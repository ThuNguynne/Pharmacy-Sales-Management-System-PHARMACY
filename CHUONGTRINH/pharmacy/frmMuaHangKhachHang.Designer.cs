namespace PharmacyManagement
{
    partial class frmMuaHangKhachHang
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblTitleCart;
        private System.Windows.Forms.Label lblThanhVienInfo;
        private System.Windows.Forms.Panel pnlCartToolbar;
        private System.Windows.Forms.Button btnChonTatCa;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.DataGridViewButtonColumn colXoa;

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTitleOrder;

        private System.Windows.Forms.GroupBox grpNguoiNhan;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Panel pnlDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;

        // Các Panel Container mới để chia 2 cột
        private System.Windows.Forms.Panel pnlGiaoThanhToan;
        private System.Windows.Forms.Panel pnlKMDiem;

        private System.Windows.Forms.GroupBox grpGiaoHang;
        private System.Windows.Forms.RadioButton rdoGiaoTanNoi;
        private System.Windows.Forms.RadioButton rdoNhanTaiQuay;

        private System.Windows.Forms.GroupBox grpThanhToan;
        private System.Windows.Forms.RadioButton rdoCOD;
        private System.Windows.Forms.RadioButton rdoChuyenKhoan;
        private System.Windows.Forms.RadioButton rdoOnline;

        private System.Windows.Forms.Panel pnlKhuyenMai;
        private System.Windows.Forms.Label lblKMTitle;
        private System.Windows.Forms.TextBox txtMaKM;
        private System.Windows.Forms.Button btnApDungKM;
        private System.Windows.Forms.Button btnHuyKM;
        private System.Windows.Forms.Label lblTenKM;

        private System.Windows.Forms.Panel pnlDiemTichLuy;
        private System.Windows.Forms.Label lblDiemTitle;
        private System.Windows.Forms.Label lblDiemHienCo;
        private System.Windows.Forms.NumericUpDown numDungDiem;
        private System.Windows.Forms.Button btnDungDiem;

        private System.Windows.Forms.Panel pnlTong;
        private System.Windows.Forms.Label lblRowTamTinh;
        private System.Windows.Forms.Label lblTamTinh;
        private System.Windows.Forms.Panel pnlGiamTV;
        private System.Windows.Forms.Label lblRowGiamTV;
        private System.Windows.Forms.Label lblGiamTV;
        private System.Windows.Forms.Panel pnlGiamKM;
        private System.Windows.Forms.Label lblRowGiamKM;
        private System.Windows.Forms.Label lblGiamKM;
        private System.Windows.Forms.Panel pnlGiamDiem;
        private System.Windows.Forms.Label lblRowGiamDiem;
        private System.Windows.Forms.Label lblGiamDiem;
        private System.Windows.Forms.Label lblRowPhiShip;
        private System.Windows.Forms.Label lblPhiShip;
        private System.Windows.Forms.Panel pnlDivTong;
        private System.Windows.Forms.Label lblRowTongCong;
        private System.Windows.Forms.Label lblTongCong;

        private System.Windows.Forms.Panel pnlBtns;
        private System.Windows.Forms.Button btnDatHang;
        private System.Windows.Forms.Button btnQuayLai;

        private System.Windows.Forms.Panel pnlDivV;

        private System.Windows.Forms.Panel pnlSpc1;
        private System.Windows.Forms.Panel pnlSpc2;
        private System.Windows.Forms.Panel pnlSpc3;
        private System.Windows.Forms.Panel pnlSpc4;
        private System.Windows.Forms.Panel pnlSpc5;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.colChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlCartToolbar = new System.Windows.Forms.Panel();
            this.btnChonTatCa = new System.Windows.Forms.Button();
            this.lblThanhVienInfo = new System.Windows.Forms.Label();
            this.lblTitleCart = new System.Windows.Forms.Label();
            this.pnlDivV = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();

            this.pnlGiaoThanhToan = new System.Windows.Forms.Panel();
            this.pnlKMDiem = new System.Windows.Forms.Panel();

            this.pnlBtns = new System.Windows.Forms.Panel();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.btnDatHang = new System.Windows.Forms.Button();
            this.pnlTong = new System.Windows.Forms.Panel();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.lblRowTongCong = new System.Windows.Forms.Label();
            this.pnlDivTong = new System.Windows.Forms.Panel();
            this.lblPhiShip = new System.Windows.Forms.Label();
            this.lblRowPhiShip = new System.Windows.Forms.Label();
            this.pnlGiamDiem = new System.Windows.Forms.Panel();
            this.lblGiamDiem = new System.Windows.Forms.Label();
            this.lblRowGiamDiem = new System.Windows.Forms.Label();
            this.pnlGiamKM = new System.Windows.Forms.Panel();
            this.lblGiamKM = new System.Windows.Forms.Label();
            this.lblRowGiamKM = new System.Windows.Forms.Label();
            this.pnlGiamTV = new System.Windows.Forms.Panel();
            this.lblGiamTV = new System.Windows.Forms.Label();
            this.lblRowGiamTV = new System.Windows.Forms.Label();
            this.lblTamTinh = new System.Windows.Forms.Label();
            this.lblRowTamTinh = new System.Windows.Forms.Label();
            this.pnlDiemTichLuy = new System.Windows.Forms.Panel();
            this.btnDungDiem = new System.Windows.Forms.Button();
            this.numDungDiem = new System.Windows.Forms.NumericUpDown();
            this.lblDiemHienCo = new System.Windows.Forms.Label();
            this.lblDiemTitle = new System.Windows.Forms.Label();
            this.pnlKhuyenMai = new System.Windows.Forms.Panel();
            this.lblTenKM = new System.Windows.Forms.Label();
            this.btnHuyKM = new System.Windows.Forms.Button();
            this.btnApDungKM = new System.Windows.Forms.Button();
            this.txtMaKM = new System.Windows.Forms.TextBox();
            this.lblKMTitle = new System.Windows.Forms.Label();
            this.grpThanhToan = new System.Windows.Forms.GroupBox();
            this.rdoOnline = new System.Windows.Forms.RadioButton();
            this.rdoChuyenKhoan = new System.Windows.Forms.RadioButton();
            this.rdoCOD = new System.Windows.Forms.RadioButton();
            this.grpGiaoHang = new System.Windows.Forms.GroupBox();
            this.rdoNhanTaiQuay = new System.Windows.Forms.RadioButton();
            this.rdoGiaoTanNoi = new System.Windows.Forms.RadioButton();
            this.grpNguoiNhan = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.pnlDiaChi = new System.Windows.Forms.Panel();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblTitleOrder = new System.Windows.Forms.Label();

            this.pnlSpc1 = new System.Windows.Forms.Panel();
            this.pnlSpc2 = new System.Windows.Forms.Panel();
            this.pnlSpc3 = new System.Windows.Forms.Panel();
            this.pnlSpc4 = new System.Windows.Forms.Panel();
            this.pnlSpc5 = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlCartToolbar.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlGiaoThanhToan.SuspendLayout();
            this.pnlKMDiem.SuspendLayout();
            this.pnlBtns.SuspendLayout();
            this.pnlTong.SuspendLayout();
            this.pnlGiamDiem.SuspendLayout();
            this.pnlGiamKM.SuspendLayout();
            this.pnlGiamTV.SuspendLayout();
            this.pnlDiemTichLuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDungDiem)).BeginInit();
            this.pnlKhuyenMai.SuspendLayout();
            this.grpThanhToan.SuspendLayout();
            this.grpGiaoHang.SuspendLayout();
            this.grpNguoiNhan.SuspendLayout();
            this.pnlDiaChi.SuspendLayout();
            this.SuspendLayout();

            // pnlLeft
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.dgvGioHang);
            this.pnlLeft.Controls.Add(this.pnlCartToolbar);
            this.pnlLeft.Controls.Add(this.lblThanhVienInfo);
            this.pnlLeft.Controls.Add(this.lblTitleCart);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(20);
            this.pnlLeft.Size = new System.Drawing.Size(880, 950);
            this.pnlLeft.TabIndex = 0;

            // dgvGioHang
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AllowUserToDeleteRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(0, 82, 165);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvGioHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGioHang.ColumnHeadersHeight = 50;
            this.dgvGioHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChon, this.colSTT, this.colTen, this.colDonGia, this.colSL, this.colThanhTien, this.colXoa});
            this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioHang.EnableHeadersVisualStyles = false;
            this.dgvGioHang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dgvGioHang.Location = new System.Drawing.Point(20, 165);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.RowHeadersVisible = false;
            this.dgvGioHang.RowTemplate.Height = 50;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(840, 765);
            this.dgvGioHang.TabIndex = 3;
            this.dgvGioHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellContentClick);
            this.dgvGioHang.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellValueChanged);
            this.dgvGioHang.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGioHang_CurrentCellDirtyStateChanged);

            // Columns Config
            this.colChon.HeaderText = "✓"; this.colChon.Name = "colChon"; this.colChon.FillWeight = 8;
            this.colSTT.HeaderText = "#"; this.colSTT.Name = "colSTT"; this.colSTT.ReadOnly = true; this.colSTT.FillWeight = 8;
            this.colTen.HeaderText = "Tên sản phẩm"; this.colTen.Name = "colTen"; this.colTen.ReadOnly = true; this.colTen.FillWeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGia.DefaultCellStyle = dataGridViewCellStyle2; this.colDonGia.HeaderText = "Đơn giá"; this.colDonGia.Name = "colDonGia"; this.colDonGia.ReadOnly = true; this.colDonGia.FillWeight = 16;
            this.colSL.HeaderText = "SL"; this.colSL.Name = "colSL"; this.colSL.FillWeight = 10;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colThanhTien.DefaultCellStyle = dataGridViewCellStyle3; this.colThanhTien.HeaderText = "Thành tiền"; this.colThanhTien.Name = "colThanhTien"; this.colThanhTien.ReadOnly = true; this.colThanhTien.FillWeight = 18;
            System.Windows.Forms.DataGridViewCellStyle cellStyleXoa = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyleXoa.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            cellStyleXoa.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            cellStyleXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            cellStyleXoa.ForeColor = System.Drawing.Color.White;
            this.colXoa.DefaultCellStyle = cellStyleXoa; this.colXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colXoa.HeaderText = ""; this.colXoa.Name = "colXoa"; this.colXoa.Text = "✕ Xóa"; this.colXoa.UseColumnTextForButtonValue = true; this.colXoa.FillWeight = 15;

            // pnlCartToolbar
            this.pnlCartToolbar.Controls.Add(this.btnChonTatCa);
            this.pnlCartToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCartToolbar.Location = new System.Drawing.Point(20, 115);
            this.pnlCartToolbar.Name = "pnlCartToolbar";
            this.pnlCartToolbar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.pnlCartToolbar.Size = new System.Drawing.Size(840, 50);

            // btnChonTatCa
            this.btnChonTatCa.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnChonTatCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChonTatCa.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnChonTatCa.FlatAppearance.BorderSize = 0;
            this.btnChonTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonTatCa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnChonTatCa.ForeColor = System.Drawing.Color.White;
            this.btnChonTatCa.Location = new System.Drawing.Point(0, 10);
            this.btnChonTatCa.Size = new System.Drawing.Size(150, 30);
            this.btnChonTatCa.Text = "☑ Chọn tất cả";
            this.btnChonTatCa.Click += new System.EventHandler(this.btnChonTatCa_Click);

            // lblThanhVienInfo
            this.lblThanhVienInfo.BackColor = System.Drawing.Color.FromArgb(232, 248, 245);
            this.lblThanhVienInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThanhVienInfo.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.lblThanhVienInfo.ForeColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.lblThanhVienInfo.Location = new System.Drawing.Point(20, 75);
            this.lblThanhVienInfo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblThanhVienInfo.Size = new System.Drawing.Size(840, 40);
            this.lblThanhVienInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblThanhVienInfo.Visible = false;

            // lblTitleCart
            this.lblTitleCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleCart.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitleCart.ForeColor = System.Drawing.Color.FromArgb(0, 82, 165);
            this.lblTitleCart.Location = new System.Drawing.Point(20, 20);
            this.lblTitleCart.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblTitleCart.Size = new System.Drawing.Size(840, 55);
            this.lblTitleCart.Text = "🛒  GIỎ HÀNG CỦA BẠN";
            this.lblTitleCart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlDivV
            this.pnlDivV.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.pnlDivV.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDivV.Location = new System.Drawing.Point(880, 0);
            this.pnlDivV.Size = new System.Drawing.Size(2, 950);

            // pnlRight
            this.pnlRight.AutoScroll = true; // Phòng hờ màn quá bé
            this.pnlRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(882, 0);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(20);
            this.pnlRight.Size = new System.Drawing.Size(768, 950);

            // Spacers - Gọt mỏng lại khoảng cách
            this.pnlSpc1.Dock = System.Windows.Forms.DockStyle.Top; this.pnlSpc1.Height = 15;
            this.pnlSpc2.Dock = System.Windows.Forms.DockStyle.Top; this.pnlSpc2.Height = 15;
            this.pnlSpc3.Dock = System.Windows.Forms.DockStyle.Top; this.pnlSpc3.Height = 15;
            this.pnlSpc4.Dock = System.Windows.Forms.DockStyle.Top; this.pnlSpc4.Height = 15;
            this.pnlSpc5.Dock = System.Windows.Forms.DockStyle.Top; this.pnlSpc5.Height = 15;

            // lblTitleOrder
            this.lblTitleOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleOrder.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitleOrder.ForeColor = System.Drawing.Color.FromArgb(0, 82, 165);
            this.lblTitleOrder.Height = 55;
            this.lblTitleOrder.Text = "📋  THÔNG TIN ĐẶT HÀNG";
            this.lblTitleOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // grpNguoiNhan (Gọn gàng ngang dọc)
            this.grpNguoiNhan.Controls.Add(this.txtGhiChu);
            this.grpNguoiNhan.Controls.Add(this.lblGhiChu);
            this.grpNguoiNhan.Controls.Add(this.pnlDiaChi);
            this.grpNguoiNhan.Controls.Add(this.txtSDT);
            this.grpNguoiNhan.Controls.Add(this.lblSDT);
            this.grpNguoiNhan.Controls.Add(this.txtHoTen);
            this.grpNguoiNhan.Controls.Add(this.lblHoTen);
            this.grpNguoiNhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpNguoiNhan.Height = 230;
            this.grpNguoiNhan.Text = " 👤 Thông tin người nhận ";

            this.lblHoTen.AutoSize = true; this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 11F); this.lblHoTen.Location = new System.Drawing.Point(20, 35); this.lblHoTen.Text = "Họ và tên (*)";
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 12.5F); this.txtHoTen.Location = new System.Drawing.Point(20, 60); this.txtHoTen.Size = new System.Drawing.Size(430, 31);

            this.lblSDT.AutoSize = true; this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 11F); this.lblSDT.Location = new System.Drawing.Point(470, 35); this.lblSDT.Text = "Số điện thoại (*)";
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 12.5F); this.txtSDT.Location = new System.Drawing.Point(470, 60); this.txtSDT.Size = new System.Drawing.Size(230, 31);

            this.pnlDiaChi.Controls.Add(this.txtDiaChi); this.pnlDiaChi.Controls.Add(this.lblDiaChi); this.pnlDiaChi.Location = new System.Drawing.Point(15, 95); this.pnlDiaChi.Size = new System.Drawing.Size(695, 60);
            this.lblDiaChi.AutoSize = true; this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 11F); this.lblDiaChi.Location = new System.Drawing.Point(5, 5); this.lblDiaChi.Text = "Địa chỉ giao hàng (*)";
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 12.5F); this.txtDiaChi.Location = new System.Drawing.Point(5, 30); this.txtDiaChi.Size = new System.Drawing.Size(680, 31);

            this.lblGhiChu.AutoSize = true; this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 11F); this.lblGhiChu.Location = new System.Drawing.Point(20, 160); this.lblGhiChu.Text = "Ghi chú đơn hàng";
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 12.5F); this.txtGhiChu.Location = new System.Drawing.Point(20, 185); this.txtGhiChu.Size = new System.Drawing.Size(680, 31);

            // pnlGiaoThanhToan (Nhóm Giao Hàng & Thanh toán nằm ngang 2 cột)
            this.pnlGiaoThanhToan.Controls.Add(this.grpThanhToan);
            this.pnlGiaoThanhToan.Controls.Add(this.grpGiaoHang);
            this.pnlGiaoThanhToan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGiaoThanhToan.Height = 145;

            // grpGiaoHang
            this.grpGiaoHang.Controls.Add(this.rdoNhanTaiQuay); this.grpGiaoHang.Controls.Add(this.rdoGiaoTanNoi);
            this.grpGiaoHang.Dock = System.Windows.Forms.DockStyle.Left; this.grpGiaoHang.Width = 350;
            this.grpGiaoHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); this.grpGiaoHang.Text = " 🚚 Giao hàng ";
            this.rdoGiaoTanNoi.AutoSize = true; this.rdoGiaoTanNoi.Checked = true; this.rdoGiaoTanNoi.Font = new System.Drawing.Font("Segoe UI", 11.5F); this.rdoGiaoTanNoi.Location = new System.Drawing.Point(20, 40); this.rdoGiaoTanNoi.Text = "Giao tận nơi (30k)"; this.rdoGiaoTanNoi.CheckedChanged += new System.EventHandler(this.rdoGiaoTanNoi_CheckedChanged);
            this.rdoNhanTaiQuay.AutoSize = true; this.rdoNhanTaiQuay.Font = new System.Drawing.Font("Segoe UI", 11.5F); this.rdoNhanTaiQuay.Location = new System.Drawing.Point(20, 80); this.rdoNhanTaiQuay.Text = "Nhận tại nhà thuốc (0đ)";

            // grpThanhToan
            this.grpThanhToan.Controls.Add(this.rdoOnline); this.grpThanhToan.Controls.Add(this.rdoChuyenKhoan); this.grpThanhToan.Controls.Add(this.rdoCOD);
            this.grpThanhToan.Dock = System.Windows.Forms.DockStyle.Right; this.grpThanhToan.Width = 360;
            this.grpThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); this.grpThanhToan.Text = " 💳 Thanh toán ";
            this.rdoCOD.AutoSize = true; this.rdoCOD.Checked = true; this.rdoCOD.Font = new System.Drawing.Font("Segoe UI", 11.5F); this.rdoCOD.Location = new System.Drawing.Point(20, 35); this.rdoCOD.Text = "Tiền mặt khi nhận (COD)";
            this.rdoChuyenKhoan.AutoSize = true; this.rdoChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 11.5F); this.rdoChuyenKhoan.Location = new System.Drawing.Point(20, 70); this.rdoChuyenKhoan.Text = "Chuyển khoản ngân hàng";
            this.rdoOnline.AutoSize = true; this.rdoOnline.Font = new System.Drawing.Font("Segoe UI", 11.5F); this.rdoOnline.Location = new System.Drawing.Point(20, 105); this.rdoOnline.Text = "Ví điện tử / Thẻ online";

            // pnlKMDiem (Nhóm Khuyến mãi & Điểm nằm ngang 2 cột)
            this.pnlKMDiem.Controls.Add(this.pnlDiemTichLuy);
            this.pnlKMDiem.Controls.Add(this.pnlKhuyenMai);
            this.pnlKMDiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKMDiem.Height = 110;

            // pnlKhuyenMai
            this.pnlKhuyenMai.BackColor = System.Drawing.Color.FromArgb(255, 253, 235);
            this.pnlKhuyenMai.Controls.Add(this.lblTenKM); this.pnlKhuyenMai.Controls.Add(this.btnHuyKM); this.pnlKhuyenMai.Controls.Add(this.btnApDungKM); this.pnlKhuyenMai.Controls.Add(this.txtMaKM); this.pnlKhuyenMai.Controls.Add(this.lblKMTitle);
            this.pnlKhuyenMai.Dock = System.Windows.Forms.DockStyle.Left; this.pnlKhuyenMai.Width = 350; this.pnlKhuyenMai.Visible = false;
            this.lblKMTitle.AutoSize = true; this.lblKMTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold); this.lblKMTitle.ForeColor = System.Drawing.Color.FromArgb(180, 100, 0); this.lblKMTitle.Location = new System.Drawing.Point(15, 10); this.lblKMTitle.Text = "🏷️ Mã khuyến mãi / Voucher";
            this.txtMaKM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper; this.txtMaKM.Font = new System.Drawing.Font("Segoe UI", 12.5F); this.txtMaKM.Location = new System.Drawing.Point(15, 40); this.txtMaKM.Size = new System.Drawing.Size(160, 31);
            this.btnApDungKM.BackColor = System.Drawing.Color.FromArgb(0, 102, 204); this.btnApDungKM.ForeColor = System.Drawing.Color.White; this.btnApDungKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnApDungKM.FlatAppearance.BorderSize = 0; this.btnApDungKM.Location = new System.Drawing.Point(185, 39); this.btnApDungKM.Size = new System.Drawing.Size(90, 33); this.btnApDungKM.Text = "Áp dụng"; this.btnApDungKM.Click += new System.EventHandler(this.btnApDungKM_Click);
            this.btnHuyKM.BackColor = System.Drawing.Color.FromArgb(108, 117, 125); this.btnHuyKM.ForeColor = System.Drawing.Color.White; this.btnHuyKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnHuyKM.FlatAppearance.BorderSize = 0; this.btnHuyKM.Location = new System.Drawing.Point(280, 39); this.btnHuyKM.Size = new System.Drawing.Size(55, 33); this.btnHuyKM.Text = "Hủy"; this.btnHuyKM.Click += new System.EventHandler(this.btnHuyKM_Click);
            this.lblTenKM.AutoSize = true; this.lblTenKM.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Italic); this.lblTenKM.ForeColor = System.Drawing.Color.ForestGreen; this.lblTenKM.Location = new System.Drawing.Point(15, 75);

            // pnlDiemTichLuy
            this.pnlDiemTichLuy.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.pnlDiemTichLuy.Controls.Add(this.btnDungDiem); this.pnlDiemTichLuy.Controls.Add(this.numDungDiem); this.pnlDiemTichLuy.Controls.Add(this.lblDiemHienCo); this.pnlDiemTichLuy.Controls.Add(this.lblDiemTitle);
            this.pnlDiemTichLuy.Dock = System.Windows.Forms.DockStyle.Right; this.pnlDiemTichLuy.Width = 360; this.pnlDiemTichLuy.Visible = false;
            this.lblDiemTitle.AutoSize = true; this.lblDiemTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold); this.lblDiemTitle.ForeColor = System.Drawing.Color.FromArgb(0, 82, 165); this.lblDiemTitle.Location = new System.Drawing.Point(15, 10); this.lblDiemTitle.Text = "⭐ Sử dụng điểm tích lũy";
            this.lblDiemHienCo.AutoSize = true; this.lblDiemHienCo.Font = new System.Drawing.Font("Segoe UI", 10.5F); this.lblDiemHienCo.ForeColor = System.Drawing.Color.Gray; this.lblDiemHienCo.Location = new System.Drawing.Point(15, 80);
            this.numDungDiem.Font = new System.Drawing.Font("Segoe UI", 12.5F); this.numDungDiem.Location = new System.Drawing.Point(15, 40); this.numDungDiem.Maximum = new decimal(new int[] { 999999, 0, 0, 0 }); this.numDungDiem.Size = new System.Drawing.Size(180, 31); this.numDungDiem.ThousandsSeparator = true;
            this.btnDungDiem.BackColor = System.Drawing.Color.FromArgb(0, 153, 76); this.btnDungDiem.ForeColor = System.Drawing.Color.White; this.btnDungDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnDungDiem.FlatAppearance.BorderSize = 0; this.btnDungDiem.Location = new System.Drawing.Point(205, 39); this.btnDungDiem.Size = new System.Drawing.Size(120, 33); this.btnDungDiem.Text = "Đổi điểm"; this.btnDungDiem.Click += new System.EventHandler(this.btnDungDiem_Click);

            // pnlTong (Thu gọn chiều dọc)
            this.pnlTong.BackColor = System.Drawing.Color.White;
            this.pnlTong.Controls.Add(this.lblTongCong); this.pnlTong.Controls.Add(this.lblRowTongCong); this.pnlTong.Controls.Add(this.pnlDivTong); this.pnlTong.Controls.Add(this.lblPhiShip); this.pnlTong.Controls.Add(this.lblRowPhiShip); this.pnlTong.Controls.Add(this.pnlGiamDiem); this.pnlTong.Controls.Add(this.pnlGiamKM); this.pnlTong.Controls.Add(this.pnlGiamTV); this.pnlTong.Controls.Add(this.lblTamTinh); this.pnlTong.Controls.Add(this.lblRowTamTinh);
            this.pnlTong.Dock = System.Windows.Forms.DockStyle.Top; this.pnlTong.Height = 220;

            this.lblRowTamTinh.AutoSize = true; this.lblRowTamTinh.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblRowTamTinh.Location = new System.Drawing.Point(20, 15); this.lblRowTamTinh.Text = "Tạm tính:";
            this.lblTamTinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); this.lblTamTinh.Location = new System.Drawing.Point(400, 15); this.lblTamTinh.Size = new System.Drawing.Size(300, 25); this.lblTamTinh.Text = "0 đ"; this.lblTamTinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.pnlGiamTV.Controls.Add(this.lblGiamTV); this.pnlGiamTV.Controls.Add(this.lblRowGiamTV); this.pnlGiamTV.Location = new System.Drawing.Point(0, 45); this.pnlGiamTV.Size = new System.Drawing.Size(728, 30); this.pnlGiamTV.Visible = false;
            this.lblRowGiamTV.AutoSize = true; this.lblRowGiamTV.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblRowGiamTV.ForeColor = System.Drawing.Color.ForestGreen; this.lblRowGiamTV.Location = new System.Drawing.Point(20, 0); this.lblRowGiamTV.Text = "Giảm giá thành viên:";
            this.lblGiamTV.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblGiamTV.ForeColor = System.Drawing.Color.ForestGreen; this.lblGiamTV.Location = new System.Drawing.Point(400, 0); this.lblGiamTV.Size = new System.Drawing.Size(300, 25); this.lblGiamTV.Text = "0 đ"; this.lblGiamTV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.pnlGiamKM.Controls.Add(this.lblGiamKM); this.pnlGiamKM.Controls.Add(this.lblRowGiamKM); this.pnlGiamKM.Location = new System.Drawing.Point(0, 75); this.pnlGiamKM.Size = new System.Drawing.Size(728, 30); this.pnlGiamKM.Visible = false;
            this.lblRowGiamKM.AutoSize = true; this.lblRowGiamKM.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblRowGiamKM.ForeColor = System.Drawing.Color.DarkOrange; this.lblRowGiamKM.Location = new System.Drawing.Point(20, 0); this.lblRowGiamKM.Text = "Mã khuyến mãi:";
            this.lblGiamKM.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblGiamKM.ForeColor = System.Drawing.Color.DarkOrange; this.lblGiamKM.Location = new System.Drawing.Point(400, 0); this.lblGiamKM.Size = new System.Drawing.Size(300, 25); this.lblGiamKM.Text = "0 đ"; this.lblGiamKM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.pnlGiamDiem.Controls.Add(this.lblGiamDiem); this.pnlGiamDiem.Controls.Add(this.lblRowGiamDiem); this.pnlGiamDiem.Location = new System.Drawing.Point(0, 105); this.pnlGiamDiem.Size = new System.Drawing.Size(728, 30); this.pnlGiamDiem.Visible = false;
            this.lblRowGiamDiem.AutoSize = true; this.lblRowGiamDiem.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblRowGiamDiem.ForeColor = System.Drawing.Color.FromArgb(0, 153, 76); this.lblRowGiamDiem.Location = new System.Drawing.Point(20, 0); this.lblRowGiamDiem.Text = "Dùng điểm tích lũy:";
            this.lblGiamDiem.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblGiamDiem.ForeColor = System.Drawing.Color.FromArgb(0, 153, 76); this.lblGiamDiem.Location = new System.Drawing.Point(400, 0); this.lblGiamDiem.Size = new System.Drawing.Size(300, 25); this.lblGiamDiem.Text = "0 đ"; this.lblGiamDiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblRowPhiShip.AutoSize = true; this.lblRowPhiShip.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblRowPhiShip.Location = new System.Drawing.Point(20, 135); this.lblRowPhiShip.Text = "Phí vận chuyển:";
            this.lblPhiShip.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblPhiShip.Location = new System.Drawing.Point(400, 135); this.lblPhiShip.Size = new System.Drawing.Size(300, 25); this.lblPhiShip.Text = "+30.000 đ"; this.lblPhiShip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.pnlDivTong.BackColor = System.Drawing.Color.FromArgb(200, 200, 200); this.pnlDivTong.Location = new System.Drawing.Point(20, 170); this.pnlDivTong.Size = new System.Drawing.Size(690, 2);

            this.lblRowTongCong.AutoSize = true; this.lblRowTongCong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblRowTongCong.ForeColor = System.Drawing.Color.FromArgb(0, 82, 165); this.lblRowTongCong.Location = new System.Drawing.Point(20, 180); this.lblRowTongCong.Text = "TỔNG CỘNG:";
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(0, 82, 165); this.lblTongCong.Location = new System.Drawing.Point(350, 175); this.lblTongCong.Size = new System.Drawing.Size(350, 40); this.lblTongCong.Text = "0 đ"; this.lblTongCong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pnlBtns
            this.pnlBtns.Controls.Add(this.btnQuayLai); this.pnlBtns.Controls.Add(this.btnDatHang);
            this.pnlBtns.Dock = System.Windows.Forms.DockStyle.Top; this.pnlBtns.Height = 80;
            this.btnDatHang.BackColor = System.Drawing.Color.FromArgb(0, 153, 76); this.btnDatHang.ForeColor = System.Drawing.Color.White; this.btnDatHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnDatHang.FlatAppearance.BorderSize = 0; this.btnDatHang.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); this.btnDatHang.Location = new System.Drawing.Point(20, 10); this.btnDatHang.Size = new System.Drawing.Size(460, 55); this.btnDatHang.Text = "✅  ĐẶT HÀNG NGAY"; this.btnDatHang.Click += new System.EventHandler(this.btnDatHang_Click);
            this.btnQuayLai.BackColor = System.Drawing.Color.FromArgb(108, 117, 125); this.btnQuayLai.ForeColor = System.Drawing.Color.White; this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnQuayLai.FlatAppearance.BorderSize = 0; this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 13F); this.btnQuayLai.Location = new System.Drawing.Point(500, 10); this.btnQuayLai.Size = new System.Drawing.Size(210, 55); this.btnQuayLai.Text = "← Quay lại"; this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);

            // Add Control Theo Ngược Trình Tự Top Down
            this.pnlRight.Controls.Add(this.pnlBtns);
            this.pnlRight.Controls.Add(this.pnlSpc5);
            this.pnlRight.Controls.Add(this.pnlTong);
            this.pnlRight.Controls.Add(this.pnlSpc4);
            this.pnlRight.Controls.Add(this.pnlKMDiem);
            this.pnlRight.Controls.Add(this.pnlSpc3);
            this.pnlRight.Controls.Add(this.pnlGiaoThanhToan);
            this.pnlRight.Controls.Add(this.pnlSpc2);
            this.pnlRight.Controls.Add(this.grpNguoiNhan);
            this.pnlRight.Controls.Add(this.pnlSpc1);
            this.pnlRight.Controls.Add(this.lblTitleOrder);

            // frmMuaHangKhachHang
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1650, 950);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlDivV);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.MinimumSize = new System.Drawing.Size(1400, 800);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giỏ hàng & Thanh toán";
            this.Load += new System.EventHandler(this.frmMuaHangKhachHang_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlCartToolbar.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlGiaoThanhToan.ResumeLayout(false);
            this.pnlKMDiem.ResumeLayout(false);
            this.pnlBtns.ResumeLayout(false);
            this.pnlTong.ResumeLayout(false);
            this.pnlTong.PerformLayout();
            this.pnlGiamDiem.ResumeLayout(false);
            this.pnlGiamDiem.PerformLayout();
            this.pnlGiamKM.ResumeLayout(false);
            this.pnlGiamKM.PerformLayout();
            this.pnlGiamTV.ResumeLayout(false);
            this.pnlGiamTV.PerformLayout();
            this.pnlDiemTichLuy.ResumeLayout(false);
            this.pnlDiemTichLuy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDungDiem)).EndInit();
            this.pnlKhuyenMai.ResumeLayout(false);
            this.pnlKhuyenMai.PerformLayout();
            this.grpThanhToan.ResumeLayout(false);
            this.grpThanhToan.PerformLayout();
            this.grpGiaoHang.ResumeLayout(false);
            this.grpGiaoHang.PerformLayout();
            this.grpNguoiNhan.ResumeLayout(false);
            this.grpNguoiNhan.PerformLayout();
            this.pnlDiaChi.ResumeLayout(false);
            this.pnlDiaChi.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}