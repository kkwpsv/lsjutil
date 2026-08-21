using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_CPU_PAGE_PROPERTY;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_HEAP_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_STATES;
using static Lsj.Util.Win32.Enums.MemoryProtectionConstants;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Encapsulates a generalized ability of the CPU and GPU to read and write to physical memory, or heaps.
    /// It contains abstractions for organizing and manipulating simple arrays of data
    /// as well as multidimensional data optimized for shader sampling.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12resource"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "696442be-a72e-4059-bc79-5b5c98040fad", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 14,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild), typeof(ID3D12Pageable)])]
    public unsafe struct ID3D12Resource
    {
        nint* _vTable;

        /// <summary>
        /// Gets a CPU pointer to the specified subresource in the resource,
        /// but may not disclose the pointer value to applications.
        /// <see cref="Map"/> also invalidates the CPU cache, when necessary,
        /// so that CPU reads to this address reflect any modifications made by the GPU.
        /// </summary>
        /// <param name="Subresource">
        /// Specifies the index number of the subresource.
        /// </param>
        /// <param name="pReadRange">
        /// <para>
        /// A pointer to a <see cref="D3D12_RANGE"/> structure that describes the range of memory to access.
        /// </para>
        /// <para>
        /// This indicates the region the CPU might read, and the coordinates are subresource-relative.
        /// A null pointer indicates the entire subresource might be read by the CPU.
        /// It is valid to specify the CPU won't read any data by passing a range
        /// where <see cref="D3D12_RANGE.End"/> is less than or equal to <see cref="D3D12_RANGE.Begin"/>.
        /// </para>
        /// </param>
        /// <param name="ppData">
        /// <para>
        /// A pointer to a memory block that receives a pointer to the resource data.
        /// </para>
        /// <para>
        /// A null pointer is valid and is useful to cache a CPU virtual address range for methods like <see cref="WriteToSubresource"/>.
        /// When <paramref name="ppData"/> is not <see cref="NullRef{nint}"/>,
        /// the pointer returned is never offset by any values in <paramref name="pReadRange"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="Map"/> and <see cref="Unmap"/> can be called by multiple threads safely.
        /// Nested <see cref="Map"/> calls are supported and are ref-counted.
        /// The first call to <see cref="Map"/> allocates a CPU virtual address range for the resource.
        /// The last call to <see cref="Unmap"/> deallocates the CPU virtual address range.
        /// The CPU virtual address is commonly returned to the application;
        /// but manipulating the contents of textures with unknown layouts precludes disclosing the CPU virtual address.
        /// See <see cref="WriteToSubresource"/> for more details.
        /// Applications cannot rely on the address being consistent, unless <see cref="Map"/> is persistently nested.
        /// </para>
        /// <para>
        /// Pointers returned by <see cref="Map"/> are not guaranteed to have all the capabilities of normal pointers,
        /// but most applications won't notice a difference in normal usage.
        /// For example, pointers with WRITE_COMBINE behavior have weaker CPU memory ordering guarantees than WRITE_BACK behavior.
        /// Memory accessible by both CPU and GPU are not guaranteed to share the same atomic memory guarantees
        /// that the CPU has, due to PCIe limitations.
        /// Use fences for synchronization.
        /// </para>
        /// <para>
        /// There are two usage model categories for <see cref="Map"/>, simple and advanced.
        /// The simple usage models maximize tool performance, so applications are recommended to stick with the simple models
        /// until the advanced models are proven to be required by the app.
        /// </para>
        /// <para>
        /// Simple Usage Models
        /// </para>
        /// <para>
        /// Applications should stick to the heap type abstractions of UPLOAD, DEFAULT, and READBACK,
        /// in order to support all adapter architectures reasonably well.
        /// </para>
        /// <para>
        /// Applications should avoid CPU reads from pointers to resources on UPLOAD heaps, even accidently.
        /// CPU reads will work, but are prohibitively slow on many common GPU architectures, so consider the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Don't make the CPU read from resources associated with heaps
        /// that are <see cref="D3D12_HEAP_TYPE_UPLOAD"/> or have <see cref="D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The memory region to which <c>pData</c> points can be allocated with <see cref="PAGE_WRITECOMBINE"/>,
        /// and your app must honor all restrictions that are associated with such memory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
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
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Use the appropriate optimization settings and language constructs to help avoid this performance penalty.
        /// For example, you can avoid the xor optimization
        /// by using a <c>volatile</c> pointer or by optimizing for code speed instead of code size.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Applications are encouraged to leave resources unmapped while the CPU will not modify them,
        /// and use tight, accurate ranges at all times.
        /// This enables the fastest modes for tools, like Graphics Debugging and the debug layer.
        /// Such tools need to track all CPU modifications to memory that the GPU could read.
        /// </para>
        /// <para>
        /// Advanced Usage Models
        /// </para>
        /// <para>
        /// Resources on CPU-accessible heaps can be persistently mapped, meaning <see cref="Map"/> can be called once,
        /// immediately after resource creation. <see cref="Unmap"/> never needs to be called,
        /// but the address returned from <see cref="Map"/> must no longer be used after the last reference to the resource is released.
        /// When using persistent map, the application must ensure the CPU finishes writing data into memory
        /// before the GPU executes a command list that reads or writes the memory.
        /// In common scenarios, the application merely must write to memory
        /// before calling <see cref="ID3D12CommandQueue.ExecuteCommandLists"/>;
        /// but using a fence to delay command list execution works as well.
        /// </para>
        /// <para>
        /// All CPU-accessible memory types support persistent mapping usage,
        /// where the resource is mapped but then never unmapped,
        /// provided the application does not access the pointer after the resource has been disposed.
        /// </para>
        /// </remarks>
        public HRESULT Map([In] UINT Subresource, [In] in D3D12_RANGE pReadRange, [Out] out nint ppData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, in D3D12_RANGE, out nint, HRESULT>)_vTable[8])
                    (thisPtr, Subresource, pReadRange, out ppData);
            }
        }

        /// <summary>
        /// Invalidates the CPU pointer to the specified subresource in the resource.
        /// </summary>
        /// <param name="Subresource">
        /// Specifies the index of the subresource.
        /// </param>
        /// <param name="pWrittenRange">
        /// <para>
        /// A pointer to a <see cref="D3D12_RANGE"/> structure that describes the range of memory to unmap.
        /// </para>
        /// <para>
        /// This indicates the region the CPU might have modified, and the coordinates are subresource-relative.
        /// A null pointer indicates the entire subresource might have been modified by the CPU.
        /// It is valid to specify the CPU didn't write any data by passing a range
        /// where <see cref="D3D12_RANGE.End"/> is less than or equal to <see cref="D3D12_RANGE.Begin"/>.
        /// </para>
        /// <para>
        /// This parameter is only used by tooling, and not for correctness of the actual unmap operation.
        /// </para>
        /// </param>
        /// <remarks>
        /// Refer to the extensive Remarks and Examples for the <see cref="Map"/> method.
        /// </remarks>
        public void Unmap([In] UINT Subresource, [In] in D3D12_RANGE pWrittenRange)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, in D3D12_RANGE, void>)_vTable[9])(thisPtr, Subresource, pWrittenRange);
            }
        }

        /// <summary>
        /// Gets the resource description.
        /// </summary>
        /// <returns>
        /// A Direct3D 12 resource description structure.
        /// </returns>
        public D3D12_RESOURCE_DESC GetDesc()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_RESOURCE_DESC>)_vTable[10])(thisPtr);
            }
        }

        /// <summary>
        /// This method returns the GPU virtual address of a buffer resource.
        /// </summary>
        /// <returns>
        /// This method returns the GPU virtual address.
        /// <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> is a typedef'd synonym of <see cref="UINT64"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method is only useful for buffer resources, it will return zero for all texture resources.
        /// </para>
        /// <para>
        /// For more information on the use of GPU virtual addresses, refer to Indirect Drawing.
        /// </para>
        /// </remarks>
        public D3D12_GPU_VIRTUAL_ADDRESS GetGPUVirtualAddress()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_GPU_VIRTUAL_ADDRESS>)_vTable[11])(thisPtr);
            }
        }

        /// <summary>
        /// <para>
        /// Uses the CPU to copy data into a subresource, enabling the CPU to modify the contents of most textures with undefined layouts.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-writetosubresource"/>
        /// </para>
        /// </summary>
        /// <param name="DstSubresource">
        /// Specifies the index of the subresource.
        /// </param>
        /// <param name="pDstBox">
        /// <para>
        /// A pointer to a box that defines the portion of the destination subresource to copy the resource data into.
        /// If NULL, the data is written to the destination subresource with no offset.
        /// The dimensions of the source must fit the destination (see <see cref="D3D12_BOX"/>).
        /// </para>
        /// <para>
        /// An empty box results in a no-op.
        /// A box is empty if the top value is greater than or equal to the bottom value,
        /// or the left value is greater than or equal to the right value,
        /// or the front value is greater than or equal to the back value.
        /// When the box is empty, this method doesn't perform any operation.
        /// </para>
        /// </param>
        /// <param name="pSrcData">
        /// A pointer to the source data in memory.
        /// </param>
        /// <param name="SrcRowPitch">
        /// The distance from one row of source data to the next row.
        /// </param>
        /// <param name="SrcDepthPitch">
        /// The distance from one depth slice of source data to the next.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The resource should first be mapped using <see cref="Map"/>.
        /// Textures must be in the <see cref="D3D12_RESOURCE_STATE_COMMON"/> state for CPU access
        /// through <see cref="WriteToSubresource"/> and <see cref="ReadFromSubresource"/> to be legal; but buffers do not.
        /// </para>
        /// <para>
        /// For efficiency, ensure the bounds and alignment of the extents
        /// within the box are ( 64 / [bytes per pixel] ) pixels horizontally.
        /// Vertical bounds and alignment should be 2 rows,
        /// except when 1-byte-per-pixel formats are used, in which case 4 rows are recommended.
        /// Single depth slices per call are handled efficiently.
        /// It is recommended but not necessary to provide pointers and strides which are 128-byte aligned.
        /// </para>
        /// <para>
        /// When writing to sub mipmap levels, it is recommended to use larger width and heights than described above.
        /// This is because small mipmap levels may actually be stored within a larger block of memory,
        /// with an opaque amount of offsetting which can interfere with alignment to cache lines.
        /// </para>
        /// <para>
        /// <see cref="WriteToSubresource"/> and <see cref="ReadFromSubresource"/> enable near zero-copy optimizations for UMA adapters,
        /// but can prohibitively impair the efficiency of discrete/ NUMA adapters as the texture data cannot reside in local video memory.
        /// Typical applications should stick to discrete-friendly upload techniques,
        /// unless they recognize the adapter architecture is UMA.
        /// For more details on uploading, refer to <see cref="ID3D12GraphicsCommandList.CopyTextureRegion"/>,
        /// and for more details on UMA, refer to <see cref="D3D12_FEATURE_DATA_ARCHITECTURE"/>.
        /// </para>
        /// <para>
        /// On UMA systems, this routine can be used to minimize the cost of memory copying through the loop optimization known as loop tiling.
        /// By breaking up the upload into chucks that comfortably fit in the CPU cache,
        /// the effective bandwidth between the CPU and main memory more closely achieves theoretical maximums.
        /// </para>
        /// </remarks>
        public HRESULT WriteToSubresource([In] UINT DstSubresource, [In] in D3D12_BOX pDstBox, [In] nint pSrcData,
            [In] UINT SrcRowPitch, [In] UINT SrcDepthPitch)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, in D3D12_BOX, nint, UINT, UINT, HRESULT>)_vTable[12])
                   (thisPtr, DstSubresource, pDstBox, pSrcData, SrcRowPitch, SrcDepthPitch);
            }
        }

        /// <summary>
        /// Uses the CPU to copy data from a subresource, enabling the CPU to read the contents of most textures with undefined layouts.
        /// </summary>
        /// <param name="pDstData">
        /// A pointer to the destination data in memory.
        /// </param>
        /// <param name="DstRowPitch">
        /// The distance from one row of destination data to the next row.
        /// </param>
        /// <param name="DstDepthPitch">
        /// The distance from one depth slice of destination data to the next.
        /// </param>
        /// <param name="SrcSubresource">
        /// Specifies the index of the subresource to read from.
        /// </param>
        /// <param name="pSrcBox">
        /// <para>
        /// A pointer to a box that defines the portion of the destination subresource to copy the resource data from.
        /// If <see cref="NullRef{D3D12_BOX}"/>, the data is read from the destination subresource with no offset.
        /// The dimensions of the destination must fit the destination (see <see cref="D3D12_BOX"/>).
        /// </para>
        /// <para>
        /// An empty box results in a no-op.
        /// A box is empty if the top value is greater than or equal to the bottom value,
        /// or the left value is greater than or equal to the right value,
        /// or the front value is greater than or equal to the back value.
        /// When the box is empty, this method doesn't perform any operation.
        /// </para>
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// See the Remarks section for <see cref="WriteToSubresource"/>.
        /// </remarks>
        public HRESULT ReadFromSubresource([In] nint pDstData, [In] UINT DstRowPitch, [In] UINT DstDepthPitch,
            [In] UINT SrcSubresource, [In] in D3D12_BOX pSrcBox)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, nint, UINT, UINT, UINT, in D3D12_BOX, HRESULT>)_vTable[13])
                    (thisPtr, pDstData, DstRowPitch, DstDepthPitch, SrcSubresource, pSrcBox);

            }
        }

        /// <summary>
        /// Retrieves the properties of the resource heap, for placed and committed resources.
        /// </summary>
        /// <param name="pHeapProperties">
        /// Pointer to a <see cref="D3D12_HEAP_PROPERTIES"/> structure,
        /// that on successful completion of the method will contain the resource heap properties.
        /// </param>
        /// <param name="pHeapFlags">
        /// Specifies a <see cref="D3D12_HEAP_FLAGS"/> variable,
        /// that on successful completion of the method will contain any miscellaneous heap flags.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// If the resource was created as reserved, <see cref="E_INVALIDARG"/> is returned.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method only works on placed and committed resources, not on reserved resources.
        /// If the resource was created as reserved, <see cref="E_INVALIDARG"/> is returned.
        /// The pages could be mapped to none, one, or more heaps.
        /// </para>
        /// <para>
        /// For more information, refer to Memory Management in Direct3D 12.
        /// </para>
        /// </remarks>
        public HRESULT GetHeapProperties([Out] out D3D12_HEAP_PROPERTIES pHeapProperties, [Out] out D3D12_HEAP_FLAGS pHeapFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3D12_HEAP_PROPERTIES, out D3D12_HEAP_FLAGS, HRESULT>)_vTable[14])
                    (thisPtr, out pHeapProperties, out pHeapFlags);
            }
        }
    }
}
