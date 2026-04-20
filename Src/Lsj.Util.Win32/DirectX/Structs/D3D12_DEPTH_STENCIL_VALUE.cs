using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies a depth and stencil value.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_depth_stencil_value"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used in the <see cref="D3D12_CLEAR_VALUE"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_DEPTH_STENCIL_VALUE
    {
        /// <summary>
        /// Specifies the depth value.
        /// </summary>
        public FLOAT Depth;

        /// <summary>
        /// Specifies the stencil value.
        /// </summary>
        public UINT8 Stencil;
    }
}
