namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines the types of hardware counters being profiled.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-hardware_counter_type"/>
    /// </para>
    /// </summary>
    public enum HARDWARE_COUNTER_TYPE
    {
        /// <summary>
        /// Hardware performance monitoring counters.
        /// </summary>
        PMCCounter,

        /// <summary>
        /// The maximum enumeration value for this enumeration.
        /// </summary>
        MaxHardwareCounterType
    }
}
