using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies resources that are supported for a provided format.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_format_support1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_FEATURE_DATA_FORMAT_SUPPORT"/> structure.
    /// </remarks>
    [Flags]
    public enum D3D12_FORMAT_SUPPORT1
    {
        /// <summary>
        /// No resources are supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_NONE = 0,

        /// <summary>
        /// Buffer resources supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_BUFFER = 0x1,

        /// <summary>
        /// Vertex buffers supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_IA_VERTEX_BUFFER = 0x2,

        /// <summary>
        /// Index buffers supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_IA_INDEX_BUFFER = 0x4,

        /// <summary>
        /// Streaming output buffers supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_SO_BUFFER = 0x8,

        /// <summary>
        /// 1D texture resources supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_TEXTURE1D = 0x10,

        /// <summary>
        /// 2D texture resources supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_TEXTURE2D = 0x20,

        /// <summary>
        /// 3D texture resources supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_TEXTURE3D = 0x40,

        /// <summary>
        /// Cube texture resources supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_TEXTURECUBE = 0x80,

        /// <summary>
        /// The HLSL <c>Load</c> function for texture objects is supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_SHADER_LOAD = 0x100,

        /// <para>
        /// The HLSL <c>Sample</c> function for texture objects is supported.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If the device supports the format as a resource (1D, 2D, 3D, or cube map) but doesn't support this option,
        /// the resource can still use the <c>Sample</c> method but must use only the point filtering sampler state to perform the sample.
        /// </para>
        D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE = 0x200,

        /// <summary>
        /// <para>
        /// The HLSL <c>SampleCmp</c> and <c>SampleCmpLevelZero</c> functions for texture objects are supported.
        /// </para>
        /// <para>
        /// Note  Windows 8 and later might provide limited support for these functions on Direct3D feature levels 9_1, 9_2, and 9_3.
        /// For more info, see Implementing shadow buffers for Direct3D feature level 9.
        /// </para>
        /// </summary>
        D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE_COMPARISON = 0x400,

        /// <summary>
        /// Reserved.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE_MONO_TEXT = 0x800,

        /// <summary>
        /// Mipmaps are supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_MIP = 0x1000,

        /// <summary>
        /// Render targets are supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_RENDER_TARGET = 0x4000,

        /// <summary>
        /// Blend operations supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_BLENDABLE = 0x8000,

        /// <summary>
        /// Depth stencils supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_DEPTH_STENCIL = 0x10000,

        /// <summary>
        /// Multisample antialiasing (MSAA) resolve operations are supported.
        /// For more info, see <see cref="ID3D12GraphicsCommandList.ResolveSubresource"/>.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_MULTISAMPLE_RESOLVE = 0x40000,

        /// <summary>
        /// Format can be displayed on screen.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_DISPLAY = 0x80000,

        /// <summary>
        /// Format can be cast to another format.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_CAST_WITHIN_BIT_LAYOUT = 0x100000,

        /// <summary>
        /// Format can be used as a multi-sampled render target.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_MULTISAMPLE_RENDERTARGET = 0x200000,

        /// <summary>
        /// Format can be used as a multi-sampled texture and read into a shader with the HLSL <c>Load</c> function.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_MULTISAMPLE_LOAD = 0x400000,

        /// <summary>
        /// Format can be used with the HLSL gather function. This value is available in DirectX 10.1 or higher.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_SHADER_GATHER = 0x800000,

        /// <summary>
        /// Format supports casting when the resource is a back buffer.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_BACK_BUFFER_CAST = 0x1000000,

        /// <summary>
        /// Format can be used for an unordered access view.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_TYPED_UNORDERED_ACCESS_VIEW = 0x2000000,

        /// <summary>
        /// Format can be used with the HLSL gather with comparison function.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_SHADER_GATHER_COMPARISON = 0x4000000,

        /// <summary>
        /// Format can be used with the decoder output.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_DECODER_OUTPUT = 0x8000000,

        /// <summary>
        /// Format can be used with the video processor output.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_VIDEO_PROCESSOR_OUTPUT = 0x10000000,

        /// <summary>
        /// Format can be used with the video processor input.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_VIDEO_PROCESSOR_INPUT = 0x20000000,

        /// <summary>
        /// Format can be used with the video encoder.
        /// </summary>
        D3D12_FORMAT_SUPPORT1_VIDEO_ENCODER = 0x40000000
    }
}
