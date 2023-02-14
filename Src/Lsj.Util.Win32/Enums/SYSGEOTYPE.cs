using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines the type of geographical location information requested in the <see cref="GetGeoInfo"/> or <see cref="GetGeoInfoEx"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/ne-winnls-sysgeotype"/>
    /// </para>
    /// </summary>
    public enum SYSGEOTYPE
    {
        /// <summary>
        /// The geographical location identifier (GEOID) of a nation.
        /// This value is stored in a long integer.
        /// Starting with Windows 10, version 1709: This value is not supported for the <see cref="GetGeoInfoEx"/> function, and should not be used.
        /// </summary>
        GEO_NATION = 0x0001,

        /// <summary>
        /// The latitude of the location.
        /// This value is stored in a floating-point number.
        /// </summary>
        GEO_LATITUDE = 0x0002,

        /// <summary>
        /// The longitude of the location.
        /// This value is stored in a floating-point number.
        /// </summary>
        GEO_LONGITUDE = 0x0003,

        /// <summary>
        /// The ISO 2-letter country/region code.
        /// This value is stored in a string.
        /// </summary>
        GEO_ISO2 = 0x0004,

        /// <summary>
        /// The ISO 3-letter country/region code.
        /// This value is stored in a string.
        /// </summary>
        GEO_ISO3 = 0x0005,

        /// <summary>
        /// The name for a string, compliant with RFC 4646 (starting with Windows Vista),
        /// that is derived from the <see cref="GetGeoInfo"/> parameters language and GeoId.
        /// Starting with Windows 10, version 1709: This value is not supported for the <see cref="GetGeoInfoEx"/> function, and should not be used.
        /// </summary>
        GEO_RFC1766 = 0x0006,

        /// <summary>
        /// A locale identifier derived using <see cref="GetGeoInfo"/>.
        /// Starting with Windows 10, version 1709: This value is not supported for the <see cref="GetGeoInfoEx"/> function, and should not be used.
        /// </summary>
        GEO_LCID = 0x0007,

        /// <summary>
        /// The friendly name of the nation, for example, Germany.
        /// This value is stored in a string.
        /// </summary>
        GEO_FRIENDLYNAME = 0x0008,

        /// <summary>
        /// The official name of the nation, for example, Federal Republic of Germany.
        /// This value is stored in a string.
        /// </summary>
        GEO_OFFICIALNAME = 0x0009,

        /// <summary>
        /// Not implemented.
        /// </summary>
        GEO_TIMEZONES = 0x000A,

        /// <summary>
        /// Not implemented.
        /// </summary>
        GEO_OFFICIALLANGUAGES = 0x000B,

        /// <summary>
        /// Starting with Windows 8:
        /// The ISO 3-digit country/region code.
        /// This value is stored in a string.
        /// </summary>
        GEO_ISO_UN_NUMBER = 0x000C,

        /// <summary>
        /// Starting with Windows 8:
        /// The geographical location identifier of the parent region of a country/region.
        /// This value is stored in a string.
        /// </summary>
        GEO_PARENT = 0x000D,

        /// <summary>
        /// Starting with Windows 10, version 1709:
        /// The dialing code to use with telephone numbers in the geographic location.
        /// For example, 1 for the United States.
        /// </summary>
        GEO_DIALINGCODE = 0x000E,

        /// <summary>
        /// Starting with Windows 10, version 1709:
        /// The three-letter code for the currency that the geographic location uses.
        /// For example, USD for United States dollars.
        /// </summary>
        GEO_CURRENCYCODE = 0x000F,

        /// <summary>
        /// Starting with Windows 10, version 1709:
        /// The symbol for the currency that the geographic location uses.
        /// For example, the dollar sign ($).
        /// </summary>
        GEO_CURRENCYSYMBOL = 0x0010,

        /// <summary>
        /// Starting with Windows 10, version 1709:
        /// The two-letter International Organization for Standardization (ISO) 3166-1 code or numeric United Nations (UN) Series M,
        /// Number 49 (M.49) code for the geographic region.
        /// For information about two-letter ISO 3166-1 codes, see Country Codes - ISO 3166.
        /// For information about numeric UN M.49 codes, see Standard country or area codes for statistical use (M49).
        /// </summary>
        GEO_NAME = 0x0011,

        /// <summary>
        /// Starting with Windows 10, version 1709:
        /// The Windows geographical location identifiers (GEOID) for the region. This value is provided for backward compatibility.
        /// Do not use this value in new applications, but use <see cref="GEO_NAME"/> instead.
        /// </summary>
        GEO_ID = 0x0012,
    }
}
