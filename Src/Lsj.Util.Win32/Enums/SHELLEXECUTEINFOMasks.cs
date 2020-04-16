using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="SHELLEXECUTEINFO"/> Masks
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/ns-shellapi-shellexecuteinfow
    /// </para>
    /// </summary>
    [Flags]
    public enum SHELLEXECUTEINFOMasks : uint
    {
        /// <summary>
        /// Use default values.
        /// </summary>
        SEE_MASK_DEFAULT = 0x00000000,

        /// <summary>
        /// Use the class name given by the <see cref="SHELLEXECUTEINFO.lpClass"/> member.
        /// If both <see cref="SEE_MASK_CLASSKEY"/> and <see cref="SEE_MASK_CLASSNAME"/> are set, the class key is used.
        /// </summary>
        SEE_MASK_CLASSNAME = 0x00000001,

        /// <summary>
        /// Use the class key given by the <see cref="SHELLEXECUTEINFO.hkeyClass"/> member.
        /// If both <see cref="SEE_MASK_CLASSKEY"/> and <see cref="SEE_MASK_CLASSNAME"/> are set, the class key is used.
        /// </summary>
        SEE_MASK_CLASSKEY = 0x00000003,

        /// <summary>
        /// Use the item identifier list given by the <see cref="SHELLEXECUTEINFO.lpIDList"/> member.
        /// The lpIDList member must point to an <see cref="ITEMIDLIST"/> structure.
        /// </summary>
        SEE_MASK_IDLIST = 0x00000004,

        /// <summary>
        /// Use the IContextMenu interface of the selected item's shortcut menu handler.
        /// Use either <see cref="SHELLEXECUTEINFO.lpFile"/> to identify the item by its file system path
        /// or <see cref="SHELLEXECUTEINFO.lpIDList"/> to identify the item by its PIDL.
        /// This flag allows applications to use <see cref="ShellExecuteEx"/> to invoke verbs from shortcut menu extensions
        /// instead of the static verbs listed in the registry.
        /// <see cref="SEE_MASK_INVOKEIDLIST"/> overrides and implies <see cref="SEE_MASK_IDLIST"/>.
        /// </summary>
        SEE_MASK_INVOKEIDLIST = 0x0000000C,

        /// <summary>
        /// Use the icon given by the <see cref="SHELLEXECUTEINFO.hIcon"/> member.
        /// This flag cannot be combined with <see cref="SEE_MASK_HMONITOR"/>.
        /// This flag is used only in Windows XP and earlier. It is ignored as of Windows Vista.
        /// </summary>
        SEE_MASK_ICON = 0x000000010,

        /// <summary>
        /// Use the keyboard shortcut given by the <see cref="SHELLEXECUTEINFO.dwHotKey"/> member.
        /// </summary>
        SEE_MASK_HOTKEY = 0x000000020,

        /// <summary>
        /// Use to indicate that the <see cref="SHELLEXECUTEINFO.hProcess"/> member receives the process handle.
        /// This handle is typically used to allow an application to find out when a process created with <see cref="ShellExecuteEx"/> terminates.
        /// In some cases, such as when execution is satisfied through a DDE conversation, no handle will be returned.
        /// The calling application is responsible for closing the handle when it is no longer needed.
        /// </summary>
        SEE_MASK_NOCLOSEPROCESS = 0x000000040,

        /// <summary>
        /// Validate the share and connect to a drive letter.
        /// This enables reconnection of disconnected network drives.
        /// The lpFile member is a UNC path of a file on a network.
        /// </summary>
        SEE_MASK_CONNECTNETDRV = 0x000000080,

        /// <summary>
        /// Wait for the execute operation to complete before returning.
        /// This flag should be used by callers that are using <see cref="ShellExecute"/> forms that might result in an async activation,
        /// for example DDE, and create a process that might be run on a background thread.
        /// (Note: <see cref="ShellExecuteEx"/> runs on a background thread by default if the caller's threading model is not Apartment.)
        /// Calls to <see cref="ShellExecuteEx"/> from processes already running on background threads should always pass this flag.
        /// Also, applications that exit immediately after calling <see cref="ShellExecuteEx"/> should specify this flag.
        /// If the execute operation is performed on a background thread and the caller did not specify the <see cref="SEE_MASK_ASYNCOK"/> flag,
        /// then the calling thread waits until the new process has started before returning.
        /// This typically means that either <see cref="CreateProcess"/> has been called, the DDE communication has completed,
        /// or that the custom execution delegate has notified <see cref="ShellExecuteEx"/> that it is done.
        /// If the <see cref="SEE_MASK_WAITFORINPUTIDLE"/> flag is specified,
        /// then <see cref="ShellExecuteEx"/> calls <see cref="WaitForInputIdle"/> and waits for the new process to idle before returning,
        /// with a maximum timeout of 1 minute.
        /// For further discussion on when this flag is necessary, see the Remarks section.
        /// </summary>
        SEE_MASK_NOASYNC = 0x000000100,

        /// <summary>
        /// Do not use; use <see cref="SEE_MASK_NOASYNC"/> instead.
        /// </summary>
        [Obsolete]
        SEE_MASK_FLAG_DDEWAIT = 0x000000100,

        /// <summary>
        /// Expand any environment variables specified in the string given
        /// by the <see cref="SHELLEXECUTEINFO.lpDirectory"/> or <see cref="SHELLEXECUTEINFO.lpFile"/> member.
        /// </summary>
        SEE_MASK_DOENVSUBST = 0x000000200,

        /// <summary>
        /// Do not display an error message box if an error occurs.
        /// </summary>
        SEE_MASK_FLAG_NO_UI = 0x000000400,

        /// <summary>
        /// Use this flag to indicate a Unicode application.
        /// </summary>
        SEE_MASK_UNICODE = 0x000004000,

        /// <summary>
        /// Use to inherit the parent's console for the new process instead of having it create a new console.
        /// It is the opposite of using a <see cref="CREATE_NEW_CONSOLE"/> flag with <see cref="CreateProcess"/>.
        /// </summary>
        SEE_MASK_NO_CONSOLE = 0x000008000,

        /// <summary>
        /// The execution can be performed on a background thread and the call should return immediately without waiting for the background thread to finish.
        /// Note that in certain cases <see cref="ShellExecuteEx"/> ignores this flag and waits for the process to finish before returning.
        /// </summary>
        SEE_MASK_ASYNCOK = 0x00100000,

        /// <summary>
        /// Not used.
        /// </summary>
        SEE_MASK_NOQUERYCLASSSTORE = 0x01000000,

        /// <summary>
        /// Use this flag when specifying a monitor on multi-monitor systems.
        /// The monitor is specified in the <see cref="SHELLEXECUTEINFO.hMonitor"/> member.
        /// This flag cannot be combined with <see cref="SEE_MASK_ICON"/>.
        /// </summary>
        SEE_MASK_HMONITOR = 0x00200000,

        /// <summary>
        /// Introduced in Windows XP. Do not perform a zone check.
        /// This flag allows <see cref="ShellExecuteEx"/> to bypass zone checking put into place by IAttachmentExecute.
        /// </summary>
        SEE_MASK_NOZONECHECKS = 0x00800000,

        /// <summary>
        /// After the new process is created, wait for the process to become idle before returning, with a one minute timeout.
        /// See <see cref="WaitForInputIdle"/> for more details.
        /// </summary>
        SEE_MASK_WAITFORINPUTIDLE = 0x02000000,

        /// <summary>
        /// Introduced in Windows XP. Keep track of the number of times this application has been launched.
        /// Applications with sufficiently high counts appear in the Start Menu's list of most frequently used programs.
        /// </summary>
        SEE_MASK_FLAG_LOG_USAGE = 0x04000000,

        /// <summary>
        /// The <see cref="SHELLEXECUTEINFO.hInstApp"/> member is used to specify the IUnknown of an object that implements IServiceProvider.
        /// This object will be used as a site pointer.
        /// The site pointer is used to provide services to the <see cref="ShellExecute"/> function, the handler binding process, and invoked verb handlers.
        /// To use <see cref="SEE_MASK_FLAG_HINST_IS_SITE"/> in operating systems prior to Windows 8,
        /// define it manually in your program: #define SEE_MASK_FLAG_HINST_IS_SITE 0x08000000.
        /// </summary>
        SEE_MASK_FLAG_HINST_IS_SITE = 0x08000000,
    }
}
