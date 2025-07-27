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
    /// Contains information about resource notification limits that have been exceeded for a job object.
    /// This structure is used with the <see cref="QueryInformationJobObject"/> function
    /// with the <see cref="JobObjectLimitViolationInformation"/> information class.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-jobobject_limit_violation_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When any notification limit specified in a <see cref="JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION"/> structure is exceeded,
    /// the system sends a <see cref="JOB_OBJECT_MSG_NOTIFICATION_LIMIT"/> message to the I/O completion port associated with the job.
    /// </para>
    /// <para>
    /// To retrieve information about the limits that were exceeded,
    /// the application monitoring the I/O completion port must call the <see cref="QueryInformationJobObject"/> function
    /// with the <see cref="JobObjectLimitViolationInformation"/> information class
    /// and a pointer to a <see cref="JOBOBJECT_LIMIT_VIOLATION_INFORMATION"/> structure.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_LIMIT_VIOLATION_INFORMATION
    {
        /// <summary>
        /// <para>
        /// Flags that identify the notification limits in effect for the job.
        /// This member is a bitfield that determines whether other structure members are used.
        /// This member can be any combination of the following values.
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
        /// <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// The job has a committed memory notification limit.
        /// The <see cref="JobMemoryLimit"/> member contains more information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_JOB_READ_BYTES"/>
        /// </para>
        /// <para>
        /// 0x00010000
        /// </para>
        /// </term>
        /// <term>
        /// The job has an I/O read bytes notification limit.
        /// The <see cref="IoReadBytesLimit"/> member contains more information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// The job has a user-mode execution time notification limit.
        /// The <see cref="PerJobUserTimeLimit"/> member contains more information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_JOB_WRITE_BYTES"/>
        /// </para>
        /// <para>
        /// 0x00020000
        /// </para>
        /// </term>
        /// <term>
        /// The job has an I/O write bytes notification limit.
        /// The <see cref="IoWriteBytesLimit"/> member contains more information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x00040000
        /// </para>
        /// </term>
        /// <term>
        /// The extent to which a job can exceed its CPU rate control limit.
        /// The <see cref="RateControlToleranceLimit"/> member contains more information.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public JOB_OBJECT_LIMIT LimitFlags;

        /// <summary>
        /// <para>
        /// Flags that identify the notification limits that have been exceeded.
        /// This member is a bitfield that determines whether other structure members are used.
        /// This member can be any combination of the following values.
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
        /// <see cref="JOB_OBJECT_LIMIT_READ_BYTES"/>
        /// </para>
        /// <para>
        /// 0x00010000
        /// </para>
        /// </term>
        /// <term>
        /// The job's I/O read bytes notification limit has been exceeded.
        /// The <see cref="IoReadBytes"/> member contains more information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_WRITE_BYTES"/>
        /// </para>
        /// <para>
        /// 0x00020000
        /// </para>
        /// </term>
        /// <term>
        /// The job's I/O write bytes notification limit has been exceeded.
        /// The <see cref="IoWriteBytes"/> member contains more information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// The job's user-mode execution time notification limit has been exceeded.
        /// The <see cref="PerJobUserTime"/> member contains more information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// The job's committed memory notification limit has been exceeded.
        /// The <see cref="JobMemory"/> member contains more information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x00040000
        /// </para>
        /// </term>
        /// <term>
        /// The job's CPU rate control limit has been exceeded.
        /// The <see cref="RateControlTolerance"/> member contains more information.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public JOB_OBJECT_LIMIT ViolationLimitFlags;

        /// <summary>
        /// If the <see cref="ViolationLimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_READ_BYTES"/>,
        /// this member contains the total I/O read bytes for all processes in the job at the time the notification was sent.
        /// </summary>
        public DWORD64 IoReadBytes;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_READ_BYTES"/>,
        /// this member contains the I/O read bytes notification limit in effect for the job.
        /// </summary>
        public DWORD64 IoReadBytesLimit;

        /// <summary>
        /// If the <see cref="ViolationLimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_WRITE_BYTES"/>,
        /// this member contains the total I/O write bytes for all processes in the job at the time the notification was sent.
        /// </summary>
        public DWORD64 IoWriteBytes;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_WRITE_BYTES"/>,
        /// this member contains the I/O write bytes notification limit in effect for the job.
        /// </summary>
        public DWORD64 IoWriteBytesLimit;

        /// <summary>
        /// If the <see cref="ViolationLimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>,
        /// this member contains the total user-mode execution time for all processes in the job at the time the notification was sent.
        /// </summary>
        public LARGE_INTEGER PerJobUserTime;

        /// <summary>
        /// If the <see cref="LimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>,
        /// this member contains the user-mode execution notification limit in effect for the job.
        /// </summary>
        public LARGE_INTEGER PerJobUserTimeLimit;

        /// <summary>
        /// If the <see cref="ViolationLimitFlags"/> member specifies <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY"/>,
        /// this member contains the committed memory for all processes in the job at the time the notification was sent.
        /// </summary>
        public DWORD64 JobMemory;

        /// <summary>
        /// If the LimitFlags member specifies <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY"/>,
        /// this member contains the committed memory limit in effect for the job.
        /// </summary>
        public DWORD64 JobMemoryLimit;

        /// <summary>
        /// <para>
        /// If the <see cref="LimitFlags"/> parameter specifies <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>,
        /// this member specifies the extent to which the job exceeded its CPU rate control limits at the time the notification was sent.
        /// This member can be one of the following values.
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
        /// <see cref="ToleranceLow"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The job exceeded its CPU rate control limits for 20% of the tolerance interval.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ToleranceMedium"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The job exceeded its CPU rate control limits for 40% of the tolerance interval.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ToleranceHigh"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The job exceeded its CPU rate control limits for 60% of the tolerance interval.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlTolerance;

        /// <summary>
        /// <para>
        /// If the <see cref="LimitFlags"/> parameter specifies <see cref="JOB_OBJECT_LIMIT_RATE_CONTROL"/>,
        /// this member contains the CPU rate control notification limits specified for the job.
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
        /// <see cref="ToleranceIntervalShort"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The tolerance interval is 10 seconds.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ToleranceIntervalMedium"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The tolerance interval is one minute.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ToleranceIntervalLong"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The tolerance interval is 10 minutes.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL RateControlToleranceLimit;
    }
}
