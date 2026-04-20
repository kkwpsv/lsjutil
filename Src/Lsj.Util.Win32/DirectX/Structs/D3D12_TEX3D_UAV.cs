using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a unordered-access 3D texture resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex3d_uav"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with a <see cref="D3D12_UNORDERED_ACCESS_VIEW_DESC"/> structure o view the resource as a 3D texture.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TEX3D_UAV
    {
        /// <summary>
        /// The mipmap slice index.
        /// </summary>
        public UINT MipSlice;

        /// <summary>
        /// The zero-based index of the first depth slice to be accessed.
        /// </summary>
        public UINT FirstWSlice;

        /// <summary>
        /// <para>
        /// The number of depth slices.
        /// </para>
        /// <para>
        /// Set to -1 to indicate all the depth slices from <see cref="FirstWSlice"/> to the last slice.
        /// </para>
        /// </summary>
        public UINT WSize;
    }
}
