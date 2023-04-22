using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
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
    }
}
