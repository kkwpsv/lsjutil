using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="OpenFile"/> flags
    /// </summary>
    [Flags]
    public enum OpenFileFlags : uint
    {
        /// <summary>
        /// OF_CANCEL
        /// </summary>
        OF_CANCEL = 0x00000800,

        /// <summary>
        /// OF_CREATE
        /// </summary>
        OF_CREATE = 0x00001000,

        /// <summary>
        /// OF_DELETE
        /// </summary>
        OF_DELETE = 0x00000200,

        /// <summary>
        /// OF_EXIST
        /// </summary>
        OF_EXIST = 0x00004000,

        /// <summary>
        /// OF_PARSE
        /// </summary>
        OF_PARSE = 0x00000100,

        /// <summary>
        /// OF_PROMPT
        /// </summary>
        OF_PROMPT = 0x00002000,

        /// <summary>
        /// OF_READ
        /// </summary>
        OF_READ = 0x00000000,

        /// <summary>
        /// OF_READWRITE
        /// </summary>
        OF_READWRITE = 0x00000002,

        /// <summary>
        /// OF_REOPEN
        /// </summary>
        OF_REOPEN = 0x00008000,

        /// <summary>
        /// OF_SHARE_COMPAT
        /// </summary>
        OF_SHARE_COMPAT = 0x00000000,

        /// <summary>
        /// OF_SHARE_DENY_NONE
        /// </summary>
        OF_SHARE_DENY_NONE = 0x00000040,

        /// <summary>
        /// OF_SHARE_DENY_READ
        /// </summary>
        OF_SHARE_DENY_READ = 0x00000030,

        /// <summary>
        /// OF_SHARE_DENY_WRITE
        /// </summary>
        OF_SHARE_DENY_WRITE = 0x00000020,

        /// <summary>
        /// OF_SHARE_EXCLUSIVE
        /// </summary>
        OF_SHARE_EXCLUSIVE = 0x00000010,

        /// <summary>
        /// OF_VERIFY
        /// </summary>
        OF_VERIFY = 0x00000400,

        /// <summary>
        /// OF_WRITE
        /// </summary>
        OF_WRITE = 0x00000001,
    }
}
