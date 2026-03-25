using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the center point, x-radius, and y-radius of an ellipse.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_ellipse"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_ELLIPSE
    {
        /// <summary>
        /// The center point of the ellipse.
        /// </summary>
        public D2D1_POINT_2F point;

        /// <summary>
        /// The X-radius of the ellipse.
        /// </summary>
        public FLOAT radiusX;

        /// <summary>
        /// The Y-radius of the ellipse.
        /// </summary>
        public FLOAT radiusY;
    }
}
