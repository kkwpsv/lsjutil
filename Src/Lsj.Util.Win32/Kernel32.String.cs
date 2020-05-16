using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.BaseTypes.LCID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CompareStringResults;
using static Lsj.Util.Win32.Enums.StringFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.BaseTypes.BOOL;

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
        public static extern CompareStringResults CompareString([In]LCID Locale, [In]StringFlags dwCmpFlags, [In]StringHandle lpString1,
            [In]int cchCount1, [In]StringHandle lpString2, [In]int cchCount2);

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
        public static extern int CompareStringOrdinal([In]StringHandle lpString1, [In]int cchCount1, [In]StringHandle lpString2,
            [In]int cchCount2, [In]BOOL bIgnoreCase);

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
        /// Use <see cref="GetNlsVersionEx"/> to discover if the sort version has changed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CompareStringEx", ExactSpelling = true, SetLastError = true)]
        public static extern CompareStringResults CompareStringEx([In]StringHandle lpLocaleName, [In]StringFlags dwCmpFlags,
            [In]StringHandle lpString1, [In]int cchCount1, [In]StringHandle lpString2, [In]int cchCount2, [In]in NLSVERSIONINFOEX lpVersionInformation,
            [In]LPVOID lpReserved, [In]LPARAM lParam);

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
        public static extern IntPtr lstrcat([MarshalAs(UnmanagedType.LPWStr)][In][Out]StringBuilder lpString1,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpString2);

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
        public static extern int lstrcmp([MarshalAs(UnmanagedType.LPWStr)][In]string lpString1, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString2);

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
        public static extern int lstrcmpi([MarshalAs(UnmanagedType.LPWStr)][In]string lpString1, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString2);

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
        public static extern IntPtr lstrcpy([MarshalAs(UnmanagedType.LPWStr)][In][Out]StringBuilder lpString1,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpString2);

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
        public static extern IntPtr lstrcpyn([MarshalAs(UnmanagedType.LPWStr)][In][Out]StringBuilder lpString1,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpString2, [In]int iMaxLength);

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
        public static extern int lstrlen([MarshalAs(UnmanagedType.LPWStr)][In]string lpString);
#pragma warning restore IDE1006
    }
}
