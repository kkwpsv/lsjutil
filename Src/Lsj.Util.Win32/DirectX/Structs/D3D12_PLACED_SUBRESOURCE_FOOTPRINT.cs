using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the footprint of a placed subresource, including the offset and the <see cref="D3D12_SUBRESOURCE_FOOTPRINT"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_placed_subresource_footprint"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used in the <see cref="D3D12_TEXTURE_COPY_LOCATION"/> structure,
    /// and by <see cref="ID3D12Device.GetCopyableFootprints"/>.
    /// </para>
    /// <para>
    /// All the data referenced by the footprint structure must fit within the bounds of the parent resource.
    /// If you use <see cref="ID3D12Device.GetCopyableFootprints"/> to fill out the structure,
    /// the <c>pTotalBytes</c> output field indicates the required size of the resource.
    /// </para>
    /// <para>
    /// This structure is also used a number of helper functions (refer to Helper Structures and Functions for D3D12).
    /// </para>
    /// <para>
    /// When copying textures, use this structure along with <see cref="D3D12_TEXTURE_COPY_LOCATION"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_PLACED_SUBRESOURCE_FOOTPRINT
    {
        /// <summary>
        /// <para>
        /// The offset of the subresource within the parent resource, in bytes.
        /// The offset between the start of the parent resource and this subresource.
        /// </para>
        /// <para>
        /// This value must be aligned to <see cref="D3D12_TEXTURE_DATA_PLACEMENT_ALIGNMENT"/> (512)
        /// unless <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS13.UnrestrictedBufferTextureCopyPitchSupported"/> is <see cref="TRUE"/>.
        /// </para>
        /// </summary>
        public UINT64 Offset;

        /// <summary>
        /// The format, width, height, depth, and row-pitch of the subresource,
        /// as a <see cref="D3D12_SUBRESOURCE_FOOTPRINT"/> structure.
        /// </summary>
        public D3D12_SUBRESOURCE_FOOTPRINT Footprint;
    }
}
