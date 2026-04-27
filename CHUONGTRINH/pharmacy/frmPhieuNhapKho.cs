using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PharmacyManagement
{
    public partial class frmPhieuNhapKho : Form
    {
        private DataTable dtChiTietNhap;
        private decimal tongTienNhap = 0;

        private const string CONNECTION_STRING = "Data Source=DESKTOP-Q1UORLL\\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";

        public frmPhieuNhapKho()
        {
            InitializeComponent();
            InitBangChiTiet();
            LoadNhaCungCap();
        }

        private void InitBangChiTiet()
        {
            dtChiTietNhap = new DataTable();
            dtChiTietNhap.Columns.Add("MaThuoc", typeof(string));
            dtChiTietNhap.Columns.Add("TenThuoc", typeof(string));
            dtChiTietNhap.Columns.Add("SoLo", typeof(string));
            dtChiTietNhap.Columns.Add("SoLuong", typeof(int));
            dtChiTietNhap.Columns.Add("GiaNhap", typeof(decimal));
            dtChiTietNhap.Columns.Add("ThanhTien", typeof(decimal));
            dtChiTietNhap.Columns.Add("NgaySX", typeof(DateTime));
            dtChiTietNhap.Columns.Add("HanSuDung", typeof(DateTime));

            dgvChiTietNhap.DataSource = dtChiTietNhap;
        }

        private void LoadNhaCungCap()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    string sql = "SELECT MANCC, TENNCC FROM NHACUNGCAP WHERE TRANGTHAI = N'HoatDong'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboNhaCungCap.DataSource = dt;
                    cboNhaCungCap.DisplayMember = "TENNCC";
                    cboNhaCungCap.ValueMember = "MANCC";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải NCC: " + ex.Message); }
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            string maThuoc = txtMaThuoc.Text.Trim();
            int sl = (int)numSoLuong.Value;
            decimal giaNhap = numGiaNhap.Value;
            DateTime hsd = dtpHanSuDung.Value;

            if (string.IsNullOrEmpty(maThuoc) || sl <= 0 || giaNhap <= 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Cảnh báo");
                return;
            }

            string tenThuoc = GetTenThuoc(maThuoc);
            if (string.IsNullOrEmpty(tenThuoc))
            {
                MessageBox.Show("Mã thuốc không tồn tại trong hệ thống!", "Lỗi");
                return;
            }

            string soLo = "LO" + DateTime.Now.ToString("yyyyMMddHHmm");
            dtChiTietNhap.Rows.Add(maThuoc, tenThuoc, soLo, sl, giaNhap, sl * giaNhap, DateTime.Now, hsd);

            TinhTongTien();
            ClearInput();
        }

        private void TinhTongTien()
        {
            tongTienNhap = 0;
            foreach (DataRow row in dtChiTietNhap.Rows)
            {
                tongTienNhap += Convert.ToDecimal(row["ThanhTien"]);
            }
            lblTongTien.Text = tongTienNhap.ToString("N0") + " VNĐ";
        }

        private void ClearInput()
        {
            txtMaThuoc.Clear();
            numSoLuong.Value = 1;
            numGiaNhap.Value = 0;
            dtpHanSuDung.Value = DateTime.Now.AddYears(1);
            txtMaThuoc.Focus();
        }

        private string GetTenThuoc(string maThuoc)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                string sql = "SELECT TENTHUOC FROM THUOC WHERE MATHUOC = @ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maThuoc);
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (dtChiTietNhap.Rows.Count == 0 || cboNhaCungCap.SelectedValue == null) return;

            if (!SessionManager.IsNhanVien)
            {
                MessageBox.Show("Vui lòng đăng nhập với tư cách nhân viên để thực hiện thao tác này!", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string maPN = "PN" + DateTime.Now.Ticks.ToString().Substring(10);

                    string sqlPN = @"INSERT INTO PHIEUNHAP (MAPHIEUNHAP, NGAYNHAP, TONGTIEN, TRANGTHAI, LOAINHAP, MANV, MANCC, MACN) 
                                     VALUES (@ma, GETDATE(), @tong, N'ChoDuyet', N'NhapNCC', @maNV, @mancc, 'CN001')";

                    SqlCommand cmdPN = new SqlCommand(sqlPN, conn, trans);
                    cmdPN.Parameters.AddWithValue("@ma", maPN);
                    cmdPN.Parameters.AddWithValue("@tong", tongTienNhap);
                    cmdPN.Parameters.AddWithValue("@maNV", SessionManager.MaNV);
                    cmdPN.Parameters.AddWithValue("@mancc", cboNhaCungCap.SelectedValue);
                    cmdPN.ExecuteNonQuery();

                    foreach (DataRow row in dtChiTietNhap.Rows)
                    {
                        string sqlCT = @"INSERT INTO CHITIETNHAP (MAPHIEUNHAP, MATHUOC, SOLO, NGAYSX, HANSD, SOLUONGNHAP, DONGIANHAP)
                                         VALUES (@maPN, @maT, @solo, @nsx, @hsd, @sl, @gia)";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@maPN", maPN);
                        cmdCT.Parameters.AddWithValue("@maT", row["MaThuoc"]);
                        cmdCT.Parameters.AddWithValue("@solo", row["SoLo"]);
                        cmdCT.Parameters.AddWithValue("@nsx", row["NgaySX"]);
                        cmdCT.Parameters.AddWithValue("@hsd", row["HanSuDung"]);
                        cmdCT.Parameters.AddWithValue("@sl", row["SoLuong"]);
                        cmdCT.Parameters.AddWithValue("@gia", row["GiaNhap"]);
                        cmdCT.ExecuteNonQuery();
                    }

                    string sqlUpdate = "UPDATE PHIEUNHAP SET TRANGTHAI = N'HoanThanh' WHERE MAPHIEUNHAP = @ma";
                    new SqlCommand(sqlUpdate, conn, trans).Parameters.AddWithValue("@ma", maPN);

                    trans.Commit();
                    MessageBox.Show("Nhập kho thành công! Tồn kho đã tự động cập nhật.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi lưu phiếu: " + ex.Message);
                }
            }
        }

       
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}