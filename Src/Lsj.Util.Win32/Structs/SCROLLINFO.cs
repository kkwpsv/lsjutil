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
        /// Specifies the scroll bar parameters to set or retrieve.
        /// This member can be a combination of the following values:
        /// <see cref="SIF_ALL"/>, <see cref="SIF_DISABLENOSCROLL"/>, <see cref="SIF_PAGE"/>,
        /// <see cref="SIF_POS"/>, <see cref="SIF_RANGE"/>, <see cref="SIF_TRACKPOS"/>
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
