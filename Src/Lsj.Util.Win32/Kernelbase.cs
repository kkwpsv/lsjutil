using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MEM_EXTENDED_PARAMETER_TYPE;
using static Lsj.Util.Win32.Enums.MemoryAllocationTypes;
using static Lsj.Util.Win32.Enums.MemoryProtectionConstants;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.SectionAttributes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.VirtualFreeTypes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Kernelbase.dll
    /// </summary>
    public static class Kernelbase
    {
        /// <summary>
        /// <para>
        /// Compares two object handles to determine if they refer to the same underlying kernel object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-compareobjecthandles"/>
        /// </para>
        /// </summary>
        /// <param name="hFirstObjectHandle">
        /// The first object handle to compare.
        /// </param>
        /// <param name="hSecondObjectHandle">
        /// The second object handle to compare.
        /// </param>
        /// <returns>
        /// A Boolean value that indicates if the two handles refer to the same underlying kernel object.
        /// <see cref="TRUE"/> if the same, otherwise <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CompareObjectHandles"/> function is useful to determine if two kernel handles refer to the same kernel object
        /// without imposing a requirement that specific access rights be granted to either handle in order to perform the comparison.
        /// For example, if a process desires to determine whether a process handle is a handle to the current process,
        /// a call to <c>CompareObjectHandles (GetCurrentProcess (), hProcess)</c> can be used to determine if hProcess refers to the current process.
        /// Notably, this does not require the use of object-specific access rights, whereas in this example,
        /// calling <see cref="GetProcessId"/> to check the process IDs of two process handles imposes a requirement
        /// that the handles grant <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access.
        /// However it is legal for a process handle to not have that access right granted depending on how the handle is intended to be used.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows10)]
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "CompareObjectHandles", ExactSpelling = true)]
        public static extern BOOL CompareObjectHandles([In] HANDLE hFirstObjectHandle, [In] HANDLE hSecondObjectHandle);

        /// <summary>
        /// <para>
        /// Maps a view of a file or a pagefile-backed section into the address space of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-mapviewoffile2"/>
        /// </para>
        /// </summary>
        /// <param name="FileMappingHandle">
        /// A <see cref="HANDLE"/> to a section that is to be mapped into the address space of the specified process.
        /// </param>
        /// <param name="ProcessHandle">
        /// A <see cref="HANDLE"/> to a process into which the section will be mapped.
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access mask.
        /// </param>
        /// <param name="Offset">
        /// The offset from the beginning of the section. This must be 64k aligned.
        /// </param>
        /// <param name="BaseAddress">
        /// The desired base address of the view. The address is rounded down to the nearest 64k boundary.
        /// If this parameter is <see cref="NULL"/>, the system picks the base address.
        /// </param>
        /// <param name="ViewSize">
        /// The number of bytes to map. A value of zero (0) specifies that the entire section is to be mapped.
        /// </param>
        /// <param name="AllocationType">
        /// <para>
        /// The type of allocation. This parameter can be zero (0) or one of the following constant values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MEM_RESERVE"/> - Maps a reserved view.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MEM_LARGE_PAGES"/> - Maps a large page view.
        /// This flag specifies that the view should be mapped using large page support.
        /// The size of the view must be a multiple of the size of a large page reported by the <see cref="GetLargePageMinimum"/> function,
        /// and the file-mapping object must have been created using the <see cref="SEC_LARGE_PAGES"/> option.
        /// If you provide a non-null value for the <paramref name="BaseAddress"/> parameter,
        /// then the value must be a multiple of <see cref="GetLargePageMinimum"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="PageProtection">
        /// <para>
        /// The desired page protection.
        /// </para>
        /// <para>
        /// For file-mapping objects created with the <see cref="SEC_IMAGE"/> attribute,
        /// the <paramref name="PageProtection"/> parameter has no effect,
        /// and should be set to any valid value such as <see cref="PAGE_READONLY"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// Returns the base address of the mapped view, if successful.
        /// Otherwise, returns <see cref="NULL"/> and extended error status is available using <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function is implemented as an inline function in the header and can't be found in any export library or DLL.
        /// It's the same as calling <see cref="MapViewOfFileNuma2"/> with the last parameter set to .
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1703)]
        public static PVOID MapViewOfFile2([In] HANDLE FileMappingHandle, [In] HANDLE ProcessHandle, [In] ULONG64 Offset,
            [In] PVOID BaseAddress, [In] SIZE_T ViewSize, [In] MemoryAllocationTypes AllocationType, [In] MemoryProtectionConstants PageProtection) =>
            MapViewOfFileNuma2(FileMappingHandle, ProcessHandle, Offset, BaseAddress, ViewSize, AllocationType, PageProtection, NUMA_NO_PREFERRED_NODE);

        /// <summary>
        /// <para>
        /// Maps a view of a file or a pagefile-backed section into the address space of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-mapviewoffilenuma2"/>
        /// </para>
        /// </summary>
        /// <param name="FileMappingHandle">
        /// A <see cref="HANDLE"/> to a section that is to be mapped into the address space of the specified process.
        /// </param>
        /// <param name="ProcessHandle">
        /// A <see cref="HANDLE"/> to a process into which the section will be mapped.
        /// </param>
        /// <param name="Offset">
        /// The offset from the beginning of the section.
        /// This must be 64k aligned.
        /// </param>
        /// <param name="BaseAddress">
        /// The desired base address of the view.
        /// The address is rounded down to the nearest 64k boundary.
        /// If this parameter is <see cref="NULL"/>, the system picks the base address.
        /// </param>
        /// <param name="ViewSize">
        /// The number of bytes to map.
        /// A value of zero (0) specifies that the entire section is to be mapped.
        /// </param>
        /// <param name="AllocationType">
        /// <para>
        /// The type of allocation. This parameter can be zero (0) or one of the following constant values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MEM_RESERVE"/> - Maps a reserved view
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MEM_LARGE_PAGES"/> - Maps a large page view
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="PageProtection">
        /// <para>
        /// The desired page protection.
        /// </para>
        /// <para>
        /// For file-mapping objects created with the <see cref="SEC_IMAGE"/> attribute,
        /// the <paramref name="PageProtection"/> parameter has no effect,
        /// and should be set to any valid value such as <see cref="PAGE_READONLY"/>.
        /// </para>
        /// </param>
        /// <param name="PreferredNode">
        /// The preferred NUMA node for this memory.
        /// </param>
        /// <returns>
        /// Returns the base address of the mapped view, if successful.
        /// Otherwise, returns <see cref="NULL"/> and extended error status is available using <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1703)]
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "MapViewOfFileNuma2", ExactSpelling = true, SetLastError = true)]
        public static extern PVOID MapViewOfFileNuma2([In] HANDLE FileMappingHandle, [In] HANDLE ProcessHandle, [In] ULONG64 Offset,
            [In] PVOID BaseAddress, [In] SIZE_T ViewSize, [In] MemoryAllocationTypes AllocationType,
            [In] MemoryProtectionConstants PageProtection, [In] ULONG PreferredNode);

        /// <summary>
        /// <para>
        /// Maps a view of a file or a pagefile-backed section into the address space of the specified process.
        /// Using this function, you can: for new allocations, specify a range of virtual address space and a power-of-2 alignment restriction;
        /// specify an arbitrary number of extended parameters; specify a preferred NUMA node for the physical memory as an extended parameter;
        /// and specify a placeholder operation (specifically, replacement).
        /// To specify the NUMA node, see the ExtendedParameters parameter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-mapviewoffile3"/>
        /// </para>
        /// </summary>
        /// <param name="FileMapping">
        /// A <see cref="HANDLE"/> to a section that is to be mapped into the address space of the specified process.
        /// </param>
        /// <param name="Process">
        /// A <see cref="HANDLE"/> to a process into which the section will be mapped.
        /// </param>
        /// <param name="BaseAddress">
        /// <para>
        /// The desired base address of the view (the address is rounded down to the nearest 64k boundary).
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the system picks the base address.
        /// </para>
        /// <para>
        /// If <paramref name="BaseAddress"/> is not <see cref="NULL"/>,
        /// then any provided <see cref="MEM_ADDRESS_REQUIREMENTS"/> must consist of all zeroes.
        /// </para>
        /// </param>
        /// <param name="Offset">
        /// <para>
        /// The offset from the beginning of the section.
        /// </para>
        /// <para>
        /// The offset must be 64k aligned or aligned to <see cref="GetLargePageMinimum"/>
        /// when <see cref="MEM_LARGE_PAGES"/> is used in <paramref name="AllocationType"/>.
        /// Furthermore, the offset must be page-aligned to the underlying page size
        /// granted by <see cref="VirtualAlloc2"/> when <see cref="MEM_REPLACE_PLACEHOLDER"/> is used in <paramref name="AllocationType"/>.
        /// </para>
        /// </param>
        /// <param name="ViewSize">
        /// <para>
        /// The number of bytes to map.
        /// A value of zero (0) specifies that the entire section is to be mapped.
        /// </para>
        /// <para>
        /// The size must always be a multiple of the page size.
        /// </para>
        /// </param>
        /// <param name="AllocationType">
        /// <para>
        /// The type of memory allocation.
        /// This parameter can be zero (0) or one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESERVE"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// Maps a reserved view.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_REPLACE_PLACEHOLDER"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Replaces a placeholder with a mapped view. Only data/pf-backed section views are supported (no images, physical memory, etc.).
        /// When you replace a placeholder, <paramref name="BaseAddress"/> and <paramref name="ViewSize"/> must exactly match those of the placeholder,
        /// and any provided <see cref="MEM_ADDRESS_REQUIREMENTS"/> structure must consist of all zeroes.
        /// </para>
        /// <para>
        /// After you replace a placeholder with a mapped view, to free that mapped view back to a placeholder,
        /// see the UnmapFlags parameter of <see cref="UnmapViewOfFileEx"/> and <see cref="UnmapViewOfFile2"/>.
        /// </para>
        /// <para>
        /// A placeholder is a type of reserved memory region.
        /// </para>
        /// <para>
        /// The 64k alignment requirements on <paramref name="Offset"/> and <paramref name="BaseAddress"/> do not apply when this flag is specified.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_LARGE_PAGES"/>
        /// </para>
        /// <para>
        /// 0x20000000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Maps a large page view. This flag specifies that the view should be mapped using large page support.
        /// The size of the view must be a multiple of the size of a large page reported by the <see cref="GetLargePageMinimum"/> function,
        /// and the file-mapping object must have been created using the <see cref="SEC_LARGE_PAGES"/> option.
        /// If you provide a non-null value for the <paramref name="BaseAddress"/> parameter,
        /// then the value must be a multiple of <see cref="GetLargePageMinimum"/>.
        /// </para>
        /// <para>
        /// The 64k alignment requirements on <paramref name="Offset"/> do not apply when this flag is specified.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="PageProtection">
        /// <para>
        /// The desired page protection.
        /// </para>
        /// <para>
        /// For file-mapping objects created with the <see cref="SEC_IMAGE"/> attribute,
        /// the <paramref name="PageProtection"/> parameter has no effect,
        /// and should be set to any valid value such as <see cref="PAGE_READONLY"/>.
        /// </para>
        /// </param>
        /// <param name="ExtendedParameters">
        /// An optional pointer to one or more extended parameters of type <see cref="MEM_EXTENDED_PARAMETER"/>.
        /// Each of those extended parameter values can itself have a <see cref="MEM_EXTENDED_PARAMETER.Type"/> field
        /// of either <see cref="MemExtendedParameterAddressRequirements"/> or <see cref="MemExtendedParameterNumaNode"/>.
        /// If no <see cref="MemExtendedParameterNumaNode"/> extended parameter is provided,
        /// then the behavior is the same as for the <see cref="VirtualAlloc"/>/<see cref="MapViewOfFile"/> functions
        /// (that is, the preferred NUMA node for the physical pages is determined
        /// based on the ideal processor of the thread that first accesses the memory).
        /// </param>
        /// <param name="ParameterCount">
        /// The number of extended parameters pointed to by <paramref name="ExtendedParameters"/>.
        /// </param>
        /// <returns>
        /// Returns the base address of the mapped view, if successful.
        /// Otherwise, returns <see cref="NULL"/> and extended error status is available using <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This API helps support high-performance games, and server applications,
        /// which have particular requirements around managing their virtual address space.
        /// For example, mapping memory on top of a previously reserved region; this is useful for implementing an automatically wrapping ring buffer.
        /// And allocating memory with specific alignment; for example, to enable your application to commit large/huge page-mapped regions on demand.
        /// </para>
        /// <para>
        /// Using this function for new allocations, you can:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// specify a range of virtual address space and a power-of-2 alignment restriction
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// specify an arbitrary number of extended parameters
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// specify a preferred NUMA node for the physical memory as an extended parameter
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// specify a placeholder operation (specifically, replacement).
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To specify the NUMA node, see the <paramref name="ExtendedParameters"/> parameter.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1803)]
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "MapViewOfFile3", ExactSpelling = true, SetLastError = true)]
        public static extern PVOID MapViewOfFile3([In] HANDLE FileMapping, [In] HANDLE Process, [In] PVOID BaseAddress, [In] ULONG64 Offset,
            [In] SIZE_T ViewSize, [In] MemoryAllocationTypes AllocationType, [In] MemoryProtectionConstants PageProtection,
            [In] MEM_EXTENDED_PARAMETER[] ExtendedParameters, [In] ULONG ParameterCount);

        /// <summary>
        /// <para>
        /// Unmaps a previously mapped view of a file or a pagefile-backed section.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-unmapviewoffile2"/>
        /// </para>
        /// </summary>
        /// <param name="Process">
        /// A <see cref="HANDLE"/> to the process from which the section will be unmapped.
        /// </param>
        /// <param name="BaseAddress">
        /// The base address of a previously mapped view that is to be unmapped.
        /// This value must be identical to the value returned by a previous call to <see cref="MapViewOfFile2"/>.
        /// </param>
        /// <param name="UnmapFlags">
        /// <para>
        /// This parameter can be zero (0) or one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_UNMAP_WITH_TRANSIENT_BOOST"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the priority of the pages being unmapped should be temporarily boosted (with automatic short term decay)
        /// because the caller expects that these pages will be accessed again shortly from another thread.
        /// For more information about memory priorities, see the <see cref="SetThreadInformation"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_PRESERVE_PLACEHOLDER"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Unmaps a mapped view back to a placeholder (after you've replaced a placeholder
        /// with a mapped view using <see cref="MapViewOfFile3"/> or <see cref="MapViewOfFile3FromApp"/>).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if sucessful.
        /// Otherwise, returns <see cref="FALSE"/> and extended error status is available using <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1703)]
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "UnmapViewOfFile2", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnmapViewOfFile2([In] HANDLE Process, [In] PVOID BaseAddress, [In] ULONG UnmapFlags);

        /// <summary>
        /// <para>
        /// Reserves, commits, or changes the state of a region of memory within the virtual address space
        /// of a specified process (allocated memory is initialized to zero).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualalloc2"/>
        /// </para>
        /// </summary>
        /// <param name="Process">
        /// <para>
        /// The handle to a process. The function allocates memory within the virtual address space of this process.
        /// </para>
        /// <para>
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// If <paramref name="Process"/> is <see cref="NULL"/>, the function allocates memory for the calling process.
        /// </para>
        /// </param>
        /// <param name="BaseAddress">
        /// <para>
        /// The pointer that specifies a desired starting address for the region of pages that you want to allocate.
        /// </para>
        /// <para>
        /// If <paramref name="BaseAddress"/> is <see cref="NULL"/>, the function determines where to allocate the region.
        /// </para>
        /// <para>
        /// If <paramref name="BaseAddress"/> is not <see cref="NULL"/>,
        /// then any provided <see cref="MEM_ADDRESS_REQUIREMENTS"/> structure must consist of all zeroes,
        /// and the base address must be a multiple of the system allocation granularity.
        /// To determine the allocation granularity, use the <see cref="GetSystemInfo"/> function.
        /// </para>
        /// <para>
        /// If this address is within an enclave that you have not initialized by calling <see cref="InitializeEnclave"/>,
        /// <see cref="VirtualAlloc2"/> allocates a page of zeros for the enclave at that address.
        /// The page must be previously uncommitted, and will not be measured
        /// with the EEXTEND instruction of the Intel Software Guard Extensions programming model.
        /// </para>
        /// <para>
        /// If the address is within an enclave that you initialized,
        /// then the allocation operation fails with the <see cref="ERROR_INVALID_ADDRESS"/> error.
        /// That is true for enclaves that do not support dynamic memory management (i.e. SGX1).
        /// SGX2 enclaves will permit allocation, and the page must be accepted by the enclave after it has been allocated.
        /// </para>
        /// </param>
        /// <param name="Size">
        /// <para>
        /// The size of the region of memory to allocate, in bytes.
        /// </para>
        /// <para>
        /// The size must always be a multiple of the page size.
        /// </para>
        /// <para>
        /// If <paramref name="BaseAddress"/> is not <see cref="NULL"/>, the function allocates all pages
        /// that contain one or more bytes in the range from <paramref name="BaseAddress"/> to <paramref name="BaseAddress"/>+<paramref name="Size"/>.
        /// This means, for example, that a 2-byte range that straddles a page boundary causes the function to allocate both pages.
        /// </para>
        /// </param>
        /// <param name="AllocationType">
        /// <para>
        /// The type of memory allocation. This parameter must contain one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
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
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages.
        /// The function also guarantees that when the caller later initially accesses the memory, the contents will be zero.
        /// Actual physical pages are not allocated unless/until the virtual addresses are actually accessed.
        /// </para>
        /// <para>
        /// To reserve and commit pages in one step, call <see cref="VirtualAlloc2"/> with <c>MEM_COMMIT | MEM_RESERVE</c>.
        /// </para>
        /// <para>
        /// Attempting to commit a specific address range by specifying <see cref="MEM_COMMIT"/> without <see cref="MEM_RESERVE"/>
        /// and a non-<see cref="NULL"/> <paramref name="BaseAddress"/> fails unless the entire range has already been reserved.
        /// The resulting error code is <see cref="ERROR_INVALID_ADDRESS"/>.
        /// </para>
        /// <para>
        /// An attempt to commit a page that is already committed does not cause the function to fail.
        /// This means that you can commit pages without first determining the current commitment state of each page.
        /// </para>
        /// <para>
        /// If <paramref name="BaseAddress"/> specifies an address within an enclave, <paramref name="AllocationType"/> must be <see cref="MEM_COMMIT"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESERVE"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory or in the paging file on disk.
        /// </para>
        /// <para>
        /// You commit reserved pages by calling <see cref="VirtualAlloc2"/> again with <see cref="MEM_COMMIT"/>.
        /// To reserve and commit pages in one step, call <see cref="VirtualAlloc2"/> with .
        /// </para>
        /// <para>
        /// Other memory allocation functions, such as malloc and <see cref="LocalAlloc"/>, cannot use reserved memory until it has been released.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_REPLACE_PLACEHOLDER"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Replaces a placeholder with a normal private allocation.
        /// Only data/pf-backed section views are supported (no images, physical memory, etc.).
        /// When you replace a placeholder, <paramref name="BaseAddress"/> and <paramref name="Size"/> must exactly match those of the placeholder,
        /// and any provided <see cref="MEM_ADDRESS_REQUIREMENTS"/> structure must consist of all zeroes.
        /// </para>
        /// <para>
        /// After you replace a placeholder with a private allocation, to free that allocation back to a placeholder,
        /// see the dwFreeType parameter of <see cref="VirtualFree"/> and <see cref="VirtualFreeEx"/>.
        /// </para>
        /// <para>
        /// A placeholder is a type of reserved memory region.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESERVE_PLACEHOLDER"/>
        /// </para>
        /// <para>
        /// 0x00040000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// To create a placeholder, call <see cref="VirtualAlloc2"/> with <c>MEM_COMMIT | MEM_RESERVE</c>
        /// and <paramref name="PageProtection"/> set to <see cref="PAGE_NOACCESS"/>.
        /// To free/split/coalesce a placeholder, see the dwFreeType parameter of <see cref="VirtualFree"/> and <see cref="VirtualFreeEx"/>.
        /// </para>
        /// <para>
        /// A placeholder is a type of reserved memory region.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESET"/>
        /// </para>
        /// <para>
        /// 0x00080000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Indicates that data in the memory range specified by <paramref name="BaseAddress"/> and <paramref name="Size"/> is no longer of interest.
        /// The pages should not be read from or written to the paging file.
        /// However, the memory block will be used again later, so it should not be decommitted.
        /// This value cannot be used with any other value.
        /// </para>
        /// <para>
        /// Using this value does not guarantee that the range operated on with <see cref="MEM_RESET"/> will contain zeros.
        /// If you want the range to contain zeros, decommit the memory and then recommit it.
        /// </para>
        /// <para>
        /// When you use <see cref="MEM_RESET"/>, the <see cref="VirtualAlloc2"/> function ignores the value of <paramref name="PageProtection"/>.
        /// However, you must still set <paramref name="PageProtection"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// </para>
        /// <para>
        /// <see cref="VirtualAlloc2"/> returns an error if you use <see cref="MEM_RESET"/> and the range of memory is mapped to a file.
        /// A shared view is only acceptable if it is mapped to a paging file.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESET_UNDO"/>
        /// </para>
        /// <para>
        /// 0x1000000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESET_UNDO"/> should only be called on an address range to which <see cref="MEM_RESET"/> was successfully applied earlier.
        /// It indicates that the data in the specified memory range specified by <paramref name="BaseAddress"/> and <paramref name="Size"/>
        /// is of interest to the caller and attempts to reverse the effects of <see cref="MEM_RESET"/>.
        /// If the function succeeds, that means all data in the specified address range is intact.
        /// If the function fails, at least some of the data in the address range has been replaced with zeroes.
        /// </para>
        /// <para>
        /// This value cannot be used with any other value. If <see cref="MEM_RESET_UNDO"/> is called
        /// on an address range which was not <see cref="MEM_RESET"/> earlier, the behavior is undefined.
        /// When you specify <see cref="MEM_RESET"/>, the <see cref="VirtualAlloc2"/> function ignores the value of <paramref name="PageProtection"/>.
        /// However, you must still set <paramref name="PageProtection"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// </para>
        /// <para>
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// The <see cref="MEM_RESET_UNDO"/> flag is not supported until Windows 8 and Windows Server 2012.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This parameter can also specify the following values as indicated.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_LARGE_PAGES"/>
        /// </para>
        /// <para>
        /// 0x20000000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Allocates memory using large page support.
        /// </para>
        /// <para>
        /// The size and alignment must be a multiple of the large-page minimum.
        /// To obtain this value, use the <see cref="GetLargePageMinimum"/> function.
        /// </para>
        /// <para>
        /// If you specify this value, you must also specify <see cref="MEM_RESERVE"/> and <see cref="MEM_COMMIT"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_64K_PAGES"/>
        /// </para>
        /// <para>
        /// 0x20400000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// A hint to the operating system to map the memory using 64K pages, if possible.
        /// </para>
        /// <para>
        /// A 64K page is a region of memory that is 64K in size, virtually and physically contiguous,
        /// and virtually and physically aligned on a 64K boundary.
        /// </para>
        /// <para>
        /// By default, memory allocated using <see cref="MEM_64K_PAGES"/> is pageable,
        /// and physical pages backing the memory are allocated on demand (at the time of access).
        /// If physical memory is too fragmented to assemble a physically contiguous 64K page,
        /// all or part of a <see cref="MEM_64K_PAGES"/> allocation may be mapped using non-contiguous small pages instead.
        /// </para>
        /// <para>
        /// If <see cref="MEM_64K_PAGES"/> is combined with the <see cref="MEM_EXTENDED_PARAMETER_NONPAGED"/> attribute,
        /// the allocation will be mapped using non-paged 64K pages.
        /// In that case, if contiguous 64K pages cannot be obtained, the allocation will fail.
        /// </para>
        /// <para>
        /// If <see cref="MEM_64K_PAGES"/> is specified, the <paramref name="Size"/> and <paramref name="BaseAddress"/> parameters
        /// must both be multiples of 64K (<paramref name="BaseAddress"/> may be <see cref="NULL"/>).
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_PHYSICAL"/>
        /// </para>
        /// <para>
        /// 0x00400000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.
        /// </para>
        /// <para>
        /// This value must be used with <see cref="MEM_RESERVE"/> and no other values.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_TOP_DOWN"/>
        /// </para>
        /// <para>
        /// 0x00100000
        /// </para>
        /// </term>
        /// <term>
        /// Allocates memory at the highest possible address.
        /// This can be slower than regular allocations, especially when there are many allocations.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="PageProtection">
        /// <para>
        /// The memory protection for the region of pages to be allocated.
        /// If the pages are being committed, you can specify any one of the memory protection constants.
        /// </para>
        /// <para>
        /// If <paramref name="BaseAddress"/> specifies an address within an enclave,
        /// <paramref name="PageProtection"/> cannot be any of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="PAGE_NOACCESS"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PAGE_GUARD"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PAGE_NOCACHE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PAGE_WRITECOMBINE"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When allocating dynamic memory for an enclave, the <paramref name="PageProtection"/> parameter
        /// must be <see cref="PAGE_READWRITE"/> or <see cref="PAGE_EXECUTE_READWRITE"/>.
        /// </para>
        /// </param>
        /// <param name="ExtendedParameters">
        /// An optional pointer to one or more extended parameters of type <see cref="MEM_EXTENDED_PARAMETER"/>.
        /// Each of those extended parameter values can itself have a <see cref="MEM_EXTENDED_PARAMETER.Type"/> field
        /// of either <see cref="MemExtendedParameterAddressRequirements"/> or <see cref="MemExtendedParameterNumaNode"/>.
        /// If no <see cref="MemExtendedParameterNumaNode"/> extended parameter is provided,
        /// then the behavior is the same as for the <see cref="VirtualAlloc"/>/<see cref="MapViewOfFile"/> functions
        /// (that is, the preferred NUMA node for the physical pages is determined
        /// based on the ideal processor of the thread that first accesses the memory).
        /// </param>
        /// <param name="ParameterCount">
        /// The number of extended parameters pointed to by <paramref name="ExtendedParameters"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the base address of the allocated region of pages.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function lets you specify:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// a range of virtual address space and a power-of-2 alignment restriction for new allocations
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// an arbitrary number of extended parameters
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// a preferred NUMA node for the physical memory as an extended parameter (see the <paramref name="ExtendedParameters"/> parameter)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// a placeholder operation (specifically, replacement).
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This API provides specialized techniques for managing virtual memory in support of high-performance games and server applications.
        /// For example, placeholders allow a reserved memory range to be explicitly partitioned, overlaid, and re-mapped;
        /// this can be used to implement arbitrarily extendable regions or virtual memory ring buffers.
        /// <see cref="VirtualAlloc2"/> also allows for allocating memory with a specific memory-alignment.
        /// </para>
        /// <para>
        /// Each page has an associated page state. The <see cref="VirtualAlloc2"/> function can perform the following operations:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Commit a region of reserved pages
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Reserve a region of free pages
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Simultaneously reserve and commit a region of free pages
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="VirtualAlloc2"/> can commit pages that are already committed, but cannot reserve pages that are already reserved.
        /// This means you can commit a range of pages, regardless of whether they have already been committed, and the function will not fail.
        /// In general however, only a minimal range of mostly uncommitted pages should be specified,
        /// because committing a large number of pages that are already committed can cause the <see cref="VirtualAlloc2"/> call to take much longer.
        /// </para>
        /// <para>
        /// You can use <see cref="VirtualAlloc2"/> to reserve a block of pages
        /// and then make additional calls to <see cref="VirtualAlloc2"/> to commit individual pages from the reserved block.
        /// This enables a process to reserve a range of its virtual address space without consuming physical storage until it is needed.
        /// </para>
        /// <para>
        /// If the <paramref name="BaseAddress"/> parameter is not <see cref="NULL"/>,
        /// the function uses the <paramref name="BaseAddress"/> and <paramref name="Size"/> parameters to compute the region of pages to be allocated.
        /// The current state of the entire range of pages must be compatible with the type of allocation
        /// specified by the <paramref name="AllocationType"/> parameter.
        /// Otherwise, the function fails and none of the pages is allocated.
        /// This compatibility requirement does not preclude committing an already committed page; see the preceding list.
        /// </para>
        /// <para>
        /// To execute dynamically generated code, use <see cref="VirtualAlloc2"/> to allocate memory,
        /// and the <see cref="VirtualProtectEx"/> function to grant <see cref="PAGE_EXECUTE"/> access.
        /// </para>
        /// <para>
        /// The <see cref="VirtualAlloc2"/> function can be used to reserve an Address Windowing Extensions (AWE) region
        /// of memory within the virtual address space of a specified process.
        /// This region of memory can then be used to map physical pages into and out of virtual memory as required by the application.
        /// The <see cref="MEM_PHYSICAL"/> and <see cref="MEM_RESERVE"/> values must be set in the <paramref name="AllocationType"/> parameter.
        /// The <see cref="MEM_COMMIT"/> value must not be set.
        /// The page protection must be set to <see cref="PAGE_READWRITE"/>.
        /// </para>
        /// <para>
        /// The <see cref="VirtualFreeEx"/> function can decommit a committed page, releasing the page's storage,
        /// or it can simultaneously decommit and release a committed page.
        /// It can also release a reserved page, making it a free page.
        /// </para>
        /// <para>
        /// When creating a region that will be executable, the calling program bears responsibility
        /// for ensuring cache coherency via an appropriate call to <see cref="FlushInstructionCache"/> once the code has been set in place.
        /// Otherwise attempts to execute code out of the newly executable region may produce unpredictable results.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows10)]
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualAlloc2", ExactSpelling = true, SetLastError = true)]
        public static extern PVOID VirtualAlloc2([In] HANDLE Process, [In] PVOID BaseAddress, [In] SIZE_T Size,
            [In] MemoryAllocationTypes AllocationType, [In] MemoryProtectionConstants PageProtection,
            [In][Out] MEM_EXTENDED_PARAMETER[]? ExtendedParameters, [In] ULONG ParameterCount);

        /// <summary>
        /// <para>
        /// Reserves, commits, or changes the state of a region of pages in the virtual address space of the calling process.
        /// Memory allocated by this function is automatically initialized to zero.
        /// </para>
        /// <para>
        /// Using this function, you can: for new allocations, specify a range of virtual address space and a power-of-2 alignment restriction;
        /// specify an arbitrary number of extended parameters; specify a preferred NUMA node for the physical memory as an extended parameter;
        /// and specify a placeholder operation (specifically, replacement).
        /// </para>
        /// <para>
        /// To specify the NUMA node, see the <paramref name="ExtendedParameters"/> parameter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualalloc2fromapp"/>
        /// </para>
        /// </summary>
        /// <param name="Process">
        /// <para>
        /// The handle to a process.
        /// </para>
        /// <para>
        /// The function allocates memory within the virtual address space of this process.
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="BaseAddress">
        /// <para>
        /// The pointer that specifies a desired starting address for the region of pages that you want to allocate.
        /// </para>
        /// <para>
        /// If <paramref name="BaseAddress"/> is <see cref="NULL"/>, the function determines where to allocate the region.
        /// </para>
        /// <para>
        /// If <paramref name="BaseAddress"/> is not <see cref="NULL"/>,
        /// then any provided <see cref="MEM_ADDRESS_REQUIREMENTS"/> structure must consist of all zeroes,
        /// and the base address must be a multiple of the system allocation granularity.
        /// To determine the allocation granularity, use the <see cref="GetSystemInfo"/> function.
        /// </para>
        /// </param>
        /// <param name="Size">
        /// <para>
        /// The size of the region of memory to allocate, in bytes.
        /// </para>
        /// <para>
        /// The size must always be a multiple of the page size.
        /// </para>
        /// <para>
        /// If <paramref name="BaseAddress"/> is not <see cref="NULL"/>,
        /// the function allocates all pages  that contain one or more bytes
        /// in the range from <paramref name="BaseAddress"/> to <paramref name="BaseAddress"/>+<paramref name="Size"/>.
        /// This means, for example, that a 2-byte range that straddles a page boundary causes the function to allocate both pages.
        /// </para>
        /// </param>
        /// <param name="AllocationType">
        /// <para>
        /// The type of memory allocation. This parameter must contain one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
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
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages.
        /// The function also guarantees that when the caller later initially accesses the memory, the contents will be zero.
        /// Actual physical pages are not allocated unless/until the virtual addresses are actually accessed.
        /// </para>
        /// <para>
        /// To reserve and commit pages in one step, call <see cref="VirtualAlloc2FromApp"/> with <c>MEM_COMMIT | MEM_RESERVE</c>.
        /// </para>
        /// <para>
        /// Attempting to commit a specific address range by specifying <see cref="MEM_COMMIT"/> without <see cref="MEM_RESERVE"/>
        /// and a non-<see cref="NULL"/> <paramref name="BaseAddress"/> fails unless the entire range has already been reserved.
        /// The resulting error code is <see cref="ERROR_INVALID_ADDRESS"/>.
        /// </para>
        /// <para>
        /// An attempt to commit a page that is already committed does not cause the function to fail.
        /// This means that you can commit pages without first determining the current commitment state of each page.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESERVE"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Reserves a range of the process's virtual address space
        /// without allocating any actual physical storage in memory or in the paging file on disk.
        /// </para>
        /// <para>
        /// You can commit reserved pages in subsequent calls to the <see cref="VirtualAlloc2FromApp"/> function.
        /// To reserve and commit pages in one step, call <see cref="VirtualAlloc2FromApp"/> with <see cref="MEM_COMMIT"/> | <see cref="MEM_RESERVE"/>.
        /// </para>
        /// <para>
        /// Other memory allocation functions, such as malloc and <see cref="LocalAlloc"/>, cannot use a reserved range of memory until it is released.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_REPLACE_PLACEHOLDER"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Replaces a placeholder with a normal private allocation.
        /// Only data/pf-backed section views are supported (no images, physical memory, etc.).
        /// When you replace a placeholder, <paramref name="BaseAddress"/> and <paramref name="Size"/> must exactly match those of the placeholder
        /// , and any provided <see cref="MEM_ADDRESS_REQUIREMENTS"/> structure must consist of all zeroes.
        /// </para>
        /// <para>
        /// After you replace a placeholder with a private allocation, to free that allocation back to a placeholder,
        /// see the dwFreeType parameter of <see cref="VirtualFree"/> and <see cref="VirtualFreeEx"/>.
        /// </para>
        /// <para>
        /// A placeholder is a type of reserved memory region.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESERVE_PLACEHOLDER"/>
        /// </para>
        /// <para>
        /// 0x00040000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// To create a placeholder, call <see cref="VirtualAlloc2"/> with <c>MEM_RESERVE | MEM_RESERVE_PLACEHOLDER</c>
        /// and <paramref name="PageProtection"/> set to <see cref="PAGE_NOACCESS"/>.
        /// To free/split/coalesce a placeholder, see the dwFreeType parameter of <see cref="VirtualFree"/> and <see cref="VirtualFreeEx"/>.
        /// </para>
        /// <para>
        /// A placeholder is a type of reserved memory region.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESET"/>
        /// </para>
        /// <para>
        /// 0x00080000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Indicates that data in the memory range specified by <paramref name="BaseAddress"/> and <paramref name="Size"/> is no longer of interest.
        /// The pages should not be read from or written to the paging file.
        /// However, the memory block will be used again later, so it should not be decommitted.
        /// This value cannot be used with any other value.
        /// </para>
        /// <para>
        /// Using this value does not guarantee that the range operated on with <see cref="MEM_RESET"/> will contain zeros.
        /// If you want the range to contain zeros, decommit the memory and then recommit it.
        /// </para>
        /// <para>
        /// When you specify <see cref="MEM_RESET"/>,
        /// the <see cref="VirtualAlloc2FromApp"/> function ignores the value of <paramref name="PageProtection"/>.
        /// However, you must still set <paramref name="PageProtection"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// </para>
        /// <para>
        /// <see cref="VirtualAlloc2FromApp"/> returns an error if you use <see cref="MEM_RESET"/> and the range of memory is mapped to a file.
        /// A shared view is only acceptable if it is mapped to a paging file.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESET_UNDO"/>
        /// </para>
        /// <para>
        /// 0x1000000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="MEM_RESET_UNDO"/> should only be called on an address range to which <see cref="MEM_RESET"/> was successfully applied earlier.
        /// It indicates that the data in the specified memory range specified by <paramref name="BaseAddress"/> and <paramref name="Size"/>
        /// is of interest to the caller and attempts to reverse the effects of <see cref="MEM_RESET"/>.
        /// If the function succeeds, that means all data in the specified address range is intact.
        /// If the function fails, at least some of the data in the address range has been replaced with zeroes.
        /// </para>
        /// <para>
        /// This value cannot be used with any other value.
        /// If <see cref="MEM_RESET_UNDO"/> is called on an address range which was not <see cref="MEM_RESET"/> earlier, the behavior is undefined.
        /// When you specify <see cref="MEM_RESET"/>, the <see cref="VirtualAlloc2FromApp"/> function ignores the value of <paramref name="PageProtection"/>.
        /// However, you must still set <paramref name="PageProtection"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This parameter can also specify the following values as indicated.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_LARGE_PAGES"/>
        /// </para>
        /// <para>
        /// 0x20000000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Allocates memory using large page support.
        /// </para>
        /// <para>
        /// The size and alignment must be a multiple of the large-page minimum.
        /// To obtain this value, use the <see cref="GetLargePageMinimum"/> function.
        /// </para>
        /// <para>
        /// If you specify this value, you must also specify <see cref="MEM_RESERVE"/> and <see cref="MEM_COMMIT"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_PHYSICAL"/>
        /// </para>
        /// <para>
        /// 0x00400000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.
        /// </para>
        /// <para>
        /// This value must be used with <see cref="MEM_RESERVE"/> and no other values.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_TOP_DOWN"/>
        /// </para>
        /// <para>
        /// 0x00100000
        /// </para>
        /// </term>
        /// <term>
        /// Allocates memory at the highest possible address.
        /// This can be slower than regular allocations, especially when there are many allocations.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MEM_WRITE_WATCH"/>
        /// </para>
        /// <para>
        /// 0x00200000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Causes the system to track pages that are written to in the allocated region.
        /// If you specify this value, you must also specify <see cref="MEM_RESERVE"/>.
        /// </para>
        /// <para>
        /// To retrieve the addresses of the pages that have been written to
        /// since the region was allocated or the write-tracking state was reset, call the <see cref="GetWriteWatch"/> function.
        /// To reset the write-tracking state, call <see cref="GetWriteWatch"/> or <see cref="ResetWriteWatch"/>.
        /// The write-tracking feature remains enabled for the memory region until the region is freed.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="PageProtection">
        /// <para>
        /// The memory protection for the region of pages to be allocated.
        /// If the pages are being committed, you can specify one of the memory protection constants.
        /// The following constants generate an error:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="PAGE_EXECUTE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PAGE_EXECUTE_READ"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PAGE_EXECUTE_READWRITE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="ExtendedParameters">
        /// An optional pointer to one or more extended parameters of type <see cref="MEM_EXTENDED_PARAMETER"/>.
        /// Each of those extended parameter values can itself have a <see cref="MEM_EXTENDED_PARAMETER.Type"/> field
        /// of either <see cref="MemExtendedParameterAddressRequirements"/> or <see cref="MemExtendedParameterNumaNode"/>.
        /// If no <see cref="MemExtendedParameterNumaNode"/> extended parameter is provided,
        /// then the behavior is the same as for the <see cref="VirtualAlloc"/>/<see cref="MapViewOfFile"/> functions
        /// (that is, the preferred NUMA node for the physical pages is determined based on the ideal processor
        /// of the thread that first accesses the memory).
        /// </param>
        /// <param name="ParameterCount">
        /// The number of extended parameters pointed to by <paramref name="ExtendedParameters"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the base address of the allocated region of pages.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>. To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This API helps support high-performance games, and server applications,
        /// which have particular requirements around managing their virtual address space.
        /// For example, mapping memory on top of a previously reserved region; this is useful for implementing an automatically wrapping ring buffer.
        /// And allocating memory with specific alignment; for example, to enable your application to commit large/huge page-mapped regions on demand.
        /// </para>
        /// <para>
        /// You can call <see cref="VirtualAlloc2FromApp"/> from Windows Store apps with just-in-time (JIT) capabilities to use JIT functionality.
        /// The app must include the codeGeneration capability in the app manifest file to use JIT capabilities.
        /// </para>
        /// <para>
        /// Each page has an associated page state. The <see cref="VirtualAlloc2FromApp"/> function can perform the following operations:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Commit a region of reserved pages
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Reserve a region of free pages
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Simultaneously reserve and commit a region of free pages
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="VirtualAlloc2FromApp"/> cannot reserve a reserved page.
        /// It can commit a page that is already committed. This means you can commit a range of pages,
        /// regardless of whether they have already been committed, and the function will not fail.
        /// </para>
        /// <para>
        /// You can use <see cref="VirtualAlloc2FromApp"/> to reserve a block of pages
        /// and then make additional calls to <see cref="VirtualAlloc2FromApp"/> to commit individual pages from the reserved block.
        /// This enables a process to reserve a range of its virtual address space without consuming physical storage until it is needed.
        /// </para>
        /// <para>
        /// If the <paramref name="BaseAddress"/> parameter is not <see cref="NULL"/>,
        /// the function uses the <paramref name="BaseAddress"/> and <paramref name="Size"/> parameters
        /// to compute the region of pages to be allocated.
        /// The current state of the entire range of pages must be compatible
        /// with the type of allocation specified by the <paramref name="AllocationType"/> parameter.
        /// Otherwise, the function fails and none of the pages are allocated.
        /// This compatibility requirement does not preclude committing an already committed page, as mentioned previously.
        /// </para>
        /// <para>
        /// <see cref="VirtualAlloc2FromApp"/> does not allow the creation of executable pages.
        /// </para>
        /// <para>
        /// The <see cref="VirtualAlloc2FromApp"/> function can be used to reserve
        /// an Address Windowing Extensions (AWE) region of memory within the virtual address space of a specified process.
        /// This region of memory can then be used to map physical pages into and out of virtual memory as required by the application.
        /// The <see cref="MEM_PHYSICAL"/> and <see cref="MEM_RESERVE"/> values must be set in the <paramref name="AllocationType"/> parameter.
        /// The <see cref="MEM_COMMIT"/> value must not be set.
        /// The page protection must be set to <see cref="PAGE_READWRITE"/>.
        /// </para>
        /// <para>
        /// The <see cref="VirtualFree"/> function can decommit a committed page, releasing the page's storage,
        /// or it can simultaneously decommit and release a committed page.
        /// It can also release a reserved page, making it a free page.
        /// </para>
        /// <para>
        /// When creating a region that will be executable, the calling program bears responsibility
        /// for ensuring cache coherency via an appropriate call to <see cref="FlushInstructionCache"/> once the code has been set in place.
        /// Otherwise attempts to execute code out of the newly executable region may produce unpredictable results.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows10)]
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualAlloc2FromApp", ExactSpelling = true, SetLastError = true)]
        public static extern PVOID VirtualAlloc2FromApp([In] HANDLE Process, [In] PVOID BaseAddress, [In] SIZE_T Size, [In] MemoryAllocationTypes AllocationType,
            [In] MemoryProtectionConstants PageProtection, [In] MEM_EXTENDED_PARAMETER[] ExtendedParameters, [In] ULONG ParameterCount);

        /// <summary>
        /// <para>
        /// Waits for the value at the specified address to change.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-waitonaddress"/>
        /// </para>
        /// </summary>
        /// <param name="Address">
        /// The address on which to wait.
        /// If the value at <paramref name="Address"/> differs from the value at <paramref name="CompareAddress"/>, the function returns immediately.
        /// If the values are the same, the function does not return until another thread in the same process signals that
        /// the value at <paramref name="Address"/> has changed by calling <see cref="WakeByAddressSingle"/> or <see cref="WakeByAddressAll"/>
        /// or the timeout elapses, whichever comes first.
        /// </param>
        /// <param name="CompareAddress">
        /// A pointer to the location of the previously observed value at <paramref name="Address"/>.
        /// The function returns when the value at Address differs from the value at <paramref name="CompareAddress"/>.
        /// </param>
        /// <param name="AddressSize">
        /// The size of the value, in bytes.
        /// This parameter can be 1, 2, 4, or 8.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The number of milliseconds to wait before the operation times out.
        /// If this parameter is <see cref="INFINITE"/>, the thread waits indefinitely.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the wait succeeded.
        /// If the operation fails, the function returns <see cref="FALSE"/>.
        /// If the wait fails, call <see cref="GetLastError"/> to obtain extended error information.
        /// In particular, if the operation times out, <see cref="GetLastError"/> returns <see cref="ERROR_TIMEOUT"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Microsoft Store app developers may need to obtain <c>synchronization.lib</c> by installing the Windows Software Development Kit (SDK).
        /// </para>
        /// <para>
        /// The <see cref="WaitOnAddress"/> function can be used by a thread to wait for a particular value
        /// to change from some undesired value to any other value.
        /// <see cref="WaitOnAddress"/> is more efficient than using the <see cref="Sleep"/> function inside a <c>while </c> loop
        /// because <see cref="WaitOnAddress"/> does not interfere with the thread scheduler.
        /// <see cref="WaitOnAddress"/> is also simpler to use than an event object
        /// because it is not necessary to create and initialize an event and then make sure it is synchronized correctly with the value.
        /// <see cref="WaitOnAddress"/> is not affected by low-memory conditions, other than potentially waking the thread early as noted below.
        /// </para>
        /// <para>
        /// Any thread within the same process that changes the value at the address on which threads are waiting
        /// should call <see cref="WakeByAddressSingle"/> to wake a single waiting thread or <see cref="WakeByAddressAll"/> to wake all waiting threads.
        /// If <see cref="WakeByAddressSingle"/> is called, other waiting threads continue to wait.
        /// </para>
        /// <para>
        /// Note: <see cref="WaitOnAddress"/> is guaranteed to return when the address is signaled, but it is also allowed to return for other reasons.
        /// For this reason, after <see cref="WaitOnAddress"/> returns the caller should
        /// compare the new value with the original undesired value to confirm that the value has actually changed.
        /// For example, the following circumstances can result in waking the thread early:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Low memory conditions
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A previous wake on the same address was abandoned
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Executing code on a checked build of the operating system
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitOnAddress", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WaitOnAddress([In] PVOID Address, [In] PVOID CompareAddress, [In] SIZE_T AddressSize, [In] DWORD dwMilliseconds);

        /// <summary>
        /// <para>
        /// Wakes all threads that are waiting for the value of an address to change.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-wakebyaddressall"/>
        /// </para>
        /// </summary>
        /// <param name="Address">
        /// The address to signal.
        /// If any threads have previously called <see cref="WaitOnAddress"/> for this address, the system wakes all of the waiting threads.
        /// </param>
        /// <remarks>
        /// <para>
        /// Microsoft Store app developers may need to obtain <c>synchronization.lib</c> by installing the Windows Software Development Kit (SDK).
        /// </para>
        /// <para>
        /// Only threads within the same process can be woken.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "WakeByAddressAll", ExactSpelling = true)]
        public static extern void WakeByAddressAll([In] PVOID Address);

        /// <summary>
        /// <para>
        /// Wakes one thread that is waiting for the value of an address to change.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-wakebyaddresssingle"/>
        /// </para>
        /// </summary>
        /// <param name="Address">
        /// The address to signal.
        /// If another thread has previously called <see cref="WaitOnAddress"/> for this address, the system wakes the waiting thread.
        /// If multiple threads are waiting for this address, the system wakes the first thread to wait.
        /// </param>
        /// <remarks>
        /// <para>
        /// Microsoft Store app developers may need to obtain <c>synchronization.lib</c> by installing the Windows Software Development Kit (SDK).
        /// </para>
        /// <para>
        /// Only threads within the same process can be woken.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "WakeByAddressSingle", ExactSpelling = true)]
        public static extern void WakeByAddressSingle([In] PVOID Address);
    }
}
