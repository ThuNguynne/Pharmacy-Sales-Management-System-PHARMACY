using System;
using System.Windows.Forms;

// ================================================================
// frmDangKyKhachHangSi.cs  –  MỚI
//
// Đăng ký hợp đồng mua sỉ — ghi vào KHACHHANG (LoaiKH='Si')
// và KHACHHANGSI (TENCONGTY, MST, TENDANGNHAP, MATKHAU,
//                 HANMUCCONGNO, TYLECHIETKHAU, THOIHANTHANHTOAN,
//                 NGAYKYHD, NGAYHETHAN, TRANGTHAID='HieuLuc')
//
// SQL constraint: NGAYHETHAN > NGAYKYHD  → validate trước khi lưu
// ================================================================

namespace PharmacyManagement
{
    public partial class frmDangKyKhachHangSi : Form
    {
        public frmDangKyKhachHangSi()
        {
            InitializeComponent();
        }

        private void frmDangKyKhachHangSi_Load(object sender, EventArgs e)
        {
            dtpNgayKyHD.Value = DateTime.Today;
            dtpNgayHetHan.Value = DateTime.Today.AddYears(1);
            nudHanMuc.Value = 50_000_000m;
            nudTyLeChietKhau.Value = 5m;      // 5 %
            nudThoiHan.Value = 30;         // 30 ngày
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // ── Lấy giá trị ────────────────────────────────────────
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string cty = txtTenCongTy.Text.Trim();
            string mst = txtMST.Text.Trim();
            string tenDN = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string xacNhan = txtXacNhanMK.Text;
            DateTime? ngaySinh = null;
            if (dtpNgaySinh.Checked) ngaySinh = dtpNgaySinh.Value.Date;

            float hanMuc = (float)nudHanMuc.Value;
            float tyLeCK = (float)nudTyLeChietKhau.Value / 100f;
            int thoiHan = (int)nudThoiHan.Value;
            DateTime ngayKy = dtpNgayKyHD.Value.Date;
            DateTime ngayHH = dtpNgayHetHan.Value.Date;

            // ── Validate ──────────────────────────────────────────
            if (string.IsNullOrEmpty(hoTen))
            { Loi(txtHoTen, "Họ tên là bắt buộc!"); return; }

            if (sdt.Length < 10 || !IsDigits(sdt))
            { Loi(txtSDT, "Số điện thoại không hợp lệ!"); return; }

            if (string.IsNullOrEmpty(cty))
            { Loi(txtTenCongTy, "Tên công ty là bắt buộc!"); return; }

            if (string.IsNullOrEmpty(mst))
            { Loi(txtMST, "Mã số thuế là bắt buộc!"); return; }

            if (tenDN.Length < 6)
            { Loi(txtTenDangNhap, "Tên đăng nhập tối thiểu 6 ký tự!"); return; }

            if (matKhau.Length < 6)
            { Loi(txtMatKhau, "Mật khẩu tối thiểu 6 ký tự!"); return; }

            if (matKhau != xacNhan)
            { Loi(txtXacNhanMK, "Mật khẩu xác nhận không khớp!"); return; }

            if (ngayHH <= ngayKy)   // CHK_KHSI_NGAY
            {
                MessageBox.Show("Ngày hết hạn phải sau Ngày ký hợp đồng!",
                    "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ── Kiểm tra trùng ────────────────────────────────────
            if (DatabaseHelper.KiemTraSDTTonTai(sdt))
            { Loi(txtSDT, "Số điện thoại đã được đăng ký!"); return; }

            if (DatabaseHelper.KiemTraTenDangNhapKhachTonTai(tenDN))
            { Loi(txtTenDangNhap, "Tên đăng nhập đã tồn tại!"); return; }

            // ── Sinh mã và lưu ────────────────────────────────────
            string maKH = DatabaseHelper.GenerateMaKH();

            bool saved = DatabaseHelper.SaveKhachHangSi(
                maKH, hoTen, sdt, diaChi, ngaySinh,
                cty, mst, tenDN, matKhau,
                hanMuc, tyLeCK, thoiHan, ngayKy, ngayHH);

            if (!saved) return;

            MessageBox.Show(
                $"Đăng ký khách sỉ thành công!\n\n" +
                $"Mã khách hàng  : {maKH}\n" +
                $"Công ty         : {cty}\n" +
                $"Tên đăng nhập  : {tenDN}\n" +
                $"Chiết khấu      : {tyLeCK * 100:F1}%\n" +
                $"Hiệu lực        : {ngayKy:dd/MM/yyyy} → {ngayHH:dd/MM/yyyy}",
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

        // ── Validate ngày khi thay đổi ────────────────────────────
        private void dtpNgayKyHD_ValueChanged(object sender, EventArgs e)
        {
            // Tự động đề xuất hết hạn = ngày ký + 1 năm
            if (dtpNgayHetHan.Value <= dtpNgayKyHD.Value)
                dtpNgayHetHan.Value = dtpNgayKyHD.Value.AddYears(1);
        }

        // ── Helper ───────────────────────────────────────────────
        private void Loi(System.Windows.Forms.Control ctrl, string msg)
        {
            MessageBox.Show(msg, "Kiểm tra thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ctrl.Focus();
        }

        private bool IsDigits(string s)
        {
            foreach (char c in s) if (!char.IsDigit(c)) return false;
            return true;
        }
    }
}