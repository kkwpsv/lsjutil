using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Lsj.Util.WPF
{
    public static class WindowHelper
    {
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong(IntPtr hMenu, int nIndex, int dwNewLong);


        public static void SetCanMaxmize(this Window window, bool canMaxmize)
        {
            int GWL_STYLE = -16;
            int WS_MAXIMIZEBOX = 0x00010000;

            var handle = new WindowInteropHelper(window).Handle;
            int nStyle = GetWindowLong(handle, GWL_STYLE);
            if (canMaxmize)
            {
                nStyle |= WS_MAXIMIZEBOX;
            }
            else
            {
                nStyle &= ~(WS_MAXIMIZEBOX);
            }
            SetWindowLong(handle, GWL_STYLE, nStyle);
        }
    }
}
