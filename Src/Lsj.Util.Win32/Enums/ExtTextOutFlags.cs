using System;
using static Lsj.Util.Win32.Enums.TextAlignments;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="ExtTextOut"/> Flags;
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-exttextoutw"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum ExtTextOutFlags : uint
    {
        /// <summary>
        /// The text will be clipped to the rectangle.
        /// </summary>
        ETO_CLIPPED = 0x0004,

        /// <summary>
        /// The lpString array refers to an array returned from <see cref="GetCharacterPlacement"/> and
        /// should be parsed directly by GDI as no further language-specific processing is required.
        /// Glyph indexing only applies to TrueType fonts,
        /// but the flag can be used for bitmap and vector fonts to indicate that no further language processing is necessary
        /// and GDI should process the string directly.
        /// Note that all glyph indexes are 16-bit values even though the string is assumed to be an array of 8-bit values for raster fonts.
        /// For <see cref="ExtTextOut"/>, the glyph indexes are saved to a metafile.
        /// However, to display the correct characters the metafile must be played back using the same font.
        /// For ExtTextOutA, the glyph indexes are not saved.
        /// </summary>
        ETO_GLYPH_INDEX = 0x0010,

        /// <summary>
        /// Reserved for system use.
        /// If an application sets this flag, it loses international scripting support and in some cases it may display no text at all.
        /// </summary>
        ETO_IGNORELANGUAGE = 0x1000,

        /// <summary>
        /// To display numbers, use European digits.
        /// </summary>
        ETO_NUMERICSLATIN = 0x0800,

        /// <summary>
        /// To display numbers, use digits appropriate to the locale.
        /// </summary>
        ETO_NUMERICSLOCAL = 0x0400,

        /// <summary>
        /// The current background color should be used to fill the rectangle.
        /// </summary>
        ETO_OPAQUE = 0x0002,

        /// <summary>
        /// When this is set, the array pointed to by lpDx contains pairs of values.
        /// The first value of each pair is, as usual, the distance between origins of adjacent character cells,
        /// but the second value is the displacement along the vertical direction of the font.
        /// </summary>
        ETO_PDY = 0x2000,

        /// <summary>
        /// Middle East language edition of Windows:
        /// If this value is specified and a Hebrew or Arabic font is selected into the device context,
        /// the string is output using right-to-left reading order.
        /// If this value is not specified, the string is output in left-to-right order.
        /// The same effect can be achieved by setting the <see cref="TA_RTLREADING"/> value in <see cref="SetTextAlign"/>.
        /// This value is preserved for backward compatibility.
        /// </summary>
        ETO_RTLREADING = 0x0080,
    }
}
