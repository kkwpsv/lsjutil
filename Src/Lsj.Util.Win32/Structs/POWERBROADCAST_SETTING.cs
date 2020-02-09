using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Sent with a power setting event and contains data about the specific change
    /// . For more information, see Registering for Power Events and Power Setting GUIDs.
    /// </para>
    /// <para>
    /// Data is after DataLength, which cannot be marshal automatically.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-powerbroadcast_setting
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POWERBROADCAST_SETTING
    {
        /// <summary>
        /// Indicates the power setting for which this notification is being delivered. For more info, see Power Setting GUIDs.
        /// </summary>
        public Guid PowerSetting;

        /// <summary>
        /// The size in bytes of the data in the Data member.
        /// </summary>
        public int DataLength;

        /*
        /// <summary>
        /// The new value of the power setting. The type and possible values for this member depend on PowerSettng.
        /// </summary>
        public byte[] Data;
        */
    }
}
