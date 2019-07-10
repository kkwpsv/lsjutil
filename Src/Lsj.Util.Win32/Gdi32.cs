using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Gdi32.dll
    /// </summary>
    public static class Gdi32
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleBitmap", SetLastError = true)]
        public static extern IntPtr CreateCompatibleBitmap([In] IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectObject", SetLastError = true)]
        public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteDC", SetLastError = true)]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteObject", SetLastError = true)]
        public static extern bool DeleteObject(IntPtr hObject);
    }
}
