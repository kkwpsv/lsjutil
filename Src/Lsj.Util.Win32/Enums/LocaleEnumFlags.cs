using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// LocaleEnumFlags
    /// </summary>
    [Flags]
    public enum LocaleEnumFlags : uint
    {
        /// <summary>
        /// LOCALE_ALL
        /// </summary>
        LOCALE_ALL = 0,

        /// <summary>
        /// LOCALE_WINDOWS
        /// </summary>
        LOCALE_WINDOWS = 0x00000001,

        /// <summary>
        /// LOCALE_SUPPLEMENTAL
        /// </summary>
        LOCALE_SUPPLEMENTAL = 0x00000002,

        /// <summary>
        /// LOCALE_ALTERNATE_SORTS
        /// </summary>
        LOCALE_ALTERNATE_SORTS = 0x00000004,

        /// <summary>
        /// LOCALE_REPLACEMENT
        /// </summary>
        LOCALE_REPLACEMENT = 0x00000008,

        /// <summary>
        /// LOCALE_NEUTRALDATA
        /// </summary>
        LOCALE_NEUTRALDATA = 0x00000010,

        /// <summary>
        /// LOCALE_SPECIFICDATA
        /// </summary>
        LOCALE_SPECIFICDATA = 0x00000020,
    }
}
