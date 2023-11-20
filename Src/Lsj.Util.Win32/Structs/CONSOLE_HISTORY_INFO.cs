using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the console history.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/console-history-info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONSOLE_HISTORY_INFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// Set this member to <code>sizeof(CONSOLE_HISTORY_INFO)</code>.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// The number of commands kept in each history buffer.
        /// </summary>
        public UINT HistoryBufferSize;

        /// <summary>
        /// The number of history buffers kept for this console process.
        /// </summary>
        public UINT NumberOfHistoryBuffers;

        /// <summary>
        /// This parameter can be zero or the following value.
        /// <see cref="HISTORY_NO_DUP_FLAG"/>: 	Duplicate entries will not be stored in the history buffer.
        /// </summary>
        public DWORD dwFlags;
    }
}
