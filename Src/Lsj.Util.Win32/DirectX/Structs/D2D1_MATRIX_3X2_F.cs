using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents a 3-by-2 matrix.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_matrix_3x2_f"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D2D1_MATRIX_3X2_F
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
