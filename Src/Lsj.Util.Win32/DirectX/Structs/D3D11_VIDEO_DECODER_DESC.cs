using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a video stream for a Microsoft Direct3D 11 video decoder or video processor.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_decoder_desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_DECODER_DESC
    {
        /// <summary>
        /// The decoding profile.
        /// To get the list of profiles supported by the device, call the <see cref="ID3D11VideoDevice.GetVideoDecoderProfile"/> method.
        /// </summary>
        public GUID Guid;

        /// <summary>
        /// The width of the video frame, in pixels.
        /// </summary>
        public UINT SampleWidth;

        /// <summary>
        /// The height of the video frame, in pixels.
        /// </summary>
        public UINT SampleHeight;

        /// <summary>
        /// The output surface format, specified as a <see cref="DXGI_FORMAT"/> value.
        /// </summary>
        public DXGI_FORMAT OutputFormat;
    }
}
