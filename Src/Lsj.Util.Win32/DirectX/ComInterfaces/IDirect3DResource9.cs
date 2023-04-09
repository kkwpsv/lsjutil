using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using IUnknown = Lsj.Util.Win32.ComInterfaces.IUnknown;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DResource9"/> interface to query and prepare resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dresource9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To create a texture resource, you can call one of the following methods.
    /// <see cref="IDirect3DDevice9.CreateCubeTexture"/>
    /// <see cref="IDirect3DDevice9.CreateTexture"/>
    /// <see cref="IDirect3DDevice9.CreateVolumeTexture"/>
    /// To create a geometry-oriented resource, you can call one of the following methods.
    /// <see cref="IDirect3DDevice9.CreateIndexBuffer"/>
    /// <see cref="IDirect3DDevice9.CreateVertexBuffer"/>
    /// This interface, like all COM interfaces, inherits from the <see cref="IUnknown"/> interface.
    /// The LPDIRECT3DRESOURCE9 and PDIRECT3DRESOURCE9 types are defined as pointers to the <see cref="IDirect3DResource9"/> interface.
    /// <code>
    /// typedef struct IDirect3DResource9 *LPDIRECT3DRESOURCE9, *PDIRECT3DRESOURCE9;</code>
    /// </remarks>
    public unsafe struct IDirect3DResource9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves the device associated with a resource.
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
        /// Associates data with the resource that is intended for use by the application, not by Direct3D.
        /// Data is passed by value, and multiple sets of data can be associated with a single resource.
        /// </summary>
        /// <param name="refguid">
        /// Reference to the globally unique identifier that identifies the private data to set.
        /// </param>
        /// <param name="pData">
        /// Pointer to a buffer that contains the data to be associated with the resource.
        /// </param>
        /// <param name="SizeOfData">
        /// Size of the buffer at <paramref name="pData"/>, in bytes.
        /// </param>
        /// <param name="Flags">
        /// Value that describes the type of data being passed, or indicates to the application that the data should be invalidated when the resource changes.
        /// 0:
        /// If no flags are specified, Direct3D allocates memory to hold the data within the buffer and copies the data into the new buffer.
        /// The buffer allocated by Direct3D is automatically freed, as appropriate.
        /// <see cref="D3DSPD_IUNKNOWN"/>:
        /// The data at <paramref name="pData"/> is a pointer to an <see cref="IUnknown"/> interface.
        /// <paramref name="SizeOfData"/> must be set to the size of a pointer to <see cref="IUnknown"/>, that is, <code>sizeof(IUnknown*)</code>.
        /// Direct3D automatically calls <see cref="IUnknown"/> through <paramref name="pData"/> when the private data is destroyed.
        /// Private data will be destroyed by a subsequent call to <see cref="IDirect3DResource9.SetPrivateData"/>with the same GUID,
        /// a subsequent call to <see cref="IDirect3DResource9.FreePrivateData"/>, or when the <see cref="IDirect3D9"/> object is released.
        /// For more information, see Remarks.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following: <see cref="D3DERR_INVALIDCALL"/>, <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// Direct3D does not manage the memory at <paramref name="pData"/>.
        /// If this buffer was dynamically allocated, it is the calling application's responsibility to free the memory.
        /// </remarks>
        public HRESULT SetPrivateData([In] in GUID refguid, [In] IntPtr pData, [In] DWORD SizeOfData, [In] DWORD Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, IntPtr, DWORD, DWORD, HRESULT>)_vTable[4])(thisPtr, refguid, pData, SizeOfData, Flags);
            }
        }

        /// <summary>
        /// Copies the private data associated with the resource to a provided buffer.
        /// </summary>
        /// <param name="refguid">
        /// The globally unique identifier that identifies the private data to retrieve.
        /// </param>
        /// <param name="pData">
        /// Pointer to a previously allocated buffer to fill with the requested private data if the call succeeds.
        /// The application calling this method is responsible for allocating and releasing this buffer.
        /// If this parameter is <see cref="NULL"/>, this method will return the buffer size in <paramref name="pSizeOfData"/>.
        /// </param>
        /// <param name="pSizeOfData">
        /// Pointer to the size of the buffer at <paramref name="pData"/>, in bytes.
        /// If this value is less than the actual size of the private data (such as 0),
        /// the method sets this parameter to the required buffer size and the method returns <see cref="D3DERR_MOREDATA"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_MOREDATA"/>, <see cref="D3DERR_NOTFOUND"/>.
        /// </returns>
        /// <remarks>
        /// This method is inherited by the following interfaces:
        /// <see cref="IDirect3DResource9"/>, <see cref="IDirect3DBaseTexture9"/>, <see cref="IDirect3DCubeTexture9"/>,
        /// <see cref="IDirect3DTexture9"/>, <see cref="IDirect3DVolumeTexture9"/>, <see cref="IDirect3DIndexBuffer9"/>,
        /// <see cref="IDirect3DVertexBuffer9"/>.
        /// </remarks>
        public HRESULT GetPrivateData([In] in GUID refguid, [In] IntPtr pData, [In][Out] ref DWORD pSizeOfData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, IntPtr, ref DWORD, HRESULT>)_vTable[5])(thisPtr, refguid, pData, ref pSizeOfData);
            }
        }

        /// <summary>
        /// Frees the specified private data associated with this resource.
        /// </summary>
        /// <param name="refguid">
        /// Reference to the globally unique identifier that identifies the private data to free.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following: <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_NOTFOUND"/>.
        /// </returns>
        /// <remarks>
        /// Direct3D calls this method automatically when a resource is released.
        /// </remarks>
        public HRESULT FreePrivateData([In] in GUID refguid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, HRESULT>)_vTable[6])(thisPtr, refguid);
            }
        }

        /// <summary>
        /// Assigns the priority of a resource for scheduling purposes.
        /// </summary>
        /// <param name="PriorityNew">
        /// Priority to assign to a resource.
        /// Differences between Direct3D 9 and Direct3D 9 for Windows Vista
        /// The priority can be any DWORD value; Direct3D 9 for Windows Vista also supports any of these pre-defined values D3D9_RESOURCE_PRIORITY.
        /// </param>
        /// <returns>
        /// Returns the previous priority value for the resource.
        /// </returns>
        /// <remarks>
        /// This method is used to change the priority of managed resources (resources created with the <see cref="D3DPOOL_MANAGED"/> flag).
        /// This method returns 0 on non-managed resources.
        /// Priorities are used to determine when managed resources are to be removed from memory.
        /// A resource assigned a low priority is removed before a resource with a high priority.
        /// If two resources have the same priority, the resource that was used more recently is kept in memory; the other resource is removed.
        /// Managed resources have a default priority of 0.
        /// Windows Vista only - When this method is called using an <see cref="IDirect3D9Ex"/> interface,
        /// only resources created with the <see cref="D3DPOOL_DEFAULT"/> flag will be affected.
        /// </remarks>
        public DWORD SetPriority([In] DWORD PriorityNew)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, DWORD>)_vTable[7])(thisPtr, PriorityNew);
            }
        }

        /// <summary>
        /// Retrieves the priority for this resource.
        /// </summary>
        /// <returns>
        /// Returns a DWORD value, indicating the priority of the resource.
        /// </returns>
        /// <remarks>
        /// <see cref="IDirect3DResource9.GetPriority"/> is used for priority control of managed resources.
        /// This method returns 0 on nonmanaged resources.
        /// Priorities are used to determine when managed resources are to be removed from memory.
        /// A resource assigned a low priority is removed before a resource with a high priority.
        /// If two resources have the same priority, the resource that was used more recently is kept in memory; the other resource is removed.
        /// Managed resources have a default priority of 0.
        /// </remarks>
        public DWORD GetPriority()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD>)_vTable[8])(thisPtr);
            }
        }

        /// <summary>
        /// Preloads a managed resource.
        /// </summary>
        /// <remarks>
        /// Calling this method indicates that the application will need this managed resource shortly.
        /// This method has no effect on nonmanaged resources.
        /// <see cref="PreLoad"/> detects "thrashing" conditions
        /// where more resources are being used in each frame than can fit in video memory simultaneously.
        /// Under such circumstances <see cref="PreLoad"/> silently does nothing.
        /// </remarks>
        public void PreLoad()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[9])(thisPtr);
            }
        }

        /// <summary>
        /// Returns the type of the resource.
        /// </summary>
        /// <returns>
        /// Returns a member of the <see cref="D3DRESOURCETYPE"/> enumerated type, identifying the type of the resource.
        /// </returns>
        public new D3DRESOURCETYPE GetType()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DRESOURCETYPE>)_vTable[10])(thisPtr);
            }
        }
    }
}
