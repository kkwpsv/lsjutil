using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.BaseTypes.UINT64;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.D3D12;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_RESOURCE_MISC_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_BUFFER_UAV_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_CPU_PAGE_PROPERTY;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_HEAP_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_MEMORY_POOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_DIMENSION;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_STATES;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_TEXTURE_LAYOUT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a virtual adapter; it is used to create command allocators, command lists, command queues, fences,
    /// resources, pipeline state objects, heaps, root signatures, samplers, and many resource views.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This interface was introduced in Windows 10.
    /// Applications targetting Windows 10 should use this interface instead of later versions.
    /// Applications targetting a later version of Windows 10
    /// should use the appropriate version of the <see cref="ID3D12Device"/> interface.
    /// The latest version of this interface is <see cref="ID3D12Device3"/> introduced in Windows 10 Fall Creators Update.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12device"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use <see cref="D3D12CreateDevice"/> to create a device.
    /// </para>
    /// <para>
    /// For Windows 10 Anniversary some additional functionality is available through <see cref="ID3D12Device1"/>.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "189819f1-1db6-4b57-be54-1821339b85f7", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 43,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object)])]
    public unsafe struct ID3D12Device
    {
        IntPtr* _vTable;

        /// <summary>
        /// Reports the number of physical adapters (nodes) that are associated with this device.
        /// </summary>
        /// <returns>
        /// The number of physical adapters (nodes) that this device has.
        /// </returns>
        public UINT GetNodeCount()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT>)_vTable[7])(thisPtr);
            }
        }

        /// <summary>
        /// <para>
        /// Creates a command queue.
        /// </para>
        /// <para>
        /// Also see <see cref="ID3D12Device9.CreateCommandQueue1"/>.
        /// </para>
        /// </summary>
        /// <param name="pDesc">
        /// Specifies a <see cref="D3D12_COMMAND_QUEUE_DESC"/> that describes the command queue.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (GUID) for the command queue interface.
        /// See Remarks. An input parameter.
        /// </param>
        /// <param name="ppCommandQueue">
        /// A pointer to a memory block that receives a pointer to the <see cref="ID3D12CommandQueue"/> interface for the command queue.
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the command queue.
        /// See Direct3D 12 return codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface to the command queue
        /// can be obtained by using the <c>__uuidof()</c> macro.
        /// For example,<c> __uuidof(ID3D12CommandQueue)</c> will get the <see cref="GUID"/> of the interface to a command queue.
        /// </remarks>
        public HRESULT CreateCommandQueue([In] in D3D12_COMMAND_QUEUE_DESC pDesc, [In] in IID riid, [Out] out IntPtr ppCommandQueue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D12_COMMAND_QUEUE_DESC, in IID, out IntPtr, HRESULT>)_vTable[8])
                    (thisPtr, pDesc, riid, out ppCommandQueue);
            }
        }

        /// <summary>
        /// Creates a command allocator object.
        /// </summary>
        /// <param name="type">
        /// A <see cref="D3D12_COMMAND_LIST_TYPE"/>-typed value that specifies the type of command allocator to create.
        /// The type of command allocator can be the type that records either direct command lists or bundles.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (<see cref="GUID"/>) for the command allocator interface (<see cref="ID3D12CommandAllocator"/>).
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface to the command allocator
        /// can be obtained by using the <c>__uuidof()</c> macro.
        /// For example, __uuidof(ID3D12CommandAllocator) will get the <see cref="GUID"/> of the interface to a command allocator.
        /// </param>
        /// <param name="ppCommandAllocator">
        /// A pointer to a memory block that receives a pointer to the <see cref="ID3D12CommandAllocator"/> interface for the command allocator.
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the command allocator.
        /// See Direct3D 12 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// The device creates command lists from the command allocator.
        /// </remarks>
        public HRESULT CreateCommandAllocator([In] D3D12_COMMAND_LIST_TYPE type, [In] in IID riid, [Out] out IntPtr ppCommandAllocator)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_COMMAND_LIST_TYPE, in IID, out IntPtr, HRESULT>)_vTable[9])
                    (thisPtr, type, riid, out ppCommandAllocator);
            }
        }

        /// <summary>
        /// Creates a graphics pipeline state object.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> structure that describes graphics pipeline state.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (<see cref="GUID"/>) for the pipeline state interface (<see cref="ID3D12PipelineState"/>).
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface to the pipeline state
        /// can be obtained by using the <c>__uuidof()</c> macro.
        /// For example, <c>__uuidof(ID3D12PipelineState)</c> will get the <see cref="GUID"/> of the interface to a pipeline state.
        /// </param>
        /// <param name="ppPipelineState">
        /// A pointer to a memory block that receives a pointer
        /// to the <see cref="ID3D12PipelineState"/> interface for the pipeline state object.
        /// The pipeline state object is an immutable state object. It contains no methods.
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the pipeline state object.
        /// See Direct3D 12 Return Codes for other possible return values.
        /// </returns>
        public HRESULT CreateGraphicsPipelineState([In] in D3D12_GRAPHICS_PIPELINE_STATE_DESC pDesc, [In] in IID riid, [Out] out IntPtr ppPipelineState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D12_GRAPHICS_PIPELINE_STATE_DESC, in IID, out IntPtr, HRESULT>)_vTable[10])
                    (thisPtr, pDesc, riid, out ppPipelineState);
            }
        }

        /// <summary>
        /// Creates a compute pipeline state object.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D12_COMPUTE_PIPELINE_STATE_DESC"/> structure that describes compute pipeline state.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (<see cref="GUID"/>) for the pipeline state interface (<see cref="ID3D12PipelineState"/>).
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface to the pipeline state
        /// can be obtained by using the <c>__uuidof()</c> macro.
        /// For example, <c>__uuidof(ID3D12PipelineState)</c> will get the <see cref="GUID"/> of the interface to a pipeline state.
        /// </param>
        /// <param name="ppPipelineState">
        /// A pointer to a memory block that receives a pointer
        /// to the <see cref="ID3D12PipelineState"/> interface for the pipeline state object.
        /// The pipeline state object is an immutable state object.
        /// It contains no methods.
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the pipeline state object.
        /// See Direct3D 12 Return Codes for other possible return values.
        /// </returns>
        public HRESULT CreateComputePipelineState([In] in D3D12_COMPUTE_PIPELINE_STATE_DESC pDesc, [In] in IID riid, [Out] out IntPtr ppPipelineState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D12_COMPUTE_PIPELINE_STATE_DESC, in IID, out IntPtr, HRESULT>)_vTable[11])
                    (thisPtr, pDesc, riid, out ppPipelineState);
            }
        }

        /// <summary>
        /// Creates a command list.
        /// </summary>
        /// <param name="nodeMask">
        /// For single-GPU operation, set this to zero.
        /// If there are multiple GPU nodes, then set a bit to identify the node (the device's physical adapter)
        /// for which to create the command list.
        /// Each bit in the mask corresponds to a single node.
        /// Only one bit must be set.
        /// Also see Multi-adapter systems.
        /// </param>
        /// <param name="type">
        /// Specifies the type of command list to create.
        /// </param>
        /// <param name="pCommandAllocator">
        /// A pointer to the command allocator object from which the device creates command lists.
        /// </param>
        /// <param name="pInitialState">
        /// <para>
        /// An optional pointer to the pipeline state object that contains the initial pipeline state for the command list.
        /// If it is <see cref="NULL"/>, then the runtime sets a dummy initial pipeline state,
        /// so that drivers don't have to deal with undefined state.
        /// The overhead for this is low, particularly for a command list,
        /// for which the overall cost of recording the command list likely dwarfs the cost of a single initial state setting.
        /// So there's little cost in not setting the initial pipeline state parameter, if doing so is inconvenient.
        /// </para>
        /// <para>
        /// For bundles, on the other hand, it might make more sense to try to set the initial state parameter
        /// (since bundles are likely smaller overall, and can be reused frequently).
        /// </para>
        /// </param>
        /// <param name="riid">
        /// A reference to the globally unique identifier (<see cref="GUID"/>) of the command list interface
        /// to return in <paramref name="ppCommandList"/>.
        /// </param>
        /// <param name="ppCommandList">
        /// A pointer to a memory block that receives a pointer to the <see cref="ID3D12CommandList"/> 
        /// or <see cref="ID3D12GraphicsCommandList"/> interface for the command list.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// There is insufficient memory to create the command list.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// See Direct3D 12 return codes for other possible return values.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The device creates command lists from the command allocator.
        /// </remarks>
        public HRESULT CreateCommandList([In] UINT nodeMask, [In] D3D12_COMMAND_LIST_TYPE type, [In] P<ID3D12CommandAllocator> pCommandAllocator,
            [In] P<ID3D12PipelineState> pInitialState, [In] in IID riid, [Out] out IntPtr ppCommandList)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_COMMAND_LIST_TYPE, P<ID3D12CommandAllocator>,
                    P<ID3D12PipelineState>, in IID, out IntPtr, HRESULT>)_vTable[12])
                    (thisPtr, nodeMask, type, pCommandAllocator, pInitialState, riid, out ppCommandList);
            }
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <param name="Feature">
        /// A constant from the <see cref="D3D12_FEATURE"/> enumeration describing the feature(s) that you want to query for support.
        /// </param>
        /// <param name="pFeatureSupportData">
        /// A pointer to a data structure that corresponds to the value of the <paramref name="Feature"/> parameter.
        /// To determine the corresponding data structure for each constant, see <see cref="D3D12_FEATURE"/>.
        /// </param>
        /// <param name="FeatureSupportDataSize">
        /// The size of the structure pointed to by the <paramref name="pFeatureSupportData"/> parameter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful.
        /// Returns <see cref="E_INVALIDARG"/> if an unsupported data type is passed to the <paramref name="pFeatureSupportData"/> parameter
        /// or if a size mismatch is detected for the <paramref name="FeatureSupportDataSize"/> parameter.
        /// </returns>
        /// <remarks>
        /// <para>
        /// As a usage example, to check for ray tracing support, specify the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS5"/> structure
        /// in the <paramref name="pFeatureSupportData"/> parameter.
        /// When the function completes successfully, access the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS5.RaytracingTier"/> field
        /// (which specifies the supported ray tracing tier) of the now-populated <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS5"/> structure.
        /// </para>
        /// <para>
        /// For more info, see Capability Querying.
        /// </para>
        /// </remarks>
        public HRESULT CheckFeatureSupport([In] D3D12_FEATURE Feature, [In] IntPtr pFeatureSupportData, [In] UINT FeatureSupportDataSize)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_FEATURE, IntPtr, UINT, HRESULT>)_vTable[13])(thisPtr, Feature, pFeatureSupportData,
   FeatureSupportDataSize);
            }
        }

        /// <summary>
        /// Creates a descriptor heap object.
        /// </summary>
        /// <param name="pDescriptorHeapDesc">
        /// A pointer to a <see cref="D3D12_DESCRIPTOR_HEAP_DESC"/> structure that describes the heap.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (<see cref="GUID"/>) for the descriptor heap interface.
        /// See Remarks. An input parameter.
        /// </param>
        /// <param name="ppvHeap">
        /// A pointer to a memory block that receives a pointer to the descriptor heap.
        /// <paramref name="ppvHeap"/> can be <see cref="NullRef{IntPtr}"/>, to enable capability testing.
        /// When <paramref name="ppvHeap"/> is <see cref="NullRef{IntPtr}"/>,
        /// no object will be created and <see cref="S_FALSE"/> will be returned when <paramref name="pDescriptorHeapDesc"/> is valid.
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the descriptor heap object.
        /// See Direct3D 12 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface to the descriptor heap
        /// can be obtained by using the <c>__uuidof()</c> macro.
        /// For example, <c>__uuidof(ID3D12DescriptorHeap)</c> will get the <see cref="GUID"/> of the interface to a descriptor heap.
        /// </remarks>
        public HRESULT CreateDescriptorHeap([In] in D3D12_DESCRIPTOR_HEAP_DESC pDescriptorHeapDesc, [In] in IID riid, [Out] out IntPtr ppvHeap)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D12_DESCRIPTOR_HEAP_DESC, in IID, out IntPtr, HRESULT>)_vTable[14])
                    (thisPtr, pDescriptorHeapDesc, riid, out ppvHeap);
            }
        }

        /// <summary>
        /// Gets the size of the handle increment for the given type of descriptor heap.
        /// This value is typically used to increment a handle into a descriptor array by the correct amount.
        /// </summary>
        /// <param name="DescriptorHeapType">
        /// The <see cref="D3D12_DESCRIPTOR_HEAP_TYPE"/>-typed value
        /// that specifies the type of descriptor heap to get the size of the handle increment for.
        /// </param>
        /// <returns>
        /// Returns the size of the handle increment for the given type of descriptor heap, including any necessary padding.
        /// </returns>
        /// <remarks>
        /// The descriptor size returned by this method is used as one input to the helper structures
        /// <c>CD3DX12_CPU_DESCRIPTOR_HANDLE</c> and <c>CD3DX12_GPU_DESCRIPTOR_HANDLE</c>.
        /// </remarks>
        public UINT GetDescriptorHandleIncrementSize([In] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_DESCRIPTOR_HEAP_TYPE, UINT>)_vTable[15])(thisPtr, DescriptorHeapType);
            }
        }

        /// <summary>
        /// Creates a root signature layout.
        /// </summary>
        /// <param name="nodeMask">
        /// For single GPU operation, set this to zero.
        /// If there are multiple GPU nodes, set bits to identify the nodes
        /// (the device's physical adapters) to which the root signature is to apply.
        /// Each bit in the mask corresponds to a single node.
        /// Refer to Multi-adapter systems.
        /// </param>
        /// <param name="pBlobWithRootSignature">
        /// A pointer to the source data for the serialized signature.
        /// </param>
        /// <param name="blobLengthInBytes">
        /// The size, in bytes, of the block of memory that <paramref name="pBlobWithRootSignature"/> points to.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (<see cref="GUID"/>) for the root signature interface.
        /// See Remarks. An input parameter.
        /// </param>
        /// <param name="ppvRootSignature">
        /// A pointer to a memory block that receives a pointer to the root signature.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the Direct3D 12 Return Codes.
        /// </para>
        /// <para>
        /// This method returns <see cref="E_INVALIDARG"/> if the blob that <paramref name="pBlobWithRootSignature"/> points to is invalid.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If an application procedurally generates a <see cref="D3D12_ROOT_SIGNATURE_DESC"/> data structure,
        /// it must pass a pointer to this <see cref="D3D12_ROOT_SIGNATURE_DESC"/>
        /// in a call to <see cref="D3D12SerializeRootSignature"/> to make the serialized form.
        /// The application then passes the serialized form to <paramref name="pBlobWithRootSignature"/>
        /// in a call to <see cref="CreateRootSignature"/>.
        /// </para>
        /// <para>
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface to the root signature layout
        /// can be obtained by using the <c>__uuidof()</c> macro.
        /// For example, <c>__uuidof(ID3D12RootSignature)</c> will get the <see cref="GUID"/> of the interface to a root signature.
        /// </para>
        /// </remarks>
        public HRESULT CreateRootSignature([In] UINT nodeMask, [In] byte[] pBlobWithRootSignature,
            [In] SIZE_T blobLengthInBytes, [In] in IID riid, [Out] out IntPtr ppvRootSignature)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (byte* pBlobWithRootSignaturePtr = pBlobWithRootSignature)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, UINT, byte*, SIZE_T, in IID, out IntPtr, HRESULT>)_vTable[16])
                        (thisPtr, nodeMask, pBlobWithRootSignaturePtr, blobLengthInBytes, riid, out ppvRootSignature);
                }
            }
        }

        /// <summary>
        /// Creates a constant-buffer view for accessing resource data.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D12_CONSTANT_BUFFER_VIEW_DESC"/> structure that describes the constant-buffer view.
        /// </param>
        /// <param name="DestDescriptor">
        /// Describes the CPU descriptor handle that represents the start of the heap that holds the constant-buffer view.
        /// </param>
        public void CreateConstantBufferView([In] in D3D12_CONSTANT_BUFFER_VIEW_DESC pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D3D12_CONSTANT_BUFFER_VIEW_DESC, D3D12_CPU_DESCRIPTOR_HANDLE, void>)_vTable[17])
                    (thisPtr, pDesc, DestDescriptor);
            }
        }

        /// <summary>
        /// Creates a shader-resource view for accessing data in a resource.
        /// </summary>
        /// <param name="pResource">
        /// <para>
        /// A pointer to the <see cref="ID3D12Resource"/> object that represents the shader resource.
        /// </para>
        /// <para>
        /// At least one of <paramref name="pResource"/> or <paramref name="pDesc"/> must be provided.
        /// A null <paramref name="pResource"/> is used to initialize a null descriptor,
        /// which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded),
        /// but must have a valid <paramref name="pDesc"/> in order to determine the descriptor type.
        /// </para>
        /// </param>
        /// <param name="pDesc">
        /// <para>
        /// A pointer to a <see cref="D3D12_SHADER_RESOURCE_VIEW_DESC"/> structure that describes the shader-resource view.
        /// </para>
        /// <para>
        /// A null <paramref name="pDesc"/> is used to initialize a default descriptor, if possible.
        /// This behavior is identical to the D3D11 null descriptor behavior, where defaults are filled in.
        /// This behavior inherits the resource format and dimension (if not typeless)
        /// and for buffers SRVs target a full buffer and are typed (not raw or structured),
        /// and for textures SRVs target a full texture, all mips and all array slices.
        /// Not all resources support null descriptor initialization.
        /// </para>
        /// </param>
        /// <param name="DestDescriptor">
        /// Describes the CPU descriptor handle that represents the shader-resource view.
        /// This handle can be created in a shader-visible or non-shader-visible descriptor heap.
        /// </param>
        /// <remarks>
        /// <para>
        /// Processing YUV 4:2:0 video formats
        /// </para>
        /// <para>
        /// An app must map the luma (Y) plane separately from the chroma (UV) planes.
        /// Developers do this by calling <see cref="CreateShaderResourceView"/> twice
        /// for the same texture and passing in 1-channel and 2-channel formats.
        /// Passing in a 1-channel format compatible with the Y plane maps only the Y plane.
        /// Passing in a 2-channel format compatible with the UV planes (together)
        /// maps only the U and V planes as a single resource view.
        /// </para>
        /// <para>
        /// YUV 4:2:0 formats are listed in <see cref="DXGI_FORMAT"/>.
        /// </para>
        /// </remarks>
        public void CreateShaderResourceView([In] P<ID3D12Resource> pResource, [In] in D3D12_SHADER_RESOURCE_VIEW_DESC pDesc,
            [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, in D3D12_SHADER_RESOURCE_VIEW_DESC,
                    D3D12_CPU_DESCRIPTOR_HANDLE, void>)_vTable[18])(thisPtr, pResource, pDesc, DestDescriptor);
            }
        }

        /// <summary>
        /// Creates a view for unordered accessing.
        /// </summary>
        /// <param name="pResource">
        /// <para>
        /// A pointer to the <see cref="ID3D12Resource"/> object that represents the unordered access.
        /// </para>
        /// <para>
        /// At least one of <paramref name="pResource"/> or <paramref name="pDesc"/> must be provided.
        /// </para>
        /// <para>
        /// A null <paramref name="pResource"/> is used to initialize a null descriptor,
        /// which guarantees Direct3D 11-like null binding behavior (reading 0s, writes are discarded),
        /// but must have a valid <paramref name="pDesc"/> in order to determine the descriptor type.
        /// </para>
        /// </param>
        /// <param name="pCounterResource">
        /// <para>
        /// The <see cref="ID3D12Resource"/> for the counter (if any) associated with the UAV.
        /// </para>
        /// <para>
        /// If <paramref name="pCounterResource"/> is not specified,
        /// then the <see cref="D3D12_BUFFER_UAV.CounterOffsetInBytes"/> member of the <see cref="D3D12_BUFFER_UAV"/> structure must be 0.
        /// </para>
        /// <para>
        /// If <paramref name="pCounterResource"/> is specified, then there is a counter associated with the UAV,
        /// and the runtime performs validation of the following requirements:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The <see cref="D3D12_BUFFER_UAV.StructureByteStride"/> member
        /// of the <see cref="D3D12_BUFFER_UAV"/> structure must be greater than 0.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The format must be <see cref="DXGI_FORMAT_UNKNOWN"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The <see cref="D3D12_BUFFER_UAV_FLAG_RAW"/> flag
        /// (a <see cref="D3D12_BUFFER_UAV_FLAGS"/> enumeration constant) must not be set.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Both of the resources (<paramref name="pResource"/> and <paramref name="pCounterResource"/>) must be buffers.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The <see cref="D3D12_BUFFER_UAV.CounterOffsetInBytes"/> member of the <see cref="D3D12_BUFFER_UAV"/> structure
        /// must be a multiple of <see cref="D3D12_UAV_COUNTER_PLACEMENT_ALIGNMENT"/> (4096),
        /// and must be within the range of the counter resource.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="pResource"/> cannot be <see cref="NULL"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="pDesc"/> cannot be see cref="NULL"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pDesc">
        /// <para>
        /// A pointer to a <see cref="D3D12_UNORDERED_ACCESS_VIEW_DESC"/> structure that describes the unordered-access view.
        /// </para>
        /// <para>
        /// A null <paramref name="pDesc"/> is used to initialize a default descriptor, if possible.
        /// This behavior is identical to the D3D11 null descriptor behavior, where defaults are filled in.
        /// This behavior inherits the resource format and dimension (if not typeless)
        /// and for buffers UAVs target a full buffer and are typed,
        /// and for textures UAVs target the first mip and all array slices.
        /// Not all resources support null descriptor initialization.
        /// </para>
        /// </param>
        /// <param name="DestDescriptor">
        /// Describes the CPU descriptor handle that represents the start of the heap that holds the unordered-access view.
        /// </param>
        public void CreateUnorderedAccessView([In] P<ID3D12Resource> pResource, [In] P<ID3D12Resource> pCounterResource,
            [In] in D3D12_UNORDERED_ACCESS_VIEW_DESC pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, P<ID3D12Resource>,
                    in D3D12_UNORDERED_ACCESS_VIEW_DESC, D3D12_CPU_DESCRIPTOR_HANDLE, void>)_vTable[19])
                    (thisPtr, pResource, pCounterResource, pDesc, DestDescriptor);
            }
        }

        /// <summary>
        /// Creates a render-target view for accessing resource data.
        /// </summary>
        /// <param name="pResource">
        /// <para>
        /// A pointer to the <see cref="ID3D12Resource"/> object that represents the render target.
        /// </para>
        /// <para>
        /// At least one of <paramref name="pResource"/> or <paramref name="pDesc"/> must be provided.
        /// A null <paramref name="pResource"/> is used to initialize a null descriptor,
        /// which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded),
        /// but must have a valid <paramref name="pDesc"/> in order to determine the descriptor type.
        /// </para>
        /// </param>
        /// <param name="pDesc">
        /// <para>
        /// A pointer to a <see cref="D3D12_RENDER_TARGET_VIEW_DESC"/> structure that describes the render-target view.
        /// </para>
        /// <para>
        /// A null <paramref name="pDesc"/> is used to initialize a default descriptor, if possible.
        /// This behavior is identical to the D3D11 null descriptor behavior, where defaults are filled in.
        /// This behavior inherits the resource format and dimension (if not typeless)
        /// and RTVs target the first mip and all array slices.
        /// Not all resources support null descriptor initialization.
        /// </para>
        /// </param>
        /// <param name="DestDescriptor">
        /// Describes the CPU descriptor handle that represents the destination where the newly-created render target view will reside.
        /// </param>
        public void CreateRenderTargetView([In] P<ID3D12Resource> pResource, [In] in D3D12_RENDER_TARGET_VIEW_DESC pDesc,
            [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, in D3D12_RENDER_TARGET_VIEW_DESC,
                    D3D12_CPU_DESCRIPTOR_HANDLE, void>)_vTable[20])(thisPtr, pResource, pDesc, DestDescriptor);
            }
        }

        /// <summary>
        /// Creates a depth-stencil view for accessing resource data.
        /// </summary>
        /// <param name="pResource">
        /// <para>
        /// A pointer to the <see cref="ID3D12Resource"/> object that represents the depth stencil.
        /// </para>
        /// <para>
        /// At least one of <paramref name="pResource"/> or <paramref name="pDesc"/> must be provided.
        /// A null <paramref name="pResource"/> is used to initialize a null descriptor,
        /// which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded),
        /// but must have a valid <paramref name="pDesc"/> in order to determine the descriptor type.
        /// </para>
        /// </param>
        /// <param name="pDesc">
        /// <para>
        /// A pointer to a <see cref="D3D12_DEPTH_STENCIL_VIEW_DESC"/> structure that describes the depth-stencil view.
        /// </para>
        /// <para>
        /// A null <paramref name="pDesc"/> is used to initialize a default descriptor, if possible.
        /// This behavior is identical to the D3D11 null descriptor behavior, where defaults are filled in.
        /// This behavior inherits the resource format and dimension (if not typeless)
        /// and DSVs target the first mip and all array slices.
        /// Not all resources support null descriptor initialization.
        /// </para>
        /// </param>
        /// <param name="DestDescriptor">
        /// Describes the CPU descriptor handle that represents the start of the heap that holds the depth-stencil view.
        /// </param>
        public void CreateDepthStencilView([In] P<ID3D12Resource> pResource, [In] in D3D12_DEPTH_STENCIL_VIEW_DESC pDesc,
            [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, in D3D12_DEPTH_STENCIL_VIEW_DESC,
                    D3D12_CPU_DESCRIPTOR_HANDLE, void>)_vTable[21])(thisPtr, pResource, pDesc, DestDescriptor);
            }
        }

        /// <summary>
        /// Create a sampler object that encapsulates sampling information for a texture.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D12_SAMPLER_DESC"/> structure that describes the sampler.
        /// </param>
        /// <param name="DestDescriptor">
        /// Describes the CPU descriptor handle that represents the start of the heap that holds the sampler.
        /// </param>
        public void CreateSampler([In] in D3D12_SAMPLER_DESC pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D3D12_SAMPLER_DESC, D3D12_CPU_DESCRIPTOR_HANDLE, void>)_vTable[22])(thisPtr, pDesc, DestDescriptor);
            }
        }

        /// <summary>
        /// Copies descriptors from a source to a destination.
        /// </summary>
        /// <param name="NumDestDescriptorRanges">
        /// The number of destination descriptor ranges to copy to.
        /// </param>
        /// <param name="pDestDescriptorRangeStarts">
        /// <para>
        /// An array of <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> objects to copy to.
        /// </para>
        /// <para>
        /// All the destination and source descriptors must be in heaps of the same <see cref="D3D12_DESCRIPTOR_HEAP_TYPE"/>.
        /// </para>
        /// </param>
        /// <param name="pDestDescriptorRangeSizes">
        /// An array of destination descriptor range sizes to copy to.
        /// </param>
        /// <param name="NumSrcDescriptorRanges">
        /// The number of source descriptor ranges to copy from.
        /// </param>
        /// <param name="pSrcDescriptorRangeStarts">
        /// <para>
        /// An array of <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> objects to copy from.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// All elements in the <paramref name="pSrcDescriptorRangeStarts"/> parameter must be in a non shader-visible descriptor heap.
        /// This is because shader-visible descriptor heaps may be created in WRITE_COMBINE memory or GPU local memory,
        /// which is prohibitively slow to read from.
        /// If your application manages descriptor heaps via copying the descriptors required
        /// for a given pass or frame from local "storage" descriptor heaps to the GPU-bound descriptor heap,
        /// use shader-opaque heaps for the storage heaps and copy into the GPU-visible heap as required.
        /// </para>
        /// </param>
        /// <param name="pSrcDescriptorRangeSizes">
        /// An array of source descriptor range sizes to copy from.
        /// </param>
        /// <param name="DescriptorHeapsType">
        /// <para>
        /// The <see cref="D3D12_DESCRIPTOR_HEAP_TYPE"/>-typed value that specifies the type of descriptor heap to copy with.
        /// This is required as different descriptor types may have different sizes.
        /// </para>
        /// <para>
        /// Both the source and destination descriptor heaps must have the same type, else the debug layer will emit an error.
        /// </para>
        /// </param>
        /// <remarks>
        /// Where applicable, prefer <see cref="CopyDescriptorsSimple"/> to this method.
        /// It can have a better CPU cache miss rate due to the linear nature of the copy.
        /// </remarks>
        public void CopyDescriptors([In] UINT NumDestDescriptorRanges, [In] D3D12_CPU_DESCRIPTOR_HANDLE[] pDestDescriptorRangeStarts,
            [In] UINT[] pDestDescriptorRangeSizes, [In] UINT NumSrcDescriptorRanges, [In] D3D12_CPU_DESCRIPTOR_HANDLE[] pSrcDescriptorRangeStarts,
            [In] UINT[] pSrcDescriptorRangeSizes, [In] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_CPU_DESCRIPTOR_HANDLE* pDestDescriptorRangeStartsPtr = pDestDescriptorRangeStarts)
                {
                    fixed (UINT* pDestDescriptorRangeSizesPtr = pDestDescriptorRangeSizes)
                    {
                        fixed (D3D12_CPU_DESCRIPTOR_HANDLE* pSrcDescriptorRangeStartsPtr = pSrcDescriptorRangeStarts)
                        {
                            fixed (UINT* pSrcDescriptorRangeSizesPtr = pSrcDescriptorRangeSizes)
                            {
                                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_CPU_DESCRIPTOR_HANDLE*, UINT*,
                                    UINT, D3D12_CPU_DESCRIPTOR_HANDLE*, UINT*, D3D12_DESCRIPTOR_HEAP_TYPE, void>)_vTable[23])
                                    (thisPtr, NumDestDescriptorRanges, pDestDescriptorRangeStartsPtr, pDestDescriptorRangeSizesPtr,
                                    NumSrcDescriptorRanges, pSrcDescriptorRangeStartsPtr, pSrcDescriptorRangeSizesPtr, DescriptorHeapsType);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Copies descriptors from a source to a destination.
        /// </summary>
        /// <param name="NumDescriptors">
        /// The number of descriptors to copy.
        /// </param>
        /// <param name="DestDescriptorRangeStart">
        /// <para>
        /// A <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> that describes the destination descriptors to start to copy to.
        /// </para>
        /// <para>
        /// The destination and source descriptors must be in heaps of the same <see cref="D3D12_DESCRIPTOR_HEAP_TYPE"/>.
        /// </para>
        /// </param>
        /// <param name="SrcDescriptorRangeStart">
        /// <para>
        /// A <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> that describes the source descriptors to start to copy from.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// The <paramref name="SrcDescriptorRangeStart"/> parameter must be in a non shader-visible descriptor heap.
        /// This is because shader-visible descriptor heaps may be created in WRITE_COMBINE memory or GPU local memory,
        /// which is prohibitively slow to read from.
        /// If your application manages descriptor heaps via copying the descriptors required
        /// for a given pass or frame from local "storage" descriptor heaps to the GPU-bound descriptor heap,
        /// then use shader-opaque heaps for the storage heaps and copy into the GPU-visible heap as required.
        /// </para>
        /// </param>
        /// <param name="DescriptorHeapsType">
        /// <para>
        /// The <see cref="D3D12_DESCRIPTOR_HEAP_TYPE"/>-typed value that specifies the type of descriptor heap to copy with.
        /// This is required as different descriptor types may have different sizes.
        /// </para>
        /// <para>
        /// Both the source and destination descriptor heaps must have the same type, else the debug layer will emit an error.
        /// </para>
        /// </param>
        /// <remarks>
        /// Where applicable, prefer this method to <see cref="CopyDescriptors"/>.
        /// It can have a better CPU cache miss rate due to the linear nature of the copy.
        /// </remarks>
        public void CopyDescriptorsSimple([In] UINT NumDescriptors, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptorRangeStart,
            [In] D3D12_CPU_DESCRIPTOR_HANDLE SrcDescriptorRangeStart, [In] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_CPU_DESCRIPTOR_HANDLE,
                    D3D12_CPU_DESCRIPTOR_HANDLE, D3D12_DESCRIPTOR_HEAP_TYPE, void>)_vTable[24])
                    (thisPtr, NumDescriptors, DestDescriptorRangeStart, SrcDescriptorRangeStart, DescriptorHeapsType);
            }
        }

        /// <summary>
        /// Gets the size and alignment of memory required for a collection of resources on this adapter.
        /// </summary>
        /// <param name="visibleMask">
        /// For single-GPU operation, set this to zero.
        /// If there are multiple GPU nodes, then set bits to identify the nodes (the device's physical adapters).
        /// Each bit in the mask corresponds to a single node. Also see Multi-adapter systems.
        /// </param>
        /// <param name="numResourceDescs">
        /// The number of resource descriptors in the pResourceDescs array.
        /// </param>
        /// <param name="pResourceDescs">
        /// An array of <see cref="D3D12_RESOURCE_DESC"/> structures that described the resources to get info about.
        /// </param>
        /// <returns>
        /// <para>
        /// A <see cref="D3D12_RESOURCE_ALLOCATION_INFO"/> structure
        /// that provides info about video memory allocated for the specified array of resources.
        /// </para>
        /// <para>
        /// If an error occurs, then <see cref="D3D12_RESOURCE_ALLOCATION_INFO.SizeInBytes"/> equals <see cref="UINT64_MAX"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you're using <see cref="CreatePlacedResource"/>, your application must use <see cref="GetResourceAllocationInfo"/>
        /// in order to understand the size and alignment characteristics of texture resources.
        /// The results of this method vary depending on the particular adapter,
        /// and must be treated as unique to this adapter and driver version.
        /// </para>
        /// <para>
        /// Your application can't use the output of <see cref="GetResourceAllocationInfo"/> to understand packed mip properties of textures.
        /// To understand packed mip properties of textures, your application must use <see cref="GetResourceTiling"/>.
        /// </para>
        /// <para>
        /// Texture resource sizes significantly differ from the information returned by <see cref="GetResourceTiling"/>,
        /// because some adapter architectures allocate extra memory for textures
        /// to reduce the effective bandwidth during common rendering scenarios.
        /// This even includes textures that have constraints on their texture layouts, or have standardized texture layouts.
        /// That extra memory can't be sparsely mapped nor remapped by an application
        /// using <see cref="CreateReservedResource"/> and <see cref="ID3D12CommandQueue.UpdateTileMappings"/>,
        /// so it isn't reported by <see cref="GetResourceTiling"/>.
        /// </para>
        /// <para>
        /// Your application can forgo using <see cref="GetResourceAllocationInfo"/> for buffer resources
        /// (<see cref="D3D12_RESOURCE_DIMENSION_BUFFER"/>) when not using Tight Alignment.
        /// Buffers that are not tightly aligned have the same size on all adapters,
        /// which is merely the smallest multiple of 64KB that's greater or equal to <see cref="D3D12_RESOURCE_DESC.Width"/>.
        /// </para>
        /// <para>
        /// When multiple resource descriptions are passed in,
        /// the C++ algorithm for calculating a structure size and alignment are used.
        /// For example, a three-element array with two tiny 64KB-aligned resources and a tiny 4MB-aligned resource,
        /// reports differing sizes based on the order of the array. If the 4MB aligned resource is in the middle,
        /// then the resulting Size is 12MB. Otherwise, the resulting Size is 8MB.
        /// The Alignment returned would always be 4MB, because it's the superset of all alignments in the resource array.
        /// </para>
        /// </remarks>
        public D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo([In] UINT visibleMask, [In] UINT numResourceDescs,
            [In] D3D12_RESOURCE_DESC[] pResourceDescs)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_RESOURCE_DESC* pResourceDescsPtr = pResourceDescs)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3D12_RESOURCE_DESC*, D3D12_RESOURCE_ALLOCATION_INFO>)_vTable[25])
                        (thisPtr, visibleMask, numResourceDescs, pResourceDescsPtr);
                }
            }
        }

        /// <summary>
        /// Divulges the equivalent custom heap properties that are used for non-custom heap types,
        /// based on the adapter's architectural properties.
        /// </summary>
        /// <param name="nodeMask">
        /// For single-GPU operation, set this to zero.
        /// If there are multiple GPU nodes, set a bit to identify the node (the device's physical adapter).
        /// Each bit in the mask corresponds to a single node.
        /// Only 1 bit must be set.
        /// See Multi-adapter systems.
        /// </param>
        /// <param name="heapType">
        /// A <see cref="D3D12_HEAP_TYPE"/>-typed value that specifies the heap to get properties for.
        /// <see cref="D3D12_HEAP_TYPE_CUSTOM"/> is not supported as a parameter value.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns a <see cref="D3D12_HEAP_PROPERTIES"/> structure that provides properties for the specified heap.
        /// The <see cref="D3D12_HEAP_PROPERTIES.Type"/> member of the returned <see cref="D3D12_HEAP_PROPERTIES"/>
        /// is always <see cref="D3D12_HEAP_TYPE_CUSTOM"/>.
        /// </para>
        /// <para>
        /// When <see cref="D3D12_FEATURE_DATA_ARCHITECTURE.UMA"/> is <see cref="FALSE"/>,
        /// the returned <see cref="D3D12_HEAP_PROPERTIES"/> members convert as follows:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Heap Type
        /// </term>
        /// <term>
        /// How the returned <see cref="D3D12_HEAP_PROPERTIES"/> members convert
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3D12_HEAP_TYPE_UPLOAD"/>
        /// </term>
        /// <term>
        /// <see cref="D3D12_HEAP_PROPERTIES.CPUPageProperty"/> = <see cref="D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE"/>,
        /// <see cref="D3D12_HEAP_PROPERTIES.MemoryPoolPreference"/> = <see cref="D3D12_MEMORY_POOL_L0"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3D12_HEAP_TYPE_DEFAULT"/>
        /// </term>
        /// <term>
        /// <see cref="D3D12_HEAP_PROPERTIES.CPUPageProperty"/> = <see cref="D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE"/>,
        /// <see cref="D3D12_HEAP_PROPERTIES.MemoryPoolPreference"/> = <see cref="D3D12_MEMORY_POOL_L1"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3D12_HEAP_TYPE_READBACK"/>
        /// </term>
        /// <term>
        /// <see cref="D3D12_HEAP_PROPERTIES.CPUPageProperty"/> = <see cref="D3D12_CPU_PAGE_PROPERTY_WRITE_BACK"/>,
        /// <see cref="D3D12_HEAP_PROPERTIES.MemoryPoolPreference"/> = <see cref="D3D12_MEMORY_POOL_L0"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When <see cref="D3D12_FEATURE_DATA_ARCHITECTURE.UMA"/> is <see cref="TRUE"/>
        /// and <see cref="D3D12_FEATURE_DATA_ARCHITECTURE.CacheCoherentUMA"/> is <see cref="FALSE"/>,
        /// the returned <see cref="D3D12_HEAP_PROPERTIES"/> members convert as follows:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Heap Type
        /// </term>
        /// <term>
        /// How the returned <see cref="D3D12_HEAP_PROPERTIES"/> members convert
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3D12_HEAP_TYPE_UPLOAD"/>
        /// </term>
        /// <term>
        /// <see cref="D3D12_HEAP_PROPERTIES.CPUPageProperty"/> = <see cref="D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE"/>,
        /// <see cref="D3D12_HEAP_PROPERTIES.MemoryPoolPreference"/> = <see cref="D3D12_MEMORY_POOL_L0"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3D12_HEAP_TYPE_DEFAULT"/>
        /// </term>
        /// <term>
        /// <see cref="D3D12_HEAP_PROPERTIES.CPUPageProperty"/> = <see cref="D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE"/>,
        /// <see cref="D3D12_HEAP_PROPERTIES.MemoryPoolPreference"/> = <see cref="D3D12_MEMORY_POOL_L0"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3D12_HEAP_TYPE_READBACK"/>
        /// </term>
        /// <term>
        /// <see cref="D3D12_HEAP_PROPERTIES.CPUPageProperty"/> = <see cref="D3D12_CPU_PAGE_PROPERTY_WRITE_BACK"/>,
        /// <see cref="D3D12_HEAP_PROPERTIES.MemoryPoolPreference"/> = <see cref="D3D12_MEMORY_POOL_L0"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When <see cref="D3D12_FEATURE_DATA_ARCHITECTURE.UMA"/> is <see cref="TRUE"/>
        /// and <see cref="D3D12_FEATURE_DATA_ARCHITECTURE.CacheCoherentUMA"/> is <see cref="TRUE"/>,
        /// the returned <see cref="D3D12_HEAP_PROPERTIES"/> members convert as follows:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Heap Type
        /// </term>
        /// <term>
        /// How the returned <see cref="D3D12_HEAP_PROPERTIES"/> members convert
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3D12_HEAP_TYPE_UPLOAD"/>
        /// </term>
        /// <term>
        /// <see cref="D3D12_HEAP_PROPERTIES.CPUPageProperty"/> = <see cref="D3D12_CPU_PAGE_PROPERTY_WRITE_BACK"/>,
        /// <see cref="D3D12_HEAP_PROPERTIES.MemoryPoolPreference"/> = <see cref="D3D12_MEMORY_POOL_L0"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3D12_HEAP_TYPE_DEFAULT"/>
        /// </term>
        /// <term>
        /// <see cref="D3D12_HEAP_PROPERTIES.CPUPageProperty"/> = <see cref="D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE"/>,
        /// <see cref="D3D12_HEAP_PROPERTIES.MemoryPoolPreference"/> = <see cref="D3D12_MEMORY_POOL_L0"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3D12_HEAP_TYPE_READBACK"/>
        /// </term>
        /// <term>
        /// <see cref="D3D12_HEAP_PROPERTIES.CPUPageProperty"/> = <see cref="D3D12_CPU_PAGE_PROPERTY_WRITE_BACK"/>,
        /// <see cref="D3D12_HEAP_PROPERTIES.MemoryPoolPreference"/> = <see cref="D3D12_MEMORY_POOL_L0"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public D3D12_HEAP_PROPERTIES GetCustomHeapProperties([In] UINT nodeMask, [In] D3D12_HEAP_TYPE heapType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3D12_HEAP_TYPE, D3D12_HEAP_PROPERTIES>)_vTable[26])(thisPtr, nodeMask, heapType);
            }
        }

        /// <summary>
        /// Creates both a resource and an implicit heap,
        /// such that the heap is big enough to contain the entire resource, and the resource is mapped to the heap.
        /// </summary>
        /// <param name="pHeapProperties">
        /// A pointer to a <see cref="D3D12_HEAP_PROPERTIES"/> structure that provides properties for the resource's heap.
        /// </param>
        /// <param name="HeapFlags">
        /// Heap options, as a bitwise-OR'd combination of <see cref="D3D12_HEAP_FLAGS"/> enumeration constants.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D12_RESOURCE_DESC"/> structure that describes the resource.
        /// </param>
        /// <param name="InitialResourceState">
        /// <para>
        /// The initial state of the resource, as a bitwise-OR'd combination of <see cref="D3D12_RESOURCE_STATES"/> enumeration constants.
        /// </para>
        /// <para>
        /// When you create a resource together with a <see cref="D3D12_HEAP_TYPE_UPLOAD"/> heap,
        /// you must set <paramref name="InitialResourceState"/> to <see cref="D3D12_RESOURCE_STATE_GENERIC_READ"/>.
        /// </para>
        /// <para>
        /// When you create a resource together with a <see cref="D3D12_HEAP_TYPE_READBACK"/> heap,
        /// you must set <paramref name="InitialResourceState"/> to <see cref="D3D12_RESOURCE_STATE_COPY_DEST"/>.
        /// </para>
        /// </param>
        /// <param name="pOptimizedClearValue">
        /// <para>
        /// Specifies a <see cref="D3D12_CLEAR_VALUE"/> structure that describes the default value for a clear color.
        /// </para>
        /// <para>
        /// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal.
        /// When the created resource is a texture with either the <see cref="D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET"/>
        /// or <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/> flags,
        /// you should choose the value with which the clear operation will most commonly be called.
        /// You can call the clear operation with other values,
        /// but those operations won't be as efficient as when the value matches the one passed in to resource creation.
        /// </para>
        /// <para>
        /// When you use <see cref="D3D12_RESOURCE_DIMENSION_BUFFER"/>,
        /// you must set <paramref name="pOptimizedClearValue"/> to <see cref="NullRef{D3D12_CLEAR_VALUE}"/>.
        /// </para>
        /// </param>
        /// <param name="riidResource">
        /// <para>
        /// A reference to the globally unique identifier (<see cref="GUID"/>) of the resource interface
        /// to return in <paramref name="ppvResource"/>.
        /// </para>
        /// <para>
        /// While <paramref name="riidResource"/> is most commonly the <see cref="GUID"/> of <see cref="ID3D12Resource"/>,
        /// it may be the <see cref="GUID"/> of any interface.
        /// If the resource object doesn't support the interface for this <see cref="GUID"/>,
        /// then creation fails with <see cref="E_NOINTERFACE"/>.
        /// </para>
        /// </param>
        /// <param name="ppvResource">
        /// <para>
        /// An optional pointer to a memory block that receives the requested interface pointer to the created resource object.
        /// </para>
        /// <para>
        /// <paramref name="ppvResource"/> can be <see cref="NullRef{IntPtr}"/>, to enable capability testing.
        /// When <paramref name="ppvResource"/> is <see cref="NullRef{IntPtr}"/>, no object is created,
        /// and <see cref="S_FALSE"/> is returned when <paramref name="pDesc"/> is valid.
        /// </para>
        /// </param>
        /// <returns></returns>
        public HRESULT CreateCommittedResource([In] in D3D12_HEAP_PROPERTIES pHeapProperties, [In] D3D12_HEAP_FLAGS HeapFlags,
            [In] in D3D12_RESOURCE_DESC pDesc, [In] D3D12_RESOURCE_STATES InitialResourceState,
            [In] in D3D12_CLEAR_VALUE pOptimizedClearValue, [In] in IID riidResource, [Out] out IntPtr ppvResource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D12_HEAP_PROPERTIES, D3D12_HEAP_FLAGS,
                    in D3D12_RESOURCE_DESC, D3D12_RESOURCE_STATES, in D3D12_CLEAR_VALUE, in IID, out IntPtr, HRESULT>)_vTable[27])
                    (thisPtr, pHeapProperties, HeapFlags, pDesc, InitialResourceState, pOptimizedClearValue, riidResource, out ppvResource);
            }
        }

        /// <summary>
        /// Creates a heap that can be used with placed resources and reserved resources.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a constant <see cref="D3D12_HEAP_DESC"/> structure that describes the heap.
        /// </param>
        /// <param name="riid">
        /// <para>
        /// A reference to the globally unique identifier (<see cref="GUID"/>) of the heap interface
        /// to return in <paramref name="ppvHeap"/>.
        /// </para>
        /// <para>
        /// While <paramref name="riid"/> is most commonly the <see cref="GUID"/> of <see cref="ID3D12Heap"/>,
        /// it may be the <see cref="GUID"/> of any interface.
        /// If the resource object doesn't support the interface for this <see cref="GUID"/>,
        /// then creation fails with <see cref="E_NOINTERFACE"/>.
        /// </para>
        /// </param>
        /// <param name="ppvHeap">
        /// <para>
        /// An optional pointer to a memory block that receives the requested interface pointer to the created heap object.
        /// </para>
        /// <para>
        /// <paramref name="ppvHeap"/> can be <see cref="NullRef{IntPtr}"/>, to enable capability testing.
        /// When <paramref name="ppvHeap"/> is <see cref="NullRef{IntPtr}"/>, no object is created,
        /// and <see cref="S_FALSE"/> is returned when <paramref name="pDesc"/> is valid.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// There is insufficient memory to create the heap.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// See Direct3D 12 return codes for other possible return values.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="CreateHeap"/> creates a heap that can be used with placed resources and reserved resources.
        /// </para>
        /// <para>
        /// Before releasing the final reference on the heap,
        /// your application must ensure that the GPU will no longer read or write to this heap.
        /// </para>
        /// <para>
        /// A placed resource object holds a reference on the heap it is created on;
        /// but a reserved resource doesn't hold a reference for each mapping made to a heap.
        /// </para>
        /// </remarks>
        public HRESULT CreateHeap([In] in D3D12_HEAP_DESC pDesc, [In] in IID riid, [Out] out IntPtr ppvHeap)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D12_HEAP_DESC, in IID, out IntPtr, HRESULT>)_vTable[28])
                    (thisPtr, pDesc, riid, out ppvHeap);
            }
        }

        /// <summary>
        /// <para>
        /// Creates a resource that is placed in a specific heap.
        /// Placed resources are the lightest weight resource objects available, and are the fastest to create and destroy.
        /// </para>
        /// <para>
        /// Your application can re-use video memory by overlapping multiple Direct3D placed and reserved resources on heap regions.
        /// The simple memory re-use model (described in Remarks) exists
        /// to clarify which overlapping resource is valid at any given time.
        /// To maximize graphics tool support, with the simple model data-inheritance isn't supported;
        /// and finer-grained tile and sub-resource invalidation isn't supported.
        /// Only full overlapping resource invalidation occurs.
        /// </para>
        /// </summary>
        /// <param name="pHeap">
        /// A pointer to the <see cref="ID3D12Heap"/> interface that represents the heap in which the resource is placed.
        /// </param>
        /// <param name="HeapOffset">
        /// The offset, in bytes, to the resource.
        /// The <paramref name="HeapOffset"/> must be a multiple of the resource's alignment,
        /// and <paramref name="HeapOffset"/> plus the resource size must be smaller than or equal to the heap size.
        /// <see cref="GetResourceAllocationInfo"/> must be used to understand the sizes of texture resources.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D12_RESOURCE_DESC"/> structure that describes the resource.
        /// </param>
        /// <param name="InitialState">
        /// <para>
        /// The initial state of the resource, as a bitwise-OR'd combination of <see cref="D3D12_RESOURCE_STATES"/> enumeration constants.
        /// </para>
        /// <para>
        /// When a resource is created together with a <see cref="D3D12_HEAP_TYPE_UPLOAD"/> heap,
        /// <paramref name="InitialState"/> must be <see cref="D3D12_RESOURCE_STATE_GENERIC_READ"/>.
        /// When a resource is created together with a <see cref="D3D12_HEAP_TYPE_READBACK"/> heap,
        /// <paramref name="InitialState"/> must be <see cref="D3D12_RESOURCE_STATE_COPY_DEST"/>.
        /// </para>
        /// </param>
        /// <param name="pOptimizedClearValue">
        /// <para>
        /// Specifies a <see cref="D3D12_CLEAR_VALUE"/> that describes the default value for a clear color.
        /// </para>
        /// <para>
        /// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal.
        /// When the created resource is a texture with either the <see cref="D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET"/>
        /// or <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/> flags,
        /// your application should choose the value that the clear operation will most commonly be called with.
        /// </para>
        /// <para>
        /// Clear operations can be called with other values,
        /// but those operations will not be as efficient as when the value matches the one passed into resource creation.
        /// </para>
        /// <para>
        /// <paramref name="pOptimizedClearValue"/> must be <see cref="NullRef{D3D12_CLEAR_VALUE}"/>
        /// when used with <see cref="D3D12_RESOURCE_DIMENSION_BUFFER"/>.
        /// </para>
        /// </param>
        /// <param name="riid">
        /// <para>
        /// The globally unique identifier (<see cref="GUID"/>) for the resource interface. This is an input parameter.
        /// </para>
        /// <para>
        /// The <c>REFIID</c>, or <see cref="GUID"/>,
        /// of the interface to the resource can be obtained by using the <c>__uuidof</c> macro.
        /// For example, <c>__uuidof(ID3D12Resource)</c> gets the <see cref="GUID"/> of the interface to a resource.
        /// Although <paramref name="riid"/> is, most commonly, the GUID for <see cref="ID3D12Resource"/>,
        /// it may be any <see cref="GUID"/> for any interface.
        /// If the resource object doesn't support the interface for this <see cref="GUID"/>,
        /// then creation fails with <see cref="E_NOINTERFACE"/>.
        /// </para>
        /// </param>
        /// <param name="ppvResource">
        /// A pointer to a memory block that receives a pointer to the resource.
        /// <paramref name="ppvResource"/> can be <see cref="NullRef{IntPtr}"/>, to enable capability testing.
        /// When <paramref name="ppvResource"/> is <see cref="NullRef{IntPtr}"/>, no object will be created
        /// and <see cref="S_FALSE"/> will be returned when <paramref name="pDesc"/> and other parameters are valid.
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the resource.
        /// See Direct3D 12 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="CreatePlacedResource"/> is similar to fully mapping a reserved resource to an offset within a heap;
        /// but the virtual address space associated with a heap may be reused as well.
        /// </para>
        /// <para>
        /// Placed resources are lighter weight to create and destroy than committed resources are.
        /// This is because no heap is created nor destroyed during those operations.
        /// In addition, placed resources enable an even lighter weight technique
        /// to reuse memory than resource creation and destruction—that is, reuse through aliasing, and aliasing barriers.
        /// Multiple placed resources may simultaneously overlap each other on the same heap,
        /// but only a single overlapping resource can be used at a time.
        /// </para>
        /// <para>
        /// There are two placed resource usage semantics—a simple model, and an advanced model.
        /// We recommend that you choose the simple model (it maximizes graphics tool support across the diverse ecosystem of GPUs),
        /// unless and until you find that you need the advanced model for your app.
        /// </para>
        /// <para>
        /// Simple model
        /// </para>
        /// <para>
        /// In this model, you can consider a placed resource to be in one of two states: active, or inactive.
        /// It's invalid for the GPU to either read or write from an inactive resource.
        /// Placed resources are created in the inactive state.
        /// </para>
        /// <para>
        /// To activate a resource with an aliasing barrier on a command list,
        /// your application must pass the resource in <see cref="D3D12_RESOURCE_ALIASING_BARRIER.pResourceAfter"/>.
        /// <see cref="D3D12_RESOURCE_ALIASING_BARRIER.pResourceBefore"/> can be left <see cref="NULL"/> during an activation.
        /// All resources that share physical memory with the activated resource now become inactive,
        /// which includes overlapping placed and reserved resources.
        /// </para>
        /// <para>
        /// Aliasing barriers should be grouped up and submitted together, in order to maximize efficiency.
        /// </para>
        /// <para>
        /// After activation, resources with either the render target or depth stencil flags must be further initialized.
        /// See the notes on the required resource initialization below.
        /// </para>
        /// <para>
        /// Notes on the required resource initialization
        /// </para>
        /// <para>
        /// Certain resource types still require initialization.
        /// Resources with either the render target or depth stencil flags must be initialized
        /// with either a clear operation or a collection of full subresource copies.
        /// If an aliasing barrier was used to denote the transition between two aliased resources,
        /// the initialization must occur after the aliasing barrier.
        /// This initialization is still required whenever a resource would've been activated in the simple model.
        /// </para>
        /// <para>
        /// Placed and reserved resources with either the render target or depth stencil flags
        /// must be initialized with one of the following operations before other operations are supported.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// A <c>Clear</c> operation; for example <see cref="ID3D12GraphicsCommandList.ClearRenderTargetView"/>
        /// or <see cref="ID3D12GraphicsCommandList.ClearDepthStencilView"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A <see cref="ID3D12GraphicsCommandList.DiscardResource"/> operation.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A <c>Copy</c> operation; for example <see cref="ID3D12GraphicsCommandList.CopyBufferRegion"/>,
        /// <see cref="ID3D12GraphicsCommandList.CopyTextureRegion"/>, or <see cref="ID3D12GraphicsCommandList.CopyResource"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Applications should prefer the most explicit operation that results in the least amount of texels modified.
        /// Consider the following examples.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Using a depth buffer to solve pixel visibility typically requires each depth texel start out at 1.0 or 0.
        /// Therefore, a <c>Clear</c> operation should be the most efficient option for aliased depth buffer initialization.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// An application may use an aliased render target as a destination for tone mapping.
        /// Since the application will render over every pixel during the tone mapping,
        /// <see cref="ID3D12GraphicsCommandList.DiscardResource"/> should be the most efficient option for initialization.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Advanced model
        /// </para>
        /// <para>
        /// In this model, you can ignore the active/inactive state abstraction.
        /// Instead, you must honor these lower-level rules.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// An aliasing barrier must be between two different GPU resource accesses of the same physical memory,
        /// as long as those accesses are within the same <see cref="ID3D12CommandQueue.ExecuteCommandLists"/> call.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The first rendering operation to certain types of aliased resource must still be an initialization,
        /// just like the simple model.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Initialization operations must occur either on an entire subresource, or on a 64KB granularity.
        /// An entire subresource initialization is supported for all resource types.
        /// A 64KB initialization granularity, aligned at a 64KB offset,
        /// is supported for buffers and textures with either the <see cref="D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE"/>
        /// or <see cref="D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE "/> texture layout (refer to <see cref="D3D12_TEXTURE_LAYOUT"/>).
        /// </para>
        /// <para>
        /// Notes on the aliasing barrier
        /// </para>
        /// <para>
        /// The aliasing barrier may set NULL for both <see cref="D3D12_RESOURCE_ALIASING_BARRIER.pResourceAfter"/>
        /// and <see cref="D3D12_RESOURCE_ALIASING_BARRIER.pResourceBefore"/>.
        /// The memory coherence definition of <see cref="ID3D12CommandQueue.ExecuteCommandLists"/> and an aliasing barrier are the same,
        /// such that two aliased accesses to the same physical memory need no aliasing barrier
        /// when the accesses are in two different <see cref="ID3D12CommandQueue.ExecuteCommandLists"/> invocations.
        /// </para>
        /// <para>
        /// For D3D12 advanced usage models, the synchronization definition
        /// of <see cref="ID3D12CommandQueue.ExecuteCommandLists"/> is equivalent to an aliasing barrier.
        /// Therefore, applications may either insert an aliasing barrier between reusing physical memory,
        /// or ensure the two aliased usages of physical memory occurs
        /// in two separate calls to <see cref="ID3D12CommandQueue.ExecuteCommandLists"/>.
        /// </para>
        /// <para>
        /// The amount of inactivation varies based on resource properties.
        /// Textures with undefined memory layouts are the worst case, as the entire texture must be inactivated atomically.
        /// For two overlapping resources with defined layouts,
        /// inactivation can result in only the overlapping aligned regions of a resource.
        /// Data inheritance can even be well-defined.
        /// For more details, see Memory aliasing and data inheritance.
        /// </para>
        /// </remarks>
        public HRESULT CreatePlacedResource([In] P<ID3D12Heap> pHeap, [In] UINT64 HeapOffset, [In] in D3D12_RESOURCE_DESC pDesc,
            [In] D3D12_RESOURCE_STATES InitialState, [In] in D3D12_CLEAR_VALUE pOptimizedClearValue,
            [In] in IID riid, [Out] out IntPtr ppvResource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Heap>, UINT64, in D3D12_RESOURCE_DESC,
                    D3D12_RESOURCE_STATES, in D3D12_CLEAR_VALUE, in IID, out IntPtr, HRESULT>)_vTable[29])
                    (thisPtr, pHeap, HeapOffset, pDesc, InitialState, pOptimizedClearValue, riid, out ppvResource);
            }
        }

        /// <summary>
        /// Creates a resource that is reserved, and not yet mapped to any pages in a heap.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D12_RESOURCE_DESC"/> structure that describes the resource.
        /// </param>
        /// <param name="InitialState">
        /// The initial state of the resource, as a bitwise-OR'd combination of <see cref="D3D12_RESOURCE_STATES"/> enumeration constants.
        /// </param>
        /// <param name="pOptimizedClearValue">
        /// <para>
        /// Specifies a <see cref="D3D12_CLEAR_VALUE"/> structure that describes the default value for a clear color.
        /// </para>
        /// <para>
        /// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal.
        /// When the created resource is a texture with either the <see cref="D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET"/>
        /// or <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/> flags,
        /// you should choose the value with which the clear operation will most commonly be called.
        /// You can call the clear operation with other values,
        /// but those operations won't be as efficient as when the value matches the one passed in to resource creation.
        /// </para>
        /// <para>
        /// When you use <see cref="D3D12_RESOURCE_DIMENSION_BUFFER"/>,
        /// you must set <paramref name="pOptimizedClearValue"/> to <see cref="NullRef{D3D12_CLEAR_VALUE}"/>.
        /// </para>
        /// </param>
        /// <param name="riid">
        /// <para>
        /// A reference to the globally unique identifier (<see cref="GUID"/>)
        /// of the resource interface to return in <paramref name="ppvResource"/>.
        /// See Remarks.
        /// </para>
        /// <para>
        /// While <paramref name="riid"/> is most commonly the <see cref="GUID"/> of <see cref="ID3D12Resource"/>,
        /// it may be the <see cref="GUID"/> of any interface.
        /// If the resource object doesn't support the interface for this <see cref="GUID"/>,
        /// then creation fails with <see cref="E_NOINTERFACE"/>.
        /// </para>
        /// </param>
        /// <param name="ppvResource">
        /// <para>
        /// An optional pointer to a memory block that receives the requested interface pointer to the created resource object.
        /// </para>
        /// <para>
        /// <paramref name="ppvResource"/> can be <see cref="NullRef{IntPtr}"/>, to enable capability testing.
        /// When <paramref name="ppvResource"/> is <see cref="NullRef{IntPtr}"/>, no object is created,
        /// and <see cref="S_FALSE"/> is returned when <paramref name="pDesc"/> is valid.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// There is insufficient memory to create the resource.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// See Direct3D 12 return codes for other possible return values.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="CreateReservedResource"/> is equivalent to <see cref="D3D11_RESOURCE_MISC_TILED"/> in Direct3D 11.
        /// It creates a resource with virtual memory only, no backing store.
        /// </para>
        /// <para>
        /// You need to map the resource to physical memory (that is, to a heap)
        /// using <see cref="ID3D12CommandQueue.CopyTileMappings"/> and <see cref="ID3D12CommandQueue.UpdateTileMappings"/>.
        /// </para>
        /// <para>
        /// These resource types can only be created when the adapter supports tiled resource tier 1 or greater.
        /// The tiled resource tier defines the behavior of accessing a resource that is not mapped to a heap.
        /// </para>
        /// </remarks>
        public HRESULT CreateReservedResource([In] in D3D12_RESOURCE_DESC pDesc, [In] D3D12_RESOURCE_STATES InitialState,
            [In] in D3D12_CLEAR_VALUE pOptimizedClearValue, [In] in IID riid, [Out] out IntPtr ppvResource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D12_RESOURCE_DESC, D3D12_RESOURCE_STATES,
                    in D3D12_CLEAR_VALUE, in IID, out IntPtr, HRESULT>)_vTable[30])
                    (thisPtr, pDesc, InitialState, pOptimizedClearValue, riid, out ppvResource);
            }
        }

        /// <summary>
        /// Creates a shared handle to a heap, resource, or fence object.
        /// </summary>
        /// <param name="pObject">
        /// <para>
        /// A pointer to the <see cref="ID3D12DeviceChild"/> interface
        /// that represents the heap, resource, or fence object to create for sharing.
        /// The following interfaces (derived from <see cref="ID3D12DeviceChild"/>) are supported:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ID3D12Heap"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D12Resource"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D12Fence"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pAttributes">
        /// <para>
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that contains two separate but related data members:
        /// an optional security descriptor, and a <see cref="BOOL"/> value
        /// that determines whether child processes can inherit the returned handle.
        /// </para>
        /// <para>
        /// Set this parameter to <see cref="NullRef{SECURITY_ATTRIBUTES}"/>
        /// if you want child processes that the application might create
        /// to not inherit the handle returned by <see cref="CreateSharedHandle"/>,
        /// and if you want the resource that is associated with the returned handle to get a default security descriptor.
        /// </para>
        /// <para>
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure
        /// specifies a <see cref="SECURITY_DESCRIPTOR"/> for the resource.
        /// Set this member to <see cref="NULL"/> if you want the runtime to assign a default security descriptor
        /// to the resource that is associated with the returned handle.
        /// The ACLs in the default security descriptor for the resource come from the primary or impersonation token of the creator.
        /// For more info, see Synchronization Object Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="Access">
        /// Currently the only value this parameter accepts is <see cref="GENERIC_ALL"/>.
        /// </param>
        /// <param name="Name">
        /// <para>
        /// A <see cref="NULL"/>-terminated <c>UNICODE</c> string that contains the name to associate with the shared heap.
        /// The name is limited to <see cref="MAX_PATH"/> characters.
        /// Name comparison is case-sensitive.
        /// </para>
        /// <para>
        /// If <paramref name="Name"/> matches the name of an existing resource,
        /// <see cref="CreateSharedHandle"/> fails with <see cref="DXGI_ERROR_NAME_ALREADY_EXISTS"/>.
        /// This occurs because these objects share the same namespace.
        /// </para>
        /// <para>
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character (\).
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// </para>
        /// <para>
        /// The object can be created in a private namespace.
        /// For more information, see Object Namespaces.
        /// </para>
        /// </param>
        /// <param name="pHandle">
        /// A pointer to a variable that receives the NT HANDLE value to the resource to share.
        /// You can use this handle in calls to access the resource.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns one of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if one of the parameters is invalid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_NAME_ALREADY_EXISTS"/> if the supplied name of the resource
        /// to share is already associated with another resource.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_ACCESSDENIED"/> if the object is being created in a protected namespace.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_OUTOFMEMORY"/> if sufficient memory is not available to create the handle.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the Direct3D 12 Return Codes topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Both heaps and committed resources can be shared.
        /// Sharing a committed resource shares the implicit heap along with the committed resource description,
        /// such that a compatible resource description can be mapped to the heap from another device.
        /// </para>
        /// <para>
        /// For Direct3D 11 and Direct3D 12 interop scenarios,
        /// a shared fence is opened in DirectX 11 with the <see cref="ID3D11Device5.OpenSharedFence"/> method,
        /// and a shared resource is opened with the <see cref="ID3D11Device1.OpenSharedResource1"/> method.
        /// </para>
        /// <para>
        /// For Direct3D 12, a shared handle is opened with the <see cref="OpenSharedHandle"/>
        /// or the <see cref="OpenSharedHandleByName"/> method.
        /// </para>
        /// </remarks>
        public HRESULT CreateSharedHandle([In] P<ID3D12DeviceChild> pObject, [In] in SECURITY_ATTRIBUTES pAttributes,
            [In] ACCESS_MASK Access, [In] LPCWSTR Name, [Out] out IntPtr pHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D12DeviceChild>, in SECURITY_ATTRIBUTES,
                    ACCESS_MASK, IntPtr, out IntPtr, HRESULT>)_vTable[31])
                    (thisPtr, pObject, pAttributes, Access, Name.ToIntPtr(), out pHandle);
            }
        }

        /// <summary>
        /// Opens a handle for shared resources, shared heaps, and shared fences, by using HANDLE and REFIID.
        /// </summary>
        /// <param name="NTHandle">
        /// The handle that was output by the call to <see cref="CreateSharedHandle"/>.
        /// </param>
        /// <param name="riid">
        /// <para>
        /// The globally unique identifier (<see cref="GUID"/>) for one of the following interfaces:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ID3D12Heap"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D12Resource"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D12Fence"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface can be obtained by using the <c>__uuidof()</c> macro.
        /// For example, <c>__uuidof(ID3D12Heap)</c> will get the <see cref="GUID"/> of the interface to a resource.
        /// </para>
        /// </param>
        /// <param name="ppvObj">
        /// <para>
        /// A pointer to a memory block that receives a pointer to one of the following interfaces:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ID3D12Heap"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D12Resource"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D12Fence"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        public HRESULT OpenSharedHandle([In] HANDLE NTHandle, [In] in IID riid, out IntPtr ppvObj)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, in IID, out IntPtr, HRESULT>)_vTable[32])
                    (thisPtr, NTHandle, riid, out ppvObj);
            }
        }

        /// <summary>
        /// Opens a handle for shared resources, shared heaps, and shared fences, by using Name and Access.
        /// </summary>
        /// <param name="Name">
        /// The name that was optionally passed as the <paramref name="Name"/> parameter
        /// in the call to <see cref="CreateSharedHandle"/>.
        /// </param>
        /// <param name="Access">
        /// The access level that was specified in the <paramref name="Access"/> parameter
        /// in the call to <see cref="CreateSharedHandle"/>.
        /// </param>
        /// <param name="pNTHandle">
        /// Pointer to the shared handle.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        public HRESULT OpenSharedHandleByName([In] LPCWSTR Name, [In] ACCESS_MASK Access, out HANDLE pNTHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, ACCESS_MASK, out HANDLE, HRESULT>)_vTable[33])
                    (thisPtr, Name.ToIntPtr(), Access, out pNTHandle);
            }
        }

        /// <summary>
        /// Makes objects resident for the device.
        /// </summary>
        /// <param name="NumObjects">
        /// The number of objects in the <paramref name="ppObjects"/> array to make resident for the device.
        /// </param>
        /// <param name="ppObjects">
        /// <para>
        /// A pointer to a memory block that contains an array of <see cref="ID3D12Pageable"/> interface pointers for the objects.
        /// </para>
        /// <para>
        /// Even though most D3D12 objects inherit from <see cref="ID3D12Pageable"/>,
        /// residency changes are only supported on the following objects:
        /// Descriptor Heaps, Heaps, Committed Resources, and Query Heaps
        /// </para>
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="MakeResident"/> loads the data associated with a resource from disk,
        /// and re-allocates the memory from the resource's appropriate memory pool.
        /// This method should be called on the object which owns the physical memory.
        /// </para>
        /// <para>
        /// Use this method, and <see cref="Evict"/>, to manage GPU video memory,
        /// noting that this was done automatically in D3D11, but now has to be done by the app in D3D12.
        /// </para>
        /// <para>
        /// <see cref="MakeResident"/> and <see cref="Evict"/> can help applications manage the residency budget on many adapters.
        /// <see cref="MakeResident"/> explicitly pages-in data and, then, precludes page-out so the GPU can access the data.
        /// <see cref="Evict"/> enables page-out.
        /// </para>
        /// <para>
        /// Some GPU architectures do not benefit from residency manipulation, due to the lack of sufficient GPU virtual address space.
        /// Use <see cref="D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT"/> and <see cref="IDXGIAdapter3.QueryVideoMemoryInfo"/>
        /// to recognize when the maximum GPU VA space per-process is too small or roughly the same size as the residency budget.
        /// For such architectures, the residency budget will always be constrained by the amount of GPU virtual address space.
        /// <see cref="Evict"/> will not free-up any residency budget on such systems.
        /// </para>
        /// <para>
        /// Applications must handle <see cref="MakeResident"/> failures,
        /// even if there appears to be enough residency budget available.
        /// Physical memory fragmentation and adapter architecture quirks can preclude the utilization of large contiguous ranges.
        /// Applications should free up more residency budget before trying again.
        /// </para>
        /// <para>
        /// <see cref="MakeResident"/> is ref-counted, such that <see cref="Evict"/> must be called
        /// the same amount of times as <see cref="MakeResident"/> before <see cref="Evict"/> takes effect.
        /// Objects that support residency are made resident during creation,
        /// so a single <see cref="Evict"/> call will actually evict the object.
        /// </para>
        /// <para>
        /// Applications must use fences to ensure the GPU doesn't use non-resident objects.
        /// <see cref="MakeResident"/> must return before the GPU executes a command list that references the object.
        /// <see cref="Evict"/> must be called after the GPU finishes executing a command list that references the object.
        /// </para>
        /// <para>
        /// Evicted objects still consume the same GPU virtual address and same amount of GPU virtual address space.
        /// Therefore, resource descriptors and other GPU virtual address references are not invalidated after <see cref="Evict"/>.
        /// </para>
        /// </remarks>
        public HRESULT MakeResident([In] UINT NumObjects, [In] P<ID3D12Pageable>[] ppObjects)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (P<ID3D12Pageable>* ppObjectsPtr = ppObjects)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D12Pageable>*, HRESULT>)_vTable[34])(thisPtr, NumObjects, ppObjectsPtr);
                }
            }
        }

        /// <summary>
        /// Enables the page-out of data, which precludes GPU access of that data.
        /// </summary>
        /// <param name="NumObjects">
        /// The number of objects in the <paramref name="ppObjects"/> array to evict from the device.
        /// </param>
        /// <param name="ppObjects">
        /// <para>
        /// A pointer to a memory block that contains an array of <see cref="ID3D12Pageable"/> interface pointers for the objects.
        /// </para>
        /// <para>
        /// Even though most D3D12 objects inherit from <see cref="ID3D12Pageable"/>,
        /// residency changes are only supported on the following objects:
        /// Descriptor Heaps, Heaps, Committed Resources, and Query Heaps
        /// </para>
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="Evict"/> persists the data associated with a resource to disk,
        /// and then removes the resource from the memory pool where it was located.
        /// This method should be called on the object which owns the physical memory:
        /// either a committed resource (which owns both virtual and physical memory assignments) or a heap
        /// - noting that reserved resources do not have physical memory, and placed resources are borrowing memory from a heap.
        /// </para>
        /// <para>
        /// Refer to the remarks for <see cref="MakeResident"/>.
        /// </para>
        /// </remarks>
        public HRESULT Evict([In] UINT NumObjects, [In] P<ID3D12Pageable>[] ppObjects)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (P<ID3D12Pageable>* ppObjectsPtr = ppObjects)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D12Pageable>*, HRESULT>)_vTable[35])(thisPtr, NumObjects, ppObjectsPtr);
                }
            }
        }

        /// <summary>
        /// Creates a fence object.
        /// </summary>
        /// <param name="InitialValue">
        /// The initial value for the fence.
        /// </param>
        /// <param name="Flags">
        /// A combination of <see cref="D3D12_FENCE_FLAGS"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for the fence.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (<see cref="GUID"/>) for the fence interface (<see cref="ID3D12Fence"/>).
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface to the fence can be obtained by using the <c>__uuidof()</c> macro.
        /// For example, <c>__uuidof(ID3D12Fence)</c> will get the <see cref="GUID"/> of the interface to a fence.
        /// </param>
        /// <param name="ppFence">
        /// A pointer to a memory block that receives a pointer to the <see cref="ID3D12Fence"/> interface that is used to access the fence.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the Direct3D 12 Return Codes.
        /// </returns>
        public HRESULT CreateFence([In] UINT64 InitialValue, [In] D3D12_FENCE_FLAGS Flags, [In] in IID riid, [Out] out IntPtr ppFence)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT64, D3D12_FENCE_FLAGS, in IID, out IntPtr, HRESULT>)_vTable[36])
                    (thisPtr, InitialValue, Flags, riid, out ppFence);
            }
        }

        /// <summary>
        /// Gets the reason that the device was removed, or <see cref="S_OK"/> if the device isn't removed.
        /// To be called back when a device is removed,
        /// consider using <see cref="ID3D12Fence.SetEventOnCompletion"/> with a value of <see cref="UINT64_MAX"/>.
        /// That's because device removal causes all fences to be signaled to that value
        /// (which also implies completing all events waited on, because they'll all be less than <see cref="UINT64_MAX"/>).
        /// </summary>
        /// <returns>
        /// This method returns the reason that the device was removed.
        /// </returns>
        public HRESULT GetDeviceRemovedReason()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[37])(thisPtr);
            }
        }

        /// <summary>
        /// Gets a resource layout that can be copied.
        /// Helps the app fill-in <see cref="D3D12_PLACED_SUBRESOURCE_FOOTPRINT"/> and <see cref="D3D12_SUBRESOURCE_FOOTPRINT"/>
        /// when suballocating space in upload heaps.
        /// </summary>
        /// <param name="pResourceDesc">
        /// A description of the resource, as a pointer to a <see cref="D3D12_RESOURCE_DESC"/> structure.
        /// </param>
        /// <param name="FirstSubresource">
        /// Index of the first subresource in the resource.
        /// The range of valid values is 0 to <see cref="D3D12_REQ_SUBRESOURCES"/>.
        /// </param>
        /// <param name="NumSubresources">
        /// The number of subresources in the resource.
        /// The range of valid values is 0 to (<see cref="D3D12_REQ_SUBRESOURCES"/> - <paramref name="FirstSubresource"/>).
        /// </param>
        /// <param name="BaseOffset">
        /// The offset, in bytes, that is added to the <see cref="D3D12_PLACED_SUBRESOURCE_FOOTPRINT.Offset"/>
        /// of each <see cref="D3D12_PLACED_SUBRESOURCE_FOOTPRINT"/> in the <paramref name="pLayouts"/> array.
        /// </param>
        /// <param name="pLayouts">
        /// A pointer to an array (of length <paramref name="NumSubresources"/>) of <see cref="D3D12_PLACED_SUBRESOURCE_FOOTPRINT"/> structures,
        /// to be filled with the description and placement of each subresource.
        /// </param>
        /// <param name="pNumRows">
        /// A pointer to an array (of length <paramref name="NumSubresources"/>) of integer variables,
        /// to be filled with the number of rows for each subresource.
        /// </param>
        /// <param name="pRowSizeInBytes">
        /// <para>
        /// A pointer to an array (of length <paramref name="NumSubresources"/>) of integer variables,
        /// each entry to be filled with the unpadded size in bytes of a row, of each subresource.
        /// </para>
        /// <para>
        /// For example, if a Texture2D resource has a width of 32 and bytes per pixel of 4,
        /// </para>
        /// <para>
        /// then <paramref name="pRowSizeInBytes"/> returns 128.
        /// </para>
        /// <para>
        /// <paramref name="pRowSizeInBytes"/> should not be confused with row pitch,
        /// as examining <paramref name="pLayouts"/> and getting the row pitch from that
        /// will give you 256 as it is aligned to <see cref="D3D12_TEXTURE_DATA_PITCH_ALIGNMENT"/>.
        /// </para>
        /// </param>
        /// <param name="pTotalBytes">
        /// A pointer to an integer variable, to be filled with the total size, in bytes.
        /// If <paramref name="pResourceDesc"/> is invalid,
        /// then the value of <paramref name="pTotalBytes"/> is set to <see cref="UINT64_MAX"/>.
        /// </param>
        /// <remarks>
        /// This routine assists the application in filling out <see cref="D3D12_PLACED_SUBRESOURCE_FOOTPRINT"/>
        /// and <see cref="D3D12_SUBRESOURCE_FOOTPRINT"/> structures, when suballocating space in upload heaps.
        /// The resulting structures are GPU adapter-agnostic,
        /// meaning that the values will not vary from one GPU adapter to the next.
        /// <see cref="GetCopyableFootprints"/> uses specified details about resource formats,
        /// texture layouts, and alignment requirements (from the <see cref="D3D12_RESOURCE_DESC"/> structure)
        /// to fill out the subresource structures.
        /// Applications have access to all these details, so this method, or a variation of it,
        /// could be written as part of the app.
        /// </remarks>
        public void GetCopyableFootprints([In] in D3D12_RESOURCE_DESC pResourceDesc, [In] UINT FirstSubresource,
            [In] UINT NumSubresources, [In] UINT64 BaseOffset, [Out] D3D12_PLACED_SUBRESOURCE_FOOTPRINT[] pLayouts,
            [Out] UINT[] pNumRows, [Out] UINT64[] pRowSizeInBytes, [Out] out UINT64 pTotalBytes)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_PLACED_SUBRESOURCE_FOOTPRINT* pLayoutsPtr = pLayouts)
                {
                    fixed (UINT* pNumRowsPtr = pNumRows)
                    {
                        fixed (UINT64* pRowSizeInBytesPtr = pRowSizeInBytes)
                        {
                            ((delegate* unmanaged[Stdcall]<void*, in D3D12_RESOURCE_DESC, UINT, UINT, UINT64,
                                D3D12_PLACED_SUBRESOURCE_FOOTPRINT*, UINT*, UINT64*, out UINT64, void>)_vTable[38])
                                (thisPtr, pResourceDesc, FirstSubresource, NumSubresources, BaseOffset, pLayoutsPtr,
                                pNumRowsPtr, pRowSizeInBytesPtr, out pTotalBytes);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a query heap.
        /// A query heap contains an array of queries.
        /// </summary>
        /// <param name="pDesc">
        /// Specifies the query heap in a <see cref="D3D12_QUERY_HEAP_DESC"/> structure.
        /// </param>
        /// <param name="riid">
        /// Specifies a <c>REFIID</c> that uniquely identifies the heap.
        /// </param>
        /// <param name="ppvHeap">
        /// Specifies a pointer to the heap, that will be returned on successful completion of the method.
        /// <paramref name="ppvHeap"/> can be <see cref="NullRef{IntPtr}"/>, to enable capability testing.
        /// When <paramref name="ppvHeap"/> is <see cref="NullRef{IntPtr}"/>, no object will be created
        /// and <see cref="S_FALSE"/> will be returned when <paramref name="pDesc"/> is valid.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// Refer to Queries for more information.
        /// </remarks>
        public HRESULT CreateQueryHeap([In] in D3D12_QUERY_HEAP_DESC pDesc, [In] in IID riid, [Out] out IntPtr ppvHeap)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D12_QUERY_HEAP_DESC, in IID, out IntPtr, HRESULT>)_vTable[39])
                    (thisPtr, pDesc, riid, out ppvHeap);
            }
        }

        /// <summary>
        /// A development-time aid for certain types of profiling and experimental prototyping.
        /// </summary>
        /// <param name="Enable">
        /// Specifies a <see cref="BOOL"/> that turns the stable power state on or off.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method is only useful during the development of applications.
        /// It enables developers to profile GPU usage of multiple algorithms without experiencing artifacts from dynamic frequency scaling.
        /// </para>
        /// <para>
        /// Do not call this method in normal execution for a shipped application.
        /// This method only works while the machine is in developer mode.
        /// If developer mode is not enabled, then device removal will occur.
        /// Instead, call this method in response to an off-by-default, developer-facing switch.
        /// Calling it in response to command line parameters, config files, registry keys,
        /// and developer console commands are reasonable usage scenarios.
        /// </para>
        /// <para>
        /// A stable power state typically fixes GPU clock rates at a slower setting
        /// that is significantly lower than that experienced by users under normal application load.
        /// This reduction in clock rate affects the entire system.
        /// Slow clock rates are required to ensure processors don’t exhaust power, current, and thermal limits.
        /// Normal usage scenarios commonly leverage a processors ability to dynamically over-clock.
        /// Any conclusions made by comparing two designs under a stable power state
        /// should be double-checked with supporting results from real usage scenarios.
        /// </para>
        /// </remarks>
        public HRESULT SetStablePowerState([In] BOOL Enable)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[40])(thisPtr, Enable);
            }
        }

        /// <summary>
        /// This method creates a command signature.
        /// </summary>
        /// <param name="pDesc">
        /// Describes the command signature to be created with the <see cref="D3D12_COMMAND_SIGNATURE_DESC"/> structure.
        /// </param>
        /// <param name="pRootSignature">
        /// <para>
        /// Specifies the <see cref="ID3D12RootSignature"/> that the command signature applies to.
        /// </para>
        /// <para>
        /// The root signature is required if any of the commands in the signature will update bindings on the pipeline.
        /// If the only command present is a draw or dispatch, the root signature parameter can be set to <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (<see cref="GUID"/>) for the command signature interface (<see cref="ID3D12CommandSignature"/>).
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface to the command signature
        /// can be obtained by using the <c>__uuidof()</c> macro.
        /// For example, <c>__uuidof(ID3D12CommandSignature)</c> will get the <see cref="GUID"/> of the interface to a command signature.
        /// </param>
        /// <param name="ppvCommandSignature">
        /// Specifies a pointer, that on successful completion of the method
        /// will point to the created command signature (<see cref="ID3D12CommandSignature"/>).
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        public HRESULT CreateCommandSignature([In] in D3D12_COMMAND_SIGNATURE_DESC pDesc, [In] P<ID3D12RootSignature> pRootSignature,
            [In] in IID riid, [Out] out IntPtr ppvCommandSignature)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D12_COMMAND_SIGNATURE_DESC, P<ID3D12RootSignature>,
                    in IID, out IntPtr, HRESULT>)_vTable[41])(thisPtr, pDesc, pRootSignature, riid, out ppvCommandSignature);
            }
        }

        /// <summary>
        /// Gets info about how a tiled resource is broken into tiles.
        /// </summary>
        /// <param name="pTiledResource">
        /// Specifies a tiled <see cref="ID3D12Resource"/> to get info about.
        /// </param>
        /// <param name="pNumTilesForEntireResource">
        /// A pointer to a variable that receives the number of tiles needed to store the entire tiled resource.
        /// </param>
        /// <param name="pPackedMipDesc">
        /// A pointer to a <see cref="D3D12_PACKED_MIP_INFO"/> structure
        /// that <see cref="GetResourceTiling"/> fills with info about how the tiled resource's mipmaps are packed.
        /// </param>
        /// <param name="pStandardTileShapeForNonPackedMips">
        /// Specifies a <see cref="D3D12_TILE_SHAPE"/> structure
        /// that <see cref="GetResourceTiling"/> fills with info about the tile shape.
        /// This is info about how pixels fit in the tiles, independent of tiled resource's dimensions, not including packed mipmaps.
        /// If the entire tiled resource is packed,
        /// this parameter is meaningless because the tiled resource has no defined layout for packed mipmaps.
        /// In this situation, <see cref="GetResourceTiling"/> sets the members of <see cref="D3D12_TILE_SHAPE"/> to zeros.
        /// </param>
        /// <param name="pNumSubresourceTilings">
        /// A pointer to a variable that contains the number of tiles in the subresource.
        /// On input, this is the number of subresources to query tilings for;
        /// on output, this is the number that was actually retrieved at <paramref name="pSubresourceTilingsForNonPackedMips"/>
        /// (clamped to what's available).
        /// </param>
        /// <param name="FirstSubresourceTilingToGet">
        /// The index of the first subresource tile to get.
        /// <see cref="GetResourceTiling"/> ignores this parameter
        /// if the number that <paramref name="pNumSubresourceTilings"/> points to is 0.
        /// </param>
        /// <param name="pSubresourceTilingsForNonPackedMips">
        /// Specifies a <see cref="D3D12_SUBRESOURCE_TILING"/> structure
        /// that <see cref="GetResourceTiling"/> fills with info about subresource tiles.
        /// If subresource tiles are part of packed mipmaps,
        /// <see cref="GetResourceTiling"/> sets the members of <see cref="D3D12_SUBRESOURCE_TILING"/> to zeros,
        /// except the <see cref="D3D12_SUBRESOURCE_TILING.StartTileIndexInOverallResource"/> member,
        /// which <see cref="GetResourceTiling"/> sets to <see cref="D3D12_PACKED_TILE"/> (0xffffffff).
        /// The <see cref="D3D12_PACKED_TILE"/> constant indicates
        /// that the whole <see cref="D3D12_SUBRESOURCE_TILING"/> structure is meaningless for this situation,
        /// and the info that the <paramref name="pPackedMipDesc"/> parameter points to applies.
        /// </param>
        /// <remarks>
        /// <para>
        /// To estimate the total resource size of textures needed
        /// when calculating heap sizes and calling <see cref="CreatePlacedResource"/>,
        /// use <see cref="GetResourceAllocationInfo"/> instead of <see cref="GetResourceTiling"/>.
        /// <see cref="GetResourceTiling"/> cannot be used for this.
        /// </para>
        /// <para>
        /// For more information on tiled resources, refer to Volume Tiled Resources.
        /// </para>
        /// </remarks>
        public void GetResourceTiling([In] P<ID3D12Resource> pTiledResource, out UINT pNumTilesForEntireResource,
            [Out] out D3D12_PACKED_MIP_INFO pPackedMipDesc, [Out] out D3D12_TILE_SHAPE pStandardTileShapeForNonPackedMips,
            [In][Out] ref UINT pNumSubresourceTilings, [In] UINT FirstSubresourceTilingToGet,
            [Out] D3D12_SUBRESOURCE_TILING[] pSubresourceTilingsForNonPackedMips)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_SUBRESOURCE_TILING* pSubresourceTilingsForNonPackedMipsPtr = pSubresourceTilingsForNonPackedMips)
                {
                    ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, out UINT, out D3D12_PACKED_MIP_INFO,
                        out D3D12_TILE_SHAPE, ref UINT, UINT, D3D12_SUBRESOURCE_TILING*, void>)_vTable[42])
                        (thisPtr, pTiledResource, out pNumTilesForEntireResource, out pPackedMipDesc,
                        out pStandardTileShapeForNonPackedMips, ref pNumSubresourceTilings,
                        FirstSubresourceTilingToGet, pSubresourceTilingsForNonPackedMipsPtr);
                }
            }
        }

        /// <summary>
        /// Gets a locally unique identifier for the current device (adapter).
        /// </summary>
        /// <returns>
        /// The locally unique identifier for the adapter.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method returns a unique identifier for the adapter that is specific to the adapter hardware.
        /// Applications can use this identifier to define robust mappings across various APIs (Direct3D 12, DXGI).
        /// </para>
        /// <para>
        /// A locally unique identifier (LUID) is a 64-bit value
        /// that is guaranteed to be unique only on the system on which it was generated.
        /// The uniqueness of a locally unique identifier (LUID) is guaranteed only until the system is restarted.
        /// </para>
        /// </remarks>
        public LUID GetAdapterLuid()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, LUID>)_vTable[43])(thisPtr);
            }
        }
    }
}
