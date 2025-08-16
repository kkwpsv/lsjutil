using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Job object cpu rate control scheduling policies
    /// </summary>
    public enum JobObjectCpuRateControlSchedulingPolicies : uint
    {
        /// <summary>
        /// JOB_OBJECT_CPU_RATE_CONTROL_ENABLE
        /// </summary>
        JOB_OBJECT_CPU_RATE_CONTROL_ENABLE = 0x1,

        /// <summary>
        /// JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED
        /// </summary>
        JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED = 0x2,

        /// <summary>
        /// JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP
        /// </summary>
        JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP = 0x4,

        /// <summary>
        /// JOB_OBJECT_CPU_RATE_CONTROL_NOTIFY
        /// </summary>
        JOB_OBJECT_CPU_RATE_CONTROL_NOTIFY = 0x8,

        /// <summary>
        /// JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE
        /// </summary>
        JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE = 0x10,
    }
}
