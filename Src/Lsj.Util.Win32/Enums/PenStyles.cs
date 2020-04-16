namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Pen Style
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createpen
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-extcreatepen
    /// </para>
    /// </summary>
    public enum PenStyles : uint
    {
        /// <summary>
        /// The pen is solid.
        /// </summary>
        PS_SOLID = 0,

        /// <summary>
        /// The pen is dashed. This style is valid only when the pen width is one or less in device units.
        /// </summary>
        PS_DASH = 1,

        /// <summary>
        /// The pen is dotted. This style is valid only when the pen width is one or less in device units.
        /// </summary>
        PS_DOT = 2,

        /// <summary>
        /// The pen has alternating dashes and dots. This style is valid only when the pen width is one or less in device units.
        /// </summary>
        PS_DASHDOT = 3,

        /// <summary>
        /// The pen has alternating dashes and double dots. This style is valid only when the pen width is one or less in device units.
        /// </summary>
        PS_DASHDOTDOT = 4,

        /// <summary>
        /// The pen is invisible.
        /// </summary>
        PS_NULL = 5,

        /// <summary>
        /// The pen is solid.
        /// When this pen is used in any GDI drawing function that takes a bounding rectangle,
        /// the dimensions of the figure are shrunk so that it fits entirely in the bounding rectangle, taking into account the width of the pen.
        /// This applies only to geometric pens.
        /// </summary>
        PS_INSIDEFRAME = 6,

        /// <summary>
        /// The pen uses a styling array supplied by the user.
        /// </summary>
        PS_USERSTYLE = 7,

        /// <summary>
        /// The pen sets every other pixel. (This style is applicable only for cosmetic pens.)
        /// </summary>
        PS_ALTERNATE = 8,

        /// <summary>
        /// End caps are round.
        /// </summary>
        PS_ENDCAP_ROUND = 0x00000000,

        /// <summary>
        /// End caps are square.
        /// </summary>
        PS_ENDCAP_SQUARE = 0x00000100,

        /// <summary>
        /// End caps are flat.
        /// </summary>
        PS_ENDCAP_FLAT = 0x00000200,

        /// <summary>
        /// PS_ENDCAP_MASK
        /// </summary>
        PS_ENDCAP_MASK = 0x00000F00,

        /// <summary>
        /// Joins are round.
        /// </summary>
        PS_JOIN_ROUND = 0x00000000,

        /// <summary>
        /// Joins are beveled.
        /// </summary>
        PS_JOIN_BEVEL = 0x00001000,

        /// <summary>
        /// Joins are mitered when they are within the current limit set by the <see cref="SetMiterLimit"/> function.
        /// If it exceeds this limit, the join is beveled.
        /// </summary>
        PS_JOIN_MITER = 0x00002000,

        /// <summary>
        /// PS_JOIN_MASK
        /// </summary>
        PS_JOIN_MASK = 0x0000F000,

        /// <summary>
        /// The pen is cosmetic.
        /// </summary>
        PS_COSMETIC = 0x00000000,

        /// <summary>
        /// The pen is geometric.
        /// </summary>
        PS_GEOMETRIC = 0x00010000,

        /// <summary>
        /// PS_TYPE_MASK
        /// </summary>
        PS_TYPE_MASK = 0x000F0000,
    }
}
