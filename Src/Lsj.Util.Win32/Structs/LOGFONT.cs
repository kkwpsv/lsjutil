using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
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
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="LOGFONT"/> structure defines the attributes of a font.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-logfontw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The following situations do not support ClearType antialiasing:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Text is rendered on a printer.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Display set for 256 colors or less.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Text is rendered to a terminal server client.
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
    /// The font has tuned embedded bitmaps, for any font sizes that contain the embedded bitmaps.
    /// For example, this occurs commonly in East Asian fonts.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOGFONT
    {
        /// <summary>
        /// LF_FACESIZE
        /// </summary>
        public const int LF_FACESIZE = 32;

        /// <summary>
        /// <para>
        /// The height, in logical units, of the font's character cell or character.
        /// The character height value (also known as the em height) is the character cell height value minus the internal-leading value.
        /// The font mapper interprets the value specified in <see cref="lfHeight"/> in the following manner.
        /// </para>
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
        /// <para>
        /// For all height comparisons, the font mapper looks for the largest font that does not exceed the requested size.
        /// </para>
        /// <para>
        /// This mapping occurs when the font is used for the first time.
        /// </para>
        /// <para>
        /// For the <see cref="MM_TEXT"/> mapping mode, you can use the following formula to specify a height for a font with a specified point size:
        /// </para>
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
        /// <para>
        /// The angle, in tenths of degrees, between the escapement vector and the x-axis of the device.
        /// The escapement vector is parallel to the base line of a row of text.
        /// </para>
        /// <para>
        /// When the graphics mode is set to <see cref="GM_ADVANCED"/>, you can specify the escapement angle
        /// of the string independently of the orientation angle of the string's characters.
        /// </para>
        /// <para>
        /// When the graphics mode is set to <see cref="GM_COMPATIBLE"/>, <see cref="lfEscapement"/> specifies both the escapement and orientation.
        /// You should set <see cref="lfEscapement"/> and <see cref="lfOrientation"/> to the same value.
        /// </para>
        /// </summary>
        public LONG lfEscapement;

        /// <summary>
        /// The angle, in tenths of degrees, between each character's base line and the x-axis of the device.
        /// </summary>
        public LONG lfOrientation;

        /// <summary>
        /// <para>
        /// The weight of the font in the range 0 through 1000.
        /// For example, 400 is normal and 700 is bold.
        /// If this value is zero, a default weight is used.
        /// </para>
        /// <para>
        /// The following values are defined for convenience.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Weight
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
        /// </summary>
        public LONG lfWeight;

        /// <summary>
        /// An italic font if set to <see cref="TRUE"/>.
        /// </summary>
        public BYTE lfItalic;

        /// <summary>
        /// An underlined font if set to <see cref="TRUE"/>.
        /// </summary>
        public BYTE lfUnderline;

        /// <summary>
        /// A strikeout font if set to <see cref="TRUE"/>.
        /// </summary>
        public BYTE lfStrikeOut;

        /// <summary>
        /// <para>
        /// The character set. The following values are predefined:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ANSI_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="BALTIC_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CHINESEBIG5_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DEFAULT_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="EASTEUROPE_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GB2312_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GREEK_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="HANGUL_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MAC_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="OEM_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="RUSSIAN_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SHIFTJIS_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SYMBOL_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="TURKISH_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="VIETNAMESE_CHARSET"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Korean language edition of Windows:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="JOHAB_CHARSET"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Middle East language edition of Windows:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ARABIC_CHARSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="HEBREW_CHARSET"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Thai language edition of Windows:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// THAI_CHARSET
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// The <see cref="OEM_CHARSET"/> value specifies a character set that is operating-system dependent.
        /// </para>
        /// <para>
        /// <see cref="DEFAULT_CHARSET"/> is set to a value based on the current system locale.
        /// For example, when the system locale is English (United States), it is set as <see cref="ANSI_CHARSET"/>.
        /// </para>
        /// <para>
        /// Fonts with other character sets may exist in the operating system.
        /// If an application uses a font with an unknown character set,
        /// it should not attempt to translate or interpret strings that are rendered with that font.
        /// </para>
        /// <para>
        /// This parameter is important in the font mapping process.
        /// To ensure consistent results when creating a font, do not specify <see cref="OEM_CHARSET"/> or <see cref="DEFAULT_CHARSET"/>.
        /// If you specify a typeface name in the <see cref="lfFaceName"/> member,
        /// make sure that the <see cref="lfCharSet"/> value matches the character set of the typeface specified in <see cref="lfFaceName"/>.
        /// </para>
        /// </summary>
        public CharacterSets lfCharSet;

        /// <summary>
        /// <para>
        /// The output precision.
        /// The output precision defines how closely the output must match the requested font's height, width,
        /// character orientation, escapement, pitch, and font type. It can be one of the following values.
        /// </para>
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
        /// Specifies the default font mapper behavior.
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
        /// This value is not used by the font mapper, but it is returned when TrueType,
        /// other outline-based fonts, and vector fonts are enumerated.
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
        /// <para>
        /// Applications can use the <see cref="OUT_DEVICE_PRECIS"/>, <see cref="OUT_RASTER_PRECIS"/>, <see cref="OUT_TT_PRECIS"/>,
        /// and <see cref="OUT_PS_ONLY_PRECIS"/> values to control how the font mapper
        /// chooses a font when the operating system contains more than one font with a specified name.
        /// For example, if an operating system contains a font named Symbol in raster and TrueType form,
        /// specifying <see cref="OUT_TT_PRECIS"/> forces the font mapper to choose the TrueType version.
        /// Specifying <see cref="OUT_TT_ONLY_PRECIS"/> forces the font mapper to choose a TrueType font,
        /// even if it must substitute a TrueType font of another name.
        /// </para>
        /// </summary>
        public OutPrecisions lfOutPrecision;

        /// <summary>
        /// <para>
        /// The clipping precision.
        /// The clipping precision defines how to clip characters that are partially outside the clipping region.
        /// It can be one or more of the following values.
        /// </para>
        /// <para>
        /// For more information about the orientation of coordinate systems,
        /// see the description of the <see cref="lfOrientation"/> parameter.
        /// </para>
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
        /// When this value is used, the rotation for all fonts depends on whether the orientation of the coordinate system is left-handed or right-handed.
        /// If not used, device fonts always rotate counterclockwise, but the rotation of other fonts is dependent on the orientation of the coordinate system.
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
        /// Not used by the font mapper, but is returned when raster, vector, or TrueType fonts are enumerated.
        /// For compatibility, this value is always returned when enumerating fonts.
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
        /// </summary>
        public ClipPrecisions lfClipPrecision;

        /// <summary>
        /// <para>
        /// The output quality.
        /// The output quality defines how carefully the graphics device interface (GDI) must attempt
        /// to match the logical-font attributes to those of an actual physical font.
        /// It can be one of the following values.
        /// </para>
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
        /// Font is always antialiased if the font supports it and the size of the font is not too small or too large.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLEARTYPE_QUALITY"/>
        /// </term>
        /// <term>
        /// If set, text is rendered (when possible) using ClearType antialiasing method.
        /// See Remarks for more information.
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
        /// Appearance of the font is less important than when <see cref="PROOF_QUALITY"/> is used.
        /// For GDI raster fonts, scaling is enabled, which means that more font sizes are available, but the quality may be lower.
        /// Bold, italic, underline, and strikeout fonts are synthesized if necessary.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NONANTIALIASED_QUALITY"/>
        /// </term>
        /// <term>
        /// Font is never antialiased.
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
        /// Bold, italic, underline, and strikeout fonts are synthesized if necessary.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// If neither <see cref="ANTIALIASED_QUALITY"/> nor <see cref="NONANTIALIASED_QUALITY"/> is selected,
        /// the font is antialiased only if the user chooses smooth screen fonts in Control Panel.
        /// </para>
        /// </summary>
        public FontQualities lfQuality;

        /// <summary>
        /// <para>
        /// The pitch and family of the font.
        /// The two low-order bits specify the pitch of the font and can be one of the following values.
        /// </para>
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
        /// <para>
        /// Bits 4 through 7 of the member specify the font family and can be one of the following values.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="FF_DECORATIVE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FF_DONTCARE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FF_MODERN"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FF_ROMAN"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FF_SCRIPT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FF_SWISS"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// The proper value can be obtained by using the bitwise OR (|) operator to join one pitch constant with one family constant.
        /// </para>
        /// <para>
        /// Font families describe the look of a font in a general way.
        /// They are intended for specifying fonts when the exact typeface desired is not available.
        /// The values for font families are as follows.
        /// </para>
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
        /// Fonts with constant stroke width (monospace), with or without serifs.
        /// Monospace fonts are usually modern.
        /// Pica, Elite, and CourierNew are examples.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FF_ROMAN"/>
        /// </term>
        /// <term>
        /// Fonts with variable stroke width (proportional) and with serifs.
        /// MS Serif is an example.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FF_SCRIPT"/>
        /// </term>
        /// <term>
        /// Fonts designed to look like handwriting.
        /// Script and Cursive are examples.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FF_SWISS"/>
        /// </term>
        /// <term>
        /// Fonts with variable stroke width (proportional) and without serifs.
        /// MS Sans Serif is an example.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public BYTE lfPitchAndFamily;

        /// <summary>
        /// A null-terminated string that specifies the typeface name of the font.
        /// The length of this string must not exceed 32 TCHAR values, including the terminating NULL.
        /// The <see cref="EnumFontFamiliesEx"/> function can be used to enumerate the typeface names of all currently available fonts.
        /// If <see cref="lfFaceName"/> is an empty string, GDI uses the first font that matches the other specified attributes.
        /// </summary>
        public ByValStringStructForSize32 lfFaceName;
    }
}
