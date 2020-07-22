using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="SECURITY_DESCRIPTOR_CONTROL"/> data type is a set of bit flags that qualify the meaning of a security descriptor or its components.
    /// Each security descriptor has a Control member that stores the <see cref="SECURITY_DESCRIPTOR_CONTROL"/> bits.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/en-us/windows/win32/secauthz/security-descriptor-control
    /// </para>
    /// </summary>
    /// <remarks>
    /// To get the control bits of a security descriptor, call the <see cref="GetSecurityDescriptorControl"/> function.
    /// To set the control bits of a security descriptor, use the functions for modifying security descriptors.
    /// For a list of these functions, see the See Also section.
    /// Applications can use the <see cref="SetSecurityDescriptorControl"/> function to set the control bits that relate to automatic inheritance of ACEs.
    /// The control value retrieved by the <see cref="GetSecurityDescriptorControl"/> function can include a combination
    /// of the following <see cref="SECURITY_DESCRIPTOR_CONTROL"/> bit flags.
    /// </remarks>
    public enum SECURITY_DESCRIPTOR_CONTROL : ushort
    {
        /// <summary>
        /// Indicates a required security descriptor in which the discretionary access control list (DACL)
        /// is set up to support automatic propagation of inheritable access control entries (ACEs) to existing child objects.
        /// For access control lists (ACLs) that support auto inheritance, this bit is always set.
        /// Protected servers can call the <see cref="ConvertToAutoInheritPrivateObjectSecurity"/> function to convert a security descriptor and set this flag.
        /// </summary>
        SE_DACL_AUTO_INHERIT_REQ = 0x0100,

        /// <summary>
        /// Indicates a security descriptor in which the discretionary access control list (DACL)
        /// is set up to support automatic propagation of inheritable access control entries (ACEs) to existing child objects.
        /// For access control lists (ACLs) that support auto inheritance, this bit is always set.
        /// Protected servers can call the <see cref="ConvertToAutoInheritPrivateObjectSecurity"/> function to convert a security descriptor and set this flag.
        /// </summary>
        SE_DACL_AUTO_INHERITED = 0x0400,

        /// <summary>
        /// <para>
        /// Indicates a security descriptor with a default DACL. For example, if the creator an object does not specify a DACL,
        /// the object receives the default DACL from the access token of the creator.
        /// This flag can affect how the system treats the DACL with respect to ACE inheritance.
        /// The system ignores this flag if the <see cref="SE_DACL_PRESENT"/> flag is not set.
        /// This flag is used to determine how the final DACL on the object is to be computed and is not stored physically
        /// in the security descriptor control of the securable object.
        /// To set this flag, use the <see cref="SetSecurityDescriptorDacl"/> function.
        /// </para>
        /// </summary>
        SE_DACL_DEFAULTED = 0x0008,

        /// <summary>
        /// Indicates a security descriptor that has a DACL.
        /// If this flag is not set, or if this flag is set and the DACL is NULL, the security descriptor allows full access to everyone.
        /// This flag is used to hold the security information specified by a caller until the security descriptor is associated with a securable object.
        /// After the security descriptor is associated with a securable object,
        /// the <see cref="SE_DACL_PRESENT"/> flag is always set in the security descriptor control.
        /// To set this flag, use the <see cref="SetSecurityDescriptorDacl"/> function.
        /// </summary>
        SE_DACL_PRESENT = 0x0004,

        /// <summary>
        /// Prevents the DACL of the security descriptor from being modified by inheritable ACEs.
        /// To set this flag, use the <see cref="SetSecurityDescriptorControl"/> function.
        /// </summary>
        SE_DACL_PROTECTED = 0x1000,

        /// <summary>
        /// Indicates that the security identifier (SID) of the security descriptor group was provided by a default mechanism.
        /// This flag can be used by a resource manager to identify objects whose security descriptor group was set by a default mechanism.
        /// To set this flag, use the <see cref="SetSecurityDescriptorGroup"/> function.
        /// </summary>
        SE_GROUP_DEFAULTED = 0x0002,

        /// <summary>
        /// Indicates that the SID of the owner of the security descriptor was provided by a default mechanism.
        /// This flag can be used by a resource manager to identify objects whose owner was set by a default mechanism.
        /// To set this flag, use the <see cref="SetSecurityDescriptorOwner"/> function.
        /// </summary>
        SE_OWNER_DEFAULTED = 0x0001,

        /// <summary>
        /// Indicates that the resource manager control is valid.
        /// </summary>
        SE_RM_CONTROL_VALID = 0x4000,

        /// <summary>
        /// Indicates a required security descriptor in which the system access control list (SACL) is
        /// set up to support automatic propagation of inheritable ACEs to existing child objects.
        /// The system sets this bit when it performs the automatic inheritance algorithm for the object and its existing child objects.
        /// To convert a security descriptor and set this flag, protected servers can call the <see cref="ConvertToAutoInheritPrivateObjectSecurity"/> function.
        /// </summary>
        SE_SACL_AUTO_INHERIT_REQ = 0x0200,

        /// <summary>
        /// Indicates a security descriptor in which the system access control list (SACL) is
        /// set up to support automatic propagation of inheritable ACEs to existing child objects.
        /// The system sets this bit when it performs the automatic inheritance algorithm for the object and its existing child objects.
        /// To convert a security descriptor and set this flag, protected servers can call the <see cref="ConvertToAutoInheritPrivateObjectSecurity"/> function.
        /// </summary>
        SE_SACL_AUTO_INHERITED = 0x0800,

        /// <summary>
        /// A default mechanism, rather than the original provider of the security descriptor, provided the SACL.
        /// This flag can affect how the system treats the SACL, with respect to ACE inheritance.
        /// The system ignores this flag if the <see cref="SE_SACL_PRESENT"/> flag is not set.
        /// To set this flag, use the <see cref="SetSecurityDescriptorSacl"/> function.
        /// </summary>
        SE_SACL_DEFAULTED = 0x0008,

        /// <summary>
        /// Indicates a security descriptor that has a SACL.
        /// To set this flag, use the <see cref="SetSecurityDescriptorSacl"/> function.
        /// </summary>
        SE_SACL_PRESENT = 0x0010,

        /// <summary>
        /// Prevents the SACL of the security descriptor from being modified by inheritable ACEs.
        /// To set this flag, use the <see cref="SetSecurityDescriptorControl"/> function.
        /// </summary>
        SE_SACL_PROTECTED = 0x2000,

        /// <summary>
        /// Indicates a self-relative security descriptor.
        /// If this flag is not set, the security descriptor is in absolute format.
        /// For more information, see Absolute and Self-Relative Security Descriptors.
        /// </summary>
        SE_SELF_RELATIVE = 0x8000,
    }
}
