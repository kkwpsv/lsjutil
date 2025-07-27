using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Structs.PRIVILEGE_SET;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// <see cref="LUID_AND_ATTRIBUTES"/> represents a locally unique identifier (LUID) and its attributes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_luid_and_attributes"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An <see cref="LUID_AND_ATTRIBUTES"/> structure can represent an LUID whose attributes change frequently,
    /// such as when it is used to represent privileges in the <see cref="PRIVILEGE_SET"/> structure.
    /// Privileges are represented by LUIDs and have attributes indicating whether they are currently enabled or disabled.
    /// </para>
    /// <para>
    /// Be aware of the following derived types:
    /// </para>
    /// <code>
    /// typedef LUID_AND_ATTRIBUTES LUID_AND_ATTRIBUTES_ARRAY[ANYSIZE_ARRAY];
    /// typedef LUID_AND_ATTRIBUTES_ARRAY *PLUID_AND_ATTRIBUTES_ARRAY;
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LUID_AND_ATTRIBUTES
    {
        /// <summary>
        /// An LUID value.
        /// </summary>
        public LUID Luid;

        /// <summary>
        /// <para>
        /// Specifies attributes of the LUID. This value contains up to 32 one-bit flags.
        /// Its meaning depends on the definition and use of the LUID.
        /// </para>
        /// <para>
        /// The following attributes are defined for privileges:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Description
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
        /// <see cref="SE_PRIVILEGE_USED_FOR_ACCESS"/>
        /// </term>
        /// <term>
        /// The privilege was used to gain access to an object or service.
        /// This flag is used to identify the relevant privileges in a set passed by a client application that may contain unnecessary privileges.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ULONG Attributes;
    }
}
