namespace PharmacyManagement
{
    partial class frmDangKyKhachHangSi
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
            this.pnlBody = new System.Windows.Forms.Panel();
            // -- Left group: Thông tin cá nhân
            this.grpCaNhan = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            // -- Right group: Công ty
            this.grpCongTy = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenCongTy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMST = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgayKyHD = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpNgayHetHan = new System.Windows.Forms.DateTimePicker();
            // -- Contract group
            this.grpHopDong = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudHanMuc = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudTyLeChietKhau = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudThoiHan = new System.Windows.Forms.NumericUpDown();
            // -- Account group
            this.grpTaiKhoan = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtXacNhanMK = new System.Windows.Forms.TextBox();
            // -- Buttons
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.grpCaNhan.SuspendLayout();
            this.grpCongTy.SuspendLayout();
            this.grpHopDong.SuspendLayout();
            this.grpTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHanMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTyLeChietKhau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiHan)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(860, 66);
            this.pnlHeader.Name = "pnlHeader";

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 10);
            this.lblTitle.Text = "ĐĂNG KÝ KHÁCH HÀNG SỈ";

            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(255, 220, 180);
            this.lblSubTitle.Location = new System.Drawing.Point(18, 42);
            this.lblSubTitle.Text = "Ký hợp đồng mua sỉ – Nhà Thuốc Pharmacy";

            // ── pnlBody ───────────────────────────────────────────
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBody.AutoScroll = true;
            this.pnlBody.Controls.Add(this.grpCaNhan);
            this.pnlBody.Controls.Add(this.grpCongTy);
            this.pnlBody.Controls.Add(this.grpHopDong);
            this.pnlBody.Controls.Add(this.grpTaiKhoan);
            this.pnlBody.Controls.Add(this.btnLuu);
            this.pnlBody.Controls.Add(this.btnHuy);
            this.pnlBody.Name = "pnlBody";

            // ── grpCaNhan ─────────────────────────────────────────
            this.grpCaNhan.Controls.Add(this.label1);
            this.grpCaNhan.Controls.Add(this.txtHoTen);
            this.grpCaNhan.Controls.Add(this.label2);
            this.grpCaNhan.Controls.Add(this.txtSDT);
            this.grpCaNhan.Controls.Add(this.lblNgaySinh);
            this.grpCaNhan.Controls.Add(this.dtpNgaySinh);
            this.grpCaNhan.Controls.Add(this.label3);
            this.grpCaNhan.Controls.Add(this.txtDiaChi);
            this.grpCaNhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCaNhan.ForeColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.grpCaNhan.Location = new System.Drawing.Point(10, 10);
            this.grpCaNhan.Size = new System.Drawing.Size(400, 195);
            this.grpCaNhan.Text = "Thông tin cá nhân";

            AddLabelAndControl(this.grpCaNhan, this.label1, "Họ và tên: *", 10, 25, this.txtHoTen, 140, 22, 240, 26);
            AddLabelAndControl(this.grpCaNhan, this.label2, "Số điện thoại: *", 10, 62, this.txtSDT, 140, 59, 150, 26);
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgaySinh.Location = new System.Drawing.Point(10, 100);
            this.lblNgaySinh.Text = "Ngày sinh:";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(140, 97);
            this.dtpNgaySinh.Size = new System.Drawing.Size(150, 26);
            this.dtpNgaySinh.ShowCheckBox = true;
            this.dtpNgaySinh.Checked = false;
            AddLabelAndControl(this.grpCaNhan, this.label3, "Địa chỉ:", 10, 137, this.txtDiaChi, 140, 134, 240, 50);
            this.txtDiaChi.Multiline = true;

            // ── grpCongTy ─────────────────────────────────────────
            this.grpCongTy.Controls.Add(this.label4);
            this.grpCongTy.Controls.Add(this.txtTenCongTy);
            this.grpCongTy.Controls.Add(this.label5);
            this.grpCongTy.Controls.Add(this.txtMST);
            this.grpCongTy.Controls.Add(this.label6);
            this.grpCongTy.Controls.Add(this.dtpNgayKyHD);
            this.grpCongTy.Controls.Add(this.label7);
            this.grpCongTy.Controls.Add(this.dtpNgayHetHan);
            this.grpCongTy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCongTy.ForeColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.grpCongTy.Location = new System.Drawing.Point(430, 10);
            this.grpCongTy.Size = new System.Drawing.Size(410, 195);
            this.grpCongTy.Text = "Thông tin công ty";

            AddLabelAndControl(this.grpCongTy, this.label4, "Tên công ty: *", 10, 25, this.txtTenCongTy, 130, 22, 260, 26);
            AddLabelAndControl(this.grpCongTy, this.label5, "Mã số thuế: *", 10, 62, this.txtMST, 130, 59, 160, 26);
            this.label6.AutoSize = true; this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(10, 100); this.label6.Text = "Ngày ký HĐ: *";
            this.dtpNgayKyHD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKyHD.Location = new System.Drawing.Point(130, 97);
            this.dtpNgayKyHD.Size = new System.Drawing.Size(140, 26);
            this.dtpNgayKyHD.ValueChanged += new System.EventHandler(this.dtpNgayKyHD_ValueChanged);
            this.label7.AutoSize = true; this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(10, 137); this.label7.Text = "Ngày hết hạn: *";
            this.dtpNgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHetHan.Location = new System.Drawing.Point(130, 134);
            this.dtpNgayHetHan.Size = new System.Drawing.Size(140, 26);

            // ── grpHopDong ────────────────────────────────────────
            this.grpHopDong.Controls.Add(this.label8);
            this.grpHopDong.Controls.Add(this.nudHanMuc);
            this.grpHopDong.Controls.Add(this.label9);
            this.grpHopDong.Controls.Add(this.nudTyLeChietKhau);
            this.grpHopDong.Controls.Add(this.label10);
            this.grpHopDong.Controls.Add(this.nudThoiHan);
            this.grpHopDong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpHopDong.ForeColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.grpHopDong.Location = new System.Drawing.Point(10, 215);
            this.grpHopDong.Size = new System.Drawing.Size(830, 80);
            this.grpHopDong.Text = "Điều khoản hợp đồng";

            this.label8.AutoSize = true; this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(10, 30); this.label8.Text = "Hạn mức công nợ (đ): *";
            this.nudHanMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudHanMuc.Location = new System.Drawing.Point(165, 27);
            this.nudHanMuc.Size = new System.Drawing.Size(160, 26);
            this.nudHanMuc.Maximum = 999_999_999m; this.nudHanMuc.Minimum = 1_000_000m;
            this.nudHanMuc.Increment = 1_000_000m; this.nudHanMuc.DecimalPlaces = 0;

            this.label9.AutoSize = true; this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(340, 30); this.label9.Text = "Chiết khấu (%):";
            this.nudTyLeChietKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudTyLeChietKhau.Location = new System.Drawing.Point(460, 27);
            this.nudTyLeChietKhau.Size = new System.Drawing.Size(80, 26);
            this.nudTyLeChietKhau.Maximum = 50m; this.nudTyLeChietKhau.Minimum = 0m;
            this.nudTyLeChietKhau.DecimalPlaces = 1;

            this.label10.AutoSize = true; this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.Location = new System.Drawing.Point(560, 30); this.label10.Text = "Thời hạn TT (ngày):";
            this.nudThoiHan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudThoiHan.Location = new System.Drawing.Point(700, 27);
            this.nudThoiHan.Size = new System.Drawing.Size(80, 26);
            this.nudThoiHan.Maximum = 365m; this.nudThoiHan.Minimum = 1m;

            // ── grpTaiKhoan ───────────────────────────────────────
            this.grpTaiKhoan.Controls.Add(this.label11);
            this.grpTaiKhoan.Controls.Add(this.txtTenDangNhap);
            this.grpTaiKhoan.Controls.Add(this.label12);
            this.grpTaiKhoan.Controls.Add(this.txtMatKhau);
            this.grpTaiKhoan.Controls.Add(this.label13);
            this.grpTaiKhoan.Controls.Add(this.txtXacNhanMK);
            this.grpTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.grpTaiKhoan.Location = new System.Drawing.Point(10, 305);
            this.grpTaiKhoan.Size = new System.Drawing.Size(830, 80);
            this.grpTaiKhoan.Text = "Tài khoản đăng nhập";

            AddLabelAndControl(this.grpTaiKhoan, this.label11, "Tên đăng nhập: *", 10, 30,
                this.txtTenDangNhap, 145, 27, 200, 26);
            AddLabelAndControl(this.grpTaiKhoan, this.label12, "Mật khẩu: *", 370, 30,
                this.txtMatKhau, 465, 27, 160, 26);
            this.txtMatKhau.PasswordChar = '●';
            AddLabelAndControl(this.grpTaiKhoan, this.label13, "Xác nhận MK: *", 645, 30,
                this.txtXacNhanMK, 755, 27, 60, 26);
            this.txtXacNhanMK.PasswordChar = '●';

            // ── Buttons ──────────────────────────────────────────
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(10, 400);
            this.btnLuu.Size = new System.Drawing.Size(200, 42);
            this.btnLuu.Text = "Lưu hợp đồng sỉ";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.btnHuy.Location = new System.Drawing.Point(230, 400);
            this.btnHuy.Size = new System.Drawing.Size(130, 42);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // ── frmDangKyKhachHangSi ──────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 530);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDangKyKhachHangSi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký Khách hàng Sỉ";
            this.Load += new System.EventHandler(this.frmDangKyKhachHangSi_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpCaNhan.ResumeLayout(false);
            this.grpCaNhan.PerformLayout();
            this.grpCongTy.ResumeLayout(false);
            this.grpCongTy.PerformLayout();
            this.grpHopDong.ResumeLayout(false);
            this.grpHopDong.PerformLayout();
            this.grpTaiKhoan.ResumeLayout(false);
            this.grpTaiKhoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHanMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTyLeChietKhau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiHan)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // Helper gán label + control gọn
        private void AddLabelAndControl(
            System.Windows.Forms.Control parent,
            System.Windows.Forms.Label lbl, string text, int lx, int ly,
            System.Windows.Forms.Control ctrl, int cx, int cy, int cw, int ch)
        {
            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.ForeColor = System.Drawing.Color.Black;
            lbl.Location = new System.Drawing.Point(lx, ly);
            lbl.Text = text;
            ctrl.Font = new System.Drawing.Font("Segoe UI", 10F);
            ctrl.Location = new System.Drawing.Point(cx, cy);
            ctrl.Size = new System.Drawing.Size(cw, ch);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.GroupBox grpCaNhan;
        private System.Windows.Forms.Label label1, label2, lblNgaySinh, label3;
        private System.Windows.Forms.TextBox txtHoTen, txtSDT, txtDiaChi;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.GroupBox grpCongTy;
        private System.Windows.Forms.Label label4, label5, label6, label7;
        private System.Windows.Forms.TextBox txtTenCongTy, txtMST;
        private System.Windows.Forms.DateTimePicker dtpNgayKyHD, dtpNgayHetHan;
        private System.Windows.Forms.GroupBox grpHopDong;
        private System.Windows.Forms.Label label8, label9, label10;
        private System.Windows.Forms.NumericUpDown nudHanMuc, nudTyLeChietKhau, nudThoiHan;
        private System.Windows.Forms.GroupBox grpTaiKhoan;
        private System.Windows.Forms.Label label11, label12, label13;
        private System.Windows.Forms.TextBox txtTenDangNhap, txtMatKhau, txtXacNhanMK;
        private System.Windows.Forms.Button btnLuu, btnHuy;
    }
}