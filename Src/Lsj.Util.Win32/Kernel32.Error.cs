using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Enums.FacilityCodes;
using static Lsj.Util.Win32.Enums.FormatMessageFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
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
        /// If the low-order byte is a nonzero value other than <see cref="FORMAT_MESSAGE_MAX_WIDTH_MASK"/>,
        /// it specifies the maximum number of characters in an output line. 
        /// The function ignores regular line breaks in the message definition text. 
        /// The function never splits a string delimited by white space across a line break. 
        /// The function stores hard-coded line breaks in the message definition text into the output buffer. 
        /// Hard-coded line breaks are coded with the %n escape sequence.
        /// </param>
        /// <param name="lpSource">
        /// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="dwFlags"/> parameter.
        /// <see cref="FORMAT_MESSAGE_FROM_HMODULE"/>: A handle to the module that contains the message table to search.
        /// <see cref="FORMAT_MESSAGE_FROM_STRING"/>: Pointer to a string that consists of unformatted message text.
        /// It will be scanned for inserts and formatted accordingly.
        /// </param>
        /// <param name="dwMessageId">
        /// The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
        /// </param>
        /// <param name="dwLanguageId">
        /// The language identifier for the requested message. 
        /// This parameter is ignored if dwFlags includes <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
        /// If you pass a specific LANGID in this parameter, <see cref="FormatMessage"/> will return a message for that LANGID only.
        /// If the function cannot find a message for that LANGID, it sets Last-Error to <see cref="ERROR_RESOURCE_LANG_NOT_FOUND"/>.
        /// If you pass in zero, <see cref="FormatMessage"/> looks for a message for LANGIDs in the following order:
        /// Language neutral
        /// Thread LANGID, based on the thread's locale value
        /// User default LANGID, based on the user's default locale value
        /// System default LANGID, based on the system default locale value
        /// US English
        /// If <see cref="FormatMessage"/> does not locate a message for any of the preceding LANGIDs, 
        /// it returns any language message string that is present.
        /// If that fails, it returns <see cref="ERROR_RESOURCE_LANG_NOT_FOUND"/>.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. 
        /// If <paramref name="dwFlags"/>"/> includes <see cref="FORMAT_MESSAGE_ALLOCATE_BUFFER"/>, the function allocates a buffer
        /// using the <see cref="LocalAlloc"/> function, and places the pointer to the buffer at the address specified in <paramref name="lpBuffer"/>.
        /// This buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="nSize">
        /// If the <see cref="FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is not set, 
        /// this parameter specifies the size of the output buffer, in TCHARs. 
        /// If <see cref="FORMAT_MESSAGE_ALLOCATE_BUFFER"/> is set, 
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
        /// If you do not have a pointer of type va_list*, then specify the <see cref="FORMAT_MESSAGE_ARGUMENT_ARRAY"/> flag
        /// and pass a pointer to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.
        /// Each insert must have a corresponding element in the array.
        /// </param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FormatMessageW", SetLastError = true)]
        public static extern uint FormatMessage([In]FormatMessageFlags dwFlags, [In]IntPtr lpSource, [In]uint dwMessageId, [In]uint dwLanguageId,
            [Out]out IntPtr lpBuffer, [In]uint nSize, [In]IntPtr Arguments);

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
        /// If the low-order byte is a nonzero value other than <see cref="FORMAT_MESSAGE_MAX_WIDTH_MASK"/>,
        /// it specifies the maximum number of characters in an output line. 
        /// The function ignores regular line breaks in the message definition text. 
        /// The function never splits a string delimited by white space across a line break. 
        /// The function stores hard-coded line breaks in the message definition text into the output buffer. 
        /// Hard-coded line breaks are coded with the %n escape sequence.
        /// </param>
        /// <param name="lpSource">
        /// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="dwFlags"/> parameter.
        /// <see cref="FORMAT_MESSAGE_FROM_HMODULE"/>: A handle to the module that contains the message table to search.
        /// <see cref="FORMAT_MESSAGE_FROM_STRING"/>: Pointer to a string that consists of unformatted message text.
        /// It will be scanned for inserts and formatted accordingly.
        /// </param>
        /// <param name="dwMessageId">
        /// The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
        /// </param>
        /// <param name="dwLanguageId">
        /// The language identifier for the requested message. 
        /// This parameter is ignored if dwFlags includes <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
        /// If you pass a specific LANGID in this parameter, <see cref="FormatMessage"/> will return a message for that LANGID only.
        /// If the function cannot find a message for that LANGID, it sets Last-Error to <see cref="ERROR_RESOURCE_LANG_NOT_FOUND"/>.
        /// If you pass in zero, <see cref="FormatMessage"/> looks for a message for LANGIDs in the following order:
        /// Language neutral
        /// Thread LANGID, based on the thread's locale value
        /// User default LANGID, based on the user's default locale value
        /// System default LANGID, based on the system default locale value
        /// US English
        /// If <see cref="FormatMessage"/> does not locate a message for any of the preceding LANGIDs, 
        /// it returns any language message string that is present.
        /// If that fails, it returns <see cref="ERROR_RESOURCE_LANG_NOT_FOUND"/>.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. 
        /// If <paramref name="dwFlags"/>"/> includes <see cref="FORMAT_MESSAGE_ALLOCATE_BUFFER"/>, the function allocates a buffer 
        /// using the <see cref="LocalAlloc"/> function, and places the pointer to the buffer at the address specified in <paramref name="lpBuffer"/>.
        /// This buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="nSize">
        /// If the <see cref="FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is not set, 
        /// this parameter specifies the size of the output buffer, in TCHARs. 
        /// If <see cref="FORMAT_MESSAGE_ALLOCATE_BUFFER"/> is set, 
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
        /// If you do not have a pointer of type va_list*, then specify the <see cref="FORMAT_MESSAGE_ARGUMENT_ARRAY"/> flag
        /// and pass a pointer to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.
        /// Each insert must have a corresponding element in the array.
        /// </param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FormatMessageW", SetLastError = true)]
        public static extern uint FormatMessage([In]FormatMessageFlags dwFlags, [In]IntPtr lpSource, [In]uint dwMessageId, [In]uint dwLanguageId,
            [MarshalAs(UnmanagedType.LPWStr)][In][Out]StringBuilder lpBuffer, [In]uint nSize, [In]IntPtr Arguments);

        /// <summary>
        /// <para>
        /// Retrieves the calling thread's last-error code value.
        /// The last-error code is maintained on a per-thread basis.
        /// Multiple threads do not overwrite each other's last-error code.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is the calling thread's last-error code.
        /// The Return Value section of the documentation for each function that sets the last-error code notes the conditions
        /// under which the function sets the last-error code.
        /// Most functions that set the thread's last-error code set it when they fail.
        /// However, some functions also set the last-error code when they succeed.
        /// If the function is not documented to set the last-error code, the value returned by this function is simply
        /// the most recent last-error code to have been set; some functions set the last-error code to 0 on success and others do not.
        /// </returns>
        /// <remarks>
        /// Functions executed by the calling thread set this value by calling the <see cref="SetLastError"/> function.
        /// You should call the <see cref="GetLastError"/> function immediately when a function's return value indicates
        /// that such a call will return useful data.
        /// That is because some functions call <see cref="SetLastError"/> with a zero when they succeed,
        /// wiping out the error code set by the most recently failed function.
        /// To obtain an error string for system error codes, use the <see cref="FormatMessage"/> function.
        /// For a complete list of error codes provided by the operating system, see System Error Codes.
        /// The error codes returned by a function are not part of the Windows API specification and can vary by operating system or device driver.
        /// For this reason, we cannot provide the complete list of error codes that can be returned by each function.
        /// There are also many functions whose documentation does not include even a partial list of error codes that can be returned.
        /// Error codes are 32-bit values (bit 31 is the most significant bit). Bit 29 is reserved for application-defined error codes;
        /// no system error code has this bit set.
        /// If you are defining an error code for your application, set this bit to one.
        /// That indicates that the error code has been defined by an application,
        /// and ensures that your error code does not conflict with any error codes defined by the system.
        /// To convert a system error into an HRESULT value, use the <see cref="HRESULT_FROM_WIN32"/> macro.
        /// </remarks>
        public static SystemErrorCodes GetLastError() => (SystemErrorCodes)Marshal.GetLastWin32Error();

        /// <summary>
        /// <para>
        /// Maps a system error code to an <see cref="HRESULT"/> value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winerror/nf-winerror-hresult_from_win32
        /// </para>
        /// </summary>
        /// <param name="x">
        /// The system error code.
        /// </param>
        /// <returns></returns>
        public static HRESULT HRESULT_FROM_WIN32(SystemErrorCodes x) =>
            unchecked((int)x) <= 0 ? (HRESULT)(uint)x : (HRESULT)((((uint)x) & 0x0000FFFF) | ((int)FACILITY_WIN32 << 16) | 0x80000000);

        /// <summary>
        /// <para>
        /// Controls whether the system will handle the specified types of serious errors or whether the process will handle them.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-seterrormode
        /// </para>
        /// </summary>
        /// <param name="uMode">
        /// The process error mode. This parameter can be one or more of the following values.
        /// 0: Use the system default, which is to display all error dialog boxes.
        /// <see cref="SEM_FAILCRITICALERRORS"/>, <see cref="SEM_NOALIGNMENTFAULTEXCEPT"/>,
        /// <see cref="SEM_NOGPFAULTERRORBOX"/>, <see cref="SEM_NOOPENFILEERRORBOX"/>
        /// </param>
        /// <returns>
        /// The return value is the previous state of the error-mode bit flags.
        /// </returns>
        /// <remarks>
        /// Each process has an associated error mode that indicates to the system how the application is going to respond to serious errors.
        /// A child process inherits the error mode of its parent process.
        /// To retrieve the process error mode, use the <see cref="GetErrorMode"/> function.
        /// Because the error mode is set for the entire process, you must ensure that multi-threaded applications do not set different error-mode flags.
        /// Doing so can lead to inconsistent error handling.
        /// The system does not make alignment faults visible to an application on all processor architectures.
        /// Therefore, specifying <see cref="SEM_NOALIGNMENTFAULTEXCEPT"/> is not an error on such architectures,
        /// but the system is free to silently ignore the request.
        /// This means that code sequences such as the following are not always valid on x86 computers:
        /// <code>
        /// SetErrorMode(SEM_NOALIGNMENTFAULTEXCEPT); 
        /// fuOldErrorMode = SetErrorMode(0); 
        /// ASSERT(fuOldErrorMode == SEM_NOALIGNMENTFAULTEXCEPT);
        /// </code>
        /// Itanium:
        /// An application must explicitly call <see cref="SetErrorMode"/> with <see cref="SEM_NOALIGNMENTFAULTEXCEPT"/>
        /// to have the system automatically fix alignment faults.
        /// The default setting is for the system to make alignment faults visible to an application.
        /// Visual Studio 2005:
        /// When declaring a pointer to a structure that may not have aligned data,
        /// you can use the __unaligned keyword to indicate that the type must be read one byte at a time.
        /// For more information, see Windows Data Alignment.
        /// Windows 7:
        /// Callers should favor <see cref="SetThreadErrorMode"/> over <see cref="SetErrorMode"/>
        /// since it is less disruptive to the normal behavior of the system.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetErrorMode", SetLastError = true)]
        public static extern uint SetErrorMode([In]ErrorModes uMode);

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
