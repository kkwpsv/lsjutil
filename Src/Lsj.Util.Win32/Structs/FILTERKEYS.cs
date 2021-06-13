using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the FilterKeys accessibility feature, which enables a user with disabilities
    /// to set the keyboard repeat rate (RepeatKeys), acceptance delay (SlowKeys), and bounce rate (BounceKeys).
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-filterkeys"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILTERKEYS
    {
        /// <summary>
        /// cbSize
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// dwFlags
        /// </summary>
        public DWORD dwFlags;

        /// <summary>
        /// Acceptance Delay
        /// </summary>
        public DWORD iWaitMSec;

        /// <summary>
        /// Delay Until Repeat
        /// </summary>
        public DWORD iDelayMSec;

        /// <summary>
        /// Repeat Rate
        /// </summary>
        public DWORD iRepeatMSec;

        /// <summary>
        /// Debounce Time
        /// </summary>
        public DWORD iBounceMSec;
    }
}
