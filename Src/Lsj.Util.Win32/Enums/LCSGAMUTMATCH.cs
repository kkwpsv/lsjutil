namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Logical color space gamut mappings
    /// </summary>
    public enum LCSGAMUTMATCH : uint
    {
        /// <summary>
        /// LCS_GM_ABS_COLORIMETRIC
        /// </summary>
        LCS_GM_ABS_COLORIMETRIC = 0x00000008,

        /// <summary>
        /// LCS_GM_BUSINESS
        /// </summary>
        LCS_GM_BUSINESS = 0x00000001,

        /// <summary>
        /// LCS_GM_GRAPHICS
        /// </summary>
        LCS_GM_GRAPHICS = 0x00000002,

        /// <summary>
        /// LCS_GM_IMAGES
        /// </summary>
        LCS_GM_IMAGES = 0x00000004
    }
}
