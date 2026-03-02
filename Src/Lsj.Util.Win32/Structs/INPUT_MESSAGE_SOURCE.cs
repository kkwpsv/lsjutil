using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the source of the input message.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-input_message_source"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INPUT_MESSAGE_SOURCE
    {
        /// <summary>
        /// The device type (<see cref="INPUT_MESSAGE_DEVICE_TYPE"/>) of the source of the input message.
        /// </summary>
        public INPUT_MESSAGE_DEVICE_TYPE deviceType;

        /// <summary>
        /// The ID (<see cref="INPUT_MESSAGE_ORIGIN_ID"/>) of the source of the input message.
        /// </summary>
        public INPUT_MESSAGE_ORIGIN_ID originId;
    }
}
