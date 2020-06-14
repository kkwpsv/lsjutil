using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="EnumDisplayDevices"/> Flags
    /// </summary>
    public enum EnumDisplayDevicesFlags : uint
    {
        /// <summary>
        /// EDD_GET_DEVICE_INTERFACE_NAME
        /// </summary>
        EDD_GET_DEVICE_INTERFACE_NAME = 0x00000001,
    }
}
