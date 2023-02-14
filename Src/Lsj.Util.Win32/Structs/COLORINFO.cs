using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.HTPatternSizes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="COLORINFO"/> structure defines a device's colors in CIE coordinate space.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winddi/ns-winddi-colorinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="LDECI4"/> type is used to represent real numbers to four decimal places.
    /// For example, (LDECI4) 10000 represents the real number 1.0000, and (LDECI4) -12345 represents -1.2345.
    /// For a monochrome printer, if you set the luminance for the Cyan member (that is, Cyan.Y) to 65534 (0xFFFE),
    /// you can select any of the available halftone pattern sizes.
    /// To select a halftone pattern size for a monochrome printer,
    /// set the <see cref="GDIINFO.ulHTPatternSize"/> member of the <see cref="GDIINFO"/> structure to the halftone pattern size that you want.
    /// If Cyan.Y is not set to 65534 (0xFFFE), halftone pattern sizes
    /// other than <see cref="HT_PATSIZE_8x8_M"/> or <see cref="HT_PATSIZE_8x8"/> are converted to <see cref="HT_PATSIZE_DEFAULT"/>.
    /// Setting the <see cref="RedGamma"/>, <see cref="BlueGamma"/>, and <see cref="GreenGamma"/> members of this structure
    /// to 0xFFFF can affect color management in printers when Image Color Management (ICM) is disabled.
    /// In this situation, the GDI halftone module switches from performing its own color management to performing none,
    /// which potentially can cause a significant change in the resulting printer output.
    /// When ICM is enabled (and <see cref="RedGamma"/>, <see cref="BlueGamma"/>, and <see cref="GreenGamma"/> are set to 0XFFFF),
    /// there is no difference in color output.
    /// For more information, see Color Management for Printers.
    /// Any values in the <see cref="COLORINFO"/> structure that are out of the specified range default to the NTSC values.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COLORINFO
    {
        /// <summary>
        /// 
        /// </summary>
        public CIECHROMA Red;

        /// <summary>
        /// 
        /// </summary>
        public CIECHROMA Green;

        /// <summary>
        /// 
        /// </summary>
        public CIECHROMA Blue;

        /// <summary>
        /// 
        /// </summary>
        public CIECHROMA Cyan;

        /// <summary>
        /// 
        /// </summary>
        public CIECHROMA Magenta;

        /// <summary>
        /// 
        /// </summary>
        public CIECHROMA Yellow;

        /// <summary>
        /// Specify <see cref="CIECHROMA"/> structures that each define the x-coordinate, y-coordinate, and Y-coordinate (luminance) of the named color.
        /// The <see cref="Cyan"/> member can have a special meaning for monochrome printers.
        /// Cyan.Y must be set to 65534 (0xFFFE) to enable all of the grayscale halftone pattern sizes.
        /// For more information, see the following Remarks section.
        /// </summary>
        public CIECHROMA AlignmentWhite;

        /// <summary>
        /// 
        /// </summary>
        public LDECI4 RedGamma;

        /// <summary>
        /// 
        /// </summary>
        public LDECI4 GreenGamma;

        /// <summary>
        /// Are the gamma corrections of display devices that permit the display device to display colors between the primary colors with accuracy.
        /// The values of these members should be in the range from 0 through 6.5535,
        /// which means that the numbers that are actually stored in these members must be in the range from 0 through 65535.
        /// For more information about these members and this data type, see the following Remarks section.
        /// </summary>
        public LDECI4 BlueGamma;

        /// <summary>
        /// 
        /// </summary>
        public LDECI4 MagentaInCyanDye;

        /// <summary>
        /// 
        /// </summary>
        public LDECI4 YellowInCyanDye;

        /// <summary>
        /// 
        /// </summary>
        public LDECI4 CyanInMagentaDye;

        /// <summary>
        /// 
        /// </summary>
        public LDECI4 YellowInMagentaDye;

        /// <summary>
        /// 
        /// </summary>
        public LDECI4 CyanInYellowDye;

        /// <summary>
        /// Used for printing devices to describe color purity and concentration.
        /// Values should be between zero and one, which means that the numbers actually stored in these members must be in the range 0 through 10000.
        /// For more information about this data type, see the following Remarks section.
        /// </summary>
        public LDECI4 MagentaInYellowDye;
    }
}
