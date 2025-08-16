namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Thread priority flags
    /// </summary>
    public enum ThreadPriorityFlags
    {
        /// <summary>
        /// THREAD_PRIORITY_ABOVE_NORMAL
        /// </summary>
        THREAD_PRIORITY_ABOVE_NORMAL = 1,

        /// <summary>
        /// THREAD_PRIORITY_BELOW_NORMAL
        /// </summary>
        THREAD_PRIORITY_BELOW_NORMAL = -1,

        /// <summary>
        /// THREAD_PRIORITY_HIGHEST
        /// </summary>
        THREAD_PRIORITY_HIGHEST = 2,

        /// <summary>
        /// THREAD_PRIORITY_IDLE
        /// </summary>
        THREAD_PRIORITY_IDLE = -15,

        /// <summary>
        /// THREAD_PRIORITY_LOWEST
        /// </summary>
        THREAD_PRIORITY_LOWEST = -2,

        /// <summary>
        /// THREAD_PRIORITY_NORMAL
        /// </summary>
        THREAD_PRIORITY_NORMAL = 0,

        /// <summary>
        /// THREAD_PRIORITY_TIME_CRITICAL
        /// </summary>
        THREAD_PRIORITY_TIME_CRITICAL = 15,

        /// <summary>
        /// THREAD_PRIORITY_ERROR_RETURN
        /// </summary>
        THREAD_PRIORITY_ERROR_RETURN = int.MaxValue,

        /// <summary>
        /// THREAD_MODE_BACKGROUND_BEGIN
        /// </summary>
        THREAD_MODE_BACKGROUND_BEGIN = 0x00010000,

        /// <summary>
        /// THREAD_MODE_BACKGROUND_END
        /// </summary>
        THREAD_MODE_BACKGROUND_END = 0x00020000,
    }
}
