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
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ALPHA_MODE;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_MODE_ROTATION;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_PRESENT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SCALING;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_CHAIN_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_EFFECT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.DirectX.D3D11;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides presentation capabilities that are enhanced from <see cref="IDXGISwapChain"/>.
    /// These presentation capabilities consist of specifying dirty rectangles and scroll rectangle to optimize the presentation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgiswapchain1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// You can create a swap chain by calling <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>,
    /// <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>, or <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
    /// You can also create a swap chain when you call <see cref="D3D11CreateDeviceAndSwapChain"/>;
    /// however, you can then only access the sub-set of swap-chain functionality that the <see cref="IDXGISwapChain"/> interface provides.
    /// </para>
    /// <para>
    /// <see cref="IDXGISwapChain1"/> provides the <see cref="IsTemporaryMonoSupported"/> method
    /// that you can use to determine whether the swap chain supports "temporary mono” presentation.
    /// This type of swap chain is a stereo swap chain that can be used to present mono content.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// Some stereo features like the advanced presentation flags are not represented by an explicit interface change.
    /// Furthermore, the original (<see cref="IDXGISwapChain"/>)
    /// and new (<see cref="IDXGISwapChain1"/>) swap chain interfaces generally have the same behavior.
    /// For information about how <see cref="IDXGISwapChain"/> methods
    /// are translated into <see cref="IDXGISwapChain1"/> methods,
    /// see the descriptions of the <see cref="IDXGISwapChain1"/> methods.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "790a45f7-0d42-4876-983a-0a55cfe6f4aa", BeginVTableSlotIndex = 18, EndVTableSlotIndex = 28,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIDeviceSubObject), typeof(IDXGISwapChain)])]
    public unsafe struct IDXGISwapChain1
    {
        nint* _vTable;

        /// <summary>
        /// Gets a description of the swap chain.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_SWAP_CHAIN_DESC1"/> structure that describes the swap chain.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        public HRESULT GetDesc1([Out] out DXGI_SWAP_CHAIN_DESC1 pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_SWAP_CHAIN_DESC1, HRESULT>)_vTable[18])(thisPtr, out pDesc);
            }
        }

        /// <summary>
        /// Gets a description of a full-screen swap chain.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_SWAP_CHAIN_FULLSCREEN_DESC"/> structure that describes the full-screen swap chain.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="GetFullscreenDesc"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully retrieved the description of the full-screen swap chain.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> for non-<see cref="HWND"/> swap chains
        /// or if <paramref name="pDesc"/> is <see cref="NullRef{DXGI_SWAP_CHAIN_FULLSCREEN_DESC}"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The semantics of <see cref="GetFullscreenDesc"/> are identical
        /// to that of the <see cref="IDXGISwapChain.GetDesc"/> method for HWND-based swap chains.
        /// </remarks>
        public HRESULT GetFullscreenDesc([Out] out DXGI_SWAP_CHAIN_FULLSCREEN_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_SWAP_CHAIN_FULLSCREEN_DESC, HRESULT>)_vTable[19])(thisPtr, out pDesc);
            }
        }

        /// <summary>
        /// Retrieves the underlying <see cref="HWND"/> for this swap-chain object.
        /// </summary>
        /// <param name="pHwnd">
        /// A pointer to a variable that receives the <see cref="HWND"/> for the swap-chain object.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </para>
        /// <para>
        /// If <paramref name="pHwnd"/> receives <see cref="NULL"/> (that is, the swap chain is not <see cref="HWND"/>-based),
        /// <see cref="GetHwnd"/> returns <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Applications call the <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/> method
        /// to create a swap chain that is associated with an <see cref="HWND"/>.
        /// </remarks>
        public HRESULT GetHwnd([Out] out HWND pHwnd)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out HWND, HRESULT>)_vTable[20])(thisPtr, out pHwnd);
            }
        }

        /// <summary>
        /// Retrieves the underlying CoreWindow object for this swap-chain object.
        /// </summary>
        /// <param name="refiid">
        /// A pointer to the globally unique identifier (GUID) of the CoreWindow object
        /// that is referenced by the <paramref name="ppUnk"/> parameter.
        /// </param>
        /// <param name="ppUnk">
        /// A pointer to a variable that receives a pointer to the CoreWindow object.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="GetCoreWindow"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully retrieved the underlying CoreWindow object.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if <paramref name="ppUnk"/> is <see cref="NULL"/>;
        /// that is, the swap chain is not associated with a CoreWindow object.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any <see cref="HRESULT"/> that a call to <see cref="IUnknown.QueryInterface"/>
        /// to query for an CoreWindow object might typically return.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="GetCoreWindow"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Applications call the <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/> method
        /// 
        /// to create a swap chain that is associated with an CoreWindow object.
        /// </remarks>
        public HRESULT GetCoreWindow([In] in IID refiid, [Out] out nint ppUnk)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out nint, HRESULT>)_vTable[21])(thisPtr, refiid, out ppUnk);
            }
        }

        /// <summary>
        /// Presents a frame on the display screen.
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
        /// If the update region straddles more than one output (each represented by <see cref="IDXGIOutput1"/>),
        /// <see cref="Present1"/> performs the synchronization to the output
        /// that contains the largest sub-rectangle of the target window's client area.
        /// </para>
        /// </param>
        /// <param name="PresentFlags">
        /// An integer value that contains swap-chain presentation options.
        /// These options are defined by the <see cref="DXGI_PRESENT"/> constants.
        /// </param>
        /// <param name="pPresentParameters">
        /// A pointer to a <see cref="DXGI_PRESENT_PARAMETERS"/> structure
        /// that describes updated rectangles and scroll information of the frame to present.
        /// </param>
        /// <returns>
        /// Possible return values include: <see cref="S_OK"/>, <see cref="DXGI_ERROR_DEVICE_REMOVED"/>,
        /// <see cref="DXGI_STATUS_OCCLUDED"/>, <see cref="DXGI_ERROR_INVALID_CALL"/>, or <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An app can use <see cref="Present1"/> to optimize presentation by specifying scroll and dirty rectangles.
        /// When the runtime has information about these rectangles,
        /// the runtime can then perform necessary bitblts during presentation more efficiently
        /// and pass this metadata to the Desktop Window Manager (DWM).
        /// The DWM can then use the metadata to optimize presentation and pass the metadata
        /// to indirect displays and terminal servers to optimize traffic over the wire.
        /// An app must confine its modifications to only the dirty regions that it passes to <see cref="Present1"/>,
        /// as well as modify the entire dirty region to avoid undefined resource contents from being exposed.
        /// </para>
        /// <para>
        /// For flip presentation model swap chains that you create with the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> value set,
        /// a successful presentation results in an unbind of back buffer 0 from the graphics pipeline,
        /// except for when you pass the <see cref="DXGI_PRESENT_DO_NOT_SEQUENCE"/> flag in the <paramref name="PresentFlags"/> parameter.
        /// </para>
        /// <para>
        /// For info about how data values change when you present content to the screen, see Converting data for the color space.
        /// </para>
        /// <para>
        /// For info about calling <see cref="Present1"/> when your app uses multiple threads,
        /// see Multithread Considerations and Multithreading and DXGI.
        /// </para>
        /// <para>
        /// Flip presentation model queue
        /// </para>
        /// <para>
        /// Suppose the following frames with sync-interval values are queued
        /// from oldest (A) to newest (E) before you call <see cref="Present1"/>.
        /// </para>
        /// <para>
        /// A: 3, B: 0, C: 0, D: 1, E: 0
        /// </para>
        /// <para>
        /// When you call <see cref="Present1"/>, the runtime shows frame A for only 1 vertical blank interval.
        /// The runtime terminates frame A early because of the sync interval 0 in frame B.
        /// Then the runtime shows frame D for 1 vertical blank interval, and then frame E until you submit a new presentation.
        /// The runtime discards frames B and C.
        /// </para>
        /// <para>
        /// Variable refresh rate displays
        /// </para>
        /// <para>
        /// It is a requirement of variable refresh rate displays that tearing is enabled.
        /// The <see cref="ID3D11Device.CheckFeatureSupport"/> method can be used to determine
        /// if this feature is available, and to set the required flags refer to
        /// the descriptions of <see cref="DXGI_PRESENT_ALLOW_TEARING"/> and <see cref="DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING"/>,
        /// and the Variable refresh rate displays/Vsync off section of DXGI 1.5 Improvements.
        /// </para>
        /// </remarks>
        public HRESULT Present1([In] UINT SyncInterval, [In] DXGI_PRESENT PresentFlags, [In] in DXGI_PRESENT_PARAMETERS pPresentParameters)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, DXGI_PRESENT, in DXGI_PRESENT_PARAMETERS, HRESULT>)_vTable[22])
                    (thisPtr, SyncInterval, PresentFlags, pPresentParameters);
            }
        }

        /// <summary>
        /// Determines whether a swap chain supports “temporary mono.”
        /// </summary>
        /// <returns>
        /// <para>
        /// Indicates whether to use the swap chain in temporary mono mode.
        /// <see cref="TRUE"/> indicates that you can use temporary-mono mode;
        /// otherwise, <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="IsTemporaryMonoSupported"/> always returns <see cref="FALSE"/>
        /// because stereoscopic 3D display behavior isn’t available with the Platform Update for Windows 7.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Temporary mono is a feature where a stereo swap chain can be presented using only the content in the left buffer.
        /// To present using the left buffer as a mono buffer,
        /// an application calls the <see cref="Present1"/> method with the <see cref="DXGI_PRESENT_STEREO_TEMPORARY_MONO"/> flag.
        /// All windowed swap chains support temporary mono.
        /// However, full-screen swap chains optionally support temporary mono
        /// because not all hardware supports temporary mono on full-screen swap chains efficiently.
        /// </remarks>
        public BOOL IsTemporaryMonoSupported()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[23])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the output (the display monitor) to which you can restrict the contents of a present operation.
        /// </summary>
        /// <param name="ppRestrictToOutput">
        /// A pointer to a buffer that receives a pointer to the <see cref="IDXGIOutput"/> interface for the restrict-to output.
        /// An application passes this pointer to <see cref="IDXGIOutput"/>
        /// in a call to the <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>,
        /// <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>,
        /// or <see cref="IDXGIFactory2.CreateSwapChainForComposition"/> method to create the swap chain.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the restrict-to output was successfully retrieved;
        /// otherwise, returns <see cref="E_INVALIDARG"/> if the pointer is invalid.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the method succeeds, the runtime fills the buffer at <paramref name="ppRestrictToOutput"/>
        /// with a pointer to the restrict-to output interface.
        /// This restrict-to output interface has its reference count incremented.
        /// When you are finished with it, be sure to release the interface to avoid a memory leak.
        /// </para>
        /// <para>
        /// The output is also owned by the adapter on which the swap chain's device was created.
        /// </para>
        /// </remarks>
        public HRESULT GetRestrictToOutput([Out] out P<IDXGIOutput> ppRestrictToOutput)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDXGIOutput>, HRESULT>)_vTable[24])(thisPtr, out ppRestrictToOutput);
            }
        }

        /// <summary>
        /// Changes the background color of the swap chain.
        /// </summary>
        /// <param name="pColor">
        /// A pointer to a <see cref="DXGI_RGBA"/> structure that specifies the background color to set.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="SetBackgroundColor"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully set the background color.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_INVALIDARG"/> if the <paramref name="pColor"/> parameter is incorrect,
        /// for example, <paramref name="pColor"/> is <see cref="NullRef{DXGI_RGBA}"/>
        /// or any of the floating-point values of the members of <see cref="DXGI_RGBA"/>
        /// to which <paramref name="pColor"/> points are outside the range from 0.0 through 1.0.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="SetBackgroundColor"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The background color affects only swap chains that you create with <see cref="DXGI_SCALING_NONE"/> in windowed mode.
        /// You pass this value in a call to <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>,
        /// <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>, or <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
        /// Typically, the background color is not visible unless the swap-chain contents are smaller than the destination window.
        /// </para>
        /// <para>
        /// When you set the background color, it is not immediately realized.
        /// It takes effect in conjunction with your next call to the <see cref="Present1"/> method.
        /// The <see cref="DXGI_PRESENT"/> flags that you pass to <see cref="Present1"/> can help achieve the effect that you require.
        /// For example, if you call <see cref="SetBackgroundColor"/>
        /// and then call <see cref="Present1"/> with the Flags parameter set to <see cref="DXGI_PRESENT_DO_NOT_SEQUENCE"/>,
        /// you change only the background color without changing the displayed contents of the swap chain.
        /// </para>
        /// <para>
        /// When you call the <see cref="Present1"/> method to display contents of the swap chain,
        /// <see cref="Present1"/> uses the <see cref="DXGI_ALPHA_MODE"/> value that is specified
        /// in the <see cref="DXGI_SWAP_CHAIN_DESC1.AlphaMode"/> member of the <see cref="DXGI_SWAP_CHAIN_DESC1"/> structure to determine
        /// how to handle the a member of the <see cref="DXGI_RGBA"/> structure,
        /// the alpha value of the background color, that achieves window transparency.
        /// For example, if <see cref="DXGI_SWAP_CHAIN_DESC1.AlphaMode"/> is <see cref="DXGI_ALPHA_MODE_IGNORE"/>,
        /// <see cref="Present1"/> ignores the a member of <see cref="DXGI_RGBA"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Like all presentation data, we recommend that you perform floating point operations in a linear color space.
        /// When the desktop is in a fixed bit color depth mode, the operating system converts linear color data
        /// to standard RGB data (sRGB, gamma 2.2 corrected space) to compose to the screen.
        /// For more info, see Converting data for the color space.
        /// </para>
        /// </remarks>
        public HRESULT SetBackgroundColor([In] in DXGI_RGBA pColor)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in DXGI_RGBA, HRESULT>)_vTable[25])(thisPtr, pColor);
            }
        }

        /// <summary>
        /// Retrieves the background color of the swap chain.
        /// </summary>
        /// <param name="pColor">
        /// A pointer to a <see cref="DXGI_RGBA"/> structure that receives the background color of the swap chain.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="GetBackgroundColor"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully retrieves the background color.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the <paramref name="pColor"/> parameter is invalid,
        /// for example, <paramref name="pColor"/> is <see cref="NullRef{DXGI_RGBA}"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// Note
        /// The background color that <see cref="GetBackgroundColor"/> retrieves 
        /// does not indicate what the screen currently displays.
        /// The background color indicates what the screen will display with your next call to the <see cref="Present1"/> method.
        /// The default value of the background color is black with full opacity: 0,0,0,1.
        /// </remarks>
        public HRESULT GetBackgroundColor([Out] out DXGI_RGBA pColor)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_RGBA, HRESULT>)_vTable[26])(thisPtr, out pColor);
            }
        }

        /// <summary>
        /// Sets the rotation of the back buffers for the swap chain.
        /// </summary>
        /// <param name="Rotation">
        /// A <see cref="DXGI_MODE_ROTATION"/>-typed value that specifies how to set the rotation of the back buffers for the swap chain.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="SetRotation"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully set the rotation.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the swap chain is bit-block transfer (bitblt) model.
        /// The swap chain must be flip model to successfully call <see cref="SetRotation"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="SetRotation"/> fails with <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You can only use <see cref="SetRotation"/> to rotate the back buffers
        /// for flip-model swap chains that you present in windowed mode.
        /// </para>
        /// <para>
        /// <see cref="SetRotation"/> isn't supported for rotating the back buffers for flip-model swap chains
        /// that you present in full-screen mode.
        /// In this situation, <see cref="SetRotation"/> doesn't fail,
        /// but you must ensure that you specify no rotation (<see cref="DXGI_MODE_ROTATION_IDENTITY"/>) for the swap chain.
        /// Otherwise, when you call <see cref="Present1"/> or <see cref="IDXGISwapChain.Present"/> to present a frame, the presentation fails.
        /// </para>
        /// </remarks>
        public HRESULT SetRotation([In] DXGI_MODE_ROTATION Rotation)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_MODE_ROTATION, HRESULT>)_vTable[27])(thisPtr, Rotation);
            }
        }

        /// <summary>
        /// Gets the rotation of the back buffers for the swap chain.
        /// </summary>
        /// <param name="pRotation">
        /// A pointer to a variable that receives a <see cref="DXGI_MODE_ROTATION"/>-typed value
        /// that specifies the rotation of the back buffers for the swap chain.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </para>
        /// <para>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="GetRotation"/> fails with <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </para>
        /// </returns>
        public HRESULT GetRotation([Out] out DXGI_MODE_ROTATION pRotation)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_MODE_ROTATION, HRESULT>)_vTable[28])(thisPtr, out pRotation);
            }
        }
    }
}
