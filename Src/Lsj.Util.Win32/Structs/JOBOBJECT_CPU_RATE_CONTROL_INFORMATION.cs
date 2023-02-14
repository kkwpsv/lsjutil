using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_CPU_RATE_CONTROL;
using static Lsj.Util.Win32.Enums.JOBOBJECTINFOCLASS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains CPU rate control information for a job object.
    /// This structure is used by the <see cref="SetInformationJobObject"/> and <see cref="QueryInformationJobObject"/> functions
    /// with the <see cref="JobObjectCpuRateControlInformation"/> information class.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-jobobject_cpu_rate_control_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// You can set CPU rate control for multiple jobs in a hierarchy of nested jobs.
    /// When you set CPU rate control for a job object, the settings apply to the job and its child jobs in the hierarchy.
    /// When you set CPU rate control for a job in a nested hierarchy, the system calculates the corresponding quotas
    /// with respect to the CPU rate control of the immediate parent job for the job.
    /// In other words, the rates set for the job represent its portion of the CPU rate that is allocated to its parent job.
    /// If a job object does not have a parent with CPU rate control turned on in the chain of its parent jobs,
    /// the rate control for the job represents the portion of the CPU for the entire system.
    /// CPU rate control cannot be used by job objects in applications running under Remote Desktop Services (formerly Terminal Services)
    /// if Dynamic Fair Share Scheduling (DFSS) is in effect.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_CPU_RATE_CONTROL_INFORMATION
    {
        /// <summary>
        /// The scheduling policy for CPU rate control. This member can be one of the following values.
        /// <see cref="JOB_OBJECT_CPU_RATE_CONTROL_ENABLE"/>, <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/>,
        /// <see cref="JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP"/>, <see cref="JOB_OBJECT_CPU_RATE_CONTROL_NOTIFY"/>,
        /// <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>
        /// </summary>
        [FieldOffset(0)]
        public JOB_OBJECT_CPU_RATE_CONTROL ControlFlags;

        /// <summary>
        /// Specifies the portion of processor cycles that the threads in a job object can use during each scheduling interval,
        /// as the number of cycles per 10,000 cycles.
        /// If the <see cref="ControlFlags"/> member specifies <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/>
        /// or <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>, this member is not used.
        /// Set <see cref="CpuRate"/> to a percentage times 100. For example, to let the job use 20% of the CPU, set CpuRate to 20 times 100, or 2,000.
        /// Do not set <see cref="CpuRate"/> to 0. If CpuRate is 0, SetInformationJobObject returns INVALID_ARGS.
        /// </summary>
        [FieldOffset(4)]
        public DWORD CpuRate;

        /// <summary>
        /// If the <see cref="ControlFlags"/> member specifies <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/>,
        /// this member specifies the scheduling weight of the job object, which determines the share of processor time
        /// given to the job relative to other workloads on the processor.
        /// This member can be a value from 1 through 9, where 1 is the smallest share and 9 is the largest share.
        /// The default is 5, which should be used for most workloads.
        /// If the <see cref="ControlFlags"/> member specifies <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>, this member is not used.
        /// </summary>
        [FieldOffset(4)]
        public DWORD Weight;

        /// <summary>
        /// Specifies the minimum portion of the processor cycles that the threads in a job object can reserve during each scheduling interval.
        /// Specify this rate as a percentage times 100. For example, to set a minimum rate of 50%, specify 50 times 100, or 5,000.
        /// For the minimum rates to work correctly, the sum of the minimum rates for all of the job objects in the system cannot exceed 10,000,
        /// which is the equivalent of 100%.
        /// </summary>
        [FieldOffset(4)]
        public WORD MinRate;

        /// <summary>
        /// Specifies the maximum portion of processor cycles that the threads in a job object can use during each scheduling interval.
        /// Specify this rate as a percentage times 100. For example, to set a maximum rate of 50%, specify 50 times 100, or 5,000.
        /// After the job reaches this limit for a scheduling interval, no threads associated with the job can run until the next scheduling interval.
        /// </summary>
        [FieldOffset(6)]
        public WORD MaxRate;
    }
}
