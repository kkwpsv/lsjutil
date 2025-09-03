using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a video decoder output view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_decoder_output_view_desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC
    {
        /// <summary>
        /// The decoding profile.
        /// To get the list of profiles supported by the device,
        /// call the <see cref="ID3D11VideoDevice.GetVideoDecoderProfile"/> method.
        /// </summary>
        public GUID DecodeProfile;

        /// <summary>
        /// The resource type of the view,
        /// specified as a member of the <see cref="D3D11_VDOV_DIMENSION"/> enumeration.
        /// </summary>
        public D3D11_VDOV_DIMENSION ViewDimension;

        /// <summary>
        /// A <see cref="D3D11_TEX2D_VDOV"/> structure that identifies the texture resource for the output view.
        /// </summary>
        public D3D11_TEX2D_VDOV Texture2D;
    }
}
