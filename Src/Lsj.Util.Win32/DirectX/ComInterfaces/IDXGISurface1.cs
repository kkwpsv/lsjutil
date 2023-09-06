using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_CHAIN_FLAG;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGISurface1"/> interface extends the <see cref="IDXGISurface"/> by adding support for using Windows Graphics Device Interface (GDI)
    /// to render to a Microsoft DirectX Graphics Infrastructure (DXGI) surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgisurface1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This interface is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
    /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
    /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
    /// An image-data object is a 2D section of memory, commonly called a surface.
    /// To get the surface from an output, call <see cref="IDXGIOutput.GetDisplaySurfaceData"/>.
    /// Then, call <see cref="IUnknown.QueryInterface"/> on the <see cref="IDXGISurface"/> object
    /// that <see cref="IDXGIOutput.GetDisplaySurfaceData"/> returns to retrieve the <see cref="IDXGISurface1"/> interface.
    /// Any object that supports <see cref="IDXGISurface"/> also supports <see cref="IDXGISurface1"/>.
    /// The runtime automatically creates an <see cref="IDXGISurface1"/> interface when it creates a Direct3D resource object that represents a surface.
    /// For example, the runtime creates an <see cref="IDXGISurface1"/> interface
    /// when you call <see cref="ID3D11Device.CreateTexture2D"/> or <see cref="ID3D10Device.CreateTexture2D"/> to create a 2D texture.
    /// To retrieve the <see cref="IDXGISurface1"/> interface that represents the 2D texture surface, call <see cref="IUnknown.QueryInterface"/>.
    /// In this call, you must pass the identifier of <see cref="IDXGISurface1"/>.
    /// If the 2D texture has only a single MIP-map level and does not consist of an array of textures,
    /// <see cref="IUnknown.QueryInterface"/> succeeds and returns a pointer to the <see cref="IDXGISurface1"/> interface pointer.
    /// Otherwise, <see cref="IUnknown.QueryInterface"/> fails and does not return the pointer to <see cref="IDXGISurface1"/>.
    /// </remarks>
    public unsafe struct IDXGISurface1
    {
        IntPtr* _vTable;

        /// <summary>
        /// Returns a device context (DC) that allows you to render to a Microsoft DirectX Graphics Infrastructure (DXGI) surface using Windows Graphics Device Interface (GDI).
        /// </summary>
        /// <param name="Discard">
        /// A Boolean value that specifies whether to preserve Direct3D contents in the GDI DC.
        /// <see cref="TRUE"/> directs the runtime not to preserve Direct3D contents in the GDI DC; that is, the runtime discards the Direct3D contents.
        /// <see cref="FALSE"/> guarantees that Direct3D contents are available in the GDI DC.
        /// </param>
        /// <param name="phdc">
        /// A pointer to an <see cref="HDC"/> handle that represents the current device context for GDI rendering.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, an error code.
        /// </returns>
        /// <remarks>
        /// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
        /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
        /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
        /// After you use the <see cref="GetDC"/> method to retrieve a DC, you can render to the DXGI surface by using GDI.
        /// The <see cref="GetDC"/> method readies the surface for GDI rendering and allows inter-operation between DXGI and GDI technologies.
        /// Keep the following in mind when using this method:
        /// You must create the surface by using the <see cref="D3D11_RESOURCE_MISC_GDI_COMPATIBLE"/> flag for a surface
        /// or by using the <see cref="DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE"/> flag for swap chains, otherwise this method fails.
        /// You must release the device and call the <see cref="IDXGISurface1.ReleaseDC"/> method before you issue any new Direct3D commands.
        /// This method fails if an outstanding DC has already been created by this method.
        /// The format for the surface or swap chain must be <see cref="DXGI_FORMAT_B8G8R8A8_UNORM_SRGB"/> or <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>.
        /// On GetDC, the render target in the output merger of the Direct3D pipeline is unbound from the surface.
        /// You must call the <see cref="ID3D11DeviceContext.OMSetRenderTargets"/> method on the device prior to Direct3D rendering after GDI rendering.
        /// Prior to resizing buffers you must release all outstanding DCs.
        /// You can also call <see cref="GetDC"/> on the back buffer at index 0 of a swap chain by obtaining an <see cref="IDXGISurface1"/> from the swap chain.
        /// The following code illustrates the process.
        /// <code>
        /// IDXGISwapChain* g_pSwapChain = NULL;
        /// IDXGISurface1* g_pSurface1 = NULL;
        /// ...
        /// //Setup the device and and swapchain
        /// g_pSwapChain->GetBuffer(0, __uuidof(IDXGISurface1), (void**) &amp;g_pSurface1);
        /// g_pSurface1->GetDC( FALSE, &amp;g_hDC );
        /// ...
        /// //Draw on the DC using GDI
        /// ...
        /// //When finish drawing release the DC
        /// g_pSurface1->ReleaseDC( NULL );
        /// </code>
        /// </remarks>
        public HRESULT GetDC([In] BOOL Discard, [Out] out HDC phdc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, out HDC, HRESULT>)_vTable[11])(thisPtr, Discard, out phdc);
            }
        }

        /// <summary>
        /// Releases the GDI device context (DC) that is associated with the current surface and allows you to use Direct3D to render.
        /// </summary>
        /// <param name="pDirtyRect">
        /// A pointer to a <see cref="RECT"/> structure that identifies the dirty region of the surface.
        /// A dirty region is any part of the surface that you used for GDI rendering and that you want to preserve.
        /// This area is used as a performance hint to graphics subsystem in certain scenarios.
        /// Do not use this parameter to restrict rendering to the specified rectangular region.
        /// If you pass in <see cref="NullRef{RECT}"/>, <see cref="ReleaseDC"/> considers the whole surface as dirty.
        /// Otherwise, <see cref="ReleaseDC"/> uses the area specified by the <see cref="RECT"/> as a performance hint to indicate what areas have been manipulated by GDI rendering.
        /// You can pass a pointer to an empty <see cref="RECT"/> structure (a rectangle with no position or area) if you didn't change any content.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>. Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
        /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
        /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
        /// Use the <see cref="ReleaseDC"/> method to release the DC and indicate that your application finished all GDI rendering to this surface.
        /// You must call the <see cref="ReleaseDC"/> method before you can use Direct3D to perform additional rendering.
        /// Prior to resizing buffers you must release all outstanding DCs.
        /// </remarks>
        public HRESULT ReleaseDC([In] in RECT pDirtyRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in RECT, HRESULT>)_vTable[12])(thisPtr, in pDirtyRect);
            }
        }
    }
}
