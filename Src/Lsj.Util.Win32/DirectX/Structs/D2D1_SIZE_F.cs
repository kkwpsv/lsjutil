using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Stores an ordered pair of floats, typically the width and height of a rectangle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/Direct2D/d2d1-size-f"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Like points, sizes are another important graphics concept.
    /// In Direct2D, sizes are represented by the <see cref="D2D1_SIZE_F"/> or <see cref="D2D1_SIZE_U"/> structures.
    /// Both contain an ordered pair of numbers, typically the width and height of a rectangle.
    /// The <see cref="D2D1_SIZE_F"/> structure contains an ordered pair of <see cref="FLOAT"/> values,
    /// and the <see cref="D2D1_SIZE_U"/> structure contains an ordered pair of <see cref="UINT32"/> values.
    /// </para>
    /// <para>
    /// <see cref="D2D1_SIZE_F"/> is a new name for an already defined type <see cref="D2D_SIZE_F"/>.
    /// For a list of the fields provided by <see cref="D2D1_SIZE_F"/>, see <see cref="D2D_SIZE_F"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_SIZE_F
    {
        /// <summary>
        /// The horizontal component of this size.
        /// </summary>
        public FLOAT width;

        /// <summary>
        /// The vertical component of this size.
        /// </summary>
        public FLOAT height;
    }
}
