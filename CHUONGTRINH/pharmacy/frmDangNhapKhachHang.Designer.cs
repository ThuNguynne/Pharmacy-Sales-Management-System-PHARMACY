// frmDangNhapKhachHang_Designer.cs  –  PHIÊN BẢN SỬA LỖI
// Thêm: lblHuongDan (gợi ý loại tài khoản đang đăng nhập)
//        txtTenDangNhap KeyDown handler

namespace PharmacyManagement
{
    partial class frmDangNhapKhachHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.grpLoaiKH = new System.Windows.Forms.GroupBox();
            this.rdoThanhVien = new System.Windows.Forms.RadioButton();
            this.rdoSi = new System.Windows.Forms.RadioButton();
            this.lblHuongDan = new System.Windows.Forms.Label();   // MỚI THÊM
            this.lblTDN = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMK = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnlDangKy = new System.Windows.Forms.Panel();
            this.lblHoiDangKy = new System.Windows.Forms.Label();
            this.lnkDangKy = new System.Windows.Forms.LinkLabel();

            this.pnlHeader.SuspendLayout();
            this.grpLoaiKH.SuspendLayout();
            this.pnlDangKy.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(440, 72);
            this.pnlHeader.Name = "pnlHeader";

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "ĐĂNG NHẬP THÀNH VIÊN";

            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(200, 230, 255);
            this.lblSubTitle.Location = new System.Drawing.Point(18, 44);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Text = "🏥 Nhà Thuốc Pharmacy – Cổng dành cho Khách hàng";

            // ── grpLoaiKH ─────────────────────────────────────────
            this.grpLoaiKH.Controls.Add(this.rdoThanhVien);
            this.grpLoaiKH.Controls.Add(this.rdoSi);
            this.grpLoaiKH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpLoaiKH.Location = new System.Drawing.Point(20, 88);
            this.grpLoaiKH.Name = "grpLoaiKH";
            this.grpLoaiKH.Size = new System.Drawing.Size(400, 50);
            this.grpLoaiKH.Text = "Loại tài khoản";
            this.grpLoaiKH.TabIndex = 0;

            this.rdoThanhVien.AutoSize = true;
            this.rdoThanhVien.Checked = true;
            this.rdoThanhVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoThanhVien.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.rdoThanhVien.Location = new System.Drawing.Point(20, 20);
            this.rdoThanhVien.Name = "rdoThanhVien";
            this.rdoThanhVien.TabIndex = 0;
            this.rdoThanhVien.Text = "🥉 Thành viên";
            this.rdoThanhVien.CheckedChanged +=
                new System.EventHandler(this.rdoThanhVien_CheckedChanged);

            this.rdoSi.AutoSize = true;
            this.rdoSi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoSi.ForeColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.rdoSi.Location = new System.Drawing.Point(200, 20);
            this.rdoSi.Name = "rdoSi";
            this.rdoSi.TabIndex = 1;
            this.rdoSi.Text = "🏭 Khách sỉ";
            this.rdoSi.CheckedChanged +=
                new System.EventHandler(this.rdoSi_CheckedChanged);

            // ── lblHuongDan (gợi ý) ── MỚI THÊM ─────────────────
            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHuongDan.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblHuongDan.Location = new System.Drawing.Point(20, 148);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(400, 18);
            this.lblHuongDan.Text = "Nhập tên đăng nhập thành viên và mật khẩu.";

            // ── Tên đăng nhập ─────────────────────────────────────
            this.lblTDN.AutoSize = true;
            this.lblTDN.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTDN.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.lblTDN.Location = new System.Drawing.Point(20, 170);
            this.lblTDN.Name = "lblTDN";
            this.lblTDN.Text = "Tên đăng nhập";

            this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTenDangNhap.Location = new System.Drawing.Point(20, 192);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(400, 29);
            this.txtTenDangNhap.TabIndex = 1;
            this.txtTenDangNhap.KeyDown +=
                new System.Windows.Forms.KeyEventHandler(this.txtTenDangNhap_KeyDown);

            // ── Mật khẩu ─────────────────────────────────────────
            this.lblMK.AutoSize = true;
            this.lblMK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMK.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.lblMK.Location = new System.Drawing.Point(20, 238);
            this.lblMK.Name = "lblMK";
            this.lblMK.Text = "Mật khẩu";

            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMatKhau.Location = new System.Drawing.Point(20, 260);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Size = new System.Drawing.Size(400, 29);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.KeyDown +=
                new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);

            // ── Buttons ──────────────────────────────────────────
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(20, 312);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(190, 42);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click +=
                new System.EventHandler(this.btnDangNhap_Click);

            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnThoat.Location = new System.Drawing.Point(230, 312);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(190, 42);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click +=
                new System.EventHandler(this.btnThoat_Click);

            // ── Panel đăng ký ─────────────────────────────────────
            this.pnlDangKy.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.pnlDangKy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDangKy.Controls.Add(this.lblHoiDangKy);
            this.pnlDangKy.Controls.Add(this.lnkDangKy);
            this.pnlDangKy.Location = new System.Drawing.Point(20, 372);
            this.pnlDangKy.Name = "pnlDangKy";
            this.pnlDangKy.Size = new System.Drawing.Size(400, 38);

            this.lblHoiDangKy.AutoSize = true;
            this.lblHoiDangKy.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHoiDangKy.ForeColor = System.Drawing.Color.Gray;
            this.lblHoiDangKy.Location = new System.Drawing.Point(10, 10);
            this.lblHoiDangKy.Text = "Chưa có tài khoản thành viên?";

            this.lnkDangKy.AutoSize = true;
            this.lnkDangKy.Font = new System.Drawing.Font("Segoe UI", 9.5F,
                System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.lnkDangKy.Location = new System.Drawing.Point(228, 10);
            this.lnkDangKy.Name = "lnkDangKy";
            this.lnkDangKy.Text = "Đăng ký ngay";
            this.lnkDangKy.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDangKy_LinkClicked);

            // ── frmDangNhapKhachHang ──────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 428);
            this.Controls.Add(this.pnlDangKy);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblMK);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblTDN);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.grpLoaiKH);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDangNhapKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng nhập Khách hàng";
            this.Load += new System.EventHandler(this.frmDangNhapKhachHang_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpLoaiKH.ResumeLayout(false);
            this.grpLoaiKH.PerformLayout();
            this.pnlDangKy.ResumeLayout(false);
            this.pnlDangKy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.GroupBox grpLoaiKH;
        private System.Windows.Forms.RadioButton rdoThanhVien;
        private System.Windows.Forms.RadioButton rdoSi;
        private System.Windows.Forms.Label lblHuongDan;        // MỚI THÊM
        private System.Windows.Forms.Label lblTDN;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMK;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel pnlDangKy;
        private System.Windows.Forms.Label lblHoiDangKy;
        private System.Windows.Forms.LinkLabel lnkDangKy;
    }
}