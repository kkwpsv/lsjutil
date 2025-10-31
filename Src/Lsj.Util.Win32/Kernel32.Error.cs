using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ErrorModes;
using static Lsj.Util.Win32.Enums.ExceptionCodes;
using static Lsj.Util.Win32.Enums.ExceptionFlags;
using static Lsj.Util.Win32.Enums.FacilityCodes;
using static Lsj.Util.Win32.Enums.MemoryProtectionConstants;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.OpenFileFlags;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// TOP_LEVEL_EXCEPTION_FILTER
        /// </summary>
        /// <param name="ExceptionInfo"></param>
        /// <returns></returns>
        public delegate LONG TOP_LEVEL_EXCEPTION_FILTER([In] in EXCEPTION_POINTERS ExceptionInfo);


        /// <summary>
        /// <para>
        /// Displays a message box and terminates the application when the message box is closed.
        /// If the system is running with a debug version of Kernel32.dll,
        /// the message box gives the user the opportunity to terminate the application or to cancel the message box and return to the application
        /// that called <see cref="FatalAppExit"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-fatalappexitw"/>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FatalAppExitW", ExactSpelling = true)]
        public static extern void FatalAppExit([In] UINT uAction, [In] LPCWSTR lpMessageText);

        /// <summary>
        /// <para>
        /// Transfers execution control to the debugger.
        /// The behavior of the debugger thereafter is specific to the type of debugger used.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-fatalexit"/>
        /// </para>
        /// </summary>
        /// <param name="ExitCode">
        /// The error code associated with the exit.
        /// </param>
        /// <remarks>
        /// An application should only use <see cref="FatalExit"/> for debugging purposes.
        /// It should not call the function in a retail version of the application because doing so will terminate the application.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FatalExit", ExactSpelling = true)]
        public static extern void FatalExit([In] int ExitCode);

        /// <summary>
        /// <para>
        /// Retrieves the error mode for the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-geterrormode"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// The process error mode. This function returns one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Uses the system default, which displays all error dialog boxes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_FAILCRITICALERRORS"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The system does not display the critical-error-handler message box.
        /// Instead, the system sends the error to the calling process.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_NOALIGNMENTFAULTEXCEPT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The system automatically fixes memory alignment faults and makes them invisible to the application.
        /// It does this for the calling process and any descendant processes.
        /// This feature is only supported by certain processor architectures.
        /// For more information, see <see cref="SetErrorMode"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_NOGPFAULTERRORBOX"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The system does not display the Windows Error Reporting dialog.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_NOOPENFILEERRORBOX"/>
        /// </para>
        /// <para>
        /// 0x8000
        /// </para>
        /// </term>
        /// <term>
        /// The system does not display a message box when it fails to find a file.
        /// Instead, the error is returned to the calling process.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Each process has an associated error mode that indicates to the system how the application is going to respond to serious errors.
        /// A child process inherits the error mode of its parent process.
        /// </para>
        /// <para>
        /// To change the error mode for the process, use the <see cref="SetErrorMode"/> function.
        /// </para>
        /// <para>
        /// Windows 7:
        /// Callers should favor <see cref="SetThreadErrorMode"/> over <see cref="SetErrorMode"/>
        /// since it is less disruptive to the normal behavior of the system.
        /// <see cref="GetThreadErrorMode"/> is the call function that corresponds to <see cref="GetErrorMode"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetErrorMode", ExactSpelling = true)]
        public static extern ErrorModes GetErrorMode();

        /// <summary>
        /// <para>
        /// Retrieves a code that identifies the type of exception that occurs.
        /// The function can be called only from within the filter expression or exception-handler block of an exception handler.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// The Microsoft C/C++ Optimizing Compiler interprets this function as a keyword,
        /// and its use outside the appropriate exception-handling syntax generates a compiler error.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/debug/getexceptioncode"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// The return value identifies the type of exception.
        /// The following table identifies the exception codes that can occur due to common programming errors.
        /// These values are defined in WinBase.h and WinNT.h.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_ACCESS_VIOLATION"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread attempts to read from or write to a virtual address for which it does not have access.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_ACCESS_VIOLATION"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_ARRAY_BOUNDS_EXCEEDED"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread attempts to access an array element that is out of bounds, and the underlying hardware supports bounds checking.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_ARRAY_BOUNDS_EXCEEDED"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_BREAKPOINT"/>
        /// </term>
        /// <term>
        /// <para>
        /// A breakpoint is encountered.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_BREAKPOINT"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_DATATYPE_MISALIGNMENT"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread attempts to read or write data that is misaligned on hardware that does not provide alignment.
        /// For example, 16-bit values must be aligned on 2-byte boundaries, 32-bit values on 4-byte boundaries, and so on.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_DATATYPE_MISALIGNMENT"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_FLT_DENORMAL_OPERAND"/>
        /// </term>
        /// <term>
        /// <para>
        /// One of the operands in a floating point operation is denormal.
        /// A denormal value is one that is too small to represent as a standard floating point value.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_FLOAT_DENORMAL_OPERAND"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_FLT_DIVIDE_BY_ZERO"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread attempts to divide a floating point value by a floating point divisor of 0 (zero).
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_FLOAT_DIVIDE_BY_ZERO"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_FLT_INEXACT_RESULT"/>
        /// </term>
        /// <term>
        /// <para>
        /// The result of a floating point operation cannot be represented exactly as a decimal fraction.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_FLOAT_INEXACT_RESULT"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_FLT_INVALID_OPERATION"/>
        /// </term>
        /// <term>
        /// <para>
        /// A floating point exception that is not included in this list.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_FLOAT_INVALID_OPERATION"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_FLT_OVERFLOW"/>
        /// </term>
        /// <term>
        /// <para>
        /// The exponent of a floating point operation is greater than the magnitude allowed by the corresponding type.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_FLOAT_OVERFLOW"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_FLT_STACK_CHECK"/>
        /// </term>
        /// <term>
        /// <para>
        /// The stack has overflowed or underflowed, because of a floating point operation.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_FLOAT_STACK_CHECK"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_FLT_UNDERFLOW"/>
        /// </term>
        /// <term>
        /// <para>
        /// The exponent of a floating point operation is less than the magnitude allowed by the corresponding type.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_FLOAT_UNDERFLOW"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_GUARD_PAGE"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread accessed memory allocated with the <see cref="PAGE_GUARD"/> modifier.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_GUARD_PAGE_VIOLATION"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_ILLEGAL_INSTRUCTION"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread tries to execute an invalid instruction.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_ILLEGAL_INSTRUCTION"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_IN_PAGE_ERROR"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread tries to access a page that is not present, and the system is unable to load the page.
        /// For example, this exception might occur if a network connection is lost while running a program over a network.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_IN_PAGE_ERROR"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_INT_DIVIDE_BY_ZERO"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread attempts to divide an integer value by an integer divisor of 0 (zero).
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_INTEGER_DIVIDE_BY_ZERO"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_INT_OVERFLOW"/>
        /// </term>
        /// <term>
        /// <para>
        /// The result of an integer operation creates a value that is too large to be held by the destination register.
        /// In some cases, this will result in a carry out of the most significant bit of the result.
        /// Some operations do not set the carry flag.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_INTEGER_OVERFLOW"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_INVALID_DISPOSITION"/>
        /// </term>
        /// <term>
        /// <para>
        /// An exception handler returns an invalid disposition to the exception dispatcher.
        /// Programmers using a high-level language such as C should never encounter this exception.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_INVALID_DISPOSITION"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread used a handle to a kernel object that was invalid (probably because it had been closed.)
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_INVALID_HANDLE"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_NONCONTINUABLE_EXCEPTION"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread attempts to continue execution after a non-continuable exception occurs.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_NONCONTINUABLE_EXCEPTION"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_PRIV_INSTRUCTION"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread attempts to execute an instruction with an operation that is not allowed in the current computer mode.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_PRIVILEGED_INSTRUCTION"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_SINGLE_STEP"/>
        /// </term>
        /// <term>
        /// <para>
        /// A trace trap or other single instruction mechanism signals that one instruction is executed.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_SINGLE_STEP"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EXCEPTION_STACK_OVERFLOW"/>
        /// </term>
        /// <term>
        /// <para>
        /// The thread uses up its stack.
        /// </para>
        /// <para>
        /// This value is defined as <see cref="STATUS_STACK_OVERFLOW"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STATUS_UNWIND_CONSOLIDATE"/>
        /// </term>
        /// <term>
        /// A frame consolidation has been executed.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetExceptionCode"/> function can be called only from
        /// within the filter expression or exception-handler block of an exception handler.
        /// The filter expression is evaluated if an exception occurs during execution of the __try block,
        /// and it determines whether or not the __except block is executed.
        /// </para>
        /// <para>
        /// The filter expression can invoke a filter function.
        /// The filter function cannot call <see cref="GetExceptionCode"/>.
        /// However, the return value of <see cref="GetExceptionCode"/> can be passed as a parameter to a filter function.
        /// The return value of the <see cref="GetExceptionInformation"/> function can also be passed as a parameter to a filter function.
        /// <see cref="GetExceptionInformation"/> returns a pointer to a structure that includes the exception code information.
        /// </para>
        /// <para>
        /// When nested handlers exist, each filter expression is evaluated
        /// until one is evaluated as <see cref="EXCEPTION_EXECUTE_HANDLER"/> or <see cref="EXCEPTION_CONTINUE_EXECUTION"/>.
        /// Each filter expression can invoke <see cref="GetExceptionCode"/> to get the exception code.
        /// </para>
        /// <para>
        /// The exception code returned is the code generated by a hardware exception,
        /// or the code specified in the <see cref="RaiseException"/> function for a software generated exception.
        /// </para>
        /// <para>
        /// When handling the breakpoint exception, it is important to increment the instruction pointer
        /// in the context record to continue from this exception.
        /// </para>
        /// </remarks>
        public static ExceptionCodes GetExceptionCode() => (ExceptionCodes)Marshal.GetExceptionCode();

        /// <summary>
        /// <para>
        /// Retrieves a computer-independent description of an exception,
        /// and information about the computer state that exists for the thread when the exception occurs.
        /// This function can be called only from within the filter expression of an exception handler.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The Microsoft C/C++ Optimizing Compiler interprets this function as a keyword,
        /// and its use outside the appropriate exception-handling syntax generates a compiler error.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/debug/getexceptioninformation"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// A pointer to an <see cref="EXCEPTION_POINTERS"/> structure that contains pointers to the following two structures:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="EXCEPTION_RECORD"/> structure that contains a description of the exception.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CONTEXT"/> structure that contains the computer state information.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The filter expression (from which the function is called) is evaluated if an exception occurs
        /// during execution of the __try block, and it determines whether or not the __except block is executed.
        /// </para>
        /// <para>
        /// The filter expression can invoke a filter function. The filter function cannot call <see cref="GetExceptionInformation"/>.
        /// However, the return value of <see cref="GetExceptionInformation"/> can be passed as a parameter to a filter function.
        /// </para>
        /// <para>
        /// To pass the <see cref="EXCEPTION_POINTERS"/> information to the exception-handler block,
        /// the filter expression or filter function must copy the pointer or the data to safe storage that the handler can later access.
        /// </para>
        /// <para>
        /// In the case of nested handlers, each filter expression is evaluated
        /// until one is evaluated as <see cref="EXCEPTION_EXECUTE_HANDLER"/> or <see cref="EXCEPTION_CONTINUE_EXECUTION"/>.
        /// Each filter expression can invoke <see cref="GetExceptionInformation"/> to get exception information.
        /// </para>
        /// </remarks>
        public static P<EXCEPTION_POINTERS> GetExceptionInformation() =>
