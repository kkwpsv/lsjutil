using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// ACE flags
    /// </summary>
    [Flags]
    public enum AceFlags : byte
    {
        /// <summary>
        /// OBJECT_INHERIT_ACE
        /// </summary>
        OBJECT_INHERIT_ACE = 0x1,

        /// <summary>
        ///CONTAINER_INHERIT_ACE
        /// </summary>
        CONTAINER_INHERIT_ACE = 0x2,

        /// <summary>
        /// NO_PROPAGATE_INHERIT_ACE
        /// </summary>
        NO_PROPAGATE_INHERIT_ACE = 0x4,

        /// <summary>
        /// INHERIT_ONLY_ACE
        /// </summary>
        INHERIT_ONLY_ACE = 0x8,

        /// <summary>
        /// INHERITED_ACE
        /// </summary>
        INHERITED_ACE = 0x10,

        /// <summary>
        /// FAILED_ACCESS_ACE_FLAG
        /// </summary>
        FAILED_ACCESS_ACE_FLAG = 0x80,

        /// <summary>
        /// SUCCESSFUL_ACCESS_ACE_FLAG
        /// </summary>
        SUCCESSFUL_ACCESS_ACE_FLAG = 0x40,
    }
}
