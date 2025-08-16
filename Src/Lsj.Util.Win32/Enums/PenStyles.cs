namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Pen styles
    /// </summary>
    public enum PenStyles : uint
    {
        /// <summary>
        /// PS_SOLID
        /// </summary>
        PS_SOLID = 0,

        /// <summary>
        /// PS_DASH
        /// </summary>
        PS_DASH = 1,

        /// <summary>
        /// PS_DOT
        /// </summary>
        PS_DOT = 2,

        /// <summary>
        /// PS_DASHDOT
        /// </summary>
        PS_DASHDOT = 3,

        /// <summary>
        /// PS_DASHDOTDOT
        /// </summary>
        PS_DASHDOTDOT = 4,

        /// <summary>
        /// PS_NULL
        /// </summary>
        PS_NULL = 5,

        /// <summary>
        /// PS_INSIDEFRAME
        /// </summary>
        PS_INSIDEFRAME = 6,

        /// <summary>
        /// PS_USERSTYLE
        /// </summary>
        PS_USERSTYLE = 7,

        /// <summary>
        /// PS_ALTERNATE
        /// </summary>
        PS_ALTERNATE = 8,

        /// <summary>
        /// PS_STYLE_MASK
        /// </summary>
        PS_STYLE_MASK = 0x0000000F,

        /// <summary>
        /// PS_ENDCAP_ROUND
        /// </summary>
        PS_ENDCAP_ROUND = 0x00000000,

        /// <summary>
        /// PS_ENDCAP_SQUARE
        /// </summary>
        PS_ENDCAP_SQUARE = 0x00000100,

        /// <summary>
        /// PS_ENDCAP_FLAT
        /// </summary>
        PS_ENDCAP_FLAT = 0x00000200,

        /// <summary>
        /// PS_ENDCAP_MASK
        /// </summary>
        PS_ENDCAP_MASK = 0x00000F00,

        /// <summary>
        /// PS_JOIN_ROUND
        /// </summary>
        PS_JOIN_ROUND = 0x00000000,

        /// <summary>
        /// PS_JOIN_BEVEL
        /// </summary>
        PS_JOIN_BEVEL = 0x00001000,

        /// <summary>
        /// PS_JOIN_MITER
        /// </summary>
        PS_JOIN_MITER = 0x00002000,

        /// <summary>
        /// PS_JOIN_MASK
        /// </summary>
        PS_JOIN_MASK = 0x0000F000,

        /// <summary>
        /// PS_COSMETIC
        /// </summary>
        PS_COSMETIC = 0x00000000,

        /// <summary>
        /// PS_GEOMETRIC
        /// </summary>
        PS_GEOMETRIC = 0x00010000,

        /// <summary>
        /// PS_TYPE_MASK
        /// </summary>
        PS_TYPE_MASK = 0x000F0000,
    }
}
