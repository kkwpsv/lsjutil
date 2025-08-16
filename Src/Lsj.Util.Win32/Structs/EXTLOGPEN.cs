using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.BrushStyles;
using static Lsj.Util.Win32.Enums.DIBColorTableUsages;
using static Lsj.Util.Win32.Enums.GlobalMemoryFlags;
using static Lsj.Util.Win32.Enums.HatchStyles;
using static Lsj.Util.Win32.Enums.LocalMemoryFlags;
using static Lsj.Util.Win32.Enums.PenStyles;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="EXTLOGPEN"/> structure defines the pen style, width, and brush attributes for an extended pen.
    /// This structure is used by the <see cref="GetObject"/> function when it retrieves a description of a pen that was create
    /// when an application called the <see cref="ExtCreatePen"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-extlogpen"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct EXTLOGPEN
    {
        /// <summary>
        /// <para>
        /// A combination of pen type, style, end cap style, and join style.
        /// The values from each category can be retrieved by using a bitwise AND operator with the appropriate mask.
        /// </para>
        /// <para>
        /// The <see cref="elpPenStyle"/> member masked with <see cref="PS_TYPE_MASK"/> has one of the following pen type values.
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
        /// <see cref="PS_GEOMETRIC"/>
        /// </term>
        /// <term>
        /// The pen is geometric.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_COSMETIC"/>
        /// </term>
        /// <term>
        /// The pen is cosmetic.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The <see cref="elpPenStyle"/> member masked with <see cref="PS_STYLE_MASK"/> has one of the following pen styles values:
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
        /// <see cref="PS_DASH"/>
        /// </term>
        /// <term>
        /// The pen is dashed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DASHDOT"/>
        /// </term>
        /// <term>
        /// The pen has alternating dashes and dots.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DASHDOTDOT"/>
        /// </term>
        /// <term>
        /// The pen has alternating dashes and double dots.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DOT"/>
        /// </term>
        /// <term>
        /// The pen is dotted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_INSIDEFRAME"/>
        /// </term>
        /// <term>
        /// The pen is solid.
        /// When this pen is used in any GDI drawing function that takes a bounding rectangle,
        /// the dimensions of the figure are shrunk so that it fits entirely in the bounding rectangle,
        /// taking into account the width of the pen.
        /// This applies only to <see cref="PS_GEOMETRIC"/> pens.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_NULL"/>
        /// </term>
        /// <term>
        /// The pen is invisible.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_SOLID"/>
        /// </term>
        /// <term>
        /// The pen is solid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_USERSTYLE"/>
        /// </term>
        /// <term>
        /// The pen uses a styling array supplied by the user.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The following category applies only to <see cref="PS_GEOMETRIC"/> pens.
        /// The <see cref="elpPenStyle"/> member masked with <see cref="PS_ENDCAP_MASK"/> has one of the following end cap values.
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
        /// <see cref="PS_ENDCAP_FLAT"/>
        /// </term>
        /// <term>
        /// Line end caps are flat.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_ENDCAP_ROUND"/>
        /// </term>
        /// <term>
        /// Line end caps are round.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_ENDCAP_SQUARE"/>
        /// </term>
        /// <term>
        /// Line end caps are square.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The following category applies only to <see cref="PS_GEOMETRIC"/> pens.
        /// The <see cref="elpPenStyle"/> member masked with <see cref="PS_JOIN_MASK"/> has one of the following join values.
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
        /// <see cref="PS_JOIN_BEVEL"/>
        /// </term>
        /// <term>
        /// Line joins are beveled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_JOIN_MITER"/>
        /// </term>
        /// <term>
        /// Line joins are mitered when they are within the current limit set by the <see cref="SetMiterLimit"/> function.
        /// A join is beveled when it would exceed the limit.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_JOIN_ROUND"/>
        /// </term>
        /// <term>
        /// Line joins are round.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PenStyles elpPenStyle;

        /// <summary>
        /// The width of the pen.
        /// If the <see cref="elpPenStyle"/> member is <see cref="PS_GEOMETRIC"/>, this value is the width of the line in logical units.
        /// Otherwise, the lines are cosmetic and this value is 1, which indicates a line with a width of one pixel.
        /// </summary>
        public DWORD elpWidth;

        /// <summary>
        /// <para>
        /// The brush style of the pen. The <see cref="elpBrushStyle"/> member value can be one of the following.
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
        /// <see cref="BS_DIBPATTERN"/>
        /// </term>
        /// <term>
        /// Specifies a pattern brush defined by a DIB specification.
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_DIBPATTERN"/>, the <see cref="elpHatch"/> member contains a handle to a packed DIB.
        /// For more information, see discussion in <see cref="elpHatch"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_DIBPATTERNPT"/>
        /// </term>
        /// <term>
        /// Specifies a pattern brush defined by a DIB specification.
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_DIBPATTERNPT"/>, the <see cref="elpHatch"/> member contains a pointer to a packed DIB.
        /// For more information, see discussion in <see cref="elpHatch"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_HATCHED"/>
        /// </term>
        /// <term>
        /// Specifies a hatched brush.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_HOLLOW"/>
        /// </term>
        /// <term>
        /// Specifies a hollow or <see cref="NULL"/> brush.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_PATTERN"/>
        /// </term>
        /// <term>
        /// Specifies a pattern brush defined by a memory bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_SOLID"/>
        /// </term>
        /// <term>
        /// Specifies a solid brush.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public BrushStyles elpBrushStyle;

        /// <summary>
        /// <para>
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_SOLID"/> or <see cref="BS_HATCHED"/>,
        /// <see cref="elpColor"/> specifies the color in which the pen is to be drawn.
        /// For <see cref="BS_HATCHED"/>, the <see cref="SetBkMode"/> and <see cref="SetBkColor"/> functions determine the background color.
        /// </para>
        /// <para>
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_HOLLOW"/> or <see cref="BS_PATTERN"/>, <see cref="elpColor"/> is ignored.
        /// </para>
        /// <para>
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_DIBPATTERN"/> or <see cref="BS_DIBPATTERNPT"/>,
        /// the low-order word of <see cref="elpColor"/> specifies whether the <see cref="BITMAPINFO.bmiColors"/> member
        /// of the <see cref="BITMAPINFO"/> structure contain explicit RGB values or indices into the currently realized logical palette.
        /// The <see cref="elpColor"/> value must be one of the following.
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
        /// <see cref="DIB_PAL_COLORS"/>
        /// </term>
        /// <term>
        /// The color table consists of an array of 16-bit indices into the currently realized logical palette.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DIB_RGB_COLORS"/>
        /// </term>
        /// <term>
        /// The color table contains literal RGB values.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The <see cref="RGB"/> macro is used to generate a <see cref="COLORREF"/> structure.
        /// </para>
        /// </summary>
        public COLORREF elpColor;

        /// <summary>
        /// <para>
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_PATTERN"/>,
        /// <see cref="elpHatch"/> is a handle to the bitmap that defines the pattern.
        /// </para>
        /// <para>
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_SOLID"/> or <see cref="BS_HOLLOW"/>, <see cref="elpHatch"/> is ignored.
        /// </para>
        /// <para>
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_DIBPATTERN"/>, the <see cref="elpHatch"/> member is a handle to a packed DIB.
        /// To obtain this handle, an application calls the <see cref="GlobalAlloc"/> function with <see cref="GMEM_MOVEABLE"/>
        /// (or <see cref="LocalAlloc"/> with <see cref="LMEM_MOVEABLE"/>) to allocate a block of memory and then fills the memory with the packed DIB.
        /// A packed DIB consists of a <see cref="BITMAPINFO"/> structure immediately followed by the array of bytes that define the pixels of the bitmap.
        /// </para>
        /// <para>
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_DIBPATTERNPT"/>, the <see cref="elpHatch"/> member is a pointer to a packed DIB.
        /// The pointer derives from the memory block created by <see cref="LocalAlloc"/> with <see cref="LMEM_FIXED"/> set
        /// or by <see cref="GlobalAlloc"/> with <see cref="GMEM_FIXED"/> set,
        /// or it is the pointer returned by a call like <see cref="LocalLock"/> (handle_to_the_dib).
        /// A packed DIB consists of a <see cref="BITMAPINFO"/> structure immediately followed by the array of bytes that define the pixels of the bitmap.
        /// </para>
        /// <para>
        /// If <see cref="elpBrushStyle"/> is <see cref="BS_HATCHED"/>,
        /// the <see cref="elpHatch"/> member specifies the orientation of the lines used to create the hatch.
        /// It can be one of the following values.
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
        /// <see cref="HS_BDIAGONAL"/>
        /// </term>
        /// <term>
        /// 45-degree upward hatch (left to right)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// HS_CROSS
        /// </term>
        /// <term>
        /// Horizontal and vertical crosshatch
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HS_DIAGCROSS"/>
        /// </term>
        /// <term>
        /// 45-degree crosshatch
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HS_FDIAGONAL"/>
        /// </term>
        /// <term>
        /// 45-degree downward hatch (left to right)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HS_HORIZONTAL"/>
        /// </term>
        /// <term>
        /// Horizontal hatch
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HS_VERTICAL"/>
        /// </term>
        /// <term>
        /// Vertical hatch
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public ULONG_PTR elpHatch;

        /// <summary>
        /// The number of entries in the style array in the <see cref="elpStyleEntry"/> member.
        /// This value is zero if <see cref="elpPenStyle"/> does not specify <see cref="PS_USERSTYLE"/>.
        /// </summary>
        public DWORD elpNumEntries;

        /// <summary>
        /// <para>
        /// A user-supplied style array.
        /// The array is specified with a finite length, but it is used as if it repeated indefinitely.
        /// The first entry in the array specifies the length of the first dash.
        /// The second entry specifies the length of the first gap.
        /// Thereafter, lengths of dashes and gaps alternate.
        /// </para>
        /// <para>
        /// If <see cref="elpWidth"/> specifies geometric lines, the lengths are in logical units.
        /// Otherwise, the lines are cosmetic and lengths are in device units.
        /// </para>
        /// </summary>
        public DWORD elpStyleEntry;
    }
}
