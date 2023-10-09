using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresource from a 2D texture to use in a render-target view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ns-d3d11_3-d3d11_tex2d_rtv1"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEX2D_RTV1
    {
        /// <summary>
        /// The index of the mipmap level to use mip slice.
        /// </summary>
        public UINT MipSlice;

        /// <summary>
        /// The index (plane slice number) of the plane to use in the texture.
        /// </summary>
        public UINT PlaneSlice;
    }
}
