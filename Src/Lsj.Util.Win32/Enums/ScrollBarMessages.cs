using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Scroll Bar Messages
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/bumper-scroll-bars-reference-messages"/>
    /// </para>
    /// </summary>
    public enum ScrollBarMessages : uint
    {
        /// <summary>
        /// An application sends the <see cref="SBM_ENABLE_ARROWS"/> message to enable or disable one or both arrows of a scroll bar control.
        /// </summary>
        SBM_ENABLE_ARROWS = 0x00E4,

        /// <summary>
        /// The <see cref="SBM_GETPOS"/> message is sent to retrieve the current position of the scroll box of a scroll bar control.
        /// The current position is a relative value that depends on the current scrolling range.
        /// For example, if the scrolling range is 0 through 100 and the scroll box is in the middle of the bar, the current position is 50.
        /// Applications should not send this message directly. Instead, they should use the <see cref="GetScrollPos"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond to these messages
        /// for the <see cref="GetScrollPos"/> function to function properly.
        /// </summary>
        SBM_GETPOS = 0x00E1,

        /// <summary>
        /// The <see cref="SBM_GETRANGE"/> message is sent to retrieve the minimum and maximum position values for the scroll bar control.
        /// Applications should not send this message directly. Instead, they should use the <see cref="GetScrollRange"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond to these messages
        /// for the <see cref="GetScrollRange"/> function to work properly.
        /// </summary>
        SBM_GETRANGE = 0x00E3,

        /// <summary>
        /// Sent by an application to retrieve information about the specified scroll bar.
        /// </summary>
        SBM_GETSCROLLBARINFO = 0x00EB,

        /// <summary>
        /// The <see cref="SBM_GETSCROLLINFO"/> message is sent to retrieve the parameters of a scroll bar.
        /// Applications should not send this message directly.
        /// Instead, they should use the <see cref="GetScrollInfo"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond to these messages
        /// for the <see cref="GetScrollInfo"/> function to work properly.
        /// </summary>
        SBM_GETSCROLLINFO = 0x00EA,

        /// <summary>
        /// The <see cref="SBM_SETPOS"/> message is sent to set the position of the scroll box (thumb) and, if requested,
        /// redraw the scroll bar to reflect the new position of the scroll box.
        /// Applications should not send this message directly.
        /// Instead, they should use the <see cref="SetScrollPos"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond to these messages for the <see cref="SetScrollPos"/> function to work properly.
        /// </summary>
        SBM_SETPOS = 0x00E0,

        /// <summary>
        /// The <see cref="SBM_SETRANGE"/> message is sent to set the minimum and maximum position values for the scroll bar control.
        /// Applications should not send this message directly. 
        /// Instead, they should use the <see cref="SetScrollRange"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond
        /// to these messages for the <see cref="SetScrollRange"/> function to work properly.
        /// </summary>
        SBM_SETRANGE = 0x00E2,

        /// <summary>
        /// The <see cref="SBM_SETSCROLLINFO"/> message is sent to set the parameters of a scroll bar.
        /// Applications should not send this message directly.
        /// Instead, they should use the <see cref="SetScrollInfo"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond
        /// to these messages for the <see cref="SetScrollInfo"/> function to function properly.
        /// </summary>
        SBM_SETSCROLLINFO = 0x00E9,
    }
}
