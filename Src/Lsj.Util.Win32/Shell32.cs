using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ShowWindowCommands;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ShellExecuteErrorCodes;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.User32;
using System.Text;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Shell32.dll
    /// </summary>
    public static class Shell32
    {
        /// <summary>
        /// <para>
        /// Parses a Unicode command line string and returns an array of pointers to the command line arguments,
        /// along with a count of such arguments, in a way that is similar to the standard C run-time argv and argc values.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-commandlinetoargvw
        /// </para>
        /// </summary>
        /// <param name="lpCmdLine">
        /// Pointer to a null-terminated Unicode string that contains the full command line.
        /// If this parameter is an empty string the function returns the path to the current executable file.
        /// </param>
        /// <param name="pNumArgs">
        /// Pointer to an int that receives the number of array elements returned, similar to argc.
        /// </param>
        /// <returns>
        /// A pointer to an array of LPWSTR values, similar to argv.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The address returned by <see cref="CommandLineToArgvW"/> is the address of the first element in an array of LPWSTR values;
        /// the number of pointers in this array is indicated by <paramref name="pNumArgs"/>.
        /// Each pointer to a null-terminated Unicode string represents an individual argument found on the command line.
        /// <see cref="CommandLineToArgvW"/> allocates a block of contiguous memory for pointers to the argument strings,
        /// and for the argument strings themselves; the calling application must free the memory used by the argument list when it is no longer needed.
        /// To free the memory, use a single call to the <see cref="LocalFree"/> function.
        /// For more information about the argv and argc argument convention, see Argument Definitions and Parsing C++ Command-Line Arguments.
        /// The <see cref="GetCommandLine"/> function can be used to get a command line string
        /// that is suitable for use as the <paramref name="lpCmdLine"/> parameter.
        /// This function accepts command lines that contain a program name; the program name can be enclosed in quotation marks or not.
        /// <see cref="CommandLineToArgvW"/> has a special interpretation of backslash characters when they are followed by a quotation mark character (").
        /// This interpretation assumes that any preceding argument is a valid file system path, or else it may behave unpredictably.
        /// This special interpretation controls the "in quotes" mode tracked by the parser. When this mode is off, whitespace terminates the current argument.
        /// When on, whitespace is added to the argument like all other characters.
        /// 2n backslashes followed by a quotation mark produce n backslashes followed by begin/end quote. This does not become part of the parsed argument,
        /// but toggles the "in quotes" mode.
        /// (2n) + 1 backslashes followed by a quotation mark again produce n backslashes followed by a quotation mark literal (").
        /// This does not toggle the "in quotes" mode.
        /// n backslashes not followed by a quotation mark simply produce n backslashes.
        /// <see cref="CommandLineToArgvW"/> treats whitespace outside of quotation marks as argument delimiters.
        /// However, if <paramref name="lpCmdLine"/> starts with any amount of whitespace,
        /// <see cref="CommandLineToArgvW"/> will consider the first argument to be an empty string.
        /// Excess whitespace at the end of <paramref name="lpCmdLine"/> is ignored.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "CommandLineToArgvW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CommandLineToArgvW(StringHandle lpCmdLine, [Out] out int pNumArgs);

        /// <summary>
        /// <para>
        /// Retrieves the application-defined, explicit Application User Model ID (AppUserModelID) for the current process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nf-shobjidl_core-getcurrentprocessexplicitappusermodelid
        /// </para>
        /// </summary>
        /// <param name="AppID">
        /// A pointer that receives the address of the AppUserModelID assigned to the process.
        /// The caller is responsible for freeing this string with <see cref="CoTaskMemFree"/> when it is no longer needed.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The AppUserModelID retrieved by this function was set earlier through <see cref="SetCurrentProcessExplicitAppUserModelID"/>.
        /// An application can only retrieve an AppUserModelID that has been explicitly set. System-assigned default AppUserModelIDs cannot be retrieved.
        /// If the application requires knowledge of its AppUserModelID it should set one explicitly.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcessExplicitAppUserModelID", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT GetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)][Out] StringBuilder AppID);

        /// <summary>
        /// <para>
        /// Specifies a unique application-defined Application User Model ID (AppUserModelID) that identifies the current process to the taskbar.
        /// This identifier allows an application to group its associated processes and windows under a single taskbar button.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nf-shobjidl_core-setcurrentprocessexplicitappusermodelid
        /// </para>
        /// </summary>
        /// <param name="AppID">
        /// Pointer to the AppUserModelID to assign to the current process.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method must be called during an application's initial startup routine
        /// before the application presents any UI or makes any manipulation of its Jump Lists.
        /// This includes any call to <see cref="SHAddToRecentDocs"/>.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCurrentProcessExplicitAppUserModelID", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)][In] string AppID);

        /// <summary>
        /// <para>
        /// Performs an operation on a specified file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-shellexecutew
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the parent window used for displaying a UI or error messages.
        /// This value can be <see cref="NULL"/> if the operation is not associated with a window.
        /// </param>
        /// <param name="lpOperation">
        /// A pointer to a null-terminated string, referred to in this case as a verb, that specifies the action to be performed.
        /// The set of available verbs depends on the particular file or folder.
        /// Generally, the actions available from an object's shortcut menu are available verbs.
        /// The following verbs are commonly used:
        /// edit:
        /// Launches an editor and opens the document for editing. If <paramref name="lpFile"/> is not a document file, the function will fail.
        /// explore:
        /// Explores a folder specified by <paramref name="lpFile"/>.
        /// find:
        /// Initiates a search beginning in the directory specified by <paramref name="lpDirectory"/>.
        /// open:
        /// Opens the item specified by the <paramref name="lpFile"/> parameter. The item can be a file or folder.
        /// print:
        /// Prints the file specified by <paramref name="lpFile"/>. If <paramref name="lpFile"/> is not a document file, the function fails.
        /// runas:
        /// Launches an application as Administrator.
        /// User Account Control (UAC) will prompt the user for consent to run the application elevated or enter
        /// the credentials of an administrator account used to run the application.
        /// <see langword="null"/>:
        /// The default verb is used, if available.
        /// If not, the "open" verb is used. If neither verb is available, the system uses the first verb listed in the registry.
        /// </param>
        /// <param name="lpFile">
        /// A pointer to a null-terminated string that specifies the file or object on which to execute the specified verb.
        /// To specify a Shell namespace object, pass the fully qualified parse name.
        /// Note that not all verbs are supported on all objects. For example, not all document types support the "print" verb.
        /// If a relative path is used for the <paramref name="lpDirectory"/> parameter do not use a relative path for <paramref name="lpFile"/>.
        /// </param>
        /// <param name="lpParameters">
        /// If <paramref name="lpFile"/> specifies an executable file, this parameter is a pointer to a null-terminated string
        /// that specifies the parameters to be passed to the application.
        /// The format of this string is determined by the verb that is to be invoked.
        /// If <paramref name="lpFile"/> specifies a document file, <paramref name="lpParameters"/> should be <see langword="null"/>.
        /// </param>
        /// <param name="lpDirectory">
        /// A pointer to a null-terminated string that specifies the default (working) directory for the action.
        /// If this value is <see langword="null"/>, the current working directory is used.
        /// If a relative path is provided at <paramref name="lpFile"/>, do not use a relative path for <paramref name="lpDirectory"/>.
        /// </param>
        /// <param name="nShowCmd">
        /// The flags that specify how an application is to be displayed when it is opened.
        /// If <paramref name="lpFile"/> specifies a document file, the flag is simply passed to the associated application.
        /// It is up to the application to decide how to handle it.
        /// These values are defined in Winuser.h.
        /// <see cref="SW_HIDE"/>:
        /// Hides the window and activates another window.
        /// <see cref="SW_MAXIMIZE"/>:
        /// Maximizes the specified window.
        /// <see cref="SW_MINIMIZE"/>:
        /// Minimizes the specified window and activates the next top-level window in the z-order.
        /// <see cref="SW_RESTORE"/>:
        /// Activates and displays the window. If the window is minimized or maximized, Windows restores it to its original size and position.
        /// An application should specify this flag when restoring a minimized window.
        /// <see cref="SW_SHOW"/>:
        /// Activates the window and displays it in its current size and position.
        /// <see cref="SW_SHOWDEFAULT"/>:
        /// Sets the show state based on the SW_ flag specified in the <see cref="STARTUPINFO"/> structure
        /// passed to the <see cref="CreateProcess"/> function by the program that started the application.
        /// An application should call <see cref="ShowWindow"/> with this flag to set the initial show state of its main window.
        /// <see cref="SW_SHOWMAXIMIZED"/>:
        /// Activates the window and displays it as a maximized window.
        /// <see cref="SW_SHOWMINIMIZED"/>:
        /// Activates the window and displays it as a minimized window.
        /// <see cref="SW_SHOWMINNOACTIVE"/>:
        /// Displays the window as a minimized window. The active window remains active.
        /// <see cref="SW_SHOWNA"/>:
        /// Displays the window in its current state. The active window remains active.
        /// <see cref="SW_SHOWNOACTIVATE"/>:
        /// Displays a window in its most recent size and position. The active window remains active.
        /// <see cref="SW_SHOWNORMAL"/>:
        /// Activates and displays a window. If the window is minimized or maximized, Windows restores it to its original size and position.
        /// An application should specify this flag when displaying the window for the first time.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a value greater than 32.
        /// If the function fails, it returns an error value that indicates the cause of the failure.
        /// The return value is cast as an <see cref="HINSTANCE"/> for backward compatibility with 16-bit Windows applications.
        /// It is not a true <see cref="HINSTANCE"/>, however. It can be cast only to an int and compared to either 32 or the following error codes below.
        /// 0: The operating system is out of memory or resources.
        /// <see cref="ERROR_FILE_NOT_FOUND"/>: The specified file was not found.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>: The specified path was not found.
        /// <see cref="ERROR_BAD_FORMAT"/>: The.exe file is invalid (non-Win32 .exe or error in .exe image).
        /// <see cref="SE_ERR_ACCESSDENIED"/>: The operating system denied access to the specified file.
        /// <see cref="SE_ERR_ASSOCINCOMPLETE"/>: The file name association is incomplete or invalid.
        /// <see cref="SE_ERR_DDEBUSY"/>: The DDE transaction could not be completed because other DDE transactions were being processed.
        /// <see cref="SE_ERR_DDEFAIL"/>: The DDE transaction failed.
        /// <see cref="SE_ERR_DDETIMEOUT"/>: The DDE transaction could not be completed because the request timed out.
        /// <see cref="SE_ERR_DLLNOTFOUND"/>: The specified DLL was not found.
        /// <see cref="SE_ERR_FNF"/>: The specified file was not found.
        /// <see cref="SE_ERR_NOASSOC"/>:
        /// There is no application associated with the given file name extension.
        /// This error will also be returned if you attempt to print a file that is not printable.
        /// <see cref="SE_ERR_OOM"/>: There was not enough memory to complete the operation.
        /// <see cref="SE_ERR_PNF"/>: The specified path was not found.
        /// <see cref="SE_ERR_SHARE"/>: A sharing violation occurred.
        /// </returns>
        /// <remarks>
        /// Because <see cref="ShellExecute"/> can delegate execution to Shell extensions
        /// (data sources, context menu handlers, verb implementations)
        /// that are activated using Component Object Model (COM), COM should be initialized before <see cref="ShellExecute"/> is called.
        /// Some Shell extensions require the COM single-threaded apartment (STA) type.
        /// In that case, COM should be initialized as shown here:
        /// <code>
        /// CoInitializeEx(NULL, COINIT_APARTMENTTHREADED | COINIT_DISABLE_OLE1DDE)
        /// </code>
        /// There are certainly instances where <see cref="ShellExecute"/> does not use one of these types of Shell extension
        /// and those instances would not require COM to be initialized at all.
        /// Nonetheless, it is good practice to always initalize COM before using this function.
        /// This method allows you to execute any commands in a folder's shortcut menu or stored in the registry.
        /// To open a folder, use either of the following calls:
        /// <code>
        /// ShellExecute(handle, NULL, &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, SW_SHOWNORMAL);
        /// </code>
        /// or
        /// <code>
        /// ShellExecute(handle, "open", &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, SW_SHOWNORMAL);
        /// </code>
        /// To explore a folder, use the following call:
        /// <code>
        /// ShellExecute(handle, "explore", &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, SW_SHOWNORMAL);
        /// </code>
        /// To launch the Shell's Find utility for a directory, use the following call.
        /// <code>
        /// ShellExecute(handle, "find", &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, 0);
        /// </code>
        /// If <paramref name="lpOperation"/> is <see langword="null"/>, the function opens the file specified by <paramref name="lpFile"/>.
        /// If <paramref name="lpOperation"/> is "open" or "explore", the function attempts to open or explore the folder.
        /// To obtain information about the application that is launched as a result of calling <see cref="ShellExecute"/>, use <see cref="ShellExecuteEx"/>.
        /// Note
        /// The Launch folder windows in a separate process setting in Folder Options affects <see cref="ShellExecute"/>.
        /// If that option is disabled (the default setting), <see cref="ShellExecute"/> uses an open Explorer window rather than launch a new one.
        /// If no Explorer window is open, <see cref="ShellExecute"/> launches a new one.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShellExecuteW", ExactSpelling = true, SetLastError = true)]
        public static extern HINSTANCE ShellExecute([In] HWND hwnd, [MarshalAs(UnmanagedType.LPWStr)][In] string lpOperation,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpFile, [MarshalAs(UnmanagedType.LPWStr)][In] string lpParameters,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpDirectory, [In] ShowWindowCommands nShowCmd);

        /// <summary>
        /// <para>
        /// Performs an operation on a specified file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-shellexecuteexw
        /// </para>
        /// </summary>
        /// <param name="pExecInfo">
        /// A pointer to a <see cref="SHELLEXECUTEINFO"/> structure that contains and receives information about the application being executed.
        /// </param>
        /// <returns>
        /// Returns <see langword="true"/> if successful; otherwise, <see langword="false"/>.
        /// Call <see cref="GetLastError"/> for extended error information.
        /// </returns>
        /// <remarks>
        /// Because <see cref="ShellExecuteEx"/> can delegate execution to Shell extensions (data sources, context menu handlers, verb implementations)
        /// that are activated using Component Object Model (COM), COM should be initialized before <see cref="ShellExecuteEx"/> is called.
        /// Some Shell extensions require the COM single-threaded apartment (STA) type.
        /// In that case, COM should be initialized as shown here:
        /// <code>
        /// CoInitializeEx(NULL, COINIT_APARTMENTTHREADED | COINIT_DISABLE_OLE1DDE)
        /// </code>
        /// There are instances where <see cref="ShellExecuteEx"/> does not use one of these types of Shell extension and those instances
        /// would not require COM to be initialized at all.
        /// Nonetheless, it is good practice to always initalize COM before using this function.
        /// When DLLs are loaded into your process, you acquire a lock known as a loader lock.
        /// The DllMain function always executes under the loader lock.
        /// It is important that you do not call <see cref="ShellExecuteEx"/> while you hold a loader lock.
        /// Because <see cref="ShellExecuteEx"/> is extensible, you could load code that does not function properly in the presence of a loader lock,
        /// risking a deadlock and therefore an unresponsive thread.
        /// With multiple monitors, if you specify an HWND and set the <see cref="SHELLEXECUTEINFO.lpVerb"/> member 
        /// of the <see cref="SHELLEXECUTEINFO"/> structure pointed to by <paramref name="pExecInfo"/> to "Properties",
        /// any windows created by <see cref="ShellExecuteEx"/> might not appear in the correct position.
        /// If the function succeeds, it sets the <see cref="SHELLEXECUTEINFO.hInstApp"/> member
        /// of the <see cref="SHELLEXECUTEINFO"/> structure to a value greater than 32.
        /// If the function fails, <see cref="SHELLEXECUTEINFO.hInstApp"/> is set to the SE_ERR_XXX error value that best indicates the cause of the failure.
        /// Although <see cref="SHELLEXECUTEINFO.hInstApp"/> is declared as an HINSTANCE for compatibility with 16-bit Windows applications,
        /// it is not a true HINSTANCE.
        /// It can be cast only to an int and can be compared only to either the value 32 or the SE_ERR_XXX error codes.
        /// The SE_ERR_XXX error values are provided for compatibility with <see cref="ShellExecute"/>.
        /// To retrieve more accurate error information, use <see cref="GetLastError"/>.
        /// It may return one of the following values.
        /// <see cref="ERROR_FILE_NOT_FOUND"/>: The specified file was not found.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>: The specified path was not found.
        /// <see cref="ERROR_DDE_FAIL"/>: The Dynamic Data Exchange(DDE) transaction failed.
        /// <see cref="ERROR_NO_ASSOCIATION"/>: There is no application associated with the specified file name extension.
        /// <see cref="ERROR_ACCESS_DENIED"/>: Access to the specified file is denied.
        /// <see cref="ERROR_DLL_NOT_FOUND"/>: One of the library files necessary to run the application can't be found.
        /// <see cref="ERROR_CANCELLED"/>: The function prompted the user for additional information, but the user canceled the request.
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>: There is not enough memory to perform the specified action.
        /// <see cref="ERROR_SHARING_VIOLATION"/>: A sharing violation occurred.
        /// Opening items from a URL You can register your application to activate when passed URLs.
        /// You can also specify which protocols your application supports. See Application Registration for more info.
        /// Site chain support As of Windows 8, you can provide a site chain pointer to the <see cref="ShellExecuteEx"/> function 
        /// to support item activation with services from that site.
        /// See Launching Applications(<see cref="ShellExecute"/>, <see cref="ShellExecuteEx"/>, <see cref="SHELLEXECUTEINFO"/>) for more information.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShellExecuteExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ShellExecuteEx([In][Out] ref SHELLEXECUTEINFO pExecInfo);

        /// <summary>
        /// <para>
        /// Retrieves information about system-defined Shell icons.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-shgetstockiconinfo
        /// </para>
        /// </summary>
        /// <param name="siid">
        /// One of the values from the <see cref="SHSTOCKICONID"/> enumeration that specifies which icon should be retrieved.
        /// </param>
        /// <param name="uFlags">
        /// A combination of zero or more of the following flags that specify which information is requested.
        /// </param>
        /// <param name="psii">
        /// A pointer to a <see cref="SHSTOCKICONINFO"/> structure.
        /// When this function is called, the <see cref="SHSTOCKICONINFO.cbSize"/> member of this structure needs to be
        /// set to the size of the <see cref="SHSTOCKICONINFO"/> structure.
        /// When this function returns, contains a pointer to a <see cref="SHSTOCKICONINFO"/> structure that contains the requested information.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// If this function returns an icon handle in the <see cref="SHSTOCKICONINFO.hIcon"/> member of the <see cref="SHSTOCKICONINFO"/> structure
        /// pointed to by <paramref name="psii"/>, you are responsible for freeing the icon with <see cref="DestroyIcon"/> when you no longer need it.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetStockIconInfo", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SHGetStockIconInfo([In] SHSTOCKICONID siid, [In] SHGetStockIconInfoFlags uFlags, [Out] out SHSTOCKICONINFO psii);
    }
}
