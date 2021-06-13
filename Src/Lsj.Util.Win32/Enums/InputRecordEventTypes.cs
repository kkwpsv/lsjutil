using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="INPUT_RECORD"/> Event Type
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/console/input-record-str"/>
    /// </para>
    /// </summary>
    public enum InputRecordEventTypes : ushort
    {
        /// <summary>
        /// The <see cref="INPUT_RECORD.Event"/> member contains a <see cref="KEY_EVENT_RECORD"/> structure with information about a keyboard event.
        /// </summary>
        KEY_EVENT = 0x0001,

        /// <summary>
        /// The <see cref="INPUT_RECORD.Event"/> member contains a <see cref="MOUSE_EVENT_RECORD"/> structure
        /// with information about a mouse movement or button press event.
        /// </summary>
        MOUSE_EVENT = 0x0002,

        /// <summary>
        /// The <see cref="INPUT_RECORD.Event"/> member contains a <see cref="WINDOW_BUFFER_SIZE_RECORD"/> structure with information
        /// about the new size of the console screen buffer.
        /// </summary>
        WINDOW_BUFFER_SIZE_EVENT = 0x0004,

        /// <summary>
        /// The <see cref="INPUT_RECORD.Event"/> member contains a <see cref="MENU_EVENT_RECORD"/> structure.
        /// These events are used internally and should be ignored.
        /// </summary>
        MENU_EVENT = 0x0008,

        /// <summary>
        /// The <see cref="INPUT_RECORD.Event"/> member contains a <see cref="FOCUS_EVENT_RECORD"/> structure.
        /// These events are used internally and should be ignored.
        /// </summary>
        FOCUS_EVENT = 0x0010,
    }
}
