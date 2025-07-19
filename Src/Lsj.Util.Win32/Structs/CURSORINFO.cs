using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.CursorStates;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains global cursor information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-cursorinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CURSORINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// The caller must set this to <code>sizeof(CURSORINFO)</code>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// <para>
        /// The cursor state. This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// The cursor is hidden.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CURSOR_SHOWING"/>
        /// </para>
        /// </term>
        /// <term>
        /// The cursor is showing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CURSOR_SUPPRESSED"/>
        /// </para>
        /// </term>
        /// <term>
        /// Windows 8: The cursor is suppressed.
        /// This flag indicates that the system is not drawing the cursor because the user is providing input through touch or pen instead of the mouse.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public CursorStates flags;

        /// <summary>
        /// A handle to the cursor.
        /// </summary>
        public HCURSOR hCursor;

        /// <summary>
        /// A structure that receives the screen coordinates of the cursor.
        /// </summary>
        public POINT ptScreenPos;
    }
}
