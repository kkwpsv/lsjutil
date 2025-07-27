using Lsj.Util.Win32.Enums;
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
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/input-record-str"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INPUT_RECORD
    {
        /// <summary>
        /// <para>
        /// A handle to the type of input event and the event record stored in the <see cref="Event"/> member.
        /// </para>
        /// <para>
        /// This member can be one of the following values.
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
        /// <see cref="FOCUS_EVENT"/> 0x0010
        /// </term>
        /// <term>
        /// The <see cref="Event"/> member contains a <see cref="FOCUS_EVENT_RECORD"/> structure.
        /// These events are used internally and should be ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="KEY_EVENT"/> 0x0001
        /// </term>
        /// <term>
        /// The <see cref="Event"/> member contains a <see cref="KEY_EVENT_RECORD"/> structure with information about a keyboard event.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MENU_EVENT"/> 0x0008
        /// </term>
        /// <term>
        /// The <see cref="Event"/> member contains a <see cref="MENU_EVENT_RECORD"/> structure.
        /// These events are used internally and should be ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MOUSE_EVENT"/> 0x0002
        /// </term>
        /// <term>
        /// The <see cref="Event"/> member contains a <see cref="MOUSE_EVENT_RECORD"/> structure
        /// with information about a mouse movement or button press event.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WINDOW_BUFFER_SIZE_EVENT"/> 0x0004
        /// </term>
        /// <term>
        /// The <see cref="Event"/> member contains a <see cref="WINDOW_BUFFER_SIZE_RECORD"/> structure
        /// with information about the new size of the console screen buffer.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public InputRecordEventTypes EventType;

        /// <summary>
        /// The event information.
        /// The format of this member depends on the event type specified by the <see cref="EventType"/> member.
        /// </summary>
        public INPUT_RECORD_Event Event;

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct INPUT_RECORD_Event
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public KEY_EVENT_RECORD KeyEvent;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public MOUSE_EVENT_RECORD MouseEvent;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public MENU_EVENT_RECORD MenuEvent;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public FOCUS_EVENT_RECORD FocusEvent;
        }
    }
}
