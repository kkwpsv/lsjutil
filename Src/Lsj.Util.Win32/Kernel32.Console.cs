using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.CtrlEventFlags;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// ATTACH_PARENT_PROCESS
        /// </summary>
        public const uint ATTACH_PARENT_PROCESS = unchecked((uint)-1);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AllocConsole", SetLastError = true)]
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AttachConsole", SetLastError = true)]
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeConsole", SetLastError = true)]
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GenerateConsoleCtrlEvent", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GenerateConsoleCtrlEvent([In]CtrlEventFlags dwCtrlEvent, [In]uint dwProcessGroupId);
    }
}
