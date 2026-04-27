using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmPhieuDoiTra : Form
    {
        private const string CONNECTION_STRING = @"Data Source=DESKTOP-Q1UORLL\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";

        public frmPhieuDoiTra()
        {
            InitializeComponent();
        }

        public frmPhieuDoiTra(string maHD) : this()
        {
            if (!string.IsNullOrEmpty(maHD))
            {
                this.Load += (s, e) =>
                {
                    txtMaHD.Text = maHD;
                    btnTimHoaDon_Click(null, null);
                };
            }
        }

        private void frmPhieuDoiTra_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtMaHD, "Nhập mã hóa đơn...");
            SetPlaceholder(txtLyDo, "VD: Thuốc hết hạn, sai đơn...");
            txtTienHoan.Text = "0";

            var tip = new ToolTip();
            tip.SetToolTip(btnLamMoi, "Làm mới toàn bộ form");

            dgvChiTietHD.SelectionChanged += (s, e2) => TinhTienHoan();
            numSoLuong.ValueChanged += (s, e2) => TinhTienHoan();
        }

        private void TinhTienHoan()
        {
            if (dgvChiTietHD.CurrentRow == null || dgvChiTietHD.CurrentRow.IsNewRow) return;
            try
            {
                decimal thanhTien = Convert.ToDecimal(dgvChiTietHD.CurrentRow.Cells["Thành Tiền"].Value);
                decimal soLuongMua = Convert.ToDecimal(dgvChiTietHD.CurrentRow.Cells["Số Lượng Mua"].Value);

                if (soLuongMua == 0) return;

                decimal donGiaThucTe = thanhTien / soLuongMua;
                decimal soLuongDoiTra = numSoLuong.Value;

                txtTienHoan.Text = (donGiaThucTe * soLuongDoiTra).ToString("N0");
                txtTienHoan.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            }
            catch { }
        }

        private void btnTimHoaDon_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.Trim();
            if (string.IsNullOrEmpty(maHD) || maHD == "Nhập mã hóa đơn...")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn cần tìm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            CT.MALO,
                            T.MATHUOC, 
                            T.TENTHUOC     AS [Tên Thuốc],
                            CT.SOLUONG     AS [Số Lượng Mua], 
                            ISNULL((
                                SELECT SUM(cdt.SOLUONGTRA) 
                                FROM CHITIETDOITRA cdt 
                                JOIN PHIEUDOITRA pdt ON pdt.MAPHIEUDOITRA = cdt.MAPHIEUDOITRA 
                                WHERE pdt.MAHD = CT.MAHD AND cdt.MATHUOC = T.MATHUOC AND pdt.TRANGTHAI <> N'TuChoi'
                            ), 0) AS [Đã Trả],
                            (CT.SOLUONG - ISNULL((
                                SELECT SUM(cdt.SOLUONGTRA) 
                                FROM CHITIETDOITRA cdt 
                                JOIN PHIEUDOITRA pdt ON pdt.MAPHIEUDOITRA = cdt.MAPHIEUDOITRA 
                                WHERE pdt.MAHD = CT.MAHD AND cdt.MATHUOC = T.MATHUOC AND pdt.TRANGTHAI <> N'TuChoi'
                            ), 0)) AS [Có Thể Trả],
                            CT.DONGIABAN   AS [Đơn Giá], 
                            CT.GIAMGIAITEM AS [Giảm Giá], 
                            CT.THANHTIEN   AS [Thành Tiền]
                        FROM CHITIETHOADON CT
                        JOIN LOHANG LH ON CT.MALO    = LH.MALO
                        JOIN THUOC  T  ON LH.MATHUOC = T.MATHUOC
                        WHERE CT.MAHD = @MaHD";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaHD", maHD);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvChiTietHD.DataSource = dt;
                        if (dgvChiTietHD.Columns.Contains("MALO")) dgvChiTietHD.Columns["MALO"].Visible = false;
                        if (dgvChiTietHD.Columns.Contains("MATHUOC")) dgvChiTietHD.Columns["MATHUOC"].Visible = false;

                        if (dgvChiTietHD.Columns.Contains("Đơn Giá")) dgvChiTietHD.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
                        if (dgvChiTietHD.Columns.Contains("Giảm Giá")) dgvChiTietHD.Columns["Giảm Giá"].DefaultCellStyle.Format = "N0";
                        if (dgvChiTietHD.Columns.Contains("Thành Tiền")) dgvChiTietHD.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";

                        if (dgvChiTietHD.Columns.Contains("Có Thể Trả"))
                        {
                            dgvChiTietHD.Columns["Có Thể Trả"].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                            dgvChiTietHD.Columns["Có Thể Trả"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
                        }

                        dgvChiTietHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvChiTietHD.ClearSelection();
                        grpDanhSach.Text = $"Danh Sách Thuốc Trong Hóa Đơn  —  {dt.Rows.Count} dòng";
                    }
                    else
                    {
                        dgvChiTietHD.DataSource = null;
                        grpDanhSach.Text = "Danh Sách Thuốc Trong Hóa Đơn";
                        MessageBox.Show("Không tìm thấy hóa đơn hoặc hóa đơn trống!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi truy vấn CSDL:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnHoanTien_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHD.CurrentRow == null || dgvChiTietHD.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng trong danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongDoiTra = Convert.ToInt32(numSoLuong.Value);
            int coTheTra = Convert.ToInt32(dgvChiTietHD.CurrentRow.Cells["Có Thể Trả"].Value);

            if (soLuongDoiTra <= 0)
            {
                MessageBox.Show("Số lượng đổi trả phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soLuongDoiTra > coTheTra)
            {
                MessageBox.Show($"Thuốc này chỉ còn có thể trả tối đa {coTheTra} sản phẩm (do trước đó đã trả rồi)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tienHoanStr = txtTienHoan.Text.Replace(",", "").Trim();
            if (!decimal.TryParse(tienHoanStr, out decimal tienHoan) || tienHoan <= 0)
            {
                MessageBox.Show("Số tiền hoàn không hợp lệ, vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvChiTietHD.CurrentRow;
            string maLo = row.Cells["MALO"].Value.ToString();
            string maThuoc = row.Cells["MATHUOC"].Value.ToString();
            string tenThuoc = row.Cells["Tên Thuốc"].Value.ToString();
            string maHD = txtMaHD.Text.Trim();
            string lyDo = (txtLyDo.Text == "VD: Thuốc hết hạn, sai đơn..." || string.IsNullOrWhiteSpace(txtLyDo.Text)) ? "" : txtLyDo.Text.Trim();
            string maPhieuDoiTra = "DT" + DateTime.Now.ToString("yyMMddHHmmss");

            DialogResult dr = MessageBox.Show(
                $"Xác nhận đổi trả?\n\n   Thuốc        : {tenThuoc}\n   Số lượng    : {soLuongDoiTra}\n   Tiền hoàn  : {tienHoan:N0} VNĐ\n   Lý do          : {(string.IsNullOrEmpty(lyDo) ? "(không ghi)" : lyDo)}\n\nThuốc sẽ được cộng lại vào tồn kho.",
                "Xác nhận đổi trả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO PHIEUDOITRA (MAPHIEUDOITRA, MAHD, NGAYTRA, LYDO, MANV) VALUES (@MaPhieu, @MaHD, GETDATE(), @LyDo, 'NV001')", conn, transaction);
                    cmd1.Parameters.AddWithValue("@MaPhieu", maPhieuDoiTra);
                    cmd1.Parameters.AddWithValue("@MaHD", maHD);
                    cmd1.Parameters.AddWithValue("@LyDo", lyDo);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO CHITIETDOITRA (MAPHIEUDOITRA, MATHUOC, SOLUONGTRA, SOTIENHOANN, TINHTRANG) VALUES (@MaPhieu, @MaThuoc, @SoLuong, @SoTien, N'ConTot')", conn, transaction);
                    cmd2.Parameters.AddWithValue("@MaPhieu", maPhieuDoiTra);
                    cmd2.Parameters.AddWithValue("@MaThuoc", maThuoc);
                    cmd2.Parameters.AddWithValue("@SoLuong", soLuongDoiTra);
                    cmd2.Parameters.AddWithValue("@SoTien", tienHoan);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("UPDATE LOHANG SET SOLUONGTON = SOLUONGTON + @SoLuongTra WHERE MALO = @MaLo", conn, transaction);
                    cmd3.Parameters.AddWithValue("@SoLuongTra", soLuongDoiTra);
                    cmd3.Parameters.AddWithValue("@MaLo", maLo);
                    cmd3.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show($"Đổi trả thành công!\n\n   Mã phiếu  : {maPhieuDoiTra}\n   Tiền hoàn : {tienHoan:N0} VNĐ\n   Tồn kho đã được cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtLyDo.Clear();
                    txtTienHoan.Text = "0";
                    numSoLuong.Value = 0;
                    btnTimHoaDon_Click(null, null);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi giao dịch CSDL:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            txtLyDo.Text = "";
            txtTienHoan.Text = "0";
            numSoLuong.Value = 0;
            dgvChiTietHD.DataSource = null;
            grpDanhSach.Text = "Danh Sách Thuốc Trong Hóa Đơn";
            SetPlaceholder(txtMaHD, "Nhập mã hóa đơn...");
            SetPlaceholder(txtLyDo, "VD: Thuốc hết hạn, sai đơn...");
            txtMaHD.Focus();
        }

        private void SetPlaceholder(TextBox tb, string placeholder)
        {
            tb.Text = placeholder;
            tb.ForeColor = System.Drawing.Color.Gray;

            tb.GotFocus += (s, e) =>
            {
                if (tb.Text == placeholder) { tb.Text = ""; tb.ForeColor = System.Drawing.Color.Black; }
            };
            tb.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text)) { tb.Text = placeholder; tb.ForeColor = System.Drawing.Color.Gray; }
            };
        }
    }
}