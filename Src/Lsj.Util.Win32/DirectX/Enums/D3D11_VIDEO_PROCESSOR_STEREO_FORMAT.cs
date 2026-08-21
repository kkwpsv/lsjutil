using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_VIDEO_PROCESSOR_FEATURE_CAPS;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the layout in memory of a stereo 3D video frame.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_stereo_format"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enumeration designates the two stereo views as "frame 0" and "frame 1".
    /// The LeftViewFrame0 parameter of the <see cref="ID3D11VideoContext.VideoProcessorSetStreamStereoFormat"/> method
    /// specifies which view is the left view, and which is the right view.
    /// </para>
    /// <para>
    /// For packed formats, if the source rectangle clips part of the surface,
    /// the driver interprets the rectangle in logical coordinates relative to the stereo view, rather than absolute pixel coordinates.
    /// The result is that frame 0 and frame 1 are clipped proportionately.
    /// </para>
    /// <para>
    /// To query whether the device supports stereo 3D video, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
    /// and check for the <see cref="D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_STEREO"/> flag
    /// in the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.FeatureCaps"/> member of the <see cref="D3D11_VIDEO_PROCESSOR_CAPS"/> structure.
    /// If this capability flag is present, it means that the driver supports all of the stereo formats that are not listed as optional.
    /// To find out which optional formats are supported, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
    /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.StereoCaps"/> member of the structure.
    /// </para>
    /// </remarks>
    public enum D3D11_VIDEO_PROCESSOR_STEREO_FORMAT
    {
        /// <summary>
        /// The sample does not contain stereo data. If the stereo format is not specified, this value is the default.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO = 0,

        /// <summary>
        /// <para>
        /// Frame 0 and frame 1 are packed side-by-side, as shown in the following diagram.
        /// </para>
        /// <para>
        /// All drivers that support stereo video must support this format.
        /// </para>
        /// </summary>
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_HORIZONTAL = 1,

        /// <summary>
        /// <para>
        /// Frame 0 and frame 1 are packed top-to-bottom, as shown in the following diagram.
        /// </para>
        /// <para>
        /// All drivers that support stereo video must support this format.
        /// </para>
        /// </summary>
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_VERTICAL = 2,

        /// <summary>
        /// <para>
        /// Frame 0 and frame 1 are placed in separate resources or in separate texture array elements within the same resource.
        /// </para>
        /// <para>
        /// All drivers that support stereo video must support this format.
        /// </para>
        /// </summary>
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE = 3,

        /// <summary>
        /// <para>
        /// The sample contains non-stereo data. However, the driver should create a left/right output of this sample using a specified offset.
        /// The offset is specified in the MonoOffset parameter of the <see cref="ID3D11VideoContext.VideoProcessorSetStreamStereoFormat"/> method.
        /// </para>
        /// <para>
        /// This format is primarily intended for subtitles and other subpicture data, where the entire sample is presented on the same plane.
        /// </para>
        /// <para>
        /// Support for this stereo format is optional.
        /// </para>
        /// </summary>
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET = 4,

        /// <para>
        /// Frame 0 and frame 1 are packed into interleaved rows, as shown in the following diagram.
        /// </para>
        /// <para>
        /// Support for this stereo format is optional.
        /// </para>
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_ROW_INTERLEAVED = 5,

        /// <para>
        /// Frame 0 and frame 1 are packed into interleaved columns, as shown in the following diagram.
        /// </para>
        /// <para>
        /// Support for this stereo format is optional.
        /// </para>
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_COLUMN_INTERLEAVED = 6,

        /// <para>
        /// Frame 0 and frame 1 are packed in a checkerboard format, as shown in the following diagram.
        /// </para>
        /// <para>
        /// Support for this stereo format is optional.
        /// </para>
        D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_CHECKERBOARD = 7,
    }
}
