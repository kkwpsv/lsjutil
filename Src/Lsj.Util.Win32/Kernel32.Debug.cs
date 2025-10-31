using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DebugEventContinueStatus;
using static Lsj.Util.Win32.Enums.DebuggingEvents;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Determines whether the specified process is being debugged.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/debugapi/nf-debugapi-checkremotedebuggerpresent"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// </param>
        /// <param name="pbDebuggerPresent">
        /// A pointer to a variable that the function sets to <see cref="TRUE"/> if the specified process is being debugged, or <see cref="FALSE"/> otherwise.
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
        /// <para>
        /// The "remote" in <see cref="CheckRemoteDebuggerPresent"/> does not imply that the debugger necessarily resides on a different computer;
        /// instead, it indicates that the debugger resides in a separate and parallel process.
        /// Use the <see cref="IsDebuggerPresent"/> function to detect whether the calling process is running under the debugger.
        /// </para>
        /// <para>
        /// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0501 or later.
        /// For more information, see Using the Windows Headers.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP1")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckRemoteDebuggerPresent", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CheckRemoteDebuggerPresent([In] HANDLE hProcess, [In][Out] ref BOOL pbDebuggerPresent);

        /// <summary>
        /// <para>
        /// Enables a debugger to continue a thread that previously reported a debugging event.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/debugapi/nf-debugapi-continuedebugevent"/>
        /// </para>
        /// </summary>
        /// <param name="dwProcessId">
        /// The process identifier of the process to continue.
        /// </param>
        /// <param name="dwThreadId">
        /// The thread identifier of the thread to continue.
        /// The combination of process identifier and thread identifier must identify a thread that has previously reported a debugging event.
        /// </param>
        /// <param name="dwContinueStatus">
        /// <para>
        /// The options to continue the thread that reported the debugging event.
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
        /// <see cref="DBG_CONTINUE"/>
        /// </para>
        /// <para>
        /// 0x00010002L
        /// </para>
        /// </term>
        /// <term>
        /// If the thread specified by the <paramref name="dwThreadId"/> parameter previously reported an <see cref="EXCEPTION_DEBUG_EVENT"/> debugging event,
        /// the function stops all exception processing and continues the thread and the exception is marked as handled.
        /// For any other debugging event, this flag simply continues the thread.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBG_EXCEPTION_NOT_HANDLED"/>
        /// </para>
        /// <para>
        /// 0x80010001L
        /// </para>
        /// </term>
        /// <term>
        /// If the thread specified by <paramref name="dwThreadId"/> previously reported an <see cref="EXCEPTION_DEBUG_EVENT"/> debugging event,
        /// the function continues exception processing.
        /// If this is a first-chance exception event, the search and dispatch logic of the structured exception handler is used;
        /// otherwise, the process is terminated.
        /// For any other debugging event, this flag simply continues the thread.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBG_REPLY_LATER"/>
        /// </para>
        /// <para>
        /// 0x40010001L
        /// </para>
        /// </term>
        /// <term>
        /// Supported in Windows 10, version 1507 or above,
        /// this flag causes <paramref name="dwThreadId"/> to replay the existing breaking event after the target continues.
        /// By calling the <see cref="SuspendThread"/> API against <paramref name="dwThreadId"/>,
        /// a debugger can resume other threads in the process and later return to the breaking.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        /// <para>
        /// Only the thread that created <paramref name="dwProcessId"/> with the <see cref="CreateProcess"/> function can call <see cref="ContinueDebugEvent"/>.
        /// </para>
        /// <para>
        /// After the <see cref="ContinueDebugEvent"/> function succeeds, the specified thread continues.
        /// Depending on the debugging event previously reported by the thread, different actions occur.
        /// If the continued thread previously reported an <see cref="EXIT_THREAD_DEBUG_EVENT"/> debugging event,
        /// <see cref="ContinueDebugEvent"/> closes the handle the debugger has to the thread.
        /// If the continued thread previously reported an <see cref="EXIT_PROCESS_DEBUG_EVENT"/> debugging event,
        /// <see cref="ContinueDebugEvent"/> closes the handles the debugger has to the process and to the thread.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ContinueDebugEvent", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ContinueDebugEvent([In] DWORD dwProcessId, [In] DWORD dwThreadId, [In] DebugEventContinueStatus dwContinueStatus);

        /// <summary>
        /// <para>
        /// Enables a debugger to attach to an active process and debug it.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/debugapi/nf-debugapi-debugactiveprocess"/>
        /// </para>
        /// </summary>
        /// <param name="dwProcessId">
        /// The identifier for the process to be debugged.
        /// The debugger is granted debugging access to the process as if it created the process with the <see cref="DEBUG_ONLY_THIS_PROCESS"/> flag.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is 0 (zero).
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To stop debugging the process, you must exit the process or call the <see cref="DebugActiveProcessStop"/> function.
        /// Exiting the debugger also exits the process unless you use the <see cref="DebugSetProcessKillOnExit"/> function.
        /// </para>
        /// <para>
        /// The debugger must have appropriate access to the target process,
        /// and it must be able to open the process for <see cref="PROCESS_ALL_ACCESS"/>.
        /// <see cref="DebugActiveProcess"/> can fail if the target process is created with a security descriptor
        /// that grants the debugger anything less than full access.
        /// If the debugging process has the <see cref="SE_DEBUG_NAME"/> privilege granted and enabled, it can debug any process.
        /// </para>
        /// <para>
        /// After the system checks the process identifier and determines that a valid debugging attachment is being made, 
        /// the function returns <see cref="TRUE"/>.
        /// Then the debugger is expected to wait for debugging events by using the <see cref="WaitForDebugEvent"/> function.
        /// The system suspends all threads in the process, and sends the debugger events that represents the current state of the process.
        /// </para>
        /// <para>
        /// The system sends the debugger a single <see cref="CREATE_PROCESS_DEBUG_EVENT"/> debugging event
        /// that represents the process specified by the <paramref name="dwProcessId"/> parameter.
        /// The <see cref="CREATE_PROCESS_DEBUG_INFO.lpStartAddress"/> member of the <see cref="CREATE_PROCESS_DEBUG_INFO"/> structure is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// For each thread that is currently part of the process, the system sends a <see cref="CREATE_THREAD_DEBUG_EVENT"/> debugging event.
        /// The <see cref="CREATE_THREAD_DEBUG_INFO.lpStartAddress"/> member of the <see cref="CREATE_THREAD_DEBUG_INFO"/> structure is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// For each dynamic-link library (DLL) that is currently loaded into the address space of the target process,
        /// the system sends a <see cref="LOAD_DLL_DEBUG_EVENT"/> debugging event.
        /// The system arranges for the first thread in the process to execute a breakpoint instruction after it resumes.
        /// Continuing this thread causes it to return to doing the same thing as before the debugger is attached.
        /// </para>
        /// <para>
        /// After all of this is done, the system resumes all threads in the process.
        /// When the first thread in the process resumes, it executes a breakpoint instruction
        /// that causes an <see cref="EXCEPTION_DEBUG_EVENT"/> debugging event to be sent to the debugger.
        /// All future debugging events are sent to the debugger by using the normal mechanism and rules.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DebugActiveProcess", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DebugActiveProcess([In] DWORD dwProcessId);

        /// <summary>
        /// <para>
        /// Stops the debugger from debugging the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/debugapi/nf-debugapi-debugactiveprocessstop"/>
        /// </para>
        /// </summary>
        /// <param name="dwProcessId">
        /// The identifier of the process to stop debugging.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DebugActiveProcessStop", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DebugActiveProcessStop([In] DWORD dwProcessId);

        /// <summary>
        /// <para>
        /// Causes a breakpoint exception to occur in the current process.
        /// This allows the calling thread to signal the debugger to handle the exception.
        /// </para>
        /// <para>
        /// To cause a breakpoint exception in another process, use the <see cref="DebugBreakProcess"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/debugapi/nf-debugapi-debugbreak"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// If the process is not being debugged, the function uses the search logic of a standard exception handler.
        /// In most cases, this causes the calling process to terminate because of an unhandled breakpoint exception.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DebugBreak", ExactSpelling = true)]
        public static extern void DebugBreak();

        /// <summary>
        /// <para>
        /// Causes a breakpoint exception to occur in the specified process.
        /// This allows the calling thread to signal the debugger to handle the exception.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-debugbreakprocess"/>
        /// </para>
        /// </summary>
        /// <param name="Process">
        /// A handle to the process.
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
        /// If the process is not being debugged, the function uses the search logic of a standard exception handler.
        /// In most cases, this causes the process to terminate because of an unhandled breakpoint exception.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DebugBreakProcess", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DebugBreakProcess([In] HANDLE Process);

        /// <summary>
        /// <para>
        /// Sets the action to be performed when the calling thread exits.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-debugsetprocesskillonexit"/>
        /// </para>
        /// </summary>
        /// <param name="KillOnExit">
        /// If this parameter is <see cref="TRUE"/>, the thread terminates all attached processes on exit (note that this is the default).
        /// Otherwise, the thread detaches from all processes being debugged on exit.
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
        /// The calling thread must have established at least one debugging connection using the <see cref="CreateProcess"/>
        /// or <see cref="DebugActiveProcess"/> function before calling this function.
        /// <see cref="DebugSetProcessKillOnExit"/> affects all current and future debuggees connected to the calling thread.
        /// A thread can call this function multiple times to change the action as needed.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DebugSetProcessKillOnExit", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DebugSetProcessKillOnExit([In] BOOL KillOnExit);

        /// <summary>
        /// <para>
        /// Determines whether the calling process is being debugged by a user-mode debugger.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/debugapi/nf-debugapi-isdebuggerpresent"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the current process is running in the context of a debugger, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the current process is not running in the context of a debugger, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function allows an application to determine whether or not it is being debugged, so that it can modify its behavior.
        /// For example, an application could provide additional information using the <see cref="OutputDebugString"/> function if it is being debugged.
        /// </para>
        /// <para>
        /// To determine whether a remote process is being debugged, use the <see cref="CheckRemoteDebuggerPresent"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsDebuggerPresent", ExactSpelling = true)]
        public static extern BOOL IsDebuggerPresent();

        /// <summary>
        /// <para>
        /// Sends a string to the debugger for display.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/debugapi/nf-debugapi-outputdebugstringw"/>
        /// </para>
        /// </summary>
        /// <param name="lpOutputString">
        /// The null-terminated string to be displayed.
        /// </param>
        /// <remarks>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// To use this function, you must include the Windows.h header in your application (not debugapi.h).
        /// </para>
        /// <para>
        /// In the past, the operating system did not return Unicode strings
        /// through <see cref="OutputDebugString"/> (ASCII strings were returned instead).
        /// To force <see cref="OutputDebugString"/> to return Unicode strings,
        /// debuggers are required to call the <see cref="WaitForDebugEventEx"/> function to opt into the new behavior.
        /// In this way, the operating system knows that the debugger supports Unicode and is specifically opting into receiving Unicode strings.
        /// </para>
        /// <para>
        /// If the application does not have a debugger, and the filter mask allows it, the system debugger displays the string.
        /// To display the string, this function calls the DbgPrint function.
        /// Prior to Windows Vista, content was not filtered by the system debugger.
        /// </para>
        /// <para>
        /// If the application does not have a debugger and the system debugger is not active, <see cref="OutputDebugString"/> does nothing.
        /// </para>
        /// <para>
        /// <see cref="OutputDebugString"/> converts the specified string based on the current system locale information
        /// and passes it to OutputDebugStringA to be displayed.
        /// As a result, some Unicode characters may not be displayed correctly.
        /// </para>
        /// <para>
        /// Applications should send very minimal debug output and provide a way for the user to enable or disable its use.
        /// See Event Tracing to learn more about tracing details.
        /// </para>
        /// <para>
        /// Visual Studio has changed how it handles the display of these strings throughout its revision history.
        /// Refer to the Visual Studio documentation for details of how your version deals with this.
        /// </para>
        /// <para>
        /// The debugapi.h header defines OutputDebugString as an alias that automatically selects the ANSI or Unicode versio
        /// n of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that is not encoding-neutral
        /// can lead to mismatches and compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OutputDebugStringW", ExactSpelling = true)]
        public static extern void OutputDebugString([In] LPCWSTR lpOutputString);

        /// <summary>
        /// <para>
        /// Waits for a debugging event to occur in a process being debugged.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// In the past, the operating system did not output Unicode strings via <see cref="OutputDebugString"/> and instead only output ASCII strings.
        /// To force <see cref="OutputDebugString"/> to correctly output Unicode strings,
        /// debuggers are required to call <see cref="WaitForDebugEventEx"/> to opt into the new behavior.
        /// On calling <see cref="WaitForDebugEventEx"/>, the operating system will know that the debugger supports Unicode
        /// and is specifically opting into receiving Unicode strings.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/debugapi/nf-debugapi-waitfordebugevent"/>
        /// </para>
        /// </summary>
        /// <param name="lpDebugEvent">
        /// A pointer to a <see cref="DEBUG_EVENT"/> structure that receives information about the debugging event.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The number of milliseconds to wait for a debugging event.
        /// If this parameter is zero, the function tests for a debugging event and returns immediately.
        /// If the parameter is <see cref="INFINITE"/>, the function does not return until a debugging event has occurred.
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
        /// <para>
        /// Only the thread that created the process being debugged can call <see cref="WaitForDebugEvent"/>.
        /// </para>
        /// <para>
        /// When a <see cref="CREATE_PROCESS_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the image file of the process being debugged,
        /// a handle to the process being debugged, and a handle to the initial thread of the process being debugged in the <see cref="DEBUG_EVENT"/> structure.
        /// The members these handles are returned in are <c>u.CreateProcessInfo.hFile</c> (image file),
        /// <c>u.CreateProcessInfo.hProcess</c> (process), and <c>u.CreateProcessInfo.hThread</c> (initial thread).
        /// If the system previously reported an <see cref="EXIT_PROCESS_DEBUG_EVENT"/> debugging event,
        /// the system closes the handles to the process and thread when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// The debugger should close the handle to the image file by calling the <see cref="CloseHandle"/> function.
        /// </para>
        /// <para>
        /// Similarly, when a <see cref="CREATE_THREAD_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the thread
        /// whose creation caused the debugging event in the <c>u.CreateThread.hThread</c> member of the <see cref="DEBUG_EVENT"/> structure.
        /// If the system previously reported an <see cref="EXIT_THREAD_DEBUG_EVENT"/> debugging event,
        /// the system closes the handles to the thread when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// </para>
        /// <para>
        /// When a <see cref="LOAD_DLL_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the loaded DLL
        /// in the <c>u.LoadDll.hFile</c> member of the <see cref="DEBUG_EVENT"/> structure.
        /// This handle should be closed by the debugger application by calling the <see cref="CloseHandle"/> function.
        /// </para>
        /// <para>
        /// Warning
        /// </para>
        /// <para>
        /// Do not queue an asynchronous procedure call (APC) to a thread that calls <see cref="WaitForDebugEvent"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForDebugEvent", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WaitForDebugEvent([Out] out DEBUG_EVENT lpDebugEvent, [In] uint dwMilliseconds);

        /// <summary>
        /// <para>
        /// Waits for a debugging event to occur in a process being debugged.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// In the past, the operating system did not output Unicode strings via <see cref="OutputDebugString"/> and instead only output ASCII strings.
        /// To force <see cref="OutputDebugString"/> to correctly output Unicode strings,
        /// debuggers are required to call <see cref="WaitForDebugEventEx"/> to opt into the new behavior.
        /// On calling <see cref="WaitForDebugEventEx"/>, the operating system will know that the debugger supports Unicode
        /// and is specifically opting into receiving Unicode strings.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/debugapi/nf-debugapi-waitfordebugeventex"/>
        /// </para>
        /// </summary>
        /// <param name="lpDebugEvent">
        /// A pointer to a <see cref="DEBUG_EVENT"/> structure that receives information about the debugging event.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The number of milliseconds to wait for a debugging event.
        /// If this parameter is zero, the function tests for a debugging event and returns immediately.
        /// If the parameter is <see cref="INFINITE"/>, the function does not return until a debugging event has occurred.
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
        /// <para>
        /// Only the thread that created the process being debugged can call <see cref="WaitForDebugEventEx"/>.
        /// </para>
        /// <para>
        /// When a <see cref="CREATE_PROCESS_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the image file of the process being debugged,
        /// a handle to the process being debugged, and a handle to the initial thread of the process being debugged in the <see cref="DEBUG_EVENT"/> structure.
        /// The members these handles are returned in are <c>u.CreateProcessInfo.hFile</c> (image file),
        /// <c>u.CreateProcessInfo.hProcess</c> (process), and <c>u.CreateProcessInfo.hThread</c> (initial thread).
        /// If the system previously reported an <see cref="EXIT_PROCESS_DEBUG_EVENT"/> debugging event,
        /// the system closes the handles to the process and thread when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// The debugger should close the handle to the image file by calling the <see cref="CloseHandle"/> function.
        /// </para>
        /// <para>
        /// Similarly, when a <see cref="CREATE_THREAD_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the thread
        /// whose creation caused the debugging event in the <c>u.CreateThread.hThread</c> member of the <see cref="DEBUG_EVENT"/> structure.
        /// If the system previously reported an <see cref="EXIT_THREAD_DEBUG_EVENT"/> debugging event,
        /// the system closes the handles to the thread when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// </para>
        /// <para>
        /// When a <see cref="LOAD_DLL_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the loaded DLL
        /// in the <c>u.LoadDll.hFile</c> member of the <see cref="DEBUG_EVENT"/> structure.
        /// This handle should be closed by the debugger application by calling the <see cref="CloseHandle"/> function.
        /// </para>
        /// <para>
        /// Warning
        /// </para>
        /// <para>
        /// Do not queue an asynchronous procedure call (APC) to a thread that calls <see cref="WaitForDebugEventEx"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows10)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForDebugEventEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WaitForDebugEventEx([Out] out DEBUG_EVENT lpDebugEvent, [In] DWORD dwMilliseconds);
    }
}
