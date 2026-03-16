using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.LCID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;

namespace Lsj.Util.Win32
{
    partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// An application-defined callback function that processes enumerated time format information
        /// provided by the <see cref="EnumTimeFormats"/> function.
        /// The <see cref="TIMEFMT_ENUMPROC"/> type defines a pointer to this callback function.
        /// <see cref="EnumTimeFormatsProc"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317832(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lpTimeFormatString">
        /// Pointer to a buffer containing a null-terminated time format string.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> to continue enumeration or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An <see cref="EnumTimeFormatsProc"/> function can carry out any desired task.
        /// The application registers this function by passing its address to the <see cref="EnumTimeFormats"/> function.
        /// </para>
        /// <para>
        /// This callback function can process enumerated data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// </remarks>
        public delegate BOOL EnumTimeFormatsProc([In] LPWSTR lpTimeFormatString);

        /// <summary>
        /// <para>
        /// An application-defined callback function that processes enumerated time format information
        /// provided by the <see cref="EnumTimeFormatsEx"/> function.
        /// The <see cref="TIMEFMT_ENUMPROCEX"/> type defines a pointer to this callback function.
        /// <see cref="EnumTimeFormatsProcEx"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317833(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lpTimeFormatString">
        /// Pointer to a buffer containing a null-terminated time format string.
        /// </param>
        /// <param name="lParam">
        /// An application-provided input parameter of <see cref="EnumTimeFormatsEx"/>.
        /// This value is especially useful for multi-threaded applications,
        /// since it can be used to pass thread-specific data to this callback function.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> to continue enumeration or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An <see cref="EnumTimeFormatsProcEx"/> function can carry out any desired task.
        /// The application registers this function by passing its address to the <see cref="EnumTimeFormatsEx"/> function.
        /// </para>
        /// <para>
        /// This callback function can process enumerated data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// </remarks>
        public delegate BOOL EnumTimeFormatsProcEx([In] LPWSTR lpTimeFormatString, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Converts MS-DOS date and time values to a file time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-dosdatetimetofiletime"/>
        /// </para>
        /// </summary>
        /// <param name="wFatDate">
        /// <para>
        /// The MS-DOS date.
        /// The date is a packed value with the following format.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-4
        /// </term>
        /// <term>
        /// Day of the month (1–31)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5-8
        /// </term>
        /// <term>
        /// Month (1 = January, 2 = February, and so on)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 9-15
        /// </term>
        /// <term>
        /// Year offset from 1980 (add 1980 to get actual year)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="wFatTime">
        /// <para>
        /// The MS-DOS time.
        /// The time is a packed value with the following format.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-4
        /// </term>
        /// <term>
        /// Second divided by 2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5-10
        /// </term>
        /// <term>
        /// Minute (0–59)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 11-15
        /// </term>
        /// <term>
        /// Hour (0–23 on a 24-hour clock)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpFileTime">
        /// A pointer to a <see cref="FILETIME"/> structure that receives the converted file time.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DosDateTimeToFileTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DosDateTimeToFileTime([In] WORD wFatDate, [In] WORD wFatTime, [Out] out FILETIME lpFileTime);

        /// <summary>
        /// <para>
        /// Enumerates the time formats that are available for a locale specified by identifier.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For interoperability reasons, the application should prefer the <see cref="EnumTimeFormatsEx"/> function to <see cref="EnumTimeFormats"/>
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// Any application that runs only on Windows Vista and later should use <see cref="EnumTimeFormatsEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-enumtimeformatsw"/>
        /// </para>
        /// </summary>
        /// <param name="lpTimeFmtEnumProc">
        /// Pointer to an application-defined callback function.
        /// For more information, see <see cref="EnumTimeFormatsProc"/>.
        /// </param>
        /// <param name="Locale">
        /// <para>
        /// Locale identifier that specifies the locale for which to retrieve time format information.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_INVARIANT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_USER_DEFAULT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// The time format. This parameter can specify a combination of any of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag
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
        /// Use the current user's long time format.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TIME_NOSECONDS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Windows 7 and later: Use the current user's short time format.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This value will not work with the ANSI version of this function, <c>EnumTimeFormatsA</c>. 
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOCAL_USE_CP_ACP"/>
        /// </term>
        /// <term>
        /// Specified with the ANSI version of this function, <c>EnumTimeFormatsA</c> (not recommended),
        /// to use the system default Windows ANSI code page (ACP) instead of the locale code page.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_FLAGS"/>.
        /// The values supplied for flags were not valid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_PARAMETER"/>.
        /// Any of the parameter values was invalid.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The function enumerates the time formats by passing a pointer to a buffer containing a time format to an application-defined callback function.
        /// The first value in the enumeration is always the user default (override) value.
        /// The function continues enumeration until the last time format is found or the callback function returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function can enumerate data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the call can succeed because the system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark ("?").
        /// Note that any new values for <paramref name="dwFlags"/> introduced in the future will not work with the ANSI version.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumTimeFormatsW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumTimeFormats([In] TIMEFMT_ENUMPROC lpTimeFmtEnumProc, [In] LCID Locale, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// Enumerates the time formats that are available for a locale specified by name.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The application should call this function in preference to <see cref="EnumTimeFormats"/>
        /// if designed to run only on Windows Vista and later.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function can enumerate data that changes between releases, for example, due to a custom locale.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-enumtimeformatsex"/>
        /// </para>
        /// </summary>
        /// <param name="lpTimeFmtEnumProcEx">
        /// Pointer to an application-defined callback function.
        /// For more information, see <c>EnumTimeFormatsProcEx</c>.
        /// </param>
        /// <param name="lpLocaleName">
        /// <para>
        /// Pointer to a locale name, or one of the following predefined values.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="LOCALE_NAME_INVARIANT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// The time format.
        /// Set to 0 to use the current user's long time format,
        /// or <see cref="TIME_NOSECONDS"/> (starting with Windows 7) to use the short time format.
        /// </param>
        /// <param name="lParam">
        /// An application-provided parameter to be passed to the callback function.
        /// This is especially useful for multi-threaded applications.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_FLAGS"/>.
        /// The values supplied for flags were not valid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_PARAMETER"/>.
        /// Any of the parameter values was invalid.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function enumerates the time formats by passing time format string pointers, one at a time,
        /// to the specified application-defined callback function,
        /// along with an application-defined constant that is useful for multi-threaded applications.
        /// The first value in the enumeration is always the user default (override) value.
        /// The function continues enumeration until the last time format is found or the callback function returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the <c>Windows.Globalization</c> namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumTimeFormatsEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumTimeFormatsEx([In] TIMEFMT_ENUMPROCEX lpTimeFmtEnumProcEx,
            [In] LPCWSTR lpLocaleName, [In] DWORD dwFlags, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Converts a file time to MS-DOS date and time values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-filetimetodosdatetime"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileTime">
        /// A pointer to a <see cref="FILETIME"/> structure containing the file time to convert to MS-DOS date and time format.
        /// </param>
        /// <param name="FileTimeToDosDateTime">
        /// <para>
        /// A pointer to a variable to receive the MS-DOS date.
        /// The date is a packed value with the following format.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0–4
        /// </term>
        /// <term>
        /// Day of the month (1–31)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5–8
        /// </term>
        /// <term>
        /// Month (1 = January, 2 = February, etc.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 9-15
        /// </term>
        /// <term>
        /// Year offset from 1980 (add 1980 to get actual year)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpFatTime">
        /// <para>
        /// A pointer to a variable to receive the MS-DOS time.
        /// The time is a packed value with the following format.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0–4
        /// </term>
        /// <term>
        /// Second divided by 2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5–10
        /// </term>
        /// <term>
        /// Minute (0–59)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 11–15
        /// </term>
        /// <term>
        /// Hour (0–23 on a 24-hour clock)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        /// The MS-DOS date format can represent only dates between 1/1/1980 and 12/31/2107;
        /// this conversion fails if the input file time is outside this range.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FileTimeToDosDateTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FileTimeToDosDateTime([In] in FILETIME lpFileTime, [Out] out WORD FileTimeToDosDateTime, [Out] out WORD lpFatTime);

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
        /// Formats time as a time string for a locale specified by identifier.
        /// The function formats either a specified time or the local system time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/datetimeapi/nf-datetimeapi-gettimeformatw"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// <para>
        /// Locale identifier that specifies the locale.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_INVARIANT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_USER_DEFAULT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// Flags specifying time format options.
        /// For detailed definitions see the <paramref name="dwFlags"/> parameter of <see cref="GetTimeFormatEx"/>.
        /// </param>
        /// <param name="lpTime">
        /// Pointer to a <see cref="SYSTEMTIME"/> structure that contains the time information to format.
        /// The application can set this parameter to <see cref="NullRef{SYSTEMTIME}"/> if the function is to use the current local system time.
        /// </param>
        /// <param name="lpFormat">
        /// Pointer to a format picture to use to format the time string.
        /// If the application sets this parameter to <see cref="NULL"/>, the function formats the string according to the time format of the specified locale.
        /// If the application does not set the parameter to <see cref="NULL"/>, the function uses the locale only for information not specified
        /// in the format picture string, for example, the locale-specific time markers.
        /// For information about the format picture string, see the Remarks section.
        /// </param>
        /// <param name="lpTimeStr">
        /// Pointer to a buffer in which this function retrieves the formatted time string.
        /// </param>
        /// <param name="cchTime">
        /// Size, in TCHAR values, for the time string buffer indicated by <paramref name="lpTimeStr"/>.
        /// Alternatively, the application can set this parameter to 0.
        /// In this case, the function returns the required size for the time string buffer,
        /// and does not use the <paramref name="lpTimeStr"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns the number of TCHAR values retrieved in the buffer indicated by <paramref name="lpTimeStr"/>.
        /// If the <paramref name="cchTime"/> parameter is set to 0, the function returns the size of the buffer
        /// required to hold the formatted time string, including a terminating null character.
        /// </para>
        /// <para>
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_FLAGS"/>.
        /// The values supplied for flags were not valid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_PARAMETER"/>.
        /// Any of the parameter values was invalid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_OUTOFMEMORY"/>.
        /// Not enough storage was available to complete this operation.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// See Remarks for <see cref="GetTimeFormatEx"/>.
        /// </para>
        /// <para>
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the function can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark (?).
        /// </para>
        /// <para>
        /// Starting with Windows 8: <see cref="GetTimeFormat"/> is declared in Datetimeapi.h.
        /// Before Windows 8, it was declared in Winnls.h.
        /// </para>
        /// </remarks>
        [Obsolete("For interoperability reasons, the application should prefer the GetTimeFormatEx function to GetTimeFormat " +
            "because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales. " +
            "Any application that will be run only on Windows Vista and later should use GetTimeFormatEx.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTimeFormatW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetTimeFormat([In] LCID Locale, [In] GetTimeFormatFlags dwFlags, [In] in SYSTEMTIME lpTime, [In] LPCWSTR lpFormat,
            [In] LPWSTR lpTimeStr, [In] int cchTime);

        /// <summary>
        /// <para>
        /// Formats time as a time string for a locale specified by name.
        /// The function formats either a specified time or the local system time.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The application should call this function in preference to <see cref="GetTimeFormat"/> if designed to run only on Windows Vista and later.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function can format data that changes between releases, for example, due to a custom locale.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/datetimeapi/nf-datetimeapi-gettimeformatex"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleName">
        /// <para>
        /// Pointer to a locale name, or one of the following predefined values.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="LOCALE_NAME_INVARIANT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Flags specifying time format options.
        /// The application can specify a combination of the following values and <see cref="LOCALE_USE_CP_ACP"/> or <see cref="LOCALE_NOUSEROVERRIDE"/>.
        /// </para>
        /// <para>
        /// Caution
        /// </para>
        /// <para>
        /// Use of <see cref="LOCALE_NOUSEROVERRIDE"/> is strongly discouraged as it disables user preferences. 
        /// </para>
        /// <para>
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
        /// <see cref="TIME_NOMINUTESORSECONDS"/>
        /// </term>
        /// <term>
        /// Do not use minutes or seconds.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TIME_NOSECONDS"/>
        /// </term>
        /// <term>
        /// Do not use seconds.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TIME_NOTIMEMARKER"/>
        /// </term>
        /// <term>
        /// Do not use a time marker.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TIME_FORCE24HOURFORMAT"/>
        /// </term>
        /// <term>
        /// Always use a 24-hour time format.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpTime">
        /// Pointer to a <see cref="SYSTEMTIME"/> structure that contains the time information to format.
        /// The application can set this parameter to <see cref="NullRef{SYSTEMTIME}"/> if the function is to use the current local system time.
        /// </param>
        /// <param name="lpFormat">
        /// Pointer to a format picture to use to format the time string.
        /// If the application sets this parameter to <see cref="NULL"/>, the function formats the string according to the time format of the specified locale.
        /// If the application does not set the parameter to <see cref="NULL"/>, the function uses the locale only
        /// for information not specified in the format picture string, for example, the locale-specific time markers.
        /// For information about the format picture string, see the Remarks section.
        /// </param>
        /// <param name="lpTimeStr">
        /// Pointer to a buffer in which this function retrieves the formatted time string.
        /// </param>
        /// <param name="cchTime">
        /// Size, in characters, for the time string buffer indicated by <paramref name="lpTimeStr"/>.
        /// Alternatively, the application can set this parameter to 0.
        /// In this case, the function returns the required size for the time string buffer, and does not use the <paramref name="lpTimeStr"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns the number of characters retrieved in the buffer indicated by <paramref name="lpTimeStr"/>.
        /// If the <paramref name="cchTime"/> parameter is set to 0, the function returns the size of the buffer
        /// required to hold the formatted time string, including a terminating null character.
        /// </para>
        /// <para>
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_FLAGS"/>.
        /// The values supplied for flags were not valid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_INVALID_PARAMETER"/>.
        /// Any of the parameter values was invalid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ERROR_OUTOFMEMORY"/>.
        /// Not enough storage was available to complete this operation.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If a time marker exists and the <see cref="TIME_NOTIMEMARKER"/> flag is not set,
        /// the function localizes the time marker based on the specified locale identifier.
        /// Examples of time markers are "AM" and "PM" for English (United States).
        /// </para>
        /// <para>
        /// The time values in the structure indicated by <paramref name="lpTime"/> must be valid.
        /// The function checks each of the time values to determine that it is within the appropriate range of values.
        /// If any of the time values are outside the correct range, the function fails, and sets the last error to <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// <para>
        /// The function ignores the date members of the <see cref="SYSTEMTIME"/> structure.
        /// These include: <see cref="SYSTEMTIME.wYear"/>, <see cref="SYSTEMTIME.wMonth"/>, <see cref="SYSTEMTIME.wDayOfWeek"/>, and <see cref="SYSTEMTIME.wDay"/>.
        /// </para>
        /// <para>
        /// If <see cref="TIME_NOMINUTESORSECONDS"/> or <see cref="TIME_NOSECONDS"/> is specified,
        /// the function removes the separators following the minutes and/or seconds members.
        /// </para>
        /// <para>
        /// If <see cref="TIME_NOTIMEMARKER"/> is specified, the function removes the separators preceding and following the time marker.
        /// </para>
        /// <para>
        /// If <see cref="TIME_FORCE24HOURFORMAT"/> is specified, the function displays any existing time marker,
        /// unless the <see cref="TIME_NOTIMEMARKER"/> flag is also set.
        /// </para>
        /// <para>
        /// The function does not include milliseconds as part of the formatted time string.
        /// </para>
        /// <para>
        /// The function returns no errors for a bad format string, but just forms the best possible time string.
        /// If more than two hour, minute, second, or time marker format pictures are passed in, the function defaults to two.
        /// For example, the only time marker pictures that are valid are "t" and "tt".
        /// If "ttt" is passed in, the function assumes "tt".
        /// </para>
        /// <para>
        /// To obtain the time format without performing any actual formatting,
        /// the application should use the <see cref="GetLocaleInfoEx"/> function, specifying <see cref="LOCALE_STIMEFORMAT"/>.
        /// </para>
        /// <para>
        /// The application can use the following elements to construct a format picture string.
        /// If spaces are used to separate the elements in the format string, these spaces appear in the same location in the output string.
        /// The letters must be in uppercase or lowercase as shown, for example, "ss", not "SS".
        /// Characters in the format string that are enclosed in single quotation marks appear in the same location and unchanged in the output string.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Picture
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// h
        /// </term>
        /// <term>
        /// Hours with no leading zero for single-digit hours; 12-hour clock
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// hh
        /// </term>
        /// <term>
        /// Hours with leading zero for single-digit hours; 12-hour clock
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// H
        /// </term>
        /// <term>
        /// Hours with no leading zero for single-digit hours; 24-hour clock
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// HH
        /// </term>
        /// <term>
        /// Hours with leading zero for single-digit hours; 24-hour clock
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// m
        /// </term>
        /// <term>
        /// Minutes with no leading zero for single-digit minutes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// mm
        /// </term>
        /// <term>
        /// Minutes with leading zero for single-digit minutes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// s
        /// </term>
        /// <term>
        /// Seconds with no leading zero for single-digit seconds
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// ss
        /// </term>
        /// <term>
        /// Seconds with leading zero for single-digit seconds
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// t
        /// </term>
        /// <term>
        /// One character time marker string, such as A or P
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// tt
        /// </term>
        /// <term>
        /// Multi-character time marker string, such as AM or PM
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For example, to get the time string
        /// </para>
        /// <code>
        /// "11:29:40 PM"
        /// </code>
        /// <para>
        /// the application should use the picture string
        /// </para>
        /// <code>
        /// "hh':'mm':'ss tt"
        /// </code>
        /// <para>
        /// This function can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// Beginning in Windows 8: If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </para>
        /// <para>
        /// Beginning in Windows 8: <see cref="GetTimeFormatEx"/> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTimeFormatEx", ExactSpelling = true, SetLastError = true)]
        public static extern int GetTimeFormatEx([In] LPCWSTR lpLocaleName, [In] GetTimeFormatFlags dwFlags, [In] in SYSTEMTIME lpTime, [In] LPCWSTR lpFormat,
            [In] LPWSTR lpTimeStr, [In] int cchTime);

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
