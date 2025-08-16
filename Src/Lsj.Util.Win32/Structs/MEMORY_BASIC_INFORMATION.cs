using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.MemoryAllocationTypes;
using static Lsj.Util.Win32.Enums.MemoryPageTypes;
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
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-memory_basic_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To enable a debugger to debug a target that is running on a different architecture (32-bit versus 64-bit),
    /// use one of the explicit forms of this structure.
    /// </para>
    /// <code>
    /// typedef struct _MEMORY_BASIC_INFORMATION32 {
    ///     DWORD BaseAddress;
    ///     DWORD AllocationBase;
    ///     DWORD AllocationProtect;
    ///     DWORD RegionSize;
    ///     DWORD State;
    ///     DWORD Protect;
    ///     DWORD Type;
    /// }
    /// MEMORY_BASIC_INFORMATION32, *PMEMORY_BASIC_INFORMATION32;
    /// 
    /// typedef struct DECLSPEC_ALIGN(16) _MEMORY_BASIC_INFORMATION64 {
    ///     ULONGLONG BaseAddress;
    ///     ULONGLONG AllocationBase;
    ///     DWORD AllocationProtect;
    ///     DWORD __alignment1;
    ///     ULONGLONG RegionSize;
    ///     DWORD State;
    ///     DWORD Protect;
    ///     DWORD Type;
    ///     DWORD __alignment2;
    /// }
    /// MEMORY_BASIC_INFORMATION64, *PMEMORY_BASIC_INFORMATION64;
    /// </code>
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
        /// 
        /// </summary>
        public WORD PartitionId;

        /// <summary>
        /// The size of the region beginning at the base address in which all pages have identical attributes, in bytes.
        /// </summary>
        public SIZE_T RegionSize;

        /// <summary>
        /// <para>
        /// The state of the pages in the region.
        /// This member can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// State
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_COMMIT"/>
        /// </para>
        /// <para>
        /// 0x1000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates committed pages for which physical storage has been allocated, either in memory or in the paging file on disk.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_FREE"/>
        /// </para>
        /// <para>
        /// 0x10000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates free pages not accessible to the calling process and available to be allocated.
        /// For free pages, the information in the <see cref="AllocationBase"/>, <see cref="AllocationProtect"/>,
        /// <see cref="Protect"/>, and <see cref="Type"/> members is undefined.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESERVE"/>
        /// </para>
        /// <para>
        /// 0x2000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates reserved pages where a range of the process's virtual address space is reserved without any physical storage being allocated.
        /// For reserved pages, the information in the <see cref="Protect"/> member is undefined.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD State;

        /// <summary>
        /// The access protection of the pages in the region.
        /// This member is one of the values listed for the <see cref="AllocationProtect"/> member.
        /// </summary>
        public DWORD Protect;

        /// <summary>
        /// <para>
        /// The type of pages in the region. The following types are defined.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Type
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_IMAGE"/>
        /// </para>
        /// <para>
        /// 0x1000000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the memory pages within the region are mapped into the view of an image section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_MAPPED"/>
        /// </para>
        /// <para>
        /// 0x40000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the memory pages within the region are mapped into the view of a section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_PRIVATE"/>
        /// </para>
        /// <para>
        /// 0x20000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the memory pages within the region are private (that is, not shared by other processes).
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public MemoryPageTypes Type;
    }
}
