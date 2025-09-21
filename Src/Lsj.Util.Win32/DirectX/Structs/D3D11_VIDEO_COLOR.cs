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
    /// Defines a color value for Microsoft Direct3D 11 video.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_color"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The anonymous union can represent both RGB and YCbCr colors.
    /// The interpretation of the union depends on the context.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_COLOR
    {
        /// <summary>
        /// A <see cref="D3D11_VIDEO_COLOR_YCbCrA"/> structure that contains a YCbCr color value.
        /// </summary>
        [FieldOffset(0)]
        public D3D11_VIDEO_COLOR_YCbCrA YCbCr;

        /// <summary>
        /// A <see cref="D3D11_VIDEO_COLOR_RGBA"/> structure that contains an RGB color value.
        /// </summary>
        [FieldOffset(0)]
        public D3D11_VIDEO_COLOR_RGBA RGBA;
    }
}
