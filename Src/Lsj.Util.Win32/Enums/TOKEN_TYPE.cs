using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="TOKEN_TYPE"/> enumeration contains values that differentiate between a primary token and an impersonation token.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-token_type"/>
    /// </para>
    /// </summary>
    public enum TOKEN_TYPE
    {
        /// <summary>
        /// Indicates a primary token.
        /// </summary>
        TokenPrimary = 1,

        /// <summary>
        /// Indicates an impersonation token.
        /// </summary>
        TokenImpersonation
    }
}
