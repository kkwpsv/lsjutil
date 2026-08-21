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
    /// Manages a pipeline library.
    /// This interface extends <see cref="ID3D12PipelineLibrary"/> to load PSOs from a pipeline state stream description.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12pipelinelibrary1"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "80eabf42-2568-4e5e-bd82-c37f86961dc3", BeginVTableSlotIndex = 13, EndVTableSlotIndex = 13,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12PipelineLibrary)])]
    public unsafe struct ID3D12PipelineLibrary1
    {
        nint* _vTable;

        /// <summary>
        /// Retrieves the requested PSO from the library.
        /// The pipeline stream description is matched against the library database,
        /// and remembered in order to prevent duplication of PSO contents.
        /// </summary>
        /// <param name="pName">
        /// The unique name of the PSO.
        /// </param>
        /// <param name="pDesc">
        /// Describes the required PSO using a <see cref="D3D12_PIPELINE_STATE_STREAM_DESC"/> structure.
        /// This description is matched against the library database, and stored in order to prevent duplication of PSO contents.
        /// </param>
        /// <param name="riid">
        /// <para>
        /// Specifies a REFIID for the <see cref="ID3D12PipelineState"/> object.
        /// </para>
        /// <para>
        /// Your app should typically set this argument and the following argument, <paramref name="ppPipelineState"/>,
        /// by using the macro <c>IID_PPV_ARGS(&amp;PSO1)</c>, where <c>PSO1</c> is the name of the object.
        /// </para>
        /// </param>
        /// <param name="ppPipelineState">
        /// Specifies the pointer that will reference the PSO after the function successfully returns.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code,
        /// which can include <see cref="E_INVALIDARG"/> if the name doesn't exist
        /// or the stream description doesn't match the data in the library,
        /// and <see cref="E_OUTOFMEMORY"/> if the function is unable to allocate the resulting PSO.
        /// </returns>
        /// <remarks>
        /// This function takes the pipeline description as a <see cref="D3D12_PIPELINE_STATE_STREAM_DESC"/>
        /// and is a replacement for the <see cref="ID3D12PipelineLibrary.LoadGraphicsPipeline"/>
        /// and <see cref="ID3D12PipelineLibrary.LoadComputePipeline"/> functions,
        /// which take their pipeline description as the less-flexible <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/>
        /// and <see cref="D3D12_COMPUTE_PIPELINE_STATE_DESC"/> structs, respectively.
        /// </remarks>
        public HRESULT LoadPipeline([In] LPCWSTR pName, [In] in D3D12_PIPELINE_STATE_STREAM_DESC pDesc,
            [In] in IID riid, [Out] out nint ppPipelineState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, nint, in D3D12_PIPELINE_STATE_STREAM_DESC,
                    in IID, out nint, HRESULT>)_vTable[13])(thisPtr, pName.ToNint(), pDesc, riid, out ppPipelineState);
            }
        }
    }
}
