/*using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

// ================================================================
// frmMain.cs  –  CẬP NHẬT: Thêm Submenu cho Báo cáo thống kê
// ================================================================

namespace PharmacyManagement
{
    public partial class frmMain : Form
    {
        private Form _currentChild;

        public frmMain()
        {
            InitializeComponent();
            ApplyCustomStyles();
            CustomizeDesign();
            RegisterEvents();
            ApplyRBAC();
            ShowDashboard();
        }

        // ==============================================================
        //  KHỞI TẠO GIAO DIỆN
        // ==============================================================
        private void ApplyCustomStyles()
        {
            // Header user info
            lblUserInfo.Text = $"👤  {SessionManager.TenNV}   |   {GetVaiTroDisplay()}";

            // Style menu chính
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button btn && btn != btnDangXuat)
                {
                    btn.Font = new Font("Segoe UI", 11F);
                    btn.Padding = new Padding(20, 0, 0, 0);
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                }
            }

            // Style submenu (Đã thêm 2 nút báo cáo mới vào mảng)
            Button[] subs = { btnBanHangTaiQuay, btnDonHangOnline, btnGiaoHang,
                               btnNhapKho, btnXuatKho, btnTonKho,
                               btnBaoCaoThongKe, btnBaoCaoTongHop };
            foreach (var b in subs)
            {
                b.Font = new Font("Segoe UI", 10F);
                b.Padding = new Padding(50, 0, 0, 0);
                b.ForeColor = Color.Gainsboro;
                b.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void CustomizeDesign()
        {
            pnlBanHangSubmenu.Visible = false;
            pnlKhoSubmenu.Visible = false;
            pnlBaoCaoSubmenu.Visible = false; // Ẩn submenu báo cáo lúc mới mở
        }

        private void RegisterEvents()
        {
            btnBanHangTaiQuay.Click += btnBanHangTaiQuay_Click;
            btnDonHangOnline.Click += btnDonHangOnline_Click;
            btnGiaoHang.Click += btnGiaoHang_Click;
            btnNhapKho.Click += btnNhapKho_Click;
            btnXuatKho.Click += btnXuatKho_Click;
            btnTonKho.Click += btnTonKho_Click;
            btnKhachHang.Click += btnKhachHang_Click;

            // Đăng ký sự kiện cho menu Báo cáo mới
            btnBaoCao.Click += btnBaoCao_Click;
            btnBaoCaoThongKe.Click += btnBaoCaoThongKe_Click;
            btnBaoCaoTongHop.Click += btnBaoCaoTongHop_Click;

            btnDangXuat.Click += btnDangXuat_Click;
            btnQuanLyThuoc.Click += btnQuanLyThuoc_Click;
            btnTrangChuKH.Click += btnTrangChuKH_Click;
        }

        // ==============================================================
        //  PHÂN QUYỀN RBAC
        // ==============================================================
        private void ApplyRBAC()
        {
            string vaiTro = SessionManager.VaiTro;

            switch (vaiTro)
            {
                // ── QUẢN LÝ : full access ────────────────────────────
                case "QuanLy":
                    SetMenuVisible(btnBanHang, true);
                    SetMenuVisible(btnKho, true);
                    SetMenuVisible(btnKhachHang, true);
                    SetMenuVisible(btnBaoCao, true);
                    SetMenuVisible(btnQuanLyThuoc, true);
                    SetMenuVisible(btnTrangChuKH, true);
                    // submenu items
                    btnBanHangTaiQuay.Visible = true;
                    btnDonHangOnline.Visible = true;
                    btnGiaoHang.Visible = true;
                    btnXuatKho.Visible = true;
                    btnTonKho.Visible = true;
                    btnBaoCaoThongKe.Visible = true;
                    btnBaoCaoTongHop.Visible = true;
                    // Đổi text role badge
                    SetRoleBadge("QUẢN LÝ", Color.FromArgb(142, 68, 173));
                    break;

                // ── DƯỢC SĨ : bán hàng + KH + thuốc ────────────────
                case "DuocSi":
                    SetMenuVisible(btnBanHang, true);
                    SetMenuVisible(btnKho, false);
                    SetMenuVisible(btnKhachHang, true);
                    SetMenuVisible(btnBaoCao, false);
                    SetMenuVisible(btnQuanLyThuoc, true);
                    SetMenuVisible(btnTrangChuKH, true);
                    btnBanHangTaiQuay.Visible = true;
                    btnDonHangOnline.Visible = true;
                    btnGiaoHang.Visible = false;
                    btnNhapKho.Visible = false;
                    btnXuatKho.Visible = false;
                    btnTonKho.Visible = false;
                    SetRoleBadge("DƯỢC SĨ", Color.FromArgb(39, 174, 96));
                    break;

                // ── NHÂN VIÊN KHO : kho + thuốc ─────────────────────
                case "NhanVienKho":
                    SetMenuVisible(btnBanHang, false);
                    SetMenuVisible(btnKho, true);
                    SetMenuVisible(btnKhachHang, false);
                    SetMenuVisible(btnBaoCao, false);
                    SetMenuVisible(btnQuanLyThuoc, true);
                    SetMenuVisible(btnTrangChuKH, false);
                    btnNhapKho.Visible = true;
                    btnXuatKho.Visible = true;
                    btnTonKho.Visible = true;
                    btnBanHangTaiQuay.Visible = false;
                    btnDonHangOnline.Visible = false;
                    btnGiaoHang.Visible = false;
                    SetRoleBadge("NHÂN VIÊN KHO", Color.FromArgb(230, 126, 34));
                    // Auto mở kho submenu vì đây là trang chính
                    pnlKhoSubmenu.Visible = true;
                    break;

                // ── NHÂN VIÊN GIAO HÀNG : chỉ xem đơn hàng ─────────
                case "NhanVienGiaoHang":
                    SetMenuVisible(btnBanHang, true);
                    SetMenuVisible(btnKho, false);
                    SetMenuVisible(btnKhachHang, false);
                    SetMenuVisible(btnBaoCao, false);
                    SetMenuVisible(btnQuanLyThuoc, false);
                    SetMenuVisible(btnTrangChuKH, false);
                    btnBanHangTaiQuay.Visible = false;
                    btnDonHangOnline.Visible = false;
                    btnGiaoHang.Visible = true;
                    btnNhapKho.Visible = false;
                    btnXuatKho.Visible = false;
                    btnTonKho.Visible = false;
                    SetRoleBadge("GIAO HÀNG", Color.FromArgb(52, 152, 219));
                    btnBanHang.Text = "📦  Đơn hàng  ▾";
                    pnlBanHangSubmenu.Visible = true;
                    break;

                default:
                    SetMenuVisible(btnBaoCao, false);
                    SetMenuVisible(btnKhachHang, false);
                    SetMenuVisible(btnQuanLyThuoc, false);
                    break;
            }
        }

        private void SetMenuVisible(Control ctrl, bool visible)
        {
            if (ctrl != null) ctrl.Visible = visible;
        }

        private void SetRoleBadge(string text, Color color)
        {
            pnlRoleBadge.BackColor = color;
            lblRoleBadge.Text = text;
        }

        // ==============================================================
        //  DASHBOARD (TRANG CHỦ NỘI BỘ)
        // ==============================================================
        private void ShowDashboard()
        {
            pnlMainContent.Controls.Clear();

            var pnlDash = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(240, 244, 248), Padding = new Padding(24) };

            var lblWelcome = new Label
            {
                Text = $"Xin chào, {SessionManager.TenNV}! 👋",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 82, 165),
                Dock = DockStyle.Top,
                Height = 56,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblSub = new Label
            {
                Text = $"Vai trò: {GetVaiTroDisplay()}   |   {DateTime.Now:dddd, dd/MM/yyyy HH:mm}",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.Gray,
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var pnlCards = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 110,
                AutoScroll = false,
                Padding = new Padding(0, 12, 0, 0)
            };

            if (SessionManager.VaiTro == "QuanLy" || SessionManager.IsDuocSi)
            {
                pnlCards.Controls.Add(MakeStatCard("💊", "Sản phẩm", GetCount("SELECT COUNT(*) FROM THUOC"), Color.FromArgb(0, 102, 204)));
                pnlCards.Controls.Add(MakeStatCard("📦", "Đơn hôm nay", GetCount("SELECT COUNT(*) FROM DONHANG WHERE CAST(NGAYDAT AS DATE)=CAST(GETDATE() AS DATE)"), Color.FromArgb(0, 153, 76)));
                pnlCards.Controls.Add(MakeStatCard("👥", "Khách hàng", GetCount("SELECT COUNT(*) FROM KHACHHANG"), Color.FromArgb(142, 68, 173)));
            }
            if (SessionManager.VaiTro == "QuanLy")
            {
                pnlCards.Controls.Add(MakeStatCard("⚠️", "Sắp hết hàng", GetCount("SELECT COUNT(*) FROM LOHANG WHERE SOLUONGTON < 10 AND SOLUONGTON > 0"), Color.FromArgb(230, 126, 34)));
                pnlCards.Controls.Add(MakeStatCard("⏰", "Sắp hết hạn", GetCount("SELECT COUNT(*) FROM LOHANG WHERE HANSD BETWEEN GETDATE() AND DATEADD(DAY,30,GETDATE())"), Color.FromArgb(192, 57, 43)));
            }
            if (SessionManager.VaiTro == "NhanVienKho")
            {
                pnlCards.Controls.Add(MakeStatCard("📦", "Tổng lô hàng", GetCount("SELECT COUNT(*) FROM LOHANG"), Color.FromArgb(230, 126, 34)));
                pnlCards.Controls.Add(MakeStatCard("⚠️", "Sắp hết hàng", GetCount("SELECT COUNT(*) FROM LOHANG WHERE SOLUONGTON < 10 AND SOLUONGTON > 0"), Color.FromArgb(192, 57, 43)));
                pnlCards.Controls.Add(MakeStatCard("⏰", "Sắp hết hạn 30 ngày", GetCount("SELECT COUNT(*) FROM LOHANG WHERE HANSD BETWEEN GETDATE() AND DATEADD(DAY,30,GETDATE())"), Color.FromArgb(142, 68, 173)));
            }
            if (SessionManager.VaiTro == "NhanVienGiaoHang")
            {
                pnlCards.Controls.Add(MakeStatCard("🚚", "Chờ giao hôm nay", GetCount("SELECT COUNT(*) FROM DONHANG WHERE TRANGTHAIDON=N'ChoGiao'"), Color.FromArgb(52, 152, 219)));
                pnlCards.Controls.Add(MakeStatCard("✅", "Đã giao hôm nay", GetCount("SELECT COUNT(*) FROM DONHANG WHERE TRANGTHAIDON=N'HoanThanh' AND CAST(NGAYDAT AS DATE)=CAST(GETDATE() AS DATE)"), Color.FromArgb(0, 153, 76)));
            }

            var lblNotice = new Label
            {
                Text = "💡  Chọn chức năng từ menu bên trái để bắt đầu làm việc.",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(100, 100, 100),
                Dock = DockStyle.Top,
                Height = 36,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 8, 0, 0)
            };

            pnlDash.Controls.Add(lblNotice);
            pnlDash.Controls.Add(pnlCards);
            pnlDash.Controls.Add(lblSub);
            pnlDash.Controls.Add(lblWelcome);
            pnlMainContent.Controls.Add(pnlDash);
        }

        private Panel MakeStatCard(string icon, string title, string value, Color color)
        {
            var card = new Panel
            {
                Width = 180,
                Height = 90,
                BackColor = color,
                Margin = new Padding(0, 0, 14, 0)
            };
            card.Controls.Add(new Label
            {
                Text = icon + "  " + value,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(12, 10),
                AutoSize = true
            });
            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(230, 230, 230),
                Location = new Point(12, 52),
                AutoSize = true
            });
            return card;
        }

        private string GetCount(string sql)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        object r = cmd.ExecuteScalar();
                        return r?.ToString() ?? "–";
                    }
                }
            }
            catch { return "–"; }
        }

        // ==============================================================
        //  GIAO DIỆN LOGIC (menu/submenu)
        // ==============================================================
        private void HideSubMenu()
        {
            if (pnlBanHangSubmenu.Visible) pnlBanHangSubmenu.Visible = false;
            if (pnlKhoSubmenu.Visible) pnlKhoSubmenu.Visible = false;
            if (pnlBaoCaoSubmenu.Visible) pnlBaoCaoSubmenu.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            subMenu.Visible = !subMenu.Visible;
            if (subMenu.Visible)
            {
                if (subMenu != pnlBanHangSubmenu) pnlBanHangSubmenu.Visible = false;
                if (subMenu != pnlKhoSubmenu) pnlKhoSubmenu.Visible = false;
                if (subMenu != pnlBaoCaoSubmenu) pnlBaoCaoSubmenu.Visible = false;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            _currentChild?.Close();
            _currentChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(childForm);
            pnlMainContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void HighlightMenu(Button active)
        {
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button b && b != btnDangXuat) b.ForeColor = Color.White;
                if (c is Panel p && p.Name != "pnlLogo" && p.Name != "pnlRoleBadge")
                    foreach (Control sc in p.Controls)
                        if (sc is Button sb) sb.ForeColor = Color.Gainsboro;
            }
            active.ForeColor = Color.Gold;
        }

        // ==============================================================
        //  SỰ KIỆN CLICK MENU
        // ==============================================================
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnTrangChu);
            HideSubMenu();
            ShowDashboard();
        }

        private void btnBanHang_Click(object sender, EventArgs e) =>
            ShowSubMenu(pnlBanHangSubmenu);

        private void btnBanHangTaiQuay_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsDuocSi)
            { ShowAccessDenied(); return; }
            HighlightMenu(btnBanHangTaiQuay);
            OpenChildForm(new frmBanHang());
        }

        private void btnDonHangOnline_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnDonHangOnline);
            OpenChildForm(new frmDanhSachDonHang());
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnGiaoHang);
            OpenChildForm(new frmGiaoHang());
        }

        private void btnKho_Click(object sender, EventArgs e) =>
            ShowSubMenu(pnlKhoSubmenu);

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsNhanVienKho)
            { ShowAccessDenied(); return; }
            HighlightMenu(btnNhapKho);
            OpenChildForm(new frmPhieuNhapKho());
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsNhanVienKho)
            { ShowAccessDenied(); return; }
            HighlightMenu(btnXuatKho);
            OpenChildForm(new frmPhieuXuatKho());
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnTonKho);
            OpenChildForm(new frmTonKho());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsDuocSi)
            { ShowAccessDenied(); return; }
            HighlightMenu(btnKhachHang);
            HideSubMenu();
            OpenChildForm(new frmQuanLyKhachHang());
        }

        private void btnQuanLyThuoc_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnQuanLyThuoc);
            HideSubMenu();
            OpenChildForm(new frmQuanLyThuoc());
        }

        // --- CÁC SỰ KIỆN CHO SUBMENU BÁO CÁO MỚI ---
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsQuanLy) { ShowAccessDenied(); return; }
            ShowSubMenu(pnlBaoCaoSubmenu); // Mở Submenu báo cáo thay vì mở Form như cũ
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnBaoCaoThongKe);
            OpenChildForm(new frmBaoCaoThongKe()); // Mở form cũ
        }

        private void btnBaoCaoTongHop_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnBaoCaoTongHop);
            OpenChildForm(new frmBaoCaoTongHop()); // Mở form biểu đồ mới
        }

        private void btnTrangChuKH_Click(object sender, EventArgs e)
        {
            var trangChu = new frmTrangChu();
            trangChu.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận đăng xuất khỏi hệ thống?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.Logout();
                this.Close();
            }
        }

        // ==============================================================
        //  HELPER
        // ==============================================================
        private void ShowAccessDenied() =>
            MessageBox.Show(
                $"⛔ Bạn không có quyền truy cập chức năng này.\n" +
                $"Vai trò hiện tại: {GetVaiTroDisplay()}",
                "Từ chối truy cập",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private string GetVaiTroDisplay()
        {
            switch (SessionManager.VaiTro)
            {
                case "QuanLy": return "Quản lý";
                case "DuocSi": return "Dược sĩ";
                case "NhanVienKho": return "Nhân viên Kho";
                case "NhanVienGiaoHang": return "Nhân viên Giao hàng";
                default: return SessionManager.VaiTro;
            }
        }
    }
}*/

    using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

