using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PharmacyManagement
{
    public partial class frmBaoCaoThongKe : Form
    {
        // Chuỗi kết nối CSDL
        private const string CONNECTION_STRING = "Data Source=DESKTOP-Q1UORLL\\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";

        public frmBaoCaoThongKe()
        {
            InitializeComponent();
        }

        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();

            // Mặc định xem từ đầu tháng 10/2024 (theo dữ liệu mẫu SQL của bạn)
            dtpTuNgay.Value = new DateTime(2024, 10, 1);
            dtpDenNgay.Value = DateTime.Now;

            LoadDuLieuThongKe();
        }

        private void SetupVisualStyling()
        {
            this.pnlHeader.BackColor = ColorTranslator.FromHtml("#0066CC");
            this.btnThongKe.BackColor = ColorTranslator.FromHtml("#28A745");
            this.btnXuatPDF.BackColor = ColorTranslator.FromHtml("#DC3545");

            dgvTopThuoc.BackgroundColor = Color.White;
            dgvTopThuoc.EnableHeadersVisualStyles = false;
            dgvTopThuoc.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgvTopThuoc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadDuLieuThongKe();
        }

        private void LoadDuLieuThongKe()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();

                    // 1. Lấy Tổng doanh thu và số đơn
                    string sqlTong = @"SELECT ISNULL(SUM(TONGTIEN), 0) AS DoanhThu, COUNT(MAHD) AS SoDon 
                                       FROM HOADON 
                                       WHERE TRANGTHAID = N'DaThanhToan' 
                                       AND NGAYLAP >= @TuNgay AND NGAYLAP <= @DenNgay";

                    using (SqlCommand cmd = new SqlCommand(sqlTong, conn))
                    {
                        cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                        cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTongDoanhThu.Text = string.Format("{0:N0} VNĐ", reader["DoanhThu"]);
                                lblSoDonHang.Text = reader["SoDon"].ToString() + " Đơn hàng";
                            }
                            reader.Close();
                        }
                    }

                    // 2. Lấy danh sách mặt hàng bán ra (Đã sửa lỗi kết nối qua bảng LOHANG)
                    string sqlGrid = @"SELECT T.TENTHUOC AS [Tên Thuốc], 
                                              SUM(C.SOLUONG) AS [Số Lượng Bán], 
                                              SUM(C.SOLUONG * C.DONGIABAN - C.GIAMGIAITEM) AS [Doanh Thu (VNĐ)]
                                       FROM CHITIETHOADON C
                                       INNER JOIN LOHANG L ON C.MALO = L.MALO
                                       INNER JOIN THUOC T ON L.MATHUOC = T.MATHUOC
                                       INNER JOIN HOADON H ON C.MAHD = H.MAHD
                                       WHERE H.TRANGTHAID = N'DaThanhToan'
                                       AND H.NGAYLAP >= @TuNgay AND H.NGAYLAP <= @DenNgay
                                       GROUP BY T.TENTHUOC
                                       ORDER BY [Doanh Thu (VNĐ)] DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sqlGrid, conn);
                    da.SelectCommand.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    da.SelectCommand.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTopThuoc.DataSource = dt;
                    dgvTopThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvTopThuoc.Columns["Doanh Thu (VNĐ)"] != null)
                        dgvTopThuoc.Columns["Doanh Thu (VNĐ)"].DefaultCellStyle.Format = "N0";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            if (dgvTopThuoc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatFilePDF(sfd.FileName);

                    // Bổ sung chức năng XEM TRƯỚC (Preview)
                    DialogResult dr = MessageBox.Show("Đã xuất báo cáo thành công! Bạn có muốn mở file xem ngay không?",
                                                      "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void XuatFilePDF(string path)
        {
            // Khởi tạo Document A4
            Document doc = new Document(PageSize.A4, 30, 30, 40, 40);
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            // Thiết lập Font chữ hỗ trợ tiếng Việt Unicode
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            var fTitle = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
            var fNormal = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
            var fBold = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            var fItalic = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.ITALIC);

            // 1. Tiêu đề báo cáo
            Paragraph title = new Paragraph("BÁO CÁO DOANH THU NHÀ THUỐC PHARMACY", fTitle);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 20;
            doc.Add(title);

            // 2. Thông tin chung
            doc.Add(new Paragraph($"Người lập: {SessionManager.TenNV}", fNormal));
            doc.Add(new Paragraph($"Thời gian thống kê: Từ {dtpTuNgay.Value:dd/MM/yyyy} đến {dtpDenNgay.Value:dd/MM/yyyy}", fNormal));
            doc.Add(new Paragraph($"Tổng doanh thu kỳ này: {lblTongDoanhThu.Text}", fBold));
            doc.Add(new Paragraph($"Số lượng đơn hàng: {lblSoDonHang.Text}", fNormal));
            doc.Add(new Paragraph(" ")); // Dòng trống

            // 3. Bảng chi tiết
            PdfPTable table = new PdfPTable(dgvTopThuoc.ColumnCount) { WidthPercentage = 100 };
            table.SetWidths(new float[] { 3f, 1.5f, 2f }); // Độ rộng các cột

            // Header bảng
            foreach (DataGridViewColumn col in dgvTopThuoc.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, fBold));
                cell.BackgroundColor = new BaseColor(240, 240, 240);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 8;
                table.AddCell(cell);
            }

            // Dữ liệu bảng
            foreach (DataGridViewRow row in dgvTopThuoc.Rows)
            {
                if (!row.IsNewRow)
                {
                    table.AddCell(new Phrase(row.Cells[0].Value?.ToString(), fNormal)); // Tên thuốc

                    PdfPCell cellSL = new PdfPCell(new Phrase(row.Cells[1].Value?.ToString(), fNormal));
                    cellSL.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cellSL); // Số lượng

                    PdfPCell cellDT = new PdfPCell(new Phrase(string.Format("{0:N0}", row.Cells[2].Value), fNormal));
                    cellDT.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cellDT); // Doanh thu
                }
            }
            doc.Add(table);

            // 4. Phần chân trang (Ngày tháng và Ký tên)
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            DateTime n = DateTime.Now;
            string dateStr = $"..., Ngày {n.Day:00} tháng {n.Month:00} năm {n.Year}";

            Paragraph pDate = new Paragraph(dateStr, fItalic);
            pDate.Alignment = Element.ALIGN_RIGHT;
            doc.Add(pDate);

            Paragraph pSign = new Paragraph("Người lập báo cáo", fBold);
            pSign.Alignment = Element.ALIGN_RIGHT;
            pSign.SpacingBefore = 5;
            // padding-right giả lập bằng cách thêm khoảng trắng hoặc căn chỉnh margin
            pSign.IndentationRight = 20;
            doc.Add(pSign);

            Paragraph pSignDetail = new Paragraph("(Ký và ghi rõ họ tên)", fItalic);
            pSignDetail.Alignment = Element.ALIGN_RIGHT;
            pSignDetail.IndentationRight = 25;
            doc.Add(pSignDetail);

            doc.Close();
        }
    }
}