using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmHoaDon : Form
    {
        private string noiDungHoaDon = "";

        // Constructor đã cập nhật thêm tham số DataTable dtGioHang
        public frmHoaDon(string maHD, string tenKH, string nvBanHang, decimal tongTien, string ptThanhToan, DataTable dtGioHang)
        {
            InitializeComponent();
            HienThiHoaDon(maHD, tenKH, nvBanHang, tongTien, ptThanhToan, dtGioHang);
        }

        private void HienThiHoaDon(string maHD, string tenKH, string nvBanHang, decimal tongTien, string ptThanhToan, DataTable dtGioHang)
        {
            rtbHoaDon.Clear();
            rtbHoaDon.SelectionAlignment = HorizontalAlignment.Center;
            rtbHoaDon.AppendText("==========================================\n");
            rtbHoaDon.AppendText("NHÀ THUỐC PHARMACY\n");
            rtbHoaDon.AppendText("Địa chỉ: 123 Đường Y Tế, TP. HCM\n");
            rtbHoaDon.AppendText("==========================================\n\n");

            rtbHoaDon.SelectionAlignment = HorizontalAlignment.Left;
            rtbHoaDon.AppendText($"Mã hóa đơn: {maHD}\n");
            rtbHoaDon.AppendText($"Ngày lập  : {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}\n");
            rtbHoaDon.AppendText($"Nhân viên : {nvBanHang}\n");
            rtbHoaDon.AppendText($"Khách hàng: {tenKH}\n");
            rtbHoaDon.AppendText("------------------------------------------\n");

            // Format cột: Cột 1 căn trái 19 ký tự, Cột 2 căn phải 4 ký tự, Cột 3 căn phải 15 ký tự
            rtbHoaDon.AppendText(string.Format("{0,-19} {1,4} {2,15}\n", "TÊN THUỐC", "SL", "THÀNH TIỀN"));

            // Quét danh sách Giỏ Hàng thay cho dữ liệu giả
            foreach (DataRow row in dtGioHang.Rows)
            {
                string tenThuoc = row["TenThuoc"].ToString();
                // Giới hạn chiều dài tên thuốc để giữ format không bị đẩy cột
                if (tenThuoc.Length > 18)
                {
                    tenThuoc = tenThuoc.Substring(0, 15) + "...";
                }

                string sl = row["SoLuong"].ToString();
                string tt = Convert.ToDecimal(row["ThanhTien"]).ToString("N0");

                rtbHoaDon.AppendText(string.Format("{0,-19} {1,4} {2,15}\n", tenThuoc, sl, tt));
            }

            rtbHoaDon.AppendText("------------------------------------------\n");

            rtbHoaDon.SelectionAlignment = HorizontalAlignment.Right;
            rtbHoaDon.AppendText($"TỔNG CỘNG: {tongTien.ToString("N0")} VNĐ\n");
            rtbHoaDon.AppendText($"PT Thanh toán: {ptThanhToan}\n\n");

            rtbHoaDon.SelectionAlignment = HorizontalAlignment.Center;
            rtbHoaDon.AppendText("Cảm ơn Quý khách và Hẹn gặp lại!\n");
            rtbHoaDon.AppendText("(Hàng mua rồi miễn đổi trả sau 24h)\n");

            // Lưu text gốc vào biến private để chuẩn bị đem đi xuất PDF
            noiDungHoaDon = rtbHoaDon.Text;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi xuất PDF
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xuất hóa đơn này ra file PDF không?",
                                              "Xác Nhận Xuất Hóa Đơn PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                XuatFilePDF();
            }
        }

        private void XuatFilePDF()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF files (*.pdf)|*.pdf";
            sfd.Title = "Lưu Hóa Đơn PDF";
            sfd.FileName = "HoaDon_" + DateTime.Now.ToString("ddMMyy_HHmmss") + ".pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Dùng tính năng in giả lập ra File PDF tích hợp sẵn của Windows
                    PrintDocument pDoc = new PrintDocument();
                    pDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    pDoc.PrinterSettings.PrintToFile = true;
                    pDoc.PrinterSettings.PrintFileName = sfd.FileName;

                    // Sự kiện in vẽ chuỗi hóa đơn vào file
                    pDoc.PrintPage += new PrintPageEventHandler(DrawPdfPage);
                    pDoc.Print();

                    MessageBox.Show("Xuất hóa đơn thành file PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form hóa đơn sau khi in xong
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất PDF: " + ex.Message + "\nChú ý: Tính năng này yêu cầu 'Microsoft Print to PDF' trên Windows.",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Phương thức vẽ chữ lên trang in (PDF)
        private void DrawPdfPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            // Font in cần phải là Font Monospaced như Courier New để format cột dọc ngay ngắn
            Font font = new Font("Courier New", 11);
            int startX = 50;
            int startY = 50;
            int offset = 40;

            graphics.DrawString(noiDungHoaDon, font, new SolidBrush(Color.Black), startX, startY + offset);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}