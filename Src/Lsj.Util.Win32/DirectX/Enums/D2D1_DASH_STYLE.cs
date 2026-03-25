namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes the sequence of dashes and gaps in a stroke.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_dash_style"/>
    /// </para>
    /// </summary>
    public enum D2D1_DASH_STYLE : uint
    {
        /// <summary>
        /// A solid line with no breaks.
        /// </summary>
        D2D1_DASH_STYLE_SOLID = 0,

        /// <summary>
        /// <para>
        /// A dash followed by a gap of equal length.
        /// The dash and the gap are each twice as long as the stroke thickness.
        /// </para>
        /// <para>
        /// The equivalent dash array for <see cref="D2D1_DASH_STYLE_DASH"/> is {2, 2}.
        /// </para>
        /// </summary>
        D2D1_DASH_STYLE_DASH = 1,

        /// <summary>
        /// <para>
        /// A dot followed by a longer gap.
        /// </para>
        /// <para>
        /// The equivalent dash array for <see cref="D2D1_DASH_STYLE_DOT"/> is {0, 2}.
        /// </para>
        /// </summary>
        D2D1_DASH_STYLE_DOT = 2,

        /// <summary>
        /// <para>
        /// A dash, followed by a gap, followed by a dot, followed by another gap.
        /// </para>
        /// <para>
        /// The equivalent dash array for <see cref="D2D1_DASH_STYLE_DASH_DOT"/> is {2, 2, 0, 2}.
        /// </para>
        /// </summary>
        D2D1_DASH_STYLE_DASH_DOT = 3,

        /// <summary>
        /// <para>
        /// A dash, followed by a gap, followed by a dot, followed by another gap, followed by another dot, followed by another gap.
        /// </para>
        /// <para>
        /// The equivalent dash array for <see cref="D2D1_DASH_STYLE_DASH_DOT_DOT"/> is {2, 2, 0, 2, 0, 2}.
        /// </para>
        /// </summary>
        D2D1_DASH_STYLE_DASH_DOT_DOT = 4,

        /// <summary>
        /// The dash pattern is specified by an array of floating-point values.
        /// </summary>
        D2D1_DASH_STYLE_CUSTOM = 5,

        /// <summary>
        /// 
        /// </summary>
        D2D1_DASH_STYLE_FORCE_DWORD = 0xffffffff
    }
}
