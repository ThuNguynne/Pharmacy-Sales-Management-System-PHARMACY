using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmGiaoHang : Form
    {
        private DataTable dtPhieuGiao;

        public frmGiaoHang()
        {
            InitializeComponent();
        }

        private void frmGiaoHang_Load(object sender, EventArgs e)
        {
            lblNhanVien.Text = "Shipper: " + SessionManager.TenNV;
            LoadPhieuGiaoHang();
        }

        // [FIX] Load từ DB thay vì dùng data giả lập
        private void LoadPhieuGiaoHang()
        {
            try
            {
                dtPhieuGiao = DatabaseHelper.GetPhieuGiaoHangByShipper(SessionManager.MaNV);
                dgvGiaoHang.DataSource = dtPhieuGiao;
                FormatGrid();

                // Thông báo nếu không có phiếu nào đang chờ
                int soPhieuDangGiao = 0;
                foreach (DataRow row in dtPhieuGiao.Rows)
                    if (row["TrangThai"].ToString() == "DangGiao" || row["TrangThai"].ToString() == "ChuaNhan")
                        soPhieuDangGiao++;

                lblSoPhieu.Text = $"Tổng: {dtPhieuGiao.Rows.Count} phiếu  |  Đang giao: {soPhieuDangGiao} phiếu";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách giao hàng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvGiaoHang.Columns.Count == 0) return;

            if (dgvGiaoHang.Columns.Contains("MaPhieuGiao"))
                dgvGiaoHang.Columns["MaPhieuGiao"].HeaderText = "Mã Phiếu";
            if (dgvGiaoHang.Columns.Contains("MaDonHang"))
                dgvGiaoHang.Columns["MaDonHang"].HeaderText = "Mã Đơn";
            if (dgvGiaoHang.Columns.Contains("TenKhach"))
            {
                dgvGiaoHang.Columns["TenKhach"].HeaderText = "Khách Hàng";
                dgvGiaoHang.Columns["TenKhach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvGiaoHang.Columns.Contains("DiaChi"))
            {
                dgvGiaoHang.Columns["DiaChi"].HeaderText = "Địa Chỉ Giao";
                dgvGiaoHang.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvGiaoHang.Columns.Contains("TienThuHo"))
            {
                dgvGiaoHang.Columns["TienThuHo"].HeaderText = "Cần Thu (COD)";
                dgvGiaoHang.Columns["TienThuHo"].DefaultCellStyle.Format = "N0";
                dgvGiaoHang.Columns["TienThuHo"].Width = 120;
                dgvGiaoHang.Columns["TienThuHo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            if (dgvGiaoHang.Columns.Contains("TrangThai"))
            {
                dgvGiaoHang.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgvGiaoHang.Columns["TrangThai"].Width = 110;
                dgvGiaoHang.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            if (dgvGiaoHang.Columns.Contains("NgayGiao"))
            {
                dgvGiaoHang.Columns["NgayGiao"].HeaderText = "Ngày Giao";
                dgvGiaoHang.Columns["NgayGiao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvGiaoHang.Columns["NgayGiao"].Width = 130;
                dgvGiaoHang.Columns["NgayGiao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            // Tô màu dòng theo trạng thái
            dgvGiaoHang.CellFormatting += DgvGiaoHang_CellFormatting;
        }

        private void DgvGiaoHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGiaoHang.Columns[e.ColumnIndex].Name != "TrangThai" || e.Value == null) return;

            switch (e.Value.ToString())
            {
                case "DangGiao":
                    e.Value = "Đang giao";
                    e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                    e.CellStyle.Font = new Font(dgvGiaoHang.Font, FontStyle.Bold);
                    break;
                case "ChuaNhan":
                    e.Value = "Chưa nhận";
                    e.CellStyle.ForeColor = Color.DarkOrange;
                    break;
                case "DaGiao":
                    e.Value = "Đã giao ✓";
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    break;
                case "ThatBai":
                    e.Value = "Thất bại ✗";
                    e.CellStyle.ForeColor = Color.Gray;
                    break;
            }
        }

        // [FIX] Thực hiện cập nhật giao thành công vào DB
        private void btnThanhCong_Click(object sender, EventArgs e)
        {
            if (dgvGiaoHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu giao hàng cần cập nhật!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string trangThai = dgvGiaoHang.SelectedRows[0].Cells["TrangThai"].Value?.ToString();
            if (trangThai == "DaGiao" || trangThai == "ThatBai")
            {
                MessageBox.Show("Phiếu này đã được xử lý xong, không thể cập nhật lại!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPG = dgvGiaoHang.SelectedRows[0].Cells["MaPhieuGiao"].Value.ToString();
            string tenKhach = dgvGiaoHang.SelectedRows[0].Cells["TenKhach"].Value?.ToString();
            decimal cod = Convert.ToDecimal(dgvGiaoHang.SelectedRows[0].Cells["TienThuHo"].Value ?? 0);

            string codText = cod > 0 ? $"\nSố tiền COD cần thu: {cod:N0} VNĐ" : "\n(Đã thanh toán online, không cần thu tiền mặt)";

            DialogResult dr = MessageBox.Show(
                $"Xác nhận GIAO THÀNH CÔNG phiếu [{maPG}]?\n" +
                $"Khách hàng: {tenKhach}{codText}\n\n" +
                "Hệ thống sẽ cập nhật trạng thái và ghi nhận kết quả.",
                "Xác nhận giao thành công",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            bool ok = DatabaseHelper.CapNhatKetQuaGiaoHang(maPG, thanhCong: true);
            if (ok)
            {
                MessageBox.Show("Cập nhật thành công! Đơn hàng đã chuyển sang trạng thái Hoàn Thành.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPhieuGiaoHang();
            }
        }

        // [FIX] Thực hiện cập nhật giao thất bại vào DB với lý do
        private void btnThatBai_Click(object sender, EventArgs e)
        {
            if (dgvGiaoHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu giao hàng cần cập nhật!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string trangThai = dgvGiaoHang.SelectedRows[0].Cells["TrangThai"].Value?.ToString();
            if (trangThai == "DaGiao" || trangThai == "ThatBai")
            {
                MessageBox.Show("Phiếu này đã được xử lý xong, không thể cập nhật lại!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPG = dgvGiaoHang.SelectedRows[0].Cells["MaPhieuGiao"].Value.ToString();
            string tenKhach = dgvGiaoHang.SelectedRows[0].Cells["TenKhach"].Value?.ToString();

            // Yêu cầu nhập lý do thất bại
            string lyDo = txtLyDo.Text.Trim();
            if (string.IsNullOrEmpty(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do giao thất bại vào ô bên dưới trước khi xác nhận!",
                    "Cần nhập lý do", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLyDo.Focus();
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Báo cáo GIAO THẤT BẠI phiếu [{maPG}]?\n" +
                $"Khách hàng : {tenKhach}\n" +
                $"Lý do        : {lyDo}\n\n" +
                "Đơn hàng sẽ bị HỦY và hàng hoàn lại kho.",
                "Xác nhận giao thất bại",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) return;

            bool ok = DatabaseHelper.CapNhatKetQuaGiaoHang(maPG, thanhCong: false, lyDoThatBai: lyDo);
            if (ok)
            {
                MessageBox.Show("Đã ghi nhận giao thất bại. Đơn hàng chuyển sang trạng thái Đã Hủy.",
                    "Đã cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLyDo.Clear();
                LoadPhieuGiaoHang();
            }
        }

        // Nút làm mới danh sách
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadPhieuGiaoHang();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}