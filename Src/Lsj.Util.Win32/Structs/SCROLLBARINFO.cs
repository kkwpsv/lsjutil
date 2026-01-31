using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ObjectStateConstants;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="SCROLLBARINFO"/> structure contains scroll bar information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-scrollbarinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SCROLLBARINFO
    {
        /// <summary>
        /// Specifies the size, in bytes, of the structure.
        /// Before calling the <see cref="GetScrollBarInfo"/> function,
        /// set <see cref="cbSize"/> to <c>sizeof(SCROLLBARINFO)</c>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// Coordinates of the scroll bar as specified in a <see cref="RECT"/> structure.
        /// </summary>
        public RECT rcScrollBar;

        /// <summary>
        /// Height or width of the thumb.
        /// </summary>
        public int dxyLineButton;

        /// <summary>
        /// Position of the top or left of the thumb.
        /// </summary>
        public int xyThumbTop;

        /// <summary>
        /// Position of the bottom or right of the thumb.
        /// </summary>
        public int xyThumbBottom;

        /// <summary>
        /// Reserved.
        /// </summary>
        public int reserved;

        /// <summary>
        /// <para>
        /// An array of <see cref="DWORD"/> elements.
        /// Each element indicates the state of a scroll bar component.
        /// The following values show the scroll bar component that corresponds to each array index.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Index
        /// </term>
        /// <term>
        /// Scroll bar component
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// The scroll bar itself.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// The top or right arrow button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// The page up or page right region.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 3
        /// </term>
        /// <term>
        /// The scroll box (thumb).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 4
        /// </term>
        /// <term>
        /// The page down or page left region.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5
        /// </term>
        /// <term>
        /// The bottom or left arrow button.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="DWORD"/> element for each scroll bar component can include a combination of the following bit flags.
        /// </para>
        /// <para>
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
        /// <see cref="STATE_SYSTEM_INVISIBLE"/>
        /// </term>
        /// <term>
        /// For the scroll bar itself, indicates the specified vertical or horizontal scroll bar does not exist.
        /// For the page up or page down regions,
        /// indicates the thumb is positioned such that the region does not exist.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STATE_SYSTEM_OFFSCREEN"/>
        /// </term>
        /// <term>
        /// For the scroll bar itself, indicates the window is sized such
        /// that the specified vertical or horizontal scroll bar is not currently displayed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STATE_SYSTEM_PRESSED"/>
        /// </term>
        /// <term>
        /// The arrow button or page region is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STATE_SYSTEM_UNAVAILABLE"/>
        /// </term>
        /// <term>
        /// The component is disabled.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public ByValDWORDArrayStructForSize6 rgstate;
    }
}
