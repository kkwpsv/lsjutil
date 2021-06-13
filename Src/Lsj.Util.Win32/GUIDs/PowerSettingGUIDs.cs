using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.GUIDs
{
    /// <summary>
    /// <para>
    /// Power Setting GUIDs
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/power/power-setting-guids"/>
    /// </para>
    /// </summary>
    public static class PowerSettingGUIDs
    {
        /// <summary>
        /// Specifies the current state of the lid (open or closed).
        /// The callback won't be called at all until a lid device is found and its current state is known.
        /// </summary>
        public static readonly Guid GUID_LIDSWITCH_STATE_CHANGE = new Guid(0xBA3E0F4D, 0xB817, 0x4094, 0xA2, 0xD1, 0xD5, 0x63, 0x79, 0xE6, 0xA0, 0xF3);

        /// <summary>
        /// Specifies (in seconds) how long we wait after the last user input has been received before we power off the video.
        /// </summary>
        public static readonly Guid GUID_VIDEO_POWERDOWN_TIMEOUT = new Guid(0x3C0BC021, 0xC8A8, 0x4E07, 0xA9, 0x73, 0x6B, 0x14, 0xCB, 0xCB, 0x2B, 0x7E);
    }
}
