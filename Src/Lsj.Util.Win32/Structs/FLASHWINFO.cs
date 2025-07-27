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
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-flashwinfo"/>
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
        /// <para>
        /// The flash status.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FLASHW_ALL"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// Flash both the window caption and taskbar button.
        /// This is equivalent to setting the <code>FLASHW_CAPTION | FLASHW_TRAY</code> flags.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FLASHW_CAPTION"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Flash the window caption.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FLASHW_STOP"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Stop flashing. The system restores the window to its original state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FLASHW_TIMER"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Flash continuously, until the FLASHW_STOP flag is set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FLASHW_TIMERNOFG"/>
        /// </para>
        /// <para>
        /// 0x0000000C
        /// </para>
        /// </term>
        /// <term>
        /// Flash continuously until the window comes to the foreground.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FLASHW_TRAY"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Flash the taskbar button.
        /// </term>
        /// </item>
        /// </list>
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
