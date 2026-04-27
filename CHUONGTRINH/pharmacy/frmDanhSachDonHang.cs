using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmDanhSachDonHang : Form
    {
        private const string CONNECTION_STRING = "Data Source=DESKTOP-Q1UORLL\\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";

        public frmDanhSachDonHang()
        {
            InitializeComponent();
        }

        private void frmDanhSachDonHang_Load(object sender, EventArgs e)
        {
            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;

            LoadDanhSachDonHang();
        }

        private void LoadDanhSachDonHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            d.MADON AS MaDonHang, 
                            d.NGAYDAT AS NgayDat, 
                            k.HOTEN AS TenKhachHang, 
                            d.TONGTIEN AS TongTien, 
                            d.TRANGTHAIDON AS TrangThai 
                        FROM DONHANG d
                        LEFT JOIN KHACHHANG k ON d.MAKH = k.MAKH
                        WHERE 1=1";

                    if (cboTrangThai.SelectedIndex > 0)
                    {
                        string selectedValue = cboTrangThai.SelectedItem.ToString();
                        string dbValue = "";

                        switch (selectedValue)
                        {
                            case "Chờ xác nhận": dbValue = "ChoXacNhan"; break;
                            case "Đang chuẩn bị": dbValue = "DangChuanBi"; break;
                            case "Chờ giao hàng": dbValue = "ChoGiao"; break;
                            case "Đang giao hàng": dbValue = "DangGiao"; break;
                            case "Hoàn thành": dbValue = "HoanThanh"; break;
                            case "Đã hủy": dbValue = "DaHuy"; break;
                        }

                        if (!string.IsNullOrEmpty(dbValue))
                        {
                            query += " AND d.TRANGTHAIDON = @trangThai";
                        }
                    }

                    query += " ORDER BY d.NGAYDAT DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (cboTrangThai.SelectedIndex > 0)
                        {
                            string selectedValue = cboTrangThai.SelectedItem.ToString();
                            string dbValue = "";
                            switch (selectedValue)
                            {
                                case "Chờ xác nhận": dbValue = "ChoXacNhan"; break;
                                case "Đang chuẩn bị": dbValue = "DangChuanBi"; break;
                                case "Chờ giao hàng": dbValue = "ChoGiao"; break;
                                case "Đang giao hàng": dbValue = "DangGiao"; break;
                                case "Hoàn thành": dbValue = "HoanThanh"; break;
                                case "Đã hủy": dbValue = "DaHuy"; break;
                            }
                            cmd.Parameters.AddWithValue("@trangThai", dbValue);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvDonHang.DataSource = dt;
                        FormatGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvDonHang.Columns.Count > 0)
            {
                dgvDonHang.Columns["MaDonHang"].HeaderText = "Mã Đơn";
                dgvDonHang.Columns["NgayDat"].HeaderText = "Ngày Đặt";
                dgvDonHang.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvDonHang.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                dgvDonHang.Columns["TenKhachHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDonHang.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvDonHang.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvDonHang.Columns["TrangThai"].HeaderText = "Trạng Thái";
            }
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachDonHang();
        }

        private void dgvDonHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDonHang.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                switch (status)
                {
                    case "ChoXacNhan":
                        e.Value = "Chờ xác nhận";
                        e.CellStyle.ForeColor = Color.OrangeRed;
                        e.CellStyle.Font = new Font(dgvDonHang.Font, FontStyle.Bold);
                        break;
                    case "DangChuanBi":
                        e.Value = "Đang chuẩn bị";
                        e.CellStyle.ForeColor = Color.DarkCyan;
                        break;
                    case "ChoGiao":
                        e.Value = "Chờ giao hàng";
                        break;
                    case "DangGiao":
                        e.Value = "Đang giao hàng";
                        e.CellStyle.ForeColor = Color.Blue;
                        break;
                    case "HoanThanh":
                        e.Value = "Hoàn thành";
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case "DaHuy":
                        e.Value = "Đã hủy";
                        e.CellStyle.ForeColor = Color.Gray;
                        break;
                }
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng!", "Thông báo");
                return;
            }

            string maDH = dgvDonHang.SelectedRows[0].Cells["MaDonHang"].Value.ToString();
            string trangThai = dgvDonHang.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            frmChiTietDonHang frmChiTiet = new frmChiTietDonHang(maDH, trangThai);
            if (frmChiTiet.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachDonHang();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}