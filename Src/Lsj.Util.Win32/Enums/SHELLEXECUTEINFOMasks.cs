using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SHELLEXECUTEINFO"/> masks
    /// </summary>
    [Flags]
    public enum ShellExecuteInfoMasks : uint
    {
        /// <summary>
        /// SEE_MASK_DEFAULT
        /// </summary>
        SEE_MASK_DEFAULT = 0x00000000,

        /// <summary>
        /// SEE_MASK_CLASSNAME
        /// </summary>
        SEE_MASK_CLASSNAME = 0x00000001,

        /// <summary>
        /// SEE_MASK_CLASSKEY
        /// </summary>
        SEE_MASK_CLASSKEY = 0x00000003,

        /// <summary>
        /// SEE_MASK_IDLIST
        /// </summary>
        SEE_MASK_IDLIST = 0x00000004,

        /// <summary>
        /// SEE_MASK_INVOKEIDLIST
        /// </summary>
        SEE_MASK_INVOKEIDLIST = 0x0000000C,

        /// <summary>
        /// SEE_MASK_ICON
        /// </summary>
        SEE_MASK_ICON = 0x000000010,

        /// <summary>
        /// SEE_MASK_HOTKEY
        /// </summary>
        SEE_MASK_HOTKEY = 0x000000020,

        /// <summary>
        /// SEE_MASK_NOCLOSEPROCESS
        /// </summary>
        SEE_MASK_NOCLOSEPROCESS = 0x000000040,

        /// <summary>
        /// SEE_MASK_CONNECTNETDRV
        /// </summary>
        SEE_MASK_CONNECTNETDRV = 0x000000080,

        /// <summary>
        /// SEE_MASK_NOASYNC
        /// </summary>
        SEE_MASK_NOASYNC = 0x000000100,

        /// <summary>
        /// SEE_MASK_FLAG_DDEWAIT
        /// </summary>
        SEE_MASK_FLAG_DDEWAIT = 0x000000100,

        /// <summary>
        /// SEE_MASK_DOENVSUBST
        /// </summary>
        SEE_MASK_DOENVSUBST = 0x000000200,

        /// <summary>
        /// SEE_MASK_FLAG_NO_UI
        /// </summary>
        SEE_MASK_FLAG_NO_UI = 0x000000400,

        /// <summary>
        /// SEE_MASK_UNICODE
        /// </summary>
        SEE_MASK_UNICODE = 0x000004000,

        /// <summary>
        /// SEE_MASK_NO_CONSOLE
        /// </summary>
        SEE_MASK_NO_CONSOLE = 0x000008000,

        /// <summary>
        /// SEE_MASK_ASYNCOK
        /// </summary>
        SEE_MASK_ASYNCOK = 0x00100000,

        /// <summary>
        /// SEE_MASK_NOQUERYCLASSSTORE
        /// </summary>
        SEE_MASK_NOQUERYCLASSSTORE = 0x01000000,

        /// <summary>
        /// SEE_MASK_HMONITOR
        /// </summary>
        SEE_MASK_HMONITOR = 0x00200000,

        /// <summary>
        /// SEE_MASK_NOZONECHECKS
        /// </summary>
        SEE_MASK_NOZONECHECKS = 0x00800000,

        /// <summary>
        /// SEE_MASK_WAITFORINPUTIDLE
        /// </summary>
        SEE_MASK_WAITFORINPUTIDLE = 0x02000000,

        /// <summary>
        /// SEE_MASK_FLAG_LOG_USAGE
        /// </summary>
        SEE_MASK_FLAG_LOG_USAGE = 0x04000000,

        /// <summary>
        /// SEE_MASK_FLAG_HINST_IS_SITE
        /// </summary>
        SEE_MASK_FLAG_HINST_IS_SITE = 0x08000000,

        /// <summary>
        /// SEE_MASK_FLAG_SEPVDM
        /// </summary>
        SEE_MASK_FLAG_SEPVDM = 0x00040000,

        /// <summary>
        /// SEE_MASK_HASLINKNAME
        /// </summary>
        SEE_MASK_HASLINKNAME = 0x00000800,

        /// <summary>
        /// SEE_MASK_HASTITLE
        /// </summary>
        SEE_MASK_HASTITLE = 0x00002000,
    }
}
