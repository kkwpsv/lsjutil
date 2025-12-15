using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CodePages;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// Converts a character string or a single character to lowercase.
        /// If the operand is a character string, the function converts the characters in place.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-charlowerw"/>
        /// </para>
        /// </summary>
        /// <param name="lpsz">
        /// A null-terminated string, or specifies a single character.
        /// If the high-order word of this parameter is zero, the low-order word must contain a single character to be converted.
        /// </param>
        /// <returns>
        /// <para>
        /// If the operand is a character string, the function returns a pointer to the converted string.
        /// Because the string is converted in place, the return value is equal to <paramref name="lpsz"/>.
        /// </para>
        /// <para>
        /// If the operand is a single character, the return value is a 32-bit value
        /// whose high-order word is zero, and low-order word contains the converted character.
        /// </para>
        /// <para>
        /// There is no indication of success or failure. Failure is rare.
        /// There is no extended error information for this function; do not call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note that <see cref="CharLower"/> always maps uppercase I to lowercase I ("i"),
        /// even when the current language is Turkish or Azerbaijani.
        /// If you need a function that is linguistically sensitive in this respect, call <see cref="LCMapString"/>.
        /// </para>
        /// <para>
        /// Conversion to Unicode in the ANSI version of the function is done with the system default locale in all cases.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharLowerW", ExactSpelling = true)]
        public static extern LPWSTR CharLower([In] LPWSTR lpsz);

        /// <summary>
        /// <para>
        /// Converts uppercase characters in a buffer to lowercase characters.
        /// The function converts the characters in place.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-charlowerbuffw"/>
        /// </para>
        /// </summary>
        /// <param name="lpsz">
        /// A buffer containing one or more characters to be processed.
        /// </param>
        /// <param name="cchLength">
        /// The size, in characters, of the buffer pointed to by <paramref name="lpsz"/>.
        /// The function examines each character, and converts uppercase characters to lowercase characters.
        /// The function examines the number of characters indicated by <paramref name="cchLength"/>,
        /// even if one or more characters are null characters.
        /// </param>
        /// <returns>
        /// The return value is the number of characters processed.
        /// For example, if <c>CharLowerBuff("Acme of Operating Systems", 10)</c> succeeds, the return value is 10.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note that <see cref="CharLowerBuff"/> always maps uppercase I to lowercase I ("i"),
        /// even when the current language is Turkish or Azerbaijani.
        /// If you need a function that is linguistically sensitive in this respect, call <see cref="LCMapString"/>.
        /// </para>
        /// <para>
        /// Conversion to Unicode in the ANSI version of the function is done with the system default locale in all cases.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharLowerBuffW", ExactSpelling = true)]
        public static extern DWORD CharLowerBuff([In] LPWSTR lpsz, [In] DWORD cchLength);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the next character in a string.
        /// This function can handle strings consisting of either single- or multi-byte characters.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-charnextw"/>
        /// </para>
        /// </summary>
        /// <param name="lpsz">
        /// A character in a null-terminated string.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value is a pointer to the next character in the string,
        /// or to the terminating null character if at the end of the string.
        /// </para>
        /// <para>
        /// If <paramref name="lpsz"/> points to the terminating null character,
        /// the return value is equal to <paramref name="lpsz"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When called as an ANSI function, <see cref="CharNext"/> uses the system default code-page,
        /// whereas <see cref="CharNextExA"/> specifies a code-page to use.
        /// </para>
        /// <para>
        /// This function works with default "user" expectations of characters when dealing with diacritics.
        /// For example: A string that contains U+0061 U+030a "LATIN SMALL LETTER A" + COMBINING RING ABOVE"
        /// — which looks like "å", will advance two code points, not one.
        /// A string that contains U+0061 U+0301 U+0302 U+0303 U+0304 — which looks like "a´^~¯",
        /// will advance five code points, not one, and so on.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharNextW", ExactSpelling = true)]
        public static extern LPWSTR CharNext([In] LPCWSTR lpsz);

        /// <summary>
        /// <para>
        /// Retrieves the pointer to the next character in a string.
        /// This function can handle strings consisting of either single- or multi-byte characters.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-charnextexa"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// <para>
        /// The identifier of the code page to use to check lead-byte ranges.
        /// Can be one of the code-page values provided in Code Page Identifiers, or one of the following predefined values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CP_ACP"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Use system default ANSI code page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CP_MACCP"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Use the system default Macintosh code page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CP_OEMCP"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Use system default OEM code page.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpCurrentChar">
        /// A character in a null-terminated string.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is reserved and must be 0.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value is a pointer to the next character in the string, or to the terminating null character if at the end of the string.
        /// </para>
        /// <para>
        /// If <paramref name="lpCurrentChar"/> points to the terminating null character,
        /// the return value is equal to <paramref name="lpCurrentChar"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <see cref="CharNextExA"/> specifies a code-page to use,
        /// whereas <see cref="CharNext"/> (if called as an ANSI function) uses the system default code-page.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharNextExA", ExactSpelling = true)]
        public static extern IntPtr CharNextExA([In] WORD CodePage, [In] LPCSTR lpCurrentChar, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the preceding character in a string.
        /// This function can handle strings consisting of either single- or multi-byte characters.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-charprevw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszStart">
        /// The beginning of the string.
        /// </param>
        /// <param name="lpszCurrent">
        /// A character in a null-terminated string.
        /// </param>
        /// <returns>
        /// The return value is a pointer to the preceding character in the string,
        /// or to the first character in the string if the <paramref name="lpszCurrent"/> parameter equals the <paramref name="lpszStart"/> parameter.
        /// </returns>
        /// <remarks>
        /// <para>
        /// When called as an ANSI function, <see cref="CharPrev"/> uses the system default code-page,
        /// whereas <see cref="CharPrevExA"/> specifies a code-page to use.
        /// </para>
        /// <para>
        /// This function works with default "user" expectations of characters when dealing with diacritics.
        /// For example: A string that contains U+0061 U+030a "LATIN SMALL LETTER A" + COMBINING RING ABOVE"
        /// — which looks like "å", will advance two code points, not one.
        /// A string that contains U+0061 U+0301 U+0302 U+0303 U+0304 — which looks like "a´^~¯",
        /// will advance five code points, not one, and so on.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharPrevW", ExactSpelling = true)]
        public static extern IntPtr CharPrev([In] IntPtr lpszStart, [In] IntPtr lpszCurrent);

        /// <summary>
        /// <para>
        /// Retrieves the pointer to the preceding character in a string.
        /// This function can handle strings consisting of either single- or multi-byte characters.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-charprevexa"/>
        /// </para>
        /// </summary>
        /// <param name="CodePage">
        /// <para>
        /// The identifier of the code page to use to check lead-byte ranges.
        /// Can be one of the code-page values provided in Code Page Identifiers, or one of the following predefined values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CP_ACP"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Use system default ANSI code page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CP_MACCP"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Use the system default Macintosh code page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CP_OEMCP"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Use system default OEM code page.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpStart">
        /// The beginning of the string.
        /// </param>
        /// <param name="lpCurrentChar">
        /// A character in a null-terminated string.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <returns>
        /// The return value is a pointer to the preceding character in the string,
        /// or to the first character in the string if the <paramref name="lpCurrentChar"/> parameter equals the <paramref name="lpStart"/> parameter.
        /// </returns>
        /// <remarks>
        /// <see cref="CharPrevExA"/> specifies a code-page to use,
        /// whereas <see cref="CharPrev"/> (if called as an ANSI function) uses the system default code-page.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharPrevExA", ExactSpelling = true)]
        public static extern IntPtr CharPrevExA([In] WORD CodePage, [In] IntPtr lpStart, [In] IntPtr lpCurrentChar, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// Translates a string into the OEM-defined character set.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-chartooemw"/>
        /// </para>
        /// </summary>
        /// <param name="pSrc">
        /// The null-terminated string to be translated.
        /// </param>
        /// <param name="pDst">
        /// The destination buffer, which receives the translated string.
        /// If the CharToOem function is being used as an ANSI function, the string can be translated in place
        /// by setting the <paramref name="pDst"/> parameter to the same address as the <paramref name="pSrc"/> parameter.
        /// This cannot be done if CharToOem is being used as a wide-character function.
        /// </param>
        /// <returns>
        /// The return value is always nonzero except when you pass the same address
        /// to <paramref name="pSrc"/> and <paramref name="pDst"/> in the wide-character version of the function.
        /// In this case the function returns zero and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_ADDRESS"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Security Considerations
        /// </para>
        /// <para>
        /// Using this function incorrectly might compromise the security of your program.
        /// For example, miscalculating the proper size of the <paramref name="pDst"/> buffer,
        /// especially when the application is used in both ANSI and Unicode versions, can cause a buffer overflow.
        /// For more information, see Security Considerations: International Features and Security Considerations: Windows User Interface.
        /// </para>
        /// </remarks>
        [Obsolete("Do not use. See Security Considerations.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharToOemW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CharToOem([In] LPCWSTR pSrc, [In] IntPtr pDst);

        /// <summary>
        /// <para>
        /// Translates a specified number of characters in a string into the OEM-defined character set.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-chartooembuffw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszSrc">
        /// The null-terminated string to be translated.
        /// </param>
        /// <param name="lpszDst">
        /// The buffer for the translated string.
        /// If the <see cref="CharToOemBuff"/> function is being used as an ANSI function,
        /// the string can be translated in place by setting the <paramref name="lpszDst"/> parameter to the same address as the <paramref name="lpszSrc"/> parameter.
        /// This cannot be done if <see cref="CharToOemBuff"/> is being used as a wide-character function.
        /// </param>
        /// <param name="cchDstLength">
        /// The number of characters to translate in the string identified by the <paramref name="lpszSrc"/> parameter.
        /// </param>
        /// <returns>
        /// he return value is always nonzero except when you pass the same address to <paramref name="lpszSrc"/>
        /// and <paramref name="lpszDst"/> in the wide-character version of the function.
        /// In this case the function returns zero and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_ADDRESS"/>.
        /// </returns>
        /// <remarks>
        /// Unlike the <see cref="CharToOem"/> function, the <see cref="CharToOemBuff"/> function does not stop converting characters
        /// when it encounters a null character in the buffer pointed to by <paramref name="lpszSrc"/>.
        /// The <see cref="CharToOemBuff"/> function converts all <paramref name="cchDstLength"/> characters.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharToOemBuffW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CharToOemBuff([In] LPCWSTR lpszSrc, [In] IntPtr lpszDst, [In] DWORD cchDstLength);

        /// <summary>
        /// <para>
        /// Converts a character string or a single character to uppercase.
        /// If the operand is a character string, the function converts the characters in place.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-charupperw"/>
        /// </para>
        /// </summary>
        /// <param name="lpsz">
        /// A null-terminated string, or a single character.
        /// If the high-order word of this parameter is zero, the low-order word must contain a single character to be converted.
        /// </param>
        /// <returns>
        /// <para>
        /// If the operand is a character string, the function returns a pointer to the converted string.
        /// Because the string is converted in place, the return value is equal to <paramref name="lpsz"/>.
        /// </para>
        /// <para>
        /// If the operand is a single character, the return value is a 32-bit value
        /// whose high-order word is zero, and low-order word contains the converted character.
        /// </para>
        /// <para>
        /// There is no indication of success or failure. Failure is rare.
        /// There is no extended error information for this function; do not call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note that <see cref="CharUpper"/> always maps lowercase I ("i") to uppercase I,
        /// even when the current language is Turkish or Azerbaijani.
        /// If you need a function that is linguistically sensitive in this respect, call <see cref="LCMapString"/>.
        /// </para>
        /// <para>
        /// Conversion to Unicode in the ANSI version of the function is done with the system default locale in all cases.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharUpperW", ExactSpelling = true)]
        public static extern LPWSTR CharUpper([In] LPWSTR lpsz);

        /// <summary>
        /// <para>
        /// Converts lowercase characters in a buffer to uppercase characters.
        /// The function converts the characters in place.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-charupperbuffw"/>
        /// </para>
        /// </summary>
        /// <param name="lpsz">
        /// A buffer containing one or more characters to be processed.
        /// </param>
        /// <param name="cchLength">
        /// <para>
        /// The size, in characters, of the buffer pointed to by <paramref name="lpsz"/>.
        /// </para>
        /// <para>
        /// The function examines each character, and converts lowercase characters to uppercase characters.
        /// The function examines the number of characters indicated by <paramref name="cchLength"/>,
        /// even if one or more characters are null characters.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// The return value is the number of characters processed.
        /// </para>
        /// <para>
        /// For example, if <c>CharUpperBuff("Zenith of API Sets", 10)</c> succeeds, the return value is 10.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note that <see cref="CharUpperBuff"/> always maps lowercase I ("i") to uppercase I,
        /// even when the current language is Turkish or Azerbaijani.
        /// If you need a function that is linguistically sensitive in this respect, call <see cref="LCMapString"/>.
        /// </para>
        /// <para>
        /// Conversion to Unicode in the ANSI version of the function is done with the system default locale in all cases.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CharUpperBuffW", ExactSpelling = true, SetLastError = false)]
        public static extern DWORD CharUpperBuff([In] LPWSTR lpsz, [In] DWORD cchLength);

        /// <summary>
        /// <para>
        /// Determines whether a character is an alphabetical character.
        /// This determination is based on the semantics of the language selected by the user during setup or through Control Panel.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-ischaralphaw"/>
        /// </para>
        /// </summary>
        /// <param name="ch">
        /// The character to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the character is alphabetical, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the character is not alphabetical, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsCharAlphaW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsCharAlpha([In] WCHAR ch);

        /// <summary>
        /// <para>
        /// Determines whether a character is either an alphabetical or a numeric character.
        /// This determination is based on the semantics of the language selected by the user during setup or through Control Panel.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-ischaralphanumericw"/>
        /// </para>
        /// </summary>
        /// <param name="ch">
        /// The character to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the character is alphanumeric, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the character is not alphanumeric, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsCharAlphaNumericW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsCharAlphaNumeric([In] WCHAR ch);

        /// <summary>
        /// <para>
        /// Determines whether a character is lowercase.
        /// This determination is based on the semantics of the language selected by the user during setup or through Control Panel.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-ischarlowerw"/>
        /// </para>
        /// </summary>
        /// <param name="ch">
        /// The character to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the character is lowercase, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the character is not lowercase, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsCharLowerW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsCharLower([In] WCHAR ch);

        /// <summary>
        /// <para>
        /// Determines whether a character is uppercase.
        /// This determination is based on the semantics of the language selected by the user during setup or through Control Panel.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-ischarupperw"/>
        /// </para>
        /// </summary>
        /// <param name="ch">
        /// The character to be tested.
        /// </param>
        /// <returns>
        /// <para>
        /// If the character is uppercase, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the character is not uppercase, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsCharUpperW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsCharUpper([In] WCHAR ch);

        /// <summary>
        /// <para>
        /// Loads a string resource from the executable file associated with a specified module and either copies the string
        /// into a buffer with a terminating null character or returns a read-only pointer to the string resource itself.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadstringw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to an instance of the module whose executable file contains the string resource.
        /// To get the handle to the application itself, call the <see cref="GetModuleHandle"/> function with <see cref="NULL"/>.
        /// </param>
        /// <param name="uID">
        /// The identifier of the string to be loaded.
        /// </param>
        /// <param name="lpBuffer">
        /// The buffer to receive the string (if <paramref name="cchBufferMax"/> is non-zero) or
        /// a read-only pointer to the string resource itself (if <paramref name="cchBufferMax"/> is zero).
        /// Must be of sufficient length to hold a pointer (8 bytes).
        /// </param>
        /// <param name="cchBufferMax">
        /// The size of the buffer, in characters.
        /// The string is truncated and null-terminated if it is longer than the number of characters specified.
        /// If this parameter is 0, then <paramref name="lpBuffer"/> receives a read-only pointer to the string resource itself.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is one of the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The number of characters copied into the buffer (if <paramref name="cchBufferMax"/> is non-zero), not including the terminating null character.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The number of characters in the string resource that <paramref name="cchBufferMax"/> points to (if <paramref name="cchBufferMax"/> is zero).
        /// The string resource is not guaranteed to be null-terminated in the module's resource table,
        /// and you can use this value to determine where the string resource ends.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Zero if the string resource does not exist.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If you pass 0 to <paramref name="cchBufferMax"/> to return a read-only pointer
        /// to the string resource in the <paramref name="lpBuffer"/> parameter,
        /// use the number of characters in the return value to determine the length of the string resource.
        /// String resources are not guaranteed to be null-terminated in the module's resource table.
        /// However, resource tables can contain null characters.
        /// String resources are stored in blocks of 16 strings, and any empty slots within a block are indicated by null characters.
        /// </para>
        /// <para>
        /// Security Remarks
        /// </para>
        /// <para>
        /// Using this function incorrectly can compromise the security of your application.
        /// Incorrect use includes specifying the wrong size in the <paramref name="cchBufferMax"/> parameter.
        /// For example, if <paramref name="lpBuffer"/> points to a buffer <c>szBuffer</c>
        /// which is declared as <c>TCHAR szBuffer[100]</c>, then sizeof(szBuffer) gives the size of the buffer in bytes,
        /// which could lead to a buffer overflow for the Unicode version of the function.
        /// Buffer overflow situations are the cause of many security problems in applications.
        /// In this case, using <c>sizeof(szBuffer)/sizeof(TCHAR)</c> or <c>sizeof(szBuffer)/sizeof(szBuffer[0])</c> would give the proper size of the buffer.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadStringW", ExactSpelling = true, SetLastError = true)]
        public static extern int LoadString([In] HINSTANCE hInstance, [In] UINT uID, [In] LPWSTR lpBuffer, [In] int cchBufferMax);

        /// <summary>
        /// <para>
        /// Translates a string from the OEM-defined character set into either an ANSI or a wide-character string.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-oemtocharw"/>
        /// </para>
        /// </summary>
        /// <param name="pSrc">
        /// A null-terminated string of characters from the OEM-defined character set.
        /// </param>
        /// <param name="pDst">
        /// The destination buffer, which receives the translated string.
        /// If the <see cref="OemToChar"/> function is being used as an ANSI function,
        /// the string can be translated in place by setting the <paramref name="pDst"/> parameter
        /// to the same address as the <paramref name="pSrc"/> parameter.
        /// This cannot be done if <see cref="OemToChar"/> is being used as a wide-character function.
        /// </param>
        /// <returns>
        /// The return value is always nonzero except when you pass the same address
        /// to <paramref name="pSrc"/> and <paramref name="pDst"/> in the wide-character version of the function.
        /// In this case the function returns zero and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_ADDRESS"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Security Considerations
        /// </para>
        /// <para>
        /// Using this function incorrectly might compromise the security of your program.
        /// For example, miscalculating the proper size of the <paramref name="pDst"/> buffer,
        /// especially when the application is used in both ANSI and Unicode versions, can cause a buffer overflow.
        /// For more information, see Security Considerations: International Features and Security Considerations: Windows User Interface.
        /// </para>
        /// </remarks>
        [Obsolete("Do not use. See Security Considerations.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OemToCharW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OemToChar([In] LPCSTR pSrc, [In] LPWSTR pDst);

        /// <summary>
        /// <para>
        /// Translates a specified number of characters in a string from the OEM-defined character set into either an ANSI or a wide-character string.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-oemtocharbuffw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszSrc">
        /// One or more characters from the OEM-defined character set.
        /// </param>
        /// <param name="lpszDst">
        /// The destination buffer, which receives the translated string.
        /// If the <see cref="OemToCharBuff"/> function is being used as an ANSI function,
        /// the string can be translated in place by setting the <paramref name="lpszDst"/> parameter
        /// to the same address as the <paramref name="lpszSrc"/> parameter.
        /// This cannot be done if the <see cref="OemToCharBuff"/> function is being used as a wide-character function.
        /// </param>
        /// <param name="cchDstLength">
        /// The number of characters to be translated in the buffer identified by the <paramref name="lpszSrc"/> parameter.
        /// </param>
        /// <returns>
        /// The return value is always nonzero except when you pass the same address
        /// to <paramref name="lpszSrc"/> and <paramref name="lpszDst"/> in the wide-character version of the function.
        /// In this case the function returns zero and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_ADDRESS"/>.
        /// </returns>
        /// <remarks>
        /// Unlike the <see cref="OemToChar"/> function, the <see cref="OemToCharBuff"/> function does not stop converting characters
        /// when it encounters a null character in the buffer pointed to by <paramref name="lpszSrc"/>.
        /// The <see cref="OemToCharBuff"/> function converts all <paramref name="cchDstLength"/> characters.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OemToCharBuffW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OemToCharBuff([In] LPCSTR lpszSrc, [In] LPWSTR lpszDst, [In] DWORD cchDstLength);
    }
}
