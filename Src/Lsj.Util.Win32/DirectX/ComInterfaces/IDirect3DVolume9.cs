using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.D3DLOCK;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DVolume9"/> interface to manipulate volume resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dvolume9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="IDirect3DVolume9"/> interface is obtained by calling the <see cref="IDirect3DVolumeTexture9.GetVolumeLevel"/> method.
    /// This interface, like all COM interfaces, inherits from the <see cref="IUnknown"/> interface.
    /// The LPDIRECT3DVOLUME9 and PDIRECT3DVOLUME9 types are defined as pointers to the <see cref="IDirect3DVolume9"/> interface.
    /// <code>
    /// typedef struct IDirect3DVolume9 *LPDIRECT3DVOLUME9, *PDIRECT3DVOLUME9;
    /// </code>
    /// </remarks>
    public unsafe struct IDirect3DVolume9
    {
        IntPtr* _vTable;


        /// <summary>
        /// Retrieves the device associated with a volume.
        /// </summary>
        /// <param name="ppDevice">
        /// Address of a pointer to an <see cref="IDirect3DDevice9"/> interface to fill with the device pointer, if the query succeeds.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// This method allows navigation to the owning device object.
        /// Calling this method will increase the internal reference count on the <see cref="IDirect3DDevice9"/> interface.
        /// Failure to call <see cref="IUnknown.Release"/> when finished using this <see cref="IDirect3DDevice9"/> interface results in a memory leak.
        /// </remarks>
        public HRESULT GetDevice([Out] out P<IDirect3DDevice9> ppDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DDevice9>, HRESULT>)_vTable[3])(thisPtr, out ppDevice);
            }
        }

        /// <summary>
        /// Associates data with the volume that is intended for use by the application, not by Direct3D.
        /// </summary>
        /// <param name="refguid">
        /// Reference to the globally unique identifier that identifies the private data to set.
        /// </param>
        /// <param name="pData">
        /// Pointer to a buffer that contains the data to associate with the volume.
        /// </param>
        /// <param name="SizeOfData">
        /// Size of the buffer at <paramref name="pData"/> in bytes.
        /// </param>
        /// <param name="Flags">
        /// Value that describes the type of data being passed, or indicates to the application that the data should be invalidated when the resource changes.
        /// 0:
        /// If no flags are specified, Direct3D allocates memory to hold the data within the buffer and copies the data into the new buffer.
        /// The buffer allocated by Direct3D is automatically freed, as appropriate.
        /// <see cref="D3DSPD_IUNKNOWN"/>:
        /// The data at <paramref name="pData"/> is a pointer to an <see cref="IUnknown"/> interface.
        /// <paramref name="SizeOfData"/> must be set to the size of a pointer to an <see cref="IUnknown"/> interface, sizeof(IUnknown*).
        /// Direct3D automatically calls <see cref="IUnknown.Release"/> through <paramref name="pData"/> and <see cref="IUnknown.Release"/> when the private data is destroyed.
        /// Private data will be destroyed by a subsequent call to <see cref="SetPrivateData"/> with the same GUID,
        /// a subsequent call to <see cref="FreePrivateData"/>, or when the <see cref="IDirect3D9"/> object is released.
        /// For more information, see Remarks.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following: <see cref="D3DERR_INVALIDCALL"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        public HRESULT SetPrivateData([In] in GUID refguid, [In] IntPtr pData, [In] DWORD SizeOfData, [In] DWORD Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, IntPtr, DWORD, DWORD, HRESULT>)_vTable[4])(thisPtr, refguid, pData, SizeOfData, Flags);
            }
        }

        /// <summary>
        /// Copies the private data associated with the volume to a provided buffer.
        /// </summary>
        /// <param name="refguid">
        /// Reference to (C++) or address of (C) the globally unique identifier that identifies the private data to retrieve.
        /// </param>
        /// <param name="pData">
        /// Pointer to a previously allocated buffer to fill with the requested private data if the call succeeds.
        /// The application calling this method is responsible for allocating and releasing this buffer.
        /// If this parameter is <see cref="NULL"/>, this method will return the buffer size in <paramref name="pSizeOfData"/>.
        /// </param>
        /// <param name="pSizeOfData">
        /// Pointer to the size of the buffer at <paramref name="pData"/>, in bytes.
        /// If this value is less than the actual size of the private data, such as 0,
        /// the method sets this parameter to the required buffer size, and the method returns <see cref="D3DERR_MOREDATA"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following: <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_MOREDATA"/>, <see cref="D3DERR_NOTFOUND"/>.
        /// </returns>
        public HRESULT GetPrivateData([In] in GUID refguid, [In] IntPtr pData, [In][Out] ref DWORD pSizeOfData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, IntPtr, ref DWORD, HRESULT>)_vTable[5])(thisPtr, refguid, pData, ref pSizeOfData);
            }
        }

        /// <summary>
        /// Frees the specified private data associated with this volume.
        /// </summary>
        /// <param name="refguid">
        /// Reference to the globally unique identifier that identifies the private data to free.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following: <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_NOTFOUND"/>.
        /// </returns>
        /// <remarks>
        /// Direct3D calls this method automatically when a volume is released.
        /// </remarks>
        public HRESULT FreePrivateData([In] in GUID refguid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, HRESULT>)_vTable[6])(thisPtr, refguid);
            }
        }

        /// <summary>
        /// Provides access to the parent volume texture object, if this surface is a child level of a volume texture.
        /// </summary>
        /// <param name="riid">
        /// Reference identifier of the volume being requested.
        /// </param>
        /// <param name="ppContainer">
        /// Address of a pointer to fill with the container pointer, if the query succeeds.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// If the call succeeds, the reference count of the container is increased by one.
        /// Here's an example getting the parent volume texture of a volume texture.
        /// <code>
        /// // Assumes pSurface is a valid IDirect3DVolume9 pointer
        /// void *pContainer = NULL;
        /// IDirect3DVolumeTexture9 *pVolumeTexture = NULL;
        /// HRESULT hr = pVolume->GetContainer(IID_IDirect3DVolumeTexture9, &amp;pContainer);
        /// if (SUCCEEDED(hr) &amp;&amp; pContainer)
        /// {
        ///     pVolumeTexture = (IDirect3DVolumeTexture9 *)pContainer;
        /// </code>
        /// </remarks>
        public HRESULT GetContainer([In] in IID riid, [Out] out IntPtr ppContainer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out IntPtr, HRESULT>)_vTable[7])(thisPtr, riid, out ppContainer);
            }
        }

        /// <summary>
        /// Retrieves a description of the volume.
        /// </summary>
        /// <param name="pDesc">
        /// Pointer to a <see cref="D3DVOLUME_DESC"/> structure, describing the volume.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if the argument is invalid.
        /// </returns>
        public HRESULT GetDesc([Out] out D3DVOLUME_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DVOLUME_DESC, HRESULT>)_vTable[8])(thisPtr, out pDesc);
            }
        }

        /// <summary>
        /// Locks a box on a volume resource.
        /// </summary>
        /// <param name="pLockedVolume">
        /// Pointer to a <see cref="D3DLOCKED_BOX"/> structure, describing the locked region.
        /// </param>
        /// <param name="pBox">
        /// Pointer to a box to lock.
        /// Specified by a pointer to a <see cref="D3DBOX"/> structure.
        /// Specifying <see cref="NullRef{D3DBOX}"/> for this parameter locks the entire volume.
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
        /// See <see cref="IDirect3DDevice9.UpdateTexture"/> for more information.
        /// </remarks>
        public HRESULT LockBox([Out] out D3DLOCKED_BOX pLockedVolume, [In] in D3DBOX pBox, [In] DWORD Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DLOCKED_BOX, in D3DBOX, DWORD, HRESULT>)_vTable[9])(thisPtr, out pLockedVolume, pBox, Flags);
            }
        }

        /// <summary>
        /// Unlocks a box on a volume resource.
        /// </summary>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT UnlockBox()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[10])(thisPtr);
            }
        }
    }
}
