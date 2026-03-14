using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_VIDEO_PROCESSOR_STEREO_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains stream-level data for the <see cref="ID3D11VideoContext.VideoProcessorBlt"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_stream"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the stereo 3D format is <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE"/>,
    /// the <see cref="ppPastSurfaces"/>, <see cref="pInputSurface"/>, and <see cref="ppFutureSurfaces"/> members contain the left view.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_PROCESSOR_STREAM
    {
        /// <para>
        /// Specifies whether this input stream is enabled.
        /// If the value is <see cref="TRUE"/>, the <see cref="ID3D11VideoContext.VideoProcessorBlt"/> method blits this stream to the output surface.
        /// Otherwise, this stream is not blitted.
        /// </para>
        /// <para>
        /// The maximum number of streams that can be enabled at one time
        /// is given in the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxInputStreams"/> member of the <see cref="D3D11_VIDEO_PROCESSOR_CAPS"/> structure.
        /// </para>
        public BOOL Enable;

        /// <summary>
        /// The zero-based index number of the output frame.
        /// </summary>
        public UINT OutputIndex;

        /// <summary>
        /// The zero-based index number of the input frame or field.
        /// </summary>
        public UINT InputFrameOrField;

        /// <summary>
        /// The number of past reference frames.
        /// </summary>
        public UINT PastFrames;

        /// <summary>
        /// The number of future reference frames.
        /// </summary>
        public UINT FutureFrames;

        /// <summary>
        /// A pointer to an array of <see cref="ID3D11VideoProcessorInputView"/> pointers, allocated by the caller.
        /// This array contains the past reference frames for the video processing operation.
        /// The number of elements in the array is equal to <see cref="PastFrames"/>.
        /// </summary>
        public P<P<ID3D11VideoProcessorInputView>> ppPastSurfaces;

        /// <summary>
        /// A pointer to the <see cref="ID3D11VideoProcessorInputView"/> interface of the surface that contains the current input frame.
        /// </summary>
        public P<ID3D11VideoProcessorInputView> pInputSurface;

        /// <summary>
        /// A pointer to an array of <see cref="ID3D11VideoProcessorInputView"/> pointers, allocated by the caller.
        /// This array contains the future reference frames for the video processing operation.
        /// The number of elements in the array is equal to <see cref="FutureFrames"/>.
        /// </summary>
        public P<P<ID3D11VideoProcessorInputView>> ppFutureSurfaces;

        /// <summary>
        /// <para>
        /// If the stereo 3D format is <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE"/>,
        /// this member points to an array that contains the past reference frames for the right view.
        /// The number of elements in the array is equal to <see cref="PastFrames"/>.
        /// </para>
        /// <para>
        /// For any other stereo 3D format, set this member to <see cref="NULL"/>.
        /// For more information, see <see cref="ID3D11VideoContext.VideoProcessorSetStreamStereoFormat"/>.
        /// </para>
        /// </summary>
        public P<P<ID3D11VideoProcessorInputView>> ppPastSurfacesRight;

        /// <summary>
        /// <para>
        /// If the stereo 3D format is <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE"/>,
        /// this member contains a pointer to the current input frame for the right view.
        /// </para>
        /// <para>
        /// For any other stereo 3D format, set this member to <see cref="NULL"/>.
        /// </para>
        /// </summary>
        public P<ID3D11VideoProcessorInputView> pInputSurfaceRight;

        /// <summary>
        /// <para>
        /// If the stereo 3D format is <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE"/>,
        /// this member points to an array that contains the future reference frames for the right view.
        /// The number of elements in the array is equal to <see cref="FutureFrames"/>.
        /// </para>
        /// <para>
        /// For any other stereo 3D format, set this member to <see cref="NULL"/>.
        /// </para>
        /// </summary>
        public P<P<ID3D11VideoProcessorInputView>> ppFutureSurfacesRight;
    }
}
