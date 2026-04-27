namespace PharmacyManagement
{
    partial class frmDangKyThanhVien
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTDN = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMK = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblXacNhanMK = new System.Windows.Forms.Label();
            this.txtXacNhanMK = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNgayCap = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHangThe = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(480, 60);
            this.pnlHeader.Name = "pnlHeader";

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(70, 16);
            this.lblTitle.Text = "ĐĂNG KÝ THÀNH VIÊN";

            // ── Họ và tên ─────────────────────────────────────────
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 80);
            this.label1.Text = "Họ và tên: *";

            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtHoTen.Location = new System.Drawing.Point(160, 77);
            this.txtHoTen.Size = new System.Drawing.Size(290, 27);
            this.txtHoTen.TabIndex = 1;

            // ── Số điện thoại ─────────────────────────────────────
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 122);
            this.label2.Text = "Số điện thoại: *";

            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSDT.Location = new System.Drawing.Point(160, 119);
            this.txtSDT.Size = new System.Drawing.Size(290, 27);
            this.txtSDT.TabIndex = 2;

            // ── Ngày sinh ─────────────────────────────────────────
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNgaySinh.Location = new System.Drawing.Point(20, 164);
            this.lblNgaySinh.Text = "Ngày sinh:";

            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(160, 161);
            this.dtpNgaySinh.Size = new System.Drawing.Size(180, 27);
            this.dtpNgaySinh.ShowCheckBox = true;
            this.dtpNgaySinh.Checked = false;
            this.dtpNgaySinh.TabIndex = 3;

            // ── Địa chỉ ───────────────────────────────────────────
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 206);
            this.label3.Text = "Địa chỉ:";

            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDiaChi.Location = new System.Drawing.Point(160, 203);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Size = new System.Drawing.Size(290, 50);
            this.txtDiaChi.TabIndex = 4;

            // ── Email ─────────────────────────────────────────────
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(20, 270);
            this.lblEmail.Text = "Email: *";

            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.Location = new System.Drawing.Point(160, 267);
            this.txtEmail.Size = new System.Drawing.Size(290, 27);
            this.txtEmail.TabIndex = 5;

            // ── Tên đăng nhập ─────────────────────────────────────
            this.lblTDN.AutoSize = true;
            this.lblTDN.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTDN.Location = new System.Drawing.Point(20, 312);
            this.lblTDN.Text = "Tên đăng nhập: *";

            this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTenDangNhap.Location = new System.Drawing.Point(160, 309);
            this.txtTenDangNhap.Size = new System.Drawing.Size(290, 27);
            this.txtTenDangNhap.TabIndex = 6;

            // ── Mật khẩu ─────────────────────────────────────────
            this.lblMK.AutoSize = true;
            this.lblMK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMK.Location = new System.Drawing.Point(20, 354);
            this.lblMK.Text = "Mật khẩu: *";

            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMatKhau.Location = new System.Drawing.Point(160, 351);
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Size = new System.Drawing.Size(290, 27);
            this.txtMatKhau.TabIndex = 7;

            // ── Xác nhận mật khẩu ────────────────────────────────
            this.lblXacNhanMK.AutoSize = true;
            this.lblXacNhanMK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblXacNhanMK.Location = new System.Drawing.Point(20, 396);
            this.lblXacNhanMK.Text = "Xác nhận MK: *";

            this.txtXacNhanMK.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtXacNhanMK.Location = new System.Drawing.Point(160, 393);
            this.txtXacNhanMK.PasswordChar = '●';
            this.txtXacNhanMK.Size = new System.Drawing.Size(290, 27);
            this.txtXacNhanMK.TabIndex = 8;

            // ── GroupBox: Thông tin thẻ (không có HANTHE) ─────────
            this.groupBox1.Controls.Add(this.lblNgayCap);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblHangThe);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.groupBox1.Location = new System.Drawing.Point(20, 435);
            this.groupBox1.Size = new System.Drawing.Size(440, 70);
            this.groupBox1.Text = "Thẻ thành viên (cấp tự động)";

            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 35);
            this.label4.Text = "Ngày cấp:";

            this.lblNgayCap.AutoSize = true;
            this.lblNgayCap.ForeColor = System.Drawing.Color.DimGray;
            this.lblNgayCap.Location = new System.Drawing.Point(85, 35);
            this.lblNgayCap.Text = "00/00/0000";

            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(200, 35);
            this.label5.Text = "Hạng thẻ:";

            this.lblHangThe.AutoSize = true;
            this.lblHangThe.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.lblHangThe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHangThe.Location = new System.Drawing.Point(280, 35);
            this.lblHangThe.Text = "Đồng  (nâng hạng khi tích điểm)";

            // ── Buttons ──────────────────────────────────────────
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(20, 525);
            this.btnXacNhan.Size = new System.Drawing.Size(200, 40);
            this.btnXacNhan.TabIndex = 9;
            this.btnXacNhan.Text = "Xác nhận đăng ký";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnHuy.Location = new System.Drawing.Point(260, 525);
            this.btnHuy.Size = new System.Drawing.Size(200, 40);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy bỏ";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // ── frmDangKyThanhVien ────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 585);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtXacNhanMK);
            this.Controls.Add(this.lblXacNhanMK);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblMK);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblTDN);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDangKyThanhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký Thành viên";
            this.Load += new System.EventHandler(this.frmDangKyThanhVien_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTDN;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMK;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblXacNhanMK;
        private System.Windows.Forms.TextBox txtXacNhanMK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNgayCap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHangThe;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
    }
}