using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetDCEx"/> flags
    /// </summary>
    public enum GetDCExFlags : uint
    {
        /// <summary>
        /// DCX_WINDOW
        /// </summary>
        DCX_WINDOW = 0x00000001,

        /// <summary>
        /// DCX_CACHE
        /// </summary>
        DCX_CACHE = 0x00000002,

        /// <summary>
        /// DCX_NORESETATTRS
        /// </summary>
        DCX_NORESETATTRS = 0x00000004,

        /// <summary>
        /// DCX_CLIPCHILDREN
        /// </summary>
        DCX_CLIPCHILDREN = 0x00000008,

        /// <summary>
        /// DCX_CLIPSIBLINGS
        /// </summary>
        DCX_CLIPSIBLINGS = 0x00000010,

        /// <summary>
        /// DCX_PARENTCLIP
        /// </summary>
        DCX_PARENTCLIP = 0x00000020,

        /// <summary>
        /// DCX_EXCLUDERGN
        /// </summary>
        DCX_EXCLUDERGN = 0x00000040,

        /// <summary>
        /// DCX_INTERSECTRGN
        /// </summary>
        DCX_INTERSECTRGN = 0x00000080,

        /// <summary>
        /// DCX_EXCLUDEUPDATE
        /// </summary>
        DCX_EXCLUDEUPDATE = 0x00000100,

        /// <summary>
        /// DCX_INTERSECTUPDATE
        /// </summary>
        DCX_INTERSECTUPDATE = 0x00000200,

        /// <summary>
        /// DCX_LOCKWINDOWUPDATE
        /// </summary>
        DCX_LOCKWINDOWUPDATE = 0x00000400,

        /// <summary>
        /// DCX_VALIDATE
        /// </summary>
        DCX_VALIDATE = 0x00200000,
    }
}
