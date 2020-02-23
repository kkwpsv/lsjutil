using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FileCreationDispositions;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.FileShareModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
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
        /// If the output buffer is too small to receive any data, the call fails, <see cref="GetLastError"/> returns
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>, and <paramref name="lpBytesReturned"/> is zero.
        /// If the output buffer is too small to hold all of the data but can hold some entries, some drivers will return as much data as fits.
        /// In this case, the call fails, <see cref="GetLastError"/> returns <see cref="ERROR_MORE_DATA"/>,
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
        /// If <paramref name="hDevice"/> was opened without specifying <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// <paramref name="lpOverlapped"/> is ignored.
        /// If <paramref name="hDevice"/> was opened with the <see cref="FILE_FLAG_OVERLAPPED"/> flag,
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
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To retrieve a handle to the device, you must call the <see cref="CreateFile"/> function with either the name of a device
        /// or the name of the driver associated with a device.
        /// To specify a device name, use the following format:
        /// \.&lt;i&gt;DeviceName
        /// <see cref="DeviceIoControl"/> can accept a handle to a specific device.
        /// For example, to open a handle to the logical drive A: with <see cref="CreateFile"/>, specify \.\a:.
        /// Alternatively, you can use the names \.\PhysicalDrive0, \.\PhysicalDrive1, and so on, to open handles to the physical drives on a system.
        /// You should specify the <see cref="FILE_SHARE_READ"/> and <see cref="FILE_SHARE_WRITE"/> access flags
        /// when calling <see cref="CreateFile"/> to open a handle to a device driver.
        /// However, when you open a communications resource, such as a serial port, you must specify exclusive access.
        /// Use the other <see cref="CreateFile"/> parameters as follows when opening a device handle:
        /// The fdwCreate parameter must specify <see cref="OPEN_EXISTING"/>.
        /// The hTemplateFile parameter must be <see cref="IntPtr.Zero"/>.
        /// The fdwAttrsAndFlags parameter can specify <see cref="FILE_FLAG_OVERLAPPED"/> to indicate that the returned handle
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
        public static extern bool DeviceIoControl([In]IntPtr hDevice, [In]IoControlCodes dwIoControlCode, [In]IntPtr lpInBuffer, [In]uint nInBufferSize,
            [In]IntPtr lpOutBuffer, [In]uint nOutBufferSize, [Out]out uint lpBytesReturned, [In] IntPtr lpOverlapped);

        /// <summary>
        /// <para>
        /// Retrieves the results of an overlapped operation on the specified file, named pipe, or communications device.
        /// To specify a timeout interval or wait on an alertable thread, use <see cref="GetOverlappedResultEx"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/ioapiset/nf-ioapiset-getoverlappedresult
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file, named pipe, or communications device.
        /// This is the same handle that was specified when the overlapped operation was started by a call to the <see cref="ReadFile"/>,
        /// <see cref="WriteFile"/>, <see cref="ConnectNamedPipe"/>, <see cref="TransactNamedPipe"/>,
        /// <see cref="DeviceIoControl"/>, or <see cref="WaitCommEvent"/> function.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure that was specified when the overlapped operation was started.
        /// </param>
        /// <param name="lpNumberOfBytesTransferred">
        /// A pointer to a variable that receives the number of bytes that were actually transferred by a read or write operation.
        /// For a <see cref="TransactNamedPipe"/> operation, this is the number of bytes that were read from the pipe.
        /// For a <see cref="DeviceIoControl"/> operation, this is the number of bytes of output data returned by the device driver.
        /// For a <see cref="ConnectNamedPipe"/> or <see cref="WaitCommEvent"/> operation, this value is undefined.
        /// </param>
        /// <param name="bWait">
        /// If this parameter is <see langword="true"/>, and the Internal member of the <paramref name="lpOverlapped"/> structure
        /// is <see cref="STATUS_PENDING"/>, the function does not return until the operation has been completed.
        /// If this parameter is <see langword="false"/> and the operation is still pending,
        /// the function returns <see langword="false"/> and the <see cref="GetLastError"/> function returns <see cref="ERROR_IO_INCOMPLETE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The results reported by the <see cref="GetOverlappedResult"/> function are those of the specified handle's last overlapped operation
        /// to which the specified <see cref="OVERLAPPED"/> structure was provided, and for which the operation's results were pending.
        /// A pending operation is indicated when the function that started the operation returns <see langword="false"/>,
        /// and the <see cref="GetLastError"/> function returns <see cref="ERROR_IO_PENDING"/>.
        /// When an I/O operation is pending, the function that started the operation resets
        /// the <see cref="OVERLAPPED.hEvent"/> member of the <see cref="OVERLAPPED"/> structure to the nonsignaled state.
        /// Then when the pending operation has been completed, the system sets the event object to the signaled state.
        /// If the <paramref name="bWait"/> parameter is <see langword="true"/>, <see cref="GetOverlappedResult"/> determines
        /// whether the pending operation has been completed by waiting for the event object to be in the signaled state.
        /// If the <see cref="OVERLAPPED.hEvent"/> member of the <see cref="OVERLAPPED"/> structure is <see cref="IntPtr"/>,
        /// the system uses the state of the <paramref name="hFile"/> handle to signal when the operation has been completed.
        /// Use of file, named pipe, or communications-device handles for this purpose is discouraged.
        /// It is safer to use an event object because of the confusion that can occur when multiple simultaneous overlapped operations
        /// are performed on the same file, named pipe, or communications device.
        /// In this situation, there is no way to know which operation caused the object's state to be signaled.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetOverlappedResult", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetOverlappedResult([In]IntPtr hFile, [In]IntPtr lpOverlapped, [Out]out uint lpNumberOfBytesTransferred, [In]bool bWait);

        /// <summary>
        /// <para>
        /// Retrieves the results of an overlapped operation on the specified file, named pipe,
        /// or communications device within the specified time-out interval.
        /// The calling thread can perform an alertable wait.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/ioapiset/nf-ioapiset-getoverlappedresultex
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file, named pipe, or communications device.
        /// This is the same handle that was specified when the overlapped operation was started
        /// by a call to the <see cref="ReadFile"/>, <see cref="WriteFile"/>, <see cref="ConnectNamedPipe"/>,
        /// <see cref="TransactNamedPipe"/>, <see cref="DeviceIoControl"/>, or <see cref="WaitCommEvent"/> function.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure that was specified when the overlapped operation was started.
        /// </param>
        /// <param name="lpNumberOfBytesTransferred">
        /// A pointer to a variable that receives the number of bytes that were actually transferred by a read or write operation.
        /// For a <see cref="TransactNamedPipe"/> operation, this is the number of bytes that were read from the pipe.
        /// For a <see cref="DeviceIoControl"/> operation, this is the number of bytes of output data returned by the device driver.
        /// For a <see cref="ConnectNamedPipe"/> or <see cref="WaitCommEvent"/> operation, this value is undefined.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If <paramref name="dwMilliseconds"/> is zero and the operation is still in progress,
        /// the function returns immediately and the <see cref="GetLastError"/> function returns <see cref="ERROR_IO_INCOMPLETE"/>.
        /// If <paramref name="dwMilliseconds"/> is nonzero and the operation is still in progress, the function waits until the object is signaled,
        /// an I/O completion routine or APC is queued, or the interval elapses before returning.
        /// Use <see cref="GetLastError"/> to get extended error information.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>,
        /// the function returns only when the object is signaled or an I/O completion routine or APC is queued.
        /// </param>
        /// <param name="bAlertable">
        /// If this parameter is <see langword="true"/> and the calling thread is in the waiting state,
        /// the function returns when the system queues an I/O completion routine or APC.
        /// The calling thread then runs the routine or function. Otherwise, the function does not return,
        /// and the completion routine or APC function is not executed.
        /// A completion routine is queued when the <see cref="ReadFileEx"/> or <see cref="WriteFileEx"/> function
        /// in which it was specified has completed.
        /// The function returns and the completion routine is called only if <paramref name="bAlertable"/> is <see langword="true"/>,
        /// and the calling thread is the thread that initiated the read or write operation.
        /// An APC is queued when you call <see cref="QueueUserAPC"/>.
        /// 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Common error codes include the following:
        /// If <paramref name="dwMilliseconds"/> is zero and the operation is still in progress,
        /// <see cref="GetLastError"/> returns <see cref="ERROR_IO_INCOMPLETE"/>.
        /// If <paramref name="dwMilliseconds"/> is nonzero, and an I/O completion routine or APC is queued,
        /// GetLastError returns <see cref="WAIT_IO_COMPLETION"/>.
        /// If <paramref name="dwMilliseconds"/> is nonzero and the specified timeout interval elapses,
        /// <see cref="GetLastError"/> returns <see cref="WAIT_TIMEOUT"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetOverlappedResultEx"/> function differs from <see cref="GetOverlappedResult"/> in the following ways:
        /// The <paramref name="dwMilliseconds"/> parameter can specify a timeout interval for the operation,
        /// and the <paramref name="bAlertable"/> parameter can specify that the calling thread should perform an alertable wait.
        /// The results reported by the <see cref="GetOverlappedResultEx"/> function are those of the specified handle's last overlapped operation
        /// to which the specified <see cref="OVERLAPPED"/> structure was provided, and for which the operation's results were pending.
        /// A pending operation is indicated when the function that started the operation returns <see langword="false"/>,
        /// and the <see cref="GetLastError"/> function returns <see cref="ERROR_IO_PENDING"/>.
        /// When an I/O operation is pending, the function that started the operation resets
        /// the <see cref="OVERLAPPED.hEvent"/> member of the <see cref="OVERLAPPED"/> structure to the nonsignaled state.
        /// Then when the pending operation has been completed, the system sets the event object to the signaled state.
        /// Specify a manual-reset event object in the <see cref="OVERLAPPED"/> structure.
        /// If an auto-reset event object is used, the event handle must not be specified in any other wait operation in the interval
        /// between starting the overlapped operation and the call to <see cref="GetOverlappedResultEx"/>.
        /// For example, the event object is sometimes specified in one of the wait functions to wait for the operation's completion.
        /// When the wait function returns, the system sets an auto-reset event's state to nonsignaled,
        /// and a subsequent call to <see cref="GetOverlappedResultEx"/> with the <paramref name="dwMilliseconds"/> parameter
        /// set to <see cref="INFINITE"/> causes the function to be blocked indefinitely.
        /// If the <see cref="OVERLAPPED.hEvent"/> member of the <see cref="OVERLAPPED"/> structure is <see cref="IntPtr.Zero"/>,
        /// the system uses the state of the <paramref name="hFile"/> handle to signal when the operation has been completed.
        /// Use of file, named pipe, or communications-device handles for this purpose is discouraged.
        /// It is safer to use an event object because of the confusion that can occur
        /// when multiple simultaneous overlapped operations are performed on the same file, named pipe, or communications device.
        /// In this situation, there is no way to know which operation caused the object's state to be signaled.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetOverlappedResultEx", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetOverlappedResultEx([In]IntPtr hFile, [In]IntPtr lpOverlapped, [Out]out uint lpNumberOfBytesTransferred,
            [In]uint dwMilliseconds, [In]bool bAlertable);

        /// <summary>
        /// <para>
        /// Attempts to dequeue an I/O completion packet from the specified I/O completion port.
        /// If there is no completion packet queued, the function waits for a pending I/O operation associated with the completion port to complete.
        /// To dequeue multiple I/O completion packets at once, use the <see cref="GetQueuedCompletionStatusEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/ioapiset/nf-ioapiset-getqueuedcompletionstatus
        /// </para>
        /// </summary>
        /// <param name="CompletionPort">
        /// A handle to the completion port.
        /// To create a completion port, use the <see cref="CreateIoCompletionPort"/> function.
        /// </param>
        /// <param name="lpNumberOfBytesTransferred">
        /// A pointer to a variable that receives the number of bytes transferred in a completed I/O operation.
        /// </param>
        /// <param name="lpCompletionKey">
        /// A pointer to a variable that receives the completion key value associated with the file handle whose I/O operation has completed.
        /// A completion key is a per-file key that is specified in a call to <see cref="CreateIoCompletionPort"/>.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to a variable that receives the address of the <see cref="OVERLAPPED"/> structure
        /// that was specified when the completed I/O operation was started.
        /// Even if you have passed the function a file handle associated with a completion port and a valid <see cref="OVERLAPPED"/> structure,
        /// an application can prevent completion port notification.
        /// This is done by specifying a valid event handle for the <see cref="OVERLAPPED.hEvent"/> member of the <see cref="OVERLAPPED"/> structure,
        /// and setting its low-order bit.
        /// A valid event handle whose low-order bit is set keeps I/O completion from being queued to the completion port.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The number of milliseconds that the caller is willing to wait for a completion packet to appear at the completion port.
        /// If a completion packet does not appear within the specified time, the function times out,
        /// returns <see langword="false"/>, and sets <paramref name="lpOverlapped"/> to <see cref="IntPtr.Zero"/>.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function will never time out.
        /// If <paramref name="dwMilliseconds"/> is zero and there is no I/O operation to dequeue, the function will time out immediately.
        /// </param>
        /// <returns>
        /// Returns <see langword="true"/> if successful or <see langword="false"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// For more information, see the Remarks section.
        /// </returns>
        /// <remarks>
        /// This function associates a thread with the specified completion port.
        /// A thread can be associated with at most one completion port.
        /// If a call to <see cref="GetQueuedCompletionStatus"/> fails because the completion port handle associated with it is closed
        /// while the call is outstanding, the function returns <see langword="false"/>, <paramref name="lpOverlapped"/> will be <see cref="IntPtr.Zero"/>,
        /// and <see cref="GetLastError"/> will return <see cref="ERROR_ABANDONED_WAIT_0"/>.
        /// Windows Server 2003 and Windows XP:
        /// Closing the completion port handle while a call is outstanding will not result in the previously stated behavior.
        /// The function will continue to wait until an entry is removed from the port or until a time-out occurs,
        /// if specified as a value other than <see cref="INFINITE"/>.
        /// If the <see cref="GetQueuedCompletionStatus"/> function succeeds,
        /// it dequeued a completion packet for a successful I/O operation from the completion port and has stored information
        /// in the variables pointed to by the following parameters: <paramref name="lpNumberOfBytesTransferred"/>,
        /// <paramref name="lpCompletionKey"/>, and <paramref name="lpOverlapped"/>.
        /// Upon failure (the return value is <see langword="false"/>), those same parameters can contain particular value combinations as follows:
        /// If <paramref name="lpOverlapped"/> is <see cref="IntPtr.Zero"/>, the function did not dequeue a completion packet from the completion port.
        /// In this case, the function does not store information in the variables pointed to
        /// by the <paramref name="lpNumberOfBytesTransferred"/> and <paramref name="lpCompletionKey"/> parameters, and their values are indeterminate.
        /// If <paramref name="lpOverlapped"/> is not NULL and the function dequeues a completion packet for a failed I/O operation from the completion port,
        /// the function stores information about the failed operation in the variables pointed to by <paramref name="lpNumberOfBytesTransferred"/>,
        /// <paramref name="lpCompletionKey"/>, and <paramref name="lpOverlapped"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// For more information on I/O completion port theory, usage, and associated functions, see I/O Completion Ports.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetQueuedCompletionStatus", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetQueuedCompletionStatus([In]IntPtr CompletionPort, [Out]out int lpNumberOfBytesTransferred,
            [Out]out UIntPtr lpCompletionKey, [Out]out IntPtr lpOverlapped, [In]uint dwMilliseconds);

        /// <summary>
        /// <para>
        /// Retrieves multiple completion port entries simultaneously.
        /// It waits for pending I/O operations that are associated with the specified completion port to complete.
        /// To dequeue I/O completion packets one at a time, use the <see cref="GetQueuedCompletionStatus"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/ioapiset/nf-ioapiset-getqueuedcompletionstatusex
        /// </para>
        /// </summary>
        /// <param name="CompletionPort">
        /// A handle to the completion port.
        /// To create a completion port, use the <see cref="CreateIoCompletionPort"/> function.
        /// </param>
        /// <param name="lpCompletionPortEntries">
        /// On input, points to a pre-allocated array of <see cref="OVERLAPPED_ENTRY"/> structures.
        /// On output, receives an array of <see cref="OVERLAPPED_ENTRY"/> structures that hold the entries.
        /// The number of array elements is provided by <paramref name="ulNumEntriesRemoved"/>.
        /// The number of bytes transferred during each I/O, the completion key that indicates on which file each I/O occurred,
        /// and the overlapped structure address used in each original I/O are all returned in the <paramref name="lpCompletionPortEntries"/> array.
        /// </param>
        /// <param name="ulCount">
        /// The maximum number of entries to remove.
        /// </param>
        /// <param name="ulNumEntriesRemoved">
        /// A pointer to a variable that receives the number of entries actually removed.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The number of milliseconds that the caller is willing to wait for a completion packet to appear at the completion port.
        /// If a completion packet does not appear within the specified time, the function times out and returns <see langword="false"/>.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function will never time out.
        /// If <paramref name="dwMilliseconds"/> is zero and there is no I/O operation to dequeue, the function will time out immediately.
        /// </param>
        /// <param name="fAlertable">
        /// If this parameter is <see langword="false"/>, the function does not return until the time-out period has elapsed or an entry is retrieved.
        /// If the parameter is <see langword="true"/> and there are no available entries, the function performs an alertable wait.
        /// The thread returns when the system queues an I/O completion routine or APC to the thread and the thread executes the function.
        /// A completion routine is queued when the <see cref="ReadFileEx"/> or <see cref="WriteFileEx"/> function in which it was specified has completed,
        /// and the calling thread is the thread that initiated the operation.
        /// An APC is queued when you call <see cref="QueueUserAPC"/>.
        /// </param>
        /// <returns>
        /// Returns <see langword="true"/> if successful or <see langword="false"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function associates a thread with the specified completion port.
        /// A thread can be associated with at most one completion port.
        /// This function returns <see langword="true"/> when at least one pending I/O is completed,
        /// but it is possible that one or more I/O operations failed.
        /// Note that it is up to the user of this function to check the list of returned entries in the <paramref name="lpCompletionPortEntries"/>
        /// parameter to determine which of them correspond to any possible failed I/O operations by looking at the status
        /// contained in the <see cref="lpOverlapped"/> member in each <see cref="OVERLAPPED_ENTRY"/>.
        /// This function returns <see langword="false"/> when no I/O operation was dequeued.
        /// This typically means that an error occurred while processing the parameters to this call,
        /// or that the <paramref name="CompletionPort"/> handle was closed or is otherwise invalid.
        /// The <see cref="GetLastError"/> function provides extended error information.
        /// If a call to <see cref="GetQueuedCompletionStatusEx"/> fails because the handle associated with it is closed,
        /// the function returns <see langword="false"/> and <see cref="GetLastError"/> will return <see cref="ERROR_ABANDONED_WAIT_0"/>.
        /// Server applications may have several threads calling the <see cref="GetQueuedCompletionStatusEx"/> function for the same completion port.
        /// As I/O operations complete, they are queued to this port in first-in-first-out order.
        /// If a thread is actively waiting on this call, one or more queued requests complete the call for that thread only.
        /// For more information on I/O completion port theory, usage, and associated functions, see I/O Completion Ports.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetQueuedCompletionStatusEx", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetQueuedCompletionStatusEx([In]IntPtr CompletionPort, [In]IntPtr lpCompletionPortEntries, [In]uint ulCount,
            [Out]out uint ulNumEntriesRemoved, [In]uint dwMilliseconds, [In]bool fAlertable);
    }
}
