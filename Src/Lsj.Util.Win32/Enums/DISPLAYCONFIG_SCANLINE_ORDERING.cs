using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_SCANLINE_ORDERING"/> enumeration specifies the method that the display uses to create an image on a screen.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ne-wingdi-displayconfig_scanline_ordering"/>
    /// </para>
    /// </summary>
    public enum DISPLAYCONFIG_SCANLINE_ORDERING
    {
        /// <summary>
        /// Indicates that scan-line ordering of the output is unspecified.
        /// The caller can only set the <see cref="DISPLAYCONFIG_PATH_TARGET_INFO.scanLineOrdering"/> member
        /// of the <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> structure
        /// in a call to the <see cref="SetDisplayConfig"/> function to <see cref="DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED"/>
        /// if the caller also set the refresh rate denominator
        /// and numerator of the <see cref="DISPLAYCONFIG_PATH_TARGET_INFO.refreshRate"/> member both to zero.
        /// In this case, SetDisplayConfig uses the best refresh rate it can find.
        /// </summary>
        DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED = 0,

        /// <summary>
        /// Indicates that the output is a progressive image.
        /// </summary>
        DISPLAYCONFIG_SCANLINE_ORDERING_PROGRESSIVE = 1,

        /// <summary>
        /// Indicates that the output is an interlaced image that is created beginning with the upper field.
        /// </summary>
        DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED = 2,

        /// <summary>
        /// Indicates that the output is an interlaced image that is created beginning with the upper field.
        /// </summary>
        DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_UPPERFIELDFIRST,

        /// <summary>
        /// Indicates that the output is an interlaced image that is created beginning with the lower field.
        /// </summary>
        DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_LOWERFIELDFIRST = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// You should not use this value.
        /// </summary>
        DISPLAYCONFIG_SCANLINE_ORDERING_FORCE_UINT32 = unchecked((int)0xFFFFFFFF),
    }
}
