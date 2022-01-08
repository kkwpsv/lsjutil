using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GlobalMemoryFlags;
using static Lsj.Util.Win32.Enums.HEAP_INFORMATION_CLASS;
using static Lsj.Util.Win32.Enums.HeapFlags;
using static Lsj.Util.Win32.Enums.LocalMemoryFlags;
using static Lsj.Util.Win32.Enums.MEM_EXTENDED_PARAMETER_TYPE;
using static Lsj.Util.Win32.Enums.MemoryAllocationTypes;
using static Lsj.Util.Win32.Enums.MemoryProtectionConstants;
using static Lsj.Util.Win32.Enums.MemoryTypes;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.ProcessHeapFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.VirtualFreeTypes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// WRITE_WATCH_FLAG_RESET
        /// </summary>
        public const uint WRITE_WATCH_FLAG_RESET = 0x01;


        /// <summary>
        /// <para>
        /// Allocates physical memory pages to be mapped and unmapped within any Address Windowing Extensions (AWE) region of a specified process.
        /// 64-bit Windows on Itanium-based systems:
        /// Due to the difference in page sizes, AllocateUserPhysicalPages is not supported for 32-bit applications.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-allocateuserphysicalpages"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to a process.
        /// The function allocates memory that can later be mapped within the virtual address space of this process.
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="NumberOfPages">
        /// The size of the physical memory to allocate, in pages.
        /// To determine the page size of the computer, use the <see cref="GetSystemInfo"/> function.
        /// On output, this parameter receives the number of pages that are actually allocated, which might be less than the number requested.
        /// </param>
        /// <param name="PageArray">
        /// A pointer to an array to store the page frame numbers of the allocated memory.
        /// The size of the array that is allocated should be at least the <paramref name="NumberOfPages"/> times
        /// the size of the <see cref="ULONG_PTR"/> data type.
        /// Do not attempt to modify this buffer.
        /// It contains operating system data, and corruption could be catastrophic.
        /// The information in the buffer is not useful to an application.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// Fewer pages than requested can be allocated.
        /// The caller must check the value of the <paramref name="NumberOfPages"/> parameter on return to see how many pages are allocated.
        /// All allocated page frame numbers are sequentially placed in the memory pointed to by the <paramref name="PageArray"/> parameter.
        /// If the function fails, the return value is <see cref="FALSE"/>,
        /// and no frames are allocated. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="AllocateUserPhysicalPages"/> function is used to allocate physical memory
        /// that can later be mapped within the virtual address space of the process.
        /// The SeLockMemoryPrivilege privilege must be enabled in the caller's token
        /// or the function will fail with <see cref="ERROR_PRIVILEGE_NOT_HELD"/>.
        /// For more information, see Privilege Constants.
        /// Memory allocated by this function must be physically present in the system. After the memory is allocated,
        /// it is locked down and unavailable to the rest of the virtual memory management system.
        /// Physical pages cannot be simultaneously mapped at more than one virtual address.
        /// Physical pages can reside at any physical address. You should make no assumptions about the contiguity of the physical pages.
        /// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AllocateUserPhysicalPages", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AllocateUserPhysicalPages([In] HANDLE hProcess, [In][Out] ref ULONG_PTR NumberOfPages, [In] ULONG_PTR[] PageArray);

        /// <summary>
        /// <para>
        /// Allocates physical memory pages to be mapped and unmapped within any Address Windowing Extensions (AWE) region of a specified process
        /// and specifies the NUMA node for the physical memory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-allocateuserphysicalpagesnuma"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to a process.
        /// The function allocates memory that can later be mapped within the virtual address space of this process.
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="NumberOfPages">
        /// The size of the physical memory to allocate, in pages.
        /// To determine the page size of the computer, use the <see cref="GetSystemInfo"/> function.
        /// On output, this parameter receives the number of pages that are actually allocated, which might be less than the number requested.
        /// </param>
        /// <param name="PageArray">
        /// A pointer to an array to store the page frame numbers of the allocated memory.
        /// The size of the array that is allocated should be at least the <paramref name="NumberOfPages"/> times
        /// the size of the <see cref="ULONG_PTR"/> data type.
        /// Caution 
        /// Do not attempt to modify this buffer. It contains operating system data, and corruption could be catastrophic.
        /// The information in the buffer is not useful to an application.
        /// </param>
        /// <param name="nndPreferred">
        /// The NUMA node where the physical memory should reside.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// Fewer pages than requested can be allocated.
        /// The caller must check the value of the <paramref name="NumberOfPages"/> parameter on return to see how many pages are allocated.
        /// All allocated page frame numbers are sequentially placed in the memory pointed to by the PageArray parameter.
        /// If the function fails, the return value is <see cref="FALSE"/> and no frames are allocated.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// The <see cref="AllocateUserPhysicalPagesNuma"/> function is used to allocate physical memory within a NUMA node
        /// that can later be mapped within the virtual address space of the process.
        /// The SeLockMemoryPrivilege privilege must be enabled in the caller's token
        /// or the function will fail with <see cref="ERROR_PRIVILEGE_NOT_HELD"/>.
        /// For more information, see Privilege Constants.
        /// Memory allocated by this function must be physically present in the system.
        /// After the memory is allocated, it is locked down and unavailable to the rest of the virtual memory management system.
        /// Physical pages cannot be simultaneously mapped at more than one virtual address.
        /// Physical pages can reside at any physical address. You should make no assumptions about the contiguity of the physical pages.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AllocateUserPhysicalPagesNuma", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AllocateUserPhysicalPagesNuma([In] HANDLE hProcess, [In][Out] ref ULONG_PTR NumberOfPages,
            [In] ULONG_PTR[] PageArray, [In] DWORD nndPreferred);

        /// <summary>
        /// <para>
        /// Frees physical memory pages that are allocated previously
        /// by using <see cref="AllocateUserPhysicalPages"/> or <see cref="AllocateUserPhysicalPagesNuma"/>.
        /// If any of these pages are currently mapped in the Address Windowing Extensions (AWE) region, they are automatically unmapped by this call.
        /// This does not affect the virtual address space that is occupied by a specified Address Windowing Extensions (AWE) region.
        /// 64-bit Windows on Itanium-based systems:
        /// Due to the difference in page sizes, <see cref="FreeUserPhysicalPages"/> is not supported for 32-bit applications.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-freeuserphysicalpages"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// The handle to a process.
        /// The function frees memory within the virtual address space of this process.
        /// </param>
        /// <param name="NumberOfPages">
        /// The size of the physical memory to free, in pages.
        /// On return, if the function fails, this parameter indicates the number of pages that are freed.
        /// </param>
        /// <param name="PageArray">
        /// A pointer to an array of page frame numbers of the allocated memory to be freed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// In this case, the <paramref name="NumberOfPages"/> parameter reflect how many pages have actually been released.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// In a multiprocessor environment, this function maintains coherence of the hardware translation buffer.
        /// When this function returns, all threads on all processors are guaranteed to see the correct mapping.
        /// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeUserPhysicalPages", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FreeUserPhysicalPages([In] HANDLE hProcess, [In][Out] ref ULONG_PTR NumberOfPages,
            [MarshalAs(UnmanagedType.LPArray)][In][Out] ULONG_PTR[] PageArray);

        /// <summary>
        /// <para>
        /// Retrieves the minimum size of a large page.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-getlargepageminimum"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the processor supports large pages, the return value is the minimum size of a large page.
        /// If the processor does not support large pages, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The minimum large page size varies, but it is typically 2 MB or greater.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLargePageMinimum", ExactSpelling = true, SetLastError = true)]
        public static extern SIZE_T GetLargePageMinimum();

        /// <summary>
        /// <para>
        /// Retrieves a handle to the default heap of the calling process.
        /// This handle can then be used in subsequent calls to the heap functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-getprocessheap"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the calling process's heap.
        /// If the function fails, the return value is <see cref="NULL"/>.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessHeap", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE GetProcessHeap();

        /// <summary>
        /// <para>
        /// Returns the number of active heaps and retrieves handles to all of the active heaps for the calling process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-getprocessheaps"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessHeaps", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetProcessHeaps([In] DWORD NumberOfHeaps, [In][Out] HANDLE[] ProcessHeaps);

        /// <summary>
        /// <para>
        /// Retrieves the addresses of the pages that are written to in a region of virtual memory.
        /// 64-bit Windows on Itanium-based systems:
        /// Due to the difference in page sizes, <see cref="GetWriteWatch"/> is not supported for 32-bit applications.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-getwritewatch"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Indicates whether the function resets the write-tracking state.
        /// To reset the write-tracking state, set this parameter to <see cref="WRITE_WATCH_FLAG_RESET"/>.
        /// If this parameter is 0 (zero), <see cref="GetWriteWatch"/> does not reset the write-tracking state.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="lpBaseAddress">
        /// The base address of the memory region for which to retrieve write-tracking information.
        /// This address must be in a memory region that is allocated by the <see cref="VirtualAlloc"/> function using <see cref="MEM_WRITE_WATCH"/>.
        /// </param>
        /// <param name="dwRegionSize">
        /// The size of the memory region for which to retrieve write-tracking information, in bytes.
        /// </param>
        /// <param name="lpAddresses">
        /// A pointer to a buffer that receives an array of page addresses in the memory region.
        /// The addresses indicate the pages that have been written to since the region has been allocated or the write-tracking state has been reset.
        /// </param>
        /// <param name="lpdwCount">
        /// On input, this variable indicates the size of the <paramref name="lpAddresses"/> array, in array elements.
        /// On output, the variable receives the number of page addresses that are returned in the array.
        /// </param>
        /// <param name="lpdwGranularity">
        /// A pointer to a variable that receives the page size, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is 0 (zero).
        /// If the function fails, the return value is a nonzero value.
        /// </returns>
        /// <remarks>
        /// When you call the <see cref="VirtualAlloc"/> function to reserve or commit memory, you can specify <see cref="MEM_WRITE_WATCH"/>.
        /// This value causes the system to keep track of the pages that are written to in the committed memory region.
        /// You can call the <see cref="GetWriteWatch"/> function to retrieve the addresses of the pages
        /// that have been written to since the region has been allocated or the write-tracking state has been reset.
        /// To reset the write-tracking state, set the <see cref="WRITE_WATCH_FLAG_RESET"/> value in the <paramref name="dwFlags"/> parameter.
        /// Alternatively, you can call the <see cref="ResetWriteWatch"/> function to reset the write-tracking state.
        /// However, if you use <see cref="ResetWriteWatch"/>, you must ensure that no threads write to the region during the interval
        /// between the <see cref="GetWriteWatch"/> and <see cref="ResetWriteWatch"/> calls.
        /// Otherwise, there may be written pages that you do not detect.
        /// The <see cref="GetWriteWatch"/> function can be useful to profilers, debugging tools, or garbage collectors.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWriteWatch", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetWriteWatch([In] DWORD dwFlags, [In] PVOID lpBaseAddress, [In] SIZE_T dwRegionSize, [In] PVOID[] lpAddresses,
            [In][Out] ULONG_PTR[] lpdwCount, [Out] out DWORD lpdwGranularity);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern HGLOBAL GlobalAlloc(GlobalMemoryFlags uFlags, SIZE_T dwBytes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwMinFree"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalCompact", ExactSpelling = true, SetLastError = true)]
        public static extern SIZE_T GlobalCompact([In] DWORD dwMinFree);

        /// <summary>
        /// <para>
        /// Discards the specified global memory block. The lock count of the memory object must be zero.
        /// Note 
        /// The global functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a global function should be used.
        /// For more information, see Global and Local Functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globaldiscard"/>
        /// </para>
        /// </summary>
        /// <param name="h">
        /// A handle to the global memory object.
        /// This handle is returned by either the <see cref="GlobalAlloc"/> or <see cref="GlobalReAlloc"/> function.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Although <see cref="GlobalDiscard"/> discards the object's memory block, the handle to the object remains valid.
        /// The process can subsequently pass the handle to the <see cref="GlobalReAlloc"/> function to
        /// allocate another global memory block identified by the same handle.
        /// </remarks>
        public static HGLOBAL GlobalDiscard(HGLOBAL h) => GlobalReAlloc(h, 0, GMEM_MOVEABLE);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hMem"></param>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalFix", ExactSpelling = true, SetLastError = true)]
        public static extern void GlobalFix([In] HGLOBAL hMem);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified global memory object.
        /// Note
        /// This function is provided only for compatibility with 16-bit versions of Windows.
        /// New applications should use the heap functions.
        /// For more information, see Remarks.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalflags"/>
        /// </para>
        /// </summary>
        /// <param name="hMem">
        /// A handle to the global memory object.
        /// This handle is returned by either the <see cref="GlobalAlloc"/> or <see cref="GlobalReAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the allocation values and the lock count for the memory object.
        /// If the function fails, the return value is <see cref="GMEM_INVALID_HANDLE"/>, indicating that the global handle is not valid.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The low-order byte of the low-order word of the return value contains the lock count of the object.
        /// To retrieve the lock count from the return value, use the <see cref="GMEM_LOCKCOUNT"/> mask with the bitwise AND (&amp;) operator.
        /// The lock count of memory objects allocated with <see cref="GMEM_FIXED"/> is always zero.
        /// The high-order byte of the low-order word of the return value indicates the allocation values of the memory object.
        /// It can be zero or <see cref="GMEM_DISCARDED"/>.
        /// The global functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a global function should be used.
        /// For more information, see Global and Local Functions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalFlags", ExactSpelling = true, SetLastError = true)]
        public static extern GlobalMemoryFlags GlobalFlags([In] HGLOBAL hMem);

        /// <summary>
        /// <para>
        /// Frees the specified global memory object and invalidates its handle.
        /// Note The global functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a global function should be used.
        /// For more information, see Global and Local Functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalfree"/>
        /// </para>
        /// </summary>
        /// <param name="hMem">
        /// A handle to the global memory object.
        /// This handle is returned by either the <see cref="GlobalAlloc"/> or <see cref="GlobalReAlloc"/> function.
        /// It is not safe to free memory allocated with <see cref="LocalAlloc"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="IntPtr.Zero"/>.
        /// If the function fails, the return value is equal to a handle to the global memory object.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the process examines or modifies the memory after it has been freed,
        /// heap corruption may occur or an access violation exception (EXCEPTION_ACCESS_VIOLATION) may be generated.
        /// The <see cref="GlobalFree"/> function will free a locked memory object.
        /// A locked memory object has a lock count greater than zero.
        /// The <see cref="GlobalLock"/> function locks a global memory object and increments the lock count by one.
        /// The <see cref="GlobalUnlock"/> function unlocks it and decrements the lock count by one.
        /// To get the lock count of a global memory object, use the <see cref="GlobalFlags"/> function.
        /// If an application is running under a debug version of the system,
        /// <see cref="GlobalFree"/> will issue a message that tells you that a locked object is being freed.
        /// If you are debugging the application, <see cref="GlobalFree"/> will enter a breakpoint just before freeing a locked object.
        /// This allows you to verify the intended behavior, then continue execution.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalFree", ExactSpelling = true, SetLastError = true)]
        public static extern HGLOBAL GlobalFree(HGLOBAL hMem);

        /// <summary>
        /// <para>
        /// Retrieves the handle associated with the specified pointer to a global memory block.
        /// Note The global functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a global function should be used.
        /// For more information, see Global and Local Functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalhandle"/>
        /// </para>
        /// </summary>
        /// <param name="pMem">
        /// A pointer to the first byte of the global memory block.
        /// This pointer is returned by the <see cref="GlobalLock"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified global memory object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// When the <see cref="GlobalAlloc"/> function allocates a memory object with <see cref="GMEM_MOVEABLE"/>, it returns a handle to the object.
        /// The <see cref="GlobalLock"/> function converts this handle into a pointer to the memory block,
        /// and <see cref="GlobalHandle"/> converts the pointer back into a handle.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalHandle", ExactSpelling = true, SetLastError = true)]
        public static extern HGLOBAL GlobalHandle([In] LPCVOID pMem);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalLock", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID GlobalLock(HGLOBAL hMem);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hMem"></param>
        /// <returns></returns>
        [Obsolete]
        public static HANDLE GlobalLRUNewest(HGLOBAL hMem) => hMem;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hMem"></param>
        /// <returns></returns>
        [Obsolete]
        public static HANDLE GlobalLRUOldest(HGLOBAL hMem) => hMem;

        /// <summary>
        /// <para>
        /// Retrieves information about the system's current usage of both physical and virtual memory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalmemorystatus"/>
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to a <see cref="MEMORYSTATUS"/> structure.
        /// The <see cref="GlobalMemoryStatus"/> function stores information about current memory availability into this structure.
        /// </param>
        /// <remarks>
        /// On computers with more than 4 GB of memory, the <see cref="GlobalMemoryStatus"/> function can return incorrect information,
        /// reporting a value of –1 to indicate an overflow.
        /// For this reason, applications should use the <see cref="GlobalMemoryStatusEx"/> function instead.
        /// On Intel x86 computers with more than 2 GB and less than 4 GB of memory,
        /// the <see cref="GlobalMemoryStatus"/> function will always return 2 GB
        /// in the <see cref="MEMORYSTATUS.dwTotalPhys"/> member of the <see cref="MEMORYSTATUS"/> structure.
        /// Similarly, if the total available memory is between 2 and 4 GB,
        /// the <see cref="MEMORYSTATUS.dwAvailPhys"/> member of the <see cref="MEMORYSTATUS"/> structure will be rounded down to 2 GB.
        /// If the executable is linked using the /LARGEADDRESSAWARE linker option,
        /// then the <see cref="GlobalMemoryStatus"/> function will return the correct amount of physical memory in both members.
        /// The information returned by the <see cref="GlobalMemoryStatus"/> function is volatile.
        /// There is no guarantee that two sequential calls to this function will return the same information.
        /// </remarks>
        [Obsolete("GlobalMemoryStatus can return incorrect information. Use the GlobalMemoryStatusEx function instead.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalMemoryStatus", ExactSpelling = true, SetLastError = true)]
        public static extern void GlobalMemoryStatus([Out] out MEMORYSTATUS lpBuffer);

        /// <summary>
        /// <para>
        /// Retrieves information about the system's current usage of both physical and virtual memory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-globalmemorystatusex"/>
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to a MEMORYSTATUSEX structure that receives information about current memory availability.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// You can use the <see cref="GlobalMemoryStatusEx"/> function to determine
        /// how much memory your application can allocate without severely impacting other applications.
        /// The information returned by the <see cref="GlobalMemoryStatusEx"/> function is volatile.
        /// There is no guarantee that two sequential calls to this function will return the same information.
        /// The <see cref="MEMORYSTATUSEX.ullAvailPhys"/> member of the <see cref="MEMORYSTATUSEX"/> structure
        /// at <paramref name="lpBuffer"/> includes memory for all NUMA nodes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalMemoryStatusEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GlobalMemoryStatusEx([In][Out] ref MEMORYSTATUSEX lpBuffer);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalReAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern HGLOBAL GlobalReAlloc(HGLOBAL hMem, SIZE_T dwBytes, GlobalMemoryFlags uFlags);

        /// <summary>
        /// <para>
        /// Retrieves the current size of the specified global memory object, in bytes.
        /// Note The global functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a global function should be used.
        /// For more information, see Global and Local Functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalsize"/>
        /// </para>
        /// </summary>
        /// <param name="hMem">
        /// A handle to the global memory object.
        /// This handle is returned by either the <see cref="GlobalAlloc"/> or <see cref="GlobalReAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the size of the specified global memory object, in bytes.
        /// If the specified handle is not valid or if the object has been discarded, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The size of a memory block may be larger than the size requested when the memory was allocated.
        /// To verify that the specified object's memory block has not been discarded,
        /// use the <see cref="GlobalFlags"/> function before calling <see cref="GlobalSize"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalSize", ExactSpelling = true, SetLastError = true)]
        public static extern SIZE_T GlobalSize([In] HGLOBAL hMem);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hMem"></param>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalUnfix", ExactSpelling = true, SetLastError = true)]
        public static extern void GlobalUnfix([In] HGLOBAL hMem);

        /// <summary>
        /// <para>
        /// Decrements the lock count associated with a memory object that was allocated with <see cref="GMEM_MOVEABLE"/>.
        /// This function has no effect on memory objects allocated with <see cref="GMEM_FIXED"/>.
        /// Note The global functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a global function should be used.
        /// For more information, see Global and Local Functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalunlock"/>
        /// </para>
        /// </summary>
        /// <param name="hMem">
        /// A handle to the global memory object.
        /// This handle is returned by either the <see cref="GlobalAlloc"/> or <see cref="GlobalReAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the memory object is still locked after decrementing the lock count, the return value is a <see cref="BOOL.TRUE"/> value.
        /// If the memory object is unlocked after decrementing the lock count,
        /// the function returns <see cref="BOOL.FALSE"/> and <see cref="GetLastError"/> returns <see cref="NO_ERROR"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/> and
        /// <see cref="GetLastError"/> returns a value other than <see cref="NO_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// The internal data structures for each memory object include a lock count that is initially zero.
        /// For movable memory objects, the <see cref="GlobalLock"/> function increments the count by one,
        /// and <see cref="GlobalUnlock"/> decrements the count by one.
        /// For each call that a process makes to <see cref="GlobalLock"/> for an object, it must eventually call <see cref="GlobalUnlock"/>.
        /// Locked memory will not be moved or discarded, unless the memory object is reallocated by using the <see cref="GlobalReAlloc"/> function.
        /// The memory block of a locked memory object remains locked until its lock count is decremented to zero, at which time it can be moved or discarded.
        /// Memory objects allocated with <see cref="GMEM_FIXED"/> always have a lock count of zero.
        /// If the specified memory block is fixed memory, this function returns <see cref="BOOL.TRUE"/>.
        /// If the memory object is already unlocked, <see cref="GlobalUnlock"/> returns <see cref="BOOL.FALSE"/>
        /// and <see cref="GetLastError"/> reports <see cref="ERROR_NOT_LOCKED"/>.
        /// A process should not rely on the return value to determine the number of times
        /// it must subsequently call <see cref="GlobalUnlock"/> for a memory object.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalUnlock", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GlobalUnlock([In] HGLOBAL hMem);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hMem"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalUnWire", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GlobalUnWire([In] HGLOBAL hMem);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hMem"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalWire", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID GlobalWire([In] HGLOBAL hMem);

        /// <summary>
        /// <para>
        /// Retrieves information about the first heap that has been allocated by a specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/tlhelp32/nf-tlhelp32-heap32listfirst"/>
        /// </para>
        /// </summary>
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the <see cref="CreateToolhelp32Snapshot"/> function.
        /// </param>
        /// <param name="lphl">
        /// A pointer to a <see cref="HEAPLIST32"/> structure.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the first entry of the heap list has been copied to the buffer or <see cref="FALSE"/> otherwise.
        /// The <see cref="ERROR_NO_MORE_FILES"/> error value is returned by the <see cref="GetLastError"/> function
        /// when no heap list exists or the snapshot does not contain heap list information.
        /// </returns>
        /// <remarks>
        /// The calling application must set the <see cref="HEAPLIST32.dwSize"/> member of <see cref="HEAPLIST32"/> to the size,
        /// in bytes, of the structure.
        /// <see cref="Heap32ListFirst"/> changes <see cref="HEAPLIST32.dwSize"/> to the number of bytes written to the structure.
        /// This will never be greater than the initial value of <see cref="HEAPLIST32.dwSize"/>, but it may be smaller.
        /// If the value is smaller, do not rely on the values of any members whose offsets are greater than this value.
        /// To retrieve information about other heaps in the heap list, use the <see cref="Heap32ListNext"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Heap32ListFirst", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Heap32ListFirst([In] HANDLE hSnapshot, [In][Out] ref HEAPLIST32 lphl);

        /// <summary>
        /// <para>
        /// Retrieves information about the next heap that has been allocated by a process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/tlhelp32/nf-tlhelp32-heap32listnext"/>
        /// </para>
        /// </summary>
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the <see cref="CreateToolhelp32Snapshot"/> function.
        /// </param>
        /// <param name="lphl">
        /// A pointer to a <see cref="HEAPLIST32"/> structure.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the next entry of the heap list has been copied to the buffer or <see cref="FALSE"/> otherwise.
        /// The <see cref="ERROR_NO_MORE_FILES"/> error value is returned by the <see cref="GetLastError"/> function
        /// when no more entries in the heap list exist.
        /// </returns>
        /// <remarks>
        /// To retrieve information about the first heap in a heap list, use the <see cref="Heap32ListFirst"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Heap32ListNext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Heap32ListNext([In] HANDLE hSnapshot, [In][Out] ref HEAPLIST32 lphl);

        /// <summary>
        /// <para>
        /// Allocates a block of memory from a heap. The allocated memory is not movable.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapalloc"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID HeapAlloc([In] HANDLE hHeap, [In] HeapFlags dwFlags, [In] SIZE_T dwBytes);

        /// <summary>
        /// <para>
        /// Returns the size of the largest committed free block in the specified heap.
        /// If the Disable heap coalesce on free global flag is set, this function also coalesces adjacent free blocks of memory in the heap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapcompact"/>
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap.
        /// This handle is returned by either the <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// The heap access options. This parameter can be the following value.
        /// <see cref="HEAP_NO_SERIALIZE"/>:
        /// Serialized access will not be used.
        /// For more information, see Remarks.
        /// To ensure that serialized access is disabled for all calls to this function, specify <see cref="HEAP_NO_SERIALIZE"/> in the call to <see cref="HeapCreate"/>.
        /// In this case, it is not necessary to additionally specify <see cref="HEAP_NO_SERIALIZE"/> in this function call.
        /// Do not specify this value when accessing the process heap.
        /// The system may create additional threads within the application's process, such as a CTRL+C handler, that simultaneously access the process heap.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the size of the largest committed free block in the heap, in bytes.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// In the unlikely case that there is absolutely no space available in the heap,
        /// the function return value is zero, and <see cref="GetLastError"/> returns the value <see cref="NO_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="HeapCompact"/> function is primarily useful for debugging.
        /// Ordinarily, the system compacts the heap whenever the HeapFree function is called,
        /// and the <see cref="HeapCompact"/> function returns the size of the largest free block in the heap but does not compact the heap any further.
        /// If the Disable heap coalesce on free global flag is set during debugging, the system does not compact the heap
        /// and calling the <see cref="HeapCompact"/> function does compact the heap.
        /// For more information about global flags, see the GFlags documentation.
        /// There is no guarantee that an application can successfully allocate a memory block of the size returned by <see cref="HeapCompact"/>.
        /// Other threads or the commit threshold might prevent such an allocation.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapCompact", ExactSpelling = true, SetLastError = true)]
        public static extern SIZE_T HeapCompact([In] HANDLE hHeap, [In] HeapFlags dwFlags);

        /// <summary>
        /// <para>
        /// Creates a private heap object that can be used by the calling process.
        /// The function reserves space in the virtual address space of the process and allocates physical storage
        /// for a specified initial portion of this block.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapcreate"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE HeapCreate([In] HeapFlags flOptions, [In] SIZE_T dwInitialSize, [In] SIZE_T dwMaximumSize);

        /// <summary>
        /// <para>
        /// Destroys the specified heap object.
        /// It decommits and releases all the pages of a private heap object, and it invalidates the handle to the heap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapdestroy"/>
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap to be destroyed.
        /// This handle is returned by the <see cref="HeapCreate"/> function.
        /// Do not use the handle to the process heap returned by the <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Processes can call <see cref="HeapDestroy"/> without first calling the <see cref="HeapFree"/> function
        /// to free memory allocated from the heap.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapDestroy", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HeapDestroy([In] HANDLE hHeap);

        /// <summary>
        /// <para>
        /// Frees a memory block allocated from a heap by the <see cref="HeapAlloc"/> or <see cref="HeapReAlloc"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapfree"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapFree", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HeapFree([In] DWORD hHeap, [In] HeapFlags dwFlags, [In] LPVOID lpMem);

        /// <summary>
        /// <para>
        /// Attempts to acquire the critical section object, or lock, that is associated with a specified heap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heaplock"/>
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
        /// If the <see cref="HeapLock"/> function is called on a heap created with the <see cref="HEAP_NO_SERIALIZE"/> flag, the results are undefined.
        /// Each successful call to <see cref="HeapLock"/> must be matched by a corresponding call to <see cref="HeapUnlock"/>.
        /// Failure to call <see cref="HeapUnlock"/> will block the execution of any other threads of the calling process that attempt to access the heap.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapLock", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HeapLock([In] HANDLE hHeap);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified heap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapqueryinformation"/>
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
        /// The <paramref name="HeapInformation"/> parameter is a pointer to a <see cref="ULONG"/> variable.
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
        /// A pointer to a variable that receives the length of data written to the <paramref name="HeapInformation"/> buffer.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapQueryInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HeapQueryInformation([In] HANDLE HeapHandle, [In] HEAP_INFORMATION_CLASS HeapInformationClass,
            [In] PVOID HeapInformation, [In] SIZE_T HeapInformationLength, [Out] out SIZE_T ReturnLength);

        /// <summary>
        /// <para>
        /// Reallocates a block of memory from a heap.
        /// This function enables you to resize a memory block and change other memory block properties.
        /// The allocated memory is not movable.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heaprealloc"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapReAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID HeapReAlloc([In] HANDLE hHeap, [In] HeapFlags dwFlags, [In] LPVOID lpMem, [In] SIZE_T dwBytes);

        /// <summary>
        /// <para>
        /// Enables features for a specified heap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapsetinformation"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapSetInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HeapSetInformation([In] HANDLE HeapHandle, [In] HEAP_INFORMATION_CLASS HeapInformationClass,
            [In] PVOID HeapInformation, [In] SIZE_T HeapInformationLength);

        /// <summary>
        /// <para>
        /// Retrieves the size of a memory block allocated from a heap by the <see cref="HeapAlloc"/> or <see cref="HeapReAlloc"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapsize"/>
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap in which the memory block resides.
        /// This handle is returned by either the <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// The heap size options.
        /// Specifying the following value overrides the corresponding value specified in the flOptions parameter
        /// when the heap was created by using the <see cref="HeapCreate"/> function.
        /// <see cref="HEAP_NO_SERIALIZE"/>:
        /// Serialized access will not be used.
        /// For more information, see Remarks.
        /// To ensure that serialized access is disabled for all calls to this function,
        /// specify <see cref="HEAP_NO_SERIALIZE"/> in the call to <see cref="HeapCreate"/>.
        /// In this case, it is not necessary to additionally specify <see cref="HEAP_NO_SERIALIZE"/> in this function call.
        /// This value should not be specified when accessing the process heap.
        /// The system may create additional threads within the application's process, such as a CTRL+C handler,
        /// that simultaneously access the process heap.
        /// </param>
        /// <param name="lpMem">
        /// A pointer to the memory block whose size the function will obtain.
        /// This is a pointer returned by the <see cref="HeapAlloc"/> or <see cref="HeapReAlloc"/> function.
        /// The memory block must be from the heap specified by the hHeap parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the requested size of the allocated memory block, in bytes.
        /// If the function fails, the return value is <code>(SIZE_T)-1</code>.
        /// The function does not call <see cref="SetLastError"/>.
        /// An application cannot call <see cref="GetLastError"/> for extended error information.
        /// If the <paramref name="lpMem"/> parameter refers to a heap allocation that is not in the heap specified by the hHeap parameter,
        /// the behavior of the <see cref="HeapSize"/> function is undefined.
        /// </returns>
        /// <remarks>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapSize", ExactSpelling = true, SetLastError = true)]
        public static extern SIZE_T HeapSize([In] HANDLE hHeap, [In] HeapFlags dwFlags, [In] LPCVOID lpMem);

        /// <summary>
        /// <para>
        /// Summarizes the specified heap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapsummary"/>
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap to be summarized.
        /// This handle is returned by either the <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// The heap summary options.
        /// </param>
        /// <param name="lpSummary">
        /// Receives a pointer to a <see cref="Heap_Summary"/> structure representing the heap summary.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> on success.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapSummary", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HeapSummary([In] HANDLE hHeap, [In] DWORD dwFlags, [Out] out HEAP_SUMMARY lpSummary);

        /// <summary>
        /// <para>
        /// Releases ownership of the critical section object, or lock, that is associated with a specified heap.
        /// It reverses the action of the <see cref="HeapLock"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapunlock"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapUnlock", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HeapUnlock([In] HANDLE hHeap);

        /// <summary>
        /// <para>
        /// Validates the specified heap.
        /// The function scans all the memory blocks in the heap and verifies that the heap control structures
        /// maintained by the heap manager are in a consistent state.
        /// You can also use the <see cref="HeapValidate"/> function to validate a single memory block
        /// within a specified heap without checking the validity of the entire heap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapvalidate"/>
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap to be validated.
        /// This handle is returned by either the <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// The heap access options. This parameter can be the following value.
        /// <see cref="HEAP_NO_SERIALIZE"/>:
        /// Serialized access will not be used.
        /// For more information, see Remarks.
        /// To ensure that serialized access is disabled for all calls to this function,
        /// specify <see cref="HEAP_NO_SERIALIZE"/> in the call to <see cref="HeapCreate"/>.
        /// In this case, it is not necessary to additionally specify <see cref="HEAP_NO_SERIALIZE"/> in this function call.
        /// This value should not be specified when accessing the process default heap.
        /// The system may create additional threads within the application's process, such as a CTRL+C handler,
        /// that simultaneously access the process default heap.
        /// </param>
        /// <param name="lpMem">
        /// A pointer to a memory block within the specified heap.
        /// This parameter may be <see cref="NULL"/>.
        /// If this parameter is <see cref="NULL"/>, the function attempts to validate the entire heap specified by <paramref name="hHeap"/>.
        /// If this parameter is not <see cref="NULL"/>, the function attempts to validate the memory block pointed to by <paramref name="lpMem"/>.
        /// It does not attempt to validate the rest of the heap.
        /// </param>
        /// <returns>
        /// If the specified heap or memory block is valid, the return value is <see cref="TRUE"/>.
        /// If the specified heap or memory block is invalid, the return value is <see cref="FALSE"/>.
        /// On a system set up for debugging, the <see cref="HeapValidate"/> function then displays debugging messages 
        /// that describe the part of the heap or memory block that is invalid,
        /// and stops at a hard-coded breakpoint so that you can examine the system to determine the source of the invalidity.
        /// The <see cref="HeapValidate"/> function does not set the thread's last error value.
        /// There is no extended error information for this function; do not call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="HeapValidate"/> function is primarily useful for debugging because validation is potentially time-consuming.
        /// Validating a heap can block other threads from accessing the heap and can degrade performance,
        /// especially on symmetric multiprocessing (SMP) computers.
        /// These side effects can last until <see cref="HeapValidate"/> returns.
        /// There are heap control structures for each memory block in a heap, and for the heap as a whole.
        /// When you use the <see cref="HeapValidate"/> function to validate a complete heap,
        /// it checks all of these control structures for consistency.
        /// When you use <see cref="HeapValidate"/> to validate a single memory block within a heap,
        /// it checks only the control structures pertaining to that element.
        /// <see cref="HeapValidate"/> can only validate allocated memory blocks.
        /// Calling <see cref="HeapValidate"/> on a freed memory block will return <see cref="FALSE"/>
        /// because there are no control structures to validate.
        /// If you want to validate the heap elements enumerated by the <see cref="HeapWalk"/> function,
        /// you should only call <see cref="HeapValidate"/> on the elements that have <see cref="PROCESS_HEAP_ENTRY_BUSY"/>
        /// in the <see cref="PROCESS_HEAP_ENTRY.wFlags"/> member of the <see cref="PROCESS_HEAP_ENTRY"/> structure.
        /// <see cref="HeapValidate"/> returns <see cref="FALSE"/> for all heap elements that do not have this bit set.
        /// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same heap.
        /// There is a small performance cost to serialization,
        /// but it must be used whenever multiple threads allocate and free memory from the same heap.
        /// Setting the <see cref="HEAP_NO_SERIALIZE"/> value eliminates mutual exclusion on the heap.
        /// Without serialization, two or more threads that use the same heap handle might attempt to allocate or free memory simultaneously,
        /// likely causing corruption in the heap.
        /// The <see cref="HEAP_NO_SERIALIZE"/> value can, therefore, be safely used only in the following situations:
        /// The process has only one thread.
        /// The process has multiple threads, but only one thread calls the heap functions for a specific heap.
        /// The process has multiple threads, and the application provides its own mechanism for mutual exclusion to a specific heap.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapValidate", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HeapValidate([In] HANDLE hHeap, [In] HeapFlags dwFlags, [In] LPCVOID lpMem);

        /// <summary>
        /// <para>
        /// Enumerates the memory blocks in the specified heap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/heapapi/nf-heapapi-heapwalk"/>
        /// </para>
        /// </summary>
        /// <param name="hHeap">
        /// A pointer to a <see cref="PROCESS_HEAP_ENTRY"/> structure that maintains state information for a particular heap enumeration.
        /// </param>
        /// <param name="lpEntry">
        /// If the <see cref="HeapWalk"/> function succeeds, returning the value <see langword="true"/>,
        /// this structure's members contain information about the next memory block in the heap.
        /// To initiate a heap enumeration, set the <see cref="PROCESS_HEAP_ENTRY.lpData"/> field
        /// of the <see cref="PROCESS_HEAP_ENTRY"/> structure to <see cref="IntPtr.Zero"/>.
        /// To continue a particular heap enumeration, call the <see cref="HeapWalk"/> function repeatedly, with no changes to <paramref name="hHeap"/>,
        /// <paramref name="lpEntry"/>, or any of the members of the <see cref="PROCESS_HEAP_ENTRY"/> structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the heap enumeration terminates successfully by reaching the end of the heap, the function returns <see langword="false"/>,
        /// and <see cref="GetLastError"/> returns the error code <see cref="ERROR_NO_MORE_ITEMS"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="HeapWalk"/> function is primarily useful for debugging because enumerating a heap is a potentially time-consuming operation.
        /// Locking the heap during enumeration blocks other threads from accessing the heap and can degrade performance, 
        /// especially on symmetric multiprocessing (SMP) computers.
        /// The side effects can last until the heap is unlocked.
        /// Use the <see cref="HeapLock"/> and <see cref="HeapUnlock"/> functions to control heap locking during heap enumeration.
        /// To initiate a heap enumeration, call <see cref="PROCESS_HEAP_ENTRY"/>
        /// with the <see cref="PROCESS_HEAP_ENTRY.lpData"/> field of the <see cref="PROCESS_HEAP_ENTRY"/> structure pointed to
        /// by <paramref name="lpEntry"/> set to <see cref="IntPtr.Zero"/>.
        /// To continue a heap enumeration, call <see cref="HeapWalk"/> with the same <paramref name="hHeap"/> and <paramref name="lpEntry"/> values,
        /// and with the <see cref="PROCESS_HEAP_ENTRY"/> structure unchanged from the preceding call to <see cref="HeapWalk"/>.
        /// Repeat this process until you have no need for further enumeration, or until the function returns <see langword="false"/>
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_NO_MORE_ITEMS"/>,
        /// indicating that all of the heap's memory blocks have been enumerated.
        /// No special call of <see cref="HeapWalk"/> is needed to terminate the heap enumeration,
        /// since no enumeration state data is maintained outside the contents of the <see cref="PROCESS_HEAP_ENTRY"/> structure.
        /// <see cref="HeapWalk"/> can fail in a multithreaded application if the heap is not locked during the heap enumeration.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "HeapWalk", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HeapWalk([In] HANDLE hHeap, [In][Out] ref PROCESS_HEAP_ENTRY lpEntry);

        /// <summary>
        /// <para>
        /// Allocates the specified number of bytes from the heap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-localalloc"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern HLOCAL LocalAlloc(LocalMemoryFlags uFlags, SIZE_T uBytes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uMinFree"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalCompact", ExactSpelling = true, SetLastError = true)]
        public static extern SIZE_T LocalCompact([In] UINT uMinFree);

        /// <summary>
        /// <para>
        /// Discards the specified local memory object. The lock count of the memory object must be zero.
        /// Note The local functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a local function should be used.
        /// For more information, see Global and Local Functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/nf-minwinbase-localdiscard"/>
        /// </para>
        /// </summary>
        /// <param name="h">
        /// A handle to the local memory object.
        /// This handle is returned by either the <see cref="LocalAlloc"/> or <see cref="LocalReAlloc"/> function.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Although LocalDiscard discards the object's memory block, the handle to the object remains valid.
        /// A process can subsequently pass the handle to the <see cref="LocalReAlloc"/> function
        /// to allocate another local memory object identified by the same handle.
        /// </remarks>
        public static HLOCAL LocalDiscard(HLOCAL h) => LocalReAlloc(h, 0, LMEM_MOVEABLE);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified local memory object.
        /// Note This function is provided only for compatibility with 16-bit versions of Windows.
        /// New applications should use the heap functions.
        /// For more information, see Remarks.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-localflags"/>
        /// </para>
        /// </summary>
        /// <param name="hMem">
        /// A handle to the local memory object.
        /// This handle is returned by either the <see cref="LocalAlloc"/> or <see cref="LocalReAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the allocation values and the lock count for the memory object.
        /// If the function fails, the return value is <see cref="LMEM_INVALID_HANDLE"/>, indicating that the local handle is not valid.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The low-order byte of the low-order word of the return value contains the lock count of the object.
        /// To retrieve the lock count from the return value, use the <see cref="LMEM_LOCKCOUNT"/> mask with the bitwise AND (&amp;) operator.
        /// The lock count of memory objects allocated with <see cref="LMEM_FIXED"/> is always zero.
        /// The high-order byte of the low-order word of the return value indicates the allocation values of the memory object.
        /// It can be zero or <see cref="LMEM_DISCARDABLE"/>.
        /// The local functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a local function should be used.
        /// For more information, see Global and Local Functions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalFree", ExactSpelling = true, SetLastError = true)]
        public static extern LocalMemoryFlags LocalFlags([In] HLOCAL hMem);

        /// <summary>
        /// <para>
        /// Frees the specified local memory object and invalidates its handle.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-localfree"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalFree", ExactSpelling = true, SetLastError = true)]
        public static extern HLOCAL LocalFree([In] HLOCAL hMem);

        /// <summary>
        /// <para>
        /// Retrieves the handle associated with the specified pointer to a local memory object.
        /// Note The local functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a local function should be used.
        /// For more information, see Global and Local Functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-localhandle"/>
        /// </para>
        /// </summary>
        /// <param name="pMem">
        /// A pointer to the first byte of the local memory object.
        /// This pointer is returned by the <see cref="LocalLock"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified local memory object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// When the <see cref="LocalAlloc"/> function allocates a local memory object with <see cref="LMEM_MOVEABLE"/>, it returns a handle to the object.
        /// The <see cref="LocalLock"/> function converts this handle into a pointer to the object's memory block,
        /// and <see cref="LocalHandle"/> converts the pointer back into a handle.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalHandle", ExactSpelling = true, SetLastError = true)]
        public static extern HLOCAL LocalHandle([In] LPCVOID pMem);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalLock", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID LocalLock(HLOCAL hMem);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalReAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern HLOCAL LocalReAlloc(HLOCAL hMem, SIZE_T uBytes, LocalMemoryFlags uFlags);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hMem"></param>
        /// <param name="cbNewSize"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalShrink", ExactSpelling = true, SetLastError = true)]
        public static extern SIZE_T LocalShrink([In] HLOCAL hMem, [In] UINT cbNewSize);

        /// <summary>
        /// <para>
        /// Retrieves the current size of the specified local memory object, in bytes.
        /// Note The local functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a local function should be used.
        /// For more information, see Global and Local Functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-localsize"/>
        /// </para>
        /// </summary>
        /// <param name="hMem">
        /// A handle to the local memory object.
        /// This handle is returned by the <see cref="LocalAlloc"/>, <see cref="LocalReAlloc"/>, or <see cref="LocalHandle"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the size of the specified local memory object, in bytes.
        /// If the specified handle is not valid or if the object has been discarded, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The size of a memory block may be larger than the size requested when the memory was allocated.
        /// To verify that the specified object's memory block has not been discarded,
        /// call the <see cref="LocalFlags"/> function before calling <see cref="LocalSize"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalSize", ExactSpelling = true, SetLastError = true)]
        public static extern SIZE_T LocalSize([In] HLOCAL hMem);

        /// <summary>
        /// <para>
        /// Decrements the lock count associated with a memory object that was allocated with <see cref="LMEM_MOVEABLE"/>.
        /// This function has no effect on memory objects allocated with <see cref="LMEM_FIXED"/>.
        /// Note The local functions have greater overhead and provide fewer features than other memory management functions.
        /// New applications should use the heap functions unless documentation states that a local function should be used.
        /// For more information, see Global and Local Functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-localunlock"/>
        /// </para>
        /// </summary>
        /// <param name="hMem">
        /// A handle to the local memory object.
        /// This handle is returned by either the <see cref="LocalAlloc"/> or <see cref="LocalReAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the memory object is still locked after decrementing the lock count, the return value is <see cref="TRUE"/>.
        /// If the memory object is unlocked after decrementing the lock count,
        /// the function returns <see cref="FALSE"/> and <see cref="GetLastError"/> returns <see cref="NO_ERROR"/>.
        /// If the function fails, the return value is <see cref="FALSE"/> and <see cref="GetLastError"/> returns a value other than <see cref="NO_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// The internal data structures for each memory object include a lock count that is initially zero.
        /// For movable memory objects, the <see cref="LocalLock"/> function increments the count by one,
        /// and <see cref="LocalUnlock"/> decrements the count by one.
        /// For each call that a process makes to <see cref="LocalLock"/> for an object, it must eventually call <see cref="LocalUnlock"/>.
        /// Locked memory will not be moved or discarded unless the memory object is reallocated by using the <see cref="LocalReAlloc"/> function.
        /// The memory block of a locked memory object remains locked until its lock count is decremented to zero, at which time it can be moved or discarded.
        /// If the memory object is already unlocked, <see cref="LocalUnlock"/> returns <see cref="BOOL.FALSE"/>
        /// and <see cref="GetLastError"/> reports <see cref="ERROR_NOT_LOCKED"/>.
        /// Memory objects allocated with <see cref="LMEM_FIXED"/> always have a lock count of zero and cause the <see cref="ERROR_NOT_LOCKED"/> error.
        /// A process should not rely on the return value to determine the number of times
        /// it must subsequently call <see cref="LocalUnlock"/> for the memory block.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalUnlock", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LocalUnlock([In] HLOCAL hMem);

        /// <summary>
        /// 
        /// </summary>
        [Obsolete]
        public static void LockSegment(UINT w) => GlobalFix((HANDLE)(IntPtr)(int)w);

        /// <summary>
        /// <para>
        /// Maps previously allocated physical memory pages at a specified address in an Address Windowing Extensions (AWE) region.
        /// To perform batch mapping and unmapping of multiple regions, use the <see cref="MapUserPhysicalPagesScatter"/> function.
        /// 64-bit Windows on Itanium-based systems:
        /// Due to the difference in page sizes, <see cref="MapUserPhysicalPages"/> is not supported for 32-bit applications.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-mapuserphysicalpages"/>
        /// </para>
        /// </summary>
        /// <param name="VirtualAddress">
        /// A pointer to the starting address of the region of memory to remap.
        /// The value of <paramref name="VirtualAddress"/> must be within the address range that the <see cref="VirtualAlloc"/> function returns
        /// when the Address Windowing Extensions (AWE) region is allocated.
        /// </param>
        /// <param name="NumberOfPages">
        /// The size of the physical memory and virtual address space for which to establish translations, in pages.
        /// The virtual address range is contiguous starting at lpAddress.
        /// The physical frames are specified by the UserPfnArray.
        /// The total number of pages cannot extend from the starting address
        /// beyond the end of the range that is specified in <see cref="AllocateUserPhysicalPages"/>.
        /// </param>
        /// <param name="PageArray">
        /// A pointer to an array of physical page frame numbers.
        /// These frames are mapped by the argument lpAddress on return from this function.
        /// The size of the memory that is allocated should be at least the <paramref name="NumberOfPages"/> times
        /// the size of the data type <see cref="ULONG_PTR"/>.
        /// Do not attempt to modify this buffer.
        /// It contains operating system data, and corruption could be catastrophic.
        /// The information in the buffer is not useful to an application.
        /// If this parameter is <see langword="null"/>, the specified address range is unmapped.
        /// Also, the specified physical pages are not freed, and you must call <see cref="FreeUserPhysicalPages"/> to free them.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/> and no mapping is done—partial or otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The physical pages are unmapped but they are not freed.
        /// You must call <see cref="FreeUserPhysicalPages"/> to free the physical pages.
        /// Any number of physical memory pages can be specified, but the memory must not extend
        /// outside the virtual address space that <see cref="VirtualAlloc"/> allocates.
        /// Any existing address maps are automatically overwritten with the new translations, and the old translations are unmapped.
        /// You cannot map physical memory pages outside the range that is specified in <see cref="AllocateUserPhysicalPages"/>.
        /// You can map multiple regions simultaneously, but they cannot overlap.
        /// Physical pages can be located at any physical address, but do not make assumptions about the contiguity of the physical pages.
        /// To unmap the current address range, specify <see langword="null"/> as the physical memory page array parameter.
        /// Any currently mapped pages are unmapped, but are not freed.
        /// You must call <see cref="FreeUserPhysicalPages"/> to free the physical pages.
        /// In a multiprocessor environment, this function maintains hardware translation buffer coherence.
        /// On return from this function, all threads on all processors are guaranteed to see the correct mapping.
        /// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapUserPhysicalPages", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MapUserPhysicalPages([In] PVOID VirtualAddress, [In] ULONG_PTR NumberOfPages, [In] ULONG_PTR[] PageArray);

        /// <summary>
        /// <para>
        /// Maps previously allocated physical memory pages at a specified address in an Address Windowing Extensions (AWE) region.
        /// 64-bit Windows on Itanium-based systems:
        /// Due to the difference in page sizes, <see cref="MapUserPhysicalPagesScatter"/> is not supported for 32-bit applications.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-mapuserphysicalpagesscatter"/>
        /// </para>
        /// </summary>
        /// <param name="VirtualAddresses">
        /// A pointer to an array of starting addresses of the regions of memory to remap.
        /// Each entry in <paramref name="VirtualAddresses"/> must be within the address range that the <see cref="VirtualAlloc"/> function returns
        /// when the Address Windowing Extensions (AWE) region is allocated.
        /// The value in <paramref name="NumberOfPages"/> indicates the size of the array.
        /// Entries can be from multiple Address Windowing Extensions (AWE) regions.
        /// </param>
        /// <param name="NumberOfPages">
        /// The size of the physical memory and virtual address space for which to establish translations, in pages.
        /// The array at <paramref name="VirtualAddresses"/> specifies the virtual address range.
        /// </param>
        /// <param name="PageArray">
        /// A pointer to an array of values that indicates how each corresponding page in <paramref name="VirtualAddresses"/> should be treated.
        /// A 0 (zero) indicates that the corresponding entry in VirtualAddresses should be unmapped, and any nonzero value that it has should be mapped.
        /// If this parameter is <see langword="null"/>, then every address in the <paramref name="VirtualAddresses"/> array is unmapped.
        /// The value in <paramref name="NumberOfPages"/> indicates the size of the array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>, and the function does not map or unmap—partial or otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The physical pages may be unmapped, but they are not freed.
        /// You must call <see cref="FreeUserPhysicalPages"/> to free the physical pages.
        /// You can specify any number of physical memory pages,
        /// but the memory cannot extend outside the virtual address space that is allocated by <see cref="VirtualAlloc"/>.
        /// Any existing address maps are automatically overwritten with the new translations, and the old translations are unmapped.
        /// You cannot map physical memory pages outside the range that is specified in <see cref="AllocateUserPhysicalPages"/>.
        /// You can map multiple regions simultaneously, but they cannot overlap.
        /// Physical pages can be located at any physical address, but do not make assumptions about the contiguity of the physical pages.
        /// In a multiprocessor environment, this function maintains hardware translation buffer coherence.
        /// On return from this function, all threads on all processors are guaranteed to see the correct mapping.
        /// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapUserPhysicalPagesScatter", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MapUserPhysicalPagesScatter([MarshalAs(UnmanagedType.LPArray)][In] PVOID[] VirtualAddresses,
            [In] ULONG_PTR NumberOfPages, [MarshalAs(UnmanagedType.LPArray)][In] ULONG_PTR[] PageArray);

        /// <summary>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-readprocessmemory"/>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process with memory that is being read.
        /// The handle must have <see cref="PROCESS_VM_READ"/> access to the process.
        /// </param>
        /// <param name="lpBaseAddress">
        /// A pointer to the base address in the specified process from which to read.
        /// Before any data transfer occurs, the system verifies that all data in the base address and memory of the specified size
        /// is accessible for read access, and if it is not accessible the function fails.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the contents from the address space of the specified process.
        /// </param>
        /// <param name="nSize">
        /// The number of bytes to be read from the specified process.
        /// </param>
        /// <param name="lpNumberOfBytesRead">
        /// A pointer to a variable that receives the number of bytes transferred into the specified buffer.
        /// If <paramref name="lpNumberOfBytesRead"/> is <see cref="NullRef{SIZE_T}"/>, the parameter is ignored.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The function fails if the requested read operation crosses into an area of the process that is inaccessible.
        /// </returns>
        /// <remarks>
        /// <see cref="ReadProcessMemory"/> copies the data in the specified address range from the address space of the specified process
        /// into the specified buffer of the current process.
        /// Any process that has a handle with <see cref="PROCESS_VM_READ"/> access can call the function.
        /// The entire area to be read must be accessible, and if it is not accessible, the function fails.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReadProcessMemory([In] HANDLE hProcess, [In] LPCVOID lpBaseAddress, [In] LPVOID lpBuffer,
            [In] SIZE_T nSize, [Out] out SIZE_T lpNumberOfBytesRead);

        /// <summary>
        /// <para>
        /// Resets the write-tracking state for a region of virtual memory.
        /// Subsequent calls to the <see cref="GetWriteWatch"/> function only report pages that are written to since the reset operation.
        /// 64-bit Windows on Itanium-based systems:
        /// Due to the difference in page sizes, <see cref="ResetWriteWatch"/> is not supported for 32-bit applications.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-resetwritewatch"/>
        /// </para>
        /// </summary>
        /// <param name="lpBaseAddress">
        /// A pointer to the base address of the memory region for which to reset the write-tracking state.
        /// This address must be in a memory region that is allocated by the <see cref="VirtualAlloc"/> function with <see cref="MEM_WRITE_WATCH"/>.
        /// </param>
        /// <param name="dwRegionSize">
        /// The size of the memory region for which to reset the write-tracking information, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is 0 (zero).
        /// If the function fails, the return value is a nonzero value.
        /// </returns>
        /// <remarks>
        /// The <see cref="ResetWriteWatch"/> function can be useful to an application such as a garbage collector.
        /// The application calls the <see cref="GetWriteWatch"/> function to retrieve the list of written pages,
        /// and then writes to those pages as part of its cleanup operation.
        /// Then the garbage collector calls <see cref="ResetWriteWatch"/> to remove the write-tracking records caused by the cleanup.
        /// You can also reset the write-tracking state of a memory region
        /// by specifying <see cref="WRITE_WATCH_FLAG_RESET"/> when you call <see cref="GetWriteWatch"/>.
        /// If you use <see cref="ResetWriteWatch"/>, you must ensure that no threads write to the region
        /// during the interval between the <see cref="GetWriteWatch"/> and <see cref="ResetWriteWatch"/> calls.
        /// Otherwise, there may be written pages that you not detect.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ResetWriteWatch", ExactSpelling = true, SetLastError = true)]
        public static extern UINT ResetWriteWatch([In] LPVOID lpBaseAddress, [In] SIZE_T dwRegionSize);

        /// <summary>
        /// 
        /// </summary>
        [Obsolete]
        public static void UnlockSegment(UINT w) => GlobalUnfix((HANDLE)(IntPtr)(int)w);

        /// <summary>
        /// <para>
        /// Reserves, commits, or changes the state of a region of pages in the virtual address space of the calling process.
        /// Memory allocated by this function is automatically initialized to zero.
        /// To allocate memory in the address space of another process, use the <see cref="VirtualAllocEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualalloc"/>
        /// </para>
        /// </summary>
        /// <param name="lpAddress">
        /// The starting address of the region to allocate.
        /// If the memory is being reserved, the specified address is rounded down to the nearest multiple of the allocation granularity.
        /// If the memory is already reserved and is being committed, the address is rounded down to the next page boundary.
        /// To determine the size of a page and the allocation granularity on the host computer, use the <see cref="GetSystemInfo"/> function.
        /// If this parameter is <see cref="NULL"/>, the system determines where to allocate the region.
        /// If this address is within an enclave that you have not initialized by calling <see cref="InitializeEnclave"/>,
        /// <see cref="VirtualAlloc"/> allocates a page of zeros for the enclave at that address.
        /// The page must be previously uncommitted, and will not be measured with the EEXTEND instruction
        /// of the Intel Software Guard Extensions programming model.
        /// If the address in within an enclave that you initialized, then the allocation operation fails with the <see cref="ERROR_INVALID_ADDRESS"/> error.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region, in bytes.
        /// If the <paramref name="lpAddress"/> parameter is <see cref="NULL"/>, this value is rounded up to the next page boundary.
        /// Otherwise, the allocated pages include all pages containing one or more bytes 
        /// in the range from <paramref name="lpAddress"/> to <paramref name="lpAddress"/>+<paramref name="dwSize"/>.
        /// This means that a 2-byte range straddling a page boundary causes both pages to be included in the allocated region.
        /// </param>
        /// <param name="flAllocationType">
        /// The type of memory allocation.
        /// This parameter must contain one of the following values.
        /// <see cref="MEM_COMMIT"/>:
        /// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages.
        /// The function also guarantees that when the caller later initially accesses the memory, the contents will be zero.
        /// Actual physical pages are not allocated unless/until the virtual addresses are actually accessed.
        /// To reserve and commit pages in one step, call <see cref="VirtualAlloc"/> with <code>MEM_COMMIT | MEM_RESERVE</code>.
        /// Attempting to commit a specific address range by specifying <see cref="MEM_COMMIT"/>
        /// without <see cref="MEM_RESERVE"/> and a non-<see cref="NULL"/> <paramref name="lpAddress"/> fails
        /// unless the entire range has already been reserved.
        /// The resulting error code is <see cref="ERROR_INVALID_ADDRESS"/>.
        /// An attempt to commit a page that is already committed does not cause the function to fail.
        /// This means that you can commit pages without first determining the current commitment state of each page.
        /// If <paramref name="lpAddress"/> specifies an address within an enclave, <paramref name="flAllocationType"/> must be <see cref="MEM_COMMIT"/>.
        /// <see cref="MEM_RESERVE"/>:
        /// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory or in the paging file on disk.
        /// You can commit reserved pages in subsequent calls to the <see cref="VirtualAlloc"/> function.
        /// To reserve and commit pages in one step, call <see cref="VirtualAlloc"/> with <code>MEM_COMMIT | MEM_RESERVE</code>.
        /// Other memory allocation functions, such as malloc and <see cref="LocalAlloc"/>, cannot use a reserved range of memory until it is released.
        /// <see cref="MEM_RESET"/>:
        /// Indicates that data in the memory range specified by lpAddress and dwSize is no longer of interest.
        /// The pages should not be read from or written to the paging file.
        /// However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other value.
        /// Using this value does not guarantee that the range operated on with <see cref="MEM_RESET"/> will contain zeros.
        /// If you want the range to contain zeros, decommit the memory and then recommit it.
        /// When you specify <see cref="MEM_RESET"/>, the <see cref="VirtualAlloc"/> function ignores the value of <paramref name="flProtect"/>.
        /// However, you must still set <paramref name="flProtect"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// <see cref="VirtualAlloc"/> returns an error if you use <see cref="MEM_RESET"/> and the range of memory is mapped to a file.
        /// A shared view is only acceptable if it is mapped to a paging file.
        /// <see cref="MEM_RESET_UNDO"/>:
        /// <see cref="MEM_RESET_UNDO"/> should only be called on an address range to which <see cref="MEM_RESET"/> was successfully applied earlier.
        /// It indicates that the data in the specified memory range specified by <paramref name="lpAddress"/> and <paramref name="dwSize"/>
        /// is of interest to the caller and attempts to reverse the effects of <see cref="MEM_RESET"/>.
        /// If the function succeeds, that means all data in the specified address range is intact.
        /// If the function fails, at least some of the data in the address range has been replaced with zeroes.
        /// This value cannot be used with any other value.
        /// If <see cref="MEM_RESET_UNDO"/> is called on an address range which was not <see cref="MEM_RESET"/> earlier, the behavior is undefined.
        /// When you specify <see cref="MEM_RESET"/>, the <see cref="VirtualAlloc"/> function ignores the value of <paramref name="flProtect"/>.
        /// However, you must still set <paramref name="flProtect"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
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
        /// <see cref="MEM_WRITE_WATCH"/>:
        /// Causes the system to track pages that are written to in the allocated region.
        /// If you specify this value, you must also specify <see cref="MEM_RESERVE"/>.
        /// To retrieve the addresses of the pages that have been written to since the region was allocated or the write-tracking state was reset,
        /// call the <see cref="GetWriteWatch"/> function.
        /// To reset the write-tracking state, call <see cref="GetWriteWatch"/> or <see cref="ResetWriteWatch"/>.
        /// The write-tracking feature remains enabled for the memory region until the region is freed.
        /// </param>
        /// <param name="flProtect">
        /// The memory protection for the region of pages to be allocated.
        /// If the pages are being committed, you can specify any one of the memory protection constants.
        /// If <paramref name="lpAddress"/> specifies an address within an enclave, <paramref name="flProtect"/> cannot be any of the following values:
        /// <see cref="PAGE_NOACCESS"/>, <see cref="PAGE_GUARD"/>, <see cref="PAGE_NOCACHE"/>, <see cref="PAGE_WRITECOMBINE"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the base address of the allocated region of pages.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Each page has an associated page state.
        /// The <see cref="VirtualAlloc"/> function can perform the following operations:
        /// Commit a region of reserved pages
        /// Reserve a region of free pages
        /// Simultaneously reserve and commit a region of free pages
        /// <see cref="VirtualAlloc"/> cannot reserve a reserved page. It can commit a page that is already committed.
        /// This means you can commit a range of pages, regardless of whether they have already been committed, and the function will not fail.
        /// You can use <see cref="VirtualAlloc"/> to reserve a block of pages and
        /// then make additional calls to <see cref="VirtualAlloc"/> to commit individual pages from the reserved block.
        /// This enables a process to reserve a range of its virtual address space without consuming physical storage until it is needed.
        /// If the <paramref name="lpAddress"/> parameter is not <see cref="NULL"/>,
        /// the function uses the <paramref name="lpAddress"/> and <paramref name="dwSize"/> parameters to compute the region of pages to be allocated.
        /// The current state of the entire range of pages must be compatible
        /// with the type of allocation specified by the <paramref name="flAllocationType"/> parameter.
        /// Otherwise, the function fails and none of the pages are allocated.
        /// This compatibility requirement does not preclude committing an already committed page, as mentioned previously.
        /// To execute dynamically generated code, use <see cref="VirtualAlloc"/> to allocate memory
        /// and the <see cref="VirtualProtect"/> function to grant <see cref="PAGE_EXECUTE"/> access.
        /// The <see cref="VirtualAlloc"/> function can be used to reserve an Address Windowing Extensions (AWE) region of memory
        /// within the virtual address space of a specified process.
        /// This region of memory can then be used to map physical pages into and out of virtual memory as required by the application.
        /// The <see cref="MEM_PHYSICAL"/> and <see cref="MEM_RESERVE"/> values must be set in the <paramref name="flAllocationType"/> parameter.
        /// The <see cref="MEM_COMMIT"/> value must not be set. The page protection must be set to <see cref="PAGE_READWRITE"/>.
        /// The <see cref="VirtualFree"/> function can decommit a committed page, releasing the page's storage,
        /// or it can simultaneously decommit and release a committed page.
        /// It can also release a reserved page, making it a free page.
        /// When creating a region that will be executable, the calling program bears responsibility
        /// for ensuring cache coherency via an appropriate call to <see cref="FlushInstructionCache"/> once the code has been set in place.
        /// Otherwise attempts to execute code out of the newly executable region may produce unpredictable results.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID VirtualAlloc([In] LPVOID lpAddress, [In] SIZE_T dwSize, [In] MemoryAllocationTypes flAllocationType,
            [In] MemoryProtectionConstants flProtect);

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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualalloc2"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualAlloc2", ExactSpelling = true, SetLastError = true)]
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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualalloc2fromapp"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualAlloc2FromApp", ExactSpelling = true, SetLastError = true)]
        public static extern PVOID VirtualAlloc2FromApp([In] HANDLE Process, [In] PVOID BaseAddress, [In] SIZE_T Size,
            [In] MemoryAllocationTypes AllocationType, [In] MemoryProtectionConstants PageProtection,
            [MarshalAs(UnmanagedType.LPArray)][In] MEM_EXTENDED_PARAMETER[] ExtendedParameters, [In] ULONG ParameterCount);

        /// <summary>
        /// <para>
        /// Reserves, commits, or changes the state of a region of memory within the virtual address space of a specified process.
        /// The function initializes the memory it allocates to zero.
        /// To specify the NUMA node for the physical memory, see <see cref="VirtualAllocExNuma"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualallocex"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// The handle to a process.
        /// The function allocates memory within the virtual address space of this process.
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpAddress">
        /// The pointer that specifies a desired starting address for the region of pages that you want to allocate.
        /// If you are reserving memory, the function rounds this address down to the nearest multiple of the allocation granularity.
        /// If you are committing memory that is already reserved, the function rounds this address down to the nearest page boundary.
        /// To determine the size of a page and the allocation granularity on the host computer, use the <see cref="GetSystemInfo"/> function.
        /// If <paramref name="lpAddress"/> is <see cref="NULL"/>, the function determines where to allocate the region.
        /// If this address is within an enclave that you have not initialized by calling <see cref="InitializeEnclave"/>,
        /// <see cref="VirtualAllocEx"/> allocates a page of zeros for the enclave at that address.
        /// The page must be previously uncommitted, and will not be measured
        /// with the EEXTEND instruction of the Intel Software Guard Extensions programming model.
        /// If the address in within an enclave that you initialized,
        /// then the allocation operation fails with the <see cref="ERROR_INVALID_ADDRESS"/> error.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region of memory to allocate, in bytes.
        /// If <paramref name="lpAddress"/> is <see cref="NULL"/>, the function rounds <paramref name="dwSize"/> up to the next page boundary.
        /// If <paramref name="lpAddress"/> is not <see cref="NULL"/>, the function allocates all pages
        /// that contain one or more bytes in the range from <paramref name="lpAddress"/> to <paramref name="lpAddress"/>+<paramref name="dwSize"/>.
        /// This means, for example, that a 2-byte range that straddles a page boundary causes the function to allocate both pages.
        /// </param>
        /// <param name="flAllocationType">
        /// The type of memory allocation. This parameter must contain one of the following values.
        /// <see cref="MEM_COMMIT"/>:
        /// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages.
        /// The function also guarantees that when the caller later initially accesses the memory,
        /// the contents will be zero. Actual physical pages are not allocated unless/until the virtual addresses are actually accessed.
        /// To reserve and commit pages in one step, call <see cref="VirtualAllocEx"/> with <code>MEM_COMMIT | MEM_RESERVE</code>.
        /// Attempting to commit a specific address range by specifying <see cref="MEM_COMMIT"/>
        /// without <see cref="MEM_RESERVE"/> and a non-NULL lpAddress fails unless the entire range has already been reserved.
        /// The resulting error code is <see cref="ERROR_INVALID_ADDRESS"/>.
        /// An attempt to commit a page that is already committed does not cause the function to fail.
        /// This means that you can commit pages without first determining the current commitment state of each page.
        /// If <paramref name="lpAddress"/> specifies an address within an enclave, <paramref name="flAllocationType"/> must be <see cref="MEM_COMMIT"/>.
        /// <see cref="MEM_RESERVE"/>:
        /// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory or in the paging file on disk.
        /// You commit reserved pages by calling <see cref="VirtualAllocEx"/> again with <see cref="MEM_COMMIT"/>.
        /// To reserve and commit pages in one step, call <see cref="VirtualAllocEx"/> with <code>MEM_COMMIT | MEM_RESERVE</code>.
        /// Other memory allocation functions, such as malloc and <see cref="LocalAlloc"/>, cannot use reserved memory until it has been released.
        /// <see cref="MEM_RESET"/>:
        /// Indicates that data in the memory range specified by lpAddress and <paramref name="dwSize"/> is no longer of interest.
        /// The pages should not be read from or written to the paging file.
        /// However, the memory block will be used again later, so it should not be decommitted.
        /// This value cannot be used with any other value.
        /// Using this value does not guarantee that the range operated on with <see cref="MEM_RESET"/> will contain zeros.
        /// If you want the range to contain zeros, decommit the memory and then recommit it.
        /// When you use <see cref="MEM_RESET"/>, the <see cref="VirtualAllocEx"/> function ignores the value of <paramref name="flProtect"/>.
        /// However, you must still set <paramref name="flProtect"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// VirtualAllocEx returns an error if you use <see cref="MEM_RESET"/> and the range of memory is mapped to a file.
        /// A shared view is only acceptable if it is mapped to a paging file.
        /// <see cref="MEM_RESET_UNDO"/>:
        /// <see cref="MEM_RESET_UNDO"/> should only be called on an address range to which <see cref="MEM_RESET"/> was successfully applied earlier.
        /// It indicates that the data in the specified memory range specified by <paramref name="lpAddress"/> and <paramref name="dwSize"/> is
        /// of interest to the caller and attempts to reverse the effects of <see cref="MEM_RESET"/>.
        /// If the function succeeds, that means all data in the specified address range is intact.
        /// If the function fails, at least some of the data in the address range has been replaced with zeroes.
        /// This value cannot be used with any other value.
        /// If <see cref="MEM_RESET_UNDO"/> is called on an address range which was not <see cref="MEM_RESET"/> earlier, the behavior is undefined.
        /// When you specify <see cref="MEM_RESET"/>, the <see cref="VirtualAllocEx"/> function ignores the value of <paramref name="flProtect"/>.
        /// However, you must still set <paramref name="flProtect"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
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
        /// <param name="flProtect">
        /// The memory protection for the region of pages to be allocated.
        /// If the pages are being committed, you can specify any one of the memory protection constants.
        /// If <paramref name="lpAddress"/> specifies an address within an enclave, <paramref name="flProtect"/> cannot be any of the following values:
        /// <see cref="PAGE_NOACCESS"/>, <see cref="PAGE_GUARD"/>, <see cref="PAGE_NOCACHE"/>, <see cref="PAGE_WRITECOMBINE"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the base address of the allocated region of pages.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Each page has an associated page state.
        /// The <see cref="VirtualAllocEx"/> function can perform the following operations:
        /// Commit a region of reserved pages
        /// Reserve a region of free pages
        /// Simultaneously reserve and commit a region of free pages
        /// <see cref="VirtualAllocEx"/> cannot reserve a reserved page. It can commit a page that is already committed.
        /// This means you can commit a range of pages, regardless of whether they have already been committed, and the function will not fail.
        /// You can use <see cref="VirtualAllocEx"/> to reserve a block of pages and
        /// then make additional calls to <see cref="VirtualAllocEx"/> to commit individual pages from the reserved block.
        /// This enables a process to reserve a range of its virtual address space without consuming physical storage until it is needed.
        /// If the <paramref name="lpAddress"/> parameter is not <see cref="NULL"/>,
        /// the function uses the <paramref name="lpAddress"/> and <paramref name="dwSize"/> parameters to compute the region of pages to be allocated.
        /// The current state of the entire range of pages must be compatible
        /// with the type of allocation specified by the <paramref name="flAllocationType"/> parameter.
        /// Otherwise, the function fails and none of the pages is allocated.
        /// This compatibility requirement does not preclude committing an already committed page; see the preceding list.
        /// To execute dynamically generated code, use <see cref="VirtualAllocEx"/> to allocate memory
        /// and the <see cref="VirtualProtectEx"/> function to grant <see cref="PAGE_EXECUTE"/> access.
        /// The <see cref="VirtualAllocEx"/> function can be used to reserve an Address Windowing Extensions (AWE) region of memory
        /// within the virtual address space of a specified process.
        /// This region of memory can then be used to map physical pages into and out of virtual memory as required by the application.
        /// The <see cref="MEM_PHYSICAL"/> and <see cref="MEM_RESERVE"/> values must be set in the <paramref name="flAllocationType"/> parameter.
        /// The <see cref="MEM_COMMIT"/> value must not be set. The page protection must be set to <see cref="PAGE_READWRITE"/>.
        /// The <see cref="VirtualFreeEx"/> function can decommit a committed page, releasing the page's storage,
        /// or it can simultaneously decommit and release a committed page.
        /// It can also release a reserved page, making it a free page.
        /// When creating a region that will be executable, the calling program bears responsibility for ensuring cache coherency
        /// via an appropriate call to <see cref="FlushInstructionCache"/> once the code has been set in place.
        /// Otherwise attempts to execute code out of the newly executable region may produce unpredictable results.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualAllocEx", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID VirtualAllocEx([In] HANDLE hProcess, [In] LPVOID lpAddress, [In] SIZE_T dwSize,
            [In] MemoryAllocationTypes flAllocationType, [In] MemoryProtectionConstants flProtect);

        /// <summary>
        /// <para>
        /// Reserves, commits, or changes the state of a region of memory within the virtual address space of the specified process,
        /// and specifies the NUMA node for the physical memory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualallocexnuma"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// The handle to a process. The function allocates memory within the virtual address space of this process.
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpAddress">
        /// The pointer that specifies a desired starting address for the region of pages that you want to allocate.
        /// If you are reserving memory, the function rounds this address down to the nearest multiple of the allocation granularity.
        /// If you are committing memory that is already reserved, the function rounds this address down to the nearest page boundary.
        /// To determine the size of a page and the allocation granularity on the host computer, use the <see cref="GetSystemInfo"/> function.
        /// If <paramref name="lpAddress"/> is <see cref="NULL"/>, the function determines where to allocate the region.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region of memory to allocate, in bytes.
        /// If <paramref name="lpAddress"/> is <see cref="NULL"/>, the function rounds <paramref name="dwSize"/> up to the next page boundary.
        /// If <paramref name="lpAddress"/> is not <see cref="NULL"/>, the function allocates all pages
        /// that contain one or more bytes in the range from <paramref name="lpAddress"/> to <paramref name="lpAddress"/>+<paramref name="dwSize"/>.
        /// This means, for example, that a 2-byte range that straddles a page boundary causes the function to allocate both pages.
        /// </param>
        /// <param name="flAllocationType">
        /// The type of memory allocation. This parameter must contain one of the following values.
        /// <see cref="MEM_COMMIT"/>:
        /// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages.
        /// The function also guarantees that when the caller later initially accesses the memory,
        /// the contents will be zero. Actual physical pages are not allocated unless/until the virtual addresses are actually accessed.
        /// To reserve and commit pages in one step, call <see cref="VirtualAllocEx"/> with <code>MEM_COMMIT | MEM_RESERVE</code>.
        /// Attempting to commit a specific address range by specifying <see cref="MEM_COMMIT"/>
        /// without <see cref="MEM_RESERVE"/> and a non-NULL lpAddress fails unless the entire range has already been reserved.
        /// The resulting error code is <see cref="ERROR_INVALID_ADDRESS"/>.
        /// An attempt to commit a page that is already committed does not cause the function to fail.
        /// This means that you can commit pages without first determining the current commitment state of each page.
        /// If <paramref name="lpAddress"/> specifies an address within an enclave, <paramref name="flAllocationType"/> must be <see cref="MEM_COMMIT"/>.
        /// <see cref="MEM_RESERVE"/>:
        /// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory or in the paging file on disk.
        /// You commit reserved pages by calling <see cref="VirtualAllocEx"/> again with <see cref="MEM_COMMIT"/>.
        /// To reserve and commit pages in one step, call <see cref="VirtualAllocEx"/> with <code>MEM_COMMIT | MEM_RESERVE</code>.
        /// Other memory allocation functions, such as malloc and <see cref="LocalAlloc"/>, cannot use reserved memory until it has been released.
        /// <see cref="MEM_RESET"/>:
        /// Indicates that data in the memory range specified by lpAddress and <paramref name="dwSize"/> is no longer of interest.
        /// The pages should not be read from or written to the paging file.
        /// However, the memory block will be used again later, so it should not be decommitted.
        /// This value cannot be used with any other value.
        /// Using this value does not guarantee that the range operated on with <see cref="MEM_RESET"/> will contain zeros.
        /// If you want the range to contain zeros, decommit the memory and then recommit it.
        /// When you use <see cref="MEM_RESET"/>, the <see cref="VirtualAllocEx"/> function ignores the value of <paramref name="flProtect"/>.
        /// However, you must still set <paramref name="flProtect"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
        /// VirtualAllocEx returns an error if you use <see cref="MEM_RESET"/> and the range of memory is mapped to a file.
        /// A shared view is only acceptable if it is mapped to a paging file.
        /// <see cref="MEM_RESET_UNDO"/>:
        /// <see cref="MEM_RESET_UNDO"/> should only be called on an address range to which <see cref="MEM_RESET"/> was successfully applied earlier.
        /// It indicates that the data in the specified memory range specified by <paramref name="lpAddress"/> and <paramref name="dwSize"/> is
        /// of interest to the caller and attempts to reverse the effects of <see cref="MEM_RESET"/>.
        /// If the function succeeds, that means all data in the specified address range is intact.
        /// If the function fails, at least some of the data in the address range has been replaced with zeroes.
        /// This value cannot be used with any other value.
        /// If <see cref="MEM_RESET_UNDO"/> is called on an address range which was not <see cref="MEM_RESET"/> earlier, the behavior is undefined.
        /// When you specify <see cref="MEM_RESET"/>, the <see cref="VirtualAllocEx"/> function ignores the value of <paramref name="flProtect"/>.
        /// However, you must still set <paramref name="flProtect"/> to a valid protection value, such as <see cref="PAGE_NOACCESS"/>.
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
        /// <param name="flProtect">
        /// The memory protection for the region of pages to be allocated.
        /// If the pages are being committed, you can specify any one of the memory protection constants.
        /// Protection attributes specified when protecting a page cannot conflict with those specified when allocating a page.
        /// </param>
        /// <param name="nndPreferred">
        /// The NUMA node where the physical memory should reside.
        /// Used only when allocating a new VA region (either committed or reserved).
        /// Otherwise this parameter is ignored when the API is used to commit pages in a region that already exists.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the base address of the allocated region of pages.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Each page has an associated page state.
        /// The <see cref="VirtualAllocExNuma"/> function can perform the following operations:
        /// Commit a region of reserved pages
        /// Reserve a region of free pages
        /// Simultaneously reserve and commit a region of free pages
        /// <see cref="VirtualAllocExNuma"/> cannot reserve a reserved page. It can commit a page that is already committed.
        /// This means you can commit a range of pages, regardless of whether they have already been committed, and the function will not fail.
        /// You can use <see cref="VirtualAllocExNuma"/> to reserve a block of pages and
        /// then make additional calls to <see cref="VirtualAllocExNuma"/> to commit individual pages from the reserved block.
        /// This enables a process to reserve a range of its virtual address space without consuming physical storage until it is needed.
        /// If the <paramref name="lpAddress"/> parameter is not <see cref="NULL"/>, the function uses
        /// the <paramref name="lpAddress"/> and <paramref name="dwSize"/> parameters to compute the region of pages to be allocated.
        /// The current state of the entire range of pages must be compatible with the type of allocation
        /// specified by the <paramref name="flAllocationType"/> parameter.
        /// Otherwise, the function fails and none of the pages is allocated.
        /// This compatibility requirement does not preclude committing an already committed page; see the preceding list.
        /// Because <see cref="VirtualAllocExNuma"/> does not allocate any physical pages,
        /// it will succeed whether or not the pages are available on that node or elsewhere in the system.
        /// The physical pages are allocated on demand.
        /// If the preferred node runs out of pages, the memory manager will use pages from other nodes.
        /// If the memory is paged out, the same process is used when it is brought back in.
        /// To execute dynamically generated code, use <see cref="VirtualAllocExNuma"/> to allocate memory
        /// and the <see cref="VirtualProtectEx"/> function to grant <see cref="PAGE_EXECUTE"/> access.
        /// The <see cref="VirtualAllocExNuma"/> function can be used to reserve an Address Windowing Extensions (AWE) region of memory
        /// within the virtual address space of a specified process.
        /// This region of memory can then be used to map physical pages into and out of virtual memory as required by the application.
        /// The <see cref="MEM_PHYSICAL"/> and <see cref="MEM_RESERVE"/> values must be set in the <paramref name="flAllocationType"/> parameter.
        /// The <see cref="MEM_COMMIT"/> value must not be set. The page protection must be set to <see cref="PAGE_READWRITE"/>.
        /// The <see cref="VirtualFreeEx"/> function can decommit a committed page, releasing the page's storage,
        /// or it can simultaneously decommit and release a committed page.
        /// It can also release a reserved page, making it a free page.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualAllocExNuma", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID VirtualAllocExNuma([In] HANDLE hProcess, [In] LPVOID lpAddress, [In] SIZE_T dwSize,
            [In] MemoryAllocationTypes flAllocationType, [In] MemoryProtectionConstants flProtect, [In] DWORD nndPreferred);

        /// <summary>
        /// <para>
        /// Releases, decommits, or releases and decommits a region of pages within the virtual address space of the calling process.
        /// To free memory allocated in another process by the <see cref="VirtualAllocEx"/> function, use the <see cref="VirtualFreeEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualfree"/>
        /// </para>
        /// </summary>
        /// <param name="lpAddress">
        /// A pointer to the base address of the region of pages to be freed.
        /// If the <paramref name="dwFreeType"/> parameter is <see cref="MEM_RELEASE"/>, this parameter must be the base address returned
        /// by the <see cref="VirtualAlloc"/> function when the region of pages is reserved.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region of memory to be freed, in bytes.
        /// If the <paramref name="dwFreeType"/> parameter is <see cref="MEM_RELEASE"/>, this parameter must be 0 (zero).
        /// The function frees the entire region that is reserved in the initial allocation call to <see cref="VirtualAlloc"/>.
        /// If the <paramref name="dwFreeType"/> parameter is <see cref="MEM_DECOMMIT"/>, the function decommits all memory pages
        /// that contain one or more bytes in the range from the <paramref name="lpAddress"/> parameter
        /// to (<paramref name="lpAddress"/>+<paramref name="dwSize"/>).
        /// This means, for example, that a 2-byte region of memory that straddles a page boundary causes both pages to be decommitted.
        /// If <paramref name="lpAddress"/> is the base address returned by <see cref="VirtualAlloc"/> and <paramref name="dwSize"/> is 0 (zero),
        /// the function decommits the entire region that is allocated by <see cref="VirtualAlloc"/>.
        /// After that, the entire region is in the reserved state.
        /// </param>
        /// <param name="dwFreeType">
        /// The type of free operation. This parameter can be one of the following values.
        /// <see cref="MEM_COALESCE_PLACEHOLDERS"/>:
        /// To coalesce two adjacent placeholders, specify <code>MEM_RELEASE | MEM_COALESCE_PLACEHOLDERS</code>.
        /// When you coalesce placeholders, <paramref name="lpAddress"/> and <paramref name="dwSize"/> must exactly match those of the placeholder.
        /// <see cref="MEM_PRESERVE_PLACEHOLDER"/>:
        /// Frees an allocation back to a placeholder (after you've replaced a placeholder with a private allocation
        /// using <see cref="VirtualAlloc2"/> or <see cref="VirtualAlloc2FromApp"/>).
        /// To split a placeholder into two placeholders, specify <code>MEM_RELEASE | MEM_PRESERVE_PLACEHOLDER</code>.
        /// <see cref="MEM_DECOMMIT"/>:
        /// Decommits the specified region of committed pages. After the operation, the pages are in the reserved state.
        /// The function does not fail if you attempt to decommit an uncommitted page.
        /// This means that you can decommit a range of pages without first determining the current commitment state.
        /// Do not use this value with <see cref="MEM_RELEASE"/>.
        /// The <see cref="MEM_DECOMMIT"/> value is not supported when the <paramref name="lpAddress"/> parameter provides the base address for an enclave.
        /// <see cref="MEM_RELEASE"/>:
        /// Releases the specified region of pages, or placeholder (for a placeholder, the address space is released and available for other allocations).
        /// After this operation, the pages are in the free state.
        /// If you specify this value, <paramref name="dwSize"/> must be 0 (zero), and <paramref name="lpAddress"/> must point to the base address
        /// returned by the <see cref="VirtualAlloc"/> function when the region is reserved.
        /// The function fails if either of these conditions is not met.
        /// If any pages in the region are committed currently, the function first decommits, and then releases them.
        /// The function does not fail if you attempt to release pages that are in different states, some reserved and some committed.
        /// This means that you can release a range of pages without first determining the current commitment state.
        /// Do not use this value with <see cref="MEM_DECOMMIT"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Each page of memory in a process virtual address space has a Page State.
        /// The <see cref="VirtualFree"/> function can decommit a range of pages that are in different states, some committed and some uncommitted.
        /// This means that you can decommit a range of pages without first determining the current commitment state of each page.
        /// Decommitting a page releases its physical storage, either in memory or in the paging file on disk.
        /// If a page is decommitted but not released, its state changes to reserved.
        /// Subsequently, you can call <see cref="VirtualAlloc"/> to commit it, or <see cref="VirtualFree"/> to release it.
        /// Attempts to read from or write to a reserved page results in an access violation exception.
        /// The <see cref="VirtualFree"/> function can release a range of pages that are in different states, some reserved and some committed.
        /// This means that you can release a range of pages without first determining the current commitment state of each page.
        /// The entire range of pages originally reserved by the <see cref="VirtualAlloc"/> function must be released at the same time.
        /// If a page is released, its state changes to free, and it is available for subsequent allocation operations.
        /// After memory is released or decommited, you can never refer to the memory again.
        /// Any information that may have been in that memory is gone forever.
        /// Attempting to read from or write to a free page results in an access violation exception.
        /// If you need to keep information, do not decommit or free memory that contains the information.
        /// The <see cref="VirtualFree"/> function can be used on an AWE region of memory,
        /// and it invalidates any physical page mappings in the region when freeing the address space.
        /// However, the physical page is not deleted, and the application can use them.
        /// The application must explicitly call <see cref="FreeUserPhysicalPages"/> to free the physical pages.
        /// When the process is terminated, all resources are cleaned up automatically.
        /// To delete an enclave when you finish using it, specify the following values:
        /// The base address of the enclave for the <paramref name="lpAddress"/> parameter.
        /// 0 for the <paramref name="dwSize"/> parameter.
        /// <see cref="MEM_RELEASE"/> for the <paramref name="dwFreeType"/> parameter. The <see cref="MEM_DECOMMIT"/> value is not supported for enclaves.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualFree", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL VirtualFree([In] LPVOID lpAddress, [In] SIZE_T dwSize, [In] VirtualFreeTypes dwFreeType);

        /// <summary>
        /// <para>
        /// Releases, decommits, or releases and decommits a region of memory within the virtual address space of a specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualfreeex"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to a process. The function frees memory within the virtual address space of the process.
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpAddress">
        /// A pointer to the starting address of the region of memory to be freed.
        /// If the <paramref name="dwFreeType"/> parameter is <see cref="MEM_RELEASE"/>, <paramref name="lpAddress"/> must be
        /// the base address returned by the <see cref="VirtualAllocEx"/> function when the region is reserved.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region of memory to free, in bytes.
        /// If the dwFreeType parameter is <see cref="MEM_RELEASE"/>, <paramref name="dwSize"/> must be 0 (zero).
        /// The function frees the entire region that is reserved in the initial allocation call to <see cref="VirtualAllocEx"/>.
        /// If <paramref name="dwFreeType"/> is <see cref="MEM_DECOMMIT"/>, the function decommits all memory pages that contain one or more bytes
        /// in the range from the <paramref name="lpAddress"/> parameter to (<paramref name="lpAddress"/>+<paramref name="dwSize"/>).
        /// This means, for example, that a 2-byte region of memory that straddles a page boundary causes both pages to be decommitted.
        /// If <paramref name="lpAddress"/> is the base address returned by <see cref="VirtualAllocEx"/> and <paramref name="dwSize"/> is 0 (zero),
        /// the function decommits the entire region that is allocated by <see cref="VirtualAllocEx"/>.
        /// After that, the entire region is in the reserved state.
        /// </param>
        /// <param name="dwFreeType">
        /// The type of free operation. This parameter can be one of the following values.
        /// <see cref="MEM_COALESCE_PLACEHOLDERS"/>:
        /// To coalesce two adjacent placeholders, specify <code>MEM_RELEASE | MEM_COALESCE_PLACEHOLDERS</code>.
        /// When you coalesce placeholders, <paramref name="lpAddress"/> and <paramref name="dwSize"/> must exactly match those of the placeholder.
        /// <see cref="MEM_PRESERVE_PLACEHOLDER"/>:
        /// Frees an allocation back to a placeholder (after you've replaced a placeholder with a private allocation
        /// using <see cref="VirtualAlloc2"/> or <see cref="VirtualAlloc2FromApp"/>).
        /// To split a placeholder into two placeholders, specify <code>MEM_RELEASE | MEM_PRESERVE_PLACEHOLDER</code>.
        /// <see cref="MEM_DECOMMIT"/>:
        /// Decommits the specified region of committed pages. After the operation, the pages are in the reserved state.
        /// The function does not fail if you attempt to decommit an uncommitted page.
        /// This means that you can decommit a range of pages without first determining their current commitment state.
        /// Do not use this value with <see cref="MEM_RELEASE"/>.
        /// The <see cref="MEM_DECOMMIT"/> value is not supported when the <paramref name="lpAddress"/> parameter provides the base address for an enclave.
        /// <see cref="MEM_RELEASE"/>:
        /// Releases the specified region of pages, or placeholder (for a placeholder, the address space is released and available for other allocations).
        /// After the operation, the pages are in the free state.
        /// If you specify this value, <paramref name="dwSize"/> must be 0 (zero), and lpAddress must point to the base address returned
        /// by the <see cref="VirtualAllocEx"/> function when the region is reserved.
        /// The function fails if either of these conditions is not met.
        /// If any pages in the region are committed currently, the function first decommits, and then releases them.
        /// The function does not fail if you attempt to release pages that are in different states, some reserved and some committed.
        /// This means that you can release a range of pages without first determining the current commitment state.
        /// Do not use this value with <see cref="MEM_DECOMMIT"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a <see cref="TRUE"/> value.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Each page of memory in a process virtual address space has a Page State.
        /// The <see cref="VirtualFreeEx"/> function can decommit a range of pages that are in different states, some committed and some uncommitted.
        /// This means that you can decommit a range of pages without first determining the current commitment state of each page.
        /// Decommitting a page releases its physical storage, either in memory or in the paging file on disk.
        /// If a page is decommitted but not released, its state changes to reserved.
        /// Subsequently, you can call <see cref="VirtualAllocEx"/> to commit it, or VirtualFreeEx to release it.
        /// Attempting to read from or write to a reserved page results in an access violation exception.
        /// The VirtualFreeEx function can release a range of pages that are in different states, some reserved and some committed.
        /// This means that you can release a range of pages without first determining the current commitment state of each page.
        /// The entire range of pages originally reserved by VirtualAllocEx must be released at the same time.
        /// If a page is released, its state changes to free, and it is available for subsequent allocation operations.
        /// After memory is released or decommitted, you can never refer to the memory again.
        /// Any information that may have been in that memory is gone forever.
        /// Attempts to read from or write to a free page results in an access violation exception.
        /// If you need to keep information, do not decommit or free memory that contains the information.
        /// The <see cref="VirtualFreeEx"/> function can be used on an AWE region of memory and it invalidates
        /// any physical page mappings in the region when freeing the address space.
        /// However, the physical pages are not deleted, and the application can use them.
        /// The application must explicitly call <see cref="FreeUserPhysicalPages"/> to free the physical pages.
        /// When the process is terminated, all resources are automatically cleaned up.
        /// To delete an enclave when you finish using it, specify the following values:
        /// The base address of the enclave for the <paramref name="lpAddress"/> parameter.
        /// 0 for the <paramref name="dwSize"/> parameter.
        /// <see cref="MEM_RELEASE"/> for the <paramref name="dwFreeType"/> parameter.
        /// The <see cref="MEM_DECOMMIT"/> value is not supported for enclaves.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualFreeEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL VirtualFreeEx([In] HANDLE hProcess, [In] LPVOID lpAddress, [In] SIZE_T dwSize, [In] VirtualFreeTypes dwFreeType);

        /// <summary>
        /// <para>
        /// Locks the specified region of the process's virtual address space into physical memory,
        /// ensuring that subsequent access to the region will not incur a page fault.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtuallock"/>
        /// </para>
        /// </summary>
        /// <param name="lpAddress">
        /// A pointer to the base address of the region of pages to be locked.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region to be locked, in bytes.
        /// The region of affected pages includes all pages that contain one or more bytes in the range
        /// from the <paramref name="lpAddress"/> parameter to (<paramref name="lpAddress"/>+<paramref name="dwSize"/>).
        /// This means that a 2-byte range straddling a page boundary causes both pages to be locked.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// All pages in the specified region must be committed. Memory protected with <see cref="PAGE_NOACCESS"/> cannot be locked.
        /// Locking pages into memory may degrade the performance of the system by reducing the available RAM and forcing the system
        /// to swap out other critical pages to the paging file.
        /// Each version of Windows has a limit on the maximum number of pages a process can lock.
        /// This limit is intentionally small to avoid severe performance degradation.
        /// Applications that need to lock larger numbers of pages must first call the <see cref="SetProcessWorkingSetSize"/> function
        /// to increase their minimum and maximum working set sizes.
        /// The maximum number of pages that a process can lock is equal to the number of pages in its minimum working set minus a small overhead.
        /// Pages that a process has locked remain in physical memory until the process unlocks them or terminates.
        /// These pages are guaranteed not to be written to the pagefile while they are locked.
        /// To unlock a region of locked pages, use the <see cref="VirtualUnlock"/> function.
        /// Locked pages are automatically unlocked when the process terminates.
        /// This function is not like the <see cref="GlobalLock"/> or <see cref="LocalLock"/> function in that
        /// it does not increment a lock count and translate a handle into a pointer.
        /// There is no lock count for virtual pages, so multiple calls to the <see cref="VirtualUnlock"/> function
        /// are never required to unlock a region of pages.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualLock", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL VirtualLock([In] LPVOID lpAddress, [In] SIZE_T dwSize);

        /// <summary>
        /// <para>
        /// Changes the protection on a region of committed pages in the virtual address space of the calling process.
        /// To change the access protection of any process, use the <see cref="VirtualProtectEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualprotect"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualProtect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL VirtualProtect([In] LPVOID lpAddress, [In] SIZE_T dwSize, [In] MemoryProtectionConstants flNewProtect,
            [Out] out MemoryProtectionConstants lpflOldProtect);

        /// <summary>
        /// <para>
        /// Changes the protection on a region of committed pages in the virtual address space of a specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualprotectex"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process whose memory protection is to be changed.
        /// The handle must have the <see cref="PROCESS_VM_OPERATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpAddress">
        /// A pointer to the base address of the region of pages whose access protection attributes are to be changed.
        /// All pages in the specified region must be within the same reserved region allocated
        /// when calling the <see cref="VirtualAlloc"/> or <see cref="VirtualAllocEx"/> function using <see cref="MEM_RESERVE"/>.
        /// The pages cannot span adjacent reserved regions that were allocated
        /// by separate calls to <see cref="VirtualAlloc"/> or <see cref="VirtualAllocEx"/> using <see cref="MEM_RESERVE"/>.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region whose access protection attributes are changed, in bytes.
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
        /// A pointer to a variable that receives the previous access protection of the first page in the specified region of pages.
        /// If this parameter is <see cref="NullRef{MemoryProtectionConstants}"/> or does not point to a valid variable, the function fails.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The access protection value can be set only on committed pages.
        /// If the state of any page in the specified region is not committed, the function fails
        /// and returns without modifying the access protection of any pages in the specified region.
        /// The <see cref="PAGE_GUARD"/> protection modifier establishes guard pages. Guard pages act as one-shot access alarms.
        /// For more information, see Creating Guard Pages.
        /// It is best to avoid using <see cref="VirtualProtectEx"/> to change page protections on memory blocks
        /// allocated by <see cref="GlobalAlloc"/>, <see cref="HeapAlloc"/>, or <see cref="LocalAlloc"/>,
        /// because multiple memory blocks can exist on a single page.
        /// The heap manager assumes that all pages in the heap grant at least read and write access.
        /// When protecting a region that will be executable, the calling program bears responsibility for ensuring cache coherency
        /// via an appropriate call to <see cref="FlushInstructionCache"/> once the code has been set in place.
        /// Otherwise attempts to execute code out of the newly executable region may produce unpredictable results.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualProtectEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL VirtualProtectEx([In] HANDLE hProcess, [In] LPVOID lpAddress, [In] SIZE_T dwSize,
            [In] MemoryProtectionConstants flNewProtect, [Out] out MemoryProtectionConstants lpflOldProtect);

        /// <summary>
        /// <para>
        /// Retrieves information about a range of pages in the virtual address space of the calling process.
        /// To retrieve information about a range of pages in the address space of another process, use the <see cref="VirtualQueryEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualquery"/>
        /// </para>
        /// </summary>
        /// <param name="lpAddress">
        /// A pointer to the base address of the region of pages to be queried.
        /// This value is rounded down to the next page boundary.
        /// To determine the size of a page on the host computer, use the <see cref="GetSystemInfo"/> function.
        /// If <paramref name="lpAddress"/> specifies an address above the highest memory address accessible to the process,
        /// the function fails with <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a <see cref="MEMORY_BASIC_INFORMATION"/> structure in which information about the specified page range is returned.
        /// </param>
        /// <param name="dwLength">
        /// The size of the buffer pointed to by the <paramref name="lpBuffer"/> parameter, in bytes.
        /// </param>
        /// <returns>
        /// The return value is the actual number of bytes returned in the information buffer.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible error values include <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="VirtualQuery"/> provides information about a region of consecutive pages beginning at a specified address
        /// that share the following attributes:
        /// The state of all pages is the same (<see cref="MEM_COMMIT"/>, <see cref="MEM_RESERVE"/>, <see cref="MEM_FREE"/>,
        /// <see cref="MEM_PRIVATE"/>, <see cref="MEM_MAPPED"/>, or <see cref="MEM_IMAGE"/>).
        /// If the initial page is not free, all pages in the region are part of the same initial allocation of pages
        /// created by a single call to <see cref="VirtualAlloc"/>, <see cref="MapViewOfFile"/>,
        /// or one of the following extended versions of these functions: <see cref="VirtualAllocEx"/>, <see cref="VirtualAllocExNuma"/>,
        /// <see cref="MapViewOfFileEx"/>, <see cref="MapViewOfFileExNuma"/>.
        /// The access granted to all pages is the same (<see cref="PAGE_READONLY"/>, <see cref="PAGE_READWRITE"/>, <see cref="PAGE_NOACCESS"/>,
        /// <see cref="PAGE_WRITECOPY"/>, <see cref="PAGE_EXECUTE"/>, <see cref="PAGE_EXECUTE_READ"/>, <see cref="PAGE_EXECUTE_READWRITE"/>,
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>, <see cref="PAGE_GUARD"/>, or <see cref="PAGE_NOCACHE"/>).
        /// The function determines the attributes of the first page in the region and then scans subsequent pages
        /// until it scans the entire range of pages or until it encounters a page with a nonmatching set of attributes.
        /// The function returns the attributes and the size of the region of pages with matching attributes, in bytes.
        /// For example, if there is a 40 megabyte (MB) region of free memory,
        /// and <see cref="VirtualQuery"/> is called on a page that is 10 MB into the region,
        /// the function will obtain a state of <see cref="MEM_FREE"/> and a size of 30 MB.
        /// If a shared copy-on-write page is modified, it becomes private to the process that modified the page.
        /// However, the <see cref="VirtualQuery"/> function will continue to report such pages as <see cref="MEM_MAPPED"/> (for data views)
        /// or <see cref="MEM_IMAGE"/> (for executable image views) rather than <see cref="MEM_PRIVATE"/>.
        /// To detect whether copy-on-write has occurred for a specific page, either access the page or lock it
        /// using the <see cref="VirtualLock"/> function to make sure the page is resident in memory,
        /// then use the <see cref="QueryWorkingSetEx"/> function to check the Shared bit in the extended working set information for the page.
        /// If the Shared bit is clear, the page is private.
        /// This function reports on a region of pages in the memory of the calling process,
        /// and the <see cref="VirtualQueryEx"/> function reports on a region of pages in the memory of a specified process.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualQuery", ExactSpelling = true, SetLastError = true)]
        public static extern SIZE_T VirtualQuery([In] LPCVOID lpAddress, [Out] out MEMORY_BASIC_INFORMATION lpBuffer, [In] SIZE_T dwLength);

        /// <summary>
        /// <para>
        /// Retrieves information about a range of pages within the virtual address space of a specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualqueryex"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process whose memory information is queried.
        /// The handle must have been opened with the <see cref="PROCESS_QUERY_INFORMATION"/> access right,
        /// which enables using the handle to read information from the process object.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpAddress">
        /// A pointer to the base address of the region of pages to be queried.
        /// This value is rounded down to the next page boundary.
        /// To determine the size of a page on the host computer, use the <see cref="GetSystemInfo"/> function.
        /// If <paramref name="lpAddress"/> specifies an address above the highest memory address accessible to the process,
        /// the function fails with <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a <see cref="MEMORY_BASIC_INFORMATION"/> structure in which information about the specified page range is returned.
        /// </param>
        /// <param name="dwLength">
        /// The size of the buffer pointed to by the <paramref name="lpBuffer"/> parameter, in bytes.
        /// </param>
        /// <returns>
        /// The return value is the actual number of bytes returned in the information buffer.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible error values include <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="VirtualQueryEx"/> provides information about a region of consecutive pages beginning
        /// at a specified address that share the following attributes:
        /// The state of all pages is the same (<see cref="MEM_COMMIT"/>, <see cref="MEM_RESERVE"/>, <see cref="MEM_FREE"/>,
        /// <see cref="MEM_PRIVATE"/>, <see cref="MEM_MAPPED"/>, or <see cref="MEM_IMAGE"/>).
        /// If the initial page is not free, all pages in the region are part of the same initial allocation of pages
        /// created by a single call to <see cref="VirtualAlloc"/>, <see cref="MapViewOfFile"/>,
        /// or one of the following extended versions of these functions: <see cref="VirtualAllocEx"/>, <see cref="VirtualAllocExNuma"/>,
        /// <see cref="MapViewOfFileEx"/>, <see cref="MapViewOfFileExNuma"/>.
        /// The access granted to all pages is the same (<see cref="PAGE_READONLY"/>, <see cref="PAGE_READWRITE"/>, <see cref="PAGE_NOACCESS"/>,
        /// <see cref="PAGE_WRITECOPY"/>, <see cref="PAGE_EXECUTE"/>, <see cref="PAGE_EXECUTE_READ"/>, <see cref="PAGE_EXECUTE_READWRITE"/>,
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>, <see cref="PAGE_GUARD"/>, or <see cref="PAGE_NOCACHE"/>).
        /// The <see cref="VirtualQueryEx"/> function determines the attributes of the first page in the region and then scans subsequent pages
        /// until it scans the entire range of pages, or until it encounters a page with a nonmatching set of attributes.
        /// The function returns the attributes and the size of the region of pages with matching attributes, in bytes.
        /// For example, if there is a 40 megabyte (MB) region of free memory,
        /// and <see cref="VirtualQueryEx"/> is called on a page that is 10 MB into the region,
        /// the function will obtain a state of <see cref="MEM_FREE"/> and a size of 30 MB.
        /// If a shared copy-on-write page is modified, it becomes private to the process that modified the page.
        /// However, the <see cref="VirtualQueryEx"/> function will continue to report such pages as <see cref="MEM_MAPPED"/> (for data views)
        /// or <see cref="MEM_IMAGE"/> (for executable image views) rather than <see cref="MEM_PRIVATE"/>.
        /// To detect whether copy-on-write has occurred for a specific page, either access the page or lock it using the <see cref="VirtualLock"/> function
        /// to make sure the page is resident in memory, then use the <see cref="QueryWorkingSet"/> or <see cref="QueryWorkingSetEx"/> function
        /// to check the Shared bit in the extended working set information for the page.
        /// If the Shared bit is clear, the page is private.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualQueryEx", ExactSpelling = true, SetLastError = true)]
        public static extern SIZE_T VirtualQueryEx([In] HANDLE hProcess, [In] LPCVOID lpAddress, [Out] out MEMORY_BASIC_INFORMATION lpBuffer,
            [In] SIZE_T dwLength);

        /// <summary>
        /// <para>
        /// Unlocks a specified range of pages in the virtual address space of a process,
        /// enabling the system to swap the pages out to the paging file if necessary.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-virtualunlock"/>
        /// </para>
        /// </summary>
        /// <param name="lpAddress">
        /// A pointer to the base address of the region of pages to be unlocked.
        /// </param>
        /// <param name="dwSize">
        /// The size of the region being unlocked, in bytes.
        /// The region of affected pages includes all pages containing one or more bytes in the range
        /// from the <paramref name="lpAddress"/> parameter to (<paramref name="lpAddress"/>+<paramref name="dwSize"/>).
        /// This means that a 2-byte range straddling a page boundary causes both pages to be unlocked.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For the function to succeed, the range specified need not match a range passed to a previous call to the <see cref="VirtualLock"/> function,
        /// but all pages in the range must be locked.
        /// If any of the pages in the specified range are not locked, <see cref="VirtualUnlock"/> removes such pages from the working set,
        /// sets last error to <see cref="ERROR_NOT_LOCKED"/>, and returns <see cref="FALSE"/>.
        /// Calling <see cref="VirtualUnlock"/> on a range of memory that is not locked releases the pages from the process's working set.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualUnlock", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL VirtualUnlock([In] LPVOID lpAddress, [In] SIZE_T dwSize);

        /// <summary>
        /// <para>
        /// Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation fails.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-writeprocessmemory"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process memory to be modified.
        /// The handle must have <see cref="PROCESS_VM_WRITE"/> and <see cref="PROCESS_VM_OPERATION"/> access to the process.
        /// </param>
        /// <param name="lpBaseAddress">
        /// A pointer to the base address in the specified process to which data is written.
        /// Before data transfer occurs, the system verifies that all data in the base address and memory of the specified size
        /// is accessible for write access, and if it is not accessible, the function fails.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to the buffer that contains data to be written in the address space of the specified process.
        /// </param>
        /// <param name="nSize">
        /// The number of bytes to be written to the specified process.
        /// </param>
        /// <param name="lpNumberOfBytesWritten">
        /// A pointer to a variable that receives the number of bytes transferred into the specified process.
        /// This parameter is optional. If <paramref name="lpNumberOfBytesWritten"/> is <see cref="NullRef{SIZE_T}"/>, the parameter is ignored.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The function fails if the requested write operation crosses into an area of the process that is inaccessible.
        /// </returns>
        /// <remarks>
        /// WriteProcessMemory copies the data from the specified buffer in the current process to the address range of the specified process.
        /// Any process that has a handle with <see cref="PROCESS_VM_WRITE"/> and <see cref="PROCESS_VM_OPERATION"/> access to the process
        /// to be written to can call the function.
        /// Typically but not always, the process with address space that is being written to is being debugged.
        /// The entire area to be written to must be accessible, and if it is not accessible, the function fails.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WriteProcessMemory([In] HANDLE hProcess, [In] LPVOID lpBaseAddress, [In] LPCVOID lpBuffer,
            [In] SIZE_T nSize, [Out] out SIZE_T lpNumberOfBytesWritten);
    }
}
