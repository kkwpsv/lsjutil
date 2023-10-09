using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a unordered-access 2D texture resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_uav"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by a <see cref="D3D11_UNORDERED_ACCESS_VIEW_DESC"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEX2D_UAV
    {
        /// <summary>
        /// The mipmap slice index.
        /// </summary>
        public UINT MipSlice;
    }
}
