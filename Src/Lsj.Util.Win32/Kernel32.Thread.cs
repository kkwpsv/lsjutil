﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DllMainReasons;
using static Lsj.Util.Win32.Enums.ExceptionCodes;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.ProcessPriorityClasses;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Enums.ThreadCreationFlags;
using static Lsj.Util.Win32.Enums.ThreadPriorityFlags;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Winmm;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// FLS_OUT_OF_INDEXES
        /// </summary>
        public static readonly DWORD FLS_OUT_OF_INDEXES = 0xFFFFFFFF;

        /// <summary>
        /// TLS_MINIMUM_AVAILABLE
        /// </summary>
        public static readonly DWORD TLS_MINIMUM_AVAILABLE = 64;

        /// <summary>
        /// TLS_OUT_OF_INDEXES
        /// </summary>
        public static readonly DWORD TLS_OUT_OF_INDEXES = 0xFFFFFFFF;


        /// <summary>
        /// <para>
        /// An application-defined function that serves as the starting address for a thread.
        /// Specify this address when calling the <see cref="CreateThread"/>, <see cref="CreateRemoteThread"/>,
        /// or <see cref="CreateRemoteThreadEx"/> function.
        /// The <see cref="LPTHREAD_START_ROUTINE"/> type defines a pointer to this callback function.
        /// ThreadProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms686736(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lpParameter">
        /// The thread data passed to the function using the lpParameter parameter of the <see cref="CreateThread"/>,
        /// <see cref="CreateRemoteThread"/>, or <see cref="CreateRemoteThreadEx"/> function.
        /// </param>
        /// <returns>
        /// The return value indicates the success or failure of this function.
        /// The return value should never be set to <see cref="STILL_ACTIVE"/>, as noted in <see cref="GetExitCodeThread"/>.
        /// Do not declare this callback function with a void return type and cast the function pointer to ThreadProc when creating the thread.
        /// Code that does this is common, but it can crash on 64-bit Windows.
        /// </returns>
        /// <remarks>
        /// A process can determine when a thread it created has completed by using one of the wait functions.
        /// It can also obtain the return value of its ThreadProc by calling the <see cref="GetExitCodeThread"/> function.
        /// Each thread receives a unique copy of the local variables of this function.
        /// Any static or global variables are shared by all threads in the process.
        /// To provide unique data to each thread using a global index, use thread local storage.
        /// </remarks>
        public delegate uint Lpthreadstartroutine([In] LPVOID lpParameter);


        /// <summary>
        /// <para>
        /// Creates a thread that runs in the virtual address space of another process.
        /// Use the <see cref="CreateRemoteThreadEx"/> function to create a thread that runs in the virtual address space of another process
        /// and optionally specify extended attributes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-createremotethread"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process in which the thread is to be created.
        /// The handle must have the <see cref="PROCESS_CREATE_THREAD"/>, <see cref="PROCESS_QUERY_INFORMATION"/>, <see cref="PROCESS_VM_OPERATION"/>,
        /// <see cref="PROCESS_VM_WRITE"/>, and <see cref="PROCESS_VM_READ"/> access rights, and may fail without these rights on certain platforms.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new thread and determines
        /// whether child processes can inherit the returned handle.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/>, the thread gets a default security descriptor
        /// and the handle cannot be inherited.
        /// The access control lists (ACL) in the default security descriptor for a thread come from the primary token of the creator.
        /// Windows XP:  The ACLs in the default security descriptor for a thread come from the primary or impersonation token of the creator.
        /// This behavior changed with Windows XP with SP2 and Windows Server 2003.
        /// </param>
        /// <param name="dwStackSize">
        /// The initial size of the stack, in bytes. The system rounds this value to the nearest page.
        /// If this parameter is 0 (zero), the new thread uses the default size for the executable.
        /// For more information, see Thread Stack Size.
        /// </param>
        /// <param name="lpStartAddress">
        /// A pointer to the application-defined function of type LPTHREAD_START_ROUTINE to be executed by the thread
        /// and represents the starting address of the thread in the remote process.
        /// The function must exist in the remote process.
        /// For more information, see <see cref="LPTHREAD_START_ROUTINE"/>.
        /// </param>
        /// <param name="lpParameter">
        /// A pointer to a variable to be passed to the thread function.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control the creation of the thread.
        /// 0: The thread runs immediately after creation.
        /// <see cref="CREATE_SUSPENDED"/>, <see cref="STACK_SIZE_PARAM_IS_A_RESERVATION"/>
        /// </param>
        /// <param name="lpThreadId">
        /// A pointer to a variable that receives the thread identifier.
        /// If this parameter is <see langword="null"/>, the thread identifier is not returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new thread.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Note that <see cref="CreateRemoteThread"/> may succeed even if <paramref name="lpStartAddress"/> points to data, code, or is not accessible.
        /// If the start address is invalid when the thread runs, an exception occurs, and the thread terminates.
        /// Thread termination due to a invalid start address is handled as an error exit for the thread's process.
        /// This behavior is similar to the asynchronous nature of <see cref="CreateProcess"/>, where the process is created
        /// even if it refers to invalid or missing dynamic-link libraries (DLL).
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateRemoteThread"/> function causes a new thread of execution to begin in the address space of the specified process.
        /// The thread has access to all objects that the process opens.
        /// Terminal Services isolates each terminal session by design.
        /// Therefore, <see cref="CreateRemoteThread"/> fails if the target process is in a different session than the calling process.
        /// The new thread handle is created with full access to the new thread.
        /// If a security descriptor is not provided, the handle may be used in any function that requires a thread object handle.
        /// When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before access is granted.
        /// If the access check denies access, the requesting process cannot use the handle to gain access to the thread.
        /// If the thread is created in a runnable state (that is, if the <see cref="CREATE_SUSPENDED"/> flag is not used),
        /// the thread can start running before <see cref="CreateThread"/> returns and, in particular, before the caller receives the handle
        /// and identifier of the created thread.
        /// The thread is created with a thread priority of <see cref="THREAD_PRIORITY_NORMAL"/>.
        /// Use the <see cref="GetThreadPriority"/> and <see cref="SetThreadPriority"/> functions to get and set the priority value of a thread.
        /// When a thread terminates, the thread object attains a signaled state, which satisfies the threads that are waiting for the object.
        /// The thread object remains in the system until the thread has terminated
        /// and all handles to it are closed through a call to <see cref="CloseHandle"/>.
        /// The <see cref="ExitProcess"/>, <see cref="ExitThread"/>, <see cref="CreateThread"/>, <see cref="CreateRemoteThread"/> functions,
        /// and a process that is starting (as the result of a CreateProcess call) are serialized between each other within a process.
        /// Only one of these events occurs in an address space at a time.
        /// This means the following restrictions hold:
        /// During process startup and DLL initialization routines, new threads can be created,
        /// but they do not begin execution until DLL initialization is done for the process.
        /// Only one thread in a process can be in a DLL initialization or detach routine at a time.
        /// <see cref="ExitProcess"/> returns after all threads have completed their DLL initialization or detach routines.
        /// A common use of this function is to inject a thread into a process that is being debugged to issue a break.
        /// However, this use is not recommended, because the extra thread is confusing to the person debugging the application and
        /// there are several side effects to using this technique:
        /// It converts single-threaded applications into multithreaded applications.
        /// It changes the timing and memory layout of the process.
        /// It results in a call to the entry point of each DLL in the process.
        /// Another common use of this function is to inject a thread into a process to query heap or other process information.
        /// This can cause the same side effects mentioned in the previous paragraph.
        /// Also, the application can deadlock if the thread attempts to obtain ownership of locks that another thread is using.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRemoteThread", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateRemoteThread([In] HANDLE hProcess, [In] in SECURITY_ATTRIBUTES lpThreadAttributes, [In] SIZE_T dwStackSize,
            [In] LPTHREAD_START_ROUTINE lpStartAddress, [In] LPVOID lpParameter, [In] ThreadCreationFlags dwCreationFlags, [Out] out DWORD lpThreadId);

        /// <summary>
        /// <para>
        /// Creates a thread that runs in the virtual address space of another process
        /// and optionally specifies extended attributes such as processor group affinity.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-createremotethreadex"/>
        /// </para>
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process in which the thread is to be created.
        /// The handle must have the <see cref="PROCESS_CREATE_THREAD"/>, <see cref="PROCESS_QUERY_INFORMATION"/>, <see cref="PROCESS_VM_OPERATION"/>,
        /// <see cref="PROCESS_VM_WRITE"/>, and <see cref="PROCESS_VM_READ"/> access rights.
        /// In Windows 10, version 1607, your code must obtain these access rights for the new handle.
        /// However, starting in Windows 10, version 1703, if the new handle is entitled to these access rights, the system obtains them for you.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new thread and determines
        /// whether child processes can inherit the returned handle.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/>, the thread gets a default security descriptor
        /// and the handle cannot be inherited.
        /// The access control lists (ACL) in the default security descriptor for a thread come from the primary token of the creator.
        /// </param>
        /// <param name="dwStackSize">
        /// The initial size of the stack, in bytes. The system rounds this value to the nearest page.
        /// If this parameter is 0 (zero), the new thread uses the default size for the executable.
        /// For more information, see Thread Stack Size.
        /// </param>
        /// <param name="lpStartAddress">
        /// A pointer to the application-defined function of type LPTHREAD_START_ROUTINE to be executed by the thread
        /// and represents the starting address of the thread in the remote process.
        /// The function must exist in the remote process.
        /// For more information, see <see cref="LPTHREAD_START_ROUTINE"/>.
        /// </param>
        /// <param name="lpParameter">
        /// A pointer to a variable to be passed to the thread function.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control the creation of the thread.
        /// 0: The thread runs immediately after creation.
        /// <see cref="CREATE_SUSPENDED"/>, <see cref="STACK_SIZE_PARAM_IS_A_RESERVATION"/>
        /// </param>
        /// <param name="lpAttributeList">
        /// An attribute list that contains additional parameters for the new thread.
        /// This list is created by the <see cref="InitializeProcThreadAttributeList"/> function.
        /// </param>
        /// <param name="lpThreadId">
        /// A pointer to a variable that receives the thread identifier.
        /// If this parameter is <see langword="null"/>, the thread identifier is not returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new thread.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateRemoteThreadEx"/> function causes a new thread of execution to begin in the address space of the specified process.
        /// The thread has access to all objects that the process opens.
        /// The <paramref name="lpAttributeList"/> parameter can be used to specify extended attributes such as processor group affinity for the new thread.
        /// If <paramref name="lpAttributeList"/> is <see cref="IntPtr.Zero"/>, the function's behavior is the same as <see cref="CreateRemoteThread"/>.
        /// Prior to Windows 8, Terminal Services isolates each terminal session by design.
        /// Therefore, <see cref="CreateRemoteThread"/> fails if the target process is in a different session than the calling process.
        /// The new thread handle is created with full access to the new thread.
        /// If a security descriptor is not provided, the handle may be used in any function that requires a thread object handle.
        /// When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before access is granted.
        /// If the access check denies access, the requesting process cannot use the handle to gain access to the thread.
        /// If the thread is created in a runnable state (that is, if the <see cref="CREATE_SUSPENDED"/> flag is not used),
        /// the thread can start running before <see cref="CreateThread"/> returns and, in particular, before the caller receives the handle
        /// and identifier of the created thread.
        /// The thread is created with a thread priority of <see cref="THREAD_PRIORITY_NORMAL"/>.
        /// To get and set the priority value of a thread, use the <see cref="GetThreadPriority"/> and <see cref="SetThreadPriority"/> functions.
        /// When a thread terminates, the thread object attains a signaled state, which satisfies the threads that are waiting for the object.
        /// The thread object remains in the system until the thread has terminated
        /// and all handles to it are closed through a call to <see cref="CloseHandle"/>.
        /// The <see cref="ExitProcess"/>, <see cref="ExitThread"/>, <see cref="CreateThread"/>, <see cref="CreateRemoteThread"/> functions,
        /// and a process that is starting (as the result of a CreateProcess call) are serialized between each other within a process.
        /// Only one of these events occurs in an address space at a time.
        /// This means the following restrictions hold:
        /// During process startup and DLL initialization routines, new threads can be created,
        /// but they do not begin execution until DLL initialization is done for the process.
        /// Only one thread in a process can be in a DLL initialization or detach routine at a time.
        /// <see cref="ExitProcess"/> returns after all threads have completed their DLL initialization or detach routines.
        /// A common use of this function is to inject a thread into a process that is being debugged to issue a break.
        /// However, this use is not recommended, because the extra thread is confusing to the person debugging the application and
        /// there are several side effects to using this technique:
        /// It converts single-threaded applications into multithreaded applications.
        /// It changes the timing and memory layout of the process.
        /// It results in a call to the entry point of each DLL in the process.
        /// Another common use of this function is to inject a thread into a process to query heap or other process information.
        /// This can cause the same side effects mentioned in the previous paragraph.
        /// Also, the application can deadlock if the thread attempts to obtain ownership of locks that another thread is using.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRemoteThreadEx", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateRemoteThreadEx([In] HANDLE hProcess, [In] in SECURITY_ATTRIBUTES lpThreadAttributes, [In] SIZE_T dwStackSize,
            [In] LPTHREAD_START_ROUTINE lpStartAddress, [In] LPVOID lpParameter, [In] ThreadCreationFlags dwCreationFlags,
            [In] LPPROC_THREAD_ATTRIBUTE_LIST lpAttributeList, [Out] out DWORD lpThreadId);

        /// <summary>
        /// <para>
        /// Creates a thread to execute within the virtual address space of the calling process.
        /// To create a thread that runs in the virtual address space of another process, use the <see cref="CreateRemoteThread"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-createthread"/>
        /// </para>
        /// </summary>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new thread.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/>, the thread gets a default security descriptor.
        /// The ACLs in the default security descriptor for a thread come from the primary token of the creator.
        /// </param>
        /// <param name="dwStackSize">
        /// The initial size of the stack, in bytes.
        /// The system rounds this value to the nearest page.
        /// If this parameter is zero, the new thread uses the default size for the executable.
        /// For more information, see Thread Stack Size.
        /// </param>
        /// <param name="lpStartAddress">
        /// A pointer to the application-defined function to be executed by the thread.
        /// This pointer represents the starting address of the thread. For more information on the thread function, see <see cref="LPTHREAD_START_ROUTINE"/>.
        /// </param>
        /// <param name="lpParameter">
        /// A pointer to a variable to be passed to the thread.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control the creation of the thread.
        /// 0: The thread runs immediately after creation.
        /// <see cref="CREATE_SUSPENDED"/>, <see cref="STACK_SIZE_PARAM_IS_A_RESERVATION"/>
        /// </param>
        /// <param name="lpThreadId">
        /// A pointer to a variable that receives the thread identifier.
        /// If this parameter is <see langword="null"/>, the thread identifier is not returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new thread.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Note that <see cref="CreateThread"/> may succeed even if <paramref name="lpStartAddress"/> points to data, code, or is not accessible.
        /// If the start address is invalid when the thread runs, an exception occurs, and the thread terminates.
        /// Thread termination due to a invalid start address is handled as an error exit for the thread's process.
        /// This behavior is similar to the asynchronous nature of <see cref="CreateProcess"/>, where the process is created
        /// even if it refers to invalid or missing dynamic-link libraries (DLLs).
        /// </returns>
        /// <remarks>
        /// The number of threads a process can create is limited by the available virtual memory.
        /// By default, every thread has one megabyte of stack space.
        /// Therefore, you can create at most 2,048 threads.
        /// If you reduce the default stack size, you can create more threads.
        /// However, your application will have better performance if you create one thread per processor
        /// and build queues of requests for which the application maintains the context information.
        /// A thread would process all requests in a queue before processing requests in the next queue.
        /// The new thread handle is created with the <see cref="THREAD_ALL_ACCESS"/> access right.
        /// If a security descriptor is not provided when the thread is created, a default security descriptor is constructed for the new thread
        /// using the primary token of the process that is creating the thread.
        /// When a caller attempts to access the thread with the <see cref="OpenThread"/> function,
        /// the effective token of the caller is evaluated against this security descriptor to grant or deny access.
        /// The newly created thread has full access rights to itself when calling the <see cref="GetCurrentThread"/> function.
        /// Windows Server 2003:  The thread's access rights to itself are computed by evaluating the primary token of the process
        /// in which the thread was created against the default security descriptor constructed for the thread.
        /// If the thread is created in a remote process, the primary token of the remote process is used.
        /// As a result, the newly created thread may have reduced access rights to itself when calling <see cref="GetCurrentThread"/>.
        /// Some access rights including <see cref="THREAD_SET_THREAD_TOKEN"/> and <see cref="THREAD_GET_CONTEXT"/> may not be present,
        /// leading to unexpected failures.
        /// For this reason, creating a thread while impersonating another user is not recommended.
        /// If the thread is created in a runnable state (that is, if the <see cref="CREATE_SUSPENDED"/> flag is not used),
        /// the thread can start running before CreateThread returns and, in particular,
        /// before the caller receives the handle and identifier of the created thread.
        /// The thread execution begins at the function specified by the <paramref name="lpStartAddress"/> parameter.
        /// If this function returns, the DWORD return value is used to terminate the thread in an implicit call to the <see cref="ExitThread"/> function.
        /// Use the <see cref="GetExitCodeThread"/> function to get the thread's return value.
        /// The thread is created with a thread priority of <see cref="THREAD_PRIORITY_NORMAL"/>.
        /// Use the <see cref="GetThreadPriority"/> and <see cref="SetThreadPriority"/> functions to get and set the priority value of a thread.
        /// When a thread terminates, the thread object attains a signaled state, satisfying any threads that were waiting on the object.
        /// The thread object remains in the system until the thread has terminated and all handles
        /// to it have been closed through a call to <see cref="CloseHandle"/>.
        /// The <see cref="ExitProcess"/>, <see cref="ExitThread"/>, <see cref="CreateThread"/>, <see cref="CreateRemoteThread"/> functions,
        /// and a process that is starting(as the result of a call by <see cref="CreateProcess"/>) are serialized between each other within a process.
        /// Only one of these events can happen in an address space at a time.
        /// This means that the following restrictions hold:
        /// During process startup and DLL initialization routines, new threads can be created,
        /// but they do not begin execution until DLL initialization is done for the process.
        /// Only one thread in a process can be in a DLL initialization or detach routine at a time.
        /// <see cref="ExitProcess"/> does not complete until there are no threads in their DLL initialization or detach routines.
        /// A thread in an executable that calls the C run - time library(CRT) should use the _beginthreadex and _endthreadex functions
        /// for thread management rather than <see cref="CreateThread"/> and <see cref="ExitThread"/>;
        /// this requires the use of the multithreaded version of the CRT.
        /// If a thread created using <see cref="CreateThread"/> calls the CRT, the CRT may terminate the process in low - memory conditions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThread", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateThread([In] in SECURITY_ATTRIBUTES lpThreadAttributes, [In] SIZE_T dwStackSize,
            [In] LPTHREAD_START_ROUTINE lpStartAddress, [In] LPVOID lpParameter, [In] ThreadCreationFlags dwCreationFlags, [Out] out DWORD lpThreadId);

        /// <summary>
        /// <para>
        /// Ends the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-exitthread"/>
        /// </para>
        /// </summary>
        /// <param name="dwExitCode">
        /// The exit code for the thread.
        /// </param>
        /// <remarks>
        /// <see cref="ExitThread"/> is the preferred method of exiting a thread in C code.
        /// However, in C++ code, the thread is exited before any destructors can be called or any other automatic cleanup can be performed.
        /// Therefore, in C++ code, you should return from your thread function.
        /// When this function is called (either explicitly or by returning from a thread procedure), the current thread's stack is deallocated,
        /// all pending I/O initiated by the thread is canceled, and the thread terminates.
        /// The entry-point function of all attached dynamic-link libraries (DLLs) is invoked with a value indicating
        /// that the thread is detaching from the DLL.
        /// If the thread is the last thread in the process when this function is called, the thread's process is also terminated.
        /// The state of the thread object becomes signaled, releasing any other threads that had been waiting for the thread to terminate.
        /// The thread's termination status changes from <see cref="STILL_ACTIVE"/> to the value of the <paramref name="dwExitCode"/> parameter.
        /// Terminating a thread does not necessarily remove the thread object from the operating system.
        /// A thread object is deleted when the last handle to the thread is closed.
        /// The <see cref="ExitProcess"/>, <see cref="ExitThread"/>, <see cref="CreateThread"/>, <see cref="CreateRemoteThread"/> functions,
        /// and a process that is starting (as the result of a <see cref="CreateProcess"/> call) are serialized between each other within a process.
        /// Only one of these events can happen in an address space at a time. This means the following restrictions hold:
        /// During process startup and DLL initialization routines, new threads can be created,
        /// but they do not begin execution until DLL initialization is done for the process.
        /// Only one thread in a process can be in a DLL initialization or detach routine at a time.
        /// <see cref="ExitProcess"/> does not return until no threads are in their DLL initialization or detach routines.
        /// A thread in an executable that is linked to the static C run-time library (CRT) should use _beginthread and _endthread
        /// for thread management rather than <see cref="CreateThread"/> and <see cref="ExitThread"/>.
        /// Failure to do so results in small memory leaks when the thread calls <see cref="ExitThread"/>.
        /// Another work around is to link the executable to the CRT in a DLL instead of the static CRT.
        /// Note that this memory leak only occurs from a DLL if the DLL is linked to the static CRT and
        /// a thread calls the <see cref="DisableThreadLibraryCalls"/> function.
        /// Otherwise, it is safe to call <see cref="CreateThread"/> and <see cref="ExitThread"/> from a thread in a DLL that links to the static CRT.
        /// Use the <see cref="GetExitCodeThread"/> function to retrieve a thread's exit code.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExitThread", ExactSpelling = true, SetLastError = true)]
        public static extern void ExitThread([In] DWORD dwExitCode);

        /// <summary>
        /// <para>
        /// Retrieves the number of the processor the current thread was running on during the call to this function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentprocessornumber"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The function returns the current processor number.
        /// </returns>
        /// <remarks>
        /// This function is used to provide information for estimating process performance.
        /// On systems with more than 64 logical processors, the <see cref="GetCurrentProcessorNumber"/> function returns the processor number
        /// within the processor group to which the logical processor is assigned.
        /// Use the <see cref="GetCurrentProcessorNumberEx"/> function to retrieve the processor group and number of the current processor.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcessorNumber", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetCurrentProcessorNumber();

        /// <summary>
        /// <para>
        /// Retrieves the processor group and number of the logical processor in which the calling thread is running.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentprocessornumberex"/>
        /// </para>
        /// </summary>
        /// <param name="ProcNumber">
        /// A pointer to a <see cref="PROCESSOR_NUMBER"/> structure that receives the processor group to
        /// which the logical processor is assigned and the number of the logical processor within its group.
        /// </param>
        /// <returns>
        /// If the function succeeds, the <paramref name="ProcNumber"/> parameter contains the group and processor number
        /// of the processor on which the calling thread is running.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcessorNumberEx", ExactSpelling = true, SetLastError = true)]
        public static extern void GetCurrentProcessorNumberEx([Out] out PROCESSOR_NUMBER ProcNumber);

        /// <summary>
        /// <para>
        /// Retrieves a pseudo handle for the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentthread"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a pseudo handle for the current thread.
        /// </returns>
        /// <remarks>
        /// A pseudo handle is a special constant that is interpreted as the current thread handle.
        /// The calling thread can use this handle to specify itself whenever a thread handle is required.
        /// Pseudo handles are not inherited by child processes.
        /// This handle has the <see cref="THREAD_ALL_ACCESS"/> access right to the thread object.
        /// For more information, see Thread Security and Access Rights.
        /// Windows Server 2003 and Windows XP:
        /// This handle has the maximum access allowed by the security descriptor of the thread to the primary token of the process.
        /// The function cannot be used by one thread to create a handle that can be used by other threads to refer to the first thread.
        /// The handle is always interpreted as referring to the thread that is using it.
        /// A thread can create a "real" handle to itself that can be used by other threads, or inherited by other processes,
        /// by specifying the pseudo handle as the source handle in a call to the <see cref="DuplicateHandle"/> function.
        /// The pseudo handle need not be closed when it is no longer needed.
        /// Calling the <see cref="CloseHandle"/> function with this handle has no effect.
        /// If the pseudo handle is duplicated by <see cref="DuplicateHandle"/>, the duplicate handle must be closed.
        /// Do not create a thread while impersonating a security context.
        /// The call will succeed, however the newly created thread will have reduced access rights to itself when calling <see cref="GetCurrentThread"/>.
        /// The access rights granted this thread will be derived from the access rights the impersonated user has to the process.
        /// Some access rights including <see cref="THREAD_SET_THREAD_TOKEN"/> and <see cref="THREAD_GET_CONTEXT"/> may not be present,
        /// leading to unexpected failures.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentThread", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE GetCurrentThread();

        /// <summary>
        /// <para>
        /// Retrieves the thread identifier of the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentthreadid"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is the thread identifier of the calling thread.
        /// </returns>
        /// <remarks>
        /// Until the thread terminates, the thread identifier uniquely identifies the thread throughout the system.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentThreadId", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetCurrentThreadId();

        /// <summary>
        /// <para>
        /// Retrieves the boundaries of the stack that was allocated by the system for the current thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentthreadstacklimits"/>
        /// </para>
        /// </summary>
        /// <param name="LowLimit">
        /// A pointer variable that receives the lower boundary of the current thread stack.
        /// </param>
        /// <param name="HighLimit">
        /// A pointer variable that receives the upper boundary of the current thread stack.
        /// </param>
        /// <remarks>
        /// It is possible for user-mode code to execute in stack memory that is outside the region allocated by the system when the thread was created.
        /// Callers can use the <see cref="GetCurrentThreadStackLimits"/> function to verify that the current stack pointer is within the returned limits.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentThreadStackLimits", ExactSpelling = true, SetLastError = true)]
        public static extern void GetCurrentThreadStackLimits([Out] out ULONG_PTR LowLimit, [Out] out ULONG_PTR HighLimit);

        /// <summary>
        /// <para>
        /// Retrieves the termination status of the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getexitcodethread"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread.
        /// The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> or <see cref="THREAD_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <param name="lpExitCode">
        /// A pointer to a variable to receive the thread termination status.
        /// For more information, see Remarks.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function returns immediately.
        /// If the specified thread has not terminated and the function succeeds, the status returned is <see cref="STILL_ACTIVE"/>.
        /// If the thread has terminated and the function succeeds, the status returned is one of the following values:
        /// The exit value specified in the <see cref="ExitThread"/> or <see cref="TerminateThread"/> function.
        /// The return value from the thread function.
        /// The exit value of the thread's process.
        /// The <see cref="GetExitCodeThread"/> function returns a valid error code defined by the application only after the thread terminates.
        /// Therefore, an application should not use <see cref="STILL_ACTIVE"/> as an error code.
        /// If a thread returns <see cref="STILL_ACTIVE"/> as an error code, applications that test for this value could interpret it to mean
        /// that the thread is still running and continue to test for the completion of the thread after the thread has terminated,
        /// which could put the application into an infinite loop.
        /// To avoid this problem, callers should call the <see cref="GetExitCodeThread"/> function only after the thread has been confirmed to have exited.
        /// Use the <see cref="WaitForSingleObject"/> function with a wait duration of zero to determine whether a thread has exited.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetExitCodeThread", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetExitCodeThread([In] HANDLE hThread, [Out] out DWORD lpExitCode);

        /// <summary>
        /// <para>
        /// Retrieves the process identifier of the process associated with the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocessidofthread"/>
        /// </para>
        /// </summary>
        /// <param name="Thread">
        /// A handle to the thread.
        /// The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> or <see cref="THREAD_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// Windows Server 2003:  The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the process identifier of the process associated with the specified thread.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Until a process terminates, its process identifier uniquely identifies it on the system.
        /// For more information about access rights, see Thread Security and Access Rights.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessIdOfThread", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetProcessIdOfThread([In] HANDLE Thread);

        /// <summary>
        /// <para>
        /// Retrieves the context of the specified thread.
        /// A 64-bit application can retrieve the context of a WOW64 thread using the <see cref="Wow64GetThreadContext"/> function.
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread whose context is to be retrieved. The handle must have <see cref="THREAD_GET_CONTEXT"/> access to the thread.
        /// For more information, see Thread Security and Access Rights.
        /// WOW64: The handle must also have <see cref="THREAD_QUERY_INFORMATION"/> access.
        /// </param>
        /// <param name="lpContext">
        /// A pointer to a <see cref="CONTEXT"/> structure that receives the appropriate context of the specified thread.
        /// The value of the <see cref="CONTEXT.ContextFlags"/> member of this structure specifies which portions of a thread's context are retrieved.
        /// The <see cref="CONTEXT"/> structure is highly processor specific.
        /// Refer to the WinNT.h header file for processor-specific definitions of this structures and any alignment requirements.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function is used to retrieve the thread context of the specified thread.
        /// The function retrieves a selective context based on the value
        /// of the <see cref="CONTEXT.ContextFlags"/> member of the <see cref="CONTEXT"/> structure. 
        /// The thread identified by the <paramref name="hThread"/> parameter is typically being debugged,
        /// but the function can also operate when the thread is not being debugged.
        /// You cannot get a valid context for a running thread.
        /// Use the <see cref="SuspendThread"/> function to suspend the thread before calling <see cref="GetThreadContext"/>.
        /// If you call <see cref="GetThreadContext"/> for the current thread, the function returns successfully; however, the context returned is not valid.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetThreadContext([In] HANDLE hThread, [Out] out CONTEXT lpContext);

        /// <summary>
        /// <para>
        /// A handle to the thread.
        /// The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> or <see cref="THREAD_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information about access rights, see Thread Security and Access Rights.
        /// Windows Server 2003:  The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> access right.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getthreadid"/>
        /// </para>
        /// </summary>
        /// <param name="Thread">
        /// A handle to the thread.
        /// The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> or <see cref="THREAD_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information about access rights, see Thread Security and Access Rights.
        /// Windows Server 2003:  The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <returns>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Until a thread terminates, its thread identifier uniquely identifies it on the system.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0502 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadId", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetThreadId([In] HANDLE Thread);

        /// <summary>
        /// <para>
        /// Retrieves the processor number of the ideal processor for the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getthreadidealprocessorex"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread for which to retrieve the ideal processor.
        /// This handle must have been created with the <see cref="THREAD_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// </param>
        /// <param name="lpIdealProcessor">
        /// Points to <see cref="PROCESSOR_NUMBER"/> structure to receive the number of the ideal processor.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, use <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadIdealProcessorEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetThreadIdealProcessorEx([In] HANDLE hThread, [Out] out PROCESSOR_NUMBER lpIdealProcessor);

        /// <summary>
        /// <para>
        /// Retrieves the priority value for the specified thread.
        /// This value, together with the priority class of the thread's process, determines the thread's base-priority level.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getthreadpriority"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread.
        /// The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> or <see cref="THREAD_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// Windows Server 2003:  The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the thread's priority level.
        /// If the function fails, the return value is <see cref="THREAD_PRIORITY_ERROR_RETURN"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the thread has the <see cref="REALTIME_PRIORITY_CLASS"/> base class,
        /// this function can also return one of the following values: -7, -6, -5, -4, -3, 3, 4, 5, or 6.
        /// For more information, see Scheduling Priorities.
        /// </returns>
        /// <remarks>
        /// Every thread has a base-priority level determined by the thread's priority value and the priority class of its process.
        /// The operating system uses the base-priority level of all executable threads to determine which thread gets the next slice of CPU time.
        /// Threads are scheduled in a round-robin fashion at each priority level,
        /// and only when there are no executable threads at a higher level will scheduling of threads at a lower level take place.
        /// For a table that shows the base-priority levels for each combination of priority class and thread priority value,
        /// refer to the <see cref="SetPriorityClass"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadPriority", ExactSpelling = true, SetLastError = true)]
        public static extern int GetThreadPriority([In] HANDLE hThread);

        /// <summary>
        /// <para>
        /// Retrieves the priority boost control state of the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getthreadpriorityboost"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread.
        /// The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> or <see cref="THREAD_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// Windows Server 2003 and Windows XP: The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <param name="pDisablePriorityBoost">
        /// A pointer to a variable that receives the priority boost control state.
        /// A value of <see langword="true"/> indicates that dynamic boosting is disabled.
        /// A value of <see langword="false"/> indicates normal behavior.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// In that case, the variable pointed to by the <paramref name="pDisablePriorityBoost"/> parameter receives the priority boost control state.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadPriorityBoost", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetThreadPriorityBoost([In] HANDLE hThread, [Out] out BOOL pDisablePriorityBoost);

        /// <summary>
        /// <para>
        /// Retrieves timing information for the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getthreadtimes"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread whose timing information is sought.
        /// The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> or <see cref="THREAD_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// Windows Server 2003 and Windows XP: The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> access right.
        /// </param>
        /// <param name="lpCreationTime">
        /// A pointer to a <see cref="FILETIME"/> structure that receives the creation time of the thread.
        /// </param>
        /// <param name="lpExitTime">
        /// A pointer to a <see cref="FILETIME"/> structure that receives the exit time of the thread.
        /// If the thread has not exited, the content of this structure is undefined.
        /// </param>
        /// <param name="lpKernelTime">
        /// A pointer to a <see cref="FILETIME"/> structure that receives the amount of time that the thread has executed in kernel mode.
        /// </param>
        /// <param name="lpUserTime">
        /// A pointer to a <see cref="FILETIME"/> structure that receives the amount of time that the thread has executed in user mode.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// All times are expressed using <see cref="FILETIME"/> data structures.
        /// Such a structure contains two 32-bit values that combine to form a 64-bit count of 100-nanosecond time units.
        /// Thread creation and exit times are points in time expressed as the amount of time that has elapsed
        /// since midnight on January 1, 1601 at Greenwich, England.
        /// There are several functions that an application can use to convert such values to more generally useful forms; see Time Functions.
        /// Thread kernel mode and user mode times are amounts of time.
        /// For example, if a thread has spent one second in kernel mode, this function will fill the <see cref="FILETIME"/> structure
        /// specified by <paramref name="lpKernelTime"/> with a 64-bit value of ten million.
        /// That is the number of 100-nanosecond units in one second.
        /// To retrieve the number of CPU clock cycles used by the threads, use the <see cref="QueryThreadCycleTime"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadTimes", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetThreadTimes([In] HANDLE hThread, [Out] out FILETIME lpCreationTime, [Out] out FILETIME lpExitTime,
            [Out] out FILETIME lpKernelTime, [Out] out FILETIME lpUserTime);

        /// <summary>
        /// <para>
        /// Opens an existing thread object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-openthread"/>
        /// </para>
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// The access to the thread object.
        /// This access right is checked against the security descriptor for the thread.
        /// This parameter can be one or more of the thread access rights.
        /// If the caller has enabled the SeDebugPrivilege privilege,
        /// the requested access is granted regardless of the contents of the security descriptor.
        /// </param>
        /// <param name="bInheritHandle">
        /// If this value is <see langword="true"/>, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwThreadId">
        /// The identifier of the thread to be opened.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified thread.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned by <see cref="OpenThread"/> can be used in any function that requires a handle to a thread,
        /// such as the wait functions, provided you requested the appropriate access rights.
        /// The handle is granted access to the thread object only to the extent it was specified in the <paramref name="dwDesiredAccess"/> parameter.
        /// When you are finished with the handle, be sure to close it by using the <see cref="CloseHandle"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenThread", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE OpenThread([In] ACCESS_MASK dwDesiredAccess, [In] BOOL bInheritHandle, [In] DWORD dwThreadId);

        /// <summary>
        /// <para>
        /// Retrieves the cycle time for the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-querythreadcycletime"/>
        /// </para>
        /// </summary>
        /// <param name="ThreadHandle">
        /// A handle to the thread.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="CycleTime">
        /// The number of CPU clock cycles used by the thread. This value includes cycles spent in both user mode and kernel mode.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To enumerate the threads of the process, use the <see cref="Thread32First"/> and <see cref="Thread32Next"/> functions.
        /// To get the thread handle for a thread identifier, use the <see cref="OpenThread"/> function.
        /// Do not attempt to convert the CPU clock cycles returned by <see cref="QueryThreadCycleTime"/> to elapsed time.
        /// This function uses timer services provided by the CPU, which can vary in implementation.
        /// For example, some CPUs will vary the frequency of the timer when changing the frequency at which the CPU runs
        /// and others will leave it at a fixed rate.
        /// The behavior of each CPU is described in the documentation provided by the CPU vendor.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryThreadCycleTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryThreadCycleTime([In] HANDLE ThreadHandle, [Out] out ULONG64 CycleTime);

        /// <summary>
        /// <para>
        /// Decrements a thread's suspend count.
        /// When the suspend count is decremented to zero, the execution of the thread is resumed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-resumethread"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread to be restarted.
        /// This handle must have the <see cref="THREAD_SUSPEND_RESUME"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the thread's previous suspend count.
        /// If the function fails, the return value is (DWORD) -1.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="ResumeThread"/> function checks the suspend count of the subject thread.
        /// If the suspend count is zero, the thread is not currently suspended. Otherwise, the subject thread's suspend count is decremented.
        /// If the resulting value is zero, then the execution of the subject thread is resumed.
        /// If the return value is zero, the specified thread was not suspended.
        /// If the return value is 1, the specified thread was suspended but was restarted.
        /// If the return value is greater than 1, the specified thread is still suspended.
        /// Note that while reporting debug events, all threads within the reporting process are frozen.
        /// Debuggers are expected to use the <see cref="SuspendThread"/> and <see cref="ResumeThread"/> functions
        /// to limit the set of threads that can execute within a process.
        /// By suspending all threads in a process except for the one reporting a debug event, it is possible to "single step" a single thread.
        /// The other threads are not released by a continue operation if they are suspended.
        /// Windows Phone 8.1: This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later.
        /// Windows 8.1 and Windows Server 2012 R2: This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ResumeThread", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD ResumeThread([In] HANDLE hThread);

        /// <summary>
        /// <para>
        /// Sets a processor affinity mask for the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setthreadaffinitymask"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread whose affinity mask is to be set.
        /// This handle must have the <see cref="THREAD_SET_INFORMATION"/> or <see cref="THREAD_SET_LIMITED_INFORMATION"/> access right
        /// and the <see cref="THREAD_QUERY_INFORMATION"/> or <see cref="THREAD_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="THREAD_SET_INFORMATION"/> and <see cref="THREAD_QUERY_INFORMATION"/> access rights.
        /// </param>
        /// <param name="dwThreadAffinityMask">
        /// The affinity mask for the thread.
        /// On a system with more than 64 processors, the affinity mask must specify processors in the thread's current processor group.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the thread's previous affinity mask.
        /// If the function fails, the return value is <see cref="UIntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the thread affinity mask requests a processor that is not selected for the process affinity mask,
        /// the last error code is <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </returns>
        /// <remarks>
        /// A thread affinity mask is a bit vector in which each bit represents a logical processor that a thread is allowed to run on.
        /// A thread affinity mask must be a subset of the process affinity mask for the containing process of a thread.
        /// A thread can only run on the processors its process can run on.
        /// Therefore, the thread affinity mask cannot specify a 1 bit for a processor when the process affinity mask specifies a 0 bit for that processor.
        /// Setting an affinity mask for a process or thread can result in threads receiving less processor time,
        /// as the system is restricted from running the threads on certain processors.
        /// In most cases, it is better to let the system select an available processor.
        /// If the new thread affinity mask does not specify the processor that is currently running the thread,
        /// the thread is rescheduled on one of the allowable processors.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadAffinityMask", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD_PTR SetThreadAffinityMask([In] HANDLE hThread, [In] DWORD_PTR dwThreadAffinityMask);

        /// <summary>
        /// <para>
        /// Sets the context for the specified thread.
        /// A 64-bit application can set the context of a WOW64 thread using the <see cref="Wow64SetThreadContext"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setthreadcontext"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread whose context is to be set.
        /// The handle must have the <see cref="THREAD_SET_CONTEXT"/> access right to the thread.
        /// For more information, see Thread Security and Access Rights.
        /// </param>
        /// <param name="lpContext">
        /// A pointer to a <see cref="CONTEXT"/> structure that contains the context to be set in the specified thread.
        /// The value of the <see cref="CONTEXT.ContextFlags"/> member of this structure specifies which portions of a thread's context to set.
        /// Some values in the <see cref="CONTEXT"/> structure that cannot be specified are silently set to the correct value.
        /// This includes bits in the CPU status register that specify the privileged processor mode, global enabling bits in the debugging register,
        /// and other states that must be controlled by the operating system.
        /// </param>
        /// <returns>
        /// If the context was set, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The function sets the thread context based on the value of the <see cref="CONTEXT.ContextFlags"/> member of the <see cref="CONTEXT"/> structure.
        /// The thread identified by the <paramref name="hThread"/> parameter is typically being debugged,
        /// but the function can also operate even when the thread is not being debugged.
        /// Do not try to set the context for a running thread; the results are unpredictable.
        /// Use the <see cref="SuspendThread"/> function to suspend the thread before calling <see cref="SetThreadContext"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadContext([In] HANDLE hThread, [In] in CONTEXT lpContext);

        /// <summary>
        /// <para>
        /// Sets a preferred processor for a thread. The system schedules threads on their preferred processors whenever possible.
        /// On a system with more than 64 processors, this function sets the preferred processor to a logical processor in the processor group
        /// to which the calling thread is assigned.
        /// Use the <see cref="SetThreadIdealProcessorEx"/> function to specify a processor group and preferred processor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setthreadidealprocessor"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread whose preferred processor is to be set.
        /// The handle must have the <see cref="THREAD_SET_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// </param>
        /// <param name="dwIdealProcessor">
        /// The number of the preferred processor for the thread. This value is zero-based.
        /// If this parameter is <see cref="MAXIMUM_PROCESSORS"/>, the function returns the current ideal processor without changing it.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous preferred processor.
        /// If the function fails, the return value is (DWORD)-1.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// You can use the <see cref="GetSystemInfo"/> function to determine the number of processors on the computer.
        /// You can also use the <see cref="GetProcessAffinityMask"/> function to check the processors on which the thread is allowed to run.
        /// Note that <see cref="GetProcessAffinityMask"/> returns a bitmask
        /// whereas <see cref="SetThreadIdealProcessor"/> uses an integer value to represent the processor.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// Windows 8.1 and Windows Server 2012 R2: This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadIdealProcessor", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SetThreadIdealProcessor([In] HANDLE hThread, [In] DWORD dwIdealProcessor);

        /// <summary>
        /// <para>
        /// Sets the ideal processor for the specified thread and optionally retrieves the previous ideal processor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setthreadidealprocessorex"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread for which to set the ideal processor.
        /// This handle must have been created with the <see cref="THREAD_SET_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// </param>
        /// <param name="lpIdealProcessor">
        /// A pointer to a <see cref="PROCESSOR_NUMBER"/> structure that specifies the processor number of the desired ideal processor.
        /// </param>
        /// <param name="lpPreviousIdealProcessor">
        /// A pointer to a <see cref="PROCESSOR_NUMBER"/> structure to receive the previous ideal processor.
        /// This parameter can point to the same memory location as the <paramref name="lpIdealProcessor"/> parameter.
        /// This parameter can be <see cref="NullRef{PROCESSOR_NUMBER}"/> if the previous ideal processor is not required.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a <see cref="TRUE"/> value.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, use <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Specifying a thread ideal processor provides a hint to the scheduler about the preferred processor for a thread.
        /// The scheduler runs the thread on the thread's ideal processor when possible.
        /// To compile an application that uses this function, set _WIN32_WINNT >= 0x0601.
        /// For more information, see Using the Windows Headers.
        /// Windows Phone 8.1: This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later.
        /// Windows 8.1 and Windows Server 2012 R2: This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadIdealProcessorEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadIdealProcessorEx([In] HANDLE hThread, [In] in PROCESSOR_NUMBER lpIdealProcessor,
            [Out] out PROCESSOR_NUMBER lpPreviousIdealProcessor);

        /// <summary>
        /// <para>
        /// Sets the priority value for the specified thread.
        /// This value, together with the priority class of the thread's process, determines the thread's base priority level.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setthreadpriority"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread whose priority value is to be set.
        /// The handle must have the <see cref="THREAD_SET_INFORMATION"/> or <see cref="THREAD_SET_LIMITED_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// Windows Server 2003: The handle must have the <see cref="THREAD_SET_INFORMATION"/> access right.
        /// </param>
        /// <param name="nPriority">
        /// The priority value for the thread. This parameter can be one of the following values.
        /// <see cref="THREAD_MODE_BACKGROUND_BEGIN"/>, <see cref="THREAD_MODE_BACKGROUND_END"/>, <see cref="THREAD_PRIORITY_ABOVE_NORMAL"/>,
        /// <see cref="THREAD_PRIORITY_BELOW_NORMAL"/>, <see cref="THREAD_PRIORITY_HIGHEST"/>, <see cref="THREAD_PRIORITY_IDLE"/>,
        /// <see cref="THREAD_PRIORITY_LOWEST"/>, <see cref="THREAD_PRIORITY_NORMAL"/>, <see cref="THREAD_PRIORITY_TIME_CRITICAL"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Every thread has a base priority level determined by the thread's priority value and the priority class of its process.
        /// The system uses the base priority level of all executable threads to determine which thread gets the next slice of CPU time.
        /// Threads are scheduled in a round-robin fashion at each priority level,
        /// and only when there are no executable threads at a higher level does scheduling of threads at a lower level take place.
        /// The <see cref="SetThreadPriority"/> function enables setting the base priority level of a thread relative to the priority class of its process.
        /// For example, specifying <see cref="THREAD_PRIORITY_HIGHEST"/> in a call to <see cref="SetThreadPriority"/> for a thread
        /// of an <see cref="IDLE_PRIORITY_CLASS"/> process sets the thread's base priority level to 6.
        /// For a table that shows the base priority levels for each combination of priority class and thread priority value, see Scheduling Priorities.
        /// For <see cref="IDLE_PRIORITY_CLASS"/>, <see cref="BELOW_NORMAL_PRIORITY_CLASS"/>, <see cref="NORMAL_PRIORITY_CLASS"/>,
        /// <see cref="ABOVE_NORMAL_PRIORITY_CLASS"/>, and <see cref="HIGH_PRIORITY_CLASS"/> processes,
        /// the system dynamically boosts a thread's base priority level when events occur that are important to the thread.
        /// <see cref="REALTIME_PRIORITY_CLASS"/> processes do not receive dynamic boosts.
        /// All threads initially start at <see cref="THREAD_PRIORITY_NORMAL"/>.
        /// Use the <see cref="GetPriorityClass"/> and <see cref="SetPriorityClass"/> functions to get and set the priority class of a process.
        /// Use the <see cref="GetThreadPriority"/> function to get the priority value of a thread.
        /// Use the priority class of a process to differentiate between applications that are time critical and those
        /// that have normal or below normal scheduling requirements.
        /// Use thread priority values to differentiate the relative priorities of the tasks of a process.
        /// For example, a thread that handles input for a window could have a higher priority level than a thread
        /// that performs intensive calculations for the CPU.
        /// When manipulating priorities, be very careful to ensure that a high-priority thread does not consume all of the available CPU time.
        /// A thread with a base priority level above 11 interferes with the normal operation of the operating system.
        /// Using <see cref="REALTIME_PRIORITY_CLASS"/> may cause disk caches to not flush, cause the mouse to stop responding, and so on.
        /// The THREAD_PRIORITY_* values affect the CPU scheduling priority of the thread.
        /// For threads that perform background work such as file I/O, network I/O, or data processing,
        /// it is not sufficient to adjust the CPU scheduling priority;
        /// even an idle CPU priority thread can easily interfere with system responsiveness when it uses the disk and memory.
        /// Threads that perform background work should use the <see cref="THREAD_MODE_BACKGROUND_BEGIN"/> and <see cref="THREAD_MODE_BACKGROUND_END"/> values
        /// to adjust their resource scheduling priorities; threads that interact with the user should not use <see cref="THREAD_MODE_BACKGROUND_BEGIN"/>.
        /// When a thread is in background processing mode, it should minimize sharing resources such as critical sections, heaps,
        /// and handles with other threads in the process, otherwise priority inversions can occur.
        /// If there are threads executing at high priority, a thread in background processing mode may not be scheduled promptly, but it will never be starved.
        /// Windows Server 2008 and Windows Vista:
        /// While the system is starting, the <see cref="SetThreadPriority"/> function returns a success return value but does not change thread priority
        /// for applications that are started from the system Startup folder or listed in
        /// the HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run registry key.
        /// These applications run at reduced priority for a short time (approximately 60 seconds) to
        /// make the system more responsive to user actions during startup.
        /// Windows 8.1 and Windows Server 2012 R2: This function is supported for Windows Store apps.
        /// Windows Phone 8.1:Windows Phone Store apps may call this function but it has no effect.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadPriority", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadPriority([In] HANDLE hThread, ThreadPriorityFlags nPriority);

        /// <summary>
        /// <para>
        /// Disables or enables the ability of the system to temporarily boost the priority of a thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setthreadpriorityboost"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread whose priority is to be boosted.
        /// The handle must have the <see cref="THREAD_SET_INFORMATION"/> or <see cref="THREAD_SET_LIMITED_INFORMATION"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// Windows Server 2003 and Windows XP: The handle must have the <see cref="THREAD_SET_INFORMATION"/> access right.
        /// </param>
        /// <param name="bDisablePriorityBoost">
        /// If this parameter is <see langword="true"/>, dynamic boosting is disabled.
        /// If the parameter is <see langword="false"/>, dynamic boosting is enabled.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// When a thread is running in one of the dynamic priority classes,
        /// the system temporarily boosts the thread's priority when it is taken out of a wait state.
        /// If <see cref="SetThreadPriorityBoost"/> is called with the <paramref name="bDisablePriorityBoost"/> parameter set to <see langword="true"/>,
        /// the thread's priority is not boosted.
        /// To restore normal behavior, call <see cref="SetThreadPriorityBoost"/> with <paramref name="bDisablePriorityBoost"/> set to <see langword="false"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadPriorityBoost", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadPriorityBoost([In] HANDLE hThread, [In] BOOL bDisablePriorityBoost);

        /// <summary>
        /// <para>
        /// Sets the minimum size of the stack associated with the calling thread or fiber
        /// that will be available during any stack overflow exceptions.
        /// This is useful for handling stack overflow exceptions;
        /// the application can safely use the specified number of bytes during exception handling.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setthreadstackguarantee"/>
        /// </para>
        /// </summary>
        /// <param name="StackSizeInBytes">
        /// The size of the stack, in bytes.
        /// On return, this value is set to the size of the previous stack, in bytes.
        /// If this parameter is 0 (zero), the function succeeds and the parameter contains the size of the current stack.
        /// If the specified size is less than the current size, the function succeeds but ignores this request.
        /// Therefore, you cannot use this function to reduce the size of the stack.
        /// This value cannot be larger than the reserved stack size.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the function is successful, the application can handle possible <see cref="EXCEPTION_STACK_OVERFLOW"/> exceptions
        /// using structured exception handling.
        /// To resume execution after handling a stack overflow, you must perform certain recovery steps.
        /// If you are using the Microsoft C/C++ compiler, call the _resetstkoflw function.
        /// If you are using another compiler, see the documentation for the compiler for information on recovering from stack overflows.
        /// To set the stack guarantee for a fiber, you must first call the <see cref="SwitchToFiber"/> function to execute the fiber.
        /// After you set the guarantee for this fiber, it is used by the fiber no matter which thread executes the fiber.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadStackGuarantee", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadStackGuarantee([In][Out] ref ULONG StackSizeInBytes);

        /// <summary>
        /// <para>
        /// The <see cref="SetThreadToken"/> function assigns an impersonation token to a thread.
        /// The function can also cause a thread to stop using an impersonation token.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setthreadtoken"/>
        /// </para>
        /// </summary>
        /// <param name="Thread">
        /// A pointer to a handle to the thread to which the function assigns the impersonation token.
        /// If Thread is <see cref="NullRef{HANDLE}"/>, the function assigns the impersonation token to the calling thread.
        /// </param>
        /// <param name="Token">
        /// A handle to the impersonation token to assign to the thread
        /// . This handle must have been opened with <see cref="TOKEN_IMPERSONATE"/> access rights.
        /// For more information, see Access Rights for Access-Token Objects.
        /// If <paramref name="Token"/> is <see cref="NULL"/>, the function causes the thread to stop using an impersonation token.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// When using the <see cref="SetThreadToken"/> function to impersonate, you must have the impersonate privileges
        /// and make sure that the <see cref="SetThreadToken"/> function succeeds before calling the <see cref="RevertToSelf"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadToken([In] in HANDLE Thread, [In] HANDLE Token);

        /// <summary>
        /// <para>
        /// Suspends the execution of the current thread until the time-out interval elapses.
        /// To enter an alertable wait state, use the <see cref="SleepEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-sleep"/>
        /// </para>
        /// </summary>
        /// <param name="dwMilliseconds">
        /// The time interval for which execution is to be suspended, in milliseconds.
        /// A value of zero causes the thread to relinquish the remainder of its time slice to any other thread that is ready to run.
        /// If there are no other threads ready to run, the function returns immediately, and the thread continues execution.
        /// Windows XP: 
        /// A value of zero causes the thread to relinquish the remainder of its time slice to any other thread of equal priority that is ready to run. 
        /// If there are no other threads of equal priority ready to run, the function returns immediately, and the thread continues execution.
        /// This behavior changed starting with Windows Server 2003.
        /// A value of <see cref="INFINITE"/> indicates that the suspension should not time out.
        /// </param>
        /// <remarks>
        /// This function causes a thread to relinquish the remainder of its time slice and become unrunnable for an interval
        /// based on the value of <paramref name="dwMilliseconds"/>.
        /// The system clock "ticks" at a constant rate.
        /// If <paramref name="dwMilliseconds"/> is less than the resolution of the system clock,
        /// the thread may sleep for less than the specified length of time.
        /// If <paramref name="dwMilliseconds"/> is greater than one tick but less than two, the wait can be anywhere between one and two ticks, and so on.
        /// To increase the accuracy of the sleep interval, call the <see cref="timeGetDevCaps"/> function to determine the supported minimum timer resolution
        /// and the <see cref="timeBeginPeriod"/> function to set the timer resolution to its minimum.
        /// Use caution when calling <see cref="timeBeginPeriod"/>, as frequent calls can significantly affect the system clock,
        /// system power usage,and the scheduler.
        /// If you call <see cref="timeBeginPeriod"/>, call it one time early in the application and
        /// be sure to call the <see cref="timeEndPeriod"/> function at the very end of the application.
        /// After the sleep interval has passed, the thread is ready to run.
        /// If you specify 0 milliseconds, the thread will relinquish the remainder of its time slice but remain ready.
        /// Note that a ready thread is not guaranteed to run immediately.
        /// Consequently, the thread may not run until some time after the sleep interval elapses.
        /// For more information, see Scheduling Priorities.
        /// Be careful when using Sleep in the following scenarios:
        /// Code that directly or indirectly creates windows (for example, DDE and COM <see cref="CoInitialize"/>).
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// If you have a thread that uses <see cref="Sleep"/> with infinite delay, the system will deadlock.
        /// Threads that are under concurrency control.
        /// For example, an I/O completion port or thread pool limits the number of associated threads that can run.
        /// If the maximum number of threads is already running, no additional associated thread can run until a running thread finishes.
        /// If a thread uses <see cref="Sleep"/> with an interval of zero to wait for one of the additional associated threads
        /// to accomplish some work, the process might deadlock.
        /// For these scenarios, use <see cref="MsgWaitForMultipleObjects"/> or <see cref="MsgWaitForMultipleObjectsEx"/>, rather than <see cref="Sleep"/>.
        /// Windows Phone 8.1: This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later.
        /// Windows 8.1 and Windows Server 2012 R2: This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Sleep", ExactSpelling = true, SetLastError = true)]
        public static extern void Sleep([In] DWORD dwMilliseconds);

        /// <summary>
        /// <para>
        /// Suspends the current thread until the specified condition is met.
        /// Execution resumes when one of the following occurs:
        /// An I/O completion callback function is called.
        /// An asynchronous procedure call(APC) is queued to the thread.
        /// The time-out interval elapses.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-sleepex"/>
        /// </para>
        /// </summary>
        /// <param name="dwMilliseconds">
        /// The time interval for which execution is to be suspended, in milliseconds.
        /// A value of zero causes the thread to relinquish the remainder of its time slice to any other thread that is ready to run.
        /// If there are no other threads ready to run, the function returns immediately, and the thread continues execution.
        /// Windows XP:
        /// A value of zero causes the thread to relinquish the remainder of its time slice to any other thread of equal priority that is ready to run.
        /// If there are no other threads of equal priority ready to run, the function returns immediately, and the thread continues execution.
        /// This behavior changed starting with Windows Server 2003.
        /// A value of <see cref="INFINITE"/> indicates that the suspension should not time out.
        /// </param>
        /// <param name="bAlertable">
        /// If this parameter is <see langword="false"/>, the function does not return until the time-out period has elapsed.
        /// If an I/O completion callback occurs, the function does not return and the I/O completion function is not executed.
        /// If an APC is queued to the thread, the function does not return and the APC function is not executed.
        /// If the parameter is <see langword="true"/> and the thread that called this function is the same thread that called the extended I/O function
        /// (<see cref="ReadFileEx"/> or <see cref="WriteFileEx"/>), the function returns when either the time-out period has elapsed
        /// or when an I/O completion callback function occurs.
        /// If an I/O completion callback occurs, the I/O completion function is called.
        /// If an APC is queued to the thread (<see cref="QueueUserAPC"/>),
        /// the function returns when either the timer-out period has elapsed or when the APC function is called.
        /// </param>
        /// <returns>
        /// The return value is zero if the specified time interval expired.
        /// The return value is <see cref="WAIT_IO_COMPLETION"/> if the function returned due to one or more I/O completion callback functions.
        /// This can happen only if <paramref name="bAlertable"/> is <see langword="true"/>,
        /// and if the thread that called the <see cref="SleepEx"/> function is the same thread that called the extended I/O function.
        /// </returns>
        /// <remarks>
        /// This function causes a thread to relinquish the remainder of its time slice and become unrunnable for an interval
        /// based on the value of <paramref name="dwMilliseconds"/>.
        /// The system clock "ticks" at a constant rate.
        /// If <paramref name="dwMilliseconds"/> is less than the resolution of the system clock,
        /// the thread may sleep for less than the specified length of time.
        /// If <paramref name="dwMilliseconds"/> is greater than one tick but less than two, the wait can be anywhere between one and two ticks, and so on.
        /// To increase the accuracy of the sleep interval, call the <see cref="timeGetDevCaps"/> function
        /// to determine the supported minimum timer resolution and the <see cref="timeBeginPeriod"/> function to set the timer resolution to its minimum.
        /// Use caution when calling <see cref="timeBeginPeriod"/>, as frequent calls can significantly affect the system clock,
        /// system power usage, and the scheduler.
        /// If you call <see cref="timeBeginPeriod"/>, call it one time early in the application and be sure
        /// to call the <see cref="timeEndPeriod"/> function at the very end of the application.
        /// After the sleep interval has passed, the thread is ready to run.
        /// If you specify 0 milliseconds, the thread will relinquish the remainder of its time slice but remain ready.
        /// Note that a ready thread is not guaranteed to run immediately.
        /// Consequently, the thread may not run until some time after the sleep interval elapses.
        /// For more information, see Scheduling Priorities.
        /// This function can be used with the <see cref="ReadFileEx"/> or <see cref="WriteFileEx"/> functions to suspend a thread
        /// until an I/O operation has been completed.
        /// These functions specify a completion routine that is to be executed when the I/O operation has been completed.
        /// For the completion routine to be executed, the thread that called the I/O function must be in an alertable wait state
        /// when the completion callback function occurs.
        /// A thread goes into an alertable wait state by calling either <see cref="SleepEx"/>, <see cref="MsgWaitForMultipleObjectsEx"/>,
        /// <see cref="WaitForSingleObjectEx"/>, or <see cref="WaitForMultipleObjectsEx"/>,
        /// with the function's <paramref name="bAlertable"/> parameter set to <see langword="true"/>.
        /// Be careful when using <see cref="SleepEx"/> in the following scenarios:
        /// Code that directly or indirectly creates windows (for example, DDE and COM <see cref="CoInitialize"/>).
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// If you have a thread that uses <see cref="SleepEx"/> with infinite delay, the system will deadlock.
        /// Threads that are under concurrency control.
        /// For example, an I/O completion port or thread pool limits the number of associated threads that can run.
        /// If the maximum number of threads is already running, no additional associated thread can run until a running thread finishes.
        /// If a thread uses <see cref="SleepEx"/> with an interval of zero to wait for one of the additional associated threads to accomplish some work,
        /// the process might deadlock.
        /// For these scenarios, use <see cref="MsgWaitForMultipleObjects"/> or <see cref="MsgWaitForMultipleObjectsEx"/>, rather than <see cref="SleepEx"/>.
        /// Windows Phone 8.1: This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later.
        /// Windows 8.1 and Windows Server 2012 R2: This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SleepEx", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SleepEx([In] DWORD dwMilliseconds, [In] BOOL bAlertable);

        /// <summary>
        /// <para>
        /// Suspends the specified thread.
        /// A 64-bit application can suspend a WOW64 thread using the <see cref="Wow64SuspendThread"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-suspendthread"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread that is to be suspended.
        /// The handle must have the <see cref="THREAD_SUSPEND_RESUME"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the thread's previous suspend count; otherwise, it is (DWORD) -1.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// If the function succeeds, execution of the specified thread is suspended and the thread's suspend count is incremented. 
        /// Suspending a thread causes the thread to stop executing user-mode (application) code.
        /// This function is primarily designed for use by debuggers. It is not intended to be used for thread synchronization.
        /// Calling <see cref="SuspendThread"/> on a thread that owns a synchronization object, such as a mutex or critical section,
        /// can lead to a deadlock if the calling thread tries to obtain a synchronization object owned by a suspended thread.
        /// To avoid this situation, a thread within an application that is not a debugger should signal the other thread to suspend itself.
        /// The target thread must be designed to watch for this signal and respond appropriately.
        /// Each thread has a suspend count (with a maximum value of <see cref="MAXIMUM_SUSPEND_COUNT"/>).
        /// If the suspend count is greater than zero, the thread is suspended; otherwise, the thread is not suspended and is eligible for execution.
        /// Calling <see cref="SuspendThread"/> causes the target thread's suspend count to be incremented.
        /// Attempting to increment past the maximum suspend count causes an error without incrementing the count.
        /// The ResumeThread function decrements the suspend count of a suspended thread.
        /// Windows Phone 8.1: This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later.
        /// Windows 8.1 and Windows Server 2012 R2: This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SuspendThread", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SuspendThread([In] HANDLE hThread);

        /// <summary>
        /// <para>
        /// Causes the calling thread to yield execution to another thread that is ready to run on the current processor.
        /// The operating system selects the next thread to be executed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-switchtothread"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If calling the <see cref="SwitchToThread"/> function causes the operating system to switch execution to another thread,
        /// the return value is <see langword="true"/>.
        /// If there are no other threads ready to execute, the operating system does not switch execution to another thread,
        /// and the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// The yield of execution is in effect for up to one thread-scheduling time slice on the processor of the calling thread.
        /// The operating system will not switch execution to another processor, even if that processor is idle or is running a thread of lower priority.
        /// After the yielding thread's time slice elapses, the operating system reschedules execution for the yielding thread.
        /// The rescheduling is determined by the priority of the yielding thread and the status of other threads that are available to run.
        /// Note that the operating system will not switch to a thread that is being prevented from running only by concurrency control.
        /// For example, an I/O completion port or thread pool limits the number of associated threads that can run.
        /// If the maximum number of threads is already running, no additional associated thread can run until a running thread finishes.
        /// If a thread uses <see cref="SwitchToThread"/> to wait for one of the additional associated threads to accomplish some work,
        /// the process might deadlock.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SwitchToThread", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SwitchToThread();

        /// <summary>
        /// <para>
        /// Terminates a thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-terminatethread"/>
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread to be terminated.
        /// The handle must have the <see cref="THREAD_TERMINATE"/> access right.
        /// For more information, see Thread Security and Access Rights.
        /// </param>
        /// <param name="dwExitCode">
        /// The exit code for the thread.
        /// Use the <see cref="GetExitCodeThread"/> function to retrieve a thread's exit value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="TerminateThread"/> is used to cause a thread to exit.
        /// When this occurs, the target thread has no chance to execute any user-mode code.
        /// DLLs attached to the thread are not notified that the thread is terminating.
        /// The system frees the thread's initial stack.
        /// Windows Server 2003 and Windows XP:  The target thread's initial stack is not freed, causing a resource leak.
        /// <see cref="TerminateThread"/> is a dangerous function that should only be used in the most extreme cases.
        /// You should call <see cref="TerminateThread"/> only if you know exactly what the target thread is doing,
        /// and you control all of the code that the target thread could possibly be running at the time of the termination.
        /// For example, <see cref="TerminateThread"/> can result in the following problems:
        /// If the target thread owns a critical section, the critical section will not be released.
        /// If the target thread is allocating memory from the heap, the heap lock will not be released.
        /// If the target thread is executing certain kernel32 calls when it is terminated, the kernel32 state for the thread's process could be inconsistent.
        /// If the target thread is manipulating the global state of a shared DLL, the state of the DLL could be destroyed, affecting other users of the DLL
        /// A thread cannot protect itself against <see cref="TerminateThread"/>, other than by controlling access to its handles.
        /// The thread handle returned by the <see cref="CreateThread"/> and <see cref="CreateProcess"/> functions has <see cref="THREAD_TERMINATE"/> access,
        /// so any caller holding one of these handles can terminate your thread.
        /// If the target thread is the last thread of a process when this function is called, the thread's process is also terminated.
        /// The state of the thread object becomes signaled, releasing any other threads that had been waiting for the thread to terminate.
        /// The thread's termination status changes from <see cref="STILL_ACTIVE"/> to the value of the dwExitCode parameter.
        /// Terminating a thread does not necessarily remove the thread object from the system.
        /// A thread object is deleted when the last thread handle is closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TerminateThread", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TerminateThread([In] HANDLE hThread, [In] DWORD dwExitCode);

        /// <summary>
        /// <para>
        /// Retrieves information about the first thread of any process encountered in a system snapshot.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/tlhelp32/nf-tlhelp32-thread32first"/>
        /// </para>
        /// </summary>
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the <see cref="CreateToolhelp32Snapshot"/> function.
        /// </param>
        /// <param name="lpte">
        /// A pointer to a <see cref="THREADENTRY32"/> structure.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the first entry of the thread list has been copied to the buffer or <see cref="FALSE"/> otherwise.
        /// The <see cref="ERROR_NO_MORE_FILES"/> error value is returned by the <see cref="GetLastError"/> function
        /// if no threads exist or the snapshot does not contain thread information.
        /// </returns>
        /// <remarks>
        /// The calling application must set the dwSize member of <see cref="THREADENTRY32"/> to the size, in bytes, of the structure.
        /// <see cref="Thread32First"/> changes <see cref="THREADENTRY32.dwSize"/> to the number of bytes written to the structure.
        /// This will never be greater than the initial value of <see cref="THREADENTRY32.dwSize"/>, but it may be smaller.
        /// If the value is smaller, do not rely on the values of any members whose offsets are greater than this value.
        /// To retrieve information about other threads recorded in the same snapshot, use the <see cref="Thread32Next"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Thread32First", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Thread32First([In] HANDLE hSnapshot, [In][Out] ref THREADENTRY32 lpte);

        /// <summary>
        /// <para>
        /// Retrieves information about the next thread of any process encountered in the system memory snapshot.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/tlhelp32/nf-tlhelp32-thread32next"/>
        /// </para>
        /// </summary>
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the <see cref="CreateToolhelp32Snapshot"/> function.
        /// </param>
        /// <param name="lpte">
        /// A pointer to a <see cref="THREADENTRY32"/> structure.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the next entry of the thread list has been copied to the buffer or <see cref="FALSE"/> otherwise.
        /// The <see cref="ERROR_NO_MORE_FILES"/> error value is returned by the <see cref="GetLastError"/> function
        /// if no threads exist or the snapshot does not contain thread information.
        /// </returns>
        /// <remarks>
        /// To retrieve information about the first thread recorded in a snapshot, use the <see cref="Thread32First"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "Thread32Next", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Thread32Next([In] HANDLE hSnapshot, [In][Out] ref THREADENTRY32 lpte);

        /// <summary>
        /// <para>
        /// Allocates a thread local storage (TLS) index.
        /// Any thread of the process can subsequently use this index to store and retrieve values that are local to the thread,
        /// because each thread receives its own slot for the index.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-tlsalloc"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a TLS index. The slots for the index are initialized to zero.
        /// If the function fails, the return value is <see cref="TLS_OUT_OF_INDEXES"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Windows Phone 8.1:
        /// This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later.
        /// When a Windows Phone Store app calls this function, it is replaced with an inline call to <see cref="FlsAlloc"/>.
        /// Refer to <see cref="FlsAlloc"/> for function documentation.
        /// Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507:
        /// This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507.
        /// When a Windows Store app calls this function, it is replaced with an inline call to <see cref="FlsAlloc"/>.
        /// Refer to FlsAlloc for function documentation.
        /// Windows 10, version 1511 and Windows 10, version 1607:
        /// This function is fully supported for Universal Windows Platform (UWP) apps,
        /// and is no longer replaced with an inline call to <see cref="FlsAlloc"/>.
        /// The threads of the process can use the TLS index in subsequent calls to the <see cref="TlsFree"/>,
        /// <see cref="TlsSetValue"/>, or <see cref="TlsGetValue"/> functions.
        /// The value of the TLS index should be treated as an opaque value; do not assume that it is an index into a zero-based array.
        /// TLS indexes are typically allocated during process or dynamic-link library (DLL) initialization.
        /// When a TLS index is allocated, its storage slots are initialized to <see cref="NULL"/>.
        /// After a TLS index has been allocated, each thread of the process can use it to access its own TLS storage slot.
        /// To store a value in its TLS slot, a thread specifies the index in a call to <see cref="TlsSetValue"/>.
        /// The thread specifies the same index in a subsequent call to <see cref="TlsGetValue"/>, to retrieve the stored value.
        /// TLS indexes are not valid across process boundaries. A DLL cannot assume that an index assigned in one process is valid in another process.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TlsAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD TlsAlloc();

        /// <summary>
        /// <para>
        /// Releases a thread local storage (TLS) index, making it available for reuse.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/windows/win32/api/processthreadsapi/nf-processthreadsapi-tlsfree"/>
        /// </para>
        /// </summary>
        /// <param name="dwTlsIndex">
        /// The TLS index that was allocated by the <see cref="TlsAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Windows Phone 8.1:
        /// This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later.
        /// When a Windows Phone Store app calls this function, it is replaced with an inline call to <see cref="FlsFree"/>.
        /// Refer to <see cref="FlsFree"/> for function documentation.
        /// Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507:
        /// This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507.
        /// When a Windows Store app calls this function, it is replaced with an inline call to <see cref="FlsFree"/>.
        /// Refer to <see cref="FlsFree"/> for function documentation.
        /// Windows 10, version 1511 and Windows 10, version 1607:
        /// This function is fully supported for Universal Windows Platform (UWP) apps,
        /// and is no longer replaced with an inline call to <see cref="FlsFree"/>.
        /// If the threads of the process have allocated memory and stored a pointer to the memory in a TLS slot,
        /// they should free the memory before calling <see cref="TlsFree"/>.
        /// The <see cref="TlsFree"/> function does not free memory blocks whose addresses have been stored in the TLS slots associated with the TLS index.
        /// It is expected that DLLs call this function (if at all) only during <see cref="DLL_PROCESS_DETACH"/>.
        /// For more information, see Thread Local Storage.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TlsFree", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TlsFree([In] DWORD dwTlsIndex);

        /// <summary>
        /// <para>
        /// Retrieves the value in the calling thread's thread local storage (TLS) slot for the specified TLS index.
        /// Each thread of a process has its own slot for each TLS index.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-tlsgetvalue"/>
        /// </para>
        /// </summary>
        /// <param name="dwTlsIndex">
        /// The TLS index that was allocated by the <see cref="TlsAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the value stored in the calling thread's TLS slot associated with the specified index.
        /// If <paramref name="dwTlsIndex"/> is a valid index allocated by a successful call to <see cref="TlsAlloc"/>, this function always succeeds.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The data stored in a TLS slot can have a value of 0 because it still has its initial value or 
        /// because the thread called the <see cref="TlsSetValue"/> function with 0.
        /// Therefore, if the return value is 0, you must check whether <see cref="GetLastError"/> returns <see cref="ERROR_SUCCESS"/>
        /// before determining that the function has failed.
        /// If <see cref="GetLastError"/> returns <see cref="ERROR_SUCCESS"/>, then the function has succeeded and the data stored in the TLS slot is 0.
        /// Otherwise, the function has failed.
        /// Functions that return indications of failure call <see cref="SetLastError"/> when they fail.
        /// They generally do not call <see cref="SetLastError"/> when they succeed.
        /// The <see cref="TlsGetValue"/> function is an exception to this general rule.
        /// The <see cref="TlsGetValue"/> function calls <see cref="SetLastError"/> to clear a thread's last error when it succeeds.
        /// That allows checking for the error-free retrieval of zero values.
        /// </returns>
        /// <remarks>
        /// Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507:
        /// This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507.
        /// When a Windows Store app calls this function, it is replaced with an inline call to <see cref="FlsGetValue"/>.
        /// Refer to <see cref="FlsGetValue"/> for function documentation.
        /// Windows 10, version 1511 and Windows 10, version 1607:
        /// This function is fully supported for Universal Windows Platform (UWP) apps,
        /// and is no longer replaced with an inline call to <see cref="FlsGetValue"/>.
        /// TLS indexes are typically allocated by the <see cref="TlsAlloc"/> function during process or DLL initialization.
        /// After a TLS index is allocated, each thread of the process can use it to access its own TLS slot for that index.
        /// A thread specifies a TLS index in a call to <see cref="TlsSetValue"/> to store a value in its slot.
        /// The thread specifies the same index in a subsequent call to <see cref="TlsGetValue"/> to retrieve the stored value.
        /// <see cref="TlsGetValue"/> was implemented with speed as the primary goal.
        /// The function performs minimal parameter validation and error checking.
        /// In particular, it succeeds if <paramref name="dwTlsIndex"/> is in the range 0 through (<see cref="TLS_MINIMUM_AVAILABLE"/>– 1).
        /// It is up to the programmer to ensure that the index is valid and
        /// that the thread calls <see cref="TlsSetValue"/> before calling <see cref="TlsGetValue"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TlsGetValue", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID TlsGetValue([In] DWORD dwTlsIndex);

        /// <summary>
        /// <para>
        /// Stores a value in the calling thread's thread local storage (TLS) slot for the specified TLS index.
        /// Each thread of a process has its own slot for each TLS index.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-tlssetvalue"/>
        /// </para>
        /// </summary>
        /// <param name="dwTlsIndex">
        /// The TLS index that was allocated by the <see cref="TlsAlloc"/> function.
        /// </param>
        /// <param name="lpTlsValue">
        /// The value to be stored in the calling thread's TLS slot for the index.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Windows Phone 8.1:
        /// This function is supported for Windows Phone Store apps on Windows Phone 8.1 and later.
        /// When a Windows Phone Store app calls this function, it is replaced with an inline call to <see cref="FlsSetValue"/>.
        /// Refer to <see cref="FlsSetValue"/> for function documentation.
        /// Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507:
        /// This function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and Windows 10, version 1507.
        /// When a Windows Store app calls this function, it is replaced with an inline call to <see cref="FlsSetValue"/>.
        /// Refer to <see cref="FlsSetValue"/> for function documentation.
        /// Windows 10, version 1511 and Windows 10, version 1607:
        /// This function is fully supported for Universal Windows Platform (UWP) apps,
        /// and is no longer replaced with an inline call to <see cref="FlsSetValue"/>.
        /// TLS indexes are typically allocated by the <see cref="TlsAlloc"/> function during process or DLL initialization.
        /// When a TLS index is allocated, its storage slots are initialized to NULL.
        /// After a TLS index is allocated, each thread of the process can use it to access its own TLS slot for that index.
        /// A thread specifies a TLS index in a call to <see cref="TlsSetValue"/>, to store a value in its slot.
        /// The thread specifies the same index in a subsequent call to <see cref="TlsGetValue"/>, to retrieve the stored value.
        /// <see cref="TlsSetValue"/> was implemented with speed as the primary goal.
        /// The function performs minimal parameter validation and error checking.
        /// In particular, it succeeds if <paramref name="dwTlsIndex"/> is in the range 0 through (<see cref="TLS_MINIMUM_AVAILABLE"/> – 1).
        /// It is up to the programmer to ensure that the index is valid before calling <see cref="TlsGetValue"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TlsSetValue", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TlsSetValue([In] DWORD dwTlsIndex, [In] LPVOID lpTlsValue);
    }
}
