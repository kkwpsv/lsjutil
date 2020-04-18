using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains basic accounting and I/O accounting information for a job object.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-jobobject_basic_and_io_accounting_information
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION
    {
        /// <summary>
        /// A <see cref="JOBOBJECT_BASIC_ACCOUNTING_INFORMATION"/> structure that specifies the basic accounting information for the job.
        /// </summary>
        public JOBOBJECT_BASIC_ACCOUNTING_INFORMATION BasicInfo;

        /// <summary>
        /// An <see cref="IO_COUNTERS"/> structure that specifies the I/O accounting information for the job.
        /// The structure includes information for all processes that have ever been associated with the job,
        /// in addition to the information for all processes currently associated with the job.
        /// </summary>
        public IO_COUNTERS IoInfo;
    }
}
