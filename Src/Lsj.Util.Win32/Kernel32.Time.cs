using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;

namespace Lsj.Util.Win32
{
    partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Converts a file time to a local file time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-filetimetolocalfiletime"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileTime">
        /// A pointer to a <see cref="FILETIME"/> structure containing the UTC-based file time to be converted into a local file time.
        /// </param>
        /// <param name="lpLocalFileTime">
        /// A pointer to a <see cref="FILETIME"/> structure to receive the converted local file time.
        /// This parameter cannot be the same as the <paramref name="lpFileTime"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To account for daylight saving time when converting a file time to a local time,
        /// use the following sequence of functions in place of using <see cref="FileTimeToLocalFileTime"/>:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// <see cref="FileTimeToSystemTime"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SystemTimeToTzSpecificLocalTime"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SystemTimeToFileTime"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FileTimeToLocalFileTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FileTimeToLocalFileTime([In] in FILETIME lpFileTime, [Out] out FILETIME lpLocalFileTime);

        /// <summary>
        /// <para>
        /// Converts a file time to system time format. System time is based on Coordinated Universal Time (UTC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/nf-timezoneapi-filetimetosystemtime"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileTime">
        /// <para>
        /// A pointer to a <see cref="FILETIME"/> structure containing the file time to be converted to system (UTC) date and time format.
        /// </para>
        /// <para>
        /// This value must be less than 0x8000000000000000.
        /// Otherwise, the function fails.
        /// </para>
        /// </param>
        /// <param name="lpSystemTime">
        /// A pointer to a <see cref="SYSTEMTIME"/> structure to receive the converted file time.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FileTimeToSystemTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FileTimeToSystemTime([In] in FILETIME lpFileTime, [Out] out SYSTEMTIME lpSystemTime);

        /// <summary>
        /// <para>
        /// Retrieves the current time zone and dynamic daylight saving time settings.
        /// These settings control the translations between Coordinated Universal Time (UTC) and local time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/nf-timezoneapi-getdynamictimezoneinformation"/>
        /// </para>
        /// </summary>
        /// <param name="pTimeZoneInformation">
        /// A pointer to a <see cref="DYNAMIC_TIME_ZONE_INFORMATION"/> structure.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TIME_ZONE_ID_UNKNOWN"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Daylight saving time is not used in the current time zone, because there are no transition dates.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TIME_ZONE_ID_STANDARD"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The system is operating in the range covered by the <see cref="DYNAMIC_TIME_ZONE_INFORMATION.StandardDate"/> member
        /// of the <see cref="DYNAMIC_TIME_ZONE_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TIME_ZONE_ID_DAYLIGHT"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The system is operating in the range covered by the <see cref="DYNAMIC_TIME_ZONE_INFORMATION.DaylightDate"/> member
        /// of the <see cref="DYNAMIC_TIME_ZONE_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the function fails, it returns <see cref="TIME_ZONE_ID_INVALID"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="DYNAMIC_TIME_ZONE_INFORMATION.StandardName"/> and <see cref="DYNAMIC_TIME_ZONE_INFORMATION.DaylightName"/> members
        /// of the resultant <see cref="DYNAMIC_TIME_ZONE_INFORMATION"/> structure are localized according to the current user default UI language.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDynamicTimeZoneInformation", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetDynamicTimeZoneInformation([Out] out DYNAMIC_TIME_ZONE_INFORMATION pTimeZoneInformation);

