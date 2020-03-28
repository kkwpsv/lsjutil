using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The EnumFontFamExProc function is an application defined callback function used with the <see cref="EnumFontFamiliesEx"/> function.
        /// It is used to process the fonts. It is called once for each enumerated font.
        /// The <see cref="FONTENUMPROC"/> type defines a pointer to this callback function.
        /// EnumFontFamExProc is a placeholder for the application defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/dd162618(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="lpelfe">
        /// A pointer to an <see cref="LOGFONT"/> structure that contains information about the logical attributes of the font.
        /// To obtain additional information about the font, you can cast the result
        /// as an <see cref="ENUMLOGFONTEX"/> or <see cref="ENUMLOGFONTEXDV"/> structure.
        /// </param>
        /// <param name="lpntme">
        /// A pointer to a structure that contains information about the physical attributes of a font.
        /// The function uses the <see cref="NEWTEXTMETRICEX"/> structure for TrueType fonts;
        /// and the <see cref="TEXTMETRIC"/> structure for other fonts.
        /// This can be an <see cref="ENUMTEXTMETRIC"/> structure.
        /// </param>
        /// <param name="FontType">
        /// The type of the font. This parameter can be a combination of these values:
        /// <see cref="DEVICE_FONTTYPE"/>
        /// <see cref="RASTER_FONTTYPE"/>
        /// <see cref="TRUETYPE_FONTTYPE"/>
        /// </param>
        /// <param name="lParam">
        /// The application-defined data passed by the <see cref="EnumFontFamiliesEx"/> function.
        /// </param>
        /// <returns>
        /// The return value must be a nonzero value to continue enumeration; to stop enumeration, the return value must be zero.
        /// </returns>
        /// <remarks>
        /// An application must register this callback function by passing its address to the <see cref="EnumFontFamiliesEx"/> function.
        /// When the graphics mode on the device context is set to <see cref="GM_ADVANCED"/>
        /// using the <see cref="SetGraphicsMode"/> function and the <see cref="DEVICE_FONTTYPE"/> flag is passed to the FontType parameter,
        /// this function returns a list of type 1 and OpenType fonts on the system.
        /// When the graphics mode is not set to <see cref="GM_ADVANCED"/>,
        /// this function returns a list of type 1, OpenType, and TrueType fonts on the system.
        /// Unlike the EnumFontFamProc callback function, EnumFontFamExProc receives extended information about a font.
        /// The <see cref="ENUMLOGFONTEX"/> structure includes the localized name of the script (character set) and
        /// the <see cref="NEWTEXTMETRICEX"/> structure includes a font-coverage signature.
        /// </remarks>
        public delegate int FONTENUMPROC([In]IntPtr lpelfe, [In]IntPtr lpntme, [In]FontTypes FontType, [In]IntPtr lParam);


        /// <summary>
        /// <para>
        /// The EnumFonts function enumerates the fonts available on a specified device.
        /// For each font with the specified typeface name, the <see cref="EnumFonts"/> function retrieves information about that font
        /// and passes it to the application defined callback function.
        /// This callback function can process the font information as desired.
        /// Enumeration continues until there are no more fonts or the callback function returns zero.
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context from which to enumerate the fonts.
        /// </param>
        /// <param name="lpLogfont">
        /// A pointer to a null-terminated string that specifies the typeface name of the desired fonts.
        /// If <paramref name="lpLogfont"/> is NULL, <see cref="EnumFonts"/> randomly selects and enumerates one font of each available typeface.
        /// </param>
        /// <param name="lpProc">
        /// A pointer to the application definedcallback function. For more information, see <see cref="FONTENUMPROC"/>.
        /// </param>
        /// <param name="lParam">
        /// A pointer to any application-defined data. The data is passed to the callback function along with the font information.
        /// </param>
        /// <returns>
        /// The return value is the last value returned by the callback function. Its meaning is defined by the application.
        /// </returns>
        /// <remarks>
        /// Use <see cref="EnumFontFamiliesEx"/> instead of <see cref="EnumFonts"/>.
        /// The <see cref="EnumFontFamiliesEx"/> function differs from the <see cref="EnumFonts"/> function in that
        /// it retrieves the style names associated with a TrueType font.
        /// With <see cref="EnumFontFamiliesEx"/>, you can retrieve information about font styles
        /// that cannot be enumerated using the <see cref="EnumFonts"/> function.
        /// The fonts for many East Asian languages have two typeface names: an English name and a localized name.
        /// <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/> return the English typeface name 
        /// if the system locale does not match the language of the font.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            " Applications should use the EnumFontFamiliesEx function.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumFontsW", SetLastError = true)]
        public static extern int EnumFonts([In]IntPtr hdc, [MarshalAs(UnmanagedType.LPWStr)][In]string lpLogfont,
            [In]FONTENUMPROC lpProc, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// The <see cref="EnumFontFamilies"/> function enumerates the fonts in a specified font family that are available on a specified device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-enumfontfamiliesw
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context from which to enumerate the fonts.
        /// </param>
        /// <param name="lpLogfont">
        /// A pointer to a null-terminated string that specifies the family name of the desired fonts.
        /// If <paramref name="lpLogfont"/> is NULL, <see cref="EnumFontFamilies"/> selects and enumerates one font of each available type family.
        /// </param>
        /// <param name="lpProc">
        /// A pointer to the application defined callback function. For information, see <see cref="FONTENUMPROC"/>.
        /// </param>
        /// <param name="lParam">
        /// A pointer to application-supplied data. The data is passed to the callback function along with the font information.
        /// </param>
        /// <returns>
        /// The return value is the last value returned by the callback function. Its meaning is implementation specific.
        /// </returns>
        /// <remarks>
        /// For each font having the typeface name specified by the <paramref name="lpLogfont"/> parameter,
        /// the <see cref="EnumFontFamilies"/> function retrieves information about that font and passes it to the function
        /// pointed to by the <paramref name="lpProc"/> parameter.
        /// The application defined callback function can process the font information as desired.
        /// Enumeration continues until there are no more fonts or the callback function returns zero.
        /// When the graphics mode on the device context is set to ,<see cref="GM_ADVANCED"/> using the <see cref="SetGraphicsMode"/> function
        /// and the <see cref="DEVICE_FONTTYPE"/> flag is passed to the FontType parameter,
        /// this function returns a list of type 1 and OpenType fonts on the system.
        /// When the graphics mode is not set to <see cref="GM_ADVANCED"/>, this function returns a list of type 1,
        /// OpenType, and TrueType fonts on the system.
        /// The fonts for many East Asian languages have two typeface names: an English name and a localized name.
        /// <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/> return the English typeface name
        /// if the system locale does not match the language of the font.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            " Applications should use the EnumFontFamiliesEx function.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumFontFamiliesW", SetLastError = true)]
        public static extern int EnumFontFamilies([In]IntPtr hdc, [MarshalAs(UnmanagedType.LPWStr)][In]string lpLogfont,
            [In]FONTENUMPROC lpProc, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// The <see cref="EnumFontFamiliesEx"/> function enumerates all uniquely-named fonts in the system
        /// that match the font characteristics specified by the <see cref="LOGFONT"/> structure.
        /// <see cref="EnumFontFamiliesEx"/> enumerates fonts based on typeface name, character set, or both.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-enumfontfamiliesexw
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context from which to enumerate the fonts.
        /// </param>
        /// <param name="lpLogfont">
        /// A pointer to a <see cref="LOGFONT"/> structure that contains information about the fonts to enumerate.
        /// The function examines the following members.
        /// <see cref="LOGFONT.lfCharSet"/>
        /// If set to <see cref="DEFAULT_CHARSET"/>, the function enumerates all uniquely-named fonts in all character sets.
        /// (If there are two fonts with the same name, only one is enumerated.)
        /// If set to a valid character set value, the function enumerates only fonts in the specified character set.
        /// <see cref="LOGFONT.lfFaceName"/>
        /// If set to an empty string, the function enumerates one font in each available typeface name.
        /// If set to a valid typeface name, the function enumerates all fonts with the specified name.
        /// <see cref="LOGFONT.lfPitchAndFamily"/>
        /// Must be set to zero for all language versions of the operating system.
        /// </param>
        /// <param name="lpProc">
        /// A pointer to the application defined callback function.
        /// For more information, see the <see cref="FONTENUMPROC"/> function.
        /// </param>
        /// <param name="lParam">
        /// An application defined value.
        /// The function passes this value to the callback function along with font information.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is not used and must be zero.
        /// </param>
        /// <returns>
        /// The return value is the last value returned by the callback function.
        /// This value depends on which font families are available for the specified device.
        /// </returns>
        /// <remarks>
        /// The <see cref="EnumFontFamiliesEx"/> function does not use tagged typeface names to identify character sets.
        /// Instead, it always passes the correct typeface name and a separate character set value to the callback function.
        /// The function enumerates fonts based on the values of
        /// the <see cref="LOGFONT.lfCharSet"/> and <see cref="LOGFONT.lfFaceName"/> members in the <see cref="LOGFONT"/> structure.
        /// As with <see cref="EnumFontFamilies"/>, <see cref="EnumFontFamiliesEx"/> enumerates all font styles.
        /// Not all styles of a font cover the same character sets.
        /// For example, Fontorama Bold might contain ANSI, Greek, and Cyrillic characters, but Fontorama Italic might contain only ANSI characters.
        /// For this reason, it's best not to assume that a specified font covers a specific character set, even if it is the ANSI character set.
        /// The following table shows the results of various combinations of values for <see cref="LOGFONT.lfCharSet"/> and <see cref="LOGFONT.lfFaceName"/>.
        /// <see cref="LOGFONT.lfCharSet"/> = <see cref="DEFAULT_CHARSET"/>
        /// <see cref="LOGFONT.lfFaceName"/> = '\0'
        /// Enumerates all uniquely-named fonts within all character sets.If there are two fonts with the same name, only one is enumerated.
        /// <see cref="LOGFONT.lfCharSet"/> = <see cref="DEFAULT_CHARSET"/>
        /// <see cref="LOGFONT.lfFaceName"/> =  a specific font
        /// Enumerates all character sets and styles in a specific font.
        /// <see cref="LOGFONT.lfCharSet"/> = a specific character set
        /// <see cref="LOGFONT.lfFaceName"/> = '\0'
        /// Enumerates all styles of all fonts in the specific character set.
        /// <see cref="LOGFONT.lfCharSet"/> = a specific character set
        /// <see cref="LOGFONT.lfFaceName"/> =  a specific font
        /// Enumerates all styles of a font in a specific character set.
        /// The following code sample shows how these values are used.
        /// <code>
        /// // To enumerate all styles and charsets of all fonts: 
        /// lf.lfFaceName[0] = '\0';
        /// lf.lfCharSet = DEFAULT_CHARSET;
        /// HRESULT hr;
        /// 
        /// // To enumerate all styles and character sets of the Arial font: 
        /// hr = StringCchCopy((LPSTR) lf.lfFaceName, LF_FACESIZE, "Arial" );
        /// if (FAILED(hr))
        /// {
        ///     // TODO: write error handler 
        /// }
        /// 
        /// lf.lfCharSet = DEFAULT_CHARSET;
        /// </code>
        /// <code>
        /// // To enumerate all styles of all fonts for the ANSI character set 
        /// lf.lfFaceName[0] = '\0';
        /// lf.lfCharSet = ANSI_CHARSET;
        /// 
        /// // To enumerate all styles of Arial font that cover the ANSI charset 
        /// hr = StringCchCopy((LPSTR) lf.lfFaceName, LF_FACESIZE, "Arial" );
        /// if (FAILED(hr))
        /// {
        ///     // TODO: write error handler 
        /// }
        ///     
        /// lf.lfCharSet = ANSI_CHARSET;
        /// </code>
        /// The callback functions for <see cref="EnumFontFamilies"/> and <see cref="EnumFontFamiliesEx"/> are very similar.
        /// The main difference is that the <see cref="ENUMLOGFONTEX"/> structure includes a script field.
        /// Note, based on the values of <see cref="LOGFONT.lfCharSet"/> and <see cref="LOGFONT.lfFaceName"/>,
        /// <see cref="EnumFontFamiliesEx"/> will enumerate the same font as many times as there are distinct character sets in the font.
        /// This can create an extensive list of fonts which can be burdensome to a user.
        /// For example, the Century Schoolbook font can appear for the Baltic, Western, Greek, Turkish, and Cyrillic character sets.
        /// To avoid this, an application should filter the list of fonts.
        /// The fonts for many East Asian languages have two typeface names: an English name and a localized name.
        /// <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/> return the English typeface name
        /// if the system locale does not match the language of the font.
        /// When the graphics mode on the device context is set to <see cref="GM_ADVANCED"/> using the <see cref="SetGraphicsMode"/> function
        /// and the <see cref="DEVICE_FONTTYPE"/> flag is passed to the FontType parameter,
        /// this function returns a list of type 1 and OpenType fonts on the system.
        /// When the graphics mode is not set to <see cref="GM_ADVANCED"/>,
        /// this function returns a list of type 1, OpenType, and TrueType fonts on the system.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumFontFamiliesExW", SetLastError = true)]
        public static extern int EnumFontFamiliesEx([In]IntPtr hdc, [In]ref LOGFONT lpLogfont, [In]FONTENUMPROC lpProc,
            [In]IntPtr lParam, [In]uint dwFlags);
    }
}
