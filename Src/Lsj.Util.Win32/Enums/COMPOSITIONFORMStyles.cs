using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="COMPOSITIONFORM"/> Styles
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/imm/ns-imm-compositionform"/>
    /// </para>
    /// </summary>
    public enum COMPOSITIONFORMStyles
    {
        /// <summary>
        /// Move the composition window to the default position.
        /// The IME window can display the composition window outside the client area, such as in a floating window.
        /// </summary>
        CFS_DEFAULT = 0x0000,

        /// <summary>
        /// Display the composition window at the position specified by <see cref="COMPOSITIONFORM.rcArea"/>.
        /// The coordinates are relative to the upper left of the window containing the composition window.
        /// </summary>
        CFS_RECT = 0x0001,

        /// <summary>
        /// Display the upper left corner of the composition window at the position specified by <see cref="COMPOSITIONFORM.ptCurrentPos"/>.
        /// The coordinates are relative to the upper left corner of the window containing the composition window and are subject to adjustment by the IME.
        /// </summary>
        CFS_POINT = 0x0002,

        /// <summary>
        /// Display the upper left corner of the composition window at exactly the position specified by <see cref="COMPOSITIONFORM.ptCurrentPos"/>.
        /// The coordinates are relative to the upper left corner of the window containing the composition window and are not subject to adjustment by the IME.
        /// </summary>
        CFS_FORCE_POSITION = 0x0020,

        /// <summary>
        /// 
        /// </summary>
        CFS_CANDIDATEPOS = 0x0040,

        /// <summary>
        /// 
        /// </summary>
        CFS_EXCLUDE = 0x0080,
    }
}
