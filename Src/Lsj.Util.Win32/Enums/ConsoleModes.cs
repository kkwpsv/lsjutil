using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Console modes
    /// </summary>
    [Flags]
    public enum ConsoleModes : uint
    {
        /// <summary>
        /// ENABLE_ECHO_INPUT
        /// </summary>
        ENABLE_ECHO_INPUT = 0x0004,

        /// <summary>
        /// ENABLE_EXTENDED_FLAGS
        /// </summary>
        ENABLE_EXTENDED_FLAGS = 0x0080,

        /// <summary>
        /// ENABLE_INSERT_MODE
        /// </summary>
        ENABLE_INSERT_MODE = 0x0020,

        /// <summary>
        /// ENABLE_LINE_INPUT
        /// </summary>
        ENABLE_LINE_INPUT = 0x0002,

        /// <summary>
        /// ENABLE_MOUSE_INPUT
        /// </summary>
        ENABLE_MOUSE_INPUT = 0x0010,

        /// <summary>
        /// ENABLE_PROCESSED_INPUT
        /// </summary>
        ENABLE_PROCESSED_INPUT = 0x0001,

        /// <summary>
        /// ENABLE_QUICK_EDIT_MODE
        /// </summary>
        ENABLE_QUICK_EDIT_MODE = 0x0040,

        /// <summary>
        /// ENABLE_WINDOW_INPUT
        /// </summary>
        ENABLE_WINDOW_INPUT = 0x0008,

        /// <summary>
        /// ENABLE_VIRTUAL_TERMINAL_INPUT
        /// </summary>
        ENABLE_VIRTUAL_TERMINAL_INPUT = 0x0200,

        /// <summary>
        /// ENABLE_PROCESSED_OUTPUT
        /// </summary>
        ENABLE_PROCESSED_OUTPUT = 0x0001,

        /// <summary>
        /// ENABLE_WRAP_AT_EOL_OUTPUT
        /// </summary>
        ENABLE_WRAP_AT_EOL_OUTPUT = 0x0002,

        /// <summary>
        /// ENABLE_VIRTUAL_TERMINAL_PROCESSING
        /// </summary>
        ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004,

        /// <summary>
        /// DISABLE_NEWLINE_AUTO_RETURN
        /// </summary>
        DISABLE_NEWLINE_AUTO_RETURN = 0x0008,

        /// <summary>
        /// ENABLE_LVB_GRID_WORLDWIDE
        /// </summary>
        ENABLE_LVB_GRID_WORLDWIDE = 0x0010,
    }
}
