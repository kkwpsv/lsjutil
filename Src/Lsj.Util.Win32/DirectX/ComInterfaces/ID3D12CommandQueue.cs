using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_TILE_RANGE_FLAGS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides methods for submitting command lists, synchronizing command list execution,
    /// instrumenting the command queue, and updating resource tile mappings.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12commandqueue"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use <see cref="ID3D12Device.CreateCommandQueue"/> to create a command queue object.
    /// </remarks>
    [ComInterface(IID = "0ec870a6-5d7e-4c22-8cfc-5baae07616ed", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 18,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild), typeof(ID3D12Pageable)])]
    public unsafe struct ID3D12CommandQueue
    {
        nint* _vTable;

        /// <summary>
        /// Updates mappings of tile locations in reserved resources to memory locations in a resource heap.
        /// </summary>
        /// <param name="pResource">
        /// A pointer to the reserved resource.
        /// </param>
        /// <param name="NumResourceRegions">
        /// The number of reserved resource regions.
        /// </param>
        /// <param name="pResourceRegionStartCoordinates">
        /// An array of <see cref="D3D12_TILED_RESOURCE_COORDINATE"/> structures
        /// that describe the starting coordinates of the reserved resource regions.
        /// The <paramref name="NumResourceRegions"/> parameter specifies
        /// the number of <see cref="D3D12_TILED_RESOURCE_COORDINATE"/> structures in the array.
        /// </param>
        /// <param name="pResourceRegionSizes">
        /// An array of <see cref="D3D12_TILE_REGION_SIZE"/> structures that describe the sizes of the reserved resource regions.
        /// The <paramref name="NumResourceRegions"/> parameter specifies
        /// the number of <see cref="D3D12_TILE_REGION_SIZE"/> structures in the array.
        /// </param>
        /// <param name="pHeap">
        /// A pointer to the resource heap.
        /// </param>
        /// <param name="NumRanges">
        /// The number of tile ranges.
        /// </param>
        /// <param name="pRangeFlags">
        /// A pointer to an array of <see cref="D3D12_TILE_RANGE_FLAGS"/> values that describes each tile range.
        /// The <paramref name="NumRanges"/> parameter specifies the number of values in the array.
        /// </param>
        /// <param name="pHeapRangeStartOffsets">
        /// An array of offsets into the resource heap. These are 0-based tile offsets, counting in tiles (not bytes).
        /// </param>
        /// <param name="pRangeTileCounts">
        /// An array of tiles.
        /// An array of values that specify the number of tiles in each tile range. 
        /// The <paramref name="NumRanges"/> parameter specifies the number of values in the array.
        /// </param>
        /// <param name="Flags">
        /// A combination of <see cref="D3D12_TILE_MAPPING_FLAGS"/> values that are combined by using a bitwise OR operation.
        /// </param>
        /// <remarks>
        /// <para>
        /// Use <see cref="UpdateTileMappings"/> to map the virtual pages of a reserved resource to the physical pages of a heap.
        /// The mapping does not have to be in order.
        /// The operation is similar to <see cref="ID3D11DeviceContext2.UpdateTileMappings"/> with the one key difference
        /// that D3D12 allows a reserved resource to have tiles from multiple heaps.
        /// </para>
        /// <para>
        /// In a single call to <see cref="UpdateTileMappings"/>,
        /// you can map one or more ranges of resource tiles to one or more ranges of heap tiles.
        /// </para>
        /// <para>
        /// You can organize the parameters of <see cref="UpdateTileMappings"/> in these ways to perform an update:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Reserved resource whose mappings are updated.
        /// Mappings start off all NULL when a resource is initially created.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Set of tile regions on the reserved resource whose mappings are updated.
        /// You can make one <see cref="UpdateTileMappings"/> call to update many mappings
        /// or multiple calls with a bit more API call overhead as well if that is more convenient.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <paramref name="NumResourceRegions"/> specifies how many regions there are.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="pResourceRegionStartCoordinates"/> and <paramref name="pResourceRegionSizes"/> are each arrays
        /// that identify the start location and extend of each region.
        /// If <paramref name="NumResourceRegions"/> is 1, for convenience either or both of the arrays
        /// that describe the regions can be <see langword="null"/>.
        /// <see langword="null"/> for <paramref name="pResourceRegionStartCoordinates"/> means the start coordinate is all 0s,
        /// and <see langword="null"/> for <paramref name="pResourceRegionSizes"/> identifies a default region
        /// that is the full set of tiles for the entire reserved resource, including all mipmaps, array slices, or both.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <paramref name="pResourceRegionStartCoordinates"/> isn't <see langword="null"/>
        /// and <paramref name="pResourceRegionSizes"/> is <see langword="null"/>,
        /// the region size defaults to 1 tile for all regions
        /// This makes it easy to define mappings for a set of individual tiles each at disparate locations
        /// by providing an array of locations in <paramref name="pResourceRegionStartCoordinates"/>
        /// without having to send an array of <paramref name="pResourceRegionSizes"/> all set to 1.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The updates are applied from first region to last;
        /// so, if regions overlap in a single call,
        /// the updates later in the list overwrite the areas that overlap with previous updates.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Heap that provides memory where tile mappings can go.
        /// If <see cref="UpdateTileMappings"/> only defines <see langword="null"/> mappings, you don't need to specify a heap.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Set of tile ranges where mappings are going.
        /// Each given tile range can specify one of a few types of ranges:
        /// a range of tiles in a heap (default), a count of tiles in the reserved resource
        /// to map to a single tile in a heap (sharing the tile),
        /// a count of tile mappings in the reserved resource to skip and leave as they are,
        /// or a count of tiles in the heap to map to NULL.
        /// <paramref name="NumRanges"/> specifies the number of tile ranges,
        /// where the total tiles identified across all ranges must match the total number of tiles
        /// in the tile regions from the previously described reserved resource.
        /// Mappings are defined by iterating through the tiles in the tile regions
        /// in sequential order - x then y then z order for box regions - while walking through the set of tile ranges in sequential order.
        /// The breakdown of tile regions doesn't have to line up with the breakdown of tile ranges,
        /// but the total number of tiles on both sides must be equal
        /// so that each reserved resource tile specified has a mapping specified.
        /// </para>
        /// <para>
        /// <paramref name="pRangeFlags"/>, <paramref name="pHeapRangeStartOffsets"/>,
        /// and <paramref name="pRangeTileCounts"/> are all arrays, of size <paramref name="NumRanges"/>, that describe the tile ranges.
        /// If <paramref name="pRangeFlags"/> is <see langword="null"/>, all ranges are sequential tiles in the heap;
        /// otherwise, for each range <c>i</c>, <c>pRangeFlags[i]</c> identifies how the mappings in that range of tiles work:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <c>pRangeFlags[i]</c> is <see cref="D3D12_TILE_RANGE_FLAG_NONE"/>,
        /// that range defines sequential tiles in the heap, with the number of tiles being <c>pRangeTileCounts[i]</c>
        /// and the starting location <c>pHeapRangeStartOffsets[i]</c>.
        /// If <paramref name="NumRanges"/> is 1, <paramref name="pRangeTileCounts"/> can be <see langword="null"/>
        /// and defaults to the total number of tiles specified by all the tile regions.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <c>pRangeFlags[i]</c> is <see cref="D3D12_TILE_RANGE_FLAG_REUSE_SINGLE_TILE"/>,
        /// <c>pHeapRangeStartOffsets[i]</c> identifies the single tile in the heap to map to,
        /// and a specifies how many tiles from the tile regions to map to that heap location.
        /// If <paramref name="NumRanges"/> is 1, <paramref name="pRangeTileCounts"/> can be <see langword="null"/>
        /// and defaults to the total number of tiles specified by all the tile regions.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <c>pRangeFlags[i]</c> is <see cref="D3D12_TILE_RANGE_FLAG_NULL"/>,
        /// <c>pRangeTileCounts[i]</c> specifies how many tiles from the tile regions to map to NULL.
        /// If <paramref name="NumRanges"/> is 1, <paramref name="pRangeTileCounts"/> can be <see langword="null"/>
        /// and defaults to the total number of tiles specified by all the tile regions.
        /// <c>pHeapRangeStartOffsets[i]</c> is ignored for NULL mappings.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <c>pRangeFlags[i]</c> is <see cref="D3D12_TILE_RANGE_FLAG_SKIP"/>,
        /// <c>pRangeTileCounts[i]</c> specifies how many tiles from the tile regions
        /// to skip over and leave existing mappings unchanged for.
        /// This can be useful if a tile region conveniently bounds an area of tile mappings
        /// to update except with some exceptions that need to be left the same as whatever they were mapped to before.
        /// <c>pHeapRangeStartOffsets[i]</c> is ignored for SKIP mappings.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Reserved resources must follow the same rules for tile aliasing, initialization,
        /// and data inheritance as placed resources.
        /// See <see cref="ID3D12Device.CreatePlacedResource"/> for more details.
        /// </para>
        /// </remarks>
        public void UpdateTileMappings([In] P<ID3D12Resource> pResource, [In] UINT NumResourceRegions,
            [In] D3D12_TILED_RESOURCE_COORDINATE[]? pResourceRegionStartCoordinates, [In] D3D12_TILE_REGION_SIZE[]? pResourceRegionSizes,
            [In] P<ID3D12Heap> pHeap, [In] UINT NumRanges, [In] D3D12_TILE_RANGE_FLAGS[]? pRangeFlags,
            [In] UINT[] pHeapRangeStartOffsets, [In] UINT[]? pRangeTileCounts, [In] D3D12_TILE_MAPPING_FLAGS Flags)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D12_TILED_RESOURCE_COORDINATE* pResourceRegionStartCoordinatesPtr = pResourceRegionStartCoordinates)
                {
                    fixed (D3D12_TILE_REGION_SIZE* pResourceRegionSizesPtr = pResourceRegionSizes)
                    {
                        fixed (D3D12_TILE_RANGE_FLAGS* pRangeFlagsPtr = pRangeFlags)
                        {
                            fixed (UINT* pHeapRangeStartOffsetsPtr = pHeapRangeStartOffsets)
                            {
                                fixed (UINT* pRangeTileCountsPtr = pRangeTileCounts)
                                {
                                    ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, UINT, D3D12_TILED_RESOURCE_COORDINATE*,
                                        D3D12_TILE_REGION_SIZE*, P<ID3D12Heap>, UINT, D3D12_TILE_RANGE_FLAGS*, UINT*, UINT*,
                                        D3D12_TILE_MAPPING_FLAGS, void>)_vTable[8])
                                        (thisPtr, pResource, NumResourceRegions, pResourceRegionStartCoordinatesPtr, pResourceRegionSizesPtr,
                                        pHeap, NumRanges, pRangeFlagsPtr, pHeapRangeStartOffsetsPtr, pRangeTileCountsPtr, Flags);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Copies mappings from a source reserved resource to a destination reserved resource.
        /// </summary>
        /// <param name="pDstResource">
        /// A pointer to the destination reserved resource.
        /// </param>
        /// <param name="pDstRegionStartCoordinate">
        /// A pointer to a <see cref="D3D12_TILED_RESOURCE_COORDINATE"/> structure
        /// that describes the starting coordinates of the destination reserved resource.
        /// </param>
        /// <param name="pSrcResource">
        /// A pointer to the source reserved resource.
        /// </param>
        /// <param name="pSrcRegionStartCoordinate">
        /// A pointer to a <see cref="D3D12_TILED_RESOURCE_COORDINATE"/> structure
        /// that describes the starting coordinates of the source reserved resource.
        /// </param>
        /// <param name="pRegionSize">
        /// A pointer to a <see cref="D3D12_TILE_REGION_SIZE"/> structure that describes the size of the reserved region.
        /// </param>
        /// <param name="Flags">
        /// One member of <see cref="D3D12_TILE_MAPPING_FLAGS"/>.
        /// </param>
        /// <remarks>
        /// <para>
        /// Use <see cref="CopyTileMappings"/> to copy the tile mappings from one reserved resource to another,
        /// either to duplicate a resource mapping, or to initialize a new mapping
        /// before modifying it using <see cref="UpdateTileMappings"/>.
        /// </para>
        /// <para>
        /// <see cref="CopyTileMappings"/> helps with tasks such as shifting mappings
        /// around within and across reserved resources, for example, scrolling tiles.
        /// The source and destination regions can overlap; the result of the copy in this situation is
        /// as if the source was saved to a temporary location and from there written to the destination.
        /// </para>
        /// <para>
        /// The destination and the source regions must each entirely fit in their resource
        /// or behavior is undefined and the debug layer will emit an error.
        /// </para>
        /// </remarks>
        public void CopyTileMappings([In] P<ID3D12Resource> pDstResource, [In] in D3D12_TILED_RESOURCE_COORDINATE pDstRegionStartCoordinate,
            [In] P<ID3D12Resource> pSrcResource, [In] in D3D12_TILED_RESOURCE_COORDINATE pSrcRegionStartCoordinate,
            [In] in D3D12_TILE_REGION_SIZE pRegionSize, [In] D3D12_TILE_MAPPING_FLAGS Flags)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Resource>, in D3D12_TILED_RESOURCE_COORDINATE, P<ID3D12Resource>,
                    in D3D12_TILED_RESOURCE_COORDINATE, in D3D12_TILE_REGION_SIZE, D3D12_TILE_MAPPING_FLAGS, void>)_vTable[9])
                    (thisPtr, pDstResource, pDstRegionStartCoordinate, pSrcResource, pSrcRegionStartCoordinate, pRegionSize, Flags);
            }
        }

        /// <summary>
        /// Submits an array of command lists for execution.
        /// </summary>
        /// <param name="NumCommandLists">
        /// The number of command lists to be executed.
        /// </param>
        /// <param name="ppCommandLists">
        /// The array of <see cref="ID3D12CommandList"/> command lists to be executed.
        /// </param>
        /// <remarks>
        /// <para>
        /// Calling <see cref="ExecuteCommandLists"/> twice in succession (from the same thread, or different threads) 
        /// guarantees that the first workload (A) finishes before the second workload (B).
        /// Calling <see cref="ExecuteCommandLists"/> with two command lists allows the driver to merge the two command lists
        /// such that the second command list (D) may begin executing work before all work from the first (C) has finished.
        /// Specifically, your application is allowed to insert a fence signal or wait between A and B,
        /// and the driver has no visibility into this,
        /// so the driver must ensure that everything in A is complete before the fence operation.
        /// There is no such opportunity in a single call to the API, so the driver is able to optimize that scenario.
        /// </para>
        /// <para>
        /// The driver is free to patch the submitted command lists.
        /// It is the calling application’s responsibility to ensure that the graphics processing unit (GPU)
        /// is not currently reading the any of the submitted command lists from a previous execution.
        /// </para>
        /// <para>
        /// Applications are encouraged to batch together command list executions
        /// to reduce fixed costs associated with submitted commands to the GPU.
        /// </para>
        /// <para>
        /// Runtime validation
        /// </para>
        /// <para>
        /// Bundles can't be submitted to a command queue directly.
        /// If a bundle is passed to this method, the runtime will drop the call.
        /// The runtime will also drop the call
        /// if the <see cref="ID3D12GraphicsCommandList.Close"/> function has not been called on one or more of the command lists.
        /// </para>
        /// <para>
        /// The runtime will detect if the command allocators associated with the command lists
        /// have been reset after <see cref="ID3D12GraphicsCommandList.Close"/> was called.
        /// The runtime will drop the call and remove the device in this situation.
        /// </para>
        /// <para>
        /// The runtime will drop the call and remove the device
        /// if the command queue fence indicates that a previous execution of any of the command lists has not yet completed.
        /// </para>
        /// <para>
        /// The runtime will validate the "before" and "after" states
        /// of resource transition barriers inside of <see cref="ExecuteCommandLists"/>.
        /// If the “before” state of a transition does not match up with the “after” state of a previous transition,
        /// then the runtime will drop the call and remove the device.
        /// </para>
        /// <para>
        /// The runtime will validate the “before” and “after” states of queries used by the command lists.
        /// If an error is detected, then the runtime will drop the call and remove the device.
        /// </para>
        /// <para>
        /// Debug layer
        /// </para>
        /// <para>
        /// The debug layer issues errors for all cases where the runtime would drop the call.
        /// </para>
        /// <para>
        /// The debug layer issues an error if it detects that any resource referenced by the command lists,
        /// including queries, has been destroyed.
        /// </para>
        /// </remarks>
        public void ExecuteCommandLists([In] UINT NumCommandLists, [In] P<ID3D12CommandList>[] ppCommandLists)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (P<ID3D12CommandList>* ppCommandListsPtr = ppCommandLists)
                {
                    ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D12CommandList>*, void>)_vTable[10])(thisPtr, NumCommandLists, ppCommandListsPtr);
                }
            }
        }

        /// <summary>
        /// Not intended to be called directly.
        /// Use the PIX event runtime to insert events into a command queue.
        /// </summary>
        /// <param name="Metadata">
        /// nternal.
        /// </param>
        /// <param name="pData">
        /// nternal.
        /// </param>
        /// <param name="Size">
        /// nternal.
        /// </param>
        /// <remarks>
        /// <para>
        /// This is a support method used internally by the PIX event runtime.
        /// It is not intended to be called directly.
        /// </para>
        /// <para>
        /// To insert instrumentation markers at the current location within a D3D12 command queue,
        /// use the <c>PIXSetMarker</c> function.
        /// This is provided by the <c>WinPixEventRuntime</c> NuGet package.
        /// </para>
        /// </remarks>
        public void SetMarker([In] UINT Metadata, [In] byte[] pData, [In] UINT Size)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (byte* pDataPtr = pData)
                {
                    ((delegate* unmanaged[Stdcall]<void*, UINT, byte*, UINT, void>)_vTable[11])(thisPtr, Metadata, pDataPtr, Size);
                }
            }
        }

        /// <summary>
        /// Not intended to be called directly.
        /// Use the PIX event runtime to insert events into a command queue.
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
        /// To mark the start of an instrumentation region at the current location within a D3D12 command queue,
        /// use the <c>PIXBeginEvent</c> function or <c>PIXScopedEvent</c> macro.
        /// These are provided by the <c>WinPixEventRuntime</c> NuGet package.
        /// </para>
        /// </remarks>
        public void BeginEvent([In] UINT Metadata, [In] byte[] pData, [In] UINT Size)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (byte* pDataPtr = pData)
                {
                    ((delegate* unmanaged[Stdcall]<void*, UINT, byte*, UINT, void>)_vTable[12])(thisPtr, Metadata, pDataPtr, Size);
                }
            }
        }

        /// <summary>
        /// Not intended to be called directly.  Use the PIX event runtime to insert events into a command queue.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is a support method used internally by the PIX event runtime.
        /// It is not intended to be called directly.
        /// </para>
        /// <para>
        /// To mark the start of an instrumentation region at the current location within a D3D12 command queue,
        /// use the <c>PIXEndEvent</c> function or <c>PIXScopedEvent</c> macro.
        /// These are provided by the <c>WinPixEventRuntime</c> NuGet package.
        /// </para>
        /// </remarks>
        public void EndEvent()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[13])(thisPtr);
            }
        }

        /// <summary>
        /// Updates a fence to a specified value.
        /// </summary>
        /// <param name="pFence">
        /// A pointer to the <see cref="ID3D12Fence"/> object.
        /// </param>
        /// <param name="Value">
        /// The value to set the fence to.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// Use this method to set a fence value from the GPU side.
        /// Use <see cref="ID3D12Fence.Signal"/> to set a fence from the CPU side.
        /// </remarks>
        public HRESULT Signal([In] P<ID3D12Fence> pFence, [In] UINT64 Value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Fence>, UINT64, HRESULT>)_vTable[14])(thisPtr, pFence, Value);
            }
        }

        /// <summary>
        /// Queues a GPU-side wait, and returns immediately.
        /// A GPU-side wait is where the GPU waits until the specified fence reaches or exceeds the specified value.
        /// </summary>
        /// <param name="pFence">
        /// A pointer to the <see cref="ID3D12Fence"/> object.
        /// </param>
        /// <param name="Value">
        /// The value that the command queue is waiting for the fence to reach or exceed.
        /// So when <see cref="ID3D12Fence.GetCompletedValue"/> is greater than or equal to <paramref name="Value"/>, the wait is terminated.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Because a wait is being queued, the API returns immediately.
        /// It's the command queue that waits (during which time no work is executed)
        /// until the fence specified reaches the requested value.
        /// </para>
        /// <para>
        /// If you want to perform a CPU-side wait (where the calling thread blocks until a fence reaches a particular value),
        /// then you should use the <see cref="ID3D12Fence.SetEventOnCompletion"/> API
        /// in conjunction with <see cref="WaitForSingleObject"/> (or a similar API).
        /// </para>
        /// </remarks>
        public HRESULT Wait([In] P<ID3D12Fence> pFence, [In] UINT64 Value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Fence>, UINT64, HRESULT>)_vTable[15])(thisPtr, pFence, Value);
            }
        }

        /// <summary>
        /// This method is used to determine the rate at which the GPU timestamp counter increments.
        /// </summary>
        /// <param name="pFrequency">
        /// The GPU timestamp counter frequency (in ticks/second).
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// For more information, refer to Timing.
        /// </remarks>
        public HRESULT GetTimestampFrequency(out UINT64 pFrequency)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT64, HRESULT>)_vTable[16])(thisPtr, out pFrequency);
            }
        }

        /// <summary>
        /// This method samples the CPU and GPU timestamp counters at the same moment in time.
        /// </summary>
        /// <param name="pGpuTimestamp">
        /// The value of the GPU timestamp counter.
        /// </param>
        /// <param name="pCpuTimestamp">
        /// The value of the CPU timestamp counter.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// For more information, refer to Timing.
        /// </remarks>
        public HRESULT GetClockCalibration(out UINT64 pGpuTimestamp, out UINT64 pCpuTimestamp)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT64, out UINT64, HRESULT>)_vTable[17])(thisPtr, out pGpuTimestamp, out pCpuTimestamp);
            }
        }

        /// <summary>
        /// Gets the description of the command queue.
        /// </summary>
        /// <returns>
        /// The description of the command queue, as a <see cref="D3D12_COMMAND_QUEUE_DESC"/> structure.
        /// </returns>
        public D3D12_COMMAND_QUEUE_DESC GetDesc()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_COMMAND_QUEUE_DESC>)_vTable[18])(thisPtr);
            }
        }
    }
}
