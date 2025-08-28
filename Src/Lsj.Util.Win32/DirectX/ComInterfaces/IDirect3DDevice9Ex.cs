using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DCAPS3;
using static Lsj.Util.Win32.DirectX.Enums.D3DCREATE;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DPOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENT;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENTFLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3DPTADDRESSCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DSTATEBLOCKTYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DSWAPEFFECT;
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DDevice9Ex"/> interface to render primitives,
    /// create resources, work with system-level variables, adjust gamma ramp levels, work with palettes, and create shaders.
    /// The <see cref="IDirect3DDevice9Ex"/> interface derives from the <see cref="IDirect3DDevice9"/> interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/nn-d3d9-idirect3ddevice9ex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <summary>
    /// <para>
    /// The <see cref="IDirect3DDevice9Ex"/> interface is obtained by calling <see cref="IDirect3D9Ex.CreateDeviceEx"/>.
    /// </para>
    /// <para>
    /// The LPDIRECT3DDEVICE9EX and PDIRECT3DDEVICE9EX types are defined as pointers to the <see cref="IDirect3DDevice9Ex"/> interface:
    /// </para>
    /// <code>
    /// typedef struct IDirect3DDevice9Ex *LPDIRECT3DDEVICE9EX, *PDIRECT3DDEVICE9EX;
    /// </code>
    /// <para>
    /// Creating a Device
    /// </para>
    /// <para>
    /// Follow these two steps to initialize a Direct3D device:
    /// </para>
    /// <para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Call <see cref="Direct3DCreate9Ex"/> to create the Direct3D object.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="CreateDeviceEx"/> to create the Direct3D device.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Here is an example:
    /// </para>
    /// <code>
    /// IDirect3D9Ex *pDirect3DEx;
    /// LPDIRECT3DDEVICE9EX pDeviceEx;
    /// DWORD behaviorFlags = D3DCREATE_HARDWARE_VERTEXPROCESSING;
    /// 
    /// Direct3DCreate9Ex(D3D_SDK_VERSION, &amp;pDirect3DEx);
    /// pDirect3DEx-&gt;CreateDeviceEx(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, hWnd, behaviorFlags, &amp;d3dpp, NULL, &amp;pDeviceEx);
    /// </code>
    /// </summary>
    /// </remarks>
    [ComInterface(IID = "B18B10CE-2649-405a-870F-95F777D4313A", BeginVTableSlotIndex = 119, EndVTableSlotIndex = 133,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDirect3DDevice9)])]
    public unsafe struct IDirect3DDevice9Ex
    {
        IntPtr* _vTable;

        /// <summary>
        /// Prepare the texture sampler for monochrome convolution filtering on a single-color texture.
        /// </summary>
        /// <param name="width">
        /// The width of the filter kernel; ranging from 1 - <see cref="D3DCONVOLUTIONMONO_MAXWIDTH"/>.
        /// The default value is 1.
        /// </param>
        /// <param name="height">
        /// The height of the filter kernel; ranging from 1 - <see cref="D3DCONVOLUTIONMONO_MAXHEIGHT"/>.
        /// The default value is 1.
        /// </param>
        /// <param name="rows">
        /// An array of weights, one weight for each kernel sub-element in the width.
        /// This parameter must be <see langword="null"/>, which will set the weights equal to the default value.
        /// </param>
        /// <param name="columns">
        /// An array of weights, one weight for each kernel sub-element in the height.
        /// This parameter must be <see langword="null"/>, which will set the weights equal to the default value.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method is designed to filter a single color texture.
        /// A monochrome convolution filter is a 2D box filter with all of the weights set to 1.0;
        /// the filter kernel resolution ranges from 1 x 1 to 7 x 7.
        /// When monochrome texture filtering is set to a texture sampler and texture sampling is performed at location,
        /// then Direct3D performs convolution.
        /// </para>
        /// <para>
        /// Restrictions include:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The filter specified by this method is recorded in state blocks as a part of <see cref="D3DSBT_PIXELSTATE"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The only texture address mode supported is: <see cref="D3DPTADDRESSCAPS_BORDER"/>; the border color is always 0.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// This method is not supported for mipmaps.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Using a non-monochrome texture with convolution filtering will generate a driver error.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT SetConvolutionMonoKernel([In] UINT width, [In] UINT height, [In] float[] rows, [In] float[] columns)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, float[], float[], HRESULT>)_vTable[119])(thisPtr, width, height, rows, columns);
            }
        }

        /// <summary>
        /// Copy a text string to one surface using an alphabet of glyphs on another surface.
        /// Composition is done by the GPU using bitwise operations.
        /// </summary>
        /// <param name="pSrc">
        /// A pointer to a source surface (prepared by IDirect3DSurface9) that supplies the alphabet glyphs.
        /// This surface must be created with the <see cref="D3DUSAGE_TEXTAPI"/> flag.
        /// </param>
        /// <param name="pDst">
        /// A pointer to the destination surface (prepared by <see cref="IDirect3DSurface9"/>) that receives the glyph data.
        /// The surface must be part of a texture.
        /// </param>
        /// <param name="pSrcRectDescs">
        /// A pointer to a vertex buffer (see <see cref="IDirect3DVertexBuffer9"/>)
        /// containing rectangles (see <see cref="D3DCOMPOSERECTDESC"/>)
        /// that enclose the desired glyphs in the source surface.
        /// </param>
        /// <param name="NumRects">
        /// The number of rectangles or glyphs that are used in the operation.
        /// The number applies to both the source and destination surfaces.
        /// The range is 0 to <see cref="D3DCOMPOSERECTS_MAXNUMRECTS"/>.
        /// </param>
        /// <param name="pDstRectDescs">
        /// A pointer to a vertex buffer (see <see cref="IDirect3DVertexBuffer9"/>)
        /// containing rectangles (see <see cref="D3DCOMPOSERECTDESTINATION"/>)
        /// that describe the destination to which the indicated glyph from the source surface will be copied.
        /// </param>
        /// <param name="Operation">
        /// Specifies how to combine the source and destination surfaces.
        /// See <see cref="D3DCOMPOSERECTSOP"/>.
        /// </param>
        /// <param name="Xoffset">
        /// A value added to the x coordinates of all destination rectangles.
        /// This value can be negative, which may cause the glyph to be rejected or clipped
        /// if the result is beyond the bounds of the surface.
        /// </param>
        /// <param name="Yoffset">
        /// A value added to the y coordinates of all destination rectangles.
        /// This value can be negative, which may cause the glyph to be rejected or clipped
        /// if the result is beyond the bounds of the surface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Glyphs from a one-bit source surface are put together into another one-bit texture surface with this method.
        /// The destination surface can then be used as the source for a normal texturing operation
        /// that will filter and scale the strings of text onto some other non-monochrome surface.
        /// </para>
        /// <para>
        /// This method has several constraints (which are similar to <see cref="IDirect3DDevice9.StretchRect"/>):
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Surfaces cannot be locked.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The source and destination surfaces cannot be the same surface.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The source and destination surfaces must be created with the <see cref="D3DFMT_A1"/> format.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The source surface and both vertex buffers must be created with the <see cref="D3DPOOL_DEFAULT"/> flag.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The destination surface must be created with either the <see cref="D3DPOOL_DEFAULT"/> or <see cref="D3DPOOL_SYSTEMMEM"/> flags.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The source rectangles must be within the source surface.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The method is not recorded in state blocks.
        /// </para>
        /// </remarks>
        public HRESULT ComposeRects([In] in IDirect3DSurface9 pSrc, [In] in IDirect3DSurface9 pDst, [In] in IDirect3DVertexBuffer9 pSrcRectDescs,
            [In] UINT NumRects, [In] in IDirect3DVertexBuffer9 pDstRectDescs, [In] D3DCOMPOSERECTSOP Operation, [In] int Xoffset, [In] int Yoffset)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, in IDirect3DSurface9, in IDirect3DVertexBuffer9,
                    UINT, in IDirect3DVertexBuffer9, D3DCOMPOSERECTSOP, int, int, HRESULT>)_vTable[120])
                    (thisPtr, pSrc, pDst, pSrcRectDescs, NumRects, pDstRectDescs, Operation, Xoffset, Yoffset);
            }
        }

        /// <summary>
        /// Swap the swapchain's next buffer with the front buffer.
        /// </summary>
        /// <param name="pSourceRect">
        /// Pointer to a <see cref="RECT"/> structure indicating region on the source surface to copy in window client coordinates.
        /// Only applies when the swapchain was created with the <see cref="D3DSWAPEFFECT_COPY"/> flag.
        /// If <see cref="NullRef{RECT}"/>, the entire source surface is presented.
        /// If the rectangle exceeds the source surface, it is clipped to the source surface.
        /// </param>
        /// <param name="pDestRect">
        /// Pointer to <see cref="RECT"/> structure indicating the target region on the destination surface in window client coordinates.
        /// Only applies when the swapchain was created with the <see cref="D3DSWAPEFFECT_COPY"/> flag.
        /// If <see cref="NullRef{RECT}"/>, the entire client area is filled.
        /// If the rectangle exceeds the destination client area, it is clipped to the destination client area.
        /// </param>
        /// <param name="hDestWindowOverride">
        /// <para>
        /// Pointer to a destination window whose client area is taken as the target for this presentation.
        /// If this value is <see cref="NULL"/>, the runtime uses
        /// the <see cref="D3DPRESENT_PARAMETERS.hDeviceWindow"/> member of <see cref="D3DPRESENT_PARAMETERS"/> for the presentation.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If you create a swap chain with <see cref="D3DSWAPEFFECT_FLIPEX"/>,
        /// you must pass <see cref="NULL"/> to <paramref name="hDestWindowOverride"/>
        /// </para>
        /// </param>
        /// <param name="pDirtyRegion">
        /// <para>
        /// Pointer to a <see cref="RGNDATA"/> structure indicating the smallest set of pixels that need to be transferred.
        /// This value must be <see cref="NullRef{RGNDATA}"/>
        /// unless the swapchain was created with the <see cref="D3DSWAPEFFECT_COPY"/> flag.
        /// For more information about swapchains, see Flipping Surfaces (Direct3D 9).
        /// </para>
        /// <para>
        /// If this value is non-<see cref="NULL"/>, the contained region is expressed in back buffer coordinates.
        /// The method takes these rectangles into account
        /// when optimizing the presentation by copying only the pixels within the region,
        /// or some suitably expanded set of rectangles.
        /// This is an aid to optimization only, and the application should not rely on the region being copied exactly.
        /// The implementation can choose to copy the whole source rectangle.
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Allows the application to request that the method return immediately
        /// when the driver reports that it cannot schedule a presentation.
        /// Valid values are 0, or any combination of <see cref="D3DPRESENT"/> flags.
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
        /// If <paramref name="dwFlags"/> = <see cref="D3DPRESENT_DONOTFLIP"/> the display driver is called
        /// with the front buffer as both the source and target surface.
        /// The driver responds by scheduling a frame synch, but not changing the displayed surface.
        /// This flag is only available in full-screen mode or when using <see cref="D3DSWAPEFFECT_FLIPEX"/> in windowed mode.
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
        /// If <paramref name="dwFlags"/> = <see cref="D3DPRESENT_FORCEIMMEDIATE"/>,
        /// <see cref="D3DPRESENT_INTERVAL_IMMEDIATE"/> is enforced on this Present call.
        /// This flag can only be specified when using <see cref="D3DSWAPEFFECT_FLIPEX"/>.
        /// This behavior is the same for windowed and full-screen modes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <paramref name="dwFlags"/> = <see cref="D3DPRESENT_LINEAR_CONTENT"/>,
        /// gamma correction is performed from linear space to sRGB for windowed swap chains.
        /// This flag will take effect only
        /// when the driver exposes <see cref="D3DCAPS3_LINEAR_TO_SRGB_PRESENTATION"/> (see Gamma (Direct3D 9)).
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// Possible return values include: <see cref="S_OK"/>, <see cref="D3DERR_DEVICELOST"/>, <see cref="D3DERR_DEVICEHUNG"/>,
        /// <see cref="D3DERR_DEVICEREMOVED"/>, or <see cref="D3DERR_OUTOFVIDEOMEMORY"/> (see D3DERR).
        /// See Lost Device Behavior Changes for more information about lost, hung, and removed devices.
        /// </para>
        /// <para>
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// </para>
        /// <para>
        /// <see cref="D3DSWAPEFFECT_FLIPEX"/> is only available in Direct3D9Ex running on Windows 7 (or more current operating system).
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Similar to the <see cref="IDirect3DDevice9.Present"/> Method,
        /// <see cref="PresentEx"/> adds a <paramref name="dwFlags"/> parameter.
        /// </para>
        /// <para>
        /// When the swapchain is created with <see cref="D3DSWAPEFFECT_FLIPEX"/> flag, <paramref name="pSourceRect"/>,
        /// <paramref name="pDestRect"/> and <paramref name="pDirtyRegion"/> values must be set to <see cref="NullRef{T}"/>.
        /// </para>
        /// </remarks>
        public HRESULT PresentEx([In] in RECT pSourceRect, [In] in RECT pDestRect, [In] HWND hDestWindowOverride,
            [In] in RGNDATA pDirtyRegion, [In] D3DPRESENT dwFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in RECT, in RECT, HWND, in RGNDATA, D3DPRESENT, HRESULT>)_vTable[121])
                    (thisPtr, pSourceRect, pDestRect, hDestWindowOverride, pDirtyRegion, dwFlags);
            }
        }

        /// <summary>
        /// Get the priority of the GPU thread.
        /// </summary>
        /// <param name="pPriority">
        /// Current GPU priority.
        /// Valid values range from -7 to 7.
        /// </param>
        /// <returns>
        /// Possible return values include: <see cref="D3D_OK"/> or <see cref="D3DERR_DEVICEREMOVED"/>
        /// (see <see cref="D3DERR"/>).
        /// </returns>
        /// <remarks>
        /// <para>
        /// Use <see cref="SetGPUThreadPriority"/> to set the priority of a thread.
        /// </para>
        /// <para>
        /// This method will retrieve the priority of the thread stored with the Direct3D device
        /// even if it was created with the <see cref="D3DCREATE_PUREDEVICE"/> flag.
        /// </para>
        /// </remarks>
        public HRESULT GetGPUThreadPriority([Out] out INT pPriority)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out INT, HRESULT>)_vTable[122])(thisPtr, out pPriority);
            }
        }

        /// <summary>
        /// Set the priority on the GPU thread.
        /// </summary>
        /// <param name="Priority">
        /// The thread priority, ranging from -7 to 7.
        /// </param>
        /// <returns>
        /// Possible return values include:
        /// <see cref="D3D_OK"/>, <see cref="D3DERR_INVALIDCALL"/>, or <see cref="D3DERR_DEVICEREMOVED"/>
        /// (see <see cref="D3DERR"/>).
        /// </returns>
        /// <remarks>
        /// GPU thread priority is not reset when a device is lost.
        /// The effects of calls to this method are not recorded in state blocks.
        /// </remarks>
        public HRESULT SetGPUThreadPriority([In] INT Priority)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, INT, HRESULT>)_vTable[123])(thisPtr, Priority);
            }
        }

        /// <summary>
        /// Suspend execution of the calling thread until the next vertical blank signal.
        /// </summary>
        /// <param name="iSwapChain">
        /// Swap chain index.
        /// This is an optional, zero-based index used to specify a swap chain on a multihead card.
        /// </param>
        /// <returns>
        /// This method will always return <see cref="D3D_OK"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method allows applications to efficiently throttle their frame rate
        /// to that of the monitor associated with the device.
        /// Following a vertical blank, the amount of time it takes for the thread to wake up is typically very short.
        /// </para>
        /// <para>
        /// In some scenarios the hardware may stop generating vertical blank signals
        /// when nothing is being displayed on the monitor.
        /// In this case, the method will wait approximately 100ms and return with <see cref="D3D_OK"/>.
        /// </para>
        /// </remarks>
        public HRESULT WaitForVBlank([In] UINT iSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[124])(thisPtr, iSwapChain);
            }
        }

        /// <summary>
        /// Checks an array of resources to determine if it is likely that they will cause a large stall at Draw time
        /// because the system must make the resources GPU-accessible.
        /// </summary>
        /// <param name="pResourceArray">
        /// An array of <see cref="IDirect3DResource9"/> pointers that indicate the resources to check.
        /// </param>
        /// <param name="NumResources">
        /// A value indicating the number of resources passed
        /// into the <paramref name="pResourceArray"/> parameter up to a maximum of 65535.
        /// </param>
        /// <returns>
        /// <para>
        /// If all the resources are in GPU-accessible memory, the method will return <see cref="S_OK"/>.
        /// The system may need to perform a remapping operation to promote the resources, but will not have to copy data.
        /// </para>
        /// <para>
        /// If no allocation that comprises the resources is on disk,
        /// but at least one allocation is not in GPU-accessible memory,
        /// the method will return <see cref="S_RESIDENT_IN_SHARED_MEMORY"/>.
        /// The system may need to perform a copy to promote the resource.
        /// </para>
        /// <para>
        /// If at least one allocation that comprises the resources is on disk,
        /// this method will return <see cref="S_NOT_RESIDENT"/>.
        /// The system may need to perform a copy to promote the resource.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This API is no more than a reasonable guess at residency,
        /// since resources may have been demoted by the time the application uses them.
        /// </para>
        /// <para>
        /// The expected usage pattern is as follows.
        /// If the application determines that a set of resources are not resident,
        /// then the application will substitute a lower-LOD version of the resource and continue with rendering.
        /// The video memory manager API, offers a feature to allow the application to express
        /// that it would like these lower-LOD resources to be made more likely to stay resident in GPU-accessible memory.
        /// It is the app's responsibility to create, fill and destroy these lower-LOD versions, if it so chooses.
        /// </para>
        /// <para>
        /// The application also needs to begin promotion of the higher-LOD versions
        /// when the residency check indicates that the resource is not resident in GPU-accessible memory.
        /// Since a per-process lock exists in kernel mode,
        /// a performant implementation will spawn a separate process whose sole job is to promote resources.
        /// The application communicates resource identity between the two process
        /// by means of the Sharing Resources shared surfaces API
        /// and promotes them by means of the <see cref="IDirect3DResource9.SetPriority"/>.
        /// </para>
        /// </remarks>
        public HRESULT CheckResourceResidency([In] P<IDirect3DResource9>[] pResourceArray, [In] UINT32 NumResources)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IDirect3DResource9>[], UINT32, HRESULT>)_vTable[125])(thisPtr, pResourceArray, NumResources);
            }
        }

        /// <summary>
        /// Set the number of frames that the system is allowed to queue for rendering.
        /// </summary>
        /// <param name="MaxLatency">
        /// The maximum number of back buffer frames that a driver can queue.
        /// The value is typically 3, but can range from 1 to 20.
        /// A value of 0 will reset latency to the default.
        /// For multi-head devices, <paramref name="MaxLatency"/> is specified per-head.
        /// </param>
        /// <returns>
        /// Possible return values include:
        /// <see cref="D3D_OK"/> or <see cref="D3DERR_DEVICEREMOVED"/> (see <see cref="D3DERR"/>).
        /// </returns>
        /// <remarks>
        /// <para>
        /// Frame latency is the number of frames that are allowed to be stored in a queue,
        /// before submission for rendering.
        /// Latency is often used to control how the CPU chooses
        /// between responding to user input and frames that are in the render queue.
        /// </para>
        /// <para>
        /// It is often beneficial for applications that have no user input (for example, video playback)
        /// to queue more than 3 frames of data.
        /// </para>
        /// </remarks>
        public HRESULT SetMaximumFrameLatency([In] UINT MaxLatency)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[126])(thisPtr, MaxLatency);
            }
        }

        /// <summary>
        /// Retrieves the number of frames of data that the system is allowed to queue.
        /// </summary>
        /// <param name="pMaxLatency">
        /// Returns the number of frames that can be queued for render.
        /// The value is typically 3, but can range from 1 to 20.
        /// </param>
        /// <returns>
        /// Possible return values include:
        /// <see cref="D3D_OK"/>, <see cref="D3DERR_DEVICELOST"/>, <see cref="D3DERR_DEVICEREMOVED"/>,
        /// <see cref="D3DERR_DRIVERINTERNALERROR"/>, <see cref="D3DERR_INVALIDCALL"/>,
        /// or <see cref="D3DERR_OUTOFVIDEOMEMORY"/> (see <see cref="D3DERR"/>).
        /// </returns>
        /// <remarks>
        /// <para>
        /// Frame latency is the number of frames that are allowed to be stored in a queue,
        /// before submission for rendering.
        /// Latency is often used to control how the CPU chooses
        /// between responding to user input and frames that are in the render queue.
        /// </para>
        /// <para>
        /// It is often beneficial for applications that have no user input (for example, video playback)
        /// to queue more than 3 frames of data.
        /// </para>
        /// </remarks>
        public HRESULT GetMaximumFrameLatency([Out] out UINT pMaxLatency)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[127])(thisPtr, out pMaxLatency);
            }
        }

        /// <summary>
        /// Reports the current cooperative-level status of the Direct3D device for a windowed or full-screen application.
        /// </summary>
        /// <param name="hDestinationWindow">
        /// The destination window handle to check for occlusion.
        /// When this parameter is <see cref="NULL"/>,
        /// <see cref="S_PRESENT_OCCLUDED"/> is returned when another device has fullscreen ownership.
        /// When the window handle is not <see cref="NULL"/>, window's client area is checked for occlusion.
        /// A window is occluded if any part of it is obscured by another application.
        /// </param>
        /// <returns>
        /// Possible return values include: <see cref="D3D_OK"/>, <see cref="D3DERR_DEVICELOST"/>, <see cref="D3DERR_DEVICEHUNG"/>,
        /// <see cref="D3DERR_DEVICEREMOVED"/>, or <see cref="D3DERR_OUTOFVIDEOMEMORY"/> (see <see cref="D3DERR"/>),
        /// or <see cref="S_PRESENT_MODE_CHANGED"/>, or <see cref="S_PRESENT_OCCLUDED"/> (see <see cref="S_PRESENT"/>).
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method replaces <see cref="IDirect3DDevice9.TestCooperativeLevel"/>,
        /// which always returns <see cref="S_OK"/> in Direct3D 9Ex applications.
        /// </para>
        /// <para>
        /// We recommend not to call <see cref="CheckDeviceState"/> every frame.
        /// Instead, call <see cref="CheckDeviceState"/> only if the <see cref="PresentEx"/> method returns a failure code.
        /// </para>
        /// <para>
        /// See Lost Device Behavior Changes for more information about lost, hung, and removed devices.
        /// </para>
        /// </remarks>
        public HRESULT CheckDeviceState([In] HWND hDestinationWindow)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, HRESULT>)_vTable[128])(thisPtr, hDestinationWindow);
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
        /// When this surface is passed to <see cref="IDirect3DDevice9.SetRenderTarget"/>,
        /// its multisample type must be the same as that of the depth-stencil
        /// set by <see cref="IDirect3DDevice9.SetDepthStencilSurface"/>.
        /// </param>
        /// <param name="MultisampleQuality">
        /// Quality level.
        /// The valid range is between zero and one less than the level
        /// returned by pQualityLevels used by <see cref="IDirect3D9.CheckDeviceMultiSampleType"/>.
        /// Passing a larger value returns the error, <see cref="D3DERR_INVALIDCALL"/>.
        /// The <paramref name="MultisampleQuality"/> values of paired render targets,
        /// depth stencil surfaces, and the multisample type must all match.
        /// </param>
        /// <param name="Lockable">
        /// <para>
        /// Render targets are not lockable unless the application specifies <see cref="TRUE"/> for <paramref name="Lockable"/>.
        /// </para>
        /// <para>
        /// Note that lockable render targets reduce performance on some graphics hardware.
        /// The readback performance (moving data from video memory to system memory)
        /// depends on the type of hardware used (AGP vs. PCI Express)
        /// and is usually far lower than upload performance (moving data from system to video memory).
        /// If you need read access to render targets,
        /// use <see cref="IDirect3DDevice9.GetRenderTargetData"/> instead of lockable render targets.
        /// </para>
        /// </param>
        /// <param name="ppSurface">
        /// Address of a pointer to an <see cref="IDirect3DSurface9"/> interface.
        /// </param>
        /// <param name="pSharedHandle">
        /// Reserved.
        /// Set this parameter to <see cref="NullRef{HANDLE}"/>.
        /// This parameter can be used in Direct3D 9 for Windows Vista to share resources.
        /// </param>
        /// <param name="Usage">
        /// Combination of one or more <see cref="D3DUSAGE"/> constants which can be OR'd together.
        /// Value of 0 indicates no usage.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_NOTAVAILABLE"/>, <see cref="D3DERR_INVALIDCALL"/>,
        /// <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Render-target surfaces are placed in the <see cref="D3DPOOL_DEFAULT"/> memory class.
        /// </para>
        /// <para>
        /// The creation of lockable, multisampled render targets is not supported.
        /// </para>
        /// </remarks>
        public HRESULT CreateRenderTargetEx([In] UINT Width, [In] UINT Height, [In] D3DFORMAT Format,
            [In] D3DMULTISAMPLE_TYPE MultiSample, [In] DWORD MultisampleQuality, [In] BOOL Lockable,
            [Out] out P<IDirect3DSurface9> ppSurface, [In][Out] ref HANDLE pSharedHandle, [In] D3DUSAGE Usage)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DFORMAT, D3DMULTISAMPLE_TYPE,
                    DWORD, BOOL, out P<IDirect3DSurface9>, ref HANDLE, D3DUSAGE, HRESULT>)_vTable[129])
                    (thisPtr, Width, Height, Format, MultiSample, MultisampleQuality, Lockable, out ppSurface, ref pSharedHandle, Usage);
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
        /// <param name="Usage">
        /// Combination of one or more <see cref="D3DUSAGE"/> constants which can be OR'd together.
        /// Value of 0 indicates no usage.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be the following: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="D3DPOOL_SCRATCH"/> will return a surface
        /// that has identical characteristics to a surface created by the DirectX 8.x method <see cref="CreateImageSurface"/>.
        /// </para>
        /// <para>
        /// <see cref="D3DPOOL_DEFAULT"/> is the appropriate pool
        /// for use with the <see cref="IDirect3DDevice9.StretchRect"/> and <see cref="IDirect3DDevice9.ColorFill"/>.
        /// </para>
        /// <para>
        /// <see cref="D3DPOOL_MANAGED"/> is not allowed when creating an offscreen plain surface.
        /// For more information about memory pools, see <see cref="D3DPOOL"/>.
        /// </para>
        /// <para>
        /// Off-screen plain surfaces are always lockable, regardless of their pool types.
        /// </para>
        /// </remarks>
        public HRESULT CreateOffscreenPlainSurfaceEx([In] UINT Width, [In] UINT Height, [In] D3DFORMAT Format, [In] D3DPOOL Pool,
            [Out] out P<IDirect3DSurface9> ppSurface, [In][Out] ref HANDLE pSharedHandle, [In] D3DUSAGE Usage)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DFORMAT, D3DPOOL,
                    out P<IDirect3DSurface9>, ref HANDLE, D3DUSAGE, HRESULT>)_vTable[130])
                    (thisPtr, Width, Height, Format, Pool, out ppSurface, ref pSharedHandle, Usage);
            }
        }

        /// <summary>
        /// Creates a depth-stencil surface.
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
        /// Member of the <see cref="D3DMULTISAMPLE_TYPE"/> enumerated type, which describes the multisampling buffer type.
        /// This value must be one of the allowed multisample types.
        /// When this surface is passed to <see cref="IDirect3DDevice9.SetDepthStencilSurface"/>,
        /// its multisample type must be the same as that of the render target set by <see cref="IDirect3DDevice9.SetRenderTarget"/>.
        /// </param>
        /// <param name="MultisampleQuality">
        /// Quality level.
        /// The valid range is between zero and one less than the level
        /// returned by pQualityLevels used by <see cref="IDirect3D9.CheckDeviceMultiSampleType"/>.
        /// Passing a larger value returns the error, <see cref="D3DERR_INVALIDCALL"/>.
        /// The <paramref name="MultisampleQuality"/> values of paired render targets,
        /// depth stencil surfaces, and the <paramref name="MultiSample"/> type must all match.
        /// </param>
        /// <param name="Discard">
        /// <para>
        /// Set this flag to <see cref="TRUE"/> to enable z-buffer discarding, and <see cref="FALSE"/> otherwise.
        /// If this flag is set, the contents of the depth stencil buffer will be invalid
        /// after calling either <see cref="IDirect3DDevice9.Present"/>
        /// or <see cref="IDirect3DDevice9.SetDepthStencilSurface"/> with a different depth surface.
        /// </para>
        /// <para>
        /// This flag has the same behavior as the constant,
        /// <see cref="D3DPRESENTFLAG_DISCARD_DEPTHSTENCIL"/>, in <see cref="D3DPRESENTFLAG"/>.
        /// </para>
        /// </param>
        /// <param name="ppSurface">
        /// Address of a pointer to an <see cref="IDirect3DSurface9"/> interface,
        /// representing the created depth-stencil surface resource.
        /// </param>
        /// <param name="pSharedHandle">
        /// Reserved.
        /// Set this parameter to <see cref="NullRef{HANDLE}"/>.
        /// This parameter can be used in Direct3D 9 for Windows Vista to share resources.
        /// </param>
        /// <param name="Usage">
        /// Combination of one or more <see cref="D3DUSAGE"/> constants which can be OR'd together.
        /// Value of 0 indicates no usage.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_NOTAVAILABLE"/>, <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// The memory class of the depth-stencil buffer is always <see cref="D3DPOOL_DEFAULT"/>.
        /// </remarks>
        public HRESULT CreateDepthStencilSurfaceEx([In] UINT Width, [In] UINT Height, [In] D3DFORMAT Format,
            [In] D3DMULTISAMPLE_TYPE MultiSample, [In] DWORD MultisampleQuality, [In] BOOL Discard,
            [Out] out P<IDirect3DSurface9> ppSurface, [In][Out] ref HANDLE pSharedHandle, [In] D3DUSAGE Usage)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, D3DFORMAT, D3DMULTISAMPLE_TYPE,
                    DWORD, BOOL, out P<IDirect3DSurface9>, ref HANDLE, D3DUSAGE, HRESULT>)_vTable[131])
                    (thisPtr, Width, Height, Format, MultiSample, MultisampleQuality, Discard, out ppSurface, ref pSharedHandle, Usage);
            }
        }

        /// <summary>
        /// Resets the type, size, and format of the swap chain with all other surfaces persistent.
        /// </summary>
        /// <param name="pPresentationParameters">
        /// <para>
        /// Pointer to a <see cref="D3DPRESENT_PARAMETERS"/> structure, describing the new presentation parameters.
        /// This value cannot be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// When switching to full-screen mode,
        /// Direct3D will try to find a desktop format that matches the back buffer format,
        /// so that back buffer and front buffer formats will be identical
        /// (to eliminate the need for color conversion).
        /// </para>
        /// <para>
        /// When this method returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3DPRESENT_PARAMETERS.BackBufferCount"/>, <see cref="D3DPRESENT_PARAMETERS.BackBufferWidth"/>,
        /// and <see cref="D3DPRESENT_PARAMETERS.BackBufferHeight"/> are set to zero.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3DPRESENT_PARAMETERS.BackBufferFormat"/> is set to <see cref="D3DFORMAT"/> for windowed mode only;
        /// a full-screen mode must specify a format.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pFullscreenDisplayMode">
        /// Pointer to a <see cref="D3DDISPLAYMODEEX"/> structure that describes the properties of the desired display mode.
        /// This value must be provided for fullscreen applications,
        /// but can be <see cref="NullRef{D3DDISPLAYMODEEX}"/> for windowed applications.
        /// </param>
        /// <returns>
        /// The method can return:
        /// <see cref="D3D_OK"/>, <see cref="D3DERR_DEVICELOST"/> or <see cref="D3DERR_DEVICEHUNG"/> (see <see cref="D3DERR"/>).
        /// If this method returns <see cref="D3DERR_DEVICELOST"/> or <see cref="D3DERR_DEVICEHUNG"/>
        /// then the application can only call <see cref="ResetEx"/>,
        /// <see cref="CheckDeviceState"/> or release the interface pointer;
        /// any other API call will cause an exception.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If a call to <see cref="ResetEx"/> fails, the device will be placed in the lost state
        /// (as indicated by a return value of <see cref="D3DERR_DEVICELOST"/> from a call to <see cref="CheckDeviceState"/>).
        /// Refer to <see cref="CheckDeviceState"/> and Lost Device Behavior Changes for further information
        /// concerning the use of <see cref="ResetEx"/> in the context of lost devices.
        /// </para>
        /// <para>
        /// Unlike previous versions of DirectX,
        /// calling <see cref="ResetEx"/> does not cause surfaces, textures or state information to be lost.
        /// </para>
        /// <para>
        /// Pixel shaders and vertex shaders survive <see cref="ResetEx"/> calls for Direct3D 9.
        /// They do not need to be re-created explicitly by the application.
        /// </para>
        /// <para>
        /// There are two different types of swap chains: full-screen or windowed.
        /// If the new swap chain is full-screen, the adapter will be placed in the display mode that matches the new size.
        /// </para>
        /// <para>
        /// Applications can expect messages to be sent to them during this call (for example, before this call is returned);
        /// applications should take precautions not to call into Direct3D at this time.
        /// </para>
        /// <para>
        /// A call to <see cref="ResetEx"/> will fail
        /// if called on a different thread than that used to create the device being reset.
        /// </para>
        /// <para>
        /// <see cref="D3DFMT_UNKNOWN"/> can be specified for the windowed mode back buffer format
        /// when calling <see cref="IDirect3D9Ex.CreateDeviceEx"/>, <see cref="ResetEx"/>,
        /// and <see cref="IDirect3DDevice9.CreateAdditionalSwapChain"/>.
        /// This means the application does not have to query the current desktop format
        /// before calling <see cref="IDirect3D9Ex.CreateDeviceEx"/> for windowed mode.
        /// For full-screen mode, the back buffer format must be specified.
        /// Setting <see cref="D3DPRESENT_PARAMETERS.BackBufferCount"/> equal to zero
        /// (<see cref="D3DPRESENT_PARAMETERS.BackBufferCount"/> = 0) results in one back buffer.
        /// </para>
        /// <para>
        /// When trying to reset more than one display adapter in a group,
        /// set <paramref name="pPresentationParameters"/> to point to an array of <see cref="D3DPRESENT_PARAMETERS"/> structures,
        /// one for each display in the adapter group.
        /// </para>
        /// <para>
        /// If a multihead device was created with <see cref="D3DCREATE_ADAPTERGROUP_DEVICE"/>,
        /// <see cref="ResetEx"/> requires an array of <see cref="D3DPRESENT_PARAMETERS"/> structures
        /// wherein each structure must specify a full-screen display.
        /// To switch back to windowed mode,
        /// the application must destroy the device and re-create a non-multihead device in windowed mode.
        /// </para>
        /// </remarks>
        public HRESULT ResetEx([In][Out] ref D3DPRESENT_PARAMETERS pPresentationParameters, [In][Out] ref D3DDISPLAYMODEEX pFullscreenDisplayMode)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ref D3DPRESENT_PARAMETERS, ref D3DDISPLAYMODEEX, HRESULT>)_vTable[132])
                    (thisPtr, ref pPresentationParameters, ref pFullscreenDisplayMode);
            }
        }

        /// <summary>
        /// Retrieves the display mode's spatial resolution, color resolution, refresh frequency, and rotation settings.
        /// </summary>
        /// <param name="iSwapChain">
        /// An unsigned integer specifying the swap chain.
        /// </param>
        /// <param name="pMode">
        /// Pointer to a <see cref="D3DDISPLAYMODEEX"/> structure containing data about the display mode of the adapter.
        /// As opposed to the display mode of the device, which may not be active if the device does not own full-screen mode.
        /// Can be set to <see cref="NullRef{D3DDISPLAYMODEEX}"/>.
        /// </param>
        /// <param name="pRotation">
        /// Pointer to a <see cref="D3DDISPLAYROTATION"/> indicating the type of screen rotation the application will do.
        /// The value returned through this pointer is important when the <see cref="D3DPRESENTFLAG_NOAUTOROTATE"/> flag is used;
        /// otherwise, it can be set to <see cref="NullRef{D3DDISPLAYROTATION}"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetDisplayModeEx([In] UINT iSwapChain, [Out] out D3DDISPLAYMODEEX pMode, [Out] out D3DDISPLAYROTATION pRotation)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DDISPLAYMODEEX, out D3DDISPLAYROTATION, HRESULT>)_vTable[133])(thisPtr, iSwapChain, out pMode, out pRotation);
            }
        }
    }
}
