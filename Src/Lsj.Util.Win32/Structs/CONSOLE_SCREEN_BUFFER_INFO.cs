using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a console screen buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/console-screen-buffer-info-str"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONSOLE_SCREEN_BUFFER_INFO
    {
        /// <summary>
        /// A <see cref="COORD"/> structure that contains the size of the console screen buffer, in character columns and rows.
        /// </summary>
        public COORD dwSize;

        /// <summary>
        /// A <see cref="COORD"/> structure that contains the column and row coordinates of the cursor in the console screen buffer.
        /// </summary>
        public COORD dwCursorPosition;

        /// <summary>
        /// The attributes of the characters written to a screen buffer by the <see cref="WriteFile"/> and <see cref="WriteConsole"/> functions,
        /// or echoed to a screen buffer by the ReadFile and ReadConsole functions. For more information, see Character Attributes.
        /// </summary>
        public ConsoleCharacterAttributes wAttributes;

        /// <summary>
        /// A <see cref="SMALL_RECT"/> structure that contains the console screen buffer coordinates
        /// of the upper-left and lower-right corners of the display window.
        /// </summary>
        public SMALL_RECT srWindow;

        /// <summary>
        /// A COORD structure that contains the maximum size of the console window, in character columns and rows,
        /// given the current screen buffer size and font and the screen size.
        /// </summary>
        public COORD dwMaximumWindowSize;
    }
}
