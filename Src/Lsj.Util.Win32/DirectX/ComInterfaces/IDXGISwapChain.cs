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
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.D3D11;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_PRESENT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_CHAIN_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_EFFECT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_USAGE;
using static Lsj.Util.Win32.Dwmapi;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An <see cref="IDXGISwapChain"/> interface implements one or more surfaces
    /// for storing rendered data before presenting it to an output.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgiswapchain"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// You can create a swap chain by calling <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>,
    /// <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>, or <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
    /// You can also create a swap chain when you call <see cref="D3D11CreateDeviceAndSwapChain"/>;
    /// however, you can then only access the sub-set of swap-chain functionality
    /// that the <see cref="IDXGISwapChain"/> interface provides.
    /// </remarks>
    [ComInterface(IID = "310d36a0-d2e7-4c0a-aa04-6a9d23b8886a", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 17,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIDeviceSubObject)])]
    public unsafe struct IDXGISwapChain
    {
        IntPtr* _vTable;

        /// <summary>
        /// Presents a rendered image to the user.
        /// </summary>
        /// <param name="SyncInterval">
        /// <para>
        /// An integer that specifies how to synchronize presentation of a frame with the vertical blank.
        /// </para>
        /// <para>
        /// For the bit-block transfer (bitblt) model
        /// (<see cref="DXGI_SWAP_EFFECT_DISCARD"/> or <see cref="DXGI_SWAP_EFFECT_SEQUENTIAL"/>),
        /// values are:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// 0 - The presentation occurs immediately, there is no synchronization.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// 1 through 4 - Synchronize presentation after the nth vertical blank.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For the flip model (<see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/>), values are:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// 0 - Cancel the remaining time on the previously presented frame and discard this frame if a newer frame is queued.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// 1 through 4 - Synchronize presentation for at least n vertical blanks.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For an example that shows how sync-interval values affect a flip presentation queue, see Remarks.
        /// </para>
        /// <para>
        /// If the update region straddles more than one output (each represented by <see cref="IDXGIOutput"/>),
        /// <see cref="Present"/> performs the synchronization to the output
        /// that contains the largest sub-rectangle of the target window's client area.
        /// </para>
        /// </param>
        /// <param name="Flags">
        /// An integer value that contains swap-chain presentation options.
        /// These options are defined by the <see cref="DXGI_PRESENT"/> constants.
        /// </param>
        /// <returns>
        /// <para>
        /// Possible return values include: <see cref="S_OK"/>, <see cref="DXGI_ERROR_DEVICE_RESET"/>
        /// or <see cref="DXGI_ERROR_DEVICE_REMOVED"/> (see <see cref="DXGI_ERROR"/>),
        /// <see cref="DXGI_STATUS_OCCLUDED"/> (see <see cref="DXGI_STATUS"/>), or <see cref="D3DDDIERR_DEVICEREMOVED"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The <see cref="Present"/> method can return either <see cref="DXGI_ERROR_DEVICE_REMOVED"/> or <see cref="D3DDDIERR_DEVICEREMOVED"/>
        /// if a video card has been physically removed from the computer, or a driver upgrade for the video card has occurred.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Starting with Direct3D 11.1, consider using <see cref="IDXGISwapChain1.Present1"/>
        /// because you can then use dirty rectangles and the scroll rectangle in the swap chain presentation
        /// and as such use less memory bandwidth and as a result less system power.
        /// For more info about using dirty rectangles and the scroll rectangle in swap chain presentation,
        /// see Using dirty rectangles and the scroll rectangle in swap chain presentation.
        /// </para>
        /// <para>
        /// For the best performance when flipping swap-chain buffers in a full-screen application,
        /// see Full-Screen Application Performance Hints.
        /// </para>
        /// <para>
        /// Because calling <see cref="Present"/> might cause the render thread to wait on the message-pump thread,
        /// be careful when calling this method in an application that uses multiple threads.
        /// For more details, see Multithreading Considerations.
        /// </para>
        /// <para>
        /// <para>
        /// Differences between Direct3D 9 and Direct3D 10:
        /// </para>
        /// <para>
        /// Specifying <see cref="DXGI_PRESENT_TEST"/> in the <paramref name="Flags"/> parameter
        /// is analogous to <see cref="IDirect3DDevice9.TestCooperativeLevel"/> in Direct3D 9.
        /// </para>
        /// </para>
        /// <para>
        /// For flip presentation model swap chains that you create
        /// with the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> or <see cref="DXGI_SWAP_EFFECT_DISCARD"/> value set,
        /// a successful presentation unbinds back buffer 0
        /// (usually set by <see cref="ID3D11DeviceContext.OMSetRenderTargets"/>) from the graphics pipeline,
        /// except for when you pass the <see cref="DXGI_PRESENT_DO_NOT_SEQUENCE"/> flag in the <paramref name="Flags"/> parameter.
        /// </para>
        /// <para>
        /// For info about how data values change when you present content to the screen, see Converting data for the color space.
        /// </para>
        /// <para>
        /// Flip presentation model queue
        /// </para>
        /// <para>
        /// Suppose the following frames with sync-interval values are queued from oldest (A) to newest (E) before you call <see cref="Present"/>.
        /// </para>
        /// <para>
        /// A: 3, B: 0, C: 0, D: 1, E: 0
        /// </para>
        /// <para>
        /// When you call <see cref="Present"/>, the runtime shows frame A for only 1 vertical blank interval.
        /// The runtime terminates frame A early because of the sync interval 0 in frame B.
        /// Then the runtime shows frame D for 1 vertical blank interval, and then frame E until you submit a new presentation.
        /// The runtime discards frames B and C.
        /// </para>
        /// <para>
        /// Variable refresh rate displays
        /// </para>
        /// <para>
        /// It is a requirement of variable refresh rate displays that tearing is enabled.
        /// The <see cref="ID3D11Device.CheckFeatureSupport"/> method can be used to determine if this feature is available,
        /// and to set the required flags refer to the descriptions
        /// of <see cref="DXGI_PRESENT_ALLOW_TEARING"/> and <see cref="DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING"/>,
        /// and Variable refresh rate displays.
        /// </para>
        /// </remarks>
        public HRESULT Present([In] UINT SyncInterval, [In] DXGI_PRESENT Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, DXGI_PRESENT, HRESULT>)_vTable[8])(thisPtr, SyncInterval, Flags);
            }
        }

        /// <summary>
        /// Accesses one of the swap-chain's back buffers.
        /// </summary>
        /// <param name="Buffer">
        /// <para>
        /// A zero-based buffer index.
        /// </para>
        /// <para>
        /// If the swap chain's swap effect is <see cref="DXGI_SWAP_EFFECT_DISCARD"/>,
        /// this method can only access the first buffer; for this situation, set the index to zero.
        /// </para>
        /// <para>
        /// If the swap chain's swap effect is either <see cref="DXGI_SWAP_EFFECT_SEQUENTIAL"/>,
        /// only the swap chain's zero-index buffer can be read from and written to.
        /// The swap chain's buffers with indexes greater than zero can only be read from;
        /// so if you call the <see cref="IDXGIResource.GetUsage"/> method for such buffers,
        /// they have the <see cref="DXGI_USAGE_READ_ONLY"/> flag set.
        /// </para>
        /// <para>
        /// If the swap chain's swap effect is <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/>,
        /// the relationship between indices and buffers is consistent.
        /// The result is identical if you get the swap chain's zero-index buffer
        /// after each time <see cref="Present"/> is called.
        /// A correct frame index should be used to retrieve the current backbuffer.
        /// </para>
        /// </param>
        /// <param name="riid">
        /// The type of interface used to manipulate the buffer.
        /// </param>
        /// <param name="ppSurface">
        /// A pointer to a back-buffer interface.
        /// </param>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        public HRESULT GetBuffer([In] UINT Buffer, [In] in IID riid, [Out] out IntPtr ppSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, in IID, out IntPtr, HRESULT>)_vTable[9])(thisPtr, Buffer, riid, out ppSurface);
            }
        }

        /// <summary>
        /// Sets the display state to windowed or full screen.
        /// </summary>
        /// <param name="Fullscreen">
        /// A Boolean value that specifies whether to set the display state to windowed or full screen.
        /// <see cref="TRUE"/> for full screen, and <see cref="FALSE"/> for windowed.
        /// </param>
        /// <param name="pTarget">
        /// If you pass <see cref="TRUE"/> to the <paramref name="Fullscreen"/> parameter to set the display state to full screen,
        /// you can optionally set this parameter to a pointer to an <see cref="IDXGIOutput"/> interface
        /// for the output target that contains the swap chain.
        /// If you set this parameter to <see cref="NULL"/>,
        /// DXGI will choose the output based on the swap-chain's device and the output window's placement.
        /// If you pass <see cref="FALSE"/> to Fullscreen, then you must set this parameter to <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// This method returns one of these values.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if the action succeeded and the swap chain was placed in the requested state.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/> if the action failed.
        /// When this error is returned, your application can continue to run in windowed mode
        /// and try to switch to full-screen mode later.
        /// There are many reasons why a windowed-mode swap chain cannot switch to full-screen mode.
        /// Here are some examples.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The application is running over Terminal Server.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The output window is occluded.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The output window does not have keyboard focus.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Another application is already in full-screen mode.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_STATUS_MODE_CHANGE_IN_PROGRESS"/> is returned
        /// if a fullscreen/windowed mode transition is occurring when this API is called.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Other error codes if you run out of memory or encounter another unexpected fault;
        /// these codes may be treated as hard, non-continuable errors.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// DXGI may change the display state of a swap chain in response to end user or system requests.
        /// </para>
        /// <para>
        /// We recommend that you create a windowed swap chain and allow the end user
        /// to change the swap chain to full screen through <see cref="SetFullscreenState"/>;
        /// that is, do not set the <see cref="DXGI_SWAP_CHAIN_DESC.Windowed"/> member
        /// of <see cref="DXGI_SWAP_CHAIN_DESC"/> to <see cref="FALSE"/> to force the swap chain to be full screen.
        /// However, if you create the swap chain as full screen,
        /// also provide the end user with a list of supported display modes
        /// because a swap chain that is created with an unsupported display mode
        /// might cause the display to go black and prevent the end user from seeing anything.
        /// Also, we recommend that you have a time-out confirmation screen or other fallback mechanism
        /// when you allow the end user to change display modes.
        /// </para>
        /// <para>
        /// Notes for Windows Store apps
        /// </para>
        /// <para>
        /// If a Windows Store app calls <see cref="SetFullscreenState"/> to set the display state to full screen,
        /// <see cref="SetFullscreenState"/> fails with <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/>.
        /// </para>
        /// <para>
        /// You cannot call <see cref="SetFullscreenState"/> on a swap chain
        /// that you created with <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
        /// </para>
        /// <para>
        /// For the flip presentation model, after you transition the display state to full screen,
        /// you must call <see cref="ResizeBuffers"/> to ensure that your call to <see cref="IDXGISwapChain1.Present1"/> succeeds.
        /// </para>
        /// </remarks>
        public HRESULT SetFullscreenState([In] BOOL Fullscreen, [In] P<IDXGIOutput> pTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, P<IDXGIOutput>, HRESULT>)_vTable[10])(thisPtr, Fullscreen, pTarget);
            }
        }

        /// <summary>
        /// Get the state associated with full-screen mode.
        /// </summary>
        /// <param name="Fullscreen">
        /// <para>
        /// A pointer to a boolean whose value is either:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="TRUE"/> if the swap chain is in full-screen mode
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FALSE"/> if the swap chain is in windowed mode
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="ppTarget">
        /// A pointer to the output target (see <see cref="IDXGIOutput"/>) when the mode is full screen;
        /// otherwise <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// When the swap chain is in full-screen mode,
        /// a pointer to the target output will be returned and its reference count will be incremented.
        /// </remarks>
        public HRESULT GetFullscreenState([Out] out BOOL Fullscreen, [Out] out P<IDXGIOutput> ppTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOL, out P<IDXGIOutput>, HRESULT>)_vTable[11])(thisPtr, out Fullscreen, out ppTarget);
            }
        }

        /// <summary>
        /// Get a description of the swap chain.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to the swap-chain description (see <see cref="DXGI_SWAP_CHAIN_DESC"/>).
        /// </param>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        [Obsolete("Starting with Direct3D 11.1, we recommend not to use GetDesc anymore to get a description of the swap chain. " +
            "Instead, use IDXGISwapChain1::GetDesc1.")]
        public HRESULT GetDesc([Out] out DXGI_SWAP_CHAIN_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_SWAP_CHAIN_DESC, HRESULT>)_vTable[12])(thisPtr, out pDesc);
            }
        }

        /// <summary>
        /// Changes the swap chain's back buffer size, format, and number of buffers.
        /// This should be called when the application window is resized.
        /// </summary>
        /// <param name="BufferCount">
        /// The number of buffers in the swap chain (including all back and front buffers).
        /// This number can be different from the number of buffers with which you created the swap chain.
        /// This number can't be greater than <see cref="DXGI_MAX_SWAP_CHAIN_BUFFERS"/>.
        /// Set this number to zero to preserve the existing number of buffers in the swap chain.
        /// You can't specify less than two buffers for the flip presentation model.
        /// </param>
        /// <param name="Width">
        /// The new width of the back buffer.
        /// If you specify zero, DXGI will use the width of the client area of the target window.
        /// You can't specify the width as zero if you called the <see cref="IDXGIFactory2.CreateSwapChainForComposition"/> method
        /// to create the swap chain for a composition surface.
        /// </param>
        /// <param name="Height">
        /// The new height of the back buffer.
        /// If you specify zero, DXGI will use the height of the client area of the target window.
        /// You can't specify the height as zero if you called the <see cref="IDXGIFactory2.CreateSwapChainForComposition"/> method
        /// to create the swap chain for a composition surface.
        /// </param>
        /// <param name="NewFormat">
        /// A <see cref="DXGI_FORMAT"/>-typed value for the new format of the back buffer.
        /// Set this value to <see cref="DXGI_FORMAT_UNKNOWN"/> to preserve the existing format of the back buffer.
        /// The flip presentation model supports a more restricted set of formats than the bit-block transfer (bitblt) model.
        /// </param>
        /// <param name="SwapChainFlags">
        /// A combination of <see cref="DXGI_SWAP_CHAIN_FLAG"/>-typed values
        /// that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for swap-chain behavior.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// You can't resize a swap chain unless you release all outstanding references to its back buffers.
        /// You must release all of its direct and indirect references on the back buffers
        /// in order for <see cref="ResizeBuffers"/> to succeed.
        /// </para>
        /// <para>
        /// Direct references are held by the application after it calls <see cref="IUnknown.AddRef"/> on a resource.
        /// </para>
        /// <para>
        /// Indirect references are held by views to a resource, binding a view of the resource to a device context,
        /// a command list that used the resource, a command list that used a view to that resource,
        /// a command list that executed another command list that used the resource, and so on.
        /// </para>
        /// <para>
        /// Before you call <see cref="ResizeBuffers"/>, ensure that the application releases all references
        /// (by calling the appropriate number of <see cref="IUnknown.Release"/> invocations) on the resources,
        /// any views to the resource, and any command lists that use either the resources or views,
        /// and ensure that neither the resource nor a view is still bound to a device context.
        /// You can use <see cref="ID3D11DeviceContext.ClearState"/> to ensure that all references are released.
        /// If a view is bound to a deferred context, you must discard the partially built command list as well
        /// (by calling <see cref="ID3D11DeviceContext.ClearState"/>, then <see cref="ID3D11DeviceContext.FinishCommandList"/>,
        /// then <see cref="IUnknown.Release"/> on the command list).
        /// After you call <see cref="ResizeBuffers"/>, you can re-query interfaces via <see cref="GetBuffer"/>.
        /// </para>
        /// <para>
        /// For swap chains that you created with <see cref="DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE"/>,
        /// before you call <see cref="ResizeBuffers"/>, also call <see cref="IDXGISurface1.ReleaseDC"/>
        /// on the swap chain's back-buffer surface to ensure that you have no outstanding GDI device contexts (DCs) open.
        /// </para>
        /// <para>
        /// We recommend that you call <see cref="ResizeBuffers"/> when a client window is resized
        /// (that is, when an application receives a <see cref="WM_SIZE"/> message).
        /// </para>
        /// <para>
        /// The only difference between <see cref="ResizeBuffers"/> in Windows 8 versus Windows 7
        /// is with flip presentation model swap chains
        /// that you create with the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> or <see cref="DXGI_SWAP_EFFECT_FLIP_DISCARD"/> value set.
        /// In Windows 8, you must call <see cref="ResizeBuffers"/> to realize a transition between full-screen mode and windowed mode;
        /// otherwise, your next call to the <see cref="Present"/> method fails.
        /// </para>
        /// </remarks>
        public HRESULT ResizeBuffers([In] UINT BufferCount, [In] UINT Width, [In] UINT Height, [In] DXGI_FORMAT NewFormat, [In] DXGI_SWAP_CHAIN_FLAG SwapChainFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, DXGI_FORMAT, DXGI_SWAP_CHAIN_FLAG, HRESULT>)_vTable[13])
                    (thisPtr, BufferCount, Width, Height, NewFormat, SwapChainFlags);
            }
        }

        /// <summary>
        /// Resizes the output target.
        /// </summary>
        /// <param name="pNewTargetParameters">
        /// A pointer to a <see cref="DXGI_MODE_DESC"/> structure that describes the mode,
        /// which specifies the new width, height, format, and refresh rate of the target.
        /// If the format is <see cref="DXGI_FORMAT_UNKNOWN"/>, <see cref="ResizeTarget"/> uses the existing format.
        /// We only recommend that you use <see cref="DXGI_FORMAT_UNKNOWN"/>
        /// when the swap chain is in full-screen mode as this method is not thread safe.
        /// </param>
        /// <returns>
        /// Returns a code that indicates success or failure.
        /// <see cref="DXGI_STATUS_MODE_CHANGE_IN_PROGRESS"/> is returned
        /// if a full-screen/windowed mode transition is occurring when this API is called.
        /// See <see cref="DXGI_ERROR"/> for additional DXGI error codes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="ResizeTarget"/> resizes the target window
        /// when the swap chain is in windowed mode, and changes the display mode on the target output
        /// when the swap chain is in full-screen mode.
        /// Therefore, apps can call <see cref="ResizeTarget"/> to resize the target window
        /// (rather than a Microsoft Win32API such as <see cref="SetWindowPos"/>) without knowledge of the swap chain display mode.
        /// </para>
        /// <para>
        /// If a Windows Store app calls <see cref="ResizeTarget"/>, it fails with <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/>.
        /// </para>
        /// <para>
        /// You cannot call <see cref="ResizeTarget"/> on a swap chain
        /// that you created with <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
        /// </para>
        /// <para>
        /// Apps must still call <see cref="ResizeBuffers"/> after they call <see cref="ResizeTarget"/>
        /// because only <see cref="ResizeBuffers"/> can change the back buffers.
        /// But, if those apps have implemented window resize processing to call <see cref="ResizeBuffers"/>,
        /// they don't need to explicitly call <see cref="ResizeBuffers"/> after they call <see cref="ResizeTarget"/>
        /// because the window resize processing will achieve what the app requires.
        /// </para>
        /// </remarks>
        public HRESULT ResizeTarget([In] in DXGI_MODE_DESC pNewTargetParameters)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in DXGI_MODE_DESC, HRESULT>)_vTable[14])(thisPtr, pNewTargetParameters);
            }
        }

        /// <summary>
        /// Get the output (the display monitor) that contains the majority of the client area of the target window.
        /// </summary>
        /// <param name="ppOutput">
        /// A pointer to the output interface (see <see cref="IDXGIOutput"/>).
        /// </param>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the method succeeds, the output interface will be filled and its reference count incremented.
        /// When you are finished with it, be sure to release the interface to avoid a memory leak.
        /// </para>
        /// <para>
        /// The output is also owned by the adapter on which the swap chain's device was created.
        /// </para>
        /// <para>
        /// You cannot call <see cref="GetContainingOutput"/> on a swap chain
        /// that you created with <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
        /// </para>
        /// <para>
        /// To determine the output corresponding to such a swap chain,
        /// you should call <see cref="IDXGIFactory.EnumAdapters"/>
        /// and then <see cref="IDXGIAdapter.EnumOutputs"/> to enumerate over all of the available outputs.
        /// You should then intersect the bounds of your CoreWindow.Bounds with the desktop coordinates of each output,
        /// as reported by <see cref="DXGI_OUTPUT_DESC1.DesktopCoordinates"/> or <see cref="DXGI_OUTPUT_DESC.DesktopCoordinates"/>.
        /// </para>
        /// </remarks>
        public HRESULT GetContainingOutput([Out] out P<IDXGIOutput> ppOutput)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDXGIOutput>, HRESULT>)_vTable[15])(thisPtr, out ppOutput);
            }
        }

        /// <summary>
        /// Gets performance statistics about the last render frame.
        /// </summary>
        /// <param name="pStats">
        /// A pointer to a <see cref="DXGI_FRAME_STATISTICS"/> structure for the frame statistics.
        /// </param>
        /// <returns>
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </returns>
        /// <remarks>
        /// <para>
        /// You cannot use <see cref="GetFrameStatistics"/> for swap chains
        /// that both use the bit-block transfer (bitblt) presentation model and draw in windowed mode.
        /// </para>
        /// <para>
        /// You can only use <see cref="GetFrameStatistics"/> for swap chains
        /// that either use the flip presentation model or draw in full-screen mode.
        /// You set the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> value
        /// in the <see cref="DXGI_SWAP_CHAIN_DESC1.SwapEffect"/> member of the <see cref="DXGI_SWAP_CHAIN_DESC1"/> structure
        /// to specify that the swap chain uses the flip presentation model.
        /// </para>
        /// <para>
        /// Statistics are not reliable in many multiple monitor scenarios,
        /// as well as scenarios where other fullscreen apps are running.
        /// </para>
        /// <para>
        /// It may be necessary to call <see cref="DwmFlush"/>
        /// before frame statistics are updated on systems that support Hardware Flip Queue.
        /// </para>
        /// </remarks>
        public HRESULT GetFrameStatistics([Out] out DXGI_FRAME_STATISTICS pStats)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_FRAME_STATISTICS, HRESULT>)_vTable[16])(thisPtr, out pStats);
            }
        }

        /// <summary>
        /// Gets the number of times that <see cref="Present"/> or <see cref="IDXGISwapChain1.Present1"/> has been called.
        /// </summary>
        /// <param name="pLastPresentCount">
        /// A pointer to a variable that receives the number of calls.
        /// </param>
        /// <returns>
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </returns>
        /// <remarks>
        /// For info about presentation statistics for a frame, see <see cref="DXGI_FRAME_STATISTICS"/>.
        /// </remarks>
        public HRESULT GetLastPresentCount([Out] out UINT pLastPresentCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[17])(thisPtr, out pLastPresentCount);
            }
        }
    }
}
