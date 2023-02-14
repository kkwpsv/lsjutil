using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// To create a scroll bar control using the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function specify the SCROLLBAR class,
    /// appropriate window style constants, and a combination of the following scroll bar control styles.
    /// Some of the styles create a scroll bar control that uses a default width or height.
    /// However, you must always specify the x- and y-coordinates and the other dimensions of the scroll bar
    /// when you call <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/scroll-bar-control-styles"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum ScrollBarControlStyles : uint
    {
        /// <summary>
        /// Aligns the bottom edge of the scroll bar with the bottom edge of the rectangle
        /// defined by the x, y, nWidth, and nHeight parameters of <see cref="CreateWindowEx"/> function.
        /// The scroll bar has the default height for system scroll bars. Use this style with the <see cref="SBS_HORZ"/> style.
        /// </summary>
        SBS_BOTTOMALIGN = 0x0004,

        /// <summary>
        /// Designates a horizontal scroll bar.
        /// If neither the <see cref="SBS_BOTTOMALIGN"/> nor <see cref="SBS_TOPALIGN"/> style is specified,
        /// the scroll bar has the height, width, and position specified by the x, y, nWidth, and nHeight parameters of <see cref="CreateWindowEx"/>.
        /// </summary>
        SBS_HORZ = 0x0000,

        /// <summary>
        /// Aligns the left edge of the scroll bar with the left edge of the rectangle
        /// defined by the x, y, nWidth, and nHeight parameters of <see cref="CreateWindowEx"/>.
        /// The scroll bar has the default width for system scroll bars.
        /// Use this style with the <see cref="SBS_VERT"/> style.
        /// </summary>
        SBS_LEFTALIGN = 0x0002,

        /// <summary>
        /// Aligns the right edge of the scroll bar with the right edge of the rectangle
        /// defined by the x, y, nWidth, and nHeight parameters of <see cref="CreateWindowEx"/>.
        /// The scroll bar has the default width for system scroll bars.
        /// Use this style with the <see cref="SBS_VERT"/> style.
        /// </summary>
        SBS_RIGHTALIGN = 0x0004,

        /// <summary>
        /// Designates a size box.
        /// If you specify neither the <see cref="SBS_SIZEBOXBOTTOMRIGHTALIGN"/> nor the <see cref="SBS_SIZEBOXTOPLEFTALIGN"/> style,
        /// the size box has the height, width, and position specified by the x, y, nWidth, and nHeight parameters of <see cref="CreateWindowEx"/>.
        /// </summary>
        SBS_SIZEBOX = 0x0008,

        /// <summary>
        /// Aligns the lower right corner of the size box with the lower right corner of the rectangle
        /// specified by the x, y, nWidth, and nHeight parameters of <see cref="CreateWindowEx"/>.
        /// The size box has the default size for system size boxes. Use this style with the <see cref="SBS_SIZEBOX"/> or <see cref="SBS_SIZEGRIP"/> styles.
        /// </summary>
        SBS_SIZEBOXBOTTOMRIGHTALIGN = 0x0004,

        /// <summary>
        /// Aligns the upper left corner of the size box with the upper left corner of the rectangle
        /// specified by the x, y, nWidth, and nHeight parameters of <see cref="CreateWindowEx"/>.
        /// The size box has the default size for system size boxes.
        /// Use this style with the <see cref="SBS_SIZEBOX"/> or <see cref="SBS_SIZEGRIP"/> styles.
        /// </summary>
        SBS_SIZEBOXTOPLEFTALIGN = 0x0002,

        /// <summary>
        /// Same as <see cref="SBS_SIZEBOX"/>, but with a raised edge.
        /// </summary>
        SBS_SIZEGRIP = 0x0010,

        /// <summary>
        /// Aligns the top edge of the scroll bar with the top edge of the rectangle
        /// defined by the x, y, nWidth, and nHeight parameters of <see cref="CreateWindowEx"/>.
        /// The scroll bar has the default height for system scroll bars.
        /// Use this style with the <see cref="SBS_HORZ"/> style.
        /// </summary>
        SBS_TOPALIGN = 0x0002,

        /// <summary>
        /// Designates a vertical scroll bar.
        /// If you specify neither the <see cref="SBS_RIGHTALIGN"/> nor the <see cref="SBS_LEFTALIGN"/> style,
        /// the scroll bar has the height, width, and position specified by the x, y, nWidth, and nHeight parameters of <see cref="CreateWindowEx"/>.
        /// </summary>
        SBS_VERT = 0x0001,
    }
}
