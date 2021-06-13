using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CIECHROMA"/> structure is used to describe the chromaticity coordinates, x and y, and the luminance, Y in CIE color space.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winddi/ns-winddi-ciechroma"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="CIECHROMA"/> structure is used by the COLORINFO structure to define colors for GDIINFO.
    /// The <see cref="LDECI4"/> type is used to represent real numbers to four decimal places.
    /// For example, (LDECI4) 10000 represents the real number 1.0000, and (LDECI4) -12345 represents -1.2345.
    /// The values of the x and y members of <see cref="CIECHROMA"/> should be in the range from 0 through 10000--that is,
    /// the values should represent the numbers 0.0000 through 1.0000.
    /// The value of the Y member of this structure should be in the range from 0 through 100.
    /// This member can also be 65534 (0xFFFE) under certain circumstances.
    /// For more information about these circumstances, see <see cref="COLORINFO"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CIECHROMA
    {
        /// <summary>
        /// Specifies the x-coordinate in CIE chromaticity space.
        /// </summary>
        public LDECI4 x;

        /// <summary>
        /// Specifies the y-coordinate in CIE chromaticity space.
        /// </summary>
        public LDECI4 y;

        /// <summary>
        /// Specifies the luminance. For more information, see the following Remarks section.
        /// </summary>
        public LDECI4 Y;
    }
}
