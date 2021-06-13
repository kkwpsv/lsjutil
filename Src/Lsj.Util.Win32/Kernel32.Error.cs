using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ErrorModes;
using static Lsj.Util.Win32.Enums.ExceptionCodes;
using static Lsj.Util.Win32.Enums.ExceptionFlags;
using static Lsj.Util.Win32.Enums.FacilityCodes;
using static Lsj.Util.Win32.Enums.FormatMessageFlags;
using static Lsj.Util.Win32.Enums.OpenFileFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.Enums.NTSTATUS;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {

        /// <summary>
        /// EXCEPTION_EXECUTE_HANDLER
        /// </summary>
        public const int EXCEPTION_EXECUTE_HANDLER = 1;

        /// <summary>
        /// EXCEPTION_CONTINUE_SEARCH
        /// </summary>
        public const int EXCEPTION_CONTINUE_SEARCH = 0;

        /// <summary>
        /// EXCEPTION_CONTINUE_EXECUTION
        /// </summary>
        public const int EXCEPTION_CONTINUE_EXECUTION = unchecked(-1);

        /// <summary>
        /// <para>
        /// Displays a message box and terminates the application when the message box is closed.
        /// If the system is running with a debug version of Kernel32.dll,
        /// the message box gives the user the opportunity to terminate the application or to cancel the message box and return to the application
        /// that called <see cref="FatalAppExit"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-fatalappexitw"/>
        /// </para>
        /// </summary>
        /// <param name="uAction">
        /// This parameter must be zero.
        /// </param>
        /// <param name="lpMessageText">
        /// The null-terminated string that is displayed in the message box.
        /// </param>
        /// <remarks>
        /// An application calls <see cref="FatalAppExit"/> only when it is not capable of terminating any other way.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FatalAppExitW", ExactSpelling = true, SetLastError = true)]
        public static extern void FatalAppExit([In] UINT uAction, [MarshalAs(UnmanagedType.LPWStr)][In] string lpMessageText);

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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-formatmessagew"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FormatMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD FormatMessage([In] FormatMessageFlags dwFlags, [In] LPCVOID lpSource, [In] DWORD dwMessageId,
            [In] DWORD dwLanguageId, [In] IntPtr lpBuffer, [In] DWORD nSize, [In] IntPtr Arguments);

        /// <summary>
        /// <para>
        /// Retrieves the error mode for the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-geterrormode"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The process error mode. This function returns one of the following values.
        /// <see cref="SEM_FAILCRITICALERRORS"/>, <see cref="SEM_NOALIGNMENTFAULTEXCEPT"/>,
        /// <see cref="SEM_NOGPFAULTERRORBOX"/>, <see cref="SEM_NOOPENFILEERRORBOX"/>
        /// </returns>
        /// <remarks>
        /// Each process has an associated error mode that indicates to the system how the application is going to respond to serious errors.
        /// A child process inherits the error mode of its parent process.
        /// To change the error mode for the process, use the <see cref="SetErrorMode"/> function.
        /// Windows 7:
        /// Callers should favor <see cref="SetThreadErrorMode"/> over <see cref="SetErrorMode"/>
        /// since it is less disruptive to the normal behavior of the system.
        /// <see cref="GetThreadErrorMode"/> is the call function that corresponds to <see cref="GetErrorMode"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetErrorMode", ExactSpelling = true, SetLastError = true)]
        public static extern ErrorModes GetErrorMode();

        /// <summary>
        /// <para>
        /// Retrieves a code that identifies the type of exception that occurs.
        /// The function can be called only from within the filter expression or exception-handler block of an exception handler.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/debug/getexceptioncode"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value identifies the type of exception.
        /// The following table identifies the exception codes that can occur due to common programming errors.
        /// These values are defined in WinBase.h and WinNT.h.
        /// <see cref="EXCEPTION_ACCESS_VIOLATION"/>:
        /// The thread attempts to read from or write to a virtual address for which it does not have access.
        /// This value is defined as <see cref="STATUS_ACCESS_VIOLATION"/>.
        /// <see cref="EXCEPTION_ARRAY_BOUNDS_EXCEEDED"/>:
        /// The thread attempts to access an array element that is out of bounds, and the underlying hardware supports bounds checking.
        /// This value is defined as <see cref="STATUS_ARRAY_BOUNDS_EXCEEDED"/>.
        /// <see cref="EXCEPTION_BREAKPOINT"/>:
        /// A breakpoint is encountered.
        /// This value is defined as <see cref="STATUS_BREAKPOINT"/>.
        /// <see cref="EXCEPTION_DATATYPE_MISALIGNMENT"/>:
        /// The thread attempts to read or write data that is misaligned on hardware that does not provide alignment.
        /// For example, 16-bit values must be aligned on 2-byte boundaries, 32-bit values on 4-byte boundaries, and so on.
        /// This value is defined as <see cref="STATUS_DATATYPE_MISALIGNMENT"/>.
        /// <see cref="EXCEPTION_FLT_DENORMAL_OPERAND"/>:
        /// One of the operands in a floating point operation is denormal.
        /// A denormal value is one that is too small to represent as a standard floating point value.
        /// This value is defined as <see cref="STATUS_FLOAT_DENORMAL_OPERAND"/>.
        /// <see cref="EXCEPTION_FLT_DIVIDE_BY_ZERO"/>:
        /// The thread attempts to divide a floating point value by a floating point divisor of 0 (zero).
        /// This value is defined as <see cref="STATUS_FLOAT_DIVIDE_BY_ZERO"/>.
        /// <see cref="EXCEPTION_FLT_INEXACT_RESULT"/>:
        /// The result of a floating point operation cannot be represented exactly as a decimal fraction.
        /// This value is defined as <see cref="STATUS_FLOAT_INEXACT_RESULT"/>.
        /// <see cref="EXCEPTION_FLT_INVALID_OPERATION"/>:
        /// A floating point exception that is not included in this list.
        /// This value is defined as <see cref="STATUS_FLOAT_INVALID_OPERATION"/>.
        /// <see cref="EXCEPTION_FLT_OVERFLOW"/>:
        /// The exponent of a floating point operation is greater than the magnitude allowed by the corresponding type.
        /// This value is defined as <see cref="STATUS_FLOAT_OVERFLOW"/>.
        /// <see cref="EXCEPTION_FLT_STACK_CHECK"/>:
        /// The stack has overflowed or underflowed, because of a floating point operation.
        /// This value is defined as <see cref="STATUS_FLOAT_STACK_CHECK"/>.
        /// <see cref="EXCEPTION_FLT_UNDERFLOW"/>:
        /// The exponent of a floating point operation is less than the magnitude allowed by the corresponding type.
        /// This value is defined as <see cref="STATUS_FLOAT_UNDERFLOW"/>.
        /// <see cref="EXCEPTION_GUARD_PAGE"/>:
        /// The thread accessed memory allocated with the <see cref="PAGE_GUARD"/> modifier.
        /// This value is defined as <see cref="STATUS_GUARD_PAGE_VIOLATION"/>.
        /// <see cref="EXCEPTION_ILLEGAL_INSTRUCTION"/>:
        /// The thread tries to execute an invalid instruction.
        /// This value is defined as <see cref="STATUS_ILLEGAL_INSTRUCTION"/>.
        /// <see cref="EXCEPTION_IN_PAGE_ERROR"/>:
        /// The thread tries to access a page that is not present, and the system is unable to load the page.
        /// For example, this exception might occur if a network connection is lost while running a program over a network.
        /// This value is defined as <see cref="STATUS_IN_PAGE_ERROR"/>.
        /// <see cref="EXCEPTION_INT_DIVIDE_BY_ZERO"/>:
        /// The thread attempts to divide an integer value by an integer divisor of 0 (zero).
        /// This value is defined as <see cref="STATUS_INTEGER_DIVIDE_BY_ZERO"/>.
        /// <see cref="EXCEPTION_INT_OVERFLOW"/>:
        /// The result of an integer operation creates a value that is too large to be held by the destination register.
        /// In some cases, this will result in a carry out of the most significant bit of the result.
        /// Some operations do not set the carry flag.
        /// This value is defined as <see cref="STATUS_INTEGER_OVERFLOW"/>.
        /// <see cref="EXCEPTION_INVALID_DISPOSITION"/>:
        /// An exception handler returns an invalid disposition to the exception dispatcher.
        /// Programmers using a high-level language such as C should never encounter this exception.
        /// This value is defined as <see cref="STATUS_INVALID_DISPOSITION"/>.
        /// <see cref="EXCEPTION_INVALID_HANDLE"/>:
        /// The thread used a handle to a kernel object that was invalid (probably because it had been closed.)
        /// This value is defined as <see cref="STATUS_INVALID_HANDLE"/>.
        /// <see cref="EXCEPTION_NONCONTINUABLE_EXCEPTION"/>:
        /// The thread attempts to continue execution after a non-continuable exception occurs.
        /// This value is defined as <see cref="STATUS_NONCONTINUABLE_EXCEPTION"/>.
        /// <see cref="EXCEPTION_PRIV_INSTRUCTION"/>:
        /// The thread attempts to execute an instruction with an operation that is not allowed in the current computer mode.
        /// This value is defined as <see cref="STATUS_PRIVILEGED_INSTRUCTION"/>.
        /// <see cref="EXCEPTION_SINGLE_STEP"/>:
        /// A trace trap or other single instruction mechanism signals that one instruction is executed.
        /// This value is defined as <see cref="STATUS_SINGLE_STEP"/>.
        /// <see cref="EXCEPTION_STACK_OVERFLOW"/>:
        /// The thread uses up its stack.
        /// This value is defined as <see cref="STATUS_STACK_OVERFLOW"/>.
        /// <see cref="STATUS_UNWIND_CONSOLIDATE"/>:
        /// A frame consolidation has been executed.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetExceptionCode"/> function can be called only
        /// from within the filter expression or exception-handler block of an exception handler.
        /// The filter expression is evaluated if an exception occurs during execution of the __try block,
        /// and it determines whether or not the __except block is executed.
        /// The filter expression can invoke a filter function.
        /// The filter function cannot call <see cref="GetExceptionCode"/>.
        /// However, the return value of <see cref="GetExceptionCode"/> can be passed as a parameter to a filter function.
        /// The return value of the <see cref="GetExceptionInformation"/> function can also be passed as a parameter to a filter function.
        /// <see cref="GetExceptionInformation"/> returns a pointer to a structure that includes the exception code information.
        /// When nested handlers exist, each filter expression is evaluated
        /// until one is evaluated as <see cref="EXCEPTION_EXECUTE_HANDLER"/> or <see cref="EXCEPTION_CONTINUE_EXECUTION"/>.
        /// Each filter expression can invoke <see cref="GetExceptionCode"/> to get the exception code.
        /// The exception code returned is the code generated by a hardware exception,
        /// or the code specified in the <see cref="RaiseException"/> function for a software generated exception.
        /// When handling the breakpoint exception, it is important to increment the instruction pointer
        /// in the context record to continue from this exception.
        /// </remarks>
        public static ExceptionCodes GetExceptionCode() => (ExceptionCodes)Marshal.GetExceptionCode();

        /// <summary>
        /// <para>
        /// Retrieves a computer-independent description of an exception,
        /// and information about the computer state that exists for the thread when the exception occurs.
        /// This function can be called only from within the filter expression of an exception handler.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/debug/getexceptioninformation"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// A pointer to an <see cref="EXCEPTION_POINTERS"/> structure that contains pointers to the following two structures:
        /// <see cref="EXCEPTION_RECORD"/> structure that contains a description of the exception.
        /// <see cref="CONTEXT"/> structure that contains the computer state information.
        /// </returns>
        /// <remarks>
        /// The filter expression (from which the function is called) is evaluated if an exception occurs during execution of the __try block,
        /// and it determines whether or not the __except block is executed.
        /// The filter expression can invoke a filter function. The filter function cannot call <see cref="GetExceptionInformation"/>.
        /// However, the return value of <see cref="GetExceptionInformation"/> can be passed as a parameter to a filter function.
        /// To pass the <see cref="EXCEPTION_POINTERS"/> information to the exception-handler block,
        /// the filter expression or filter function must copy the pointer or the data to safe storage that the handler can later access.
        /// In the case of nested handlers, each filter expression is evaluated
        /// until one is evaluated as <see cref="EXCEPTION_EXECUTE_HANDLER"/> or <see cref="EXCEPTION_CONTINUE_EXECUTION"/>.
        /// Each filter expression can invoke <see cref="GetExceptionInformation"/> to get exception information.
        /// </remarks>
