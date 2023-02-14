using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.STARTUPINFOFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Expands environment-variable strings and replaces them with the values defined for the current user.
        /// To specify the environment block for a particular user or the system, use the ExpandEnvironmentStringsForUser function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-expandenvironmentstringsw"/>
        /// </para>
        /// </summary>
        /// <param name="lpSrc">
        /// A buffer that contains one or more environment-variable strings in the form: %variableName%.
        /// For each such reference, the %variableName% portion is replaced with the current value of that environment variable.
        /// Case is ignored when looking up the environment-variable name.
        /// If the name is not found, the %variableName% portion is left unexpanded.
        /// Note that this function does not support all the features that Cmd.exe supports.
        /// For example, it does not support %variableName:str1= str2 % or % variableName:~offset,length%.
        /// </param>
        /// <param name="lpDst">
        /// A pointer to a buffer that receives the result of expanding the environment variable strings in the <paramref name="lpSrc"/> buffer.
        /// Note that this buffer cannot be the same as the <paramref name="lpSrc"/> buffer.
        /// </param>
        /// <param name="nSize">
        /// The maximum number of characters that can be stored in the buffer pointed to by the <paramref name="lpDst"/> parameter.
        /// When using ANSI strings, the buffer size should be the string length, plus terminating null character, plus one.
        /// When using Unicode strings, the buffer size should be the string length plus the terminating null character.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of TCHARs stored in the destination buffer, including the terminating null character.
        /// If the destination buffer is too small to hold the expanded string, the return value is the required buffer size, in characters.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The size of the <paramref name="lpSrc"/> and <paramref name="lpDst"/> buffers is limited to 32K.
        /// To replace folder names in a fully qualified path with their associated environment-variable strings,
        /// use the <see cref="PathUnExpandEnvStrings"/> function.
        /// To retrieve the list of environment variables for a process, use the <see cref="GetEnvironmentStrings"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExpandEnvironmentStringsW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD ExpandEnvironmentStrings([In] LPWSTR lpSrc, [In] IntPtr lpDst, [In] DWORD nSize);

        /// <summary>
        /// <para>
        /// Frees a block of environment strings.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-freeenvironmentstringsw"/>
        /// </para>
        /// </summary>
        /// <param name="penv"></param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If you used the ANSI version of <see cref="GetEnvironmentStrings"/>, be sure to use the ANSI version of <see cref="FreeEnvironmentStrings"/>.
        /// Similarly, if you used the Unicode version of <see cref="GetEnvironmentStrings"/>, 
        /// be sure to use the Unicode version of <see cref="FreeEnvironmentStrings"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeEnvironmentStringsW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FreeEnvironmentStrings([In] IntPtr penv);

        /// <summary>
        /// <para>
        /// Retrieves the command-line string for the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-getcommandlinew"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCommandLineW", ExactSpelling = true, SetLastError = true)]
        public static extern LPWSTR GetCommandLine();

        /// <summary>
        /// <para>
        /// Retrieves the current directory for the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getcurrentdirectory"/>
        /// </para>
        /// </summary>
        /// <param name="nBufferLength">
        /// The length of the buffer for the current directory string, in TCHARs.
        /// The buffer length must include room for a terminating null character.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to the buffer that receives the current directory string.
        /// This null-terminated string specifies the absolute path to the current directory.
        /// To determine the required buffer size, set this parameter to <see langword="null"/> and the <paramref name="nBufferLength"/> parameter to 0.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the number of characters that are written to the buffer,
        /// not including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the buffer that is pointed to by <paramref name="lpBuffer"/> is not large enough,
        /// the return value specifies the required size of the buffer, in characters, including the null-terminating character.
        /// </returns>
        /// <remarks>
        /// Each process has a single current directory that consists of two parts:
        /// A disk designator that is either a drive letter followed by a colon, or a server name followed by a share name (\\servername\sharename)
        /// A directory on the disk designator
        /// To set the current directory, use the <see cref="SetCurrentDirectory"/> function.
        /// Multithreaded applications and shared library code should not use the <see cref="GetCurrentDirectory"/> function
        /// and should avoid using relative path names.
        /// The current directory state written by the <see cref="SetCurrentDirectory"/> function is stored as a global variable in each process,
        /// therefore multithreaded applications cannot reliably use this value without possible data corruption from other threads
        /// that may also be reading or setting this value.
        /// This limitation also applies to the <see cref="SetCurrentDirectory"/> and <see cref="GetFullPathName"/> functions.
        /// The exception being when the application is guaranteed to be running in a single thread,
        /// for example parsing file names from the command line argument string in the main thread prior to creating any additional threads.
        /// Using relative path names in multithreaded applications or shared library code can yield unpredictable results and is not supported.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentDirectoryW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetCurrentDirectory([In] DWORD nBufferLength, [In] LPWSTR lpBuffer);

        /// <summary>
        /// <para>
        /// Retrieves the environment variables for the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-getenvironmentstringsw"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the environment block of the current process.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetEnvironmentStrings"/> function returns a pointer to a block of memory
        /// that contains the environment variables of the calling process (both the system and the user environment variables).
        /// Each environment block contains the environment variables in the following format:
        /// Var1 Value1 Var2 Value2 Var3 Value3 VarN ValueN Treat this memory as read-only; do not modify it directly.
        /// To add or change an environment variable, use the <see cref="GetEnvironmentVariable"/> and <see cref="SetEnvironmentVariable"/> functions.
        /// When the block returned by <see cref="GetEnvironmentStrings"/> is no longer needed,
        /// it should be freed by calling the <see cref="FreeEnvironmentStrings"/> function.
        /// Note that the ANSI version of this function, GetEnvironmentStringsA, returns OEM characters.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnvironmentStringsW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetEnvironmentStrings();

        /// <summary>
        /// <para>
        /// Retrieves the contents of the specified variable from the environment block of the calling process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-getenvironmentvariablew"/>
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// The name of the environment variable.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the contents of the specified environment variable as a null-terminated string.
        /// An environment variable has a maximum size limit of 32,767 characters, including the null-terminating character.
        /// </param>
        /// <param name="nSize">
        /// The size of the buffer pointed to by the <paramref name="lpBuffer"/> parameter, including the null-terminating character, in characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters stored in the buffer pointed to by <paramref name="lpBuffer"/>,
        /// not including the terminating null character.
        /// If <paramref name="lpBuffer"/> is not large enough to hold the data, the return value is the buffer size, in characters,
        /// required to hold the string and its terminating null character and the contents of <paramref name="lpBuffer"/> are undefined.
        /// If the function fails, the return value is zero.
        /// If the specified environment variable was not found in the environment block,
        /// <see cref="GetLastError"/> returns <see cref="ERROR_ENVVAR_NOT_FOUND"/>.
        /// </returns>
        /// <remarks>
        /// This function can retrieve either a system environment variable or a user environment variable.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnvironmentVariableW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetEnvironmentVariable([In] LPCWSTR lpName, [In] LPWSTR lpBuffer, [In] DWORD nSize);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the specified standard device (standard input, standard output, or standard error).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/console/getstdhandle"/>
        /// </para>
        /// </summary>
        /// <param name="nStdHandle">
        /// The standard device. This parameter can be one of the following values.
        /// <see cref="STD_INPUT_HANDLE"/>: The standard input device. Initially, this is the console input buffer, CONIN$.
        /// <see cref="STD_OUTPUT_HANDLE"/>: The standard output device. Initially, this is the active console screen buffer, CONOUT$.
        /// <see cref="STD_ERROR_HANDLE"/>: The standard error device. Initially, this is the active console screen buffer, CONOUT$.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified device,
        /// or a redirected handle set by a previous call to <see cref="SetStdHandle"/>.
        /// The handle has <see cref="GENERIC_READ"/> and <see cref="GENERIC_WRITE"/> access rights,
        /// unless the application has used <see cref="SetStdHandle"/> to set a standard handle with lesser access.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If an application does not have associated standard handles, such as a service running on an interactive desktop,
        /// and has not redirected them, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// Handles returned by <see cref="GetStdHandle"/> can be used by applications that need to read from or write to the console.
        /// When a console is created, the standard input handle is a handle to the console's input buffer,
        /// and the standard output and standard error handles are handles of the console's active screen buffer.
        /// These handles can be used by the <see cref="ReadFile"/> and <see cref="WriteFile"/> functions,
        /// or by any of the console functions that access the console input buffer or a screen buffer
        /// (for example, the <see cref="ReadConsoleInput"/>, <see cref="WriteConsole"/>, or <see cref="GetConsoleScreenBufferInfo"/> functions).
        /// The standard handles of a process may be redirected by a call to <see cref="SetStdHandle"/>,
        /// in which case <see cref="GetStdHandle"/> returns the redirected handle.
        /// If the standard handles have been redirected, you can specify the CONIN$ value in a call to the <see cref="CreateFile"/> function
        /// to get a handle to a console's input buffer.
        /// Similarly, you can specify the CONOUT$ value to get a handle to a console's active screen buffer.
        /// Attach/detach behavior
        /// When attaching to a new console, standard handles are always replaced with console handles
        /// unless <see cref="STARTF_USESTDHANDLES"/> was specified during process creation.
        /// If the existing value of the standard handle is <see cref="IntPtr.Zero"/>, or the existing value of the standard handle
        /// looks like a console pseudohandle, the handle is replaced with a console handle.
        /// When a parent uses both <see cref="CREATE_NEW_CONSOLE"/> and <see cref="STARTF_USESTDHANDLES"/> to create a console process,
        /// standard handles will not be replaced unless the existing value of the standard handle is <see cref="IntPtr.Zero"/> or a console pseudohandle.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStdHandle", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE GetStdHandle([In] DWORD nStdHandle);

        /// <summary>
        /// <para>
        /// Searches for a specified file in a specified path.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-searchpathw"/>
        /// </para>
        /// </summary>
        /// <param name="lpPath">
        /// The path to be searched for the file.
        /// If this parameter is <see cref="NULL"/>, the function searches for a matching file using a registry-dependent system search path.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="lpFileName">
        /// The name of the file for which to search.
        /// </param>
        /// <param name="lpExtension">
        /// The extension to be added to the file name when searching for the file.
        /// The first character of the file name extension must be a period (.).
        /// The extension is added only if the specified file name does not end with an extension.
        /// If a file name extension is not required or if the file name contains an extension, this parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="nBufferLength">
        /// The size of the buffer that receives the valid path and file name (including the terminating null character), in TCHARs.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to the buffer to receive the path and file name of the file found. The string is a null-terminated string.
        /// </param>
        /// <param name="lpFilePart">
        /// A pointer to the variable to receive the address (within <paramref name="lpBuffer"/>) of the last component of the valid path and file name,
        /// which is the address of the character immediately following the final backslash () in the path.
        /// </param>
        /// <returns>
        /// If the function succeeds, the value returned is the length, in TCHARs, of the string that is copied to the buffer,
        /// not including the terminating null character.
        /// If the return value is greater than <paramref name="nBufferLength"/>, the value returned is the size of the buffer
        /// that is required to hold the path, including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="lpPath"/> parameter is <see cref="NULL"/>, <see cref="SearchPath"/> searches
        /// for a matching file based on the current value of the following registry value:
        /// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\SafeProcessSearchMode
        /// When the value of this REG_DWORD registry value is set to 1,
        /// <see cref="SearchPath"/> first searches the folders that are specified in the system path, and then searches the current working folder.
        /// When the value of this registry value is set to 0, the computer first searches the current working folder,
        /// and then searches the folders that are specified in the system path.
        /// The system default value for this registry key is 0.
        /// The search mode used by the <see cref="SearchPath"/> function can also be set per-process by calling the <see cref="SetSearchPathMode"/> function.
        /// The <see cref="SearchPath"/> function is not recommended as a method of locating a .dll file
        /// if the intended use of the output is in a call to the <see cref="LoadLibrary"/> function.
        /// This can result in locating the wrong .dll file because the search order of the <see cref="SearchPath"/> function
        /// differs from the search order used by the <see cref="LoadLibrary"/> function.
        /// If you need to locate and load a .dll file, use the <see cref="LoadLibrary"/> function.
        /// Tip Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="SearchPath"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation.
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SearchPathW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SearchPath([In] LPCWSTR lpPath, [In] LPCWSTR lpFileName, [In] LPCWSTR lpExtension,
            [In] DWORD nBufferLength, [In] LPWSTR lpBuffer, [Out] out LPWSTR lpFilePart);

        /// <summary>
        /// <para>
        /// Changes the current directory for the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setcurrentdirectory"/>
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// The path to the new current directory.
        /// This parameter may specify a relative path or a full path.
        /// In either case, the full path of the specified directory is calculated and stored as the current directory.
        /// For more information, see File Names, Paths, and Namespaces.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// The final character before the null character must be a backslash ('').
        /// If you do not specify the backslash, it will be added for you; therefore, specify <see cref="MAX_PATH"/>-2 characters
        /// for the path unless you include the trailing backslash, in which case, specify <see cref="MAX_PATH"/>-1 characters for the path.
        /// Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="SetCurrentDirectory"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation.
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Each process has a single current directory made up of two parts:
        /// A disk designator that is either a drive letter followed by a colon, or a server name and share name (\\servername\sharename)
        /// A directory on the disk designator
        /// Multithreaded applications and shared library code should not use the <see cref="SetCurrentDirectory"/> function
        /// and should avoid using relative path names.
        /// The current directory state written by the <see cref="SetCurrentDirectory"/> function is stored as a global variable in each process,
        /// therefore multithreaded applications cannot reliably use this value without possible data corruption from other threads
        /// that may also be reading or setting this value.
        /// This limitation also applies to the <see cref="GetCurrentDirectory"/> and <see cref="GetFullPathName"/> functions.
        /// The exception being when the application is guaranteed to be running in a single thread,
        /// for example parsing file names from the command line argument string in the main thread prior to creating any additional threads.
        /// Using relative path names in multithreaded applications or shared library code can yield unpredictable results and is not supported.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCurrentDirectoryW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCurrentDirectory([In] LPCWSTR lpPathName);

        /// <summary>
        /// <para>
        /// Sets the environment strings of the calling process (both the system and the user environment variables) for the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-setenvironmentstringsw"/>
        /// </para>
        /// </summary>
        /// <param name="NewEnvironment">
        /// The environment variable string using the following format:
        /// Var1 Value1 Var2 Value2 Var3 Value3 VarN ValueN
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> on success.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetEnvironmentStringsW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetEnvironmentStrings([In] LPWSTR NewEnvironment);


        /// <summary>
        /// <para>
        /// Sets the contents of the specified environment variable for the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-setenvironmentvariablew"/>
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// The name of the environment variable.
        /// The operating system creates the environment variable if it does not exist and <paramref name="lpValue"/> is not <see langword="null"/>.
        /// </param>
        /// <param name="lpValue">
        /// The contents of the environment variable. The maximum size of a user-defined environment variable is 32,767 characters.
        /// For more information, see Environment Variables.
        /// Windows Server 2003 and Windows XP:  The total size of the environment block for a process may not exceed 32,767 characters.
        /// If this parameter is <see langword="null"/>, the variable is deleted from the current process's environment.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function has no effect on the system environment variables or the environment variables of other processes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetEnvironmentVariableW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetEnvironmentVariable([In] LPWSTR lpName, [In] LPWSTR lpValue);

        /// <summary>
        /// <para>
        /// Sets the handle for the specified standard device (standard input, standard output, or standard error).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/console/setstdhandle"/>
        /// </para>
        /// </summary>
        /// <param name="nStdHandle">
        /// The standard device for which the handle is to be set. This parameter can be one of the following values.
        /// <see cref="STD_INPUT_HANDLE"/>: The standard input device.
        /// <see cref="STD_OUTPUT_HANDLE"/>: The standard output device.
        /// <see cref="STD_ERROR_HANDLE"/>: The standard error device.
        /// </param>
        /// <param name="hHandle">
        /// The handle for the standard device.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The standard handles of a process may have been redirected by a call to <see cref="SetStdHandle"/>,
        /// in which case <see cref="GetStdHandle"/> will return the redirected handle.
        /// If the standard handles have been redirected, you can specify the CONIN$ value
        /// in a call to the <see cref="CreateFile"/> function to get a handle to a console's input buffer.
        /// Similarly, you can specify the CONOUT$ value to get a handle to the console's active screen buffer.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetStdHandle", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetStdHandle([In] DWORD nStdHandle, [In] HANDLE hHandle);

        /// <summary>
        /// <para>
        /// Sets the handle for the input, output, or error streams.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-setstdhandleex"/>
        /// </para>
        /// </summary>
        /// <param name="nStdHandle">
        /// A DWORD indicating the stream for which the handle is being set.
        /// </param>
        /// <param name="hHandle">
        /// The handle.
        /// </param>
        /// <param name="phPrevValue">
        /// Optional. Receives the previous handle.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> on success.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetStdHandleEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetStdHandleEx([In] DWORD nStdHandle, [In] HANDLE hHandle, [Out] out HANDLE phPrevValue);
    }
}
