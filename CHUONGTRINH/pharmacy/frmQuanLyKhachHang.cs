using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmQuanLyKhachHang : Form
    {
        private DataTable _dt;
        // Chuỗi kết nối dùng chung cho các thao tác trực tiếp trên Form
        private const string STR_CONN = @"Data Source=DESKTOP-Q1UORLL\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";

        public frmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            cboLoaiKH.SelectedIndex = 0;   // Mặc định chọn "Tất cả"
            LoadDuLieu("");
        }

        private void LoadDuLieu(string loaiKH)
        {
            _dt = DatabaseHelper.GetDanhSachKhachHang(loaiKH); // Sử dụng hàm từ Helper có sẵn
            BindGrid(_dt);
        }

        private void BindGrid(DataTable dt)
        {
            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = dt;

            // Thiết lập độ rộng và tên cột hiển thị để không bị đè chữ
            HideOrRename("MAKH", "Mã KH", 80);
            HideOrRename("HOTEN", "Họ và Tên", 180);
            HideOrRename("SDT", "Số Điện Thoại", 110);
            HideOrRename("LOAIKH", "Loại", 90);
            HideOrRename("DIEMTICHLUY", "Điểm tích lũy", 100);
            HideOrRename("HANGTV", "Hạng Thẻ", 90);
            HideOrRename("TENCONGTY", "Tên Công Ty/Phòng Khám", 200, fill: true);
            HideOrRename("CONGNOHT", "Công nợ hiện tại", 120);

            // Ẩn các cột dữ liệu kỹ thuật không cần thiết cho người dùng
            string[] hideCols = { "DIACHI", "NGAYSINH", "EMAIL", "TDN_TV", "TRANGTHAI_TV",
                                 "NGAYCAPTHE", "MST_SI", "TRANGTHAI_SI", "TYLECHIETKHAU" };
            foreach (var col in hideCols)
                if (dgvKhachHang.Columns.Contains(col)) dgvKhachHang.Columns[col].Visible = false;

            lblSoLuong.Text = $"Tổng: {dt.Rows.Count} khách hàng";
        }

        private void HideOrRename(string colName, string header, int width, bool fill = false)
        {
            if (!dgvKhachHang.Columns.Contains(colName)) return;
            var col = dgvKhachHang.Columns[colName];
            col.HeaderText = header;
            col.Width = width;
            col.MinimumWidth = width;
            if (fill) col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(kw))
            {
                string loai = cboLoaiKH.SelectedIndex > 0 ? cboLoaiKH.SelectedItem.ToString() : "";
                LoadDuLieu(loai);
            }
            else
            {
                BindGrid(DatabaseHelper.TimKiemKhachHang(kw)); //
            }
        }

        private void cboLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loai = "";
            switch (cboLoaiKH.SelectedIndex)
            {
                case 1: loai = "ThanhVien"; break;
                case 2: loai = "Si"; break;
                case 3: loai = "VangLai"; break;
            }
            LoadDuLieu(loai);
        }

        // ── CHỨC NĂNG SỬA ──────────────────────────────────────────
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) return;
            string maKH = dgvKhachHang.CurrentRow.Cells["MAKH"].Value.ToString();

            // Gọi form sửa đã có sẵn
            using (var frm = new frmSuaKhachHang(maKH))
            {
                if (frm.ShowDialog() == DialogResult.OK) LoadDuLieu("");
            }
        }

        // ── CHỨC NĂNG XÓA ──────────────────────────────────────────
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = dgvKhachHang.CurrentRow.Cells["MAKH"].Value.ToString();
            string tenKH = dgvKhachHang.CurrentRow.Cells["HOTEN"].Value.ToString();
            string loaiKH = dgvKhachHang.CurrentRow.Cells["LOAIKH"].Value.ToString();

            // 1. Kiểm tra nghiệp vụ: Nếu đã có hóa đơn hoặc đơn hàng thì không được xóa
            if (CheckHasTransactions(maKH))
            {
                MessageBox.Show($"Khách hàng '{tenKH}' đã có phát sinh giao dịch (Hóa đơn/Đơn hàng). Không thể xóa để đảm bảo toàn vẹn dữ liệu!",
                    "Từ chối xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // 2. Xác nhận xóa
            var dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{tenKH}' và các dữ liệu liên quan không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (ExecuteDeleteCustomer(maKH, loaiKH))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDuLieu("");
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu. Vui lòng kiểm tra lại kết nối cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckHasTransactions(string maKH)
        {
            using (SqlConnection conn = new SqlConnection(STR_CONN))
            {
                conn.Open();
                // Kiểm tra đồng thời trong các bảng nghiệp vụ chính
                string sql = @"SELECT 
                    (SELECT COUNT(*) FROM HOADON WHERE MAKH = @m) + 
                    (SELECT COUNT(*) FROM DONHANG WHERE MAKH = @m) +
                    (SELECT COUNT(*) FROM PHIEUDATTRUOC WHERE MAKH = @m)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@m", maKH);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool ExecuteDeleteCustomer(string maKH, string loaiKH)
        {
            using (SqlConnection conn = new SqlConnection(STR_CONN))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Xóa dữ liệu râu ria trước (Giỏ hàng)
                    string sqlGH = "DELETE FROM CHITIETGIOHANG WHERE MAGIOHANG IN (SELECT MAGIOHANG FROM GIOHANG WHERE MAKH=@m); " +
                                 "DELETE FROM GIOHANG WHERE MAKH=@m;";
                    new SqlCommand(sqlGH, conn, trans).Parameters.AddWithValue("@m", maKH);

                    // Xóa thẻ và thông tin loại khách tương ứng
                    if (loaiKH == "ThanhVien")
                    {
                        new SqlCommand("DELETE FROM THETHANHVIEN WHERE MAKH=@m", conn, trans).Parameters.AddWithValue("@m", maKH);
                        new SqlCommand("DELETE FROM KHACHHANGTHANHVIEN WHERE MAKH=@m", conn, trans).Parameters.AddWithValue("@m", maKH);
                    }
                    else if (loaiKH == "Si")
                        new SqlCommand("DELETE FROM KHACHHANGSI WHERE MAKH=@m", conn, trans).Parameters.AddWithValue("@m", maKH);
                    else
                        new SqlCommand("DELETE FROM KHACHHANGVANGLAI WHERE MAKH=@m", conn, trans).Parameters.AddWithValue("@m", maKH);

                    // Cuối cùng mới xóa khách hàng
                    SqlCommand cmdMain = new SqlCommand("DELETE FROM KHACHHANG WHERE MAKH=@m", conn, trans);
                    cmdMain.Parameters.AddWithValue("@m", maKH);
                    cmdMain.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        private void dgvKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnSua_Click(null, null);
        }

        private void dgvKhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvKhachHang.Columns[e.ColumnIndex].Name != "LOAIKH") return;
            string val = e.Value?.ToString();
            if (val == "ThanhVien") e.CellStyle.ForeColor = Color.Blue;
            else if (val == "Si") e.CellStyle.ForeColor = Color.OrangeRed;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLoaiKH.SelectedIndex = 0;
            LoadDuLieu("");
        }

        private void btnDong_Click(object sender, EventArgs e) => this.Close();

        private void btnDangKyTV_Click(object sender, EventArgs e) => new frmDangKyThanhVien().ShowDialog();

        private void btnDangKySi_Click(object sender, EventArgs e) => new frmDangKyKhachHangSi().ShowDialog();
    }
}