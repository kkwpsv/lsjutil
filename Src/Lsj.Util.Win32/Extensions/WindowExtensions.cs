using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Extensions
{
    /// <summary>
    /// Window Extensions
    /// </summary>
    public static class WindowExtensions
    {
        /// <summary>
        /// Get All Top-Level Window Handle (Use <see cref="EnumWindows"/>)
        /// </summary>
        /// <returns></returns>
        public static HWND[] GetAllTopLevelWindowHandle() => GetAllWindow(x => x, _ => (true, false, true), _ => (false, false));

        /// <summary>
        /// Get All Window Handle (Use <see cref="EnumWindows"/> with <see cref="EnumChildWindows"/>)
        /// </summary>
        /// <returns></returns>
        public static HWND[] GetAllWindowHandle() => GetAllWindow(x => x, _ => (true, true, true), _ => (true, true));

        /// <summary>
        /// Get All Window with result selector and filter
        /// </summary>
        /// <typeparam name="T">result type</typeparam>
        /// <param name="resultSelector">result selector</param>
        /// <param name="filter">filter</param>
        /// <param name="descendantsFilter">child filter</param>
        /// <returns></returns>
        public static T[] GetAllWindow<T>(Func<HWND, T> resultSelector, Func<HWND, (bool includeSelf, bool includeDescendants, bool continueEnum)> filter, Func<HWND, (bool includeSelf, bool continueEnum)> descendantsFilter)
        {
            var result = new List<T>();
            Wndenumproc enumFunc = (handle, _) =>
            {
                var (includeSelf, includeDescendants, continueEnum) = filter(handle);
                if (includeSelf)
                {
                    result.Add(resultSelector(handle));
                }
                if (includeDescendants)
                {
                    EnumChildWindows(handle, (WNDENUMPROC)((childHandle, _) =>
                    {
                        var (includeSelf, continueEnum) = descendantsFilter(childHandle);
                        if (includeSelf)
                        {
                            result.Add(resultSelector(childHandle));
                        }
                        return continueEnum;
                    }), NULL);
                }
                return continueEnum;
            };

            EnumWindows(enumFunc, IntPtr.Zero);

            GC.KeepAlive(enumFunc);

            return result.ToArray();
        }

        /// <summary>
        /// Get All Top-Level Window Handle (Use <see cref="EnumWindows"/>
        /// </summary>
        /// <returns></returns>
        public static (HWND WindowHandle, string Text)[] GetAllTopLevelWindowHandleWithText()
        {
            var result = new List<(HWND, string)>();
            Wndenumproc enumFunc = (handle, _) =>
            {
                SetLastError(0);
                var length = GetWindowTextLength(handle);
                var code = GetLastError();
                if (code == 0)
                {
                    var sb = new StringBuffer(length);
                    GetWindowText(handle, sb, 20);
                    code = GetLastError();
                    if (code == 0)
                    {
                        result.Add((handle, sb.ToString()));
                        return true;
                    }
                }
                result.Add((handle, null));
                return true;
            };

            EnumWindows(enumFunc, IntPtr.Zero);

            GC.KeepAlive(enumFunc);
            return result.ToArray();
        }

        /// <summary>
        /// Get Window Screenshot (Use GDI)
        /// </summary>
        /// <param name="hwnd">
        /// The window to screenshot. If <see cref="NULL"/>, the result will be of the main display monitor.
        /// </param>
        /// <returns>The <see cref="HBITMAP"/>, must use <see cref="DeleteObject"/> to delete it.</returns>
        public static HBITMAP GetWindowScreenshot(HWND hwnd) => GetWindowScreenshot(hwnd, SRCCOPY);

        /// <summary>
        /// Get Window Screenshot (Use GDI with <see cref="CAPTUREBLT"/>)
        /// </summary>
        /// <param name="hwnd">
        /// The window to screenshot. If <see cref="NULL"/>, the result will be of the main display monitor.
        /// </param>
        /// <returns>The <see cref="HBITMAP"/>, must use <see cref="DeleteObject"/> to delete it.</returns>
        public static HBITMAP GetWindowScreenshotWithCaptureBlt(HWND hwnd) => GetWindowScreenshot(hwnd, SRCCOPY | CAPTUREBLT);

        /// <summary>
        /// Get Window Screenshot (Use GDI)
        /// </summary>
        /// <param name="hwnd">
        /// The window to screenshot. If <see cref="NULL"/>, the result will be of the main display monitor.
        /// </param>
        /// <param name="rasterCodes">
        /// The rasterCodes for <see cref="BitBlt"/>
        /// </param>
        /// <returns>The <see cref="HBITMAP"/>, must use <see cref="DeleteObject"/> to delete it.</returns>
        public static HBITMAP GetWindowScreenshot(HWND hwnd, RasterCodes rasterCodes)
        {
            HDC windowDC = NULL;
            HDC destDC = NULL;
            HBITMAP destBitmap = NULL;

            try
            {
                windowDC = GetWindowDC(hwnd);
                if (windowDC == NULL)
                {
                    throw new Win32Exception();
                }

                if (!GetWindowRect(hwnd == NULL ? GetDesktopWindow() : hwnd, out var rect))
                {
                    throw new Win32Exception();
                }
                var width = rect.right - rect.left;
                var height = rect.bottom - rect.top;

                destDC = CreateCompatibleDC(windowDC);
                if (destDC == NULL)
                {
                    throw new Win32Exception();
                }

                destBitmap = CreateCompatibleBitmap(windowDC, width, height);
                if (destBitmap == NULL)
                {
                    throw new Win32Exception();
                }

                SelectObject(destDC, destBitmap);

                if (!BitBlt(destDC, 0, 0, width, height, windowDC, 0, 0, rasterCodes))
                {
                    throw new Win32Exception();
                }

            }
            finally
            {
                ReleaseDC(hwnd, windowDC);
                DeleteDC(destDC);
            }
            return destBitmap;
        }

        /// <summary>
        /// Get Foreground Window Screenshot (Use GDI.)
        /// BitBlt from screen dc. Only work for foreground window.
        /// </summary>
        /// <param name="hwnd">
        /// The window to screenshot. If <see cref="NULL"/>, the result will be of the main display monitor.
        /// </param>
        /// <returns>The <see cref="HBITMAP"/>, must use <see cref="DeleteObject"/> to delete it.</returns>
        public static HBITMAP GetForegroundWindowScreenshot(HWND hwnd)
        {
            HDC desktopDC = NULL;
            HDC destDC = NULL;
            HBITMAP destBitmap = NULL;

            try
            {
                desktopDC = GetDC(NULL);
                if (desktopDC == NULL)
                {
                    throw new Win32Exception();
                }

                if (!GetWindowRect(hwnd, out var rect))
                {
                    throw new Win32Exception();
                }
                var width = rect.right - rect.left;
                var height = rect.bottom - rect.top;

                destDC = CreateCompatibleDC(desktopDC);
                if (destDC == NULL)
                {
                    throw new Win32Exception();
                }

                destBitmap = CreateCompatibleBitmap(desktopDC, width, height);
                if (destBitmap == NULL)
                {
                    throw new Win32Exception();
                }

                SelectObject(destDC, destBitmap);

                if (!BitBlt(destDC, rect.left, rect.top, width, height, desktopDC, 0, 0, SRCCOPY))
                {
                    throw new Win32Exception();
                }

            }
            finally
            {
                ReleaseDC(hwnd, desktopDC);
                DeleteDC(destDC);
            }
            return destBitmap;
        }
    }
}
