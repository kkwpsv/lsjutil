using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// ACE member flags
    /// </summary>
    [Flags]
    public enum AceMemberFlags : uint
    {
        /// <summary>
        /// ACE_OBJECT_TYPE_PRESENT
        /// </summary>
        ACE_OBJECT_TYPE_PRESENT = 0x1,

        /// <summary>
        /// ACE_INHERITED_OBJECT_TYPE_PRESENT
        /// </summary>
        ACE_INHERITED_OBJECT_TYPE_PRESENT = 0x2,
    }
}
