using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace PharmacyManagement
{
    public partial class frmTrangChu : Form
    {
        // ── Giỏ hàng tạm (truyền sang frmMuaHangKhachHang) ─────────
        public List<GioHangItem> GioHang { get; private set; } = new List<GioHangItem>();

        private string _maDanhMucSelected = "ALL";

        public frmTrangChu()
        {
            InitializeComponent();

            // Di chuyển xử lý giao diện từ file Designer sang đây để tránh lỗi Design
            this.pnlBanner.Paint += (s, pe) =>
            {
                using (var br = new System.Drawing.Drawing2D.LinearGradientBrush(
                    this.pnlBanner.ClientRectangle,
                    Color.FromArgb(224, 242, 254),
                    Color.FromArgb(187, 222, 251),
                    System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                {
                    pe.Graphics.FillRectangle(br, this.pnlBanner.ClientRectangle);
                }
            };

            this.listCategories.DrawItem += (s, de) =>
            {
                bool sel = (de.State & DrawItemState.Selected) != 0;
                de.DrawBackground();
                if (sel)
                    de.Graphics.FillRectangle(
                        new SolidBrush(Color.FromArgb(227, 242, 253)),
                        de.Bounds);

                if (de.Index >= 0 && de.Index < listCategories.Items.Count)
                {
                    string txt2 = listCategories.Items[de.Index].ToString();
                    Color fc = sel ? Color.FromArgb(0, 82, 165) : Color.FromArgb(50, 50, 50);

                    de.Graphics.DrawString(
                        txt2,
                        sel ? new Font("Segoe UI", 10F, FontStyle.Bold) : new Font("Segoe UI", 10F),
                        new SolidBrush(fc),
                        de.Bounds.X + 6, de.Bounds.Y + 6);
                }
            };
        }

        // ==============================================================
        //  LOAD
        // ==============================================================
        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadSanPham();
            RefreshUserUI();
        }

        // ==============================================================
        //  DỮ LIỆU
        // ==============================================================
        private void LoadDanhMuc()
        {
            listCategories.Items.Clear();
            listCategories.Items.Add(new CategoryItem("ALL", "🏠 Tất cả sản phẩm"));

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    const string sql = "SELECT MADANHMUC, TENDANHMUC FROM DANHMUC ORDER BY TENDANHMUC";
                    using (var cmd = new SqlCommand(sql, conn))
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            listCategories.Items.Add(
                                new CategoryItem(r["MADANHMUC"].ToString(), "  " + r["TENDANHMUC"]));
                }
            }
            catch { /* DB chưa kết nối – bỏ qua */ }

            listCategories.SelectedIndex = 0;
        }

        private void LoadSanPham(string tuKhoa = "", string maDanhMuc = "ALL")
        {
            flowProducts.Controls.Clear();
            flowProducts.SuspendLayout();

            bool loaded = false;
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string whereExtra =
                        (maDanhMuc != "ALL" ? " AND T.MADANHMUC = @DM" : "") +
                        (!string.IsNullOrEmpty(tuKhoa) ? " AND (T.TENTHUOC LIKE @TK OR T.HOATCHAT LIKE @TK)" : "");

                    string sql = @"
                        SELECT T.MATHUOC, T.TENTHUOC, T.DANGBAOCHE, T.QUYCACH,
                               T.GIABANLRE, T.ISKEDON, T.MADANHMUC, D.TENDANHMUC,
                               COALESCE((SELECT SUM(L.SOLUONGTON)
                                         FROM LOHANG L
                                         WHERE L.MATHUOC = T.MATHUOC
                                           AND L.HANSD > GETDATE()
                                           AND L.TRANGTHAI = N'HoatDong'), 0) AS TONKHO
                        FROM   THUOC T
                        LEFT   JOIN DANHMUC D ON T.MADANHMUC = D.MADANHMUC
                        WHERE  1=1" + whereExtra + @"
                        ORDER  BY T.TENTHUOC";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        if (maDanhMuc != "ALL") cmd.Parameters.AddWithValue("@DM", maDanhMuc);
                        if (!string.IsNullOrEmpty(tuKhoa)) cmd.Parameters.AddWithValue("@TK", "%" + tuKhoa + "%");

                        using (var r = cmd.ExecuteReader())
                            while (r.Read())
                            {
                                flowProducts.Controls.Add(TaoCard(
                                    r["MATHUOC"].ToString(),
                                    r["TENTHUOC"].ToString(),
                                    r["DANGBAOCHE"].ToString(),
                                    r["QUYCACH"]?.ToString() ?? "",
                                    Convert.ToDouble(r["GIABANLRE"]),
                                    Convert.ToBoolean(r["ISKEDON"]),
                                    Convert.ToInt32(r["TONKHO"]),
                                    r["TENDANHMUC"]?.ToString() ?? ""
                                ));
                                loaded = true;
                            }
                    }
                }
            }
            catch { /* DB offline */ }

            if (!loaded)
                HienThiMauDemo();

            if (flowProducts.Controls.Count == 0)
                flowProducts.Controls.Add(new Label
                {
                    Text = "Không tìm thấy sản phẩm phù hợp.",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(30)
                });

            flowProducts.ResumeLayout();
        }

        // ==============================================================
        //  TẠO THẺ SẢN PHẨM (ĐÃ CẬP NHẬT LOAD ẢNH THẬT)
        // ==============================================================
        private Panel TaoCard(string maThuoc, string tenThuoc, string dangBaoChe,
            string quyCach, double giaBanLe, bool isKeDon, int tonKho, string tenDanhMuc)
        {
            double giahienThi = giaBanLe;
            if (SessionManager.IsKhachHangLoggedIn && SessionManager.LoaiKH == "Si")
                giahienThi = giaBanLe * (1.0 - SessionManager.TyLeChietKhau);

            var card = new Panel
            {
                Width = 195,
                Height = 270,
                BackColor = Color.White,
                Margin = new Padding(8),
                Cursor = Cursors.Hand,
                Tag = maThuoc
            };

            card.Paint += (s, pe) =>
            {
                using (var pen = new Pen(Color.FromArgb(220, 220, 230), 1))
                    pe.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };

            // ========================================================
            // LOGIC XỬ LÝ HÌNH ẢNH SẢN PHẨM
            // ========================================================
            var picProduct = new PictureBox
            {
                Width = 195,
                Height = 100,
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.Zoom, // Zoom để ảnh ko bị méo
                BackColor = Color.White
            };

            // Đường dẫn thư mục chứa ảnh: bin/Debug/Images/Products/
            string imageDir = System.IO.Path.Combine(Application.StartupPath, "Images", "Products");
            string imagePathJpg = System.IO.Path.Combine(imageDir, maThuoc + ".jpg");
            string imagePathPng = System.IO.Path.Combine(imageDir, maThuoc + ".png");

            // Kiểm tra xem có file ảnh thật không
            if (System.IO.File.Exists(imagePathJpg))
            {
                picProduct.Image = Image.FromFile(imagePathJpg);
            }
            else if (System.IO.File.Exists(imagePathPng))
            {
                picProduct.Image = Image.FromFile(imagePathPng);
            }
            else
            {
                // FALLBACK: Nếu chưa có ảnh thật, dùng lại ô màu và icon như cũ
                picProduct.BackColor = LayMauDanhMuc(tenDanhMuc);
                var lblEmoji = new Label
                {
                    Text = "💊",
                    Font = new Font("Segoe UI", 22, FontStyle.Bold),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                picProduct.Controls.Add(lblEmoji);
            }

            // Gắn nhãn thuốc kê đơn (Badge) đè lên góc ảnh
            if (isKeDon)
            {
                var lblRx = new Label
                {
                    Text = "Rx Kê đơn",
                    Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                    BackColor = Color.Crimson,
                    ForeColor = Color.White,
                    AutoSize = true,
                    Location = new Point(5, 5),
                    Padding = new Padding(2)
                };
                picProduct.Controls.Add(lblRx);
            }

            card.Controls.Add(picProduct);
            // ========================================================

            card.Controls.Add(new Label
            {
                Text = tenThuoc,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 20, 80),
                Location = new Point(8, 106),
                Width = 179,
                Height = 38,
                AutoSize = false,
                TextAlign = ContentAlignment.TopLeft
            });

            card.Controls.Add(new Label
            {
                Text = tenDanhMuc,
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = Color.Gray,
                Location = new Point(8, 144),
                Width = 179,
                Height = 18,
                AutoSize = false
            });

            string subText = dangBaoChe + (!string.IsNullOrEmpty(quyCach) ? " – " + quyCach : "");
            card.Controls.Add(new Label
            {
                Text = subText,
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = Color.DimGray,
                Location = new Point(8, 160),
                Width = 179,
                Height = 16,
                AutoSize = false
            });

            card.Controls.Add(new Label
            {
                Text = giahienThi.ToString("N0") + " đ",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                Location = new Point(8, 178),
                Width = 179,
                Height = 25,
                AutoSize = false
            });

            string tagText = tonKho == 0 ? "● Hết hàng"
                            : isKeDon ? "⚕ Cần đơn thuốc"
                            : "● Còn hàng";
            Color tagColor = tonKho == 0 ? Color.Crimson
                           : isKeDon ? Color.DarkOrange
                           : Color.ForestGreen;

            card.Controls.Add(new Label
            {
                Text = tagText,
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = tagColor,
                Location = new Point(8, 204),
                Width = 179,
                Height = 16,
                AutoSize = false
            });

            string btnText = tonKho > 0 ? "🛒  Thêm vào giỏ" : "📋  Đặt trước";
            Color btnColor = tonKho > 0 ? Color.FromArgb(0, 153, 76) : Color.FromArgb(230, 126, 34);

            var btnMua = new Button
            {
                Text = btnText,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = btnColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(8, 226),
                Width = 179,
                Height = 34,
                Cursor = Cursors.Hand,
                Tag = new object[] { maThuoc, tenThuoc, giaBanLe, isKeDon, tonKho }
            };
            btnMua.FlatAppearance.BorderSize = 0;
            btnMua.Click += BtnMua_Click;
            card.Controls.Add(btnMua);

            return card;
        }

        private void BtnMua_Click(object sender, EventArgs e)
        {
            var data = (object[])((Button)sender).Tag;
            string maThuoc = (string)data[0];
            string tenThuoc = (string)data[1];
            double giaBanLe = (double)data[2];
            bool isKeDon = (bool)data[3];
            int tonKho = (int)data[4];

            if (tonKho == 0)
            {
                MessageBox.Show("Sản phẩm hiện đang hết hàng.\nBạn có thể đặt trước để được thông báo khi có hàng.",
                    "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (isKeDon)
            {
                MessageBox.Show(
                    "⚕ Đây là thuốc kê đơn.\n\n" +
                    "Vui lòng mang đơn thuốc từ bác sĩ đến quầy nhà thuốc\n" +
                    "hoặc liên hệ dược sĩ để được tư vấn thêm.",
                    "Thuốc kê đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double gia = giaBanLe;
            if (SessionManager.IsKhachHangLoggedIn && SessionManager.LoaiKH == "Si")
                gia = giaBanLe * (1.0 - SessionManager.TyLeChietKhau);

            var existing = GioHang.Find(x => x.MaThuoc == maThuoc);
            if (existing != null)
                existing.SoLuong++;
            else
                GioHang.Add(new GioHangItem { MaThuoc = maThuoc, TenThuoc = tenThuoc, GiaBan = gia, SoLuong = 1 });

            RefreshCartButton();

            int tongSL = 0;
            GioHang.ForEach(x => tongSL += x.SoLuong);
            lblCartBadge.Text = tongSL.ToString();
            lblCartBadge.Visible = true;

            toolTipGio.Show($"✓ Đã thêm {tenThuoc}", btnCart, btnCart.Width / 2, -30, 1800);
        }

        // ==============================================================
        //  GIỎ HÀNG
        // ==============================================================
        private void RefreshCartButton()
        {
            int total = 0;
            GioHang.ForEach(x => total += x.SoLuong);
            btnCart.Text = $"🛒  Giỏ hàng ({total})";
            lblCartBadge.Text = total.ToString();
            lblCartBadge.Visible = total > 0;
        }

        // ==============================================================
        //  CẬP NHẬT UI THEO TRẠNG THÁI ĐĂNG NHẬP
        //  (Phiên bản sửa – điều chỉnh btnDangNhapNV + btnVaoHeThong)
        // ==============================================================
        public void RefreshUserUI()
        {
            if (SessionManager.IsLoggedIn)
            {
                // ── Nhân viên / Quản lý đã đăng nhập ─────────────
                lblUserInfo.Text = $"👤 {SessionManager.TenNV}  [{SessionManager.VaiTro}]";
                lblUserInfo.Visible = true;

                btnDangNhap.Visible = false;
                btnDangKy.Visible = false;
                btnDangNhapNV.Visible = false;   // đã đăng nhập rồi
                btnVaoHeThong.Visible = true;
                btnDangXuat.Visible = true;
            }
            else if (SessionManager.IsKhachHangLoggedIn)
            {
                // ── Khách hàng đã đăng nhập ───────────────────────
                string info = SessionManager.LoaiKH == "Si"
                    ? $"👤 {SessionManager.TenKH}  [Sỉ]"
                    : $"👤 {SessionManager.TenKH}  ★ {SessionManager.DiemTichLuy:N0} đ";
                lblUserInfo.Text = info;
                lblUserInfo.Visible = true;

                btnDangNhap.Visible = false;
                btnDangKy.Visible = false;
                btnDangNhapNV.Visible = false;   // ẩn nút NV khi KH đã đăng nhập
                btnVaoHeThong.Visible = false;
                btnDangXuat.Visible = true;
            }
            else
            {
                // ── Chưa đăng nhập ────────────────────────────────
                lblUserInfo.Visible = false;
                btnDangNhap.Visible = true;
                btnDangKy.Visible = true;
                btnDangNhapNV.Visible = true;
                btnVaoHeThong.Visible = false;
                btnDangXuat.Visible = false;
            }
        }

        // ==============================================================
        //  SỰ KIỆN ĐIỀU HƯỚNG
        // ==============================================================

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var frm = new frmDangNhapKhachHang();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshUserUI();
                LoadSanPham(txtSearch.Text.Trim(), _maDanhMucSelected);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            var frm = new frmDangKyThanhVien();
            if (frm.ShowDialog(this) == DialogResult.OK)
                MessageBox.Show("Đăng ký thành công!\nVui lòng đăng nhập để mua hàng.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận đăng xuất?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            SessionManager.Logout();
            SessionManager.LogoutKhachHang();
            GioHang.Clear();
            RefreshCartButton();
            RefreshUserUI();
            LoadSanPham();
        }

        private void btnVaoHeThong_Click(object sender, EventArgs e)
        {
            var main = new frmMain();
            this.Hide();
            main.FormClosed += (s2, e2) => this.Show();
            main.Show();
        }

        private void btnDangNhapNV_Click(object sender, EventArgs e)
        {
            var frm = new frmDangNhap();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshUserUI();
                var main = new frmMain();
                this.Hide();
                main.FormClosed += (s2, e2) =>
                {
                    SessionManager.Logout();
                    RefreshUserUI();
                    this.Show();
                };
                main.Show();
            }
        }

        // ==============================================================
        //  GIỎ HÀNG – KẾT NỐI frmMuaHangKhachHang (ĐÃ SỬA)
        // ==============================================================
        private void btnCart_Click(object sender, EventArgs e)
        {
            if (GioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng của bạn đang trống!\nHãy thêm sản phẩm vào giỏ.",
                    "Giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ── Nếu NHÂN VIÊN đang login → cho phép mua như vãng lai, không yêu cầu đăng nhập KH ──
            if (SessionManager.IsLoggedIn)
            {
                // NV dùng trang mua hàng → mở thẳng không cần đăng nhập KH
                var frmGioNV = new frmMuaHangKhachHang(GioHang);
                if (frmGioNV.ShowDialog(this) == DialogResult.OK)
                {
                    GioHang.Clear();
                    RefreshCartButton();
                }
                return;
            }

            // ── Khách chưa đăng nhập → gợi ý đăng nhập (nhưng không bắt buộc) ──
            if (!SessionManager.IsKhachHangLoggedIn)
            {
                var res = MessageBox.Show(
                    "Bạn chưa đăng nhập tài khoản thành viên.\n\n" +
                    "Đăng nhập để hưởng ưu đãi & tích điểm?\n" +
                    "(Chọn 'No' để tiếp tục mua hàng như khách vãng lai)",
                    "Gợi ý đăng nhập",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    var frmLogin = new frmDangNhapKhachHang();
                    if (frmLogin.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshUserUI();
                        // Reload sản phẩm để áp chiết khấu sỉ nếu có
                        LoadSanPham(txtSearch.Text.Trim(), _maDanhMucSelected);
                    }
                    // Nếu đóng form login mà không OK → vẫn tiếp tục như vãng lai
                }
            }

            // Mở form đặt hàng / giỏ hàng
            var frmGio = new frmMuaHangKhachHang(GioHang);
            if (frmGio.ShowDialog(this) == DialogResult.OK)
            {
                // Đặt hàng thành công → làm sạch giỏ
                GioHang.Clear();
                RefreshCartButton();
            }
        }

        // ==============================================================
        //  TÌM KIẾM / DANH MỤC
        // ==============================================================
        private void btnSearch_Click(object sender, EventArgs e) =>
            LoadSanPham(txtSearch.Text.Trim(), _maDanhMucSelected);

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void listCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCategories.SelectedItem is CategoryItem item)
            {
                _maDanhMucSelected = item.MaDanhMuc;
                LoadSanPham(txtSearch.Text.Trim(), item.MaDanhMuc);
            }
        }

        // ==============================================================
        //  HELPER
        // ==============================================================
        private Color LayMauDanhMuc(string ten)
        {
            if (string.IsNullOrEmpty(ten)) return Color.FromArgb(70, 130, 180);
            Color[] palette =
            {
                Color.FromArgb(0,  102, 204),
                Color.FromArgb(0,  153,  76),
                Color.FromArgb(192,  57,  43),
                Color.FromArgb(142,  68, 173),
                Color.FromArgb( 22, 160, 133),
                Color.FromArgb(211,  84,   0),
                Color.FromArgb( 41, 128, 185),
            };
            return palette[Math.Abs(ten.GetHashCode()) % palette.Length];
        }

        private void HienThiMauDemo()
        {
            var demos = new[]
            {
                new { Ma="T001", Ten="Paracetamol 500mg",       Dang="Viên nén",      Gia=25000.0,  KeDon=false, Ton=200, DM="Giảm đau - Hạ sốt" },
                new { Ma="T002", Ten="Vitamin C 1000mg",        Dang="Viên sủi",      Gia=120000.0, KeDon=false, Ton=150, DM="Vitamin & Khoáng chất" },
                new { Ma="T003", Ten="Amoxicillin 500mg",       Dang="Viên nang",     Gia=85000.0,  KeDon=true,  Ton=100, DM="Kháng sinh" },
                new { Ma="T004", Ten="Berberin 10mg",           Dang="Viên nén",      Gia=28000.0,  KeDon=false, Ton=300, DM="Tiêu hóa" },
                new { Ma="T005", Ten="Omega-3 Fish Oil 1000mg", Dang="Viên nang mềm", Gia=250000.0, KeDon=false, Ton=80,  DM="Thực phẩm chức năng" },
                new { Ma="T006", Ten="Collagen C Powder",       Dang="Bột uống",      Gia=320000.0, KeDon=false, Ton=60,  DM="Làm đẹp - Da liễu" },
                new { Ma="T007", Ten="Ibuprofen 400mg",         Dang="Viên nén bao",  Gia=35000.0,  KeDon=false, Ton=180, DM="Giảm đau - Hạ sốt" },
                new { Ma="T008", Ten="Cetirizine 10mg",         Dang="Viên nén",      Gia=45000.0,  KeDon=false, Ton=90,  DM="Dị ứng - Hô hấp" },
            };
            foreach (var d in demos)
                flowProducts.Controls.Add(TaoCard(d.Ma, d.Ten, d.Dang, "", d.Gia, d.KeDon, d.Ton, d.DM));
        }

        // ==============================================================
        //  INNER CLASSES
        // ==============================================================
        public class GioHangItem
        {
            public string MaThuoc { get; set; }
            public string TenThuoc { get; set; }
            public double GiaBan { get; set; }
            public int SoLuong { get; set; }
            public double ThanhTien => GiaBan * SoLuong;
        }

        private class CategoryItem
        {
            public string MaDanhMuc { get; }
            public string TenDanhMuc { get; }
            public CategoryItem(string ma, string ten) { MaDanhMuc = ma; TenDanhMuc = ten; }
            public override string ToString() => TenDanhMuc;
        }
    }
}