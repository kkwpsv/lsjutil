using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="LoadLibraryEx"/> flags
    /// </summary>
    public enum LoadLibraryExFlags
    {
        /// <summary>
        /// DONT_RESOLVE_DLL_REFERENCES
        /// </summary>
        [Obsolete]
        DONT_RESOLVE_DLL_REFERENCES = 0x00000001,

        /// <summary>
        /// LOAD_IGNORE_CODE_AUTHZ_LEVEL
        /// </summary>
        LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,

        /// <summary>
        /// LOAD_LIBRARY_AS_DATAFILE
        /// For more information, see Remarks.
        /// </summary>
        LOAD_LIBRARY_AS_DATAFILE = 0x00000002,

        /// <summary>
        /// LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE
        /// </summary>
        LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,

        /// <summary>
        /// LOAD_LIBRARY_AS_IMAGE_RESOURCE
        /// </summary>
        LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,

        /// <summary>
        /// LOAD_LIBRARY_SEARCH_APPLICATION_DIR
        /// </summary>
        LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200,

        /// <summary>
        /// LOAD_LIBRARY_SEARCH_DEFAULT_DIRS
        /// </summary>
        LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000,

        /// <summary>
        /// LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR
        /// </summary>
        LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100,

        /// <summary>
        /// LOAD_LIBRARY_SEARCH_SYSTEM32
        /// </summary>
        LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800,

        /// <summary>
        /// LOAD_LIBRARY_SEARCH_USER_DIRS
        /// </summary>
        LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400,

        /// <summary>
        /// LOAD_WITH_ALTERED_SEARCH_PATH
        /// </summary>
        LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008,

        /// <summary>
        /// LOAD_LIBRARY_REQUIRE_SIGNED_TARGET
        /// </summary>
        LOAD_LIBRARY_REQUIRE_SIGNED_TARGET = 0x00000080,

        /// <summary>
        /// LOAD_LIBRARY_SAFE_CURRENT_DIRS
        /// </summary>
        LOAD_LIBRARY_SAFE_CURRENT_DIRS = 0x00002000,
    }
}