        /// <summary>
        /// <para>
        /// Retrieves the current time zone settings.
        /// These settings control the translations between Coordinated Universal Time (UTC) and local time.
        /// </para>
        /// <para>
        /// To support boundaries for daylight saving time that change from year to year,
        /// use the <see cref="GetDynamicTimeZoneInformation"/> or <see cref="GetTimeZoneInformationForYear"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/nf-timezoneapi-gettimezoneinformation"/>
        /// </para>
        /// </summary>
        /// <param name="lpTimeZoneInformation">
        /// A pointer to a <see cref="TIME_ZONE_INFORMATION"/> structure to receive the current settings.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TIME_ZONE_ID_UNKNOWN"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Daylight saving time is not used in the current time zone,
        /// because there are no transition dates or automatic adjustment for daylight saving time is disabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TIME_ZONE_ID_STANDARD"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The system is operating in the range covered by the <see cref="TIME_ZONE_INFORMATION.StandardDate"/> member
        /// of the <see cref="TIME_ZONE_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TIME_ZONE_ID_DAYLIGHT"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The system is operating in the range covered by the <see cref="TIME_ZONE_INFORMATION.DaylightDate"/> member
        /// of the <see cref="TIME_ZONE_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the function fails for other reasons, such as an out of memory error, it returns <see cref="TIME_ZONE_ID_INVALID"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// All translations between UTC time and local time are based on the following formula:
        /// </para>
        /// <para>
        /// UTC = local time + bias
        /// </para>
        /// <para>
        /// The bias is the difference, in minutes, between UTC time and local time.
        /// </para>
        /// <para>
        /// The <see cref="TIME_ZONE_INFORMATION.StandardName"/> and <see cref="TIME_ZONE_INFORMATION.DaylightName"/> members
        /// of the resultant <see cref="TIME_ZONE_INFORMATION"/> structure are localized according to the current user default UI language.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTimeZoneInformation", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetTimeZoneInformation([Out] out TIME_ZONE_INFORMATION lpTimeZoneInformation);

        /// <summary>
        /// <para>
        /// Retrieves the time zone settings for the specified year and time zone.
        /// These settings control the translations between Coordinated Universal Time (UTC) and local time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/nf-timezoneapi-gettimezoneinformationforyear"/>
        /// </para>
        /// </summary>
        /// <param name="wYear">
        /// The year for which the time zone settings are to be retrieved.
        /// The <paramref name="wYear"/> parameter must be a local time value.
        /// </param>
        /// <param name="pdtzi">
        /// A pointer to a <see cref="DYNAMIC_TIME_ZONE_INFORMATION"/> structure that specifies the time zone.
        /// To populate this parameter, call <see cref="EnumDynamicTimeZoneInformation"/> with the index of the time zone you want.
        /// If this parameter is <see cref="NullRef{DYNAMIC_TIME_ZONE_INFORMATION}"/>, the current time zone is used.
        /// </param>
        /// <param name="ptzi">
        /// A pointer to a <see cref="TIME_ZONE_INFORMATION"/> structure to receive the current settings.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <paramref name="wYear"/> parameter is assumed to be a local time value.
        /// If the local time is close to the transition between the old year and the new year (00:00:00 January 1),
        /// passing a UTC year to the <see cref="GetTimeZoneInformationForYear"/> function can cause the function to return time zone settings for the wrong year.
        /// </para>
        /// <para>
        /// The <see cref="TIME_ZONE_INFORMATION.StandardName"/> and <see cref="TIME_ZONE_INFORMATION.DaylightName"/> members
        /// of the resultant <see cref="TIME_ZONE_INFORMATION"/> structure are localized according to the current user default UI language.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista, BuildNumbers.WindowsVistaSP1)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTimeZoneInformationForYear", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTimeZoneInformationForYear([In] USHORT wYear, [In] in DYNAMIC_TIME_ZONE_INFORMATION pdtzi, [Out] out TIME_ZONE_INFORMATION ptzi);

        /// <summary>
        /// <para>
        /// Sets the current time zone and dynamic daylight saving time settings.
        /// These settings control translations from Coordinated Universal Time (UTC) to local time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/nf-timezoneapi-setdynamictimezoneinformation"/>
        /// </para>
        /// </summary>
        /// <param name="lpTimeZoneInformation">
        /// A pointer to a <see cref="DYNAMIC_TIME_ZONE_INFORMATION"/> structure.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// An application must have the <see cref="SE_TIME_ZONE_NAME"/> privilege for this function to succeed.
        /// This privilege is disabled by default.
        /// Use the <see cref="AdjustTokenPrivileges"/> function to enable the privilege before calling <see cref="SetDynamicTimeZoneInformation"/>,
        /// and then to disable the privilege after the <see cref="SetDynamicTimeZoneInformation"/> call.
        /// For more information, see Running with Special Privileges.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDynamicTimeZoneInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDynamicTimeZoneInformation([In] in DYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation);

