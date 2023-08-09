using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BITMAPFILEHEADER"/> structure contains information about the type, size, and layout of a file that contains a DIB.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-bitmapfileheader"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A <see cref="BITMAPINFO"/> or <see cref="BITMAPCOREINFO"/> structure immediately follows the <see cref="BITMAPFILEHEADER"/> structure in the DIB file.
    /// For more information, see Bitmap Storage.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 2)]
    public struct BITMAPFILEHEADER
    {
        /// <summary>
        /// The file type; must be BM.
        /// </summary>
        public WORD bfType;

        /// <summary>
        /// The size, in bytes, of the bitmap file.
        /// </summary>
        public DWORD bfSize;

        /// <summary>
        /// Reserved; must be zero.
        /// </summary>
        public WORD bfReserved1;

        /// <summary>
        /// Reserved; must be zero.
        /// </summary>
        public WORD bfReserved2;

        /// <summary>
        /// The offset, in bytes, from the beginning of the <see cref="BITMAPFILEHEADER"/> structure to the bitmap bits.
        /// </summary>
        public DWORD bfOffBits;
    }
}
