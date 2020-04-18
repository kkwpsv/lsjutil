using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains I/O accounting information for a process or a job object.
    /// For a job object, the counters include all operations performed by all processes that have ever been associated with the job,
    /// in addition to all processes currently associated with the job.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-io_counters
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct IO_COUNTERS
    {
        /// <summary>
        /// The number of read operations performed.
        /// </summary>
        public ULONGLONG ReadOperationCount;

        /// <summary>
        /// The number of write operations performed.
        /// </summary>
        public ULONGLONG WriteOperationCount;

        /// <summary>
        /// The number of I/O operations performed, other than read and write operations.
        /// </summary>
        public ULONGLONG OtherOperationCount;

        /// <summary>
        /// The number of bytes read.
        /// </summary>
        public ULONGLONG ReadTransferCount;

        /// <summary>
        /// The number of bytes written.
        /// </summary>
        public ULONGLONG WriteTransferCount;

        /// <summary>
        /// The number of bytes transferred during operations other than read and write operations.
        /// </summary>
        public ULONGLONG OtherTransferCount;
    }
}
