using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains pointer-based device properties (Human Interface Device (HID) global items that correspond to HID usages).
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-pointer_device_property
    /// </para>
    /// </summary>
    /// <remarks>
    /// Developers can use this function to determine the properties that a device supports beyond the standard ones
    /// that are delivered through Pointer Input Messages and Notifications.
    /// The properties map directly to HID usages.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINTER_DEVICE_PROPERTY
    {
        /// <summary>
        /// The minimum value that the device can report for this property.
        /// </summary>
        public INT32 logicalMin;

        /// <summary>
        /// The maximum value that the device can report for this property.
        /// </summary>
        public INT32 logicalMax;

        /// <summary>
        /// The physical minimum in Himetric.
        /// </summary>
        public INT32 physicalMin;

        /// <summary>
        /// The physical maximum in Himetric.
        /// </summary>
        public INT32 physicalMax;

        /// <summary>
        /// The unit.
        /// </summary>
        public UINT32 unit;

        /// <summary>
        /// The exponent.
        /// </summary>
        public UINT32 unitExponent;

        /// <summary>
        /// The usage page for the property, as documented in the HID specification.
        /// </summary>
        public USHORT usagePageId;

        /// <summary>
        /// The usage of the property, as documented in the HID specification.
        /// </summary>
        public USHORT usageId;
    }
}
