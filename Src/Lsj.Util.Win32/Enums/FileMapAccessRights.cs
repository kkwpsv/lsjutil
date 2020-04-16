using static Lsj.Util.Win32.Enums.MemoryProtectionConstants;
using static Lsj.Util.Win32.Enums.SectionAccessRights;
using static Lsj.Util.Win32.Enums.SectionAttributes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// File Map Access Rights
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-mapviewoffile
    /// </para>
    /// </summary>
    public enum FileMapAccessRights : uint
    {
        /// <summary>
        /// A read/write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READWRITE"/> or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When used with the <see cref="MapViewOfFile"/> function, <see cref="FILE_MAP_ALL_ACCESS"/> is equivalent to <see cref="FILE_MAP_WRITE"/>.
        /// </summary>
        FILE_MAP_ALL_ACCESS = SECTION_ALL_ACCESS,

        /// <summary>
        /// A read-only view of the file is mapped.
        /// An attempt to write to the file view results in an access violation.
        /// The file mapping object must have been created with <see cref="PAGE_READONLY"/>, <see cref="PAGE_READWRITE"/>,
        /// <see cref="PAGE_EXECUTE_READ"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// </summary>
        FILE_MAP_READ = SECTION_MAP_READ,

        /// <summary>
        /// A read/write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READWRITE"/> or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When used with <see cref="MapViewOfFile"/>, (<see cref="FILE_MAP_WRITE"/> | <see cref="FILE_MAP_READ"/>) and 
        /// <see cref="FILE_MAP_ALL_ACCESS"/> are equivalent to <see cref="FILE_MAP_WRITE"/>.
        /// </summary>
        FILE_MAP_WRITE = SECTION_MAP_WRITE,

        /// <summary>
        /// A copy-on-write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READONLY"/>, <see cref="PAGE_EXECUTE_READ"/>, <see cref="PAGE_WRITECOPY"/>,
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>, <see cref="PAGE_READWRITE"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When a process writes to a copy-on-write page, the system copies the original page to a new page that is private to the process.
        /// The new page is backed by the paging file.The protection of the new page changes from copy-on-write to read/write.
        /// When copy-on-write access is specified, the system and process commit charge taken is for the entire view
        /// because the calling process can potentially write to every page in the view, making all pages private.
        /// The contents of the new page are never written back to the original file and are lost when the view is unmapped.
        /// </summary>
        FILE_MAP_COPY = 0x00000001,

        /// <summary>
        /// An executable view of the file is mapped (mapped memory can be run as code).
        /// The file mapping object must have been created with <see cref="PAGE_EXECUTE_READ"/>, <see cref="PAGE_EXECUTE_WRITECOPY"/>,
        /// or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// Windows Server 2003 and Windows XP: This value is available starting with Windows XP with SP2 and Windows Server 2003 with SP1.
        /// </summary>
        FILE_MAP_EXECUTE = SECTION_MAP_EXECUTE_EXPLICIT,

        /// <summary>
        /// Starting with Windows 10, version 1703, this flag specifies that the view should be mapped using large page support.
        /// The size of the view must be a multiple of the size of a large page reported by the <see cref="GetLargePageMinimum"/> function,
        /// and the file-mapping object must have been created using the <see cref="SEC_LARGE_PAGES"/> option.
        /// If you provide a non-null value for lpBaseAddress, then the value must be a multiple of <see cref="GetLargePageMinimum"/>.
        /// </summary>
        FILE_MAP_LARGE_PAGES = 0x20000000,

        /// <summary>
        /// Sets all the locations in the mapped file as invalid targets for Control Flow Guard (CFG).
        /// This flag is similar to PAGE_TARGETS_INVALID. Use this flag in combination with the execute access right <see cref="FILE_MAP_EXECUTE"/>.
        /// Any indirect call to locations in those pages will fail CFG checks, and the process will be terminated.
        /// The default behavior for executable pages allocated is to be marked valid call targets for CFG.
        /// </summary>
        FILE_MAP_TARGETS_INVALID = 0x40000000,
    }
}
