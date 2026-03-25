using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents an x-coordinate and y-coordinate pair in two-dimensional space.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/Direct2D/d2d1-point-2f"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Points in Direct2D are represented by the <see cref="D2D1_POINT_2F"/> or <see cref="D2D1_POINT_2U"/> structures.
    /// Both contain an x-coordinate and y-coordinate pair in two-dimensional space.
    /// The <see cref="D2D1_POINT_2F"/> structure stores the coordinates as <see cref="FLOAT"/> values,
    /// and the <see cref="D2D1_POINT_2U"/> structure stores them as <see cref="UINT32"/> values.
    /// </para>
    /// <para>
    /// <see cref="D2D1_POINT_2F"/> is a new name for the already defined type <see cref="D2D_POINT_2F"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_POINT_2F
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
