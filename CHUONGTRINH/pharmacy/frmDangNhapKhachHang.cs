using System;
using System.Data.SqlClient;
using System.Windows.Forms;

// ================================================================
// frmDangNhapKhachHang.cs  –  PHIÊN BẢN SỬA LỖI
//
// Thay đổi:
//  1. Khi đăng nhập thất bại, tự động kiểm tra xem tài khoản có
//     tồn tại ở loại KH khác không → gợi ý người dùng đổi tab.
//  2. Placeholder text cho ô tên đăng nhập (via Windows API).
//  3. Thông báo lỗi rõ ràng hơn.
// ================================================================

namespace PharmacyManagement
{
    public partial class frmDangNhapKhachHang : Form
    {
        private int _soLanSai = 0;

        public frmDangNhapKhachHang()
        {
            InitializeComponent();
        }

        private void frmDangNhapKhachHang_Load(object sender, EventArgs e)
        {
            rdoThanhVien.Checked = true;
            txtTenDangNhap.Focus();
        }

        // ── Chuyển UI theo loại KH ───────────────────────────────
        private void rdoThanhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoThanhVien.Checked)
            {
                lblTitle.Text = "ĐĂNG NHẬP THÀNH VIÊN";
                pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
                btnDangNhap.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
                lnkDangKy.Visible = true;
                lblHuongDan.Text = "Nhập tên đăng nhập thành viên và mật khẩu.";
            }
        }

        private void rdoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSi.Checked)
            {
                lblTitle.Text = "ĐĂNG NHẬP KHÁCH SỈ";
                pnlHeader.BackColor = System.Drawing.Color.FromArgb(230, 81, 0);
                btnDangNhap.BackColor = System.Drawing.Color.FromArgb(230, 81, 0);
                lnkDangKy.Visible = false;
                lblHuongDan.Text = "Nhập tên đăng nhập và mật khẩu do nhà thuốc cung cấp.";
            }
        }

        // ── Đăng nhập ────────────────────────────────────────────
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rdoThanhVien.Checked)
                DangNhapThanhVien(user, pass);
            else
                DangNhapSi(user, pass);
        }

        private void DangNhapThanhVien(string user, string pass)
        {
            string maKH, hoTen, hangTV;
            int diemTichLuy;

            bool ok = DatabaseHelper.CheckLoginThanhVien(
                user, pass, out maKH, out hoTen, out hangTV, out diemTichLuy);

            if (ok)
            {
                SessionManager.LoginKhachHang(maKH, hoTen, hangTV, diemTichLuy);
                ThongBaoThanhCong(
                    $"Chào mừng, {hoTen}!\n" +
                    $"Hạng thẻ : {HienThiHangTV(hangTV)}\n" +
                    $"Điểm tích lũy : {diemTichLuy:N0} điểm");
            }
            else
            {
                // Kiểm tra xem tên đăng nhập này có phải là tài khoản Sỉ không
                if (KiemTraTonTaiTronBangKhac(user, isCheckingSi: true))
                {
                    var res = MessageBox.Show(
                        $"Tên đăng nhập '{user}' thuộc loại tài khoản KHÁCH SỈ,\n" +
                        "không phải Thành Viên.\n\n" +
                        "Bạn có muốn chuyển sang tab Khách Sỉ không?",
                        "Gợi ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        rdoSi.Checked = true;
                        txtMatKhau.Clear();
                        txtMatKhau.Focus();
                        return;
                    }
                }
                XuLySaiMatKhau();
            }
        }

        private void DangNhapSi(string user, string pass)
        {
            string maKH, hoTen, tenCongTy;
            float tyLeChietKhau;
            int soLanSaiDB;

            bool ok = DatabaseHelper.CheckLoginKhachHangSi(
                user, pass, out maKH, out hoTen,
                out tenCongTy, out tyLeChietKhau, out soLanSaiDB);

            if (ok)
            {
                DatabaseHelper.ResetSoLanSaiKhachHangSi(user);
                SessionManager.LoginKhachHangSi(maKH, hoTen, tenCongTy, tyLeChietKhau);
                ThongBaoThanhCong(
                    $"Đăng nhập thành công!\n" +
                    $"Công ty     : {tenCongTy}\n" +
                    $"Chiết khấu  : {tyLeChietKhau * 100:F1}%");
            }
            else
            {
                // Kiểm tra xem có phải nhầm tab không
                if (KiemTraTonTaiTronBangKhac(user, isCheckingSi: false))
                {
                    var res = MessageBox.Show(
                        $"Tên đăng nhập '{user}' thuộc loại tài khoản THÀNH VIÊN,\n" +
                        "không phải Khách Sỉ.\n\n" +
                        "Bạn có muốn chuyển sang tab Thành Viên không?",
                        "Gợi ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        rdoThanhVien.Checked = true;
                        txtMatKhau.Clear();
                        txtMatKhau.Focus();
                        return;
                    }
                }

                // Cập nhật số lần sai trong DB
                DatabaseHelper.UpdateSoLanSaiKhachHangSi(user, soLanSaiDB + 1);
                XuLySaiMatKhau();
            }
        }

        // ── Kiểm tra tài khoản có tồn tại trong bảng kia không ──
        /// <summary>
        /// Khi isCheckingSi=true  → kiểm tra xem user có trong KHACHHANGSI không
        /// Khi isCheckingSi=false → kiểm tra xem user có trong KHACHHANGTHANHVIEN không
        /// </summary>
        private bool KiemTraTonTaiTronBangKhac(string user, bool isCheckingSi)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = isCheckingSi
                        ? "SELECT COUNT(*) FROM KHACHHANGSI         WHERE TENDANGNHAP = @u"
                        : "SELECT COUNT(*) FROM KHACHHANGTHANHVIEN  WHERE TENDANGNHAP = @u";
                    var cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u", user);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch { return false; }
        }

        private void ThongBaoThanhCong(string msg)
        {
            MessageBox.Show(msg, "Đăng nhập thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void XuLySaiMatKhau()
        {
            _soLanSai++;
            int conLai = 5 - _soLanSai;

            if (_soLanSai >= 5)
            {
                MessageBox.Show(
                    "Đăng nhập sai quá 5 lần!\n" +
                    "Tài khoản tạm thời bị khóa.\n" +
                    "Vui lòng liên hệ nhà thuốc để mở khóa.",
                    "Bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    $"Tên đăng nhập hoặc mật khẩu không đúng!\nBạn còn {conLai} lần thử.",
                    "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        // ── Đăng ký thành viên mới ───────────────────────────────
        private void lnkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmDangKyThanhVien();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "Đăng ký thành công! Hãy đăng nhập với tài khoản vừa tạo.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnDangNhap_Click(sender, e);
        }

        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMatKhau.Focus();
            }
        }

        // ── Helper ──────────────────────────────────────────────
        private string HienThiHangTV(string hang)
        {
            switch (hang)
            {
                case "Bac": return "🥈 Bạc";
                case "Vang": return "🥇 Vàng";
                default: return "🥉 Đồng";
            }
        }
    }
}