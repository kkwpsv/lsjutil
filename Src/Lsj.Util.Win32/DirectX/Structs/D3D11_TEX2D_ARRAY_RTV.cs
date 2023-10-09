using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the subresources from an array of 2D textures to use in a render-target view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_array_rtv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is one member of a render-target-view description (see <see cref="D3D11_RENDER_TARGET_VIEW_DESC"/>).
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEX2D_ARRAY_RTV
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
        /// Number of textures in the array to use in the render target view, starting from <see cref="FirstArraySlice"/>.
        /// </summary>
        public UINT ArraySize;
    }
}
