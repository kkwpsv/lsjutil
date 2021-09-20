using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ACE_TYPE;
using static Lsj.Util.Win32.Enums.AceFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ACE_HEADER"/> structure defines the type and size of an access control entry (ACE).
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-ace_header"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The ACE_HEADER structure is the first member of the various types of ACE structures, such as <see cref="ACCESS_ALLOWED_ACE"/>.
    /// System-alarm ACEs are not currently supported.
    /// The <see cref="AceType"/> member cannot specify the <see cref="SYSTEM_ALARM_ACE_TYPE"/> or <see cref="SYSTEM_ALARM_OBJECT_ACE_TYPE"/> values.
    /// Do not use the <see cref="SYSTEM_ALARM_ACE"/> or <see cref="SYSTEM_ALARM_OBJECT_ACE"/> structures.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACE_HEADER
    {
        /// <summary>
        /// Specifies the ACE type.
        /// This member can be one of the following values.
        /// <see cref="ACCESS_ALLOWED_ACE_TYPE"/>, <see cref="ACCESS_ALLOWED_CALLBACK_ACE_TYPE"/>,
        /// <see cref="ACCESS_ALLOWED_CALLBACK_OBJECT_ACE_TYPE"/>, <see cref="ACCESS_ALLOWED_COMPOUND_ACE_TYPE"/>,
        /// <see cref="ACCESS_ALLOWED_OBJECT_ACE_TYPE"/>, <see cref="ACCESS_DENIED_ACE_TYPE"/>,
        /// <see cref="ACCESS_DENIED_CALLBACK_ACE_TYPE"/>, <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE_TYPE"/>,
        /// <see cref="ACCESS_DENIED_OBJECT_ACE_TYPE"/>, <see cref="ACCESS_MAX_MS_ACE_TYPE"/>,
        /// <see cref="ACCESS_MAX_MS_V2_ACE_TYPE"/>, <see cref="ACCESS_MAX_MS_V3_ACE_TYPE"/>,
        /// <see cref="ACCESS_MAX_MS_V4_ACE_TYPE"/>, <see cref="ACCESS_MAX_MS_OBJECT_ACE_TYPE"/>,
        /// <see cref="ACCESS_MIN_MS_ACE_TYPE"/>, <see cref="ACCESS_MIN_MS_OBJECT_ACE_TYPE"/>,
        /// <see cref="SYSTEM_ALARM_ACE_TYPE"/>, <see cref="SYSTEM_ALARM_CALLBACK_ACE_TYPE"/>,
        /// <see cref="SYSTEM_ALARM_CALLBACK_OBJECT_ACE_TYPE"/>, <see cref="SYSTEM_ALARM_OBJECT_ACE_TYPE"/>,
        /// <see cref="SYSTEM_AUDIT_ACE_TYPE"/>, <see cref="SYSTEM_AUDIT_CALLBACK_ACE_TYPE"/>,
        /// <see cref="SYSTEM_AUDIT_CALLBACK_OBJECT_ACE_TYPE"/>, <see cref="SYSTEM_AUDIT_OBJECT_ACE_TYPE"/>,
        /// <see cref="SYSTEM_MANDATORY_LABEL_ACE_TYPE"/>
        /// </summary>
        public ACE_TYPE AceType;

        /// <summary>
        /// Specifies a set of ACE type-specific control flags.
        /// This member can be a combination of the following values.
        /// <see cref="CONTAINER_INHERIT_ACE"/>, <see cref="FAILED_ACCESS_ACE_FLAG"/>, <see cref="INHERIT_ONLY_ACE"/>,
        /// <see cref="INHERITED_ACE"/>, <see cref="NO_PROPAGATE_INHERIT_ACE"/>, <see cref="OBJECT_INHERIT_ACE"/>,
        /// <see cref="SUCCESSFUL_ACCESS_ACE_FLAG"/>
        /// </summary>
        public AceFlags AceFlags;

        /// <summary>
        /// Specifies the size, in bytes, of the ACE.
        /// </summary>
        public WORD AceSize;
    }
}
