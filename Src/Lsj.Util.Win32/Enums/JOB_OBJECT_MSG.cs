namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// JOB_OBJECT_MSG
    /// </summary>
    public enum JOB_OBJECT_MSG : uint
    {
        /// <summary>
        /// JOB_OBJECT_MSG_END_OF_JOB_TIME
        /// </summary>
        JOB_OBJECT_MSG_END_OF_JOB_TIME = 1,

        /// <summary>
        /// JOB_OBJECT_MSG_END_OF_PROCESS_TIME
        /// </summary>
        JOB_OBJECT_MSG_END_OF_PROCESS_TIME = 2,

        /// <summary>
        /// JOB_OBJECT_MSG_ACTIVE_PROCESS_LIMIT
        /// </summary>
        JOB_OBJECT_MSG_ACTIVE_PROCESS_LIMIT = 3,

        /// <summary>
        /// JOB_OBJECT_MSG_ACTIVE_PROCESS_ZERO
        /// </summary>
        JOB_OBJECT_MSG_ACTIVE_PROCESS_ZERO = 4,

        /// <summary>
        /// JOB_OBJECT_MSG_NEW_PROCESS
        /// </summary>
        JOB_OBJECT_MSG_NEW_PROCESS = 6,

        /// <summary>
        /// JOB_OBJECT_MSG_EXIT_PROCESS
        /// </summary>
        JOB_OBJECT_MSG_EXIT_PROCESS = 7,

        /// <summary>
        /// JOB_OBJECT_MSG_ABNORMAL_EXIT_PROCESS
        /// </summary>
        JOB_OBJECT_MSG_ABNORMAL_EXIT_PROCESS = 8,

        /// <summary>
        /// JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT
        /// </summary>
        JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT = 9,

        /// <summary>
        /// JOB_OBJECT_MSG_JOB_MEMORY_LIMIT
        /// </summary>
        JOB_OBJECT_MSG_JOB_MEMORY_LIMIT = 10,

        /// <summary>
        /// JOB_OBJECT_MSG_NOTIFICATION_LIMIT
        /// </summary>
        JOB_OBJECT_MSG_NOTIFICATION_LIMIT = 11,

        /// <summary>
        /// JOB_OBJECT_MSG_JOB_CYCLE_TIME_LIMIT
        /// </summary>
        JOB_OBJECT_MSG_JOB_CYCLE_TIME_LIMIT = 12,

        /// <summary>
        /// JOB_OBJECT_MSG_SILO_TERMINATED
        /// </summary>
        JOB_OBJECT_MSG_SILO_TERMINATED = 13,
    }
}
