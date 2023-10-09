using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the subresources from an array of multisampled 2D textures for a depth-stencil view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2dms_array_dsv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is one member of a depth-stencil-view description (see <see cref="D3D11_DEPTH_STENCIL_VIEW_DESC"/>).
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEX2DMS_ARRAY_DSV
    {
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
