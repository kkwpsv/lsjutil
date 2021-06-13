using static Lsj.Util.Win32.Enums.ProcessPriorityClasses;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Thread Priority Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getthreadpriority"/>
    /// </para>
    /// </summary>
    public enum ThreadPriorityFlags
    {
        /// <summary>
        /// Priority 1 point above the priority class.
        /// </summary>
        THREAD_PRIORITY_ABOVE_NORMAL = 1,

        /// <summary>
        /// Priority 1 point below the priority class.
        /// </summary>
        THREAD_PRIORITY_BELOW_NORMAL = -1,

        /// <summary>
        /// Priority 2 points above the priority class.
        /// </summary>
        THREAD_PRIORITY_HIGHEST = 2,

        /// <summary>
        /// Base priority of 1 for <see cref="IDLE_PRIORITY_CLASS"/>, <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>,
        /// <see cref="NORMAL_PRIORITY_CLASS"/>, <see cref="ABOVE_NORMAL_PRIORITY_CLASS"/>, or <see cref="HIGH_PRIORITY_CLASS"/> processes,
        /// and a base priority of 16 for <see cref="REALTIME_PRIORITY_CLASS"/> processes.
        /// </summary>
        THREAD_PRIORITY_IDLE = -15,

        /// <summary>
        /// Priority 2 points below the priority class.
        /// </summary>
        THREAD_PRIORITY_LOWEST = -2,

        /// <summary>
        /// Normal priority for the priority class.
        /// </summary>
        THREAD_PRIORITY_NORMAL = 0,

        /// <summary>
        /// Base-priority level of 15 for <see cref="IDLE_PRIORITY_CLASS"/>, <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>,
        /// <see cref="NORMAL_PRIORITY_CLASS"/>, <see cref="ABOVE_NORMAL_PRIORITY_CLASS"/>, or <see cref="HIGH_PRIORITY_CLASS"/> processes,
        /// and a base-priority level of 31 for <see cref="REALTIME_PRIORITY_CLASS"/> processes.
        /// </summary>
        THREAD_PRIORITY_TIME_CRITICAL = 15,

        /// <summary>
        /// 
        /// </summary>
        THREAD_PRIORITY_ERROR_RETURN = int.MaxValue,

        /// <summary>
        /// THREAD_MODE_BACKGROUND_BEGIN
        /// </summary>
        THREAD_MODE_BACKGROUND_BEGIN =    0x00010000,

        /// <summary>
        /// THREAD_MODE_BACKGROUND_END
        /// </summary>
        THREAD_MODE_BACKGROUND_END =   0x00020000,
    }
}
