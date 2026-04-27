/*using System;
using System.Windows.Forms;

// ================================================================
// frmDangNhap.cs  –  Đăng nhập NHÂN VIÊN  (FIXED)
//
// THAY ĐỔI:
//  - Bỏ hết mock "admin/123456", gọi DatabaseHelper.CheckLogin()
//  - Cập nhật SOLANSIMATKHAU vào DB sau mỗi lần sai
//  - Khóa tài khoản khi >= 5 lần sai
//  - Thêm link mở frmDangNhapKhachHang cho khách hàng
// ================================================================

namespace PharmacyManagement
{
    public partial class frmDangNhap : Form
    {
        // Đếm số lần sai trong phiên đăng nhập hiện tại
        private int _soLanSai = 0;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        // ── Đăng nhập nhân viên ──────────────────────────────────
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV, tenNV, vaiTro;
            int capDoQuyen, soLanSaiDB;

            bool ok = DatabaseHelper.CheckLogin(
                user, pass,
                out maNV, out tenNV, out vaiTro,
                out capDoQuyen, out soLanSaiDB);

            if (ok)
            {
                // Đăng nhập thành công → reset bộ đếm sai
                DatabaseHelper.ResetSoLanSaiNhanVien(user);
                SessionManager.Login(maNV, tenNV, vaiTro, capDoQuyen);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                _soLanSai++;

                // Ghi số lần sai mới vào DB (trigger TR_KhoaTaiKhoan cũng chạy)
                DatabaseHelper.UpdateSoLanSaiNhanVien(user, soLanSaiDB + 1);

                int conLai = 5 - _soLanSai;
                if (_soLanSai >= 5 || soLanSaiDB + 1 >= 5)
                {
                    MessageBox.Show(
                        "Tài khoản đã bị khóa do nhập sai quá 5 lần!\n" +
                        "Liên hệ quản lý hệ thống để mở khóa.",
                        "Bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(
                        $"Sai tên đăng nhập hoặc mật khẩu!\nBạn còn {conLai} lần thử.",
                        "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e);
        }

        // ── Link chuyển sang đăng nhập khách hàng ────────────────
        private void lnkKhachHang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmDangNhapKhachHang();
            frm.ShowDialog(this);
        }
    }
}*/

