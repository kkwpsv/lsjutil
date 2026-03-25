namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes the shape at the end of a line or segment.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_cap_style"/>
    /// </para>
    /// </summary>
    public enum D2D1_CAP_STYLE : uint
    {
        /// <summary>
        /// A cap that does not extend past the last point of the line.
        /// Comparable to cap used for objects other than lines.
        /// </summary>
        D2D1_CAP_STYLE_FLAT = 0,

        /// <summary>
        /// Half of a square that has a length equal to the line thickness.
        /// </summary>
        D2D1_CAP_STYLE_SQUARE = 1,

        /// <summary>
        /// A semicircle that has a diameter equal to the line thickness.
        /// </summary>
        D2D1_CAP_STYLE_ROUND = 2,

        /// <summary>
        /// An isosceles right triangle whose hypotenuse is equal in length to the thickness of the line.
        /// </summary>
        D2D1_CAP_STYLE_TRIANGLE = 3,

        /// <summary>
        /// 
        /// </summary>
        D2D1_CAP_STYLE_FORCE_DWORD = 0xffffffff
    }
}
