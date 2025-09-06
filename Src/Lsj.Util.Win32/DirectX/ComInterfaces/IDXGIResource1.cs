using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_RESOURCE_MISC_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

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
    /// <para>
    /// To determine the type of memory a resource is currently located in, use <see cref="IDXGIDevice.QueryResourceResidency"/>.
    /// To share resources between processes, use <see cref="ID3D11Device1.OpenSharedResource1"/>.
    /// For information about how to share resources between multiple Windows graphics APIs,
    /// including Direct3D 11, Direct2D, Direct3D 10, and Direct3D 9Ex, see Surface Sharing Between Windows Graphics APIs.
    /// </para>
    /// <para>
    /// You can retrieve the <see cref="IDXGIResource1"/> interface from any video memory resource
    /// that you create from a Direct3D 10 and later function.
    /// Any Direct3D object that supports <see cref="ID3D10Resource"/>
    /// or <see cref="ID3D11Resource"/> also supports <see cref="IDXGIResource1"/>.
    /// For example, the Direct3D 2D texture object that you create
    /// from <see cref="ID3D11Device.CreateTexture2D"/> supports <see cref="IDXGIResource1"/>.
    /// You can call <see cref="IUnknown.QueryInterface"/> on the 2D texture object
    /// (<see cref="ID3D11Texture2D"/>) to retrieve the <see cref="IDXGIResource1"/> interface.
    /// For example, to retrieve the <see cref="IDXGIResource1"/> interface from the 2D texture object, use the following code.
    /// </para>
    /// <code>
    /// IDXGIResource1 * pDXGIResource;
    /// hr = g_pd3dTexture2D->QueryInterface(__uuidof(IDXGIResource1), (void**)&amp;pDXGIResource);
    /// </code>
    /// <para>
    /// Windows Phone 8: This API is supported.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "30961379-4609-4a41-998e-54fe567ee0c1", BeginVTableSlotIndex = 12, EndVTableSlotIndex = 13,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIDeviceSubObject), typeof(IDXGIResource)])]
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
        /// The address of a pointer to a <see cref="IDXGISurface2"/> interface
        /// that represents the created subresource surface object
        /// at the position specified by the <paramref name="index"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the index is out of range or if the subresource is not a valid surface.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_OUTOFMEMORY"/> if insufficient memory is available to create the subresource surface object.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// A subresource is a valid surface if the original resource would have been a valid surface had its array size been equal to 1.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Subresource surface objects implement the <see cref="IDXGISurface2"/> interface,
        /// which inherits from <see cref="IDXGISurface1"/> and indirectly <see cref="IDXGISurface"/>.
        /// Therefore, the GDI-interoperable methods of <see cref="IDXGISurface1"/> work
        /// if the original resource interface object was created with the GDI-interoperable flag
        /// (<see cref="D3D11_RESOURCE_MISC_GDI_COMPATIBLE"/>).
        /// </para>
        /// <para>
        /// <see cref="CreateSubresourceSurface"/> creates a subresource surface
        /// that is based on the resource interface on which <see cref="CreateSubresourceSurface"/> is called.
        /// For example, if the original resource interface object is a 2D texture,
        /// the created subresource surface is also a 2D texture.
        /// </para>
        /// <para>
        /// You can use <see cref="CreateSubresourceSurface"/> to create parts of a stereo resource
        /// so you can use Direct2D on either the left or right part of the stereo resource.
        /// </para>
        /// </remarks>
        public HRESULT CreateSubresourceSurface([In] UINT index, [Out] out P<IDXGISurface2> ppSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDXGISurface2>, HRESULT>)_vTable[12])(thisPtr, index, out ppSurface);
            }
        }

        /// <summary>
        /// Creates a handle to a shared resource. You can then use the returned handle with multiple Direct3D devices.
        /// </summary>
        /// <param name="pAttributes">
        /// <para>
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure
        /// that contains two separate but related data members:
        /// an optional security descriptor,
        /// and a Boolean value that determines whether child processes can inherit the returned handle.
        /// </para>
        /// <para>
        /// Set this parameter to <see cref="NullRef{SECURITY_ATTRIBUTES}"/>
        /// if you want child processes that the application might create to not inherit the handle
        /// returned by <see cref="CreateSharedHandle"/>,
        /// and if you want the resource that is associated with the returned handle to get a default security descriptor.
        /// </para>
        /// <para>
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure
        /// specifies a <see cref="SECURITY_DESCRIPTOR"/> for the resource.
        /// Set this member to <see cref="NULL"/> if you want the runtime to assign a default security descriptor
        /// to the resource that is associated with the returned handle.
        /// The ACLs in the default security descriptor for the resource
        /// come from the primary or impersonation token of the creator.
        /// For more info, see Synchronization Object Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="dwAccess">
        /// <para>
        /// The requested access rights to the resource.
        /// In addition to the generic access rights, DXGI defines the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DXGI_SHARED_RESOURCE_READ"/> ( 0x80000000L ) - specifies read access to the resource.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_SHARED_RESOURCE_WRITE"/> ( 1 ) - specifies write access to the resource.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// You can combine these values by using a bitwise OR operation.
        /// </para>
        /// </param>
        /// <param name="lpName">
        /// <para>
        /// The name of the resource to share.
        /// The name is limited to <see cref="MAX_PATH"/> characters.
        /// Name comparison is case sensitive.
        /// </para>
        /// <para>
        /// You will need the resource name
        /// if you call the <see cref="ID3D11Device1.OpenSharedResourceByName"/> method to access the shared resource by name.
        /// If you instead call the <see cref="ID3D11Device1.OpenSharedResource1"/> method
        /// to access the shared resource by handle, set this parameter to <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If <paramref name="lpName"/> matches the name of an existing resource,
        /// <see cref="CreateSharedHandle"/> fails with <see cref="DXGI_ERROR_NAME_ALREADY_EXISTS"/>.
        /// This occurs because these objects share the same namespace.
        /// </para>
        /// <para>
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character (\).
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// </para>
        /// <para>
        /// The object can be created in a private namespace.
        /// For more information, see Object Namespaces.
        /// </para>
        /// </param>
        /// <param name="pHandle">
        /// A pointer to a variable that receives the NT HANDLE value to the resource to share.
        /// You can use this handle in calls to access the resource.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if one of the parameters is invalid.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_NAME_ALREADY_EXISTS"/> if the supplied name of the resource
        /// to share is already associated with another resource.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_ACCESSDENIED"/> if the object is being created in a protected namespace.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_OUTOFMEMORY"/> if sufficient memory is not available to create the handle.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="CreateSharedHandle"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="CreateSharedHandle"/> only returns the NT handle
        /// when you created the resource as shared and specified that it uses NT handles
        /// (that is, you set the <see cref="D3D11_RESOURCE_MISC_SHARED_NTHANDLE"/> and <see cref="D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> flags).
        /// If you created the resource as shared and specified that it uses NT handles,
        /// you must use <see cref="CreateSharedHandle"/> to get a handle for sharing.
        /// In this situation, you can't use the <see cref="IDXGIResource.GetSharedHandle"/> method because it will fail.
        /// </para>
        /// <para>
        /// You can pass the handle that <see cref="CreateSharedHandle"/> returns
        /// in a call to the <see cref="ID3D11Device1.OpenSharedResource1"/> method
        /// to give a device access to a shared resource that you created on a different device.
        /// </para>
        /// <para>
        /// Because the handle that <see cref="CreateSharedHandle"/> returns is an NT handle,
        /// you can use the handle with <see cref="CloseHandle"/>, <see cref="DuplicateHandle"/>, and so on.
        /// You can call <see cref="CreateSharedHandle"/> only once for a shared resource; later calls fail.
        /// If you need more handles to the same shared resource, call <see cref="DuplicateHandle"/>.
        /// When you no longer need the shared resource handle,
        /// call <see cref="CloseHandle"/> to close the handle, in order to avoid memory leaks.
        /// </para>
        /// <para>
        /// If you pass a name for the resource to <paramref name="lpName"/>
        /// when you call <see cref="CreateSharedHandle"/> to share the resource,
        /// you can subsequently pass this name in a call to the <see cref="ID3D11Device1.OpenSharedResourceByName"/> method
        /// to give another device access to the shared resource.
        /// If you use a named resource, a malicious user can use this named resource
        /// before you do and prevent your app from starting.
        /// To prevent this situation, create a randomly named resource and store the name
        /// so that it can only be obtained by an authorized user.
        /// Alternatively, you can use a file for this purpose.
        /// To limit your app to one instance per user, create a locked file in the user's profile directory.
        /// </para>
        /// <para>
        /// If you created the resource as shared and did not specify that it uses NT handles,
        /// you cannot use <see cref="CreateSharedHandle"/> to get a handle for sharing
        /// because <see cref="CreateSharedHandle"/> will fail.
        /// </para>
        /// </remarks>
        public HRESULT CreateSharedHandle([In] in SECURITY_ATTRIBUTES pAttributes, [In] DWORD dwAccess, [In] LPCWSTR lpName, [Out] out HANDLE pHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in SECURITY_ATTRIBUTES, DWORD, IntPtr, out HANDLE, HRESULT>)_vTable[13])
                    (thisPtr, pAttributes, dwAccess, lpName.ToIntPtr(), out pHandle);
            }
        }
    }
}
