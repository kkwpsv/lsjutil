using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// DXGI.dll
    /// </summary>
    public static class DXGI
    {
        /// <summary>
        /// <para>
        /// Creates a DXGI 1.0 factory that you can use to generate other DXGI objects.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-createdxgifactory"/>
        /// </para>
        /// </summary>
        /// <param name="riid">
        /// The globally unique identifier (GUID) of the <see cref="IDXGIFactory"/> object referenced by the <paramref name="ppFactory"/> parameter.
        /// </param>
        /// <param name="ppFactory"></param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// Use a DXGI factory to generate objects that enumerate adapters, create swap chains, and associate a window
        /// with the alt+enter key sequence for toggling to and from the fullscreen display mode.
        /// If the <see cref="CreateDXGIFactory"/> function succeeds, the reference count on the <see cref="IDXGIFactory"/> interface is incremented.
        /// To avoid a memory leak, when you finish using the interface, call the <see cref="IUnknown.Release"/> method to release the interface.
        /// Note
        /// Do not mix the use of DXGI 1.0 (<see cref="IDXGIFactory"/>) and DXGI 1.1 (<see cref="IDXGIFactory1"/>) in an application.
        /// Use <see cref="IDXGIFactory"/> or <see cref="IDXGIFactory1"/>, but not both in an application.
        /// Note
        /// <see cref="CreateDXGIFactory"/> fails if your app's DllMain function calls it.
        /// For more info about how DXGI responds from DllMain, see DXGI Responses from DLLMain.
        /// Note
        /// Starting with Windows 8, all DXGI factories (regardless if they were
        /// created with <see cref="CreateDXGIFactory"/> or <see cref="CreateDXGIFactory1"/>) enumerate adapters identically.
        /// The enumeration order of adapters, which you retrieve with <see cref="IDXGIFactory.EnumAdapters"/> or <see cref="IDXGIFactory1.EnumAdapters1"/>,
        /// is as follows:
        /// Adapter with the output on which the desktop primary is displayed. This adapter corresponds with an index of zero.
        /// Adapters with outputs.
        /// Adapters without outputs.
        /// The <see cref="CreateDXGIFactory"/> function does not exist for Windows Store apps.
        /// Instead, Windows Store apps use the <see cref="CreateDXGIFactory1"/> function.
        /// </remarks>
        [DllImport("DXGI.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDXGIFactory", ExactSpelling = true)]
        public static extern HRESULT CreateDXGIFactory([In] in IID riid, [Out] out P<IDXGIFactory> ppFactory);

        /// <summary>
        /// <para>
        /// Creates a DXGI 1.1 factory that you can use to generate other DXGI objects.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-createdxgifactory1"/>
        /// </para>
        /// </summary>
        /// <param name="riid">
        /// The globally unique identifier (GUID) of the <see cref="IDXGIFactory1"/> object referenced by the ppFactory parameter.
        /// </param>
        /// <param name="ppFactory">
        /// Address of a pointer to an <see cref="IDXGIFactory1"/> object.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// Use a DXGI 1.1 factory to generate objects that enumerate adapters, create swap chains, and associate a window
        /// with the alt+enter key sequence for toggling to and from the full-screen display mode.
        /// If the <see cref="CreateDXGIFactory1"/> function succeeds, the reference count on the <see cref="IDXGIFactory1"/> interface is incremented.
        /// To avoid a memory leak, when you finish using the interface, call the <see cref="IUnknown.Release"/> method to release the interface.
        /// This entry point is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
        /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
        /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
        /// Note
        /// Do not mix the use of DXGI 1.0 (<see cref="IDXGIFactory"/>) and DXGI 1.1 (<see cref="IDXGIFactory1"/>) in an application.
        /// Use <see cref="IDXGIFactory"/> or <see cref="IDXGIFactory1"/>, but not both in an application.
        /// Note  CreateDXGIFactory1 fails if your app's DllMain function calls it.
        /// For more info about how DXGI responds from DllMain, see DXGI Responses from DLLMain.
        /// Note
        /// Starting with Windows 8, all DXGI factories (regardless if they were created
        /// with <see cref="CreateDXGIFactory"/> or <see cref="CreateDXGIFactory1"/>) enumerate adapters identically.
        /// The enumeration order of adapters, which you retrieve with <see cref="IDXGIFactory.EnumAdapters"/> or <see cref="IDXGIFactory1.EnumAdapters1"/>,
        /// is as follows:
        /// Adapter with the output on which the desktop primary is displayed.This adapter corresponds with an index of zero.
        /// Adapters with outputs.
        /// Adapters without outputs.
        /// </remarks>
        [DllImport("DXGI.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDXGIFactory1", ExactSpelling = true)]
        public static extern HRESULT CreateDXGIFactory1([In] in IID riid, [Out] out P<IDXGIFactory1> ppFactory);

        /// <summary>
        /// <para>
        /// Creates a DXGI 1.3 factory that you can use to generate other DXGI objects.
        /// In Windows 8, any DXGI factory created while DXGIDebug.dll was present on the system would load and use it.
        /// Starting in Windows 8.1, apps explicitly request that DXGIDebug.dll be loaded instead.
        /// Use <see cref="CreateDXGIFactory2"/> and specify the <see cref="DXGI_CREATE_FACTORY_DEBUG"/> flag to request DXGIDebug.dll;
        /// the DLL will be loaded if it is present on the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-createdxgifactory2"/>
        /// </para>
        /// </summary>
        /// <param name="Flags">
        /// Valid values include the <see cref="DXGI_CREATE_FACTORY_DEBUG"/> (0x01) flag, and zero.
        /// Note
        /// This flag will be set by the D3D runtime if:
        /// The system creates an implicit factory during device creation.
        /// The <see cref="D3D11_CREATE_DEVICE_DEBUG"/> flag is specified during device creation,
        /// for example using <see cref="D3D11CreateDevice"/> (or the swapchain method, or the Direct3D 10 equivalents).
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (GUID) of the <see cref="IDXGIFactory2"/> object referenced by the ppFactory parameter.
        /// </param>
        /// <param name="ppFactory">
        /// Address of a pointer to an <see cref="IDXGIFactory2"/> object.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// This function accepts a flag indicating whether DXGIDebug.dll is loaded.
        /// The function otherwise behaves identically to <see cref="CreateDXGIFactory1"/>.
        /// </remarks>
        [DllImport("DXGI.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDXGIFactory2", ExactSpelling = true)]
        public static extern HRESULT CreateDXGIFactory2([In] UINT Flags, [In] in IID riid, [Out] out P<IDXGIFactory2> ppFactory);

        /// <summary>
        /// <para>
        /// Allows a process to indicate that it's resilient to any of its graphics devices being removed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-dxgideclareadapterremovalsupport"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// If this function is called after device creation, it returns <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// If this is not the first time that this function is called, it returns <see cref="DXGI_ERROR_ALREADY_EXISTS"/>.
        /// For a full list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// This function is graphics API-agnostic, meaning that apps running on other APIs, such as OpenGL and Vulkan, would also apply.
        /// This function should be called once per process and before any device creation.
        /// </remarks>
        [DllImport("DXGI.dll", CharSet = CharSet.Unicode, EntryPoint = "DXGIDeclareAdapterRemovalSupport", ExactSpelling = true)]
        public static extern HRESULT DXGIDeclareAdapterRemovalSupport();

        /// <summary>
        /// <para>
        /// Disables v-blank virtualization for the process.
        /// This virtualization is used by the dynamic refresh rate (DRR) feature by default for all swap chains
        /// to maintain a steady virtualized present rate and v-blank cadence from <see cref="IDXGIOutput.WaitForVBlank"/>.
        /// By disabling virtualization, these APIs will see the changing refresh rate.
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a full list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// By default, a DXGI swap chain is unable to observe the changing refresh rate
        /// that's caused by the dynamic refresh rate (DRR) feature (see the blog post Dynamic refresh rate—Get the best of both worlds).
        /// Instead, a swap chain is virtualized to always see a fraction of the refresh rate—60Hz if the DRR mode is 120Hz.
        /// <see cref="DXGIDisableVBlankVirtualization"/> disables that virtualization for the entire process.
        /// Your application will then see v-blank timings change as the system boosts between 60Hz and 120Hz,
        /// and frames will arrive at the corresponding times for each rate, with present statistics reflecting those changes.
        /// You should call <see cref="DXGIDisableVBlankVirtualization"/> once per process,
        /// before creating any swap chains or calling <see cref="IDXGIOutput.WaitForVBlank"/>.
        /// It can't be disabled for the lifetime of the process,
        /// so any changes in v-blank timing or statistics from DRR boosting will remain observable to the process.
        /// You can find more information on how Dynamic Refresh Rate works in the Compositor clock topic.
        /// </remarks>
        [DllImport("DXGI.dll", CharSet = CharSet.Unicode, EntryPoint = "DXGIDisableVBlankVirtualization", ExactSpelling = true)]
        public static extern HRESULT DXGIDisableVBlankVirtualization();

        /// <summary>
        /// <para>
        /// Retrieves an interface that Windows Store apps use for debugging the Microsoft DirectX Graphics Infrastructure (DXGI).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-dxgigetdebuginterface1"/>
        /// </para>
        /// </summary>
        /// <param name="Flags">
        /// Not used.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (GUID) of the requested interface type,
        /// which can be the identifier for the <see cref="IDXGIDebug"/>, <see cref="IDXGIDebug1"/>, or <see cref="IDXGIInfoQueue"/> interfaces.
        /// </param>
        /// <param name="pDebug">
        /// A pointer to a buffer that receives a pointer to the debugging interface.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The <see cref="DXGIGetDebugInterface1"/> function returns <see cref="E_NOINTERFACE"/> on systems
        /// without the Windows Software Development Kit (SDK) installed, because it's a development-time aid.
        /// </remarks>
        [DllImport("DXGI.dll", CharSet = CharSet.Unicode, EntryPoint = "DXGIGetDebugInterface1", ExactSpelling = true)]
        public static extern HRESULT DXGIGetDebugInterface1([In] UINT Flags,[In]in IID riid,[Out]out IntPtr pDebug);
    }
}
