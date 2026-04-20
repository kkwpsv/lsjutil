using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresources from an array of multi sampled 2D textures for a depth-stencil view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2dms_array_dsv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with a <see cref="D3D12_DEPTH_STENCIL_VIEW_DESC"/> structure to view the resource as an array of multi sampled 2D textures.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TEX2DMS_ARRAY_DSV
    {
        /// <summary>
        /// The index of the first texture to use in an array of textures.
        /// </summary>
        public UINT FirstArraySlice;

        /// <summary>
        /// The number of textures to use.
        /// </summary>
        public UINT ArraySize;
    }
}
