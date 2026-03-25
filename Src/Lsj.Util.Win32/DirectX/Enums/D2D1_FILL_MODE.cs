using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how the intersecting areas of geometries or figures are combined to form the area of the composite geometry.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_fill_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use the <see cref="D2D1_FILL_MODE"/> enumeration when creating an <see cref="ID2D1GeometryGroup"/>
    /// with the <see cref="ID2D1Factory.CreateGeometryGroup"/> method,
    /// or when modifying the fill mode of an <see cref="ID2D1SimplifiedGeometrySink"/>
    /// with the <see cref="ID2D1SimplifiedGeometrySink.SetFillMode"/> method.
    /// </para>
    /// <para>
    /// Direct2D fills the interior of a path by using one of the two fill modes specified by this enumeration:
    /// <see cref="D2D1_FILL_MODE_ALTERNATE"/> (alternate) or <see cref="D2D1_FILL_MODE_WINDING"/> (winding).
    /// Because the modes determine how to fill the interior of a closed shape,
    /// all shapes are treated as closed when they are filled.
    /// If there is a gap in a segment in a shape, draw an imaginary line to close it.
    /// </para>
    /// <para>
    /// To see the difference between the winding and alternate fill modes,
    /// assume that you have four circles with the same center and a different radius,
    /// as shown in the following illustration.
    /// The first one has the radius of 25, the second 50, the third 75, and the fourth 100.
    /// The following illustration shows the shape filled by using the alternate fill mode.
    /// Notice that the center and third ring are not filled.
    /// This is because a ray drawn from any point in either of those two rings passes through an even number of segments.
    /// </para>
    /// <para>
    /// The following illustration explains this process.
    /// </para>
    /// <para>
    /// The following illustration shows how the same shape is filled when the winding fill mode is specified.
    /// </para>
    /// <para>
    /// Notice that all the rings are filled.
    /// This is because all the segments run in the same direction,
    /// so a ray drawn from any point will cross one or more segments, and the sum of the crossings will not equal zero.
    /// </para>
    /// <para>
    /// The following illustration explains this process.
    /// The red arrows represent the direction in which the segments are drawn
    /// and the black arrow represents an arbitrary ray that runs from a point in the innermost ring.
    /// Starting with a value of zero, for each segment that the ray crosses,
    /// a value of one is added for every clockwise intersection.
    /// All points lie in the fill region in this illustration, because the count does not equal zero.
    /// </para>
    /// </remarks>
    public enum D2D1_FILL_MODE : uint
    {
        /// <summary>
        /// Determines whether a point is in the fill region
        /// by drawing a ray from that point to infinity in any direction,
        /// and then counting the number of path segments within the given shape that the ray crosses.
        /// If this number is odd, the point is in the fill region; if even, the point is outside the fill region.
        /// </summary>
        D2D1_FILL_MODE_ALTERNATE = 0,

        /// <summary>
        /// Determines whether a point is in the fill region of the path
        /// by drawing a ray from that point to infinity in any direction,
        /// and then examining the places where a segment of the shape crosses the ray.
        /// Starting with a count of zero, add one each time a segment crosses the ray from left to right
        /// and subtract one each time a path segment crosses the ray from right to left,
        /// as long as left and right are seen from the perspective of the ray.
        /// After counting the crossings, if the result is zero, then the point is outside the path.
        /// Otherwise, it is inside the path.
        /// </summary>
        D2D1_FILL_MODE_WINDING = 1,

        /// <summary>
        /// 
        /// </summary>
        D2D1_FILL_MODE_FORCE_DWORD = 0xffffffff,
    }
}
