using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the dimensions and corner radii of a rounded rectangle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_rounded_rect"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Each corner of the rectangle specified by <see cref="rect"/> is replaced with a quarter ellipse,
    /// with a radius in each direction specified by <see cref="radiusX"/> and <see cref="radiusY"/>.
    /// </para>
    /// <para>
    /// If <see cref="radiusX"/> is greater than or equal to half the width of the rectangle,
    /// and <see cref="radiusY"/> is greater than or equal to one-half the height,
    /// then the rounded rectangle is an ellipse with the same width and height of <see cref="rect"/>.
    /// </para>
    /// <para>
    /// Even when both <see cref="radiusX"/> and <see cref="radiusY"/> are zero,
    /// the rounded rectangle is different from a rectangle.
    /// When stroked, the corners of the rounded rectangle are roundly joined, not mitered (square).
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_ROUNDED_RECT
    {
        /// <summary>
        /// The coordinates of the rectangle.
        /// </summary>
        public D2D1_RECT_F rect;

        /// <summary>
        /// The x-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.
        /// </summary>
        public FLOAT radiusX;

        /// <summary>
        /// The y-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.
        /// </summary>
        public FLOAT radiusY;
    }
}
