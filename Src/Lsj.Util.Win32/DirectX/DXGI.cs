using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
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
        /// The enumeration order of adapters, which you retrieve with <see cref="IDXGIFactory.EnumAdapters"/> or <see cref="IDXGIFactory1."EnumAdapters1/>,
        /// is as follows:
        /// Adapter with the output on which the desktop primary is displayed. This adapter corresponds with an index of zero.
        /// Adapters with outputs.
        /// Adapters without outputs.
        /// The <see cref="CreateDXGIFactory"/> function does not exist for Windows Store apps.
        /// Instead, Windows Store apps use the <see cref="CreateDXGIFactory1"/> function.
        /// </remarks>
        [DllImport("DXGI.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDXGIFactory", ExactSpelling = true)]
        public static extern HRESULT CreateDXGIFactory([In] in IID riid, [Out] out IntPtr ppFactory);
    }
}
