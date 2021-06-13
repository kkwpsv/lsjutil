using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes an entry from a list of the threads executing in the system when a snapshot was taken.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/tlhelp32/ns-tlhelp32-threadentry32"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct THREADENTRY32
    {
        /// <summary>
        /// The size of the structure, in bytes. Before calling the <see cref="Thread32First"/> function,
        /// set this member to <code>sizeof(THREADENTRY32)</code>.
        /// If you do not initialize dwSize, <see cref="Thread32First"/> fails.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public DWORD cntUsage;

        /// <summary>
        /// The thread identifier, compatible with the thread identifier returned by the <see cref="CreateProcess"/> function.
        /// </summary>
        public DWORD th32ThreadID;

        /// <summary>
        /// The identifier of the process that created the thread.
        /// </summary>
        public DWORD th32OwnerProcessID;

        /// <summary>
        /// The kernel base priority level assigned to the thread.
        /// The priority is a number from 0 to 31, with 0 representing the lowest possible thread priority.
        /// For more information, see KeQueryPriorityThread.
        /// </summary>
        public LONG tpBasePri;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public LONG tpDeltaPri;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public DWORD dwFlags;
    }
}
