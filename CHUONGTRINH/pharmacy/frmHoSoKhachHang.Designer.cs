namespace PharmacyManagement
{
    partial class frmHoSoKhachHang
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
            // ── Controls khai báo ─────────────────────────────────
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitleMain = new System.Windows.Forms.Label();
            this.lblLoaiKH = new System.Windows.Forms.Label();
            this.pnlChung = new System.Windows.Forms.GroupBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            // labels tiêu đề bên trái
            this.lbl_MaKH = new System.Windows.Forms.Label();
            this.lbl_HoTen = new System.Windows.Forms.Label();
            this.lbl_SDT = new System.Windows.Forms.Label();
            this.lbl_DiaChi = new System.Windows.Forms.Label();
            this.lbl_NgaySinh = new System.Windows.Forms.Label();
            // Panel thành viên
            this.pnlThanhVien = new System.Windows.Forms.GroupBox();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.lblNgayCap = new System.Windows.Forms.Label();
            this.lblHangTV = new System.Windows.Forms.Label();
            this.lblDiemTichLuy = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lbl_MaThe = new System.Windows.Forms.Label();
            this.lbl_NgayCap = new System.Windows.Forms.Label();
            this.lbl_HangTV = new System.Windows.Forms.Label();
            this.lbl_Diem = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            // Panel sỉ
            this.pnlSi = new System.Windows.Forms.GroupBox();
            this.lblTenCongTy = new System.Windows.Forms.Label();
            this.lblMST = new System.Windows.Forms.Label();
            this.lblHanMuc = new System.Windows.Forms.Label();
            this.lblCongNo = new System.Windows.Forms.Label();
            this.lblTyLeCK = new System.Windows.Forms.Label();
            this.lblThoiHan = new System.Windows.Forms.Label();
            this.lblTrangThaiHD = new System.Windows.Forms.Label();
            this.lblNgayKyHD = new System.Windows.Forms.Label();
            this.lblNgayHH = new System.Windows.Forms.Label();
            this.lbl_Cty = new System.Windows.Forms.Label();
            this.lbl_MST = new System.Windows.Forms.Label();
            this.lbl_HanMuc = new System.Windows.Forms.Label();
            this.lbl_CongNo = new System.Windows.Forms.Label();
            this.lbl_TyLeCK = new System.Windows.Forms.Label();
            this.lbl_ThoiHan = new System.Windows.Forms.Label();
            this.lbl_TrangThaiHD = new System.Windows.Forms.Label();
            this.lbl_NKy = new System.Windows.Forms.Label();
            this.lbl_NHH = new System.Windows.Forms.Label();
            // History tab
            this.grpLichSu = new System.Windows.Forms.GroupBox();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.lblTongHoaDon = new System.Windows.Forms.Label();
            // Button
            this.btnDong = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlChung.SuspendLayout();
            this.pnlThanhVien.SuspendLayout();
            this.pnlSi.SuspendLayout();
            this.grpLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.pnlHeader.Controls.Add(this.lblTitleMain);
            this.pnlHeader.Controls.Add(this.lblLoaiKH);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(920, 64);
            this.pnlHeader.Name = "pnlHeader";

            this.lblTitleMain.AutoSize = true;
            this.lblTitleMain.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitleMain.ForeColor = System.Drawing.Color.White;
            this.lblTitleMain.Location = new System.Drawing.Point(16, 10);
            this.lblTitleMain.Text = "HỒ SƠ KHÁCH HÀNG";

            this.lblLoaiKH.AutoSize = true;
            this.lblLoaiKH.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLoaiKH.ForeColor = System.Drawing.Color.FromArgb(200, 240, 255);
            this.lblLoaiKH.Location = new System.Drawing.Point(16, 40);
            this.lblLoaiKH.Text = "—";

            // ── pnlChung ──────────────────────────────────────────
            this.pnlChung.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pnlChung.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.pnlChung.Location = new System.Drawing.Point(10, 74);
            this.pnlChung.Size = new System.Drawing.Size(900, 95);
            this.pnlChung.Text = "Thông tin cơ bản";

            Row(this.pnlChung, this.lbl_MaKH, "Mã KH:", 10, 24, this.lblMaKH, 115);
            Row(this.pnlChung, this.lbl_HoTen, "Họ tên:", 10, 48, this.lblHoTen, 115);
            Row(this.pnlChung, this.lbl_SDT, "SĐT:", 250, 24, this.lblSDT, 330);
            Row(this.pnlChung, this.lbl_DiaChi, "Địa chỉ:", 490, 24, this.lblDiaChi, 570);
            this.lblDiaChi.Size = new System.Drawing.Size(315, 17);
            Row(this.pnlChung, this.lbl_NgaySinh, "Ngày sinh:", 250, 48, this.lblNgaySinh, 330);

            // ── pnlThanhVien ──────────────────────────────────────
            this.pnlThanhVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pnlThanhVien.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.pnlThanhVien.Location = new System.Drawing.Point(10, 178);
            this.pnlThanhVien.Size = new System.Drawing.Size(900, 78);
            this.pnlThanhVien.Text = "Thông tin thành viên";
            this.pnlThanhVien.Visible = false;

            Row(this.pnlThanhVien, this.lbl_Email, "Email:", 10, 24, this.lblEmail, 80);
            Row(this.pnlThanhVien, this.lbl_HangTV, "Hạng thẻ:", 300, 24, this.lblHangTV, 380);
            Row(this.pnlThanhVien, this.lbl_Diem, "Điểm:", 490, 24, this.lblDiemTichLuy, 540);
            Row(this.pnlThanhVien, this.lbl_MaThe, "Số thẻ:", 10, 48, this.lblMaThe, 80);
            Row(this.pnlThanhVien, this.lbl_NgayCap, "Ngày cấp:", 300, 48, this.lblNgayCap, 380);

            // ── pnlSi ─────────────────────────────────────────────
            this.pnlSi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pnlSi.ForeColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.pnlSi.Location = new System.Drawing.Point(10, 178);
            this.pnlSi.Size = new System.Drawing.Size(900, 100);
            this.pnlSi.Text = "Thông tin hợp đồng sỉ";
            this.pnlSi.Visible = false;

            Row(this.pnlSi, this.lbl_Cty, "Công ty:", 10, 22, this.lblTenCongTy, 75);
            Row(this.pnlSi, this.lbl_MST, "MST:", 440, 22, this.lblMST, 480);
            Row(this.pnlSi, this.lbl_HanMuc, "Hạn mức CN:", 10, 48, this.lblHanMuc, 95);
            Row(this.pnlSi, this.lbl_CongNo, "Công nợ HT:", 220, 48, this.lblCongNo, 305);
            Row(this.pnlSi, this.lbl_TyLeCK, "Chiết khấu:", 440, 48, this.lblTyLeCK, 520);
            Row(this.pnlSi, this.lbl_ThoiHan, "Thời hạn TT:", 620, 48, this.lblThoiHan, 710);
            Row(this.pnlSi, this.lbl_TrangThaiHD, "Trạng thái:", 10, 72, this.lblTrangThaiHD, 95);
            Row(this.pnlSi, this.lbl_NKy, "Ngày ký:", 300, 72, this.lblNgayKyHD, 370);
            Row(this.pnlSi, this.lbl_NHH, "Hết hạn:", 500, 72, this.lblNgayHH, 565);

            // ── grpLichSu ─────────────────────────────────────────
            this.grpLichSu.Controls.Add(this.dgvLichSu);
            this.grpLichSu.Controls.Add(this.lblTongHoaDon);
            this.grpLichSu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpLichSu.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.grpLichSu.Location = new System.Drawing.Point(10, 286);
            this.grpLichSu.Size = new System.Drawing.Size(900, 230);
            this.grpLichSu.Text = "Lịch sử mua hàng (20 gần nhất)";

            this.lblTongHoaDon.AutoSize = true;
            this.lblTongHoaDon.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTongHoaDon.ForeColor = System.Drawing.Color.Gray;
            this.lblTongHoaDon.Location = new System.Drawing.Point(10, 200);
            this.lblTongHoaDon.Text = "—";

            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLichSu.ColumnHeadersHeight = 30;
            this.dgvLichSu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvLichSu.Location = new System.Drawing.Point(8, 22);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.RowTemplate.Height = 26;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.Size = new System.Drawing.Size(882, 172);
            this.dgvLichSu.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichSu_CellDoubleClick);

            // ── btnDong ───────────────────────────────────────────
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnDong.Location = new System.Drawing.Point(780, 530);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(130, 36);
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            // ── frmHoSoKhachHang ──────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 580);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.grpLichSu);
            this.Controls.Add(this.pnlSi);
            this.Controls.Add(this.pnlThanhVien);
            this.Controls.Add(this.pnlChung);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(920, 580);
            this.Name = "frmHoSoKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hồ sơ Khách hàng";
            this.Load += new System.EventHandler(this.frmHoSoKhachHang_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlChung.ResumeLayout(false);
            this.pnlChung.PerformLayout();
            this.pnlThanhVien.ResumeLayout(false);
            this.pnlThanhVien.PerformLayout();
            this.pnlSi.ResumeLayout(false);
            this.pnlSi.PerformLayout();
            this.grpLichSu.ResumeLayout(false);
            this.grpLichSu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);
        }

        // Helper gọn gán 1 dòng label + value
        private void Row(
            System.Windows.Forms.Control parent,
            System.Windows.Forms.Label lbl, string title, int lx, int ly,
            System.Windows.Forms.Label val, int vx)
        {
            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.DimGray;
            lbl.Location = new System.Drawing.Point(lx, ly);
            lbl.Text = title;
            parent.Controls.Add(lbl);

            val.AutoSize = true;
            val.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            val.ForeColor = System.Drawing.Color.Black;
            val.Location = new System.Drawing.Point(vx, ly);
            val.Text = "—";
            parent.Controls.Add(val);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitleMain;
        private System.Windows.Forms.Label lblLoaiKH;
        private System.Windows.Forms.GroupBox pnlChung;
        private System.Windows.Forms.Label lbl_MaKH, lbl_HoTen, lbl_SDT, lbl_DiaChi, lbl_NgaySinh;
        private System.Windows.Forms.Label lblMaKH, lblHoTen, lblSDT, lblDiaChi, lblNgaySinh;
        private System.Windows.Forms.GroupBox pnlThanhVien;
        private System.Windows.Forms.Label lbl_Email, lbl_HangTV, lbl_Diem, lbl_MaThe, lbl_NgayCap;
        private System.Windows.Forms.Label lblEmail, lblHangTV, lblDiemTichLuy, lblMaThe, lblNgayCap;
        private System.Windows.Forms.GroupBox pnlSi;
        private System.Windows.Forms.Label lbl_Cty, lbl_MST, lbl_HanMuc, lbl_CongNo;
        private System.Windows.Forms.Label lbl_TyLeCK, lbl_ThoiHan, lbl_TrangThaiHD, lbl_NKy, lbl_NHH;
        private System.Windows.Forms.Label lblTenCongTy, lblMST, lblHanMuc, lblCongNo;
        private System.Windows.Forms.Label lblTyLeCK, lblThoiHan, lblTrangThaiHD, lblNgayKyHD, lblNgayHH;
        private System.Windows.Forms.GroupBox grpLichSu;
        private System.Windows.Forms.DataGridView dgvLichSu;
        private System.Windows.Forms.Label lblTongHoaDon;
        private System.Windows.Forms.Button btnDong;
    }
}