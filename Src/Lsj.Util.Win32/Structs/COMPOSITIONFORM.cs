using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.CompositionWindowPositionStyles;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains style and position information for a composition window.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/ns-imm-compositionform"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Some IME windows adjust the composition window position specified by the system or the application.
    /// The <see cref="CFS_FORCE_POSITION"/> directs the IME window to skip this adjustment.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COMPOSITIONFORM
    {
        /// <summary>
        /// <para>
        /// Position style. This member can be one of the following values:
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
        /// <see cref="CFS_DEFAULT"/>
        /// </term>
        /// <term>
        /// Move the composition window to the default position.
        /// The IME window can display the composition window outside the client area, such as in a floating window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CFS_FORCE_POSITION"/>
        /// </term>
        /// <term>
        /// Display the upper left corner of the composition window at exactly the position specified by <see cref="ptCurrentPos"/>.
        /// The coordinates are relative to the upper left corner of the window containing the composition window and are not subject to adjustment by the IME.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CFS_POINT"/>
        /// </term>
        /// <term>
        /// Display the upper left corner of the composition window at the position specified by <see cref="ptCurrentPos"/>.
        /// The coordinates are relative to the upper left corner of the window containing the composition window and are subject to adjustment by the IME.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CFS_RECT"/>
        /// </term>
        /// <term>
        /// Display the composition window at the position specified by <see cref="rcArea"/>.
        /// The coordinates are relative to the upper left of the window containing the composition window.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public CompositionWindowPositionStyles dwStyle;

        /// <summary>
        /// A <see cref="POINT"/> structure containing the coordinates of the upper left corner of the composition window.
        /// </summary>
        public POINT ptCurrentPos;

        /// <summary>
        /// A <see cref="RECT"/> structure containing the coordinates
        /// of the upper left and lower right corners of the composition window.
        /// </summary>
        public RECT rcArea;
    }
}
