using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGIDevice2"/> interface implements a derived class for DXGI objects that produce image data.
    /// The interface exposes methods to block CPU processing until the GPU completes processing, and to offer resources to the operating system.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgidevice2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="IDXGIDevice2"/> interface is designed for use by DXGI objects that need access to other DXGI objects.
    /// This interface is useful to applications that do not use Direct3D to communicate with DXGI.
    /// The Direct3D create device functions return a Direct3D device object.
    /// This Direct3D device object implements the <see cref="IUnknown"/> interface.
    /// You can query this Direct3D device object for the device's corresponding <see cref="IDXGIDevice1"/> interface.
    /// To retrieve the <see cref="IDXGIDevice1"/> interface of a Direct3D device, use the following code:
    /// <code>
    /// IDXGIDevice1 * pDXGIDevice;
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice1), (void**)&amp;pDXGIDevice);
    /// </code>
    /// Windows Phone 8: This API is supported.
    /// </remarks>
    public unsafe struct IDXGIDevice2
    {
        IntPtr* _vTable;

        /// <summary>
        /// Allows the operating system to free the video memory of resources by discarding their content.
        /// </summary>
        /// <param name="NumResources">
        /// The number of resources in the <paramref name="ppResources"/> argument array.
        /// </param>
        /// <param name="ppResources">
        /// An array of pointers to <see cref="IDXGIResource"/> interfaces for the resources to offer.
        /// </param>
        /// <param name="Priority">
        /// A <see cref="DXGI_OFFER_RESOURCE_PRIORITY"/>-typed value that indicates how valuable data is.
        /// </param>
        /// <returns>
        /// <see cref="OfferResources"/> returns:
        /// <see cref="S_OK"/> if resources were successfully offered
        /// <see cref="E_INVALIDARG"/> if a resource in the array or the priority is invalid
        /// </returns>
        /// <remarks>
        /// The priority value that the <paramref name="Priority"/> parameter specifies describes how valuable the caller considers the content to be.
        /// The operating system uses the priority value to discard resources in order of priority.
        /// The operating system discards a resource that is offered with low priority before it discards a resource that is offered with a higher priority.
        /// If you call <see cref="OfferResources"/> to offer a resource while the resource is bound to the pipeline, the resource is unbound.
        /// You cannot call <see cref="OfferResources"/> on a resource that is mapped.
        /// After you offer a resource, the resource cannot be mapped or bound to the pipeline
        /// until you call the <see cref="ReclaimResource"/> method to reclaim the resource.
        /// You cannot call <see cref="OfferResources"/> to offer immutable resources.
        /// To offer shared resources, call <see cref="OfferResources"/> on only one of the sharing devices.
        /// To ensure exclusive access to the resources, you must use an <see cref="IDXGIKeyedMutex"/> object
        /// and then call <see cref="OfferResources"/> only while you hold the mutex.
        /// In fact, you can't offer shared resources unless you use <see cref="IDXGIKeyedMutex"/>
        /// because offering shared resources without using <see cref="IDXGIKeyedMutex"/> isn't supported.
        /// Note
        /// The user mode display driver might not immediately offer the resources that you specified in a call to <see cref="OfferResources"/>.
        /// The driver can postpone offering them until the next call to <see cref="IDXGISwapChain.Present"/>,
        /// <see cref="IDXGISwapChain1.Present1"/>, or <see cref="ID3D11DeviceContext.Flush"/>.
        /// Platform Update for Windows 7:
        /// The runtime validates that <see cref="OfferResources"/> is used correctly on non-shared resources but doesn't perform the intended functionality.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </remarks>
        public HRESULT OfferResources([In] UINT NumResources, [In] P<IDXGIResource>[] ppResources, [In] DXGI_OFFER_RESOURCE_PRIORITY Priority)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (P<IDXGIResource>* ppResourcesPtr = ppResources)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, UINT, P<IDXGIResource>*, DXGI_OFFER_RESOURCE_PRIORITY, HRESULT>)_vTable[14])
                        (thisPtr, NumResources, ppResourcesPtr, Priority);
                }
            }
        }

        /// <summary>
        /// Restores access to resources that were previously offered by calling <see cref="OfferResources"/>.
        /// </summary>
        /// <param name="NumResources">
        /// The number of resources in the <paramref name="ppResources"/> argument and <paramref name="pDiscarded"/> argument arrays.
        /// </param>
        /// <param name="ppResources">
        /// An array of pointers to <see cref="IDXGIResource"/> interfaces for the resources to reclaim.
        /// </param>
        /// <param name="pDiscarded">
        /// A pointer to an array that receives Boolean values.
        /// Each value in the array corresponds to a resource at the same index that the <paramref name="ppResources"/> parameter specifies.
        /// The runtime sets each Boolean value to <see cref="TRUE"/> if the corresponding resource’s content was discarded and is now undefined,
        /// or to <see cref="FALSE"/> if the corresponding resource’s old content is still intact.
        /// The caller can pass in <see langword="null"/>, if the caller intends to fill the resources with new content regardless of whether the old content was discarded.
        /// </param>
        /// <returns>
        /// <see cref="ReclaimResources"/> returns:
        /// <see cref="S_OK"/> if resources were successfully reclaimed
        /// <see cref="E_INVALIDARG"/> if the resources are invalid
        /// </returns>
        /// <remarks>
        /// After you call <see cref="OfferResources"/> to offer one or more resources,
        /// you must call <see cref="ReclaimResources"/> before you can use those resources again.
        /// You must check the values in the array at <paramref name="pDiscarded"/> to determine whether each resource’s content was discarded.
        /// If a resource’s content was discarded while it was offered, its current content is undefined.
        /// Therefore, you must overwrite the resource’s content before you use the resource.
        /// To reclaim shared resources, call <see cref="ReclaimResources"/> only on one of the sharing devices.
        /// To ensure exclusive access to the resources, you must use an <see cref="IDXGIKeyedMutex"/> object
        /// and then call <see cref="ReclaimResources"/> only while you hold the mutex.
        /// Platform Update for Windows 7:
        /// The runtime validates that <see cref="ReclaimResources"/> is used correctly on non-shared resources but doesn't perform the intended functionality.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </remarks>
        public HRESULT ReclaimResources([In] UINT NumResources, [In] P<IDXGIResource>[] ppResources, [Out] BOOL[] pDiscarded)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (P<IDXGIResource>* ppResourcesPtr = ppResources)
                {
                    fixed (BOOL* pDiscardedPtr = pDiscarded)
                    {
                        return ((delegate* unmanaged[Stdcall]<void*, UINT, P<IDXGIResource>*, BOOL[], HRESULT>)_vTable[15])
                        (thisPtr, NumResources, ppResourcesPtr, pDiscarded);
                    }
                }
            }
        }

        /// <summary>
        /// Flushes any outstanding rendering commands and sets the specified event object
        /// to the signaled state after all previously submitted rendering commands complete.
        /// </summary>
        /// <param name="hEvent">
        /// A handle to the event object.
        /// The <see cref="CreateEvent"/> or <see cref="OpenEvent"/> function returns this handle.
        /// All types of event objects (manual-reset, auto-reset, and so on) are supported.
        /// The handle must have the <see cref="EVENT_MODIFY_STATE"/> access right.
        /// For more information about access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following values:
        /// <see cref="E_OUTOFMEMORY"/> if insufficient memory is available to complete the operation.
        /// <see cref="E_INVALIDARG"/> if the parameter was validated and determined to be incorrect.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed, <see cref="EnqueueSetEvent"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        /// <remarks>
        /// <see cref="EnqueueSetEvent"/> calls the <see cref="SetEvent"/> function on the event object
        /// after all previously submitted rendering commands complete or the device is removed.
        /// After an application calls <see cref="EnqueueSetEvent"/>,
        /// it can immediately call the <see cref="WaitForSingleObject"/> function to put itself to sleep until rendering commands complete.
        /// You cannot use <see cref="EnqueueSetEvent"/> to determine work completion that is associated with presentation (<see cref="IDXGISwapChain.Present"/>);
        /// instead, we recommend that you use <see cref="IDXGISwapChain.GetFrameStatistics"/>.
        /// </remarks>
        public HRESULT EnqueueSetEvent([In] HANDLE hEvent)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, HRESULT>)_vTable[16])(thisPtr, hEvent);
            }
        }
    }
}
