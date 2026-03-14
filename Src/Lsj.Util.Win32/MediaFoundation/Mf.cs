using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.MediaFoundation.GUIDs.MediaFoundationAttributes;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.MediaFoundation
{
    /// <summary>
    /// Mf.dll
    /// </summary>
    public static class Mf
    {
        /// <summary>
        /// <para>
        /// Queries an object for a specified service interface.
        /// </para>
        /// <para>
        /// This function is a helper function that wraps the <see cref="IMFGetService.GetService"/> method.
        /// The function queries the object for the <see cref="IMFGetService"/> interface and,
        /// if successful, calls <see cref="IMFGetService.GetService"/> on the object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfidl/nf-mfidl-mfgetservice"/>
        /// </para>
        /// </summary>
        /// <param name="punkObject">
        /// A pointer to the <see cref="IUnknown"/> interface of the object to query.
        /// </param>
        /// <param name="guidService">
        /// The service identifier (SID) of the service.
        /// For a list of service identifiers, see Service Interfaces.
        /// </param>
        /// <param name="riid">
        /// The interface identifier (IID) of the interface being requested.
        /// </param>
        /// <param name="ppvObject">
        /// Receives the interface pointer. The caller must release the interface.
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
        /// <see cref="MF_E_UNSUPPORTED_SERVICE"/>
        /// </term>
        /// <term>
        /// The service requested cannot be found in the object represented by <paramref name="punkObject"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Mf.dll", CharSet = CharSet.Unicode, EntryPoint = "MFGetService", ExactSpelling = true)]
        public static extern HRESULT MFGetService(
#if NETFRAMEWORK
            [In] nint punkObject,
#else
            [In] P<IUnknown> punkObject,
#endif
            [In] in GUID guidService, [In] in IID riid, [Out] out LPVOID ppvObject);

        /// <summary>
        /// <para>
        /// Enumerates a list of audio or video capture devices.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfidl/nf-mfidl-mfenumdevicesources"/>
        /// </para>
        /// </summary>
        /// <param name="pAttributes">
        /// <para>
        /// Pointer to an attribute store that contains search criteria.
        /// To create the attribute store, call <see cref="MFCreateAttributes"/>.
        /// Set one or more of the following attributes on the attribute store:
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
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE"/>
        /// </term>
        /// <term>
        /// Specifies whether to enumerate audio or video devices. (Required.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_AUDCAP_ROLE"/>
        /// </term>
        /// <term>
        /// For audio capture devices, specifies the device role. (Optional.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_CATEGORY"/>
        /// </term>
        /// <term>
        /// For video capture devices, specifies the device category. (Optional.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pppSourceActivate">
        /// Receives an array of <see cref="IMFActivate"/> interface pointers.
        /// Each pointer represents an activation object for a media source.
        /// The function allocates the memory for the array.
        /// The caller must release the pointers in the array and call <see cref="CoTaskMemFree"/> to free the memory for the array.
        /// </param>
        /// <param name="pcSourceActivate">
        /// Receives the number of elements in the <paramref name="pppSourceActivate"/> array.
        /// If no capture devices match the search criteria, this parameter receives the value 0.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Each returned <see cref="IMFActivate"/> pointer represents a capture device,
        /// and can be used to create a media source for that device.
        /// You can also use the <see cref="IMFActivate"/> pointer to query for attributes that describe the device.
        /// The following attributes might be set:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_FRIENDLY_NAME"/>
        /// </term>
        /// <term>
        /// The display name of the device.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_MEDIA_TYPE"/>
        /// </term>
        /// <term>
        /// The major type and subtype GUIDs that describe the device's output format.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE"/>
        /// </term>
        /// <term>
        /// The type of capture device (audio or video).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_AUDCAP_ENDPOINT_ID"/>
        /// </term>
        /// <term>
        /// The audio endpoint ID string. (Audio devices only.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_CATEGORY"/>
        /// </term>
        /// <term>
        /// The device category. (Video devices only.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_HW_SOURCE"/>
        /// </term>
        /// <term>
        /// Whether a device is a hardware or software device. (Video devices only.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_SYMBOLIC_LINK"/>
        /// </term>
        /// <term>
        /// The symbolic link for the device driver. (Video devices only.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To create a media source from an <see cref="IMFActivate"/> pointer,
        /// call the <see cref="IMFActivate.ActivateObject"/> method.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("Mf.dll", CharSet = CharSet.Unicode, EntryPoint = "MFEnumDeviceSources", ExactSpelling = true)]
        public static extern HRESULT MFEnumDeviceSources(
#if NETFRAMEWORK
            [In] nint pAttributes,
#else
            [In] P<IMFAttributes> pAttributes,
#endif
            [Out] out P<P<IMFActivate>> pppSourceActivate, [Out] out UINT32 pcSourceActivate);
    }
}
