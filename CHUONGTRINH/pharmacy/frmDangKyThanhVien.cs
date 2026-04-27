using System;
using System.Windows.Forms;

// ================================================================
// frmDangKyThanhVien.cs  –  FIXED
//
// THAY ĐỔI:
//  [F1] Xóa lblHanThe – THETHANHVIEN không có cột HANTHE trong SQL
//  [F2] Thêm txtEmail, txtTenDangNhap, txtMatKhau, txtXacNhanMK
//       (KHACHHANGTHANHVIEN yêu cầu EMAIL + TENDANGNHAP + MATKHAU)
//  [F3] Gọi DatabaseHelper.SaveKhachHangThanhVien() thật
//  [F4] Validate trùng SĐT / email / tên đăng nhập trước khi lưu
// ================================================================

namespace PharmacyManagement
{
    public partial class frmDangKyThanhVien : Form
    {
        public frmDangKyThanhVien()
        {
            InitializeComponent();
        }

        private void frmDangKyThanhVien_Load(object sender, EventArgs e)
        {
            lblNgayCap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            // [F1] KHÔNG còn lblHanThe – thẻ Pharmacy không có ngày hết hạn
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // ── Lấy giá trị ────────────────────────────────────────
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tenDN = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string xacNhanMK = txtXacNhanMK.Text;
            DateTime? ngaySinh = null;
            if (dtpNgaySinh.Checked) ngaySinh = dtpNgaySinh.Value.Date;

            // ── Validate bắt buộc ───────────────────────────────────
            if (string.IsNullOrEmpty(hoTen))
            { TapTrungLoi(txtHoTen, "Họ tên là bắt buộc!"); return; }

            if (sdt.Length < 10 || !IsAllDigits(sdt))
            { TapTrungLoi(txtSDT, "Số điện thoại không hợp lệ (10 chữ số)!"); return; }

            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            { TapTrungLoi(txtEmail, "Email không hợp lệ!"); return; }

            if (tenDN.Length < 6)
            { TapTrungLoi(txtTenDangNhap, "Tên đăng nhập tối thiểu 6 ký tự!"); return; }

            if (matKhau.Length < 6)
            { TapTrungLoi(txtMatKhau, "Mật khẩu tối thiểu 6 ký tự!"); return; }

            if (matKhau != xacNhanMK)
            { TapTrungLoi(txtXacNhanMK, "Mật khẩu xác nhận không khớp!"); return; }

            // ── Kiểm tra trùng (gọi DB) ─────────────────────────────
            if (DatabaseHelper.KiemTraSDTTonTai(sdt))
            { TapTrungLoi(txtSDT, "Số điện thoại đã được đăng ký!"); return; }

            if (DatabaseHelper.KiemTraEmailTonTai(email))
            { TapTrungLoi(txtEmail, "Email đã được sử dụng!"); return; }

            if (DatabaseHelper.KiemTraTenDangNhapKhachTonTai(tenDN))
            { TapTrungLoi(txtTenDangNhap, "Tên đăng nhập đã tồn tại!"); return; }

            // ── Sinh mã KH và lưu DB ─────────────────────────────────
            string maKH = DatabaseHelper.GenerateMaKH();

            bool saved = DatabaseHelper.SaveKhachHangThanhVien(
                maKH, hoTen, sdt, diaChi, ngaySinh, email, tenDN, matKhau);

            if (!saved) return;   // lỗi đã được show trong DatabaseHelper

            // ── Thông báo thành công ─────────────────────────────────
            MessageBox.Show(
                $"Đăng ký thành công!\n\n" +
                $"Mã khách hàng : {maKH}\n" +
                $"Họ tên        : {hoTen}\n" +
                $"Số điện thoại : {sdt}\n" +
                $"Tên đăng nhập : {tenDN}\n" +
                $"Ngày cấp thẻ  : {DateTime.Now:dd/MM/yyyy}\n" +
                $"Hạng thẻ      : Đồng (có thể nâng hạng khi tích điểm)",
                "Đăng ký thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ── Helper ──────────────────────────────────────────────────
        private void TapTrungLoi(System.Windows.Forms.Control ctrl, string msg)
        {
            MessageBox.Show(msg, "Kiểm tra thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ctrl.Focus();
        }

        private bool IsAllDigits(string s)
        {
            foreach (char c in s) if (!char.IsDigit(c)) return false;
            return true;
        }
    }
}