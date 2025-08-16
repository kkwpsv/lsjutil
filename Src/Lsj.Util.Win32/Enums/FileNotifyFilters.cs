using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// File Notify Filters
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-readdirectorychangesw"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum FileNotifyFilters : uint
    {
        /// <summary>
        /// FILE_NOTIFY_CHANGE_FILE_NAME
        /// </summary>
        FILE_NOTIFY_CHANGE_FILE_NAME = 0x00000001,

        /// <summary>
        /// FILE_NOTIFY_CHANGE_DIR_NAME
        /// </summary>
        FILE_NOTIFY_CHANGE_DIR_NAME = 0x00000002,

        /// <summary>
        /// FILE_NOTIFY_CHANGE_ATTRIBUTES
        /// </summary>
        FILE_NOTIFY_CHANGE_ATTRIBUTES = 0x00000004,

        /// <summary>
        /// FILE_NOTIFY_CHANGE_SIZE
        /// </summary>
        FILE_NOTIFY_CHANGE_SIZE = 0x00000008,

        /// <summary>
        /// FILE_NOTIFY_CHANGE_LAST_WRITE
        /// </summary>
        FILE_NOTIFY_CHANGE_LAST_WRITE = 0x00000010,

        /// <summary>
        /// FILE_NOTIFY_CHANGE_LAST_ACCESS
        /// </summary>
        FILE_NOTIFY_CHANGE_LAST_ACCESS = 0x00000020,

        /// <summary>
        /// FILE_NOTIFY_CHANGE_CREATION
        /// </summary>
        FILE_NOTIFY_CHANGE_CREATION = 0x00000040,

        /// <summary>
        /// FILE_NOTIFY_CHANGE_SECURITY
        /// </summary>
        FILE_NOTIFY_CHANGE_SECURITY = 0x00000100,
    }
}
