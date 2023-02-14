using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Month Calendar Styles
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/month-calendar-control-styles"/>
    /// </para>
    /// </summary>
    public enum MonthCalendarStyles : uint
    {
        /// <summary>
        /// Version 4.70.
        /// The month calendar sends MCN_GETDAYSTATE notifications to request information about which days should be displayed in bold.
        /// </summary>
        MCS_DAYSTATE = 0x0001,

        /// <summary>
        /// Version 4.70.
        /// The month calendar enables the user to select a range of dates within the control.
        /// By default, the maximum range is one week.
        /// You can change the maximum range that can be selected by using the <see cref="MCM_SETMAXSELCOUNT"/> message.
        /// </summary>
        MCS_MULTISELECT = 0x0002,

        /// <summary>
        /// Version 4.70. The month calendar control displays week numbers (1-52) to the left of each row of days.
        /// Week 1 is defined as the first week that contains at least four days.
        /// </summary>
        MCS_WEEKNUMBERS = 0x0004,

        /// <summary>
        /// Version 4.70.
        /// The month calendar control does not circle the "today" date.
        /// </summary>
        MCS_NOTODAYCIRCLE = 0x0008,

        /// <summary>
        /// Version 4.70.
        /// The month calendar control does not display the "today" date at the bottom of the control.
        /// </summary>
        MCS_NOTODAY = 0x0010,

        /// <summary>
        /// Windows Vista.
        /// Dates from the previous and next months are not displayed in the current month's calendar.
        /// </summary>
        MCS_NOTRAILINGDATES = 0x0040,

        /// <summary>
        /// Windows Vista. Short day names are displayed in the header.
        /// </summary>
        MCS_SHORTDAYSOFWEEK = 0x0080,

        /// <summary>
        /// Windows Vista.
        /// The selection is not changed when the user navigates next or previous in the calendar.
        /// This allows the user to select a range larger than is visible.
        /// </summary>
        MCS_NOSELCHANGEONNAV = 0x0100,
    }
}
