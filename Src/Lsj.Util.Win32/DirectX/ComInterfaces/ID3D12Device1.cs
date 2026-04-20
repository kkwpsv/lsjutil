using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.D3D12;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FEATURE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_SHADER_CACHE_SUPPORT_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a virtual adapter, and expands on the range of methods provided by <see cref="ID3D12Device"/>.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This interface was introduced in Windows 10 Anniversary Update.
    /// Applications targetting Windows 10 Anniversary Update should use this interface instead of earlier or later versions.
    /// Applications targetting an earlier or later version of Windows 10
    /// should use the appropriate version of the <see cref="ID3D12Device"/> interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12device1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use <see cref="D3D12CreateDevice"/> to create a device.
    /// </remarks>
    [ComInterface(IID = "77acce80-638e-4e65-8895-c1f23386863e", BeginVTableSlotIndex = 44, EndVTableSlotIndex = 46,
       InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12Device)])]
    public unsafe struct ID3D12Device1
    {
        IntPtr* _vTable;

        /// <summary>
        /// <para>
        /// Creates a cached pipeline library.
        /// For pipeline state objects (PSOs) that are expected to share data together,
        /// grouping them into a library before serializing them means that there's less overhead due to metadata,
        /// as well as the opportunity to avoid redundant or duplicated data being written to disk.
        /// </para>
        /// <para>
        /// You can query for <see cref="ID3D12PipelineLibrary"/> support with <see cref="ID3D12Device.CheckFeatureSupport"/>,
        /// with <see cref="D3D12_FEATURE_SHADER_CACHE"/> and <see cref="D3D12_FEATURE_DATA_SHADER_CACHE"/>.
        /// If the <see cref="D3D12_FEATURE_DATA_SHADER_CACHE.SupportFlags"/> member of <see cref="D3D12_FEATURE_DATA_SHADER_CACHE"/>
        /// contains the flag <see cref="D3D12_SHADER_CACHE_SUPPORT_LIBRARY"/>, the <see cref="ID3D12PipelineLibrary"/> interface is supported.
        /// If not, then <see cref="DXGI_ERROR_UNSUPPORTED"/> will always be returned when this function is called.
        /// </para>
        /// </summary>
        /// <param name="pLibraryBlob">
        /// If the input library blob is empty, then the initial content of the library is empty.
        /// If the input library blob is not empty, then it is validated for integrity, parsed, and the pointer is stored.
        /// The pointer provided as input to this method must remain valid for the lifetime of the object returned.
        /// For efficiency reasons, the data is not copied.
        /// </param>
        /// <param name="BlobLength">
        /// Specifies the length of <paramref name="pLibraryBlob"/> in bytes.
        /// </param>
        /// <param name="riid">
        /// Specifies a unique <c>REFIID</c> for the <see cref="ID3D12PipelineLibrary"/> object.
        /// Typically set this and the following parameter with the macro <c>IID_PPV_ARGS(&amp;Library)</c>,
        /// where <c>Library</c> is the name of the object.
        /// </param>
        /// <param name="ppPipelineLibrary">
        /// Returns a pointer to the created library.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code,
        /// including <see cref="E_INVALIDARG"/> if the blob is corrupted or unrecognized,
        /// <see cref="D3D12_ERROR_DRIVER_VERSION_MISMATCH"/> if the provided data came from an old driver or runtime,
        /// and <see cref="D3D12_ERROR_ADAPTER_NOT_FOUND"/> if the data came from different hardware.
        /// </para>
        /// <para>
        /// If you pass <see cref="NULL"/> for <paramref name="pLibraryBlob"/>
        /// then the runtime still performs the validation of the blob but avoid creating the actual library
        /// and returns <see cref="S_FALSE"/> if the library would have been created.
        /// </para>
        /// <para>
        /// Also, the feature requires an updated driver,
        /// and attempting to use it on old drivers will return <see cref="DXGI_ERROR_UNSUPPORTED"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A pipeline library enables the following operations.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Adding pipeline state objects (PSOs) to an existing library object
        /// (refer to <see cref="ID3D12PipelineLibrary.StorePipeline"/>).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Serializing a PSO library into a contiguous block of memory for disk storage
        /// (refer to <see cref="ID3D12PipelineLibrary.Serialize"/>).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// De-serializing a PSO library from persistent storage (this is handled by <see cref="CreatePipelineLibrary"/>).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Retrieving individual PSOs from the library
        /// (refer to <see cref="ID3D12PipelineLibrary.LoadComputePipeline"/> and <see cref="ID3D12PipelineLibrary.LoadGraphicsPipeline"/>).
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// At no point in the lifecycle of a pipeline library is there duplication between PSOs with identical sub-components.
        /// </para>
        /// <para>
        /// A recommended solution for managing the lifetime of the provided pointer
        /// while only having to ref-count the returned interface is to leverage <see cref="ID3D12Object.SetPrivateDataInterface"/>,
        /// and use an object which implements <see cref="IUnknown"/>, and frees the memory when the ref-count reaches 0.
        /// </para>
        /// <para>
        /// Thread Safety
        /// </para>
        /// <para>
        /// The pipeline library is thread-safe to use, and will internally synchronize as necessary,
        /// with one exception: multiple threads loading the same PSO (via <see cref="ID3D12PipelineLibrary.LoadComputePipeline"/>,
        /// <see cref="ID3D12PipelineLibrary.LoadGraphicsPipeline"/>, or <see cref="ID3D12PipelineLibrary1.LoadPipeline"/>)
        /// should synchronize themselves, as this act may modify the state of that pipeline within the library in a non-thread-safe manner.
        /// </para>
        /// </remarks>
        public HRESULT CreatePipelineLibrary([In] IntPtr pLibraryBlob, [In] SIZE_T BlobLength,
            [In] in IID riid, [Out] out IntPtr ppPipelineLibrary)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, SIZE_T, in IID, out IntPtr, HRESULT>)_vTable[44])
                    (thisPtr, pLibraryBlob, BlobLength, riid, out ppPipelineLibrary);
            }
        }

        /// <summary>
        /// Specifies an event that should be fired when one or more of a collection of fences reach specific values.
        /// </summary>
        /// <param name="ppFences">
        /// An array of length <paramref name="NumFences"/> that specifies the <see cref="ID3D12Fence"/> objects.
        /// </param>
        /// <param name="pFenceValues">
        /// An array of length <paramref name="NumFences"/> that specifies the fence values required for the event is to be signaled.
        /// </param>
        /// <param name="NumFences">
        /// Specifies the number of fences to be included.
        /// </param>
        /// <param name="Flags">
        /// Specifies one of the <see cref="D3D12_MULTIPLE_FENCE_WAIT_FLAGS"/> that determines how to proceed.
        /// </param>
        /// <param name="hEvent">
        /// A handle to the event object.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To specify a single fence refer to the <see cref="ID3D12Fence.SetEventOnCompletion"/> method.
        /// </para>
        /// <para>
        /// If <paramref name="hEvent"/> is a null handle,
        /// then this API will not return until the specified fence value(s) have been reached.
        /// </para>
        /// </remarks>
        public HRESULT SetEventOnMultipleFenceCompletion([In] P<ID3D12Fence>[] ppFences, [In] UINT64[] pFenceValues,
            [In] UINT NumFences, [In] D3D12_MULTIPLE_FENCE_WAIT_FLAGS Flags, [In] HANDLE hEvent)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (P<ID3D12Fence>* ppFencesPtr = ppFences)
                {
                    fixed (UINT64* pFenceValuesPtr = pFenceValues)
                    {
                        return ((delegate* unmanaged[Stdcall]<void*, P<ID3D12Fence>*, UINT64*, UINT, D3D12_MULTIPLE_FENCE_WAIT_FLAGS, HANDLE, HRESULT>)_vTable[45])
                            (thisPtr, ppFencesPtr, pFenceValuesPtr, NumFences, Flags, hEvent);
                    }
                }
            }
        }

        /// <summary>
        /// This method sets residency priorities of a specified list of objects.
        /// </summary>
        /// <param name="NumObjects">
        /// Specifies the number of objects in the <paramref name="ppObjects"/> and <paramref name="pPriorities"/> arrays.
        /// </param>
        /// <param name="ppObjects">
        /// Specifies an array, of length <paramref name="NumObjects"/>, containing references to <see cref="ID3D12Pageable"/> objects.
        /// </param>
        /// <param name="pPriorities">
        /// Specifies an array, of length <paramref name="NumObjects"/>,
        /// of <see cref="D3D12_RESIDENCY_PRIORITY"/> values for the list of objects.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code.
        /// </returns>
        /// <remarks>
        /// For more information, refer to Residency.
        /// </remarks>
        public HRESULT SetResidencyPriority([In] UINT NumObjects, [In] P<ID3D12Pageable>[] ppObjects, [In] D3D12_RESIDENCY_PRIORITY[] pPriorities)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (P<ID3D12Pageable>* ppObjectsPtr = ppObjects)
                {
                    fixed (D3D12_RESIDENCY_PRIORITY* pPrioritiesPtr = pPriorities)
                    {
                        return ((delegate* unmanaged[Stdcall]<void*, UINT, P<ID3D12Pageable>*, D3D12_RESIDENCY_PRIORITY*, HRESULT>)_vTable[46])
                            (thisPtr, NumObjects, ppObjectsPtr, pPrioritiesPtr);
                    }
                }
            }
        }
    }
}
