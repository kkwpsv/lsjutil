using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.LCID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CharacterTypeFlags;
using static Lsj.Util.Win32.Enums.CodePages;
using static Lsj.Util.Win32.Enums.CompareStringResults;
using static Lsj.Util.Win32.Enums.CType1Flags;
using static Lsj.Util.Win32.Enums.CType2Flags;
using static Lsj.Util.Win32.Enums.CType3Flags;
using static Lsj.Util.Win32.Enums.MBCSTranslationFlags;
using static Lsj.Util.Win32.Enums.NORM_FORM;
using static Lsj.Util.Win32.Enums.StringFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Name of an invariant locale that provides stable locale and calendar data.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/intl/locale-name-constants"/>
        /// </para>
        /// </summary>
        public static readonly StringHandle LOCALE_NAME_INVARIANT = "";

        /// <summary>
        /// <para>
        /// Maximum length of a locale name. The maximum number of characters allowed for this string is 85, including a terminating null character.
        /// Your application must use the constant for the maximum locale name length, instead of hard-coding the value "85". 
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/intl/locale-name-constants"/>
        /// </para>
        /// </summary>
        public const int LOCALE_NAME_MAX_LENGTH = 85;

        /// <summary>
        /// <para>
        /// Name of the current operating system locale.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/intl/locale-name-constants"/>
        /// </para>
        /// </summary>
        public static readonly StringHandle LOCALE_NAME_SYSTEM_DEFAULT = "!x-sys-default-locale";

        /// <summary>
        /// <para>
        /// Name of the current user locale, matching the preference set in the regional and language options portion of Control Panel.
        /// This locale can be different from the locale for the current user interface language.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/intl/locale-name-constants"/>
        /// </para>
        /// </summary>
        public static readonly StringHandle LOCALE_NAME_USER_DEFAULT = NULL;


        /// <summary>
        /// <para>
        /// Compares two character strings, for a locale specified by identifier.
        /// Caution
        /// Using <see cref="CompareString"/> incorrectly can compromise the security of your application.
        /// Strings that are not compared correctly can produce invalid input.
        /// For example, the function can raise security issues when used for a non-linguistic comparison,
        /// because two strings that are distinct in their binary representation can be linguistically equivalent.
        /// The application should test strings for validity before using them, and should provide error handlers.
        /// For more information, see Security Considerations: International Features.
        /// Note
        /// For compatibility with Unicode, your applications should prefer <see cref="CompareStringEx"/> or the Unicode version of <see cref="CompareString"/>.
        /// Another reason for preferring <see cref="CompareStringEx"/> is that Microsoft is migrating toward the use of locale names
        /// instead of locale identifiers for new locales, for interoperability reasons.
        /// Any application that will be run only on Windows Vista and later should use <see cref="CompareStringEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-comparestringw"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier of the locale used for the comparison.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>
        /// <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// <see cref="LOCALE_INVARIANT"/>
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/>
        /// <see cref="LOCALE_USER_DEFAULT"/>
        /// </param>
        /// <param name="dwCmpFlags">
        /// Flags that indicate how the function compares the two strings.
        /// For detailed definitions, see the dwCmpFlags parameter of <see cref="CompareStringEx"/>.
        /// </param>
        /// <param name="lpString1">
        /// Pointer to the first string to compare.
        /// </param>
        /// <param name="cchCount1">
        /// Length of the string indicated by <paramref name="lpString1"/>, excluding the terminating null character.
        /// This value represents bytes for the ANSI version of the function and wide characters for the Unicode version.
        /// The application can supply a negative value if the string is null-terminated.
        /// In this case, the function determines the length automatically.
        /// </param>
        /// <param name="lpString2">
        /// Pointer to the second string to compare.
        /// </param>
        /// <param name="cchCount2">
        /// Length of the string indicated by <paramref name="lpString2"/>, excluding the terminating null character.
        /// This value represents bytes for the ANSI version of the function and wide characters for the Unicode version.
        /// The application can supply a negative value if the string is null-terminated.
        /// In this case, the function determines the length automatically.
        /// </param>
        /// <returns>
        /// Returns the values described for <see cref="CompareStringEx"/>.
        /// </returns>
        /// <remarks>
        /// See Remarks for <see cref="CompareStringEx"/>.
        /// If your application is calling the ANSI version of <see cref="CompareString"/>,
        /// the function converts parameters via the default code page of the supplied locale.
        /// Thus, an application can never use <see cref="CompareString"/> to handle UTF-8 text.
        /// Normally, for case-insensitive comparisons, <see cref="CompareString"/> maps the lowercase "i" to the uppercase "I",
        /// even when the locale is Turkish or Azerbaijani.
        /// The <see cref="NORM_LINGUISTIC_CASING"/> flag overrides this behavior for Turkish or Azerbaijani.
        /// If this flag is specified in conjunction with Turkish or Azerbaijani, LATIN SMALL LETTER DOTLESS I (U+0131) is the lowercase form of 
        /// LATIN CAPITAL LETTER I (U+0049) and LATIN SMALL LETTER I (U+0069) is the lowercase form of LATIN CAPITAL LETTER I WITH DOT ABOVE (U+0130).
        /// Starting with Windows 8:
        /// The ANSI version of the function is declared in Winnls.h, and the Unicode version is declared in Stringapiset.h.
        /// Before Windows 8, both versions were declared in Winnls.h.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CompareStringW", ExactSpelling = true, SetLastError = true)]
        public static extern CompareStringResults CompareString([In] LCID Locale, [In] StringFlags dwCmpFlags, [In] LPCWSTR lpString1,
            [In] int cchCount1, [In] LPCWSTR lpString2, [In] int cchCount2);

        /// <summary>
        /// <para>
        /// Compares two Unicode strings to test binary equivalence.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-comparestringordinal"/>
        /// </para>
        /// </summary>
        /// <param name="lpString1">
        /// Pointer to the first string to compare.
        /// </param>
        /// <param name="cchCount1">
        /// Length of the string indicated by <paramref name="lpString1"/>.
        /// The application supplies -1 if the string is null-terminated.
        /// In this case, the function determines the length automatically.
        /// </param>
        /// <param name="lpString2">
        /// Pointer to the second string to compare.
        /// </param>
        /// <param name="cchCount2">
        /// Length of the string indicated by <paramref name="lpString2"/>.
        /// The application supplies -1 if the string is null-terminated.
        /// In this case, the function determines the length automatically.
        /// </param>
        /// <param name="bIgnoreCase">
        /// <see cref="TRUE"/> if the function is to perform a case-insensitive comparison, using the operating system uppercase table information.
        /// The application sets this parameter to <see cref="FALSE"/> if the function is to compare the strings exactly as they are passed in.
        /// Note that 1 is the only numeric value that can be used to specify a true value for this boolean parameter
        /// that does not result an invalid parameter error.
        /// Boolean values for this parameter work as expected.
        /// </param>
        /// <returns>
        /// Returns one of the following values if successful.
        /// To maintain the C runtime convention of comparing strings, the value 2 can be subtracted from a nonzero return value.
        /// Then, the meaning of &lt;0, ==0, and &gt;0 is consistent with the C runtime.
        /// <see cref="CSTR_LESS_THAN"/>.
        /// The value indicated by <paramref name="lpString1"/> is less than the value indicated by <paramref name="lpString2"/>.
        /// <see cref="CSTR_EQUAL"/>.
        /// The value indicated by <paramref name="lpString1"/> equals the value indicated by <paramref name="lpString2"/>.
        /// <see cref="CSTR_GREATER_THAN"/>.
        /// The value indicated by <paramref name="lpString1"/> is greater than the value indicated by <paramref name="lpString2"/>.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid. 
        /// </returns>
        /// <remarks>
        /// This function tests for binary equality, not linguistic equality.
        /// For information about the use of the function for ordinal sorting, see Handling Sorting in Your Applications.
        /// Applications that are concerned with linguistic equality should use <see cref="CompareString"/>,
        /// <see cref="CompareStringEx"/>, <see cref="lstrcmp"/>, or <see cref="lstrcmpi"/>.
        /// For more information about linguistic sorting, see Handling Sorting in Your Applications
        /// Starting with Windows 8: <see cref="CompareStringOrdinal"/> is declared in Stringapiset.h.
        /// Before Windows 8, it was declared in Winnls.h.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CompareStringOrdinal", ExactSpelling = true, SetLastError = true)]
        public static extern int CompareStringOrdinal([In] LPCWSTR lpString1, [In] int cchCount1, [In] LPCWSTR lpString2,
            [In] int cchCount2, [In] BOOL bIgnoreCase);

        /// <summary>
        /// <para>
        /// Compares two Unicode (wide character) strings, for a locale specified by name.
        /// Caution
        /// Using <see cref="CompareStringEx"/> incorrectly can compromise the security of your application.
        /// Strings that are not compared correctly can produce invalid input.
        /// Test strings to make sure they are valid before using them, and provide error handlers.
        /// For more information, see Security Considerations: International Features.
        /// Note
        /// The application should call this function in preference to <see cref="CompareString"/> if designed to run only on Windows Vista and later.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-comparestringex"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleName">
        /// Pointer to a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>
        /// <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>
        /// <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="dwCmpFlags">
        /// Flags that indicate how the function compares the two strings.
        /// By default, these flags are not set.
        /// This parameter can specify a combination of any of the following values, or it can be set to 0 to obtain the default behavior.
        /// <see cref="LINGUISTIC_IGNORECASE"/>: Ignore case, as linguistically appropriate.
        /// <see cref="LINGUISTIC_IGNOREDIACRITIC"/>:
        /// Ignore nonspacing characters, as linguistically appropriate.
        /// Note
        /// This flag does not always produce predictable results when used with decomposed characters, that is,
        /// characters in which a base character and one or more nonspacing characters each have distinct code point values.
        /// <see cref="NORM_IGNORECASE"/>:
        /// Ignore case. For many scripts (notably Latin scripts), <see cref="NORM_IGNORECASE"/> coincides with <see cref="LINGUISTIC_IGNORECASE"/>.
        /// Note
        /// <see cref="NORM_IGNORECASE"/> ignores any tertiary distinction, whether it is actually linguistic case or not.
        /// For example, in Arabic and Indic scripts, this distinguishes alternate forms of a character,
        /// but the differences do not correspond to linguistic case.
        /// <see cref="LINGUISTIC_IGNORECASE"/> causes the function to ignore only actual linguistic casing, instead of ignoring the third sorting weight.
        /// Note
        /// With this flag set, the function ignores the distinction between the wide and narrow forms of the CJK compatibility characters.
        /// <see cref="NORM_IGNOREKANATYPE"/>:
        /// Do not differentiate between hiragana and katakana characters. Corresponding hiragana and katakana characters compare as equal. 
        /// <see cref="NORM_IGNORENONSPACE"/>:
        /// Ignore nonspacing characters.
        /// For many scripts (notably Latin scripts), <see cref="NORM_IGNORENONSPACE"/> coincides with <see cref="LINGUISTIC_IGNOREDIACRITIC"/>.
        /// Note
        /// <see cref="NORM_IGNORENONSPACE"/> ignores any secondary distinction, whether it is a diacritic or not.
        /// Scripts for Korean, Japanese, Chinese, and Indic languages, among others, use this distinction for purposes other than diacritics.
        /// <see cref="LINGUISTIC_IGNOREDIACRITIC"/> causes the function to ignore only actual diacritics, instead of ignoring the second sorting weight.
        /// Note
        /// <see cref="NORM_IGNORENONSPACE"/> only has an effect for locales in which
        /// accented characters are sorted in a second pass from main characters.
        /// Normally all characters in the string are first compared without regard to accents and, if the strings are equal,
        /// a second pass over the strings is performed to compare accents.
        /// This flag causes the second pass to not be performed.
        /// For locales that sort accented characters in the first pass, this flag has no effect.
        /// <see cref="NORM_IGNORESYMBOLS"/>:
        /// Ignore symbols and punctuation. 
        /// <see cref="NORM_IGNOREWIDTH"/>:
        /// Ignore the difference between half-width and full-width characters, for example, C a t == cat.
        /// The full-width form is a formatting distinction used in Chinese and Japanese scripts. 
        /// <see cref="NORM_LINGUISTIC_CASING"/>:
        /// Use the default linguistic rules for casing, instead of file system rules.
        /// Note that most scenarios for <see cref="CompareStringEx"/> use this flag.
        /// This flag does not have to be used when your application calls <see cref="CompareStringOrdinal"/>.
        /// <see cref="SORT_DIGITSASNUMBERS"/>:
        /// Windows 7: Treat digits as numbers during sorting, for example, sort "2" before "10". 
        /// <see cref="SORT_STRINGSORT"/>:
        /// Treat punctuation the same as symbols. 
        /// </param>
        /// <param name="lpString1">
        /// Pointer to the first string to compare.
        /// </param>
        /// <param name="cchCount1">
        /// Length of the string indicated by <paramref name="lpString1"/>, excluding the terminating null character.
        /// The application can supply a negative value if the string is null-terminated.
        /// In this case, the function determines the length automatically.
        /// </param>
        /// <param name="lpString2">
        /// Pointer to the second string to compare.
        /// </param>
        /// <param name="cchCount2">
        /// Length of the string indicated by lpString2, excluding the terminating null character.
        /// The application can supply a negative value if the string is null-terminated.
        /// In this case, the function determines the length automatically.
        /// </param>
        /// <param name="lpVersionInformation">
        /// Pointer to an <see cref="NLSVERSIONINFOEX"/> structure that contains the version information about the relevant NLS capability;
        /// usually retrieved from <see cref="GetNLSVersionEx"/>.
        /// Windows Vista, Windows 7: Reserved; must set to <see cref="NullRef{NLSVERSIONINFOEX}"/>.
        /// </param>
        /// <param name="lpReserved">
        /// Reserved; must set to <see cref="NULL"/>.
        /// </param>
        /// <param name="lParam">
        /// Reserved; must be set to 0.
        /// </param>
        /// <returns>
        /// Returns one of the following values if successful.
        /// To maintain the C runtime convention of comparing strings, the value 2 can be subtracted from a nonzero return value.
        /// Then, the meaning of &lt;0, ==0, and &gt;0 is consistent with the C runtime.
        /// <see cref="CSTR_LESS_THAN"/>.
        /// The string indicated by <paramref name="lpString1"/> is less in lexical value than the string indicated by <paramref name="lpString2"/>.
        /// <see cref="CSTR_EQUAL"/>.
        /// The string indicated by <paramref name="lpString1"/> is equivalent in lexical value to the string indicated by <paramref name="lpString2"/>.
        /// The two strings are equivalent for sorting purposes, although not necessarily identical.
        /// <see cref="CSTR_GREATER_THAN"/>.
        /// The string indicated by <paramref name="lpString1"/> is greater in lexical value than the string indicated by <paramref name="lpString2"/>.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were invalid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// Both <see cref="CompareString"/> and <see cref="CompareStringEx"/> are optimized to run at the highest speed
        /// when <paramref name="dwCmpFlags"/> is set to 0 or <see cref="NORM_IGNORECASE"/>,
        /// <paramref name="cchCount1"/> and <paramref name="cchCount2"/> are set to -1,
        /// and the locale does not support any linguistic compressions, as when traditional Spanish sorting treats "ch" as a single character.
        /// Both <see cref="CompareString"/> and <see cref="CompareStringEx"/> ignore Arabic kashidas during the comparison.
        /// Thus, if two strings are identical except for the presence of kashidas, the function returns <see cref="CSTR_EQUAL"/>.
        /// When the application uses the <see cref="NORM_IGNORENONSPACE"/> and <see cref="NORM_IGNORECASE"/> flags with the sorting function,
        /// the flags can sometimes interfere with string comparisons.
        /// This situation might result for a locale that does not support non-spacing characters or case,
        /// but uses equivalent weight levels to handle other important operations.
        /// In such cases, your application should use the <see cref="LINGUISTIC_IGNOREDIACRITIC"/> and <see cref="LINGUISTIC_IGNORECASE"/> flags.
        /// These flags provide linguistically appropriate results for sorting code points
        /// that use case and diacritic marks, and have no impact on other code points.
        /// Beginning in Windows Vista:
        /// Both <see cref="CompareString"/> and <see cref="CompareStringEx"/> can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace, 
        /// it must first convert the tags by calling ResolveLocaleName.
        /// Beginning in Windows 8:
        /// <see cref="CompareStringEx"/> is declared in Stringapiset.h. Before Windows 8, it was declared in Winnls.h.
        /// Note
        /// The behavior of sorting can change between Windows releases. For example, there may be new Unicode code points created.
        /// Use <see cref="GetNLSVersionEx"/> to discover if the sort version has changed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CompareStringEx", ExactSpelling = true, SetLastError = true)]
        public static extern CompareStringResults CompareStringEx([In] StringHandle lpLocaleName, [In] StringFlags dwCmpFlags,
            [In] LPCWSTR lpString1, [In] int cchCount1, [In] LPCWSTR lpString2, [In] int cchCount2, [In] in NLSVERSIONINFOEX lpVersionInformation,
            [In] LPVOID lpReserved, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Locates a Unicode string (wide characters) in another Unicode string for a non-linguistic comparison.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-findstringordinal"/>
        /// </para>
        /// </summary>
        /// <param name="dwFindStringOrdinalFlags">
        /// Flags specifying details of the find operation.
        /// These flags are mutually exclusive, with <see cref="FIND_FROMSTART"/> being the default.
        /// The application can specify just one of the find flags.
        /// <see cref="FIND_FROMSTART"/>, <see cref="FIND_FROMEND"/>, <see cref="FIND_STARTSWITH"/>, <see cref="FIND_ENDSWITH"/>
        /// </param>
        /// <param name="lpStringSource">
        /// Pointer to the source string, in which the function searches for the string specified by <paramref name="lpStringValue"/>.
        /// </param>
        /// <param name="cchSource">
        /// Size, in characters excluding the terminating null character, of the string indicated by <paramref name="lpStringSource"/>.
        /// The application must normally specify a positive number, or 0.
        /// The application can specify -1 if the source string is null-terminated and the function should calculate the size automatically.
        /// </param>
        /// <param name="lpStringValue">
        /// Pointer to the search string for which the function searches in the source string.
        /// </param>
        /// <param name="cchValue">
        /// Size, in characters excluding the terminating null character, of the string indicated by <paramref name="lpStringSource"/>.
        /// The application must normally specify a positive number, or 0.
        /// The application can specify -1 if the string is null-terminated and the function should calculate the size automatically.
        /// </param>
        /// <param name="bIgnoreCase">
        /// <see cref="TRUE"/> if the function is to perform a case-insensitive comparison, and <see cref="FALSE"/> otherwise.
        /// The comparison is not a linguistic operation and is not appropriate for all locales and languages.
        /// Its behavior is similar to that for English.
        /// </param>
        /// <returns>
        /// Returns a 0-based index into the source string indicated by <paramref name="lpStringSource"/> if successful.
        /// If the function succeeds, the found string is the same size as the value of <paramref name="lpStringValue"/>.
        /// A return value of 0 indicates that the function found a match at the beginning of the source string.
        /// The function returns -1 if it does not succeed or if it does not find the search string.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_FLAGS"/>: The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: Any of the parameter values was invalid.
        /// <see cref="ERROR_SUCCESS"/>: The action completed successfully but yielded no results.
        /// </returns>
        /// <remarks>
        /// Since <see cref="FindStringOrdinal"/> provides a binary comparison, it does not return linguistically appropriate results.
        /// The ordinal comparison might be mistaken for English sorting behavior.
        /// However, it does not find matches when characters vary by linguistically insignificant amounts.
        /// See Sorting for information about choosing an appropriate sorting function.
        /// In contrast to NLS functions that return 0 for failure, this function returns -1 if it fails.
        /// On success, it returns a 0-based index. Use of this index helps the function avoid off-by-one errors and one-character buffer overruns.
        /// This function is one of the few NLS functions that calls <see cref="SetLastError"/> even when it succeeds.
        /// It makes this call to clear the last error in a thread when it fails to match the search string.
        /// This clears the value returned by <see cref="GetLastError"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindStringOrdinal", ExactSpelling = true, SetLastError = true)]
        public static extern int FindStringOrdinal([In] FindStringFlags dwFindStringOrdinalFlags, [In] LPCWSTR lpStringSource, [In] int cchSource,
            [In] LPCWSTR lpStringValue, [In] int cchValue, [In] BOOL bIgnoreCase);

        /// <summary>
        /// <para>
        /// Maps one Unicode string to another, performing the specified transformation.
        /// For an overview of the use of the string functions, see Strings.
        /// Caution
        /// Using <see cref="FoldString"/> incorrectly can compromise the security of your application.
        /// Strings that are not mapped correctly can produce invalid input.
        /// Test strings to make sure they are valid before using them and provide error handlers.
        /// For more information, see Security Considerations: International Features.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-foldstringw"/>
        /// </para>
        /// </summary>
        /// <param name="dwMapFlags">
        /// Flags specifying the type of transformation to use during string mapping.
        /// This parameter can be a combination of the following values.
        /// <see cref="MAP_COMPOSITE"/>:
        /// Map accented characters to decomposed characters, that is,
        /// characters in which a base character and one or more nonspacing characters each have distinct code point values.
        /// For example, Ä is represented by A + ¨: LATIN CAPITAL LETTER A (U+0041) + COMBINING DIAERESIS (U+0308).
        /// This flag is equivalent to normalization form D in Windows Vista.
        /// Note that this flag cannot be used with <see cref="MB_PRECOMPOSED"/>.
        /// <see cref="MAP_EXPAND_LIGATURES"/>:
        /// Expand all ligature characters so that they are represented by their two-character equivalent.
        /// For example, the ligature "æ" (U+00e6) expands to the two characters "a" (U+0061) + "e" (U+0065).
        /// This value cannot be combined with <see cref="MAP_PRECOMPOSED"/> or <see cref="MAP_COMPOSITE"/>.
        /// <see cref="MAP_FOLDCZONE"/>:
        /// Fold compatibility zone characters into standard Unicode equivalents.
        /// This flag is equivalent to normalization form KD in Windows Vista, if the <see cref="MAP_COMPOSITE"/> flag is also set.
        /// If the composite flag is not set (default), this flag is equivalent to normalization form KC in Windows Vista.
        /// <see cref="MAP_FOLDDIGITS"/>:
        /// Map all digits to Unicode characters 0 through 9.
        /// <see cref="MAP_PRECOMPOSED"/>:
        /// Map accented characters to precomposed characters, in which the accent and base character are combined into a single character value.
        /// This flag is equivalent to normalization form C in Windows Vista. This value cannot be combined with <see cref="MAP_COMPOSITE"/>.
        /// </param>
        /// <param name="lpSrcStr">
        /// Pointer to a source string that the function maps.
        /// </param>
        /// <param name="cchSrc">
        /// Size, in characters, of the source string indicated by <paramref name="lpSrcStr"/>, excluding the terminating null character.
        /// The application can set the parameter to any negative value to specify that the source string is null-terminated.
        /// In this case, the function calculates the string length automatically, and null-terminates the mapped string indicated by <paramref name="lpDestStr"/>.
        /// </param>
        /// <param name="lpDestStr">
        /// Pointer to a buffer in which this function retrieves the mapped string.
        /// </param>
        /// <param name="cchDest">
        /// Size, in characters, of the destination string indicated by <paramref name="lpDestStr"/>.
        /// If space for a terminating null character is included in <paramref name="cchSrc"/>,
        /// <paramref name="cchDest"/> must also include space for a terminating null character.
        /// The application can set <paramref name="cchDest"/> to 0.
        /// In this case, the function does not use the <paramref name="lpDestStr"/> parameter and returns the required buffer size for the mapped string.
        /// If the <see cref="MAP_FOLDDIGITS"/> flag is specified, the return value is the maximum size required,
        /// even if the actual number of characters needed is smaller than the maximum size.
        /// If the maximum size is not passed, the function fails with <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// </param>
        /// <returns>
        /// Returns the number of characters in the translated string, including a terminating null character, if successful.
        /// If the function succeeds and the value of <paramref name="cchDest"/> is 0,
        /// the return value is the size of the buffer required to hold the translated string, including a terminating null character.
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_DATA"/>. The data was invalid.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// <see cref="ERROR_MOD_NOT_FOUND"/>. The module was not found.
        /// <see cref="ERROR_OUTOFMEMORY"/>. Not enough storage was available to complete this operation.
        /// <see cref="ERROR_PROC_NOT_FOUND"/>. The required procedure was not found.
        /// </returns>
        /// <remarks>
        /// The values of the <paramref name="lpSrcStr"/> and and <paramref name="lpDestStr"/> parameters must not be the same
        /// If they are the same, the function fails with <see cref="ERROR_INVALID_PARAMETER"/>.
        /// The compatibility zone in Unicode consists of characters in the range 0xF900 through 0xFFEF
        /// that are assigned to characters from other encoding standards for characters but are actually variants of characters already in Unicode.
        /// The compatibility zone is used to support round-trip mapping to these standards.
        /// Applications can use the <see cref="MAP_FOLDCZONE"/> flag to avoid supporting the duplication of characters in the compatibility zone.
        /// Starting with Windows Vista:
        /// This function supports Unicode normalization. All Unicode compatibility characters are mapped.
        /// Starting with Windows Vista:
        /// The transformations indicated by the <see cref="MAP_FOLDCZONE"/>, <see cref="MAP_PRECOMPOSED"/>, and <see cref="MAP_COMPOSITE"/> flags
        /// use Unicode normalization forms KC, C, and D (through the <see cref="NormalizeString"/> function) to do the mappings.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FoldStringW", ExactSpelling = true, SetLastError = true)]
        public static extern int FoldString([In] DWORD dwMapFlags, [In] LPCWSTR lpSrcStr, [In] int cchSrc, [In] LPWSTR lpDestStr, [In] int cchDest);

        /// <summary>
        /// <para>
        /// Retrieves character type information for the characters in the specified Unicode source string.
        /// For each character in the string, the function sets one or more bits in the corresponding 16-bit element of the output array.
        /// Each bit identifies a given character type, for example, letter, digit, or neither.
        /// Caution
        /// Using the <see cref="GetStringType"/> function incorrectly can compromise the security of your application.
        /// To avoid a buffer overflow, the application must set the output buffer size correctly.
        /// For more security information, see Security Considerations: Windows User Interface.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-getstringtypew"/>
        /// </para>
        /// </summary>
        /// <param name="dwInfoType">
        /// Flags specifying the character type information to retrieve.
        /// This parameter can have the following values.
        /// The character types are divided into different levels as described in the Remarks section.
        /// <see cref="CT_CTYPE1"/>:
        /// Retrieve character type information.
        /// <see cref="CT_CTYPE2"/>:
        /// Retrieve bidirectional layout information.
        /// <see cref="CT_CTYPE3"/>:
        /// Retrieve text processing information.
        /// </param>
        /// <param name="lpSrcStr">
        /// Pointer to the Unicode string for which to retrieve the character types.
        /// The string is assumed to be null-terminated if <paramref name="cchSrc"/> is set to any negative value.
        /// </param>
        /// <param name="cchSrc">
        /// Size, in characters, of the string indicated by <paramref name="lpSrcStr"/>.
        /// If the size includes a terminating null character, the function retrieves character type information for that character.
        /// If the application sets the size to any negative integer,
        /// the source string is assumed to be null-terminated and the function calculates the size automatically
        /// with an additional character for the null termination.
        /// </param>
        /// <param name="lpCharType">
        /// Pointer to an array of 16-bit values.
        /// The length of this array must be large enough to receive one 16-bit value for each character in the source string.
        /// If <paramref name="cchSrc"/> is not a negative number, <paramref name="lpCharType"/> should be an array of words with <paramref name="cchSrc"/> elements.
        /// If <paramref name="cchSrc"/> is set to a negative number, <paramref name="lpSrcStr"/> is an array of words with <paramref name="lpSrcStr"/> + 1 elements.
        /// When the function returns, this array contains one word corresponding to each character in the source string.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// For an overview of the use of the string functions, see Strings.
        /// The values of the <paramref name="lpSrcStr"/> and <paramref name="lpCharType"/> parameters must not be the same.
        /// If they are the same, the function fails with <see cref="ERROR_INVALID_PARAMETER"/>.
        /// The Locale parameter used by the corresponding GetStringTypeA function is not used by this function.
        /// Because of the parameter difference, an application cannot automatically invoke the proper ANSI or Unicode version of a GetStringType* function
        /// through the use of the #define UNICODE switch.
        /// An application can circumvent this limitation by using <see cref="GetStringTypeEx"/>, which is the recommended function.
        /// Supported Character Types
        /// The character type bits are divided into several levels.
        /// The information for one level can be retrieved by a single call to this function.
        /// Each level is limited to 16 bits of information so that the other mapping functions,
        /// which are limited to 16 bits of representation per character, can also return character type information.
        /// Ctype 1
        /// These types support ANSI C and POSIX (LC_CTYPE) character typing functions.
        /// A bitwise-OR of these values is retrieved in the array in the output buffer when <paramref name="dwInfoType"/> is set to <see cref="CT_CTYPE1"/>.
        /// For DBCS locales, the type attributes apply to both narrow characters and wide characters.
        /// The Japanese hiragana and katakana characters, and the kanji ideograph characters all have the <see cref="C1_ALPHA"/> attribute.
        /// Name                        Value   Meaning
        /// <see cref="C1_UPPER"/>      0x0001  Uppercase
        /// <see cref="C1_LOWER"/>      0x0002  Lowercase
        /// <see cref="C1_DIGIT"/>      0x0004  Decimal digits
        /// <see cref="C1_SPACE"/>      0x0008  Space characters
        /// <see cref="C1_PUNCT"/>      0x0010  Punctuation
        /// <see cref="C1_CNTRL"/>      0x0020  Control characters
        /// <see cref="C1_BLANK"/>      0x0040  Blank characters
        /// <see cref="C1_XDIGIT"/>     0x0080  Hexadecimal digits
        /// <see cref="C1_ALPHA"/>      0x0100  Any linguistic character: alphabetical, syllabary, or ideographic
        /// <see cref="C1_DEFINED"/>    0x0200  A defined character, but not one of the other C1_* types
        /// The following character types are either constant or computable from basic types and do not need to be supported by this function.
        /// Type            Description
        /// Alphanumeric    Alphabetical characters and digits (<see cref="C1_ALPHA"/> and <see cref="C1_DIGIT"/>)
        /// Printable       raphic characters and blanks (all C1_* types except <see cref="C1_CNTRL"/>)
        /// Ctype 2
        /// These types support proper layout of Unicode text. For DBCS locales, the character type applies to both narrow and wide characters.
        /// The direction attributes are assigned so that the bidirectional layout algorithm standardized by Unicode produces accurate results.
        /// These types are mutually exclusive. For more information about the use of these attributes, see The Unicode Standard.
        /// Name                                Value   Meaning
        /// Strong
        /// <see cref="C2_LEFTTORIGHT"/>        0x0001  Left to right
        /// <see cref="C2_RIGHTTOLEFT"/>        0x0002  Right to left
        /// Weak
        /// <see cref="C2_EUROPENUMBER"/>       0x0003  European number, European digit
        /// <see cref="C2_EUROPESEPARATOR"/>    0x0004  European numeric separator
        /// <see cref="C2_EUROPETERMINATOR"/>   0x0005  European numeric terminator
        /// <see cref="C2_ARABICNUMBER"/>       0x0006  Arabic number
        /// <see cref="C2_COMMONSEPARATOR"/>    0x0007  Common numeric separator
        /// Neutral
        /// <see cref="C2_BLOCKSEPARATOR"/>     0x0008  Block separator
        /// <see cref="C2_SEGMENTSEPARATOR"/>   0x0009  Segment separator
        /// <see cref="C2_WHITESPACE"/>         0x000A  White space
        /// <see cref="C2_OTHERNEUTRAL"/>       0x000B  Other neutrals
        /// Not applicable
        /// <see cref="C2_NOTAPPLICABLE"/>      0x0000  No implicit directionality (for example, control codes)
        /// Ctype 3
        /// These types are intended to be placeholders for extensions to the POSIX types required for general text processing or for the standard C library functions.
        /// A bitwise-OR of these values is retrieved when dwInfoType is set to <see cref="CT_CTYPE3"/>.
        /// For DBCS locales, the Ctype 3 attributes apply to both narrow characters and wide characters.
        /// The Japanese hiragana and katakana characters, and the kanji ideograph characters all have the <see cref="C3_ALPHA"/> attribute.
        /// Name                            Value   Meaning
        /// <see cref="C3_NONSPACING"/>     0x0001  Nonspacing mark
        /// <see cref="C3_DIACRITIC"/>      0x0002  Diacritic nonspacing mark
        /// <see cref="C3_VOWELMARK"/>      0x0004  Vowel nonspacing mark
        /// <see cref="C3_SYMBOL"/>         0x0008  Symbol
        /// <see cref="C3_KATAKANA"/>       0x0010  Katakana character
        /// <see cref="C3_HIRAGANA"/>       0x0020  Hiragana character
        /// <see cref="C3_HALFWIDTH"/>      0x0040  Half-width (narrow) character
        /// <see cref="C3_FULLWIDTH"/>      0x0080  Full-width (wide) character
        /// <see cref="C3_IDEOGRAPH"/>      0x0100  Ideographic character
        /// <see cref="C3_KASHIDA"/>        0x0200  Arabic kashida character
        /// <see cref="C3_LEXICAL"/>        0x0400  Punctuation which is counted as part of the word (kashida, hyphen, feminine/masculine ordinal indicators, equal sign, and so forth)
        /// <see cref="C3_ALPHA"/>          0x8000  All linguistic characters (alphabetical, syllabary, and ideographic)
        /// <see cref="C3_HIGHSURROGATE"/>  0x0800  Windows Vista: High surrogate code unit
        /// <see cref="C3_LOWSURROGATE"/>   0x1000  Windows Vista: Low surrogate code unit
        /// Not applicable
        /// <see cref="C3_NOTAPPLICABLE"/>  0x0000  Not applicable
        /// <see cref="C3_HIGHSURROGATE"/> and <see cref="C3_LOWSURROGATE"/> are listed only for completeness, and should never be provided to this function.
        /// They are relevant only for Unicode.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStringTypeW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetStringType([In] CharacterTypeFlags dwInfoType, [In] LPCWSTR lpSrcStr, [In] int cchSrc, [Out] WORD[] lpCharType);

        /// <summary>
        /// <para>
        /// Retrieves character type information for the characters in the specified source string.
        /// For each character in the string, the function sets one or more bits in the corresponding 16-bit element of the output array.
        /// Each bit identifies a given character type, for example, letter, digit, or neither.
        /// Caution
        /// Using the <see cref="GetStringTypeEx"/> function incorrectly can compromise the security of your application.
        /// To avoid a buffer overflow, the application must set the output buffer size correctly.
        /// For more security information, see Security Considerations: Windows User Interface.
        /// Note
        /// Unlike its close relatives GetStringTypeA and GetStringTypeW, this function exhibits appropriate ANSI or Unicode behavior
        /// through the use of the #define UNICODE switch.
        /// This is the recommended function for character type retrieval.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-getstringtypew"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier that specifies the locale.
        /// This value uniquely defines the ANSI code page.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// Windows Vista and later: The following custom locale identifiers are also supported.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </param>
        /// <param name="dwInfoType">
        /// Flags specifying the character type information to retrieve.
        /// For possible flag values, see the dwInfoType parameter of <see cref="GetStringType"/>.
        /// For detailed information about the character type bits, see Remarks for <see cref="GetStringType"/>.
        /// </param>
        /// <param name="lpSrcStr">
        /// Pointer to the Unicode string for which to retrieve the character types.
        /// The string is assumed to be null-terminated if <paramref name="cchSrc"/> is set to any negative value.
        /// </param>
        /// <param name="cchSrc">
        /// Size, in characters, of the string indicated by <paramref name="lpSrcStr"/>.
        /// If the size includes a terminating null character, the function retrieves character type information for that character.
        /// If the application sets the size to any negative integer,
        /// the source string is assumed to be null-terminated and the function calculates the size automatically
        /// with an additional character for the null termination.
        /// </param>
        /// <param name="lpCharType">
        /// Pointer to an array of 16-bit values.
        /// The length of this array must be large enough to receive one 16-bit value for each character in the source string.
        /// If <paramref name="cchSrc"/> is not a negative number, <paramref name="lpCharType"/> should be an array of words with <paramref name="cchSrc"/> elements.
        /// If <paramref name="cchSrc"/> is set to a negative number, <paramref name="lpSrcStr"/> is an array of words with <paramref name="lpSrcStr"/> + 1 elements.
        /// When the function returns, this array contains one word corresponding to each character in the source string.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// For an overview of the use of the string functions, see Strings.
        /// Using the ANSI code page for the supplied locale, this function translates the source string from ANSI to Unicode.
        /// It then analyzes each Unicode character for character type information.
        /// The ANSI version of this function converts the source string to Unicode and calls the corresponding <see cref="GetStringType"/> function.
        /// Thus the words in the output buffer correspond not to the original ANSI string but to its Unicode equivalent.
        /// The conversion from ANSI to Unicode can result in a change in string length, for example, a pair of ANSI characters can map to a single Unicode character.
        /// Therefore, the correspondence between the words in the output buffer and the characters in the original ANSI string
        /// is not one-to-one in all cases, for example, multibyte strings.
        /// Thus, the ANSI version of this function is of limited use for multi-character strings.
        /// The Unicode version of the function is recommended instead.
        /// This function circumvents a limitation caused by the difference in parameters between GetStringTypeA and GetStringTypeW.
        /// Because of the parameter difference, an application cannot automatically invoke the proper ANSI or Unicode version of a GetStringType* function
        /// through the use of the #define UNICODE switch.
        /// On the other hand, <see cref="GetStringTypeEx"/>, behaves properly with regard to that switch. Thus it is the recommended function.
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the function can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark (?).
        /// The values of the lpSrcStr and lpCharType parameters must not be the same.
        /// If they are the same, the function fails with <see cref="ERROR_INVALID_PARAMETER"/>.
        /// The Locale parameter is only used to perform string conversion to Unicode.
        /// It has nothing to do with the CTYPE* values supplied by the application.
        /// These values are solely determined by Unicode code points, and do not vary on a locale basis.
        /// For example, Greek letters are specified as <see cref="C1_ALPHA"/> for any value of Locale.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStringTypeExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetStringTypeEx([In] LCID Locale, [In] DWORD dwInfoType, [In] LPCWSTR lpSrcStr, [In] int cchSrc, [Out] WORD[] lpCharType);

#pragma warning disable IDE1006

        /// <summary>
        /// <para>
        /// Appends one string to another.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrcatw"/>
        /// </para>
        /// </summary>
        /// <param name="lpString1">
        /// The first null-terminated string. This buffer must be large enough to contain both strings.
        /// </param>
        /// <param name="lpString2">
        /// The null-terminated string to be appended to the string specified in the <paramref name="lpString1"/> parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the buffer.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/> and <paramref name="lpString1"/> may not be null-terminated.
        /// </returns>
        [Obsolete("Do not use. Consider using StringCchCat instead. See Security Considerations.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "lstrcatW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr lstrcat([In] IntPtr lpString1, [MarshalAs(UnmanagedType.LPWStr)][In] string lpString2);

        /// <summary>
        /// <para>
        /// Compares two character strings. The comparison is case-sensitive.
        /// To perform a comparison that is not case-sensitive, use the lstrcmpi function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrcmpw"/>
        /// </para>
        /// </summary>
        /// <param name="lpString1">
        /// The first null-terminated string to be compared.
        /// </param>
        /// <param name="lpString2">
        /// The second null-terminated string to be compared.
        /// </param>
        /// <returns>
        /// If the string pointed to by <paramref name="lpString1"/> is less than the string pointed to by <paramref name="lpString2"/>,
        /// the return value is negative.
        /// If the string pointed to by <paramref name="lpString1"/> is greater than the string pointed to by <paramref name="lpString2"/>,
        /// the return value is positive.
        /// If the strings are equal, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="lstrcmp"/> function compares two strings by checking the first characters against each other,
        /// the second characters against each other, and so on until it finds an inequality or reaches the ends of the strings.
        /// Note that the <paramref name="lpString1"/> and <paramref name="lpString2"/> parameters must be null-terminated,
        /// otherwise the string comparison can be incorrect.
        /// The function calls <see cref="CompareStringEx"/>, using the current thread locale, and subtracts 2 from the result,
        /// to maintain the C run-time conventions for comparing strings.
        /// The language (user locale) selected by the user at setup time, or through Control Panel,
        /// determines which string is greater (or whether the strings are the same).
        /// If no language (user locale) is selected, the system performs the comparison by using default values.
        /// With a double-byte character set (DBCS) version of the system, this function can compare two DBCS strings.
        /// The <see cref="lstrcmp"/> function uses a word sort, rather than a string sort.
        /// A word sort treats hyphens and apostrophes differently than it treats other symbols that are not alphanumeric,
        /// in order to ensure that words such as "coop" and "co-op" stay together within a sorted list.
        /// For a detailed discussion of word sorts and string sorts, see Handling Sorting in Your Applications.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "lstrcmpW", ExactSpelling = true, SetLastError = true)]
        public static extern int lstrcmp([MarshalAs(UnmanagedType.LPWStr)][In] string lpString1, [MarshalAs(UnmanagedType.LPWStr)][In] string lpString2);

        /// <summary>
        /// <para>
        /// Compares two character strings. The comparison is not case-sensitive.
        /// To perform a comparison that is case-sensitive, use the <see cref="lstrcmp"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrcmpiw"/>
        /// </para>
        /// </summary>
        /// <param name="lpString1">
        /// The first null-terminated string to be compared.
        /// </param>
        /// <param name="lpString2">
        /// The second null-terminated string to be compared.
        /// </param>
        /// <returns>
        /// If the string pointed to by <paramref name="lpString1"/> is less than the string pointed to by <paramref name="lpString2"/>,
        /// the return value is negative.
        /// If the string pointed to by <paramref name="lpString1"/> is greater than the string pointed to by <paramref name="lpString2"/>,
        /// the return value is positive.
        /// If the strings are equal, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="lstrcmpi"/> function compares two strings by checking the first characters against each other,
        /// the second characters against each other, and so on until it finds an inequality or reaches the ends of the strings.
        /// Note that the <paramref name="lpString1"/> and <paramref name="lpString2"/> parameters must be null-terminated,
        /// otherwise the string comparison can be incorrect.
        /// The function calls <see cref="CompareStringEx"/>, using the current thread locale, and subtracts 2 from the result,
        /// to maintain the C run-time conventions for comparing strings.
        /// For some locales, the lstrcmpi function may be insufficient.
        /// If this occurs, use <see cref="CompareStringEx"/> to ensure proper comparison.
        /// For example, in Japan call with the NORM_IGNORECASE, NORM_IGNOREKANATYPE, and NORM_IGNOREWIDTH values
        /// to achieve the most appropriate non-exact string comparison.
        /// The NORM_IGNOREKANATYPE and NORM_IGNOREWIDTH values are ignored in non-Asian locales, so you can set these values
        /// for all locales and be guaranteed to have a culturally correct "insensitive" sorting regardless of the locale.
        /// Note that specifying these values slows performance, so use them only when necessary.
        /// With a double-byte character set (DBCS) version of the system, this function can compare two DBCS strings.
        /// The lstrcmpi function uses a word sort, rather than a string sort.
        /// A word sort treats hyphens and apostrophes differently than it treats other symbols that are not alphanumeric,
        /// in order to ensure that words such as "coop" and "co-op" stay together within a sorted list.
        /// For a detailed discussion of word sorts and string sorts, see Handling Sorting in Your Applications.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "lstrcmpiW", ExactSpelling = true, SetLastError = true)]
        public static extern int lstrcmpi([MarshalAs(UnmanagedType.LPWStr)][In] string lpString1, [MarshalAs(UnmanagedType.LPWStr)][In] string lpString2);

        /// <summary>
        /// <para>
        /// Copies a string to a buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrcpyw"/>
        /// </para>
        /// </summary>
        /// <param name="lpString1">
        /// A buffer to receive the contents of the string pointed to by the <paramref name="lpString2"/> parameter.
        /// The buffer must be large enough to contain the string, including the terminating null character.
        /// </param>
        /// <param name="lpString2">
        /// The null-terminated string to be copied.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the buffer.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/> and <paramref name="lpString1"/> may not be null-terminated.
        /// </returns>
        /// <remarks>
        /// With a double-byte character set (DBCS) version of the system, this function can be used to copy a DBCS string.
        /// The lstrcpy function has an undefined behavior if source and destination buffers overlap.
        /// Security Remarks
        /// Using this function incorrectly can compromise the security of your application.
        /// This function uses structured exception handling (SEH) to catch access violations and other errors.
        /// When this function catches SEH errors, it returns <see cref="IntPtr.Zero"/> without null-terminating the string
        /// and without notifying the caller of the error.
        /// The caller is not safe to assume that insufficient space is the error condition.
        /// <paramref name="lpString1"/> must be large enough to hold <paramref name="lpString2"/> and the closing '\0', otherwise a buffer overrun may occur.
        /// Buffer overflow situations are the cause of many security problems in applications and can cause a denial of service attack
        /// against the application if an access violation occurs.
        /// In the worst case, a buffer overrun may allow an attacker to inject executable code into your process,
        /// especially if <paramref name="lpString1"/> is a stack-based buffer.
        /// Consider using <see cref="StringCchCopy"/> instead; use either <code>StringCchCopy(buffer, sizeof(buffer)/sizeof(buffer[0]), src);</code>,
        /// being aware that buffer must not be a pointer or use <code>StringCchCopy(buffer, ARRAYSIZE(buffer), src);</code>,
        /// being aware that, when copying to a pointer, the caller is responsible for passing in the size of the pointed-to memory in characters.
        /// </remarks>
        [Obsolete("Do not use. Consider using StringCchCopy instead. See Remarks.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "lstrcpyW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr lstrcpy([In] IntPtr lpString1, [MarshalAs(UnmanagedType.LPWStr)][In] string lpString2);

        /// <summary>
        /// <para>
        /// Copies a specified number of characters from a source string into a buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrcpynw"/>
        /// </para>
        /// </summary>
        /// <param name="lpString1">
        /// The destination buffer, which receives the copied characters.
        /// The buffer must be large enough to contain the number of TCHAR values specified by <paramref name="iMaxLength"/>,
        /// including room for a terminating null character.
        /// </param>
        /// <param name="lpString2">
        /// The source string from which the function is to copy characters.
        /// </param>
        /// <param name="iMaxLength">
        /// The number of TCHAR values to be copied from the string pointed to by <paramref name="lpString2"/>
        /// into the buffer pointed to by <paramref name="lpString1"/>, including a terminating null character.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the buffer.
        /// The function can succeed even if the source string is greater than <paramref name="iMaxLength"/> characters.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/> and <paramref name="lpString1"/> may not be null-terminated.
        /// </returns>
        /// <remarks>
        /// The buffer pointed to by <paramref name="lpString1"/> must be large enough to include a terminating null character,
        /// and the string length value specified by <paramref name="iMaxLength"/> includes room for a terminating null character.
        /// The <see cref="lstrcpyn"/> function has an undefined behavior if source and destination buffers overlap.
        /// Security Warning
        /// Using this function incorrectly can compromise the security of your application.
        /// This function uses structured exception handling (SEH) to catch access violations and other errors.
        /// When this function catches SEH errors, it returns NULL without null-terminating the string and without notifying the caller of the error.
        /// The caller is not safe to assume that insufficient space is the error condition.
        /// If the buffer pointed to by <paramref name="lpString1"/> is not large enough to contain the copied string, a buffer overrun can occur.
        /// When copying an entire string, note that sizeof returns the number of bytes.
        /// For example, if <paramref name="lpString1"/> points to a buffer szString1 which is declared as TCHAR szString[100],
        /// then sizeof(szString1) gives the size of the buffer in bytes rather than WCHAR,
        /// which could lead to a buffer overflow for the Unicode version of the function.
        /// Buffer overflow situations are the cause of many security problems in applications and can cause a denial of service attack
        /// against the application if an access violation occurs.
        /// In the worst case, a buffer overrun may allow an attacker to inject executable code into your process,
        /// especially if lpString1 is a stack-based buffer.
        /// Using sizeof(szString1)/sizeof(szString1[0]) gives the proper size of the buffer.
        /// Consider using <see cref="StringCchCopy"/> instead; use either <code>StringCchCopy(buffer, sizeof(buffer)/sizeof(buffer[0]), src);</code>,
        /// being aware that buffer must not be a pointer or use <code>StringCchCopy(buffer, ARRAYSIZE(buffer), src);</code>,
        /// being aware that, when copying to a pointer, the caller is responsible for passing in the size of the pointed-to memory in characters.
        /// Review Security Considerations: Windows User Interface before continuing.
        /// </remarks>
        [Obsolete("Do not use. Consider using StringCchCopy instead. See Remarks.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "lstrcpynW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr lstrcpyn([In] IntPtr lpString1, [MarshalAs(UnmanagedType.LPWStr)][In] string lpString2, [In] int iMaxLength);

        /// <summary>
        /// <para>
        /// Determines the length of the specified string (not including the terminating null character).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrlenw"/>
        /// </para>
        /// </summary>
        /// <param name="lpString">
        /// The null-terminated string to be checked.
        /// </param>
        /// <returns>
        /// The function returns the length of the string, in characters.
        /// If <paramref name="lpString"/> is <see langword="null"/>, the function returns 0.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "lstrlenW", ExactSpelling = true, SetLastError = true)]
        public static extern int lstrlen([MarshalAs(UnmanagedType.LPWStr)][In] string lpString);
#pragma warning restore IDE1006

        /// <summary>
        /// <para>
        /// Maps a character string to a UTF-16 (wide character) string.
        /// The character string is not necessarily from a multibyte character set.
        /// Caution
        /// Using the <see cref="MultiByteToWideChar"/> function incorrectly can compromise the security of your application.
        /// Calling this function can easily cause a buffer overrun because the size of the input buffer
        /// indicated by <paramref name="lpMultiByteStr"/> equals the number of bytes in the string,
        /// while the size of the output buffer indicated by <paramref name="lpWideCharStr"/> equals the number of characters.
        /// To avoid a buffer overrun, your application must specify a buffer size appropriate for the data type the buffer receives.
        /// For more information, see Security Considerations: International Features.
        /// Note
        /// The ANSI code pages can be different on different computers, or can be changed for a single computer, leading to data corruption.
        /// For the most consistent results, applications should use Unicode, such as UTF-8 or UTF-16, instead of a specific code page,
        /// unless legacy standards or data formats prevent the use of Unicode.
        /// If using Unicode is not possible, applications should tag the data stream with the appropriate encoding name when protocols allow it.
        /// HTML and XML files allow tagging, but text files do not.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-multibytetowidechar"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// Code page to use in performing the conversion.
        /// This parameter can be set to the value of any code page that is installed or available in the operating system.
        /// For a list of code pages, see Code Page Identifiers.
        /// Your application can also specify one of the values shown in the following table.
        /// <see cref="CP_ACP"/>:
        /// The system default Windows ANSI code page. 
        /// Note
        /// This value can be different on different computers, even on the same network.
        /// It can be changed on the same computer, leading to stored data becoming irrecoverably corrupted.
        /// This value is only intended for temporary use and permanent storage should use UTF-16 or UTF-8 if possible.
        /// <see cref="CP_MACCP"/>:
        /// The current system Macintosh code page. 
        /// Note
        /// This value can be different on different computers, even on the same network.
        /// It can be changed on the same computer, leading to stored data becoming irrecoverably corrupted.
        /// This value is only intended for temporary use and permanent storage should use UTF-16 or UTF-8 if possible.
        /// Note
        /// This value is used primarily in legacy code and should not generally be needed since modern Macintosh computers use Unicode for encoding.
        /// <see cref="CP_OEMCP"/>:
        /// The current system OEM code page.
        /// Note  This value can be different on different computers, even on the same network.
        /// It can be changed on the same computer, leading to stored data becoming irrecoverably corrupted.
        /// This value is only intended for temporary use and permanent storage should use UTF-16 or UTF-8 if possible.
        /// <see cref="CP_SYMBOL"/>:
        /// Symbol code page (42).
        /// <see cref="CP_THREAD_ACP"/>:
        /// The Windows ANSI code page for the current thread.
        /// Note  This value can be different on different computers, even on the same network.
        /// It can be changed on the same computer, leading to stored data becoming irrecoverably corrupted.
        /// This value is only intended for temporary use and permanent storage should use UTF-16 or UTF-8 if possible.
        /// <see cref="CP_UTF7"/>:
        /// UTF-7. Use this value only when forced by a 7-bit transport mechanism. Use of UTF-8 is preferred. 
        /// <see cref="CP_UTF8"/>:
        /// UTF-8. 
        /// </param>
        /// <param name="dwFlags">
        /// Flags indicating the conversion type.
        /// The application can specify a combination of the following values, with <see cref="MB_PRECOMPOSED"/> being the default.
        /// <see cref="MB_PRECOMPOSED"/> and <see cref="MB_COMPOSITE"/> are mutually exclusive.
        /// <see cref="MB_USEGLYPHCHARS"/> and <see cref="MB_ERR_INVALID_CHARS"/> can be set regardless of the state of the other flags.
        /// <see cref="MB_COMPOSITE"/>:
        /// Always use decomposed characters, that is, characters in which a base character
        /// and one or more nonspacing characters each have distinct code point values.
        /// For example, Ä is represented by A + ¨: LATIN CAPITAL LETTER A (U+0041) + COMBINING DIAERESIS (U+0308).
        /// Note that this flag cannot be used with <see cref="MB_PRECOMPOSED"/>.
        /// <see cref="MB_ERR_INVALID_CHARS"/>:
        /// Fail if an invalid input character is encountered.
        /// Starting with Windows Vista, the function does not drop illegal code points if the application does not set this flag,
        /// but instead replaces illegal sequences with U+FFFD (encoded as appropriate for the specified codepage).
        /// Windows 2000 with SP4 and later, Windows XP:
        /// If this flag is not set, the function silently drops illegal code points.
        /// A call to <see cref="GetLastError"/> returns <see cref="ERROR_NO_UNICODE_TRANSLATION"/>.
        /// <see cref="MB_PRECOMPOSED"/>:
        /// Default; do not use with <see cref="MB_COMPOSITE"/>.
        /// Always use precomposed characters, that is, characters having a single character value for a base or nonspacing character combination.
        /// For example, in the character è, the e is the base character and the accent grave mark is the nonspacing character.
        /// If a single Unicode code point is defined for a character, the application should use it
        /// instead of a separate base character and a nonspacing character.
        /// For example, Ä is represented by the single Unicode code point LATIN CAPITAL LETTER A WITH DIAERESIS (U+00C4).
        /// <see cref="MB_USEGLYPHCHARS"/>:
        /// Use glyph characters instead of control characters.
        /// For the code pages listed below, <paramref name="dwFlags"/> must be set to 0.
        /// Otherwise, the function fails with <see cref="ERROR_INVALID_FLAGS"/>.
        /// 50220,50221,50222,50225,50227,50229,57002 through 57011,65000 (UTF-7),42 (Symbol)
        /// Note
        /// For UTF-8 or code page 54936 (GB18030, starting with Windows Vista),
        /// <paramref name="dwFlags"/> must be set to either 0 or <see cref="MB_ERR_INVALID_CHARS"/>.
        /// Otherwise, the function fails with <see cref="ERROR_INVALID_FLAGS"/>.
        /// </param>
        /// <param name="lpMultiByteStr">
        /// Pointer to the character string to convert.
        /// </param>
        /// <param name="cbMultiByte">
        /// Size, in bytes, of the string indicated by the <paramref name="lpMultiByteStr"/> parameter.
        /// Alternatively, this parameter can be set to -1 if the string is null-terminated.
        /// Note that, if <paramref name="cbMultiByte"/> is 0, the function fails.
        /// If this parameter is -1, the function processes the entire input string, including the terminating null character.
        /// Therefore, the resulting Unicode string has a terminating null character, and the length returned by the function includes this character.
        /// If this parameter is set to a positive integer, the function processes exactly the specified number of bytes.
        /// If the provided size does not include a terminating null character, the resulting Unicode string is not null-terminated,
        /// and the returned length does not include this character.
        /// </param>
        /// <param name="lpWideCharStr">
        /// Pointer to a buffer that receives the converted string.
        /// </param>
        /// <param name="cchWideChar">
        /// Size, in characters, of the buffer indicated by <paramref name="lpWideCharStr"/>.
        /// If this value is 0, the function returns the required buffer size, in characters,
        /// including any terminating null character, and makes no use of the <paramref name="lpWideCharStr"/> buffer.
        /// </param>
        /// <returns>
        /// Returns the number of characters written to the buffer indicated by <paramref name="lpWideCharStr"/> if successful.
        /// If the function succeeds and <paramref name="cchWideChar"/> is 0, the return value is the required size, in characters,
        /// for the buffer indicated by <paramref name="lpWideCharStr"/>.
        /// Also see <paramref name="dwFlags"/> for info about how the <see cref="MB_ERR_INVALID_CHARS"/> flag
        /// affects the return value when invalid sequences are input.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// <see cref="ERROR_NO_UNICODE_TRANSLATION"/>. Invalid Unicode was found in a string.
        /// </returns>
        /// <remarks>
        /// The default behavior of this function is to translate to a precomposed form of the input character string.
        /// If a precomposed form does not exist, the function attempts to translate to a composite form.
        /// The use of the <see cref="MB_PRECOMPOSED"/> flag has very little effect on most code pages because most input data is composed already.
        /// Consider calling <see cref="NormalizeString"/> after converting with <see cref="MultiByteToWideChar"/>.
        /// <see cref="NormalizeString"/> provides more accurate, standard, and consistent data, and can also be faster.
        /// Note that for the <see cref="NORM_FORM"/> enumeration being passed to <see cref="NormalizeString"/>,
        /// <see cref="NormalizationC"/> corresponds to <see cref="MB_PRECOMPOSED"/>
        /// and <see cref="NormalizationD"/> corresponds to <see cref="MB_COMPOSITE"/>.
        /// As mentioned in the caution above, the output buffer can easily be overrun if this function is not first called
        /// with <paramref name="cchWideChar"/> set to 0 in order to obtain the required size.
        /// If the <see cref="MB_COMPOSITE"/> flag is used, the output can be three or more characters long for each input character.
        /// The <paramref name="lpMultiByteStr"/> and <paramref name="lpWideCharStr"/> pointers must not be the same.
        /// If they are the same, the function fails, and <see cref="GetLastError"/> returns the value <see cref="ERROR_INVALID_PARAMETER"/>.
        /// <see cref="MultiByteToWideChar"/> does not null-terminate an output string
        /// if the input string length is explicitly specified without a terminating null character.
        /// To null-terminate an output string for this function, the application should pass in -1
        /// or explicitly count the terminating null character for the input string.
        /// The function fails if <see cref="MB_ERR_INVALID_CHARS"/> is set and an invalid character is encountered in the source string.
        /// An invalid character is one of the following:
        /// A character that is not the default character in the source string,
        /// but translates to the default character when <see cref="MB_ERR_INVALID_CHARS"/> is not set
        /// For DBCS strings, a character that has a lead byte but no valid trail byte
        /// Starting with Windows Vista, this function fully conforms with the Unicode 4.1 specification for UTF-8 and UTF-16.
        /// The function used on earlier operating systems encodes or decodes lone surrogate halves or mismatched surrogate pairs.
        /// Code written in earlier versions of Windows that rely on this behavior to encode random non-text binary data might run into problems.
        /// However, code that uses this function on valid UTF-8 strings will behave the same way as on earlier Windows operating systems.
        /// Windows XP:
        /// To prevent the security problem of the non-shortest-form versions of UTF-8 characters, <see cref="MultiByteToWideChar"/> deletes these characters.
        /// Starting with Windows 8:
        /// <see cref="MultiByteToWideChar"/> is declared in Stringapiset.h. Before Windows 8, it was declared in Winnls.h.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MultiByteToWideChar", ExactSpelling = true, SetLastError = true)]
        public static extern int MultiByteToWideChar([In] CodePages CodePage, [In] MBCSTranslationFlags dwFlags, [In] IntPtr lpMultiByteStr,
            [In] int cbMultiByte, [In] IntPtr lpWideCharStr, [In] int cchWideChar);

        /// <summary>
        /// <para>
        /// Normalizes characters of a text string according to Unicode 4.0 TR#15.
        /// For more information, see Using Unicode Normalization to Represent Strings.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-normalizestring"/>
        /// </para>
        /// </summary>
        /// <param name="NormForm">
        /// Normalization form to use.
        /// <see cref="NORM_FORM"/> specifies the standard Unicode normalization forms.
        /// </param>
        /// <param name="lpSrcString">
        /// Pointer to the non-normalized source string.
        /// </param>
        /// <param name="cwSrcLength">
        /// Length, in characters, of the buffer containing the source string.
        /// The application can set this parameter to -1 if the function should assume the string
        /// to be null-terminated and calculate the length automatically.
        /// </param>
        /// <param name="lpDstString">
        /// Pointer to a buffer in which the function retrieves the destination string.
        /// Alternatively, this parameter contains <see cref="NULL"/> if <paramref name="cwDstLength"/> is set to 0.
        /// Note
        /// The function does not null-terminate the string if the input string length is explicitly specified without a terminating null character.
        /// To null-terminate the output string, the application should specify -1
        /// or explicitly count the terminating null character for the input string.
        /// </param>
        /// <param name="cwDstLength">
        /// Length, in characters, of the buffer containing the destination string.
        /// Alternatively, the application can set this parameter to 0 to request the function to return the required size for the destination buffer.
        /// </param>
        /// <returns>
        /// Returns the length of the normalized string in the destination buffer.
        /// If <paramref name="cwDstLength"/> is set to 0, the function returns the estimated buffer length required to do the actual conversion.
        /// If the string in the input buffer is null-terminated or if <paramref name="cwSrcLength"/> is -1,
        /// the string written to the destination buffer is null-terminated and the returned string length includes the terminating null character.
        /// The function returns a value that is less than or equal to 0 if it does not succeed.
        /// To get extended error information, the application can call GetLastError, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// <see cref="ERROR_NO_UNICODE_TRANSLATION"/>. Invalid Unicode was found in a string.
        /// The return value is the negative of the index of the location of the error in the input string.
        /// <see cref="ERROR_SUCCESS"/>. The action completed successfully but yielded no results.
        /// </returns>
        /// <remarks>
        /// Some Unicode characters have multiple equivalent binary representations consisting of sets of combining and/or composite Unicode characters.
        /// The Unicode standard defines a process called normalization that returns one binary representation
        /// when given any of the equivalent binary representations of a character.
        /// Normalization can be performed with several algorithms, called normalization forms, that obey different rules,
        /// as described in Using Unicode Normalization to Represent Strings.
        /// The Win32 and the .NET Framework currently support normalization forms C, D, KC, and KD,
        /// as defined in Unicode Standard Annex #15: Unicode Normalization Forms.
        /// Normalized strings are typically evaluated with an ordinal comparison.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "NormalizeString", ExactSpelling = true, SetLastError = true)]
        public static extern int NormalizeString([In] NORM_FORM NormForm, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSrcString,
            [In] int cwSrcLength, [In] IntPtr lpDstString, [In] int cwDstLength);

        /// <summary>
        /// <para>
        /// Maps a UTF-16 (wide character) string to a new character string.
        /// The new character string is not necessarily from a multibyte character set.
        /// Caution
        /// Using the <see cref="WideCharToMultiByte"/> function incorrectly can compromise the security of your application.
        /// Calling this function can easily cause a buffer overrun because the size of the input buffer
        /// indicated by <paramref name="lpWideCharStr"/> equals the number of characters in the Unicode string,
        /// while the size of the output buffer indicated by <paramref name="lpMultiByteStr"/> equals the number of bytes.
        /// To avoid a buffer overrun, your application must specify a buffer size appropriate for the data type the buffer receives
        /// Data converted from UTF-16 to non-Unicode encodings is subject to data loss,
        /// because a code page might not be able to represent every character used in the specific Unicode data.
        /// For more information, see Security Considerations: International Features.
        /// Note
        /// The ANSI code pages can be different on different computers, or can be changed for a single computer, leading to data corruption.
        /// For the most consistent results, applications should use Unicode, such as UTF-8 or UTF-16,
        /// instead of a specific code page, unless legacy standards or data formats prevent the use of Unicode.
        /// If using Unicode is not possible, applications should tag the data stream with the appropriate encoding name when protocols allow it.
        /// HTML and XML files allow tagging, but text files do not.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-widechartomultibyte"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// Code page to use in performing the conversion.
        /// This parameter can be set to the value of any code page that is installed or available in the operating system.
        /// For a list of code pages, see Code Page Identifiers.
        /// Your application can also specify one of the values shown in the following table.
        /// <see cref="CP_ACP"/>:
        /// The system default Windows ANSI code page.
        /// Note
        /// This value can be different on different computers, even on the same network.
        /// It can be changed on the same computer, leading to stored data becoming irrecoverably corrupted.
        /// This value is only intended for temporary use and permanent storage should use UTF-16 or UTF-8 if possible.
        /// <see cref="CP_MACCP"/>:
        /// The current system Macintosh code page.
        /// Note
        /// This value can be different on different computers, even on the same network.
        /// It can be changed on the same computer, leading to stored data becoming irrecoverably corrupted.
        /// This value is only intended for temporary use and permanent storage should use UTF-16 or UTF-8 if possible.
        /// Note
        /// This value is used primarily in legacy code and should not generally be needed since modern Macintosh computers use Unicode for encoding.
        /// <see cref="CP_OEMCP"/>:
        /// The current system OEM code page.
        /// Note
        /// This value can be different on different computers, even on the same network.
        /// It can be changed on the same computer, leading to stored data becoming irrecoverably corrupted.
        /// This value is only intended for temporary use and permanent storage should use UTF-16 or UTF-8 if possible.
        /// <see cref="CP_SYMBOL"/>:
        /// Windows 2000: Symbol code page (42).
        /// <see cref="CP_THREAD_ACP"/>:
        /// Windows 2000: The Windows ANSI code page for the current thread.
        /// Note
        /// This value can be different on different computers, even on the same network.
        /// It can be changed on the same computer, leading to stored data becoming irrecoverably corrupted.
        /// This value is only intended for temporary use and permanent storage should use UTF-16 or UTF-8 if possible.
        /// <see cref="CP_UTF7"/>:
        /// UTF-7. Use this value only when forced by a 7-bit transport mechanism.
        /// Use of UTF-8 is preferred. With this value set, <paramref name="lpDefaultChar"/> 
        /// and <paramref name="lpUsedDefaultChar"/> must be set to <see cref="NULL"/>.
        /// <see cref="CP_UTF8"/>:
        /// UTF-8. With this value set, <paramref name="lpDefaultChar"/> and <paramref name="lpUsedDefaultChar"/> must be set to <see cref="NULL"/>.
        /// </param>
        /// <param name="dwFlags">
        /// Flags indicating the conversion type.
        /// The application can specify a combination of the following values.
        /// The function performs more quickly when none of these flags is set.
        /// The application should specify <see cref="WC_NO_BEST_FIT_CHARS"/> and <see cref="WC_COMPOSITECHECK"/> with the specific value
        /// <see cref="WC_DEFAULTCHAR"/> to retrieve all possible conversion results.
        /// If all three values are not provided, some results will be missing.
        /// <see cref="WC_COMPOSITECHECK"/>:
        /// Convert composite characters, consisting of a base character and a nonspacing character, each with different character values.
        /// Translate these characters to precomposed characters, which have a single character value for a base-nonspacing character combination.
        /// For example, in the character è, the e is the base character and the accent grave mark is the nonspacing character.
        /// Note 
        /// Windows normally represents Unicode strings with precomposed data, making the use of the <see cref="WC_COMPOSITECHECK"/> flag unnecessary.
        /// Your application can combine <see cref="WC_COMPOSITECHECK"/> with any one of the following flags, with the default being <see cref="WC_SEPCHARS"/>.
        /// These flags determine the behavior of the function when no precomposed mapping for a base-nonspacing character combination in a Unicode string is available.
        /// If none of these flags is supplied, the function behaves as if the <see cref="WC_SEPCHARS"/> flag is set.
        /// For more information, see <see cref="WC_COMPOSITECHECK"/> and related flags in the Remarks section.
        /// <see cref="WC_DEFAULTCHAR"/>	Replace exceptions with the default character during conversion.
        /// <see cref="WC_DISCARDNS"/>      Discard nonspacing characters during conversion.
        /// <see cref="WC_SEPCHARS"/>       Default. Generate separate characters during conversion.
        /// <see cref="WC_ERR_INVALID_CHARS"/>:
        /// Windows Vista and later: Fail (by returning 0 and setting the last-error code to <see cref="ERROR_NO_UNICODE_TRANSLATION"/>)
        /// if an invalid input character is encountered. 
        /// You can retrieve the last-error code with a call to <see cref="GetLastError"/>.
        /// If this flag is not set, the function replaces illegal sequences with U+FFFD (encoded as appropriate for the specified codepage)
        /// and succeeds by returning the length of the converted string.
        /// Note that this flag only applies when <paramref name="CodePage"/> is specified as <see cref="CP_UTF8"/> or 54936.
        /// It cannot be used with other code page values.
        /// <see cref="WC_NO_BEST_FIT_CHARS"/>:
        /// Translate any Unicode characters that do not translate directly to multibyte equivalents to the default character specified by <paramref name="lpDefaultChar"/>.
        /// In other words, if translating from Unicode to multibyte and back to Unicode again does not yield the same Unicode character,
        /// the function uses the default character. This flag can be used by itself or in combination with the other defined flags.
        /// For strings that require validation, such as file, resource, and user names, the application should always use the <see cref="WC_NO_BEST_FIT_CHARS"/> flag.
        /// This flag prevents the function from mapping characters to characters that appear similar but have very different semantics.
        /// In some cases, the semantic change can be extreme.
        /// For example, the symbol for "∞" (infinity) maps to 8 (eight) in some code pages.
        /// For the code pages listed below, <paramref name="dwFlags"/> must be 0.
        /// Otherwise, the function fails with <see cref="ERROR_INVALID_FLAGS"/>.
        /// 50220, 50221, 50222, 50225, 50227, 50229, 57002 through 57011, 65000 (UTF-7), 42 (Symbol)
        /// Note 
        /// For the code page 65001 (UTF-8) or the code page 54936 (GB18030, Windows Vista and later),
        /// <paramref name="dwFlags"/> must be set to either 0 or <see cref="WC_ERR_INVALID_CHARS"/>.
        /// Otherwise, the function fails with <see cref="ERROR_INVALID_FLAGS"/>.
        /// </param>
        /// <param name="lpWideCharStr">
        /// Pointer to the Unicode string to convert.
        /// </param>
        /// <param name="cchWideChar">
        /// Size, in characters, of the string indicated by <paramref name="lpWideCharStr"/>.
        /// Alternatively, this parameter can be set to -1 if the string is null-terminated.
        /// If <paramref name="cchWideChar"/> is set to 0, the function fails.
        /// If this parameter is -1, the function processes the entire input string, including the terminating null character.
        /// Therefore, the resulting character string has a terminating null character, and the length returned by the function includes this character.
        /// If this parameter is set to a positive integer, the function processes exactly the specified number of characters.
        /// If the provided size does not include a terminating null character, the resulting character string is not null-terminated,
        /// and the returned length does not include this character.
        /// </param>
        /// <param name="lpMultiByteStr">
        /// Pointer to a buffer that receives the converted string.
        /// </param>
        /// <param name="cbMultiByte">
        /// Size, in bytes, of the buffer indicated by <paramref name="lpMultiByteStr"/>.
        /// If this parameter is set to 0, the function returns the required buffer size for <paramref name="lpMultiByteStr"/>
        /// and makes no use of the output parameter itself.
        /// </param>
        /// <param name="lpDefaultChar">
        /// Pointer to the character to use if a character cannot be represented in the specified code page.
        /// The application sets this parameter to <see cref="NULL"/> if the function is to use a system default value.
        /// To obtain the system default character, the application can call the <see cref="GetCPInfo"/> or <see cref="GetCPInfoEx"/> function.
        /// For the <see cref="CP_UTF7"/> and <see cref="CP_UTF8"/> settings for CodePage, this parameter must be set to <see cref="NULL"/>.
        /// Otherwise, the function fails with <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <param name="lpUsedDefaultChar">
        /// Pointer to a flag that indicates if the function has used a default character in the conversion.
        /// The flag is set to <see cref="TRUE"/> if one or more characters in the source string cannot be represented in the specified code page.
        /// Otherwise, the flag is set to <see cref="FALSE"/>. This parameter can be set to <see cref="NullRef{BOOL}"/>.
        /// For the <see cref="CP_UTF7"/> and <see cref="CP_UTF8"/> settings for <paramref name="CodePage"/>, this parameter must be set to <see cref="NullRef{BOOL}"/>.
        /// Otherwise, the function fails with <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <returns>
        /// If successful, returns the number of bytes written to the buffer pointed to by <paramref name="lpMultiByteStr"/>.
        /// If the function succeeds and <paramref name="cbMultiByte"/> is 0, the return value is the required size, in bytes,
        /// for the buffer indicated by <paramref name="lpMultiByteStr"/>.
        /// Also see <paramref name="dwFlags"/> for info about how the <see cref="WC_ERR_INVALID_CHARS"/> flag affects the return value when invalid sequences are input.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// <see cref="ERROR_NO_UNICODE_TRANSLATION"/>. Invalid Unicode was found in a string.
        /// </returns>
        /// <remarks>
        /// The <paramref name="lpMultiByteStr"/> and <paramref name="lpWideCharStr"/> pointers must not be the same.
        /// If they are the same, the function fails, and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// <see cref="WideCharToMultiByte"/> does not null-terminate an output string if the input string length is explicitly specified without a terminating null character.
        /// To null-terminate an output string for this function, the application should pass in -1 or explicitly count the terminating null character for the input string.
        /// If <paramref name="cbMultiByte"/> is less than <paramref name="cchWideChar"/>, this function writes the number of characters
        /// specified by <paramref name="cbMultiByte"/> to the buffer indicated by <paramref name="lpMultiByteStr"/>.
        /// However, if <paramref name="CodePage"/> is set to <see cref="CP_SYMBOL"/> and <paramref name="cbMultiByte"/> is less than <paramref name="cchWideChar"/>,
        /// the function writes no characters to <paramref name="lpMultiByteStr"/>.
        /// The <see cref="WideCharToMultiByte"/> function operates most efficiently when both <paramref name="lpDefaultChar"/>
        /// and <paramref name="lpUsedDefaultChar"/> are set to <see cref="NULL"/>.
        /// The following table shows the behavior of the function for the four possible combinations of these parameters.
        /// <paramref name="lpDefaultChar"/>	<paramref name="lpUsedDefaultChar"/>	Result
        /// <see cref="NULL"/>	                <see cref="NullRef{BOOL}"/>	            No default checking. These parameter settings are the most efficient ones for use with this function.
        /// Non-null character	                <see cref="NullRef{BOOL}"/>	            Uses the specified default character, but does not set <paramref name="lpUsedDefaultChar"/>.
        /// <see cref="NULL"/>	                Non-null character	                    Uses the system default character and sets <paramref name="lpUsedDefaultChar"/> if necessary.
        /// Non-null character	                Non-null character	                    Uses the specified default character and sets <paramref name="lpUsedDefaultChar"/> if necessary.
        /// Starting with Windows Vista, this function fully conforms with the Unicode 4.1 specification for UTF-8 and UTF-16.
        /// The function used on earlier operating systems encodes or decodes lone surrogate halves or mismatched surrogate pairs.
        /// Code written in earlier versions of Windows that rely on this behavior to encode random non-text binary data might run into problems.
        /// However, code that uses this function to produce valid UTF-8 strings will behave the same way as on earlier Windows operating systems.
        /// Starting with Windows 8: <see cref="WideCharToMultiByte"/> is declared in Stringapiset.h. Before Windows 8, it was declared in Winnls.h.
        /// <see cref="WC_COMPOSITECHECK"/> and related flags
        /// As discussed in Using Unicode Normalization to Represent Strings, Unicode allows multiple representations of the same string (interpreted linguistically).
        /// For example, Capital A with dieresis (umlaut) can be represented either precomposed as a single Unicode code point "Ä" (U+00C4)
        /// or decomposed as the combination of Capital A and the combining dieresis character ("A" + "¨", that is U+0041 U+0308).
        /// However, most code pages provide only composed characters.
        /// The <see cref="WC_COMPOSITECHECK"/> flag causes the <see cref="WideCharToMultiByte"/> function to test for decomposed Unicode characters
        /// and attempts to compose them before converting them to the requested code page.
        /// This flag is only available for conversion to single byte (SBCS) or double byte (DBCS) code pages (code pages &gt; 50000, excluding code page 42).
        /// If your application needs to convert decomposed Unicode data to single byte or double byte code pages, this flag might be useful.
        /// However, not all characters can be converted this way and it is more reliable to save and store such data as Unicode.
        /// When an application is using <see cref="WC_COMPOSITECHECK"/>, some character combinations might remain incomplete or might have additional nonspacing characters left over.
        /// For example, A + ¨ + ¨ combines to Ä + ¨. Using the <see cref="WC_DISCARDNS"/> flag causes the function to discard additional nonspacing characters.
        /// Using the <see cref="WC_DEFAULTCHAR"/> flag causes the function to use the default replacement character (typically "?") instead.
        /// Using the <see cref="WC_SEPCHARS"/> flag causes the function to attempt to convert each additional nonspacing character to the target code page.
        /// Usually this flag also causes the use of the replacement character ("?").
        /// However, for code page 1258 (Vietnamese) and 20269, nonspacing characters exist and can be used.
        /// The conversions for these code pages are not perfect.
        /// Some combinations do not convert correctly to code page 1258, and WC_COMPOSITECHECK corrupts data in code page 20269.
        /// As mentioned earlier, it is more reliable to design your application to save and store such data as Unicode.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WideCharToMultiByte", ExactSpelling = true, SetLastError = true)]
        public static extern int WideCharToMultiByte([In] CodePages CodePage, [In] MBCSTranslationFlags dwFlags, [In] IntPtr lpWideCharStr, [In] int cchWideChar,
            [In] IntPtr lpMultiByteStr, [In] int cbMultiByte, [In] LPCCH lpDefaultChar, [Out] out BOOL lpUsedDefaultChar);
    }
}
