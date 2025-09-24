using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ConfigurationManagerDeviceCapabilityFlags;
using static Lsj.Util.Win32.Enums.RegistryValueTypes;
using static Lsj.Util.Win32.Enums.SetupDeviceRegistryProperties;
using static Lsj.Util.Win32.Enums.SetupDiGetClassDevsFlags;
using static Lsj.Util.Win32.Enums.SetupDiOpenDeviceInfoFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// SetupAPI.dll
    /// </summary>
    public static class SetupAPI
    {
        /// <summary>
        /// <para>
        /// The <see cref="SetupDiDestroyDeviceInfoList"/> function deletes a device information set and frees all associated memory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdidestroydeviceinfolist"/>
        /// </para>
        /// </summary>
        /// <param name="DeviceInfoSet">
        /// A handle to the device information set to delete.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> if it is successful.
        /// Otherwise, it returns <see cref="FALSE"/> and the logged error can be retrieved with a call to <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiDestroyDeviceInfoList", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiDestroyDeviceInfoList([In] HDEVINFO DeviceInfoSet);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiGetClassDevs"/> function returns a handle to a device information set
        /// that contains requested device information elements for a local computer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevsw"/>
        /// </para>
        /// </summary>
        /// <param name="ClassGuid">
        /// A pointer to the <see cref="GUID"/> for a device setup class or a device interface class.
        /// This pointer is optional and can be <see cref="NullRef{GUID}"/>.
        /// For more information about how to set <paramref name="ClassGuid"/>, see the following Remarks section.
        /// </param>
        /// <param name="Enumerator">
        /// <para>
        /// A pointer to a <see cref="NULL"/>-terminated string that specifies:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// An identifier (ID) of a Plug and Play (PnP) enumerator.
        /// This ID can either be the value's globally unique identifier (GUID) or symbolic name.
        /// For example, "PCI" can be used to specify the PCI PnP value.
        /// Other examples of symbolic names for PnP values include "USB," "PCMCIA," and "SCSI".
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A PnP device instance ID.
        /// When specifying a PnP device instance ID, <see cref="DIGCF_DEVICEINTERFACE"/> must be set in the <paramref name="Flags"/> parameter.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This pointer is optional and can be <see cref="NULL"/>.
        /// If an enumeration value is not used to select devices, set <paramref name="Enumerator"/> to <see cref="NULL"/>
        /// </para>
        /// <para>
        /// For more information about how to set the <paramref name="Enumerator"/> value, see the following Remarks section.
        /// </para>
        /// </param>
        /// <param name="hwndParent">
        /// A handle to the top-level window to be used for a user interface
        /// that is associated with installing a device instance in the device information set.
        /// This handle is optional and can be <see cref="NULL"/>.
        /// </param>
        /// <param name="Flags">
        /// <para>
        /// A variable of type <see cref="DWORD"/> that specifies control options
        /// that filter the device information elements that are added to the device information set.
        /// This parameter can be a bitwise OR of zero or more of the following flags.
        /// For more information about combining these flags, see the following Remarks section.
        /// </para>
        /// <para>
        /// <see cref="DIGCF_ALLCLASSES"/>
        /// </para>
        /// <para>
        /// Return a list of installed devices for all device setup classes or all device interface classes.
        /// </para>
        /// <para>
        /// <see cref="DIGCF_DEVICEINTERFACE"/>
        /// </para>
        /// <para>
        /// Return devices that support device interfaces for the specified device interface classes.
        /// This flag must be set in the <paramref name="Flags"/> parameter if the <paramref name="Enumerator"/> parameter specifies a device instance ID.
        /// </para>
        /// <para>
        /// <see cref="DIGCF_DEFAULT"/>
        /// </para>
        /// <para>
        /// Return only the device that is associated with the system default device interface, if one is set, for the specified device interface classes.
        /// </para>
        /// <para>
        /// <see cref="DIGCF_PRESENT"/>
        /// </para>
        /// <para>
        /// Return only devices that are currently present in a system.
        /// </para>
        /// <para>
        /// <see cref="DIGCF_PROFILE"/>
        /// </para>
        /// <para>
        /// Return only devices that are a part of the current hardware profile.
        /// </para>
        /// </param>
        /// <returns>
        /// If the operation succeeds, <see cref="SetupDiGetClassDevs"/> returns a handle to a device information set
        /// that contains all installed devices that matched the supplied parameters.
        /// If the operation fails, the function returns <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The caller of <see cref="SetupDiGetClassDevs"/> must delete the returned device information set
        /// when it is no longer needed by calling <see cref="SetupDiDestroyDeviceInfoList"/>.
        /// </para>
        /// <para>
        /// Call <see cref="SetupDiGetClassDevsEx"/> to retrieve the devices for a class on a remote computer.
        /// </para>
        /// <para>
        /// Device Setup Class Control Options
        /// </para>
        /// <para>
        /// Use the following filtering options to control whether <see cref="SetupDiGetClassDevs"/> returns devices
        /// for all device setup classes or only for a specified device setup class:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// To return devices for all device setup classes, set the <see cref="DIGCF_ALLCLASSES"/> flag,
        /// and set the <paramref name="ClassGuid"/> parameter to <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To return devices only for a specific device setup class, do not set <see cref="DIGCF_ALLCLASSES"/>,
        /// and use <paramref name="ClassGuid"/> to supply the GUID of the device setup class.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In addition, you can use the following filtering options in combination with one another to further restrict which devices are returned:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// To return only devices that are present in the system, set the <see cref="DIGCF_PRESENT"/> flag.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To return only devices that are part of the current hardware profile, set the <see cref="DIGCF_PROFILE"/> flag.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To return devices only for a specific PnP enumerator,
        /// use the <paramref name="Enumerator"/> parameter to supply the <see cref="GUID"/> or symbolic name of the enumerator.
        /// If <paramref name="Enumerator"/> is <see cref="NULL"/>, <see cref="SetupDiGetClassDevs"/> returns devices for all PnP enumerators.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Device Interface Class Control Options
        /// </para>
        /// <para>
        /// Use the following filtering options to control whether <see cref="SetupDiGetClassDevs"/> returns devices
        /// that support any device interface class or only devices that support a specified device interface class:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// To return devices that support a device interface of any class, set the <see cref="DIGCF_DEVICEINTERFACE"/> flag,
        /// set the <see cref="DIGCF_ALLCLASSES"/> flag, and set <paramref name="ClassGuid"/> to <see cref="NULL"/>.
        /// The function adds to the device information set a device information element that represents such a device
        /// and then adds to the device information element a device interface list that contains all the device interfaces that the device supports.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To return only devices that support a device interface of a specified class, set the <see cref="DIGCF_DEVICEINTERFACE"/> flag
        /// and use the <paramref name="ClassGuid"/> parameter to supply the class <see cref="GUID"/> of the device interface class.
        /// The function adds to the device information set a device information element that represents such a device
        /// and then adds a device interface of the specified class to the device interface list for that device information element.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In addition, you can use the following filtering options to control
        /// whether <see cref="SetupDiGetClassDevs"/> returns only devices that support the system default interface for device interface classes:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// To return only the device that supports the system default interface, if one is set, for a specified device interface class,
        /// set the <see cref="DIGCF_DEVICEINTERFACE"/> flag, set the <see cref="DIGCF_DEFAULT"/> flag,
        /// and use <paramref name="ClassGuid"/> to supply the class <see cref="GUID"/> of the device interface class.
        /// The function adds to the device information set a device information element that represents such a device
        /// and then adds the system default interface to the device interface list for that device information element.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To return a device that supports a system default interface for an unspecified device interface class,
        /// set the <see cref="DIGCF_DEVICEINTERFACE"/> flag, set the <see cref="DIGCF_ALLCLASSES"/> flag,
        /// set the <see cref="DIGCF_DEFAULT"/> flag, and set <paramref name="ClassGuid"/> to <see cref="NULL"/>.
        /// The function adds to the device information set a device information element that represents such a device
        /// and then adds the system default interface to the device interface list for that device information element.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// You can also use the following options in combination with the other options to further restrict which devices are returned:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// To return only devices that are present in the system, set the <see cref="DIGCF_PRESENT"/> flag.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To return only devices that are part of the current hardware profile, set the <see cref="DIGCF_PROFILE"/> flag.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To return only a specific device, set the <see cref="DIGCF_DEVICEINTERFACE"/> flag
        /// and use the <paramref name="Enumerator"/> parameter to supply the device instance ID of the device.
        /// To include all possible devices, set <paramref name="Enumerator"/> to <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiGetClassDevsW", ExactSpelling = true, SetLastError = true)]
        public static extern HDEVINFO SetupDiGetClassDevs([In] in GUID ClassGuid, [In] LPCWSTR Enumerator,
            [In] HWND hwndParent, [In] SetupDiGetClassDevsFlags Flags);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiEnumDeviceInfo"/> function returns a <see cref="SP_DEVINFO_DATA"/> structure
        /// that specifies a device information element in a device information set.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdienumdeviceinfo"/>
        /// </para>
        /// </summary>
        /// <param name="DeviceInfoSet">
        /// A handle to the device information set for which to return an <see cref="SP_DEVINFO_DATA"/> structure
        /// that represents a device information element.
        /// </param>
        /// <param name="MemberIndex">
        /// A zero-based index of the device information element to retrieve.
        /// </param>
        /// <param name="DeviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure to receive information about an enumerated device information element.
        /// The caller must set <c>DeviceInfoData.cbSize</c> to <c>sizeof(SP_DEVINFO_DATA)</c>.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> if it is successful.
        /// Otherwise, it returns <see cref="FALSE"/> and the logged error can be retrieved with a call to <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Repeated calls to this function return a device information element for a different device.
        /// This function can be called repeatedly to get information about all devices in the device information set.
        /// </para>
        /// <para>
        /// To enumerate device information elements,
        /// an installer should initially call <see cref="SetupDiEnumDeviceInfo"/> with the <paramref name="MemberIndex"/> parameter set to 0.
        /// The installer should then increment <paramref name="MemberIndex"/> and call <see cref="SetupDiEnumDeviceInfo"/>
        /// until there are no more values (the function fails and a call to <see cref="GetLastError"/> returns <see cref="ERROR_NO_MORE_ITEMS"/>).
        /// </para>
        /// <para>
        /// Call <see cref="SetupDiEnumDeviceInterfaces"/> to get a context structure for a device interface (versus a device information element).
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiEnumDeviceInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiEnumDeviceInfo([In] HDEVINFO DeviceInfoSet, [In] DWORD MemberIndex, [In][Out] ref SP_DEVINFO_DATA DeviceInfoData);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiEnumDeviceInterfaces"/> function enumerates the device interfaces that are contained in a device information set.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdienumdeviceinterfaces"/>
        /// </para>
        /// </summary>
        /// <param name="DeviceInfoSet">
        /// A pointer to a device information set that contains the device interfaces for which to return information.
        /// This handle is typically returned by <see cref="SetupDiGetClassDevs"/>.
        /// </param>
        /// <param name="DeviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure that specifies a device information element in <paramref name="DeviceInfoSet"/>.
        /// This parameter is optional and can be <see cref="NullRef{SP_DEVINFO_DATA}"/>.
        /// If this parameter is specified, <see cref="SetupDiEnumDeviceInterfaces"/> constrains
        /// the enumeration to the interfaces that are supported by the specified device.
        /// If this parameter is <see cref="NullRef{SP_DEVINFO_DATA}"/>, repeated calls to <see cref="SetupDiEnumDeviceInterfaces"/>
        /// return information about the interfaces that are associated with all the device information elements in <paramref name="DeviceInfoSet"/>.
        /// This pointer is typically returned by <see cref="SetupDiEnumDeviceInfo"/>.
        /// </param>
        /// <param name="InterfaceClassGuid">
        /// A pointer to a <see cref="GUID"/> that specifies the device interface class for the requested interface.
        /// </param>
        /// <param name="MemberIndex">
        /// <para>
        /// A zero-based index into the list of interfaces in the device information set.
        /// The caller should call this function first with <paramref name="MemberIndex"/> set to zero to obtain the first interface.
        /// Then, repeatedly increment <paramref name="MemberIndex"/> and retrieve an interface
        /// until this function fails and <see cref="GetLastError"/> returns <see cref="ERROR_NO_MORE_ITEMS"/>.
        /// </para>
        /// <para>
        /// If <paramref name="DeviceInfoData"/> specifies a particular device,
        /// the <paramref name="MemberIndex"/> is relative to only the interfaces exposed by that device.
        /// </para>
        /// </param>
        /// <param name="DeviceInterfaceData">
        /// A pointer to a caller-allocated buffer that contains, on successful return,
        /// a completed <see cref="SP_DEVICE_INTERFACE_DATA"/> structure that identifies an interface that meets the search parameters.
        /// The caller must set <c>DeviceInterfaceData.cbSize</c> to <c>sizeof(SP_DEVICE_INTERFACE_DATA)</c> before calling this function.
        /// </param>
        /// <returns>
        /// <see cref="SetupDiEnumDeviceInterfaces"/> returns <see cref="TRUE"/> if the function completed without error.
        /// If the function completed with an error, <see cref="FALSE"/> is returned
        /// and the error code for the failure can be retrieved by calling <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Repeated calls to this function return an <see cref="SP_DEVICE_INTERFACE_DATA"/> structure for a different device interface.
        /// This function can be called repeatedly to get information about interfaces in a device information set
        /// that are associated with a particular device information element or that are associated with all device information elements.
        /// </para>
        /// <para>
        /// <paramref name="DeviceInterfaceData"/> points to a structure that identifies a requested device interface.
        /// To get detailed information about an interface, call <see cref="SetupDiGetDeviceInterfaceDetail"/>.
        /// The detailed information includes the name of the device interface that can be passed to a Win32 function
        /// such as <see cref="CreateFile"/> (described in Microsoft Windows SDK documentation) to get a handle to the interface.
        /// </para>
        /// <para>
        /// See Overview of Device Interface Classes for more info.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiEnumDeviceInterfaces", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiEnumDeviceInterfaces([In] HDEVINFO DeviceInfoSet, [In] in SP_DEVINFO_DATA DeviceInfoData,
            [In] in GUID InterfaceClassGuid, [In] DWORD MemberIndex, [In][Out] ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiGetDeviceInstanceId"/> function retrieves the device instance ID that is associated with a device information element.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// In Windows Vista and later versions of Windows,
        /// the unified device property model uses the DEVPKEY_Device_InstanceId property key to represent the device instance identifier.
        /// See Retrieving a Device Instance Identifier for details.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinstanceidw"/>
        /// </para>
        /// </summary>
        /// <param name="DeviceInfoSet">
        /// A handle to the device information set that contains the device information element
        /// that represents the device for which to retrieve a device instance ID.
        /// </param>
        /// <param name="DeviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure
        /// that specifies the device information element in <paramref name="DeviceInfoSet"/>.
        /// </param>
        /// <param name="DeviceInstanceId">
        /// A pointer to the character buffer that will receive the NULL-terminated device instance ID for the specified device information element.
        /// For information about device instance IDs, see Device Identification Strings.
        /// </param>
        /// <param name="DeviceInstanceIdSize">
        /// The size, in characters, of the <paramref name="DeviceInstanceId"/> buffer.
        /// </param>
        /// <param name="RequiredSize">
        /// A pointer to the variable that receives the number of characters required to store the device instance ID.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> if it is successful.
        /// Otherwise, it returns <see cref="FALSE"/> and the logged error can be retrieved by making a call to <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiGetDeviceInstanceIdW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiGetDeviceInstanceId([In] HDEVINFO DeviceInfoSet, [In] in SP_DEVINFO_DATA DeviceInfoData, [In] IntPtr DeviceInstanceId,
            [In] DWORD DeviceInstanceIdSize, [Out] out DWORD RequiredSize);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiGetDeviceInterfaceDetail"/> function returns details about a device interface.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacedetailw"/>
        /// </para>
        /// </summary>
        /// <param name="DeviceInfoSet">
        /// A pointer to the device information set that contains the interface for which to retrieve details.
        /// This handle is typically returned by <see cref="SetupDiGetClassDevs"/>.
        /// </param>
        /// <param name="DeviceInterfaceData">
        /// A pointer to an <see cref="SP_DEVICE_INTERFACE_DATA"/> structure
        /// that specifies the interface in <paramref name="DeviceInfoSet"/> for which to retrieve details.
        /// A pointer of this type is typically returned by <see cref="SetupDiEnumDeviceInterfaces"/>.
        /// </param>
        /// <param name="DeviceInterfaceDetailData">
        /// A pointer to an <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA"/> structure to receive information about the specified interface.
        /// This parameter is optional and can be <see cref="NullRef{SP_DEVICE_INTERFACE_DETAIL_DATA}"/>.
        /// This parameter must be <see cref="NullRef{SP_DEVICE_INTERFACE_DETAIL_DATA}"/> if <paramref name="DeviceInterfaceDetailDataSize"/> is zero.
        /// If this parameter is specified, the caller must set <code>DeviceInterfaceDetailData.cbSize</code>
        /// to <code>sizeof(SP_DEVICE_INTERFACE_DETAIL_DATA)</code> before calling this function.
        /// The <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA.cbSize"/> member always contains the size of the fixed part of the data structure,
        /// not a size reflecting the variable-length string at the end.
        /// </param>
        /// <param name="DeviceInterfaceDetailDataSize">
        /// <para>
        /// The size of the <paramref name="DeviceInterfaceDetailData"/> buffer.
        /// The buffer must be at least (<c>offsetof(SP_DEVICE_INTERFACE_DETAIL_DATA, DevicePath) + sizeof(TCHAR)</c>) bytes,
        /// to contain the fixed part of the structure and a single <see cref="NULL"/> to terminate an empty MULTI_SZ string.
        /// </para>
        /// <para>
        /// This parameter must be zero if <paramref name="DeviceInterfaceDetailData"/> is <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="RequiredSize">
        /// A pointer to a variable of type <see cref="DWORD"/> that receives the required size of the <paramref name="DeviceInterfaceDetailData"/> buffer.
        /// This size includes the size of the fixed part of the structure plus the number of bytes required for the variable-length device path string.
        /// This parameter is optional and can be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="DeviceInfoData">
        /// A pointer to a buffer that receives information about the device that supports the requested interface.
        /// The caller must set <code>DeviceInfoData.cbSize</code> to <code>sizeof(SP_DEVINFO_DATA)</code>.
        /// This parameter is optional and can be <see cref="NullRef{SP_DEVINFO_DATA}"/>.
        /// </param>
        /// <returns>
        /// <see cref="SetupDiGetDeviceInterfaceDetail"/> returns <see cref="TRUE"/> if the function completed without error.
        /// If the function completed with an error, <see cref="FALSE"/> is returned
        /// and the error code for the failure can be retrieved by calling <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Using this function to get details about an interface is typically a two-step process:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Get the required buffer size. Call <see cref="SetupDiGetDeviceInterfaceDetail"/> with a <see cref="NULL"/>
        /// <paramref name="DeviceInterfaceDetailData"/> pointer, a <paramref name="DeviceInterfaceDetailDataSize"/> of zero,
        /// and a valid <paramref name="RequiredSize"/> variable.
        /// In response to such a call, this function returns the required buffer size at <paramref name="RequiredSize"/>
        /// and fails with <see cref="GetLastError"/> returning <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Allocate an appropriately sized buffer and call the function again to get the interface details.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The interface detail returned by this function consists of a device path
        /// that can be passed to Win32 functions such as <see cref="CreateFile"/>.
        /// Do not attempt to parse the device path symbolic name.
        /// The device path can be reused across system starts.
        /// </para>
        /// <para>
        /// <see cref="SetupDiGetDeviceInterfaceDetail"/> can be used to get just the <paramref name="DeviceInfoData"/>.
        /// If the interface exists but <paramref name="DeviceInterfaceDetailData"/> is <see cref="NULL"/>, this function fails,
        /// <see cref="GetLastError"/> returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>,
        /// and the <paramref name="DeviceInfoData"/> structure is filled with information about the device that exposes the interface.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiGetDeviceInterfaceDetailW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiGetDeviceInterfaceDetail([In] HDEVINFO DeviceInfoSet, [In] in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
            [In][Out] ref SP_DEVICE_INTERFACE_DETAIL_DATA DeviceInterfaceDetailData, [In] DWORD DeviceInterfaceDetailDataSize,
            [Out] out DWORD RequiredSize, [In][Out] ref SP_DEVINFO_DATA DeviceInfoData);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiGetDeviceRegistryProperty"/> function retrieves a specified Plug and Play device property.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceregistrypropertyw"/>
        /// </para>
        /// </summary>
        /// <param name="DeviceInfoSet">
        /// A handle to a device information set that contains a device information element
        /// that represents the device for which to retrieve a Plug and Play property.
        /// </param>
        /// <param name="DeviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure that specifies the device information element in <paramref name="DeviceInfoSet"/>.
        /// </param>
        /// <param name="Property">
        /// <para>
        /// One of the following values that specifies the property to be retrieved:
        /// </para>
        /// <para>
        /// <see cref="SPDRP_ADDRESS"/>
        /// </para>
        /// <para>
        /// The function retrieves the device's address.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_BUSNUMBER"/>
        /// </para>
        /// <para>
        /// The function retrieves the device's bus number.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_BUSTYPEGUID"/>
        /// </para>
        /// <para>
        /// The function retrieves the GUID for the device's bus type.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_CAPABILITIES"/>
        /// </para>
        /// <para>
        /// The function retrieves a bitwise OR of the following CM_DEVCAP_Xxx flags in a <see cref="DWORD"/>.
        /// The device capabilities that are represented by these flags correspond to the device capabilities
        /// that are represented by the members of the <see cref="DEVICE_CAPABILITIES"/> structure.
        /// The CM_DEVCAP_Xxx constants are defined in Cfgmgr32.h.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// CM_DEVCAP_Xxx flag
        /// </term>
        /// <term>
        /// Corresponding <see cref="DEVICE_CAPABILITIES"/> structure member
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVCAP_LOCKSUPPORTED"/>
        /// </term>
        /// <term>
        /// <see cref="DEVICE_CAPABILITIES.LockSupported"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVCAP_EJECTSUPPORTED"/>
        /// </term>
        /// <term>
        /// <see cref="DEVICE_CAPABILITIES.EjectSupported"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVCAP_REMOVABLE"/>
        /// </term>
        /// <term>
        /// <see cref="DEVICE_CAPABILITIES.Removable"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVCAP_DOCKDEVICE"/>
        /// </term>
        /// <term>
        /// <see cref="DEVICE_CAPABILITIES.DockDevice"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVCAP_UNIQUEID"/>
        /// </term>
        /// <term>
        /// <see cref="DEVICE_CAPABILITIES.UniqueID"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVCAP_SILENTINSTALL"/>
        /// </term>
        /// <term>
        /// <see cref="DEVICE_CAPABILITIES.SilentInstall"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVCAP_RAWDEVICEOK"/>
        /// </term>
        /// <term>
        /// <see cref="DEVICE_CAPABILITIES.RawDeviceOK"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVCAP_SURPRISEREMOVALOK"/>
        /// </term>
        /// <term>
        /// <see cref="DEVICE_CAPABILITIES.SurpriseRemovalOK"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVCAP_HARDWAREDISABLED"/>
        /// </term>
        /// <term>
        /// <see cref="DEVICE_CAPABILITIES.HardwareDisabled"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVCAP_NONDYNAMIC"/>
        /// </term>
        /// <term>
        /// <see cref="DEVICE_CAPABILITIES.NonDynamic"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="SPDRP_CHARACTERISTICS"/>
        /// </para>
        /// <para>
        /// The function retrieves a bitwise OR of a device's characteristics flags in a <see cref="DWORD"/>.
        /// For a description of these flags, which are defined in Wdm.h and Ntddk.h,
        /// see the DeviceCharacteristics parameter of the IoCreateDevice function.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_CLASS"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the device setup class of a device.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_CLASSGUID"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the <see cref="GUID"/> that represents the device setup class of a device.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_COMPATIBLEIDS"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_MULTI_SZ"/> string that contains the list of compatible IDs for a device.
        /// For information about compatible IDs, see Device Identification Strings.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_CONFIGFLAGS"/>
        /// </para>
        /// <para>
        /// The function retrieves a bitwise OR of a device's configuration flags in a <see cref="DWORD"/> value. 
        /// The configuration flags are represented by the CONFIGFLAG_Xxx bitmasks that are defined in Regstr.h.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_DEVICE_POWER_DATA"/>
        /// </para>
        /// <para>
        /// (Windows XP and later)
        /// The function retrieves a <see cref="CM_POWER_DATA"/> structure that contains the device's power management information.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_DEVICEDESC"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the description of a device.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_DEVTYPE"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="DWORD"/> value that represents the device's type.
        /// For more information, see Specifying Device Types.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_DRIVER"/>
        /// </para>
        /// <para>
        /// The function retrieves a string that identifies the device's software key (sometimes called the driver key).
        /// For more information about driver keys, see Registry Trees and Keys for Devices and Drivers.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_ENUMERATOR_NAME"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the name of the device's enumerator.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_EXCLUSIVE"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="DWORD"/> value that indicates whether a user can obtain exclusive use of the device.
        /// The returned value is one if exclusive use is allowed, or zero otherwise.
        /// For more information, see IoCreateDevice.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_FRIENDLYNAME"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the friendly name of a device.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_HARDWAREID"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_MULTI_SZ"/> string that contains the list of hardware IDs for a device.
        /// For information about hardware IDs, see Device Identification Strings.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_INSTALL_STATE"/>
        /// </para>
        /// <para>
        /// (Windows XP and later)
        /// The function retrieves a <see cref="DWORD"/> value that indicates the installation state of a device.
        /// The installation state is represented by one of the CM_INSTALL_STATE_Xxx values that are defined in Cfgmgr32.h.
        /// The CM_INSTALL_STATE_Xxx values correspond to the <see cref="DEVICE_INSTALL_STATE"/> enumeration values.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_LEGACYBUSTYPE"/>
        /// </para>
        /// <para>
        /// The function retrieves the device's legacy bus type as an INTERFACE_TYPE value (defined in Wdm.h and Ntddk.h).
        /// </para>
        /// <para>
        /// <see cref="SPDRP_LOCATION_INFORMATION"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the hardware location of a device.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_LOCATION_PATHS"/>
        /// </para>
        /// <para>
        /// (Windows Server 2003 and later)
        /// The function retrieves a <see cref="REG_MULTI_SZ"/> string that represents the location of the device in the device tree.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_LOWERFILTERS"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_MULTI_SZ"/> string that contains the names of a device's lower-filter drivers.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_MFG"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the name of the device manufacturer.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_PHYSICAL_DEVICE_OBJECT_NAME"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the name that is associated with the device's PDO.
        /// For more information, see IoCreateDevice.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_REMOVAL_POLICY"/>
        /// </para>
        /// <para>
        /// (Windows XP and later)
        /// The function retrieves the device's current removal policy as a <see cref="DWORD"/>
        /// that contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_REMOVAL_POLICY_HW_DEFAULT"/>
        /// </para>
        /// <para>
        /// (Windows XP and later)
        /// The function retrieves the device's hardware-specified default removal policy as a <see cref="DWORD"/>
        /// that contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_REMOVAL_POLICY_OVERRIDE"/>
        /// </para>
        /// <para>
        /// (Windows XP and later)
        /// The function retrieves the device's override removal policy (if it exists) from the registry,
        /// as a DWORD that contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_SECURITY"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="SECURITY_DESCRIPTOR"/> structure for a device.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_SECURITY_SDS"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the device's security descriptor.
        /// For information about security descriptor strings, see Security Descriptor Definition Language (Windows).
        /// For information about the format of security descriptor strings, see Security Descriptor Definition Language (Windows).
        /// </para>
        /// <para>
        /// <see cref="SPDRP_SERVICE"/>
        /// </para>
        /// <para>
        /// The function retrieves a REG_SZ string that contains the service name for a device.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_UI_NUMBER"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="DWORD"/> value set to the value of the <see cref="DEVICE_CAPABILITIES.UINumber"/> member
        /// of the device's <see cref="DEVICE_CAPABILITIES"/> structure.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_UI_NUMBER_DESC_FORMAT"/>
        /// </para>
        /// <para>
        /// The function retrieves a format string (<see cref="REG_SZ"/>) used to display the <see cref="DEVICE_CAPABILITIES.UINumber"/> value.
        /// </para>
        /// <para>
        /// <see cref="SPDRP_UPPERFILTERS"/>
        /// </para>
        /// <para>
        /// The function retrieves a <see cref="REG_MULTI_SZ"/> string that contains the names of a device's upper filter drivers.
        /// </para>
        /// </param>
        /// <param name="PropertyRegDataType">
        /// A pointer to a variable that receives the data type of the property that is being retrieved.
        /// This is one of the standard registry data types.
        /// This parameter is optional and can be <see cref="NullRef{RegistryValueTypes}"/>.
        /// </param>
        /// <param name="PropertyBuffer">
        /// A pointer to a buffer that receives the property that is being retrieved.
        /// If this parameter is set to <see cref="NULL"/>, and <paramref name="PropertyBufferSize"/> is also set to zero,
        /// the function returns the required size for the buffer in <paramref name="RequiredSize"/>.
        /// </param>
        /// <param name="PropertyBufferSize">
        /// The size, in bytes, of the <paramref name="PropertyBuffer"/> buffer.
        /// </param>
        /// <param name="RequiredSize">
        /// A pointer to a variable of type <see cref="DWORD"/> that receives the required size, in bytes,
        /// of the <paramref name="PropertyBuffer"/> buffer that is required to hold the data for the requested property.
        /// This parameter is optional and can be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <returns>
        /// <see cref="SetupDiGetDeviceRegistryProperty"/> returns <see cref="TRUE"/> if the call was successful.
        /// Otherwise, it returns <see cref="FALSE"/> and the logged error can be retrieved by making a call to <see cref="GetLastError"/>.
        /// <see cref="SetupDiGetDeviceRegistryProperty"/> returns the <see cref="ERROR_INVALID_DATA"/> error code
        /// if the requested property does not exist for a device or if the property data is not valid.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiGetDeviceRegistryPropertyW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiGetDeviceRegistryProperty([In] HDEVINFO DeviceInfoSet, [In] in SP_DEVINFO_DATA DeviceInfoData,
            [In] SetupDeviceRegistryProperties Property, [Out] out RegistryValueTypes PropertyRegDataType, [In] IntPtr PropertyBuffer,
            [In] DWORD PropertyBufferSize, [Out] out DWORD RequiredSize);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiGetSelectedDriver"/> function retrieves the selected driver
        /// for a device information set or a particular device information element.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetselecteddriverw"/>
        /// </para>
        /// </summary>
        /// <param name="DeviceInfoSet">
        /// A handle to the device information set for which to retrieve a selected driver.
        /// </param>
        /// <param name="DeviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure that specifies a device information element
        /// that represents the device in <paramref name="DeviceInfoSet"/> for which to retrieve the selected driver.
        /// This parameter is optional and can be NULL.
        /// If this parameter is specified, <see cref="SetupDiGetSelectedDriver"/> retrieves the selected driver for the specified device.
        /// If this parameter is <see cref="NullRef{SP_DEVINFO_DATA}"/>, <see cref="SetupDiGetSelectedDriver"/> retrieves
        /// the selected class driver in the global class driver list that is associated with <paramref name="DeviceInfoSet"/>.
        /// </param>
        /// <param name="DriverInfoData">
        /// A pointer to an <see cref="SP_DRVINFO_DATA"/> structure that receives information about the selected driver.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> if it is successful.
        /// Otherwise, it returns <see cref="FALSE"/> and the logged error can be retrieved with a call to <see cref="GetLastError"/>.
        /// If a driver has not been selected for the specified device instance, the logged error is <see cref="ERROR_NO_DRIVER_SELECTED"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiGetSelectedDriverW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiGetSelectedDriver([In] HDEVINFO DeviceInfoSet, [In] in SP_DEVINFO_DATA DeviceInfoData,
            [In][Out] ref SP_DRVINFO_DATA DriverInfoData);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiOpenDeviceInfo"/> function adds a device information element for a device instance to a device information set,
        /// if one does not already exist in the device information set,
        /// and retrieves information that identifies the device information element for the device instance in the device information set.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiopendeviceinfow"/>
        /// </para>
        /// </summary>
        /// <param name="DeviceInfoSet">
        /// A handle to the device information set to which <see cref="SetupDiOpenDeviceInfo"/> adds a device information element,
        /// if one does not already exist, for the device instance that is specified by <paramref name="DeviceInstanceId"/>.
        /// </param>
        /// <param name="DeviceInstanceId">
        /// A pointer to a NULL-terminated string that supplies the device instance identifier of a device (for example, "Root*PNP0500\0000").
        /// If <paramref name="DeviceInstanceId"/> is <see langword="null"/> or references a zero-length string,
        /// <see cref="SetupDiOpenDeviceInfo"/> adds a device information element to the supplied device information set,
        /// if one does not already exist, for the root device in the device tree.
        /// </param>
        /// <param name="hwndParent">
        /// The handle to the top-level window to use for any user interface related to installing the device.
        /// </param>
        /// <param name="OpenFlags">
        /// <para>
        /// A variable of <see cref="DWORD"/> type that controls how the device information element is opened.
        /// The value of this parameter can be one or more of the following:
        /// </para>
        /// <para>
        /// <see cref="DIOD_CANCEL_REMOVE"/>
        /// </para>
        /// <para>
        /// If this flag is specified and the device had been marked for pending removal, the operating system cancels the pending removal.
        /// </para>
        /// <para>
        /// <see cref="DIOD_INHERIT_CLASSDRVS"/>
        /// </para>
        /// <para>
        /// If this flag is specified, the resulting device information element inherits the class driver list,
        /// if any, associated with the device information set.
        /// In addition, if there is a selected driver for the device information set, that same driver is selected for the new device information element.
        /// </para>
        /// <para>
        /// If the device information element was already present, its class driver list, if any, is replaced with the inherited list.
        /// </para>
        /// </param>
        /// <param name="DeviceInfoData">
        /// A pointer to a caller-supplied <see cref="SP_DEVINFO_DATA"/> structure that receives information
        /// about the device information element for the device instance that is specified by <paramref name="DeviceInstanceId"/>.
        /// The caller must set <see cref="SP_DEVINFO_DATA.cbSize"/> to <code>sizeof(SP_DEVINFO_DATA)</code>.
        /// This parameter is optional and can be <see cref="NullRef{SP_DEVINFO_DATA}"/>.
        /// </param>
        /// <returns>
        /// <see cref="SetupDiOpenDeviceInfo"/> returns <see cref="TRUE"/> if it is successful.
        /// Otherwise, the function returns <see cref="FALSE"/> and the logged error can be retrieved with a call to <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// f this device instance is being added to a set that has an associated class,
        /// the device class must be the same or the call will fail.
        /// In this case, a call to <see cref="GetLastError"/> returns <see cref="ERROR_CLASS_MISMATCH"/>.
        /// </para>
        /// <para>
        /// If the new device information element is successfully opened
        /// but the caller-supplied <paramref name="DeviceInfoData"/> buffer is invalid, this function returns <see cref="FALSE"/>.
        /// In this case, a call to <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_USER_BUFFER"/>.
        /// However, the device information element is added as a new member of the set anyway.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiOpenDeviceInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiOpenDeviceInfo([In] HDEVINFO DeviceInfoSet, [In] LPCWSTR DeviceInstanceId, [In] HWND hwndParent,
            [In] SetupDiOpenDeviceInfoFlags OpenFlags, [Out] out SP_DEVINFO_DATA DeviceInfoData);
    }
}
