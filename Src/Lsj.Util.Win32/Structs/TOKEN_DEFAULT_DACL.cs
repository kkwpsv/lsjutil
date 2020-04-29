using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="TOKEN_DEFAULT_DACL"/> structure specifies a discretionary access control list (DACL).
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-token_default_dacl
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="GetTokenInformation"/> function retrieves the default DACL for an access token,
    /// in the form of a <see cref="TOKEN_DEFAULT_DACL"/> structure.
    /// This structure is also used with the <see cref="SetTokenInformation"/> function to set the default DACL.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TOKEN_DEFAULT_DACL
    {
        /// <summary>
        /// A pointer to an <see cref="ACL"/> structure assigned by default to any objects created by the user.
        /// The user is represented by the access token.
        /// </summary>
        public IntPtr DefaultDacl;
    }
}
