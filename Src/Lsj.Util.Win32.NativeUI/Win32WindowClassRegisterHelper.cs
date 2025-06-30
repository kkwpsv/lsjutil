using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.ComponentModel;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ClassStyles;
using static Lsj.Util.Win32.Enums.ImageTypes;
using static Lsj.Util.Win32.Enums.LoadImageFlags;
using static Lsj.Util.Win32.Enums.SystemColors;
using static Lsj.Util.Win32.Enums.SystemCursors;
using static Lsj.Util.Win32.Enums.SystemIcons;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.NativeUI
{
    /// <summary>
    /// Window class register helper
    /// </summary>
    public static class Win32WindowClassRegisterHelper
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="className">window class name, auto generate if <see langword="null"/></param>
        /// <param name="classStyles">window class style</param>
        /// <param name="windowProc">window class procedure, use <see cref="DefWindowProc"/> if <see href="NULL"/></param>
        /// <param name="hInstance">window class hInstance</param>
        /// <param name="hIcon">window class hIcon, <see cref="IDI_APPLICATION"/> if <see href="NULL"/></param>
        /// <param name="hCursor">window class hCursor, <see cref="IDC_ARROW"/> if <see href="NULL"/></param>
        /// <param name="hbrBackground">window class hbrBackground, <see cref="COLOR_WINDOW"/> if <see href="NULL"/></param>
        /// <returns></returns>
        /// <exception cref="Win32Exception"></exception>
        public static ATOM Register(LPWSTR className, ClassStyles classStyles = CS_DBLCLKS, WNDPROC windowProc = default,
            HINSTANCE hInstance = default, HICON? hIcon = default, HCURSOR? hCursor = default, HBRUSH? hbrBackground = null)
        {
            var @class = new WNDCLASSEX
            {
                cbSize = UnsafePInvokeExtensions.SizeOf<WNDCLASSEX>(),
                style = classStyles,
                lpfnWndProc = (IntPtr)windowProc == NULL ? GetDefWindowProc() : windowProc,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = hInstance,
                hIcon = hIcon ?? LoadImage(NULL, (IntPtr)IDI_APPLICATION, IMAGE_ICON, 0, 0, LR_SHARED),
                hCursor = hCursor ?? LoadImage(NULL, (IntPtr)IDC_ARROW, IMAGE_CURSOR, 0, 0, LR_SHARED),
                hbrBackground = hbrBackground ?? COLOR_WINDOW,
                lpszMenuName = NULL,
                lpszClassName = className.Handle,
            };
            var result = RegisterClassEx(@class);
            if (result == 0)
            {
                throw new Win32Exception();
            }
            return result;
        }

        static WNDPROC _wndProc;

        private static WNDPROC GetDefWindowProc()
        {
            if ((IntPtr)_wndProc == NULL)
            {
                _wndProc = (WNDPROC)(IntPtr)GetProcAddress(GetModuleHandle("user32.dll"), "DefWindowProcW");
            }

            return _wndProc;
        }
    }
}
