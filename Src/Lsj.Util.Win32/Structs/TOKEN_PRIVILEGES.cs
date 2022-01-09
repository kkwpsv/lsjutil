using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PrivilegeAttributes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="TOKEN_PRIVILEGES"/> structure contains information about a set of privileges for an access token.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-token_privileges"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TOKEN_PRIVILEGES
    {
        /// <summary>
        /// This must be set to the number of entries in the Privileges array.
        /// </summary>
        public DWORD PrivilegeCount;

        /// <summary>
        /// Specifies an array of <see cref="LUID_AND_ATTRIBUTES"/> structures.
        /// Each structure contains the LUID and attributes of a privilege.
        /// To get the name of the privilege associated with a <see cref="LUID"/>, call the <see cref="LookupPrivilegeName"/> function,
        /// passing the address of the <see cref="LUID"/> as the value of the lpLuid parameter.
        /// Important
        /// The constant <see cref="ANYSIZE_ARRAY"/> is defined as 1 in the public header Winnt.h.
        /// To create this array with more than one element, you must allocate sufficient memory for the structure to take into account additional elements.
        /// The attributes of a privilege can be a combination of the following values.
        /// <see cref="SE_PRIVILEGE_ENABLED"/>: The privilege is enabled.
        /// <see cref="SE_PRIVILEGE_ENABLED_BY_DEFAULT"/>: The privilege is enabled by default.
        /// <see cref="SE_PRIVILEGE_REMOVED"/>: Used to remove a privilege. For details, see <see cref="AdjustTokenPrivileges"/>.
        /// <see cref="SE_PRIVILEGE_USED_FOR_ACCESS"/>:
        /// The privilege was used to gain access to an object or service.
        /// This flag is used to identify the relevant privileges in a set passed by a client application that may contain unnecessary privileges.
        /// </summary>
        public LUID_AND_ATTRIBUTES Privileges;
    }
}
