using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.Enums.StandardAccessRights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// An application cannot change the access control list of an object unless the application has the rights to do so. 
    /// These rights are controlled by a security descriptor in the access token for the object.
    /// For more information about security, see Access Control Model.
    /// </para>
    /// <para>
    /// To get or set the security descriptor for an access token,
    /// call the <see cref="GetKernelObjectSecurity"/> and <see cref="SetKernelObjectSecurity"/> functions.
    /// </para>
    /// <para>
    /// When you call the <see cref="OpenProcessToken"/> or <see cref="OpenThreadToken"/> function to get a handle to an access token,
    /// the system checks the requested access rights against the DACL in the token's security descriptor.
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The <see cref="DELETE"/>, <see cref="READ_CONTROL"/>, <see cref="WRITE_DAC"/>, and <see cref="WRITE_OWNER"/> standard access rights.
    /// Access tokens do not support the <see cref="SYNCHRONIZE"/> standard access right.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The <see cref="ACCESS_SYSTEM_SECURITY"/> right to get or set the SACL in the object's security descriptor.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The specific access rights for access tokens, which are listed in the following table.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// The following are valid access rights for access-token objects:
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/secauthz/access-rights-for-access-token-objects"/>
    /// </para>
    /// </summary>
    public enum TokenAccessRights : uint
    {
        /// <summary>
        /// Required to change the default owner, primary group, or DACL of an access token.
        /// </summary>
        TOKEN_ADJUST_DEFAULT = 0x0080,

        /// <summary>
        /// Required to adjust the attributes of the groups in an access token.
        /// </summary>
        TOKEN_ADJUST_GROUPS = 0x0040,

        /// <summary>
        /// Required to enable or disable the privileges in an access token.
        /// </summary>
        TOKEN_ADJUST_PRIVILEGES = 0x0020,

        /// <summary>
        /// Required to adjust the session ID of an access token.
        /// The SE_TCB_NAME privilege is required.
        /// </summary>
        TOKEN_ADJUST_SESSIONID = 0x0100,

        /// <summary>
        /// Required to attach a primary token to a process.
        /// The SE_ASSIGNPRIMARYTOKEN_NAME privilege is also required to accomplish this task.
        /// </summary>
        TOKEN_ASSIGN_PRIMARY = 0x0001,

        /// <summary>
        /// Required to duplicate an access token.
        /// </summary>
        TOKEN_DUPLICATE = 0x0002,

        /// <summary>
        /// Combines <see cref="STANDARD_RIGHTS_EXECUTE"/> and <see cref="TOKEN_IMPERSONATE"/>.
        /// </summary>
        TOKEN_EXECUTE = STANDARD_RIGHTS_EXECUTE,

        /// <summary>
        /// Required to attach an impersonation access token to a process.
        /// </summary>
        TOKEN_IMPERSONATE = 0x0004,

        /// <summary>
        /// Required to query an access token.
        /// </summary>
        TOKEN_QUERY = 0x0008,

        /// <summary>
        /// Required to query the source of an access token.
        /// </summary>
        TOKEN_QUERY_SOURCE = 0x0010,

        /// <summary>
        /// Combines <see cref="STANDARD_RIGHTS_READ"/> and <see cref="TOKEN_QUERY"/>.
        /// </summary>
        TOKEN_READ = STANDARD_RIGHTS_READ | TOKEN_QUERY,

        /// <summary>
        /// Combines <see cref="STANDARD_RIGHTS_WRITE"/>, <see cref="TOKEN_ADJUST_PRIVILEGES"/>,
        /// <see cref="TOKEN_ADJUST_GROUPS"/>, and <see cref="TOKEN_ADJUST_DEFAULT"/>.
        /// </summary>
        TOKEN_WRITE = STANDARD_RIGHTS_WRITE | TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT,

        /// <summary>
        /// Combines all possible access rights for a token.
        /// </summary>
        TOKEN_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | TOKEN_ASSIGN_PRIMARY | TOKEN_DUPLICATE | TOKEN_IMPERSONATE | TOKEN_QUERY
            | TOKEN_QUERY_SOURCE | TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT,
    }
}
