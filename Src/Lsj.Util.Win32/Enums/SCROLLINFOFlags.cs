using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="SCROLLINFO"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-scrollinfo"/>
    /// </para>
    /// </summary>
    public enum SCROLLINFOFlags : uint
    {
        /// <summary>
        /// The <see cref="SCROLLINFO.nMin"/> and <see cref="SCROLLINFO.nMax"/> members contain the minimum and maximum values for the scrolling range.
        /// </summary>
        SIF_RANGE = 0x0001,

        /// <summary>
        /// The <see cref="SCROLLINFO.nPage"/> member contains the page size for a proportional scroll bar.
        /// </summary>
        SIF_PAGE = 0x0002,

        /// <summary>
        /// The <see cref="SCROLLINFO.nPos"/> member contains the scroll box position, which is not updated while the user drags the scroll box.
        /// </summary>
        SIF_POS = 0x0004,

        /// <summary>
        /// This value is used only when setting a scroll bar's parameters.
        /// If the scroll bar's new parameters make the scroll bar unnecessary, disable the scroll bar instead of removing it.
        /// </summary>
        SIF_DISABLENOSCROLL = 0x0008,

        /// <summary>
        /// The <see cref="SCROLLINFO.nTrackPos"/> member contains the current position of the scroll box while the user is dragging it.
        /// </summary>
        SIF_TRACKPOS = 0x0010,

        /// <summary>
        /// Combination of <see cref="SIF_PAGE"/>, <see cref="SIF_POS"/>, <see cref="SIF_RANGE"/>, and <see cref="SIF_TRACKPOS"/>.
        /// </summary>
        SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS),
    }
}
