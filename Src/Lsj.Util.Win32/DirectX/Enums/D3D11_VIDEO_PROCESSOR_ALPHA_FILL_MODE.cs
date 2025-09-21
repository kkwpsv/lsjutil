using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the alpha fill mode for video processing.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_alpha_fill_mode"/>
    /// </para>
    /// </summary>
    public enum D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE
    {
        /// <summary>
        /// Alpha values inside the target rectangle are set to opaque.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE = 0,

        /// <summary>
        /// Alpha values inside the target rectangle are set to the alpha value specified in the background color.
        /// To set the background color, call the <see cref="ID3D11VideoContext.VideoProcessorSetOutputBackgroundColor"/> method.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_BACKGROUND = 1,

        /// <summary>
        /// Existing alpha values remain unchanged in the output surface.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_DESTINATION = 2,

        /// <summary>
        /// <para>
        /// Alpha values are taken from an input stream, scaled, and copied to the corresponding destination rectangle for that stream.
        /// The input stream is specified in the StreamIndex parameter of the <see cref="ID3D11VideoContext.VideoProcessorSetOutputAlphaFillMode"/> method.
        /// </para>
        /// <para>
        /// If the input stream does not have alpha data, the video processor sets the alpha values in the target rectangle to opaque.
        /// If the input stream is disabled or the source rectangle is empty, the alpha values in the target rectangle are not modified.
        /// </para>
        /// </summary>
        D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM = 3,
    }
}
