using System;

// ================================================================
// PharmacyManagement.cs  –  SessionManager mở rộng
//
// THÊM MỚI:
//  - Hỗ trợ phiên đăng nhập của KHÁCH HÀNG (ThanhVien / Si)
//  - Properties IsKhachHang, MaKH, TenKH, LoaiKH, HangTV, DiemTichLuy
//  - LoginKhachHang / LoginKhachHangSi / LogoutKhachHang
//  - IsNhanVien giữ nguyên để không break code cũ
// ================================================================

namespace PharmacyManagement
{
    /// <summary>
    /// Quản lý phiên đăng nhập toàn hệ thống.
    /// Hỗ trợ đồng thời 2 loại phiên: nhân viên nội bộ và khách hàng.
    /// </summary>
    public static class SessionManager
    {
        // ──────────────────────────────────────────────────────────
        // PHIÊN NHÂN VIÊN  (giữ nguyên từ code cũ)
        // ──────────────────────────────────────────────────────────

        public static string MaNV { get; private set; }
        public static string TenNV { get; private set; }
        public static string VaiTro { get; private set; }
        public static int CapDoQuyen { get; private set; }
        public static bool IsLoggedIn { get; private set; }

        /// <summary>Đăng nhập nhân viên (gọi từ frmDangNhap).</summary>
        public static void Login(string maNV, string tenNV, string vaiTro, int capDo)
        {
            MaNV = maNV;
            TenNV = tenNV;
            VaiTro = vaiTro;
            CapDoQuyen = capDo;
            IsLoggedIn = true;
        }

        /// <summary>Đăng xuất nhân viên.</summary>
        public static void Logout()
        {
            MaNV = TenNV = VaiTro = string.Empty;
            CapDoQuyen = 0;
            IsLoggedIn = false;
        }

        // Kiểm tra quyền: QuanLy hoặc DuocSi cấp 2+
        public static bool IsNhanVien => IsLoggedIn && !string.IsNullOrEmpty(MaNV);
        public static bool IsQuanLy => IsLoggedIn && VaiTro == "QuanLy";
        public static bool IsDuocSi => IsLoggedIn && (VaiTro == "DuocSi" || VaiTro == "QuanLy");
        public static bool IsNhanVienKho => IsLoggedIn && (VaiTro == "NhanVienKho" || VaiTro == "QuanLy");

        // ──────────────────────────────────────────────────────────
        // PHIÊN KHÁCH HÀNG  (THÊM MỚI)
        // ──────────────────────────────────────────────────────────

        /// <summary>Mã khách hàng đang đăng nhập (KH001…).</summary>
        public static string MaKH { get; private set; }

        /// <summary>Họ tên khách hàng.</summary>
        public static string TenKH { get; private set; }

        /// <summary>Loại KH: 'ThanhVien' | 'Si' | 'VangLai'.</summary>
        public static string LoaiKH { get; private set; }

        /// <summary>Hạng thẻ thành viên: 'Dong' | 'Bac' | 'Vang' (ThanhVien).</summary>
        public static string HangTV { get; private set; }

        /// <summary>Điểm tích lũy (ThanhVien).</summary>
        public static int DiemTichLuy { get; private set; }

        /// <summary>Tên công ty (KhachSi).</summary>
        public static string TenCongTy { get; private set; }

        /// <summary>Tỉ lệ chiết khấu sỉ (0.0 – 1.0).</summary>
        public static float TyLeChietKhau { get; private set; }

        /// <summary>True nếu có phiên khách hàng đang hoạt động.</summary>
        public static bool IsKhachHangLoggedIn { get; private set; }

        // ── Đăng nhập KHÁCH THÀNH VIÊN ────────────────────────────
        public static void LoginKhachHang(
            string maKH, string tenKH, string hangTV, int diemTichLuy)
        {
            MaKH = maKH;
            TenKH = tenKH;
            LoaiKH = "ThanhVien";
            HangTV = hangTV;
            DiemTichLuy = diemTichLuy;
            TenCongTy = string.Empty;
            TyLeChietKhau = 0f;
            IsKhachHangLoggedIn = true;
        }

        // ── Đăng nhập KHÁCH SỈ ────────────────────────────────────
        public static void LoginKhachHangSi(
            string maKH, string tenKH, string tenCongTy, float tyLeChietKhau)
        {
            MaKH = maKH;
            TenKH = tenKH;
            LoaiKH = "Si";
            HangTV = string.Empty;
            DiemTichLuy = 0;
            TenCongTy = tenCongTy;
            TyLeChietKhau = tyLeChietKhau;
            IsKhachHangLoggedIn = true;
        }

        // ── Đặt KHÁCH VÃNG LAI (không cần đăng nhập) ─────────────
        public static void SetKhachVangLai(string maKH = "", string tenKH = "Khách vãng lai")
        {
            MaKH = maKH;
            TenKH = tenKH;
            LoaiKH = "VangLai";
            HangTV = string.Empty;
            DiemTichLuy = 0;
            TenCongTy = string.Empty;
            TyLeChietKhau = 0f;
            IsKhachHangLoggedIn = false;   // vãng lai không cần đăng nhập
        }

        // ── Đăng xuất KHÁCH HÀNG ──────────────────────────────────
        public static void LogoutKhachHang()
        {
            MaKH = TenKH = LoaiKH = HangTV = TenCongTy = string.Empty;
            DiemTichLuy = 0;
            TyLeChietKhau = 0f;
            IsKhachHangLoggedIn = false;
        }

        // ── Trạng thái hiển thị ────────────────────────────────────

        /// <summary>Chuỗi hiển thị trên tiêu đề sau đăng nhập.</summary>
        public static string GetDisplayName()
        {
            if (IsLoggedIn)
                return $"{TenNV}  [{VaiTro}]";
            if (IsKhachHangLoggedIn)
                return LoaiKH == "Si"
                    ? $"{TenKH} – {TenCongTy} [Sỉ]"
                    : $"{TenKH} [{HangTV}]  ★{DiemTichLuy}đ";
            return "Chưa đăng nhập";
        }
    }
}