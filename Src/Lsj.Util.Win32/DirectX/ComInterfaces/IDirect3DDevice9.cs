using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DCREATE;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DLIGHTTYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DPOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENTFLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRIMITIVETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;
using static Lsj.Util.Win32.DirectX.Enums.D3DXERR;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DDevice9"/> interface to perform DrawPrimitive-based rendering,
    /// create resources, work with system-level variables, adjust gamma ramp levels, work with palettes, and create shaders.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/nn-d3d9-idirect3ddevice9"/>
    /// </para>
    /// </summary>
    public unsafe struct IDirect3DDevice9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Reports the current cooperative-level status of the Direct3D device for a windowed or full-screen application.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>,
        /// indicating that the device is operational and the calling application can continue.
        /// If the method fails, the return value can be one of the following values:
        /// <see cref="D3DERR_DEVICELOST"/>, <see cref="D3DERR_DEVICENOTRESET"/>, <see cref="D3DERR_DRIVERINTERNALERROR"/>.
        /// </returns>
        /// <remarks>
        /// If the device is lost but cannot be restored at the current time, <see cref="TestCooperativeLevel"/> returns the <see cref="D3DERR_DEVICELOST"/> return code.
        /// This would be the case, for example, when a full-screen device has lost focus.
        /// If an application detects a lost device, it should pause and periodically call <see cref="TestCooperativeLevel"/>
        /// until it receives a return value of <see cref="D3DERR_DEVICENOTRESET"/>.
        /// The application may then attempt to reset the device by calling <see cref="Reset"/> and,
        /// if this succeeds, restore the necessary resources and resume normal operation.
        /// Note that <see cref="Present"/> will return <see cref="D3DERR_DEVICELOST"/> if the device is either "lost" or "not reset".
        /// A call to <see cref="TestCooperativeLevel"/> will fail if called on a different thread than that used to create the device being reset.
        /// </remarks>
        public HRESULT TestCooperativeLevel()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[3])(thisPtr);
            }
        }

        /// <summary>
        /// Returns an estimate of the amount of available texture memory.
        /// </summary>
        /// <returns>
        /// The function returns an estimate of the available texture memory.
        /// </returns>
        /// <remarks>
        /// The returned value is rounded to the nearest MB.
        /// This is done to reflect the fact that video memory estimates are never precise due to alignment
        /// and other issues that affect consumption by certain resources.
        /// Applications can use this value to make gross estimates of memory availability to make large-scale resource decisions
        /// such as how many levels of a mipmap to attempt to allocate,
        /// but applications cannot use this value to make small-scale decisions such as if there is enough memory left to allocate another resource.
        /// </remarks>
        public UINT GetAvailableTextureMem()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Evicts all managed resources, including both Direct3D and driver-managed resources.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="D3DERR_COMMAND_UNPARSED"/>.
        /// </returns>
        /// <remarks>
        /// This function causes only the <see cref="D3DPOOL_DEFAULT"/> copy of resources to be evicted.
        /// The resource copy in system memory is retained.
        /// See <see cref="D3DPOOL"/>.
        /// </remarks>
        public HRESULT EvictManagedResources()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[5])(thisPtr);
            }
        }

        /// <summary>
        /// Returns an interface to the instance of the Direct3D object that created the device.
        /// </summary>
        /// <param name="ppD3D9">
        /// Address of a pointer to an <see cref="IDirect3D9"/> interface, representing the interface of the Direct3D object that created the device.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Calling <see cref="GetDirect3D"/> will increase the internal reference count on the <see cref="IDirect3D9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/> when finished using this <see cref="IDirect3D9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetDirect3D([Out] out P<IDirect3D9> ppD3D9)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3D9>, HRESULT>)_vTable[6])(thisPtr, out ppD3D9);
            }
        }

        /// <summary>
        /// Retrieves the capabilities of the rendering device.
        /// </summary>
        /// <param name="pCaps">
        /// Pointer to a <see cref="D3DCAPS9"/> structure, describing the returned device.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GetDeviceCaps"/> retrieves the software vertex pipeline capabilities when the device is being used in software vertex processing mode.
        /// </remarks>
        public HRESULT GetDeviceCaps([Out] out D3DCAPS9 pCaps)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DCAPS9, HRESULT>)_vTable[7])(thisPtr, out pCaps);
            }
        }

        /// <summary>
        /// Retrieves the display mode's spatial resolution, color resolution, and refresh frequency.
        /// </summary>
        /// <param name="iSwapChain">
        /// An unsigned integer specifying the swap chain.
        /// </param>
        /// <param name="pMode">
        /// Pointer to a <see cref="D3DDISPLAYMODE"/> structure containing data about the display mode of the adapter.
        /// As opposed to the display mode of the device, which may not be active if the device does not own full-screen mode.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetDisplayMode([In] UINT iSwapChain, [Out] out D3DDISPLAYMODE pMode)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DDISPLAYMODE, HRESULT>)_vTable[8])(thisPtr, iSwapChain, out pMode);
            }
        }

        /// <summary>
        /// Retrieves the creation parameters of the device.
        /// </summary>
        /// <param name="pParameters">
        /// Pointer to a <see cref="D3DDEVICE_CREATION_PARAMETERS"/> structure, describing the creation parameters of the device.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if the argument is invalid.
        /// </returns>
        /// <remarks>
        /// You can query the <see cref="D3DDEVICE_CREATION_PARAMETERS.AdapterOrdinal"/> member
        /// of the returned <see cref="D3DDEVICE_CREATION_PARAMETERS"/> structure to retrieve the ordinal of the adapter represented by this device.
        /// </remarks>
        public HRESULT GetCreationParameters([Out] out D3DDEVICE_CREATION_PARAMETERS pParameters)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DDEVICE_CREATION_PARAMETERS, HRESULT>)_vTable[9])(thisPtr, out pParameters);
            }
        }

        public HRESULT SetCursorProperties([In] UINT XHotSpot, [In] UINT YHotSpot, [In] in IDirect3DSurface9 pCursorBitmap)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, in IDirect3DSurface9, HRESULT>)_vTable[10])(thisPtr, XHotSpot, YHotSpot, pCursorBitmap);
            }
        }

        public void SetCursorPosition([In] int X, [In] int Y, [In] DWORD Flags)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, int, int, DWORD, void>)_vTable[11])(thisPtr, X, Y, Flags);
            }
        }

        public BOOL ShowCursor([In] BOOL bShow)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, BOOL>)_vTable[12])(thisPtr, bShow);
            }
        }

        /// <summary>
        /// Creates an additional swap chain for rendering multiple views.
        /// </summary>
        /// <param name="pPresentationParameters">
        /// Pointer to a D3DPRESENT_PARAMETERS structure, containing the presentation parameters for the new swap chain.
        /// This value cannot be <see cref="NullRef{D3DPRESENT_PARAMETERS}"/>.
        /// Calling this method changes the value of members of the <see cref="D3DPRESENT_PARAMETERS"/> structure.
        /// If <see cref="D3DPRESENT_PARAMETERS.BackBufferCount"/> == 0, calling <see cref="CreateAdditionalSwapChain"/> will increase it to 1.
        /// If the application is in windowed mode, and if either the <see cref="D3DPRESENT_PARAMETERS.BackBufferWidth"/>
        /// or the <see cref="D3DPRESENT_PARAMETERS.BackBufferHeight"/> == 0, they will be set to the client area width and height of the hwnd.
        /// </param>
        /// <param name="pSwapChain">
        /// Address of a pointer to an <see cref="IDirect3DSwapChain9"/> interface, representing the additional swap chain.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_NOTAVAILABLE"/>, <see cref="D3DERR_DEVICELOST"/>, <see cref="D3DERR_INVALIDCALL"/>,
        /// <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// There is always at least one swap chain (the implicit swap chain) for each device because Direct3D 9 has one swap chain as a property of the device.
        /// Note that any given device can support only one full-screen swap chain.
        /// <see cref="D3DFMT_UNKNOWN"/> can be specified for the windowed mode back buffer format
        /// when calling <see cref="IDirect3D9.CreateDevice"/>, <see cref="Reset"/> and <see cref="CreateAdditionalSwapChain"/>.
        /// This means the application does not have to query the current desktop format before calling CreateDevice for windowed mode.
        /// For full-screen mode, the back buffer format must be specified.
        /// </remarks>
        public HRESULT CreateAdditionalSwapChain([In] in D3DPRESENT_PARAMETERS pPresentationParameters, [Out] out P<IDirect3DSwapChain9> pSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DPRESENT_PARAMETERS, out P<IDirect3DSwapChain9>, HRESULT>)_vTable[13])
                    (thisPtr, in pPresentationParameters, out pSwapChain);
            }
        }

        /// <summary>
        /// Gets a pointer to a swap chain.
        /// </summary>
        /// <param name="iSwapChain">
        /// The swap chain ordinal value.
        /// For more information, see <see cref="D3DCAPS9.NumberOfAdaptersInGroup"/> in <see cref="D3DCAPS9"/>.
        /// </param>
        /// <param name="pSwapChain">
        /// Pointer to an <see cref="IDirect3DSwapChain9"/> interface that will receive a copy of swap chain.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetSwapChain([In] UINT iSwapChain, [Out] out P<IDirect3DSwapChain9> pSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDirect3DSwapChain9>, HRESULT>)_vTable[14])(thisPtr, iSwapChain, out pSwapChain);
            }
        }

        /// <summary>
        /// Gets the number of implicit swap chains.
        /// </summary>
        /// <returns>
        /// Number of implicit swap chains.
        /// See Remarks.
        /// </returns>
        /// <remarks>
        /// Implicit swap chains are created by the device during <see cref="IDirect3D9.CreateDevice"/>.
        /// This method returns the number of swap chains created by <see cref="IDirect3D9.CreateDevice"/>.
        /// An application may create additional swap chains using I<see cref="CreateAdditionalSwapChain"/>.
        /// </remarks>
        public UINT GetNumberOfSwapChains()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT>)_vTable[15])(thisPtr);
            }
        }

        public HRESULT Reset([In] in D3DPRESENT_PARAMETERS pPresentationParameters)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DPRESENT_PARAMETERS, HRESULT>)_vTable[16])(thisPtr, pPresentationParameters);
            }
        }

        public HRESULT Present([In] in RECT pSourceRect, [In] in RECT pDestRect, [In] HWND hDestWindowOverride, [In] in RGNDATA pDirtyRegion)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in RECT, in RECT, HWND, in RGNDATA, HRESULT>)_vTable[17])
                    (thisPtr, in pSourceRect, in pDestRect, hDestWindowOverride, in pDirtyRegion);
            }
        }

        /// <summary>
        /// Retrieves a back buffer from the device's swap chain.
        /// </summary>
        /// <param name="iSwapChain">
        /// An unsigned integer specifying the swap chain.
        /// </param>
        /// <param name="iBackBuffer">
        /// Index of the back buffer object to return.
        /// Back buffers are numbered from 0 to the total number of back buffers minus one.
        /// A value of 0 returns the first back buffer, not the front buffer.
        /// The front buffer is not accessible through this method.
        /// Use <see cref="GetFrontBufferData"/> to retrieve a copy of the front buffer.
        /// </param>
        /// <param name="Type">
        /// Stereo view is not supported in Direct3D 9, so the only valid value for this parameter is <see cref="D3DBACKBUFFER_TYPE_MONO"/>.
        /// </param>
        /// <param name="ppBackBuffer">
        /// Address of a pointer to an <see cref="IDirect3DSurface9"/> interface, representing the returned back buffer surface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If <paramref name="iBackBuffer"/> equals or exceeds the total number of back buffers,
        /// then the function fails and returns <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DSurface9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/> when finished using this <see cref="IDirect3DSurface9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetBackBuffer([In] UINT iSwapChain, [In] UINT iBackBuffer, [In] D3DBACKBUFFER_TYPE Type, [Out] out P<IDirect3DSurface9> ppBackBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DBACKBUFFER_TYPE, out P<IDirect3DSurface9>, HRESULT>)_vTable[18])
                    (thisPtr, iSwapChain, iBackBuffer, Type, out ppBackBuffer);
            }
        }

        /// <summary>
        /// Returns information describing the raster of the monitor on which the swap chain is presented.
        /// </summary>
        /// <param name="iSwapChain">
        /// An unsigned integer specifying the swap chain.
        /// </param>
        /// <param name="pRasterStatus">
        /// Pointer to a <see cref="D3DRASTER_STATUS"/> structure filled with information
        /// about the position or other status of the raster on the monitor driven by this adapter.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if <paramref name="pRasterStatus"/> is invalid
        /// or if the device does not support reading the current scan line.
        /// To determine if the device supports reading the scan line, check for the <see cref="D3DCAPS_READ_SCANLINE"/> flag
        /// in the <see cref="D3DCAPS9.Caps"/> member of <see cref="D3DCAPS9"/>.
        /// </returns>
        public HRESULT GetRasterStatus([In] UINT iSwapChain, [Out] out D3DRASTER_STATUS pRasterStatus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DRASTER_STATUS, HRESULT>)_vTable[19])(thisPtr, iSwapChain, out pRasterStatus);
            }
        }

        public HRESULT SetDialogBoxMode([In] BOOL bEnableDialogs)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[20])(thisPtr, bEnableDialogs);
            }
        }

        public void SetGammaRamp([In] UINT iSwapChain, [In] DWORD Flags, [In] in D3DGAMMARAMP pRamp)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, DWORD, in D3DGAMMARAMP, HRESULT>)_vTable[21])(thisPtr, iSwapChain, Flags, pRamp);
            }
        }

        /// <summary>
        /// Retrieves the gamma correction ramp for the swap chain.
        /// </summary>
        /// <param name="iSwapChain">
        /// An unsigned integer specifying the swap chain.
        /// </param>
        /// <param name="pRamp">
        /// Pointer to an application-supplied <see cref="D3DGAMMARAMP"/> structure to fill with the gamma correction ramp.
        /// </param>
        public void GetGammaRamp([In] UINT iSwapChain, [Out] out D3DGAMMARAMP pRamp)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DGAMMARAMP, HRESULT>)_vTable[22])(thisPtr, iSwapChain, out pRamp);
            }
        }

        /// <summary>
        /// Creates a texture resource.
        /// </summary>
        /// <param name="Width">
        /// Width of the top-level of the texture, in pixels.
        /// The pixel dimensions of subsequent levels will be the truncated value of half of the previous level's pixel dimension (independently).
        /// Each dimension clamps at a size of 1 pixel.
        /// Thus, if the division by 2 results in 0, 1 will be taken instead.
        /// </param>
        /// <param name="Height">
        /// Height of the top-level of the texture, in pixels.
        /// The pixel dimensions of subsequent levels will be the truncated value of half of the previous level's pixel dimension (independently).
        /// Each dimension clamps at a size of 1 pixel.
        /// Thus, if the division by 2 results in 0, 1 will be taken instead.
        /// </param>
        /// <param name="Levels">
        /// Number of levels in the texture.
        /// If this is zero, Direct3D will generate all texture sublevels down to 1 by 1 pixels for hardware that supports mipmapped textures.
        /// Call <see cref="IDirect3DBaseTexture9.GetLevelCount"/> to see the number of levels generated.
        /// </param>
        /// <param name="Usage">
        /// Usage can be 0, which indicates no usage value.
        /// However, if usage is desired, use a combination of one or more <see cref="D3DUSAGE"/> constants.
        /// It is good practice to match the usage parameter with the behavior flags in <see cref="IDirect3D9.CreateDevice"/>.
        /// </param>
        /// <param name="Format">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the format of all levels in the texture.
        /// </param>
        /// <param name="Pool">
        /// Member of the <see cref="D3DPOOL"/> enumerated type, describing the memory class into which the texture should be placed.
        /// </param>
        /// <param name="ppTexture">
        /// Pointer to an <see cref="IDirect3DTexture9"/> interface, representing the created texture resource.
        /// </param>
        /// <param name="pSharedHandle">
        /// Reserved.
        /// Set this parameter to <see cref="NullRef{HANDLE}"/>.
        /// This parameter can be used in Direct3D 9 for Windows Vista to share resources.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// An application can discover support for Automatic Generation of Mipmaps (Direct3D 9) in a particular format
        /// by calling <see cref="IDirect3D9.CheckDeviceFormat"/> with <see cref="D3DUSAGE_AUTOGENMIPMAP"/>.
        /// If <see cref="IDirect3D9.CheckDeviceFormat"/> returns <see cref="D3DOK_NOAUTOGEN"/>,
        /// <see cref="CreateTexture"/> will succeed but it will return a one-level texture.
        /// In Windows Vista CreateTexture can create a texture from a system memory pointer
        /// allowing the application more flexibility over the use, allocation and deletion of the system memory.
        /// For example, an application could pass a GDI system memory bitmap pointer and get a Direct3D texture interface around it.
        /// Using a system memory pointer with <see cref="CreateTexture"/> has the following restrictions.
        /// The pitch of the texture must be equal to the width multiplied by the number of bytes per pixel.
        /// Only textures with a single mipmap level are supported. The <paramref name="Levels"/> argument must be 1.
        /// The <paramref name="Pool"/> argument must be <see cref="D3DPOOL_SYSTEMMEM"/>.
        /// The <paramref name="pSharedHandle"/> argument must be a valid pointer to a buffer that can hold the system memory point;
        /// *<paramref name="pSharedHandle"/> must be a valid pointer to system memory
        /// with a size in bytes of texture width * texture height * bytes per pixel of the texture format.
        /// </remarks>
        public HRESULT CreateTexture([In] UINT Width, [In] UINT Height, [In] UINT Levels, [In] DWORD Usage,
            [In] D3DFORMAT Format, [In] D3DPOOL Pool, [Out] out P<IDirect3DTexture9> ppTexture, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, DWORD, D3DFORMAT, D3DPOOL, out P<IDirect3DTexture9>, ref HANDLE, HRESULT>)_vTable[23])
                    (thisPtr, Width, Height, Levels, Usage, Format, Pool, out ppTexture, ref pSharedHandle);
            }
        }

        /// <summary>
        /// Creates a volume texture resource.
        /// </summary>
        /// <param name="Width">
        /// Width of the top-level of the volume texture, in pixels.
        /// This value must be a power of two if the <see cref="D3DPTEXTURECAPS_VOLUMEMAP_POW2"/> member of <see cref="D3DCAPS9"/> is set.
        /// The pixel dimensions of subsequent levels will be the truncated value of half of the previous level's pixel dimension (independently).
        /// Each dimension clamps at a size of 1 pixel. Thus, if the division by two results in 0 (zero), 1 will be taken instead.
        /// The maximum dimension that a driver supports (for width, height, and depth) can be found in <see cref="D3DCAPS9.MaxVolumeExtent"/> in <see cref="D3DCAPS9"/>.
        /// </param>
        /// <param name="Height">
        /// Height of the top-level of the volume texture, in pixels.
        /// This value must be a power of two if the <see cref="D3DPTEXTURECAPS_VOLUMEMAP_POW2"/> member of <see cref="D3DCAPS9"/> is set.
        /// The pixel dimensions of subsequent levels will be the truncated value of half of the previous level's pixel dimension (independently).
        /// Each dimension clamps at a size of 1 pixel. Thus, if the division by 2 results in 0 (zero), 1 will be taken instead.
        /// The maximum dimension that a driver supports (for width, height, and depth) can be found in <see cref="D3DCAPS9.MaxVolumeExtent"/> in <see cref="D3DCAPS9"/>.
        /// </param>
        /// <param name="Depth">
        /// Depth of the top-level of the volume texture, in pixels.
        /// This value must be a power of two if the <see cref="D3DPTEXTURECAPS_VOLUMEMAP_POW2"/> member of <see cref="D3DCAPS9"/> is set.
        /// The pixel dimensions of subsequent levels will be the truncated value of half of the previous level's pixel dimension (independently).
        /// Each dimension clamps at a size of 1 pixel. Thus, if the division by 2 results in 0 (zero), 1 will be taken instead.
        /// The maximum dimension that a driver supports (for width, height, and depth) can be found in <see cref="D3DCAPS9.MaxVolumeExtent"/> in <see cref="D3DCAPS9"/>.
        /// </param>
        /// <param name="Levels">
        /// Number of levels in the texture.
        /// If this is zero, Direct3D will generate all texture sublevels down to 1x1 pixels for hardware that supports mipmapped volume textures.
        /// Call <see cref="IDirect3DBaseTexture9.GetLevelCount"/> to see the number of levels generated.
        /// </param>
        /// <param name="Usage">
        /// Usage can be 0, which indicates no usage value.
        /// If usage is desired, use <see cref="D3DUSAGE_DYNAMIC"/> or <see cref="D3DUSAGE_SOFTWAREPROCESSING"/>.
        /// For more information, see <see cref="D3DUSAGE"/>.
        /// </param>
        /// <param name="Format">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the format of all levels in the volume texture.
        /// </param>
        /// <param name="Pool">
        /// Member of the <see cref="D3DPOOL"/> enumerated type, describing the memory class into which the volume texture should be placed.
        /// </param>
        /// <param name="ppVolumeTexture">
        /// Address of a pointer to an <see cref="IDirect3DVolumeTexture9"/> interface, representing the created volume texture resource.
        /// </param>
        /// <param name="pSharedHandle">
        /// Reserved.
        /// Set this parameter to <see cref="NullRef{HANDLE}"/>.
        /// This parameter can be used in Direct3D 9 for Windows Vista to share resources.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        public HRESULT CreateVolumeTexture([In] UINT Width, [In] UINT Height, [In] UINT Depth, [In] UINT Levels, [In] DWORD Usage,
            [In] D3DFORMAT Format, [In] D3DPOOL Pool, [Out] out P<IDirect3DVolumeTexture9> ppVolumeTexture, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, UINT, DWORD, D3DFORMAT, D3DPOOL, out P<IDirect3DVolumeTexture9>, ref HANDLE, HRESULT>)_vTable[24])
                    (thisPtr, Width, Height, Depth, Levels, Usage, Format, Pool, out ppVolumeTexture, ref pSharedHandle);
            }
        }

        /// <summary>
        /// Creates a cube texture resource.
        /// </summary>
        /// <param name="EdgeLength">
        /// Size of the edges of all the top-level faces of the cube texture.
        /// The pixel dimensions of subsequent levels of each face will be the truncated value of half of the previous level's pixel dimension (independently).
        /// Each dimension clamps at a size of 1 pixel. Thus, if the division by 2 results in 0 (zero), 1 will be taken instead.
        /// </param>
        /// <param name="Levels">
        /// Number of levels in each face of the cube texture.
        /// If this is zero, Direct3D will generate all cube texture sublevels down to 1x1 pixels
        /// for each face for hardware that supports mipmapped cube textures.
        /// Call <see cref="IDirect3DBaseTexture9.GetLevelCount"/> to see the number of levels generated.
        /// </param>
        /// <param name="Usage">
        /// Usage can be 0, which indicates no usage value.
        /// However, if usage is desired, use a combination of one or more <see cref="D3DUSAGE"/> constants.
        /// It is good practice to match the usage parameter in <see cref="CreateCubeTexture"/>
        /// with the behavior flags in <see cref="IDirect3D9.CreateDevice"/>.
        /// For more information, see Remarks.
        /// </param>
        /// <param name="Format">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the format of all levels in all faces of the cube texture.
        /// </param>
        /// <param name="Pool">
        /// Member of the <see cref="D3DPOOL"/> enumerated type, describing the memory class into which the cube texture should be placed.
        /// </param>
        /// <param name="ppCubeTexture">
        /// Address of a pointer to an <see cref="IDirect3DCubeTexture9"/> interface, representing the created cube texture resource.
        /// </param>
        /// <param name="pSharedHandle">
        /// Reserved.
        /// Set this parameter to <see cref="NullRef{HANDLE}"/>.
        /// This parameter can be used in Direct3D 9 for Windows Vista to share resources.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// A mipmap (texture) is a collection of successively downsampled (mipmapped) surfaces.
        /// On the other hand, a cube texture (created by <see cref="CreateCubeTexture"/>) is a collection of six textures (mipmaps), one for each face.
        /// All faces must be present in the cube texture.
        /// Also, a cube map surface must be the same pixel size in all three dimensions (x, y, and z).
        /// An application can discover support for Automatic Generation of Mipmaps (Direct3D 9) in a particular format
        /// by calling <see cref="IDirect3D9.CheckDeviceFormat"/> with <see cref="D3DUSAGE_AUTOGENMIPMAP"/>.
        /// If <see cref="IDirect3D9.CheckDeviceFormat"/> returns <see cref="D3DOK_NOAUTOGEN"/>,
        /// <see cref="CreateCubeTexture"/> will succeed but it will return a one-level texture.
        /// </remarks>
        public HRESULT CreateCubeTexture([In] UINT EdgeLength, [In] UINT Levels, [In] D3DUSAGE Usage, [In] D3DFORMAT Format,
            [In] D3DPOOL Pool, [Out] out P<IDirect3DCubeTexture9> ppCubeTexture, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DUSAGE, D3DFORMAT, D3DPOOL, out P<IDirect3DCubeTexture9>, ref HANDLE, HRESULT>)_vTable[25])
                    (thisPtr, EdgeLength, Levels, Usage, Format, Pool, out ppCubeTexture, ref pSharedHandle);
            }
        }

        /// <summary>
        /// Creates a vertex buffer.
        /// </summary>
        /// <param name="Length">
        /// Size of the vertex buffer, in bytes.
        /// For FVF vertex buffers, Length must be large enough to contain at least one vertex, but it need not be a multiple of the vertex size.
        /// <paramref name="Length"/> is not validated for non-FVF buffers.
        /// See Remarks.
        /// </param>
        /// <param name="Usage">
        /// Usage can be 0, which indicates no usage value.
        /// However, if usage is desired, use a combination of one or more <see cref="D3DUSAGE"/> constants.
        /// It is good practice to match the usage parameter in <see cref="CreateVertexBuffer"/> with the behavior flags in <see cref="IDirect3D9.CreateDevice"/>.
        /// For more information, see Remarks.
        /// </param>
        /// <param name="FVF">
        /// Combination of <see cref="D3DFVF"/>, a usage specifier that describes the vertex format of the vertices in this buffer.
        /// If this parameter is set to a valid FVF code, the created vertex buffer is an FVF vertex buffer (see Remarks).
        /// Otherwise, if this parameter is set to zero, the vertex buffer is a non-FVF vertex buffer.
        /// </param>
        /// <param name="Pool">
        /// Member of the <see cref="D3DPOOL"/> enumerated type, describing a valid memory class into which to place the resource.
        /// Do not set to <see cref="D3DPOOL_SCRATCH"/>.
        /// </param>
        /// <param name="ppVertexBuffer">
        /// Address of a pointer to an <see cref="IDirect3DVertexBuffer9"/> interface, representing the created vertex buffer resource.
        /// </param>
        /// <param name="pSharedHandle">
        /// Reserved.
        /// Set this parameter to <see cref="NullRef{HANDLE}"/>.
        /// This parameter can be used in Direct3D 9 for Windows Vista to share resources.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// A vertex buffer can be used with either hardware or software vertex processing.
        /// This is determined by how the device and the vertex buffer are created.
        /// When a device is created, <see cref="IDirect3D9.CreateDevice"/> uses the behavior flag to determine whether to process vertices in hardware or software.
        /// There are three possibilities:
        /// Process vertices in hardware by setting <see cref="D3DCREATE_HARDWARE_VERTEXPROCESSING"/>.
        /// Process vertices in software by setting <see cref="D3DCREATE_SOFTWARE_VERTEXPROCESSING"/>.
        /// Process vertices in either hardware or software by setting <see cref="D3DCREATE_MIXED_VERTEXPROCESSING"/>.
        /// Mixed-mode devices might need to switch between software and hardware processing
        /// (using <see cref="SetSoftwareVertexProcessing"/>) after the device is created.
        /// When a vertex buffer is created, <see cref="CreateVertexBuffer"/> uses the usage parameter to decide whether to process vertices in hardware or software.
        /// If <see cref="IDirect3D9.CreateDevice"/> uses <see cref="D3DCREATE_HARDWARE_VERTEXPROCESSING"/>,
        /// <see cref="CreateVertexBuffer"/> must use 0.
        /// If <see cref="IDirect3D9.CreateDevice"/> uses <see cref="D3DCREATE_SOFTWARE_VERTEXPROCESSING"/>,
        /// <see cref="CreateVertexBuffer"/> must use either 0 or <see cref="D3DUSAGE_SOFTWAREPROCESSING"/>.
        /// For either value, vertices will be processed in software.
        /// If <see cref="IDirect3D9.CreateDevice"/> uses <see cref="D3DCREATE_MIXED_VERTEXPROCESSING"/>,
        /// <see cref="CreateVertexBuffer"/> can use either 0 or <see cref="D3DUSAGE_SOFTWAREPROCESSING"/>.
        /// To use a vertex buffer with a mixed mode device, create a single vertex buffer which can be used for both hardware or software processing.
        /// Use <see cref="SetStreamSource"/> to set the current vertex buffer and use <see cref="SetRenderState"/>,
        /// if necessary, to change the device behavior to match.
        /// It is recommended that the vertex buffer usage matches the device behavior.
        /// Note that a vertex buffer created for software processing cannot be located in video memory.
        /// The <see cref="IDirect3DDevice9"/> interface supports rendering of primitives using vertex data stored in vertex buffer objects.
        /// Vertex buffers are created from the <see cref="IDirect3DDevice9"/>, and are usable only with the <see cref="IDirect3DDevice9"/> object from which they are created.
        /// When set to a nonzero value, which must be a valid FVF code,
        /// the <paramref name="FVF"/> parameter indicates that the buffer content is to be characterized by an FVF code.
        /// A vertex buffer that is created with an FVF code is referred to as an FVF vertex buffer.
        /// For more information, see FVF Vertex Buffers (Direct3D 9).
        /// Non-FVF buffers can be used to interleave data during multipass rendering or multitexture rendering in a single pass.
        /// To do this, one buffer contains geometry data and the others contain texture coordinates for each texture to be rendered.
        /// When rendering, the buffer containing the geometry data is interleaved with each of the buffers containing the texture coordinates.
        /// If FVF buffers were used instead, each of them would need to contain identical geometry data
        /// in addition to the texture coordinate data specific to each texture rendered.
        /// This would result in either a speed or memory penalty, depending on the strategy used.
        /// For more information about texture coordinates, see Texture Coordinates (Direct3D 9).
        /// </remarks>
        public HRESULT CreateVertexBuffer([In] UINT Length, [In] DWORD Usage, [In] D3DFVF FVF, [In] D3DPOOL Pool,
            [Out] out P<IDirect3DVertexBuffer9> ppVertexBuffer, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, DWORD, D3DFVF, D3DPOOL, out P<IDirect3DVertexBuffer9>, ref HANDLE, HRESULT>)_vTable[26])
                    (thisPtr, Length, Usage, FVF, Pool, out ppVertexBuffer, ref pSharedHandle);
            }
        }

        /// <summary>
        /// Creates an index buffer.
        /// </summary>
        /// <param name="Length">
        /// Size of the index buffer, in bytes.
        /// </param>
        /// <param name="Usage">
        /// Usage can be 0, which indicates no usage value.
        /// However, if usage is desired, use a combination of one or more <see cref="D3DUSAGE"/> constants.
        /// It is good practice to match the usage parameter in <see cref="CreateIndexBuffer"/>
        /// with the behavior flags in <see cref="IDirect3D9.CreateDevice"/>.
        /// For more information, see Remarks.
        /// </param>
        /// <param name="Format">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the format of the index buffer.
        /// For more information, see Remarks.
        /// The valid settings are the following:
        /// <see cref="D3DFMT_INDEX16"/>: Indices are 16 bits each.
        /// <see cref="D3DFMT_INDEX32"/>: Indices are 32 bits each.
        /// </param>
        /// <param name="Pool">
        /// Member of the <see cref="D3DPOOL"/> enumerated type, describing a valid memory class into which to place the resource.
        /// </param>
        /// <param name="ppIndexBuffer">
        /// Address of a pointer to an <see cref="IDirect3DIndexBuffer9"/> interface, representing the created index buffer resource.
        /// </param>
        /// <param name="pSharedHandle">
        /// This parameter can be used in Direct3D 9 for Windows Vista to share resources;
        /// set it to <see cref="NullRef{HANDLE}"/> to not share a resource.
        /// This parameter is not used in Direct3D 9 for operating systems earlier than Windows Vista; set it to <see cref="NullRef{HANDLE}"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>,
        /// <see cref="D3DXERR_INVALIDDATA"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// Index buffers are memory resources used to hold indices, they are similar to both surfaces and vertex buffers.
        /// The use of index buffers enables Direct3D to avoid unnecessary data copying and to place the buffer in the optimal memory type for the expected usage.
        /// To use index buffers, create an index buffer, lock it, fill it with indices, unlock it, pass it to <see cref="SetIndices"/>,
        /// set up the vertices, set up the vertex shader, and call <see cref="DrawIndexedPrimitive"/> for rendering.
        /// The <see cref="D3DCAPS9.MaxVertexIndex"/> member of the <see cref="D3DCAPS9"/> structure
        /// indicates the types of index buffers that are valid for rendering.
        /// </remarks>
        public HRESULT CreateIndexBuffer([In] UINT Length, [In] DWORD Usage, [In] D3DFORMAT Format, [In] D3DPOOL Pool,
            [Out] out P<IDirect3DIndexBuffer9> ppIndexBuffer, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, DWORD, D3DFORMAT, D3DPOOL, out P<IDirect3DIndexBuffer9>, ref HANDLE, HRESULT>)_vTable[27])
                    (thisPtr, Length, Usage, Format, Pool, out ppIndexBuffer, ref pSharedHandle);
            }
        }

        /// <summary>
        /// Creates a render-target surface.
        /// </summary>
        /// <param name="Width">
        /// Width of the render-target surface, in pixels.
        /// </param>
        /// <param name="Height">
        /// Height of the render-target surface, in pixels.
        /// </param>
        /// <param name="Format">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the format of the render target.
        /// </param>
        /// <param name="MultiSample">
        /// Member of the <see cref="D3DMULTISAMPLE_TYPE"/> enumerated type, which describes the multisampling buffer type.
        /// This parameter specifies the antialiasing type for this render target.
        /// When this surface is passed to <see cref="SetRenderTarget"/>, its multisample type must be the same as
        /// that of the depth-stencil set by <see cref="SetDepthStencilSurface"/>.
        /// </param>
        /// <param name="MultisampleQuality">
        /// Quality level. 
        /// The valid range is between zero and one less than the level returned by pQualityLevels used by <see cref="IDirect3D9.CheckDeviceMultiSampleType"/>.
        /// Passing a larger value returns the error, <see cref="D3DERR_INVALIDCALL"/>.
        /// The <paramref name="MultisampleQuality"/> values of paired render targets, depth stencil surfaces, and the multisample type must all match.
        /// </param>
        /// <param name="Lockable">
        /// Render targets are not lockable unless the application specifies <see cref="TRUE"/> for Lockable.
        /// Note that lockable render targets reduce performance on some graphics hardware.
        /// The readback performance (moving data from video memory to system memory) depends on the type of hardware used (AGP vs. PCI Express)
        /// and is usually far lower than upload performance (moving data from system to video memory).
        /// If you need read access to render targets, use <see cref="GetRenderTargetData"/> instead of lockable render targets.
        /// </param>
        /// <param name="ppSurface">
        /// Address of a pointer to an <see cref="IDirect3DSurface9"/> interface.
        /// </param>
        /// <param name="pSharedHandle">
        /// Reserved.
        /// Set this parameter to <see cref="NullRef{HANDLE}"/>.
        /// This parameter can be used in Direct3D 9 for Windows Vista to share resources.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_NOTAVAILABLE"/>, <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// Render-target surfaces are placed in the <see cref="D3DPOOL_DEFAULT"/> memory class.
        /// The creation of lockable, multisampled render targets is not supported.
        /// </remarks>
        public HRESULT CreateRenderTarget([In] UINT Width, [In] UINT Height, [In] D3DFORMAT Format, [In] D3DMULTISAMPLE_TYPE MultiSample,
            [In] DWORD MultisampleQuality, [In] BOOL Lockable, [Out] out P<IDirect3DSurface9> ppSurface, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DFORMAT, D3DMULTISAMPLE_TYPE, DWORD, BOOL, out P<IDirect3DSurface9>, ref HANDLE, HRESULT>)_vTable[28])
                    (thisPtr, Width, Height, Format, MultiSample, MultisampleQuality, Lockable, out ppSurface, ref pSharedHandle);
            }
        }

        /// <summary>
        /// Creates a depth-stencil resource.
        /// </summary>
        /// <param name="Width">
        /// Width of the depth-stencil surface, in pixels.
        /// </param>
        /// <param name="Height">
        /// Height of the depth-stencil surface, in pixels.
        /// </param>
        /// <param name="Format">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the format of the depth-stencil surface.
        /// This value must be one of the enumerated depth-stencil formats for this device.
        /// </param>
        /// <param name="MultiSample">
        /// Member of the D3DMULTISAMPLE_TYPE enumerated type, describing the multisampling buffer type.
        /// This value must be one of the allowed multisample types.
        /// When this surface is passed to <see cref="SetDepthStencilSurface"/>,
        /// its multisample type must be the same as that of the render target set by <see cref="SetRenderTarget"/>.
        /// </param>
        /// <param name="MultisampleQuality">
        /// Quality level. The valid range is between zero and one less than the level
        /// returned by pQualityLevels used by <see cref="IDirect3D9.CheckDeviceMultiSampleType"/>.
        /// Passing a larger value returns the error <see cref="D3DERR_INVALIDCALL"/>.
        /// The <paramref name="MultisampleQuality"/> values of paired render targets, depth stencil surfaces,
        /// and the <paramref name="MultiSample"/> type must all match.
        /// </param>
        /// <param name="Discard">
        /// Set this flag to <see cref="TRUE"/> to enable z-buffer discarding, and <see cref="FALSE"/> otherwise.
        /// If this flag is set, the contents of the depth stencil buffer will be invalid
        /// after calling either <see cref="Present"/> or <see cref="SetDepthStencilSurface"/> with a different depth surface.
        /// This flag has the same behavior as the constant, <see cref="D3DPRESENTFLAG_DISCARD_DEPTHSTENCIL"/>, in <see cref="D3DPRESENTFLAG"/>.
        /// </param>
        /// <param name="ppSurface">
        /// Address of a pointer to an <see cref="IDirect3DSurface9"/> interface, representing the created depth-stencil surface resource.
        /// </param>
        /// <param name="pSharedHandle">
        /// Reserved.
        /// Set this parameter to <see cref="NullRef{HANDLE}"/>.
        /// This parameter can be used in Direct3D 9 for Windows Vista to share resources.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_NOTAVAILABLE"/>, <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// The memory class of the depth-stencil buffer is always <see cref="D3DPOOL_DEFAULT"/>.
        /// </remarks>
        public HRESULT CreateDepthStencilSurface([In] UINT Width, [In] UINT Height, [In] D3DFORMAT Format, [In] D3DMULTISAMPLE_TYPE MultiSample,
            [In] DWORD MultisampleQuality, [In] BOOL Discard, [Out] out P<IDirect3DSurface9> ppSurface, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DFORMAT, D3DMULTISAMPLE_TYPE, DWORD, BOOL, out P<IDirect3DSurface9>, ref HANDLE, HRESULT>)_vTable[29])
                    (thisPtr, Width, Height, Format, MultiSample, MultisampleQuality, Discard, out ppSurface, ref pSharedHandle);
            }
        }

        public HRESULT UpdateSurface([In] in IDirect3DSurface9 pSourceSurface, [In] in RECT pSourceRect,
            [In] in IDirect3DSurface9 pDestinationSurface, [In] in POINT pDestPoint)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, in RECT, in IDirect3DSurface9, in POINT, HRESULT>)_vTable[30])
                    (thisPtr, pSourceSurface, pSourceRect, pDestinationSurface, pDestPoint);
            }
        }

        public HRESULT UpdateTexture([In] in IDirect3DBaseTexture9 pSourceTexture, [In] in IDirect3DBaseTexture9 pDestinationTexture)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DBaseTexture9, in IDirect3DBaseTexture9, HRESULT>)_vTable[31])(thisPtr, pSourceTexture, pDestinationTexture);
            }
        }

        /// <summary>
        /// Copies the render-target data from device memory to system memory.
        /// </summary>
        /// <param name="pRenderTarget">
        /// Pointer to an <see cref="IDirect3DSurface9"/> object, representing a render target.
        /// </param>
        /// <param name="pDestSurface">
        /// Pointer to an <see cref="IDirect3DSurface9"/> object, representing a destination surface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_DRIVERINTERNALERROR"/>, <see cref="D3DERR_DEVICELOST"/>, <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// The destination surface must be either an off-screen plain surface or a level of a texture (mipmap or cube texture) created with <see cref="D3DPOOL_SYSTEMMEM"/>.
        /// The source surface must be a regular render target or a level of a render-target texture (mipmap or cube texture) created with <see cref="POOL_DEFAULT"/>.
        /// This method will fail if:
        /// The render target is multisampled.
        /// The source render target is a different size than the destination surface.
        /// The source render target and destination surface formats do not match.
        /// </remarks>
        public HRESULT GetRenderTargetData([In] in IDirect3DSurface9 pRenderTarget, [In] in IDirect3DSurface9 pDestSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, in IDirect3DSurface9, HRESULT>)_vTable[32])(thisPtr, pRenderTarget, pDestSurface);
            }
        }

        /// <summary>
        /// Generates a copy of the device's front buffer and places that copy in a system memory buffer provided by the application.
        /// </summary>
        /// <param name="iSwapChain">
        /// An unsigned integer specifying the swap chain.
        /// </param>
        /// <param name="pDestSurface">
        /// Pointer to an <see cref="IDirect3DSurface9"/> interface that will receive a copy of the contents of the front buffer.
        /// The data is returned in successive rows with no intervening space, starting from the vertically highest row on the device's output to the lowest.
        /// For windowed mode, the size of the destination surface should be the size of the desktop.
        /// For full-screen mode, the size of the destination surface should be the screen size.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_DRIVERINTERNALERROR"/>, <see cref="D3DERR_DEVICELOST"/>, <see cref="D3DERR_INVALIDCALL"/>
        /// </returns>
        /// <remarks>
        /// The buffer pointed to by <paramref name="pDestSurface"/> will be filled with a representation of the front buffer,
        /// converted to the standard 32 bits per pixel format <see cref="D3DFMT_A8R8G8B8"/>.
        /// This method is the only way to capture an antialiased screen shot.
        /// This function is very slow, by design, and should not be used in any performance-critical path.
        /// For more information, see Lost Devices and Retrieved Data.
        /// </remarks>
        public HRESULT GetFrontBufferData([In] UINT iSwapChain, [In] in IDirect3DSurface9 pDestSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, in IDirect3DSurface9, HRESULT>)_vTable[33])(thisPtr, iSwapChain, pDestSurface);
            }
        }

        public HRESULT StretchRect([In] in IDirect3DSurface9 pSourceSurface, [In] in RECT pSourceRect,
            [In] in IDirect3DSurface9 pDestinationSurface, [In] in RECT pDestRect, [In] D3DTEXTUREFILTERTYPE Filter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, in RECT, in IDirect3DSurface9, in RECT, D3DTEXTUREFILTERTYPE, HRESULT>)_vTable[34])
                    (thisPtr, pSourceSurface, pSourceRect, pDestinationSurface, pDestRect, Filter);
            }
        }

        /// <summary>
        /// Allows an application to fill a rectangular area of a <see cref="D3DPOOL_DEFAULT"/> surface with a specified color.
        /// </summary>
        /// <param name="pSurface">
        /// Pointer to the surface to be filled.
        /// </param>
        /// <param name="pRect">
        /// Pointer to the source rectangle.
        /// Using <see cref="NullRef{RECT}"/> means that the entire surface will be filled.
        /// </param>
        /// <param name="color">
        /// Color used for filling.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method can only be applied to a render target, a render-target texture surface,
        /// or an off-screen plain surface with a pool type of <see cref="D3DPOOL_DEFAULT"/>.
        /// <see cref="ColorFill"/> will work with all formats.
        /// However, when using a reference or software device, the only formats supported are
        /// <see cref="D3DFMT_X1R5G5B5"/>, <see cref="D3DFMT_A1R5G5B5"/>, <see cref="D3DFMT_R5G6B5"/>, <see cref="D3DFMT_X8R8G8B8"/>,
        /// <see cref="D3DFMT_A8R8G8B8"/>, <see cref="D3DFMT_YUY2"/>, <see cref="D3DFMT_G8R8_G8B8"/>, <see cref="D3DFMT_UYVY"/>,
        /// <see cref="D3DFMT_R8G8_B8G8"/>, <see cref="D3DFMT_R16F"/>, <see cref="D3DFMT_G16R16F"/>, <see cref="D3DFMT_A16B16G16R16F"/>,
        /// <see cref="D3DFMT_R32F"/>, <see cref="D3DFMT_G32R32F"/>, and <see cref="D3DFMT_A32B32G32R32F"/>.
        /// When using a DirectX 7 or DirectX 8.x driver, the only YUV formats supported are <see cref="D3DFMT_UYVY"/> and <see cref="D3DFMT_YUY2"/>.
        /// </remarks>
        public HRESULT ColorFill([In] in IDirect3DSurface9 pSurface, [In] in RECT pRect, [In] D3DCOLOR color)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, in RECT, D3DCOLOR, HRESULT>)_vTable[35])(thisPtr, pSurface, pRect, color);
            }
        }

        /// <summary>
        /// Create an off-screen surface.
        /// </summary>
        /// <param name="Width">
        /// Width of the surface.
        /// </param>
        /// <param name="Height">
        /// Height of the surface.
        /// </param>
        /// <param name="Format">
        /// Format of the surface.
        /// See <see cref="D3DFORMAT"/>.
        /// </param>
        /// <param name="Pool">
        /// Surface pool type.
        /// See <see cref="D3DPOOL"/>.
        /// </param>
        /// <param name="ppSurface">
        /// Pointer to the <see cref="IDirect3DSurface9"/> interface created.
        /// </param>
        /// <param name="pSharedHandle">
        /// Reserved.
        /// Set this parameter to <see cref="NullRef{HANDLE}"/>.
        /// This parameter can be used in Direct3D 9 for Windows Vista to share resources.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be the following: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="D3DPOOL_SCRATCH"/> will return a surface that has identical characteristics to a surface
        /// created by the DirectX 8.x method <see cref="CreateImageSurface"/>.
        /// <see cref="D3DPOOL_DEFAULT"/> is the appropriate pool for use with the <see cref="StretchRect"/> and <see cref="ColorFill"/>.
        /// <see cref="D3DPOOL_MANAGED"/> is not allowed when creating an offscreen plain surface.
        /// For more information about memory pools, see <see cref="D3DPOOL"/>.
        /// Off-screen plain surfaces are always lockable, regardless of their pool types.
        /// </remarks>
        public HRESULT CreateOffscreenPlainSurface([In] UINT Width, [In] UINT Height, [In] D3DFORMAT Format, [In] D3DPOOL Pool,
            [Out] out P<IDirect3DSurface9> ppSurface, [In][Out] ref HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DFORMAT, D3DPOOL, out P<IDirect3DSurface9>, ref HANDLE, HRESULT>)_vTable[36])
                    (thisPtr, Width, Height, Format, Pool, out ppSurface, ref pSharedHandle);
            }
        }

        public HRESULT SetRenderTarget([In] DWORD RenderTargetIndex, [In] in IDirect3DSurface9 pRenderTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, in IDirect3DSurface9, HRESULT>)_vTable[37])(thisPtr, RenderTargetIndex, pRenderTarget);
            }
        }

        /// <summary>
        /// Retrieves a render-target surface.
        /// </summary>
        /// <param name="RenderTargetIndex">
        /// Index of the render target. See Remarks.
        /// </param>
        /// <param name="ppRenderTarget">
        /// Address of a pointer to an <see cref="IDirect3DSurface9"/> interface, representing the returned render-target surface for this device.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/> if one of the arguments is invalid,
        /// or <see cref="D3DERR_NOTFOUND"/> if there's no render target available for the given index.
        /// </returns>
        /// <remarks>
        /// Typically, methods that return state will not work on a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// This method however, will work even on a pure device because it returns an interface.
        /// The device can now support multiple render targets.
        /// The number of render targets supported by a device is contained in the <see cref="D3DCAPS9.NumSimultaneousRTs"/> member of <see cref="D3DCAPS9"/>.
        /// See Multiple Render Targets (Direct3D 9).
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DSurface9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/> when finished using the <see cref="IDirect3DSurface9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetRenderTarget([In] DWORD RenderTargetIndex, [Out] out P<IDirect3DSurface9> ppRenderTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out P<IDirect3DSurface9>, HRESULT>)_vTable[38])(thisPtr, RenderTargetIndex, out ppRenderTarget);
            }
        }

        public HRESULT SetDepthStencilSurface([In] in IDirect3DSurface9 pNewZStencil)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, HRESULT>)_vTable[39])(thisPtr, pNewZStencil);
            }
        }

        /// <summary>
        /// Gets the depth-stencil surface owned by the Direct3DDevice object.
        /// </summary>
        /// <param name="ppZStencilSurface">
        /// Address of a pointer to an <see cref="IDirect3DSurface9"/> interface, representing the returned depth-stencil surface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the device doesn't have a depth stencil buffer associated with it, the return value will be <see cref="D3DERR_NOTFOUND"/>.
        /// Otherwise, if the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DSurface9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/> when finished using this <see cref="IDirect3DSurface9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetDepthStencilSurface([Out] out P<IDirect3DSurface9> ppZStencilSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DSurface9>, HRESULT>)_vTable[40])(thisPtr, out ppZStencilSurface);
            }
        }

        /// <summary>
        /// Begins a scene.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// The method will fail with <see cref="D3DERR_INVALIDCALL"/> if <see cref="BeginScene"/> is called
        /// while already in a <see cref="BeginScene"/>/<see cref="EndScene"/> pair.
        /// This happens only when <see cref="BeginScene"/> is called twice without first calling <see cref="EndScene"/>.
        /// </returns>
        /// <remarks>
        /// Applications must call <see cref="BeginScene"/> before performing any rendering
        /// and must call <see cref="EndScene"/> when rendering is complete and before calling <see cref="BeginScene"/> again.
        /// If <see cref="BeginScene"/> fails, the device was unable to begin the scene, and there is no need to call <see cref="EndScene"/>.
        /// In fact, calls to <see cref="EndScene"/> will fail if the previous <see cref="BeginScene"/> failed.
        /// This applies to any application that creates multiple swap chains.
        /// There should be one <see cref="BeginScene"/>/<see cref="EndScene"/> pair between any successive calls to present
        /// (either <see cref="Present"/> or <see cref="IDirect3DSwapChain9.Present"/>).
        /// <see cref="BeginScene"/> should be called once before any rendering is performed,
        /// and <see cref="EndScene"/> should be called once after all rendering for a frame has been submitted to the runtime.
        /// Multiple non-nested <see cref="BeginScene"/>/<see cref="EndScene"/> pairs between calls to present are legal,
        /// but having more than one pair may incur a performance hit.
        /// To enable maximal parallelism between the CPU and the graphics accelerator,
        /// it is advantageous to call <see cref="EndScene"/> as far ahead of calling present as possible.
        /// </remarks>
        public HRESULT BeginScene()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[41])(thisPtr);
            }
        }

        /// <summary>
        /// Ends a scene that was begun by calling <see cref="BeginScene"/>.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// The method will fail with <see cref="D3DERR_INVALIDCALL"/> if <see cref="BeginScene"/> is called
        /// while already in a <see cref="BeginScene"/>/<see cref="EndScene"/> pair.
        /// This happens only when <see cref="BeginScene"/> is called twice without first calling <see cref="EndScene"/>.
        /// </returns>
        /// <remarks>
        /// When this method succeeds, the scene has been queued up for rendering by the driver.
        /// This is not a synchronous method, so the scene is not guaranteed to have completed rendering when this method returns.
        /// Applications must call <see cref="BeginScene"/> before performing any rendering
        /// and must call <see cref="EndScene"/> when rendering is complete and before calling <see cref="BeginScene"/> again.
        /// If <see cref="BeginScene"/> fails, the device was unable to begin the scene, and there is no need to call <see cref="EndScene"/>.
        /// In fact, calls to <see cref="EndScene"/> will fail if the previous <see cref="BeginScene"/> failed.
        /// This applies to any application that creates multiple swap chains.
        /// There should be one <see cref="BeginScene"/>/<see cref="EndScene"/> pair between any successive calls to present
        /// (either <see cref="Present"/> or <see cref="IDirect3DSwapChain9.Present"/>).
        /// <see cref="BeginScene"/> should be called once before any rendering is performed,
        /// and <see cref="EndScene"/> should be called once after all rendering for a frame has been submitted to the runtime.
        /// Multiple non-nested <see cref="BeginScene"/>/<see cref="EndScene"/> pairs between calls to present are legal,
        /// but having more than one pair may incur a performance hit.
        /// To enable maximal parallelism between the CPU and the graphics accelerator,
        /// it is advantageous to call <see cref="EndScene"/> as far ahead of calling present as possible.
        /// </remarks>
        public HRESULT EndScene()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[42])(thisPtr);
            }
        }

        /// <summary>
        /// Clears one or more surfaces such as a render target, multiple render targets, a stencil buffer, and a depth buffer.
        /// </summary>
        /// <param name="Count">
        /// Number of rectangles in the array at <paramref name="pRects"/>.
        /// Must be set to 0 if <paramref name="pRects"/> is <see langword="null"/>.
        /// May not be 0 if <paramref name="pRects"/> is a valid pointer.
        /// </param>
        /// <param name="pRects">
        /// Pointer to an array of <see cref="D3DRECT"/> structures that describe the rectangles to clear.
        /// Set a rectangle to the dimensions of the rendering target to clear the entire surface.
        /// Each rectangle uses screen coordinates that correspond to points on the render target.
        /// Coordinates are clipped to the bounds of the viewport rectangle.
        /// To indicate that the entire viewport rectangle is to be cleared, set this parameter to <see langword="null"/> and <paramref name="Count"/> to 0.
        /// </param>
        /// <param name="Flags">
        /// Combination of one or more <see cref="D3DCLEAR"/> flags that specify the surface(s) that will be cleared.
        /// </param>
        /// <param name="Color">
        /// Clear a render target to this ARGB color.
        /// </param>
        /// <param name="Z">
        /// Clear the depth buffer to this new z value which ranges from 0 to 1.
        /// See remarks.
        /// </param>
        /// <param name="Stencil">
        /// Clear the stencil buffer to this new value which ranges from 0 to 2ⁿ-1 (n is the bit depth of the stencil buffer).
        /// See remarks.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Use this method to clear a surface including: a render target, all render targets in an MRT, a stencil buffer, or a depth buffer.
        /// Flags determines how many surfaces are cleared. Use pRects to clear a subset of a surface defined by an array of rectangles.
        /// <see cref="Clear"/> will fail if you:
        /// Try to clear either the depth buffer or the stencil buffer of a render target that does not have an attached depth buffer.
        /// Try to clear the stencil buffer when the depth buffer does not contain stencil data.
        /// </remarks>
        public HRESULT Clear([In] DWORD Count, [In] D3DRECT[] pRects, [In] D3DCLEAR Flags, [In] D3DCOLOR Color, [In] float Z, [In] DWORD Stencil)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, D3DRECT[], D3DCLEAR, D3DCOLOR, float, DWORD, HRESULT>)_vTable[43])
                    (thisPtr, Count, pRects, Flags, Color, Z, Stencil);
            }
        }

        public HRESULT SetTransform([In] D3DTRANSFORMSTATETYPE State, [In] in D3DMATRIX pMatrix)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DTRANSFORMSTATETYPE, in D3DMATRIX, HRESULT>)_vTable[44])(thisPtr, State, pMatrix);
            }
        }

        /// <summary>
        /// Retrieves a matrix describing a transformation state.
        /// </summary>
        /// <param name="State">
        /// Device state variable that is being modified.
        /// This parameter can be any member of the <see cref="D3DTRANSFORMSTATETYPE"/> enumerated type, or the <see cref="D3DTS_WORLDMATRIX"/> macro.
        /// </param>
        /// <param name="pMatrix">
        /// Pointer to a <see cref="D3DMATRIX"/> structure, describing the returned transformation state.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> if one of the arguments is invalid.
        /// </returns>
        /// <remarks>
        /// This method will not return device state for a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// If you want to use this method, you must create your device with any of the other flag values in <see cref="D3DCREATE"/>.
        /// </remarks>
        public HRESULT GetTransform([In] D3DTRANSFORMSTATETYPE State, [Out] out D3DMATRIX pMatrix)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DTRANSFORMSTATETYPE, out D3DMATRIX, HRESULT>)_vTable[45])(thisPtr, State, out pMatrix);
            }
        }

        public HRESULT MultiplyTransform([In] D3DTRANSFORMSTATETYPE unnamedParam1, [In] in D3DMATRIX unnamedParam2)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DTRANSFORMSTATETYPE, in D3DMATRIX, HRESULT>)_vTable[46])(thisPtr, unnamedParam1, unnamedParam2);
            }
        }

        public HRESULT SetViewport([In] in D3DVIEWPORT9 pViewport)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DVIEWPORT9, HRESULT>)_vTable[47])(thisPtr, pViewport);
            }
        }

        /// <summary>
        /// Retrieves the viewport parameters currently set for the device.
        /// </summary>
        /// <param name="pViewport">
        /// Pointer to a <see cref="D3DVIEWPORT9"/> structure, representing the returned viewport parameters.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if the <paramref name="pViewport"/> parameter is invalid.
        /// </returns>
        /// <remarks>
        /// Typically, methods that return state will not work on a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// This method however, will work even on a pure device.
        /// </remarks>
        public HRESULT GetViewport([Out] out D3DVIEWPORT9 pViewport)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DVIEWPORT9, HRESULT>)_vTable[48])(thisPtr, out pViewport);
            }
        }

        public HRESULT SetMaterial([In] in D3DMATERIAL9 pMaterial)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DMATERIAL9, HRESULT>)_vTable[49])(thisPtr, pMaterial);
            }
        }

        /// <summary>
        /// Retrieves the current material properties for the device.
        /// </summary>
        /// <param name="pMaterial">
        /// Pointer to a <see cref="D3DMATERIAL9"/> structure to fill with the currently set material properties.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> if the <paramref name="pMaterial"/> parameter is invalid.
        /// </returns>
        /// <remarks>
        /// This method will not return device state for a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// If you want to use this method, you must create your device with any of the other values in <see cref="D3DCREATE"/>.
        /// </remarks>
        public HRESULT GetMaterial([Out] out D3DMATERIAL9 pMaterial)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DMATERIAL9, HRESULT>)_vTable[50])(thisPtr, out pMaterial);
            }
        }

        public HRESULT SetLight([In] DWORD Index, [In] in D3DLIGHT9 unnamedParam2)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, in D3DLIGHT9, HRESULT>)_vTable[51])(thisPtr, Index, unnamedParam2);
            }
        }

        /// <summary>
        /// Retrieves a set of lighting properties that this device uses.
        /// </summary>
        /// <param name="Index">
        /// Zero-based index of the lighting property set to retrieve.
        /// This method will fail if a lighting property has not been set for this index by calling the <see cref="SetLight"/> method.
        /// </param>
        /// <param name="unnamedParam2">
        /// Pointer to a <see cref="D3DLIGHT9"/> structure that is filled with the retrieved lighting-parameter set.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value is <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method will not return device state for a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// If you want to use this method, you must create your device with any of the other values in <see cref="D3DCREATE"/>.
        /// Retrieve all the properties for an existing light source by calling the <see cref="GetLight"/> method for the device.
        /// When calling the <see cref="GetLight"/> method, pass the zero-based index of the light source
        /// for which the properties will be retrieved as the first parameter, and supply the address of a <see cref="D3DLIGHT9"/> structure as the second parameter.
        /// The device fills the <see cref="D3DLIGHT9"/> structure to describe the lighting properties it uses for the light source at that index.
        /// <code>
        /// // Assume d3dDevice is a valid pointer to an IDirect3DDevice9 interface.
        /// HRESULT hr;
        /// D3DLight9 light;
        /// 
        /// // Get the property information for the first light.
        /// hr = pd3dDevice->GetLight(0, &amp;light);
        /// if (SUCCEEDED(hr))
        ///     // Handle Success
        /// else
        ///     // Handle failure
        /// </code>
        /// If you supply an index outside the range of the light sources assigned in the device,
        /// the <see cref="GetLight"/> method fails, returning <see cref="D3DERR_INVALIDCALL"/>.
        /// When you assign a set of light properties for a light source in a scene,
        /// the light source can be activated by calling the <see cref="LightEnable"/> method for the device.
        /// New light sources are disabled by default.
        /// The <see cref="LightEnable"/> method accepts two parameters.
        /// Set the first parameter to the zero-based index of the light source to be affected by the method,
        /// and set the second parameter to <see cref="TRUE"/> to enable the light or <see cref="FALSE"/> to disable it.
        /// The following code example illustrates the use of this method by enabling the first light source in the device's list of light source properties.
        /// <code>
        /// // Assume d3dDevice is a valid pointer to an IDirect3DDevice9 interface.
        /// HRESULT hr;
        /// 
        /// hr = pd3dDevice->LightEnable(0, TRUE);
        /// if (SUCCEEDED(hr))
        ///     // Handle Success
        /// else
        ///     // Handle failure
        /// </code>
        /// Check the <see cref="D3DCAPS9.MaxActiveLights"/> member of the <see cref="D3DCAPS9"/> structure
        /// when you retrieve device capabilities to determine the maximum number of active lights supported by that device.
        /// If you enable or disable a light that has no properties that are set with <see cref="SetLight"/>,
        /// the <see cref="LightEnable"/> method creates a light source with the properties listed in following table and enables or disables it.
        /// </remarks>
        public HRESULT GetLight([In] DWORD Index, [Out] out D3DLIGHT9 unnamedParam2)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out D3DLIGHT9, HRESULT>)_vTable[52])(thisPtr, Index, out unnamedParam2);
            }
        }

        /// <summary>
        /// Enables or disables a set of lighting parameters within a device.
        /// </summary>
        /// <param name="Index">
        /// Zero-based index of the set of lighting parameters that are the target of this method.
        /// </param>
        /// <param name="Enable">
        /// Value that indicates if the set of lighting parameters are being enabled or disabled.
        /// Set this parameter to <see cref="TRUE"/> to enable lighting with the parameters at the specified index, or <see cref="FALSE"/> to disable it.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// If a value for <paramref name="Index"/> is outside the range of the light property sets assigned within the device, 
        /// the <see cref="LightEnable"/> method creates a light source represented by a <see cref="D3DLIGHT9"/> structure
        /// with the following properties and sets its enabled state to the value specified in <paramref name="Enable"/>.
        /// Member                                  Default
        /// <see cref="D3DLIGHT9.Type"/>            <see cref="D3DLIGHT_DIRECTIONAL"/>
        /// <see cref="D3DLIGHT9.Diffuse"/>         (R:1, G:1, B:1, A:0)
        /// <see cref="D3DLIGHT9.Specular"/>        (R:0, G:0, B:0, A:0)
        /// <see cref="D3DLIGHT9.Ambient"/>         (R:0, G:0, B:0, A:0)
        /// <see cref="D3DLIGHT9.Position"/>        (0, 0, 0)
        /// <see cref="D3DLIGHT9.Direction"/>       (0, 0, 1)
        /// <see cref="D3DLIGHT9.Range"/>           0
        /// <see cref="D3DLIGHT9.Falloff"/>         0
        /// <see cref="D3DLIGHT9.Attenuation0"/>    0
        /// <see cref="D3DLIGHT9.Attenuation1"/>    0
        /// <see cref="D3DLIGHT9.Attenuation2"/>    0
        /// <see cref="D3DLIGHT9.Theta"/>           0
        /// <see cref="D3DLIGHT9.Phi"/>             0
        /// </remarks>
        public HRESULT LightEnable([In] DWORD Index, [In] BOOL Enable)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, BOOL, HRESULT>)_vTable[53])(thisPtr, Index, Enable);
            }
        }

        /// <summary>
        /// Retrieves the activity status - enabled or disabled - for a set of lighting parameters within a device.
        /// </summary>
        /// <param name="Index">
        /// Zero-based index of the set of lighting parameters that are the target of this method.
        /// </param>
        /// <param name="pEnable">
        /// Pointer to a variable to fill with the status of the specified lighting parameters.
        /// After the call, a nonzero value at this address indicates that the specified lighting parameters are enabled; a value of 0 indicates that they are disabled.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method will not return device state for a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// If you want to use this method, you must create your device with any of the other values in <see cref="D3DCREATE"/>.
        /// </remarks>
        public HRESULT GetLightEnable([In] DWORD Index, [Out] out BOOL pEnable)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out BOOL, HRESULT>)_vTable[54])(thisPtr, Index, out pEnable);
            }
        }

        public HRESULT SetClipPlane([In] DWORD Index, [In] float[] pPlane)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, float[], HRESULT>)_vTable[55])(thisPtr, Index, pPlane);
            }
        }

        /// <summary>
        /// Retrieves the coefficients of a user-defined clipping plane for the device.
        /// </summary>
        /// <param name="Index">
        /// Index of the clipping plane for which the plane equation coefficients are retrieved.
        /// </param>
        /// <param name="pPlane">
        /// Pointer to a four-element array of values that represent the coefficients of the clipping plane in the form of the general plane equation.
        /// See Remarks.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value is <see cref="D3DERR_INVALIDCALL"/>.
        /// This error indicates that the value in <paramref name="Index"/> exceeds the maximum clipping plane index supported by the device,
        /// or that the array at <paramref name="pPlane"/> is not large enough to contain four floating-point values.
        /// </returns>
        /// <remarks>
        /// This method will not return device state for a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// If you want to use this method, you must create your device with any of the other values in <see cref="D3DCREATE"/>.
        /// The coefficients that this method reports take the form of the general plane equation.
        /// If the values in the array at <paramref name="pPlane"/> were labeled A, B, C, and D in the order that they appear in the array,
        /// they would fit into the general plane equation so that Ax + By + Cz + Dw = 0.
        /// A point with homogeneous coordinates (x, y, z, w) is visible in the half space of the plane if Ax + By + Cz + Dw >= 0.
        /// Points that exist on or behind the clipping plane are clipped from the scene.
        /// The plane equation used by this method exists in world space and is set by a previous call to the <see cref="SetClipPlane"/> method.
        /// </remarks>
        public HRESULT GetClipPlane([In] DWORD Index, [Out] float[] pPlane)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, float[], HRESULT>)_vTable[56])(thisPtr, Index, pPlane);
            }
        }

        public HRESULT SetRenderState([In] D3DRENDERSTATETYPE State, [In] DWORD Value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DRENDERSTATETYPE, DWORD, HRESULT>)_vTable[57])(thisPtr, State, Value);
            }
        }

        /// <summary>
        /// Retrieves a render-state value for a device.
        /// </summary>
        /// <param name="State">
        /// Device state variable that is being queried.
        /// This parameter can be any member of the <see cref="D3DRENDERSTATETYPE"/> enumerated type.
        /// </param>
        /// <param name="pValue">
        /// Pointer to a variable that receives the value of the queried render state variable when the method returns.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> if one of the arguments is invalid.
        /// </returns>
        /// <remarks>
        /// This method will not return device state for a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// If you want to use this method, you must create your device with any of the other values in <see cref="D3DCREATE"/>.
        /// </remarks>
        public HRESULT GetRenderState([In] D3DRENDERSTATETYPE State, [Out] out DWORD pValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DRENDERSTATETYPE, out DWORD, HRESULT>)_vTable[58])(thisPtr, State, out pValue);
            }
        }

        /// <summary>
        /// Creates a new state block that contains the values for all device states, vertex-related states, or pixel-related states.
        /// </summary>
        /// <param name="Type">
        /// Type of state data that the method should capture.
        /// This parameter can be set to a value defined in the <see cref="D3DSTATEBLOCKTYPE"/> enumerated type.
        /// </param>
        /// <param name="ppSB">
        /// Pointer to a state block interface. See <see cref="IDirect3DStateBlock9"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// Vertex-related device states typically refer to those states that affect how the system processes vertices.
        /// Pixel-related states generally refer to device states that affect how the system processes pixel or depth-buffer data during rasterization.
        /// Some states are contained in both groups.
        /// Differences between Direct3D 9 and Direct3D 10:
        /// In Direct3D 9, a state block contains state data, for the states it was requested to capture, when the object is created.
        /// To change the value of the state block, call <see cref="IDirect3DStateBlock9.Capture"/> or <see cref="BeginStateBlock"/>/<see cref="EndStateBlock"/>.
        /// There is no state saved when a state block object is created in Direct3D 10.
        /// </remarks>
        public HRESULT CreateStateBlock([In] D3DSTATEBLOCKTYPE Type, [Out] out P<IDirect3DStateBlock9> ppSB)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DSTATEBLOCKTYPE, out P<IDirect3DStateBlock9>, HRESULT>)_vTable[59])(thisPtr, Type, out ppSB);
            }
        }

        /// <summary>
        /// Signals Direct3D to begin recording a device-state block.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following: <see cref="D3DERR_INVALIDCALL"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// Applications can ensure that all recorded states are valid by calling the <see cref="ValidateDevice"/> method prior to calling this method.
        /// The following methods can be recorded in a state block, after calling <see cref="BeginStateBlock"/> and before <see cref="EndStateBlock"/>.
        /// <see cref="LightEnable"/>, <see cref="SetClipPlane"/>, <see cref="SetCurrentTexturePalette"/>, <see cref="SetFVF"/>,
        /// <see cref="SetIndices"/>, <see cref="SetLight"/>, <see cref="SetMaterial"/>, <see cref="SetNPatchMode"/>,
        /// <see cref="SetPixelShader"/>, <see cref="SetPixelShaderConstantB"/>, <see cref="SetPixelShaderConstantF"/>,
        /// <see cref="SetPixelShaderConstantI"/>, <see cref="SetRenderState"/>, <see cref="SetSamplerState"/>,
        /// <see cref="SetScissorRect"/>, <see cref="SetStreamSource"/>, <see cref="SetStreamSourceFreq"/>, <see cref="SetTexture"/>,
        /// <see cref="SetTextureStageState"/>, <see cref="SetTransform"/>, <see cref="SetViewport"/>, <see cref="SetVertexDeclaration"/>,
        /// <see cref="SetVertexShader"/>, <see cref="SetVertexShaderConstantB"/>,<see cref="SetVertexShaderConstantF"/>,
        /// <see cref="SetVertexShaderConstantI"/>
        /// The ordering of state changes in a state block is not guaranteed.
        /// If the same state is specified multiple times in a state block, only the last value is used.
        /// </remarks>
        public HRESULT BeginStateBlock()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[60])(thisPtr);
            }
        }

        /// <summary>
        /// Signals Direct3D to stop recording a device-state block and retrieve a pointer to the state block interface.
        /// </summary>
        /// <param name="ppSB">
        /// Pointer to a state block interface.
        /// See <see cref="IDirect3DStateBlock9"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT EndStateBlock([Out] out P<IDirect3DStateBlock9> ppSB)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DStateBlock9>, HRESULT>)_vTable[61])(thisPtr, out ppSB);
            }
        }

        public HRESULT SetClipStatus([In] in D3DCLIPSTATUS9 pClipStatus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DCLIPSTATUS9, HRESULT>)_vTable[62])(thisPtr, pClipStatus);
            }
        }

        /// <summary>
        /// Retrieves the clip status.
        /// </summary>
        /// <param name="pClipStatus">
        /// Pointer to a <see cref="D3DCLIPSTATUS9"/> structure that describes the clip status.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if the argument is invalid.
        /// </returns>
        /// <remarks>
        /// When clipping is enabled during vertex processing (by <see cref="ProcessVertices"/>, <see cref="DrawPrimitive"/>, or other drawing functions),
        /// Direct3D computes a clip code for every vertex.
        /// The clip code is a combination of D3DCS_* bits.
        /// When a vertex is outside a particular clipping plane, the corresponding bit is set in the clipping code.
        /// Direct3D maintains the clip status using <see cref="D3DCLIPSTATUS9"/>,
        /// which has <see cref="D3DCLIPSTATUS9.ClipUnion"/> and <see cref="D3DCLIPSTATUS9.ClipIntersection"/> members.
        /// <see cref="D3DCLIPSTATUS9.ClipUnion"/> is a bitwise "OR" of all vertex clip codes
        /// and <see cref="D3DCLIPSTATUS9.ClipIntersection"/> is a bitwise "AND" of all vertex clip codes.
        /// Initial values are zero for <see cref="D3DCLIPSTATUS9.ClipUnion"/> and 0xFFFFFFFF for ClipIntersection.
        /// When <see cref="D3DRS_CLIPPING"/> is set to <see cref="FALSE"/>,
        /// <see cref="D3DCLIPSTATUS9.ClipUnion"/> and <see cref="D3DCLIPSTATUS9.ClipIntersection"/> are set to zero.
        /// Direct3D updates the clip status during drawing calls.
        /// To compute clip status for a particular object, set <see cref="D3DCLIPSTATUS9.ClipUnion"/>
        /// and <see cref="D3DCLIPSTATUS9.ClipIntersection"/> to their initial value and continue drawing.
        /// Clip status is not updated by <see cref="DrawRectPatch"/> and <see cref="DrawTriPatch"/> because there is no software emulation for them.
        /// Clip status is used during software vertex processing.
        /// Therefore, this method is not supported on pure or nonpure hardware processing devices.
        /// For more information about pure devices, see <see cref="D3DCREATE"/>.
        /// </remarks>
        public HRESULT GetClipStatus([Out] out D3DCLIPSTATUS9 pClipStatus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DCLIPSTATUS9, HRESULT>)_vTable[63])(thisPtr, out pClipStatus);
            }
        }

        /// <summary>
        /// Retrieves a texture assigned to a stage for a device.
        /// </summary>
        /// <param name="Stage">
        /// Stage identifier of the texture to retrieve.
        /// Stage identifiers are zero-based.
        /// </param>
        /// <param name="ppTexture">
        /// Address of a pointer to an <see cref="IDirect3DBaseTexture9"/> interface, representing the returned texture.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Typically, methods that return state will not work on a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// This method however, will work even on a pure device because it returns an interface.
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DTexture9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/> when finished using this <see cref="IDirect3DTexture9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetTexture([In] DWORD Stage, [Out] out P<IDirect3DBaseTexture9> ppTexture)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out P<IDirect3DBaseTexture9>, HRESULT>)_vTable[64])(thisPtr, Stage, out ppTexture);
            }
        }

        public HRESULT SetTexture([In] DWORD Stage, [In] in IDirect3DBaseTexture9 pTexture)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, in IDirect3DBaseTexture9, HRESULT>)_vTable[65])(thisPtr, Stage, pTexture);
            }
        }

        /// <summary>
        /// Retrieves a state value for an assigned texture.
        /// </summary>
        /// <param name="Stage">
        /// Stage identifier of the texture for which the state is retrieved.
        /// Stage identifiers are zero-based.
        /// Devices can have up to eight set textures, so the maximum value allowed for Stage is 7.
        /// </param>
        /// <param name="Type">
        /// Texture state to retrieve.
        /// This parameter can be any member of the <see cref="D3DTEXTURESTAGESTATETYPE"/> enumerated type.
        /// </param>
        /// <param name="pValue">
        /// Pointer a variable to fill with the retrieved state value.
        /// The meaning of the retrieved value is determined by the <paramref name="Type"/> parameter.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method will not return device state for a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>
        /// If you want to use this method, you must create your device with any of the other flag values in <see cref="D3DCREATE"/>
        /// </remarks>
        public HRESULT GetTextureStageState([In] DWORD Stage, [In] D3DTEXTURESTAGESTATETYPE Type, [Out] out DWORD pValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, D3DTEXTURESTAGESTATETYPE, out DWORD, HRESULT>)_vTable[66])(thisPtr, Stage, Type, out pValue);
            }
        }

        public HRESULT SetTextureStageState([In] DWORD Stage, [In] D3DTEXTURESTAGESTATETYPE Type, [In] DWORD Value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, D3DTEXTURESTAGESTATETYPE, DWORD, HRESULT>)_vTable[67])(thisPtr, Stage, Type, Value);
            }
        }

        /// <summary>
        /// Gets the sampler state value.
        /// </summary>
        /// <param name="Sampler">
        /// The sampler stage index.
        /// </param>
        /// <param name="Type">
        /// This parameter can be any member of the <see cref="D3DSAMPLERSTATETYPE"/> enumerated type.
        /// </param>
        /// <param name="pValue">
        /// State value to get.
        /// The meaning of this value is determined by the <paramref name="Type"/> parameter.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method will not return device state for a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// If you want to use this method, you must create your device with any of the other values in <see cref="D3DCREATE"/>.
        /// </remarks>
        public HRESULT GetSamplerState([In] DWORD Sampler, [In] D3DSAMPLERSTATETYPE Type, [Out] out DWORD pValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, D3DSAMPLERSTATETYPE, out DWORD, HRESULT>)_vTable[68])(thisPtr, Sampler, Type, out pValue);
            }
        }

        public HRESULT SetSamplerState([In] DWORD Sampler, [In] D3DSAMPLERSTATETYPE Type, [In] DWORD Value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, D3DSAMPLERSTATETYPE, DWORD, HRESULT>)_vTable[69])(thisPtr, Sampler, Type, Value);
            }
        }

        public HRESULT ValidateDevice()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[70])(thisPtr);
            }
        }

        public HRESULT SetPaletteEntries([In] UINT PaletteNumber, [In] PALETTEENTRY[] pEntries)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, PALETTEENTRY[], HRESULT>)_vTable[71])(thisPtr, PaletteNumber, pEntries);
            }
        }

        /// <summary>
        /// Retrieves palette entries.
        /// </summary>
        /// <param name="PaletteNumber">
        /// An ordinal value identifying the particular palette to retrieve.
        /// </param>
        /// <param name="pEntries">
        /// Pointer to a <see cref="PALETTEENTRY"/> structure, representing the returned palette entries.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// For more information about <see cref="PALETTEENTRY"/>, see the Platform SDK.
        /// Note
        /// As of Direct3D 9, the <see cref="PALETTEENTRY.peFlags"/> member of the <see cref="PALETTEENTRY"/> structure
        /// does not workthe way it is documented in the Platform SDK.
        /// The <see cref="PALETTEENTRY.peFlags"/> member is now the alpha channel for 8-bit palettized formats.
        /// </remarks>
        public HRESULT GetPaletteEntries([In] UINT PaletteNumber, [Out] PALETTEENTRY[] pEntries)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, PALETTEENTRY[], HRESULT>)_vTable[72])(thisPtr, PaletteNumber, pEntries);
            }
        }

        public HRESULT SetCurrentTexturePalette([In] UINT PaletteNumber)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[73])(thisPtr, PaletteNumber);
            }
        }

        /// <summary>
        /// Retrieves the current texture palette.
        /// </summary>
        /// <param name="PaletteNumber">
        /// Pointer to a returned value that identifies the current texture palette.
        /// </param>
        /// <returns>
        /// f the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetCurrentTexturePalette([Out] out UINT PaletteNumber)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[74])(thisPtr, out PaletteNumber);
            }
        }

        public HRESULT SetScissorRect([In] in RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in RECT, HRESULT>)_vTable[75])(thisPtr, pRect);
            }
        }

        /// <summary>
        /// Gets the scissor rectangle.
        /// </summary>
        /// <param name="pRect">
        /// Returns a pointer to a <see cref="RECT"/> structure that defines the rendering area within the render target if scissor test is enabled.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be the following: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// The scissor rectangle is used as a rectangular clipping region.
        /// See Rectangles (Direct3D 9) for further information on the use of rectangles in DirectX.
        /// </remarks>
        public HRESULT GetScissorRect([Out] out RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out RECT, HRESULT>)_vTable[76])(thisPtr, out pRect);
            }
        }

        public HRESULT SetSoftwareVertexProcessing([In] BOOL bSoftware)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[77])(thisPtr, bSoftware);
            }
        }

        /// <summary>
        /// Gets the vertex processing (hardware or software) mode.
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if software vertex processing is set.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// An application can create a mixed-mode device to use both the software vertex processing and the hardware vertex processing.
        /// To switch between the two vertex processing modes in DirectX 8.x,
        /// use <see cref="SetRenderState"/> with the render state <see cref="D3DRS_SOFTWAREVERTEXPROCESSING"/> and the appropriate <see cref="BOOL"/> argument.
        /// The drawback of the render state approach was the difficulty in defining the semantics for state blocks.
        /// Applications and the runtime had to do extra work and be careful while recording and playing back state blocks.
        /// In Direct3D 9, use <see cref="SetSoftwareVertexProcessing"/> instead. This new API is not recorded by StateBlocks.
        /// Also refer to the notes for the <see cref="D3DCREATE"/> constants.
        /// </remarks>
        public BOOL GetSoftwareVertexProcessing()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[78])(thisPtr);
            }
        }

        public HRESULT SetNPatchMode([In] float nSegments)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, float, HRESULT>)_vTable[79])(thisPtr, nSegments);
            }
        }

        /// <summary>
        /// Gets the N-patch mode segments.
        /// </summary>
        /// <returns>
        /// Specifies the number of subdivision segments.
        /// If the number of segments is less than 1.0, N-patches are disabled.
        /// The default value is 0.0.
        /// </returns>
        public float GetNPatchMode()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, float>)_vTable[80])(thisPtr);
            }
        }

        /// <summary>
        /// Renders a sequence of nonindexed, geometric primitives of the specified type from the current set of data input streams.
        /// </summary>
        /// <param name="PrimitiveType">
        /// Member of the <see cref="D3DPRIMITIVETYPE"/> enumerated type, describing the type of primitive to render.
        /// </param>
        /// <param name="StartVertex">
        /// Index of the first vertex to load.
        /// Beginning at <paramref name="StartVertex"/> the correct number of vertices will be read out of the vertex buffer.
        /// </param>
        /// <param name="PrimitiveCount">
        /// Number of primitives to render.
        /// The maximum number of primitives allowed is determined
        /// by checking the <see cref="D3DCAPS9.MaxPrimitiveCount"/> member of the <see cref="D3DCAPS9"/> structure.
        /// <paramref name="PrimitiveCount"/> is the number of primitives as determined by the primitive type.
        /// If it is a line list, each primitive has two vertices.
        /// If it is a triangle list, each primitive has three vertices.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// When converting a legacy application to Direct3D 9, you must add a call to either <see cref="SetFVF"/> to use the fixed function pipeline,
        /// or <see cref="SetVertexDeclaration"/> to use a vertex shader before you make any Draw calls.
        /// </remarks>
        public HRESULT DrawPrimitive([In] D3DPRIMITIVETYPE PrimitiveType, [In] UINT StartVertex, [In] UINT PrimitiveCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DPRIMITIVETYPE, UINT, UINT, HRESULT>)_vTable[81])(thisPtr, PrimitiveType, StartVertex, PrimitiveCount);
            }
        }

        /// <summary>
        /// Based on indexing, renders the specified geometric primitive into an array of vertices.
        /// </summary>
        /// <param name="unnamedParam1">
        /// Member of the <see cref="D3DPRIMITIVETYPE"/> enumerated type, describing the type of primitive to render.
        /// <see cref="D3DPT_POINTLIST"/> is not supported with this method. See Remarks.
        /// </param>
        /// <param name="BaseVertexIndex">
        /// Offset from the start of the vertex buffer to the first vertex. See Scenario 4.
        /// </param>
        /// <param name="MinVertexIndex">
        /// Minimum vertex index for vertices used during this call.
        /// This is a zero based index relative to <paramref name="BaseVertexIndex"/>.
        /// </param>
        /// <param name="NumVertices">
        /// Number of vertices used during this call.
        /// The first vertex is located at index: <paramref name="BaseVertexIndex"/> + <paramref name="MinVertexIndex"/>.
        /// </param>
        /// <param name="startIndex">
        /// Index of the first index to use when accessing the vertex buffer.
        /// Beginning at StartIndex to index vertices from the vertex buffer.
        /// </param>
        /// <param name="primCount">
        /// Number of primitives to render.
        /// The number of vertices used is a function of the primitive count and the primitive type.
        /// The maximum number of primitives allowed is determined
        /// by checking the <see cref="D3DCAPS9.MaxPrimitiveCount"/> member of the <see cref="D3DCAPS9"/> structure.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be the following: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method draws indexed primitives from the current set of data input streams.
        /// <paramref name="MinVertexIndex"/> and all the indices in the index stream are relative to the <paramref name="BaseVertexIndex"/>.
        /// The <paramref name="MinVertexIndex"/> and <paramref name="NumVertices"/> parameters
        /// specify the range of vertex indices used for each <see cref="DrawIndexedPrimitive"/> call.
        /// These are used to optimize vertex processing of indexed primitives by processing a sequential range of vertices prior to indexing into these vertices.
        /// It is invalid for any indices used during this call to reference any vertices outside of this range.
        /// <see cref="DrawIndexedPrimitive"/> fails if no index array is set.
        /// The <see cref="D3DPT_POINTLIST"/> member of the <see cref="D3DPRIMITIVETYPE"/> enumerated type is not supported and is not a valid type for this method.
        /// When converting a legacy application to Direct3D 9, you must add a call to either <see cref="SetFVF"/> to use the fixed function pipeline,
        /// or <see cref="SetVertexDeclaration"/> to use a vertex shader before you make any Draw calls.
        /// </remarks>
        public HRESULT DrawIndexedPrimitive([In] D3DPRIMITIVETYPE unnamedParam1, [In] INT BaseVertexIndex, [In] UINT MinVertexIndex,
            [In] UINT NumVertices, [In] UINT startIndex, [In] UINT primCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DPRIMITIVETYPE, INT, UINT, UINT, UINT, UINT, HRESULT>)_vTable[82])
                    (thisPtr, unnamedParam1, BaseVertexIndex, MinVertexIndex, NumVertices, startIndex, primCount);
            }
        }

        /// <summary>
        /// Renders data specified by a user memory pointer as a sequence of geometric primitives of the specified type.
        /// </summary>
        /// <param name="PrimitiveType">
        /// Member of the <see cref="D3DPRIMITIVETYPE"/> enumerated type, describing the type of primitive to render.
        /// </param>
        /// <param name="PrimitiveCount">
        /// Number of primitives to render.
        /// The maximum number of primitives allowed is determined
        /// by checking the <see cref="D3DCAPS9.MaxPrimitiveCount"/> member of the <see cref="D3DCAPS9"/> structure.
        /// <paramref name="PrimitiveCount"/> is the number of primitives as determined by the primitive type.
        /// </param>
        /// <param name="pVertexStreamZeroData">
        /// User memory pointer to the vertex data.
        /// </param>
        /// <param name="VertexStreamZeroStride">
        /// The number of bytes of data for each vertex. This value may not be 0.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be the following: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method is intended for use in applications that are unable to store their vertex data in vertex buffers.
        /// This method supports only a single vertex stream.
        /// The effect of this call is to use the provided vertex data pointer and stride for vertex stream 0.
        /// It is invalid to have the declaration of the current vertex shader refer to vertex streams other than stream 0.
        /// Following any <see cref="DrawPrimitiveUP"/> call, the stream 0 settings,
        /// referenced by <see cref="GetStreamSource"/>, are set to <see cref="NULL"/>.
        /// The vertex data passed to <see cref="DrawPrimitiveUP"/> does not need to persist after the call.
        /// Direct3D completes its access to that data prior to returning from the call.
        /// When converting a legacy application to Direct3D 9, you must add a call to either <see cref="SetFVF"/> to use the fixed function pipeline,
        /// or <see cref="SetVertexDeclaration"/> to use a vertex shader before you make any Draw calls.
        /// </remarks>
        public HRESULT DrawPrimitiveUP([In] D3DPRIMITIVETYPE PrimitiveType, [In] UINT PrimitiveCount, [In] IntPtr pVertexStreamZeroData, [In] UINT VertexStreamZeroStride)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DPRIMITIVETYPE, UINT, IntPtr, UINT, HRESULT>)_vTable[83])
                    (thisPtr, PrimitiveType, PrimitiveCount, pVertexStreamZeroData, VertexStreamZeroStride);
            }
        }

        /// <summary>
        /// Renders the specified geometric primitive with data specified by a user memory pointer.
        /// </summary>
        /// <param name="PrimitiveType">
        /// Member of the <see cref="D3DPRIMITIVETYPE"/> enumerated type, describing the type of primitive to render.
        /// </param>
        /// <param name="MinVertexIndex">
        /// Minimum vertex index.
        /// This is a zero-based index.
        /// </param>
        /// <param name="NumVertices">
        /// Number of vertices used during this call.
        /// The first vertex is located at index: <paramref name="MinVertexIndex"/>.
        /// </param>
        /// <param name="PrimitiveCount">
        /// Number of primitives to render.
        /// The maximum number of primitives allowed is determined
        /// by checking the <see cref="D3DCAPS9.MaxPrimitiveCount"/> member of the <see cref="D3DCAPS9"/> structure
        /// (the number of indices is a function of the primitive count and the primitive type).
        /// </param>
        /// <param name="pIndexData">
        /// User memory pointer to the index data.
        /// </param>
        /// <param name="IndexDataFormat">
        /// Member of the D3DFORMAT enumerated type, describing the format of the index data. The valid settings are either:
        /// <see cref="D3DFMT_INDEX16"/>, <see cref="D3DFMT_INDEX32"/>
        /// </param>
        /// <param name="pVertexStreamZeroData">
        /// User memory pointer to the vertex data.
        /// The vertex data must be in stream 0.
        /// </param>
        /// <param name="VertexStreamZeroStride">
        /// The number of bytes of data for each vertex.
        /// This value may not be 0.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be the following: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method is intended for use in applications that are unable to store their vertex data in vertex buffers.
        /// This method supports only a single vertex stream, which must be declared as stream 0.
        /// Following any <see cref="DrawIndexedPrimitiveUP"/> call, the stream 0 settings,
        /// referenced by <see cref="GetStreamSource"/>, are set to <see cref="NULL"/>.
        /// Also, the index buffer setting for <see cref="SetIndices"/> is set to <see cref="NULL"/>.
        /// The vertex data passed to <see cref="DrawIndexedPrimitiveUP"/> does not need to persist after the call.
        /// Direct3D completes its access to that data prior to returning from the call.
        /// When converting a legacy application to Direct3D 9, you must add a call to either <see cref="SetFVF"/> to use the fixed function pipeline,
        /// or <see cref="SetVertexDeclaration"/> to use a vertex shader before you make any Draw calls.
        /// </remarks>
        public HRESULT DrawIndexedPrimitiveUP([In] D3DPRIMITIVETYPE PrimitiveType, [In] UINT MinVertexIndex, [In] UINT NumVertices,
            [In] UINT PrimitiveCount, [In] IntPtr pIndexData, [In] D3DFORMAT IndexDataFormat, [In] IntPtr pVertexStreamZeroData, [In] UINT VertexStreamZeroStride)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DPRIMITIVETYPE, UINT, UINT, UINT, IntPtr, D3DFORMAT, IntPtr, UINT, HRESULT>)_vTable[84])
                    (thisPtr, PrimitiveType, MinVertexIndex, NumVertices, PrimitiveCount, pIndexData, IndexDataFormat, pVertexStreamZeroData, VertexStreamZeroStride);
            }
        }

        public HRESULT ProcessVertices([In] UINT SrcStartIndex, [In] UINT DestIndex, [In] UINT VertexCount,
            [In] in IDirect3DVertexBuffer9 pDestBuffer, [In] in IDirect3DVertexDeclaration9 pVertexDecl, [In] DWORD Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, in IDirect3DVertexBuffer9, in IDirect3DVertexDeclaration9, DWORD, HRESULT>)_vTable[85])
                    (thisPtr, SrcStartIndex, DestIndex, VertexCount, pDestBuffer, pVertexDecl, Flags);
            }
        }

        /// <summary>
        /// Create a vertex shader declaration from the device and the vertex elements.
        /// </summary>
        /// <param name="pVertexElements">
        /// An array of <see cref="D3DVERTEXELEMENT9"/> vertex elements.
        /// </param>
        /// <param name="ppDecl">
        /// Pointer to an <see cref="IDirect3DVertexDeclaration9"/> pointer that returns the created vertex shader declaration.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// See the Vertex Declaration (Direct3D 9) page for a detailed description of how to map vertex declarations between different versions of DirectX.
        /// </remarks>
        public HRESULT CreateVertexDeclaration([In] D3DVERTEXELEMENT9[] pVertexElements, [Out] out P<IDirect3DVertexDeclaration9> ppDecl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DVERTEXELEMENT9[], out P<IDirect3DVertexDeclaration9>, HRESULT>)_vTable[86])(thisPtr, pVertexElements, out ppDecl);
            }
        }

        public HRESULT SetVertexDeclaration([In] in IDirect3DVertexDeclaration9 pDecl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DVertexDeclaration9, HRESULT>)_vTable[87])(thisPtr, pDecl);
            }
        }

        /// <summary>
        /// Gets a vertex shader declaration.
        /// </summary>
        /// <param name="ppDecl">
        /// Pointer to an <see cref="IDirect3DVertexDeclaration9"/> object that is returned.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetVertexDeclaration([Out] out P<IDirect3DVertexDeclaration9> ppDecl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DVertexDeclaration9>, HRESULT>)_vTable[88])(thisPtr, out ppDecl);
            }
        }

        public HRESULT SetFVF([In] DWORD FVF)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[89])(thisPtr, FVF);
            }
        }

        /// <summary>
        /// Gets the fixed vertex function declaration.
        /// </summary>
        /// <param name="pFVF">
        /// A DWORD pointer to the fixed function vertex type.
        /// For more information, see <see cref="D3DFVF"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// The fixed vertex function declaration is a set of FVF flags that determine how vertices processed by the fixed function pipeline will be used.
        /// </remarks>
        public HRESULT GetFVF([Out] out D3DFVF pFVF)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DFVF, HRESULT>)_vTable[90])(thisPtr, out pFVF);
            }
        }

        /// <summary>
        /// Creates a vertex shader.
        /// </summary>
        /// <param name="pFunction">
        /// Pointer to an array of tokens that represents the vertex shader, including any embedded debug and symbol table information.
        /// Use a function such as <see cref="D3DXCompileShader"/> to create the array from a HLSL shader.
        /// Use a function like <see cref="D3DXAssembleShader"/> to create the token array from an assembly language shader.
        /// Use a function like <see cref="ID3DXEffectCompiler.CompileShader"/> to create the array from an effect.
        /// </param>
        /// <param name="ppShader">
        /// Pointer to the returned vertex shader interface (see <see cref="IDirect3DVertexShader9"/>).
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// When a device is created, <see cref="IDirect3D9.CreateDevice"/> uses the behavior flag to determine whether to process vertices in hardware or software.
        /// There are three possibilities:
        /// rocess vertices in hardware by setting <see cref="D3DCREATE_HARDWARE_VERTEXPROCESSING"/>.
        /// Process vertices in software by setting <see cref="D3DCREATE_SOFTWARE_VERTEXPROCESSING"/>.
        /// Process vertices in either hardware or software by setting <see cref="D3DCREATE_MIXED_VERTEXPROCESSING"/>.
        /// To switch a mixed-mode device between software and hardware processing, use <see cref="SetSoftwareVertexProcessing"/>.
        /// For an example using <see cref="D3DXCompileShader"/>, see HLSLwithoutEffects Sample.
        /// </remarks>
        public HRESULT CreateVertexShader([In] IntPtr pFunction, [Out] out P<IDirect3DVertexShader9> ppShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, out P<IDirect3DVertexShader9>, HRESULT>)_vTable[91])(thisPtr, pFunction, out ppShader);
            }
        }

        public HRESULT SetVertexShader([In] in IDirect3DVertexShader9 pShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DVertexShader9, HRESULT>)_vTable[92])(thisPtr, pShader);
            }
        }

        /// <summary>
        /// Retrieves the currently set vertex shader.
        /// </summary>
        /// <param name="ppShader">
        /// Pointer to a vertex shader interface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If <paramref name="ppShader"/> is invalid, <see cref="D3DERR_INVALIDCALL"/> is returned.
        /// </returns>
        /// <remarks>
        /// Typically, methods that return state will not work on a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// This method however, will work even on a pure device because it returns an interface.
        /// </remarks>
        public HRESULT GetVertexShader([Out] out P<IDirect3DVertexShader9> ppShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DVertexShader9>, HRESULT>)_vTable[93])(thisPtr, out ppShader);
            }
        }

        public HRESULT SetVertexShaderConstantF([In] UINT StartRegister, [In] float[] pConstantData, [In] UINT Vector4fCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], UINT, HRESULT>)_vTable[94])(thisPtr, StartRegister, pConstantData, Vector4fCount);
            }
        }

        /// <summary>
        /// Gets a floating-point vertex shader constant.
        /// </summary>
        /// <param name="StartRegister">
        /// Register number that will contain the first constant value.
        /// </param>
        /// <param name="pConstantData">
        /// Pointer to an array of constants.
        /// </param>
        /// <param name="Vector4fCount">
        /// Number of four float vectors in the array of constants.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetVertexShaderConstantF([In] UINT StartRegister, [Out] float[] pConstantData, [In] UINT Vector4fCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], UINT, HRESULT>)_vTable[95])(thisPtr, StartRegister, pConstantData, Vector4fCount);
            }
        }

        public HRESULT SetVertexShaderConstantI([In] UINT StartRegister, [In] int[] pConstantData, [In] UINT Vector4iCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, int[], UINT, HRESULT>)_vTable[96])(thisPtr, StartRegister, pConstantData, Vector4iCount);
            }
        }

        /// <summary>
        /// Gets an integer vertex shader constant.
        /// </summary>
        /// <param name="StartRegister">
        /// Register number that will contain the first constant value.
        /// </param>
        /// <param name="pConstantData">
        /// Pointer to an array of constants.
        /// </param>
        /// <param name="Vector4iCount">
        /// Number of four integer vectors in the array of constants.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetVertexShaderConstantI([In] UINT StartRegister, [Out] int[] pConstantData, [In] UINT Vector4iCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, int[], UINT, HRESULT>)_vTable[97])(thisPtr, StartRegister, pConstantData, Vector4iCount);
            }
        }

        public HRESULT SetVertexShaderConstantB([In] UINT StartRegister, [In] BOOL[] pConstantData, [In] UINT BoolCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, BOOL[], UINT, HRESULT>)_vTable[98])(thisPtr, StartRegister, pConstantData, BoolCount);
            }
        }

        /// <summary>
        /// Gets a Boolean vertex shader constant.
        /// </summary>
        /// <param name="StartRegister">
        /// Register number that will contain the first constant value.
        /// </param>
        /// <param name="pConstantData">
        /// Pointer to an array of constants.
        /// </param>
        /// <param name="BoolCount">
        /// Number of Boolean values in the array of constants.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetVertexShaderConstantB([In] UINT StartRegister, [Out] BOOL[] pConstantData, [In] UINT BoolCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, BOOL[], UINT, HRESULT>)_vTable[99])(thisPtr, StartRegister, pConstantData, BoolCount);
            }
        }

        public HRESULT SetStreamSource([In] UINT StreamNumber, [In] in IDirect3DVertexBuffer9 pStreamData, [In] UINT OffsetInBytes, [In] UINT Stride)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, in IDirect3DVertexBuffer9, UINT, UINT, HRESULT>)_vTable[100])
                    (thisPtr, StreamNumber, pStreamData, OffsetInBytes, Stride);
            }
        }

        /// <summary>
        /// Retrieves a vertex buffer bound to the specified data stream.
        /// </summary>
        /// <param name="StreamNumber">
        /// Specifies the data stream, in the range from 0 to the maximum number of streams minus one.
        /// </param>
        /// <param name="ppStreamData">
        /// Address of a pointer to an <see cref="IDirect3DVertexBuffer9"/> interface,
        /// representing the returned vertex buffer bound to the specified data stream.
        /// </param>
        /// <param name="pOffsetInBytes">
        /// 
        /// Pointer containing the offset from the beginning of the stream to the beginning of the vertex data.
        /// The offset is measured in bytes. See Remarks.</param>
        /// <param name="pStride">
        /// Pointer to a returned stride of the component, in bytes.
        /// See Remarks.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// A stream is defined as a uniform array of component data, where each component consists of one or more elements
        /// representing a single entity such as position, normal, color, and so on.
        /// When a FVF vertex shader is used, the stride of the vertex stream must match the vertex size, computed from the FVF.
        /// When a declaration is used, the stride should be greater than or equal to the stream size computed from the declaration.
        /// Calling this method increases the internal reference count on the <see cref="IDirect3DVertexBuffer9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/> when finished using this <see cref="IDirect3DVertexBuffer9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetStreamSource([In] UINT StreamNumber, [Out] out P<IDirect3DVertexBuffer9> ppStreamData, [Out] out UINT pOffsetInBytes, [Out] out UINT pStride)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDirect3DVertexBuffer9>, out UINT, out UINT, HRESULT>)_vTable[101])
                    (thisPtr, StreamNumber, out ppStreamData, out pOffsetInBytes, out pStride);
            }
        }

        public HRESULT SetStreamSourceFreq([In] UINT StreamNumber, [In] UINT Setting)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, HRESULT>)_vTable[102])(thisPtr, StreamNumber, Setting);
            }
        }

        /// <summary>
        /// Gets the stream source frequency divider value.
        /// </summary>
        /// <param name="StreamNumber">
        /// Stream source number.
        /// </param>
        /// <param name="pSetting">
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Vertex shaders can now be invoked more than once per vertex.
        /// See Drawing Non-Indexed Geometry.
        /// </remarks>
        public HRESULT GetStreamSourceFreq([In] UINT StreamNumber, [Out] out UINT pSetting)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out UINT, HRESULT>)_vTable[103])(thisPtr, StreamNumber, out pSetting);
            }
        }

        public HRESULT SetIndices([In] in IDirect3DIndexBuffer9 pIndexData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DIndexBuffer9, HRESULT>)_vTable[104])(thisPtr, pIndexData);
            }
        }

        /// <summary>
        /// Retrieves index data.
        /// </summary>
        /// <param name="ppIndexData">
        /// Address of a pointer to an <see cref="IDirect3DIndexBuffer9"/> interface, representing the returned index data.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Calling this method increases the internal reference count on the <see cref="IDirect3DIndexBuffer9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/> when finished using this <see cref="IDirect3DIndexBuffer9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetIndices([Out] out P<IDirect3DIndexBuffer9> ppIndexData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DIndexBuffer9>, HRESULT>)_vTable[105])(thisPtr, out ppIndexData);
            }
        }

        /// <summary>
        /// Creates a pixel shader.
        /// </summary>
        /// <param name="pFunction">
        /// Pointer to the pixel shader function token array, specifying the blending operations.
        /// This value cannot be <see cref="NULL"/>.
        /// </param>
        /// <param name="ppShader">
        /// Pointer to the returned pixel shader interface.
        /// See <see cref="IDirect3DPixelShader9"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        public HRESULT CreatePixelShader([In] IntPtr pFunction, [Out] out P<IDirect3DPixelShader9> ppShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, out P<IDirect3DPixelShader9>, HRESULT>)_vTable[106])(thisPtr, pFunction, out ppShader);
            }
        }

        public HRESULT SetPixelShader([In] in IDirect3DPixelShader9 pShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DPixelShader9, HRESULT>)_vTable[107])(thisPtr, pShader);
            }
        }

        /// <summary>
        /// Retrieves the currently set pixel shader.
        /// </summary>
        /// <param name="ppShader">
        /// Pointer to a pixel shader interface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method will not work on a device that is created using <see cref="D3DCREATE_PUREDEVICE"/>.
        /// </remarks>
        public HRESULT GetPixelShader([Out] out P<IDirect3DPixelShader9> ppShader)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DPixelShader9>, HRESULT>)_vTable[108])(thisPtr, out ppShader);
            }
        }

        public HRESULT SetPixelShaderConstantF([In] UINT StartRegister, [In] float[] pConstantData, [In] UINT Vector4fCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], UINT, HRESULT>)_vTable[109])(thisPtr, StartRegister, pConstantData, Vector4fCount);
            }
        }

        /// <summary>
        /// Gets a floating-point shader constant.
        /// </summary>
        /// <param name="StartRegister">
        /// Register number that will contain the first constant value.
        /// </param>
        /// <param name="pConstantData">
        /// Pointer to an array of constants.
        /// </param>
        /// <param name="Vector4fCount">
        /// Number of four float vectors in the array of constants.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetPixelShaderConstantF([In] UINT StartRegister, [Out] float[] pConstantData, [In] UINT Vector4fCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], UINT, HRESULT>)_vTable[110])(thisPtr, StartRegister, pConstantData, Vector4fCount);
            }
        }

        public HRESULT SetPixelShaderConstantI([In] UINT StartRegister, [In] int[] pConstantData, [In] UINT Vector4iCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, int[], UINT, HRESULT>)_vTable[111])(thisPtr, StartRegister, pConstantData, Vector4iCount);
            }
        }

        /// <summary>
        /// Gets an integer shader constant.
        /// </summary>
        /// <param name="StartRegister">
        /// Register number that will contain the first constant value.
        /// </param>
        /// <param name="pConstantData">
        /// Pointer to an array of constants.
        /// </param>
        /// <param name="Vector4iCount">
        /// Number of four integer vectors in the array of constants.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetPixelShaderConstantI([In] UINT StartRegister, [Out] int[] pConstantData, [In] UINT Vector4iCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, int[], UINT, HRESULT>)_vTable[112])(thisPtr, StartRegister, pConstantData, Vector4iCount);
            }
        }

        public HRESULT SetPixelShaderConstantB([In] UINT StartRegister, [In] BOOL[] pConstantData, [In] UINT BoolCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, BOOL[], UINT, HRESULT>)_vTable[113])(thisPtr, StartRegister, pConstantData, BoolCount);
            }
        }

        /// <summary>
        /// Gets a Boolean shader constant.
        /// </summary>
        /// <param name="StartRegister">
        /// Register number that will contain the first constant value.
        /// </param>
        /// <param name="pConstantData">
        /// Pointer to an array of constants.
        /// </param>
        /// <param name="BoolCount">
        /// Number of Boolean values in the array of constants.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetPixelShaderConstantB([In] UINT StartRegister, [Out] BOOL[] pConstantData, [In] UINT BoolCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, BOOL[], UINT, HRESULT>)_vTable[114])(thisPtr, StartRegister, pConstantData, BoolCount);
            }
        }

        /// <summary>
        /// Draws a rectangular patch using the currently set streams.
        /// </summary>
        /// <param name="Handle">
        /// Handle to the rectangular patch to draw.
        /// </param>
        /// <param name="pNumSegs">
        /// Pointer to an array of four floating-point values that identify the number of segments
        /// each edge of the rectangle patch should be divided into when tessellated.
        /// See <see cref="D3DRECTPATCH_INFO"/>.
        /// </param>
        /// <param name="pRectPatchInfo">
        /// Pointer to a <see cref="D3DRECTPATCH_INFO"/> structure, describing the rectangular patch to draw.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// For static patches:
        /// Set the vertex shader, set the appropriate streams,  supply patch information in the <paramref name="pRectPatchInfo"/> parameter,
        /// and specify a handle so that Direct3D can capture and cache information.
        /// Call <see cref="DrawRectPatch"/> subsequently with <paramref name="pRectPatchInfo"/>
        /// set to <see cref="NullRef{D3DRECTPATCH_INFO}"/> to efficiently draw the patch.
        /// When drawing a cached patch, the currently set streams are ignored.
        /// Override the cached <paramref name="pNumSegs"/> by specifying a new value for <paramref name="pNumSegs"/>.
        /// When rendering a cached patch, you must set the same vertex shader that was set when it was captured.
        /// Calling <see cref="DrawRectPatch"/> with a handle invalidates the same handle cached by a previous <see cref="DrawTriPatch"/> call.
        /// For dynamic patches, the patch data changes for every rendering of the patch, so it is not efficient to cache information.
        /// The application can convey this to Direct3D by setting <paramref name="Handle"/> to 0.
        /// In this case, Direct3D draws the patch using the currently set streams and the <paramref name="pNumSegs"/> values, and does not cache any information.
        /// It is not valid to simultaneously set <paramref name="Handle"/> to 0 and <paramref name="pRectPatchInfo"/> to <see cref="NullRef{D3DRECTPATCH_INFO}"/>.
        /// </remarks>
        public HRESULT DrawRectPatch([In] UINT Handle, [In] float[] pNumSegs, [In] in D3DRECTPATCH_INFO pRectPatchInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], in D3DRECTPATCH_INFO, HRESULT>)_vTable[115])(thisPtr, Handle, pNumSegs, pRectPatchInfo);
            }
        }

        /// <summary>
        /// Draws a triangular patch using the currently set streams.
        /// </summary>
        /// <param name="Handle">
        /// Handle to the triangular patch to draw.
        /// </param>
        /// <param name="pNumSegs">
        /// Pointer to an array of three floating-point values that identify the number of segments
        /// each edge of the triangle patch should be divided into when tessellated.
        /// See <see cref="D3DTRIPATCH_INFO"/>.
        /// </param>
        /// <param name="pTriPatchInfo">
        /// Pointer to a <see cref="D3DTRIPATCH_INFO"/> structure, describing the triangular high-order patch to draw.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// For static patches:
        /// Set the vertex shader, set the appropriate streams, supply patch information in the <paramref name="pTriPatchInfo"/> parameter,
        /// and specify a handle so that Direct3D can capture and cache information.
        /// To efficiently draw the patch, call <see cref="DrawTriPatch"/> with <paramref name="pTriPatchInfo"/> set to <see cref="NullRef{D3DTRIPATCH_INFO}"/>.
        /// When drawing a cached patch, the currently set streams are ignored.
        /// Override the cached <paramref name="pNumSegs"/> by specifying a new value for <paramref name="pNumSegs"/>.
        /// When rendering a cached patch, you must set the same vertex shader that was set when it was captured.
        /// Calling <see cref="DrawTriPatch"/> with a handle invalidates the same handle cached by a previous <see cref="DrawRectPatch"/> call.
        /// For dynamic patches, the patch data changes for every rendering of the patch so it is not efficient to cache information.
        /// The application can convey this to Direct3D by setting <paramref name="Handle"/> to 0.
        /// In this case, Direct3D draws the patch using the currently set streams and the <paramref name="pNumSegs"/> values, and does not cache any information.
        /// It is not valid to simultaneously set <paramref name="Handle"/> to 0 and <paramref name="pTriPatchInfo"/> to <see cref="NullRef{D3DTRIPATCH_INFO}"/>.
        /// </remarks>
        public HRESULT DrawTriPatch([In] UINT Handle, [In] float[] pNumSegs, [In] in D3DTRIPATCH_INFO pTriPatchInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, float[], in D3DTRIPATCH_INFO, HRESULT>)_vTable[116])(thisPtr, Handle, pNumSegs, pTriPatchInfo);
            }
        }

        /// <summary>
        /// Frees a cached high-order patch.
        /// </summary>
        /// <param name="Handle">
        /// Handle of the cached high-order patch to delete.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT DeletePatch([In] UINT Handle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[117])(thisPtr, Handle);
            }
        }

        /// <summary>
        /// Creates a status query.
        /// </summary>
        /// <param name="Type">
        /// Identifies the query type.
        /// For more information, see <see cref="D3DQUERYTYPE"/>.
        /// </param>
        /// <param name="ppQuery">
        /// Returns a pointer to the query interface that manages the query object.
        /// See <see cref="IDirect3DQuery9"/>.
        /// This parameter can be set to <see cref="NullRef{IDirect3DQuery9}"/> to see if a query is supported.
        /// If the query is not supported, the method returns <see cref="D3DERR_NOTAVAILABLE"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_NOTAVAILABLE"/> or <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// This method is provided for both synchronous and asynchronous queries.
        /// It takes the place of GetInfo, which is no longer supported in Direct3D 9.
        /// Synchronous and asynchronous queries are created with <see cref="CreateQuery"/> with <see cref="D3DQUERYTYPE"/>.
        /// When a query has been created and the API calls have been made that are being queried,
        /// use <see cref="IDirect3DQuery9.Issue"/> to issue a query and <see cref="IDirect3DQuery9.GetData"/> to get the results of the query.
        /// </remarks>
        public HRESULT CreateQuery([In] D3DQUERYTYPE Type, [Out] out P<IDirect3DQuery9> ppQuery)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DQUERYTYPE, out P<IDirect3DQuery9>, HRESULT>)_vTable[118])(thisPtr, Type, out ppQuery);
            }
        }
    }
}