// ================================================================
// frmMain.cs  –  CẬP NHẬT: Thêm nút Đổi/Trả hàng vào submenu Bán Hàng
// ================================================================

namespace PharmacyManagement
{
    public partial class frmMain : Form
    {
        private Form _currentChild;

        public frmMain()
        {
            InitializeComponent();
            ApplyCustomStyles();
            CustomizeDesign();
            RegisterEvents();
            ApplyRBAC();
            ShowDashboard();
        }

        // ==============================================================
        //  KHỞI TẠO GIAO DIỆN
        // ==============================================================
        private void ApplyCustomStyles()
        {
            // Header user info
            lblUserInfo.Text = $"👤  {SessionManager.TenNV}   |   {GetVaiTroDisplay()}";

            // Style menu chính
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button btn && btn != btnDangXuat)
                {
                    btn.Font = new Font("Segoe UI", 11F);
                    btn.Padding = new Padding(20, 0, 0, 0);
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                }
            }

            // Style submenu – ĐÃ THÊM btnDoiTra vào mảng
            Button[] subs = { btnBanHangTaiQuay, btnDonHangOnline, btnGiaoHang, btnDoiTra,
                               btnNhapKho, btnXuatKho, btnTonKho,
                               btnBaoCaoThongKe, btnBaoCaoTongHop };
            foreach (var b in subs)
            {
                b.Font = new Font("Segoe UI", 10F);
                b.Padding = new Padding(50, 0, 0, 0);
                b.ForeColor = Color.Gainsboro;
                b.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void CustomizeDesign()
        {
            pnlBanHangSubmenu.Visible = false;
            pnlKhoSubmenu.Visible = false;
            pnlBaoCaoSubmenu.Visible = false;
        }

        private void RegisterEvents()
        {
            btnBanHangTaiQuay.Click += btnBanHangTaiQuay_Click;
            btnDonHangOnline.Click += btnDonHangOnline_Click;
            btnGiaoHang.Click += btnGiaoHang_Click;
            // ── MỚI ──────────────────────────────────────────────────
            btnDoiTra.Click += btnDoiTra_Click;
            // ─────────────────────────────────────────────────────────
            btnNhapKho.Click += btnNhapKho_Click;
            btnXuatKho.Click += btnXuatKho_Click;
            btnTonKho.Click += btnTonKho_Click;
            btnKhachHang.Click += btnKhachHang_Click;

            btnBaoCao.Click += btnBaoCao_Click;
            btnBaoCaoThongKe.Click += btnBaoCaoThongKe_Click;
            btnBaoCaoTongHop.Click += btnBaoCaoTongHop_Click;

            btnDangXuat.Click += btnDangXuat_Click;
            btnQuanLyThuoc.Click += btnQuanLyThuoc_Click;
            btnTrangChuKH.Click += btnTrangChuKH_Click;
        }

        // ==============================================================
        //  PHÂN QUYỀN RBAC
        // ==============================================================
        private void ApplyRBAC()
        {
            string vaiTro = SessionManager.VaiTro;

            switch (vaiTro)
            {
                // ── QUẢN LÝ : full access ────────────────────────────
                case "QuanLy":
                    SetMenuVisible(btnBanHang, true);
                    SetMenuVisible(btnKho, true);
                    SetMenuVisible(btnKhachHang, true);
                    SetMenuVisible(btnBaoCao, true);
                    SetMenuVisible(btnQuanLyThuoc, true);
                    SetMenuVisible(btnTrangChuKH, true);
                    btnBanHangTaiQuay.Visible = true;
                    btnDonHangOnline.Visible = true;
                    btnGiaoHang.Visible = true;
                    btnDoiTra.Visible = true;   // ← MỚI
                    btnXuatKho.Visible = true;
                    btnTonKho.Visible = true;
                    btnBaoCaoThongKe.Visible = true;
                    btnBaoCaoTongHop.Visible = true;
                    SetRoleBadge("QUẢN LÝ", Color.FromArgb(142, 68, 173));
                    break;

                // ── DƯỢC SĨ : bán hàng + KH + thuốc ────────────────
                case "DuocSi":
                    SetMenuVisible(btnBanHang, true);
                    SetMenuVisible(btnKho, false);
                    SetMenuVisible(btnKhachHang, true);
                    SetMenuVisible(btnBaoCao, false);
                    SetMenuVisible(btnQuanLyThuoc, true);
                    SetMenuVisible(btnTrangChuKH, true);
                    btnBanHangTaiQuay.Visible = true;
                    btnDonHangOnline.Visible = true;
                    btnGiaoHang.Visible = false;
                    btnDoiTra.Visible = true;   // ← MỚI: Dược sĩ được phép đổi trả
                    btnNhapKho.Visible = false;
                    btnXuatKho.Visible = false;
                    btnTonKho.Visible = false;
                    SetRoleBadge("DƯỢC SĨ", Color.FromArgb(39, 174, 96));
                    break;

                // ── NHÂN VIÊN KHO : kho + thuốc ─────────────────────
                case "NhanVienKho":
                    SetMenuVisible(btnBanHang, false);
                    SetMenuVisible(btnKho, true);
                    SetMenuVisible(btnKhachHang, false);
                    SetMenuVisible(btnBaoCao, false);
                    SetMenuVisible(btnQuanLyThuoc, true);
                    SetMenuVisible(btnTrangChuKH, false);
                    btnNhapKho.Visible = true;
                    btnXuatKho.Visible = true;
                    btnTonKho.Visible = true;
                    btnBanHangTaiQuay.Visible = false;
                    btnDonHangOnline.Visible = false;
                    btnGiaoHang.Visible = false;
                    btnDoiTra.Visible = false;  // ← NV Kho không đổi trả
                    SetRoleBadge("NHÂN VIÊN KHO", Color.FromArgb(230, 126, 34));
                    pnlKhoSubmenu.Visible = true;
                    break;

                // ── NHÂN VIÊN GIAO HÀNG : chỉ xem đơn hàng ─────────
                case "NhanVienGiaoHang":
                    SetMenuVisible(btnBanHang, true);
                    SetMenuVisible(btnKho, false);
                    SetMenuVisible(btnKhachHang, false);
                    SetMenuVisible(btnBaoCao, false);
                    SetMenuVisible(btnQuanLyThuoc, false);
                    SetMenuVisible(btnTrangChuKH, false);
                    btnBanHangTaiQuay.Visible = false;
                    btnDonHangOnline.Visible = false;
                    btnGiaoHang.Visible = true;
                    btnDoiTra.Visible = false;  // ← NV Giao hàng không đổi trả
                    btnNhapKho.Visible = false;
                    btnXuatKho.Visible = false;
                    btnTonKho.Visible = false;
                    SetRoleBadge("GIAO HÀNG", Color.FromArgb(52, 152, 219));
                    btnBanHang.Text = "📦  Đơn hàng  ▾";
                    pnlBanHangSubmenu.Visible = true;
                    break;

                default:
                    SetMenuVisible(btnBaoCao, false);
                    SetMenuVisible(btnKhachHang, false);
                    SetMenuVisible(btnQuanLyThuoc, false);
                    btnDoiTra.Visible = false;
                    break;
            }
        }

        private void SetMenuVisible(Control ctrl, bool visible)
        {
            if (ctrl != null) ctrl.Visible = visible;
        }

        private void SetRoleBadge(string text, Color color)
        {
            pnlRoleBadge.BackColor = color;
            lblRoleBadge.Text = text;
        }

        // ==============================================================
        //  DASHBOARD (TRANG CHỦ NỘI BỘ)
        // ==============================================================
        private void ShowDashboard()
        {
            pnlMainContent.Controls.Clear();

            var pnlDash = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(240, 244, 248), Padding = new Padding(24) };

            var lblWelcome = new Label
            {
                Text = $"Xin chào, {SessionManager.TenNV}! 👋",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 82, 165),
                Dock = DockStyle.Top,
                Height = 56,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblSub = new Label
            {
                Text = $"Vai trò: {GetVaiTroDisplay()}   |   {DateTime.Now:dddd, dd/MM/yyyy HH:mm}",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.Gray,
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var pnlCards = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 110,
                AutoScroll = false,
                Padding = new Padding(0, 12, 0, 0)
            };

            if (SessionManager.VaiTro == "QuanLy" || SessionManager.IsDuocSi)
            {
                pnlCards.Controls.Add(MakeStatCard("💊", "Sản phẩm", GetCount("SELECT COUNT(*) FROM THUOC"), Color.FromArgb(0, 102, 204)));
                pnlCards.Controls.Add(MakeStatCard("📦", "Đơn hôm nay", GetCount("SELECT COUNT(*) FROM DONHANG WHERE CAST(NGAYDAT AS DATE)=CAST(GETDATE() AS DATE)"), Color.FromArgb(0, 153, 76)));
                pnlCards.Controls.Add(MakeStatCard("👥", "Khách hàng", GetCount("SELECT COUNT(*) FROM KHACHHANG"), Color.FromArgb(142, 68, 173)));
            }
            if (SessionManager.VaiTro == "QuanLy")
            {
                pnlCards.Controls.Add(MakeStatCard("⚠️", "Sắp hết hàng", GetCount("SELECT COUNT(*) FROM LOHANG WHERE SOLUONGTON < 10 AND SOLUONGTON > 0"), Color.FromArgb(230, 126, 34)));
                pnlCards.Controls.Add(MakeStatCard("⏰", "Sắp hết hạn", GetCount("SELECT COUNT(*) FROM LOHANG WHERE HANSD BETWEEN GETDATE() AND DATEADD(DAY,30,GETDATE())"), Color.FromArgb(192, 57, 43)));
            }
            if (SessionManager.VaiTro == "NhanVienKho")
            {
                pnlCards.Controls.Add(MakeStatCard("📦", "Tổng lô hàng", GetCount("SELECT COUNT(*) FROM LOHANG"), Color.FromArgb(230, 126, 34)));
                pnlCards.Controls.Add(MakeStatCard("⚠️", "Sắp hết hàng", GetCount("SELECT COUNT(*) FROM LOHANG WHERE SOLUONGTON < 10 AND SOLUONGTON > 0"), Color.FromArgb(192, 57, 43)));
                pnlCards.Controls.Add(MakeStatCard("⏰", "Sắp hết hạn 30 ngày", GetCount("SELECT COUNT(*) FROM LOHANG WHERE HANSD BETWEEN GETDATE() AND DATEADD(DAY,30,GETDATE())"), Color.FromArgb(142, 68, 173)));
            }
            if (SessionManager.VaiTro == "NhanVienGiaoHang")
            {
                pnlCards.Controls.Add(MakeStatCard("🚚", "Chờ giao hôm nay", GetCount("SELECT COUNT(*) FROM DONHANG WHERE TRANGTHAIDON=N'ChoGiao'"), Color.FromArgb(52, 152, 219)));
                pnlCards.Controls.Add(MakeStatCard("✅", "Đã giao hôm nay", GetCount("SELECT COUNT(*) FROM DONHANG WHERE TRANGTHAIDON=N'HoanThanh' AND CAST(NGAYDAT AS DATE)=CAST(GETDATE() AS DATE)"), Color.FromArgb(0, 153, 76)));
            }

            var lblNotice = new Label
            {
                Text = "💡  Chọn chức năng từ menu bên trái để bắt đầu làm việc.",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(100, 100, 100),
                Dock = DockStyle.Top,
                Height = 36,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 8, 0, 0)
            };

