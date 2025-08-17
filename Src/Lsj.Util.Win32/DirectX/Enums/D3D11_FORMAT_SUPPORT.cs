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
        /// <para>
        /// The HLSL Sample function for texture objects is supported.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If the device supports the format as a resource (1D, 2D, 3D, or cube map) but doesn't support this option,
        /// the resource can still use the Sample method but must use only the point filtering sampler state to perform the sample.
        /// </para>
        /// </summary>
        D3D11_FORMAT_SUPPORT_SHADER_SAMPLE = 0x200,

        /// <summary>
        /// <para>
        /// The HLSL SampleCmp and SampleCmpLevelZero functions for texture objects are supported.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Windows 8 and later might provide limited support for these functions on Direct3D feature levels 9_1, 9_2, and 9_3.
        /// For more info, see Implementing shadow buffers for Direct3D feature level 9.
        /// </para>
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

        /// <summary>
        /// Automatic generation of mipmaps is supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_MIP_AUTOGEN = 0x2000,

        /// <summary>
        /// Render targets are supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_RENDER_TARGET = 0x4000,

        /// <summary>
        /// Blend operations supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_BLENDABLE = 0x8000,

        /// <summary>
        /// Depth stencils supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_DEPTH_STENCIL = 0x10000,

        /// <summary>
        /// CPU locking supported.
        /// </summary>
        D3D11_FORMAT_SUPPORT_CPU_LOCKABLE = 0x20000,

        /// <summary>
        /// Multisample antialiasing (MSAA) resolve operations are supported.
        /// For more info, see <see cref="ID3D11DeviceContext.ResolveSubresource"/>.
        /// </summary>
        D3D11_FORMAT_SUPPORT_MULTISAMPLE_RESOLVE = 0x40000,

        /// <summary>
        /// Format can be displayed on screen.
        /// </summary>
        D3D11_FORMAT_SUPPORT_DISPLAY = 0x80000,

        /// <summary>
        /// Format cannot be cast to another format.
        /// </summary>
        D3D11_FORMAT_SUPPORT_CAST_WITHIN_BIT_LAYOUT = 0x100000,

        /// <summary>
        /// Format can be used as a multisampled rendertarget.
        /// </summary>
        D3D11_FORMAT_SUPPORT_MULTISAMPLE_RENDERTARGET = 0x200000,

        /// <summary>
        /// Format can be used as a multisampled texture and read into a shader with the HLSL load function.
        /// </summary>
        D3D11_FORMAT_SUPPORT_MULTISAMPLE_LOAD = 0x400000,

        /// <summary>
        /// Format can be used with the HLSL gather function.
        /// This value is available in DirectX 10.1 or higher.
        /// </summary>
        D3D11_FORMAT_SUPPORT_SHADER_GATHER = 0x800000,

        /// <summary>
        /// Format supports casting when the resource is a back buffer.
        /// </summary>
        D3D11_FORMAT_SUPPORT_BACK_BUFFER_CAST = 0x1000000,

        /// <summary>
        /// Format can be used for an unordered access view.
        /// </summary>
        D3D11_FORMAT_SUPPORT_TYPED_UNORDERED_ACCESS_VIEW = 0x2000000,

        /// <summary>
        /// Format can be used with the HLSL gather with comparison function.
        /// </summary>
        D3D11_FORMAT_SUPPORT_SHADER_GATHER_COMPARISON = 0x4000000,

        /// <summary>
        /// <para>
        /// Format can be used with the decoder output.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_FORMAT_SUPPORT_DECODER_OUTPUT = 0x8000000,

        /// <summary>
        /// <para>
        /// Format can be used with the video processor output.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_FORMAT_SUPPORT_VIDEO_PROCESSOR_OUTPUT = 0x10000000,

        /// <summary>
        /// <para>
        /// Format can be used with the video processor input.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_FORMAT_SUPPORT_VIDEO_PROCESSOR_INPUT = 0x20000000,

        /// <summary>
        /// <para>
        /// Format can be used with the video encoder.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_FORMAT_SUPPORT_VIDEO_ENCODER = 0x40000000,
    }
}
