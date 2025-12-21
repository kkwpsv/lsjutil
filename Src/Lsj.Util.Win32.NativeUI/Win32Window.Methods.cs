using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Extensions.NativeUI;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Enums.SetWindowPosFlags;
using static Lsj.Util.Win32.Enums.ShowWindowCommands;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.NativeUI
{
    public partial class Win32Window
    {
        /// <summary>
        /// Hook window proc
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        public void HookWindowProc()
        {
            if (CheckFlag(Win32WindowFlags.OtherProcess))
            {
                throw new NotSupportedException("Not support hook other process's window now.");
            }
            if (CheckFlag(Win32WindowFlags.WindowProcHooked))
            {
                throw new InvalidOperationException("Already hooked.");
            }
            if (CheckFlag(Win32WindowFlags.WindowProcUseThis))
            {
                throw new InvalidOperationException("No need to hook. Already use window proc of this.");
            }

            _hookedWndProc = GetWindowLongPtr(_handle, GetWindowLongIndexes.GWL_WNDPROC);
            if (_hookedWndProc != NULL)
            {
                _wndProc = WindowProc;
                SetWindowLongPtr(_handle, GetWindowLongIndexes.GWL_WNDPROC, Marshal.GetFunctionPointerForDelegate(_wndProc));
            }
            else
            {
                throw new Win32Exception();
            }

            _flags |= Win32WindowFlags.WindowProcHooked;
        }


        /// <summary>
        /// Show
        /// </summary>
        public void Show() => ShowWindow(_handle, SW_SHOWNORMAL);


        /// <summary>
        /// Hide
        /// </summary>
        public void Hide() => ShowWindow(_handle, SW_HIDE);

        /// <summary>
        /// Set TopMost
        /// </summary>
        public void SetTopMost()
        {
            SetForegroundWindow(_handle);
            if (!SetWindowPos(_handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE))
            {
                ThrowExceptionIfError();
            }
        }

        /// <summary>
        /// Set No TopMost
        /// </summary>
        public void SetNoTopMost()
        {
            if (!SetWindowPos(_handle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE))
            {
                ThrowExceptionIfError();
            }
        }

        /// <summary>
        /// Get ScreenShot
        /// </summary>
        public void GetScreenShot() => WindowExtensions.GetWindowScreenshot(_handle);

        /// <summary>
        /// Get ScreenShot with <see cref="CAPTUREBLT"/>
        /// </summary>
        public void GetScreenShotWithCaptureBlt() => WindowExtensions.GetWindowScreenshotWithCaptureBlt(_handle);

        /// <summary>
        /// Register Touch Window
        /// </summary>
        /// <param name="flags"></param>
        public void RegisterTouchWindow(TouchWindowFlags flags = 0)
        {
            if (!User32.RegisterTouchWindow(_handle, flags))
            {
                ThrowExceptionIfError();
            }
        }

        /// <summary>
        /// Unregister Touch Window
        /// </summary>
        public void UnregisterTouchWindow()
        {
            if (!User32.UnregisterTouchWindow(_handle))
            {
                ThrowExceptionIfError();
            }
        }
    }
}
