using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CM_DEVCAP;
using static Lsj.Util.Win32.Enums.DeviceRegistryPropertyCodes;
using static Lsj.Util.Win32.Enums.RegistryValueTypes;
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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/setupapi/nf-setupapi-setupdidestroydeviceinfolist"/>
        /// </para>
        /// </summary>
        /// <param name="DeviceInfoSet">
        /// A handle to the device information set to delete.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> if it is successful.
        /// Otherwise, it returns <see cref="FALSE"/> and the logged error can be retrieved with a call to <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiDestroyDeviceInfoList", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiDestroyDeviceInfoList([In] HDEVINFO DeviceInfoSet);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiGetClassDevs"/> function returns a handle to a device information set
        /// that contains requested device information elements for a local computer.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevsw"/>
        /// </para>
        /// </summary>
        /// <param name="ClassGuid">
        /// A pointer to the GUID for a device setup class or a device interface class.
        /// This pointer is optional and can be <see cref="NullRef{GUID}"/>.
        /// For more information about how to set ClassGuid, see the following Remarks section.
        /// </param>
        /// <param name="Enumerator">
        /// A pointer to a NULL-terminated string that specifies:
        /// An identifier (ID) of a Plug and Play (PnP) enumerator.
        /// This ID can either be the value's globally unique identifier (GUID) or symbolic name.
        /// For example, "PCI" can be used to specify the PCI PnP value.
        /// Other examples of symbolic names for PnP values include "USB," "PCMCIA," and "SCSI".
        /// A PnP device instance ID.
        /// When specifying a PnP device instance ID, <see cref="DIGCF_DEVICEINTERFACE"/> must be set in the <paramref name="Flags"/> parameter.
        /// This pointer is optional and can be <see langword="null"/>.
        /// If an enumeration value is not used to select devices, set <paramref name="Enumerator"/> to <see langword="null"/>
        /// For more information about how to set the <paramref name="Enumerator"/> value, see the following Remarks section.
        /// </param>
        /// <param name="hwndParent">
        /// A handle to the top-level window to be used for a user interface
        /// that is associated with installing a device instance in the device information set.
        /// This handle is optional and can be <see cref="NULL"/>.
        /// </param>
        /// <param name="Flags">
        /// A variable of type DWORD that specifies control options that filter the device information elements
        /// that are added to the device information set.
        /// This parameter can be a bitwise OR of zero or more of the following flags.
        /// For more information about combining these flags, see the following Remarks section.
        /// </param>
        /// <returns>
        /// If the operation succeeds, <see cref="SetupDiGetClassDevs"/> returns a handle to a device information set
        /// that contains all installed devices that matched the supplied parameters.
        /// If the operation fails, the function returns <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The caller of <see cref="SetupDiGetClassDevs"/> must delete the returned device information set
        /// when it is no longer needed by calling <see cref="SetupDiDestroyDeviceInfoList"/>.
        /// Call <see cref="SetupDiGetClassDevsEx"/> to retrieve the devices for a class on a remote computer.
        /// </remarks>
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiGetClassDevsW", ExactSpelling = true, SetLastError = true)]
        public static extern HDEVINFO SetupDiGetClassDevs([In] in GUID ClassGuid, [In] string Enumerator,
            [In] HWND hwndParent, [In] SetupDiGetClassDevsFlags Flags);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiEnumDeviceInfo"/> function returns a <see cref="SP_DEVINFO_DATA"/> structure
        /// that specifies a device information element in a device information set.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/setupapi/nf-setupapi-setupdienumdeviceinfo"/>
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
        /// The caller must set <code>DeviceInfoData.cbSize</code> to <code>sizeof(SP_DEVINFO_DATA)</code>.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> if it is successful.
        /// Otherwise, it returns <see cref="FALSE"/> and the logged error can be retrieved with a call to <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Repeated calls to this function return a device information element for a different device.
        /// This function can be called repeatedly to get information about all devices in the device information set.
        /// To enumerate device information elements, an installer should initially call <see cref="SetupDiEnumDeviceInfo"/>
        /// with the MemberIndex parameter set to 0.
        /// The installer should then increment <paramref name="MemberIndex"/> and call <see cref="SetupDiEnumDeviceInfo"/>
        /// until there are no more values (the function fails and a call to <see cref="GetLastError"/> returns <see cref="ERROR_NO_MORE_ITEMS"/>).
        /// Call <see cref="SetupDiEnumDeviceInterfaces"/> to get a context structure
        /// for a device interface element (versus a device information element).
        /// </remarks>
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiEnumDeviceInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiEnumDeviceInfo([In] HDEVINFO DeviceInfoSet, [In] DWORD MemberIndex, [In][Out] ref SP_DEVINFO_DATA DeviceInfoData);


        /// <summary>
        /// <para>
        /// The <see cref="SetupDiGetDeviceInstanceId"/> function retrieves the device instance ID that is associated with a device information element.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinstanceidw"/>
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
        /// <remarks>
        /// The setupapi.h header defines <see cref="SetupDiGetDeviceInstanceId"/> as an alias which automatically
        /// selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to
        /// mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiGetDeviceInstanceIdW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiGetDeviceInstanceId([In] HDEVINFO DeviceInfoSet, [In] in SP_DEVINFO_DATA DeviceInfoData, [In] IntPtr DeviceInstanceId,
            [In] DWORD DeviceInstanceIdSize, [Out] out DWORD RequiredSize);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiGetDeviceRegistryProperty"/> function retrieves a specified Plug and Play device property.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceregistrypropertyw"/>
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
        /// One of the following values that specifies the property to be retrieved:
        /// <see cref="SPDRP_ADDRESS"/>:
        /// The function retrieves the device's address.
        /// <see cref="SPDRP_BUSNUMBER"/>:
        /// The function retrieves the device's bus number.
        /// <see cref="SPDRP_BUSTYPEGUID"/>:
        /// The function retrieves the GUID for the device's bus type.
        /// <see cref="SPDRP_CAPABILITIES"/>:
        /// The function retrieves a bitwise OR of the following CM_DEVCAP_Xxx flags in a DWORD.
        /// The device capabilities that are represented by these flags correspond to the device capabilities
        /// that are represented by the members of the <see cref="DEVICE_CAPABILITIES"/> structure.
        /// The CM_DEVCAP_Xxx constants are defined in Cfgmgr32.h.
        /// <see cref="CM_DEVCAP_LOCKSUPPORTED"/>	LockSupported
        /// <see cref="CM_DEVCAP_EJECTSUPPORTED"/> EjectSupported
        /// <see cref="CM_DEVCAP_REMOVABLE"/> Removable
        /// <see cref="CM_DEVCAP_DOCKDEVICE"/> DockDevice
        /// <see cref="CM_DEVCAP_UNIQUEID"/> UniqueID
        /// <see cref="CM_DEVCAP_SILENTINSTALL"/> SilentInstall
        /// <see cref="CM_DEVCAP_RAWDEVICEOK"/> RawDeviceOK
        /// <see cref="CM_DEVCAP_SURPRISEREMOVALOK"/> SurpriseRemovalOK
        /// <see cref="CM_DEVCAP_HARDWAREDISABLED"/> HardwareDisabled
        /// <see cref="CM_DEVCAP_NONDYNAMIC"/> NonDynamic
        /// <see cref="SPDRP_CHARACTERISTICS"/>:
        /// The function retrieves a bitwise OR of a device's characteristics flags in a DWORD.
        /// For a description of these flags, which are defined in Wdm.h and Ntddk.h,
        /// see the DeviceCharacteristics parameter of the IoCreateDevice function.
        /// <see cref="SPDRP_CLASS"/>:
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the device setup class of a device.
        /// <see cref="SPDRP_CLASSGUID"/>:
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the GUID that represents the device setup class of a device.
        /// <see cref="SPDRP_COMPATIBLEIDS"/>:
        /// The function retrieves a <see cref="REG_MULTI_SZ"/> string that contains the list of compatible IDs for a device.
        /// For information about compatible IDs, see Device Identification Strings.
        /// <see cref="SPDRP_CONFIGFLAGS"/>:
        /// The function retrieves a bitwise OR of a device's configuration flags in a <see cref="DWORD"/> value.
        /// The configuration flags are represented by the CONFIGFLAG_Xxx bitmasks that are defined in Regstr.h.
        /// <see cref="SPDRP_DEVICE_POWER_DATA"/>:
        /// (Windows XP and later)
        /// The function retrieves a CM_POWER_DATA structure that contains the device's power management information.
        /// <see cref="SPDRP_DEVICEDESC"/>:
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the description of a device.
        /// <see cref="SPDRP_DEVTYPE"/>:
        /// The function retrieves a <see cref="DWORD"/> value that represents the device's type.
        /// For more information, see Specifying Device Types.
        /// <see cref="SPDRP_DRIVER"/>:
        /// The function retrieves a string that identifies the device's software key (sometimes called the driver key).
        /// For more information about driver keys, see Registry Trees and Keys for Devices and Drivers.
        /// <see cref="SPDRP_ENUMERATOR_NAME"/>:
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the name of the device's enumerator.
        /// <see cref="SPDRP_EXCLUSIVE"/>:
        /// The function retrieves a <see cref="DWORD"/> value that indicates whether a user can obtain exclusive use of the device.
        /// The returned value is one if exclusive use is allowed, or zero otherwise.
        /// For more information, see IoCreateDevice.
        /// <see cref="SPDRP_FRIENDLYNAME"/>:
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the friendly name of a device.
        /// <see cref="SPDRP_HARDWAREID"/>:
        /// The function retrieves a <see cref="REG_MULTI_SZ"/> string that contains the list of hardware IDs for a device.
        /// For information about hardware IDs, see Device Identification Strings.
        /// <see cref="SPDRP_INSTALL_STATE"/>:
        /// (Windows XP and later)
        /// The function retrieves a <see cref="DWORD"/> value that indicates the installation state of a device.
        /// The installation state is represented by one of the CM_INSTALL_STATE_Xxx values that are defined in Cfgmgr32.h.
        /// The CM_INSTALL_STATE_Xxx values correspond to the DEVICE_INSTALL_STATE enumeration values.
        /// <see cref="SPDRP_LEGACYBUSTYPE"/>:
        /// The function retrieves the device's legacy bus type as an <see cref="INTERFACE_TYPE"/> value (defined in Wdm.h and Ntddk.h).
        /// <see cref="SPDRP_LOCATION_INFORMATION"/>:
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the hardware location of a device.
        /// <see cref="SPDRP_LOCATION_PATHS"/>:
        /// (Windows Server 2003 and later)
        /// The function retrieves a <see cref="REG_MULTI_SZ"/> string that represents the location of the device in the device tree.
        /// <see cref="SPDRP_LOWERFILTERS"/>:
        /// The function retrieves a <see cref="REG_MULTI_SZ"/> string that contains the names of a device's lower-filter drivers.
        /// <see cref="SPDRP_MFG"/>:
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the name of the device manufacturer.
        /// <see cref="SPDRP_PHYSICAL_DEVICE_OBJECT_NAME"/>:
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the name that is associated with the device's PDO.
        /// For more information, see IoCreateDevice.
        /// <see cref="SPDRP_REMOVAL_POLICY"/>:
        /// (Windows XP and later)
        /// The function retrieves the device's current removal policy as a <see cref="DWORD"/> that
        /// contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
        /// <see cref="SPDRP_REMOVAL_POLICY_HW_DEFAULT"/>:
        /// (Windows XP and later)
        /// The function retrieves the device's hardware-specified default removal policy as a <see cref="DWORD"/> that
        /// contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
        /// <see cref="SPDRP_REMOVAL_POLICY_OVERRIDE"/>:
        /// (Windows XP and later)
        /// The function retrieves the device's override removal policy (if it exists) from the registry,
        /// as a <see cref="DWORD"/> that contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
        /// <see cref="SPDRP_SECURITY"/>:
        /// The function retrieves a <see cref="SECURITY_DESCRIPTOR"/> structure for a device.
        /// <see cref="SPDRP_SECURITY_SDS"/>:
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the device's security descriptor.
        /// For information about security descriptor strings, see Security Descriptor Definition Language (Windows).
        /// For information about the format of security descriptor strings, see Security Descriptor Definition Language (Windows).
        /// <see cref="SPDRP_SERVICE"/>:
        /// The function retrieves a <see cref="REG_SZ"/> string that contains the service name for a device.
        /// <see cref="SPDRP_UI_NUMBER"/>:
        /// The function retrieves a <see cref="DWORD"/> value set to the value of
        /// the <see cref="DEVICE_CAPABILITIES.UINumber"/> member of the device's <see cref="DEVICE_CAPABILITIES"/> structure.
        /// <see cref="SPDRP_UI_NUMBER_DESC_FORMAT"/>:
        /// The function retrieves a format string (<see cref="REG_SZ"/>) used to display the <see cref="DEVICE_CAPABILITIES.UINumber"/> value.
        /// <see cref="SPDRP_UPPERFILTERS"/>
        /// The function retrieves a <see cref="REG_MULTI_SZ"/> string that contains the names of a device's upper filter drivers.
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
        /// <remarks>
        /// The setupapi.h header defines <see cref="SetupDiGetDeviceRegistryProperty"/> as an alias
        /// which automatically selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to
        /// mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiGetDeviceRegistryPropertyW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiGetDeviceRegistryProperty([In] HDEVINFO DeviceInfoSet, [In] in SP_DEVINFO_DATA DeviceInfoData,
            [In] DeviceRegistryPropertyCodes Property, [Out] out RegistryValueTypes PropertyRegDataType, [In] IntPtr PropertyBuffer,
            [In] DWORD PropertyBufferSize, [Out] out DWORD RequiredSize);

        /// <summary>
        /// <para>
        /// The <see cref="SetupDiGetSelectedDriver"/> function retrieves the selected driver
        /// for a device information set or a particular device information element.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/setupapi/nf-setupapi-setupdigetselecteddriverw"/>
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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/setupapi/nf-setupapi-setupdiopendeviceinfow"/>
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
        /// A variable of <see cref="DWORD"/> type that controls how the device information element is opened.
        /// The value of this parameter can be one or more of the following:
        /// <see cref="DIOD_CANCEL_REMOVE"/> <see cref="DIOD_INHERIT_CLASSDRVS"/>
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
        /// If this device instance is being added to a set that has an associated class, the device class must be the same or the call will fail.
        /// In this case, a call to <see cref="GetLastError"/> returns <see cref="ERROR_CLASS_MISMATCH"/>.
        /// If the new device information element is successfully opened but the caller-supplied <paramref name="DeviceInfoData"/> buffer is invalid,
        /// this function returns <see cref="FALSE"/>.
        /// In this case, a call to <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_USER_BUFFER"/>.
        /// However, the device information element is added as a new member of the set anyway.
        /// </remarks>
        [DllImport("SetupAPI.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupDiOpenDeviceInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupDiOpenDeviceInfo([In] HDEVINFO DeviceInfoSet, [In] string DeviceInstanceId, [In] HWND hwndParent,
            [In] SetupDiOpenDeviceInfoFlags OpenFlags, [In][Out] ref SP_DEVINFO_DATA DeviceInfoData);
    }
}
