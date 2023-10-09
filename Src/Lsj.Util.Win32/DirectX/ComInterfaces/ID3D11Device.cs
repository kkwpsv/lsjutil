using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.D3D11;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BIND_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_CREATE_DEVICE_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_RESOURCE_MISC_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_RTV_DIMENSION;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_SRV_DIMENSION;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_UAV_DIMENSION;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_USAGE;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The device interface represents a virtual adapter; it is used to create resources.
    /// Note
    /// The latest version of this interface is <see cref="ID3D11Device5"/> introduced in the Windows 10 Creators Update.
    /// Applications targetting Windows 10 Creators Update should use the <see cref="ID3D11Device5"/> interface instead of <see cref="ID3D11Device"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11device"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A device is created using <see cref="D3D11CreateDevice"/>.
    /// Windows Phone 8: This API is supported.
    /// </remarks>
    public unsafe struct ID3D11Device
    {
        IntPtr* _vTable;

        /// <summary>
        /// Creates a buffer (vertex buffer, index buffer, or shader-constant buffer).
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_BUFFER_DESC"/> structure that describes the buffer.
        /// </param>
        /// <param name="pInitialData">
        /// A pointer to a <see cref="D3D11_SUBRESOURCE_DATA"/> structure that describes the initialization data;
        /// use <see cref="NullRef{D3D11_SUBRESOURCE_DATA}"/> to allocate space only
        /// (with the exception that it cannot be <see cref="NullRef{D3D11_SUBRESOURCE_DATA}"/> if the usage flag is <see cref="D3D11_USAGE_IMMUTABLE"/>).
        /// If you don't pass anything to <paramref name="pInitialData"/>, the initial content of the memory for the buffer is undefined.
        /// In this case, you need to write the buffer content some other way before the resource is read.
        /// </param>
        /// <param name="ppBuffer">
        /// Address of a pointer to the <see cref="ID3D11Buffer"/> interface for the buffer object created.
        /// Set this parameter to NULL to validate the other input parameters (<see cref="S_FALSE"/> indicates a pass).
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the buffer.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// For example code, see How to: Create a Vertex Buffer, How to: Create an Index Buffer or How to: Create a Constant Buffer.
        /// For a constant buffer (<see cref="D3D11_BUFFER_DESC.BindFlags"/> of <see cref="D3D11_BUFFER_DESC"/> set to <see cref="D3D11_BIND_CONSTANT_BUFFER"/>),
        /// you must set the <see cref="D3D11_BUFFER_DESC.ByteWidth"/> value of <see cref="D3D11_BUFFER_DESC"/> in multiples of 16,
        /// and less than or equal to <see cref="D3D11_REQ_CONSTANT_BUFFER_ELEMENT_COUNT"/>.
        /// The Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems,
        /// provides the following new functionality for <see cref="CreateBuffer"/>:
        /// You can create a constant buffer that is larger than the maximum constant buffer size that a shader can access (4096 32-bit*4-component constants – 64KB).
        /// When you bind the constant buffer to the pipeline (for example, via <see cref="PSSetConstantBuffers"/> or <see cref="PSSetConstantBuffers1"/>),
        /// you can define a range of the buffer that the shader can access that fits within the 4096 constant limit.
        /// The Direct3D 11.1 runtime (available in Windows 8 and later operating systems) emulates this feature for feature level 9.1, 9.2, and 9.3;
        /// therefore, this feature is supported for feature level 9.1, 9.2, and 9.3.
        /// This feature is always available on new drivers for feature level 10 and higher.
        /// On runtimes older than Direct3D 11.1, a call to <see cref="CreateBuffer"/> to request a constant buffer that is larger than 4096 fails.
        /// </remarks>
        public HRESULT CreateBuffer([In] in D3D11_BUFFER_DESC pDesc, [In] in D3D11_SUBRESOURCE_DATA pInitialData, [Out] out P<ID3D11Buffer> ppBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_BUFFER_DESC, in D3D11_SUBRESOURCE_DATA, out P<ID3D11Buffer>, HRESULT>)_vTable[3])
                    (thisPtr, pDesc, pInitialData, out ppBuffer);
            }
        }

        /// <summary>
        /// Creates an array of 1D textures.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_TEXTURE1D_DESC"/> structure that describes a 1D texture resource.
        /// To create a typeless resource that can be interpreted at runtime into different, compatible formats,
        /// specify a typeless format in the texture description.
        /// To generate mipmap levels automatically, set the number of mipmap levels to 0.
        /// </param>
        /// <param name="pInitialData">
        /// A pointer to an array of <see cref="D3D11_SUBRESOURCE_DATA"/> structures that describe subresources for the 1D texture resource.
        /// Applications can't specify <see langword="null"/> for <paramref name="pInitialData"/>
        /// when creating IMMUTABLE resources (see <see cref="D3D11_USAGE"/>).
        /// If the resource is multisampled, <paramref name="pInitialData"/> must be <see langword="null"/>
        /// because multisampled resources cannot be initialized with data when they are created.
        /// If you don't pass anything to <paramref name="pInitialData"/>, the initial content of the memory for the resource is undefined.
        /// In this case, you need to write the resource content some other way before the resource is read.
        /// You can determine the size of this array from values
        /// in the <see cref="D3D11_TEXTURE1D_DESC.MipLevels"/> and <see cref="D3D11_TEXTURE1D_DESC.ArraySize"/> members
        /// of the <see cref="D3D11_TEXTURE1D_DESC"/> structure to which <paramref name="pDesc"/> points by using the following calculation:
        /// MipLevels * ArraySize
        /// For more information about this array size, see Remarks.
        /// </param>
        /// <param name="ppTexture1D">
        /// A pointer to a buffer that receives a pointer to a <see cref="ID3D11Texture1D"/> interface for the created texture.
        /// Set this parameter to NULL to validate the other input parameters (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// If the method succeeds, the return code is <see cref="S_OK"/>.
        /// See Direct3D 11 Return Codes for failing error codes.
        /// </returns>
        /// <remarks>
        /// CreateTexture1D creates a 1D texture resource, which can contain a number of 1D subresources.
        /// The number of textures is specified in the texture description.
        /// All textures in a resource must have the same format, size, and number of mipmap levels.
        /// All resources are made up of one or more subresources.
        /// To load data into the texture, applications can supply the data initially
        /// as an array of <see cref="D3D11_SUBRESOURCE_DATA"/> structures pointed to by <paramref name="pInitialData"/>,
        /// or they can use one of the D3DX texture functions such as <see cref="D3DX11CreateTextureFromFile"/>.
        /// For a 32 width texture with a full mipmap chain, the pInitialData array has the following 6 elements:
        /// pInitialData[0] = 32x1
        /// pInitialData[1] = 16x1
        /// pInitialData[2] = 8x1
        /// pInitialData[3] = 4x1
        /// pInitialData[4] = 2x1
        /// pInitialData[5] = 1x1
        /// </remarks>
        public HRESULT CreateTexture1D([In] in D3D11_TEXTURE1D_DESC pDesc, [In] D3D11_SUBRESOURCE_DATA[] pInitialData, [Out] out P<ID3D11Texture1D> ppTexture1D)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D11_SUBRESOURCE_DATA* pInitialDataPtr = pInitialData)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, in D3D11_TEXTURE1D_DESC, D3D11_SUBRESOURCE_DATA*, out P<ID3D11Texture1D>, HRESULT>)_vTable[4])
                        (thisPtr, pDesc, pInitialDataPtr, out ppTexture1D);
                }
            }
        }

        /// <summary>
        /// Create an array of 2D textures.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_TEXTURE2D_DESC"/> structure that describes a 2D texture resource.
        /// To create a typeless resource that can be interpreted at runtime into different,
        /// compatible formats, specify a typeless format in the texture description.
        /// To generate mipmap levels automatically, set the number of mipmap levels to 0.
        /// </param>
        /// <param name="pInitialData">
        /// A pointer to an array of <see cref="D3D11_SUBRESOURCE_DATA"/> structures that describe subresources for the 2D texture resource.
        /// Applications can't specify <see langword="null"/> for <paramref name="pInitialData"/>
        /// when creating IMMUTABLE resources (see <see cref="D3D11_USAGE"/>).
        /// If the resource is multisampled, <paramref name="pInitialData"/> must be <see langword="null"/>
        /// because multisampled resources cannot be initialized with data when they are created.
        /// If you don't pass anything to <paramref name="pInitialData"/>, the initial content of the memory for the resource is undefined.
        /// In this case, you need to write the resource content some other way before the resource is read.
        /// You can determine the size of this array from values
        /// in the <see cref="D3D11_TEXTURE2D_DESC.MipLevels"/> and <see cref="D3D11_TEXTURE2D_DESC.ArraySize"/> members
        /// of the <see cref="D3D11_TEXTURE2D_DESC"/> structure to which <paramref name="pDesc"/> points by using the following calculation:
        /// MipLevels * ArraySize
        /// For more information about this array size, see Remarks.
        /// </param>
        /// <param name="ppTexture2D">
        /// A pointer to a buffer that receives a pointer to a <see cref="ID3D11Texture2D"/> interface for the created texture.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// If the method succeeds, the return code is <see cref="S_OK"/>.
        /// See Direct3D 11 Return Codes for failing error codes.
        /// </returns>
        /// <remarks>
        /// <see cref="CreateTexture2D"/> creates a 2D texture resource, which can contain a number of 2D subresources.
        /// The number of textures is specified in the texture description.
        /// All textures in a resource must have the same format, size, and number of mipmap levels.
        /// All resources are made up of one or more subresources.
        /// To load data into the texture, applications can supply the data initially
        /// as an array of <see cref="D3D11_SUBRESOURCE_DATA"/> structures pointed to by <paramref name="pInitialData"/>,
        /// or it may use one of the D3DX texture functions such as <see cref="D3DX11CreateTextureFromFile"/>.
        /// For a 32 x 32 texture with a full mipmap chain, the <paramref name="pInitialData"/> array has the following 6 elements:
        /// pInitialData[0] = 32x32
        /// pInitialData[1] = 16x16
        /// pInitialData[2] = 8x8
        /// pInitialData[3] = 4x4
        /// pInitialData[4] = 2x2
        /// pInitialData[5] = 1x1
        /// </remarks>
        public HRESULT CreateTexture2D([In] in D3D11_TEXTURE2D_DESC pDesc, [In] D3D11_SUBRESOURCE_DATA[] pInitialData, [Out] out P<ID3D11Texture2D> ppTexture2D)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D11_SUBRESOURCE_DATA* pInitialDataPtr = pInitialData)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, in D3D11_TEXTURE2D_DESC, D3D11_SUBRESOURCE_DATA*, out P<ID3D11Texture2D>, HRESULT>)_vTable[5])
                        (thisPtr, pDesc, pInitialDataPtr, out ppTexture2D);
                }
            }
        }

        /// <summary>
        /// Create a single 3D texture.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_TEXTURE3D_DESC"/> structure that describes a 3D texture resource.
        /// To create a typeless resource that can be interpreted at runtime into different, compatible formats,
        /// specify a typeless format in the texture description.
        /// To generate mipmap levels automatically, set the number of mipmap levels to 0.
        /// </param>
        /// <param name="pInitialData">
        /// A pointer to an array of <see cref="D3D11_SUBRESOURCE_DATA"/> structures that describe subresources for the 3D texture resource.
        /// Applications cannot specify <see langword="null"/> for <paramref name="pInitialData"/>
        /// when creating IMMUTABLE resources (see <see cref="D3D11_USAGE"/>).
        /// If the resource is multisampled, <paramref name="pInitialData"/> must be <see langword="null"/>
        /// because multisampled resources cannot be initialized with data when they are created.
        /// If you don't pass anything to <paramref name="pInitialData"/>, the initial content of the memory for the resource is undefined.
        /// In this case, you need to write the resource content some other way before the resource is read.
        /// You can determine the size of this array from the value
        /// in the <see cref="D3D11_TEXTURE3D_DESC.MipLevels"/> member of the <see cref="D3D11_TEXTURE3D_DESC"/> structure to which <paramref name="pDesc"/> points.
        /// Arrays of 3D volume textures are not supported.
        /// For more information about this array size, see Remarks.
        /// </param>
        /// <param name="ppTexture3D">
        /// A pointer to a buffer that receives a pointer to a <see cref="ID3D11Texture3D"/> interface for the created texture.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// If the method succeeds, the return code is <see cref="S_OK"/>.
        /// See Direct3D 11 Return Codes for failing error codes.
        /// </returns>
        /// <remarks>
        /// <see cref="CreateTexture3D"/> creates a 3D texture resource, which can contain a number of 3D subresources.
        /// The number of textures is specified in the texture description.
        /// All textures in a resource must have the same format, size, and number of mipmap levels.
        /// All resources are made up of one or more subresources.
        /// To load data into the texture, applications can supply the data initially
        /// as an array of <see cref="D3D11_SUBRESOURCE_DATA"/> structures pointed to by <paramref name="pInitialData"/>,
        /// or they can use one of the D3DX texture functions such as <see cref="D3DX11CreateTextureFromFile"/>.
        /// Each element of <paramref name="pInitialData"/> provides all of the slices that are defined for a given miplevel.
        /// For example, for a 32 x 32 x 4 volume texture with a full mipmap chain, the array has the following 6 elements:
        /// pInitialData[0] = 32x32 with 4 slices
        /// pInitialData[1] = 16x16 with 2 slices
        /// pInitialData[2] = 8x8 with 1 slice
        /// pInitialData[3] = 4x4 with 1 slice
        /// pInitialData[4] = 2x2 with 1 slice
        /// pInitialData[5] = 1x1 with 1 slice
        /// </remarks>
        public HRESULT CreateTexture3D([In] in D3D11_TEXTURE3D_DESC pDesc, [In] D3D11_SUBRESOURCE_DATA[] pInitialData, [Out] out P<ID3D11Texture3D> ppTexture3D)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D11_SUBRESOURCE_DATA* pInitialDataPtr = pInitialData)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, in D3D11_TEXTURE3D_DESC, D3D11_SUBRESOURCE_DATA*, out P<ID3D11Texture3D>, HRESULT>)_vTable[6])
                        (thisPtr, pDesc, pInitialDataPtr, out ppTexture3D);
                }
            }
        }

        /// <summary>
        /// Create a shader-resource view for accessing data in a resource.
        /// </summary>
        /// <param name="pResource">
        /// Pointer to the resource that will serve as input to a shader.
        /// This resource must have been created with the <see cref="D3D11_BIND_SHADER_RESOURCE"/> flag.
        /// </param>
        /// <param name="pDesc">
        /// Pointer to a shader-resource view description (see <see cref="D3D11_SHADER_RESOURCE_VIEW_DESC"/>).
        /// Set this parameter to <see cref="NullRef{D3D11_SHADER_RESOURCE_VIEW_DESC}"/> to create a view that accesses the entire resource
        /// (using the format the resource was created with).
        /// </param>
        /// <param name="ppSRView">
        /// Address of a pointer to an <see cref="ID3D11ShaderResourceView"/>.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// A resource is made up of one or more subresources; a view identifies which subresources to allow the pipeline to access.
        /// In addition, each resource is bound to the pipeline using a view.
        /// A shader-resource view is designed to bind any buffer or texture resource to the shader stages using the following API methods:
        /// <see cref="ID3D11DeviceContext.VSSetShaderResources"/>, <see cref="ID3D11DeviceContext.GSSetShaderResources"/>
        /// and <see cref="ID3D11DeviceContext.PSSetShaderResources"/>.
        /// Because a view is fully typed, this means that typeless resources become fully typed when bound to the pipeline.
        /// Note
        /// To successfully create a shader-resource view from a typeless buffer (for example, <see cref="DXGI_FORMAT_R32G32B32A32_TYPELESS"/>),
        /// you must set the <see cref="D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS"/> flag when you create the buffer.
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// allows you to use <see cref="CreateShaderResourceView"/> for the following new purpose.
        /// You can create shader-resource views of video resources so that Direct3D shaders can process those shader-resource views.
        /// These video resources are either Texture2D or Texture2DArray.
        /// The value in the <see cref="D3D11_SHADER_RESOURCE_VIEW_DESC.ViewDimension"/> member of the <see cref="D3D11_SHADER_RESOURCE_VIEW_DESC"/> structure
        /// for a created shader-resource view must match the type of video resource,
        /// <see cref="D3D11_SRV_DIMENSION_TEXTURE2D"/> for Texture2D and <see cref="D3D11_SRV_DIMENSION_TEXTURE2DARRAY"/> for Texture2DArray.
        /// Additionally, the format of the underlying video resource restricts the formats that the view can use.
        /// The video resource format values on the <see cref="DXGI_FORMAT"/> reference page specify the format values that views are restricted to.
        /// The runtime read+write conflict prevention logic (which stops a resource from being bound as an SRV and RTV or UAV at the same time)
        /// treats views of different parts of the same video surface as conflicting for simplicity.
        /// Therefore, the runtime does not allow an application to read from luma while the application simultaneously
        /// renders to chroma in the same surface even though the hardware might allow these simultaneous operations.
        /// Windows Phone 8: This API is supported.
        /// </remarks>
        public HRESULT CreateShaderResourceView([In] in ID3D11Resource pResource, [In] in D3D11_SHADER_RESOURCE_VIEW_DESC pDesc,
            [Out] out P<ID3D11ShaderResourceView> ppSRView)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in ID3D11Resource, in D3D11_SHADER_RESOURCE_VIEW_DESC, out P<ID3D11ShaderResourceView>, HRESULT>)_vTable[7])
                    (thisPtr, pResource, pDesc, out ppSRView);
            }
        }

        /// <summary>
        /// Creates a view for accessing an unordered access resource.
        /// </summary>
        /// <param name="pResource">
        /// Pointer to an <see cref="ID3D11Resource"/> that represents a resources that will serve as an input to a shader.
        /// </param>
        /// <param name="pDesc">
        /// Pointer to an <see cref="D3D11_UNORDERED_ACCESS_VIEW_DESC"/> that represents a shader-resource view description.
        /// Set this parameter to <see cref="NullRef{D3D11_UNORDERED_ACCESS_VIEW_DESC}"/> to create a view
        /// that accesses the entire resource (using the format the resource was created with).
        /// </param>
        /// <param name="ppUAView">
        /// Address of a pointer to an <see cref="ID3D11UnorderedAccessView"/> that represents an unordered-access view.
        /// Set this parameter to NULL to validate the other input parameters 
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// allows you to use <see cref="CreateUnorderedAccessView"/> for the following new purpose.
        /// You can create unordered-access views of video resources so that Direct3D shaders can process those unordered-access views.
        /// These video resources are either Texture2D or Texture2DArray.
        /// The value in the <see cref="D3D11_UNORDERED_ACCESS_VIEW_DESC.ViewDimension"/> member of the <see cref="D3D11_UNORDERED_ACCESS_VIEW_DESC"/> structure
        /// for a created unordered-access view must match the type of video resource,
        /// <see cref="D3D11_UAV_DIMENSION_TEXTURE2D"/> for Texture2D and <see cref="D3D11_UAV_DIMENSION_TEXTURE2DARRAY"/> for Texture2DArray.
        /// Additionally, the format of the underlying video resource restricts the formats that the view can use.
        /// The video resource format values on the <see cref="DXGI_FORMAT"/> reference page specify the format values that views are restricted to.
        /// The runtime read+write conflict prevention logic (which stops a resource from being bound as an SRV and RTV or UAV at the same time)
        /// treats views of different parts of the same video surface as conflicting for simplicity.
        /// Therefore, the runtime does not allow an application to read from luma while the application simultaneously renders
        /// to chroma in the same surface even though the hardware might allow these simultaneous operations.
        /// </remarks>
        public HRESULT CreateUnorderedAccessView([In] in ID3D11Resource pResource, [In] in D3D11_UNORDERED_ACCESS_VIEW_DESC pDesc,
            [Out] out P<ID3D11UnorderedAccessView> ppUAView)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in ID3D11Resource, in D3D11_UNORDERED_ACCESS_VIEW_DESC, out P<ID3D11UnorderedAccessView>, HRESULT>)_vTable[8])
                    (thisPtr, pResource, pDesc, out ppUAView);
            }
        }

        /// <summary>
        /// Creates a render-target view for accessing resource data.
        /// </summary>
        /// <param name="pResource">
        /// Pointer to a <see cref="ID3D11Resource"/> that represents a render target.
        /// This resource must have been created with the <see cref="D3D11_BIND_RENDER_TARGET"/> flag.
        /// </param>
        /// <param name="pDesc">
        /// Pointer to a <see cref="D3D11_RENDER_TARGET_VIEW_DESC"/> that represents a render-target view description.
        /// Set this parameter to <see cref="NullRef{D3D11_RENDER_TARGET_VIEW_DESC}"/> to create a view that accesses all of the subresources in mipmap level 0.
        /// </param>
        /// <param name="ppRTView">
        /// Address of a pointer to an <see cref="ID3D11RenderTargetView"/>.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// A render-target view can be bound to the output-merger stage by calling <see cref="ID3D11DeviceContext.OMSetRenderTargets"/>.
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// allows you to use <see cref="CreateRenderTargetView"/> for the following new purpose.
        /// You can create render-target views of video resources so that Direct3D shaders can process those render-target views.
        /// These video resources are either Texture2D or Texture2DArray.
        /// The value in the <see cref="D3D11_RENDER_TARGET_VIEW_DESC.ViewDimension"/> member of the <see cref="D3D11_RENDER_TARGET_VIEW_DESC"/> structure
        /// for a created render-target view must match the type of video resource,
        /// <see cref="D3D11_RTV_DIMENSION_TEXTURE2D"/> for Texture2D and <see cref="D3D11_RTV_DIMENSION_TEXTURE2DARRAY"/> for Texture2DArray.
        /// Additionally, the format of the underlying video resource restricts the formats that the view can use.
        /// The video resource format values on the <see cref="DXGI_FORMAT"/> reference page specify the format values that views are restricted to.
        /// The runtime read+write conflict prevention logic (which stops a resource from being bound as an SRV and RTV or UAV at the same time)
        /// treats views of different parts of the same video surface as conflicting for simplicity.
        /// Therefore, the runtime does not allow an application to read from luma while the application simultaneously renders to
        /// chroma in the same surface even though the hardware might allow these simultaneous operations.
        /// </remarks>
        public HRESULT CreateRenderTargetView([In] in ID3D11Resource pResource, [In] in D3D11_RENDER_TARGET_VIEW_DESC pDesc,
            [Out] out P<ID3D11RenderTargetView> ppRTView)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in ID3D11Resource, in D3D11_RENDER_TARGET_VIEW_DESC, out P<ID3D11RenderTargetView>, HRESULT>)_vTable[9])
                    (thisPtr, pResource, pDesc, out ppRTView);
            }
        }

        /// <summary>
        /// Create a depth-stencil view for accessing resource data.
        /// </summary>
        /// <param name="pResource">
        /// Pointer to the resource that will serve as the depth-stencil surface.
        /// This resource must have been created with the <see cref="D3D11_BIND_DEPTH_STENCIL"/> flag.
        /// </param>
        /// <param name="pDesc">
        /// Pointer to a depth-stencil-view description (see <see cref="D3D11_DEPTH_STENCIL_VIEW_DESC"/>).
        /// Set this parameter to <see cref="NullRef{D3D11_DEPTH_STENCIL_VIEW_DESC}"/> to create a view that accesses mipmap level 0 of the entire resource
        /// (using the format the resource was created with).
        /// </param>
        /// <param name="ppDepthStencilView">
        /// Address of a pointer to an <see cref="ID3D11DepthStencilView"/>.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// A depth-stencil view can be bound to the output-merger stage by calling <see cref="ID3D11DeviceContext.OMSetRenderTargets"/>.
        /// </remarks>
        public HRESULT CreateDepthStencilView([In] in ID3D11Resource pResource, [In] in D3D11_DEPTH_STENCIL_VIEW_DESC pDesc,
            [Out] out P<ID3D11DepthStencilView> ppDepthStencilView)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in ID3D11Resource, in D3D11_DEPTH_STENCIL_VIEW_DESC, out P<ID3D11DepthStencilView>, HRESULT>)_vTable[10])
                    (thisPtr, pResource, pDesc, out ppDepthStencilView);
            }
        }

        /// <summary>
        /// Create an input-layout object to describe the input-buffer data for the input-assembler stage.
        /// </summary>
        /// <param name="pInputElementDescs">
        /// An array of the input-assembler stage input data types;
        /// each type is described by an element description (see <see cref="D3D11_INPUT_ELEMENT_DESC"/>).
        /// </param>
        /// <param name="NumElements">
        /// The number of input-data types in the array of input-elements.
        /// </param>
        /// <param name="pShaderBytecodeWithInputSignature">
        /// A pointer to the compiled shader.
        /// The compiled shader code contains a input signature which is validated against the array of elements.
        /// See remarks.
        /// </param>
        /// <param name="BytecodeLength">
        /// Size of the compiled shader.
        /// </param>
        /// <param name="ppInputLayout">
        /// A pointer to the input-layout object created (see <see cref="ID3D11InputLayout"/>).
        /// To validate the other input parameters, set this pointer to be NULL and verify that the method returns <see cref="S_FALSE"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return code is <see cref="S_OK"/>.
        /// See Direct3D 11 Return Codes for failing error codes.
        /// </returns>
        /// <remarks>
        /// After creating an input layout object, it must be bound to the input-assembler stage before calling a draw API.
        /// Once an input-layout object is created from a shader signature,
        /// the input-layout object can be reused with any other shader that has an identical input signature (semantics included).
        /// This can simplify the creation of input-layout objects when you are working with many shaders with identical inputs.
        /// If a data type in the input-layout declaration does not match the data type in a shader-input signature,
        /// <see cref="CreateInputLayout"/> will generate a warning during compilation.
        /// The warning is simply to call attention to the fact that the data may be reinterpreted when read from a register.
        /// You may either disregard this warning (if reinterpretation is intentional)
        /// or make the data types match in both declarations to eliminate the warning.
        /// Windows Phone 8: This API is supported.
        /// </remarks>
        public HRESULT CreateInputLayout([In] D3D11_INPUT_ELEMENT_DESC[] pInputElementDescs, [In] UINT NumElements,
            [In] IntPtr pShaderBytecodeWithInputSignature, [In] SIZE_T BytecodeLength, [Out] out P<ID3D11InputLayout> ppInputLayout)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D11_INPUT_ELEMENT_DESC* pInputElementDescsPtr = pInputElementDescs)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, D3D11_INPUT_ELEMENT_DESC*, UINT, IntPtr, SIZE_T, out P<ID3D11InputLayout>, HRESULT>)_vTable[11])
                    (thisPtr, pInputElementDescsPtr, NumElements, pShaderBytecodeWithInputSignature, BytecodeLength, out ppInputLayout);
                }
            }
        }

        /// <summary>
        /// Create a vertex-shader object from a compiled shader.
        /// </summary>
        /// <param name="pShaderBytecode">
        /// A pointer to the compiled shader.
        /// </param>
        /// <param name="BytecodeLength">
        /// Size of the compiled vertex shader.
        /// </param>
        /// <param name="pClassLinkage">
        /// A pointer to a class linkage interface (see <see cref="ID3D11ClassLinkage"/>);
        /// the value can be <see cref="NullRef{ID3D11ClassLinkage}"/>.
        /// </param>
        /// <param name="ppVertexShader">
        /// Address of a pointer to a <see cref="ID3D11VertexShader"/> interface.
        /// If this is NULL, all other parameters will be validated,
        /// and if all parameters pass validation this API will return <see cref="S_FALSE"/> instead of <see cref="S_OK"/>.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <see cref="CreateVertexShader"/>.
        /// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0 runtime.
        /// For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages,
        /// you can use these instructions in all shader stages.
        /// Therefore, if you use the following shader model 5.0 instructions in a vertex shader,
        /// you can successfully pass the compiled vertex shader to <paramref name="pShaderBytecode"/>.
        /// That is, the call to <see cref="CreateVertexShader"/> succeeds.
        /// If you pass a compiled shader to <paramref name="pShaderBytecode"/> that uses any of the following instructions
        /// on a device that doesn’t support UAVs at every shader stage
        /// (including existing drivers that are not implemented to support UAVs at every shader stage),
        /// <see cref="CreateVertexShader"/> fails.
        /// <see cref="CreateVertexShader"/> also fails if the shader tries to use a UAV slot beyond the set of UAV slots that the hardware supports.
        /// dcl_uav_typed, dcl_uav_raw, dcl_uav_structured, ld_raw, ld_structured, ld_uav_typed, store_raw, 
        /// store_structured, store_uav_typed, sync_uglobal, All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)
        /// </remarks>
        public HRESULT CreateVertexShader([In] IntPtr pShaderBytecode, [In] SIZE_T BytecodeLength,
            [In] in ID3D11ClassLinkage pClassLinkage, [Out] out P<ID3D11VertexShader> ppVertexShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, SIZE_T, in ID3D11ClassLinkage, out P<ID3D11VertexShader>, HRESULT>)_vTable[12])
                    (thisPtr, pShaderBytecode, BytecodeLength, pClassLinkage, out ppVertexShader);
            }
        }

        /// <summary>
        /// Create a geometry shader.
        /// </summary>
        /// <param name="pShaderBytecode">
        /// A pointer to the compiled shader.
        /// </param>
        /// <param name="BytecodeLength">
        /// Size of the compiled geometry shader.
        /// </param>
        /// <param name="pClassLinkage">
        /// A pointer to a class linkage interface (see <see cref="ID3D11ClassLinkage"/>);
        /// the value can be <see cref="NullRef{ID3D11ClassLinkage}"/>.
        /// </param>
        /// <param name="ppGeometryShader">
        /// Address of a pointer to a <see cref="ID3D11GeometryShader"/> interface.
        /// If this is NULL, all other parameters will be validated,
        /// and if all parameters pass validation this API will return <see cref="S_FALSE"/> instead of <see cref="S_OK"/>.
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// After it is created, the shader can be set to the device by calling <see cref="ID3D11DeviceContext.GSSetShader"/>.
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// provides the following new functionality for <see cref="CreateGeometryShader"/>.
        /// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0 runtime.
        /// For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages,
        /// you can use these instructions in all shader stages.
        /// Therefore, if you use the following shader model 5.0 instructions in a geometry shader,
        /// you can successfully pass the compiled geometry shader to <paramref name="pShaderBytecode"/>.
        /// That is, the call to <see cref="CreateGeometryShader"/> succeeds.
        /// If you pass a compiled shader to <paramref name="pShaderBytecode"/> that uses any of the following instructions
        /// on a device that doesn’t support UAVs at every shader stage
        /// (including existing drivers that are not implemented to support UAVs at every shader stage),
        /// <see cref="CreateGeometryShader"/> fails.
        /// <see cref="CreateGeometryShader"/> also fails if the shader tries to use a UAV slot beyond the set of UAV slots that the hardware supports.
        /// dcl_uav_typed, dcl_uav_raw, dcl_uav_structured, ld_raw, ld_structured, ld_uav_typed, store_raw, 
        /// store_structured, store_uav_typed, sync_uglobal, All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)
        /// </remarks>
        public HRESULT CreateGeometryShader([In] IntPtr pShaderBytecode, [In] SIZE_T BytecodeLength,
            [In] in ID3D11ClassLinkage pClassLinkage, [Out] out P<ID3D11GeometryShader> ppGeometryShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, SIZE_T, in ID3D11ClassLinkage, out P<ID3D11GeometryShader>, HRESULT>)_vTable[13])
                    (thisPtr, pShaderBytecode, BytecodeLength, pClassLinkage, out ppGeometryShader);
            }
        }

        /// <summary>
        /// Creates a geometry shader that can write to streaming output buffers.
        /// </summary>
        /// <param name="pShaderBytecode">
        /// A pointer to the compiled geometry shader for a standard geometry shader plus stream output.
        /// For info on how to get this pointer, see Getting a Pointer to a Compiled Shader.
        /// To create the stream output without using a geometry shader, pass a pointer to the output signature for the prior stage.
        /// To obtain this output signature, call the <see cref="D3DGetOutputSignatureBlob"/> compiler function.
        /// You can also pass a pointer to the compiled shader for the prior stage (for example, the vertex-shader stage or domain-shader stage).
        /// This compiled shader provides the output signature for the data.
        /// </param>
        /// <param name="BytecodeLength">
        /// Size of the compiled geometry shader.
        /// </param>
        /// <param name="pSODeclaration">
        /// Pointer to a <see cref="D3D11_SO_DECLARATION_ENTRY"/> array.
        /// Cannot be <see langword="null"/> if <paramref name="NumStrides"/> &gt; 0.
        /// </param>
        /// <param name="NumEntries">
        /// The number of entries in the stream output declaration
        /// ( ranges from 0 to <see cref="D3D11_SO_STREAM_COUNT"/> * <see cref="D3D11_SO_OUTPUT_COMPONENT_COUNT"/> ).
        /// </param>
        /// <param name="pBufferStrides">
        /// An array of buffer strides; each stride is the size of an element for that buffer.
        /// </param>
        /// <param name="NumStrides">
        /// The number of strides (or buffers) in <paramref name="pBufferStrides"/> (ranges from 0 to <see cref="D3D11_SO_BUFFER_SLOT_COUNT"/>).
        /// </param>
        /// <param name="RasterizedStream">
        /// The index number of the stream to be sent to the rasterizer stage (ranges from 0 to <see cref="D3D11_SO_STREAM_COUNT"/> - 1).
        /// Set to <see cref="D3D11_SO_NO_RASTERIZED_STREAM"/> if no stream is to be rasterized.
        /// </param>
        /// <param name="pClassLinkage">
        /// A pointer to a class linkage interface (see <see cref="ID3D11ClassLinkage"/>);
        /// the value can be <see cref="NullRef{ID3D11ClassLinkage}"/>.
        /// </param>
        /// <param name="ppGeometryShader">
        /// Address of a pointer to an <see cref="ID3D11GeometryShader"/> interface, representing the geometry shader that was created.
        /// Set this to NULL to validate the other parameters; if validation passes, the method will return <see cref="S_FALSE"/> instead of <see cref="S_OK"/>.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// For more info about using <see cref="CreateGeometryShaderWithStreamOutput"/>, see Create a Geometry-Shader Object with Stream Output.
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// provides the following new functionality for <see cref="CreateGeometryShaderWithStreamOutput"/>.
        /// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0 runtime.
        /// For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages,
        /// you can use these instructions in all shader stages.
        /// Therefore, if you use the following shader model 5.0 instructions in a geometry shader,
        /// you can successfully pass the compiled geometry shader to <paramref name="pShaderBytecode"/>.
        /// That is, the call to <see cref="CreateGeometryShaderWithStreamOutput"/> succeeds.
        /// If you pass a compiled shader to <paramref name="pShaderBytecode"/> that uses any of the following instructions
        /// on a device that doesn’t support UAVs at every shader stage
        /// (including existing drivers that are not implemented to support UAVs at every shader stage),
        /// <see cref="CreateGeometryShaderWithStreamOutput"/> fails.
        /// <see cref="CreateGeometryShaderWithStreamOutput"/> also fails if the shader tries to use a UAV slot beyond the set of UAV slots that the hardware supports.
        /// dcl_uav_typed, dcl_uav_raw, dcl_uav_structured, ld_raw, ld_structured, ld_uav_typed, store_raw, 
        /// store_structured, store_uav_typed, sync_uglobal, All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)
        /// </remarks>
        public HRESULT CreateGeometryShaderWithStreamOutput([In] IntPtr pShaderBytecode, [In] SIZE_T BytecodeLength,
            [In] D3D11_SO_DECLARATION_ENTRY[] pSODeclaration, [In] UINT NumEntries, [In] UINT[] pBufferStrides, [In] UINT NumStrides,
            [In] UINT RasterizedStream, [In] in ID3D11ClassLinkage pClassLinkage, [Out] out P<ID3D11GeometryShader> ppGeometryShader)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D11_SO_DECLARATION_ENTRY* pSODeclarationPtr = pSODeclaration)
                {
                    fixed (UINT* pBufferStridesPtr = pBufferStrides)
                    {
                        return ((delegate* unmanaged[Stdcall]<void*, IntPtr, SIZE_T, D3D11_SO_DECLARATION_ENTRY*, UINT, UINT*,
                            UINT, UINT, in ID3D11ClassLinkage, out P<ID3D11GeometryShader>, HRESULT>)_vTable[14])
                            (thisPtr, pShaderBytecode, BytecodeLength, pSODeclarationPtr, NumEntries, pBufferStridesPtr,
                            NumStrides, RasterizedStream, pClassLinkage, out ppGeometryShader);
                    }
                }
            }
        }

        /// <summary>
        /// Create a pixel shader.
        /// </summary>
        /// <param name="pShaderBytecode">
        /// A pointer to the compiled shader.
        /// </param>
        /// <param name="BytecodeLength">
        /// Size of the compiled pixel shader.
        /// </param>
        /// <param name="pClassLinkage">
        /// A pointer to a class linkage interface (see <see cref="ID3D11ClassLinkage"/>);
        /// the value can be <see cref="NullRef{ID3D11ClassLinkage}"/>.
        /// </param>
        /// <param name="ppPixelShader">
        /// Address of a pointer to a <see cref="ID3D11PixelShader"/> interface.
        /// If this is NULL, all other parameters will be validated,
        /// and if all parameters pass validation this API will return <see cref="S_FALSE"/> instead of <see cref="S_OK"/>.
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// After creating the pixel shader, you can set it to the device using <see cref="ID3D11DeviceContext.PSSetShader"/>.
        /// </remarks>
        public HRESULT CreatePixelShader([In] IntPtr pShaderBytecode, [In] SIZE_T BytecodeLength,
            [In] in ID3D11ClassLinkage pClassLinkage, [Out] out P<ID3D11PixelShader> ppPixelShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, SIZE_T, in ID3D11ClassLinkage, out P<ID3D11PixelShader>, HRESULT>)_vTable[15])
                    (thisPtr, pShaderBytecode, BytecodeLength, pClassLinkage, out ppPixelShader);
            }
        }

        /// <summary>
        /// Create a hull shader.
        /// </summary>
        /// <param name="pShaderBytecode">
        /// A pointer to a compiled shader.
        /// </param>
        /// <param name="BytecodeLength">
        /// Size of the compiled shader.
        /// </param>
        /// <param name="pClassLinkage">
        /// A pointer to a class linkage interface (see <see cref="ID3D11ClassLinkage"/>);
        /// the value can be <see cref="NullRef{ID3D11ClassLinkage}"/>.
        /// </param>
        /// <param name="ppHullShader">
        /// Address of a pointer to a <see cref="ID3D11HullShader"/> interface.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// provides the following new functionality for <see cref="CreateHullShader"/>.
        /// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0 runtime.
        /// For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages,
        /// you can use these instructions in all shader stages.
        /// Therefore, if you use the following shader model 5.0 instructions in a geometry shader,
        /// you can successfully pass the compiled geometry shader to <paramref name="pShaderBytecode"/>.
        /// That is, the call to <see cref="CreateHullShader"/> succeeds.
        /// If you pass a compiled shader to <paramref name="pShaderBytecode"/> that uses any of the following instructions
        /// on a device that doesn’t support UAVs at every shader stage
        /// (including existing drivers that are not implemented to support UAVs at every shader stage),
        /// <see cref="CreateHullShader"/> fails.
        /// <see cref="CreateHullShader"/> also fails if the shader tries to use a UAV slot beyond the set of UAV slots that the hardware supports.
        /// dcl_uav_typed, dcl_uav_raw, dcl_uav_structured, ld_raw, ld_structured, ld_uav_typed, store_raw, 
        /// store_structured, store_uav_typed, sync_uglobal, All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)
        /// </remarks>
        public HRESULT CreateHullShader([In] IntPtr pShaderBytecode, [In] SIZE_T BytecodeLength,
            [In] in ID3D11ClassLinkage pClassLinkage, [Out] out P<ID3D11HullShader> ppHullShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, SIZE_T, in ID3D11ClassLinkage, out P<ID3D11HullShader>, HRESULT>)_vTable[16])
                    (thisPtr, pShaderBytecode, BytecodeLength, pClassLinkage, out ppHullShader);
            }
        }

        /// <summary>
        /// Create a domain shader.
        /// </summary>
        /// <param name="pShaderBytecode">
        /// A pointer to a compiled shader.
        /// </param>
        /// <param name="BytecodeLength">
        /// Size of the compiled shader.
        /// </param>
        /// <param name="pClassLinkage">
        /// A pointer to a class linkage interface (see <see cref="ID3D11ClassLinkage"/>);
        /// the value can be <see cref="NullRef{ID3D11ClassLinkage}"/>.
        /// </param>
        /// <param name="ppDomainShader">
        /// Address of a pointer to a <see cref="ID3D11PixelShader"/> interface.
        /// If this is NULL, all other parameters will be validated,
        /// and if all parameters pass validation this API will return <see cref="S_FALSE"/> instead of <see cref="S_OK"/>.
        /// </param>
        /// <returns>
        /// his method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8,
        /// provides the following new functionality for <see cref="CreateDomainShader"/>.
        /// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0 runtime.
        /// For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages,
        /// you can use these instructions in all shader stages.
        /// Therefore, if you use the following shader model 5.0 instructions in a geometry shader,
        /// you can successfully pass the compiled geometry shader to <paramref name="pShaderBytecode"/>.
        /// That is, the call to <see cref="CreateDomainShader"/> succeeds.
        /// If you pass a compiled shader to <paramref name="pShaderBytecode"/> that uses any of the following instructions
        /// on a device that doesn’t support UAVs at every shader stage
        /// (including existing drivers that are not implemented to support UAVs at every shader stage),
        /// <see cref="CreateDomainShader"/> fails.
        /// <see cref="CreateDomainShader"/> also fails if the shader tries to use a UAV slot beyond the set of UAV slots that the hardware supports.
        /// dcl_uav_typed, dcl_uav_raw, dcl_uav_structured, ld_raw, ld_structured, ld_uav_typed, store_raw, 
        /// store_structured, store_uav_typed, sync_uglobal, All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)
        /// </remarks>
        public HRESULT CreateDomainShader([In] IntPtr pShaderBytecode, [In] SIZE_T BytecodeLength,
            [In] in ID3D11ClassLinkage pClassLinkage, [Out] out P<ID3D11DomainShader> ppDomainShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, SIZE_T, in ID3D11ClassLinkage, out P<ID3D11DomainShader>, HRESULT>)_vTable[17])
                    (thisPtr, pShaderBytecode, BytecodeLength, pClassLinkage, out ppDomainShader);
            }
        }

        /// <summary>
        /// Create a compute shader.
        /// </summary>
        /// <param name="pShaderBytecode">
        /// A pointer to a compiled shader.
        /// </param>
        /// <param name="BytecodeLength">
        /// Size of the compiled shader in <paramref name="pShaderBytecode"/>.
        /// </param>
        /// <param name="pClassLinkage">
        /// A pointer to a class linkage interface (see <see cref="ID3D11ClassLinkage"/>);
        /// the value can be <see cref="NullRef{ID3D11ClassLinkage}"/>.
        /// </param>
        /// <param name="ppComputeShader">
        /// Address of a pointer to a <see cref="ID3D11ComputeShader"/> interface.
        /// If this is NULL, all other parameters will be validated,
        /// and if all parameters pass validation <see cref="CreateComputeShader"/> will return <see cref="S_FALSE"/> instead of <see cref="S_OK"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the compute shader.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// For an example, see How To: Create a Compute Shader and HDRToneMappingCS11 Sample.
        /// </remarks>
        public HRESULT CreateComputeShader([In] IntPtr pShaderBytecode, [In] SIZE_T BytecodeLength,
            [In] in ID3D11ClassLinkage pClassLinkage, [Out] out P<ID3D11ComputeShader> ppComputeShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, SIZE_T, in ID3D11ClassLinkage, out P<ID3D11ComputeShader>, HRESULT>)_vTable[18])
                    (thisPtr, pShaderBytecode, BytecodeLength, pClassLinkage, out ppComputeShader);
            }
        }

        /// <summary>
        /// Creates class linkage libraries to enable dynamic shader linkage.
        /// </summary>
        /// <param name="ppLinkage">
        /// A pointer to a class-linkage interface pointer (see <see cref="ID3D11ClassLinkage"/>).
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// The <see cref="ID3D11ClassLinkage"/> interface returned in <paramref name="ppLinkage"/> is associated with a shader
        /// by passing it as a parameter to one of the <see cref="ID3D11Device"/> create shader methods such as <see cref="ID3D11Device.CreatePixelShader"/>.
        /// </remarks>
        public HRESULT CreateClassLinkage([Out] out P<ID3D11ClassLinkage> ppLinkage)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11ClassLinkage>, HRESULT>)_vTable[19])(thisPtr, out ppLinkage);
            }
        }

        /// <summary>
        /// Create a blend-state object that encapsulates blend state for the output-merger stage.
        /// </summary>
        /// <param name="pBlendStateDesc">
        /// Pointer to a blend-state description (see <see cref="D3D11_BLEND_DESC"/>).
        /// </param>
        /// <param name="ppBlendState">
        /// Address of a pointer to the blend-state object created (see <see cref="ID3D11BlendState"/>).
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the blend-state object.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// An application can create up to 4096 unique blend-state objects.
        /// For each object created, the runtime checks to see if a previous object has the same state.
        /// If such a previous object exists, the runtime will return a pointer to previous instance instead of creating a duplicate object.
        /// Windows Phone 8: This API is supported.
        /// </remarks>
        public HRESULT CreateBlendState([In] in D3D11_BLEND_DESC pBlendStateDesc, [Out] out P<ID3D11BlendState> ppBlendState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_BLEND_DESC, out P<ID3D11BlendState>, HRESULT>)_vTable[20])
                    (thisPtr, pBlendStateDesc, out ppBlendState);
            }
        }

        /// <summary>
        /// Create a depth-stencil state object that encapsulates depth-stencil test information for the output-merger stage.
        /// </summary>
        /// <param name="pDepthStencilDesc">
        /// Pointer to a depth-stencil state description (see <see cref="D3D11_DEPTH_STENCIL_DESC"/>).
        /// </param>
        /// <param name="ppDepthStencilState">
        /// Address of a pointer to the depth-stencil state object created (see <see cref="ID3D11DepthStencilState"/>).
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// 4096 unique depth-stencil state objects can be created on a device at a time.
        /// If an application attempts to create a depth-stencil-state interface with the same state as an existing interface,
        /// the same interface will be returned and the total number of unique depth-stencil state objects will stay the same.
        /// </remarks>
        public HRESULT CreateDepthStencilState([In] in D3D11_DEPTH_STENCIL_DESC pDepthStencilDesc, [Out] out P<ID3D11DepthStencilState> ppDepthStencilState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_DEPTH_STENCIL_DESC, out P<ID3D11DepthStencilState>, HRESULT>)_vTable[21])
                    (thisPtr, pDepthStencilDesc, out ppDepthStencilState);
            }
        }

        /// <summary>
        /// Create a rasterizer state object that tells the rasterizer stage how to behave.
        /// </summary>
        /// <param name="pRasterizerDesc">
        /// Pointer to a rasterizer state description (see <see cref="D3D11_RASTERIZER_DESC"/>).
        /// </param>
        /// <param name="ppRasterizerState">
        /// Address of a pointer to the rasterizer state object created (see <see cref="ID3D11RasterizerState"/>).
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the compute shader.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// 4096 unique rasterizer state objects can be created on a device at a time.
        /// If an application attempts to create a rasterizer-state interface with the same state as an existing interface,
        /// the same interface will be returned and the total number of unique rasterizer state objects will stay the same.
        /// </remarks>
        public HRESULT CreateRasterizerState([In] in D3D11_RASTERIZER_DESC pRasterizerDesc, [Out] out P<ID3D11RasterizerState> ppRasterizerState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_RASTERIZER_DESC, out P<ID3D11RasterizerState>, HRESULT>)_vTable[22])
                    (thisPtr, pRasterizerDesc, out ppRasterizerState);
            }
        }

        /// <summary>
        /// Create a sampler-state object that encapsulates sampling information for a texture.
        /// </summary>
        /// <param name="pSamplerDesc">
        /// Pointer to a sampler state description (see <see cref="D3D11_SAMPLER_DESC"/>).
        /// </param>
        /// <param name="ppSamplerState">
        /// Address of a pointer to the sampler state object created (see <see cref="ID3D11SamplerState"/>).
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// 4096 unique sampler state objects can be created on a device at a time.
        /// If an application attempts to create a sampler-state interface with the same state as an existing interface,
        /// the same interface will be returned and the total number of unique sampler state objects will stay the same.
        /// </remarks>
        public HRESULT CreateSamplerState([In] in D3D11_SAMPLER_DESC pSamplerDesc, [Out] out P<ID3D11SamplerState> ppSamplerState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_SAMPLER_DESC, out P<ID3D11SamplerState>, HRESULT>)_vTable[23])
                    (thisPtr, pSamplerDesc, out ppSamplerState);
            }
        }

        /// <summary>
        /// This interface encapsulates methods for querying information from the GPU.
        /// </summary>
        /// <param name="pQueryDesc">
        /// Pointer to a query description (see <see cref="D3D11_QUERY_DESC"/>).
        /// </param>
        /// <param name="ppQuery">
        /// Address of a pointer to the query object created (see <see cref="ID3D11Query"/>).
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the query object.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        public HRESULT CreateQuery([In] in D3D11_QUERY_DESC pQueryDesc, [Out] out P<ID3D11Query> ppQuery)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_QUERY_DESC, out P<ID3D11Query>, HRESULT>)_vTable[24])
                    (thisPtr, pQueryDesc, out ppQuery);
            }
        }

        /// <summary>
        /// Creates a predicate.
        /// </summary>
        /// <param name="pPredicateDesc">
        /// Pointer to a query description where the type of query
        /// must be a <see cref="D3D11_QUERY_SO_OVERFLOW_PREDICATE"/> or <see cref="D3D11_QUERY_OCCLUSION_PREDICATE"/> (see <see cref="D3D11_QUERY_DESC"/>).
        /// </param>
        /// <param name="ppPredicate">
        /// Address of a pointer to a predicate (see <see cref="ID3D11Predicate"/>).
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        public HRESULT CreatePredicate([In] in D3D11_QUERY_DESC pPredicateDesc, [Out] out P<ID3D11Predicate> ppPredicate)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_QUERY_DESC, out P<ID3D11Predicate>, HRESULT>)_vTable[25])
                    (thisPtr, pPredicateDesc, out ppPredicate);
            }
        }

        /// <summary>
        /// Create a counter object for measuring GPU performance.
        /// </summary>
        /// <param name="pCounterDesc">
        /// Pointer to a counter description (see <see cref="D3D11_COUNTER_DESC"/>).
        /// </param>
        /// <param name="ppCounter">
        /// Address of a pointer to a counter (see <see cref="ID3D11Counter"/>).
        /// </param>
        /// <returns>
        /// If this function succeeds, it will return <see cref="S_OK"/>.
        /// If it fails, possible return values are: <see cref="S_FALSE"/>, <see cref="E_OUTOFMEMORY"/>,
        /// <see cref="DXGI_ERROR_UNSUPPORTED"/>, <see cref="DXGI_ERROR_NONEXCLUSIVE"/>, or <see cref="E_INVALIDARG"/>.
        /// <see cref="DXGI_ERROR_UNSUPPORTED"/> is returned whenever the application requests to create a well-known counter,
        /// but the current device does not support it.
        /// <see cref="DXGI_ERROR_NONEXCLUSIVE"/> indicates that another device object is currently using the counters,
        /// so they cannot be used by this device at the moment.
        /// <see cref="E_INVALIDARG"/> is returned whenever an out-of-range well-known or device-dependent counter is requested,
        /// or when the simulataneously active counters have been exhausted.
        /// </returns>
        public HRESULT CreateCounter([In] in D3D11_COUNTER_DESC pCounterDesc, [Out] out P<ID3D11Counter> ppCounter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_COUNTER_DESC, out P<ID3D11Counter>, HRESULT>)_vTable[26])
                    (thisPtr, pCounterDesc, out ppCounter);
            }
        }

        /// <summary>
        /// Creates a deferred context, which can record command lists.
        /// </summary>
        /// <param name="ContextFlags">
        /// Reserved for future use. Pass 0.
        /// </param>
        /// <param name="ppDeferredContext">
        /// Upon completion of the method, the passed pointer to an <see cref="ID3D11DeviceContext"/> interface pointer is initialized.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following:
        /// Returns <see cref="DXGI_ERROR_DEVICE_REMOVED"/> if the video card has been physically removed from the system,
        /// or a driver upgrade for the video card has occurred. If this error occurs, you should destroy and recreate the device.
        /// Returns <see cref="DXGI_ERROR_INVALID_CALL"/> if the <see cref="CreateDeferredContext"/> method cannot be called from the current context.
        /// For example, if the device was created with the <see cref="D3D11_CREATE_DEVICE_SINGLETHREADED"/> value,
        /// <see cref="CreateDeferredContext"/> returns <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// Returns <see cref="E_INVALIDARG"/> if the <paramref name="ContextFlags"/> parameter is invalid.
        /// Returns <see cref="E_OUTOFMEMORY"/> if the application has exhausted available memory.
        /// </returns>
        /// <remarks>
        /// A deferred context is a thread-safe context that you can use to record graphics commands
        /// on a thread other than the main rendering thread.
        /// Using a deferred context, you can record graphics commands into a command list
        /// that is encapsulated by the <see cref="ID3D11CommandList"/> interface.
        /// After all scene items are recorded, you can then submit them to the main render thread for final rendering.
        /// In this manner, you can perform rendering tasks concurrently across multiple threads
        /// and potentially improve performance in multi-core CPU scenarios.
        /// You can create multiple deferred contexts.
        /// Note
        /// If you use the <see cref="D3D11_CREATE_DEVICE_SINGLETHREADED"/> value to create the device
        /// that is represented by <see cref="ID3D11Device"/>, the <see cref="CreateDeferredContext"/> method will fail,
        /// and you will not be able to create a deferred context.
        /// For more information about deferred contexts, see Immediate and Deferred Rendering.
        /// Windows Phone 8: This API is supported.
        /// </remarks>
        public HRESULT CreateDeferredContext([In] UINT ContextFlags, [Out] out P<ID3D11DeviceContext> ppDeferredContext)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<ID3D11DeviceContext>, HRESULT>)_vTable[27])
                    (thisPtr, ContextFlags, out ppDeferredContext);
            }
        }

        /// <summary>
        /// Give a device access to a shared resource created on a different device.
        /// </summary>
        /// <param name="hResource">
        /// A resource handle.
        /// See remarks.
        /// </param>
        /// <param name="ReturnedInterface">
        /// The globally unique identifier (GUID) for the resource interface.
        /// See remarks.
        /// </param>
        /// <param name="ppResource">
        /// Address of a pointer to the resource we are gaining access to.
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// The REFIID, or GUID, of the interface to the resource can be obtained by using the __uuidof() macro.
        /// For example, __uuidof(ID3D11Buffer) will get the GUID of the interface to a buffer resource.
        /// The unique handle of the resource is obtained differently depending on the type of device that originally created the resource.
        /// To share a resource between two Direct3D 11 devices the resource must have been created with the <see cref="D3D11_RESOURCE_MISC_SHARED"/> flag,
        /// if it was created using the <see cref="ID3D11Device"/> interface.
        /// If it was created using a DXGI device interface, then the resource is always shared.
        /// The REFIID, or GUID, of the interface to the resource can be obtained by using the __uuidof() macro.
        /// For example, __uuidof(ID3D11Buffer) will get the GUID of the interface to a buffer resource.
        /// When sharing a resource between two Direct3D 10/11 devices the unique handle of the resource can be obtained
        /// by querying the resource for the <see cref="IDXGIResource"/> interface and then calling <see cref="IDXGIResource.GetSharedHandle"/>.
        /// <code>
        /// IDXGIResource* pOtherResource(NULL);
        /// hr = pOtherDeviceResource->QueryInterface(__uuidof(IDXGIResource), (void**)&amp;pOtherResource );
        /// HANDLE sharedHandle;
        /// pOtherResource->GetSharedHandle(&amp;sharedHandle);
        /// </code>
        /// The only resources that can be shared are 2D non-mipmapped textures.
        /// To share a resource between a Direct3D 9 device and a Direct3D 11 device the texture
        /// must have been created using the pSharedHandle argument of <see cref="IDirect3DDevice9.CreateTexture"/>.
        /// The shared Direct3D 9 handle is then passed to <see cref="OpenSharedResource"/> in the hResource argument.
        /// The following code illustrates the method calls involved.
        /// <code>
        /// sharedHandle = NULL; // must be set to NULL to create, can use a valid handle here to open in D3D9 
        /// pDevice9->CreateTexture(..., pTex2D_9, &amp;sharedHandle); 
        /// ...
        /// pDevice11->OpenSharedResource(sharedHandle, __uuidof(ID3D11Resource), (void**)(&amp;tempResource11)); 
        /// tempResource11->QueryInterface(__uuidof(ID3D11Texture2D), (void**)(&amp;pTex2D_11)); 
        /// tempResource11->Release();
        /// // now use pTex2D_11 with pDevice11
        /// </code>
        /// Textures being shared from D3D9 to D3D11 have the following restrictions.
        /// Textures must be 2D
        /// Only 1 mip level is allowed
        /// Texture must have default usage
        /// Texture must be write only
        /// MSAA textures are not allowed
        /// Bind flags must have SHADER_RESOURCE and RENDER_TARGET set
        /// Only R10G10B10A2_UNORM, R16G16B16A16_FLOAT and R8G8B8A8_UNORM formats are allowed
        /// If a shared texture is updated on one device <see cref="ID3D11DeviceContext.Flush"/> must be called on that device.
        /// </remarks>
        public HRESULT OpenSharedResource([In] HANDLE hResource, [In] in IID ReturnedInterface, [Out] out IntPtr ppResource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, in IID, out IntPtr, HRESULT>)_vTable[28])
                    (thisPtr, hResource, in ReturnedInterface, out ppResource);
            }
        }

        /// <summary>
        /// Get the support of a given format on the installed video device.
        /// </summary>
        /// <param name="Format">
        /// A <see cref="DXGI_FORMAT"/> enumeration that describes a format for which to check for support.
        /// </param>
        /// <param name="pFormatSupport">
        /// A bitfield of <see cref="D3D11_FORMAT_SUPPORT"/> enumeration values describing
        /// how the specified format is supported on the installed device.
        /// The values are ORed together.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns <see cref="E_INVALIDARG"/> if the <paramref name="Format"/> parameter is NULL,
        /// or returns <see cref="E_FAIL"/> if the described format does not exist.
        /// </returns>
        public HRESULT CheckFormatSupport([In] DXGI_FORMAT Format, [Out] out D3D11_FORMAT_SUPPORT pFormatSupport)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_FORMAT, out D3D11_FORMAT_SUPPORT, HRESULT>)_vTable[29])
                    (thisPtr, Format, out pFormatSupport);
            }
        }

        /// <summary>
        /// Get the number of quality levels available during multisampling.
        /// </summary>
        /// <param name="Format">
        /// The texture format.
        /// See <see cref="DXGI_FORMAT"/>.
        /// </param>
        /// <param name="SampleCount">
        /// The number of samples during multisampling.
        /// </param>
        /// <param name="pNumQualityLevels">
        /// Number of quality levels supported by the adapter.
        /// See Remarks.
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// When multisampling a texture, the number of quality levels available for an adapter
        /// is dependent on the texture format used and the number of samples requested.
        /// The maximum number of quality levels is defined by <see cref="D3D11_MAX_MULTISAMPLE_SAMPLE_COUNT"/> in D3D11.h.
        /// If this method returns 0 (<see cref="S_OK"/>), and the output parameter <paramref name="pNumQualityLevels"/> receives a positive value,
        /// then the format and sample count combination is supported for the device.
        /// When the combination is not supported, this method returns a failure <see cref="HRESULT"/> code (that is, a negative integer),
        /// or sets <paramref name="pNumQualityLevels"/> output parameter to zero, or both.
        /// Furthermore, the definition of a quality level is left to each hardware vendor to define;
        /// however no facility is provided by Direct3D to help discover this information.
        /// Note that <see cref="FEATURE_LEVEL_10_1"/> devices are required to support 4x MSAA for all render targets except R32G32B32A32 and R32G32B32.
        /// <see cref="FEATURE_LEVEL_11_0"/> devices are required to support 4x MSAA for all render target formats,
        /// and 8x MSAA for all render target formats except R32G32B32A32 formats.
        /// </remarks>
        public HRESULT CheckMultisampleQualityLevels([In] DXGI_FORMAT Format, [In] UINT SampleCount, [Out] out UINT pNumQualityLevels)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_FORMAT, UINT, out UINT, HRESULT>)_vTable[30])
                    (thisPtr, Format, SampleCount, out pNumQualityLevels);
            }
        }

        /// <summary>
        /// Get a counter's information.
        /// </summary>
        /// <param name="pCounterInfo">
        /// Pointer to counter information (see <see cref="D3D11_COUNTER_INFO"/>).
        /// </param>
        public void CheckCounterInfo([Out] out D3D11_COUNTER_INFO pCounterInfo)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out D3D11_COUNTER_INFO, void>)_vTable[31])(thisPtr, out pCounterInfo);
            }
        }

        /// <summary>
        /// Get the type, name, units of measure, and a description of an existing counter.
        /// </summary>
        /// <param name="pDesc">
        /// Pointer to a counter description (see <see cref="D3D11_COUNTER_DESC"/>).
        /// Specifies which counter information is to be retrieved about.
        /// </param>
        /// <param name="pType">
        /// Pointer to the data type of a counter (see <see cref="D3D11_COUNTER_TYPE"/>).
        /// Specifies the data type of the counter being retrieved.
        /// </param>
        /// <param name="pActiveCounters">
        /// Pointer to the number of hardware counters that are needed for this counter type to be created.
        /// All instances of the same counter type use the same hardware counters.
        /// </param>
        /// <param name="szName">
        /// String to be filled with a brief name for the counter.
        /// May be <see cref="NULL"/> if the application is not interested in the name of the counter.
        /// </param>
        /// <param name="pNameLength">
        /// Length of the string returned to <paramref name="szName"/>.
        /// Can be <see cref="NullRef{UINT}"/>.
        /// </param>
        /// <param name="szUnits">
        /// Name of the units a counter measures, provided the memory the pointer points to has enough room to hold the string.
        /// Can be <see cref="NULL"/>.
        /// The returned string will always be in English.
        /// </param>
        /// <param name="pUnitsLength">
        /// Length of the string returned to <paramref name="szUnits"/>.
        /// Can be <see cref="NullRef{UINT}"/>.
        /// </param>
        /// <param name="szDescription">
        /// A description of the counter, provided the memory the pointer points to has enough room to hold the string.
        /// Can be <see cref="NULL"/>.
        /// The returned string will always be in English.
        /// </param>
        /// <param name="pDescriptionLength">
        /// Length of the string returned to <paramref name="szDescription"/>.
        /// Can be <see cref="NullRef{UINT}"/>.
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// Length parameters can be <see cref="NullRef{UINT}"/>, which indicates the application is not interested in the length nor the corresponding string value.
        /// When a length parameter is non-NULL and the corresponding string is <see cref="NULL"/>, the input value of the length parameter is ignored,
        /// and the length of the corresponding string (including terminating NULL) will be returned through the length parameter.
        /// When length and the corresponding parameter are both non-NULL, the input value of length is checked to ensure there is enough room,
        /// and then the length of the string (including terminating NULL character) is passed out through the length parameter.
        /// Windows Phone 8: This API is supported.
        /// </remarks>
        public HRESULT CheckCounter([In] in D3D11_COUNTER_DESC pDesc, [Out] out D3D11_COUNTER_TYPE pType, [Out] out UINT pActiveCounters,
            [In] LPWSTR szName, [In][Out] ref UINT pNameLength, [In] LPWSTR szUnits, [In][Out] ref UINT pUnitsLength,
            [In] LPWSTR szDescription, [In][Out] ref UINT pDescriptionLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_COUNTER_DESC, out D3D11_COUNTER_TYPE, out UINT,
                    IntPtr, ref UINT, IntPtr, ref UINT, IntPtr, ref UINT, HRESULT>)_vTable[32])
                    (thisPtr, pDesc, out pType, out pActiveCounters, szName.Handle, ref pNameLength,
                    szUnits.Handle, ref pUnitsLength, szDescription.Handle, ref pDescriptionLength);
            }
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <param name="Feature">
        /// A member of the <see cref="D3D11_FEATURE"/> enumerated type that describes which feature to query for support.
        /// </param>
        /// <param name="pFeatureSupportData">
        /// Upon completion of the method, the passed structure is filled with data that describes the feature support.
        /// </param>
        /// <param name="FeatureSupportDataSize">
        /// The size of the structure passed to the <paramref name="pFeatureSupportData"/> parameter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns <see cref="E_INVALIDARG"/>
        /// if an unsupported data type is passed to the <paramref name="pFeatureSupportData"/> parameter
        /// or a size mismatch is detected for the <paramref name="FeatureSupportDataSize"/> parameter.
        /// </returns>
        /// <remarks>
        /// To query for multi-threading support, pass the <see cref="D3D11_FEATURE_THREADING"/> value to the Feature parameter,
        /// pass the <see cref="D3D11_FEATURE_DATA_THREADING"/> structure to the <paramref name="pFeatureSupportData"/> parameter,
        /// and pass the size of the <see cref="D3D11_FEATURE_DATA_THREADING"/> structure to the <paramref name="FeatureSupportDataSize"/> parameter.
        /// Calling <see cref="CheckFeatureSupport"/> with Feature set to <see cref="D3D11_FEATURE_FORMAT_SUPPORT"/> causes the method
        /// to return the same information that would be returned by <see cref="CheckFormatSupport"/>.
        /// </remarks>
        public HRESULT CheckFeatureSupport([In] D3D11_FEATURE Feature, [In] IntPtr pFeatureSupportData, [In] UINT FeatureSupportDataSize)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D11_FEATURE, IntPtr, UINT, HRESULT>)_vTable[33])
                    (thisPtr, Feature, pFeatureSupportData, FeatureSupportDataSize);
            }
        }

        /// <summary>
        /// Get application-defined data from a device.
        /// </summary>
        /// <param name="guid">
        /// Guid associated with the data.
        /// </param>
        /// <param name="pDataSize">
        /// A pointer to a variable that on input contains the size, in bytes, of the buffer that pData points to,
        /// and on output contains the size, in bytes, of the amount of data that <see cref="GetPrivateData"/> retrieved.
        /// </param>
        /// <param name="pData">
        /// A pointer to a buffer that <see cref="GetPrivateData"/> fills with data from the device
        /// if <paramref name="pDataSize"/> points to a value that specifies a buffer large enough to hold the data.
        /// </param>
        /// <returns>
        /// This method returns one of the codes described in the topic Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// If the data returned is a pointer to an <see cref="IUnknown"/>, or one of its derivative classes,
        /// which was previously set by <see cref="SetPrivateDataInterface"/>,
        /// that interface will have its reference count incremented before the private data is returned.
        /// </remarks>
        public HRESULT GetPrivateData([In] in GUID guid, [In][Out] ref UINT pDataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, ref UINT, IntPtr, HRESULT>)_vTable[34])(thisPtr, guid, ref pDataSize, pData);
            }
        }

        /// <summary>
        /// Set data to a device and associate that data with a guid.
        /// </summary>
        /// <param name="guid">
        /// Guid associated with the data.
        /// </param>
        /// <param name="DataSize">
        /// Size of the data.
        /// </param>
        /// <param name="pData">
        /// Pointer to the data to be stored with this device.
        /// If <paramref name="pData"/> is <see cref="NULL"/>, <paramref name="DataSize"/> must also be 0,
        /// and any data previously associated with the guid will be destroyed.
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// The data stored in the device with this method can be retrieved with <see cref="GetPrivateData"/>.
        /// The data and guid set with this method will typically be application-defined.
        /// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names.
        /// The default friendly name is "&lt;unnamed&gt;".
        /// You can set the friendly name so that you can determine if the corresponding object interface pointer caused the leak.
        /// To set the friendly name, use the <see cref="SetPrivateData"/> method and the <see cref="WKPDID_D3DDebugObjectName"/> GUID that is in D3Dcommon.h.
        /// For example, to give pContext a friendly name of My name, use the following code:
        /// <code>
        /// static const char c_szName[] = "My name";
        /// hr = pContext->SetPrivateData( WKPDID_D3DDebugObjectName, sizeof( c_szName ) - 1, c_szName );
        /// </code>
        /// </remarks>
        public HRESULT SetPrivateData([In] in GUID guid, [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, UINT, IntPtr, HRESULT>)_vTable[35])(thisPtr, guid, DataSize, pData);
            }
        }

        /// <summary>
        /// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
        /// </summary>
        /// <param name="guid">
        /// Guid associated with the interface.
        /// </param>
        /// <param name="pData">
        /// Guid associated with the interface.
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        public HRESULT SetPrivateDataInterface([In] in GUID guid, [In] in IUnknown pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in IUnknown, HRESULT>)_vTable[36])(thisPtr, guid, pData);
            }
        }

        /// <summary>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </summary>
        /// <returns>
        /// A member of the <see cref="D3D_FEATURE_LEVEL"/> enumerated type that describes the feature level of the hardware device.
        /// </returns>
        /// <remarks>
        /// Feature levels determine the capabilities of your device.
        /// </remarks>
        public D3D_FEATURE_LEVEL GetFeatureLevel()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D_FEATURE_LEVEL>)_vTable[37])(thisPtr);
            }
        }

        /// <summary>
        /// Get the flags used during the call to create the device with <see cref="D3D11CreateDevice"/>.
        /// </summary>
        /// <returns>
        /// A bitfield containing the flags used to create the device.
        /// See <see cref="D3D11_CREATE_DEVICE_FLAG"/>.
        /// </returns>
        public D3D11_CREATE_DEVICE_FLAG GetCreationFlags()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D11_CREATE_DEVICE_FLAG>)_vTable[38])(thisPtr);
            }
        }

        /// <summary>
        /// Get the reason why the device was removed.
        /// </summary>
        /// <returns>
        /// Possible return values include:
        /// <see cref="DXGI_ERROR_DEVICE_HUNG"/>
        /// <see cref="DXGI_ERROR_DEVICE_REMOVED"/>
        /// <see cref="DXGI_ERROR_DEVICE_RESET"/>
        /// <see cref="DXGI_ERROR_DRIVER_INTERNAL_ERROR"/>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/>
        /// <see cref="S_OK"/>
        /// For more detail on these return codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        public HRESULT GetDeviceRemovedReason()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[38])(thisPtr);
            }
        }

        /// <summary>
        /// Gets an immediate context, which can play back command lists.
        /// </summary>
        /// <param name="ppImmediateContext">
        /// Upon completion of the method, the passed pointer to an <see cref="ID3D11DeviceContext"/> interface pointer is initialized.
        /// </param>
        /// <remarks>
        /// The <see cref="GetImmediateContext"/> method returns an <see cref="ID3D11DeviceContext"/> object
        /// that represents an immediate context which is used to perform rendering that you want immediately submitted to a device.
        /// For most applications, an immediate context is the primary object that is used to draw your scene.
        /// The <see cref="GetImmediateContext"/> method increments the reference count of the immediate context by one.
        /// Therefore, you must call <see cref="IUnknown.Release"/> on the returned interface pointer when you are done with it to avoid a memory leak.
        /// </remarks>
        public void GetImmediateContext([Out] out P<ID3D11DeviceContext> ppImmediateContext)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11DeviceContext>, HRESULT>)_vTable[39])(thisPtr, out ppImmediateContext);
            }
        }

        /// <summary>
        /// Get the exception-mode flags.
        /// </summary>
        /// <param name="RaiseFlags">
        /// A value that contains one or more exception flags; each flag specifies a condition which will cause an exception to be raised.
        /// The flags are listed in <see cref="D3D11_RAISE_FLAG"/>.
        /// A default value of 0 means there are no flags.
        /// </param>
        /// <returns>
        /// This method returns one of the following Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// Set an exception-mode flag to elevate an error condition to a non-continuable exception.
        /// Whenever an error occurs, a Direct3D device enters the DEVICEREMOVED state
        /// and if the appropriate exception flag has been set, an exception is raised.
        /// A raised exception is designed to terminate an application.
        /// Before termination, the last chance an application has to persist data is by using an UnhandledExceptionFilter (see Structured Exception Handling).
        /// In general, UnhandledExceptionFilters are leveraged to try to persist data when an application is crashing (to disk, for example).
        /// Any code that executes during an UnhandledExceptionFilter is not guaranteed to reliably execute (due to possible process corruption).
        /// Any data that the UnhandledExceptionFilter manages to persist, before the UnhandledExceptionFilter crashes again,
        /// should be treated as suspect, and therefore inspected by a new, non-corrupted process to see if it is usable.
        /// </remarks>
        public HRESULT SetExceptionMode([In] D3D11_RAISE_FLAG RaiseFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D11_RAISE_FLAG, HRESULT>)_vTable[40])(thisPtr, RaiseFlags);
            }
        }

        /// <summary>
        /// Get the exception-mode flags.
        /// </summary>
        /// <returns>
        /// A value that contains one or more exception flags; each flag specifies a condition which will cause an exception to be raised.
        /// The flags are listed in <see cref="D3D11_RAISE_FLAG"/>.
        /// A default value of 0 means there are no flags.
        /// </returns>
        /// <remarks>
        /// An exception-mode flag is used to elevate an error condition to a non-continuable exception.
        /// </remarks>
        public D3D11_RAISE_FLAG GetExceptionMode()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D11_RAISE_FLAG>)_vTable[41])(thisPtr);
            }
        }
    }
}
