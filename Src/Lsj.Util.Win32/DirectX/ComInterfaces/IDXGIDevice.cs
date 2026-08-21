using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_RESIDENCY;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An <see cref="IDXGIDevice"/> interface implements a derived class for DXGI objects that produce image data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgidevice"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="IDXGIDevice"/> interface is designed for use by DXGI objects that need access to other DXGI objects.
    /// This interface is useful to applications that do not use Direct3D to communicate with DXGI.
    /// </para>
    /// <para>
    /// The Direct3D create device functions return a Direct3D device object.
    /// This Direct3D device object implements the <see cref="IUnknown"/> interface.
    /// You can query this Direct3D device object for the device's corresponding <see cref="IDXGIDevice"/> interface.
    /// To retrieve the <see cref="IDXGIDevice"/> interface of a Direct3D device, use the following code:
    /// </para>
    /// <code>
    /// IDXGIDevice * pDXGIDevice;
    /// hr = g_pd3dDevice-&gt;QueryInterface(__uuidof(IDXGIDevice), (void **)&amp;pDXGIDevice);
    /// </code>
    /// <para>
    /// Windows Phone 8: This API is supported.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "54ec77fa-1377-44e6-8c32-88fd5f44c84c", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 11,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject)])]
    public unsafe struct IDXGIDevice
    {
        nint* _vTable;

        /// <summary>
        /// Returns the adapter for the specified device.
        /// </summary>
        /// <param name="pAdapter">
        /// The address of an <see cref="IDXGIAdapter"/> interface pointer to the adapter.
        /// This parameter must not be <see cref="NullRef{T}"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns one of the <see cref="DXGI_ERROR"/> that indicates failure.
        /// If the <paramref name="pAdapter"/> parameter is <see cref="NullRef{T}"/>
        /// this method returns <see cref="E_INVALIDARG"/>.
        /// </returns>
        /// <remarks>
        /// If the <see cref="GetAdapter"/> method succeeds,
        /// the reference count on the adapter interface will be incremented.
        /// To avoid a memory leak, be sure to release the interface when you are finished using it.
        /// </remarks>
        public HRESULT GetAdapter([Out] out P<IDXGIAdapter> pAdapter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDXGIAdapter>, HRESULT>)_vTable[7])(thisPtr, out pAdapter);
            }
        }

        /// <summary>
        /// Returns a surface.
        /// This method is used internally and you should not call it directly in your application.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_SURFACE_DESC"/> structure that describes the surface.
        /// </param>
        /// <param name="NumSurfaces">
        /// The number of surfaces to create.
        /// </param>
        /// <param name="Usage">
        /// A <see cref="DXGI_USAGE"/> flag that specifies how the surface is expected to be used.
        /// </param>
        /// <param name="pSharedResource">
        /// An optional pointer to a <see cref="DXGI_SHARED_RESOURCE"/> structure
        /// that contains shared resource information for opening views of such resources.
        /// </param>
        /// <param name="ppSurface">
        /// The address of an <see cref="IDXGISurface"/> interface pointer to the first created surface.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateSurface"/> method creates a buffer to exchange data between one or more devices.
        /// It is used internally, and you should not directly call it.
        /// </para>
        /// <para>
        /// The runtime automatically creates an <see cref="IDXGISurface"/> interface
        /// when it creates a Direct3D resource object that represents a surface.
        /// For example, the runtime creates an <see cref="IDXGISurface"/> interface
        /// when it calls <see cref="ID3D11Device.CreateTexture2D"/>
        /// or <see cref="ID3D10Device.CreateTexture2D"/> to create a 2D texture.
        /// To retrieve the <see cref="IDXGISurface"/> interface that represents the 2D texture surface,
        /// call <c>ID3D11Texture2D.QueryInterface</c> or <c>ID3D10Texture2D.QueryInterface</c>.
        /// In this call, you must pass the identifier of <see cref="IDXGISurface"/>.
        /// If the 2D texture has only a single MIP-map level and does not consist of an array of textures,
        /// <see cref="IUnknown.QueryInterface"/> succeeds
        /// and returns a pointer to the <see cref="IDXGISurface"/> interface pointer.
        /// Otherwise, <see cref="IUnknown.QueryInterface"/> fails
        /// and does not return the pointer to <see cref="IDXGISurface"/>.
        /// </para>
        /// </remarks>
        public HRESULT CreateSurface([In] in DXGI_SURFACE_DESC pDesc, [In] UINT NumSurfaces, [In] DXGI_USAGE Usage,
            [In] in DXGI_SHARED_RESOURCE pSharedResource, [Out] out P<IDXGISurface> ppSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in DXGI_SURFACE_DESC, UINT, DXGI_USAGE,
                    in DXGI_SHARED_RESOURCE, out P<IDXGISurface>, HRESULT>)_vTable[8])
                    (thisPtr, pDesc, NumSurfaces, Usage, pSharedResource, out ppSurface);
            }
        }

        /// <summary>
        /// Gets the residency status of an array of resources.
        /// </summary>
        /// <param name="ppResources">
        /// An array of <see cref="IDXGIResource"/> interfaces.
        /// </param>
        /// <param name="pResidencyStatus">
        /// An array of <see cref="DXGI_RESIDENCY"/> flags.
        /// Each element describes the residency status for corresponding element
        /// in the <paramref name="ppResources"/> argument array.
        /// </param>
        /// <param name="NumResources">
        /// The number of resources in the <paramref name="ppResources"/> argument array
        /// and <paramref name="pResidencyStatus"/> argument array.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns <see cref="DXGI_ERROR_DEVICE_REMOVED"/>, <see cref="E_INVALIDARG"/>,
        /// or <see cref="E_POINTER"/> (see Common HRESULT Values and WinError.h for more information).
        /// </returns>
        /// <remarks>
        /// <para>
        /// The information returned by the <paramref name="pResidencyStatus"/> argument array
        /// describes the residency status at the time that the <see cref="QueryResourceResidency"/> method was called.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The residency status will constantly change.
        /// </para>
        /// <para>
        /// If you call the <see cref="QueryResourceResidency"/> method during a device removed state,
        /// the <paramref name="pResidencyStatus"/> argument will return the <see cref="DXGI_RESIDENCY_RESIDENT_IN_SHARED_MEMORY"/> flag.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This method should not be called every frame as it incurs a non-trivial amount of overhead.
        /// </para>
        /// </remarks>
        public HRESULT QueryResourceResidency([In] P<IUnknown>[] ppResources, [Out] DXGI_RESIDENCY[] pResidencyStatus, [In] UINT NumResources)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>[], DXGI_RESIDENCY[], UINT, HRESULT>)_vTable[9])
                    (thisPtr, ppResources, pResidencyStatus, NumResources);
            }
        }

        /// <summary>
        /// Sets the GPU thread priority.
        /// </summary>
        /// <param name="Priority">
        /// A value that specifies the required GPU thread priority.
        /// This value must be between -7 and 7, inclusive, where 0 represents normal priority.
        /// </param>
        /// <returns>
        /// Return <see cref="S_OK"/> if successful;
        /// otherwise, returns <see cref="E_INVALIDARG"/>
        /// if the <paramref name="Priority"/> parameter is invalid.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To use the <see cref="SetGPUThreadPriority"/> method,
        /// you should have a comprehensive understanding of GPU scheduling.
        /// If used inappropriately, the <see cref="SetGPUThreadPriority"/> method
        /// can impede rendering speed and result in a poor user experience,
        /// so profile your application to understand impact of priority change on application and on system.
        /// </para>
        /// <para>
        /// The values for the <paramref name="Priority"/> parameter function as follows: Priority Values Bit Definition:
        /// </para>
        /// <para>
        /// Bit 0-4 : Priority Value
        /// </para>
        /// <para>
        /// Bit 5-29 : Reserved
        /// </para>
        /// <para>
        /// Bit 30 : Absolute Priority Flag ( D3DKMT_SETCONTEXTSCHEDULINGPRIORITY_ABSOLUTE ),
        /// can be ORed with Priority Value Bits [4:0] (Only valid for Windows 10+, else not used)
        /// </para>
        /// <para>
        /// Bit 31 : Signed bit
        /// </para>
        /// <para>
        /// Bit 30 (Absolute Priority Flag) can be used to control the mode of operation for this API.
        /// </para>
        /// <para>
        /// Relative Priority Mode : API will use this mode when bit 30 value is set to 0.
        /// In this mode, <paramref name="Priority"/> value must be between -7 and 7, inclusive,
        /// where priority value 0 represents normal priority (Default for all contexts) and -7 represents Idle priority.
        /// Bit 31 is used to control sign of the priority.
        /// </para>
        /// <para>
        /// Absolute Priority Mode : API will use this mode when bit 30 value is set to 1.
        /// In this mode, <paramref name="Priority"/> value (for bits[4:0]) must be between 0 and 31.
        /// Meaning of these priority levels is described below.
        /// Use D3DKMT_SETCONTEXTSCHEDULINGPRIORITY_ABSOLUTE
        /// only if you have thorough understanding of dxgkrnl/graphics priorities and understand repercussions of changing them.
        /// </para>
        /// <para>
        /// Priority Values Bits[4:0] translates to following priority values:
        /// </para>
        /// <para>
        /// 0 : Idle Priority - Forward progress is not guaranteed if higher priorties use most of the accelerator time.
        /// </para>
        /// <para>
        /// 1 : Normal Priority - Most of the processes use this priority with forward progress guarantee.
        /// </para>
        /// <para>
        /// 2 -15 : Reserved -
        /// </para>
        /// <para>
        /// 16-29 : Soft Realtime - Preempts lower priorities and periodically yields
        /// to lower priorities to ensure their forward progress.
        /// </para>
        /// <para>
        /// 30 : Hard Realtime - Used for extremely latency sensitive well bounded workloads.
        /// This priority does not yield to lower priorities.
        /// </para>
        /// <para>
        /// 31 : Internal Use
        /// </para>
        /// </remarks>
        public HRESULT SetGPUThreadPriority([In] INT Priority)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, INT, HRESULT>)_vTable[10])(thisPtr, Priority);
            }
        }

        /// <summary>
        /// Gets the GPU thread priority.
        /// </summary>
        /// <param name="pPriority">
        /// A pointer to a variable that receives a value that indicates the current GPU thread priority.
        /// The value will be between -7 and 7, inclusive, where 0 represents normal priority.
        /// </param>
        /// <returns>
        /// Return <see cref="INT"/> if successful;
        /// otherwise, returns <see cref="E_POINTER"/>
        /// if the <paramref name="pPriority"/> parameter is <see cref="NullRef{INT}"/>.
        /// </returns>
        public HRESULT GetGPUThreadPriority([Out] out INT pPriority)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out INT, HRESULT>)_vTable[11])(thisPtr, out pPriority);
            }
        }
    }
}
