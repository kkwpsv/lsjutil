namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Process priority classes
    /// </summary>
    public enum ProcessPriorityClasses
    {
        /// <summary>
        /// ABOVE_NORMAL_PRIORITY_CLASS
        /// </summary>
        ABOVE_NORMAL_PRIORITY_CLASS = 0x00008000,

        /// <summary>
        /// BELOW_NORMAL_PRIORITY_CLASS
        /// </summary>
        BELOW_NORMAL_PRIORITY_CLASS = 0x00004000,

        /// <summary>
        /// HIGH_PRIORITY_CLASS
        /// </summary>
        HIGH_PRIORITY_CLASS = 0x00000080,

        /// <summary>
        /// IDLE_PRIORITY_CLASS
        /// </summary>
        IDLE_PRIORITY_CLASS = 0x00000040,

        /// <summary>
        /// NORMAL_PRIORITY_CLASS
        /// </summary>
        NORMAL_PRIORITY_CLASS = 0x00000020,

        /// <summary>
        /// PROCESS_MODE_BACKGROUND_BEGIN
        /// </summary>
        PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000,

        /// <summary>
        /// PROCESS_MODE_BACKGROUND_END
        /// </summary>
        PROCESS_MODE_BACKGROUND_END = 0x00200000,

        /// <summary>
        /// REALTIME_PRIORITY_CLASS
        /// </summary>
        REALTIME_PRIORITY_CLASS = 0x00000100,
    }
}
