using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOLEAN;
using static Lsj.Util.Win32.Enums.RegistryValueTypes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies settings for a time zone and dynamic daylight saving time.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timezoneapi/ns-timezoneapi-dynamic_time_zone_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Dynamic daylight saving time provides support for time zones whose boundaries for daylight saving time change from year to year.
    /// This feature enables easier updating of systems, especially for locales where the yearly DST boundaries are known in advance.
    /// After the time zone has been updated, the current time zone setting is applied to all time operations,
    /// even when the time in question occurred before the time zone changed.
    /// Therefore, it is best to store UTC times and convert them to the current local time zone.
    /// </para>
    /// <para>
    /// You can set the transition dates for the current year using the <see cref="SetDynamicTimeZoneInformation"/> function.
    /// To set future transition dates, you must add entries to the registry data.
    /// The settings for dynamic daylight time are stored in the following registry key:
    /// </para>
    /// <code>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones\time_zone_name\Dynamic DST</code>
    /// <para>
    /// Each Dynamic DST key includes the following registry values.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Registry value
    /// </term>
    /// <term>
    /// Type
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// FirstEntry
    /// </term>
    /// <term>
    /// <see cref="REG_DWORD"/>
    /// </term>
    /// <term>
    /// The first year in the table.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// LastEntry
    /// </term>
    /// <term>
    /// <see cref="REG_DWORD"/>
    /// </term>
    /// <term>
    /// The last year in the table.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// year1
    /// </term>
    /// <term>
    /// <see cref="REG_BINARY"/>
    /// </term>
    /// <term>
    /// <para>
    /// The following time zone information.
    /// </para>
    /// <code>
    /// typedef struct _REG_TZI_FORMAT
    /// {
    ///     LONG Bias;
    ///     LONG StandardBias;
    ///     LONG DaylightBias;
    ///     SYSTEMTIME StandardDate;
    ///     SYSTEMTIME DaylightDate;
    /// } REG_TZI_FORMAT;
    /// </code>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// year2
    /// </term>
    /// <term>
    /// <see cref="REG_BINARY"/>
    /// </term>
    /// <term>
    /// A <see cref="REG_TZI_FORMAT"/> structure.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// yearN
    /// </term>
    /// <term>
    /// <see cref="REG_BINARY"/>
    /// </term>
    /// <term>
    /// A <see cref="REG_TZI_FORMAT"/> structure.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// For more information on other values in the Time Zones key, see <see cref="TIME_ZONE_INFORMATION"/>.
    /// </para>
    /// <para>
    /// Both <see cref="StandardName"/> and <see cref="DaylightName"/> are localized according to the current user default UI language.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DYNAMIC_TIME_ZONE_INFORMATION
    {
        /// <summary>
        /// <para>
        /// The current bias for local time translation on this computer, in minutes.
        /// The bias is the difference, in minutes, between Coordinated Universal Time (UTC) and local time.
        /// All translations between UTC and local time are based on the following formula:
        /// </para>
        /// <para>
        /// UTC = local time + bias
        /// </para>
        /// <para>
        /// This member is required.
        /// </para>
        /// </summary>
        public LONG Bias;

        /// <summary>
        /// A description for standard time.
        /// For example, "EST" could indicate Eastern Standard Time.
        /// The string will be returned unchanged by the <see cref="GetDynamicTimeZoneInformation"/> function.
        /// This string can be empty.
        /// </summary>
        public ByValStringStructForSize32 StandardName;

        /// <summary>
        /// <para>
        /// A <see cref="SYSTEMTIME"/> structure that contains a date and local time when the transition
        /// from daylight saving time to standard time occurs on this operating system.
        /// If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time,
        /// the <see cref="SYSTEMTIME.wMonth"/> member in the <see cref="SYSTEMTIME"/> structure must be zero.
        /// If this date is specified, the <see cref="DaylightDate"/> member of this structure must also be specified.
        /// Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
        /// </para>
        /// <para>
        /// To select the correct day in the month, set the <see cref="SYSTEMTIME.wYear"/> member to zero,
        /// the <see cref="SYSTEMTIME.wHour"/> and <see cref="SYSTEMTIME.wMinute"/> members to the transition time,
        /// the <see cref="SYSTEMTIME.wDayOfWeek"/> member to the appropriate weekday,
        /// and the <see cref="SYSTEMTIME.wDay"/> member to indicate the occurrence of the day of the week within the month
        /// (1 to 5, where 5 indicates the final occurrence during the month if that day of the week does not occur 5 times).
        /// </para>
        /// <para>
        /// Using this notation, specify 02:00 on the first Sunday in April as follows:
        /// <see cref="SYSTEMTIME.wHour"/> = 2, <see cref="SYSTEMTIME.wMonth"/> = 4,
        /// <see cref="SYSTEMTIME.wDayOfWeek"/> = 0, <see cref="SYSTEMTIME.wDay"/> = 1. 
        /// Specify 02:00 on the last Thursday in October as follows:
        /// <see cref="SYSTEMTIME.wHour"/> = 2, <see cref="SYSTEMTIME.wMonth"/> = 10,
        /// <see cref="SYSTEMTIME.wDayOfWeek"/> = 4, <see cref="SYSTEMTIME.wDay"/> = 5.
        /// </para>
        /// <para>
        /// If the <see cref="SYSTEMTIME.wYear"/> member is not zero, the transition date is absolute; it will only occur one time.
        /// Otherwise, it is a relative date that occurs yearly.
        /// </para>
        /// </summary>
        public SYSTEMTIME StandardDate;

        /// <para>
        /// The bias value to be used during local time translations that occur during standard time.
        /// This member is ignored if a value for the <see cref="StandardDate"/> member is not supplied.
        /// </para>
        /// <para>
        /// This value is added to the value of the <see cref="Bias"/> member to form the bias used during standard time.
        /// In most time zones, the value of this member is zero.
        /// </para>
        /// </summary>
        public LONG StandardBias;

        /// <summary>
        /// A description for daylight saving time (DST).
        /// For example, "PDT" could indicate Pacific Daylight Time.
        /// The string will be returned unchanged by the <see cref="GetDynamicTimeZoneInformation"/> function.
        /// This string can be empty.
        /// </summary>
        public ByValStringStructForSize32 DaylightName;

        /// <summary>
        /// <para>
        /// A <see cref="SYSTEMTIME"/> structure that contains a date and local time
        /// when the transition from standard time to daylight saving time occurs on this operating system.
        /// If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time,
        /// the <see cref="SYSTEMTIME.wMonth"/> member in the <see cref="SYSTEMTIME"/> structure must be zero.
        /// If this date is specified, the <see cref="StandardDate"/> member in this structure must also be specified.
        /// Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
        /// </para>
        /// <para>
        /// To select the correct day in the month, set the <see cref="SYSTEMTIME.wYear"/> member to zero,
        /// the <see cref="SYSTEMTIME.wHour"/> and <see cref="SYSTEMTIME.Minute"/> members to the transition time,
        /// the <see cref="SYSTEMTIME.wDayOfWeek"/> member to the appropriate weekday,
        /// and the <see cref="SYSTEMTIME.wDay"/> member to indicate the occurrence of the day of the week within the month
        /// (1 to 5, where 5 indicates the final occurrence during the month if that day of the week does not occur 5 times).
        /// </para>
        /// <para>
        /// If the <see cref="SYSTEMTIME.wYear"/> member is not zero, the transition date is absolute; it will only occur one time.
        /// Otherwise, it is a relative date that occurs yearly.
        /// </para>
        /// </summary>
        public SYSTEMTIME DaylightDate;

        /// <summary>
        /// <para>
        /// The bias value to be used during local time translations that occur during daylight saving time.
        /// This member is ignored if a value for the <see cref="DaylightDate"/> member is not supplied.
        /// </para>
        /// <para>
        /// This value is added to the value of the <see cref="Bias"/> member to form the bias used during daylight saving time.
        /// In most time zones, the value of this member is –60.
        /// </para>
        /// </summary>
        public LONG DaylightBias;

        /// <summary>
        /// The name of the time zone registry key on the local computer.
        /// For more information, see Remarks.
        /// </summary>
        public ByValStringStructForSize128 TimeZoneKeyName;

        /// <summary>
        /// <para>
        /// Indicates whether dynamic daylight saving time is disabled.
        /// Setting this member to <see cref="TRUE"/> disables dynamic daylight saving time,
        /// causing the system to use a fixed set of transition dates.
        /// </para>
        /// <para>
        /// To restore dynamic daylight saving time, call the <see cref="SetDynamicTimeZoneInformation"/> function
        /// with <see cref="DynamicDaylightTimeDisabled"/> set to <see cref="FALSE"/>.
        /// The system will read the transition dates for the current year at the next time update,
        /// the next system reboot, or the end of the calendar year (whichever comes first.)
        /// </para>
        /// <para>
        /// When calling the <see cref="GetDynamicTimeZoneInformation"/> function,
        /// this member is <see cref="TRUE"/> if the time zone was set using the <see cref="SetTimeZoneInformation"/> function
        /// instead of <see cref="SetDynamicTimeZoneInformation"/> or if the user has disabled this feature using the Date and Time application in Control Panel.
        /// </para>
        /// <para>
        /// To disable daylight saving time, set this member to <see cref="TRUE"/>,
        /// clear the <see cref="StandardDate"/> and <see cref="DaylightDate"/> members, and call <see cref="SetDynamicTimeZoneInformation"/>.
        /// To restore daylight saving time, call <see cref="SetDynamicTimeZoneInformation"/>
        /// with <see cref="DynamicDaylightTimeDisabled"/> set to <see cref="FALSE"/>.
        /// </para>
        /// </summary>
        public BOOLEAN DynamicDaylightTimeDisabled;
    }
}
