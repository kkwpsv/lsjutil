using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies a type of compressed buffer for decoding.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_decoder_buffer_type"/>
    /// </para>
    /// </summary>
    public enum D3D11_VIDEO_DECODER_BUFFER_TYPE
    {
        /// <summary>
        /// Picture decoding parameter buffer.
        /// </summary>
        D3D11_VIDEO_DECODER_BUFFER_PICTURE_PARAMETERS = 0,

        /// <summary>
        /// Macroblock control command buffer.
        /// </summary>
        D3D11_VIDEO_DECODER_BUFFER_MACROBLOCK_CONTROL = 1,

        /// <summary>
        /// Residual difference block data buffer.
        /// </summary>
        D3D11_VIDEO_DECODER_BUFFER_RESIDUAL_DIFFERENCE = 2,

        /// <summary>
        /// Deblocking filter control command buffer.
        /// </summary>
        D3D11_VIDEO_DECODER_BUFFER_DEBLOCKING_CONTROL = 3,

        /// <summary>
        /// Inverse quantization matrix buffer.
        /// </summary>
        D3D11_VIDEO_DECODER_BUFFER_INVERSE_QUANTIZATION_MATRIX = 4,

        /// <summary>
        /// Slice-control buffer.
        /// </summary>
        D3D11_VIDEO_DECODER_BUFFER_SLICE_CONTROL = 5,

        /// <summary>
        /// Bitstream data buffer.
        /// </summary>
        D3D11_VIDEO_DECODER_BUFFER_BITSTREAM = 6,

        /// <summary>
        /// Motion vector buffer.
        /// </summary>
        D3D11_VIDEO_DECODER_BUFFER_MOTION_VECTOR = 7,

        /// <summary>
        /// Film grain synthesis data buffer.
        /// </summary>
        D3D11_VIDEO_DECODER_BUFFER_FILM_GRAIN = 8,

        /// <summary>
        /// 
        /// </summary>
        D3D11_VIDEO_DECODER_BUFFER_HUFFMAN_TABLE =9,
    }
}
