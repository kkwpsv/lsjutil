using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DBACKBUFFER_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DCAPS3;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENT;
using static Lsj.Util.Win32.DirectX.Enums.D3DSWAPEFFECT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using IUnknown = Lsj.Util.Win32.ComInterfaces.IUnknown;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DSwapChain9"/> interface to manipulate a swap chain.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/nn-d3d9-idirect3dswapchain9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// There is always at least one swap chain for each device, known as the implicit swap chain.
    /// However, an additional swap chain for rendering multiple views from the same device can be created
    /// by calling the <see cref="IDirect3DDevice9.CreateAdditionalSwapChain"/> method.
    /// </para>
    /// <para>
    /// This interface, like all COM interfaces, inherits from the <see cref="IUnknown"/> interface.
    /// </para>
    /// <para>
    /// The LPDIRECT3DSWAPCHAIN9 and PDIRECT3DSWAPCHAIN9 types are defined as pointers to the <see cref="IDirect3DSwapChain9"/> interface.
    /// </para>
    /// <code>
    /// typedef struct IDirect3DSwapChain9 *LPDIRECT3DSWAPCHAIN9, *PDIRECT3DSWAPCHAIN9;
    /// </code>
    /// <para>
    /// Note the application should ensure that its associated device window is visible
    /// when its swapchain(s) is in fullscreen mode.
    /// Invisible windows cannot receive user mode events and invisible fullscreen windows
    /// will interfere with other windowed mode applications' presentation.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "794950F2-ADFC-458a-905E-10A10B0B503B", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 9, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDirect3DSwapChain9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Presents the contents of the next buffer in the sequence of back buffers owned by the swap chain.
        /// </summary>
        /// <param name="pSourceRect">
        /// Pointer to the source rectangle (see <see cref="RECT"/>).
        /// Use <see cref="NullRef{RECT}"/> to present the entire surface
        /// This value must be <see cref="NullRef{RECT}"/>
        /// unless the swap chain was created with <see cref="D3DSWAPEFFECT_COPY"/>.
        /// If the rectangle exceeds the source surface, the rectangle is clipped to the source surface.
        /// </param>
        /// <param name="pDestRect">
        /// Pointer to the destination rectangle in client coordinates (see <see cref="RECT"/>).
        /// This value must be <see cref="NullRef{RECT}"/>
        /// unless the swap chain was created with <see cref="D3DSWAPEFFECT_COPY"/>.
        /// Use <see cref="NullRef{RECT}"/> to fill the entire client area.
        /// If the rectangle exceeds the destination client area,
        /// the rectangle is clipped to the destination client area.
        /// </param>
        /// <param name="hDestWindowOverride">
        /// Pointer to a destination window whose client area is taken as the target for this presentation.
        /// If this value is <see cref="NULL"/>, the runtime uses
        /// the <see cref="D3DPRESENT_PARAMETERS.hDeviceWindow"/> member
        /// of <see cref="D3DPRESENT_PARAMETERS"/> for the presentation.
        /// </param>
        /// <param name="pDirtyRegion">
        /// <para>
        /// Value must be <see cref="NullRef{RGNDATA}"/>
        /// unless the swap chain was created with <see cref="D3DSWAPEFFECT_COPY"/>.
        /// For more information about swap chains, see Flipping Surfaces (Direct3D 9).
        /// </para>
        /// <para>
        /// If this value is non-NULL, the contained region is expressed in back buffer coordinates.
        /// The rectangles within the region are the minimal set of pixels that need to be updated.
        /// This method takes these rectangles into account when optimizing the presentation
        /// by copying only the pixels within the region, or some suitably expanded set of rectangles.
        /// This is an aid to optimization only, and the application should not rely on the region being copied exactly.
        /// The implementation can choose to copy the whole source rectangle.
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Allows the application to request that the method return immediately
        /// when the driver reports that it cannot schedule a presentation.
        /// Valid values are 0, or any combination of <see cref="D3DPRESENT_DONOTWAIT"/> or <see cref="D3DPRESENT_LINEAR_CONTENT"/>.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <paramref name="dwFlags"/> = 0, this method behaves as it did prior to Direct3D 9.
        /// Present will spin until the hardware is free, without returning an error.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <paramref name="dwFlags"/> = <see cref="D3DPRESENT_DONOTWAIT"/>,
        /// and the hardware is busy processing or waiting for a vertical sync interval,
        /// the method will return <see cref="D3DERR_WASSTILLDRAWING"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <paramref name="dwFlags"/> = <see cref="D3DPRESENT_LINEAR_CONTENT"/>,
        /// gamma correction is performed from linear space to sRGB for windowed swap chains.
        /// This flag will take effect only when the driver exposes
        /// <see cref="D3DCAPS3_LINEAR_TO_SRGB_PRESENTATION"/> (see Gamma (Direct3D 9)).
        /// Applications should specify this flag if the backbuffer format is 16-bit floating point
        /// in order to match windowed mode present to fullscreen gamma behavior.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_DEVICELOST"/>, <see cref="D3DERR_DRIVERINTERNALERROR"/>,
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="Present"/> method is a shortcut to Present.
        /// Present has been updated to take a flag allowing the application to request that the method return immediately
        /// when the driver reports that it cannot schedule a presentation.
        /// </para>
        /// <para>
        /// If necessary, a stretch operation is applied to transfer the pixels
        /// within the source rectangle to the destination rectangle in the client area of the target window.
        /// </para>
        /// <para>
        /// Present will fail if called between <see cref="IDirect3DDevice9.BeginScene"/>
        /// and <see cref="IDirect3DDevice9.EndScene"/> pairs unless the render target is not the current render target
        /// (such as the back buffer you get from creating an additional swap chain).
        /// This is a new behavior for Direct3D 9.
        /// </para>
        /// </remarks>
        public HRESULT Present([In] in RECT pSourceRect, [In] in RECT pDestRect, [In] HWND hDestWindowOverride,
            [In] in RGNDATA pDirtyRegion, [In] D3DPRESENT dwFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in RECT, in RECT, HWND, in RGNDATA, D3DPRESENT, HRESULT>)_vTable[3])
                    (thisPtr, in pSourceRect, in pDestRect, hDestWindowOverride, in pDirtyRegion, dwFlags);
            }
        }

        /// <summary>
        /// Generates a copy of the swapchain's front buffer
        /// and places that copy in a system memory buffer provided by the application.
        /// </summary>
        /// <param name="pDestSurface">
        /// Pointer to an <see cref="IDirect3DSurface9"/> interface
        /// that will receive a copy of the swapchain's front buffer.
        /// The data is returned in successive rows with no intervening space,
        /// starting from the vertically highest row to the lowest.
        /// For windowed mode, the size of the destination surface should be the size of the desktop.
        /// For full screen mode, the size of the destination surface should be the screen size.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If BackBuffer exceeds or equals the total number of back buffers,
        /// the function fails and returns <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DSurface9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/>
        /// when finished using this <see cref="IDirect3DSurface9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetFrontBufferData([In] in IDirect3DSurface9 pDestSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, HRESULT>)_vTable[4])(thisPtr, pDestSurface);
            }
        }

        /// <summary>
        /// Retrieves a back buffer from the swap chain of the device.
        /// </summary>
        /// <param name="iBackBuffer">
        /// Index of the back buffer object to return.
        /// Back buffers are numbered from 0 to the total number of back buffers - 1.
        /// A value of 0 returns the first back buffer, not the front buffer.
        /// The front buffer is not accessible through this method.
        /// Use <see cref="GetFrontBufferData"/> to retrieve a copy of the front buffer.
        /// </param>
        /// <param name="Type">
        /// Stereo view is not supported in Direct3D 9,
        /// so the only valid value for this parameter is <see cref="D3DBACKBUFFER_TYPE_MONO"/>.
        /// </param>
        /// <param name="ppBackBuffer">
        /// Address of a pointer to an <see cref="IDirect3DSurface9"/> interface,
        /// representing the returned back buffer surface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If BackBuffer exceeds or equals the total number of back buffers,
        /// then the function fails and returns <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DSurface9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/>
        /// when finished using this <see cref="IDirect3DSurface9"/> interface results in a memory leak.
        /// You must release any surfaces obtained through this method before releasing the swap chain it belongs to.
        /// </remarks>
        public HRESULT GetBackBuffer([In] UINT iBackBuffer, [In] D3DBACKBUFFER_TYPE Type, [Out] out P<IDirect3DSurface9> ppBackBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DBACKBUFFER_TYPE, out P<IDirect3DSurface9>, HRESULT>)_vTable[5])
                    (thisPtr, iBackBuffer, Type, out ppBackBuffer);
            }
        }

        /// <summary>
        /// Returns information describing the raster of the monitor on which the swap chain is presented.
        /// </summary>
        /// <param name="pRasterStatus">
        /// Pointer to a <see cref="D3DRASTER_STATUS"/> structure filled with information
        /// about the position or other status of the raster on the monitor driven by this adapter.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if <paramref name="pRasterStatus"/> is invalid
        /// or if the device does not support reading the current scan line.
        /// To determine if the device supports reading the scan line,
        /// check for the <see cref="D3DCAPS_READ_SCANLINE"/> flag
        /// in the <see cref="D3DCAPS9.Caps"/> member of <see cref="D3DCAPS9"/>.
        /// </returns>
        public HRESULT GetRasterStatus([Out] out D3DRASTER_STATUS pRasterStatus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DRASTER_STATUS, HRESULT>)_vTable[6])(thisPtr, out pRasterStatus);
            }
        }

        /// <summary>
        /// Retrieves the display mode's spatial resolution, color resolution, and refresh frequency.
        /// </summary>
        /// <param name="pMode">
        /// Pointer to a <see cref="D3DDISPLAYMODE"/> structure containing data about the display mode of the adapter.
        /// As opposed to the display mode of the device,
        /// which may not be active if the device does not own full-screen mode.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetDisplayMode([Out] out D3DDISPLAYMODE pMode)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DDISPLAYMODE, HRESULT>)_vTable[7])(thisPtr, out pMode);
            }
        }

        /// <summary>
        /// Retrieves the device associated with the swap chain.
        /// </summary>
        /// <param name="ppDevice">
        /// Address of a pointer to an <see cref="IDirect3DDevice9"/> interface to fill with the device pointer,
        /// if the query succeeds.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method allows navigation to the owning device object.
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DDevice9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/>
        /// when finished using this <see cref="IDirect3DDevice9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetDevice([Out] out P<IDirect3DDevice9> ppDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DDevice9>, HRESULT>)_vTable[8])(thisPtr, out ppDevice);
            }
        }

        /// <summary>
        /// Retrieves the presentation parameters associated with a swap chain.
        /// </summary>
        /// <param name="pPresentationParameters">
        /// Pointer to the presentation parameters.
        /// See <see cref="D3DPRESENT_PARAMETERS"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method can be used to see the presentation parameters of the parent swap chain of a surface
        /// (a back buffer, for instance).
        /// The parent swap chain can be retrieved with <see cref="IDirect3DSurface9.GetContainer"/>.
        /// </remarks>
        public HRESULT GetPresentParameters([Out] out D3DPRESENT_PARAMETERS pPresentationParameters)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DPRESENT_PARAMETERS, HRESULT>)_vTable[9])(thisPtr, out pPresentationParameters);
            }
        }
    }
}
