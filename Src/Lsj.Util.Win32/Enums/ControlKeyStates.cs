using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Control Key States
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/console-readconsole-control"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum ControlKeyStates : uint
    {
        /// <summary>
        /// The right ALT key is pressed.
        /// </summary>
        RIGHT_ALT_PRESSED = 0x0001,

        /// <summary>
        /// The left ALT key is pressed.
        /// </summary>
        LEFT_ALT_PRESSED = 0x0002,

        /// <summary>
        /// The right CTRL key is pressed.
        /// </summary>
        RIGHT_CTRL_PRESSED = 0x0004,

        /// <summary>
        /// The left CTRL key is pressed.
        /// </summary>
        LEFT_CTRL_PRESSED = 0x0008,

        /// <summary>
        /// The SHIFT key is pressed.
        /// </summary>
        SHIFT_PRESSED = 0x0010,

        /// <summary>
        /// The NUM LOCK light is on.
        /// </summary>
        NUMLOCK_ON = 0x0020,

        /// <summary>
        /// The SCROLL LOCK light is on.
        /// </summary>
        SCROLLLOCK_ON = 0x0040,

        /// <summary>
        /// The CAPS LOCK light is on.
        /// </summary>
        CAPSLOCK_ON = 0x0080,

        /// <summary>
        /// The key is enhanced.
        /// </summary>
        ENHANCED_KEY = 0x0100,
    }
}
