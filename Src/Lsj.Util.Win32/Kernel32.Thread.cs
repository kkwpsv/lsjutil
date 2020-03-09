﻿using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ThreadCreationFlags;
using static Lsj.Util.Win32.Enums.ThreadPriorityFlags;
using static Lsj.Util.Win32.Enums.ProcessPriorityClasses;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// An application-defined function that serves as the starting address for a thread.
        /// Specify this address when calling the <see cref="CreateThread"/>, <see cref="CreateRemoteThread"/>, or <see cref="CreateRemoteThreadEx"/> function.
        /// The LPTHREAD_START_ROUTINE type defines a pointer to this callback function.
        /// <see cref="ThreadProc"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms686736(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="lpParameter">
        /// The thread data passed to the function using the lpParameter parameter of the <see cref="CreateThread"/>,
        /// <see cref="CreateRemoteThread"/>, or <see cref="CreateRemoteThreadEx"/> function.
        /// </param>
        /// <returns>
        /// The return value indicates the success or failure of this function.
        /// The return value should never be set to <see cref="STILL_ACTIVE"/>, as noted in <see cref="GetExitCodeThread"/>.
        /// Do not declare this callback function with a void return type and cast the function pointer
        /// to <see cref="ThreadProc"/> when creating the thread.
        /// Code that does this is common, but it can crash on 64-bit Windows.
        /// </returns>
        /// <remarks>
        /// A process can determine when a thread it created has completed by using one of the wait functions.
        /// It can also obtain the return value of its <see cref="ThreadProc"/> by calling the <see cref="GetExitCodeThread"/> function.
        /// Each thread receives a unique copy of the local variables of this function.
        /// Any static or global variables are shared by all threads in the process.
        /// To provide unique data to each thread using a global index, use thread local storage.
        /// </remarks>
        public delegate uint ThreadProc([In]IntPtr lpParameter);

        /// <summary>
        /// <para>
        /// Creates a thread that runs in the virtual address space of another process.
        /// Use the <see cref="CreateRemoteThreadEx"/> function to create a thread that runs in the virtual address space of another process
        /// and optionally specify extended attributes.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-createremotethread
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
        /// For more information, see <see cref="ThreadProc"/>.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRemoteThread", SetLastError = true)]
        public static extern IntPtr CreateRemoteThread([In]IntPtr hProcess,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpThreadAttributes, [In]UIntPtr dwStackSize,
            [MarshalAs(UnmanagedType.FunctionPtr)][In]ThreadProc lpStartAddress, [In]IntPtr lpParameter, [In]ThreadCreationFlags dwCreationFlags,
            [Out]out uint lpThreadId);

        /// <summary>
        /// <para>
        /// Creates a thread that runs in the virtual address space of another process
        /// and optionally specifies extended attributes such as processor group affinity.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-createremotethreadex
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
        /// For more information, see <see cref="ThreadProc"/>.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRemoteThreadEx", SetLastError = true)]
        public static extern IntPtr CreateRemoteThreadEx([In]IntPtr hProcess,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpThreadAttributes, [In]UIntPtr dwStackSize,
            [MarshalAs(UnmanagedType.FunctionPtr)][In]ThreadProc lpStartAddress, [In]IntPtr lpParameter, [In]ThreadCreationFlags dwCreationFlags,
            [In]IntPtr lpAttributeList, [Out]out uint lpThreadId);

        /// <summary>
        /// <para>
        /// Creates a thread to execute within the virtual address space of the calling process.
        /// To create a thread that runs in the virtual address space of another process, use the <see cref="CreateRemoteThread"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-createthread
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
        /// This pointer represents the starting address of the thread. For more information on the thread function, see <see cref="ThreadProc"/>.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThread", SetLastError = true)]
        public static extern IntPtr CreateThread(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpThreadAttributes, [In]UIntPtr dwStackSize,
            [MarshalAs(UnmanagedType.FunctionPtr)][In] ThreadProc lpStartAddress, [In]IntPtr lpParameter, [In]ThreadCreationFlags dwCreationFlags,
            [Out]out uint lpThreadId);

        /// <summary>
        /// <para>
        /// Ends the calling thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-exitthread
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExitThread", SetLastError = true)]
        public static extern void ExitThread([In]uint dwExitCode);

        /// <summary>
        /// <para>
        /// Retrieves a pseudo handle for the calling thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentthread
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentThread", SetLastError = true)]
        public static extern IntPtr GetCurrentThread();

        /// <summary>
        /// <para>
        /// Retrieves the thread identifier of the calling thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentthreadid
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is the thread identifier of the calling thread.
        /// </returns>
        /// <remarks>
        /// Until the thread terminates, the thread identifier uniquely identifies the thread throughout the system.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentThreadId", SetLastError = true)]
        public static extern uint GetCurrentThreadId();

        /// <summary>
        /// <para>
        /// Retrieves the termination status of the specified thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getexitcodethread
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetExitCodeThread", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetExitCodeThread([In]IntPtr hThread, [Out]out uint lpExitCode);

        /// <summary>
        /// <para>
        /// Retrieves the process identifier of the process associated with the specified thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocessidofthread
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessIdOfThread", SetLastError = true)]
        public static extern uint GetProcessIdOfThread([In]IntPtr Thread);

        /// <summary>
        /// <para>
        /// A handle to the thread.
        /// The handle must have the <see cref="THREAD_QUERY_INFORMATION"/> or <see cref="THREAD_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information about access rights, see Thread Security and Access Rights.
        /// Windows Server 2003:  The handle must have the THREAD_QUERY_INFORMATION access right.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadId", SetLastError = true)]
        public static extern uint GetThreadId([In]IntPtr Thread);

        /// <summary>
        /// <para>
        /// Retrieves the priority value for the specified thread.
        /// This value, together with the priority class of the thread's process, determines the thread's base-priority level.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadPriority", SetLastError = true)]
        public static extern int GetThreadPriority([In]IntPtr hThread);

        /// <summary>
        /// <para>
        /// Terminates a thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-terminatethread
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TerminateThread", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TerminateThread([In]IntPtr hThread, [In]uint dwExitCode);
    }
}
