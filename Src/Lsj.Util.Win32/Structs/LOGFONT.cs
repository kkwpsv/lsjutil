using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.CharacterSets;
using static Lsj.Util.Win32.Enums.ClipPrecisions;
using static Lsj.Util.Win32.Enums.FamilyFont;
using static Lsj.Util.Win32.Enums.FontQualities;
using static Lsj.Util.Win32.Enums.FontWeights;
using static Lsj.Util.Win32.Enums.GraphicsModes;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.OutPrecisions;
using static Lsj.Util.Win32.Enums.PitchFont;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="LOGFONT"/> structure defines the attributes of a font.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-logfontw
    /// </para>
    /// </summary>
    /// <remarks>
    /// The following situations do not support ClearType antialiasing:
    /// Text is rendered on a printer.
    /// Display set for 256 colors or less.
    /// Text is rendered to a terminal server client.
    /// The font is not a TrueType font or an OpenType font with TrueType outlines.
    /// For example, the following do not support ClearType antialiasing: Type 1 fonts, Postscript OpenType fonts without TrueType outlines,
    /// bitmap fonts, vector fonts, and device fonts.
    /// The font has tuned embedded bitmaps, for any font sizes that contain the embedded bitmaps.
    /// For example, this occurs commonly in East Asian fonts.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOGFONT
    {
        /// <summary>
        /// LF_FACESIZE
        /// </summary>
        public const int LF_FACESIZE = 32;

        /// <summary>
        /// The height, in logical units, of the font's character cell or character.
        /// The character height value (also known as the em height) is the character cell height value minus the internal-leading value.
        /// The font mapper interprets the value specified in <see cref="lfHeight"/> in the following manner.
        /// &lt; 0：
        /// The font mapper transforms this value into device units and matches it against the cell height of the available fonts.
        /// 0：
        /// The font mapper uses a default height value when it searches for a match.
        /// &gt; 0：
        /// The font mapper transforms this value into device units and matches its absolute value against the character height of the available fonts.
        /// For all height comparisons, the font mapper looks for the largest font that does not exceed the requested size.
        /// This mapping occurs when the font is used for the first time.
        /// For the <see cref="MM_TEXT"/> mapping mode, you can use the following formula to specify a height for a font with a specified point size:
        /// <code>lfHeight = -MulDiv(PointSize, GetDeviceCaps(hDC, LOGPIXELSY), 72);</code>
        /// </summary>
        public LONG lfHeight;

        /// <summary>
        /// <para>
        /// The average width, in logical units, of characters in the font.
        /// If <see cref="lfWidth"/> is zero, the aspect ratio of the device is matched against the digitization aspect ratio
        /// of the available fonts to find the closest match, determined by the absolute value of the difference.
        /// </para>
        /// </summary>
        public LONG lfWidth;

        /// <summary>
        /// The angle, in tenths of degrees, between the escapement vector and the x-axis of the device.
        /// The escapement vector is parallel to the base line of a row of text.
        /// When the graphics mode is set to <see cref="GM_ADVANCED"/>, you can specify the escapement angle of the string
        /// independently of the orientation angle of the string's characters.
        /// When the graphics mode is set to <see cref="GM_COMPATIBLE"/>, lfEscapement specifies both the escapement and orientation.
        /// You should set <see cref="lfEscapement"/> and <see cref="lfOrientation"/> to the same value.
        /// </summary>
        public LONG lfEscapement;

        /// <summary>
        /// The angle, in tenths of degrees, between each character's base line and the x-axis of the device.
        /// </summary>
        public LONG lfOrientation;

        /// <summary>
        /// The weight of the font in the range 0 through 1000. For example, 400 is normal and 700 is bold.
        /// If this value is zero, a default weight is used.
        /// The following values are defined for convenience.
        /// <see cref="FW_DONTCARE"/>: 0
        /// <see cref="FW_THIN"/>: 100
        /// <see cref="FW_EXTRALIGHT"/>: 200
        /// <see cref="FW_ULTRALIGHT"/>: 200
        /// <see cref="FW_LIGHT"/>: 300
        /// <see cref="FW_NORMAL"/>: 400
        /// <see cref="FW_REGULAR"/>: 400
        /// <see cref="FW_MEDIUM"/>: 500
        /// <see cref="FW_SEMIBOLD"/>: 600
        /// <see cref="FW_DEMIBOLD"/>: 600
        /// <see cref="FW_BOLD"/>: 700
        /// <see cref="FW_EXTRABOLD"/>: 800
        /// <see cref="FW_ULTRABOLD"/>: 800
        /// <see cref="FW_HEAVY"/>: 900
        /// <see cref="FW_BLACK"/>: 900
        /// </summary>
        public int lfWeight;

        /// <summary>
        /// An italic font if set to <see langword="true"/>.
        /// </summary>
        public BYTE lfItalic;

        /// <summary>
        /// An underlined font if set to <see langword="true"/>.
        /// </summary>
        public BYTE lfUnderline;

        /// <summary>
        /// A strikeout font if set to <see langword="true"/>.
        /// </summary>
        public BYTE lfStrikeOut;

        /// <summary>
        /// The character set. The following values are predefined.
        /// <see cref="ANSI_CHARSET"/>
        /// <see cref="BALTIC_CHARSET"/>
        /// <see cref="CHINESEBIG5_CHARSET"/>
        /// <see cref="DEFAULT_CHARSET"/>
        /// <see cref="EASTEUROPE_CHARSET"/>
        /// <see cref="GB2312_CHARSET"/>
        /// <see cref="GREEK_CHARSET"/>
        /// <see cref="HANGUL_CHARSET"/>
        /// <see cref="MAC_CHARSET"/>
        /// <see cref="OEM_CHARSET"/>
        /// <see cref="RUSSIAN_CHARSET"/>
        /// <see cref="SHIFTJIS_CHARSET"/>
        /// <see cref="SYMBOL_CHARSET"/>
        /// <see cref="TURKISH_CHARSET"/>
        /// <see cref="VIETNAMESE_CHARSET"/>
        /// Korean language edition of Windows:
        /// <see cref="JOHAB_CHARSET"/>
        /// Middle East language edition of Windows:
        /// <see cref="ARABIC_CHARSET"/>
        /// <see cref="HEBREW_CHARSET"/>
        /// Thai language edition of Windows:
        /// <see cref="THAI_CHARSET"/>
        /// The <see cref="OEM_CHARSET"/> value specifies a character set that is operating-system dependent.
        /// <see cref="DEFAULT_CHARSET"/> is set to a value based on the current system locale.
        /// For example, when the system locale is English (United States), it is set as <see cref="ANSI_CHARSET"/>.
        /// Fonts with other character sets may exist in the operating system.
        /// If an application uses a font with an unknown character set,
        /// it should not attempt to translate or interpret strings that are rendered with that font.
        /// This parameter is important in the font mapping process.
        /// To ensure consistent results, specify a specific character set.
        /// If you specify a typeface name in the <see cref="lfFaceName"/> member,
        /// make sure that the <see cref="lfCharSet"/> value matches the character set of the typeface specified in <see cref="lfFaceName"/>.
        /// </summary>
        public CharacterSets lfCharSet;

        /// <summary>
        /// The output precision.
        /// The output precision defines how closely the output must match the requested font's height, width,
        /// character orientation, escapement, pitch, and font type.
        /// It can be one of the following values.
        /// <see cref="OUT_CHARACTER_PRECIS"/>:
        /// Not used.
        /// <see cref="OUT_DEFAULT_PRECIS"/>:
        /// Specifies the default font mapper behavior.
        /// <see cref="OUT_DEVICE_PRECIS"/>
        /// Instructs the font mapper to choose a Device font when the system contains multiple fonts with the same name.
        /// <see cref="OUT_OUTLINE_PRECIS"/>
        /// This value instructs the font mapper to choose from TrueType and other outline-based fonts.
        /// <see cref="OUT_PS_ONLY_PRECIS"/>
        /// Instructs the font mapper to choose from only PostScript fonts.If there are no PostScript fonts installed in the system,
        /// the font mapper returns to default behavior.
        /// <see cref="OUT_RASTER_PRECIS"/>
        /// Instructs the font mapper to choose a raster font when the system contains multiple fonts with the same name.
        /// <see cref="OUT_STRING_PRECIS"/>
        /// This value is not used by the font mapper, but it is returned when raster fonts are enumerated.
        /// <see cref="OUT_STROKE_PRECIS"/>
        /// This value is not used by the font mapper, but it is returned when TrueType, other outline-based fonts, and vector fonts are enumerated.
        /// <see cref="OUT_TT_ONLY_PRECIS"/>
        /// Instructs the font mapper to choose from only TrueType fonts.
        /// If there are no TrueType fonts installed in the system, the font mapper returns to default behavior.
        /// <see cref="OUT_TT_PRECIS"/>
        /// Instructs the font mapper to choose a TrueType font when the system contains multiple fonts with the same name.
        /// Applications can use the <see cref="OUT_DEVICE_PRECIS"/>, <see cref="OUT_RASTER_PRECIS"/>, <see cref="OUT_TT_PRECIS"/>,
        /// and <see cref="OUT_PS_ONLY_PRECIS"/> values to control how the font mapper chooses a font 
        /// when the operating system contains more than one font with a specified name.
        /// For example, if an operating system contains a font named Symbol in raster and TrueType form,
        /// specifying <see cref="OUT_TT_PRECIS"/> forces the font mapper to choose the TrueType version.
        /// Specifying <see cref="OUT_TT_ONLY_PRECIS"/> forces the font mapper to choose a TrueType font,
        /// even if it must substitute a TrueType font of another name.
        /// </summary>
        public OutPrecisions lfOutPrecision;

        /// <summary>
        /// The clipping precision.
        /// The clipping precision defines how to clip characters that are partially outside the clipping region.
        /// It can be one or more of the following values.
        /// For more information about the orientation of coordinate systems, see the description of the nOrientation parameter.
        /// <see cref="CLIP_CHARACTER_PRECIS"/>
        /// Not used.
        /// <see cref="CLIP_DEFAULT_PRECIS"/>
        /// Specifies default clipping behavior.
        /// <see cref="CLIP_DFA_DISABLE"/>
        /// Windows XP SP1: Turns off font association for the font.
        /// Note that this flag is not guaranteed to have any effect on any platform after Windows Server 2003.
        /// <see cref="CLIP_EMBEDDED"/>
        /// You must specify this flag to use an embedded read-only font.
        /// <see cref="CLIP_LH_ANGLES"/>
        /// When this value is used, the rotation for all fonts depends on whether the orientation of the coordinate system
        /// is left-handed or right-handed.If not used, device fonts always rotate counterclockwise,
        /// but the rotation of other fonts is dependent on the orientation of the coordinate system.
        /// <see cref="CLIP_MASK"/>
        /// Not used.
        /// <see cref="CLIP_DFA_OVERRIDE"/>
        /// Turns off font association for the font.
        /// This is identical to <see cref="CLIP_DFA_DISABLE"/>, but it can have problems in some situations;
        /// the recommended flag to use is <see cref="CLIP_DFA_DISABLE"/>.
        /// <see cref="CLIP_STROKE_PRECIS"/>
        /// Not used by the font mapper, but is returned when raster, vector, or TrueType fonts are enumerated.
        /// For compatibility, this value is always returned when enumerating fonts.
        /// <see cref="CLIP_TT_ALWAYS"/>
        /// Not used.
        /// </summary>
        public ClipPrecisions lfClipPrecision;

        /// <summary>
        /// The output quality.
        /// The output quality defines how carefully the graphics device interface (GDI) must attempt
        /// to match the logical-font attributes to those of an actual physical font.
        /// It can be one of the following values.
        /// <see cref="ANTIALIASED_QUALITY"/>
        /// Font is always antialiased if the font supports it and the size of the font is not too small or too large.
        /// <see cref="CLEARTYPE_QUALITY"/>
        /// If set, text is rendered(when possible) using ClearType antialiasing method.See Remarks for more information.
        /// <see cref="DEFAULT_QUALITY"/>
        /// Appearance of the font does not matter.
        /// <see cref="DRAFT_QUALITY"/>
        /// Appearance of the font is less important than when <see cref="PROOF_QUALITY"/> is used.For GDI raster fonts,
        /// scaling is enabled, which means that more font sizes are available, but the quality may be lower.
        /// Bold, italic, underline, and strikeout fonts are synthesized if necessary.
        /// <see cref="NONANTIALIASED_QUALITY"/>
        /// Font is never antialiased.
        /// <see cref="PROOF_QUALITY"/>
        /// Character quality of the font is more important than exact matching of the logical-font attributes.
        /// For GDI raster fonts, scaling is disabled and the font closest in size is chosen.
        /// Although the chosen font size may not be mapped exactly when <see cref="PROOF_QUALITY"/> is used,
        /// the quality of the font is high and there is no distortion of appearance.
        /// Bold, italic, underline, and strikeout fonts are synthesized if necessary.
        /// If neither <see cref="ANTIALIASED_QUALITY"/> nor <see cref="NONANTIALIASED_QUALITY"/> is selected,
        /// the font is antialiased only if the user chooses smooth screen fonts in Control Panel.
        /// </summary>
        public FontQualities lfQuality;

        /// <summary>
        /// The pitch and family of the font.
        /// The two low-order bits specify the pitch of the font and can be one of the following values.
        /// <see cref="DEFAULT_PITCH"/>
        /// <see cref="FIXED_PITCH"/>
        /// <see cref="VARIABLE_PITCH"/>
        /// Bits 4 through 7 of the member specify the font family and can be one of the following values.
        /// <see cref="FF_DECORATIVE"/>
        /// <see cref="FF_DONTCARE"/>
        /// <see cref="FF_MODERN"/>
        /// <see cref="FF_ROMAN"/>
        /// <see cref="FF_SCRIPT"/>
        /// <see cref="FF_SWISS"/>
        /// The proper value can be obtained by using the Boolean OR operator to join one pitch constant with one family constant.
        /// Font families describe the look of a font in a general way.
        /// They are intended for specifying fonts when the exact typeface desired is not available.
        /// The values for font families are as follows.
        /// <see cref="FF_DECORATIVE"/>
        /// Novelty fonts.Old English is an example.
        /// <see cref="FF_DONTCARE"/>
        /// Use default font.
        /// <see cref="FF_MODERN"/>
        /// Fonts with constant stroke width (monospace), with or without serifs.
        /// Monospace fonts are usually modern.
        /// Pica, Elite, and CourierNew are examples.
        /// <see cref="FF_ROMAN"/>
        /// Fonts with variable stroke width (proportional) and with serifs.
        /// MS Serif is an example.
        /// <see cref="FF_SCRIPT"/>
        /// Fonts designed to look like handwriting.Script and Cursive are examples.
        /// <see cref="FF_SWISS"/>
        /// Fonts with variable stroke width (proportional) and without serifs.
        /// MS Sans Serif is an example.
        /// </summary>
        public BYTE lfPitchAndFamily;

        /// <summary>
        /// A null-terminated string that specifies the typeface name of the font.
        /// The length of this string must not exceed 32 TCHAR values, including the terminating NULL.
        /// The <see cref="EnumFontFamiliesEx"/> function can be used to enumerate the typeface names of all currently available fonts.
        /// If <see cref="lfFaceName"/> is an empty string, GDI uses the first font that matches the other specified attributes.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
        public string lfFaceName;
    }
}
