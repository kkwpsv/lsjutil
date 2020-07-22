using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_LIMIT;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_MSG;
using static Lsj.Util.Win32.Enums.JOBOBJECT_RATE_CONTROL_TOLERANCE;
using static Lsj.Util.Win32.Enums.JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL;
using static Lsj.Util.Win32.Enums.JOBOBJECTINFOCLASS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about notification limits for a job object.
    /// This structure is used by the <see cref="SetInformationJobObject"/> and <see cref="QueryInformationJobObject"/> functions
    /// with the <see cref="JobObjectNotificationLimitInformation"/> information class.
    /// </para>
    /// </summary>
    /// <remarks>
    /// When a notification limit is exceeded, the system sends a <see cref="JOB_OBJECT_MSG_NOTIFICATION_LIMIT"/> message
    /// to the I/O completion port associated with the job.
    /// Processes in the job continue to run and can continue to allocate memory or transmit read or write bytes beyond the specified limits.
    /// When the application monitoring the I/O completion port receives a <see cref="JOB_OBJECT_MSG_NOTIFICATION_LIMIT"/> message,
    /// it must call <see cref="QueryInformationJobObject"/> with the <see cref="JobObjectLimitViolationInformation"/> information class.
    /// Limit violation information is received in a <see cref="JOBOBJECT_LIMIT_VIOLATION_INFORMATION"/> that contains information
    /// about all notification limits that were exceeded at the time of the query.
    /// The system will not send another <see cref="JOB_OBJECT_MSG_NOTIFICATION_LIMIT"/> message
    /// until after <see cref="QueryInformationJobObject"/> is called.
    /// CPU rate control limits for a job are established in a <see cref="JOBOBJECT_CPU_RATE_CONTROL_INFORMATION"/> structure.
    /// The CPU rate control values in the <see cref="JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION"/> structure specify
    /// how much the job can exceed its established CPU rate control limits before notification is sent.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION
    {
        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_READ_BYTES"/>,
        /// this member is the notification limit for total I/O bytes read by all processes in the job.
        /// Otherwise, this member is ignored.
        /// </summary>
        public DWORD64 IoReadBytesLimit;

        /// <summary>
        /// If the <see cref="LimitFlags"/> parameter specifies <see cref="JOB_OBJECT_LIMIT_JOB_WRITE_BYTES"/>,
        /// this member is the notification limit for total I/O bytes written by all processes in the job.
        /// Otherwise, this member is ignored.
        /// </summary>
        public DWORD64 IoWriteBytesLimit;

        /// <summary>
        /// If the <see cref="LimitFlags"/> parameter specifies <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>,
        /// this member is the notification limit for per-job user-mode execution time, in 100-nanosecond ticks.
        /// Otherwise, this member is ignored.
        /// The system adds the accumulated execution time of processes associated with the job to this limit when the limit is set.
        /// For example, if a process associated with the job has already accumulated 5 minutes of user-mode execution time
        /// and the limit is set to 1 minute, the limit actually enforced is 6 minutes.
        /// To specify MSe  PerJobUserTimeLimit as an enforceable limit and terminate processes in jobs that exceed the limit,
        /// see the <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </summary>
        public LARGE_INTEGER PerJobUserTimeLimit;

        /// <summary>
        /// If the LimitFlags parameter specifies <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY"/>,
        /// this member is the notification limit for total virtual memory that can be committed by all processes in the job, in bytes.
        /// Otherwise, this member is ignored.
        /// To specify <see cref="JobMemoryLimit"/> as an enforceable limit and prevent processes in jobs
        /// that exceed the limit from continuing to commit memory, see the <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// </summary>
        public DWORD64 JobMemoryLimit;

        /// <summary>
        /// If the <see cref="LimitFlags"/> parameter specifies <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>,
        /// this member specifies the extent to which a job can exceed its CPU rate control limits
        /// during the interval specified by the <see cref="RateControlToleranceInterval"/> member.
        /// Otherwise, this member is ignored.
        /// This member can be one of the following values. If no value is specified, <see cref="ToleranceHigh"/> is used.
        /// <see cref="ToleranceLow"/>: The job can exceed its CPU rate control limits for 20% of the tolerance interval.
        /// <see cref="ToleranceMedium"/>: The job can exceed its CPU rate control limits for 40% of the tolerance interval.
        /// <see cref="ToleranceHigh"/>: The job can exceed its CPU rate control limits for 60% of the tolerance interval.
        /// </summary>
        public JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlTolerance;

        /// <summary>
        /// If the <see cref="LimitFlags"/> parameter specifies <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>,
        /// this member specifies the interval during which a job's CPU usage is monitored
        /// to determine whether the job has exceeded its CPU rate control limits.
        /// Otherwise, this member is ignored.
        /// This member can be one of the following values.If no value is specified, <see cref="ToleranceIntervalShort"/> is used.
        /// <see cref="ToleranceIntervalShort"/>: The tolerance interval is 10 seconds.
        /// <see cref="ToleranceIntervalMedium"/>: The tolerance interval is one minute.
        /// <see cref="ToleranceIntervalLong"/>: The tolerance interval is 10 minutes.
        /// </summary>
        public JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL RateControlToleranceInterval;

        /// <summary>
        /// The limit flags that are in effect. This member is a bitfield that determines whether other structure members are used.
        /// Any combination of the following values can be specified.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY"/>:
        /// Establishes the committed memory limit to the job-wide sum of committed memory for all processes associated with the job.
        /// The <see cref="JobMemoryLimit"/> member contains additional information.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_READ_BYTES"/>:
        /// Establishes the I/O read bytes limit to the job-wide sum of I/O bytes read by all processes associated with the job.
        /// The <see cref="IoReadBytesLimit"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_WRITE_BYTES"/>:
        /// Establishes the I/O write bytes limit to the job-wide sum of I/O bytes written by all processes associated with the job.
        /// The <see cref="IoWriteBytesLimit"/> member contains more information.
        /// <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>:
        /// Establishes the limit for user-mode execution time for the job.
        /// The <see cref="PerJobUserTimeLimit"/> member contains additional information.
        /// <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>:
        /// Establishes the notification threshold for the CPU rate control limits established for the job.
        /// The <see cref="RateControlTolerance"/> and <see cref="RateControlToleranceInterval"/> members contain additional information.
        /// CPU rate control limits are established by calling <see cref="SetInformationJobObject"/>
        /// with the <see cref="JobObjectCpuRateControlInformation"/> information class.
        /// </summary>
        public JOB_OBJECT_LIMIT LimitFlags;
    }
}
