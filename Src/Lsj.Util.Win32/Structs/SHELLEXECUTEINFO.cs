using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.RegistryKeyAccessRights;
using static Lsj.Util.Win32.Enums.ShellExecuteErrorCodes;
using static Lsj.Util.Win32.Enums.ShellExecuteInfoMasks;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information used by <see cref="ShellExecuteEx"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/ns-shellapi-shellexecuteinfow"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="SEE_MASK_NOASYNC"/> flag must be specified if the thread calling <see cref="ShellExecuteEx"/> does not have a message loop
    /// or if the thread or process will terminate soon after <see cref="ShellExecuteEx"/> returns.
    /// Under such conditions, the calling thread will not be available to complete the DDE conversation,
    /// so it is important that <see cref="ShellExecuteEx"/> complete the conversation before returning control to the calling application.
    /// Failure to complete the conversation can result in an unsuccessful launch of the document.
    /// </para>
    /// <para>
    /// If the calling thread has a message loop and will exist for some time after the call to <see cref="ShellExecuteEx"/> returns,
    /// the <see cref="SEE_MASK_NOASYNC"/> flag is optional.
    /// If the flag is omitted, the calling thread's message pump will be used to complete the DDE conversation.
    /// The calling application regains control sooner, since the DDE conversation can be completed in the background.
    /// </para>
    /// <para>
    /// For calls to this API that result from user interaction specify <see cref="SEE_MASK_FLAG_LOG_USAGE"/>.
    /// </para>
    /// <para>
    /// To include double quotation marks in <see cref="lpParameters"/>, enclose each mark in a pair of quotation marks, as in the following example.
    /// </para>
    /// <code>
    /// sei.lpParameters = "An example: \"\"\"quoted text\"\"\"";
    /// </code>
    /// <para>
    /// In this case, the application receives three parameters: <c>An, example:, and "quoted text"</c>
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHELLEXECUTEINFO
    {
        /// <summary>
        /// Required. The size of this structure, in bytes.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// <para>
        /// A combination of one or more of the following values that indicate the content and validity of the other structure members:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_DEFAULT"/> (0x00000000)
        /// </term>
        /// <term>
        /// Use default values.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_CLASSNAME"/> (0x00000001)
        /// </term>
        /// <term>
        /// Use the class name given by the <see cref="lpClass"/> member.
        /// If both <see cref="SEE_MASK_CLASSKEY"/> and <see cref="SEE_MASK_CLASSNAME"/> are set, the class key is used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_CLASSKEY"/> (0x00000003)
        /// </term>
        /// <term>
        /// Use the class key given by the <see cref="hkeyClass"/> member.
        /// If both <see cref="SEE_MASK_CLASSKEY"/> and <see cref="SEE_MASK_CLASSNAME"/> are set, the class key is used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_IDLIST"/> (0x00000004)
        /// </term>
        /// <term>
        /// Use the item identifier list given by the <see cref="lpIDList"/> member.
        /// The <see cref="lpIDList"/> member must point to an <see cref="ITEMIDLIST"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_INVOKEIDLIST"/> (0x0000000C)
        /// </term>
        /// <term>
        /// <para>
        /// Use the <see cref="IContextMenu"/> interface of the selected item's shortcut menu handler.
        /// Use either <see cref="lpFile"/> to identify the item by its file system path or <see cref="lpIDList"/> to identify the item by its PIDL.
        /// This flag allows applications to use <see cref="ShellExecuteEx"/> to invoke verbs from shortcut menu extensions
        /// instead of the static verbs listed in the registry.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// <see cref="SEE_MASK_INVOKEIDLIST"/> overrides and implies <see cref="SEE_MASK_IDLIST"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_ICON"/> (0x00000010)
        /// </term>
        /// <term>
        /// <para>
        /// Use the icon given by the <see cref="hIcon"/> member.
        /// This flag cannot be combined with <see cref="SEE_MASK_HMONITOR"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This flag is used only in Windows XP and earlier. It is ignored as of Windows Vista.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_HOTKEY"/> (0x00000020)
        /// </term>
        /// <term>
        /// Use the keyboard shortcut given by the <see cref="dwHotKey"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_NOCLOSEPROCESS"/> (0x00000040)
        /// </term>
        /// <term>
        /// Use to indicate that the <see cref="hProcess"/> member receives the process handle.
        /// This handle is typically used to allow an application to find out when a process created with <see cref="ShellExecuteEx"/> terminates.
        /// In some cases, such as when execution is satisfied through a DDE conversation, no handle will be returned.
        /// The calling application is responsible for closing the handle when it is no longer needed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_CONNECTNETDRV"/> (0x00000080)
        /// </term>
        /// <term>
        /// Validate the share and connect to a drive letter.
        /// This enables reconnection of disconnected network drives.
        /// The <see cref="lpFile"/> member is a UNC path of a file on a network.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_NOASYNC"/> (0x00000100)
        /// </term>
        /// <term>
        /// <para>
        /// Only respected when launching files, does not apply to uris or shell namespace items (e.g. "This PC").
        /// Wait for the async part of the execute operation, (e.g. DDE) to complete before returning.
        /// When this applies it ensures the launching operation finishes before returning.
        /// Applications that exit immediately after calling <see cref="ShellExecuteEx"/> should specify this flag.
        /// Note, <see cref="ShellExecuteEx"/> moves its work to a background thread if the caller's threading model is not Apartment.
        /// Forcing the call to be synchronous disables that behavior and uses the callers COM apartment.
        /// Specifing <see cref="SEE_MASK_FLAG_HINST_IS_SITE"/> forces synchronous behavior always.
        /// </para>
        /// <para>
        /// If the execute operation is performed on a background thread and the caller did not specify the <see cref="SEE_MASK_ASYNCOK"/> flag,
        /// then the calling thread waits until the new process has started before returning.
        /// This typically means that either <see cref="CreateProcess"/> has been called, the DDE communication has completed,
        /// or that the custom execution delegate has notified <see cref="ShellExecuteEx"/> that it is done.
        /// If the <see cref="SEE_MASK_WAITFORINPUTIDLE"/> flag is specified,
        /// then <see cref="ShellExecuteEx"/> calls <see cref="WaitForInputIdle"/>
        /// and waits for the new process to idle before returning, with a maximum timeout of 1 minute.
        /// </para>
        /// <para>
        /// For further discussion on when this flag is necessary, see the Remarks section.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_FLAG_DDEWAIT"/> (0x00000100)
        /// </term>
        /// <term>
        /// The same as <see cref="SEE_MASK_NOASYNC"/>, use of that option is preferred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_DOENVSUBST"/> (0x00000200)
        /// </term>
        /// <term>
        /// Expand any environment variables specified in the string given by the lpDirectory or lpFile member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_FLAG_NO_UI"/> (0x00000400)
        /// </term>
        /// <term>
        /// Do not display user interface (UI) error dialogs that would normally be presented without this option.
        /// Security prompts are exempted and will still be shown.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_UNICODE"/> (0x00004000)
        /// </term>
        /// <term>
        /// Use this flag to indicate a Unicode application.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_NO_CONSOLE"/> (0x00008000)
        /// </term>
        /// <term>
        /// Use to inherit the parent's console for the new process instead of having it create a new console.
        /// It is the opposite of using a <see cref="CREATE_NEW_CONSOLE"/> flag with <see cref="CreateProcess"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_ASYNCOK"/> (0x00100000)
        /// </term>
        /// <term>
        /// The execution can be performed on a background thread and the call should return immediately without waiting for the background thread to finish. Note that in certain cases <see cref="ShellExecuteEx"/> ignores this flag and waits for the process to finish before returning.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_NOQUERYCLASSSTORE"/> (0x01000000)
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_HMONITOR"/> (0x00200000)
        /// </term>
        /// <term>
        /// Use this flag when specifying a monitor on multi-monitor systems.
        /// The monitor is specified in the <see cref="hMonitor"/> member.
        /// This flag cannot be combined with <see cref="SEE_MASK_ICON"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_NOZONECHECKS"/> (0x00800000)
        /// </term>
        /// <term>
        /// Do not perform a zone check.
        /// This flag allows <see cref="ShellExecuteEx"/> to bypass zone checking put into place by <see cref="IAttachmentExecute"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_WAITFORINPUTIDLE"/> (0x02000000)
        /// </term>
        /// <term>
        /// After the new process is created, wait for the process to become idle before returning, with a one minute timeout.
        /// See <see cref="WaitForInputIdle"/> for more details.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_FLAG_LOG_USAGE"/> (0x04000000)
        /// </term>
        /// <term>
        /// Indicates a user initiated launch that enables tracking of frequently used programs and other behaviors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEE_MASK_FLAG_HINST_IS_SITE"/> (0x08000000)
        /// </term>
        /// <term>
        /// <para>
        /// The <see cref="hInstApp"/> member is used to specify the <see cref="IUnknown"/> of an object that implements <see cref="IServiceProvider"/>.
        /// This object will be used as a site pointer.
        /// The site pointer is used to provide services to the <see cref="ShellExecuteEx"/> function,
        /// the handler binding process, and invoked verb handlers.
        /// <see cref="ICreatingProcess"/> can be provided to allow the caller to alter some parameters of the process being created.
        /// </para>
        /// <para>
        /// This flag is supported in Windows 8 and later.
        /// </para>
        /// <para>
        /// When this option is specified the call runs synchronously on the calling thread.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ShellExecuteInfoMasks fMask;

        /// <summary>
        /// Optional.
        /// A handle to the owner window, used to display and position any UI that the system might produce while executing this function.
        /// </summary>
        public HWND hwnd;

        /// <summary>
        /// <para>
        /// A string, referred to as a verb, that specifies the action to be performed.
        /// The set of available verbs depends on the particular file or folder.
        /// Generally, the actions available from an object's shortcut menu are available verbs.
        /// This parameter can be <see cref="NULL"/>, in which case the default verb is used if available.
        /// If not, the ":::no-loc text="open"::" verb is used.
        /// If neither verb is available, the system uses the first verb listed in the registry.
        /// The following verbs are commonly used:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// edit: Launches an editor and opens the document for editing.
        /// If <see cref="lpFile"/> is not a document file, the function will fail.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// explore: Explores the folder specified by <see cref="lpFile"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// find: Initiates a search starting from the specified directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// open: Opens the file specified by the <see cref="lpFile"/> parameter.
        /// The file can be an executable file, a document file, or a folder.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// openas: Launches a picker UI allowing the user to select an app with which to open the file specified by the <see cref="lpFile"/> parameter.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// print: Prints the document file specified by <see cref="lpFile"/>.
        /// If <see cref="lpFile"/> is not a document file, the function will fail.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// properties: Displays the file or folder's properties.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// runas: Launches an application as Administrator.
        /// User Account Control (UAC) will prompt the user for consent to run the application elevated
        /// or enter the credentials of an administrator account used to run the application.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public nint lpVerb;

        /// <summary>
        /// <para>
        /// The address of a null-terminated string that specifies the name of the file
        /// or object on which <see cref="ShellExecuteEx"/> will perform the action specified by the <see cref="lpVerb"/> parameter.
        /// The system registry verbs that are supported by the <see cref="ShellExecuteEx"/> function
        /// include "open" for executable files and document files and "print" for document files for which a print handler has been registered.
        /// Other applications might have added Shell verbs through the system registry, such as ":play" for .avi and .wav files.
        /// To specify a Shell namespace object, pass the fully qualified parse name
        /// and set the <see cref="SEE_MASK_INVOKEIDLIST"/> flag in the <see cref="fMask"/> parameter.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If the <see cref="SEE_MASK_INVOKEIDLIST"/> flag is set,
        /// you can use either <see cref="lpFile"/> or <see cref="lpIDList"/> to identify the item by its file system path or its PIDL respectively.
        /// One of the two values—<see cref="lpFile"/> or <see cref="lpIDList"/>—must be set.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If the path is not included with the name, the current directory is assumed.
        /// </para>
        /// </summary>
        public nint lpFile;

        /// <summary>
        /// Optional.
        /// The address of a null-terminated string that contains the application parameters.
        /// The parameters must be separated by spaces.
        /// If the <see cref="lpFile"/> member specifies a document file, <see cref="lpParameters"/> should be <see cref="NULL"/>.
        /// </summary>
        public nint lpParameters;

        /// <summary>
        /// Optional.
        /// The address of a null-terminated string that specifies the name of the working directory.
        /// If this member is <see cref="NULL"/>, the current directory is used as the working directory.
        /// </summary>
        public nint lpDirectory;

        /// <summary>
        /// Required.
        /// Flags that specify how an application is to be shown when it is opened; one of the SW_ values listed for the <see cref="ShellExecute"/> function.
        /// If <see cref="lpFile"/> specifies a document file, the flag is simply passed to the associated application.
        /// It is up to the application to decide how to handle it.
        /// </summary>
        public ShowWindowCommands nShow;

        /// <summary>
        /// <para>
        /// If <see cref="SEE_MASK_NOCLOSEPROCESS"/> is set and the <see cref="ShellExecuteEx"/> call succeeds,
        /// it sets this member to a value greater than 32.
        /// If the function fails, it is set to an SE_ERR_XXX error value that indicates the cause of the failure.
        /// Although <see cref="hInstApp"/> is declared as an <see cref="HINSTANCE"/> for compatibility
        /// with 16-bit Windows applications, it is not a true <see cref="HINSTANCE"/>.
        /// It can be cast only to an int and compared to either 32 or the following SE_ERR_XXX error codes.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Error Code
        /// </term>
        /// <term>
        /// Reason
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_FNF"/> (2)
        /// </term>
        /// <term>
        /// File not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_PNF"/> (3)
        /// </term>
        /// <term>
        /// Path not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_ACCESSDENIED"/> (5)
        /// </term>
        /// <term>
        /// Access denied.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_OOM"/> (8)
        /// </term>
        /// <term>
        /// Out of memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_DLLNOTFOUND"/> (32)
        /// </term>
        /// <term>
        /// Dynamic-link library not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_SHARE"/> (26)
        /// </term>
        /// <term>
        /// Cannot share an open file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_ASSOCINCOMPLETE"/> (27)
        /// </term>
        /// <term>
        /// File association information not complete.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_DDETIMEOUT"/> (28)
        /// </term>
        /// <term>
        /// DDE operation timed out.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_DDEFAIL"/> (29)
        /// </term>
        /// <term>
        /// DDE operation failed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_DDEBUSY"/> (30)
        /// </term>
        /// <term>
        /// DDE operation is busy.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_NOASSOC"/> (31)
        /// </term>
        /// <term>
        /// File association not available.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public HINSTANCE hInstApp;

        /// <summary>
        /// The address of an absolute <see cref="ITEMIDLIST"/> structure (PCIDLIST_ABSOLUTE) to contain an item identifier list
        /// that uniquely identifies the file to execute.
        /// This member is ignored if the <see cref="fMask"/> member does not include <see cref="SEE_MASK_IDLIST"/> or <see cref="SEE_MASK_INVOKEIDLIST"/>.
        /// </summary>
        public nint lpIDList;

        /// <summary>
        /// <para>
        /// The address of a null-terminated string that specifies one of the following:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// A ProgId. For example, "Paint.Picture".
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A URI protocol scheme. For example, "http".
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A file extension. For example, ".txt".
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A registry path under HKEY_CLASSES_ROOT that names a subkey that contains one or more Shell verbs.
        /// This key will have a subkey that conforms to the Shell verb registry schema, such as shell\verb name.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// This member is ignored if <see cref="fMask"/> does not include <see cref="SEE_MASK_CLASSNAME"/>.
        /// </para>
        /// </summary>
        public nint lpClass;

        /// <summary>
        /// A handle to the registry key for the file type.
        /// The access rights for this registry key should be set to <see cref="KEY_READ"/>.
        /// This member is ignored if <see cref="fMask"/> does not include <see cref="SEE_MASK_CLASSKEY"/>.
        /// </summary>
        public HKEY hkeyClass;

        /// <summary>
        /// A keyboard shortcut to associate with the application.
        /// The low-order word is the virtual key code, and the high-order word is a modifier flag (HOTKEYF_).
        /// For a list of modifier flags, see the description of the <see cref="WM_SETHOTKEY"/> message.
        /// This member is ignored if <see cref="fMask"/> does not include <see cref="SEE_MASK_HOTKEY"/>.
        /// </summary>
        public DWORD dwHotKey;

        private SHELLEXECUTEINFO_DUMMYUNIONNAME _union;

#pragma warning disable IDE1006
        /// <summary>
        /// A handle to the icon for the file type.
        /// This member is ignored if fMask does not include <see cref="SEE_MASK_ICON"/>.
        /// This value is used only in Windows XP and earlier. It is ignored as of Windows Vista.
        /// </summary>

        public HANDLE hIcon
        {
            get => _union.hIcon;
            set => _union.hIcon = value;
        }

        /// <summary>
        /// A handle to the monitor upon which the document is to be displayed.
        /// This member is ignored if <see cref="fMask"/> does not include <see cref="SEE_MASK_HMONITOR"/>.
        /// </summary>
        public HANDLE hMonitor
        {
            get => _union.hMonitor;
            set => _union.hMonitor = value;
        }
#pragma warning restore IDE1006

        /// <summary>
        /// <para>
        /// A handle to the newly started application.
        /// This member is set on return and is always <see cref="NULL"/> unless <see cref="fMask"/> is set to <see cref="SEE_MASK_NOCLOSEPROCESS"/>.
        /// Even if <see cref="fMask"/> is set to <see cref="SEE_MASK_NOCLOSEPROCESS"/>,
        /// <see cref="hProcess"/> will be <see cref="NULL"/> if no process was launched.
        /// For example, if a document to be launched is a URL and an instance of Internet Explorer is already running, it will display the document.
        /// No new process is launched, and <see cref="hProcess"/> will be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// <see cref="ShellExecuteEx"/> does not always return an <see cref="hProcess"/>, even if a process is launched as the result of the call.
        /// For example, an <see cref="hProcess"/> does not return when you use <see cref="SEE_MASK_INVOKEIDLIST"/> to invoke <see cref="IContextMenu"/>.
        /// </para>
        /// </summary>
        public HANDLE hProcess;

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct SHELLEXECUTEINFO_DUMMYUNIONNAME
        {
            [FieldOffset(0)]
            public HANDLE hIcon;

            [FieldOffset(0)]
            public HANDLE hMonitor;
        }
    }
}
