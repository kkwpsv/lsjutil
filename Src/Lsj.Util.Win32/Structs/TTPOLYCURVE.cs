using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.TTPOLYCURVETypes;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="TTPOLYCURVE"/> structure contains information about a curve in the outline of a TrueType character.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-ttpolycurve"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When an application calls the <see cref="GetGlyphOutline"/> function,
    /// a glyph outline for a TrueType character is returned in a <see cref="TTPOLYGONHEADER"/> structure,
    /// followed by as many <see cref="TTPOLYCURVE"/> structures as are required to describe the glyph.
    /// All points are returned as <see cref="POINTFX"/> structures and represent absolute positions, not relative moves.
    /// The starting point specified by the <see cref="TTPOLYGONHEADER.pfxStart"/> member of the <see cref="TTPOLYGONHEADER"/> structure
    /// is the point at which the outline for a contour begins.
    /// The <see cref="TTPOLYCURVE"/> structures that follow can be either polyline records or spline records.
    /// </para>
    /// <para>
    /// Polyline records are a series of points; lines drawn between the points describe the outline of the character.
    /// Spline records represent the quadratic curves (that is, quadratic b-splines) used by TrueType.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TTPOLYCURVE
    {
        /// <summary>
        /// <para>
        /// The type of curve described by the structure. This member can be one of the following values.
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
        /// <see cref="TT_PRIM_LINE"/>
        /// </term>
        /// <term>
        /// Curve is a polyline.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TT_PRIM_QSPLINE"/>
        /// </term>
        /// <term>
        /// Curve is a quadratic Bézier spline.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TT_PRIM_CSPLINE"/>
        /// </term>
        /// <term>
        /// Curve is a cubic Bézier spline.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public TTPOLYCURVETypes wType;

        /// <summary>
        /// The number of <see cref="POINTFX"/> structures in the array.
        /// </summary>
        public WORD cpfx;

        /// <summary>
        /// Specifies an array of <see cref="POINTFX"/> structures that define the polyline or Bézier spline.
        /// </summary>
        public POINTFX apfx;
    }
}
