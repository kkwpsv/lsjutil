using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.LCID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CodePages;
using static Lsj.Util.Win32.Enums.FindStringFlags;
using static Lsj.Util.Win32.Enums.FormatMessageFlags;
using static Lsj.Util.Win32.Enums.IDNFlags;
using static Lsj.Util.Win32.Enums.LCIDFlags;
using static Lsj.Util.Win32.Enums.LCMapStringFlags;
using static Lsj.Util.Win32.Enums.LGRPIDFlags;
using static Lsj.Util.Win32.Enums.MUIFlags;
using static Lsj.Util.Win32.Enums.MUIQueryFlags;
using static Lsj.Util.Win32.Enums.StringFlags;
using static Lsj.Util.Win32.Enums.SYSNLS_FUNCTION;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// An application-defined callback function that processes enumerated geographical location information provided by the <see cref="EnumSystemGeoID"/> function.
        /// The <see cref="GEO_ENUMPROC"/> type defines a pointer to this callback function.
        /// EnumGeoInfoProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/dd317817(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="GeoId">
        /// Identifier of the geographical location to check.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> to continue enumeration or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// An EnumGeoInfoProc function can carry out any desired task.
        /// The application registers this function by passing its address to the <see cref="EnumSystemGeoID"/> function.
        /// </remarks>
        public delegate BOOL EnumGeoInfoProc([In] GEOID GeoId);

        /// <summary>
        /// <para>
        /// An application-defined callback function that processes enumerated locale information provided by the <see cref="EnumSystemLocales"/> function.
        /// The <see cref="LOCALE_ENUMPROC"/> type defines a pointer to this callback function.
        /// EnumLocalesProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/dd317822(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleString">
        /// Pointer to a buffer containing a null-terminated locale identifier string.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> to continue enumeration or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// An EnumLocalesProc function can carry out any desired task.
        /// The application registers this function by passing its address to the <see cref="EnumSystemLocales"/> function.
        /// </remarks>
        public delegate BOOL EnumLocalesProc([In] LPWSTR lpLocaleString);


        /// <summary>
        /// <para>
        /// Converts a default locale value to an actual locale identifier.
        /// Note
        /// This function is only provided for converting partial locale identifiers.
        /// Your applications should use locale names instead of identifiers.
        /// The <see cref="LCIDToLocaleName"/> function can be used to convert a locale identifier to a valid locale name.
        /// Your application can also use <see cref="GetUserDefaultLocaleName"/> to retrieve the current user locale name;
        /// <see cref="GetSystemDefaultLocaleName"/> to retrieve the current system locale name;
        /// and <see cref="GetLocaleInfoEx"/> with <see cref="LOCALE_SNAME"/> to retrieve the locale name for any input locale, including the default constants.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-convertdefaultlocale"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Default locale identifier value to convert.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// Windows Vista and later: The following custom locale identifiers are also supported.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </param>
        /// <returns>
        /// Returns the appropriate locale identifier if successful.
        /// This function returns the value of the Locale parameter if it does not succeed.
        /// The function fails when the Locale value is not one of the default values listed above.
        /// </returns>
        /// <remarks>
        /// A call to <see cref="ConvertDefaultLocale"/> specifying <see cref="LOCALE_SYSTEM_DEFAULT"/>
        /// is equivalent to a call to <see cref="GetSystemDefaultLCID"/>.
        /// A call to <see cref="ConvertDefaultLocale"/> specifying <see cref="LOCALE_USER_DEFAULT"/>
        /// is equivalent to a call to <see cref="GetUserDefaultLCID"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertDefaultLocale", ExactSpelling = true, SetLastError = true)]
        public static extern LCID ConvertDefaultLocale([In] LCID Locale);

        /// <summary>
        /// <para>
        /// Enumerates the geographical location identifiers (type GEOID) that are available on the operating system.
        /// <see cref="EnumSystemGeoID"/> is available for use in the operating systems specified in the Requirements section.
        /// It may be altered or unavailable in subsequent versions.
        /// Instead, use <see cref="EnumSystemGeoNames"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-enumsystemgeoid"/>
        /// </para>
        /// </summary>
        /// <param name="GeoClass">
        /// Geographical location class for which to enumerate the identifiers.
        /// At present, only <see cref="GEOCLASS_NATION"/> is supported.
        /// This type causes the function to enumerate all geographical identifiers for nations on the operating system.
        /// </param>
        /// <param name="ParentGeoId">
        /// Reserved.
        /// This parameter must be 0.
        /// </param>
        /// <param name="lpGeoEnumProc">
        /// Pointer to the application-defined callback function EnumGeoInfoProc.
        /// The <see cref="EnumSystemGeoID"/> function makes repeated calls to this callback function until it returns <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumSystemGeoID", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumSystemGeoID([In] GEOCLASS GeoClass, [In] GEOID ParentGeoId, [In] GEO_ENUMPROC lpGeoEnumProc);

        /// <summary>
        /// <para>
        /// Enumerates the locales that are either installed on or supported by an operating system.
        /// Note
        /// For interoperability reasons, the application should prefer the <see cref="EnumSystemLocalesEx"/> function to <see cref="EnumSystemLocales"/>
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// Any application that will be run only on Windows Vista and later should use <see cref="EnumSystemLocalesEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-enumsystemlocalesw"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleEnumProc">
        /// Pointer to an application-defined callback function.
        /// For more information, see EnumLocalesProc.
        /// </param>
        /// <param name="dwFlags">
        /// Flags specifying the locale identifiers to enumerate.
        /// The flags can be used singly or combined using a binary OR.
        /// If the application specifies 0 for this parameter, the function behaves as for <see cref="LCID_SUPPORTED"/>.
        /// <see cref="LCID_INSTALLED"/>:
        /// Enumerate only installed locale identifiers.
        /// This value cannot be used with <see cref="LCID_SUPPORTED"/>.
        /// <see cref="LCID_SUPPORTED"/>:
        /// Enumerate all supported locale identifiers.
        /// This value cannot be used with <see cref="LCID_INSTALLED"/>.
        /// <see cref="LCID_ALTERNATE_SORTS"/>:
        /// Enumerate only the alternate sort locale identifiers.
        /// If this value is used with either <see cref="LCID_INSTALLED"/> or <see cref="LCID_SUPPORTED"/>,
        /// the installed or supported locales are retrieved, as well as the alternate sort locale identifiers.
        /// </param>
        /// <returns>
        /// Returns a <see cref="TRUE"/> value if successful, or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_BADDB"/>:
        /// The function could not access the data.
        /// This situation should not normally occur, and typically indicates a bad installation, a disk problem, or the like.
        /// <see cref="ERROR_INVALID_FLAGS"/>:
        /// The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>:
        /// Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// The function enumerates locales by passing locale identifiers, one at a time, to the specified application-defined callback function.
        /// This continues until all of the installed or supported locale identifiers
        /// have been passed to the callback function or the callback function returns <see cref="FALSE"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumSystemLocalesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumSystemLocales([In] LOCALE_ENUMPROC lpLocaleEnumProc, [In] LCIDFlags dwFlags);

        /// <summary>
        /// <para>
        /// Locates a Unicode string (wide characters) or its equivalent in another Unicode string for a locale specified by identifier.
        /// Caution
        /// Because strings with very different binary representations can compare as identical, this function can raise certain security concerns.
        /// For more information, see the discussion of comparison functions in Security Considerations: International Features.
        /// Note
        /// For interoperability reasons, the application should prefer the <see cref="FindNLSStringEx"/> function
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// Although <see cref="FindNLSString"/> supports custom locales, most applications should use <see cref="FindNLSStringEx"/> for this type of support.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-findnlsstring"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier that specifies the locale.
        /// You can use the <see cref="MAKELCID"/> macro to create an identifier or use one of the following predefined values.
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// Windows Vista and later: The following custom locale identifiers are also supported.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </param>
        /// <param name="dwFindNLSStringFlags">
        /// Flags specifying details of the find operation.
        /// For detailed definitions, see the dwFindNLSStringFlags parameter of <see cref="dwFindNLSStringFlags"/>.
        /// </param>
        /// <param name="lpStringSource">
        /// Pointer to the source string, in which the function searches for the string specified by <paramref name="lpStringValue"/>.
        /// </param>
        /// <param name="cchSource">
        /// Size, in characters excluding the terminating null character, of the string indicated by <paramref name="lpStringSource"/>.
        /// The application cannot specify 0 or any negative number other than -1 for this parameter.
        /// The application specifies -1 if the source string is null-terminated and the function should calculate the size automatically.
        /// </param>
        /// <param name="lpStringValue">
        /// Pointer to the search string, for which the function searches in the source string.
        /// </param>
        /// <param name="cchValue">
        /// Size, in characters excluding the terminating null character, of the string indicated by <paramref name="lpStringValue"/>.
        /// The application cannot specify 0 or any negative number other than -1 for this parameter.
        /// The application specifies -1 if the search string is null-terminated and the function should calculate the size automatically.
        /// </param>
        /// <param name="pcchFound">
        /// Pointer to a buffer containing the length of the string that the function finds.
        /// For details, see the pcchFound parameter of <see cref="FindNLSStringEx"/>.
        /// </param>
        /// <returns>
        /// Returns a 0-based index into the source string indicated by <paramref name="lpStringSource"/> if successful.
        /// In combination with the value in <paramref name="pcchFound"/>, this index provides the exact location of the entire found string in the source string.
        /// A return value of 0 is an error-free index into the source string, and the matching string is in the source string at offset 0.
        /// The function returns -1 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_FLAGS"/>: The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: Any of the parameter values was invalid.
        /// <see cref="ERROR_SUCCESS"/>: The action completed successfully but yielded no results.
        /// </returns>
        /// <remarks>
        /// See Remarks for <see cref="FindNLSStringEx"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNLSString", ExactSpelling = true, SetLastError = true)]
        public static extern int FindNLSString([In] LCID Locale, [In] DWORD dwFindNLSStringFlags, [In] LPCWSTR lpStringSource,
            [In] int cchSource, [In] LPCWSTR lpStringValue, [In] int cchValue, [Out] out INT pcchFound);

        /// <summary>
        /// <para>
        /// Locates a Unicode string (wide characters) or its equivalent in another Unicode string for a locale specified by name.
        /// Caution
        /// Because strings with very different binary representations can compare as identical, this function can raise certain security concerns.
        /// For more information, see the discussion of comparison functions in Security Considerations: International Features.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-findnlsstringex"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleName">
        /// Pointer to a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>, <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>, <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="dwFindNLSStringFlags">
        /// Flags specifying details of the find operation.
        /// These flags are mutually exclusive, with <see cref="FIND_FROMSTART"/> being the default.
        /// The application can specify just one of the find flags with any of the filtering flags defined in the next table.
        /// If the application does not specify a flag, the function uses the default comparison for the specified locale.
        /// As discussed in Handling Sorting in Your Applications, there is no binary comparison mode.
        /// <see cref="FIND_FROMSTART"/>:
        /// Search the string, starting with the first character of the string.
        /// <see cref="FIND_FROMEND"/>:
        /// Search the string in the reverse direction, starting with the last character of the string.
        /// <see cref="FIND_STARTSWITH"/>:
        /// Test to find out if the value specified by <paramref name="lpStringValue"/> is the first value in the source string indicated by <paramref name="lpStringSource"/>.
        /// <see cref="FIND_ENDSWITH"/>:
        /// Test to find out if the value specified by <paramref name="lpStringValue"/> is the last value in the source string indicated by <paramref name="lpStringSource"/>.
        /// The application can use the filtering flags defined below in combination with a find flag.
        /// <see cref="LINGUISTIC_IGNORECASE"/>:
        /// Ignore case in the search, as linguistically appropriate. For more information, see the Remarks section.
        /// <see cref="LINGUISTIC_IGNOREDIACRITIC"/>:
        /// Ignore diacritics, as linguistically appropriate.
        /// For more information, see the Remarks section.
        /// Note
        /// This flag does not always produce predictable results when used with decomposed characters,
        /// that is, characters in which a base character and one or more nonspacing characters each have distinct code point values.
        /// <see cref="NORM_IGNORECASE"/>:
        /// Ignore case in the search. For more information, see the Remarks section.
        /// <see cref="NORM_IGNOREKANATYPE"/>:
        /// Do not differentiate between hiragana and katakana characters.
        /// Corresponding hiragana and katakana characters compare as equal.
        /// <see cref="NORM_IGNORENONSPACE"/>:
        /// Ignore nonspacing characters. For more information, see the Remarks section.
        /// <see cref="NORM_IGNORESYMBOLS"/>:
        /// Ignore symbols and punctuation.
        /// <see cref="NORM_IGNOREWIDTH"/>:
        /// Ignore the difference between half-width and full-width characters, for example, C a t == cat.
        /// The full-width form is a formatting distinction used in Chinese and Japanese scripts.
        /// <see cref="NORM_LINGUISTIC_CASING"/>:
        /// Use linguistic rules for casing, instead of file system rules (default).
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="lpStringSource">
        /// Pointer to the source string, in which the function searches for the string specified by <paramref name="lpStringValue"/>.
        /// </param>
        /// <param name="cchSource">
        /// Size, in characters excluding the terminating null character, of the string indicated by <paramref name="lpStringSource"/>.
        /// The application cannot specify 0 or any negative number other than -1 for this parameter.
        /// The application specifies -1 if the source string is null-terminated and the function should calculate the size automatically.
        /// </param>
        /// <param name="lpStringValue">
        /// Pointer to the search string, for which the function searches in the source string.
        /// </param>
        /// <param name="cchValue">
        /// Size, in characters excluding the terminating null character, of the string indicated by <paramref name="lpStringValue"/>.
        /// The application cannot specify 0 or any negative number other than -1 for this parameter.
        /// The application specifies -1 if the search string is null-terminated and the function should calculate the size automatically.
        /// </param>
        /// <param name="pcchFound">
        /// Pointer to a buffer containing the length of the string that the function finds.
        /// The string can be either longer or shorter than the search string.
        /// If the function fails to find the search string, this parameter is not modified.
        /// The function can retrieve NULL in this parameter.
        /// In this case, the function makes no indication if the length of the found string differs from the length of the source string.
        /// Note that the value of pcchFound is often identical to the value provided in <paramref name="cchValue"/>, but can differ in the following cases:
        /// The value provided in <paramref name="cchValue"/> is negative.
        /// The strings are equivalent, but have different lengths.
        /// For example, "A" plus "Combining Ring" (U+0041 U+030A) is equivalent to the "A Ring" (U+00c5).
        /// </param>
        /// <param name="lpVersionInformation">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpReserved">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <param name="sortHandle">
        /// Reserved; must be 0.
        /// </param>
        /// <returns>
        /// Returns a 0-based index into the source string indicated by <paramref name="lpStringSource"/> if successful.
        /// In combination with the value in <paramref name="pcchFound"/>, this index provides the exact location of the entire found string in the source string.
        /// A return value of 0 is an error-free index into the source string, and the matching string is in the source string at offset 0.
        /// The function returns -1 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_FLAGS"/>: The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: Any of the parameter values was invalid.
        /// <see cref="ERROR_SUCCESS"/>: The action completed successfully but yielded no results.
        /// </returns>
        /// <remarks>
        /// This function provides a variety of search options, including search direction, character equivalence filtering, and locale-specific filtering.
        /// Note that equivalence depends on the locale and flags specified in the call to the function.
        /// The filtering flags can alter the results of the search.
        /// For example, the potential matches increase when the function ignores case or diacritic marks when performing the search.
        /// By default, this function maps the lowercase "i" to the uppercase "I", even when the Locale parameter specifies Turkish (Turkey) or Azerbaijani (Azerbaijan).
        /// To override this behavior for Turkish or Azerbaijani, the application should specify <see cref="NORM_LINGUISTIC_CASING"/>.
        /// If this flag is specified for the correct locale, "ı" (lowercase dotless I) is the lowercase form of "I" (uppercase dotless I)
        /// and "i" (lowercase dotted I) is the lowercase form of "ı" (uppercase dotted I).
        /// For many scripts (notably Latin scripts), <see cref="NORM_IGNORENONSPACE"/> coincides with <see cref="LINGUISTIC_IGNOREDIACRITIC"/>
        /// and <see cref="NORM_IGNORECASE"/> coincides with <see cref="LINGUISTIC_IGNORECASE"/>, with the following exceptions:
        /// <see cref="NORM_IGNORENONSPACE"/> ignores any secondary distinction, whether or not it is a diacritic.
        /// Scripts for Korean, Japanese, Chinese, Indic languages, and others use this distinction for purposes other than diacritics.
        /// <see cref="LINGUISTIC_IGNOREDIACRITIC"/> ignores only actual diacritics, instead of simply ignoring the second sorting weight.
        /// <see cref="NORM_IGNORECASE"/> ignores any tertiary distinction, whether or not it is actually linguistic case.
        /// For example, in Arabic and Indic scripts, this flag distinguishes alternate forms of a character.
        /// However, the differences do not correspond to linguistic case.
        /// <see cref="LINGUISTIC_IGNORECASE"/> ignores only actual linguistic casing, instead of ignoring the third sorting weight.
        /// In contrast to other NLS API functions, which return 0 for failure, this function returns -1 if it fails.
        /// On success, it returns a 0-based index.
        /// Use of this index helps the function avoid off-by-one errors and one-character buffer overruns.
        /// This function is one of the few NLS functions that calls SetLastError even when it succeeds.
        /// It makes this call to clear the last error in a thread when it fails to match the search string.
        /// This clears the value returned by <see cref="GetLastError"/>.
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNLSStringEx", ExactSpelling = true, SetLastError = true)]
        public static extern int FindNLSStringEx([In] LPCWSTR lpLocaleName, [In] DWORD dwFindNLSStringFlags, [In] LPCWSTR lpStringSource,
            [In] int cchSource, [In] LPCWSTR lpStringValue, [In] int cchValue, [Out] out INT pcchFound, [In] IntPtr lpVersionInformation,
            [In] LPVOID lpReserved, [In] LPARAM sortHandle);

        /// <summary>
        /// <para>
        /// Formats a message string. The function requires a message definition as input. 
        /// The message definition can come from a buffer passed into the function.
        /// It can come from a message table resource in an already-loaded module.
        /// Or the caller can ask the function to search the system's message table resource(s) for the message definition.
        /// The function finds the message definition in a message table resource based on a message identifier and a language identifier.
        /// The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-formatmessagew"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// The formatting options, and how to interpret the lpSource parameter. 
        /// The low-order byte of <paramref name="dwFlags"/> specifies how the function handles line breaks in the output buffer.
        /// The low-order byte can also specify the maximum width of a formatted output line.
        /// If the low-order byte is a nonzero value other than <see cref="FORMAT_MESSAGE_MAX_WIDTH_MASK"/>,
        /// it specifies the maximum number of characters in an output line. 
        /// The function ignores regular line breaks in the message definition text. 
        /// The function never splits a string delimited by white space across a line break. 
        /// The function stores hard-coded line breaks in the message definition text into the output buffer. 
        /// Hard-coded line breaks are coded with the %n escape sequence.
        /// </param>
        /// <param name="lpSource">
        /// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="dwFlags"/> parameter.
        /// <see cref="FORMAT_MESSAGE_FROM_HMODULE"/>: A handle to the module that contains the message table to search.
        /// <see cref="FORMAT_MESSAGE_FROM_STRING"/>: Pointer to a string that consists of unformatted message text.
        /// It will be scanned for inserts and formatted accordingly.
        /// </param>
        /// <param name="dwMessageId">
        /// The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
        /// </param>
        /// <param name="dwLanguageId">
        /// The language identifier for the requested message. 
        /// This parameter is ignored if dwFlags includes <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
        /// If you pass a specific LANGID in this parameter, <see cref="FormatMessage"/> will return a message for that LANGID only.
        /// If the function cannot find a message for that LANGID, it sets Last-Error to <see cref="ERROR_RESOURCE_LANG_NOT_FOUND"/>.
        /// If you pass in zero, <see cref="FormatMessage"/> looks for a message for LANGIDs in the following order:
        /// Language neutral
        /// Thread LANGID, based on the thread's locale value
        /// User default LANGID, based on the user's default locale value
        /// System default LANGID, based on the system default locale value
        /// US English
        /// If <see cref="FormatMessage"/> does not locate a message for any of the preceding LANGIDs, 
        /// it returns any language message string that is present.
        /// If that fails, it returns <see cref="ERROR_RESOURCE_LANG_NOT_FOUND"/>.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. 
        /// If <paramref name="dwFlags"/>"/> includes <see cref="FORMAT_MESSAGE_ALLOCATE_BUFFER"/>, the function allocates a buffer 
        /// using the <see cref="LocalAlloc"/> function, and places the pointer to the buffer at the address specified in <paramref name="lpBuffer"/>.
        /// This buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="nSize">
        /// If the <see cref="FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is not set, 
        /// this parameter specifies the size of the output buffer, in TCHARs. 
        /// If <see cref="FORMAT_MESSAGE_ALLOCATE_BUFFER"/> is set, 
        /// this parameter specifies the minimum number of TCHARs to allocate for an output buffer.
        /// The output buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="Arguments">
        /// An array of values that are used as insert values in the formatted message. 
        /// A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second argument; and so on.
        /// The interpretation of each value depends on the formatting information associated with the insert in the message definition.
        /// The default is to treat each value as a pointer to a null-terminated string.
        /// By default, the Arguments parameter is of type va_list*, which is a language- and implementation-specific data type 
        /// for describing a variable number of arguments. The state of the va_list argument is undefined upon return from the function.
        /// To use the va_list again, destroy the variable argument list pointer using va_end and reinitialize it with va_start.
        /// If you do not have a pointer of type va_list*, then specify the <see cref="FORMAT_MESSAGE_ARGUMENT_ARRAY"/> flag
        /// and pass a pointer to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.
        /// Each insert must have a corresponding element in the array.
        /// </param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FormatMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD FormatMessage([In] FormatMessageFlags dwFlags, [In] LPCVOID lpSource, [In] DWORD dwMessageId,
            [In] DWORD dwLanguageId, [In] IntPtr lpBuffer, [In] DWORD nSize, [In] IntPtr Arguments);

        /// <summary>
        /// <para>
        /// Retrieves the current Windows ANSI code page identifier for the operating system.
        /// Caution
        /// The ANSI API functions, for example, the ANSI version of <see cref="TextOut"/>,
        /// implicitly use <see cref="GetACP"/> to translate text to or from Unicode.
        /// For the Multilingual User Interface (MUI) edition of Windows,
        /// the system ACP might not cover all code points in the user's selected logon language identifier.
        /// For compatibility with this edition, your application should avoid calls that depend on <see cref="GetACP"/> either implicitly or explicitly,
        /// as this function can cause some locales to display text as question marks.
        /// Instead, the application should use the Unicode API functions directly, for example, the Unicode version of <see cref="TextOut"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getacp"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the current Windows ANSI code page (ACP) identifier for the operating system.
        /// See Code Page Identifiers for a list of identifiers for Windows ANSI code pages and other code pages.
        /// </returns>
        /// <remarks>
        /// The ANSI code pages can be different on different computers, or can be changed for a single computer, leading to data corruption.
        /// For the most consistent results, applications should use UTF-8 or UTF-16 when possible.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetACP", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetACP();

        /// <summary>
        /// <para>
        /// Retrieves information about a calendar for a locale specified by identifier.
        /// Note
        /// For interoperability reasons, the application should prefer the <see cref="GetCalendarInfoEx"/> function to <see cref="GetCalendarInfo"/>
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// Any application that runs only on Windows Vista and later should use <see cref="GetCalendarInfoEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getcalendarinfow"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier that specifies the locale for which to retrieve calendar information.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>,
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// </param>
        /// <param name="Calendar">
        /// Calendar identifier.
        /// </param>
        /// <param name="CalType">
        /// Type of information to retrieve. 
        /// For more information, see Calendar Type Information.
        /// Note
        /// <see cref="GetCalendarInfo"/> returns only one string if this parameter specifies <see cref="CAL_IYEAROFFSETRANGE"/> or <see cref="CAL_SERASTRING"/>.
        /// In both cases the current era is returned.
        /// <see cref="CAL_USE_CP_ACP"/> is relevant only for the ANSI version of this function.
        /// For <see cref="CAL_NOUSEROVERRIDE"/>, the function ignores any value set by <see cref="SetCalendarInfo"/>
        /// and uses the database settings for the current system default locale.
        /// This type is relevant only in the combination <code>CAL_NOUSEROVERRIDE | CAL_ITWODIGITYEARMAX</code>.
        /// <see cref="CAL_ITWODIGITYEARMAX"/> is the only value that can be set by <see cref="SetCalendarInfo"/>.
        /// </param>
        /// <param name="lpCalData">
        /// Pointer to a buffer in which this function retrieves the requested data as a string.
        /// If <see cref="CAL_RETURN_NUMBER"/> is specified in <paramref name="CalType"/>, this parameter must retrieve <see cref="NULL"/>.
        /// </param>
        /// <param name="cchData">
        /// Size, in characters, of the <paramref name="lpCalData"/> buffer.
        /// The application can set this parameter to 0 to return the required size for the calendar data buffer.
        /// In this case, the <paramref name="lpCalData"/> parameter is not used.
        /// If <see cref="CAL_RETURN_NUMBER"/> is specified for <paramref name="CalType"/>, the value of <paramref name="cchData"/> must be 0.
        /// </param>
        /// <param name="lpValue">
        /// Pointer to a variable that receives the requested data as a number.
        /// If <see cref="CAL_RETURN_NUMBER"/> is specified in <paramref name="CalType"/>, then <paramref name="lpValue"/> must not be <see cref="NULL"/>.
        /// If <see cref="CAL_RETURN_NUMBER"/> is not specified in <paramref name="CalType"/>, then <paramref name="lpValue"/> must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// Returns the number of characters retrieved in the <paramref name="lpCalData"/> buffer,
        /// with <paramref name="cchData"/> set to a nonzero value, if successful. 
        /// If the function succeeds, <paramref name="cchData"/> is set to 0, and <see cref="CAL_RETURN_NUMBER"/> is not specified,
        /// the return value is the size of the buffer required to hold the calendar information.
        /// If the function succeeds, <paramref name="cchData"/> is set 0, and <see cref="CAL_RETURN_NUMBER"/> is specified,
        /// the return value is the size of the value retrieved in <paramref name="lpValue"/>,
        /// that is, 2 for the Unicode version of the function or 4 for the ANSI version.
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// Note
        /// This API is being updated to support the May 2019 Japanese era change.
        /// If your application supports the Japanese calendar, you should validate that it properly handles the new era.
        /// See Prepare your application for the Japanese era change for more information.
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the function can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark (?).
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCalendarInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetCalendarInfo([In] LCID Locale, [In] CALID Calendar, [In] CALTYPE CalType,
            [In] LPWSTR lpCalData, [In] int cchData, [Out] out DWORD lpValue);

        /// <summary>
        /// <para>
        /// Retrieves information about a calendar for a locale specified by name.
        /// Note
        /// The application should call this function in preference to <see cref="GetCalendarInfo"/> if designed to run only on Windows Vista and later.
        /// Note
        /// This function can retrieve data that changes between releases, for example, due to a custom locale.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getcalendarinfoex"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleName">
        /// Pointer to a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>, <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>, <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="Calendar">
        /// Calendar identifier.
        /// </param>
        /// <param name="lpReserved">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <param name="CalType">
        /// Type of information to retrieve. 
        /// For more information, see Calendar Type Information.
        /// Note
        /// <see cref="GetCalendarInfoEx "/> returns only one string if this parameter specifies <see cref="CAL_IYEAROFFSETRANGE"/> or <see cref="CAL_SERASTRING"/>.
        /// In both cases the current era is returned.
        /// For <see cref="CAL_NOUSEROVERRIDE"/>, the function ignores any value set by <see cref="SetCalendarInfo"/>
        /// and uses the database settings for the current system default locale.
        /// This type is relevant only in the combination <code>CAL_NOUSEROVERRIDE | CAL_ITWODIGITYEARMAX</code>.
        /// <see cref="CAL_ITWODIGITYEARMAX"/> is the only value that can be set by <see cref="SetCalendarInfo"/>.
        /// </param>
        /// <param name="lpCalData">
        /// Pointer to a buffer in which this function retrieves the requested data as a string.
        /// If <see cref="CAL_RETURN_NUMBER"/> is specified in <paramref name="CalType"/>, this parameter must retrieve <see cref="NULL"/>.
        /// </param>
        /// <param name="cchData">
        /// Size, in characters, of the <paramref name="lpCalData"/> buffer.
        /// The application can set this parameter to 0 to return the required size for the calendar data buffer.
        /// In this case, the <paramref name="lpCalData"/> parameter is not used.
        /// If <see cref="CAL_RETURN_NUMBER"/> is specified for <paramref name="CalType"/>, the value of <paramref name="cchData"/> must be 0.
        /// </param>
        /// <param name="lpValue">
        /// Pointer to a variable that receives the requested data as a number.
        /// If <see cref="CAL_RETURN_NUMBER"/> is specified in <paramref name="CalType"/>, then <paramref name="lpValue"/> must not be <see cref="NULL"/>.
        /// If <see cref="CAL_RETURN_NUMBER"/> is not specified in <paramref name="CalType"/>, then <paramref name="lpValue"/> must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// Returns the number of characters retrieved in the <paramref name="lpCalData"/> buffer,
        /// with <paramref name="cchData"/> set to a nonzero value, if successful. 
        /// If the function succeeds, <paramref name="cchData"/> is set to 0, and <see cref="CAL_RETURN_NUMBER"/> is not specified,
        /// the return value is the size of the buffer required to hold the calendar information.
        /// If the function succeeds, <paramref name="cchData"/> is set 0, and <see cref="CAL_RETURN_NUMBER"/> is specified,
        /// the return value is the size of the value retrieved in <paramref name="lpValue"/>.
        /// This size is always 2.
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// Note
        /// This API is being updated to support the May 2019 Japanese era change.
        /// If your application supports the Japanese calendar, you should validate that it properly handles the new era.
        /// See Prepare your application for the Japanese era change for more information.
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCalendarInfoEx", ExactSpelling = true, SetLastError = true)]
        public static extern int GetCalendarInfoEx([In] LPCWSTR lpLocaleName, [In] CALID Calendar, [In] LPCWSTR lpReserved, [In] CALTYPE CalType,
            [In] LPWSTR lpCalData, [In] int cchData, [Out] out DWORD lpValue);

        /// <summary>
        /// <para>
        /// Retrieves information about any valid installed or available code page.
        /// Note
        /// To obtain additional information about valid installed or available code pages, the application should use <see cref="GetCPInfoEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getcpinfo"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// Identifier for the code page for which to retrieve information.
        /// For details, see the CodePage parameter of <see cref="GetCPInfoEx"/>.
        /// </param>
        /// <param name="lpCPInfo">
        /// Pointer to a <see cref="CPINFO"/> structure that receives information about the code page.
        /// See the Remarks section.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/>0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// See Remarks for <see cref="GetCPInfoEx"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCPInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCPInfo([In] CodePages CodePage, [Out] out CPINFO lpCPInfo);

        /// <summary>
        /// <para>
        /// Retrieves information about any valid installed or available code page.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getcpinfoexw"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// Identifier for the code page for which to retrieve information.
        /// The application can specify the code page identifier for any installed or available code page, or one of the following predefined values.
        /// See Code Page Identifiers for a list of identifiers for ANSI and other code pages.
        /// <see cref="CP_ACP"/>: Use the system default Windows ANSI code page.
        /// <see cref="CP_MACCP"/>: Use the system default Macintosh code page.
        /// <see cref="CP_OEMCP"/>: Use the system default OEM code page.
        /// <see cref="CP_THREAD_ACP"/>: Use the current thread's ANSI code page.
        /// </param>
        /// <param name="dwFlags">
        /// Reserved; must be 0.
        /// </param>
        /// <param name="lpCPInfoEx">
        /// Pointer to a <see cref="CPINFOEX"/> structure that receives information about the code page.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_PARAMETER"/>: Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// The information retrieved in the <see cref="CPINFOEX"/> structure is not always useful for all code pages.
        /// To determine buffer sizes, for example, the application should call <see cref="MultiByteToWideChar"/>
        /// or <see cref="WideCharToMultiByte"/> to request an accurate buffer size.
        /// If <see cref="CPINFOEX"/> settings indicate that a lead byte exists,
        /// the conversion function does not necessarily handle lead bytes differently,
        /// for example, in the case of a missing or illegal trail byte.
        /// Note
        /// The winnls.h header defines <see cref="GetCPInfoEx"/> as an alias which automatically
        /// selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCPInfoExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCPInfoEx([In] CodePages CodePage, [In] DWORD dwFlags, [Out] out CPINFOEX lpCPInfoEx);

        /// <summary>
        /// <para>
        /// Retrieves resource-related information about a file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getfilemuiinfo"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags specifying the information to retrieve. Any combination of the following flags is allowed.
        /// The default value of the flags is <code>MUI_QUERY_TYPE | MUI_QUERY_CHECKSUM</code>.
        /// <see cref="MUI_QUERY_TYPE"/>:
        /// Retrieve one of the following values in the <see cref="FILEMUIINFO.dwFileType"/> member of <see cref="FILEMUIINFO"/>:
        /// <see cref="MUI_FILETYPE_NOT_LANGUAGE_NEUTRAL"/>:
        /// The specified input file does not have resource configuration data.
        /// Thus it is neither an LN file nor a language-specific resource file.
        /// This type of file is typical for older executable files.
        /// If this file type is specified, the function will not retrieve useful information for the other types.
        /// <see cref="MUI_FILETYPE_LANGUAGE_NEUTRAL_MAIN"/>:
        /// The input file is an LN file.
        /// <see cref="MUI_FILETYPE_LANGUAGE_NEUTRAL_MUI"/>:
        /// The input file is a language-specific resource file associated with an LN file.
        /// <see cref="MUI_QUERY_CHECKSUM"/>:
        /// Retrieve the resource checksum of the input file in the <see cref="FILEMUIINFO.pChecksum"/> member of <see cref="FILEMUIINFO"/>.
        /// If the input file does not have resource configuration data, this member of the structure contains 0.
        /// <see cref="MUI_QUERY_LANGUAGE_NAME"/>：
        /// Retrieve the language associated with the input file.
        /// For a language-specific resource file, this flag requests the associated language.
        /// For an LN file, this flag requests the language of the ultimate fallback resources for the module,
        /// which can be either in the LN file or in a separate language-specific resource file referenced by the resource configuration data of the LN file.
        /// For more information, see the Remarks section.
        /// <see cref="MUI_QUERY_RESOURCE_TYPES"/>:
        /// Retrieve lists of resource types in the language-specific resource files and LN files as they are specified in the resource configuration data.
        /// See the Remarks section for a way to access this information.
        /// </param>
        /// <param name="pcwszFilePath">
        /// Pointer to a null-terminated string indicating the path to the file.
        /// Typically the file is either an LN file or a language-specific resource file.
        /// If it is not one of these types, the only significant value that the function retrieves is <see cref="MUI_FILETYPE_NOT_LANGUAGE_NEUTRAL"/>.
        /// The function only retrieves this value if the <see cref="MUI_QUERY_RESOURCE_TYPES"/> flag is set.
        /// </param>
        /// <param name="pFileMUIInfo">
        /// Pointer to a buffer containing file information in a <see cref="FILEMUIINFO"/> structure and possibly in data following that structure.
        /// The information buffer might have to be much larger than the size of the structure itself.
        /// Depending on flag settings, the function can store considerable information following the structure, at offsets retrieved in the structure.
        /// For more information, see the Remarks section.
        /// Alternatively, the application can set this parameter to <see cref="NullRef{FILEMUIINFO}"/>
        /// if <paramref name="pcbFileMUIInfo"/> is set to 0.
        /// In this case, the function retrieves the required size for the information buffer in <paramref name="pcbFileMUIInfo"/>.
        /// Note
        /// If the value of <paramref name="pFileMUIInfo"/> is not <see cref="NullRef{FILEMUIINFO}"/>,
        /// the <see cref="FILEMUIINFO.dwSize"/> member must be set to the size of the <see cref="FILEMUIINFO"/> structure (including the information buffer),
        /// and the <see cref="FILEMUIINFO.dwVersion"/> member must be set to the current version of 0x001.
        /// </param>
        /// <param name="pcbFileMUIInfo">
        /// Pointer to the buffer size, in bytes, for the file information indicated by <paramref name="pFileMUIInfo"/>.
        /// On successful return from the function, this parameter contains the size of the retrieved file information buffer
        /// and the <see cref="FILEMUIINFO"/> structure that contains it.
        /// Alternatively, the application can set this parameter to 0 if it sets <see cref="NullRef{FILEMUIINFO}"/> in <paramref name="pFileMUIInfo"/>.
        /// In this case, the function retrieves the required file information buffer size in <paramref name="pcbFileMUIInfo"/>.
        /// To allocate the correct amount of memory, this value should be added to the size of the <see cref="FILEMUIINFO"/> structure itself.
        /// Note
        /// The value of this parameter must match the value of the <see cref="FILEMUIINFO.dwSize"/> member of <see cref="FILEMUIINFO"/>
        /// if the value of <paramref name="pFileMUIInfo"/> is not <see cref="NullRef{FILEMUIINFO}"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For the <see cref="MUI_QUERY_LANGUAGE_NAME"/> flag, this function retrieves an offset, in bytes,
        /// from the beginning of <see cref="FILEMUIINFO"/> in the <see cref="FILEMUIINFO.dwLanguageNameOffset"/> member.
        /// The following is sample code that accesses the language name associated with the input file:
        /// <code>
        /// LPWSTR lpszLang = reinterpret_cast&lt;LPWSTR&gt;(
        ///     reinterpret_cast&lt;BYTE*&gt;(pFileMUIInfo) +
        ///     pFileMUIInfo->dwLanguageNameOffset);
        /// </code>
        /// For the <see cref="MUI_QUERY_RESOURCE_TYPES"/> flag,
        /// this function retrieves language-specific resource file information in the following <see cref="FILEMUIINFO"/> members:
        /// The <see cref="FILEMUIINFO.dwTypeIDMUIOffset"/> member contains the offset
        /// to an array of identifiers of resources contained in the language-specific resource file.
        /// The <see cref="FILEMUIINFO.dwTypeIDMUISize"/> member contains
        /// the size of the array of resource identifiers for the language-specific resource file.
        /// The <see cref="FILEMUIINFO.dwTypeNameMUIOffset"/> member contains
        /// the offset to an array of names of resources contained in the language-specific resource file.
        /// If the input file is an LN file, the function fills in all the above structure members.
        /// In addition, it fills in the following members:
        /// The <see cref="FILEMUIINFO.dwTypeIDMainOffset"/> member contains the offset to an array of identifiers of resources contained in the LN file.
        /// The <see cref="FILEMUIINFO.dwTypeIDMainSize"/> member contains the size of the array of resource identifiers for the LN file.
        /// The <see cref="FILEMUIINFO.dwTypeNameMainOffset"/> member contains the offset to an array of names of resources contained in the file.
        /// The following is sample code that accesses the array of resource identifiers in the LN file.
        /// <code>
        /// DWORD *pdwTypeID = reinterpret_cast&lt;DWORD *&gt;(
        ///     reinterpret_cast&lt;BYTE*&gt;(pFileMUIInfo) +
        ///     pFileMUIInfo-&lt;dwTypeIDMainOffset);
        /// </code>
        /// Note
        /// The lists of language-specific resources are accessed in the same way.
        /// The following is sample code to access the multistring array of resource names in the LN file.
        /// <code>
        /// LPWSTR lpszNames = reinterpret_cast&lt;LPWSTR&gt;(
        ///     reinterpret_cast&lt;BYTE*&gt;(pFileMUIInfo) +
        ///     pFileMUIInfo-&lt;dwTypeNameMainOffset);
        /// </code>
        /// Note
        /// The lists of language-specific resources are accessed in the same way.
        /// Each of the code samples uses two reinterpret casts.
        /// First the code casts to BYTE* so that the pointer arithmetic for the offset is done in bytes.
        /// Then the code casts the resulting pointer to the desired type
        /// Another approach is to write the following instead of the code shown in the samples.
        /// The effect is the same and the choice is strictly one of style.
        /// <code>
        /// DWORD ix = pFileMUIInfo-&gt;dwLanguageNameOffset - 
        ///     offsetof(struct _FILEMUIINFO, abBuffer);
        /// LPWSTR lpszLang = reinterpret_cast&lt;LPWSTR&gt;(&amp;(pFileMUIInfo-&gt;abBuffer[ix]));
        /// </code>
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileMUIInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetFileMUIInfo([In] MUIQueryFlags dwFlags, [In] LPCWSTR pcwszFilePath,
            [In][Out] ref FILEMUIINFO pFileMUIInfo, [In][Out] ref DWORD pcbFileMUIInfo);

        /// <summary>
        /// <para>
        /// Retrieves the path to all language-specific resource files associated with the supplied LN file.
        /// The application must call this function repeatedly to get the path for each resource file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getfilemuipath"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags identifying language format and filtering.
        /// The following flags specify the format of the language indicated by <paramref name="pwszLanguage"/>.
        /// The flags are mutually exclusive, and the default is <see cref="MUI_LANGUAGE_NAME"/>.
        /// <see cref="MUI_LANGUAGE_ID"/>: Retrieve the language string in language identifier format.
        /// <see cref="MUI_LANGUAGE_NAME"/>: etrieve the language string in language name format.
        /// The following flags specify the filtering for the function to use in locating language-specific resource files
        /// if <paramref name="pwszLanguage"/> is set to <see cref="NULL"/>.
        /// The filtering flags are mutually exclusive, and the default is <see cref="MUI_USER_PREFERRED_UI_LANGUAGES"/>.
        /// <see cref="MUI_USE_SEARCH_ALL_LANGUAGES"/>:
        /// Retrieve all language-specific resource files for the path indicated by <paramref name="pcwszFilePath"/>, without considering file licensing.
        /// This flag is relevant only if the application supplies a null string for <paramref name="pwszLanguage"/>.
        /// <see cref="MUI_USER_PREFERRED_UI_LANGUAGES"/>:
        /// Retrieve only the files that implement languages in the fallback list.
        /// Successive calls enumerate the successive fallbacks, in the appropriate order.
        /// The first file indicated by the output value of <paramref name="pcchFileMUIPath"/> should be the best fit.
        /// This flag is relevant only if the application supplies a null string for <paramref name="pwszLanguage"/>.
        /// <see cref="MUI_USE_INSTALLED_LANGUAGES"/>:
        /// Retrieve only the files for the languages installed on the computer.
        /// This flag is relevant only if the application supplies a null string for <paramref name="pwszLanguage"/>.
        /// The following flags allow the user to indicate the type of file that is specified by <paramref name="pcwszFilePath"/>
        /// so that the function can determine if it must add ".mui" to the file name.
        /// The flags are mutually exclusive. If the application passes both flags, the function fails.
        /// If the application passes neither flag, the function checks the file in the root folder to verify the file type and decide on file naming.
        /// <see cref="MUI_LANG_NEUTRAL_PE_FILE"/>:
        /// Do not verify the file passed in <paramref name="pcwszFilePath"/> and append ".mui" to the file name before processing.
        /// For example, change Abc.exe to Abc.exe.mui.
        /// <see cref="MUI_NON_LANG_NEUTRAL_FILE"/>:
        /// Do not verify the file passed in <paramref name="pcwszFilePath"/> and do not append ".mui" to the file name before processing.
        /// For example, use Abc.txt or Abc.chm.
        /// </param>
        /// <param name="pcwszFilePath">
        /// Pointer to a null-terminated string specifying a file path.
        /// The path is either for an existing LN file or for a file such as a .txt, .inf, or .msc file.
        /// If the file is an LN file, the function looks for files containing the associated language-specific resources.
        /// For all other types of files, the function seeks files that correspond exactly to the file name and path indicated.
        /// Your application can overwrite the behavior of the file type check
        /// by using the <see cref="MUI_LANG_NEUTRAL_PE_FILE"/> or <see cref="MUI_NON_LANG_NEUTRAL_FILE"/> flag.
        /// For more information, see the Remarks section.
        /// Note
        /// The supplied file path can be a network path: for example, "\\machinename\c$\windows\system32\notepad.exe".
        /// </param>
        /// <param name="pwszLanguage">
        /// Pointer to a buffer containing a language string.
        /// On input, this buffer contains the language identifier or language name for which the application should find language-specific resource files,
        /// depending on the settings of <paramref name="dwFlags"/>.
        /// On successful return from the function, this parameter contains the language of the language-specific resource file that the function has found.
        /// Alternatively, the application can set this parameter to <see cref="NULL"/>, with the value referenced by <paramref name="pcchLanguage"/> set to 0.
        /// In this case, the function retrieves the required buffer size in <paramref name="pcchLanguage"/>.
        /// </param>
        /// <param name="pcchLanguage">
        /// Pointer to the buffer size, in characters, for the language string indicated by <paramref name="pwszLanguage"/>.
        /// If the application sets the value referenced by this parameter to 0 and passes <see cref="NULL"/> for <paramref name="pwszLanguage"/>,
        /// then the required buffer size will be returned in <paramref name="pcchLanguage"/> and the returned buffer size is always <see cref="LOCALE_NAME_MAX_LENGTH"/>,
        /// because the function is typically called multiple times in succession.
        /// The function cannot determine the exact size of the language name for all successive calls, and cannot extend the buffer on subsequent calls.
        /// Thus <see cref="LOCALE_NAME_MAX_LENGTH"/> is the only safe maximum.
        /// </param>
        /// <param name="pwszFileMUIPath">
        /// Pointer to a buffer containing the path to the language-specific resource file.
        /// It is strongly recommended to allocate this buffer to be of size <see cref="MAX_PATH"/>.
        /// Alternatively, this parameter can retrieve <see cref="NULL"/> if the value referenced by <paramref name="pcchFileMUIPath"/> is set to 0.
        /// In this case, the function retrieves the required size for the file path buffer in <paramref name="pcchFileMUIPath"/>.
        /// </param>
        /// <param name="pcchFileMUIPath">
        /// Pointer to the buffer size, in characters, for the file path indicated by <paramref name="pwszFileMUIPath"/>.
        /// On successful return from the function, this parameter indicates the size of the retrieved file path.
        /// If the application sets the value referenced by this parameter to 0, the function retrieves <see cref="NULL"/> for <paramref name="pwszFileMUIPath"/>,
        /// the required buffer size will be returned in <paramref name="pcchFileMUIPath"/> and the returned buffer size is always <see cref="MAX_PATH"/>,
        /// because the function is typically called multiple times in succession.
        /// The function cannot determine the exact size of the path for all successive calls, and cannot extend the buffer on subsequent calls.
        /// Thus <see cref="MAX_PATH"/> is the only safe maximum.
        /// </param>
        /// <param name="pululEnumerator">
        /// Pointer to an enumeration variable.
        /// The first time this function is called, the value of the variable should be 0.
        /// Between subsequent calls, the application should not change the value of this parameter.
        /// After the function retrieves all possible language-specific resource file paths, it returns <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// If the function fails, the output parameters do not change.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to NULL.
        /// <see cref="ERROR_NO_MORE_FILES"/>. There were no more files to process.
        /// </returns>
        /// <remarks>
        /// This function verifies that language-specific resource files exist, but it does not verify that they are correct.
        /// It requires the resource files to be stored according to the storage convention explained in Application Deployment.
        /// If the call to this function specifies the <see cref="MUI_LANGUAGE_ID"/> flag,
        /// the supplied language string must use a hexadecimal language identifier that does not include the leading 0x, and is 4 characters in length.
        /// For example, en-US should be passed as "0409" and en as "0009".
        /// The returned language string will be in the same format.
        /// When <see cref="MUI_LANGUAGE_ID"/> is specified, each hexadecimal value in the supplied language string must represent an actual language identifier.
        /// In particular, the values corresponding to the following locales cannot be specified:
        /// <see cref="LOCALE_USER_DEFAULT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_DEFAULT"/>,
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// To receive enumerated information, the application should call this function repeatedly until it returns <see cref="FALSE"/>,
        /// leaving the contents of <paramref name="pululEnumerator"/> unchanged between calls.
        /// Since each call retrieves the path to a different language-specific resource file,
        /// the application must clear the language buffer to an empty string between calls.
        /// If the application does not do this, the input value of <paramref name="pwszLanguage"/> takes precedence over the setting of <paramref name="dwFlags"/>.
        /// Typically the resource loader is used to find resource files.
        /// However, your application can also use this function to find the files.
        /// If the input file path is for an LN file, the function attaches a suffix of ".mui" when looking for the corresponding language-specific resource files.
        /// For example, the function retrieves the following files when the application passes the string "C:\mydir\Example1.dll"
        /// in <paramref name="pcwszFilePath"/> as the root file path, with <paramref name="dwFlags"/> set to <code>MUI_LANGUAGE_NAME | MUI_USE_SEARCH_ALL_LANGUAGES</code>:
        /// C:\mydir\Example1.dll
        /// C:\mydir\en-US\Example1.dll.mui
        /// C:\mydir\ja-JP\Example1.dll.mui
        /// The first call to the function sets <paramref name="pwszFileMUIPath"/> to "C:\mydir\en-US\Example1.dll.mui".
        /// The second call sets the file path to "C:\mydir\ja-JP\Example1.dll.mui".
        /// The function returns <see cref="FALSE"/> when called a third time and <see cref="GetLastError"/> returns <see cref="ERROR_NO_MORE_FILES"/>.
        /// If the file indicated by <paramref name="pcwszFilePath"/> does not have resource configuration data,
        /// or if the file does not exist, the function leaves the file name as it is when looking for the corresponding language-specific resource files.
        /// For example, the application passes the string "C:\mydir\Example2.txt" in <paramref name="pcwszFilePath"/> as the root file path,
        /// with <paramref name="dwFlags"/> set to <code>MUI_LANGUAGE_NAME | MUI_USER_PREFERRED_UI_LANGUAGES</code>.
        /// Let's consider the case in which the user preferred UI languages (in order) are Catalan, "ca-ES",
        /// and Spanish (Spain), "es-ES", and where the following files exist:
        /// (no corresponding file in C:\mydir)
        /// C:\mydir\en-US\Example2.txt
        /// C:\mydir\en\Example2.txt
        /// C:\mydir\es-ES\Example2.txt
        /// C:\mydir\es\Example2.txt
        /// C:\mydir\ja-JP\Example2.txt
        /// The first call to the function determines that there are no resources for "ca-ES" or for the neutral language "ca".
        /// The function then tries the next option, "es-ES", for which it succeeds in finding a match.
        /// Before returning, the function sets <paramref name="pwszFileMUIPath"/> to "C:\mydir\es-ES\Example2.txt".
        /// A second application call to the function continues the enumeration by setting <paramref name="pwszFileMUIPath"/> to "C:\mydir\es\Example2.txt".
        /// If the target file and its associated resource files are actually Side-by-side enabled assemblies,
        /// <see cref="GetFileMUIPath"/> cannot be used to retrieve the path to the resource file.
        /// Please refer to Using Assemblies with a Multilanguage User Interface for details on how to use Side-by-side assemblies with MUI support.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileMUIPath", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetFileMUIPath([In] MUIFlags dwFlags, [In] LPCWSTR pcwszFilePath, [In] LPWSTR pwszLanguage,
            [In][Out] ref ULONG pcchLanguage, [In] LPWSTR pwszFileMUIPath, [In][Out] ref ULONG pcchFileMUIPath, [In][Out] ref ULONGLONG pululEnumerator);

        /// <summary>
        /// <para>
        /// Retrieves information about a specified geographical location.
        /// <see cref="GetGeoInfo"/> is available for use in the operating systems specified in the Requirements section.
        /// It may be altered or unavailable in subsequent versions. Instead, use <see cref="GetGeoInfoEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getgeoinfow"/>
        /// </para>
        /// </summary>
        /// <param name="Location">
        /// Identifier for the geographical location for which to get information.
        /// For more information, see Table of Geographical Locations.
        /// You can obtain the available values by calling <see cref="EnumSystemGeoID"/>.
        /// </param>
        /// <param name="GeoType">
        /// Type of information to retrieve.
        /// Possible values are defined by the <see cref="SYSGEOTYPE"/> enumeration.
        /// If the value of <paramref name="GeoType"/> is <see cref="GEO_LCID"/>, the function retrieves a locale identifier.
        /// If the value of <paramref name="GeoType"/> is <see cref="GEO_RFC1766"/>,
        /// the function retrieves a string name that is compliant with RFC 4646 (Windows Vista).
        /// For more information, see the Remarks section.
        /// Windows XP: When <paramref name="GeoType"/> is set to <see cref="GEO_LCID"/>, the retrieved string is an 8-digit hexadecimal value.
        /// Windows Me: When <paramref name="GeoType"/> is set to <see cref="GEO_LCID"/>, the retrieved string is a decimal value.
        /// </param>
        /// <param name="lpGeoData">
        /// Pointer to the buffer in which this function retrieves the information.
        /// </param>
        /// <param name="cchData">
        /// Size of the buffer indicated by <paramref name="lpGeoData"/>.
        /// The size is the number of bytes for the ANSI version of the function, or the number of words for the Unicode version.
        /// The application can set this parameter to 0 if the function is to return the required size of the buffer.
        /// </param>
        /// <param name="LangId">
        /// Identifier for the language, used with the value of Location.
        /// The application can set this parameter to 0, with <see cref="GEO_RFC1766"/> or <see cref="GEO_LCID"/> specified for <paramref name="GeoType"/>.
        /// This setting causes the function to retrieve the language identifier by calling <see cref="GetUserDefaultLangID"/>.
        /// Note
        /// The application must set this parameter to 0 if <paramref name="GeoType"/> has any value other than <see cref="GEO_RFC1766"/> or <see cref="GEO_LCID"/>.
        /// </param>
        /// <returns>
        /// Returns the number of bytes (ANSI) or words (Unicode) of geographical location information retrieved in the output buffer.
        /// If <paramref name="cchData"/> is set to 0, the function returns the required size for the buffer.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// If the application specifies <see cref="GEO_RFC1766"/> for <paramref name="GeoType"/>,
        /// it should specify a language identifier for <paramref name="LangId"/> that is appropriate to the specified geographical location identifier.
        /// The appropriate language is either a locale-neutral language or one with a locale corresponding to the specified identifier.
        /// The resulting string, compliant with RFC 4646 (Windows Vista), constitutes a locale name.
        /// For example, if Location is specified as 0xF4 for United States, <paramref name="GeoType"/> is specified as <see cref="GEO_RFC1766"/>,
        /// and <paramref name="LangId"/> is specified as either 0x09 for locale-neutral English or 0x409 for English (United States),
        /// the function retrieves "en-US" on successful return.
        /// In fact, the function ignores the locale-specific portion of the language.
        /// Thus, if the application specifies LangId as 0x809 for English (United Kingdom), the function also writes "en-US" to <paramref name="lpGeoData"/>.
        /// Consider another example. If Location is specified as 0xF4 for United States,
        /// <paramref name="GeoType"/> is specified as <see cref="GEO_RFC1766"/>, and <paramref name="LangId"/> is specified as 0x04 for Chinese,
        /// the function retrieves "zh-US" on successful return.
        /// This is not the name of a supported locale.
        /// If the application specifies <see cref="GEO_LCID"/> for <paramref name="GeoType"/>,
        /// the function treats the language identifier as a locale identifier (LCID).
        /// It attempts to return the locale identifier if it is associated with the provided geographical identifier in some way.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetGeoInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetGeoInfo([In] GEOID Location, [In] SYSGEOTYPE GeoType, [In] LPWSTR lpGeoData,
            [In] int cchData, [In] LANGID LangId);

        /// <summary>
        /// <para>
        /// Retrieves information about a locale specified by identifier.
        /// Note
        /// For interoperability reasons, the application should prefer the <see cref="GetLocaleInfoEx"/> function to <see cref="GetLocaleInfo"/>
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// Any application that runs only on Windows Vista and later should use <see cref="GetLocaleInfoEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getlocaleinfow"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier for which to retrieve information.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>,
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// </param>
        /// <param name="LCType">
        /// The locale information to retrieve.
        /// For detailed definitions, see the LCType parameter of <see cref="GetLocaleInfoEx"/>.
        /// Note
        /// For <see cref="GetLocaleInfo"/>, the value <see cref="LOCALE_USE_CP_ACP"/> is relevant only for the ANSI version.
        /// </param>
        /// <param name="lpLCData">
        /// Pointer to a buffer in which this function retrieves the requested locale information.
        /// This pointer is not used if <paramref name="cchData"/> is set to 0.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="cchData">
        /// Size, in TCHAR values, of the data buffer indicated by <paramref name="lpLCData"/>.
        /// Alternatively, the application can set this parameter to 0.
        /// In this case, the function does not use the <paramref name="lpLCData"/> parameter and returns the required buffer size,
        /// including the terminating null character.
        /// </param>
        /// <returns>
        /// Returns the number of characters retrieved in the locale data buffer if successful and <paramref name="cchData"/> is a nonzero value.
        /// If the function succeeds, <paramref name="cchData"/> is nonzero, and <see cref="LOCALE_RETURN_NUMBER"/> is specified,
        /// the return value is the size of the integer retrieved in the data buffer; that is, 2 for the Unicode version of the function or 4 for the ANSI version.
        /// If the function succeeds and the value of cchData is 0, the return value is the required size,
        /// in characters including a null character, for the locale data buffer.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// For the operation of this function, see Remarks for <see cref="GetLocaleInfoEx"/>.
        /// Note
        /// Even when the <paramref name="LCType"/> parameter is specified as <see cref="LOCALE_FONTSIGNATURE"/>,
        /// <paramref name="cchData"/> and the function return are still TCHAR counts.
        /// The count is different for the ANSI and Unicode versions of the function.
        /// When an application calls the generic version of <see cref="GetLocaleInfo"/> with <see cref="LOCALE_FONTSIGNATURE"/>,
        /// <paramref name="cchData"/> can be safely specified as <code>sizeof(LOCALESIGNATURE) / sizeof(TCHAR)</code>.
        /// The following examples deal correctly with the buffer size for non-text values:
        /// <code>
        /// int   ret;
        /// CALID calid;
        /// DWORD value;
        /// 
        /// ret = GetLocaleInfo(LOCALE_USER_DEFAULT,
        ///                     LOCALE_ICALENDARTYPE | LOCALE_RETURN_NUMBER,
        ///                     (LPTSTR)&amp;value,
        ///                     sizeof(value) / sizeof(TCHAR) );
        /// calid = value;
        /// 
        /// LOCALESIGNATURE LocSig;
        /// 
        /// ret = GetLocaleInfo(LOCALE_USER_DEFAULT,
        ///                     LOCALE_FONTSIGNATURE,
        ///                     (LPWSTR)&amp;LocSig,
        ///                     sizeof(LocSig) / sizeof(TCHAR) );
        /// </code>
        /// The ANSI string retrieved by the ANSI version of this function is translated from Unicode to ANSI
        /// based on the default ANSI code page for the locale identifier.
        /// However, if <see cref="LOCALE_USE_CP_ACP"/> is specified, the translation is based on the system default ANSI code page.
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the function can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark (?).
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLocaleInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetLocaleInfo([In] LCID Locale, [In] LCTYPE LCType, [In] LPWSTR lpLCData, [In] int cchData);

        /// <summary>
        /// <para>
        /// Retrieves information about a locale specified by identifier.
        /// Note
        /// The application should call this function in preference to <see cref="GetLocaleInfo"/> if designed to run only on Windows Vista and later.
        /// Note
        /// This function can retrieve data that changes between releases, for example, due to a custom locale.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getlocaleinfoex"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleName">
        /// Pointer to a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>, <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>, <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="LCType">
        /// The locale information to retrieve.
        /// For possible values, see the "Constants Used in the LCType Parameter of GetLocaleInfo,
        /// GetLocaleInfoEx, and SetLocaleInfo" section in Locale Information Constants.
        /// Note that only one piece of locale information can be specified per call.
        /// The application can use the binary OR operator to combine <see cref="LOCALE_RETURN_NUMBER"/> with any other allowed constant.
        /// In this case, the function retrieves the value as a number instead of a string.
        /// The buffer that receives the value must be at least the length of a DWORD value, which is 2.
        /// Caution
        /// It is also possible to combine <see cref="LOCALE_NOUSEROVERRIDE"/> with any other constant.
        /// However, use of this constant is strongly discouraged.
        /// (Even without using the current user override, the data can differ from computer to computer,
        /// and custom locales can change the data. For example, even month or day names are subject to spelling reforms.)
        /// If <paramref name="LCType"/> is set to <see cref="LOCALE_IOPTIONALCALENDAR"/>, the function retrieves only the first alternate calendar.
        /// Note
        /// To get all alternate calendars, the application should use <see cref="EnumCalendarInfoEx"/>.
        /// Starting with Windows Vista, your applications should not use <see cref="LOCALE_ILANGUAGE"/>
        /// in the <paramref name="LCType"/> parameter to avoid failure or retrieval of unexpected data.
        /// Instead, it is recommended for your applications to call <see cref="GetLocaleInfoEx"/>.
        /// </param>
        /// <param name="lpLCData">
        /// Pointer to a buffer in which this function retrieves the requested locale information.
        /// This pointer is not used if <paramref name="cchData"/> is set to 0.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="cchData">
        /// Size, in TCHAR values, of the data buffer indicated by <paramref name="lpLCData"/>.
        /// Alternatively, the application can set this parameter to 0.
        /// In this case, the function does not use the <paramref name="lpLCData"/> parameter and returns the required buffer size,
        /// including the terminating null character.
        /// </param>
        /// <returns>
        /// Returns the number of characters retrieved in the locale data buffer if successful and <paramref name="cchData"/> is a nonzero value.
        /// If the function succeeds, <paramref name="cchData"/> is nonzero, and <see cref="LOCALE_RETURN_NUMBER"/> is specified,
        /// the return value is the size of the integer retrieved in the data buffer; that is, 2.
        /// If the function succeeds and the value of cchData is 0, the return value is the required size,
        /// in characters including a null character, for the locale data buffer.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// This function normally retrieves information in text format.
        /// If the information is a numeric value and the value of <paramref name="LCType"/> is <see cref="LOCALE_ILANGUAGE"/> or <see cref="LOCALE_IDEFAULTLANGUAGE"/>,
        /// this function retrieves strings containing hexadecimal numbers.
        /// Otherwise, the retrieved text for numeric information is a decimal number.
        /// There are two exceptions to this rule. First, the application can retrieve numeric values as integers
        /// by specifying <see cref="LOCALE_RETURN_NUMBER"/> in the <paramref name="LCType"/> parameter.
        /// The second exception is that <see cref="LOCALE_FONTSIGNATURE"/> behaves differently from all other locale information constants.
        /// The application must provide a data buffer of at least <code>sizeof(LOCALESIGNATURE)</code> bytes.
        /// On successful return from the function, the buffer is filled in as a <see cref="LOCALESIGNATURE"/> structure.
        /// Note
        /// Even when the <paramref name="LCType"/> parameter is specified as <see cref="LOCALE_FONTSIGNATURE"/>,
        /// <paramref name="cchData"/> and the function return are still TCHAR counts.
        /// The count is different for the ANSI and Unicode versions of the function.
        /// When an application calls the generic version of <see cref="GetLocaleInfo"/> with <see cref="LOCALE_FONTSIGNATURE"/>,
        /// <paramref name="cchData"/> can be safely specified as <code>sizeof(LOCALESIGNATURE) / sizeof(TCHAR)</code>.
        /// The following examples deal correctly with the buffer size for non-text values:
        /// <code>
        /// int   ret;
        /// CALID calid;
        /// DWORD value;
        /// 
        /// ret = GetLocaleInfoEx(LOCALE_NAME_USER_DEFAULT,
        ///                       LOCALE_ICALENDARTYPE | LOCALE_RETURN_NUMBER,
        ///                       (LPTSTR)&amp;value,
        ///                       sizeof(value) / sizeof(TCHAR) );
        /// calid = value;
        /// 
        /// LOCALESIGNATURE LocSig;
        /// 
        /// ret = GetLocaleInfoEx(LOCALE_NAME_USER_DEFAULT,
        ///                       LOCALE_FONTSIGNATURE,
        ///                       (LPWSTR)&amp;LocSig,
        ///                       sizeof(LocSig) / sizeof(TCHAR) );
        /// </code>
        /// This function can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLocaleInfoEx", ExactSpelling = true, SetLastError = true)]
        public static extern int GetLocaleInfoEx([In] LPCWSTR lpLocaleName, [In] LCTYPE LCType, [In] LPWSTR lpLCData, [In] int cchData);

        /// <summary>
        /// <para>
        /// Retrieves information about the current version of a specified NLS capability for a locale specified by identifier.
        /// Note
        /// For interoperability reasons, the application should prefer the <see cref="GetNLSVersionEx"/> function to <see cref="GetNLSVersion"/>
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// This recommendation applies especially to custom locales, for which <see cref="GetNLSVersionEx"/> retrieves enough information
        /// to determine if sort behavior has changed.
        /// Any application that runs only on Windows Vista and later should use <see cref="GetNLSVersionEx"/>
        /// or at least pass the <see cref="NLSVERSIONINFOEX"/> structure when calling <see cref="GetNLSVersion"/> to obtain additional sorting versioning data.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getnlsversion"/>
        /// </para>
        /// </summary>
        /// <param name="function">
        /// The NLS capability to query.
        /// This value must be <see cref="COMPARE_STRING"/>.
        /// See the <see cref="SYSNLS_FUNCTION"/> enumeration.
        /// </param>
        /// <param name="Locale">
        /// Locale identifier that specifies the locale.
        /// You can use the <see cref="MAKELCID"/> macro to create an identifier or use one of the following predefined values.
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// Windows Vista and later: The following custom locale identifiers are also supported.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </param>
        /// <param name="lpVersionInformation">
        /// Pointer to an <see cref="NLSVERSIONINFO"/> structure.
        /// The application must initialize the <see cref="NLSVERSIONINFO.dwNLSVersionInfoSize"/> member to <code>sizeof(NLSVERSIONINFO)</code>.
        /// Note
        /// On Windows Vista and later, the function can alternatively provide version information in an <see cref="NLSVERSIONINFOEX"/> structure.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if and only if the application has supplied valid values in <see cref="NLSVERSIONINFO.lpVersionInformation"/>,
        /// or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// This function allows an application such as Active Directory to determine
        /// if an NLS change affects the locale identifier used for a particular index table.
        /// If it does not, there is no need to re-index the table. For more information, see Handling Sorting in Your Applications.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNLSVersion", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNLSVersion([In] SYSNLS_FUNCTION function, [In] LCID Locale, [In] in NLSVERSIONINFO lpVersionInformation);

        /// <summary>
        /// <para>
        /// Retrieves information about the current version of a specified NLS capability for a locale specified by name.
        /// Note
        /// The application should call this function in preference to <see cref="GetNLSVersion"/> if designed to run only on Windows Vista and later.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getnlsversionex"/>
        /// </para>
        /// </summary>
        /// <param name="function">
        /// The NLS capability to query.
        /// This value must be <see cref="COMPARE_STRING"/>.
        /// See the <see cref="SYSNLS_FUNCTION"/> enumeration.
        /// </param>
        /// <param name="lpLocaleName">
        /// Pointer to a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>, <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>, <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="lpVersionInformation">
        /// Pointer to an <see cref="NLSVERSIONINFOEX"/> structure.
        /// The application must initialize the <see cref="NLSVERSIONINFOEX.dwNLSVersionInfoSize"/> member to <code>sizeof(NLSVERSIONINFOEX)</code>.
        /// Note
        /// On Windows Vista and later, the function can alternatively provide version information in an <see cref="NLSVERSIONINFO"/> structure.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if and only if the application has supplied valid values in <paramref name="lpVersionInformation"/>,
        /// or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// This function allows an application such as Active Directory to determine if an NLS change affects the locale used for a particular index table.
        /// If it does not, there is no need to re-index the table.
        /// For more information, see Handling Sorting in Your Applications.
        /// In particular, to tell if a sort version changed and you need to reindex:
        /// Use <see cref="GetNLSVersionEx"/> to retrieve an <see cref="NLSVERSIONINFOEX"/> structure when doing the original indexing of your data.
        /// Store the following properties with your index to identify the version:
        /// <see cref="NLSVERSIONINFOEX.dwNLSVersion"/>. This specifies the version of the sorting table you're using.
        /// <see cref="NLSVERSIONINFOEX.dwEffectiveId"/>. This specifies the effective locale of your sort. A custom locale will point to an in-box locale's sort.
        /// <see cref="NLSVERSIONINFOEX.guidCustomVersion"/>. This is a GUID specifying a specific custom sort for custom locales that have them.
        /// When using the index use <see cref="GetNLSVersionEx"/> to discover the version of your data.
        /// If any of the three properties has changed, the sorting data you're using could return different results and any indexing you have may fail to find records.
        /// If you know that your data doesn't contain invalid Unicode code points (that is, all of your strings passed a call to <see cref="IsNLSDefinedString"/>)
        /// then you may consider them the same if only the low byte of <see cref="NLSVERSIONINFOEX.dwNLSVersion"/> changed (the minor version described above).
        /// This is covered in more detail in the blog entry "How to tell if the collation version changed"
        /// (http://blogs.msdn.com/shawnste/archive/2007/06/01/how-to-tell-if-the-collation-version-changed.aspx).
        /// This function supports custom locales.
        /// If <paramref name="lpLocaleName"/> specifies a supplemental locale,
        /// the data retrieved is the correct data for the sort order associated with that supplemental locale.
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNLSVersionEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNLSVersionEx([In] SYSNLS_FUNCTION function, [In] LPWSTR lpLocaleName, [In] in NLSVERSIONINFOEX lpVersionInformation);

        /// <summary>
        /// <para>
        /// Returns the current original equipment manufacturer (OEM) code page identifier for the operating system.
        /// Note
        /// The ANSI code pages can be different on different computers, or can be changed for a single computer, leading to data corruption.
        /// For the most consistent results, applications should use Unicode, such as UTF-8 or UTF-16, instead of a specific code page.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getoemcp"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the current OEM code page identifier for the operating system.
        /// </returns>
        /// <remarks>
        /// See Code Page Identifiers for a list of OEM and other code pages.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetOEMCP", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetOEMCP();

        /// <summary>
        /// <para>
        /// Retrieves the process preferred UI languages.
        /// For more information, see User Interface Language Management.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getprocesspreferreduilanguages"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags identifying the language format to use for the process preferred UI languages.
        /// The flags are mutually exclusive, and the default is <see cref="MUI_LANGUAGE_NAME"/>.
        /// <see cref="MUI_LANGUAGE_ID"/>: Retrieve the language strings in language identifier format.
        /// <see cref="MUI_LANGUAGE_NAME"/>: Retrieve the language strings in language name format.
        /// </param>
        /// <param name="pulNumLanguages">
        /// Pointer to the number of languages retrieved in <paramref name="pwszLanguagesBuffer"/>.
        /// </param>
        /// <param name="pwszLanguagesBuffer">
        /// Optional.
        /// Pointer to a double null-terminated multi-string buffer in which the function retrieves an ordered,
        /// null-delimited list in preference order, starting with the most preferable.
        /// Alternatively if this parameter is set to <see cref="NULL"/> and <paramref name="pcchLanguagesBuffer"/> is set to 0,
        /// the function retrieves the required size of the language buffer in <paramref name="pcchLanguagesBuffer"/>.
        /// The required size includes the two null characters.
        /// </param>
        /// <param name="pcchLanguagesBuffer">
        /// Pointer to the size, in characters, for the language buffer indicated by <paramref name="pwszLanguagesBuffer"/>.
        /// On successful return from the function, the parameter contains the size of the retrieved language buffer.
        /// Alternatively if this parameter is set to 0 and <paramref name="pwszLanguagesBuffer"/> is set to <see cref="NULL"/>,
        /// the function retrieves the required size of the language buffer in <paramref name="pcchLanguagesBuffer"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// If the process preferred UI language list is empty or if the languages specified for the process are not valid,
        /// the function succeeds and returns an empty multistring in <paramref name="pwszLanguagesBuffer"/> and 2 in the <paramref name="pcchLanguagesBuffer"/> parameter.
        /// </returns>
        /// <remarks>
        /// Depending on the flags specified by the application, this function can retrieve a list consisting of the process preferred UI languages.
        /// If it encounters a duplicate language, the function only retrieves the first instance of the duplicated language.
        /// When <see cref="MUI_LANGUAGE_ID"/> is specified, the language strings retrieved will be hexadecimal language identifiers
        /// that do not include the leading 0x, and will be 4 characters in length.
        /// For example, en-US will be returned as "0409" and en as "0009".
        /// Note
        /// Use of <see cref="MUI_LANGUAGE_NAME"/> is recommended over <see cref="MUI_LANGUAGE_ID"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessPreferredUILanguages", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetProcessPreferredUILanguages([In] MUIFlags dwFlags, [Out] out ULONG pulNumLanguages,
            [In] IntPtr pwszLanguagesBuffer, [In][Out] ref ULONG pcchLanguagesBuffer);

        /// <summary>
        /// <para>
        /// Returns the language identifier for the system locale.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getsystemdefaultlangid"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the language identifier for the system locale.
        /// This is the language used when displaying text in programs that do not support Unicode.
        /// It is set by the Administrator under Control Panel > Clock, Language, and Region > Change date, time, or number formats > Administrative tab.
        /// For more information on language identifiers, see Language Identifier Constants and Strings.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemDefaultLangID", ExactSpelling = true, SetLastError = true)]
        public static extern LANGID GetSystemDefaultLangID();

        /// <summary>
        /// <para>
        /// Returns the locale identifier for the system locale.
        /// Note
        /// Any application that runs only on Windows Vista and later should use <see cref="GetSystemDefaultLocaleName"/> in preference to this function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getsystemdefaultlcid"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the locale identifier for the system default locale, identified by <see cref="LOCALE_SYSTEM_DEFAULT"/>.
        /// </returns>
        /// <remarks>
        /// This function can retrieve data from custom locales. Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemDefaultLCID", ExactSpelling = true, SetLastError = true)]
        public static extern LCID GetSystemDefaultLCID();

        /// <summary>
        /// <para>
        /// Retrieves the system preferred UI languages.
        /// For more information, see User Interface Language Management.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getsystempreferreduilanguages"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags identifying the language format to use for the process preferred UI languages.
        /// The flags are mutually exclusive, and the default is <see cref="MUI_LANGUAGE_NAME"/>.
        /// <see cref="MUI_LANGUAGE_ID"/>: Retrieve the language strings in language identifier format.
        /// <see cref="MUI_LANGUAGE_NAME"/>: Retrieve the language strings in language name format.
        /// The following flag specifies whether the function is to validate the list of languages (default)
        /// or retrieve the system preferred UI languages list exactly as it is stored in the registry.
        /// <see cref="MUI_MACHINE_LANGUAGE_SETTINGS"/>:
        /// Retrieve the stored system preferred UI languages list, checking only to ensure that each language name corresponds to a valid NLS locale.
        /// If this flag is not set, the function retrieves the system preferred UI languages in <paramref name="pwszLanguagesBuffer"/>,
        /// as long as the list is non-empty and meets the validation criteria.
        /// Otherwise, the function retrieves the system default user interface language in the language buffer.
        /// </param>
        /// <param name="pulNumLanguages">
        /// Pointer to the number of languages retrieved in <paramref name="pwszLanguagesBuffer"/>.
        /// </param>
        /// <param name="pwszLanguagesBuffer">
        /// Optional.
        /// Pointer to a double null-terminated multi-string buffer in which the function retrieves an ordered,
        /// null-delimited list in preference order, starting with the most preferable.
        /// Alternatively if this parameter is set to <see cref="NULL"/> and <paramref name="pcchLanguagesBuffer"/> is set to 0,
        /// the function retrieves the required size of the language buffer in <paramref name="pcchLanguagesBuffer"/>.
        /// The required size includes the two null characters.
        /// </param>
        /// <param name="pcchLanguagesBuffer">
        /// Pointer to the size, in characters, for the language buffer indicated by <paramref name="pwszLanguagesBuffer"/>.
        /// On successful return from the function, the parameter contains the size of the retrieved language buffer.
        /// Alternatively if this parameter is set to 0 and <paramref name="pwszLanguagesBuffer"/> is set to <see cref="NULL"/>,
        /// the function retrieves the required size of the language buffer in <paramref name="pcchLanguagesBuffer"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// If the function fails for any other reason, the parameters <paramref name="pulNumLanguages"/> and <paramref name="pcchLanguagesBuffer"/> are undefined.
        /// </returns>
        /// <remarks>
        /// When <see cref="MUI_LANGUAGE_ID"/> is specified, the language strings retrieved will be hexadecimal language identifiers
        /// that do not include the leading 0x, and will be 4 characters in length.
        /// For example, en-US will be returned as "0409" and en as "0009".
        /// The system preferred UI languages cannot include more than one Language Interface Pack (LIP) language that corresponds to a supplemental locale.
        /// If the list includes more than one of these languages, and if the application specifies <see cref="MUI_LANGUAGE_ID"/> in the call to the function,
        /// the language buffer contains "1400" for that language.
        /// This string corresponds to the hexadecimal value of <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>.
        /// If the <see cref="MUI_MACHINE_LANGUAGE_SETTINGS"/> flag is set, this function checks each language in the list that represents a valid NLS locale.
        /// The retrieved list can contain the following items:
        /// Languages not installed on the system
        /// Duplicate language entries
        /// An empty string
        /// If the <see cref="MUI_MACHINE_LANGUAGE_SETTINGS"/> flag is set and the system preferred UI languages list is empty,
        /// the function retrieves an empty string in the language buffer (two null characters, because it is a multistring buffer),
        /// 0 for the number of languages, and 2 for the buffer size.
        /// If the <see cref="MUI_MACHINE_LANGUAGE_SETTINGS"/> flag is not set, the retrieved language list has the following characteristics:
        /// Each language represents a valid NLS locale.
        /// Each language is installed on the operating system.
        /// The list contains one entry for each language, with no duplicate entries.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemPreferredUILanguages", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetSystemPreferredUILanguages([In] MUIFlags dwFlags, [Out] out ULONG pulNumLanguages,
            [In] IntPtr pwszLanguagesBuffer, [In][Out] ref ULONG pcchLanguagesBuffer);

        /// <summary>
        /// <para>
        /// Returns the locale identifier of the current locale for the calling thread.
        /// Note
        /// This function can retrieve data that changes between releases, for example, due to a custom locale.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getthreadlocale"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the locale identifier of the locale associated with the current thread.
        /// Windows Vista: This function can return the identifier of a custom locale.
        /// If the current thread locale is a custom locale, the function returns <see cref="LOCALE_CUSTOM_DEFAULT"/>.
        /// If the current thread locale is a supplemental custom locale, the function can return <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>.
        /// All supplemental locales share this locale identifier.
        /// </returns>
        /// <remarks>
        /// When an application process launches, it uses the Standards and Formats variable for the locale.
        /// For more information, see NLS Terminology.
        /// When a new thread is created in a process, it inherits the locale of the creating thread.
        /// This locale can be either the default Standards and Formats locale or a different locale
        /// set for the creating thread in a call to <see cref="SetThreadLocale"/>.
        /// <see cref="GetThreadLocale"/> and <see cref="SetThreadLocale"/> can be used to modify the locale of the new thread.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadLocale", ExactSpelling = true, SetLastError = true)]
        public static extern LCID GetThreadLocale();

        /// <summary>
        /// <para>
        /// Retrieves the thread preferred UI languages for the current thread.
        /// For more information, see User Interface Language Management.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getthreadpreferreduilanguages"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags identifying the language format to use for the process preferred UI languages.
        /// The flags are mutually exclusive, and the default is <see cref="MUI_LANGUAGE_NAME"/>.
        /// <see cref="MUI_LANGUAGE_ID"/>: Retrieve the language strings in language identifier format.
        /// <see cref="MUI_LANGUAGE_NAME"/>: Retrieve the language strings in language name format.
        /// The following flags specify filtering for the function to use in retrieving the thread preferred UI languages.
        /// The default flag is <see cref="MUI_MERGE_USER_FALLBACK"/>.
        /// <see cref="MUI_MERGE_SYSTEM_FALLBACK"/>:
        /// Use the system fallback to retrieve a list that corresponds exactly to the language list used by the resource loader.
        /// This flag can be used only in combination with <see cref="MUI_MERGE_USER_FALLBACK"/>.
        /// Using the flags in combination alters the usual effect of <see cref="MUI_MERGE_USER_FALLBACK"/> by including fallback and neutral languages in the list.
        /// <see cref="MUI_MERGE_USER_FALLBACK"/>:
        /// Retrieve a composite list consisting of the thread preferred UI languages, followed by process preferred UI languages,
        /// followed by any user preferred UI languages that are distinct from these,
        /// followed by the system default UI language, if it is not already in the list.
        /// If the user preferred UI languages list is empty, the function retrieves the system preferred UI languages.
        /// This flag cannot be combined with <see cref="MUI_THREAD_LANGUAGES"/>.
        /// <see cref="MUI_THREAD_LANGUAGES"/>:
        /// Retrieve only the thread preferred UI languages for the current thread, or an empty list if no preferred languages are set for the current thread.
        /// This flag cannot be combined with <see cref="MUI_MERGE_USER_FALLBACK"/> or <see cref="MUI_MERGE_SYSTEM_FALLBACK"/>.
        /// <see cref="MUI_UI_FALLBACK"/>:
        /// Retrieve a complete thread preferred UI languages list along with associated fallback and neutral languages.
        /// Use of this flag is equivalent to combining <see cref="MUI_MERGE_SYSTEM_FALLBACK"/> and <see cref="MUI_MERGE_USER_FALLBACK"/>.
        /// (Applicable only for Windows 7 and later).
        /// </param>
        /// <param name="pulNumLanguages">
        /// Pointer to the number of languages retrieved in <paramref name="pwszLanguagesBuffer"/>.
        /// </param>
        /// <param name="pwszLanguagesBuffer">
        /// Optional.
        /// Pointer to a double null-terminated multi-string buffer in which the function retrieves an ordered,
        /// null-delimited list in preference order, starting with the most preferable.
        /// Alternatively if this parameter is set to <see cref="NULL"/> and <paramref name="pcchLanguagesBuffer"/> is set to 0,
        /// the function retrieves the required size of the language buffer in <paramref name="pcchLanguagesBuffer"/>.
        /// The required size includes the two null characters.
        /// </param>
        /// <param name="pcchLanguagesBuffer">
        /// Pointer to the size, in characters, for the language buffer indicated by <paramref name="pwszLanguagesBuffer"/>.
        /// On successful return from the function, the parameter contains the size of the retrieved language buffer.
        /// Alternatively if this parameter is set to 0 and <paramref name="pwszLanguagesBuffer"/> is set to <see cref="NULL"/>,
        /// the function retrieves the required size of the language buffer in <paramref name="pcchLanguagesBuffer"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// If the function fails for any other reason, the parameters <paramref name="pulNumLanguages"/> and <paramref name="pcchLanguagesBuffer"/> are undefined.
        /// </returns>
        /// <remarks>
        /// Depending on the flags specified by the application, this function can retrieve a composite list consisting of the thread preferred UI languages,
        /// process preferred UI languages, user preferred UI languages or system preferred UI languages, and the system default UI language.
        /// If it encounters a duplicate language, the function only retrieves the first language.
        /// If the application has called <see cref="SetThreadPreferredUILanguages"/>
        /// with the <see cref="MUI_CONSOLE_FILTER"/> or <see cref="MUI_COMPLEX_SCRIPT_FILTER"/> flag,
        /// <see cref="GetThreadPreferredUILanguages"/> filters the languages in the result list.
        /// The function replaces the languages the console cannot display with a substitute language.
        /// The substitution for a language is determined from the value of <see cref="LOCALE_SCONSOLEFALLBACKNAME"/> for the language. 
        /// For more console information, see the description of <see cref="SetThreadUILanguage"/>.
        /// Use of <see cref="MUI_LANGUAGE_NAME"/> is recommended over <see cref="MUI_LANGUAGE_ID"/>
        /// because the <see cref="MUI_LANGUAGE_NAME"/> flag can do a better job of handling Language Interface Pack (LIP) languages that correspond to supplemental locales.
        /// When <see cref="MUI_LANGUAGE_ID"/> is specified, the language strings retrieved will be hexadecimal language identifiers
        /// that do not include the leading 0x, and will be 4 characters in length.
        /// For example, en-US will be returned as "0409" and en as "0009".
        /// If the application sets the <see cref="MUI_LANGUAGE_ID"/> flag,
        /// the thread preferred UI languages can include one or more languages that correspond to supplemental locales.
        /// On successful return from the function, the language buffer contains "1400" for any language corresponding to a supplemental locale.
        /// There can be only one such language in this list.
        /// The string "1400" corresponds to the hexadecimal value of <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>.
        /// Also on successful return from the function, the <paramref name="pwszLanguagesBuffer"/> contains "1000"
        /// for any other language that corresponds to a supplemental locale.
        /// The string "1000" corresponds to the hexadecimal value of <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>,
        /// which is not useful as an input to any function, because it cannot distinguish among supplemental locales.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadPreferredUILanguages", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetThreadPreferredUILanguages([In] MUIFlags dwFlags, [Out] out ULONG pulNumLanguages,
            [In] IntPtr pwszLanguagesBuffer, [In][Out] ref ULONG pcchLanguagesBuffer);

        /// <summary>
        /// <para>
        /// Returns the language identifier of the first user interface language for the current thread.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getthreaduilanguage"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the identifier for a language explicitly associated with the thread
        /// by <see cref="SetThreadUILanguage"/> or <see cref="SetThreadPreferredUILanguages"/>.
        /// Alternatively, if no language has been explicitly associated with the current thread,
        /// the identifier can indicate a user or system user interface language.
        /// </returns>
        /// <remarks>
        /// Calling this function is identical to calling <see cref="GetThreadPreferredUILanguages"/> with dwFlags
        /// set to <code>MUI_MERGE_SYSTEM_FALLBACK | MUI_MERGE_USER_FALLBACK | MUI_LANGUAGE_ID</code> and using the first language in the retrieved list.
        /// The return value for this function does not provide useful information about a Language Interface Pack(LIP) language
        /// if that language corresponds to a supplemental locale.For such a language,
        /// the function returns the hexadecimal value "1400", which corresponds to <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>
        /// if that language is specified in the user preferred UI languages list.
        /// If the language is not specified in the user preferred UI languages list,
        /// the function returns the value "1000", corresponding to <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadUILanguage", ExactSpelling = true, SetLastError = true)]
        public static extern LANGID GetThreadUILanguage();

        /// <summary>
        /// <para>
        /// Retrieves a variety of information about an installed UI language:
        /// Is the language installed?
        /// Is the current user licensed to use the language?
        /// Is the language fully localized? Partially localized? Part of a Language Installation Pack (LIP)?
        /// If it is partially localized or part of an LIP:
        /// What is its fallback language?
        /// If that fallback language is a partially localized language, what is its base?
        /// What is the default fallback language?
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getuilanguageinfo"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags defining the format of the specified language. The flags are mutually exclusive, and the default is <see cref="MUI_LANGUAGE_NAME"/>.
        /// <see cref="MUI_LANGUAGE_ID"/>: Retrieve the language strings in language identifier format.
        /// <see cref="MUI_LANGUAGE_NAME"/>: Retrieve the language strings in language name format.
        /// </param>
        /// <param name="pwmszLanguage">
        /// Pointer to languages for which the function is to retrieve information.
        /// This parameter indicates an ordered, null-delimited list of language identifiers or language names, depending on the flag setting.
        /// For information on the use of this parameter, see the Remarks section.
        /// </param>
        /// <param name="pwszFallbackLanguages">
        /// Pointer to a buffer in which this function retrieves an ordered, null-delimited list of fallback languages,
        /// formatted as defined by the setting for <paramref name="dwFlags"/>.
        /// This list ends with two null characters.
        /// Alternatively if this parameter is set to <see cref="NULL"/> and <paramref name="pcchFallbackLanguages"/> is set to 0,
        /// the function retrieves the required size of the language buffer in <paramref name="pcchFallbackLanguages"/>.
        /// The required size includes the two null characters.
        /// </param>
        /// <param name="pcchFallbackLanguages">
        /// Pointer to the size, in characters, for the language buffer indicated by <paramref name="pwszFallbackLanguages"/>.
        /// On successful return from the function, the parameter contains the size of the retrieved language buffer.
        /// Alternatively if this parameter is set to 0 and <paramref name="pwszFallbackLanguages"/> is set to <see cref="NULL"/>,
        /// the function retrieves the required size of the language buffer in <paramref name="pcchFallbackLanguages"/>.
        /// </param>
        /// <param name="pAttributes">
        /// Pointer to flags indicating attributes of the input language list.
        /// The function always retrieves the flag characterizing the last language listed.
        /// <see cref="MUI_FULL_LANGUAGE"/>: The language is fully localized.
        /// <see cref="MUI_PARTIAL_LANGUAGE"/>: The language is partially localized.
        /// <see cref="MUI_LIP_LANGUAGE"/>: The language is an LIP language.
        /// In addition, <paramref name="pAttributes"/> includes one or both of the following flags, as appropriate.
        /// <see cref="MUI_LANGUAGE_INSTALLED"/>: The language is installed on this computer.
        /// <see cref="MUI_LANGUAGE_LICENSED"/>: The language is appropriately licensed for the current user.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid. For more information, see Remarks.
        /// <see cref="ERROR_OBJECT_NAME_NOT_FOUND"/>.
        /// The specified object name was not found, or it was not valid, or the first language in the input list is not an installed language.
        /// For more information, see Remarks.
        /// If <see cref="GetLastError"/> returns any other error code,
        /// the parameters <paramref name="pcchFallbackLanguages"/> and <paramref name="pAttributes"/> are undefined.
        /// </returns>
        /// <remarks>
        /// <see cref="MUI_LANGUAGE_NAME"/> is recommended over <see cref="MUI_LANGUAGE_ID"/>
        /// because it allows the function to do a better job of handling LIP languages that do not correspond to predefined locales,
        /// but instead correspond to a supplemental locale.
        /// LIP languages that correspond to predefined locales are handled just like non-LIP languages.
        /// If the <see cref="MUI_LANGUAGE_ID"/> flag is specified, the supplied language strings must use hexadecimal language identifiers
        /// that do not include the leading 0x, and are 4 characters in length.
        /// For example, en-US should be passed as "0409" and en as "0009".
        /// The returned language strings will be in the same format.
        /// When <see cref="MUI_LANGUAGE_ID"/> is specified, and if there is such a language in the user preferred UI languages list,
        /// there can be only one such language in the list.
        /// That language can be specified in pwmszLanguage as "1400", which corresponds to the hexadecimal value of <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>.
        /// No other such language can be specified using <see cref="MUI_LANGUAGE_ID"/>.
        /// Using "1000", which corresponds to the hexadecimal value of <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>,
        /// in the string indicated by <paramref name="pwszFallbackLanguages"/> will result in an <see cref="ERROR_INVALID_PARAMETER"/> code.
        /// A partially localized language can have a fallback language that is partially localized,
        /// requiring repeated calls to <see cref="GetUILanguageInfo"/> to obtain full information.
        /// Consider the case of a partially localized language Lang1 that offers a choice of three fallback languages.
        /// The Lang3 fallback language is partially localized, and offers a choice of two fallback languages.
        /// The dependencies are as follows, with the default fallback listed first:
        /// Lang1
        ///     Lang2
        ///     Lang3
        ///         Lang5
        ///         Lang6
        ///     Lang4
        /// To get the fallback language(s) of Lang1, the application passes in pwmszLanguage as "Lang1\0\0".
        /// On return from the function, <paramref name="pwszFallbackLanguages"/> is set to "Lang2\0Lang3\0Lang4\0\0".
        /// Note that the ordering of this list indicates that Lang2 is the default fallback language.
        /// To get the fallback language(s) of Lang3 in relation to Lang1, the application passes in pwmszLanguage as "lang1\0\lang3\0\0".
        /// On return from the function, <paramref name="pwszFallbackLanguages"/> is set to "Lang5\0Lang6\0\0".
        /// This function returns <see cref="ERROR_INVALID_PARAMETER"/> for any of the following:
        /// <paramref name="pwszFallbackLanguages"/> is <see cref="NULL"/> or empty.
        /// Both <see cref="MUI_LANGUAGE_ID"/> and <see cref="MUI_LANGUAGE_NAME"/> are set.
        /// Any flags other than <see cref="MUI_LANGUAGE_ID"/> or <see cref="MUI_LANGUAGE_NAME"/> are set.
        /// <paramref name="pcchFallbackLanguages"/> is greater than 0 but <paramref name="pwszFallbackLanguages"/> is <see cref="NULL"/>.
        /// <paramref name="pwmszLanguage"/> cannot be parsed as a multi-string buffer of language identifiers or language names, depending on the flag setting.
        /// The <see cref="ERROR_OBJECT_NAME_NOT_FOUND"/> error code occurs if <paramref name="pwmszLanguage"/> can be parsed, but is not valid.
        /// The code might also be returned for an invalid locale identifier, or if the first language in the input list is not an installed language,
        /// or if a fully localized language has defined a fallback language.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUILanguageInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetUILanguageInfo([In] MUIFlags dwFlags, [In] IntPtr pwmszLanguage, [In] IntPtr pwszFallbackLanguages,
            [In][Out] ref DWORD pcchFallbackLanguages, [Out] out DWORD pAttributes);

        /// <summary>
        /// <para>
        /// Returns the language identifier of the Region Format setting for the current user.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getuserdefaultlangid"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the language identifier for the current user as set under Control Panel > Clock, Language, and Region > Change date, time,
        /// or number formats > Formats tab > Format dropdown.
        /// For more information on language identifiers, see Language Identifier Constants and Strings.
        /// </returns>
        /// <remarks>
        /// The return value is not necessarily the same as that returned by <see cref="GetSystemDefaultLangID"/>, even for a single-user computer.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUserDefaultLangID", ExactSpelling = true, SetLastError = true)]
        public static extern LANGID GetUserDefaultLangID();

        /// <summary>
        /// <para>
        /// Returns the locale identifier for the user default locale.
        /// Caution
        /// If the user default locale is a custom locale, an application cannot accurately tag data with the value or exchange it.
        /// In this case, the application should use <see cref="GetUserDefaultLocaleName"/> in preference to <see cref="GetUserDefaultLCID"/>.
        /// Note
        /// Applications that are intended to run only on Windows Vista and later should use <see cref="GetUserDefaultLocaleName"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getuserdefaultlcid"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns the locale identifier for the user default locale, represented as <see cref="LOCALE_USER_DEFAULT"/>.
        /// If the user default locale is a custom locale, this function always returns <see cref="LOCALE_CUSTOM_DEFAULT"/>,
        /// regardless of the custom locale that is selected.
        /// For example, whether the user locale is Hawaiian (US), haw-US, or Fijiian (Fiji), fj-FJ, the function returns the same value.
        /// </returns>
        /// <remarks>
        /// This function can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUserDefaultLCID", ExactSpelling = true, SetLastError = true)]
        public static extern LCID GetUserDefaultLCID();

        /// <summary>
        /// <para>
        /// Retrieves the user default locale name.
        /// Note
        /// The application should call this function in preference to <see cref="GetUserDefaultLCID"/> if designed to run only on Windows Vista and later.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getuserdefaultlocalename"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleName">
        /// Pointer to a buffer in which this function retrieves the locale name.
        /// </param>
        /// <param name="cchLocaleName">
        /// Size, in characters, of the buffer indicated by <paramref name="lpLocaleName"/>.
        /// The maximum possible length of a locale name, including a terminating null character, is <see cref="LOCALE_NAME_MAX_LENGTH"/>.
        /// This is the recommended size to supply in this parameter.
        /// </param>
        /// <returns>
        /// Returns the size of the buffer containing the locale name, including the terminating null character, if successful.
        /// Note
        /// On single-user systems, the return value is the same as that returned by <see cref="GetSystemDefaultLocaleName"/>.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// This function can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUserDefaultLocaleName", ExactSpelling = true, SetLastError = true)]
        public static extern int GetUserDefaultLocaleName([In] LPWSTR lpLocaleName, [In] int cchLocaleName);

        /// <summary>
        /// <para>
        /// Retrieves information about the geographical location of the user.
        /// For more information, see Table of Geographical Locations.
        /// <see cref="GetUserGeoID"/> is available for use in the operating systems specified in the Requirements section.
        /// It may be altered or unavailable in subsequent versions.
        /// Instead, use <see cref="GetUserDefaultGeoName"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getusergeoid"/>
        /// </para>
        /// </summary>
        /// <param name="GeoClass">
        /// Geographical location class to return.
        /// Possible values are defined by the <see cref="SYSGEOCLASS"/> enumeration.
        /// </param>
        /// <returns>
        /// Returns the geographical location identifier of the user if <see cref="SetUserGeoID"/> has been called before to set the identifier.
        /// If no geographical location identifier has been set for the user, the function returns <see cref="GEOID_NOT_AVAILABLE"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUserGeoID", ExactSpelling = true, SetLastError = true)]
        public static extern GEOID GetUserGeoID([In] GEOCLASS GeoClass);

        /// <summary>
        /// <para>
        /// Retrieves information about the display language setting.
        /// For more information, see User Interface Language Management.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-getuserpreferreduilanguages"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags identifying the language format to use for the process preferred UI languages.
        /// The flags are mutually exclusive, and the default is <see cref="MUI_LANGUAGE_NAME"/>.
        /// <see cref="MUI_LANGUAGE_ID"/>: Retrieve the language strings in language identifier format.
        /// <see cref="MUI_LANGUAGE_NAME"/>: Retrieve the language strings in language name format.
        /// </param>
        /// <param name="pulNumLanguages">
        /// Pointer to the number of languages retrieved in <paramref name="pwszLanguagesBuffer"/>.
        /// </param>
        /// <param name="pwszLanguagesBuffer">
        /// Optional.
        /// Pointer to a double null-terminated multi-string buffer in which the function retrieves an ordered,
        /// null-delimited list in preference order, starting with the most preferable.
        /// Alternatively if this parameter is set to <see cref="NULL"/> and <paramref name="pcchLanguagesBuffer"/> is set to 0,
        /// the function retrieves the required size of the language buffer in <paramref name="pcchLanguagesBuffer"/>.
        /// The required size includes the two null characters.
        /// </param>
        /// <param name="pcchLanguagesBuffer">
        /// Pointer to the size, in characters, for the language buffer indicated by <paramref name="pwszLanguagesBuffer"/>.
        /// On successful return from the function, the parameter contains the size of the retrieved language buffer.
        /// Alternatively if this parameter is set to 0 and <paramref name="pwszLanguagesBuffer"/> is set to <see cref="NULL"/>,
        /// the function retrieves the required size of the language buffer in <paramref name="pcchLanguagesBuffer"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// If the function fails for any other reason, the parameters <paramref name="pulNumLanguages"/> and <paramref name="pcchLanguagesBuffer"/> are undefined.
        /// </returns>
        /// <remarks>
        /// When <see cref="MUI_LANGUAGE_ID"/> is specified, the language strings retrieved will be hexadecimal language identifiers
        /// that do not include the leading 0x, and will be 4 characters in length.
        /// For example, en-US will be returned as "0409" and en as "0009".
        /// The display language cannot include more than one Language Interface Pack (LIP) language that corresponds to a supplemental locale.
        /// If the list includes more than one of these languages, and if the application specifies <see cref="MUI_LANGUAGE_ID"/> in the call to the function,
        /// the language buffer contains "1400" for that language.
        /// This string corresponds to the hexadecimal value of <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>.
        /// The language list retrieved by this function has the following characteristics:
        /// Each language represents a valid NLS locale.
        /// Each language is installed on the operating system.
        /// The list contains one entry for each language, with no duplicate entries.
        /// If the list is empty or does not meet these validation criteria, the system preferred UI languages list is used instead.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUserPreferredUILanguages", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetUserPreferredUILanguages([In] MUIFlags dwFlags, [Out] out ULONG pulNumLanguages,
            [In] IntPtr pwszLanguagesBuffer, [In][Out] ref ULONG pcchLanguagesBuffer);

        /// <summary>
        /// <para>
        /// Converts an internationalized domain name (IDN) or another internationalized label to a Unicode (wide character)
        /// representation of the ASCII string that represents the name in the Punycode transfer encoding syntax.
        /// Caution
        /// This function implements the RFC 3490: Internationalizing Domain Names in Applications (IDNA) standard algorithm for converting an IDN to Punycode.
        /// The standard introduces some security issues.
        /// One issue is that glyphs representing certain characters from different scripts might appear similar or even identical.
        /// For example, in many fonts, Cyrillic lowercase A ("а") is indistinguishable from Latin lowercase A ("a").
        /// There is no way to tell visually that "example.com" and "exаmple.com" are two different domain names,
        /// one with a Latin lowercase A in the name, the other with a Cyrillic lowercase A.
        /// For more information about IDN-related security concerns, see Handling Internationalized Domain Names (IDNs).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-idntoascii"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags specifying conversion options. The following table lists the possible values.
        /// <see cref="IDN_ALLOW_UNASSIGNED"/>:
        /// Note
        /// An application can set this value if it is just using a query string for normal lookup, as in a compare operation.
        /// However, the application should not set this value for a stored string, which is a string being prepared for storage.
        /// Allow unassigned code points to be included in the input string.
        /// The default is to not allow unassigned code points, and fail with an extended error code of <see cref="ERROR_INVALID_NAME"/>.
        /// This flag allows the function to process characters that are not currently legal in IDNs,
        /// but might be legal in later versions of the IDNA standard.
        /// If your application encodes unassigned code points as Punycode, the resulting domain names should be illegal.
        /// Security can be compromised if a later version of IDNA makes these names legal or if an application filters out the illegal characters
        /// to try to create a legal domain name.
        /// For more information, see Handling Internationalized Domain Names (IDNs).
        /// <see cref="IDN_USE_STD3_ASCII_RULES"/>:
        /// Filter out ASCII characters that are not allowed in STD3 names.
        /// The only ASCII characters allowed in the input Unicode string are letters, digits, and the hyphen-minus.
        /// The string cannot begin or end with the hyphen-minus. The function fails if the input Unicode string contains ASCII characters,
        /// such as "[", "]", or "/", that cannot occur in domain names.
        /// Note
        /// Some local networks can allow some of these characters in computer names.
        /// The function fails if the input Unicode string contains control characters (U+0001 through U+0020) or the "delete" character (U+007F).
        /// In either case, this flag has no effect on the non-ASCII characters that are allowed in the Unicode string.
        /// <see cref="IDN_EMAIL_ADDRESS"/>:
        /// Starting with Windows 8: Enable EAI algorithmic fallback for the local parts of email addresses (such as &lt;local&gt;@microsoft.com).
        /// The default is for this function to fail when an email address has an invalid address or syntax.
        /// An application can set this flag to enable Email Address Internationalization (EAI) to return a discoverable fallback address, if possible.
        /// For more information, see the IETF Email Address Internationalization (eai) Charter.
        /// <see cref="IDN_RAW_PUNYCODE"/>:
        /// Starting with Windows 8: Disable the validation and mapping of Punycode.
        /// </param>
        /// <param name="lpUnicodeCharStr">
        /// Pointer to a Unicode string representing an IDN or another internationalized label.
        /// </param>
        /// <param name="cchUnicodeChar">
        /// Count of characters in the input Unicode string indicated by <paramref name="lpUnicodeCharStr"/>.
        /// </param>
        /// <param name="lpASCIICharStr">
        /// Pointer to a buffer that receives a Unicode string consisting only of characters in the ASCII character set.
        /// On return from this function, the buffer contains the ASCII string equivalent of the string provided in <paramref name="lpUnicodeCharStr"/> under Punycode.
        /// Alternatively, the function can retrieve <see cref="NULL"/> for this parameter, if <paramref name="cchASCIIChar"/> is set to 0.
        /// In this case, the function returns the size required for this buffer.
        /// </param>
        /// <param name="cchASCIIChar">
        /// Size of the buffer indicated by <paramref name="lpASCIICharStr"/>.
        /// The application can set the parameter to 0 to retrieve <see cref="NULL"/> in <paramref name="lpASCIICharStr"/>.
        /// </param>
        /// <returns>
        /// Returns the number of characters retrieved in <paramref name="lpASCIICharStr"/> if successful.
        /// The retrieved string is null-terminated only if the input Unicode string is null-terminated.
        /// If the function succeeds and the value of <paramref name="cchASCIIChar"/> is 0,
        /// the function returns the required size, in characters including a terminating null character if it was part of the input buffer.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="RROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_NAME"/>. An invalid name was supplied to the function.Note that this error code catches all syntax errors.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// <see cref="ERROR_NO_UNICODE_TRANSLATION"/>. Invalid Unicode was found in a string.
        /// </returns>
        /// <remarks>
        /// The function does not null-terminate an output string if the input string length is explicitly specified without a terminating null character.
        /// To null-terminate an output string for this function, the application should supply -1 for the <paramref name="cchUnicodeChar"/> parameter
        /// or explicitly count the terminating null character for the input string.
        /// Note that the function always fails if the input string contains control characters (U+0001 through U+0020) or the "delete" character (U+007F).
        /// Since the character U+0000 can appear only as a terminating null character, the function always fails if U+0000 appears anywhere else in the input string.
        /// Windows XP, Windows Server 2003: No longer supported.
        /// The required header file and DLL are part of the Microsoft Internationalized Domain Name (IDN) Mitigation APIs, which are no longer available for download.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IdnToAscii", ExactSpelling = true, SetLastError = true)]
        public static extern int IdnToAscii([In] IDNFlags dwFlags, [In] LPCWSTR lpUnicodeCharStr, [In] int cchUnicodeChar,
            [In] LPWSTR lpASCIICharStr, [In] int cchASCIIChar);

        /// <summary>
        /// <para>
        /// Converts the Punycode form of an internationalized domain name (IDN) or another internationalized label to the normal Unicode UTF-16 encoding syntax.
        /// Caution
        /// This function implements the RFC 3490: Internationalizing Domain Names in Applications (IDNA) standard algorithm for converting an IDN to Punycode.
        /// The standard introduces some security issues.
        /// One issue is that glyphs representing certain characters from different scripts might appear similar or even identical.
        /// For example, in many fonts, Cyrillic lowercase A ("а") is indistinguishable from Latin lowercase A ("a").
        /// There is no way to tell visually that "example.com" and "exаmple.com" are two different domain names,
        /// one with a Latin lowercase A in the name, the other with a Cyrillic lowercase A.
        /// For more information about IDN-related security concerns, see Handling Internationalized Domain Names (IDNs).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-idntounicode"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags specifying conversion options. For detailed definitions, see the dwFlags parameter of <see cref="IdnToAscii"/>.
        /// </param>
        /// <param name="lpASCIICharStr">
        /// Pointer to a string representing the Punycode encoding of an IDN or another internationalized label.
        /// This string must consist only of ASCII characters, and can include Punycode-encoded Unicode.
        /// The function decodes Punycode values to their UTF-16 values.
        /// </param>
        /// <param name="cchASCIIChar">
        /// Count of characters in the input string indicated by <paramref name="lpASCIICharStr"/>.
        /// </param>
        /// <param name="lpUnicodeCharStr">
        /// Pointer to a buffer that receives a normal Unicode UTF-16 encoding equivalent to the Punycode value of the input string.
        /// Alternatively, the function can retrieve <see cref="NULL"/> for this parameter, if <paramref name="cchUnicodeChar"/> set to 0.
        /// In this case, the function returns the size required for this buffer.
        /// </param>
        /// <param name="cchUnicodeChar">
        /// Size, in characters, of the buffer indicated by <paramref name="lpUnicodeCharStr"/>. 
        /// The application can set the size to 0 to retrieve <see cref="NULL"/> in <paramref name="lpUnicodeCharStr"/> and have the function return the required buffer size.
        /// </param>
        /// <returns>
        /// Returns the number of characters retrieved in <paramref name="lpUnicodeCharStr"/> if successful.
        /// The retrieved string is null-terminated only if the input Unicode string is null-terminated.
        /// If the function succeeds and the value of <paramref name="cchUnicodeChar"/> is 0,
        /// the function returns the required size, in characters including a terminating null character if it was part of the input buffer.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="RROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_NAME"/>. An invalid name was supplied to the function.Note that this error code catches all syntax errors.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// <see cref="ERROR_NO_UNICODE_TRANSLATION"/>. Invalid Unicode was found in a string.
        /// </returns>
        /// <remarks>
        /// See Remarks for <see cref="IdnToAscii"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IdnToUnicode", ExactSpelling = true, SetLastError = true)]
        public static extern int IdnToUnicode([In] IDNFlags dwFlags, [In] LPCWSTR lpASCIICharStr, [In] int cchASCIIChar,
            [In] LPWSTR lpUnicodeCharStr, [In] int cchUnicodeChar);

        /// <summary>
        /// <para>
        /// Determines if a specified character is a lead byte for the system default Windows ANSI code page (<see cref="CP_ACP"/>).
        /// A lead byte is the first byte of a two-byte character in a double-byte character set (DBCS) for the code page.
        /// To use a different code page, your application should use the <see cref="IsDBCSLeadByteEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isdbcsleadbyte"/>
        /// </para>
        /// </summary>
        /// <param name="TestChar">
        /// The character to test.
        /// </param>
        /// <returns>
        /// Returns a <see cref="TRUE"/> value if the test character is potentially a lead byte.
        /// The function returns <see cref="FALSE"/> if the test character is not a lead byte or if it is a single-byte character.
        /// To get extended error information, the application can call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function does not validate the presence or validity of a trail byte.
        /// Therefore, <see cref="MultiByteToWideChar"/> might not recognize a sequence that the application
        /// using <see cref="IsDBCSLeadByte"/> reports as a lead byte.
        /// The application can easily become unsynchronized with the results of <see cref="MultiByteToWideChar"/>,
        /// potentially leading to unexpected errors or buffer size mismatches.
        /// In general, instead of attempting low-level manipulation of code page data,
        /// applications should use <see cref="MultiByteToWideChar"/> to convert the data to UTF-16 and work with it in that encoding.
        /// Lead byte values are specific to each distinct DBCS.
        /// Some byte values can appear in a single code page as both the lead and trail byte of a DBCS character.
        /// To make sense of a DBCS string, an application normally starts at the beginning of a string and scans forward,
        /// keeping track when it encounters a lead byte, and treating the next byte as the trailing part of the same character.
        /// If the application must back up, it should use <see cref="CharPrev"/> instead of attempting to develop its own algorithm.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsDBCSLeadByte", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsDBCSLeadByte([In] BYTE TestChar);

        /// <summary>
        /// <para>
        /// Determines if a specified character is potentially a lead byte.
        /// A lead byte is the first byte of a two-byte character in a double-byte character set (DBCS) for the code page.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isdbcsleadbyteex"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// Identifier of the code page used to check lead byte ranges.
        /// This parameter can be one of the code page identifiers defined in Unicode and Character Set Constants
        /// or one of the following predefined values.
        /// This function validates lead byte values only in code pages 932, 936, 949, 950, and 1361.
        /// <see cref="CP_ACP"/>: Use system default Windows ANSI code page.
        /// <see cref="CP_MACCP"/>: Use the system default Macintosh code page.
        /// <see cref="CP_OEMCP"/>: Use system default OEM code page.
        /// <see cref="CP_THREAD_ACP"/>: Use the Windows ANSI code page for the current thread. 
        /// </param>
        /// <param name="TestChar">
        /// The character to test.
        /// </param>
        /// <returns>
        /// Returns a nonzero value if the byte is a lead byte.
        /// The function returns 0 if the byte is not a lead byte or if the character is a single-byte character.
        /// To get extended error information, the application can call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Note
        /// This function does not validate the presence or validity of a trail byte.
        /// Therefore, <see cref="MultiByteToWideChar"/> might not recognize a sequence
        /// that the application using <see cref="IsDBCSLeadByte"/> reports as a lead byte.
        /// The application can easily become unsynchronized with the results of <see cref="MultiByteToWideChar"/>,
        /// potentially leading to unexpected errors or buffer size mismatches.
        /// In general, instead of attempting low-level manipulation of code page data,
        /// applications should use <see cref="MultiByteToWideChar"/> to convert the data to UTF-16 and work with it in that encoding.
        /// Lead byte values are specific to each distinct DBCS.
        /// Some byte values can appear in a single code page as both the lead and trail byte of a DBCS character.
        /// Thus, <see cref="IsDBCSLeadByteEx"/> can only indicate a potential lead byte value.
        /// To make sense of a DBCS string, an application normally starts at the beginning of the string and scans forward,
        /// keeping track when it encounters a lead byte, and treating the next byte as the trailing part of the same character.
        /// To back up, the application should use <see cref="CharPrevExA"/> instead of attempting to develop its own algorithm.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsDBCSLeadByteEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsDBCSLeadByteEx([In] UINT CodePage, [In] BYTE TestChar);

        /// <summary>
        /// <para>
        /// Determines if each character in a string has a defined result for a specified NLS capability.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isnlsdefinedstring"/>
        /// </para>
        /// </summary>
        /// <param name="Function">
        /// NLS capability to query.
        /// This value must be <see cref="COMPARE_STRING"/>. See the <see cref="SYSNLS_FUNCTION"/> enumeration.
        /// </param>
        /// <param name="dwFlags">
        /// Flags defining the function. Must be 0.
        /// </param>
        /// <param name="lpVersionInformation">
        /// Pointer to an <see cref="NLSVERSIONINFO"/> structure containing version information.
        /// Typically, the information is obtained by calling <see cref="GetNLSVersion"/>.
        /// The application sets this parameter to <see cref="NullRef{NLSVERSIONINFO}"/> if the function is to use the current version.
        /// </param>
        /// <param name="lpString">
        /// Pointer to the UTF-16 string to examine.
        /// </param>
        /// <param name="cchStr">
        /// Number of UTF-16 characters in the string indicated by <paramref name="lpString"/>.
        /// This count can include a terminating null character.
        /// If the terminating null character is included in the character count,
        /// it does not affect the checking behavior because the terminating null character is always defined.
        /// The application should supply -1 to indicate that the string is null-terminated.
        /// In this case, the function itself calculates the string length.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, only if the input string is valid, or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>.Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// This function differentiates between defined and undefined strings,
        /// so that an application such as Active Directory can reject strings with undefined code points.
        /// Use of the function can minimize the necessity for the application to re-index its database.
        /// For more information, see Handling Sorting in Your Applications.
        /// For example, if Function is set to <see cref="COMPARE_STRING"/>, <see cref="IsNLSDefinedString"/> checks for undefined code points,
        /// surrogate pairs that represent undefined Unicode characters, or ill-formed surrogate pairs.
        /// If the function returns <see cref="TRUE"/> for a particular string, the results,
        /// as retrieved by <see cref="CompareString"/> or <see cref="LCMapString"/> with <see cref="LCMAP_SORTKEY"/> set,
        /// are guaranteed to be identical as long as the corresponding NLS version does not change.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsNLSDefinedString", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsNLSDefinedString([In] SYSNLS_FUNCTION Function, [In] DWORD dwFlags, [In] in NLSVERSIONINFO lpVersionInformation,
            [In] LPCWSTR lpString, [In] INT cchStr);

        /// <summary>
        /// <para>
        /// Determines if a specified code page is valid.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isvalidcodepage"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// Code page identifier for the code page to check.
        /// </param>
        /// <returns>
        /// Returns a <see cref="TRUE"/> value if the code page is valid, or <see cref="FALSE"/> if the code page is invalid.
        /// </returns>
        /// <remarks>
        /// A code page is considered valid only if it is installed on the operating system. Unicode is preferred.
        /// Starting with Windows Vista, all code pages that can be installed are loaded by default.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsValidCodePage", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsValidCodePage([In] UINT CodePage);

        /// <summary>
        /// <para>
        /// Determines if a language group is installed or supported on the operating system.
        /// For more information, see NLS Terminology.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isvalidlanguagegroup"/>
        /// </para>
        /// </summary>
        /// <param name="LanguageGroup">
        /// Identifier of language group to validate. This parameter can have one of the following values:
        /// <see cref="LGRPID_ARABIC"/>, <see cref="LGRPID_ARMENIAN"/>, <see cref="LGRPID_BALTIC"/>,
        /// <see cref="LGRPID_CENTRAL_EUROPE"/>, <see cref="LGRPID_CYRILLIC"/>, <see cref="LGRPID_GEORGIAN"/>,
        /// <see cref="LGRPID_GREEK"/>, <see cref="LGRPID_HEBREW"/>, <see cref="LGRPID_INDIC"/>,
        /// <see cref="LGRPID_JAPANESE"/>, <see cref="LGRPID_KOREAN"/>, <see cref="LGRPID_SIMPLIFIED_CHINESE"/>,
        /// <see cref="LGRPID_TRADITIONAL_CHINESE"/>, <see cref="LGRPID_THAI"/>, <see cref="LGRPID_TURKIC"/>,
        /// <see cref="LGRPID_TURKISH"/>, <see cref="LGRPID_VIETNAMESE"/>, <see cref="LGRPID_WESTERN_EUROPE"/>
        /// </param>
        /// <param name="dwFlags">
        /// Flag specifying the validity test to apply to the language group identifier.
        /// This parameter can be set to one of the following values.
        /// <see cref="LGRPID_INSTALLED"/>: Determine if language group identifier is both supported and installed.
        /// <see cref="LGRPID_SUPPORTED"/>: Determine if language group identifier is supported.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the language group identifier passes the specified validity test, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// If the <see cref="LGRPID_INSTALLED"/> flag is specified and this function returns <see cref="TRUE"/>,
        /// the language group identifier is both supported and installed on the operating system.
        /// If the <see cref="LGRPID_SUPPORTED"/> flag is specified and this function returns <see cref="TRUE"/>, 
        /// the language group identifier is supported in the release, but not necessarily installed on the operating system.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsValidLanguageGroup", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsValidLanguageGroup([In] LGRPID LanguageGroup, [In] LGRPIDFlags dwFlags);

        /// <summary>
        /// <para>
        /// Determines if the specified locale is installed or supported on the operating system.
        /// For more information, see Locales and Languages.
        /// IsValidLocale is available for use in the operating systems specified in the Requirements section.
        /// It may be altered or unavailable in subsequent versions.
        /// Instead, use <see cref="IsValidLocaleName"/> to determine the validity of a supplemental locale.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isvalidlocale"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier of the locale to validate.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/> Windows Server 2003, Windows XP and Windows 2000:  This locale identifier is not supported.
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/> Windows Server 2003, Windows XP and Windows 2000:  This locale identifier is not supported.
        /// <see cref="LOCALE_CUSTOM_UNSPECIFIED"/> Windows Server 2003, Windows XP and Windows 2000:  This locale identifier is not supported.
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// </param>
        /// <param name="dwFlags">
        /// Flag specifying the validity test to apply to the locale identifier.
        /// This parameter can have one of the following values.
        /// <see cref="LCID_INSTALLED"/>: Determine if the locale identifier is both supported and installed.
        /// <see cref="LCID_SUPPORTED"/>: Determine if the locale identifier is supported.
        /// 0x39:
        /// Do not use. Instead, use <see cref="LCID_INSTALLED"/>.
        /// Windows Server 2008, Windows Vista, Windows Server 2003, Windows XP and Windows 2000:
        /// Setting <paramref name="dwFlags"/> to 0x39 is a special case that can behave like <see cref="LCID_INSTALLED"/> for some locales on some versions of Windows.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the locale identifier passes the specified validity test.
        /// The function returns <see cref="FALSE"/> if it does not succeed.
        /// </returns>
        /// <remarks>
        /// If the <see cref="LCID_INSTALLED"/> flag is specified and this function returns <see cref="TRUE"/>,
        /// the locale identifier is both supported and installed on the operating system.
        /// Having an identifier installed implies that the full level of language support is available for the indicated locale.
        /// Full support includes code page translation tables, keyboard layouts, fonts, and sorting and locale data.
        /// If <see cref="LCID_SUPPORTED"/> is specified and this function returns <see cref="FALSE"/>,
        /// the locale identifier is supported in the release, but not necessarily installed on the operating system.
        /// This function can handle data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsValidLocale", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsValidLocale([In] LCID Locale, [In] LCIDFlags dwFlags);

        /// <summary>
        /// <para>
        /// Determines if the specified locale name is valid for a locale that is installed or supported on the operating system.
        /// Note
        /// An application running only on Windows Vista and later should call this function in preference
        /// to <see cref="IsValidLocale"/> to determine the validity of a supplemental locale.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isvalidlocalename"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleName">
        /// Pointer to the locale name to validate.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the locale name is valid, or returns <see cref="FALSE"/> for an invalid name.
        /// </returns>
        /// <remarks>
        /// On Windows Vista and later, all supported locales should be installed on all operating systems.
        /// This function can handle the name of a custom locale.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsValidLocaleName", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsValidLocaleName([In] LPCWSTR lpLocaleName);

        /// <summary>
        /// <para>
        /// Determines if the NLS version is valid for a given NLS function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-isvalidnlsversion"/>
        /// </para>
        /// </summary>
        /// <param name="function">
        /// The NLS capability to query.
        /// This value must be <see cref="COMPARE_STRING"/>.
        /// See the <see cref="SYSNLS_FUNCTION"/> enumeration.
        /// </param>
        /// <param name="lpLocaleName">
        /// Pointer to a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>, <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>, <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="lpVersionInformation">
        /// Pointer to an <see cref="NLSVERSIONINFOEX"/> structure.
        /// The application must initialize the <see cref="NLSVERSIONINFOEX.dwNLSVersionInfoSize"/> member to <code>sizeof(NLSVERSIONINFOEX)</code>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the NLS version is valid, or <see cref="FALSE"/> if the version is invalid.
        /// </returns>
        /// <remarks>
        /// Initialize the <see cref="NLSVERSIONINFOEX"/> structure by calling <see cref="GetNLSVersionEx"/>.
        /// See the Remarks for <see cref="GetNLSVersionEx"/> for a discussion on how the members of <see cref="NLSVERSIONINFOEX"/> can be used
        /// to determine if a sort version has changed and you need to reindex data.
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsValidNLSVersion", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsValidNLSVersion([In] SYSNLS_FUNCTION function, [In] LPCWSTR lpLocaleName, [In] in NLSVERSIONINFOEX lpVersionInformation);

        /// <summary>
        /// <para>
        /// For a locale specified by identifier, maps one input character string to another using a specified transformation,
        /// or generates a sort key for the input string.
        /// Note
        /// For interoperability reasons, the application should prefer the <see cref="LCMapStringEx"/> function to <see cref="LCMapString"/>
        /// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales.
        /// This recommendation applies especially to custom locales, including those created by Microsoft.
        /// Any application that will be run only on Windows Vista and later should use <see cref="LCMapStringEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-lcmapstringw"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier that specifies the locale.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// The following custom locale identifiers are also supported.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </param>
        /// <param name="dwMapFlags">
        /// Flags specifying the type of transformation to use during string mapping or the type of sort key to generate.
        /// For detailed definitions, see the dwMapFlags parameter of <see cref="LCMapStringEx"/>.
        /// </param>
        /// <param name="lpSrcStr">
        /// Pointer to a source string that the function maps or uses for sort key generation.
        /// This string cannot have a size of 0.
        /// </param>
        /// <param name="cchSrc">
        /// Size, in characters, of the source string indicated by <paramref name="lpSrcStr"/>.
        /// The size of the source string can include the terminating null character, but does not have to.
        /// If the terminating null character is included, the mapping behavior of the function is not greatly affected
        /// because the terminating null character is considered to be unsortable and always maps to itself.
        /// The application can set the parameter to any negative value to specify that the source string is null-terminated.
        /// In this case, if <see cref="LCMapString"/> is being used in its string-mapping mode, the function calculates the string length itself,
        /// and null-terminates the mapped string indicated by <paramref name="lpDestStr"/>.
        /// The application cannot set this parameter to 0.
        /// </param>
        /// <param name="lpDestStr">
        /// Pointer to a buffer in which this function retrieves the mapped string or a sort key.
        /// If the application is using the function to generate a sort key (<see cref="LCMAP_SORTKEY"/>):
        /// The sort key is stored in the buffer and treated as an opaque array of bytes.
        /// The stored values can include embedded 0 bytes at any position.
        /// The destination string can contain an odd number of bytes.
        /// The <see cref="LCMAP_BYTEREV"/> flag only reverses an even number of bytes.
        /// The last byte (odd-positioned) in the sort key is not reversed.
        /// If the caller explicitly requests a subset of the string, the destination string does not include a terminating null character
        /// unless the caller specified it in <paramref name="cchDest"/>.
        /// If this function fails, the destination buffer might contain either partial results or no results at all.
        /// In this case, all results should be considered invalid.
        /// Note
        /// When setting <see cref="LCMAP_UPPERCASE"/> or <see cref="LCMAP_LOWERCASE"/>, the destination string can use the same buffer as the source string.
        /// However, this is strongly discouraged, as some conditions may cause the returned cased string to be a different length.
        /// </param>
        /// <param name="cchDest">
        /// Size, in characters, of the destination string indicated by <paramref name="lpDestStr"/>.
        /// If the application is using the function for string mapping, it supplies a character count for this parameter.
        /// If space for a terminating null character is included in <paramref name="cchSrc"/>, cchDest must also include space for a terminating null character.
        /// If the application is using the function to generate a sort key, it supplies a byte count for the size.
        /// This byte count must include space for the sort key 0x00 terminator.
        /// The application can set cchDest to 0. In this case, the function does not use the <paramref name="lpDestStr"/> parameter
        /// and returns the required buffer size for the mapped string or sort key.
        /// </param>
        /// <returns>
        /// If the function succeeds when used for string mapping, it returns the number of characters
        /// in the translated string (see <paramref name="cchSrc"/> and <paramref name="cchDest"/> for more details).
        /// If the function succeeds when used for string mapping it returns the number of bytes in the sort key.
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// See Remarks for <see cref="LCMapStringEx"/>.
        /// The ANSI version of <see cref="LCMapString"/> maps strings to and from Unicode
        /// based on the default Windows (ANSI) code page associated with the specified locale.
        /// When the ANSI version of this function is used with a Unicode-only locale,
        /// the function can succeed because the operating system uses the <see cref="CP_ACP"/> value,
        /// representing the system default Windows ANSI code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark (?).
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LCMapStringW", ExactSpelling = true, SetLastError = true)]
        public static extern int LCMapString([In] LCID Locale, [In] LCMapStringFlags dwMapFlags, [In] LPCWSTR lpSrcStr,
            [In] int cchSrc, [In] LPWSTR lpDestStr, [In] int cchDest);

        /// <summary>
        /// <para>
        /// For a locale specified by name, maps an input character string to another using a specified transformation,
        /// or generates a sort key for the input string.
        /// Note
        /// The application should call this function in preference to <see cref="LCMapString"/> if designed to run only on Windows Vista and later.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-lcmapstringex"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocaleName">
        /// Pointer to a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>, <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>, <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="dwMapFlags">
        /// Flag specifying the type of transformation to use during string mapping or the type of sort key to generate.
        /// This parameter can have the following values.
        /// <see cref="LCMAP_BYTEREV"/>:
        /// Use byte reversal. For example, if the application passes in 0x3450 0x4822, the result is 0x5034 0x2248.
        /// <see cref="LCMAP_FULLWIDTH"/>:
        /// Use Unicode (wide) characters where applicable.
        /// This flag and <see cref="LCMAP_HALFWIDTH"/> are mutually exclusive.
        /// With this flag, the mapping may use Normalization Form C even if an input character is already full-width.
        /// For example, the string "は゛" (which is already full-width) is normalized to "ば". See Unicode normalization forms.
        /// <see cref="LCMAP_HALFWIDTH"/>:
        /// Use narrow characters where applicable. This flag and <see cref="LCMAP_FULLWIDTH"/> are mutually exclusive.
        /// <see cref="LCMAP_HIRAGANA"/>:
        /// Map all katakana characters to hiragana. This flag and <see cref="LCMAP_KATAKANA"/> are mutually exclusive.
        /// <see cref="LCMAP_KATAKANA"/>:
        /// Map all hiragana characters to katakana. This flag and <see cref="LCMAP_HIRAGANA"/> are mutually exclusive.
        /// <see cref="LCMAP_LINGUISTIC_CASING"/>:
        /// Use linguistic rules for casing, instead of file system rules (default).
        /// This flag is valid with <see cref="LCMAP_LOWERCASE"/> or <see cref="LCMAP_UPPERCASE"/> only.
        /// <see cref="LCMAP_LOWERCASE"/>:
        /// For locales and scripts capable of handling uppercase and lowercase, map all characters to lowercase.
        /// <see cref="LCMAP_HASH"/>:
        /// Return a hash of the raw sort weights of a string.
        /// Strings that appear equivalent typically return the same hash (for example, "hello" and "HELLO" with <see cref="LCMAP_IGNORECASE"/>).
        /// However, some complex cases, such as East Asian languages, can have similar strings with identical weights that compare as equal but do not return the same hash.
        /// <see cref="LCMAP_HASH"/> requires that the output buffer be of size sizeof(int)
        /// <see cref="LCMAP_SIMPLIFIED_CHINESE"/>:
        /// Map traditional Chinese characters to simplified Chinese characters.
        /// This flag and <see cref="LCMAP_TRADITIONAL_CHINESE"/> are mutually exclusive.
        /// <see cref="LCMAP_SORTHANDLE"/>:
        /// The use of a sort handle results in minimal performance improvements and is discouraged.
        /// Return a token representing the resolved sort parameters for the locale (like locale name),
        /// so future calls can pass NULL for the sort name and pass the previously queried sort handle
        /// as the last parameter (<paramref name="sortHandle"/>) in subsequent calls to <see cref="CompareStringEx"/> or <see cref="LCMapStringEx"/>.
        /// <see cref="LCMAP_SORTHANDLE"/> requires that the output buffer be of size sizeof(lparam)
        /// <see cref="LCMAP_SORTKEY"/>:
        /// Produce a normalized sort key.
        /// If the <see cref="LCMAP_SORTKEY"/> flag is not specified, the function performs string mapping.
        /// For details of sort key generation and string mapping, see the Remarks section.
        /// <see cref="LCMAP_TITLECASE"/>:
        /// Windows 7: Map all characters to title case, in which the first letter of each major word is capitalized.
        /// <see cref="LCMAP_TRADITIONAL_CHINESE"/>:
        /// Map simplified Chinese characters to traditional Chinese characters.
        /// This flag and <see cref="LCMAP_SIMPLIFIED_CHINESE"/> are mutually exclusive.
        /// <see cref="LCMAP_UPPERCASE"/>:
        /// For locales and scripts capable of handling uppercase and lowercase, map all characters to uppercase.
        /// The following flags can be used alone, with one another, or with the <see cref="LCMAP_SORTKEY"/> and/or <see cref="LCMAP_BYTEREV"/> flags.
        /// However, they cannot be combined with the other flags listed above.
        /// <see cref="NORM_IGNORENONSPACE"/>:
        /// Ignore nonspacing characters.
        /// For many scripts (notably Latin scripts), <see cref="NORM_IGNORENONSPACE"/> coincides with <see cref="LINGUISTIC_IGNOREDIACRITIC"/>.
        /// Note
        /// <see cref="NORM_IGNORENONSPACE"/> ignores any secondary distinction, whether it is a diacritic or not.
        /// Scripts for Korean, Japanese, Chinese, and Indic languages, among others, use this distinction for purposes other than diacritics.
        /// <see cref="LINGUISTIC_IGNOREDIACRITIC"/> causes the function to ignore only actual diacritics, instead of ignoring the second sorting weight.
        /// <see cref="NORM_IGNORESYMBOLS"/>:
        /// Ignore symbols and punctuation.
        /// The flags listed below are used only with the <see cref="LCMAP_SORTKEY"/> flag.
        /// <see cref="LINGUISTIC_IGNORECASE"/>:
        /// Ignore case, as linguistically appropriate.
        /// <see cref="LINGUISTIC_IGNOREDIACRITIC"/>:
        /// Ignore nonspacing characters, as linguistically appropriate.
        /// Note
        /// This flag does not always produce predictable results when used with decomposed characters,
        /// that is, characters in which a base character and one or more nonspacing characters each have distinct code point values.
        /// <see cref="NORM_IGNORECASE"/>:
        /// Ignore case.
        /// For many scripts (notably Latin scripts), <see cref="NORM_IGNORECASE"/> coincides with <see cref="LINGUISTIC_IGNORECASE"/>.
        /// Note
        /// <see cref="NORM_IGNORECASE"/> ignores any tertiary distinction, whether it is actually linguistic case or not.
        /// For example, in Arabic and Indic scripts, this flag distinguishes alternate forms of a character, 
        /// but the differences do not correspond to linguistic case.
        /// <see cref="LINGUISTIC_IGNORECASE"/> causes the function to ignore only actual linguistic casing, instead of ignoring the third sorting weight.
        /// Note
        /// For double-byte character set (DBCS) locales, <see cref="NORM_IGNORECASE"/> has an effect on all Unicode characters
        /// as well as narrow (one-byte) characters, including Greek and Cyrillic characters.
        /// <see cref="NORM_IGNOREKANATYPE"/>:
        /// Do not differentiate between hiragana and katakana characters. Corresponding hiragana and katakana characters compare as equal.
        /// <see cref="NORM_IGNOREWIDTH"/>:
        /// Ignore the difference between half-width and full-width characters, for example, C a t == cat.
        /// The full-width form is a formatting distinction used in Chinese and Japanese scripts.
        /// <see cref="NORM_LINGUISTIC_CASING"/>:
        /// Use linguistic rules for casing, instead of file system rules (default).
        /// <see cref="SORT_DIGITSASNUMBERS"/>:
        /// Windows 7: Treat digits as numbers during sorting, for example, sort "2" before "10".
        /// <see cref="SORT_STRINGSORT"/>:
        /// Treat punctuation the same as symbols.
        /// </param>
        /// <param name="lpSrcStr">
        /// Pointer to a source string that the function maps or uses for sort key generation.
        /// This string cannot have a size of 0.
        /// </param>
        /// <param name="cchSrc">
        /// Size, in characters, of the source string indicated by <paramref name="lpSrcStr"/>.
        /// The size of the source string can include the terminating null character, but does not have to.
        /// If the terminating null character is included, the mapping behavior of the function is not greatly affected
        /// because the terminating null character is considered to be unsortable and always maps to itself.
        /// The application can set this parameter to any negative value to specify that the source string is null-terminated.
        /// In this case, if <see cref="LCMapStringEx"/> is being used in its string-mapping mode,
        /// the function calculates the string length itself, and null-terminates the mapped string indicated by <paramref name="lpDestStr"/>.
        /// The application cannot set this parameter to 0.
        /// </param>
        /// <param name="lpDestStr">
        /// Pointer to a buffer in which this function retrieves the mapped string or a sort key.
        /// If the application is using the function to generate a sort key (<see cref="LCMAP_SORTKEY"/>):
        /// The sort key is stored in the buffer and treated as an opaque array of bytes.
        /// The stored values can include embedded 0 bytes at any position.
        /// The destination string can contain an odd number of bytes.
        /// The <see cref="LCMAP_BYTEREV"/> flag only reverses an even number of bytes.
        /// The last byte (odd-positioned) in the sort key is not reversed.
        /// If the caller explicitly requests a subset of the string,
        /// the destination string does not include a terminating null character unless the caller specified it in <paramref name="cchDest"/>.
        /// If this function fails, the destination buffer might contain either partial results or no results at all.
        /// In this case, all results should be considered invalid.
        /// Note
        /// When setting <see cref="LCMAP_UPPERCASE"/> or <see cref="LCMAP_LOWERCASE"/>,
        /// the destination string can use the same buffer as the source string.
        /// However, this is strongly discouraged, as some conditions may cause the returned cased string to be a different length.
        /// </param>
        /// <param name="cchDest">
        /// Size, in characters, of the destination string indicated by <paramref name="dwMapFlags"/>.
        /// If the application is using the function for string mapping, it supplies a character count for this parameter.
        /// If space for a terminating null character is included in <paramref name="cchSrc"/>,
        /// <paramref name="cchDest"/> must also include space for a terminating null character.
        /// If the application is using the function to generate a sort key, it supplies a byte count for the size.
        /// This byte count must include space for the sort key 0x00 terminator.
        /// The application can set cchDest to 0. In this case, the function does not use the <paramref name="lpDestStr"/> parameter
        /// and returns the required buffer size for the mapped string or sort key.
        /// </param>
        /// <param name="lpVersionInformation">
        /// Pointer to an <see cref="NLSVERSIONINFOEX"/> structure that contains the version information about the relevant NLS capability;
        /// usually retrieved from <see cref="GetNLSVersionEx"/>.
        /// Windows Vista, Windows 7: Reserved; must set to <see cref="NullRef{NLSVERSIONINFOEX}"/>.
        /// </param>
        /// <param name="lpReserved">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <param name="sortHandle">
        /// Reserved; must be 0.
        /// Note
        /// <see cref="CompareStringEx"/> and <see cref="LCMapStringEx"/> can specify a sort handle (if the locale name is null).
        /// This use is discouraged for most apps.
        /// </param>
        /// <returns>
        /// If the function succeeds when used for string mapping, it returns the number of characters in the translated string
        /// (see <paramref name="cchSrc"/> and <paramref name="cchDest"/> for more details).
        /// If the function succeeds when used for string mapping it returns the number of bytes in the sort key.
        /// This function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>. A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// The application can use <see cref="LCMapString"/> or <see cref="LCMapStringEx"/> to generate a sort key.
        /// To do this, the application specifies <see cref="LCMAP_SORTKEY"/> for the <paramref name="dwMapFlags"/> parameter.
        /// For more information, see Handling Sorting in Your Applications.
        /// Note
        /// Sort keys are opaque byte streams.
        /// Callers should treat them as a byte array of the length returned by the API and not rely on any internal structure that may appear to be present.
        /// Zero, one or more of the bytes in the returned sort key could be 0. Absence or presence of a zero byte should not be expected.
        /// Another way for your application to use <see cref="LCMapString"/> or <see cref="LCMapStringEx"/> is in mapping strings.
        /// In this case, the application does not specify <see cref="LCMAP_SORTKEY"/> for the <paramref name="dwMapFlags"/> parameter,
        /// but supplies some other combination of flags.
        /// For more information, see Handling Sorting in Your Applications.
        /// Beginning in Windows Vista:
        /// This function can handle data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LCMapStringEx", ExactSpelling = true, SetLastError = true)]
        public static extern int LCMapStringEx([In] LPCWSTR lpLocaleName, [In] LCMapStringFlags dwMapFlags, [In] LPCWSTR lpSrcStr,
            [In] int cchSrc, [In] LPWSTR lpDestStr, [In] int cchDest, [In] in NLSVERSIONINFO lpVersionInformation,
            [In] LPVOID lpReserved, [In] LPARAM sortHandle);

        /// <summary>
        /// <para>
        /// Converts a locale name to a locale identifier.
        /// Note
        /// For custom locales, including those created by Microsoft, your applications should prefer locale names over locale identifiers.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-localenametolcid"/>
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// Pointer to a null-terminated string representing a locale name, or one of the following predefined values.
        /// <see cref="LOCALE_NAME_INVARIANT"/>, <see cref="LOCALE_NAME_SYSTEM_DEFAULT"/>, <see cref="LOCALE_NAME_USER_DEFAULT"/>
        /// </param>
        /// <param name="dwFlags">
        /// Prior to Windows 7: Reserved; should always be 0.
        /// Beginning in Windows 7: Can be set to <see cref="LOCALE_ALLOW_NEUTRAL_NAMES"/> to allow the return of a neutral LCID.
        /// </param>
        /// <returns>
        /// Returns the locale identifier corresponding to the locale name if successful.
        /// If the supplied locale name corresponds to a custom locale that is the user default, this function returns <see cref="LOCALE_CUSTOM_DEFAULT"/>.
        /// If the locale name corresponds to a custom locale that is not the user default, the function returns <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>.
        /// If the locale provided is a transient locale or a CLDR (Unicode Common Locale Data Repository) locale, then the <see cref="LCID"/> returned is 0x1000.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// Beginning in Windows 8:
        /// If your app passes language tags to this function from the Windows.Globalization namespace,
        /// it must first convert the tags by calling <see cref="ResolveLocaleName"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocaleNameToLCID", ExactSpelling = true, SetLastError = true)]
        public static extern LCID LocaleNameToLCID([In] LPCWSTR lpName, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// Finds a possible locale name match for the supplied name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-resolvelocalename"/>
        /// </para>
        /// </summary>
        /// <param name="lpNameToResolve">
        /// Pointer to a name to resolve, for example, "en-XA" for English (Private Use).
        /// </param>
        /// <param name="lpLocaleName">
        /// Pointer to a buffer in which this function retrieves the locale name that is the match for the input name.
        /// For example, the match for the name "en-XA" is "en-US" for English (United States).
        /// Note  If the function fails, the state of the output buffer is not guaranteed to be accurate.
        /// In this case, the application should check the return value and error status set by the function to determine the correct course of action.
        /// </param>
        /// <param name="cchLocaleName">
        /// Size, in characters, of the buffer indicated by <paramref name="lpLocaleName"/>.
        /// The maximum possible length of a locale name, including a terminating null character, is the value of <see cref="LOCALE_NAME_MAX_LENGTH"/>.
        /// This is the recommended size to supply in this parameter.
        /// </param>
        /// <returns>
        /// Returns the size of the buffer containing the locale name, including the terminating null character, if successful.
        /// The function returns 0 if it does not succeed.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>: A supplied buffer size was not large enough, or it was incorrectly set to <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// The retrieved locale name indicates a specific locale, including language and country/region, even if the input language is neutral.
        /// For example, an input of "en" for English (United States) causes the function to retrieve "en-US".
        /// This function can retrieve data from custom locales.
        /// Data is not guaranteed to be the same from computer to computer or between runs of an application,
        /// nor does the return of a valid locale guarantee that it will be valid on another computer.
        /// If your application must persist or transmit data, see Using Persistent Locale Data.
        /// Beginning in Windows 8:
        /// Language tags obtained from the Windows.Globalization namespace must be converted by <see cref="ResolveLocaleName"/>
        /// before they can be used with any National Language Support functions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ResolveLocaleName", ExactSpelling = true, SetLastError = true)]
        public static extern int ResolveLocaleName([In] LPCWSTR lpNameToResolve, [In] LPWSTR lpLocaleName, [In] int cchLocaleName);

        /// <summary>
        /// <para>
        /// Sets an item of locale information for a calendar.
        /// For more information, see Date and Calendar.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-setcalendarinfow"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier that specifies the locale.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// The following custom locale identifiers are also supported.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </param>
        /// <param name="Calendar">
        /// Calendar identifier for the calendar for which to set information.
        /// </param>
        /// <param name="CalType">
        /// Type of calendar information to set.
        /// Only the following <see cref="CALTYPE"/> values are valid for this function.
        /// The <see cref="CAL_USE_CP_ACP"/> constant is only meaningful for the ANSI version of the function.
        /// <see cref="CAL_USE_CP_ACP"/>
        /// <see cref="CAL_ITWODIGITYEARMAX"/>
        /// The application can specify only one calendar identifier per call to this function.
        /// An exception can be made if the application uses the binary OR operator
        /// to combine <see cref="CAL_USE_CP_ACP"/> with any valid <see cref="CALTYPE"/> value defined in Calendar Type Information.
        /// </param>
        /// <param name="lpCalData">
        /// Pointer to a null-terminated calendar information string.
        /// The information must be in the format of the specified calendar type.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_INTERNAL_ERROR"/>. An unexpected error occurred in the function.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// This function only affects the user override portion of the calendar settings. It does not set the system defaults.
        /// Calendar information is always passed as a null-terminated Unicode string in the Unicode version of this function,
        /// and as a null-terminated ANSI string in the ANSI version.
        /// No integers are allowed by this function. Any numeric values must be specified as either Unicode or ANSI text.
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the function can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark (?).
        /// <see cref="CAL_ITWODIGITYEARMAX"/> can be used with any calendar, even if the calendar is not supported for the specified locale.
        /// To avoid complications, the application should call <see cref="EnumCalendarInfo"/> to ensure that the calendar is supported for the locale of interest.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCalendarInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCalendarInfo([In] LCID Locale, [In] CALID Calendar, [In] CALTYPE CalType, [In] LPCWSTR lpCalData);

        /// <summary>
        /// <para>
        /// Sets an item of information in the user override portion of the current locale.
        /// This function does not set the system defaults.
        /// Caution
        /// Because this function modifies values for all applications,
        /// it should only be called by the regional and language options functionality of Control Panel, or a similar utility.
        /// If making an international change to system parameters,
        /// the calling application must broadcast the <see cref="WM_SETTINGCHANGE"/> message to avoid causing instabilities in other applications.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-setlocaleinfow"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// For the ANSI version of the function, the locale identifier of the locale with the code page used
        /// when interpreting the <paramref name="lpLCData"/> information.
        /// For the Unicode version, this parameter is ignored.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// The following custom locale identifiers are also supported.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>
        /// </param>
        /// <param name="LCType">
        /// Type of locale information to set.
        /// For valid constants see "Constants Used in the LCType Parameter of GetLocaleInfo,
        /// GetLocaleInfoEx, and SetLocaleInfo" section of Locale Information Constants.
        /// The application can specify only one value per call,
        /// but it can use the binary OR operator to combine <see cref="LOCALE_USE_CP_ACP"/> with any other constant.
        /// </param>
        /// <param name="lpLCData">
        /// Pointer to a null-terminated string containing the locale information to set.
        /// The information must be in the format specific to the specified constant.
        /// The application uses a Unicode string for the Unicode version of the function, and an ANSI string for the ANSI version.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return one of the following error codes:
        /// <see cref="ERROR_ACCESS_DISABLED_BY_POLICY"/>. The group policy of the computer or the user has forbidden this operation.
        /// <see cref="ERROR_INVALID_ACCESS"/>. The access code was invalid.
        /// <see cref="ERROR_INVALID_FLAGS"/>. The values supplied for flags were not valid.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// This function writes to the registry, where it sets values that are associated with a particular user instead of a particular application.
        /// These registry values affect the behavior of other applications run by the user.
        /// As a rule, an application should call this function only when the user has explicitly requested the changes.
        /// The registry settings should not be changed for the convenience of a single application.
        /// For the <paramref name="LCType"/> parameter, the application should set <see cref="LOCALE_USE_CP_ACP"/>
        /// to use the operating system ANSI code page instead of the locale code page for string translation.
        /// When the ANSI version of this function is used with a Unicode-only locale identifier,
        /// the function can succeed because the operating system uses the system code page.
        /// However, characters that are undefined in the system code page appear in the string as a question mark (?).
        /// As of Windows Vista, the <see cref="LOCALE_SDATE"/> and <see cref="LOCALE_STIME"/> constants are obsolete.
        /// Do not use these constants. Use <see cref="LOCALE_SSHORTDATE"/> and <see cref="LOCALE_STIMEFORMAT"/> instead.
        /// A custom locale might not have a single, uniform separator character within the date or time format:
        /// for example, a format such as "12/31, 2006" or "03:56'23" might be valid.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetLocaleInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetLocaleInfo([In] LCID Locale, [In] LCTYPE LCType, [In] LPCWSTR lpLCData);

        /// <summary>
        /// <para>
        /// Sets the process preferred UI languages for the application process.
        /// For more information, see User Interface Language Management.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-setprocesspreferreduilanguages"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags identifying the language format to use for the process preferred UI languages. 
        /// The flags are mutually exclusive, and the default is <see cref="MUI_LANGUAGE_NAME"/>.
        /// We recommend that you use <see cref="MUI_LANGUAGE_NAME"/> instead of <see cref="MUI_LANGUAGE_ID"/>.
        /// <see cref="MUI_LANGUAGE_ID"/>: The input parameter language strings are in language identifier format.
        /// <see cref="MUI_LANGUAGE_NAME"/>: The input parameter language strings are in language name format.
        /// </param>
        /// <param name="pwszLanguagesBuffer">
        /// Pointer to a double null-terminated multi-string buffer that contains an ordered, null-delimited list in decreasing order of preference.
        /// If there are more than five languages in the buffer, the function only sets the first five valid languages.
        /// Alternatively, this parameter can contain <see cref="NULL"/> if no language list is required.
        /// In this case, the function clears the preferred UI languages for the process.
        /// </param>
        /// <param name="pulNumLanguages">
        /// Pointer to the number of languages that has been set in the process language list from the input buffer, up to a maximum of five.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>, which can return the following error code:
        /// <see cref="ERROR_INVALID_PARAMETER"/>. An invalid parameter is specified.
        /// If the process preferred UI languages list is empty or if the languages specified for the process are not valid,
        /// the function succeeds and sets 0 in the <paramref name="pulNumLanguages"/> parameter.
        /// </returns>
        /// <remarks>
        /// Ideally, applications will call <see cref="SetProcessPreferredUILanguages"/> as soon as possible after launching.
        /// After this function returns, the application can call <see cref="GetProcessPreferredUILanguages"/> to verify and examine the resulting language list.
        /// When <see cref="MUI_LANGUAGE_ID"/> is specified, the input parameter language strings must use hexadecimal language identifiers
        /// that do not include the leading 0x, and are 4 characters in length.
        /// For example, en-US should be passed as "0409" and en as "0009".
        /// Note 
        /// Use of <see cref="MUI_LANGUAGE_NAME"/> is recommended over <see cref="MUI_LANGUAGE_ID"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessPreferredUILanguages", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessPreferredUILanguages([In] MUIFlags dwFlags, [In] IntPtr pwszLanguagesBuffer, [Out] out ULONG pulNumLanguages);

        /// <summary>
        /// <para>
        /// Sets the current locale of the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-setthreadlocale"/>
        /// </para>
        /// </summary>
        /// <param name="Locale">
        /// Locale identifier that specifies the locale.
        /// You can use the <see cref="MAKELCID"/> macro to create a locale identifier or use one of the following predefined values.
        /// <see cref="LOCALE_CUSTOM_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>,
        /// <see cref="LOCALE_INVARIANT"/>, <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>
        /// </param>
        /// <returns>
        /// The function should return an <see cref="LCID"/> on success.
        /// This is the <see cref="LCID"/> of the previous thread locale.
        /// </returns>
        /// <remarks>
        /// When a thread is created, it uses the user locale.
        /// This value is returned by <see cref="GetUserDefaultLCID"/>.
        /// The user locale can be modified for future processes and thread creation using the regional and language options portion of the Control Panel.
        /// The thread locale can also be changed using <see cref="SetThreadLocale"/>.
        /// <see cref="SetThreadLocale"/> affects the selection of resources with a LANGUAGE statement.
        /// The statement affects such functions as <see cref="CreateDialog"/>, <see cref="DialogBox"/>,
        /// <see cref="LoadMenu"/>, <see cref="LoadString"/>, and <see cref="FindResource"/>.
        /// It sets the code page implied by <see cref="CP_THREAD_ACP"/>, but does not affect <see cref="FindResourceEx"/>.
        /// For more information, see Code Page Identifiers.
        /// Windows Vista and later:
        /// Do not use <see cref="SetThreadLocale"/> to select a user interface language.
        /// The resource loader selects the resource that is defined in the .rc file with a LANGUAGE statement,
        /// or the application can use <see cref="FindResourceEx"/>.
        /// Additionally, the application can use <see cref="SetThreadUILanguage"/>.
        /// Windows 2000, Windows XP: Do not use <see cref="SetThreadLocale"/> to select a user interface language.
        /// To select the resource that is defined in the .rc file with a LANGUAGE statement,
        /// the application must use the <see cref="FindResourceEx"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadLocale", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadLocale([In] LCID Locale);

        /// <summary>
        /// <para>
        /// Sets the thread preferred UI languages for the current thread.
        /// For more information, see User Interface Language Management.
        /// Note
        /// This function is also used by the operating system to identify languages that are safe to use on the Windows console.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-setthreadpreferreduilanguages"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags identifying format and filtering for the languages to set.
        /// The following format flags specify the language format to use for the thread preferred UI languages.
        /// The flags are mutually exclusive, and the default is <see cref="MUI_LANGUAGE_NAME"/>.
        /// We recommend that you use <see cref="MUI_LANGUAGE_NAME"/> instead of <see cref="MUI_LANGUAGE_ID"/>.
        /// <see cref="MUI_LANGUAGE_ID"/>: The input parameter language strings are in language identifier format.
        /// <see cref="MUI_LANGUAGE_NAME"/>: The input parameter language strings are in language name format.
        /// The following filtering flags specify filtering for the language list.
        /// The flags are mutually exclusive.
        /// By default, neither <see cref="MUI_COMPLEX_SCRIPT_FILTER"/> nor <see cref="MUI_CONSOLE_FILTER"/> is set.
        /// For more information about the filtering flags, see the Remarks section.
        /// <see cref="MUI_COMPLEX_SCRIPT_FILTER"/>:
        /// <see cref="GetThreadPreferredUILanguages"/> should replace with the appropriate fallback all languages having complex scripts.
        /// When this flag is specified, <see cref="NULL"/> must be passed for all other parameters.
        /// <see cref="MUI_CONSOLE_FILTER"/>:
        /// <see cref="GetThreadPreferredUILanguages"/> should replace with the appropriate fallback all languages
        /// that cannot display properly in a console window with the current operating system settings.
        /// When this flag is specified, <see cref="NULL"/> must be passed for all other parameters.
        /// <see cref="MUI_RESET_FILTERS"/>:
        /// Reset the filtering for the language list by removing any other filter settings.
        /// When this flag is specified, <see cref="NULL"/> must be passed for all other parameters.
        /// After setting this flag, the application can call <see cref="GetThreadPreferredUILanguages"/> to retrieve the complete unfiltered list.
        /// </param>
        /// <param name="pwszLanguagesBuffer">
        /// Pointer to a double null-terminated multi-string buffer that contains an ordered,
        /// null-delimited list, in the format specified by <paramref name="dwFlags"/>.
        /// To clear the thread preferred UI languages list, an application sets this parameter to a null string or an empty double null-terminated string.
        /// If an application clears a language list, it should specify either a format flag or 0 for the <paramref name="dwFlags"/> parameter.
        /// When the application specifies one of the filtering flags, it must set this parameter to <see cref="NULL"/>.
        /// In this case, the function succeeds, but does not reset the thread preferred languages.
        /// </param>
        /// <param name="pulNumLanguages">
        /// Pointer to the number of languages that the function has set in the thread preferred UI languages list.
        /// When the application specifies one of the filtering flags, the function must set this parameter to <see cref="NullRef{ULONG}"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// When the application loads resources after a call to this function,
        /// the thread-specific preferences take priority over the languages preferred by the user.
        /// This function can set up to five preferred languages for the thread, in order of preference.
        /// If the language buffer contains more than five valid languages, the function sets the first five valid languages and ignores the rest.
        /// If the application calls this function with the <see cref="MUI_LANGUAGE_ID"/> flag set,
        /// the strings in the language list must use hexadecimal language identifiers that do not include the leading 0x, and are 4 characters in length.
        /// For example, en-US should be passed as "0409" and en as "0009".
        /// When <see cref="MUI_LANGUAGE_ID"/> is specified, the hexadecimal values in the language list must each represent an actual language identifier.
        /// In particular, the following locale identifier values cannot be used to correspond to the language identifier:
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>, <see cref="LOCALE_CUSTOM_DEFAULT"/>,
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>,
        /// Calling this function with an empty language list and setting the <see cref="MUI_CONSOLE_FILTER"/> flag has the same effect
        /// as calling <see cref="SetThreadUILanguage"/> with the language identifier set to 0.
        /// The language is set appropriately for use in a console window.
        /// After this function returns, the application can call <see cref="GetThreadPreferredUILanguages"/> to verify and examine the resulting language list. 
        /// When <see cref="MUI_CONSOLE_FILTER"/> or <see cref="MUI_COMPLEX_FILTER"/> has been set by <see cref="SetThreadPreferredUILanguages"/>,
        /// the <see cref="GetThreadPreferredUILanguages"/> function replaces with the fallback the languages the console cannot display
        /// using the current operating system language setting.
        /// The fallback for a language is determined based on the value of <see cref="LOCALE_SCONSOLEFALLBACKNAME"/> for the language.
        /// Setting the <see cref="MUI_COMPLEX_SCRIPT_FILTER"/> flag in the call to <see cref="SetThreadPreferredUILanguages"/>
        /// causes <see cref="GetThreadPreferredUILanguages"/> to remove languages that the console cannot display with language
        /// that can only be rendered using Uniscribe, and insert the fallback language as the ultimate fallback.
        /// Examples of such languages are Arabic or the various Indic languages.
        /// Setting the <see cref="MUI_CONSOLE_FILTER"/> flag in the call to <see cref="SetThreadPreferredUILanguages"/>
        /// causes <see cref="GetThreadPreferredUILanguages"/> to remove languages the console cannot display
        /// with the current system setting and insert the fallback language as the ultimate fallback,
        /// because the console is limited to displaying characters from a single code page.
        /// For example, if the user language is Japanese (Japan), but the current console code page is the code page for Russian (Russia),
        /// the console displays Japanese-language text mostly as a series of character-not-found symbols.
        /// <see cref="GetThreadPreferredUILanguages"/> chooses a language from the fallback list that will be legible in the console.
        /// Note Resource-loading functions, such as <see cref="LoadString"/>, <see cref="LoadImage"/>,
        /// and <see cref="FindResource"/>, also make calls to <see cref="GetThreadPreferredUILanguages"/>.
        /// To change the code page, the application uses the setlocale function, or equivalent.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadPreferredUILanguages", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadPreferredUILanguages([In] MUIFlags dwFlags, [In] IntPtr pwszLanguagesBuffer, [Out] out ULONG pulNumLanguages);

        /// <summary>
        /// <para>
        /// Sets the user interface language for the current thread.
        /// Windows Vista and later:
        /// This function cannot clear the thread preferred UI languages list.
        /// Your MUI application should call <see cref="SetThreadPreferredUILanguages"/> to clear the language list.
        /// Windows XP:
        /// This function is limited to allowing the operating system to identify and set a value that is safe to use on the Windows console.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-setthreaduilanguage"/>
        /// </para>
        /// </summary>
        /// <param name="LangId">
        /// Language identifier for the user interface language for the thread.
        /// Windows Vista and later: The application can specify a language identifier of 0 or a nonzero identifier.
        /// For more information, see the Remarks section.
        /// Windows XP: The application can only set this parameter to 0.
        /// This setting causes the function to select the language that best supports the console display.
        /// For more information, see the Remarks section.
        /// </param>
        /// <returns>
        /// Returns the input language identifier if successful.
        /// If the input identifier is nonzero, the function returns that value.
        /// If the language identifier is 0, the function always succeeds and returns the identifier of the language that best supports the Windows console.
        /// See the Remarks section.
        /// If the input language identifier is nonzero and the function fails, the return value differs from the input language identifier.
        /// To get extended error information, the application can call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// When a thread is created, the thread user interface language setting is empty
        /// and the user interface for the thread is displayed in the user-selected language.
        /// This function enables the application to change the user interface language for the current running thread.
        /// Windows Vista and later:
        /// Calling this function and specifying 0 for the language identifier is identical
        /// to calling <see cref="SetThreadPreferredUILanguages"/> with the <see cref="MUI_CONSOLE_FILTER"/> flag set.
        /// If the application specifies a valid nonzero language identifier, the function sets a particular user interface language for the thread.
        /// After specifying 0 for the language identifier, the application cannot use any of the following constants to correspond to a language identifier:
        /// <see cref="LOCALE_SYSTEM_DEFAULT"/>, <see cref="LOCALE_USER_DEFAULT"/>, <see cref="LOCALE_CUSTOM_DEFAULT"/>,
        /// <see cref="LOCALE_CUSTOM_UI_DEFAULT"/>, <see cref="LOCALE_CUSTOM_UNSPECIFIED"/>,
        /// Windows XP:
        /// When the application calls this function with a language identifier of 0, the function first verifies
        /// that the current user interface does not require Uniscribe, and that it is supported by the console code page.
        /// If the user interface passes these tests, the function uses the supplied value.
        /// If not, the function changes the thread user interface language to a language that the Windows console can display.
        /// Windows XP does not support a concept of thread user interface language separate from thread locale.
        /// Therefore, this function changes the thread locale on Windows XP.
        /// It is easy for your application to set a thread to use the most appropriate language for console display,
        /// based on user and system preferred UI languages, the language for non-Unicode applications, and the capabilities of the console.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadUILanguage", ExactSpelling = true, SetLastError = true)]
        public static extern LANGID SetThreadUILanguage([In] LANGID LangId);

        /// <summary>
        /// <para>
        /// Sets the geographical location identifier for the user.
        /// This identifier should have one of the values described in Table of Geographical Locations.
        /// SetUserGeoID is available for use in the operating systems specified in the Requirements section.
        /// It may be altered or unavailable in subsequent versions.
        /// Instead, use <see cref="SetUserGeoName"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winnls-setthreadlocale"/>
        /// </para>
        /// </summary>
        /// <param name="GeoId">
        /// Identifier for the geographical location of the user.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// Windows XP, Windows Server 2003:
        /// This function does not supply extended error information.
        /// Thus it is not appropriate for an application to call <see cref="GetLastError"/> after this function.
        /// If the application does call <see cref="GetLastError"/>, it can return a value set by some previously called function.
        /// If this function does not succeed, the application can call <see cref="GetLastError"/>,
        /// which can return one of the following error codes:
        /// <see cref="ERROR_ACCESS_DISABLED_BY_POLICY"/>. The group policy of the computer or the user has forbidden this operation.
        /// <see cref="ERROR_INTERNAL_ERROR"/>. An unexpected error occurred in the function.
        /// <see cref="ERROR_INVALID_PARAMETER"/>. Any of the parameter values was invalid.
        /// </returns>
        /// <remarks>
        /// This function writes to the registry the geographical location for a particular user instead of a particular application.
        /// This action affects the behavior of other applications run by the user.
        /// As a rule, the application should call this function only when the user has explicitly requested changes,
        /// but not for purely application-specific reasons.
        /// <see cref="SetUserGeoID"/> is intended for use by applications that are designed to change user settings, such as the Windows Settings app.
        /// Other applications should not call this function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetUserGeoID", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetUserGeoID([In] GEOID GeoId);

        /// <summary>
        /// <para>
        /// Retrieves a description string for the language associated with a specified binary Microsoft language identifier.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/nf-winver-verlanguagenamew"/>
        /// </para>
        /// </summary>
        /// <param name="wLang">
        /// The binary language identifier.
        /// For a complete list of the language identifiers, see Language Identifiers.
        /// For example, the description string associated with the language identifier 0x040A is "Spanish (Traditional Sort)".
        /// If the identifier is unknown, the szLang parameter points to a default string ("Language Neutral").
        /// </param>
        /// <param name="szLang">
        /// The language specified by the <paramref name="wLang"/> parameter.
        /// </param>
        /// <param name="cchLang">
        /// The size, in characters, of the buffer pointed to by <paramref name="szLang"/>.
        /// </param>
        /// <returns>
        /// The return value is the size, in characters, of the string returned in the buffer.
        /// This value does not include the terminating null character.
        /// If the description string is smaller than or equal to the buffer, the entire description string is in the buffer.
        /// If the description string is larger than the buffer, the description string is truncated to the length of the buffer.
        /// If an error occurs, the return value is zero. Unknown language identifiers do not produce errors.
        /// </returns>
        /// <remarks>
        /// This function works on 16-, 32-, and 64-bit file images.
        /// Typically, an installation program uses this function to translate a language identifier returned by the <see cref="VerQueryValue"/> function.
        /// The text string may be used in a dialog box that asks the user how to proceed in the event of a language conflict.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "VerLanguageNameW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD VerLanguageName([In] DWORD wLang, [In] LPWSTR szLang, [In] DWORD cchLang);
    }
}