        /// <summary>
        /// <para>
        /// Sets the current time zone settings.
        /// These settings control translations from Coordinated Universal Time (UTC) to local time.
        /// </para>
        /// <para>
        /// To support boundaries for daylight saving time that change from year to year,
        /// use the <see cref="SetDynamicTimeZoneInformation"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/nf-timezoneapi-settimezoneinformation"/>
        /// </para>
        /// </summary>
        /// <param name="lpTimeZoneInformation">
        /// A pointer to a <see cref="TIME_ZONE_INFORMATION"/> structure that contains the new settings.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application must have the <see cref="SE_TIME_ZONE_NAME"/> privilege for this function to succeed.
        /// This privilege is disabled by default.
        /// Use the <see cref="AdjustTokenPrivileges"/> function to enable the privilege before calling <see cref="SetTimeZoneInformation"/>,
        /// and then to disable the privilege after the <see cref="SetTimeZoneInformation"/> call.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000:
        /// The application must have the <see cref="SE_SYSTEMTIME_NAME"/> privilege.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Starting with Windows Vista and Windows Server 2008 through all current versions of Windows,
        /// call <see cref="SetDynamicTimeZoneInformation"/> instead of <see cref="SetTimeZoneInformation"/> to set system time zone information.
        /// <see cref="SetDynamicTimeZoneInformation"/> supports the full history of changes to standard time
        /// and daylight saving time provided by the dynamic data in the Windows registry.
        /// If an application uses <see cref="SetTimeZoneInformation"/>, dynamic daylight saving time support is disabled for the system
        /// and the message "Your current time zone is not recognized. Please select a valid time zone."
        /// will appear to the user in the Windows time zone settings.
        /// </para>
        /// <para>
        /// To inform Explorer that the time zone has changed, send the <see cref="WM_SETTINGCHANGE"/> message.
        /// </para>
        /// <para>
        /// All translations between UTC and local time are based on the following formula:
        /// </para>
        /// <para>
        /// UTC = local time + bias
        /// </para>
        /// <para>
        /// The bias is the difference, in minutes, between UTC and local time.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTimeZoneInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetTimeZoneInformation([In] in TIME_ZONE_INFORMATION lpTimeZoneInformation);

        /// <summary>
        /// <para>
        /// Converts a system time to file time format.
        /// System time is based on Coordinated Universal Time (UTC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/nf-timezoneapi-systemtimetofiletime"/>
        /// </para>
        /// </summary>
        /// <param name="lpSystemTime">
        /// <para>
        /// A pointer to a <see cref="SYSTEMTIME"/> structure that contains the system time to be converted from UTC to file time format.
        /// </para>
        /// <para>
        /// The <see cref="SYSTEMTIME.wDayOfWeek"/> member of the <see cref="SYSTEMTIME"/> structure is ignored.
        /// </para>
        /// </param>
        /// <param name="lpFileTime">
        /// A pointer to a <see cref="FILETIME"/> structure to receive the converted system time.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// A False return value can indicate that the passed <see cref="SYSTEMTIME"/> structure represents an invalid date.
        /// Certain situations, such as the additional day added in a leap year,
        /// can result in application logic unexpectedly creating an invalid date.
        /// For more information on avoiding these issues, see leap year readiness.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SystemTimeToFileTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SystemTimeToFileTime([In] in SYSTEMTIME lpSystemTime, [Out] out FILETIME lpFileTime);

