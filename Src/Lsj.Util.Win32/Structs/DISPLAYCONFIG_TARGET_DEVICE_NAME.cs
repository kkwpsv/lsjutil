using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DISPLAYCONFIG_DEVICE_INFO_TYPE;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME"/> structure contains information about the target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_target_device_name"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Extended display identification data (EDID) is a set of data
    /// that is provided by a display to describe its capabilities to a graphics adapter.
    /// EDID data allows a computer to detect the type of monitor that is connected to it.
    /// EDID data includes the manufacturer name, the product type, the timings that are supported by the display,
    /// the display size, as well as other display characteristics.
    /// EDID is defined by a standard published by the Video Electronics Standards Association (VESA).
    /// </para>
    /// <para>
    /// A named device object has a path and name of the form <code>\Device\DeviceName</code>.
    /// This is known as the device name of the device object.
    /// </para>
    /// <para>
    /// If an application calls the <see cref="DisplayConfigGetDeviceInfo"/> function to obtain the monitor name
    /// and <see cref="DisplayConfigGetDeviceInfo"/> either cannot get the monitor name or the target is forced without a monitor connected,
    /// the string in the <see cref="monitorFriendlyDeviceName"/> member of the <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME"/> structure
    /// is a <see cref="NULL"/> string and none of the bit-field flags in the <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS"/> structure are set.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_TARGET_DEVICE_NAME
    {
        /// <summary>
        /// A <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> structure that contains information about the request for the target device name.
        /// The caller should set the <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER.type"/> member
        /// of <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> to <see cref="DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME"/> and
        /// the <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER.adapterId"/> and <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER.id"/> members
        /// of <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> to the target for which the caller wants the target device name.
        /// The caller should set the <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER.size"/> member
        /// of <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> to at least the size of the <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME"/> structure.
        /// </summary>
        public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

        /// <summary>
        /// A <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS"/> structure that identifies, in bit-field flags, information about the target.
        /// </summary>
        public DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS flags;

        /// <summary>
        /// A value from the <see cref="DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY"/> enumeration that specifies the target's connector type.
        /// </summary>
        public DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;

        /// <summary>
        /// The manufacture identifier from the monitor extended display identification data (EDID).
        /// This member is set only when the edidIdsValid bit-field is set in the flags member.
        /// </summary>
        public UINT16 edidManufactureId;

        /// <summary>
        /// The product code from the monitor EDID.
        /// This member is set only when the edidIdsValid bit-field is set in the flags member.
        /// </summary>
        public UINT16 edidProductCodeId;

        /// <summary>
        /// The one-based instance number of this particular target only when the adapter has multiple targets of this type.
        /// The connector instance is a consecutive one-based number that is unique within each adapter.
        /// If this is the only target of this type on the adapter, this value is zero.
        /// </summary>
        public UINT32 connectorInstance;

        /// <summary>
        /// A NULL-terminated WCHAR string that is the device name for the monitor.
        /// This name can be used with SetupAPI.dll to obtain the device name that is contained in the installation package.
        /// </summary>
        public ByValStringStructForSize64 monitorFriendlyDeviceName;

        /// <summary>
        /// A NULL-terminated WCHAR string that is the path to the device name for the monitor.
        /// This path can be used with SetupAPI.dll to obtain the device name that is contained in the installation package.
        /// </summary>
        public ByValStringStructForSize128 monitorDevicePath;
    }
}
