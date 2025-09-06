using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_CHAIN_FLAG;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An <see cref="IDXGIDevice1"/> interface implements a derived class for DXGI objects that produce image data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgidevice1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is not supported by Direct3D 12 devices.
    /// Direct3D 12 applications have direct control over their swapchain management,
    /// so better latency control should be handled by the application.
    /// You can make use of Waitable objects (refer to <see cref="DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT"/>)
    /// and the <see cref="IDXGISwapChain2.SetMaximumFrameLatency"/> method if desired.
    /// </para>
    /// <para>
    /// This interface is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
    /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
    /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
    /// </para>
    /// <para>
    /// The <see cref="IDXGIDevice1"/> interface is designed for use by DXGI objects that need access to other DXGI objects.
    /// This interface is useful to applications that do not use Direct3D to communicate with DXGI.
    /// </para>
    /// <para>
    /// The Direct3D create device functions return a Direct3D device object.
    /// This Direct3D device object implements the <see cref="IUnknown"/> interface.
    /// You can query this Direct3D device object for the device's corresponding <see cref="IDXGIDevice1"/> interface.
    /// To retrieve the <see cref="IDXGIDevice1"/> interface of a Direct3D device, use the following code:
    /// </para>
    /// <code>
    /// IDXGIDevice1 * pDXGIDevice;
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice1), (void**)&amp;pDXGIDevice);
    /// </code>
    /// <para>
    /// Windows Phone 8: This API is supported.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "77db970f-6276-48ba-ba28-070143b4392c", BeginVTableSlotIndex = 12, EndVTableSlotIndex = 13,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIDevice)])]
    public unsafe struct IDXGIDevice1
    {
        IntPtr* _vTable;

        /// <summary>
        /// Sets the number of frames that the system is allowed to queue for rendering.
        /// </summary>
        /// <param name="MaxLatency">
        /// The maximum number of back buffer frames that a driver can queue.
        /// The value defaults to 3, but can range from 1 to 16.
        /// A value of 0 will reset latency to the default.
        /// For multi-head devices, this value is specified per-head.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, <see cref="DXGI_ERROR_DEVICE_REMOVED"/> if the device was removed.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
        /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
        /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
        /// </para>
        /// <para>
        /// Frame latency is the number of frames that are allowed to be stored in a queue before submission for rendering.
        /// Latency is often used to control how the CPU chooses
        /// between responding to user input and frames that are in the render queue.
        /// It is often beneficial for applications that have no user input
        /// (for example, video playback) to queue more than 3 frames of data.
        /// </para>
        /// </remarks>
        public HRESULT SetMaximumFrameLatency([In] UINT MaxLatency)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[12])(thisPtr, MaxLatency);
            }
        }

        /// <summary>
        /// Gets the number of frames that the system is allowed to queue for rendering.
        /// </summary>
        /// <param name="pMaxLatency">
        /// <para>
        /// This value is set to the number of frames that can be queued for render.
        /// </para>
        /// <para>
        /// This value defaults to 3, but can range from 1 to 16.
        /// </para>
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
        /// <remarks>
        /// <para>
        /// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
        /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
        /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
        /// </para>
        /// <para>
        /// Frame latency is the number of frames that are allowed to be stored in a queue before submission for rendering.
        /// Latency is often used to control how the CPU chooses
        /// between responding to user input and frames that are in the render queue.
        /// It is often beneficial for applications that have no user input
        /// (for example, video playback) to queue more than 3 frames of data.
        /// </para>
        /// </remarks>
        public HRESULT GetMaximumFrameLatency([Out] out UINT pMaxLatency)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[13])(thisPtr, out pMaxLatency);
            }
        }
    }
}
