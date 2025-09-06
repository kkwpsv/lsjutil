using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGISurface2"/> interface extends the <see cref="IDXGISurface1"/> interface
    /// by adding support for subresource surfaces and getting a handle to a shared resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgisurface2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An image-data object is a 2D section of memory, commonly called a surface.
    /// To get the surface from an output, call <see cref="IDXGIOutput.GetDisplaySurfaceData"/>.
    /// Then, call <see cref="IUnknown.QueryInterface"/> on the <see cref="IDXGISurface"/> object
    /// that <see cref="IDXGIOutput.GetDisplaySurfaceData"/> returns to retrieve the <see cref="IDXGISurface2"/> interface.
    /// </para>
    /// <para>
    /// Any object that supports <see cref="IDXGISurface"/> also supports <see cref="IDXGISurface2"/>.
    /// </para>
    /// <para>
    /// The runtime automatically creates an <see cref="IDXGISurface2"/> interface
    /// when it creates a Direct3D resource object that represents a surface.
    /// For example, the runtime creates an <see cref="IDXGISurface2"/> interface
    /// when you call <see cref="ID3D11Device.CreateTexture2D"/> to create a 2D texture.
    /// To retrieve the <see cref="IDXGISurface2"/> interface that represents the 2D texture surface,
    /// call <see cref="IUnknown.QueryInterface"/>.
    /// In this call, you must pass the identifier of <see cref="IDXGISurface2"/>.
    /// If the 2D texture has only a single MIP-map level and does not consist of an array of textures,
    /// <see cref="IUnknown.QueryInterface"/> succeeds and returns a pointer to the <see cref="IDXGISurface2"/> interface pointer.
    /// Otherwise, <see cref="QueryInterface"/> fails and does not return the pointer to <see cref="IDXGISurface2"/>.
    /// </para>
    /// <para>
    /// You can call the <see cref="IDXGIResource1.CreateSubresourceSurface"/> method
    /// to create an <see cref="IDXGISurface2"/> interface that refers to one subresource of a stereo resource.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "aba496dd-b617-4cb8-a866-bc44d7eb1fa2", BeginVTableSlotIndex = 13, EndVTableSlotIndex = 13,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIDeviceSubObject), typeof(IDXGISurface), typeof(IDXGISurface1)])]
    public unsafe struct IDXGISurface2
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the parent resource and subresource index that support a subresource surface.
        /// </summary>
        /// <param name="riid">
        /// The globally unique identifier (GUID) of the requested interface type.
        /// </param>
        /// <param name="ppParentResource">
        /// A pointer to a buffer that receives a pointer to the parent resource object for the subresource surface.
        /// </param>
        /// <param name="pSubresourceIndex">
        /// A pointer to a variable that receives the index of the subresource surface.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="E_NOINTERFACE"/> if the object does not implement the <see cref="GUID"/>
        /// that the <paramref name="riid"/> parameter specifies.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For subresource surface objects that the <see cref="IDXGIResource1.CreateSubresourceSurface"/> method creates,
        /// <see cref="GetResource"/> simply returns the values that were used to create the subresource surface.
        /// </para>
        /// <para>
        /// Current objects that implement <see cref="IDXGISurface"/> are either resources or views.
        /// <see cref="GetResource"/> for these objects returns “this” or the resource
        /// that supports the view respectively.
        /// In this situation, the subresource index is 0.
        /// </para>
        /// </remarks>
        public HRESULT GetResource([In] in IID riid, [Out] out IntPtr ppParentResource, [Out] out UINT pSubresourceIndex)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out IntPtr, out UINT, HRESULT>)_vTable[13])(thisPtr, riid, out ppParentResource, out pSubresourceIndex);
            }
        }
    }
}