#if NETSTANDARD2_0
            throw new NotSupportedException();
#else
            Marshal.GetExceptionPointers();
#endif

        /// <summary>
        /// <para>
        /// Retrieves the calling thread's last-error code value.
        /// The last-error code is maintained on a per-thread basis.
        /// Multiple threads do not overwrite each other's last-error code.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// The return value is the calling thread's last-error code.
        /// </para>
        /// <para>
        /// The Return Value section of the documentation for each function that sets the last-error code
        /// notes the conditions under which the function sets the last-error code.
        /// Most functions that set the thread's last-error code set it when they fail.
        /// However, some functions also set the last-error code when they succeed.
        /// If the function is not documented to set the last-error code,
        /// the value returned by this function is simply the most recent last-error code to have been set;
        /// some functions set the last-error code to 0 on success and others do not.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Functions executed by the calling thread set this value by calling the <see cref="SetLastError"/> function.
        /// You should call the <see cref="GetLastError"/> function immediately
        /// when a function's return value indicates that such a call will return useful data.
        /// That is because some functions call <see cref="SetLastError"/> with a zero when they succeed,
        /// wiping out the error code set by the most recently failed function.
        /// </para>
        /// <para>
        /// To obtain an error string for system error codes, use the <see cref="FormatMessage"/> function.
        /// For a complete list of error codes provided by the operating system, see System Error Codes.
        /// </para>
        /// <para>
        /// The error codes returned by a function are not part of the Windows API specification
        /// and can vary by operating system or device driver.
        /// For this reason, we cannot provide the complete list of error codes that can be returned by each function.
        /// There are also many functions whose documentation does not include even a partial list of error codes that can be returned.
        /// </para>
        /// <para>
        /// Error codes are 32-bit values (bit 31 is the most significant bit).
        /// Bit 29 is reserved for application-defined error codes; no system error code has this bit set.
        /// If you are defining an error code for your application, set this bit to one.
        /// That indicates that the error code has been defined by an application,
        /// and ensures that your error code does not conflict with any error codes defined by the system.
        /// </para>
        /// <para>
        /// To convert a system error into an <see cref="HRESULT"/> value, use the <see cref="HRESULT_FROM_WIN32"/> macro.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        public static SystemErrorCodes GetLastError() => (SystemErrorCodes)Marshal.GetLastWin32Error();

        /// <summary>
        /// <para>
        /// Retrieves the error mode for the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-getthreaderrormode"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// The process error mode. This function returns one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Uses the system default, which is to display all error dialog boxes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_FAILCRITICALERRORS"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The system does not display the critical-error-handler message box.
        /// Instead, the system sends the error to the calling thread.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_NOGPFAULTERRORBOX"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The system does not display the Windows Error Reporting dialog.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_NOOPENFILEERRORBOX"/>
        /// </para>
        /// <para>
        /// 0x8000
        /// </para>
        /// </term>
        /// <term>
        /// The system does not display a message box when it fails to find a file.
        /// Instead, the error is returned to the calling thread.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// A thread inherits the error mode of the process in which it is running.
        /// To change the error mode for the thread, use the <see cref="SetThreadErrorMode"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadErrorMode", ExactSpelling = true)]
        public static extern ErrorModes GetThreadErrorMode();

        /// <summary>
        /// <para>
        /// Maps a system error code to an <see cref="HRESULT"/> value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winerror/nf-winerror-hresult_from_win32"/>
        /// </para>
        /// </summary>
        /// <param name="x">
        /// The system error code.
        /// </param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This macro is defined as follows:
        /// </para>
        /// <code>
        /// //
        /// // HRESULT_FROM_WIN32(x) used to be a macro, however we now run it as an inline function
        /// // to prevent double evaluation of 'x'. If you still need the macro, you can use __HRESULT_FROM_WIN32(x)
        /// //
        /// #define __HRESULT_FROM_WIN32(x) ((HRESULT)(x) &lt;= 0 ? ((HRESULT)(x)) : ((HRESULT) (((x) &amp; 0x0000FFFF) | (FACILITY_WIN32 &lt;&lt; 16) | 0x80000000)))
        /// 
        /// #ifndef __midl
        /// FORCEINLINE HRESULT HRESULT_FROM_WIN32(unsigned long x) { 
        ///    return (HRESULT)(x) &lt;= 0 ? (HRESULT)(x) : (HRESULT) (((x) &amp; 0x0000FFFF) | (FACILITY_WIN32 &lt;&lt; 16) | 0x80000000);
        /// }
        /// #else
        /// #define HRESULT_FROM_WIN32(x) __HRESULT_FROM_WIN32(x)
        /// #endif
        /// </code>
        /// </remarks>
        public static HRESULT HRESULT_FROM_WIN32(SystemErrorCodes x) =>
            unchecked((int)x) <= 0 ? (HRESULT)(uint)x : (HRESULT)((((uint)x) & 0x0000FFFF) | ((int)FACILITY_WIN32 << 16) | 0x80000000);

        /// <summary>
        /// <para>
        /// Raises an exception in the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-raiseexception"/>
        /// </para>
        /// </summary>
        /// <param name="dwExceptionCode">
        /// <para>
        /// An application-defined exception code of the exception being raised.
        /// The filter expression and exception-handler block of an exception handler
        /// can use the <see cref="GetExceptionCode"/> function to retrieve this value.
        /// </para>
        /// <para>
        /// Note that the system will clear bit 28 of <paramref name="dwExceptionCode"/> before displaying a message
        /// This bit is a reserved exception bit, used by the system for its own purposes.
        /// </para>
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
        /// <para>
        /// The <see cref="RaiseException"/> function enables a process to use structured exception handling
        /// to handle private, software-generated, application-defined exceptions.
        /// </para>
        /// <para>
        /// Raising an exception causes the exception dispatcher to go through the following search for an exception handler:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// The system first attempts to notify the process's debugger, if any.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the process is not being debugged, or if the associated debugger does not handle the exception,
        /// the system attempts to locate a frame-based exception handler
        /// by searching the stack frames of the thread in which the exception occurred.
        /// The system searches the current stack frame first, then proceeds backward through preceding stack frames.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If no frame-based handler can be found, or no frame-based handler handles the exception,
        /// the system makes a second attempt to notify the process's debugger.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the process is not being debugged, or if the associated debugger does not handle the exception,
        /// the system provides default handling based on the exception type.
        /// For most exceptions, the default action is to call the <see cref="ExitProcess"/> function.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The values specified in the <paramref name="dwExceptionCode"/>, <paramref name="dwExceptionFlags"/>,
        /// <paramref name="nNumberOfArguments"/>, and <paramref name="lpArguments"/> parameters
        /// can be retrieved in the filter expression of a frame-based exception handler by calling the <see cref="GetExceptionInformation"/> function.
        /// A debugger can retrieve these values by calling the <see cref="WaitForDebugEvent"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RaiseException", ExactSpelling = true)]
        public static extern void RaiseException([In] ExceptionCodes dwExceptionCode, [In] ExceptionFlags dwExceptionFlags,
            [In] DWORD nNumberOfArguments, [In] ULONG_PTR[] lpArguments);

        /// <summary>
        /// <para>
        /// Controls whether the system will handle the specified types of serious errors or whether the process will handle them.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-seterrormode"/>
        /// </para>
        /// </summary>
        /// <param name="uMode">
        /// <para>
        /// The process error mode.
        /// This parameter can be one or more of the following values.
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
        /// 0
        /// </term>
        /// <term>
        /// Use the system default, which displays all error dialog boxes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_FAILCRITICALERRORS"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The system does not display the critical-error-handler message box.
        /// Instead, the system sends the error to the calling process.
        /// </para>
        /// <para>
        /// Best practice is that all applications call the process-wide <see cref="SetErrorMode"/> function
        /// with a parameter of <see cref="SEM_FAILCRITICALERRORS"/> at startup.
        /// This is to prevent error mode dialogs from hanging the application.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_NOALIGNMENTFAULTEXCEPT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The system automatically fixes memory alignment faults and makes them invisible to the application.
        /// It does this for the calling process and any descendant processes.
        /// This feature is only supported by certain processor architectures.
        /// For more information, see the Remarks section.
        /// </para>
        /// <para>
        /// After this value is set for a process, subsequent attempts to clear the value are ignored.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_NOGPFAULTERRORBOX"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The system does not invoke Windows Error Reporting.
        /// To disable Windows Error Reporting UI, call <see cref="WerSetFlags"/> with the <see cref="WER_FAULT_REPORTING_NO_UI"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_NOOPENFILEERRORBOX"/>
        /// </para>
        /// <para>
        /// 0x8000
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="OpenFile"/> function does not display a message box when it fails to find a file.
        /// Instead, the error is returned to the caller.
        /// This error mode overrides the <see cref="OF_PROMPT"/> flag.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// The return value is the previous state of the error-mode bit flags.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Each process has an associated error mode that indicates to the system how the application is going to respond to serious errors.
        /// A child process inherits the error mode of its parent process.
        /// To retrieve the process error mode, use the <see cref="GetErrorMode"/> function.
        /// </para>
        /// <para>
        /// Because the error mode is set for the entire process,
        /// you must ensure that multi-threaded applications do not set different error-mode flags.
        /// Doing so can lead to inconsistent error handling.
        /// </para>
        /// <para>
        /// The system does not make alignment faults visible to an application on all processor architectures.
        /// Therefore, specifying <see cref="SEM_NOALIGNMENTFAULTEXCEPT"/> is not an error on such architectures,
        /// but the system is free to silently ignore the request.
        /// This means that code sequences such as the following are not always valid on x86 computers:
        /// </para>
        /// <code>
        /// SetErrorMode(SEM_NOALIGNMENTFAULTEXCEPT); 
        /// fuOldErrorMode = SetErrorMode(0); 
        /// ASSERT(fuOldErrorMode == SEM_NOALIGNMENTFAULTEXCEPT);
        /// </code>
        /// <para>
        /// Itanium:
        /// An application must explicitly call <see cref="SetErrorMode"/> with <see cref="SEM_NOALIGNMENTFAULTEXCEPT"/>
        /// to have the system automatically fix alignment faults.
        /// The default setting is for the system to make alignment faults visible to an application.
        /// </para>
        /// <para>
        /// Visual Studio 2005:
        /// When declaring a pointer to a structure that may not have aligned data,
        /// you can use the __unaligned keyword to indicate that the type must be read one byte at a time.
        /// For more information, see Windows Data Alignment.
        /// </para>
        /// <para>
        /// Windows 7:
        /// Callers should favor <see cref="SetThreadErrorMode"/> over <see cref="SetErrorMode"/>
        /// since it is less disruptive to the normal behavior of the system.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetErrorMode", ExactSpelling = true)]
        public static extern UINT SetErrorMode([In] ErrorModes uMode);

        /// <summary>
        /// <para>
        /// Sets the last-error code for the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-setlasterror"/>
        /// </para>
        /// </summary>
        /// <param name="dwErrCode">
        /// The last-error code for the thread.
        /// </param>
        /// <remarks>
        /// <para>
        /// The last-error code is kept in thread local storage so that multiple threads do not overwrite each other's values.
        /// </para>
        /// <para>
        /// Most functions call <see cref="SetLastError"/> or <see cref="SetLastErrorEx"/> only when they fail.
        /// However, some system functions call <see cref="SetLastError"/> or <see cref="SetLastErrorEx"/> under conditions of success;
        /// those cases are noted in each function's documentation.
        /// </para>
        /// <para>
        /// Applications can optionally retrieve the value set by this function
        /// by using the <see cref="GetLastError"/> function immediately after a function fails.
        /// </para>
        /// <para>
        /// Error codes are 32-bit values (bit 31 is the most significant bit).
        /// Bit 29 is reserved for application-defined error codes; no system error code has this bit set.
        /// If you are defining an error code for your application, set this bit to indicate that the error code has been defined by your application
        /// and to ensure that your error code does not conflict with any system-defined error codes.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetLastError", ExactSpelling = true, SetLastError = true)]
        public static extern void SetLastError([In] SystemErrorCodes dwErrCode);

        /// <summary>
        /// <para>
        /// Controls whether the system will handle the specified types of serious errors or whether the calling thread will handle them.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-setthreaderrormode"/>
        /// </para>
        /// </summary>
        /// <param name="dwNewMode">
        /// <para>
        /// The thread error mode.
        /// This parameter can be one or more of the following values.
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
        /// 0
        /// </term>
        /// <term>
        /// Use the system default, which is to display all error dialog boxes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_FAILCRITICALERRORS"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The system does not display the critical-error-handler message box.
        /// Instead, the system sends the error to the calling thread.
        /// </para>
        /// <para>
        /// Best practice is that all applications call the process-wide <see cref="SetErrorMode"/> function
        /// with a parameter of <see cref="SEM_FAILCRITICALERRORS"/> at startup.
        /// This is to prevent error mode dialogs from hanging the application.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_NOGPFAULTERRORBOX"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The system does not display the Windows Error Reporting dialog.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SEM_NOOPENFILEERRORBOX"/>
        /// </para>
        /// <para>
        /// 0x8000
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="OpenFile"/> function does not display a message box when it fails to find a file.
        /// Instead, the error is returned to the caller.
        /// This error mode overrides the <see cref="OF_PROMPT"/> flag.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpOldMode">
        /// If the function succeeds, this parameter is set to the thread's previous error mode.
        /// This parameter can be <see cref="NullRef{ErrorModes}"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Each process has an associated error mode that indicates to the system how the application is going to respond to serious errors.
        /// A thread inherits the error mode of the process in which it is running.
        /// To retrieve the process error mode, use the <see cref="GetErrorMode"/> function.
        /// To retrieve the error mode of the calling thread, use the <see cref="GetThreadErrorMode"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadErrorMode", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadErrorMode([In] ErrorModes dwNewMode, [Out] out ErrorModes lpOldMode);

        /// <summary>
        /// <para>
        /// Enables an application to supersede the top-level exception handler of each thread of a process.
        /// </para>
        /// <para>
        /// After calling this function, if an exception occurs in a process that is not being debugged,
        /// and the exception makes it to the unhandled exception filter,
        /// that filter will call the exception filter function specified by the <paramref name="lpTopLevelExceptionFilter"/> parameter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-setunhandledexceptionfilter"/>
        /// </para>
        /// </summary>
        /// <param name="lpTopLevelExceptionFilter">
        /// <para>
        /// A pointer to a top-level exception filter function that will be called
        /// whenever the <see cref="UnhandledExceptionFilter"/> function gets control, and the process is not being debugged.
        /// A value of <see cref="NULL"/> for this parameter specifies default handling within <see cref="UnhandledExceptionFilter"/>.
        /// </para>
        /// <para>
        /// The filter function has syntax similar to that of <see cref="UnhandledExceptionFilter"/>:
        /// It takes a single parameter of type LPEXCEPTION_POINTERS, has a WINAPI calling convention,
        /// and returns a value of type <see cref="LONG"/>.
        /// The filter function should return one of the following values.
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
        /// <see cref="EXCEPTION_EXECUTE_HANDLER"/>
        /// </para>
        /// <para>
        /// 0x1
        /// </para>
        /// </term>
        /// <term>
        /// Return from <see cref="UnhandledExceptionFilter"/> and execute the associated exception handler.
        /// This usually results in process termination.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EXCEPTION_CONTINUE_EXECUTION"/>
        /// </para>
        /// <para>
        /// 0xffffffff
        /// </para>
        /// </term>
        /// <term>
        /// Return from <see cref="UnhandledExceptionFilter"/> and continue execution from the point of the exception.
        /// Note that the filter function is free to modify the continuation state by modifying the exception information
        /// supplied through its LPEXCEPTION_POINTERS parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EXCEPTION_CONTINUE_SEARCH"/>
        /// </para>
        /// <para>
        /// 0x0
        /// </para>
        /// </term>
        /// <term>
        /// Proceed with normal execution of <see cref="UnhandledExceptionFilter"/>.
        /// That means obeying the <see cref="SetErrorMode"/> flags, or invoking the Application Error pop-up message box.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// The <see cref="SetUnhandledExceptionFilter"/> function returns the address of the previous exception filter established with the function.
        /// A <see cref="NULL"/> return value means that there is no current top-level exception handler.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Issuing <see cref="SetUnhandledExceptionFilter"/> replaces the existing top-level exception filter
        /// for all existing and all future threads in the calling process.
        /// </para>
        /// <para>
        /// The exception handler specified by <paramref name="lpTopLevelExceptionFilter"/> is executed in the context of the thread that caused the fault.
        /// This can affect the exception handler's ability to recover from certain exceptions, such as an invalid stack.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetUnhandledExceptionFilter", ExactSpelling = true)]
        public static extern LPTOP_LEVEL_EXCEPTION_FILTER SetUnhandledExceptionFilter([In] LPTOP_LEVEL_EXCEPTION_FILTER lpTopLevelExceptionFilter);

        /// <summary>
        /// <para>
        /// An application-defined function that passes unhandled exceptions to the debugger, if the process is being debugged.
        /// Otherwise, it optionally displays an Application Error message box and causes the exception handler to be executed.
        /// This function can be called only from within the filter expression of an exception handler.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-unhandledexceptionfilter"/>
        /// </para>
        /// </summary>
        /// <param name="ExceptionInfo">
        /// A pointer to an <see cref="EXCEPTION_POINTERS"/> structure that specifies a description of the exception
        /// and the processor context at the time of the exception.
        /// This pointer is the return value of a call to the <see cref="GetExceptionInformation"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// The function returns one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EXCEPTION_CONTINUE_SEARCH"/>
        /// </para>
        /// <para>
        /// 0x0
        /// </para>
        /// </term>
        /// <term>
        /// The process is being debugged, so the exception should be passed (as second chance) to the application's debugger.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EXCEPTION_EXECUTE_HANDLER"/>
        /// </para>
        /// <para>
        /// 0x1
        /// </para>
        /// </term>
        /// <term>
        /// If the <see cref="SEM_NOGPFAULTERRORBOX"/> flag was specified in a previous call to <see cref="SetErrorMode"/>,
        /// no Application Error message box is displayed.
        /// The function returns control to the exception handler, which is free to take any appropriate action.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the process is not being debugged, the function displays an Application Error message box, depending on the current error mode.
        /// The default behavior is to display the dialog box, but this can be disabled
        /// by specifying <see cref="SEM_NOGPFAULTERRORBOX"/> in a call to the <see cref="SetErrorMode"/> function.
        /// </para>
        /// <para>
        /// The system uses <see cref="UnhandledExceptionFilter"/> internally to handle exceptions that occur during process and thread creation.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnhandledExceptionFilter", ExactSpelling = true)]
        public static extern LONG UnhandledExceptionFilter([Out] out EXCEPTION_POINTERS ExceptionInfo);
    }
}
