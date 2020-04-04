using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SHELLEXECUTEINFOMasks;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information used by <see cref="ShellExecuteEx"/>.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/ns-shellapi-shellexecuteinfow
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="SEE_MASK_NOASYNC"/> flag must be specified if the thread calling <see cref="ShellExecuteEx"/> does not have a message loop
    /// or if the thread or process will terminate soon after <see cref="ShellExecuteEx"/> returns.
    /// Under such conditions, the calling thread will not be available to complete the DDE conversation,
    /// so it is important that <see cref="ShellExecuteEx"/> complete the conversation before returning control to the calling application.
    /// Failure to complete the conversation can result in an unsuccessful launch of the document.
    /// If the calling thread has a message loop and will exist for some time after the call to <see cref="ShellExecuteEx"/> returns
    /// the <see cref="SEE_MASK_NOASYNC"/> flag is optional.
    /// If the flag is omitted, the calling thread's message pump will be used to complete the DDE conversation.
    /// The calling application regains control sooner, since the DDE conversation can be completed in the background.
    /// When populating the most frequently used program list using the <see cref="SEE_MASK_FLAG_LOG_USAGE"/> flag in <see cref="fMask"/>,
    /// counts are made differently for the classic and Windows XP-style Start menus.
    /// The classic style menu only counts hits to the shortcuts in the Program menu.
    /// The Windows XP-style menu counts both hits to the shortcuts in the Program menu and hits to those shortcuts' targets outside of the Program menu.
    /// Therefore, setting <see cref="lpFile"/> to myfile.exe would affect the count for the Windows XP-style menu regardless of whether
    /// that file was launched directly or through a shortcut.
    /// The classic style—which would require <see cref="lpFile"/> to contain a .lnk file name—would not be affected.
    /// To include double quotation marks in lpParameters, enclose each mark in a pair of quotation marks, as in the following example.
    /// <code>
    /// sei.lpParameters = "An example: \"\"\"quoted text\"\"\"";
    /// </code>
    /// In this case, the application receives three parameters: An, example:, and "quoted text".
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHELLEXECUTEINFO
    {
        /// <summary>
        /// Required. The size of this structure, in bytes.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// Flags that indicate the content and validity of the other structure members; a combination of the following values:
        /// <see cref="SEE_MASK_DEFAULT"/>, <see cref="SEE_MASK_CLASSNAME"/>, <see cref="SEE_MASK_CLASSKEY"/>,
        /// <see cref="SEE_MASK_IDLIST "/>, <see cref="SEE_MASK_INVOKEIDLIST"/>, <see cref="SEE_MASK_ICON"/>,
        /// <see cref="SEE_MASK_HOTKEY"/>, <see cref="SEE_MASK_NOCLOSEPROCESS"/>, <see cref="SEE_MASK_CONNECTNETDRV"/>,
        /// <see cref="SEE_MASK_NOASYNC"/>, <see cref="SEE_MASK_FLAG_DDEWAIT"/>, <see cref="SEE_MASK_DOENVSUBST"/>,
        /// <see cref="SEE_MASK_FLAG_NO_UI"/>, <see cref="SEE_MASK_UNICODE"/>, <see cref="SEE_MASK_NO_CONSOLE"/>,
        /// <see cref="SEE_MASK_ASYNCOK"/>, <see cref="SEE_MASK_NOQUERYCLASSSTORE"/>, <see cref="SEE_MASK_HMONITOR"/>,
        /// <see cref="SEE_MASK_NOZONECHECKS"/>, <see cref="SEE_MASK_WAITFORINPUTIDLE"/>, <see cref="SEE_MASK_FLAG_LOG_USAGE"/>,
        /// <see cref="SEE_MASK_FLAG_HINST_IS_SITE"/>
        /// </summary>
        public SHELLEXECUTEINFOMasks fMask;

        /// <summary>
        /// Optional.
        /// A handle to the parent window, used to display any message boxes that the system might produce while executing this function.
        /// This value can be <see cref="IntPtr.Zero"/>.
        /// </summary>
        public IntPtr hwnd;

        /// <summary>
        /// A string, referred to as a verb, that specifies the action to be performed.
        /// The set of available verbs depends on the particular file or folder.
        /// Generally, the actions available from an object's shortcut menu are available verbs.
        /// This parameter can be <see langword="null"/>, in which case the default verb is used if available.
        /// If not, the "open" verb is used. If neither verb is available, the system uses the first verb listed in the registry.
        /// The following verbs are commonly used:
        /// edit:
        /// Launches an editor and opens the document for editing.If <see cref="lpFile"/> is not a document file, the function will fail.
        /// explore:
        /// Explores the folder specified by <see cref="lpFile"/>.
        /// find:
        /// Initiates a search starting from the specified directory.
        /// open:
        /// Opens the file specified by the <see cref="lpFile"/> parameter.
        /// The file can be an executable file, a document file, or a folder.
        /// print:
        /// Prints the document file specified by <see cref="lpFile"/>.
        /// If <see cref="lpFile"/> is not a document file, the function will fail.
        /// properties:
        /// Displays the file or folder's properties.
        /// runas:
        /// Launches an application as Administrator.
        /// User Account Control (UAC) will prompt the user for consent to run the application elevated
        /// or enter the credentials of an administrator account used to run the application.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpVerb;

        /// <summary>
        /// The address of a null-terminated string that specifies the name of the file or object on which <see cref="ShellExecuteEx"/> will
        /// perform the action specified by the <see cref="lpVerb"/> parameter. 
        /// The system registry verbs that are supported by the <see cref="ShellExecuteEx"/> function include "open" for executable files and document files
        /// and "print" for document files for which a print handler has been registered
        /// Other applications might have added Shell verbs through the system registry, such as "play" for .avi and .wav files.
        /// To specify a Shell namespace object, pass the fully qualified parse name
        /// and set the <see cref="SEE_MASK_INVOKEIDLIST"/> flag in the <see cref="fMask"/> parameter.
        /// If the <see cref="SEE_MASK_INVOKEIDLIST"/> flag is set, you can use either <see cref="lpFile"/> or <see cref="lpIDList"/>
        /// to identify the item by its file system path or its PIDL respectively.
        /// One of the two values—<see cref="lpFile"/> or <see cref="lpIDList"/>—must be set.
        /// If the path is not included with the name, the current directory is assumed.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpFile;

        /// <summary>
        /// Optional.
        /// The address of a null-terminated string that contains the application parameters.
        /// The parameters must be separated by spaces.
        /// If the <see cref="lpFile"/> member specifies a document file, <see cref="lpParameters"/> should be <see cref="IntPtr.Zero"/>.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpParameters;

        /// <summary>
        /// Optional.
        /// The address of a null-terminated string that specifies the name of the working directory.
        /// If this member is <see cref="IntPtr.Zero"/>, the current directory is used as the working directory.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpDirectory;

        /// <summary>
        /// Required.
        /// Flags that specify how an application is to be shown when it is opened; one of the SW_ values listed for the <see cref="ShellExecute"/> function.
        /// If <see cref="lpFile"/> specifies a document file, the flag is simply passed to the associated application.
        /// It is up to the application to decide how to handle it.
        /// </summary>
        public ShowWindowCommands nShow;

        /// <summary>
        /// If <see cref="SEE_MASK_NOCLOSEPROCESS"/> is set and the <see cref="ShellExecuteEx"/> call succeeds, it sets this member to a value greater than 32.
        /// If the function fails, it is set to an SE_ERR_XXX error value that indicates the cause of the failure.
        /// Although <see cref="hInstApp"/> is declared as an HINSTANCE for compatibility with 16-bit Windows applications, it is not a true HINSTANCE.
        /// It can be cast only to an int and compared to either 32 or the following SE_ERR_XXX error codes.
        /// <see cref="SE_ERR_FNF"/>: File not found.
        /// <see cref="SE_ERR_PNF"/>: Path not found.
        /// <see cref="SE_ERR_ACCESSDENIED"/>: Access denied.
        /// <see cref="SE_ERR_OOM"/>: Out of memory.
        /// <see cref="SE_ERR_DLLNOTFOUND"/>: Dynamic-link library not found.
        /// <see cref="SE_ERR_SHARE"/>: Cannot share an open file.
        /// <see cref="SE_ERR_ASSOCINCOMPLETE"/>: File association information not complete.
        /// <see cref="SE_ERR_DDETIMEOUT"/>: DDE operation timed out.
        /// <see cref="SE_ERR_DDEFAIL"/>: DDE operation failed.
        /// <see cref="SE_ERR_DDEBUSY"/>: DDE operation is busy.
        /// <see cref="SE_ERR_NOASSOC"/>: File association not available.
        /// </summary>
        public IntPtr hInstApp;

        /// <summary>
        /// The address of an absolute <see cref="ITEMIDLIST"/> structure (PCIDLIST_ABSOLUTE) to contain an item identifier list
        /// that uniquely identifies the file to execute.
        /// This member is ignored if the <see cref="fMask"/> member does not include <see cref="SEE_MASK_IDLIST"/> or <see cref="SEE_MASK_INVOKEIDLIST"/>.
        /// </summary>
        public IntPtr lpIDList;

        /// <summary>
        /// The address of a null-terminated string that specifies one of the following:
        /// A ProgId. For example, "Paint.Picture".
        /// A URI protocol scheme. For example, "http".
        /// A file extension. For example, ".txt".
        /// A registry path under HKEY_CLASSES_ROOT that names a subkey that contains one or more Shell verbs.
        /// This key will have a subkey that conforms to the Shell verb registry schema, such as shell\verb name.
        /// This member is ignored if <see cref="fMask"/> does not include <see cref="SEE_MASK_CLASSNAME"/>.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpClass;

        /// <summary>
        /// A handle to the registry key for the file type.
        /// The access rights for this registry key should be set to <see cref="KEY_READ"/>.
        /// This member is ignored if <see cref="fMask"/> does not include <see cref="SEE_MASK_CLASSKEY"/>.
        /// </summary>
        public IntPtr hkeyClass;

        /// <summary>
        /// A keyboard shortcut to associate with the application.
        /// The low-order word is the virtual key code, and the high-order word is a modifier flag (HOTKEYF_).
        /// For a list of modifier flags, see the description of the <see cref="WM_SETHOTKEY"/> message.
        /// This member is ignored if <see cref="fMask"/> does not include <see cref="SEE_MASK_HOTKEY"/>.
        /// </summary>
        public uint dwHotKey;

        private UnionStruct<IntPtr, IntPtr> _union;

        /// <summary>
        /// A handle to the icon for the file type.
        /// This member is ignored if fMask does not include <see cref="SEE_MASK_ICON"/>.
        /// This value is used only in Windows XP and earlier. It is ignored as of Windows Vista.
        /// </summary>
        public IntPtr hIcon
        {
            get => _union.Struct1;
            set => _union.Struct1 = value;
        }

        /// <summary>
        /// A handle to the monitor upon which the document is to be displayed.
        /// This member is ignored if <see cref="fMask"/> does not include <see cref="SEE_MASK_HMONITOR"/>.
        /// </summary>
        public IntPtr hMonitor
        {
            get => _union.Struct1;
            set => _union.Struct1 = value;
        }

        /// <summary>
        /// A handle to the newly started application.
        /// This member is set on return and is always <see cref="IntPtr.Zero"/> unless <see cref="fMask"/> is set to <see cref="SEE_MASK_NOCLOSEPROCESS"/>.
        /// Even if <see cref="fMask"/> is set to <see cref="SEE_MASK_NOCLOSEPROCESS"/>,
        /// <see cref="hProcess"/> will be <see cref="IntPtr.Zero"/> if no process was launched.
        /// For example, if a document to be launched is a URL and an instance of Internet Explorer is already running, it will display the document.
        /// No new process is launched, and <see cref="hProcess"/> will be <see cref="IntPtr.Zero"/>.
        /// <see cref="ShellExecuteEx"/> does not always return an <see cref="hProcess"/>, even if a process is launched as the result of the call.
        /// For example, an <see cref="hProcess"/> does not return when you use <see cref="SEE_MASK_INVOKEIDLIST"/> to invoke IContextMenu.
        /// </summary>
        public IntPtr hProcess;
    }
}
