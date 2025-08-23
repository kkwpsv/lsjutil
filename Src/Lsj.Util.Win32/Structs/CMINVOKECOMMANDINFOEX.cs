using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CommandStrings;
using static Lsj.Util.Win32.Enums.CommandMenuInvokeCommandInfoMasks;
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
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/ns-shobjidl_core-cminvokecommandinfoex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Although the <see cref="IContextMenu.InvokeCommand"/> declaration specifies a <see cref="CMINVOKECOMMANDINFO"/> structure for the pici parameter,
    /// it can also accept a <see cref="CMINVOKECOMMANDINFOEX"/> structure.
    /// If you are implementing this method, you must inspect <see cref="cbSize"/> to determine which structure has been passed.
    /// </para>
    /// <para>
    /// By default, all 16-bit Windows-based applications run as threads in a single, shared VDM.
    /// The advantage of running separately is that a crash only terminates the single VDM;
    /// any other programs running in distinct VDMs continue to function normally.
    /// Also, 16-bit Windows-based applications that are run in separate VDMs have separate input queues.
    /// That means that if one application stops responding momentarily, applications in separate VDMs continue to receive input.
    /// The disadvantage of running separately is that it takes significantly more memory to do so.
    /// </para>
    /// <para>
    /// <see cref="CMINVOKECOMMANDINFOEX"/> itself is defined in Shobjidl.h, but you must also include Shellapi.h to have full access to all flags.
    /// </para>
    /// <para>
    /// Note  Prior to Windows Vista, this structure was declared in Shlobj.h.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CMINVOKECOMMANDINFOEX
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// This member should be filled in by callers of <see cref="IContextMenu::InvokeCommand"/>
        /// and tested by the implementations to know that the structure is a <see cref="CMINVOKECOMMANDINFOEX"/> structure rather than <see cref="CMINVOKECOMMANDINFO"/>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// <para>
        /// Zero, or one or more of the following flags are set to indicate desired behavior and indicate that other fields in the structure are to be used.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_HOTKEY"/>
        /// </para>
        /// <para>
        /// The <see cref="dwHotKey"/> member is valid.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_ICON"/>
        /// </para>
        /// <para>
        /// The <see cref="hIcon"/> member is valid. As of Windows Vista this flag is not used.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_FLAG_NO_UI"/>
        /// </para>
        /// <para>
        /// The implementation of <see cref="IContextMenu.InvokeCommand"/> is prevented from displaying user interface elements
        /// (for example, error messages) while carrying out a command.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_UNICODE"/>
        /// </para>
        /// <para>
        /// The shortcut menu handler should use <see cref="lpVerbW"/>, <see cref="lpParametersW"/>, <see cref="lpDirectoryW"/>,
        /// and <see cref="lpTitleW"/> members instead of their ANSI equivalents.
        /// Because some shortcut menu handlers may not support Unicode, you should also pass valid ANSI strings in the <see cref="lpVerb"/>,
        /// <see cref="lpParameters"/>, <see cref="lpDirectory"/>, and <see cref="lpTitle"/> members.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_NO_CONSOLE"/>
        /// </para>
        /// <para>
        /// If a shortcut menu handler needs to create a new process, it will normally create a new console.
        /// Setting the <see cref="CMIC_MASK_NO_CONSOLE"/> flag suppresses the creation of a new console.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_HASLINKNAME"/>
        /// </para>
        /// <para>
        /// The <see cref="lpTitle"/> member contains a full path to a shortcut file.
        /// Use in conjunction with <see cref="CMIC_MASK_HASTITLE"/>.
        /// <para>
        /// Note This value is not supported in Windows Vista and later systems.
        /// </para>
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_HASTITLE"/>
        /// </para>
        /// <para>
        /// The <see cref="lpTitle"/> member is valid.
        /// </para>
        /// <para>
        /// Note This value is not supported in Windows Vista and later systems.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_FLAG_SEP_VDM"/>
        /// </para>
        /// <para>
        /// This flag is valid only when referring to a 16-bit Windows-based application.
        /// If set, the application that the shortcut points to runs in a private Virtual DOS Machine (VDM). See Remarks.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_ASYNCOK"/>
        /// </para>
        /// <para>
        /// The implementation of <see cref="IContextMenu.InvokeCommand"/> can spin off a new thread or process 
        /// to handle the call and does not need to block on completion of the function being invoked.
        /// For example, if the verb is "delete" the <see cref="IContextMenu.InvokeCommand"/> call may return before all of the items have been deleted.
        /// Since this is advisory, calling applications that specify this flag cannot guarantee
        /// that this request will be honored if they are not familiar with the implementation of the verb that they are invoking.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_NOASYNC"/>
        /// </para>
        /// <para>
        /// Windows Vista and later.
        /// The implementation of <see cref="IContextMenu.InvokeCommand"/> should be synchronous, not returning before it is complete.
        /// Since this is recommended, calling applications that specify this flag cannot guarantee
        /// that this request will be honored if they are not familiar with the implementation of the verb that they are invoking.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_SHIFT_DOWN"/>
        /// </para>
        /// <para>
        /// The SHIFT key is pressed.
        /// Use this instead of polling the current state of the keyboard that may have changed since the verb was invoked.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_CONTROL_DOWN"/>
        /// </para>
        /// <para>
        /// The CTRL key is pressed.
        /// Use this instead of polling the current state of the keyboard that may have changed since the verb was invoked.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_FLAG_LOG_USAGE"/>
        /// </para>
        /// <para>
        /// Indicates that the implementation of <see cref="IContextMenu.InvokeCommand"/> might
        /// want to keep track of the item being invoked for features like the "Recent documents" menu.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_NOZONECHECKS"/>
        /// </para>
        /// <para>
        /// Do not perform a zone check.
        /// This flag allows <see cref="ShellExecuteEx"/> to bypass zone checking put into place by <see cref="IAttachmentExecute"/>.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_PTINVOKE"/>
        /// </para>
        /// <para>
        /// The <see cref="ptInvoke"/> member is valid.
        /// </para>
        /// </summary>
        public CommandMenuInvokeCommandInfoMasks fMask;

        /// <summary>
        /// A handle to the window that is the owner of the shortcut menu.
        /// An extension can also use this handle as the owner of any message boxes or dialog boxes it displays.
        /// Callers must specify a legitimate HWND that can be used as the owner window for any UI that may be displayed.
        /// Failing to specify an HWND when calling from a UI thread (one with windows already created) will result in reentrancy
        /// and possible bugs in the implementation of a <see cref="IContextMenu.InvokeCommand"/> call.
        /// </summary>
        public HWND hwnd;

        /// <summary>
        /// <para>
        /// The address of a null-terminated string that specifies the language-independent name of the command to carry out.
        /// This member is typically a string when a command is being activated by an application.
        /// The system provides predefined constant values for the following command strings.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Constant
        /// </term>
        /// <term>
        /// Command string
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CMDSTR_RUNAS"/>
        /// </term>
        /// <term>
        /// "RunAs"
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CMDSTR_PRINT"/>
        /// </term>
        /// <term>
        /// "Print"
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CMDSTR_PREVIEW"/>
        /// </term>
        /// <term>
        /// "Preview"
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CMDSTR_OPEN"/>
        /// </term>
        /// <term>
        /// "Open"
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is not a fixed set; new canonical verbs can be invented by context menu handlers and applications can invoke them.
        /// </para>
        /// <para>
        /// If a canonical verb exists and a menu handler does not implement the canonical verb,
        /// it must return a failure code to enable the next handler to be able to handle this verb.
        /// Failing to do this will break functionality in the system including <see cref="ShellExecute"/>.
        /// </para>
        /// <para>
        /// Alternatively, rather than a pointer, this parameter can be <code>MAKEINTRESOURCE(offset)</code>
        /// where offset is the menu-identifier offset of the command to carry out.
        /// Implementations can use the <see cref="IS_INTRESOURCE"/> macro to detect that this alternative is being employed.
        /// The Shell uses this alternative when the user chooses a menu command.
        /// </para>
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
