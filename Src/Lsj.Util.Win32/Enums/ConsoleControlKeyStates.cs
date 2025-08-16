using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Console control key states
    /// </summary>
    [Flags]
    public enum ConsoleControlKeyStates : uint
    {
        /// <summary>
        /// RIGHT_ALT_PRESSED
        /// </summary>
        RIGHT_ALT_PRESSED = 0x0001,

        /// <summary>
        /// LEFT_ALT_PRESSED
        /// </summary>
        LEFT_ALT_PRESSED = 0x0002,

        /// <summary>
        /// RIGHT_CTRL_PRESSED
        /// </summary>
        RIGHT_CTRL_PRESSED = 0x0004,

        /// <summary>
        /// LEFT_CTRL_PRESSED
        /// </summary>
        LEFT_CTRL_PRESSED = 0x0008,

        /// <summary>
        /// SHIFT_PRESSED
        /// </summary>
        SHIFT_PRESSED = 0x0010,

        /// <summary>
        /// NUMLOCK_ON
        /// </summary>
        NUMLOCK_ON = 0x0020,

        /// <summary>
        /// SCROLLLOCK_ON
        /// </summary>
        SCROLLLOCK_ON = 0x0040,

        /// <summary>
        /// CAPSLOCK_ON
        /// </summary>
        CAPSLOCK_ON = 0x0080,

        /// <summary>
        /// ENHANCED_KEY
        /// </summary>
        ENHANCED_KEY = 0x0100,
    }
}
