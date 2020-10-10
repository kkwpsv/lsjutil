using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains a 64-bit value representing the number of 100-nanosecond intervals since January 1, 1601 (UTC).
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-filetime
    /// </para>
    /// </summary>
    /// <remarks>
    /// To convert a <see cref="FILETIME"/> structure into a time that is easy to display to a user, use the <see cref="FileTimeToSystemTime"/> function.
    /// It is not recommended that you add and subtract values from the <see cref="FILETIME"/> structure to obtain relative times.
    /// Instead, you should copy the low- and high-order parts of the file time to a <see cref="ULARGE_INTEGER"/> structure,
    /// perform 64-bit arithmetic on the <see cref="ULARGE_INTEGER.QuadPart"/> member,
    /// and copy the <see cref="ULARGE_INTEGER.LowPart"/> and <see cref="ULARGE_INTEGER.HighPart"/> members
    /// into the <see cref="FILETIME"/> structure.
    /// Do not cast a pointer to a <see cref="FILETIME"/> structure to either a <see cref="ULARGE_INTEGER"/>* or __int64* value
    /// because it can cause alignment faults on 64-bit Windows.
    /// Not all file systems can record creation and last access time and not all file systems record them in the same manner.
    /// For example, on NT FAT, create time has a resolution of 10 milliseconds, write time has a resolution of 2 seconds,
    /// and access time has a resolution of 1 day (really, the access date).
    /// On NTFS, access time has a resolution of 1 hour.
    /// Therefore, the <see cref="GetFileTime"/> function may not return the same file time information set using the <see cref="SetFileTime"/> function.
    /// Furthermore, FAT records times on disk in local time.
    /// However, NTFS records times on disk in UTC.
    /// For more information, see File Times.
    /// A function using the <see cref="FILETIME"/> structure can allow for values outside of zero or positive values typically specified
    /// by the <see cref="dwLowDateTime"/> and <see cref="dwHighDateTime"/> members.
    /// For example, the <see cref="SetFileTime"/> function uses 0xFFFFFFFF to specify that a file's previous access time should be preserved.
    /// For more information, see the topic for the function you are calling.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILETIME
    {
        /// <summary>
        /// The low-order part of the file time.
        /// </summary>
        public DWORD dwLowDateTime;

        /// <summary>
        /// The high-order part of the file time.
        /// </summary>
        public DWORD dwHighDateTime;
    }
}
