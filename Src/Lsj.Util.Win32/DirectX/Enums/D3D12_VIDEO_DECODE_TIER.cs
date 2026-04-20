using static Lsj.Util.Win32.DirectX.Enums.D3D12_CPU_PAGE_PROPERTY;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_MEMORY_POOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_VIDEO_DECODE_CONFIGURATION_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_FLAGS;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the decoding tier of a hardware video decoder, which determines the required format of application-defined textures and buffers.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_decode_tier"/>
    /// </para>
    /// </summary>
    public enum D3D12_VIDEO_DECODE_TIER
    {
        /// <summary>
        /// Video decoding is not supported.
        /// </summary>
        D3D12_VIDEO_DECODE_TIER_NOT_SUPPORTED = 0,

        /// <summary>
        /// <para>
        /// In tier 1, the hardware decoder requires that the application allocate reference textures as a texture array.
        /// This is to accommodate hardware requirements that the textures be "close" in address space
        /// because the hardware doesn't support a full size pointer for each individual picture buffer.
        /// Instead it has one pointer and a more limited bit offset.
        /// For more information on texture arrays, see Introduction To Textures in Direct3D 11.
        /// </para>
        /// <para>
        /// If the decoder hardware requires a unique memory layout
        /// that is not supported for operations on other engines or different video operations,
        /// the decoder may set the <see cref="D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED"/>
        /// configuration flag in the <see cref="D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT"/> structure when queried for profile support.
        /// This flag indicates that the application must allocate references with the <see cref="D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY"/> flag.
        /// The application should use the <see cref="D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS"/> structure
        /// to set a reference-only output if the output is needed as a future reference frame.
        /// The output frame passed to <see cref="ID3D12VideoCommandList.DecodeFrame"/> is a D3D12 resource
        /// that can be consumed by other portions of the pipeline
        /// and must not have the <see cref="D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY"/> flag.
        /// </para>
        /// <para>
        /// #### Tier 1 requirements for compressed input buffers
        /// </para>
        /// <para>
        /// - All slices for a given frame must be placed in order and must be contiguous, i.e. there must be no gaps between slices.
        /// Slice control buffers must specify offset and size parameters that meet this requirement.
        /// </para>
        /// <para>
        /// - The first slice must begin on a 128 Byte boundary.
        /// The offset set in the <see cref="D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM"/> structure must be a multiple of 128 Bytes.
        /// </para>
        /// <para>
        /// - Decoding is supported from buffers allocated with <see cref="D3D12_MEMORY_POOL_L0"/>.
        /// This is always system memory, but still a D3D12 buffer.
        /// </para>
        /// <para>
        /// - Decoding is supported from buffers allocated with <see cref="D3D12_MEMORY_POOL_L1"/>,
        /// the default pool, including those allocated with <see cref="D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE"/>.
        /// </para>
        /// </summary>
        D3D12_VIDEO_DECODE_TIER_1 = 1,

        /// <summary>
        /// <para>
        /// In decode tier 2, textures can be referenced as a texture array
        /// or as an array of separate texture 2D resources (each resource having array size of 1).
        /// This is more flexible for the caller and is important in scenarios
        /// where the resolution changes frequently such as in streaming video,
        /// because a texture array can only be allocated and deallocated as a single unit,
        /// but separate texture 2D resources can be allocated and deallocated individually.
        /// </para>
        /// <para>
        /// If decode hardware requires a unique tiling format that is not supported
        /// for operations on other engines or different video operations,
        /// the decoder may set the <see cref="D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED"/> configuration flag
        /// in the <see cref="D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT"/> structure when queried for profile support.
        /// This flag indicates that the application must allocate references
        /// with the <see cref="D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY"/> flag.
        /// The application should use the <see cref="D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS"/> structure
        /// to set a reference only output if the output is needed as a future reference frame.
        /// The output frame passed to <see cref="ID3D12VideoCommandList.DecodeFrame"/> is a D3D12 resource
        /// that can be consumed by other portions of the pipeline
        /// and must not have the <see cref="D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY"/> flag.
        /// </para>
        /// <para>
        /// #### Tier 2 requirements for compressed input buffers
        /// </para>
        /// <para>
        /// These requirements are identical to the tier 1 requirements.
        /// </para>
        /// <para>
        /// - All slices for a given frame must be placed in order and must be contiguous, i.e. there must be no gaps between slices.
        /// Slice control buffers must specify offset and size parameters that meet this requirement.
        /// </para>
        /// <para>
        /// - The first slice must begin on a 128 Byte boundary.
        /// The offset set in the <see cref="D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM"/> structure must be a multiple of 128 Bytes.
        /// </para>
        /// <para>
        /// - Decoding is supported from buffers allocated with <see cref="D3D12_MEMORY_POOL_L0"/>.
        /// This is always system memory, but still a D3D12 buffer.
        /// </para>
        /// <para>
        /// - Decoding is supported from buffers allocated with <see cref="D3D12_MEMORY_POOL_L1"/>,
        /// the default pool, including those allocated with <see cref="D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE"/>.
        /// </para>
        /// </summary>
        D3D12_VIDEO_DECODE_TIER_2 = 2,

        /// <summary>
        /// This field is reserved.
        /// </summary>
        D3D12_VIDEO_DECODE_TIER_3 = 3
    }
}
