using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="RedrawWindow"/> flags
    /// </summary>
    [Flags]
    public enum RedrawWindowFlags : uint
    {
        /// <summary>
        /// RDW_ERASE
        /// </summary>
        RDW_ERASE = 0x0004,

        /// <summary>
        /// RDW_FRAME
        /// </summary>
        RDW_FRAME = 0x0400,

        /// <summary>
        /// RDW_INTERNALPAINT
        /// </summary>
        RDW_INTERNALPAINT = 0x0002,

        /// <summary>
        /// RDW_INVALIDATE
        /// </summary>
        RDW_INVALIDATE = 0x0001,

        /// <summary>
        /// RDW_NOERASE
        /// </summary>
        RDW_NOERASE = 0x0020,

        /// <summary>
        /// RDW_NOFRAME
        /// </summary>
        RDW_NOFRAME = 0x0800,

        /// <summary>
        /// RDW_NOINTERNALPAINT
        /// </summary>
        RDW_NOINTERNALPAINT = 0x0010,

        /// <summary>
        /// RDW_VALIDATE
        /// </summary>
        RDW_VALIDATE = 0x0008,

        /// <summary>
        /// RDW_ERASENOW
        /// </summary>
        RDW_ERASENOW = 0x0200,

        /// <summary>
        /// RDW_UPDATENOW
        /// </summary>
        RDW_UPDATENOW = 0x0100,

        /// <summary>
        /// RDW_ALLCHILDREN
        /// </summary>
        RDW_ALLCHILDREN = 0x0080,

        /// <summary>
        /// RDW_NOCHILDREN
        /// </summary>
        RDW_NOCHILDREN = 0x0040,
    }
}
