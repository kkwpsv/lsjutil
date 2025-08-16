using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Job object limit flags
    /// </summary>
    [Flags]
    public enum JobObjectLimitFlags
    {
        /// <summary>
        /// JOB_OBJECT_LIMIT_ACTIVE_PROCESS
        /// </summary>
        JOB_OBJECT_LIMIT_ACTIVE_PROCESS = 0x00000008,

        /// <summary>
        /// JOB_OBJECT_LIMIT_AFFINITY
        /// </summary>
        JOB_OBJECT_LIMIT_AFFINITY = 0x00000010,

        /// <summary>
        /// JOB_OBJECT_LIMIT_BREAKAWAY_OK
        /// </summary>
        JOB_OBJECT_LIMIT_BREAKAWAY_OK = 0x00000800,

        /// <summary>
        /// JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION
        /// </summary>
        JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION = 0x00000400,

        /// <summary>
        /// JOB_OBJECT_LIMIT_JOB_MEMORY
        /// </summary>
        JOB_OBJECT_LIMIT_JOB_MEMORY = 0x00000200,

        /// <summary>
        /// JOB_OBJECT_LIMIT_JOB_TIME
        /// </summary>
        JOB_OBJECT_LIMIT_JOB_TIME = 0x00000004,

        /// <summary>
        /// JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE
        /// </summary>
        JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE = 0x00002000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME
        /// </summary>
        JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME = 0x00000040,

        /// <summary>
        /// JOB_OBJECT_LIMIT_PRIORITY_CLASS
        /// </summary>
        JOB_OBJECT_LIMIT_PRIORITY_CLASS = 0x00000020,

        /// <summary>
        /// JOB_OBJECT_LIMIT_PROCESS_MEMORY
        /// </summary>
        JOB_OBJECT_LIMIT_PROCESS_MEMORY = 0x00000100,

        /// <summary>
        /// JOB_OBJECT_LIMIT_PROCESS_TIME
        /// </summary>
        JOB_OBJECT_LIMIT_PROCESS_TIME = 0x00000002,

        /// <summary>
        /// JOB_OBJECT_LIMIT_SCHEDULING_CLASS
        /// </summary>
        JOB_OBJECT_LIMIT_SCHEDULING_CLASS = 0x00000080,

        /// <summary>
        /// JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK
        /// </summary>
        JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK = 0x00001000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_SUBSET_AFFINITY
        /// </summary>
        JOB_OBJECT_LIMIT_SUBSET_AFFINITY = 0x00004000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_WORKINGSET
        /// </summary>
        JOB_OBJECT_LIMIT_WORKINGSET = 0x00000001,

        /// <summary>
        /// JOB_OBJECT_LIMIT_JOB_READ_BYTES
        /// </summary>
        JOB_OBJECT_LIMIT_JOB_READ_BYTES = 0x00010000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_JOB_WRITE_BYTES
        /// </summary>
        JOB_OBJECT_LIMIT_JOB_WRITE_BYTES = 0x00020000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_RATE_CONTROL
        /// </summary>
        JOB_OBJECT_LIMIT_RATE_CONTROL = 0x00040000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_JOB_MEMORY_HIGH
        /// </summary>
        JOB_OBJECT_LIMIT_JOB_MEMORY_HIGH = 0x00000200,

        /// <summary>
        /// JOB_OBJECT_LIMIT_JOB_MEMORY_LOW
        /// </summary>
        JOB_OBJECT_LIMIT_JOB_MEMORY_LOW = 0x00008000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_CPU_RATE_CONTROL
        /// </summary>
        JOB_OBJECT_LIMIT_CPU_RATE_CONTROL = 0x00040000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_IO_RATE_CONTROL
        /// </summary>
        JOB_OBJECT_LIMIT_IO_RATE_CONTROL = 0x00080000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_NET_RATE_CONTROL
        /// </summary>
        JOB_OBJECT_LIMIT_NET_RATE_CONTROL = 0x00100000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_READ_BYTES
        /// </summary>
        JOB_OBJECT_LIMIT_READ_BYTES = 0x00010000,

        /// <summary>
        /// JOB_OBJECT_LIMIT_WRITE_BYTES
        /// </summary>
        JOB_OBJECT_LIMIT_WRITE_BYTES = 0x00020000,
    }
}
