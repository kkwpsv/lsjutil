using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Extensions
{
    /// <summary>
    /// Native Win32 Window
    /// </summary>
    public class Win32Window
    {
        private readonly IntPtr _window;

        /// <summary>
        /// Window Handle
        /// </summary>
        public IntPtr Handle => _window;

        /// <summary>
        /// 
        /// </summary>
        public Win32Window() : this(Guid.NewGuid().ToString(), "")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowClassName"></param>
        /// <param name="windowName"></param>
        public Win32Window(string windowClassName, string windowName)
        {
            var hInstance = Process.GetCurrentProcess().Handle;

            using var marshal = new StringToIntPtrMarshaler(windowClassName);
            var wndclass = new WNDCLASSEX
            {
                cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX)),
                style = ClassStyles.CS_DBLCLKS,
                lpfnWndProc = WindowProc,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = hInstance,
                hIcon = LoadIcon(hInstance, SystemIcons.IDI_APPLICATION),
                hCursor = LoadCursor(IntPtr.Zero, SystemCursors.IDC_ARROW),
                hbrBackground = (IntPtr)BackgroundColors.COLOR_WINDOW,
                lpszMenuName = IntPtr.Zero,
                lpszClassName = marshal.GetPtr(),
            };
            if (RegisterClassEx(ref wndclass) != 0)
            {
                _window = CreateWindowEx(WindowStylesEx.WS_EX_OVERLAPPEDWINDOW, windowClassName, windowName, WindowStyles.WS_TILEDWINDOW,
                    CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, IntPtr.Zero, IntPtr.Zero, hInstance, IntPtr.Zero);
                if (_window == IntPtr.Zero)
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
            while (GetMessage(out var msg, _window, 0, 0) != 0)
            {
                try
                {
                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
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
        protected virtual IntPtr WindowProc(IntPtr hWnd, WindowsMessages msg, UIntPtr wParam, IntPtr lParam)
        {
            try
            {
                switch (msg)
                {
                    case WindowsMessages.WM_DESTROY:
                        PostQuitMessage(0);
                        return IntPtr.Zero;
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
                return IntPtr.Zero;
            }
        }
    }
}
