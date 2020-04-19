using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// JOB_OBJECT_END_OF_JOB
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_end_of_job_time_information
    /// </para>
    /// </summary>
    public enum JOB_OBJECT_END_OF_JOB : uint
    {
        /// <summary>
        /// Terminates all processes and sets the exit status to <see cref="ERROR_NOT_ENOUGH_QUOTA"/>.
        /// The processes cannot prevent or delay their own termination.
        /// The job object is set to the signaled state and remains signaled until this limit is reset.
        /// No additional processes can be assigned to the job until the limit is reset.
        /// This is the default termination action.
        /// </summary>
        JOB_OBJECT_TERMINATE_AT_END_OF_JOB = 0,

        /// <summary>
        /// Posts a completion packet to the completion port using the <see cref="PostQueuedCompletionStatus"/> function.
        /// After the completion packet is posted, the system clears the end-of-job time limit, and processes in the job can continue their execution.
        /// If no completion port is associated with the job when the time limit has been exceeded,
        /// the action taken is the same as for <see cref="JOB_OBJECT_TERMINATE_AT_END_OF_JOB"/>.
        /// </summary>
        JOB_OBJECT_POST_AT_END_OF_JOB = 1,
    }
}
