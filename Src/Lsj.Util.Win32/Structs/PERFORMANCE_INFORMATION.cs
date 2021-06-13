using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.MemoryAllocationTypes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains performance information.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/psapi/ns-psapi-performance_information"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PERFORMANCE_INFORMATION
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public DWORD cb;

        /// <summary>
        /// The number of pages currently committed by the system.
        /// Note that committing pages (using <see cref="VirtualAlloc"/> with <see cref="MEM_COMMIT"/>) changes this value immediately;
        /// however, the physical memory is not charged until the pages are accessed.
        /// </summary>
        public SIZE_T CommitTotal;

        /// <summary>
        /// The current maximum number of pages that can be committed by the system without extending the paging file(s).
        /// This number can change if memory is added or deleted, or if pagefiles have grown, shrunk, or been added.
        /// If the paging file can be extended, this is a soft limit.
        /// </summary>
        public SIZE_T CommitLimit;

        /// <summary>
        /// The maximum number of pages that were simultaneously in the committed state since the last system reboot.
        /// </summary>
        public SIZE_T CommitPeak;

        /// <summary>
        /// The amount of actual physical memory, in pages.
        /// </summary>
        public SIZE_T PhysicalTotal;

        /// <summary>
        /// The amount of physical memory currently available, in pages.
        /// This is the amount of physical memory that can be immediately reused without having to write its contents to disk first.
        /// It is the sum of the size of the standby, free, and zero lists.
        /// </summary>
        public SIZE_T PhysicalAvailable;

        /// <summary>
        /// The amount of system cache memory, in pages. This is the size of the standby list plus the system working set.
        /// </summary>
        public SIZE_T SystemCache;

        /// <summary>
        /// The sum of the memory currently in the paged and nonpaged kernel pools, in pages.
        /// </summary>
        public SIZE_T KernelTotal;

        /// <summary>
        /// The memory currently in the paged kernel pool, in pages.
        /// </summary>
        public SIZE_T KernelPaged;

        /// <summary>
        /// The memory currently in the nonpaged kernel pool, in pages.
        /// </summary>
        public SIZE_T KernelNonpaged;

        /// <summary>
        /// The size of a page, in bytes.
        /// </summary>
        public SIZE_T PageSize;

        /// <summary>
        /// The current number of open handles.
        /// </summary>
        public DWORD HandleCount;

        /// <summary>
        /// The current number of processes.
        /// </summary>
        public DWORD ProcessCount;

        /// <summary>
        /// The current number of threads.
        /// </summary>
        public DWORD ThreadCount;
    }
}
