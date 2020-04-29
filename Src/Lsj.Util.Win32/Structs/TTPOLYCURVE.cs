using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.TTPOLYCURVETypes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="TTPOLYCURVE"/> structure contains information about a curve in the outline of a TrueType character.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-ttpolycurve
    /// </para>
    /// </summary>
    /// <remarks>
    /// When an application calls the <see cref="GetGlyphOutline"/> function, a glyph outline for a TrueType character
    /// is returned in a <see cref="TTPOLYGONHEADER"/> structure, followed by as many <see cref="TTPOLYCURVE"/> structures
    /// as are required to describe the glyph.
    /// All points are returned as <see cref="POINTFX"/> structures and represent absolute positions, not relative moves.
    /// The starting point specified by the <see cref="TTPOLYGONHEADER.pfxStart"/> member of the <see cref="TTPOLYGONHEADER"/> structure is the point
    /// at which the outline for a contour begins.
    /// The <see cref="TTPOLYCURVE"/> structures that follow can be either polyline records or spline records.
    /// Polyline records are a series of points; lines drawn between the points describe the outline of the character. Spline records represent the quadratic curves (that is, quadratic b-splines) used by TrueType.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TTPOLYCURVE
    {
        /// <summary>
        /// The type of curve described by the structure. This member can be one of the following values.
        /// <see cref="TT_PRIM_LINE"/>, <see cref="TT_PRIM_QSPLINE"/>, <see cref="TT_PRIM_CSPLINE"/>
        /// </summary>
        public TTPOLYCURVETypes wType;

        /// <summary>
        /// The number of <see cref="POINTFX"/> structures in the array.
        /// </summary>
        public WORD cpfx;

        /// <summary>
        /// Specifies an array of <see cref="POINTFX"/> structures that define the polyline or Bézier spline.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public POINTFX[] apfx;
    }
}
