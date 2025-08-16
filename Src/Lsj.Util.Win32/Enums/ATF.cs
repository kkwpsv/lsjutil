using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="ACCESSTIMEOUT"/> flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-accesstimeout"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum ATF : uint
    {
        /// <summary>
        /// ATF_ONOFFFEEDBACK
        /// </summary>
        ATF_ONOFFFEEDBACK = 0x00000002,

        /// <summary>
        /// ATF_TIMEOUTON
        /// </summary>
        ATF_TIMEOUTON = 0x00000001,
    }
}
