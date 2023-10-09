using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The device interface represents a virtual adapter; it is used to create resources.
    /// <see cref="ID3D11Device3"/> adds new methods to those in <see cref="ID3D11Device2"/>.
    /// </para>
    /// </summary>
    public unsafe struct ID3D11Device3
    {
        IntPtr* _vTable;

        /// <summary>
        /// Creates a 2D texture.
        /// </summary>
        /// <param name="pDesc1">
        /// A pointer to a <see cref="D3D11_TEXTURE2D_DESC1"/> structure that describes a 2D texture resource.
        /// To create a typeless resource that can be interpreted at runtime into different, compatible formats,
        /// specify a typeless format in the texture description.
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
        /// in the <see cref="D3D11_TEXTURE2D_DESC1.MipLevels"/> and <see cref="D3D11_TEXTURE2D_DESC1.ArraySize"/> members
        /// of the <see cref="D3D11_TEXTURE2D_DESC1"/> structure to which <paramref name="pDesc1"/> points by using the following calculation:
        /// MipLevels * ArraySize
        /// For more information about this array size, see Remarks.
        /// </param>
        /// <param name="ppTexture2D">
        /// A pointer to a buffer that receives a pointer to a <see cref="ID3D11Texture2D1"/> interface for the created texture.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// If the method succeeds, the return code is <see cref="S_OK"/>.
        /// See Direct3D 11 Return Codes for failing error codes.
        /// </returns>
        /// <remarks>
        /// <see cref="CreateTexture2D1"/> creates a 2D texture resource, which can contain a number of 2D subresources.
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
        public HRESULT CreateTexture2D1([In] in D3D11_TEXTURE2D_DESC1 pDesc1, [In] D3D11_SUBRESOURCE_DATA[] pInitialData, [Out] out P<ID3D11Texture2D1> ppTexture2D)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D11_SUBRESOURCE_DATA* pInitialDataPtr = pInitialData)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, in D3D11_TEXTURE2D_DESC1, D3D11_SUBRESOURCE_DATA*, out P<ID3D11Texture2D1>, HRESULT>)_vTable[52])
                        (thisPtr, pDesc1, pInitialDataPtr, out ppTexture2D);
                }
            }
        }

        /// <summary>
        /// Create a single 3D texture.
        /// </summary>
        /// <param name="pDesc1">
        /// A pointer to a <see cref="D3D11_TEXTURE3D_DESC1"/> structure that describes a 3D texture resource.
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
        /// in the <see cref="D3D11_TEXTURE3D_DESC1 .MipLevels"/> member of the <see cref="D3D11_TEXTURE3D_DESC1"/> structure to which <paramref name="pDesc1"/> points.
        /// Arrays of 3D volume textures are not supported.
        /// For more information about this array size, see Remarks.
        /// </param>
        /// <param name="ppTexture3D">
        /// A pointer to a buffer that receives a pointer to a <see cref="ID3D11Texture3D1"/> interface for the created texture.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// If the method succeeds, the return code is <see cref="S_OK"/>.
        /// See Direct3D 11 Return Codes for failing error codes.
        /// </returns>
        /// <remarks>
        /// <see cref="CreateTexture3D1"/> creates a 3D texture resource, which can contain a number of 3D subresources.
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
        public HRESULT CreateTexture3D([In] in D3D11_TEXTURE3D_DESC1 pDesc1, [In] D3D11_SUBRESOURCE_DATA[] pInitialData, [Out] out P<ID3D11Texture3D1> ppTexture3D)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D11_SUBRESOURCE_DATA* pInitialDataPtr = pInitialData)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, in D3D11_TEXTURE3D_DESC1, D3D11_SUBRESOURCE_DATA*, out P<ID3D11Texture3D1>, HRESULT>)_vTable[53])
                        (thisPtr, pDesc1, pInitialDataPtr, out ppTexture3D);
                }
            }
        }

        /// <summary>
        /// Creates a rasterizer state object that informs the rasterizer stage how to behave and forces the sample count while UAV rendering or rasterizing.
        /// </summary>
        /// <param name="pRasterizerDesc">
        /// A pointer to a <see cref="D3D11_RASTERIZER_DESC2"/> structure that describes the rasterizer state.
        /// </param>
        /// <param name="ppRasterizerState">
        /// A pointer to a memory block that receives a pointer to a <see cref="ID3D11RasterizerState2"/> interface for the created rasterizer state object.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the rasterizer state object.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        public HRESULT CreateRasterizerState2([In] in D3D11_RASTERIZER_DESC2 pRasterizerDesc, [Out] out P<ID3D11RasterizerState2> ppRasterizerState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_RASTERIZER_DESC2, out P<ID3D11RasterizerState2>, HRESULT>)_vTable[54])
                    (thisPtr, pRasterizerDesc, out ppRasterizerState);
            }
        }

        /// <summary>
        /// Create a shader-resource view for accessing data in a resource.
        /// </summary>
        /// <param name="pResource">
        /// Pointer to the resource that will serve as input to a shader.
        /// This resource must have been created with the <see cref="D3D11_BIND_SHADER_RESOURCE"/> flag.
        /// </param>
        /// <param name="pDesc1">
        /// Pointer to a shader-resource view description (see <see cref="D3D11_SHADER_RESOURCE_VIEW_DESC1"/>).
        /// Set this parameter to <see cref="NullRef{D3D11_SHADER_RESOURCE_VIEW_DESC1}"/> to create a view that accesses the entire resource
        /// (using the format the resource was created with).
        /// </param>
        /// <param name="ppSRView1">
        /// Address of a pointer to an <see cref="ID3D11ShaderResourceView1"/>.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the shader-resource view.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        public HRESULT CreateShaderResourceView1([In] in ID3D11Resource pResource, [In] in D3D11_SHADER_RESOURCE_VIEW_DESC1 pDesc1,
            [Out] out P<ID3D11ShaderResourceView1> ppSRView1)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in ID3D11Resource, in D3D11_SHADER_RESOURCE_VIEW_DESC1, out P<ID3D11ShaderResourceView1>, HRESULT>)_vTable[55])
                    (thisPtr, pResource, pDesc1, out ppSRView1);
            }
        }

        /// <summary>
        /// Creates a view for accessing an unordered access resource.
        /// </summary>
        /// <param name="pResource">
        /// Pointer to an <see cref="ID3D11Resource"/> that represents a resources that will serve as an input to a shader.
        /// </param>
        /// <param name="pDesc1">
        /// Pointer to an <see cref="D3D11_UNORDERED_ACCESS_VIEW_DESC1"/> that represents a shader-resource view description.
        /// Set this parameter to <see cref="NullRef{D3D11_UNORDERED_ACCESS_VIEW_DESC1}"/> to create a view
        /// that accesses the entire resource (using the format the resource was created with).
        /// </param>
        /// <param name="ppUAView1">
        /// Address of a pointer to an <see cref="ID3D11UnorderedAccessView1"/> that represents an unordered-access view.
        /// Set this parameter to NULL to validate the other input parameters 
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the unordered-access view.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        public HRESULT CreateUnorderedAccessView1([In] in ID3D11Resource pResource, [In] in D3D11_UNORDERED_ACCESS_VIEW_DESC1 pDesc1,
            [Out] out P<ID3D11UnorderedAccessView1> ppUAView1)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in ID3D11Resource, in D3D11_UNORDERED_ACCESS_VIEW_DESC1, out P<ID3D11UnorderedAccessView1>, HRESULT>)_vTable[56])
                    (thisPtr, pResource, pDesc1, out ppUAView1);
            }
        }

        /// <summary>
        /// Creates a render-target view for accessing resource data.
        /// </summary>
        /// <param name="pResource">
        /// Pointer to a <see cref="ID3D11Resource"/> that represents a render target.
        /// This resource must have been created with the <see cref="D3D11_BIND_RENDER_TARGET"/> flag.
        /// </param>
        /// <param name="pDesc1">
        /// Pointer to a <see cref="D3D11_RENDER_TARGET_VIEW_DESC1"/> that represents a render-target view description.
        /// Set this parameter to <see cref="NullRef{D3D11_RENDER_TARGET_VIEW_DESC1}"/> to create a view that accesses all of the subresources in mipmap level 0.
        /// </param>
        /// <param name="ppRTView1">
        /// Address of a pointer to an <see cref="ID3D11RenderTargetView1"/>.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// A render-target view can be bound to the output-merger stage by calling <see cref="ID3D11DeviceContext.OMSetRenderTargets"/>.
        /// </remarks>
        public HRESULT CreateRenderTargetView1([In] in ID3D11Resource pResource, [In] in D3D11_RENDER_TARGET_VIEW_DESC1 pDesc1,
            [Out] out P<ID3D11RenderTargetView1> ppRTView1)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in ID3D11Resource, in D3D11_RENDER_TARGET_VIEW_DESC1, out P<ID3D11RenderTargetView1>, HRESULT>)_vTable[57])
                    (thisPtr, pResource, pDesc1, out ppRTView1);
            }
        }

        /// <summary>
        /// Creates a query object for querying information from the graphics processing unit (GPU).
        /// </summary>
        /// <param name="pQueryDesc1">
        /// Pointer to a <see cref="D3D11_QUERY_DESC1"/> structure that represents a query description.
        /// </param>
        /// <param name="ppQuery1">
        /// A pointer to a memory block that receives a pointer to a <see cref="ID3D11Query1"/> interface for the created query object.
        /// Set this parameter to NULL to validate the other input parameters
        /// (the method will return <see cref="S_FALSE"/> if the other input parameters pass validation).
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the query object.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        public HRESULT CreateQuery1([In] in D3D11_QUERY_DESC1 pQueryDesc1, [Out] out P<ID3D11Query1> ppQuery1)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_QUERY_DESC1, out P<ID3D11Query1>, HRESULT>)_vTable[58])
                    (thisPtr, pQueryDesc1, out ppQuery1);
            }
        }

        /// <summary>
        /// Gets an immediate context, which can play back command lists.
        /// </summary>
        /// <param name="ppImmediateContext">
        /// Upon completion of the method, the passed pointer to an <see cref="ID3D11DeviceContext3"/> interface pointer is initialized.
        /// </param>
        /// <remarks>
        /// The <see cref="GetImmediateContext3"/> method returns an <see cref="ID3D11DeviceContext3"/> object that represents an immediate context,
        /// which is used to perform rendering that you want immediately submitted to a device.
        /// For most apps, an immediate context is the primary object that is used to draw your scene.
        /// The <see cref="GetImmediateContext3"/> method increments the reference count of the immediate context by one.
        /// Therefore, you must call <see cref="IUnknown.Release"/> on the returned interface pointer when you are done with it to avoid a memory leak.
        /// </remarks>
        public void GetImmediateContext3([Out] out P<ID3D11DeviceContext3> ppImmediateContext)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11DeviceContext3>, HRESULT>)_vTable[59])(thisPtr, out ppImmediateContext);
            }
        }

        /// <summary>
        /// Creates a deferred context, which can record command lists.
        /// </summary>
        /// <param name="ContextFlags">
        /// Reserved for future use.
        /// Pass 0.
        /// </param>
        /// <param name="ppDeferredContext">
        /// Upon completion of the method, the passed pointer to an <see cref="ID3D11DeviceContext3"/> interface pointer is initialized.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following:
        /// Returns <see cref="DXGI_ERROR_DEVICE_REMOVED"/> if the graphics adapter has been physically removed from the computer
        /// or a driver upgrade for the graphics adapter has occurred.
        /// If this error occurs, you should destroy and re-create the device.
        /// Returns <see cref="DXGI_ERROR_INVALID_CALL"/> if the <see cref="CreateDeferredContext3"/> method cannot be called from the current context.
        /// For example, if the device was created with the <see cref="D3D11_CREATE_DEVICE_SINGLETHREADED"/> value,
        /// <see cref="CreateDeferredContext3"/> returns <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// Returns <see cref="E_INVALIDARG"/> if the <paramref name="ContextFlags"/> parameter is invalid.
        /// Returns <see cref="E_OUTOFMEMORY"/> if the application has exhausted available memory.
        /// </returns>
        public HRESULT CreateDeferredContext3([In] UINT ContextFlags, [Out] out P<ID3D11DeviceContext3> ppDeferredContext)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<ID3D11DeviceContext3>, HRESULT>)_vTable[60])
                    (thisPtr, ContextFlags, out ppDeferredContext);
            }
        }

        /// <summary>
        /// Copies data into a <see cref="D3D11_USAGE_DEFAULT"/> texture which was mapped using <see cref="ID3D11DeviceContext3.Map"/>
        /// while providing a NULL <see cref="D3D11_MAPPED_SUBRESOURCE"/> parameter.
        /// </summary>
        /// <param name="pDstResource">
        /// A pointer to the destination resource (an <see cref="ID3D11Resource"/>).
        /// </param>
        /// <param name="DstSubresource">
        /// A zero-based index, that identifies the destination subresource.
        /// For more details, see <see cref="D3D11CalcSubresource"/>.
        /// </param>
        /// <param name="pDstBox">
        /// A pointer to a box that defines the portion of the destination subresource to copy the resource data into.
        /// If <see cref="NullRef{D3D11_BOX}"/>, the data is written to the destination subresource with no offset.
        /// The dimensions of the source must fit the destination (see <see cref="D3D11_BOX"/>).
        /// An empty box results in a no-op.
        /// A box is empty if the top value is greater than or equal to the bottom value,
        /// or the left value is greater than or equal to the right value, or the front value is greater than or equal to the back value.
        /// When the box is empty, this method doesn't perform any operation.
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
        /// The provided resource must be a <see cref="D3D11_USAGE_DEFAULT"/> texture which was mapped
        /// for writing by a previous call to <see cref="ID3D11DeviceContext3.Map"/> while providing a NULL <see cref="D3D11_MAPPED_SUBRESOURCE"/> parameter.
        /// This API is intended for calling at high frequency.
        /// Callers can reduce memory by making iterative calls that update progressive regions of the texture,
        /// while provide a small buffer during each call.
        /// It is most efficient to specify large enough regions, though,
        /// because this enables D3D to fill whole cache lines in the texture before returning.
        /// For efficiency, ensure the bounds and alignment of the extents within the box are ( 64 / [bytes per pixel] ) pixels horizontally.
        /// Vertical bounds and alignment should be 2 rows, except when 1-byte-per-pixel formats are used, in which case 4 rows are recommended.
        /// Single depth slices per call are handled efficiently.
        /// It is recommended but not necessary to provide pointers and strides which are 128-byte aligned.
        /// When writing to sub mipmap levels, it is recommended to use larger width and heights than described above.
        /// This is because small mipmap levels may actually be stored within a larger block of memory,
        /// with an opaque amount of offsetting which can interfere with alignment to cache lines.
        /// </remarks>
        public void WriteToSubresource([In] in ID3D11Resource pDstResource, [In] UINT DstSubresource, [In] in D3D11_BOX pDstBox,
            [In] IntPtr pSrcData, [In] UINT SrcRowPitch, [In] UINT SrcDepthPitch)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in ID3D11Resource, UINT, in D3D11_BOX, IntPtr, UINT, UINT, void>)_vTable[61])
                    (thisPtr, pDstResource, DstSubresource, pDstBox, pSrcData, SrcRowPitch, SrcDepthPitch);
            }
        }

        /// <summary>
        /// Copies data from a <see cref="D3D11_USAGE_DEFAULT"/> texture which was mapped using <see cref="ID3D11DeviceContext3.Map"/>
        /// while providing a NULL <see cref="D3D11_MAPPED_SUBRESOURCE"/> parameter.
        /// </summary>
        /// <param name="pDstData">
        /// A pointer to the destination data in memory.
        /// </param>
        /// <param name="DstRowPitch">
        /// The size of one row of the destination data.
        /// </param>
        /// <param name="DstDepthPitch">
        /// The size of one depth slice of destination data.
        /// </param>
        /// <param name="pSrcResource">
        /// A pointer to the source resource (see <see cref="ID3D11Resource"/>).
        /// </param>
        /// <param name="SrcSubresource">
        /// A zero-based index, that identifies the destination subresource.
        /// For more details, see <see cref="D3D11CalcSubresource"/>.
        /// </param>
        /// <param name="pSrcBox">
        /// A pointer to a box that defines the portion of the destination subresource to copy the resource data from.
        /// If <see cref="NullRef{D3D11_BOX}"/>, the data is read from the destination subresource with no offset.
        /// The dimensions of the destination must fit the destination (see <see cref="D3D11_BOX"/>).
        /// An empty box results in a no-op.
        /// A box is empty if the top value is greater than or equal to the bottom value,
        /// or the left value is greater than or equal to the right value, or the front value is greater than or equal to the back value.
        /// When the box is empty, this method doesn't perform any operation.
        /// </param>
        /// <remarks>
        /// The provided resource must be a <see cref="D3D11_USAGE_DEFAULT"/> texture which was mapped
        /// for writing by a previous call to <see cref="ID3D11DeviceContext3.Map"/> while providing a NULL <see cref="D3D11_MAPPED_SUBRESOURCE"/> parameter.
        /// This API is intended for calling at high frequency.
        /// Callers can reduce memory by making iterative calls that update progressive regions of the texture,
        /// while provide a small buffer during each call.
        /// It is most efficient to specify large enough regions, though,
        /// because this enables D3D to fill whole cache lines in the texture before returning.
        /// For efficiency, ensure the bounds and alignment of the extents within the box are ( 64 / [bytes per pixel] ) pixels horizontally.
        /// Vertical bounds and alignment should be 2 rows, except when 1-byte-per-pixel formats are used, in which case 4 rows are recommended.
        /// Single depth slices per call are handled efficiently.
        /// It is recommended but not necessary to provide pointers and strides which are 128-byte aligned.
        /// When writing to sub mipmap levels, it is recommended to use larger width and heights than described above.
        /// This is because small mipmap levels may actually be stored within a larger block of memory,
        /// with an opaque amount of offsetting which can interfere with alignment to cache lines.
        /// </remarks>
        public void ReadFromSubresource([In] IntPtr pDstData, [In] UINT DstRowPitch, [In] UINT DstDepthPitch,
            [In] in ID3D11Resource pSrcResource, [In] UINT SrcSubresource, [In] in D3D11_BOX pSrcBox)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, IntPtr,UINT,UINT,in ID3D11Resource, UINT, in D3D11_BOX, void>)_vTable[62])
                    (thisPtr, pDstData, DstRowPitch, DstDepthPitch, pSrcResource, SrcSubresource, pSrcBox);
            }
        }
    }
}
