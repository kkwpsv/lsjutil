using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DLOCK;
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
    public unsafe struct IDirect3DTexture9
    {
        IntPtr* _vTable;

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
