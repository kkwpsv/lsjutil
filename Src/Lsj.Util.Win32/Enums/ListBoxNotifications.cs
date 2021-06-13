using static Lsj.Util.Win32.Enums.WindowsMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// List Box Notifications
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-list-box-control-reference-notifications"/>
    /// </para>
    /// </summary>
    public enum ListBoxNotifications
    {
        /// <summary>
        /// Notifies the application that the user has double-clicked an item in a list box.
        /// The parent window of the list box receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
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
        LBN_SELCHANGE = 1,

        /// <summary>
        /// Notifies the application that the list box has received the keyboard focus.
        /// The parent window of the list box receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        LBN_SETFOCUS = 4,
    }
}
