namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Border Flags
    /// </summary>
    public enum BorderFlags : uint
    {
        /// <summary>
        /// BF_LEFT
        /// </summary>
        BF_LEFT = 0x0001,

        /// <summary>
        /// BF_TOP
        /// </summary>
        BF_TOP = 0x0002,

        /// <summary>
        /// BF_RIGHT
        /// </summary>
        BF_RIGHT = 0x0004,

        /// <summary>
        /// BF_BOTTOM
        /// </summary>
        BF_BOTTOM = 0x0008,

        /// <summary>
        /// BF_TOPLEFT
        /// </summary>
        BF_TOPLEFT = BF_TOP | BF_LEFT,

        /// <summary>
        /// BF_TOPRIGHT
        /// </summary>
        BF_TOPRIGHT = BF_TOP | BF_RIGHT,

        /// <summary>
        /// BF_BOTTOMLEFT
        /// </summary>
        BF_BOTTOMLEFT = BF_BOTTOM | BF_LEFT,

        /// <summary>
        /// BF_BOTTOMRIGHT
        /// </summary>
        BF_BOTTOMRIGHT = BF_BOTTOM | BF_RIGHT,

        /// <summary>
        /// BF_RECT
        /// </summary>
        BF_RECT = BF_LEFT | BF_TOP | BF_RIGHT | BF_BOTTOM,

        /// <summary>
        /// BF_DIAGONAL
        /// </summary>
        BF_DIAGONAL = 0x0010,

        /// <summary>
        /// BF_DIAGONAL_ENDTOPRIGHT
        /// </summary>
        BF_DIAGONAL_ENDTOPRIGHT = BF_DIAGONAL | BF_TOP | BF_RIGHT,

        /// <summary>
        /// BF_DIAGONAL_ENDTOPLEFT
        /// </summary>
        BF_DIAGONAL_ENDTOPLEFT = BF_DIAGONAL | BF_TOP | BF_LEFT,

        /// <summary>
        /// BF_DIAGONAL_ENDBOTTOMLEFT
        /// </summary>
        BF_DIAGONAL_ENDBOTTOMLEFT = BF_DIAGONAL | BF_BOTTOM | BF_LEFT,

        /// <summary>
        /// BF_DIAGONAL_ENDBOTTOMRIGHT
        /// </summary>
        BF_DIAGONAL_ENDBOTTOMRIGHT = BF_DIAGONAL | BF_BOTTOM | BF_RIGHT,

        /// <summary>
        /// BF_MIDDLE
        /// </summary>
        BF_MIDDLE = 0x0800,

        /// <summary>
        /// BF_SOFT
        /// </summary>
        BF_SOFT = 0x1000,

        /// <summary>
        /// BF_ADJUST
        /// </summary>
        BF_ADJUST = 0x2000,

        /// <summary>
        /// BF_FLAT
        /// </summary>
        BF_FLAT = 0x4000,

        /// <summary>
        /// BF_MONO
        /// </summary>
        BF_MONO = 0x8000,
    }
}
