using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Identifies the texture resource for a video processor input view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_vpiv"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEX2D_VPIV
    {
        /// <summary>
        /// The zero-based index into the array of subtextures.
        /// </summary>
        public UINT MipSlice;

        /// <summary>
        /// The zero-based index of the texture.
        /// </summary>
        public UINT ArraySlice;
    }
}
