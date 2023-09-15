using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.DISPLAYCONFIG_DEVICE_INFO_TYPE;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> structure contains display information about the device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_device_info_header"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="DisplayConfigGetDeviceInfo"/> function uses the <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> structure
    /// for retrieving display configuration information about the device,
    /// and the <see cref="DisplayConfigSetDeviceInfo"/> function uses the <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> structure
    /// for setting display configuration information for the device.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_DEVICE_INFO_HEADER
    {
        /// <summary>
        /// A <see cref="DISPLAYCONFIG_DEVICE_INFO_TYPE"/> enumerated value that determines the type of device information to retrieve or set.
        /// The remainder of the packet for the retrieve or set operation follows immediately
        /// after the <see cref="DISPLAYCONFIG_DEVICE_INFO_HEADER"/> structure.
        /// </summary>
        public DISPLAYCONFIG_DEVICE_INFO_TYPE type;

        /// <summary>
        /// The size, in bytes, of the device information that is retrieved or set.
        /// This size includes the size of the header and the size of the additional data that follows the header.
        /// This device information depends on the request type.
        /// </summary>
        public UINT32 size;

        /// <summary>
        /// A locally unique identifier (LUID) that identifies the adapter that the device information packet refers to.
        /// </summary>
        public LUID adapterId;

        /// <summary>
        /// The source or target identifier to get or set the device information for.
        /// The meaning of this identifier is related to the type of information being requested.
        /// For example, in the case of <see cref="DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME"/>, this is the source identifier.
        /// </summary>
        public UINT32 id;
    }
}
