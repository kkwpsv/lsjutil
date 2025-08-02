using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ScrollBarCommands;
using static Lsj.Util.Win32.Enums.ScrollBarMessages;
using static Lsj.Util.Win32.Enums.SCROLLINFOFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="SCROLLINFO"/> structure contains scroll bar parameters to be set
    /// by the <see cref="SetScrollInfo"/> function (or <see cref="SBM_SETSCROLLINFO"/> message),
    /// or retrieved by the <see cref="GetScrollInfo"/> function (or <see cref="SBM_GETSCROLLINFO"/> message).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-scrollinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SCROLLINFO
    {
        /// <summary>
        /// Specifies the size, in bytes, of this structure.
        /// The caller must set this to <code>sizeof(SCROLLINFO)</code>.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// <para>
        /// Specifies the scroll bar parameters to set or retrieve.
        /// This member can be a combination of the following values:
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
        /// <see cref="SIF_ALL"/>
        /// </term>
        /// <term>
        /// Combination of <see cref="SIF_PAGE"/>, <see cref="SIF_POS"/>, <see cref="SIF_RANGE"/>, and <see cref="SIF_TRACKPOS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIF_DISABLENOSCROLL"/>
        /// </term>
        /// <term>
        /// This value is used only when setting a scroll bar's parameters.
        /// If the scroll bar's new parameters make the scroll bar unnecessary, disable the scroll bar instead of removing it.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIF_PAGE"/>
        /// </term>
        /// <term>
        /// The <see cref="nPage"/> member contains the page size for a proportional scroll bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIF_POS"/>
        /// </term>
        /// <term>
        /// The <see cref="nPos"/> member contains the scroll box position, which is not updated while the user drags the scroll box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIF_RANGE"/>
        /// </term>
        /// <term>
        /// The <see cref="nMin"/> and <see cref="nMax"/> members contain the minimum and maximum values for the scrolling range.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIF_TRACKPOS"/>
        /// </term>
        /// <term>
        /// The <see cref="nTrackPos"/> member contains the current position of the scroll box while the user is dragging it.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public SCROLLINFOFlags fMask;

        /// <summary>
        /// Specifies the minimum scrolling position.
        /// </summary>
        public int nMin;

        /// <summary>
        /// Specifies the maximum scrolling position.
        /// </summary>
        public int nMax;

        /// <summary>
        /// Specifies the page size, in device units.
        /// A scroll bar uses this value to determine the appropriate size of the proportional scroll box.
        /// </summary>
        public UINT nPage;

        /// <summary>
        /// Specifies the position of the scroll box.
        /// </summary>
        public int nPos;

        /// <summary>
        /// Specifies the immediate position of a scroll box that the user is dragging.
        /// An application can retrieve this value while processing the <see cref="SB_THUMBTRACK"/> request code.
        /// An application cannot set the immediate scroll position; the <see cref="SetScrollInfo"/> function ignores this member.
        /// </summary>
        public int nTrackPos;
    }
}
