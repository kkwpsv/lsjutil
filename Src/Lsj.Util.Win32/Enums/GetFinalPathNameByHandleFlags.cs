using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GetFinalPathNameByHandle"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-getfinalpathnamebyhandlew"/>
    /// </para>
    /// </summary>
    public enum GetFinalPathNameByHandleFlags : uint
    {
        /// <summary>
        /// Return the normalized drive name.
        /// This is the default.
        /// </summary>
        FILE_NAME_NORMALIZED = 0x0,

        /// <summary>
        /// Return the opened file name (not normalized).
        /// </summary>
        FILE_NAME_OPENED = 0x8,

        /// <summary>
        /// Return the path with the drive letter.
        /// This is the default.
        /// </summary>
        VOLUME_NAME_DOS = 0x0,

        /// <summary>
        /// Return the path with a volume GUID path instead of the drive name.
        /// </summary>
        VOLUME_NAME_GUID = 0x1,

        /// <summary>
        /// Return the path with no drive information.
        /// </summary>
        VOLUME_NAME_NONE = 0x4,

        /// <summary>
        /// Return the path with the volume device path.
        /// </summary>
        VOLUME_NAME_NT = 0x2,
    }
}
