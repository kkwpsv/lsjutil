using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="SID_IDENTIFIER_AUTHORITY"/> structure represents the top-level authority of a security identifier (SID).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-sid_identifier_authority"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The identifier authority value identifies the agency that issued the SID.
    /// The following identifier authorities are predefined. 
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Identifier authority
    /// </term>
    /// <term>
    /// Value
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// SECURITY_NULL_SID_AUTHORITY
    /// </term>
    /// <term>
    /// 0
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// SECURITY_WORLD_SID_AUTHORITY
    /// </term>
    /// <term>
    /// 1
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// SECURITY_LOCAL_SID_AUTHORITY
    /// </term>
    /// <term>
    /// 2
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// SECURITY_CREATOR_SID_AUTHORITY
    /// </term>
    /// <term>
    /// 3
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// SECURITY_NON_UNIQUE_AUTHORITY
    /// </term>
    /// <term>
    /// 4
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// SECURITY_NT_AUTHORITY
    /// </term>
    /// <term>
    /// 5
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// SECURITY_RESOURCE_MANAGER_AUTHORITY
    /// </term>
    /// <term>
    /// 9
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// A SID must contain a top-level authority and at least one relative identifier (RID) value.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SID_IDENTIFIER_AUTHORITY
    {
        /// <summary>
        /// An array of 6 bytes specifying a SID's top-level authority.
        /// </summary>
        public ByValBYTEArrayStructForSize6 Value;
    }
}
