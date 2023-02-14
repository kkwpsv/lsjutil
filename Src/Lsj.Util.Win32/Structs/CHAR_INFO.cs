using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ConsoleCharacterAttributes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies a Unicode or ANSI character and its attributes.
    /// This structure is used by console functions to read from and write to a console screen buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/char-info-str"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CHAR_INFO
    {
        /// <summary>
        /// A union of the following members.
        /// </summary>
        public CHAR_INFO_Char Char;

        /// <summary>
        /// The character attributes. This member can be zero or any combination of the following values.
        /// <see cref="FOREGROUND_BLUE"/>, <see cref="FOREGROUND_GREEN"/>, <see cref="FOREGROUND_RED"/>, <see cref="FOREGROUND_INTENSITY"/>,
        /// <see cref="BACKGROUND_BLUE"/>, <see cref="BACKGROUND_GREEN"/>, <see cref="BACKGROUND_RED"/>, <see cref="BACKGROUND_INTENSITY"/>,
        /// <see cref="COMMON_LVB_LEADING_BYTE"/>, <see cref="COMMON_LVB_TRAILING_BYTE"/>, <see cref="COMMON_LVB_GRID_HORIZONTAL"/>,
        /// <see cref="COMMON_LVB_GRID_LVERTICAL"/>, <see cref="COMMON_LVB_GRID_RVERTICAL"/>, <see cref="COMMON_LVB_REVERSE_VIDEO"/>,
        /// <see cref="COMMON_LVB_UNDERSCORE"/>
        /// </summary>
        public ConsoleCharacterAttributes Attributes;

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct CHAR_INFO_Char
        {
            /// <summary>
            /// Unicode character of a screen buffer character cell.
            /// </summary>
            [FieldOffset(0)]
            public WCHAR UnicodeChar;

            /// <summary>
            /// ANSI character of a screen buffer character cell.
            /// </summary>
            [FieldOffset(0)]
            public CHAR AsciiChar;
        }
    }
}
