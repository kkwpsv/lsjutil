using System;
using static Lsj.Util.Win32.Enums.SectionAccessRights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// File map access rights
    /// </summary>
    [Flags]
    public enum FileMapAccessRights : uint
    {
        /// <summary>
        /// FILE_MAP_ALL_ACCESS
        /// </summary>
        FILE_MAP_ALL_ACCESS = SECTION_ALL_ACCESS,

        /// <summary>
        /// FILE_MAP_READ
        /// </summary>
        FILE_MAP_READ = SECTION_MAP_READ,

        /// <summary>
        /// FILE_MAP_WRITE
        /// </summary>
        FILE_MAP_WRITE = SECTION_MAP_WRITE,

        /// <summary>
        /// FILE_MAP_COPY
        /// </summary>
        FILE_MAP_COPY = 0x00000001,

        /// <summary>
        /// FILE_MAP_EXECUTE
        /// </summary>
        FILE_MAP_EXECUTE = SECTION_MAP_EXECUTE_EXPLICIT,

        /// <summary>
        /// FILE_MAP_LARGE_PAGES
        /// </summary>
        FILE_MAP_LARGE_PAGES = 0x20000000,

        /// <summary>
        /// FILE_MAP_TARGETS_INVALID
        /// </summary>
        FILE_MAP_TARGETS_INVALID = 0x40000000,
    }
}
