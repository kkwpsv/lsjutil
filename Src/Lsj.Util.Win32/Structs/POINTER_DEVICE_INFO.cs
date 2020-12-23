using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a pointer device.
    /// An array of these structures is returned from the <see cref="GetPointerDevices"/> function.
    /// A single structure is returned from a call to the <see cref="GetPointerDevice"/> function.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-pointer_device_info
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINTER_DEVICE_INFO
    {
        /// <summary>
        /// POINTER_DEVICE_PRODUCT_STRING_MAX
        /// </summary>
        public const int POINTER_DEVICE_PRODUCT_STRING_MAX = 520;

        /// <summary>
        /// One of the values from <see cref="DISPLAYCONFIG_ROTATION"/>, which identifies the orientation of the input digitizer.
        /// Note This value is 0 when the source of input is Touch Injection.
        /// </summary>
        public DISPLAYCONFIG_ROTATION displayOrientation;

        /// <summary>
        /// The handle to the pointer device.
        /// </summary>
        public HANDLE device;

        /// <summary>
        /// The device type.
        /// </summary>
        public POINTER_DEVICE_TYPE pointerDeviceType;

        /// <summary>
        /// The <see cref="HMONITOR"/> for the display that the device is mapped to.
        /// This is not necessarily the monitor that the pointer device is physically connected to.
        /// </summary>
        public HMONITOR monitor;

        /// <summary>
        /// The lowest ID that's assigned to the device.
        /// </summary>
        public ULONG startingCursorId;

        /// <summary>
        /// The number of supported simultaneous contacts.
        /// </summary>
        public USHORT maxActiveContacts;

        /// <summary>
        /// The string that identifies the product.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = POINTER_DEVICE_PRODUCT_STRING_MAX)]
        public string productString;
    }
}
