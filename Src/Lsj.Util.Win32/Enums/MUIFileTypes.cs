namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// MUI file types
    /// </summary>
    public enum MUIFileTypes : uint
    {
        /// <summary>
        /// MUI_FILETYPE_NOT_LANGUAGE_NEUTRAL
        /// </summary>
        MUI_FILETYPE_NOT_LANGUAGE_NEUTRAL = 0x001,

        /// <summary>
        /// MUI_FILETYPE_LANGUAGE_NEUTRAL_MAIN
        /// </summary>
        MUI_FILETYPE_LANGUAGE_NEUTRAL_MAIN = 0x002,

        /// <summary>
        /// MUI_FILETYPE_LANGUAGE_NEUTRAL_MUI
        /// </summary>
        MUI_FILETYPE_LANGUAGE_NEUTRAL_MUI = 0x004,
    }
}
