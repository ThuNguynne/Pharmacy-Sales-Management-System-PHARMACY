using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

// ================================================================
// frmHoSoKhachHang.cs  –  FIXED for C# 7.3 compatibility
//
// Xem & tra cứu hồ sơ chi tiết của 1 khách hàng:
//  - Thông tin KHACHHANG (MAKH, HOTEN, SDT, DIACHI, NGAYSINH, LOAIKH)
//  - Nếu ThanhVien: KHACHHANGTHANHVIEN + THETHANHVIEN (không có HANTHE)
//  - Nếu Sỉ       : KHACHHANGSI (công nợ, chiết khấu, hiệu lực HĐ)
//  - Tab: Lịch sử mua hàng (20 hóa đơn gần nhất)
// ================================================================

namespace PharmacyManagement
{
    public partial class frmHoSoKhachHang : Form
    {
        private readonly string _maKH;
        private DataRow _row;

        public frmHoSoKhachHang(string maKH)
        {
            InitializeComponent();
            _maKH = maKH;
        }

        private void frmHoSoKhachHang_Load(object sender, EventArgs e)
        {
            HienThiHoSo();
            HienThiLichSu();
        }

        // ── Hiển thị hồ sơ ──────────────────────────────────────
        private void HienThiHoSo()
        {
            _row = DatabaseHelper.GetHoSoKhachHang(_maKH);
            if (_row == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng: " + _maKH,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); return;
            }

            string loai = _row["LOAIKH"].ToString();

            // ── Thông tin chung ────────────────────────────────────
            lblMaKH.Text = _row["MAKH"].ToString();
            lblHoTen.Text = _row["HOTEN"].ToString();
            lblSDT.Text = _row["SDT"].ToString();
            lblDiaChi.Text = _row["DIACHI"].ToString();

            // Fix C# 7.3 compatibility
            switch (loai)
            {
                case "ThanhVien":
                    lblLoaiKH.Text = "🥉 Thành Viên";
                    break;
                case "Si":
                    lblLoaiKH.Text = "🏭 Khách Sỉ";
                    break;
                default:
                    lblLoaiKH.Text = "👤 Vãng Lai";
                    break;
            }

            if (_row["NGAYSINH"] != DBNull.Value)
                lblNgaySinh.Text = Convert.ToDateTime(_row["NGAYSINH"]).ToString("dd/MM/yyyy");
            else
                lblNgaySinh.Text = "—";

            // ── Màu tiêu đề theo loại ─────────────────────────────
            if (loai == "Si")
            {
                pnlHeader.BackColor = Color.FromArgb(230, 81, 0);
            }
            else
            {
                pnlHeader.BackColor = Color.FromArgb(0, 102, 204);
            }

            // ── Panel thành viên ──────────────────────────────────
            if (loai == "ThanhVien")
            {
                pnlThanhVien.Visible = true;
                pnlSi.Visible = false;

                lblEmail.Text = _row["EMAIL"].ToString();
                lblDiemTichLuy.Text = $"{Convert.ToInt32(_row["DIEMTICHLUY"]):N0} điểm";
                lblHangTV.Text = FormatHangTV(_row["HANGTV"].ToString());

                if (_row["NGAYCAPTHE"] != DBNull.Value)
                    lblNgayCap.Text = Convert.ToDateTime(_row["NGAYCAPTHE"]).ToString("dd/MM/yyyy");
                else
                    lblNgayCap.Text = "—";

                lblMaThe.Text = _row["MATHE"].ToString();

                // Highlight hạng thẻ (Fix C# 7.3)
                string hangTVColor = _row["HANGTV"].ToString();
                if (hangTVColor == "Vang")
                    lblHangTV.ForeColor = Color.FromArgb(218, 165, 32);
                else if (hangTVColor == "Bac")
                    lblHangTV.ForeColor = Color.Silver;
                else
                    lblHangTV.ForeColor = Color.FromArgb(0, 102, 204);
            }
            else if (loai == "Si")
            {
                pnlThanhVien.Visible = false;
                pnlSi.Visible = true;

                lblTenCongTy.Text = _row["TENCONGTY"].ToString();
                lblMST.Text = _row["MST"].ToString();
                lblHanMuc.Text = $"{Convert.ToDouble(_row["HANMUCCONGNO"]):N0} đ";
                lblCongNo.Text = $"{Convert.ToDouble(_row["CONGNOHT"]):N0} đ";
                lblTyLeCK.Text = $"{Convert.ToDouble(_row["TYLECHIETKHAU"]) * 100:F1} %";
                lblThoiHan.Text = $"{Convert.ToInt32(_row["THOIHANTHANHTOAN"])} ngày";
                lblTrangThaiHD.Text = _row["TRANGTHAID"].ToString();
                lblTrangThaiHD.ForeColor = _row["TRANGTHAID"].ToString() == "HieuLuc"
                    ? Color.DarkGreen : Color.Red;

                if (_row["NGAYKYHD"] != DBNull.Value)
                    lblNgayKyHD.Text = Convert.ToDateTime(_row["NGAYKYHD"]).ToString("dd/MM/yyyy");
                if (_row["NGAYHETHAN"] != DBNull.Value)
                    lblNgayHH.Text = Convert.ToDateTime(_row["NGAYHETHAN"]).ToString("dd/MM/yyyy");
            }
            else // VangLai
            {
                pnlThanhVien.Visible = false;
                pnlSi.Visible = false;
            }
        }

