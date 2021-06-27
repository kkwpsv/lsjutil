using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ShowWindowCommands;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.SetWindowPosFlags;

namespace Lsj.Util.Win32.NativeUI
{
    public partial class Win32Window
    {
        /// <summary>
        /// Start Message Loop
        /// </summary>
        public void StartMessageLoop()
        {
            while (GetMessage(out var msg, NULL, 0, 0))
            {
                TranslateMessage(msg);
                DispatchMessage(msg);
            }
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
    }
}
