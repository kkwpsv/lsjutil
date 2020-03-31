namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Brush Styles
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-logbrush
    /// </para>
    /// </summary>
    public enum BrushStyles : uint
    {
        /// <summary>
        /// Solid brush.
        /// </summary>
        BS_SOLID = 0,

        /// <summary>
        /// Same as <see cref="BS_HOLLOW"/>.
        /// </summary>
        BS_NULL = 1,

        /// <summary>
        /// Hollow brush.
        /// </summary>
        BS_HOLLOW = BS_NULL,

        /// <summary>
        /// Hatched brush.
        /// </summary>
        BS_HATCHED = 2,

        /// <summary>
        /// Pattern brush defined by a memory bitmap.
        /// </summary>
        BS_PATTERN = 3,

        /// <summary>
        /// A pattern brush defined by a device-independent bitmap (DIB) specification.
        /// If lbStyle is <see cref="BS_DIBPATTERN"/>, the lbHatch member contains a handle to a packed DIB.
        /// For more information, see discussion in lbHatch.
        /// </summary>
        BS_DIBPATTERN = 5,

        /// <summary>
        /// A pattern brush defined by a device-independent bitmap (DIB) specification.
        /// If lbStyle is <see cref="BS_DIBPATTERNPT"/>, the lbHatch member contains a pointer to a packed DIB.
        /// For more information, see discussion in lbHatch.
        /// </summary>
        BS_DIBPATTERNPT = 6,

        /// <summary>
        /// See <see cref="BS_PATTERN"/>.
        /// </summary>
        BS_PATTERN8X8 = 7,

        /// <summary>
        /// See <see cref="BS_DIBPATTERN"/>.
        /// </summary>
        BS_DIBPATTERN8X8 = 8,
    }
}
