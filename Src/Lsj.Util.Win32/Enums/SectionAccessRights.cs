using System;
using static Lsj.Util.Win32.Enums.StandardAccessRights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Section access rights
    /// </summary>
    [Flags]
    public enum SectionAccessRights : uint
    {
        /// <summary>
        /// SECTION_EXTEND_SIZE
        /// </summary>
        SECTION_EXTEND_SIZE = 0x0010,

        /// <summary>
        /// SECTION_MAP_EXECUTE
        /// </summary>
        SECTION_MAP_EXECUTE = 0x0008,

        /// <summary>
        /// SECTION_MAP_READ
        /// </summary>
        SECTION_MAP_READ = 0x0004,

        /// <summary>
        /// SECTION_MAP_WRITE
        /// </summary>
        SECTION_MAP_WRITE = 0x0002,

        /// <summary>
        /// SECTION_QUERY
        /// </summary>
        SECTION_QUERY = 0x0001,

        /// <summary>
        /// SECTION_ALL_ACCESS
        /// </summary>
        SECTION_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SECTION_QUERY | SECTION_MAP_WRITE | SECTION_MAP_READ | SECTION_MAP_EXECUTE | SECTION_EXTEND_SIZE,

        /// <summary>
        /// SECTION_MAP_EXECUTE_EXPLICIT
        /// </summary>
        SECTION_MAP_EXECUTE_EXPLICIT = 0x0020,
    }
}
