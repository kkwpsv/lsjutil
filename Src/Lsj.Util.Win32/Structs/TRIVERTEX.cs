using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="TRIVERTEX"/> structure contains color information and position information.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-trivertex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// In the <see cref="TRIVERTEX"/> structure, x and y indicate position in the same manner
    /// as in the <see cref="POINTL"/> structure contained in the wtypes.h header file.
    /// <see cref="Red"/>, <see cref="Green"/>, <see cref="Blue"/>, and <see cref="Alpha"/> members indicate color information at the point x, y.
    /// The color information of each channel is specified as a value from 0x0000 to 0xff00.
    /// This allows higher color resolution for an object that has been split into small triangles for display.
    /// The <see cref="TRIVERTEX"/> structure contains information needed by the pVertex parameter of <see cref="GradientFill"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TRIVERTEX
    {
        /// <summary>
        /// The x-coordinate, in logical units, of the upper-left corner of the rectangle.
        /// </summary>
        public LONG x;

        /// <summary>
        /// The y-coordinate, in logical units, of the upper-left corner of the rectangle.
        /// </summary>
        public LONG y;

        /// <summary>
        /// The color information at the point of x, y.
        /// </summary>
        public COLOR16 Red;

        /// <summary>
        /// The color information at the point of x, y.
        /// </summary>
        public COLOR16 Green;

        /// <summary>
        /// The color information at the point of x, y.
        /// </summary>
        public COLOR16 Blue;

        /// <summary>
        /// The color information at the point of x, y.
        /// </summary>
        public COLOR16 Alpha;
    }
}
