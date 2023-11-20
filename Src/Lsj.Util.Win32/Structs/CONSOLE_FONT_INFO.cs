using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information for a console font.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/console-font-info-str"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To obtain the size of the font, pass the font index to the <see cref="GetConsoleFontSize"/> function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONSOLE_FONT_INFO
    {
        /// <summary>
        /// The index of the font in the system's console font table.
        /// </summary>
        public DWORD nFont;

        /// <summary>
        /// A <see cref="COORD"/> structure that contains the width and height of each character in the font, in logical units.
        /// The <see cref="COORD.X"/> member contains the width, while the <see cref="COORD.Y"/> member contains the height.
        /// </summary>
        public COORD dwFontSize;
    }
}
