using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Extensions;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CommEvents;
using static Lsj.Util.Win32.Enums.FileCreationDispositions;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.FileShareModes;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Mswsock;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Cancels all pending input and output (I/O) operations that are issued by the calling thread for the specified file.
        /// The function does not cancel I/O operations that other threads issue for a file handle.
        /// To cancel I/O operations from another thread, use the <see cref="CancelIoEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/ioapiset/nf-ioapiset-cancelio
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// The function cancels all pending I/O operations for this file handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="false"/>.
        /// The cancel operation for all pending I/O operations issued by the calling thread for the specified file handle was successfully requested.
        /// The thread can use the <see cref="GetOverlappedResult"/> function to determine when the I/O operations themselves have been completed.
        /// If the function fails, the return value is <see langword="true"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// If there are any pending I/O operations in progress for the specified file handle, and they are issued by the calling thread,
        /// the <see cref="CancelIo"/> function cancels them.
        /// <see cref="CancelIo"/> cancels only outstanding I/O on the handle, it does not change the state of the handle;
        /// this means that you cannot rely on the state of the handle because you cannot know whether the operation was completed successfully or canceled.
        /// The I/O operations must be issued as overlapped I/O.
        /// If they are not, the I/O operations do not return to allow the thread to call the <see cref="CancelIo"/> function.
        /// Calling the <see cref="CancelIo"/> function with a file handle that is not opened with <see cref="FILE_FLAG_OVERLAPPED"/> does nothing.
        /// All I/O operations that are canceled complete with the error <see cref="ERROR_OPERATION_ABORTED"/>,
        /// and all completion notifications for the I/O operations occur normally.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CancelIo", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CancelIo([In] IntPtr hFile);

        /// <summary>
        /// <para>
        /// Marks any outstanding I/O operations for the specified file handle.
        /// The function only cancels I/O operations in the current process, regardless of which thread created the I/O operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/ioapiset/nf-ioapiset-cancelioex
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> data structure that contains the data used for asynchronous I/O.
        /// If this parameter is <see langword="null"/>, all I/O requests for the hFile parameter are canceled.
        /// If this parameter is not <see langword="null"/>, only those specific I/O requests that were issued for
        /// the file with the specified <paramref name="lpOverlapped"/> overlapped structure are marked as canceled,
        /// meaning that you can cancel one or more requests,
        /// while the <see cref="CancelIo"/> function cancels all outstanding requests on a file handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// The cancel operation for all pending I/O operations issued by the calling process for the specified file handle was successfully requested.
        /// The application must not free or reuse the <see cref="OVERLAPPED"/> structure associated with the canceled I/O operations
        /// until they have completed.
        /// The thread can use the <see cref="GetOverlappedResult"/> function to determine when the I/O operations themselves have been completed.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// If this function cannot find a request to cancel, the return value is <see langword="false"/>,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_NOT_FOUND"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CancelIoEx"/> function allows you to cancel requests in threads other than the calling thread.
        /// The <see cref="CancelIo"/> function only cancels requests in the same thread that called the <see cref="CancelIo"/> function.
        /// <see cref="CancelIoEx"/> cancels only outstanding I/O on the handle, it does not change the state of the handle;
        /// this means that you cannot rely on the state of the handle because you cannot know whether the operation was completed successfully or canceled.
        /// If there are any pending I/O operations in progress for the specified file handle,
        /// the <see cref="CancelIoEx"/> function marks them for cancellation.
        /// Most types of operations can be canceled immediately;
        /// other operations can continue toward completion before they are actually canceled and the caller is notified.
        /// The <see cref="CancelIoEx"/> function does not wait for all canceled operations to complete.
        /// If the file handle is associated with a completion port,
        /// an I/O completion packet is not queued to the port if a synchronous operation is successfully canceled.
        /// For asynchronous operations still pending, the cancel operation will queue an I/O completion packet.
        /// The operation being canceled is completed with one of three statuses;
        /// you must check the completion status to determine the completion state.The three statuses are:
        /// The operation completed normally.
        /// This can occur even if the operation was canceled, because the cancel request might not have been submitted in time to cancel the operation.
        /// The operation was canceled.
        /// The <see cref="GetLastError"/> function returns <see cref="ERROR_OPERATION_ABORTED"/>.
        /// The operation failed with another error. The <see cref="GetLastError"/> function returns the relevant error code.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CancelIoEx", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CancelIoEx([In] IntPtr hFile, [In][Out] ref OVERLAPPED lpOverlapped);

        /// <summary>
        /// <para>
        /// Marks pending synchronous I/O operations that are issued by the specified thread as canceled.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/fileio/cancelsynchronousio-func
        /// </para>
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// If this function cannot find a request to cancel, the return value is <see cref="FALSE"/>,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_NOT_FOUND"/>.
        /// </returns>
        /// <remarks>
        /// The caller must have the <see cref="THREAD_TERMINATE"/> access right.
        /// If there are any pending I/O operations in progress for the specified thread,
        /// the <see cref="CancelSynchronousIo"/> function marks them for cancellation.
        /// Most types of operations can be canceled immediately; other operations can continue toward completion
        /// before they are actually canceled and the caller is notified.
        /// The <see cref="CancelSynchronousIo"/> function does not wait for all canceled operations to complete.
        /// For more information, see I/O Completion/Cancellation Guidelines.
        /// The operation being canceled is completed with one of three statuses; you must check the completion status to determine the completion state.
        /// The three statuses are:
        /// The operation completed normally. This can occur even if the operation was canceled,
        /// because the cancel request might not have been submitted in time to cancel the operation.
        /// The operation was canceled. The <see cref="GetLastError"/> function returns <see cref="ERROR_OPERATION_ABORTED"/>.
        /// The operation failed with another error. The <see cref="GetLastError"/> function returns the relevant error code.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CancelSynchronousIo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CancelSynchronousIo([In] HANDLE hThread);

        /// <summary>
        /// <para>
        /// Creates an input/output (I/O) completion port and associates it with a specified file handle,
        /// or creates an I/O completion port that is not yet associated with a file handle, allowing association at a later time.
        /// Associating an instance of an opened file handle with an I/O completion port allows a process to receive notification
        /// of the completion of asynchronous I/O operations involving that file handle.
        /// The term file handle as used here refers to a system abstraction that represents an overlapped I/O endpoint, not only a file on disk.
        /// Any system objects that support overlapped I/O—such as network endpoints, TCP sockets, named pipes, and mail slots—can be used as file handles.
        /// For additional information, see the Remarks section.
        /// </para>
        /// </summary>
        /// <param name="FileHandle">
        /// An open file handle or <see cref="INVALID_HANDLE_VALUE"/>.
        /// The handle must be to an object that supports overlapped I/O.
        /// If a handle is provided, it has to have been opened for overlapped I/O completion.
        /// For example, you must specify the <see cref="FILE_FLAG_OVERLAPPED"/> flag when using the <see cref="CreateFile"/> function to obtain the handle.
        /// If <see cref="INVALID_HANDLE_VALUE"/> is specified, the function creates an I/O completion port without associating it with a file handle.
        /// In this case, the <paramref name="ExistingCompletionPort"/> parameter must be <see cref="IntPtr.Zero"/>
        /// and the <paramref name="CompletionKey"/> parameter is ignored.
        /// </param>
        /// <param name="ExistingCompletionPort">
        /// A handle to an existing I/O completion port or <see cref="IntPtr.Zero"/>.
        /// If this parameter specifies an existing I/O completion port,
        /// the function associates it with the handle specified by the <paramref name="FileHandle"/> parameter.
        /// The function returns the handle of the existing I/O completion port if successful; it does not create a new I/O completion port.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the function creates a new I/O completion port and,
        /// if the <paramref name="FileHandle"/> parameter is valid, associates it with the new I/O completion port.
        /// Otherwise no file handle association occurs.
        /// The function returns the handle to the new I/O completion port if successful.
        /// </param>
        /// <param name="CompletionKey">
        /// The per-handle user-defined completion key that is included in every I/O completion packet for the specified file handle.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="NumberOfConcurrentThreads">
        /// The maximum number of threads that the operating system can allow to concurrently process I/O completion packets for the I/O completion port.
        /// This parameter is ignored if the <paramref name="ExistingCompletionPort"/> parameter is not <see cref="IntPtr.Zero"/>.
        /// If this parameter is zero, the system allows as many concurrently running threads as there are processors in the system.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to an I/O completion port:
        /// If the <paramref name="ExistingCompletionPort"/> parameter was <see cref="IntPtr.Zero"/>, the return value is a new handle.
        /// If the <paramref name="ExistingCompletionPort"/> parameter was a valid I/O completion port handle, the return value is that same handle.
        /// If the <paramref name="FileHandle"/> parameter was a valid handle, that file handle is now associated with the returned I/O completion port.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// The I/O system can be instructed to send I/O completion notification packets to I/O completion ports, where they are queued.
        /// The <see cref="CreateIoCompletionPort"/> function provides this functionality.
        /// An I/O completion port and its handle are associated with the process that created it and is not sharable between processes.
        /// However, a single handle is sharable between threads in the same process.
        /// <see cref="CreateIoCompletionPort"/> can be used in three distinct modes:
        /// Create only an I/O completion port without associating it with a file handle.
        /// Associate an existing I/O completion port with a file handle.
        /// Perform both creation and association in a single call.
        /// To create an I/O completion port without associating it, set the <paramref name="FileHandle"/> parameter to <see cref="INVALID_HANDLE_VALUE"/>,
        /// the <paramref name="ExistingCompletionPort"/> parameter to <see cref="IntPtr.Zero"/>,
        /// and the <paramref name="CompletionKey"/> parameter to <see cref="IntPtr.Zero"/> (which is ignored in this case).
        /// Set the <paramref name="NumberOfConcurrentThreads"/> parameter to the desired concurrency value for the new I/O completion port,
        /// or zero for the default (the number of processors in the system).
        /// The handle passed in the <paramref name="FileHandle"/> parameter can be any handle that supports overlapped I/O.
        /// Most commonly, this is a handle opened by the <see cref="CreateFile"/> function
        /// using the <see cref="FILE_FLAG_OVERLAPPED"/> flag (for example, files, mail slots, and pipes).
        /// Objects created by other functions such as socket can also be associated with an I/O completion port.
        /// For an example using sockets, see <see cref="AcceptEx"/>.
        /// A handle can be associated with only one I/O completion port, and after the association is made,
        /// the handle remains associated with that I/O completion port until it is closed.
        /// For more information on I/O completion port theory, usage, and associated functions, see I/O Completion Ports.
        /// Multiple file handles can be associated with a single I/O completion port by calling <see cref="CreateIoCompletionPort"/> multiple times
        /// with the same I/O completion port handle in the <paramref name="ExistingCompletionPort"/> parameter
        /// and a different file handle in the <paramref name="FileHandle"/> parameter each time.
        /// Use the <paramref name="CompletionKey"/> parameter to help your application track which I/O operations have completed.
        /// This value is not used by <see cref="CreateIoCompletionPort"/> for functional control; rather, it is attached to the file handle
        /// specified in the <paramref name="FileHandle"/> parameter at the time of association with an I/O completion port.
        /// This completion key should be unique for each file handle, and it accompanies the file handle throughout the internal completion queuing process.
        /// It is returned in the <see cref="GetQueuedCompletionStatus"/> function call when a completion packet arrives.
        /// The <paramref name="CompletionKey"/> parameter is also used
        /// by the <see cref="PostQueuedCompletionStatus"/> function to queue your own special-purpose completion packets.
        /// After an instance of an open handle is associated with an I/O completion port, it cannot be used
        /// in the <see cref="ReadFileEx"/> or <see cref="WriteFileEx"/> function because these functions have their own asynchronous I/O mechanisms.
        /// It is best not to share a file handle associated with an I/O completion port
        /// by using either handle inheritance or a call to the <see cref="DuplicateHandle"/> function.
        /// Operations performed with such duplicate handles generate completion notifications.
        /// Careful consideration is advised.
        /// The I/O completion port handle and every file handle associated with that particular I/O completion port are known
        /// as references to the I/O completion port.
        /// The I/O completion port is released when there are no more references to it.
        /// Therefore, all of these handles must be properly closed to release the I/O completion port and its associated system resources.
        /// After these conditions are satisfied, close the I/O completion port handle by calling the <see cref="CloseHandle"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateIoCompletionPort", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateIoCompletionPort([In] IntPtr FileHandle, [In] IntPtr ExistingCompletionPort, [In] UIntPtr CompletionKey,
            [In] uint NumberOfConcurrentThreads);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeviceIoControl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeviceIoControl([In] HANDLE hDevice, [In] IoControlCodes dwIoControlCode, [In] LPVOID lpInBuffer, [In] DWORD nInBufferSize,
            [In] LPVOID lpOutBuffer, [In] DWORD nOutBufferSize, [Out] out DWORD lpBytesReturned, [In] in OVERLAPPED lpOverlapped);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetOverlappedResult", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetOverlappedResult([In] IntPtr hFile, [In] IntPtr lpOverlapped, [Out] out uint lpNumberOfBytesTransferred, [In] bool bWait);

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
        /// <see cref="GetLastError"/> returns <see cref="WAIT_IO_COMPLETION"/>.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetOverlappedResultEx", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetOverlappedResultEx([In] IntPtr hFile, [In] IntPtr lpOverlapped, [Out] out uint lpNumberOfBytesTransferred,
            [In] uint dwMilliseconds, [In] bool bAlertable);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetQueuedCompletionStatus", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetQueuedCompletionStatus([In] IntPtr CompletionPort, [Out] out int lpNumberOfBytesTransferred,
            [Out] out UIntPtr lpCompletionKey, [Out] out IntPtr lpOverlapped, [In] uint dwMilliseconds);

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
        /// contained in the <see cref="OVERLAPPED_ENTRY.lpOverlapped"/> member in each <see cref="OVERLAPPED_ENTRY"/>.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetQueuedCompletionStatusEx", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetQueuedCompletionStatusEx([In] IntPtr CompletionPort, [In] IntPtr lpCompletionPortEntries, [In] uint ulCount,
            [Out] out uint ulNumEntriesRemoved, [In] uint dwMilliseconds, [In] bool fAlertable);

        /// <summary>
        /// <para>
        /// Provides a high performance test operation that can be used to poll for the completion of an outstanding I/O operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-hasoverlappediocompleted
        /// </para>
        /// </summary>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure that was specified when the overlapped I/O operation was started.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Do not call this macro unless the call to <see cref="GetLastError"/> returns <see cref="ERROR_IO_PENDING"/>,
        /// indicating that the overlapped I/O has started.
        /// To cancel all pending asynchronous I/O operations, use the <see cref="CancelIo"/> function.
        /// The <see cref="CancelIo"/> function only cancels operations issued by the calling thread for the specified file handle.
        /// I/O operations that are canceled complete with the error <see cref="ERROR_OPERATION_ABORTED"/>.
        /// To get more details about a completed I/O operation,
        /// call the <see cref="GetOverlappedResult"/> or <see cref="GetQueuedCompletionStatus"/> function.
        /// </remarks>
        public static bool HasOverlappedIoCompleted(OVERLAPPED lpOverlapped) => ((UIntPtr)lpOverlapped.Internal).SafeToUInt32() != (uint)STATUS_PENDING;

        /// <summary>
        /// <para>
        /// Sets the current configuration of a communications device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-setcommconfig
        /// </para>
        /// </summary>
        /// <param name="hCommDev">
        /// A handle to the open communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpCC">
        /// A pointer to a <see cref="COMMCONFIG"/> structure.
        /// </param>
        /// <param name="dwSize">
        /// The size of the structure pointed to by <paramref name="lpCC"/>, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCommConfig", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCommConfig([In] HANDLE hCommDev, [In] IntPtr lpCC, [In] DWORD dwSize);

        /// <summary>
        /// <para>
        /// Waits for an event to occur for a specified communications device.
        /// The set of events that are monitored by this function is contained in the event mask associated with the device handle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-waitcommevent
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpEvtMask">
        /// A pointer to a variable that receives a mask indicating the type of event that occurred.
        /// If an error occurs, the value is zero; otherwise, it is one of the following values.
        /// <see cref="EV_BREAK"/>, <see cref="EV_CTS"/>, <see cref="EV_DSR"/>, <see cref="EV_ERR"/>, <see cref="EV_RING"/>,
        /// <see cref="EV_RLSD"/>, <see cref="EV_RXCHAR"/>, <see cref="EV_RXFLAG"/>, <see cref="EV_TXEMPTY"/>
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure.
        /// This structure is required if <paramref name="hFile"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/>.
        /// If <paramref name="hFile"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// the <paramref name="lpOverlapped"/> parameter must not be <see cref="NullRef{OVERLAPPED}"/>.
        /// It must point to a valid <see cref="OVERLAPPED"/> structure.
        /// If <paramref name="hFile"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/> and
        /// <paramref name="lpOverlapped"/> is <see cref="NullRef{OVERLAPPED}"/>, the function can incorrectly report that the operation is complete.
        /// If <paramref name="hFile"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/> and
        /// <paramref name="lpOverlapped"/> is not <see cref="NullRef{OVERLAPPED}"/>, <see cref="WaitCommEvent"/> is performed as an overlapped operation.
        /// In this case, the OVERLAPPED structure must contain a handle to a manual-reset event object
        /// (created by using the <see cref="CreateEvent"/> function).
        /// If <paramref name="hFile"/> was not opened with <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// <see cref="WaitCommEvent"/> does not return until one of the specified events or an error occurs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The WaitCommEvent function monitors a set of events for a specified communications resource.
        /// To set and query the current event mask of a communications resource, use the <see cref="SetCommMask"/> and <see cref="GetCommMask"/> functions.
        /// If the overlapped operation cannot be completed immediately, the function returns <see cref="FALSE"/> and
        /// the <see cref="GetLastError"/> function returns <see cref="ERROR_IO_PENDING"/>, indicating that the operation is executing in the background.
        /// When this happens, the system sets the <see cref="OVERLAPPED.hEvent"/> member of the <see cref="OVERLAPPED"/> structure
        /// to the not-signaled state before <see cref="WaitCommEvent"/> returns, and then it sets it to the signaled state
        /// when one of the specified events or an error occurs.
        /// The calling process can use one of the wait functions to determine the event object's state
        /// and then use the <see cref="GetOverlappedResult"/> function to determine the results of the <see cref="WaitCommEvent"/> operation.
        /// <see cref="GetOverlappedResult"/> reports the success or failure of the operation,
        /// and the variable pointed to by the <paramref name="lpEvtMask"/> parameter is set to indicate the event that occurred.
        /// If a process attempts to change the device handle's event mask by using the <see cref="SetCommMask"/> function
        /// while an overlapped <see cref="WaitCommEvent"/> operation is in progress, <see cref="WaitCommEvent"/> returns immediately.
        /// The variable pointed to by the <paramref name="lpEvtMask"/> parameter is set to zero.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitCommEvent", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WaitCommEvent([In] HANDLE hFile, [Out] out CommEvents lpEvtMask, [In] in OVERLAPPED lpOverlapped);
    }
}
