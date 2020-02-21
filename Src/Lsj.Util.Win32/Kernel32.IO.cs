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
    }
}
