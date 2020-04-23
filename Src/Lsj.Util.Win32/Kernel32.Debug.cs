using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DebuggingEvents;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Enables a debugger to continue a thread that previously reported a debugging event.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/debugapi/nf-debugapi-continuedebugevent
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
        /// The options to continue the thread that reported the debugging event.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Only the thread that created dwProcessId with the <see cref="CreateProcess"/> function can call <see cref="ContinueDebugEvent"/>.
        /// After the <see cref="ContinueDebugEvent"/> function succeeds, the specified thread continues.
        /// Depending on the debugging event previously reported by the thread, different actions occur.
        /// If the continued thread previously reported an <see cref="EXIT_THREAD_DEBUG_EVENT"/> debugging event,
        /// <see cref="ContinueDebugEvent"/> closes the handle the debugger has to the thread.
        /// If the continued thread previously reported an <see cref="EXIT_PROCESS_DEBUG_EVENT"/> debugging event,
        /// <see cref="ContinueDebugEvent"/> closes the handles the debugger has to the process and to the thread.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ContinueDebugEvent", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ContinueDebugEvent([In]uint dwProcessId, [In]uint dwThreadId, [In]DebugContinueStatus dwContinueStatus);

        /// <summary>
        /// <para>
        /// Enables a debugger to attach to an active process and debug it.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/debugapi/nf-debugapi-debugactiveprocess
        /// </para>
        /// </summary>
        /// <param name="dwProcessId">
        /// The identifier for the process to be debugged.
        /// The debugger is granted debugging access to the process as if it created the process with the <see cref="DEBUG_ONLY_THIS_PROCESS"/> flag.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To stop debugging the process, you must exit the process or call the <see cref="DebugActiveProcessStop"/> function.
        /// Exiting the debugger also exits the process unless you use the <see cref="DebugSetProcessKillOnExit"/> function.
        /// The debugger must have appropriate access to the target process, and it must be able to open the process for <see cref="PROCESS_ALL_ACCESS"/>.
        /// <see cref="DebugActiveProcess"/> can fail if the target process is created with a security descriptor
        /// that grants the debugger anything less than full access.
        /// If the debugging process has the SE_DEBUG_NAME privilege granted and enabled, it can debug any process.
        /// After the system checks the process identifier and determines
        /// that a valid debugging attachment is being made, the function returns <see cref="TRUE"/>.
        /// Then the debugger is expected to wait for debugging events by using the <see cref="WaitForDebugEvent"/> function.
        /// The system suspends all threads in the process, and sends the debugger events that represents the current state of the process.
        /// The system sends the debugger a single <see cref="CREATE_PROCESS_DEBUG_EVENT"/> debugging event
        /// that represents the process specified by the <paramref name="dwProcessId"/> parameter.
        /// The <see cref="CREATE_PROCESS_DEBUG_INFO.lpStartAddress"/> member of the <see cref="CREATE_PROCESS_DEBUG_INFO"/> structure is <see cref="NULL"/>.
        /// For each thread that is currently part of the process, the system sends a <see cref="CREATE_THREAD_DEBUG_EVENT"/> debugging event.
        /// The <see cref="CREATE_THREAD_DEBUG_INFO.lpStartAddress"/> member of the <see cref="CREATE_THREAD_DEBUG_INFO"/> structure is <see cref="NULL"/>.
        /// For each dynamic-link library (DLL) that is currently loaded into the address space of the target process,
        /// the system sends a <see cref="LOAD_DLL_DEBUG_EVENT"/> debugging event.
        /// The system arranges for the first thread in the process to execute a breakpoint instruction after it resumes.
        /// Continuing this thread causes it to return to doing the same thing as before the debugger is attached.
        /// After all of this is done, the system resumes all threads in the process.
        /// When the first thread in the process resumes, it executes a breakpoint instruction
        /// that causes an <see cref="EXCEPTION_DEBUG_EVENT"/> debugging event to be sent to the debugger.
        /// All future debugging events are sent to the debugger by using the normal mechanism and rules.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DebugActiveProcess", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DebugActiveProcess([In]DWORD dwProcessId);

        /// <summary>
        /// <para>
        /// Stops the debugger from debugging the specified process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/debugapi/nf-debugapi-debugactiveprocessstop
        /// </para>
        /// </summary>
        /// <param name="dwProcessId">
        /// The identifier of the process to stop debugging.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DebugActiveProcessStop", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DebugActiveProcessStop([In]DWORD dwProcessId);

        /// <summary>
        /// <para>
        /// Causes a breakpoint exception to occur in the current process.
        /// This allows the calling thread to signal the debugger to handle the exception.
        /// To cause a breakpoint exception in another process, use the <see cref="DebugBreakProcess"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/debugapi/nf-debugapi-debugbreak
        /// </para>
        /// </summary>
        /// <remarks>
        /// If the process is not being debugged, the function uses the search logic of a standard exception handler.
        /// In most cases, this causes the calling process to terminate because of an unhandled breakpoint exception.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DebugBreak", ExactSpelling = true, SetLastError = true)]
        public static extern void DebugBreak();

        /// <summary>
        /// <para>
        /// Causes a breakpoint exception to occur in the specified process.
        /// This allows the calling thread to signal the debugger to handle the exception.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-debugbreakprocess
        /// </para>
        /// </summary>
        /// <param name="Process">
        /// A handle to the process.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the process is not being debugged, the function uses the search logic of a standard exception handler.
        /// In most cases, this causes the process to terminate because of an unhandled breakpoint exception.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DebugBreakProcess", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DebugBreakProcess([In]HANDLE Process);

        /// <summary>
        /// <para>
        /// Sets the action to be performed when the calling thread exits.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-debugsetprocesskillonexit
        /// </para>
        /// </summary>
        /// <param name="KillOnExit">
        /// If this parameter is <see cref="TRUE"/>, the thread terminates all attached processes on exit (note that this is the default).
        /// Otherwise, the thread detaches from all processes being debugged on exit.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The calling thread must have established at least one debugging connection using the <see cref="CreateProcess"/>
        /// or <see cref="DebugActiveProcess"/> function before calling this function.
        /// <see cref="DebugSetProcessKillOnExit"/> affects all current and future debuggees connected to the calling thread.
        /// A thread can call this function multiple times to change the action as needed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DebugSetProcessKillOnExit", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DebugSetProcessKillOnExit([In]BOOL KillOnExit);

        /// <summary>
        /// <para>
        /// Transfers execution control to the debugger.
        /// The behavior of the debugger thereafter is specific to the type of debugger used.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-fatalexit
        /// </para>
        /// </summary>
        /// <param name="ExitCode">
        /// The error code associated with the exit.
        /// </param>
        /// <remarks>
        /// An application should only use <see cref="FatalExit"/> for debugging purposes.
        /// It should not call the function in a retail version of the application because doing so will terminate the application.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FatalExit", ExactSpelling = true, SetLastError = true)]
        public static extern void FatalExit([In]int ExitCode);

        /// <summary>
        /// <para>
        /// Waits for a debugging event to occur in a process being debugged.
        /// In the past, the operating system did not output Unicode strings via <see cref="OutputDebugString"/> and instead only output ASCII strings.
        /// To force <see cref="OutputDebugString"/> to correctly output Unicode strings,
        /// debuggers are required to call <see cref="WaitForDebugEventEx"/> to opt into the new behavior.
        /// On calling <see cref="WaitForDebugEventEx"/>, the operating system will know that the debugger supports Unicode
        /// and is specifically opting into receiving Unicode strings.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/debugapi/nf-debugapi-waitfordebugevent
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
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Only the thread that created the process being debugged can call <see cref="WaitForDebugEvent"/>.
        /// When a <see cref="CREATE_PROCESS_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the image file of the process being debugged,
        /// a handle to the process being debugged, and a handle to the initial thread of the process being debugged in the <see cref="DEBUG_EVENT"/> structure.
        /// The members these handles are returned in are u.CreateProcessInfo.hFile (image file), u.CreateProcessInfo.hProcess (process),
        /// and u.CreateProcessInfo.hThread (initial thread).
        /// If the system previously reported an <see cref="EXIT_PROCESS_DEBUG_EVENT"/> debugging event,
        /// the system closes the handles to the process and thread when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// The debugger should close the handle to the image file by calling the CloseHandle function.
        /// Similarly, when a <see cref="CREATE_THREAD_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the thread
        /// whose creation caused the debugging event in the u.CreateThread.hThread member of the <see cref="DEBUG_EVENT"/> structure.
        /// If the system previously reported an <see cref="EXIT_THREAD_DEBUG_EVENT"/> debugging event,
        /// the system closes the handles to the thread when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// When a <see cref="LOAD_DLL_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the loaded DLL
        /// in the u.LoadDll.hFile member of the <see cref="DEBUG_EVENT"/> structure.
        /// This handle should be closed by the debugger application by calling the <see cref="CloseHandle"/> function.
        /// Do not queue an asynchronous procedure call (APC) to a thread that calls <see cref="WaitForDebugEvent"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForDebugEvent", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WaitForDebugEvent([In]IntPtr lpDebugEvent, [In]uint dwMilliseconds);

        /// <summary>
        /// <para>
        /// Sends a string to the debugger for display.
        /// Important
        /// In the past, the operating system did not output Unicode strings via <see cref="OutputDebugString"/> and instead only output ASCII strings.
        /// To force <see cref="OutputDebugString"/> to correctly output Unicode strings,
        /// debuggers are required to call <see cref="WaitForDebugEventEx"/> to opt into the new behavior.
        /// On calling <see cref="WaitForDebugEventEx"/>, the operating system will know that the debugger supports Unicode
        /// and is specifically opting into receiving Unicode strings.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/debugapi/nf-debugapi-outputdebugstringw
        /// </para>
        /// </summary>
        /// <param name="lpOutputString">
        /// The null-terminated string to be displayed.
        /// </param>
        /// <remarks>
        /// If the application has no debugger, the system debugger displays the string if the filter mask allows it.
        /// (Note that this function calls the DbgPrint function to display the string.
        /// For details on how the filter mask controls what the system debugger displays,
        /// see the DbgPrint function in the Windows Driver Kit (WDK) on MSDN.)
        /// If the application has no debugger and the system debugger is not active, <see cref="OutputDebugString"/> does nothing.
        /// Prior to Windows Vista: The system debugger does not filter content.
        /// <see cref="OutputDebugString"/> converts the specified string based on the current system locale information
        /// and passes it to OutputDebugStringA to be displayed.
        /// As a result, some Unicode characters may not be displayed correctly.
        /// Applications should send very minimal debug output and provide a way for the user to enable or disable its use.
        /// To provide more detailed tracing, see Event Tracing.
        /// Visual Studio has changed how it handles the display of these strings throughout its revision history.
        /// Refer to the Visual Studio documentation for details of how your version deals with this.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OutputDebugStringW", ExactSpelling = true, SetLastError = true)]
        public static extern void OutputDebugString([MarshalAs(UnmanagedType.LPWStr)][In]string lpOutputString
);
    }
}