        /// <summary>
        /// <para>
        /// Converts a time in Coordinated Universal Time (UTC) to a specified time zone's corresponding local time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/nf-timezoneapi-systemtimetotzspecificlocaltime"/>
        /// </para>
        /// </summary>
        /// <param name="lpTimeZoneInformation">
        /// <para>
        /// A pointer to a <see cref="TIME_ZONE_INFORMATION"/> structure that specifies the time zone of interest.
        /// </para>
        /// <para>
        /// If <paramref name="lpTimeZoneInformation"/> is <see cref="NullRef{TIME_ZONE_INFORMATION}"/>,
        /// the function uses the currently active time zone.
        /// </para>
        /// </param>
        /// <param name="lpUniversalTime">
        /// A pointer to a <see cref="SYSTEMTIME"/> structure that specifies the UTC time to be converted.
        /// The function converts this universal time to the specified time zone's corresponding local time.
        /// </param>
        /// <param name="lpLocalTime">
        /// A pointer to a <see cref="SYSTEMTIME"/> structure that receives the local time.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero,
        /// and the function sets the members of the <see cref="SYSTEMTIME"/> structure pointed to
        /// by <paramref name="lpLocalTime"/> to the appropriate local time values.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="SystemTimeToTzSpecificLocalTime"/> function takes into account whether daylight saving time (DST) is in effect 
        /// for the local time to which the system time is to be converted.
        /// </para>
        /// <para>
        /// The <see cref="SystemTimeToTzSpecificLocalTime"/> function may calculate the local time incorrectly under the following conditions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The time zone uses a different UTC offset for the old and new years.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The UTC time to be converted and the calculated local time are in different years.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SystemTimeToTzSpecificLocalTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SystemTimeToTzSpecificLocalTime([In] in TIME_ZONE_INFORMATION lpTimeZoneInformation,
            [In] in SYSTEMTIME lpUniversalTime, [Out] out SYSTEMTIME lpLocalTime);

        /// <summary>
        /// <para>
        /// Converts a local time to a time in Coordinated Universal Time (UTC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/nf-timezoneapi-tzspecificlocaltimetosystemtime"/>
        /// </para>
        /// </summary>
        /// <param name="lpTimeZoneInformation">
        /// <para>
        /// A pointer to a <see cref="TIME_ZONE_INFORMATION"/> structure
        /// that specifies the time zone for the time specified in <paramref name="lpLocalTime"/>.
        /// </para>
        /// <para>
        /// If <paramref name="lpTimeZoneInformation"/> is <see cref="NullRef{TIME_ZONE_INFORMATION}"/>,
        /// the function uses the currently active time zone.
        /// </para>
        /// </param>
        /// <param name="lpLocalTime">
        /// A pointer to a <see cref="SYSTEMTIME"/> structure that specifies the local time to be converted.
        /// The function converts this time to the corresponding UTC time.
        /// </param>
        /// <param name="lpUniversalTime">
        /// A pointer to a <see cref="SYSTEMTIME"/> structure that receives the UTC time.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero,
        /// and the function sets the members of the <see cref="SYSTEMTIME"/> structure pointed to
        /// by <paramref name="lpUniversalTime"/> to the appropriate values.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="TzSpecificLocalTimeToSystemTime"/> takes into account
        /// whether daylight saving time (DST) is in effect for the local time to be converted.
        /// </para>
        /// <para>
        ///  Important
        /// </para>
        /// <para>
        /// The following local times, near DST transitions, can be ambiguous or invalid
        /// and might result in unexpected behavior (as there is no guaranteed "correct" result).
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// During the transition from daylight saving time to standard time, the local clock repeats.
        /// A local time within the repeated window is ambiguous
        /// because it occurs twice, once in daylight saving time and once in standard time.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// During the transition from standard time to daylight saving time, the local clock jumps forward.
        /// A local time within the skipped window is invalid because it does not have a valid UTC conversion.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the specified local time is either ambiguous or invalid,
        /// the function treats it as daylight saving time and applies the daylight saving time bias.
        /// Applications requiring continuity or precision should avoid this function and use UTC time instead.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TzSpecificLocalTimeToSystemTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TzSpecificLocalTimeToSystemTime([In] in TIME_ZONE_INFORMATION lpTimeZoneInformation,
            [In] in SYSTEMTIME lpLocalTime, [Out] out SYSTEMTIME lpUniversalTime);
    }
}
