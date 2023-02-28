using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a matrix.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dmatrix"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// In Direct3D, the _34 element of a projection matrix cannot be a negative number.
    /// If your application needs to use a negative value in this location, it should scale the entire projection matrix by -1 instead.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DMATRIX
    {
        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _11;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _12;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _13;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _14;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _21;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _22;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _23;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _24;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _31;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _32;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _33;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _34;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _41;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _42;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _43;

        /// <summary>
        /// An array of floats that represent a 4x4 matrix, where i is the row number and j is the column number.
        /// For example, _34 means the same as [a₃₄], the component in the third row and fourth column.
        /// </summary>
        public float _44;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public unsafe ref D3DMATRIXRow this[int index]
        {
            get
            {
                fixed (void* thisPtr = &this)
                {
                    return ref *((D3DMATRIXRow*)thisPtr + index);
                }
            }
        }

        /// <summary>
        /// <see cref="D3DMATRIX"/> Row
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct D3DMATRIXRow
        {
            private float _1;
            private float _2;
            private float _3;
            private float _4;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public unsafe ref float this[int index]
            {
                get
                {
                    fixed (void* thisPtr = &this)
                    {
                        return ref *((float*)thisPtr + index);
                    }
                }
            }
        }
    }
}
