using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="RGBTRIPLE"/> structure describes a color consisting of relative intensities of red, green, and blue.
    /// The <see cref="BITMAPCOREINFO.bmciColors"/> member of the <see cref="BITMAPCOREINFO"/> structure
    /// consists of an array of <see cref="RGBTRIPLE"/> structures.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RGBTRIPLE
    {
        /// <summary>
        /// The intensity of blue in the color.
        /// </summary>
        public BYTE rgbtBlue;

        /// <summary>
        /// The intensity of green in the color.
        /// </summary>
        public BYTE rgbtGreen;

        /// <summary>
        /// The intensity of red in the color.
        /// </summary>
        public BYTE rgbtRed;
    }
}
