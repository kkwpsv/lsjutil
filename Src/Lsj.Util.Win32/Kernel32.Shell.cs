using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/processenv/nf-processenv-getcommandlinew"/>
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
        public static extern StringHandle GetCommandLine();
    }
}
