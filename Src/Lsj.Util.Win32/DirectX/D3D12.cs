using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
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
        /// Calculates a subresource index for a texture.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d12/d3d12calcsubresource"/>
        /// </para>
        /// </summary>
        /// <param name="MipSlice">
        /// The zero-based index for the mipmap level to address; 0 indicates the first, most detailed mipmap level.
        /// </param>
        /// <param name="ArraySlice">
        /// The zero-based index for the array level to address; always use 0 for volume (3D) textures.
        /// </param>
        /// <param name="PlaneSlice">
        /// The zero-based index for the plane level to address.
        /// </param>
        /// <param name="MipLevels">
        /// The number of mipmap levels in the resource.
        /// </param>
        /// <param name="ArraySize">
        /// The number of elements in the array.
        /// </param>
        /// <returns>
        /// The index which equals <paramref name="MipSlice"/> + (<paramref name="ArraySlice"/> * <paramref name="MipLevels"/>).
        /// </returns>
        /// <remarks>
        /// <para>
        /// A buffer is an unstructured resource and is therefore defined as containing a single subresource.
        /// APIs that take buffers do not need a subresource index.
        /// A texture on the other hand is highly structured.
        /// Each texture object may contain one or more subresources depending on the size of the array and the number of mipmap levels.
        /// </para>
        /// <para>
        /// For volume (3D) textures, all slices for a given mipmap level are a single subresource index.
        /// </para>
        /// </remarks>
        public static UINT D3D12CalcSubresource(UINT MipSlice, UINT ArraySlice, UINT PlaneSlice, UINT MipLevels, UINT ArraySize) =>
            MipSlice + ArraySlice * MipLevels + PlaneSlice * MipLevels * ArraySize;

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
        /// Pass <see cref="NullRef{nint}"/> to test if device creation would succeed, but to not actually create the device.
        /// If <see cref="NullRef{nint}"/> is passed and device creation would succeed, <see cref="S_FALSE"/> is returned.
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
        public static extern HRESULT D3D12CreateDevice(
#if NETFRAMEWORK
            [In] nint pAdapter,
#else
            [In] P<IUnknown> pAdapter,
#endif
            [In] D3D_FEATURE_LEVEL MinimumFeatureLevel, [In] in IID riid, [Out] out nint ppDevice);
    }
}
