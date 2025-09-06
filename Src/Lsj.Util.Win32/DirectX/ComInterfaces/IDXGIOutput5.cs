using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.Enums.EventConstants;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents an adapter output (such as a monitor).
    /// The <see cref="IDXGIOutput5"/> interface exposes a single method
    /// to specify a list of supported formats for fullscreen surfaces.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_5/nn-dxgi1_5-idxgioutput5"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10)]
    [ComInterface(IID = "80A07424-AB52-42EB-833C-0C42FD282D98", BeginVTableSlotIndex = 26, EndVTableSlotIndex = 26,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIOutput), typeof(IDXGIOutput1),
            typeof(IDXGIOutput2), typeof(IDXGIOutput3), typeof(IDXGIOutput4)])]
    public unsafe struct IDXGIOutput5
    {
        IntPtr* _vTable;

        /// <summary>
        /// Allows specifying a list of supported formats for fullscreen surfaces
        /// that can be returned by the <see cref="IDXGIOutputDuplication"/> object.
        /// </summary>
        /// <param name="pDevice">
        /// A pointer to the Direct3D device interface that you can use to process the desktop image.
        /// This device must be created from the adapter to which the output is connected.
        /// </param>
        /// <param name="Flags">
        /// Reserved for future use; must be zero.
        /// </param>
        /// <param name="SupportedFormatsCount">
        /// Specifies the number of supported formats.
        /// </param>
        /// <param name="pSupportedFormats">
        /// Specifies an array, of length <paramref name="SupportedFormatsCount"/> of <see cref="DXGI_FORMAT"/> entries.
        /// </param>
        /// <param name="ppOutputDuplication">
        /// A pointer to a variable that receives the new <see cref="IDXGIOutputDuplication"/> interface.
        /// </param>
        /// <returns>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if <see cref="DuplicateOutput1"/> successfully created the desktop duplication interface.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="E_INVALIDARG"/> for one of the following reasons:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The specified device (<paramref name="pDevice"/>) is invalid, was not created on the correct adapter,
        /// or was not created from <see cref="IDXGIFactory1"/>
        /// (or a later version of a DXGI factory interface that inherits from <see cref="IDXGIFactory1"/>).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The calling application is already duplicating this desktop output.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_ACCESSDENIED"/> if the application does not have access privilege to the current desktop image.
        /// For example, only an application that runs at LOCAL_SYSTEM can access the secure desktop.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="DXGI_ERROR_UNSUPPORTED"/> if the created <see cref="IDXGIOutputDuplication"/> interface
        /// does not support the current desktop mode or scenario.
        /// For example, 8bpp and non-DWM desktop modes are not supported.
        /// </para>
        /// <para>
        /// If <see cref="DuplicateOutput1"/> fails with <see cref="DXGI_ERROR_UNSUPPORTED"/>,
        /// the application can wait for system notification of desktop switches
        /// and mode changes and then call <see cref="DuplicateOutput1"/> again after such a notification occurs.
        /// For more information, see the desktop switch (<see cref="EVENT_SYSTEM_DESKTOPSWITCH"/>)
        /// and mode change notification (<see cref="WM_DISPLAYCHANGE"/>).
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/> if DXGI reached
        /// the limit on the maximum number of concurrent duplication applications (default of four).
        /// Therefore, the calling application cannot create any desktop duplication interfaces until the other applications close.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_SESSION_DISCONNECTED"/> if <see cref="DuplicateOutput1"/> failed
        /// because the session is currently disconnected.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Other error codes are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method allows directly receiving the original back buffer format used by a running fullscreen application.
        /// For comparison, using the original <see cref="IDXGIOutput1.DuplicateOutput"/> function
        /// always converts the fullscreen surface to a 32-bit BGRA format.
        /// In cases where the current fullscreen application is using a different buffer format,
        /// a conversion to 32-bit BGRA incurs a performance penalty.
        /// Besides the performance benefit of being able to skip format conversion,
        /// using <see cref="DuplicateOutput1"/> also allows receiving the full gamut of colors
        /// in cases where a high-color format (such as R10G10B10A2) is being presented.
        /// </para>
        /// <para>
        /// The <paramref name="pSupportedFormats"/> array should only contain display scan-out formats.
        /// See Format Support for Direct3D Feature Level 11.0 Hardware for required scan-out formats at each feature level.
        /// If the current fullscreen buffer format is not contained in the <paramref name="pSupportedFormats"/> array,
        /// DXGI will pick one of the supplied formats and convert the fullscreen buffer
        /// to that format before returning from <see cref="IDXGIOutputDuplication.AcquireNextFrame"/>.
        /// The list of supported formats should always contain <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>,
        /// as this is the most common format for the desktop.
        /// </para>
        /// </remarks>
        public HRESULT DuplicateOutput1([In] P<IUnknown> pDevice, [In] UINT Flags, [In] UINT SupportedFormatsCount,
            [In] DXGI_FORMAT[] pSupportedFormats, [Out] out P<IDXGIOutputDuplication> ppOutputDuplication)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (DXGI_FORMAT* pSupportedFormatsPtr = pSupportedFormats)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>, UINT, UINT, DXGI_FORMAT*, out P<IDXGIOutputDuplication>, HRESULT>)_vTable[26])
                        (thisPtr, pDevice, Flags, SupportedFormatsCount, pSupportedFormatsPtr, out ppOutputDuplication);
                }
            }
        }
    }
}
