using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.DXGI;
using static Lsj.Util.Win32.DirectX.Enums.D3D_DRIVER_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BIND_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_PRESENT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Creates swap chains for desktop media apps that use DirectComposition surfaces to decode and display video.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nn-dxgi1_3-idxgifactorymedia"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To create a Microsoft DirectX Graphics Infrastructure (DXGI) media factory interface,
    /// pass <see cref="IDXGIFactoryMedia"/> into either the <see cref="CreateDXGIFactory"/>
    /// or <see cref="CreateDXGIFactory1"/> function or call <see cref="IUnknown.QueryInterface"/> from a factory object
    /// returned by <see cref="CreateDXGIFactory"/>, <see cref="CreateDXGIFactory1"/>, or <see cref="CreateDXGIFactory2"/>.
    /// </para>
    /// <para>
    /// Because you can create a Direct3D device without creating a swap chain,
    /// you might need to retrieve the factory that is used to create the device in order to create a swap chain.
    /// You can request the <see cref="IDXGIDevice"/>, <see cref="IDXGIDevice1"/>, <see cref="IDXGIDevice2"/>,
    /// or <see cref="IDXGIDevice3"/> interface from the Direct3D device
    /// and then use the <see cref="IDXGIObject.GetParent"/> method to locate the factory.
    /// The following code shows how.
    /// </para>
    /// <code>
    /// IDXGIDevice2 * pDXGIDevice;
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice2), (void**)&amp;pDXGIDevice);
    /// 
    /// IDXGIAdapter * pDXGIAdapter;
    /// hr = pDXGIDevice->GetParent(__uuidof(IDXGIAdapter), (void **)&amp;pDXGIAdapter);
    /// 
    /// IDXGIFactoryMedia * pIDXGIFactory;
    /// pDXGIAdapter->GetParent(__uuidof(IDXGIFactoryMedia), (void **)&amp;pIDXGIFactory);
    /// </code>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
    [ComInterface(IID = "41e7d1f2-a591-4f7b-a2e5-fa9c843e1c12", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 4, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDXGIFactoryMedia
    {
        IntPtr* _vTable;

        /// <summary>
        /// Creates a YUV swap chain for an existing DirectComposition surface handle.
        /// </summary>
        /// <param name="pDevice">
        /// A pointer to the Direct3D device for the swap chain.
        /// This parameter cannot be <see cref="NULL"/>.
        /// Software drivers, like <see cref="D3D_DRIVER_TYPE_REFERENCE"/>,
        /// are not supported for composition swap chains.
        /// </param>
        /// <param name="hSurface">
        /// A handle to an existing DirectComposition surface.
        /// This parameter cannot be <see cref="NULL"/>.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_SWAP_CHAIN_DESC1"/> structure for the swap-chain description.
        /// This parameter cannot be <see cref="NullRef{DXGI_SWAP_CHAIN_DESC1}"/>.
        /// </param>
        /// <param name="pRestrictToOutput">
        /// <para>
        /// A pointer to the <see cref="IDXGIOutput"/> interface for the swap chain to restrict content to.
        /// If the swap chain is moved to a different output, the content is black.
        /// You can optionally set this parameter to an output target
        /// that uses <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> to restrict the content on this output.
        /// If the swap chain is moved to a different output, the content is black.
        /// </para>
        /// <para>
        /// You must also pass the <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> flag
        /// in a present call to force the content to appear blacked out on any other output.
        /// If you want to restrict the content to a different output, you must create a new swap chain.
        /// However, you can conditionally restrict content
        /// based on the <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> flag.
        /// </para>
        /// <para>
        /// Set this parameter to <see cref="NULL"/> if you don't want to restrict content to an output target.
        /// </para>
        /// </param>
        /// <param name="ppSwapChain">
        /// A pointer to a variable that receives a pointer to the <see cref="IDXGISwapChain1"/> interface
        /// for the swap chain that this method creates.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="CreateSwapChainForCompositionSurfaceHandle"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully created a swap chain.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_OUTOFMEMORY"/> if memory is unavailable to complete the operation.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the calling application provided invalid data,
        /// for example, if <paramref name="pDesc"/>, pYuvDecodeBuffers, or <paramref name="ppSwapChain"/> is <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic
        /// that are defined by the type of device that you pass to <paramref name="pDevice"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT CreateSwapChainForCompositionSurfaceHandle([In] P<IUnknown> pDevice, [In] HANDLE hSurface, [In] in DXGI_SWAP_CHAIN_DESC1 pDesc,
            [In] P<IDXGIOutput> pRestrictToOutput, [Out] out P<IDXGISwapChain1> ppSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>, HANDLE, in DXGI_SWAP_CHAIN_DESC1, P<IDXGIOutput>, out P<IDXGISwapChain1>, HRESULT>)_vTable[3])
                    (thisPtr, pDevice, hSurface, pDesc, pRestrictToOutput, out ppSwapChain);
            }
        }

        /// <summary>
        /// Creates a YUV swap chain for an existing DirectComposition surface handle.
        /// The swap chain is created with pre-existing buffers and very few descriptive elements are required.
        /// Instead, this method requires a DirectComposition surface handle
        /// and an <see cref="IDXGIResource"/> buffer to hold decoded frame data.
        /// The swap chain format is determined by the format of the subresources of the <see cref="IDXGIResource"/>.
        /// </summary>
        /// <param name="pDevice">
        /// A pointer to the Direct3D device for the swap chain.
        /// This parameter cannot be <see cref="NULL"/>.
        /// Software drivers, like <see cref="D3D_DRIVER_TYPE_REFERENCE"/>, are not supported for composition swap chains.
        /// </param>
        /// <param name="hSurface">
        /// A handle to an existing DirectComposition surface.
        /// This parameter cannot be <see cref="NULL"/>.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_DECODE_SWAP_CHAIN_DESC"/> structure for the swap-chain description.
        /// This parameter cannot be <see cref="NullRef{DXGI_DECODE_SWAP_CHAIN_DESC}"/>.
        /// </param>
        /// <param name="pYuvDecodeBuffers">
        /// A pointer to a <see cref="IDXGIResource"/> interface that represents the resource
        /// that contains the info that <see cref="CreateDecodeSwapChainForCompositionSurfaceHandle"/> decodes.
        /// </param>
        /// <param name="pRestrictToOutput">
        /// <para>
        /// A pointer to the <see cref="IDXGIOutput"/> interface for the swap chain to restrict content to.
        /// If the swap chain is moved to a different output, the content is black.
        /// You can optionally set this parameter to an output target
        /// that uses <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> to restrict the content on this output.
        /// If the swap chain is moved to a different output, the content is black.
        /// </para>
        /// <para>
        /// You must also pass the <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> flag
        /// in a present call to force the content to appear blacked out on any other output.
        /// If you want to restrict the content to a different output, you must create a new swap chain.
        /// However, you can conditionally restrict content based on the <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> flag.
        /// </para>
        /// <para>
        /// Set this parameter to <see cref="NULL"/> if you don't want to restrict content to an output target.
        /// </para>
        /// </param>
        /// <param name="ppSwapChain">
        /// A pointer to a variable that receives a pointer to the <see cref="IDXGIDecodeSwapChain"/> interface
        /// for the swap chain that this method creates.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="CreateDecodeSwapChainForCompositionSurfaceHandle"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully created a swap chain.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_OUTOFMEMORY"/> if memory is unavailable to complete the operation.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the calling application provided invalid data,
        /// for example, if <paramref name="pDesc"/>, <paramref name="pYuvDecodeBuffers"/>,
        /// or <paramref name="ppSwapChain"/> is <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic
        /// that are defined by the type of device that you pass to <paramref name="pDevice"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="IDXGIResource"/> provided via the <paramref name="pYuvDecodeBuffers"/> parameter
        /// must point to at least one subresource,
        /// and all subresources must be created with the <see cref="D3D11_BIND_DECODER"/> flag.
        /// </remarks>
        public HRESULT CreateDecodeSwapChainForCompositionSurfaceHandle([In] P<IUnknown> pDevice, [In] HANDLE hSurface, [In] in DXGI_DECODE_SWAP_CHAIN_DESC pDesc,
            [In] P<IDXGIResource> pYuvDecodeBuffers, [In] P<IDXGIOutput> pRestrictToOutput, [Out] out P<IDXGIDecodeSwapChain> ppSwapChain)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>, HANDLE, in DXGI_DECODE_SWAP_CHAIN_DESC,
                    P<IDXGIResource>, P<IDXGIOutput>, out P<IDXGIDecodeSwapChain>, HRESULT>)_vTable[4])
                    (thisPtr, pDevice, hSurface, pDesc, pYuvDecodeBuffers, pRestrictToOutput, out ppSwapChain);
            }
        }
    }
}
