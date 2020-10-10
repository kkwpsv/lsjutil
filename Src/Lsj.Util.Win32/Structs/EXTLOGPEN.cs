using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.BrushStyles;
using static Lsj.Util.Win32.Enums.DIBColorTableIdentifiers;
using static Lsj.Util.Win32.Enums.GlobalMemoryFlags;
using static Lsj.Util.Win32.Enums.HatchStyles;
using static Lsj.Util.Win32.Enums.LocalMemoryFlags;
using static Lsj.Util.Win32.Enums.PenStyles;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="EXTLOGPEN"/> structure defines the pen style, width, and brush attributes for an extended pen.
    /// This structure is used by the <see cref="GetObject"/> function when it retrieves a description of a pen that was create
    /// when an application called the <see cref="ExtCreatePen"/> function.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-extlogpen
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct EXTLOGPEN
    {
        /// <summary>
        /// A combination of pen type, style, end cap style, and join style.
        /// The values from each category can be retrieved by using a bitwise AND operator with the appropriate mask.
        /// The <see cref="elpPenStyle"/> member masked with <see cref="PS_TYPE_MASK"/> has one of the following pen type values.
        /// <see cref="PS_GEOMETRIC"/>: The pen is geometric.
        /// <see cref="PS_COSMETIC"/>: The pen is cosmetic.
        /// The <see cref="elpPenStyle"/> member masked with <see cref="PS_STYLE_MASK"/> has one of the following pen styles values:
        /// <see cref="PS_DASH"/>: The pen is dashed.
        /// <see cref="PS_DASHDOT"/>: The pen has alternating dashes and dots.
        /// <see cref="PS_DASHDOTDOT"/>: The pen has alternating dashes and double dots.
        /// <see cref="PS_DOT"/>: The pen is dotted.
        /// <see cref="PS_INSIDEFRAME"/>:
        /// The pen is solid. When this pen is used in any GDI drawing function that takes a bounding rectangle,
        /// the dimensions of the figure are shrunk so that it fits entirely in the bounding rectangle, taking into account the width of the pen.
        /// This applies only to <see cref="PS_GEOMETRIC"/> pens.
        /// <see cref="PS_NULL"/>: The pen is invisible.
        /// <see cref="PS_SOLID"/>: The pen is solid.
        /// <see cref="PS_USERSTYLE"/>: The pen uses a styling array supplied by the user.
        /// The following category applies only to <see cref="PS_GEOMETRIC"/> pens.
        /// The <see cref="elpPenStyle"/> member masked with <see cref="PS_ENDCAP_MASK"/> has one of the following end cap values.
        /// <see cref="PS_ENDCAP_FLAT"/>: Line end caps are flat.
        /// <see cref="PS_ENDCAP_ROUND"/>: Line end caps are round.
        /// <see cref="PS_ENDCAP_SQUARE"/>: Line end caps are square.
        /// The following category applies only to <see cref="PS_GEOMETRIC"/> pens.
        /// The <see cref="elpPenStyle"/> member masked with <see cref="PS_JOIN_MASK"/> has one of the following join values.
        /// <see cref="PS_JOIN_BEVEL"/>: Line joins are beveled.
        /// <see cref="PS_JOIN_MITER"/>:
        /// Line joins are mitered when they are within the current limit set by the <see cref="SetMiterLimit"/> function.
        /// A join is beveled when it would exceed the limit.
        /// <see cref="PS_JOIN_ROUND"/>: Line joins are round.
        /// </summary>
        public PenStyles elpPenStyle;

        /// <summary>
        /// The width of the pen.
        /// If the <see cref="elpPenStyle"/> member is <see cref="PS_GEOMETRIC"/>, this value is the width of the line in logical units.
        /// Otherwise, the lines are cosmetic and this value is 1, which indicates a line with a width of one pixel.
        /// </summary>
        public DWORD elpWidth;

        /// <summary>
        /// The brush style of the pen.
        /// The <see cref="elpBrushStyle"/> member value can be one of the following.
        /// <see cref="BS_DIBPATTERN"/>:
        /// Specifies a pattern brush defined by a DIB specification.
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_DIBPATTERN"/>, the <see cref="elpHatch"/> member contains a handle to a packed DIB.
        /// For more information, see discussion in <see cref="elpHatch"/>.
        /// <see cref="BS_DIBPATTERNPT"/>:
        /// Specifies a pattern brush defined by a DIB specification.
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_DIBPATTERNPT"/>, the <see cref="elpHatch"/> member contains a pointer to a packed DIB.
        /// For more information, see discussion in <see cref="elpHatch"/>.
        /// <see cref="BS_HATCHED"/>: Specifies a hatched brush.
        /// <see cref="BS_HOLLOW"/>: Specifies a hollow or NULL brush.
        /// <see cref="BS_PATTERN"/>: Specifies a pattern brush defined by a memory bitmap.
        /// <see cref="BS_SOLID"/>: Specifies a solid brush.
        /// </summary>
        public BrushStyles elpBrushStyle;

        /// <summary>
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_SOLID"/> or <see cref="BS_HATCHED"/>,
        /// <see cref="elpColor"/> specifies the color in which the pen is to be drawn.
        /// For <see cref="BS_HATCHED"/>, the <see cref="SetBkMode"/> and <see cref="SetBkColor"/> functions determine the background color.
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_HOLLOW"/> or <see cref="BS_PATTERN"/>, <see cref="elpColor"/> is ignored.
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_DIBPATTERN"/> or <see cref="BS_DIBPATTERNPT"/>,
        /// the low-order word of <see cref="elpColor"/> specifies whether the <see cref="BITMAPINFO.bmiColors"/> member
        /// of the <see cref="BITMAPINFO"/> structure contain explicit RGB values or indices into the currently realized logical palette.
        /// The <see cref="elpColor"/> value must be one of the following.
        /// <see cref="DIB_PAL_COLORS"/>: The color table consists of an array of 16-bit indices into the currently realized logical palette.
        /// <see cref="DIB_RGB_COLORS"/>: The color table contains literal RGB values.
        /// The <see cref="RGB"/> macro is used to generate a <see cref="COLORREF"/> structure.
        /// </summary>
        public COLORREF elpColor;

        /// <summary>
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_PATTERN"/>, <see cref="elpHatch"/> is a handle to the bitmap that defines the pattern.
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_SOLID"/> or <see cref="BS_HOLLOW"/>, <see cref="elpHatch"/> is ignored.
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_DIBPATTERN"/>, the <see cref="elpHatch"/> member is a handle to a packed DIB.
        /// To obtain this handle, an application calls the <see cref="GlobalAlloc"/> function with <see cref="GMEM_MOVEABLE"/>
        /// (or <see cref="LocalAlloc"/> with <see cref="LMEM_MOVEABLE"/>) to allocate a block of memory and then fills the memory with the packed DIB.
        /// A packed DIB consists of a <see cref="BITMAPINFO"/> structure immediately followed by the array of bytes that define the pixels of the bitmap.
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_DIBPATTERNPT"/>, the <see cref="elpHatch"/> member is a pointer to a packed DIB.
        /// The pointer derives from the memory block created by <see cref="LocalAlloc"/> with <see cref="LMEM_FIXED"/> set
        /// or by <see cref="GlobalAlloc"/> with <see cref="GMEM_FIXED"/> set,
        /// or it is the pointer returned by a call like <see cref="LocalLock"/> (handle_to_the_dib).
        /// A packed DIB consists of a <see cref="BITMAPINFO"/> structure immediately followed by the array of bytes that define the pixels of the bitmap.
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_HATCHED"/>, the <see cref="elpHatch"/> member
        /// specifies the orientation of the lines used to create the hatch.
        /// It can be one of the following values.
        /// <see cref="HS_BDIAGONAL"/>: 45-degree upward hatch (left to right)
        /// <see cref="HS_CROSS"/>: Horizontal and vertical crosshatch
        /// <see cref="HS_DIAGCROSS"/>: 45-degree crosshatch
        /// <see cref="HS_FDIAGONAL"/>: 45-degree downward hatch (left to right)
        /// <see cref="HS_HORIZONTAL"/>: Horizontal hatch
        /// <see cref="HS_VERTICAL"/>: Vertical hatch
        /// </summary>
        public ULONG_PTR elpHatch;

        /// <summary>
        /// The number of entries in the style array in the <see cref="elpStyleEntry"/> member.
        /// This value is zero if <see cref="elpPenStyle"/> does not specify <see cref="PS_USERSTYLE"/>.
        /// </summary>
        public DWORD elpNumEntries;

        /// <summary>
        /// A user-supplied style array.
        /// The array is specified with a finite length, but it is used as if it repeated indefinitely.
        /// The first entry in the array specifies the length of the first dash.
        /// The second entry specifies the length of the first gap.
        /// Thereafter, lengths of dashes and gaps alternate.
        /// If elpWidth specifies geometric lines, the lengths are in logical units.
        /// Otherwise, the lines are cosmetic and lengths are in device units.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public DWORD[] elpStyleEntry;
    }
}
