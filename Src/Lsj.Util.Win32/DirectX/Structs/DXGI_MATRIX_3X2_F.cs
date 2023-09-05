using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents a 3x2 matrix.
    /// Used with <see cref="IDXGISwapChain2.GetMatrixTransform"/> and <see cref="IDXGISwapChain2.SetMatrixTransform"/>
    /// to indicate the scaling and translation transform for SwapChainPanel swap chains.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/ns-dxgi1_3-dxgi_matrix_3x2_f"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_MATRIX_3X2_F
    {
        /// <summary>
        /// The value in the first row and first column of the matrix.
        /// </summary>
        public FLOAT _11;

        /// <summary>
        /// The value in the first row and second column of the matrix.
        /// </summary>
        public FLOAT _12;

        /// <summary>
        /// The value in the second row and first column of the matrix.
        /// </summary>
        public FLOAT _21;

        /// <summary>
        /// The value in the second row and second column of the matrix.
        /// </summary>
        public FLOAT _22;

        /// <summary>
        /// The value in the third row and first column of the matrix.
        /// </summary>
        public FLOAT _31;

        /// <summary>
        /// The value in the third row and second column of the matrix.
        /// </summary>
        public FLOAT _32;
    }
}
