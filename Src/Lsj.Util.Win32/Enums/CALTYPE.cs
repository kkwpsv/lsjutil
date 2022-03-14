using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Calendar Type Information
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/intl/calendar-type-information"/>
    /// </para>
    /// </summary>
    public enum CALTYPE : uint
    {
        /// <summary>
        /// Windows Me/98, Windows 2000: Use the system default instead of the user's choice.
        /// </summary>
        CAL_NOUSEROVERRIDE = 0x80000000,

        /// <summary>
        /// Windows Me/98, Windows 2000: Use the system ANSI code page (ACP) instead of the locale code page for string translation.
        /// This is only relevant for ANSI versions of functions, for example, EnumCalendarInfoA.
        /// </summary>
        CAL_USE_CP_ACP = 0x40000000,

        /// <summary>
        /// Windows Me/98, Windows 2000: Retrieve the result from <see cref="GetCalendarInfo"/> as a number instead of a string.
        /// This is only valid for values beginning with CAL_I.
        /// </summary>
        CAL_RETURN_NUMBER = 0x20000000,

        /// <summary>
        /// Windows 7 and later: Retrieve the result from <see cref="GetCalendarInfo"/> in the form of genitive names of months,
        /// which are the names used when the month names are combined with other items.
        /// For example, in Ukrainian the equivalent of January is written "Січень" when the month is named alone.
        /// However, when the month name is used in combination, for example, in a date such as January 5th, 2003, the genitive form of the name is used.
        /// For the Ukrainian example, the genitive month name is displayed as "5 січня 2003".
        /// For more information, see <see cref="LOCALE_RETURN_GENITIVE_NAMES"/>.
        /// </summary>
        CAL_RETURN_GENITIVE_NAMES = 0x10000000,

        /// <summary>
        /// An integer value indicating the calendar type of the alternate calendar.
        /// </summary>
        CAL_ICALINTVALUE = 0x00000001,

        /// <summary>
        /// Native name of the alternate calendar.
        /// </summary>
        CAL_SCALNAME = 0x00000002,

        /// <summary>
        /// One or more null-terminated strings that specify the year offsets for each of the era ranges.
        /// The last string has an extra terminating null character.
        /// This value varies in format depending on the type of optional calendar.
        /// </summary>
        CAL_IYEAROFFSETRANGE = 0x00000003,

        /// <summary>
        /// One or more null-terminated strings that specify each of the Unicode code points
        /// specifying the era associated with <see cref="CAL_IYEAROFFSETRANGE"/>.
        /// The last string has an extra terminating null character.
        /// This value varies in format depending on the type of optional calendar.
        /// </summary>
        CAL_SERASTRING = 0x00000004,

        /// <summary>
        /// Short date formats for the calendar type.
        /// </summary>
        CAL_SSHORTDATE = 0x00000005,

        /// <summary>
        /// Long date formats for the calendar type.
        /// </summary>
        CAL_SLONGDATE = 0x00000006,

        /// <summary>
        /// Native name of the first day of the week.
        /// </summary>
        CAL_SDAYNAME1 = 0x00000007,

        /// <summary>
        /// Native name of the second day of the week.
        /// </summary>
        CAL_SDAYNAME2 = 0x00000008,

        /// <summary>
        /// Native name of the third day of the week.
        /// </summary>
        CAL_SDAYNAME3 = 0x00000009,

        /// <summary>
        /// Native name of the fourth day of the week.
        /// </summary>
        CAL_SDAYNAME4 = 0x0000000a,

        /// <summary>
        /// Native name of the fifth day of the week.
        /// </summary>
        CAL_SDAYNAME5 = 0x0000000b,

        /// <summary>
        /// Native name of the sixth day of the week.
        /// </summary>
        CAL_SDAYNAME6 = 0x0000000c,

        /// <summary>
        /// Native name of the seventh day of the week.
        /// </summary>
        CAL_SDAYNAME7 = 0x0000000d,

        /// <summary>
        /// Abbreviated native name of the first day of the week.
        /// </summary>
        CAL_SABBREVDAYNAME1 = 0x0000000e,

        /// <summary>
        /// Abbreviated native name of the second day of the week.
        /// </summary>
        CAL_SABBREVDAYNAME2 = 0x0000000f,

        /// <summary>
        /// Abbreviated native name of the third day of the week.
        /// </summary>
        CAL_SABBREVDAYNAME3 = 0x00000010,

        /// <summary>
        /// Abbreviated native name of the fourth day of the week.
        /// </summary>
        CAL_SABBREVDAYNAME4 = 0x00000011,

        /// <summary>
        /// Abbreviated native name of the fifth day of the week.
        /// </summary>
        CAL_SABBREVDAYNAME5 = 0x00000012,

        /// <summary>
        /// Abbreviated native name of the sixth day of the week.
        /// </summary>
        CAL_SABBREVDAYNAME6 = 0x00000013,

        /// <summary>
        /// Abbreviated native name of the seventh day of the week.
        /// </summary>
        CAL_SABBREVDAYNAME7 = 0x00000014,

        /// <summary>
        /// Native name of the first month of the year.
        /// </summary>
        CAL_SMONTHNAME1 = 0x00000015,

        /// <summary>
        /// Native name of the second month of the year.
        /// </summary>
        CAL_SMONTHNAME2 = 0x00000016,

        /// <summary>
        /// Native name of the third month of the year.
        /// </summary>
        CAL_SMONTHNAME3 = 0x00000017,

        /// <summary>
        /// Native name of the fourth month of the year.
        /// </summary>
        CAL_SMONTHNAME4 = 0x00000018,

        /// <summary>
        /// Native name of the fifth month of the year.
        /// </summary>
        CAL_SMONTHNAME5 = 0x00000019,

        /// <summary>
        /// Native name of the sixth month of the year.
        /// </summary>
        CAL_SMONTHNAME6 = 0x0000001a,

        /// <summary>
        /// Native name of the seventh month of the year.
        /// </summary>
        CAL_SMONTHNAME7 = 0x0000001b,

        /// <summary>
        /// Native name of the eighth month of the year.
        /// </summary>
        CAL_SMONTHNAME8 = 0x0000001c,

        /// <summary>
        /// Native name of the ninth month of the year.
        /// </summary>
        CAL_SMONTHNAME9 = 0x0000001d,

        /// <summary>
        /// Native name of the tenth month of the year.
        /// </summary>
        CAL_SMONTHNAME10 = 0x0000001e,

        /// <summary>
        /// Native name of the eleventh month of the year.
        /// </summary>
        CAL_SMONTHNAME11 = 0x0000001f,

        /// <summary>
        /// Native name of the twelfth month of the year.
        /// </summary>
        CAL_SMONTHNAME12 = 0x00000020,

        /// <summary>
        /// Native name of the thirteenth month of the year, if it exists.
        /// </summary>
        CAL_SMONTHNAME13 = 0x00000021,

        /// <summary>
        /// Abbreviated native name of the first month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME1 = 0x00000022,

        /// <summary>
        /// Abbreviated native name of the second month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME2 = 0x00000023,

        /// <summary>
        /// Abbreviated native name of the third month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME3 = 0x00000024,

        /// <summary>
        /// Abbreviated native name of the fourth month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME4 = 0x00000025,

        /// <summary>
        /// Abbreviated native name of the fifth month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME5 = 0x00000026,

        /// <summary>
        /// Abbreviated native name of the sixth month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME6 = 0x00000027,

        /// <summary>
        /// Abbreviated native name of the seventh month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME7 = 0x00000028,

        /// <summary>
        /// Abbreviated native name of the eighth month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME8 = 0x00000029,

        /// <summary>
        /// Abbreviated native name of the ninth month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME9 = 0x0000002a,

        /// <summary>
        /// Abbreviated native name of the tenth month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME10 = 0x0000002b,

        /// <summary>
        /// Abbreviated native name of the eleventh month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME11 = 0x0000002c,

        /// <summary>
        /// Abbreviated native name of the twelfth month of the year.
        /// </summary>
        CAL_SABBREVMONTHNAME12 = 0x0000002d,

        /// <summary>
        /// Abbreviated native name of the thirteenth month of the year, if it exists.
        /// </summary>
        CAL_SABBREVMONTHNAME13 = 0x0000002e,

        /// <summary>
        /// Windows Me/98, Windows 2000: The year/month formats for the specified calendars.
        /// </summary>
        CAL_SYEARMONTH = 0x0000002f,

        /// <summary>
        /// Windows Me/98, Windows 2000: An integer value indicating the upper boundary of the two-digit year range.
        /// </summary>
        CAL_ITWODIGITYEARMAX = 0x00000030,

        /// <summary>
        /// Windows Vista and later: Short native name of the first day of the week.
        /// </summary>
        CAL_SSHORTESTDAYNAME1 = 0x00000031,

        /// <summary>
        /// Windows Vista and later: Short native name of the second day of the week.
        /// </summary>
        CAL_SSHORTESTDAYNAME2 = 0x00000032,

        /// <summary>
        /// Windows Vista and later: Short native name of the third day of the week.
        /// </summary>
        CAL_SSHORTESTDAYNAME3 = 0x00000033,

        /// <summary>
        /// Windows Vista and later: Short native name of the fourth day of the week.
        /// </summary>
        CAL_SSHORTESTDAYNAME4 = 0x00000034,

        /// <summary>
        /// Windows Vista and later: Short native name of the fifth day of the week.
        /// </summary>
        CAL_SSHORTESTDAYNAME5 = 0x00000035,

        /// <summary>
        /// Windows Vista and later: Short native name of the sixth day of the week.
        /// </summary>
        CAL_SSHORTESTDAYNAME6 = 0x00000036,

        /// <summary>
        /// Windows Vista and later: Short native name of the seventh day of the week.
        /// </summary>
        CAL_SSHORTESTDAYNAME7 = 0x00000037,

        /// <summary>
        /// Windows 7 and later: Format of the month and day for the calendar type. 
        /// The formatting is similar to that for <see cref="CAL_SLONGDATE"/>.
        /// For example, if the Month/Day pattern is the full month name followed by the day number with leading zeros,
        /// for example, "September 03", the format is "MMMM dd".
        /// Single quotation marks can be used to insert non-format characters, for example, 'de' in Spanish.
        /// This calendar type supports only one format.
        /// </summary>
        CAL_SMONTHDAY = 0x00000038,

        /// <summary>
        /// Windows 7 and later: Abbreviated native name of an era. The full era is represented by the <see cref="CAL_SERASTRING"/> constant.
        /// </summary>
        CAL_SABBREVERASTRING = 0x00000039,
    }
}
