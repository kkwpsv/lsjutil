using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.LCSCSTYPE;
using static Lsj.Util.Win32.Enums.LCSGAMUTMATCH;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="LOGCOLORSPACE"/> structure contains information that defines a logical color space.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-logcolorspacew"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Like palettes, but unlike pens and brushes, a pointer must be passed when creating a LogColorSpace.
    /// </para>
    /// <para>
    /// If the <see cref="lcsCSType"/> member is set to <see cref="LCS_sRGB"/> or <see cref="LCS_WINDOWS_COLOR_SPACE"/>,
    /// the other members of this structure are ignored, and WCS uses the sRGB color space.
    /// The <see cref="lcsEndpoints"/>, <see cref="lcsGammaRed"/>, <see cref="lcsGammaGreen"/>,
    /// and <see cref="lcsGammaBlue"/> members are used to describe the logical color space.
    /// The <see cref="lcsEndpoints"/> member is a <see cref="CIEXYZTRIPLE"/>
    /// that contains the x, y, and z values of the color space's RGB endpoint.
    /// </para>
    /// <para>
    /// The required DWORD bit format for the <see cref="lcsGammaRed"/>, <see cref="lcsGammaGreen"/>,
    /// and <see cref="lcsGammaBlue"/> is an 8.8 fixed point integer left-shifted by 8 bits.
    /// This means 8 integer bits are followed by 8 fraction bits.
    /// Taking the bit shift into account, the required format of the 32-bit DWORD is:
    /// </para>
    /// <para>
    /// 00000000nnnnnnnnffffffff00000000
    /// </para>
    /// <para>
    /// Whenever the <see cref="lcsFilename"/> member contains a file name
    /// and the <see cref="lcsCSType"/> member is set to <see cref="LCS_CALIBRATED_RGB"/>,
    /// WCS ignores the other members of this structure.
    /// It uses the color space in the file as the color space to which this <see cref="LOGCOLORSPACE"/> structure refers.
    /// </para>
    /// <para>
    /// The relation between tri-stimulus values X,Y,Z and chromaticity values x,y,z is as follows:
    /// </para>
    /// <para>
    /// x = X/(X+Y+Z)
    /// </para>
    /// <para>
    /// y = Y/(X+Y+Z)
    /// </para>
    /// <para>
    /// z = Z/(X+Y+Z)
    /// </para>
    /// <para>
    /// If the <see cref="lcsCSType"/> member is set to <see cref="LCS_sRGB"/> or <see cref="LCS_WINDOWS_COLOR_SPACE"/>,
    /// the other members of this structure are ignored, and ICM uses the sRGB color space.
    /// Applications should still initialize the rest of the structure
    /// since <see cref="CreateProfileFromLogColorSpace"/> ignores <see cref="lcsCSType"/> member
    /// and uses <see cref="lcsEndpoints"/>, <see cref="lcsGammaRed"/>,
    /// <see cref="lcsGammaGreen"/>, <see cref="lcsGammaBlue"/> members to create a profile,
    /// which may not be initialized in case of <see cref="LCS_sRGB"/> or <see cref="LCS_WINDOWS_COLOR_SPACE"/> color spaces.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOGCOLORSPACE
    {
        /// <summary>
        /// Color space signature.
        /// At present, this member should always be set to <see cref="LCS_SIGNATURE"/>.
        /// </summary>
        public DWORD lcsSignature;

        /// <summary>
        /// Version number; must be 0x400.
        /// </summary>
        public DWORD lcsVersion;

        /// <summary>
        /// Size of this structure, in bytes.
        /// </summary>
        public DWORD lcsSize;

        /// <summary>
        /// <para>
        /// Color space type.
        /// The member can be one of the following values.
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
        /// <see cref="LCS_CALIBRATED_RGB"/>
        /// </term>
        /// <term>
        /// Color values are calibrated RGB values.
        /// The values are translated using the endpoints specified by the <see cref="lcsEndpoints"/> member
        /// before being passed to the device.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LCS_sRGB"/>
        /// </term>
        /// <term>
        /// Color values are values are sRGB values.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LCS_WINDOWS_COLOR_SPACE"/>
        /// </term>
        /// <term>
        /// Color values are Windows default color space color values.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <see cref="LCS_CALIBRATED_RGB"/> is not specified,
        /// the <see cref="lcsEndpoints"/> member is ignored.
        /// </para>
        /// </summary>
        public LCSCSTYPE lcsCSType;

        /// <summary>
        /// <para>
        /// The gamut mapping method.
        /// This member can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Intent
        /// </term>
        /// <term>
        /// ICC Name
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="LCS_GM_ABS_COLORIMETRIC"/>
        /// </term>
        /// <term>
        /// Match
        /// </term>
        /// <term>
        /// Absolute Colorimetric
        /// </term>
        /// <term>
        /// Maintain the white point.
        /// Match the colors to their nearest color in the destination gamut.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LCS_GM_BUSINESS"/>
        /// </term>
        /// <term>
        /// Graphic
        /// </term>
        /// <term>
        /// Saturation
        /// </term>
        /// <term>
        /// Maintain saturation.
        /// Used for business charts and other situations in which undithered colors are required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LCS_GM_GRAPHICS"/>
        /// </term>
        /// <term>
        /// Proof
        /// </term>
        /// <term>
        /// Relative Colorimetric
        /// </term>
        /// <term>
        /// Maintain colorimetric match. Used for graphic designs and named colors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LCS_GM_IMAGES"/>
        /// </term>
        /// <term>
        /// Picture
        /// </term>
        /// <term>
        /// Perceptual
        /// </term>
        /// <term>
        /// Maintain contrast.
        /// Used for photographs and natural images.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public LCSGAMUTMATCH lcsIntent;

        /// <summary>
        /// Red, green, blue endpoints.
        /// </summary>
        public CIEXYZTRIPLE lcsEndpoints;

        /// <summary>
        /// Scale of the red coordinate.
        /// </summary>
        public DWORD lcsGammaRed;

        /// <summary>
        /// Scale of the green coordinate.
        /// </summary>
        public DWORD lcsGammaGreen;

        /// <summary>
        /// Scale of the blue coordinate.
        /// </summary>
        public DWORD lcsGammaBlue;

        /// <summary>
        /// A null-terminated string that names a color profile file.
        /// This member is typically set to zero,
        /// but may be used to set the color space to be exactly as specified by the color profile.
        /// This is useful for devices that input color values for a specific printer,
        /// or when using an installable image color matcher.
        /// If a color profile is specified, all other members of this structure should be set to reasonable values,
        /// even if the values are not completely accurate.
        /// </summary>
        public ByValStringStructForSizeMAX_PATH lcsFilename;
    }
}
