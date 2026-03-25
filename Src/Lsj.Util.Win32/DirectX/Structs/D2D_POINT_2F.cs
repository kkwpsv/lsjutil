using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents an x-coordinate and y-coordinate pair, expressed as floating-point values, in two-dimensional space.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_point_2f"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D_POINT_2F
    {
        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        public FLOAT x;

        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        public FLOAT y;
    }
}
