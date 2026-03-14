using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D_FEATURE_LEVEL;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BIND_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BLEND;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BLEND_OP;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BUFFER_UAV_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_INPUT_CLASSIFICATION;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_MAP;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_QUERY;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_RESOURCE_MISC_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_TEXTURE_LAYOUT;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_USAGE;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.Enums.MemoryProtectionConstants;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="ID3D11DeviceContext"/> interface represents a device context which generates rendering commands.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// The latest version of this interface is <see cref="ID3D11DeviceContext4"/> introduced in the Windows 10 Creators Update.
    /// Applications targetting Windows 10 Creators Update
    /// should use the <see cref="ID3D11DeviceContext4"/> interface instead of <see cref="ID3D11DeviceContext"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11devicecontext"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "c0bfa96c-e089-44fb-8eaf-26f8796190da", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 114,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D11DeviceChild)])]
    public unsafe struct ID3D11DeviceContext
    {
        IntPtr* _vTable;

        /// <summary>
        /// Sets the constant buffers used by the vertex shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting constant buffers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to set (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffers (see <see cref="ID3D11Buffer"/>) being given to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// can bind a larger number of <see cref="ID3D11Buffer"/> resources to the shader than the maximum constant buffer size
        /// that is supported by shaders (4096 constants – 4*32-bit components each).
        /// When you bind such a large buffer, the shader can access only the first 4096 4*32-bit component constants in the buffer,
        /// as if 4096 constants is the full size of the buffer.
        /// </para>
        /// <para>
        /// If the application wants the shader to access other parts of the buffer,
        /// it must call the <see cref="VSSetConstantBuffers1"/> method instead.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void VSSetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [In] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[7])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Bind an array of shader resources to the pixel shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting shader resources to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// Number of shader resources to set.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to set to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// If an overlapping resource view is already bound to an output slot, such as a render target,
        /// then the method will fill the destination shader resource slot with <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// For information about creating shader-resource views, see <see cref="ID3D11Device.CreateShaderResourceView"/>.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void PSSetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [In] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[8])(thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Sets a pixel shader to the device.
        /// </summary>
        /// <param name="pPixelShader">
        /// Pointer to a pixel shader (see <see cref="ID3D11PixelShader"/>).
        /// Passing in <see cref="NULL"/> disables the shader for this pipeline stage.
        /// </param>
        /// <param name="ppClassInstances">
        /// A pointer to an array of class-instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// Each interface used by a shader must have a corresponding class instance or the shader will get disabled.
        /// Set <paramref name="ppClassInstances"/> to <see langword="null"/> if the shader does not use any interfaces.
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance interfaces in the array.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The maximum number of instances a shader can have is 256.
        /// </para>
        /// <para>
        /// Set <paramref name="ppClassInstances"/> to <see langword="null"/> if no interfaces are used in the shader.
        /// If it is not <see langword="null"/>, the number of class instances must match the number of interfaces used in the shader.
        /// Furthermore, each interface pointer must have a corresponding class instance or the assigned shader will be disabled.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void PSSetShader([In] P<ID3D11PixelShader> pPixelShader, [In] P<ID3D11ClassInstance>[]? ppClassInstances, [In] UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11PixelShader>, P<ID3D11ClassInstance>[]?, UINT, void>)_vTable[9])
                    (thisPtr, pPixelShader, ppClassInstances, NumClassInstances);
            }
        }

        /// <summary>
        /// Set an array of sampler states to the pixel shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting samplers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers in the array.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Pointer to an array of sampler-state interfaces (see <see cref="ID3D11SamplerState"/>). See Remarks.
        /// </param>
        /// <remarks>
        /// <para>
        /// Any sampler may be set to <see cref="NULL"/>; this invokes the default state, which is defined to be the following.
        /// </para>
        /// <code>
        /// //Default sampler state:
        /// D3D11_SAMPLER_DESC SamplerDesc;
        /// SamplerDesc.Filter = D3D11_FILTER_MIN_MAG_MIP_LINEAR;
        /// SamplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.MipLODBias = 0;
        /// SamplerDesc.MaxAnisotropy = 1;
        /// SamplerDesc.ComparisonFunc = D3D11_COMPARISON_NEVER;
        /// SamplerDesc.BorderColor[0] = 1.0f;
        /// SamplerDesc.BorderColor[1] = 1.0f;
        /// SamplerDesc.BorderColor[2] = 1.0f;
        /// SamplerDesc.BorderColor[3] = 1.0f;
        /// SamplerDesc.MinLOD = -FLT_MAX;
        /// SamplerDesc.MaxLOD = FLT_MAX;
        /// </code>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void PSSetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [In] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[10])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Set a vertex shader to the device.
        /// </summary>
        /// <param name="pVertexShader">
        /// Pointer to a vertex shader (see <see cref="ID3D11VertexShader"/>).
        /// Passing in <see cref="NULL"/> disables the shader for this pipeline stage.
        /// </param>
        /// <param name="ppClassInstances">
        /// A pointer to an array of class-instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// Each interface used by a shader must have a corresponding class instance or the shader will get disabled.
        /// Set <paramref name="ppClassInstances"/> to <see langword="null"/> if the shader does not use any interfaces.
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance interfaces in the array.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The maximum number of instances a shader can have is 256.
        /// </para>
        /// </remarks>
        public void VSSetShader([In] P<ID3D11VertexShader> pVertexShader, [In] P<ID3D11ClassInstance>[]? ppClassInstances, [In] UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VertexShader>, P<ID3D11ClassInstance>[]?, UINT, void>)_vTable[11])
                    (thisPtr, pVertexShader, ppClassInstances, NumClassInstances);
            }
        }

        /// <summary>
        /// Draw indexed, non-instanced primitives.
        /// </summary>
        /// <param name="IndexCount">
        /// Number of indices to draw.
        /// </param>
        /// <param name="StartIndexLocation">
        /// The location of the first index read by the GPU from the index buffer.
        /// </param>
        /// <param name="BaseVertexLocation">
        /// A value added to each index before reading a vertex from the vertex buffer.
        /// </param>
        /// <remarks>
        /// <para>
        /// A draw API submits work to the rendering pipeline.
        /// </para>
        /// <para>
        /// If the sum of both indices is negative, the result of the function call is undefined.
        /// </para>
        /// </remarks>
        public void DrawIndexed([In] UINT IndexCount, [In] UINT StartIndexLocation, [In] INT BaseVertexLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, INT, void>)_vTable[12])(thisPtr, IndexCount, StartIndexLocation, BaseVertexLocation);
            }
        }

        /// <summary>
        /// Draw non-indexed, non-instanced primitives.
        /// </summary>
        /// <param name="VertexCount">
        /// Number of vertices to draw.
        /// </param>
        /// <param name="StartVertexLocation">
        /// Index of the first vertex, which is usually an offset in a vertex buffer.
        /// </param>
        /// <remarks>
        /// <para>
        /// <see cref="Draw"/> submits work to the rendering pipeline.
        /// </para>
        /// <para>
        /// The vertex data for a draw call normally comes from a vertex buffer that is bound to the pipeline.
        /// </para>
        /// <para>
        /// Even without any vertex buffer bound to the pipeline, you can generate your own vertex data
        /// in your vertex shader by using the SV_VertexID system-value semantic to determine the current vertex that the runtime is processing.
        /// </para>
        /// </remarks>
        public void Draw([In] UINT VertexCount, [In] UINT StartVertexLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, void>)_vTable[13])(thisPtr, VertexCount, StartVertexLocation);
            }
        }

        /// <summary>
        /// Gets a pointer to the data contained in a subresource, and denies the GPU access to that subresource.
        /// </summary>
        /// <param name="pResource">
        /// A pointer to a <see cref="ID3D11Resource"/> interface.
        /// </param>
        /// <param name="Subresource">
        /// Index number of the subresource.
        /// </param>
        /// <param name="MapType">
        /// A <see cref="D3D11_MAP"/>-typed value that specifies the CPU's read and write permissions for a resource.
        /// </param>
        /// <param name="MapFlags">
        /// Flag that specifies what the CPU does when the GPU is busy.
        /// This flag is optional.
        /// </param>
        /// <param name="pMappedResource">
        /// A pointer to the <see cref="D3D11_MAPPED_SUBRESOURCE"/> structure for the mapped subresource.
        /// See the Remarks section regarding <see cref="NullRef{D3D11_MAPPED_SUBRESOURCE}"/> pointers.
        /// </param>
        /// <returns>
        /// <para>
        /// This method returns one of the Direct3D 11 Return Codes.
        /// </para>
        /// <para>
        /// This method also returns <see cref="DXGI_ERROR_WAS_STILL_DRAWING"/>
        /// if <paramref name="MapFlags"/> specifies <see cref="D3D11_MAP_FLAG_DO_NOT_WAIT"/> and the GPU is not yet finished with the resource.
        /// </para>
        /// <para>
        /// This method also returns <see cref="DXGI_ERROR_DEVICE_REMOVED"/>
        /// if <paramref name="MapType"/> allows any CPU read access and the video card has been removed.
        /// </para>
        /// <para>
        /// For more information about these error codes, see <see cref="DXGI_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If you call <see cref="Map"/> on a deferred context, you can only pass <see cref="D3D11_MAP_WRITE_DISCARD"/>,
        /// <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/>, or both to the <paramref name="MapType"/> parameter.
        /// Other <see cref="D3D11_MAP"/>-typed values are not supported for a deferred context.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// enables mapping dynamic constant buffers and shader resource views (SRVs) of dynamic buffers with <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/>.
        /// The Direct3D 11 and earlier runtimes limited mapping to vertex or index buffers.
        /// To determine if a Direct3D device supports these features,
        /// call <see cref="ID3D11Device.CheckFeatureSupport"/> with <see cref="D3D11_FEATURE_D3D11_OPTIONS"/>.
        /// <see cref="CheckFeatureSupport"/> fills members of a <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS"/> structure with the device's features.
        /// The relevant members here are <see cref="MapNoOverwriteOnDynamicConstantBuffer"/> and <see cref="MapNoOverwriteOnDynamicBufferSRV"/>.
        /// </para>
        /// <para>
        /// For info about how to use <see cref="Map"/>, see How to: Use dynamic resources.
        /// </para>
        /// <para>
        /// NULL pointers for <paramref name="pMappedResource"/>
        /// </para>
        /// <para>
        /// The <paramref name="pMappedResource"/> parameter may be <see cref="NullRef{D3D11_MAPPED_SUBRESOURCE}"/>
        /// when a texture is provided that was created with <see cref="D3D11_USAGE_DEFAULT"/>,
        /// and the API is called on an immediate context.
        /// This allows a default texture to be mapped, even if it was created using <see cref="D3D11_TEXTURE_LAYOUT_UNDEFINED"/>.
        /// Following this API call, the texture may be accessed using <see cref="ID3D11DeviceContext3.WriteToSubresource"/>
        /// and/or <see cref="ID3D11DeviceContext3.ReadFromSubresource"/>.
        /// </para>
        /// <para>
        /// Don't read from a subresource mapped for writing
        /// </para>
        /// <para>
        /// When you pass <see cref="D3D11_MAP_WRITE"/>, <see cref="D3D11_MAP_WRITE_DISCARD"/>,
        /// or <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/> to the <paramref name="MapType"/> parameter,
        /// you must ensure that your app does not read the subresource data
        /// to which the <see cref="D3D11_MAPPED_SUBRESOURCE.pData"/> member of <see cref="D3D11_MAPPED_SUBRESOURCE"/> points
        /// because doing so can cause a significant performance penalty.
        /// The memory region to which pData points can be allocated with <see cref="PAGE_WRITECOMBINE"/>,
        /// and your app must honor all restrictions that are associated with such memory.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Even the following C++ code can read from memory and trigger the performance penalty because the code can expand to the following x86 assembly code.
        /// </para>
        /// <para>
        /// C++ code:
        /// </para>
        /// <code>
        /// *((int*)MappedResource.pData) = 0;
        /// </code>
        /// <para>
        /// x86 assembly code:
        /// </para>
        /// <code>
        /// AND DWORD PTR [EAX],0
        /// </code>
        /// <para>
        /// Use the appropriate optimization settings and language constructs to help avoid this performance penalty.
        /// For example, you can avoid the xor optimization by using a volatile pointer or by optimizing for code speed instead of code size.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public HRESULT Map([In] P<ID3D11Resource> pResource, [In] UINT Subresource,
            [In] D3D11_MAP MapType, [In] UINT MapFlags, [Out] out D3D11_MAPPED_SUBRESOURCE pMappedResource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, UINT, D3D11_MAP, UINT, out D3D11_MAPPED_SUBRESOURCE, HRESULT>)_vTable[14])
                    (thisPtr, pResource, Subresource, MapType, MapFlags, out pMappedResource);
            }
        }

        /// <summary>
        /// Invalidate the pointer to a resource and reenable the GPU's access to that resource.
        /// </summary>
        /// <param name="pResource">
        /// A pointer to a <see cref="ID3D11Resource"/> interface.
        /// </param>
        /// <param name="Subresource">
        /// A subresource to be unmapped.
        /// </param>
        /// <remarks>
        /// <para>
        /// For info about how to use <see cref="Unmap"/>, see How to: Use dynamic resources.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void Unmap([In] P<ID3D11Resource> pResource, [In] UINT Subresource)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, UINT, HRESULT>)_vTable[15])(thisPtr, pResource, Subresource);
            }
        }

        /// <summary>
        /// Sets the constant buffers used by the pixel shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting constant buffers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to set (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffers (see <see cref="ID3D11Buffer"/>) being given to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems,
        /// can bind a larger number of <see cref="ID3D11Buffer"/> resources to the shader than the maximum constant buffer size
        /// that is supported by shaders (4096 constants – 432-bit components each).
        /// When you bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer,
        /// as if 4096 constants is the full size of the buffer.
        /// </para>
        /// <para>
        /// To enable the shader to access other parts of the buffer,
        /// call <see cref="PSSetConstantBuffers1"/> instead of <see cref="PSSetConstantBuffers"/>.
        /// <see cref="PSSetConstantBuffers1"/> has additional parameters pFirstConstant and pNumConstants.
        /// </para>
        /// </remarks>
        public void PSSetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [In] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[16])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Bind an input-layout object to the input-assembler stage.
        /// </summary>
        /// <param name="pInputLayout">
        /// A pointer to the input-layout object (see <see cref="ID3D11InputLayout"/>),
        /// which describes the input buffers that will be read by the IA stage.
        /// </param>
        /// <remarks>
        /// <para>
        /// Input-layout objects describe how vertex buffer data is streamed into the IA pipeline stage.
        /// To create an input-layout object, call <see cref="ID3D11Device.CreateInputLayout"/>.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void IASetInputLayout([In] P<ID3D11InputLayout> pInputLayout)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11InputLayout>, HRESULT>)_vTable[17])(thisPtr, pInputLayout);
            }
        }

        /// <summary>
        /// Bind an array of vertex buffers to the input-assembler stage.
        /// </summary>
        /// <param name="StartSlot">
        /// The first input slot for binding.
        /// The first vertex buffer is explicitly bound to the start slot;
        /// this causes each additional vertex buffer in the array to be implicitly bound to each subsequent input slot.
        /// The maximum of 16 or 32 input slots (ranges from 0 to <see cref="D3D11_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT"/> - 1) are available;
        /// the maximum number of input slots depends on the feature level.
        /// </param>
        /// <param name="NumBuffers">
        /// The number of vertex buffers in the array.
        /// The number of buffers (plus the starting slot) can't exceed the total number of IA-stage input slots
        /// (ranges from 0 to <see cref="D3D11_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppVertexBuffers">
        /// A pointer to an array of vertex buffers (see <see cref="ID3D11Buffer"/>).
        /// The vertex buffers must have been created with the <see cref="D3D11_BIND_VERTEX_BUFFER"/> flag.
        /// </param>
        /// <param name="pStrides">
        /// Pointer to an array of stride values; one stride value for each buffer in the vertex-buffer array.
        /// Each stride is the size (in bytes) of the elements that are to be used from that vertex buffer.
        /// </param>
        /// <param name="pOffsets">
        /// Pointer to an array of offset values; one offset value for each buffer in the vertex-buffer array.
        /// Each offset is the number of bytes between the first element of a vertex buffer and the first element that will be used.
        /// </param>
        /// <remarks>
        /// <para>
        /// For info about creating vertex buffers, see How to: Create a Vertex Buffer.
        /// </para>
        /// <para>
        /// Calling this method using a buffer that is currently bound for writing
        /// (that is, bound to the stream output pipeline stage) will effectively bind <see cref="NULL"/> instead
        /// because a buffer can't be bound as both an input and an output at the same time.
        /// </para>
        /// <para>
        /// The debug layer will generate a warning whenever a resource is prevented from being bound simultaneously as an input and an output,
        /// but this will not prevent invalid data from being used by the runtime.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void IASetVertexBuffers([In] UINT StartSlot, [In] UINT NumBuffers,
            [In] P<ID3D11Buffer>[]? ppVertexBuffers, [In] UINT[]? pStrides, [In] UINT[]? pOffsets)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, UINT[]?, UINT[]?, void>)_vTable[18])
                    (thisPtr, StartSlot, NumBuffers, ppVertexBuffers, pStrides, pOffsets);
            }
        }

        /// <summary>
        /// Bind an index buffer to the input-assembler stage.
        /// </summary>
        /// <param name="pIndexBuffer">
        /// A pointer to an <see cref="ID3D11Buffer"/> object, that contains indices.
        /// The index buffer must have been created with the <see cref="D3D11_BIND_INDEX_BUFFER"/> flag.
        /// </param>
        /// <param name="Format">
        /// A <see cref="DXGI_FORMAT"/> that specifies the format of the data in the index buffer.
        /// The only formats allowed for index buffer data are 16-bit (<see cref="DXGI_FORMAT_R16_UINT"/>) and 32-bit (<see cref="DXGI_FORMAT_R32_UINT"/>) integers.
        /// </param>
        /// <param name="Offset">
        /// Offset (in bytes) from the start of the index buffer to the first index to use.
        /// </param>
        /// <remarks>
        /// <para>
        /// For information about creating index buffers, see How to: Create an Index Buffer.
        /// </para>
        /// <para>
        /// Calling this method using a buffer that is currently bound for writing
        /// (i.e. bound to the stream output pipeline stage) will effectively bind <see cref="NULL"/> instead
        /// because a buffer cannot be bound as both an input and an output at the same time.
        /// </para>
        /// <para>
        /// The debug layer will generate a warning whenever a resource is prevented from being bound simultaneously as an input and an output,
        /// but this will not prevent invalid data from being used by the runtime.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void IASetIndexBuffer([In] P<ID3D11Buffer> pIndexBuffer, [In] DXGI_FORMAT Format, [In] UINT Offset)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Buffer>, DXGI_FORMAT, UINT, HRESULT>)_vTable[19])(thisPtr, pIndexBuffer, Format, Offset);
            }
        }

        /// <summary>
        /// Draw indexed, instanced primitives.
        /// </summary>
        /// <param name="IndexCountPerInstance">
        /// Number of indices read from the index buffer for each instance.
        /// </param>
        /// <param name="InstanceCount">
        /// Number of instances to draw.
        /// </param>
        /// <param name="StartIndexLocation">
        /// The location of the first index read by the GPU from the index buffer.
        /// </param>
        /// <param name="BaseVertexLocation">
        /// A value added to each index before reading a vertex from the vertex buffer.
        /// </param>
        /// <param name="StartInstanceLocation">
        /// A value added to each index before reading per-instance data from a vertex buffer.
        /// </param>
        /// <remarks>
        /// <para>
        /// A draw API submits work to the rendering pipeline.
        /// </para>
        /// <para>
        /// Instancing may extend performance by reusing the same geometry to draw multiple objects in a scene.
        /// One example of instancing could be to draw the same object with different positions and colors.
        /// Instancing requires multiple vertex buffers: at least one for per-vertex data and a second buffer for per-instance data.
        /// </para>
        /// <para>
        /// The second buffer is needed only if the input layout that you use has elements
        /// that use <see cref="D3D11_INPUT_PER_INSTANCE_DATA"/> as the input element classification buffer for per-instance data.
        /// </para>
        /// </remarks>
        public void DrawIndexedInstanced([In] UINT IndexCountPerInstance, [In] UINT InstanceCount, [In] UINT StartIndexLocation,
            [In] INT BaseVertexLocation, [In] UINT StartInstanceLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, INT, UINT, void>)_vTable[20])
                    (thisPtr, IndexCountPerInstance, InstanceCount, StartIndexLocation, BaseVertexLocation, StartInstanceLocation);
            }
        }

        /// <summary>
        /// Draw non-indexed, instanced primitives.
        /// </summary>
        /// <param name="VertexCountPerInstance">
        /// Number of vertices to draw.
        /// </param>
        /// <param name="InstanceCount">
        /// Number of instances to draw.
        /// </param>
        /// <param name="StartVertexLocation">
        /// Index of the first vertex.
        /// </param>
        /// <param name="StartInstanceLocation">
        /// A value added to each index before reading per-instance data from a vertex buffer.
        /// </param>
        /// <remarks>
        /// <para>
        /// A draw API submits work to the rendering pipeline.
        /// </para>
        /// <para>
        /// Instancing may extend performance by reusing the same geometry to draw multiple objects in a scene.
        /// One example of instancing could be to draw the same object with different positions and colors.
        /// </para>
        /// <para>
        /// The vertex data for an instanced draw call normally comes from a vertex buffer that is bound to the pipeline.
        /// However, you could also provide the vertex data from a shader that has instanced data identified with a system-value semantic (SV_InstanceID).
        /// </para>
        /// </remarks>
        public void DrawInstanced([In] UINT VertexCountPerInstance, [In] UINT InstanceCount, [In] UINT StartVertexLocation, [In] UINT StartInstanceLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, UINT, void>)_vTable[21])
                    (thisPtr, VertexCountPerInstance, InstanceCount, StartVertexLocation, StartInstanceLocation);
            }
        }

        /// <summary>
        /// Sets the constant buffers used by the geometry shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the zero-based array to begin setting constant buffers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to set (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffers (see <see cref="ID3D11Buffer"/>) being given to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// You can't use the <see cref="ID3D11ShaderReflectionConstantBuffer"/> interface
        /// to get information about what is currently bound to the pipeline in the device context.
        /// But you can use <see cref="ID3D11ShaderReflectionConstantBuffer"/> to get information from a compiled shader.
        /// For example, you can use <see cref="ID3D11ShaderReflectionConstantBuffer"/> and <see cref="ID3D11ShaderReflectionVariable"/>
        /// to determine the slot in which a geometry shader expects a constant buffer.
        /// You can then pass this slot number to <see cref="GSSetConstantBuffers"/> to set the constant buffer.
        /// You can call the <see cref="D3D11Reflect"/> function
        /// to retrieve the address of a pointer to the <see cref="ID3D11ShaderReflection"/> interface
        /// and then call <see cref="ID3D11ShaderReflection.GetConstantBufferByName"/>
        /// to get a pointer to <see cref="ID3D11ShaderReflectionConstantBuffer"/>.
        /// </para>
        /// <para>
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// can bind a larger number of <see cref="ID3D11Buffer"/> resources to the shader
        /// than the maximum constant buffer size that is supported by shaders (4096 constants – 432-bit components each).
        /// When you bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer,
        /// as if 4096 constants is the full size of the buffer.
        /// </para>
        /// <para>
        /// If the application wants the shader to access other parts of the buffer,
        /// it must call the <see cref="GSSetConstantBuffers1"/> method instead.
        /// </para>
        /// </remarks>
        public void GSSetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [In] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[22])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Set a geometry shader to the device.
        /// </summary>
        /// <param name="pShader">
        /// Pointer to a geometry shader (see <see cref="ID3D11GeometryShader"/>).
        /// Passing in <see cref="NULL"/> disables the shader for this pipeline stage.
        /// </param>
        /// <param name="ppClassInstances">
        /// A pointer to an array of class-instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// Each interface used by a shader must have a corresponding class instance or the shader will get disabled.
        /// Set <paramref name="ppClassInstances"/> to <see langword="null"/> if the shader does not use any interfaces.
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance interfaces in the array.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The maximum number of instances a shader can have is 256.
        /// </para>
        /// </remarks>
        public void GSSetShader([In] P<ID3D11GeometryShader> pShader, [In] P<ID3D11ClassInstance>[]? ppClassInstances, [In] UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11GeometryShader>, P<ID3D11ClassInstance>[]?, UINT, void>)_vTable[23])
                    (thisPtr, pShader, ppClassInstances, NumClassInstances);
            }
        }

        /// <summary>
        /// Bind information about the primitive type, and data order that describes input data for the input assembler stage.
        /// </summary>
        /// <param name="Topology">
        /// The type of primitive and ordering of the primitive data (see D3D11_PRIMITIVE_TOPOLOGY).
        /// </param>
        /// <remarks>
        /// Windows Phone 8: This API is supported.
        /// </remarks>
        public void IASetPrimitiveTopology([In] D3D11_PRIMITIVE_TOPOLOGY Topology)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, D3D11_PRIMITIVE_TOPOLOGY, void>)_vTable[24])(thisPtr, Topology);
            }
        }

        /// <summary>
        /// Bind an array of shader resources to the vertex-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting shader resources to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// Number of shader resources to set.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to set to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// If an overlapping resource view is already bound to an output slot, such as a rendertarget,
        /// then this API will fill the destination shader resource slot with <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// For information about creating shader-resource views, see <see cref="ID3D11Device.CreateShaderResourceView"/>.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// In order to unbind resource slots, you must pass an array containing null values.
        /// For example, to clear the first 4 slots, use:
        /// </para>
        /// <code>
        /// ID3D11ShaderResourceView* nullsrv[] = { nullptr, nullptr, nullptr, nullptr };
        /// context-&gt;VSSetShaderResources(0, 4, nullsrv);
        /// </code>
        /// </remarks>
        public void VSSetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [In] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[25])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Set an array of sampler states to the vertex shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting samplers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers in the array.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Pointer to an array of sampler-state interfaces (see <see cref="ID3D11SamplerState"/>). See Remarks.
        /// </param>
        /// <remarks>
        /// <para>
        /// Any sampler may be set to <see cref="NULL"/>; this invokes the default state, which is defined to be the following.
        /// </para>
        /// <code>
        /// //Default sampler state:
        /// D3D11_SAMPLER_DESC SamplerDesc;
        /// SamplerDesc.Filter = D3D11_FILTER_MIN_MAG_MIP_LINEAR;
        /// SamplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.MipLODBias = 0;
        /// SamplerDesc.MaxAnisotropy = 1;
        /// SamplerDesc.ComparisonFunc = D3D11_COMPARISON_NEVER;
        /// SamplerDesc.BorderColor[0] = 1.0f;
        /// SamplerDesc.BorderColor[1] = 1.0f;
        /// SamplerDesc.BorderColor[2] = 1.0f;
        /// SamplerDesc.BorderColor[3] = 1.0f;
        /// SamplerDesc.MinLOD = -FLT_MAX;
        /// SamplerDesc.MaxLOD = FLT_MAX;
        /// </code>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void VSSetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [In] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[26])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Mark the beginning of a series of commands.
        /// </summary>
        /// <param name="pAsync">
        /// A pointer to an <see cref="ID3D11Asynchronous"/> interface.
        /// </param>
        /// <remarks>
        /// Use <see cref="End"/> to mark the ending of the series of commands.
        /// </remarks>
        public void Begin([In] P<ID3D11Asynchronous> pAsync)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Asynchronous>, void>)_vTable[27])(thisPtr, pAsync);
            }
        }

        /// <summary>
        /// Mark the end of a series of commands.
        /// </summary>
        /// <param name="pAsync">
        /// A pointer to an <see cref="ID3D11Asynchronous"/> interface.
        /// </param>
        /// <remarks>
        /// Use <see cref="Begin"/> to mark the beginning of the series of commands.
        /// </remarks>
        public void End([In] P<ID3D11Asynchronous> pAsync)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Asynchronous>, void>)_vTable[28])(thisPtr, pAsync);
            }
        }

        /// <summary>
        /// Get data from the graphics processing unit (GPU) asynchronously.
        /// </summary>
        /// <param name="pAsync">
        /// A pointer to an <see cref="ID3D11Asynchronous"/> interface for the object about which <see cref="GetData"/> retrieves data.
        /// </param>
        /// <param name="pData">
        /// Address of memory that will receive the data.
        /// If <see cref="NULL"/>, <see cref="GetData"/> will be used only to check status.
        /// The type of data output depends on the type of asynchronous interface.
        /// </param>
        /// <param name="DataSize">
        /// Size of the data to retrieve or 0.
        /// Must be 0 when <paramref name="pData"/> is <see cref="NULL"/>.
        /// </param>
        /// <param name="GetDataFlags">
        /// Optional flags.
        /// Can be 0 or any combination of the flags enumerated by <see cref="D3D11_ASYNC_GETDATA_FLAG"/>.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 Return Codes.
        /// A return value of <see cref="S_OK"/> indicates that the data at pData is available for the calling application to access.
        /// A return value of <see cref="S_FALSE"/> indicates that the data is not yet available.
        /// If the data is not yet available, the application must call <see cref="GetData"/> until the data is available.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Queries in a deferred context are limited to predicated drawing.
        /// That is, you cannot call <see cref="GetData"/> on a deferred context to get data about a query;
        /// you can only call <see cref="GetData"/> on the immediate context to get data about a query.
        /// For predicated drawing, the results of a predication-type query are used by the GPU and not returned to an application.
        /// For more information about predication and predicated drawing, see <see cref="SetPredication"/>.
        /// </para>
        /// <para>
        /// <see cref="GetData"/> retrieves the data that the runtime collected
        /// between calls to <see cref="Begin"/> and <see cref="End"/>.
        /// Certain queries only require a call to <see cref="End"/> in which case the data
        /// returned by <see cref="GetData"/> is accurate up to the last call to <see cref="End"/>.
        /// For information about the queries that only require a call to <see cref="End"/>
        /// and about the type of data that <see cref="GetData"/> retrieves for each query, see <see cref="D3D11_QUERY"/>.
        /// </para>
        /// <para>
        /// If <paramref name="DataSize"/> is 0, <see cref="GetData"/> is only used to check status.
        /// </para>
        /// <para>
        /// An application gathers counter data by calling <see cref="Begin"/>, issuing some graphics commands,
        /// calling <see cref="End"/>, and then calling <see cref="GetData"/> to get data about
        /// what happened in between the <see cref="Begin"/> and <see cref="End"/> calls.
        /// For information about performance counter types, see <see cref="D3D11_COUNTER"/>.
        /// </para>
        /// </remarks>
        public HRESULT GetData([In] P<ID3D11Asynchronous> pAsync, [In] IntPtr pData, [In] UINT DataSize, [In] D3D11_ASYNC_GETDATA_FLAG GetDataFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Asynchronous>, IntPtr, UINT, D3D11_ASYNC_GETDATA_FLAG, HRESULT>)_vTable[29])
                    (thisPtr, pAsync, pData, DataSize, GetDataFlags);
            }
        }

        /// <summary>
        /// Set a rendering predicate.
        /// </summary>
        /// <param name="pPredicate">
        /// A pointer to the <see cref="ID3D11Predicate"/> interface that represents the rendering predicate.
        /// A <see cref="NULL"/> value indicates "no" predication;
        /// in this case, the value of <paramref name="PredicateValue"/> is irrelevant but will be preserved for <see cref="GetPredication"/>.
        /// </param>
        /// <param name="PredicateValue">
        /// If <see cref="TRUE"/>, rendering will be affected by when the predicate's conditions are met.
        /// If <see cref="FALSE"/>, rendering will be affected when the conditions are not met.
        /// </param>
        /// <remarks>
        /// <para>
        /// The predicate must be in the "issued" or "signaled" state to be used for predication.
        /// While the predicate is set for predication, calls to <see cref="Begin"/> and <see cref="End"/> are invalid.
        /// </para>
        /// <para>
        /// Use this method to denote that subsequent rendering and resource manipulation commands are not actually performed
        /// if the resulting predicate data of the predicate is equal to the <paramref name="PredicateValue"/>.
        /// However, some predicates are only hints, so they may not actually prevent operations from being performed.
        /// </para>
        /// <para>
        /// The primary usefulness of predication is to allow an application to issue rendering and resource manipulation commands
        /// without taking the performance hit of spinning, waiting for <see cref="GetData"/> to return.
        /// So, predication can occur while <see cref="GetData"/> returns <see cref="S_FALSE"/>.
        /// Another way to think of it: an application can also use predication as a fallback,
        /// if it is possible that <see cref="GetData"/> returns <see cref="S_FALSE"/>.
        /// If <see cref="GetData"/> returns <see cref="S_OK"/>,
        /// the application can skip calling the rendering and resource manipulation commands manually with its own application logic.
        /// </para>
        /// <para>
        /// Rendering and resource manipulation commands for Direct3D 11 include these Draw, Dispatch, Copy, Update, Clear, Generate, and Resolve operations.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="Draw"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DrawAuto"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DrawIndexed"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DrawIndexedInstanced"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DrawIndexedInstancedIndirect"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DrawInstanced"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DrawInstancedIndirect"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="Dispatch"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DispatchIndirect"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CopyResource"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CopyStructureCount"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CopySubresourceRegion"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CopySubresourceRegion1"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CopyTiles"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CopyTileMappings"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="UpdateSubresource"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="UpdateSubresource1"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="UpdateTiles"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="UpdateTileMappings"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ClearRenderTargetView"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ClearUnorderedAccessViewFloat"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ClearUnorderedAccessViewUint"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ClearView"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ClearDepthStencilView"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GenerateMips"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ResolveSubresource"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// You can set a rendering predicate on an immediate or a deferred context.
        /// For info about immediate and deferred contexts, see Immediate and Deferred Rendering.
        /// </para>
        /// </remarks>
        public void SetPredication([In] P<ID3D11Predicate> pPredicate, [In] BOOL PredicateValue)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Predicate>, BOOL, void>)_vTable[30])(thisPtr, pPredicate, PredicateValue);
            }
        }

        /// <summary>
        /// Bind an array of shader resources to the domain-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting shader resources to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// Number of shader resources to set.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to set to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// If an overlapping resource view is already bound to an output slot, such as a render target,
        /// then the method will fill the destination shader resource slot with <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// For information about creating shader-resource views, see <see cref="ID3D11Device.CreateShaderResourceView"/>.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void GSSetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [In] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[31])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Set an array of sampler states to the geometry shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting samplers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers in the array.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Pointer to an array of sampler-state interfaces (see <see cref="ID3D11SamplerState"/>). See Remarks.
        /// </param>
        /// <remarks>
        /// <para>
        /// Any sampler may be set to <see cref="NULL"/>; this invokes the default state, which is defined to be the following.
        /// </para>
        /// <code>
        /// //Default sampler state:
        /// D3D11_SAMPLER_DESC SamplerDesc;
        /// SamplerDesc.Filter = D3D11_FILTER_MIN_MAG_MIP_LINEAR;
        /// SamplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.MipLODBias = 0;
        /// SamplerDesc.MaxAnisotropy = 1;
        /// SamplerDesc.ComparisonFunc = D3D11_COMPARISON_NEVER;
        /// SamplerDesc.BorderColor[0] = 1.0f;
        /// SamplerDesc.BorderColor[1] = 1.0f;
        /// SamplerDesc.BorderColor[2] = 1.0f;
        /// SamplerDesc.BorderColor[3] = 1.0f;
        /// SamplerDesc.MinLOD = -FLT_MAX;
        /// SamplerDesc.MaxLOD = FLT_MAX;
        /// </code>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void GSSetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [In] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[32])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Bind one or more render targets atomically and the depth-stencil buffer to the output-merger stage.
        /// </summary>
        /// <param name="NumViews">
        /// Number of render targets to bind (ranges between 0 and <see cref="D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT"/>).
        /// If this parameter is nonzero, the number of entries in the array
        /// to which <paramref name="ppRenderTargetViews"/> points must equal the number in this parameter.
        /// </param>
        /// <param name="ppRenderTargetViews">
        /// Pointer to an array of <see cref="ID3D11RenderTargetView"/> that represent the render targets to bind to the device.
        /// If this parameter is <see langword="null"/> and <paramref name="NumViews"/> is 0, no render targets are bound.
        /// </param>
        /// <param name="pDepthStencilView">
        /// Pointer to a <see cref="ID3D11DepthStencilView"/> that represents the depth-stencil view to bind to the device.
        /// If this parameter is <see cref="NULL"/>, the depth-stencil view is not bound.
        /// </param>
        /// <remarks>
        /// <para>
        /// The maximum number of active render targets a device can have active at any given time
        /// is set by a #define in D3D11.h called <see cref="D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT"/>.
        /// It is invalid to try to set the same subresource to multiple render target slots.
        /// Any render targets not defined by this call are set to <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If any subresources are also currently bound for reading in a different stage or writing
        /// (perhaps in a different part of the pipeline), those bind points will be set to <see cref="NULL"/>,
        /// in order to prevent the same subresource from being read and written simultaneously in a single rendering operation.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// If the render-target views were created from an array resource type,
        /// all of the render-target views must have the same array size.
        /// </para>
        /// <para>
        /// This restriction also applies to the depth-stencil view,
        /// its array size must match that of the render-target views being bound.
        /// </para>
        /// <para>
        /// The pixel shader must be able to simultaneously render to at least eight separate render targets.
        /// All of these render targets must access the same type of resource: 
        /// Buffer, Texture1D, Texture1DArray, Texture2D, Texture2DArray, Texture3D, or TextureCube.
        /// All render targets must have the same size in all dimensions (width and height, and depth for 3D or array size for *Array types).
        /// If render targets use multisample anti-aliasing,
        /// all bound render targets and depth buffer must be the same form of multisample resource
        /// (that is, the sample counts must be the same).
        /// Each render target can have a different data format.
        /// These render target formats are not required to have identical bit-per-element counts.
        /// </para>
        /// <para>
        /// Any combination of the eight slots for render targets can have a render target set or not set.
        /// </para>
        /// <para>
        /// The same resource view cannot be bound to multiple render target slots simultaneously.
        /// However, you can set multiple non-overlapping resource views of a single resource as simultaneous multiple render targets.
        /// </para>
        /// <para>
        /// Note that unlike some other resource methods in Direct3D,
        /// all currently bound render targets will be unbound by calling <c>OMSetRenderTargets(0, nullptr, nullptr);</c>.
        /// </para>
        /// </remarks>
        public void OMSetRenderTargets([In] UINT NumViews, [In] P<ID3D11RenderTargetView>[]? ppRenderTargetViews,
            [In] P<ID3D11DepthStencilView> pDepthStencilView)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D11RenderTargetView>[]?, P<ID3D11DepthStencilView>, void>)_vTable[33])
                    (thisPtr, NumViews, ppRenderTargetViews, pDepthStencilView);
            }
        }

        /// <summary>
        /// Binds resources to the output-merger stage.
        /// </summary>
        /// <param name="NumRTVs">
        /// Number of render targets to bind (ranges between 0 and <see cref="D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT"/>).
        /// If this parameter is nonzero, the number of entries in the array
        /// to which <paramref name="ppRenderTargetViews"/> points must equal the number in this parameter.
        /// If you set <paramref name="NumRTVs"/> to <see cref="D3D11_KEEP_RENDER_TARGETS_AND_DEPTH_STENCIL"/> (0xffffffff),
        /// this method does not modify the currently bound render-target views (RTVs) and also does not modify depth-stencil view (DSV).
        /// </param>
        /// <param name="ppRenderTargetViews">
        /// Pointer to an array of <see cref="ID3D11RenderTargetView"/>s that represent the render targets to bind to the device.
        /// If this parameter is <see langword="null"/> and <paramref name="NumUAVs"/> is 0, no render targets are bound.
        /// </param>
        /// <param name="pDepthStencilView">
        /// Pointer to a <see cref="ID3D11DepthStencilView"/> that represents the depth-stencil view to bind to the device.
        /// If this parameter is <see cref="NULL"/>, the depth-stencil view is not bound.
        /// </param>
        /// <param name="UAVStartSlot">
        /// <para>
        /// Index into a zero-based array to begin setting unordered-access views (ranges from 0 to <see cref="D3D11_PS_CS_UAV_REGISTER_COUNT"/> - 1).
        /// </para>
        /// <para>
        /// For the Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// this value can range from 0 to <see cref="D3D11_1_UAV_SLOT_COUNT"/> - 1.
        /// <see cref="D3D11_1_UAV_SLOT_COUNT"/> is defined as 64.
        /// </para>
        /// <para>
        /// For pixel shaders, <paramref name="UAVStartSlot"/> should be equal to the number of render-target views being bound.
        /// </para>
        /// </param>
        /// <param name="NumUAVs">
        /// <para>
        /// Number of unordered-access views (UAVs) in <paramref name="ppUnorderedAccessViews"/>.
        /// If you set <paramref name="NumUAVs"/> to <see cref="D3D11_KEEP_UNORDERED_ACCESS_VIEWS"/> (0xffffffff),
        /// this method does not modify the currently bound unordered-access views.
        /// </para>
        /// <para>
        /// For the Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// this value can range from 0 to <see cref="D3D11_1_UAV_SLOT_COUNT"/> - <paramref name="UAVStartSlot"/>.
        /// </para>
        /// </param>
        /// <param name="ppUnorderedAccessViews">
        /// Pointer to an array of <see cref="ID3D11UnorderedAccessView"/>s that represent the unordered-access views to bind to the device.
        /// If this parameter is <see cref="NULL"/> and <paramref name="NumUAVs"/> is 0, no unordered-access views are bound.
        /// </param>
        /// <param name="pUAVInitialCounts">
        /// An array of append and consume buffer offsets.
        /// A value of -1 indicates to keep the current offset.
        /// Any other values set the hidden counter for that appendable and consumable UAV.
        /// <paramref name="pUAVInitialCounts"/> is relevant only for UAVs
        /// that were created with either <see cref="D3D11_BUFFER_UAV_FLAG_APPEND"/> or <see cref="D3D11_BUFFER_UAV_FLAG_COUNTER"/> specified
        /// when the UAV was created; otherwise, the argument is ignored.
        /// </param>
        /// <remarks>
        /// <para>
        /// For pixel shaders, the render targets and unordered-access views share the same resource slots when being written out. This means that UAVs must be given an offset so that they are placed in the slots after the render target views that are being bound.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// RTVs, DSV, and UAVs cannot be set independently; they all need to be set at the same time.
        /// </para>
        /// <para>
        /// Two RTVs conflict if they share a subresource (and therefore share the same resource).
        /// </para>
        /// <para>
        /// Two UAVs conflict if they share a subresource (and therefore share the same resource).
        /// </para>
        /// <para>
        /// An RTV conflicts with a UAV if they share a subresource or share a bind point.
        /// </para>
        /// <para>
        /// <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> operates properly in the following situations:
        /// </para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// <para>
        /// <paramref name="NumRTVs"/> != <see cref="D3D11_KEEP_RENDER_TARGETS_AND_DEPTH_STENCIL"/>
        /// and <paramref name="NumUAVs"/> != <see cref="D3D11_KEEP_UNORDERED_ACCESS_VIEWS"/>
        /// </para>
        /// <para>
        /// The following conditions must be true for <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> to succeed
        /// and for the runtime to pass the bind information to the driver:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <paramref name="NumRTVs"/> &lt;= 8
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="UAVStartSlot"/> &gt;= <paramref name="NumRTVs"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="UAVStartSlot"/> + <paramref name="NumUAVs"/> &lt;= 8
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// There must be no conflicts in the set of all <paramref name="ppRenderTargetViews"/> and <paramref name="ppUnorderedAccessViews"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="pDepthStencilView"/> must match the render-target views.
        /// For more information about resource views, see Introduction to a Resource in Direct3D 11.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> performs the following tasks:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Unbinds all currently bound conflicting resources (stream-output target resources (SOTargets), compute shader (CS) UAVs, shader-resource views (SRVs)).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Binds <paramref name="ppRenderTargetViews"/>, <paramref name="pDepthStencilView"/>, and <paramref name="ppUnorderedAccessViews"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <paramref name="NumRTVs"/> == <see cref="D3D11_KEEP_RENDER_TARGETS_AND_DEPTH_STENCIL"/>
        /// </para>
        /// <para>
        /// In this situation, <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> binds only UAVs.
        /// </para>
        /// <para>
        /// The following conditions must be true for <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> to succeed
        /// and for the runtime to pass the bind information to the driver:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <paramref name="UAVStartSlot"/> + <paramref name="NumUAVs"/> &lt;= 8
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// There must be no conflicts in <paramref name="ppUnorderedAccessViews"/>.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> unbinds the following items:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// All RTVs in slots &gt;= <paramref name="UAVStartSlot"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// All RTVs that conflict with any UAVs in <paramref name="ppUnorderedAccessViews"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// All currently bound resources (SOTargets, CS UAVs, SRVs) that conflict with <paramref name="ppUnorderedAccessViews"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> binds <paramref name="ppUnorderedAccessViews"/>.
        /// </para>
        /// <para>
        /// <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> ignores ppDepthStencilView, and the current depth-stencil view remains bound.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <paramref name="NumUAVs"/> == <see cref="D3D11_KEEP_UNORDERED_ACCESS_VIEWS"/>
        /// </para>
        /// <para>
        /// In this situation, <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> binds only RTVs and DSV.
        /// </para>
        /// <para>
        /// The following conditions must be true for <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> to succeed
        /// and for the runtime to pass the bind information to the driver:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <paramref name="NumRTVs"/> &lt;= 8
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// There must be no conflicts in <paramref name="ppRenderTargetViews"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="pDepthStencilView"/> must match the render-target views.
        /// For more information about resource views, see Introduction to a Resource in Direct3D 11.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> unbinds the following items:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// All UAVs in slots &lt; <paramref name="NumRTVs"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// All UAVs that conflict with any RTVs in <paramref name="ppRenderTargetViews"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// All currently bound resources (SOTargets, CS UAVs, SRVs) that conflict with <paramref name="ppRenderTargetViews"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> binds <paramref name="ppRenderTargetViews"/> and <paramref name="pDepthStencilView"/>.
        /// </para>
        /// <para>
        /// <see cref="OMSetRenderTargetsAndUnorderedAccessViews"/> ignores <paramref name="UAVStartSlot"/>.
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void OMSetRenderTargetsAndUnorderedAccessViews([In] UINT NumRTVs, [In] P<ID3D11RenderTargetView>[]? ppRenderTargetViews,
            [In] P<ID3D11DepthStencilView> pDepthStencilView, [In] UINT UAVStartSlot, [In] UINT NumUAVs,
            [In] P<ID3D11UnorderedAccessView>[]? ppUnorderedAccessViews, [In] UINT[]? pUAVInitialCounts)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D11RenderTargetView>[]?, P<ID3D11DepthStencilView>,
                    UINT, UINT, P<ID3D11UnorderedAccessView>[]?, UINT[]?, void>)_vTable[34])
                    (thisPtr, NumRTVs, ppRenderTargetViews, pDepthStencilView, UAVStartSlot, NumUAVs, ppUnorderedAccessViews, pUAVInitialCounts);
            }
        }

        /// <summary>
        /// Set the blend state of the output-merger stage.
        /// </summary>
        /// <param name="pBlendState">
        /// Pointer to a blend-state interface (see <see cref="ID3D11BlendState"/>).
        /// Pass <see cref="NULL"/> for a default blend state.
        /// For more info about default blend state, see Remarks.
        /// </param>
        /// <param name="BlendFactor">
        /// Array of blend factors, one for each RGBA component.
        /// The blend factors modulate values for the pixel shader, render target, or both.
        /// If you created the blend-state object with <see cref="D3D11_BLEND_BLEND_FACTOR"/> or <see cref="D3D11_BLEND_INV_BLEND_FACTOR"/>,
        /// the blending stage uses the non-NULL array of blend factors.
        /// If you didn't create the blend-state object with <see cref="D3D11_BLEND_BLEND_FACTOR"/> or <see cref="D3D11_BLEND_INV_BLEND_FACTOR"/>,
        /// the blending stage does not use the non-NULL array of blend factors;
        /// the runtime stores the blend factors, and you can later call <see cref="OMGetBlendState"/> to retrieve the blend factors.
        /// If you pass <see langword="null"/>, the runtime uses or stores a blend factor equal to { 1, 1, 1, 1 }.
        /// </param>
        /// <param name="SampleMask">
        /// 32-bit sample coverage.
        /// The default value is 0xffffffff.
        /// See remarks.
        /// </param>
        /// <remarks>
        /// <para>
        /// Blend state is used by the output-merger stage to determine how to blend together two RGB pixel values and two alpha values.
        /// The two RGB pixel values and two alpha values are the RGB pixel value and alpha value
        /// that the pixel shader outputs and the RGB pixel value and alpha value already in the output render target.
        /// The blend option controls the data source that the blending stage
        /// uses to modulate values for the pixel shader, render target, or both.
        /// The blend operation controls how the blending stage mathematically combines these modulated values.
        /// </para>
        /// <para>
        /// To create a blend-state interface, call <see cref="ID3D11Device.CreateBlendState"/>.
        /// </para>
        /// <para>
        /// Passing in <see langword="null"/> for the blend-state interface
        /// indicates to the runtime to set a default blending state.
        /// The following table indicates the default blending parameters.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// State
        /// </term>
        /// <term>
        /// Default Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// AlphaToCoverageEnable
        /// </term>
        /// <term>
        /// <see cref="FALSE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// IndependentBlendEnable
        /// </term>
        /// <term>
        /// <see cref="FALSE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// RenderTarget[0].BlendEnable
        /// </term>
        /// <term>
        /// <see cref="FALSE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// RenderTarget[0].SrcBlend
        /// </term>
        /// <term>
        /// <see cref="D3D11_BLEND_ONE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// RenderTarget[0].DestBlend
        /// </term>
        /// <term>
        /// <see cref="D3D11_BLEND_ZERO"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// RenderTarget[0].BlendOp
        /// </term>
        /// <term>
        /// <see cref="D3D11_BLEND_OP_ADD"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// RenderTarget[0].SrcBlendAlpha
        /// </term>
        /// <term>
        /// <see cref="D3D11_BLEND_ONE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// RenderTarget[0].DestBlendAlpha
        /// </term>
        /// <term>
        /// <see cref="D3D11_BLEND_ZERO"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// RenderTarget[0].BlendOpAlpha
        /// </term>
        /// <term>
        /// <see cref="D3D11_BLEND_OP_ADD"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// RenderTarget[0].RenderTargetWriteMask
        /// </term>
        /// <term>
        /// <see cref="D3D11_COLOR_WRITE_ENABLE_ALL"/>
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// A sample mask determines which samples get updated in all the active render targets.
        /// The mapping of bits in a sample mask to samples in a multisample render target is the responsibility of an individual application.
        /// A sample mask is always applied; it is independent of whether multisampling is enabled,
        /// and does not depend on whether an application uses multisample render targets.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void OMSetBlendState([In] P<ID3D11BlendState> pBlendState, [In] FLOAT[]? BlendFactor, [In] UINT SampleMask)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11BlendState>, FLOAT[]?, UINT, void>)_vTable[35])
                    (thisPtr, pBlendState, BlendFactor, SampleMask);
            }
        }

        /// <summary>
        /// Sets the depth-stencil state of the output-merger stage.
        /// </summary>
        /// <param name="pDepthStencilState">
        /// Pointer to a depth-stencil state interface (see <see cref="ID3D11DepthStencilState"/>) to bind to the device.
        /// Set this to <see cref="NULL"/> to use the default state listed in <see cref="D3D11_DEPTH_STENCIL_DESC"/>.
        /// </param>
        /// <param name="StencilRef">
        /// Reference value to perform against when doing a depth-stencil test. See remarks.
        /// </param>
        /// <remarks>
        /// <para>
        /// To create a depth-stencil state interface, call <see cref="ID3D11Device.CreateDepthStencilState"/>.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void OMSetDepthStencilState([In] P<ID3D11DepthStencilState> pDepthStencilState, [In] UINT StencilRef)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11DepthStencilState>, UINT, void>)_vTable[36])(thisPtr, pDepthStencilState, StencilRef);
            }
        }

        /// <summary>
        /// Set the target output buffers for the stream-output stage of the pipeline.
        /// </summary>
        /// <param name="NumBuffers">
        /// The number of buffer to bind to the device.
        /// A maximum of four output buffers can be set.
        /// If less than four are defined by the call, the remaining buffer slots are set to <see cref="NULL"/>.
        /// See Remarks.
        /// </param>
        /// <param name="ppSOTargets">
        /// The array of output buffers (see <see cref="ID3D11Buffer"/>) to bind to the device.
        /// The buffers must have been created with the <see cref="D3D11_BIND_STREAM_OUTPUT"/> flag.
        /// </param>
        /// <param name="pOffsets">
        /// Array of offsets to the output buffers from <paramref name="ppSOTargets"/>, one offset for each buffer.
        /// The offset values must be in bytes.
        /// </param>
        /// <remarks>
        /// <para>
        /// An offset of -1 will cause the stream output buffer to be appended,
        /// continuing after the last location written to the buffer in a previous stream output pass.
        /// </para>
        /// <para>
        /// Calling this method using a buffer that is currently bound for writing will effectively bind <see cref="NULL"/> instead
        /// because a buffer cannot be bound as both an input and an output at the same time.
        /// </para>
        /// <para>
        /// The debug layer will generate a warning whenever a resource is prevented from being bound simultaneously as an input and an output,
        /// but this will not prevent invalid data from being used by the runtime.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// Note that unlike some other resource methods in Direct3D,
        /// all currently bound targets will be unbound by calling <c>SOSetTargets(0, nullptr, nullptr);</c>.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void SOSetTargets([In] UINT NumBuffers, [In] P<ID3D11Buffer>[]? ppSOTargets, [In] UINT[]? pOffsets)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D11Buffer>[]?, UINT[]?, void>)_vTable[37])
                    (thisPtr, NumBuffers, ppSOTargets, pOffsets);
            }
        }

        /// <summary>
        /// Draw geometry of an unknown size.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A draw API submits work to the rendering pipeline.
        /// This API submits work of an unknown size that was processed by the input assembler, vertex shader, and stream-output stages;
        /// the work may or may not have gone through the geometry-shader stage.
        /// </para>
        /// <para>
        /// After data has been streamed out to stream-output stage buffers,
        /// those buffers can be again bound to the Input Assembler stage at input slot 0
        /// and <see cref="DrawAuto"/> will draw them without the application needing to know the amount of data that was written to the buffers.
        /// A measurement of the amount of data written to the SO stage buffers is maintained internally when the data is streamed out.
        /// This means that the CPU does not need to fetch the measurement before re-binding the data that was streamed as input data.
        /// Although this amount is tracked internally, it is still the responsibility of applications to use input layouts
        /// to describe the format of the data in the SO stage buffers so that the layouts are available
        /// when the buffers are again bound to the input assembler.
        /// </para>
        /// <para>
        /// The following diagram shows the <see cref="DrawAuto"/> process.
        /// </para>
        /// <para>
        /// Calling <see cref="DrawAuto"/> does not change the state of the streaming-output buffers that were bound again as inputs.
        /// </para>
        /// <para>
        /// <see cref="DrawAuto"/> only works when drawing with one input buffer bound as an input to the IA stage at slot 0.
        /// Applications must create the SO buffer resource with both binding flags,
        /// <see cref="D3D11_BIND_VERTEX_BUFFER"/> and <see cref="D3D11_BIND_STREAM_OUTPUT"/>.
        /// </para>
        /// <para>
        /// This API does not support indexing or instancing.
        /// </para>
        /// <para>
        /// If an application needs to retrieve the size of the streaming-output buffer,
        /// it can query for statistics on streaming output by using <see cref="D3D11_QUERY_SO_STATISTICS"/>.
        /// </para>
        /// </remarks>
        public void DrawAuto()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[38])(thisPtr);
            }
        }

        /// <summary>
        /// Draw indexed, instanced, GPU-generated primitives.
        /// </summary>
        /// <param name="pBufferForArgs">
        /// A pointer to an <see cref="ID3D11Buffer"/>, which is a buffer containing the GPU-generated primitives.
        /// </param>
        /// <param name="AlignedByteOffsetForArgs">
        /// A DWORD-aligned byte offset in <paramref name="pBufferForArgs"/> to the start of the GPU generated primitives.
        /// </param>
        /// <remarks>
        /// <para>
        /// When an application creates a buffer that is associated with the <see cref="ID3D11Buffer"/> interface
        /// that <paramref name="pBufferForArgs"/> points to,
        /// your application must set the <see cref="D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS"/> flag
        /// in the <see cref="D3D11_BUFFER_DESC.MiscFlags"/> member of the <see cref="D3D11_BUFFER_DESC"/> structure that describes the buffer.
        /// To create the buffer, your application should call the <see cref="ID3D11Device.CreateBuffer"/> method,
        /// and pass a pointer to a <see cref="D3D11_BUFFER_DESC"/> in the pDesc parameter.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void DrawIndexedInstancedIndirect([In] P<ID3D11Buffer> pBufferForArgs, [In] UINT AlignedByteOffsetForArgs)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Buffer>, UINT, void>)_vTable[39])(thisPtr, pBufferForArgs, AlignedByteOffsetForArgs);
            }
        }

        /// <summary>
        /// Draw instanced, GPU-generated primitives.
        /// </summary>
        /// <param name="pBufferForArgs">
        /// A pointer to an <see cref="ID3D11Buffer"/>, which is a buffer containing the GPU generated primitives.
        /// </param>
        /// <param name="AlignedByteOffsetForArgs">
        /// Offset in <paramref name="pBufferForArgs"/> to the start of the GPU generated primitives.
        /// </param>
        /// <remarks>
        /// When an application creates a buffer that is associated with the <see cref="ID3D11Buffer"/> interface
        /// that <paramref name="pBufferForArgs"/> points to,
        /// the application must set the <see cref="D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS"/> flag
        /// in the <see cref="D3D11_BUFFER_DESC.MiscFlags"/> member of the <see cref="D3D11_BUFFER_DESC"/> structure that describes the buffer.
        /// To create the buffer, the application calls the <see cref="ID3D11Device.CreateBuffer"/> method
        /// and in this call passes a pointer to <see cref="D3D11_BUFFER_DESC"/> in the pDesc parameter.
        /// </remarks>
        public void DrawInstancedIndirect([In] P<ID3D11Buffer> pBufferForArgs, [In] UINT AlignedByteOffsetForArgs)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Buffer>, UINT, void>)_vTable[40])(thisPtr, pBufferForArgs, AlignedByteOffsetForArgs);
            }
        }

        /// <summary>
        /// Execute a command list from a thread group.
        /// </summary>
        /// <param name="ThreadGroupCountX">
        /// The number of groups dispatched in the x direction.
        /// <paramref name="ThreadGroupCountX"/> must be less than or equal to <see cref="D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION"/> (65535).
        /// </param>
        /// <param name="ThreadGroupCountY">
        /// The number of groups dispatched in the y direction.
        /// <paramref name="ThreadGroupCountY"/> must be less than or equal to <see cref="D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION"/> (65535).
        /// </param>
        /// <param name="ThreadGroupCountZ">
        /// The number of groups dispatched in the z direction.
        /// <paramref name="ThreadGroupCountZ"/> must be less than or equal to <see cref="D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION"/> (65535).
        /// In feature level 10 the value for <paramref name="ThreadGroupCountZ"/> must be 1.
        /// </param>
        /// <remarks>
        /// <para>
        /// You call the <see cref="Dispatch"/> method to execute commands in a compute shader.
        /// A compute shader can be run on many threads in parallel, within a thread group.
        /// Index a particular thread, within a thread group using a 3D vector given by (x,y,z).
        /// </para>
        /// <para>
        /// In the following illustration, assume a thread group with 50 threads where the size of the group is given by (5,5,2).
        /// A single thread is identified from a thread group with 50 threads in it, using the vector (4,1,1).
        /// </para>
        /// <para>
        /// The following illustration shows the relationship between the parameters passed to <see cref="Dispatch"/>,
        /// Dispatch(5,3,2), the values specified in the numthreads attribute, numthreads(10,8,3),
        /// and values that will passed to the compute shader for the thread-related system values
        /// (SV_GroupIndex, SV_DispatchThreadID, SV_GroupThreadID, SV_GroupID).
        /// </para>
        /// </remarks>
        public void Dispatch([In] UINT ThreadGroupCountX, [In] UINT ThreadGroupCountY, [In] UINT ThreadGroupCountZ)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, void>)_vTable[41])
                    (thisPtr, ThreadGroupCountX, ThreadGroupCountY, ThreadGroupCountZ);
            }
        }

        /// <summary>
        /// Execute a command list over one or more thread groups.
        /// </summary>
        /// <param name="pBufferForArgs">
        /// A pointer to an <see cref="ID3D11Buffer"/>, which must be loaded with data
        /// that matches the argument list for <see cref="Dispatch"/>.
        /// </param>
        /// <param name="AlignedByteOffsetForArgs">
        /// A byte-aligned offset between the start of the buffer and the arguments.
        /// </param>
        /// <remarks>
        /// <para>
        /// You call the <see cref="DispatchIndirect"/> method to execute commands in a compute shader.
        /// </para>
        /// <para>
        /// When an application creates a buffer that is associated with the <see cref="ID3D11Buffer"/> interface
        /// that <paramref name="pBufferForArgs"/> points to,
        /// the application must set the <see cref="D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS"/> flag
        /// in the <see cref="D3D11_BUFFER_DESC.MiscFlags"/> member of the <see cref="D3D11_BUFFER_DESC"/> structure that describes the buffer.
        /// To create the buffer, the application calls the <see cref="ID3D11Device.CreateBuffer"/> method
        /// and in this call passes a pointer to <see cref="D3D11_BUFFER_DESC"/> in the pDesc parameter.
        /// </para>
        /// </remarks>
        public void DispatchIndirect([In] P<ID3D11Buffer> pBufferForArgs, [In] UINT AlignedByteOffsetForArgs)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Buffer>, UINT, void>)_vTable[42])(thisPtr, pBufferForArgs, AlignedByteOffsetForArgs);
            }
        }

        /// <summary>
        /// Set the rasterizer state for the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="pRasterizerState">
        /// Pointer to a rasterizer-state interface (see <see cref="ID3D11RasterizerState"/>) to bind to the pipeline.
        /// </param>
        /// <remarks>
        /// <para>
        /// To create a rasterizer state interface, call <see cref="ID3D11Device.CreateRasterizerState"/>.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void RSSetState([In] P<ID3D11RasterizerState> pRasterizerState)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11RasterizerState>, void>)_vTable[43])(thisPtr, pRasterizerState);
            }
        }

        /// <summary>
        /// Bind an array of viewports to the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="NumViewports">
        /// Number of viewports to bind.
        /// </param>
        /// <param name="pViewports">
        /// An array of <see cref="D3D11_VIEWPORT"/> structures to bind to the device.
        /// See the structure page for details about how the viewport size is dependent on the device feature level
        /// which has changed between Direct3D 11 and Direct3D 10.
        /// </param>
        /// <remarks>
        /// <para>
        /// All viewports must be set atomically as one operation.
        /// Any viewports not defined by the call are disabled.
        /// </para>
        /// <para>
        /// Which viewport to use is determined by the SV_ViewportArrayIndex semantic output by a geometry shader;
        /// if a geometry shader does not specify the semantic, Direct3D will use the first viewport in the array.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Even though you specify float values to the members of the <see cref="D3D11_VIEWPORT"/> structure
        /// for the <paramref name="pViewports"/> array in a call to <see cref="RSSetViewports"/> for feature levels 9_x,
        /// <see cref="RSSetViewports"/> uses DWORDs internally.
        /// Because of this behavior, when you use a negative top left corner for the viewport,
        /// the call to <see cref="RSSetViewports"/> for feature levels 9_x fails.
        /// This failure occurs because <see cref="RSSetViewports"/> for 9_x casts the floating point values
        /// into unsigned integers without validation, which results in integer overflow.
        /// </para>
        /// </remarks>
        public void RSSetViewports([In] UINT NumViewports, [In] D3D11_VIEWPORT[]? pViewports)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D11_VIEWPORT[]?, void>)_vTable[44])(thisPtr, NumViewports, pViewports);
            }
        }

        /// <summary>
        /// Bind an array of scissor rectangles to the rasterizer stage.
        /// </summary>
        /// <param name="NumRects">
        /// Number of scissor rectangles to bind.
        /// </param>
        /// <param name="pRects">
        /// An array of scissor rectangles (see <see cref="D3D11_RECT"/>).
        /// </param>
        /// <remarks>
        /// <para>
        /// All scissor rects must be set atomically as one operation.
        /// Any scissor rects not defined by the call are disabled.
        /// </para>
        /// <para>
        /// The scissor rectangles will only be used if <see cref="D3D11_RASTERIZER_DESC.ScissorEnable"/> is set to <see cref="TRUE"/>
        /// in the rasterizer state (see <see cref="D3D11_RASTERIZER_DESC"/>).
        /// </para>
        /// <para>
        /// Which scissor rectangle to use is determined by the SV_ViewportArrayIndex semantic output by a geometry shader (see shader semantic syntax).
        /// If a geometry shader does not make use of the SV_ViewportArrayIndex semantic
        /// then Direct3D will use the first scissor rectangle in the array.
        /// </para>
        /// <para>
        /// Each scissor rectangle in the array corresponds to a viewport in an array of viewports (see <see cref="RSSetViewports"/>).
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void RSSetScissorRects([In] UINT NumRects, [In] D3D11_RECT[]? pRects)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D11_RECT[]?, void>)_vTable[45])(thisPtr, NumRects, pRects);
            }
        }

        /// <summary>
        /// Copy a region from a source resource to a destination resource.
        /// </summary>
        /// <param name="pDstResource">
        /// A pointer to the destination resource (see <see cref="ID3D11Resource"/>).
        /// </param>
        /// <param name="DstSubresource">
        /// Destination subresource index.
        /// </param>
        /// <param name="DstX">
        /// The x-coordinate of the upper left corner of the destination region.
        /// </param>
        /// <param name="DstY">
        /// The y-coordinate of the upper left corner of the destination region.
        /// For a 1D subresource, this must be zero.
        /// </param>
        /// <param name="DstZ">
        /// The z-coordinate of the upper left corner of the destination region.
        /// For a 1D or 2D subresource, this must be zero.
        /// </param>
        /// <param name="pSrcResource">
        /// A pointer to the source resource (see <see cref="ID3D11Resource"/>).
        /// </param>
        /// <param name="SrcSubresource">
        /// Source subresource index.
        /// </param>
        /// <param name="pSrcBox">
        /// <para>
        /// A pointer to a 3D box (see <see cref="D3D11_BOX"/>) that defines the source subresource that can be copied.
        /// If <see cref="NullRef{D3D11_BOX}"/>, the entire source subresource is copied.
        /// The box must fit within the source resource.
        /// </para>
        /// <para>
        /// An empty box results in a no-op.
        /// A box is empty if the top value is greater than or equal to the bottom value,
        /// or the left value is greater than or equal to the right value, or the front value is greater than or equal to the back value.
        /// When the box is empty, <see cref="CopySubresourceRegion"/> doesn't perform a copy operation.
        /// </para>
        /// </param>
        /// <remarks>
        /// <para>
        /// The source box must be within the size of the source resource.
        /// The destination offsets, (x, y, and z), allow the source box to be offset when writing into the destination resource;
        /// however, the dimensions of the source box and the offsets must be within the size of the resource.
        /// If you try and copy outside the destination resource or specify a source box that is larger than the source resource,
        /// the behavior of <see cref="CopySubresourceRegion"/> is undefined.
        /// If you created a device that supports the debug layer,
        /// the debug output reports an error on this invalid <see cref="CopySubresourceRegion"/> call.
        /// Invalid parameters to <see cref="CopySubresourceRegion"/> cause undefined behavior
        /// and might result in incorrect rendering, clipping, no copy, or even the removal of the rendering device.
        /// </para>
        /// <para>
        /// If the resources are buffers, all coordinates are in bytes; if the resources are textures, all coordinates are in texels.
        /// <see cref="D3D11CalcSubresource"/> is a helper function for calculating subresource indexes.
        /// </para>
        /// <para>
        /// <see cref="CopySubresourceRegion"/> performs the copy on the GPU (similar to a memcpy by the CPU).
        /// As a consequence, the source and destination resources:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Must be different subresources (although they can be from the same resource).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Must be the same type.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Must have compatible DXGI formats (identical or from the same type group).
        /// For example, a <see cref="DXGI_FORMAT_R32G32B32_FLOAT"/> texture can be copied to a <see cref="DXGI_FORMAT_R32G32B32_UINT"/> texture
        /// since both of these formats are in the <see cref="DXGI_FORMAT_R32G32B32_TYPELESS"/> group.
        /// <see cref="CopySubresourceRegion"/> can copy between a few format types.
        /// For more info, see Format Conversion using Direct3D 10.1.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// May not be currently mapped.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// <see cref="CopySubresourceRegion"/> only supports copy; it doesn't support any stretch, color key, or blend.
        /// <see cref="CopySubresourceRegion"/> can reinterpret the resource data between a few format types.
        /// For more info, see Format conversion using Direct3D 10.1.
        /// </para>
        /// <para>
        /// If your app needs to copy an entire resource, we recommend to use <see cref="CopyResource"/> instead.
        /// </para>
        /// <para>
        /// <see cref="CopySubresourceRegion"/> is an asynchronous call, which may be added to the command-buffer queue,
        /// this attempts to remove pipeline stalls that may occur when copying data.
        /// For more information about pipeline stalls, see performance considerations.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Applies only to feature level 9_x hardware If you use <see cref="UpdateSubresource"/>
        /// or <see cref="CopySubresourceRegion"/> to copy from a staging resource to a default resource, you can corrupt the destination contents.
        /// This occurs if you pass a <see cref="NULL"/> source box and if the source resource has different dimensions
        /// from those of the destination resource or if you use destination offsets, (x, y, and z).
        /// In this situation, always pass a source box that is the full size of the source resource.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Applies only to feature level 9_x hardware You can't use <see cref="CopySubresourceRegion"/> to copy mipmapped volume textures.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Applies only to feature levels 9_x Subresources created with the <see cref="D3D11_BIND_DEPTH_STENCIL"/> flag
        /// can only be used as a source for <see cref="CopySubresourceRegion"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If you use <see cref="CopySubresourceRegion"/> with a depth-stencil buffer or a multisampled resource, you must copy the whole subresource.
        /// In this situation, you must pass 0 to the <paramref name="DstX"/>, <paramref name="DstY"/>
        /// , and <paramref name="DstZ"/> parameters and <see cref="NULL"/> to the <paramref name="pSrcBox"/> parameter.
        /// In addition, source and destination resources, which are represented
        /// by the <paramref name="pSrcResource"/> and <paramref name="pDstResource"/> parameters, should have identical sample count values.
        /// </para>
        /// </remarks>
        public void CopySubresourceRegion([In] P<ID3D11Resource> pDstResource, [In] UINT DstSubresource, [In] UINT DstX,
            [In] UINT DstY, [In] UINT DstZ, [In] P<ID3D11Resource> pSrcResource, [In] UINT SrcSubresource, [In] in D3D11_BOX pSrcBox)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, UINT, UINT, UINT, UINT, P<ID3D11Resource>, UINT, in D3D11_BOX, void>)_vTable[46])
                    (thisPtr, pDstResource, DstSubresource, DstX, DstY, DstZ, pSrcResource, SrcSubresource, pSrcBox);
            }
        }

        /// <summary>
        /// Copy the entire contents of the source resource to the destination resource using the GPU.
        /// </summary>
        /// <param name="pDstResource">
        /// A pointer to the <see cref="ID3D11Resource"/> interface that represents the destination resource.
        /// </param>
        /// <param name="pSrcResource">
        /// A pointer to the <see cref="ID3D11Resource"/> interface that represents the source resource.
        /// </param>
        /// <remarks>
        /// <para>
        /// This method is unusual in that it causes the GPU to perform the copy operation (similar to a memcpy by the CPU).
        /// As a result, it has a few restrictions designed for improving performance.
        /// For instance, the source and destination resources:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Must be different resources.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Must be the same type.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Must have identical dimensions (including width, height, depth, and size as appropriate).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Must have compatible DXGI formats, which means the formats must be identical or at least from the same type group.
        /// For example, a <see cref="DXGI_FORMAT_R32G32B32_FLOAT"/> texture can be copied to a <see cref="DXGI_FORMAT_R32G32B32_UINT"/> texture
        /// since both of these formats are in the <see cref="DXGI_FORMAT_R32G32B32_TYPELESS"/> group.
        /// <see cref="CopyResource"/> can copy between a few format types.
        /// For more info, see Format Conversion using Direct3D 10.1.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Can't be currently mapped.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// <see cref="CopyResource"/> only supports copy; it doesn't support any stretch, color key, or blend.
        /// <see cref="CopyResource"/> can reinterpret the resource data between a few format types.
        /// For more info, see Format Conversion using Direct3D 10.1.
        /// </para>
        /// <para>
        /// You can't use an Immutable resource as a destination.
        /// You can use a depth-stencil resource as either a source or a destination provided
        /// that the feature level is <see cref="D3D_FEATURE_LEVEL_10_1"/> or greater.
        /// For feature levels 9_x, resources created with the <see cref="D3D11_BIND_DEPTH_STENCIL"/> flag
        /// can only be used as a source for <see cref="CopyResource"/>.
        /// Resources created with multisampling capability (see <see cref="DXGI_SAMPLE_DESC"/>) can be used as source and destination
        /// only if both source and destination have identical multisampled count and quality.
        /// If source and destination differ in multisampled count and quality or if one is multisampled and the other is not multisampled,
        /// the call to <see cref="CopyResource"/> fails.
        /// Use <see cref="ResolveSubresource"/> to resolve a multisampled resource to a resource that is not multisampled.
        /// </para>
        /// <para>
        /// The method is an asynchronous call, which may be added to the command-buffer queue.
        /// This attempts to remove pipeline stalls that may occur when copying data.
        /// For more info, see performance considerations.
        /// </para>
        /// <para>
        /// We recommend to use <see cref="CopySubresourceRegion"/> instead if you only need to copy a portion of the data in a resource.
        /// </para>
        /// </remarks>
        public void CopyResource([In] P<ID3D11Resource> pDstResource, [In] P<ID3D11Resource> pSrcResource)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, P<ID3D11Resource>, void>)_vTable[47])(thisPtr, pDstResource, pSrcResource);
            }
        }

        /// <summary>
        /// <para>
        /// See the Basic hologram sample.
        /// </para>
        /// <para>
        /// The CPU copies data from memory to a subresource created in non-mappable memory.
        /// </para>
        /// </summary>
        /// <param name="pDstResource">
        /// A pointer to the destination resource (see <see cref="ID3D11Resource"/>).
        /// </param>
        /// <param name="DstSubresource">
        /// A zero-based index, that identifies the destination subresource.
        /// See <see cref="D3D11CalcSubresource"/> for more details.
        /// </param>
        /// <param name="pDstBox">
        /// <para>
        /// A pointer to a box that defines the portion of the destination subresource to copy the resource data into.
        /// Coordinates are in bytes for buffers and in texels for textures.
        /// If <see cref="NullRef{D3D11_BOX}"/>, the data is written to the destination subresource with no offset.
        /// The dimensions of the source must fit the destination (see <see cref="D3D11_BOX"/>).
        /// </para>
        /// <para>
        /// An empty box results in a no-op.
        /// A box is empty if the top value is greater than or equal to the bottom value,
        /// or the left value is greater than or equal to the right value,
        /// or the front value is greater than or equal to the back value.
        /// When the box is empty, <see cref="UpdateSubresource"/> doesn't perform an update operation.
        /// </para>
        /// </param>
        /// <param name="pSrcData">
        /// A pointer to the source data in memory.
        /// </param>
        /// <param name="SrcRowPitch">
        /// The size of one row of the source data.
        /// </param>
        /// <param name="SrcDepthPitch">
        /// The size of one depth slice of source data.
        /// </param>
        /// <remarks>
        /// <para>
        /// For a shader-constant buffer; set <paramref name="pDstBox"/> to <see cref="NullRef{D3D11_BOX}"/>.
        /// It is not possible to use this method to partially update a shader-constant buffer.
        /// </para>
        /// <para>
        /// A resource cannot be used as a destination if:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// the resource is created with immutable or dynamic usage.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// the resource is created as a depth-stencil resource.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// the resource is created with multisampling capability (see <see cref="DXGI_SAMPLE_DESC"/>).
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// When <see cref="UpdateSubresource"/> returns, the application is free to change
        /// or even free the data pointed to by <paramref name="pSrcData"/>
        /// because the method has already copied/snapped away the original contents.
        /// </para>
        /// <para>
        /// The performance of <see cref="UpdateSubresource"/> depends on whether or not there is contention for the destination resource.
        /// For example, contention for a vertex buffer resource occurs
        /// when the application executes a <see cref="Draw"/> call and later calls <see cref="UpdateSubresource"/> on the same vertex buffer
        /// before the <see cref="Draw"/> call is actually executed by the GPU.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// When there is contention for the resource, <see cref="UpdateSubresource"/> will perform 2 copies of the source data.
        /// First, the data is copied by the CPU to a temporary storage space accessible by the command buffer.
        /// This copy happens before the method returns.
        /// A second copy is then performed by the GPU to copy the source data into non-mappable memory.
        /// This second copy happens asynchronously because it is executed by GPU when the command buffer is flushed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// When there is no resource contention, the behavior of <see cref="UpdateSubresource"/> is dependent on which is faster (from the CPU's perspective):
        /// copying the data to the command buffer and then having a second copy execute when the command buffer is flushed,
        /// or having the CPU copy the data to the final resource location.
        /// This is dependent on the architecture of the underlying system.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Applies only to feature level 9_x hardware If you use <see cref="UpdateSubresource"/> or <see cref="CopySubresourceRegion"/>
        /// to copy from a staging resource to a default resource, you can corrupt the destination contents.
        /// This occurs if you pass a <see cref="NULL"/> source box
        /// and if the source resource has different dimensions from those of the destination resource
        /// or if you use destination offsets, (x, y, and z).
        /// In this situation, always pass a source box that is the full size of the source resource.
        /// </para>
        /// <para>
        /// To better understand the source row pitch and source depth pitch parameters, the following illustration shows a 3D volume texture.  
        /// </para>
        /// <para>
        /// Each block in this visual represents an element of data, and the size of each element is dependent on the resource's format.
        /// For example, if the resource format is <see cref="DXGI_FORMAT_R32G32B32A32_FLOAT"/>, the size of each element would be 128 bits, or 16 bytes.
        /// This 3D volume texture has a width of two, a height of three, and a depth of four.
        /// </para>
        /// <para>
        /// To calculate the source row pitch and source depth pitch for a given resource, use the following formulas:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Source Row Pitch = [size of one element in bytes] * [number of elements in one row]
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Source Depth Pitch = [Source Row Pitch] * [number of rows (height)]
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// In the case of this example 3D volume texture where the size of each element is 16 bytes, the formulas are as follows:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Source Row Pitch = 16 * 2 = 32
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Source Depth Pitch = 16 * 2 * 3 = 96
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// The following illustration shows the resource as it is laid out in memory.
        /// </para>
        /// <para>
        /// For example, the following code snippet shows how to specify a destination region in a 2D texture.
        /// Assume the destination texture is 512x512 and the operation will copy
        /// the data pointed to by pData to [(120,100)..(200,220)] in the destination texture.
        /// Also assume that <see cref="rowPitch"/> has been initialized with the proper value (as explained above).
        /// front and back are set to 0 and 1 respectively, because by having front equal to back, the box is technically empty. 
        /// </para>
        /// <code>
        /// D3D11_BOX destRegion;
        /// destRegion.left = 120;
        /// destRegion.right = 200;
        /// destRegion.top = 100;
        /// destRegion.bottom = 220;
        /// destRegion.front = 0;
        /// destRegion.back = 1;
        /// 
        /// pd3dDeviceContext->UpdateSubresource(pDestTexture, 0, &amp;destRegion, pData, rowPitch, 0 );
        /// </code>
        /// <para>
        /// The 1D case is similar.
        /// The following snippet shows how to specify a destination region in a 1D texture.
        /// Use the same assumptions as above, except that the texture is 512 in length. 
        /// </para>
        /// <code>
        /// D3D11_BOX destRegion;
        /// destRegion.left = 120;
        /// destRegion.right = 200;
        /// destRegion.top = 0;
        /// destRegion.bottom = 1;
        /// destRegion.front = 0;
        /// destRegion.back = 1;
        /// 
        /// pd3dDeviceContext->UpdateSubresource(pDestTexture, 0, &amp;destRegion, pData, rowPitch, 0 );
        /// </code>
        /// <para>
        /// For info about various resource types and how <see cref="UpdateSubresource"/> might work with each resource type,
        /// see Introduction to a Resource in Direct3D 11.
        /// </para>
        /// <para>
        /// Calling <see cref="UpdateSubresource"/> on a Deferred Context
        /// </para>
        /// <para>
        /// If your application calls <see cref="UpdateSubresource"/> on a deferred context with a destination box
        /// —to which <paramref name="pDstBox"/> points—that has a non-(0,0,0) offset, and if the driver does not support command lists,
        /// <see cref="UpdateSubresource"/> inappropriately applies that destination-box offset to the <paramref name="pSrcData"/> parameter.
        /// To work around this behavior, use the following code:
        /// </para>
        /// <code>
        /// HRESULT UpdateSubresource_Workaround(
        ///   ID3D11Device *pDevice,
        ///   ID3D11DeviceContext *pDeviceContext,
        ///   ID3D11Resource *pDstResource,
        ///   UINT dstSubresource,
        ///   const D3D11_BOX *pDstBox,
        ///   const void *pSrcData,
        ///   UINT srcBytesPerElement,
        ///   UINT srcRowPitch,
        ///   UINT srcDepthPitch,
        ///   bool* pDidWorkAround )
        /// {
        ///      HRESULT hr = S_OK;
        ///      bool needWorkaround = false;
        ///      D3D11_DEVICE_CONTEXT_TYPE contextType = pDeviceContext-&gt;GetType();
        /// 
        ///      if( pDstBox &amp;&amp; (D3D11_DEVICE_CONTEXT_DEFERRED == contextType) )
        ///      {
        ///           D3D11_FEATURE_DATA_THREADING threadingCaps = { FALSE, FALSE };
        /// 
        ///           hr = pDevice-&gt;CheckFeatureSupport( D3D11_FEATURE_THREADING, &amp;threadingCaps, sizeof(threadingCaps) );
        ///           if( SUCCEEDED(hr) )
        ///           {
        ///                if( !threadingCaps.DriverCommandLists )
        ///                {
        ///                     needWorkaround = true;
        ///                }
        ///           }
        ///      }
        /// 
        ///      const void* pAdjustedSrcData = pSrcData;
        /// 
        ///      if( needWorkaround )
        ///      {
        ///           D3D11_BOX alignedBox = *pDstBox;
        /// 		
        ///           // convert from pixels to blocks
        ///           if( m_bBC )
        ///           {
        ///                alignedBox.left     /= 4;
        ///                alignedBox.right    /= 4;
        ///                alignedBox.top      /= 4;
        ///                alignedBox.bottom   /= 4;
        ///           }
        /// 
        ///           pAdjustedSrcData = ((const BYTE*)pSrcData) - (alignedBox.front * srcDepthPitch) - (alignedBox.top * srcRowPitch) - (alignedBox.left * srcBytesPerElement);
        ///      }
        /// 
        ///      pDeviceContext-&gt;UpdateSubresource( pDstResource, dstSubresource, pDstBox, pAdjustedSrcData, srcRowPitch, srcDepthPitch );
        /// 
        ///      if( pDidWorkAround )
        ///      {
        ///           *pDidWorkAround = needWorkaround;
        ///      }
        /// 
        ///      return hr;
        /// }
        /// </code>
        /// </remarks>
        public void UpdateSubresource([In] P<ID3D11Resource> pDstResource, [In] UINT DstSubresource, [In] in D3D11_BOX pDstBox,
            [In] IntPtr pSrcData, [In] UINT SrcRowPitch, [In] UINT SrcDepthPitch)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, UINT, in D3D11_BOX, IntPtr, UINT, UINT, void>)_vTable[48])
                    (thisPtr, pDstResource, DstSubresource, pDstBox, pSrcData, SrcRowPitch, SrcDepthPitch);
            }
        }

        /// <summary>
        /// Copies data from a buffer holding variable length data.
        /// </summary>
        /// <param name="pDstBuffer">
        /// Pointer to <see cref="ID3D11Buffer"/>.
        /// This can be any buffer resource that other copy commands,
        /// such as <see cref="CopyResource"/> or <see cref="CopySubresourceRegion"/>, are able to write to.
        /// </param>
        /// <param name="DstAlignedByteOffset">
        /// Offset from the start of <paramref name="pDstBuffer"/> to write 32-bit UINT structure (vertex) count from <paramref name="pSrcView"/>.
        /// </param>
        /// <param name="pSrcView">
        /// Pointer to an <see cref="ID3D11UnorderedAccessView"/> of a Structured Buffer resource
        /// created with either <see cref="D3D11_BUFFER_UAV_FLAG_APPEND"/> or <see cref="D3D11_BUFFER_UAV_FLAG_COUNTER"/> specified when the UAV was created.
        /// These types of resources have hidden counters tracking "how many" records have been written.
        /// </param>
        public void CopyStructureCount([In] P<ID3D11Buffer> pDstBuffer, [In] UINT DstAlignedByteOffset, [In] P<ID3D11UnorderedAccessView> pSrcView)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Buffer>, UINT, P<ID3D11UnorderedAccessView>, void>)_vTable[49])
                    (thisPtr, pDstBuffer, DstAlignedByteOffset, pSrcView);
            }
        }

        /// <summary>
        /// Set all the elements in a render target to one value.
        /// </summary>
        /// <param name="pRenderTargetView">
        /// Pointer to the render target.
        /// </param>
        /// <param name="ColorRGBA">
        /// A 4-component array that represents the color to fill the render target with.
        /// </param>
        /// <remarks>
        /// <para>
        /// Applications that wish to clear a render target to a specific integer value bit pattern
        /// should render a screen-aligned quad instead of using this method.
        /// The reason for this is because this method accepts as input a floating point value,
        /// which may not have the same bit pattern as the original integer.
        /// </para>
        /// <para>
        /// Differences between Direct3D 9 and Direct3D 11/10:
        /// </para>
        /// <para>
        /// Unlike Direct3D 9, the full extent of the resource view is always cleared. Viewport and scissor settings are not applied.
        /// </para>
        /// <para>
        /// When using D3D_FEATURE_LEVEL_9_x, <see cref="ClearRenderTargetView"/> only clears the first array slice in the render target view.
        /// This can impact (for example) cube map rendering scenarios.
        /// Applications should create a render target view for each face or array slice, then clear each view individually.
        /// </para>
        /// </remarks>
        public void ClearRenderTargetView([In] P<ID3D11RenderTargetView> pRenderTargetView, [In] FLOAT[] ColorRGBA)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11RenderTargetView>, FLOAT[], void>)_vTable[50])(thisPtr, pRenderTargetView, ColorRGBA);
            }
        }

        /// <summary>
        /// Clears an unordered access resource with bit-precise values.
        /// </summary>
        /// <param name="pUnorderedAccessView">
        /// The <see cref="ID3D11UnorderedAccessView"/> to clear.
        /// </param>
        /// <param name="Values">
        /// Values to copy to corresponding channels, see remarks.
        /// </param>
        /// <remarks>
        /// This API copies the lower ni bits from each array element i to the corresponding channel,
        /// where ni is the number of bits in the ith channel of the resource format
        /// (for example, R8G8B8_FLOAT has 8 bits for the first 3 channels).
        /// This works on any UAV with no format conversion.
        /// For a raw or structured buffer view, only the first array element value is used.
        /// </remarks>
        public void ClearUnorderedAccessViewUint([In] P<ID3D11UnorderedAccessView> pUnorderedAccessView, [In] UINT[] Values)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11UnorderedAccessView>, UINT[], void>)_vTable[51])(thisPtr, pUnorderedAccessView, Values);
            }
        }

        /// <summary>
        /// Clears an unordered access resource with a float value.
        /// </summary>
        /// <param name="pUnorderedAccessView">
        /// The <see cref="ID3D11UnorderedAccessView"/> to clear.
        /// </param>
        /// <param name="Values">
        /// Values to copy to corresponding channels, see remarks.
        /// </param>
        /// <remarks>
        /// This API works on FLOAT, UNORM, and SNORM unordered access views (UAVs),
        /// with format conversion from FLOAT to *NORM where appropriate.
        /// On other UAVs, the operation is invalid and the call will not reach the driver.
        /// </remarks>
        public void ClearUnorderedAccessViewFloat([In] P<ID3D11UnorderedAccessView> pUnorderedAccessView, [In] FLOAT[] Values)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11UnorderedAccessView>, FLOAT[], void>)_vTable[52])(thisPtr, pUnorderedAccessView, Values);
            }
        }

        /// <summary>
        /// Clears the depth-stencil resource.
        /// </summary>
        /// <param name="pDepthStencilView">
        /// Pointer to the depth stencil to be cleared.
        /// </param>
        /// <param name="ClearFlags">
        /// Identify the type of data to clear (see <see cref="D3D11_CLEAR_FLAG"/>).
        /// </param>
        /// <param name="Depth">
        /// Clear the depth buffer with this value.
        /// This value will be clamped between 0 and 1.
        /// </param>
        /// <param name="Stencil">
        /// Clear the stencil buffer with this value.
        /// </param>
        /// <remarks>
        /// <para>
        /// Differences between Direct3D 9 and Direct3D 11/10:
        /// </para>
        /// <para>
        /// Unlike Direct3D 9, the full extent of the resource view is always cleared.
        /// Viewport and scissor settings are not applied.
        /// </para>
        /// </remarks>
        public void ClearDepthStencilView([In] P<ID3D11DepthStencilView> pDepthStencilView,
            [In] D3D11_CLEAR_FLAG ClearFlags, [In] FLOAT Depth, [In] UINT8 Stencil)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11DepthStencilView>, D3D11_CLEAR_FLAG, FLOAT, UINT8, void>)_vTable[53])
                    (thisPtr, pDepthStencilView, ClearFlags, Depth, Stencil);
            }
        }

        /// <summary>
        /// Generates mipmaps for the given shader resource.
        /// </summary>
        /// <param name="pShaderResourceView">
        /// A pointer to an <see cref="ID3D11ShaderResourceView"/> interface that represents the shader resource.
        /// </param>
        /// <remarks>
        /// <para>
        /// You can call <see cref="GenerateMips"/> on any shader-resource view to generate the lower mipmap levels for the shader resource.
        /// <see cref="GenerateMips"/> uses the largest mipmap level of the view to recursively
        /// generate the lower levels of the mip and stops with the smallest level that is specified by the view.
        /// If the base resource wasn't created with <see cref="D3D11_BIND_RENDER_TARGET"/>,
        /// <see cref="D3D11_BIND_SHADER_RESOURCE"/>, and <see cref="D3D11_RESOURCE_MISC_GENERATE_MIPS"/>,
        /// the call to <see cref="GenerateMips"/> has no effect.
        /// </para>
        /// <para>
        /// Feature levels 9.1, 9.2, and 9.3 can't support automatic generation of mipmaps for 3D (volume) textures.
        /// </para>
        /// <para>
        /// Video adapters that support feature level 9.1 and higher support generating mipmaps if you use any of these formats:
        /// </para>
        /// <code>
        /// DXGI_FORMAT_R8G8B8A8_UNORM
        /// DXGI_FORMAT_R8G8B8A8_UNORM_SRGB
        /// DXGI_FORMAT_B5G6R5_UNORM
        /// DXGI_FORMAT_B8G8R8A8_UNORM
        /// DXGI_FORMAT_B8G8R8A8_UNORM_SRGB
        /// DXGI_FORMAT_B8G8R8X8_UNORM
        /// DXGI_FORMAT_B8G8R8X8_UNORM_SRGB
        /// </code>
        /// <para>
        /// Video adapters that support feature level 9.2 and higher support generating mipmaps
        /// if you use any of these formats in addition to any of the formats for feature level 9.1:
        /// </para>
        /// <code>
        /// DXGI_FORMAT_R16G16B16A16_FLOAT
        /// DXGI_FORMAT_R16G16B16A16_UNORM
        /// DXGI_FORMAT_R16G16_FLOAT
        /// DXGI_FORMAT_R16G16_UNORM
        /// DXGI_FORMAT_R32_FLOAT
        /// </code>
        /// <para>
        /// Video adapters that support feature level 9.3 and higher support generating mipmaps
        /// if you use any of these formats in addition to any of the formats for feature levels 9.1 and 9.2:
        /// </para>
        /// <code>
        /// DXGI_FORMAT_R32G32B32A32_FLOAT
        /// DXGI_FORMAT_B4G4R4A4 (optional)
        /// </code>
        /// <para>
        /// Video adapters that support feature level 10 and higher support generating mipmaps
        /// if you use any of these formats in addition to any of the formats for feature levels 9.1, 9.2, and 9.3:
        /// </para>
        /// <code>
        /// DXGI_FORMAT_R32G32B32_FLOAT (optional)
        /// DXGI_FORMAT_R16G16B16A16_SNORM
        /// DXGI_FORMAT_R32G32_FLOAT
        /// DXGI_FORMAT_R10G10B10A2_UNORM
        /// DXGI_FORMAT_R11G11B10_FLOAT
        /// DXGI_FORMAT_R8G8B8A8_SNORM
        /// DXGI_FORMAT_R16G16_SNORM
        /// DXGI_FORMAT_R8G8_UNORM
        /// DXGI_FORMAT_R8G8_SNORM
        /// DXGI_FORMAT_R16_FLOAT
        /// DXGI_FORMAT_R16_UNORM
        /// DXGI_FORMAT_R16_SNORM
        /// DXGI_FORMAT_R8_UNORM
        /// DXGI_FORMAT_R8_SNORM
        /// DXGI_FORMAT_A8_UNORM
        /// DXGI_FORMAT_B5G5R5A1_UNORM(optional)
        /// </code>
        /// <para>
        /// For all other unsupported formats, <see cref="GenerateMips"/> will silently fail.
        /// </para>
        /// </remarks>
        public void GenerateMips([In] P<ID3D11ShaderResourceView> pShaderResourceView)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11ShaderResourceView>, void>)_vTable[54])(thisPtr, pShaderResourceView);
            }
        }

        /// <summary>
        /// Sets the minimum level-of-detail (LOD) for a resource.
        /// </summary>
        /// <param name="pResource">
        /// A pointer to an <see cref="ID3D11Resource"/> that represents the resource.
        /// </param>
        /// <param name="MinLOD">
        /// The level-of-detail, which ranges between 0 and the maximum number of mipmap levels of the resource.
        /// For example, the maximum number of mipmap levels of a 1D texture
        /// is specified in the <see cref="D3D11_TEXTURE1D_DESC.MipLevels"/> member of the <see cref="D3D11_TEXTURE1D_DESC"/> structure.
        /// </param>
        /// <para>
        /// To use a resource with <see cref="SetResourceMinLOD"/>,
        /// you must set the <see cref="D3D11_RESOURCE_MISC_RESOURCE_CLAMP"/> flag when you create that resource.
        /// </para>
        /// <para>
        /// For Direct3D 10 and Direct3D 10.1, when sampling from a texture resource in a shader,
        /// the sampler can define a minimum LOD clamp to force sampling from less detailed mip levels.
        /// For Direct3D 11, this functionality is extended from the sampler to the entire resource.
        /// Therefore, the application can specify the highest-resolution mip level of a resource that is available for access.
        /// This restricts the set of mip levels that are required to be resident in GPU memory, thereby saving memory.
        /// </para>
        /// <para>
        /// The set of mip levels resident per-resource in GPU memory can be specified by the user.
        /// </para>
        /// <para>
        /// Minimum LOD affects all of the resident mip levels. Therefore, only the resident mip levels can be updated and read from.
        /// </para>
        /// <para>
        /// All methods that access texture resources must adhere to minimum LOD clamps.
        /// </para>
        /// <para>
        /// Empty-set accesses are handled as out-of-bounds cases.
        /// </para>
        public void SetResourceMinLOD([In] P<ID3D11Resource> pResource, [In] FLOAT MinLOD)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, FLOAT, void>)_vTable[55])(thisPtr, pResource, MinLOD);
            }
        }

        /// <summary>
        /// Gets the minimum level-of-detail (LOD).
        /// </summary>
        /// <param name="pResource">
        /// A pointer to an <see cref="ID3D11Resource"/> which represents the resource.
        /// </param>
        /// <returns>
        /// Returns the minimum LOD.
        /// </returns>
        public FLOAT GetResourceMinLOD([In] P<ID3D11Resource> pResource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, FLOAT>)_vTable[56])(thisPtr, pResource);
            }
        }

        /// <summary>
        /// Copy a multisampled resource into a non-multisampled resource.
        /// </summary>
        /// <param name="pDstResource">
        /// Destination resource.
        /// Must be a created with the <see cref="D3D11_USAGE_DEFAULT"/> flag and be single-sampled.
        /// See <see cref="ID3D11Resource"/>.
        /// </param>
        /// <param name="DstSubresource">
        /// A zero-based index, that identifies the destination subresource.
        /// Use <see cref="D3D11CalcSubresource"/> to calculate the index.
        /// </param>
        /// <param name="pSrcResource">
        /// Source resource. Must be multisampled.
        /// </param>
        /// <param name="SrcSubresource">
        /// The source subresource of the source resource.
        /// </param>
        /// <param name="Format">
        /// A <see cref="DXGI_FORMAT"/> that indicates how the multisampled resource will be resolved to a single-sampled resource.
        /// See remarks.
        /// </param>
        /// <remarks>
        /// <para>
        /// This API is most useful when re-using the resulting rendertarget of one render pass as an input to a second render pass.
        /// </para>
        /// <para>
        /// The source and destination resources must be the same resource type and have the same dimensions.
        /// In addition, they must have compatible formats. There are three scenarios for this:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Scenario
        /// </term>
        /// <term>
        /// Requirements
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Source and destination are prestructured and typed
        /// </term>
        /// <term>
        /// Both the source and destination must have identical formats and that format must be specified in the <paramref name="Format"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// One resource is prestructured and typed and the other is prestructured and typeless
        /// </term>
        /// <term>
        /// The typed resource must have a format that is compatible with the typeless resource
        /// (i.e. the typed resource is <see cref="DXGI_FORMAT_R32_FLOAT"/> and the typeless resource is <see cref="DXGI_FORMAT_R32_TYPELESS"/>).
        /// The format of the typed resource must be specified in the Format parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Source and destination are prestructured and typeless
        /// </term>
        /// <term>
        /// <para>
        /// Both the source and destination must have the same typeless format
        /// (i.e. both must have <see cref="DXGI_FORMAT_R32_TYPELESS"/>),
        /// and the <paramref name="Format"/> parameter must specify a format that is compatible with the source and destination
        /// (i.e. if both are <see cref="DXGI_FORMAT_R32_TYPELESS"/>
        /// then <see cref="DXGI_FORMAT_R32_FLOAT"/> could be specified in the <paramref name="Format"/> parameter).
        /// </para>
        /// <para>
        /// For example, given the <see cref="DXGI_FORMAT_R16G16B16A16_TYPELESS"/> format:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The source (or dest) format could be <see cref="DXGI_FORMAT_R16G16B16A16_UNORM"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The dest (or source) format could be <see cref="DXGI_FORMAT_R16G16B16A16_FLOAT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </term>
        /// </item>
        /// </list>
        /// </remarks>
        public void ResolveSubresource([In] P<ID3D11Resource> pDstResource, [In] UINT DstSubresource,
            [In] P<ID3D11Resource> pSrcResource, [In] UINT SrcSubresource, [In] DXGI_FORMAT Format)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, UINT, P<ID3D11Resource>, UINT, DXGI_FORMAT, void>)_vTable[57])
                    (thisPtr, pDstResource, DstSubresource, pSrcResource, SrcSubresource, Format);
            }
        }

        /// <summary>
        /// Queues commands from a command list onto a device.
        /// </summary>
        /// <param name="pCommandList">
        /// A pointer to an <see cref="ID3D11CommandList"/> interface that encapsulates a command list.
        /// </param>
        /// <param name="RestoreContextState">
        /// A Boolean flag that determines whether the target context state
        /// is saved prior to and restored after the execution of a command list.
        /// Use <see cref="TRUE"/> to indicate that the runtime needs to save and restore the state.
        /// Use <see cref="FALSE"/> to indicate that no state shall be saved or restored,
        /// which causes the target context to return to its default state after the command list executes.
        /// Applications should typically use <see cref="FALSE"/>
        /// unless they will restore the state to be nearly equivalent to the state
        /// that the runtime would restore if <see cref="TRUE"/> were passed.
        /// When applications use <see cref="FALSE"/>, they can avoid unnecessary and inefficient state transitions.
        /// </param>
        /// <remarks>
        /// <para>
        /// Use this method to play back a command list that was recorded by a deferred context on any thread.
        /// </para>
        /// <para>
        /// A call to <see cref="ExecuteCommandList"/> of a command list from a deferred context
        /// onto the immediate context is required for the recorded commands to be executed on the graphics processing unit (GPU).
        /// A call to <see cref="ExecuteCommandList"/> of a command list from a deferred context
        /// onto another deferred context can be used to merge recorded lists.
        /// But to run the commands from the merged deferred command list on the GPU,
        /// you need to execute them on the immediate context.
        /// </para>
        /// <para>
        /// This method performs some runtime validation related to queries.
        /// Queries that are begun in a device context cannot be manipulated indirectly by executing a command list
        /// (that is, Begin or End was invoked against the same query by the deferred context which generated the command list).
        /// If such a condition occurs, the <see cref="ExecuteCommandList"/> method does not execute the command list.
        /// However, the state of the device context is still maintained,
        /// as would be expected (<see cref="ClearState"/> is performed,
        /// unless the application indicates to preserve the device context state).
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void ExecuteCommandList([In] P<ID3D11CommandList> pCommandList, [In] BOOL RestoreContextState)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CommandList>, BOOL, void>)_vTable[58])(thisPtr, pCommandList, RestoreContextState);
            }
        }

        /// <summary>
        /// Bind an array of shader resources to the hull-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting shader resources to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// Number of shader resources to set.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to set to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// If an overlapping resource view is already bound to an output slot, such as a render target,
        /// then the method will fill the destination shader resource slot with <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// For information about creating shader-resource views, see <see cref="ID3D11Device.CreateShaderResourceView"/>.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void HSSetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [In] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[59])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Set a hull shader to the device.
        /// </summary>
        /// <param name="pHullShader">
        /// Pointer to a hull shader (see <see cref="ID3D11HullShader"/>).
        /// Passing in <see cref="NULL"/> disables the shader for this pipeline stage.
        /// </param>
        /// <param name="ppClassInstances">
        /// A pointer to an array of class-instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// Each interface used by a shader must have a corresponding class instance or the shader will get disabled.
        /// Set <paramref name="ppClassInstances"/> to <see langword="null"/> if the shader does not use any interfaces.
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance interfaces in the array.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The maximum number of instances a shader can have is 256.
        /// </para>
        /// </remarks>
        public void HSSetShader([In] P<ID3D11HullShader> pHullShader, [In] P<ID3D11ClassInstance>[]? ppClassInstances, [In] UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11HullShader>, P<ID3D11ClassInstance>[]?, UINT, void>)_vTable[60])
                    (thisPtr, pHullShader, ppClassInstances, NumClassInstances);
            }
        }

        /// <summary>
        /// Set an array of sampler states to the hull-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting samplers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers in the array.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Pointer to an array of sampler-state interfaces (see <see cref="ID3D11SamplerState"/>). See Remarks.
        /// </param>
        /// <remarks>
        /// <para>
        /// Any sampler may be set to <see cref="NULL"/>; this invokes the default state, which is defined to be the following.
        /// </para>
        /// <code>
        /// //Default sampler state:
        /// D3D11_SAMPLER_DESC SamplerDesc;
        /// SamplerDesc.Filter = D3D11_FILTER_MIN_MAG_MIP_LINEAR;
        /// SamplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.MipLODBias = 0;
        /// SamplerDesc.MaxAnisotropy = 1;
        /// SamplerDesc.ComparisonFunc = D3D11_COMPARISON_NEVER;
        /// SamplerDesc.BorderColor[0] = 1.0f;
        /// SamplerDesc.BorderColor[1] = 1.0f;
        /// SamplerDesc.BorderColor[2] = 1.0f;
        /// SamplerDesc.BorderColor[3] = 1.0f;
        /// SamplerDesc.MinLOD = -FLT_MAX;
        /// SamplerDesc.MaxLOD = FLT_MAX;
        /// </code>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void HSSetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [In] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[61])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Sets the constant buffers used by the hull-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the zero-based array to begin setting constant buffers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to set (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffers (see <see cref="ID3D11Buffer"/>) being given to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// can bind a larger number of <see cref="ID3D11Buffer"/> resources to the shader
        /// than the maximum constant buffer size that is supported by shaders (4096 constants – 432-bit components each).
        /// When you bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer,
        /// as if 4096 constants is the full size of the buffer.
        /// </para>
        /// <para>
        /// If the application wants the shader to access other parts of the buffer,
        /// it must call the <see cref="HSSetConstantBuffers1"/> method instead.
        /// </para>
        /// </remarks>
        public void HSSetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [In] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[62])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Bind an array of shader resources to the domain-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting shader resources to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// Number of shader resources to set.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to set to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// If an overlapping resource view is already bound to an output slot, such as a render target,
        /// then the method will fill the destination shader resource slot with <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// For information about creating shader-resource views, see <see cref="ID3D11Device.CreateShaderResourceView"/>.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void DSSetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [In] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[63])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Set a domain shader to the device.
        /// </summary>
        /// <param name="pDomainShader">
        /// Pointer to a domain shader (see <see cref="ID3D11DomainShader"/>).
        /// Passing in <see cref="NULL"/> disables the shader for this pipeline stage.
        /// </param>
        /// <param name="ppClassInstances">
        /// A pointer to an array of class-instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// Each interface used by a shader must have a corresponding class instance or the shader will get disabled.
        /// Set <paramref name="ppClassInstances"/> to <see langword="null"/> if the shader does not use any interfaces.
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance interfaces in the array.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The maximum number of instances a shader can have is 256.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void DSSetShader([In] P<ID3D11DomainShader> pDomainShader, [In] P<ID3D11ClassInstance>[]? ppClassInstances, [In] UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11DomainShader>, P<ID3D11ClassInstance>[]?, UINT, void>)_vTable[64])
                    (thisPtr, pDomainShader, ppClassInstances, NumClassInstances);
            }
        }

        /// <summary>
        /// Set an array of sampler states to the domain-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting samplers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers in the array.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Pointer to an array of sampler-state interfaces (see <see cref="ID3D11SamplerState"/>). See Remarks.
        /// </param>
        /// <remarks>
        /// <para>
        /// Any sampler may be set to <see cref="NULL"/>; this invokes the default state, which is defined to be the following.
        /// </para>
        /// <code>
        /// //Default sampler state:
        /// D3D11_SAMPLER_DESC SamplerDesc;
        /// SamplerDesc.Filter = D3D11_FILTER_MIN_MAG_MIP_LINEAR;
        /// SamplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.MipLODBias = 0;
        /// SamplerDesc.MaxAnisotropy = 1;
        /// SamplerDesc.ComparisonFunc = D3D11_COMPARISON_NEVER;
        /// SamplerDesc.BorderColor[0] = 1.0f;
        /// SamplerDesc.BorderColor[1] = 1.0f;
        /// SamplerDesc.BorderColor[2] = 1.0f;
        /// SamplerDesc.BorderColor[3] = 1.0f;
        /// SamplerDesc.MinLOD = -FLT_MAX;
        /// SamplerDesc.MaxLOD = FLT_MAX;
        /// </code>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void DSSetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [In] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[65])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Sets the constant buffers used by the domain-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the zero-based array to begin setting constant buffers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to set (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffers (see <see cref="ID3D11Buffer"/>) being given to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// can bind a larger number of <see cref="ID3D11Buffer"/> resources to the shader than the maximum constant buffer size
        /// that is supported by shaders (4096 constants – 432-bit components each).
        /// When you bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer,
        /// as if 4096 constants is the full size of the buffer.
        /// </para>
        /// <para>
        /// If the application wants the shader to access other parts of the buffer,
        /// it must call the <see cref="DSSetConstantBuffers1"/> method instead.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void DSSetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [In] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[66])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Bind an array of shader resources to the compute-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting shader resources to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// Number of shader resources to set.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to set to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// If an overlapping resource view is already bound to an output slot, such as a render target,
        /// then the method will fill the destination shader resource slot with <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// For information about creating shader-resource views, see <see cref="ID3D11Device.CreateShaderResourceView"/>.
        /// </para>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void CSSetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [In] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[67])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Sets an array of views for an unordered resource.
        /// </summary>
        /// <param name="StartSlot">
        /// Index of the first element in the zero-based array to begin setting
        /// (ranges from 0 to <see cref="D3D11_1_UAV_SLOT_COUNT"/> - 1).
        /// <see cref="D3D11_1_UAV_SLOT_COUNT"/> is defined as 64.
        /// </param>
        /// <param name="NumUAVs">
        /// Number of views to set (ranges from 0 to <see cref="D3D11_1_UAV_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppUnorderedAccessViews">
        /// A pointer to an array of <see cref="ID3D11UnorderedAccessView"/> pointers to be set by the method.
        /// </param>
        /// <param name="pUAVInitialCounts">
        /// An array of append and consume buffer offsets.
        /// A value of -1 indicates to keep the current offset.
        /// Any other values set the hidden counter for that appendable and consumable UAV.
        /// <paramref name="pUAVInitialCounts"/> is only relevant for UAVs
        /// that were created with either <see cref="D3D11_BUFFER_UAV_FLAG_APPEND"/> or <see cref="D3D11_BUFFER_UAV_FLAG_COUNTER"/> specified
        /// when the UAV was created; otherwise, the argument is ignored.
        /// </param>
        /// <remarks>
        /// Windows Phone 8: This API is supported.
        /// </remarks>
        public void CSSetUnorderedAccessViews([In] UINT StartSlot, [In] UINT NumUAVs,
            [In] P<ID3D11UnorderedAccessView>[]? ppUnorderedAccessViews, [In] UINT[]? pUAVInitialCounts)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11UnorderedAccessView>[]?, UINT[]?, void>)_vTable[68])
                    (thisPtr, StartSlot, NumUAVs, ppUnorderedAccessViews, pUAVInitialCounts);
            }
        }

        /// <summary>
        /// Set a compute shader to the device.
        /// </summary>
        /// <param name="pDomainShader">
        /// Pointer to a compute shader (see <see cref="ID3D11ComputeShader"/>).
        /// Passing in <see cref="NULL"/> disables the shader for this pipeline stage.
        /// </param>
        /// <param name="ppClassInstances">
        /// A pointer to an array of class-instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// Each interface used by a shader must have a corresponding class instance or the shader will get disabled.
        /// Set <paramref name="ppClassInstances"/> to <see langword="null"/> if the shader does not use any interfaces.
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance interfaces in the array.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The maximum number of instances a shader can have is 256.
        /// </para>
        /// </remarks>
        public void CSSetShader([In] P<ID3D11ComputeShader> pDomainShader, [In] P<ID3D11ClassInstance>[]? ppClassInstances, [In] UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11ComputeShader>, P<ID3D11ClassInstance>[]?, UINT, void>)_vTable[69])
                    (thisPtr, pDomainShader, ppClassInstances, NumClassInstances);
            }
        }

        /// <summary>
        /// Set an array of sampler states to the compute-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting samplers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers in the array.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Pointer to an array of sampler-state interfaces (see <see cref="ID3D11SamplerState"/>). See Remarks.
        /// </param>
        /// <remarks>
        /// <para>
        /// Any sampler may be set to <see cref="NULL"/>; this invokes the default state, which is defined to be the following.
        /// </para>
        /// <code>
        /// //Default sampler state:
        /// D3D11_SAMPLER_DESC SamplerDesc;
        /// SamplerDesc.Filter = D3D11_FILTER_MIN_MAG_MIP_LINEAR;
        /// SamplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_CLAMP;
        /// SamplerDesc.MipLODBias = 0;
        /// SamplerDesc.MaxAnisotropy = 1;
        /// SamplerDesc.ComparisonFunc = D3D11_COMPARISON_NEVER;
        /// SamplerDesc.BorderColor[0] = 1.0f;
        /// SamplerDesc.BorderColor[1] = 1.0f;
        /// SamplerDesc.BorderColor[2] = 1.0f;
        /// SamplerDesc.BorderColor[3] = 1.0f;
        /// SamplerDesc.MinLOD = -FLT_MAX;
        /// SamplerDesc.MaxLOD = FLT_MAX;
        /// </code>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// </remarks>
        public void CSSetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [In] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[70])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Sets the constant buffers used by the compute-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the zero-based array to begin setting constant buffers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to set (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffers (see <see cref="ID3D11Buffer"/>) being given to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// The method will hold a reference to the interfaces passed in.
        /// This differs from the device state behavior in Direct3D 10.
        /// </para>
        /// <para>
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// can bind a larger number of <see cref="ID3D11Buffer"/> resources to the shader than the maximum constant buffer size
        /// that is supported by shaders (4096 constants – 4*32-bit components each).
        /// When you bind such a large buffer, the shader can access only the first 4096 4*32-bit component constants in the buffer,
        /// as if 4096 constants is the full size of the buffer.
        /// </para>
        /// <para>
        /// If the application wants the shader to access other parts of the buffer,
        /// it must call the <see cref="CSSetConstantBuffers1"/> method instead.
        /// </para>
        /// </remarks>
        public void CSSetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [In] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[71])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Get the constant buffers used by the vertex shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin retrieving constant buffers from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to retrieve
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffer interface pointers (see <see cref="ID3D11Buffer"/>) to be returned by the method.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void VSGetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [Out] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[72])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Get the pixel shader resources.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin getting shader resources from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// The number of resources to get from the device.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to be returned by the device.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void PSGetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [Out] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[73])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Get the pixel shader currently set on the device.
        /// </summary>
        /// <param name="ppPixelShader">
        /// Address of a pointer to a pixel shader (see <see cref="ID3D11PixelShader"/>) to be returned by the method.
        /// </param>
        /// <param name="ppClassInstances">
        /// Pointer to an array of class instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance elements in the array.
        /// </param>
        /// <remarks>
        /// <para>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void PSGetShader([Out] out P<ID3D11PixelShader> ppPixelShader, [Out] P<ID3D11ClassInstance>[]? ppClassInstances, [In][Out] ref UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11PixelShader>, P<ID3D11ClassInstance>[]?, ref UINT, void>)_vTable[74])
                    (thisPtr, out ppPixelShader, ppClassInstances, ref NumClassInstances);
            }
        }

        /// <summary>
        /// Get an array of sampler states from the pixel shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting samplers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers in the array.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Array of sampler-state interface pointers (see <see cref="ID3D11SamplerState"/>) to be returned by the device.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void PSGetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [Out] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[75])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Get the vertex shader currently set on the device.
        /// </summary>
        /// <param name="ppVertexShader">
        /// Address of a pointer to a vertex shader (see <see cref="ID3D11VertexShader"/>) to be returned by the method.
        /// </param>
        /// <param name="ppClassInstances">
        /// Pointer to an array of class instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance elements in the array.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void VSGetShader([Out] out P<ID3D11VertexShader> ppVertexShader, [Out] P<ID3D11ClassInstance>[]? ppClassInstances, [In][Out] ref UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11VertexShader>, P<ID3D11ClassInstance>[]?, ref UINT, void>)_vTable[76])
                    (thisPtr, out ppVertexShader, ppClassInstances, ref NumClassInstances);
            }
        }

        /// <summary>
        /// Get the constant buffers used by the pixel shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin retrieving constant buffers from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to retrieve
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffer interface pointers (see <see cref="ID3D11Buffer"/>) to be returned by the method.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void PSGetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [Out] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[77])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Get a pointer to the input-layout object that is bound to the input-assembler stage.
        /// </summary>
        /// <param name="ppInputLayout">
        /// A pointer to the input-layout object (see <see cref="ID3D11InputLayout"/>),
        /// which describes the input buffers that will be read by the IA stage.
        /// </param>
        /// <remarks>
        /// <para>
        /// For information about creating an input-layout object, see Creating the Input-Layout Object.
        /// </para>
        /// <para>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </para>
        /// </remarks>
        public void IAGetInputLayout([Out] out P<ID3D11InputLayout> ppInputLayout)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11InputLayout>, HRESULT>)_vTable[78])(thisPtr, out ppInputLayout);
            }
        }

        /// <summary>
        /// Get the vertex buffers bound to the input-assembler stage.
        /// </summary>
        /// <param name="StartSlot">
        /// The input slot of the first vertex buffer to get.
        /// The first vertex buffer is explicitly bound to the start slot;
        /// this causes each additional vertex buffer in the array to be implicitly bound to each subsequent input slot.
        /// The maximum of 16 or 32 input slots (ranges from 0 to <see cref="D3D11_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT"/> - 1) are available;
        /// the maximum number of input slots depends on the feature level.
        /// </param>
        /// <param name="NumBuffers">
        /// The number of vertex buffers to get starting at the offset.
        /// The number of buffers (plus the starting slot) cannot exceed the total number of IA-stage input slots.
        /// </param>
        /// <param name="ppVertexBuffers">
        /// A pointer to an array of vertex buffers returned by the method (see <see cref="ID3D11Buffer"/>).
        /// </param>
        /// <param name="pStrides">
        /// Pointer to an array of stride values returned by the method; one stride value for each buffer in the vertex-buffer array.
        /// Each stride value is the size (in bytes) of the elements that are to be used from that vertex buffer.
        /// </param>
        /// <param name="pOffsets">
        /// Pointer to an array of offset values returned by the method; one offset value for each buffer in the vertex-buffer array.
        /// Each offset is the number of bytes between the first element of a vertex buffer and the first element that will be used.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void IAGetVertexBuffers([In] UINT StartSlot, [In] UINT NumBuffers,
            [Out] P<ID3D11Buffer>[]? ppVertexBuffers, [Out] UINT[]? pStrides, [Out] UINT[]? pOffsets)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, UINT[]?, UINT[]?, void>)_vTable[79])
                    (thisPtr, StartSlot, NumBuffers, ppVertexBuffers, pStrides, pOffsets);
            }
        }

        /// <summary>
        /// Get a pointer to the index buffer that is bound to the input-assembler stage.
        /// </summary>
        /// <param name="pIndexBuffer">
        /// A pointer to an index buffer returned by the method (see <see cref="ID3D11Buffer"/>).
        /// </param>
        /// <param name="Format">
        /// Specifies format of the data in the index buffer (see <see cref="DXGI_FORMAT"/>).
        /// These formats provide the size and type of the data in the buffer.
        /// The only formats allowed for index buffer data are 16-bit (<see cref="DXGI_FORMAT_R16_UINT"/>) and 32-bit (<see cref="DXGI_FORMAT_R32_UINT"/>) integers.
        /// </param>
        /// <param name="Offset">
        /// Offset (in bytes) from the start of the index buffer, to the first index to use.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void IAGetIndexBuffer([Out] out P<ID3D11Buffer> pIndexBuffer, [Out] out DXGI_FORMAT Format, [Out] out UINT Offset)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11Buffer>, out DXGI_FORMAT, out UINT, HRESULT>)_vTable[80])
                    (thisPtr, out pIndexBuffer, out Format, out Offset);
            }
        }

        /// <summary>
        /// Get the constant buffers used by the geometry shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin retrieving constant buffers from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to retrieve
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffer interface pointers (see <see cref="ID3D11Buffer"/>) to be returned by the method.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void GSGetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [Out] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[81])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Get the geometry shader currently set on the device.
        /// </summary>
        /// <param name="ppGeometryShader">
        /// Address of a pointer to a geometry shader (see <see cref="ID3D11ComputeShader"/>) to be returned by the method.
        /// </param>
        /// <param name="ppClassInstances">
        /// Pointer to an array of class instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance elements in the array.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void GSGetShader([Out] out P<ID3D11GeometryShader> ppGeometryShader,
            [Out] P<ID3D11ClassInstance>[]? ppClassInstances, [In][Out] ref UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11GeometryShader>, P<ID3D11ClassInstance>[]?, ref UINT, void>)_vTable[82])
                    (thisPtr, out ppGeometryShader, ppClassInstances, ref NumClassInstances);
            }
        }

        /// <summary>
        /// Get information about the primitive type, and data order that describes input data for the input assembler stage.
        /// </summary>
        /// <param name="Topology">
        /// A pointer to the type of primitive, and ordering of the primitive data (see <see cref="D3D11_PRIMITIVE_TOPOLOGY"/>).
        /// </param>
        public void IAGetPrimitiveTopology([Out] out D3D11_PRIMITIVE_TOPOLOGY Topology)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out D3D11_PRIMITIVE_TOPOLOGY, void>)_vTable[83])(thisPtr, out Topology);
            }
        }

        /// <summary>
        /// Get the vertex shader resources.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin getting shader resources from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// The number of resources to get from the device.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to be returned by the device.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void VSGetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [Out] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[84])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Get an array of sampler states from the vertex shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting samplers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers in the array.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Array of sampler-state interface pointers (see <see cref="ID3D11SamplerState"/>) to be returned by the device.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void VSGetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [Out] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[85])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Get the rendering predicate state.
        /// </summary>
        /// <param name="ppPredicate">
        /// Address of a pointer to a predicate (see <see cref="ID3D11Predicate"/>).
        /// Value stored here will be <see cref="NULL"/> upon device creation.
        /// </param>
        /// <param name="pPredicateValue">
        /// Address of a boolean to fill with the predicate comparison value.
        /// <see cref="FALSE"/> upon device creation.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void GetPredication([Out] out P<ID3D11Predicate> ppPredicate, [Out] out BOOL pPredicateValue)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11Predicate>, out BOOL, void>)_vTable[86])(thisPtr, out ppPredicate, out pPredicateValue);
            }
        }

        /// <summary>
        /// Get the geometry shader resources.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin getting shader resources from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// The number of resources to get from the device.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to be returned by the device.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void GSGetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [Out] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[87])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Get an array of sampler state interfaces from the geometry shader pipeline stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into a zero-based array to begin getting samplers from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers to get from a device context.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Pointer to an array of sampler-state interfaces (see <see cref="ID3D11SamplerState"/>).
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void GSGetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [Out] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[88])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Get pointers to the resources bound to the output-merger stage.
        /// </summary>
        /// <param name="NumViews">
        /// Number of render targets to retrieve.
        /// </param>
        /// <param name="ppRenderTargetViews">
        /// Pointer to an array of <see cref="ID3D11RenderTargetView"/>s which represent render target views.
        /// Specify <see langword="null"/> for this parameter when retrieval of a render target is not needed.
        /// </param>
        /// <param name="ppDepthStencilView">
        /// Pointer to a <see cref="ID3D11DepthStencilView"/>, which represents a depth-stencil view.
        /// Specify <see cref="NullRef{T}"/> for this parameter when retrieval of the depth-stencil view is not needed.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void OMGetRenderTargets([In] UINT NumViews, [Out] P<ID3D11RenderTargetView>[]? ppRenderTargetViews, [Out] out P<ID3D11DepthStencilView> ppDepthStencilView)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D11RenderTargetView>[]?, out P<ID3D11DepthStencilView>, void>)_vTable[89])
                    (thisPtr, NumViews, ppRenderTargetViews, out ppDepthStencilView);
            }
        }

        /// <summary>
        /// Get pointers to the resources bound to the output-merger stage.
        /// </summary>
        /// <param name="NumRTVs">
        /// The number of render-target views to retrieve.
        /// </param>
        /// <param name="ppRenderTargetViews">
        /// Pointer to an array of <see cref="ID3D11RenderTargetView"/>s which represent render target views.
        /// Specify <see langword="null"/> for this parameter when retrieval of render-target views is not required.
        /// </param>
        /// <param name="ppDepthStencilView">
        /// Pointer to a <see cref="ID3D11DepthStencilView"/>, which represents a depth-stencil view.
        /// Specify <see cref="NullRef{T}"/> for this parameter when retrieval of the depth-stencil view is not required.
        /// </param>
        /// <param name="UAVStartSlot">
        /// Index into a zero-based array to begin retrieving unordered-access views
        /// (ranges from 0 to <see cref="D3D11_PS_CS_UAV_REGISTER_COUNT"/> - 1).
        /// For pixel shaders <paramref name="UAVStartSlot"/> should be equal to the number of render-target views that are bound.
        /// </param>
        /// <param name="NumUAVs">
        /// Number of unordered-access views to return in <paramref name="ppUnorderedAccessViews"/>.
        /// This number ranges from 0 to <see cref="D3D11_PS_CS_UAV_REGISTER_COUNT"/> - <paramref name="UAVStartSlot"/>.
        /// </param>
        /// <param name="ppUnorderedAccessViews">
        /// Pointer to an array of <see cref="ID3D11UnorderedAccessView"/>s, which represent unordered-access views that are retrieved.
        /// Specify <see cref="NullRef{T}"/> for this parameter when retrieval of unordered-access views is not required.
        /// </param>
        /// <remarks>
        /// <para>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void OMGetRenderTargetsAndUnorderedAccessViews([In] UINT NumRTVs, [Out] P<ID3D11RenderTargetView>[]? ppRenderTargetViews,
            [Out] out P<ID3D11DepthStencilView> ppDepthStencilView, [In] UINT UAVStartSlot,
            [In] UINT NumUAVs, [Out] P<ID3D11UnorderedAccessView>[]? ppUnorderedAccessViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D11RenderTargetView>[]?,
                    out P<ID3D11DepthStencilView>, UINT, UINT, P<ID3D11UnorderedAccessView>[]?, void>)_vTable[90])
                    (thisPtr, NumRTVs, ppRenderTargetViews, out ppDepthStencilView, UAVStartSlot, NumUAVs, ppUnorderedAccessViews);
            }
        }

        /// <summary>
        /// Get the blend state of the output-merger stage.
        /// </summary>
        /// <param name="ppBlendState">
        /// Address of a pointer to a blend-state interface (see <see cref="ID3D11BlendState"/>).
        /// </param>
        /// <param name="BlendFactor">
        /// Array of blend factors, one for each RGBA component.
        /// </param>
        /// <param name="pSampleMask">
        /// Pointer to a sample mask.
        /// </param>
        /// <remarks>
        /// <para>
        /// The reference count of the returned interface will be incremented by one when the blend state is retrieved.
        /// Applications must release returned pointer(s) when they are no longer needed, or else there will be a memory leak.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void OMGetBlendState([Out] out P<ID3D11BlendState> ppBlendState, [In] FLOAT[]? BlendFactor, [Out] out UINT pSampleMask)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11BlendState>, FLOAT[]?, out UINT, void>)_vTable[91])
                    (thisPtr, out ppBlendState, BlendFactor, out pSampleMask);
            }
        }

        /// <summary>
        /// Gets the depth-stencil state of the output-merger stage.
        /// </summary>
        /// <param name="ppDepthStencilState">
        /// Address of a pointer to a depth-stencil state interface (see <see cref="ID3D11DepthStencilState"/>)
        /// to be filled with information from the device.
        /// </param>
        /// <param name="pStencilRef">
        /// Pointer to the stencil reference value used in the depth-stencil test.
        /// </param>
        /// <remarks>
        /// <para>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void OMGetDepthStencilState([Out] out P<ID3D11DepthStencilState> ppDepthStencilState, [Out] out UINT pStencilRef)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11DepthStencilState>, out UINT, void>)_vTable[92])
                    (thisPtr, out ppDepthStencilState, out pStencilRef);
            }
        }

        /// <summary>
        /// Get the target output buffers for the stream-output stage of the pipeline.
        /// </summary>
        /// <param name="NumBuffers">
        /// Number of buffers to get.
        /// </param>
        /// <param name="ppSOTargets">
        /// An array of output buffers (see <see cref="ID3D11Buffer"/>) to be retrieved from the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// A maximum of four output buffers can be retrieved.
        /// </para>
        /// <para>
        /// The offsets to the output buffers pointed to in the returned <paramref name="ppSOTargets"/> array
        /// may be assumed to be -1 (append), as defined for use in <see cref="SOSetTargets"/>.
        /// </para>
        /// <para>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public void SOGetTargets([In] UINT NumBuffers, [Out] P<ID3D11Buffer>[]? ppSOTargets)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D11Buffer>[]?, void>)_vTable[93])(thisPtr, NumBuffers, ppSOTargets);
            }
        }

        /// <summary>
        /// Get the rasterizer state from the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="ppRasterizerState">
        /// Address of a pointer to a rasterizer-state interface (see <see cref="ID3D11RasterizerState"/>) to fill with information from the device.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void RSGetState([Out] out P<ID3D11RasterizerState> ppRasterizerState)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11RasterizerState>, void>)_vTable[94])(thisPtr, out ppRasterizerState);
            }
        }

        /// <summary>
        /// Gets the array of viewports bound to the rasterizer stage.
        /// </summary>
        /// <param name="pNumViewports">
        /// <para>
        /// A pointer to a variable that, on input, specifies the number of viewports
        /// (ranges from 0 to <see cref="D3D11_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE"/>) in the <paramref name="pViewports"/> array;
        /// on output, the variable contains the actual number of viewports that are bound to the rasterizer stage.
        /// If <paramref name="pViewports"/> is <see langword="null"/>,
        /// <see cref="RSGetViewports"/> fills the variable with the number of viewports currently bound.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// In some versions of the Windows SDK, a debug device will raise an exception
        /// if the input value in the variable to which <paramref name="pNumViewports"/> points
        /// is greater than <see cref="D3D11_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE"/>
        /// even if <paramref name="pViewports"/> is <see langword="null"/>.
        /// The regular runtime ignores the value in the variable to which <paramref name="pNumViewports"/> points
        /// when <paramref name="pViewports"/> is <see langword="null"/>.
        /// This behavior of a debug device might be corrected in a future release of the Windows SDK.
        /// </para>
        /// </param>
        /// <param name="pViewports">
        /// An array of <see cref="D3D11_VIEWPORT"/> structures for the viewports that are bound to the rasterizer stage.
        /// If the number of viewports (in the variable to which <paramref name="pNumViewports"/> points) is greater
        /// than the actual number of viewports currently bound, unused elements of the array contain 0.
        /// For info about how the viewport size depends on the device feature level,
        /// which has changed between Direct3D 11 and Direct3D 10, see <see cref="D3D11_VIEWPORT"/>.
        /// </param>
        /// <remarks>
        /// Windows Phone 8: This API is supported.
        /// </remarks>
        public void RSGetViewports([In][Out] ref UINT pNumViewports, [Out] D3D11_VIEWPORT[]? pViewports)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, ref UINT, D3D11_VIEWPORT[]?, void>)_vTable[95])(thisPtr, ref pNumViewports, pViewports);
            }
        }

        /// <summary>
        /// Get the array of scissor rectangles bound to the rasterizer stage.
        /// </summary>
        /// <param name="pNumRects">
        /// The number of scissor rectangles (ranges between 0 and <see cref="D3D11_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE"/>) bound;
        /// set <paramref name="pRects"/> to <see langword="null"/> to use <paramref name="pNumRects"/> to see how many rectangles would be returned.
        /// </param>
        /// <param name="pRects">
        /// An array of scissor rectangles (see <see cref="D3D11_RECT"/>).
        /// If <paramref name="pNumRects"/> is greater than the number of scissor rects currently bound,
        /// then unused members of the array will contain 0.
        /// </param>
        public void RSGetScissorRects([In][Out] ref UINT pNumRects, [Out] D3D11_RECT[]? pRects)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, ref UINT, D3D11_RECT[]?, void>)_vTable[96])(thisPtr, ref pNumRects, pRects);
            }
        }

        /// <summary>
        /// Get the hull-shader resources.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin getting shader resources from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// The number of resources to get from the device.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to be returned by the device.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void HSGetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [Out] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[97])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }


        /// <summary>
        /// Get the hull shader currently set on the device.
        /// </summary>
        /// <param name="ppHullShader">
        /// Address of a pointer to a hull shader (see <see cref="ID3D11HullShader"/>) to be returned by the method.
        /// </param>
        /// <param name="ppClassInstances">
        /// Pointer to an array of class instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance elements in the array.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void HSGetShader([Out] out P<ID3D11HullShader> ppHullShader, [Out] P<ID3D11ClassInstance>[]? ppClassInstances, [In][Out] ref UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11HullShader>, P<ID3D11ClassInstance>[]?, ref UINT, void>)_vTable[98])
                    (thisPtr, out ppHullShader, ppClassInstances, ref NumClassInstances);
            }
        }

        /// <summary>
        /// Get an array of sampler state interfaces from the hull-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting samplers to
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers in the array.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Pointer to an array of sampler-state interfaces (see <see cref="ID3D11SamplerState"/>).
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void HSGetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [Out] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[99])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Get the constant buffers used by the hull-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin retrieving constant buffers from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to retrieve
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffer interface pointers (see <see cref="ID3D11Buffer"/>) to be returned by the method.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void HSGetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [Out] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[100])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Get the domain-shader resources.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin getting shader resources from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// The number of resources to get from the device.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to be returned by the device.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void DSGetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [Out] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[101])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Get the domain shader currently set on the device.
        /// </summary>
        /// <param name="ppDomainShader">
        /// Address of a pointer to a domain shader (see <see cref="ID3D11DomainShader"/>) to be returned by the method.
        /// </param>
        /// <param name="ppClassInstances">
        /// Pointer to an array of class instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance elements in the array.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void DSGetShader([Out] out P<ID3D11DomainShader> ppDomainShader, [Out] P<ID3D11ClassInstance>[]? ppClassInstances, [In][Out] ref UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11DomainShader>, P<ID3D11ClassInstance>[]?, ref UINT, void>)_vTable[102])
                    (thisPtr, out ppDomainShader, ppClassInstances, ref NumClassInstances);
            }
        }

        /// <summary>
        /// Get an array of sampler state interfaces from the domain-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into a zero-based array to begin getting samplers from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers to get from a device context.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Pointer to an array of sampler-state interfaces (see <see cref="ID3D11SamplerState"/>).
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void DSGetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [Out] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[103])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Get the constant buffers used by the domain-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin retrieving constant buffers from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to retrieve
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffer interface pointers (see <see cref="ID3D11Buffer"/>) to be returned by the method.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void DSGetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [Out] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[104])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Get the compute-shader resources.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin getting shader resources from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumViews">
        /// The number of resources to get from the device.
        /// Up to a maximum of 128 slots are available for shader resources
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppShaderResourceViews">
        /// Array of shader resource view interfaces to be returned by the device.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void CSGetShaderResources([In] UINT StartSlot, [In] UINT NumViews, [Out] P<ID3D11ShaderResourceView>[]? ppShaderResourceViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11ShaderResourceView>[]?, void>)_vTable[105])
                    (thisPtr, StartSlot, NumViews, ppShaderResourceViews);
            }
        }

        /// <summary>
        /// Gets an array of views for an unordered resource.
        /// </summary>
        /// <param name="StartSlot">
        /// Index of the first element in the zero-based array to return (ranges from 0 to <see cref="D3D11_1_UAV_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumUAVs">
        /// Number of views to get (ranges from 0 to <see cref="D3D11_1_UAV_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppUnorderedAccessViews">
        /// A pointer to an array of interface pointers (see <see cref="ID3D11UnorderedAccessView"/>) to get.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void CSGetUnorderedAccessViews([In] UINT StartSlot, [In] UINT NumUAVs, [Out] P<ID3D11UnorderedAccessView>[]? ppUnorderedAccessViews)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11UnorderedAccessView>[]?, void>)_vTable[106])
                    (thisPtr, StartSlot, NumUAVs, ppUnorderedAccessViews);
            }
        }

        /// <summary>
        /// Get the compute shader currently set on the device.
        /// </summary>
        /// <param name="ppComputeShader">
        /// Address of a pointer to a Compute shader (see <see cref="ID3D11ComputeShader"/>) to be returned by the method.
        /// </param>
        /// <param name="ppClassInstances">
        /// Pointer to an array of class instance interfaces (see <see cref="ID3D11ClassInstance"/>).
        /// </param>
        /// <param name="NumClassInstances">
        /// The number of class-instance elements in the array.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void CSGetShader([Out] out P<ID3D11ComputeShader> ppComputeShader, [Out] P<ID3D11ClassInstance>[]? ppClassInstances, [In][Out] ref UINT NumClassInstances)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11ComputeShader>, P<ID3D11ClassInstance>[]?, ref UINT, void>)_vTable[107])
                    (thisPtr, out ppComputeShader, ppClassInstances, ref NumClassInstances);
            }
        }

        /// <summary>
        /// Get an array of sampler state interfaces from the compute-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// ndex into a zero-based array to begin getting samplers from
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumSamplers">
        /// Number of samplers to get from a device context.
        /// Each pipeline stage has a total of 16 sampler slots available
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppSamplers">
        /// Pointer to an array of sampler-state interfaces (see <see cref="ID3D11SamplerState"/>).
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void CSGetSamplers([In] UINT StartSlot, [In] UINT NumSamplers, [Out] P<ID3D11SamplerState>[]? ppSamplers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11SamplerState>[]?, void>)_vTable[108])(thisPtr, StartSlot, NumSamplers, ppSamplers);
            }
        }

        /// <summary>
        /// Get the constant buffers used by the compute-shader stage.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin retrieving constant buffers
        /// from (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - 1).
        /// </param>
        /// <param name="NumBuffers">
        /// Number of buffers to retrieve
        /// (ranges from 0 to <see cref="D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT"/> - <paramref name="StartSlot"/>).
        /// </param>
        /// <param name="ppConstantBuffers">
        /// Array of constant buffer interface pointers (see <see cref="ID3D11Buffer"/>) to be returned by the method.
        /// </param>
        /// <remarks>
        /// Any returned interfaces will have their reference count incremented by one.
        /// Applications should call <see cref="IUnknown.Release"/> on the returned interfaces when they are no longer needed to avoid memory leaks.
        /// </remarks>
        public void CSGetConstantBuffers([In] UINT StartSlot, [In] UINT NumBuffers, [Out] P<ID3D11Buffer>[]? ppConstantBuffers)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, P<ID3D11Buffer>[]?, void>)_vTable[109])(thisPtr, StartSlot, NumBuffers, ppConstantBuffers);
            }
        }

        /// <summary>
        /// Restore all default settings.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method resets any device context to the default settings.
        /// This sets all input/output resource slots, shaders, input layouts, predications, scissor rectangles,
        /// depth-stencil state, rasterizer state, blend state, sampler state, and viewports to <see cref="NULL"/>.
        /// The primitive topology is set to UNDEFINED.
        /// </para>
        /// <para>
        /// For a scenario where you would like to clear a list of commands recorded so far,
        /// call <see cref="FinishCommandList"/> and throw away the resulting <see cref="ID3D11CommandList"/>.
        /// </para>
        /// </remarks>
        public void ClearState()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[110])(thisPtr);
            }
        }

        /// <summary>
        /// Sends queued-up commands in the command buffer to the graphics processing unit (GPU).
        /// </summary>
        /// <remarks>
        /// <para>
        /// Most applications don't need to call this method.
        /// If an application calls this method when not necessary, it incurs a performance penalty.
        /// Each call to <see cref="Flush"/> incurs a significant amount of overhead.
        /// </para>
        /// <para>
        /// When Microsoft Direct3D state-setting, present, or draw commands are called by an application,
        /// those commands are queued into an internal command buffer.
        /// <see cref="Flush"/> sends those commands to the GPU for processing.
        /// Typically, the Direct3D runtime sends these commands to the GPU automatically
        /// whenever the runtime determines that they need to be sent,
        /// such as when the command buffer is full or when an application maps a resource.
        /// <see cref="Flush"/> sends the commands manually.
        /// </para>
        /// <para>
        /// We recommend that you use <see cref="Flush"/> when the CPU waits for an arbitrary amount of time
        /// (such as when you call the <see cref="Sleep"/> function).
        /// </para>
        /// <para>
        /// Because <see cref="Flush"/> operates asynchronously,
        /// it can return either before or after the GPU finishes executing the queued graphics commands.
        /// However, the graphics commands eventually always complete.
        /// You can call the <see cref="ID3D11Device.CreateQuery"/> method with the <see cref="D3D11_QUERY_EVENT"/> value to create an event query;
        /// you can then use that event query in a call to the <see cref="GetData"/> method to determine
        /// when the GPU is finished processing the graphics commands.
        /// </para>
        /// <para>
        /// Microsoft Direct3D 11 defers the destruction of objects.
        /// Therefore, an application can't rely upon objects immediately being destroyed.
        /// By calling <see cref="Flush"/>, you destroy any objects whose destruction was deferred.
        /// If an application requires synchronous destruction of an object,
        /// we recommend that the application release all its references,
        /// call <see cref="ClearState"/>, and then call <see cref="Flush"/>.
        /// </para>
        /// <para>
        /// Deferred Destruction Issues with Flip Presentation Swap Chains
        /// </para>
        /// <para>
        /// Direct3D 11 defers the destruction of objects like views and resources until it can efficiently destroy them.
        /// This deferred destruction can cause problems with flip presentation model swap chains.
        /// Flip presentation model swap chains have the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> flag set.
        /// When you create a flip presentation model swap chain,
        /// you can associate only one swap chain at a time with an <see cref="HWND"/>, <see cref="IWindow"/>, or composition surface.
        /// If an application attempts to destroy a flip presentation model swap chain and replace it with another swap chain,
        /// the original swap chain is not destroyed when the application immediately frees all of the original swap chain's references.
        /// </para>
        /// <para>
        /// Most applications typically use the <see cref="IDXGISwapChain.ResizeBuffers"/> method for the majority of scenarios
        /// where they replace new swap chain buffers for old swap chain buffers.
        /// However, if an application must actually destroy an old swap chain and create a new swap chain,
        /// the application must force the destruction of all objects that the application freed.
        /// To force the destruction, call <see cref="ClearState"/> (or otherwise ensure no views are bound to pipeline state),
        /// and then call <see cref="Flush"/> on the immediate context.
        /// You must force destruction before you call <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>,
        /// <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>,
        /// or <see cref="IDXGIFactory2.CreateSwapChainForComposition"/> again to create a new swap chain.
        /// </para>
        /// </remarks>
        public void Flush()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[111])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the type of device context.
        /// </summary>
        /// <returns>
        /// A member of <see cref="D3D11_DEVICE_CONTEXT_TYPE"/> that indicates the type of device context.
        /// </returns>
        public new D3D11_DEVICE_CONTEXT_TYPE GetType()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D11_DEVICE_CONTEXT_TYPE>)_vTable[112])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the initialization flags associated with the current deferred context.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// The GetContextFlags method gets the flags
        /// that were supplied to the ContextFlags parameter of <see cref="ID3D11Device.CreateDeferredContext"/>;
        /// however, the context flag is reserved for future use.
        /// </remarks>
        public UINT GetContextFlags()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT>)_vTable[113])(thisPtr);
            }
        }

        /// <summary>
        /// Create a command list and record graphics commands into it.
        /// </summary>
        /// <param name="RestoreDeferredContextState">
        /// <para>
        /// A Boolean flag that determines whether the runtime saves deferred context state
        /// before it executes <see cref="FinishCommandList"/> and restores it afterwards.
        /// Use <see cref="TRUE"/> to indicate that the runtime needs to save and restore the state.
        /// Use <see cref="FALSE"/> to indicate that the runtime will not save or restore any state.
        /// In this case, the deferred context will return to its default state after the call to <see cref="FinishCommandList"/> completes.
        /// For information about default state, see <see cref="ClearState"/>.
        /// Typically, use <see cref="FALSE"/> unless you restore the state to be nearly equivalent to the state
        /// that the runtime would restore if you passed <see cref="TRUE"/>.
        /// When you use <see cref="FALSE"/>, you can avoid unnecessary and inefficient state transitions.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This parameter does not affect the command list that the current call to <see cref="FinishCommandList"/> returns.
        /// However, this parameter affects the command list of the next call to <see cref="FinishCommandList"/> on the same deferred context.
        /// </para>
        /// </param>
        /// <param name="ppCommandList">
        /// Upon completion of the method, the passed pointer to an <see cref="ID3D11CommandList"/> interface pointer
        /// is initialized with the recorded command list information.
        /// The resulting <see cref="ID3D11CommandList"/> object is immutable 
        /// and can only be used with <see cref="ExecuteCommandList"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Returns <see cref="DXGI_ERROR_DEVICE_REMOVED"/> if the video card has been physically removed from the system,
        /// or a driver upgrade for the video card has occurred. If this error occurs, you should destroy and recreate the device.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Returns <see cref="DXGI_ERROR_INVALID_CALL"/> if <see cref="FinishCommandList"/> cannot be called from the current context.
        /// See remarks.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Returns <see cref="E_OUTOFMEMORY"/> if the application has exhausted available memory.
        /// </description>
        /// </item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Create a command list from a deferred context and record commands into it by calling <see cref="FinishCommandList"/>.
        /// Play back a command list with an immediate context by calling <see cref="ExecuteCommandList"/>.
        /// </para>
        /// <para>
        /// Immediate context state is cleared before and after a command list is executed.
        /// A command list has no concept of inheritance.
        /// Each call to <see cref="FinishCommandList"/> will record only the state set since any previous call to <see cref="FinishCommandList"/>.
        /// </para>
        /// <para>
        /// For example, the state of a device context is its render state or pipeline state.
        /// To retrieve device context state, an application can call <see cref="GetData"/> or <see cref="GetPredication"/>.
        /// </para>
        /// <para>
        /// For more information about how to use <see cref="FinishCommandList"/>,
        /// see How to: Record a Command List.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        public HRESULT FinishCommandList([In] BOOL RestoreDeferredContextState, [Out] out P<ID3D11CommandList> ppCommandList)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, out P<ID3D11CommandList>, HRESULT>)_vTable[114])
                    (thisPtr, RestoreDeferredContextState, out ppCommandList);
            }
        }
    }
}
