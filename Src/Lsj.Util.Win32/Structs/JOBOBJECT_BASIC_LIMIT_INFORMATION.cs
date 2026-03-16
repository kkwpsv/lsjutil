using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ErrorModes;
using static Lsj.Util.Win32.Enums.JobObjectInformationClasses;
using static Lsj.Util.Win32.Enums.JobObjectLimitFlags;
using static Lsj.Util.Win32.Enums.JobObjectMessageIdentifiers;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains basic limit information for a job object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-jobobject_basic_limit_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Processes can still empty their working sets using the <see cref="SetProcessWorkingSetSize"/> function with (<see cref="SIZE_T"/>)-1,
    /// even when <see cref="JOB_OBJECT_LIMIT_WORKINGSET"/> is used.
    /// However, you cannot use <see cref="SetProcessWorkingSetSize"/> change the minimum or maximum working set size of a process in a job object.
    /// </para>
    /// <para>
    /// The system increments the active process count when you attempt to associate a process with a job.
    /// If the limit is exceeded, the system decrements the active process count only when the process terminates and all handles to the process are closed.
    /// Therefore, if you have an open handle to a process that has been terminated in such a manner,
    /// you cannot associate any new processes until the handle is closed and the active process count is below the limit.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_BASIC_LIMIT_INFORMATION
    {
        /// <summary>
        /// <para>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_PROCESS_TIME"/>,
        /// this member is the per-process user-mode execution time limit, in 100-nanosecond ticks.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// The system periodically checks to determine whether each process associated with the job has accumulated more user-mode time than the set limit.
        /// If it has, the process is terminated.
        /// </para>
        /// <para>
        /// If the job is nested, the effective limit is the most restrictive limit in the job chain.
        /// </para>
        /// </summary>
        public LARGE_INTEGER PerProcessUserTimeLimit;

        /// <summary>
        /// <para>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>,
        /// this member is the per-job user-mode execution time limit, in 100-nanosecond ticks.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// The system adds the current time of the processes associated with the job to this limit.
        /// For example, if you set this limit to 1 minute, and the job has a process that has accumulated 5 minutes of user-mode time,
        /// the limit actually enforced is 6 minutes.
        /// </para>
        /// <para>
        /// The system periodically checks to determine whether the sum of the user-mode execution time for all processes is greater than this end-of-job limit.
        /// If it is, the action specified in the <see cref="JOBOBJECT_END_OF_JOB_TIME_INFORMATION.EndOfJobTimeAction"/> member
        /// of the <see cref="JOBOBJECT_END_OF_JOB_TIME_INFORMATION"/> structure is carried out.
        /// By default, all processes are terminated and the status code is set to <see cref="ERROR_NOT_ENOUGH_QUOTA"/>.
        /// </para>
        /// <para>
        /// To register for notification when this limit is exceeded without terminating processes,
        /// use the <see cref="SetInformationJobObject"/> function with the <see cref="JobObjectNotificationLimitInformation"/> information class.
        /// </para>
        /// </summary>
        public LARGE_INTEGER PerJobUserTimeLimit;

        /// <summary>
        /// <para>
        /// The limit flags that are in effect.
        /// This member is a bitfield that determines whether other structure members are used.
        /// Any combination of the following values can be specified.
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
        /// <see cref="JOB_OBJECT_LIMIT_ACTIVE_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Establishes a maximum number of simultaneously active processes associated with the job.
        /// The <see cref="ActiveProcessLimit"/> member contains additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_AFFINITY"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Causes all processes associated with the job to use the same processor affinity.
        /// The <see cref="Affinity"/> member contains additional information.
        /// </para>
        /// <para>
        /// If the job is nested, the specified processor affinity must be a subset of the effective affinity of the parent job.
        /// If the specified affinity a superset of the affinity of the parent job, it is ignored and the affinity of the parent job is used.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_BREAKAWAY_OK"/>
        /// </para>
        /// <para>
        /// 0x00000800
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// If any process associated with the job creates a child process using the <see cref="CREATE_BREAKAWAY_FROM_JOB"/> flag
        /// while this limit is in effect, the child process is not associated with the job.
        /// </para>
        /// <para>
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Forces a call to the <see cref="SetErrorMode"/> function with the <see cref="SEM_NOGPFAULTERRORBOX"/> flag for each process associated with the job.
        /// </para>
        /// <para>
        /// If an exception occurs and the system calls the <see cref="UnhandledExceptionFilter"/> function, the debugger will be given a chance to act.
        /// If there is no debugger, the functions returns <see cref="EXCEPTION_EXECUTE_HANDLER"/>.
        /// Normally, this will cause termination of the process with the exception code as the exit status.
        /// </para>
        /// <para>
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </para>
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
        /// <para>
        /// Causes all processes associated with the job to limit the job-wide sum of their committed memory.
        /// When a process attempts to commit memory that would exceed the job-wide limit, it fails.
        /// If the job object is associated with a completion port, a <see cref="JOB_OBJECT_MSG_JOB_MEMORY_LIMIT"/> message is sent to the completion port.
        /// </para>
        /// <para>
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// To register for notification when this limit is exceeded while allowing processes to continue to commit memory,
        /// use the <see cref="SetInformationJobObject"/> function with the <see cref="JobObjectNotificationLimitInformation"/> information class.
        /// </para>
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
        /// Establishes a user-mode execution time limit for the job. The <see cref="PerJobUserTimeLimit"/> member contains additional information.
        /// This flag cannot be used with <see cref="JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Causes all processes associated with the job to terminate when the last handle to the job is closed.
        /// </para>
        /// <para>
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Preserves any job time limits you previously set.
        /// As long as this flag is set, you can establish a per-job time limit once, then alter other limits in subsequent calls.
        /// This flag cannot be used with <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_PRIORITY_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Causes all processes associated with the job to use the same priority class.
        /// For more information, see Scheduling Priorities. The <see cref="PriorityClass"/> member contains additional information.
        /// </para>
        /// <para>
        /// If the job is nested, the effective priority class is the lowest priority class in the job chain.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_PROCESS_MEMORY"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Causes all processes associated with the job to limit their committed memory.
        /// When a process attempts to commit memory that would exceed the per-process limit, it fails.
        /// If the job object is associated with a completion port, a <see cref="JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT"/> message is sent to the completion port.
        /// </para>
        /// <para>
        /// If the job is nested, the effective memory limit is the most restrictive memory limit in the job chain.
        /// </para>
        /// <para>
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_PROCESS_TIME"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Establishes a user-mode execution time limit for each currently active process and for all future processes associated with the job.
        /// The <see cref="PerProcessUserTimeLimit"/> member contains additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_SCHEDULING_CLASS"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Causes all processes in the job to use the same scheduling class. The <see cref="SchedulingClass"/> member contains additional information.
        /// </para>
        /// <para>
        /// If the job is nested, the effective scheduling class is the lowest scheduling class in the job chain.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK"/>
        /// </para>
        /// <para>
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Allows any process associated with the job to create child processes that are not associated with the job.
        /// </para>
        /// <para>
        /// If the job is nested and its immediate job object allows breakaway,
        /// the child process breaks away from the immediate job object and from each job in the parent job chain,
        /// moving up the hierarchy until it reaches a job that does not permit breakaway.
        /// If the immediate job object does not allow breakaway, the child process does not break away even if jobs in its parent job chain allow it.
        /// </para>
        /// <para>
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_SUBSET_AFFINITY"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Allows processes to use a subset of the processor affinity for all processes associated with the job.
        /// This value must be combined with <see cref="JOB_OBJECT_LIMIT_AFFINITY"/>.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This flag is supported starting with Windows 7 and Windows Server 2008 R2.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_LIMIT_WORKINGSET"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Causes all processes associated with the job to use the same minimum and maximum working set sizes.
        /// The <see cref="MinimumWorkingSetSize"/> and <see cref="MaximumWorkingSetSize"/> members contain additional information.
        /// </para>
        /// <para>
        /// If the job is nested, the effective working set size is the smallest working set size in the job chain.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public JobObjectLimitFlags LimitFlags;

        /// <summary>
        /// <para>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_WORKINGSET"/>,
        /// this member is the minimum working set size in bytes for each process associated with the job.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// If <see cref="MaximumWorkingSetSize"/> is nonzero, <see cref="MinimumWorkingSetSize"/> cannot be zero.
        /// </para>
        /// </summary>
        public SIZE_T MinimumWorkingSetSize;

        /// <summary>
        /// <para>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_WORKINGSET"/>,
        /// this member is the maximum working set size in bytes for each process associated with the job.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// If <see cref="MinimumWorkingSetSize"/> is nonzero, <see cref="MaximumWorkingSetSize"/> cannot be zero.
        /// </para>
        /// </summary>
        public SIZE_T MaximumWorkingSetSize;

        /// <summary>
        /// <para>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_ACTIVE_PROCESS"/>,
        /// this member is the active process limit for the job.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// If you try to associate a process with a job, and this causes the active process count to exceed this limit,
        /// the process is terminated and the association fails.
        /// </para>
        /// </summary>
        public DWORD ActiveProcessLimit;

        /// <summary>
        /// <para>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_AFFINITY"/>,
        /// this member is the processor affinity for all processes associated with the job.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// The affinity must be a subset of the system affinity mask obtained by calling the <see cref="GetProcessAffinityMask"/> function.
        /// The affinity of each thread is set to this value, but threads are free to subsequently set their affinity,
        /// as long as it is a subset of the specified affinity mask.
        /// Processes cannot set their own affinity mask.
        /// </para>
        /// </summary>
        public ULONG_PTR Affinity;

        /// <summary>
        /// <para>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_PRIORITY_CLASS"/>,
        /// this member is the priority class for all processes associated with the job.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// Processes and threads cannot modify their priority class.
        /// The calling process must enable the <see cref="SE_INC_BASE_PRIORITY_NAME"/> privilege.
        /// </para>
        /// </summary>
        public ProcessPriorityClasses PriorityClass;

        /// <summary>
        /// <para>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_SCHEDULING_CLASS"/>,
        /// this member is the scheduling class for all processes associated with the job.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// The valid values are 0 to 9.
        /// Use 0 for the least favorable scheduling class relative to other threads,
        /// and 9 for the most favorable scheduling class relative to other threads.
        /// By default, this value is 5. To use a scheduling class greater than 5,
        /// the calling process must enable the <see cref="SE_INC_BASE_PRIORITY_NAME"/> privilege.
        /// </para>
        /// </summary>
        public DWORD SchedulingClass;
    }
}
