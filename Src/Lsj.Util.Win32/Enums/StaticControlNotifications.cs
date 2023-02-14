using static Lsj.Util.Win32.Enums.StaticControlStyles;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Static Control Notifications
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/bumper-static-control-reference-notifications"/>
    /// </para>
    /// </summary>
    public enum StaticControlNotifications
    {
        /// <summary>
        /// The <see cref="STN_CLICKED"/> notification code is sent when the user clicks a static control that has the <see cref="SS_NOTIFY"/> style.
        /// The parent window of the control receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        STN_CLICKED = 0,

        /// <summary>
        /// The <see cref="STN_DBLCLK"/> notification code is sent when the user double-clicks a static control that has the <see cref="SS_NOTIFY"/> style.
        /// The parent window of the control receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        STN_DBLCLK = 1,

        /// <summary>
        /// The STN_DISABLE notification code is sent when a static control is disabled.
        /// The static control must have the <see cref="SS_NOTIFY"/> style to receive this notification code.
        /// The parent window of the control receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        STN_DISABLE = 3,

        /// <summary>
        /// The <see cref="STN_ENABLE"/> notification code is sent when a static control is enabled.
        /// The static control must have the <see cref="SS_NOTIFY"/> style to receive this notification code.
        /// The parent window of the control receives this notification code through the <see cref="WM_COMMAND"/> message.
        /// </summary>
        STN_ENABLE = 2,
    }
}
