namespace PharmacyManagement
{
    partial class frmPhieuDoiTra
    {
        private System.ComponentModel.IContainer components = null;

        // ── Controls ────────────────────────────────────────────────
        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;

        // GroupBox 1 – Tìm kiếm
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Button btnTimHoaDon;
        private System.Windows.Forms.Label lblHuongDan;

        // GroupBox 2 – Danh sách thuốc trong hóa đơn
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvChiTietHD;

        // GroupBox 3 – Thông tin đổi trả
        private System.Windows.Forms.GroupBox grpDoiTra;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblTienHoan;
        private System.Windows.Forms.TextBox txtTienHoan;
        private System.Windows.Forms.Label lblTienHoanDVT;

        // Buttons hành động
        private System.Windows.Forms.Button btnHoanTien;
        private System.Windows.Forms.Button btnLamMoi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle styleHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleRow = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();

            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.btnTimHoaDon = new System.Windows.Forms.Button();
            this.lblHuongDan = new System.Windows.Forms.Label();

            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvChiTietHD = new System.Windows.Forms.DataGridView();

            this.grpDoiTra = new System.Windows.Forms.GroupBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblTienHoan = new System.Windows.Forms.Label();
            this.txtTienHoan = new System.Windows.Forms.TextBox();
            this.lblTienHoanDVT = new System.Windows.Forms.Label();

            this.btnHoanTien = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).BeginInit();
            this.grpDoiTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.SuspendLayout();

            // ================================================================
            // HEADER PANEL
            // ================================================================
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "XỬ LÝ ĐỔI TRẢ THUỐC"; // Đã bỏ emoji để tránh lỗi font tách chữ

            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(210, 235, 255);
            this.lblSubTitle.Location = new System.Drawing.Point(24, 42);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Text = "Tra cứu hóa đơn → Chọn thuốc → Nhập thông tin → Xác nhận hoàn tiền";

            // ================================================================
            // GROUP 1 – TÌM KIẾM HÓA ĐƠN
            // ================================================================
            this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpTimKiem.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.grpTimKiem.Location = new System.Drawing.Point(25, 85);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(1000, 80);
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tra Cứu Hóa Đơn";
            this.grpTimKiem.Controls.Add(this.lblHuongDan);
            this.grpTimKiem.Controls.Add(this.btnTimHoaDon);
            this.grpTimKiem.Controls.Add(this.txtMaHD);
            this.grpTimKiem.Controls.Add(this.lblMaHD);

            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaHD.ForeColor = System.Drawing.Color.Black;
            this.lblMaHD.Location = new System.Drawing.Point(20, 36);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Text = "Mã Hóa Đơn:";

            this.txtMaHD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaHD.Location = new System.Drawing.Point(120, 33);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(250, 25);
            this.txtMaHD.TabIndex = 0;

            this.btnTimHoaDon.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnTimHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimHoaDon.FlatAppearance.BorderSize = 0;
            this.btnTimHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnTimHoaDon.Location = new System.Drawing.Point(390, 31);
            this.btnTimHoaDon.Name = "btnTimHoaDon";
            this.btnTimHoaDon.Size = new System.Drawing.Size(140, 30);
            this.btnTimHoaDon.TabIndex = 1;
            this.btnTimHoaDon.Text = "TÌM KIẾM";
            this.btnTimHoaDon.UseVisualStyleBackColor = false;
            this.btnTimHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimHoaDon.Click += new System.EventHandler(this.btnTimHoaDon_Click);

            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblHuongDan.ForeColor = System.Drawing.Color.DimGray;
            this.lblHuongDan.Location = new System.Drawing.Point(550, 38);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Text = "* Sau khi tìm thấy, click chọn dòng thuốc cần đổi/trả bên dưới";

            // ================================================================
            // GROUP 2 – DANH SÁCH THUỐC TRONG HÓA ĐƠN
            // ================================================================
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDanhSach.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.grpDanhSach.Location = new System.Drawing.Point(25, 180);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(1000, 260);
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh Sách Thuốc Trong Hóa Đơn";
            this.grpDanhSach.Controls.Add(this.dgvChiTietHD);

            // DataGridView
            this.dgvChiTietHD.AllowUserToAddRows = false;
            this.dgvChiTietHD.AllowUserToDeleteRows = false;
            this.dgvChiTietHD.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHD.ReadOnly = true;
            this.dgvChiTietHD.RowHeadersVisible = false;
            this.dgvChiTietHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHD.MultiSelect = false;
            this.dgvChiTietHD.RowTemplate.Height = 32;

            styleHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            styleHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            styleHeader.ForeColor = System.Drawing.Color.White;
            styleHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            styleHeader.SelectionBackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            styleHeader.SelectionForeColor = System.Drawing.Color.White;
            styleHeader.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietHD.ColumnHeadersDefaultCellStyle = styleHeader;
            this.dgvChiTietHD.ColumnHeadersHeight = 40;
            this.dgvChiTietHD.EnableHeadersVisualStyles = false;

