using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the position and color of a gradient stop.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_gradient_stop"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Gradient stops can be specified in any order if they are at different positions.
    /// Two stops may share a position.
    /// In this case, the first stop specified is treated as the "low" stop (nearer 0.0f) and subsequent stops are treated as "higher" (nearer 1.0f).
    /// This behavior is useful if a caller wants an instant transition in the middle of a stop.
    /// </para>
    /// <para>
    /// Typically, there are at least two points in a collection, although creation with only one stop is permitted.
    /// For example, one point is at position 0.0f, another point is at position 1.0f,
    /// and additional points are distributed in the [0, 1] range.
    /// Where the gradient progression is beyond the range of [0, 1], the stops are stored, but may affect the gradient.
    /// </para>
    /// <para>
    /// When drawn, the [0, 1] range of positions is mapped to the brush, in a brush-dependent way.
    /// For details, see <see cref="ID2D1LinearGradientBrush"/> and <see cref="ID2D1RadialGradientBrush"/>.
    /// </para>
    /// <para>
    /// Gradient stops with a position outside the [0, 1] range cannot be seen explicitly,
    /// but they can still affect the colors produced in the [0, 1] range.
    /// For example, a two-stop gradient {{0.0f, Black}, {2.0f, White}} is indistinguishable visually from {{0.0f, Black}, {1.0f, Mid-level gray}}.
    /// Also, the colors are clamped before interpolation.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_GRADIENT_STOP
    {
        /// <summary>
        /// A value that indicates the relative position of the gradient stop in the brush.
        /// This value must be in the [0.0f, 1.0f] range if the gradient stop is to be seen explicitly.
        /// </summary>
        public FLOAT position;

        /// <summary>
        /// The color of the gradient stop.
        /// </summary>
        public D2D1_COLOR_F color;
    }
}
