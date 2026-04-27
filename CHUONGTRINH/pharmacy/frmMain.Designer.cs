/*namespace PharmacyManagement
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlRoleBadge = new System.Windows.Forms.Panel();
            this.lblRoleBadge = new System.Windows.Forms.Label();
            this.btnTrangChu = new System.Windows.Forms.Button();

            this.btnBanHang = new System.Windows.Forms.Button();
            this.pnlBanHangSubmenu = new System.Windows.Forms.Panel();
            this.btnBanHangTaiQuay = new System.Windows.Forms.Button();
            this.btnDonHangOnline = new System.Windows.Forms.Button();
            this.btnGiaoHang = new System.Windows.Forms.Button();

            this.btnKho = new System.Windows.Forms.Button();
            this.pnlKhoSubmenu = new System.Windows.Forms.Panel();
            this.btnNhapKho = new System.Windows.Forms.Button();
            this.btnXuatKho = new System.Windows.Forms.Button();
            this.btnTonKho = new System.Windows.Forms.Button();

            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnQuanLyThuoc = new System.Windows.Forms.Button();

            // Nút Menu Báo cáo Chính
            this.btnBaoCao = new System.Windows.Forms.Button();

            // Menu con của Báo cáo (MỚI)
            this.pnlBaoCaoSubmenu = new System.Windows.Forms.Panel();
            this.btnBaoCaoThongKe = new System.Windows.Forms.Button();
            this.btnBaoCaoTongHop = new System.Windows.Forms.Button();

            this.btnTrangChuKH = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();

            this.pnlSidebar.SuspendLayout();
            this.pnlBanHangSubmenu.SuspendLayout();
            this.pnlKhoSubmenu.SuspendLayout();
            this.pnlBaoCaoSubmenu.SuspendLayout(); // Thêm dòng này
            this.pnlLogo.SuspendLayout();
            this.pnlRoleBadge.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // ===================================================================
            // SIDEBAR
            // ===================================================================
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(0, 82, 165);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 250;
            this.pnlSidebar.Name = "pnlSidebar";

            // LOGO
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(0, 60, 130);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Height = 80;
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Controls.Add(this.lblLogo);

            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Text = "💊 PHARMACY";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ROLE BADGE
            this.pnlRoleBadge.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.pnlRoleBadge.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleBadge.Height = 32;
            this.pnlRoleBadge.Name = "pnlRoleBadge";
            this.pnlRoleBadge.Controls.Add(this.lblRoleBadge);

            this.lblRoleBadge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRoleBadge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRoleBadge.ForeColor = System.Drawing.Color.White;
            this.lblRoleBadge.Text = "VAI TRÒ";
            this.lblRoleBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRoleBadge.Name = "lblRoleBadge";

            // MENU: Trang Chủ
            this.btnTrangChu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangChu.Height = 52;
            this.btnTrangChu.Text = "🏠  Trang Chủ";
            this.btnTrangChu.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTrangChu.Name = "btnTrangChu";

            // MENU: Bán Hàng
            this.btnBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanHang.Height = 52;
            this.btnBanHang.Text = "🛒  Bán hàng  ▾";
            this.btnBanHang.ForeColor = System.Drawing.Color.White;
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHang.FlatAppearance.BorderSize = 0;
            this.btnBanHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHang.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBanHang.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBanHang.Name = "btnBanHang";

            // SUBMENU: Bán Hàng
            this.pnlBanHangSubmenu.BackColor = System.Drawing.Color.FromArgb(0, 62, 130);
            this.pnlBanHangSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanHangSubmenu.Height = 132;
            this.pnlBanHangSubmenu.Name = "pnlBanHangSubmenu";

            this.btnBanHangTaiQuay.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanHangTaiQuay.Height = 44;
            this.btnBanHangTaiQuay.Text = "  🏪  Bán hàng tại quầy";
            this.btnBanHangTaiQuay.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBanHangTaiQuay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHangTaiQuay.FlatAppearance.BorderSize = 0;
            this.btnBanHangTaiQuay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHangTaiQuay.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnBanHangTaiQuay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBanHangTaiQuay.Name = "btnBanHangTaiQuay";

            this.btnDonHangOnline.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDonHangOnline.Height = 44;
            this.btnDonHangOnline.Text = "  📱  Đơn hàng Online";
            this.btnDonHangOnline.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDonHangOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonHangOnline.FlatAppearance.BorderSize = 0;
            this.btnDonHangOnline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonHangOnline.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnDonHangOnline.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDonHangOnline.Name = "btnDonHangOnline";

            this.btnGiaoHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGiaoHang.Height = 44;
            this.btnGiaoHang.Text = "  🚚  Cập nhật Giao hàng";
            this.btnGiaoHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGiaoHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiaoHang.FlatAppearance.BorderSize = 0;
            this.btnGiaoHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiaoHang.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnGiaoHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGiaoHang.Name = "btnGiaoHang";

            this.pnlBanHangSubmenu.Controls.Add(this.btnGiaoHang);
            this.pnlBanHangSubmenu.Controls.Add(this.btnDonHangOnline);
            this.pnlBanHangSubmenu.Controls.Add(this.btnBanHangTaiQuay);

            // MENU: Quản Lý Kho
            this.btnKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKho.Height = 52;
            this.btnKho.Text = "📦  Quản lý Kho  ▾";
            this.btnKho.ForeColor = System.Drawing.Color.White;
            this.btnKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKho.FlatAppearance.BorderSize = 0;
            this.btnKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKho.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKho.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnKho.Name = "btnKho";

            // SUBMENU: Kho
            this.pnlKhoSubmenu.BackColor = System.Drawing.Color.FromArgb(0, 62, 130);
            this.pnlKhoSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKhoSubmenu.Height = 132;
            this.pnlKhoSubmenu.Name = "pnlKhoSubmenu";

            this.btnNhapKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapKho.Height = 44;
            this.btnNhapKho.Text = "  📥  Nhập kho";
            this.btnNhapKho.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnNhapKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapKho.FlatAppearance.BorderSize = 0;
            this.btnNhapKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapKho.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnNhapKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNhapKho.Name = "btnNhapKho";

            this.btnXuatKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXuatKho.Height = 44;
            this.btnXuatKho.Text = "  📤  Xuất kho";
            this.btnXuatKho.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnXuatKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatKho.FlatAppearance.BorderSize = 0;
            this.btnXuatKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatKho.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnXuatKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnXuatKho.Name = "btnXuatKho";

            this.btnTonKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTonKho.Height = 44;
            this.btnTonKho.Text = "  🔍  Tồn kho";
            this.btnTonKho.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTonKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTonKho.FlatAppearance.BorderSize = 0;
            this.btnTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTonKho.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnTonKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTonKho.Name = "btnTonKho";

            this.pnlKhoSubmenu.Controls.Add(this.btnTonKho);
            this.pnlKhoSubmenu.Controls.Add(this.btnXuatKho);
            this.pnlKhoSubmenu.Controls.Add(this.btnNhapKho);

            // MENU: Quản lý Khách hàng
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.Height = 52;
            this.btnKhachHang.Text = "👥  Quản lý Khách hàng";
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnKhachHang.Name = "btnKhachHang";

            // MENU: Quản lý Thuốc
            this.btnQuanLyThuoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyThuoc.Height = 52;
            this.btnQuanLyThuoc.Text = "💊  Quản lý Thuốc";
            this.btnQuanLyThuoc.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyThuoc.FlatAppearance.BorderSize = 0;
            this.btnQuanLyThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyThuoc.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnQuanLyThuoc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnQuanLyThuoc.Name = "btnQuanLyThuoc";

            // ── MENU: BÁO CÁO THỐNG KÊ (Đã Sửa Đổi) ────────────────────
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.Height = 52;
            this.btnBaoCao.Text = "📊  Báo cáo Thống kê  ▾";
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBaoCao.Name = "btnBaoCao";

            // ── SUBMENU: BÁO CÁO MỚI ─────────────────────────────────────
            this.pnlBaoCaoSubmenu.BackColor = System.Drawing.Color.FromArgb(0, 62, 130);
            this.pnlBaoCaoSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBaoCaoSubmenu.Height = 88;
            this.pnlBaoCaoSubmenu.Name = "pnlBaoCaoSubmenu";

            this.btnBaoCaoThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoThongKe.Height = 44;
            this.btnBaoCaoThongKe.Text = "  📈  Doanh thu cơ bản";
            this.btnBaoCaoThongKe.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaoCaoThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCaoThongKe.FlatAppearance.BorderSize = 0;
            this.btnBaoCaoThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoThongKe.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnBaoCaoThongKe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBaoCaoThongKe.Name = "btnBaoCaoThongKe";

            this.btnBaoCaoTongHop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoTongHop.Height = 44;
            this.btnBaoCaoTongHop.Text = "  📈  Báo cáo đa năng (Biểu đồ)";
            this.btnBaoCaoTongHop.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaoCaoTongHop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCaoTongHop.FlatAppearance.BorderSize = 0;
            this.btnBaoCaoTongHop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoTongHop.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnBaoCaoTongHop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBaoCaoTongHop.Name = "btnBaoCaoTongHop";

            this.pnlBaoCaoSubmenu.Controls.Add(this.btnBaoCaoTongHop); // Added second (bottom)
            this.pnlBaoCaoSubmenu.Controls.Add(this.btnBaoCaoThongKe); // Added first (top)

            // MENU: Về trang chủ KH
            this.btnTrangChuKH.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangChuKH.Height = 44;
            this.btnTrangChuKH.Text = "🌐  Trang chủ Pharmacy";
            this.btnTrangChuKH.ForeColor = System.Drawing.Color.FromArgb(173, 216, 230);
            this.btnTrangChuKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChuKH.FlatAppearance.BorderSize = 0;
            this.btnTrangChuKH.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 62, 130);
            this.btnTrangChuKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChuKH.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTrangChuKH.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTrangChuKH.Name = "btnTrangChuKH";

            // NÚT ĐĂNG XUẤT
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.Height = 58;
            this.btnDangXuat.Text = "ĐĂNG XUẤT";
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Name = "btnDangXuat";

            // Add to Sidebar
            this.pnlSidebar.Controls.Add(this.btnTrangChuKH);
            this.pnlSidebar.Controls.Add(this.pnlBaoCaoSubmenu); // <--- SUBMENU BÁO CÁO NẰM Ở ĐÂY
            this.pnlSidebar.Controls.Add(this.btnBaoCao);
            this.pnlSidebar.Controls.Add(this.btnQuanLyThuoc);
            this.pnlSidebar.Controls.Add(this.btnKhachHang);
            this.pnlSidebar.Controls.Add(this.pnlKhoSubmenu);
            this.pnlSidebar.Controls.Add(this.btnKho);
            this.pnlSidebar.Controls.Add(this.pnlBanHangSubmenu);
            this.pnlSidebar.Controls.Add(this.btnBanHang);
            this.pnlSidebar.Controls.Add(this.btnTrangChu);
            this.pnlSidebar.Controls.Add(this.pnlRoleBadge);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Controls.Add(this.btnDangXuat);

            // ===================================================================
            // HEADER
            // ===================================================================
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 72;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Controls.Add(this.lblUserInfo);
            this.pnlHeader.Controls.Add(this.lblSystemName);

            this.pnlHeader.Paint += (s, pe) =>
            {
                pe.Graphics.DrawLine(
                    new System.Drawing.Pen(System.Drawing.Color.FromArgb(220, 220, 230), 1),
                    0, this.pnlHeader.Height - 1,
                    this.pnlHeader.Width, this.pnlHeader.Height - 1);
            };

            this.lblSystemName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSystemName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.ForeColor = System.Drawing.Color.FromArgb(0, 82, 165);
            this.lblSystemName.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblSystemName.Width = 420;
            this.lblSystemName.Text = "HỆ THỐNG QUẢN LÝ BÁN HÀNG";
            this.lblSystemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblUserInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblUserInfo.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblUserInfo.Width = 420;
            this.lblUserInfo.Text = "👤 Tên Nhân Viên | Vai trò";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ===================================================================
            // MAIN CONTENT
            // ===================================================================
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Name = "pnlMainContent";

            // ===================================================================
            // FORM CONFIG
            // ===================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pharmacy Management System";
            this.Name = "frmMain";

            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlBanHangSubmenu.ResumeLayout(false);
            this.pnlKhoSubmenu.ResumeLayout(false);
            this.pnlBaoCaoSubmenu.ResumeLayout(false); // Thêm dòng này
            this.pnlLogo.ResumeLayout(false);
            this.pnlRoleBadge.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlRoleBadge;
        private System.Windows.Forms.Label lblRoleBadge;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Panel pnlBanHangSubmenu;
        private System.Windows.Forms.Button btnBanHangTaiQuay;
        private System.Windows.Forms.Button btnDonHangOnline;
        private System.Windows.Forms.Button btnGiaoHang;
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Panel pnlKhoSubmenu;
        private System.Windows.Forms.Button btnNhapKho;
        private System.Windows.Forms.Button btnXuatKho;
        private System.Windows.Forms.Button btnTonKho;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnQuanLyThuoc;

        // --- 3 MỤC MỚI DÀNH CHO BÁO CÁO ---
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Panel pnlBaoCaoSubmenu;
        private System.Windows.Forms.Button btnBaoCaoThongKe;
        private System.Windows.Forms.Button btnBaoCaoTongHop;

        private System.Windows.Forms.Button btnTrangChuKH;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel pnlMainContent;
    }
}*/

    namespace PharmacyManagement
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlRoleBadge = new System.Windows.Forms.Panel();
            this.lblRoleBadge = new System.Windows.Forms.Label();
            this.btnTrangChu = new System.Windows.Forms.Button();

            this.btnBanHang = new System.Windows.Forms.Button();
            this.pnlBanHangSubmenu = new System.Windows.Forms.Panel();
            this.btnBanHangTaiQuay = new System.Windows.Forms.Button();
            this.btnDonHangOnline = new System.Windows.Forms.Button();
            this.btnGiaoHang = new System.Windows.Forms.Button();
            this.btnDoiTra = new System.Windows.Forms.Button(); // ← MỚI

            this.btnKho = new System.Windows.Forms.Button();
            this.pnlKhoSubmenu = new System.Windows.Forms.Panel();
            this.btnNhapKho = new System.Windows.Forms.Button();
            this.btnXuatKho = new System.Windows.Forms.Button();
            this.btnTonKho = new System.Windows.Forms.Button();

            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnQuanLyThuoc = new System.Windows.Forms.Button();

            this.btnBaoCao = new System.Windows.Forms.Button();
            this.pnlBaoCaoSubmenu = new System.Windows.Forms.Panel();
            this.btnBaoCaoThongKe = new System.Windows.Forms.Button();
            this.btnBaoCaoTongHop = new System.Windows.Forms.Button();

            this.btnTrangChuKH = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();

            this.pnlSidebar.SuspendLayout();
            this.pnlBanHangSubmenu.SuspendLayout();
            this.pnlKhoSubmenu.SuspendLayout();
            this.pnlBaoCaoSubmenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlRoleBadge.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // ===================================================================
            // SIDEBAR
            // ===================================================================
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(0, 82, 165);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 250;
            this.pnlSidebar.Name = "pnlSidebar";

            // LOGO
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(0, 60, 130);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Height = 80;
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Controls.Add(this.lblLogo);

            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Text = "💊 PHARMACY";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ROLE BADGE
            this.pnlRoleBadge.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.pnlRoleBadge.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleBadge.Height = 32;
            this.pnlRoleBadge.Name = "pnlRoleBadge";
            this.pnlRoleBadge.Controls.Add(this.lblRoleBadge);

            this.lblRoleBadge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRoleBadge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRoleBadge.ForeColor = System.Drawing.Color.White;
            this.lblRoleBadge.Text = "VAI TRÒ";
            this.lblRoleBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRoleBadge.Name = "lblRoleBadge";

            // MENU: Trang Chủ
            this.btnTrangChu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangChu.Height = 52;
            this.btnTrangChu.Text = "🏠  Trang Chủ";
            this.btnTrangChu.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);

            // MENU: Bán Hàng
            this.btnBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanHang.Height = 52;
            this.btnBanHang.Text = "🛒  Bán hàng  ▾";
            this.btnBanHang.ForeColor = System.Drawing.Color.White;
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHang.FlatAppearance.BorderSize = 0;
            this.btnBanHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHang.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBanHang.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);

            // SUBMENU: Bán Hàng
            // ── Height: 4 nút × 44px = 176 (tăng từ 132 vì thêm btnDoiTra) ──
            this.pnlBanHangSubmenu.BackColor = System.Drawing.Color.FromArgb(0, 62, 130);
            this.pnlBanHangSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanHangSubmenu.Height = 176;   // ← tăng từ 132 lên 176
            this.pnlBanHangSubmenu.Name = "pnlBanHangSubmenu";

            this.btnBanHangTaiQuay.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanHangTaiQuay.Height = 44;
            this.btnBanHangTaiQuay.Text = "  🏪  Bán hàng tại quầy";
            this.btnBanHangTaiQuay.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBanHangTaiQuay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHangTaiQuay.FlatAppearance.BorderSize = 0;
            this.btnBanHangTaiQuay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHangTaiQuay.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnBanHangTaiQuay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBanHangTaiQuay.Name = "btnBanHangTaiQuay";

            this.btnDonHangOnline.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDonHangOnline.Height = 44;
            this.btnDonHangOnline.Text = "  📱  Đơn hàng Online";
            this.btnDonHangOnline.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDonHangOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonHangOnline.FlatAppearance.BorderSize = 0;
            this.btnDonHangOnline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonHangOnline.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnDonHangOnline.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDonHangOnline.Name = "btnDonHangOnline";

            this.btnGiaoHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGiaoHang.Height = 44;
            this.btnGiaoHang.Text = "  🚚  Cập nhật Giao hàng";
            this.btnGiaoHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGiaoHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiaoHang.FlatAppearance.BorderSize = 0;
            this.btnGiaoHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiaoHang.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnGiaoHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGiaoHang.Name = "btnGiaoHang";

            // ── NÚT MỚI: Đổi / Trả hàng ─────────────────────────────
            this.btnDoiTra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoiTra.Height = 44;
            this.btnDoiTra.Text = "  🔄  Đổi / Trả hàng";
            this.btnDoiTra.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDoiTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiTra.FlatAppearance.BorderSize = 0;
            this.btnDoiTra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiTra.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnDoiTra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDoiTra.Name = "btnDoiTra";
            // ─────────────────────────────────────────────────────────

            // Thứ tự Add vào submenu: Add sau = hiển thị trên cùng (DockStyle.Top)
            // Muốn thứ tự hiển thị: BanHangTaiQuay → DonHangOnline → GiaoHang → DoiTra
            // Thì Add theo thứ tự ngược lại:
            this.pnlBanHangSubmenu.Controls.Add(this.btnDoiTra);        // hiển thị dưới cùng
            this.pnlBanHangSubmenu.Controls.Add(this.btnGiaoHang);
            this.pnlBanHangSubmenu.Controls.Add(this.btnDonHangOnline);
            this.pnlBanHangSubmenu.Controls.Add(this.btnBanHangTaiQuay); // hiển thị trên cùng

            // MENU: Quản Lý Kho
            this.btnKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKho.Height = 52;
            this.btnKho.Text = "📦  Quản lý Kho  ▾";
            this.btnKho.ForeColor = System.Drawing.Color.White;
            this.btnKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKho.FlatAppearance.BorderSize = 0;
            this.btnKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKho.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKho.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnKho.Name = "btnKho";
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);

            // SUBMENU: Kho
            this.pnlKhoSubmenu.BackColor = System.Drawing.Color.FromArgb(0, 62, 130);
            this.pnlKhoSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKhoSubmenu.Height = 132;
            this.pnlKhoSubmenu.Name = "pnlKhoSubmenu";

            this.btnNhapKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapKho.Height = 44;
            this.btnNhapKho.Text = "  📥  Nhập kho";
            this.btnNhapKho.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnNhapKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapKho.FlatAppearance.BorderSize = 0;
            this.btnNhapKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapKho.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnNhapKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNhapKho.Name = "btnNhapKho";

            this.btnXuatKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXuatKho.Height = 44;
            this.btnXuatKho.Text = "  📤  Xuất kho";
            this.btnXuatKho.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnXuatKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatKho.FlatAppearance.BorderSize = 0;
            this.btnXuatKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatKho.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnXuatKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnXuatKho.Name = "btnXuatKho";

            this.btnTonKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTonKho.Height = 44;
            this.btnTonKho.Text = "  🔍  Tồn kho";
            this.btnTonKho.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTonKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTonKho.FlatAppearance.BorderSize = 0;
            this.btnTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTonKho.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnTonKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTonKho.Name = "btnTonKho";

            this.pnlKhoSubmenu.Controls.Add(this.btnTonKho);
            this.pnlKhoSubmenu.Controls.Add(this.btnXuatKho);
            this.pnlKhoSubmenu.Controls.Add(this.btnNhapKho);

            // MENU: Quản lý Khách hàng
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.Height = 52;
            this.btnKhachHang.Text = "👥  Quản lý Khách hàng";
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnKhachHang.Name = "btnKhachHang";

            // MENU: Quản lý Thuốc
            this.btnQuanLyThuoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyThuoc.Height = 52;
            this.btnQuanLyThuoc.Text = "💊  Quản lý Thuốc";
            this.btnQuanLyThuoc.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyThuoc.FlatAppearance.BorderSize = 0;
            this.btnQuanLyThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyThuoc.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnQuanLyThuoc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnQuanLyThuoc.Name = "btnQuanLyThuoc";

            // MENU: Báo cáo Thống kê
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.Height = 52;
            this.btnBaoCao.Text = "📊  Báo cáo Thống kê  ▾";
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBaoCao.Name = "btnBaoCao";

            // SUBMENU: Báo cáo
            this.pnlBaoCaoSubmenu.BackColor = System.Drawing.Color.FromArgb(0, 62, 130);
            this.pnlBaoCaoSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBaoCaoSubmenu.Height = 88;
            this.pnlBaoCaoSubmenu.Name = "pnlBaoCaoSubmenu";

            this.btnBaoCaoThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoThongKe.Height = 44;
            this.btnBaoCaoThongKe.Text = "  📈  Doanh thu cơ bản";
            this.btnBaoCaoThongKe.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaoCaoThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCaoThongKe.FlatAppearance.BorderSize = 0;
            this.btnBaoCaoThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoThongKe.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnBaoCaoThongKe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBaoCaoThongKe.Name = "btnBaoCaoThongKe";

            this.btnBaoCaoTongHop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoTongHop.Height = 44;
            this.btnBaoCaoTongHop.Text = "  📈  Báo cáo đa năng (Biểu đồ)";
            this.btnBaoCaoTongHop.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaoCaoTongHop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCaoTongHop.FlatAppearance.BorderSize = 0;
            this.btnBaoCaoTongHop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoTongHop.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnBaoCaoTongHop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBaoCaoTongHop.Name = "btnBaoCaoTongHop";

            this.pnlBaoCaoSubmenu.Controls.Add(this.btnBaoCaoTongHop);
            this.pnlBaoCaoSubmenu.Controls.Add(this.btnBaoCaoThongKe);

            // MENU: Về trang chủ KH
            this.btnTrangChuKH.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangChuKH.Height = 44;
            this.btnTrangChuKH.Text = "🌐  Trang chủ Pharmacy";
            this.btnTrangChuKH.ForeColor = System.Drawing.Color.FromArgb(173, 216, 230);
            this.btnTrangChuKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChuKH.FlatAppearance.BorderSize = 0;
            this.btnTrangChuKH.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 62, 130);
            this.btnTrangChuKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChuKH.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTrangChuKH.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTrangChuKH.Name = "btnTrangChuKH";

            // NÚT ĐĂNG XUẤT
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.Height = 58;
            this.btnDangXuat.Text = "ĐĂNG XUẤT";
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Name = "btnDangXuat";

            // Add to Sidebar (thứ tự Add = thứ tự hiển thị ngược - Add trước → hiển thị sau)
            this.pnlSidebar.Controls.Add(this.btnTrangChuKH);
            this.pnlSidebar.Controls.Add(this.pnlBaoCaoSubmenu);
            this.pnlSidebar.Controls.Add(this.btnBaoCao);
            this.pnlSidebar.Controls.Add(this.btnQuanLyThuoc);
            this.pnlSidebar.Controls.Add(this.btnKhachHang);
            this.pnlSidebar.Controls.Add(this.pnlKhoSubmenu);
            this.pnlSidebar.Controls.Add(this.btnKho);
            this.pnlSidebar.Controls.Add(this.pnlBanHangSubmenu);
            this.pnlSidebar.Controls.Add(this.btnBanHang);
            this.pnlSidebar.Controls.Add(this.btnTrangChu);
            this.pnlSidebar.Controls.Add(this.pnlRoleBadge);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Controls.Add(this.btnDangXuat);

            // ===================================================================
            // HEADER
            // ===================================================================
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 72;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Controls.Add(this.lblUserInfo);
            this.pnlHeader.Controls.Add(this.lblSystemName);

            this.pnlHeader.Paint += (s, pe) =>
            {
                pe.Graphics.DrawLine(
                    new System.Drawing.Pen(System.Drawing.Color.FromArgb(220, 220, 230), 1),
                    0, this.pnlHeader.Height - 1,
                    this.pnlHeader.Width, this.pnlHeader.Height - 1);
            };

            this.lblSystemName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSystemName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.ForeColor = System.Drawing.Color.FromArgb(0, 82, 165);
            this.lblSystemName.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblSystemName.Width = 420;
            this.lblSystemName.Text = "HỆ THỐNG QUẢN LÝ BÁN HÀNG";
            this.lblSystemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblUserInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblUserInfo.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblUserInfo.Width = 420;
            this.lblUserInfo.Text = "👤 Tên Nhân Viên | Vai trò";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ===================================================================
            // MAIN CONTENT
            // ===================================================================
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Name = "pnlMainContent";

            // ===================================================================
            // FORM CONFIG
            // ===================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pharmacy Management System";
            this.Name = "frmMain";

            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlBanHangSubmenu.ResumeLayout(false);
            this.pnlKhoSubmenu.ResumeLayout(false);
            this.pnlBaoCaoSubmenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlRoleBadge.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlRoleBadge;
        private System.Windows.Forms.Label lblRoleBadge;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Panel pnlBanHangSubmenu;
        private System.Windows.Forms.Button btnBanHangTaiQuay;
        private System.Windows.Forms.Button btnDonHangOnline;
        private System.Windows.Forms.Button btnGiaoHang;
        private System.Windows.Forms.Button btnDoiTra;          // ← MỚI
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Panel pnlKhoSubmenu;
        private System.Windows.Forms.Button btnNhapKho;
        private System.Windows.Forms.Button btnXuatKho;
        private System.Windows.Forms.Button btnTonKho;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnQuanLyThuoc;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Panel pnlBaoCaoSubmenu;
        private System.Windows.Forms.Button btnBaoCaoThongKe;
        private System.Windows.Forms.Button btnBaoCaoTongHop;
        private System.Windows.Forms.Button btnTrangChuKH;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel pnlMainContent;
    }
}