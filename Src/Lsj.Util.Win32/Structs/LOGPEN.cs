using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.PenStyles;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="LOGPEN"/> structure defines the style, width, and color of a pen.
    /// The <see cref="CreatePenIndirect"/> function uses the <see cref="LOGPEN"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-logpen"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the width of the pen is greater than 1 and the pen style is <see cref="PS_INSIDEFRAME"/>,
    /// the line is drawn inside the frame of all GDI objects except polygons and polylines.
    /// If the pen color does not match an available RGB value, the pen is drawn with a logical (dithered) color.
    /// If the pen width is less than or equal to 1, the <see cref="PS_INSIDEFRAME"/> style is identical to the <see cref="PS_SOLID"/> style.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOGPEN
    {
        /// <summary>
        /// <para>
        /// The pen style, which can be one of the following values.
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
        /// <see cref="PS_SOLID"/>
        /// </term>
        /// <term>
        /// The pen is solid.
        /// </term>
        /// </item>
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
        /// <see cref="PS_DOT"/>
        /// </term>
        /// <term>
        /// The pen is dotted.
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
        /// The pen has dashes and double dots.
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
        /// <see cref="PS_INSIDEFRAME"/>
        /// </term>
        /// <term>
        /// The pen is solid.
        /// When this pen is used in any GDI drawing function that takes a bounding rectangle,
        /// the dimensions of the figure are shrunk so that it fits entirely in the bounding rectangle,
        /// taking into account the width of the pen.
        /// This applies only to geometric pens.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PenStyles lopnStyle;

        /// <summary>
        /// The <see cref="POINT"/> structure that contains the pen width, in logical units.
        /// If the pointer member is NULL, the pen is one pixel wide on raster devices.
        /// The <see cref="POINT.y"/> member in the <see cref="POINT"/> structure for <see cref="lopnWidth"/> is not used.
        /// </summary>
        public POINT lopnWidth;

        /// <summary>
        /// The pen color.
        /// To generate a <see cref="COLORREF"/> structure, use the <see cref="RGB"/> macro.
        /// </summary>
        public COLORREF lopnColor;
    }
}
