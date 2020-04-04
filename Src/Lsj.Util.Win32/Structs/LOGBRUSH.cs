using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="LOGBRUSH"/> structure defines the style, color, and pattern of a physical brush.
    /// It is used by the <see cref="CreateBrushIndirect"/> and <see cref="ExtCreatePen"/> functions.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Although <see cref="lbColor"/> controls the foreground color of a hatch brush,
    /// the <see cref="SetBkMode"/> and <see cref="SetBkColor"/> functions control the background color.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOGBRUSH
    {
        /// <summary>
        /// The brush style.
        /// The <see cref="lbStyle"/> member must be one of the following styles.
        /// <see cref="BS_DIBPATTERN"/>, <see cref="BS_DIBPATTERN8X8"/>, <see cref="BS_DIBPATTERNPT"/>, <see cref="BS_HATCHED"/>,
        /// <see cref="BS_HOLLOW"/>, <see cref="BS_NULL"/>, <see cref="BS_PATTERN"/>, <see cref="BS_PATTERN8X8"/>, <see cref="BS_SOLID"/>
        /// </summary>
        public BrushStyles lbStyle;

        /// <summary>
        /// The color in which the brush is to be drawn.
        /// If <see cref="lbStyle"/> is the <see cref="BS_HOLLOW"/> or <see cref="BS_PATTERN"/> style, <see cref="lbColor"/> is ignored.
        /// If <see cref="lbStyle"/> is <see cref="BS_DIBPATTERN"/> or <see cref="BS_DIBPATTERNPT"/>,
        /// the low-order word of <see cref="lbColor"/> specifies whether the <see cref="bmiColors"/> members of the <see cref="BITMAPINFO"/> structure
        /// contain explicit red, green, blue (RGB) values or indexes into the currently realized logical palette.
        /// The <see cref="lbColor"/> member must be one of the following values.
        /// <see cref="DIB_PAL_COLORS"/>: The color table consists of an array of 16-bit indexes into the currently realized logical palette.
        /// <see cref="DIB_RGB_COLORS"/>: The color table contains literal RGB values.
        /// If <see cref="lbStyle"/> is <see cref="BS_HATCHED"/> or <see cref="BS_SOLID"/>, <see cref="lbColor"/> is a <see cref="COLORREF"/> color value.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </summary>
        public COLORREF lbColor;

        /// <summary>
        /// A hatch style.
        /// The meaning depends on the brush style defined by <see cref="lbStyle"/>.
        /// If <see cref="lbStyle"/> is <see cref="BS_DIBPATTERN"/>, the lbHatch member contains a handle to a packed DIB.
        /// To obtain this handle, an application calls the <see cref="GlobalAlloc"/> function with <see cref="GMEM_MOVEABLE"/>
        /// (or <see cref="LocalAlloc"/> with <see cref="LMEM_MOVEABLE"/>) to allocate a block of memory and then fills the memory with the packed DIB.
        /// A packed DIB consists of a <see cref="BITMAPINFO"/> structure immediately followed by the array of bytes that define the pixels of the bitmap.
        /// If <see cref="lbStyle"/> is <see cref="BS_DIBPATTERNPT"/>, the lbHatch member contains a pointer to a packed DIB.
        /// The pointer derives from the memory block created by <see cref="LocalAlloc"/> with <see cref="LMEM_FIXED"/> set
        /// or by <see cref="GlobalAlloc"/> with <see cref="GMEM_FIXED"/> set,
        /// or it is the pointer returned by a call like <see cref="LocalLock"/> (handle_to_the_dib).
        /// A packed DIB consists of a <see cref="BITMAPINFO"/> structure immediately followed by the array of bytes that define the pixels of the bitmap.
        /// If <see cref="lbStyle"/> is <see cref="BS_HATCHED"/>, the <see cref="lbHatch"/> member specifies the orientation of the lines
        /// used to create the hatch. It can be one of the following values.
        /// <see cref="HS_BDIAGONAL"/>:  A 45-degree upward, left-to-right hatch
        /// <see cref="HS_CROSS"/>: Horizontal and vertical cross-hatch
        /// <see cref="HS_DIAGCROSS"/>: 45-degree crosshatch
        /// <see cref="HS_FDIAGONAL"/>: A 45-degree downward, left-to-right hatch
        /// <see cref="HS_HORIZONTAL"/>: Horizontal hatch
        /// <see cref="HS_VERTICAL"/>: Vertical hatch
        /// If <see cref="lbStyle"/> is <see cref="BS_PATTERN"/>, <see cref="lbHatch"/> is a handle to the bitmap that defines the pattern.
        /// The bitmap cannot be a DIB section bitmap, which is created by the <see cref="CreateDIBSection"/> function.
        /// If <see cref="lbStyle"/> is <see cref="BS_SOLID"/> or <see cref="BS_HOLLOW"/>, <see cref="lbHatch"/> is ignored.
        /// </summary>
        public ULONG_PTR lbHatch;
    }
}
