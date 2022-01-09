using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.RegistryValueTypes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies settings for a time zone.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/timezoneapi/ns-timezoneapi-time_zone_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Settings for each time zone are stored in the following registry key:
    /// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones\time_zone_name
    /// Each Dynamic DST key includes the following registry values.
    /// Display     <see cref="REG_SZ"/>        The display name.
    /// Dlt         <see cref="REG_SZ"/>        The first year in the table.
    /// MUI_Display <see cref="REG_SZ"/>        The display name as a string of the form @path,-stringID[;comment]. For more information, see MUI.
    /// MUI_Dlt     <see cref="REG_SZ"/>        The description for daylight time as a string of the form @path,-stringID[;comment].
    /// MUI_Std     <see cref="REG_SZ"/>        The description for standard time as a string of the form @path,-stringID[;comment].
    /// Std         <see cref="REG_SZ"/>        The description for standard time.
    /// TZI         <see cref="REG_BINARY"/>  A <see cref="REG_TZI_FORMAT"/> structure.
    /// For more information about the Dynamic DST key, see <see cref="DYNAMIC_TIME_ZONE_INFORMATION"/>.
    /// Both <see cref="StandardName"/> and <see cref="DaylightName"/> are localized according to the current user default UI language.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TIME_ZONE_INFORMATION
    {
        /// <summary>
        /// The current bias for local time translation on this computer, in minutes.
        /// The bias is the difference, in minutes, between Coordinated Universal Time (UTC) and local time.
        /// All translations between UTC and local time are based on the following formula:
        /// UTC = local time + bias
        /// This member is required.
        /// </summary>
        public LONG Bias;

        /// <summary>
        /// A description for standard time.
        /// For example, "EST" could indicate Eastern Standard Time.
        /// The string will be returned unchanged by the <see cref="GetTimeZoneInformation"/> function.
        /// This string can be empty.
        /// </summary>
        public ByValStringStructForSize32 StandardName;

        /// <summary>
        /// A <see cref="SYSTEMTIME"/> structure that contains a date and local time
        /// when the transition from daylight saving time to standard time occurs on this operating system.
        /// If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time,
        /// the <see cref="SYSTEMTIME.wMonth"/> member in the <see cref="SYSTEMTIME"/> structure must be zero.
        /// If this date is specified, the <see cref="DaylightDate"/> member of this structure must also be specified.
        /// Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
        /// To select the correct day in the month, set the <see cref="SYSTEMTIME.wYear"/> member to zero,
        /// the <see cref="SYSTEMTIME.wHour"/> and <see cref="SYSTEMTIME.wMinute"/> members to the transition time,
        /// the <see cref="SYSTEMTIME.wDayOfWeek"/> member to the appropriate weekday,
        /// and the <see cref="SYSTEMTIME.wDay"/> member to indicate the occurrence of the day of the week within the month
        /// (1 to 5, where 5 indicates the final occurrence during the month if that day of the week does not occur 5 times).
        /// Using this notation, specify 02:00 on the first Sunday in April as follows:
        /// <see cref="SYSTEMTIME.wHour"/> = 2, <see cref="SYSTEMTIME.wMonth"/> = 4,
        /// <see cref="SYSTEMTIME.wDayOfWeek"/> = 0, <see cref="SYSTEMTIME.wDay"/> = 1.
        /// Specify 02:00 on the last Thursday in October as follows:
        /// <see cref="SYSTEMTIME.wHour"/> = 2, <see cref="SYSTEMTIME.wMonth"/> = 10,
        /// <see cref="SYSTEMTIME.wDayOfWeek"/> = 4, <see cref="SYSTEMTIME.wDay"/> = 5.
        /// If the <see cref="SYSTEMTIME.wYear"/> member is not zero, the transition date is absolute;
        /// it will only occur one time. Otherwise, it is a relative date that occurs yearly.
        /// </summary>
        public SYSTEMTIME StandardDate;

        /// <summary>
        /// The bias value to be used during local time translations that occur during standard time.
        /// This member is ignored if a value for the <see cref="StandardDate"/> member is not supplied.
        /// This value is added to the value of the <see cref="Bias"/> member to form the bias used during standard time.
        /// In most time zones, the value of this member is zero.
        /// </summary>
        public LONG StandardBias;

        /// <summary>
        /// A description for daylight saving time (DST).
        /// For example, "PDT" could indicate Pacific Daylight Time.
        /// The string will be returned unchanged by the <see cref="GetTimeZoneInformation"/> function.
        /// This string can be empty.
        /// </summary>
        public ByValStringStructForSize32 DaylightName;

        /// <summary>
        /// A <see cref="SYSTEMTIME"/> structure that contains a date and local time
        /// when the transition from standard time to daylight saving time occurs on this operating system.
        /// If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time,
        /// the <see cref="SYSTEMTIME.wMonth"/> member in the <see cref="SYSTEMTIME"/> structure must be zero.
        /// If this date is specified, the <see cref="StandardDate"/> member in this structure must also be specified.
        /// Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
        /// To select the correct day in the month, set the <see cref="SYSTEMTIME.wYear"/> member to zero,
        /// the <see cref="SYSTEMTIME.wHour"/> and <see cref="SYSTEMTIME.wMinute"/> members to the transition time,
        /// the <see cref="SYSTEMTIME.wDayOfWeek"/> member to the appropriate weekday,
        /// and the <see cref="SYSTEMTIME.wDay"/> member to indicate the occurrence of the day of the week within the month
        /// (1 to 5, where 5 indicates the final occurrence during the month if that day of the week does not occur 5 times).
        /// If the <see cref="SYSTEMTIME.wYear"/> member is not zero, the transition date is absolute; it will only occur one time.
        /// Otherwise, it is a relative date that occurs yearly.
        /// </summary>
        public SYSTEMTIME DaylightDate;

        /// <summary>
        /// The bias value to be used during local time translations that occur during daylight saving time.
        /// This member is ignored if a value for the <see cref="DaylightDate"/> member is not supplied.
        /// This value is added to the value of the Bias member to form the bias used during daylight saving time.
        /// In most time zones, the value of this member is –60.
        /// </summary>
        public LONG DaylightBias;
    }
}
