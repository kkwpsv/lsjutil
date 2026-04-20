using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_ERROR;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Stores a pipeline state.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_cached_pipeline_state"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by the <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> structure,
    /// and the <see cref="D3D12_COMPUTE_PIPELINE_STATE_DESC"/> structure.
    /// </para>
    /// <para>
    /// This structure is intended to be filled with the data retrieved from <see cref="ID3D12PipelineState.GetCachedBlob"/>.
    /// This cached PSO contains data specific to the hardware, driver, and machine that it was retrieved from.
    /// Compilation using this data should be faster than compilation without.
    /// The rest of the data in the PSO needs to still be valid,
    /// and needs to match the cached PSO, otherwise <see cref="E_INVALIDARG"/> might be returned.
    /// </para>
    /// <para>
    /// If the driver has been upgraded to a D3D12 driver after the PSO was cached, 
    /// you might see a <see cref="D3D12_ERROR_DRIVER_VERSION_MISMATCH"/> return code,
    /// or if you’re running on a different GPU, the <see cref="D3D12_ERROR_ADAPTER_NOT_FOUND"/> return code.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_CACHED_PIPELINE_STATE
    {
        /// <summary>
        /// Specifies pointer that references the memory location of the cache.
        /// </summary>
        public IntPtr pCachedBlob;

        /// <summary>
        /// Specifies the size of the cache in bytes.
        /// </summary>
        public SIZE_T CachedBlobSizeInBytes;
    }
}
