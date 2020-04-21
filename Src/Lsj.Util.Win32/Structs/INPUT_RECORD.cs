using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.InputRecordEventTypes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes an input event in the console input buffer.
    /// These records can be read from the input buffer by using the <see cref="ReadConsoleInput"/> or <see cref="PeekConsoleInput"/> function,
    /// or written to the input buffer by using the <see cref="WriteConsoleInput"/> function.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/console/input-record-str
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INPUT_RECORD
    {
        /// <summary>
        /// A handle to the type of input event and the event record stored in the <see cref="Event"/> member.
        /// This member can be one of the following values.
        /// <see cref="FOCUS_EVENT"/>,<see cref="KEY_EVENT"/>, <see cref="MENU_EVENT"/>, <see cref="MOUSE_EVENT"/>, <see cref="WINDOW_BUFFER_SIZE_EVENT"/>
        /// </summary>
        public InputRecordEventTypes EventType;

        /// <summary>
        /// The event information.
        /// The format of this member depends on the event type specified by the <see cref="EventType"/> member.
        /// </summary>
        public UnionStruct<KEY_EVENT_RECORD, MOUSE_EVENT_RECORD, WINDOW_BUFFER_SIZE_RECORD, MENU_EVENT_RECORD, FOCUS_EVENT_RECORD> Event;

        /// <summary>
        /// 
        /// </summary>
        public KEY_EVENT_RECORD KeyEvent
        {
            get => Event.Struct1;
            set => Event.Struct1 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public MOUSE_EVENT_RECORD MouseEvent
        {
            get => Event.Struct2;
            set => Event.Struct2 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent
        {
            get => Event.Struct3;
            set => Event.Struct3 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public MENU_EVENT_RECORD MenuEvent
        {
            get => Event.Struct4;
            set => Event.Struct4 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public FOCUS_EVENT_RECORD FocusEvent
        {
            get => Event.Struct5;
            set => Event.Struct5 = value;
        }
    }
}
