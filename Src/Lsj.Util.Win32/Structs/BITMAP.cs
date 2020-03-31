using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BITMAP"/> structure defines the type, width, height, color format, and bit values of a bitmap.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-bitmap
    /// </para>
    /// </summary>
    /// <remarks>
    /// The bitmap formats currently used are monochrome and color.
    /// The monochrome bitmap uses a one-bit, one-plane format.
    /// Each scan is a multiple of 16 bits.
    /// Scans are organized as follows for a monochrome bitmap of height n:
    /// <code>
    /// Scan 0 
    /// Scan 1 
    /// . 
    /// . 
    /// . 
    /// Scan n-2 
    /// Scan n-1 
    /// </code>
    /// The pixels on a monochrome device are either black or white.
    /// If the corresponding bit in the bitmap is 1, the pixel is set to the foreground color;
    /// if the corresponding bit in the bitmap is zero, the pixel is set to the background color.
    /// All devices that have the <see cref="RC_BITBLT"/> device capability support bitmaps. For more information, see <see cref="GetDeviceCaps"/>.
    /// Each device has a unique color format.
    /// To transfer a bitmap from one device to another, use the <see cref="GetDIBits"/> and <see cref="SetDIBits"/> functions.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BITMAP
    {
        /// <summary>
        /// The bitmap type.
        /// This member must be zero.
        /// </summary>
        public LONG bmType;

        /// <summary>
        /// The width, in pixels, of the bitmap.
        /// The width must be greater than zero.
        /// </summary>
        public LONG bmWidth;

        /// <summary>
        /// The height, in pixels, of the bitmap.
        /// The height must be greater than zero.
        /// </summary>
        public LONG bmHeight;

        /// <summary>
        /// The number of bytes in each scan line.
        /// This value must be divisible by 2, because the system assumes that the bit values of a bitmap form an array that is word aligned.
        /// </summary>
        public LONG bmWidthBytes;

        /// <summary>
        /// The count of color planes.
        /// </summary>
        public WORD bmPlanes;

        /// <summary>
        /// The number of bits required to indicate the color of a pixel.
        /// </summary>
        public WORD bmBitsPixel;

        /// <summary>
        /// A pointer to the location of the bit values for the bitmap.
        /// The <see cref="bmBits"/> member must be a pointer to an array of character (1-byte) values.
        /// </summary>
        public LPVOID bmBits;
    }
}
