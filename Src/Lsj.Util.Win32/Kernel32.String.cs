using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.LCID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CodePages;
using static Lsj.Util.Win32.Enums.CompareStringResults;
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/intl/locale-name-constants
        /// </para>
        /// </summary>
        public static readonly StringHandle LOCALE_NAME_INVARIANT = "";

        /// <summary>
        /// <para>
        /// Maximum length of a locale name. The maximum number of characters allowed for this string is 85, including a terminating null character.
        /// Your application must use the constant for the maximum locale name length, instead of hard-coding the value "85". 
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/intl/locale-name-constants
        /// </para>
        /// </summary>
        public const int LOCALE_NAME_MAX_LENGTH = 85;

        /// <summary>
        /// <para>
        /// Name of the current operating system locale.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/intl/locale-name-constants
        /// </para>
        /// </summary>
        public static readonly StringHandle LOCALE_NAME_SYSTEM_DEFAULT = "!x-sys-default-locale";

        /// <summary>
        /// <para>
        /// Name of the current user locale, matching the preference set in the regional and language options portion of Control Panel.
        /// This locale can be different from the locale for the current user interface language.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/intl/locale-name-constants
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-comparestringw
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
        public static extern CompareStringResults CompareString([In] LCID Locale, [In] StringFlags dwCmpFlags, [In] StringHandle lpString1,
            [In] int cchCount1, [In] StringHandle lpString2, [In] int cchCount2);

        /// <summary>
        /// <para>
        /// Compares two Unicode strings to test binary equivalence.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-comparestringordinal
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
        public static extern int CompareStringOrdinal([In] StringHandle lpString1, [In] int cchCount1, [In] StringHandle lpString2,
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-comparestringex
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
            [In] StringHandle lpString1, [In] int cchCount1, [In] StringHandle lpString2, [In] int cchCount2, [In] in NLSVERSIONINFOEX lpVersionInformation,
            [In] LPVOID lpReserved, [In] LPARAM lParam);

#pragma warning disable IDE1006

        /// <summary>
        /// <para>
        /// Appends one string to another.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrcatw
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrcmpw
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrcmpiw
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrcpyw
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrcpynw
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-lstrlenw
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-multibytetowidechar
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-normalizestring
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
    }
}
