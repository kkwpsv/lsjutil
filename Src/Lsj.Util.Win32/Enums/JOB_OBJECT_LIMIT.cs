using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.ErrorModes;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_MSG;
using static Lsj.Util.Win32.Enums.JOBOBJECTINFOCLASS;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// JOB_OBJECT_LIMIT
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_basic_limit_information"/>
    /// </para>
    /// </summary>
    public enum JOB_OBJECT_LIMIT
    {
        /// <summary>
        /// Establishes a maximum number of simultaneously active processes associated with the job.
        /// The <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.ActiveProcessLimit"/> member contains additional information.
        /// </summary>
        JOB_OBJECT_LIMIT_ACTIVE_PROCESS = 0x00000008,

        /// <summary>
        /// Causes all processes associated with the job to use the same processor affinity.
        /// The <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.Affinity"/> member contains additional information.
        /// If the job is nested, the specified processor affinity must be a subset of the effective affinity of the parent job.
        /// If the specified affinity a superset of the affinity of the parent job, it is ignored and the affinity of the parent job is used.
        /// </summary>
        JOB_OBJECT_LIMIT_AFFINITY = 0x00000010,

        /// <summary>
        /// If any process associated with the job creates a child process using the <see cref="CREATE_BREAKAWAY_FROM_JOB"/> flag
        /// while this limit is in effect, the child process is not associated with the job.
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member
        /// is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </summary>
        JOB_OBJECT_LIMIT_BREAKAWAY_OK = 0x00000800,

        /// <summary>
        /// Forces a call to the <see cref="SetErrorMode"/> function with the <see cref="SEM_NOGPFAULTERRORBOX"/> flag
        /// for each process associated with the job.
        /// If an exception occurs and the system calls the <see cref="UnhandledExceptionFilter"/> function, the debugger will be given a chance to act.
        /// If there is no debugger, the functions returns <see cref="EXCEPTION_EXECUTE_HANDLER"/>.
        /// Normally, this will cause termination of the process with the exception code as the exit status.
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member
        /// is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </summary>
        JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION = 0x00000400,

        /// <summary>
        /// Causes all processes associated with the job to limit the job-wide sum of their committed memory.
        /// When a process attempts to commit memory that would exceed the job-wide limit, it fails.
        /// If the job object is associated with a completion port, a <see cref="JOB_OBJECT_MSG_JOB_MEMORY_LIMIT"/> message is sent to the completion port.
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member
        /// is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// To register for notification when this limit is exceeded while allowing processes to continue to commit memory,
        /// use the <see cref="SetInformationJobObject"/> function with the <see cref="JobObjectNotificationLimitInformation"/> information class.
        /// </summary>
        JOB_OBJECT_LIMIT_JOB_MEMORY = 0x00000200,

        /// <summary>
        /// Establishes a user-mode execution time limit for the job.
        /// The <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.PerJobUserTimeLimit"/> member contains additional information.
        /// This flag cannot be used with <see cref="JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME"/>.
        /// </summary>
        JOB_OBJECT_LIMIT_JOB_TIME = 0x00000004,

        /// <summary>
        /// Causes all processes associated with the job to terminate when the last handle to the job is closed.
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member
        /// is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </summary>
        JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE = 0x00002000,

        /// <summary>
        /// Preserves any job time limits you previously set.
        /// As long as this flag is set, you can establish a per-job time limit once, then alter other limits in subsequent calls.
        /// This flag cannot be used with <see cref="JOB_OBJECT_LIMIT_JOB_TIME"/>.
        /// </summary>
        JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME = 0x00000040,

        /// <summary>
        /// Causes all processes associated with the job to use the same priority class.
        /// For more information, see Scheduling Priorities.
        /// The <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.PriorityClass"/> member contains additional information.
        /// If the job is nested, the effective priority class is the lowest priority class in the job chain.
        /// </summary>
        JOB_OBJECT_LIMIT_PRIORITY_CLASS = 0x00000020,

        /// <summary>
        /// Causes all processes associated with the job to limit their committed memory.
        /// When a process attempts to commit memory that would exceed the per-process limit, it fails.
        /// If the job object is associated with a completion port,
        /// a <see cref="JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT"/> message is sent to the completion port.
        /// If the job is nested, the effective memory limit is the most restrictive memory limit in the job chain.
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member
        /// is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </summary>
        JOB_OBJECT_LIMIT_PROCESS_MEMORY = 0x00000100,

        /// <summary>
        /// Establishes a user-mode execution time limit for each currently active process and for all future processes associated with the job.
        /// The <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.PerProcessUserTimeLimit"/> member contains additional information.
        /// </summary>
        JOB_OBJECT_LIMIT_PROCESS_TIME = 0x00000002,

        /// <summary>
        /// Causes all processes in the job to use the same scheduling class.
        /// The <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.SchedulingClass"/> member contains additional information.
        /// If the job is nested, the effective scheduling class is the lowest scheduling class in the job chain.
        /// </summary>
        JOB_OBJECT_LIMIT_SCHEDULING_CLASS = 0x00000080,

        /// <summary>
        /// Allows any process associated with the job to create child processes that are not associated with the job.
        /// If the job is nested and its immediate job object allows breakaway,
        /// the child process breaks away from the immediate job object and from each job in the parent job chain,
        /// moving up the hierarchy until it reaches a job that does not permit breakaway.
        /// If the immediate job object does not allow breakaway, the child process does not break away even if jobs in its parent job chain allow it.
        /// This limit requires use of a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// Its <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION.BasicLimitInformation"/> member
        /// is a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </summary>
        JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK = 0x00001000,

        /// <summary>
        /// Allows processes to use a subset of the processor affinity for all processes associated with the job.
        /// This value must be combined with <see cref="JOB_OBJECT_LIMIT_AFFINITY"/>.
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This flag is supported starting with Windows 7 and Windows Server 2008 R2.
        /// </summary>
        JOB_OBJECT_LIMIT_SUBSET_AFFINITY = 0x00004000,

        /// <summary>
        /// Causes all processes associated with the job to use the same minimum and maximum working set sizes.
        /// The <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.MinimumWorkingSetSize"/>
        /// and <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.MaximumWorkingSetSize"/> members contain additional information.
        /// If the job is nested, the effective working set size is the smallest working set size in the job chain.
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
        /// 0x00080000
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
