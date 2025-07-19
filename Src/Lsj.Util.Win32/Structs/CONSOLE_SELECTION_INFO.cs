using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information for a console selection.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/console-selection-info-str"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONSOLE_SELECTION_INFO
    {
        /// <summary>
        /// <para>
        /// The selection indicator. This member can be one or more of the following values.
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
        /// <see cref="CONSOLE_MOUSE_DOWN"/> 0x0008
        /// </term>
        /// <term>
        /// Mouse is down. The user is actively adjusting the selection rectangle with a mouse.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CONSOLE_MOUSE_SELECTION"/> 0x0004
        /// </term>
        /// <term>
        /// Selecting with the mouse. If off, the user is operating conhost.exe mark mode selection with the keyboard.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CONSOLE_NO_SELECTION"/> 0x0000
        /// </term>
        /// <term>
        /// No selection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CONSOLE_SELECTION_IN_PROGRESS"/> 0x0001
        /// </term>
        /// <term>
        /// Selection has begun. If a mouse selection, this will typically not occur without the <see cref="CONSOLE_SELECTION_NOT_EMPTY"/> flag.
        /// If a keyboard selection, this may occur when mark mode has been entered but the user is still navigating to the initial position.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CONSOLE_SELECTION_NOT_EMPTY"/> 0x0002
        /// </term>
        /// <term>
        /// Selection rectangle not empty. The payload of <see cref="dwSelectionAnchor"/> and <see cref="srSelection "/> are valid.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD dwFlags;

        /// <summary>
        /// A <see cref="COORD"/> structure that specifies the selection anchor, in characters.
        /// </summary>
        public COORD dwSelectionAnchor;

        /// <summary>
        /// A <see cref="SMALL_RECT"/> structure that specifies the selection rectangle.
        /// </summary>
        public SMALL_RECT srSelection;
    }
}
