using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CMDSTR;
using static Lsj.Util.Win32.Enums.CMIC_MASK;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information needed by <see cref="IContextMenu.InvokeCommand"/> to invoke a shortcut menu command.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/ns-shobjidl_core-cminvokecommandinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Although the <see cref="IContextMenu.InvokeCommand"/> declaration specifies a <see cref="CMINVOKECOMMANDINFO"/> structure for the pici parameter,
    /// it can also accept a <see cref="CMINVOKECOMMANDINFOEX"/> structure.
    /// If you are implementing this method, you must inspect <see cref="cbSize"/> to determine which structure has been passed.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CMINVOKECOMMANDINFO
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public DWORD cbSize;

        /// <para>
        /// Zero, or one or more of the following flags.
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
        /// The system is prevented from displaying user interface elements (for example, error messages) while carrying out a command.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_NO_CONSOLE"/>
        /// </para>
        /// <para>
        /// If a shortcut menu handler needs to create a new process, it will normally create a new console.
        /// Setting the <see cref="CMIC_MASK_NO_CONSOLE"/> flag suppresses the creation of a new console.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_FLAG_SEP_VDM"/>
        /// </para>
        /// <para>
        /// This flag is valid only when referring to a 16-bit Windows-based application.
        /// If set, the application that the shortcut points to runs in a private Virtual DOS Machine (VDM).
        /// See Remarks.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_ASYNCOK"/>
        /// </para>
        /// <para>
        /// Wait for the DDE conversation to terminate before returning.
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
        /// Indicates that the implementation of <see cref="IContextMenu.InvokeCommand"/> might want to keep track of the item
        /// being invoked for features like the "Recent documents" menu.
        /// </para>
        /// <para>
        /// <see cref="CMIC_MASK_NOZONECHECKS"/>
        /// </para>
        /// <para>
        /// Do not perform a zone check.
        /// This flag allows <see cref="ShellExecuteEx"/> to bypass zone checking put into place by <see cref="IAttachmentExecute"/>.
        /// </para>

        public CMIC_MASK fMask;

        /// <summary>
        /// A handle to the window that is the owner of the shortcut menu.
        /// An extension can also use this handle as the owner of any message boxes or dialog boxes it displays.
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
        /// An optional string containing parameters that are passed to the command.
        /// The format of this string is determined by the command that is to be invoked.
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
    }
}
