using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the current state of both physical and virtual memory.
    /// The <see cref="GlobalMemoryStatus"/> function stores information in a <see cref="MEMORYSTATUS"/> structure.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-memorystatus
    /// </para>
    /// </summary>
    /// <remarks>
    /// MEMORYSTATUS reflects the state of memory at the time of the call. It also reflects the size of the paging file at that time.
    /// The operating system can enlarge the paging file up to the maximum size set by the administrator.
    /// On computers with more than 4 GB of memory, the <see cref="MEMORYSTATUS"/> structure can return incorrect information,
    /// reporting a value of –1 to indicate an overflow.
    /// If your application is at risk for this behavior,
    /// use the <see cref="GlobalMemoryStatusEx"/> function instead of the <see cref="GlobalMemoryStatus"/> function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MEMORYSTATUS
    {
        /// <summary>
        /// The size of the <see cref="MEMORYSTATUS"/> data structure, in bytes.
        /// You do not need to set this member before calling the <see cref="GlobalMemoryStatus"/> function; the function sets it.
        /// </summary>
        public DWORD dwLength;

        /// <summary>
        /// A number between 0 and 100 that specifies the approximate percentage of physical memory
        /// that is in use (0 indicates no memory use and 100 indicates full memory use).
        /// </summary>
        public DWORD dwMemoryLoad;

        /// <summary>
        /// The amount of actual physical memory, in bytes.
        /// </summary>
        public SIZE_T dwTotalPhys;

        /// <summary>
        /// The amount of physical memory currently available, in bytes.
        /// This is the amount of physical memory that can be immediately reused without having to write its contents to disk first.
        /// It is the sum of the size of the standby, free, and zero lists.
        /// </summary>
        public SIZE_T dwAvailPhys;

        /// <summary>
        /// The current size of the committed memory limit, in bytes.
        /// This is physical memory plus the size of the page file, minus a small overhead.
        /// </summary>
        public SIZE_T dwTotalPageFile;

        /// <summary>
        /// The maximum amount of memory the current process can commit, in bytes.
        /// This value should be smaller than the system-wide available commit.
        /// To calculate this value, call <see cref="GetPerformanceInfo"/> and subtract the value
        /// of <see cref="CommitTotal"/> from <see cref="CommitLimit"/>.
        /// </summary>
        public SIZE_T dwAvailPageFile;

        /// <summary>
        /// The size of the user-mode portion of the virtual address space of the calling process, in bytes.
        /// This value depends on the type of process, the type of processor, and the configuration of the operating system.
        /// For example, this value is approximately 2 GB for most 32-bit processes on an x86 processor
        /// and approximately 3 GB for 32-bit processes that are large address aware running on a system with 4 GT RAM Tuning enabled.
        /// </summary>
        public SIZE_T dwTotalVirtual;

        /// <summary>
        /// The amount of unreserved and uncommitted memory currently in the user-mode portion of the virtual address space of the calling process, in bytes.
        /// </summary>
        public SIZE_T dwAvailVirtual;
    }
}
