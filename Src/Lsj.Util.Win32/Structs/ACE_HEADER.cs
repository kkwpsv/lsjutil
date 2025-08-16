using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.AceTypes;
using static Lsj.Util.Win32.Enums.AceFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ACE_HEADER"/> structure defines the type and size of an access control entry (ACE).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-ace_header"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="ACE_HEADER"/> structure is the first member of the various types of ACE structures, such as <see cref="ACCESS_ALLOWED_ACE"/>.
    /// </para>
    /// <para>
    /// System-alarm ACEs are not currently supported.
    /// The <see cref="AceType"/> member cannot specify the <see cref="SYSTEM_ALARM_ACE_TYPE"/> or <see cref="SYSTEM_ALARM_OBJECT_ACE_TYPE"/> values.
    /// Do not use the <see cref="SYSTEM_ALARM_ACE"/> or <see cref="SYSTEM_ALARM_OBJECT_ACE"/> structures.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACE_HEADER
    {
        /// <summary>
        /// <para>
        /// Specifies the ACE type. This member can be one of the following values.
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
        /// <see cref="ACCESS_ALLOWED_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Access-allowed ACE that uses the <see cref="ACCESS_ALLOWED_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_ALLOWED_CALLBACK_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Access-allowed callback ACE that uses the <see cref="ACCESS_ALLOWED_CALLBACK_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_ALLOWED_CALLBACK_OBJECT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Object-specific access-allowed callback ACE that uses the <see cref="ACCESS_ALLOWED_CALLBACK_OBJECT_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_ALLOWED_COMPOUND_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Reserved.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_ALLOWED_OBJECT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Object-specific access-allowed ACE that uses the <see cref="ACCESS_ALLOWED_OBJECT_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_DENIED_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Access-denied ACE that uses the <see cref="ACCESS_DENIED_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_DENIED_CALLBACK_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Access-denied callback ACE that uses the <see cref="ACCESS_DENIED_CALLBACK_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Object-specific access-denied callback ACE that uses the <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_DENIED_OBJECT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Object-specific access-denied ACE that uses the <see cref="ACCESS_DENIED_OBJECT_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_MAX_MS_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Same as SYSTEM_ALARM_OBJECT_ACE_TYPE.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_MAX_MS_V2_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Same as SYSTEM_ALARM_ACE_TYPE.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_MAX_MS_V3_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Reserved.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_MAX_MS_V4_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Same as SYSTEM_ALARM_OBJECT_ACE_TYPE.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_MAX_MS_OBJECT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Same as SYSTEM_ALARM_OBJECT_ACE_TYPE.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_MIN_MS_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Same as ACCESS_ALLOWED_ACE_TYPE.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ACCESS_MIN_MS_OBJECT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Same as ACCESS_ALLOWED_OBJECT_ACE_TYPE.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYSTEM_ALARM_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Reserved for future use. System-alarm ACE that uses the <see cref="SYSTEM_ALARM_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYSTEM_ALARM_CALLBACK_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Reserved for future use. System-alarm callback ACE that uses the <see cref="SYSTEM_ALARM_CALLBACK_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYSTEM_ALARM_CALLBACK_OBJECT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Reserved for future use. Object-specific system-alarm callback ACE that uses the <see cref="SYSTEM_ALARM_CALLBACK_OBJECT_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYSTEM_ALARM_OBJECT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Reserved for future use. Object-specific system-alarm ACE that uses the <see cref="SYSTEM_ALARM_OBJECT_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYSTEM_AUDIT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// System-audit ACE that uses the <see cref="SYSTEM_AUDIT_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYSTEM_AUDIT_CALLBACK_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// System-audit callback ACE that uses the <see cref="SYSTEM_AUDIT_CALLBACK_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYSTEM_AUDIT_CALLBACK_OBJECT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Object-specific system-audit callback ACE that uses the <see cref="SYSTEM_AUDIT_CALLBACK_OBJECT_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYSTEM_AUDIT_OBJECT_ACE_TYPE"/>
        /// </term>
        /// <term>
        /// Object-specific system-audit ACE that uses the <see cref="SYSTEM_AUDIT_OBJECT_ACE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SYSTEM_MANDATORY_LABEL_ACE_TYPE"/>
        /// </para>
        /// <para>
        /// 0x11
        /// </para>
        /// </term>
        /// <term>
        /// Mandatory label ACE that uses the <see cref="SYSTEM_MANDATORY_LABEL_ACE"/> structure.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public AceTypes AceType;

        /// <summary>
        /// <para>
        /// Specifies a set of ACE type-specific control flags. This member can be a combination of the following values.
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
        /// <see cref="CONTAINER_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// Child objects that are containers, such as directories, inherit the ACE as an effective ACE.
        /// The inherited ACE is inheritable unless the <see cref="NO_PROPAGATE_INHERIT_ACE"/> bit flag is also set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FAILED_ACCESS_ACE_FLAG"/>
        /// </term>
        /// <term>
        /// Used with system-audit ACEs in a system access control list (SACL) to generate audit messages for failed access attempts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="INHERIT_ONLY_ACE"/>
        /// </term>
        /// <term>
        /// <para>
        /// Indicates an inherit-only ACE, which does not control access to the object to which it is attached.
        /// If this flag is not set, the ACE is an effective ACE which controls access to the object to which it is attached.
        /// </para>
        /// <para>
        /// Both effective and inherit-only ACEs can be inherited depending on the state of the other inheritance flags.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="INHERITED_ACE"/>
        /// </term>
        /// <term>
        /// Indicates that the ACE was inherited.
        /// The system sets this bit when it propagates an inherited ACE to a child object.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NO_PROPAGATE_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// If the ACE is inherited by a child object,
        /// the system clears the <see cref="OBJECT_INHERIT_ACE"/> and <see cref="CONTAINER_INHERIT_ACE"/> flags in the inherited ACE.
        /// This prevents the ACE from being inherited by subsequent generations of objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBJECT_INHERIT_ACE"/>
        /// </term>
        /// <term>
        /// <para>
        /// Noncontainer child objects inherit the ACE as an effective ACE.
        /// </para>
        /// <para>
        /// For child objects that are containers, the ACE is inherited as an inherit-only ACE unless the <see cref="NO_PROPAGATE_INHERIT_ACE"/> bit flag is also set.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SUCCESSFUL_ACCESS_ACE_FLAG"/>
        /// </term>
        /// <term>
        /// Used with system-audit ACEs in a SACL to generate audit messages for successful access attempts.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public AceFlags AceFlags;

        /// <summary>
        /// Specifies the size, in bytes, of the ACE.
        /// </summary>
        public WORD AceSize;
    }
}
