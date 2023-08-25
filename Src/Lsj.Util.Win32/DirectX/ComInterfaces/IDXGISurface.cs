using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGISurface"/> interface implements methods for image-data objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgisurface"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An image-data object is a 2D section of memory, commonly called a surface.
    /// To get the surface from an output, call <see cref="IDXGIOutput.GetDisplaySurfaceData"/>.
    /// Runtimes earlier than Direct3D 12 automatically create an <see cref="IDXGISurface"/> interface when they create a Direct3D resource object that represents a surface.
    /// <see cref="IDXGISurface"/> interfaces are not supported in Direct3D 12.
    /// For example, the runtime creates an <see cref="IDXGISurface"/> interface
    /// when you call <see cref="ID3D11Device.CreateTexture2D"/> or <see cref="ID3D10Device.CreateTexture2D"/> to create a 2D texture.
    /// To retrieve the <see cref="IDXGISurface"/> interface that represents the 2D texture surface, call <see cref="IUnknown.QueryInterface"/>.
    /// In this call, you must pass the identifier of <see cref="IDXGISurface"/>.
    /// If the 2D texture has only a single MIP-map level and does not consist of an array of textures, 
    /// <see cref="IUnknown.QueryInterface"/> succeeds and returns a pointer to the <see cref="IDXGISurface"/> interface pointer.
    /// Otherwise, <see cref="IUnknown.QueryInterface"/> fails and does not return the pointer to <see cref="IDXGISurface"/>.
    /// </remarks>
    public unsafe struct IDXGISurface
    {
        IntPtr* _vTable;

        /// <summary>
        /// Get a description of the surface.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to the surface description (see <see cref="DXGI_SURFACE_DESC"/>).
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT GetDesc([Out] out DXGI_SURFACE_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_SURFACE_DESC, HRESULT>)_vTable[8])(thisPtr, out pDesc);
            }
        }

        /// <summary>
        /// Get a pointer to the data contained in the surface, and deny GPU access to the surface.
        /// </summary>
        /// <param name="pLockedRect">
        /// A pointer to the surface data (see DXGI_MAPPED_RECT).
        /// </param>
        /// <param name="MapFlags">
        /// CPU read-write flags. These flags can be combined with a logical OR.
        /// <see cref="DXGI_MAP_READ"/> - Allow CPU read access.
        /// <see cref="DXGI_MAP_WRITE"/> - Allow CPU write access.
        /// <see cref="DXGI_MAP_DISCARD"/> - Discard the previous contents of a resource when it is mapped.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        /// <remarks>
        /// Use <see cref="Map"/> to access a surface from the CPU.
        /// To release a mapped surface (and allow GPU access) call <see cref="Unmap"/>.
        /// </remarks>
        public HRESULT Map([Out] out DXGI_MAPPED_RECT pLockedRect, [In] DXGI_MAP MapFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_MAPPED_RECT, DXGI_MAP, HRESULT>)_vTable[9])(thisPtr, out pLockedRect, MapFlags);
            }
        }

        /// <summary>
        /// Invalidate the pointer to the surface retrieved by <see cref="Map"/> and re-enable GPU access to the resource.
        /// </summary>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT Unmap()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[10])(thisPtr);
            }
        }
    }
}
