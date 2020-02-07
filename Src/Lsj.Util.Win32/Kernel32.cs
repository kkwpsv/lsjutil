using System;
using System.Runtime.InteropServices;
using System.Text;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Kernel32.dll
    /// </summary>
    public static class Kernel32
    {
        /// <summary>
        /// <para>
        /// Formats a message string. The function requires a message definition as input. 
        /// The message definition can come from a buffer passed into the function.
        /// It can come from a message table resource in an already-loaded module.
        /// Or the caller can ask the function to search the system's message table resource(s) for the message definition.
        /// The function finds the message definition in a message table resource based on a message identifier and a language identifier.
        /// The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-formatmessagew
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// The formatting options, and how to interpret the lpSource parameter. 
        /// The low-order byte of <paramref name="dwFlags"/> specifies how the function handles line breaks in the output buffer.
        /// The low-order byte can also specify the maximum width of a formatted output line.
        /// If the low-order byte is a nonzero value other than <see cref="FormatMessageFlags.FORMAT_MESSAGE_MAX_WIDTH_MASK"/>,
        /// it specifies the maximum number of characters in an output line. 
        /// The function ignores regular line breaks in the message definition text. 
        /// The function never splits a string delimited by white space across a line break. 
        /// The function stores hard-coded line breaks in the message definition text into the output buffer. 
        /// Hard-coded line breaks are coded with the %n escape sequence.
        /// </param>
        /// <param name="lpSource">
        /// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="dwFlags"/> parameter.
        /// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE"/>: A handle to the module that contains the message table to search.
        /// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>: Pointer to a string that consists of unformatted message text.
        /// It will be scanned for inserts and formatted accordingly.
        /// </param>
        /// <param name="dwMessageId">
        /// The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.
        /// </param>
        /// <param name="dwLanguageId">
        /// The language identifier for the requested message. 
        /// This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.
        /// If you pass a specific LANGID in this parameter, <see cref="FormatMessage"/> will return a message for that LANGID only.
        /// If the function cannot find a message for that LANGID, it sets Last-Error to ERROR_RESOURCE_LANG_NOT_FOUND.
        /// If you pass in zero, <see cref="FormatMessage"/> looks for a message for LANGIDs in the following order:
        /// Language neutral
        /// Thread LANGID, based on the thread's locale value
        /// User default LANGID, based on the user's default locale value
        /// System default LANGID, based on the system default locale value
        /// US English
        /// If <see cref="FormatMessage"/> does not locate a message for any of the preceding LANGIDs, 
        /// it returns any language message string that is present.
        /// If that fails, it returns <see cref="SystemErrorCodes.ERROR_RESOURCE_LANG_NOT_FOUND"/>.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. 
        /// If <paramref name="dwFlags"/>"/> includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/>,
        /// the function allocates a buffer using the LocalAlloc function,
        /// and places the pointer to the buffer at the address specified in lpBuffer.
        /// This buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="nSize">
        /// If the <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is not set, 
        /// this parameter specifies the size of the output buffer, in TCHARs. 
        /// If <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> is set, 
        /// this parameter specifies the minimum number of TCHARs to allocate for an output buffer.
        /// The output buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="Arguments">
        /// An array of values that are used as insert values in the formatted message. 
        /// A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second argument; and so on.
        /// The interpretation of each value depends on the formatting information associated with the insert in the message definition.
        /// The default is to treat each value as a pointer to a null-terminated string.
        /// By default, the Arguments parameter is of type va_list*, which is a language- and implementation-specific data type 
        /// for describing a variable number of arguments. The state of the va_list argument is undefined upon return from the function.
        /// To use the va_list again, destroy the variable argument list pointer using va_end and reinitialize it with va_start.
        /// If you do not have a pointer of type va_list*, then specify the <see cref="FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY"/> flag
        /// and pass a pointer to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.
        /// Each insert must have a corresponding element in the array.
        /// </param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FormatMessageW", SetLastError = true)]
        public static extern uint FormatMessage([In]FormatMessageFlags dwFlags, [In]IntPtr lpSource, [In]uint dwMessageId, [In]uint dwLanguageId,
            [MarshalAs(UnmanagedType.LPWStr)][In][Out]StringBuilder lpBuffer, [In]uint nSize, [In]IntPtr Arguments);

        /// <summary>
        /// <para>
        /// Formats a message string. The function requires a message definition as input. 
        /// The message definition can come from a buffer passed into the function.
        /// It can come from a message table resource in an already-loaded module.
        /// Or the caller can ask the function to search the system's message table resource(s) for the message definition.
        /// The function finds the message definition in a message table resource based on a message identifier and a language identifier.
        /// The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-formatmessagew
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// The formatting options, and how to interpret the lpSource parameter. 
        /// The low-order byte of <paramref name="dwFlags"/> specifies how the function handles line breaks in the output buffer.
        /// The low-order byte can also specify the maximum width of a formatted output line.
        /// If the low-order byte is a nonzero value other than <see cref="FormatMessageFlags.FORMAT_MESSAGE_MAX_WIDTH_MASK"/>,
        /// it specifies the maximum number of characters in an output line. 
        /// The function ignores regular line breaks in the message definition text. 
        /// The function never splits a string delimited by white space across a line break. 
        /// The function stores hard-coded line breaks in the message definition text into the output buffer. 
        /// Hard-coded line breaks are coded with the %n escape sequence.
        /// </param>
        /// <param name="lpSource">
        /// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="dwFlags"/> parameter.
        /// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE"/>: A handle to the module that contains the message table to search.
        /// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>: Pointer to a string that consists of unformatted message text.
        /// It will be scanned for inserts and formatted accordingly.
        /// </param>
        /// <param name="dwMessageId">
        /// The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.
        /// </param>
        /// <param name="dwLanguageId">
        /// The language identifier for the requested message. 
        /// This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.
        /// If you pass a specific LANGID in this parameter, <see cref="FormatMessage"/> will return a message for that LANGID only.
        /// If the function cannot find a message for that LANGID, it sets Last-Error to ERROR_RESOURCE_LANG_NOT_FOUND.
        /// If you pass in zero, <see cref="FormatMessage"/> looks for a message for LANGIDs in the following order:
        /// Language neutral
        /// Thread LANGID, based on the thread's locale value
        /// User default LANGID, based on the user's default locale value
        /// System default LANGID, based on the system default locale value
        /// US English
        /// If <see cref="FormatMessage"/> does not locate a message for any of the preceding LANGIDs, 
        /// it returns any language message string that is present.
        /// If that fails, it returns <see cref="SystemErrorCodes.ERROR_RESOURCE_LANG_NOT_FOUND"/>.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. 
        /// If <paramref name="dwFlags"/>"/> includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/>,
        /// the function allocates a buffer using the LocalAlloc function,
        /// and places the pointer to the buffer at the address specified in lpBuffer.
        /// This buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="nSize">
        /// If the <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is not set, 
        /// this parameter specifies the size of the output buffer, in TCHARs. 
        /// If <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> is set, 
        /// this parameter specifies the minimum number of TCHARs to allocate for an output buffer.
        /// The output buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="Arguments">
        /// An array of values that are used as insert values in the formatted message. 
        /// A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second argument; and so on.
        /// The interpretation of each value depends on the formatting information associated with the insert in the message definition.
        /// The default is to treat each value as a pointer to a null-terminated string.
        /// By default, the Arguments parameter is of type va_list*, which is a language- and implementation-specific data type 
        /// for describing a variable number of arguments. The state of the va_list argument is undefined upon return from the function.
        /// To use the va_list again, destroy the variable argument list pointer using va_end and reinitialize it with va_start.
        /// If you do not have a pointer of type va_list*, then specify the <see cref="FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY"/> flag
        /// and pass a pointer to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.
        /// Each insert must have a corresponding element in the array.
        /// </param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FormatMessageW", SetLastError = true)]
        public static extern uint FormatMessage([In]FormatMessageFlags dwFlags, [In]IntPtr lpSource, [In]uint dwMessageId, [In]uint dwLanguageId,
            [Out]out IntPtr lpBuffer, [In]uint nSize, [In]IntPtr Arguments);

        /// <summary>
        /// <para>
        /// Allocates the specified number of bytes from the heap.
        /// </para>
        /// <para>
        /// https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalalloc
        /// </para>
        /// </summary>
        /// <param name="uFlags">
        /// The memory allocation attributes. If zero is specified, the default is <see cref="GlobalMemoryFlags.GMEM_FIXED"/>.
        /// This parameter can be one or more of the following values, except for the incompatible combinations that are specifically noted.
        /// <see cref="GlobalMemoryFlags.GHND"/> : Combines <see cref="GlobalMemoryFlags.GMEM_MOVEABLE"/> and <see cref="GlobalMemoryFlags.GMEM_ZEROINIT"/>.
        /// <see cref="GlobalMemoryFlags.GMEM_FIXED"/> : Allocates fixed memory. The return value is a pointer.
        /// <see cref="GlobalMemoryFlags.GMEM_MOVEABLE"/> : Allocates movable memory. Memory blocks are never moved in physical memory,
        /// but they can be moved within the default heap. The return value is a handle to the memory object. 
        /// To translate the handle into a pointer, use the <see cref="GlobalLock"/> function.
        /// This value cannot be combined with <see cref="GlobalMemoryFlags.GMEM_FIXED"/>.
        /// <see cref="GlobalMemoryFlags.GMEM_ZEROINIT"/> : Initializes memory contents to zero.
        /// <see cref="GlobalMemoryFlags.GPTR"/> : Combines <see cref="GlobalMemoryFlags.GMEM_FIXED"/> and <see cref="GlobalMemoryFlags.GMEM_ZEROINIT"/>.
        /// The following values are obsolete, but are provided for compatibility with 16-bit Windows. They are ignored.
        /// <see cref="GlobalMemoryFlags.GMEM_DDESHARE"/>, <see cref="GlobalMemoryFlags.GMEM_DISCARDABLE"/>, <see cref="GlobalMemoryFlags.GMEM_LOWER"/>,
        /// <see cref="GlobalMemoryFlags.GMEM_NOCOMPACT"/>, <see cref="GlobalMemoryFlags.GMEM_NODISCARD"/>, <see cref="GlobalMemoryFlags.GMEM_NOT_BANKED"/>,
        /// <see cref="GlobalMemoryFlags.GMEM_NOTIFY"/>, <see cref="GlobalMemoryFlags.GMEM_SHARE"/>.
        /// </param>
        /// <param name="dwBytes">
        /// The number of bytes to allocate.
        /// If this parameter is zero and the <paramref name="uFlags"/> parameter specifies <see cref="GlobalMemoryFlags.GMEM_MOVEABLE"/>,
        /// the function returns a handle to a memory object that is marked as discarded.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly allocated memory object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
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
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
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
        /// The new size of the memory block, in bytes. If uFlags specifies <see cref="GlobalMemoryFlags.GMEM_MODIFY"/>, this parameter is ignored.
        /// </param>
        /// <param name="uFlags">
        /// The reallocation options. If <see cref="GlobalMemoryFlags.GMEM_MODIFY"/> is specified,
        /// the function modifies the attributes of the memory object only (the dwBytes parameter is ignored.)
        /// Otherwise, the function reallocates the memory object.
        /// You can optionally combine <see cref="GlobalMemoryFlags.GMEM_MODIFY"/> with the following value.
        /// <see cref="GlobalMemoryFlags.GMEM_MOVEABLE"/> : Allocates movable memory.
        /// If the memory is a locked <see cref="GlobalMemoryFlags.GMEM_MOVEABLE"/> memory block 
        /// or a <see cref="GlobalMemoryFlags.GMEM_FIXED"/> memory block and this flag is not specified, the memory can only be reallocated in place.
        /// If this parameter does not specify <see cref="GlobalMemoryFlags.GMEM_MODIFY"/>, you can use the following value.
        /// <see cref="GlobalMemoryFlags.GMEM_ZEROINIT"/> : Causes the additional memory contents to be initialized to zero
        /// if the memory object is growing in size.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the reallocated memory object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalReAlloc", SetLastError = true)]
        public static extern IntPtr GlobalReAlloc(IntPtr hMem, IntPtr dwBytes, GlobalMemoryFlags uFlags);

        /// <summary>
        /// <para>
        /// Allocates the specified number of bytes from the heap.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-localalloc
        /// </para>
        /// </summary>
        /// <param name="uFlags">
        /// The memory allocation attributes. The default is the <see cref="LocalMemoryFlags.LMEM_FIXED"/> value.
        /// This parameter can be one or more of the following values, except for the incompatible combinations that are specifically noted.
        /// <see cref="LocalMemoryFlags.LHND"/> : Combines <see cref="LocalMemoryFlags.LMEM_MOVEABLE"/> and <see cref="LocalMemoryFlags.LMEM_ZEROINIT"/>.
        /// <see cref="LocalMemoryFlags.LMEM_FIXED"/> : Allocates fixed memory. The return value is a pointer to the memory object.
        /// <see cref="LocalMemoryFlags.LMEM_MOVEABLE"/> : Allocates movable memory. Memory blocks are never moved in physical memory,
        /// but they can be moved within the default heap. The return value is a handle to the memory object. 
        /// To translate the handle to a pointer, use the <see cref="LocalLock"/> function.
        /// This value cannot be combined with <see cref="LocalMemoryFlags.LMEM_FIXED"/>.
        /// <see cref="LocalMemoryFlags.LMEM_ZEROINIT"/> : Initializes memory contents to zero.
        /// <see cref="LocalMemoryFlags.LPTR"/> : Combines <see cref="LocalMemoryFlags.LMEM_FIXED"/> and <see cref="LocalMemoryFlags.LMEM_ZEROINIT"/>.
        /// <see cref="LocalMemoryFlags.NONZEROLHND"/> : Same as <see cref="LocalMemoryFlags.LMEM_MOVEABLE"/>.
        /// <see cref="LocalMemoryFlags.NONZEROLPTR"/> : Same as <see cref="LocalMemoryFlags.LMEM_FIXED"/>.
        /// The following values are obsolete, but are provided for compatibility with 16-bit Windows. They are ignored.
        /// <see cref="LocalMemoryFlags.LMEM_DISCARDABLE"/>, <see cref="LocalMemoryFlags.LMEM_NOCOMPACT"/>, <see cref="LocalMemoryFlags.LMEM_NODISCARD"/>.
        /// </param>
        /// <param name="uBytes">
        /// The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies <see cref="LocalMemoryFlags.LMEM_MOVEABLE"/>,
        /// the function returns a handle to a memory object that is marked as discarded.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly allocated memory object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
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
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
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
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
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
        /// The new size of the memory block, in bytes. If uFlags specifies <see cref="LocalMemoryFlags.LMEM_MODIFY"/>, this parameter is ignored.
        /// </param>
        /// <param name="uFlags">
        /// The reallocation options. If <see cref="LocalMemoryFlags.LMEM_MODIFY"/> is specified,
        /// the function modifies the attributes of the memory object only (the <paramref name="uBytes"/> parameter is ignored.)
        /// Otherwise, the function reallocates the memory object.
        /// You can optionally combine <see cref="LocalMemoryFlags.LMEM_MODIFY"/> with the following value.
        /// <see cref="LocalMemoryFlags.LMEM_MOVEABLE"/> : Allocates fixed or movable memory. 
        /// If the memory is a locked <see cref="LocalMemoryFlags.LMEM_MOVEABLE"/> memory block
        /// or a <see cref="LocalMemoryFlags.LMEM_FIXED"/> memory block and this flag is not specified, the memory can only be reallocated in place.
        /// If this parameter does not specify <see cref="LocalMemoryFlags.LMEM_MODIFY"/>, you can use the following value.
        /// <see cref="LocalMemoryFlags.LMEM_ZEROINIT"/> : Causes the additional memory contents to be initialized to zero
        /// if the memory object is growing in size.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the reallocated memory object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalReAlloc", SetLastError = true)]
        public static extern IntPtr LocalReAlloc(IntPtr hMem, IntPtr uBytes, LocalMemoryFlags uFlags);

        /// <summary>
        /// <para>
        /// Sets the last-error code for the calling thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-setlasterror
        /// </para>
        /// </summary>
        /// <param name="dwErrCode">The last-error code for the thread.</param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetLastError", SetLastError = true)]
        public static extern void SetLastError([In]uint dwErrCode);
    }
}
