using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a video stream for a video processor.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_content_desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_PROCESSOR_CONTENT_DESC
    {
        /// <summary>
        /// A member of the <see cref="D3D11_VIDEO_FRAME_FORMAT"/> enumeration
        /// that describes how the video stream is interlaced.
        /// </summary>
        public D3D11_VIDEO_FRAME_FORMAT InputFrameFormat;

        /// <summary>
        /// The frame rate of the input video stream,
        /// specified as a <see cref="DXGI_RATIONAL"/> structure.
        /// </summary>
        public DXGI_RATIONAL InputFrameRate;

        /// <summary>
        /// The width of the input frames, in pixels.
        /// </summary>
        public UINT InputWidth;

        /// <summary>
        /// The height of the input frames, in pixels.
        /// </summary>
        public UINT InputHeight;

        /// <summary>
        /// The frame rate of the output video stream,
        /// specified as a <see cref="DXGI_RATIONAL"/> structure.
        /// </summary>
        public DXGI_RATIONAL OutputFrameRate;

        /// <summary>
        /// The width of the output frames, in pixels.
        /// </summary>
        public UINT OutputWidth;

        /// <summary>
        /// The height of the output frames, in pixels.
        /// </summary>
        public UINT OutputHeight;

        /// <summary>
        /// A member of the <see cref="D3D11_VIDEO_USAGE"/> enumeration
        /// that describes how the video processor will be used.
        /// The value indicates the desired trade-off between speed and video quality.
        /// The driver uses this flag as a hint when it creates the video processor.
        /// </summary>
        public D3D11_VIDEO_USAGE Usage;
    }
}
