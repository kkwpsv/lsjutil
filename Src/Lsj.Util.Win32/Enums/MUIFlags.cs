using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// MUIFlags
    /// </summary>
    [Flags]
    public enum MUIFlags : uint
    {
        /// <summary>
        /// MUI_LANGUAGE_ID
        /// </summary>
        MUI_LANGUAGE_ID = 0x4,

        /// <summary>
        /// MUI_LANGUAGE_NAME
        /// </summary>
        MUI_LANGUAGE_NAME = 0x8,

        /// <summary>
        /// MUI_USER_PREFERRED_UI_LANGUAGES
        /// </summary>
        MUI_USER_PREFERRED_UI_LANGUAGES = 0x10,

        /// <summary>
        /// MUI_USE_INSTALLED_LANGUAGES
        /// </summary>
        MUI_USE_INSTALLED_LANGUAGES = 0x20,

        /// <summary>
        /// MUI_USE_SEARCH_ALL_LANGUAGES
        /// </summary>
        MUI_USE_SEARCH_ALL_LANGUAGES = 0x40,

        /// <summary>
        /// MUI_LANG_NEUTRAL_PE_FILE
        /// </summary>
        MUI_LANG_NEUTRAL_PE_FILE = 0x100,

        /// <summary>
        /// MUI_NON_LANG_NEUTRAL_FILE
        /// </summary>
        MUI_NON_LANG_NEUTRAL_FILE = 0x200,
    }
}
