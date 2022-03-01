using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;
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
        protected HWND _handle;
        private readonly WNDPROC _wndProc;

        /// <summary>
        /// Create 
        /// </summary>
        public Win32Window() : this(Guid.NewGuid().ToString(), "")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowClassName"></param>
        /// <param name="windowText"></param>
        public Win32Window(string windowClassName, string windowText) : this(windowClassName, windowText, true, NULL)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowClassName"></param>
        /// <param name="windowText"></param>
        /// <param name="needRegisterClass"></param>
        /// <param name="parentWindow"></param>
        public Win32Window(string windowClassName, string windowText, bool needRegisterClass, HWND parentWindow)
            : this(windowClassName, windowText, needRegisterClass, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, WS_TILEDWINDOW, WS_EX_OVERLAPPEDWINDOW, parentWindow)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowClassName"></param>
        /// <param name="windowText"></param>
        /// <param name="needRegisterClass"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="style"></param>
        /// <param name="stylesEx"></param>
        /// <param name="parentWindow"></param>
        public Win32Window(string windowClassName, string windowText, bool needRegisterClass, int x, int y, int width, int height, WindowStyles style, WindowStylesEx stylesEx, HWND parentWindow)
        {
            _flags |= Win32WindowFlags.OwnWindow;
            var hInstance = GetModuleHandle(NULL);
            _wndProc = (Wndproc)WindowProc;

            if (needRegisterClass)
            {
                RegisterWindowClass(hInstance, windowClassName);
            }

            _handle = CreateWindowImpl(windowClassName, windowText, x, y, width, height, (uint)style, (uint)stylesEx, parentWindow, hInstance);

            if (_handle == NULL)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            DWMInfo = new DWMInfo(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowHandle"></param>
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
        protected virtual HWND CreateWindowImpl(string windowClassName, string windowText, int x, int y, int width, int height, uint style, uint styleEx, HWND parentWindow, HINSTANCE hInstance)
        {
            return CreateWindowEx((WindowStylesEx)styleEx, windowClassName, windowText, (WindowStyles)style, x, y, width, height, parentWindow, NULL, hInstance, NULL);
        }
    }
}
