using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="SID_IDENTIFIER_AUTHORITY"/> structure represents the top-level authority of a security identifier (SID).
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-sid_identifier_authority"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The identifier authority value identifies the agency that issued the SID. The following identifier authorities are predefined.
    /// SECURITY_NULL_SID_AUTHORITY: 0
    /// SECURITY_WORLD_SID_AUTHORITY: 1
    /// SECURITY_LOCAL_SID_AUTHORITY: 2
    /// SECURITY_CREATOR_SID_AUTHORITY: 3
    /// SECURITY_NON_UNIQUE_AUTHORITY: 4
    /// SECURITY_NT_AUTHORITY: 5
    /// SECURITY_RESOURCE_MANAGER_AUTHORITY: 9
    /// A SID must contain a top-level authority and at least one relative identifier (RID) value.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SID_IDENTIFIER_AUTHORITY
    {
        /// <summary>
        /// An array of 6 bytes specifying a SID's top-level authority.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public BYTE[] Value;
    }
}
