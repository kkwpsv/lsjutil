using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.PANOSEValues;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="PANOSE"/> structure describes the <see cref="PANOSE"/> font-classification values for a TrueType font.
    /// These characteristics are then used to associate the font with other fonts of similar appearance but different names.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-panose"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PANOSE
    {
        /// <summary>
        /// <para>
        /// For Latin fonts, one of one of the following values.
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
        /// <see cref="PAN_ANY"/>
        /// </term>
        /// <term>
        /// Any
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_NO_FIT"/>
        /// </term>
        /// <term>
        /// No fit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_FAMILY_TEXT_DISPLAY"/>
        /// </term>
        /// <term>
        /// Text and display
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_FAMILY_SCRIPT"/>
        /// </term>
        /// <term>
        /// Script
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_FAMILY_DECORATIVE"/>
        /// </term>
        /// <term>
        /// Decorative
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_FAMILY_PICTORIAL"/>
        /// </term>
        /// <term>
        /// Pictorial
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PANOSEValues bFamilyType;

        /// <summary>
        /// <para>
        /// The serif style.
        /// For Latin fonts, one of the following values.
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
        /// <see cref="PAN_ANY"/>
        /// </term>
        /// <term>
        /// Any
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_NO_FIT"/>
        /// </term>
        /// <term>
        /// No fit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_COVE"/>
        /// </term>
        /// <term>
        /// Cove
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_OBTUSE_COVE"/>
        /// </term>
        /// <term>
        /// Obtuse cove
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_SQUARE_COVE"/>
        /// </term>
        /// <term>
        /// Square cove
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_OBTUSE_SQUARE_COVE"/>
        /// </term>
        /// <term>
        /// Obtuse square cove
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_SQUARE"/>
        /// </term>
        /// <term>
        /// Square
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_THIN"/>
        /// </term>
        /// <term>
        /// Thin
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_BONE"/>
        /// </term>
        /// <term>
        /// Bone
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_EXAGGERATED"/>
        /// </term>
        /// <term>
        /// Exaggerated
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_TRIANGLE"/>
        /// </term>
        /// <term>
        /// Triangle
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_NORMAL_SANS"/>
        /// </term>
        /// <term>
        /// Normal sans serif
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_OBTUSE_SANS"/>
        /// </term>
        /// <term>
        /// Obtuse sans serif
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_PERP_SANS"/>
        /// </term>
        /// <term>
        /// Perp sans serif
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_FLARED"/>
        /// </term>
        /// <term>
        /// Flared
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_SERIF_ROUNDED"/>
        /// </term>
        /// <term>
        /// Rounded
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PANOSEValues bSerifStyle;

        /// <summary>
        /// <para>
        /// For Latin fonts, one of the following values.
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
        /// <see cref="PAN_ANY"/>
        /// </term>
        /// <term>
        /// Any
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_NO_FIT"/>
        /// </term>
        /// <term>
        /// No fit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_WEIGHT_VERY_LIGHT"/>
        /// </term>
        /// <term>
        /// Very light
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_WEIGHT_LIGHT"/>
        /// </term>
        /// <term>
        /// Light
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_WEIGHT_THIN"/>
        /// </term>
        /// <term>
        /// Thin
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_WEIGHT_BOOK"/>
        /// </term>
        /// <term>
        /// Book
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_WEIGHT_MEDIUM"/>
        /// </term>
        /// <term>
        /// Medium
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_WEIGHT_DEMI"/>
        /// </term>
        /// <term>
        /// Demibold
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_WEIGHT_BOLD"/>
        /// </term>
        /// <term>
        /// Bold
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_WEIGHT_HEAVY"/>
        /// </term>
        /// <term>
        /// Heavy
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_WEIGHT_BLACK"/>
        /// </term>
        /// <term>
        /// Black
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_WEIGHT_NORD"/>
        /// </term>
        /// <term>
        /// Nord
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PANOSEValues bWeight;

        /// <summary>
        /// <para>
        /// For Latin fonts, one of the following values.
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
        /// <see cref="PAN_ANY"/>
        /// </term>
        /// <term>
        /// Any
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_NO_FIT"/>
        /// </term>
        /// <term>
        /// No fit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_PROP_OLD_STYLE"/>
        /// </term>
        /// <term>
        /// Old style
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_PROP_MODERN"/>
        /// </term>
        /// <term>
        /// Modern
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_PROP_EVEN_WIDTH"/>
        /// </term>
        /// <term>
        /// Even width
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_PROP_EXPANDED"/>
        /// </term>
        /// <term>
        /// Expanded
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_PROP_CONDENSED"/>
        /// </term>
        /// <term>
        /// Condensed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_PROP_VERY_EXPANDED"/>
        /// </term>
        /// <term>
        /// Very expanded
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_PROP_VERY_CONDENSED"/>
        /// </term>
        /// <term>
        /// Very condensed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_PROP_MONOSPACED"/>
        /// </term>
        /// <term>
        /// Monospaced
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PANOSEValues bProportion;

        /// <summary>
        /// <para>
        /// For Latin fonts, one of the following values.
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
        /// <see cref="PAN_ANY"/>
        /// </term>
        /// <term>
        /// Any
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_NO_FIT"/>
        /// </term>
        /// <term>
        /// No fit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_CONTRAST_NONE"/>
        /// </term>
        /// <term>
        /// None
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_CONTRAST_VERY_LOW"/>
        /// </term>
        /// <term>
        /// Very low
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_CONTRAST_LOW"/>
        /// </term>
        /// <term>
        /// Low
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_CONTRAST_MEDIUM_LOW"/>
        /// </term>
        /// <term>
        /// Medium low
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_CONTRAST_MEDIUM"/>
        /// </term>
        /// <term>
        /// Medium
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_CONTRAST_MEDIUM_HIGH"/>
        /// </term>
        /// <term>
        /// Medium high
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_CONTRAST_HIGH"/>
        /// </term>
        /// <term>
        /// High
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_CONTRAST_VERY_HIGH"/>
        /// </term>
        /// <term>
        /// Very high
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PANOSEValues bContrast;

        /// <summary>
        /// <para>
        /// For Latin fonts, one of the following values.
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
        /// <see cref="PAN_ANY"/>
        /// </term>
        /// <term>
        /// Any
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_NO_FIT"/>
        /// </term>
        /// <term>
        /// No fit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STROKE_GRADUAL_DIAG"/>
        /// </term>
        /// <term>
        /// Gradual/diagonal
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STROKE_GRADUAL_TRAN"/>
        /// </term>
        /// <term>
        /// Gradual/transitional
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STROKE_GRADUAL_VERT"/>
        /// </term>
        /// <term>
        /// Gradual/vertical
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STROKE_GRADUAL_HORZ"/>
        /// </term>
        /// <term>
        /// Gradual/horizontal
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STROKE_RAPID_VERT"/>
        /// </term>
        /// <term>
        /// Rapid/vertical
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STROKE_RAPID_HORZ"/>
        /// </term>
        /// <term>
        /// Rapid/horizontal
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STROKE_INSTANT_VERT"/>
        /// </term>
        /// <term>
        /// Instant/vertical
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PANOSEValues bStrokeVariation;

        /// <summary>
        /// <para>
        /// For Latin fonts, one of the following values.
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
        /// <see cref="PAN_ANY"/>
        /// </term>
        /// <term>
        /// Any
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_NO_FIT"/>
        /// </term>
        /// <term>
        /// No fit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STRAIGHT_ARMS_HORZ"/>
        /// </term>
        /// <term>
        /// Straight arms/horizontal
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STRAIGHT_ARMS_WEDGE"/>
        /// </term>
        /// <term>
        /// Straight arms/wedge
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STRAIGHT_ARMS_VERT"/>
        /// </term>
        /// <term>
        /// Straight arms/vertical
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STRAIGHT_ARMS_SINGLE_SERIF"/>
        /// </term>
        /// <term>
        /// Straight arms/single-serif
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_STRAIGHT_ARMS_DOUBLE_SERIF"/>
        /// </term>
        /// <term>
        /// Straight arms/double-serif
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_BENT_ARMS_HORZ"/>
        /// </term>
        /// <term>
        /// Nonstraight arms/horizontal
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_BENT_ARMS_WEDGE"/>
        /// </term>
        /// <term>
        /// Nonstraight arms/wedge
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_BENT_ARMS_VERT"/>
        /// </term>
        /// <term>
        /// Nonstraight arms/vertical
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_BENT_ARMS_SINGLE_SERIF"/>
        /// </term>
        /// <term>
        /// Nonstraight arms/single-serif
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_BENT_ARMS_DOUBLE_SERIF"/>
        /// </term>
        /// <term>
        /// Nonstraight arms/double-serif
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PANOSEValues bArmStyle;

        /// <summary>
        /// <para>
        /// For Latin fonts, one of the following values.
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
        /// <see cref="PAN_ANY"/>
        /// </term>
        /// <term>
        /// Any
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_NO_FIT"/>
        /// </term>
        /// <term>
        /// No fit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_NORMAL_CONTACT"/>
        /// </term>
        /// <term>
        /// Normal/contact
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_NORMAL_WEIGHTED"/>
        /// </term>
        /// <term>
        /// Normal/weighted
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_NORMAL_BOXED"/>
        /// </term>
        /// <term>
        /// Normal/boxed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_NORMAL_FLATTENED"/>
        /// </term>
        /// <term>
        /// Normal/flattened
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_NORMAL_ROUNDED"/>
        /// </term>
        /// <term>
        /// Normal/rounded
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_NORMAL_OFF_CENTER"/>
        /// </term>
        /// <term>
        /// Normal/off center
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_NORMAL_SQUARE"/>
        /// </term>
        /// <term>
        /// Normal/square
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_OBLIQUE_CONTACT"/>
        /// </term>
        /// <term>
        /// Oblique/contact
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_OBLIQUE_WEIGHTED"/>
        /// </term>
        /// <term>
        /// Oblique/weighted
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_OBLIQUE_BOXED"/>
        /// </term>
        /// <term>
        /// Oblique/boxed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_OBLIQUE_FLATTENED"/>
        /// </term>
        /// <term>
        /// Oblique/flattened
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_OBLIQUE_ROUNDED"/>
        /// </term>
        /// <term>
        /// Oblique/rounded
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_OBLIQUE_OFF_CENTER"/>
        /// </term>
        /// <term>
        /// Oblique/off center
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_LETT_OBLIQUE_SQUARE"/>
        /// </term>
        /// <term>
        /// Oblique/square
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PANOSEValues bLetterform;

        /// <summary>
        /// <para>
        /// For Latin fonts, one of the following values.
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
        /// <see cref="PAN_ANY"/>
        /// </term>
        /// <term>
        /// Any
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_NO_FIT"/>
        /// </term>
        /// <term>
        /// No fit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_STANDARD_TRIMMED"/>
        /// </term>
        /// <term>
        /// Standard/trimmed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_STANDARD_POINTED"/>
        /// </term>
        /// <term>
        /// Standard/pointed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_STANDARD_SERIFED"/>
        /// </term>
        /// <term>
        /// Standard/serifed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_HIGH_TRIMMED"/>
        /// </term>
        /// <term>
        /// High/trimmed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_HIGH_POINTED"/>
        /// </term>
        /// <term>
        /// High/pointed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_HIGH_SERIFED"/>
        /// </term>
        /// <term>
        /// High/serifed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_CONSTANT_TRIMMED"/>
        /// </term>
        /// <term>
        /// Constant/trimmed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_CONSTANT_POINTED"/>
        /// </term>
        /// <term>
        /// Constant/pointed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_CONSTANT_SERIFED"/>
        /// </term>
        /// <term>
        /// Constant/serifed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_LOW_TRIMMED"/>
        /// </term>
        /// <term>
        /// Low/trimmed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_LOW_POINTED"/>
        /// </term>
        /// <term>
        /// Low/pointed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_MIDLINE_LOW_SERIFED"/>
        /// </term>
        /// <term>
        /// Low/serifed
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PANOSEValues bMidline;

        /// <summary>
        /// <para>
        /// For Latin fonts, one of the following values.
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
        /// <see cref="PAN_ANY"/>
        /// </term>
        /// <term>
        /// Any
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_NO_FIT"/>
        /// </term>
        /// <term>
        /// No fit
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_XHEIGHT_CONSTANT_SMALL"/>
        /// </term>
        /// <term>
        /// Constant/small
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_XHEIGHT_CONSTANT_STD"/>
        /// </term>
        /// <term>
        /// Constant/standard
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_XHEIGHT_CONSTANT_LARGE"/>
        /// </term>
        /// <term>
        /// Constant/large
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_XHEIGHT_DUCKING_SMALL"/>
        /// </term>
        /// <term>
        /// Ducking/small
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_XHEIGHT_DUCKING_STD"/>
        /// </term>
        /// <term>
        /// Ducking/standard
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAN_XHEIGHT_DUCKING_LARGE"/>
        /// </term>
        /// <term>
        /// Ducking/large
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PANOSEValues bXHeight;
    }
}
