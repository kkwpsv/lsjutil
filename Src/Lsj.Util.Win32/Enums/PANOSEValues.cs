using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="PANOSE"/> Values
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-panose"/>
    /// </para>
    /// </summary>
    public enum PANOSEValues : byte
    {
        /// <summary>
        /// Any
        /// </summary>
        PAN_ANY = 0,

        /// <summary>
        /// No fit
        /// </summary>
        PAN_NO_FIT = 1,

        /// <summary>
        /// Text and display
        /// </summary>
        PAN_FAMILY_TEXT_DISPLAY = 2,

        /// <summary>
        /// Script
        /// </summary>
        PAN_FAMILY_SCRIPT = 3,

        /// <summary>
        /// Decorative
        /// </summary>
        PAN_FAMILY_DECORATIVE = 4,

        /// <summary>
        /// Pictorial
        /// </summary>
        PAN_FAMILY_PICTORIAL = 5,

        /// <summary>
        /// Cove
        /// </summary>
        PAN_SERIF_COVE = 2,

        /// <summary>
        /// Obtuse cove
        /// </summary>
        PAN_SERIF_OBTUSE_COVE = 3,

        /// <summary>
        /// Square cove
        /// </summary>
        PAN_SERIF_SQUARE_COVE = 4,

        /// <summary>
        /// Obtuse square cove
        /// </summary>
        PAN_SERIF_OBTUSE_SQUARE_COVE = 5,

        /// <summary>
        /// Square
        /// </summary>
        PAN_SERIF_SQUARE = 6,

        /// <summary>
        /// Thin
        /// </summary>
        PAN_SERIF_THIN = 7,

        /// <summary>
        /// Bone
        /// </summary>
        PAN_SERIF_BONE = 8,

        /// <summary>
        /// Exaggerated
        /// </summary>
        PAN_SERIF_EXAGGERATED = 9,

        /// <summary>
        /// Triangle
        /// </summary>
        PAN_SERIF_TRIANGLE = 10,

        /// <summary>
        /// Normal sans serif
        /// </summary>
        PAN_SERIF_NORMAL_SANS = 11,

        /// <summary>
        /// Obtuse sans serif
        /// </summary>
        PAN_SERIF_OBTUSE_SANS = 12,

        /// <summary>
        /// Perp sans serif
        /// </summary>
        PAN_SERIF_PERP_SANS = 13,

        /// <summary>
        /// Flared
        /// </summary>
        PAN_SERIF_FLARED = 14,

        /// <summary>
        /// Rounded
        /// </summary>
        PAN_SERIF_ROUNDED = 15,

        /// <summary>
        /// Very light
        /// </summary>
        PAN_WEIGHT_VERY_LIGHT = 2,

        /// <summary>
        /// Light
        /// </summary>
        PAN_WEIGHT_LIGHT = 3,

        /// <summary>
        /// Thin
        /// </summary>
        PAN_WEIGHT_THIN = 4,

        /// <summary>
        /// Book
        /// </summary>
        PAN_WEIGHT_BOOK = 5,

        /// <summary>
        /// Medium
        /// </summary>
        PAN_WEIGHT_MEDIUM = 6,

        /// <summary>
        /// Demibold
        /// </summary>
        PAN_WEIGHT_DEMI = 7,

        /// <summary>
        /// Bold
        /// </summary>
        PAN_WEIGHT_BOLD = 8,

        /// <summary>
        /// Heavy
        /// </summary>
        PAN_WEIGHT_HEAVY = 9,

        /// <summary>
        /// Black
        /// </summary>
        PAN_WEIGHT_BLACK = 10,

        /// <summary>
        /// NORD
        /// </summary>
        PAN_WEIGHT_NORD = 11,

        /// <summary>
        /// Old style
        /// </summary>
        PAN_PROP_OLD_STYLE = 2,

        /// <summary>
        /// Modern
        /// </summary>
        PAN_PROP_MODERN = 3,

        /// <summary>
        /// Even width
        /// </summary>
        PAN_PROP_EVEN_WIDTH = 4,

        /// <summary>
        /// Expanded
        /// </summary>
        PAN_PROP_EXPANDED = 5,

        /// <summary>
        /// Condensed
        /// </summary>
        PAN_PROP_CONDENSED = 6,

        /// <summary>
        /// Very expanded
        /// </summary>
        PAN_PROP_VERY_EXPANDED = 7,

        /// <summary>
        /// Very condensed
        /// </summary>
        PAN_PROP_VERY_CONDENSED = 8,

        /// <summary>
        /// Monospaced
        /// </summary>
        PAN_PROP_MONOSPACED = 9,

        /// <summary>
        /// None
        /// </summary>
        PAN_CONTRAST_NONE = 2,

        /// <summary>
        /// Very low
        /// </summary>
        PAN_CONTRAST_VERY_LOW = 3,

        /// <summary>
        /// Low
        /// </summary>
        PAN_CONTRAST_LOW = 4,

        /// <summary>
        /// Medium low
        /// </summary>
        PAN_CONTRAST_MEDIUM_LOW = 5,

        /// <summary>
        /// Medium
        /// </summary>
        PAN_CONTRAST_MEDIUM = 6,

        /// <summary>
        /// Medium high
        /// </summary>
        PAN_CONTRAST_MEDIUM_HIGH = 7,

        /// <summary>
        /// High
        /// </summary>
        PAN_CONTRAST_HIGH = 8,

        /// <summary>
        /// Very high
        /// </summary>
        PAN_CONTRAST_VERY_HIGH = 9,

        /// <summary>
        /// Gradual/diagonal
        /// </summary>
        PAN_STROKE_GRADUAL_DIAG = 2,

        /// <summary>
        /// Gradual/transitional
        /// </summary>
        PAN_STROKE_GRADUAL_TRAN = 3,

        /// <summary>
        /// Gradual/vertical
        /// </summary>
        PAN_STROKE_GRADUAL_VERT = 4,

        /// <summary>
        /// Gradual/horizontal
        /// </summary>
        PAN_STROKE_GRADUAL_HORZ = 5,

        /// <summary>
        /// Rapid/vertical
        /// </summary>
        PAN_STROKE_RAPID_VERT = 6,

        /// <summary>
        /// Rapid/horizontal
        /// </summary>
        PAN_STROKE_RAPID_HORZ = 7,

        /// <summary>
        /// Instant/vertical
        /// </summary>
        PAN_STROKE_INSTANT_VERT = 8,

        /// <summary>
        /// Straight arms/horizontal
        /// </summary>
        PAN_STRAIGHT_ARMS_HORZ = 2,

        /// <summary>
        /// Straight arms/wedge
        /// </summary>
        PAN_STRAIGHT_ARMS_WEDGE = 3,

        /// <summary>
        /// Straight arms/vertical
        /// </summary>
        PAN_STRAIGHT_ARMS_VERT = 4,

        /// <summary>
        /// Straight arms/single-serif
        /// </summary>
        PAN_STRAIGHT_ARMS_SINGLE_SERIF = 5,

        /// <summary>
        /// Straight arms/double-serif
        /// </summary>
        PAN_STRAIGHT_ARMS_DOUBLE_SERIF = 6,

        /// <summary>
        /// Nonstraight arms/horizontal
        /// </summary>
        PAN_BENT_ARMS_HORZ = 7,

        /// <summary>
        /// Nonstraight arms/wedge
        /// </summary>
        PAN_BENT_ARMS_WEDGE = 8,

        /// <summary>
        /// Nonstraight arms/vertical
        /// </summary>
        PAN_BENT_ARMS_VERT = 9,

        /// <summary>
        /// Nonstraight arms/single-serif
        /// </summary>
        PAN_BENT_ARMS_SINGLE_SERIF = 10,

        /// <summary>
        /// Nonstraight arms/double-serif
        /// </summary>
        PAN_BENT_ARMS_DOUBLE_SERIF = 11,

        /// <summary>
        /// Normal/contact
        /// </summary>
        PAN_LETT_NORMAL_CONTACT = 2,

        /// <summary>
        /// Normal/weighted
        /// </summary>
        PAN_LETT_NORMAL_WEIGHTED = 3,

        /// <summary>
        /// Normal/boxed
        /// </summary>
        PAN_LETT_NORMAL_BOXED = 4,

        /// <summary>
        /// Normal/flattened
        /// </summary>
        PAN_LETT_NORMAL_FLATTENED = 5,

        /// <summary>
        /// Normal/rounded
        /// </summary>
        PAN_LETT_NORMAL_ROUNDED = 6,

        /// <summary>
        /// Normal/off center
        /// </summary>
        PAN_LETT_NORMAL_OFF_CENTER = 7,

        /// <summary>
        /// Normal/square
        /// </summary>
        PAN_LETT_NORMAL_SQUARE = 8,

        /// <summary>
        /// Oblique/contact
        /// </summary>
        PAN_LETT_OBLIQUE_CONTACT = 9,

        /// <summary>
        /// Oblique/weighted
        /// </summary>
        PAN_LETT_OBLIQUE_WEIGHTED = 10,

        /// <summary>
        /// Oblique/boxed
        /// </summary>
        PAN_LETT_OBLIQUE_BOXED = 11,

        /// <summary>
        /// Oblique/flattened
        /// </summary>
        PAN_LETT_OBLIQUE_FLATTENED = 12,

        /// <summary>
        /// Oblique/rounded
        /// </summary>
        PAN_LETT_OBLIQUE_ROUNDED = 13,

        /// <summary>
        /// Oblique/off center
        /// </summary>
        PAN_LETT_OBLIQUE_OFF_CENTER = 14,

        /// <summary>
        /// Oblique/square
        /// </summary>
        PAN_LETT_OBLIQUE_SQUARE = 15,

        /// <summary>
        /// Standard/trimmed
        /// </summary>
        PAN_MIDLINE_STANDARD_TRIMMED = 2,

        /// <summary>
        /// Standard/pointed
        /// </summary>
        PAN_MIDLINE_STANDARD_POINTED = 3,

        /// <summary>
        /// Standard/serifed
        /// </summary>
        PAN_MIDLINE_STANDARD_SERIFED = 4,

        /// <summary>
        /// High/trimmed
        /// </summary>
        PAN_MIDLINE_HIGH_TRIMMED = 5,

        /// <summary>
        /// High/pointed
        /// </summary>
        PAN_MIDLINE_HIGH_POINTED = 6,

        /// <summary>
        /// High/serifed
        /// </summary>
        PAN_MIDLINE_HIGH_SERIFED = 7,

        /// <summary>
        /// Constant/trimmed
        /// </summary>
        PAN_MIDLINE_CONSTANT_TRIMMED = 8,

        /// <summary>
        /// Constant/pointed
        /// </summary>
        PAN_MIDLINE_CONSTANT_POINTED = 9,

        /// <summary>
        /// Constant/serifed 
        /// </summary>
        PAN_MIDLINE_CONSTANT_SERIFED = 10,

        /// <summary>
        /// Low/trimmed
        /// </summary>
        PAN_MIDLINE_LOW_TRIMMED = 11,

        /// <summary>
        /// Low/pointed
        /// </summary>
        PAN_MIDLINE_LOW_POINTED = 12,

        /// <summary>
        /// Low/serifed
        /// </summary>
        PAN_MIDLINE_LOW_SERIFED = 13,

        /// <summary>
        /// Constant/small
        /// </summary>
        PAN_XHEIGHT_CONSTANT_SMALL = 2,

        /// <summary>
        /// Constant/standard
        /// </summary>
        PAN_XHEIGHT_CONSTANT_STD = 3,

        /// <summary>
        /// Constant/large
        /// </summary>
        PAN_XHEIGHT_CONSTANT_LARGE = 4,

        /// <summary>
        /// Ducking/small
        /// </summary>
        PAN_XHEIGHT_DUCKING_SMALL = 5,

        /// <summary>
        /// Ducking/standard
        /// </summary>
        PAN_XHEIGHT_DUCKING_STD = 6,

        /// <summary>
        /// Ducking/large
        /// </summary>
        PAN_XHEIGHT_DUCKING_LARGE = 7,
    }
}
