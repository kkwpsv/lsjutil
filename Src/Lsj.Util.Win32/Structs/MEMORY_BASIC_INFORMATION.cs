using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.MemoryAllocationTypes;
using static Lsj.Util.Win32.Enums.MemoryTypes;
using static Lsj.Util.Win32.Enums.VirtualFreeTypes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a range of pages in the virtual address space of a process.
    /// The <see cref="VirtualQuery"/> and <see cref="VirtualQueryEx"/> functions use this structure.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-memory_basic_information
    /// </para>
    /// </summary>
    /// <remarks>
    /// To enable a debugger to debug a target that is running on a different architecture (32-bit versus 64-bit),
    /// use one of the explicit forms of this structure.
    /// <see cref="MEMORY_BASIC_INFORMATION32"/>, <see cref="MEMORY_BASIC_INFORMATION64"/>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MEMORY_BASIC_INFORMATION
    {
        /// <summary>
        /// A pointer to the base address of the region of pages.
        /// </summary>
        public PVOID BaseAddress;

        /// <summary>
        /// A pointer to the base address of a range of pages allocated by the <see cref="VirtualAlloc"/> function.
        /// The page pointed to by the <see cref="BaseAddress"/> member is contained within this allocation range.
        /// </summary>
        public PVOID AllocationBase;

        /// <summary>
        /// The memory protection option when the region was initially allocated.
        /// This member can be one of the memory protection constants or 0 if the caller does not have access.
        /// </summary>
        public MemoryProtectionConstants AllocationProtect;

        /// <summary>
        /// The size of the region beginning at the base address in which all pages have identical attributes, in bytes.
        /// </summary>
        public SIZE_T RegionSize;

        /// <summary>
        /// The state of the pages in the region. This member can be one of the following values.
        /// <see cref="MEM_COMMIT"/>:
        /// Indicates committed pages for which physical storage has been allocated, either in memory or in the paging file on disk.
        /// <see cref="MEM_FREE"/>:
        /// Indicates free pages not accessible to the calling process and available to be allocated.
        /// For free pages, the information in the <see cref="AllocationBase"/>, <see cref="AllocationProtect"/>,
        /// <see cref="Protect"/>, and <see cref="Type"/> members is undefined.
        /// <see cref="MEM_RESERVE"/>:
        /// Indicates reserved pages where a range of the process's virtual address space is reserved without any physical storage being allocated.
        /// For reserved pages, the information in the <see cref="Protect"/> member is undefined.
        /// </summary>
        public DWORD State;

        /// <summary>
        /// The access protection of the pages in the region.
        /// This member is one of the values listed for the <see cref="AllocationProtect"/> member.
        /// </summary>
        public DWORD Protect;

        /// <summary>
        /// The type of pages in the region. The following types are defined.
        /// <see cref="MEM_IMAGE"/>:
        /// Indicates that the memory pages within the region are mapped into the view of an image section.
        /// <see cref="MEM_MAPPED"/>:
        /// Indicates that the memory pages within the region are mapped into the view of a section.
        /// <see cref="MEM_PRIVATE"/>:
        /// Indicates that the memory pages within the region are private (that is, not shared by other processes).
        /// </summary>
        public MemoryTypes Type;
    }
}
