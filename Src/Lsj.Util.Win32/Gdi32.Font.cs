using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.AddFontResourceExFlags;
using static Lsj.Util.Win32.Enums.CharacterSets;
using static Lsj.Util.Win32.Enums.ClipPrecisions;
using static Lsj.Util.Win32.Enums.EnumFontTypes;
using static Lsj.Util.Win32.Enums.FontFamilies;
using static Lsj.Util.Win32.Enums.FontPitches;
using static Lsj.Util.Win32.Enums.FontQualities;
using static Lsj.Util.Win32.Enums.FontWeights;
using static Lsj.Util.Win32.Enums.GetCharacterPlacementCharacterClasses;
using static Lsj.Util.Win32.Enums.GetCharacterPlacementFlags;
using static Lsj.Util.Win32.Enums.GetGlyphOutlineFormats;
using static Lsj.Util.Win32.Enums.GraphicsModes;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.OutPrecisions;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.TextMetricPitchAndFamilyFlags;
using static Lsj.Util.Win32.Enums.TrueTypeFontFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="EnumFontFamExProc"/> function is an application defined callback function used with the <see cref="EnumFontFamiliesEx"/> function.
        /// It is used to process the fonts. It is called once for each enumerated font.
        /// The <see cref="FONTENUMPROC"/> type defines a pointer to this callback function.
        /// <see cref="EnumFontFamExProc"/> is a placeholder for the application defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/dd162618(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lpelfe">
        /// A pointer to an <see cref="LOGFONT"/> structure that contains information about the logical attributes of the font.
        /// To obtain additional information about the font,
        /// you can cast the result as an <see cref="ENUMLOGFONTEX"/> or <see cref="ENUMLOGFONTEXDV"/> structure.
        /// </param>
        /// <param name="lpntme">
        /// <para>
        /// A pointer to a structure that contains information about the physical attributes of a font.
        /// The function uses the <see cref="NEWTEXTMETRICEX"/> structure for TrueType fonts;
        /// and the <see cref="TEXTMETRIC"/> structure for other fonts.
        /// </para>
        /// <para>
        /// This can be an <see cref="ENUMTEXTMETRIC"/> structure.
        /// </para>
        /// </param>
        /// <param name="FontType">
        /// <para>
        /// The type of the font. This parameter can be a combination of these values:
        /// </para>
        /// <para>
        /// <see cref="DEVICE_FONTTYPE"/>
        /// </para>
        /// <para>
        /// <see cref="RASTER_FONTTYPE"/>
        /// </para>
        /// <para>
        /// <see cref="TRUETYPE_FONTTYPE"/>
        /// </para>
        /// </param>
        /// <param name="lParam">
        /// The application-defined data passed by the <see cref="EnumFontFamiliesEx"/> function.
        /// </param>
        /// <returns>
        /// The return value must be a nonzero value to continue enumeration; to stop enumeration, the return value must be zero.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application must register this callback function by passing its address to the <see cref="EnumFontFamiliesEx"/> function.
        /// </para>
        /// <para>
        /// When the graphics mode on the device context is set to <see cref="GM_ADVANCED"/> using the <see cref="SetGraphicsMode"/> function
        /// and the <see cref="DEVICE_FONTTYPE"/> flag is passed to the <paramref name="FontType"/> parameter,
        /// this function returns a list of type 1 and OpenType fonts on the system.
        /// When the graphics mode is not set to <see cref="GM_ADVANCED"/>,
        /// this function returns a list of type 1, OpenType, and TrueType fonts on the system.
        /// </para>
        /// <para>
        /// Unlike the EnumFontFamProc callback function, <see cref="EnumFontFamExProc"/> receives extended information about a font.
        /// The <see cref="ENUMLOGFONTEX"/> structure includes the localized name of the script (character set)
        /// and the <see cref="NEWTEXTMETRICEX"/> structure includes a font-coverage signature.
        /// </para>
        /// </remarks>
        public delegate int EnumFontFamExProc([In] P<LOGFONT> lpelfe, [In] P<TEXTMETRIC> lpntme, [In] EnumFontTypes FontType, [In] LPARAM lParam);


        /// <summary>
        /// <para>
        /// The <see cref="AddFontMemResourceEx"/> function adds the font resource from a memory image to the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-addfontmemresourceex"/>
        /// </para>
        /// </summary>
        /// <param name="pFileView">
        /// A pointer to a font resource.
        /// </param>
        /// <param name="cjSize">
        /// The number of bytes in the font resource that is pointed to by <paramref name="pFileView"/>.
        /// </param>
        /// <param name="pvResrved">
        /// Reserved. Must be 0.
        /// </param>
        /// <param name="pNumFonts">
        /// A pointer to a variable that specifies the number of fonts installed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the handle to the font added.
        /// This handle uniquely identifies the fonts that were installed on the system.
        /// If the function fails, the return value is zero.
        /// No extended error information is available.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function allows an application to get a font that is embedded in a document or a webpage.
        /// A font that is added by <see cref="AddFontMemResourceEx"/> is always private to the process that made the call and is not enumerable.
        /// </para>
        /// <para>
        /// A memory image can contain more than one font.
        /// When this function succeeds, <paramref name="pNumFonts"/> is a pointer to a <see cref="DWORD"/>
        /// whose value is the number of fonts added to the system as a result of this call.
        /// For example, this number could be 2 for the vertical and horizontal faces of an Asian font.
        /// </para>
        /// <para>
        /// When the function succeeds, the caller of this function can free the memory pointed to by <paramref name="pFileView"/>
        /// because the system has made its own copy of the memory.
        /// To remove the fonts that were installed, call <see cref="RemoveFontMemResourceEx"/>.
        /// However, when the process goes away, the system will unload the fonts even if the process did not call <see cref="RemoveFontMemResourceEx"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddFontMemResourceEx", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE AddFontMemResourceEx([In] PVOID pFileView, [In] DWORD cjSize, [In] PVOID pvResrved, [In] in DWORD pNumFonts);

        /// <summary>
        /// <para>
        /// The <see cref="AddFontResource"/> function adds the font resource from the specified file to the system font table.
        /// The font can subsequently be used for text output by any application.
        /// </para>
        /// <para>
        /// To mark a font as private or not enumerable, use the <see cref="AddFontResourceEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-addfontresourcew"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// <para>
        /// A pointer to a null-terminated character string that contains a valid font file name.
        /// This parameter can specify any of the following files.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// File Extension
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// .fon
        /// </term>
        /// <term>
        /// Font resource file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .fnt
        /// </term>
        /// <term>
        /// Raw bitmap font file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .ttf
        /// </term>
        /// <term>
        /// Raw TrueType file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .ttc
        /// </term>
        /// <term>
        /// East Asian Windows: TrueType font collection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .fot
        /// </term>
        /// <term>
        /// TrueType resource file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .otf
        /// </term>
        /// <term>
        /// PostScript OpenType font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .mmm
        /// </term>
        /// <term>
        /// Multiple master Type1 font resource file. It must be used with .pfm and .pfb files.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .pfb
        /// </term>
        /// <term>
        /// Type 1 font bits file. It is used with a .pfm file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .pfm
        /// </term>
        /// <term>
        /// Type 1 font metrics file. It is used with a .pfb file.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To add a font whose information comes from several resource files, have <paramref name="unnamedParam1"/> point to a string
        /// with the file names separated by a "|" --for example, abcxxxxx.pfm | abcxxxxx.pfb.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the number of fonts added.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// No extended error information is available.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Any application that adds or removes fonts from the system font table should notify other windows of the change
        /// by sending a <see cref="WM_FONTCHANGE"/> message to all top-level windows in the operating system.
        /// The application should send this message by calling the <see cref="SendMessage"/> function and setting the hwnd parameter to <see cref="HWND_BROADCAST"/>.
        /// </para>
        /// <para>
        /// When an application no longer needs a font resource that it loaded by calling the <see cref="AddFontResource"/> function,
        /// it must remove that resource by calling the <see cref="RemoveFontResource"/> function.
        /// </para>
        /// <para>
        /// This function installs the font only for the current session. When the system restarts, the font will not be present.
        /// To have the font installed even after restarting the system, the font must be listed in the registry.
        /// </para>
        /// <para>
        /// A font listed in the registry and installed to a location other than the %windir%\fonts\ folder
        /// cannot be modified, deleted, or replaced as long as it is loaded in any session.
        /// In order to change one of these fonts, it must first be removed by calling <see cref="RemoveFontResource"/>,
        /// removed from the font registry (HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts), and the system restarted.
        /// After restarting the system, the font will no longer be loaded and can be changed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddFontResourceW", ExactSpelling = true, SetLastError = true)]
        public static extern int AddFontResource([In] LPCWSTR unnamedParam1);

        /// <summary>
        /// <para>
        /// The <see cref="AddFontResourceEx"/> function adds the font resource from the specified file to the system.
        /// Fonts added with the <see cref="AddFontResourceEx"/> function can be marked as private and not enumerable.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-addfontresourceexw"/>
        /// </para>
        /// </summary>
        /// <param name="name">
        /// <para>
        /// A pointer to a null-terminated character string that contains a valid font file name.
        /// This parameter can specify any of the following files.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// File Extension
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// .fon
        /// </term>
        /// <term>
        /// Font resource file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .fnt
        /// </term>
        /// <term>
        /// Raw bitmap font file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .ttf
        /// </term>
        /// <term>
        /// Raw TrueType file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .ttc
        /// </term>
        /// <term>
        /// East Asian Windows: TrueType font collection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .fot
        /// </term>
        /// <term>
        /// TrueType resource file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .otf
        /// </term>
        /// <term>
        /// PostScript OpenType font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .mmm
        /// </term>
        /// <term>
        /// multiple master Type1 font resource file. It must be used with .pfm and .pfb files.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .pfb
        /// </term>
        /// <term>
        /// Type 1 font bits file. It is used with a .pfm file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// .pfm
        /// </term>
        /// <term>
        /// Type 1 font metrics file. It is used with a .pfb file.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// To add a font whose information comes from several resource files, point <paramref name="name"/> to a string
        /// with the file names separated by a | --for example, abcxxxxx.pfm | abcxxxxx.pfb.
        /// </para>
        /// </param>
        /// <param name="fl">
        /// <para>
        /// The characteristics of the font to be added to the system. This parameter can be one of the following values.
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
        /// <see cref="FR_PRIVATE"/>
        /// </term>
        /// <term>
        /// Specifies that only the process that called the <see cref="AddFontResourceEx"/> function can use this font.
        /// When the font name matches a public font, the private font will be chosen.
        /// When the process terminates, the system will remove all fonts installed by the process with the <see cref="AddFontResourceEx"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FR_NOT_ENUM"/>
        /// </term>
        /// <term>
        /// Specifies that no process, including the process that called the <see cref="AddFontResourceEx"/> function, can enumerate this font.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="res">
        /// Reserved. Must be zero.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the number of fonts added.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero. No extended error information is available.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function allows a process to use fonts without allowing other processes access to the fonts.
        /// </para>
        /// <para>
        /// When an application no longer needs a font resource it loaded by calling the <see cref="AddFontResourceEx"/> function,
        /// it must remove the resource by calling the <see cref="RemoveFontResourceEx"/> function.
        /// </para>
        /// <para>
        /// This function installs the font only for the current session. When the system restarts, the font will not be present.
        /// To have the font installed even after restarting the system, the font must be listed in the registry.
        /// </para>
        /// <para>
        /// A font listed in the registry and installed to a location other than the %windir%\fonts\ folder
        /// cannot be modified, deleted, or replaced as long as it is loaded in any session.
        /// In order to change one of these fonts, it must first be removed by calling <see cref="RemoveFontResource"/>,
        /// removed from the font registry (HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts), and the system restarted.
        /// After restarting the system, the font will no longer be loaded and can be changed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddFontResourceExW", ExactSpelling = true, SetLastError = true)]
        public static extern int AddFontResourceEx([In] LPCWSTR name, [In] AddFontResourceExFlags fl, [In] PVOID res);

        /// <summary>
        /// <para>
        /// The <see cref="CreateFont"/> function creates a logical font with the specified characteristics.
        /// The logical font can subsequently be selected as the font for any device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createfontw"/>
        /// </para>
        /// </summary>
        /// <param name="cHeight">
        /// <para>
        /// The height, in logical units, of the font's character cell or character.
        /// The character height value (also known as the em height) is the character cell height value minus the internal-leading value.
        /// The font mapper interprets the value specified in <paramref name="cHeight"/> in the following manner.
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
        /// &gt; 0
        /// </term>
        /// <term>
        /// The font mapper transforms this value into device units and matches it against the cell height of the available fonts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// The font mapper uses a default height value when it searches for a match.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// &lt; 0
        /// </term>
        /// <term>
        /// The font mapper transforms this value into device units and matches its absolute value against the character height of the available fonts.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For all height comparisons, the font mapper looks for the largest font that does not exceed the requested size.
        /// </para>
        /// <para>
        /// This mapping occurs when the font is used for the first time.
        /// </para>
        /// <para>
        /// For the <see cref="MM_TEXT"/> mapping mode, you can use the following formula to specify a height for a font with a specified point size:
        /// </para>
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
        /// <para>
        /// The angle, in tenths of degrees, between the escapement vector and the x-axis of the device.
        /// The escapement vector is parallel to the base line of a row of text.
        /// </para>
        /// <para>
        /// When the graphics mode is set to <see cref="GM_ADVANCED"/>,
        /// you can specify the escapement angle of the string independently of the orientation angle of the string's characters.
        /// </para>
        /// <para>
        /// When the graphics mode is set to <see cref="GM_COMPATIBLE"/>, <paramref name="cEscapement"/> specifies both the escapement and orientation.
        /// You should set <paramref name="cEscapement"/> and <paramref name="cOrientation"/> to the same value.
        /// </para>
        /// </param>
        /// <param name="cOrientation">
        /// The angle, in tenths of degrees, between each character's base line and the x-axis of the device.
        /// </param>
        /// <param name="cWeight">
        /// <para>
        /// The weight of the font in the range 0 through 1000.
        /// For example, 400 is normal and 700 is bold.
        /// If this value is zero, a default weight is used.
        /// </para>
        /// <para>
        /// The following values are defined for convenience.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Weight
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="FW_DONTCARE"/>
        /// </term>
        /// <term>
        /// 0
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_THIN"/>
        /// </term>
        /// <term>
        /// 100
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_EXTRALIGHT"/>
        /// </term>
        /// <term>
        /// 200
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_ULTRALIGHT"/>
        /// </term>
        /// <term>
        /// 200
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_LIGHT"/>
        /// </term>
        /// <term>
        /// 300
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_NORMAL"/>
        /// </term>
        /// <term>
        /// 400
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_REGULAR"/>
        /// </term>
        /// <term>
        /// 400
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_MEDIUM"/>
        /// </term>
        /// <term>
        /// 500
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_SEMIBOLD"/>
        /// </term>
        /// <term>
        /// 600
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_DEMIBOLD"/>
        /// </term>
        /// <term>
        /// 600
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_BOLD"/>
        /// </term>
        /// <term>
        /// 700
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_EXTRABOLD"/>
        /// </term>
        /// <term>
        /// 800
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_ULTRABOLD"/>
        /// </term>
        /// <term>
        /// 800
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_HEAVY"/>
        /// </term>
        /// <term>
        /// 900
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FW_BLACK"/>
        /// </term>
        /// <term>
        /// 900
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        /// <para>
        /// The character set. For a list of possible values, see <see cref="LOGFONT.lfCharSet"/> field of the <see cref="LOGFONT"/> structure.
        /// </para>
        /// <para>
        /// Fonts with other character sets may exist in the operating system.
        /// If an application uses a font with an unknown character set,
        /// it should not attempt to translate or interpret strings that are rendered with that font.
        /// </para>
        /// <para>
        /// To ensure consistent results when creating a font, do not specify <see cref="OEM_CHARSET"/> or <see cref="DEFAULT_CHARSET"/>.
        /// If you specify a typeface name in the <paramref name="pszFaceName"/> parameter,
        /// make sure that the <paramref name="iCharSet"/> value matches the character set of the typeface specified in <paramref name="pszFaceName"/>.
        /// </para>
        /// </param>
        /// <param name="iOutPrecision">
        /// <para>
        /// The output precision.
        /// The output precision defines how closely the output must match the requested font's height, width,
        /// character orientation, escapement, pitch, and font type.
        /// It can be one of the following values.
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
        /// <see cref="OUT_CHARACTER_PRECIS"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OUT_DEFAULT_PRECIS"/>
        /// </term>
        /// <term>
        /// The default font mapper behavior.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OUT_DEVICE_PRECIS"/>
        /// </term>
        /// <term>
        /// Instructs the font mapper to choose a Device font when the system contains multiple fonts with the same name.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OUT_OUTLINE_PRECIS"/>
        /// </term>
        /// <term>
        /// This value instructs the font mapper to choose from TrueType and other outline-based fonts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OUT_PS_ONLY_PRECIS"/>
        /// </term>
        /// <term>
        /// Instructs the font mapper to choose from only PostScript fonts.
        /// If there are no PostScript fonts installed in the system, the font mapper returns to default behavior.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OUT_RASTER_PRECIS"/>
        /// </term>
        /// <term>
        /// Instructs the font mapper to choose a raster font when the system contains multiple fonts with the same name.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OUT_STRING_PRECIS"/>
        /// </term>
        /// <term>
        /// This value is not used by the font mapper, but it is returned when raster fonts are enumerated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OUT_STROKE_PRECIS"/>
        /// </term>
        /// <term>
        /// This value is not used by the font mapper, but it is returned when TrueType, other outline-based fonts, and vector fonts are enumerated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OUT_TT_ONLY_PRECIS"/>
        /// </term>
        /// <term>
        /// Instructs the font mapper to choose from only TrueType fonts.
        /// If there are no TrueType fonts installed in the system, the font mapper returns to default behavior.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OUT_TT_PRECIS"/>
        /// </term>
        /// <term>
        /// Instructs the font mapper to choose a TrueType font when the system contains multiple fonts with the same name.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Applications can use the <see cref="OUT_DEVICE_PRECIS"/>, <see cref="OUT_RASTER_PRECIS"/>, <see cref="OUT_TT_PRECIS"/>,
        /// and <see cref="OUT_PS_ONLY_PRECIS"/> values to control how the font mapper chooses a font
        /// when the operating system contains more than one font with a specified name.
        /// For example, if an operating system contains a font named Symbol in raster and TrueType form,
        /// specifying <see cref="OUT_TT_PRECIS"/> forces the font mapper to choose the TrueType version.
        /// Specifying <see cref="OUT_TT_ONLY_PRECIS"/> forces the font mapper to choose a TrueType font,
        /// even if it must substitute a TrueType font of another name.
        /// </para>
        /// </param>
        /// <param name="iClipPrecision">
        /// <para>
        /// The clipping precision.
        /// The clipping precision defines how to clip characters that are partially outside the clipping region.
        /// It can be one or more of the following values.
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
        /// <see cref="CLIP_CHARACTER_PRECIS"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLIP_DEFAULT_PRECIS"/>
        /// </term>
        /// <term>
        /// Specifies default clipping behavior.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLIP_DFA_DISABLE"/>
        /// </term>
        /// <term>
        /// Windows XP SP1: Turns off font association for the font.
        /// Note that this flag is not guaranteed to have any effect on any platform after Windows Server 2003.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLIP_EMBEDDED"/>
        /// </term>
        /// <term>
        /// You must specify this flag to use an embedded read-only font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLIP_LH_ANGLES"/>
        /// </term>
        /// <term>
        /// <para>
        /// When this value is used, the rotation for all fonts depends on
        /// whether the orientation of the coordinate system is left-handed or right-handed.
        /// </para>
        /// <para>
        /// If not used, device fonts always rotate counterclockwise,
        /// but the rotation of other fonts is dependent on the orientation of the coordinate system.
        /// </para>
        /// <para>
        /// For more information about the orientation of coordinate systems,
        /// see the description of the <paramref name="cOrientation"/> parameter
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLIP_MASK"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLIP_DFA_OVERRIDE"/>
        /// </term>
        /// <term>
        /// Turns off font association for the font.
        /// This is identical to <see cref="CLIP_DFA_DISABLE"/>, but it can have problems in some situations;
        /// the recommended flag to use is <see cref="CLIP_DFA_DISABLE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLIP_STROKE_PRECIS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Not used by the font mapper, but is returned when raster, vector, or TrueType fonts are enumerated.
        /// </para>
        /// <para>
        /// For compatibility, this value is always returned when enumerating fonts.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLIP_TT_ALWAYS"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="iQuality">
        /// <para>
        /// The output quality.
        /// The output quality defines how carefully GDI must attempt to match the logical-font attributes to those of an actual physical font.
        /// It can be one of the following values.
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
        /// <see cref="ANTIALIASED_QUALITY"/>
        /// </term>
        /// <term>
        /// Font is antialiased, or smoothed, if the font supports it and the size of the font is not too small or too large.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLEARTYPE_QUALITY"/>
        /// </term>
        /// <term>
        /// If set, text is rendered (when possible) using ClearType antialiasing method. See Remarks for more information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DEFAULT_QUALITY"/>
        /// </term>
        /// <term>
        /// Appearance of the font does not matter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DRAFT_QUALITY"/>
        /// </term>
        /// <term>
        /// Appearance of the font is less important than when the <see cref="PROOF_QUALITY"/> value is used.
        /// For GDI raster fonts, scaling is enabled, which means that more font sizes are available, but the quality may be lower.
        /// Bold, italic, underline, and strikeout fonts are synthesized, if necessary.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NONANTIALIASED_QUALITY"/>
        /// </term>
        /// <term>
        /// Font is never antialiased, that is, font smoothing is not done.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROOF_QUALITY"/>
        /// </term>
        /// <term>
        /// Character quality of the font is more important than exact matching of the logical-font attributes.
        /// For GDI raster fonts, scaling is disabled and the font closest in size is chosen.
        /// Although the chosen font size may not be mapped exactly when <see cref="PROOF_QUALITY"/> is used,
        /// the quality of the font is high and there is no distortion of appearance.
        /// Bold, italic, underline, and strikeout fonts are synthesized, if necessary.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the output quality is <see cref="DEFAULT_QUALITY"/>, <see cref="DRAFT_QUALITY"/>, or <see cref="PROOF_QUALITY"/>,
        /// then the font is antialiased if the <see cref="SPI_GETFONTSMOOTHING"/> system parameter is <see cref="TRUE"/>.
        /// Users can control this system parameter from the Control Panel.
        /// (The precise wording of the setting in the Control panel depends on the version of Windows,
        /// but it will be words to the effect of "Smooth edges of screen fonts".)
        /// </para>
        /// </param>
        /// <param name="iPitchAndFamily">
        /// <para>
        /// The pitch and family of the font.
        /// The two low-order bits specify the pitch of the font and can be one of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DEFAULT_PITCH"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FIXED_PITCH"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="VARIABLE_PITCH"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The four high-order bits specify the font family and can be one of the following values.
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
        /// <see cref="FF_DECORATIVE"/>
        /// </term>
        /// <term>
        /// Novelty fonts. Old English is an example.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FF_DONTCARE"/>
        /// </term>
        /// <term>
        /// Use default font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FF_MODERN"/>
        /// </term>
        /// <term>
        /// Fonts with constant stroke width, with or without serifs.
        /// Pica, Elite, and Courier New are examples.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FF_ROMAN"/>
        /// </term>
        /// <term>
        /// Fonts with variable stroke width and with serifs. MS Serif is an example.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FF_SCRIPT"/>
        /// </term>
        /// <term>
        /// Fonts designed to look like handwriting. Script and Cursive are examples.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FF_SWISS"/>
        /// </term>
        /// <term>
        /// Fonts with variable stroke width and without serifs. MS?Sans Serif is an example.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// An application can specify a value for the <paramref name="iPitchAndFamily"/> parameter
        /// by using the Boolean OR operator to join a pitch constant with a family constant.
        /// </para>
        /// <para>
        /// Font families describe the look of a font in a general way.
        /// They are intended for specifying fonts when the exact typeface requested is not available.
        /// </para>
        /// </param>
        /// <param name="pszFaceName">
        /// <para>
        /// A pointer to a null-terminated string that specifies the typeface name of the font.
        /// The length of this string must not exceed 32 characters, including the terminating null character.
        /// The <see cref="EnumFontFamilies"/> function can be used to enumerate the typeface names of all currently available fonts.
        /// For more information, see the Remarks.
        /// </para>
        /// <para>
        /// If <paramref name="pszFaceName"/> is <see cref="NULL"/> or empty string,
        /// GDI uses the first font that matches the other specified attributes.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to a logical font.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you no longer need the font, call the <see cref="DeleteObject"/> function to delete it.
        /// </para>
        /// <para>
        /// To help protect the copyrights of vendors who provide fonts for Windows,
        /// applications should always report the exact name of a selected font.
        /// Because available fonts can vary from system to system, do not assume that the selected font is always the same as the requested font.
        /// For example, if you request a font named Palatino, but no such font is available on the system,
        /// the font mapper will substitute a font that has similar attributes but a different name.
        /// Always report the name of the selected font to the user.
        /// </para>
        /// <para>
        /// To get the appropriate font on different language versions of the OS,
        /// call <see cref="EnumFontFamiliesEx"/> with the desired font characteristics in the <see cref="LOGFONT"/> structure,
        /// then retrieve the appropriate typeface name and create the font using <see cref="CreateFont"/> or <see cref="CreateFontIndirect"/>.
        /// </para>
        /// <para>
        /// The font mapper for <see cref="CreateFont"/>,<see cref="CreateFontIndirect"/>,
        /// and <see cref="CreateFontIndirectEx"/> recognizes both the English and the localized typeface name, regardless of locale.
        /// </para>
        /// <para>
        /// The following situations do not support ClearType antialiasing:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Text rendered on a printer.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A display set for 256 colors or less.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Text rendered to a terminal server client.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The font is not a TrueType font or an OpenType font with TrueType outlines.
        /// For example, the following do not support ClearType antialiasing:
        /// Type 1 fonts, Postscript OpenType fonts without TrueType outlines, bitmap fonts, vector fonts, and device fonts.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The font has tuned embedded bitmaps, only for the font sizes that contain the embedded bitmaps.
        /// For example, this occurs commonly in East Asian fonts.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFontW", ExactSpelling = true, SetLastError = true)]
        public static extern HFONT CreateFont([In] int cHeight, [In] int cWidth, [In] int cEscapement, [In] int cOrientation, [In] int cWeight,
            [In] DWORD bItalic, [In] DWORD bUnderline, [In] DWORD bStrikeOut, [In] DWORD iCharSet, [In] DWORD iOutPrecision, [In] DWORD iClipPrecision,
            [In] DWORD iQuality, [In] DWORD iPitchAndFamily, [In] LPCWSTR pszFaceName);

        /// <summary>
        /// <para>
        /// The <see cref="CreateFontIndirect"/> function creates a logical font that has the specified characteristics.
        /// The font can subsequently be selected as the current font for any device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createfontindirectw"/>
        /// </para>
        /// </summary>
        /// <param name="lplf">
        /// A pointer to a <see cref="LOGFONT"/> structure that defines the characteristics of the logical font.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to a logical font.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateFontIndirect"/> function creates a logical font with the characteristics specified in the <see cref="LOGFONT"/> structure.
        /// When this font is selected by using the <see cref="SelectObject"/> function,
        /// GDI's font mapper attempts to match the logical font with an existing physical font.
        /// If it fails to find an exact match, it provides an alternative whose characteristics match as many of the requested characteristics as possible.
        /// </para>
        /// <para>
        /// To get the appropriate font on different language versions of the OS,
        /// call <see cref="EnumFontFamiliesEx"/> with the desired font characteristics in the <see cref="LOGFONT"/> structure,
        /// retrieve the appropriate typeface name, and create the font using <see cref="CreateFont"/> or <see cref="CreateFontIndirect"/>.
        /// </para>
        /// <para>
        /// When you no longer need the font, call the <see cref="DeleteObject"/> function to delete it.
        /// </para>
        /// <para>
        /// The fonts for many East Asian languages have two typeface names:
        /// an English name and a localized name. <see cref="CreateFont"/> and <see cref="CreateFontIndirect"/>
        /// take the localized typeface name only on a system locale that matches the language,
        /// while they take the English typeface name on all other system locales.
        /// The best method is to try one name and, on failure, try the other.
        /// Note that <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/>
        /// return the English typeface name if the system locale does not match the language of the font.
        /// </para>
        /// <para>
        /// The font mapper for <see cref="CreateFont"/>, <see cref="CreateFontIndirect"/>, and <see cref="CreateFontIndirectEx"/>
        /// recognizes both the English and the localized typeface name, regardless of locale.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFontIndirectW", ExactSpelling = true, SetLastError = true)]
        public static extern HFONT CreateFontIndirect([In] in LOGFONT lplf);

        /// <summary>
        /// <para>
        /// The <see cref="CreateFontIndirectEx"/> function specifies a logical font that has the characteristics in the specified structure.
        /// The font can subsequently be selected as the current font for any device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createfontindirectexw"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// <para>
        /// Pointer to an <see cref="ENUMLOGFONTEXDV"/> structure that defines the characteristics of a multiple master font.
        /// </para>
        /// <para>
        /// Note, this function ignores the <see cref="ENUMLOGFONTEXDV.elfDesignVector"/> member in <see cref="ENUMLOGFONTEXDV"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the new <see cref="ENUMLOGFONTEXDV"/> structure.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// No extended error information is available.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateFontIndirectEx"/> function creates a logical font
        /// with the characteristics specified in the <see cref="ENUMLOGFONTEXDV"/> structure.
        /// When this font is selected by using the <see cref="SelectObject"/> function,
        /// GDI's font mapper attempts to match the logical font with an existing physical font.
        /// If it fails to find an exact match, it provides an alternative whose characteristics match as many of the requested characteristics as possible.
        /// </para>
        /// <para>
        /// When you no longer need the font, call the <see cref="DeleteObject"/> function to delete it.
        /// </para>
        /// <para>
        /// The font mapper for <see cref="CreateFont"/>, <see cref="CreateFontIndirect"/>, and <see cref="CreateFontIndirectEx"/>
        /// recognizes both the English and the localized typeface name, regardless of locale.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFontIndirectExW", ExactSpelling = true, SetLastError = true)]
        public static extern HFONT CreateFontIndirectEx([In] in ENUMLOGFONTEXDV unnamedParam1);

        /// <summary>
        /// <para>
        /// The <see cref="CreateScalableFontResource"/> function creates a font resource file for a scalable font.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createscalablefontresourcew"/>
        /// </para>
        /// </summary>
        /// <param name="fdwHidden">
        /// <para>
        /// Specifies whether the font is a read-only font.
        /// This parameter can be one of the following values.
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
        /// 0
        /// </term>
        /// <term>
        /// The font has read/write permission.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// The font has read-only permission and should be hidden from other applications in the system.
        /// When this flag is set, the font is not enumerated by the <see cref="EnumFonts"/> or <see cref="EnumFontFamilies"/> function.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpszFont">
        /// A pointer to a null-terminated string specifying the name of the font resource file to create.
        /// If this parameter specifies an existing font resource file, the function fails.
        /// </param>
        /// <param name="lpszFile">
        /// A pointer to a null-terminated string specifying the name of the scalable font file
        /// that this function uses to create the font resource file.
        /// </param>
        /// <param name="lpszPath">
        /// A pointer to a null-terminated string specifying the path to the scalable font file.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// <para>
        /// If <paramref name="lpszFont"/> specifies an existing font file, <see cref="GetLastError"/> returns <see cref="ERROR_FILE_EXISTS"/>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateScalableFontResource"/> function is used by applications that install TrueType fonts.
        /// An application uses the <see cref="CreateScalableFontResource"/> function to create a font resource file
        /// (typically with a .fot file name extension) and then uses the <see cref="AddFontResource"/> function to install the font.
        /// The TrueType font file (typically with a .ttf file name extension) must be
        /// in the System subdirectory of the Windows directory to be used by the <see cref="AddFontResource"/> function.
        /// </para>
        /// <para>
        /// The <see cref="CreateScalableFontResource"/> function currently supports only TrueType-technology scalable fonts.
        /// </para>
        /// <para>
        /// When the <paramref name="lpszFile"/> parameter specifies only a file name and extension,
        /// the <paramref name="lpszPath"/> parameter must specify a path.
        /// When the <paramref name="lpszFile"/> parameter specifies a full path,
        /// the <paramref name="lpszPath"/> parameter must be <see cref="NULL"/> or a pointer to <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// When only a file name and extension are specified in the <paramref name="lpszFile"/> parameter
        /// and a path is specified in the <paramref name="lpszPath"/> parameter,
        /// the string in <paramref name="lpszFile"/> is copied into the .fot file as the .ttf file that belongs to this resource.
        /// When the <see cref="AddFontResource"/> function is called, the operating system assumes that the .ttf file
        /// has been copied into the System directory (or into the main Windows directory in the case of a network installation).
        /// The .ttf file need not be in this directory when the <see cref="CreateScalableFontResource"/> function is called,
        /// because the <paramref name="lpszPath"/> parameter contains the directory information.
        /// A resource created in this manner does not contain absolute path information and can be used in any installation.
        /// </para>
        /// <para>
        /// When a path is specified in the <paramref name="lpszFile"/> parameter
        /// and <see cref="NULL"/> is specified in the <paramref name="lpszPath"/> parameter,
        /// the string in <paramref name="lpszFile"/> is copied into the .fot file.
        /// In this case, when the <see cref="AddFontResource"/> function is called,
        /// the .ttf file must be at the location specified in the <paramref name="lpszFile"/> parameter
        /// when the <see cref="CreateScalableFontResource"/> function was called; the <paramref name="lpszPath"/> parameter is not needed.
        /// A resource created in this manner contains absolute references to paths and drives
        /// and does not work if the .ttf file is moved to a different location.
        /// </para>
        /// </remarks>
        [Obsolete("The CreateScalableFontResource function is available for use in the operating systems specified in the Requirements section." +
            "It may be altered or unavailable in subsequent versions.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateScalableFontResourceW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateScalableFontResource([In] DWORD fdwHidden, [In] LPWSTR lpszFont, [In] LPWSTR lpszFile, [In] LPWSTR lpszPath);

        /// <summary>
        /// <para>
        /// This function enables or disables support for end-user-defined characters (EUDC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/enableeudc"/>
        /// </para>
        /// </summary>
        /// <param name="bEnable">
        /// Boolean that is set to <see cref="TRUE"/> to enable EUDC, and to <see cref="FALSE"/> to disable EUDC.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If EUDC is disabled, trying to display EUDC characters will result in missing or bad glyphs.
        /// </para>
        /// <para>
        /// During multi-session, this function affects the current session only.
        /// </para>
        /// <para>
        /// It is recommended that you use this function with Windows XP SP2 or later.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// EnableEUDC is recommended to be called only once, as repeated calls may cause performance degradation.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableEUDC", ExactSpelling = true)]
        public static extern BOOL EnableEUDC([In] BOOL bEnable);

        /// <summary>
        /// <para>
        /// The <see cref="EnumFontFamilies"/> function enumerates the fonts in a specified font family that are available on a specified device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumfontfamiliesw"/>
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
        /// <para>
        /// For each font having the typeface name specified by the <paramref name="lpLogfont"/> parameter,
        /// the <see cref="EnumFontFamilies"/> function retrieves information about that font
        /// and passes it to the function pointed to by the <paramref name="lpProc"/> parameter.
        /// The application defined callback function can process the font information as desired.
        /// Enumeration continues until there are no more fonts or the callback function returns zero.
        /// </para>
        /// <para>
        /// When the graphics mode on the device context is set to <see cref="GM_ADVANCED"/> using the <see cref="SetGraphicsMode"/> function
        /// and the <see cref="DEVICE_FONTTYPE"/> flag is passed to the FontType parameter,
        /// this function returns a list of type 1 and OpenType fonts on the system.
        /// When the graphics mode is not set to <see cref="GM_ADVANCED"/>, this function returns a list of type 1, OpenType, and TrueType fonts on the system.
        /// </para>
        /// <para>
        /// The fonts for many East Asian languages have two typeface names: an English name and a localized name.
        /// <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/>
        /// return the English typeface name if the system locale does not match the language of the font.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            " Applications should use the EnumFontFamiliesEx function.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumFontFamiliesW", ExactSpelling = true, SetLastError = true)]
        public static extern int EnumFontFamilies([In] IntPtr hdc, [In] LPCWSTR lpLogfont, [In] FONTENUMPROC lpProc, [In] IntPtr lParam);

        /// <summary>
        /// <para>
        /// The <see cref="EnumFontFamiliesEx"/> function enumerates all uniquely-named fonts in the system
        /// that match the font characteristics specified by the <see cref="LOGFONT"/> structure.
        /// <see cref="EnumFontFamiliesEx"/> enumerates fonts based on typeface name, character set, or both.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumfontfamiliesexw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context from which to enumerate the fonts.
        /// </param>
        /// <param name="lpLogfont">
        /// <para>
        /// A pointer to a <see cref="LOGFONT"/> structure that contains information about the fonts to enumerate.
        /// The function examines the following members.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Member
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="LOGFONT.lfCharSet"/>
        /// </term>
        /// <term>
        /// If set to <see cref="DEFAULT_CHARSET"/>, the function enumerates all uniquely-named fonts in all character sets.
        /// (If there are two fonts with the same name, only one is enumerated.)
        /// If set to a valid character set value, the function enumerates only fonts in the specified character set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGFONT.lfFaceName"/>
        /// </term>
        /// <term>
        /// If set to an empty string, the function enumerates one font in each available typeface name.
        /// If set to a valid typeface name, the function enumerates all fonts with the specified name.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGFONT.lfPitchAndFamily"/>
        /// </term>
        /// <term>
        /// Must be set to zero for all language versions of the operating system.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        /// <para>
        /// The <see cref="EnumFontFamiliesEx"/> function does not use tagged typeface names to identify character sets.
        /// Instead, it always passes the correct typeface name and a separate character set value to the callback function.
        /// The function enumerates fonts based on the values of the <see cref="LOGFONT.lfCharSet"/>
        /// and <see cref="LOGFONT.lfFaceName"/> members in the <see cref="LOGFONT"/> structure.
        /// </para>
        /// <para>
        /// As with <see cref="EnumFontFamilies"/>, <see cref="EnumFontFamiliesEx"/> enumerates all font styles.
        /// Not all styles of a font cover the same character sets.
        /// For example, Fontorama Bold might contain ANSI, Greek, and Cyrillic characters, but Fontorama Italic might contain only ANSI characters.
        /// For this reason, it's best not to assume that a specified font covers a specific character set, even if it is the ANSI character set.
        /// The following table shows the results of various combinations of values for <see cref="LOGFONT.lfCharSet"/> and <see cref="LOGFONT.lfFaceName"/>.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Values
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LOGFONT.lfCharSet"/> = <see cref="DEFAULT_CHARSET"/>
        /// </para>
        /// <para>
        /// <see cref="LOGFONT.lfFaceName"/> = '\0'
        /// </para>
        /// </term>
        /// <term>
        /// Enumerates all uniquely-named fonts within all character sets.
        /// If there are two fonts with the same name, only one is enumerated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LOGFONT.lfCharSet"/> = <see cref="DEFAULT_CHARSET"/>
        /// </para>
        /// <para>
        /// <see cref="LOGFONT.lfFaceName"/> = a specific font
        /// </para>
        /// </term>
        /// <term>
        /// Enumerates all character sets and styles in a specific font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LOGFONT.lfCharSet"/> =a specific character set
        /// </para>
        /// <para>
        /// <see cref="LOGFONT.lfFaceName"/> = '\0'
        /// </para>
        /// </term>
        /// <term>
        /// Enumerates all styles of all fonts in the specific character set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LOGFONT.lfCharSet"/> =a specific character set
        /// </para>
        /// <para>
        /// <see cref="LOGFONT.lfFaceName"/> = a specific font
        /// </para>
        /// </term>
        /// <term>
        /// Enumerates all styles of a font in a specific character set.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following code sample shows how these values are used.
        /// </para>
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
        /// <para>
        /// The callback functions for <see cref="EnumFontFamilies"/> and <see cref="EnumFontFamiliesEx"/> are very similar.
        /// The main difference is that the <see cref="ENUMLOGFONTEX"/> structure includes a script field.
        /// </para>
        /// <para>
        /// Note, based on the values of <see cref="LOGFONT.lfCharSet"/> and <see cref="LOGFONT.lfFaceName"/>,
        /// <see cref="EnumFontFamiliesEx"/> will enumerate the same font as many times as there are distinct character sets in the font.
        /// This can create an extensive list of fonts which can be burdensome to a user.
        /// For example, the Century Schoolbook font can appear for the Baltic, Western, Greek, Turkish, and Cyrillic character sets.
        /// To avoid this, an application should filter the list of fonts.
        /// </para>
        /// <para>
        /// The fonts for many East Asian languages have two typeface names: an English name and a localized name.
        /// <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/> return the English typeface name
        /// if the system locale does not match the language of the font.
        /// </para>
        /// <para>
        /// When the graphics mode on the device context is set to <see cref="GM_ADVANCED"/> using the <see cref="SetGraphicsMode"/> function
        /// and the <see cref="DEVICE_FONTTYPE"/> flag is passed to the FontType parameter,
        /// this function returns a list of type 1 and OpenType fonts on the system.
        /// When the graphics mode is not set to <see cref="GM_ADVANCED"/>,
        /// this function returns a list of type 1, OpenType, and TrueType fonts on the system.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumFontFamiliesExW", ExactSpelling = true, SetLastError = true)]
        public static extern int EnumFontFamiliesEx([In] IntPtr hdc, [In] ref LOGFONT lpLogfont, [In] FONTENUMPROC lpProc,
            [In] IntPtr lParam, [In] uint dwFlags);

        /// <summary>
        /// <para>
        /// The <see cref="EnumFonts"/> function enumerates the fonts available on a specified device.
        /// For each font with the specified typeface name, the <see cref="EnumFonts"/> function retrieves information about that font
        /// and passes it to the application defined callback function.
        /// This callback function can process the font information as desired.
        /// Enumeration continues until there are no more fonts or the callback function returns zero.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumfontsw"/>
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
        /// <para>
        /// Use <see cref="EnumFontFamiliesEx"/> instead of <see cref="EnumFonts"/>.
        /// The <see cref="EnumFontFamiliesEx"/> function differs from the <see cref="EnumFonts"/> function
        /// in that it retrieves the style names associated with a TrueType font.
        /// With <see cref="EnumFontFamiliesEx"/>, you can retrieve information about font styles
        /// that cannot be enumerated using the <see cref="EnumFonts"/> function.
        /// </para>
        /// <para>
        /// The fonts for many East Asian languages have two typeface names: an English name and a localized name.
        /// <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/>
        /// return the English typeface name if the system locale does not match the language of the font.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            " Applications should use the EnumFontFamiliesEx function.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumFontsW", ExactSpelling = true, SetLastError = true)]
        public static extern int EnumFonts([In] HDC hdc, [In] LPCWSTR lpLogfont, [In] FONTENUMPROC lpProc, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// The <see cref="GetAspectRatioFilterEx"/> function retrieves the setting for the current aspect-ratio filter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getaspectratiofilterex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context.
        /// </param>
        /// <param name="lpsize">
        /// Pointer to a <see cref="SIZE"/> structure that receives the current aspect-ratio filter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The aspect ratio is the ratio formed by the width and height of a pixel on a specified device.
        /// </para>
        /// <para>
        /// The system provides a special filter, the aspect-ratio filter, to select fonts that were designed for a particular device.
        /// An application can specify that the system should only retrieve fonts
        /// matching the specified aspect ratio by calling the <see cref="SetMapperFlags"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAspectRatioFilterEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetAspectRatioFilterEx([In] HDC hdc, [Out] out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetCharABCWidths"/> function retrieves the widths, in logical units,
        /// of consecutive characters in a specified range from the current TrueType font.
        /// This function succeeds only with TrueType fonts.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharabcwidthsw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="wFirst">
        /// The first character in the group of consecutive characters from the current font.
        /// </param>
        /// <param name="wLast">
        /// The last character in the group of consecutive characters from the current font.
        /// </param>
        /// <param name="lpABC">
        /// A pointer to an array of <see cref="ABC"/> structures that receives the character widths, in logical units.
        /// This array must contain at least as many <see cref="ABC"/> structures as there are characters in the range
        /// specified by the <paramref name="wFirst"/> and <paramref name="wLast"/> parameters.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The TrueType rasterizer provides ABC character spacing after a specific point size has been selected.
        /// A spacing is the distance added to the current position before placing the glyph.
        /// B spacing is the width of the black part of the glyph.
        /// C spacing is the distance added to the current position to provide white space to the right of the glyph.
        /// The total advanced width is specified by A+B+C.
        /// </para>
        /// <para>
        /// When the <see cref="GetCharABCWidths"/> function retrieves negative A or C widths for a character, that character includes underhangs or overhangs.
        /// </para>
        /// <para>
        /// To convert the ABC widths to font design units, an application should use the value
        /// stored in the <see cref="OUTLINETEXTMETRIC.otmEMSquare"/> member of a <see cref="OUTLINETEXTMETRIC"/> structure.
        /// This value can be retrieved by calling the <see cref="GetOutlineTextMetrics"/> function.
        /// </para>
        /// <para>
        /// The ABC widths of the default character are used for characters outside the range of the currently selected font.
        /// </para>
        /// <para>
        /// To retrieve the widths of characters in non-TrueType fonts, applications should use the <see cref="GetCharWidth"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCharABCWidthsW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCharABCWidths([In] HDC hdc, [In] UINT wFirst, [In] UINT wLast, [In][Out] ABC[] lpABC);

        /// <summary>
        /// <para>
        /// The <see cref="GetCharABCWidthsFloat"/> function retrieves the widths, in logical units,
        /// of consecutive characters in a specified range from the current font.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharabcwidthsfloatw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <param name="iFirst">
        /// Specifies the code point of the first character in the group of consecutive characters where the ABC widths are seeked.
        /// </param>
        /// <param name="iLast">
        /// Specifies the code point of the last character in the group of consecutive characters where the ABC widths are seeked.
        /// This range is inclusive.
        /// An error is returned if the specified last character precedes the specified first character.
        /// </param>
        /// <param name="lpABC">
        /// Pointer to an array of <see cref="ABCFLOAT"/> structures that receives the character widths, in logical units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Unlike the <see cref="GetCharABCWidths"/> function that returns widths only for TrueType fonts,
        /// the <see cref="GetCharABCWidthsFloat"/> function retrieves widths for any font.
        /// The widths returned by this function are in the IEEE floating-point format.
        /// </para>
        /// <para>
        /// If the current world-to-device transformation is not identified, the returned widths may be noninteger values,
        /// even if the corresponding values in the device space are integers.
        /// </para>
        /// <para>
        /// A spacing is the distance added to the current position before placing the glyph.
        /// B spacing is the width of the black part of the glyph.
        /// C spacing is the distance added to the current position to provide white space to the right of the glyph.
        /// The total advanced width is specified by A+B+C.
        /// </para>
        /// <para>
        /// The ABC spaces are measured along the character base line of the selected font.
        /// </para>
        /// <para>
        /// The ABC widths of the default character are used for characters outside the range of the currently selected font.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCharABCWidthsFloatW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCharABCWidthsFloat([In] HDC hdc, [In] UINT iFirst, [In] UINT iLast, [In][Out] ABCFLOAT[] lpABC);

        /// <summary>
        /// <para>
        /// The <see cref="GetCharABCWidthsI"/> function retrieves the widths, in logical units,
        /// of consecutive glyph indices in a specified range from the current TrueType font.
        /// This function succeeds only with TrueType fonts.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharabcwidthsi"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="giFirst">
        /// The first glyph index in the group of consecutive glyph indices from the current font.
        /// This parameter is only used if the <paramref name="pgi"/> parameter is <see langword="null"/>.
        /// </param>
        /// <param name="cgi">
        /// The number of glyph indices.
        /// </param>
        /// <param name="pgi">
        /// A pointer to an array that contains glyph indices.
        /// If this parameter is <see langword="null"/>, the <paramref name="giFirst"/> parameter is used instead.
        /// The <paramref name="cgi"/> parameter specifies the number of glyph indices in this array.
        /// </param>
        /// <param name="pabc">
        /// A pointer to an array of <see cref="ABC"/> structures that receives the character widths, in logical units.
        /// This array must contain at least as many <see cref="ABC"/> structures
        /// as there are glyph indices specified by the <paramref name="cgi"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The TrueType rasterizer provides ABC character spacing after a specific point size has been selected.
        /// A spacing is the distance added to the current position before placing the glyph.
        /// B spacing is the width of the black part of the glyph.
        /// C spacing is the distance added to the current position to provide white space to the right of the glyph.
        /// The total advanced width is specified by A+B+C.
        /// </para>
        /// <para>
        /// When the <see cref="GetCharABCWidthsI"/> function retrieves negative A or C widths for a character,
        /// that character includes underhangs or overhangs.
        /// </para>
        /// <para>
        /// To convert the ABC widths to font design units, an application should use the value
        /// stored in the <see cref="OUTLINETEXTMETRIC.otmEMSquare"/> member of a <see cref="OUTLINETEXTMETRIC"/> structure.
        /// This value can be retrieved by calling the <see cref="GetOutlineTextMetrics"/> function.
        /// </para>
        /// <para>
        /// The ABC widths of the default character are used for characters outside the range of the currently selected font.
        /// </para>
        /// <para>
        /// To retrieve the widths of glyph indices in non-TrueType fonts, applications should use the <see cref="GetCharWidthI"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCharABCWidthsI", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCharABCWidthsI([In] HDC hdc, [In] UINT giFirst, [In] UINT cgi, [In] WORD[] pgi, [In][Out] ABC[] pabc);

        /// <summary>
        /// <para>
        /// <para>
        /// The <see cref="GetCharacterPlacement"/> function retrieves information about a character string,
        /// such as character widths, caret positioning, ordering within the string, and glyph rendering.
        /// The type of information returned depends on the <paramref name="dwFlags"/> parameter
        /// and is based on the currently selected font in the specified display context.
        /// The function copies the information to the specified <see cref="GCP_RESULTS"/> structure or to one or more arrays specified by the structure.
        /// </para>
        /// <para>
        /// Although this function was once adequate for working with character strings,
        /// a need to work with an increasing number of languages and scripts has rendered it obsolete.
        /// It has been superseded by the functionality of the Uniscribe module.
        /// For more information, see Uniscribe.
        /// </para>
        /// <para>
        /// It is recommended that an application use the <see cref="GetFontLanguageInfo"/> function to determine
        /// whether the <see cref="GCP_DIACRITIC"/>, <see cref="GCP_DBCS"/>, <see cref="GCP_USEKERNING"/>, <see cref="GCP_LIGATE"/>,
        /// <see cref="GCP_REORDER"/>, <see cref="GCP_GLYPHSHAPE"/>, and <see cref="GCP_KASHIDA"/> values are valid for the currently selected font.
        /// If not valid, <see cref="GetCharacterPlacement"/> ignores the value.
        /// </para>
        /// <para>
        /// The <see cref="GCP_NODIACRITICS"/> value is no longer defined and should not be used.
        /// </para>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharacterplacementw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpString">
        /// A pointer to the character string to process.
        /// The string does not need to be zero-terminated, since nCount specifies the length of the string.
        /// </param>
        /// <param name="nCount">
        /// The length of the string pointed to by <paramref name="lpString"/>.
        /// </param>
        /// <param name="nMaxExtent">
        /// The maximum extent (in logical units) to which the string is processed.
        /// Characters that, if processed, would exceed this extent are ignored.
        /// Computations for any required ordering or glyph arrays apply only to the included characters.
        /// This parameter is used only if the <see cref="GCP_MAXEXTENT"/> value is specified in the <paramref name="dwFlags"/> parameter.
        /// As the function processes the input string, each character and its extent is added to the output,
        /// extent, and other arrays only if the total extent has not yet exceeded the maximum.
        /// Once the limit is reached, processing will stop.
        /// </param>
        /// <param name="lpResults">
        /// A pointer to a <see cref="GCP_RESULTS"/> structure that receives the results of the function.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Specifies how to process the string into the required arrays.
        /// This parameter can be one or more of the following values.
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
        /// <see cref="GCP_CLASSIN"/>
        /// </term>
        /// <term>
        /// Specifies that the <see cref="GCP_RESULTS.lpClass"/> array contains preset classifications for characters.
        /// The classifications may be the same as on output.
        /// If the particular classification for a character is not known, the corresponding location in the array must be set to zero.
        /// for more information about the classifications, see <see cref="GCP_RESULTS"/>.
        /// This is useful only if <see cref="GetFontLanguageInfo"/> returned the <see cref="GCP_REORDER"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_DIACRITIC"/>
        /// </term>
        /// <term>
        /// <para>
        /// Determines how diacritics in the string are handled.
        /// If this value is not set, diacritics are treated as zero-width characters.
        /// For example, a Hebrew string may contain diacritics, but you may not want to display them.
        /// </para>
        /// <para>
        /// Use <see cref="GetFontLanguageInfo"/> to determine whether a font supports diacritics.
        /// If it does, you can use or not use the <see cref="GCP_DIACRITIC"/> flag in the call to <see cref="GetCharacterPlacement"/>,
        /// depending on the needs of your application.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_DISPLAYZWG"/>
        /// </term>
        /// <term>
        /// For languages that need reordering or different glyph shapes depending on the positions of the characters within a word,
        /// nondisplayable characters often appear in the code page.
        /// For example, in the Hebrew code page, there are Left-To-Right and Right-To-Left markers,
        /// to help determine the final positioning of characters within the output strings.
        /// Normally these are not displayed and are removed from the <see cref="GCP_RESULTS.lpGlyphs"/> and <see cref="GCP_RESULTS.lpDx"/> arrays.
        /// You can use the <see cref="GCP_DISPLAYZWG"/> flag to display these characters.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_GLYPHSHAPE"/>
        /// </term>
        /// <term>
        /// Specifies that some or all characters in the string are to be displayed using shapes
        /// other than the standard shapes defined in the currently selected font for the current code page.
        /// Some languages, such as Arabic, cannot support glyph creation unless this value is specified.
        /// As a general rule, if <see cref="GetFontLanguageInfo"/> returns this value for a string,
        /// this value must be used with <see cref="GetCharacterPlacement"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_JUSTIFY"/>
        /// </term>
        /// <term>
        /// Adjusts the extents in the <see cref="GCP_RESULTS.lpDx"/> array so that the string length is the same as <paramref name="nMaxExtent"/>.
        /// <see cref="GCP_JUSTIFY"/> may only be used in conjunction with <see cref="GCP_MAXEXTENT"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_KASHIDA"/>
        /// </term>
        /// <term>
        /// <para>
        /// Use Kashidas as well as, or instead of, adjusted extents to modify the length of the string
        /// so that it is equal to the value specified by <paramref name="nMaxExtent"/>.
        /// In the <see cref="GCP_RESULTS.lpDx"/> array, a Kashida is indicated by a negative justification index.
        /// <see cref="GCP_KASHIDA"/> may be used only in conjunction with <see cref="GCP_JUSTIFY"/>
        /// and only if the font (and language) support Kashidas.
        /// Use <see cref="GetFontLanguageInfo"/> to determine whether the current font supports Kashidas.
        /// </para>
        /// <para>
        /// Using Kashidas to justify the string can result in the number of glyphs required
        /// being greater than the number of characters in the input string.
        /// Because of this, when Kashidas are used, the application cannot assume
        /// that setting the arrays to be the size of the input string will be sufficient.
        /// (The maximum possible will be approximately dxPageWidth/dxAveCharWidth,
        /// where dxPageWidth is the width of the document and dxAveCharWidth is the average character width
        /// as returned from a <see cref="GetTextMetrics"/> call).
        /// </para>
        /// <para>
        /// Note that just because <see cref="GetFontLanguageInfo"/> returns the <see cref="GCP_KASHIDA"/> flag
        /// does not mean that it has to be used in the call to <see cref="GetCharacterPlacement"/>, just that the option is available.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_LIGATE"/>
        /// </term>
        /// <term>
        /// <para>
        /// Use ligations wherever characters ligate. A ligation occurs where one glyph is used for two or more characters.
        /// For example, the letters a and e can ligate to ?.
        /// For this to be used, however, both the language support and the font must support the required glyphs
        /// (the example will not be processed by default in English).
        /// </para>
        /// <para>
        /// Use <see cref="GetFontLanguageInfo"/> to determine whether the current font supports ligation.
        /// If it does and a specific maximum is required for the number of characters that will ligate,
        /// set the number in the first element of the <see cref="GCP_RESULTS.lpGlyphs"/> array.
        /// If normal ligation is required, set this value to zero.
        /// If <see cref="GCP_LIGATE"/> is not specified, no ligation will take place.
        /// See <see cref="GCP_RESULTS"/> for more information.
        /// </para>
        /// <para>
        /// If the <see cref="GCP_REORDER"/> value is usually required for the character set but is not specified,
        /// the output will be meaningless unless the string being passed in is already in visual ordering
        /// (that is, the result that gets put into lpGcpResults-&gt;lpOutString
        /// in one call to <see cref="GetCharacterPlacement"/> is the input string of a second call).
        /// </para>
        /// <para>
        /// Note that just because <see cref="GetFontLanguageInfo"/> returns the <see cref="GCP_LIGATE"/> flag
        /// does not mean that it has to be used in the call to <see cref="GetCharacterPlacement"/>, just that the option is available.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_MAXEXTENT"/>
        /// </term>
        /// <term>
        /// Compute extents of the string only as long as the resulting extent, in logical units,
        /// does not exceed the values specified by the <paramref name="nMaxExtent"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_NEUTRALOVERRIDE"/>
        /// </term>
        /// <term>
        /// Certain languages only.
        /// Override the normal handling of neutrals and treat them as strong characters that match the strings reading order.
        /// Useful only with the <see cref="GCP_REORDER"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_NUMERICOVERRIDE"/>
        /// </term>
        /// <term>
        /// Certain languages only.
        /// Override the normal handling of numerics and treat them as strong characters that match the strings reading order.
        /// Useful only with the <see cref="GCP_REORDER"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_NUMERICSLATIN"/>
        /// </term>
        /// <term>
        /// Arabic/Thai only.
        /// Use standard Latin glyphs for numbers and override the system default.
        /// To determine if this option is available in the language of the font,
        /// use <see cref="GetStringTypeEx"/> to see if the language supports more than one number format.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_NUMERICSLOCAL"/>
        /// </term>
        /// <term>
        /// Arabic/Thai only. Use local glyphs for numeric characters and override the system default.
        /// To determine if this option is available in the language of the font,
        /// use <see cref="GetStringTypeEx"/> to see if the language supports more than one number format.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_REORDER"/>
        /// </term>
        /// <term>
        /// <para>
        /// Reorder the string. Use for languages that are not SBCS and left-to-right reading order.
        /// If this value is not specified, the string is assumed to be in display order already.
        /// </para>
        /// <para>
        /// If this flag is set for Semitic languages and the <see cref="GCP_RESULTS.lpClass"/> array is used,
        /// the first two elements of the array are used to specify the reading order beyond the bounds of the string.
        /// <see cref="GCPCLASS_PREBOUNDRTL"/> and <see cref="GCPCLASS_PREBOUNDLTR"/> can be used to set the order.
        /// If no preset order is required, set the values to zero.
        /// These values can be combined with other values if the <see cref="GCP_CLASSIN"/> flag is set.
        /// </para>
        /// <para>
        /// If the GCP_REORDER value is not specified, the <paramref name="lpString"/> parameter is taken to be visual ordered
        /// for languages where this is used, and the <see cref="GCP_RESULTS.lpOutString"/> and <see cref="GCP_RESULTS.lpOrder"/> fields are ignored.
        /// </para>
        /// <para>
        /// Use <see cref="GetFontLanguageInfo"/> to determine whether the current font supports reordering.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_SYMSWAPOFF"/>
        /// </term>
        /// <term>
        /// Semitic languages only. Specifies that swappable characters are not reset.
        /// For example, in a right-to-left string, the '(' and ')' are not reversed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_USEKERNING"/>
        /// </term>
        /// <term>
        /// <para>
        /// Use kerning pairs in the font (if any) when creating the widths arrays.
        /// Use <see cref="GetFontLanguageInfo"/> to determine whether the current font supports kerning pairs.
        /// </para>
        /// <para>
        /// Note that just because <see cref="GetFontLanguageInfo"/> returns the <see cref="GCP_USEKERNING"/> flag
        /// does not mean that it has to be used in the call to <see cref="GetCharacterPlacement"/>, just that the option is available.
        /// Most TrueType fonts have a kerning table, but you do not have to use it.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// It is recommended that an application use the <see cref="GetFontLanguageInfo"/> function to determine
        /// whether the <see cref="GCP_DIACRITIC"/>, <see cref="GCP_DBCS"/>, <see cref="GCP_USEKERNING"/>, <see cref="GCP_LIGATE"/>,
        /// <see cref="GCP_REORDER"/>, <see cref="GCP_GLYPHSHAPE"/>, and <see cref="GCP_KASHIDA"/> values are valid for the currently selected font.
        /// If not valid, <see cref="GetCharacterPlacement"/> ignores the value.
        /// </para>
        /// <para>
        /// The <see cref="GCP_NODIACRITICS"/> value is no longer defined and should not be used.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the width and height of the string in logical units.
        /// The width is the low-order word and the height is the high-order word.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetCharacterPlacement"/> ensures that an application can correctly process text
        /// regardless of the international setting and type of fonts available.
        /// Applications use this function before using the <see cref="ExtTextOut"/> function
        /// and in place of the <see cref="GetTextExtentPoint32"/> function
        /// (and occasionally in place of the <see cref="GetCharWidth32"/> and <see cref="GetCharABCWidths"/> functions).
        /// </para>
        /// <para>
        /// Using <see cref="GetCharacterPlacement"/> to retrieve intercharacter spacing and index arrays
        /// is not always necessary unless justification or kerning is required.
        /// For non-Latin fonts, applications can improve the speed at which the <see cref="ExtTextOut"/> function renders text
        /// by using <see cref="GetCharacterPlacement"/> to retrieve the intercharacter spacing and index arrays before calling <see cref="ExtTextOut"/>.
        /// This is especially useful when rendering the same text repeatedly or when using intercharacter spacing to position the caret.
        /// If the <see cref="GCP_RESULTS.lpGlyphs"/> output array is used in the call to <see cref="ExtTextOut"/>, the <see cref="ETO_GLYPH_INDEX"/> flag must be set.
        /// </para>
        /// <para>
        /// <see cref="GetCharacterPlacement"/> checks the <see cref="GCP_RESULTS.lpOrder"/>, <see cref="GCP_RESULTS.lpDx"/>,
        /// <see cref="GCP_RESULTS.lpCaretPos"/>, <see cref="GCP_RESULTS.lpOutString"/>, and <see cref="GCP_RESULTS.lpGlyphs"/> members
        /// of the <see cref="GCP_RESULTS"/> structure and fills the corresponding arrays if these members are not set to <see cref="NULL"/>.
        /// If <see cref="GetCharacterPlacement"/> cannot fill an array, it sets the corresponding member to <see cref="NULL"/>.
        /// To ensure retrieval of valid information, the application is responsible for setting the member to a valid address
        /// before calling the function and for checking the value of the member after the call.
        /// If the <see cref="GCP_JUSTIFY"/> or <see cref="GCP_USEKERNING"/> values are specified,
        /// the <see cref="GCP_RESULTS.lpDx"/> and/or <see cref="GCP_RESULTS.lpCaretPos"/> members must have valid addresses.
        /// </para>
        /// <para>
        /// Note that the glyph indexes returned in <see cref="GCP_RESULTS.lpGlyphs"/> are specific to the current font in the device context
        /// and should only be used to draw text in the device context while that font remains selected.
        /// </para>
        /// <para>
        /// When computing justification, if the trailing characters in the string are spaces,
        /// the function reduces the length of the string and removes the spaces prior to computing the justification.
        /// If the array consists of only spaces, the function returns an error.
        /// </para>
        /// <para>
        /// <see cref="ExtTextOut"/> expects an <see cref="GCP_RESULTS.lpDx"/> entry for each byte of a DBCS string,
        /// whereas <see cref="GetCharacterPlacement"/> assigns an <see cref="GCP_RESULTS.lpDx"/> entry for each glyph.
        /// To correct this mismatch when using this combination of functions,
        /// either use <see cref="GetGlyphIndices"/> or expand the <see cref="GCP_RESULTS.lpDx"/> array
        /// with zero-width entries for the corresponding second byte of a DBCS byte pair.
        /// </para>
        /// <para>
        /// If the logical width is less than the width of the leading character in the input string,
        /// <see cref="GCP_RESULTS.nMaxFit"/> returns a bad value.
        /// For this case, call <see cref="GetCharacterPlacement"/> for glyph indexes and the <see cref="GCP_RESULTS.lpDx"/> array.
        /// Then use the <see cref="GCP_RESULTS.lpDx"/> array to do the extent calculation using the advance width of each character,
        /// where <see cref="GCP_RESULTS.nMaxFit"/> is the number of characters
        /// whose glyph indexes advance width is less than the width of the leading character.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCharacterPlacementW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetCharacterPlacement([In] HDC hdc, [In] LPCWSTR lpString, [In] int nCount, [In] int nMaxExtent,
            [In][Out] ref GCP_RESULTS lpResults, [In] GetCharacterPlacementFlags dwFlags);

        /// <summary>
        /// <para>
        /// The <see cref="GetCharWidth"/> function retrieves the widths, in logical coordinates,
        /// of consecutive characters in a specified range from the current font.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharwidthw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iFirst">
        /// The first character in the group of consecutive characters.
        /// </param>
        /// <param name="iLast">
        /// The last character in the group of consecutive characters, which must not precede the specified first character.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the character widths, in logical coordinates.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetCharWidth"/> cannot be used on TrueType fonts.
        /// To retrieve character widths for TrueType fonts, use <see cref="GetCharABCWidths"/>.
        /// </para>
        /// <para>
        /// The range is inclusive; that is, the returned widths include the widths of the characters
        /// specified by the <paramref name="iFirst"/> and <paramref name="iLast"/> parameters.
        /// </para>
        /// <para>
        /// If a character does not exist in the current font, it is assigned the width of the default character.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should call the GetCharWidth32 function, which provides more accurate results.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCharWidthW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCharWidth([In] HDC hdc, [In] UINT iFirst, [In] UINT iLast, [Out] out int lpBuffer);

        /// <summary>
        /// <para>
        /// The <see cref="GetCharWidth32"/> function retrieves the widths,
        /// in logical coordinates, of consecutive characters in a specified range from the current font.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharwidth32w"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iFirst">
        /// The first character in the group of consecutive characters.
        /// </param>
        /// <param name="iLast">
        /// The last character in the group of consecutive characters, which must not precede the specified first character.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the character widths, in logical coordinates.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetCharWidth32"/> cannot be used on TrueType fonts.
        /// To retrieve character widths for TrueType fonts, use <see cref="GetCharABCWidths"/>.
        /// </para>
        /// <para>
        /// The range is inclusive; that is, the returned widths include the widths of the characters
        /// specified by the <paramref name="iFirst"/> and <paramref name="iLast"/> parameters.
        /// </para>
        /// <para>
        /// If a character does not exist in the current font, it is assigned the width of the default character.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCharWidth32W", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCharWidth32([In] HDC hdc, [In] UINT iFirst, [In] UINT iLast, [Out] INT[] lpBuffer);

        /// <summary>
        /// <para>
        /// The <see cref="GetCharWidthFloat"/> function retrieves the fractional widths
        /// of consecutive characters in a specified range from the current font.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharwidthfloatw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iFirst">
        /// The code point of the first character in the group of consecutive characters.
        /// </param>
        /// <param name="iLast">
        /// The code point of the last character in the group of consecutive characters.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the character widths, in logical units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The returned widths are in the 32-bit IEEE floating-point format. (The widths are measured along the base line of the characters.)
        /// </para>
        /// <para>
        /// If the <paramref name="iFirst"/> parameter specifies the letter a and the <paramref name="iLast"/> parameter
        /// specifies the letter z, <see cref="GetCharWidthFloat"/> retrieves the widths of all lowercase characters.
        /// </para>
        /// <para>
        /// If a character does not exist in the current font, it is assigned the width of the default character.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCharWidthFloatW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCharWidthFloat([In] HDC hdc, [In] UINT iFirst, [In] UINT iLast, [Out] FLOAT[] lpBuffer);

        /// <summary>
        /// <para>
        /// The <see cref="GetCharWidthI"/> function retrieves the widths, in logical coordinates,
        /// of consecutive glyph indices in a specified range from the current font.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharwidthi"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="giFirst">
        /// The first glyph index in the group of consecutive glyph indices.
        /// </param>
        /// <param name="cgi">
        /// The number of glyph indices.
        /// </param>
        /// <param name="pgi">
        /// A pointer to an array of glyph indices.
        /// If this parameter is not <see langword="null"/>, it is used instead of the <paramref name="giFirst"/> parameter.
        /// </param>
        /// <param name="piWidths">
        /// A pointer to a buffer that receives the widths, in logical coordinates.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="GetCharWidthI"/> function processes a consecutive glyph indices
        /// if the <paramref name="pgi"/> parameter is <see langword="null"/> with the <paramref name="giFirst"/> parameter
        /// indicating the first glyph index to process and the <paramref name="cgi"/> parameter indicating how many glyph indices to process.
        /// Otherwise the <see cref="GetCharWidthI"/> function processes the array of glyph indices
        /// pointed to by the <paramref name="pgi"/> parameter with the <paramref name="cgi"/> parameter indicating how many glyph indices to process.
        /// If a character does not exist in the current font, it is assigned the width of the default character.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCharWidthI", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCharWidthI([In] HDC hdc, [In] UINT giFirst, [In] UINT cgi, [In] WORD[] pgi, [Out] INT[] piWidths);

        /// <summary>
        /// <para>
        /// The <see cref="GetFontData"/> function retrieves font metric data for a TrueType font.
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="dwTable">
        /// The name of a font metric table from which the font data is to be retrieved.
        /// This parameter can identify one of the metric tables documented in the TrueType Font Files specification published by Microsoft Corporation.
        /// If this parameter is zero, the information is retrieved starting at the beginning of the file for TrueType font files or
        /// from the beginning of the data for the currently selected font for TrueType Collection files.
        /// To retrieve the data from the beginning of the file for TrueType Collection files specify 'ttcf' (0x66637474).
        /// </param>
        /// <param name="dwOffset">
        /// The offset from the beginning of the font metric table to the location where the function should begin retrieving information.
        /// If this parameter is zero, the information is retrieved starting at the beginning of the table specified by the <paramref name="dwTable"/> parameter.
        /// If this value is greater than or equal to the size of the table, an error occurs.
        /// </param>
        /// <param name="pvBuffer">
        /// A pointer to a buffer that receives the font information.
        /// If this parameter is <see cref="NULL"/>, the function returns the size of the buffer required for the font data.
        /// </param>
        /// <param name="cjBuffer">
        /// The length, in bytes, of the information to be retrieved.
        /// If this parameter is zero, <see cref="GetFontData"/> returns the size of the data specified in the <paramref name="dwTable"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of bytes returned.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is intended to be used to retrieve TrueType font information directly from the font file by font-manipulation applications.
        /// For information about embedding fonts see the Font Embedding Reference.
        /// </para>
        /// <para>
        /// An application can sometimes use the <see cref="GetFontData"/> function to save a TrueType font with a document.
        /// To do this, the application determines whether the font can be embedded
        /// by checking the <see cref="OUTLINETEXTMETRIC.otmfsType"/> member of the <see cref="OUTLINETEXTMETRIC"/> structure.
        /// If bit 1 of <see cref="OUTLINETEXTMETRIC.otmfsType"/> is set, embedding is not permitted for the font.
        /// If bit 1 is clear, the font can be embedded. If bit 2 is set, the embedding is read-only.
        /// If embedding is permitted, the application can retrieve the entire font file,
        /// specifying zero for the <paramref name="dwTable"/>, <paramref name="dwOffset"/>, and <paramref name="cjBuffer"/> parameters.
        /// </para>
        /// <para>
        /// If an application attempts to use this function to retrieve information for a non-TrueType font, an error occurs.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFontData", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetFontData([In] HDC hdc, [In] DWORD dwTable, [In] DWORD dwOffset, [In] PVOID pvBuffer, [In] DWORD cjBuffer);

        /// <summary>
        /// <para>
        /// The <see cref="GetFontLanguageInfo"/> function returns information
        /// about the currently selected font for the specified display context.
        /// Applications typically use this information and the <see cref="GetCharacterPlacement"/> function to prepare a character string for display.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getfontlanguageinfo"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">Handle to a display device context.</param>
        /// <returns>
        /// <para>
        /// The return value identifies characteristics of the currently selected font.
        /// The function returns 0 if the font is "normalized" and can be treated as a simple Latin font;
        /// it returns <see cref="GCP_ERROR"/> if an error occurs.
        /// Otherwise, the function returns a combination of the following values.
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
        /// <see cref="GCP_DBCS"/>
        /// </term>
        /// <term>
        /// The character set is DBCS.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_DIACRITIC"/>
        /// </term>
        /// <term>
        /// The font/language contains diacritic glyphs.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FLI_GLYPHS"/>
        /// </term>
        /// <term>
        /// The font contains extra glyphs not normally accessible using the code page.
        /// Use <see cref="GetCharacterPlacement"/> to access the glyphs.
        /// This value is for information only and is not intended to be passed to <see cref="GetCharacterPlacement"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_GLYPHSHAPE"/>
        /// </term>
        /// <term>
        /// The font/language contains multiple glyphs per code point or per code point combination (supports shaping and/or ligation),
        /// and the font contains advanced glyph tables to provide extra glyphs for the extra shapes.
        /// If this value is specified, the lpGlyphs array must be used with the <see cref="GetCharacterPlacement"/> function
        /// and the <see cref="ETO_GLYPHINDEX"/> value must be passed to the <see cref="ExtTextOut"/> function when the string is drawn.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_KASHIDA"/>
        /// </term>
        /// <term>
        /// The font/ language permits Kashidas.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_LIGATE"/>
        /// </term>
        /// <term>
        /// The font/language contains ligation glyphs which can be substituted for specific character combinations.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_USEKERNING"/>
        /// </term>
        /// <term>
        /// The font contains a kerning table which can be used to provide better spacing between the characters and glyphs.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GCP_REORDER"/>
        /// </term>
        /// <term>
        /// The language requires reordering for display for example, Hebrew or Arabic.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The return value, when masked with <see cref="FLI_MASK"/>,
        /// can be passed directly to the <see cref="GetCharacterPlacement"/> function.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFontLanguageInfo", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetFontLanguageInfo([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetFontUnicodeRanges"/> function returns information about which Unicode characters are supported by a font.
        /// The information is returned as a <see cref="GLYPHSET"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getfontunicoderanges"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpgs">
        /// A pointer to a <see cref="GLYPHSET"/> structure that receives the glyph set information.
        /// If this parameter is <see cref="NullRef{GLYPHSET}"/>,
        /// the function returns the size of the <see cref="GLYPHSET"/> structure required to store the information.
        /// </param>
        /// <returns>
        /// <para>
        ///  the function succeeds, it returns number of bytes written to the <see cref="GLYPHSET"/> structure or,
        ///  if the <paramref name="lpgs"/> parameter is <see cref="NULL"/>,
        ///  it returns the size of the <see cref="GLYPHSET"/> structure required to store the information.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero. No extended error information is available.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFontUnicodeRanges", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetFontUnicodeRanges([In] HDC hdc, [Out] out GLYPHSET lpgs);

        /// <summary>
        /// <para>
        /// The <see cref="GetGlyphIndices"/> function translates a string into an array of glyph indices.
        /// The function can be used to determine whether a glyph exists in a font.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getglyphindicesw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpstr">
        /// A pointer to the string to be converted.
        /// </param>
        /// <param name="c">
        /// The length of both the length of the string pointed to by <paramref name="lpstr"/>
        /// and the size (in WORDs) of the buffer pointed to by <paramref name="pgi"/>.
        /// </param>
        /// <param name="pgi">
        /// This buffer must be of dimension <paramref name="c"/>.
        /// On successful return, contains an array of glyph indices corresponding to the characters in the string.
        /// </param>
        /// <param name="fl">
        /// <para>
        /// Specifies how glyphs should be handled if they are not supported.
        /// This parameter can be the following value.
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
        /// <see cref="GGI_MARK_NONEXISTING_GLYPHS"/>
        /// </term>
        /// <term>
        /// Marks unsupported glyphs with the hexadecimal value 0xffff.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns the number of bytes (for the ANSI function)
        /// or <see cref="WORD"/>s (for the Unicode function) converted.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function attempts to identify a single-glyph representation
        /// for each character in the string pointed to by <paramref name="lpstr"/>.
        /// While this is useful for certain low-level purposes (such as manipulating font files),
        /// higher-level applications that wish to map a string to glyphs will typically wish to use the Uniscribe functions.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetGlyphIndicesW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetGlyphIndices([In] HDC hdc, [In] LPCWSTR lpstr, [In] int c, [Out] WORD[] pgi, [In] DWORD fl);

        /// <summary>
        /// <para>
        /// The <see cref="GetGlyphOutline"/> function retrieves the outline or bitmap for a character in the TrueType font
        /// that is selected into the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getglyphoutlinew"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="uChar">
        /// The character for which data is to be returned.
        /// </param>
        /// <param name="fuFormat">
        /// <para>
        /// The format of the data that the function retrieves. This parameter can be one of the following values.
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
        /// <see cref="GGO_BEZIER"/>
        /// </term>
        /// <term>
        /// The function retrieves the curve data as a cubic Bézier spline (not in quadratic spline format).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GGO_BITMAP"/>
        /// </term>
        /// <term>
        /// The function retrieves the glyph bitmap.
        /// For information about memory allocation, see the following Remarks section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GGO_GLYPH_INDEX"/>
        /// </term>
        /// <term>
        /// Indicates that the <paramref name="uChar"/> parameter is a TrueType Glyph Index rather than a character code.
        /// See the <see cref="ExtTextOut"/> function for additional remarks on Glyph Indexing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GGO_GRAY2_BITMAP"/>
        /// </term>
        /// <term>
        /// The function retrieves a glyph bitmap that contains five levels of gray.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GGO_GRAY4_BITMAP"/>
        /// </term>
        /// <term>
        /// The function retrieves a glyph bitmap that contains 17 levels of gray.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GGO_GRAY8_BITMAP"/>
        /// </term>
        /// <term>
        /// The function retrieves a glyph bitmap that contains 65 levels of gray.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GGO_METRICS"/>
        /// </term>
        /// <term>
        /// The function only retrieves the <see cref="GLYPHMETRICS"/> structure specified by <paramref name="lpgm"/>.
        /// The <paramref name="pvBuffer"/> is ignored.
        /// This value affects the meaning of the function's return value upon failure; see the Return Values section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GGO_NATIVE"/>
        /// </term>
        /// <term>
        /// The function retrieves the curve data points in the rasterizer's native format and uses the font's design units.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GGO_UNHINTED"/>
        /// </term>
        /// <term>
        /// The function only returns unhinted outlines.
        /// This flag only works in conjunction with <see cref="GGO_BEZIER"/> and <see cref="GGO_NATIVE"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Note that, for the GGO_GRAYn_BITMAP values, the function retrieves a glyph bitmap
        /// that contains n^2+1 (n squared plus one) levels of gray.
        /// </para>
        /// </param>
        /// <param name="lpgm">
        /// A pointer to the <see cref="GLYPHMETRICS"/> structure describing the placement of the glyph in the character cell.
        /// </param>
        /// <param name="cjBuffer">
        /// The size, in bytes, of the buffer (*<paramref name="pvBuffer"/>)
        /// where the function is to copy information about the outline character.
        /// If this value is zero, the function returns the required size of the buffer.
        /// </param>
        /// <param name="pvBuffer">
        /// A pointer to the buffer that receives information about the outline character.
        /// If this value is <see cref="NULL"/>, the function returns the required size of the buffer.
        /// </param>
        /// <param name="lpmat2">
        /// A pointer to a <see cref="MAT2"/> structure specifying a transformation matrix for the character.
        /// </param>
        /// <returns>
        /// <para>
        /// If <see cref="GGO_BITMAP"/>, <see cref="GGO_GRAY2_BITMAP"/>, <see cref="GGO_GRAY4_BITMAP"/>, <see cref="GGO_GRAY8_BITMAP"/>,
        /// or <see cref="GGO_NATIVE"/> is specified and the function succeeds, the return value is greater than zero;
        /// otherwise, the return value is <see cref="GDI_ERROR"/>.
        /// If one of these flags is specified and the buffer size or address is zero,
        /// the return value specifies the required buffer size, in bytes.
        /// </para>
        /// <para>
        /// If <see cref="GGO_METRICS"/> is specified and the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The glyph outline returned by the <see cref="GetGlyphOutline"/> function is for a grid-fitted glyph.
        /// (A grid-fitted glyph is a glyph that has been modified so that its bitmapped image
        /// conforms as closely as possible to the original design of the glyph.)
        /// If an application needs an unmodified glyph outline,
        /// it can request the glyph outline for a character in a font whose size is equal to the font's em unit.
        /// The value for a font's em unit is stored in the <see cref="OUTLINETEXTMETRIC.otmEMSquare"/> member
        /// of the <see cref="OUTLINETEXTMETRIC"/> structure.
        /// </para>
        /// <para>
        /// The glyph bitmap returned by <see cref="GetGlyphOutline"/>
        /// when <see cref="GGO_BITMAP"/> is specified is a <see cref="DWORD"/>-aligned, row-oriented, monochrome bitmap.
        /// When <see cref="GGO_GRAY2_BITMAP"/> is specified, the bitmap returned is a <see cref="DWORD"/>-aligned,
        /// row-oriented array of bytes whose values range from 0 to 4.
        /// When <see cref="GGO_GRAY4_BITMAP"/> is specified, the bitmap returned is a <see cref="DWORD"/>-aligned,
        /// row-oriented array of bytes whose values range from 0 to 16.
        /// When <see cref="GGO_GRAY8_BITMAP"/> is specified, the bitmap returned is a <see cref="DWORD"/>-aligned,
        /// row-oriented array of bytes whose values range from 0 to 64.
        /// </para>
        /// <para>
        /// The native buffer returned by <see cref="GetGlyphOutline"/> when <see cref="GGO_NATIVE"/> is specified is a glyph outline.
        /// A glyph outline is returned as a series of one or more contours
        /// defined by a <see cref="TTPOLYGONHEADER"/> structure followed by one or more curves.
        /// Each curve in the contour is defined by a <see cref="TTPOLYCURVE"/> structure
        /// followed by a number of <see cref="POINTFX"/> data points.
        /// <see cref="POINTFX"/> points are absolute positions, not relative moves.
        /// The starting point of a contour is given by the <see cref="TTPOLYGONHEADER.pfxStart"/> member
        /// of the <see cref="TTPOLYGONHEADER"/> structure.
        /// The starting point of each curve is the last point of the previous curve or the starting point of the contour.
        /// The count of data points in a curve is stored
        /// in the <see cref="TTPOLYCURVE.cpfx"/> member of <see cref="TTPOLYCURVE"/> structure.
        /// The size of each contour in the buffer, in bytes,
        /// is stored in the <see cref="TTPOLYGONHEADER.cb"/> member of <see cref="TTPOLYGONHEADER"/> structure.
        /// Additional curve definitions are packed into the buffer following preceding curves and additional contour
        /// s are packed into the buffer following preceding contours.
        /// The buffer contains as many contours as fit within the buffer returned by <see cref="GetGlyphOutline"/>.
        /// </para>
        /// <para>
        /// The <see cref="GLYPHMETRICS"/> structure specifies the width of the character cell and the location of a glyph within the character cell.
        /// The origin of the character cell is located at the left side of the cell at the baseline of the font.
        /// The location of the glyph origin is relative to the character cell origin.
        /// The height of a character cell, the baseline, and other metrics global to the font
        /// are given by the <see cref="OUTLINETEXTMETRIC"/> structure.
        /// </para>
        /// <para>
        /// An application can alter the characters retrieved in bitmap or native format
        /// by specifying a 2-by-2 transformation matrix in the <paramref name="lpmat2"/> parameter.
        /// For example the glyph can be modified by shear, rotation, scaling, or any combination of the three using matrix multiplication.
        /// </para>
        /// <para>
        /// Additional information on a glyph outlines is located in the TrueType and the OpenType technical specifications.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetGlyphOutlineW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetGlyphOutline([In] HDC hdc, [In] UINT uChar, [In] GetGlyphOutlineFormats fuFormat,
            [Out] out GLYPHMETRICS lpgm, [In] DWORD cjBuffer, [In] LPVOID pvBuffer, [In] in MAT2 lpmat2);

        /// <summary>
        /// <para>
        /// The <see cref="GetKerningPairs"/> function retrieves the character-kerning pairs
        /// for the currently selected font for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getkerningpairsw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="nPairs">
        /// The number of pairs in the <paramref name="lpKernPair"/> array.
        /// If the font has more than <paramref name="nPairs"/> kerning pairs, the function returns an error.
        /// </param>
        /// <param name="lpKernPair">
        /// A pointer to an array of <see cref="KERNINGPAIR"/> structures that receives the kerning pairs.
        /// The array must contain at least as many structures as specified by the <paramref name="nPairs"/> parameter.
        /// If this parameter is <see langword="null"/>, the function returns the total number of kerning pairs for the font.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of kerning pairs returned.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKerningPairsW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetKerningPairs([In] HDC hdc, [In] DWORD nPairs, [In][Out] KERNINGPAIR[] lpKernPair);

        /// <summary>
        /// <para>
        /// The <see cref="GetOutlineTextMetrics"/> function retrieves text metrics for TrueType fonts.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getoutlinetextmetricsw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="cjCopy">
        /// The size, in bytes, of the array that receives the text metrics.
        /// </param>
        /// <param name="potm">
        /// A pointer to an <see cref="OUTLINETEXTMETRIC"/> structure.
        /// If this parameter is <see cref="NullRef{OUTLINETEXTMETRIC}"/>,
        /// the function returns the size of the buffer required for the retrieved metric data.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero or the size of the required buffer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="OUTLINETEXTMETRIC"/> structure contains most of the text metric information provided for TrueType fonts
        /// (including a <see cref="TEXTMETRIC"/> structure).
        /// The sizes returned in <see cref="OUTLINETEXTMETRIC"/> are in logical units; they depend on the current mapping mode.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetOutlineTextMetricsW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetOutlineTextMetrics([In] HDC hdc, [In] UINT cjCopy, [Out] out OUTLINETEXTMETRIC potm);

        /// <summary>
        /// <para>
        /// The <see cref="GetRasterizerCaps"/> function returns flags indicating whether TrueType fonts are installed in the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrasterizercaps"/>
        /// </para>
        /// </summary>
        /// <param name="lpraststat">
        /// A pointer to a <see cref="RASTERIZER_STATUS"/> structure that receives information about the rasterizer.
        /// </param>
        /// <param name="cjBytes">
        /// The number of bytes to be copied into the structure pointed to by the <paramref name="lpraststat"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetRasterizerCaps"/> function enables applications and printer drivers
        /// to determine whether TrueType fonts are installed.
        /// </para>
        /// <para>
        /// If the <see cref="TT_AVAILABLE"/> flag is set in the <see cref="RASTERIZER_STATUS.wFlags"/> member
        /// of the <see cref="RASTERIZER_STATUS"/> structure, at least one TrueType font is installed.
        /// If the <see cref="TT_ENABLED"/> flag is set, TrueType is enabled for the system.
        /// </para>
        /// <para>
        /// The actual number of bytes copied is either the member specified
        /// in the <paramref name="cjBytes"/> parameter or the length of the <see cref="RASTERIZER_STATUS"/> structure, whichever is less.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetRasterizerCaps", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetRasterizerCaps([Out] out RASTERIZER_STATUS lpraststat, [In] UINT cjBytes);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextFace"/> function retrieves the typeface name of the font that is selected into the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextfacew"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="c">
        /// The length of the buffer pointed to by <paramref name="lpName"/>.
        /// For the ANSI function it is a <see cref="BYTE"/> count and for the Unicode function it is a <see cref="WORD"/> count.
        /// Note that for the ANSI function, characters in SBCS code pages take one byte each,
        /// while most characters in DBCS code pages take two bytes;
        /// for the Unicode function, most currently defined Unicode characters (those in the Basic Multilingual Plane (BMP)) are
        /// one <see cref="WORD"/> while Unicode surrogates are two <see cref="WORD"/>s.
        /// </param>
        /// <param name="lpName">
        /// A pointer to the buffer that receives the typeface name.
        /// If this parameter is <see cref="NULL"/>, the function returns the number of characters in the name,
        /// including the terminating null character.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of characters copied to the buffer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The typeface name is copied as a null-terminated character string.
        /// </para>
        /// <para>
        /// If the name is longer than the number of characters specified by the <paramref name="c"/> parameter, the name is truncated.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextFaceW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetTextFace([In] HDC hdc, [In] int c, [In] LPWSTR lpName);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextMetrics"/> function fills the specified buffer with the metrics for the currently selected font.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextmetrics"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lptm">
        /// A pointer to the <see cref="TEXTMETRIC"/> structure that receives the text metrics.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// To determine whether a font is a TrueType font, first select it into a DC, then call <see cref="GetTextMetrics"/>,
        /// and then check for <see cref="TMPF_TRUETYPE"/> in <see cref="TEXTMETRIC.tmPitchAndFamily"/>.
        /// Note that <see cref="GetDC"/> returns an uninitialized DC, which has "System" (a bitmap font) as the default font;
        /// thus the need to select a font into the DC.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextMetricsW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTextMetrics([In] HDC hdc, [Out] out TEXTMETRIC lptm);

        /// <summary>
        /// <para>
        /// The <see cref="RemoveFontMemResourceEx"/> function removes the fonts added from a memory image file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-removefontmemresourceex"/>
        /// </para>
        /// </summary>
        /// <param name="h">
        /// A handle to the font-resource.
        /// This handle is returned by the <see cref="AddFontMemResourceEx"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// No extended error information is available.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function removes a font that was added by the <see cref="AddFontMemResourceEx"/> function.
        /// To remove the font, specify the same path and flags as were used in <see cref="AddFontMemResourceEx"/>.
        /// This function will only remove the font that is specified by <paramref name="h"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemoveFontMemResourceEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RemoveFontMemResourceEx([In] HANDLE h);

        /// <summary>
        /// <para>
        /// The <see cref="RemoveFontResource"/> function removes the fonts in the specified file from the system font table.
        /// </para>
        /// <para>
        /// If the font was added using the <see cref="AddFontResourceEx"/> function,
        /// you must use the <see cref="RemoveFontResourceEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-removefontresourcew"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// A pointer to a null-terminated string that names a font resource file.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// We recommend that if an app adds or removes fonts from the system font table
        /// that it notify other windows of the change by sending a <see cref="WM_FONTCHANGE"/> message to all top-level windows in the system.
        /// The app sends this message by calling the <see cref="SendMessage"/> function with the hwnd parameter set to <see cref="HWND_BROADCAST"/>.
        /// </para>
        /// <para>
        /// If there are outstanding references to a font, the associated resource remains loaded until no device context is using it.
        /// Furthermore, if the font is listed in the font registry (HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts)
        /// and is installed to any location other than the %windir%\fonts\ folder, it may be loaded into other active sessions (including session 0).
        /// </para>
        /// <para>
        /// When you try to replace an existing font file that contains a font with outstanding references to it,
        /// you might get an error that indicates that the original font can't be deleted
        /// because it’s in use even after you call <see cref="RemoveFontResource"/>.
        /// If your app requires that the font file be replaced, to reduce the resource count of the original font to zero,
        /// call <see cref="RemoveFontResource"/> in a loop as shown in this example code.
        /// If you continue to get errors, this is an indication that the font file remains loaded in other sessions.
        /// Make sure the font isn't listed in the font registry and restart the system to ensure the font is unloaded from all sessions.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Apps where the original font file is in use will still be able to access the original file
        /// and won't use the new font until the font reloads.
        /// Call <see cref="AddFontResource"/> to reload the font.
        /// We recommend that you call <see cref="AddFontResource"/> the same number of times
        /// as the call to <see cref="RemoveFontResource"/> succeeded as shown in this example code.
        /// </para>
        /// <code>
        /// int i = 0;
        /// while( RemoveFontResource( FontFile ) )
        /// {
        ///     i++;
        /// }
        /// 
        /// // TODO: Replace font file
        /// 
        /// while( i-- )
        /// {
        ///     AddFontResource( FontFile );
        /// }
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemoveFontResourceW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RemoveFontResource([In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// The <see cref="RemoveFontResourceEx"/> function removes the fonts in the specified file from the system font table.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-removefontresourceexw"/>
        /// </para>
        /// </summary>
        /// <param name="name">
        /// A pointer to a null-terminated string that names a font resource file.
        /// </param>
        /// <param name="fl">
        /// The characteristics of the font to be removed from the system.
        /// In order for the font to be removed, the flags used must be the same
        /// as when the font was added with the <see cref="AddFontResourceEx"/> function.
        /// See the <see cref="AddFontResourceEx"/> function for more information.
        /// </param>
        /// <param name="pdv">
        /// Reserved. Must be zero.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// No extended error information is available.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function will only remove the font if the flags specified are the same
        /// as when then font was added with the <see cref="AddFontResourceEx"/> function.
        /// </para>
        /// <para>
        /// When you try to replace an existing font file that contains a font with outstanding references to it,
        /// you might get an error that indicates that the original font can't be deleted
        /// because it’s in use even after you call <see cref="RemoveFontResourceEx"/>.
        /// If your app requires that the font file be replaced, to reduce the resource count of the original font to zero,
        /// call <see cref="RemoveFontResourceEx"/> in a loop as shown in this example code.
        /// If you continue to get errors, this is an indication that the font file remains loaded in other sessions.
        /// Make sure the font isn't listed in the font registry and restart the system to ensure the font is unloaded from all sessions.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Apps where the original font file is in use will still be able to access the original file
        /// and won't use the new font until the font reloads.
        /// Call <see cref="AddFontResourceEx"/> to reload the font.
        /// We recommend that you call <see cref="AddFontResourceEx"/> the same number of times
        /// as the call to <see cref="RemoveFontResourceEx"/> succeeded as shown in this example code.
        /// </para>
        /// <code>
        /// int i = 0;
        /// while( RemoveFontResourceEx( FontFile, FR_PRIVATE, 0 ) )
        /// {
        ///     i++;
        /// }
        /// 
        /// // TODO: Replace font file
        /// 
        /// while( i-- )
        /// {
        ///     AddFontResourceEx( FontFile, FR_PRIVATE, 0 );
        /// }
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemoveFontResourceExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RemoveFontResourceEx([In] LPCWSTR name, [In] DWORD fl, [In] PVOID pdv);

        /// <summary>
        /// <para>
        /// The <see cref="SetMapperFlags"/> function alters the algorithm the font mapper uses when it maps logical fonts to physical fonts.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setmapperflags"/>
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
        /// <para>
        /// If the function succeeds, the return value is the previous value of the font-mapper flag.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <paramref name="flags"/> parameter is set and no matching fonts exist,
        /// Windows chooses a new aspect ratio and retrieves a font that matches this ratio.
        /// </para>
        /// <para>
        /// The remaining bits of the <paramref name="flags"/> parameter must be zero.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMapperFlags", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SetMapperFlags([In] HDC hdc, [In] DWORD flags);
    }
}
