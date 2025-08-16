namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// String returned types
    /// </summary>
    public enum StringReturnedTypes : uint
    {
        /// <summary>
        /// STRRET_WSTR
        /// </summary>
        STRRET_WSTR = 0,

        /// <summary>
        /// STRRET_OFFSET
        /// </summary>
        STRRET_OFFSET = 0x1,

        /// <summary>
        /// STRRET_CSTR
        /// </summary>
        STRRET_CSTR = 0x2
    }
}
