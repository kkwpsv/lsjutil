using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the rate at which the video processor produces output frames from an input stream.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_output_rate"/>
    /// </para>
    /// </summary>
    public enum D3D11_VIDEO_PROCESSOR_OUTPUT_RATE
    {
        /// <summary>
        /// The output is the normal frame rate.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_NORMAL = 0,

        /// <summary>
        /// The output is half the frame rate.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_HALF = 1,

        /// <summary>
        /// The output is a custom frame rate.
        /// </summary>
        D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM = 2,
    }
}
