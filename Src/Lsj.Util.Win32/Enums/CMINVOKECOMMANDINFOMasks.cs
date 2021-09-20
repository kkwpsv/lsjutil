using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.SHELLEXECUTEINFOMasks;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="CMINVOKECOMMANDINFO"/> Masks and <see cref="CMINVOKECOMMANDINFOEX"/> Masks
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/ns-shobjidl_core-cminvokecommandinfoex"/>
    /// </para>
    /// </summary>
    public enum CMINVOKECOMMANDINFOMasks : uint
    {
        /// <summary>
        /// The <see cref="CMINVOKECOMMANDINFO.dwHotKey"/> member is valid.
        /// </summary>
        CMIC_MASK_HOTKEY = SEE_MASK_HOTKEY,

        /// <summary>
        /// The <see cref="CMINVOKECOMMANDINFO.hIcon"/> member is valid.
        /// As of Windows Vista this flag is not used.
        /// </summary>
        CMIC_MASK_ICON = SEE_MASK_ICON,

        /// <summary>
        /// The system is prevented from displaying user interface elements (for example, error messages) while carrying out a command.
        /// </summary>
        CMIC_MASK_FLAG_NO_UI = SEE_MASK_FLAG_NO_UI,

        /// <summary>
        /// The shortcut menu handler should use <see cref="CMINVOKECOMMANDINFOEX.lpVerbW"/>, <see cref="CMINVOKECOMMANDINFOEX.lpParametersW"/>,
        /// <see cref="CMINVOKECOMMANDINFOEX.lpDirectoryW"/>, and <see cref="CMINVOKECOMMANDINFOEX.lpTitleW"/> members instead of their ANSI equivalents.
        /// Because some shortcut menu handlers may not support Unicode, you should also pass valid ANSI strings
        /// in the <see cref="CMINVOKECOMMANDINFOEX.lpVerb"/>, <see cref="CMINVOKECOMMANDINFOEX.lpParameters"/>,
        /// <see cref="CMINVOKECOMMANDINFOEX.lpDirectory"/>, and <see cref="CMINVOKECOMMANDINFOEX.lpTitle"/> members.
        /// </summary>
        CMIC_MASK_UNICODE = SEE_MASK_UNICODE,

        /// <summary>
        /// If a shortcut menu handler needs to create a new process, it will normally create a new console.
        /// Setting the <see cref="CMIC_MASK_NO_CONSOLE"/> flag suppresses the creation of a new console.
        /// </summary>
        CMIC_MASK_NO_CONSOLE = SEE_MASK_NO_CONSOLE,

        /// <summary>
        /// The <see cref="CMINVOKECOMMANDINFOEX.lpTitle"/> member contains a full path to a shortcut file.
        /// Use in conjunction with <see cref="CMIC_MASK_HASTITLE"/>.
        /// Note  This value is not supported in Windows Vista and later systems.
        /// </summary>
        CMIC_MASK_HASLINKNAME = SEE_MASK_HASLINKNAME,

        /// <summary>
        /// The <see cref="CMINVOKECOMMANDINFOEX.lpTitle"/> member is valid.
        /// Note  This value is not supported in Windows Vista and later systems.
        /// </summary>
        CMIC_MASK_HASTITLE = SEE_MASK_HASTITLE,

        /// <summary>
        /// This flag is valid only when referring to a 16-bit Windows-based application.
        /// If set, the application that the shortcut points to runs in a private Virtual DOS Machine (VDM). See Remarks.
        /// </summary>
        CMIC_MASK_FLAG_SEP_VDM = SEE_MASK_FLAG_SEPVDM,

        /// <summary>
        /// Wait for the DDE conversation to terminate before returning.
        /// </summary>
        CMIC_MASK_ASYNCOK = SEE_MASK_ASYNCOK,

        /// <summary>
        /// Windows Vista and later.
        /// The implementation of <see cref="IContextMenu.InvokeCommand"/> should be synchronous, not returning before it is complete.
        /// Since this is recommended, calling applications that specify this flag cannot guarantee
        /// that this request will be honored if they are not familiar with the implementation of the verb that they are invoking.
        /// </summary>
        CMIC_MASK_NOASYNC = SEE_MASK_NOASYNC,

        /// <summary>
        /// The SHIFT key is pressed.
        /// Use this instead of polling the current state of the keyboard that may have changed since the verb was invoked.
        /// </summary>
        CMIC_MASK_SHIFT_DOWN = 0x10000000,

        /// <summary>
        /// The CTRL key is pressed.
        /// Use this instead of polling the current state of the keyboard that may have changed since the verb was invoked.
        /// </summary>
        CMIC_MASK_CONTROL_DOWN = 0x40000000,

        /// <summary>
        /// Indicates that the implementation of <see cref="IContextMenu.InvokeCommand"/> might want to keep track of the item
        /// being invoked for features like the "Recent documents" menu.
        /// </summary>
        CMIC_MASK_FLAG_LOG_USAGE = SEE_MASK_FLAG_LOG_USAGE,

        /// <summary>
        /// Do not perform a zone check.
        /// This flag allows <see cref="ShellExecuteEx"/> to bypass zone checking put into place by <see cref="IAttachmentExecute"/>.
        /// </summary>
        CMIC_MASK_NOZONECHECKS = SEE_MASK_NOZONECHECKS,

        /// <summary>
        /// The <see cref="CMINVOKECOMMANDINFOEX.ptInvoke"/> member is valid.
        /// </summary>
        CMIC_MASK_PTINVOKE =    0x20000000,
    }
}
