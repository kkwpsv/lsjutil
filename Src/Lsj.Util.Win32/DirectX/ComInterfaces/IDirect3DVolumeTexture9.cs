using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DLOCK;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DVolumeTexture9"/> interface to manipulate a volume texture resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dvolumetexture9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="IDirect3DVolumeTexture9"/> interface can be obtained
    /// by calling the <see cref="CreateVolumeTexture"/> method or one of the D3DXCreateVolumeTexturexxx functions.
    /// This interface inherits additional functionality from the <see cref="IDirect3DBaseTexture9"/> interface.
    /// This interface, like all COM interfaces, inherits from the <see cref="IUnknown"/> interface.
    /// The LPDIRECT3DVOLUMETEXTURE9 and PDIRECT3DVOLUMETEXTURE9 types are defined as pointers to the <see cref="IDirect3DVolumeTexture9"/> interface.
    /// <code>
    /// typedef struct IDirect3DVolumeTexture9 *LPDIRECT3DVOLUMETEXTURE9, *PDIRECT3DVOLUMETEXTURE9;
    /// </code>
    /// </remarks>
    public unsafe struct IDirect3DVolumeTexture9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves a level description of a volume texture resource.
        /// </summary>
        /// <param name="Level">
        /// Identifies a level of the volume texture resource.
        /// This method returns a volume description for the level specified by this parameter.
        /// </param>
        /// <param name="pDesc">
        /// Pointer to a <see cref="D3DVOLUME_DESC"/> structure, describing the returned volume texture level.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if one or more of the arguments are invalid.
        /// </returns>
        public HRESULT GetLevelDesc([In] UINT Level, [Out] out D3DSURFACE_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DSURFACE_DESC, HRESULT>)_vTable[17])(thisPtr, Level, out pDesc);
            }
        }

        /// <summary>
        /// Retrieves the specified volume texture level.
        /// </summary>
        /// <param name="Level">
        /// Identifies a level of the volume texture resource.
        /// This method returns a volume for the level specified by this parameter.
        /// </param>
        /// <param name="ppVolumeLevel">
        /// Address of a pointer to an <see cref="IDirect3DVolume9"/> interface, representing the returned volume level.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DVolume9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/> when finished using this <see cref="IDirect3DVolume9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetVolumeLevel([In] UINT Level, [Out] out P<IDirect3DVolume9> ppVolumeLevel)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDirect3DVolume9>, HRESULT>)_vTable[18])(thisPtr, Level, out ppVolumeLevel);
            }
        }

        /// <summary>
        /// Locks a box on a volume texture resource.
        /// </summary>
        /// <param name="Level">
        /// Specifies the level of the volume texture resource to lock.
        /// </param>
        /// <param name="pLockedVolume">
        /// Pointer to a <see cref="D3DLOCKED_BOX"/> structure, describing the locked region.
        /// </param>
        /// <param name="pBox">
        /// Pointer to the volume to lock.
        /// This parameter is specified by a pointer to a <see cref="D3DBOX"/> structure.
        /// Specifying <see cref="NullRef{D3DBOX}"/> for this parameter locks the entire volume level.
        /// </param>
        /// <param name="Flags">
        /// Combination of zero or more locking flags that describe the type of lock to perform. For this method, the valid flags are:
        /// <see cref="D3DLOCK_DISCARD"/>, <see cref="D3DLOCK_NO_DIRTY_UPDATE"/>,
        /// <see cref="D3DLOCK_NOSYSLOCK"/>, <see cref="D3DLOCK_NOSYSLOCK"/>
        /// For a description of the flags, see <see cref="D3DLOCK"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// For performance reasons, dirty regions are only recorded for level zero of a texture.
        /// Dirty regions are automatically recorded when <see cref="LockBox"/> is called without <see cref="D3DLOCK_NO_DIRTY_UPDATE"/> or <see cref="D3DLOCK_READONLY"/>.
        /// For more information, see <see cref="IDirect3DDevice9.UpdateTexture"/>.
        /// </remarks>
        public HRESULT LockBox([In] UINT Level, [Out] out D3DLOCKED_BOX pLockedVolume, [In] in D3DBOX pBox, [In] DWORD Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out D3DLOCKED_BOX, in D3DBOX, DWORD, HRESULT>)_vTable[19])(thisPtr, Level, out pLockedVolume, pBox, Flags);
            }
        }

        /// <summary>
        /// Unlocks a box on a volume texture resource.
        /// </summary>
        /// <param name="Level">
        /// Specifies the level of the volume texture resource to unlock.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT UnlockBox([In] UINT Level)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[20])(thisPtr, Level);
            }
        }

        /// <summary>
        /// Adds a dirty region to a volume texture resource.
        /// </summary>
        /// <param name="pDirtyBox">
        /// Pointer to a <see cref="D3DBOX"/> structure, specifying the dirty region to add.
        /// Specifying <see cref="NullRef{D3DBOX}"/> expands the dirty region to cover the entire volume texture.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// For performance reasons, dirty regions are only recorded for level zero of a texture.
        /// For sublevels, it is assumed that the corresponding (scaled) box is also dirty.
        /// Dirty regions are automatically recorded when <see cref="LockBox"/> is called
        /// without <see cref="D3DLOCK_NO_DIRTY_UPDATE"/> or <see cref="D3DLOCK_READONLY"/>.
        /// Using <see cref="D3DLOCK_NO_DIRTY_UPDATE"/> and explicitly specifying dirty regions
        /// can be used to increase the efficiency of <see cref="IDirect3DDevice9.UpdateTexture"/>.
        /// Using this method, applications can optimize what subset of a resource is copied by specifying dirty boxes on the resource.
        /// However, the dirty regions may be expanded to optimize alignment.
        /// </remarks>
        public HRESULT AddDirtyBox([In] in D3DBOX pDirtyBox)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3DBOX, HRESULT>)_vTable[21])(thisPtr, pDirtyBox);
            }
        }
    }
}
