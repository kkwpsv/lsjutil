using static Lsj.Util.Win32.BaseTypes.LCID;
using static Lsj.Util.Win32.Enums.DateTimePickerMessages;
using static Lsj.Util.Win32.Enums.DateTimePickerNotifications;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// DateTimePicker Styles
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/date-and-time-picker-control-styles"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The DTS_XXXFORMAT styles that define the display format cannot be combined.
    /// If none of the format styles are suitable, use a <see cref="DTM_SETFORMAT"/> message to define a custom format.
    /// </remarks>
    public enum DateTimePickerStyles : uint
    {
        /// <summary>
        /// Allows the owner to parse user input and take necessary action.
        /// It enables users to edit within the client area of the control when they press the F2 key.
        /// The control sends <see cref="DTN_USERSTRING"/> notification codes when users are finished.
        /// </summary>
        DTS_APPCANPARSE = 0x0010,

        /// <summary>
        /// Displays the date in long format.
        /// The default format string for this style is defined by <see cref="LOCALE_SLONGDATE"/>, which produces output like "Friday, April 19, 1996".
        /// When this style is used, the dropdown button does not display an icon.
        /// </summary>
        DTS_LONGDATEFORMAT = 0x0004,

        /// <summary>
        /// The drop-down month calendar will be right-aligned with the control instead of left-aligned, which is the default.
        /// </summary>
        DTS_RIGHTALIGN = 0x0020,

        /// <summary>
        /// It is possible to have no date currently selected in the control.
        /// With this style, the control displays a check box that is automatically selected whenever a date is picked or entered.
        /// If the check box is subsequently deselected, the application cannot retrieve the date from the control because, in essence, the control has no date.
        /// The state of the check box can be set with the <see cref="DTM_SETSYSTEMTIME"/> message or queried with the <see cref="DTM_GETSYSTEMTIME"/> message.
        /// </summary>
        DTS_SHOWNONE = 0x0002,

        /// <summary>
        /// Displays the date in short format. 
        /// The default format string for this style is defined by <see cref="LOCALE_SSHORTDATE"/>, which produces output like "4/19/96".
        /// </summary>
        DTS_SHORTDATEFORMAT = 0x0000,

        /// <summary>
        /// Version 5.80.
        /// Similar to the <see cref="DTS_SHORTDATEFORMAT"/> style, except the year is a four-digit field.
        /// The default format string for this style is based on <see cref="LOCALE_SSHORTDATE"/>. The output looks like: "4/19/1996".
        /// </summary>
        DTS_SHORTDATECENTURYFORMAT = 0x000C,

        /// <summary>
        /// Displays the time.
        /// The default format string for this style is defined by <see cref="LOCALE_STIMEFORMAT"/>, which produces output like "5:31:42 PM".
        /// </summary>
        DTS_TIMEFORMAT = 0x0009,

        /// <summary>
        /// Places an up-down control to the right of the DTP control to modify date-time values.
        /// This style can be used in place of the drop-down month calendar, which is the default style.
        /// </summary>
        DTS_UPDOWN = 0x0001,
    }
}
