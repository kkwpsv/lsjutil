using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Extensions.Gdi
{
    /// <summary>
    /// Gdi screen capturer
    /// </summary>
    public class GdiScreenCapturer
    {
        /// <summary>
        /// Capture image of primary monitor
        /// </summary>
        /// <returns></returns>
        public HBITMAP CapturePrimaryMonitor() => CaptureWindow(GetDesktopWindow());

        /// <summary>
        /// Capture image of a monitor (The process/thread should be dpi aware, or the image size will be wrong.)
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns></returns>
        /// <exception cref="GdiScreenCapturerException"></exception>
        public HBITMAP CaptureMonitor(HMONITOR monitor)
        {
            MONITORINFOEX monitorInfo = new MONITORINFOEX
            {
                cbSize = UnsafePInvokeExtensions.SizeOf<MONITORINFOEX>(),
            };

            if (!GetMonitorInfo(monitor, ref monitorInfo))
            {
                throw new GdiScreenCapturerException("GetMonitorInfo failed.");
            }

            return CaptureWindow(GetDesktopWindow(), rect: monitorInfo.rcMonitor);
        }

        /// <summary>
        /// Capture image of virtual screen
        /// </summary>
        /// <returns></returns>
        public HBITMAP CaptureVirtualScreen() => CaptureWindow(GetDesktopWindow());

        /// <summary>
        /// Capture image of a window
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="rasterCodes"></param>
        /// <param name="rect">The rect coordinates is based on the window device context.</param>
        /// <returns></returns>
        /// <exception cref="GdiScreenCapturerException"></exception>
        public HBITMAP CaptureWindow(HWND hwnd, RasterCodes rasterCodes = SRCCOPY | CAPTUREBLT, RECT? rect = null)
        {
            HDC windowDC = NULL;
            HDC destDC = NULL;
            HBITMAP destBitmap = NULL;

            try
            {
                windowDC = GetWindowDC(hwnd);
                if (windowDC == NULL)
                {
                    throw new GdiScreenCapturerException("GetWindowDC failed.");
                }

                RECT captureRect;
                if (rect != null)
                {
                    captureRect = rect.Value;
                }
                else
                {
                    if (GetClipBox(windowDC, out captureRect) == RegionFlags.ERROR)
                    {
                        throw new GdiScreenCapturerException("GetWindowRect failed.", GetLastWin32Exception());
                    }
                }

                var width = captureRect.right - captureRect.left;
                var height = captureRect.bottom - captureRect.top;

                destDC = CreateCompatibleDC(windowDC);
                if (destDC == NULL)
                {
                    throw new GdiScreenCapturerException("CreateCompatibleDC failed.");
                }

                destBitmap = CreateCompatibleBitmap(windowDC, width, height);
                if (destBitmap == NULL)
                {
                    throw new GdiScreenCapturerException("CreateCompatibleBitmap failed.");
                }

                SelectObject(destDC, destBitmap);

                if (!BitBlt(destDC, 0, 0, width, height, windowDC, 0, 0, rasterCodes))
                {
                    throw new GdiScreenCapturerException("BitBlt failed.", GetLastWin32Exception());
                }
            }
            finally
            {
                if (windowDC != NULL)
                {
                    ReleaseDC(hwnd, windowDC);
                }

                DeleteDC(destDC);
            }
            return destBitmap;
        }

        private Win32Exception? GetLastWin32Exception()
        {
            var code = Marshal.GetLastWin32Error();
            if (code != 0)
            {
                return new Win32Exception(code);
            }
            return null;
        }
    }

    /// <summary>
    /// Gdi screen capturer exception
    /// </summary>
    public class GdiScreenCapturerException : Exception
    {
        internal GdiScreenCapturerException(string message, Exception? innerException = null) : base(message, innerException)
        {

        }
    }
}
