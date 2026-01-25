using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the power status of the system.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-system_power_status"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The system is only capable of estimating <see cref="BatteryFullLifeTime"/>
    /// based on calculations on <see cref="BatteryLifeTime"/> and <see cref="BatteryLifePercent"/>.
    /// Without smart battery subsystems, this value may not be accurate enough to be useful.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SYSTEM_POWER_STATUS
    {
        /// <summary>
        /// <para>
        /// The AC power status.
        /// This member can be one of the following values.
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
        /// 0
        /// </term>
        /// <term>
        /// Offline
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Online
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 255
        /// </term>
        /// <term>
        /// Unknown status
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BYTE ACLineStatus;

        /// <summary>
        /// <para>
        /// The battery charge status.
        /// This member can contain one or more of the following flags.
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
        /// 1
        /// </term>
        /// <term>
        /// High—the battery capacity is at more than 66 percent
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// Low—the battery capacity is at less than 33 percent
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 4
        /// </term>
        /// <term>
        /// Critical—the battery capacity is at less than five percent
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 8
        /// </term>
        /// <term>
        /// Charging
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 128
        /// </term>
        /// <term>
        /// No system battery
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 255
        /// </term>
        /// <term>
        /// Unknown status—unable to read the battery flag information
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The value is zero if the battery is not being charged and the battery capacity is between low and high.
        /// </para>
        /// </summary>
        public BYTE BatteryFlag;

        /// <summary>
        /// The percentage of full battery charge remaining.
        /// This member can be a value in the range 0 to 100, or 255 if status is unknown.
        /// </summary>
        public BYTE BatteryLifePercent;

        /// <para>
        /// The status of battery saver.
        /// To participate in energy conservation, avoid resource intensive tasks when battery saver is on.
        /// To be notified when this value changes, call the <see cref="RegisterPowerSettingNotification"/> function
        /// with the power setting GUID, <see cref="GUID_POWER_SAVING_STATUS"/>.
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
        /// 0
        /// </term>
        /// <term>
        /// Battery saver is off.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Battery saver on. Save energy where possible.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This flag and the <see cref="GUID_POWER_SAVING_STATUS"/> GUID were introduced in Windows 10.
        /// This flag was previously reserved, named <c>Reserved1</c>, and had a value of 0.
        /// </para>
        /// <para>
        /// For general information about battery saver, see battery saver (in the hardware component guidelines).
        /// </para>
        public BYTE SystemStatusFlag;

        /// <summary>
        /// The number of seconds of battery life remaining,
        /// or –1 if remaining seconds are unknown or if the device is connected to AC power.
        /// </summary>
        public DWORD BatteryLifeTime;

        /// <summary>
        /// The number of seconds of battery life when at full charge,
        /// or –1 if full battery lifetime is unknown or if the device is connected to AC power.
        /// </summary>
        public DWORD BatteryFullLifeTime;
    }
}