using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmDangNhap : Form
    {
        // Chuỗi kết nối CSDL (Được giữ nguyên)
        private const string CONNECTION_STRING = "Data Source=DESKTOP-Q1UORLL\\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";

        public frmDangNhap()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();
            SetupPlaceholders();
            ApplyRoundedCorners();
        }

        #region --- GIAO DIỆN & HIỆU ỨNG (UI/UX) ---

        private void SetupVisualStyling()
        {
            // Bảng màu hiện đại (Trust Blue & Soft Light)
            this.pnlHeader.BackColor = ColorTranslator.FromHtml("#0052CC");
            this.lblTitle.ForeColor = Color.White;

            this.btn_Login.BackColor = ColorTranslator.FromHtml("#0052CC");
            this.btn_Login.ForeColor = Color.White;

            this.btn_Exit.BackColor = ColorTranslator.FromHtml("#EBECF0");
            this.btn_Exit.ForeColor = ColorTranslator.FromHtml("#172B4D");

            this.pnlMain.BackColor = ColorTranslator.FromHtml("#FAFBFC");
            this.pnlLoginBox.BackColor = Color.White;

            ResetPanelColor(pnlUsername, txtUsername);
            ResetPanelColor(pnlPassword, txtPassword);

            this.txtPassword.PasswordChar = '•';
        }

        private void ApplyRoundedCorners()
        {
            MakeRoundedPanel(pnlLoginBox, 12); // Bo góc nhẹ nhàng hơn
            MakeRoundedPanel(pnlUsername, 6);
            MakeRoundedPanel(pnlPassword, 6);
            MakeRoundedButton(btn_Login, 6);
            MakeRoundedButton(btn_Exit, 6);
        }

        private void MakeRoundedPanel(Panel panel, int radius)
        {
            panel.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = GetRoundedRectPath(panel.ClientRectangle, radius))
                    panel.Region = new Region(path);
            };
        }

        private void MakeRoundedButton(Button button, int radius)
        {
            button.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = GetRoundedRectPath(button.ClientRectangle, radius))
                    button.Region = new Region(path);
            };
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void SetupPlaceholders()
        {
            SetPlaceholder(txtUsername, "Nhập tên đăng nhập");
            SetPlaceholder(txtPassword, "Nhập mật khẩu");
        }

        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Tag = placeholderText;
            textBox.Text = placeholderText;
            textBox.ForeColor = ColorTranslator.FromHtml("#7A869A"); // Màu chữ xám thanh lịch
            if (textBox == txtPassword) textBox.PasswordChar = '\0';
        }

        private void RemovePlaceholder(TextBox textBox)
        {
            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.ForeColor = ColorTranslator.FromHtml("#172B4D"); // Màu chữ chính xác nét
                if (textBox == txtPassword && !chkShowPass.Checked) textBox.PasswordChar = '•';
            }
        }

        // UX: Đổi màu nền khi TextBox được Focus
        private void SetPanelFocus(Panel pnl, TextBox txt)
        {
            pnl.BackColor = ColorTranslator.FromHtml("#DEEBFF");
            txt.BackColor = ColorTranslator.FromHtml("#DEEBFF");
        }

        private void ResetPanelColor(Panel pnl, TextBox txt)
        {
            pnl.BackColor = ColorTranslator.FromHtml("#F4F5F7");
            txt.BackColor = ColorTranslator.FromHtml("#F4F5F7");
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtUsername);
            SetPanelFocus(pnlUsername, txtUsername);
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "") SetPlaceholder(txtUsername, txtUsername.Tag.ToString());
            ResetPanelColor(pnlUsername, txtUsername);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtPassword);
            SetPanelFocus(pnlPassword, txtPassword);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "") SetPlaceholder(txtPassword, txtPassword.Tag.ToString());
            ResetPanelColor(pnlPassword, txtPassword);
        }

        // UX: Hiệu ứng Hover cho Button
        private void btn_Login_MouseEnter(object sender, EventArgs e) => btn_Login.BackColor = ColorTranslator.FromHtml("#0047B3");
        private void btn_Login_MouseLeave(object sender, EventArgs e) => btn_Login.BackColor = ColorTranslator.FromHtml("#0052CC");
        private void btn_Exit_MouseEnter(object sender, EventArgs e) => btn_Exit.BackColor = ColorTranslator.FromHtml("#DFE1E6");
        private void btn_Exit_MouseLeave(object sender, EventArgs e) => btn_Exit.BackColor = ColorTranslator.FromHtml("#EBECF0");

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPassword.Tag.ToString())
                txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '•';
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(sender, e);
            }
        }

        #endregion

        #region --- XỬ LÝ ĐĂNG NHẬP (SQL) ---
        // TOÀN BỘ CODE BÊN DƯỚI ĐƯỢC GIỮ NGUYÊN 100%

        private void btn_Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void lblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ Quản lý chi nhánh để cấp lại mật khẩu!", "Hỗ trợ kỹ thuật", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (user == txtUsername.Tag.ToString() || pass == txtPassword.Tag.ToString() || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = Authenticate(user, pass);

            if (res.IsSuccess)
            {
                // Gọi SessionManager để lưu thông tin theo đúng chuẩn
                SessionManager.Login(res.ID, res.Name, res.Role, res.CapDo);

                frmMain main = new frmMain();
                this.Hide();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(res.Msg, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm Authenticate trả về đầy đủ Cấp độ quyền
        private (bool IsSuccess, string Role, string Name, string ID, int CapDo, string Msg) Authenticate(string user, string pass)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT T.MATK, T.MATKHAU, T.TRANGTHAI, T.VAITRO, T.SOLANSIMATKHAU, T.CAPDOQUYEN, N.TENNV, N.MANV " +
                                 "FROM TAIKHOAN T INNER JOIN NHANVIEN N ON T.MANV = N.MANV WHERE T.TENDANGNHAP = @u";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", user);
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                string ma = rd["MATK"].ToString();
                                string dbPass = rd["MATKHAU"].ToString();
                                string tt = rd["TRANGTHAI"].ToString();
                                int sai = Convert.ToInt32(rd["SOLANSIMATKHAU"]);
                                string vt = rd["VAITRO"].ToString();
                                string ten = rd["TENNV"].ToString();
                                string mnv = rd["MANV"].ToString();
                                int capDo = Convert.ToInt32(rd["CAPDOQUYEN"]);

                                rd.Close();

                                if (tt != "HoatDong") return (false, null, null, null, 0, "Tài khoản đang bị khóa hoặc ngừng hoạt động!");

                                if (dbPass == pass)
                                {
                                    UpdateSai(conn, ma, 0); // Reset số lần sai
                                    return (true, vt, ten, mnv, capDo, "");
                                }
                                else
                                {
                                    sai++;
                                    UpdateSai(conn, ma, sai);
                                    if (sai >= 5)
                                    {
                                        return (false, null, null, null, 0, "Nhập sai quá 5 lần! Tài khoản đã bị khóa bảo mật.");
                                    }
                                    return (false, null, null, null, 0, $"Sai mật khẩu! Còn {5 - sai} lần thử.");
                                }
                            }
                            return (false, null, null, null, 0, "Không tìm thấy tài khoản!");
                        }
                    }
                }
                catch (Exception ex) { return (false, null, null, null, 0, $"Lỗi hệ thống CSDL: {ex.Message}"); }
            }
        }

        private void UpdateSai(SqlConnection c, string m, int s)
        {
            string up = "UPDATE TAIKHOAN SET SOLANSIMATKHAU = @s WHERE MATK = @m";
            using (SqlCommand cmd = new SqlCommand(up, c))
            {
                cmd.Parameters.AddWithValue("@s", s);
                cmd.Parameters.AddWithValue("@m", m);
                cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }
}