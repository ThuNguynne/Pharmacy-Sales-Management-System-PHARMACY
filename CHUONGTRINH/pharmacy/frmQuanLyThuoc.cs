using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmQuanLyThuoc : Form
    {
        private readonly string connectionString = "Server=localhost;Database=QLNhaThuocPharmacy;Trusted_Connection=True;";

        // Quản lý trạng thái: Adding (Thêm mới), Viewing (Xem chi tiết), Editing (Sửa)
        private enum Mode { Adding, Viewing, Editing }
        private Mode currentMode = Mode.Adding;

        public frmQuanLyThuoc()
        {
            InitializeComponent();
        }

        private void frmQuanLyThuoc_Load(object sender, EventArgs e)
        {
            LoadComboBoxDanhMuc();
            LoadDataThuoc();
            SwitchMode(Mode.Adding);
        }

        // Hàm chuyển đổi trạng thái giao diện
        private void SwitchMode(Mode mode)
        {
            currentMode = mode;
            switch (mode)
            {
                case Mode.Adding:
                    ClearFields();
                    EnableFields(true);
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnSua.Text = "SỬA";
                    btnXoa.Enabled = false;
                    break;
                case Mode.Viewing:
                    EnableFields(false);
                    btnThem.Enabled = false;
                    btnSua.Enabled = true;
                    btnSua.Text = "SỬA";
                    btnXoa.Enabled = true;
                    break;
                case Mode.Editing:
                    EnableFields(true);
                    txtMaThuoc.ReadOnly = true; // Không cho sửa khóa chính
                    btnThem.Enabled = false;
                    btnSua.Enabled = true;
                    btnSua.Text = "LƯU";
                    btnXoa.Enabled = false;
                    break;
            }
        }

        private void EnableFields(bool status)
        {
            txtMaThuoc.ReadOnly = !status;
            txtTenThuoc.ReadOnly = !status;
            txtHoatChat.ReadOnly = !status;
            txtDangBaoChe.ReadOnly = !status;
            txtGiaBan.ReadOnly = !status;
            cmbDanhMuc.Enabled = status;
            chkKeDon.Enabled = status;
        }

        private void ClearFields()
        {
            txtMaThuoc.Clear();
            txtTenThuoc.Clear();
            txtHoatChat.Clear();
            txtDangBaoChe.Clear();
            txtGiaBan.Clear();
            chkKeDon.Checked = false;
        }

        private void LoadComboBoxDanhMuc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MADANHMUC, TENDANHMUC FROM DANHMUC", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbDanhMuc.DataSource = dt;
                    cmbDanhMuc.DisplayMember = "TENDANHMUC";
                    cmbDanhMuc.ValueMember = "MADANHMUC";
                }
            }
            catch { }
        }

        private void LoadDataThuoc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MATHUOC, TENTHUOC, HOATCHAT, DANGBAOCHE, GIABANLRE, MADANHMUC, ISKEDON FROM THUOC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvThuoc.DataSource = dt;
                }
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaThuoc.Text)) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO THUOC (MATHUOC, TENTHUOC, HOATCHAT, DANGBAOCHE, GIABANLRE, MADANHMUC, ISKEDON) " +
                                   "VALUES (@Ma, @Ten, @HoatChat, @DangBaoChe, @Gia, @MaDM, @IsKeDon)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ma", txtMaThuoc.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtTenThuoc.Text);
                    cmd.Parameters.AddWithValue("@HoatChat", txtHoatChat.Text);
                    cmd.Parameters.AddWithValue("@DangBaoChe", txtDangBaoChe.Text);
                    cmd.Parameters.AddWithValue("@Gia", double.Parse(txtGiaBan.Text));
                    cmd.Parameters.AddWithValue("@MaDM", cmbDanhMuc.SelectedValue);
                    cmd.Parameters.AddWithValue("@IsKeDon", chkKeDon.Checked ? 1 : 0);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thuốc thành công!");
                    LoadDataThuoc();
                    SwitchMode(Mode.Adding);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentMode == Mode.Viewing)
            {
                SwitchMode(Mode.Editing);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE THUOC SET TENTHUOC=@Ten, HOATCHAT=@HoatChat, DANGBAOCHE=@DangBaoChe, " +
                                       "GIABANLRE=@Gia, MADANHMUC=@MaDM, ISKEDON=@IsKeDon WHERE MATHUOC=@Ma";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Ma", txtMaThuoc.Text);
                        cmd.Parameters.AddWithValue("@Ten", txtTenThuoc.Text);
                        cmd.Parameters.AddWithValue("@HoatChat", txtHoatChat.Text);
                        cmd.Parameters.AddWithValue("@DangBaoChe", txtDangBaoChe.Text);
                        cmd.Parameters.AddWithValue("@Gia", double.Parse(txtGiaBan.Text));
                        cmd.Parameters.AddWithValue("@MaDM", cmbDanhMuc.SelectedValue);
                        cmd.Parameters.AddWithValue("@IsKeDon", chkKeDon.Checked ? 1 : 0);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thành công!");
                        LoadDataThuoc();
                        SwitchMode(Mode.Viewing);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa thuốc này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("DELETE FROM THUOC WHERE MATHUOC=@Ma", conn);
                        cmd.Parameters.AddWithValue("@Ma", txtMaThuoc.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        LoadDataThuoc();
                        SwitchMode(Mode.Adding);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SwitchMode(Mode.Adding);
        }

        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThuoc.Rows[e.RowIndex];
                txtMaThuoc.Text = row.Cells["MATHUOC"].Value?.ToString();
                txtTenThuoc.Text = row.Cells["TENTHUOC"].Value?.ToString();
                txtHoatChat.Text = row.Cells["HOATCHAT"].Value?.ToString();
                txtDangBaoChe.Text = row.Cells["DANGBAOCHE"].Value?.ToString();
                txtGiaBan.Text = row.Cells["GIABANLRE"].Value?.ToString();
                cmbDanhMuc.SelectedValue = row.Cells["MADANHMUC"].Value?.ToString();
                chkKeDon.Checked = Convert.ToBoolean(row.Cells["ISKEDON"].Value);

                SwitchMode(Mode.Viewing); // Chuyển sang chế độ XEM CHI TIẾT
            }
        }
    }
}