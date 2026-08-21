using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the extend modes and the interpolation mode of an <see cref="ID2D1BitmapBrush"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_bitmap_brush_properties"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_BITMAP_BRUSH_PROPERTIES
    {
        /// <summary>
        /// A value that describes how the brush horizontally tiles those areas that extend past its bitmap.
        /// </summary>
        public D2D1_EXTEND_MODE extendModeX;

        /// <summary>
        /// A value that describes how the brush vertically tiles those areas that extend past its bitmap.
        /// </summary>
        public D2D1_EXTEND_MODE extendModeY;

        /// <summary>
        /// A value that specifies how the bitmap is interpolated when it is scaled or rotated.
        /// </summary>
        public D2D1_BITMAP_INTERPOLATION_MODE interpolationMode;
    }
}
