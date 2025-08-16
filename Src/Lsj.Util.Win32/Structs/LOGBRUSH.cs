using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.BrushStyles;
using static Lsj.Util.Win32.Enums.DIBColorTableUsages;
using static Lsj.Util.Win32.Enums.GlobalMemoryFlags;
using static Lsj.Util.Win32.Enums.HatchStyles;
using static Lsj.Util.Win32.Enums.LocalMemoryFlags;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="LOGBRUSH"/> structure defines the style, color, and pattern of a physical brush.
    /// It is used by the <see cref="CreateBrushIndirect"/> and <see cref="ExtCreatePen"/> functions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-logbrush"/>
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
        /// <para>
        /// The brush style.
        /// The <see cref="lbStyle"/> member must be one of the following styles.
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
        /// A pattern brush defined by a device-independent bitmap (DIB) specification.
        /// If <see cref="lbStyle"/> is <see cref="BS_DIBPATTERN"/>, the <see cref="lbHatch"/> member contains a handle to a packed DIB.
        /// For more information, see discussion in <see cref="lbHatch"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_DIBPATTERN8X8"/>
        /// </term>
        /// <term>
        /// See <see cref="BS_DIBPATTERN"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_DIBPATTERNPT"/>
        /// </term>
        /// <term>
        /// A pattern brush defined by a device-independent bitmap (DIB) specification.
        /// If <see cref="lbStyle"/> is <see cref="BS_DIBPATTERNPT"/>, the <see cref="lbHatch"/> member contains a pointer to a packed DIB.
        /// For more information, see discussion in <see cref="lbHatch"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_HATCHED"/>
        /// </term>
        /// <term>
        /// Hatched brush.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_HOLLOW"/>
        /// </term>
        /// <term>
        /// Hollow brush.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_NULL"/>
        /// </term>
        /// <term>
        /// Same as <see cref="BS_HOLLOW"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_PATTERN"/>
        /// </term>
        /// <term>
        /// Pattern brush defined by a memory bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_PATTERN8X8"/>
        /// </term>
        /// <term>
        /// See <see cref="BS_PATTERN"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BS_SOLID"/>
        /// </term>
        /// <term>
        /// Solid brush.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public BrushStyles lbStyle;

        /// <summary>
        /// <para>
        /// The color in which the brush is to be drawn.
        /// If <see cref="lbStyle"/> is the <see cref="BS_HOLLOW"/> or <see cref="BS_PATTERN"/> style, <see cref="lbColor"/> is ignored.
        /// </para>
        /// <para>
        /// If <see cref="lbStyle"/> is <see cref="BS_DIBPATTERN"/> or <see cref="BS_DIBPATTERNPT"/>,
        /// the low-order word of <see cref="lbColor"/> specifies whether the <see cref="BITMAPINFO.bmiColors"/> members
        /// of the <see cref="BITMAPINFO"/> structure contain explicit red, green,
        /// blue (RGB) values or indexes into the currently realized logical palette.
        /// The <see cref="lbColor"/> member must be one of the following values.
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
        /// The color table consists of an array of 16-bit indexes into the currently realized logical palette.
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
        /// If <see cref="lbStyle"/> is <see cref="BS_HATCHED"/> or <see cref="BS_SOLID"/>,
        /// <see cref="lbColor"/> is a <see cref="COLORREF"/> color value.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </para>
        /// </summary>
        public COLORREF lbColor;

        /// <summary>
        /// <para>
        /// A hatch style.
        /// The meaning depends on the brush style defined by <see cref="lbStyle"/>.
        /// </para>
        /// <para>
        /// If <see cref="lbStyle"/> is <see cref="BS_DIBPATTERN"/>, the <see cref="lbHatch"/> member contains a handle to a packed DIB.
        /// To obtain this handle, an application calls the <see cref="GlobalAlloc"/> function
        /// with <see cref="GMEM_MOVEABLE"/> (or <see cref="LocalAlloc"/> with <see cref="LMEM_MOVEABLE"/>) to allocate a block of memory
        /// and then fills the memory with the packed DIB.
        /// A packed DIB consists of a <see cref="BITMAPINFO"/> structure immediately followed by the array of bytes that define the pixels of the bitmap.
        /// </para>
        /// <para>
        /// If <see cref="lbStyle"/> is <see cref="BS_DIBPATTERNPT"/>, the <see cref="lbHatch"/> member contains a pointer to a packed DIB.
        /// The pointer derives from the memory block created by <see cref="LocalAlloc"/> with <see cref="LMEM_FIXED"/> set
        /// or by <see cref="GlobalAlloc"/> with <see cref="GMEM_FIXED"/> set,
        /// or it is the pointer returned by a call like <see cref="LocalLock"/> (handle_to_the_dib).
        /// A packed DIB consists of a <see cref="BITMAPINFO"/> structure immediately followed by the array of bytes that define the pixels of the bitmap.
        /// </para>
        /// <para>
        /// If <see cref="lbStyle"/> is <see cref="BS_HATCHED"/>, the <see cref="lbHatch"/> member
        /// specifies the orientation of the lines used to create the hatch.
        /// It can be one of the following values.
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
        /// <see cref="HS_BDIAGONAL"/>
        /// </term>
        /// <term>
        /// A 45-degree upward, left-to-right hatch
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HS_CROSS"/>
        /// </term>
        /// <term>
        /// Horizontal and vertical cross-hatch
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
        /// A 45-degree downward, left-to-right hatch
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
        /// <para>
        /// If <see cref="lbStyle"/> is <see cref="BS_PATTERN"/>, <see cref="lbHatch"/> is a handle to the bitmap that defines the pattern.
        /// The bitmap cannot be a DIB section bitmap, which is created by the <see cref="CreateDIBSection"/> function.
        /// </para>
        /// <para>
        /// If <see cref="lbStyle"/> is <see cref="BS_SOLID"/> or <see cref="BS_HOLLOW"/>, <see cref="lbHatch"/> is ignored.
        /// </para>
        /// </summary>
        public ULONG_PTR lbHatch;
    }
}
