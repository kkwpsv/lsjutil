using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents a 3-by-2 matrix.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct2d/d2d1-matrix-3x2-f"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="D2D1_MATRIX_3X2"/> is a new name for the <see cref="D2D_MATRIX_3X2_F"/> structure.
    /// For a list of fields provided by the matrix, see <see cref="D2D_MATRIX_3X2_F"/>.
    /// </para>
    /// <para>
    /// To simplify common matrix operations, Direct2D provides the <c>D2D1.Matrix3x2F</c> class,
    /// which is derived from the <see cref="D2D_MATRIX_3X2_F"/> structure.
    /// The <c>Matrix3x2F</c> class provides a set of helper methods for performing common tasks,
    /// such as creating a translation or skew matrix.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D2D_MATRIX_3X2_F
    {
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public FLOAT m11;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public FLOAT m12;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(8)]
        public FLOAT m21;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(12)]
        public FLOAT m22;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(16)]
        public FLOAT dx;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(20)]
        public FLOAT dy;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public FLOAT _11;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public FLOAT _12;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(8)]
        public FLOAT _21;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(12)]
        public FLOAT _22;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(16)]
        public FLOAT _31;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(20)]
        public FLOAT _32;
    }
}
