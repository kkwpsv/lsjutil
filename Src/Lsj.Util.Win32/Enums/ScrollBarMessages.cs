using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.LONG;
using static Lsj.Util.Win32.Enums.ScrollBarCommands;
using static Lsj.Util.Win32.Enums.ScrollInfoFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
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
        /// <para>
        /// The <see cref="SBM_GETPOS"/> message is sent to retrieve the current position of the scroll box of a scroll bar control.
        /// The current position is a relative value that depends on the current scrolling range.
        /// For example, if the scrolling range is 0 through 100 and the scroll box is in the middle of the bar, the current position is 50.
        /// </para>
        /// <para>
        /// Applications should not send this message directly. Instead, they should use the <see cref="GetScrollPos"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond to these messages for the <see cref="GetScrollPos"/> function to function properly.
        /// </para>
        /// </summary>
        SBM_GETPOS = 0x00E1,

        /// <summary>
        /// <para>
        /// The <see cref="SBM_GETRANGE"/> message is sent to retrieve the minimum and maximum position values for the scroll bar control.
        /// </para>
        /// <para>
        /// Applications should not send this message directly.
        /// Instead, they should use the <see cref="GetScrollRange"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond to these messages for the <see cref="GetScrollRange"/> function to work properly.
        /// </para>
        /// </summary>
        SBM_GETRANGE = 0x00E3,

        /// <summary>
        /// Sent by an application to retrieve information about the specified scroll bar.
        /// </summary>
        SBM_GETSCROLLBARINFO = 0x00EB,

        /// <summary>
        /// <para>
        /// The <see cref="SBM_GETSCROLLINFO"/> message is sent to retrieve the parameters of a scroll bar.
        /// </para>
        /// <para>
        /// Applications should not send this message directly.
        /// Instead, they should use the <see cref="GetScrollInfo"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond to these messages for the <see cref="GetScrollInfo"/> function to work properly.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The messages that indicate scroll bar position, <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/>, provide only 16 bits of position data.
        /// However, the <see cref="SCROLLINFO"/> structure used by <see cref="SBM_GETSCROLLINFO"/>, <see cref="SBM_SETSCROLLINFO"/>,
        /// <see cref="GetScrollInfo"/>, and <see cref="SetScrollInfo"/> provides 32 bits of scroll bar position data.
        /// You can use these messages and functions while processing either the <see cref="WM_HSCROLL"/> or <see cref="WM_VSCROLL"/> messages
        /// to obtain 32-bit scroll bar position data.
        /// </para>
        /// <para>
        /// To get the 32-bit position of the scroll box (thumb) during a <see cref="SB_THUMBTRACK"/> request code
        /// in a <see cref="WM_HSCROLL"/> or <see cref="WM_VSCROLL"/> message,
        /// send <see cref="SBM_GETSCROLLINFO"/> with the <see cref="SIF_TRACKPOS"/> value
        /// in the <see cref="SCROLLINFO.fMask"/> member of the <see cref="SCROLLINFO"/> structure.
        /// The message returns the tracking position of the scroll box
        /// in the <see cref="SCROLLINFO.nTrackPos"/> member of the <see cref="SCROLLINFO"/> structure.
        /// This allows you to get the position of the scroll box as the user moves it.
        /// Alternatively, you can use the <see cref="GetScrollInfo"/> function to get the same information.
        /// </para>
        /// </remarks>
        SBM_GETSCROLLINFO = 0x00EA,

        /// <summary>
        /// <para>
        /// The <see cref="SBM_SETPOS"/> message is sent to set the position of the scroll box (thumb) and,
        /// if requested, redraw the scroll bar to reflect the new position of the scroll box.
        /// </para>
        /// <para>
        /// Applications should not send this message directly.
        /// Instead, they should use the <see cref="SetScrollPos"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond to these messages for the <see cref="SetScrollPos"/> function to work properly.
        /// </para>
        /// </summary>
        /// <remarks>
        /// If the scroll bar control is redrawn by a subsequent call to another function, setting the lParam parameter to <see cref="FALSE"/> is useful.
        /// </remarks>
        SBM_SETPOS = 0x00E0,

        /// <summary>
        /// <para>
        /// The <see cref="SBM_SETRANGE"/> message is sent to set the minimum and maximum position values for the scroll bar control.
        /// </para>
        /// <para>
        /// Applications should not send this message directly. Instead, they should use the <see cref="SetScrollRange"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond to these messages for the <see cref="SetScrollRange"/> function to work properly.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The default minimum and maximum position values are zero.
        /// The difference between the values specified by the wParam and lParam parameters must not be greater than <see cref="MAXLONG"/>.
        /// </para>
        /// <para>
        /// If the minimum and maximum position values are equal, the scroll bar control is hidden and, in effect, disabled.
        /// </para>
        /// </remarks>
        SBM_SETRANGE = 0x00E2,

        /// <summary>
        /// An application sends the <see cref="SBM_SETRANGEREDRAW"/> message to a scroll bar control
        /// to set the minimum and maximum position values and to redraw the control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The default minimum and maximum position values are zero.
        /// The difference between the values specified by the wParam and lParam parameters must not be greater than <see cref="MAXLONG"/>.
        /// </para>
        /// <para>
        /// If the minimum and maximum position values are equal, the scroll bar control is hidden and, in effect, disabled.
        /// </para>
        /// </remarks>
        SBM_SETRANGEREDRAW = 0x00E6,

        /// <summary>
        /// <para>
        /// The <see cref="SBM_SETSCROLLINFO"/> message is sent to set the parameters of a scroll bar.
        /// </para>
        /// <para>
        /// Applications should not send this message directly.
        /// Instead, they should use the <see cref="SetScrollInfo"/> function.
        /// A window receives this message through its WindowProc function.
        /// Applications which implement a custom scroll bar control must respond to these messages for the <see cref="SetScrollInfo"/> function to function properly.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The messages that indicate scroll bar position, <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/>, provide only 16 bits of position data.
        /// However, the <see cref="SCROLLINFO"/> structure used by <see cref="SBM_GETSCROLLINFO"/>, <see cref="SBM_SETSCROLLINFO"/>,
        /// <see cref="GetScrollInfo"/>, and <see cref="SetScrollInfo"/> provides 32 bits of scroll bar position data.
        /// You can use these messages and functions while processing either the <see cref="WM_HSCROLL"/> or <see cref="WM_VSCROLL"/> messages
        /// to obtain 32-bit scroll bar position data.
        /// </remarks>
        SBM_SETSCROLLINFO = 0x00E9,
    }
}
