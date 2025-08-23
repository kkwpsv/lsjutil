using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.Illuminants;
using static Lsj.Util.Win32.Enums.StretchBltModes;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Constants;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="COLORADJUSTMENT"/> structure defines the color adjustment values
    /// used by the <see cref="StretchBlt"/> and <see cref="StretchDIBits"/> functions when the stretch mode is <see cref="HALFTONE"/>.
    /// You can set the color adjustment values by calling the <see cref="SetColorAdjustment"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-coloradjustment"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COLORADJUSTMENT
    {
        /// <summary>
        /// CA_LOG_FILTER
        /// </summary>
        public const ushort CA_LOG_FILTER = 2;

        /// <summary>
        /// CA_NEGATIVE
        /// </summary>
        public const ushort CA_NEGATIVE = 1;


        /// <summary>
        /// The size, in bytes, of the structure.
        /// </summary>
        public WORD caSize;

        /// <summary>
        /// <para>
        /// Specifies how the output image should be prepared.
        /// This member may be set to <see cref="NULL"/> or any combination of the following values.
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
        /// <see cref="CA_NEGATIVE"/>
        /// </term>
        /// <term>
        /// Specifies that the negative of the original image should be displayed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CA_LOG_FILTER"/>
        /// </term>
        /// <term>
        /// Specifies that a logarithmic function should be applied to the final density of the output colors.
        /// This will increase the color contrast when the luminance is low.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public WORD caFlags;

        /// <summary>
        /// <para>
        /// The type of standard light source under which the image is viewed. This member may be set to one of the following values.
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
        /// <see cref="ILLUMINANT_DEVICE_DEFAULT"/>
        /// </term>
        /// <term>
        /// Device's default. Standard used by output devices.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_A"/>
        /// </term>
        /// <term>
        /// Tungsten lamp.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_B"/>
        /// </term>
        /// <term>
        /// Noon sunlight.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_C"/>
        /// </term>
        /// <term>
        /// NTSC daylight.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_D50"/>
        /// </term>
        /// <term>
        /// Normal print.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_D55"/>
        /// </term>
        /// <term>
        /// Bond paper print.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_D65"/>
        /// </term>
        /// <term>
        /// Standard daylight. Standard for CRTs and pictures.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_D75"/>
        /// </term>
        /// <term>
        /// Northern daylight.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_F2"/>
        /// </term>
        /// <term>
        /// Cool white lamp.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_TUNGSTEN"/>
        /// </term>
        /// <term>
        /// Same as <see cref="ILLUMINANT_A"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_DAYLIGHT"/>
        /// </term>
        /// <term>
        /// Same as <see cref="ILLUMINANT_C"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_FLUORESCENT"/>
        /// </term>
        /// <term>
        /// Same as <see cref="ILLUMINANT_F2"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ILLUMINANT_NTSC"/>
        /// </term>
        /// <term>
        /// Same as <see cref="ILLUMINANT_C"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public Illuminants caIlluminantIndex;

        /// <summary>
        /// Specifies the nth power gamma-correction value for the red primary of the source colors.
        /// The value must be in the range from 2500 to 65,000.
        /// A value of 10,000 means no gamma correction.
        /// </summary>
        public WORD caRedGamma;

        /// <summary>
        /// Specifies the nth power gamma-correction value for the green primary of the source colors.
        /// The value must be in the range from 2500 to 65,000.
        /// A value of 10,000 means no gamma correction.
        /// </summary>
        public WORD caGreenGamma;

        /// <summary>
        /// Specifies the nth power gamma-correction value for the blue primary of the source colors.
        /// The value must be in the range from 2500 to 65,000.
        /// A value of 10,000 means no gamma correction.
        /// </summary>
        public WORD caBlueGamma;

        /// <summary>
        /// The black reference for the source colors.
        /// Any colors that are darker than this are treated as black.
        /// The value must be in the range from 0 to 4000.
        /// </summary>
        public WORD caReferenceBlack;

        /// <summary>
        /// The white reference for the source colors.
        /// Any colors that are lighter than this are treated as white.
        /// The value must be in the range from 6000 to 10,000.
        /// </summary>
        public WORD caReferenceWhite;

        /// <summary>
        /// The amount of contrast to be applied to the source object.
        /// The value must be in the range from -100 to 100.
        /// A value of 0 means no contrast adjustment.
        /// </summary>
        public SHORT caContrast;

        /// <summary>
        /// The amount of brightness to be applied to the source object.
        /// The value must be in the range from -100 to 100.
        /// A value of 0 means no brightness adjustment.
        /// </summary>
        public SHORT caBrightness;

        /// <summary>
        /// The amount of colorfulness to be applied to the source object.
        /// The value must be in the range from -100 to 100.
        /// A value of 0 means no colorfulness adjustment.
        /// </summary>
        public SHORT caColorfulness;

        /// <summary>
        /// The amount of red or green tint adjustment to be applied to the source object.
        /// The value must be in the range from -100 to 100.
        /// Positive numbers adjust toward red and negative numbers adjust toward green. Zero means no tint adjustment.
        /// </summary>
        public SHORT caRedGreenTint;
    }
}
