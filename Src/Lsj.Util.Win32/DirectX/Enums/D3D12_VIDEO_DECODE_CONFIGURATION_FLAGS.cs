using System;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_VIDEO_DECODE_TIER;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the configuration for video decoding.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_decode_configuration_flags"/>
    /// </para>
    /// </summary>
    [Flags]
   public enum D3D12_VIDEO_DECODE_CONFIGURATION_FLAGS
    {
        /// <summary>
        /// No configuration flags.
        /// </summary>
        D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_NONE = 0,

        /// <summary>
        /// The height of the output decoded surfaces must be a multiple of 32.
        /// </summary>
        D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_HEIGHT_ALIGNMENT_MULTIPLE_32_REQUIRED = 0x1,

        /// <summary>
        /// The driver supports post processing.
        /// If this flag is set, the host decoder can set up post-processing
        /// by using the conversion flags in the <see cref="D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS"/>.
        /// </summary>
        D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_POST_PROCESSING_SUPPORTED = 0x2,

        /// <summary>
        /// Reference resources must be allocated with the <see cref="D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY"/> resource flag.
        /// References textures must be separate from output textures, similar to performing a format conversion or downscale.
        /// This flag must not be set for <see cref="D3D12_VIDEO_DECODE_TIER_3"/> or greater.
        /// </summary>
        D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED = 0x4,

        /// <summary>
        /// The decode resolution can be changed on a non-key frame.
        /// </summary>
        D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_ALLOW_RESOLUTION_CHANGE_ON_NON_KEY_FRAME = 0x8
    }
}
