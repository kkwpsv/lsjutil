using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Kernel32.dll
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// NUMA_NO_PREFERRED_NODE
        /// </summary>
        public const uint NUMA_NO_PREFERRED_NODE = 0xffffffff;

        /// <summary>
        /// <para>
        /// Converts a file time to system time format. System time is based on Coordinated Universal Time (UTC).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/timezoneapi/nf-timezoneapi-filetimetosystemtime
        /// </para>
        /// </summary>
        /// <param name="lpFileTime">
        /// A pointer to a <see cref="FILETIME"/> structure containing the file time to be converted to system (UTC) date and time format.
        /// This value must be less than 0x8000000000000000. Otherwise, the function fails.
        /// </param>
        /// <param name="lpSystemTime">
        /// A pointer to a <see cref="SYSTEMTIME"/> structure to receive the converted file time.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FileTimeToSystemTime", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileTimeToSystemTime([In]ref Structs.FILETIME lpFileTime, [In][Out]ref SYSTEMTIME lpSystemTime);

        /// <summary>
        /// <para>
        /// Retrieves the path of the system directory.
        /// The system directory contains system files such as dynamic-link libraries and drivers.
        /// This function is provided primarily for compatibility.
        /// Applications should store code in the Program Files folder and persistent data in the Application Data folder in the user's profile.
        /// For more information, see <see cref="ShGetFolderPath"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemdirectoryw
        /// </para>
        /// </summary>
        /// <param name="lpBuffer">
        /// A pointer to the buffer to receive the path.
        /// This path does not end with a backslash unless the system directory is the root directory.
        /// For example, if the system directory is named Windows\System32 on drive C,
        /// the path of the system directory retrieved by this function is C:\Windows\System32.
        /// </param>
        /// <param name="uSize">
        /// The maximum size of the buffer, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in TCHARs, of the string copied to the buffer,
        /// not including the terminating null character.
        /// If the length is greater than the size of the buffer, the return value is the size of the buffer required to hold the path,
        /// including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Applications should not create files in the system directory.
        /// If the user is running a shared version of the operating system, the application does not have write access to the system directory.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemDirectoryW", SetLastError = true)]
        public static extern uint GetSystemDirectory([Out]StringBuilder lpBuffer, [In]uint uSize);
    }
}
