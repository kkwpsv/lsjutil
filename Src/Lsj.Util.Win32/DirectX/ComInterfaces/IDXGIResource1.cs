using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An <see cref="IDXGIResource1"/> interface extends the <see cref="IDXGIResource"/> interface
    /// by adding support for creating a subresource surface object and for creating a handle to a shared resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgiresource1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To determine the type of memory a resource is currently located in, use <see cref="IDXGIDevice.QueryResourceResidency"/>.
    /// To share resources between processes, use <see cref="ID3D11Device1.OpenSharedResource1"/>.
    /// For information about how to share resources between multiple Windows graphics APIs,
    /// including Direct3D 11, Direct2D, Direct3D 10, and Direct3D 9Ex, see Surface Sharing Between Windows Graphics APIs.
    /// You can retrieve the <see cref="IDXGIResource1"/> interface from any video memory resource that you create from a Direct3D 10 and later function.
    /// Any Direct3D object that supports <see cref="ID3D10Resource"/> or <see cref="ID3D11Resource"/> also supports <see cref="IDXGIResource1"/>.
    /// For example, the Direct3D 2D texture object that you create from <see cref="ID3D11Device.CreateTexture2D"/> supports <see cref="IDXGIResource1"/>.
    /// You can call <see cref="IUnknown.QueryInterface"/> on the 2D texture object (<see cref="ID3D11Texture2D"/>) to retrieve the <see cref="IDXGIResource1"/> interface.
    /// For example, to retrieve the <see cref="IDXGIResource"/> interface from the 2D texture object, use the following code.
    /// <code>
    /// IDXGIResource1 * pDXGIResource;
    /// hr = g_pd3dTexture2D->QueryInterface(__uuidof(IDXGIResource1), (void**)&amp;pDXGIResource);
    /// </code>
    /// Windows Phone 8: This API is supported.
    /// </remarks>
    public unsafe struct IDXGIResource1
    {
        IntPtr* _vTable;

        /// <summary>
        /// Creates a subresource surface object.
        /// </summary>
        /// <param name="index">
        /// The index of the subresource surface object to enumerate.
        /// </param>
        /// <param name="ppSurface">
        /// The address of a pointer to a <see cref="IDXGISurface2"/> interface that represents the created subresource surface object
        /// at the position specified by the <paramref name="index"/> parameter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following values:
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the <paramref name="index"/> is out of range or if the subresource is not a valid surface.
        /// <see cref="E_OUTOFMEMORY"/> if insufficient memory is available to create the subresource surface object.
        /// A subresource is a valid surface if the original resource would have been a valid surface had its array size been equal to 1.
        /// </returns>
        /// <remarks>
        /// Subresource surface objects implement the <see cref="IDXGISurface2"/> interface,
        /// which inherits from <see cref="IDXGISurface1"/> and indirectly <see cref="IDXGISurface"/>.
        /// Therefore, the GDI-interoperable methods of <see cref="IDXGISurface1"/> work
        /// if the original resource interface object was created with the GDI-interoperable flag (<see cref="D3D11_RESOURCE_MISC_GDI_COMPATIBLE"/>).
        /// <see cref="CreateSubresourceSurface"/> creates a subresource surface
        /// that is based on the resource interface on which <see cref="CreateSubresourceSurface"/> is called.
        /// For example, if the original resource interface object is a 2D texture, the created subresource surface is also a 2D texture.
        /// You can use <see cref="CreateSubresourceSurface"/> to create parts of a stereo resource
        /// so you can use Direct2D on either the left or right part of the stereo resource.
        /// </remarks>
        public HRESULT CreateSubresourceSurface([In] UINT index, [Out] out P<IDXGISurface2> ppSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDXGISurface2>, HRESULT>)_vTable[12])(thisPtr, index, out ppSurface);
            }
        }
    }
}
