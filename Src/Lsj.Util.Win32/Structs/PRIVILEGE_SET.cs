using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="PRIVILEGE_SET"/> structure specifies a set of privileges.
    /// It is also used to indicate which, if any, privileges are held by a user or group requesting access to an object.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-privilege_set"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A privilege is used to control access to an object or service more strictly than is typical with discretionary access control.
    /// A system manager uses privileges to control which users are able to manipulate system resources.
    /// An application uses privileges when it changes a system-wide resource, such as when it changes the system time or shuts down the system.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PRIVILEGE_SET
    {
        /// <summary>
        /// PRIVILEGE_SET_ALL_NECESSARY
        /// </summary>
        public const uint PRIVILEGE_SET_ALL_NECESSARY = 1;

        /// <summary>
        /// SE_PRIVILEGE_ENABLED_BY_DEFAULT
        /// </summary>
        public const uint SE_PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001;

        /// <summary>
        /// SE_PRIVILEGE_ENABLED
        /// </summary>
        public const uint SE_PRIVILEGE_ENABLED = 0x00000002;

        /// <summary>
        /// SE_PRIVILEGE_USED_FOR_ACCESS
        /// </summary>
        public const uint SE_PRIVILEGE_USED_FOR_ACCESS = 0x80000000;

        /// <summary>
        /// Specifies the number of privileges in the privilege set.
        /// </summary>
        public DWORD PrivilegeCount;

        /// <summary>
        /// Specifies a control flag related to the privileges.
        /// The <see cref="PRIVILEGE_SET_ALL_NECESSARY"/> control flag is currently defined.
        /// It indicates that all of the specified privileges must be held by the process requesting access.
        /// If this flag is not set, the presence of any privileges in the user's access token grants the access.
        /// </summary>
        public DWORD Control;

        /// <summary>
        /// Specifies an array of <see cref="LUID_AND_ATTRIBUTES"/> structures describing the set's privileges.
        /// The following attributes are defined for privileges.
        /// <see cref="SE_PRIVILEGE_ENABLED_BY_DEFAULT"/>: The privilege is enabled by default.
        /// <see cref="SE_PRIVILEGE_ENABLED"/>: The privilege is enabled.
        /// <see cref="SE_PRIVILEGE_USED_FOR_ACCESS"/>:
        /// The privilege was used to gain access to an object or service.
        /// This flag is used to identify the relevant privileges in a set passed by a client application that may contain unnecessary privileges.
        /// </summary>
        public LUID_AND_ATTRIBUTES Privilege;
    }
}
