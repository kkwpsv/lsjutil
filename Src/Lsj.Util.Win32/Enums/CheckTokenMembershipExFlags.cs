using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="CheckTokenMembershipEx"/> Flags
    /// </summary>
    [Flags]
    public enum CheckTokenMembershipExFlags : uint
    {
        /// <summary>
        /// CTMF_INCLUDE_APPCONTAINER
        /// </summary>
        CTMF_INCLUDE_APPCONTAINER = 0x00000001,
    }
}
