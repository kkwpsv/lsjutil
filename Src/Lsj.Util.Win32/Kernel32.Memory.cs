using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.GlobalMemoryFlags;
using static Lsj.Util.Win32.Enums.HeapFlags;
using static Lsj.Util.Win32.Enums.LocalMemoryFlags;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Retrieves the minimum size of a large page.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-getlargepageminimum
        /// </para>
        /// </summary>
        /// <returns>
        /// If the processor supports large pages, the return value is the minimum size of a large page.
        /// If the processor does not support large pages, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The minimum large page size varies, but it is typically 2 MB or greater.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLargePageMinimum", SetLastError = true)]
        public static extern IntPtr GetLargePageMinimum();

        /// <summary>
        /// <para>
        /// Retrieves a handle to the default heap of the calling process.
        /// This handle can then be used in subsequent calls to the heap functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-getprocessheap
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the calling process's heap.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetProcessHeap"/> function obtains a handle to the default heap for the calling process.
        /// A process can use this handle to allocate memory from the process heap without having to first create a private heap
        /// using the <see cref="HeapCreate"/> function.
        /// Windows Server 2003 and Windows XP:
        /// To enable the low-fragmentation heap for the default heap of the process,
        /// call the <see cref="HeapSetInformation"/> function with the handle returned by <see cref="GetProcessHeap"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessHeap", SetLastError = true)]
        public static extern IntPtr GetProcessHeap();

        /// <summary>
        /// <para>
        /// Allocates the specified number of bytes from the heap.
        /// </para>
        /// <para>
        /// https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalalloc
        /// </para>
        /// </summary>
        /// <param name="uFlags">
        /// The memory allocation attributes. If zero is specified, the default is <see cref="GMEM_FIXED"/>.
        /// This parameter can be one or more of the following values, except for the incompatible combinations that are specifically noted.
        /// <see cref="GHND"/> : Combines <see cref="GMEM_MOVEABLE"/> and <see cref="GMEM_ZEROINIT"/>.
        /// <see cref="GMEM_FIXED"/> : Allocates fixed memory. The return value is a pointer.
        /// <see cref="GMEM_MOVEABLE"/> : Allocates movable memory. Memory blocks are never moved in physical memory,
        /// but they can be moved within the default heap. The return value is a handle to the memory object. 
        /// To translate the handle into a pointer, use the <see cref="GlobalLock"/> function.
        /// This value cannot be combined with <see cref="GMEM_FIXED"/>.
        /// <see cref="GMEM_ZEROINIT"/> : Initializes memory contents to zero.
        /// <see cref="GPTR"/> : Combines <see cref="GMEM_FIXED"/> and <see cref="GMEM_ZEROINIT"/>.
        /// The following values are obsolete, but are provided for compatibility with 16-bit Windows. They are ignored.
        /// <see cref="GMEM_DDESHARE"/>, <see cref="GMEM_DISCARDABLE"/>, <see cref="GMEM_LOWER"/>,
        /// <see cref="GMEM_NOCOMPACT"/>, <see cref="GMEM_NODISCARD"/>, <see cref="GMEM_NOT_BANKED"/>,
        /// <see cref="GMEM_NOTIFY"/>, <see cref="GMEM_SHARE"/>.
        /// </param>
        /// <param name="dwBytes">
        /// The number of bytes to allocate.
        /// If this parameter is zero and the <paramref name="uFlags"/> parameter specifies <see cref="GMEM_MOVEABLE"/>,
        /// the function returns a handle to a memory object that is marked as discarded.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly allocated memory object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalAlloc", SetLastError = true)]
        public static extern IntPtr GlobalAlloc(GlobalMemoryFlags uFlags, IntPtr dwBytes);

        /// <summary>
        /// Locks a global memory object and returns a pointer to the first byte of the object's memory block.
        /// </summary>
        /// <param name="hMem">
        /// A handle to the global memory object.
        /// This handle is returned by either the <see cref="GlobalAlloc"/> or <see cref="GlobalReAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the first byte of the memory block.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalLock", SetLastError = true)]
        public static extern IntPtr GlobalLock(IntPtr hMem);

        /// <summary>
        /// Changes the size or attributes of a specified global memory object. The size can increase or decrease.
        /// </summary>
        /// <param name="hMem">
        /// A handle to the global memory object to be reallocated.
        /// This handle is returned by either the <see cref="GlobalAlloc"/> or <see cref="GlobalReAlloc"/> function.
        /// </param>
        /// <param name="dwBytes">
        /// The new size of the memory block, in bytes. If uFlags specifies <see cref="GMEM_MODIFY"/>, this parameter is ignored.
        /// </param>
        /// <param name="uFlags">
        /// The reallocation options. If <see cref="GMEM_MODIFY"/> is specified,
        /// the function modifies the attributes of the memory object only (the dwBytes parameter is ignored.)
        /// Otherwise, the function reallocates the memory object.
        /// You can optionally combine <see cref="GMEM_MODIFY"/> with the following value.
        /// <see cref="GMEM_MOVEABLE"/> : Allocates movable memory.
        /// If the memory is a locked <see cref="GMEM_MOVEABLE"/> memory block 
        /// or a <see cref="GMEM_FIXED"/> memory block and this flag is not specified, the memory can only be reallocated in place.
        /// If this parameter does not specify <see cref="GMEM_MODIFY"/>, you can use the following value.
        /// <see cref="GMEM_ZEROINIT"/> : Causes the additional memory contents to be initialized to zero
        /// if the memory object is growing in size.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the reallocated memory object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalReAlloc", SetLastError = true)]
        public static extern IntPtr GlobalReAlloc(IntPtr hMem, IntPtr dwBytes, GlobalMemoryFlags uFlags);

        /// <summary>
        /// <para>
        /// Allocates a block of memory from a heap. The allocated memory is not movable.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapalloc
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap from which the memory will be allocated.
        /// This handle is returned by the <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// The heap allocation options.
        /// Specifying any of these values will override the corresponding value specified when the heap was created with <see cref="HeapCreate"/>.
        /// This parameter can be one or more of the following values.
        /// <see cref="HEAP_GENERATE_EXCEPTIONS"/>: 
        /// The system will raise an exception to indicate a function failure, such as an out-of-memory condition, instead of returning NULL.
        /// To ensure that exceptions are generated for all calls to this function,
        /// specify <see cref="HEAP_GENERATE_EXCEPTIONS"/> in the call to <see cref="HeapCreate"/>.
        /// In this case, it is not necessary to additionally specify <see cref="HEAP_GENERATE_EXCEPTIONS"/> in this function call.
        /// <see cref="HEAP_NO_SERIALIZE"/>:
        /// Serialized access will not be used for this allocation. For more information, see Remarks.
        /// To ensure that serialized access is disabled for all calls to this function,
        /// specify <see cref="HEAP_NO_SERIALIZE"/> in the call to <see cref="HeapCreate"/>.
        /// In this case, it is not necessary to additionally specify <see cref="HEAP_NO_SERIALIZE"/> in this function call.
        /// This value should not be specified when accessing the process's default heap.
        /// The system may create additional threads within the application's process, such as a CTRL+C handler,
        /// that simultaneously access the process's default heap.
        /// <see cref="HEAP_ZERO_MEMORY"/>:
        /// The allocated memory will be initialized to zero. Otherwise, the memory is not initialized to zero.
        /// </param>
        /// <param name="dwBytes">
        /// The number of bytes to be allocated.
        /// If the heap specified by the hHeap parameter is a "non-growable" heap, <paramref name="dwBytes"/> must be less than 0x7FFF8.
        /// You create a non-growable heap by calling the <see cref="HeapCreate"/> function with a nonzero value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the allocated memory block.
        /// If the function fails and you have not specified <see cref="HEAP_GENERATE_EXCEPTIONS"/>, the return value is <see cref="IntPtr.Zero"/>.
        /// If the function fails and you have specified <see cref="HEAP_GENERATE_EXCEPTIONS"/>,
        /// the function may generate either of the exceptions listed in the following table.
        /// The particular exception depends upon the nature of the heap corruption.
        /// For more information, see <see cref="Marshal.GetExceptionCode"/>.
        /// <see cref="STATUS_NO_MEMORY"/>: The allocation attempt failed because of a lack of available memory or heap corruption.
        /// <see cref="STATUS_ACCESS_VIOLATION"/>: The allocation attempt failed because of heap corruption or improper function parameters.
        /// If the function fails, it does not call <see cref="SetLastError"/>.
        /// An application cannot call GetLastError for extended error information.
        /// </returns>
        /// <remarks>
        /// If the <see cref="HeapAlloc"/> function succeeds, it allocates at least the amount of memory requested.
        /// To allocate memory from the process's default heap,
        /// use <see cref="HeapAlloc"/> with the handle returned by the <see cref="GetProcessHeap"/> function.
        /// To free a block of memory allocated by <see cref="HeapAlloc"/>, use the <see cref="HeapFree"/> function.
        /// Memory allocated by <see cref="HeapAlloc"/> is not movable.
        /// The address returned by HeapAlloc is valid until the memory block is freed or reallocated;
        /// the memory block does not need to be locked.
        /// Because the system cannot compact a private heap, it can become fragmented.
        /// Applications that allocate large amounts of memory in various allocation sizes can use the low-fragmentation heap to reduce heap fragmentation.
        /// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same heap.
        /// There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory from the same heap.
        /// Setting the <see cref="HEAP_NO_SERIALIZE"/> value eliminates mutual exclusion on the heap.
        /// Without serialization, two or more threads that use the same heap handle might attempt to allocate or free memory simultaneously,
        /// likely causing corruption in the heap.
        /// The <see cref="HEAP_NO_SERIALIZE"/> value can, therefore, be safely used only in the following situations:
        /// The process has only one thread.
        /// The process has multiple threads, but only one thread calls the heap functions for a specific heap.
        /// The process has multiple threads, and the application provides its own mechanism for mutual exclusion to a specific heap.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapAlloc", SetLastError = true)]
        public static extern IntPtr HeapAlloc([In]IntPtr hHeap, [In]HeapFlags dwFlags, [In]IntPtr dwBytes);

        /// <summary>
        /// <para>
        /// Allocates the specified number of bytes from the heap.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-localalloc
        /// </para>
        /// </summary>
        /// <param name="uFlags">
        /// The memory allocation attributes. The default is the <see cref="LMEM_FIXED"/> value.
        /// This parameter can be one or more of the following values, except for the incompatible combinations that are specifically noted.
        /// <see cref="LHND"/> : Combines <see cref="LMEM_MOVEABLE"/> and <see cref="LMEM_ZEROINIT"/>.
        /// <see cref="LMEM_FIXED"/> : Allocates fixed memory. The return value is a pointer to the memory object.
        /// <see cref="LMEM_MOVEABLE"/> : Allocates movable memory. Memory blocks are never moved in physical memory,
        /// but they can be moved within the default heap. The return value is a handle to the memory object. 
        /// To translate the handle to a pointer, use the <see cref="LocalLock"/> function.
        /// This value cannot be combined with <see cref="LMEM_FIXED"/>.
        /// <see cref="LMEM_ZEROINIT"/> : Initializes memory contents to zero.
        /// <see cref="LPTR"/> : Combines <see cref="LMEM_FIXED"/> and <see cref="LMEM_ZEROINIT"/>.
        /// <see cref="NONZEROLHND"/> : Same as <see cref="LMEM_MOVEABLE"/>.
        /// <see cref="NONZEROLPTR"/> : Same as <see cref="LMEM_FIXED"/>.
        /// The following values are obsolete, but are provided for compatibility with 16-bit Windows. They are ignored.
        /// <see cref="LMEM_DISCARDABLE"/>, <see cref="LMEM_NOCOMPACT"/>, <see cref="LMEM_NODISCARD"/>.
        /// </param>
        /// <param name="uBytes">
        /// The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies <see cref="LMEM_MOVEABLE"/>,
        /// the function returns a handle to a memory object that is marked as discarded.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly allocated memory object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalAlloc", SetLastError = true)]
        public static extern IntPtr LocalAlloc(LocalMemoryFlags uFlags, IntPtr uBytes);

        /// <summary>
        /// <para>
        /// Frees the specified local memory object and invalidates its handle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-localfree
        /// </para>
        /// </summary>
        /// <param name="hMem">
        /// A handle to the local memory object.
        /// This handle is returned by either the <see cref="LocalAlloc"/> or <see cref="LocalReAlloc"/> function.
        /// It is not safe to free memory allocated with <see cref="GlobalAlloc"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="IntPtr.Zero"/>.
        /// If the function fails, the return value is equal to a handle to the local memory object.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalFree", SetLastError = true)]
        public static extern IntPtr LocalFree([In]IntPtr hMem);

        /// <summary>
        /// <para>
        /// Locks a local memory object and returns a pointer to the first byte of the object's memory block.
        /// </para>
        /// <para>
        /// https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-locallock
        /// </para>
        /// </summary>
        /// <param name="hMem">
        /// A handle to the local memory object. This handle is returned by either the <see cref="LocalAlloc"/> or <see cref="LocalReAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the first byte of the memory block.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalLock", SetLastError = true)]
        public static extern IntPtr LocalLock(IntPtr hMem);

        /// <summary>
        /// <para>
        /// Changes the size or the attributes of a specified local memory object. The size can increase or decrease.
        /// </para>
        /// <para>
        /// https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-localrealloc
        /// </para>
        /// </summary>
        /// <param name="hMem">
        /// A handle to the local memory object to be reallocated.
        /// This handle is returned by either the <see cref="LocalAlloc"/> or <see cref="LocalReAlloc"/> function.
        /// </param>
        /// <param name="uBytes">
        /// The new size of the memory block, in bytes. If uFlags specifies <see cref="LMEM_MODIFY"/>, this parameter is ignored.
        /// </param>
        /// <param name="uFlags">
        /// The reallocation options. If <see cref="LMEM_MODIFY"/> is specified,
        /// the function modifies the attributes of the memory object only (the <paramref name="uBytes"/> parameter is ignored.)
        /// Otherwise, the function reallocates the memory object.
        /// You can optionally combine <see cref="LMEM_MODIFY"/> with the following value.
        /// <see cref="LMEM_MOVEABLE"/> : Allocates fixed or movable memory. 
        /// If the memory is a locked <see cref="LMEM_MOVEABLE"/> memory block
        /// or a <see cref="LMEM_FIXED"/> memory block and this flag is not specified, the memory can only be reallocated in place.
        /// If this parameter does not specify <see cref="LMEM_MODIFY"/>, you can use the following value.
        /// <see cref="LMEM_ZEROINIT"/> : Causes the additional memory contents to be initialized to zero
        /// if the memory object is growing in size.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the reallocated memory object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalReAlloc", SetLastError = true)]
        public static extern IntPtr LocalReAlloc(IntPtr hMem, IntPtr uBytes, LocalMemoryFlags uFlags);

        /// <summary>
        /// <para>
        /// Changes the protection on a region of committed pages in the virtual address space of the calling process.
        /// To change the access protection of any process, use the <see cref="VirtualProtectEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualprotect
        /// </para>
        /// </summary>
        /// <param name="lpAddress">
        /// A pointer an address that describes the starting page of the region of pages whose access protection attributes are to be changed.
        /// All pages in the specified region must be within the same reserved region allocated
        /// when calling the <see cref="VirtualAlloc"/> or <see cref="VirtualAllocEx"/> function using <see cref="MEM_RESERVE"/>.
        /// The pages cannot span adjacent reserved regions that were allocated by separate calls
        /// to <see cref="VirtualAlloc"/> or <see cref="VirtualAllocEx"/> using <see cref="MEM_RESERVE"/>.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region whose access protection attributes are to be changed, in bytes.
        /// The region of affected pages includes all pages containing one or more bytes in the range
        /// from the <paramref name="lpAddress"/> parameter to (<paramref name="lpAddress"/>+<paramref name="dwSize"/>).
        /// This means that a 2-byte range straddling a page boundary causes the protection attributes of both pages to be changed.
        /// </param>
        /// <param name="flNewProtect">
        /// The memory protection option. This parameter can be one of the memory protection constants.
        /// For mapped views, this value must be compatible with the access protection specified when the view was mapped
        /// (see <see cref="MapViewOfFile"/>, <see cref="MapViewOfFileEx"/>, and <see cref="MapViewOfFileExNuma"/>).
        /// </param>
        /// <param name="lpflOldProtect">
        /// A pointer to a variable that receives the previous access protection value of the first page in the specified region of pages.
        /// If this parameter is <see langword="null"/> or does not point to a valid variable, the function fails.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// You can set the access protection value on committed pages only.
        /// If the state of any page in the specified region is not committed, the function fails and returns
        /// without modifying the access protection of any pages in the specified region.
        /// The <see cref="PAGE_GUARD"/> protection modifier establishes guard pages.
        /// Guard pages act as one-shot access alarms. For more information, see Creating Guard Pages.
        /// It is best to avoid using <see cref="VirtualProtect"/> to change page protections on memory blocks allocated by <see cref="GlobalAlloc"/>,
        /// <see cref="HeapAlloc"/>, or <see cref="LocalAlloc"/>, because multiple memory blocks can exist on a single page.
        /// The heap manager assumes that all pages in the heap grant at least read and write access.
        /// When protecting a region that will be executable, the calling program bears responsibility for ensuring cache coherency 
        /// via an appropriate call to <see cref="FlushInstructionCache"/> once the code has been set in place.
        /// Otherwise attempts to execute code out of the newly executable region may produce unpredictable results.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualProtect", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool VirtualProtect([In]IntPtr lpAddress, [In]IntPtr dwSize, [In]MemoryProtectionConstants flNewProtect,
            [Out]out MemoryProtectionConstants lpflOldProtect);
    }
}
