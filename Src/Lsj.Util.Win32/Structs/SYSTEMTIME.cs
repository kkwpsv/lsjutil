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
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-systemtime"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// The <see cref="SYSTEMTIME"/> does not check to see if the date represented is a real and valid date.
    /// When working with this API, you should ensure its validity, especially in leap reat scenarios.
    /// See leap day readiness for more information.
    /// </para>
    /// <para>
    /// It is not recommended that you add and subtract values from the <see cref="SYSTEMTIME"/> structure to obtain relative times.
    /// Instead, you should:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Convert the <see cref="SYSTEMTIME"/> structure to a <see cref="FILETIME"/> structure.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Copy the resulting <see cref="FILETIME"/> structure to a <see cref="ULARGE_INTEGER"/> structure.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Use normal 64-bit arithmetic on the <see cref="ULARGE_INTEGER"/> value.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// The system can periodically refresh the time by synchronizing with a time source.
    /// Because the system time can be adjusted either forward or backward,
    /// do not compare system time readings to determine elapsed time.
    /// Instead, use one of the methods described in Windows Time.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SYSTEMTIME
    {
        /// <summary>
        /// The year. The valid values for this member are 1601 through 30827.
        /// </summary>
        public WORD wYear;

        /// <summary>
        /// <para>
        /// The month. This member can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// January
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// February
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 3
        /// </term>
        /// <term>
        /// March
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 4
        /// </term>
        /// <term>
        /// April
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5
        /// </term>
        /// <term>
        /// May
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 6
        /// </term>
        /// <term>
        /// June
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 7
        /// </term>
        /// <term>
        /// July
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 8
        /// </term>
        /// <term>
        /// August
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 9
        /// </term>
        /// <term>
        /// September
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 10
        /// </term>
        /// <term>
        /// October
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 11
        /// </term>
        /// <term>
        /// November
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 12
        /// </term>
        /// <term>
        /// December
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public WORD wMonth;

        /// <summary>
        /// <para>
        /// The day of the week. This member can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Sunday
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Monday
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// Tuesday
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 3
        /// </term>
        /// <term>
        /// Wednesday
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 4
        /// </term>
        /// <term>
        /// Thursday
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5
        /// </term>
        /// <term>
        /// Friday
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 6
        /// </term>
        /// <term>
        /// Saturday
        /// </term>
        /// </item>
        /// </list>
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
