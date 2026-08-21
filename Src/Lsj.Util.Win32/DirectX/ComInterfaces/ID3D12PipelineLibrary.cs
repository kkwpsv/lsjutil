using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Manages a pipeline library, in particular loading and retrieving individual PSOs.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12pipelinelibrary"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Refer to the remarks and examples for <see cref="ID3D12Device1.CreatePipelineLibrary"/>.
    /// </remarks>
    [ComInterface(IID = "c64226a8-9201-46af-b4cc-53fb9ff7414f", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 12,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild)])]
    public unsafe struct ID3D12PipelineLibrary
    {
        nint* _vTable;

        /// <summary>
        /// Adds the input PSO to an internal database with the corresponding name.
        /// </summary>
        /// <param name="pName">
        /// Specifies a unique name for the library.
        /// Overwriting is not supported.
        /// </param>
        /// <param name="pPipeline">
        /// Specifies the <see cref="ID3D12PipelineState"/> to add.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code,
        /// including <see cref="E_INVALIDARG"/> if the name already exists,
        /// <see cref="E_OUTOFMEMORY"/> if unable to allocate storage in the library.
        /// </returns>
        /// <remarks>
        /// Refer to the remarks and examples for <see cref="ID3D12Device1.CreatePipelineLibrary"/>.
        /// </remarks>
        public HRESULT StorePipeline([In] LPCWSTR pName, [In] P<ID3D12PipelineState> pPipeline)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, nint, P<ID3D12PipelineState>, HRESULT>)_vTable[8])(thisPtr, pName.ToNint(), pPipeline);
            }
        }

        /// <summary>
        /// Retrieves the requested PSO from the library.
        /// </summary>
        /// <param name="pName">
        /// The unique name of the PSO.
        /// </param>
        /// <param name="pDesc">
        /// Specifies a description of the required PSO in a <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> structure.
        /// This input description is matched against the data in the current library database,
        /// and stored in order to prevent duplication of PSO contents.
        /// </param>
        /// <param name="riid">
        /// Specifies a <c>REFIID</c> for the <see cref="ID3D12PipelineState"/> object.
        /// Typically set this, and the following parameter, with the macro <c>IID_PPV_ARGS(&amp;PSO1)</c>,
        /// where <c>PSO1</c> is the name of the object.
        /// </param>
        /// <param name="ppPipelineState">
        /// Specifies a pointer that will reference the returned PSO.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code,
        /// including <see cref="E_INVALIDARG"/> if the name doesn’t exist,
        /// or if the input description doesn’t match the data in the library,
        /// <see cref="E_OUTOFMEMORY"/> if unable to allocate the return PSO.
        /// </returns>
        /// <remarks>
        /// Refer to the remarks and examples for <see cref="ID3D12Device1.CreatePipelineLibrary"/>.
        /// </remarks>
        public HRESULT LoadGraphicsPipeline([In] LPCWSTR pName, [In] in D3D12_GRAPHICS_PIPELINE_STATE_DESC pDesc,
            [In] in IID riid, [Out] out nint     ppPipelineState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, nint, in D3D12_GRAPHICS_PIPELINE_STATE_DESC,
                    in IID, out nint, HRESULT>)_vTable[9])(thisPtr, pName.ToNint(), pDesc, riid, out ppPipelineState);
            }
        }

        /// <summary>
        /// Retrieves the requested PSO from the library.
        /// The input desc is matched against the data in the current library database,
        /// and remembered in order to prevent duplication of PSO contents.
        /// </summary>
        /// <param name="pName">
        /// The unique name of the PSO.
        /// </param>
        /// <param name="pDesc">
        /// Specifies a description of the required PSO in a <see cref="D3D12_COMPUTE_PIPELINE_STATE_DESC"/> structure.
        /// This input description is matched against the data in the current library database,
        /// and stored in order to prevent duplication of PSO contents.
        /// </param>
        /// <param name="riid">
        /// Specifies a <c>REFIID</c> for the <see cref="ID3D12PipelineState"/> object.
        /// Typically set this, and the following parameter, with the macro <c>IID_PPV_ARGS(&amp;PSO1)</c>,
        /// where <c>PSO1</c> is the name of the object.
        /// </param>
        /// <param name="ppPipelineState">
        /// Specifies a pointer that will reference the returned PSO.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code,
        /// including <see cref="E_INVALIDARG"/> if the name doesn’t exist,
        /// or if the input description doesn’t match the data in the library,
        /// <see cref="E_OUTOFMEMORY"/> if unable to allocate the return PSO.
        /// </returns>
        /// <remarks>
        /// Refer to the remarks and examples for <see cref="ID3D12Device1.CreatePipelineLibrary"/>.
        /// </remarks>
        public HRESULT LoadComputePipeline([In] LPCWSTR pName, [In] in D3D12_COMPUTE_PIPELINE_STATE_DESC pDesc,
            [In] in IID riid, [Out] out nint ppPipelineState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, nint, in D3D12_COMPUTE_PIPELINE_STATE_DESC,
                    in IID, out nint, HRESULT>)_vTable[10])(thisPtr, pName.ToNint(), pDesc, riid, out ppPipelineState);
            }
        }

        /// <summary>
        /// Returns the amount of memory required to serialize the current contents of the database.
        /// </summary>
        /// <returns>
        /// This method returns a <see cref="SIZE_T"/> object, containing the size required in bytes.
        /// </returns>
        /// <remarks>
        /// Refer to the remarks and examples for <see cref="ID3D12Device1.CreatePipelineLibrary"/>.
        /// </remarks>
        public SIZE_T GetSerializedSize()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, SIZE_T>)_vTable[11])(thisPtr);
            }
        }

        /// <summary>
        /// Writes the contents of the library to the provided memory, to be provided back to the runtime at a later time.
        /// </summary>
        /// <param name="pData">
        /// Specifies a pointer to the data.
        /// This memory must be readable and writable up to the input size.
        /// This data can be saved and provided to <see cref="ID3D12Device1.CreatePipelineLibrary"/> at a later time,
        /// including future instances of this or other processes.
        /// The data becomes invalidated if the runtime or driver is updated, and is not portable to other hardware or devices.
        /// </param>
        /// <param name="DataSizeInBytes">
        /// The size provided must be at least the size returned from <see cref="GetSerializedSize"/>.
        /// </param>
        /// <returns>
        /// This method returns an HRESULT success or error code,
        /// including <see cref="E_INVALIDARG"/> if the buffer provided isn’t big enough.
        /// </returns>
        /// <remarks>
        /// Refer to the remarks and examples for <see cref="ID3D12Device1.CreatePipelineLibrary"/>.
        /// </remarks>
        public HRESULT Serialize([In] nint pData, [In] SIZE_T DataSizeInBytes)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, nint, SIZE_T, HRESULT>)_vTable[12])(thisPtr, pData, DataSizeInBytes);
            }
        }
    }
}
