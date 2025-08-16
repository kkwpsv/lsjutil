using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Queue status
    /// </summary>
    [Flags]
    public enum QueueStatus : uint
    {
        /// <summary>
        /// QS_ALLEVENTS
        /// </summary>
        QS_ALLEVENTS = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY,

        /// <summary>
        /// QS_ALLINPUT
        /// </summary>
        QS_ALLINPUT = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY | QS_SENDMESSAGE,

        /// <summary>
        /// QS_ALLPOSTMESSAGE
        /// </summary>
        QS_ALLPOSTMESSAGE = 0x0100,

        /// <summary>
        /// QS_HOTKEY
        /// </summary>
        QS_HOTKEY = 0x0080,

        /// <summary>
        /// QS_INPUT
        /// </summary>
        QS_INPUT = QS_MOUSE | QS_KEY | QS_RAWINPUT,

        /// <summary>
        /// QS_KEY
        /// </summary>
        QS_KEY = 0x0001,

        /// <summary>
        /// QS_MOUSE
        /// </summary>
        QS_MOUSE = QS_MOUSEMOVE | QS_MOUSEBUTTON,

        /// <summary>
        /// QS_MOUSEBUTTON
        /// </summary>
        QS_MOUSEBUTTON = 0x0004,

        /// <summary>
        /// QS_MOUSEMOVE
        /// </summary>
        QS_MOUSEMOVE = 0x0002,

        /// <summary>
        /// QS_PAINT
        /// </summary>
        QS_PAINT = 0x0020,

        /// <summary>
        /// QS_POSTMESSAGE
        /// </summary>
        QS_POSTMESSAGE = 0x0008,

        /// <summary>
        /// QS_RAWINPUT
        /// </summary>
        QS_RAWINPUT = 0x0400,

        /// <summary>
        /// QS_SENDMESSAGE
        /// </summary>
        QS_SENDMESSAGE = 0x0040,

        /// <summary>
        /// QS_TIMER
        /// </summary>
        QS_TIMER = 0x0010,
    }
}
