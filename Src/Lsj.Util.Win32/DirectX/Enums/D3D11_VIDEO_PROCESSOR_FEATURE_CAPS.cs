using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_VIDEO_PROCESSOR_STEREO_FORMAT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines features that a Microsoft Direct3D 11 video processor can support.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_feature_caps"/>
    /// </para>
    /// </summary>
    public enum D3D11_VIDEO_PROCESSOR_FEATURE_CAPS
    {
        /// <summary>
        /// The video processor can set alpha values on the output pixels.
        /// For more information, see <see cref="ID3D11VideoContext.VideoProcessorSetOutputAlphaFillMode"/>.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_FILL = 0x1,

        /// <summary>
        /// The video processor can downsample the video output.
        /// For more information, see <see cref="ID3D11VideoContext.VideoProcessorSetOutputConstriction"/>.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_CONSTRICTION = 0x2,

        /// <summary>
        /// The video processor can perform luma keying.
        /// For more information, see <see cref="ID3D11VideoContext.VideoProcessorSetStreamLumaKey"/>.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LUMA_KEY = 0x4,

        /// <summary>
        /// The video processor can apply alpha values from color palette entries.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE = 0x8,

        /// <summary>
        /// <para>
        /// The driver does not support full video processing capabilities.
        /// If this capability flag is set, the video processor has the following limitations:
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// A maximum of two streams are supported:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The first stream must be either NV12 or YUY2.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The second stream must be AYUV, AI44, or IA44.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Image adjustment (proc amp) controls are applied to the entire video processing blit, rather than per stream.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Support for per-stream planar alpha is not reliable. (Per-pixel alpha is supported, however.)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LEGACY = 0x10,

        /// <summary>
        /// <para>
        /// The video processor can support 3D stereo video.
        /// For more information, see <see cref="ID3D11VideoContext.VideoProcessorSetStreamStereoFormat"/>.
        /// </para>
        /// <para>
        /// All drivers setting this caps must support the following stereo formats:
        /// <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_HORIZONTAL"/>, <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_VERTICAL"/>,
        /// and <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE"/>.
        /// </para>
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_STEREO = 0x20,

        /// <summary>
        /// The driver can rotate the input data either 90, 180, or 270 degrees clockwise as part of the video processing operation.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ROTATION = 0x40,

        /// <summary>
        /// The driver supports the <see cref="ID3D11VideoContext.VideoProcessorSetStreamAlpha"/> call.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_STREAM = 0x80,

        /// <summary>
        /// The driver supports the <see cref="ID3D11VideoContext.VideoProcessorSetStreamPixelAspectRatio"/> call.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_PIXEL_ASPECT_RATIO = 0x100,

        /// <summary>
        /// 
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_MIRROR = 0x200,

        /// <summary>
        /// 
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_SHADER_USAGE = 0x400,

        /// <summary>
        /// 
        /// </summary>
        D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_METADATA_HDR10 = 0x800
    }
}
