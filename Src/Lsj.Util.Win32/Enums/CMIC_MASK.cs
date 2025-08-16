using static Lsj.Util.Win32.Enums.ShellExecuteInfoMasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// CMIC_MASK
    /// </summary>
    public enum CMIC_MASK : uint
    {
        /// <summary>
        /// CMIC_MASK_HOTKEY
        /// </summary>
        CMIC_MASK_HOTKEY = SEE_MASK_HOTKEY,

        /// <summary>
        /// CMIC_MASK_ICON
        /// </summary>
        CMIC_MASK_ICON = SEE_MASK_ICON,

        /// <summary>
        /// CMIC_MASK_FLAG_NO_UI
        /// </summary>
        CMIC_MASK_FLAG_NO_UI = SEE_MASK_FLAG_NO_UI,

        /// <summary>
        /// CMIC_MASK_UNICODE
        /// </summary>
        CMIC_MASK_UNICODE = SEE_MASK_UNICODE,

        /// <summary>
        /// CMIC_MASK_NO_CONSOLE
        /// </summary>
        CMIC_MASK_NO_CONSOLE = SEE_MASK_NO_CONSOLE,

        /// <summary>
        /// CMIC_MASK_HASLINKNAME
        /// </summary>
        CMIC_MASK_HASLINKNAME = SEE_MASK_HASLINKNAME,

        /// <summary>
        /// CMIC_MASK_HASTITLE
        /// </summary>
        CMIC_MASK_HASTITLE = SEE_MASK_HASTITLE,

        /// <summary>
        /// CMIC_MASK_FLAG_SEP_VDM
        /// </summary>
        CMIC_MASK_FLAG_SEP_VDM = SEE_MASK_FLAG_SEPVDM,

        /// <summary>
        /// CMIC_MASK_ASYNCOK
        /// </summary>
        CMIC_MASK_ASYNCOK = SEE_MASK_ASYNCOK,

        /// <summary>
        /// CMIC_MASK_NOASYNC = SEE_MASK_NOASYNC,
        /// </summary>
        CMIC_MASK_NOASYNC = SEE_MASK_NOASYNC,

        /// <summary>
        /// CMIC_MASK_SHIFT_DOWN
        /// </summary>
        CMIC_MASK_SHIFT_DOWN = 0x10000000,

        /// <summary>
        /// CMIC_MASK_CONTROL_DOWN
        /// </summary>
        CMIC_MASK_CONTROL_DOWN = 0x40000000,

        /// <summary>
        /// CMIC_MASK_FLAG_LOG_USAGE
        /// </summary>
        CMIC_MASK_FLAG_LOG_USAGE = SEE_MASK_FLAG_LOG_USAGE,

        /// <summary>
        /// CMIC_MASK_NOZONECHECKS
        /// </summary>
        CMIC_MASK_NOZONECHECKS = SEE_MASK_NOZONECHECKS,

        /// <summary>
        /// CMIC_MASK_PTINVOKE
        /// </summary>
        CMIC_MASK_PTINVOKE = 0x20000000,
    }
}
