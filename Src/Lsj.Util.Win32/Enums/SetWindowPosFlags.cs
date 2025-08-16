using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SetWindowPos"/> flags
    /// </summary>
    [Flags]
    public enum SetWindowPosFlags : uint
    {
        /// <summary>
        /// SWP_ASYNCWINDOWPOS
        /// </summary>
        SWP_ASYNCWINDOWPOS = 0x4000,

        /// <summary>
        /// SWP_DEFERERASE
        /// </summary>
        SWP_DEFERERASE = 0x200,

        /// <summary>
        /// SWP_DRAWFRAME
        /// </summary>
        SWP_DRAWFRAME = 0x0020,

        /// <summary>
        /// SWP_FRAMECHANGED
        /// </summary>
        SWP_FRAMECHANGED = 0x0020,

        /// <summary>
        /// SWP_HIDEWINDOW
        /// </summary>
        SWP_HIDEWINDOW = 0x0080,

        /// <summary>
        /// SWP_NOACTIVATE
        /// </summary>
        SWP_NOACTIVATE = 0x0010,

        /// <summary>
        /// SWP_NOCOPYBITS
        /// </summary>
        SWP_NOCOPYBITS = 0x0100,

        /// <summary>
        /// SWP_NOMOVE
        /// </summary>
        SWP_NOMOVE = 0x0002,

        /// <summary>
        /// SWP_NOOWNERZORDER
        /// </summary>
        SWP_NOOWNERZORDER = 0x0200,

        /// <summary>
        /// SWP_NOREDRAW
        /// </summary>
        SWP_NOREDRAW = 0x0008,

        /// <summary>
        /// SWP_NOREPOSITION
        /// </summary>
        SWP_NOREPOSITION = 0x0200,

        /// <summary>
        /// SWP_NOSENDCHANGING
        /// </summary>
        SWP_NOSENDCHANGING = 0x0400,

        /// <summary>
        /// SWP_NOSIZE
        /// </summary>
        SWP_NOSIZE = 0x0001,

        /// <summary>
        /// SWP_NOZORDER
        /// </summary>
        SWP_NOZORDER = 0x0004,

        /// <summary>
        /// SWP_SHOWWINDOW
        /// </summary>
        SWP_SHOWWINDOW = 0x0040,
    }
}
