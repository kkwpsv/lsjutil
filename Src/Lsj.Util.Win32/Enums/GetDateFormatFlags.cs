using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetDateFormat"/> flags
    /// </summary>
    [Flags]
    public enum GetDateFormatFlags : uint
    {
        /// <summary>
        /// DATE_AUTOLAYOUT
        /// </summary>
        DATE_AUTOLAYOUT = 0x00000040,

        /// <summary>
        /// DATE_LONGDATE
        /// </summary>
        DATE_LONGDATE = 0x00000002,

        /// <summary>
        /// DATE_LTRREADING
        /// </summary>
        DATE_LTRREADING = 0x00000010,

        /// <summary>
        /// DATE_RTLREADING
        /// </summary>
        DATE_RTLREADING = 0x00000020,

        /// <summary>
        /// DATE_SHORTDATE
        /// </summary>
        DATE_SHORTDATE = 0x00000001,

        /// <summary>
        /// DATE_USE_ALT_CALENDAR
        /// </summary>
        DATE_USE_ALT_CALENDAR = 0x00000004,

        /// <summary>
        /// DATE_YEARMONTH
        /// </summary>
        DATE_YEARMONTH = 0x00000008,

        /// <summary>
        /// DATE_MONTHDAY
        /// </summary>
        DATE_MONTHDAY = 0x00000080,
    }
}
