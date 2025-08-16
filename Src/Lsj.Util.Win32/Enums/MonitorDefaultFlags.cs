namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Monitor default flags
    /// </summary>
    public enum MonitorDefaultFlags
    {
        /// <summary>
        /// Returns NULL.
        /// </summary>
        MONITOR_DEFAULTTONULL = 0,

        /// <summary>
        /// MONITOR_DEFAULTTOPRIMARY
        /// </summary>
        MONITOR_DEFAULTTONEAREST = 1,

        /// <summary>
        /// MONITOR_DEFAULTTONEAREST
        /// </summary>
        MONITOR_DEFAULTTOPRIMARY = 2,
    }
}
