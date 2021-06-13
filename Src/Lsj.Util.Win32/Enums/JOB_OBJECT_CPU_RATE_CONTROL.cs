using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// JOB_OBJECT_CPU_RATE_CONTROL
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_cpu_rate_control_information"/>
    /// </para>
    /// </summary>
    public enum JOB_OBJECT_CPU_RATE_CONTROL : uint
    {
        /// <summary>
        /// This flag enables the job's CPU rate to be controlled based on weight or hard cap.
        /// You must set this value if you also set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/>,
        /// <see cref="JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP"/>, or <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>.
        /// </summary>
        JOB_OBJECT_CPU_RATE_CONTROL_ENABLE = 0x1,

        /// <summary>
        /// The job's CPU rate is calculated based on its relative weight to the weight of other jobs.
        /// If this flag is set, the Weight member contains more information.
        /// If this flag is clear, the <see cref="JOBOBJECT_CPU_RATE_CONTROL_INFORMATION.CpuRate"/> member contains more information.
        /// If you set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/>, you cannot also set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>.
        /// </summary>
        JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED = 0x2,

        /// <summary>
        /// The job's CPU rate is a hard limit.
        /// After the job reaches its CPU cycle limit for the current scheduling interval,
        /// no threads associated with the job will run until the next interval.
        /// If you set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP"/>, you cannot also set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>.
        /// </summary>
        JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP = 0x4,

        /// <summary>
        /// Sends messages when the CPU rate for the job exceeds the rate limits for the job during the tolerance interval.
        /// </summary>
        JOB_OBJECT_CPU_RATE_CONTROL_NOTIFY = 0x8,

        /// <summary>
        /// The CPU rate for the job is limited by minimum and maximum rates that you specify in the MinRate and MaxRate members.
        /// If you set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>,
        /// you can set neither <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/> nor <see cref="JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP"/>.
        /// </summary>
        JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE = 0x10,
    }
}
