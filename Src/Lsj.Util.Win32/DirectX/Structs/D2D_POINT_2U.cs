using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents an x-coordinate and y-coordinate pair, expressed as an unsigned 32-bit integer value, in two-dimensional space.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_point_2u"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D_POINT_2U
    {
        /// <summary>
        /// The x-coordinate value of the point.
        /// </summary>
        public UINT32 x;

        /// <summary>
        /// The y-coordinate value of the point.
        /// </summary>
        public UINT32 y;
    }
}
