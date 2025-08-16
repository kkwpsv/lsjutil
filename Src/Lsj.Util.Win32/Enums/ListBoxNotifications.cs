using static Lsj.Util.Win32.Enums.ListBoxMessages;
using static Lsj.Util.Win32.Enums.ListBoxStyles;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// List Box Notifications
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/bumper-list-box-control-reference-notifications"/>
    /// </para>
    /// </summary>
    public enum ListBoxNotifications
    {
        /// <summary>
        /// Notifies the application that the user has double-clicked an item in a list box.
        /// The parent window of the list box receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        /// <remarks>
        /// This notification code is sent only by a list box that has the <see cref="LBS_NOTIFY"/> style.
        /// </remarks>
        LBN_DBLCLK = 2,

        /// <summary>
        /// Notifies the application that the list box cannot allocate enough memory to meet a specific request.
        /// The parent window of the list box receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        LBN_ERRSPACE = -2,

        /// <summary>
        /// Notifies the application that the list box has lost the keyboard focus.
        /// The parent window of the list box receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        LBN_KILLFOCUS = 5,

        /// <summary>
        /// Notifies the application that the user has canceled the selection in a list box.
        /// The parent window of the list box receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        LBN_SELCANCEL = 3,

        /// <summary>
        /// Notifies the application that the selection in a list box has changed as a result of user input.
        /// The parent window of the list box receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This notification code is sent only by a list box that has the <see cref="LBS_NOTIFY"/> style.
        /// </para>
        /// <para>
        /// This notification code is not sent if the <see cref="LB_SETSEL"/>, <see cref="LB_SETCURSEL"/>,
        /// <see cref="LB_SELECTSTRING"/>, <see cref="LB_SELITEMRANGE"/> or <see cref="LB_SELITEMRANGEEX"/> message changes the selection.
        /// </para>
        /// <para>
        /// For a multiple-selection list box, the <see cref="LBN_SELCHANGE"/> notification code is sent
        /// whenever the user presses an arrow key, even if the selection does not change.
        /// </para>
        /// </remarks>
        LBN_SELCHANGE = 1,

        /// <summary>
        /// Notifies the application that the list box has received the keyboard focus.
        /// The parent window of the list box receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        LBN_SETFOCUS = 4,
    }
}
