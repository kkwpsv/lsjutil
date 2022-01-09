using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.DisplayDeviceStateFlags;
using Lsj.Util.Win32.Marshals.ByValStructs;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAY_DEVICE"/> structure receives information about the display device
    /// specified by the iDevNum parameter of the <see cref="EnumDisplayDevices"/> function.
    /// </para>
    /// </summary>
    /// <remarks>
    /// The four string members are set based on the parameters passed to <see cref="EnumDisplayDevices"/>.
    /// If the lpDevice param is <see langword="null"/>, then <see cref="DISPLAY_DEVICE"/> is filled in with information about the display adapter(s).
    /// If it is a valid device name, then it is filled in with information about the monitor(s) for that device.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAY_DEVICE
    {
        /// <summary>
        /// Size, in bytes, of the <see cref="DISPLAY_DEVICE"/> structure.
        /// This must be initialized prior to calling <see cref="EnumDisplayDevices"/>.
        /// </summary>
        public DWORD cb;

        /// <summary>
        /// An array of characters identifying the device name.
        /// This is either the adapter device or the monitor device.
        /// </summary>
        public ByValStringStructForSize32 DeviceName;

        /// <summary>
        /// An array of characters containing the device context string.
        /// This is either a description of the display adapter or of the display monitor.
        /// </summary>
        public ByValStringStructForSize128 DeviceString;

        /// <summary>
        /// Device state flags.
        /// It can be any reasonable combination of the following.
        /// <see cref="DISPLAY_DEVICE_ACTIVE"/>, <see cref="DISPLAY_DEVICE_MIRRORING_DRIVER"/>, <see cref="DISPLAY_DEVICE_MODESPRUNED"/>,
        /// <see cref="DISPLAY_DEVICE_PRIMARY_DEVICE"/>, <see cref="DISPLAY_DEVICE_REMOVABLE"/>, <see cref="DISPLAY_DEVICE_VGA_COMPATIBLE"/>
        /// </summary>
        public DisplayDeviceStateFlags StateFlags;

        /// <summary>
        /// Not used.
        /// </summary>
        public ByValStringStructForSize128 DeviceID;

        /// <summary>
        /// Reserved.
        /// </summary>
        public ByValStringStructForSize128 DeviceKey;
    }
}
