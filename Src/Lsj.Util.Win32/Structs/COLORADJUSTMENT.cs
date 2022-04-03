using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="COLORADJUSTMENT"/> structure defines the color adjustment values
    /// used by the <see cref="StretchBlt"/> and <see cref="StretchDIBits"/> functions when the stretch mode is <see cref="HALFTONE"/>.
    /// You can set the color adjustment values by calling the <see cref="SetColorAdjustment"/> function.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COLORADJUSTMENT
    {
        /// <summary>
        /// The size, in bytes, of the structure.
        /// </summary>
        public WORD caSize;

        /// <summary>
        /// Specifies how the output image should be prepared.
        /// This member may be set to NULL or any combination of the following values.
        /// <see cref="CA_NEGATIVE"/>:
        /// Specifies that the negative of the original image should be displayed.
        /// <see cref="CA_LOG_FILTER"/>:
        /// Specifies that a logarithmic function should be applied to the final density of the output colors.
        /// This will increase the color contrast when the luminance is low.
        /// </summary>
        public WORD caFlags;

        /// <summary>
        /// The type of standard light source under which the image is viewed.
        /// This member may be set to one of the following values.
        /// <see cref="ILLUMINANT_DEVICE_DEFAULT"/>:
        /// Device's default. Standard used by output devices.
        /// <see cref="ILLUMINANT_A"/>:
        /// Tungsten lamp.
        /// <see cref="ILLUMINANT_B"/>:
        /// Noon sunlight.
        /// <see cref="ILLUMINANT_C"/>:
        /// NTSC daylight.
        /// <see cref="ILLUMINANT_D50"/>:
        /// Normal print.
        /// <see cref="ILLUMINANT_D55"/>:
        /// Bond paper print.
        /// <see cref="ILLUMINANT_D65"/>:
        /// Standard daylight. Standard for CRTs and pictures.
        /// <see cref="ILLUMINANT_D75"/>:
        /// Northern daylight.
        /// <see cref="ILLUMINANT_F2"/>:
        /// Cool white lamp.
        /// <see cref="ILLUMINANT_TUNGSTEN"/>:
        /// Same as <see cref="ILLUMINANT_A"/>.
        /// <see cref="ILLUMINANT_DAYLIGHT"/>:
        /// Same as <see cref="ILLUMINANT_C"/>.
        /// <see cref="ILLUMINANT_FLUORESCENT"/>:
        /// Same as <see cref="ILLUMINANT_F2"/>.
        /// <see cref="ILLUMINANT_NTSC"/>:
        /// Same as <see cref="ILLUMINANT_C"/>.
        /// </summary>
        public WORD caIlluminantIndex;

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
