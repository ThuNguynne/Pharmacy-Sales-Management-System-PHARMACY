namespace PharmacyManagement
{
    partial class frmChiTietDonHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblMaDonHang = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.grpPhanCong = new System.Windows.Forms.GroupBox();
            this.lblChonShipper = new System.Windows.Forms.Label();
            this.cboShipper = new System.Windows.Forms.ComboBox();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.grpPhanCong.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.pnlHeader.Controls.Add(this.lblMaDonHang);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(584, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblMaDonHang
            // 
            this.lblMaDonHang.AutoSize = true;
            this.lblMaDonHang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblMaDonHang.ForeColor = System.Drawing.Color.White;
            this.lblMaDonHang.Location = new System.Drawing.Point(20, 15);
            this.lblMaDonHang.Name = "lblMaDonHang";
            this.lblMaDonHang.Size = new System.Drawing.Size(252, 30);
            this.lblMaDonHang.TabIndex = 0;
            this.lblMaDonHang.Text = "CHI TIẾT ĐƠN HÀNG";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.lblTrangThai.Location = new System.Drawing.Point(20, 75);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(200, 21);
            this.lblTrangThai.TabIndex = 1;
            this.lblTrangThai.Text = "Trạng thái: Chưa xác nhận";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersHeight = 30;
            this.dgvChiTiet.Location = new System.Drawing.Point(20, 110);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.Size = new System.Drawing.Size(540, 200);
            this.dgvChiTiet.TabIndex = 2;
            // 
            // grpPhanCong
            // 
            this.grpPhanCong.Controls.Add(this.lblChonShipper);
            this.grpPhanCong.Controls.Add(this.cboShipper);
            this.grpPhanCong.Controls.Add(this.btnPhanCong);
            this.grpPhanCong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPhanCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.grpPhanCong.Location = new System.Drawing.Point(20, 330);
            this.grpPhanCong.Name = "grpPhanCong";
            this.grpPhanCong.Size = new System.Drawing.Size(540, 100);
            this.grpPhanCong.TabIndex = 3;
            this.grpPhanCong.TabStop = false;
            this.grpPhanCong.Text = "Phân công Giao Hàng";
            // 
            // lblChonShipper
            // 
            this.lblChonShipper.AutoSize = true;
            this.lblChonShipper.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChonShipper.ForeColor = System.Drawing.Color.Black;
            this.lblChonShipper.Location = new System.Drawing.Point(20, 40);
            this.lblChonShipper.Name = "lblChonShipper";
            this.lblChonShipper.Size = new System.Drawing.Size(95, 19);
            this.lblChonShipper.TabIndex = 0;
            this.lblChonShipper.Text = "Chọn Shipper:";
            // 
            // cboShipper
            // 
            this.cboShipper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShipper.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboShipper.FormattingEnabled = true;
            this.cboShipper.Location = new System.Drawing.Point(130, 37);
            this.cboShipper.Name = "cboShipper";
            this.cboShipper.Size = new System.Drawing.Size(200, 25);
            this.cboShipper.TabIndex = 1;
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnPhanCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhanCong.ForeColor = System.Drawing.Color.White;
            this.btnPhanCong.Location = new System.Drawing.Point(350, 35);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(160, 35);
            this.btnPhanCong.TabIndex = 2;
            this.btnPhanCong.Text = "Xác nhận && Chuyển";
            this.btnPhanCong.UseVisualStyleBackColor = false;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnDong.Location = new System.Drawing.Point(460, 445);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 35);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmChiTietDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 501);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.grpPhanCong);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmChiTietDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi Tiết Đơn Hàng";
            this.Load += new System.EventHandler(this.frmChiTietDonHang_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.grpPhanCong.ResumeLayout(false);
            this.grpPhanCong.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblMaDonHang;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.GroupBox grpPhanCong;
        private System.Windows.Forms.Label lblChonShipper;
        private System.Windows.Forms.ComboBox cboShipper;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnDong;
    }
}