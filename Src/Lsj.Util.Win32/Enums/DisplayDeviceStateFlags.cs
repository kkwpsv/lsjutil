using System;
using System.Collections.Generic;
using System.Text;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Display Device State Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-display_devicew"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum DisplayDeviceStateFlags : uint
    {
        /// <summary>
        /// <see cref="DISPLAY_DEVICE_ACTIVE"/> specifies whether a monitor is presented as being "on" by the respective GDI view.
        /// Windows Vista: <see cref="EnumDisplayDevices"/> will only enumerate monitors that can be presented as being "on." 
        /// </summary>
        DISPLAY_DEVICE_ACTIVE = 0x00000001,

        /// <summary>
        /// Represents a pseudo device used to mirror application drawing for remoting or other purposes.
        /// An invisible pseudo monitor is associated with this device.
        /// For example, NetMeeting uses it.
        /// Note that <code>GetSystemMetrics(SM_MONITORS)</code> only accounts for visible display monitors.
        /// </summary>
        DISPLAY_DEVICE_MIRRORING_DRIVER = 0x00000008,

        /// <summary>
        /// The device has more display modes than its output devices support.
        /// </summary>
        DISPLAY_DEVICE_MODESPRUNED = 0x08000000,

        /// <summary>
        /// The primary desktop is on the device.
        /// For a system with a single display card, this is always set.
        /// For a system with multiple display cards, only one device can have this set.
        /// </summary>
        DISPLAY_DEVICE_PRIMARY_DEVICE = 0x00000004,

        /// <summary>
        /// The device is removable; it cannot be the primary display.
        /// </summary>
        DISPLAY_DEVICE_REMOVABLE = 0x00000020,

        /// <summary>
        /// The device is VGA compatible.
        /// </summary>
        DISPLAY_DEVICE_VGA_COMPATIBLE = 0x00000010,

        /// <summary>
        /// DISPLAY_DEVICE_ATTACHED_TO_DESKTOP
        /// </summary>
        DISPLAY_DEVICE_ATTACHED_TO_DESKTOP = 0x00000001,
    }
}
