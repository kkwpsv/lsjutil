using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DLOCK;
using static Lsj.Util.Win32.DirectX.Enums.D3DPOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENTFLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DSurface9"/> interface to query and prepare surfaces.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/nn-d3d9-idirect3dsurface9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The LPDIRECT3DSURFACE9 and PDIRECT3DSURFACE9 types are defined as pointers to the <see cref="IDirect3DSurface9"/> interface.
    /// </para>
    /// <code>
    /// typedef struct IDirect3DSurface9 *LPDIRECT3DSURFACE9, *PDIRECT3DSURFACE9;
    /// </code>
    /// </remarks>
    [ComInterface(IID = "0CFBAF3A-9FF6-429a-99B3-A2796AF8B89B", BeginVTableSlotIndex = 11, EndVTableSlotIndex = 16,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDirect3DResource9)])]
    public unsafe struct IDirect3DSurface9
    {
        nint* _vTable;

        /// <summary>
        /// Provides access to the parent cube texture or texture (mipmap) object,
        /// if this surface is a child level of a cube texture or a mipmap.
        /// This method can also provide access to the parent swap chain if the surface is a back-buffer child.
        /// </summary>
        /// <param name="riid">
        /// Reference identifier of the container being requested.
        /// </param>
        /// <param name="ppContainer">
        /// Address of a pointer to fill with the container pointer if the query succeeds.
        /// See Remarks.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the surface is created using <see cref="IDirect3DDevice9.CreateRenderTarget"/>
        /// or <see cref="IDirect3DDevice9.CreateOffscreenPlainSurface"/>
        /// or <see cref="IDirect3DDevice9.CreateDepthStencilSurface"/>, the surface is considered stand alone.
        /// In this case, <see cref="GetContainer"/> will return the Direct3D device used to create the surface.
        /// </para>
        /// <para>
        /// If the call succeeds, the reference count of the container is increased by one.
        /// </para>
        /// <para>
        /// Here's an example getting the parent texture of a mip surface.
        /// </para>
        /// <code>
        /// // Assumes pSurface is a valid IDirect3DSurface9 pointer
        /// void *pContainer = NULL;
        /// IDirect3DTexture9 *pTexture = NULL;
        /// HRESULT hr = pSurface-&gt;GetContainer(IID_IDirect3DTexture9, &amp;pContainer);
        /// if (SUCCEEDED(hr) &amp;&amp; pContainer)
        /// {
        ///     pTexture = (IDirect3DTexture9 *)pContainer;
        /// }
        /// </code>
        /// </remarks>
        public HRESULT GetContainer([In] in IID riid, [Out] out nint ppContainer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out nint, HRESULT>)_vTable[11])(thisPtr, riid, out ppContainer);
            }
        }

        /// <summary>
        /// Retrieves a description of the surface.
        /// </summary>
        /// <param name="pDesc">
        /// Pointer to a <see cref="D3DSURFACE_DESC"/> structure, describing the surface.
        /// </param>
        /// <returns>
        /// <para>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// </para>
        /// <para>
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if the argument is invalid.
        /// </para>
        /// </returns>
        public HRESULT GetDesc([Out] out D3DSURFACE_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DSURFACE_DESC, HRESULT>)_vTable[12])(thisPtr, out pDesc);
            }
        }

        /// <summary>
        /// Locks a rectangle on a surface.
        /// </summary>
        /// <param name="pLockedRect">
        /// Pointer to a <see cref="D3DLOCKED_RECT"/> structure that describes the locked region.
        /// </param>
        /// <param name="pRect">
        /// Pointer to a rectangle to lock.
        /// Specified by a pointer to a <see cref="RECT"/> structure.
        /// Specifying <see cref="NullRef{RECT}"/> for this parameter
        /// expands the dirty region to cover the entire surface.
        /// </param>
        /// <param name="Flags">
        /// <para>
        /// Combination of zero or more locking flags that describe the type of lock to perform.
        /// For this method, the valid flags are:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3DLOCK_DISCARD"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3DLOCK_DONOTWAIT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3DLOCK_NO_DIRTY_UPDATE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3DLOCK_NOSYSLOCK"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3DLOCK_READONLY"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// You may not specify a subrect when using <see cref="D3DLOCK_DISCARD"/>.
        /// For a description of the flags, see <see cref="D3DLOCK"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// </para>
        /// <para>
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/> or <see cref="D3DERR_WASSTILLDRAWING"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <see cref="D3DLOCK_DONOTWAIT"/> flag is specified and the driver cannot lock the surface immediately,
        /// <see cref="LockRect"/> will return <see cref="D3DERR_WASSTILLDRAWING"/>
        /// so that an application can use the CPU cycles while waiting for the driver to lock the surface.
        /// </para>
        /// <para>
        /// The only lockable format for a depth-stencil surface is <see cref="D3DFMT_D16_LOCKABLE"/>.
        /// See <see cref="D3DFORMAT"/>.
        /// </para>
        /// <para>
        /// For performance reasons, dirty regions are recorded only for level zero of a texture.
        /// Dirty regions are automatically recorded
        /// when <see cref="LockRect"/> is called without <see cref="D3DLOCK_NO_DIRTY_UPDATE"/> or <see cref="D3DLOCK_READONLY"/>.
        /// See <see cref="IDirect3DDevice9.UpdateTexture"/> for more information.
        /// </para>
        /// <para>
        /// A multisample back buffer cannot be locked.
        /// </para>
        /// <para>
        /// This method cannot retrieve data from a surface
        /// that is contained by a texture resource created with <see cref="D3DUSAGE_RENDERTARGET"/>
        /// because such a texture must be assigned to <see cref="D3DPOOL_DEFAULT"/> memory and is therefore not lockable.
        /// In this case, use instead <see cref="IDirect3DDevice9.GetRenderTargetData"/>
        /// to copy texture data from device memory to system memory.
        /// </para>
        /// </remarks>
        public HRESULT LockRect([Out] out D3DLOCKED_RECT pLockedRect, [In] in RECT pRect, [In] D3DLOCK Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DLOCKED_RECT, in RECT, D3DLOCK, HRESULT>)_vTable[13])
                    (thisPtr, out pLockedRect, pRect, Flags);
            }
        }

        /// <summary>
        /// Unlocks a rectangle on a surface.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT UnlockRect()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[14])(thisPtr);
            }
        }

        /// <summary>
        /// Retrieves a device context.
        /// </summary>
        /// <param name="phdc">
        /// Pointer to the device context for the surface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if the argument is invalid.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The following restrictions apply.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GetDC"/> is valid on the following formats only:
        /// <see cref="D3DFMT_R5G6B5"/>, <see cref="D3DFMT_X1R5G5B5"/>,
        /// <see cref="D3DFMT_R8G8B8"/>, and <see cref="D3DFMT_X8R8G8B8"/>.
        /// Formats that contain Alpha are not supported
        /// because the GDI implementations don't have a well-defined behavior on the alpha channel.
        /// For more information about formats, see <see cref="D3DFORMAT"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Only one device context per surface can be returned at a time.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GetDC"/> will fail if the surface is already locked.
        /// If the surface is a member of a mipmap or cubemap,
        /// <see cref="GetDC"/> fails if any other mipmap or cubemap member is locked.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GetDC"/> fails on render targets unless they were created lockable
        /// (or, in the case of back buffers, with the <see cref="D3DPRESENTFLAG_LOCKABLE_BACKBUFFER"/> flag).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// For surfaces not created with <see cref="IDirect3DDevice9.CreateOffscreenPlainSurface"/>,
        /// <see cref="GetDC"/> will fail on default pool (<see cref="D3DPOOL_DEFAULT"/>) surfaces
        /// unless they are dynamic (<see cref="D3DUSAGE_DYNAMIC"/>) or are lockable render targets.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GetDC"/> will fail on <see cref="D3DPOOL_SCRATCH"/> surfaces.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When a device context is outstanding on a surface, the application may not call these methods:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="IDirect3DCubeTexture9"/>
        /// </term>
        /// <term>
        /// <see cref="IDirect3DCubeTexture9.LockRect"/>
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="IDirect3DDevice9"/>
        /// </term>
        /// <term>
        /// <see cref="IDirect3DDevice9.ColorFill"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// </term>
        /// <term>
        /// <see cref="IDirect3DDevice9.StretchRect"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// </term>
        /// <term>
        /// <see cref="IDirect3DDevice9.UpdateSurface"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// </term>
        /// <term>
        /// <see cref="IDirect3DDevice9.UpdateTexture"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IDirect3DSurface9"/>
        /// </term>
        /// <term>
        /// <see cref="LockRect"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IDirect3DSwapChain9"/>
        /// </term>
        /// <term>
        /// <see cref="IDirect3DSwapChain9.Present"/> *
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// IDirect3DTexture9
        /// </term>
        /// <term>
        /// <see cref="IDirect3DTexture9.LockRect"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// (on a swap chain that contains the surface)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="GetDC"/> causes an implicit lock; do not retain the device context for later use.
        /// Call <see cref="ReleaseDC"/> to release it.
        /// </para>
        /// <para>
        /// It is valid to call <see cref="GetDC"/>/<see cref="ReleaseDC"/> on levels of a mipmap or cubemap,
        /// however, these calls will be slow to all miplevels except the topmost level,
        /// and GDI operations to these miplevels will not be accelerated.
        /// </para>
        /// <para>
        /// The hdc provides access to Win32 and GDI functionality.
        /// </para>
        /// </remarks>
        public HRESULT GetDC([Out] out HDC phdc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out HDC, HRESULT>)_vTable[15])(thisPtr, out phdc);
            }
        }

        /// <summary>
        /// Release a device context handle.
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if the argument is invalid.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An <paramref name="hdc"/> is a Windows resource.
        /// It must be released after use so Windows can return it to the pool of available resources.
        /// </para>
        /// <para>
        /// This method will release only the device context returned by <see cref="GetDC"/>.
        /// Otherwise, this method will fail.
        /// </para>
        /// </remarks>
        public HRESULT ReleaseDC([In] HDC hdc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HDC, HRESULT>)_vTable[16])(thisPtr, hdc);
            }
        }
    }
}
