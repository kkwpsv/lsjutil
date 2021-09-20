namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// AceFlags
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-ace_header"/>
    /// </para>
    /// </summary>
    public enum AceFlags : byte
    {
        /// <summary>
        /// Noncontainer child objects inherit the ACE as an effective ACE.
        /// For child objects that are containers, the ACE is inherited as an inherit-only ACE
        /// unless the <see cref="NO_PROPAGATE_INHERIT_ACE"/> bit flag is also set.
        /// </summary>
        OBJECT_INHERIT_ACE = 0x1,

        /// <summary>
        /// Child objects that are containers, such as directories, inherit the ACE as an effective ACE.
        /// The inherited ACE is inheritable unless the <see cref="NO_PROPAGATE_INHERIT_ACE"/> bit flag is also set.
        /// </summary>
        CONTAINER_INHERIT_ACE = 0x2,

        /// <summary>
        /// If the ACE is inherited by a child object,
        /// the system clears the <see cref="OBJECT_INHERIT_ACE"/> and <see cref="CONTAINER_INHERIT_ACE"/> flags in the inherited ACE.
        /// This prevents the ACE from being inherited by subsequent generations of objects.
        /// </summary>
        NO_PROPAGATE_INHERIT_ACE = 0x4,

        /// <summary>
        /// Indicates an inherit-only ACE, which does not control access to the object to which it is attached.
        /// If this flag is not set, the ACE is an effective ACE which controls access to the object to which it is attached.
        /// Both effective and inherit-only ACEs can be inherited depending on the state of the other inheritance flags.
        /// </summary>
        INHERIT_ONLY_ACE = 0x8,

        /// <summary>
        /// Indicates that the ACE was inherited.
        /// The system sets this bit when it propagates an inherited ACE to a child object.
        /// </summary>
        INHERITED_ACE = 0x10,

        /// <summary>
        /// Used with system-audit ACEs in a system access control list (SACL) to generate audit messages for failed access attempts.
        /// </summary>
        FAILED_ACCESS_ACE_FLAG = 0x80,

        /// <summary>
        /// Used with system-audit ACEs in a SACL to generate audit messages for successful access attempts.
        /// </summary>
        SUCCESSFUL_ACCESS_ACE_FLAG = 0x40,
    }
}
