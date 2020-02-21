using static Lsj.Util.Win32.Enums.StandardAccessRights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Section Access Rights
    /// </para>
    /// <para>
    /// From: 
    /// </para>
    /// </summary>
    public enum SectionAccessRights : uint
    {
        /// <summary>
        /// Dynamically extend the size of the section.
        /// </summary>
        SECTION_EXTEND_SIZE = 0x0010,

        /// <summary>
        /// Execute views of the section.
        /// </summary>
        SECTION_MAP_EXECUTE = 0x0008,

        /// <summary>
        /// Read views of the section.
        /// </summary>
        SECTION_MAP_READ = 0x0004,

        /// <summary>
        /// Write views of the section.
        /// </summary>
        SECTION_MAP_WRITE = 0x0002,

        /// <summary>
        /// Query the section object for information about the section. Drivers should set this flag.
        /// </summary>
        SECTION_QUERY = 0x0001,

        /// <summary>
        /// All of the previous flags combined with <see cref="STANDARD_RIGHTS_REQUIRED"/>.
        /// </summary>
        SECTION_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SECTION_QUERY | SECTION_MAP_WRITE | SECTION_MAP_READ | SECTION_MAP_EXECUTE | SECTION_EXTEND_SIZE,

        /// <summary>
        /// SECTION_MAP_EXECUTE_EXPLICIT
        /// </summary>
        SECTION_MAP_EXECUTE_EXPLICIT = 0x0020,
    }
}