            styleRow.Font = new System.Drawing.Font("Segoe UI", 10F);
            styleRow.BackColor = System.Drawing.Color.White;
            styleRow.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            styleRow.SelectionBackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            styleRow.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvChiTietHD.DefaultCellStyle = styleRow;

            this.dgvChiTietHD.Location = new System.Drawing.Point(15, 30);
            this.dgvChiTietHD.Name = "dgvChiTietHD";
            this.dgvChiTietHD.Size = new System.Drawing.Size(970, 215);
            this.dgvChiTietHD.TabIndex = 2;
            this.dgvChiTietHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvChiTietHD.GridColor = System.Drawing.Color.FromArgb(220, 230, 240);

            // ================================================================
            // GROUP 3 – THÔNG TIN ĐỔI TRẢ
            // ================================================================
            this.grpDoiTra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDoiTra.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.grpDoiTra.Location = new System.Drawing.Point(25, 455);
            this.grpDoiTra.Name = "grpDoiTra";
            this.grpDoiTra.Size = new System.Drawing.Size(1000, 85);
            this.grpDoiTra.TabStop = false;
            this.grpDoiTra.Text = "Thông Tin Đổi Trả";
            this.grpDoiTra.Controls.Add(this.lblTienHoanDVT);
            this.grpDoiTra.Controls.Add(this.txtTienHoan);
            this.grpDoiTra.Controls.Add(this.lblTienHoan);
            this.grpDoiTra.Controls.Add(this.txtLyDo);
            this.grpDoiTra.Controls.Add(this.lblLyDo);
            this.grpDoiTra.Controls.Add(this.numSoLuong);
            this.grpDoiTra.Controls.Add(this.lblSoLuong);

            // Số lượng đổi trả
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoLuong.ForeColor = System.Drawing.Color.Black;
            this.lblSoLuong.Location = new System.Drawing.Point(20, 37);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Text = "Số lượng đổi trả:";

            this.numSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numSoLuong.Location = new System.Drawing.Point(140, 35);
            this.numSoLuong.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numSoLuong.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(100, 25);
            this.numSoLuong.TabIndex = 3;

            // Lý do
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLyDo.ForeColor = System.Drawing.Color.Black;
            this.lblLyDo.Location = new System.Drawing.Point(270, 37);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Text = "Lý do đổi trả:";

            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLyDo.Location = new System.Drawing.Point(370, 35);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(350, 25);
            this.txtLyDo.TabIndex = 4;

            // Tiền hoàn
            this.lblTienHoan.AutoSize = true;
            this.lblTienHoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTienHoan.ForeColor = System.Drawing.Color.Black;
            this.lblTienHoan.Location = new System.Drawing.Point(750, 37);
            this.lblTienHoan.Name = "lblTienHoan";
            this.lblTienHoan.Text = "Tiền hoàn:";

            this.txtTienHoan.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtTienHoan.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.txtTienHoan.Location = new System.Drawing.Point(835, 34);
            this.txtTienHoan.Name = "txtTienHoan";
            this.txtTienHoan.Size = new System.Drawing.Size(120, 26);
            this.txtTienHoan.TabIndex = 5;
            this.txtTienHoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblTienHoanDVT.AutoSize = true;
            this.lblTienHoanDVT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTienHoanDVT.ForeColor = System.Drawing.Color.DimGray;
            this.lblTienHoanDVT.Location = new System.Drawing.Point(960, 38);
            this.lblTienHoanDVT.Name = "lblTienHoanDVT";
            this.lblTienHoanDVT.Text = "VNĐ";

            // ================================================================
            // BUTTONS HÀNH ĐỘNG
            // ================================================================
            // Nút Xác nhận hoàn tiền (đỏ)
            this.btnHoanTien.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnHoanTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoanTien.FlatAppearance.BorderSize = 0;
            this.btnHoanTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHoanTien.ForeColor = System.Drawing.Color.White;
            this.btnHoanTien.Location = new System.Drawing.Point(625, 560);
            this.btnHoanTien.Name = "btnHoanTien";
            this.btnHoanTien.Size = new System.Drawing.Size(260, 45);
            this.btnHoanTien.TabIndex = 6;
            this.btnHoanTien.Text = "XÁC NHẬN HOÀN TIỀN";
            this.btnHoanTien.UseVisualStyleBackColor = false;
            this.btnHoanTien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoanTien.Click += new System.EventHandler(this.btnHoanTien_Click);

            // Nút Làm mới (xám)
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(895, 560);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 45);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // ================================================================
            // FORM CHÍNH
            // ================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize = new System.Drawing.Size(1050, 630); // Đã mở rộng Form
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmPhieuDoiTra";
            this.Text = "Đổi Trả Hàng";
            this.Load += new System.EventHandler(this.frmPhieuDoiTra_Load);

            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnHoanTien);
            this.Controls.Add(this.grpDoiTra);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).EndInit();
            this.grpDoiTra.ResumeLayout(false);
            this.grpDoiTra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
        }
    }
}