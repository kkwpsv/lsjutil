using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FLASHWINFOFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the flash status for a window and the number of times the system should flash the window.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-flashwinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct FLASHWINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// A handle to the window to be flashed. The window can be either opened or minimized.
        /// </summary>
        public HWND hwnd;

        /// <summary>
        /// The flash status.
        /// This parameter can be one or more of the following values.
        /// <see cref="FLASHW_ALL"/>, <see cref="FLASHW_CAPTION"/>, <see cref="FLASHW_STOP"/>,
        /// <see cref="FLASHW_TIMER"/>, <see cref="FLASHW_TIMERNOFG"/>, <see cref="FLASHW_TRAY"/>.
        /// </summary>
        public FLASHWINFOFlags dwFlags;

        /// <summary>
        /// The number of times to flash the window.
        /// </summary>
        public UINT uCount;

        /// <summary>
        /// The rate at which the window is to be flashed, in milliseconds.
        /// If <see cref="dwTimeout"/> is zero, the function uses the default cursor blink rate.
        /// </summary>
        public DWORD dwTimeout;
    }
}
