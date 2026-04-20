using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresources from a 3D texture to use in a render-target view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex3d_rtv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with a <see cref="D3D12_RENDER_TARGET_VIEW_DESC"/> structure to view the resource as a 3D texture.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TEX3D_RTV
    {
        /// <summary>
        /// The index of the mipmap level to use mip slice.
        /// </summary>
        public UINT MipSlice;

        /// <summary>
        /// First depth level to use.
        /// </summary>
        public UINT FirstWSlice;

        /// <summary>
        /// Number of depth levels to use in the render-target view, starting from <see cref="FirstWSlice"/>.
        /// A value of -1 indicates all of the slices along the w axis, starting from <see cref="FirstWSlice"/>.
        /// </summary>
        public UINT WSize;
    }
}
