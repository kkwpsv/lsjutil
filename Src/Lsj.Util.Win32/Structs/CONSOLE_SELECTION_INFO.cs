using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
        /// The selection indicator.
        /// This member can be one or more of the following values.
        /// <see cref="CONSOLE_MOUSE_DOWN"/>:
        /// Mouse is down.
        /// The user is actively adjusting the selection rectangle with a mouse.
        /// <see cref="CONSOLE_MOUSE_SELECTION"/>:
        /// Selecting with the mouse.
        /// If off, the user is operating conhost.exe mark mode selection with the keyboard.
        /// <see cref="CONSOLE_NO_SELECTION"/>:
        /// No selection.
        /// <see cref="CONSOLE_SELECTION_IN_PROGRESS"/>:
        /// Selection has begun.
        /// If a mouse selection, this will typically not occur without the <see cref="CONSOLE_SELECTION_NOT_EMPTY"/> flag.
        /// If a keyboard selection, this may occur when mark mode has been entered but the user is still navigating to the initial position.
        /// <see cref="CONSOLE_SELECTION_NOT_EMPTY"/>:
        /// Selection rectangle not empty.
        /// The payload of <see cref="dwSelectionAnchor"/> and <see cref="srSelection"/> are valid.
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
