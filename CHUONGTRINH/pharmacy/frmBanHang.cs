using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmBanHang : Form
    {
        private const string CONNECTION_STRING = @"Data Source=DESKTOP-Q1UORLL\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";

        private DataTable dtGioHang;
        private decimal tongTien = 0;
        private string _lastMaHD = "";

        public frmBanHang()
        {
            InitializeComponent();
            InitGioHang();
        }

        private void InitGioHang()
        {
            dtGioHang = new DataTable();
            dtGioHang.Columns.Add("MaThuoc", typeof(string));
            dtGioHang.Columns.Add("TenThuoc", typeof(string));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal));
            dtGioHang.Columns.Add("IsKeDon", typeof(bool));

            dgvGioHang.DataSource = dtGioHang;
            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            if (dgvGioHang.Columns.Contains("IsKeDon"))
                dgvGioHang.Columns["IsKeDon"].Visible = false;

            btnDoiTraHoaDon.Enabled = false;
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            string maThuoc = txtMaThuoc.Text.Trim();
            int soLuongMua = (int)numSoLuong.Value;

            if (string.IsNullOrEmpty(maThuoc))
            {
                MessageBox.Show("Vui lòng nhập mã thuốc!"); return;
            }

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT T.TENTHUOC, T.GIABANLRE, T.ISKEDON, 
                                   (SELECT SUM(SOLUONGTON) FROM LOHANG L WHERE L.MATHUOC = T.MATHUOC AND L.HANSD > GETDATE()) as TongTon
                                   FROM THUOC T WHERE T.MATHUOC = @Ma";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma", maThuoc);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string tenThuoc = reader["TENTHUOC"].ToString();
                            decimal giaBan = Convert.ToDecimal(reader["GIABANLRE"]);
                            bool isKeDon = Convert.ToBoolean(reader["ISKEDON"]);
                            int tongTon = reader["TongTon"] != DBNull.Value ? Convert.ToInt32(reader["TongTon"]) : 0;

                            if (tongTon < soLuongMua)
                            {
                                MessageBox.Show($"Không đủ hàng! Tồn kho hiện tại: {tongTon}", "Thông báo");
                                return;
                            }

                            bool found = false;
                            foreach (DataRow row in dtGioHang.Rows)
                            {
                                if (row["MaThuoc"].ToString() == maThuoc)
                                {
                                    row["SoLuong"] = (int)row["SoLuong"] + soLuongMua;
                                    row["ThanhTien"] = (int)row["SoLuong"] * giaBan;
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                                dtGioHang.Rows.Add(maThuoc, tenThuoc, soLuongMua, giaBan, soLuongMua * giaBan, isKeDon);

                            UpdateTongTien();
                        }
                        else { MessageBox.Show("Mã thuốc không tồn tại!"); }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void UpdateTongTien()
        {
            tongTien = 0;
            foreach (DataRow row in dtGioHang.Rows)
                tongTien += Convert.ToDecimal(row["ThanhTien"]);

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!"); return;
            }

            bool hasThuocKeDon = false;
            foreach (DataRow row in dtGioHang.Rows)
            {
                if (Convert.ToBoolean(row["IsKeDon"]))
                {
                    hasThuocKeDon = true;
                    break;
                }
            }

            if (hasThuocKeDon)
            {
                DialogResult dialog = MessageBox.Show(
                    "Giỏ hàng có chứa THUỐC KÊ ĐƠN.\nKhách hàng đã cung cấp đơn thuốc hợp lệ của Bác sĩ chưa?",
                    "Xác nhận Thuốc Kê Đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.No)
                {
                    MessageBox.Show("Dược sĩ từ chối bán do không có đơn thuốc!", "Hủy bán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string maHD = "HD" + DateTime.Now.ToString("yyMMddHHmmss");

                    string sqlHD = @"INSERT INTO HOADON (MAHD, NGAYLAP, TONGTIEN, LOAIHD, TRANGTHAID, MANV, MACN) 
                                   VALUES (@ma, GETDATE(), @tong, N'Le', N'DaThanhToan', 'NV001', 'CN001')";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans);
                    cmdHD.Parameters.AddWithValue("@ma", maHD);
                    cmdHD.Parameters.AddWithValue("@tong", tongTien);
                    cmdHD.ExecuteNonQuery();

                    if (hasThuocKeDon)
                    {
                        string maDT = "DT" + DateTime.Now.ToString("yyMMddHHmmss");
                        string sqlDT = @"INSERT INTO DONTHUOC (MADONTHUOC, NGAYKE, TENBACSSI, SOCCHN, ANHDON, NGAYHETHAN, MAHD) 
                                         VALUES (@madt, GETDATE(), N'Khách mang đơn ngoài', N'N/A', N'N/A', DATEADD(DAY, 5, GETDATE()), @mahd)";
                        SqlCommand cmdDT = new SqlCommand(sqlDT, conn, trans);
                        cmdDT.Parameters.AddWithValue("@madt", maDT);
                        cmdDT.Parameters.AddWithValue("@mahd", maHD);
                        cmdDT.ExecuteNonQuery();
                    }

                    foreach (DataRow row in dtGioHang.Rows)
                    {
                        string sqlGetLo = "SELECT TOP 1 MALO FROM LOHANG WHERE MATHUOC = @mt AND SOLUONGTON >= @sl AND HANSD > GETDATE() ORDER BY HANSD ASC";
                        SqlCommand cmdGetLo = new SqlCommand(sqlGetLo, conn, trans);
                        cmdGetLo.Parameters.AddWithValue("@mt", row["MaThuoc"]);
                        cmdGetLo.Parameters.AddWithValue("@sl", row["SoLuong"]);
                        string maLo = cmdGetLo.ExecuteScalar()?.ToString();

                        if (string.IsNullOrEmpty(maLo)) throw new Exception($"Thuốc {row["TenThuoc"]} đã hết lô hàng phù hợp!");

                        string sqlCT = "INSERT INTO CHITIETHOADON (MAHD, MALO, SOLUONG, DONGIABAN, GIAMGIAITEM) VALUES (@ma, @malo, @sl, @dg, 0)";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@ma", maHD);
                        cmdCT.Parameters.AddWithValue("@malo", maLo);
                        cmdCT.Parameters.AddWithValue("@sl", row["SoLuong"]);
                        cmdCT.Parameters.AddWithValue("@dg", row["DonGia"]);
                        cmdCT.ExecuteNonQuery();

                        string sqlUpdateKho = "UPDATE LOHANG SET SOLUONGTON = SOLUONGTON - @sl WHERE MALO = @malo";
                        SqlCommand cmdUpdate = new SqlCommand(sqlUpdateKho, conn, trans);
                        cmdUpdate.Parameters.AddWithValue("@sl", row["SoLuong"]);
                        cmdUpdate.Parameters.AddWithValue("@malo", maLo);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    trans.Commit();
                    _lastMaHD = maHD;
                    btnDoiTraHoaDon.Enabled = true;

                    MessageBox.Show($"Thanh toán thành công! Mã hóa đơn: {maHD}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtGioHang.Clear();
                    UpdateTongTien();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message);
                }
            }
        }

        private void btnDoiTraHoaDon_Click(object sender, EventArgs e)
        {
            var frm = new frmPhieuDoiTra(_lastMaHD);
            frm.ShowDialog();
        }

        private void btnTimKhach_Click(object sender, EventArgs e)
        {
            string sdt = txtSDTKhach.Text.Trim();
            if (string.IsNullOrEmpty(sdt)) return;

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT HOTEN, LOAIKH FROM KHACHHANG WHERE SDT = @SDT";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SDT", sdt);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            lblTenKhachHang.Text = reader.Read() ? $"{reader["HOTEN"]} ({reader["LOAIKH"]})" : "Khách vãng lai";
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btnDong_Click(object sender, EventArgs e) => this.Close();

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTienKhachDua.Text, out decimal tienKhachDua))
                lblTienThua.Text = (tienKhachDua - tongTien).ToString("N0") + " VNĐ";
            else
                lblTienThua.Text = "0 VNĐ";
        }
    }
}