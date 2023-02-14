using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.LANGID;
using static Lsj.Util.Win32.Kernel32;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A locale identifier.
    /// For more information, see Locale Identifiers.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types"/>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/locale-information-constants"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct LCID
    {
        /// <summary>
        /// <para>
        /// Creates a locale identifier from a language identifier and a sort order identifier.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-makelcid"/>
        /// </para>
        /// </summary>
        /// <param name="lgid">
        /// Language identifier.
        /// This identifier is a combination of a primary language identifier and a sublanguage identifier
        /// and is usually created by using the <see cref="MAKELANGID"/> macro.
        /// </param>
        /// <param name="srtid">
        /// Sort order identifier.
        /// </param>
        /// <returns></returns>
        public static LCID MAKELCID(WORD lgid, WORD srtid) => (uint)((srtid) << 16) | (lgid);

        /// <summary>
        /// Windows 7 and later: Allow the return of neutral names or LCIDs when converting between locale names and locale identifiers.
        /// </summary>
        public static readonly LCID LOCALE_ALLOW_NEUTRAL_NAMES = new LCID { _value = 0x08000000 };

        /// <summary>
        /// Windows Vista and later: The default custom locale.
        /// When an NLS function must return a locale identifier for a supplemental locale for the current user,
        /// the function returns this value instead of <see cref="LOCALE_USER_DEFAULT"/>.
        /// </summary>
        public static readonly LCID LOCALE_CUSTOM_DEFAULT = new LCID { _value = 0x0c00 };

        /// <summary>
        /// Windows Vista and later: The default custom locale for MUI.
        /// The user preferred UI languages and the system preferred UI languages can include at most a single language
        /// that is implemented by a Language Interface Pack (LIP) and for which the language identifier corresponds to a supplemental locale.
        /// If there is such a language in a list, the constant is used to refer to that language in certain contexts. 
        /// </summary>
        public static readonly LCID LOCALE_CUSTOM_UI_DEFAULT = new LCID { _value = 0x1400 };

        /// <summary>
        /// Windows Vista and later: An unspecified custom locale,
        /// used to identify all supplemental locales except the locale for the current user.
        /// Supplemental locales cannot be distinguished from one another by their locale identifiers,
        /// but can be distinguished by their locale names.
        /// Certain NLS functions can return this constant to indicate that they cannot provide a useful identifier for a particular locale.
        /// </summary>
        public static readonly LCID LOCALE_CUSTOM_UNSPECIFIED = new LCID { _value = 0x1000 };

        /// <summary>
        /// Windows Me/98/95, Windows NT 4.0:
        /// A specific bit pattern that determines the relationship between the character coverage needed to support the locale and the font contents.
        /// Note that <see cref="LOCALE_FONTSIGNATURE"/> data takes a different form from all other locale information.
        /// All other locale information can be expressed in a string form or as a number.
        /// <see cref="LOCALE_FONTSIGNATURE"/> data is retrieved in a <see cref="LOCALESIGNATURE"/> structure.
        /// </summary>
        public static readonly LCID LOCALE_FONTSIGNATURE = new LCID { _value = 0x00000058 };

        /// <summary>
        /// Obsolete. Do not use.
        /// This value was provided so that partially specified locales could be completed with default values.
        /// Partially specified locales are now deprecated.
        /// </summary>
        public static readonly LCID LOCALE_IDEFAULTLANGUAGE = new LCID { _value = 0x00000009 };

        /// <summary>
        /// Language identifier with a hexadecimal value.
        /// For example, English (United States) has the value 0409, which indicates 0x0409 hexadecimal, and is equivalent to 1033 decimal.
        /// The maximum number of characters allowed for this string is five, including a terminating null character.
        /// Windows Vista and later: Use of this constant can cause GetLocaleInfo to return an invalid locale identifier.
        /// Your application should use the <see cref="LOCALE_SNAME"/> constant when calling this function.
        /// </summary>
        public static readonly LCID LOCALE_ILANGUAGE = new LCID { _value = 0x00000001 };

        /// <summary>
        /// System of measurement.
        /// The maximum number of characters allowed for this string is two, including a terminating null character.
        /// This value is 0 if the metric system (Systéme International d'Units, or S.I.) is used,
        /// and 1 if the United States system is used.
        /// </summary>
        public static readonly LCID LOCALE_IMEASURE = new LCID { _value = 0x0000000D };

        /// <summary>
        /// Windows XP: The locale used for operating system-level functions that require consistent and locale-independent results.
        /// For example, the invariant locale is used when an application compares character strings
        /// using the <see cref="CompareString"/> function and expects a consistent result regardless of the user locale.
        /// The settings of the invariant locale are similar to those for English (United States)
        /// but should not be used to display formatted data.
        /// Typically, an application does not use <see cref="LOCALE_INVARIANT"/> because it expects
        /// the results of an action to depend on the rules governing each individual locale.
        /// </summary>
        public static readonly LCID LOCALE_INVARIANT = new LCID { _value = 0x007f };

        /// <summary>
        /// An optional calendar type that is available for a locale.
        /// The calendar type can only represent an optional calendar that is available for the corresponding locale.
        /// To retrieve all optional calendars available for a locale, the application can use the following NLS functions:
        /// <see cref="EnumCalendarInfo"/>, <see cref="EnumCalendarInfoEx"/>, <see cref="EnumCalendarInfoExEx"/>
        /// </summary>
        public static readonly LCID LOCALE_IOPTIONALCALENDAR = new LCID { _value = 0x0000100B };

        /// <summary>
        ///  Caution
        ///  Since <see cref="LOCALE_NOUSEROVERRIDE"/> disables user preferences, its use is strongly discouraged.
        ///  This constant does not guarantee data stability since custom locales, service updates,
        ///  different operating system versions, and other scenarios can change data in unexpected ways
        ///  For more information, see Using Persistent Locale Data.
        ///  No user override.
        ///  In several functions, for example, <see cref="GetLocaleInfo"/> and <see cref="GetLocaleInfoEx"/>,
        ///  this constant causes the function to bypass any user override
        ///  and use the system default value for any other constant specified in the function call.
        ///  The information is retrieved from the locale database, even if the identifier indicates the current locale
        ///  and the user has changed some of the values using the Control Panel,
        ///  or if an application has changed these values by using <see cref="SetLocaleInfo"/>.
        ///  If this constant is not specified, any values that the user has configured from the Control Panel
        ///  or that an application has configured using <see cref="SetLocaleInfo"/> take precedence
        ///  over the database settings for the current system default locale.
        /// </summary>
        public static readonly LCID LOCALE_NOUSEROVERRIDE = new LCID { _value = 0x80000000 };

        /// <summary>
        /// Windows 7 and later:
        /// Retrieve the genitive names of months, which are the names used when the month names are combined with other items.
        /// For example, in Ukrainian the equivalent of January is written "Січень" when the month is named alone.
        /// However, when the month name is used in combination, for example,
        /// in a date such as January 5th, 2003, the genitive form of the name is used.
        /// For the Ukrainian example, the genitive month name is displayed as "5 січня 2003".
        /// The list of genitive month names begins with January and is semicolon-delimited.
        /// If there is no 13th month, use a semicolon in its place at the end of the list.
        /// Note
        /// Genitive month names do not exist in all languages.
        /// </summary>
        public static readonly LCID LOCALE_RETURN_GENITIVE_NAMES = new LCID { _value = 0x10000000 };

        /// <summary>
        /// Windows Me/98, Windows NT 4.0 and later:
        /// Retrieve a number.
        /// This constant causes <see cref="GetLocaleInfo"/> or <see cref="GetLocaleInfoEx"/> to retrieve a value as a number instead of as a string.
        /// The buffer that receives the value must be at least the length of a <see cref="DWORD"/> value.
        /// This constant can be combined with any other constant having a name that begins with "LOCALE_I".
        /// </summary>
        public static readonly LCID LOCALE_RETURN_NUMBER = new LCID { _value = 0x20000000 };

        /// <summary>
        /// Windows Vista and later: Preferred locale to use for console display.
        /// The maximum number of characters allowed for this string is 85, including a terminating null character.
        /// In general, applications should not make direct use of <see cref="LOCALE_SCONSOLEFALLBACKNAME"/> data.
        /// To determine what language resources to use in a console window,
        /// an application should call either <see cref="SetThreadUILanguage"/> or <see cref="SetThreadPreferredUILanguages"/>.
        /// These functions use the console fallback data as a factor in choosing a language that is legible in the console,
        /// but it is not the sole determinant.
        /// In particular, the console is limited to displaying characters from a single code page.
        /// For example, el-GR for Greek (Greece) is a valid console language,
        /// but if the current console code page is Latin-1 (code page 1252) the console displays Greek text
        /// mostly as a series of character-not-found symbols.
        /// If the language corresponding to this locale is supported in the console,
        /// the value is the same as that for <see cref="LOCALE_SNAME"/>, that is, the locale itself can be used for console display.
        /// However, the console cannot display languages that can be rendered only with Uniscribe.
        /// For example, the console cannot display Arabic or the various Indic languages.
        /// Therefore, the <see cref="LOCALE_SCONSOLEFALLBACKNAME"/> value for locales
        /// corresponding to these languages is different from the value for <see cref="LOCALE_SNAME"/>.
        /// For predefined locales, if the fallback value is different from the value for the locale itself,
        /// the value for the neutral locale is used.
        /// A specific locale is associated with both a language and a country/region,
        /// while a neutral locale is associated with a language but is not associated with any country/region.
        /// For example, ar-SA falls back to "en", not to "en-US".
        /// This policy of using neutral locales is implemented consistently 
        /// for predefined locales and is strongly recommended for custom locales.
        /// However, the policy is not enforced.
        /// For a custom locale, your application can use a specific locale instead of a neutral locale as a fallback.
        /// Note
        /// None of the functions described in Calling the "Locale Name" Functions accept neutral locales as inputs.
        /// Thus <see cref="LOCALE_SCONSOLEFALLBACKNAME"/> data is of very limited use.
        /// In particular, neither <see cref="GetLocaleInfo"/> nor <see cref="GetLocaleInfoEx"/> accepts neutral locales as inputs.
        /// </summary>
        public static readonly LCID LOCALE_SCONSOLEFALLBACKNAME = new LCID { _value = 0x0000006e };

        /// <summary>
        /// Character(s) for the date separator.
        /// The maximum number of characters allowed for this string is four, including a terminating null character.
        /// Windows Vista and later:
        /// This constant is deprecated. Use <see cref="LOCALE_SSHORTDATE"/> instead.
        /// A custom locale might not have a single, uniform separator character.
        /// For example, a format such as "12/31, 2006" is valid.
        /// </summary>
        public static readonly LCID LOCALE_SDATE = new LCID { _value = 0x0000001D };

        /// <summary>
        /// Long date formatting string for the locale.
        /// The maximum number of characters allowed for this string is 80, including a terminating null character.
        /// The string can consist of a combination of day, month, year, and era format pictures
        /// and any string of characters enclosed in single quotes.
        /// Characters in single quotes remain as specified.
        /// For example, the Spanish (Spain) long date is "dddd, dd' de 'MMMM' de 'yyyy".
        /// Locales can define multiple long date formats.
        /// To get all of the long date formats for a locale,
        /// use <see cref="EnumDateFormats"/>, <see cref="EnumDateFormatsEx"/>, or <see cref="EnumDateFormatsExEx"/>.
        /// </summary>
        public static readonly LCID LOCALE_SLONGDATE = new LCID { _value = 0x00000020 };

        /// <summary>
        /// Windows Vista and later:
        /// Locale name, a multi-part tag to uniquely identify the locale.
        /// The maximum number of characters allowed for this string is <see cref="LOCALE_NAME_MAX_LENGTH"/>,
        /// including a terminating null character.
        /// The tag is based on the language tagging conventions of IETF BCP 47.
        /// The pattern to use is described in Locale Names.
        /// </summary>
        public static readonly LCID LOCALE_SNAME = new LCID { _value = 0x0000005c };

        /// <summary>
        /// Short date formatting string for the locale.
        /// The maximum number of characters allowed for this string is 80, including a terminating null character.
        /// The string can consist of a combination of day, month, year, and era format pictures.
        /// For example, "M/d/yyyy" indicates that September 3, 2004 is written 9/3/2004.
        /// Locales can define multiple short date formats.
        /// To get all of the short date formats for this locale, use <see cref="EnumDateFormats"/>,
        /// <see cref="EnumDateFormatsEx"/>, or <see cref="EnumDateFormatsExEx"/>.
        /// </summary>
        public static readonly LCID LOCALE_SSHORTDATE = new LCID { _value = 0x0000001F };

        /// <summary>
        /// Character(s) for the time separator.
        /// The maximum number of characters allowed for this string is four, including a terminating null character.
        /// Windows Vista and later: This constant is deprecated.
        /// Use <see cref="LOCALE_STIMEFORMAT"/> instead.
        /// A custom locale might not have a single, uniform separator character.
        /// For example, a format such as "03:56'23" is valid.
        /// </summary>
        public static readonly LCID LOCALE_STIME = new LCID { _value = 0x0000001E };

        /// <summary>
        /// Time formatting strings for the locale.
        /// The maximum number of characters allowed for this string is 80, including a terminating null character.
        /// The string can consist of a combination of hour, minute, and second format pictures.
        /// </summary>
        public static readonly LCID LOCALE_STIMEFORMAT = new LCID { _value = 0x00001003 };

        /// <summary>
        /// The default locale for the operating system.
        /// </summary>
        public static readonly LCID LOCALE_SYSTEM_DEFAULT = new LCID { _value = 0x0800 };

        /// <summary>
        /// Windows Me/98, Windows 2000:
        /// System default Windows ANSI code page (ACP) instead of the locale code page used for string translation.
        /// See Code Page Identifiers for a list of ANSI and other code pages.
        /// </summary>
        public static readonly LCID LOCALE_USE_CP_ACP = new LCID { _value = 0x40000000 };

        /// <summary>
        /// The default locale for the user or process.
        /// </summary>
        public static readonly LCID LOCALE_USER_DEFAULT = new LCID { _value = 0x0400 };

        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(LCID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LCID(uint val) => new LCID { _value = val };
    }
}
