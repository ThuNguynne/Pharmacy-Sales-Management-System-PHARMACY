using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmChiTietDonHang : Form
    {
        private string _maDH;
        private string _trangThai;

        public frmChiTietDonHang(string maDH, string trangThai)
        {
            InitializeComponent();
            _maDH = maDH;
            _trangThai = trangThai;
        }

        private void frmChiTietDonHang_Load(object sender, EventArgs e)
        {
            lblMaDonHang.Text = "Mã Đơn: " + _maDH;
            lblTrangThai.Text = "Trạng thái: " + HienThiTrangThai(_trangThai);

            // [FIX #1] Load chi tiết đơn hàng từ DB thay vì hardcode
            LoadChiTietDonHang();

            // [FIX #2] Load danh sách Shipper từ DB vào ComboBox
            LoadDanhSachShipper();

            // [FIX #3] Điều kiện hiển thị nút dựa trên giá trị DB thực ("ChoXacNhan")
            //          Chỉ cho phép phân công khi đơn hàng đang chờ xác nhận
            if (_trangThai != "ChoXacNhan")
            {
                btnPhanCong.Visible = false;
                cboShipper.Enabled = false;
                lblChonShipper.Text = "Shipper phụ trách: (Đã phân công hoặc không cần giao)";
            }
        }

        // [FIX #1] Load chi tiết đơn hàng từ CHITIETDONHANG
        private void LoadChiTietDonHang()
        {
            try
            {
                DataTable dtChiTiet = DatabaseHelper.GetChiTietDonHang(_maDH);

                if (dtChiTiet.Rows.Count == 0)
                {
                    // Hiển thị thông báo thay vì để grid trống không rõ lý do
                    lblTrangThai.Text += "  |  (Chưa có chi tiết sản phẩm)";
                }

                dgvChiTiet.DataSource = dtChiTiet;
                dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Định dạng header và số tiền nếu có dữ liệu
                if (dgvChiTiet.Columns.Count > 0)
                {
                    if (dgvChiTiet.Columns.Contains("TenThuoc"))
                        dgvChiTiet.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                    if (dgvChiTiet.Columns.Contains("SoLuong"))
                    {
                        dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng";
                        dgvChiTiet.Columns["SoLuong"].Width = 90;
                        dgvChiTiet.Columns["SoLuong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    }
                    if (dgvChiTiet.Columns.Contains("DonGia"))
                    {
                        dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn Giá";
                        dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                        dgvChiTiet.Columns["DonGia"].Width = 110;
                        dgvChiTiet.Columns["DonGia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    }
                    if (dgvChiTiet.Columns.Contains("ThanhTien"))
                    {
                        dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                        dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                        dgvChiTiet.Columns["ThanhTien"].Width = 120;
                        dgvChiTiet.Columns["ThanhTien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết đơn hàng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // [FIX #2] Load shipper từ DB với ValueMember = MANV
        private void LoadDanhSachShipper()
        {
            try
            {
                DataTable dtShipper = DatabaseHelper.GetDanhSachShipper();

                if (dtShipper.Rows.Count == 0)
                {
                    // Không có shipper nào → ẩn phần phân công
                    btnPhanCong.Enabled = false;
                    lblChonShipper.Text = "Không có shipper nào đang hoạt động";
                    return;
                }

                cboShipper.DataSource = dtShipper;
                cboShipper.DisplayMember = "TenHienThi";   // "MANV – TENNV"
                cboShipper.ValueMember = "MANV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách shipper: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // [FIX #3] Thực hiện phân công giao hàng vào DB
        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (cboShipper.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn shipper!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNVShipper = cboShipper.SelectedValue.ToString();
            string tenShipper = cboShipper.Text;

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận phân công đơn hàng [{_maDH}] cho:\n{tenShipper}?\n\n" +
                "Trạng thái đơn hàng sẽ chuyển sang: Đang Giao.",
                "Xác nhận phân công",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ok = DatabaseHelper.PhanCongGiaoHang(_maDH, maNVShipper);

            if (ok)
            {
                MessageBox.Show(
                    $"Phân công thành công!\n\nĐơn hàng : {_maDH}\nShipper   : {tenShipper}\nTrạng thái: Đang Giao",
                    "Phân công thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // Nếu không OK, DatabaseHelper đã hiện MessageBox lỗi
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Helper: chuyển giá trị DB sang tiếng Việt để hiển thị
        private string HienThiTrangThai(string dbValue)
        {
            switch (dbValue)
            {
                case "ChoXacNhan": return "Chờ xác nhận";
                case "DangChuanBi": return "Đang chuẩn bị";
                case "ChoGiao": return "Chờ giao hàng";
                case "DangGiao": return "Đang giao hàng";
                case "HoanThanh": return "Hoàn thành";
                case "DaHuy": return "Đã hủy";
                default: return dbValue;
            }
        }
    }
}