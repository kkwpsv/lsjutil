using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_CHAIN_FLAG;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends <see cref="IDXGISwapChain1"/> with methods to support swap back buffer scaling and lower-latency swap chains.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nn-dxgi1_3-idxgiswapchain2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// You can create a swap chain by calling <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>,
    /// <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>, or <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
    [ComInterface(IID = "a8be2ac4-199f-4946-b331-79599fb98de7", BeginVTableSlotIndex = 29, EndVTableSlotIndex = 35,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIDeviceSubObject), typeof(IDXGISwapChain), typeof(IDXGISwapChain1)])]
    public unsafe struct IDXGISwapChain2
    {
        IntPtr* _vTable;

        /// <summary>
        /// <para>
        /// Sets the source region to be used for the swap chain.
        /// </para>
        /// <para>
        /// Use <see cref="SetSourceSize"/> to specify the portion of the swap chain from which the operating system presents.
        /// This allows an effective resize without calling the more-expensive <see cref="IDXGISwapChain.ResizeBuffers"/> method.
        /// Prior to Windows 8.1, calling <see cref="IDXGISwapChain.ResizeBuffers"/> was the only way to resize the swap chain.
        /// The source rectangle is always defined by the region [0, 0, Width, Height].
        /// </para>
        /// </summary>
        /// <param name="Width">
        /// Source width to use for the swap chain.
        /// This value must be greater than zero, and must be less than or equal to the overall width of the swap chain.
        /// </param>
        /// <param name="Height">
        /// Source height to use for the swap chain.
        /// This value must be greater than zero, and must be less than or equal to the overall height of the swap chain.
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="E_INVALIDARG"/> if one or more parameters exceed the size of the back buffer.
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
        public HRESULT SetSourceSize([In] UINT Width, [In] UINT Height)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, HRESULT>)_vTable[29])(thisPtr, Width, Height);
            }
        }

        /// <summary>
        /// <para>
        /// Gets the source region used for the swap chain.
        /// </para>
        /// <para>
        /// Use <see cref="GetSourceSize"/> to get the portion of the swap chain from which the operating system presents.
        /// The source rectangle is always defined by the region [0, 0, Width, Height].
        /// Use <see cref="SetSourceSize"/> to set this portion of the swap chain.
        /// </para>
        /// </summary>
        /// <param name="pWidth">
        /// The current width of the source region of the swap chain.
        /// This value can range from 1 to the overall width of the swap chain.
        /// </param>
        /// <param name="pHeight">
        /// The current height of the source region of the swap chain.
        /// This value can range from 1 to the overall height of the swap chain.
        /// </param>
        /// <returns>
        /// This method can return error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT GetSourceSize([Out] out UINT pWidth, [Out] out UINT pHeight)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, out UINT, HRESULT>)_vTable[30])(thisPtr, out pWidth, out pHeight);
            }
        }

        /// <summary>
        /// Sets the number of frames that the swap chain is allowed to queue for rendering.
        /// </summary>
        /// <param name="MaxLatency">
        /// The maximum number of back buffer frames that will be queued for the swap chain.
        /// This value is 1 by default.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, <see cref="DXGI_ERROR_DEVICE_REMOVED"/> if the device was removed.
        /// </returns>
        /// <remarks>
        /// This method is only valid for use on swap chains
        /// created with <see cref="DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT"/>.
        /// Otherwise, the result will be <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// </remarks>
        public HRESULT SetMaximumFrameLatency([In] UINT MaxLatency)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[31])(thisPtr, MaxLatency);
            }
        }

        /// <summary>
        /// Gets the number of frames that the swap chain is allowed to queue for rendering.
        /// </summary>
        /// <param name="pMaxLatency">
        /// The maximum number of back buffer frames that will be queued for the swap chain.
        /// This value is 1 by default, but should be set to 2
        /// if the scene takes longer than it takes for one vertical refresh (typically about 16ms) to draw.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns one of the following members of the <see cref="D3DERR"/> enumerated type:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3DERR_DEVICELOST"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3DERR_DEVICEREMOVED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3DERR_DRIVERINTERNALERROR"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3DERR_INVALIDCALL"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3DERR_OUTOFVIDEOMEMORY"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT GetMaximumFrameLatency([Out] out UINT pMaxLatency)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[32])(thisPtr, out pMaxLatency);
            }
        }

        /// <summary>
        /// <para>
        /// Returns a waitable handle that signals
        /// when the DXGI adapter has finished presenting a new frame.
        /// </para>
        /// <para>
        /// Windows 8.1 introduces new APIs that allow lower-latency rendering by waiting
        /// until the previous frame is presented to the display before drawing the next frame.
        /// To use this method, first create the DXGI swap chain
        /// with the <see cref="DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT"/> flag set,
        /// then call <see cref="GetFrameLatencyWaitableObject"/> to retrieve the waitable handle.
        /// Use the waitable handle with <see cref="WaitForSingleObjectEx"/>
        /// to synchronize rendering of each new frame with the end of the previous frame.
        /// For every frame it renders, the app should wait on this handle before starting any rendering operations.
        /// Note that this requirement includes the first frame the app renders with the swap chain.
        /// See the DirectXLatency sample.
        /// When you are done with the handle, use <see cref="CloseHandle"/> to close it.
        /// </para>
        /// </summary>
        /// <returns>
        /// A handle to the waitable object,
        /// or <see cref="NULL"/> if the swap chain was not created with <see cref="DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT"/>.
        /// </returns>
        /// <remarks>
        /// When an application is finished using the object handle returned by <see cref="GetFrameLatencyWaitableObject"/>,
        /// use the <see cref="CloseHandle"/> function to close the handle.
        /// </remarks>
        public HANDLE GetFrameLatencyWaitableObject()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE>)_vTable[33])(thisPtr);
            }
        }

        /// <summary>
        /// <para>
        /// Sets the transform matrix that will be applied to a composition swap chain upon the next present.
        /// </para>
        /// <para>
        /// Starting with Windows 8.1, Windows Store apps are able to place DirectX swap chain visuals
        /// in XAML pages using the SwapChainPanel element, which can be placed and sized arbitrarily.
        /// This exposes the DirectX swap chain visuals to touch scaling and translation scenarios using touch UI.
        /// The <see cref="GetMatrixTransform"/> and <see cref="SetMatrixTransform"/> methods
        /// are used to synchronize scaling of the DirectX swap chain with its associated SwapChainPanel element.
        /// Only simple scale/translation elements in the matrix are allowed
        /// – the call will fail if the matrix contains skew/rotation elements.
        /// </para>
        /// </summary>
        /// <param name="pMatrix">
        /// The transform matrix to use for swap chain scaling and translation.
        /// This function can only be used with composition swap chains
        /// created by <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
        /// Only scale and translation components are allowed in the matrix.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="SetMatrixTransform"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully retrieves the transform matrix.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_INVALIDARG"/> if the <paramref name="pMatrix"/> parameter is incorrect,
        /// for example, <paramref name="pMatrix"/> is <see cref="NullRef{DXGI_MATRIX_3X2_F}"/>
        /// or the matrix represented by <see cref="DXGI_MATRIX_3X2_F"/> includes components other than scale and translation.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the method is called on a swap chain
        /// that was not created with <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
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
        public HRESULT SetMatrixTransform([In] in DXGI_MATRIX_3X2_F pMatrix)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in DXGI_MATRIX_3X2_F, HRESULT>)_vTable[34])(thisPtr, pMatrix);
            }
        }

        /// <summary>
        /// <para>
        /// Gets the transform matrix that will be applied to a composition swap chain upon the next present.
        /// </para>
        /// <para>
        /// Starting with Windows 8.1, Windows Store apps are able to place DirectX swap chain visuals
        /// in XAML pages using the SwapChainPanel element, which can be placed and sized arbitrarily.
        /// This exposes the DirectX swap chain visuals to touch scaling and translation scenarios using touch UI.
        /// The <see cref="GetMatrixTransform"/> and <see cref="SetMatrixTransform"/> methods
        /// are used to synchronize scaling of the DirectX swap chain with its associated SwapChainPanel element.
        /// Only simple scale/translation elements in the matrix are allowed
        /// – the call will fail if the matrix contains skew/rotation elements.
        /// </para>
        /// </summary>
        /// <param name="pMatrix">
        /// The transform matrix currently used for swap chain scaling and translation.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="GetMatrixTransform"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully retrieves the transform matrix.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the method is called on a swap chain
        /// that was not created with <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
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
        public HRESULT GetMatrixTransform([Out] out DXGI_MATRIX_3X2_F pMatrix)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_MATRIX_3X2_F, HRESULT>)_vTable[35])(thisPtr, out pMatrix);
            }
        }
    }
}
