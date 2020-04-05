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
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-panose
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PANOSE
    {
        /// <summary>
        /// For Latin fonts, one of one of the following values.
        /// <see cref="PAN_ANY"/>, <see cref="PAN_NO_FIT"/>, <see cref="PAN_FAMILY_TEXT_DISPLAY"/>, <see cref="PAN_FAMILY_SCRIPT"/>,
        /// <see cref="PAN_FAMILY_DECORATIVE"/>, <see cref="PAN_FAMILY_PICTORIAL"/>
        /// </summary>
        public PANOSEValues bFamilyType;

        /// <summary>
        /// The serif style. For Latin fonts, one of the following values.
        /// <see cref="PAN_ANY"/>, <see cref="PAN_NO_FIT"/>, <see cref="PAN_SERIF_COVE"/>, <see cref="PAN_SERIF_OBTUSE_COVE"/>,
        /// <see cref="PAN_SERIF_SQUARE_COVE"/>, <see cref="PAN_SERIF_OBTUSE_SQUARE_COVE"/>, <see cref="PAN_SERIF_SQUARE"/>,
        /// <see cref="PAN_SERIF_THIN"/>, <see cref="PAN_SERIF_BONE"/>, <see cref="PAN_SERIF_EXAGGERATED"/>, <see cref="PAN_SERIF_TRIANGLE"/>,
        /// <see cref="PAN_SERIF_NORMAL_SANS"/>, <see cref="PAN_SERIF_OBTUSE_SANS"/>, <see cref="PAN_SERIF_PERP_SANS"/>,
        /// <see cref="PAN_SERIF_FLARED"/>, <see cref="PAN_SERIF_ROUNDED"/>
        /// </summary>
        public PANOSEValues bSerifStyle;

        /// <summary>
        /// For Latin fonts, one of the following values.
        /// <see cref="PAN_ANY"/>, <see cref="PAN_NO_FIT"/>, <see cref="PAN_WEIGHT_VERY_LIGHT"/>, <see cref="PAN_WEIGHT_LIGHT"/>,
        /// <see cref="PAN_WEIGHT_THIN"/>, <see cref="PAN_WEIGHT_BOOK"/>, <see cref="PAN_WEIGHT_MEDIUM"/>, <see cref="PAN_WEIGHT_DEMI"/>,
        /// <see cref="PAN_WEIGHT_BOLD"/>, <see cref="PAN_WEIGHT_HEAVY"/>, <see cref="PAN_WEIGHT_BLACK"/>, <see cref="PAN_WEIGHT_NORD"/>
        /// </summary>
        public PANOSEValues bWeight;

        /// <summary>
        /// For Latin fonts, one of the following values.
        /// <see cref="PAN_ANY"/>, <see cref="PAN_NO_FIT"/>, <see cref="PAN_PROP_OLD_STYLE"/>, <see cref="PAN_PROP_MODERN"/>,
        /// <see cref="PAN_PROP_EVEN_WIDTH"/>, <see cref="PAN_PROP_EXPANDED"/>, <see cref="PAN_PROP_CONDENSED"/>,
        /// <see cref="PAN_PROP_VERY_EXPANDED"/>, <see cref="PAN_PROP_VERY_CONDENSED"/>, <see cref="PAN_PROP_MONOSPACED"/>
        /// </summary>
        public PANOSEValues bProportion;

        /// <summary>
        /// For Latin fonts, one of the following values.
        /// <see cref="PAN_ANY"/>, <see cref="PAN_NO_FIT"/>, <see cref="PAN_CONTRAST_NONE"/>, <see cref="PAN_CONTRAST_VERY_LOW"/>,
        /// <see cref="PAN_CONTRAST_LOW"/>, <see cref="PAN_CONTRAST_MEDIUM_LOW"/>, <see cref="PAN_CONTRAST_MEDIUM"/>,
        /// <see cref="PAN_CONTRAST_MEDIUM_HIGH"/>, <see cref="PAN_CONTRAST_HIGH"/>, <see cref="PAN_CONTRAST_VERY_HIGH"/>
        /// </summary>
        public PANOSEValues bContrast;

        /// <summary>
        /// For Latin fonts, one of the following values.
        /// <see cref="PAN_ANY"/>, <see cref="PAN_NO_FIT"/>, <see cref="PAN_STROKE_GRADUAL_DIAG"/>, <see cref="PAN_STROKE_GRADUAL_TRAN"/>,
        /// <see cref="PAN_STROKE_GRADUAL_VERT"/>, <see cref="PAN_STROKE_GRADUAL_HORZ"/>, <see cref="PAN_STROKE_RAPID_VERT"/>,
        /// <see cref="PAN_STROKE_RAPID_HORZ"/>, <see cref="PAN_STROKE_INSTANT_VERT"/>
        /// </summary>
        public PANOSEValues bStrokeVariation;

        /// <summary>
        /// For Latin fonts, one of the following values.
        /// <see cref="PAN_ANY"/>, <see cref="PAN_NO_FIT"/>, <see cref="PAN_STRAIGHT_ARMS_HORZ"/>, <see cref="PAN_STRAIGHT_ARMS_WEDGE"/>,
        /// <see cref="PAN_STRAIGHT_ARMS_VERT"/>, <see cref="PAN_STRAIGHT_ARMS_SINGLE_SERIF"/>, <see cref="PAN_STRAIGHT_ARMS_DOUBLE_SERIF"/>,
        /// <see cref="PAN_BENT_ARMS_HORZ"/>， <see cref="PAN_BENT_ARMS_WEDGE"/>, <see cref="PAN_BENT_ARMS_VERT"/>,
        /// <see cref="PAN_BENT_ARMS_SINGLE_SERIF"/>, <see cref="PAN_BENT_ARMS_DOUBLE_SERIF"/>
        /// </summary>
        public PANOSEValues bArmStyle;

        /// <summary>
        /// For Latin fonts, one of the following values.
        /// <see cref="PAN_ANY"/>, <see cref="PAN_NO_FIT"/>, <see cref="PAN_LETT_NORMAL_CONTACT"/>, <see cref="PAN_LETT_NORMAL_WEIGHTED"/>,
        /// <see cref="PAN_LETT_NORMAL_BOXED"/>, <see cref="PAN_LETT_NORMAL_FLATTENED"/>, <see cref="PAN_LETT_NORMAL_ROUNDED"/>,
        /// <see cref="PAN_LETT_NORMAL_OFF_CENTER"/>, <see cref="PAN_LETT_NORMAL_SQUARE"/>, <see cref="PAN_LETT_OBLIQUE_CONTACT"/>,
        /// <see cref="PAN_LETT_OBLIQUE_WEIGHTED"/>, <see cref="PAN_LETT_OBLIQUE_BOXED"/>, <see cref="PAN_LETT_OBLIQUE_FLATTENED"/>,
        /// <see cref="PAN_LETT_OBLIQUE_ROUNDED"/>, <see cref="PAN_LETT_OBLIQUE_OFF_CENTER"/>, <see cref="PAN_LETT_OBLIQUE_SQUARE"/>
        /// </summary>
        public PANOSEValues bLetterform;

        /// <summary>
        /// For Latin fonts, one of the following values.
        /// <see cref="PAN_ANY"/>, <see cref="PAN_NO_FIT"/>, <see cref="PAN_MIDLINE_STANDARD_TRIMMED"/>, <see cref="PAN_MIDLINE_STANDARD_POINTED"/>,
        /// <see cref="PAN_MIDLINE_STANDARD_SERIFED"/>, <see cref="PAN_MIDLINE_HIGH_TRIMMED"/>, <see cref="PAN_MIDLINE_HIGH_POINTED"/>,
        /// <see cref="PAN_MIDLINE_HIGH_SERIFED"/>, <see cref="PAN_MIDLINE_CONSTANT_TRIMMED"/>, <see cref="PAN_MIDLINE_CONSTANT_POINTED"/>,
        /// <see cref="PAN_MIDLINE_CONSTANT_SERIFED"/>, <see cref="PAN_MIDLINE_LOW_TRIMMED"/>, <see cref="PAN_MIDLINE_LOW_POINTED"/>,
        /// <see cref="PAN_MIDLINE_LOW_SERIFED"/>
        /// </summary>
        public PANOSEValues bMidline;

        /// <summary>
        /// For Latin fonts, one of the following values.
        /// <see cref="PAN_ANY"/>, <see cref="PAN_NO_FIT"/>, <see cref="PAN_XHEIGHT_CONSTANT_SMALL"/>, <see cref="PAN_XHEIGHT_CONSTANT_STD"/>,
        /// <see cref="PAN_XHEIGHT_CONSTANT_LARGE"/>, <see cref="PAN_XHEIGHT_DUCKING_SMALL"/>, <see cref="PAN_XHEIGHT_DUCKING_STD"/>,
        /// <see cref="PAN_XHEIGHT_DUCKING_LARGE"/>
        /// </summary>
        public PANOSEValues bXHeight;
    }
}
