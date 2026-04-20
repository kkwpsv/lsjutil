using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresources from an array of 1D textures to use in a render-target view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex1d_array_rtv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with a <see cref="D3D12_RENDER_TARGET_VIEW_DESC"/> structure to view the resource as an array of 1D textures.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TEX1D_ARRAY_RTV
    {
        /// <summary>
        /// The index of the mipmap level to use mip slice.
        /// </summary>
        public UINT MipSlice;

        /// <summary>
        /// The index of the first texture to use in an array of textures.
        /// </summary>
        public UINT FirstArraySlice;

        /// <summary>
        /// Number of textures to use.
        /// </summary>
        public UINT ArraySize;
    }
}
