using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains extended information for a console font.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/console-font-infoex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To obtain the size of the font, pass the font index to the <see cref="GetConsoleFontSize"/> function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONSOLE_FONT_INFOEX
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// This member must be set to <code>sizeof(CONSOLE_FONT_INFOEX)</code> before calling <see cref="GetCurrentConsoleFontEx"/> or it will fail.
        /// </summary>
        public ULONG cbSize;

        /// <summary>
        /// The index of the font in the system's console font table.
        /// </summary>
        public DWORD nFont;

        /// <summary>
        /// A <see cref="COORD"/> structure that contains the width and height of each character in the font, in logical units.
        /// The <see cref="COORD.X"/> member contains the width, while the <see cref="COORD.Y"/> member contains the height.
        /// </summary>
        public COORD dwFontSize;

        /// <summary>
        /// The font pitch and family.
        /// For information about the possible values for this member,
        /// see the description of the <see cref="TEXTMETRIC.tmPitchAndFamily"/> member of the <see cref="TEXTMETRIC"/> structure.
        /// </summary>
        public UINT FontFamily;

        /// <summary>
        /// The font weight. The weight can range from 100 to 1000, in multiples of 100.
        /// For example, the normal weight is 400, while 700 is bold.
        /// </summary>
        public UINT FontWeight;

        /// <summary>
        /// The name of the typeface (such as Courier or Arial).
        /// </summary>
        public ByValStringStructForSize32 FaceName;
    }
}
