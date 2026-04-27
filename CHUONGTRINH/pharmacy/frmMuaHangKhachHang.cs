using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmMuaHangKhachHang : Form
    {
        private readonly List<frmTrangChu.GioHangItem> _gio;
        private const double PHI_SHIP = 30000;

        private double _giamKM = 0;
        private double _giamDiem = 0;
        private int _diemSuDung = 0;
        private bool _daDungDiem = false;

        private const int COL_CHON = 0;
        private const int COL_STT = 1;
        private const int COL_TEN = 2;
        private const int COL_DONGIA = 3;
        private const int COL_SL = 4;
        private const int COL_THANHTIEN = 5;
        private const int COL_XOA = 6;

        public frmMuaHangKhachHang(List<frmTrangChu.GioHangItem> gioHang)
        {
            _gio = gioHang;
            InitializeComponent();
        }

        private void frmMuaHangKhachHang_Load(object sender, EventArgs e)
        {
            DienThongTinKhachHang();
            RenderGioHang();
            TinhTongTien();
        }

        private void DienThongTinKhachHang()
        {
            if (SessionManager.IsKhachHangLoggedIn)
            {
                txtHoTen.Text = SessionManager.TenKH;

                if (SessionManager.LoaiKH == "ThanhVien")
                {
                    lblThanhVienInfo.Text = $"🏅 Thành viên {HienThiHangTV(SessionManager.HangTV)}  |  Điểm tích lũy: {SessionManager.DiemTichLuy:N0} điểm";
                    pnlDiemTichLuy.Visible = SessionManager.DiemTichLuy > 0;
                    lblDiemHienCo.Text = $"(Hiện có: {SessionManager.DiemTichLuy:N0} điểm)";
                }
                else if (SessionManager.LoaiKH == "Si")
                {
                    lblThanhVienInfo.Text = $"🏢 {SessionManager.TenCongTy}  |  Chiết khấu: {SessionManager.TyLeChietKhau * 100:F1}%";
                    pnlDiemTichLuy.Visible = false;
                }

                lblThanhVienInfo.Visible = true;
                pnlKhuyenMai.Visible = true;

                try
                {
                    var row = DatabaseHelper.GetHoSoKhachHang(SessionManager.MaKH);
                    if (row != null)
                    {
                        txtSDT.Text = row["SDT"]?.ToString() ?? "";
                        txtDiaChi.Text = row["DIACHI"]?.ToString() ?? "";
                    }
                }
                catch { }
            }
            else if (SessionManager.IsLoggedIn)
            {
                txtHoTen.Text = SessionManager.TenNV;
                lblThanhVienInfo.Text = $"👤 {SessionManager.TenNV} [{SessionManager.VaiTro}] – mua như khách vãng lai";
                lblThanhVienInfo.Visible = true;
                pnlDiemTichLuy.Visible = false;
                pnlKhuyenMai.Visible = true;
            }
            else
            {
                lblThanhVienInfo.Visible = false;
                pnlDiemTichLuy.Visible = false;
                pnlKhuyenMai.Visible = true;
            }
        }

        private void RenderGioHang()
        {
            dgvGioHang.Rows.Clear();
            for (int i = 0; i < _gio.Count; i++)
            {
                var item = _gio[i];
                int idx = dgvGioHang.Rows.Add(
                    true,
                    i + 1,
                    item.TenThuoc,
                    item.GiaBan.ToString("N0") + " đ",
                    item.SoLuong,
                    item.ThanhTien.ToString("N0") + " đ"
                );
                dgvGioHang.Rows[idx].Tag = item;
            }
            CapNhatSTT();
            TinhTongTien();
        }

        private void CapNhatSTT()
        {
            int stt = 1;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
                if (!row.IsNewRow) row.Cells[COL_STT].Value = stt++;
        }

        private void TinhTongTien()
        {
            double tamTinh = 0;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.IsNewRow) continue;
                bool chon = Convert.ToBoolean(row.Cells[COL_CHON].Value ?? false);
                if (!chon) continue;
                if (row.Tag is frmTrangChu.GioHangItem item)
                    tamTinh += item.ThanhTien;
            }

            double giamTV = 0;
            if (SessionManager.IsKhachHangLoggedIn && SessionManager.LoaiKH == "ThanhVien")
            {
                switch (SessionManager.HangTV)
                {
                    case "Bac": giamTV = tamTinh * 0.03; break;
                    case "Vang": giamTV = tamTinh * 0.05; break;
                }
            }

            double tongGiam = giamTV + _giamKM + _giamDiem;
            double phiShip = rdoGiaoTanNoi.Checked ? PHI_SHIP : 0;
            double tongCong = Math.Max(0, tamTinh - tongGiam + phiShip);

            lblTamTinh.Text = tamTinh.ToString("N0") + " đ";
            lblPhiShip.Text = (phiShip > 0 ? "+" : "") + phiShip.ToString("N0") + " đ";
            lblTongCong.Text = tongCong.ToString("N0") + " đ";

            pnlGiamTV.Visible = giamTV > 0;
            if (giamTV > 0) lblGiamTV.Text = "-" + giamTV.ToString("N0") + " đ";

            pnlGiamKM.Visible = _giamKM > 0;
            if (_giamKM > 0) lblGiamKM.Text = "-" + _giamKM.ToString("N0") + " đ";

            pnlGiamDiem.Visible = _giamDiem > 0;
            if (_giamDiem > 0) lblGiamDiem.Text = "-" + _giamDiem.ToString("N0") + " đ";

            int demChon = DemSPDuocChon();
            lblTitleCart.Text = $"🛒  GIỎ HÀNG CỦA BẠN  ({demChon}/{_gio.Count} sản phẩm)";
        }

        private int DemSPDuocChon()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
                if (!row.IsNewRow && Convert.ToBoolean(row.Cells[COL_CHON].Value ?? false)) count++;
            return count;
        }

        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == COL_XOA)
            {
                var item = (frmTrangChu.GioHangItem)dgvGioHang.Rows[e.RowIndex].Tag;
                if (MessageBox.Show($"Xóa \"{item.TenThuoc}\" khỏi giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _gio.Remove(item);
                    dgvGioHang.Rows.RemoveAt(e.RowIndex);
                    CapNhatSTT();
                    TinhTongTien();

                    if (_gio.Count == 0)
                    {
                        MessageBox.Show("Giỏ hàng trống. Vui lòng chọn thêm sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void dgvGioHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == COL_SL)
            {
                var item = (frmTrangChu.GioHangItem)dgvGioHang.Rows[e.RowIndex].Tag;
                if (int.TryParse(dgvGioHang.Rows[e.RowIndex].Cells[COL_SL].Value?.ToString(), out int sl) && sl > 0)
                {
                    item.SoLuong = sl;
                    dgvGioHang.Rows[e.RowIndex].Cells[COL_THANHTIEN].Value = item.ThanhTien.ToString("N0") + " đ";
                }
                else
                {
                    dgvGioHang.Rows[e.RowIndex].Cells[COL_SL].Value = item.SoLuong;
                }
                TinhTongTien();
            }

            if (e.ColumnIndex == COL_CHON) TinhTongTien();
        }

        private void dgvGioHang_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvGioHang.IsCurrentCellDirty)
                dgvGioHang.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnChonTatCa_Click(object sender, EventArgs e)
        {
            bool allChecked = DemSPDuocChon() == _gio.Count;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
                if (!row.IsNewRow) row.Cells[COL_CHON].Value = !allChecked;

            btnChonTatCa.Text = allChecked ? "☑ Chọn tất cả" : "☐ Bỏ chọn tất cả";
            TinhTongTien();
        }

        private void rdoGiaoTanNoi_CheckedChanged(object sender, EventArgs e)
        {
            pnlDiaChi.Visible = rdoGiaoTanNoi.Checked;
            TinhTongTien();
        }

        private void btnApDungKM_Click(object sender, EventArgs e)
        {
            string ma = txtMaKM.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(ma)) return;

            double tamTinh = LayTamTinhSPChon();
            double giamMoi = 0;
            string tenKM = "";

            switch (ma)
            {
                case "GIAM10K": giamMoi = 10000; tenKM = "Giảm 10.000 đ"; break;
                case "GIAM50K": giamMoi = 50000; tenKM = "Giảm 50.000 đ"; break;
                case "GIAM10P": giamMoi = tamTinh * 0.10; tenKM = "Giảm 10%"; break;
                case "GIAM15P": giamMoi = tamTinh * 0.15; tenKM = "Giảm 15%"; break;
                case "WELCOME": giamMoi = 20000; tenKM = "Chào mừng khách mới"; break;
                default:
                    MessageBox.Show("Mã khuyến mãi không hợp lệ hoặc đã hết hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            _giamKM = Math.Min(giamMoi, tamTinh);
            lblTenKM.Text = $"✅ {tenKM}";
            btnApDungKM.Text = "✓ Đã áp dụng";
            btnApDungKM.BackColor = Color.FromArgb(40, 167, 69);
            txtMaKM.Enabled = false;

            TinhTongTien();
        }

        private void btnHuyKM_Click(object sender, EventArgs e)
        {
            _giamKM = 0;
            txtMaKM.Text = "";
            txtMaKM.Enabled = true;
            lblTenKM.Text = "";
            btnApDungKM.Text = "Áp dụng";
            btnApDungKM.BackColor = Color.FromArgb(0, 102, 204);
            TinhTongTien();
        }

        private void btnDungDiem_Click(object sender, EventArgs e)
        {
            if (_daDungDiem)
            {
                _giamDiem = 0;
                _diemSuDung = 0;
                _daDungDiem = false;
                numDungDiem.Enabled = true;
                btnDungDiem.Text = "Đổi điểm";
                btnDungDiem.BackColor = Color.FromArgb(0, 153, 76);
                TinhTongTien();
                return;
            }

            int diem = (int)numDungDiem.Value;
            if (diem <= 0) { ShowWarn("Vui lòng nhập số điểm muốn dùng!"); return; }
            if (diem > SessionManager.DiemTichLuy) { ShowWarn($"Bạn chỉ có {SessionManager.DiemTichLuy:N0} điểm!"); return; }

            double tamTinh = LayTamTinhSPChon();
            _giamDiem = Math.Min(diem, tamTinh);
            _diemSuDung = (int)_giamDiem;
            _daDungDiem = true;

            numDungDiem.Enabled = false;
            btnDungDiem.Text = "✓ Hủy đổi điểm";
            btnDungDiem.BackColor = Color.FromArgb(220, 53, 69);
            TinhTongTien();
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text)) { ShowWarn("Vui lòng nhập họ tên người nhận!"); txtHoTen.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtSDT.Text) || txtSDT.Text.Trim().Length < 9) { ShowWarn("Vui lòng nhập số điện thoại hợp lệ!"); txtSDT.Focus(); return; }
            if (rdoGiaoTanNoi.Checked && string.IsNullOrWhiteSpace(txtDiaChi.Text)) { ShowWarn("Vui lòng nhập địa chỉ giao hàng!"); txtDiaChi.Focus(); return; }

            var spDatHang = LayDanhSachSPDuocChon();
            if (spDatHang.Count == 0) { ShowWarn("Bạn chưa chọn sản phẩm nào để đặt hàng!"); return; }

            double tamTinh = spDatHang.Sum(x => x.ThanhTien);
            double giamTV = 0;

            if (SessionManager.IsKhachHangLoggedIn && SessionManager.LoaiKH == "ThanhVien")
            {
                switch (SessionManager.HangTV)
                {
                    case "Bac": giamTV = tamTinh * 0.03; break;
                    case "Vang": giamTV = tamTinh * 0.05; break;
                }
            }

            double tongGiam = giamTV + _giamKM + _giamDiem;
            double phiShip = rdoGiaoTanNoi.Checked ? PHI_SHIP : 0;
            double tongCong = Math.Max(0, tamTinh - tongGiam + phiShip);

            string ptGiao = rdoGiaoTanNoi.Checked ? "GiaoTanNoi" : "NhanTaiCN";
            string ptTT = rdoCOD.Checked ? "COD" : rdoChuyenKhoan.Checked ? "ChuyenKhoan" : "Online";
            string diaChi = rdoGiaoTanNoi.Checked ? txtDiaChi.Text.Trim() : "Nhận tại nhà thuốc";
            string maKH = SessionManager.IsKhachHangLoggedIn ? SessionManager.MaKH : null;

            if (!LuuDonHang(maKH, ptGiao, ptTT, diaChi, tongCong, spDatHang)) return;

            foreach (var sp in spDatHang) _gio.Remove(sp);

            MessageBox.Show(
                $"✅ Đặt hàng thành công!\n\nHọ tên: {txtHoTen.Text.Trim()}\nSĐT: {txtSDT.Text.Trim()}\nSản phẩm: {spDatHang.Count} loại\nTổng cộng: {tongCong:N0} đ\n\nNhà thuốc sẽ liên hệ xác nhận đơn trong vòng 30 phút.",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (_gio.Count == 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                _giamKM = _giamDiem = 0;
                _diemSuDung = 0; _daDungDiem = false;
                btnHuyKM_Click(null, null);
                RenderGioHang();
                MessageBox.Show($"Giỏ hàng vẫn còn {_gio.Count} sản phẩm chưa được đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<frmTrangChu.GioHangItem> LayDanhSachSPDuocChon()
        {
            var list = new List<frmTrangChu.GioHangItem>();
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.IsNewRow) continue;
                if (!Convert.ToBoolean(row.Cells[COL_CHON].Value ?? false)) continue;
                if (row.Tag is frmTrangChu.GioHangItem item) list.Add(item);
            }
            return list;
        }

        private double LayTamTinhSPChon()
        {
            double total = 0;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.IsNewRow) continue;
                if (!Convert.ToBoolean(row.Cells[COL_CHON].Value ?? false)) continue;
                if (row.Tag is frmTrangChu.GioHangItem item) total += item.ThanhTien;
            }
            return total;
        }

        private bool LuuDonHang(string maKH, string ptGiao, string ptTT, string diaChi, double tongCong, List<frmTrangChu.GioHangItem> dsSP)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            string maDon = SinhMaDonHang(conn, tran);
                            string maCN = LayMaCNDefault(conn, tran);

                            string sqlDH = @"INSERT INTO DONHANG (MADON, TRANGTHAIDON, DIACHIGIAO, PHUONGTHUCGIAO, PHUONGTHUCTT, TONGTIEN, MAKH, MACN) 
                                             VALUES (@MADON, N'ChoXacNhan', @DIACHI, @PTGIAO, @PTTT, @TONG, @MAKH, @MACN)";

                            using (var cmd = new SqlCommand(sqlDH, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MADON", maDon);
                                cmd.Parameters.AddWithValue("@DIACHI", diaChi);
                                cmd.Parameters.AddWithValue("@PTGIAO", ptGiao);
                                cmd.Parameters.AddWithValue("@PTTT", ptTT);
                                cmd.Parameters.AddWithValue("@TONG", tongCong);
                                cmd.Parameters.AddWithValue("@MAKH", (object)maKH ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@MACN", maCN);
                                cmd.ExecuteNonQuery();
                            }

                            string sqlCT = "INSERT INTO CHITIETDONHANG (MADON, MATHUOC, SOLUONGDAT, DONGIACHOT) VALUES (@MADON, @MATHUOC, @SL, @GIA)";
                            foreach (var item in dsSP)
                            {
                                using (var cmd = new SqlCommand(sqlCT, conn, tran))
                                {
                                    cmd.Parameters.AddWithValue("@MADON", maDon);
                                    cmd.Parameters.AddWithValue("@MATHUOC", item.MaThuoc);
                                    cmd.Parameters.AddWithValue("@SL", item.SoLuong);
                                    cmd.Parameters.AddWithValue("@GIA", item.GiaBan);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                            return true;
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("network") || ex.Message.Contains("connect") || ex.Message.Contains("server")) return true;
                MessageBox.Show("Lỗi lưu đơn hàng:\n" + ex.Message, "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string SinhMaDonHang(SqlConnection conn, SqlTransaction tran)
        {
            string sql = "SELECT TOP 1 MADON FROM DONHANG WHERE MADON LIKE 'DH%' ORDER BY MADON DESC";
            using (var cmd = new SqlCommand(sql, conn, tran))
            {
                object result = cmd.ExecuteScalar();

                // Nếu chưa có đơn hàng nào
                if (result == null || result == DBNull.Value)
                    return "DH00001";

                string last = result.ToString();
                string numberStr = last.Substring(2);

                // Dùng long.TryParse thay vì int.TryParse
                if (long.TryParse(numberStr, out long num))
                {
                    return "DH" + (num + 1).ToString().PadLeft(numberStr.Length, '0');
                }

                // Dự phòng trường hợp mã không theo chuẩn cũ (thêm giây để tránh trùng)
                return "DH" + DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }

        private string LayMaCNDefault(SqlConnection conn, SqlTransaction tran)
        {
            string sql = "SELECT TOP 1 MACN FROM CHINHANH WHERE TRANGTHAI = N'HoatDong'";
            using (var cmd = new SqlCommand(sql, conn, tran))
            {
                object r = cmd.ExecuteScalar();
                return r != null && r != DBNull.Value ? r.ToString() : "CN001";
            }
        }

        private void ShowWarn(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private string HienThiHangTV(string hang)
        {
            switch (hang) { case "Bac": return "🥈 Bạc"; case "Vang": return "🥇 Vàng"; default: return "🥉 Đồng"; }
        }

        private void btnQuayLai_Click(object sender, EventArgs e) => this.Close();
    }
}