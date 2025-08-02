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
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_privileges"/>
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
        /// <para>
        /// Specifies an array of <see cref="LUID_AND_ATTRIBUTES"/> structures.
        /// Each structure contains the <see cref="LUID"/> and attributes of a privilege.
        /// To get the name of the privilege associated with a <see cref="LUID"/>,
        /// call the <see cref="LookupPrivilegeName"/> function,
        /// passing the address of the <see cref="LUID"/> as the value of the lpLuid parameter.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// The constant <see cref="ANYSIZE_ARRAY"/> is defined as 1 in the public header Winnt.h.
        /// To create this array with more than one element,
        /// you must allocate sufficient memory for the structure to take into account additional elements.
        /// </para>
        /// <para>
        /// The attributes of a privilege can be a combination of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="SE_PRIVILEGE_ENABLED"/>
        /// </term>
        /// <term>
        /// The privilege is enabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_PRIVILEGE_ENABLED_BY_DEFAULT"/>
        /// </term>
        /// <term>
        /// The privilege is enabled by default.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_PRIVILEGE_REMOVED"/>
        /// </term>
        /// <term>
        /// Used to remove a privilege. For details, see <see cref="AdjustTokenPrivileges"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_PRIVILEGE_USED_FOR_ACCESS"/>
        /// </term>
        /// <term>
        /// The privilege was used to gain access to an object or service.
        /// This flag is used to identify the relevant privileges in a set passed by a client application that may contain unnecessary privileges.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public AnySizeArray<LUID_AND_ATTRIBUTES> Privileges;
    }
}
