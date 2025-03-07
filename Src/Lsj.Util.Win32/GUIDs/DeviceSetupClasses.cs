using Lsj.Util.Win32.BaseTypes;
using System;

namespace Lsj.Util.Win32.GUIDs
{
    /// <summary>
    /// Device Setup Classes
    /// </summary>
    public static class DeviceSetupClasses
    {
        /// <summary>
        /// Camera Device
        /// </summary>
        /// <remarks>
        /// (Windows 10 version 1709 and later versions of Windows) Includes universal camera drivers.
        /// </remarks>
        public static readonly GUID GUID_DEVCLASS_CAMERA = new Guid(0xca3e7ab9, 0xb4c3, 0x4ae6, 0x82, 0x51, 0x57, 0x9e, 0xf9, 0x33, 0x89, 0x0f);

        /// <summary>
        /// Display Adapters
        /// </summary>
        /// <remarks>
        /// Includes video adapters. Drivers for this class include display drivers and video miniport drivers.
        /// </remarks>
        public static readonly GUID GUID_DEVCLASS_DISPLAY = new Guid(0x4d36e968, 0xe325, 0x11ce, 0xbf, 0xc1, 0x08, 0x00, 0x2b, 0xe1, 0x03, 0x18);

        /// <summary>
        /// Human Interface Devices (HID)
        /// </summary>
        /// <remarks>
        /// Includes interactive input devices that are operated by the system-supplied HID class driver.
        /// This includes USB devices that comply with the USB HID Standard and non-USB devices that use a HID minidriver.
        /// For more information, see HIDClass Device Setup Class. See also the Keyboard or Mouse classes.
        /// </remarks>
        public static readonly GUID GUID_DEVCLASS_HIDCLASS = new Guid(0x745a17a0, 0x74d3, 0x11d0, 0xb6, 0xfe, 0x00, 0xa0, 0xc9, 0x0f, 0x57, 0xda);
    }
}
