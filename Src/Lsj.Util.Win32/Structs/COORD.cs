using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the coordinates of a character cell in a console screen buffer.
    /// The origin of the coordinate system (0,0) is at the top, left cell of the buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/coord-str"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COORD
    {
        /// <summary>
        /// The horizontal coordinate or column value. The units depend on the function call.
        /// </summary>
        public SHORT X;

        /// <summary>
        /// The vertical coordinate or row value. The units depend on the function call.
        /// </summary>
        public SHORT Y;
    }
}
