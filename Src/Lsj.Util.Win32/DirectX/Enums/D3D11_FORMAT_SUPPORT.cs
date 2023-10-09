using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Which resources are supported for a given format and given device
    /// (see <see cref="ID3D11Device.CheckFormatSupport"/> and <see cref="ID3D11Device.CheckFeatureSupport"/>).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_format_support"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3D11_FORMAT_SUPPORT
    {
        /// <summary>
        /// Buffer resources supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_BUFFER = 0x1,

        /// <summary>
        /// Vertex buffers supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_IA_VERTEX_BUFFER = 0x2,

        /// <summary>
        /// Index buffers supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_IA_INDEX_BUFFER = 0x4,

        /// <summary>
        /// Streaming output buffers supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_SO_BUFFER = 0x8,

        /// <summary>
        /// 1D texture resources supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_TEXTURE1D = 0x10,

        /// <summary>
        /// 2D texture resources supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_TEXTURE2D = 0x20,

        /// <summary>
        /// 3D texture resources supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_TEXTURE3D = 0x40,

        /// <summary>
        /// Cube texture resources supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_TEXTURECUBE = 0x80,

        /// <summary>
        /// The HLSL Load function for texture objects is supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_SHADER_LOAD = 0x100,

        /// <summary>
        /// The HLSL Sample function for texture objects is supported.
        /// Note
        /// If the device supports the format as a resource (1D, 2D, 3D, or cube map) but doesn't support this option,
        /// the resource can still use the Sample method but must use only the point filtering sampler state to perform the sample.
        /// </summary>
        D3D11_FORMAT_SUPPORT_SHADER_SAMPLE = 0x200,

        /// <summary>
        /// The HLSL SampleCmp and SampleCmpLevelZero functions for texture objects are supported.
        /// Note
        /// Windows 8 and later might provide limited support for these functions on Direct3D feature levels 9_1, 9_2, and 9_3.
        /// For more info, see Implementing shadow buffers for Direct3D feature level 9.
        /// </summary>
        D3D11_FORMAT_SUPPORT_SHADER_SAMPLE_COMPARISON = 0x400,

        /// <summary>
        /// Reserved.
        /// </summary>
        D3D11_FORMAT_SUPPORT_SHADER_SAMPLE_MONO_TEXT = 0x800,

        /// <summary>
        /// Mipmaps are supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_MIP = 0x1000,
        D3D11_FORMAT_SUPPORT_MIP_AUTOGEN = 0x2000,
        D3D11_FORMAT_SUPPORT_RENDER_TARGET = 0x4000,
        D3D11_FORMAT_SUPPORT_BLENDABLE = 0x8000,
        D3D11_FORMAT_SUPPORT_DEPTH_STENCIL = 0x10000,
        D3D11_FORMAT_SUPPORT_CPU_LOCKABLE = 0x20000,
        D3D11_FORMAT_SUPPORT_MULTISAMPLE_RESOLVE = 0x40000,
        D3D11_FORMAT_SUPPORT_DISPLAY = 0x80000,
        D3D11_FORMAT_SUPPORT_CAST_WITHIN_BIT_LAYOUT = 0x100000,
        D3D11_FORMAT_SUPPORT_MULTISAMPLE_RENDERTARGET = 0x200000,
        D3D11_FORMAT_SUPPORT_MULTISAMPLE_LOAD = 0x400000,
        D3D11_FORMAT_SUPPORT_SHADER_GATHER = 0x800000,
        D3D11_FORMAT_SUPPORT_BACK_BUFFER_CAST = 0x1000000,
        D3D11_FORMAT_SUPPORT_TYPED_UNORDERED_ACCESS_VIEW = 0x2000000,
        D3D11_FORMAT_SUPPORT_SHADER_GATHER_COMPARISON = 0x4000000,
        D3D11_FORMAT_SUPPORT_DECODER_OUTPUT = 0x8000000,
        D3D11_FORMAT_SUPPORT_VIDEO_PROCESSOR_OUTPUT = 0x10000000,
        D3D11_FORMAT_SUPPORT_VIDEO_PROCESSOR_INPUT = 0x20000000,
        D3D11_FORMAT_SUPPORT_VIDEO_ENCODER = 0x40000000
    }
}
