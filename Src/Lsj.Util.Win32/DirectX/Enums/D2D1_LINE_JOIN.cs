namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes the shape that joins two lines or segments.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_line_join"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A miter limit affects how sharp miter joins are allowed to be.
    /// If the line join style is <see cref="D2D1_LINE_JOIN_MITER_OR_BEVEL"/>,
    /// then the join will be mitered with regular angular vertices if it doesn't extend beyond the miter limit;
    /// otherwise, the line join will be beveled.
    /// </remarks>
    public enum D2D1_LINE_JOIN : uint
    {
        /// <summary>
        /// Regular angular vertices.
        /// </summary>
        D2D1_LINE_JOIN_MITER = 0,

        /// <summary>
        /// Beveled vertices.
        /// </summary>
        D2D1_LINE_JOIN_BEVEL = 1,

        /// <summary>
        /// Rounded vertices.
        /// </summary>
        D2D1_LINE_JOIN_ROUND = 2,

        /// <summary>
        /// Regular angular vertices unless the join would extend beyond the miter limit; otherwise, beveled vertices.
        /// </summary>
        D2D1_LINE_JOIN_MITER_OR_BEVEL = 3,

        /// <summary>
        /// 
        /// </summary>
        D2D1_LINE_JOIN_FORCE_DWORD = 0xffffffff
    }
}
