namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies how to bind a resource to the pipeline.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_bind_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// In general, binding flags can be combined using a bitwise OR (except the constant-buffer flag);
    /// however, you should use a single flag to allow the device to optimize the resource usage.
    /// This enumeration is used by a:
    /// Buffer description when creating a buffer.
    /// Texture description when creating a texture (see <see cref="D3D11_TEXTURE1D_DESC"/> or <see cref="D3D11_TEXTURE2D_DESC"/> or <see cref="D3D11_TEXTURE3D_DESC"/>).
    /// A shader-resource buffer is NOT a constant buffer; rather, it is a texture or buffer resource that is bound to a shader,
    /// that contains texture or buffer data (it is not limited to a single element type in the buffer).
    /// A shader-resource buffer is created with the <see cref="D3D11_BIND_SHADER_RESOURCE"/> flag and is bound to the pipeline using one of these APIs:
    /// <see cref="ID3D11DeviceContext.GSSetShaderResources"/>, <see cref="ID3D11DeviceContext.PSSetShaderResources"/>, or <see cref="ID3D11DeviceContext.VSSetShaderResources"/>.
    /// Furthermore, a shader-resource buffer cannot use the <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/> flag.
    /// Note
    /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
    /// enables mapping dynamic constant buffers and shader resource views (SRVs) of dynamic buffers with <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/>.
    /// The Direct3D 11 and earlier runtimes limited mapping to vertex or index buffers.
    /// To determine if a Direct3D device supports these features, call <see cref="ID3D11Device.CheckFeatureSupport"/> with <see cref="D3D11_FEATURE_D3D11_OPTIONS"/>.
    /// <see cref="ID3D11Device.CheckFeatureSupport"/> fills members of a <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS"/> structure with the device's features.
    /// The relevant members here are <see cref="MapNoOverwriteOnDynamicConstantBuffer"/> and <see cref="MapNoOverwriteOnDynamicBufferSRV"/>.
    /// </remarks>
    public enum D3D11_BIND_FLAG : uint
    {
        /// <summary>
        /// Bind a buffer as a vertex buffer to the input-assembler stage.
        /// </summary>
        D3D11_BIND_VERTEX_BUFFER = 0x1,

        /// <summary>
        /// Bind a buffer as an index buffer to the input-assembler stage.
        /// </summary>
        D3D11_BIND_INDEX_BUFFER = 0x2,

        /// <summary>
        /// Bind a buffer as a constant buffer to a shader stage; this flag may NOT be combined with any other bind flag.
        /// </summary>
        D3D11_BIND_CONSTANT_BUFFER = 0x4,

        /// <summary>
        /// Bind a buffer or texture to a shader stage; this flag cannot be used with the <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/> flag.
        /// Note
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// enables mapping dynamic constant buffers and shader resource views (SRVs) of dynamic buffers with <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/>.
        /// The Direct3D 11 and earlier runtimes limited mapping to vertex or index buffers.
        /// To determine if a Direct3D device supports these features, call <see cref="ID3D11Device.CheckFeatureSupport"/> with <see cref="D3D11_FEATURE_D3D11_OPTIONS"/>.
        /// <see cref="ID3D11Device.CheckFeatureSupport"/> fills members of a <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS"/> structure with the device's features.
        /// The relevant members here are <see cref="MapNoOverwriteOnDynamicConstantBuffer"/> and <see cref="MapNoOverwriteOnDynamicBufferSRV"/>.
        /// </summary>
        D3D11_BIND_SHADER_RESOURCE = 0x8,

        /// <summary>
        /// Bind an output buffer for the stream-output stage.
        /// </summary>
        D3D11_BIND_STREAM_OUTPUT = 0x10,

        /// <summary>
        /// Bind a texture as a render target for the output-merger stage.
        /// </summary>
        D3D11_BIND_RENDER_TARGET = 0x20,

        /// <summary>
        /// Bind a texture as a depth-stencil target for the output-merger stage.
        /// </summary>
        D3D11_BIND_DEPTH_STENCIL = 0x40,

        /// <summary>
        /// Bind an unordered access resource.
        /// </summary>
        D3D11_BIND_UNORDERED_ACCESS = 0x80,

        /// <summary>
        /// Set this flag to indicate that a 2D texture is used to receive output from the decoder API.
        /// The common way to create resources for a decoder output is
        /// by calling the <see cref="ID3D11Device.CreateTexture2D"/> method to create an array of 2D textures.
        /// However, you cannot use texture arrays that are created with this flag in calls to <see cref="ID3D11Device.CreateShaderResourceView"/>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1..
        /// </summary>
        D3D11_BIND_DECODER = 0x200,

        /// <summary>
        /// Set this flag to indicate that a 2D texture is used to receive input from the video encoder API.
        /// The common way to create resources for a video encoder is
        /// by calling the <see cref="ID3D11Device.CreateTexture2D"/> method to create an array of 2D textures.
        /// However, you cannot use texture arrays that are created with this flag in calls to <see cref="ID3D11Device.CreateShaderResourceView"/>.
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1.
        /// </summary>
        D3D11_BIND_VIDEO_ENCODER = 0x400,
    }
}
