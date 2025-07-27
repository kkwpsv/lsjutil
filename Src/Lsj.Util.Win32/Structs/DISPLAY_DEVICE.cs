using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DisplayDeviceStateFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAY_DEVICE"/> structure receives information about the display device
    /// specified by the iDevNum parameter of the <see cref="EnumDisplayDevices"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-display_devicew"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The four string members are set based on the parameters passed to <see cref="EnumDisplayDevices"/>.
    /// If the lpDevice param is <see cref="NULL"/>, then <see cref="DISPLAY_DEVICE"/> is filled in with information about the display adapter(s).
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
        /// <para>
        /// Device state flags. It can be any reasonable combination of the following.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DISPLAY_DEVICE_ACTIVE"/>
        /// </term>
        /// <term>
        /// <see cref="DISPLAY_DEVICE_ACTIVE"/> specifies whether a monitor is presented as being "on" by the respective GDI view.
        /// Windows Vista: <see cref="EnumDisplayDevices"/> will only enumerate monitors that can be presented as being "on."
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISPLAY_DEVICE_MIRRORING_DRIVER"/>
        /// </term>
        /// <term>
        /// Represents a pseudo device used to mirror application drawing for remoting or other purposes.
        /// An invisible pseudo monitor is associated with this device.
        /// For example, NetMeeting uses it.
        /// Note that <code>GetSystemMetrics(SM_MONITORS)</code> only accounts for visible display monitors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISPLAY_DEVICE_MODESPRUNED"/>
        /// </term>
        /// <term>
        /// The device has more display modes than its output devices support.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISPLAY_DEVICE_PRIMARY_DEVICE"/>
        /// </term>
        /// <term>
        /// The primary desktop is on the device. For a system with a single display card, this is always set.
        /// For a system with multiple display cards, only one device can have this set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISPLAY_DEVICE_REMOVABLE"/>
        /// </term>
        /// <term>
        /// The device is removable; it cannot be the primary display.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISPLAY_DEVICE_VGA_COMPATIBLE"/>
        /// </term>
        /// <term>
        /// The device is VGA compatible.
        /// </term>
        /// </item>
        /// </list>
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
