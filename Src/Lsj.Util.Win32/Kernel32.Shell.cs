using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Retrieves the command-line string for the current process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processenv/nf-processenv-getcommandlinew
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a pointer to the command-line string for the current process.
        /// </returns>
        /// <remarks>
        /// ANSI console processes written in C can use the argc and argv arguments of the main function to access the command-line arguments.
        /// ANSI GUI applications can use the lpCmdLine parameter of the WinMain function to access the command-line string, excluding the program name.
        /// The main and WinMain functions cannot return Unicode strings.
        /// Unicode console process written in C can use the wmain or _tmain function to access the command-line arguments.
        /// Unicode GUI applications must use the <see cref="GetCommandLine"/> function to access Unicode strings.
        /// To convert the command line to an argv style array of strings, call the <see cref="CommandLineToArgvW"/> function.
        /// The name of the executable in the command line that the operating system provides to a process is not necessarily identical
        /// to that in the command line that the calling process gives to the <see cref="CreateProcess"/> function.
        /// The operating system may prepend a fully qualified path to an executable name that is provided without a fully qualified path.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCommandLineW", SetLastError = true)]
        public static extern StringHandle GetCommandLine();

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShellExecuteExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShellExecuteEx([In][Out]ref SHELLEXECUTEINFO pExecInfo);
    }
}
