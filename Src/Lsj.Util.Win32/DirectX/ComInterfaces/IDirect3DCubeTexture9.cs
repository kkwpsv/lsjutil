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
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DCubeTexture9"/> interface to manipulate a cube texture resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dcubetexture9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="IDirect3DCubeTexture9"/> interface can be obtained
    /// by calling the <see cref="IDirect3DDevice9.CreateCubeTexture"/> method or one of the D3DXCreateCubeTexturexxx functions.
    /// </para>
    /// <para>
    /// This interface inherits additional functionality from the <see cref="IDirect3DBaseTexture9"/> interface.
    /// </para>
    /// <para>
    /// This interface, like all COM interfaces, inherits additional functionality from the <see cref="IUnknown"/> interface.
    /// </para>
    /// <para>
    /// The LPDIRECT3DCUBETEXTURE9 and PDIRECT3DCubeTexture9 types are defined as pointers to the <see cref="IDirect3DCubeTexture9"/> interface.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "FFF32F81-D953-473a-9223-93D652ABA93F", BeginVTableSlotIndex = 17, EndVTableSlotIndex = 21,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDirect3DResource9), typeof(IDirect3DBaseTexture9)])]
    public unsafe struct IDirect3DCubeTexture9
    {
        nint* _vTable;

        /// <summary>
        /// Retrieves a description of one face of the specified cube texture level.
        /// </summary>
        /// <param name="Level">
        /// Specifies a level of a mipmapped cube texture.
        /// </param>
        /// <param name="pDesc">
        /// Pointer to a <see cref="D3DSURFACE_DESC"/> structure, describing one face of the specified cube texture level.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="D3DSURFACE_DESC"/> structure contains <see cref="D3DSURFACE_DESC.Width"/>
        /// and <see cref="D3DSURFACE_DESC.Height"/> members, which describe the size of one face in the cube.
        /// To get the size of the entire cube, multiply six (the number of cube faces)
        /// by the product of <see cref="D3DSURFACE_DESC.Width"/> and <see cref="D3DSURFACE_DESC.Height"/>.
        /// </remarks>
        public HRESULT GetLevelDesc([In] UINT Level, [Out] out D3DSURFACE_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DSURFACE_DESC, HRESULT>)_vTable[17])(thisPtr, Level, out pDesc);
            }
        }

        /// <summary>
        /// Retrieves a cube texture map surface.
        /// </summary>
        /// <param name="FaceType">
        /// Member of the <see cref="D3DCUBEMAP_FACES"/> enumerated type, identifying a cube map face.
        /// </param>
        /// <param name="Level">
        /// Specifies a level of a mipmapped cube texture.
        /// </param>
        /// <param name="ppCubeMapSurface">
        /// Address of a pointer to an <see cref="IDirect3DSurface9"/> interface,
        /// representing the returned cube texture map surface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DSurface9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/>
        /// when finished using this <see cref="IDirect3DSurface9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetCubeMapSurface([In] D3DCUBEMAP_FACES FaceType, [In] UINT Level, [Out] out P<IDirect3DSurface9> ppCubeMapSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DCUBEMAP_FACES, UINT, out P<IDirect3DSurface9>, HRESULT>)_vTable[18])
                    (thisPtr, FaceType, Level, out ppCubeMapSurface);
            }
        }

        /// <summary>
        /// Locks a rectangle on a cube texture resource.
        /// </summary>
        /// <param name="FaceType">
        /// Member of the <see cref="D3DCUBEMAP_FACES"/> enumerated type, identifying a cube map face.
        /// </param>
        /// <param name="Level">
        /// Specifies a level of a mipmapped cube texture.
        /// </param>
        /// <param name="pLockedRect">
        /// Pointer to a <see cref="D3DLOCKED_RECT"/> structure, describing the region to lock.
        /// </param>
        /// <param name="pRect">
        /// Pointer to a rectangle to lock.
        /// Specified by a pointer to a <see cref="RECT"/> structure.
        /// Specifying <see cref="NullRef{RECT}"/> for this parameter expands the dirty region to cover the entire cube texture.
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
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if one or more of the arguments is invalid.
        /// </returns>
        /// <remarks>
        /// <para>
        /// For performance reasons, dirty regions are only recorded for level zero of a texture.
        /// Dirty regions are automatically recorded when <see cref="LockRect"/> is called
        /// without <see cref="D3DLOCK_NO_DIRTY_UPDATE"/> or <see cref="D3DLOCK_READONLY"/>.
        /// See <see cref="IDirect3DDevice9.UpdateTexture"/> for more information.
        /// </para>
        /// <para>
        /// Cube textures created with <see cref="D3DPOOL_DEFAULT"/> are not lockable.
        /// Cube textures created in video memory are lockable when created with <see cref="D3DUSAGE_DYNAMIC"/>.
        /// </para>
        /// <para>
        /// The only lockable format for a depth-stencil texture is <see cref="D3DFMT_D16_LOCKABLE"/>.
        /// </para>
        /// </remarks>
        public HRESULT LockRect([In] D3DCUBEMAP_FACES FaceType, [In] UINT Level, [Out] out D3DLOCKED_RECT pLockedRect, [In] in RECT pRect, [In] D3DLOCK Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DCUBEMAP_FACES, UINT, out D3DLOCKED_RECT, in RECT, D3DLOCK, HRESULT>)_vTable[19])
                    (thisPtr, FaceType, Level, out pLockedRect, pRect, Flags);
            }
        }

        /// <summary>
        /// Unlocks a rectangle on a cube texture resource.
        /// </summary>
        /// <param name="FaceType">
        /// Member of the <see cref="D3DCUBEMAP_FACES"/> enumerated type, identifying a cube map face.
        /// </param>
        /// <param name="Level">
        /// Specifies a level of a mipmapped cube texture.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT UnlockRect([In] D3DCUBEMAP_FACES FaceType, [In] UINT Level)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DCUBEMAP_FACES, UINT, HRESULT>)_vTable[20])(thisPtr, FaceType, Level);
            }
        }

        /// <summary>
        /// Adds a dirty region to a cube texture resource.
        /// </summary>
        /// <param name="FaceType">
        /// Member of the <see cref="D3DCUBEMAP_FACES"/> enumerated type, identifying the cube map face.
        /// </param>
        /// <param name="pDirtyRect">
        /// Pointer to a <see cref="RECT"/> structure, specifying the dirty region.
        /// Specifying <see cref="NullRef{RECT}"/> expands the dirty region to cover the entire cube texture.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be: <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// For performance reasons, dirty regions are only recorded for level zero of a texture.
        /// For sublevels, it is assumed that the corresponding (scaled) rectangle or box is also dirty.
        /// Dirty regions are automatically recorded when <see cref="LockRect"/> is called
        /// without <see cref="D3DLOCK_NO_DIRTY_UPDATE"/> or <see cref="D3DLOCK_READONLY"/>.
        /// The destination surface of <see cref="IDirect3DDevice9.UpdateSurface"/> is also marked dirty automatically.
        /// </para>
        /// <para>
        /// Using <see cref="D3DLOCK_NO_DIRTY_UPDATE"/> and explicitly specifying dirty regions
        /// can be used to increase the efficiency of <see cref="IDirect3DDevice9.UpdateTexture"/>.
        /// Using this method, applications can optimize
        /// what subset of a resource is copied by specifying dirty regions on the resource.
        /// However, the dirty regions may be expanded to optimize alignment.
        /// </para>
        /// </remarks>
        public HRESULT AddDirtyRect([In] D3DCUBEMAP_FACES FaceType, [In] in RECT pDirtyRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DCUBEMAP_FACES, in RECT, HRESULT>)_vTable[21])(thisPtr, FaceType, pDirtyRect);
            }
        }
    }
}
