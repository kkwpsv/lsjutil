using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.DateTimePickerNotifications;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// DateTimePicker Messages
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-date-and-time-picker-control-reference-messages"/>
    /// </para>
    /// </summary>
    public enum DateTimePickerMessages
    {
        /// <summary>
        /// Closes a date and time picker (DTP) control.
        /// Send this message explicitly or by using the <see cref="DateTime_CloseMonthCal"/> macro.
        /// </summary>
        /// <remarks>
        /// Destroys the control and sends a <see cref="DTN_CLOSEUP"/> notification
        /// that the control is closing as opposed to the control is opening
        /// (dropping-down as in the <see cref="DTN_DROPDOWN"/> notification) to the control's parent.
        /// </remarks>
        DTM_CLOSEMONTHCAL = 0x1013,

        /// <summary>
        /// Gets information on a date and time picker (DTP) control.
        /// </summary>
        DTM_GETDATETIMEPICKERINFO = 0x1014,

        /// <summary>
        /// Gets the size needed to display the control without clipping.
        /// Send this message explicitly or by using the <see cref="DateTime_GetIdealSize"/> macro.
        /// </summary>
        DTM_GETIDEALSIZE = 0x1015,

        /// <summary>
        /// Gets the color for a given portion of the month calendar within a date and time picker (DTP) control.
        /// You can send this message explicitly or use the <see cref="DateTime_GetMonthCalColor"/> macro.
        /// </summary>
        DTM_GETMCCOLOR = 0x1007,

        /// <summary>
        /// Gets the font that the date and time picker (DTP) control's child month calendar control is currently using.
        /// You can send this message explicitly or use the <see cref="DateTime_GetMonthCalFont"/> macro.
        /// </summary>
        DTM_GETMCFONT = 0x1010,

        /// <summary>
        /// Gets the style of a date and time picker (DTP) control.
        /// Send this message explicitly or by using the <see cref="DateTime_GetMonthCalStyle"/> macro.
        /// </summary>
        DTM_GETMCSTYLE = 0x1012,

        /// <summary>
        /// Gets the handle to a date and time picker's (DTP) child month calendar control.
        /// You can send this message explicitly or use the <see cref="DateTime_GetMonthCal"/> macro.
        /// </summary>
        /// <remarks>
        /// DTP controls create a child month calendar control when the user clicks the drop-down arrow (<see cref="DTN_DROPDOWN"/> notification).
        /// When the month calendar is no longer needed, it is destroyed (a <see cref="DTN_CLOSEUP"/> notification is sent on destruction).
        /// So your application must not rely on a static handle to the DTP control's child month calendar.
        /// </remarks>
        DTM_GETMONTHCAL = 0x1008,

        /// <summary>
        /// Gets the current minimum and maximum allowable system times for a date and time picker (DTP) control.
        /// You can send this message explicitly or use the <see cref="DateTime_GetRange"/> macro.
        /// </summary>
        /// <remarks>
        /// The date and time picker displays only dates/times that fall within the specified range,
        /// preventing the user from selecting a date and time that falls outside the range.
        /// If the <see cref="DTM_SETSYSTEMTIME"/> message specifies a date and time that falls outside the range, it will fail.
        /// </remarks>
        DTM_GETRANGE = 0x1003,

        /// <summary>
        /// Gets the currently selected time from a date and time picker (DTP) control and places it in a specified <see cref="SYSTEMTIME"/> structure.
        /// You can send this message explicitly or use the <see cref="DateTime_GetSystemtime"/> macro.
        /// </summary>
        DTM_GETSYSTEMTIME = 0x1001,

        /// <summary>
        /// Sets the display of a date and time picker (DTP) control based on a given format string.
        /// You can send this message explicitly or use the <see cref="DateTime_SetFormat"/> macro.
        /// </summary>
        /// <remarks>
        /// It is acceptable to include extra characters within the format string to produce a more rich display.
        /// However, any nonformat characters must be enclosed within single quotes.
        /// For example, the format string "'Today is: 'hh':'m':'s ddddMMMdd', 'yyy"
        /// would produce output like "Today is: 04:22:31 Tuesday Mar 23, 1996".
        /// Note
        /// A DTP control tracks locale changes when it is using the default format string.
        /// If you set a custom format string, it will not be updated in response to locale changes.
        /// </remarks>
        DTM_SETFORMAT = 0x1050,

        /// <summary>
        /// Sets the color for a given portion of the month calendar within a date and time picker (DTP) control.
        /// You can send this message explicitly or use the <see cref="DateTime_SetMonthCalColor"/> macro.
        /// </summary>
        /// <remarks>
        /// When visual styles are enabled, this message has no effect except when wParam is <see cref="MCSC_BACKGROUND"/>.
        /// </remarks>
        DTM_SETMCCOLOR = 0x1006,

        /// <summary>
        /// Sets the font to be used by the date and time picker (DTP) control's child month calendar control.
        /// You can send this message explicitly or use the <see cref="DateTime_SetMonthCalFont"/> macro.
        /// </summary>
        DTM_SETMCFONT = 0x1009,

        /// <summary>
        /// Sets the style of a date and time picker (DTP) control.
        /// Send this message explicitly or by using the <see cref="DateTime_SetMonthCalStyle"/> macro.
        /// </summary>
        DTM_SETMCSTYLE = 0x1011,

        /// <summary>
        /// Sets the minimum and maximum allowable system times for a date and time picker (DTP) control.
        /// You can send this message explicitly or use the <see cref="DateTime_SetRange"/> macro.
        /// </summary>
        /// <remarks>
        /// The date and time picker displays only dates/times that fall within the specified range,
        /// preventing the user from selecting a date and time that falls outside the range.
        /// If the <see cref="DTM_SETSYSTEMTIME"/> message specifies a date and time that falls outside the range, it will fail.
        /// </remarks>
        DTM_SETRANGE = 0x1004,

        /// <summary>
        /// Sets the time in a date and time picker (DTP) control.
        /// You can send this message explicitly or use the <see cref="DateTime_SetSystemtime"/> macro.
        /// </summary>
        DTM_SETSYSTEMTIME = 0x1002,
    }
}
