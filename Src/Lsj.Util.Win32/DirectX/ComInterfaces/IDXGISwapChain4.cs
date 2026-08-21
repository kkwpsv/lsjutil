using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface exposes a single method for setting video metadata.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_5/nn-dxgi1_5-idxgiswapchain4"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "3D585D5A-BD4A-489E-B1F4-3DBCB6452FFB", BeginVTableSlotIndex = 39, EndVTableSlotIndex = 39,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIDeviceSubObject), typeof(IDXGISwapChain),
            typeof(IDXGISwapChain1), typeof(IDXGISwapChain2), typeof(IDXGISwapChain3)])]
    public unsafe struct IDXGISwapChain4
    {
        nint* _vTable;

        /// <summary>
        /// This method sets High Dynamic Range (HDR) and Wide Color Gamut (WCG) header metadata.
        /// </summary>
        /// <param name="Type">
        /// Specifies one member of the <see cref="DXGI_HDR_METADATA_TYPE"/> enum.
        /// </param>
        /// <param name="Size">
        /// Specifies the size of <paramref name="pMetaData"/>, in bytes.
        /// </param>
        /// <param name="pMetaData">
        /// Specifies a void pointer that references the metadata, if it exists.
        /// Refer to the <see cref="DXGI_HDR_METADATA_HDR10"/> structure.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method sets metadata to enable a monitor's output to be adjusted depending on its capabilities.
        /// However it does not change how pixel values are interpreted by Windows or monitors.
        /// To adjust the color space of the swap chain, use <see cref="IDXGISwapChain3.SetColorSpace1"/> instead.
        /// </para>
        /// <para>
        /// Applications should not rely on the metadata being sent to the monitor as the metadata may be ignored.
        /// Monitors do not consistently process HDR metadata,
        /// resulting in varied appearance of your content across different monitors.
        /// In order to ensure more consistent output across a range of monitors, devices, and use cases,
        /// it is recommended to not use <see cref="SetHDRMetaData"/> and to instead tone-map content
        /// into the gamut and luminance range supported by the monitor.
        /// See <see cref="IDXGIOutput6.GetDesc1"/> to retrieve the monitor's supported gamut and luminance range.
        /// Monitors adhering to the VESA DisplayHDR standard will automatically
        /// perform a form of clipping for content outside of the monitor's supported gamut and luminance range.
        /// </para>
        /// <para>
        /// For more details on how to write apps that react dynamically to monitor capabilities,
        /// see Using DirectX with high dynamic range displays and Advanced Color.
        /// </para>
        /// </remarks>
        [Obsolete("It is no longer recommended for apps to explicitly set HDR metadata on their swap chain using SetHDRMetaData. " +
            "Windows does not guarantee that swap chain metadata is sent to the monitor, and monitors do not handle HDR metadata consistently. " +
            "Therefore it's recommended that apps always tone-map content into the range reported by the monitor. " +
            "For more details on how to write apps that react dynamically to monitor capabilities, see Using DirectX with high dynamic range displays and Advanced Color." +
            "See Remarks for more details.")]
        public HRESULT SetHDRMetaData([In] DXGI_HDR_METADATA_TYPE Type, [In] UINT Size, [In] nint pMetaData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_HDR_METADATA_TYPE, UINT, nint, HRESULT>)_vTable[39])(thisPtr, Type, Size, pMetaData);
            }
        }
    }
}
