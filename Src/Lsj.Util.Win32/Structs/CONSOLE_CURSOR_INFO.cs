using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the console cursor.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/console/console-cursor-info-str
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONSOLE_CURSOR_INFO
    {
        /// <summary>
        /// The percentage of the character cell that is filled by the cursor. This value is between 1 and 100.
        /// The cursor appearance varies, ranging from completely filling the cell to showing up as a horizontal line at the bottom of the cell.
        /// Note
        /// While the <see cref="dwSize"/> value is normally between 1 and 100, under some circumstances a value outside of that range might be returned.
        /// For example, if CursorSize is set to 0 in the registry, the <see cref="dwSize"/> value returned would be 0.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// The visibility of the cursor.
        /// If the cursor is visible, this member is <see cref="TRUE"/>.
        /// </summary>
        public BOOL bVisible;
    }
}
