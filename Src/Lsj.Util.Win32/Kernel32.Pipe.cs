using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileAccessRights;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.PipeModes;
using static Lsj.Util.Win32.Enums.PipeOpenModes;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
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
        /// PIPE_UNLIMITED_INSTANCES
        /// </summary>
        public const uint PIPE_UNLIMITED_INSTANCES = 255;

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
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the message written to the pipe by the server process is longer than <paramref name="nOutBufferSize"/>,
        /// <see cref="CallNamedPipe"/> returns <see langword="false"/>,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_MORE_DATA"/>.
        /// The remainder of the message is discarded, because <see cref="CallNamedPipe"/> closes the handle to the pipe before returning.
        /// </returns>
        /// <remarks>
        /// Calling <see cref="CallNamedPipe"/> is equivalent to calling the <see cref="CreateFile"/> (or <see cref="WaitNamedPipe"/>,
        /// if <see cref="CreateFile"/> cannot open the pipe immediately), <see cref="TransactNamedPipe"/>, and <see cref="CloseHandle"/> functions.
        /// <see cref="CreateFile"/> is called with an access flag of <see cref="GENERIC_READ"/> | <see cref="GENERIC_WRITE"/>,
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
        /// If <paramref name="hNamedPipe"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// the <paramref name="lpOverlapped"/> parameter must not be <see cref="IntPtr.Zero"/>.
        /// It must point to a valid <see cref="OVERLAPPED"/> structure.
        /// If <paramref name="hNamedPipe"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/>
        /// and <paramref name="lpOverlapped"/> is <see cref="IntPtr.Zero"/>,
        /// the function can incorrectly report that the connect operation is complete.
        /// If <paramref name="hNamedPipe"/> was created with <see cref="FILE_FLAG_OVERLAPPED"/>
        /// and <paramref name="lpOverlapped"/> is not <see cref="IntPtr.Zero"/>,
        /// the <see cref="OVERLAPPED"/> structure should contain a handle to a manual-reset event object
        /// (which the server can create by using the <see cref="CreateEvent"/> function).
        /// If <paramref name="hNamedPipe"/> was not opened with <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// the function does not return until a client is connected or an error occurs.
        /// Successful synchronous operations result in the function returning a nonzero value if a client connects after the function is called.
        /// </param>
        /// <returns>
        /// If the operation is synchronous, <see cref="ConnectNamedPipe"/> does not return until the operation has completed.
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the operation is asynchronous, <see cref="ConnectNamedPipe"/> returns immediately.
        /// If the operation is still pending, the return value is <see langword="false"/>
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_IO_PENDING"/>.
        /// (You can use the <see cref="HasOverlappedIoCompleted"/> macro to determine when the operation has finished.)
        /// If the function fails, the return value is <see langword="false"/>
        /// and <see cref="GetLastError"/> returns a value
        /// other than <see cref="ERROR_IO_PENDING"/> or <see cref="ERROR_PIPE_CONNECTED"/>.
        /// If a client connects before the function is called, the function returns <see langword="false"/>
        /// and GetLastError returns <see cref="ERROR_PIPE_CONNECTED"/>.
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
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_NO_DATA"/>
        /// if the previous client has closed its handle or <see cref="ERROR_PIPE_CONNECTED"/> if it has not closed its handle.
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
        /// In these situations, <see cref="GetLastError"/> returns <see cref="ERROR_PIPE_LISTENING"/>
        /// if no client is connected, <see cref="ERROR_PIPE_CONNECTED"/> if a client is connected,
        /// and <see cref="ERROR_NO_DATA"/> if a previous client has closed its pipe handle but the server has not disconnected.
        /// Note that a good connection between client and server exists only
        /// after the <see cref="ERROR_PIPE_CONNECTED"/> error is received.
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
        /// <see cref="PIPE_ACCESS_DUPLEX"/>, <see cref="PIPE_ACCESS_INBOUND"/>, <see cref="PIPE_ACCESS_OUTBOUND"/>.
        /// This parameter can also include one or more of the following flags, which enable the write-through and overlapped modes.
        /// These modes can be different for different instances of the same pipe.
        /// <see cref="FILE_FLAG_FIRST_PIPE_INSTANCE"/>:
        /// If you attempt to create multiple instances of a pipe with this flag, creation of the first instance succeeds,
        /// but creation of the next instance fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// <see cref="FILE_FLAG_WRITE_THROUGH"/>:
        /// Write-through mode is enabled. This mode affects only write operations on byte-type pipes and, then,
        /// only when the client and server processes are on different computers.
        /// If this mode is enabled, functions writing to a named pipe do not return until the data written is transmitted across the network
        /// and is in the pipe's buffer on the remote computer.
        /// If this mode is not enabled, the system enhances the efficiency of network operations by buffering data
        /// until a minimum number of bytes accumulate or until a maximum time elapses.
        /// <see cref="FILE_FLAG_OVERLAPPED"/>
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
        /// <see cref="WRITE_DAC"/>:
        /// The caller will have write access to the named pipe's discretionary access control list (ACL).
        /// <see cref="WRITE_OWNER"/>:
        /// The caller will have write access to the named pipe's owner.
        /// <see cref="ACCESS_SYSTEM_SECURITY"/>:
        /// The caller will have write access to the named pipe's SACL. For more information, see Access-Control Lists (ACLs) and SACL Access Right.
        /// </param>
        /// <param name="dwPipeMode">
        /// The pipe mode.
        /// The function fails if <paramref name="dwPipeMode"/> specifies anything other than 0 or the flags listed in the following tables.
        /// One of the following type modes can be specified. The same type mode must be specified for each instance of the pipe.
        /// <see cref="PIPE_TYPE_BYTE"/>, <see cref="PIPE_TYPE_MESSAGE"/>
        /// One of the following read modes can be specified. Different instances of the same pipe can specify different read modes.
        /// <see cref="PIPE_READMODE_BYTE"/>, <see cref="PIPE_READMODE_MESSAGE"/>
        /// One of the following wait modes can be specified. Different instances of the same pipe can specify different wait modes.
        /// <see cref="PIPE_WAIT"/>, <see cref="PIPE_NOWAIT"/>
        /// One of the following remote-client modes can be specified. Different instances of the same pipe can specify different remote-client modes.
        /// <see cref="PIPE_ACCEPT_REMOTE_CLIENTS"/>, <see cref="PIPE_REJECT_REMOTE_CLIENTS"/>
        /// </param>
        /// <param name="nMaxInstances">
        /// The maximum number of instances that can be created for this pipe.
        /// The first instance of the pipe can specify this value; the same number must be specified for other instances of the pipe.
        /// Acceptable values are in the range 1 through <see cref="PIPE_UNLIMITED_INSTANCES"/>.
        /// If this parameter is <see cref="PIPE_UNLIMITED_INSTANCES"/>, the number of pipe instances that can be created
        /// is limited only by the availability of system resources.
        /// If nMaxInstances is greater than <see cref="PIPE_UNLIMITED_INSTANCES"/>,
        /// the return value is <see cref="INVALID_HANDLE_VALUE"/> and
        /// <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
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
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To create an instance of a named pipe by using <see cref="CreateNamedPipe"/>,
        /// the user must have <see cref="FILE_CREATE_PIPE_INSTANCE"/> access to the named pipe object.
        /// If a new named pipe is being created, the access control list (ACL) from the security attributes parameter
        /// defines the discretionary access control for the named pipe.
        /// All instances of a named pipe must specify the same pipe type (byte-type or message-type),
        /// pipe access (duplex, inbound, or outbound), instance count, and time-out value.
        /// If different values are used, this function fails and
        /// <see cref="GetLastError"/> returns <see cref="ERROR_ACCESS_DENIED"/>.
        /// A client process connects to a named pipe by using the <see cref="CreateFile"/> or <see cref="CallNamedPipe"/> function.
        /// The client side of a named pipe starts out in byte mode, even if the server side is in message mode.
        /// To avoid problems receiving data, set the client side to message mode as well.
        /// To change the mode of the pipe, the pipe client must open a read-only pipe
        /// with <see cref="GENERIC_READ"/> and <see cref="FILE_WRITE_ATTRIBUTES"/> access.
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
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes);

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
        /// To get extended error information, call <see cref="GetLastError"/>.
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
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpPipeAttributes, [In] uint nSize);

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
        /// To get extended error information, call <see cref="GetLastError"/>.
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
    }
}
