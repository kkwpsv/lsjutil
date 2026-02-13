namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Logical color spaces
    /// </summary>
    public enum LCSCSTYPE : uint
    {
        /// <summary>
        /// LCS_CALIBRATED_RGB
        /// </summary>
        LCS_CALIBRATED_RGB = 0x00000000,

        /// <summary>
        /// LCS_sRGB
        /// </summary>
        LCS_sRGB = 0x73524742,

        /// <summary>
        /// LCS_WINDOWS_COLOR_SPACE
        /// </summary>
        LCS_WINDOWS_COLOR_SPACE = 0x57696E20,

        /// <summary>
        /// PROFILE_LINKED
        /// </summary>
        PROFILE_LINKED = 0x4C494E4B,

        /// <summary>
        /// PROFILE_EMBEDDED
        /// </summary>
        PROFILE_EMBEDDED = 0x4D424544,
    }
}
