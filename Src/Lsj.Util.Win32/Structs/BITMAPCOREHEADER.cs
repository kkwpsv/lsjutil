using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BITMAPCOREHEADER"/> structure contains information about the dimensions and color format of a DIB.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-bitmapcoreheader"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="BITMAPCOREINFO"/> structure combines the <see cref="BITMAPCOREHEADER"/> structure and a color table
    /// to provide a complete definition of the dimensions and colors of a DIB.
    /// For more information about specifying a DIB, see <see cref="BITMAPCOREINFO"/>.
    /// An application should use the information stored in the <see cref="bcSize"/> member
    /// to locate the color table in a <see cref="BITMAPCOREINFO"/> structure, using a method such as the following:
    /// <code>
    /// pColor = ((LPBYTE) pBitmapCoreInfo + (WORD) (pBitmapCoreInfo -&gt; bcSize)) 
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BITMAPCOREHEADER
    {
        /// <summary>
        /// The number of bytes required by the structure.
        /// </summary>
        public DWORD bcSize;

        /// <summary>
        /// The width of the bitmap, in pixels.
        /// </summary>
        public WORD bcWidth;

        /// <summary>
        /// The height of the bitmap, in pixels.
        /// </summary>
        public WORD bcHeight;

        /// <summary>
        /// The number of planes for the target device. This value must be 1.
        /// </summary>
        public WORD bcPlanes;

        /// <summary>
        /// The number of bits-per-pixel. This value must be 1, 4, 8, or 24.
        /// </summary>
        public WORD bcBitCount;
    }
}
