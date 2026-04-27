using System;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmThanhToan : Form
    {
        public decimal TongTienBanDau { get; set; }
        public decimal TongTienPhaiTra { get; private set; }
        public string PhuongThucThanhToan { get; private set; }
        public decimal TienKhachDua { get; private set; }
        public decimal TienThua { get; private set; }

        public frmThanhToan(decimal tongTien)
        {
            InitializeComponent();
            TongTienBanDau = tongTien;
            TongTienPhaiTra = tongTien;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblTongTien.Text = TongTienBanDau.ToString("N0") + " VNĐ";
            lblPhaiTra.Text = TongTienPhaiTra.ToString("N0") + " VNĐ";
            cboPhuongThuc.SelectedIndex = 0; // Mặc định là Tiền mặt
        }

        private void btnApDungKM_Click(object sender, EventArgs e)
        {
            string maKM = txtMaKhuyenMai.Text.Trim().ToUpper();
            if (maKM == "GIAM10K") // Giả lập BLL kiểm tra mã KM
            {
                MessageBox.Show("Áp dụng mã giảm giá 10.000 VNĐ thành công!", "Khuyến mãi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TongTienPhaiTra = TongTienBanDau - 10000;
                if (TongTienPhaiTra < 0) TongTienPhaiTra = 0;
                lblPhaiTra.Text = TongTienPhaiTra.ToString("N0") + " VNĐ";
                TinhTienThua();
            }
            else
            {
                MessageBox.Show("Mã khuyến mãi không hợp lệ hoặc đã hết hạn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            TinhTienThua();
        }

        private void TinhTienThua()
        {
            if (decimal.TryParse(txtTienKhachDua.Text, out decimal tienKhach))
            {
                TienKhachDua = tienKhach;
                TienThua = TienKhachDua - TongTienPhaiTra;
                lblTienThua.Text = TienThua >= 0 ? TienThua.ToString("N0") + " VNĐ" : "Chưa đủ tiền";
                lblTienThua.ForeColor = TienThua >= 0 ? Color.FromArgb(40, 167, 69) : Color.Red;
            }
            else
            {
                lblTienThua.Text = "0 VNĐ";
            }
        }

        private void cboPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhuongThuc.Text == "Tiền mặt")
            {
                txtTienKhachDua.Enabled = true;
            }
            else // Chuyển khoản / Quẹt thẻ
            {
                txtTienKhachDua.Enabled = false;
                txtTienKhachDua.Text = TongTienPhaiTra.ToString(); // Tự động điền đủ tiền
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cboPhuongThuc.Text == "Tiền mặt" && TienThua < 0)
            {
                MessageBox.Show("Số tiền khách đưa không đủ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhuongThucThanhToan = cboPhuongThuc.Text;

            // TODO: BLL - Ghi dữ liệu vào bảng PHIEUTHANTOAN (Trạng thái: Thành công)
            // Lấy MACN, MATK từ SessionManager để lưu

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}