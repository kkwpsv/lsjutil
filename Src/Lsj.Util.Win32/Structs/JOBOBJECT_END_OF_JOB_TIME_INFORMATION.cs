using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the action the system will perform when an end-of-job time limit is exceeded.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_end_of_job_time_information
    /// </para>
    /// </summary>
    /// <remarks>
    /// The end-of-job time limit is specified in the <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.PerJobUserTimeLimit"/> member
    /// of the <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
    /// To associate a completion port with a job, use the <see cref="JOBOBJECT_ASSOCIATE_COMPLETION_PORT"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_END_OF_JOB_TIME_INFORMATION
    {
        /// <summary>
        /// The action that the system will perform when the end-of-job time limit has been exceeded. This member can be one of the following values.
        /// </summary>
        public JOB_OBJECT_END_OF_JOB EndOfJobTimeAction;
    }
}
