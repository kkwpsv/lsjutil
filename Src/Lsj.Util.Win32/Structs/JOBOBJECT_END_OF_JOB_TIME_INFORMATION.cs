using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.JOB_OBJECT_END_OF_JOB;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the action the system will perform when an end-of-job time limit is exceeded.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-jobobject_end_of_job_time_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The end-of-job time limit is specified in the <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.PerJobUserTimeLimit"/> member
    /// of the <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
    /// </para>
    /// <para>
    /// To associate a completion port with a job, use the <see cref="JOBOBJECT_ASSOCIATE_COMPLETION_PORT"/> structure.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_END_OF_JOB_TIME_INFORMATION
    {
        /// <summary>
        /// <para>
        /// The action that the system will perform when the end-of-job time limit has been exceeded.
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
        /// <see cref="JOB_OBJECT_TERMINATE_AT_END_OF_JOB"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Terminates all processes and sets the exit status to <see cref="ERROR_NOT_ENOUGH_QUOTA"/>.
        /// The processes cannot prevent or delay their own termination.
        /// The job object is set to the signaled state and remains signaled until this limit is reset.
        /// No additional processes can be assigned to the job until the limit is reset.
        /// </para>
        /// <para>
        /// This is the default termination action.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JOB_OBJECT_POST_AT_END_OF_JOB"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Posts a completion packet to the completion port using the <see cref="PostQueuedCompletionStatus"/> function.
        /// After the completion packet is posted, the system clears the end-of-job time limit, and processes in the job can continue their execution.
        /// </para>
        /// <para>
        /// If no completion port is associated with the job when the time limit has been exceeded,
        /// the action taken is the same as for <see cref="JOB_OBJECT_TERMINATE_AT_END_OF_JOB"/>.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public JOB_OBJECT_END_OF_JOB EndOfJobTimeAction;
    }
}
