using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CMDSTR;
using static Lsj.Util.Win32.Enums.CMINVOKECOMMANDINFOMasks;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains extended information about a shortcut menu command.
    /// This structure is an extended version of <see cref="CMINVOKECOMMANDINFO"/> that allows the use of Unicode values.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/ns-shobjidl_core-cminvokecommandinfoex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Although the <see cref="IContextMenu.InvokeCommand"/> declaration specifies a <see cref="CMINVOKECOMMANDINFO"/> structure for the pici parameter,
    /// it can also accept a <see cref="CMINVOKECOMMANDINFOEX"/> structure.
    /// If you are implementing this method, you must inspect <see cref="cbSize"/> to determine which structure has been passed.
    /// By default, all 16-bit Windows-based applications run as threads in a single, shared VDM.
    /// The advantage of running separately is that a crash only terminates the single VDM;
    /// any other programs running in distinct VDMs continue to function normally.
    /// Also, 16-bit Windows-based applications that are run in separate VDMs have separate input queues.
    /// That means that if one application stops responding momentarily, applications in separate VDMs continue to receive input.
    /// The disadvantage of running separately is that it takes significantly more memory to do so.
    /// <see cref="CMINVOKECOMMANDINFOEX"/> itself is defined in Shobjidl.h, but you must also include Shellapi.h to have full access to all flags.
    /// Note: Prior to Windows Vista, this structure was declared in Shlobj.h.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CMINVOKECOMMANDINFOEX
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// Zero, or one or more of the following flags.
        /// <see cref="CMIC_MASK_HOTKEY"/>, <see cref="CMIC_MASK_ICON"/>, <see cref="CMIC_MASK_FLAG_NO_UI"/>,<see cref="CMIC_MASK_UNICODE"/>,
        /// <see cref="CMIC_MASK_NO_CONSOLE"/>, <see cref="CMIC_MASK_HASLINKNAME"/>, <see cref="CMIC_MASK_HASTITLE"/>,
        /// <see cref="CMIC_MASK_FLAG_SEP_VDM"/>, <see cref="CMIC_MASK_ASYNCOK"/>, <see cref="CMIC_MASK_NOASYNC"/>, <see cref="CMIC_MASK_SHIFT_DOWN"/>,
        /// <see cref="CMIC_MASK_CONTROL_DOWN"/>, <see cref="CMIC_MASK_FLAG_LOG_USAGE"/>, <see cref="CMIC_MASK_NOZONECHECKS"/>,
        /// <see cref="CMIC_MASK_PTINVOKE"/>
        /// </summary>
        public CMINVOKECOMMANDINFOMasks fMask;

        /// <summary>
        /// A handle to the window that is the owner of the shortcut menu.
        /// An extension can also use this handle as the owner of any message boxes or dialog boxes it displays.
        /// Callers must specify a legitimate HWND that can be used as the owner window for any UI that may be displayed.
        /// Failing to specify an HWND when calling from a UI thread (one with windows already created) will result in reentrancy
        /// and possible bugs in the implementation of a <see cref="IContextMenu.InvokeCommand"/> call.
        /// </summary>
        public HWND hwnd;

        /// <summary>
        /// The address of a null-terminated string that specifies the language-independent name of the command to carry out.
        /// This member is typically a string when a command is being activated by an application. 
        /// The system provides predefined constant values for the following command strings.
        /// <see cref="CMDSTR_RUNAS"/>	    "RunAs"
        /// <see cref="CMDSTR_PRINT"/>	    "Print"
        /// <see cref="CMDSTR_PREVIEW"/>	"Preview"
        /// <see cref="CMDSTR_OPEN"/>	    "Open"
        /// This is not a fixed set; new canonical verbs can be invented by context menu handlers and applications can invoke them.
        /// If a canonical verb exists and a menu handler does not implement the canonical verb,
        /// it must return a failure code to enable the next handler to be able to handle this verb.
        /// Failing to do this will break functionality in the system including <see cref="ShellExecute"/>.
        /// Alternatively, rather than a pointer, this parameter can be <code>MAKEINTRESOURCE(offset)</code>
        /// where offset is the menu-identifier offset of the command to carry out.
        /// Implementations can use the <see cref="IS_INTRESOURCE"/> macro to detect that this alternative is being employed.
        /// The Shell uses this alternative when the user chooses a menu command.
        /// </summary>
        public IntPtr lpVerb;

        /// <summary>
        /// Optional parameters.
        /// This member is always <see cref="NULL"/> for menu items inserted by a Shell extension.
        /// </summary>
        public IntPtr lpParameters;

        /// <summary>
        /// An optional working directory name.
        /// This member is always <see cref="NULL"/> for menu items inserted by a Shell extension.
        /// </summary>
        public IntPtr lpDirectory;

        /// <summary>
        /// A set of SW_ values to pass to the <see cref="ShowWindow"/> function if the command displays a window or starts an application.
        /// </summary>
        public int nShow;

        /// <summary>
        /// An optional keyboard shortcut to assign to any application activated by the command.
        /// If the <see cref="fMask"/> member does not specify <see cref="CMIC_MASK_HOTKEY"/>, this member is ignored.
        /// </summary>
        public DWORD dwHotKey;

        /// <summary>
        /// An icon to use for any application activated by the command.
        /// If the <see cref="fMask"/> member does not specify <see cref="CMIC_MASK_ICON"/>, this member is ignored.
        /// </summary>
        public HANDLE hIcon;

        /// <summary>
        /// An ASCII title.
        /// </summary>
        public IntPtr lpTitle;

        /// <summary>
        /// A Unicode verb, for those commands that can use it.
        /// </summary>
        public IntPtr lpVerbW;

        /// <summary>
        /// A Unicode parameters, for those commands that can use it.
        /// </summary>
        public IntPtr lpParametersW;

        /// <summary>
        /// A Unicode directory, for those commands that can use it.
        /// </summary>
        public IntPtr lpDirectoryW;

        /// <summary>
        /// A Unicode title.
        /// </summary>
        public IntPtr lpTitleW;

        /// <summary>
        /// The point where the command is invoked.
        /// If the <see cref="fMask"/> member does not specify <see cref="CMIC_MASK_PTINVOKE"/>, this member is ignored.
        /// This member is not valid prior to Internet Explorer 4.0.
        /// </summary>
        public POINT ptInvoke;
    }
}
