using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_GPU_PREFERENCE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface enables a single method that enumerates graphics adapters based on a given GPU preference.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nn-dxgi1_6-idxgifactory6"/>
    /// </para>
    /// </summary>
    public unsafe struct IDXGIFactory6
    {
        IntPtr* _vTable;

        /// <summary>
        /// Enumerates graphics adapters based on a given GPU preference.
        /// </summary>
        /// <param name="Adapter">
        /// The index of the adapter to enumerate.
        /// The indices are in order of the preference specified in GpuPreference—for example,
        /// if <see cref="DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE"/> is specified, then the highest-performing adapter is at index 0,
        /// the second-highest is at index 1, and so on.
        /// </param>
        /// <param name="GpuPreference">
        /// The GPU preference for the app.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (GUID) of the <see cref="IDXGIAdapter"/> object referenced by the <paramref name="ppvAdapter"/> parameter.
        /// </param>
        /// <param name="ppvAdapter">
        /// The address of an <see cref="IDXGIAdapter"/> interface pointer to the adapter.
        /// This parameter must not be <see cref="NullRef{IntPtr}"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// This method allows developers to select which GPU they think is most appropriate for each device their app creates and utilizes.
        /// This method is similar to <see cref="IDXGIFactory1.EnumAdapters1"/>, but it accepts a GPU preference to reorder the adapter enumeration.
        /// It returns the appropriate <see cref="IDXGIAdapter"/> for the given GPU preference. 
        /// It is meant to be used in conjunction with the D3DCreateDevice functions, which take in an <see cref="IDXGIAdapter"/>.
        /// When <see cref="DXGI_GPU_PREFERENCE_UNSPECIFIED"/> is specified for the <paramref name="GpuPreference"/> parameter,
        /// this method is equivalent to calling <see cref="IDXGIFactory1.EnumAdapters1"/>.
        /// When <see cref="DXGI_GPU_PREFERENCE_MINIMUM_POWER"/> is specified for the <paramref name="GpuPreference"/> parameter,
        /// the order of preference for the adapter returned in <paramref name="ppvAdapter"/> will be:
        /// 1. iGPUs (integrated GPUs)
        /// 2. dGPUs(discrete GPUs)
        /// 3. xGPUs(external GPUs)
        /// When <see cref="DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE"/> is specified for the <paramref name="GpuPreference"/> parameter,
        /// the order of preference for the adapter returned in <paramref name="ppvAdapter"/> will be:
        /// 1. xGPUs
        /// 2. dGPUs
        /// 3. iGPUs
        /// </remarks>
        public HRESULT EnumAdapterByGpuPreference([In] UINT Adapter, [In] DXGI_GPU_PREFERENCE GpuPreference, [In] in IID riid, [Out] out IntPtr ppvAdapter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, DXGI_GPU_PREFERENCE, in IID, out IntPtr, HRESULT>)_vTable[29])
                    (thisPtr, Adapter, GpuPreference, riid, out ppvAdapter);
            }
        }
    }
}
