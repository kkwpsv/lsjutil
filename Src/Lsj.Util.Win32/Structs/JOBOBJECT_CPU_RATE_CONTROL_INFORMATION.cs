using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.JobObjectCpuRateControlSchedulingPolicies;
using static Lsj.Util.Win32.Enums.JobObjectInformationClasses;
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
    /// <para>
    /// You can set CPU rate control for multiple jobs in a hierarchy of nested jobs.
    /// When you set CPU rate control for a job object, the settings apply to the job and its child jobs in the hierarchy.
    /// When you set CPU rate control for a job in a nested hierarchy, the system calculates the corresponding quotas
    /// with respect to the CPU rate control of the immediate parent job for the job.
    /// In other words, the rates set for the job represent its portion of the CPU rate that is allocated to its parent job.
    /// If a job object does not have a parent with CPU rate control turned on in the chain of its parent jobs,
    /// the rate control for the job represents the portion of the CPU for the entire system.
    /// </para>
    /// <para>
    /// CPU rate control cannot be used by job objects in applications running under Remote Desktop Services (formerly Terminal Services)
    /// if Dynamic Fair Share Scheduling (DFSS) is in effect.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_CPU_RATE_CONTROL_INFORMATION
    {
        /// <summary>
        /// <para>
        /// The scheduling policy for CPU rate control. This member can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_CPU_RATE_CONTROL_ENABLE"/>
        /// </para>
        /// <para>
        /// 0x1
        /// </para>
        /// </term>
        /// <term>
        /// This flag enables the job's CPU rate to be controlled based on weight or hard cap.
        /// You must set this value if you also set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/>,
        /// <see cref="JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP"/>, or <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/>
        /// </para>
        /// <para>
        /// 0x2
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The job's CPU rate is calculated based on its relative weight to the weight of other jobs.
        /// If this flag is set, the <see cref="Weight"/> member contains more information.
        /// If this flag is clear, the <see cref="CpuRate"/> member contains more information.
        /// </para>
        /// <para>
        /// If you set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/>, you cannot also set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP"/>
        /// </para>
        /// <para>
        /// 0x4
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The job's CPU rate is a hard limit.
        /// After the job reaches its CPU cycle limit for the current scheduling interval,
        /// no threads associated with the job will run until the next interval.
        /// </para>
        /// <para>
        /// If you set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP"/>,
        /// you cannot also set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_CPU_RATE_CONTROL_NOTIFY"/>
        /// </para>
        /// <para>
        /// 0x8
        /// </para>
        /// </term>
        /// <term>
        /// Sends messages when the CPU rate for the job exceeds the rate limits for the job during the tolerance interval.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>
        /// </para>
        /// <para>
        /// 0x10
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The CPU rate for the job is limited by minimum and maximum rates that you specify in the <see cref="MinRate"/> and <see cref="MaxRate"/> members.
        /// </para>
        /// <para>
        /// If you set <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>,
        /// you can set neither <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/> nor <see cref="JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP"/>.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        [FieldOffset(0)]
        public JobObjectCpuRateControlSchedulingPolicies ControlFlags;

        /// <summary>
        /// <para>
        /// Specifies the portion of processor cycles that the threads in a job object can use during each scheduling interval,
        /// as the number of cycles per 10,000 cycles. If the <see cref="ControlFlags"/> member
        /// specifies <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/> or <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>, this member is not used.
        /// </para>
        /// <para>
        /// Set <see cref="CpuRate"/> to a percentage times 100.
        /// For example, to let the job use 20% of the CPU, set <see cref="CpuRate"/> to 20 times 100, or 2,000.
        /// </para>
        /// <para>
        /// Do not set <see cref="CpuRate"/> to 0.
        /// If <see cref="CpuRate"/> is 0, <see cref="SetInformationJobObject"/> returns INVALID_ARGS.
        /// </para>
        /// </summary>
        [FieldOffset(4)]
        public DWORD CpuRate;

        /// <summary>
        /// <para>
        /// If the <see cref="ControlFlags"/> member specifies <see cref="JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED"/>,
        /// this member specifies the scheduling weight of the job object,
        /// which determines the share of processor time given to the job relative to other workloads on the processor.
        /// </para>
        /// <para>
        /// This member can be a value from 1 through 9, where 1 is the smallest share and 9 is the largest share.
        /// The default is 5, which should be used for most workloads.
        /// </para>
        /// <para>
        /// If the <see cref="ControlFlags"/> member specifies <see cref="JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE"/>, this member is not used.
        /// </para>
        /// </summary>
        [FieldOffset(4)]
        public DWORD Weight;

        /// <summary>
        /// <para>
        /// Specifies the minimum portion of the processor cycles that the threads in a job object can reserve during each scheduling interval.
        /// Specify this rate as a percentage times 100.
        /// For example, to set a minimum rate of 50%, specify 50 times 100, or 5,000.
        /// </para>
        /// <para>
        /// For the minimum rates to work correctly, the sum of the minimum rates for all of the job objects
        /// in the system cannot exceed 10,000, which is the equivalent of 100%.
        /// </para>
        /// </summary>
        [FieldOffset(4)]
        public WORD MinRate;

        /// <summary>
        /// <para>
        /// Specifies the maximum portion of processor cycles that the threads in a job object can use during each scheduling interval.
        /// Specify this rate as a percentage times 100.
        /// For example, to set a maximum rate of 50%, specify 50 times 100, or 5,000.
        /// </para>
        /// <para>
        /// After the job reaches this limit for a scheduling interval,
        /// no threads associated with the job can run until the next scheduling interval.
        /// </para>
        /// </summary>
        [FieldOffset(6)]
        public WORD MaxRate;
    }
}
