using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.DXGI;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_MWA;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An <see cref="IDXGIFactory"/> interface implements methods for generating DXGI objects (which handle full screen transitions).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgifactory"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Create a factory by calling <see cref="CreateDXGIFactory"/>.
    /// </para>
    /// <para>
    /// Because you can create a Direct3D device without creating a swap chain,
    /// you might need to retrieve the factory that is used to create the device in order to create a swap chain.
    /// You can request the <see cref="IDXGIDevice"/> interface from the Direct3D device
    /// and then use the <see cref="IDXGIObject.GetParent"/> method to locate the factory.
    /// The following code shows how.
    /// </para>
    /// <code>
    /// IDXGIDevice * pDXGIDevice = nullptr;
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice), (void **)&amp;pDXGIDevice);
    /// 
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice), (void **)&amp;pDXGIDevice);
    /// hr = pDXGIDevice->GetAdapter( &amp;pDXGIAdapter );
    /// 
    /// IDXGIFactory * pIDXGIFactory = nullptr;
    /// pDXGIAdapter->GetParent(__uuidof(IDXGIFactory), (void **)&amp;pIDXGIFactory);
    /// </code>
    /// <para>
    /// Windows Phone 8: This API is supported.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "7b7166ec-21c7-44ae-b21a-c9ae321ae369", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 11,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject)])]
    public unsafe struct IDXGIFactory
    {
        nint* _vTable;

        /// <summary>
        /// Enumerates the adapters (video cards).
        /// </summary>
        /// <param name="Adapter">
        /// The index of the adapter to enumerate.
        /// </param>
        /// <param name="ppAdapter">
        /// The address of a pointer to an <see cref="IDXGIAdapter"/> interface at the position
        /// specified by the <paramref name="Adapter"/> parameter.
        /// This parameter must not be <see cref="NullRef{T}"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns <see cref="DXGI_ERROR_NOT_FOUND"/>
        /// if the index is greater than or equal to the number of adapters in the local system,
        /// or <see cref="DXGI_ERROR_INVALID_CALL"/> if <paramref name="ppAdapter"/> parameter is <see cref="NullRef{T}"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you create a factory, the factory enumerates the set of adapters that are available in the system.
        /// Therefore, if you change the adapters in a system,
        /// you must destroy and recreate the <see cref="IDXGIFactory"/> object.
        /// The number of adapters in a system changes when you add or remove a display card, or dock or undock a laptop.
        /// </para>
        /// <para>
        /// When the <see cref="EnumAdapters"/> method succeeds
        /// and fills the <paramref name="ppAdapter"/> parameter with the address of the pointer to the adapter interface,
        /// <see cref="EnumAdapters"/> increments the adapter interface's reference count.
        /// When you finish using the adapter interface,
        /// call the <see cref="IUnknown.Release"/> method to decrement the reference count before you destroy the pointer.
        /// </para>
        /// <para>
        /// <see cref="EnumAdapters"/> first returns the adapter with the output on which the desktop primary is displayed.
        /// This adapter corresponds with an index of zero.
        /// <see cref="EnumAdapters"/> next returns other adapters with outputs.
        /// <see cref="EnumAdapters"/> finally returns adapters without outputs.
        /// </para>
        /// </remarks>
        public HRESULT EnumAdapters([In] UINT Adapter, [Out] out P<IDXGIAdapter> ppAdapter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDXGIAdapter>, HRESULT>)_vTable[7])(thisPtr, Adapter, out ppAdapter);
            }
        }

        /// <summary>
        /// Allows DXGI to monitor an application's message queue for the alt-enter key sequence
        /// (which causes the application to switch from windowed to full screen or vice versa).
        /// </summary>
        /// <param name="WindowHandle">
        /// The handle of the window that is to be monitored.
        /// This parameter can be <see cref="NULL"/>; but only if <paramref name="Flags"/> is also 0.
        /// </param>
        /// <param name="Flags">
        /// <para>
        /// One or more of the following values.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DXGI_MWA_NO_WINDOW_CHANGES"/> - Prevent DXGI from monitoring an applications message queue;
        /// this makes DXGI unable to respond to mode changes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_MWA_NO_ALT_ENTER"/> - Prevent DXGI from responding to an alt-enter sequence.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_MWA_NO_PRINT_SCREEN"/> - Prevent DXGI from responding to a print-screen key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if <paramref name="WindowHandle"/> is invalid, or <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If you call this API in a Session 0 process, it returns <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/>.
        /// </para>
        /// <para>
        /// The combination of <paramref name="WindowHandle"/> and <paramref name="Flags"/>
        /// informs DXGI to stop monitoring window messages for the previously-associated window.
        /// </para>
        /// <para>
        /// If the application switches to full-screen mode,
        /// DXGI will choose a full-screen resolution to be the smallest supported resolution
        /// that is larger or the same size as the current back buffer size.
        /// </para>
        /// <para>
        /// Applications can make some changes to make the transition from windowed to full screen more efficient.
        /// For example, on a <see cref="WM_SIZE"/> message,
        /// the application should release any outstanding swap-chain back buffers,
        /// call <see cref="IDXGISwapChain.ResizeBuffers"/>, then re-acquire the back buffers from the swap chain(s).
        /// This gives the swap chain(s) an opportunity to resize the back buffers,
        /// and/or recreate them to enable full-screen flipping operation.
        /// If the application does not perform this sequence,
        /// DXGI will still make the full-screen/windowed transition,
        /// but may be forced to use a stretch operation (since the back buffers may not be the correct size),
        /// which may be less efficient.
        /// Even if a stretch is not required, presentation may not be optimal
        /// because the back buffers might not be directly interchangeable with the front buffer.
        /// Thus, a call to <see cref="IDXGISwapChain.ResizeBuffers"/> on <see cref="WM_SIZE"/> is always recommended,
        /// since <see cref="WM_SIZE"/> is always sent during a fullscreen transition.
        /// </para>
        /// <para>
        /// While windowed, the application can, if it chooses,
        /// restrict the size of its window's client area to sizes to which it is comfortable rendering.
        /// A fully flexible application would make no such restriction,
        /// but UI elements or other design considerations can, of course, make this flexibility untenable.
        /// If the application further chooses to restrict its window's client area to just those
        /// that match supported full-screen resolutions, the application can field <see cref="WM_SIZING"/>,
        /// then check against <see cref="IDXGIOutput.FindClosestMatchingMode"/>.
        /// If a matching mode is found, allow the resize.
        /// (The <see cref="IDXGIOutput"/> can be retrieved from <see cref="IDXGISwapChain.GetContainingOutput"/>.
        /// Absent subsequent changes to desktop topology, this will be the same output that will be chosen
        /// when alt-enter is fielded and fullscreen mode is begun for that swap chain.)
        /// </para>
        /// <para>
        /// Applications that want to handle mode changes or Alt+Enter themselves
        /// should call <see cref="MakeWindowAssociation"/> with the <see cref="DXGI_MWA_NO_WINDOW_CHANGES"/> flag
        /// after swap chain creation.
        /// The <paramref name="WindowHandle"/> argument, if non-<see cref="NULL"/>,
        /// specifies that the application message queues will not be handled by the DXGI runtime
        /// for all swap chains of a particular target <see cref="HWND"/>.
        /// Calling <see cref="MakeWindowAssociation"/> with the <see cref="DXGI_MWA_NO_WINDOW_CHANGES"/> flag
        /// after swapchain creation ensures that DXGI will not interfere
        /// with application's handling of window mode changes or Alt+Enter.
        /// </para>
        /// <para>
        /// You must call the <see cref="MakeWindowAssociation"/> method
        /// on the factory object associated with the target HWND swap chain(s).
        /// You can guarantee that by calling the <see cref="IDXGIObject.GetParent"/> method
        /// on the swap chain(s) to locate the factory.
        /// Here's a code example of doing that.
        /// </para>
        /// <code>
        /// void MakeWindowAssociationWithLocatedFactory(
        ///     winrt::com_ptr&lt;IDXGISwapChain&gt; const&amp; swapChain,
        ///     HWND hWnd,
        ///     UINT flags)
        /// {
        ///     winrt::com_ptr&lt;IDXGIFactory1&gt; factory;
        ///     factory.capture(swapChain, &amp;IDXGISwapChain::GetParent);
        ///     factory->MakeWindowAssociation(hWnd, flags);
        /// }
        /// </code>
        /// <para>
        /// Notes for Windows Store apps
        /// </para>
        /// <para>
        /// If a Windows Store app calls <see cref="MakeWindowAssociation"/>,
        /// it fails with <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/>.
        /// </para>
        /// <para>
        /// A Microsoft Win32 application can use <see cref="MakeWindowAssociation"/> to control full-screen transitions
        /// through the Alt+Enter key combination and print screen behavior for full screen.
        /// For Windows Store apps, because DXGI can't perform full-screen transitions,
        /// a Windows Store app has no way to control full-screen transitions.
        /// </para>
        /// </remarks>
        public HRESULT MakeWindowAssociation([In] HWND WindowHandle, [In] DXGI_MWA Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, DXGI_MWA, HRESULT>)_vTable[8])(thisPtr, WindowHandle, Flags);
            }
        }

        /// <summary>
        /// Get the window through which the user controls the transition to and from full screen.
        /// </summary>
        /// <param name="pWindowHandle">
        /// A pointer to a window handle.
        /// </param>
        /// <returns>
        /// Returns a code that indicates success or failure.
        /// <see cref="S_OK"/> indicates success, <see cref="DXGI_ERROR_INVALID_CALL"/>
        /// indicates <paramref name="pWindowHandle"/> was passed in as <see cref="NullRef{HWND}"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If you call this API in a Session 0 process, it returns <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/>.
        /// </para>
        /// </remarks>
        public HRESULT GetWindowAssociation([Out] out HWND pWindowHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out HWND, HRESULT>)_vTable[9])(thisPtr, out pWindowHandle);
            }
        }

        /// <summary>
        /// Creates a swap chain.
        /// </summary>
        /// <param name="pDevice">
        /// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain.
        /// For Direct3D 12 this is a pointer to a direct command queue (refer to <see cref="ID3D12CommandQueue"/>) .
        /// This parameter cannot be <see cref="NULL"/>.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_SWAP_CHAIN_DESC"/> structure for the swap-chain description.
        /// This parameter cannot be <see cref="NullRef{DXGI_SWAP_CHAIN_DESC}"/>.
        /// </param>
        /// <param name="ppSwapChain">
        /// A pointer to a variable that receives a pointer to the <see cref="IDXGISwapChain"/> interface
        /// for the swap chain that <see cref="CreateSwapChain"/> creates.
        /// </param>
        /// <returns>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/>
        /// if <paramref name="pDesc"/> or <paramref name="ppSwapChain"/> is <see cref="NullRef{T}"/>,
        /// <see cref="DXGI_STATUS_OCCLUDED"/> if you request full-screen mode and it is unavailable,
        /// or <see cref="E_OUTOFMEMORY"/>.
        /// Other error codes defined by the type of device passed in may also be returned.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If you call this API in a Session 0 process, it returns <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/>.
        /// If you attempt to create a swap chain in full-screen mode, and full-screen mode is unavailable,
        /// the swap chain will be created in windowed mode and <see cref="DXGI_STATUS_OCCLUDED"/> will be returned.
        /// </para>
        /// <para>
        /// If the buffer width or the buffer height is zero,
        /// the sizes will be inferred from the output window size in the swap-chain description.
        /// </para>
        /// <para>
        /// Because the target output can't be chosen explicitly when the swap chain is created,
        /// we recommend not to create a full-screen swap chain.
        /// This can reduce presentation performance if the swap chain size and the output window size do not match.
        /// Here are two ways to ensure that the sizes match:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Create a windowed swap chain and then set it full-screen using <see cref="IDXGISwapChain.SetFullscreenState"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Save a pointer to the swap chain immediately after creation,
        /// and use it to get the output window size during a <see cref="WM_SIZE"/> event.
        /// Then resize the swap chain buffers (with <see cref="IDXGISwapChain.ResizeBuffers"/>) during the transition from windowed to full-screen.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the swap chain is in full-screen mode, before you release it
        /// you must use <see cref="IDXGISwapChain.SetFullscreenState"/> to switch it to windowed mode.
        /// For more information about releasing a swap chain,
        /// see the "Destroying a Swap Chain" section of DXGI Overview.
        /// </para>
        /// <para>
        /// After the runtime renders the initial frame in full screen,
        /// the runtime might unexpectedly exit full screen during a call to <see cref="IDXGISwapChain.Present"/>.
        /// To work around this issue, we recommend that you execute the following code right
        /// after you call <see cref="CreateSwapChain"/> to create a full-screen swap chain
        /// (<see cref="DXGI_SWAP_CHAIN_DESC.Windowed"/> member of <see cref="DXGI_SWAP_CHAIN_DESC"/> set to <see cref="FALSE"/>).
        /// </para>
        /// <code>
        /// // Detect if newly created full-screen swap chain isn't actually full screen.
        /// IDXGIOutput* pTarget; BOOL bFullscreen;
        /// if (SUCCEEDED(pSwapChain->GetFullscreenState(&amp;bFullscreen, &amp;pTarget)))
        /// {
        ///    pTarget->Release();
        /// }
        /// else
        ///     bFullscreen = FALSE;
        /// // If not full screen, enable full screen again.
        /// if (!bFullscreen)
        /// {
        ///     ShowWindow(hWnd, SW_MINIMIZE);
        ///     ShowWindow(hWnd, SW_RESTORE);
        ///     pSwapChain->SetFullscreenState(TRUE, NULL);
        ///     }
        /// </code>
        /// <para>
        /// You can specify <see cref="DXGI_SWAP_EFFECT"/> and <see cref="DXGI_SWAP_CHAIN_FLAG"/> values
        /// in the swap-chain description that <paramref name="pDesc"/> points to.
        /// These values allow you to use features like flip-model presentation
        /// and content protection by using pre-Windows 8 APIs.
        /// </para>
        /// <para>
        /// However, to use stereo presentation and to change resize behavior for the flip model,
        /// applications must use the <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/> method.
        /// Otherwise, the back-buffer contents implicitly scale to fit the presentation target size;
        /// that is, you can't turn off scaling.
        /// </para>
        /// <para>
        /// Notes for Windows Store apps
        /// </para>
        /// <para>
        /// If a Windows Store app calls <see cref="CreateSwapChain"/> with full screen specified,
        /// <see cref="CreateSwapChain"/> fails.
        /// </para>
        /// <para>
        /// Windows Store apps call the <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/> method to create a swap chain.
        /// </para>
        /// <para>
        /// For info about how to choose a format for the swap chain's back buffer, see Converting data for the color space.
        /// </para>
        /// </remarks>
        [Obsolete("Starting with Direct3D 11.1, we recommend not to use CreateSwapChain anymore to create a swap chain. " +
            "Instead, use CreateSwapChainForHwnd, CreateSwapChainForCoreWindow, " +
            "or CreateSwapChainForComposition depending on how you want to create the swap chain")]
        public HRESULT CreateSwapChain([In] P<IUnknown> pDevice, [In] in DXGI_SWAP_CHAIN_DESC pDesc, [Out] out P<IDXGISwapChain> ppSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>, in DXGI_SWAP_CHAIN_DESC, out P<IDXGISwapChain>, HRESULT>)_vTable[10])
                    (thisPtr, pDevice, pDesc, out ppSwapChain);
            }
        }

        /// <summary>
        /// Create an adapter interface that represents a software adapter.
        /// </summary>
        /// <param name="Module">
        /// Handle to the software adapter's dll.
        /// <see cref="HMODULE"/> can be obtained with <see cref="GetModuleHandle"/> or <see cref="LoadLibrary"/>.
        /// </param>
        /// <param name="ppAdapter">
        /// Address of a pointer to an adapter (see <see cref="IDXGIAdapter"/>).
        /// </param>
        /// <returns>
        /// A return code indicating success or failure.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A software adapter is a DLL that implements the entirety of a device driver interface,
        /// plus emulation, if necessary, of kernel-mode graphics components for Windows.
        /// Details on implementing a software adapter can be found in the Windows Vista Driver Development Kit.
        /// This is a very complex development task, and is not recommended for general readers.
        /// </para>
        /// <para>
        /// Calling this method will increment the module's reference count by one.
        /// The reference count can be decremented by calling <see cref="FreeLibrary"/>.
        /// </para>
        /// <para>
        /// The typical calling scenario is to call <see cref="LoadLibrary"/>,
        /// pass the handle to <see cref="CreateSoftwareAdapter"/>,
        /// then immediately call <see cref="FreeLibrary"/> on the DLL and forget the DLL's <see cref="HMODULE"/>.
        /// Since the software adapter calls <see cref="FreeLibrary"/> when it is destroyed,
        /// the lifetime of the DLL will now be owned by the adapter,
        /// and the application is free of any further consideration of its lifetime.
        /// </para>
        /// </remarks>
        public HRESULT CreateSoftwareAdapter([In] HMODULE Module, [Out] out P<IDXGIAdapter> ppAdapter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HMODULE, out P<IDXGIAdapter>, HRESULT>)_vTable[11])(thisPtr, Module, out ppAdapter);
            }
        }
    }
}