#if NETSTANDARD2_0
        public static IntPtr GetExceptionInformation() =>throw new NotSupportedException();
#else
        public static IntPtr GetExceptionInformation() => Marshal.GetExceptionPointers();
#endif

        /// <summary>
        /// <para>
        /// Retrieves the calling thread's last-error code value.
        /// The last-error code is maintained on a per-thread basis.
        /// Multiple threads do not overwrite each other's last-error code.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror"/>
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
        /// Retrieves the error mode for the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-getthreaderrormode"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The process error mode. This function returns one of the following values.
        /// <see cref="SEM_FAILCRITICALERRORS"/>, <see cref="SEM_NOGPFAULTERRORBOX"/>, <see cref="SEM_NOOPENFILEERRORBOX"/>
        /// </returns>
        /// <remarks>
        /// A thread inherits the error mode of the process in which it is running.
        /// To change the error mode for the thread, use the <see cref="SetThreadErrorMode"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadErrorMode", ExactSpelling = true, SetLastError = true)]
        public static extern ErrorModes GetThreadErrorMode();

        /// <summary>
        /// <para>
        /// Maps a system error code to an <see cref="HRESULT"/> value.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winerror/nf-winerror-hresult_from_win32"/>
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
        /// Raises an exception in the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-raiseexception"/>
        /// </para>
        /// </summary>
        /// <param name="dwExceptionCode">
        /// An application-defined exception code of the exception being raised.
        /// The filter expression and exception-handler block of an exception handler can use the <see cref="GetExceptionCode"/> function
        /// to retrieve this value.
        /// Note that the system will clear bit 28 of <paramref name="dwExceptionCode"/> before displaying a message.
        /// This bit is a reserved exception bit, used by the system for its own purposes.
        /// </param>
        /// <param name="dwExceptionFlags">
        /// The exception flags.
        /// This can be either zero to indicate a continuable exception, or <see cref="EXCEPTION_NONCONTINUABLE"/> to indicate a noncontinuable exception.
        /// Any attempt to continue execution after a noncontinuable exception causes the <see cref="EXCEPTION_NONCONTINUABLE_EXCEPTION"/> exception.
        /// </param>
        /// <param name="nNumberOfArguments">
        /// The number of arguments in the <paramref name="lpArguments"/> array.
        /// This value must not exceed <see cref="EXCEPTION_MAXIMUM_PARAMETERS"/>.
        /// This parameter is ignored if <paramref name="lpArguments"/> is <see langword="null"/>.
        /// </param>
        /// <param name="lpArguments">
        /// An array of arguments. This parameter can be <see langword="null"/>.
        /// These arguments can contain any application-defined data that needs to be passed to the filter expression of the exception handler.
        /// </param>
        /// <remarks>
        /// The <see cref="RaiseException"/> function enables a process to use structured exception handling to handle private,
        /// software-generated, application-defined exceptions.
        /// Raising an exception causes the exception dispatcher to go through the following search for an exception handler:
        /// The system first attempts to notify the process's debugger, if any.
        /// If the process is not being debugged, or if the associated debugger does not handle the exception,
        /// the system attempts to locate a frame-based exception handler by searching the stack frames of the thread in which the exception occurred.
        /// The system searches the current stack frame first, then proceeds backward through preceding stack frames.
        /// If no frame-based handler can be found, or no frame-based handler handles the exception,
        /// the system makes a second attempt to notify the process's debugger.
        /// If the process is not being debugged, or if the associated debugger does not handle the exception,
        /// the system provides default handling based on the exception type.
        /// For most exceptions, the default action is to call the <see cref="ExitProcess"/> function.
        /// The values specified in the <paramref name="dwExceptionCode"/>, <paramref name="dwExceptionFlags"/>, <paramref name="nNumberOfArguments"/>,
        /// and <paramref name="lpArguments"/> parameters can be retrieved in the filter expression of a frame-based exception handler
        /// by calling the <see cref="GetExceptionInformation"/> function.
        /// A debugger can retrieve these values by calling the <see cref="WaitForDebugEvent"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RaiseException", ExactSpelling = true, SetLastError = true)]
        public static extern void RaiseException([In] ExceptionCodes dwExceptionCode, [In] ExceptionFlags dwExceptionFlags,
            [In] DWORD nNumberOfArguments, [MarshalAs(UnmanagedType.LPArray)][In] ULONG_PTR[] lpArguments);

        /// <summary>
        /// <para>
        /// Controls whether the system will handle the specified types of serious errors or whether the process will handle them.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-seterrormode"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetErrorMode", ExactSpelling = true, SetLastError = true)]
        public static extern UINT SetErrorMode([In] ErrorModes uMode);

        /// <summary>
        /// <para>
        /// Sets the last-error code for the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-setlasterror"/>
        /// </para>
        /// </summary>
        /// <param name="dwErrCode">The last-error code for the thread.</param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetLastError", ExactSpelling = true, SetLastError = true)]
        public static extern void SetLastError([In] uint dwErrCode);

        /// <summary>
        /// <para>
        /// Controls whether the system will handle the specified types of serious errors or whether the calling thread will handle them.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-setthreaderrormode"/>
        /// </para>
        /// </summary>
        /// <param name="dwNewMode">
        /// The thread error mode. This parameter can be one or more of the following values.
        /// 0: Use the system default, which is to display all error dialog boxes.
        /// <see cref="SEM_FAILCRITICALERRORS"/>:
        /// The system does not display the critical-error-handler message box.
        /// Instead, the system sends the error to the calling thread.
        /// Best practice is that all applications call the process-wide <see cref="SetErrorMode"/> function
        /// with a parameter of <see cref="SEM_FAILCRITICALERRORS"/> at startup.
        /// This is to prevent error mode dialogs from hanging the application.
        /// <see cref="SEM_NOGPFAULTERRORBOX"/>:
        /// The system does not display the Windows Error Reporting dialog.
        /// <see cref="SEM_NOOPENFILEERRORBOX"/>:
        /// The <see cref="OpenFile"/> function does not display a message box when it fails to find a file.
        /// Instead, the error is returned to the caller.
        /// This error mode overrides the <see cref="OF_PROMPT"/> flag. 
        /// </param>
        /// <param name="lpOldMode">
        /// If the function succeeds, this parameter is set to the thread's previous error mode.
        /// This parameter can be <see cref="NullRef{ErrorModes}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Each process has an associated error mode that indicates to the system how the application is going to respond to serious errors.
        /// A thread inherits the error mode of the process in which it is running.
        /// To retrieve the process error mode, use the <see cref="GetErrorMode"/> function.
        /// To retrieve the error mode of the calling thread, use the <see cref="GetThreadErrorMode"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadErrorMode", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadErrorMode([In] ErrorModes dwNewMode, [Out] out ErrorModes lpOldMode);

        /// <summary>
        /// <para>
        /// An application-defined function that passes unhandled exceptions to the debugger, if the process is being debugged.
        /// Otherwise, it optionally displays an Application Error message box and causes the exception handler to be executed.
        /// This function can be called only from within the filter expression of an exception handler.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/errhandlingapi/nf-errhandlingapi-unhandledexceptionfilter"/>
        /// </para>
        /// </summary>
        /// <param name="ExceptionInfo">
        /// A pointer to an <see cref="EXCEPTION_POINTERS"/> structure that specifies a description of the exception
        /// and the processor context at the time of the exception.
        /// This pointer is the return value of a call to the <see cref="GetExceptionInformation"/> function.
        /// </param>
        /// <returns>
        /// The function returns one of the following values.
        /// <see cref="EXCEPTION_CONTINUE_SEARCH"/>:
        /// The process is being debugged, so the exception should be passed (as second chance) to the application's debugger. 
        /// <see cref="EXCEPTION_EXECUTE_HANDLER"/>:
        /// If the <see cref="SEM_NOGPFAULTERRORBOX"/> flag was specified in a previous call to <see cref="SetErrorMode"/>,
        /// no Application Error message box is displayed.
        /// The function returns control to the exception handler, which is free to take any appropriate action. 
        /// </returns>
        /// <remarks>
        /// If the process is not being debugged, the function displays an Application Error message box, depending on the current error mode.
        /// The default behavior is to display the dialog box, but this can be disabled by specifying <see cref="SEM_NOGPFAULTERRORBOX"/>
        /// in a call to the <see cref="SetErrorMode"/> function.
        /// The system uses <see cref="UnhandledExceptionFilter"/> internally to handle exceptions that occur during process and thread creation.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnhandledExceptionFilter", ExactSpelling = true, SetLastError = true)]
        public static extern LONG UnhandledExceptionFilter([Out] out EXCEPTION_POINTERS ExceptionInfo);
    }
}
