namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// GetCharacterPlacement Flags
    /// </summary>
    public enum GetCharacterPlacementFlags : uint
    {
        /// <summary>
        /// GCP_DBCS
        /// </summary>
        GCP_DBCS = 0x0001,

        /// <summary>
        /// GCP_REORDER
        /// </summary>
        GCP_REORDER = 0x0002,

        /// <summary>
        /// GCP_USEKERNING
        /// </summary>
        GCP_USEKERNING = 0x0008,

        /// <summary>
        /// GCP_GLYPHSHAPE
        /// </summary>
        GCP_GLYPHSHAPE = 0x0010,

        /// <summary>
        /// GCP_LIGATE
        /// </summary>
        GCP_LIGATE = 0x0020,

        /// <summary>
        /// GCP_DIACRITIC
        /// </summary>
        GCP_DIACRITIC = 0x0100,

        /// <summary>
        /// GCP_KASHIDA
        /// </summary>
        GCP_KASHIDA = 0x0400,

        /// <summary>
        /// GCP_ERROR
        /// </summary>
        GCP_ERROR = 0x8000,

        /// <summary>
        /// GCP_JUSTIFY
        /// </summary>
        GCP_JUSTIFY = 0x00010000,

        /// <summary>
        /// GCP_CLASSIN
        /// </summary>
        GCP_CLASSIN = 0x00080000,

        /// <summary>
        /// GCP_MAXEXTENT
        /// </summary>
        GCP_MAXEXTENT = 0x00100000,

        /// <summary>
        /// GCP_JUSTIFYIN
        /// </summary>
        GCP_JUSTIFYIN = 0x00200000,

        /// <summary>
        /// GCP_DISPLAYZWG
        /// </summary>
        GCP_DISPLAYZWG = 0x00400000,

        /// <summary>
        /// GCP_SYMSWAPOFF
        /// </summary>
        GCP_SYMSWAPOFF = 0x00800000,

        /// <summary>
        /// GCP_NUMERICOVERRIDE
        /// </summary>
        GCP_NUMERICOVERRIDE = 0x01000000,

        /// <summary>
        /// GCP_NEUTRALOVERRIDE
        /// </summary>
        GCP_NEUTRALOVERRIDE = 0x02000000,

        /// <summary>
        /// GCP_NUMERICSLATIN
        /// </summary>
        GCP_NUMERICSLATIN = 0x04000000,

        /// <summary>
        /// GCP_NUMERICSLOCAL
        /// </summary>
        GCP_NUMERICSLOCAL = 0x08000000,

        /// <summary>
        /// GCP_NODIACRITICS
        /// </summary>
        GCP_NODIACRITICS = 0x00020000,
    }
}
