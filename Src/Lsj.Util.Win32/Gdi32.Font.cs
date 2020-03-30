using Lsj.Util.Win32.BaseTypes;
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
        /// The <see cref="AddFontResource"/> function adds the font resource from the specified file to the system font table.
        /// The font can subsequently be used for text output by any application.
        /// To mark a font as private or not enumerable, use the <see cref="AddFontResourceEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-addfontresourcew
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A pointer to a null-terminated character string that contains a valid font file name.
        /// This parameter can specify any of the following files.
        /// .fon: Font resource file.
        /// .fnt: Raw bitmap font file.
        /// .ttf: Raw TrueType file.
        /// .ttc: East Asian Windows: TrueType font collection.
        /// .fot: TrueType resource file.
        /// .otf: PostScript OpenType font.
        /// .mmm: Multiple master Type1 font resource file. It must be used with .pfm and .pfb files.
        /// .pfb: Type 1 font bits file. It is used with a .pfm file.
        /// .pfm: Type 1 font metrics file. It is used with a .pfb file.
        /// To add a font whose information comes from several resource files, have <paramref name="Arg1"/> point to a string with the file names
        /// separated by a "|" --for example, abcxxxxx.pfm | abcxxxxx.pfb.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the number of fonts added.
        /// If the function fails, the return value is zero.
        /// No extended error information is available.
        /// </returns>
        /// <remarks>
        /// Any application that adds or removes fonts from the system font table should notify other windows of the change
        /// by sending a <see cref="WM_FONTCHANGE"/> message to all top-level windows in the operating system.
        /// The application should send this message by calling the <see cref="SendMessage"/> function
        /// and setting the hwnd parameter to <see cref="HWND_BROADCAST"/>.
        /// When an application no longer needs a font resource that it loaded by calling the <see cref="AddFontResource"/> function,
        /// it must remove that resource by calling the <see cref="RemoveFontResource"/> function.
        /// This function installs the font only for the current session.
        /// When the system restarts, the font will not be present.
        /// To have the font installed even after restarting the system, the font must be listed in the registry.
        /// A font listed in the registry and installed to a location other than the %windir%\fonts\ folder cannot be modified, deleted,
        /// or replaced as long as it is loaded in any session.
        /// In order to change one of these fonts, it must first be removed by calling <see cref="RemoveFontResource"/>,
        /// removed from the font registry (HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts), and the system restarted.
        /// After restarting the system, the font will no longer be loaded and can be changed.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([MarshalAs(UnmanagedType.LPWStr)][In]string Arg1);

        /// <summary>
        /// <para>
        /// The <see cref="CreateFont"/> function creates a logical font with the specified characteristics.
        /// The logical font can subsequently be selected as the font for any device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createfontw
        /// </para>
        /// </summary>
        /// <param name="cHeight">
        /// The height, in logical units, of the font's character cell or character.
        /// The character height value (also known as the em height) is the character cell height value minus the internal-leading value.
        /// The font mapper interprets the value specified in <paramref name="cHeight"/> in the following manner.
        /// &gt; 0: The font mapper transforms this value into device units and matches it against the cell height of the available fonts.
        /// 0: The font mapper uses a default height value when it searches for a match.
        /// &lt; 0: The font mapper transforms this value into device units and matches its absolute value against the character height of the available fonts.
        /// For all height comparisons, the font mapper looks for the largest font that does not exceed the requested size.
        /// This mapping occurs when the font is used for the first time.
        /// For the <see cref="MM_TEXT"/> mapping mode, you can use the following formula to specify a height for a font with a specified point size:
        /// <code>
        /// nHeight = -MulDiv(PointSize, GetDeviceCaps(hDC, LOGPIXELSY), 72);
        /// </code>
        /// </param>
        /// <param name="cWidth">
        /// The average width, in logical units, of characters in the requested font.
        /// If this value is zero, the font mapper chooses a closest match value.
        /// The closest match value is determined by comparing the absolute values of the difference
        /// between the current device's aspect ratio and the digitized aspect ratio of available fonts.
        /// </param>
        /// <param name="cEscapement">
        /// The angle, in tenths of degrees, between the escapement vector and the x-axis of the device.
        /// The escapement vector is parallel to the base line of a row of text.
        /// When the graphics mode is set to <see cref="GM_ADVANCED"/>, you can specify the escapement angle of the string
        /// independently of the orientation angle of the string's characters.
        /// When the graphics mode is set to <see cref="GM_COMPATIBLE"/>, nEscapement specifies both the escapement and orientation.
        /// You should set <paramref name="cEscapement"/> and <paramref name="cOrientation"/> to the same value.
        /// </param>
        /// <param name="cOrientation">
        /// The angle, in tenths of degrees, between each character's base line and the x-axis of the device.
        /// </param>
        /// <param name="cWeight">
        /// The weight of the font in the range 0 through 1000. For example, 400 is normal and 700 is bold. If this value is zero, a default weight is used.
        /// The following values are defined for convenience.
        /// <see cref="FW_DONTCARE"/>, <see cref="FW_THIN"/>, <see cref="FW_EXTRALIGHT"/>, <see cref="FW_ULTRALIGHT"/>, <see cref="FW_LIGHT"/>,
        /// <see cref="FW_NORMAL"/>, <see cref="FW_REGULAR"/>, <see cref="FW_MEDIUM"/>, <see cref="FW_SEMIBOLD"/>, <see cref="FW_DEMIBOLD"/>,
        /// <see cref="FW_BOLD"/>, <see cref="FW_EXTRABOLD"/>, <see cref="FW_ULTRABOLD"/>, <see cref="FW_HEAVY"/>, <see cref="FW_BLACK"/>
        /// </param>
        /// <param name="bItalic">
        /// Specifies an italic font if set to <see cref="TRUE"/>.
        /// </param>
        /// <param name="bUnderline">
        /// Specifies an underlined font if set to <see cref="TRUE"/>.
        /// </param>
        /// <param name="bStrikeOut">
        /// A strikeout font if set to <see cref="TRUE"/>.
        /// </param>
        /// <param name="iCharSet">
        /// The character set. The following values are predefined:
        /// <see cref="ANSI_CHARSET"/>, <see cref="BALTIC_CHARSET"/>, <see cref="CHINESEBIG5_CHARSET"/>, <see cref="DEFAULT_CHARSET"/>,
        /// <see cref="EASTEUROPE_CHARSET"/>, <see cref="GB2312_CHARSET"/>, <see cref="GREEK_CHARSET"/>, <see cref="HANGUL_CHARSET"/>,
        /// <see cref="MAC_CHARSET"/>, <see cref="OEM_CHARSET"/>, <see cref="RUSSIAN_CHARSET"/>, <see cref="SHIFTJIS_CHARSET"/>,
        /// <see cref="SYMBOL_CHARSET"/>, <see cref="TURKISH_CHARSET"/>, <see cref="VIETNAMESE_CHARSET"/>
        /// Korean language edition of Windows:
        /// <see cref="JOHAB_CHARSET"/>
        /// Middle East language edition of Windows:
        /// <see cref="ARABIC_CHARSET"/>, <see cref="HEBREW_CHARSET"/>
        /// Thai language edition of Windows:
        /// <see cref="THAI_CHARSET"/>
        /// The <see cref="OEM_CHARSET"/> value specifies a character set that is operating-system dependent.
        /// <see cref="DEFAULT_CHARSET"/> is set to a value based on the current system locale.
        /// For example, when the system locale is English (United States), it is set as <see cref="ANSI_CHARSET"/>.
        /// Fonts with other character sets may exist in the operating system.
        /// If an application uses a font with an unknown character set, it should not attempt to translate or interpret strings
        /// that are rendered with that font.
        /// To ensure consistent results when creating a font, do not specify <see cref="OEM_CHARSET"/> or <see cref="DEFAULT_CHARSET"/>.
        /// If you specify a typeface name in the <paramref name="pszFaceName"/> parameter,
        /// make sure that the <paramref name="iCharSet"/> value matches the character set of the typeface specified in <paramref name="pszFaceName"/>.
        /// </param>
        /// <param name="iOutPrecision">
        /// The output precision. The output precision defines how closely the output must match the requested font's height, width,
        /// character orientation, escapement, pitch, and font type. It can be one of the following values.
        /// <see cref="OUT_CHARACTER_PRECIS"/>, <see cref="OUT_DEFAULT_PRECIS"/>, <see cref="OUT_DEVICE_PRECIS"/>,
        /// <see cref="OUT_OUTLINE_PRECIS"/>, <see cref="OUT_PS_ONLY_PRECIS"/>, <see cref="OUT_RASTER_PRECIS"/>,
        /// <see cref="OUT_STRING_PRECIS"/>, <see cref="OUT_STROKE_PRECIS"/>, <see cref="OUT_TT_ONLY_PRECIS"/>, <see cref="OUT_TT_PRECIS"/>
        /// Applications can use the <see cref="OUT_DEVICE_PRECIS"/>, <see cref="OUT_RASTER_PRECIS"/>, <see cref="OUT_TT_PRECIS"/>,
        /// and <see cref="OUT_PS_ONLY_PRECIS"/> values to control how the font mapper chooses a font
        /// when the operating system contains more than one font with a specified name.
        /// For example, if an operating system contains a font named Symbol in raster and TrueType form,
        /// specifying <see cref="OUT_TT_PRECIS"/> forces the font mapper to choose the TrueType version.
        /// Specifying <see cref="OUT_TT_ONLY_PRECIS"/> forces the font mapper to choose a TrueType font,
        /// even if it must substitute a TrueType font of another name.
        /// </param>
        /// <param name="iClipPrecision">
        /// The clipping precision.
        /// The clipping precision defines how to clip characters that are partially outside the clipping region.
        /// It can be one or more of the following values.
        /// <see cref="CLIP_CHARACTER_PRECIS"/>, <see cref="CLIP_DEFAULT_PRECIS"/>, <see cref="CLIP_DFA_DISABLE"/>,
        /// <see cref="CLIP_EMBEDDED"/>, <see cref="CLIP_LH_ANGLES"/>, <see cref="CLIP_MASK"/>, <see cref="CLIP_DFA_OVERRIDE"/>,
        /// <see cref="CLIP_STROKE_PRECIS"/>, <see cref="CLIP_TT_ALWAYS"/>
        /// </param>
        /// <param name="iQuality">
        /// The output quality.
        /// The output quality defines how carefully GDI must attempt to match the logical-font attributes to those of an actual physical font.
        /// It can be one of the following values.
        /// <see cref="ANTIALIASED_QUALITY"/>, <see cref="CLEARTYPE_QUALITY"/>, <see cref="DEFAULT_QUALITY"/>, <see cref="DRAFT_QUALITY"/>,
        /// <see cref="NONANTIALIASED_QUALITY"/>, <see cref="PROOF_QUALITY"/>
        /// If the output quality is <see cref="DEFAULT_QUALITY"/>, <see cref="DRAFT_QUALITY"/>, or <see cref="PROOF_QUALITY"/>,
        /// then the font is antialiased if the <see cref="SPI_GETFONTSMOOTHING"/> system parameter is <see cref="TRUE"/>.
        /// Users can control this system parameter from the Control Panel.
        /// (The precise wording of the setting in the Control panel depends on the version of Windows,
        /// but it will be words to the effect of "Smooth edges of screen fonts".)
        /// </param>
        /// <param name="iPitchAndFamily">
        /// The pitch and family of the font.
        /// The two low-order bits specify the pitch of the font and can be one of the following values:
        /// <see cref="DEFAULT_PITCH"/>, <see cref="FIXED_PITCH"/>, <see cref="VARIABLE_PITCH"/>
        /// The four high-order bits specify the font family and can be one of the following values.
        /// <see cref="FF_DECORATIVE"/>, <see cref="FF_DONTCARE"/>, <see cref="FF_MODERN"/>,
        /// <see cref="FF_ROMAN"/>, <see cref="FF_SCRIPT"/>, <see cref="FF_SWISS"/>
        /// An application can specify a value for the <paramref name="iPitchAndFamily"/> parameter by using the Boolean OR operator
        /// to join a pitch constant with a family constant.
        /// Font families describe the look of a font in a general way.
        /// They are intended for specifying fonts when the exact typeface requested is not available.
        /// </param>
        /// <param name="pszFaceName">
        /// A pointer to a null-terminated string that specifies the typeface name of the font.
        /// The length of this string must not exceed 32 characters, including the terminating null character.
        /// The <see cref="EnumFontFamilies"/> function can be used to enumerate the typeface names of all currently available fonts.
        /// For more information, see the Remarks.
        /// If <paramref name="pszFaceName"/> is <see langword="null"/> or empty string,
        /// GDI uses the first font that matches the other specified attributes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a logical font.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the font, call the <see cref="DeleteObject"/> function to delete it.
        /// To help protect the copyrights of vendors who provide fonts for Windows, applications should always report the exact name of a selected font.
        /// Because available fonts can vary from system to system, do not assume that the selected font is always the same as the requested font.
        /// For example, if you request a font named Palatino, but no such font is available on the system,
        /// the font mapper will substitute a font that has similar attributes but a different name.
        /// Always report the name of the selected font to the user.
        /// To get the appropriate font on different language versions of the OS, call <see cref="EnumFontFamiliesEx"/> with the desired font characteristics
        /// in the <see cref="LOGFONT"/> structure, then retrieve the appropriate typeface name
        /// and create the font using <see cref="CreateFont"/> or <see cref="CreateFontIndirect"/>.
        /// The font mapper for <see cref="CreateFont"/>, <see cref="CreateFontIndirect"/>, and <see cref="CreateFontIndirectEx"/> recognizes
        /// both the English and the localized typeface name, regardless of locale.
        /// The following situations do not support ClearType antialiasing:
        /// Text rendered on a printer.
        /// A display set for 256 colors or less.
        /// Text rendered to a terminal server client.
        /// The font is not a TrueType font or an OpenType font with TrueType outlines.
        /// For example, the following do not support ClearType antialiasing:
        /// Type 1 fonts, Postscript OpenType fonts without TrueType outlines, bitmap fonts, vector fonts, and device fonts.
        /// The font has tuned embedded bitmaps, only for the font sizes that contain the embedded bitmaps.
        /// For example, this occurs commonly in East Asian fonts.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFontW", SetLastError = true)]
        public static extern HFONT CreateFont([In]int cHeight, [In]int cWidth, [In]int cEscapement, [In]int cOrientation, [In]int cWeight,
            [In]DWORD bItalic, [In]DWORD bUnderline, [In]DWORD bStrikeOut, [In]DWORD iCharSet, [In]DWORD iOutPrecision, [In]DWORD iClipPrecision,
            [In]DWORD iQuality, [In]DWORD iPitchAndFamily, [MarshalAs(UnmanagedType.LPWStr)][In]string pszFaceName);

        /// <summary>
        /// <para>
        /// The <see cref="CreateFontIndirect"/> function creates a logical font that has the specified characteristics.
        /// The font can subsequently be selected as the current font for any device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createfontindirectw
        /// </para>
        /// </summary>
        /// <param name="lplf">
        /// A pointer to a <see cref="LOGFONT"/> structure that defines the characteristics of the logical font.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a logical font.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateFontIndirect"/> function creates a logical font with the characteristics specified in the <see cref="LOGFONT"/> structure.
        /// When this font is selected by using the <see cref="SelectObject"/> function, GDI's font mapper attempts to match the logical font
        /// with an existing physical font.
        /// If it fails to find an exact match, it provides an alternative whose characteristics match as many of the requested characteristics as possible.
        /// To get the appropriate font on different language versions of the OS, call <see cref="EnumFontFamiliesEx"/> with the desired font characteristics
        /// in the <see cref="LOGFONT"/> structure, retrieve the appropriate typeface name,
        /// and create the font using <see cref="CreateFont"/> or <see cref="CreateFontIndirect"/>.
        /// When you no longer need the font, call the <see cref="DeleteObject"/> function to delete it.
        /// The fonts for many East Asian languages have two typeface names: an English name and a localized name.
        /// <see cref="CreateFont"/> and <see cref="CreateFontIndirect"/> take the localized typeface name only on a system locale that matches the language,
        /// while they take the English typeface name on all other system locales.
        /// The best method is to try one name and, on failure, try the other.
        /// Note that <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/> return the English typeface name
        /// if the system locale does not match the language of the font.
        /// The font mapper for <see cref="CreateFont"/>, <see cref="CreateFontIndirect"/>, and <see cref="CreateFontIndirectEx"/> recognizes
        /// both the English and the localized typeface name, regardless of locale.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFontIndirectW", SetLastError = true)]
        public static extern HFONT CreateFontIndirect([MarshalAs(UnmanagedType.LPStruct)][In]LOGFONT lplf);

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

        /// <summary>
        /// <para>
        /// The <see cref="GetAspectRatioFilterEx"/> function retrieves the setting for the current aspect-ratio filter.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getaspectratiofilterex
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context.
        /// </param>
        /// <param name="lpsize">
        /// Pointer to a <see cref="SIZE"/> structure that receives the current aspect-ratio filter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The aspect ratio is the ratio formed by the width and height of a pixel on a specified device.
        /// The system provides a special filter, the aspect-ratio filter, to select fonts that were designed for a particular device.
        /// An application can specify that the system should only retrieve fonts matching the specified aspect ratio
        /// by calling the <see cref="SetMapperFlags"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAspectRatioFilterEx", SetLastError = true)]
        public static extern BOOL GetAspectRatioFilterEx([In]HDC hdc, [Out]out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextFace"/> function retrieves the typeface name of the font that is selected into the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextfacew
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="c">
        /// The length of the buffer pointed to by <paramref name="lpName"/>.
        /// For the ANSI function it is a <see cref="BYTE"/> count and for the Unicode function it is a <see cref="WORD"/> count.
        /// Note that for the ANSI function, characters in SBCS code pages take one byte each, while most characters in DBCS code pages take two bytes;
        /// for the Unicode function, most currently defined Unicode characters (those in the Basic Multilingual Plane (BMP)) are
        /// one <see cref="WORD"/> while Unicode surrogates are two <see cref="WORD"/>s.
        /// </param>
        /// <param name="lpName">
        /// A pointer to the buffer that receives the typeface name.
        /// If this parameter is <see cref="NULL"/>, the function returns the number of characters in the name, including the terminating null character.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters copied to the buffer.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The typeface name is copied as a null-terminated character string.
        /// If the name is longer than the number of characters specified by the <paramref name="c"/> parameter, the name is truncated.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextFaceW", SetLastError = true)]
        public static extern int GetTextFace([In]HDC hdc, [In]int c, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextMetrics"/> function fills the specified buffer with the metrics for the currently selected font.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextmetrics
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lptm">
        /// A pointer to the <see cref="TEXTMETRIC"/> structure that receives the text metrics.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// To determine whether a font is a TrueType font, first select it into a DC, then call <see cref="GetTextMetrics"/>,
        /// and then check for <see cref="TMPF_TRUETYPE"/> in <see cref="TEXTMETRIC.tmPitchAndFamily"/>.
        /// Note that <see cref="GetDC"/> returns an uninitialized DC, which has "System" (a bitmap font) as the default font;
        /// thus the need to select a font into the DC.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextMetricsW", SetLastError = true)]
        public static extern BOOL GetTextMetrics([In]HDC hdc, [Out]out TEXTMETRIC lptm);

        /// <summary>
        /// <para>
        /// The <see cref="RemoveFontResource"/> function removes the fonts in the specified file from the system font table.
        /// If the font was added using the <see cref="AddFontResourceEx"/> function, you must use the <see cref="RemoveFontResourceEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-removefontresourcew
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// A pointer to a null-terminated string that names a font resource file.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// We recommend that if an app adds or removes fonts from the system font table that it notify other windows of the change
        /// by sending a <see cref="WM_FONTCHANGE"/> message to all top-level windows in the system.
        /// The app sends this message by calling the <see cref="SendMessage"/> function with the hwnd parameter set to <see cref="HWND_BROADCAST"/>.
        /// If there are outstanding references to a font, the associated resource remains loaded until no device context is using it.
        /// Furthermore, if the font is listed in the font registry (HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts)
        /// and is installed to any location other than the %windir%\fonts\ folder, it may be loaded into other active sessions (including session 0).
        /// When you try to replace an existing font file that contains a font with outstanding references to it, you might get an error
        /// that indicates that the original font can't be deleted because it’s in use even after you call <see cref="RemoveFontResource"/>.
        /// If your app requires that the font file be replaced, to reduce the resource count of the original font to zero,
        /// call <see cref="RemoveFontResource"/> in a loop as shown in this example code.
        /// If you continue to get errors, this is an indication that the font file remains loaded in other sessions.
        /// Make sure the font isn't listed in the font registry and restart the system to ensure the font is unloaded from all sessions.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemoveFontResourceW", SetLastError = true)]
        public static extern BOOL RemoveFontResource([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName);

        /// <summary>
        /// <para>
        /// The <see cref="SetMapperFlags"/> function alters the algorithm the font mapper uses when it maps logical fonts to physical fonts.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setmapperflags
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context that contains the font-mapper flag.
        /// </param>
        /// <param name="flags">
        /// Specifies whether the font mapper should attempt to match a font's aspect ratio to the current device's aspect ratio.
        /// If bit zero is set, the mapper selects only matching fonts.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous value of the font-mapper flag.
        /// If the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="flags"/> parameter is set and no matching fonts exist,
        /// Windows chooses a new aspect ratio and retrieves a font that matches this ratio.
        /// The remaining bits of the <paramref name="flags"/> parameter must be zero.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMapperFlags", SetLastError = true)]
        public static extern DWORD SetMapperFlags([In]HDC hdc, [In]DWORD flags);
    }
}
