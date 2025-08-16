using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="TTPOLYCURVE"/> types
    /// </summary>
    public enum TrueTypePolyCurveTypes : ushort
    {
        /// <summary>
        /// Curve is a polyline.
        /// </summary>
        TT_PRIM_LINE = 1,

        /// <summary>
        /// Curve is a quadratic Bézier spline.
        /// </summary>
        TT_PRIM_QSPLINE = 2,

        /// <summary>
        /// Curve is a cubic Bézier spline.
        /// </summary>
        TT_PRIM_CSPLINE = 3,
    }
}