        // ── Lịch sử mua hàng ─────────────────────────────────────
        private void HienThiLichSu()
        {
            var dt = DatabaseHelper.GetLichSuMuaHang(_maKH, 20);
            dgvLichSu.DataSource = dt;

            if (dgvLichSu.Columns.Contains("MAHD"))
            {
                dgvLichSu.Columns["MAHD"].HeaderText = "Số HĐ";
                dgvLichSu.Columns["MAHD"].Width = 90;
                dgvLichSu.Columns["NGAYLAP"].HeaderText = "Ngày lập";
                dgvLichSu.Columns["NGAYLAP"].Width = 120;
                dgvLichSu.Columns["NGAYLAP"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvLichSu.Columns["TONGTIEN"].HeaderText = "Tổng tiền (đ)";
                dgvLichSu.Columns["TONGTIEN"].Width = 120;
                dgvLichSu.Columns["TONGTIEN"].DefaultCellStyle.Format = "N0";
                dgvLichSu.Columns["TONGTIEN"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                dgvLichSu.Columns["LOAIHD"].HeaderText = "Loại";
                dgvLichSu.Columns["LOAIHD"].Width = 70;
                dgvLichSu.Columns["TRANGTHAID"].HeaderText = "Trạng thái";
                dgvLichSu.Columns["TRANGTHAID"].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
            }

            lblTongHoaDon.Text = $"Có {dt.Rows.Count} hóa đơn gần đây";
        }

        private void btnDong_Click(object sender, EventArgs e) => this.Close();

        // ── Xem chi tiết HĐ khi double-click ────────────────────
        private void dgvLichSu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string maHD = dgvLichSu.Rows[e.RowIndex].Cells["MAHD"].Value?.ToString();
            if (string.IsNullOrEmpty(maHD)) return;

            // Mở frmChiTietDonHang nếu muốn mở rộng — hiện tại hiển thị nhanh
            var dt = DatabaseHelper.GetChiTietHoaDon(maHD);
            string thongTin = $"Chi tiết Hóa đơn: {maHD}\n" + new string('─', 40);
            foreach (DataRow r in dt.Rows)
                thongTin += $"\n  {r["TENTHUOC"],-30} x{r["SOLUONG"],4}  {Convert.ToDouble(r["DONGIABAN"]):N0} đ";
            MessageBox.Show(thongTin, "Chi tiết HĐ", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ── Helper ──────────────────────────────────────────────
        private string FormatHangTV(string hang)
        {
            switch (hang)
            {
                case "Vang":
                    return "🥇 Vàng (VIP)";
                case "Bac":
                    return "🥈 Bạc";
                default:
                    return "🥉 Đồng";
            }
        }
    }
}