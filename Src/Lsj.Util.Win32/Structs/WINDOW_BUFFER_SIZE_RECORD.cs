using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ConsoleModes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a change in the size of the console screen buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/console/window-buffer-size-record-str"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Buffer size events are placed in the input buffer when the console is in window-aware mode (<see cref="ENABLE_WINDOW_INPUT"/>).
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WINDOW_BUFFER_SIZE_RECORD
    {
        /// <summary>
        /// A <see cref="COORD"/> structure that contains the size of the console screen buffer, in character cell columns and rows.
        /// </summary>
        public COORD dwSize;
    }
}
