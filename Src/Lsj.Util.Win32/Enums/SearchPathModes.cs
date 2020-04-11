namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Search Path Modes
    /// </summary>
    public enum SearchPathModes : uint
    {
        /// <summary>
        /// BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE
        /// </summary>
        BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE = 0x1,

        /// <summary>
        /// BASE_SEARCH_PATH_DISABLE_SAFE_SEARCHMODE
        /// </summary>
        BASE_SEARCH_PATH_DISABLE_SAFE_SEARCHMODE = 0x10000,

        /// <summary>
        /// BASE_SEARCH_PATH_PERMANENT
        /// </summary>
        BASE_SEARCH_PATH_PERMANENT = 0x8000,

        /// <summary>
        /// BASE_SEARCH_PATH_INVALID_FLAGS
        /// </summary>
        BASE_SEARCH_PATH_INVALID_FLAGS = unchecked((uint)~0x18001),
    }
}
