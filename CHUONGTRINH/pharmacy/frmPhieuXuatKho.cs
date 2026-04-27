using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PharmacyManagement
{
    public partial class frmPhieuXuatKho : Form
    {
        private DataTable dtChiTietXuat;
        private decimal tongTienXuat = 0;

        private const string CONNECTION_STRING = "Data Source=DESKTOP-Q1UORLL\\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";

        public frmPhieuXuatKho()
        {
            InitializeComponent();
            InitBangChiTiet();
        }

        // Bổ sung sự kiện Form Load
        private void frmPhieuXuatKho_Load(object sender, EventArgs e)
        {
            if (cboLyDoXuat.Items.Count > 0)
            {
                cboLyDoXuat.SelectedIndex = 0; // Chọn mặc định item đầu tiên
            }
        }

        private void InitBangChiTiet()
        {
            dtChiTietXuat = new DataTable();
            dtChiTietXuat.Columns.Add("MaThuoc", typeof(string));
            dtChiTietXuat.Columns.Add("TenThuoc", typeof(string));
            dtChiTietXuat.Columns.Add("MaLo", typeof(string));
            dtChiTietXuat.Columns.Add("SoLuong", typeof(int));
            dtChiTietXuat.Columns.Add("DonGia", typeof(decimal));
            dtChiTietXuat.Columns.Add("ThanhTien", typeof(decimal));
            dgvChiTietXuat.DataSource = dtChiTietXuat;
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            string maThuoc = txtMaThuoc.Text.Trim();
            int slXuat = (int)numSoLuong.Value;

            DataRow loHang = TimLoHangTon(maThuoc, slXuat);

            if (loHang == null)
            {
                MessageBox.Show("Không tìm thấy lô hàng nào đủ số lượng tồn cho thuốc này!", "Hết hàng");
                return;
            }

            dtChiTietXuat.Rows.Add(
                maThuoc,
                loHang["TENTHUOC"],
                loHang["MALO"],
                slXuat,
                numDonGia.Value,
                slXuat * numDonGia.Value
            );

            TinhTongTien();
            ClearInput();
        }

        private void TinhTongTien()
        {
            tongTienXuat = 0;
            foreach (DataRow row in dtChiTietXuat.Rows)
            {
                tongTienXuat += Convert.ToDecimal(row["ThanhTien"]);
            }
            lblTongTien.Text = tongTienXuat.ToString("N0") + " VNĐ";
        }

        private void ClearInput()
        {
            txtMaThuoc.Clear();
            numSoLuong.Value = 1;
            numDonGia.Value = 0;
            txtMaThuoc.Focus();
        }

        private DataRow TimLoHangTon(string maThuoc, int slXuat)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                string sql = @"SELECT TOP 1 L.MALO, T.TENTHUOC, L.SOLUONGTON 
                               FROM LOHANG L JOIN THUOC T ON L.MATHUOC = T.MATHUOC
                               WHERE L.MATHUOC = @ma AND L.SOLUONGTON >= @sl 
                               AND L.HANSD >= GETDATE() AND L.TRANGTHAI = N'HoatDong'
                               ORDER BY L.HANSD ASC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@ma", maThuoc);
                da.SelectCommand.Parameters.AddWithValue("@sl", slXuat);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (dtChiTietXuat.Rows.Count == 0) return;

            if (!SessionManager.IsNhanVien)
            {
                MessageBox.Show("Vui lòng đăng nhập với tư cách nhân viên để xuất kho!", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string maPX = "PX" + DateTime.Now.Ticks.ToString().Substring(10);

                    string sqlPX = @"INSERT INTO PHIEUXUAT (MAPHIEUXUAT, NGAYXUAT, LYDO, TRANGTHAI, LOAIOXUAT, MANV, MACN) 
                                     VALUES (@ma, GETDATE(), @lydo, N'ChoDuyet', N'HangHong', @maNV, 'CN001')";
                    SqlCommand cmdPX = new SqlCommand(sqlPX, conn, trans);
                    cmdPX.Parameters.AddWithValue("@ma", maPX);
                    cmdPX.Parameters.AddWithValue("@lydo", cboLyDoXuat.Text);
                    cmdPX.Parameters.AddWithValue("@maNV", SessionManager.MaNV);
                    cmdPX.ExecuteNonQuery();

                    foreach (DataRow row in dtChiTietXuat.Rows)
                    {
                        string sqlCT = "INSERT INTO CHITIETXUAT (MAPHIEUXUAT, MALO, SOLUONGXUAT, TINTRANGTHUOC) VALUES (@maPX, @maL, @sl, N'ConTot')";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@maPX", maPX);
                        cmdCT.Parameters.AddWithValue("@maL", row["MaLo"]);
                        cmdCT.Parameters.AddWithValue("@sl", row["SoLuong"]);
                        cmdCT.ExecuteNonQuery();
                    }

                    string sqlUpdate = "UPDATE PHIEUXUAT SET TRANGTHAI = N'HoanThanh' WHERE MAPHIEUXUAT = @ma";
                    SqlCommand cmdUp = new SqlCommand(sqlUpdate, conn, trans);
                    cmdUp.Parameters.AddWithValue("@ma", maPX);
                    cmdUp.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Xuất kho thành công! Hệ thống đã tự động trừ số lượng tồn.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // Bổ sung hàm đóng Form
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}