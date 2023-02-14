using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GetDateFormat"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/datetimeapi/nf-datetimeapi-getdateformatex"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum GetDateFormatFlags : uint
    {
        /// <summary>
        /// Windows 7 and later:
        /// Detect the need for right-to-left and left-to-right reading layout using the locale and calendar information, and add marks accordingly.
        /// This value cannot be used with <see cref="DATE_LTRREADING"/> or <see cref="DATE_RTLREADING"/>.
        /// <see cref="DATE_AUTOLAYOUT"/> is preferred over <see cref="DATE_LTRREADING"/> and <see cref="DATE_RTLREADING"/>
        /// because it uses the locales and calendars to determine the correct addition of marks.
        /// </summary>
        DATE_AUTOLAYOUT = 0x00000040,

        /// <summary>
        /// Use the long date format.
        /// This value cannot be used with <see cref="DATE_MONTHDAY"/>, <see cref="DATE_SHORTDATE"/>, or <see cref="DATE_YEARMONTH"/>.
        /// </summary>
        DATE_LONGDATE = 0x00000002,

        /// <summary>
        /// Add marks for left-to-right reading layout.
        /// This value cannot be used with <see cref="DATE_RTLREADING"/>.
        /// </summary>
        DATE_LTRREADING = 0x00000010,

        /// <summary>
        /// Add marks for right-to-left reading layout.
        /// This value cannot be used with <see cref="DATE_LTRREADING"/>.
        /// </summary>
        DATE_RTLREADING = 0x00000020,

        /// <summary>
        /// Use the short date format.
        /// This is the default.
        /// This value cannot be used with <see cref="DATE_MONTHDAY"/>, <see cref="DATE_LONGDATE"/>, or <see cref="DATE_YEARMONTH"/>.
        /// </summary>
        DATE_SHORTDATE = 0x00000001,

        /// <summary>
        /// Use the alternate calendar, if one exists, to format the date string.
        /// If this flag is set, the function uses the default format for that alternate calendar, rather than using any user overrides.
        /// The user overrides will be used only in the event that there is no default format for the specified alternate calendar.
        /// </summary>
        DATE_USE_ALT_CALENDAR = 0x00000004,

        /// <summary>
        /// Windows Vista:
        /// Use the year/month format.
        /// This value cannot be used with <see cref="DATE_MONTHDAY"/>, <see cref="DATE_SHORTDATE"/>, or <see cref="DATE_LONGDATE"/>.
        /// </summary>
        DATE_YEARMONTH = 0x00000008,

        /// <summary>
        /// Windows 10:
        /// Use the combination of month and day formats appropriate for the specified locale.
        /// This value cannot be used with <see cref="DATE_YEARMONTH"/>, <see cref="DATE_SHORTDATE"/>, or <see cref="DATE_LONGDATE"/>.
        /// </summary>
        DATE_MONTHDAY = 0x00000080,
    }
}
