using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes an array of unordered-access 2D texture resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2d_array_uav"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with a <see cref="D3D12_UNORDERED_ACCESS_VIEW_DESC"/> structure to view the resource as an array of 2D textures.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TEX2D_ARRAY_UAV
    {
        /// <summary>
        /// The mipmap slice index.
        /// </summary>
        public UINT MipSlice;

        /// <summary>
        /// The zero-based index of the first array slice to be accessed.
        /// </summary>
        public UINT FirstArraySlice;

        /// <summary>
        /// The number of slices in the array.
        /// </summary>
        public UINT ArraySize;

        /// <summary>
        /// The index (plane slice number) of the plane to use in an array of textures.
        /// </summary>
        public UINT PlaneSlice;
    }
}
