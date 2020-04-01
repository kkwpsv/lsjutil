using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using Lsj.Util.Win32.BaseTypes;

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
        public static extern IntPtr CommandLineToArgvW(StringHandle lpCmdLine, [Out]out int pNumArgs);

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
        public static extern HRESULT GetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)][Out]string AppID);

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
        /// If this function returns an icon handle in the <see cref="hIcon"/> member of the <see cref="SHSTOCKICONINFO"/> structure
        /// pointed to by <paramref name="psii"/>, you are responsible for freeing the icon with <see cref="DestroyIcon"/> when you no longer need it.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetStockIconInfo", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SHGetStockIconInfo([In]SHSTOCKICONID siid, [In]SHGetStockIconInfoFlags uFlags, [Out]out SHSTOCKICONINFO psii);
    }
}
