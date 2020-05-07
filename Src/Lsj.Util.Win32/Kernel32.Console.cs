using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ConsoleModes;
using static Lsj.Util.Win32.Enums.CtrlEventFlags;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.STARTUPINFOFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// ATTACH_PARENT_PROCESS
        /// </summary>
        public const uint ATTACH_PARENT_PROCESS = unchecked((uint)-1);

        /// <summary>
        /// STD_INPUT_HANDLE
        /// </summary>
        public const uint STD_INPUT_HANDLE = unchecked((uint)-10);

        /// <summary>
        /// STD_OUTPUT_HANDLE
        /// </summary>
        public const uint STD_OUTPUT_HANDLE = unchecked((uint)-11);

        /// <summary>
        /// STD_ERROR_HANDLE 
        /// </summary>
        public const uint STD_ERROR_HANDLE = unchecked((uint)-12);

        /// <summary>
        /// <para>
        /// Allocates a new console for the calling process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/allocconsole
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A process can be associated with only one console,
        /// so the <see cref="AllocConsole"/> function fails if the calling process already has a console.
        /// A process can use the <see cref="FreeConsole"/> function to detach itself from its current console,
        /// then it can call <see cref="AllocConsole"/> to create a new console or <see cref="AttachConsole"/> to attach to another console.
        /// If the calling process creates a child process, the child inherits the new console.
        /// <see cref="AllocConsole"/> initializes standard input, standard output, and standard error handles for the new console.
        /// The standard input handle is a handle to the console's input buffer,
        /// and the standard output and standard error handles are handles to the console's screen buffer.To retrieve these handles,
        /// use the <see cref="GetStdHandle"/> function.
        /// This function is primarily used by graphical user interface (GUI) application to create a console window.
        /// GUI applications are initialized without a console.
        /// Console applications are initialized with a console, unless they are created as detached processes
        /// (by calling the <see cref="CreateProcess"/> function with the <see cref="DETACHED_PROCESS"/> flag).
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AllocConsole", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();

        /// <summary>
        /// <para>
        /// Attaches the calling process to the console of the specified process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/attachconsole
        /// </para>
        /// </summary>
        /// <param name="dwProcessId">
        /// The identifier of the process whose console is to be used. This parameter can be one of the following values.
        /// pid	: Use the console of the specified process.
        /// <see cref="ATTACH_PARENT_PROCESS"/> : Use the console of the parent of the current process.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A process can be attached to at most one console.
        /// If the calling process is already attached to a console, the error code returned is <see cref="ERROR_ACCESS_DENIED"/>.
        /// If the specified process does not have a console, the error code returned is <see cref="ERROR_INVALID_HANDLE"/>.
        /// If the specified process does not exist, the error code returned is <see cref="ERROR_INVALID_PARAMETER"/>.
        /// A process can use the <see cref="FreeConsole"/> function to detach itself from its console.
        /// If other processes share the console, the console is not destroyed, but the process that called <see cref="FreeConsole"/> cannot refer to it.
        /// A console is closed when the last process attached to it terminates or calls <see cref="FreeConsole"/>.
        /// After a process calls <see cref="FreeConsole"/>, it can call the <see cref="AllocConsole"/> function to create a new console
        /// or <see cref="AttachConsole"/> to attach to another console.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0501 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AttachConsole", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AttachConsole([In]uint dwProcessId);

        /// <summary>
        /// <para>
        /// Detaches the calling process from its console.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/freeconsole
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A process can be attached to at most one console.
        /// If the calling process is not already attached to a console, the error code returned is <see cref="ERROR_INVALID_PARAMETER"/>.
        /// A process can use the <see cref="FreeConsole"/> function to detach itself from its console.
        /// If other processes share the console, the console is not destroyed, but the process that called <see cref="FreeConsole"/> cannot refer to it.
        /// A console is closed when the last process attached to it terminates or calls <see cref="FreeConsole"/>.
        /// After a process calls <see cref="FreeConsole"/>, it can call the <see cref="AllocConsole"/> function to create a new console
        /// or <see cref="AttachConsole"/> to attach to another console.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeConsole", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeConsole();

        /// <summary>
        /// <para>
        /// Sends a specified signal to a console process group that shares the console associated with the calling process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/generateconsolectrlevent
        /// </para>
        /// </summary>
        /// <param name="dwCtrlEvent">
        /// The type of signal to be generated.
        /// This parameter can be one of the following values.
        /// <see cref="CTRL_C_EVENT"/>:
        /// Generates a CTRL+C signal.
        /// This signal cannot be generated for process groups.
        /// If <paramref name="dwProcessGroupId"/> is nonzero, this function will succeed,
        /// but the CTRL+C signal will not be received by processes within the specified process group.
        /// <see cref="CTRL_BREAK_EVENT"/>:
        /// Generates a CTRL+BREAK signal.
        /// </param>
        /// <param name="dwProcessGroupId">
        /// The identifier of the process group to receive the signal.
        /// A process group is created when the <see cref="CREATE_NEW_PROCESS_GROUP"/> flag is specified
        /// in a call to the <see cref="CreateProcess"/> function.
        /// The process identifier of the new process is also the process group identifier of a new process group.
        /// The process group includes all processes that are descendants of the root process.
        /// Only those processes in the group that share the same console as the calling process receive the signal.
        /// In other words, if a process in the group creates a new console, that process does not receive the signal, nor do its descendants.
        /// If this parameter is zero, the signal is generated in all processes that share the console of the calling process.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GenerateConsoleCtrlEvent"/> causes the control handler functions of processes in the target group to be called.
        /// All console processes have a default handler function that calls the <see cref="ExitProcess"/> function.
        /// A console process can use the <see cref="SetConsoleCtrlHandler"/> function to install or remove other handler functions.
        /// <see cref="SetConsoleCtrlHandler"/> can also enable an inheritable attribute that causes the calling process to ignore CTRL+C signals.
        /// If <see cref="GenerateConsoleCtrlEvent"/> sends a CTRL+C signal to a process for which this attribute is enabled,
        /// the handler functions for that process are not called.
        /// CTRL+BREAK signals always cause the handler functions to be called.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GenerateConsoleCtrlEvent", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GenerateConsoleCtrlEvent([In]CtrlEventFlags dwCtrlEvent, [In]uint dwProcessGroupId);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified console screen buffer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/getconsolescreenbufferinfo
        /// </para>
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer.
        /// The handle must have the <see cref="GENERIC_READ"/> access right.
        /// For more information, see Console Buffer Security and Access Rights.
        /// </param>
        /// <param name="lpConsoleScreenBufferInfo">
        /// A pointer to a <see cref="CONSOLE_SCREEN_BUFFER_INFO"/> structure that receives the console screen buffer information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The rectangle returned in the <see cref="CONSOLE_SCREEN_BUFFER_INFO.srWindow"/> member of the <see cref="CONSOLE_SCREEN_BUFFER_INFO"/> structure
        /// can be modified and then passed to the <see cref="SetConsoleWindowInfo"/> function to scroll the console screen buffer in the window,
        /// to change the size of the window, or both.
        /// All coordinates returned in the <see cref="CONSOLE_SCREEN_BUFFER_INFO"/> structure are in character-cell coordinates,
        /// where the origin (0, 0) is at the upper-left corner of the console screen buffer.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GenerateConsoleCtrlEvent", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleScreenBufferInfo([In]IntPtr hConsoleOutput, [Out]out CONSOLE_SCREEN_BUFFER_INFO lpConsoleScreenBufferInfo);

        /// <summary>
        /// <para>
        /// Retrieves the current input mode of a console's input buffer or the current output mode of a console screen buffer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/getconsolemode
        /// </para>
        /// </summary>
        /// <param name="hConsoleHandle">
        /// A handle to the console input buffer or the console screen buffer.
        /// The handle must have the <see cref="GENERIC_READ"/> access right.
        /// For more information, see Console Buffer Security and Access Rights.
        /// </param>
        /// <param name="lpMode">
        /// A pointer to a variable that receives the current mode of the specified buffer.
        /// If the <paramref name="hConsoleHandle"/> parameter is an input handle, the mode can be one or more of the following values.
        /// When a console is created, all input modes except <see cref="ENABLE_WINDOW_INPUT"/> are enabled by default.
        /// <see cref="ENABLE_ECHO_INPUT"/>, <see cref="ENABLE_INSERT_MODE"/>, <see cref="ENABLE_LINE_INPUT"/>,
        /// <see cref="ENABLE_MOUSE_INPUT"/>,<see cref="ENABLE_PROCESSED_INPUT"/>, <see cref="ENABLE_QUICK_EDIT_MODE"/>,
        /// <see cref="ENABLE_WINDOW_INPUT"/>, <see cref="ENABLE_VIRTUAL_TERMINAL_INPUT"/>
        /// If the <paramref name="hConsoleHandle"/> parameter is a screen buffer handle, the mode can be one or more of the following values.
        /// When a screen buffer is created, both output modes are enabled by default.
        /// <see cref="ENABLE_PROCESSED_OUTPUT"/>, <see cref="ENABLE_WRAP_AT_EOL_OUTPUT"/>, <see cref="ENABLE_VIRTUAL_TERMINAL_PROCESSING"/>,
        /// <see cref="DISABLE_NEWLINE_AUTO_RETURN"/>, <see cref="ENABLE_LVB_GRID_WORLDWIDE"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A console consists of an input buffer and one or more screen buffers.
        /// The mode of a console buffer determines how the console behaves during input or output (I/O) operations.
        /// One set of flag constants is used with input handles, and another set is used with screen buffer (output) handles.
        /// Setting the output modes of one screen buffer does not affect the output modes of other screen buffers.
        /// The <see cref="ENABLE_LINE_INPUT"/> and <see cref="ENABLE_ECHO_INPUT"/> modes only affect processes
        /// that use <see cref="ReadFile"/> or <see cref="ReadConsole"/> to read from the console's input buffer.
        /// Similarly, the <see cref="ENABLE_PROCESSED_INPUT"/> mode primarily affects <see cref="ReadFile"/> and <see cref="ReadConsole"/> users,
        /// except that it also determines whether CTRL+C input is reported in the input buffer (to be read by the <see cref="ReadConsoleInput"/> function)
        /// or is passed to a function defined by the application.
        /// The <see cref="ENABLE_WINDOW_INPUT"/> and <see cref="ENABLE_MOUSE_INPUT"/> modes determine
        /// whether user interactions involving window resizing and mouse actions are reported in the input buffer or discarded.
        /// These events can be read by <see cref="ReadConsoleInput"/>, but they are always filtered by <see cref="ReadFile"/> and <see cref="ReadConsole"/>.
        /// The <see cref="ENABLE_PROCESSED_OUTPUT"/> and <see cref="ENABLE_WRAP_AT_EOL_OUTPUT"/> modes only affect
        /// processes using <see cref="ReadFile"/> or <see cref="ReadConsole"/> and <see cref="WriteFile"/> or <see cref="WriteConsole"/>.
        /// To change a console's I/O modes, call <see cref="SetConsoleMode"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetConsoleMode", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetConsoleMode([In]HANDLE hConsoleHandle, [Out]out ConsoleModes lpMode);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the specified standard device (standard input, standard output, or standard error).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/getstdhandle
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
        public static extern IntPtr GetStdHandle([In]uint nStdHandle);

        /// <summary>
        /// <para>
        /// Reads character input from the console input buffer and removes it from the buffer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/readconsole
        /// </para>
        /// </summary>
        /// <param name="hConsoleInput">
        /// A handle to the console input buffer.
        /// The handle must have the <see cref="GENERIC_READ"/> access right.
        /// For more information, see Console Buffer Security and Access Rights.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the data read from the console input buffer.
        /// </param>
        /// <param name="nNumberOfCharsToRead">
        /// The number of characters to be read.
        /// The size of the buffer pointed to by the <paramref name="lpBuffer"/> parameter should be
        /// at least <paramref name="nNumberOfCharsToRead"/> * sizeof(TCHAR) bytes.
        /// </param>
        /// <param name="lpNumberOfCharsRead">
        /// A pointer to a variable that receives the number of characters actually read.
        /// </param>
        /// <param name="pInputControl">
        /// A pointer to a <see cref="CONSOLE_READCONSOLE_CONTROL"/> structure that specifies a control character to signal the end of the read operation.
        /// This parameter can be <see cref="NullRef{CONSOLE_READCONSOLE_CONTROL}"/>.
        /// This parameter requires Unicode input by default.
        /// For ANSI mode, set this parameter to <see cref="NullRef{CONSOLE_READCONSOLE_CONTROL}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="ReadConsole"/> reads keyboard input from a console's input buffer.
        /// It behaves like the <see cref="ReadFile"/> function, except that it can read in either Unicode (wide-character) or ANSI mode.
        /// To have applications that maintain a single set of sources compatible with both modes,
        /// use <see cref="ReadConsole"/> rather than <see cref="ReadFile"/>.
        /// Although <see cref="ReadConsole"/> can only be used with a console input buffer handle,
        /// <see cref="ReadFile"/> can be used with other handles (such as files or pipes).
        /// <see cref="ReadConsole"/> fails if used with a standard handle that has been redirected to be something other than a console handle.
        /// All of the input modes that affect the behavior of <see cref="ReadFile"/> have the same effect on <see cref="ReadConsole"/>.
        /// To retrieve and set the input modes of a console input buffer, use the <see cref="GetConsoleMode"/> and <see cref="SetConsoleMode"/> functions.
        /// If the input buffer contains input events other than keyboard events (such as mouse events or window-resizing events), they are discarded.
        /// Those events can only be read by using the <see cref="ReadConsoleInput"/> function.
        /// This function uses either Unicode characters or 8-bit characters from the console's current code page.
        /// The console's code page defaults initially to the system's OEM code page.
        /// To change the console's code page, use the <see cref="SetConsoleCP"/> or <see cref="SetConsoleOutputCP"/> functions,
        /// or use the chcp or mode con cp select= commands.
        /// The <paramref name="pInputControl"/> parameter can be used to enable intermediate wakeups
        /// from the read in response to a file-completion control character specified in a <see cref="CONSOLE_READCONSOLE_CONTROL"/> structure.
        /// This feature requires command extensions to be enabled, the standard output handle to be a console output handle, and input to be Unicode.
        /// Windows Server 2003 and Windows XP/2000: The intermediate read feature is not supported.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReadConsole", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReadConsole([In]HANDLE hConsoleInput, [Out]LPVOID lpBuffer, [In]DWORD nNumberOfCharsToRead,
            [Out]out DWORD lpNumberOfCharsRead, [In]in CONSOLE_READCONSOLE_CONTROL pInputControl);

        /// <summary>
        /// <para>
        /// Reads data from a console input buffer and removes it from the buffer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/readconsoleinput
        /// </para>
        /// </summary>
        /// <param name="hConsoleInput">
        /// A handle to the console input buffer.
        /// The handle must have the <see cref="GENERIC_READ"/> access right.
        /// For more information, see Console Buffer Security and Access Rights.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to an array of <see cref="INPUT_RECORD"/> structures that receives the input buffer data.
        /// </param>
        /// <param name="nLength">
        /// The size of the array pointed to by the <paramref name="lpBuffer"/> parameter, in array elements.
        /// </param>
        /// <param name="lpNumberOfEventsRead">
        /// A pointer to a variable that receives the number of input records read.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the number of records requested in the <paramref name="nLength"/> parameter exceeds the number of records available in the buffer,
        /// the number available is read.
        /// The function does not return until at least one input record has been read.
        /// A process can specify a console input buffer handle in one of the wait functions to determine when there is unread console input.
        /// When the input buffer is not empty, the state of a console input buffer handle is signaled.
        /// To determine the number of unread input records in a console's input buffer, use the <see cref="GetNumberOfConsoleInputEvents"/> function.
        /// To read input records from a console input buffer without affecting the number of unread records,
        /// use the <see cref="PeekConsoleInput"/> function.
        /// To discard all unread records in a console's input buffer, use the <see cref="FlushConsoleInputBuffer"/> function.
        /// This function uses either Unicode characters or 8-bit characters from the console's current code page.
        /// The console's code page defaults initially to the system's OEM code page.
        /// To change the console's code page, use the <see cref="SetConsoleCP"/> or <see cref="SetConsoleOutputCP"/> functions,
        /// or use the chcp or mode con cp select= commands.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReadConsoleInput", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReadConsoleInput([In]HANDLE hConsoleInput, [Out]out INPUT_RECORD[] lpBuffer,
            [In]DWORD nLength, [Out]out DWORD lpNumberOfEventsRead);

        /// <summary>
        /// <para>
        /// Sets the input code page used by the console associated with the calling process.
        /// A console uses its input code page to translate keyboard input into the corresponding character value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/setconsolecp
        /// </para>
        /// </summary>
        /// <param name="wCodePageID">
        /// The identifier of the code page to be set. For more information, see Remarks.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A code page maps 256 character codes to individual characters.
        /// Different code pages include different special characters, typically customized for a language or a group of languages.
        /// To find the code pages that are installed or supported by the operating system, use the <see cref="EnumSystemCodePages"/> function.
        /// The identifiers of the code pages available on the local computer are also stored in the registry under the following key:
        /// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Nls\CodePage
        /// However, it is better to use <see cref="EnumSystemCodePages"/> to enumerate code pages
        /// because the registry can differ in different versions of Windows.
        /// To determine whether a particular code page is valid, use the <see cref="IsValidCodePage"/> function.
        /// To retrieve more information about a code page, including its name, use the <see cref="GetCPInfoEx"/> function.
        /// For a list of available code page identifiers, see Code Page Identifiers.
        /// To determine a console's current input code page, use the <see cref="GetConsoleCP"/> function.
        /// To set and retrieve a console's output code page, use the <see cref="SetConsoleOutputCP"/> and <see cref="GetConsoleOutputCP"/> functions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetConsoleCP", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetConsoleCP([In]UINT wCodePageID);

        /// <summary>
        /// <para>
        /// Sets the input mode of a console's input buffer or the output mode of a console screen buffer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/setconsolemode
        /// </para>
        /// </summary>
        /// <param name="hConsoleHandle">
        /// A handle to the console input buffer or a console screen buffer.
        /// The handle must have the <see cref="GENERIC_READ"/> access right.
        /// For more information, see Console Buffer Security and Access Rights.
        /// </param>
        /// <param name="dwMode">
        /// The input or output mode to be set.
        /// If the <paramref name="hConsoleHandle"/> parameter is an input handle, the mode can be one or more of the following values.
        /// When a console is created, all input modes except <see cref="ENABLE_WINDOW_INPUT"/> are enabled by default.
        /// <see cref="ENABLE_ECHO_INPUT"/>, <see cref="ENABLE_EXTENDED_FLAGS"/>, <see cref="ENABLE_INSERT_MODE"/>,
        /// <see cref="ENABLE_LINE_INPUT"/>, <see cref="ENABLE_MOUSE_INPUT"/>, <see cref="ENABLE_PROCESSED_INPUT"/>,
        /// <see cref="ENABLE_QUICK_EDIT_MODE"/>, <see cref="ENABLE_WINDOW_INPUT"/>, <see cref="ENABLE_VIRTUAL_TERMINAL_INPUT"/>
        /// If the <paramref name="hConsoleHandle"/> parameter is a screen buffer handle, the mode can be one or more of the following values.
        /// When a screen buffer is created, both output modes are enabled by default.
        /// <see cref="ENABLE_PROCESSED_OUTPUT"/>, <see cref="ENABLE_WRAP_AT_EOL_OUTPUT"/>, <see cref="ENABLE_VIRTUAL_TERMINAL_PROCESSING"/>,
        /// <see cref="DISABLE_NEWLINE_AUTO_RETURN"/>, <see cref="ENABLE_LVB_GRID_WORLDWIDE"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A console consists of an input buffer and one or more screen buffers.
        /// The mode of a console buffer determines how the console behaves during input and output (I/O) operations.
        /// One set of flag constants is used with input handles, and another set is used with screen buffer (output) handles.
        /// Setting the output modes of one screen buffer does not affect the output modes of other screen buffers.
        /// The <see cref="ENABLE_LINE_INPUT"/> and <see cref="ENABLE_ECHO_INPUT"/> modes only affect processes
        /// that use <see cref="ReadFile"/> or <see cref="ReadConsole"/> to read from the console's input buffer.
        /// Similarly, the <see cref="ENABLE_PROCESSED_INPUT"/> mode primarily affects <see cref="ReadFile"/> and <see cref="ReadConsole"/> users,
        /// except that it also determines whether Ctrl+C input is reported in the input buffer (to be read by the <see cref="ReadConsoleInput"/> function)
        /// or is passed to a <see cref="HandlerRoutine"/> function defined by the application.
        /// The <see cref="ENABLE_WINDOW_INPUT"/> and <see cref="ENABLE_MOUSE_INPUT"/> modes determine whether user interactions
        /// involving window resizing and mouse actions are reported in the input buffer or discarded.
        /// These events can be read by <see cref="ReadConsoleInput"/>, but they are always filtered by <see cref="ReadFile"/> and <see cref="ReadConsole"/>.
        /// The <see cref="ENABLE_PROCESSED_OUTPUT"/> and <see cref="ENABLE_WRAP_AT_EOL_OUTPUT"/> modes only affect processes
        /// using <see cref="ReadFile"/> or <see cref="ReadConsole"/> and <see cref="WriteFile"/> or <see cref="WriteConsole"/>.
        /// To determine the current mode of a console input buffer or a screen buffer, use the <see cref="GetConsoleMode"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetConsoleMode", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetConsoleMode([In]HANDLE hConsoleHandle, [In]ConsoleModes dwMode);

        /// <summary>
        /// <para>
        /// Sets the output code page used by the console associated with the calling process.
        /// A console uses its output code page to translate the character values written 
        /// by the various output functions into the images displayed in the console window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/setconsoleoutputcp
        /// </para>
        /// </summary>
        /// <param name="wCodePageID">
        /// The identifier of the code page to set. For more information, see Remarks.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A code page maps 256 character codes to individual characters.
        /// Different code pages include different special characters, typically customized for a language or a group of languages.
        /// If the current font is a fixed-pitch Unicode font, <see cref="SetConsoleOutputCP"/> changes the mapping of the character values
        /// into the glyph set of the font, rather than loading a separate font each time it is called.
        /// This affects how extended characters (ASCII value greater than 127) are displayed in a console window.
        /// However, if the current font is a raster font, <see cref="SetConsoleOutputCP"/> does not affect how extended characters are displayed.
        /// To find the code pages that are installed or supported by the operating system, use the <see cref="EnumSystemCodePages"/> function.
        /// The identifiers of the code pages available on the local computer are also stored in the registry under the following key:
        /// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Nls\CodePage
        /// However, it is better to use <see cref="EnumSystemCodePages"/> to enumerate code pages
        /// because the registry can differ in different versions of Window.
        /// To determine whether a particular code page is valid, use the <see cref="IsValidCodePage"/> function.
        /// To retrieve more information about a code page, including its name, use the <see cref="GetCPInfoEx"/> function.
        /// For a list of available code page identifiers, see Code Page Identifiers.
        /// To determine a console's current output code page, use the <see cref="GetConsoleOutputCP"/> function.
        /// To set and retrieve a console's input code page, use the <see cref="SetConsoleCP"/> and <see cref="GetConsoleCP"/> functions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetConsoleOutputCP", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetConsoleOutputCP([In]UINT wCodePageID);

        /// <summary>
        /// <para>
        /// Sets the handle for the specified standard device (standard input, standard output, or standard error).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/setstdhandle
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
        public static extern BOOL SetStdHandle([In]DWORD nStdHandle, [In]HANDLE hHandle);

        /// <summary>
        /// <para>
        /// Writes a character string to a console screen buffer beginning at the current cursor location.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/writeconsole
        /// </para>
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer.
        /// The handle must have the <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see Console Buffer Security and Access Rights.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that contains characters to be written to the console screen buffer.
        /// </param>
        /// <param name="nNumberOfCharsToWrite">
        /// The number of characters to be written.
        /// If the total size of the specified number of characters exceeds the available heap,
        /// the function fails with <see cref="ERROR_NOT_ENOUGH_MEMORY"/>.
        /// </param>
        /// <param name="lpNumberOfCharsWritten">
        /// A pointer to a variable that receives the number of characters actually written.
        /// </param>
        /// <param name="lpReserved">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="WriteConsole"/> function writes characters to the console screen buffer at the current cursor position.
        /// The cursor position advances as characters are written.
        /// The <see cref="SetConsoleCursorPosition"/> function sets the current cursor position.
        /// Characters are written using the foreground and background color attributes associated with the console screen buffer.
        /// The <see cref="SetConsoleTextAttribute"/> function changes these colors.
        /// To determine the current color attributes and the current cursor position, use <see cref="GetConsoleScreenBufferInfo"/>.
        /// All of the input modes that affect the behavior of the <see cref="WriteFile"/> function have the same effect on <see cref="WriteConsole"/>.
        /// To retrieve and set the output modes of a console screen buffer, use the <see cref="GetConsoleMode"/> and <see cref="SetConsoleMode"/> functions.
        /// The <see cref="WriteConsole"/> function uses either Unicode characters or ANSI characters from the console's current code page.
        /// The console's code page defaults initially to the system's OEM code page.
        /// To change the console's code page, use the <see cref="SetConsoleCP"/> or <see cref="SetConsoleOutputCP"/> functions,
        /// or use the chcp or mode con cp select= commands.
        /// <see cref="WriteConsole"/> fails if it is used with a standard handle that is redirected to a file.
        /// If an application processes multilingual output that can be redirected, determine whether the output handle is a console handle
        /// (one method is to call the <see cref="GetConsoleMode"/> function and check whether it succeeds).
        /// If the handle is a console handle, call WriteConsole. If the handle is not a console handle,
        /// the output is redirected and you should call <see cref="WriteFile"/> to perform the I/O.
        /// Be sure to prefix a Unicode plain text file with a byte order mark.
        /// For more information, see Using Byte Order Marks.
        /// Although an application can use <see cref="WriteConsole"/> in ANSI mode to write ANSI characters, consoles do not support ANSI escape sequences.
        /// However, some functions provide equivalent functionality.
        /// For more information, see <see cref="SetCursorPos"/>, <see cref="SetConsoleTextAttribute"/>, and <see cref="GetConsoleCursorInfo"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteConsoleW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WriteConsole([In]HANDLE hConsoleOutput, [In]IntPtr lpBuffer, [In]DWORD nNumberOfCharsToWrite,
            [Out]out DWORD lpNumberOfCharsWritten, [In]LPVOID lpReserved);

        /// <summary>
        /// <para>
        /// Writes character and color attribute data to a specified rectangular block of character cells in a console screen buffer.
        /// The data to be written is taken from a correspondingly sized rectangular block at a specified location in the source buffer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/writeconsoleoutput
        /// </para>
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer.
        /// The handle must have the <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see Console Buffer Security and Access Rights.
        /// </param>
        /// <param name="lpBuffer">
        /// The data to be written to the console screen buffer.
        /// This pointer is treated as the origin of a two-dimensional array of <see cref="CHAR_INFO"/> structures
        /// whose size is specified by the dwBufferSize parameter.
        /// </param>
        /// <param name="dwBufferSize">
        /// The size of the buffer pointed to by the lpBuffer parameter, in character cells.
        /// The <see cref="COORD.X"/> member of the <see cref="COORD"/> structure is the number of columns;
        /// the <see cref="COORD.Y"/> member is the number of rows.
        /// </param>
        /// <param name="dwBufferCoord">
        /// The coordinates of the upper-left cell in the buffer pointed to by the <paramref name="lpBuffer"/> parameter.
        /// The <see cref="COORD.X"/> member of the <see cref="COORD"/> structure is the column, and the <see cref="COORD.Y"/> member is the row.
        /// </param>
        /// <param name="lpWriteRegion">
        /// A pointer to a <see cref="SMALL_RECT"/> structure.
        /// On input, the structure members specify the upper-left and lower-right coordinates of the console screen buffer rectangle to write to.
        /// On output, the structure members specify the actual rectangle that was used.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="WriteConsoleOutput"/> treats the source buffer and the destination screen buffer
        /// as two-dimensional arrays (columns and rows of character cells).
        /// The rectangle pointed to by the <paramref name="lpWriteRegion"/> parameter specifies the size and location of the block
        /// to be written to in the console screen buffer.
        /// A rectangle of the same size is located with its upper-left cell
        /// at the coordinates of the <paramref name="dwBufferCoord"/> parameter in the <paramref name="lpBuffer"/> array.
        /// Data from the cells that are in the intersection of this rectangle and the source buffer rectangle
        /// (whose dimensions are specified by the <paramref name="dwBufferSize"/> parameter) is written to the destination rectangle.
        /// Cells in the destination rectangle whose corresponding source location are outside
        /// the boundaries of the source buffer rectangle are left unaffected by the write operation.
        /// In other words, these are the cells for which no data is available to be written.
        /// Before <see cref="WriteConsoleOutput"/> returns, it sets the members of <paramref name="lpWriteRegion"/>
        /// to the actual screen buffer rectangle affected by the write operation.
        /// This rectangle reflects the cells in the destination rectangle for which there existed a corresponding cell in the source buffer,
        /// because <see cref="WriteConsoleOutput"/> clips the dimensions of the destination rectangle to the boundaries of the console screen buffer.
        /// If the rectangle specified by <paramref name="lpWriteRegion"/> lies completely outside the boundaries of the console screen buffer,
        /// or if the corresponding rectangle is positioned completely outside the boundaries of the source buffer, no data is written.
        /// In this case, the function returns with the members of the structure pointed to by the <paramref name="lpWriteRegion"/> parameter
        /// set such that the <see cref="SMALL_RECT.Right"/> member is less than the <see cref="SMALL_RECT.Left"/>,
        /// or the <see cref="SMALL_RECT.Bottom"/> member is less than the <see cref="SMALL_RECT.Top"/>.
        /// To determine the size of the console screen buffer, use the <see cref="GetConsoleScreenBufferInfo"/> function.
        /// <see cref="WriteConsoleOutput"/> has no effect on the cursor position.
        /// This function uses either Unicode characters or 8-bit characters from the console's current code page.
        /// The console's code page defaults initially to the system's OEM code page.
        /// To change the console's code page, use the <see cref="SetConsoleCP"/> or <see cref="SetConsoleOutputCP"/> functions,
        /// or use the chcp or mode con cp select= commands.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteConsoleOutput", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WriteConsoleOutput([In]HANDLE hConsoleOutput, [In]CHAR_INFO[] lpBuffer, [In]COORD dwBufferSize,
            [In]COORD dwBufferCoord, [In]SMALL_RECT lpWriteRegion);

        /// <summary>
        /// <para>
        /// Copies a number of character attributes to consecutive cells of a console screen buffer, beginning at a specified location.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/console/writeconsoleoutputattribute
        /// </para>
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer.
        /// The handle must have the <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see Console Buffer Security and Access Rights.
        /// </param>
        /// <param name="lpAttribute">
        /// The attributes to be used when writing to the console screen buffer.
        /// For more information, see Character Attributes.
        /// </param>
        /// <param name="nLength">
        /// The number of screen buffer character cells to which the attributes will be copied.
        /// </param>
        /// <param name="dwWriteCoord">
        /// A <see cref="COORD"/> structure that specifies the character coordinates of the first cell in the console screen buffer
        /// to which the attributes will be written.
        /// </param>
        /// <param name="lpNumberOfAttrsWritten">
        /// A pointer to a variable that receives the number of attributes actually written to the console screen buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the number of attributes to be written to extends beyond the end of the specified row in the console screen buffer,
        /// attributes are written to the next row.
        /// If the number of attributes to be written to extends beyond the end of the console screen buffer,
        /// the attributes are written up to the end of the console screen buffer.
        /// The character values at the positions written to are not changed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteConsoleOutputAttribute", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WriteConsoleOutputAttribute([In]HANDLE hConsoleOutput, [In]ConsoleCharacterAttributes[] lpAttribute,
            [In]COORD nLength, [In]COORD dwWriteCoord, [Out]out DWORD lpNumberOfAttrsWritten);
    }
}
