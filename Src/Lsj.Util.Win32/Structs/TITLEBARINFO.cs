using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ObjectStateConstants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains title bar information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-titlebarinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TITLEBARINFO
    {
        /// <summary>
        /// The size, in bytes, of the structure.
        /// The caller must set this member to <code>sizeof(TITLEBARINFO)</code>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// The coordinates of the title bar.
        /// These coordinates include all title-bar elements except the window menu.
        /// </summary>
        public RECT rcTitleBar;

        /// <summary>
        /// An array that receives a value for each element of the title bar.
        /// The following are the title bar elements represented by the array.
        /// Index   Title Bar Element
        /// 0       The title bar itself.
        /// 1       Reserved.
        /// 2       Minimize button.
        /// 3       Maximize button.
        /// 4       Help button.
        /// 5       Close button.
        /// Each array element is a combination of one or more of the following values.
        /// <see cref="STATE_SYSTEM_FOCUSABLE"/>: The element can accept the focus.
        /// <see cref="STATE_SYSTEM_INVISIBLE"/>: The element is invisible.
        /// <see cref="STATE_SYSTEM_OFFSCREEN"/>: The element has no visible representation.
        /// <see cref="STATE_SYSTEM_UNAVAILABLE"/>: The element is unavailable.
        /// <see cref="STATE_SYSTEM_PRESSED"/>: The element is in the pressed state.
        /// </summary>
        public ByValDWORDArrayStructForSize6 rgstate;
    }
}
