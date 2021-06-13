using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates whether the device is a primary or immersive type of display.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shellscalingapi/ne-shellscalingapi-display_device_type"/>
    /// </para>
    /// </summary>
    public enum DISPLAY_DEVICE_TYPE
    {
        /// <summary>
        /// The device is a primary display device.
        /// </summary>
        DEVICE_PRIMARY,

        /// <summary>
        /// The device is an immersive display device.
        /// </summary>
        DEVICE_IMMERSIVE
    }
}
