using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.MediaFoundation.Constants;
using static Lsj.Util.Win32.MediaFoundation.Enums.MediaFoundationStartupFlags;
using static Lsj.Util.Win32.DirectX.D3D11;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_CREATE_DEVICE_FLAG;

namespace Lsj.Util.Win32.MediaFoundation
{
    /// <summary>
    /// Mfplat.dll
    /// </summary>
    public static class Mfplat
    {
        /// <summary>
        /// <para>
        /// Creates an empty attribute store.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfapi/nf-mfapi-mfcreateattributes"/>
        /// </para>
        /// </summary>
        /// <param name="ppMFAttributes">
        /// Receives a pointer to the <see cref="IMFAttributes"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <param name="cInitialSize">
        /// The initial number of elements allocated for the attribute store.
        /// The attribute store grows as needed.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Attributes are used throughout Microsoft Media Foundation to configure objects,
        /// describe media formats, query object properties, and other purposes.
        /// For more information, see Attributes in Media Foundation.
        /// </para>
        /// <para>
        /// For a complete list of all the defined attribute GUIDs in Media Foundation, see Media Foundation Attributes.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Mfplat.dll", CharSet = CharSet.Unicode, EntryPoint = "MFCreateAttributes", ExactSpelling = true)]
        public static extern HRESULT MFCreateAttributes([Out] out P<IMFAttributes> ppMFAttributes, [In] UINT32 cInitialSize);

        /// <summary>
        /// <para>
        /// Creates an instance of the Microsoft DirectX Graphics Infrastructure (DXGI) Device Manager.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfapi/nf-mfapi-mfcreatedxgidevicemanager"/>
        /// </para>
        /// </summary>
        /// <param name="resetToken">
        /// Receives a token that identifies this instance of the DXGI Device Manager.
        /// Use this token when calling <see cref="IMFDXGIDeviceManager.ResetDevice"/>.
        /// </param>
        /// <param name="ppDeviceManager">
        /// Receives a pointer to the <see cref="IMFDXGIDeviceManager"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// When you create an <see cref="IMFDXGIDeviceManager"/> with <see cref="MFCreateDXGIDeviceManager"/>,
        /// a Microsoft Direct3D 11 device is not associated with the device manager.
        /// To associate a Direct3D 11 device with the device manager,
        /// call <see cref="IMFDXGIDeviceManager.ResetDevice"/>, passing in the pointer to the Direct3D 11 device.
        /// To create a Direct3D 11 device, call <see cref="D3D11CreateDevice"/>.
        /// The device should be created with the <see cref="D3D11_CREATE_DEVICE_VIDEO_SUPPORT"/> device creation flag
        /// which is defined in the <see cref="D3D11_CREATE_DEVICE_FLAG"/> enumeration.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("Mfplat.dll", CharSet = CharSet.Unicode, EntryPoint = "MFCreateDXGIDeviceManager", ExactSpelling = true)]
        public static extern HRESULT MFCreateDXGIDeviceManager([Out] out UINT resetToken, [Out] out P<IMFDXGIDeviceManager> ppDeviceManager);

        /// <summary>
        /// <para>
        /// Initializes Microsoft Media Foundation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfapi/nf-mfapi-mfstartup"/>
        /// </para>
        /// </summary>
        /// <param name="Version">
        /// Version number.
        /// Use the value <see cref="MF_VERSION"/>, defined in mfapi.h.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// This parameter is optional when using C++ but required in C. The value must be one of the following flags:
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
        /// <see cref="MFSTARTUP_NOSOCKET"/>
        /// </term>
        /// <term>
        /// Do not initialize the sockets library.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MFSTARTUP_LITE"/>
        /// </term>
        /// <term>
        /// Equivalent to <see cref="MFSTARTUP_NOSOCKET"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MFSTARTUP_FULL"/>
        /// </term>
        /// <term>
        /// Initialize the entire Media Foundation platform. This is the default value when <paramref name="dwFlags"/> is not specified.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// The function returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_BAD_STARTUP_VERSION"/>
        /// </term>
        /// <term>
        /// The <paramref name="Version"/> parameter requires a newer version of Media Foundation than the version that is running.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_DISABLED_IN_SAFEMODE"/>
        /// </term>
        /// <term>
        /// The Media Foundation platform is disabled because the system was started in "Safe Mode" (fail-safe boot).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_NOTIMPL"/>
        /// </term>
        /// <term>
        /// Media Foundation is not implemented on the system.
        /// This error can occur if the media components are not present (See KB2703761 for more info).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application must call this function before using Media Foundation.
        /// Before your application quits, call <see cref="MFShutdown"/> once for every previous call to <see cref="MFStartup"/>.
        /// </para>
        /// <para>
        /// <see cref="MFStartup"/> should be called during should be called during app initialization
        /// and not from static constructors during process initialization.
        /// </para>
        /// <para>
        /// Do not call <see cref="MFStartup"/> or <see cref="MFShutdown"/> from work queue threads.
        /// For more information about work queues, see Work Queues.
        /// </para>
        /// <para>
        /// This function is available on the following platforms
        /// if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Mfplat.dll", CharSet = CharSet.Unicode, EntryPoint = "MFStartup", ExactSpelling = true)]
        public static extern HRESULT MFStartup([In] ULONG Version, [In] MediaFoundationStartupFlags dwFlags);
    }
}
