using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// User32.dll
    /// </summary>
    public static class User32
    {
        public delegate IntPtr WndProc(IntPtr hWnd, WindowsMessages msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefWindowProcW", SetLastError = true)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, WindowsMessages uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", SetLastError = true)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, IntPtr lpCursorName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterClassExW", SetLastError = true)]
        public static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", SetLastError = true)]
        public static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWindowExW", SetLastError = true)]
        public static extern IntPtr CreateWindowEx(WindowStylesEx dwExStyle, [MarshalAs(UnmanagedType.LPWStr)]string lpClassName,
            [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, WindowStyles dwStyle, int x, int y, int nWidth, int nHeight,
            IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessageW", SetLastError = true)]
        public static extern int GetMessage(out WindowsMessages lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateMessage", SetLastError = true)]
        public static extern bool TranslateMessage([In] ref WindowsMessages lpMsg);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DispatchMessageW", SetLastError = true)]
        public static extern IntPtr DispatchMessage([In] ref WindowsMessages lpmsg);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostQuitMessage", SetLastError = true)]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowRect", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDC", SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateLayeredWindow", SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pptSrc,
            uint crKey, [In] ref BLENDFUNCTION pblend, uint dwFlags);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemMetrics", SetLastError = true)]
        public static extern int GetSystemMetrics(SystemMetric smIndex);
    }
}
