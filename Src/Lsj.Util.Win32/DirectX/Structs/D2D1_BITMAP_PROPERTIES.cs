using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the pixel format and dpi of a bitmap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_bitmap_properties"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_BITMAP_PROPERTIES
    {
        /// <summary>
        /// The bitmap's pixel format and alpha mode.
        /// </summary>
        public D2D1_PIXEL_FORMAT pixelFormat;

        /// <summary>
        /// The horizontal dpi of the bitmap.
        /// </summary>
        public FLOAT dpiX;

        /// <summary>
        /// The vertical dpi of the bitmap.
        /// </summary>
        public FLOAT dpiY;
    }
}
