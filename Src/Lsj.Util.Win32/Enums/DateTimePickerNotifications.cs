using static Lsj.Util.Win32.Enums.DateTimePickerMessages;
using static Lsj.Util.Win32.Enums.DateTimePickerStyles;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// DateTimePicker Notifications
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-date-and-time-picker-control-reference-notifications"/>
    /// </para>
    /// </summary>
    public enum DateTimePickerNotifications
    {
        /// <summary>
        /// Sent by a date and time picker (DTP) control when the user closes the drop-down month calendar.
        /// The month calendar is closed when the user chooses a date
        /// from the month calendar or clicks the drop-down arrow while the calendar is open.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        /// <remarks>
        /// DTP controls do not maintain a static child month calendar control.
        /// The DTP control destroys the child month calendar control prior to sending this notification code.
        /// So your application must not rely on a static window handle to the control's child month calendar.
        /// </remarks>
        DTN_CLOSEUP = -753,

        /// <summary>
        /// Sent by a date and time picker (DTP) control whenever a change occurs.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        DTN_DATETIMECHANGE = -759,

        /// <summary>
        /// Sent by a date and time picker (DTP) control when the user activates the drop-down month calendar.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        /// <remarks>
        /// One task that your notification handler may need to perform is to customize the dropdown month-calendar control.
        /// For instance, if you do not want "Go To Today," you need to set the control's <see cref="MCS_NOTODAY"/> style.
        /// To retrieve a handle to the month-calendar control, send the DTP control a <see cref="DTM_GETMONTHCAL"/> message.
        /// You can then use this handle and <see cref="SetWindowLong"/> to set the desired month-calendar style.
        /// DTP controls do not maintain a static child month calendar control.
        /// The DTP control creates a new month calendar control before sending this notification code.
        /// Additionally, the DTP control destroys the child control when it is not active (visible).
        /// So your application must not rely on a static window handle to the control's child month calendar.
        /// </remarks>
        DTN_DROPDOWN = -754,

        /// <summary>
        /// Sent by a date and time picker (DTP) control to request text to be displayed in a callback field.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        /// <remarks>
        /// Handling this notification code allows the owner of the control to provide a custom string that the control will display.
        /// (For additional information about callback fields, see Callback fields.)
        /// </remarks>
        DTN_FORMAT = -743,

        /// <summary>
        /// Sent by a date and time picker (DTP) control to retrieve the maximum allowable size
        /// of the string that will be displayed in a callback field.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        /// <remarks>
        /// Handling this notification code prepares the control to adjust for the maximum size of the string
        /// that will be displayed in a particular callback field.
        /// This enables the control to properly display output at all times, reducing flicker within the control's display.
        /// (For additional information about callback fields, see Callback fields.)
        /// </remarks>
        DTN_FORMATQUERY = -742,

        /// <summary>
        /// Sent by a date and time picker (DTP) control when a user finishes editing a string in the control.
        /// This notification code is only sent by DTP controls that are set to the <see cref="DTS_APPCANPARSE"/> style.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        /// <remarks>
        /// Handling this notification code allows the owner to provide custom responses
        /// to strings entered into the control by the user.
        /// The owner must be prepared to parse the input string and take action if necessary.
        /// </remarks>
        DTN_USERSTRING = -745,

        /// <summary>
        /// Sent by a date and time picker (DTP) control when the user types in a callback field.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        /// <remarks>
        /// Handling this notification code allows the owner of the control to provide specific responses
        /// to keystrokes within the callback fields of the control.
        /// </remarks>
        DTN_WMKEYDOWN = -744,
    }
}
