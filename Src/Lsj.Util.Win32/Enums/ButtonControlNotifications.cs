using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.ButtonStyles;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Button Control Notifications
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-button-control-reference-notifications"/>
    /// </para>
    /// </summary>
    public enum ButtonControlNotifications : uint
    {
        /// <summary>
        /// BCN_FIRST
        /// </summary>
        BCN_FIRST = unchecked(0U - 1250U),

        /// <summary>
        /// BCN_LAST
        /// </summary>
        BCN_LAST = unchecked(0U - 1350U),

        /// <summary>
        /// Sent when the user clicks a drop down arrow on a button.
        /// The parent window of the control receives this notification code in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        BCN_DROPDOWN = BCN_FIRST + 0x0002,

        /// <summary>
        /// Notifies the button control owner that the mouse is entering or leaving the client area of the button control.
        /// The button control sends this notification code in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        BCN_HOTITEMCHANGE = BCN_FIRST + 0x0001,

        /// <summary>
        /// Sent when the user clicks a button.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        BN_CLICKED = 0,

        /// <summary>
        /// Sent when the user double-clicks a button.
        /// This notification code is sent automatically for <see cref="BS_USERBUTTON"/>, <see cref="BS_RADIOBUTTON"/>,
        /// and <see cref="BS_OWNERDRAW"/> buttons.
        /// Other button types send <see cref="BN_DBLCLK"/> only if they have the <see cref="BS_NOTIFY"/> style.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        BN_DBLCLK = BN_DOUBLECLICKED,

        /// <summary>
        /// Sent when a button is disabled.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        /// <remarks>
        /// This notification code is provided only for compatibility with 16-bit versions of Windows earlier than version 3.0.
        /// Applications should use the <see cref="BS_OWNERDRAW"/> button style and the <see cref="DRAWITEMSTRUCT"/> structure for this task.
        /// </remarks>
        BN_DISABLE = 4,

        /// <summary>
        /// Sent when the user double-clicks a button.
        /// This notification code is sent automatically for <see cref="BS_USERBUTTON"/>, <see cref="BS_RADIOBUTTON"/>,
        /// and <see cref="BS_OWNERDRAW"/> buttons.
        /// Other button types send <see cref="BN_DOUBLECLICKED"/> only if they have the <see cref="BS_NOTIFY"/> style.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        BN_DOUBLECLICKED = 5,

        /// <summary>
        /// Sent when the user selects a button.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        /// <remarks>
        /// This notification code is provided only for compatibility with 16-bit versions of Windows earlier than version 3.0.
        /// Applications should use the <see cref="BS_OWNERDRAW"/> button style and the <see cref="DRAWITEMSTRUCT"/> structure for this task.
        /// </remarks>
        BN_HILITE = 2,

        /// <summary>
        /// Sent when a button loses the keyboard focus.
        /// The button must have the <see cref="BS_NOTIFY"/> style to send this notification code.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        BN_KILLFOCUS = 7,

        /// <summary>
        /// Sent when a button should be painted.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        /// <remarks>
        /// This notification code is provided only for compatibility with 16-bit versions of Windows earlier than version 3.0.
        /// Applications should use the <see cref="BS_OWNERDRAW"/> button style and the <see cref="DRAWITEMSTRUCT"/> structure for this task.
        /// </remarks>
        BN_PAINT = 1,

        /// <summary>
        /// Sent when the push state of a button is set to pushed.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        /// <remarks>
        /// This notification code is provided only for compatibility with 16-bit versions of Windows earlier than version 3.0.
        /// Applications should use the <see cref="BS_OWNERDRAW"/> button style and the <see cref="DRAWITEMSTRUCT"/> structure for this task.
        /// </remarks>
        BN_PUSHED = BN_HILITE,

        /// <summary>
        /// Sent when a button receives the keyboard focus.
        /// The button must have the <see cref="BS_NOTIFY"/> style to send this notification code.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        BN_SETFOCUS = 6,

        /// <summary>
        /// Sent when the highlight should be removed from a button.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        /// <remarks>
        /// This notification code is provided only for compatibility with 16-bit versions of Windows earlier than version 3.0.
        /// Applications should use the <see cref="BS_OWNERDRAW"/> button style and the <see cref="DRAWITEMSTRUCT"/> structure for this task.
        /// </remarks>
        BN_UNHILITE = 3,

        /// <summary>
        /// Sent when the push state of a button is set to unpushed.
        /// The parent window of the button receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        /// <remarks>
        /// This notification code is provided only for compatibility with 16-bit versions of Windows earlier than version 3.0.
        /// Applications should use the <see cref="BS_OWNERDRAW"/> button style and the <see cref="DRAWITEMSTRUCT"/> structure for this task.
        /// </remarks>
        BN_UNPUSHED = BN_UNHILITE,
    }
}
