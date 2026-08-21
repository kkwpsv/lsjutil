using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_OFFER_RESOURCE_FLAGS;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface provides updated methods to offer and reclaim resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_5/nn-dxgi1_5-idxgidevice4"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The Direct3D create device functions return a Direct3D device object.
    /// This Direct3D device object implements the <see cref="IUnknown"/> interface.
    /// You can query this Direct3D device object for the device's corresponding <see cref="IDXGIDevice4"/> interface.
    /// To retrieve the <see cref="IDXGIDevice4"/> interface of a Direct3D device, use the following code:
    /// </para>
    /// <code>
    /// IDXGIDevice4 * pDXGIDevice;
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice4), (void**)&amp;pDXGIDevice);
    /// </code>
    /// </remarks>
    [ComInterface(IID = "95B4F95F-D8DA-4CA4-9EE6-3B76D5968A10", BeginVTableSlotIndex = 18, EndVTableSlotIndex = 19,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIDevice), typeof(IDXGIDevice1), typeof(IDXGIDevice2), typeof(IDXGIDevice3)])]
    public unsafe struct IDXGIDevice4
    {
        nint* _vTable;

        /// <summary>
        /// Allows the operating system to free the video memory of resources,
        /// including both discarding the content and de-committing the memory.
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
        /// <param name="Flags">
        /// Specifies the <see cref="DXGI_OFFER_RESOURCE_FLAGS"/>.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code,
        /// which can include <see cref="E_INVALIDARG"/> if a resource in the array, or the priority, is invalid.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="OfferResources1"/> (an extension of the original <see cref="IDXGIDevice2.OfferResources"/> API)
        /// enables D3D based applications to allow de-committing of an allocation’s backing store
        /// to reduce system commit under low memory conditions.
        /// A de-committed allocation cannot be reused,
        /// so opting in to the new <see cref="DXGI_OFFER_RESOURCE_FLAG_ALLOW_DECOMMIT"/> flag
        /// means the new reclaim results must be properly handled.
        /// Refer to the flag descriptions in <see cref="DXGI_RECLAIM_RESOURCE_RESULTS"/> and the Example below.
        /// </para>
        /// <para>
        /// <see cref="OfferResources1"/> and <see cref="ReclaimResources1"/>
        /// may not be used interchangeably with <see cref="IDXGIDevice2.OfferResources"/> and <see cref="IDXGIDevice2.ReclaimResources"/>.
        /// </para>
        /// <para>
        /// The priority value that the <paramref name="Priority"/> parameter specifies describes
        /// how valuable the caller considers the content to be.
        /// The operating system uses the priority value to discard resources in order of priority.
        /// The operating system discards a resource that is offered with low priority
        /// before it discards a resource that is offered with a higher priority.
        /// </para>
        /// <para>
        /// If you call <see cref="OfferResources1"/> to offer a resource
        /// while the resource is bound to the pipeline, the resource is unbound.
        /// You cannot call <see cref="OfferResources1"/> on a resource that is mapped.
        /// After you offer a resource, the resource cannot be mapped or bound to the pipeline
        /// until you call the <see cref="ReclaimResources1"/> method to reclaim the resource.
        /// You cannot call <see cref="OfferResources1"/> to offer immutable resources.
        /// </para>
        /// <para>
        /// To offer shared resources, call <see cref="OfferResources1"/> on only one of the sharing devices.
        /// To ensure exclusive access to the resources,
        /// you must use an <see cref="IDXGIKeyedMutex"/> object and then call <see cref="OfferResources1"/>
        /// only while you hold the mutex.
        /// In fact, you can't offer shared resources unless you use <see cref="IDXGIKeyedMutex"/>
        /// because offering shared resources without using <see cref="IDXGIKeyedMutex"/> isn't supported.
        /// </para>
        /// <para>
        /// The user mode display driver might not immediately offer the resources
        /// that you specified in a call to <see cref="OfferResources1"/>.
        /// The driver can postpone offering them until the next call to <see cref="IDXGISwapChain.Present"/>,
        /// <see cref="IDXGISwapChain1.Present1"/>, or <see cref="ID3D11DeviceContext.Flush"/>.
        /// </para>
        /// </remarks>
        public HRESULT OfferResources1([In] UINT NumResources, [In] P<IDXGIResource>[] ppResources, [In] DXGI_OFFER_RESOURCE_PRIORITY Priority,
            [In] DXGI_OFFER_RESOURCE_FLAGS Flags)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (P<IDXGIResource>* ppResourcesPtr = ppResources)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, UINT, P<IDXGIResource>*, DXGI_OFFER_RESOURCE_PRIORITY, DXGI_OFFER_RESOURCE_FLAGS, HRESULT>)_vTable[18])
                        (thisPtr, NumResources, ppResourcesPtr, Priority, Flags);
                }
            }
        }

        /// <summary>
        /// Restores access to resources that were previously offered by calling <see cref="OfferResources1"/>.
        /// </summary>
        /// <param name="NumResources">
        /// The number of resources in the <paramref name="ppResources"/> argument and <paramref name="pResults"/> argument arrays.
        /// </param>
        /// <param name="ppResources">
        /// An array of pointers to <see cref="IDXGIResource"/> interfaces for the resources to reclaim.
        /// </param>
        /// <param name="pResults">
        /// A pointer to an array that receives <see cref="DXGI_RECLAIM_RESOURCE_RESULTS"/> values.
        /// Each value in the array corresponds to a resource at the same index
        /// that the <paramref name="ppResources"/> parameter specifies.
        /// The caller can pass in <see langword="null"/>, if the caller intends to fill the resources with new content
        /// regardless of whether the old content was discarded.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code,
        /// including <see cref="E_INVALIDARG"/> if the resources are invalid.
        /// </returns>
        /// <remarks>
        /// <para>
        /// After you call <see cref="OfferResources1"/> to offer one or more resources,
        /// you must call <see cref="ReclaimResources1"/> before you can use those resources again.
        /// </para>
        /// <para>
        /// To reclaim shared resources, call <see cref="ReclaimResources1"/> only on one of the sharing devices.
        /// To ensure exclusive access to the resources,
        /// you must use an <see cref="IDXGIKeyedMutex"/> object
        /// and then call <see cref="ReclaimResources1"/> only while you hold the mutex.
        /// </para>
        /// </remarks>
        public HRESULT ReclaimResources1([In] UINT NumResources, [In] P<IDXGIResource>[] ppResources, [Out] DXGI_RECLAIM_RESOURCE_RESULTS[] pResults)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (P<IDXGIResource>* ppResourcesPtr = ppResources)
                {
                    fixed (DXGI_RECLAIM_RESOURCE_RESULTS* pResultsPtr = pResults)
                    {
                        return ((delegate* unmanaged[Stdcall]<void*, UINT, P<IDXGIResource>*, DXGI_RECLAIM_RESOURCE_RESULTS*, HRESULT>)_vTable[19])
                        (thisPtr, NumResources, ppResourcesPtr, pResultsPtr);
                    }
                }
            }
        }
    }
}
