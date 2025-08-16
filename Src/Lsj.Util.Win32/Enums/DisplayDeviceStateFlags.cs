using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Display device state flags
    /// </summary>
    [Flags]
    public enum DisplayDeviceStateFlags : uint
    {
        /// <summary>
        /// DISPLAY_DEVICE_ACTIVE
        /// </summary>
        DISPLAY_DEVICE_ACTIVE = 0x00000001,

        /// <summary>
        /// DISPLAY_DEVICE_MIRRORING_DRIVER
        /// </summary>
        DISPLAY_DEVICE_MIRRORING_DRIVER = 0x00000008,

        /// <summary>
        /// DISPLAY_DEVICE_MODESPRUNED
        /// </summary>
        DISPLAY_DEVICE_MODESPRUNED = 0x08000000,

        /// <summary>
        /// DISPLAY_DEVICE_PRIMARY_DEVICE
        /// </summary>
        DISPLAY_DEVICE_PRIMARY_DEVICE = 0x00000004,

        /// <summary>
        /// DISPLAY_DEVICE_REMOVABLE
        /// </summary>
        DISPLAY_DEVICE_REMOVABLE = 0x00000020,

        /// <summary>
        /// DISPLAY_DEVICE_VGA_COMPATIBLE
        /// </summary>
        DISPLAY_DEVICE_VGA_COMPATIBLE = 0x00000010,

        /// <summary>
        /// DISPLAY_DEVICE_ATTACHED_TO_DESKTOP
        /// </summary>
        DISPLAY_DEVICE_ATTACHED_TO_DESKTOP = 0x00000001,
    }
}
