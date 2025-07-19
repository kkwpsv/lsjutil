using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains extended information about a console screen buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/console-screen-buffer-infoex"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONSOLE_SCREEN_BUFFER_INFOEX
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public ULONG cbSize;

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
        /// or echoed to a screen buffer by the <see cref="ReadFile"/> and <see cref="ReadConsole"/> functions.
        /// For more information, see Character Attributes.
        /// </summary>
        public ConsoleCharacterAttributes wAttributes;

        /// <summary>
        /// A <see cref="SMALL_RECT"/> structure that contains the console screen buffer coordinates
        /// of the upper-left and lower-right corners of the display window.
        /// </summary>
        public SMALL_RECT srWindow;

        /// <summary>
        /// A <see cref="COORD"/> structure that contains the maximum size of the console window, in character columns and rows,
        /// given the current screen buffer size and font and the screen size.
        /// </summary>
        public COORD dwMaximumWindowSize;

        /// <summary>
        /// The fill attribute for console pop-ups.
        /// </summary>
        public WORD wPopupAttributes;

        /// <summary>
        /// If this member is <see cref="TRUE"/>, full-screen mode is supported; otherwise, it is not.
        /// This will always be <see cref="FALSE"/> for systems after Windows Vista with the WDDM driver model
        /// as true direct VGA access to the monitor is no longer available.
        /// </summary>
        public BOOL bFullscreenSupported;

        /// <summary>
        /// An array of <see cref="COLORREF"/> values that describe the console's color settings.
        /// </summary>
        public ByValCOLORREFArrayStructForSize16 ColorTable;
    }
}
