using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NhaThuocPharmacy
{
    public static class UIHelper
    {
        // Sử dụng thư viện User32 của Windows để tạo Placeholder (chữ mờ) cho TextBox
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// Hàm tạo chữ mờ (Placeholder) cho TextBox trong .NET Framework
        /// </summary>
        /// <param name="textBox">Tên TextBox cần đặt</param>
        /// <param name="placeholderText">Nội dung chữ mờ</param>
        public static void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholderText);
        }
    }
}