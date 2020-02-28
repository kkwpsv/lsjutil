namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="CharacterSets"/> Enumeration defines the possible sets of character glyphs that are defined in fonts for graphics output.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-wmf/0d0b32ac-a836-4bd2-a112-b6000a1b4fc9
    /// </para>
    /// </summary>
    public enum CharacterSets : byte
    {
        /// <summary>
        /// Specifies the English character set.
        /// </summary>
        ANSI_CHARSET = 0x00000000,

        /// <summary>
        /// Specifies a character set based on the current system locale;
        /// for example, when the system locale is United States English,
        /// the default character set is <see cref="ANSI_CHARSET"/>.
        /// </summary>
        DEFAULT_CHARSET = 0x00000001,

        /// <summary>
        /// Specifies a character set of symbols.
        /// </summary>
        SYMBOL_CHARSET = 0x00000002,

        /// <summary>
        /// Specifies the Apple Macintosh character set.
        /// </summary>
        MAC_CHARSET = 0x0000004D,

        /// <summary>
        ///  Specifies the Japanese character set.
        /// </summary>
        SHIFTJIS_CHARSET = 0x00000080,

        /// <summary>
        /// Also spelled "Hangeul". Specifies the Hangul Korean character set.
        /// </summary>
        HANGUL_CHARSET = 0x00000081,

        /// <summary>
        /// Also spelled "Johap". Specifies the Johab Korean character set.
        /// </summary>
        JOHAB_CHARSET = 0x00000082,

        /// <summary>
        /// Specifies the "simplified" Chinese character set for People's Republic of China.
        /// </summary>
        GB2312_CHARSET = 0x00000086,

        /// <summary>
        /// Specifies the "traditional" Chinese character set, used mostly in Taiwan and in the Hong Kong and Macao Special Administrative Regions.
        /// </summary>
        CHINESEBIG5_CHARSET = 0x00000088,

        /// <summary>
        /// Specifies the Greek character set.
        /// </summary>
        GREEK_CHARSET = 0x000000A1,

        /// <summary>
        /// Specifies the Turkish character set.
        /// </summary>
        TURKISH_CHARSET = 0x000000A2,

        /// <summary>
        /// Specifies the Vietnamese character set.
        /// </summary>
        VIETNAMESE_CHARSET = 0x000000A3,

        /// <summary>
        /// Specifies the Hebrew character set
        /// </summary>
        HEBREW_CHARSET = 0x000000B1,

        /// <summary>
        /// Specifies the Arabic character set
        /// </summary>
        ARABIC_CHARSET = 0x000000B2,

        /// <summary>
        /// Specifies the Baltic (Northeastern European) character set
        /// </summary>
        BALTIC_CHARSET = 0x000000BA,

        /// <summary>
        /// Specifies the Russian Cyrillic character set.
        /// </summary>
        RUSSIAN_CHARSET = 0x000000CC,

        /// <summary>
        /// Specifies the Thai character set.
        /// </summary>
        THAI_CHARSET = 0x000000DE,

        /// <summary>
        /// Specifies a Eastern European character set.
        /// </summary>
        EASTEUROPE_CHARSET = 0x000000EE,

        /// <summary>
        /// Specifies a mapping to one of the OEM code pages, according to the current system locale setting.
        /// </summary>
        OEM_CHARSET = 0x000000FF
    }
}
