namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Locale Independent Mapping Flags
    /// </summary>
    public enum LocaleIndependentMappingFlags : uint
    {
        /// <summary>
        /// MAP_FOLDCZONE
        /// </summary>
        MAP_FOLDCZONE = 0x00000010,

        /// <summary>
        /// MAP_PRECOMPOSED
        /// </summary>
        MAP_PRECOMPOSED = 0x00000020,

        /// <summary>
        /// MAP_COMPOSITE
        /// </summary>
        MAP_COMPOSITE = 0x00000040,

        /// <summary>
        /// MAP_FOLDDIGITS
        /// </summary>
        MAP_FOLDDIGITS = 0x00000080,

        /// <summary>
        /// MAP_EXPAND_LIGATURES
        /// </summary>
        MAP_EXPAND_LIGATURES = 0x00002000,
    }
}
