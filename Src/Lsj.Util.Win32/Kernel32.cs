using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Ktmw32;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Userenv;
using static Lsj.Util.Win32.Ws2_32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Kernel32.dll
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// CREATE_MUTEX_INITIAL_OWNER
        /// </summary>
        public const uint CREATE_MUTEX_INITIAL_OWNER = 1;

        /// <summary>
        /// CREATE_WAITABLE_TIMER_MANUAL_RESET
        /// </summary>
        public const uint CREATE_WAITABLE_TIMER_MANUAL_RESET = 1;

        /// <summary>
        /// MAILSLOT_WAIT_FOREVER
        /// </summary>
        public const uint MAILSLOT_WAIT_FOREVER = unchecked((uint)-1);

        /// <summary>
        /// Does not wait for the named pipe. If the named pipe is not available, the function returns an error.
        /// </summary>
        public const uint NMPWAIT_NOWAIT = 0x00000001;

        /// <summary>
        /// Uses the default time-out specified in a call to the <see cref="CreateNamedPipe"/> function.
        /// </summary>
        public const uint NMPWAIT_USE_DEFAULT_WAIT = 0x00000000;

        /// <summary>
        /// Waits indefinitely.
        /// </summary>
        public const uint NMPWAIT_WAIT_FOREVER = 0xffffffff;

        /// <summary>
        /// NUMA_NO_PREFERRED_NODE
        /// </summary>
        public const uint NUMA_NO_PREFERRED_NODE = 0xffffffff;

        /// <summary>
        /// PIPE_UNLIMITED_INSTANCES
        /// </summary>
        public const uint PIPE_UNLIMITED_INSTANCES = 255;

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
        /// to LPTHREAD_START_ROUTINE when creating the thread.
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
        /// Assigns a process to an existing job object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/jobapi2/nf-jobapi2-assignprocesstojobobject
        /// </para>
        /// </summary>
        /// <param name="hJob">
        /// A handle to the job object to which the process will be associated.
        /// The <see cref="CreateJobObject"/> or <see cref="OpenJobObject"/> function returns this handle.
        /// The handle must have the <see cref="JOB_OBJECT_ASSIGN_PROCESS"/> access right.
        /// For more information, see Job Object Security and Access Rights.
        /// </param>
        /// <param name="hProcess">
        /// A handle to the process to associate with the job object.
        /// The handle must have the <see cref="PROCESS_SET_QUOTA"/> and <see cref="PROCESS_TERMINATE"/> access rights.
        /// For more information, see Process Security and Access Rights.
        /// If the process is already associated with a job, the job specified by hJob must be empty or it must be
        /// in the hierarchy of nested jobs to which the process already belongs,
        /// and it cannot have UI limits set (<see cref="SetInformationJobObject"/> with <see cref="JobObjectBasicUIRestrictions"/>).
        /// For more information, see Remarks.
        /// Windows 7, Windows Server 2008 R2, Windows XP with SP3, Windows Server 2008, Windows Vista and Windows Server 2003:
        /// The process must not already be assigned to a job; if it is, the function fails with <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// This behavior changed starting in Windows 8 and Windows Server 2012.
        /// Terminal Services:  All processes within a job must run within the same session as the job.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// After you associate a process with a job object using <see cref="AssignProcessToJobObject"/>,
        /// the process is subject to the limits set for the job.
        /// To set limits for a job, use the <see cref="SetInformationJobObject"/> function.
        /// If the job has a user-mode time limit, and the time limit has been exhausted,
        /// <see cref="AssignProcessToJobObject"/> fails and the specified process is terminated.
        /// If the time limit would be exceeded by associating the process, <see cref="AssignProcessToJobObject"/> still succeeds.
        /// However, the time limit violation will be reported.
        /// If the job has an active process limit, and the limit would be exceeded by associating this process,
        /// <see cref="AssignProcessToJobObject"/> fails, and the specified process is terminated.
        /// Memory operations performed by a process associated with a job that has a memory limit are subject to the memory limit.
        /// Memory operations performed by the process before it was associated with the job are not examined by <see cref="AssignProcessToJobObject"/>.
        /// If the process is already running and the job has security limitations, <see cref="AssignProcessToJobObject"/> may fail.
        /// For example, if the primary token of the process contains the local administrators group,
        /// but the job object has the security limitation <see cref="JOB_OBJECT_SECURITY_NO_ADMIN"/>, the function fails.
        /// If the job has the security limitation <see cref="JOB_OBJECT_SECURITY_ONLY_TOKEN"/>, the process must be created suspended.
        /// To create a suspended process, call the <see cref="CreateProcess"/> function with the <see cref="ProcessCreationFlags.CREATE_SUSPENDED"/> flag.
        /// A process can be associated with more than one job in a hierarchy of nested jobs.
        /// For priority class, affinity, commit charge, per-process execution time limit, scheduling class limit, and working set minimum and maximum,
        /// the process inherits an effective limit which is the most restrictive limit of all the jobs in its parent job chain.
        /// For other resource limits, the process inherits limits from its immediate job in the hierarchy.
        /// Accounting information is added to the immediate job and aggregated in each parent job in the job chain.
        /// By default, all child processes are associated with the immediate job and every job in the parent job chain.
        /// To create a child process that is not part of the same job chain, call the <see cref="CreateProcess"/> function 
        /// with the <see cref="ProcessCreationFlags.CREATE_BREAKAWAY_FROM_JOB"/> flag.
        /// The child process breaks away from every job in the job chain unless a job in the chain does not allow breakaway.
        /// In this case, the child process does not break away from that job or any job above it in the job chain.
        /// For more information, see Nested Jobs.
        /// Windows 7, Windows Server 2008 R2, Windows XP with SP3, Windows Server 2008, Windows Vista and Windows Server 2003:
        /// A process can be associated only with a single job.
        /// A process inherits limits from the job it is associated with and adds its accounting information to the job.
        /// If a process is associated with a job, all child processes it creates are associated with that job by default.
        /// To create a child process that is not part of the same job, call the <see cref="CreateProcess"/> function
        /// with the <see cref="ProcessCreationFlags.CREATE_BREAKAWAY_FROM_JOB"/> flag.
        /// A process can be associated with more than one job starting in Windows 8 and Windows Server 2012.
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008 and Windows Vista:
        /// If the process is being monitored by the Program Compatibility Assistant (PCA), it is placed into a compatibility job.
        /// Therefore, the process must be created using <see cref="ProcessCreationFlags.CREATE_BREAKAWAY_FROM_JOB"/> before it can be placed in another job.
        /// Alternatively, you can embed an application manifest that specifies a User Account Control (UAC) level in your application
        /// and PCA will not add the process to the compatibility job.
        /// For more information, see Application Development Requirements for User Account Control Compatibility.
        /// If the job or any of its parent jobs in the job chain is terminating when <see cref="AssignProcessToJobObject"/> is called, the function fails.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later. For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AssignProcessToJobObject", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AssignProcessToJobObject([In]IntPtr hJob, [In]IntPtr hProcess);

        /// <summary>
        /// <para>
        /// Connects to a message-type pipe (and waits if an instance of the pipe is not available),
        /// writes to and reads from the pipe, and then closes the pipe.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-callnamedpipea
        /// </para>
        /// </summary>
        /// <param name="lpNamedPipeName">
        /// The pipe name.
        /// </param>
        /// <param name="lpInBuffer">
        /// The data to be written to the pipe.
        /// </param>
        /// <param name="nInBufferSize">
        /// The size of the write buffer, in bytes.
        /// </param>
        /// <param name="lpOutBuffer">
        /// A pointer to the buffer that receives the data read from the pipe.
        /// </param>
        /// <param name="nOutBufferSize">
        /// The size of the read buffer, in bytes.
        /// </param>
        /// <param name="lpBytesRead">
        /// A pointer to a variable that receives the number of bytes read from the pipe.
        /// </param>
        /// <param name="nTimeOut">
        /// The number of milliseconds to wait for the named pipe to be available.
        /// In addition to numeric values, the following special values can be specified.
        /// <see cref="NMPWAIT_NOWAIT"/>, <see cref="NMPWAIT_WAIT_FOREVER"/>, <see cref="NMPWAIT_USE_DEFAULT_WAIT"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// If the message written to the pipe by the server process is longer than <paramref name="nOutBufferSize"/>,
        /// <see cref="CallNamedPipe"/> returns <see langword="false"/>,
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_MORE_DATA"/>.
        /// The remainder of the message is discarded, because <see cref="CallNamedPipe"/> closes the handle to the pipe before returning.
        /// </returns>
        /// <remarks>
        /// Calling <see cref="CallNamedPipe"/> is equivalent to calling the <see cref="CreateFile"/> (or <see cref="WaitNamedPipe"/>,
        /// if <see cref="CreateFile"/> cannot open the pipe immediately), <see cref="TransactNamedPipe"/>, and <see cref="CloseHandle"/> functions.
        /// <see cref="CreateFile"/> is called with an access flag
        /// of <see cref="GenericAccessRights.GENERIC_READ"/> | <see cref="GenericAccessRights.GENERIC_WRITE"/>,
        /// and an inherit handle flag of <see langword="false"/>.
        /// <see cref="CallNamedPipe"/> fails if the pipe is a byte-type pipe.
        /// Windows 10, version 1709:  Pipes are only supported within an app-container;
        /// ie, from one UWP process to another UWP process that's part of the same app.
        /// Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallNamedPipeW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CallNamedPipe([MarshalAs(UnmanagedType.LPWStr)][In]string lpNamedPipeName, [In]IntPtr lpInBuffer,
            [In]uint nInBufferSize, [In]IntPtr lpOutBuffer, [In]uint nOutBufferSize, [Out]out uint lpBytesRead, [In]uint nTimeOut);

        /// <summary>
        /// <para>
        /// Closes an open object handle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/handleapi/nf-handleapi-closehandle
        /// </para>
        /// </summary>
        /// <param name="hObject">
        /// A valid handle to an open object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// If the application is running under a debugger, the function will throw an exception if it receives either a handle value
        /// that is not valid or a pseudo-handle value.
        /// This can happen if you close a handle twice, or if you call <see cref="CloseHandle"/> on a handle returned
        /// by the <see cref="FindFirstFile"/> function instead of calling the <see cref="FindClose"/> function.
        /// </returns>
        /// <remarks>
        /// The CloseHandle function closes handles to the following objects:
        /// Access token, Communications device, Console input, Console screen buffer, Event, File, File mapping, I/O completion port, 
        /// Job, Mailslot, Memory resource notification, Mutex, Named pipe, Pipe, Process, Semaphore, Thread, Transaction, Waitable timer.
        /// The documentation for the functions that create these objects indicates that <see cref="CloseHandle"/> should be used
        /// when you are finished with the object, and what happens to pending operations on the object after the handle is closed.
        /// In general, <see cref="CloseHandle"/> invalidates the specified object handle, decrements the object's handle count,
        /// and performs object retention checks. After the last handle to an object is closed, the object is removed from the system.
        /// For a summary of the creator functions for these objects, see Kernel Objects.
        /// Generally, an application should call <see cref="CloseHandle"/> once for each handle it opens.
        /// It is usually not necessary to call <see cref="CloseHandle"/> if a function that uses a handle
        /// fails with <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>, because this error usually indicates that the handle is already invalidated.
        /// However, some functions use <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/> to indicate that the object itself is no longer valid.
        /// For example, a function that attempts to use a handle to a file on a network might fail
        /// with <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/> if the network connection is severed,
        /// because the file object is no longer available. In this case, the application should close the handle.
        /// If a handle is transacted, all handles bound to a transaction should be closed before the transaction is committed.
        /// If a transacted handle was opened by calling <see cref="CreateFileTransacted"/> with the <see cref="FILE_FLAG_DELETE_ON_CLOSE"/> flag,
        /// the file is not deleted until the application closes the handle and calls <see cref="CommitTransaction"/>.
        /// For more information about transacted objects, see Working With Transactions.
        /// Closing a thread handle does not terminate the associated thread or remove the thread object.
        /// Closing a process handle does not terminate the associated process or remove the process object.
        /// To remove a thread object, you must terminate the thread, then close all handles to the thread.
        /// For more information, see Terminating a Thread.
        /// To remove a process object, you must terminate the process, then close all handles to the process.
        /// For more information, see Terminating a Process.
        /// Closing a handle to a file mapping can succeed even when there are file views that are still open.
        /// For more information, see Closing a File Mapping Object.
        /// Do not use the <see cref="CloseHandle"/> function to close a socket. Instead, use the <see cref="closesocket"/> function,
        /// which releases all resources associated with the socket including the handle to the socket object.
        /// For more information, see Socket Closure.
        /// Do not use the <see cref="CloseHandle"/> function to close a handle to an open registry key.
        /// Instead, use the <see cref="RegCloseKey"/> function.
        /// <see cref="CloseHandle"/> does not close the handle to the registry key, but does not return an error to indicate this failure.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseHandle", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle([In]IntPtr hObject);

        /// <summary>
        /// <para>
        /// Parses a Unicode command line string and returns an array of pointers to the command line arguments,
        /// along with a count of such arguments, in a way that is similar to the standard C run-time argv and argc values.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-commandlinetoargvw
        /// </para>
        /// </summary>
        /// <param name="lpCmdLine">
        /// Pointer to a null-terminated Unicode string that contains the full command line.
        /// If this parameter is an empty string the function returns the path to the current executable file.
        /// </param>
        /// <param name="pNumArgs">
        /// Pointer to an int that receives the number of array elements returned, similar to argc.
        /// </param>
        /// <returns>
        /// A pointer to an array of LPWSTR values, similar to argv.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// The address returned by <see cref="CommandLineToArgvW"/> is the address of the first element in an array of LPWSTR values;
        /// the number of pointers in this array is indicated by <paramref name="pNumArgs"/>.
        /// Each pointer to a null-terminated Unicode string represents an individual argument found on the command line.
        /// <see cref="CommandLineToArgvW"/> allocates a block of contiguous memory for pointers to the argument strings,
        /// and for the argument strings themselves; the calling application must free the memory used by the argument list when it is no longer needed.
        /// To free the memory, use a single call to the <see cref="LocalFree"/> function.
        /// For more information about the argv and argc argument convention, see Argument Definitions and Parsing C++ Command-Line Arguments.
        /// The <see cref="GetCommandLine"/> function can be used to get a command line string
        /// that is suitable for use as the <paramref name="lpCmdLine"/> parameter.
        /// This function accepts command lines that contain a program name; the program name can be enclosed in quotation marks or not.
        /// <see cref="CommandLineToArgvW"/> has a special interpretation of backslash characters when they are followed by a quotation mark character (").
        /// This interpretation assumes that any preceding argument is a valid file system path, or else it may behave unpredictably.
        /// This special interpretation controls the "in quotes" mode tracked by the parser. When this mode is off, whitespace terminates the current argument.
        /// When on, whitespace is added to the argument like all other characters.
        /// 2n backslashes followed by a quotation mark produce n backslashes followed by begin/end quote. This does not become part of the parsed argument,
        /// but toggles the "in quotes" mode.
        /// (2n) + 1 backslashes followed by a quotation mark again produce n backslashes followed by a quotation mark literal (").
        /// This does not toggle the "in quotes" mode.
        /// n backslashes not followed by a quotation mark simply produce n backslashes.
        /// <see cref="CommandLineToArgvW"/> treats whitespace outside of quotation marks as argument delimiters.
        /// However, if <paramref name="lpCmdLine"/> starts with any amount of whitespace,
        /// <see cref="CommandLineToArgvW"/> will consider the first argument to be an empty string.
        /// Excess whitespace at the end of <paramref name="lpCmdLine"/> is ignored.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CommandLineToArgvW", SetLastError = true)]
        public static extern IntPtr CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)][In]string lpCmdLine, [Out]out int pNumArgs);

        /// <summary>
        /// <para>
        /// Enables a named pipe server process to wait for a client process to connect to an instance of a named pipe.
        /// A client process connects by calling either the <see cref="CreateFile"/> or <see cref="CallNamedPipe"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/namedpipeapi/nf-namedpipeapi-connectnamedpipe
        /// </para>
        /// </summary>
        /// <param name="hNamedPipe">
        /// A handle to the server end of a named pipe instance.
        /// This handle is returned by the <see cref="CreateNamedPipe"/> function.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure.
        /// If <paramref name="hNamedPipe"/> was opened with <see cref="FileFlags.FILE_FLAG_OVERLAPPED"/>,
        /// the <paramref name="lpOverlapped"/> parameter must not be <see cref="IntPtr.Zero"/>.
        /// It must point to a valid <see cref="OVERLAPPED"/> structure.
        /// If <paramref name="hNamedPipe"/> was opened with <see cref="FileFlags.FILE_FLAG_OVERLAPPED"/>
        /// and <paramref name="lpOverlapped"/> is <see cref="IntPtr.Zero"/>,
        /// the function can incorrectly report that the connect operation is complete.
        /// If <paramref name="hNamedPipe"/> was created with <see cref="FileFlags.FILE_FLAG_OVERLAPPED"/>
        /// and <paramref name="lpOverlapped"/> is not <see cref="IntPtr.Zero"/>,
        /// the <see cref="OVERLAPPED"/> structure should contain a handle to a manual-reset event object
        /// (which the server can create by using the <see cref="CreateEvent"/> function).
        /// If <paramref name="hNamedPipe"/> was not opened with <see cref="FileFlags.FILE_FLAG_OVERLAPPED"/>,
        /// the function does not return until a client is connected or an error occurs.
        /// Successful synchronous operations result in the function returning a nonzero value if a client connects after the function is called.
        /// </param>
        /// <returns>
        /// If the operation is synchronous, <see cref="ConnectNamedPipe"/> does not return until the operation has completed.
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// If the operation is asynchronous, <see cref="ConnectNamedPipe"/> returns immediately.
        /// If the operation is still pending, the return value is <see langword="false"/>
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_IO_PENDING"/>.
        /// (You can use the <see cref="HasOverlappedIoCompleted"/> macro to determine when the operation has finished.)
        /// If the function fails, the return value is <see langword="false"/>
        /// and <see cref="Marshal.GetLastWin32Error"/> returns a value
        /// other than <see cref="SystemErrorCodes.ERROR_IO_PENDING"/> or <see cref="SystemErrorCodes.ERROR_PIPE_CONNECTED"/>.
        /// If a client connects before the function is called, the function returns <see langword="false"/>
        /// and GetLastError returns <see cref="SystemErrorCodes.ERROR_PIPE_CONNECTED"/>.
        /// This can happen if a client connects in the interval between the call to <see cref="CreateNamedPipe"/>
        /// and the call to <see cref="ConnectNamedPipe"/>.
        /// In this situation, there is a good connection between client and server, even though the function returns <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// A named pipe server process can use <see cref="ConnectNamedPipe"/> with a newly created pipe instance.
        /// It can also be used with an instance that was previously connected to another client process;
        /// in this case, the server process must first call the <see cref="DisconnectNamedPipe"/> function
        /// to disconnect the handle from the previous client before the handle can be reconnected to a new client.
        /// Otherwise, <see cref="ConnectNamedPipe"/> returns <see langword="false"/>,
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_NO_DATA"/>
        /// if the previous client has closed its handle or <see cref="SystemErrorCodes.ERROR_PIPE_CONNECTED"/> if it has not closed its handle.
        /// The behavior of <see cref="ConnectNamedPipe"/> depends on two conditions:
        /// whether the pipe handle's wait mode is set to blocking or nonblocking and
        /// whether the function is set to execute synchronously or in overlapped mode.
        /// A server initially specifies a pipe handle's wait mode in the <see cref="CreateNamedPipe"/> function,
        /// and it can be changed by using the <see cref="SetNamedPipeHandleState"/> function.
        /// The server process can use any of the wait functions or <see cref="SleepEx"/>— to determine
        /// when the state of the event object is signaled, and it can then use
        /// the <see cref="HasOverlappedIoCompleted"/> macro to determine when the <see cref="ConnectNamedPipe"/> operation completes.
        /// If the specified pipe handle is in nonblocking mode, <see cref="ConnectNamedPipe"/> always returns immediately.
        /// In nonblocking mode, <see cref="ConnectNamedPipe"/> returns a nonzero value the first time it is called for a pipe instance
        /// that is disconnected from a previous client.
        /// This indicates that the pipe is now available to be connected to a new client process.
        /// In all other situations when the pipe handle is in nonblocking mode, <see cref="ConnectNamedPipe"/> returns <see langword="false"/>.
        /// In these situations, <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_PIPE_LISTENING"/>
        /// if no client is connected, <see cref="SystemErrorCodes.ERROR_PIPE_CONNECTED"/> if a client is connected,
        /// and <see cref="SystemErrorCodes.ERROR_NO_DATA"/> if a previous client has closed its pipe handle but the server has not disconnected.
        /// Note that a good connection between client and server exists only
        /// after the <see cref="SystemErrorCodes.ERROR_PIPE_CONNECTED"/> error is received.
        /// Nonblocking mode is supported for compatibility with Microsoft LAN Manager version 2.0,
        /// and it should not be used to achieve asynchronous input and output (I/O) with named pipes.
        /// Windows 10, version 1709:  Pipes are only supported within an app-container; ie, from one UWP process to another UWP process
        /// that's part of the same app. Also, named pipes must use the syntax "\\.\pipe\LOCAL\" for the pipe name.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConnectNamedPipe", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConnectNamedPipe([In]IntPtr hNamedPipe, [In]int lpOverlapped);

        /// <summary>
        /// <para>
        /// Creates a new directory.
        /// If the underlying file system supports security on files and directories,
        /// the function applies a specified security descriptor to the new directory.
        /// To specify a template directory, use the <see cref="CreateDirectoryEx"/> function.
        /// To perform this operation as a transacted operation, use the <see cref="CreateDirectoryTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createdirectory
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// The path of the directory to be created.
        /// For the ANSI version of this function, there is a default string size limit for paths of 248 characters
        /// (<see cref="Constants.MAX_PATH"/> - enough room for a 8.3 filename).
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File
        ///  Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="CreateDirectory"/>),
        ///  you can opt-in to remove the 248 character limitation without prepending "\\?\". The 255 character limit per path segment still applies.
        ///  See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// The <paramref name="lpSecurityAttributes"/> member of the structure specifies a security descriptor for the new directory.
        /// If <paramref name="lpSecurityAttributes"/> is null, the directory gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for this parameter to have an effect.
        /// This is indicated when <see cref="GetVolumeInformation"/> returns <see cref="FS_PERSISTENT_ACLS"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// Possible errors include the following.
        /// <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>: The specified directory already exists.
        /// <see cref="SystemErrorCodes.ERROR_PATH_NOT_FOUND"/>: One or more intermediate directories do not exist.
        /// </returns>
        /// <remarks>
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes formatted for such a file system, a new directory inherits the compression and encryption attributes of its parent directory.
        /// An application can obtain a handle to a directory by calling <see cref="CreateFile"/> with
        /// the <see cref="FileFlags.FILE_FLAG_BACKUP_SEMANTICS"/> flag set.
        /// For a code example, see <see cref="CreateFile"/>.
        /// To support inheritance functions that query the security descriptor of this object may heuristically determine
        /// and report that inheritance is in effect. See Automatic Propagation of Inheritable ACEs for more information.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDirectoryW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateDirectory([MarshalAs(UnmanagedType.LPWStr)][In]string lpPathName,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Creates a new directory with the attributes of a specified template directory.
        /// If the underlying file system supports security on files and directories,
        /// the function applies a specified security descriptor to the new directory.
        /// The new directory retains the other attributes of the specified template directory.
        /// To perform this operation as a transacted operation, use the <see cref="CreateDirectoryTransacted"/> function.
        /// </para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createdirectoryexw
        /// </summary>
        /// <param name="lpTemplateDirectory">
        /// The path of the directory to use as a template when creating the new directory.
        /// In the ANSI version of this function, the name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="CreateDirectoryEx"/>),
        /// you can opt-in to remove the <see cref="Constants.MAX_PATH"/> character limitation without prepending "\\?\".
        /// The 255 character limit per path segment still applies.
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpNewDirectory">
        /// The path of the directory to be created.
        /// In the ANSI version of this function, the name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="CreateDirectoryEx"/>),
        /// you can opt-in to remove the <see cref="Constants.MAX_PATH"/> character limitation without prepending "\\?\".
        /// The 255 character limit per path segment still applies.
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// The <paramref name="lpSecurityAttributes"/> member of the structure specifies a security descriptor for the new directory.
        /// If <paramref name="lpSecurityAttributes"/> is null, the directory gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for this parameter to have an effect.
        /// This is indicated when <see cref="GetVolumeInformation"/> returns <see cref="FS_PERSISTENT_ACLS"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// Possible errors include the following.
        /// <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>: The specified directory already exists.
        /// <see cref="SystemErrorCodes.ERROR_PATH_NOT_FOUND"/>: One or more intermediate directories do not exist.
        /// This function only creates the final directory in the path.
        /// To create all intermediate directories on the path, use the <see cref="SHCreateDirectoryEx"/> function.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateDirectoryEx"/> function allows you to create directories that inherit stream information from other directories.
        /// This function is useful, for example, when you are using Macintosh directories,
        /// which have a resource stream that is needed to properly identify directory contents as an attribute.
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes formatted for such a file system, a new directory inherits the compression and encryption attributes of its parent directory.
        /// You can obtain a handle to a directory by calling the <see cref="CreateFile"/> function with
        /// the <see cref="FileFlags.FILE_FLAG_BACKUP_SEMANTICS"/> flag set.
        /// For a code example, see <see cref="CreateFile"/>.
        /// To support inheritance functions that query the security descriptor of this object can heuristically determine and report
        /// that inheritance is in effect. For more information, see Automatic Propagation of Inheritable ACEs.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDirectoryExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateDirectoryEx([MarshalAs(UnmanagedType.LPWStr)][In]string lpTemplateDirectory,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpNewDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Creates a new directory as a transacted operation, with the attributes of a specified template directory.
        /// If the underlying file system supports security on files and directories,
        /// the function applies a specified security descriptor to the new directory.
        /// The new directory retains the other attributes of the specified template directory.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createdirectorytransactedw
        /// </para>
        /// </summary>
        /// <param name="lpTemplateDirectory">
        /// The path of the directory to use as a template when creating the new directory. This parameter can be <see langword="null"/>.
        /// In the ANSI version of this function, the name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// The directory must reside on the local computer; otherwise, the function fails and
        /// the last error code is set to <see cref="SystemErrorCodes.ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="lpNewDirectory">
        /// The path of the directory to be created.
        /// In the ANSI version of this function, the name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// The <paramref name="lpSecurityAttributes"/> member of the structure specifies a security descriptor for the new directory.
        /// If <paramref name="lpSecurityAttributes"/> is <see langword="null"/>, the directory gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for this parameter to have an effect.
        /// This is indicated when <see cref="GetVolumeInformation"/> returns <see cref="FS_PERSISTENT_ACLS"/>.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// Possible errors include the following.
        /// <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>: The specified directory already exists.
        /// <see cref="SystemErrorCodes.ERROR_EFS_NOT_ALLOWED_IN_TRANSACTION"/>:
        /// You cannot create a child directory with a parent directory that has encryption disabled.
        /// <see cref="SystemErrorCodes.ERROR_PATH_NOT_FOUND"/>:
        /// One or more intermediate directories do not exist.
        /// This function only creates the final directory in the path.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateDirectoryTransacted"/> function allows you to create directories that inherit stream information from other directories.
        /// This function is useful, for example, when you are using Macintosh directories,
        /// which have a resource stream that is needed to properly identify directory contents as an attribute.
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes formatted for such a file system, a new directory inherits the compression and encryption attributes of its parent directory.
        /// This function fails with <see cref="SystemErrorCodes.ERROR_EFS_NOT_ALLOWED_IN_TRANSACTION"/> if you try to create a child directory
        /// with a parent directory that has encryption disabled.
        /// You can obtain a handle to a directory by calling the <see cref="CreateFileTransacted"/> function
        /// with the <see cref="FileFlags.FILE_FLAG_BACKUP_SEMANTICS"/> flag set.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDirectoryTransactedW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateDirectoryTransacted([MarshalAs(UnmanagedType.LPWStr)][In]string lpTemplateDirectory,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpNewDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes,
            IntPtr hTransaction);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed event object.
        /// To specify an access mask for the object, use the <see cref="CreateEventEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createeventw
        /// </para>
        /// </summary>
        /// <param name="lpEventAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new event.
        /// If <paramref name="lpEventAttributes"/> is <see cref="IntPtr.Zero"/>, the event gets a default security descriptor.
        /// The ACLs in the default security descriptor for an event come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="bManualReset">
        /// If this parameter is <see langword="true"/>, the function creates a manual-reset event object,
        /// which requires the use of the <see cref="ResetEvent"/> function to set the event state to nonsignaled.
        /// If this parameter is <see langword="false"/>, the function creates an auto-reset event object,
        /// and system automatically resets the event state to nonsignaled after a single waiting thread has been released.
        /// </param>
        /// <param name="bInitialState">
        /// If this parameter is <see langword="true"/>, the initial state of the event object is signaled; otherwise, it is nonsignaled.
        /// </param>
        /// <param name="lpName">
        /// The name of the event object. The name is limited to <see cref="Constants.MAX_PATH"/> characters. Name comparison is case sensitive.
        /// If <paramref name="lpName"/> matches the name of an existing named event object,
        /// this function requests the <see cref="EVENT_ALL_ACCESS"/> access right.
        /// In this case, the <paramref name="bManualReset"/> and <paramref name="bInitialState"/> parameters are ignored
        /// because they have already been set by the creating process.
        /// If the <paramref name="lpEventAttributes"/> parameter is not <see cref="IntPtr.Zero"/>,
        /// it determines whether the handle can be inherited, but its security-descriptor member is ignored.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the event object is created without a name.
        /// If <paramref name="lpName"/> matches the name of another kind of object in the same namespace
        /// (such as an existing semaphore, mutex, waitable timer, job, or file-mapping object),
        /// the function fails and the <see cref="Marshal.GetLastWin32Error"/> function returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace. For more information, see Object Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the event object.
        /// If the named event object existed before the function call, the function returns a handle to the existing object
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned by <see cref="CreateEvent"/> has the <see cref="EVENT_ALL_ACCESS"/> access right;
        /// it can be used in any function that requires a handle to an event object, provided that the caller has been granted access.
        /// If an event is created from a service or a thread that is impersonating a different user,
        /// you can either apply a security descriptor to the event when you create it,
        /// or change the default security descriptor for the creating process by changing its default DACL.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// Any thread of the calling process can specify the event-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// The initial state of the event object is specified by the bInitialState parameter.
        /// Use the <see cref="SetEvent"/> function to set the state of an event object to signaled.
        /// Use the <see cref="ResetEvent"/> function to reset the state of an event object to nonsignaled.
        /// When the state of a manual-reset event object is signaled, it remains signaled until it is explicitly reset
        /// to nonsignaled by the <see cref="ResetEvent"/> function.
        /// Any number of waiting threads, or threads that subsequently begin wait operations for the specified event object,
        /// can be released while the object's state is signaled.
        /// When the state of an auto-reset event object is signaled, it remains signaled until a single waiting thread is released;
        /// the system then automatically resets the state to nonsignaled.
        /// If no threads are waiting, the event object's state remains signaled.
        /// Multiple processes can have handles of the same event object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to an event object
        /// if the <paramref name="lpEventAttributes"/> parameter of <see cref="CreateEvent"/> enabled inheritance.
        /// A process can specify the event-object handle in a call to the <see cref="DuplicateHandle"/> function to create a duplicate handle
        /// that can be used by another process.
        /// A process can specify the name of an event object in a call to the <see cref="OpenEvent"/> or <see cref="CreateEvent"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The event object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEventW", SetLastError = true)]
        public static extern IntPtr CreateEvent(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpEventAttributes,
            [MarshalAs(UnmanagedType.Bool)][In]bool bManualReset, [MarshalAs(UnmanagedType.Bool)][In]bool bInitialState,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed event object and returns a handle to the object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createeventexw
        /// </para>
        /// </summary>
        /// <param name="lpEventAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If <paramref name="lpEventAttributes"/> is <see langword="null"/>, the event handle cannot be inherited by child processes.
        /// The <paramref name="lpEventAttributes"/> member of the structure specifies a security descriptor for the new event.
        /// If <paramref name="lpEventAttributes"/> is <see langword="null"/>, the event gets a default security descriptor.
        /// The ACLs in the default security descriptor for an event come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lpName">
        /// The name of the event object. The name is limited to <see cref="Constants.MAX_PATH"/> characters. Name comparison is case sensitive.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the event object is created without a name.
        /// If <paramref name="lpName"/> matches the name of another kind of object in the same namespace
        /// (such as an existing semaphore, mutex, waitable timer, job, or file-mapping object),
        /// the function fails and the <see cref="Marshal.GetLastWin32Error"/> function returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace. For more information, see Object Namespaces.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be one or more of the following values.
        /// <see cref="CreateEventExFlags.CREATE_EVENT_INITIAL_SET"/>, <see cref="CreateEventExFlags.CREATE_EVENT_MANUAL_RESET"/>
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access mask for the event object.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the event object.
        /// If the named event object existed before the function call, the function returns a handle to the existing object
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// Any thread of the calling process can specify the event-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// The initial state of the event object is specified by the dwFlags parameter.
        /// Use the <see cref="SetEvent"/> function to set the state of an event object to signaled.
        /// Use the <see cref="ResetEvent"/> function to reset the state of an event object to nonsignaled.
        /// When the state of a manual-reset event object is signaled, it remains signaled until it is explicitly reset
        /// to nonsignaled by the <see cref="ResetEvent"/> function.
        /// Any number of waiting threads, or threads that subsequently begin wait operations for the specified event object,
        /// can be released while the object's state is signaled.
        /// Multiple processes can have handles of the same event object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to an event object
        /// if the <paramref name="lpEventAttributes"/> parameter of <see cref="CreateEvent"/> enabled inheritance.
        /// A process can specify the event-object handle in a call to the <see cref="DuplicateHandle"/> function
        /// to create a duplicate handle that can be used by another process.
        /// A process can specify the name of an event object in a call to the <see cref="OpenEvent"/> or <see cref="CreateEvent"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The event object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEventExW", SetLastError = true)]
        public static extern IntPtr CreateEventEx(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpEventAttributes,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpName, [In]CreateEventExFlags dwFlags, [In]uint dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Creates or opens a file or I/O device.
        /// The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer,
        /// tape drive, communications resource, mailslot, and pipe.
        /// The function returns a handle that can be used to access the file or device for various types of I/O depending on
        /// the file or device and the flags and attributes specified.
        /// To perform this operation as a transacted operation, which results in a handle that can be used for transacted I/O,
        /// use the <see cref="CreateFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-createfilew
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file or device to be created or opened. You may use either forward slashes (/) or backslashes () in this name.
        /// In the ANSI version of this function, the name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming Files, Paths, and Namespaces.
        /// For information on special device names, see Defining an MS-DOS Device Name.
        /// To create a file stream, specify the name of the file, a colon, and then the name of the stream. 
        /// For more information, see File Streams.
        /// Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="CreateFile"/>),
        /// you can opt-in to remove the <see cref="Constants.MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The requested access to the file or device, which can be summarized as read, write, both or neither zero).
        /// The most commonly used values are <see cref="GenericAccessRights.GENERIC_READ"/>, <see cref="GenericAccessRights.GENERIC_WRITE"/>,
        /// or both (<see cref="GenericAccessRights.GENERIC_READ"/> | <see cref="GenericAccessRights.GENERIC_WRITE"/>).
        /// For more information, see Generic Access Rights, File Security and Access Rights, File Access Rights Constants, and ACCESS_MASK.
        /// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes
        /// without accessing that file or device, even if <see cref="GenericAccessRights.GENERIC_READ"/> access would have been denied.
        /// You cannot request an access mode that conflicts with the sharing mode that is specified by
        /// the <paramref name="dwShareMode"/> parameter in an open request that already has an open handle.
        /// For more information, see the Remarks section of this topic and Creating and Opening Files.
        /// </param>
        /// <param name="dwShareMode">
        /// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table).
        /// Access requests to attributes or extended attributes are not affected by this flag.
        /// If this parameter is zero and <see cref="CreateFile"/> succeeds,
        /// the file or device cannot be shared and cannot be opened again until the handle to the file or device is closed.
        /// For more information, see the Remarks section.
        /// You cannot request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open handle.
        /// <see cref="CreateFile"/> would fail and
        /// the <see cref="Marshal.GetLastWin32Error"/> function would return <see cref="SystemErrorCodes.ERROR_SHARING_VIOLATION"/>.
        /// To enable a process to share a file or device while another process has the file or device open,
        /// use a compatible combination of one or more of the following values.
        /// For more information about valid combinations of this parameter with the <paramref name="dwDesiredAccess"/> parameter,
        /// see Creating and Opening Files.
        /// The sharing options for each open handle remain in effect until that handle is closed, regardless of process context.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that contains two separate but related data members:
        /// an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes.
        /// The parameter can be <see langword="null"/>.
        /// If this parameter is <see langword="null"/>, the handle returned by <see cref="CreateFile"/> cannot be inherited
        /// by any child processes the application may create and the file or device associated with the returned handle
        /// gets a default security descriptor.
        /// The <paramref name="lpSecurityAttributes"/> member of the structure specifies a <see cref="SECURITY_DESCRIPTOR"/> for a file or device.
        /// If this member is <see langword="null"/>, the file or device associated with the returned handle is assigned a default security descriptor.
        /// <see cref="CreateFile"/> ignores the <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member when opening an existing file,
        /// but continues to use the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member.
        /// The <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of the structure specifies whether the returned handle can be inherited.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="dwCreationDisposition">
        /// An action to take on files that exist and do not exist.
        /// For devices other than files, this parameter is usually set to <see cref="FileCreationDispositions.OPEN_EXISTING"/>.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="dwFlagsAndAttributes">
        /// The file attributes and flags, <see cref="FileAttributes.FILE_ATTRIBUTE_NORMAL"/> being the most common default value.
        /// This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*).
        /// All other file attributes override <see cref="FileAttributes.FILE_ATTRIBUTE_NORMAL"/>.
        /// This parameter can also contain combinations of flags (FILE_FLAG_) for control of buffering behavior,
        /// access modes, and other special-purpose flags. These combine with any FILE_ATTRIBUTE_ values.
        /// This parameter can also contain Security Quality of Service (SQOS) information
        /// by specifying the <see cref="SECURITY_SQOS_PRESENT"/> flag.
        /// Additional SQOS-related flags information is presented in the table following the attributes and flags tables.
        /// When <see cref="CreateFile"/> opens an existing file, it generally combines the file flags with the file attributes of the existing file,
        /// and ignores any file attributes supplied as part of <paramref name="dwFlagsAndAttributes"/>.
        /// Special cases are detailed in Creating and Opening Files.
        /// Some of the following file attributes and flags may only apply to files and not necessarily all other types of devices 
        /// that <see cref="CreateFile"/> can open.
        /// For additional information, see the Remarks section of this topic and Creating and Opening Files.
        /// For more advanced access to file attributes, see <see cref="SetFileAttributes"/>.
        /// For a complete list of all file attributes with their values and descriptions, see File Attribute Constants.
        /// The <paramref name="lpSecurityAttributes"/> parameter can also specify SQOS information.
        /// For more information, see Impersonation Levels.
        /// When the calling application specifies the <see cref="SECURITY_SQOS_PRESENT"/> flag
        /// as part of <paramref name="dwFlagsAndAttributes"/>, it can also contain one or more of the following values.
        /// <see cref="SECURITY_ANONYMOUS"/>, <see cref="SECURITY_CONTEXT_TRACKING"/>, <see cref="SECURITY_DELEGATION"/>,
        /// <see cref="SECURITY_EFFECTIVE_ONLY"/>, <see cref="SECURITY_IDENTIFICATION"/>, <see cref="SECURITY_IMPERSONATION"/>
        /// </param>
        /// <param name="hTemplateFile">
        /// A valid handle to a template file with the <see cref="GenericAccessRights.GENERIC_READ"/> access right.
        /// The template file supplies file attributes and extended attributes for the file that is being created.
        /// This parameter can be <see cref="IntPtr.Zero"/>.
        /// When opening an existing file, <see cref="CreateFile"/> ignores the template file.
        /// When opening a new EFS-encrypted file, the file inherits the discretionary access control list from its parent directory.
        /// For additional information, see File Encryption.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="CreateFile"/> was originally developed specifically for file interaction
        /// but has since been expanded and enhanced to include most other types of I/O devices and mechanisms available to Windows developers.
        /// This section attempts to cover the varied issues developers may experience
        /// when using <see cref="CreateFile"/> in different contexts and with different I/O types.
        /// The text attempts to use the word file only when referring specifically to data stored in an actual file on a file system.
        /// However, some uses of file may be referring more generally to an I/O object that supports file-like mechanisms.
        /// This liberal use of the term file is particularly prevalent in constant names and parameter names because of
        /// the previously mentioned historical reasons.
        /// When an application is finished using the object handle returned by <see cref="CreateFile"/>,
        /// use the <see cref="CloseHandle"/> function to close the handle.
        /// This not only frees up system resources, but can have wider influence on things like sharing the file or device and committing data to disk.
        /// Specifics are noted within this topic as appropriate.
        /// Windows Server 2003 and Windows XP:
        /// A sharing violation occurs if an attempt is made to open a file or directory for deletion on a remote computer
        /// when the value of the <paramref name="dwDesiredAccess"/> parameter is the <see cref="StandardAccessRights.DELETE"/> access flag (0x00010000)
        /// OR'ed with any other access flag, and the remote file or directory has not been opened with <see cref="FileShareModes.FILE_SHARE_DELETE"/>.
        /// To avoid the sharing violation in this scenario, open the remote file or directory
        /// with the <see cref="StandardAccessRights.DELETE"/> access right only,
        /// or call <see cref="DeleteFile"/> without first opening the file or directory for deletion.
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes that have a mounted file system with this support, a new file inherits the compression and encryption attributes of its directory.
        /// You cannot use <see cref="CreateFile"/> to control compression, decompression, or decryption on a file or directory.
        /// For more information, see Creating and Opening Files, File Compression and Decompression, and File Encryption.
        /// Windows Server 2003 and Windows XP:
        /// For backward compatibility purposes, <see cref="CreateFile"/> does not apply inheritance rules when you specify 
        /// a security descriptor in <paramref name="lpSecurityAttributes"/>.
        /// To support inheritance, functions that later query the security descriptor of this file may heuristically determine 
        /// and report that inheritance is in effect.
        /// For more information, see Automatic Propagation of Inheritable ACEs.
        /// As stated previously, if the <paramref name="lpSecurityAttributes"/> parameter is <see langword="null"/>,
        /// the handle returned by <see cref="CreateFile"/> cannot be inherited by any child processes your application may create.
        /// The following information regarding this parameter also applies:
        /// If the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member variable is not <see langword="false"/>, which is any nonzero value,
        /// then the handle can be inherited.
        /// Therefore it is critical this structure member be properly initialized to <see langword="false"/> if you do not intend
        /// the handle to be inheritable.
        /// The access control lists(ACL) in the default security descriptor for a file or directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for the lpSecurityDescriptor member to have an effect on them,
        /// which can be determined by using <see cref="GetVolumeInformation"/>.
        /// Note that <see cref="CreateFile"/> with supersede disposition will fail
        /// if performed on a file where there is already an open alternate data stream.
        /// Symbolic Link Behavior
        /// If the call to this function creates a file, there is no change in behavior.
        /// Also, consider the following information regarding <see cref="FileFlags.FILE_FLAG_OPEN_REPARSE_POINT"/>:
        /// If <see cref="FileFlags.FILE_FLAG_OPEN_REPARSE_POINT"/> is specified:
        /// If an existing file is opened and it is a symbolic link, the handle returned is a handle to the symbolic link.
        /// If <see cref="FileCreationDispositions.TRUNCATE_EXISTING"/> or <see cref="FileFlags.FILE_FLAG_DELETE_ON_CLOSE"/> are specified,
        /// the file affected is a symbolic link.
        /// If <see cref="FileFlags.FILE_FLAG_OPEN_REPARSE_POINT"/> is not specified:
        /// If an existing file is opened and it is a symbolic link, the handle returned is a handle to the target.
        /// If <see cref="FileCreationDispositions.CREATE_ALWAYS"/>, <see cref="FileCreationDispositions.TRUNCATE_EXISTING"/>,
        /// or <see cref="FileFlags.FILE_FLAG_DELETE_ON_CLOSE"/> are specified, the file affected is the target.
        /// Caching Behavior
        /// Several of the possible values for the <paramref name="dwFlagsAndAttributes"/> parameter are used by <see cref="CreateFile"/>
        /// to control or affect how the data associated with the handle is cached by the system. They are:
        /// <see cref="FileFlags.FILE_FLAG_NO_BUFFERING"/>, <see cref="FileFlags.FILE_FLAG_RANDOM_ACCESS"/>,
        /// <see cref="FileFlags.FILE_FLAG_SEQUENTIAL_SCAN"/>, <see cref="FileFlags.FILE_FLAG_WRITE_THROUGH"/>,
        /// <see cref="FileAttributes.FILE_ATTRIBUTE_TEMPORARY"/>.
        /// If none of these flags is specified, the system uses a default general-purpose caching scheme.
        /// Otherwise, the system caching behaves as specified for each flag.
        /// Some of these flags should not be combined.
        /// For instance, combining <see cref="FileFlags.FILE_FLAG_RANDOM_ACCESS"/> with <see cref="FileFlags.FILE_FLAG_SEQUENTIAL_SCAN"/> is self-defeating.
        /// Specifying the <see cref="FileFlags.FILE_FLAG_SEQUENTIAL_SCAN"/> flag can increase performance for applications
        /// that read large files using sequential access.
        /// Performance gains can be even more noticeable for applications that read large files mostly sequentially,
        /// but occasionally skip forward over small ranges of bytes.
        /// If an application moves the file pointer for random access, optimum caching performance most likely will not occur.
        /// However, correct operation is still guaranteed.
        /// The flags <see cref="FileFlags.FILE_FLAG_WRITE_THROUGH"/> and <see cref="FileFlags.FILE_FLAG_NO_BUFFERING"/> are independent and may be combined.
        /// If <see cref="FileFlags.FILE_FLAG_WRITE_THROUGH"/> is used but <see cref="FileFlags.FILE_FLAG_NO_BUFFERING"/> is not also specified,
        /// so that system caching is in effect, then the data is written to the system cache but is flushed to disk without delay.
        /// If <see cref="FileFlags.FILE_FLAG_WRITE_THROUGH"/> and <see cref="FileFlags.FILE_FLAG_NO_BUFFERING"/> are both specified,
        /// so that system caching is not in effect, then the data is immediately flushed to disk without going through the Windows system cache.
        /// The operating system also requests a write-through of the hard disk's local hardware cache to persistent media.
        /// Not all hard disk hardware supports this write-through capability.
        /// Proper use of the <see cref="FileFlags.FILE_FLAG_NO_BUFFERING"/> flag requires special application considerations.
        /// For more information, see File Buffering.
        /// A write-through request via <see cref="FileFlags.FILE_FLAG_WRITE_THROUGH"/> also causes NTFS to flush any metadata changes,
        /// such as a time stamp update or a rename operation, that result from processing the request.
        /// For this reason, the <see cref="FileFlags.FILE_FLAG_WRITE_THROUGH"/> flag is often used with 
        /// the <see cref="FileFlags.FILE_FLAG_NO_BUFFERING"/> flag as a replacement for
        /// calling the <see cref="FlushFileBuffers"/> function after each write, which can cause unnecessary performance penalties.
        /// Using these flags together avoids those penalties.
        /// For general information about the caching of files and metadata, see File Caching.
        /// When <see cref="FileFlags.FILE_FLAG_NO_BUFFERING"/> is combined with <see cref="FileFlags.FILE_FLAG_OVERLAPPED"/>,
        /// the flags give maximum asynchronous performance, because the I/O does not rely on the synchronous operations of the memory manager.
        /// However, some I/O operations take more time, because data is not being held in the cache.
        /// Also, the file metadata may still be cached (for example, when creating an empty file).
        /// To ensure that the metadata is flushed to disk, use the <see cref="FlushFileBuffers"/> function.
        /// Specifying the <see cref="FileAttributes.FILE_ATTRIBUTE_TEMPORARY"/> attribute causes file systems to
        /// avoid writing data back to mass storage if sufficient cache memory is available,
        /// because an application deletes a temporary file after a handle is closed.
        /// In that case, the system can entirely avoid writing the data.
        /// Although it does not directly control data caching in the same way as the previously mentioned flags,
        /// the <see cref="FileAttributes.FILE_ATTRIBUTE_TEMPORARY"/> attribute does tell the system to hold as much as possible
        /// in the system cache without writing and therefore may be of concern for certain applications.
        /// Files
        /// If you rename or delete a file and then restore it shortly afterward, the system searches the cache for file information to restore.
        /// Cached information includes its short/long name pair and creation time.
        /// If you call <see cref="CreateFile"/> on a file that is pending deletion as a result of
        /// a previous call to <see cref="DeleteFile"/>, the function fails.
        /// The operating system delays file deletion until all handles to the file are closed.
        /// <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// The <paramref name="dwDesiredAccess"/> parameter can be zero, allowing the application to query file attributes
        /// without accessing the file if the application is running with adequate security settings.
        /// This is useful to test for the existence of a file without opening it for read and/or write access,
        /// or to obtain other statistics about the file or directory.
        /// See Obtaining and Setting File Information and <see cref="GetFileInformationByHandle"/>.
        /// If <see cref="FileCreationDispositions.CREATE_ALWAYS"/> and <see cref="FileAttributes.FILE_ATTRIBUTE_NORMAL"/> are specified,
        /// <see cref="CreateFile"/> fails and sets the last error to <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/> if the file exists
        /// and has the <see cref="FileAttributes.FILE_ATTRIBUTE_HIDDEN"/> or <see cref="FileAttributes.FILE_ATTRIBUTE_SYSTEM"/> attribute.
        /// To avoid the error, specify the same attributes as the existing file.
        /// When an application creates a file across a network, it is better to use <code>GENERIC_READ | GENERIC_WRITE</code>
        /// for <paramref name="dwDesiredAccess"/> than to use <see cref="GenericAccessRights.GENERIC_WRITE"/> alone.
        /// The resulting code is faster, because the redirector can use the cache manager and send fewer SMBs with more data.
        /// This combination also avoids an issue where writing to a file across a network
        /// can occasionally return <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// For more information, see Creating and Opening Files.
        /// Synchronous and Asynchronous I/O Handles
        /// <see cref="CreateFile"/> provides for creating a file or device handle that is either synchronous or asynchronous.
        /// A synchronous handle behaves such that I/O function calls using that handle are blocked until they complete,
        /// while an asynchronous file handle makes it possible for the system to return immediately from I/O function calls,
        /// whether they completed the I/O operation or not.
        /// As stated previously, this synchronous versus asynchronous behavior is determined
        /// by specifying <see cref="FileFlags.FILE_FLAG_OVERLAPPED"/> within the <paramref name="dwFlagsAndAttributes"/> parameter.
        /// There are several complexities and potential pitfalls when using asynchronous I/O;
        /// for more information, see Synchronous and Asynchronous I/O.
        /// File Streams
        /// On NTFS file systems, you can use <see cref="CreateFile"/> to create separate streams within a file.
        /// For more information, see File Streams.
        /// Directories
        /// An application cannot create a directory by using <see cref="CreateFile"/>, therefore only
        /// the <see cref="FileCreationDispositions.OPEN_EXISTING"/> value is valid for <paramref name="dwCreationDisposition"/> for this use case.
        /// To create a directory, the application must call <see cref="CreateDirectory"/> or <see cref="CreateDirectoryEx"/>.
        /// To open a directory using <see cref="CreateFile"/>, specify the <see cref="FileFlags.FILE_FLAG_BACKUP_SEMANTICS"/> flag
        /// as part of <paramref name="dwFlagsAndAttributes"/>.
        /// Appropriate security checks still apply when this flag is used
        /// without <see cref="SE_BACKUP_NAME"/> and <see cref="SE_RESTORE_NAME"/> privileges.
        /// When using <see cref="CreateFile"/> to open a directory during defragmentation of a FAT or FAT32 file system volume,
        /// do not specify the <see cref="MAXIMUM_ALLOWED"/> access right.
        /// Access to the directory is denied if this is done.
        /// Specify the <see cref="GenericAccessRights.GENERIC_READ"/> access right instead.
        /// For more information, see About Directory Management.
        /// Physical Disks and Volumes
        /// Direct access to the disk or to a volume is restricted.
        /// For more information, see "Changes to the file system and to the storage stack to restrict direct disk access
        /// and direct volume access in Windows Vista and in Windows Server 2008" in the Help and Support Knowledge Base
        /// at http://support.microsoft.com/kb/942448.
        /// Windows Server 2003 and Windows XP:  Direct access to the disk or to a volume is not restricted in this manner.
        /// You can use the <see cref="CreateFile"/> function to open a physical disk drive or a volume,
        /// which returns a direct access storage device (DASD) handle that can be used with the <see cref="DeviceIoControl"/> function.
        /// This enables you to access the disk or volume directly, for example such disk metadata as the partition table.
        /// However, this type of access also exposes the disk drive or volume to potential data loss,
        /// because an incorrect write to a disk using this mechanism could make its contents inaccessible to the operating system.
        /// To ensure data integrity, be sure to become familiar with <see cref="DeviceIoControl"/> and how other APIs behave differently
        /// with a direct access handle as opposed to a file system handle.
        /// The following requirements must be met for such a call to succeed:
        /// The caller must have administrative privileges. For more information, see Running with Special Privileges.
        /// The <paramref name="dwCreationDisposition"/> parameter must have the <see cref="FileCreationDispositions.OPEN_EXISTING"/> flag.
        /// When opening a volume or floppy disk, the <paramref name="dwShareMode"/> parameter must have
        /// the <see cref="FileShareModes.FILE_SHARE_WRITE"/> flag.
        /// The <paramref name="dwDesiredAccess"/> parameter can be zero, allowing the application to query device attributes without accessing a device.
        /// This is useful for an application to determine the size of a floppy disk drive and the formats it supports
        /// without requiring a floppy disk in a drive, for instance.
        /// It can also be used for reading statistics without requiring higher-level data read/write permission.
        /// When opening a physical drive x:, the lpFileName string should be the following form: "\\.\PhysicalDriveX".
        /// Hard disk numbers start at zero. The following table shows some examples of physical drive strings.
        /// "\\.\PhysicalDrive0": Opens the first physical drive.
        /// "\\.\PhysicalDrive2": Opens the third physical drive.
        /// To obtain the physical drive identifier for a volume, open a handle to the volume and
        /// call the <see cref="DeviceIoControl"/> function with <see cref="IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS"/>.
        /// This control code returns the disk number and offset for each of the volume's one or more extents; a volume can span multiple physical disks.
        /// For an example of opening a physical drive, see Calling DeviceIoControl.
        /// When opening a volume or removable media drive (for example, a floppy disk drive or flash memory thumb drive),
        /// the <paramref name="lpFileName"/> string should be the following form: "\.&lt;i&gt;X:".
        /// Do not use a trailing backslash (), which indicates the root directory of a drive.
        /// The following table shows some examples of drive strings.
        /// "\\.\A:": Opens floppy disk drive A.
        /// "\\.\C:": Opens the C: volume.
        /// "\\.\C:\": Opens the file system of the C: volume.
        /// You can also open a volume by referring to its volume name. For more information, see Naming a Volume.
        /// A volume contains one or more mounted file systems.
        /// Volume handles can be opened as noncached at the discretion of the particular file system,
        /// even when the noncached option is not specified in <see cref="CreateFile"/>.
        /// You should assume that all Microsoft file systems open volume handles as noncached.
        /// The restrictions on noncached I/O for files also apply to volumes.
        /// A file system may or may not require buffer alignment even though the data is noncached.
        /// However, if the noncached option is specified when opening a volume, buffer alignment is enforced regardless of the file system on the volume.
        /// It is recommended on all file systems that you open volume handles as noncached, and follow the noncached I/O restrictions.
        /// To read or write to the last few sectors of the volume, you must call <see cref="DeviceIoControl"/> and
        /// specify <see cref="FSCTL_ALLOW_EXTENDED_DASD_IO"/>.
        /// This signals the file system driver not to perform any I/O boundary checks on partition read or write calls.
        /// Instead, boundary checks are performed by the device driver.
        /// Changer Device
        /// The IOCTL_CHANGER_* control codes for <see cref="DeviceIoControl"/> accept a handle to a changer device.
        /// To open a changer device, use a file name of the following form: "\\.\Changerx" where x is a number
        /// that indicates which device to open, starting with zero.
        /// To open changer device zero in an application that is written in C or C++, use the following file name: "\\\\.\\Changer0".
        /// Tape Drives
        /// You can open tape drives by using a file name of the following form: "\\.\TAPEx" where x is a number 
        /// that indicates which drive to open, starting with tape drive zero.
        /// To open tape drive zero in an application that is written in C or C++, use the following file name: "\\\\.\\TAPE0".
        /// For more information, see Backup.
        /// Communications Resources
        /// The <see cref="CreateFile"/> function can create a handle to a communications resource, such as the serial port COM1.
        /// For communications resources, the <paramref name="dwCreationDisposition"/> parameter must
        /// be <see cref="FileCreationDispositions.OPEN_EXISTING"/>, the <paramref name="dwShareMode"/> parameter must be zero (exclusive access),
        /// and the <paramref name="hTemplateFile"/> parameter must be <see cref="IntPtr.Zero"/>.
        /// Read, write, or read/write access can be specified, and the handle can be opened for overlapped I/O.
        /// To specify a COM port number greater than 9, use the following syntax: "\.\COM10".
        /// This syntax works for all port numbers and hardware that allows COM port numbers to be specified.
        /// For more information about communications, see Communications.
        /// Consoles
        /// The <see cref="CreateFile"/> function can create a handle to console input (CONIN$).
        /// If the process has an open handle to it as a result of inheritance or duplication,
        /// it can also create a handle to the active screen buffer (CONOUT$).
        /// The calling process must be attached to an inherited console or one allocated by the <see cref="AllocConsole"/> function.
        /// For console handles, set the <see cref="CreateFile"/> parameters as follows.
        /// <paramref name="lpFileName"/>: 
        /// Use the CONIN$ value to specify console input.
        /// Use the CONOUT$ value to specify console output.
        /// CONIN$ gets a handle to the console input buffer, even if the <see cref="SetStdHandle"/> function redirects the standard input handle.
        /// To get the standard input handle, use the <see cref="GetStdHandle"/> function.
        /// CONOUT$ gets a handle to the active screen buffer, even if <see cref="SetStdHandle"/> redirects the standard output handle.
        /// To get the standard output handle, use <see cref="GetStdHandle"/>.
        /// <paramref name="dwDesiredAccess"/>: <code>GENERIC_READ | GENERIC_WRITE</code> is preferred, but either one can limit access.
        /// <paramref name="dwShareMode"/>: 
        /// When opening CONIN$, specify <see cref="FileShareModes.FILE_SHARE_READ"/>.
        /// When opening CONOUT$, specify <see cref="FileShareModes.FILE_SHARE_WRITE"/>.
        /// If the calling process inherits the console, or if a child process should be able to access the console,
        /// this parameter must be <code>FILE_SHARE_READ | FILE_SHARE_WRITE</code>.
        /// <paramref name="lpSecurityAttributes"/>:
        /// If you want the console to be inherited, the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of
        /// the <see cref="SECURITY_ATTRIBUTES"/> structure must be <see langword="true"/>.
        /// <paramref name="dwCreationDisposition"/>:
        /// You should specify <see cref="FileCreationDispositions.OPEN_EXISTING"/> when using <see cref="CreateFile"/> to open the console.
        /// <paramref name="dwFlagsAndAttributes"/>: Ignored.
        /// <paramref name="hTemplateFile"/>: Ignored.
        /// The following table shows various settings of <paramref name="dwDesiredAccess"/> and <paramref name="lpFileName"/>.
        /// "CON" <see cref="GenericAccessRights.GENERIC_READ"/> Opens console for input.
        /// "CON" <see cref="GenericAccessRights.GENERIC_WRITE"/> Opens console for output.
        /// "CON" <see cref="GenericAccessRights.GENERIC_READ"/> | <see cref="GenericAccessRights.GENERIC_WRITE"/>
        /// Causes <see cref="CreateFile"/> to fail; <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_FILE_NOT_FOUND"/>.
        /// Mailslots
        /// If <see cref="CreateFile"/> opens the client end of a mailslot, the function returns <see cref="INVALID_HANDLE_VALUE"/>
        /// if the mailslot client attempts to open a local mailslot before the mailslot server has created it with the <see cref="CreateMailslot"/> function.
        /// For more information, see Mailslots.
        /// Pipes
        /// If <see cref="CreateFile"/> opens the client end of a named pipe,
        /// the function uses any instance of the named pipe that is in the listening state.
        /// The opening process can duplicate the handle as many times as required, but after it is opened,
        /// the named pipe instance cannot be opened by another client.
        /// The access that is specified when a pipe is opened must be compatible with the access that is specified
        /// in the dwOpenModeparameter of the <see cref="CreateNamedPipe"/> function.
        /// If the <see cref="CreateNamedPipe"/> function was not successfully called on the server prior to this operation,
        /// a pipe will not exist and <see cref="CreateFile"/> will fail with <see cref="SystemErrorCodes.ERROR_FILE_NOT_FOUND"/>.
        /// If there is at least one active pipe instance but there are no available listener pipes on the server,
        /// which means all pipe instances are currently connected, CreateFile fails with <see cref="SystemErrorCodes.ERROR_PIPE_BUSY"/>.
        /// For more information, see Pipes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFile", SetLastError = true)]
        public static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPWStr)] [In] string lpFileName, [In]FileAccessRights dwDesiredAccess,
            [In]FileShareModes dwShareMode,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes,
            [In]FileCreationDispositions dwCreationDisposition, [In]uint dwFlagsAndAttributes, [In]IntPtr hTemplateFile);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed file mapping object for a specified file.
        /// To specify the NUMA node for the physical memory, see <see cref="CreateFileMappingNuma"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-createfilemappingw
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file from which to create a file mapping object.
        /// The file must be opened with access rights that are compatible with the protection flags
        /// that the <paramref name="flProtect"/> parameter specifies.
        /// It is not required, but it is recommended that files you intend to map be opened for exclusive access.
        /// For more information, see File Security and Access Rights.
        /// If hFile is <see cref="Constants.INVALID_HANDLE_VALUE"/>, the calling process must also specify a size for the file mapping object
        /// in the <paramref name="dwMaximumSizeHigh"/> and <paramref name="dwMaximumSizeLow"/> parameters.
        /// In this scenario, <see cref="CreateFileMapping"/> creates a file mapping object of a specified size
        /// that is backed by the system paging file instead of by a file in the file system.
        /// </param>
        /// <param name="lpFileMappingAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether a returned handle can be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the <see cref="SECURITY_ATTRIBUTES"/> structure
        /// specifies a security descriptor for a new file mapping object.
        /// If <paramref name="lpFileMappingAttributes"/> is <see langword="null"/>, the handle cannot be inherited
        /// and the file mapping object gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a file mapping object come from the primary
        /// or impersonation token of the creator.
        /// For more information, see File Mapping Security and Access Rights.
        /// </param>
        /// <param name="flProtect">
        /// Specifies the page protection of the file mapping object.
        /// All mapped views of the object must be compatible with this protection.
        /// This parameter can be one of the following values.
        /// <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READ"/> :
        /// Allows views to be mapped for read-only, copy-on-write, or execute access.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/> and <see cref="GenericAccessRights.GENERIC_WRITE"/> access rights.
        /// Windows Server 2003 and Windows XP:  This value is not available until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READWRITE"/>:
        /// Allows views to be mapped for read-only, copy-on-write, read/write, or execute access.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/>, <see cref="GenericAccessRights.GENERIC_WRITE"/>,
        /// and <see cref="GenericAccessRights.GENERIC_EXECUTE"/> access rights.
        /// Windows Server 2003 and Windows XP:  This value is not available until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// <see cref="MemoryProtectionConstants.PAGE_EXECUTE_WRITECOPY"/>:
        /// Allows views to be mapped for read-only, copy-on-write, or execute access.
        /// This value is equivalent to <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READ"/>.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/> and <see cref="GenericAccessRights.GENERIC_WRITE"/> access rights.
        /// Windows Vista:  This value is not available until Windows Vista with SP1.
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// <see cref="MemoryProtectionConstants.PAGE_READONLY"/>:
        /// Allows views to be mapped for read-only or copy-on-write access.
        /// An attempt to write to a specific region results in an access violation.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/> access right.
        /// <see cref="MemoryProtectionConstants.PAGE_READWRITE"/>:
        /// Allows views to be mapped for read-only, copy-on-write, or read/write access.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/> and <see cref="GenericAccessRights.GENERIC_WRITE"/> access rights.
        /// <see cref="MemoryProtectionConstants.PAGE_WRITECOPY"/>:
        /// Allows views to be mapped for read-only or copy-on-write access.
        /// This value is equivalent to <see cref="MemoryProtectionConstants.PAGE_READONLY"/>.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/> access right.
        /// An application can specify one or more of the following attributes for the file mapping object by combining them
        /// with one of the preceding page protection values.
        /// <see cref="SectionAttributes.SEC_COMMIT"/>:
        /// If the file mapping object is backed by the operating system paging file 
        /// (the <paramref name="hFile"/> parameter is <see cref="Constants.INVALID_HANDLE_VALUE"/>),
        /// specifies that when a view of the file is mapped into a process address space,
        /// the entire range of pages is committed rather than reserved.
        /// The system must have enough committable pages to hold the entire mapping.
        /// Otherwise, <see cref="CreateFileMapping"/> fails.
        /// This attribute has no effect for file mapping objects that are backed by executable image files or data files 
        /// (the <paramref name="hFile"/> parameter is a handle to a file).
        /// <see cref="SectionAttributes.SEC_COMMIT"/> cannot be combined with <see cref="SectionAttributes.SEC_RESERVE"/>.
        /// <see cref="SectionAttributes.SEC_IMAGE"/>:
        /// Specifies that the file that the <paramref name="hFile"/> parameter specifies is an executable image file.
        /// The <see cref="SectionAttributes.SEC_IMAGE"/> attribute must be combined
        /// with a page protection value such as <see cref="MemoryProtectionConstants.PAGE_READONLY"/>.
        /// However, this page protection value has no effect on views of the executable image file.
        /// Page protection for views of an executable image file is determined by the executable file itself.
        /// No other attributes are valid with <see cref="SectionAttributes.SEC_IMAGE"/>.
        /// <see cref="SectionAttributes.SEC_IMAGE_NO_EXECUTE"/>:
        /// Specifies that the file that the hFile parameter specifies is an executable image file that will not be executed
        /// and the loaded image file will have no forced integrity checks run.
        /// Additionally, mapping a view of a file mapping object created with the <see cref="SectionAttributes.SEC_IMAGE_NO_EXECUTE"/> attribute
        /// will not invoke driver callbacks registered using the PsSetLoadImageNotifyRoutine kernel API.
        /// The <see cref="SectionAttributes.SEC_IMAGE_NO_EXECUTE"/> attribute must be combined
        /// with the <see cref="MemoryProtectionConstants.PAGE_READONLY"/> page protection value.
        /// No other attributes are valid with <see cref="SectionAttributes.SEC_IMAGE_NO_EXECUTE"/>.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported before Windows Server 2012 and Windows 8.
        /// <see cref="SectionAttributes.SEC_LARGE_PAGES"/>:
        /// Enables large pages to be used for file mapping objects that are backed by the operating system paging file
        /// (the <paramref name="hFile"/> parameter is <see cref="Constants.INVALID_HANDLE_VALUE"/>).
        /// This attribute is not supported for file mapping objects that are backed by executable image files or data files
        /// (the <paramref name="hFile"/> parameter is a handle to an executable image or data file).
        /// The maximum size of the file mapping object must be a multiple of the minimum size of a large page
        /// returned by the <see cref="GetLargePageMinimum"/> function.
        /// If it is not, <see cref="CreateFileMapping"/> fails.
        /// When mapping a view of a file mapping object created with <see cref="SectionAttributes.SEC_LARGE_PAGES"/>,
        /// the base address and view size must also be multiples of the minimum large page size.
        /// <see cref="SectionAttributes.SEC_LARGE_PAGES"/> requires the <see cref="SeLockMemoryPrivilege"/> privilege
        /// to be enabled in the caller's token.
        /// If <see cref="SectionAttributes.SEC_LARGE_PAGES"/> is specified, <see cref="SectionAttributes.SEC_COMMIT"/> must also be specified.
        /// Windows Server 2003:  This value is not supported until Windows Server 2003 with SP1.
        /// Windows XP:  This value is not supported.
        /// <see cref="SectionAttributes.SEC_NOCACHE"/>:
        /// Sets all pages to be non-cachable.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped with <see cref="SectionAttributes.SEC_NOCACHE"/>
        /// can result in an <see cref="EXCEPTION_ILLEGAL_INSTRUCTION"/> exception.
        /// <see cref="SectionAttributes.SEC_NOCACHE"/> requires either
        /// the <see cref="SectionAttributes.SEC_RESERVE"/> or <see cref="SectionAttributes.SEC_COMMIT"/> attribute to be set.
        /// <see cref="SectionAttributes.SEC_RESERVE"/>:
        /// If the file mapping object is backed by the operating system paging file
        /// (the <paramref name="hFile"/> parameter is <see cref="Constants.INVALID_HANDLE_VALUE"/>),
        /// specifies that when a view of the file is mapped into a process address space,
        /// the entire range of pages is reserved for later use by the process rather than committed.
        /// Reserved pages can be committed in subsequent calls to the <see cref="VirtualAlloc"/> function.
        /// After the pages are committed, they cannot be freed or decommitted with the <see cref="VirtualFree"/> function.
        /// This attribute has no effect for file mapping objects that are backed by executable image files or data files
        /// (the <paramref name="hFile"/> parameter is a handle to a file).
        /// <see cref="SectionAttributes.SEC_RESERVE"/> cannot be combined with <see cref="SectionAttributes.SEC_COMMIT"/>.
        /// <see cref="SectionAttributes.SEC_WRITECOMBINE"/>:
        /// Sets all pages to be write-combined.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped with <see cref="SectionAttributes.SEC_WRITECOMBINE"/>
        /// can result in an <see cref="EXCEPTION_ILLEGAL_INSTRUCTION"/> exception.
        /// <see cref="SectionAttributes.SEC_WRITECOMBINE"/> requires either
        /// the <see cref="SectionAttributes.SEC_RESERVE"/> or <see cref="SectionAttributes.SEC_COMMIT"/> attribute to be set.
        /// Windows Server 2003 and Windows XP:  This flag is not supported until Windows Vista.
        /// </param>
        /// <param name="dwMaximumSizeHigh">
        /// The high-order DWORD of the maximum size of the file mapping object.
        /// </param>
        /// <param name="dwMaximumSizeLow">
        /// The low-order DWORD of the maximum size of the file mapping object.
        /// If this parameter and <paramref name="dwMaximumSizeHigh"/> are 0 (zero),
        /// the maximum size of the file mapping object is equal to the current size of the file that <paramref name="hFile"/> identifies.
        /// An attempt to map a file with a length of 0 (zero) fails with an error code of <see cref="SystemErrorCodes.ERROR_FILE_INVALID"/>.
        /// Applications should test for files with a length of 0 (zero) and reject those files.
        /// </param>
        /// <param name="lpName">
        /// The name of the file mapping object.
        /// If this parameter matches the name of an existing mapping object,
        /// the function requests access to the object with the protection that <paramref name="flProtect"/> specifies.
        /// If this parameter is <see langword="null"/>, the file mapping object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, semaphore, mutex, waitable timer, or job object,
        /// the function fails, and the <see cref="Marshal.GetLastWin32Error"/> function returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// Creating a file mapping object in the global namespace from a session other than session zero
        /// requires the <see cref="SeCreateGlobalPrivilege"/> privilege.
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented by using Terminal Services sessions.
        /// The first user to log on uses session 0 (zero), the next user to log on uses session 1 (one), and so on.
        /// Kernel object names must follow the guidelines that are outlined for Terminal Services so that applications can support multiple users.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created file mapping object.
        /// If the object exists before the function call, the function returns a handle to the existing object (with its current size,
        /// not the specified size), and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// After a file mapping object is created, the size of the file must not exceed the size of the file mapping object;
        /// if it does, not all of the file contents are available for sharing.
        /// If an application specifies a size for the file mapping object that is larger than the size of the actual named file on disk
        /// and if the page protection allows write access (that is, the <paramref name="flProtect"/> parameter specifies
        /// <see cref="MemoryProtectionConstants.PAGE_READWRITE"/> or <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READWRITE"/>),
        /// then the file on disk is increased to match the specified size of the file mapping object.
        /// If the file is extended, the contents of the file between the old end of the file and the new end of the file are not guaranteed to be zero;
        /// the behavior is defined by the file system.
        /// If the file on disk cannot be increased, <see cref="CreateFileMapping"/> fails
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_DISK_FULL"/>.
        /// The initial contents of the pages in a file mapping object backed by the operating system paging file are 0 (zero).
        /// The handle that <see cref="CreateFileMapping"/> returns has full access to a new file mapping object,
        /// and can be used with any function that requires a handle to a file mapping object.
        /// Multiple processes can share a view of the same file by either using a single shared file mapping object
        /// or creating separate file mapping objects backed by the same file.
        /// A single file mapping object can be shared by multiple processes through inheriting the handle at process creation,
        /// duplicating the handle, or opening the file mapping object by name.
        /// For more information, see the <see cref="CreateProcess"/>, <see cref="DuplicateHandle"/> and <see cref="OpenFileMapping"/> functions.
        /// Creating a file mapping object does not actually map the view into a process address space.
        /// The <see cref="MapViewOfFile"/> and <see cref="MapViewOfFileEx"/> functions map a view of a file into a process address space.
        /// With one important exception, file views derived from any file mapping object that is backed by the same file are coherent
        /// or identical at a specific time.
        /// Coherency is guaranteed for views within a process and for views that are mapped by different processes.
        /// The exception is related to remote files.
        /// Although <see cref="CreateFileMapping"/> works with remote files, it does not keep them coherent.
        /// For example, if two computers both map a file as writable, and both change the same page, each computer only sees its own writes to the page.
        /// When the data gets updated on the disk, it is not merged.
        /// A mapped file and a file that is accessed by using the input and output (I/O) functions
        /// (<see cref="ReadFile"/> and <see cref="WriteFile"/>) are not necessarily coherent.
        /// Mapped views of a file mapping object maintain internal references to the object,
        /// and a file mapping object does not close until all references to it are released.
        /// Therefore, to fully close a file mapping object, an application must unmap all mapped views of the file mapping object
        /// by calling <see cref="UnmapViewOfFile"/> and close the file mapping object handle by calling <see cref="CloseHandle"/>.
        /// These functions can be called in any order.
        /// When modifying a file through a mapped view, the last modification timestamp may not be updated automatically.
        /// If required, the caller should use <see cref="SetFileTime"/> to set the timestamp.
        /// Creating a file mapping object in the global namespace from a session other than session zero
        /// requires the <see cref="SeCreateGlobalPrivilege"/> privilege.
        /// Note that this privilege check is limited to the creation of file mapping objects and does not apply to opening existing ones.
        /// For example, if a service or the system creates a file mapping object in the global namespace, any process running
        /// in any session can access that file mapping object provided that the caller has the required access rights.
        /// Windows XP:  The requirement described in the previous paragraph was introduced with Windows Server 2003 and Windows XP with SP2
        /// Use structured exception handling to protect any code that writes to or reads from a file view.
        /// For more information, see Reading and Writing From a File View.
        /// To have a mapping with executable permissions, an application must call <see cref="CreateFileMapping"/> with
        /// either <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READWRITE"/> or <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READ"/>,
        /// and then call <see cref="MapViewOfFile"/> with <see cref="FILE_MAP_EXECUTE"/> | <see cref="FILE_MAP_WRITE"/>
        /// or <see cref="FILE_MAP_EXECUTE"/> | <see cref="FILE_MAP_READ"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFileMappingW", SetLastError = true)]
        public static extern IntPtr CreateFileMapping([In]IntPtr hFile,
             [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpFileMappingAttributes,
             [In]uint flProtect, [In]uint dwMaximumSizeHigh, [In]uint dwMaximumSizeLow, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed file mapping object for a specified file and specifies the NUMA node for the physical memory.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-createfilemappingnumaw
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file from which to create a file mapping object.
        /// The file must be opened with access rights that are compatible with the protection flags
        /// that the <paramref name="flProtect"/> parameter specifies.
        /// It is not required, but it is recommended that files you intend to map be opened for exclusive access.
        /// For more information, see File Security and Access Rights.
        /// If hFile is <see cref="Constants.INVALID_HANDLE_VALUE"/>, the calling process must also specify a size for the file mapping object
        /// in the <paramref name="dwMaximumSizeHigh"/> and <paramref name="dwMaximumSizeLow"/> parameters.
        /// In this scenario, <see cref="CreateFileMapping"/> creates a file mapping object of a specified size
        /// that is backed by the system paging file instead of by a file in the file system.
        /// </param>
        /// <param name="lpFileMappingAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether a returned handle can be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the <see cref="SECURITY_ATTRIBUTES"/> structure
        /// specifies a security descriptor for a new file mapping object.
        /// If <paramref name="lpFileMappingAttributes"/> is <see langword="null"/>, the handle cannot be inherited
        /// and the file mapping object gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a file mapping object come from the primary
        /// or impersonation token of the creator.
        /// For more information, see File Mapping Security and Access Rights.
        /// </param>
        /// <param name="flProtect">
        /// Specifies the page protection of the file mapping object.
        /// All mapped views of the object must be compatible with this protection.
        /// This parameter can be one of the following values.
        /// <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READ"/> :
        /// Allows views to be mapped for read-only, copy-on-write, or execute access.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/> and <see cref="GenericAccessRights.GENERIC_WRITE"/> access rights.
        /// Windows Server 2003 and Windows XP:  This value is not available until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READWRITE"/>:
        /// Allows views to be mapped for read-only, copy-on-write, read/write, or execute access.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/>, <see cref="GenericAccessRights.GENERIC_WRITE"/>,
        /// and <see cref="GenericAccessRights.GENERIC_EXECUTE"/> access rights.
        /// Windows Server 2003 and Windows XP:  This value is not available until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// <see cref="MemoryProtectionConstants.PAGE_EXECUTE_WRITECOPY"/>:
        /// Allows views to be mapped for read-only, copy-on-write, or execute access.
        /// This value is equivalent to <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READ"/>.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/> and <see cref="GenericAccessRights.GENERIC_WRITE"/> access rights.
        /// Windows Vista:  This value is not available until Windows Vista with SP1.
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// <see cref="MemoryProtectionConstants.PAGE_READONLY"/>:
        /// Allows views to be mapped for read-only or copy-on-write access.
        /// An attempt to write to a specific region results in an access violation.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/> access right.
        /// <see cref="MemoryProtectionConstants.PAGE_READWRITE"/>:
        /// Allows views to be mapped for read-only, copy-on-write, or read/write access.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/> and <see cref="GenericAccessRights.GENERIC_WRITE"/> access rights.
        /// <see cref="MemoryProtectionConstants.PAGE_WRITECOPY"/>:
        /// Allows views to be mapped for read-only or copy-on-write access.
        /// This value is equivalent to <see cref="MemoryProtectionConstants.PAGE_READONLY"/>.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GenericAccessRights.GENERIC_READ"/> access right.
        /// An application can specify one or more of the following attributes for the file mapping object by combining them
        /// with one of the preceding page protection values.
        /// <see cref="SectionAttributes.SEC_COMMIT"/>:
        /// If the file mapping object is backed by the operating system paging file 
        /// (the <paramref name="hFile"/> parameter is <see cref="Constants.INVALID_HANDLE_VALUE"/>),
        /// specifies that when a view of the file is mapped into a process address space,
        /// the entire range of pages is committed rather than reserved.
        /// The system must have enough committable pages to hold the entire mapping.
        /// Otherwise, <see cref="CreateFileMapping"/> fails.
        /// This attribute has no effect for file mapping objects that are backed by executable image files or data files 
        /// (the <paramref name="hFile"/> parameter is a handle to a file).
        /// <see cref="SectionAttributes.SEC_COMMIT"/> cannot be combined with <see cref="SectionAttributes.SEC_RESERVE"/>.
        /// <see cref="SectionAttributes.SEC_IMAGE"/>:
        /// Specifies that the file that the <paramref name="hFile"/> parameter specifies is an executable image file.
        /// The <see cref="SectionAttributes.SEC_IMAGE"/> attribute must be combined
        /// with a page protection value such as <see cref="MemoryProtectionConstants.PAGE_READONLY"/>.
        /// However, this page protection value has no effect on views of the executable image file.
        /// Page protection for views of an executable image file is determined by the executable file itself.
        /// No other attributes are valid with <see cref="SectionAttributes.SEC_IMAGE"/>.
        /// <see cref="SectionAttributes.SEC_IMAGE_NO_EXECUTE"/>:
        /// Specifies that the file that the hFile parameter specifies is an executable image file that will not be executed
        /// and the loaded image file will have no forced integrity checks run.
        /// Additionally, mapping a view of a file mapping object created with the <see cref="SectionAttributes.SEC_IMAGE_NO_EXECUTE"/> attribute
        /// will not invoke driver callbacks registered using the PsSetLoadImageNotifyRoutine kernel API.
        /// The <see cref="SectionAttributes.SEC_IMAGE_NO_EXECUTE"/> attribute must be combined
        /// with the <see cref="MemoryProtectionConstants.PAGE_READONLY"/> page protection value.
        /// No other attributes are valid with <see cref="SectionAttributes.SEC_IMAGE_NO_EXECUTE"/>.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported before Windows Server 2012 and Windows 8.
        /// <see cref="SectionAttributes.SEC_LARGE_PAGES"/>:
        /// Enables large pages to be used for file mapping objects that are backed by the operating system paging file
        /// (the <paramref name="hFile"/> parameter is <see cref="Constants.INVALID_HANDLE_VALUE"/>).
        /// This attribute is not supported for file mapping objects that are backed by executable image files or data files
        /// (the <paramref name="hFile"/> parameter is a handle to an executable image or data file).
        /// The maximum size of the file mapping object must be a multiple of the minimum size of a large page
        /// returned by the <see cref="GetLargePageMinimum"/> function.
        /// If it is not, <see cref="CreateFileMapping"/> fails.
        /// When mapping a view of a file mapping object created with <see cref="SectionAttributes.SEC_LARGE_PAGES"/>,
        /// the base address and view size must also be multiples of the minimum large page size.
        /// <see cref="SectionAttributes.SEC_LARGE_PAGES"/> requires the <see cref="SeLockMemoryPrivilege"/> privilege
        /// to be enabled in the caller's token.
        /// If <see cref="SectionAttributes.SEC_LARGE_PAGES"/> is specified, <see cref="SectionAttributes.SEC_COMMIT"/> must also be specified.
        /// Windows Server 2003:  This value is not supported until Windows Server 2003 with SP1.
        /// Windows XP:  This value is not supported.
        /// <see cref="SectionAttributes.SEC_NOCACHE"/>:
        /// Sets all pages to be non-cachable.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped with <see cref="SectionAttributes.SEC_NOCACHE"/>
        /// can result in an <see cref="EXCEPTION_ILLEGAL_INSTRUCTION"/> exception.
        /// <see cref="SectionAttributes.SEC_NOCACHE"/> requires either
        /// the <see cref="SectionAttributes.SEC_RESERVE"/> or <see cref="SectionAttributes.SEC_COMMIT"/> attribute to be set.
        /// <see cref="SectionAttributes.SEC_RESERVE"/>:
        /// If the file mapping object is backed by the operating system paging file
        /// (the <paramref name="hFile"/> parameter is <see cref="Constants.INVALID_HANDLE_VALUE"/>),
        /// specifies that when a view of the file is mapped into a process address space,
        /// the entire range of pages is reserved for later use by the process rather than committed.
        /// Reserved pages can be committed in subsequent calls to the <see cref="VirtualAlloc"/> function.
        /// After the pages are committed, they cannot be freed or decommitted with the <see cref="VirtualFree"/> function.
        /// This attribute has no effect for file mapping objects that are backed by executable image files or data files
        /// (the <paramref name="hFile"/> parameter is a handle to a file).
        /// <see cref="SectionAttributes.SEC_RESERVE"/> cannot be combined with <see cref="SectionAttributes.SEC_COMMIT"/>.
        /// <see cref="SectionAttributes.SEC_WRITECOMBINE"/>:
        /// Sets all pages to be write-combined.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped with <see cref="SectionAttributes.SEC_WRITECOMBINE"/>
        /// can result in an <see cref="EXCEPTION_ILLEGAL_INSTRUCTION"/> exception.
        /// <see cref="SectionAttributes.SEC_WRITECOMBINE"/> requires either
        /// the <see cref="SectionAttributes.SEC_RESERVE"/> or <see cref="SectionAttributes.SEC_COMMIT"/> attribute to be set.
        /// Windows Server 2003 and Windows XP:  This flag is not supported until Windows Vista.
        /// </param>
        /// <param name="dwMaximumSizeHigh">
        /// The high-order DWORD of the maximum size of the file mapping object.
        /// </param>
        /// <param name="dwMaximumSizeLow">
        /// The low-order DWORD of the maximum size of the file mapping object.
        /// If this parameter and <paramref name="dwMaximumSizeHigh"/> are 0 (zero),
        /// the maximum size of the file mapping object is equal to the current size of the file that <paramref name="hFile"/> identifies.
        /// An attempt to map a file with a length of 0 (zero) fails with an error code of <see cref="SystemErrorCodes.ERROR_FILE_INVALID"/>.
        /// Applications should test for files with a length of 0 (zero) and reject those files.
        /// </param>
        /// <param name="lpName">
        /// The name of the file mapping object.
        /// If this parameter matches the name of an existing mapping object,
        /// the function requests access to the object with the protection that <paramref name="flProtect"/> specifies.
        /// If this parameter is <see langword="null"/>, the file mapping object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, semaphore, mutex, waitable timer, or job object,
        /// the function fails, and the <see cref="Marshal.GetLastWin32Error"/> function returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// Creating a file mapping object in the global namespace from a session other than session zero
        /// requires the <see cref="SeCreateGlobalPrivilege"/> privilege.
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented by using Terminal Services sessions.
        /// The first user to log on uses session 0 (zero), the next user to log on uses session 1 (one), and so on.
        /// Kernel object names must follow the guidelines that are outlined for Terminal Services so that applications can support multiple users.
        /// </param>
        /// <param name="nndPreferred">
        /// The NUMA node where the physical memory should reside.
        /// <see cref="NUMA_NO_PREFERRED_NODE"/>:
        /// No NUMA node is preferred.
        /// This is the same as calling the <see cref="CreateFileMapping"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created file mapping object.
        /// If the object exists before the function call, the function returns a handle to the existing object (with its current size,
        /// not the specified size), and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// After a file mapping object is created, the size of the file must not exceed the size of the file mapping object;
        /// if it does, not all of the file contents are available for sharing.
        /// The file mapping object can be shared by duplication, inheritance, or by name.
        /// The initial contents of the pages in a file mapping object backed by the page file are 0 (zero).
        /// If an application specifies a size for the file mapping object that is larger than the size of the actual named file on disk
        /// and if the page protection allows write access (that is, the <paramref name="flProtect"/> parameter specifies
        /// <see cref="MemoryProtectionConstants.PAGE_READWRITE"/> or <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READWRITE"/>),
        /// then the file on disk is increased to match the specified size of the file mapping object.
        /// If the file is extended, the contents of the file between the old end of the file and the new end of the file are not guaranteed to be zero;
        /// the behavior is defined by the file system.
        /// If the file on disk cannot be increased, <see cref="CreateFileMapping"/> fails
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_DISK_FULL"/>.
        /// The handle that the <see cref="CreateFileMappingNuma"/> function returns has full access to a new file mapping object
        /// and can be used with any function that requires a handle to a file mapping object.
        /// A file mapping object can be shared through process creation, handle duplication, or by name.
        /// For more information, see the <see cref="DuplicateHandle"/> and <see cref="OpenFileMapping"/> functions.
        /// Creating a file mapping object creates the potential for mapping a view of the file but does not map the view.
        /// The <see cref="MapViewOfFileExNuma"/> function maps a view of a file into a process address space.
        /// With one important exception, file views derived from a single file mapping object are coherent or identical at a specific time.
        /// If multiple processes have handles of the same file mapping object, they see a coherent view of the data when they map a view of the file.
        /// The exception is related to remote files.
        /// Although <see cref="CreateFileMappingNuma"/> works with remote files, it does not keep them coherent.
        /// For example, if two computers both map a file as writable, and both change the same page, each computer only sees its own writes to the page.
        /// When the data gets updated on the disk, the page is not merged.
        /// A mapped file and a file that is accessed by using the input and output (I/O) functions
        /// (<see cref="ReadFile"/> and <see cref="WriteFile"/>) are not necessarily coherent.
        /// To fully close a file mapping object, an application must unmap all mapped views of the file mapping object
        /// by calling <see cref="UnmapViewOfFile"/> and close the file mapping object handle by calling <see cref="CloseHandle"/>.
        /// These functions can be called in any order.
        /// The call to the <see cref="UnmapViewOfFile"/> function is necessary,
        /// because mapped views of a file mapping object maintain internal open handles to the object,
        /// and a file mapping object does not close until all open handles to it are closed.
        /// When modifying a file through a mapped view, the last modification timestamp may not be updated automatically.
        /// If required, the caller should use <see cref="SetFileTime"/> to set the timestamp.
        /// Creating a file mapping object in the global namespace from a session other than session zero
        /// requires the <see cref="SeCreateGlobalPrivilege"/> privilege.
        /// Note that this privilege check is limited to the creation of file mapping objects and does not apply to opening existing ones.
        /// For example, if a service or the system creates a file mapping object in the global namespace, any process running
        /// in any session can access that file mapping object provided that the caller has the required access rights.
        /// Use structured exception handling to protect any code that writes to or reads from a file view.
        /// For more information, see Reading and Writing From a File View.
        /// To have a mapping with executable permissions, an application must call <see cref="CreateFileMappingNuma"/> with
        /// either <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READWRITE"/> or <see cref="MemoryProtectionConstants.PAGE_EXECUTE_READ"/>,
        /// and then call <see cref="MapViewOfFile"/> with <see cref="FILE_MAP_EXECUTE"/> | <see cref="FILE_MAP_WRITE"/>
        /// or <see cref="FILE_MAP_EXECUTE"/> | <see cref="FILE_MAP_READ"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFileMappingNumaW", SetLastError = true)]
        public static extern IntPtr CreateFileMappingNuma([In]IntPtr hFile,
             [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpFileMappingAttributes,
             [In]uint flProtect, [In]uint dwMaximumSizeHigh, [In]uint dwMaximumSizeLow, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName,
             [In]uint nndPreferred);

        /// <summary>
        /// <para>
        /// Creates or opens a file, file stream, or directory as a transacted operation.
        /// The function returns a handle that can be used to access the object.
        /// To perform this operation as a nontransacted operation or to access objects
        /// other than files(for example, named pipes, physical devices, mailslots), use the <see cref="CreateFile"/> function.
        /// For more information about transactions, see the Remarks section of this topic.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createfiletransactedw
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of an object to be created or opened.
        /// The object must reside on the local computer
        /// otherwise, the function fails and the last error code is set to <see cref="SystemErrorCodes.ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// In the ANSI version of this function, the name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File. For information on special device names, see Defining an MS-DOS Device Name.
        /// To create a file stream, specify the name of the file, a colon, and then the name of the stream.
        /// For more information, see File Streams.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access to the object, which can be summarized as read, write, both or neither (zero).
        /// The most commonly used values are <see cref="GenericAccessRights.GENERIC_READ"/>, <see cref="GenericAccessRights.GENERIC_WRITE"/>,
        /// or both (<see cref="GenericAccessRights.GENERIC_READ"/> | <see cref="GenericAccessRights.GENERIC_WRITE"/>).
        /// For more information, see Generic Access Rights and File Security and Access Rights.
        /// If this parameter is zero, the application can query file, directory, or device attributes without accessing that file or device.
        /// For more information, see the Remarks section of this topic.
        /// You cannot request an access mode that conflicts with the sharing mode that is specified in an open request that has an open handle.
        /// For more information, see Creating and Opening Files.
        /// </param>
        /// <param name="dwShareMode">
        /// The sharing mode of an object, which can be read, write, both, delete, all of these, or none (refer to the following table).
        /// If this parameter is zero and <see cref="CreateFileTransacted"/> succeeds,
        /// the object cannot be shared and cannot be opened again until the handle is closed.
        /// For more information, see the Remarks section of this topic.
        /// You cannot request a sharing mode that conflicts with the access mode that is specified in an open request that has an open handle,
        /// because that would result in the following sharing violation: <see cref="SystemErrorCodes.ERROR_SHARING_VIOLATION"/>.
        /// For more information, see Creating and Opening Files.
        /// To enable a process to share an object while another process has the object open,
        /// use a combination of one or more of the following values to specify the access mode they can request to open the object.
        /// The sharing options for each open handle remain in effect until that handle is closed, regardless of process context.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that contains an optional security descriptor and
        /// also determines whether or not the returned handle can be inherited by child processes.
        /// The parameter can be <see cref="IntPtr.Zero"/>.
        /// If the <paramref name="lpSecurityAttributes"/> parameter is NULL, the handle returned by <see cref="CreateFileTransacted"/> 
        /// cannot be inherited by any child processes your application may create and
        /// the object associated with the returned handle gets a default security descriptor.
        /// The <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of the structure specifies whether the returned handle can be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for an object,
        /// but may also be NULL.
        /// If <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member is NULL,
        /// the object associated with the returned handle is assigned a default security descriptor.
        /// <see cref="CreateFileTransacted"/> ignores the <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member when opening an existing file,
        /// but continues to use the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="dwCreationDisposition">
        /// An action to take on files that exist and do not exist.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="dwFlagsAndAttributes">
        /// The file attributes and flags, <see cref="FileAttributes.FILE_ATTRIBUTE_NORMAL"/> being the most common default value.
        /// This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*).
        /// All other file attributes override <see cref="FileAttributes.FILE_ATTRIBUTE_NORMAL"/>.
        /// This parameter can also contain combinations of flags (FILE_FLAG_) for control of buffering behavior,
        /// access modes, and other special-purpose flags. These combine with any FILE_ATTRIBUTE_ values.
        /// This parameter can also contain Security Quality of Service (SQOS) information
        /// by specifying the <see cref="SECURITY_SQOS_PRESENT"/> flag.
        /// Additional SQOS-related flags information is presented in the table following the attributes and flags tables.
        /// When <see cref="CreateFileTransacted"/> opens an existing file, it generally combines the file flags
        /// with the file attributes of the existing file, and ignores any file attributes supplied as part of <paramref name="dwFlagsAndAttributes"/>.
        /// Special cases are detailed in Creating and Opening Files.
        /// The following file attributes and flags are used only for file objects, not other types of objects
        /// that <see cref="CreateFileTransacted"/> opens (additional information can be found in the Remarks section of this topic).
        /// For more advanced access to file attributes, see <see cref="SetFileAttributes"/>.
        /// For a complete list of all file attributes with their values and descriptions, see File Attribute Constants.
        /// The <paramref name="lpSecurityAttributes"/> parameter can also specify SQOS information.
        /// For more information, see Impersonation Levels.
        /// When the calling application specifies the <see cref="SECURITY_SQOS_PRESENT"/> flag
        /// as part of <paramref name="dwFlagsAndAttributes"/>, it can also contain one or more of the following values.
        /// <see cref="SECURITY_ANONYMOUS"/>, <see cref="SECURITY_CONTEXT_TRACKING"/>, <see cref="SECURITY_DELEGATION"/>,
        /// <see cref="SECURITY_EFFECTIVE_ONLY"/>, <see cref="SECURITY_IDENTIFICATION"/>, <see cref="SECURITY_IMPERSONATION"/>
        /// </param>
        /// <param name="hTemplateFile">
        /// A valid handle to a template file with the <see cref="GenericAccessRights.GENERIC_READ"/> access right.
        /// The template file supplies file attributes and extended attributes for the file that is being created.
        /// This parameter can be <see cref="IntPtr.Zero"/>.
        /// When opening an existing file, <see cref="CreateFileTransacted"/> ignores the template file.
        /// When opening a new EFS-encrypted file, the file inherits the DACL from its parent directory.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <param name="pusMiniVersion">
        /// The miniversion to be opened.
        /// If the transaction specified in hTransaction is not the transaction that is modifying the file,
        /// this parameter should be <see cref="IntPtr.Zero"/>.
        /// Otherwise, this parameter can be a miniversion identifier returned by the <see cref="FSCTL_TXFS_CREATE_MINIVERSION"/> control code,
        /// or one of the following values.
        /// <see cref="TXFS_MINIVERSION_COMMITTED_VIEW"/>, <see cref="TXFS_MINIVERSION_DIRTY_VIEW"/>, <see cref="TXFS_MINIVERSION_DEFAULT_VIEW"/>.
        /// </param>
        /// <param name="lpExtendedParameter">
        /// This parameter is reserved and must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
        /// If the function fails, the return value is INVALID_HANDLE_VALUE.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// When using the handle returned by <see cref="CreateFileTransacted"/>,
        /// use the transacted version of file I/O functions instead of the standard file I/O functions where appropriate.
        /// For more information, see Programming Considerations for Transactional NTFS.
        /// When opening a transacted handle to a directory, that handle must have <see cref="FileAccessRights.FILE_WRITE_DATA"/>
        /// (<see cref="FileAccessRights.FILE_ADD_FILE"/>) and <see cref="FileAccessRights.FILE_APPEND_DATA"/>
        /// (<see cref="FileAccessRights.FILE_ADD_SUBDIRECTORY"/>) permissions.
        /// These are included in <see cref="FileAccessRights.FILE_GENERIC_WRITE"/> permissions.
        /// You should open directories with fewer permissions if you are just using the handle to create files or subdirectories;
        /// otherwise, sharing violations can occur.
        /// You cannot open a file with <see cref="FileAccessRights.FILE_EXECUTE"/> access level
        /// when that file is a part of another transaction (that is, another application opened it by calling <see cref="CreateFileTransacted"/>).
        /// This means that <see cref="CreateFileTransacted"/> fails if the access level
        /// <see cref="FileAccessRights.FILE_EXECUTE"/> or <see cref="FileAccessRights.FILE_ALL_ACCESS"/> is specified.
        /// When a non-transacted application calls <see cref="CreateFileTransacted"/> with <see cref="MAXIMUM_ALLOWED"/> specified 
        /// for <paramref name="lpSecurityAttributes"/>, a handle is opened with the same access level every time.
        /// When a transacted application calls <see cref="CreateFileTransacted"/> with <see cref="MAXIMUM_ALLOWED"/> specified
        /// for <paramref name="lpSecurityAttributes"/>, a handle is opened with a differing amount of access based on
        /// whether the file is locked by a transaction.
        /// For example, if the calling application has <see cref="FileAccessRights.FILE_EXECUTE"/> access level for a file,
        /// the application only obtains this access if the file that is being opened is either not locked by a transaction,
        /// or is locked by a transaction and the application is already a transacted reader for that file.
        /// See Transactional NTFS for a complete description of transacted operations.
        /// Use the <see cref="CloseHandle"/> function to close an object handle returned by <see cref="CreateFileTransacted"/>
        /// when the handle is no longer needed, and prior to committing or rolling back the transaction.
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes that are formatted for that kind of file system, a new file inherits the compression and encryption attributes of its directory.
        /// You cannot use <see cref="CreateFileTransacted"/> to control compression on a file or directory.
        /// For more information, see File Compression and Decompression, and File Encryption.
        /// Symbolic link behavior—If the call to this function creates a new file, there is no change in behavior.
        /// If <see cref="FileFlags.FILE_FLAG_OPEN_REPARSE_POINT"/> is specified:
        /// If an existing file is opened and it is a symbolic link, the handle returned is a handle to the symbolic link.
        /// If <see cref="FileCreationDispositions.TRUNCATE_EXISTING"/> or <see cref="FileFlags.FILE_FLAG_DELETE_ON_CLOSE"/> are specified,
        /// the file affected is a symbolic link.
        /// If <see cref="FileFlags.FILE_FLAG_OPEN_REPARSE_POINT"/> is not specified:
        /// If an existing file is opened and it is a symbolic link, the handle returned is a handle to the target.
        /// If <see cref="FileCreationDispositions.CREATE_ALWAYS"/>, <see cref="FileCreationDispositions.TRUNCATE_EXISTING"/>,
        /// or <see cref="FileFlags.FILE_FLAG_DELETE_ON_CLOSE"/> are specified, the file affected is the target.
        /// A multi-sector write is not guaranteed to be atomic unless you are using a transaction (that is, the handle created is a transacted handle).
        /// A single-sector write is atomic. Multi-sector writes that are cached may not always be written to the disk;
        /// therefore, specify <see cref="FileFlags.FILE_FLAG_WRITE_THROUGH"/> to ensure that
        /// an entire multi-sector write is written to the disk without caching.
        /// As stated previously, if the <paramref name="lpSecurityAttributes"/> parameter is <see cref="IntPtr.Zero"/>,
        /// the handle returned by <see cref="CreateFileTransacted"/> cannot be inherited by any child processes your application may create.
        /// The following information regarding this parameter also applies:
        /// If <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> is not <see langword="false"/>, which is any nonzero value,
        /// then the handle can be inherited. Therefore it is critical this structure member be properly
        /// initialized to <see langword="false"/> if you do not intend the handle to be inheritable.
        /// The access control lists(ACL) in the default security descriptor for a file or directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for
        /// the <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> to have an effect on them,
        /// which can be determined by using <see cref="GetVolumeInformation"/>.
        /// Files
        /// If you try to create a file on a floppy drive that does not have a floppy disk or a CD-ROM drive that does not have a CD,
        /// the system displays a message for the user to insert a disk or a CD.
        /// To prevent the system from displaying this message, call the <see cref="SetErrorMode"/> function with <see cref="SEM_FAILCRITICALERRORS"/>.
        /// For more information, see Creating and Opening Files.
        /// If you rename or delete a file and then restore it shortly afterward, the system searches the cache for file information to restore.
        /// Cached information includes its short/long name pair and creation time.
        /// If you call <see cref="CreateFileTransacted"/> on a file that is pending deletion as a result of a previous call to <see cref="DeleteFile"/>,
        /// the function fails. The operating system delays file deletion until all handles to the file are closed.
        /// <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// The <paramref name="dwDesiredAccess"/> parameter can be zero, allowing the application to query file attributes
        /// without accessing the file if the application is running with adequate security settings.
        /// This is useful to test for the existence of a file without opening it for read and/or write access,
        /// or to obtain other statistics about the file or directory.
        /// See Obtaining and Setting File Information and <see cref="GetFileInformationByHandle"/>.
        /// When an application creates a file across a network, it is better to use
        /// <see cref="GenericAccessRights.GENERIC_READ"/> | <see cref="GenericAccessRights.GENERIC_WRITE"/> than
        /// to use <see cref="GenericAccessRights.GENERIC_WRITE"/> alone.
        /// The resulting code is faster, because the redirector can use the cache manager and send fewer SMBs with more data.
        /// This combination also avoids an issue where writing to a file
        /// across a network can occasionally return <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// File Streams
        /// On NTFS file systems, you can use <see cref="CreateFileTransacted"/> to create separate streams within a file.
        /// For more information, see File Streams.
        /// Directories
        /// An application cannot create a directory by using <see cref="CreateFileTransacted"/>,
        /// therefore only the <see cref="FileCreationDispositions.OPEN_EXISTING"/> value is valid
        /// for <paramref name="dwCreationDisposition"/> for this use case.
        /// To create a directory, the application must call <see cref="CreateDirectoryTransacted"/>,
        /// <see cref="CreateDirectory"/> or <see cref="CreateDirectoryEx"/>.
        /// To open a directory using <see cref="CreateFileTransacted"/>, specify the <see cref="FileFlags.FILE_FLAG_BACKUP_SEMANTICS"/> flag
        /// as part of <paramref name="dwFlagsAndAttributes"/>.
        /// Appropriate security checks still apply when this flag is used
        /// without <see cref="SE_BACKUP_NAME"/> and <see cref="SE_RESTORE_NAME"/> privileges.
        /// When using <see cref="CreateFileTransacted"/> to open a directory during defragmentation of a FAT or FAT32 file system volume,
        /// do not specify the <see cref="MAXIMUM_ALLOWED"/> access right. Access to the directory is denied if this is done.
        /// Specify the <see cref="GenericAccessRights.GENERIC_READ"/> access right instead.
        /// For more information, see About Directory Management.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFileTransactedW", SetLastError = true)]
        public static extern IntPtr CreateFileTransacted([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName, [In]FileAccessRights dwDesiredAccess,
            [In]FileShareModes dwShareMode,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes,
            [In]FileCreationDispositions dwCreationDisposition, [In]uint dwFlagsAndAttributes, [In]IntPtr hTemplateFile, [In]IntPtr hTransaction,
            [In]IntPtr pusMiniVersion, [In]IntPtr lpExtendedParameter);

        /// <summary>
        /// <para>
        /// Creates or opens a job object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/jobapi2/nf-jobapi2-createjobobjectw
        /// </para>
        /// </summary>
        /// <param name="lpJobAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies the security descriptor for the job object
        /// and determines whether child processes can inherit the returned handle.
        /// If <paramref name="lpJobAttributes"/> is <see langword="null"/>, the job object gets a default security descriptor 
        /// and the handle cannot be inherited.
        /// The ACLs in the default security descriptor for a job object come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lpName">
        /// The name of the job. The name is limited to <see cref="Constants.MAX_PATH"/> characters. Name comparison is case-sensitive.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the job is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, semaphore, mutex, waitable timer, or file-mapping object,
        /// the function fails and the <see cref="Marshal.GetLastWin32Error"/> function returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The object can be created in a private namespace. For more information, see Object Namespaces.
        /// Terminal Services:  The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the job object.
        /// The handle has the <see cref="JOB_OBJECT_ALL_ACCESS"/> access right.
        /// If the object existed before the function call, the function returns a handle to the existing job object
        /// and <see cref="Marshal.GetLastError"/> returns <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// When a job is created, its accounting information is initialized to zero, all limits are inactive, and there are no associated processes.
        /// To assign a process to a job object, use the <see cref="AssignProcessToJobObject"/> function.
        /// To set limits for a job, use the <see cref="SetInformationJobObject"/> function.
        /// To query accounting information, use the <see cref="QueryInformationJobObject"/> function.
        /// All processes associated with a job must run in the same session.
        /// A job is associated with the session of the first process to be assigned to the job.
        /// Windows Server 2003 and Windows XP:  A job is associated with the session of the process that created it.
        /// To close a job object handle, use the <see cref="CloseHandle"/> function.
        /// The job is destroyed when its last handle has been closed and all associated processes have exited.
        /// However, if the job has the <see cref="JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE"/> flag specified,
        /// closing the last job object handle terminates all associated processes and then destroys the job object itself.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateJobObjectW", SetLastError = true)]
        public static extern IntPtr CreateJobObject(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpJobAttributes,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// Creates a mailslot with the specified name and returns a handle that a mailslot server can use to perform operations on the mailslot.
        /// The mailslot is local to the computer that creates it. An error occurs if a mailslot with the specified name already exists.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createmailslotw
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// The name of the mailslot. This name must have the following form:
        /// \.\mailslot[path]name
        /// The name field must be unique. The name may include multiple levels of pseudo directories separated by backslashes.
        /// For example, both \.\mailslot\example_mailslot_name and \.\mailslot\abc\def\ghi are valid names.
        /// </param>
        /// <param name="nMaxMessageSize">
        /// The maximum size of a single message that can be written to the mailslot, in bytes.
        /// To specify that the message can be of any size, set this value to zero.
        /// </param>
        /// <param name="lReadTimeout">
        /// The time a read operation can wait for a message to be written to the mailslot before a time-out occurs, in milliseconds.
        /// The following values have special meanings.
        /// 0: Returns immediately if no message is present. (The system does not treat an immediate return as an error.)
        /// <see cref="MAILSLOT_WAIT_FOREVER"/>: Waits forever for a message.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// The <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of the structure determines whether the returned handle
        /// can be inherited by child processes.
        /// If <paramref name="lpSecurityAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the mailslot, for use in server mailslot operations.
        /// The handle returned by this function is asynchronous, or overlapped.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// The mailslot exists until one of the following conditions is true:
        /// The last (possibly inherited or duplicated) handle to it is closed using the <see cref="CloseHandle"/> function.
        /// The process owning the last (possibly inherited or duplicated) handle exits.
        /// The system uses the second method to destroy mailslots.
        /// To write a message to a mailslot, a process uses the <see cref="CreateFile"/> function,
        /// specifying the mailslot name by using one of the following formats.
        /// \\.\mailslot\name: Retrieves a client handle to a local mailslot.
        /// \\computername\mailslot\name: Retrieves a client handle to a remote mailslot.
        /// \\domainname\mailslot\name: Retrieves a client handle to all mailslots with the specified name in the specified domain.
        /// \\*\mailslot\name: Retrieves a client handle to all mailslots with the specified name in the system's primary domain.
        /// If <see cref="CreateFile"/> specifies a domain or uses the asterisk format to specify the system's primary domain,
        /// the application cannot write more than 424 bytes at a time to the mailslot.
        /// If the application attempts to do so, the <see cref="WriteFile"/> function fails and
        /// <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_BAD_NETPATH"/>.
        /// An application must specify the <see cref="FileShareModes.FILE_SHARE_READ"/> flag
        /// when using <see cref="CreateFile"/> to retrieve a client handle to a mailslot.
        /// If <see cref="CreateFile"/> is called to access a non-existent mailslot,
        /// the <see cref="SystemErrorCodes.ERROR_FILE_NOT_FOUND"/> error code will be set.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMailslotW", SetLastError = true)]
        public static extern IntPtr CreateMailslot([MarshalAs(UnmanagedType.LPWStr)][In]string lpName, [In]uint nMaxMessageSize, [In]uint lReadTimeout,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed mutex object.
        /// To specify an access mask for the object, use the <see cref="CreateMutexEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createmutexw
        /// </para>
        /// </summary>
        /// <param name="lpMutexAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If this parameter is <see langword="null"/>, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new mutex.
        /// If <paramref name="lpMutexAttributes"/> is <see langword="null"/>, the mutex gets a default security descriptor.
        /// The ACLs in the default security descriptor for a mutex come from the primary or impersonation token of the creator.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="bInitialOwner">
        /// If this value is <see langword="true"/> and the caller created the mutex, the calling thread obtains initial ownership of the mutex object.
        /// Otherwise, the calling thread does not obtain ownership of the mutex.
        /// To determine if the caller created the mutex, see the Return Values section.
        /// </param>
        /// <param name="lpName">
        /// The name of the mutex object. The name is limited to <see cref="Constants.MAX_PATH"/> characters. Name comparison is case sensitive.
        /// If <paramref name="lpName"/> matches the name of an existing named mutex object,
        /// this function requests the <see cref="MUTEX_ALL_ACCESS"/> access right.
        /// In this case, the <paramref name="bInitialOwner"/> parameter is ignored because it has already been set by the creating process.
        /// If the <paramref name="lpMutexAttributes"/> parameter is not <see langword="null"/>, it determines whether the handle can be inherited,
        /// but its security-descriptor member is ignored.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the mutex object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, semaphore, waitable timer, job, or file-mapping object,
        /// the function fails and the <see cref="Marshal.GetLastWin32Error"/> function returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace. For more information, see Object Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created mutex object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// If the mutex is a named mutex and the object existed before this function call,
        /// the return value is a handle to the existing object, <see cref="OpenMutex"/> function.
        /// </returns>
        /// <remarks>
        /// The handle returned by <see cref="CreateMutex"/> has the <see cref="MUTEX_ALL_ACCESS"/> access right;
        /// it can be used in any function that requires a handle to a mutex object, provided that the caller has been granted access.
        /// If a mutex is created from a service or a thread that is impersonating a different user,
        /// you can either apply a security descriptor to the mutex when you create it,
        /// or change the default security descriptor for the creating process by changing its default DACL.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// If you are using a named mutex to limit your application to a single instance, a malicious user can create this mutex 
        /// before you do and prevent your application from starting.
        /// To prevent this situation, create a randomly named mutex and store the name so that it can only be obtained by an authorized user.
        /// Alternatively, you can use a file for this purpose.
        /// To limit your application to one instance per user, create a locked file in the user's profile directory.
        /// Any thread of the calling process can specify the mutex-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// The state of a mutex object is signaled when it is not owned by any thread.
        /// The creating thread can use the <paramref name="bInitialOwner"/> flag to request immediate ownership of the mutex.
        /// Otherwise, a thread must use one of the wait functions to request ownership.
        /// When the mutex's state is signaled, one waiting thread is granted ownership,
        /// the mutex's state changes to nonsignaled, and the wait function returns.
        /// Only one thread can own a mutex at any given time
        /// . The owning thread uses the ReleaseMutex function to release its ownership.
        /// The thread that owns a mutex can specify the same mutex in repeated wait function calls without blocking its execution.
        /// Typically, you would not wait repeatedly for the same mutex,
        /// but this mechanism prevents a thread from deadlocking itself while waiting for a mutex that it already owns.
        /// However, to release its ownership, the thread must call <see cref="ReleaseMutex"/> once for each time that the mutex satisfied a wait.
        /// Two or more processes can call <see cref="CreateMutex"/> to create the same named mutex.
        /// The first process actually creates the mutex, and subsequent processes with sufficient access rights simply open a handle to the existing mutex.
        /// This enables multiple processes to get handles of the same mutex,
        /// while relieving the user of the responsibility of ensuring that the creating process is started first.
        /// When using this technique, you should set the <paramref name="bInitialOwner"/> flag to FALSE;
        /// otherwise, it can be difficult to be certain which process has initial ownership.
        /// Multiple processes can have handles of the same mutex object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to a mutex object
        /// if the <paramref name="lpMutexAttributes"/> parameter of <see cref="CreateMutex"/> enabled inheritance.
        /// This mechanism works for both named and unnamed mutexes.
        /// A process can specify the handle to a mutex object in a call to the <see cref="DuplicateHandle"/> function
        /// to create a duplicate handle that can be used by another process.
        /// This mechanism works for both named and unnamed mutexes.
        /// A process can specify a named mutex in a call to the <see cref="OpenMutex"/>
        /// or <see cref="CreateMutex"/> function to retrieve a handle to the mutex object.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The mutex object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMutexW", SetLastError = true)]
        public static extern IntPtr CreateMutex(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpMutexAttributes,
            [In]bool bInitialOwner, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed mutex object and returns a handle to the object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createmutexexw
        /// </para>
        /// </summary>
        /// <param name="lpMutexAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If this parameter is <see langword="null"/>, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new mutex.
        /// If <paramref name="lpMutexAttributes"/> is <see langword="null"/>, the mutex gets a default security descriptor.
        /// The ACLs in the default security descriptor for a mutex come from the primary or impersonation token of the creator.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="lpName">
        /// The name of the mutex object. The name is limited to <see cref="Constants.MAX_PATH"/> characters. Name comparison is case sensitive.
        /// If <paramref name="lpName"/> matches the name of an existing named mutex object,
        /// this function requests the <see cref="MUTEX_ALL_ACCESS"/> access right.
        /// In this case, the <paramref name="bInitialOwner"/> parameter is ignored because it has already been set by the creating process.
        /// If the <paramref name="lpMutexAttributes"/> parameter is not <see langword="null"/>, it determines whether the handle can be inherited,
        /// but its security-descriptor member is ignored.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the mutex object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, semaphore, waitable timer, job, or file-mapping object,
        /// the function fails and the <see cref="Marshal.GetLastWin32Error"/> function returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace. For more information, see Object Namespaces.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be 0 or the following value.
        /// <see cref="CREATE_MUTEX_INITIAL_OWNER"/>: The object creator is the initial owner of the mutex.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access mask for the mutex object.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created mutex object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// If the mutex is a named mutex and the object existed before this function call,
        /// the return value is a handle to the existing object, <see cref="OpenMutex"/> function.
        /// </returns>
        /// <remarks>
        /// If you are using a named mutex to limit your application to a single instance, a malicious user can create this mutex 
        /// before you do and prevent your application from starting.
        /// To prevent this situation, create a randomly named mutex and store the name so that it can only be obtained by an authorized user.
        /// Alternatively, you can use a file for this purpose.
        /// To limit your application to one instance per user, create a locked file in the user's profile directory.
        /// Any thread of the calling process can specify the mutex-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// The state of a mutex object is signaled when it is not owned by any thread.
        /// The creating thread can use the <paramref name="dwFlags "/> flag to request immediate ownership of the mutex.
        /// Otherwise, a thread must use one of the wait functions to request ownership.
        /// When the mutex's state is signaled, one waiting thread is granted ownership,
        /// the mutex's state changes to nonsignaled, and the wait function returns.
        /// Only one thread can own a mutex at any given time
        /// . The owning thread uses the ReleaseMutex function to release its ownership.
        /// The thread that owns a mutex can specify the same mutex in repeated wait function calls without blocking its execution.
        /// Typically, you would not wait repeatedly for the same mutex,
        /// but this mechanism prevents a thread from deadlocking itself while waiting for a mutex that it already owns.
        /// However, to release its ownership, the thread must call <see cref="ReleaseMutex"/> once for each time that the mutex satisfied a wait.
        /// Two or more processes can call <see cref="CreateMutex"/> to create the same named mutex.
        /// The first process actually creates the mutex, and subsequent processes with sufficient access rights simply open a handle to the existing mutex.
        /// This enables multiple processes to get handles of the same mutex,
        /// while relieving the user of the responsibility of ensuring that the creating process is started first.
        /// When using this technique, you should use the <see cref="CREATE_MUTEX_INITIAL_OWNER"/> flag;
        /// otherwise, it can be difficult to be certain which process has initial ownership.
        /// Multiple processes can have handles of the same mutex object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to a mutex object
        /// if the <paramref name="lpMutexAttributes"/> parameter of <see cref="CreateMutex"/> enabled inheritance.
        /// This mechanism works for both named and unnamed mutexes.
        /// A process can specify the handle to a mutex object in a call to the <see cref="DuplicateHandle"/> function
        /// to create a duplicate handle that can be used by another process.
        /// This mechanism works for both named and unnamed mutexes.
        /// A process can specify a named mutex in a call to the <see cref="OpenMutex"/>
        /// or <see cref="CreateMutex"/> function to retrieve a handle to the mutex object.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The mutex object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMutexExW", SetLastError = true)]
        public static extern IntPtr CreateMutexEx(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpMutexAttributes,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpName, [In]uint dwFlags, [In]uint dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Creates an instance of a named pipe and returns a handle for subsequent pipe operations.
        /// A named pipe server process uses this function either to create the first instance of a specific named pipe
        /// and establish its basic attributes or to create a new instance of an existing named pipe.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createnamedpipea (CreateNamedPipeW document not exists)
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// The unique pipe name. This string must have the following form:
        /// \.\pipe&lt;i&gt;pipename
        /// The pipename part of the name can include any character other than a backslash, including numbers and special characters.
        /// The entire pipe name string can be up to 256 characters long. Pipe names are not case sensitive.
        /// </param>
        /// <param name="dwOpenMode">
        /// The open mode.
        /// The function fails if <paramref name="dwOpenMode"/> specifies anything other than 0 or the flags listed in the following tables.
        /// This parameter must specify one of the following pipe access modes. The same mode must be specified for each instance of the pipe.
        /// <see cref="PipeOpenModes.PIPE_ACCESS_DUPLEX"/>, <see cref="PipeOpenModes.PIPE_ACCESS_INBOUND"/>, <see cref="PipeOpenModes.PIPE_ACCESS_OUTBOUND"/>.
        /// This parameter can also include one or more of the following flags, which enable the write-through and overlapped modes.
        /// These modes can be different for different instances of the same pipe.
        /// <see cref="FileFlags.FILE_FLAG_FIRST_PIPE_INSTANCE"/>:
        /// If you attempt to create multiple instances of a pipe with this flag, creation of the first instance succeeds,
        /// but creation of the next instance fails with <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// <see cref="FileFlags.FILE_FLAG_WRITE_THROUGH"/>:
        /// Write-through mode is enabled. This mode affects only write operations on byte-type pipes and, then,
        /// only when the client and server processes are on different computers.
        /// If this mode is enabled, functions writing to a named pipe do not return until the data written is transmitted across the network
        /// and is in the pipe's buffer on the remote computer.
        /// If this mode is not enabled, the system enhances the efficiency of network operations by buffering data
        /// until a minimum number of bytes accumulate or until a maximum time elapses.
        /// <see cref="FileFlags.FILE_FLAG_OVERLAPPED"/>
        /// Overlapped mode is enabled.
        /// If this mode is enabled, functions performing read, write, and connect operations that may take a significant time
        /// to be completed can return immediately.
        /// This mode enables the thread that started the operation to perform other operations while the time-consuming operation
        /// executes in the background.
        /// For example, in overlapped mode, a thread can handle simultaneous input and output (I/O) operations on
        /// multiple instances of a pipe or perform simultaneous read and write operations on the same pipe handle.
        /// If overlapped mode is not enabled, functions performing read, write, and connect operations on the pipe handle
        /// do not return until the operation is finished.
        /// The <see cref="ReadFileEx"/> and <see cref="WriteFileEx"/> functions can only be used with a pipe handle in overlapped mode.
        /// The <see cref="ReadFile"/>, <see cref="WriteFile"/>, <see cref="ConnectNamedPipe"/>, and <see cref="TransactNamedPipe"/> functions
        /// can execute either synchronously or as overlapped operations.
        /// This parameter can include any combination of the following security access modes.
        /// These modes can be different for different instances of the same pipe.
        /// <see cref="StandardAccessRights.WRITE_DAC"/>:
        /// The caller will have write access to the named pipe's discretionary access control list (ACL).
        /// <see cref="StandardAccessRights.WRITE_OWNER"/>:
        /// The caller will have write access to the named pipe's owner.
        /// <see cref="Constants.ACCESS_SYSTEM_SECURITY"/>:
        /// The caller will have write access to the named pipe's SACL. For more information, see Access-Control Lists (ACLs) and SACL Access Right.
        /// </param>
        /// <param name="dwPipeMode">
        /// The pipe mode.
        /// The function fails if <paramref name="dwPipeMode"/> specifies anything other than 0 or the flags listed in the following tables.
        /// One of the following type modes can be specified. The same type mode must be specified for each instance of the pipe.
        /// <see cref="PipeModes.PIPE_TYPE_BYTE"/>, <see cref="PipeModes.PIPE_TYPE_MESSAGE"/>
        /// One of the following read modes can be specified. Different instances of the same pipe can specify different read modes.
        /// <see cref="PipeModes.PIPE_READMODE_BYTE"/>, <see cref="PipeModes.PIPE_READMODE_MESSAGE"/>
        /// One of the following wait modes can be specified. Different instances of the same pipe can specify different wait modes.
        /// <see cref="PipeModes.PIPE_WAIT"/>, <see cref="PipeModes.PIPE_NOWAIT"/>
        /// One of the following remote-client modes can be specified. Different instances of the same pipe can specify different remote-client modes.
        /// <see cref="PipeModes.PIPE_ACCEPT_REMOTE_CLIENTS"/>, <see cref="PipeModes.PIPE_REJECT_REMOTE_CLIENTS"/>
        /// </param>
        /// <param name="nMaxInstances">
        /// The maximum number of instances that can be created for this pipe.
        /// The first instance of the pipe can specify this value; the same number must be specified for other instances of the pipe.
        /// Acceptable values are in the range 1 through <see cref="PIPE_UNLIMITED_INSTANCES"/>.
        /// If this parameter is <see cref="PIPE_UNLIMITED_INSTANCES"/>, the number of pipe instances that can be created
        /// is limited only by the availability of system resources.
        /// If nMaxInstances is greater than <see cref="PIPE_UNLIMITED_INSTANCES"/>,
        /// the return value is <see cref="INVALID_HANDLE_VALUE"/> and
        /// <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <param name="nOutBufferSize">
        /// The number of bytes to reserve for the output buffer. For a discussion on sizing named pipe buffers, see the following Remarks section.
        /// </param>
        /// <param name="nInBufferSize">
        /// The number of bytes to reserve for the input buffer. For a discussion on sizing named pipe buffers, see the following Remarks section.
        /// </param>
        /// <param name="nDefaultTimeOut">
        /// The default time-out value, in milliseconds, if the <see cref="WaitNamedPipe"/> function specifies <see cref="NMPWAIT_USE_DEFAULT_WAIT"/>.
        /// Each instance of a named pipe must specify the same value.
        /// A value of zero will result in a default time-out of 50 milliseconds.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new named pipe
        /// and determines whether child processes can inherit the returned handle.
        /// If <paramref name="lpSecurityAttributes"/> is <see langword="null"/>, 
        /// the named pipe gets a default security descriptor and the handle cannot be inherited.
        /// The ACLs in the default security descriptor for a named pipe grant full control to the LocalSystem account,
        /// administrators, and the creator owner. They also grant read access to members of the Everyone group and the anonymous account.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the server end of a named pipe instance.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// To create an instance of a named pipe by using <see cref="CreateNamedPipe"/>,
        /// the user must have <see cref="FILE_CREATE_PIPE_INSTANCE"/> access to the named pipe object.
        /// If a new named pipe is being created, the access control list (ACL) from the security attributes parameter
        /// defines the discretionary access control for the named pipe.
        /// All instances of a named pipe must specify the same pipe type (byte-type or message-type),
        /// pipe access (duplex, inbound, or outbound), instance count, and time-out value.
        /// If different values are used, this function fails and
        /// <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// A client process connects to a named pipe by using the <see cref="CreateFile"/> or <see cref="CallNamedPipe"/> function.
        /// The client side of a named pipe starts out in byte mode, even if the server side is in message mode.
        /// To avoid problems receiving data, set the client side to message mode as well.
        /// To change the mode of the pipe, the pipe client must open a read-only pipe
        /// with <see cref="GenericAccessRights.GENERIC_READ"/> and <see cref="FileAccessRights.FILE_WRITE_ATTRIBUTES"/> access.
        /// The pipe server should not perform a blocking read operation until the pipe client has started. Otherwise, a race condition can occur.
        /// This typically occurs when initialization code, such as the C run-time, needs to lock and examine inherited handles.
        /// Every time a named pipe is created, the system creates the inbound and/or outbound buffers using nonpaged pool,
        /// which is the physical memory used by the kernel.
        /// The number of pipe instances (as well as objects such as threads and processes) that you can create is limited by the available nonpaged pool.
        /// Each read or write request requires space in the buffer for the read or write data, plus additional space for the internal data structures.
        /// The input and output buffer sizes are advisory. The actual buffer size reserved for each end of the named pipe is either the system default,
        /// the system minimum or maximum, or the specified size rounded up to the next allocation boundary.
        /// The buffer size specified should be small enough that your process will not run out of nonpaged pool,
        /// but large enough to accommodate typical requests.
        /// Whenever a pipe write operation occurs, the system first tries to charge the memory against the pipe write quota.
        /// If the remaining pipe write quota is enough to fulfill the request, the write operation completes immediately.
        /// If the remaining pipe write quota is too small to fulfill the request, the system will try to expand the buffers
        /// to accommodate the data using nonpaged pool reserved for the process.
        /// The write operation will block until the data is read from the pipe so that the additional buffer quota can be released.
        /// Therefore, if your specified buffer size is too small, the system will grow the buffer as needed,
        /// but the downside is that the operation will block.
        /// If the operation is overlapped, a system thread is blocked; otherwise, the application thread is blocked.
        /// To free resources used by a named pipe, the application should always close handles when they are no longer needed,
        /// which is accomplished either by calling the <see cref="CloseHandle"/> function or when the process associated with the instance handles ends.
        /// Note that an instance of a named pipe may have more than one handle associated with it.
        /// An instance of a named pipe is always deleted when the last handle to the instance of the named pipe is closed.
        /// Windows 10, version 1709:  Pipes are only supported within an app-container; ie,
        /// from one UWP process to another UWP process that's part of the same app.
        /// Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateNamedPipeW", SetLastError = true)]
        public static extern IntPtr CreateNamedPipe([MarshalAs(UnmanagedType.LPWStr)][In]string lpName, [In]uint dwOpenMode, [In]uint dwPipeMode,
            [In]uint nMaxInstances, [In]uint nOutBufferSize, [In]uint nInBufferSize, [In]uint nDefaultTimeOut,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Creates an anonymous pipe, and returns handles to the read and write ends of the pipe.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/namedpipeapi/nf-namedpipeapi-createpipe
        /// </para>
        /// </summary>
        /// <param name="hReadPipe">
        /// A pointer to a variable that receives the read handle for the pipe.
        /// </param>
        /// <param name="hWritePipe">
        /// A pointer to a variable that receives the write handle for the pipe.
        /// </param>
        /// <param name="lpPipeAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpPipeAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new pipe.
        /// If <paramref name="lpPipeAttributes"/> is <see langword="null"/>, the pipe gets a default security descriptor.
        /// The ACLs in the default security descriptor for a pipe come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="nSize">
        /// The size of the buffer for the pipe, in bytes.
        /// The size is only a suggestion; the system uses the value to calculate an appropriate buffering mechanism.
        /// If this parameter is zero, the system uses the default buffer size.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="CreatePipe"/> creates the pipe, assigning the specified pipe size to the storage buffer.
        /// <see cref="CreatePipe"/> also creates handles that the process uses to read from and write to the buffer
        /// in subsequent calls to the <see cref="ReadFile"/> and <see cref="WriteFile"/> functions.
        /// To read from the pipe, a process uses the read handle in a call to the <see cref="ReadFile"/> function.
        /// <see cref="ReadFile"/> returns when one of the following is true: a write operation completes on the write end of the pipe,
        /// the number of bytes requested has been read, or an error occurs.
        /// When a process uses <see cref="WriteFile"/> to write to an anonymous pipe, the write operation is not completed until all bytes are written.
        /// If the pipe buffer is full before all bytes are written, <see cref="WriteFile"/> does not return
        /// until another process or thread uses <see cref="ReadFile"/> to make more buffer space available.
        /// Anonymous pipes are implemented using a named pipe with a unique name.
        /// Therefore, you can often pass a handle to an anonymous pipe to a function that requires a handle to a named pipe.
        /// If <see cref="CreatePipe"/> fails, the contents of the output parameters are indeterminate.
        /// No assumptions should be made about their contents in this event.
        /// To free resources used by a pipe, the application should always close handles when they are no longer needed,
        /// which is accomplished either by calling the <see cref="CloseHandle"/> function or
        /// when the process associated with the instance handles ends.
        /// Note that an instance of a pipe may have more than one handle associated with it.
        /// An instance of a pipe is always deleted when the last handle to the instance of the named pipe is closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePipe", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreatePipe([Out]out IntPtr hReadPipe, [Out]out IntPtr hWritePipe,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpPipeAttributes,
            [In] uint nSize);

        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread. The new process runs in the security context of the calling process.
        /// If the calling process is impersonating another user, the new process uses the token for the calling process, not the impersonation token.
        /// To run the new process in the security context of the user represented by the impersonation token,
        /// use the <see cref="CreateProcessAsUser"/> or <see cref="CreateProcessWithLogonW"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-createprocessw
        /// </para>
        /// </summary>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path.
        /// This parameter must include the file name extension; no default extension is assumed.
        /// The <paramref name="lpApplicationName"/> parameter can be <see langword="null"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCommandLine"/> string.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be NULL,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// To run a batch file, you must start the command interpreter; set <paramref name="lpApplicationName"/> to cmd.exe and
        /// set <paramref name="lpCommandLine"/> to the following arguments: /c plus the name of the batch file.
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed.
        /// The maximum length of this string is 32,768 characters, including the Unicode terminating null character.
        /// If lpApplicationName is <see langword="null"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// The Unicode version of this function, <see cref="CreateProcess"/>, can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// The <paramref name="lpCommandLine"/> parameter can be <see langword="null"/>.
        /// In that case, the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-NULL,
        /// the null-terminated string pointed to by <paramref name="lpApplicationName"/> specifies the module to execute,
        /// and the null-terminated string pointed to by <paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and
        /// the arguments begin (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// 1.The directory from which the application loaded.
        /// 2. The current directory for the parent process.
        /// 3. The 32-bit Windows system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// 4.The 16-bit Windows system directory. 
        /// There is no function that obtains the path of this directory, but it is searched. The name of this directory is System.
        /// 5. The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// 6.The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// The system adds a terminating null character to the command-line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </param>
        /// <param name="lpProcessAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether
        /// the returned handle to the new process object can be inherited by child processes.
        /// If <paramref name="lpProcessAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new process.
        /// If <paramref name="lpProcessAttributes"/> is <see langword="null"/> or
        /// <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="IntPtr.Zero"/>, the process gets a default security descriptor.
        /// The ACLs in the default security descriptor for a process come from the primary token of the creator.
        /// Windows XP:  The ACLs in the default security descriptor for a process come from the primary or impersonation token of the creator.
        /// This behavior changed with Windows XP with SP2 and Windows Server 2003.
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether
        /// the returned handle to the new thread object can be inherited by child processes.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the main thread.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/> or
        /// <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="IntPtr.Zero"/>, the thread gets a default security descriptor.
        /// The ACLs in the default security descriptor for a thread come from the process token.
        /// Windows XP:  The ACLs in the default security descriptor for a thread come from the primary or impersonation token of the creator.
        /// This behavior changed with Windows XP with SP2 and Windows Server 2003.
        /// </param>
        /// <param name="bInheritHandles">
        /// If this parameter is <see langword="true"/>, each inheritable handle in the calling process is inherited by the new process.
        /// If the parameter is <see langword="false"/>, the handles are not inherited.
        /// Note that inherited handles have the same value and access rights as the original handles.
        /// For additional discussion of inheritable handles, see Remarks.
        /// Terminal Services:  You cannot inherit handles across sessions.
        /// Additionally, if this parameter is <see langword="true"/>, you must create the process in the same session as the caller.
        /// Protected Process Light (PPL) processes:  The generic handle inheritance is blocked
        /// when a PPL process creates a non-PPL process since <see cref="PROCESS_DUP_HANDLE"/> is not allowed from a non-PPL process to a PPL process.
        /// See Process Security and Access Rights
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control the priority class and the creation of the process. 
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="ProcessPriorityClasses.NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="ProcessPriorityClasses.IDLE_PRIORITY_CLASS"/> 
        /// or <see cref="ProcessPriorityClasses.BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to the environment block for the new process.
        /// If this parameter is <see langword="null"/>, the new process uses the environment of the calling process.
        /// An environment block consists of a null-terminated block of null-terminated strings.
        /// Each string is in the following form: name=value\0
        /// Because the equal sign is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain either Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// be sure that <paramref name="dwCreationFlags"/> includes <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/>.
        /// If this parameter is <see langword="null"/> and the environment block of the parent process contains Unicode characters,
        /// you must also ensure that dwCreationFlags includes <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/>.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is <see langword="null"/>, the new process will have the same current drive and directory as the calling process.
        /// (This feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> structure.
        /// To set extended attributes, use a <see cref="STARTUPINFOEX"/> structure and
        /// specify <see cref="ProcessCreationFlags.EXTENDED_STARTUPINFO_PRESENT"/> in the <paramref name="dwCreationFlags"/> parameter.
        /// Handles in <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> must be closed with CloseHandle when they are no longer needed.
        /// Important  The caller is responsible for ensuring that the standard handle fields in <see cref="STARTUPINFO"/> contain valid handle values.
        /// These fields are copied unchanged to the child process without validation,
        /// even when the dwFlags member specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information about the new process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </returns>
        /// <remarks>
        /// The process is assigned a process identifier.
        /// The identifier is valid until the process terminates.
        /// It can be used to identify the process, or specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in the <see cref="PROCESS_INFORMATION"/> structure.
        /// The name of the executable in the command line that the operating system provides to a process is not necessarily identical
        /// to that in the command line that the calling process gives to the <see cref="CreateProcess"/> function.
        /// The operating system may prepend a fully qualified path to an executable name that is provided without a fully qualified path.
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait until the new process has finished its initialization
        /// and is waiting for user input with no input pending.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to find a window associated with the new process.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcess"/> returns without waiting for the new process to finish its initialization.
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// A parent process can directly alter the environment variables of a child process during process creation.
        /// This is the only situation when a process can directly change the environment settings of another process.
        /// For more information, see Changing Environment Variables.
        /// If an application provides an environment block,
        /// the current directory information of the system drives is not automatically propagated to the new process.
        /// For example, there is an environment variable named =C: whose value is the current directory on drive C.
        /// An application must manually pass the current directory information to the new process.
        /// To do so, the application must explicitly create these environment variable strings,
        /// sort them alphabetically (because the system uses a sorted environment), and put them into the environment block.
        /// Typically, they will go at the front of the environment block, due to the environment block sort order.
        /// One way to obtain the current directory information for a drive X is to make the following call: GetFullPathName("X:", ...).
        /// That avoids an application having to scan the environment block.
        /// If the full path returned is X:, there is no need to pass that value on as environment data,
        /// since the root directory is the default current directory for drive X of a new process.
        /// When a process is created with <see cref="ProcessCreationFlags.CREATE_NEW_PROCESS_GROUP"/> specified,
        /// an implicit call to SetConsoleCtrlHandler(NULL,TRUE) is made on behalf of the new process;
        /// this means that the new process has CTRL+C disabled.
        /// This lets shells handle CTRL+C themselves, and selectively pass that signal on to sub-processes.
        /// CTRL+BREAK is not disabled, and may be used to interrupt the process/process group.
        /// By default, passing <see langword="true"/> as the value of the <paramref name="bInheritHandles"/> parameter
        /// causes all inheritable handles to be inherited by the new process.
        /// This can be problematic for applications which create processes from multiple threads simultaneously
        /// yet desire each process to inherit different handles.
        /// Applications can use the <see cref="UpdateProcThreadAttributeList"/> function
        /// with the PROC_THREAD_ATTRIBUTE_HANDLE_LIST parameter to provide a list of handles to be inherited by a particular process.
        /// 
        /// Security Remarks
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see langword="null"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable
        /// could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcess(NULL, szCmdline, /* ... */);
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcess"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcess(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcess([MarshalAs(UnmanagedType.LPWStr)][In]string lpApplicationName,
          [MarshalAs(UnmanagedType.LPWStr)][In]string lpCommandLine,
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpProcessAttributes,
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpThreadAttributes,
          [In]bool bInheritHandles, [In]ProcessCreationFlags dwCreationFlags, [MarshalAs(UnmanagedType.LPWStr)][In]string lpEnvironment,
          [MarshalAs(UnmanagedType.LPWStr)][In]string lpCurrentDirectory,
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))][In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo,
          [Out]out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread.
        /// The new process runs in the security context of the user represented by the specified token.
        /// Typically, the process that calls the <see cref="CreateProcessAsUser"/> function must have the <see cref="SE_INCREASE_QUOTA_NAME"/> privilege
        /// and may require the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege if the token is not assignable.
        /// If this function fails with <see cref="SystemErrorCodes.ERROR_PRIVILEGE_NOT_HELD"/>,
        /// use the <see cref="CreateProcessWithLogonW"/> function instead.
        /// <see cref="CreateProcessWithLogonW"/> requires no special privileges,
        /// but the specified user account must be allowed to log on interactively.
        /// Generally, it is best to use <see cref="CreateProcessWithLogonW"/> to create a process with alternate credentials.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-createprocessasuserw
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// A handle to the primary token that represents a user.
        /// The handle must have the <see cref="TOKEN_QUERY"/>, <see cref="TOKEN_DUPLICATE"/>, and <see cref="TOKEN_ASSIGN_PRIMARY"/> access rights.
        /// For more information, see Access Rights for Access-Token Objects.
        /// The user represented by the token must have read and execute access to the application specified by
        /// the <paramref name="lpApplicationName"/> or the <paramref name="lpCommandLine"/> parameter.
        /// To get a primary token that represents the specified user, call the <see cref="LogonUser"/> function.
        /// Alternatively, you can call the <see cref="DuplicateTokenEx"/> function to convert an impersonation token into a primary token.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// If <paramref name="hToken"/> is a restricted version of the caller's primary token,
        /// the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege is not required.
        /// If the necessary privileges are not already enabled, <see cref="CreateProcessAsUser"/> enables them for the duration of the call.
        /// For more information, see Running with Special Privileges.
        /// Terminal Services:  The process is run in the session specified in the token.
        /// By default, this is the same session that called <see cref="LogonUser"/>.
        /// To change the session, use the <see cref="SetTokenInformation"/> function.
        /// </param>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path.
        /// This parameter must include the file name extension; no default extension is assumed.
        /// The <paramref name="lpApplicationName"/> parameter can be <see langword="null"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCommandLine"/> string.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be NULL,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// By default, all 16-bit Windows-based applications created by <see cref="CreateProcessAsUser"/> are run in a separate VDM
        /// (equivalent to <see cref="ProcessCreationFlags.CREATE_SEPARATE_WOW_VDM"/> in <see cref="CreateProcess"/>).
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed.
        /// The maximum length of this string is 32,768 characters, including the Unicode terminating null character.
        /// If lpApplicationName is <see langword="null"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// The Unicode version of this function, <see cref="CreateProcess"/>, can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// The <paramref name="lpCommandLine"/> parameter can be <see langword="null"/>.
        /// In that case, the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-NULL,
        /// the null-terminated string pointed to by <paramref name="lpApplicationName"/> specifies the module to execute,
        /// and the null-terminated string pointed to by <paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and
        /// the arguments begin (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// 1.The directory from which the application loaded.
        /// 2. The current directory for the parent process.
        /// 3. The 32-bit Windows system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// 4.The 16-bit Windows system directory. 
        /// There is no function that obtains the path of this directory, but it is searched. The name of this directory is System.
        /// 5. The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// 6.The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// The system adds a terminating null character to the command-line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </param>
        /// <param name="lpProcessAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether
        /// the returned handle to the new process object can be inherited by child processes.
        /// If <paramref name="lpProcessAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new process.
        /// If <paramref name="lpProcessAttributes"/> is <see langword="null"/> or
        /// <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="IntPtr.Zero"/>, the process gets a default security descriptor
        /// and the handle cannot be inherited..
        /// The default security descriptor is that of the user referenced in the <paramref name="hToken"/> parameter.
        /// This security descriptor may not allow access for the caller, in which case the process may not be opened again after it is run.
        /// The process handle is valid and will continue to have full access rights.
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether
        /// the returned handle to the new thread object can be inherited by child processes.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the main thread.
        /// If <paramref name="lpThreadAttributes"/> is <see langword="null"/> or
        /// <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="IntPtr.Zero"/>, the thread gets a default security descriptor
        /// and the handle cannot be inherited.
        /// The default security descriptor is that of the user referenced in the <paramref name="hToken"/> parameter.
        /// This security descriptor may not allow access for the caller.
        /// </param>
        /// <param name="bInheritHandles">
        /// If this parameter is <see langword="true"/>, each inheritable handle in the calling process is inherited by the new process.
        /// If the parameter is <see langword="false"/>, the handles are not inherited.
        /// Note that inherited handles have the same value and access rights as the original handles.
        /// For additional discussion of inheritable handles, see Remarks.
        /// Terminal Services:  You cannot inherit handles across sessions.
        /// Additionally, if this parameter is <see langword="true"/>, you must create the process in the same session as the caller.
        /// Protected Process Light (PPL) processes:  The generic handle inheritance is blocked
        /// when a PPL process creates a non-PPL process since <see cref="PROCESS_DUP_HANDLE"/> is not allowed from a non-PPL process to a PPL process.
        /// See Process Security and Access Rights
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control the priority class and the creation of the process.
        /// For a list of values, see Process Creation Flags.
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="ProcessPriorityClasses.NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="ProcessPriorityClasses.IDLE_PRIORITY_CLASS"/> 
        /// or <see cref="ProcessPriorityClasses.BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to the environment block for the new process.
        /// If this parameter is <see langword="null"/>, the new process uses the environment of the calling process.
        /// An environment block consists of a null-terminated block of null-terminated strings.
        /// Each string is in the following form: name=value\0
        /// Because the equal sign is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain either Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// be sure that <paramref name="dwCreationFlags"/> includes <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/>.
        /// If this parameter is <see langword="null"/> and the environment block of the parent process contains Unicode characters,
        /// you must also ensure that <paramref name="dwCreationFlags"/> includes <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/>.
        /// The ANSI version of this function, <see cref="CreateProcessAsUser"/> fails if the total size of
        /// the environment block for the process exceeds 32,767 characters.
        /// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
        /// Windows Server 2003 and Windows XP:  If the size of the combined user and system environment variable exceeds 8192 bytes, 
        /// the process created by CreateProcessAsUser no longer runs with the environment block passed to the function by the parent process.
        /// Instead, the child process runs with the environment block returned by the <see cref="CreateEnvironmentBlock"/> function.
        /// To retrieve a copy of the environment block for a given user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is <see langword="null"/>, the new process will have the same current drive and directory as the calling process.
        /// (This feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> structure.
        /// To set extended attributes, use a <see cref="STARTUPINFOEX"/> structure and
        /// specify <see cref="ProcessCreationFlags.EXTENDED_STARTUPINFO_PRESENT"/> in the <paramref name="dwCreationFlags"/> parameter.
        /// Handles in <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> must be closed
        /// with <see cref="CloseHandle"/> when they are no longer needed.
        /// Important  The caller is responsible for ensuring that the standard handle fields in <see cref="STARTUPINFO"/> contain valid handle values.
        /// These fields are copied unchanged to the child process without validation,
        /// even when the dwFlags member specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information about the new process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="CreateProcessAsUser"/> must be able to open the primary token of the calling process
        /// with the <see cref="TOKEN_DUPLICATE"/> and <see cref="TOKEN_IMPERSONATE"/> access rights.
        /// By default, <see cref="CreateProcessAsUser"/> creates the new process on a noninteractive window station
        /// with a desktop that is not visible and cannot receive user input.
        /// To enable user interaction with the new process, you must specify the name of
        /// the default interactive window station and desktop, "winsta0\default", in the <see cref="STARTUPINFO.lpDesktop"/> member
        /// of the <see cref="STARTUPINFO"/> structure.
        /// In addition, before calling <see cref="CreateProcessAsUser"/>, you must change the discretionary access control list (DACL) of both
        /// the default interactive window station and the default desktop.
        /// The DACLs for the window station and desktop must grant access to the user or the logon session
        /// represented by the <paramref name="hToken"/> parameter.
        /// <see cref="CreateProcessAsUser"/> does not load the specified user's profile into the HKEY_USERS registry key.
        /// Therefore, to access the information in the HKEY_CURRENT_USER registry key,
        /// you must load the user's profile information into HKEY_USERS with the <see cref="LoadUserProfile"/> function
        /// before calling <see cref="CreateProcessAsUser"/>.
        /// Be sure to call <see cref="UnloadUserProfile"/> after the new process exits.
        /// If the <paramref name="lpEnvironment"/> parameter is <see langword="null"/>, the new process inherits the environment of the calling process.
        /// <see cref="CreateProcessAsUser"/> does not automatically modify the environment block to include environment variables
        /// specific to the user represented by <paramref name="hToken"/>.
        /// For example, the USERNAME and USERDOMAIN variables are inherited from the calling process
        /// if <paramref name="lpEnvironment"/> is <see langword="null"/>.
        /// It is your responsibility to prepare the environment block for the new process and specify it in <paramref name="lpEnvironment"/>.
        /// The <see cref="CreateProcessWithLogonW"/> and <see cref="CreateProcessWithTokenW"/> functions are similar to
        /// <see cref="CreateProcessAsUser"/>, except that the caller does not need to call the <see cref="LogonUser"/> function
        /// to authenticate the user and get a token.
        /// <see cref="CreateProcessAsUser"/> allows you to access the specified directory and executable image in the security context
        /// of the caller or the target user.
        /// By default, <see cref="CreateProcessAsUser"/> accesses the directory and executable image in the security context of the caller.
        /// In this case, if the caller does not have access to the directory and executable image, the function fails.
        /// To access the directory and executable image using the security context of the target user, specify <paramref name="hToken"/> in a call
        /// to the <see cref="ImpersonateLoggedOnUser"/> function before calling <see cref="CreateProcessAsUser"/>.
        /// The process is assigned a process identifier.
        /// The identifier is valid until the process terminates.
        /// It can be used to identify the process, or specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in the <see cref="PROCESS_INFORMATION"/> structure.
        /// The name of the executable in the command line that the operating system provides to a process is not necessarily identical
        /// to that in the command line that the calling process gives to the <see cref="CreateProcess"/> function.
        /// The operating system may prepend a fully qualified path to an executable name that is provided without a fully qualified path.
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait until the new process has finished its initialization
        /// and is waiting for user input with no input pending.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to find a window associated with the new process.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcess"/> returns without waiting for the new process to finish its initialization.
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// By default, passing <see langword="true"/> as the value of the <paramref name="bInheritHandles"/> parameter
        /// causes all inheritable handles to be inherited by the new process.
        /// This can be problematic for applications which create processes from multiple threads simultaneously
        /// yet desire each process to inherit different handles.
        /// Applications can use the <see cref="UpdateProcThreadAttributeList"/> function
        /// with the PROC_THREAD_ATTRIBUTE_HANDLE_LIST parameter to provide a list of handles to be inherited by a particular process.
        /// 
        /// Security Remarks
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see langword="null"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable
        /// could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcess(NULL, szCmdline, /* ... */);
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessAsUser"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcess(NULL, szCmdline, /*...*/);
        /// </code>
        /// PowerShell:  When the <see cref="CreateProcessAsUser"/> function is used to implement a cmdlet in PowerShell version 2.0,
        /// the cmdlet operates correctly for both fan-in and fan-out remote sessions.
        /// Because of certain security scenarios, however, a cmdlet implemented with <see cref="CreateProcessAsUser"/> only operates correctly
        /// in PowerShell version 3.0 for fan-in remote sessions; fan-out remote sessions will fail because of insufficient client security privileges.
        /// To implement a cmdlet that works for both fan-in and fan-out remote sessions in PowerShell version 3.0,
        /// use the <see cref="CreateProcess"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessAsUserW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcessAsUser([In]IntPtr hToken, [MarshalAs(UnmanagedType.LPWStr)][In]string lpApplicationName,
          [MarshalAs(UnmanagedType.LPWStr)][In]string lpCommandLine,
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpProcessAttributes,
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpThreadAttributes,
          [In]bool bInheritHandles, [In]ProcessCreationFlags dwCreationFlags, [MarshalAs(UnmanagedType.LPWStr)][In]string lpEnvironment,
          [MarshalAs(UnmanagedType.LPWStr)][In]string lpCurrentDirectory,
          [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))][In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo,
          [Out]out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread. Then the new process runs the specified executable file in the security context
        /// of the specified credentials (user, domain, and password).
        /// It can optionally load the user profile for a specified user.
        /// This function is similar to the <see cref="CreateProcessAsUser"/> and <see cref="CreateProcessWithTokenW"/> functions,
        /// except that the caller does not need to call the <see cref="LogonUser"/> function to authenticate the user and get a token.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createprocesswithlogonw
        /// </para>
        /// </summary>
        /// <param name="lpUsername">
        /// The name of the user.
        /// This is the name of the user account to log on to.
        /// If you use the UPN format, user@DNS_domain_name, the lpDomain parameter must be <see langword="null"/>.
        /// The user account must have the Log On Locally permission on the local computer.
        /// This permission is granted to all users on workstations and servers, but only to administrators on domain controllers.
        /// </param>
        /// <param name="lpDomain">
        /// The name of the domain or server whose account database contains the <paramref name="lpUsername"/> account.
        /// If this parameter is <see langword="null"/>, the user name must be specified in UPN format.
        /// </param>
        /// <param name="lpPassword">
        /// The clear-text password for the <paramref name="lpUsername"/> account.
        /// </param>
        /// <param name="dwLogonFlags">
        /// The logon option. This parameter can be 0 (zero) or one of the following values.
        /// <see cref="LogonFlags.LOGON_WITH_PROFILE"/>, <see cref="LogonFlags.LOGON_NETCREDENTIALS_ONLY"/>
        /// </param>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path.
        /// This parameter must include the file name extension; no default extension is assumed.
        /// The <paramref name="lpApplicationName"/> parameter can be <see langword="null"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCommandLine"/> string.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be NULL,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed.
        /// The maximum length of this string is 1024 characters.
        /// If lpApplicationName is <see langword="null"/>,
        /// the module name portion of <paramref name="lpCommandLine"/> is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// The function can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// The <paramref name="lpCommandLine"/> parameter can be <see langword="null"/>,
        /// and the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-NULL,
        /// the null-terminated string pointed to by <paramref name="lpApplicationName"/> specifies the module to execute,
        /// and the null-terminated string pointed to by <paramref name="lpCommandLine"/> specifies the command line.
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and
        /// the arguments begin (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// 1.The directory from which the application loaded.
        /// 2. The current directory for the parent process.
        /// 3. The 32-bit Windows system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// 4.The 16-bit Windows system directory. 
        /// There is no function that obtains the path of this directory, but it is searched. The name of this directory is System.
        /// 5. The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// 6.The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// The system adds a terminating null character to the command-line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control how the process is created.
        /// The <see cref="ProcessCreationFlags.CREATE_DEFAULT_ERROR_MODE"/>, <see cref="ProcessCreationFlags.CREATE_NEW_CONSOLE"/>,
        /// and <see cref="ProcessCreationFlags.CREATE_NEW_PROCESS_GROUP"/> flags are enabled by default— even if you do not set the flag,
        /// the system functions as if it were set. You can specify additional flags as noted.
        /// <see cref="ProcessCreationFlags.CREATE_DEFAULT_ERROR_MODE"/>, <see cref="ProcessCreationFlags.CREATE_NEW_CONSOLE"/>,
        /// <see cref="ProcessCreationFlags.CREATE_NEW_PROCESS_GROUP"/>, <see cref="ProcessCreationFlags.CREATE_SEPARATE_WOW_VDM"/>,
        /// <see cref="ProcessCreationFlags.CREATE_SUSPENDED"/>, <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/>
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="ProcessPriorityClasses.NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="ProcessPriorityClasses.IDLE_PRIORITY_CLASS"/>
        /// or <see cref="ProcessPriorityClasses.BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to an environment block for the new process.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the new process uses an environment created
        /// from the profile of the user specified by <paramref name="lpUsername"/>.
        /// An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:
        /// name=value
        /// Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// ensure that <paramref name="dwCreationFlags"/> includes <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/>.
        /// If this parameter is <see cref="IntPtr.Zero"/> and the environment block of the parent process contains Unicode characters,
        /// you must also ensure that <paramref name="dwCreationFlags"/> includes <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/>.
        /// An ANSI environment block is terminated by two 0 (zero) bytes: one for the last string and one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
        /// To retrieve a copy of the environment block for a specific user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is <see langword="null"/>, the new process has the same current drive and directory as the calling process.
        /// This feature is provided primarily for shells that need to start an application, and specify its initial drive and working directory.
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure.
        /// The application must add permission for the specified user account to the specified window station and desktop, even for WinSta0\Default.
        /// If the <see cref="STARTUPINFO.lpDesktop"/> member is <see cref="IntPtr.Zero"/> or an empty string,
        /// the new process inherits the desktop and window station of its parent process.
        /// The application must add permission for the specified user account to the inherited window station and desktop.
        /// Windows XP:  <see cref="CreateProcessWithLogonW"/> adds permission for the specified user account to the inherited window station and desktop.
        /// Handles in <see cref="STARTUPINFO"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// If the <see cref="STARTUPINFO.dwFlags"/> member of the <see cref="STARTUPINFO"/> structure
        /// specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>, 
        /// the standard handle fields are copied unchanged to the child process without validation.
        /// The caller is responsible for ensuring that these fields contain valid handle values.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information for the new process,
        /// including a handle to the process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with the <see cref="CloseHandle"/> function when they are not needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </returns>
        /// <remarks>
        /// By default, <see cref="CreateProcessWithLogonW"/> does not load the specified user profile into the HKEY_USERS registry key.
        /// This means that access to information in the HKEY_CURRENT_USER registry key may not produce results that are consistent
        /// with a normal interactive logon.
        /// It is your responsibility to load the user registry hive into HKEY_USERS before calling <see cref="CreateProcessWithLogonW"/>,
        /// by using <see cref="LogonFlags.LOGON_WITH_PROFILE"/>, or by calling the <see cref="LoadUserProfile"/> function.
        /// If the <paramref name="lpEnvironment"/> parameter is <see cref="IntPtr.Zero"/>,
        /// the new process uses an environment block created from the profile of the user specified by <paramref name="lpUsername"/>.
        /// If the HOMEDRIVE and HOMEPATH variables are not set, <see cref="CreateProcessWithLogonW"/> modifies the environment block
        /// to use the drive and path of the user's working directory.
        /// When created, the new process and thread handles receive full access rights
        /// (<see cref="PROCESS_ALL_ACCESS"/> and <see cref="THREAD_ALL_ACCESS"/>).
        /// For either handle, if a security descriptor is not provided, the handle can be used in any function that requires an object handle of that type.
        /// When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before access is granted.
        /// If access is denied, the requesting process cannot use the handle to gain access to the process or thread.
        /// To retrieve a security token, pass the process handle in the <see cref="PROCESS_INFORMATION"/> structure
        /// to the <see cref="OpenProcessToken"/> function.
        /// The process is assigned a process identifier. The identifier is valid until the process terminates.
        /// It can be used to identify the process, or it can be specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in <see cref="PROCESS_INFORMATION"/>.
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait until the new process has completed
        /// its initialization and is waiting for user input with no input pending.
        /// This can be useful for synchronization between parent and child processes
        /// , because <see cref="CreateProcessWithLogonW"/> returns without waiting for the new process to finish its initialization.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to
        /// find a window that is associated with the new process.
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated 
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// <see cref="CreateProcessWithLogonW"/> accesses the specified directory and executable image in the security context of the target user.
        /// If the executable image is on a network and a network drive letter is specified in the path,
        /// the network drive letter is not available to the target user, as network drive letters can be assigned for each logon.
        /// If a network drive letter is specified, this function fails. If the executable image is on a network, use the UNC path.
        /// There is a limit to the number of child processes that can be created by this function and run simultaneously.
        /// For example, on Windows XP, this limit is <see cref="MAXIMUM_WAIT_OBJECTS"/>*4.
        /// However, you may not be able to create this many processes due to system-wide quota limits.
        /// Windows XP with SP2,Windows Server 2003, or later:  You cannot call <see cref="CreateProcessWithLogonW"/> from a process
        /// that is running under the "LocalSystem" account, because the function uses the logon SID in the caller token,
        /// and the token for the "LocalSystem" account does not contain this SID.
        /// As an alternative, use the <see cref="CreateProcessAsUser"/> and <see cref="LogonUser"/> functions.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// 
        /// Security Remarks
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see langword="null"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable
        /// could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcessWithLogonW(NULL, szCmdline, /* ... */);
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessWithLogonW"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcessWithLogonW(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessWithLogonW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcessWithLogonW([MarshalAs(UnmanagedType.LPWStr)][In]string lpUsername,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpDomain, [MarshalAs(UnmanagedType.LPWStr)][In]string lpPassword,
            [In]LogonFlags dwLogonFlags, [MarshalAs(UnmanagedType.LPWStr)][In]string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpCommandLine, [In]ProcessCreationFlags dwCreationFlags,
            [In]IntPtr lpEnvironment, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCurrentDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))][In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo,
            [Out]out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// <para>
        /// Creates a new process and its primary thread. The new process runs in the security context of the specified token.
        /// It can optionally load the user profile for the specified user.
        /// The process that calls CreateProcessWithTokenW must have the <see cref="SE_IMPERSONATE_NAME"/> privilege.
        /// If this function fails with <see cref="SystemErrorCodes.ERROR_PRIVILEGE_NOT_HELD"/>, use the <see cref="CreateProcessAsUser"/>
        /// or <see cref="CreateProcessWithLogonW"/> function instead.
        /// Typically, the process that calls <see cref="CreateProcessAsUser"/> must have the <see cref="SE_INCREASE_QUOTA_NAME"/> privilege
        /// and may require the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege if the token is not assignable.
        /// <see cref="CreateProcessWithLogonW"/> requires no special privileges, but the specified user account must be allowed to log on interactively.
        /// Generally, it is best to use <see cref="CreateProcessWithLogonW"/> to create a process with alternate credentials.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createprocesswithtokenw
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// A handle to the primary token that represents a user.
        /// The handle must have the <see cref="TOKEN_QUERY"/>, <see cref="TOKEN_DUPLICATE"/>, and <see cref="TOKEN_ASSIGN_PRIMARY"/> access rights.
        /// For more information, see Access Rights for Access-Token Objects.
        /// The user represented by the token must have read and execute access to the application specified
        /// by the <paramref name="lpApplicationName"/> or the <paramref name="lpCommandLine"/> parameter.
        /// To get a primary token that represents the specified user, call the LogonUser function.
        /// Alternatively, you can call the <see cref="DuplicateTokenEx"/> function to convert an impersonation token into a primary token.
        /// This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// Terminal Services:  The process is run in the session specified in the token.
        /// By default, this is the same session that called <see cref="LogonUser"/>.
        /// To change the session, use the <see cref="SetTokenInformation"/> function.
        /// </param>
        /// <param name="dwLogonFlags">
        /// The logon option. This parameter can be zero or one of the following values.
        /// <see cref="LogonFlags.LOGON_WITH_PROFILE"/>, <see cref="LogonFlags.LOGON_NETCREDENTIALS_ONLY"/>
        /// </param>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application.
        /// It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name.
        /// In the case of a partial name, the function uses the current drive and current directory to complete the specification.
        /// The function will not use the search path. This parameter must include the file name extension; no default extension is assumed.
        /// The <paramref name="lpApplicationName"/> parameter can be <see langword="null"/>.
        /// In that case, the module name must be the first white space–delimited token in the <paramref name="lpCurrentDirectory"/> string.
        /// If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin;
        /// otherwise, the file name is ambiguous.
        /// For example, consider the string "c:\program files\sub dir\program name".
        /// This string can be interpreted in a number of ways.
        /// The system tries to interpret the possibilities in the following order:
        /// c:\program.exe c:\program files\sub.exe c:\program files\sub dir\program.exe c:\program files\sub dir\program name.exe
        /// If the executable module is a 16-bit application, <paramref name="lpApplicationName"/> should be <see langword="null"/>,
        /// and the string pointed to by <paramref name="lpCommandLine"/> should specify the executable module as well as its arguments.
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed.
        /// The maximum length of this string is 1024 characters.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>, the module name
        /// portion of <paramref name="lpCommandLine"/> is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// The function can modify the contents of this string.
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).
        /// If this parameter is a constant string, the function may cause an access violation.
        /// The <paramref name="lpCommandLine"/> parameter can be <see langword="null"/>.
        /// In that case, the function uses the string pointed to by <paramref name="lpApplicationName"/> as the command line.
        /// If both <paramref name="lpApplicationName"/> and <paramref name="lpCommandLine"/> are non-NULL,
        /// <paramref name="lpApplicationName"/> specifies the module to execute, and <paramref name="lpCommandLine"/> specifies the command line. 
        /// The new process can use <see cref="GetCommandLine"/> to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse the command line.
        /// Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If <paramref name="lpApplicationName"/> is <see langword="null"/>,
        /// the first white space–delimited token of the command line specifies the module name.
        /// If you are using a long file name that contains a space, use quoted strings to indicate
        /// where the file name ends and the arguments begin (see the explanation for the <paramref name="lpApplicationName"/> parameter).
        /// If the file name does not contain an extension, .exe is appended.
        /// Therefore, if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// If the file name does not contain a directory path, the system searches for the executable file in the following sequence:
        /// 1. The directory from which the application loaded.
        /// 2. The current directory for the parent process.
        /// 3. The 32-bit Windows system directory. Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// 4. The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.
        /// 5. The Windows directory. Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// 6. The directories that are listed in the PATH environment variable.
        /// Note that this function does not search the per-application path specified by the App Paths registry key.
        /// To include this per-application path in the search sequence, use the <see cref="ShellExecute"/> function.
        /// The system adds a null character to the command line string to separate the file name from the arguments.
        /// This divides the original string into two strings for internal processing.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control how the process is created.
        /// The <see cref="ProcessCreationFlags.CREATE_DEFAULT_ERROR_MODE"/>, <see cref="ProcessCreationFlags.CREATE_NEW_CONSOLE"/>,
        /// and <see cref="ProcessCreationFlags.CREATE_NEW_PROCESS_GROUP"/> flags are enabled by default— even if you do not set the flag,
        /// the system functions as if it were set. You can specify additional flags as noted.
        /// <see cref="ProcessCreationFlags.CREATE_DEFAULT_ERROR_MODE"/>, <see cref="ProcessCreationFlags.CREATE_NEW_CONSOLE"/>,
        /// <see cref="ProcessCreationFlags.CREATE_NEW_PROCESS_GROUP"/>, <see cref="ProcessCreationFlags.CREATE_SEPARATE_WOW_VDM"/>,
        /// <see cref="ProcessCreationFlags.CREATE_SUSPENDED"/>, <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/>,
        /// <see cref="ProcessCreationFlags.EXTENDED_STARTUPINFO_PRESENT"/>
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see <see cref="GetPriorityClass"/>.
        /// If none of the priority class flags is specified, the priority class defaults to <see cref="ProcessPriorityClasses.NORMAL_PRIORITY_CLASS"/>
        /// unless the priority class of the creating process is <see cref="ProcessPriorityClasses.IDLE_PRIORITY_CLASS"/>
        /// or <see cref="ProcessPriorityClasses.BELOW_NORMAL_PRIORITY_CLASS"/>.
        /// In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to an environment block for the new process.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the new process uses an environment created
        /// from the profile of the user specified by <paramref name="hToken"/>.
        /// An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:
        /// name=value
        /// Because the equal sign (=) is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain Unicode or ANSI characters.
        /// If the environment block pointed to by <paramref name="lpEnvironment"/> contains Unicode characters,
        /// ensure that <paramref name="dwCreationFlags"/> includes <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/>.
        /// If this parameter is <see cref="IntPtr.Zero"/> and the environment block of the parent process contains Unicode characters,
        /// you must also ensure that <paramref name="dwCreationFlags"/> includes <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/>.
        /// An ANSI environment block is terminated by two 0 (zero) bytes: one for the last string and one more to terminate the block.
        /// A Unicode environment block is terminated by four zero bytes: two for the last string and two more to terminate the block.
        /// To retrieve a copy of the environment block for a specific user, use the <see cref="CreateEnvironmentBlock"/> function.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is <see langword="null"/>, the new process has the same current drive and directory as the calling process.
        /// This feature is provided primarily for shells that need to start an application, and specify its initial drive and working directory.
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure.
        /// The application must add permission for the specified user account to the specified window station and desktop, even for WinSta0\Default.
        /// If the <see cref="STARTUPINFO.lpDesktop"/> member is <see cref="IntPtr.Zero"/> or an empty string,
        /// the new process inherits the desktop and window station of its parent process.
        /// The application must add permission for the specified user account to the inherited window station and desktop.
        /// Windows XP:  <see cref="CreateProcessWithLogonW"/> adds permission for the specified user account to the inherited window station and desktop.
        /// Handles in <see cref="STARTUPINFO"/> must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// If the <see cref="STARTUPINFO.dwFlags"/> member of the <see cref="STARTUPINFO"/> structure
        /// specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>, 
        /// the standard handle fields are copied unchanged to the child process without validation.
        /// The caller is responsible for ensuring that these fields contain valid handle values.
        /// Incorrect values can cause the child process to misbehave or crash.
        /// Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information for the new process,
        /// including a handle to the process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with the <see cref="CloseHandle"/> function when they are not needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// Note that the function returns before the process has finished initialization.
        /// If a required DLL cannot be located or fails to initialize, the process is terminated.
        /// To get the termination status of a process, call <see cref="GetExitCodeProcess"/>.
        /// </returns>
        /// <remarks>
        /// By default, <see cref="CreateProcessWithTokenW"/> does not load the specified user profile into the HKEY_USERS registry key.
        /// This means that access to information in the HKEY_CURRENT_USER registry key may not produce results that are consistent
        /// with a normal interactive logon.
        /// It is your responsibility to load the user registry hive into HKEY_USERS before calling <see cref="CreateProcessWithTokenW"/>,
        /// by using <see cref="LogonFlags.LOGON_WITH_PROFILE"/>, or by calling the <see cref="LoadUserProfile"/> function.
        /// If the <paramref name="lpEnvironment"/> parameter is <see cref="IntPtr.Zero"/>,
        /// the new process uses an environment block created from the profile of the user specified by <paramref name="hToken"/>.
        /// If the HOMEDRIVE and HOMEPATH variables are not set, <see cref="CreateProcessWithTokenW"/> modifies the environment block
        /// to use the drive and path of the user's working directory.
        /// When created, the new process and thread handles receive full access rights
        /// (<see cref="PROCESS_ALL_ACCESS"/> and <see cref="THREAD_ALL_ACCESS"/>).
        /// For either handle, if a security descriptor is not provided, the handle can be used in any function that requires an object handle of that type.
        /// When a security descriptor is provided, an access check is performed on all subsequent uses of the handle before access is granted.
        /// If access is denied, the requesting process cannot use the handle to gain access to the process or thread.
        /// To retrieve a security token, pass the process handle in the <see cref="PROCESS_INFORMATION"/> structure
        /// to the <see cref="OpenProcessToken"/> function.
        /// The process is assigned a process identifier. The identifier is valid until the process terminates.
        /// It can be used to identify the process, or it can be specified in the <see cref="OpenProcess"/> function to open a handle to the process.
        /// The initial thread in the process is also assigned a thread identifier.
        /// It can be specified in the <see cref="OpenThread"/> function to open a handle to the thread.
        /// The identifier is valid until the thread terminates and can be used to uniquely identify the thread within the system.
        /// These identifiers are returned in <see cref="PROCESS_INFORMATION"/>.
        /// The calling thread can use the <see cref="WaitForInputIdle"/> function to wait until the new process has completed
        /// its initialization and is waiting for user input with no input pending.
        /// This can be useful for synchronization between parent and child processes,
        /// because <see cref="CreateProcessWithTokenW"/> returns without waiting for the new process to finish its initialization.
        /// For example, the creating process would use <see cref="WaitForInputIdle"/> before trying to
        /// find a window that is associated with the new process.
        /// The preferred way to shut down a process is by using the <see cref="ExitProcess"/> function,
        /// because this function sends notification of approaching termination to all DLLs attached to the process.
        /// Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls <see cref="ExitProcess"/>, other threads of the process are terminated 
        /// without an opportunity to execute any additional code (including the thread termination code of attached DLLs).
        /// For more information, see Terminating a Process.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// 
        /// Security Remarks
        /// The first parameter, <paramref name="lpApplicationName"/>, can be <see langword="null"/>,
        /// in which case the executable name must be in the white space–delimited string pointed to by <paramref name="lpCommandLine"/>.
        /// If the executable or path name has a space in it, there is a risk that a different executable
        /// could be run because of the way the function parses spaces.
        /// The following example is dangerous because the function will attempt to run "Program.exe", if it exists, instead of "MyApp.exe".
        /// <code>
        /// LPTSTR szCmdline = _tcsdup(TEXT("C:\\Program Files\\MyApp -L -S"));
        /// CreateProcessWithTokenW(NULL, szCmdline, /* ... */);
        /// </code>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls <see cref="CreateProcessWithTokenW"/> using the Program Files directory will run this application
        /// instead of the intended application.
        /// To avoid this problem, do not pass <see langword="null"/> for <paramref name="lpApplicationName"/>.
        /// If you do pass <see langword="null"/> for <paramref name="lpApplicationName"/>,
        /// use quotation marks around the executable path in <paramref name="lpCommandLine"/>, as shown in the example below.
        /// <code>
        /// LPTSTR szCmdline[] = _tcsdup(TEXT("\"C:\\Program Files\\MyApp\" -L -S"));
        /// CreateProcessWithTokenW(NULL, szCmdline, /*...*/);
        /// </code>
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateProcessWithTokenW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcessWithTokenW([In]IntPtr hToken, [In]LogonFlags dwLogonFlags,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpApplicationName, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCommandLine,
            [In]ProcessCreationFlags dwCreationFlags, [In]IntPtr lpEnvironment, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCurrentDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AlternativeStructObjectMarshaler<STARTUPINFO, STARTUPINFOEX>))][In]AlternativeStructObject<STARTUPINFO, STARTUPINFOEX> lpStartupInfo,
            [Out]out PROCESS_INFORMATION lpProcessInformation);

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
        /// <see cref="ThreadCreationFlags.CREATE_SUSPENDED"/>, <see cref="ThreadCreationFlags.STACK_SIZE_PARAM_IS_A_RESERVATION"/>
        /// </param>
        /// <param name="lpThreadId">
        /// A pointer to a variable that receives the thread identifier.
        /// If this parameter is <see langword="null"/>, the thread identifier is not returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new thread.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
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
        /// If the thread is created in a runnable state (that is, if the <see cref="ThreadCreationFlags.CREATE_SUSPENDED"/> flag is not used),
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
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpThreadAttributes,
            [In]UIntPtr dwStackSize, [MarshalAs(UnmanagedType.FunctionPtr)][In]ThreadProc lpStartAddress, [In]IntPtr lpParameter,
            [In]ThreadCreationFlags dwCreationFlags, [Out]out uint lpThreadId);

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
        /// <see cref="ThreadCreationFlags.CREATE_SUSPENDED"/>, <see cref="ThreadCreationFlags.STACK_SIZE_PARAM_IS_A_RESERVATION"/>
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
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
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
        /// If the thread is created in a runnable state (that is, if the <see cref="ThreadCreationFlags.CREATE_SUSPENDED"/> flag is not used),
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
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpThreadAttributes,
            [In]UIntPtr dwStackSize, [MarshalAs(UnmanagedType.FunctionPtr)][In]ThreadProc lpStartAddress, [In]IntPtr lpParameter,
            [In]ThreadCreationFlags dwCreationFlags, [In]IntPtr lpAttributeList, [Out]out uint lpThreadId);

        /// <summary>
        /// <para>
        /// The <see cref="CreateRestrictedToken"/> function creates a new access token that is a restricted version of an existing access token.
        /// The restricted token can have disabled security identifiers (SIDs), deleted privileges, and a list of restricting SIDs.
        /// For more information, see Restricted Tokens.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/securitybaseapi/nf-securitybaseapi-createrestrictedtoken
        /// </para>
        /// </summary>
        /// <param name="ExistingTokenHandle">
        /// A handle to a primary or impersonation token.
        /// The token can also be a restricted token.
        /// The handle must have <see cref="TOKEN_DUPLICATE"/> access to the token.
        /// </param>
        /// <param name="Flags">
        /// Specifies additional privilege options.
        /// This parameter can be zero or a combination of the following values.
        /// <see cref="CreateRestrictedTokenFlags.DISABLE_MAX_PRIVILEGE"/>, <see cref="CreateRestrictedTokenFlags.SANDBOX_INERT"/>,
        /// <see cref="CreateRestrictedTokenFlags.LUA_TOKEN"/>, <see cref="CreateRestrictedTokenFlags.WRITE_RESTRICTED"/>
        /// </param>
        /// <param name="DisableSidCount">
        /// Specifies the number of entries in the <paramref name="SidsToDisable"/> array.
        /// </param>
        /// <param name="SidsToDisable">
        /// A pointer to an array of <see cref="SID_AND_ATTRIBUTES"/> structures that specify the deny-only SIDs in the restricted token.
        /// The system uses a deny-only SID to deny access to a securable object.
        /// The absence of a deny-only SID does not allow access.
        /// Disabling a SID turns on <see cref="SE_GROUP_USE_FOR_DENY_ONLY"/> and
        /// turns off <see cref="SE_GROUP_ENABLED"/> and <see cref="SE_GROUP_ENABLED_BY_DEFAULT"/>.
        /// All other attributes are ignored.
        /// Deny-only attributes apply to any combination of an existing token's SIDs, including the user SID and group SIDs
        /// that have the <see cref="SE_GROUP_MANDATORY"/> attribute.
        /// To get the SIDs associated with the existing token, use the <see cref="GetTokenInformation"/> function
        /// with the <see cref="TokenUser"/> and <see cref="TokenGroups"/> flags.
        /// The function ignores any SIDs in the array that are not also found in the existing token.
        /// The function ignores the <see cref="SID_AND_ATTRIBUTES.Attributes"/> member of the <see cref="SID_AND_ATTRIBUTES"/> structure.
        /// This parameter can be <see cref="IntPtr.Zero"/> if no SIDs are to be disabled.
        /// </param>
        /// <param name="DeletePrivilegeCount">
        /// Specifies the number of entries in the <paramref name="PrivilegesToDelete"/> array.
        /// </param>
        /// <param name="PrivilegesToDelete">
        /// A pointer to an array of <see cref="LUID_AND_ATTRIBUTES"/> structures that specify the privileges to delete in the restricted token.
        /// The <see cref="GetTokenInformation"/> function can be used with the TokenPrivileges flag to retrieve the privileges held by the existing token.
        /// The function ignores any privileges in the array that are not held by the existing token.
        /// The function ignores the <see cref="LUID_AND_ATTRIBUTES.Attributes"/> members of the <see cref="LUID_AND_ATTRIBUTES"/> structures.
        /// This parameter can be <see cref="IntPtr.Zero"/> if you do not want to delete any privileges.
        /// If the calling program passes too many privileges in this array,
        /// <see cref="CreateRestrictedToken"/> returns <see cref="SystemErrorCodes.ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <param name="RestrictedSidCount">
        /// Specifies the number of entries in the <paramref name="SidsToRestrict"/> array.
        /// </param>
        /// <param name="SidsToRestrict">
        /// A pointer to an array of <see cref="SID_AND_ATTRIBUTES"/> structures that specify a list of restricting SIDs for the new token.
        /// If the existing token is a restricted token, the list of restricting SIDs for the new token is the intersection of this array 
        /// and the list of restricting SIDs for the existing token.
        /// No check is performed to remove duplicate SIDs that were placed on the <paramref name="SidsToRestrict"/> parameter.
        /// Duplicate SIDs allow a restricted token to have redundant information in the restricting SID list.
        /// The <see cref="SID_AND_ATTRIBUTES.Attributes"/> member of the <see cref="SID_AND_ATTRIBUTES"/> structure must be zero.
        /// Restricting SIDs are always enabled for access checks.
        /// This parameter can be <see cref="IntPtr.Zero"/> if you do not want to specify any restricting SIDs.
        /// </param>
        /// <param name="NewTokenHandle">
        /// A pointer to a variable that receives a handle to the new restricted token.
        /// This handle has the same access rights as <paramref name="ExistingTokenHandle"/>.
        /// The new token is the same type, primary or impersonation, as the existing token.
        /// The handle returned in <paramref name="NewTokenHandle"/> can be duplicated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateRestrictedToken"/> function can restrict the token in the following ways:
        /// Apply the deny-only attribute to SIDs in the token so they cannot be used to access secured objects.
        /// For more information about the deny-only attribute, see SID Attributes in an Access Token.
        /// Remove privileges from the token.
        /// Specify a list of restricting SIDs, which the system uses when it checks the token's access to a securable object.
        /// The system performs two access checks: one using the token's enabled SIDs, and another using the list of restricting SIDs.
        /// Access is granted only if both access checks allow the requested access rights.
        /// You can use the restricted token in the <see cref="CreateProcessAsUser"/> function to create a process
        /// that has restricted access rights and privileges.
        /// If a process calls <see cref="CreateProcessAsUser"/> using a restricted version of its own token,
        /// the calling process does not need to have the <see cref="SE_ASSIGNPRIMARYTOKEN_NAME"/> privilege.
        /// You can use the restricted token in the <see cref="ImpersonateLoggedOnUser"/> function.
        ///  Applications that use restricted tokens should run the restricted application on desktops other than the default desktop.
        ///  This is necessary to prevent an attack by a restricted application, using <see cref="SendMessage"/> or <see cref="PostMessage"/>,
        ///  to unrestricted applications on the default desktop. 
        ///  If necessary, switch between desktops for your application purposes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRestrictedToken", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateRestrictedToken([In]IntPtr ExistingTokenHandle, [In]CreateRestrictedTokenFlags Flags, [In]uint DisableSidCount,
            [In]IntPtr SidsToDisable, [In]uint DeletePrivilegeCount, [In]IntPtr PrivilegesToDelete, [In]uint RestrictedSidCount,
            [In]IntPtr SidsToRestrict, [Out]out IntPtr NewTokenHandle);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed semaphore object.
        /// To specify an access mask for the object, use the <see cref="CreateSemaphoreEx"/> function.
        /// </para>
        /// </summary>
        /// <param name="lpSemaphoreAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If this parameter is <see langword="null"/>, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new semaphore.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the semaphore gets a default security descriptor.
        /// The ACLs in the default security descriptor for a semaphore come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lInitialCount">
        /// The initial count for the semaphore object.
        /// This value must be greater than or equal to zero and less than or equal to <paramref name="lMaximumCount"/>.
        /// The state of a semaphore is signaled when its count is greater than zero and nonsignaled when it is zero.
        /// The count is decreased by one whenever a wait function releases a thread that was waiting for the semaphore.
        /// The count is increased by a specified amount by calling the <see cref="ReleaseSemaphore"/> function.
        /// </param>
        /// <param name="lMaximumCount">
        /// The maximum count for the semaphore object. This value must be greater than zero.
        /// </param>
        /// <param name="lpName">
        /// The name of the semaphore object.
        /// The name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// Name comparison is case sensitive.
        /// If <paramref name="lpName"/> matches the name of an existing named semaphore object,
        /// this function requests the <see cref="SEMAPHORE_ALL_ACCESS"/> access right.
        /// In this case, the <paramref name="lInitialCount"/> and <paramref name="lMaximumCount"/> parameters are ignored
        /// because they have already been set by the creating process.
        /// If the <paramref name="lpSemaphoreAttributes"/> parameter is not <see langword="null"/>,
        /// it determines whether the handle can be inherited, but its security-descriptor member is ignored.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the semaphore object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, mutex, waitable timer, job, or file-mapping object,
        /// the function fails and the <see cref="Marshal.GetLastWin32Error"/> function returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace. For more information, see Object Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the semaphore object.
        /// If the named semaphore object existed before the function call, the function returns a handle to the existing object
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned by <see cref="CreateSemaphore"/> has the <see cref="SEMAPHORE_ALL_ACCESS"/> access right;
        /// it can be used in any function that requires a handle to a semaphore object, provided that the caller has been granted access.
        /// If an semaphore is created from a service or a thread that is impersonating a different user,
        /// you can either apply a security descriptor to the semaphore when you create it,
        /// or change the default security descriptor for the creating process by changing its default DACL.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// The state of a semaphore object is signaled when its count is greater than zero, and nonsignaled when its count is equal to zero.
        /// The <paramref name="lInitialCount"/> parameter specifies the initial count.
        /// The count can never be less than zero or greater than the value specified in the <paramref name="lMaximumCount"/> parameter.
        /// Any thread of the calling process can specify the semaphore-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// Each time a thread completes a wait for a semaphore object, the count of the semaphore object is decremented by one.
        /// When the thread has finished, it calls the <see cref="ReleaseSemaphore"/> function, which increments the count of the semaphore object.
        /// Multiple processes can have handles of the same semaphore object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to a semaphore object
        /// if the <paramref name="lpSemaphoreAttributes"/> parameter of <see cref="CreateSemaphore"/> enabled inheritance.
        /// A process can specify the semaphore-object handle in a call to the <see cref="DuplicateHandle"/> function
        /// to create a duplicate handle that can be used by another process.
        /// A process can specify the name of a semaphore object in a call to the <see cref="OpenSemaphore"/> or <see cref="CreateSemaphore"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The semaphore object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSemaphoreW", SetLastError = true)]
        public static extern IntPtr CreateSemaphore(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSemaphoreAttributes,
            [In]int lInitialCount, [In]int lMaximumCount, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed semaphore object.
        /// To specify an access mask for the object, use the <see cref="CreateSemaphoreEx"/> function.
        /// </para>
        /// </summary>
        /// <param name="lpSemaphoreAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If this parameter is <see langword="null"/>, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new semaphore.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the semaphore gets a default security descriptor.
        /// The ACLs in the default security descriptor for a semaphore come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lInitialCount">
        /// The initial count for the semaphore object.
        /// This value must be greater than or equal to zero and less than or equal to <paramref name="lMaximumCount"/>.
        /// The state of a semaphore is signaled when its count is greater than zero and nonsignaled when it is zero.
        /// The count is decreased by one whenever a wait function releases a thread that was waiting for the semaphore.
        /// The count is increased by a specified amount by calling the <see cref="ReleaseSemaphore"/> function.
        /// </param>
        /// <param name="lMaximumCount">
        /// The maximum count for the semaphore object. This value must be greater than zero.
        /// </param>
        /// <param name="lpName">
        /// The name of the semaphore object.
        /// The name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// Name comparison is case sensitive.
        /// If <paramref name="lpName"/> matches the name of an existing named semaphore object,
        /// this function requests the <see cref="SEMAPHORE_ALL_ACCESS"/> access right.
        /// In this case, the <paramref name="lInitialCount"/> and <paramref name="lMaximumCount"/> parameters are ignored
        /// because they have already been set by the creating process.
        /// If the <paramref name="lpSemaphoreAttributes"/> parameter is not <see langword="null"/>,
        /// it determines whether the handle can be inherited, but its security-descriptor member is ignored.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the semaphore object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, mutex, waitable timer, job, or file-mapping object,
        /// the function fails and the <see cref="Marshal.GetLastWin32Error"/> function returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace. For more information, see Object Namespaces.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is reserved and must be 0.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access mask for the semaphore object.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the semaphore object.
        /// If the named semaphore object existed before the function call, the function returns a handle to the existing object
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// The state of a semaphore object is signaled when its count is greater than zero, and nonsignaled when its count is equal to zero.
        /// The <paramref name="lInitialCount"/> parameter specifies the initial count.
        /// The count can never be less than zero or greater than the value specified in the <paramref name="lMaximumCount"/> parameter.
        /// Any thread of the calling process can specify the semaphore-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// Each time a thread completes a wait for a semaphore object, the count of the semaphore object is decremented by one.
        /// When the thread has finished, it calls the <see cref="ReleaseSemaphore"/> function, which increments the count of the semaphore object.
        /// Multiple processes can have handles of the same semaphore object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to a semaphore object
        /// if the <paramref name="lpSemaphoreAttributes"/> parameter of <see cref="CreateSemaphore"/> enabled inheritance.
        /// A process can specify the semaphore-object handle in a call to the <see cref="DuplicateHandle"/> function
        /// to create a duplicate handle that can be used by another process.
        /// A process can specify the name of a semaphore object in a call to the <see cref="OpenSemaphore"/> or <see cref="CreateSemaphore"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The semaphore object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSemaphoreExW", SetLastError = true)]
        public static extern IntPtr CreateSemaphoreEx(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSemaphoreAttributes,
            [In]int lInitialCount, [In]int lMaximumCount, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName, [In]uint dwFlags, [In]uint dwDesiredAccess);

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
        /// <see cref="ThreadCreationFlags.CREATE_SUSPENDED"/>, <see cref="ThreadCreationFlags.STACK_SIZE_PARAM_IS_A_RESERVATION"/>
        /// </param>
        /// <param name="lpThreadId">
        /// A pointer to a variable that receives the thread identifier.
        /// If this parameter is <see langword="null"/>, the thread identifier is not returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new thread.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
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
        /// If the thread is created in a runnable state (that is, if the <see cref="ThreadCreationFlags.CREATE_SUSPENDED"/> flag is not used),
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
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpThreadAttributes,
            [In]UIntPtr dwStackSize, [MarshalAs(UnmanagedType.FunctionPtr)][In] ThreadProc lpStartAddress, [In]IntPtr lpParameter,
            [In]ThreadCreationFlags dwCreationFlags, [Out]out uint lpThreadId);

        /// <summary>
        /// <para>
        /// Creates or opens a waitable timer object.
        /// To specify an access mask for the object, use the <see cref="CreateWaitableTimerEx"/> function.
        /// </para>
        /// </summary>
        /// <param name="lpTimerAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor
        /// for the new timer object and determines whether child processes can inherit the returned handle.
        /// If <paramref name="lpTimerAttributes"/> is <see langword="null"/>,
        /// the timer object gets a default security descriptor and the handle cannot be inherited.
        /// The ACLs in the default security descriptor for a timer come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="bManualReset">
        /// If this parameter is <see langword="true"/>, the timer is a manual-reset notification timer.
        /// Otherwise, the timer is a synchronization timer.
        /// </param>
        /// <param name="lpTimerName">
        /// The name of the timer object. The name is limited to MAX_PATH characters. Name comparison is case sensitive.
        /// If <param ref="lpTimerName"/> is <see langword="null"/>, the timer object is created without a name.
        /// If <param ref="lpTimerName"/> matches the name of an existing event, semaphore, mutex, job, or file-mapping object,
        /// the function fails and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace.
        /// For more information, see Object Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the timer object.
        /// If the named timer object exists before the function call, the function returns a handle to the existing object
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned by <see cref="CreateWaitableTimer"/> is created with the <see cref="TIMER_ALL_ACCESS"/> access right;
        /// it can be used in any function that requires a handle to a timer object, provided that the caller has been granted access.
        /// If a timer is created from a service or thread that is impersonating a different user,
        /// you can either apply a security descriptor to the timer when you create it,
        /// or change the default security descriptor for the creating process by changing its default DACL.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// Any thread of the calling process can specify the timer object handle in a call to one of the wait functions.
        /// Multiple processes can have handles to the same timer object, enabling use of the object for interprocess synchronization.
        /// A process created by the <see cref="CreateProcess"/> function can inherit a handle to a timer object
        /// if the <paramref name="lpTimerAttributes"/> parameter of <see cref="CreateWaitableTimer"/> enables inheritance.
        /// A process can specify the timer object handle in a call to the <see cref="DuplicateHandle"/> function.
        /// The resulting handle can be used by another process.
        /// A process can specify the name of a timer object in a call
        /// to the <see cref="OpenWaitableTimer"/> or <see cref="CreateWaitableTimer"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The timer object is destroyed when its last handle has been closed.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// To associate a timer with a window, use the <see cref="SetTimer"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWaitableTimerW", SetLastError = true)]
        public static extern IntPtr CreateWaitableTimer(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpTimerAttributes,
            [In]bool bManualReset, [MarshalAs(UnmanagedType.LPWStr)][In]string lpTimerName);

        /// <summary>
        /// <para>
        /// Creates or opens a waitable timer object and returns a handle to the object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createwaitabletimerexw
        /// </para>
        /// </summary>
        /// <param name="lpTimerAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor
        /// for the new timer object and determines whether child processes can inherit the returned handle.
        /// If <paramref name="lpTimerAttributes"/> is <see langword="null"/>,
        /// the timer object gets a default security descriptor and the handle cannot be inherited.
        /// The ACLs in the default security descriptor for a timer come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lpTimerName">
        /// The name of the timer object. The name is limited to MAX_PATH characters. Name comparison is case sensitive.
        /// If <param ref="lpTimerName"/> is <see langword="null"/>, the timer object is created without a name.
        /// If <param ref="lpTimerName"/> matches the name of an existing event, semaphore, mutex, job, or file-mapping object,
        /// the function fails and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace.
        /// For more information, see Object Namespaces.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be 0 or the following value.
        /// <see cref="CREATE_WAITABLE_TIMER_MANUAL_RESET"/>:
        /// The timer must be manually reset. Otherwise, the system automatically resets the timer after releasing a single waiting thread.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access mask for the timer object.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the timer object.
        /// If the named timer object exists before the function call, the function returns a handle to the existing object
        /// and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// Any thread of the calling process can specify the timer object handle in a call to one of the wait functions.
        /// Multiple processes can have handles to the same timer object, enabling use of the object for interprocess synchronization.
        /// A process created by the <see cref="CreateProcess"/> function can inherit a handle to a timer object
        /// if the <paramref name="lpTimerAttributes"/> parameter of <see cref="CreateWaitableTimer"/> enables inheritance.
        /// A process can specify the timer object handle in a call to the <see cref="DuplicateHandle"/> function.
        /// The resulting handle can be used by another process.
        /// A process can specify the name of a timer object in a call
        /// to the <see cref="OpenWaitableTimer"/> or <see cref="CreateWaitableTimer"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The timer object is destroyed when its last handle has been closed.
        /// To associate a timer with a window, use the <see cref="SetTimer"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWaitableTimerExW", SetLastError = true)]
        public static extern IntPtr CreateWaitableTimerEx(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))][In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpTimerAttributes,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpTimerName, [In]IntPtr dwFlags, [In]IntPtr dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Deletes an existing file.
        /// To perform this operation as a transacted operation, use the <see cref="DeleteFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-deletefilew
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file to be deleted.
        /// In the ANSI version of this function, the name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Starting in Windows 10, version 1607, for the unicode version of this function (<see cref="DeleteFile"/>),
        /// you can opt-in to remove the <see cref="Constants.MAX_PATH"/> character limitation without prepending "\\?\".
        /// See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// If an application attempts to delete a file that does not exist,
        /// the <see cref="DeleteFile"/> function fails with <see cref="SystemErrorCodes.ERROR_FILE_NOT_FOUND"/>.
        /// If the file is a read-only file, the function fails with <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// The following list identifies some tips for deleting, removing, or closing files:
        /// To delete a read-only file, first you must remove the read-only attribute.
        /// To delete or rename a file, you must have either delete permission on the file, or delete child permission in the parent directory.
        /// To recursively delete the files in a directory, use the <see cref="SHFileOperation"/> function.
        /// To remove an empty directory, use the <see cref="RemoveDirectory"/> function.
        /// To close an open file, use the <see cref="CloseHandle"/> function.
        /// If you set up a directory with all access except delete and delete child, and the access control lists (ACL) of new files are inherited,
        /// then you can create a file without being able to delete it.
        /// However, then you can create a file, and then get all the access you request on the handle that is returned to you at the time
        /// you create the file.
        /// If you request delete permission at the time you create a file, you can delete or rename the file with that handle,
        /// but not with any other handle.
        /// For more information, see File Security and Access Rights.
        /// The <see cref="DeleteFile"/> function fails if an application attempts to delete a file that has other handles open for normal I/O or
        /// as a memory-mapped file (<see cref="FileShareModes.FILE_SHARE_DELETE"/> must have been specified when other handles were opened).
        /// The <see cref="DeleteFile"/> function marks a file for deletion on close.
        /// Therefore, the file deletion does not occur until the last handle to the file is closed.
        /// Subsequent calls to <see cref="CreateFile"/> to open the file fail with <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// Symbolic link behavior—
        /// If the path points to a symbolic link, the symbolic link is deleted, not the target.
        /// To delete a target, you must call <see cref="CreateFile"/> and specify <see cref="FileFlags.FILE_FLAG_DELETE_ON_CLOSE"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteFileW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteFile([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName);

        /// <summary>
        /// <para>
        /// Deletes an existing file as a transacted operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-deletefiletransactedw
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file to be deleted.
        /// In the ANSI version of this function, the name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// The file must reside on the local computer;
        /// otherwise, the function fails and the last error code is set to <see cref="SystemErrorCodes.ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction. This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// If an application attempts to delete a file that does not exist,
        /// the <see cref="DeleteFileTransacted"/> function fails with <see cref="SystemErrorCodes.ERROR_FILE_NOT_FOUND"/>.
        /// If the file is a read-only file, the function fails with <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// The following list identifies some tips for deleting, removing, or closing files:
        /// To delete a read-only file, first you must remove the read-only attribute.
        /// To delete or rename a file, you must have either delete permission on the file, or delete child permission in the parent directory.
        /// To recursively delete the files in a directory, use the <see cref="SHFileOperation"/> function.
        /// To remove an empty directory, use the <see cref="RemoveDirectory"/> function.
        /// To close an open file, use the <see cref="CloseHandle"/> function.
        /// If you set up a directory with all access except delete and delete child, and the access control lists (ACL) of new files are inherited,
        /// then you can create a file without being able to delete it.
        /// However, then you can create a file, and then get all the access you request on the handle that is returned to you at the time
        /// you create the file.
        /// If you request delete permission at the time you create a file, you can delete or rename the file with that handle,
        /// but not with any other handle.
        /// For more information, see File Security and Access Rights.
        /// The <see cref="DeleteFileTransacted"/> function fails if an application attempts to delete a file that has other handles open
        /// for normal I/O or as a memory-mapped file (<see cref="FileShareModes.FILE_SHARE_DELETE"/> must have been specified
        /// when other handles were opened).
        /// The <see cref="DeleteFileTransacted"/> function marks a file for deletion on close.
        /// The file is deleted after the last transacted writer handle to the file is closed, provided that the transaction is still active.
        /// If a file has been marked for deletion and a transacted writer handle is still open after the transaction completes,
        /// the file will not be deleted.
        /// Symbolic link behavior—
        /// If the path points to a symbolic link, the symbolic link is deleted, not the target.
        /// To delete a target, you must call <see cref="CreateFile"/> and specify <see cref="FileFlags.FILE_FLAG_DELETE_ON_CLOSE"/>.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteFileTransactedW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteFileTransacted([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName, [In]IntPtr hTransaction);

        /// <summary>
        /// <para>
        /// Disconnects the server end of a named pipe instance from a client process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/namedpipeapi/nf-namedpipeapi-disconnectnamedpipe
        /// </para>
        /// </summary>
        /// <param name="hNamedPipe">
        /// A handle to an instance of a named pipe.
        /// This handle must be created by the <see cref="CreateNamedPipe"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// If the client end of the named pipe is open, the <see cref="DisconnectNamedPipe"/> function forces that end of the named pipe closed.
        /// The client receives an error the next time it attempts to access the pipe.
        /// A client that is forced off a pipe by <see cref="DisconnectNamedPipe"/> must still use
        /// the <see cref="CloseHandle"/> function to close its end of the pipe.
        /// The pipe exists as long as a server or client process has an open handle to the pipe.
        /// When the server process disconnects a pipe instance, any unread data in the pipe is discarded.
        /// Before disconnecting, the server can make sure data is not lost by calling the <see cref="FlushFileBuffers"/> function,
        /// which does not return until the client process has read all the data.
        /// The server process must call <see cref="DisconnectNamedPipe"/> to disconnect a pipe handle from its previous client
        /// before the handle can be connected to another client by using the <see cref="ConnectNamedPipe"/> function.
        /// Windows 10, version 1709:  Pipes are only supported within an app-container; ie, from one UWP process to another UWP process
        /// that's part of the same app. Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DisconnectNamedPipe", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisconnectNamedPipe([In]IntPtr hNamedPipe);

        /// <summary>
        /// <para>
        /// Duplicates an object handle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/handleapi/nf-handleapi-duplicatehandle
        /// </para>
        /// </summary>
        /// <param name="hSourceProcessHandle">
        /// A handle to the process with the handle to be duplicated.
        /// The handle must have the <see cref="PROCESS_DUP_HANDLE"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="hSourceHandle">
        /// The handle to be duplicated.
        /// This is an open object handle that is valid in the context of the source process.
        /// For a list of objects whose handles can be duplicated, see the following Remarks section.
        /// </param>
        /// <param name="hTargetProcessHandle">
        /// A handle to the process that is to receive the duplicated handle.
        /// The handle must have the <see cref="PROCESS_DUP_HANDLE"/> access right.
        /// </param>
        /// <param name="lpTargetHandle">
        /// A pointer to a variable that receives the duplicate handle.
        /// This handle value is valid in the context of the target process.
        /// If <paramref name="hSourceHandle"/> is a pseudo handle returned by <see cref="GetCurrentProcess"/> or <see cref="GetCurrentThread"/>,
        /// <see cref="DuplicateHandle"/> converts it to a real handle to a process or thread, respectively.
        /// If <paramref name="lpTargetHandle"/> is <see langword="null"/>, the function duplicates the handle,
        /// but does not return the duplicate handle value to the caller.
        /// This behavior exists only for backward compatibility with previous versions of this function.
        /// You should not use this feature, as you will lose system resources until the target process terminates.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access requested for the new handle.
        /// For the flags that can be specified for each object type, see the following Remarks section.
        /// This parameter is ignored if the <paramref name="dwOptions"/> parameter specifies the <see cref="DUPLICATE_SAME_ACCESS"/> flag.
        /// Otherwise, the flags that can be specified depend on the type of object whose handle is to be duplicated.
        /// </param>
        /// <param name="bInheritHandle">
        /// A variable that indicates whether the handle is inheritable.
        /// If <see langword="true"/>, the duplicate handle can be inherited by new processes created by the target process.
        /// If <see langword="false"/>, the new handle cannot be inherited.
        /// </param>
        /// <param name="dwOptions">
        /// Optional actions.
        /// This parameter can be zero, or any combination of the following values.
        /// <see cref="DuplicateHandleOptions.DUPLICATE_CLOSE_SOURCE"/>, <see cref="DuplicateHandleOptions.DUPLICATE_SAME_ACCESS"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// The duplicate handle refers to the same object as the original handle.
        /// Therefore, any changes to the object are reflected through both handles
        /// . For example, if you duplicate a file handle, the current file position is always the same for both handles.
        /// For file handles to have different file positions, use the <see cref="CreateFile"/> function to
        /// create file handles that share access to the same file.
        /// <see cref="DuplicateHandle"/> can be called by either the source process or the target process
        /// (or a process that is both the source and target process).
        /// For example, a process can use <see cref="DuplicateHandle"/> to create a noninheritable duplicate of an inheritable handle,
        /// or a handle with different access than the original handle.
        /// The source process uses the <see cref="GetCurrentProcess"/> function to get a handle to itself.
        /// This handle is a pseudo handle, but <see cref="DuplicateHandle"/> converts it to a real process handle.
        /// To get the target process handle, it may be necessary to use some form of interprocess communication
        /// (for example, a named pipe or shared memory) to communicate the process identifier to the source process.
        /// The source process can use this identifier in the <see cref="OpenProcess"/> function to obtain a handle to the target process.
        /// If the process that calls <see cref="DuplicateHandle"/> is not also the target process,
        /// the source process must use interprocess communication to pass the value of the duplicate handle to the target process.
        /// <see cref="DuplicateHandle"/> can be used to duplicate a handle between a 32-bit process and a 64-bit process.
        /// The resulting handle is appropriately sized to work in the target process.
        /// For more information, see Process Interoperability.
        /// <see cref="DuplicateHandle"/> can duplicate handles to the following types of objects.
        /// Access token:
        /// The handle is returned by the <see cref="CreateRestrictedToken"/>, <see cref="DuplicateToken"/>, <see cref="DuplicateTokenEx"/>,
        /// <see cref="OpenProcessToken"/>, or <see cref="OpenThreadToken"/> function.
        /// Change notification:
        /// The handle is returned by the <see cref="FindFirstChangeNotification"/> function.
        /// Communications device:
        /// The handle is returned by the <see cref="CreateFile"/> function.
        /// Console input:
        /// The handle is returned by the <see cref="CreateFile"/> function when CONIN$ is specified,
        /// or by the <see cref="GetStdHandle"/> function when <see cref="STD_INPUT_HANDLE"/> is specified.
        /// Console handles can be duplicated for use only in the same process.
        /// Console screen buffer:
        /// The handle is returned by the <see cref="CreateFile"/> function when CONOUT$ is specified,
        /// or by the <see cref="GetStdHandle"/> function when <see cref="STD_OUTPUT_HANDLE"/> is specified.
        /// Console handles can be duplicated for use only in the same process.
        /// Desktop:
        /// The handle is returned by the <see cref="GetThreadDesktop"/> function.
        /// Event:
        /// The handle is returned by the <see cref="CreateEvent"/> or <see cref="OpenEvent"/> function.
        /// File:
        /// The handle is returned by the <see cref="CreateFile"/> function.
        /// File mapping:
        /// The handle is returned by the <see cref="CreateFileMapping"/> function.
        /// Job:
        /// The handle is returned by the <see cref="CreateJobObject"/> function.
        /// Mailslot:
        /// The handle is returned by the <see cref="CreateMailslot"/> function.
        /// Mutex:
        /// The handle is returned by the <see cref="CreateMutex"/> or <see cref="OpenMutex"/> function.
        /// Pipe:
        /// A named pipe handle is returned by the <see cref="CreateNamedPipe"/> or <see cref="CreateFile"/> function.
        /// An anonymous pipe handle is returned by the <see cref="CreatePipe"/> function.
        /// Process:
        /// The handle is returned by the <see cref="CreateProcess"/>, <see cref="GetCurrentProcess"/>, or <see cref="OpenProcess"/> function.
        /// Registry key:
        /// The handle is returned by the <see cref="RegCreateKey"/>, <see cref="RegCreateKeyEx"/>,
        /// <see cref="RegOpenKey"/>, or <see cref="RegOpenKeyEx"/> function.
        /// Note that registry key handles returned by the <see cref="RegConnectRegistry"/> function
        /// cannot be used in a call to <see cref="DuplicateHandle"/>.
        /// Semaphore:
        /// The handle is returned by the <see cref="CreateSemaphore"/> or <see cref="OpenSemaphore"/> function.
        /// Thread:
        /// The handle is returned by the <see cref="CreateProcess"/>, <see cref="CreateThread"/>,
        /// <see cref="CreateRemoteThread"/>, or <see cref="GetCurrentThread"/> function.
        /// Timer:
        /// The handle is returned by the <see cref="CreateWaitableTimer"/> or <see cref="OpenWaitableTimer"/> function.
        /// Transaction:
        /// The handle is returned by the <see cref="CreateTransaction"/> function.
        /// Window station:
        /// The handle is returned by the <see cref="GetProcessWindowStation"/> function.
        /// You should not use <see cref="DuplicateHandle"/> to duplicate handles to the following objects:
        /// I/O completion ports. No error is returned, but the duplicate handle cannot be used.
        /// Sockets. No error is returned, but the duplicate handle may not be recognized by Winsock at the target process.
        /// Also, using <see cref="DuplicateHandle"/> interferes with internal reference counting on the underlying object.
        /// To duplicate a socket handle, use the <see cref="WSADuplicateSocket"/> function.
        /// Pseudo-handles other than the ones returned by the <see cref="GetCurrentProcess"/> or <see cref="GetCurrentThread"/> functions.
        /// The dwDesiredAccess parameter specifies the new handle's access rights. All objects support the standard access rights.
        /// Objects may also support additional access rights depending on the object type.
        /// For more information, see the following topics:
        /// Desktop Security and Access Rights
        /// File Security and Access Rights
        /// File-Mapping Security and Access Rights
        /// Job Object Security and Access Rights
        /// Process Security and Access Rights
        /// Registry Key Security and Access Rights
        /// Synchronization Object Security and Access Rights
        /// Thread Security and Access Rights
        /// Window-Station Security and Access Rights
        /// In some cases, the new handle can have more access rights than the original handle.
        /// However, in other cases, <see cref="DuplicateHandle"/> cannot create a handle with more access rights than the original.
        /// For example, a file handle created with the <see cref="GenericAccessRights.GENERIC_READ"/> access right cannot be duplicated
        /// so that it has both the <see cref="GenericAccessRights.GENERIC_READ"/> and <see cref="GenericAccessRights.GENERIC_WRITE"/> access right.
        /// Normally the target process closes a duplicated handle when that process is finished using the handle.
        /// To close a duplicated handle from the source process, call <see cref="DuplicateHandle"/> with the following parameters:
        /// Set <paramref name="hSourceProcessHandle"/> to the target process from the <see cref="DuplicateHandle"/> call that created the handle.
        /// Set <paramref name="hSourceHandle"/> to the duplicated handle to close.
        /// Set <paramref name="lpTargetHandle"/> to NULL.
        /// Set <paramref name="dwOptions"/> to <see cref="DuplicateHandleOptions.DUPLICATE_CLOSE_SOURCE"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateHandle", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateHandle([In]IntPtr hSourceProcessHandle, [In]IntPtr hSourceHandle, [In]IntPtr hTargetProcessHandle,
            [Out]out IntPtr lpTargetHandle, [In]uint dwDesiredAccess, [In]bool bInheritHandle, [In]DuplicateHandleOptions dwOptions);

        /// <summary>
        /// <para>
        /// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/ioapiset/nf-ioapiset-deviceiocontrol
        /// </para>
        /// </summary>
        /// <param name="hDevice">
        /// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
        /// To retrieve a device handle, use the <see cref="CreateFile"/> function. For more information, see Remarks.
        /// </param>
        /// <param name="dwIoControlCode">
        /// The control code for the operation.
        /// This value identifies the specific operation to be performed and the type of device on which to perform it.
        /// For a list of the control codes, see Remarks.
        /// The documentation for each control code provides usage details for the <paramref name="lpInBuffer"/>, <paramref name="nInBufferSize"/>,
        /// <paramref name="lpOutBuffer"/>, and <paramref name="nOutBufferSize"/> parameters.
        /// </param>
        /// <param name="lpInBuffer">
        /// A pointer to the input buffer that contains the data required to perform the operation.
        /// The format of this data depends on the value of the <paramref name="dwIoControlCode"/> parameter.
        /// This parameter can be <see cref="IntPtr.Zero"/> if <paramref name="dwIoControlCode"/> specifies an operation that does not require input data.
        /// </param>
        /// <param name="nInBufferSize">
        /// The size of the input buffer, in bytes.
        /// </param>
        /// <param name="lpOutBuffer">
        /// A pointer to the output buffer that is to receive the data returned by the operation.
        /// The format of this data depends on the value of the <paramref name="dwIoControlCode"/> parameter.
        /// This parameter can be <see cref="IntPtr.Zero"/> if <paramref name="dwIoControlCode"/> specifies an operation that does not return data.
        /// </param>
        /// <param name="nOutBufferSize">
        /// The size of the output buffer, in bytes.
        /// </param>
        /// <param name="lpBytesReturned">
        /// A pointer to a variable that receives the size of the data stored in the output buffer, in bytes.
        /// If the output buffer is too small to receive any data, the call fails, <see cref="Marshal.GetLastWin32Error"/> returns
        /// <see cref="SystemErrorCodes.ERROR_INSUFFICIENT_BUFFER"/>, and <paramref name="lpBytesReturned"/> is zero.
        /// If the output buffer is too small to hold all of the data but can hold some entries, some drivers will return as much data as fits.
        /// In this case, the call fails, <see cref="Marshal.GetLastWin32Error"/> returns <see cref="SystemErrorCodes.ERROR_MORE_DATA"/>,
        /// and <paramref name="lpBytesReturned"/> indicates the amount of data received.
        /// Your application should call <see cref="DeviceIoControl"/> again with the same operation, specifying a new starting point.
        /// If <paramref name="lpOverlapped"/> is <see cref="IntPtr.Zero"/>, <paramref name="lpBytesReturned"/> cannot be <see langword="null"/>.
        /// Even when an operation returns no output data and <paramref name="lpOutBuffer"/> is <see cref="IntPtr.Zero"/>,
        /// <see cref="DeviceIoControl"/> makes use of <paramref name="lpBytesReturned"/>.
        /// After such an operation, the value of <paramref name="lpBytesReturned"/> is meaningless.
        /// If <paramref name="lpOverlapped"/> is not <see cref="IntPtr.Zero"/>, <paramref name="lpBytesReturned"/> can be <see langword="null"/>.
        /// If this parameter is not <see langword="null"/> and the operation returns data, <paramref name="lpBytesReturned"/> is meaningless
        /// until the overlapped operation has completed.
        /// To retrieve the number of bytes returned, call <see cref="GetOverlappedResult"/>.
        /// If <paramref name="hDevice"/> is associated with an I/O completion port, you can retrieve the number of bytes returned
        /// by calling <see cref="GetQueuedCompletionStatus"/>.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure.
        /// If <paramref name="hDevice"/> was opened without specifying <see cref="FileFlags.FILE_FLAG_OVERLAPPED"/>,
        /// <paramref name="lpOverlapped"/> is ignored.
        /// If <paramref name="hDevice"/> was opened with the <see cref="FileFlags.FILE_FLAG_OVERLAPPED"/> flag,
        /// the operation is performed as an overlapped (asynchronous) operation.
        /// In this case, lpOverlapped must point to a valid <see cref="OVERLAPPED"/> structure that contains a handle to an event object.
        /// Otherwise, the function fails in unpredictable ways.
        /// For overlapped operations, <see cref="DeviceIoControl"/> returns immediately,
        /// and the event object is signaled when the operation has been completed.
        /// Otherwise, the function does not return until the operation has been completed or an error occurs.
        /// </param>
        /// <returns>
        /// If the operation completes successfully, the return value is <see langword="true"/>.
        /// If the operation fails or is pending, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// To retrieve a handle to the device, you must call the <see cref="CreateFile"/> function with either the name of a device
        /// or the name of the driver associated with a device.
        /// To specify a device name, use the following format:
        /// \.&lt;i&gt;DeviceName
        /// <see cref="DeviceIoControl"/> can accept a handle to a specific device.
        /// For example, to open a handle to the logical drive A: with <see cref="CreateFile"/>, specify \.\a:.
        /// Alternatively, you can use the names \.\PhysicalDrive0, \.\PhysicalDrive1, and so on, to open handles to the physical drives on a system.
        /// You should specify the <see cref="FileShareModes.FILE_SHARE_READ"/> and <see cref="FileShareModes.FILE_SHARE_WRITE"/> access flags
        /// when calling <see cref="CreateFile"/> to open a handle to a device driver.
        /// However, when you open a communications resource, such as a serial port, you must specify exclusive access.
        /// Use the other <see cref="CreateFile"/> parameters as follows when opening a device handle:
        /// The fdwCreate parameter must specify <see cref="FileCreationDispositions.OPEN_EXISTING"/>.
        /// The hTemplateFile parameter must be <see cref="IntPtr.Zero"/>.
        /// The fdwAttrsAndFlags parameter can specify <see cref="FileFlags.FILE_FLAG_OVERLAPPED"/> to indicate that the returned handle
        /// can be used in overlapped (asynchronous) I/O operations.
        /// For lists of supported control codes, see the following topics:
        /// Communications Control Codes
        /// Device Management Control Codes
        /// Directory Management Control Codes
        /// Disk Management Control Codes
        /// File Management Control Codes
        /// Power Management Control Codes
        /// Volume Management Control Codes
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeviceIoControl", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeviceIoControl([In]IntPtr hDevice, [In]uint dwIoControlCode, [In]IntPtr lpInBuffer, [In]uint nInBufferSize,
            [In]IntPtr lpOutBuffer, [In]uint nOutBufferSize, [Out]out uint lpBytesReturned, [In] IntPtr lpOverlapped);

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
        /// Retrieves the command-line string for the current process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processenv/nf-processenv-getcommandlinew
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a pointer to the command-line string for the current process.
        /// </returns>
        /// <remarks>
        /// ANSI console processes written in C can use the argc and argv arguments of the main function to access the command-line arguments.
        /// ANSI GUI applications can use the lpCmdLine parameter of the WinMain function to access the command-line string, excluding the program name.
        /// The main and WinMain functions cannot return Unicode strings.
        /// Unicode console process written in C can use the wmain or _tmain function to access the command-line arguments.
        /// Unicode GUI applications must use the <see cref="GetCommandLine"/> function to access Unicode strings.
        /// To convert the command line to an argv style array of strings, call the <see cref="CommandLineToArgvW"/> function.
        /// The name of the executable in the command line that the operating system provides to a process is not necessarily identical
        /// to that in the command line that the calling process gives to the <see cref="CreateProcess"/> function.
        /// The operating system may prepend a fully qualified path to an executable name that is provided without a fully qualified path.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCommandLineW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(MarshalStringMarshaler))]
        public static extern MarshalString GetCommandLine();

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
        /// Retrieves the contents of the <see cref="STARTUPINFO"/> structure that was specified when the calling process was created.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-getstartupinfow
        /// </para>
        /// </summary>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure that receives the startup information.
        /// </param>
        /// <remarks>
        /// The <see cref="STARTUPINFO"/> structure was specified by the process that created the calling process.
        /// It can be used to specify properties associated with the main window of the calling process.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStartupInfoW", SetLastError = true)]
        public static extern void GetStartupInfo([Out]out STARTUPINFO lpStartupInfo);

        /// <summary>
        /// <para>
        /// Retrieves the fully qualified path for the file that contains the specified module.
        /// The module must have been loaded by the current process.
        /// To locate the file for a module that was loaded by another process, use the <see cref="GetModuleFileNameEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulefilenamew
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the loaded module whose path is being requested.
        /// If this parameter is <see cref="IntPtr.Zero"/>,
        /// <see cref="GetModuleFileName"/> retrieves the path of the executable file of the current process.
        /// The <see cref="GetModuleFileName"/> function does not retrieve the path for modules
        /// that were loaded using the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </param>
        /// <param name="lpFilename">
        /// A pointer to a buffer that receives the fully qualified path of the module.
        /// If the length of the path is less than the size that the <paramref name="nSize"/> parameter specifies,
        /// the function succeeds and the path is returned as a null-terminated string.
        /// If the length of the path exceeds the size that the <paramref name="nSize"/> parameter specifies,
        /// the function succeeds and the string is truncated to <paramref name="nSize"/> characters including the terminating null character.
        /// Windows XP:  The string is truncated to nSize characters and is not null-terminated.
        /// The string returned will use the same format that was specified when the module was loaded.
        /// Therefore, the path can be a long or short file name, and can use the prefix "\?".
        /// For more information, see Naming a File.
        /// </param>
        /// <param name="nSize">
        /// The size of the <paramref name="lpFilename"/> buffer, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string that is copied to the buffer, in characters,
        /// not including the terminating null character.
        /// If the buffer is too small to hold the module name, the string is truncated to <paramref name="nSize"/> characters
        /// including the terminating null character, the function returns <paramref name="nSize"/>,
        /// and the function sets the last error to <see cref="SystemErrorCodes.ERROR_INSUFFICIENT_BUFFER"/>.
        /// Windows XP:  If the buffer is too small to hold the module name, the function returns <paramref name="nSize"/>.
        /// The last error code remains <see cref="SystemErrorCodes.ERROR_SUCCESS"/>.
        /// If <paramref name="nSize"/> is zero, the return value is zero and the last error code is <see cref="SystemErrorCodes.ERROR_SUCCESS"/>
        /// If the function fails, the return value is 0 (zero). To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// If a DLL is loaded in two processes, its file name in one process may differ in case from its file name in the other process.
        /// The global variable _pgmptr is automatically initialized to the full path of the executable file,
        /// and can be used to retrieve the full path name of an executable file.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleFileNameW", SetLastError = true)]
        public static extern uint GetModuleFileName([In]IntPtr hModule, [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpFilename, uint nSize);

        /// <summary>
        /// <para>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// To avoid the race conditions described in the Remarks section, use the <see cref="GetModuleHandleEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandlew
        /// </para>
        /// </summary>
        /// <param name="lpModuleName">
        /// The name of the loaded module (either a .dll or .exe file).
        /// If the file name extension is omitted, the default library extension .dll is appended.
        /// The file name string can include a trailing point character (.) to indicate that the module name has no extension.
        /// The string does not have to specify a path. When specifying a path, be sure to use backslashes (), not forward slashes (/).
        /// The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.
        /// If this parameter is <see langword="null"/>, <see cref="GetModuleHandle"/> returns a handle to the file 
        /// used to create the calling process (.exe file).
        /// The <see cref="GetModuleHandle"/> function does not retrieve handles for modules
        /// that were loaded using the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified module.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// The returned handle is not global or inheritable. It cannot be duplicated or used by another process.
        /// If <paramref name="lpModuleName"/> does not include a path and there is more than one loaded module with the same base name and extension,
        /// you cannot predict which module handle will be returned.
        /// To work around this problem, you could specify a path, use side-by-side assemblies, or use <see cref="GetModuleHandleEx"/>
        /// to specify a memory location rather than a DLL name.
        /// The <see cref="GetModuleHandle"/> function returns a handle to a mapped module without incrementing its reference count.
        /// However, if this handle is passed to the FreeLibrary function, the reference count of the mapped module will be decremented.
        /// Therefore, do not pass a handle returned by <see cref="GetModuleHandle"/> to the <see cref="FreeLibrary"/> function.
        /// Doing so can cause a DLL module to be unmapped prematurely.
        /// This function must be used carefully in a multithreaded application.
        /// There is no guarantee that the module handle remains valid between the time this function returns the handle and the time it is used.
        /// For example, suppose that a thread retrieves a module handle, but before it uses the handle, a second thread frees the module.
        /// If the system loads another module, it could reuse the module handle that was recently freed.
        /// Therefore, the first thread would have a handle to a different module than the one intended.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandleW", SetLastError = true)]
        public static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)][In]string lpModuleName);

        /// <summary>
        /// <para>
        /// Retrieves a module handle for the specified module and increments the module's reference count
        /// unless <see cref="GetModuleHandleExFlags.GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/> is specified.
        /// The module must have been loaded by the calling process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandleexw
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// This parameter can be zero or one or more of the following values.
        /// If the module's reference count is incremented, the caller must use the <see cref="FreeLibrary"/> function
        /// to decrement the reference count when the module handle is no longer needed.
        /// </param>
        /// <param name="lpModuleName">
        /// The name of the loaded module (either a .dll or .exe file), or an address in the module
        /// (if <paramref name="dwFlags"/> is <see cref="GetModuleHandleExFlags.GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS"/>).
        /// For a module name, if the file name extension is omitted, the default library extension .dll is appended.
        /// The file name string can include a trailing point character (.) to indicate that the module name has no extension.
        /// The string does not have to specify a path.
        /// When specifying a path, be sure to use backslashes (), not forward slashes (/).
        /// The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.
        /// If this parameter is <see langword="null"/>, the function returns a handle to the file used to create the calling process (.exe file).
        /// </param>
        /// <param name="phModule">
        /// A handle to the specified module.
        /// If the function fails, this parameter is <see cref="IntPtr.Zero"/>.
        /// The <see cref="GetModuleHandleEx"/> function does not retrieve handles for modules that were loaded
        /// using the <see cref="LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// For more information, see <see cref="LoadLibraryEx"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, see <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned is not global or inheritable. It cannot be duplicated or used by another process.
        /// If <paramref name="lpModuleName"/> does not include a path and there is more than one loaded module with the same base name and extension,
        /// you cannot predict which module handle will be returned.
        /// To work around this problem, you could specify a path, use side-by-side assemblies, or specify a memory location rather than a DLL name
        /// in the <paramref name="lpModuleName"/> parameter.
        /// If <paramref name="dwFlags"/> contains <see cref="GetModuleHandleExFlags.GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/>,
        /// the <see cref="GetModuleHandleEx"/> function returns a handle to a mapped module without incrementing its reference count.
        /// However, if this handle is passed to the FreeLibrary function, the reference count of the mapped module will be decremented.
        /// Therefore, do not pass a handle returned by <see cref="GetModuleHandleEx"/>
        /// with <see cref="GetModuleHandleExFlags.GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/> to the <see cref="FreeLibrary"/> function.
        /// Doing so can cause a DLL module to be unmapped prematurely.
        /// If <paramref name="dwFlags"/> contains <see cref="GetModuleHandleExFlags.GET_MODULE_HANDLE_EX_UNCHANGED_REFCOUNT"/>,
        /// this function must be used carefully in a multithreaded application.
        /// There is no guarantee that the module handle remains valid between the time this function returns the handle and the time it is used.
        /// For example, a thread retrieves a module handle, but before it uses the handle, a second thread frees the module.
        /// If the system loads another module, it could reuse the module handle that was recently freed.
        /// Therefore, first thread would have a handle to a module different than the one intended.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0501 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandleExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetModuleHandleEx([In]uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)][In]string lpModuleName,
            [Out]out IntPtr phModule);

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
