using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// String Flags
    /// </summary>
    [Flags]
    public enum StringFlags : uint
    {
        /// <summary>
        /// NORM_IGNORECASE
        /// </summary>
        NORM_IGNORECASE = 0x00000001,

        /// <summary>
        /// NORM_IGNORENONSPACE
        /// </summary>
        NORM_IGNORENONSPACE = 0x00000002,

        /// <summary>
        /// NORM_IGNORESYMBOLS
        /// </summary>
        NORM_IGNORESYMBOLS = 0x00000004,

        /// <summary>
        /// LINGUISTIC_IGNORECASE
        /// </summary>
        LINGUISTIC_IGNORECASE = 0x00000010,

        /// <summary>
        /// LINGUISTIC_IGNOREDIACRITIC
        /// </summary>
        LINGUISTIC_IGNOREDIACRITIC = 0x00000020,

        /// <summary>
        /// NORM_IGNOREKANATYPE
        /// </summary>
        NORM_IGNOREKANATYPE = 0x00010000,

        /// <summary>
        /// NORM_IGNOREWIDTH
        /// </summary>
        NORM_IGNOREWIDTH = 0x00020000,

        /// <summary>
        /// NORM_LINGUISTIC_CASING
        /// </summary>
        NORM_LINGUISTIC_CASING = 0x08000000,

        /// <summary>
        /// SORT_STRINGSORT
        /// </summary>
        SORT_STRINGSORT = 0x00001000,

        /// <summary>
        /// SORT_DIGITSASNUMBERS
        /// </summary>
        SORT_DIGITSASNUMBERS = 0x00000008,
    }
}
