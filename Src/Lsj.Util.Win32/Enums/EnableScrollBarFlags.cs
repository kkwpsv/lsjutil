using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="EnableScrollBar"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enablescrollbar"/>
    /// </para>
    /// </summary>
    public enum EnableScrollBarFlags : uint
    {
        /// <summary>
        /// Enables both arrows on a scroll bar.
        /// </summary>
        ESB_ENABLE_BOTH = 0x0000,

        /// <summary>
        /// Disables both arrows on a scroll bar.
        /// </summary>
        ESB_DISABLE_BOTH = 0x0003,

        /// <summary>
        /// Disables the left arrow on a horizontal scroll bar.
        /// </summary>
        ESB_DISABLE_LEFT = 0x0001,

        /// <summary>
        /// Disables the right arrow on a horizontal scroll bar.
        /// </summary>
        ESB_DISABLE_RIGHT = 0x0002,

        /// <summary>
        /// Disables the up arrow on a vertical scroll bar.
        /// </summary>
        ESB_DISABLE_UP = 0x0001,

        /// <summary>
        /// Disables the down arrow on a vertical scroll bar.
        /// </summary>
        ESB_DISABLE_DOWN = 0x0002,

        /// <summary>
        /// Disables the left arrow on a horizontal scroll bar or the up arrow of a vertical scroll bar.
        /// </summary>
        ESB_DISABLE_LTUP = ESB_DISABLE_LEFT,

        /// <summary>
        /// Disables the right arrow on a horizontal scroll bar or the down arrow of a vertical scroll bar.
        /// </summary>
        ESB_DISABLE_RTDN = ESB_DISABLE_RIGHT,
    }
}
