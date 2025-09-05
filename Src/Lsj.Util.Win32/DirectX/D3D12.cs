using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.DXGI;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// D3D12.dll
    /// </summary>
    public static class D3D12
    {
        /// <summary>
        /// <para>
        /// Creates a device that represents the display adapter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12createdevice"/>
        /// </para>
        /// </summary>
        /// <param name="pAdapter">
        /// <para>
        /// A pointer to the video adapter to use when creating a device.
        /// Pass <see cref="NULL"/> to use the default adapter,
        /// which is the first adapter that is enumerated by <see cref="IDXGIFactory.EnumAdapters"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Do not mix the use of DXGI 1.0 (<see cref="IDXGIFactory"/>) and DXGI 1.1 (<see cref="IDXGIFactory1"/>) in an application.
        /// Use <see cref="IDXGIFactory"/> or <see cref="IDXGIFactory1"/>, but not both in an application.
        /// </para>
        /// </param>
        /// <param name="MinimumFeatureLevel">
        /// The minimum <see cref="D3D_FEATURE_LEVEL"/> required for successful device creation.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (GUID) for the device interface. 
        /// This parameter, and <paramref name="ppDevice"/>, can be addressed with the single macro IID_PPV_ARGS.
        /// </param>
        /// <param name="ppDevice">
        /// A pointer to a memory block that receives a pointer to the device.
        /// Pass <see cref="NullRef{IntPtr}"/> to test if device creation would succeed, but to not actually create the device.
        /// If <see cref="NullRef{IntPtr}"/> is passed and device creation would succeed, <see cref="S_FALSE"/> is returned.
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return one of the Direct3D 12 Return Codes.
        /// </para>
        /// <para>
        /// Possible return values include those documented for <see cref="CreateDXGIFactory1"/> and <see cref="IDXGIFactory.EnumAdapters"/>.
        /// </para>
        /// <para>
        /// If <paramref name="ppDevice"/> is <see cref="NULL"/> and the function succeeds,
        /// <see cref="S_FALSE"/> is returned, rather than <see cref="S_OK"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Direct3D 12 devices are singletons per adapter.
        /// If a Direct3D 12 device already exists in the current process for a given adapter,
        /// then a subsequent call to <see cref="D3D12CreateDevice"/> returns the existing device.
        /// If the current Direct3D 12 device is in a removed state
        /// (that is, <see cref="ID3D12Device.GetDeviceRemovedReason"/> returns a failing <see cref="HRESULT"/>),
        /// then <see cref="D3D12CreateDevice"/> fails instead of returning the existing device.
        /// The sameness of two adapters (that is, they have the same identity) is determined by comparing their LUIDs, not their pointers.
        /// </para>
        /// <para>
        /// In order to be sure to pick up the first adapter that supports D3D12, use the following code.
        /// </para>
        /// <code>
        /// void GetHardwareAdapter(IDXGIFactory4* pFactory, IDXGIAdapter1** ppAdapter)
        /// {
        ///     *ppAdapter = nullptr;
        ///     for (UINT adapterIndex = 0; ; ++adapterIndex)
        ///     {
        ///         IDXGIAdapter1* pAdapter = nullptr;
        ///         if (DXGI_ERROR_NOT_FOUND == pFactory->EnumAdapters1(adapterIndex, &amp;pAdapter))
        ///         {
        ///             // No more adapters to enumerate.
        ///             break;
        ///         }
        ///         
        ///         // Check to see if the adapter supports Direct3D 12, but don't create the
        ///         // actual device yet.
        ///         if (SUCCEEDED(D3D12CreateDevice(pAdapter, D3D_FEATURE_LEVEL_11_0, _uuidof(ID3D12Device), nullptr)))
        ///         {
        ///             *ppAdapter = pAdapter;
        ///             return;
        ///         }
        ///         pAdapter->Release();
        ///     }
        /// }
        /// </code>
        /// <para>
        /// The function signature PFN_D3D12_CREATE_DEVICE is provided as a typedef,
        /// so that you can use dynamic linking techniques (<see cref="GetProcAddress"/>) instead of statically linking.
        /// </para>
        /// <para>
        /// The REFIID, or <see cref="GUID"/>, of the interface to a device can be obtained by using the macro.
        /// For example, (<see cref="ID3D12Device"/>) will get the <see cref="GUID"/> of the interface to a device.
        /// </para>
        /// </remarks>
        [DllImport("D3D12.dll", CharSet = CharSet.Unicode, EntryPoint = "D3D12CreateDevice", ExactSpelling = true)]
        public static extern HRESULT D3D12CreateDevice([In] P<IUnknown> pAdapter, [In] D3D_FEATURE_LEVEL MinimumFeatureLevel,
            [In] in IID riid, [Out] out IntPtr ppDevice);
    }
}
