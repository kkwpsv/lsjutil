using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.WindowsRuntimeInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D_DRIVER_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D_FEATURE_LEVEL;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_CREATE_DEVICE_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// D3D11.dll
    /// </summary>
    public static class D3D11
    {
        /// <summary>
        /// D3D11_SDK_VERSION
        /// </summary>
        public static readonly UINT D3D11_SDK_VERSION = 7;

        /// <summary>
        /// <para>
        /// Creates an instance of <see cref="IDirect3DDevice"/> from an <see cref="IDXGIDevice"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/windows.graphics.directx.direct3d11.interop/nf-windows-graphics-directx-direct3d11-interop-createdirect3d11devicefromdxgidevice"/>
        /// </para>
        /// </summary>
        /// <param name="dxgiDevice">
        /// The <see cref="IDXGIDevice"/> to create the Direct3DDevice from.
        /// </param>
        /// <param name="graphicsDevice">
        /// A Direct3DDevice instance that wraps the DXGIDevice.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [DllImport("D3D11.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDirect3D11DeviceFromDXGIDevice", ExactSpelling = true)]
        public static extern HRESULT CreateDirect3D11DeviceFromDXGIDevice(in IDXGIDevice dxgiDevice, [Out] out P<IInspectable> graphicsDevice);

        /// <summary>
        /// <para>
        /// Creates a device that represents the display adapter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-d3d11createdevice"/>
        /// </para>
        /// </summary>
        /// <param name="pAdapter">
        /// <para>
        /// A pointer to the video adapter to use when creating a device.
        /// Pass <see cref="NULL"/> to use the default adapter,
        /// which is the first adapter that is enumerated by <see cref="IDXGIFactory.EnumAdapters"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Do not mix the use of DXGI 1.0 (<see cref="IDXGIFactory"/>) and DXGI 1.1 (<see cref="IDXGIFactory1"/>) in an application.
        /// Use <see cref="IDXGIFactory"/> or <see cref="IDXGIFactory1"/>, but not both in an application.
        /// </para>
        /// </param>
        /// <param name="DriverType">
        /// The <see cref="D3D_DRIVER_TYPE"/>, which represents the driver type to create.
        /// </param>
        /// <param name="Software">
        /// A handle to a DLL that implements a software rasterizer.
        /// If <paramref name="DriverType"/> is <see cref="D3D_DRIVER_TYPE_SOFTWARE"/>,
        /// <paramref name="Software"/> must not be <see cref="NULL"/>.
        /// Get the handle by calling <see cref="LoadLibrary"/>, <see cref="LoadLibraryEx"/> , or <see cref="GetModuleHandle"/>.
        /// </param>
        /// <param name="Flags">
        /// The runtime layers to enable (see <see cref="D3D11_CREATE_DEVICE_FLAG"/>); values can be bitwise OR'd together.
        /// </param>
        /// <param name="pFeatureLevels">
        /// <para>
        /// A pointer to an array of <see cref="D3D_FEATURE_LEVEL"/>s, 
        /// which determine the order of feature levels to attempt to create.
        /// If <paramref name="pFeatureLevels"/> is set to <see cref="NULL"/>,
        /// this function uses the following array of feature levels:
        /// </para>
        /// <code>
        /// {
        ///     D3D_FEATURE_LEVEL_11_0,
        ///     D3D_FEATURE_LEVEL_10_1,
        ///     D3D_FEATURE_LEVEL_10_0,
        ///     D3D_FEATURE_LEVEL_9_3,
        ///     D3D_FEATURE_LEVEL_9_2,
        ///     D3D_FEATURE_LEVEL_9_1,
        /// };
        /// </code>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If the Direct3D 11.1 runtime is present on the computer and <paramref name="pFeatureLevels"/> is set to <see langword="null"/>,
        /// this function won't create a <see cref="D3D_FEATURE_LEVEL_11_1"/> device.
        /// To create a <see cref="D3D_FEATURE_LEVEL_11_1"/> device, you must explicitly provide
        /// a <see cref="D3D_FEATURE_LEVEL"/> array that includes <see cref="D3D_FEATURE_LEVEL_11_1"/>.
        /// If you provide a <see cref="D3D_FEATURE_LEVEL"/> array that contains <see cref="D3D_FEATURE_LEVEL_11_1"/> on a computer
        /// that doesn't have the Direct3D 11.1 runtime installed, this function immediately fails with <see cref="E_INVALIDARG"/>.
        /// </para>
        /// </param>
        /// <param name="FeatureLevels">
        /// The number of elements in <paramref name="pFeatureLevels"/>.
        /// </param>
        /// <param name="SDKVersion">
        /// The SDK version; use <see cref="D3D11_SDK_VERSION"/>.
        /// </param>
        /// <param name="ppDevice">
        /// Returns the address of a pointer to an <see cref="ID3D11Device"/> object that represents the device created.
        /// If this parameter is <see cref="NullRef{T}"/>, no <see cref="ID3D11Device"/> will be returned.
        /// </param>
        /// <param name="pFeatureLevel">
        /// If successful, returns the first <see cref="D3D_FEATURE_LEVEL"/> from the <paramref name="pFeatureLevels"/> array which succeeded.
        /// Supply <see cref="NullRef{D3D_FEATURE_LEVEL}"/> as an input if you don't need to determine which feature level is supported.
        /// </param>
        /// <param name="ppImmediateContext">
        /// Returns the address of a pointer to an <see cref="ID3D11DeviceContext"/> object that represents the device context.
        /// If this parameter is <see cref="NullRef{T}"/>, no <see cref="ID3D11DeviceContext"/> will be returned.
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return one of the Direct3D 11 Return Codes.
        /// </para>
        /// <para>
        /// This method returns <see cref="E_INVALIDARG"/>
        /// if you set the <paramref name="pAdapter"/> parameter to a non-<see cref="NULL"/> value
        /// and the <paramref name="DriverType"/> parameter to the <see cref="D3D_DRIVER_TYPE_HARDWARE"/> value.
        /// </para>
        /// <para>
        /// This method returns <see cref="DXGI_ERROR_SDK_COMPONENT_MISSING"/>
        /// if you specify <see cref="D3D11_CREATE_DEVICE_DEBUG"/> in <paramref name="Flags"/>
        /// and the incorrect version of the debug layer is installed on your computer.
        /// Install the latest Windows SDK to get the correct version.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This entry-point is supported by the Direct3D 11 runtime, which is available on Windows 7,
        /// Windows Server 2008 R2, and as an update to Windows Vista (KB971644).
        /// </para>
        /// <para>
        /// To create a Direct3D 11.1 device (<see cref="ID3D11Device1"/>),
        /// which is available on Windows 8, Windows Server 2012,
        /// and Windows 7 and Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// you first create a <see cref="ID3D11Device"/> with this function,
        /// and then call the <see cref="IUnknown.QueryInterface"/> method on the <see cref="ID3D11Device"/> object
        /// to obtain the <see cref="ID3D11Device1"/> interface.
        /// </para>
        /// <para>
        /// To create a Direct3D 11.2 device (<see cref="ID3D11Device2"/>),
        /// which is available on Windows 8.1 and Windows Server 2012 R2,
        /// you first create a <see cref="ID3D11Device"/> with this function,
        /// and then call the <see cref="IUnknown.QueryInterface"/> method on the <see cref="ID3D11Device"/> object
        /// to obtain the <see cref="ID3D11Device2"/> interface.
        /// </para>
        /// <para>
        /// Set <paramref name="ppDevice"/> and <paramref name="ppImmediateContext"/> to <see cref="NULL"/>
        /// to determine which feature level is supported by looking at <paramref name="pFeatureLevel"/> without creating a device.
        /// </para>
        /// <para>
        /// For an example, see How To: Create a Device and Immediate Context;
        /// to create a device and a swap chain at the same time, use <see cref="D3D11CreateDeviceAndSwapChain"/>.
        /// </para>
        /// <para>
        /// If you set the <paramref name="pAdapter"/> parameter to a non-<see cref="NULL"/> value,
        /// you must also set the <paramref name="DriverType"/> parameter to the <see cref="D3D_DRIVER_TYPE_UNKNOWN"/> value.
        /// If you set the <paramref name="pAdapter"/> parameter to a non-<see cref="NULL"/> value
        /// and the <paramref name="DriverType"/> parameter to the <see cref="D3D_DRIVER_TYPE_HARDWARE"/> value,
        /// <see cref="D3D11CreateDevice"/> returns an <see cref="HRESULT"/> of <see cref="E_INVALIDARG"/>. 
        /// </para>
        /// <para>
        /// Differences between Direct3D 10 and Direct3D 11:
        /// </para>
        /// <para>
        /// In Direct3D 10, the presence of <paramref name="pAdapter"/> dictated which adapter to use
        /// and the <paramref name="DriverType"/> could mismatch what the adapter was.
        /// </para>
        /// <para>
        /// In Direct3D 11, if you are trying to create a hardware or a software device,
        /// set <paramref name="pAdapter"/> != <see cref="NULL"/> which constrains the other inputs to be:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <paramref name="DriverType"/> must be <see cref="D3D_DRIVER_TYPE_UNKNOWN"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="Software"/> must be <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// On the other hand, if <paramref name="pAdapter"/> == <see cref="NULL"/>,
        /// the <paramref name="DriverType"/> cannot be set to <see cref="D3D_DRIVER_TYPE_UNKNOWN"/>;
        /// it can be set to either:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <paramref name="DriverType"/> == <see cref="D3D_DRIVER_TYPE_SOFTWARE"/>,
        /// <paramref name="Software"/> cannot be <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <paramref name="DriverType"/> == <see cref="D3D_DRIVER_TYPE_HARDWARE"/>, the adapter used will be the default adapter,
        /// which is the first adapter that is enumerated by <see cref="IDXGIFactory1.EnumAdapters"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The function signature PFN_D3D11_CREATE_DEVICE is provided as a typedef,
        /// so that you can use dynamic linking techniques (<see cref="GetProcAddress"/>) instead of statically linking.
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// <para>
        /// Windows Phone 8.1: This API is supported.
        /// </para>
        /// </remarks>
        [DllImport("D3D11.dll", CharSet = CharSet.Unicode, EntryPoint = "D3D11CreateDevice", ExactSpelling = true)]
        public static extern HRESULT D3D11CreateDevice([In] P<IDXGIAdapter> pAdapter, [In] D3D_DRIVER_TYPE DriverType, [In] HMODULE Software,
            [In] D3D11_CREATE_DEVICE_FLAG Flags, [In] D3D_FEATURE_LEVEL[]? pFeatureLevels, [In] UINT FeatureLevels, [In] UINT SDKVersion,
            [Out] out P<ID3D11Device> ppDevice, [Out] out D3D_FEATURE_LEVEL pFeatureLevel, [Out] out P<ID3D11DeviceContext> ppImmediateContext);

        /// <summary>
        /// <para>
        /// Creates a device that represents the display adapter and a swap chain used for rendering.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-d3d11createdeviceandswapchain"/>
        /// </para>
        /// </summary>
        /// <param name="pAdapter">
        /// <para>
        /// A pointer to the video adapter to use when creating a device.
        /// Pass <see cref="NULL"/> to use the default adapter,
        /// which is the first adapter that is enumerated by <see cref="IDXGIFactory.EnumAdapters"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Do not mix the use of DXGI 1.0 (<see cref="IDXGIFactory"/>) and DXGI 1.1 (<see cref="IDXGIFactory1"/>) in an application.
        /// Use <see cref="IDXGIFactory"/> or <see cref="IDXGIFactory1"/>, but not both in an application.
        /// </para>
        /// </param>
        /// <param name="DriverType">
        /// The <see cref="D3D_DRIVER_TYPE"/>, which represents the driver type to create.
        /// </param>
        /// <param name="Software">
        /// A handle to a DLL that implements a software rasterizer.
        /// If <paramref name="DriverType"/> is <see cref="D3D_DRIVER_TYPE_SOFTWARE"/>,
        /// <paramref name="Software"/> must not be <see cref="NULL"/>.
        /// Get the handle by calling <see cref="LoadLibrary"/>, <see cref="LoadLibraryEx"/> , or <see cref="GetModuleHandle"/>.
        /// The value should be non-<see cref="NULL"/>
        /// when <see cref="D3D_DRIVER_TYPE"/> is <see cref="D3D_DRIVER_TYPE_SOFTWARE"/> and <see cref="NULL"/> otherwise.
        /// </param>
        /// <param name="Flags">
        /// The runtime layers to enable (see <see cref="D3D11_CREATE_DEVICE_FLAG"/>); values can be bitwise OR'd together.
        /// </param>
        /// <param name="pFeatureLevels">
        /// <para>
        /// A pointer to an array of <see cref="D3D_FEATURE_LEVEL"/>s, 
        /// which determine the order of feature levels to attempt to create.
        /// If <paramref name="pFeatureLevels"/> is set to <see cref="NULL"/>,
        /// this function uses the following array of feature levels:
        /// </para>
        /// <code>
        /// {
        ///     D3D_FEATURE_LEVEL_11_0,
        ///     D3D_FEATURE_LEVEL_10_1,
        ///     D3D_FEATURE_LEVEL_10_0,
        ///     D3D_FEATURE_LEVEL_9_3,
        ///     D3D_FEATURE_LEVEL_9_2,
        ///     D3D_FEATURE_LEVEL_9_1,
        /// };
        /// </code>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If the Direct3D 11.1 runtime is present on the computer and <paramref name="pFeatureLevels"/> is set to <see langword="null"/>,
        /// this function won't create a <see cref="D3D_FEATURE_LEVEL_11_1"/> device.
        /// To create a <see cref="D3D_FEATURE_LEVEL_11_1"/> device, you must explicitly provide
        /// a <see cref="D3D_FEATURE_LEVEL"/> array that includes <see cref="D3D_FEATURE_LEVEL_11_1"/>.
        /// If you provide a <see cref="D3D_FEATURE_LEVEL"/> array that contains <see cref="D3D_FEATURE_LEVEL_11_1"/> on a computer
        /// that doesn't have the Direct3D 11.1 runtime installed, this function immediately fails with <see cref="E_INVALIDARG"/>.
        /// </para>
        /// </param>
        /// <param name="FeatureLevels">
        /// The number of elements in <paramref name="pFeatureLevels"/>.
        /// </param>
        /// <param name="SDKVersion">
        /// The SDK version; use <see cref="D3D11_SDK_VERSION"/>.
        /// </param>
        /// <param name="pSwapChainDesc">
        /// A pointer to a swap chain description (see <see cref="DXGI_SWAP_CHAIN_DESC"/>)
        /// that contains initialization parameters for the swap chain.
        /// </param>
        /// <param name="ppSwapChain">
        /// Returns the address of a pointer to the <see cref="IDXGISwapChain"/> object that represents the swap chain used for rendering.
        /// </param>
        /// <param name="ppDevice">
        /// Returns the address of a pointer to an <see cref="ID3D11Device"/> object that represents the device created.
        /// If this parameter is <see cref="NullRef{T}"/>, no <see cref="ID3D11Device"/> will be returned.
        /// </param>
        /// <param name="pFeatureLevel">
        /// If successful, returns the first <see cref="D3D_FEATURE_LEVEL"/> from the <paramref name="pFeatureLevels"/> array which succeeded.
        /// Supply <see cref="NullRef{D3D_FEATURE_LEVEL}"/> as an input if you don't need to determine which feature level is supported.
        /// </param>
        /// <param name="ppImmediateContext">
        /// Returns the address of a pointer to an <see cref="ID3D11DeviceContext"/> object that represents the device context.
        /// If this parameter is <see cref="NullRef{T}"/>, no <see cref="ID3D11DeviceContext"/> will be returned.
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return one of the Direct3D 11 Return Codes.
        /// </para>
        /// <para>
        /// This method returns <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/> if you call it in a Session 0 process.
        /// </para>
        /// <para>
        /// This method returns <see cref="E_INVALIDARG"/>
        /// if you set the <paramref name="pAdapter"/> parameter to a non-<see cref="NULL"/> value
        /// and the <paramref name="DriverType"/> parameter to the <see cref="D3D_DRIVER_TYPE_HARDWARE"/> value.
        /// </para>
        /// <para>
        /// This method returns <see cref="DXGI_ERROR_SDK_COMPONENT_MISSING"/>
        /// if you specify <see cref="D3D11_CREATE_DEVICE_DEBUG"/> in <paramref name="Flags"/>
        /// and the incorrect version of the debug layer is installed on your computer.
        /// Install the latest Windows SDK to get the correct version.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If you call this method in a Session 0 process, it returns <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/>.
        /// </para>
        /// <para>
        /// This entry-point is supported by the Direct3D 11 runtime,
        /// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista (KB971644).
        /// </para>
        /// <para>
        /// To create a Direct3D 11.1 device (<see cref="ID3D11Device1"/>),
        /// which is available on Windows 8, Windows Server 2012,
        /// and Windows 7 and Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// you first create a <see cref="ID3D11Device"/> with this function,
        /// and then call the <see cref="IUnknown.QueryInterface"/> method on the <see cref="ID3D11Device"/> object
        /// to obtain the <see cref="ID3D11Device1"/> interface.
        /// </para>
        /// <para>
        /// To create a Direct3D 11.2 device (<see cref="ID3D11Device2"/>),
        /// which is available on Windows 8.1 and Windows Server 2012 R2,
        /// you first create a <see cref="ID3D11Device"/> with this function,
        /// and then call the <see cref="IUnknown.QueryInterface"/> method on the <see cref="ID3D11Device"/> object
        /// to obtain the <see cref="ID3D11Device2"/> interface.
        /// </para>
        /// <para>
        /// Also, see the remarks section in <see cref="D3D11CreateDevice"/> for details about input parameter dependencies.
        /// To create a device without creating a swap chain, use the <see cref="D3D11CreateDevice"/> function.
        /// </para>
        /// <para>
        /// If you set the <paramref name="pAdapter"/> parameter to a non-<see cref="NULL"/> value,
        /// you must also set the <paramref name="DriverType"/> parameter to the <see cref="D3D_DRIVER_TYPE_UNKNOWN"/> value.
        /// If you set the <paramref name="pAdapter"/> parameter to a non-<see cref="NULL"/> value
        /// and the <paramref name="DriverType"/> parameter to the <see cref="D3D_DRIVER_TYPE_HARDWARE"/> value,
        /// <see cref="D3D11CreateDeviceAndSwapChain"/> returns an <see cref="HRESULT"/> of <see cref="E_INVALIDARG"/>.
        /// </para>
        /// <para>
        /// The function signature PFN_D3D11_CREATE_DEVICE_AND_SWAP_CHAIN is provided as a typedef,
        /// so that you can use dynamic linking techniques (<see cref="GetProcAddress"/>) instead of statically linking.
        /// </para>
        /// <para>
        /// Usage notes
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The <see cref="D3D11CreateDeviceAndSwapChain"/> function does not exist for Windows Store apps.
        /// Instead, Windows Store apps use the <see cref="D3D11CreateDevice"/> function
        /// and then use the <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/> method.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function has not been updated to support recent additional features of swap chain creation.
        /// For the most up-to-date swap chain creation methods,
        /// refer to the methods of <see cref="IDXGIFactory2"/> (including <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>,
        /// <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/> and <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>).
        /// </para>
        /// <para>
        /// Windows Phone 8: This API is supported.
        /// </para>
        /// </remarks>
        [DllImport("D3D11.dll", CharSet = CharSet.Unicode, EntryPoint = "D3D11CreateDeviceAndSwapChain", ExactSpelling = true)]
        public static extern HRESULT D3D11CreateDeviceAndSwapChain([In] P<IDXGIAdapter> pAdapter, [In] D3D_DRIVER_TYPE DriverType, [In] HMODULE Software,
             [In] D3D11_CREATE_DEVICE_FLAG Flags, [In] D3D_FEATURE_LEVEL[] pFeatureLevels, [In] UINT FeatureLevels, [In] UINT SDKVersion,
             [In] in DXGI_SWAP_CHAIN_DESC pSwapChainDesc, [Out] out P<IDXGISwapChain> ppSwapChain, [Out] out P<ID3D11Device> ppDevice,
             [Out] out D3D_FEATURE_LEVEL pFeatureLevel, [Out] out P<ID3D11DeviceContext> ppImmediateContext);
    }
}
