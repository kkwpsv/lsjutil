using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the information returned by a call to the <see cref="GetQueuedCompletionStatusEx"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-overlapped_entry"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OVERLAPPED_ENTRY
    {
        /// <summary>
        /// Receives the completion key value associated with the file handle whose I/O operation has completed.
        /// A completion key is a per-file key that is specified in a call to <see cref="CreateIoCompletionPort"/>.
        /// </summary>
        public ULONG_PTR lpCompletionKey;

        /// <summary>
        /// Receives the address of the <see cref="OVERLAPPED"/> structure that was specified when the completed I/O operation was started.
        /// </summary>
        public IntPtr lpOverlapped;

        /// <summary>
        /// Reserved.
        /// </summary>
        public ULONG_PTR Internal;

        /// <summary>
        /// Receives the number of bytes transferred during the I/O operation that has completed.
        /// </summary>
        public DWORD dwNumberOfBytesTransferred;
    }
}
