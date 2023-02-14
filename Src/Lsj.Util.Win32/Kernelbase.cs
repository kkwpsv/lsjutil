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
        /// a call to <code>CompareObjectHandles (GetCurrentProcess (), hProcess)</code>  can be used to determine if hProcess refers to the current process.
        /// Notably, this does not require the use of object-specific access rights, whereas in this example,
        /// calling <see cref="GetProcessId"/> to check the process IDs of two process handles imposes a requirement
        /// that the handles grant <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access.
        /// However it is legal for a process handle to not have that access right granted depending on how the handle is intended to be used.
        /// </remarks>
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "CompareObjectHandles", ExactSpelling = true, SetLastError = true)]
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
        /// The type of allocation. This parameter can be zero (0) or one of the following constant values:
        /// <see cref="MEM_RESERVE"/> - Maps a reserved view.
        /// <see cref="MEM_LARGE_PAGES"/> - Maps a large page view. This flag specifies that the view should be mapped using large page support.
        /// The size of the view must be a multiple of the size of a large page reported by the <see cref="GetLargePageMinimum"/> function,
        /// and the file-mapping object must have been created using the <see cref="SEC_LARGE_PAGES"/> option.
        /// If you provide a non-null value for the <paramref name="BaseAddress"/> parameter,
        /// then the value must be a multiple of <see cref="GetLargePageMinimum"/>.
        /// </param>
        /// <param name="PageProtection">
        /// The desired page protection.
        /// For file-mapping objects created with the <see cref="SEC_IMAGE"/> attribute,
        /// the <paramref name="PageProtection"/> parameter has no effect, and should be set to any valid value such as <see cref="PAGE_READONLY"/>.
        /// </param>
        /// <returns>
        /// Returns the base address of the mapped view, if successful.
        /// Otherwise, returns <see cref="NULL"/> and extended error status is available using <see cref="GetLastError"/>.
        /// </returns>
        public static PVOID MapViewOfFile2([In] HANDLE FileMappingHandle, [In] HANDLE ProcessHandle, [In] ULONG64 Offset,
            [In] PVOID BaseAddress, [In] SIZE_T ViewSize, [In] MemoryAllocationTypes AllocationType, [In] MemoryProtectionConstants PageProtection) =>
            MapViewOfFileNuma2(FileMappingHandle, ProcessHandle, Offset, BaseAddress, ViewSize, AllocationType, PageProtection, 0);

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
        /// The type of allocation.
        /// This parameter can be zero (0) or one of the following constant values:
        /// <see cref="MEM_RESERVE"/>: Maps a reserved view
        /// <see cref="MEM_LARGE_PAGES"/>: Maps a large page view
        /// </param>
        /// <param name="PageProtection">
        /// The desired page protection.
        /// For file-mapping objects created with the <see cref="SEC_IMAGE"/> attribute,
        /// the <paramref name="PageProtection"/> parameter has no effect,
        /// and should be set to any valid value such as <see cref="PAGE_READONLY"/>.
        /// </param>
        /// <param name="PreferredNode">
        /// The preferred NUMA node for this memory.
        /// </param>
        /// <returns>
        /// Returns the base address of the mapped view, if successful.
        /// Otherwise, returns <see cref="NULL"/> and extended error status is available using <see cref="GetLastError"/>.
        /// </returns>
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
        /// The desired base address of the view.
        /// The address is rounded down to the nearest 64k boundary.
        /// If this parameter is <see cref="NULL"/>, the system picks the base address.
        /// </param>
        /// <param name="Offset">
        /// The offset from the beginning of the section.
        /// This must be 64k aligned.
        /// </param>
        /// <param name="ViewSize">
        /// The number of bytes to map.
        /// A value of zero (0) specifies that the entire section is to be mapped.
        /// The size must always be a multiple of the page size.
        /// </param>
        /// <param name="AllocationType">
        /// The type of memory allocation. This parameter can be zero (0) or one of the following values.
        /// <see cref="MEM_RESERVE"/>: Maps a reserved view.
        /// <see cref="MEM_REPLACE_PLACEHOLDER"/>:
        /// Replaces a placeholder with a mapped view. Only data/pf-backed section views are supported (no images, physical memory, etc.).
        /// When you replace a placeholder, <paramref name="BaseAddress"/> and <paramref name="ViewSize"/> must exactly match those of the placeholder.
        /// After you replace a placeholder with a mapped view, to free that mapped view back to a placeholder,
        /// see the UnmapFlags parameter of <see cref="UnmapViewOfFileEx"/> and <see cref="UnmapViewOfFile2"/>.
        /// A placeholder is a type of reserved memory region.
        /// <see cref="MEM_LARGE_PAGES"/>:
        /// Maps a large page view.
        /// This flag specifies that the view should be mapped using large page support.
        /// The size of the view must be a multiple of the size of a large page reported by the <see cref="GetLargePageMinimum"/> function,
        /// and the file-mapping object must have been created using the <see cref="SEC_LARGE_PAGES"/> option.
        /// If you provide a non-null value for the <paramref name="BaseAddress"/> parameter,
        /// then the value must be a multiple of <see cref="GetLargePageMinimum"/>. 
        /// </param>
        /// <param name="PageProtection">
        /// The desired page protection.
        /// For file-mapping objects created with the <see cref="SEC_IMAGE"/> attribute,
        /// the <paramref name="PageProtection"/> parameter has no effect, and should be set to any valid value such as <see cref="PAGE_READONLY"/>.
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
        /// This API helps support high-performance games, and server applications,
        /// which have particular requirements around managing their virtual address space.
        /// For example, mapping memory on top of a previously reserved region; this is useful for implementing an automatically wrapping ring buffer.
        /// And allocating memory with specific alignment; for example, to enable your application to commit large/huge page-mapped regions on demand.
        /// </remarks>
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
        /// This parameter can be zero (0) or one of the following values.
        /// <see cref="MEM_UNMAP_WITH_TRANSIENT_BOOST"/>:
        /// Specifies that the priority of the pages being unmapped should be temporarily boosted (with automatic short term decay)
        /// because the caller expects that these pages will be accessed again shortly from another thread.
        /// For more information about memory priorities, see the <code>SetThreadInformation(ThreadMemoryPriority)</code> function.
        /// <see cref="MEM_PRESERVE_PLACEHOLDER"/>:
        /// Unmaps a mapped view back to a placeholder (after you've replaced a placeholder with a mapped view
        /// using <see cref="MapViewOfFile2"/> or MapViewOfFile2FromApp).
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if sucessful.
        /// Otherwise, returns <see cref="FALSE"/> and extended error status is available using <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "UnmapViewOfFile2", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnmapViewOfFile2([In] HANDLE Process, [In] PVOID BaseAddress, [In] ULONG UnmapFlags);

        /// <summary>
        /// <para>
        /// Reserves, commits, or changes the state of a region of memory within the virtual address space of a specified process.
        /// The function initializes the memory it allocates to zero.
        /// Using this function, you can: for new allocations, specify a range of virtual address space and a power-of-2 alignment restriction;
        /// specify an arbitrary number of extended parameters; specify a preferred NUMA node for the physical memory as an extended parameter;
        /// and specify a placeholder operation (specifically, replacement).
        /// To specify the NUMA node, see the <paramref name="ExtendedParameters"/> parameter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualalloc2"/>
        /// </para>
        /// </summary>
        /// <param name="Process">
        /// The handle to a process.
        /// The function allocates memory within the virtual address space of this process.
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="BaseAddress">
        /// The pointer that specifies a desired starting address for the region of pages that you want to allocate.
        /// If an explicit base address is specified, then it must be a multiple of the system allocation granularity.
        /// To determine the size of a page and the allocation granularity on the host computer, use the <see cref="GetSystemInfo"/> function.
        /// If <paramref name="BaseAddress"/> is <see cref="NULL"/>, the function determines where to allocate the region.
        /// If this address is within an enclave that you have not initialized by calling <see cref="InitializeEnclave"/>,
        /// <see cref="VirtualAlloc2"/> allocates a page of zeros for the enclave at that address.
        /// The page must be previously uncommitted, and will not be measured with the EEXTEND instruction
        /// of the Intel Software Guard Extensions programming model.
        /// If the address in within an enclave that you initialized,
        /// then the allocation operation fails with the <see cref="ERROR_INVALID_ADDRESS"/> error.
        /// </param>
        /// <param name="Size">
        /// The size of the region of memory to allocate, in bytes.
        /// The size must always be a multiple of the page size.
        /// If <paramref name="BaseAddress"/> is not <see cref="NULL"/>, the function allocates all pages that contain one or more bytes
        /// in the range from <paramref name="BaseAddress"/> to <paramref name="BaseAddress"/>+<paramref name="Size"/>.
        /// This means, for example, that a 2-byte range that straddles a page boundary causes the function to allocate both pages.
        /// </param>
        /// <param name="AllocationType">
        /// The type of memory allocation. This parameter must contain one of the following values.
        /// <see cref="MEM_COMMIT"/>:
        /// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages.
        /// The function also guarantees that when the caller later initially accesses the memory, the contents will be zero.
        /// Actual physical pages are not allocated unless/until the virtual addresses are actually accessed.
        /// To reserve and commit pages in one step, call <see cref="VirtualAlloc2"/> with <code>MEM_COMMIT | MEM_RESERVE</code>.
        /// Attempting to commit a specific address range by specifying <see cref="MEM_COMMIT"/> without <see cref="MEM_RESERVE"/>
        /// and a non-NULL <paramref name="BaseAddress"/> fails unless the entire range has already been reserved.
        /// The resulting error code is <see cref="ERROR_INVALID_ADDRESS"/>.
        /// An attempt to commit a page that is already committed does not cause the function to fail.
        /// This means that you can commit pages without first determining the current commitment state of each page.
        /// If <paramref name="BaseAddress"/> specifies an address within an enclave, <paramref name="AllocationType"/> must be <see cref="MEM_COMMIT"/>.
        /// <see cref="MEM_RESERVE"/>:
        /// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory
        /// or in the paging file on disk.
        /// You commit reserved pages by calling <see cref="VirtualAlloc2"/> again with <see cref="MEM_COMMIT"/>.
        /// To reserve and commit pages in one step, call <see cref="VirtualAlloc2"/> with <code>MEM_COMMIT | MEM_RESERVE</code>.
        /// Other memory allocation functions, such as malloc and <see cref="LocalAlloc"/>, cannot use reserved memory until it has been released.
        /// <see cref="MEM_REPLACE_PLACEHOLDER"/>:
        /// Replaces a placeholder with a normal private allocation.
        /// Only data/pf-backed section views are supported (no images, physical memory, etc.).
        /// When you replace a placeholder, <paramref name="BaseAddress"/> and <paramref name="Size"/> must exactly match those of the placeholder.
        /// After you replace a placeholder with a private allocation, to free that allocation back to a placeholder,
        /// see the dwFreeType parameter of <see cref="VirtualFree"/> and <see cref="VirtualFreeEx"/>.
        /// A placeholder is a type of reserved memory region.
        /// <see cref="MEM_RESERVE_PLACEHOLDER"/>:
        /// To create a placeholder, call <see cref="VirtualAlloc2"/> with <code>MEM_RESERVE | MEM_RESERVE_PLACEHOLDER</code>
        /// and <paramref name="PageProtection"/> set to <see cref="PAGE_NOACCESS"/>.
        /// To free/split/coalesce a placeholder, see the dwFreeType parameter of <see cref="VirtualFree"/> and <see cref="VirtualFreeEx"/>.
        /// A placeholder is a type of reserved memory region.
        /// <see cref="MEM_RESET"/>:
        /// Indicates that data in the memory range specified by <paramref name="BaseAddress"/> and <paramref name="Size"/> is no longer of interest.
        /// The pages should not be read from or written to the paging file.
        /// However, the memory block will be used again later, so it should not be decommitted.
        /// This value cannot be used with any other value.
        /// Using this value does not guarantee that the range operated on with <see cref="MEM_RESET"/> will contain zeros.
        /// If you want the range to contain zeros, decommit the memory and then recommit it.
        /// When you use <see cref="MEM_RESET"/>, the <see cref="VirtualAlloc2"/> function ignores the value of <paramref name="PageProtection"/>.
        /// However, you must still set <paramref name="PageProtection"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// <see cref="VirtualAlloc2"/> returns an error if you use <see cref="MEM_RESET"/> and the range of memory is mapped to a file.
        /// A shared view is only acceptable if it is mapped to a paging file.
        /// <see cref="MEM_RESET_UNDO"/>:
        /// <see cref="MEM_RESET_UNDO"/> should only be called on an address range to which <see cref="MEM_RESET"/> was successfully applied earlier.
        /// It indicates that the data in the specified memory range specified by <paramref name="BaseAddress"/> and <paramref name="Size"/>
        /// is of interest to the caller and attempts to reverse the effects of <see cref="MEM_RESET"/>.
        /// If the function succeeds, that means all data in the specified address range is intact.
        /// If the function fails, at least some of the data in the address range has been replaced with zeroes.
        /// This value cannot be used with any other value.
        /// If <see cref="MEM_RESET_UNDO"/> is called on an address range which was not <see cref="MEM_RESET"/> earlier, the behavior is undefined.
        /// When you specify <see cref="MEM_RESET"/>, the <see cref="VirtualAlloc2"/> function ignores the value of <paramref name="PageProtection"/>.
        /// However, you must still set <paramref name="PageProtection"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// The <see cref="MEM_RESET_UNDO"/> flag is not supported until Windows 8 and Windows Server 2012.
        /// This parameter can also specify the following values as indicated.
        /// <see cref="MEM_LARGE_PAGES"/>:
        /// Allocates memory using large page support.
        /// The size and alignment must be a multiple of the large-page minimum.
        /// To obtain this value, use the <see cref="GetLargePageMinimum"/> function.
        /// If you specify this value, you must also specify <see cref="MEM_RESERVE"/> and <see cref="MEM_COMMIT"/>.
        /// <see cref="MEM_PHYSICAL"/>:
        /// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.
        /// This value must be used with <see cref="MEM_RESERVE"/> and no other values.
        /// <see cref="MEM_TOP_DOWN"/>:
        /// Allocates memory at the highest possible address. 
        /// This can be slower than regular allocations, especially when there are many allocations. 
        /// </param>
        /// <param name="PageProtection">
        /// The memory protection for the region of pages to be allocated.
        /// If the pages are being committed, you can specify any one of the memory protection constants.
        /// If <paramref name="BaseAddress"/> specifies an address within an enclave,
        /// <paramref name="PageProtection"/> cannot be any of the following values:
        /// <see cref="PAGE_NOACCESS"/>, <see cref="PAGE_GUARD"/>, <see cref="PAGE_NOCACHE"/>, <see cref="PAGE_WRITECOMBINE"/>
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
        /// If the function succeeds, the return value is the base address of the allocated region of pages.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This API helps support high-performance games, and server applications,
        /// which have particular requirements around managing their virtual address space.
        /// For example, mapping memory on top of a previously reserved region; this is useful for implementing an automatically wrapping ring buffer.
        /// And allocating memory with specific alignment; for example, to enable your application to commit large/huge page-mapped regions on demand.
        /// Each page has an associated page state.
        /// The <see cref="VirtualAlloc2"/> function can perform the following operations:
        /// Commit a region of reserved pages
        /// Reserve a region of free pages
        /// Simultaneously reserve and commit a region of free pages
        /// <see cref="VirtualAlloc2"/> cannot reserve a reserved page. It can commit a page that is already committed.
        /// This means you can commit a range of pages, regardless of whether they have already been committed, and the function will not fail.
        /// You can use <see cref="VirtualAlloc2"/> to reserve a block of pages and
        /// then make additional calls to <see cref="VirtualAlloc2"/> to commit individual pages from the reserved block.
        /// This enables a process to reserve a range of its virtual address space without consuming physical storage until it is needed.
        /// If the <paramref name="BaseAddress"/> parameter is not <see cref="NULL"/>,
        /// the function uses the <paramref name="BaseAddress"/> and <paramref name="Size"/> parameters to compute the region of pages to be allocated.
        /// The current state of the entire range of pages must be compatible with the type
        /// of allocation specified by the <paramref name="AllocationType"/> parameter.
        /// Otherwise, the function fails and none of the pages is allocated.
        /// This compatibility requirement does not preclude committing an already committed page; see the preceding list.
        /// To execute dynamically generated code, use <see cref="VirtualAlloc2"/> to allocate memory,
        /// and the <see cref="VirtualProtectEx"/> function to grant <see cref="PAGE_EXECUTE"/> access.
        /// The <see cref="VirtualAlloc2"/> function can be used to reserve an Address Windowing Extensions (AWE) region of memory
        /// within the virtual address space of a specified process.
        /// This region of memory can then be used to map physical pages into and out of virtual memory as required by the application.
        /// The <see cref="MEM_PHYSICAL"/> and <see cref="MEM_RESERVE"/> values must be set in the <paramref name="AllocationType"/> parameter.
        /// The <see cref="MEM_COMMIT"/> value must not be set. The page protection must be set to <see cref="PAGE_READWRITE"/>.
        /// The <see cref="VirtualFreeEx"/> function can decommit a committed page, releasing the page's storage,
        /// or it can simultaneously decommit and release a committed page.
        /// It can also release a reserved page, making it a free page.
        /// When creating a region that will be executable, the calling program bears responsibility for ensuring cache coherency
        /// via an appropriate call to <see cref="FlushInstructionCache"/> once the code has been set in place.
        /// Otherwise attempts to execute code out of the newly executable region may produce unpredictable results.
        /// </remarks>
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualAlloc2", ExactSpelling = true, SetLastError = true)]
        public static extern PVOID VirtualAlloc2([In] HANDLE Process, [In] PVOID BaseAddress, [In] SIZE_T Size,
            [In] MemoryAllocationTypes AllocationType, [In] MemoryProtectionConstants PageProtection,
            [MarshalAs(UnmanagedType.LPArray)][In] MEM_EXTENDED_PARAMETER[] ExtendedParameters, [In] ULONG ParameterCount);

        /// <summary>
        /// <para>
        /// Reserves, commits, or changes the state of a region of pages in the virtual address space of the calling process.
        /// Memory allocated by this function is automatically initialized to zero.
        /// Using this function, you can: for new allocations, specify a range of virtual address space and a power-of-2 alignment restriction;
        /// specify an arbitrary number of extended parameters; specify a preferred NUMA node for the physical memory as an extended parameter;
        /// and specify a placeholder operation (specifically, replacement).
        /// To specify the NUMA node, see the <paramref name="ExtendedParameters"/> parameter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualalloc2fromapp"/>
        /// </para>
        /// </summary>
        /// <param name="Process">
        /// The handle to a process.
        /// The function allocates memory within the virtual address space of this process.
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="BaseAddress">
        /// The pointer that specifies a desired starting address for the region of pages that you want to allocate.
        /// If an explicit base address is specified, then it must be a multiple of the system allocation granularity.
        /// To determine the size of a page and the allocation granularity on the host computer, use the <see cref="GetSystemInfo"/> function.
        /// If <paramref name="BaseAddress"/> is <see cref="NULL"/>, the function determines where to allocate the region.
        /// </param>
        /// <param name="Size">
        /// The size of the region of memory to allocate, in bytes.
        /// The size must always be a multiple of the page size.
        /// If <paramref name="BaseAddress"/> is not <see cref="NULL"/>, the function allocates all pages that contain one or more bytes
        /// in the range from <paramref name="BaseAddress"/> to <paramref name="BaseAddress"/>+<paramref name="Size"/>.
        /// This means, for example, that a 2-byte range that straddles a page boundary causes the function to allocate both pages.
        /// </param>
        /// <param name="AllocationType">
        /// The type of memory allocation. This parameter must contain one of the following values.
        /// <see cref="MEM_COMMIT"/>:
        /// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages.
        /// The function also guarantees that when the caller later initially accesses the memory, the contents will be zero.
        /// Actual physical pages are not allocated unless/until the virtual addresses are actually accessed.
        /// To reserve and commit pages in one step, call <see cref="VirtualAlloc2FromApp"/> with <code>MEM_COMMIT | MEM_RESERVE</code>.
        /// Attempting to commit a specific address range by specifying <see cref="MEM_COMMIT"/> without <see cref="MEM_RESERVE"/>
        /// and a non-NULL <paramref name="BaseAddress"/> fails unless the entire range has already been reserved.
        /// The resulting error code is <see cref="ERROR_INVALID_ADDRESS"/>.
        /// An attempt to commit a page that is already committed does not cause the function to fail.
        /// This means that you can commit pages without first determining the current commitment state of each page.
        /// <see cref="MEM_RESERVE"/>:
        /// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory
        /// or in the paging file on disk.
        /// You commit reserved pages by calling <see cref="VirtualAlloc2FromApp"/> again with <see cref="MEM_COMMIT"/>.
        /// To reserve and commit pages in one step, call <see cref="VirtualAlloc2FromApp"/> with <code>MEM_COMMIT | MEM_RESERVE</code>.
        /// Other memory allocation functions, such as malloc and <see cref="LocalAlloc"/>, cannot use reserved memory until it has been released.
        /// <see cref="MEM_REPLACE_PLACEHOLDER"/>:
        /// Replaces a placeholder with a normal private allocation.
        /// Only data/pf-backed section views are supported (no images, physical memory, etc.).
        /// When you replace a placeholder, <paramref name="BaseAddress"/> and <paramref name="Size"/> must exactly match those of the placeholder.
        /// After you replace a placeholder with a private allocation, to free that allocation back to a placeholder,
        /// see the dwFreeType parameter of <see cref="VirtualFree"/> and <see cref="VirtualFreeEx"/>.
        /// A placeholder is a type of reserved memory region.
        /// <see cref="MEM_RESERVE_PLACEHOLDER"/>:
        /// To create a placeholder, call <see cref="VirtualAlloc2FromApp"/> with <code>MEM_RESERVE | MEM_RESERVE_PLACEHOLDER</code>
        /// and <paramref name="PageProtection"/> set to <see cref="PAGE_NOACCESS"/>.
        /// To free/split/coalesce a placeholder, see the dwFreeType parameter of <see cref="VirtualFree"/> and <see cref="VirtualFreeEx"/>.
        /// A placeholder is a type of reserved memory region.
        /// <see cref="MEM_RESET"/>:
        /// Indicates that data in the memory range specified by <paramref name="BaseAddress"/> and <paramref name="Size"/> is no longer of interest.
        /// The pages should not be read from or written to the paging file.
        /// However, the memory block will be used again later, so it should not be decommitted.
        /// This value cannot be used with any other value.
        /// Using this value does not guarantee that the range operated on with <see cref="MEM_RESET"/> will contain zeros.
        /// If you want the range to contain zeros, decommit the memory and then recommit it.
        /// When you use <see cref="MEM_RESET"/>, the <see cref="VirtualAlloc2FromApp"/> function ignores the value of <paramref name="PageProtection"/>.
        /// However, you must still set <paramref name="PageProtection"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// <see cref="VirtualAlloc2FromApp"/> returns an error if you use <see cref="MEM_RESET"/> and the range of memory is mapped to a file.
        /// A shared view is only acceptable if it is mapped to a paging file.
        /// <see cref="MEM_RESET_UNDO"/>:
        /// <see cref="MEM_RESET_UNDO"/> should only be called on an address range to which <see cref="MEM_RESET"/> was successfully applied earlier.
        /// It indicates that the data in the specified memory range specified by <paramref name="BaseAddress"/> and <paramref name="Size"/>
        /// is of interest to the caller and attempts to reverse the effects of <see cref="MEM_RESET"/>.
        /// If the function succeeds, that means all data in the specified address range is intact.
        /// If the function fails, at least some of the data in the address range has been replaced with zeroes.
        /// This value cannot be used with any other value.
        /// If <see cref="MEM_RESET_UNDO"/> is called on an address range which was not <see cref="MEM_RESET"/> earlier, the behavior is undefined.
        /// When you specify <see cref="MEM_RESET"/>, the <see cref="VirtualAlloc2"/> function ignores the value of <paramref name="PageProtection"/>.
        /// However, you must still set <paramref name="PageProtection"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// This parameter can also specify the following values as indicated.
        /// <see cref="MEM_LARGE_PAGES"/>:
        /// Allocates memory using large page support.
        /// The size and alignment must be a multiple of the large-page minimum.
        /// To obtain this value, use the <see cref="GetLargePageMinimum"/> function.
        /// If you specify this value, you must also specify <see cref="MEM_RESERVE"/> and <see cref="MEM_COMMIT"/>.
        /// <see cref="MEM_PHYSICAL"/>:
        /// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.
        /// This value must be used with <see cref="MEM_RESERVE"/> and no other values.
        /// <see cref="MEM_TOP_DOWN"/>:
        /// Allocates memory at the highest possible address. 
        /// This can be slower than regular allocations, especially when there are many allocations.
        /// <see cref="MEM_WRITE_WATCH"/>:
        /// Causes the system to track pages that are written to in the allocated region.
        /// If you specify this value, you must also specify <see cref="MEM_RESERVE"/>.
        /// To retrieve the addresses of the pages that have been written to since the region was allocated or the write-tracking state was reset,
        /// call the <see cref="GetWriteWatch"/> function.
        /// To reset the write-tracking state, call <see cref="GetWriteWatch"/> or <see cref="ResetWriteWatch"/>.
        /// The write-tracking feature remains enabled for the memory region until the region is freed.
        /// </param>
        /// <param name="PageProtection">
        /// The memory protection for the region of pages to be allocated.
        /// If the pages are being committed, you can specify any one of the memory protection constants.
        /// If <paramref name="BaseAddress"/> specifies an address within an enclave,
        /// <paramref name="PageProtection"/> cannot be any of the following values:
        /// <see cref="PAGE_EXECUTE"/>, <see cref="PAGE_EXECUTE_READ"/>, <see cref="PAGE_EXECUTE_READWRITE"/>, <see cref="PAGE_EXECUTE_WRITECOPY"/>
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
        /// If the function succeeds, the return value is the base address of the allocated region of pages.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This API helps support high-performance games, and server applications,
        /// which have particular requirements around managing their virtual address space.
        /// For example, mapping memory on top of a previously reserved region; this is useful for implementing an automatically wrapping ring buffer.
        /// And allocating memory with specific alignment; for example, to enable your application to commit large/huge page-mapped regions on demand.
        /// You can call <see cref="VirtualAlloc2FromApp"/> from Windows Store apps with just-in-time (JIT) capabilities to use JIT functionality.
        /// The app must include the codeGeneration capability in the app manifest file to use JIT capabilities.
        /// Each page has an associated page state. The Virtual2AllocFromApp function can perform the following operations:
        /// Commit a region of reserved pages
        /// Reserve a region of free pages
        /// Simultaneously reserve and commit a region of free pages
        /// <see cref="VirtualAlloc2FromApp"/> cannot reserve a reserved page. It can commit a page that is already committed.
        /// This means you can commit a range of pages, regardless of whether they have already been committed, and the function will not fail.
        /// You can use <see cref="VirtualAlloc2FromApp"/> to reserve a block of pages
        /// and then make additional calls to <see cref="VirtualAlloc2FromApp"/> to commit individual pages from the reserved block.
        /// This enables a process to reserve a range of its virtual address space without consuming physical storage until it is needed.
        /// If the <paramref name="BaseAddress"/> parameter is not <see cref="NULL"/>,
        /// the function uses the <paramref name="BaseAddress"/> and <paramref name="Size"/> parameters to compute the region of pages to be allocated.
        /// The current state of the entire range of pages must be compatible
        /// with the type of allocation specified by the <paramref name="AllocationType"/> parameter.
        /// Otherwise, the function fails and none of the pages are allocated.
        /// This compatibility requirement does not preclude committing an already committed page, as mentioned previously.
        /// <see cref="VirtualAlloc2FromApp"/> does not allow the creation of executable pages.
        /// The <see cref="VirtualAlloc2FromApp"/> function can be used to reserve an Address Windowing Extensions (AWE) region
        /// of memory within the virtual address space of a specified process.
        /// This region of memory can then be used to map physical pages into and out of virtual memory as required by the application.
        /// The <see cref="MEM_PHYSICAL"/> and <see cref="MEM_RESERVE"/> values must be set in the <paramref name="AllocationType"/> parameter.
        /// The <see cref="MEM_COMMIT"/> value must not be set.
        /// The page protection must be set to <see cref="PAGE_READWRITE"/>.
        /// The <see cref="VirtualFree"/> function can decommit a committed page, releasing the page's storage,
        /// or it can simultaneously decommit and release a committed page. 
        /// It can also release a reserved page, making it a free page.
        /// When creating a region that will be executable, the calling program bears responsibility
        /// for ensuring cache coherency via an appropriate call to <see cref="FlushInstructionCache"/> once the code has been set in place.
        /// Otherwise attempts to execute code out of the newly executable region may produce unpredictable results.
        /// </remarks>
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualAlloc2FromApp", ExactSpelling = true, SetLastError = true)]
        public static extern PVOID VirtualAlloc2FromApp([In] HANDLE Process, [In] PVOID BaseAddress, [In] SIZE_T Size,
            [In] MemoryAllocationTypes AllocationType, [In] MemoryProtectionConstants PageProtection,
            [MarshalAs(UnmanagedType.LPArray)][In] MEM_EXTENDED_PARAMETER[] ExtendedParameters, [In] ULONG ParameterCount);

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
        /// The <see cref="WaitOnAddress"/> function can be used by a thread to wait for a particular value
        /// to change from some undesired value to any other value.
        /// <see cref="WaitOnAddress"/> is more efficient than using the Sleep function inside a while loop
        /// because <see cref="WaitOnAddress"/> does not interfere with the thread scheduler.
        /// <see cref="WaitOnAddress"/> is also simpler to use than an event object because it is not necessary
        /// to create and initialize an event and then make sure it is synchronized correctly with the value.
        /// <see cref="WaitOnAddress"/> is not affected by low-memory conditions, other than potentially waking the thread early as noted below.
        /// Any thread within the same process that changes the value at the address on which threads are waiting
        /// should call <see cref="WakeByAddressSingle"/> to wake a single waiting thread or <see cref="WakeByAddressAll"/> to wake all waiting threads.
        /// If <see cref="WakeByAddressSingle"/> is called, other waiting threads continue to wait.
        /// Note WaitOnAddress is guaranteed to return when the address is signaled, but it is also allowed to return for other reasons.
        /// For this reason, after <see cref="WaitOnAddress"/> returns the caller should compare the new value
        /// with the original undesired value to confirm that the value has actually changed.
        /// For example, the following circumstances can result in waking the thread early:
        /// Low memory conditions
        /// A previous wake on the same address was abandoned
        /// Executing code on a checked build of the operating system
        /// </remarks>
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
        /// Only threads within the same process can be woken.
        /// </remarks>
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "WakeByAddressAll", ExactSpelling = true, SetLastError = true)]
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
        /// Only a thread within the same process can be woken.
        /// </remarks>
        [DllImport("Kernelbase.dll", CharSet = CharSet.Unicode, EntryPoint = "WakeByAddressSingle", ExactSpelling = true, SetLastError = true)]
        public static extern void WakeByAddressSingle([In] PVOID Address);
    }
}
