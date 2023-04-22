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
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DTexture9"/> interface to manipulate a texture resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dtexture9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="IDirect3DTexture9"/> interface can be obtained by calling the <see cref="IDirect3DDevice9.CreateTexture"/> method
    /// or one of the D3DXCreateTexturexxx functions.
    /// This interface inherits additional functionality from the <see cref="IDirect3DBaseTexture9"/> interface.
    /// This interface, like all COM interfaces, inherits from the <see cref="IUnknown"/> interface.
    /// The LPDIRECT3DTEXTURE9 and PDIRECT3DTEXTURE9 types are defined as pointers to the <see cref="IDirect3DTexture9"/> interface.
    /// <code>
    /// typedef struct IDirect3DTexture9 *LPDIRECT3DTEXTURE9, *PDIRECT3DTEXTURE9;
    /// </code>
    /// </remarks>
    public unsafe struct IDirect3DTexture9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves a level description of a texture resource.
        /// </summary>
        /// <param name="Level">
        /// Identifies a level of the texture resource.
        /// This method returns a surface description for the level specified by this parameter.
        /// </param>
        /// <param name="pDesc">
        /// Pointer to a <see cref="D3DSURFACE_DESC"/> structure, describing the returned level.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if one of the arguments is invalid.
        /// </returns>
        public HRESULT GetLevelDesc([In] UINT Level, [Out] out D3DSURFACE_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DSURFACE_DESC, HRESULT>)_vTable[17])(thisPtr, Level, out pDesc);
            }
        }

        /// <summary>
        /// Retrieves the specified texture surface level.
        /// </summary>
        /// <param name="Level">
        /// Identifies a level of the texture resource.
        /// This method returns a surface for the level specified by this parameter.
        /// The top-level surface is denoted by 0.
        /// </param>
        /// <param name="ppSurfaceLevel">
        /// Address of a pointer to an <see cref="IDirect3DSurface9"/> interface, representing the returned surface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DSurface9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/> when finished using this <see cref="IDirect3DSurface9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetSurfaceLevel([In] UINT Level, [Out] out P<IDirect3DSurface9> ppSurfaceLevel)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDirect3DSurface9>, HRESULT>)_vTable[18])(thisPtr, Level, out ppSurfaceLevel);
            }
        }

        /// <summary>
        /// Locks a rectangle on a texture resource.
        /// </summary>
        /// <param name="Level">
        /// Specifies the level of the texture resource to lock.
        /// </param>
        /// <param name="pLockedRect">
        /// Pointer to a <see cref="D3DLOCKED_RECT"/> structure, describing the locked region.
        /// </param>
        /// <param name="pRect">
        /// Pointer to a rectangle to lock.
        /// Specified by a pointer to a <see cref="RECT"/> structure.
        /// Specifying <see cref="NullRef{RECT}"/> for this parameter expands the dirty region to cover the entire texture.
        /// </param>
        /// <param name="Flags">
        /// Combination of zero or more locking flags that describe the type of lock to perform.
        /// For this method, the valid flags are:
        /// <see cref="D3DLOCK_DISCARD"/>, <see cref="D3DLOCK_NO_DIRTY_UPDATE"/>,
        /// <see cref="D3DLOCK_NOSYSLOCK"/>, <see cref="D3DLOCK_READONLY"/>
        /// You may not specify a subrect when using <see cref="D3DLOCK_DISCARD"/>.
        /// For a description of the flags, see <see cref="D3DLOCK"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Textures created with <see cref="D3DPOOL_DEFAULT"/> are not lockable.
        /// Textures created in video memory are lockable when created with <see cref="D3DUSAGE_DYNAMIC"/>.
        /// For performance reasons, dirty regions are recorded only for level zero of a texture.
        /// Dirty regions are automatically recorded when <see cref="LockRect"/> is called without <see cref="D3DLOCK_NO_DIRTY_UPDATE"/> or <see cref="D3DLOCK_READONLY"/>.
        /// See <see cref="IDirect3DDevice9.UpdateTexture"/> for more information.
        /// The only lockable format for a depth-stencil texture is <see cref="D3DFMT_D16_LOCKABLE"/>.
        /// Video memory textures cannot be locked, but must be modified by calling <see cref="IDirect3DDevice9.UpdateSurface"/> or <see cref="IDirect3DDevice9.UpdateTexture"/>.
        /// There are exceptions for some proprietary driver pixel formats that Direct3D 9 does not recognize. These can be locked.
        /// This method cannot retrieve data from a texture resource created with <see cref="D3DUSAGE_RENDERTARGET"/>
        /// because such a texture must be assigned to <see cref="D3DPOOL_DEFAULT"/> memory and is therefore not lockable.
        /// In this case, use instead <see cref="IDirect3DDevice9.GetRenderTargetData"/> to copy texture data from device memory to system memory.
        /// </remarks>
        public HRESULT LockRect([In] UINT Level, [Out] out D3DLOCKED_RECT pLockedRect, [In] in RECT pRect, [In] D3DLOCK Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DLOCKED_RECT, in RECT, D3DLOCK, HRESULT>)_vTable[19])(thisPtr, Level, out pLockedRect, pRect, Flags);
            }
        }

        /// <summary>
        /// Unlocks a rectangle on a texture resource.
        /// </summary>
        /// <param name="Level">
        /// Specifies the level of the texture resource to unlock.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT UnlockRect([In] UINT Level)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[20])(thisPtr, Level);
            }
        }

        /// <summary>
        /// Adds a dirty region to a texture resource.
        /// </summary>
        /// <param name="pDirtyRect">
        /// Pointer to a <see cref="RECT"/> structure, specifying the dirty region to add.
        /// Specifying <see cref="NullRef{RECT}"/> expands the dirty region to cover the entire texture.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// For performance reasons, dirty regions are only recorded for level zero of a texture.
        /// For sublevels, it is assumed that the corresponding (scaled) rectangle or box is also dirty.
        /// Dirty regions are automatically recorded when <see cref="LockRect"/> is called
        /// without <see cref="D3DLOCK_NO_DIRTY_UPDATE"/> or <see cref="D3DLOCK_READONLY"/>.
        /// The destination surface of <see cref="IDirect3DDevice9.UpdateSurface"/> is also marked dirty automatically.
        /// Using <see cref="D3DLOCK_NO_DIRTY_UPDATE"/> and explicitly specifying dirty regions
        /// can be used to increase the efficiency of <see cref="IDirect3DDevice9.UpdateTexture"/>.
        /// Using this method, applications can optimize what subset of a resource is copied by specifying dirty regions on the resource.
        /// However, the dirty regions may be expanded to optimize alignment.
        /// </remarks>
        public HRESULT AddDirtyRect([In] in RECT pDirtyRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in RECT, HRESULT>)_vTable[21])(thisPtr, pDirtyRect);
            }
        }
    }
}
