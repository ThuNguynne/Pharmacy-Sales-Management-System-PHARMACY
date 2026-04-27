using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmSuaKhachHang : Form
    {
        private const string CONNECTION_STRING = @"Data Source=DESKTOP-Q1UORLL\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";
        private string maKH_selected;

        // Constructor nhận mã KH từ Form Quản lý
        public frmSuaKhachHang(string maKH)
        {
            InitializeComponent();
            this.maKH_selected = maKH;
        }

        private void frmSuaKhachHang_Load(object sender, EventArgs e)
        {
            LoadThongTinKhachHang();
        }

        private void LoadThongTinKhachHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    string query = "SELECT * FROM KHACHHANG WHERE MAKH = @MaKH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", maKH_selected);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtMaKH.Text = dr["MAKH"].ToString();
                                txtHoTen.Text = dr["HOTEN"].ToString();
                                txtSDT.Text = dr["SDT"].ToString();
                                txtDiaChi.Text = dr["DIACHI"].ToString();
                                cboLoaiKH.SelectedItem = dr["LOAIKH"].ToString();

                                if (dr["NGAYSINH"] != DBNull.Value)
                                    dtpNgaySinh.Value = Convert.ToDateTime(dr["NGAYSINH"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào cơ bản
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Họ tên và SĐT không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    string query = @"
                        UPDATE KHACHHANG 
                        SET HOTEN = @HoTen, 
                            SDT = @SDT, 
                            DIACHI = @DiaChi, 
                            NGAYSINH = @NgaySinh, 
                            LOAIKH = @LoaiKH 
                        WHERE MAKH = @MaKH";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@LoaiKH", cboLoaiKH.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@MaKH", maKH_selected);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // Đóng form và báo về cho Form chính load lại grid
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}