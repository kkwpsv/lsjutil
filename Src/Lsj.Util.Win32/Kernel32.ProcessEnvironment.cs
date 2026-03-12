using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.RegistryValueTypes;
using static Lsj.Util.Win32.Enums.SearchPathModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Expands environment-variable strings and replaces them with the values defined for the current user.
        /// </para>
        /// <para>
        /// To specify the environment block for a particular user or the system, use the <see cref="ExpandEnvironmentStringsForUser"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-expandenvironmentstringsw"/>
        /// </para>
        /// </summary>
        /// <param name="lpSrc">
        /// <para>
        /// A buffer that contains one or more environment-variable strings in the form: <c>%variableName%</c>.
        /// For each such reference, the <c>%variableName%</c> portion is replaced with the current value of that environment variable.
        /// </para>
        /// <para>
        /// Case is ignored when looking up the environment-variable name.
        /// If the name is not found, the <c>%variableName%</c> portion is left unexpanded.
        /// </para>
        /// <para>
        /// Note that this function does not support all the features that Cmd.exe supports.
        /// For example, it does not support <c>%variableName:str1=str2%</c> or <c>%variableName:~offset,length%</c>.
        /// </para>
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
        /// <para>
        /// If the function succeeds, the return value is the number of <c>TCHAR</c>s stored in the destination buffer, including the terminating null character.
        /// If the destination buffer is too small to hold the expanded string, the return value is the required buffer size, in characters.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The size of the <paramref name="lpSrc"/> and <paramref name="lpDst"/> buffers is limited to 32K.
        /// </para>
        /// <para>
        /// To replace folder names in a fully qualified path with their associated environment-variable strings,
        /// use the <see cref="PathUnExpandEnvStrings"/> function.
        /// </para>
        /// <para>
        /// To retrieve the list of environment variables for a process, use the <see cref="GetEnvironmentStrings"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExpandEnvironmentStringsW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD ExpandEnvironmentStrings([In] LPWSTR lpSrc, [In] LPWSTR lpDst, [In] DWORD nSize);

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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If you used the ANSI version of <c>GetEnvironmentStrings</c>, be sure to use the ANSI version of <c>FreeEnvironmentStrings</c>.
        /// Similarly, if you used the Unicode version of <see cref="GetEnvironmentStrings"/>, 
        /// be sure to use the Unicode version of <see cref="FreeEnvironmentStrings"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeEnvironmentStringsW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FreeEnvironmentStrings([In] LPWCH penv);

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
        /// <para>
        /// The lifetime of the returned value is managed by the system, applications should not free or modify this value.
        /// </para>
        /// <para>
        /// Console processes can use the <c>argc</c> and <c>argv</c> arguments of the <c>main</c> or <c>wmain</c> functions
        /// by implementing those as the program entry point.
        /// GUI processes can use the <c>lpCmdLine</c> argument of the <c>WinMain</c> or <c>wWinMain</c> functions
        /// by implementing those as the program entry point.
        /// </para>
        /// <para>
        /// To convert the command line to an <c>argv</c> style array of strings,
        /// pass the result from <see cref="GetCommandLine"/> to <see cref="CommandLineToArgvW"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The name of the executable in the command line that the operating system provides to a process
        /// is not necessarily identical to that in the command line that the calling process gives to the <see cref="CreateProcess"/> function.
        /// The operating system may prepend a fully qualified path to an executable name that is provided without a fully qualified path.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCommandLineW", ExactSpelling = true)]
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
        /// The length of the buffer for the current directory string, in <c>TCHAR</c>s.
        /// The buffer length must include room for a terminating null character.
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// A pointer to the buffer that receives the current directory string.
        /// This null-terminated string specifies the absolute path to the current directory.
        /// </para>
        /// <para>
        /// To determine the required buffer size, set this parameter to <see cref="NULL"/> and the <paramref name="nBufferLength"/> parameter to 0.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the number of characters
        /// that are written to the buffer, not including the terminating null character.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If the buffer that is pointed to by <paramref name="lpBuffer"/> is not large enough,
        /// the return value specifies the required size of the buffer, in characters, including the null-terminating character.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Each process has a single current directory that consists of two parts:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// A disk designator that is either a drive letter followed by a colon,
        /// or a server name followed by a share name (<c>\\servername\sharename</c>)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A directory on the disk designator
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To set the current directory, use the <see cref="SetCurrentDirectory"/> function.
        /// </para>
        /// <para>
        /// Multithreaded applications and shared library code should not use the see cref="GetCurrentDirectory"/> function
        /// and should avoid using relative path names.
        /// The current directory state written by the <see cref="SetCurrentDirectory"/> function is stored as a global variable in each process,
        /// therefore multithreaded applications cannot reliably use this value without possible data corruption
        /// from other threads that may also be reading or setting this value.
        /// This limitation also applies to the <see cref="SetCurrentDirectory"/> and <see cref="GetFullPathName"/> functions.
        /// The exception being when the application is guaranteed to be running in a single thread,
        /// for example parsing file names from the command line argument string in the main thread prior to creating any additional threads.
        /// Using relative path names in multithreaded applications or shared library code can yield unpredictable results and is not supported.
        /// </para>
        /// <para>
        /// In Windows 8 and Windows Server 2012, this function is supported by the following technologies.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Technology
        /// </term>
        /// <term>
        /// Supported
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Server Message Block (SMB) 3.0 protocol
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 Transparent Failover (TFO)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 with Scale-out File Shares (SO)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Cluster Shared Volume File System (CsvFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Resilient File System (ReFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// If the function succeeds, the return value is a pointer to the environment block of the current process.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetEnvironmentStrings"/> function returns a pointer to a block of memory
        /// that contains the environment variables of the calling process (both the system and the user environment variables).
        /// Each environment block contains the environment variables in the following format:
        /// </para>
        /// <code>
        /// Var1=Value1\0
        /// Var2=Value2\0
        /// Var3=Value3\0
        /// ...
        /// VarN=ValueN\0\0
        /// </code>
        /// <para>
        /// The name of an environment variable cannot include an equal sign (=).
        /// </para>
        /// <para>
        /// Treat this memory as read-only; do not modify it directly.
        /// To add or change an environment variable, use the <see cref="GetEnvironmentVariable"/> and <see cref="SetEnvironmentVariable"/> functions.
        /// </para>
        /// <para>
        /// When the block returned by <see cref="GetEnvironmentStrings"/> is no longer needed,
        /// it should be freed by calling the <see cref="FreeEnvironmentStrings"/> function.
        /// </para>
        /// <para>
        /// Note that the ANSI version of this function, <c>GetEnvironmentStringsA</c>, returns OEM characters.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnvironmentStringsW", ExactSpelling = true)]
        public static extern LPWCH GetEnvironmentStrings();

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
        /// <para>
        /// A pointer to a buffer that receives the contents of the specified environment variable as a null-terminated string.
        /// </para>
        /// <para>
        /// The maximum size of a user-defined environment variable is 32,767 characters.
        /// There is no technical limitation on the size of the environment block.
        /// However, there are practical limits depending on the mechanism used to access the block.
        /// For example, a batch file cannot set a variable that is longer than the maximum command line length.
        /// For more information, see Environment Variables.
        /// </para>
        /// </param>
        /// <param name="nSize">
        /// The size of the buffer pointed to by the <paramref name="lpBuffer"/> parameter, including the null-terminating character, in characters.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of characters stored in the buffer
        /// pointed to by <paramref name="lpBuffer"/>, not including the terminating null character.
        /// </para>
        /// <para>
        /// If <paramref name="lpBuffer"/> is not large enough to hold the data, the return value is the buffer size, in characters,
        /// required to hold the string and its terminating null character and the contents of <paramref name="lpBuffer"/> are undefined.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// If the specified environment variable was not found in the environment block,
        /// <see cref="GetLastError"/> returns <see cref="ERROR_ENVVAR_NOT_FOUND"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function can retrieve either a system environment variable or a user environment variable.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnvironmentVariableW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetEnvironmentVariable([In] LPCWSTR lpName, [In] LPWSTR lpBuffer, [In] DWORD nSize);

        /// <summary>
        /// <para>
        /// Determines whether the current directory should be included in the search path for the specified executable.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-needcurrentdirectoryforexepathw"/>
        /// </para>
        /// </summary>
        /// <param name="ExeName">
        /// The name of the executable file.
        /// </param>
        /// <returns>
        /// If the current directory should be part of the search path, the return value is <see cref="TRUE"/>.
        /// Otherwise, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function should only be called in instances
        /// where the caller must explicitly resolve a relative executable name to an absolute name. 
        /// If <see cref="CreateProcess"/> is called with a relative executable name,
        /// it will automatically search for the executable, calling this function to determine the search path.
        /// </para>
        /// <para>
        /// Most system functions perform their own path resolution,
        /// therefore, this function should only be called if you are attempting to resolve a search path
        /// for the specified executable based on the current directory.
        /// </para>
        /// <para>
        /// The value of the <c>NoDefaultCurrentDirectoryInExePath</c> environment variable determines the value this function returns.
        /// However, you should call this function rather than checking the environment variable directly,
        /// as the registry location of this environment variable can change.
        /// </para>
        /// <para>
        /// If the value of the <paramref name="ExeName"/> parameter contains a backslash (\),
        /// this function will always return <see cref="TRUE"/>.
        /// If it does not contain a backslash,
        /// the existence of the <c>NoDefaultCurrentDirectoryInExePath</c> environment variable is checked, and not its value.
        /// </para>
        /// <para>
        /// An example of an instance when this function should be called
        /// instead of relying on the default search path resolution algorithm in <see cref="CreateProcess"/> is the "cmd.exe" executable.
        /// It calls this function to determine the command search path
        /// because it does its own path resolution before calling <see cref="CreateProcess"/>.
        /// If this function returns <see cref="TRUE"/>, cmd.exe uses the path ".;%PATH%" for the executable search.
        /// If it returns <see cref="FALSE"/>, cmd.exe uses the path "%PATH%" for the search.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "NeedCurrentDirectoryForExePathW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL NeedCurrentDirectoryForExePathW([In] LPCWSTR ExeName);

        /// <summary>
        /// <para>
        /// Searches for a specified file in a specified path.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-searchpathw"/>
        /// </para>
        /// </summary>
        /// <param name="lpPath">
        /// <para>
        /// The path to be searched for the file.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the function searches for a matching file using a registry-dependent system search path.
        /// For more information, see the Remarks section.
        /// </para>
        /// </param>
        /// <param name="lpFileName">
        /// The name of the file for which to search.
        /// </param>
        /// <param name="lpExtension">
        /// <para>
        /// The extension to be added to the file name when searching for the file.
        /// The first character of the file name extension must be a period (.).
        /// The extension is added only if the specified file name does not end with an extension.
        /// </para>
        /// <para>
        /// If a file name extension is not required or if the file name contains an extension, this parameter can be <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="nBufferLength">
        /// The size of the buffer that receives the valid path and file name (including the terminating null character), in <c>TCHAR</c>s.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to the buffer to receive the path and file name of the file found. The string is a null-terminated string.
        /// </param>
        /// <param name="lpFilePart">
        /// A pointer to the variable to receive the address (within <paramref name="lpBuffer"/>) of the last component of the valid path and file name,
        /// which is the address of the character immediately following the final backslash () in the path.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the value returned is the length, in <c>TCHAR</c>s,
        /// of the string that is copied to the buffer, not including the terminating null character.
        /// If the return value is greater than <paramref name="nBufferLength"/>,
        /// the value returned is the size of the buffer that is required to hold the path, including the terminating null character.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <paramref name="lpPath"/> parameter is <see cref="NULL"/>,
        /// <see cref="SearchPath"/> searches for a matching file based on the current value of the following registry value:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\SafeProcessSearchMode</c>
        /// </para>
        /// <para>
        /// When the value of this <see cref="REG_DWORD"/> registry value is set to 1,
        /// <see cref="SearchPath"/> first searches the folders that are specified in the system path, and then searches the current working folder.
        /// When the value of this registry value is set to 0, the computer first searches the current working folder,
        /// and then searches the folders that are specified in the system path.
        /// The system default value for this registry key is 0.
        /// </para>
        /// <para>
        /// The search mode used by the <see cref="SearchPath"/> function can also be set per-process by calling the <see cref="SetSearchPathMode"/> function.
        /// </para>
        /// <para>
        /// The <see cref="SearchPath"/> function is not recommended as a method of locating a .dll file
        /// if the intended use of the output is in a call to the <see cref="LoadLibrary"/> function.
        /// This can result in locating the wrong .dll file because the search order of the <see cref="SearchPath"/> function
        /// differs from the search order used by the <see cref="LoadLibrary"/> function.
        /// If you need to locate and load a .dll file, use the <see cref="LoadLibrary"/> function.
        /// </para>
        /// <para>
        /// Tip
        /// </para>
        /// <para>
        /// Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="SearchPath"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation.
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </para>
        /// <para>
        /// In Windows 8 and Windows Server 2012, this function is supported by the following technologies.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Technology
        /// </term>
        /// <term>
        /// Supported
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Server Message Block (SMB) 3.0 protocol
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 Transparent Failover (TFO)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 with Scale-out File Shares (SO)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Cluster Shared Volume File System (CsvFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Resilient File System (ReFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// The path to the new current directory.
        /// This parameter may specify a relative path or a full path.
        /// In either case, the full path of the specified directory is calculated and stored as the current directory.
        /// </para>
        /// <para>
        /// For more info, see Naming files, paths, and namespaces.
        /// </para>
        /// <para>
        /// By default, the name is limited to <see cref="MAX_PATH"/> characters.
        /// </para>
        /// <para>
        ///  Tip
        /// </para>
        /// <para>
        /// Starting with Windows 10, Version 1607, you can opt in to remove the <see cref="MAX_PATH"/> limitation.
        /// For details, see the Maximum path length limitation section of Naming files, paths, and namespaces.
        /// </para>
        /// <para>
        ///  Important
        /// </para>
        /// <para>
        /// Setting a current directory longer than <see cref="MAX_PATH"/> causes <see cref="CreateProcess"/> to fail.
        /// </para>
        /// <para>
        /// The final character before the null character must be a backslash ('\').
        /// If you don't specify the backslash, then it will be added for you.
        /// Therefore, specify ><see cref="MAX_PATH"/>-2 characters for the path unless you include the trailing backslash;
        /// in which case, specify <see cref="MAX_PATH"/>-1 characters for the path.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, then the return value is non-zero.
        /// </para>
        /// <para>
        /// If the function fails, then the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Each process has a single current directory made up of two parts:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// A disk designator that is either a drive letter followed by a colon,
        /// or a server name and share name (<c>\\servername\sharename</c>)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A directory on the disk designator
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The current directory is shared by all threads of the process:
        /// If one thread changes the current directory, it affects all threads in the process.
        /// </para>
        /// <para>
        /// Multithreaded applications and shared library code should avoid calling the <see cref="SetCurrentDirectory"/> function
        /// due to the risk of affecting relative path calculations being performed by other threads.
        /// Conversely, multithreaded applications and shared library code should avoid using relative paths
        /// so that they are unaffected by changes to the current directory performed by other threads.
        /// </para>
        /// <para>
        /// The current directory for a process is locked while the process is executing.
        /// That prevents the directory from being deleted, moved, or renamed.
        /// </para>
        /// <para>
        /// In Windows 8 and Windows Server 2012, this function is supported by the following technologies.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Technology
        /// </term>
        /// <term>
        /// Supported
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Server Message Block (SMB) 3.0 protocol
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 Transparent Failover (TFO)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 with Scale-out File Shares (SO)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Cluster Shared Volume File System (CsvFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Resilient File System (ReFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// The environment variable string using the following format:
        /// </para>
        /// <code>
        /// Var1=Value1\0
        /// Var2=Value2\0
        /// Var3=Value3\0
        /// ...
        /// VarN=ValueN\0\0
        /// </code>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetEnvironmentStringsW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetEnvironmentStrings([In] LPWCH NewEnvironment);

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
        /// The operating system creates the environment variable if it does not exist and <paramref name="lpValue"/> is not <see cref="NULL"/>.
        /// </param>
        /// <param name="lpValue">
        /// <para>
        /// The contents of the environment variable.
        /// </para>
        /// <para>
        /// The maximum size of a user-defined environment variable is 32,767 characters.
        /// There is no technical limitation on the size of the environment block.
        /// However, there are practical limits depending on the mechanism used to access the block.
        /// For example, a batch file cannot set a variable that is longer than the maximum command line length.
        /// For more information, see Environment Variables.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The total size of the environment block for a process may not exceed 32,767 characters.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the variable is deleted from the current process's environment.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function has no effect on the system environment variables or the environment variables of other processes.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetEnvironmentVariableW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetEnvironmentVariable([In] LPWSTR lpName, [In] LPWSTR lpValue);

        /// <summary>
        /// <para>
        /// Sets the per-process mode that the <see cref="SearchPath"/> function uses when locating files.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setsearchpathmode"/>
        /// </para>
        /// </summary>
        /// <param name="Flags">
        /// <para>
        /// The search mode to use.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Enable safe process search mode for the process.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BASE_SEARCH_PATH_DISABLE_SAFE_SEARCHMODE"/>
        /// </para>
        /// <para>
        /// 0x00010000
        /// </para>
        /// </term>
        /// <term>
        /// Disable safe process search mode for the process.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BASE_SEARCH_PATH_PERMANENT"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Optional flag to use in combination with <see cref="BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE"/> to make this mode permanent for this process.
        /// This is done by bitwise OR operation:
        /// </para>
        /// <para>
        /// <c>(BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE | BASE_SEARCH_PATH_PERMANENT)</c>
        /// </para>
        /// <para>
        /// This flag cannot be combined with the <see cref="BASE_SEARCH_PATH_DISABLE_SAFE_SEARCHMODE"/> flag.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the operation completes successfully, the <see cref="SetSearchPathMode"/> function returns a nonzero value.
        /// </para>
        /// <para>
        /// If the operation fails, the <see cref="SetSearchPathMode"/> function returns zero.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </para>
        /// <para>
        /// If the <see cref="SetSearchPathMode"/> function fails because a parameter value is not valid,
        /// the value returned by the <see cref="GetLastError"/> function will be <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// <para>
        /// If the <see cref="SetSearchPathMode"/> function fails because the combination of current state and parameter value is not valid,
        /// the value returned by the <see cref="GetLastError"/> function will be <see cref="ERROR_ACCESS_DENIED"/>.
        /// For more information, see the Remarks section.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <see cref="SetSearchPathMode"/> function has not been successfully called for the current process,
        /// the search mode used by the <see cref="SearchPath"/> function is obtained from the system registry.
        /// For more information, see <see cref="SearchPath"/>.
        /// </para>
        /// <para>
        /// After the <see cref="SetSearchPathMode"/> function has been successfully called for the current process,
        /// the setting in the system registry is ignored in favor of the mode most recently set successfully.
        /// </para>
        /// <para>
        /// If the <see cref="SetSearchPathMode"/> function has been successfully called for the current process
        /// with <paramref name="Flags"/> set to <c>(BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE | BASE_SEARCH_PATH_PERMANENT)</c>,
        /// safe mode is set permanently for the calling process.
        /// Any subsequent calls to the <see cref="SetSearchPathMode"/> function from within that process
        /// that attempt to change the search mode will fail with <see cref="ERROR_ACCESS_DENIED"/> from the <see cref="GetLastError"/> function.
        /// </para>
        /// <para>
        /// Note 
        /// </para>
        /// <para>
        /// Because setting safe search mode permanently cannot be disabled for the life of the process for which is was set,
        /// it should be used with careful consideration.
        /// This is particularly true for DLL development, where the user of the DLL will be affected by this process-wide setting.
        /// It is not possible to permanently disable safe search mode.
        /// </para>
        /// <para>
        /// This function does not modify the system registry.
        /// </para>
        /// <para>
        /// In Windows 8 and Windows Server 2012, this function is supported by the following technologies.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Technology
        /// </term>
        /// <term>
        /// Supported
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Server Message Block (SMB) 3.0 protocol
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 Transparent Failover (TFO)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// SMB 3.0 with Scale-out File Shares (SO)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Cluster Shared Volume File System (CsvFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Resilient File System (ReFS)
        /// </term>
        /// <term>
        /// Yes
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "KB959426")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSearchPathMode", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSearchPathMode([In] SearchPathModes Flags);

        /// <summary>
        /// <para>
        /// Sets the handle for the input, output, or error streams.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-setstdhandleex"/>
        /// </para>
        /// </summary>
        /// <param name="nStdHandle">
        /// A <see cref="DWORD"/> indicating the stream for which the handle is being set.
        /// </param>
        /// <param name="hHandle">
        /// The handle.
        /// </param>
        /// <param name="phPrevValue">
        /// Optional. Receives the previous handle.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetStdHandleEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetStdHandleEx([In] DWORD nStdHandle, [In] HANDLE hHandle, [Out] out HANDLE phPrevValue);
    }
}
