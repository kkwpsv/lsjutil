using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.D3D12;
using static Lsj.Util.Win32.DirectX.Enums.D3D_PRIMITIVE_TOPOLOGY;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_BLEND;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_COMMAND_LIST_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_DESCRIPTOR_HEAP_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_HEAP_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_PREDICATION_OP;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_STATES;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Encapsulates a list of graphics commands for rendering.
    /// Includes APIs for instrumenting the command list execution, and for setting and clearing the pipeline state.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// The latest version of this interface is <see cref="ID3D12GraphicsCommandList1"/> introduced in the Windows 10 Creators Update.
    /// Applications targetting Windows 10 Creators Update should use
    /// the <see cref="ID3D12GraphicsCommandList1"/> interface instead of <see cref="ID3D12GraphicsCommandList"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12graphicscommandlist"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This interface is new to D3D12, encapsulating much of the functionality of the <see cref="ID3D11CommandList"/> interface,
    /// and including the new functionality described in Rendering.
    /// </remarks>
    [ComInterface(IID = "5b160d0f-ac1b-4185-8ba8-b3ae42a5a455", BeginVTableSlotIndex = 9, EndVTableSlotIndex = 59,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild), typeof(ID3D12CommandList)])]
    public unsafe struct ID3D12GraphicsCommandList
    {
        IntPtr* _vTable;

        /// <summary>
        /// Indicates that recording to the command list has finished.
        /// </summary>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns one of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="E_FAIL"/> if the command list has already been closed,
        /// or an invalid API was called during command list recording.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_OUTOFMEMORY"/> if the operating system ran out of memory during recording.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_INVALIDARG"/> if an invalid argument was passed to the command list API during recording.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// See Direct3D 12 Return Codes for other possible return values.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The runtime will validate that the command list has not previously been closed.
        /// If an error was encountered during recording, the error code is returned here.
        /// The runtime won't call the close device driver interface (DDI) in this case.
        /// </remarks>
        public HRESULT Close()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[9])(thisPtr);
            }
        }

        /// <summary>
        /// Resets a command list back to its initial state as if a new command list was just created.
        /// </summary>
        /// <param name="pAllocator">
        /// A pointer to the <see cref="ID3D12CommandAllocator"/> object that the device creates command lists from.
        /// </param>
        /// <param name="pInitialState">
        /// <para>
        /// A pointer to the <see cref="ID3D12PipelineState"/> object that contains the initial pipeline state for the command list.
        /// This is optional and can be <see cref="NULL"/>.
        /// If <see cref="NULL"/>, the runtime sets a dummy initial pipeline state so that drivers don't have to deal with undefined state.
        /// The overhead for this is low, particularly for a command list,
        /// for which the overall cost of recording the command list likely dwarfs the cost of one initial state setting.
        /// So there is little cost in not setting the initial pipeline state parameter if it isn't convenient.
        /// </para>
        /// <para>
        /// For bundles on the other hand, it might make more sense to try to set the initial state parameter
        /// since bundles are likely smaller overall and can be reused frequently.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="E_FAIL"/> if the command list was not in the "closed" state when the <see cref="Reset"/> call was made,
        /// or the per-device limit would have been exceeded.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_OUTOFMEMORY"/> if the operating system ran out of memory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_INVALIDARG"/> if the allocator is currently being used with another command list in the "recording" state
        /// or if the specified allocator was created with the wrong type.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// See Direct3D 12 Return Codes for other possible return values.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// By using <see cref="Reset"/>, you can re-use command list tracking structures without any allocations.
        /// Unlike <see cref="ID3D12CommandAllocator.Reset"/>,
        /// you can call <see cref="Reset"/> while the command list is still being executed.
        /// </para>
        /// <para>
        /// You can use <see cref="Reset"/> for both direct command lists and bundles.
        /// </para>
        /// <para>
        /// The command allocator passed to <see cref="Reset"/> cannot be associated with any other currently-recording command list.
        /// The allocator type, direct command list or bundle, must match the type of command list that is being created.
        /// </para>
        /// <para>
        /// If a bundle doesn't specify a resource heap, it can't make changes to which descriptor tables are bound.
        /// Either way, bundles can't change the resource heap within the bundle.
        /// If a heap is specified for a bundle, the heap must match the calling 'parent' command list’s heap.
        /// </para>
        /// </remarks>
        public HRESULT Reset([In] P<ID3D12CommandAllocator> pAllocator, [In] P<ID3D12PipelineState> pInitialState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D12CommandAllocator>, P<ID3D12PipelineState>, HRESULT>)_vTable[10])
                    (thisPtr, pAllocator, pInitialState);
            }
        }

        /// <summary>
        /// Resets the state of a direct command list back to the state it was in when the command list was created.
        /// </summary>
        /// <param name="pPipelineState">
        /// A pointer to the <see cref="ID3D12PipelineState"/> object that contains the initial pipeline state for the command list.
        /// </param>
        /// <remarks>
        /// <para>
        /// It is invalid to call <see cref="ClearState"/> on a bundle.
        /// If an app calls <see cref="ClearState"/> on a bundle,
        /// the call to <see cref="Close"/> will return <see cref="E_FAIL"/>.
        /// </para>
        /// <para>
        /// When <see cref="ClearState"/> is called, all currently bound resources are unbound.
        /// The primitive topology is set to <see cref="D3D_PRIMITIVE_TOPOLOGY_UNDEFINED"/>.
        /// Viewports, scissor rectangles, stencil reference value, and the blend factor are set to empty values (all zeros).
        /// Predication is disabled.
        /// </para>
        /// <para>
        /// The app-provided pipeline state object becomes bound as the currently set pipeline state object.
        /// </para>
        /// </remarks>
        public void ClearState([In] P<ID3D12PipelineState> pPipelineState)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12PipelineState>, void>)_vTable[11])(thisPtr, pPipelineState);
            }
        }

        /// <summary>
        /// Draws non-indexed, instanced primitives.
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
        /// Instancing might extend performance by reusing the same geometry to draw multiple objects in a scene.
        /// One example of instancing could be to draw the same object with different positions and colors.
        /// </para>
        /// <para>
        /// The vertex data for an instanced draw call typically comes from a vertex buffer that is bound to the pipeline.
        /// But, you could also provide the vertex data from a shader
        /// that has instanced data identified with a system-value semantic (<c>SV_InstanceID</c>).
        /// </para>
        /// </remarks>
        public void DrawInstanced([In] UINT VertexCountPerInstance, [In] UINT InstanceCount, [In] UINT StartVertexLocation, [In] UINT StartInstanceLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, UINT, void>)_vTable[12])
                    (thisPtr, VertexCountPerInstance, InstanceCount, StartVertexLocation, StartInstanceLocation);
            }
        }

        /// <summary>
        /// Draws indexed, instanced primitives.
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
        /// Instancing might extend performance by reusing the same geometry to draw multiple objects in a scene.
        /// One example of instancing could be to draw the same object with different positions and colors.
        /// Instancing requires multiple vertex buffers:
        /// at least one for per-vertex data and a second buffer for per-instance data.
        /// </para>
        /// </remarks>
        public void DrawIndexedInstanced([In] UINT IndexCountPerInstance, [In] UINT InstanceCount, [In] UINT StartIndexLocation,
            [In] INT BaseVertexLocation, [In] UINT StartInstanceLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, INT, UINT, void>)_vTable[13])
                    (thisPtr, IndexCountPerInstance, InstanceCount, StartIndexLocation, BaseVertexLocation, StartInstanceLocation);
            }
        }

        /// <summary>
        /// Executes a command list from a thread group.
        /// </summary>
        /// <param name="ThreadGroupCountX">
        /// The number of groups dispatched in the x direction.
        /// <paramref name="ThreadGroupCountX"/> must be less than or equal to <see cref="D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION"/> (65535).
        /// </param>
        /// <param name="ThreadGroupCountY">
        /// The number of groups dispatched in the y direction.
        /// <paramref name="ThreadGroupCountY"/> must be less than or equal to <see cref="D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION"/> (65535).
        /// </param>
        /// <param name="ThreadGroupCountZ">
        /// The number of groups dispatched in the z direction.
        /// <paramref name="ThreadGroupCountZ"/> must be less than or equal to <see cref="D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION"/> (65535).
        /// In feature level 10 the value for <paramref name="ThreadGroupCountZ"/> must be 1.
        /// </param>
        /// <remarks>
        /// You call the <see cref="Dispatch"/> method to execute commands in a compute shader.
        /// A compute shader can be run on many threads in parallel, within a thread group.
        /// Index a particular thread, within a thread group using a 3D vector given by (x,y,z).
        /// </remarks>
        public void Dispatch([In] UINT ThreadGroupCountX, [In] UINT ThreadGroupCountY, [In] UINT ThreadGroupCountZ)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, void>)_vTable[14])
                    (thisPtr, ThreadGroupCountX, ThreadGroupCountY, ThreadGroupCountZ);
            }
        }

        /// <summary>
        /// Copies a region of a buffer from one resource to another.
        /// </summary>
        /// <param name="pDstBuffer">
        /// Specifies the destination <see cref="ID3D12Resource"/>.
        /// </param>
        /// <param name="DstOffset">
        /// Specifies a UINT64 offset (in bytes) into the destination resource.
        /// </param>
        /// <param name="pSrcBuffer">
        /// Specifies the source <see cref="ID3D12Resource"/>.
        /// </param>
        /// <param name="SrcOffset">
        /// Specifies a UINT64 offset (in bytes) into the source resource, to start the copy from.
        /// </param>
        /// <param name="NumBytes">
        /// Specifies the number of bytes to copy.
        /// </param>
        /// <remarks>
        /// <para>
        /// Consider using the <see cref="CopyResource"/> method when copying an entire resource,
        /// and use this method for copying regions of a resource.
        /// </para>
        /// <para>
        /// <see cref="CopyBufferRegion"/> may be used to initialize resources which alias the same heap memory.
        /// See <see cref="ID3D12Device.CreatePlacedResource"/> for more details.
        /// </para>
        /// </remarks>
        public void CopyBufferRegion([In] P<ID3D12Resource> pDstBuffer, [In] UINT64 DstOffset,
            [In] P<ID3D12Resource> pSrcBuffer, [In] UINT64 SrcOffset, [In] UINT64 NumBytes)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, UINT64, P<ID3D12Resource>, UINT64, UINT64, void>)_vTable[15])
                    (thisPtr, pDstBuffer, DstOffset, pSrcBuffer, SrcOffset, NumBytes);
            }
        }

        /// <summary>
        /// This method uses the GPU to copy texture data between two locations.
        /// Both the source and the destination may reference texture data located within either a buffer resource or a texture resource.
        /// </summary>
        /// <param name="pDst">
        /// Specifies the destination <see cref="D3D12_TEXTURE_COPY_LOCATION"/>.
        /// The subresource referred to must be in the <see cref="D3D12_RESOURCE_STATE_COPY_DEST"/> state.
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
        /// <param name="pSrc">
        /// Specifies the source <see cref="D3D12_TEXTURE_COPY_LOCATION"/>.
        /// The subresource referred to must be in the <see cref="D3D12_RESOURCE_STATE_COPY_SOURCE"/> state.
        /// </param>
        /// <param name="pSrcBox">
        /// Specifies an optional <see cref="D3D12_BOX"/> that sets the size of the source texture to copy.
        /// </param>
        /// <remarks>
        /// <para>
        /// The source box must be within the size of the source resource.
        /// The destination offsets, (x, y, and z), allow the source box to be offset when writing into the destination resource;
        /// however, the dimensions of the source box and the offsets must be within the size of the resource.
        /// If you try and copy outside the destination resource or specify a source box that is larger than the source resource,
        /// the behavior of <see cref="CopyTextureRegion"/> is undefined.
        /// If you created a device that supports the debug layer,
        /// the debug output reports an error on this invalid <see cref="CopyTextureRegion"/> call.
        /// Invalid parameters to <see cref="CopyTextureRegion"/> cause undefined behavior
        /// and might result in incorrect rendering, clipping, no copy, or even the removal of the rendering device.
        /// </para>
        /// <para>
        /// If the resources are buffers, all coordinates are in bytes;
        /// if the resources are textures, all coordinates are in texels.
        /// </para>
        /// <para>
        /// <see cref="CopyTextureRegion"/> performs the copy on the GPU (similar to a <c>memcpy</c> by the CPU).
        /// As a consequence, the source and destination resources:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Must be different subresources (although they can be from the same resource).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Must have compatible <see cref="DXGI_FORMAT"/>s (identical or from the same type group).
        /// For example, a <see cref="DXGI_FORMAT_R32G32B32_FLOAT"/> texture can be copied to a <see cref="DXGI_FORMAT_R32G32B32_UINT"/> texture
        /// since both of these formats are in the <see cref="DXGI_FORMAT_R32G32B32_TYPELESS"/> group.
        /// <see cref="CopyTextureRegion"/> can copy between a few format types.
        /// For more info, see Format Conversion using Direct3D 10.1.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="CopyTextureRegion"/> only supports copy; it does not support any stretch, color key, or blend.
        /// <see cref="CopyTextureRegion"/> can reinterpret the resource data between a few format types.
        /// </para>
        /// <para>
        /// Note that for a depth-stencil buffer, the depth and stencil planes are separate subresources within the buffer.
        /// </para>
        /// <para>
        /// To copy an entire resource, rather than just a region of a subresource, we recommend to use <see cref="CopyResource"/> instead.
        /// </para>
        /// <para>
        /// </para>
        /// <para>
        /// If you use <see cref="CopyTextureRegion"/> with a depth-stencil buffer or a multisampled resource,
        /// you must copy the entire subresource rectangle.
        /// In this situation, you must pass 0 to the <paramref name="DstX"/>, <paramref name="DstY"/>,
        /// and <paramref name="DstZ"/> parameters and <see cref="NullRef{D3D12_BOX}"/> to the <paramref name="pSrcBox"/> parameter.
        /// In addition, source and destination resources,
        /// which are represented by the <paramref name="pSrc"/> and <paramref name="pDst"/> parameters,
        /// should have identical sample count values.
        /// </para>
        /// <para>
        /// <see cref="CopyTextureRegion"/> may be used to initialize resources which alias the same heap memory.
        /// See <see cref="ID3D12Device.CreatePlacedResource"/> for more details.
        /// </para>
        /// </remarks>
        public void CopyTextureRegion([In] in D3D12_TEXTURE_COPY_LOCATION pDst, [In] UINT DstX, [In] UINT DstY, [In] UINT DstZ,
            [In] in D3D12_TEXTURE_COPY_LOCATION pSrc, [In] in D3D12_BOX pSrcBox)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D3D12_TEXTURE_COPY_LOCATION, UINT, UINT, UINT,
                    in D3D12_TEXTURE_COPY_LOCATION, in D3D12_BOX, void>)_vTable[16])(thisPtr, pDst, DstX, DstY, DstZ, pSrc, pSrcBox);
            }
        }

        /// <summary>
        /// Copies the entire contents of the source resource to the destination resource.
        /// </summary>
        /// <param name="pDstResource">
        /// A pointer to the <see cref="ID3D12Resource"/> interface that represents the destination resource.
        /// </param>
        /// <param name="pSrcResource">
        /// A pointer to the <see cref="ID3D12Resource"/> interface that represents the source resource.
        /// </param>
        /// <remarks>
        /// <para>
        /// <see cref="CopyResource"/> operations are performed on the GPU,
        /// and do not incur a significant CPU workload linearly dependent on the size of the data to copy.
        /// </para>
        /// <para>
        /// <see cref="CopyResource"/> can be used to initialize resources that alias the same heap memory.
        /// See <see cref="ID3D12Device.CreatePlacedResource"/> for more details.
        /// </para>
        /// <para>
        /// Debug layer
        /// </para>
        /// <para>
        /// The debug layer issues an error if the source subresource is not in the <see cref="D3D12_RESOURCE_STATE_COPY_SOURCE"/> state.
        /// </para>
        /// <para>
        /// The debug layer issues an error if the destination subresource is not in the state.
        /// </para>
        /// <para>
        /// Restrictions
        /// </para>
        /// <para>
        /// This method has a few restrictions designed for improving performance.
        /// For instance, the source and destination resources:
        /// </para>
        /// <para>
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
        /// Must be the same total size (bytes).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Must have identical dimensions (width, height, depth) or be a compatible Reinterpret Copy.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Must have compatible DXGI formats, which means the formats must be identical or at least from the same type group.
        /// For example, a <see cref="DXGI_FORMAT_R32G32B32_FLOAT"/> texture can be copied to a <see cref="DXGI_FORMAT_R32G32B32_UINT"/> texture
        /// since both of these formats are in the <see cref="DXGI_FORMAT_R32G32B32_TYPELESS"/> group.
        /// <see cref="CopyResource"/> can copy between a few format types (see Reinterpret copy).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Can't be currently mapped.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="CopyResource"/> only supports copy; it doesn't support any stretch, color key, or blend.
        /// </para>
        /// <para>
        /// <see cref="CopyResource"/> can reinterpret the resource data between a few format types, see Reinterpret Copy below for details.
        /// </para>
        /// <para>
        /// You can use a depth-stencil resource as either a source or a destination.
        /// Resources created with multi-sampling capability (see <see cref="DXGI_SAMPLE_DESC"/>) can be used as source and destination
        /// only if both source and destination have identical multi-sampled count and quality.
        /// If source and destination differ in multi-sampled count and quality or if one is multi-sampled and the other is not multi-sampled,
        /// the call to <see cref="CopyResource"/> fails.
        /// Use <see cref="ResolveSubresource"/> to resolve a multi-sampled resource to a resource that is not multi-sampled.
        /// </para>
        /// <para>
        /// The method is an asynchronous call, which may be added to the command-buffer queue.
        /// This attempts to remove pipeline stalls that may occur when copying data.
        /// For more info, see performance considerations.
        /// </para>
        /// <para>
        /// Consider using <see cref="CopyTextureRegion"/> or <see cref="CopyBufferRegion"/>
        /// if you only need to copy a portion of the data in a resource.
        /// </para>
        /// <para>
        /// Reinterpret copy
        /// </para>
        /// <para>
        /// The following table lists the allowable source and destination formats
        /// that you can use in the reinterpretation type of format conversion.
        /// The underlying data values are not converted or compressed/decompressed
        /// and must be encoded properly for the reinterpretation to work as expected.
        /// For more info, see Format Conversion using Direct3D 10.1.
        /// </para>
        /// <para>
        /// For <see cref="DXGI_FORMAT_R9G9B9E5_SHAREDEXP"/> the width and height must be equal (1 texel per block).
        /// </para>
        /// <para>
        /// Block-compressed resource width and height must be 4 times the uncompressed resource width and height (16 texels per block).
        /// For example, a uncompressed 256x256 <see cref="DXGI_FORMAT_R32G32B32A32_UINT"/> texture
        /// will map to a 1024x1024 <see cref="DXGI_FORMAT_BC5_UNORM"/> compressed texture.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bit width
        /// </term>
        /// <term>
        /// Uncompressed resource
        /// </term>
        /// <term>
        /// Block-compressed resource
        /// </term>
        /// <term>
        /// Width / height difference
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 32
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="DXGI_FORMAT_R32_UINT"/>
        /// </para>
        /// <para>
        /// <see cref="DXGI_FORMAT_R32_SINT"/>
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="DXGI_FORMAT_R9G9B9E5_SHAREDEXP"/>
        /// </term>
        /// <term>
        /// 1:1
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 64
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="DXGI_FORMAT_R16G16B16A16_UINT"/>
        /// </para>
        /// <para>
        /// <see cref="DXGI_FORMAT_R16G16B16A16_SINT"/>
        /// </para>
        /// <para>
        /// <see cref="DXGI_FORMAT_R32G32_UINT"/>
        /// </para>
        /// <para>
        /// <see cref="DXGI_FORMAT_R32G32_SINT"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// <c>DXGI_FORMAT_BC1_UNORM[_SRGB]</c>
        /// </para>
        /// <para>
        /// <see cref="DXGI_FORMAT_BC4_UNORM"/>
        /// </para>
        /// <para>
        /// <see cref="DXGI_FORMAT_BC4_SNORM"/>
        /// </para>
        /// </term>
        /// <term>
        /// 1:4
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 128
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="DXGI_FORMAT_R32G32B32A32_UINT"/>
        /// </para>
        /// <para>
        /// <see cref="DXGI_FORMAT_R32G32B32A32_SINT"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// <c>DXGI_FORMAT_BC2_UNORM[_SRGB]</c>
        /// </para>
        /// <para>
        /// <c>DXGI_FORMAT_BC3_UNORM[_SRGB]</c>
        /// </para>
        /// <para>
        /// <see cref="DXGI_FORMAT_BC5_UNORM"/>
        /// </para>
        /// <para>
        /// <see cref="DXGI_FORMAT_BC5_SNORM"/>
        /// </para>
        /// </term>
        /// <term>
        /// 1:4
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public void CopyResource([In] P<ID3D12Resource> pDstResource, [In] P<ID3D12Resource> pSrcResource)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, P<ID3D12Resource>, void>)_vTable[17])(thisPtr, pDstResource, pSrcResource);
            }
        }

        /// <summary>
        /// Copies tiles from buffer to tiled resource or vice versa.
        /// </summary>
        /// <param name="pTiledResource">
        /// A pointer to a tiled resource.
        /// </param>
        /// <param name="pTileRegionStartCoordinate">
        /// A pointer to a <see cref="D3D12_TILED_RESOURCE_COORDINATE"/> structure
        /// that describes the starting coordinates of the tiled resource.
        /// </param>
        /// <param name="pTileRegionSize">
        /// A pointer to a <see cref="D3D12_TILE_REGION_SIZE"/> structure that describes the size of the tiled region.
        /// </param>
        /// <param name="pBuffer">
        /// A pointer to an <see cref="ID3D12Resource"/> that represents a default, dynamic, or staging buffer.
        /// </param>
        /// <param name="BufferStartOffsetInBytes">
        /// The offset in bytes into the buffer at <paramref name="pBuffer"/> to start the operation.
        /// </param>
        /// <param name="Flags">
        /// A combination of <see cref="D3D12_TILE_COPY_FLAGS"/>-typed values that are combined
        /// by using a bitwise OR operation and that identifies how to copy tiles.
        /// </param>
        /// <remarks>
        /// <para>
        /// <see cref="CopyTiles"/> drops write operations to unmapped areas and handles read operations
        /// from unmapped areas (except on Tier_1 tiled resources, where reading and writing unmapped areas is invalid
        /// - refer to <see cref="D3D12_TILED_RESOURCES_TIER"/>).
        /// </para>
        /// <para>
        /// If a copy operation involves writing to the same memory location multiple times
        /// because multiple locations in the destination resource are mapped to the same tile memory,
        /// the resulting write operations to multi-mapped tiles are non-deterministic and non-repeatable;
        /// that is, accesses to the tile memory happen in whatever order the hardware happens to execute the copy operation.
        /// </para>
        /// <para>
        /// The tiles involved in the copy operation can't include tiles
        /// that contain packed mipmaps or results of the copy operation are undefined.
        /// To transfer data to and from mipmaps that the hardware packs into the one-or-more tiles that constitute the packed mips,
        /// you must use the standard (that is, non-tile specific) copy APIs like <see cref="CopyTextureRegion"/>.
        /// </para>
        /// <para>
        /// <see cref="CopyTiles"/> does copy data in a slightly different pattern than the standard copy methods.
        /// </para>
        /// <para>
        /// The memory layout of the tiles in the non-tiled buffer resource side of the copy operation is linear in memory within 64 KB tiles,
        /// which the hardware and driver swizzle and de-swizzle per tile as appropriate when they transfer to and from a tiled resource.
        /// For multisample antialiasing (MSAA) surfaces,
        /// the hardware and driver traverse each pixel's samples in sample-index order before they move to the next pixel.
        /// For tiles that are partially filled on the right side
        /// (for a surface that has a width not a multiple of tile width in pixels),
        /// the pitch and stride to move down a row is the full size in bytes of the number pixels
        /// that would fit across the tile if the tile was full.
        /// So, there can be a gap between each row of pixels in memory.
        /// Mipmaps that are smaller than a tile are not packed together in the linear layout,
        /// which might seem to be a waste of memory space,
        /// but as mentioned you can't use <see cref="CopyTiles"/> to copy to mipmaps that the hardware packs together.
        /// You can just use generic copy APIs, like <see cref="CopyTextureRegion"/>, to copy small mipmaps individually.
        /// </para>
        /// </remarks>
        public void CopyTiles([In] P<ID3D12Resource> pTiledResource, [In] in D3D12_TILED_RESOURCE_COORDINATE pTileRegionStartCoordinate,
            [In] in D3D12_TILE_REGION_SIZE pTileRegionSize, [In] P<ID3D12Resource> pBuffer,
            [In] UINT64 BufferStartOffsetInBytes, [In] D3D12_TILE_COPY_FLAGS Flags)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, in D3D12_TILED_RESOURCE_COORDINATE,
                    in D3D12_TILE_REGION_SIZE, P<ID3D12Resource>, UINT64, D3D12_TILE_COPY_FLAGS, void>)_vTable[18])
                    (thisPtr, pTiledResource, pTileRegionStartCoordinate, pTileRegionSize, pBuffer, BufferStartOffsetInBytes, Flags);
            }
        }

        /// <summary>
        /// Copy a multi-sampled resource into a non-multi-sampled resource.
        /// </summary>
        /// <param name="pDstResource">
        /// Destination resource.
        /// Must be a created on a <see cref="D3D12_HEAP_TYPE_DEFAULT"/> heap and be single-sampled.
        /// See <see cref="ID3D12Resource"/>.
        /// </param>
        /// <param name="DstSubresource">
        /// A zero-based index, that identifies the destination subresource.
        /// Use <see cref="D3D12CalcSubresource"/> to calculate the subresource index if the parent resource is complex.
        /// </param>
        /// <param name="pSrcResource">
        /// Source resource. Must be multisampled.
        /// </param>
        /// <param name="SrcSubresource">
        /// The source subresource of the source resource.
        /// </param>
        /// <param name="Format">
        /// A <see cref="DXGI_FORMAT"/> that indicates how the multisampled resource will be resolved to a single-sampled resource.
        /// See remarks.
        /// </param>
        /// <remarks>
        /// <para>
        /// Debug layer
        /// </para>
        /// <para>
        /// The debug layer will issue an error if the subresources referenced by the source view
        /// is not in the <see cref="D3D12_RESOURCE_STATE_RESOLVE_SOURCE"/> state.
        /// </para>
        /// <para>
        /// The debug layer will issue an error
        /// if the destination buffer is not in the <see cref="D3D12_RESOURCE_STATE_RESOLVE_DEST"/> state.
        /// </para>
        /// <para>
        /// The source and destination resources must be the same resource type and have the same dimensions.
        /// In addition, they must have compatible formats.
        /// There are three scenarios for this:
        /// </para>
        /// <para>
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
        /// Both the source and destination must have identical formats
        /// and that format must be specified in the <paramref name="Format"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// One resource is prestructured and typed and the other is prestructured and typeless
        /// </term>
        /// <term>
        /// The typed resource must have a format that is compatible with the typeless resource
        /// (i.e. the typed resource is <see cref="DXGI_FORMAT_R32_FLOAT"/> and the typeless resource is <see cref="DXGI_FORMAT_R32_TYPELESS"/>).
        /// The format of the typed resource must be specified in the <paramref name="Format"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Source and destination are prestructured and typeless
        /// </term>
        /// <term>
        /// <para>
        /// Both the source and destination must have the same typeless format (i.e. both must have <see cref="DXGI_FORMAT_R32_TYPELESS"/>),
        /// and the <paramref name="Format"/> parameter must specify a format that is compatible with the source and destination
        /// (i.e. if both are <see cref="DXGI_FORMAT_R32_TYPELESS"/>
        /// then <see cref="DXGI_FORMAT_R32_FLOAT"/> could be specified in the <paramref name="Format"/> parameter).
        /// For example, given the <see cref="DXGI_FORMAT_R16G16B16A16_TYPELESS"/> format:
        /// </para>
        /// <para>
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
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public void ResolveSubresource([In] P<ID3D12Resource> pDstResource, [In] UINT DstSubresource,
            [In] P<ID3D12Resource> pSrcResource, [In] UINT SrcSubresource, [In] DXGI_FORMAT Format)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, UINT, P<ID3D12Resource>, UINT, DXGI_FORMAT, void>)_vTable[19])
                    (thisPtr, pDstResource, DstSubresource, pSrcResource, SrcSubresource, Format);
            }
        }

        /// <summary>
        /// Bind information about the primitive type, and data order that describes input data for the input assembler stage.
        /// </summary>
        /// <param name="PrimitiveTopology">
        /// The type of primitive and ordering of the primitive data (see <see cref="D3D_PRIMITIVE_TOPOLOGY"/>).
        /// </param>
        public void IASetPrimitiveTopology([In] D3D_PRIMITIVE_TOPOLOGY PrimitiveTopology)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, D3D_PRIMITIVE_TOPOLOGY, void>)_vTable[20])(thisPtr, PrimitiveTopology);
            }
        }

        /// <summary>
        /// Bind an array of viewports to the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="NumViewports">
        /// Number of viewports to bind.
        /// The range of valid values is (0, <see cref="D3D12_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE"/>).
        /// </param>
        /// <param name="pViewports">
        /// An array of <see cref="D3D12_VIEWPORT"/> structures to bind to the device.
        /// </param>
        /// <remarks>
        /// <para>
        /// All viewports must be set atomically as one operation.
        /// Any viewports not defined by the call are disabled.
        /// </para>
        /// <para>
        /// Which viewport to use is determined by the <c>SV_ViewportArrayIndex</c> semantic output by a geometry shader;
        /// if a geometry shader does not specify the semantic, Direct3D will use the first viewport in the array.
        /// </para>
        /// </remarks>
        public void RSSetViewports([In] UINT NumViewports, [In] D3D12_VIEWPORT[] pViewports)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_VIEWPORT* pViewportsPtr = pViewports)
                {
                    ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_VIEWPORT*, void>)_vTable[21])(thisPtr, NumViewports, pViewportsPtr);
                }
            }
        }

        /// <summary>
        /// Binds an array of scissor rectangles to the rasterizer stage.
        /// </summary>
        /// <param name="NumRects">
        /// The number of scissor rectangles to bind.
        /// </param>
        /// <param name="pRects">
        /// An array of scissor rectangles.
        /// </param>
        /// <remarks>
        /// <para>
        /// All scissor rectangles must be set atomically as one operation.
        /// Any scissor rectangles not defined by the call are disabled.
        /// </para>
        /// <para>
        /// Which scissor rectangle to use is determined by the <c>SV_ViewportArrayIndex</c> semantic output
        /// by a geometry shader (see shader semantic syntax).
        /// If a geometry shader does not make use of the <c>SV_ViewportArrayIndex</c> semantic
        /// then Direct3D will use the first scissor rectangle in the array.
        /// </para>
        /// <para>
        /// Each scissor rectangle in the array corresponds to a viewport in an array of viewports (see <see cref="RSSetViewports"/>).
        /// </para>
        /// </remarks>
        public void RSSetScissorRects([In] UINT NumRects, [In] D3D12_RECT[] pRects)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_RECT* pRectsPtr = pRects)
                {
                    ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_RECT*, void>)_vTable[22])(thisPtr, NumRects, pRectsPtr);
                }
            }
        }

        /// <summary>
        /// Sets the blend factor that modulate values for a pixel shader, render target, or both.
        /// </summary>
        /// <param name="BlendFactor">
        /// Array of blend factors, one for each RGBA component.
        /// </param>
        /// <remarks>
        /// <para>
        /// If you created the blend-state object with <see cref="D3D12_BLEND_BLEND_FACTOR"/> or <see cref="D3D12_BLEND_INV_BLEND_FACTOR"/>,
        /// then the blending stage uses the non-NULL array of blend factors.
        /// Otherwise,the blending stage doesn't use the non-NULL array of blend factors; the runtime stores the blend factors.
        /// </para>
        /// <para>
        /// If you pass NULL, then the runtime uses or stores a blend factor equal to <c>{ 1, 1, 1, 1 }</c>.
        /// </para>
        /// </remarks>
        public void OMSetBlendFactor([In] FLOAT[] BlendFactor)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (FLOAT* BlendFactorPtr = BlendFactor)
                {
                    ((delegate* unmanaged[Stdcall]<void*, FLOAT*, void>)_vTable[23])(thisPtr, BlendFactorPtr);
                }
            }
        }

        /// <summary>
        /// Sets the reference value for depth stencil tests.
        /// </summary>
        /// <param name="StencilRef">
        /// Reference value to perform against when doing a depth-stencil test.
        /// </param>
        public void OMSetStencilRef([In] UINT StencilRef)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, void>)_vTable[24])(thisPtr, StencilRef);
            }
        }

        /// <summary>
        /// Sets all shaders and programs most of the fixed-function state of the graphics processing unit (GPU) pipeline.
        /// </summary>
        /// <param name="pPipelineState">
        /// Pointer to the <see cref="ID3D12PipelineState"/> containing the pipeline state data.
        /// </param>
        public void SetPipelineState([In] P<ID3D12PipelineState> pPipelineState)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12PipelineState>, void>)_vTable[25])(thisPtr, pPipelineState);
            }
        }

        /// <summary>
        /// Notifies the driver that it needs to synchronize multiple accesses to resources.
        /// </summary>
        /// <param name="NumBarriers">
        /// The number of submitted barrier descriptions.
        /// </param>
        /// <param name="pBarriers">
        /// Pointer to an array of barrier descriptions.
        /// </param>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// A resource to be used for the <see cref="D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE"/> state
        /// must be created in that state, and then never transitioned out of it.
        /// Nor may a resource that was created not in that state be transitioned into it.
        /// For more info, see Acceleration structure memory restrictions in the DirectX raytracing (DXR) functional specification on GitHub.
        /// </para>
        /// <para>
        /// There are three types of barrier descriptions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_TRANSITION_BARRIER"/>
        /// - Transition barriers indicate that a set of subresources transition between different usages.
        /// The caller must specify the before and after usages of the subresources.
        /// The <see cref="D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES"/> flag is used to transition all subresources in a resource at the same time.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_ALIASING_BARRIER"/>
        /// - Aliasing barriers indicate a transition between usages of two different resources which have mappings into the same heap.
        /// The application can specify both the before and the after resource.
        /// Note that one or both resources can be <see cref="NULL"/> (indicating that any tiled resource could cause aliasing).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_UAV_BARRIER"/>
        /// - Unordered access view barriers indicate all UAV accesses (read or writes) to a particular resource must complete
        /// before any future UAV accesses (read or write) can begin.
        /// The specified resource may be <see cref="NULL"/>.
        /// It is not necessary to insert a UAV barrier between two draw or dispatch calls which only read a UAV.
        /// Additionally, it is not necessary to insert a UAV barrier between two draw or dispatch calls which write to the same UAV
        /// if the application knows that it is safe to execute the UAV accesses in any order.
        /// The resource can be <see cref="NULL"/> (indicating that any UAV access could require the barrier).
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When <see cref="ResourceBarrier"/> is passed an array of resource barrier descriptions,
        /// the API behaves as if it was called N times (1 for each array element), in the specified order.
        /// Transitions should be batched together into a single API call when possible, as a performance optimization.
        /// </para>
        /// <para>
        /// For descriptions of the usage states a subresource can be in,
        /// see the <see cref="D3D12_RESOURCE_STATES"/> enumeration
        /// and the Using Resource Barriers to Synchronize Resource States in Direct3D 12 section.
        /// </para>
        /// <para>
        /// All subresources in a resource must be in the RENDER_TARGET state, or DEPTH_WRITE state,
        /// for render targets/depth-stencil resources respectively, when <see cref="DiscardResource"/> is called.
        /// </para>
        /// <para>
        /// When a back buffer is presented, it must be in the <see cref="D3D12_RESOURCE_STATE_PRESENT"/> state.
        /// If <see cref="IDXGISwapChain1.Present1"/> is called on a resource which is not in the PRESENT state,
        /// a debug layer warning will be emitted.
        /// </para>
        /// <para>
        /// The resource usage bits are group into two categories, read-only and read/write.
        /// </para>
        /// <para>
        /// The following usage bits are read-only:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_INDEX_BUFFER"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_COPY_SOURCE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_DEPTH_READ"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following usage bits are read/write:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_UNORDERED_ACCESS"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_DEPTH_WRITE"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following usage bits are write-only:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_COPY_DEST"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_RENDER_TARGET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_STATE_STREAM_OUT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// At most one write bit can be set. If any write bit is set, then no read bit may be set.
        /// If no write bit is set, then any number of read bits may be set.
        /// </para>
        /// <para>
        /// At any given time, a subresource is in exactly one state (determined by a set of flags).
        /// The application must ensure that the states are matched when making a sequence of <see cref="ResourceBarrier"/> calls.
        /// In other words, the before and after states in consecutive calls to <see cref="ResourceBarrier"/> must agree.
        /// </para>
        /// <para>
        /// To transition all subresources within a resource,
        /// the application can set the subresource index to <see cref="D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES"/>,
        /// which implies that all subresources are changed.
        /// </para>
        /// <para>
        /// For improved performance, applications should use split barriers (refer to Multi-engine synchronization).
        /// Your application should also batch multiple transitions into a single call whenever possible.
        /// </para>
        /// <para>
        /// Runtime validation
        /// </para>
        /// <para>
        /// The runtime will validate that the barrier type values are valid members
        /// of the <see cref="D3D12_RESOURCE_BARRIER_TYPE"/> enumeration.
        /// </para>
        /// <para>
        /// In addition, the runtime checks the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The resource pointer is non-NULL.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The subresource index is valid
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The before and after states are supported by the <see cref="D3D12_RESOURCE_BINDING_TIER"/>
        /// and <see cref="D3D12_RESOURCE_FLAGS"/> flags of the resource.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Reserved bits in the state masks are not set.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The before and after states are different.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The set of bits in the before and after states are valid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the <see cref="D3D12_RESOURCE_STATE_RESOLVE_SOURCE"/> bit is set,
        /// then the resource sample count must be greater than 1.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the <see cref="D3D12_RESOURCE_STATE_RESOLVE_DEST"/> bit is set,
        /// then the resource sample count must be equal to 1.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For aliasing barriers the runtime will validate that,
        /// if either resource pointer is non-<see cref="NULL"/>, it refers to a tiled resource.
        /// </para>
        /// <para>
        /// For UAV barriers the runtime will validate that,
        /// if the resource is non-<see cref="NULL"/>,
        /// the resource has the <see cref="D3D12_RESOURCE_STATE_UNORDERED_ACCESS"/> bind flag set.
        /// </para>
        /// <para>
        /// Validation failure causes <see cref="Close"/> to return <see cref="E_INVALIDARG"/>.
        /// </para>
        /// <para>
        /// Debug layer
        /// </para>
        /// <para>
        /// The debug layer normally issues errors where runtime validation fails:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If a subresource transition in a command list is inconsistent with previous transitions in the same command list.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If a resource is used without first calling <see cref="ResourceBarrier"/> to put the resource into the correct state.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If a resource is illegally bound for read and write at the same time.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the before states passed to the <see cref="ResourceBarrier"/> do not match
        /// the after states of previous calls to <see cref="ResourceBarrier"/>, including the aliasing case.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Whereas the debug layer attempts to validate the runtime rules,
        /// it operates conservatively so that debug layer errors are real errors,
        /// and in some cases real errors may not produce debug layer errors.
        /// </para>
        /// <para>
        /// The debug layer will issue warnings in the following cases:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// All of the cases where the D3D12 debug layer would issues warnings for <see cref="ResourceBarrier"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If a depth buffer is used in a non-read-only mode
        /// while the resource has the <see cref="D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE"/> usage bit set.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public void ResourceBarrier([In] UINT NumBarriers, [In] D3D12_RESOURCE_BARRIER[] pBarriers)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_RESOURCE_BARRIER* pBarriersPtr = pBarriers)
                {
                    ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_RESOURCE_BARRIER*, void>)_vTable[26])(thisPtr, NumBarriers, pBarriersPtr);
                }
            }
        }

        /// <summary>
        /// Executes a bundle.
        /// </summary>
        /// <param name="pCommandList">
        /// Specifies the <see cref="ID3D12GraphicsCommandList"/> that determines the bundle to be executed.
        /// </param>
        /// <remarks>
        /// <para>
        /// Bundles inherit all state from the parent command list on which <see cref="ExecuteBundle"/> is called,
        /// except the pipeline state object and primitive topology.
        /// All of the state that is set in a bundle will affect the state of the parent command list.
        /// Note that <see cref="ExecuteBundle"/> is not a predicated operation.
        /// </para>
        /// <para>
        /// Runtime validation
        /// </para>
        /// <para>
        /// The runtime will validate that the "callee" is a bundle and that the "caller" is a direct command list.
        /// The runtime will also validate that the bundle has been closed.
        /// If the contract is violated, the runtime will silently drop the call.
        /// Validation failure will result in <see cref="Close"/> returning E_INVALIDARG.
        /// </para>
        /// <para>
        /// Debug layer
        /// </para>
        /// <para>
        /// The debug layer will issue a warning in the same cases where the runtime will fail.
        /// The debug layer will issue a warning if a predicate is set when <see cref="ID3D12CommandQueue.ExecuteCommandLists"/> is called.
        /// Also, the debug layer will issue an error if it detects that any resource reference by the command list has been destroyed.
        /// </para>
        /// <para>
        /// The debug layer will also validate that the command allocator associated with the bundle has not been reset
        /// since <see cref="Close"/> was called on the command list.
        /// This validation occurs at <see cref="ExecuteBundle"/> time, and when the parent command list is executed on a command queue.
        /// </para>
        /// </remarks>
        public void ExecuteBundle([In] P<ID3D12GraphicsCommandList> pCommandList)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12GraphicsCommandList>, void>)_vTable[27])(thisPtr, pCommandList);
            }
        }

        /// <summary>
        /// Changes the currently bound descriptor heaps that are associated with a command list.
        /// </summary>
        /// <param name="NumDescriptorHeaps">
        /// Number of descriptor heaps to bind.
        /// </param>
        /// <param name="ppDescriptorHeaps">
        /// <para>
        /// A pointer to an array of <see cref="ID3D12DescriptorHeap"/> objects for the heaps to set on the command list.
        /// </para>
        /// <para>
        /// You can only bind descriptor heaps of type <see cref="D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV"/>
        /// and <see cref="D3D12_DESCRIPTOR_HEAP_TYPE_SAMPLER"/>.
        /// </para>
        /// <para>
        /// Only one descriptor heap of each type can be set at one time,
        /// which means a maximum of 2 heaps (one sampler, one CBV/SRV/UAV) can be set at one time.
        /// </para>
        /// </param>
        /// <remarks>
        /// <para>
        /// <see cref="SetDescriptorHeaps"/> can be called on a bundle,
        /// but the bundle descriptor heaps must match the calling command list descriptor heap.
        /// For more information on bundle restrictions, refer to Creating and Recording Command Lists and Bundles.
        /// </para>
        /// <para>
        /// All previously set heaps are unset by the call. At most one heap of each shader-visible type can be set in the call.
        /// </para>
        /// <para>
        /// Changing descriptor heaps can incur a pipeline flush on some hardware.
        /// Because of this, it is recommended to use a single shader-visible heap of each type,
        /// and set it once per frame, rather than regularly changing the bound descriptor heaps.
        /// Instead, use <see cref="ID3D12Device.CopyDescriptors"/> and <see cref="ID3D12Device.CopyDescriptorsSimple"/>
        /// to copy the required descriptors from shader-opaque heaps to the single shader-visible heap as required during rendering.
        /// </para>
        /// </remarks>
        public void SetDescriptorHeaps([In] UINT NumDescriptorHeaps, [In] P<ID3D12DescriptorHeap>[] ppDescriptorHeaps)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (P<ID3D12DescriptorHeap>* ppDescriptorHeapsPtr = ppDescriptorHeaps)
                {
                    ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D12DescriptorHeap>*, void>)_vTable[28])
                        (thisPtr, NumDescriptorHeaps, ppDescriptorHeapsPtr);
                }
            }
        }

        /// <summary>
        /// Sets the layout of the compute root signature.
        /// </summary>
        /// <param name="pRootSignature">
        /// A pointer to the <see cref="ID3D12RootSignature"/> object.
        /// </param>
        public void SetComputeRootSignature([In] P<ID3D12RootSignature> pRootSignature)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12RootSignature>, void>)_vTable[29])(thisPtr, pRootSignature);
            }
        }

        /// <summary>
        /// Sets the layout of the graphics root signature.
        /// </summary>
        /// <param name="pRootSignature">
        /// A pointer to the <see cref="ID3D12RootSignature"/> object.
        /// </param>
        public void SetGraphicsRootSignature([In] P<ID3D12RootSignature> pRootSignature)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12RootSignature>, void>)_vTable[30])(thisPtr, pRootSignature);
            }
        }

        /// <summary>
        /// Sets a descriptor table into the compute root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="BaseDescriptor">
        /// A GPU_descriptor_handle object for the base descriptor to set.
        /// </param>
        public void SetComputeRootDescriptorTable([In] UINT RootParameterIndex, [In] D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_GPU_DESCRIPTOR_HANDLE, void>)_vTable[31])
                    (thisPtr, RootParameterIndex, BaseDescriptor);
            }
        }

        /// <summary>
        /// Sets a descriptor table into the graphics root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="BaseDescriptor">
        /// A GPU_descriptor_handle object for the base descriptor to set.
        /// </param>
        public void SetGraphicsRootDescriptorTable([In] UINT RootParameterIndex, [In] D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_GPU_DESCRIPTOR_HANDLE, void>)_vTable[32])
                    (thisPtr, RootParameterIndex, BaseDescriptor);
            }
        }

        /// <summary>
        /// Sets a constant in the compute root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="SrcData">
        /// The source data for the constant to set.
        /// </param>
        /// <param name="DestOffsetIn32BitValues">
        /// The offset, in 32-bit values, to set the constant in the root signature.
        /// </param>
        public void SetComputeRoot32BitConstant([In] UINT RootParameterIndex, [In] UINT SrcData, [In] UINT DestOffsetIn32BitValues)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, void>)_vTable[33])
                    (thisPtr, RootParameterIndex, SrcData, DestOffsetIn32BitValues);
            }
        }

        /// <summary>
        /// Sets a constant in the graphics root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="SrcData">
        /// The source data for the constant to set.
        /// </param>
        /// <param name="DestOffsetIn32BitValues">
        /// The offset, in 32-bit values, to set the constant in the root signature.
        /// </param>
        public void SetGraphicsRoot32BitConstant([In] UINT RootParameterIndex, [In] UINT SrcData, [In] UINT DestOffsetIn32BitValues)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, void>)_vTable[34])
                    (thisPtr, RootParameterIndex, SrcData, DestOffsetIn32BitValues);
            }
        }

        /// <summary>
        /// Sets a group of constants in the compute root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="Num32BitValuesToSet">
        /// The number of constants to set in the root signature.
        /// </param>
        /// <param name="pSrcData">
        /// The source data for the group of constants to set.
        /// </param>
        /// <param name="DestOffsetIn32BitValues">
        /// The offset, in 32-bit values, to set the first constant of the group in the root signature.
        /// </param>
        public void SetComputeRoot32BitConstants([In] UINT RootParameterIndex, [In] UINT Num32BitValuesToSet,
            [In] IntPtr pSrcData, [In] UINT DestOffsetIn32BitValues)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, IntPtr, UINT, void>)_vTable[35])
                    (thisPtr, RootParameterIndex, Num32BitValuesToSet, pSrcData, DestOffsetIn32BitValues);
            }
        }

        /// <summary>
        /// Sets a group of constants in the graphics root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="Num32BitValuesToSet">
        /// The number of constants to set in the root signature.
        /// </param>
        /// <param name="pSrcData">
        /// The source data for the group of constants to set.
        /// </param>
        /// <param name="DestOffsetIn32BitValues">
        /// The offset, in 32-bit values, to set the first constant of the group in the root signature.
        /// </param>
        public void SetGraphicsRoot32BitConstants([In] UINT RootParameterIndex, [In] UINT Num32BitValuesToSet,
            [In] IntPtr pSrcData, [In] UINT DestOffsetIn32BitValues)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, IntPtr, UINT, void>)_vTable[36])
                    (thisPtr, RootParameterIndex, Num32BitValuesToSet, pSrcData, DestOffsetIn32BitValues);
            }
        }

        /// <summary>
        /// Sets a CPU descriptor handle for the constant buffer in the compute root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="BufferLocation">
        /// Specifies the <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> of the constant buffer.
        /// </param>
        public void SetComputeRootConstantBufferView([In] UINT RootParameterIndex, [In] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_GPU_VIRTUAL_ADDRESS, void>)_vTable[37])
                    (thisPtr, RootParameterIndex, BufferLocation);
            }
        }

        /// <summary>
        /// Sets a CPU descriptor handle for the constant buffer in the graphics root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="BufferLocation">
        /// The GPU virtual address of the constant buffer.
        /// <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> is a typedef'd alias of <see cref="UINT64"/>.
        /// </param>
        public void SetGraphicsRootConstantBufferView([In] UINT RootParameterIndex, [In] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_GPU_VIRTUAL_ADDRESS, void>)_vTable[38])
                    (thisPtr, RootParameterIndex, BufferLocation);
            }
        }

        /// <summary>
        /// Sets a CPU descriptor handle for the shader resource in the compute root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="BufferLocation">
        /// The GPU virtual address of the buffer.
        /// <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> is a typedef'd alias of <see cref="UINT64"/>.
        /// </param>
        public void SetComputeRootShaderResourceView([In] UINT RootParameterIndex, [In] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_GPU_VIRTUAL_ADDRESS, void>)_vTable[39])
                    (thisPtr, RootParameterIndex, BufferLocation);
            }
        }

        /// <summary>
        /// Sets a CPU descriptor handle for the shader resource in the graphics root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="BufferLocation">
        /// The GPU virtual address of the Buffer. Textures are not supported.
        /// <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> is a typedef'd alias of <see cref="UINT64"/>.
        /// </param>
        public void SetGraphicsRootShaderResourceView([In] UINT RootParameterIndex, [In] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_GPU_VIRTUAL_ADDRESS, void>)_vTable[40])
                    (thisPtr, RootParameterIndex, BufferLocation);
            }
        }

        /// <summary>
        /// Sets a CPU descriptor handle for the unordered-access-view resource in the compute root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="BufferLocation">
        /// The GPU virtual address of the buffer.
        /// <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> is a typedef'd alias of <see cref="UINT64"/>.
        /// </param>
        public void SetComputeRootUnorderedAccessView([In] UINT RootParameterIndex, [In] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_GPU_VIRTUAL_ADDRESS, void>)_vTable[41])
                    (thisPtr, RootParameterIndex, BufferLocation);
            }
        }

        /// <summary>
        /// Sets a CPU descriptor handle for the unordered-access-view resource in the graphics root signature.
        /// </summary>
        /// <param name="RootParameterIndex">
        /// The slot number for binding.
        /// </param>
        /// <param name="BufferLocation">
        /// The GPU virtual address of the buffer.
        /// <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> is a typedef'd alias of <see cref="UINT64"/>.
        /// </param>
        public void SetGraphicsRootUnorderedAccessView([In] UINT RootParameterIndex, [In] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_GPU_VIRTUAL_ADDRESS, void>)_vTable[42])
                    (thisPtr, RootParameterIndex, BufferLocation);
            }
        }

        /// <summary>
        /// Sets the view for the index buffer.
        /// </summary>
        /// <param name="pView">
        /// The view specifies the index buffer's address, size, and <see cref="DXGI_FORMAT"/>,
        /// as a pointer to a <see cref="D3D12_INDEX_BUFFER_VIEW"/> structure.
        /// </param>
        /// <remarks>
        /// Only one index buffer can be bound to the graphics pipeline at any one time.
        /// </remarks>
        public void IASetIndexBuffer([In] in D3D12_INDEX_BUFFER_VIEW pView)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D3D12_INDEX_BUFFER_VIEW, void>)_vTable[43])(thisPtr, pView);
            }
        }

        /// <summary>
        /// Sets a CPU descriptor handle for the vertex buffers.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting vertex buffers.
        /// </param>
        /// <param name="NumViews">
        /// The number of views in the <paramref name="pViews"/> array.
        /// </param>
        /// <param name="pViews">
        /// Specifies the vertex buffer views in an array of <see cref="D3D12_VERTEX_BUFFER_VIEW"/> structures.
        /// </param>
        public void IASetVertexBuffers([In] UINT StartSlot, [In] UINT NumViews, [In] D3D12_VERTEX_BUFFER_VIEW[] pViews)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_VERTEX_BUFFER_VIEW* pViewsPtr = pViews)
                {
                    ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3D12_VERTEX_BUFFER_VIEW*, void>)_vTable[44])
                        (thisPtr, StartSlot, NumViews, pViewsPtr);
                }
            }
        }

        /// <summary>
        /// Sets the stream output buffer views.
        /// </summary>
        /// <param name="StartSlot">
        /// Index into the device's zero-based array to begin setting stream output buffers.
        /// </param>
        /// <param name="NumViews">
        /// The number of entries in the <paramref name="pViews"/> array.
        /// </param>
        /// <param name="pViews">
        /// Specifies an array of <see cref="D3D12_STREAM_OUTPUT_BUFFER_VIEW"/> structures.
        /// </param>
        public void SOSetTargets([In] UINT StartSlot, [In] UINT NumViews, [In] D3D12_STREAM_OUTPUT_BUFFER_VIEW[] pViews)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_STREAM_OUTPUT_BUFFER_VIEW* pViewsPtr = pViews)
                {
                    ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3D12_STREAM_OUTPUT_BUFFER_VIEW*, void>)_vTable[45])
                        (thisPtr, StartSlot, NumViews, pViewsPtr);
                }
            }
        }

        /// <summary>
        /// Sets CPU descriptor handles for the render targets and depth stencil.
        /// </summary>
        /// <param name="NumRenderTargetDescriptors">
        /// The number of entries in the <paramref name="pRenderTargetDescriptors"/> array
        /// (ranges between 0 and <see cref="D3D12_SIMULTANEOUS_RENDER_TARGET_COUNT"/>).
        /// If this parameter is nonzero, the number of entries in the array
        /// to which <paramref name="pRenderTargetDescriptors"/> points must equal the number in this parameter.
        /// </param>
        /// <param name="pRenderTargetDescriptors">
        /// Specifies an array of <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> structures
        /// that describe the CPU descriptor handles that represents the start of the heap of render target descriptors.
        /// If this parameter is <see cref="NullRef{D3D12_CPU_DESCRIPTOR_HANDLE}"/>
        /// and <paramref name="NumRenderTargetDescriptors"/> is 0, no render targets are bound.
        /// </param>
        /// <param name="RTsSingleHandleToDescriptorRange">
        /// <para>
        /// <see cref="TRUE"/> means the handle passed in is the pointer
        /// to a contiguous range of <paramref name="NumRenderTargetDescriptors"/> descriptors.
        /// This case is useful if the set of descriptors to bind already happens to be contiguous in memory
        /// (so all that’s needed is a handle to the first one).
        /// For example, if <paramref name="NumRenderTargetDescriptors"/> is 3 then the memory layout is taken as follows:
        /// In this case the driver dereferences the handle and then increments the memory being pointed to.
        /// </para>
        /// <para>
        /// <see cref="FALSE"/> means that the handle is the first of an array of <paramref name="NumRenderTargetDescriptors"/> handles.
        /// The false case allows an application to bind a set of descriptors from different locations at once.
        /// Again assuming that <paramref name="NumRenderTargetDescriptors"/> is 3, the memory layout is taken as follows:
        /// In this case the driver dereferences three handles that are expected to be adjacent to each other in memory.
        /// </para>
        /// </param>
        /// <param name="pDepthStencilDescriptor">
        /// A pointer to a <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> structure that describes the CPU descriptor handle
        /// that represents the start of the heap that holds the depth stencil descriptor.
        /// If this parameter is <see cref="NullRef{D3D12_CPU_DESCRIPTOR_HANDLE}"/>, no depth stencil descriptor is bound.
        /// </param>
        public void OMSetRenderTargets([In] UINT NumRenderTargetDescriptors, [In] in D3D12_CPU_DESCRIPTOR_HANDLE pRenderTargetDescriptors,
            [In] BOOL RTsSingleHandleToDescriptorRange, [In] in D3D12_CPU_DESCRIPTOR_HANDLE pDepthStencilDescriptor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, in D3D12_CPU_DESCRIPTOR_HANDLE, BOOL, in D3D12_CPU_DESCRIPTOR_HANDLE, void>)_vTable[46])
                    (thisPtr, NumRenderTargetDescriptors, pRenderTargetDescriptors, RTsSingleHandleToDescriptorRange, pDepthStencilDescriptor);
            }
        }

        /// <summary>
        /// Describes the CPU descriptor handle that represents the start of the heap for the depth stencil to be cleared.
        /// </summary>
        /// <param name="DepthStencilView">
        /// A combination of <see cref="D3D12_CLEAR_FLAGS"/> values that are combined by using a bitwise OR operation.
        /// The resulting value identifies the type of data to clear (depth buffer, stencil buffer, or both).
        /// </param>
        /// <param name="ClearFlags">
        /// A value to clear the depth buffer with.
        /// This value will be clamped between 0 and 1.
        /// </param>
        /// <param name="Depth">
        /// A value to clear the depth buffer with. This value will be clamped between 0 and 1.
        /// </param>
        /// <param name="Stencil">
        /// A value to clear the stencil buffer with.
        /// </param>
        /// <param name="NumRects">
        /// The number of rectangles in the array that the <paramref name="pRects"/> parameter specifies.
        /// </param>
        /// <param name="pRects">
        /// An array of <see cref="D3D12_RECT"/> structures for the rectangles in the resource view to clear.
        /// If <see langword="null"/>, <see cref="ClearDepthStencilView"/> clears the entire resource view.
        /// </param>
        /// <remarks>
        /// <para>
        /// Only direct and bundle command lists support this operation.
        /// </para>
        /// <para>
        /// <see cref="ClearDepthStencilView"/> may be used to initialize resources which alias the same heap memory.
        /// See <see cref="ID3D12Device.CreatePlacedResource"/> for more details.
        /// </para>
        /// <para>
        /// Runtime validation
        /// </para>
        /// <para>
        /// For floating-point inputs, the runtime will set denormalized values to 0 (while preserving NANs).
        /// </para>
        /// <para>
        /// Validation failure will result in the call to <see cref="Close"/> returning <see cref="E_INVALIDARG"/>.
        /// </para>
        /// <para>
        /// Debug layer
        /// </para>
        /// <para>
        /// The debug layer will issue errors if the input colors are denormalized.
        /// </para>
        /// <para>
        /// The debug layer will issue an error if the subresources referenced by the view are not in the appropriate state.
        /// For <see cref="ClearDepthStencilView"/>, the state must be in the state <see cref="D3D12_RESOURCE_STATE_DEPTH_WRITE"/>.
        /// </para>
        /// </remarks>
        public void ClearDepthStencilView([In] D3D12_CPU_DESCRIPTOR_HANDLE DepthStencilView, [In] D3D12_CLEAR_FLAGS ClearFlags,
            [In] FLOAT Depth, [In] UINT8 Stencil, [In] UINT NumRects, [In] D3D12_RECT[] pRects)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_RECT* pRectsPtr = pRects)
                {
                    ((delegate* unmanaged[Stdcall]<void*, D3D12_CPU_DESCRIPTOR_HANDLE, D3D12_CLEAR_FLAGS,
                        FLOAT, UINT8, UINT, D3D12_RECT*, void>)_vTable[47])
                        (thisPtr, DepthStencilView, ClearFlags, Depth, Stencil, NumRects, pRectsPtr);
                }
            }
        }

        /// <summary>
        /// Sets all the elements in a render target to one value.
        /// </summary>
        /// <param name="RenderTargetView">
        /// Specifies a <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> structure
        /// that describes the CPU descriptor handle that represents the start of the heap for the render target to be cleared.
        /// </param>
        /// <param name="ColorRGBA">
        /// A 4-component array that represents the color to fill the render target with.
        /// </param>
        /// <param name="NumRects">
        /// The number of rectangles in the array that the <paramref name="pRects"/> parameter specifies.
        /// </param>
        /// <param name="pRects">
        /// An array of <see cref="D3D12_RECT"/> structures for the rectangles in the resource view to clear.
        /// If <see langword="null"/>, <see cref="ClearRenderTargetView"/> clears the entire resource view.
        /// </param>
        /// <remarks>
        /// <para>
        /// <see cref="ClearRenderTargetView"/> may be used to initialize resources which alias the same heap memory.
        /// See <see cref="ID3D12Device.CreatePlacedResource"/> for more details.
        /// </para>
        /// <para>
        /// Runtime validation
        /// </para>
        /// <para>
        /// For floating-point inputs, the runtime will set denormalized values to 0 (while preserving NANs).
        /// </para>
        /// <para>
        /// Validation failure will result in the call to <see cref="Close"/> returning <see cref="E_INVALIDARG"/>.
        /// </para>
        /// <para>
        /// Debug layer
        /// </para>
        /// <para>
        /// The debug layer will issue errors if the input colors are denormalized.
        /// </para>
        /// <para>
        /// The debug layer will issue an error if the subresources referenced by the view are not in the appropriate state.
        /// For <see cref="ClearRenderTargetView"/>, the state must be <see cref="D3D12_RESOURCE_STATE_RENDER_TARGET"/>.
        /// </para>
        /// </remarks>
        public void ClearRenderTargetView([In] D3D12_CPU_DESCRIPTOR_HANDLE RenderTargetView,
            [In] FLOAT[] ColorRGBA, [In] UINT NumRects, [In] D3D12_RECT[] pRects)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (FLOAT* ColorRGBAPtr = ColorRGBA)
                {
                    fixed (D3D12_RECT* pRectsPtr = pRects)
                    {
                        ((delegate* unmanaged[Stdcall]<void*, D3D12_CPU_DESCRIPTOR_HANDLE, FLOAT*, UINT, D3D12_RECT*, void>)_vTable[48])
                            (thisPtr, RenderTargetView, ColorRGBAPtr, NumRects, pRectsPtr);
                    }
                }
            }
        }

        /// <summary>
        /// <para>
        /// Sets all the elements in a unordered-access view (UAV) to the specified integer values.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// This behaves like a compute operation in that it isn't ordered with respect to surrounding work such as <see cref="Dispatch"/> calls.
        /// To ensure ordering, barrier calls must be issued before and/or after the <c>ClearUnorderedAccessViewXxx</c> call as needed.
        /// It might appear on some drivers that such barriers aren't necessary.
        /// But implicit barriers are not a spec guarantee; so they can't be relied upon.
        /// This is in contrast to <see cref="ClearDepthStencilView"/> and <see cref="ClearRenderTargetView"/>
        /// which (like <c>DrawXxx</c> commands), respect command list ordering.
        /// </para>
        /// </summary>
        /// <param name="ViewGPUHandleInCurrentHeap">
        /// A <see cref="D3D12_GPU_DESCRIPTOR_HANDLE"/> that references an initialized descriptor
        /// for the unordered-access view (UAV) that is to be cleared.
        /// This descriptor must be in a shader-visible descriptor heap,
        /// which must be set on the command list via <see cref="SetDescriptorHeaps"/>.
        /// </param>
        /// <param name="ViewCPUHandle">
        /// <para>
        /// A <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> in a non-shader visible descriptor heap
        /// that references an initialized descriptor for the unordered-access view (UAV) that is to be cleared.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// This descriptor must not be in a shader-visible descriptor heap.
        /// This is to allow drivers that implement the clear as a fixed-function hardware operation
        /// (rather than as a dispatch) to efficiently read from the descriptor,
        /// as shader-visible heaps may be created in WRITE_COMBINE memory
        /// (similar to <see cref="D3D12_HEAP_TYPE_UPLOAD"/> heap types),
        /// and CPU reads from this type of memory are prohibitively slow.
        /// </para>
        /// </param>
        /// <param name="pResource">
        /// A pointer to the <see cref="ID3D12Resource"/> interface that represents the unordered-access-view (UAV) resource to clear.
        /// </param>
        /// <param name="Values">
        /// A 4-component array that containing the values to fill the unordered-access-view resource with.
        /// </param>
        /// <param name="NumRects">
        /// The number of rectangles in the array that the <paramref name="pRects"/>parameter specifies.
        /// </param>
        /// <param name="pRects">
        /// An array of <see cref="D3D12_RECT"/> structures for the rectangles in the resource view to clear.
        /// If <see langword="null"/>, <see cref="ClearUnorderedAccessViewUint"/> clears the entire resource view.
        /// </param>
        /// <remarks>
        /// <para>
        /// Runtime validation
        /// </para>
        /// <para>
        /// Validation failure results in the call to <see cref="Close"/> returning <see cref="E_INVALIDARG"/>.
        /// </para>
        /// <para>
        /// Debug layer
        /// </para>
        /// <para>
        /// The debug layer issues errors if the input values are outside of a normalized range.
        /// </para>
        /// <para>
        /// The debug layer issues an error if the subresources referenced by the view aren't in the appropriate state.
        /// For <see cref="ClearUnorderedAccessViewUint"/>, the state must be <see cref="D3D12_RESOURCE_STATE_UNORDERED_ACCESS"/>.
        /// </para>
        /// </remarks>
        public void ClearUnorderedAccessViewUint([In] D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap,
            [In] D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle, [In] P<ID3D12Resource> pResource, [In] UINT[] Values,
            [In] UINT NumRects, [In] D3D12_RECT[] pRects)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (UINT* ValuesPtr = Values)
                {
                    fixed (D3D12_RECT* pRectsPtr = pRects)
                    {
                        ((delegate* unmanaged[Stdcall]<void*, D3D12_GPU_DESCRIPTOR_HANDLE, D3D12_CPU_DESCRIPTOR_HANDLE,
                            P<ID3D12Resource>, UINT*, UINT, D3D12_RECT*, void>)_vTable[49])
                            (thisPtr, ViewGPUHandleInCurrentHeap, ViewCPUHandle, pResource, ValuesPtr, NumRects, pRectsPtr);
                    }
                }
            }
        }

        /// <summary>
        /// <para>
        /// Sets all the elements in a unordered-access view (UAV) to the specified float values.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// This behaves like a compute operation in that it isn't ordered with respect to surrounding work such as <see cref="Dispatch"/> calls.
        /// To ensure ordering, barrier calls must be issued before and/or after the <c>ClearUnorderedAccessViewXxx</c> call as needed.
        /// It might appear on some drivers that such barriers aren't necessary.
        /// But implicit barriers are not a spec guarantee; so they can't be relied upon.
        /// This is in contrast to <see cref="ClearDepthStencilView"/> and <see cref="ClearRenderTargetView"/>
        /// which (like <c>DrawXxx</c> commands), respect command list ordering.
        /// </para>
        /// </summary>
        /// <param name="ViewGPUHandleInCurrentHeap">
        /// A <see cref="D3D12_GPU_DESCRIPTOR_HANDLE"/> that references an initialized descriptor
        /// for the unordered-access view (UAV) that is to be cleared.
        /// This descriptor must be in a shader-visible descriptor heap,
        /// which must be set on the command list via <see cref="SetDescriptorHeaps"/>.
        /// </param>
        /// <param name="ViewCPUHandle">
        /// <para>
        /// A <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> in a non-shader visible descriptor heap
        /// that references an initialized descriptor for the unordered-access view (UAV) that is to be cleared.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// This descriptor must not be in a shader-visible descriptor heap.
        /// This is to allow drivers that implement the clear as a fixed-function hardware operation
        /// (rather than as a dispatch) to efficiently read from the descriptor,
        /// as shader-visible heaps may be created in WRITE_COMBINE memory
        /// (similar to <see cref="D3D12_HEAP_TYPE_UPLOAD"/> heap types),
        /// and CPU reads from this type of memory are prohibitively slow.
        /// </para>
        /// </param>
        /// <param name="pResource">
        /// A pointer to the <see cref="ID3D12Resource"/> interface that represents the unordered-access-view (UAV) resource to clear.
        /// </param>
        /// <param name="Values">
        /// A 4-component array that containing the values to fill the unordered-access-view resource with.
        /// </param>
        /// <param name="NumRects">
        /// The number of rectangles in the array that the <paramref name="pRects"/>parameter specifies.
        /// </param>
        /// <param name="pRects">
        /// An array of <see cref="D3D12_RECT"/> structures for the rectangles in the resource view to clear.
        /// If <see langword="null"/>, <see cref="ClearUnorderedAccessViewFloat"/> clears the entire resource view.
        /// </param>
        /// <remarks>
        /// <para>
        /// Runtime validation
        /// </para>
        /// <para>
        /// For floating-point inputs, the runtime sets denormalized values to 0 (while preserving NANs).
        /// </para>
        /// <para>
        /// If you want to clear the UAV to a specific bit pattern, consider using <see cref="ClearUnorderedAccessViewUint"/>.
        /// </para>
        /// <para>
        /// Validation failure results in the call to <see cref="Close"/> returning <see cref="E_INVALIDARG"/>.
        /// </para>
        /// <para>
        /// Debug layer
        /// </para>
        /// <para>
        /// The debug layer issues errors if the input values are outside of a normalized range.
        /// </para>
        /// <para>
        /// The debug layer issues an error if the subresources referenced by the view aren't in the appropriate state.
        /// For <see cref="ClearUnorderedAccessViewUint"/>, the state must be <see cref="D3D12_RESOURCE_STATE_UNORDERED_ACCESS"/>.
        /// </para>
        /// </remarks>
        public void ClearUnorderedAccessViewFloat([In] D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap,
            [In] D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle, [In] P<ID3D12Resource> pResource, [In] FLOAT[] Values,
            [In] UINT NumRects, [In] D3D12_RECT[] pRects)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (FLOAT* ValuesPtr = Values)
                {
                    fixed (D3D12_RECT* pRectsPtr = pRects)
                    {
                        ((delegate* unmanaged[Stdcall]<void*, D3D12_GPU_DESCRIPTOR_HANDLE, D3D12_CPU_DESCRIPTOR_HANDLE,
                            P<ID3D12Resource>, FLOAT*, UINT, D3D12_RECT*, void>)_vTable[50])
                            (thisPtr, ViewGPUHandleInCurrentHeap, ViewCPUHandle, pResource, ValuesPtr, NumRects, pRectsPtr);
                    }
                }
            }
        }

        /// <summary>
        /// Indicates that the contents of a resource don't need to be preserved.
        /// The function may re-initialize resource metadata in some cases.
        /// </summary>
        /// <param name="pResource">
        /// A pointer to the <see cref="ID3D12Resource"/> interface for the resource to discard.
        /// </param>
        /// <param name="pRegion">
        /// A pointer to a <see cref="D3D12_DISCARD_REGION"/> structure
        /// that describes details for the discard-resource operation.
        /// </param>
        /// <remarks>
        /// <para>
        /// The semantics of <see cref="DiscardResource"/> change based on the command list type.
        /// </para>
        /// <para>
        /// For <see cref="D3D12_COMMAND_LIST_TYPE_DIRECT"/>, the following two rules apply:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// When a resource has the <see cref="D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET"/> flag,
        /// <see cref="DiscardResource"/> must be called when the discarded subresource regions
        /// are in the <see cref="D3D12_RESOURCE_STATE_RENDER_TARGET"/> resource barrier state.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// When a resource has the <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/> flag,
        /// <see cref="DiscardResource"/> must be called when the discarded subresource regions
        /// are in the <see cref="D3D12_RESOURCE_STATE_DEPTH_WRITE"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For <see cref="D3D12_COMMAND_LIST_TYPE_COMPUTE"/>, the following rule applies:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The resource must have the <see cref="D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS"/> flag,
        /// and <see cref="DiscardResource"/> must be called
        /// when the discarded subresource regions are in the <see cref="D3D12_RESOURCE_STATE_UNORDERED_ACCESS"/> resource barrier state.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="DiscardResource"/> is not supported on command lists
        /// with either <see cref="D3D12_COMMAND_LIST_TYPE_BUNDLE"/> nor <see cref="D3D12_COMMAND_LIST_TYPE_COPY"/>.
        /// </para>
        /// </remarks>
        public void DiscardResource([In] P<ID3D12Resource> pResource, [In] in D3D12_DISCARD_REGION pRegion)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, in D3D12_DISCARD_REGION, void>)_vTable[51])
                    (thisPtr, pResource, pRegion);
            }
        }

        /// <summary>
        /// Starts a query running.
        /// </summary>
        /// <param name="pQueryHeap">
        /// Specifies the <see cref="ID3D12QueryHeap"/> containing the query.
        /// </param>
        /// <param name="Type">
        /// Specifies one member of <see cref="D3D12_QUERY_TYPE"/>.
        /// </param>
        /// <param name="Index">
        /// Specifies the index of the query within the query heap.
        /// </param>
        /// <remarks>
        /// See Queries for more information about D3D12 queries.
        /// </remarks>
        public void BeginQuery([In] P<ID3D12QueryHeap> pQueryHeap, [In] D3D12_QUERY_TYPE Type, [In] UINT Index)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12QueryHeap>, D3D12_QUERY_TYPE, UINT, void>)_vTable[52])
                    (thisPtr, pQueryHeap, Type, Index);
            }
        }

        /// <summary>
        /// Ends a running query.
        /// </summary>
        /// <param name="pQueryHeap">
        /// Specifies the <see cref="ID3D12QueryHeap"/> containing the query.
        /// </param>
        /// <param name="Type">
        /// Specifies one member of <see cref="D3D12_QUERY_TYPE"/>.
        /// </param>
        /// <param name="Index">
        /// Specifies the index of the query in the query heap.
        /// </param>
        /// <remarks>
        /// See Queries for more information about D3D12 queries.
        /// </remarks>
        public void EndQuery([In] P<ID3D12QueryHeap> pQueryHeap, [In] D3D12_QUERY_TYPE Type, [In] UINT Index)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12QueryHeap>, D3D12_QUERY_TYPE, UINT, void>)_vTable[53])
                    (thisPtr, pQueryHeap, Type, Index);
            }
        }

        /// <summary>
        /// Extracts data from a query.
        /// <see cref="ResolveQueryData"/> works with all heap types (default, upload, and readback).
        /// </summary>
        /// <param name="pQueryHeap">
        /// Specifies the <see cref="ID3D12QueryHeap"/> containing the queries to resolve.
        /// </param>
        /// <param name="Type">
        /// Specifies the type of query, one member of <see cref="D3D12_QUERY_TYPE"/>.
        /// </param>
        /// <param name="StartIndex">
        /// Specifies an index of the first query to resolve.
        /// </param>
        /// <param name="NumQueries">
        /// Specifies the number of queries to resolve.
        /// </param>
        /// <param name="pDestinationBuffer">
        /// Specifies an <see cref="ID3D12Resource"/> destination buffer,
        /// which must be in the state <see cref="D3D12_RESOURCE_STATE_COPY_DEST"/>.
        /// </param>
        /// <param name="AlignedDestinationBufferOffset">
        /// Specifies an alignment offset into the destination buffer.
        /// Must be a multiple of 8 bytes.
        /// </param>
        /// <remarks>
        /// <para>
        /// <see cref="ResolveQueryData"/> performs a batched operation that writes query data into a destination buffer.
        /// Query data is written contiguously to the destination buffer, and the parameter.
        /// </para>
        /// <para>
        /// <see cref="ResolveQueryData"/> turns application-opaque query data
        /// in an application-opaque query heap into adapter-agnostic values usable by your application.
        /// Resolving queries within a heap that have not been completed (so have had <see cref="BeginQuery"/> called for them,
        /// but not <see cref="EndQuery"/>), or that have been uninitialized,
        /// results in undefined behavior and might cause device hangs or removal.
        /// The debug layer will emit an error if it detects an application has resolved incomplete or uninitialized queries.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// Resolving incomplete or uninitialized queries is undefined behavior
        /// because the driver might internally store GPUVAs or other data within unresolved queries.
        /// And so attempting to resolve these queries on uninitialized data could cause a page fault or device hang.
        /// Older versions of the debug layer didn't validate this behavior.
        /// </para>
        /// <para>
        /// Binary occlusion queries write 64-bits per query.
        /// The least significant bit is either 0 (the object was entirely occluded)
        /// or 1 (at least 1 sample of the object would have been drawn).
        /// The rest of the bits are 0. Occlusion queries write 64-bits per query.
        /// The value is the number of samples that passed testing.
        /// Timestamp queries write 64-bits per query, 
        /// which is a tick value that must be compared to the respective command queue frequency (see Timing).
        /// </para>
        /// <para>
        /// Pipeline statistics queries write a <see cref="D3D12_QUERY_DATA_PIPELINE_STATISTICS"/> structure per query.
        /// All stream-out statistics queries write a <see cref="D3D12_QUERY_DATA_SO_STATISTICS"/> structure per query.
        /// </para>
        /// <para>
        /// The core runtime will validate the following.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <paramref name="StartIndex"/> and <paramref name="NumQueries"/> are within range.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="AlignedDestinationBufferOffset"/> is a multiple of 8 bytes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="pDestinationBuffer"/> is a buffer.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The written data will not overflow the output buffer.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The query type must be supported by the command list type.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The query type must be supported by the query heap.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The debug layer will issue a warning if the destination buffer is not in the <see cref="D3D12_RESOURCE_STATE_COPY_DEST"/> state,
        /// or if any queries being resolved have not had <see cref="EndQuery"/> called on them.
        /// </para>
        /// </remarks>
        public void ResolveQueryData([In] P<ID3D12QueryHeap> pQueryHeap, [In] D3D12_QUERY_TYPE Type, [In] UINT StartIndex,
            [In] UINT NumQueries, [In] P<ID3D12Resource> pDestinationBuffer, [In] UINT64 AlignedDestinationBufferOffset)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12QueryHeap>, D3D12_QUERY_TYPE, UINT, UINT, P<ID3D12Resource>, UINT64, void>)_vTable[54])
                    (thisPtr, pQueryHeap, Type, StartIndex, NumQueries, pDestinationBuffer, AlignedDestinationBufferOffset);
            }
        }

        /// <summary>
        /// Sets a rendering predicate.
        /// </summary>
        /// <param name="pBuffer">
        /// The buffer, as an <see cref="ID3D12Resource"/>,
        /// which must be in the <see cref="D3D12_RESOURCE_STATE_PREDICATION"/>
        /// or <see cref="D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT"/> state (both values are identical, and provided as aliases for clarity),
        /// or <see cref="NULL"/> to disable predication.
        /// </param>
        /// <param name="AlignedBufferOffset">
        /// The aligned buffer offset, as a <see cref="UINT64"/>.
        /// </param>
        /// <param name="Operation">
        /// Specifies a <see cref="D3D12_PREDICATION_OP"/>,
        /// such as <see cref="D3D12_PREDICATION_OP_EQUAL_ZERO"/> or <see cref="D3D12_PREDICATION_OP_NOT_EQUAL_ZERO"/>.
        /// </param>
        /// <remarks>
        /// <para>
        /// Use this method to denote that subsequent rendering and resource manipulation commands are not actually performed
        /// if the resulting predicate data of the predicate is equal to the operation specified.
        /// </para>
        /// <para>
        /// Unlike Direct3D 11, in Direct3D 12 predication state is not inherited by direct command lists,
        /// and predication is always respected (there are no predication hints).
        /// All direct command lists begin with predication disabled. Bundles do inherit predication state.
        /// It is legal for the same predicate to be bound multiple times.
        /// </para>
        /// <para>
        /// Illegal API calls will result in <see cref="Close"/> returning an error,
        /// or <see cref="ID3D12CommandQueue.ExecuteCommandLists"/> dropping the command list and removing the device.
        /// </para>
        /// <para>
        /// The debug layer will issue errors whenever the runtime validation fails.
        /// </para>
        /// <para>
        /// Refer to Predication for more information.
        /// </para>
        /// </remarks>
        public void SetPredication([In] P<ID3D12Resource> pBuffer, [In] UINT64 AlignedBufferOffset, [In] D3D12_PREDICATION_OP Operation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, UINT64, D3D12_PREDICATION_OP, void>)_vTable[55])
                    (thisPtr, pBuffer, AlignedBufferOffset, Operation);
            }
        }

        /// <summary>
        /// Not intended to be called directly.
        /// Use the PIX event runtime to insert events into a command list.
        /// </summary>
        /// <param name="Metadata">
        /// Internal.
        /// </param>
        /// <param name="pData">
        /// Internal.
        /// </param>
        /// <param name="Size">
        /// Internal.
        /// </param>
        /// <remarks>
        /// <para>
        /// This is a support method used internally by the PIX event runtime.
        /// It is not intended to be called directly.
        /// </para>
        /// <para>
        /// To insert instrumentation markers at the current location within a D3D12 command list, use the <c>PIXSetMarker</c> function.
        /// This is provided by the WinPixEventRuntime NuGet package.
        /// </para>
        /// </remarks>
        public void SetMarker([In] UINT Metadata, [In] IntPtr pData, [In] UINT Size)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, IntPtr, UINT, void>)_vTable[56])(thisPtr, Metadata, pData, Size);
            }
        }

        /// <summary>
        /// Not intended to be called directly.
        /// Use the PIX event runtime to insert events into a command list.
        /// </summary>
        /// <param name="Metadata">
        /// Internal.
        /// </param>
        /// <param name="pData">
        /// Internal.
        /// </param>
        /// <param name="Size">
        /// Internal.
        /// </param>
        /// <remarks>
        /// <para>
        /// This is a support method used internally by the PIX event runtime.
        /// It is not intended to be called directly.
        /// </para>
        /// <para>
        /// To insert instrumentation markers at the current location within a D3D12 command list,
        /// use the <c>PIXBeginEvent</c> function or <c>PIXScopedEvent</c> macro. 
        /// This is provided by the WinPixEventRuntime NuGet package.
        /// </para>
        /// </remarks>
        public void BeginEvent([In] UINT Metadata, [In] IntPtr pData, [In] UINT Size)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, IntPtr, UINT, void>)_vTable[57])(thisPtr, Metadata, pData, Size);
            }
        }

        /// <summary>
        /// Not intended to be called directly.
        /// Use the PIX event runtime to insert events into a command list.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is a support method used internally by the PIX event runtime.
        /// It is not intended to be called directly.
        /// </para>
        /// <para>
        /// To insert instrumentation markers at the current location within a D3D12 command list,
        /// use the <c>PIXEndEvent</c> function or <c>PIXScopedEvent</c> macro. 
        /// This is provided by the WinPixEventRuntime NuGet package.
        /// </para>
        /// </remarks>
        public void EndEvent()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[58])(thisPtr);
            }
        }

        /// <summary>
        /// Apps perform indirect draws/dispatches using the <see cref="ExecuteIndirect"/> method.
        /// </summary>
        /// <param name="pCommandSignature">
        /// Specifies a <see cref="ID3D12CommandSignature"/>.
        /// The data referenced by <paramref name="pArgumentBuffer"/> will be interpreted
        /// depending on the contents of the command signature.
        /// Refer to Indirect Drawing for the APIs that are used to create a command signature.
        /// </param>
        /// <param name="MaxCommandCount">
        /// <para>
        /// There are two ways that command counts can be specified:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <paramref name="pCountBuffer"/> is not <see cref="NULL"/>,
        /// then <paramref name="MaxCommandCount"/> specifies the maximum number of operations which will be performed.
        /// The actual number of operations to be performed are defined by the minimum of this value,
        /// and a 32-bit unsigned integer contained in <paramref name="pCountBuffer"/>
        /// (at the byte offset specified by <paramref name="CountBufferOffset"/>).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <paramref name="pCountBuffer"/> is <see cref="NULL"/>,
        /// the <paramref name="MaxCommandCount"/> specifies the exact number of operations which will be performed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pArgumentBuffer">
        /// Specifies one or more <see cref="ID3D12Resource"/> objects, containing the command arguments.
        /// </param>
        /// <param name="ArgumentBufferOffset">
        /// Specifies an offset into <paramref name="pArgumentBuffer"/> to identify the first command argument.
        /// </param>
        /// <param name="pCountBuffer">
        /// Specifies a pointer to a <see cref="ID3D12Resource"/>.
        /// </param>
        /// <param name="CountBufferOffset">
        /// Specifies a <see cref="UINT64"/> that is the offset into <paramref name="pCountBuffer"/>,
        /// identifying the argument count.
        /// </param>
        /// <remarks>
        /// <para>
        /// The semantics of this API are defined with the following pseudo-code:
        /// </para>
        /// <para>
        /// Non-<see cref="NULL"/> <paramref name="pCountBuffer"/>:
        /// </para>
        /// <code>
        /// // Read draw count out of count buffer
        /// UINT CommandCount = pCountBuffer-&gt;ReadUINT32(CountBufferOffset);
        /// 
        /// CommandCount = min(CommandCount, MaxCommandCount)
        /// 
        /// // Get pointer to first Commanding argument
        /// BYTE* Arguments = pArgumentBuffer-&gt;GetBase() + ArgumentBufferOffset;
        /// 
        /// for(UINT CommandIndex = 0; CommandIndex &lt; CommandCount; CommandIndex++)
        /// {
        ///   // Interpret the data contained in *Arguments
        ///   // according to the command signature
        ///   pCommandSignature-&gt;Interpret(Arguments);
        /// 
        ///   Arguments += pCommandSignature-&gt;GetByteStride();
        /// }
        /// </code>
        /// <para>
        /// <see cref="NULL"/> <paramref name="pCountBuffer"/>:
        /// </para>
        /// <code>
        /// // Get pointer to first Commanding argument
        /// BYTE* Arguments = pArgumentBuffer-&gt;GetBase() + ArgumentBufferOffset;
        /// 
        /// for(UINT CommandIndex = 0; CommandIndex &lt; MaxCommandCount; CommandIndex++)
        /// {
        ///   // Interpret the data contained in *Arguments
        ///   // according to the command signature
        ///   pCommandSignature-&gt;Interpret(Arguments);
        /// 
        ///   Arguments += pCommandSignature-&gt;GetByteStride();
        /// }
        /// </code>
        /// <para>
        /// The debug layer will issue an error if either the count buffer or the argument buffer
        /// are not in the <see cref="D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT"/> state.
        /// The core runtime will validate:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <paramref name="CountBufferOffset"/> and <paramref name="ArgumentBufferOffset"/> are 4-byte aligned
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="pCountBuffer"/> and <paramref name="pArgumentBuffer"/> are buffer resources (any heap type)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The offset implied by <paramref name="MaxCommandCount"/>, <paramref name="ArgumentBufferOffset"/>,
        /// and the drawing program stride do not exceed the bounds of <paramref name="pArgumentBuffer"/> (similarly for count buffer)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The command list is a direct command list or a compute command list (not a copy or JPEG decode command list)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The root signature of the command list matches the root signature of the command signature
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The functionality of two APIs from earlier versions of Direct3D,
        /// <c>DrawInstancedIndirect</c> and <c>DrawIndexedInstancedIndirect</c>, are encompassed by <see cref="ExecuteIndirect"/>.
        /// </para>
        /// <para>
        /// Bundles
        /// </para>
        /// <para>
        /// <see cref="ExecuteIndirect"/> is allowed inside of bundle command lists only if all of the following are true:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <paramref name="pCountBuffer"/> is <see cref="NULL"/> (CPU-specified count only).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The command signature contains exactly one operation.
        /// This implies that the command signature does not contain root arguments changes, nor contain VB/IB binding changes.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Obtaining buffer virtual addresses
        /// </para>
        /// <para>
        /// The <see cref="ID3D12Resource.GetGPUVirtualAddress"/> method enables an app to retrieve the GPU virtual address of a buffer.
        /// </para>
        /// <para>
        /// Apps are free to apply byte offsets to virtual addresses before placing them in an indirect argument buffer.
        /// Note that all of the D3D12 alignment requirements for VB/IB/CB still apply to the resulting GPU virtual address.
        /// </para>
        /// </remarks>
        public void ExecuteIndirect([In] P<ID3D12CommandSignature> pCommandSignature, [In] UINT MaxCommandCount,
            [In] P<ID3D12Resource> pArgumentBuffer, [In] UINT64 ArgumentBufferOffset,
            [In] P<ID3D12Resource> pCountBuffer, [In] UINT64 CountBufferOffset)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12CommandSignature>, UINT, P<ID3D12Resource>,
                    UINT64, P<ID3D12Resource>, UINT64, void>)_vTable[59])
                    (thisPtr, pCommandSignature, MaxCommandCount, pArgumentBuffer, ArgumentBufferOffset, pCountBuffer, CountBufferOffset);
            }
        }
    }
}
