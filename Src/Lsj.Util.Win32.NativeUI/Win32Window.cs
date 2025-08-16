using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemColors;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.ExtendedWindowStyles;
using static Lsj.Util.Win32.Enums.StandardCursors;
using static Lsj.Util.Win32.Enums.SystemIcons;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.NativeUI
{
    /// <summary>
    /// Native Win32 Window
    /// </summary>
    public partial class Win32Window : DisposableClass
    {
        /// <summary>
        /// Window Handle
        /// </summary>
        private HWND _handle;
        private readonly LPCWSTR? _windowClassName;
        private readonly HINSTANCE _hInstance;
        private Wndproc? _wndProc;
        private IntPtr _hookedWndProc;

        /// <summary>
        /// Create new window
        /// </summary>
        public Win32Window() : this("", Guid.NewGuid().ToString())
        {
        }

        /// <summary>
        /// Create new window
        /// </summary>
        /// <param name="windowText">window text</param>
        /// <param name="windowClassName">window class name, auto generate if <see langword="null"/></param>
        /// <param name="classStyles">window class style</param>
        /// <param name="windowProc">window class procedure, use <see cref="WindowProc"/> if <see href="NULL"/></param>
        /// <param name="hInstance">window class hInstance</param>
        /// <param name="hIcon">window class hIcon, <see cref="IDI_APPLICATION"/> if <see href="NULL"/></param>
        /// <param name="hCursor">window class hCursor, <see cref="IDC_ARROW"/> if <see href="NULL"/></param>
        /// <param name="hbrBackground">window class hbrBackground, <see cref="COLOR_WINDOW"/> if <see href="NULL"/></param>
        /// <param name="x">window x</param>
        /// <param name="y">window y</param>
        /// <param name="width">window width</param>
        /// <param name="height">window height</param>
        /// <param name="style">window style</param>
        /// <param name="stylesEx">window style ex</param>
        /// <param name="parentWindow">parent window</param>
        /// <param name="hMenu">window menu</param>
        public Win32Window(string windowText, string? windowClassName = null, WindowClassStyles classStyles = WindowClassStyles.CS_DBLCLKS,
            WNDPROC windowProc = default, HINSTANCE hInstance = default, HICON hIcon = default, HCURSOR? hCursor = default,
            HBRUSH? hbrBackground = null, int x = CW_USEDEFAULT, int y = CW_USEDEFAULT, int width = CW_USEDEFAULT,
            int height = CW_USEDEFAULT, WindowStyles style = WS_OVERLAPPEDWINDOW, ExtendedWindowStyles stylesEx = WS_EX_OVERLAPPEDWINDOW,
            HWND parentWindow = default, HMENU hMenu = default)
        {
            _flags |= Win32WindowFlags.OwnWindow;

            if ((nint)windowProc == NULL)
            {
                _wndProc = WindowProc;
                _flags |= Win32WindowFlags.WindowProcUseThis;
            }
            else
            {
                _wndProc = windowProc;
            }
            windowClassName ??= "Win32Window-" + Guid.NewGuid().ToString();
            _windowClassName = (nint)Win32WindowClassRegisterHelper.Register(windowClassName, classStyles, _wndProc, hInstance,
                hIcon, hCursor, hbrBackground ?? COLOR_WINDOW);
            _flags |= Win32WindowFlags.RegisteredClass;

            _handle = CreateWindowImpl(_windowClassName, windowText, x, y, width, height, (uint)style, (uint)stylesEx, parentWindow, hMenu, hInstance);

            DWMInfo = new DWMInfo(this);
        }

        /// <summary>
        /// Create new window and register class
        /// </summary>
        /// <param name="windowClass">window class</param>
        /// <param name="windowText"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="style"></param>
        /// <param name="stylesEx"></param>
        /// <param name="parentWindow"></param>
        /// <param name="hMenu"></param>
        public Win32Window(WNDCLASSEX windowClass, string windowText, int x = CW_USEDEFAULT, int y = CW_USEDEFAULT,
           int width = CW_USEDEFAULT, int height = CW_USEDEFAULT, WindowStyles style = WS_OVERLAPPEDWINDOW,
           ExtendedWindowStyles stylesEx = WS_EX_OVERLAPPEDWINDOW, HWND parentWindow = default, HMENU hMenu = default)
            : this((nint)RegisterWindowClass(windowClass), windowClass.hInstance, windowText)
        {
            _flags |= Win32WindowFlags.RegisteredClass;
            _hInstance = windowClass.hInstance;
        }

        /// <summary>
        /// Create new window with existed window class
        /// </summary>
        /// <param name="windowClass"></param>
        /// <param name="hInstance"></param>
        /// <param name="windowText"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="style"></param>
        /// <param name="stylesEx"></param>
        /// <param name="parentWindow"></param>
        /// <param name="hMenu"></param>
        public Win32Window(LPCWSTR windowClass, HINSTANCE hInstance, string windowText, int x = CW_USEDEFAULT,
            int y = CW_USEDEFAULT, int width = CW_USEDEFAULT, int height = CW_USEDEFAULT, WindowStyles style = WS_OVERLAPPEDWINDOW,
            ExtendedWindowStyles stylesEx = WS_EX_OVERLAPPEDWINDOW, HWND parentWindow = default, HMENU hMenu = default)
        {
            _flags |= Win32WindowFlags.OwnWindow;
            _windowClassName = windowClass;
            _handle = CreateWindowImpl(windowClass, windowText, x, y, width, height, (uint)style, (uint)stylesEx, parentWindow, hMenu, hInstance);

            DWMInfo = new DWMInfo(this);
        }

        /// <summary>
        /// Init from existed window
        /// </summary>
        /// <param name="windowHandle">existed window handle</param>
        public Win32Window(HWND windowHandle)
        {
            if (!IsWindow(windowHandle))
            {
                throw new ArgumentException("Invalid Window Handle");
            }
            _handle = windowHandle;
            if (ProcessID != GetProcessId(GetCurrentProcess()))
            {
                _flags |= Win32WindowFlags.OtherProcess;
            }

            DWMInfo = new DWMInfo(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowClassName"></param>
        /// <param name="windowText"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="style"></param>
        /// <param name="styleEx"></param>
        /// <param name="parentWindow"></param>
        /// <param name="hInstance"></param>
        /// <param name="hMenu"></param>
        protected virtual HWND CreateWindowImpl(LPCWSTR windowClassName, string windowText, int x, int y, int width, int height, uint style, uint styleEx, HWND parentWindow, HMENU hMenu, HINSTANCE hInstance)
        {
            var hWnd = CreateWindowEx((ExtendedWindowStyles)styleEx, windowClassName, windowText, (WindowStyles)style, x, y, width, height, parentWindow, hMenu, hInstance, NULL);
            if (hWnd == NULL)
            {
                throw new Win32Exception();
            }
            return hWnd;
        }
    }
}
