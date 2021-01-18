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
        /// The <see cref="GUID_DEVINTERFACE_USB_DEVICE"/> device interface class is defined for USB devices that are attached to a USB hub.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows-hardware/drivers/install/guid-devinterface-usb-device
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
    }
}
