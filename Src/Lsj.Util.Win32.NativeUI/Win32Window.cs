using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ClassStyles;
using static Lsj.Util.Win32.Enums.SystemColors;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.LoadImageFlags;

namespace Lsj.Util.Win32.NativeUI
{
    /// <summary>
    /// Native Win32 Window
    /// </summary>
    public class Win32Window : DisposableClass
    {
        private HWND _window;
        private readonly WNDPROC _wndProc;

        /// <summary>
        /// Window Handle
        /// </summary>
        public HWND Handle => _window;

        /// <summary>
        /// 
        /// </summary>
        public Win32Window() : this(Guid.NewGuid().ToString(), "")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpUnmanagedResources()
        {
            if (_window != NULL)
            {
                DestroyWindow(_window);
                _window = NULL;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowClassName"></param>
        /// <param name="windowName"></param>
        public Win32Window(string windowClassName, string windowName)
        {
            var hInstance = GetModuleHandle(null);
            _wndProc = WindowProc;

            using var marshal = new StringToIntPtrMarshaler(windowClassName);
            var wndclass = new WNDCLASSEX
            {
                cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX)),
                style = CS_DBLCLKS,
                lpfnWndProc = _wndProc,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = hInstance,
                hIcon = LoadImage(NULL, (IntPtr)SystemIcons.IDI_APPLICATION, ImageTypes.IMAGE_ICON, 0, 0, LR_SHARED),
                hCursor = LoadImage(NULL, (IntPtr)SystemCursors.IDC_ARROW, ImageTypes.IMAGE_CURSOR, 0, 0, LR_SHARED),
                hbrBackground = COLOR_WINDOW,
                lpszMenuName = IntPtr.Zero,
                lpszClassName = marshal.GetPtr(),
            };
            if (RegisterClassEx(wndclass) != 0)
            {
                _window = CreateWindowEx(WS_EX_OVERLAPPEDWINDOW, windowClassName, windowName, WS_TILEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT,
                    CW_USEDEFAULT, CW_USEDEFAULT, IntPtr.Zero, IntPtr.Zero, hInstance, IntPtr.Zero);
                if (_window == NULL)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        /// <summary>
        /// Show
        /// </summary>
        public void Show()
        {
            ShowWindow(_window, ShowWindowCommands.SW_SHOWNORMAL);
        }

        /// <summary>
        /// Hide
        /// </summary>
        public void Hide()
        {
            ShowWindow(_window, ShowWindowCommands.SW_HIDE);
        }

        /// <summary>
        /// Set Window Size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetWindowSize(int width, int height)
        {
            SetWindowPos(_window, IntPtr.Zero, 0, 0, width, height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER);
        }

        /// <summary>
        /// Start Message Loop
        /// </summary>
        public void StartMessageLoop()
        {
            while (GetMessage(out var msg, NULL, 0, 0))
            {
                try
                {
                    TranslateMessage(msg);
                    DispatchMessage(msg);
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Window Proc
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected virtual LRESULT WindowProc(HWND hWnd, WindowsMessages msg, WPARAM wParam, LPARAM lParam)
        {
            try
            {
                switch (msg)
                {
                    case WindowsMessages.WM_DESTROY:
                        PostQuitMessage(0);
                        return 0;
                    default:
                        return DefWindowProc(hWnd, msg, wParam, lParam);
                }
            }
            catch
            {
                //The finally in Main won't run if exception is thrown in this method.
                //This may be because this method was called by system code.
                //So we must handle exception here.
                DestroyWindow(_window);
                return 0;
            }
        }
    }
}
