using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information used in asynchronous (or overlapped) input and output (I/O).
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-overlapped"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Any unused members of this structure should always be initialized to zero before the structure is used in a function call.
    /// Otherwise, the function may fail and return <see cref="ERROR_INVALID_PARAMETER"/>.
    /// The <see cref="Offset"/> and <see cref="OffsetHigh"/> members together represent a 64-bit file position.
    /// It is a byte offset from the start of the file or file-like device, and it is specified by the user; the system will not modify these values.
    /// The calling process must set this member before passing the <see cref="OVERLAPPED"/> structure to functions that use an offset,
    /// such as the <see cref="ReadFile"/> or <see cref="WriteFile"/> (and related) functions.
    /// You can use the <see cref="HasOverlappedIoCompleted"/> macro to check whether an asynchronous I/O operation has completed
    /// if <see cref="GetOverlappedResult"/> is too cumbersome for your application.
    /// You can use the <see cref="CancelIo"/> function to cancel an asynchronous I/O operation.
    /// A common mistake is to reuse an <see cref="OVERLAPPED"/> structure before the previous asynchronous operation has been completed.
    /// You should use a separate structure for each request.
    /// You should also create an event object for each thread that processes data.
    /// If you store the event handles in an array, you could easily wait for all events
    /// to be signaled using the <see cref="WaitForMultipleObjects"/> function.
    /// For additional information and potential pitfalls of asynchronous I/O usage,
    /// see <see cref="CreateFile"/>, <see cref="ReadFile"/>, <see cref="WriteFile"/>, and related functions.
    /// For a general synchronization overview and conceptual <see cref="OVERLAPPED"/> usage information,
    /// see Synchronization and Overlapped Input and Output and related topics.
    /// For a file I/O–oriented overview of synchronous and asynchronous I/O, see Synchronous and Asynchronous I/O.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OVERLAPPED
    {
        /// <summary>
        /// The status code for the I/O request.
        /// When the request is issued, the system sets this member to <see cref="STATUS_PENDING"/> to indicate that the operation has not yet started.
        /// When the request is completed, the system sets this member to the status code for the completed request.
        /// The <see cref="Internal"/> member was originally reserved for system use and its behavior may change.
        /// </summary>
        public ULONG_PTR Internal;

        /// <summary>
        /// The number of bytes transferred for the I/O request.
        /// The system sets this member if the request is completed without errors.
        /// The <see cref="InternalHigh"/> member was originally reserved for system use and its behavior may change.
        /// </summary>
        public ULONG_PTR InternalHigh;

        /// <summary>
        /// 
        /// </summary>
#pragma warning disable IDE1006 // 命名样式
        private OVERLAPPED_DUMMYUNIONNAME DUMMYUNIONNAME;
#pragma warning restore IDE1006 // 命名样式

        /// <summary>
        /// The low-order portion of the file position at which to start the I/O request, as specified by the user.
        /// This member is nonzero only when performing I/O requests on a seeking device that supports the concept of an offset
        /// (also referred to as a file pointer mechanism), such as a file.
        /// Otherwise, this member must be zero.
        /// For additional information, see Remarks.
        /// </summary>
        public uint Offset
        {
            get => DUMMYUNIONNAME.Offset;
            set => DUMMYUNIONNAME.Offset = value;
        }

        /// <summary>
        /// The high-order portion of the file position at which to start the I/O request, as specified by the user.
        /// This member is nonzero only when performing I/O requests on a seeking device that supports the concept of an offset
        /// (also referred to as a file pointer mechanism), such as a file.
        /// Otherwise, this member must be zero.
        /// For additional information, see Remarks.
        /// </summary>
        public uint OffsetHigh
        {
            get => DUMMYUNIONNAME.OffsetHigh;
            set => DUMMYUNIONNAME.OffsetHigh = value;
        }

        /// <summary>
        /// Reserved for system use; do not use after initialization to zero.
        /// </summary>
        public PVOID Pointer
        {
            get => DUMMYUNIONNAME.Pointer;
            set => DUMMYUNIONNAME.Pointer = value;
        }

        /// <summary>
        /// A handle to the event that will be set to a signaled state by the system when the operation has completed.
        /// The user must initialize this member either to zero or a valid event handle
        /// using the <see cref="CreateEvent"/> function before passing this structure to any overlapped functions.
        /// This event can then be used to synchronize simultaneous I/O requests for a device.
        /// For additional information, see Remarks.
        /// Functions such as <see cref="ReadFile"/> and <see cref="WriteFile"/> set this handle to the nonsignaled state
        /// before they begin an I/O operation.
        /// When the operation has completed, the handle is set to the signaled state.
        /// Functions such as <see cref="GetOverlappedResult"/> and the synchronization wait functions reset auto-reset events to the nonsignaled state.
        /// Therefore, you should use a manual reset event; if you use an auto-reset event,
        /// your application can stop responding if you wait for the operation to complete and
        /// then call <see cref="GetOverlappedResult"/> with the bWait parameter set to <see langword="true"/>.
        /// </summary>
        public HANDLE hEvent;

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct OVERLAPPED_DUMMYUNIONNAME
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public uint Offset;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(4)]
            public uint OffsetHigh;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public PVOID Pointer;
        }
    }
}
