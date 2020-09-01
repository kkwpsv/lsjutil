using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="RGBQUAD"/> structure describes a color consisting of relative intensities of red, green, and blue.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-rgbquad
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure consists of an array of <see cref="RGBQUAD"/> structures.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RGBQUAD
    {
        /// <summary>
        /// The intensity of blue in the color.
        /// </summary>
        public BYTE rgbBlue;

        /// <summary>
        /// The intensity of green in the color.
        /// </summary>
        public BYTE rgbGreen;

        /// <summary>
        /// The intensity of red in the color.
        /// </summary>
        public BYTE rgbRed;

        /// <summary>
        /// This member is reserved and must be zero.
        /// </summary>
        public BYTE rgbReserved;
    }
}
