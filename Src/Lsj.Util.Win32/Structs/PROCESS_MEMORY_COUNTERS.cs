using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the memory statistics for a process.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/psapi/ns-psapi-process_memory_counters
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MEMORY_COUNTERS
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public DWORD cb;

        /// <summary>
        /// The number of page faults.
        /// </summary>
        public DWORD PageFaultCount;

        /// <summary>
        /// The peak working set size, in bytes.
        /// </summary>
        public SIZE_T PeakWorkingSetSize;

        /// <summary>
        /// The current working set size, in bytes.
        /// </summary>
        public SIZE_T WorkingSetSize;

        /// <summary>
        /// The peak paged pool usage, in bytes.
        /// </summary>
        public SIZE_T QuotaPeakPagedPoolUsage;

        /// <summary>
        /// The current paged pool usage, in bytes.
        /// </summary>
        public SIZE_T QuotaPagedPoolUsage;

        /// <summary>
        /// The peak nonpaged pool usage, in bytes.
        /// </summary>
        public SIZE_T QuotaPeakNonPagedPoolUsage;

        /// <summary>
        /// The current nonpaged pool usage, in bytes.
        /// </summary>
        public SIZE_T QuotaNonPagedPoolUsage;

        /// <summary>
        /// The Commit Charge value in bytes for this process.
        /// Commit Charge is the total amount of memory that the memory manager has committed for a running process.
        /// </summary>
        public SIZE_T PagefileUsage;

        /// <summary>
        /// The peak value in bytes of the Commit Charge during the lifetime of this process.
        /// </summary>
        public SIZE_T PeakPagefileUsage;
    }
}
