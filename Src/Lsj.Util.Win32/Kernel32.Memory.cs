using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.GlobalMemoryFlags;
using static Lsj.Util.Win32.Enums.HeapFlags;
using static Lsj.Util.Win32.Enums.LocalMemoryFlags;
using static Lsj.Util.Win32.Enums.HEAP_INFORMATION_CLASS;

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
        /// Returns the number of active heaps and retrieves handles to all of the active heaps for the calling process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-getprocessheaps
        /// </para>
        /// </summary>
        /// <param name="NumberOfHeaps">
        /// The maximum number of heap handles that can be stored into the buffer pointed to by <paramref name="ProcessHeaps"/>.
        /// </param>
        /// <param name="ProcessHeaps">
        /// A pointer to a buffer that receives an array of heap handles.
        /// </param>
        /// <returns>
        /// The return value is the number of handles to heaps that are active for the calling process.
        /// If the return value is less than or equal to Number<paramref name="NumberOfHeaps"/>OfHeaps,
        /// the function has stored that number of heap handles in the buffer pointed to by <paramref name="ProcessHeaps"/>.
        /// If the return value is greater than <paramref name="NumberOfHeaps"/>,
        /// the buffer pointed to by <paramref name="ProcessHeaps"/> is too small to hold all the heap handles for the calling process,
        /// and the function stores <paramref name="NumberOfHeaps"/> handles in the buffer.
        /// Use the return value to allocate a buffer that is large enough to receive all of the handles, and call the function again.
        /// If the return value is zero, the function has failed because every process has at least one active heap, the default heap for the process.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetProcessHeaps"/> function obtains a handle to the default heap of the calling process,
        /// plus handles to any additional private heaps created by calling the <see cref="HeapCreate"/> function on any thread in the process.
        /// The <see cref="GetProcessHeaps"/> function is primarily useful for debugging,
        /// because some of the private heaps retrieved by the function may have been created by other code running in the process
        /// and may be destroyed after <see cref="GetProcessHeaps"/> returns.
        /// Destroying a heap invalidates the handle to the heap, and continued use of such handles can cause undefined behavior in the application.
        /// Heap functions should be called only on the default heap of the calling process and on private heaps that the process creates and manages.
        /// To obtain a handle to the process heap of the calling process, use the <see cref="GetProcessHeap"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessHeaps", SetLastError = true)]
        public static extern uint GetProcessHeaps([In]uint NumberOfHeaps, [In]IntPtr ProcessHeaps);

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
        /// Creates a private heap object that can be used by the calling process.
        /// The function reserves space in the virtual address space of the process and allocates physical storage
        /// for a specified initial portion of this block.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapcreate
        /// </para>
        /// </summary>
        /// <param name="flOptions">
        /// The heap allocation options.
        /// These options affect subsequent access to the new heap through calls to the heap functions.
        /// This parameter can be 0 or one or more of the following values.
        /// <see cref="HEAP_CREATE_ENABLE_EXECUTE"/>:
        /// All memory blocks that are allocated from this heap allow code execution, if the hardware enforces data execution prevention.
        /// Use this flag heap in applications that run code from the heap.
        /// If <see cref="HEAP_CREATE_ENABLE_EXECUTE"/> is not specified and an application attempts to run code from a protected page,
        /// the application receives an exception with the status code <see cref="STATUS_ACCESS_VIOLATION"/>.
        /// <see cref="HEAP_GENERATE_EXCEPTIONS"/>:
        /// The system raises an exception to indicate failure (for example, an out-of-memory condition)
        /// for calls to <see cref="HeapAlloc"/> and <see cref="HeapReAlloc"/> instead of returning <see cref="IntPtr.Zero"/>.
        /// <see cref="HEAP_NO_SERIALIZE"/>:
        /// Serialized access is not used when the heap functions access this heap.
        /// This option applies to all subsequent heap function calls.
        /// Alternatively, you can specify this option on individual heap function calls.
        /// The low-fragmentation heap(LFH) cannot be enabled for a heap created with this option.
        /// A heap created with this option cannot be locked.
        /// For more information about serialized access, see the Remarks section of this topic.
        /// </param>
        /// <param name="dwInitialSize">
        /// The initial size of the heap, in bytes. This value determines the initial amount of memory that is committed for the heap.
        /// The value is rounded up to a multiple of the system page size.
        /// The value must be smaller than <paramref name="dwMaximumSize"/>.
        /// If this parameter is 0, the function commits one page.
        /// To determine the size of a page on the host computer, use the <see cref="GetSystemInfo"/> function.
        /// </param>
        /// <param name="dwMaximumSize">
        /// The maximum size of the heap, in bytes.
        /// The <see cref="HeapCreate"/> function rounds <paramref name="dwMaximumSize"/> up to a multiple of the system page size and
        /// then reserves a block of that size in the process's virtual address space for the heap.
        /// If allocation requests made by the <see cref="HeapAlloc"/> or <see cref="HeapReAlloc"/> functions exceed
        /// the size specified by <paramref name="dwInitialSize"/>, the system commits additional pages of memory for the heap,
        /// up to the heap's maximum size.
        /// If <paramref name="dwMaximumSize"/> is not zero, the heap size is fixed and cannot grow beyond the maximum size.
        /// Also, the largest memory block that can be allocated from the heap is slightly less than 512 KB for a 32-bit process and
        /// slightly less than 1,024 KB for a 64-bit process.
        /// Requests to allocate larger blocks fail, even if the maximum size of the heap is large enough to contain the block.
        /// If <paramref name="dwMaximumSize"/> is 0, the heap can grow in size. The heap's size is limited only by the available memory.
        /// Requests to allocate memory blocks larger than the limit for a fixed-size heap do not automatically fail;
        /// instead, the system calls the <see cref="VirtualAlloc"/> function to obtain the memory that is needed for large blocks.
        /// Applications that need to allocate large memory blocks should set <paramref name="dwMaximumSize"/> to 0.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created heap.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="HeapCreate"/> function creates a private heap object from which the calling process can allocate memory blocks
        /// by using the <see cref="HeapAlloc"/> function.
        /// The initial size determines the number of committed pages that are allocated initially for the heap.
        /// The maximum size determines the total number of reserved pages.
        /// These pages create a block in the process's virtual address space into which the heap can grow.
        /// If requests by <see cref="HeapAlloc"/> exceed the current size of committed pages,
        /// additional pages are automatically committed from this reserved space, if the physical storage is available.
        /// Windows Server 2003 and Windows XP:
        /// By default, the newly created private heap is a standard heap.
        /// To enable the low-fragmentation heap, call the <see cref="HeapSetInformation"/> function with a handle to the private heap.
        /// The memory of a private heap object is accessible only to the process that created it.
        /// If a dynamic-link library (DLL) creates a private heap, the heap is created in the address space of the process that calls the DLL,
        /// and it is accessible only to that process.
        /// The system uses memory from the private heap to store heap support structures,
        /// so not all of the specified heap size is available to the process.
        /// For example, if the <see cref="HeapAlloc"/> function requests 64 kilobytes (K) from a heap with a maximum size of 64K,
        /// the request may fail because of system overhead.
        /// If <see cref="HEAP_NO_SERIALIZE"/> is not specified (the simple default), the heap serializes access within the calling process.
        /// Serialization ensures mutual exclusion when two or more threads attempt simultaneously to allocate or free blocks from the same heap.
        /// There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory from the same heap.
        /// The <see cref="HeapLock"/> and <see cref="HeapUnlock"/> functions can be used to block and permit access to a serialized heap.
        /// Setting <see cref="HEAP_NO_SERIALIZE"/> eliminates mutual exclusion on the heap.
        /// Without serialization, two or more threads that use the same heap handle might attempt to allocate or free memory simultaneously,
        /// which may cause corruption in the heap.
        /// Therefore, <see cref="HEAP_NO_SERIALIZE"/> can safely be used only in the following situations:
        /// The process has only one thread.
        /// The process has multiple threads, but only one thread calls the heap functions for a specific heap.
        /// The process has multiple threads, and the application provides its own mechanism for mutual exclusion to a specific heap.
        /// If the <see cref="HeapLock"/> and <see cref="HeapUnlock"/> functions are called on a heap created
        /// with the <see cref="HEAP_NO_SERIALIZE"/> flag, the results are undefined.
        /// To obtain a handle to the default heap for a process, use the <see cref="GetProcessHeap"/> function.
        /// To obtain handles to the default heap and private heaps that are active for the calling process,
        /// use the <see cref="GetProcessHeaps"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapAlloc", SetLastError = true)]
        public static extern IntPtr HeapCreate([In]HeapFlags flOptions, [In]IntPtr dwInitialSize, [In]IntPtr dwMaximumSize);

        /// <summary>
        /// <para>
        /// Frees a memory block allocated from a heap by the <see cref="HeapAlloc"/> or <see cref="HeapReAlloc"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapfree
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap whose memory block is to be freed.
        /// This handle is returned by either the <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// The heap free options.
        /// Specifying the following value overrides the corresponding value specified in the flOptions parameter 
        /// when the heap was created by using the <see cref="HeapCreate"/> function.
        /// <see cref="HEAP_NO_SERIALIZE"/>:
        /// Serialized access will not be used. For more information, see Remarks.
        /// To ensure that serialized access is disabled for all calls to this function,
        /// specify <see cref="HEAP_NO_SERIALIZE"/> in the call to <see cref="HeapCreate"/>.
        /// In this case, it is not necessary to additionally specify <see cref="HEAP_NO_SERIALIZE"/> in this function call.
        /// Do not specify this value when accessing the process heap.
        /// The system may create additional threads within the application's process,
        /// such as a CTRL+C handler, that simultaneously access the process heap.
        /// </param>
        /// <param name="lpMem">
        /// A pointer to the memory block to be freed.
        /// This pointer is returned by the <see cref="HeapAlloc"/> or <see cref="HeapReAlloc"/> function.
        /// If this pointer is <see cref="IntPtr.Zero"/>, the behavior is undefined.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// An application can call <see cref="GetLastError"/> for extended error information.
        /// </returns>
        /// <remarks>
        /// You should not refer in any way to memory that has been freed by <see cref="HeapFree"/>.
        /// After that memory is freed, any information that may have been in it is gone forever.
        /// If you require information, do not free memory containing the information.
        /// Function calls that return information about memory (such as HeapSize) may not be used with freed memory, as they may return bogus data.
        /// Calling <see cref="HeapFree"/> twice with the same pointer can cause heap corruption,
        /// resulting in subsequent calls to <see cref="HeapAlloc"/> returning the same pointer twice.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapFree", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapFree([In]IntPtr hHeap, [In]HeapFlags dwFlags, [In]IntPtr lpMem);

        /// <summary>
        /// <para>
        /// Attempts to acquire the critical section object, or lock, that is associated with a specified heap.
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap to be locked.
        /// This handle is returned by either the <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// An application can call <see cref="GetLastError"/> for extended error information.
        /// </returns>
        /// <remarks>
        /// If the function succeeds, the calling thread owns the heap lock.
        /// Only the calling thread will be able to allocate or release memory from the heap.
        /// The execution of any other thread of the calling process will be blocked if that thread attempts to allocate or release memory from the heap.
        /// Such threads will remain blocked until the thread that owns the heap lock calls the <see cref="HeapUnlock"/> function.
        /// The <see cref="HeapLock"/> function is primarily useful for preventing the allocation and
        /// release of heap memory by other threads while the calling thread uses the <see cref="HeapWalk"/> function.
        /// If the <see cref="HeapLock"/> function is called on a heap created with the <see cref="HEAP_NO_SERIALIZATION"/> flag, the results are undefined.
        /// Each successful call to <see cref="HeapLock"/> must be matched by a corresponding call to <see cref="HeapUnlock"/>.
        /// Failure to call <see cref="HeapUnlock"/> will block the execution of any other threads of the calling process that attempt to access the heap.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapLock", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapLock([In]IntPtr hHeap);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified heap.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapqueryinformation
        /// </para>
        /// </summary>
        /// <param name="HeapHandle">
        /// A handle to the heap whose information is to be retrieved.
        /// This handle is returned by either the <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <param name="HeapInformationClass">
        /// The class of information to be retrieved.
        /// This parameter can be the following value from the <see cref="HEAP_INFORMATION_CLASS"/> enumeration type.
        /// <see cref="HeapCompatibilityInformation"/>:
        /// Indicates the heap features that are enabled.
        /// The <paramref name="HeapInformation"/> parameter is a pointer to a ULONG variable.
        /// If <paramref name="HeapInformation"/> is 0, the heap is a standard heap that does not support look-aside lists.
        /// If <paramref name="HeapInformation"/> is 1, the heap supports look-aside lists. For more information, see Remarks.
        /// If <paramref name="HeapInformation"/> is 2, the low-fragmentation heap (LFH) has been enabled for the heap.
        /// Enabling the LFH disables look-aside lists.
        /// </param>
        /// <param name="HeapInformation">
        /// A pointer to a buffer that receives the heap information.
        /// The format of this data depends on the value of the <paramref name="HeapInformationClass"/> parameter.
        /// </param>
        /// <param name="HeapInformationLength">
        /// The size of the heap information being queried, in bytes.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable that receives the length of data written to the HeapInformation buffer.
        /// If the buffer is too small, the function fails and <paramref name="ReturnLength"/> specifies the minimum size required for the buffer.
        /// If you do not want to receive this information, specify <see langword="null"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To enable the LFH or the terminate-on-corruption feature, use the <see cref="HeapSetInformation"/> function.
        /// Windows XP and Windows Server 2003:   A look-aside list is a fast memory allocation mechanism that contains only fixed-sized blocks.
        /// Look-aside lists are enabled by default for heaps that support them.Starting with Windows Vista,
        /// look-aside lists are not used and the LFH is enabled by default.
        /// Look-aside lists are faster than general pool allocations that vary in size,
        /// because the system does not search for free memory that fits the allocation.
        /// In addition, access to look-aside lists is generally synchronized using fast atomic processor exchange instructions
        /// instead of mutexes or spinlocks.
        /// Look-aside lists can be created by the system or drivers.They can be allocated from paged or nonpaged pool.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapQueryInformation", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapQueryInformation([In]IntPtr HeapHandle, [In]HEAP_INFORMATION_CLASS HeapInformationClass,
            [In]IntPtr HeapInformation, [In]IntPtr HeapInformationLength, [Out]out IntPtr ReturnLength);

        /// <summary>
        /// <para>
        /// Reallocates a block of memory from a heap.
        /// This function enables you to resize a memory block and change other memory block properties.
        /// The allocated memory is not movable.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heaprealloc
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap from which the memory is to be reallocated.
        /// This handle is a returned by either the HeapCreate or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// The heap reallocation options.
        /// Specifying a value overrides the corresponding value specified in the flOptions parameter
        /// when the heap was created by using the <see cref="HeapCreate"/> function.
        /// This parameter can be one or more of the following values.
        /// <see cref="HEAP_GENERATE_EXCEPTIONS"/>:
        /// The operating-system raises an exception to indicate a function failure,
        /// such as an out-of-memory condition, instead of returning <see cref="IntPtr.Zero"/>.
        /// To ensure that exceptions are generated for all calls to this function,
        /// specify <see cref="HEAP_GENERATE_EXCEPTIONS"/> in the call to <see cref="HeapCreate"/>.
        /// In this case, it is not necessary to additionally specify <see cref="HEAP_GENERATE_EXCEPTIONS"/> in this function call.
        /// <see cref="HEAP_NO_SERIALIZE"/>:
        /// Serialized access will not be used. For more information, see Remarks.
        /// To ensure that serialized access is disabled for all calls to this function,
        /// specify <see cref="HEAP_NO_SERIALIZE"/> in the call to <see cref="HeapCreate"/>.
        /// In this case, it is not necessary to additionally specify <see cref="HEAP_NO_SERIALIZE"/> in this function call.
        /// This value should not be specified when accessing the process heap.
        /// The system may create additional threads within the application's process, such as a CTRL+C handler,
        /// that simultaneously access the process heap.
        /// <see cref="HEAP_REALLOC_IN_PLACE_ONLY"/>:
        /// There can be no movement when reallocating a memory block.
        /// If this value is not specified, the function may move the block to a new location.
        /// If this value is specified and the block cannot be resized without moving, the function fails, leaving the original memory block unchanged.
        /// <see cref="HEAP_ZERO_MEMORY"/>:
        /// If the reallocation request is for a larger size, the additional region of memory beyond the original size be initialized to zero.
        /// The contents of the memory block up to its original size are unaffected.
        /// </param>
        /// <param name="lpMem">
        /// A pointer to the block of memory that the function reallocates.
        /// This pointer is returned by an earlier call to the <see cref="HeapAlloc"/> or <see cref="HeapReAlloc"/> function.
        /// </param>
        /// <param name="dwBytes">
        /// The new size of the memory block, in bytes. A memory block's size can be increased or decreased by using this function.
        /// If the heap specified by the hHeap parameter is a "non-growable" heap, dwBytes must be less than 0x7FFF8.
        /// You create a non-growable heap by calling the <see cref="HeapCreate"/> function with a nonzero value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the reallocated memory block.
        /// If the function fails and you have not specified <see cref="HEAP_GENERATE_EXCEPTIONS"/>, the return value is <see cref="IntPtr.Zero"/>.
        /// If the function fails and you have specified <see cref="HEAP_GENERATE_EXCEPTIONS"/>,
        /// the function may generate either of the exceptions listed in the following table.
        /// For more information, see <see cref="Marshal.GetExceptionCode"/>.
        /// <see cref="STATUS_NO_MEMORY"/>: The allocation attempt failed because of a lack of available memory or heap corruption.
        /// <see cref="STATUS_ACCESS_VIOLATION"/>: The allocation attempt failed because of heap corruption or improper function parameters.
        /// If the function fails, it does not call <see cref="SetLastError"/>.
        /// An application cannot call <see cref="GetLastError"/> for extended error information.
        /// </returns>
        /// <remarks>
        /// If <see cref="HeapReAlloc"/> succeeds, it allocates at least the amount of memory requested.
        /// If <see cref="HeapReAlloc"/> fails, the original memory is not freed, and the original handle and pointer are still valid.
        /// <see cref="HeapReAlloc"/> is guaranteed to preserve the content of the memory being reallocated,
        /// even if the new memory is allocated at a different location.
        /// The process of preserving the memory content involves a memory copy operation that is potentially very time-consuming.
        /// To free a block of memory allocated by <see cref="HeapReAlloc"/>, use the <see cref="HeapFree"/> function.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapReAlloc", SetLastError = true)]
        public static extern IntPtr HeapReAlloc([In]IntPtr hHeap, [In]HeapFlags dwFlags, [In]IntPtr lpMem, [In]IntPtr dwBytes);

        /// <summary>
        /// <para>
        /// Enables features for a specified heap.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapsetinformation
        /// </para>
        /// </summary>
        /// <param name="HeapHandle">
        /// A handle to the heap where information is to be set.
        /// This handle is returned by either the <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <param name="HeapInformationClass">
        /// The class of information to be set.
        /// This parameter can be one of the following values from the <see cref="HEAP_INFORMATION_CLASS"/> enumeration type.
        /// <see cref="HeapCompatibilityInformation"/>:
        /// Enables heap features. Only the low-fragmentation heap (LFH) is supported.
        /// However, it is not necessary for applications to enable the LFH because the system uses the LFH as needed to service memory allocation requests.
        /// Windows XP and Windows Server 2003:
        /// The LFH is not enabled by default. To enable the LFH for the specified heap, set the variable pointed to by the HeapInformation parameter to 2.
        /// After the LFH is enabled for a heap, it cannot be disabled.
        /// The LFH cannot be enabled for heaps created with <see cref="HEAP_NO_SERIALIZE"/> or for heaps created with a fixed size.
        /// The LFH also cannot be enabled if you are using the heap debugging tools in Debugging Tools for Windows or Microsoft Application Verifier.
        /// When a process is run under any debugger, certain heap debug options are automatically enabled for all heaps in the process.
        /// These heap debug options prevent the use of the LFH.
        /// To enable the low-fragmentation heap when running under a debugger, set the _NO_DEBUG_HEAP environment variable to 1.
        /// <see cref="HeapEnableTerminationOnCorruption"/>:
        /// Enables the terminate-on-corruption feature.
        /// If the heap manager detects an error in any heap used by the process, it calls the Windows Error Reporting service and terminates the process.
        /// After a process enables this feature, it cannot be disabled.
        /// Windows Server 2003 and Windows XP:
        /// This value is not supported until Windows Vista and Windows XP with SP3.
        /// The function succeeds but the <see cref="HeapEnableTerminationOnCorruption"/> value is ignored.
        /// <see cref="HeapOptimizeResources"/>
        /// If <see cref="HeapSetInformation"/> is called with <paramref name="HeapHandle"/> set to <see cref="IntPtr.Zero"/>,
        /// then all heaps in the process with a low-fragmentation heap (LFH) will have their caches optimized,
        /// and the memory will be decommitted if possible.
        /// If a heap pointer is supplied in <paramref name="HeapHandle"/>, then only that heap will be optimized.
        /// Note that the <see cref="HEAP_OPTIMIZE_RESOURCES_INFORMATION"/> structure passed in HeapInformation must be properly initialized.
        /// Note This value was added in Windows 8.1.
        /// </param>
        /// <param name="HeapInformation">
        /// The heap information buffer. The format of this data depends on the value of the <paramref name="HeapInformationClass"/> parameter.
        /// If the <paramref name="HeapInformationClass"/> parameter is <see cref="HeapCompatibilityInformation"/>,
        /// the <paramref name="HeapInformation"/> parameter is a pointer to a ULONG variable.
        /// If the <paramref name="HeapInformationClass"/> parameter is <see cref="HeapEnableTerminationOnCorruption"/>,
        /// the <paramref name="HeapInformation"/> parameter should be <see cref="IntPtr.Zero"/> and <paramref name="HeapInformationLength"/> should be 0
        /// </param>
        /// <param name="HeapInformationLength">
        /// The size of the <paramref name="HeapInformation"/> buffer, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To retrieve the current settings for the heap, use the <see cref="HeapQueryInformation"/> function.
        /// Setting the <see cref="HeapEnableTerminationOnCorruption"/> option is strongly recommended
        /// because it reduces an application's exposure to security exploits that take advantage of a corrupted heap.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapSetInformation", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapSetInformation([In]IntPtr HeapHandle, [In]HEAP_INFORMATION_CLASS HeapInformationClass,
            [In]IntPtr HeapInformation, [In]IntPtr HeapInformationLength);

        /// <summary>
        /// <para>
        /// Releases ownership of the critical section object, or lock, that is associated with a specified heap.
        /// It reverses the action of the <see cref="HeapLock"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapunlock
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap to be unlocked.
        /// This handle is returned by either the <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="HeapLock"/> function is primarily useful for preventing the allocation
        /// and release of heap memory by other threads while the calling thread uses the <see cref="HeapWalk"/> function.
        /// The <see cref="HeapUnlock"/> function is the inverse of <see cref="HeapLock"/>.
        /// Each call to <see cref="HeapLock"/> must be matched by a corresponding call to the <see cref="HeapUnlock"/> function.
        /// Failure to call <see cref="HeapUnlock"/> will block the execution of any other threads of the calling process that attempt to access the heap.
        /// If the <see cref="HeapUnlock"/> function is called on a heap created with the <see cref="HEAP_NO_SERIALIZE"/> flag,
        /// the results are undefined.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapUnlock", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapUnlock([In]IntPtr hHeap);

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
