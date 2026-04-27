using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace PharmacyManagement                         // [F1]
{
    public static class DatabaseHelper
    {
        // --- Đổi chuỗi kết nối theo máy chủ thực tế của bạn ---
        private static readonly string _conn =
            @"Data Source=DESKTOP-Q1UORLL\DESKTOP;" +
            @"Initial Catalog=QLNhaThuocPharmacy;" +
            @"Persist Security Info=True;User ID=sa;Password=123";

        public static SqlConnection GetConnection() => new SqlConnection(_conn);

        // ============================================================
        // 1. ĐĂNG NHẬP NHÂN VIÊN  (TAIKHOAN + NHANVIEN)
        //    [F2] Không có bảng VAITRO; VAITRO là cột trong TAIKHOAN
        //    [F3] TRANGTHAI là NVARCHAR ('HoatDong' | 'BiKhoa' | 'NgungHD')
        // ============================================================
        public static bool CheckLogin(
            string username, string password,
            out string maNV, out string tenNV,
            out string vaiTro, out int capDoQuyen, out int soLanSai)
        {
            maNV = tenNV = vaiTro = string.Empty;
            capDoQuyen = 1; soLanSai = 0;

            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    const string sql = @"
                        SELECT T.MATKHAU,
                               T.TRANGTHAI,            -- NVARCHAR, không phải BIT
                               T.SOLANSIMATKHAU,
                               T.CAPDOQUYEN,
                               T.VAITRO,               -- cột trực tiếp, không JOIN
                               N.MANV,
                               N.TENNV
                        FROM   TAIKHOAN  T
                        JOIN   NHANVIEN  N ON T.MANV = N.MANV
                        WHERE  T.TENDANGNHAP = @User";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@User", username);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (!r.Read()) return false;

                            string trangThai = r["TRANGTHAI"].ToString();   // [F3]
                            soLanSai = Convert.ToInt32(r["SOLANSIMATKHAU"]);

                            if (trangThai != "HoatDong" || soLanSai >= 5)
                            {
                                MessageBox.Show(
                                    "Tài khoản đã bị khóa!\nLiên hệ quản lý để mở khóa.",
                                    "Bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            if (r["MATKHAU"].ToString() != password) return false;

                            maNV = r["MANV"].ToString();
                            tenNV = r["TENNV"].ToString();
                            vaiTro = r["VAITRO"].ToString();
                            capDoQuyen = Convert.ToInt32(r["CAPDOQUYEN"]);
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Cập nhật số lần sai + khóa khi >= 5 (nhân viên)
        public static void UpdateSoLanSaiNhanVien(string username, int count)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = count >= 5
                    ? "UPDATE TAIKHOAN SET SOLANSIMATKHAU=@c, TRANGTHAI=N'BiKhoa' WHERE TENDANGNHAP=@u"
                    : "UPDATE TAIKHOAN SET SOLANSIMATKHAU=@c WHERE TENDANGNHAP=@u";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@c", count);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.ExecuteNonQuery();
            }
        }

        // Wrapper cũ – giữ để không break code hiện tại
        public static void UpdateSoLanSaiMatKhau(string username, int count)
            => UpdateSoLanSaiNhanVien(username, count);

        public static void ResetSoLanSaiNhanVien(string username)
            => UpdateSoLanSaiNhanVien(username, 0);

        // ============================================================
        // 2. ĐĂNG NHẬP KHÁCH HÀNG THÀNH VIÊN  (KHACHHANGTHANHVIEN)
        //    Bảng có TENDANGNHAP + MATKHAU + TRANGTHAI riêng
        // ============================================================
        public static bool CheckLoginThanhVien(
            string username, string password,
            out string maKH, out string hoTen,
            out string hangTV, out int diemTichLuy)
        {
            maKH = hoTen = string.Empty;
            hangTV = "Dong"; diemTichLuy = 0;

            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    const string sql = @"
                        SELECT  KH.MAKH,
                                KH.HOTEN,
                                TV.MATKHAU,
                                TV.TRANGTHAI,
                                TV.DIEMTICHLUY,
                                ISNULL(THE.HANGTV, N'Dong') AS HANGTV
                        FROM    KHACHHANGTHANHVIEN TV
                        JOIN    KHACHHANG          KH  ON KH.MAKH  = TV.MAKH
                        LEFT JOIN THETHANHVIEN     THE ON THE.MAKH = TV.MAKH
                        WHERE   TV.TENDANGNHAP = @User";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@User", username);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (!r.Read()) return false;

                            if (r["TRANGTHAI"].ToString() != "HoatDong")
                            {
                                MessageBox.Show("Tài khoản thành viên đang bị khóa!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                            if (r["MATKHAU"].ToString() != password) return false;

                            maKH = r["MAKH"].ToString();
                            hoTen = r["HOTEN"].ToString();
                            hangTV = r["HANGTV"].ToString();
                            diemTichLuy = Convert.ToInt32(r["DIEMTICHLUY"]);
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // ============================================================
        // 3. ĐĂNG NHẬP KHÁCH SỈ  (KHACHHANGSI)
        // ============================================================
        public static bool CheckLoginKhachHangSi(
            string username, string password,
            out string maKH, out string hoTen,
            out string tenCongTy, out float tyLeChietKhau, out int soLanSai)
        {
            maKH = hoTen = tenCongTy = string.Empty;
            tyLeChietKhau = 0f; soLanSai = 0;

            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    const string sql = @"
                        SELECT  KH.MAKH,
                                KH.HOTEN,
                                KS.MATKHAU,
                                KS.SOLANSIMATKHAU,
                                KS.TRANGTHAID,
                                KS.TENCONGTY,
                                KS.TYLECHIETKHAU,
                                KS.NGAYHETHAN
                        FROM    KHACHHANGSI KS
                        JOIN    KHACHHANG   KH ON KH.MAKH = KS.MAKH
                        WHERE   KS.TENDANGNHAP = @User";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@User", username);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (!r.Read()) return false;

                            soLanSai = Convert.ToInt32(r["SOLANSIMATKHAU"]);
                            string tt = r["TRANGTHAID"].ToString();

                            if (soLanSai >= 5)
                            {
                                MessageBox.Show(
                                    "Tài khoản sỉ đã bị khóa do nhập sai mật khẩu quá 5 lần!\n" +
                                    "Vui lòng liên hệ nhà thuốc để mở khóa.",
                                    "Tài khoản bị khóa",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            if (tt == "TamNgung")
                            {
                                MessageBox.Show(
                                    "Tài khoản sỉ đang bị tạm ngưng!\n" +
                                    "Lý do: Công nợ vượt hạn mức hoặc vi phạm hợp đồng.\n\n" +
                                    "Vui lòng liên hệ nhà thuốc để được hỗ trợ.",
                                    "Tài khoản tạm ngưng",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            DateTime ngayHetHan = Convert.ToDateTime(r["NGAYHETHAN"]);
                            bool hdHetHan = ngayHetHan < DateTime.Today;

                            if (r["MATKHAU"].ToString() != password)
                                return false;

                            maKH = r["MAKH"].ToString();
                            hoTen = r["HOTEN"].ToString();
                            tenCongTy = r["TENCONGTY"].ToString();
                            tyLeChietKhau = Convert.ToSingle(r["TYLECHIETKHAU"]);

                            if (hdHetHan)
                            {
                                MessageBox.Show(
                                    $"⚠️  Hợp đồng của {tenCongTy} đã hết hạn\n" +
                                    $"   (Ngày hết hạn: {ngayHetHan:dd/MM/yyyy})\n\n" +
                                    "Vui lòng liên hệ nhà thuốc để gia hạn hợp đồng.\n" +
                                    "Bạn vẫn có thể đăng nhập nhưng một số tính năng\n" +
                                    "mua sỉ có thể bị hạn chế.",
                                    "Cảnh báo hợp đồng",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static void UpdateSoLanSaiKhachHangSi(string username, int count)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = count >= 5
                    ? "UPDATE KHACHHANGSI SET SOLANSIMATKHAU=@c, TRANGTHAID=N'TamNgung' WHERE TENDANGNHAP=@u"
                    : "UPDATE KHACHHANGSI SET SOLANSIMATKHAU=@c WHERE TENDANGNHAP=@u";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@c", count);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.ExecuteNonQuery();
            }
        }

        public static void ResetSoLanSaiKhachHangSi(string username)
            => UpdateSoLanSaiKhachHangSi(username, 0);

        // ============================================================
        // 4. DANH SÁCH KHÁCH HÀNG  (tất cả loại, có filter)
        // ============================================================
        public static DataTable GetDanhSachKhachHang(string loaiKH = "")
        {
            using (var conn = GetConnection())
            {
                string where = string.IsNullOrEmpty(loaiKH)
                    ? "" : "WHERE KH.LOAIKH = @LoaiKH";

                string sql = $@"
                    SELECT
                        KH.MAKH,
                        KH.HOTEN,
                        KH.SDT,
                        KH.DIACHI,
                        KH.NGAYSINH,
                        KH.LOAIKH,
                        ISNULL(TV.EMAIL,        '')  AS EMAIL,
                        ISNULL(TV.TENDANGNHAP,  '')  AS TDN_TV,
                        ISNULL(TV.DIEMTICHLUY,  0)   AS DIEMTICHLUY,
                        ISNULL(TV.TRANGTHAI,    '')  AS TRANGTHAI_TV,
                        ISNULL(THE.HANGTV,      '')  AS HANGTV,
                        ISNULL(THE.NGAYCAP,     NULL) AS NGAYCAPTHE,
                        ISNULL(KS.TENCONGTY,    '')  AS TENCONGTY,
                        ISNULL(KS.MST,          '')  AS MST_SI,
                        ISNULL(KS.TRANGTHAID,   '')  AS TRANGTHAI_SI,
                        ISNULL(KS.CONGNOHT,     0)   AS CONGNOHT,
                        ISNULL(KS.TYLECHIETKHAU,0)   AS TYLECHIETKHAU
                    FROM      KHACHHANG           KH
                    LEFT JOIN KHACHHANGTHANHVIEN  TV  ON TV.MAKH  = KH.MAKH
                    LEFT JOIN THETHANHVIEN        THE ON THE.MAKH = KH.MAKH
                    LEFT JOIN KHACHHANGSI         KS  ON KS.MAKH  = KH.MAKH
                    {where}
                    ORDER BY KH.LOAIKH, KH.HOTEN";

                var da = new SqlDataAdapter(sql, conn);
                if (!string.IsNullOrEmpty(loaiKH))
                    da.SelectCommand.Parameters.AddWithValue("@LoaiKH", loaiKH);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable TimKiemKhachHang(string keyword)
        {
            using (var conn = GetConnection())
            {
                const string sql = @"
                    SELECT
                        KH.MAKH, KH.HOTEN, KH.SDT, KH.LOAIKH,
                        ISNULL(TV.DIEMTICHLUY,0) AS DIEMTICHLUY,
                        ISNULL(THE.HANGTV,'')    AS HANGTV,
                        ISNULL(KS.TENCONGTY,'')  AS TENCONGTY
                    FROM      KHACHHANG           KH
                    LEFT JOIN KHACHHANGTHANHVIEN  TV  ON TV.MAKH  = KH.MAKH
                    LEFT JOIN THETHANHVIEN        THE ON THE.MAKH = KH.MAKH
                    LEFT JOIN KHACHHANGSI         KS  ON KS.MAKH  = KH.MAKH
                    WHERE KH.SDT   LIKE @kw
                       OR KH.HOTEN LIKE @kw
                       OR KH.MAKH  LIKE @kw
                    ORDER BY KH.HOTEN";
                var da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ============================================================
        // 5. LƯU KHÁCH HÀNG THÀNH VIÊN  (transaction 3 bảng)
        // ============================================================
        public static bool SaveKhachHangThanhVien(
            string maKH, string hoTen, string sdt,
            string diaChi, DateTime? ngaySinh,
            string email, string tenDangNhap, string matKhau)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    var c1 = new SqlCommand(@"
                        INSERT INTO KHACHHANG(MAKH,HOTEN,SDT,DIACHI,NGAYSINH,LOAIKH)
                        VALUES(@mk,@ht,@sdt,@dc,@ns,N'ThanhVien')", conn, trans);
                    c1.Parameters.AddWithValue("@mk", maKH);
                    c1.Parameters.AddWithValue("@ht", hoTen);
                    c1.Parameters.AddWithValue("@sdt", sdt);
                    c1.Parameters.AddWithValue("@dc", (object)diaChi ?? DBNull.Value);
                    c1.Parameters.AddWithValue("@ns", ngaySinh.HasValue
                                                        ? (object)ngaySinh.Value : DBNull.Value);
                    c1.ExecuteNonQuery();

                    var c2 = new SqlCommand(@"
                        INSERT INTO KHACHHANGTHANHVIEN
                               (MAKH,EMAIL,TENDANGNHAP,MATKHAU,DIEMTICHLUY,NGAYDK,TRANGTHAI)
                        VALUES (@mk,@em,@tdn,@mk2,0,GETDATE(),N'HoatDong')", conn, trans);
                    c2.Parameters.AddWithValue("@mk", maKH);
                    c2.Parameters.AddWithValue("@em", email);
                    c2.Parameters.AddWithValue("@tdn", tenDangNhap);
                    c2.Parameters.AddWithValue("@mk2", matKhau);
                    c2.ExecuteNonQuery();

                    string soThe = "THE" + maKH.Substring(2).PadLeft(5, '0');
                    var c3 = new SqlCommand(@"
                        INSERT INTO THETHANHVIEN(MATHE,MAKH,NGAYCAP,HANGTV)
                        VALUES (@mt,@mk,GETDATE(),N'Dong')", conn, trans);
                    c3.Parameters.AddWithValue("@mt", soThe);
                    c3.Parameters.AddWithValue("@mk", maKH);
                    c3.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi lưu khách thành viên:\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // ============================================================
        // 6. LƯU KHÁCH HÀNG SỈ  (transaction 2 bảng)
        // ============================================================
        public static bool SaveKhachHangSi(
            string maKH, string hoTen, string sdt, string diaChi, DateTime? ngaySinh,
            string tenCongTy, string mst, string tenDangNhap, string matKhau,
            float hanMucCongNo, float tyLeChietKhau, int thoiHanThanhToan,
            DateTime ngayKyHD, DateTime ngayHetHan)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    var c1 = new SqlCommand(@"
                        INSERT INTO KHACHHANG(MAKH,HOTEN,SDT,DIACHI,NGAYSINH,LOAIKH)
                        VALUES(@mk,@ht,@sdt,@dc,@ns,N'Si')", conn, trans);
                    c1.Parameters.AddWithValue("@mk", maKH);
                    c1.Parameters.AddWithValue("@ht", hoTen);
                    c1.Parameters.AddWithValue("@sdt", sdt);
                    c1.Parameters.AddWithValue("@dc", (object)diaChi ?? DBNull.Value);
                    c1.Parameters.AddWithValue("@ns", ngaySinh.HasValue
                                                        ? (object)ngaySinh.Value : DBNull.Value);
                    c1.ExecuteNonQuery();

                    var c2 = new SqlCommand(@"
                        INSERT INTO KHACHHANGSI
                            (MAKH,TENCONGTY,MST,TENDANGNHAP,MATKHAU,SOLANSIMATKHAU,
                             HANMUCCONGNO,CONGNOHT,THOIHANTHANHTOAN,TYLECHIETKHAU,
                             TRANGTHAID,NGAYKYHD,NGAYHETHAN)
                        VALUES(@mk,@tc,@mst,@tdn,@mk2,0,
                               @hm,0,@tht,@tl,N'HieuLuc',@nk,@nh)", conn, trans);
                    c2.Parameters.AddWithValue("@mk", maKH);
                    c2.Parameters.AddWithValue("@tc", tenCongTy);
                    c2.Parameters.AddWithValue("@mst", mst);
                    c2.Parameters.AddWithValue("@tdn", tenDangNhap);
                    c2.Parameters.AddWithValue("@mk2", matKhau);
                    c2.Parameters.AddWithValue("@hm", hanMucCongNo);
                    c2.Parameters.AddWithValue("@tht", thoiHanThanhToan);
                    c2.Parameters.AddWithValue("@tl", tyLeChietKhau);
                    c2.Parameters.AddWithValue("@nk", ngayKyHD);
                    c2.Parameters.AddWithValue("@nh", ngayHetHan);
                    c2.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi lưu khách sỉ:\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // ============================================================
        // 7. TIỆN ÍCH  – sinh mã KH tự động
        // ============================================================
        public static string GenerateMaKH()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT TOP 1 MAKH FROM KHACHHANG ORDER BY MAKH DESC", conn);
                string last = cmd.ExecuteScalar()?.ToString() ?? "KH000";
                if (int.TryParse(last.Substring(2), out int n))
                    return "KH" + (n + 1).ToString("D3");
                return "KH001";
            }
        }

        public static bool KiemTraTenDangNhapKhachTonTai(string tenDangNhap)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT COUNT(*) FROM (
                        SELECT TENDANGNHAP FROM KHACHHANGTHANHVIEN WHERE TENDANGNHAP = @tdn
                        UNION ALL
                        SELECT TENDANGNHAP FROM KHACHHANGSI         WHERE TENDANGNHAP = @tdn
                    ) T", conn);
                cmd.Parameters.AddWithValue("@tdn", tenDangNhap);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public static bool KiemTraSDTTonTai(string sdt)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM KHACHHANG WHERE SDT = @sdt", conn);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public static bool KiemTraEmailTonTai(string email)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM KHACHHANGTHANHVIEN WHERE EMAIL = @em", conn);
                cmd.Parameters.AddWithValue("@em", email);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // ============================================================
        // 8. THUỐC  &  DANH MỤC
        // ============================================================
        public static DataTable GetDanhSachThuoc()
        {
            using (var conn = GetConnection())
            {
                const string sql = @"
                    SELECT T.MATHUOC, T.TENTHUOC, T.HOATCHAT,
                           T.DANGBAOCHE, T.QUYCACH, T.ISKEDON,
                           T.GIABANLRE, D.TENDANHMUC
                    FROM   THUOC   T
                    LEFT JOIN DANHMUC D ON D.MADANHMUC = T.MADANHMUC
                    ORDER BY T.TENTHUOC";
                var da = new SqlDataAdapter(sql, conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetDanhMucList()
        {
            using (var conn = GetConnection())
            {
                var da = new SqlDataAdapter(
                    "SELECT MADANHMUC, TENDANHMUC FROM DANHMUC ORDER BY TENDANHMUC", conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ============================================================
        // 9. CHI TIẾT HÓA ĐƠN  [F4]
        //    CHITIETHOADON dùng MALO (lô hàng), phải JOIN → LOHANG → THUOC
        // ============================================================
        public static DataTable GetChiTietHoaDon(string maHD)
        {
            using (var conn = GetConnection())
            {
                const string sql = @"
                    SELECT
                        CT.MALO,
                        T.MATHUOC,
                        T.TENTHUOC,
                        LH.HANSD,
                        CT.SOLUONG,
                        CT.DONGIABAN,
                        CT.GIAMGIAITEM,
                        CT.THANHTIEN,
                        CT.CACHDUNG
                    FROM      CHITIETHOADON CT
                    INNER JOIN LOHANG  LH ON LH.MALO    = CT.MALO
                    INNER JOIN THUOC   T  ON T.MATHUOC  = LH.MATHUOC
                    WHERE CT.MAHD = @MaHD";
                var da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaHD", maHD);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ============================================================
        // 10. HỒ SƠ KHÁCH HÀNG  (cho frmHoSoKhachHang)
        // ============================================================
        public static DataRow GetHoSoKhachHang(string maKH)
        {
            using (var conn = GetConnection())
            {
                const string sql = @"
                    SELECT
                        KH.MAKH, KH.HOTEN, KH.SDT, KH.DIACHI, KH.NGAYSINH, KH.LOAIKH,
                        ISNULL(TV.EMAIL,'')           AS EMAIL,
                        ISNULL(TV.DIEMTICHLUY,0)      AS DIEMTICHLUY,
                        ISNULL(TV.NGAYDK,NULL)        AS NGAYDK,
                        ISNULL(TV.TRANGTHAI,'')       AS TRANGTHAI_TV,
                        ISNULL(THE.MATHE,'')          AS MATHE,
                        ISNULL(THE.NGAYCAP,NULL)      AS NGAYCAPTHE,
                        ISNULL(THE.HANGTV,'')         AS HANGTV,
                        ISNULL(KS.TENCONGTY,'')       AS TENCONGTY,
                        ISNULL(KS.MST,'')             AS MST,
                        ISNULL(KS.HANMUCCONGNO,0)     AS HANMUCCONGNO,
                        ISNULL(KS.CONGNOHT,0)         AS CONGNOHT,
                        ISNULL(KS.TYLECHIETKHAU,0)    AS TYLECHIETKHAU,
                        ISNULL(KS.THOIHANTHANHTOAN,30) AS THOIHANTHANHTOAN,
                        ISNULL(KS.TRANGTHAID,'')      AS TRANGTHAID,
                        ISNULL(KS.NGAYKYHD,NULL)      AS NGAYKYHD,
                        ISNULL(KS.NGAYHETHAN,NULL)    AS NGAYHETHAN
                    FROM      KHACHHANG           KH
                    LEFT JOIN KHACHHANGTHANHVIEN  TV  ON TV.MAKH  = KH.MAKH
                    LEFT JOIN THETHANHVIEN        THE ON THE.MAKH = KH.MAKH
                    LEFT JOIN KHACHHANGSI         KS  ON KS.MAKH  = KH.MAKH
                    WHERE KH.MAKH = @MaKH";
                var da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaKH", maKH);
                var dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public static DataTable GetLichSuMuaHang(string maKH, int topN = 20)
        {
            using (var conn = GetConnection())
            {
                string sql = $@"
                    SELECT TOP {topN}
                        HD.MAHD, HD.NGAYLAP, HD.TONGTIEN, HD.LOAIHD, HD.TRANGTHAID
                    FROM   HOADON HD
                    WHERE  HD.MAKH = @MaKH
                    ORDER  BY HD.NGAYLAP DESC";
                var da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaKH", maKH);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ============================================================
        // 11. CHI TIẾT ĐƠN HÀNG ONLINE  (CHITIETDONHANG → DONHANG)
        //     Dùng cho frmChiTietDonHang – khác với GetChiTietHoaDon
        // ============================================================
        public static DataTable GetChiTietDonHang(string maDon)
        {
            using (var conn = GetConnection())
            {
                const string sql = @"
                    SELECT  T.TENTHUOC  AS TenThuoc,
                            C.SOLUONGDAT AS SoLuong,
                            C.DONGIACHOT AS DonGia,
                            C.THANHTIEN  AS ThanhTien
                    FROM    CHITIETDONHANG C
                    JOIN    THUOC          T ON T.MATHUOC = C.MATHUOC
                    WHERE   C.MADON = @MaDon";
                var da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaDon", maDon);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ============================================================
        // 12. DANH SÁCH SHIPPER  (NhanVienGiaoHang đang hoạt động)
        //     Dùng cho cboShipper trong frmChiTietDonHang
        // ============================================================
        public static DataTable GetDanhSachShipper()
        {
            using (var conn = GetConnection())
            {
                const string sql = @"
                    SELECT  N.MANV,
                            N.TENNV,
                            N.MANV + N' – ' + N.TENNV AS TenHienThi
                    FROM    NHANVIEN  N
                    JOIN    TAIKHOAN  T ON T.MANV = N.MANV
                    WHERE   T.VAITRO   = N'NhanVienGiaoHang'
                      AND   T.TRANGTHAI = N'HoatDong'
                    ORDER BY N.TENNV";
                var da = new SqlDataAdapter(sql, conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ============================================================
        // 13. PHÂN CÔNG GIAO HÀNG
        //     INSERT PHIEUGIAOHANG + UPDATE DONHANG.TRANGTHAIDON
        // ============================================================
        public static bool PhanCongGiaoHang(string maDon, string maNVShipper)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    // Sinh mã vận đơn tự động (VD + số thứ tự)
                    string maVanDon;
                    var cmdMax = new SqlCommand(
                        "SELECT TOP 1 MAVANDON FROM PHIEUGIAOHANG ORDER BY MAVANDON DESC", conn, trans);
                    string lastVD = cmdMax.ExecuteScalar()?.ToString() ?? "VD000";
                    if (lastVD.Length >= 5 && int.TryParse(lastVD.Substring(2), out int n))
                        maVanDon = "VD" + (n + 1).ToString("D3");
                    else
                        maVanDon = "VD" + DateTime.Now.ToString("yyMMddHHmm");

                    // Lấy địa chỉ giao hàng từ DONHANG
                    string diaChiGiao = "";
                    var cmdDC = new SqlCommand(
                        "SELECT ISNULL(DIACHIGIAO, N'Không có địa chỉ') FROM DONHANG WHERE MADON = @md",
                        conn, trans);
                    cmdDC.Parameters.AddWithValue("@md", maDon);
                    object dcResult = cmdDC.ExecuteScalar();
                    if (dcResult != null) diaChiGiao = dcResult.ToString();

                    // INSERT vào PHIEUGIAOHANG
                    var cmdInsert = new SqlCommand(@"
                        INSERT INTO PHIEUGIAOHANG
                            (MAVANDON, NGAYGIAO, PHISHIP, TRANGTHAI, DIACHINHA, MADON, MANV)
                        VALUES
                            (@mvd, GETDATE(), 0, N'DangGiao', @dc, @md, @nv)",
                        conn, trans);
                    cmdInsert.Parameters.AddWithValue("@mvd", maVanDon);
                    cmdInsert.Parameters.AddWithValue("@dc", diaChiGiao);
                    cmdInsert.Parameters.AddWithValue("@md", maDon);
                    cmdInsert.Parameters.AddWithValue("@nv", maNVShipper);
                    cmdInsert.ExecuteNonQuery();

                    // UPDATE DONHANG.TRANGTHAIDON = 'DangGiao'
                    var cmdUpdate = new SqlCommand(
                        "UPDATE DONHANG SET TRANGTHAIDON = N'DangGiao' WHERE MADON = @md",
                        conn, trans);
                    cmdUpdate.Parameters.AddWithValue("@md", maDon);
                    cmdUpdate.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi phân công giao hàng:\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // ============================================================
        // 14. DANH SÁCH PHIẾU GIAO HÀNG THEO SHIPPER
        //     Dùng cho frmGiaoHang – lấy đơn đang giao của shipper hiện tại
        // ============================================================
        public static DataTable GetPhieuGiaoHangByShipper(string maNV)
        {
            using (var conn = GetConnection())
            {
                const string sql = @"
                    SELECT  PGH.MAVANDON        AS MaPhieuGiao,
                            PGH.MADON           AS MaDonHang,
                            ISNULL(KH.HOTEN, N'Không xác định') AS TenKhach,
                            PGH.DIACHINHA       AS DiaChi,
                            CASE DH.PHUONGTHUCTT
                                WHEN N'COD' THEN DH.TONGTIEN
                                ELSE 0
                            END                 AS TienThuHo,
                            PGH.TRANGTHAI       AS TrangThai,
                            PGH.NGAYGIAO        AS NgayGiao
                    FROM    PHIEUGIAOHANG PGH
                    JOIN    DONHANG       DH  ON DH.MADON = PGH.MADON
                    LEFT JOIN KHACHHANG   KH  ON KH.MAKH  = DH.MAKH
                    WHERE   PGH.MANV = @MaNV
                    ORDER BY PGH.NGAYGIAO DESC";
                var da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaNV", maNV);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ============================================================
        // 15. CẬP NHẬT KẾT QUẢ GIAO HÀNG
        //     thanhCong=true  → PHIEUGIAOHANG='DaGiao',  DONHANG='HoanThanh'
        //     thanhCong=false → PHIEUGIAOHANG='ThatBai',  DONHANG='DaHuy'
        // ============================================================
        public static bool CapNhatKetQuaGiaoHang(string maVanDon, bool thanhCong, string lyDoThatBai = "")
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    string trangThaiPGH = thanhCong ? "DaGiao" : "ThatBai";
                    string trangThaiDH = thanhCong ? "HoanThanh" : "DaHuy";

                    // 1. Lấy MADON từ PHIEUGIAOHANG
                    var cmdGetDon = new SqlCommand(
                        "SELECT MADON FROM PHIEUGIAOHANG WHERE MAVANDON = @mvd", conn, trans);
                    cmdGetDon.Parameters.AddWithValue("@mvd", maVanDon);
                    string maDon = cmdGetDon.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(maDon))
                        throw new Exception("Không tìm thấy đơn hàng cho phiếu: " + maVanDon);

                    // 2. UPDATE PHIEUGIAOHANG
                    var cmdPGH = new SqlCommand(@"
                        UPDATE PHIEUGIAOHANG
                        SET    TRANGTHAI    = @tt,
                               LYDOTHATBAI  = @ly
                        WHERE  MAVANDON = @mvd", conn, trans);
                    cmdPGH.Parameters.AddWithValue("@tt", trangThaiPGH);
                    cmdPGH.Parameters.AddWithValue("@ly", string.IsNullOrEmpty(lyDoThatBai)
                                                            ? (object)DBNull.Value : lyDoThatBai);
                    cmdPGH.Parameters.AddWithValue("@mvd", maVanDon);
                    cmdPGH.ExecuteNonQuery();

                    // 3. UPDATE DONHANG.TRANGTHAIDON
                    var cmdDH = new SqlCommand(
                        "UPDATE DONHANG SET TRANGTHAIDON = @tt WHERE MADON = @md", conn, trans);
                    cmdDH.Parameters.AddWithValue("@tt", trangThaiDH);
                    cmdDH.Parameters.AddWithValue("@md", maDon);
                    cmdDH.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi cập nhật kết quả giao hàng:\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}