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
    public unsafe struct IDXGIDevice
    {
        IntPtr* _vTable;

        /// <summary>
        /// Returns the adapter for the specified device.
        /// </summary>
        /// <param name="pAdapter">
        /// The address of an <see cref="IDXGIAdapter"/> interface pointer to the adapter.
        /// This parameter must not be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the <see cref="DXGI_ERROR"/> that indicates failure.
        /// If the <paramref name="pAdapter"/> parameter is <see cref="NULL"/> this method returns <see cref="E_INVALIDARG"/>.
        /// </returns>
        /// <remarks>
        /// If the <see cref="GetAdapter"/> method succeeds, the reference count on the adapter interface will be incremented.
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
        /// An optional pointer to a <see cref="DXGI_SHARED_RESOURCE"/> structure that contains shared resource information for opening views of such resources.
        /// </param>
        /// <param name="ppSurface">
        /// The address of an <see cref="IDXGISurface"/> interface pointer to the first created surface.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateSurface"/> method creates a buffer to exchange data between one or more devices.
        /// It is used internally, and you should not directly call it.
        /// The runtime automatically creates an <see cref="IDXGISurface"/> interface when it creates a Direct3D resource object that represents a surface.
        /// For example, the runtime creates an <see cref="IDXGISurface"/> interface
        /// when it calls <see cref="ID3D11Device.CreateTexture2D"/> or <see cref="ID3D10Device.CreateTexture2D"/> to create a 2D texture.
        /// To retrieve the <see cref="IDXGISurface"/> interface that represents the 2D texture surface,
        /// call <see cref="IUnknown.QueryInterface"/>. In this call, you must pass the identifier of <see cref="IDXGISurface"/>.
        /// If the 2D texture has only a single MIP-map level and does not consist of an array of textures,
        /// <see cref="IUnknown.QueryInterface"/> succeeds and returns a pointer to the <see cref="IDXGISurface"/> interface pointer.
        /// Otherwise, <see cref="IUnknown.QueryInterface"/> fails and does not return the pointer to <see cref="IDXGISurface"/>.
        /// </remarks>
        public HRESULT CreateSurface([In] in DXGI_SURFACE_DESC pDesc, [In] UINT NumSurfaces, [In] DXGI_USAGE Usage,
            [In] in DXGI_SHARED_RESOURCE pSharedResource, [Out] out P<IDXGISurface> ppSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in DXGI_SURFACE_DESC, UINT, DXGI_USAGE, in DXGI_SHARED_RESOURCE, out P<IDXGISurface>, HRESULT>)_vTable[8])
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
        /// Each element describes the residency status for corresponding element in the <paramref name="ppResources"/> argument array.
        /// </param>
        /// <param name="NumResources">
        /// The number of resources in the <paramref name="ppResources"/> argument array and <paramref name="pResidencyStatus"/> argument array.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns <see cref="DXGI_ERROR_DEVICE_REMOVED"/>, <see cref="E_INVALIDARG"/>,
        /// or <see cref="E_POINTER"/> (see Common HRESULT Values and WinError.h for more information).
        /// </returns>
        /// <remarks>
        /// The information returned by the <paramref name="pResidencyStatus"/> argument array describes the residency status
        /// at the time that the <see cref="QueryResourceResidency"/> method was called.
        /// Note
        /// The residency status will constantly change.
        /// If you call the <see cref="QueryResourceResidency"/> method during a device removed state,
        /// the <paramref name="pResidencyStatus"/> argument will return the <see cref="DXGI_RESIDENCY_RESIDENT_IN_SHARED_MEMORY"/> flag.
        /// Note
        /// This method should not be called every frame as it incurs a non-trivial amount of overhead.
        /// </remarks>
        public HRESULT QueryResourceResidency([In] P<IUnknown>[] ppResources, [Out] DXGI_RESIDENCY[] pResidencyStatus, [In] UINT NumResources)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>[], DXGI_RESIDENCY[], UINT, HRESULT>)_vTable[9])(thisPtr, ppResources, pResidencyStatus, NumResources);
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
        /// otherwise, returns <see cref="E_INVALIDARG"/> if the <paramref name="Priority"/> parameter is invalid.
        /// </returns>
        /// <remarks>
        /// The values for the <paramref name="Priority"/> parameter function as follows:
        /// Positive values increase the likelihood that the GPU scheduler will grant GPU execution cycles to the device when rendering.
        /// Negative values lessen the likelihood that the device will receive GPU execution cycles when devices compete for them.
        /// The device is guaranteed to receive some GPU execution cycles at all settings.
        /// To use the <see cref="SetGPUThreadPriority"/> method, you should have a comprehensive understanding of GPU scheduling.
        /// You should profile your application to ensure that it behaves as intended.
        /// If used inappropriately, the <see cref="SetGPUThreadPriority"/> method can impede rendering speed and result in a poor user experience.
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
        /// otherwise, returns <see cref="E_POINTER"/> if the <paramref name="pPriority"/> parameter is <see cref="NullRef{INT}"/>.
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
