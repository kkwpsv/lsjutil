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
    /// Specifies an RGB color value.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_color_rgba"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The RGB values have a nominal range of [0...1].
    /// For an RGB format with n bits per channel, the value of each color component is calculated as follows:
    /// </para>
    /// <para>
    /// <c>val = f * ((1 &lt;&lt; n)-1)</c>
    /// </para>
    /// <para>
    /// For example, for RGB-32 (8 bits per channel), <c>val = BYTE(f * 255.0)</c>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_COLOR_RGBA
    {
        /// <summary>
        /// The red value.
        /// </summary>
        public float R;

        /// <summary>
        /// The green value.
        /// </summary>
        public float G;

        /// <summary>
        /// The blue value.
        /// </summary>
        public float B;

        /// <summary>
        /// The alpha value.
        /// Values range from 0 (transparent) to 1 (opaque).
        /// </summary>
        public float A;
    }
}
