using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a unordered-access 2D texture resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2d_uav"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with a <see cref="D3D12_UNORDERED_ACCESS_VIEW_DESC"/> structure to view the resource as a 2D texture.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TEX2D_UAV
    {
        /// <summary>
        /// The mipmap slice index.
        /// </summary>
        public UINT MipSlice;

        /// <summary>
        /// The index (plane slice number) of the plane to use in the texture.
        /// </summary>
        public UINT PlaneSlice;
    }
}
