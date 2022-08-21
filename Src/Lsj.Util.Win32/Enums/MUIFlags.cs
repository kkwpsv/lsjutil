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
        /// MUI_MERGE_SYSTEM_FALLBACK
        /// </summary>
        MUI_MERGE_SYSTEM_FALLBACK = 0x10,

        /// <summary>
        /// MUI_MERGE_USER_FALLBACK
        /// </summary>
        MUI_MERGE_USER_FALLBACK = 0x20,

        /// <summary>
        /// MUI_UI_FALLBACK
        /// </summary>
        MUI_UI_FALLBACK = MUI_MERGE_SYSTEM_FALLBACK | MUI_MERGE_USER_FALLBACK,

        /// <summary>
        /// MUI_USER_PREFERRED_UI_LANGUAGES
        /// </summary>
        MUI_USER_PREFERRED_UI_LANGUAGES = 0x10,

        /// <summary>
        /// MUI_USE_INSTALLED_LANGUAGES
        /// </summary>
        MUI_USE_INSTALLED_LANGUAGES = 0x20,

        /// <summary>
        /// MUI_THREAD_LANGUAGES
        /// </summary>
        MUI_THREAD_LANGUAGES = 0x40,

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

        /// <summary>
        /// MUI_MACHINE_LANGUAGE_SETTINGS
        /// </summary>
        MUI_MACHINE_LANGUAGE_SETTINGS = 0x400,

        /// <summary>
        /// MUI_CONSOLE_FILTER
        /// </summary>
        MUI_CONSOLE_FILTER = 0x100,

        /// <summary>
        /// MUI_COMPLEX_SCRIPT_FILTER
        /// </summary>
        MUI_COMPLEX_SCRIPT_FILTER = 0x200,

        /// <summary>
        /// MUI_RESET_FILTERS
        /// </summary>
        MUI_RESET_FILTERS = 0x001,

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

        /// <summary>
        /// MUI_FULL_LANGUAGE
        /// </summary>
        MUI_FULL_LANGUAGE = 0x01,

        /// <summary>
        /// MUI_PARTIAL_LANGUAGE
        /// </summary>
        MUI_PARTIAL_LANGUAGE = 0x02,

        /// <summary>
        /// MUI_LIP_LANGUAGE
        /// </summary>
        MUI_LIP_LANGUAGE = 0x04,

        /// <summary>
        /// MUI_LANGUAGE_INSTALLED
        /// </summary>
        MUI_LANGUAGE_INSTALLED = 0x20,

        /// <summary>
        /// MUI_LANGUAGE_LICENSED
        /// </summary>
        MUI_LANGUAGE_LICENSED = 0x40,
    }
}
