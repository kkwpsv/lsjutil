using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_RESOURCE_PRIORITY;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_RESOURCE_MISC_FLAG;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An <see cref="IDXGIResource"/> interface allows resource sharing and identifies the memory that a resource resides in.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgiresource"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To find out what type of memory a resource is currently located in, use <see cref="IDXGIDevice.QueryResourceResidency"/>.
    /// To share resources between processes, use <see cref="ID3D10Device.OpenSharedResource"/>.
    /// For information about how to share resources between multiple Windows graphics APIs,
    /// including Direct3D 11, Direct2D, Direct3D 10, and Direct3D 9Ex, see Surface Sharing Between Windows Graphics APIs.
    /// </para>
    /// <para>
    /// You can retrieve the <see cref="IDXGIResource"/> interface from any video memory resource
    /// that you create from a Direct3D 10 and later function.
    /// Any Direct3D object that supports <see cref="ID3D10Resource"/> or <see cref="ID3D11Resource"/> also supports <see cref="IDXGIResource"/>.
    /// For example, the Direct3D 2D texture object that you create
    /// from <see cref="ID3D11Device.CreateTexture2D"/> supports <see cref="IDXGIResource"/>.
    /// You can call <see cref="IUnknown.QueryInterface"/> on the 2D texture object
    /// (<see cref="ID3D11Texture2D"/>) to retrieve the <see cref="IDXGIResource"/> interface.
    /// For example, to retrieve the <see cref="IDXGIResource"/> interface from the 2D texture object, use the following code.
    /// </para>
    /// <code>
    /// IDXGIResource * pDXGIResource;
    /// hr = g_pd3dTexture2D->QueryInterface(__uuidof(IDXGIResource), (void**)&amp;pDXGIResource);
    /// </code>
    /// <para>
    /// Windows Phone 8: This API is supported.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "035f3ab4-482e-4e50-b41f-8a7f8bd8960b", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 11,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIDeviceSubObject)])]
    public unsafe struct IDXGIResource
    {
        nint* _vTable;

        /// <summary>
        /// Gets the handle to a shared resource.
        /// </summary>
        /// <param name="pSharedHandle">
        /// A pointer to a handle.
        /// </param>
        /// <returns>
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetSharedHandle"/> returns a handle for the resource that you created as shared
        /// (that is, you set the <see cref="D3D11_RESOURCE_MISC_SHARED"/>
        /// with or without the <see cref="D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> flag).
        /// You can pass this handle to the <see cref="ID3D11Device.OpenSharedResource"/> method
        /// to give another device access to the shared resource.
        /// You can also marshal this handle to another process to share a resource with a device in another process.
        /// However, this handle is not an NT handle.
        /// Therefore, don't use the handle with <see cref="CloseHandle"/>, <see cref="DuplicateHandle"/>, and so on.
        /// </para>
        /// <para>
        /// The creator of a shared resource must not destroy the resource until all intended entities have opened the resource.
        /// The validity of the handle is tied to the lifetime of the underlying video memory.
        /// If no resource objects exist on any devices that refer to this resource, the handle is no longer valid.
        /// To extend the lifetime of the handle and video memory, you must open the shared resource on a device.
        /// </para>
        /// <para>
        /// <see cref="GetSharedHandle"/> can also return handles for resources
        /// that were passed into <see cref="ID3D11Device.OpenSharedResource"/> to open those resources.
        /// </para>
        /// <para>
        /// <see cref="GetSharedHandle"/> fails if the resource to which it wants to get a handle is not shared.
        /// </para>
        /// </remarks>
        [Obsolete("Starting with Direct3D 11.1, we recommend not to use GetSharedHandle anymore to retrieve the handle to a shared resource. " +
            "Instead, use IDXGIResource1::CreateSharedHandle to get a handle for sharing. " +
            "To use IDXGIResource1::CreateSharedHandle, you must create the resource as shared " +
            "and specify that it uses NT handles (that is, you set the D3D11_RESOURCE_MISC_SHARED_NTHANDLE flag). " +
            "We also recommend that you create shared resources that use NT handles so you can use CloseHandle, DuplicateHandle, and so on on those shared resources.")]
        public HRESULT GetSharedHandle([Out] out HANDLE pSharedHandle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out HANDLE, HRESULT>)_vTable[8])(thisPtr, out pSharedHandle);
            }
        }

        /// <summary>
        /// Get the expected resource usage.
        /// </summary>
        /// <param name="pUsage">
        /// A pointer to a usage flag (see <see cref="DXGI_USAGE"/>).
        /// For Direct3D 10, a surface can be used as a shader input or a render-target output.
        /// </param>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        public HRESULT GetUsage([Out] out DXGI_USAGE pUsage)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_USAGE, HRESULT>)_vTable[9])(thisPtr, out pUsage);
            }
        }

        /// <summary>
        /// Set the priority for evicting the resource from memory.
        /// </summary>
        /// <param name="EvictionPriority">
        /// <para>
        /// The priority is one of the following values:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DXGI_RESOURCE_PRIORITY_MINIMUM"/> (0x28000000)
        /// </term>
        /// <term>
        /// The resource is unused and can be evicted as soon as another resource requires the memory that the resource occupies.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXGI_RESOURCE_PRIORITY_LOW"/> (0x50000000)
        /// </term>
        /// <term>
        /// The eviction priority of the resource is low.
        /// The placement of the resource is not critical, and minimal work is performed to find a location for the resource.
        /// For example, if a GPU can render with a vertex buffer from either local or non-local memory
        /// with little difference in performance, that vertex buffer is low priority.
        /// Other more critical resources (for example, a render target or texture) can then occupy the faster memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXGI_RESOURCE_PRIORITY_NORMAL"/> (0x78000000)
        /// </term>
        /// <term>
        /// The eviction priority of the resource is normal.
        /// The placement of the resource is important, but not critical, for performance.
        /// The resource is placed in its preferred location instead of a low-priority resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXGI_RESOURCE_PRIORITY_HIGH"/> (0xa0000000)
        /// </term>
        /// <term>
        /// The eviction priority of the resource is high.
        /// The resource is placed in its preferred location instead of a low-priority or normal-priority resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXGI_RESOURCE_PRIORITY_MAXIMUM"/> (0xc8000000)
        /// </term>
        /// <term>
        /// The resource is evicted from memory only if there is no other way of resolving the memory requirement.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The eviction priority is a memory-management variable that is used by DXGI for determining how to populate overcommitted memory.
        /// </para>
        /// <para>
        /// You can set priority levels other than the defined values when appropriate.
        /// For example, you can set a resource with a priority level of 0x78000001 to indicate that the resource is slightly above normal.
        /// </para>
        /// </remarks>
        public HRESULT SetEvictionPriority([In] UINT EvictionPriority)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[10])(thisPtr, EvictionPriority);
            }
        }

        /// <summary>
        /// Get the eviction priority.
        /// </summary>
        /// <param name="pEvictionPriority">
        /// <para>
        /// A pointer to the eviction priority, which determines when a resource can be evicted from memory.
        /// </para>
        /// <para>
        /// The following defined values are possible.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DXGI_RESOURCE_PRIORITY_MINIMUM"/> (0x28000000)
        /// </term>
        /// <term>
        /// The resource is unused and can be evicted as soon as another resource requires the memory that the resource occupies.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXGI_RESOURCE_PRIORITY_LOW"/> (0x50000000)
        /// </term>
        /// <term>
        /// The eviction priority of the resource is low.
        /// The placement of the resource is not critical, and minimal work is performed to find a location for the resource.
        /// For example, if a GPU can render with a vertex buffer from either local or non-local memory
        /// with little difference in performance, that vertex buffer is low priority.
        /// Other more critical resources (for example, a render target or texture) can then occupy the faster memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXGI_RESOURCE_PRIORITY_NORMAL"/> (0x78000000)
        /// </term>
        /// <term>
        /// The eviction priority of the resource is normal.
        /// The placement of the resource is important, but not critical, for performance.
        /// The resource is placed in its preferred location instead of a low-priority resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXGI_RESOURCE_PRIORITY_HIGH"/> (0xa0000000)
        /// </term>
        /// <term>
        /// The eviction priority of the resource is high.
        /// The resource is placed in its preferred location instead of a low-priority or normal-priority resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXGI_RESOURCE_PRIORITY_MAXIMUM"/> (0xc8000000)
        /// </term>
        /// <term>
        /// The resource is evicted from memory only if there is no other way of resolving the memory requirement.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The eviction priority is a memory-management variable that is used by DXGI to determine how to manage overcommitted memory.
        /// </para>
        /// <para>
        /// Priority levels other than the defined values are used when appropriate.
        /// For example, a resource with a priority level of 0x78000001 indicates that the resource is slightly above normal.
        /// </para>
        /// </remarks>
        public HRESULT GetEvictionPriority([Out] out UINT pEvictionPriority)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[11])(thisPtr, out pEvictionPriority);
            }
        }
    }
}
