using Lsj.Util.Win32.BaseTypes;
using System;

namespace Lsj.Util.Win32.GUIDs
{
    /// <summary>
    /// Device Interface Classes
    /// </summary>
    public static class DeviceInterfaceClasses
    {
        /// <summary>
        /// <para>
        /// <see cref="GUID_CLASS_USB_DEVICE"/> is an obsolete identifier for the device interface class for USB devices that are attached to a USB hub.
        /// Starting with Microsoft Windows 2000, use the <see cref="GUID_DEVINTERFACE_USB_DEVICE"/> class identifier for new instances of this class.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/install/guid-class-usb-device"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The Microsoft Windows Driver Kit (WDK) includes the USBVIEW sample application.
        /// The USBVIEW sample uses <see cref="GUID_CLASS_USB_DEVICE"/> to register to be notified
        /// if instances of the <see cref="GUID_CLASS_USB_DEVICE"/> interface class are present.
        /// </remarks>
        [Obsolete]
        public static readonly GUID GUID_CLASS_USB_DEVICE = GUID_DEVINTERFACE_USB_DEVICE;

        /// <summary>
        /// <para>
        /// The <see cref="GUID_DEVINTERFACE_USB_DEVICE"/> device interface class is defined for USB devices that are attached to a USB hub.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/install/guid-devinterface-usb-device"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The system-supplied USB hub driver registers instances of <see cref="GUID_DEVINTERFACE_USB_DEVICE"/>
        /// to notify the system and applications of the presence of USB devices that are attached to a USB hub.
        /// The Microsoft Windows Driver Kit (WDK) includes the USBVIEW sample application.
        /// The USBVIEW sample uses the obsolete identifier <see cref="GUID_CLASS_USB_DEVICE"/> to register
        /// to be notified of the arrival of instances of this device interface class.
        /// You must include initguid.h before including any header that declares a GUID by using the DEFINE_GUID macro.
        /// </remarks>
        public static readonly GUID GUID_DEVINTERFACE_USB_DEVICE = new Guid(0xA5DCBF10, 0x6530, 0x11D2, 0x90, 0x1F, 0x00, 0xC0, 0x4F, 0xB9, 0x51, 0xED);

        /// <summary>
        /// <para>
        /// The <see cref="GUID_DEVINTERFACE_MONITOR"/> device interface class is defined for monitor devices.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/install/guid-devinterface-monitor"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Windows registers a device interface for each monitor that is configured in the operating system.
        /// For information about display adapter and monitors, see Display Devices Design Guide and Monitor Drivers.
        /// </remarks>
        public static readonly GUID GUID_DEVINTERFACE_MONITOR = new Guid(0xE6F07B5F, 0xEE97, 0x4a90, 0xB0, 0x76, 0x33, 0xF5, 0x7B, 0xF4, 0xEA, 0xA7);
    }
}
