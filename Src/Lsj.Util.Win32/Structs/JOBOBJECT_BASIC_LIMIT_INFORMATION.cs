using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_LIMIT;
using static Lsj.Util.Win32.Enums.JOBOBJECTINFOCLASS;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains basic limit information for a job object.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_basic_limit_information
    /// </para>
    /// </summary>
    /// <remarks>
    /// Processes can still empty their working sets using the <see cref="SetProcessWorkingSetSize"/> function with (SIZE_T)-1,
    /// even when <see cref="JOB_OBJECT_LIMIT_WORKINGSET"/> is used.
    /// However, you cannot use <see cref="SetProcessWorkingSetSize"/> change the minimum or maximum working set size of a process in a job object.
    /// The system increments the active process count when you attempt to associate a process with a job.
    /// If the limit is exceeded, the system decrements the active process count only when the process terminates and all handles to the process are closed.
    /// Therefore, if you have an open handle to a process that has been terminated in such a manner,
    /// you cannot associate any new processes until the handle is closed and the active process count is below the limit.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_BASIC_LIMIT_INFORMATION
    {
        /// <summary>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_PROCESS_TIME"/>,
        /// this member is the per-process user-mode execution time limit, in 100-nanosecond ticks.
        /// Otherwise, this member is ignored.
        /// The system periodically checks to determine whether each process associated with the job has accumulated more user-mode time than the set limit.
        /// If it has, the process is terminated.
        /// If the job is nested, the effective limit is the most restrictive limit in the job chain.
        /// </summary>
        public LARGE_INTEGER PerProcessUserTimeLimit;

        /// <summary>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>, this member is the per-job user-mode execution time limit,
        /// in 100-nanosecond ticks. Otherwise, this member is ignored.
        /// The system adds the current time of the processes associated with the job to this limit.
        /// For example, if you set this limit to 1 minute, and the job has a process that has accumulated 5 minutes of user-mode time,
        /// the limit actually enforced is 6 minutes.
        /// The system periodically checks to determine whether the sum of the user-mode execution time
        /// for all processes is greater than this end-of-job limit.
        /// If it is, the action specified in the <see cref="JOBOBJECT_END_OF_JOB_TIME_INFORMATION.EndOfJobTimeAction"/> member
        /// of the <see cref="JOBOBJECT_END_OF_JOB_TIME_INFORMATION"/> structure is carried out.
        /// By default, all processes are terminated and the status code is set to <see cref="ERROR_NOT_ENOUGH_QUOTA"/>.
        /// To register for notification when this limit is exceeded without terminating processes,
        /// use the <see cref="SetInformationJobObject"/> function with the <see cref="JobObjectNotificationLimitInformation"/> information class.
        /// </summary>
        public LARGE_INTEGER PerJobUserTimeLimit;

        /// <summary>
        /// The limit flags that are in effect.
        /// This member is a bitfield that determines whether other structure members are used.
        /// Any combination of the following values can be specified.
        /// <see cref="JOB_OBJECT_LIMIT_ACTIVE_PROCESS"/>, <see cref="JOB_OBJECT_LIMIT_AFFINITY"/>, <see cref="JOB_OBJECT_LIMIT_BREAKAWAY_OK"/>,
        /// <see cref="JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION"/>, <see cref="JOB_OBJECT_LIMIT_JOB_MEMORY"/>, <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>,
        /// <see cref="JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE"/>, <see cref="JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME"/>,
        /// <see cref="JOB_OBJECT_LIMIT_PRIORITY_CLASS"/>, <see cref="JOB_OBJECT_LIMIT_PROCESS_MEMORY"/>, <see cref="JOB_OBJECT_LIMIT_PROCESS_TIME"/>,
        /// <see cref="JOB_OBJECT_LIMIT_SCHEDULING_CLASS"/>, <see cref="JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK"/>,
        /// <see cref="JOB_OBJECT_LIMIT_SUBSET_AFFINITY"/>, <see cref="JOB_OBJECT_LIMIT_WORKINGSET"/>
        /// </summary>
        public JOB_OBJECT_LIMIT LimitFlags;

        /// <summary>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_WORKINGSET"/>,
        /// this member is the minimum working set size in bytes for each process associated with the job.
        /// Otherwise, this member is ignored.
        /// If <see cref="MaximumWorkingSetSize"/> is nonzero, <see cref="MinimumWorkingSetSize"/> cannot be zero.
        /// </summary>
        public SIZE_T MinimumWorkingSetSize;

        /// <summary>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_WORKINGSET"/>,
        /// this member is the maximum working set size in bytes for each process associated with the job.
        /// Otherwise, this member is ignored.
        /// If <see cref="MinimumWorkingSetSize"/> is nonzero, <see cref="MaximumWorkingSetSize"/> cannot be zero.
        /// </summary>
        public SIZE_T MaximumWorkingSetSize;

        /// <summary>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_ACTIVE_PROCESS"/>, this member is the active process limit for the job.
        /// Otherwise, this member is ignored.
        /// If you try to associate a process with a job, and this causes the active process count to exceed this limit,
        /// the process is terminated and the association fails.
        /// </summary>
        public DWORD ActiveProcessLimit;

        /// <summary>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_AFFINITY"/>,
        /// this member is the processor affinity for all processes associated with the job.
        /// Otherwise, this member is ignored.
        /// The affinity must be a subset of the system affinity mask obtained by calling the <see cref="GetProcessAffinityMask"/> function.
        /// The affinity of each thread is set to this value, but threads are free to subsequently set their affinity,
        /// as long as it is a subset of the specified affinity mask. Processes cannot set their own affinity mask.
        /// </summary>
        public ULONG_PTR Affinity;

        /// <summary>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_PRIORITY_CLASS"/>,
        /// this member is the priority class for all processes associated with the job.
        /// Otherwise, this member is ignored.
        /// Processes and threads cannot modify their priority class.
        /// The calling process must enable the SE_INC_BASE_PRIORITY_NAME privilege.
        /// </summary>
        public ProcessPriorityClasses PriorityClass;

        /// <summary>
        /// If <see cref="LimitFlags"/> specifies <see cref="JOB_OBJECT_LIMIT_SCHEDULING_CLASS"/>,
        /// this member is the scheduling class for all processes associated with the job.
        /// Otherwise, this member is ignored.
        /// The valid values are 0 to 9. Use 0 for the least favorable scheduling class relative to other threads,
        /// and 9 for the most favorable scheduling class relative to other threads.
        /// By default, this value is 5. To use a scheduling class greater than 5,
        /// the calling process must enable the SE_INC_BASE_PRIORITY_NAME privilege.
        /// </summary>
        public DWORD SchedulingClass;
    }
}
