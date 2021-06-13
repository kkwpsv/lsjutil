using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// A debugging event is an incident in the process being debugged that causes the system to notify the debugger.
    /// Debugging events include creating a process, creating a thread, loading a dynamic-link library (DLL), unloading a DLL,
    /// sending an output string, and generating an exception.
    /// If a debugging event occurs while a debugger is waiting for one, the system fills the <see cref="DEBUG_EVENT"/> structure
    /// specified by <see cref="WaitForDebugEvent"/> with information describing the event.
    /// When the system notifies the debugger of a debugging event, it also suspends all threads in the affected process.
    /// The threads do not resume execution until the debugger continues the debugging event by using <see cref="ContinueDebugEvent"/>.
    /// The following debugging events may occur while a process is being debugged.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/debug/debugging-events"/>
    /// </para>
    /// </summary>
    public enum DebuggingEvents
    {
        /// <summary>
        /// Generated whenever an exception occurs in the process being debugged.
        /// Possible exceptions include attempting to access inaccessible memory, executing breakpoint instructions,
        /// attempting to divide by zero, or any other exception noted in Structured Exception Handling.
        /// The DEBUG_EVENT structure contains an <see cref="EXCEPTION_DEBUG_INFO"/> structure.
        /// This structure describes the exception that caused the debugging event.
        /// Besides the standard exception conditions, an additional exception code can occur during console process debugging.
        /// The system generates a <see cref="DBG_CONTROL_C"/> exception code when CTRL+C is input to a console process
        /// that handles CTRL+C signals and is being debugged.
        /// This exception code is not meant to be handled by applications. An application should never use an exception handler to deal with it.
        /// It is raised only for the benefit of the debugger and is only used when a debugger is attached to the console process.
        /// If a process is not being debugged or if the debugger passes on the <see cref="DBG_CONTROL_C"/> exception unhandled (through the gn command),
        /// the application's list of handler functions is searched, as documented for the <see cref="SetConsoleCtrlHandler"/> function.
        /// If the debugger handles the <see cref="DBG_CONTROL_C"/> exception (through the gh command),
        /// an application will not notice the CTRL+C except in code like this.
        /// while ((inputChar = getchar()) != EOF) ...
        /// Thus, the debugger cannot be used to stop the read wait in such code from terminating.
        /// </summary>
        EXCEPTION_DEBUG_EVENT = 1,

        /// <summary>
        /// Generated whenever a new thread is created in a process being debugged or whenever the debugger begins debugging an already active process.
        /// This debugging event is generated before the new thread begins to execute in user mode.
        /// The <see cref="DEBUG_EVENT"/> structure contains a <see cref="CREATE_THREAD_DEBUG_INFO"/> structure.
        /// This structure includes a handle to the new thread and the thread's starting address.
        /// The handle has <see cref="THREAD_GET_CONTEXT"/>, <see cref="THREAD_SET_CONTEXT"/>, and <see cref="THREAD_SUSPEND_RESUME"/> access to the thread.
        /// If a debugger has these types of access to a thread, it can read from and write to the thread's registers
        /// by using the <see cref="GetThreadContext"/> and <see cref="SetThreadContext"/> functions and can suspend and resume the thread
        /// by using the <see cref="SuspendThread"/> and <see cref="ResumeThread"/> functions.
        /// If the system previously reported an <see cref="EXIT_THREAD_DEBUG_EVENT"/> event,
        /// the system closes the handle to the new thread when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// </summary>
        CREATE_THREAD_DEBUG_EVENT = 2,

        /// <summary>
        /// Generated whenever a new process is created in a process being debugged or whenever the debugger begins debugging an already active process.
        /// The system generates this debugging event before the process begins to execute in user mode
        /// and before the system generates any other debugging events for the new process.
        /// The <see cref="DEBUG_EVENT"/> structure contains a <see cref="CREATE_PROCESS_DEBUG_INFO"/> structure.
        /// This structure includes a handle to the new process, a handle to the process's image file, a handle to the process's initial thread,
        /// and other information that describes the new process.
        /// The handle to the process has <see cref="PROCESS_VM_READ"/> and <see cref="PROCESS_VM_WRITE"/> access.
        /// If a debugger has these types of access to a thread, it can read and write to the process's memory
        /// by using the <see cref="ReadProcessMemory"/> and <see cref="WriteProcessMemory"/> functions.
        /// If the system previously reported an <see cref="EXIT_PROCESS_DEBUG_EVENT"/> event,
        /// the system closes this handle when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// The handle to the process's image file has <see cref="GENERIC_READ"/> access and is opened for read-sharing.
        /// The debugger should close this handle while processing <see cref="CREATE_PROCESS_DEBUG_EVENT"/>.
        /// The handle to the process's initial thread has <see cref="THREAD_GET_CONTEXT"/>, <see cref="THREAD_SET_CONTEXT"/>,
        /// and <see cref="THREAD_SUSPEND_RESUME"/> access to the thread.
        /// If a debugger has these types of access to a thread, it can read from and write to the thread's registers
        /// by using the <see cref="GetThreadContext"/> and <see cref="SetThreadContext"/> functions and can suspend
        /// and resume the thread by using the <see cref="SuspendThread"/> and <see cref="ResumeThread"/> functions.
        /// If the system previously reported an <see cref="EXIT_PROCESS_DEBUG_EVENT"/> event,
        /// the system closes this handle when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// </summary>
        CREATE_PROCESS_DEBUG_EVENT = 3,

        /// <summary>
        /// Generated whenever a thread that is part of a process being debugged exits.
        /// The system generates this debugging event immediately after it updates the thread's exit code.
        /// The <see cref="DEBUG_EVENT"/> structure contains an <see cref="EXIT_THREAD_DEBUG_INFO"/> structure that specifies the exit code.
        /// This debugging event does not occur if the exiting thread is the last thread of a process.
        /// In this case, the <see cref="EXIT_PROCESS_DEBUG_EVENT"/> debugging event occurs instead.
        /// The debugger deallocates any internal structures associated with the thread on receipt of this debugging event.
        /// The system closes the debugger's handle to the exiting thread.
        /// The debugger should not close this handle.
        /// </summary>
        EXIT_THREAD_DEBUG_EVENT = 4,

        /// <summary>
        /// Generated whenever the last thread in a process being debugged exits.
        /// This debugging event occurs immediately after the system unloads the process's DLLs and updates the process's exit code.
        /// The <see cref="DEBUG_EVENT"/> structure contains an <see cref="EXIT_PROCESS_DEBUG_INFO"/> structure that specifies the exit code.
        /// The debugger deallocates any internal structures associated with the process on receipt of this debugging event.
        /// The system closes the debugger's handle to the exiting process and all of the process's threads.
        /// The debugger should not close these handles.
        /// The kernel-mode portion of process shutdown cannot be completed until the debugger
        /// that receives this event calls <see cref="ContinueDebugEvent"/>.
        /// Until then, the process handles are open and the virtual address space is not released, so the debugger can examine the child process.
        /// To receive notification when the kernel-mode portion of process shutdown is complete,
        /// duplicate the handle returned with <see cref="CREATE_PROCESS_DEBUG_EVENT"/>, call <see cref="ContinueDebugEvent"/>,
        /// and then wait for the duplicated process handle to be signaled.
        /// </summary>
        EXIT_PROCESS_DEBUG_EVENT = 5,

        /// <summary>
        /// Generated whenever a process being debugged loads a DLL.
        /// This debugging event occurs when the system loader resolves links to a DLL
        /// or when the debugged process uses the <see cref="LoadLibrary"/> function.
        /// This debugging event only occurs the first time the system attaches a DLL to the virtual address space of a process.
        /// The <see cref="DEBUG_EVENT"/> structure contains a <see cref="LOAD_DLL_DEBUG_INFO"/> structure.
        /// This structure includes a handle to the newly loaded DLL, the base address of the DLL, and other information that describes the DLL.
        /// The debugger should close the handle to the DLL handle while processing <see cref="LOAD_DLL_DEBUG_EVENT"/>.
        /// Typically, a debugger loads a symbol table associated with the DLL on receipt of this debugging event.
        /// </summary>
        LOAD_DLL_DEBUG_EVENT = 6,

        /// <summary>
        /// Generated whenever a process being debugged unloads a DLL by using the <see cref="FreeLibrary"/> function.
        /// This debugging event only occurs the last time a DLL is unloaded from a process's address space (that is, when the DLL's usage count is zero).
        /// The <see cref="DEBUG_EVENT"/> structure contains an <see cref="UNLOAD_DLL_DEBUG_INFO"/> structure.
        /// This structure specifies the base address of the DLL in the address space of the process that unloads the DLL.
        /// Typically, a debugger unloads a symbol table associated with the DLL upon receiving this debugging event.
        /// When a process exits, the system automatically unloads the process's DLLs,
        /// but does not generate an <see cref="UNLOAD_DLL_DEBUG_EVENT"/> debugging event.
        /// </summary>
        UNLOAD_DLL_DEBUG_EVENT = 7,

        /// <summary>
        /// Generated when a process being debugged uses the <see cref="OutputDebugString"/> function.
        /// The <see cref="DEBUG_EVENT"/> structure contains an <see cref="OUTPUT_DEBUG_STRING_INFO"/> structure.
        /// This structure specifies the address, length, and format of the debugging string.
        /// </summary>
        OUTPUT_DEBUG_STRING_EVENT = 8,

        /// <summary>
        /// Generated whenever a process being debugged dies outside of the control of the system debugger.
        /// The <see cref="DEBUG_EVENT"/> structure contains a <see cref="RIP_INFO"/> structure.
        /// This structure specifies the error and type of error.
        /// </summary>
        RIP_EVENT = 9,
    }
}
