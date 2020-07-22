using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_LIMIT;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_MSG;
using static Lsj.Util.Win32.Enums.JOBOBJECT_RATE_CONTROL_TOLERANCE;
using static Lsj.Util.Win32.Enums.JOBOBJECTINFOCLASS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains extended information about resource notification limits that have been exceeded for a job object.
    /// This structure is used with the <see cref="QueryInformationJobObject"/> function
    /// with the <see cref="JobObjectLimitViolationInformation2"/> information class.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_limit_violation_information_2
    /// </para>
    /// </summary>
    /// <remarks>
    /// When any notification limit specified in a <see cref="JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2"/> structure is exceeded,
    /// the system sends a <see cref="JOB_OBJECT_MSG_NOTIFICATION_LIMIT"/> message to the I/O completion port associated with the job.
    /// To retrieve information about the limits that were exceeded, the application monitoring the I/O completion port
    /// must call the <see cref="QueryInformationJobObject"/> function with the <see cref="JobObjectLimitViolationInformation2"/> information class
    /// and a pointer to a <see cref="JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2
    {
        /// <summary>
        /// Flags that identify the notification limits in effect for the job.
        /// This member is a bitfield that determines whether other structure members are used.
        /// This member can be any combination of the following values.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY_HIGH"/>:
        /// The job has a committed memory notification limit. The <see cref="JobHighMemoryLimit"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY_LOW"/>:
        /// The job has a committed minimum memory notification limit. The <see cref="JobLowMemoryLimit"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_READ_BYTES"/>:
        /// The job has an I/O read bytes notification limit. The <see cref="IoReadBytesLimit"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_WRITE_BYTES"/>:
        /// The job has an I/O write bytes notification limit. The <see cref="IoWriteBytesLimit"/> member contains more information. 
        /// <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>:
        /// The job has a user-mode execution time notification limit. The <see cref="PerJobUserTimeLimit"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>:
        /// The job has notification limit for the extent to which a job can exceed its CPU rate control limit.
        /// The <see cref="RateControlToleranceLimit"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_CPU_RATE_CONTROL"/>:
        /// The job has notification limit for the extent to which a job can exceed its CPU rate control limit.
        /// The <see cref="CpuRateControlToleranceLimit"/> member contains more information. 
        /// <see cref="JOB_OBJECT_LIMIT_IO_RATE_CONTROL"/>:
        /// The job has notification limit for the extent to which a job can exceed its I/O rate control limit.
        /// The <see cref="IoRateControlToleranceLimit"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_NET_RATE_CONTROL"/>:
        /// The job has notification limit for the extent to which a job can exceed its network rate control limit.
        /// The <see cref="NetRateControlToleranceLimit"/> member contains more information. 
        /// </summary>
        [FieldOffset(0)]
        public JOB_OBJECT_LIMIT LimitFlags;

        /// <summary>
        /// Flags that identify the notification limits that have been exceeded.
        /// This member is a bitfield that determines whether other structure members are used.
        /// This member can be any combination of the following values.
        /// <see cref="JOB_OBJECT_LIMIT_READ_BYTES"/>:
        /// The job's I/O read bytes notification limit has been exceeded. The <see cref="IoReadBytes"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_WRITE_BYTES"/>:
        /// The job's I/O write bytes notification limit has been exceeded. The <see cref="IoWriteBytes"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>:
        /// The job's user-mode execution time notification limit has been exceeded. The <see cref="PerJobUserTime"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY_HIGH"/>:
        /// The job's committed maximum memory notification limit has been exceeded. The <see cref="JobMemory"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY_LOW"/>:
        /// The job's committed memory has fallen below its minimum notification limit. The <see cref="JobMemory"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>:
        /// The job's CPU rate control limit has been exceeded. The <see cref="RateControlTolerance"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_CPU_RATE_CONTROL"/>:
        /// The job's CPU rate control limit has been exceeded. The <see cref="CpuRateControlTolerance"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_IO_RATE_CONTROL"/>:
        /// The job's I/O rate control limit has been exceeded. The <see cref="IoRateControlTolerance"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_NET_RATE_CONTROL"/>:
        /// The job's network rate control limit has been exceeded. The <see cref="NetRateControlTolerance"/> member contains more information.
        /// </summary>
        [FieldOffset(4)]
        public JOB_OBJECT_LIMIT ViolationLimitFlags;

        /// <summary>
        /// If the <see cref="ViolationLimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_READ_BYTES"/>,
        /// this member contains the total I/O read bytes for all processes in the job at the time the notification was sent.
        /// </summary>
        [FieldOffset(8)]
        public DWORD64 IoReadBytes;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_READ_BYTES"/>,
        /// this member contains the I/O read bytes notification limit in effect for the job.
        /// </summary>
        [FieldOffset(16)]
        public DWORD64 IoReadBytesLimit;

        /// <summary>
        /// If the <see cref="ViolationLimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_WRITE_BYTES"/>,
        /// this member contains the total I/O write bytes for all processes in the job at the time the notification was sent.
        /// </summary>
        [FieldOffset(24)]
        public DWORD64 IoWriteBytes;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_WRITE_BYTES"/>,
        /// this member contains the I/O write bytes notification limit in effect for the job.
        /// </summary>
        [FieldOffset(32)]
        public DWORD64 IoWriteBytesLimit;

        /// <summary>
        /// If the <see cref="ViolationLimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>,
        /// this member contains the total user-mode execution time for all processes in the job at the time the notification was sent.
        /// </summary>
        [FieldOffset(40)]
        public LARGE_INTEGER PerJobUserTime;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>,
        /// this member contains the user-mode execution notification limit in effect for the job.
        /// </summary>
        [FieldOffset(48)]
        public LARGE_INTEGER PerJobUserTimeLimit;

        /// <summary>
        /// If the <see cref="ViolationLimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY_HIGH"/>
        /// or <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY_LOW"/>, this member contains the committed memory for all processes
        /// in the job at the time the notification was sent.
        /// </summary>
        [FieldOffset(56)]
        public DWORD64 JobMemory;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY_HIGH"/>,
        /// this member contains the committed maximum memory limit in effect for the job.
        /// </summary>
        [FieldOffset(64)]
        public DWORD64 JobHighMemoryLimit;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY"/>,
        /// this member contains the committed maximum memory limit in effect for the job.
        /// </summary>
        [FieldOffset(64)]
        public DWORD64 JobMemoryLimit;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>,
        /// this member specifies the extent to which the job exceeded its CPU rate control limits at the time the notification was sent.
        /// This member can be one of the following values.
        /// <see cref="ToleranceLow"/>: The job exceeded its CPU rate control limits for 20% of the tolerance interval.
        /// <see cref="ToleranceMedium"/>: The job exceeded its CPU rate control limits for 40% of the tolerance interval.
        /// <see cref="ToleranceHigh"/>: The job exceeded its CPU rate control limits for 60% of the tolerance interval. 
        /// </summary>
        [FieldOffset(72)]
        public JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlTolerance;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_CPU_RATE_CONTROL"/>,
        /// this member specifies the extent to which the job exceeded its CPU rate control limits at the time the notification was sent.
        /// This member can be one of the following values.
        /// <see cref="ToleranceLow"/>: The job exceeded its CPU rate control limits for 20% of the tolerance interval.
        /// <see cref="ToleranceMedium"/>: The job exceeded its CPU rate control limits for 40% of the tolerance interval.
        /// <see cref="ToleranceHigh"/>: The job exceeded its CPU rate control limits for 60% of the tolerance interval. 
        /// </summary>
        [FieldOffset(72)]
        public JOBOBJECT_RATE_CONTROL_TOLERANCE CpuRateControlTolerance;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>,
        /// this member contains the CPU rate control notification limits specified for the job.
        /// <see cref="ToleranceLow"/>: The job exceeded its CPU rate control limits for 20% of the tolerance interval.
        /// <see cref="ToleranceMedium"/>: The job exceeded its CPU rate control limits for 40% of the tolerance interval.
        /// <see cref="ToleranceHigh"/>: The job exceeded its CPU rate control limits for 60% of the tolerance interval. 
        /// </summary>
        [FieldOffset(76)]
        public JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlToleranceLimit;

        /// <summary>
        /// If the <see cref="LimitFlags"/> parameter specifies <see cref="JOB_OBJECT_LIMIT_CPU_RATE_CONTROL"/>,
        /// this member contains the CPU rate control notification limits specified for the job.
        /// <see cref="ToleranceLow"/>: The job exceeded its CPU rate control limits for 20% of the tolerance interval.
        /// <see cref="ToleranceMedium"/>: The job exceeded its CPU rate control limits for 40% of the tolerance interval.
        /// <see cref="ToleranceHigh"/>: The job exceeded its CPU rate control limits for 60% of the tolerance interval. 
        /// </summary>
        [FieldOffset(76)]
        public JOBOBJECT_RATE_CONTROL_TOLERANCE CpuRateControlToleranceLimit;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY_LOW"/>,
        /// this member contains the committed minimum memory limit in effect for the job.
        /// </summary>
        [FieldOffset(80)]
        public DWORD64 JobLowMemoryLimit;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_IO_RATE_CONTROL"/>,
        /// this member specifies the extent to which the job exceeded its I/O rate control limits at the time the notification was sent.
        /// This member can be one of the following values.
        /// <see cref="ToleranceLow"/>: The job exceeded its CPU rate control limits for 20% of the tolerance interval.
        /// <see cref="ToleranceMedium"/>: The job exceeded its CPU rate control limits for 40% of the tolerance interval.
        /// <see cref="ToleranceHigh"/>: The job exceeded its CPU rate control limits for 60% of the tolerance interval. 
        /// </summary>
        [FieldOffset(88)]
        public JOBOBJECT_RATE_CONTROL_TOLERANCE IoRateControlTolerance;

        /// <summary>
        /// If the <see cref="LimitFlags"/> parameter specifies <see cref="JOB_OBJECT_LIMIT_IO_RATE_CONTROL"/>,
        /// this member contains the I/O rate control notification limits specified for the job.
        /// <see cref="ToleranceLow"/>: The job exceeded its CPU rate control limits for 20% of the tolerance interval.
        /// <see cref="ToleranceMedium"/>: The job exceeded its CPU rate control limits for 40% of the tolerance interval.
        /// <see cref="ToleranceHigh"/>: The job exceeded its CPU rate control limits for 60% of the tolerance interval.
        /// </summary>
        [FieldOffset(92)]
        public JOBOBJECT_RATE_CONTROL_TOLERANCE IoRateControlToleranceLimit;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_NET_RATE_CONTROL"/>,
        /// this member specifies the extent to which the job exceeded its network rate control limits at the time the notification was sent.
        /// This member can be one of the following values.
        /// <see cref="ToleranceLow"/>: The job exceeded its CPU rate control limits for 20% of the tolerance interval.
        /// <see cref="ToleranceMedium"/>: The job exceeded its CPU rate control limits for 40% of the tolerance interval.
        /// <see cref="ToleranceHigh"/>: The job exceeded its CPU rate control limits for 60% of the tolerance interval.
        /// </summary>
        [FieldOffset(96)]
        public JOBOBJECT_RATE_CONTROL_TOLERANCE NetRateControlTolerance;

        /// <summary>
        /// If the <see cref="LimitFlags"/> parameter specifies <see cref="JOB_OBJECT_LIMIT_NET_RATE_CONTROL"/>,
        /// this member contains the network rate control notification limits specified for the job.
        /// <see cref="ToleranceLow"/>: The job exceeded its CPU rate control limits for 20% of the tolerance interval.
        /// <see cref="ToleranceMedium"/>: The job exceeded its CPU rate control limits for 40% of the tolerance interval.
        /// <see cref="ToleranceHigh"/>: The job exceeded its CPU rate control limits for 60% of the tolerance interval.
        /// </summary>
        [FieldOffset(100)]
        public JOBOBJECT_RATE_CONTROL_TOLERANCE NetRateControlToleranceLimit;
    }
}
