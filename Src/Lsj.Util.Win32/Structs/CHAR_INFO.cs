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
        /// <para>
        /// The character attributes. This member can be zero or any combination of the following values.
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
        /// <see cref="FOREGROUND_BLUE"/> 
        /// </term>
        /// <term>
        /// Text color contains blue.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FOREGROUND_GREEN"/> 
        /// </term>
        /// <term>
        /// Text color contains green.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FOREGROUND_RED"/> 
        /// </term>
        /// <term>
        /// Text color contains red.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FOREGROUND_INTENSITY"/> 
        /// </term>
        /// <term>
        /// Text color is intensified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BACKGROUND_BLUE"/> 
        /// </term>
        /// <term>
        /// Background color contains blue.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BACKGROUND_GREEN"/> 
        /// </term>
        /// <term>
        /// Background color contains green.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BACKGROUND_RED"/> 
        /// </term>
        /// <term>
        /// Background color contains red.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BACKGROUND_INTENSITY"/> 
        /// </term>
        /// <term>
        /// Background color is intensified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMMON_LVB_LEADING_BYTE"/> 
        /// </term>
        /// <term>
        /// Leading byte.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMMON_LVB_TRAILING_BYTE"/> 
        /// </term>
        /// <term>
        /// Trailing byte.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMMON_LVB_GRID_HORIZONTAL"/> 
        /// </term>
        /// <term>
        /// Top horizontal.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMMON_LVB_GRID_LVERTICAL"/> 
        /// </term>
        /// <term>
        /// Left vertical.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMMON_LVB_GRID_RVERTICAL"/> 
        /// </term>
        /// <term>
        /// Right vertical.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMMON_LVB_REVERSE_VIDEO"/> 
        /// </term>
        /// <term>
        /// Reverse foreground and background attribute.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMMON_LVB_UNDERSCORE"/> 
        /// </term>
        /// <term>
        /// Underscore.
        /// </term>
        /// </item>
        /// </list>
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
