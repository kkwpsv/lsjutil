using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.DXGI;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGIFactory2"/> interface includes methods to create a newer version swap chain with more features
    /// than <see cref="IDXGISwapChain"/> and to monitor stereoscopic 3D capabilities.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgifactory2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To create a Microsoft DirectX Graphics Infrastructure (DXGI) 1.2 factory interface, pass <see cref="IDXGIFactory2"/> into
    /// either the <see cref="CreateDXGIFactory"/> or <see cref="CreateDXGIFactory1"/> function
    /// or call <see cref="IUnknown.QueryInterface"/> from a factory object that either <see cref="CreateDXGIFactory"/> or <see cref="CreateDXGIFactory1"/> returns.
    /// Because you can create a Direct3D device without creating a swap chain, you might need to retrieve the factory
    /// that is used to create the device in order to create a swap chain.
    /// You can request the <see cref="IDXGIDevice"/>, <see cref="IDXGIDevice1"/>, or <see cref="IDXGIDevice2"/> interface
    /// from the Direct3D device and then use the <see cref="IDXGIObject.GetParent"/> method to locate the factory.
    /// The following code shows how.
    /// <code>
    /// IDXGIDevice2 * pDXGIDevice;
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice2), (void **)&amp;pDXGIDevice);
    /// 
    /// IDXGIAdapter * pDXGIAdapter;
    /// hr = pDXGIDevice->GetParent(__uuidof(IDXGIAdapter), (void **)&amp;pDXGIAdapter);
    /// 
    /// IDXGIFactory2 * pIDXGIFactory;
    /// pDXGIAdapter->GetParent(__uuidof(IDXGIFactory2), (void **)&amp;pIDXGIFactory);
    /// </code>
    /// </remarks>
    public unsafe struct IDXGIFactory2
    {
        IntPtr* _vTable;

        /// <summary>
        /// Determines whether to use stereo mode.
        /// </summary>
        /// <returns>
        /// Indicates whether to use stereo mode.
        /// <see cref="TRUE"/> indicates that you can use stereo mode; otherwise, <see cref="FALSE"/>.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="IsWindowedStereoEnabled"/> always returns <see cref="FALSE"/>
        /// because stereoscopic 3D display behavior isn’t available with the Platform Update for Windows 7.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        /// <remarks>
        /// We recommend that windowed applications call <see cref="IsWindowedStereoEnabled"/> before they attempt to use stereo.
        /// <see cref="IsWindowedStereoEnabled"/> returns <see cref="TRUE"/> if both of the following items are true:
        /// All adapters in the computer have drivers that are capable of stereo.
        /// This only means that the driver is implemented to the Windows Display Driver Model (WDDM) for Windows 8 (WDDM 1.2).
        /// However, the adapter does not necessarily have to be able to scan out stereo.
        /// The current desktop mode (desktop modes are mono) and system policy and hardware are configured
        /// so that the Desktop Window Manager (DWM) performs stereo composition on at least one adapter output.
        /// The creation of a windowed stereo swap chain succeeds if the first requirement is met.
        /// However, if the adapter can't scan out stereo, the output on that adapter is reduced to mono.
        /// The Direct3D 11.1 Simple Stereo 3D Sample shows how to add a stereoscopic 3D effect and how to respond to system stereo changes.
        /// </remarks>
        public BOOL IsWindowedStereoEnabled()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[14])(thisPtr);
            }
        }

        /// <summary>
        /// Creates a swap chain that is associated with an <see cref="HWND"/> handle to the output window for the swap chain.
        /// </summary>
        /// <param name="pDevice">
        /// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain.
        /// For Direct3D 12 this is a pointer to a direct command queue (refer to <see cref="ID3D12CommandQueue"/>).
        /// This parameter cannot be <see cref="NullRef{IUnknown}"/>.
        /// </param>
        /// <param name="hWnd">
        /// The <see cref="HWND"/> handle that is associated with the swap chain that <see cref="CreateSwapChainForHwnd"/> creates.
        /// This parameter cannot be <see cref="NULL"/>.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_SWAP_CHAIN_DESC1"/> structure for the swap-chain description.
        /// This parameter cannot be <see cref="NullRef{DXGI_SWAP_CHAIN_DESC1}"/>.
        /// </param>
        /// <param name="pFullscreenDesc">
        /// A pointer to a <see cref="DXGI_SWAP_CHAIN_FULLSCREEN_DESC"/> structure for the description of a full-screen swap chain.
        /// You can optionally set this parameter to create a full-screen swap chain.
        /// Set it to <see cref="NullRef{DXGI_SWAP_CHAIN_FULLSCREEN_DESC}"/> to create a windowed swap chain.
        /// </param>
        /// <param name="pRestrictToOutput">
        /// A pointer to the <see cref="IDXGIOutput"/> interface for the output to restrict content to.
        /// You must also pass the <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> flag in a <see cref="IDXGISwapChain1.Present1"/> call
        /// to force the content to appear blacked out on any other output.
        /// If you want to restrict the content to a different output, you must create a new swap chain.
        /// However, you can conditionally restrict content based on the <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> flag.
        /// Set this parameter to <see cref="NullRef{IDXGIOutput}"/> if you don't want to restrict content to an output target.
        /// </param>
        /// <param name="ppSwapChain">
        /// A pointer to a variable that receives a pointer to the <see cref="IDXGISwapChain1"/> interface
        /// for the swap chain that <see cref="CreateSwapChainForHwnd"/> creates.
        /// </param>
        /// <returns>
        /// <see cref="CreateSwapChainForHwnd"/> returns:
        /// <see cref="S_OK"/> if it successfully created a swap chain.
        /// <see cref="E_OUTOFMEMORY"/> if memory is unavailable to complete the operation.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the calling application provided invalid data, for example,
        /// if <paramref name="pDesc"/> or <paramref name="ppSwapChain"/> is NULL, or <paramref name="pDesc"/> data members are invalid.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic
        /// that are defined by the type of device that you pass to <paramref name="pDevice"/>.
        /// Platform Update for Windows 7:
        /// <see cref="DXGI_SCALING_NONE"/> is not supported on Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed
        /// and causes <see cref="CreateSwapChainForHwnd"/> to return <see cref="DXGI_ERROR_INVALID_CALL"/> when called.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        /// <remarks>
        /// Note
        /// Do not use this method in Windows Store apps. Instead, use <see cref="CreateSwapChainForCoreWindow"/>.
        /// If you specify the width, height, or both (<see cref="DXGI_SWAP_CHAIN_DESC1.Width"/> and <see cref="DXGI_SWAP_CHAIN_DESC1.Height"/>
        /// members of <see cref="DXGI_SWAP_CHAIN_DESC1"/> that pDesc points to) of the swap chain as zero,
        /// the runtime obtains the size from the output window that the <paramref name="hWnd"/> parameter specifies.
        /// You can subsequently call the <see cref="IDXGISwapChain1.GetDesc1"/> method to retrieve the assigned width or height value.
        /// Because you can associate only one flip presentation model swap chain at a time with an <see cref="HWND"/>,
        /// the Microsoft Direct3D 11 policy of deferring the destruction of objects can cause problems
        /// if you attempt to destroy a flip presentation model swap chain and replace it with another swap chain.
        /// For more info about this situation, see Deferred Destruction Issues with Flip Presentation Swap Chains.
        /// For info about how to choose a format for the swap chain's back buffer, see Converting data for the color space.
        /// </remarks>
        public HRESULT CreateSwapChainForHwnd([In] in IUnknown pDevice, [In] HWND hWnd, [In] in DXGI_SWAP_CHAIN_DESC1 pDesc,
            [In] in DXGI_SWAP_CHAIN_FULLSCREEN_DESC pFullscreenDesc, [In] in IDXGIOutput pRestrictToOutput, [Out] out P<IDXGISwapChain1> ppSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IUnknown, HWND, in DXGI_SWAP_CHAIN_DESC1,
                    in DXGI_SWAP_CHAIN_FULLSCREEN_DESC, in IDXGIOutput, out P<IDXGISwapChain1>, HRESULT>)_vTable[15])
                    (thisPtr, pDevice, hWnd, pDesc, pFullscreenDesc, pRestrictToOutput, out ppSwapChain);
            }
        }

        /// <summary>
        /// Creates a swap chain that is associated with the CoreWindow object for the output window for the swap chain.
        /// </summary>
        /// <param name="pDevice">
        /// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain.
        /// For Direct3D 12 this is a pointer to a direct command queue (refer to <see cref="ID3D12CommandQueue"/>).
        /// This parameter cannot be <see cref="NullRef{IUnknown}"/>.
        /// </param>
        /// <param name="pWindow">
        /// A pointer to the CoreWindow object that is associated with the swap chain that <see cref="CreateSwapChainForCoreWindow"/> creates.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_SWAP_CHAIN_DESC1"/> structure for the swap-chain description.
        /// This parameter cannot be <see cref="NullRef{DXGI_SWAP_CHAIN_DESC1}"/>.
        /// </param>
        /// <param name="pRestrictToOutput">
        /// A pointer to the <see cref="IDXGIOutput"/> interface that the swap chain is restricted to.
        /// If the swap chain is moved to a different output, the content is black.
        /// You can optionally set this parameter to an output target
        /// that uses <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> to restrict the content on this output.
        /// If you do not set this parameter to restrict content on an output target, you can set it to <see cref="NullRef{IDXGIOutput}"/>.
        /// </param>
        /// <param name="ppSwapChain">
        /// A pointer to a variable that receives a pointer to the <see cref="IDXGISwapChain1"/> interface
        /// for the swap chain that <see cref="CreateSwapChainForCoreWindow"/> creates.
        /// </param>
        /// <returns>
        /// <see cref="CreateSwapChainForCoreWindow"/> returns:
        /// <see cref="S_OK"/> if it successfully created a swap chain.
        /// <see cref="E_OUTOFMEMORY"/> if memory is unavailable to complete the operation.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the calling application provided invalid data, for example,
        /// if <paramref name="pDesc"/> or <paramref name="ppSwapChain"/> is NULL.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic
        /// that are defined by the type of device that you pass to <paramref name="pDevice"/>.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="CreateSwapChainForCoreWindow"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        /// <remarks>
        /// Note
        /// Use this method in Windows Store apps rather than <see cref="CreateSwapChainForHwnd"/>.
        /// If you specify the width, height, or both (<see cref="DXGI_SWAP_CHAIN_DESC1.Width"/> and <see cref="DXGI_SWAP_CHAIN_DESC1.Height"/>
        /// members of <see cref="DXGI_SWAP_CHAIN_DESC1"/> that <paramref name="pDesc"/> points to) of the swap chain as zero,
        /// the runtime obtains the size from the output window that the <paramref name="pWindow"/> parameter specifies.
        /// You can subsequently call the <see cref="IDXGISwapChain1.GetDesc1"/> method to retrieve the assigned width or height value.
        /// Because you can associate only one flip presentation model swap chain (per layer) at a time with a CoreWindow,
        /// the Microsoft Direct3D 11 policy of deferring the destruction of objects can cause problems
        /// if you attempt to destroy a flip presentation model swap chain and replace it with another swap chain.
        /// For more info about this situation, see Deferred Destruction Issues with Flip Presentation Swap Chains.
        /// For info about how to choose a format for the swap chain's back buffer, see Converting data for the color space.
        /// Overlapping swap chains
        /// Starting with Windows 8.1, it is possible to create an additional swap chain in the foreground layer.
        /// A foreground swap chain can be used to render UI elements at native resolution
        /// while scaling up real-time rendering in the background swap chain (such as gameplay).
        /// This enables scenarios where lower resolution rendering is required for faster fill rates, but without sacrificing UI quality.
        /// Foreground swap chains are created by setting the <see cref="DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER"/> swap chain flag
        /// in the <see cref="DXGI_SWAP_CHAIN_DESC1"/> that pDesc points to.
        /// Foreground swap chains must also use the <see cref="DXGI_ALPHA_MODE_PREMULTIPLIED"/> alpha mode, and must use <see cref="DXGI_SCALING_NONE"/>.
        /// Premultiplied alpha means that each pixel's color values are expected to be already multiplied by the alpha value before the frame is presented.
        /// For example, a 100% white BGRA pixel at 50% alpha is set to (0.5, 0.5, 0.5, 0.5).
        /// The alpha premultiplication step can be done in the output-merger stage by applying an app blend state (see <see cref="ID3D11BlendState"/>)
        /// with the <see cref="D3D11_RENDER_TARGET_BLEND_DESC"/> structure's <see cref="D3D11_RENDER_TARGET_BLEND_DESC.SrcBlend"/> field
        /// set to <see cref="D3D11_SRC_ALPHA"/>.
        /// If the alpha premultiplication step is not done, colors on the foreground swap chain will be brighter than expected.
        /// The foreground swap chain will use multiplane overlays if supported by the hardware.
        /// Call <see cref="IDXGIOutput2.SupportsOverlays"/> to query the adapter for overlay support.
        /// The following example creates a foreground swap chain for a CoreWindow:
        /// <code>
        /// DXGI_SWAP_CHAIN_DESC1 swapChainDesc = { 0 };
        /// 
        /// swapChainDesc.Width = static_cast&lt;UINT&gt;(m_d3dRenderTargetSize.Width);
        /// swapChainDesc.Height = static_cast&lt;UINT&gt;(m_d3dRenderTargetSize.Height);
        /// swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;
        /// swapChainDesc.Stereo = false;
        /// swapChainDesc.SampleDesc.Count = 1; // Don't use multi-sampling.
        /// swapChainDesc.SampleDesc.Quality = 0;
        /// swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
        /// swapChainDesc.BufferCount = 2;
        /// swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL;
        /// swapChainDesc.Flags = DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER;
        /// swapChainDesc.AlphaMode = DXGI_ALPHA_MODE_PREMULTIPLIED;
        /// swapChainDesc.Scaling = DXGI_SCALING_NONE;
        /// 
        /// ComPtr&lt;IDXGISwapChain1&gt; swapChain;
        /// HRESULT hr = dxgiFactory->CreateSwapChainForCoreWindow(
        ///     m_d3dDevice.Get(),
        ///     reinterpret_cast&lt;IUnknown*&gt;(m_window.Get()),
        ///     &amp;swapChainDesc,
        ///     nullptr,
        ///     &amp;swapChain
        ///     );
        /// </code>
        /// Present both swap chains together after rendering is complete.
        /// The following example presents both swap chains:
        /// <code>
        /// HRESULT hr = m_swapChain->Present(1, 0);
        /// 
        /// if (SUCCEEDED(hr) &amp;&amp; m_foregroundSwapChain)
        /// {
        ///     m_foregroundSwapChain->Present(1, 0);
        /// }
        /// </code>
        /// </remarks>
        public HRESULT CreateSwapChainForCoreWindow([In] in IUnknown pDevice, [In] in IUnknown pWindow, [In] in DXGI_SWAP_CHAIN_DESC1 pDesc,
            [In] in IDXGIOutput pRestrictToOutput, [Out] out P<IDXGISwapChain1> ppSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IUnknown, in IUnknown, in DXGI_SWAP_CHAIN_DESC1,
                    in IDXGIOutput, out P<IDXGISwapChain1>, HRESULT>)_vTable[16])
                    (thisPtr, pDevice, pWindow, pDesc, pRestrictToOutput, out ppSwapChain);
            }
        }

        /// <summary>
        /// Identifies the adapter on which a shared resource object was created.
        /// </summary>
        /// <param name="hResource">
        /// A handle to a shared resource object.
        /// The <see cref="IDXGIResource1.CreateSharedHandle"/> method returns this handle.
        /// </param>
        /// <param name="pLuid">
        /// A pointer to a variable that receives a locally unique identifier (LUID) value that identifies the adapter.
        /// LUID is defined in Dxgi.h.
        /// An LUID is a 64-bit value that is guaranteed to be unique only on the operating system on which it was generated.
        /// The uniqueness of an LUID is guaranteed only until the operating system is restarted.
        /// </param>
        /// <returns>
        /// <see cref="GetSharedResourceAdapterLuid"/> returns:
        /// <see cref="S_OK"/> if it identified the adapter.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if <paramref name="hResource"/> is invalid.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="GetSharedResourceAdapterLuid"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        public HRESULT GetSharedResourceAdapterLuid([In] HANDLE hResource, [Out] out LUID pLuid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, out LUID, HRESULT>)_vTable[17])(thisPtr, hResource, out pLuid);
            }
        }

        /// <summary>
        /// Registers an application window to receive notification messages of changes of stereo status.
        /// </summary>
        /// <param name="WindowHandle">
        /// The handle of the window to send a notification message to when stereo status change occurs.
        /// </param>
        /// <param name="wMsg">
        /// Identifies the notification message to send.
        /// </param>
        /// <param name="pdwCookie">
        /// A pointer to a key value that an application can pass to the <see cref="UnregisterStereoStatus"/> method
        /// to unregister the notification message that <paramref name="wMsg"/> specifies.
        /// </param>
        /// <returns>
        /// <see cref="RegisterStereoStatusWindow"/> returns:
        /// <see cref="S_OK"/> if it successfully registered the window.
        /// <see cref="E_OUTOFMEMORY"/> if memory is unavailable to complete the operation.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="RegisterStereoStatusWindow"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        public HRESULT RegisterStereoStatusWindow([In] HWND WindowHandle, [In] UINT wMsg, [Out] out DWORD pdwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, UINT, out DWORD, HRESULT>)_vTable[18])(thisPtr, WindowHandle, wMsg, out pdwCookie);
            }
        }

        /// <summary>
        /// Registers to receive notification of changes in stereo status by using event signaling.
        /// </summary>
        /// <param name="hEvent">
        /// A handle to the event object that the operating system sets when notification of stereo status change occurs.
        /// The <see cref="CreateEvent"/> or <see cref="OpenEvent"/> function returns this handle.
        /// </param>
        /// <param name="pdwCookie">
        /// A pointer to a key value that an application can pass to the <see cref="UnregisterStereoStatus"/> method
        /// to unregister the notification event that <paramref name="hEvent"/> specifies.
        /// </param>
        /// <returns>
        /// <see cref="RegisterStereoStatusEvent"/> returns:
        /// <see cref="S_OK"/> if it successfully registered the event.
        /// <see cref="E_OUTOFMEMORY"/> if memory is unavailable to complete the operation.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="RegisterStereoStatusEvent"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        public HRESULT RegisterStereoStatusEvent([In] HANDLE hEvent, [Out] out DWORD pdwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, out DWORD, HRESULT>)_vTable[19])(thisPtr, hEvent, out pdwCookie);
            }
        }

        /// <summary>
        /// Unregisters a window or an event to stop it from receiving notification when stereo status changes.
        /// </summary>
        /// <param name="dwCookie">
        /// A key value for the window or event to unregister.
        /// The <see cref="RegisterStereoStatusWindow"/> or <see cref="RegisterStereoStatusEvent"/> method returns this value.
        /// </param>
        /// <remarks>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed, <see cref="UnregisterStereoStatus"/> has no effect.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </remarks>
        public void UnregisterStereoStatus([In] DWORD dwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DWORD, void>)_vTable[20])(thisPtr, dwCookie);
            }
        }

        /// <summary>
        /// Registers an application window to receive notification messages of changes of occlusion status.
        /// </summary>
        /// <param name="WindowHandle">
        /// The handle of the window to send a notification message to when occlusion status change occurs.
        /// </param>
        /// <param name="wMsg">
        /// Identifies the notification message to send.
        /// </param>
        /// <param name="pdwCookie">
        /// A pointer to a key value that an application can pass to the <see cref="UnregisterOcclusionStatus"/> method
        /// to unregister the notification message that <paramref name="wMsg"/> specifies.
        /// </param>
        /// <returns>
        /// <see cref="RegisterOcclusionStatusWindow"/> returns:
        /// <see cref="S_OK"/> if it successfully registered the window.
        /// <see cref="E_OUTOFMEMORY"/> if memory is unavailable to complete the operation.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="RegisterOcclusionStatusWindow"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        /// <remarks>
        /// Apps choose the Windows message that Windows sends when occlusion status changes.
        /// </remarks>
        public HRESULT RegisterOcclusionStatusWindow([In] HWND WindowHandle, [In] UINT wMsg, [Out] out DWORD pdwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, UINT, out DWORD, HRESULT>)_vTable[21])(thisPtr, WindowHandle, wMsg, out pdwCookie);
            }
        }

        /// <summary>
        /// Registers to receive notification of changes in occlusion status by using event signaling.
        /// </summary>
        /// <param name="hEvent">
        /// A handle to the event object that the operating system sets when notification of occlusion status change occurs.
        /// The <see cref="CreateEvent"/> or <see cref="OpenEvent"/> function returns this handle.
        /// </param>
        /// <param name="pdwCookie">
        /// A pointer to a key value that an application can pass to the <see cref="UnregisterOcclusionStatus"/> method
        /// to unregister the notification event that <paramref name="hEvent"/> specifies.
        /// </param>
        /// <returns>
        /// <see cref="RegisterOcclusionStatusEvent"/> returns:
        /// <see cref="S_OK"/> if it successfully registered the event.
        /// <see cref="E_OUTOFMEMORY"/> if memory is unavailable to complete the operation.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="RegisterOcclusionStatusEvent "/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        /// <remarks>
        /// If you call <see cref="RegisterOcclusionStatusEvent"/> multiple times with the same event handle,
        /// <see cref="RegisterOcclusionStatusEvent"/> fails with <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// If you call <see cref="RegisterOcclusionStatusEvent"/> multiple times with the different event handles,
        /// <see cref="RegisterOcclusionStatusEvent"/> properly registers the events.
        /// </remarks>
        public HRESULT RegisterOcclusionStatusEvent([In] HANDLE hEvent, [Out] out DWORD pdwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, out DWORD, HRESULT>)_vTable[22])(thisPtr, hEvent, out pdwCookie);
            }
        }

        /// <summary>
        /// Unregisters a window or an event to stop it from receiving notification when occlusion status changes.
        /// </summary>
        /// <param name="dwCookie">
        /// A key value for the window or event to unregister.
        /// The <see cref="RegisterOcclusionStatusWindow"/> or <see cref="RegisterOcclusionStatusEvent"/> method returns this value.
        /// </param>
        /// <remarks>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed, <see cref="UnregisterStereoStatus"/> has no effect.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </remarks>
        public void UnregisterOcclusionStatus([In] DWORD dwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DWORD, void>)_vTable[23])(thisPtr, dwCookie);
            }
        }

        /// <summary>
        /// Creates a swap chain that you can use to send Direct3D content into the DirectComposition API,
        /// to the Windows.UI.Xaml framework, or to Windows UI Library (WinUI) XAML, to compose in a window.
        /// </summary>
        /// <param name="pDevice">
        /// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain.
        /// For Direct3D 12 this is a pointer to a direct command queue (refer to <see cref="ID3D12CommandQueue"/>).
        /// This parameter cannot be <see cref="NullRef{IUnknown}"/>.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_SWAP_CHAIN_DESC1"/> structure for the swap-chain description.
        /// This parameter cannot be <see cref="NullRef{DXGI_SWAP_CHAIN_DESC1}"/>.
        /// You must specify the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> value
        /// in the <see cref="DXGI_SWAP_CHAIN_DESC1.SwapEffect"/> member of <see cref="DXGI_SWAP_CHAIN_DESC1"/>
        /// because <see cref="CreateSwapChainForComposition"/> supports only flip presentation model.
        /// You must also specify the <see cref="DXGI_SCALING_STRETCH"/> value
        /// in the <see cref="DXGI_SWAP_CHAIN_DESC1.Scaling"/> member of <see cref="DXGI_SWAP_CHAIN_DESC1"/>.
        /// </param>
        /// <param name="pRestrictToOutput">
        /// A pointer to the <see cref="IDXGIOutput"/> interface for the output to restrict content to.
        /// You must also pass the <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> flag in a <see cref="IDXGISwapChain1.Present1"/> call
        /// to force the content to appear blacked out on any other output.
        /// If you want to restrict the content to a different output, you must create a new swap chain.
        /// However, you can conditionally restrict content based on the <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> flag.
        /// Set this parameter to <see cref="NullRef{IDXGIOutput}"/> if you don't want to restrict content to an output target.
        /// </param>
        /// <param name="ppSwapChain">
        /// A pointer to a variable that receives a pointer to the <see cref="IDXGISwapChain1"/> interface
        /// for the swap chain that <see cref="CreateSwapChainForComposition"/> creates.
        /// </param>
        /// <returns>
        /// <see cref="CreateSwapChainForComposition"/> returns:
        /// <see cref="S_OK"/> if it successfully created a swap chain.
        /// <see cref="E_OUTOFMEMORY"/> if memory is unavailable to complete the operation.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the calling application provided invalid data, for example,
        /// if <paramref name="pDesc"/> or <paramref name="ppSwapChain"/> is NULL.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic
        /// that are defined by the type of device that you pass to <paramref name="pDevice"/>.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="CreateSwapChainForComposition"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        /// <remarks>
        /// You can use composition swap chains with either:
        /// DirectComposition's <see cref="IDCompositionVisual"/> interface,
        /// System XAML's SwapChainPanel or SwapChainBackgroundPanel classes.
        /// Windows UI Library (WinUI) 3 XAML's SwapChainPanel or SwapChainBackgroundPanel classes.
        /// For DirectComposition, you can call the <see cref="IDCompositionVisual.SetContent"/> method
        /// to set the swap chain as the content of a visual object, which then allows you to bind the swap chain to the visual tree.
        /// For XAML, the SwapChainBackgroundPanel class exposes a classic COM interface ISwapChainBackgroundPanelNative.
        /// You can use the ISwapChainBackgroundPanelNative::SetSwapChain method to bind to the XAML UI graph.
        /// For info about how to use composition swap chains with XAML’s SwapChainBackgroundPanel class, see DirectX and XAML interop.
        /// The <see cref="IDXGISwapChain.SetFullscreenState"/>, <see cref="IDXGISwapChain.ResizeTarget"/>,
        /// <see cref="IDXGISwapChain.GetContainingOutput"/>, <see cref="IDXGISwapChain1.GetHwnd"/>,
        /// and <see cref="IDXGISwapChain.GetCoreWindow"/> methods aren't valid on this type of swap chain.
        /// If you call any of these methods on this type of swap chain, they fail.
        /// For info about how to choose a format for the swap chain's back buffer, see Converting data for the color space.
        /// </remarks>
        public HRESULT CreateSwapChainForComposition([In] in IUnknown pDevice, [In] in DXGI_SWAP_CHAIN_DESC1 pDesc,
            [In] in IDXGIOutput pRestrictToOutput, [Out] out P<IDXGISwapChain1> ppSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IUnknown, in DXGI_SWAP_CHAIN_DESC1, in IDXGIOutput, out P<IDXGISwapChain1>, HRESULT>)_vTable[24])
                    (thisPtr, pDevice, pDesc, pRestrictToOutput, out ppSwapChain);
            }
        }
    }
}
