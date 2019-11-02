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
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/power/power-setting-guids
    /// </para>
    /// </summary>
    public static class PowerSettingGUIDs
    {
        /// <summary>
        /// <para>
        /// Lid state changes
        /// </para>
        /// <para>
        /// Specifies the current state of the lid (open or closed). The callback won't be called at all until a lid device is found and its current state is known.
        /// 0 for closed and 1 for opend.
        /// </para>
        /// <para>
        /// Not include in online document.
        /// </para>
        /// </summary>
        public static readonly Guid GUID_LIDSWITCH_STATE_CHANGE = new Guid(0xBA3E0F4D, 0xB817, 0x4094, 0xA2, 0xD1, 0xD5, 0x63, 0x79, 0xE6, 0xA0, 0xF3);
    }
}
