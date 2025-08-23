using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.JobObjectEndOfJobTimeActions;
using static Lsj.Util.Win32.Enums.JobObjectMessageIdentifiers;
using static Lsj.Util.Win32.Enums.JobObjectInformationClasses;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information used to associate a completion port with a job. You can associate one completion port with a job.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-jobobject_associate_completion_port"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The system sends messages to the I/O completion port associated with a job when certain events occur.
    /// If the job is nested, the message is sent to every I/O completion port associated
    /// with any job in the parent job chain of the job that triggered the message.
    /// All messages are sent directly from the job as if the job had called the <see cref="PostQueuedCompletionStatus"/> function.
    /// </para>
    /// <para>
    /// Note that, except for limits set with the <see cref="JobObjectNotificationLimitInformation"/> information class,
    /// messages are intended only as notifications and their delivery to the completion port is not guaranteed.
    /// The failure of a message to arrive at the completion port does not necessarily mean that the event did not occur.
    /// Notifications for limits set with <see cref="JobObjectNotificationLimitInformation"/> are guaranteed to arrive at the completion port.
    /// </para>
    /// <para>
    /// A thread must monitor the completion port using the <see cref="GetQueuedCompletionStatus"/> function to pick up the messages.
    /// The thread receives information in the <see cref="GetQueuedCompletionStatus"/> parameters shown in the following table.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Parameter
    /// </term>
    /// <term>
    /// Information Received
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// lpCompletionKey
    /// </term>
    /// <term>
    /// The value specified in <see cref="CompletionKey"/> during the completion-port association.
    /// If a completion port is associated with multiple jobs,
    /// <see cref="CompletionKey"/> should help the caller determine which completion port is sending a message.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// lpOverlapped
    /// </term>
    /// <term>
    /// Message-specific value.
    /// For more information, see the following table of message identifiers.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// lpNumberOfBytes
    /// </term>
    /// <term>
    /// The message identifier that indicates which job-related event occurred.
    /// For more information, see the following table of message identifiers.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// The following messages can be sent to the completion port.
    /// Note that for messages that return a process identifier,
    /// you cannot guarantee that this process is still active or that the identifier has not been recycled (assigned to a new process after termination)
    /// unless you maintain an open handle to the process.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Message Identifier
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="JOB_OBJECT_MSG_ABNORMAL_EXIT_PROCESS"/>
    /// </term>
    /// <term>
    /// <para>
    /// Indicates that a process associated with the job exited with an exit code that indicates an abnormal exit (see the list following this table).
    /// </para>
    /// <para>
    /// The value of lpOverlapped is the identifier of the exiting process.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="JOB_OBJECT_MSG_ACTIVE_PROCESS_LIMIT"/>
    /// </term>
    /// <term>
    /// <para>
    /// Indicates that the active process limit has been exceeded.
    /// </para>
    /// <para>
    /// The value of lpOverlapped is <see cref="NULL"/>.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="JOB_OBJECT_MSG_ACTIVE_PROCESS_ZERO"/>
    /// </term>
    /// <term>
    /// <para>
    /// Indicates that the active process count has been decremented to 0.
    /// For example, if the job currently has two active processes, the system sends this message after they both terminate.
    /// </para>
    /// <para>
    /// The value of lpOverlapped is <see cref="NULL"/>.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="JOB_OBJECT_MSG_END_OF_JOB_TIME"/>
    /// </term>
    /// <term>
    /// <para>
    /// Indicates that the <see cref="JOB_OBJECT_POST_AT_END_OF_JOB"/> option is in effect and the end-of-job time limit has been reached.
    /// Upon posting this message, the time limit is canceled and the job's processes can continue to run.
    /// </para>
    /// <para>
    /// The value of lpOverlapped is <see cref="NULL"/>.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="JOB_OBJECT_MSG_END_OF_PROCESS_TIME"/>
    /// </term>
    /// <term>
    /// <para>
    /// Indicates that a process has exceeded a per-process time limit.
    /// The system sends this message after the process termination has been requested.
    /// </para>
    /// <para>
    /// The value of lpOverlapped is the identifier of the process that exceeded its limit.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="JOB_OBJECT_MSG_EXIT_PROCESS"/>
    /// </term>
    /// <term>
    /// <para>
    /// Indicates that a process associated with the job has exited.
    /// </para>
    /// <para>
    /// The value of lpOverlapped is the identifier of the exiting process.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="JOB_OBJECT_MSG_JOB_MEMORY_LIMIT"/>
    /// </term>
    /// <term>
    /// <para>
    /// Indicates that a process associated with the job caused the job to exceed the job-wide memory limit (if one is in effect).
    /// </para>
    /// <para>
    /// The value of lpOverlapped specifies the identifier of the process that has attempted to exceed the limit.
    /// The system does not send this message if the process has not yet reported its process identifier.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="JOB_OBJECT_MSG_NEW_PROCESS"/>
    /// </term>
    /// <term>
    /// <para>
    /// Indicates that a process has been added to the job.
    /// Processes added to a job at the time a completion port is associated are also reported.
    /// </para>
    /// <para>
    /// The value of lpOverlapped is the identifier of the process added to the job.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="JOB_OBJECT_MSG_NOTIFICATION_LIMIT"/>
    /// </term>
    /// <term>
    /// <para>
    /// Indicates that a process associated with a job that has registered for resource limit notifications has exceeded one or more limits.
    /// Use the <see cref="QueryInformationJobObject"/> function with <see cref="JobObjectLimitViolationInformation"/> to determine which limit was exceeded.
    /// </para>
    /// <para>
    /// The value of lpOverlapped is the identifier of the process that has exceeded its limit.
    /// The system does not send this message if the process has not yet reported its process identifier.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT"/>
    /// </term>
    /// <term>
    /// <para>
    /// Indicates that a process associated with the job has exceeded its memory limit (if one is in effect).
    /// </para>
    /// <para>
    /// The value of lpOverlapped is the identifier of the process that has exceeded its limit.
    /// The system does not send this message if the process has not yet reported its process identifier.
    /// </para>
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// The following exit codes indicate an abnormal exit:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="STATUS_GUARD_PAGE_VIOLATION"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_DATATYPE_MISALIGNMENT"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_BREAKPOINT"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_SINGLE_STEP"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_ACCESS_VIOLATION"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_IN_PAGE_ERROR"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_ILLEGAL_INSTRUCTION"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_NONCONTINUABLE_EXCEPTION"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_INVALID_DISPOSITION"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_ARRAY_BOUNDS_EXCEEDED"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_FLOAT_DENORMAL_OPERAND"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_FLOAT_DIVIDE_BY_ZERO"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_FLOAT_INEXACT_RESULT"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_FLOAT_INVALID_OPERATION"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_FLOAT_OVERFLOW"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_FLOAT_STACK_CHECK"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_FLOAT_UNDERFLOW"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_INTEGER_DIVIDE_BY_ZERO"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_INTEGER_OVERFLOW"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_PRIVILEGED_INSTRUCTION"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_STACK_OVERFLOW"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_CONTROL_C_EXIT"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_FLOAT_MULTIPLE_FAULTS"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_FLOAT_MULTIPLE_TRAPS"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="STATUS_REG_NAT_CONSUMPTION"/>
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// You must be cautious when using the <see cref="JOB_OBJECT_MSG_NEW_PROCESS"/>
    /// and <see cref="JOB_OBJECT_MSG_EXIT_PROCESS"/> messages, as race conditions may occur.
    /// For instance, if processes are actively starting and exiting within a job,
    /// and you are in the process of assigning a completion port to the job,
    /// you may miss messages for processes whose states change during the association of the completion port.
    /// For this reason, it is best to associate a completion port with a job when the job is inactive.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_ASSOCIATE_COMPLETION_PORT
    {
        /// <summary>
        /// The value to use in the dwCompletionKey parameter of <see cref="PostQueuedCompletionStatus"/>
        /// when messages are sent on behalf of the job.
        /// </summary>
        public PVOID CompletionKey;

        /// <summary>
        /// <para>
        /// The completion port to use in the CompletionPort parameter of the <see cref="PostQueuedCompletionStatus"/> function
        /// when messages are sent on behalf of the job.
        /// </para>
        /// <para>
        /// Windows 8 and newer, Windows Server 2012 and newer:
        /// Specify <see cref="NULL"/> to remove the association between the current completion port and the job.
        /// </para>
        /// </summary>
        public HANDLE CompletionPort;
    }
}
