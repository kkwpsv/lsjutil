using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.COMPOSITIONFORMStyles;

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
        /// Position style. This member can be one of the following values:
        /// </summary>
        public COMPOSITIONFORMStyles dwStyle;

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
