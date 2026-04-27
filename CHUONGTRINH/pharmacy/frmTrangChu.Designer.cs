namespace PharmacyManagement
{
    partial class frmTrangChu
    {
        private System.ComponentModel.IContainer components = null;

        // ── TOP NAVIGATION sub-panels ────────────────────────────────
        private System.Windows.Forms.Panel pnlTopNav;
        private System.Windows.Forms.Panel pnlNavLeft;
        private System.Windows.Forms.Panel pnlNavMiddle;
        private System.Windows.Forms.Panel pnlNavRight;

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;

        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Label lblCartBadge;

        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnDangNhapNV;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnVaoHeThong;
        private System.Windows.Forms.ToolTip toolTipGio;

        // ── BANNER ───────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.Label lblBannerTitle;
        private System.Windows.Forms.Label lblBannerSub;

        // ── BODY ─────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblCatTitle;
        private System.Windows.Forms.ListBox listCategories;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlFilterBar;
        private System.Windows.Forms.Label lblProductCount;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTipGio = new System.Windows.Forms.ToolTip(this.components);
            this.btnDangNhapNV = new System.Windows.Forms.Button();
            this.pnlTopNav = new System.Windows.Forms.Panel();
            this.pnlNavMiddle = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlNavRight = new System.Windows.Forms.Panel();
            this.btnCart = new System.Windows.Forms.Button();
            this.lblCartBadge = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnVaoHeThong = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pnlNavLeft = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.lblBannerTitle = new System.Windows.Forms.Label();
            this.lblBannerSub = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilterBar = new System.Windows.Forms.Panel();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.listCategories = new System.Windows.Forms.ListBox();
            this.pnlDiv = new System.Windows.Forms.Panel();
            this.lblCatTitle = new System.Windows.Forms.Label();
            this.pnlTopNav.SuspendLayout();
            this.pnlNavMiddle.SuspendLayout();
            this.pnlNavRight.SuspendLayout();
            this.pnlNavLeft.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilterBar.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDangNhapNV
            // 
            this.btnDangNhapNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDangNhapNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhapNV.FlatAppearance.BorderSize = 0;
            this.btnDangNhapNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhapNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDangNhapNV.ForeColor = System.Drawing.Color.White;
            this.btnDangNhapNV.Location = new System.Drawing.Point(385, 14);
            this.btnDangNhapNV.Name = "btnDangNhapNV";
            this.btnDangNhapNV.Size = new System.Drawing.Size(195, 36);
            this.btnDangNhapNV.TabIndex = 5;
            this.btnDangNhapNV.Text = "🔑 Đăng nhập Nhân Viên";
            this.toolTipGio.SetToolTip(this.btnDangNhapNV, "Đăng nhập với tài khoản nhân viên / quản lý");
            this.btnDangNhapNV.UseVisualStyleBackColor = false;
            this.btnDangNhapNV.Click += new System.EventHandler(this.btnDangNhapNV_Click);
            // 
            // pnlTopNav
            // 
            this.pnlTopNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(165)))));
            this.pnlTopNav.Controls.Add(this.pnlNavMiddle);
            this.pnlTopNav.Controls.Add(this.pnlNavRight);
            this.pnlTopNav.Controls.Add(this.pnlNavLeft);
            this.pnlTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopNav.Location = new System.Drawing.Point(0, 0);
            this.pnlTopNav.Name = "pnlTopNav";
            this.pnlTopNav.Size = new System.Drawing.Size(1264, 64);
            this.pnlTopNav.TabIndex = 2;
            // 
            // pnlNavMiddle
            // 
            this.pnlNavMiddle.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavMiddle.Controls.Add(this.txtSearch);
            this.pnlNavMiddle.Controls.Add(this.btnSearch);
            this.pnlNavMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavMiddle.Location = new System.Drawing.Point(340, 0);
            this.pnlNavMiddle.Name = "pnlNavMiddle";
            this.pnlNavMiddle.Padding = new System.Windows.Forms.Padding(8, 14, 6, 14);
            this.pnlNavMiddle.Size = new System.Drawing.Size(324, 64);
            this.pnlNavMiddle.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtSearch.Location = new System.Drawing.Point(8, 14);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(268, 36);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(76)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(276, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(42, 36);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "🔍";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlNavRight
            // 
            this.pnlNavRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavRight.Controls.Add(this.btnCart);
            this.pnlNavRight.Controls.Add(this.lblCartBadge);
            this.pnlNavRight.Controls.Add(this.lblUserInfo);
            this.pnlNavRight.Controls.Add(this.btnDangNhap);
            this.pnlNavRight.Controls.Add(this.btnDangKy);
            this.pnlNavRight.Controls.Add(this.btnDangNhapNV);
            this.pnlNavRight.Controls.Add(this.btnVaoHeThong);
            this.pnlNavRight.Controls.Add(this.btnDangXuat);
            this.pnlNavRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNavRight.Location = new System.Drawing.Point(664, 0);
            this.pnlNavRight.Name = "pnlNavRight";
            this.pnlNavRight.Size = new System.Drawing.Size(600, 64);
            this.pnlNavRight.TabIndex = 1;
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCart.ForeColor = System.Drawing.Color.White;
            this.btnCart.Location = new System.Drawing.Point(15, 14);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(145, 36);
            this.btnCart.TabIndex = 0;
            this.btnCart.Text = "🛒  Giỏ hàng (0)";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // lblCartBadge
            // 
            this.lblCartBadge.BackColor = System.Drawing.Color.Crimson;
            this.lblCartBadge.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCartBadge.ForeColor = System.Drawing.Color.White;
            this.lblCartBadge.Location = new System.Drawing.Point(150, 8);
            this.lblCartBadge.Name = "lblCartBadge";
            this.lblCartBadge.Size = new System.Drawing.Size(20, 20);
            this.lblCartBadge.TabIndex = 1;
            this.lblCartBadge.Text = "0";
            this.lblCartBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCartBadge.Visible = false;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUserInfo.ForeColor = System.Drawing.Color.White;
            this.lblUserInfo.Location = new System.Drawing.Point(175, 14);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(195, 36);
            this.lblUserInfo.TabIndex = 2;
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserInfo.Visible = false;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.White;
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(165)))));
            this.btnDangNhap.Location = new System.Drawing.Point(175, 14);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(100, 36);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(76)))));
            this.btnDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(285, 14);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(90, 36);
            this.btnDangKy.TabIndex = 4;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnVaoHeThong
            // 
            this.btnVaoHeThong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnVaoHeThong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVaoHeThong.FlatAppearance.BorderSize = 0;
            this.btnVaoHeThong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVaoHeThong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVaoHeThong.ForeColor = System.Drawing.Color.White;
            this.btnVaoHeThong.Location = new System.Drawing.Point(380, 14);
            this.btnVaoHeThong.Name = "btnVaoHeThong";
            this.btnVaoHeThong.Size = new System.Drawing.Size(100, 36);
            this.btnVaoHeThong.TabIndex = 6;
            this.btnVaoHeThong.Text = "⚙ Quản lý";
            this.btnVaoHeThong.UseVisualStyleBackColor = false;
            this.btnVaoHeThong.Visible = false;
            this.btnVaoHeThong.Click += new System.EventHandler(this.btnVaoHeThong_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(490, 14);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(90, 36);
            this.btnDangXuat.TabIndex = 7;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Visible = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // pnlNavLeft
            // 
            this.pnlNavLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavLeft.Controls.Add(this.lblLogo);
            this.pnlNavLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlNavLeft.Name = "pnlNavLeft";
            this.pnlNavLeft.Size = new System.Drawing.Size(340, 64);
            this.pnlNavLeft.TabIndex = 2;
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblLogo.Size = new System.Drawing.Size(340, 64);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "💊 NHÀ THUỐC PHARMACY";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBanner
            // 
            this.pnlBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.pnlBanner.Controls.Add(this.lblBannerTitle);
            this.pnlBanner.Controls.Add(this.lblBannerSub);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(0, 64);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(1264, 90);
            this.pnlBanner.TabIndex = 1;
            // 
            // lblBannerTitle
            // 
            this.lblBannerTitle.AutoSize = true;
            this.lblBannerTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBannerTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(165)))));
            this.lblBannerTitle.Location = new System.Drawing.Point(20, 12);
            this.lblBannerTitle.Name = "lblBannerTitle";
            this.lblBannerTitle.Size = new System.Drawing.Size(1006, 38);
            this.lblBannerTitle.TabIndex = 0;
            this.lblBannerTitle.Text = "🏥 Chăm sóc sức khỏe toàn diện – Giao hàng tận nơi – Đổi trả trong 24 giờ";
            // 
            // lblBannerSub
            // 
            this.lblBannerSub.AutoSize = true;
            this.lblBannerSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBannerSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblBannerSub.Location = new System.Drawing.Point(20, 50);
            this.lblBannerSub.Name = "lblBannerSub";
            this.lblBannerSub.Size = new System.Drawing.Size(914, 28);
            this.lblBannerSub.TabIndex = 1;
            this.lblBannerSub.Text = "💊 Thuốc chính hãng  •  ⚕ Tư vấn dược sĩ miễn phí  •  🚚 Giao nhanh 2–4 giờ  •  🔒" +
    " Bảo mật thông tin";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlRight);
            this.pnlBody.Controls.Add(this.pnlLeft);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 154);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1264, 607);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.flowProducts);
            this.pnlRight.Controls.Add(this.pnlFilterBar);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(185, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.pnlRight.Size = new System.Drawing.Size(1079, 607);
            this.pnlRight.TabIndex = 0;
            // 
            // flowProducts
            // 
            this.flowProducts.AutoScroll = true;
            this.flowProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.flowProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProducts.Location = new System.Drawing.Point(10, 46);
            this.flowProducts.Name = "flowProducts";
            this.flowProducts.Padding = new System.Windows.Forms.Padding(4);
            this.flowProducts.Size = new System.Drawing.Size(1059, 551);
            this.flowProducts.TabIndex = 0;
            // 
            // pnlFilterBar
            // 
            this.pnlFilterBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlFilterBar.Controls.Add(this.lblProductCount);
            this.pnlFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBar.Location = new System.Drawing.Point(10, 8);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1059, 38);
            this.pnlFilterBar.TabIndex = 1;
            // 
            // lblProductCount
            // 
            this.lblProductCount.AutoSize = true;
            this.lblProductCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProductCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblProductCount.Location = new System.Drawing.Point(0, 8);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(167, 28);
            this.lblProductCount.TabIndex = 0;
            this.lblProductCount.Text = "Tất cả sản phẩm";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.listCategories);
            this.pnlLeft.Controls.Add(this.pnlDiv);
            this.pnlLeft.Controls.Add(this.lblCatTitle);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(185, 607);
            this.pnlLeft.TabIndex = 1;
            // 
            // listCategories
            // 
            this.listCategories.BackColor = System.Drawing.Color.White;
            this.listCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCategories.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listCategories.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listCategories.ItemHeight = 30;
            this.listCategories.Location = new System.Drawing.Point(0, 38);
            this.listCategories.Name = "listCategories";
            this.listCategories.Size = new System.Drawing.Size(184, 569);
            this.listCategories.TabIndex = 0;
            this.listCategories.SelectedIndexChanged += new System.EventHandler(this.listCategories_SelectedIndexChanged);
            // 
            // pnlDiv
            // 
            this.pnlDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.pnlDiv.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDiv.Location = new System.Drawing.Point(184, 38);
            this.pnlDiv.Name = "pnlDiv";
            this.pnlDiv.Size = new System.Drawing.Size(1, 569);
            this.pnlDiv.TabIndex = 1;
            // 
            // lblCatTitle
            // 
            this.lblCatTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCatTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCatTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(165)))));
            this.lblCatTitle.Location = new System.Drawing.Point(0, 8);
            this.lblCatTitle.Name = "lblCatTitle";
            this.lblCatTitle.Size = new System.Drawing.Size(185, 30);
            this.lblCatTitle.TabIndex = 2;
            this.lblCatTitle.Text = "DANH MỤC";
            this.lblCatTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTrangChu
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBanner);
            this.Controls.Add(this.pnlTopNav);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 680);
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHÀ THUỐC PHARMACY – Cửa hàng trực tuyến";
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.pnlTopNav.ResumeLayout(false);
            this.pnlNavMiddle.ResumeLayout(false);
            this.pnlNavMiddle.PerformLayout();
            this.pnlNavRight.ResumeLayout(false);
            this.pnlNavLeft.ResumeLayout(false);
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlFilterBar.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlDiv;
    }
}