namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Pen Style
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createpen
    /// </para>
    /// </summary>
    public enum PenStyles
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
    }
}
