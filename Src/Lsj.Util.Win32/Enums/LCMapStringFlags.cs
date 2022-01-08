namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// LCMapString Flags
    /// </summary>
    public enum LCMapStringFlags : uint
    {
        /// <summary>
        /// LCMAP_LOWERCASE
        /// </summary>
        LCMAP_LOWERCASE = 0x00000100,

        /// <summary>
        /// LCMAP_UPPERCASE
        /// </summary>
        LCMAP_UPPERCASE = 0x00000200,

        /// <summary>
        /// LCMAP_TITLECASE
        /// </summary>
        LCMAP_TITLECASE = 0x00000300,

        /// <summary>
        /// LCMAP_SORTKEY
        /// </summary>
        LCMAP_SORTKEY = 0x00000400,

        /// <summary>
        /// LCMAP_BYTEREV
        /// </summary>
        LCMAP_BYTEREV = 0x00000800,

        /// <summary>
        /// LCMAP_HIRAGANA
        /// </summary>
        LCMAP_HIRAGANA = 0x00100000,

        /// <summary>
        /// LCMAP_KATAKANA
        /// </summary>
        LCMAP_KATAKANA = 0x00200000,

        /// <summary>
        /// LCMAP_HALFWIDTH
        /// </summary>
        LCMAP_HALFWIDTH = 0x00400000,

        /// <summary>
        /// LCMAP_FULLWIDTH
        /// </summary>
        LCMAP_FULLWIDTH = 0x00800000,

        /// <summary>
        /// LCMAP_LINGUISTIC_CASING
        /// </summary>
        LCMAP_LINGUISTIC_CASING = 0x01000000,

        /// <summary>
        /// LCMAP_SIMPLIFIED_CHINESE
        /// </summary>
        LCMAP_SIMPLIFIED_CHINESE = 0x02000000,

        /// <summary>
        /// LCMAP_TRADITIONAL_CHINESE
        /// </summary>
        LCMAP_TRADITIONAL_CHINESE = 0x04000000,

        /// <summary>
        /// LCMAP_SORTHANDLE
        /// </summary>
        LCMAP_SORTHANDLE = 0x20000000,

        /// <summary>
        /// LCMAP_HASH
        /// </summary>
        LCMAP_HASH = 0x00040000,
    }
}
