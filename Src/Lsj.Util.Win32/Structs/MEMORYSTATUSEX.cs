using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the current state of both physical and virtual memory, including extended memory.
    /// The <see cref="GlobalMemoryStatusEx"/> function stores information in this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/ns-sysinfoapi-memorystatusex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="MEMORYSTATUSEX"/> reflects the state of memory at the time of the call.
    /// It also reflects the size of the paging file at that time.
    /// The operating system can enlarge the paging file up to the maximum size set by the administrator.
    /// The physical memory sizes returned include the memory from all nodes.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MEMORYSTATUSEX
    {
        /// <summary>
        /// The size of the structure, in bytes. You must set this member before calling <see cref="GlobalMemoryStatusEx"/>.
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
        public DWORDLONG ullTotalPhys;

        /// <summary>
        /// The amount of physical memory currently available, in bytes.
        /// This is the amount of physical memory that can be immediately reused without having to write its contents to disk first.
        /// It is the sum of the size of the standby, free, and zero lists.
        /// </summary>
        public DWORDLONG ullAvailPhys;

        /// <summary>
        /// The current committed memory limit for the system or the current process, whichever is smaller, in bytes.
        /// To get the system-wide committed memory limit, call <see cref="GetPerformanceInfo"/>.
        /// </summary>
        public DWORDLONG ullTotalPageFile;

        /// <summary>
        /// The maximum amount of memory the current process can commit, in bytes.
        /// This value is equal to or smaller than the system-wide available commit value.
        /// To calculate the system-wide available commit value, call <see cref="GetPerformanceInfo"/> and subtract
        /// the value of <see cref="PERFORMANCE_INFORMATION.CommitTotal"/> from the value of <see cref="PERFORMANCE_INFORMATION.CommitLimit"/>.
        /// </summary>
        public DWORDLONG ullAvailPageFile;

        /// <summary>
        /// The size of the user-mode portion of the virtual address space of the calling process, in bytes.
        /// This value depends on the type of process, the type of processor, and the configuration of the operating system.
        /// For example, this value is approximately 2 GB for most 32-bit processes on an x86 processor
        /// and approximately 3 GB for 32-bit processes that are large address aware running on a system with 4-gigabyte tuning enabled.
        /// </summary>
        public DWORDLONG ullTotalVirtual;

        /// <summary>
        /// The amount of unreserved and uncommitted memory currently in the user-mode portion
        /// of the virtual address space of the calling process, in bytes.
        /// </summary>
        public DWORDLONG ullAvailVirtual;

        /// <summary>
        /// Reserved. This value is always 0.
        /// </summary>
        public DWORDLONG ullAvailExtendedVirtual;
    }
}
