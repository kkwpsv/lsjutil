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
    /// Specifies a YCbCr color value.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_color_ycbcra"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Values have a nominal range of [0...1].
    /// Given a format with n bits per channel, the value of each color component is calculated as follows:
    /// </para>
    /// <para>
    /// <c>val = f * ((1 &lt;&lt; n)-1)</c>
    /// </para>
    /// <para>
    /// For example, for 8-bit YUV formats, <c>val = BYTE(f * 255.0)</c>.
    /// Reference black is (0.0625, 0.5, 0.5), which corresponds to (16, 128, 128) in an 8-bit representation.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_COLOR_YCbCrA
    {
        /// <summary>
        /// The Y luma value.
        /// </summary>
        public float Y;

        /// <summary>
        /// The Cb chroma value.
        /// </summary>
        public float Cb;

        /// <summary>
        /// The Cr chroma value.
        /// </summary>
        public float Cr;

        /// <summary>
        /// The alpha value.
        /// Values range from 0 (transparent) to 1 (opaque).
        /// </summary>
        public float A;
    }
}
