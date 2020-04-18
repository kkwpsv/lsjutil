using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains basic accounting information for a job object.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_basic_accounting_information
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_BASIC_ACCOUNTING_INFORMATION
    {
        /// <summary>
        /// The total amount of user-mode execution time for all active processes associated with the job,
        /// as well as all terminated processes no longer associated with the job, in 100-nanosecond ticks.
        /// </summary>
        public LARGE_INTEGER TotalUserTime;

        /// <summary>
        /// The total amount of kernel-mode execution time for all active processes associated with the job,
        /// as well as all terminated processes no longer associated with the job, in 100-nanosecond ticks.
        /// </summary>
        public LARGE_INTEGER TotalKernelTime;

        /// <summary>
        /// The total amount of user-mode execution time for all active processes associated with the job
        /// (as well as all terminated processes no longer associated with the job) since the last call that set a per-job user-mode time limit,
        /// in 100-nanosecond ticks.
        /// This member is set to 0 on creation of the job, and each time a per-job user-mode time limit is established.
        /// </summary>
        public LARGE_INTEGER ThisPeriodTotalUserTime;

        /// <summary>
        /// The total amount of kernel-mode execution time for all active processes associated with the job
        /// (as well as all terminated processes no longer associated with the job) since the last call that set a per-job kernel-mode time limit,
        /// in 100-nanosecond ticks.
        /// This member is set to zero on creation of the job, and each time a per-job kernel-mode time limit is established.
        /// </summary>
        public LARGE_INTEGER ThisPeriodTotalKernelTime;

        /// <summary>
        /// The total number of page faults encountered by all active processes associated with the job,
        /// as well as all terminated processes no longer associated with the job.
        /// </summary>
        public DWORD TotalPageFaultCount;

        /// <summary>
        /// The total number of processes associated with the job during its lifetime, including those that have terminated.
        /// For example, when a process is associated with a job, but the association fails because of a limit violation, this value is incremented.
        /// </summary>
        public DWORD TotalProcesses;

        /// <summary>
        /// The total number of processes currently associated with the job.
        /// When a process is associated with a job, but the association fails because of a limit violation, this value is temporarily incremented.
        /// When the terminated process exits and all references to the process are released, this value is decremented.
        /// </summary>
        public DWORD ActiveProcesses;

        /// <summary>
        /// The total number of processes terminated because of a limit violation.
        /// </summary>
        public DWORD TotalTerminatedProcesses;
    }
}
