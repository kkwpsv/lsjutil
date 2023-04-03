using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// Applications use the methods of the <see cref="IDirect3DSurface9"/> interface to query and prepare surfaces.
    /// </summary>
    public unsafe struct IDirect3DSurface9
    {
        IntPtr* _vTable;

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
        /// If the surface is created using <see cref="IDirect3DDevice9.CreateRenderTarget"/> or <see cref="IDirect3DDevice9.CreateOffscreenPlainSurface"/>
        /// or <see cref="IDirect3DDevice9.CreateDepthStencilSurface"/>, the surface is considered stand alone.
        /// In this case, <see cref="GetContainer"/> will return the Direct3D device used to create the surface.
        /// If the call succeeds, the reference count of the container is increased by one.
        /// </remarks>
        public HRESULT GetContainer([In] in IID riid, [Out] out IntPtr ppContainer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out IntPtr, HRESULT>)_vTable[11])(thisPtr, riid, out ppContainer);
            }
        }

        /// <summary>
        /// Retrieves a description of the surface.
        /// </summary>
        /// <param name="pDesc">
        /// Pointer to a <see cref="D3DSURFACE_DESC"/> structure, describing the surface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if the argument is invalid.
        /// </returns>
        public HRESULT GetDesc([Out] out D3DSURFACE_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DSURFACE_DESC, HRESULT>)_vTable[12])(thisPtr, out pDesc);
            }
        }
    }
}
