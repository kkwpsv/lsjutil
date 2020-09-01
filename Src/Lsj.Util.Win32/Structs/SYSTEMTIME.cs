using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies a date and time, using individual members for the month, day, year, weekday, hour, minute, second, and millisecond.
    /// The time is either in coordinated universal time (UTC) or local time, depending on the function that is being called.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-systemtime
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="SYSTEMTIME"/> does not check to see if the date represented is a real and valid date.
    /// When working with this API, you should ensure its validity, especially in leap reat scenarios.
    /// See leap day readiness for more information.
    /// It is not recommended that you add and subtract values from the <see cref="SYSTEMTIME"/> structure to obtain relative times.
    /// Instead, you should:
    /// Convert the <see cref="SYSTEMTIME"/> structure to a <see cref="FILETIME"/> structure.
    /// Copy the resulting <see cref="FILETIME"/> structure to a <see cref="ULARGE_INTEGER"/> structure.
    /// Use normal 64-bit arithmetic on the <see cref="ULARGE_INTEGER"/> value.
    /// The system can periodically refresh the time by synchronizing with a time source.
    /// Because the system time can be adjusted either forward or backward, do not compare system time readings to determine elapsed time.
    /// Instead, use one of the methods described in Windows Time.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SYSTEMTIME
    {
        /// <summary>
        /// The year. The valid values for this member are 1601 through 30827.
        /// </summary>
        public WORD wYear;

        /// <summary>
        /// The month. This member can be one of the following values.
        /// 1 January
        /// 2 February
        /// 3 March
        /// 4 April
        /// 5 May
        /// 6 June
        /// 7 July
        /// 8 August
        /// 9 September
        /// 10 October
        /// 11 November
        /// 12 December
        /// </summary>
        public WORD wMonth;

        /// <summary>
        /// The day of the week. This member can be one of the following values.
        /// 0 Sunday
        /// 1 Monday
        /// 2 Tuesday
        /// 3 Wednesday
        /// 4 Thursday
        /// 5 Friday
        /// 6 Saturday
        /// </summary>
        public WORD wDayOfWeek;

        /// <summary>
        /// The day of the month. The valid values for this member are 1 through 31.
        /// </summary>
        public WORD wDay;

        /// <summary>
        /// The hour. The valid values for this member are 0 through 23.
        /// </summary>
        public WORD wHour;

        /// <summary>
        /// The minute. The valid values for this member are 0 through 59.
        /// </summary>
        public WORD wMinute;

        /// <summary>
        /// The second. The valid values for this member are 0 through 59.
        /// </summary>
        public WORD wSecond;

        /// <summary>
        /// The millisecond. The valid values for this member are 0 through 999.
        /// </summary>
        public WORD wMilliseconds;
    }
}