            pnlDash.Controls.Add(lblNotice);
            pnlDash.Controls.Add(pnlCards);
            pnlDash.Controls.Add(lblSub);
            pnlDash.Controls.Add(lblWelcome);
            pnlMainContent.Controls.Add(pnlDash);
        }

        private Panel MakeStatCard(string icon, string title, string value, Color color)
        {
            var card = new Panel
            {
                Width = 180,
                Height = 90,
                BackColor = color,
                Margin = new Padding(0, 0, 14, 0)
            };
            card.Controls.Add(new Label
            {
                Text = icon + "  " + value,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(12, 10),
                AutoSize = true
            });
            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(230, 230, 230),
                Location = new Point(12, 52),
                AutoSize = true
            });
            return card;
        }

        private string GetCount(string sql)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        object r = cmd.ExecuteScalar();
                        return r?.ToString() ?? "–";
                    }
                }
            }
            catch { return "–"; }
        }

        // ==============================================================
        //  GIAO DIỆN LOGIC (menu/submenu)
        // ==============================================================
        private void HideSubMenu()
        {
            if (pnlBanHangSubmenu.Visible) pnlBanHangSubmenu.Visible = false;
            if (pnlKhoSubmenu.Visible) pnlKhoSubmenu.Visible = false;
            if (pnlBaoCaoSubmenu.Visible) pnlBaoCaoSubmenu.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            subMenu.Visible = !subMenu.Visible;
            if (subMenu.Visible)
            {
                if (subMenu != pnlBanHangSubmenu) pnlBanHangSubmenu.Visible = false;
                if (subMenu != pnlKhoSubmenu) pnlKhoSubmenu.Visible = false;
                if (subMenu != pnlBaoCaoSubmenu) pnlBaoCaoSubmenu.Visible = false;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            _currentChild?.Close();
            _currentChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(childForm);
            pnlMainContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void HighlightMenu(Button active)
        {
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button b && b != btnDangXuat) b.ForeColor = Color.White;
                if (c is Panel p && p.Name != "pnlLogo" && p.Name != "pnlRoleBadge")
                    foreach (Control sc in p.Controls)
                        if (sc is Button sb) sb.ForeColor = Color.Gainsboro;
            }
            active.ForeColor = Color.Gold;
        }

        // ==============================================================
        //  SỰ KIỆN CLICK MENU
        // ==============================================================
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnTrangChu);
            HideSubMenu();
            ShowDashboard();
        }

        private void btnBanHang_Click(object sender, EventArgs e) =>
            ShowSubMenu(pnlBanHangSubmenu);

        private void btnBanHangTaiQuay_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsDuocSi)
            { ShowAccessDenied(); return; }
            HighlightMenu(btnBanHangTaiQuay);
            OpenChildForm(new frmBanHang());
        }

        private void btnDonHangOnline_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnDonHangOnline);
            OpenChildForm(new frmDanhSachDonHang());
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnGiaoHang);
            OpenChildForm(new frmGiaoHang());
        }

        // ── MỚI: Mở form Phiếu Đổi Trả ──────────────────────────────
        private void btnDoiTra_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsDuocSi)
            { ShowAccessDenied(); return; }
            HighlightMenu(btnDoiTra);
            OpenChildForm(new frmPhieuDoiTra());
        }
        // ─────────────────────────────────────────────────────────────

        private void btnKho_Click(object sender, EventArgs e) =>
            ShowSubMenu(pnlKhoSubmenu);

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsNhanVienKho)
            { ShowAccessDenied(); return; }
            HighlightMenu(btnNhapKho);
            OpenChildForm(new frmPhieuNhapKho());
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsNhanVienKho)
            { ShowAccessDenied(); return; }
            HighlightMenu(btnXuatKho);
            OpenChildForm(new frmPhieuXuatKho());
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnTonKho);
            OpenChildForm(new frmTonKho());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsDuocSi)
            { ShowAccessDenied(); return; }
            HighlightMenu(btnKhachHang);
            HideSubMenu();
            OpenChildForm(new frmQuanLyKhachHang());
        }

        private void btnQuanLyThuoc_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnQuanLyThuoc);
            HideSubMenu();
            OpenChildForm(new frmQuanLyThuoc());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsQuanLy) { ShowAccessDenied(); return; }
            ShowSubMenu(pnlBaoCaoSubmenu);
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnBaoCaoThongKe);
            OpenChildForm(new frmBaoCaoThongKe());
        }

        private void btnBaoCaoTongHop_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnBaoCaoTongHop);
            OpenChildForm(new frmBaoCaoTongHop());
        }

        private void btnTrangChuKH_Click(object sender, EventArgs e)
        {
            var trangChu = new frmTrangChu();
            trangChu.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận đăng xuất khỏi hệ thống?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.Logout();
                this.Close();
            }
        }

        // ==============================================================
        //  HELPER
        // ==============================================================
        private void ShowAccessDenied() =>
            MessageBox.Show(
                $"⛔ Bạn không có quyền truy cập chức năng này.\n" +
                $"Vai trò hiện tại: {GetVaiTroDisplay()}",
                "Từ chối truy cập",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private string GetVaiTroDisplay()
        {
            switch (SessionManager.VaiTro)
            {
                case "QuanLy": return "Quản lý";
                case "DuocSi": return "Dược sĩ";
                case "NhanVienKho": return "Nhân viên Kho";
                case "NhanVienGiaoHang": return "Nhân viên Giao hàng";
                default: return SessionManager.VaiTro;
            }
        }
    }
}