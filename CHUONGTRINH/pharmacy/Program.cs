using System;
using System.Windows.Forms;

// ================================================================
// Program.cs  –  CẬP NHẬT
//
// Luồng khởi động mới:
//   1. Mở frmTrangChu (trang chủ, không yêu cầu đăng nhập)
//   2. Người dùng tự chọn:
//      - Khách vãng lai : duyệt sản phẩm, thêm vào giỏ, đặt hàng
//      - KH thành viên / Sỉ : bấm "Đăng nhập" → frmDangNhapKhachHang
//      - Nhân viên : bấm "🔑 NV" → frmDangNhap → frmMain
// ================================================================

namespace PharmacyManagement
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Đặt trạng thái mặc định: Khách vãng lai
            SessionManager.SetKhachVangLai();

            // Chạy thẳng trang chủ – không yêu cầu đăng nhập trước
            Application.Run(new frmTrangChu());
        }
    }
}