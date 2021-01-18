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
        /// DISPLAY
        /// </summary>
        public static readonly GUID GUID_DEVCLASS_DISPLAY = new Guid(0x4d36e968, 0xe325, 0x11ce, 0xbf, 0xc1, 0x08, 0x00, 0x2b, 0xe1, 0x03, 0x18);

        /// <summary>
        /// HID
        /// </summary>
        public static readonly GUID GUID_DEVCLASS_HIDCLASS = new Guid(0x745a17a0, 0x74d3, 0x11d0, 0xb6, 0xfe, 0x00, 0xa0, 0xc9, 0x0f, 0x57, 0xda);
    }
}
