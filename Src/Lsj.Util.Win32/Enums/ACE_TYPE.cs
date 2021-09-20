using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// ACE type
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-ace_header"/>
    /// </para>
    /// </summary>
    public enum ACE_TYPE : byte
    {
        /// <summary>
        /// Same as <see cref="ACCESS_ALLOWED_ACE_TYPE"/>.
        /// </summary>
        ACCESS_MIN_MS_ACE_TYPE = 0x0,

        /// <summary>
        /// Access-allowed ACE that uses the <see cref="ACCESS_ALLOWED_ACE"/> structure.
        /// </summary>
        ACCESS_ALLOWED_ACE_TYPE = 0x0,

        /// <summary>
        /// Access-denied ACE that uses the <see cref="ACCESS_DENIED_ACE"/> structure.
        /// </summary>
        ACCESS_DENIED_ACE_TYPE = 0x1,

        /// <summary>
        /// System-audit ACE that uses the <see cref="SYSTEM_AUDIT_ACE"/> structure.
        /// </summary>
        SYSTEM_AUDIT_ACE_TYPE = 0x2,

        /// <summary>
        /// Reserved for future use.
        /// System-alarm ACE that uses the <see cref="SYSTEM_ALARM_ACE"/> structure.
        /// </summary>
        SYSTEM_ALARM_ACE_TYPE = 0x3,

        /// <summary>
        /// Same as <see cref="SYSTEM_ALARM_ACE_TYPE"/>.
        /// </summary>
        ACCESS_MAX_MS_V2_ACE_TYPE = 0x3,

        /// <summary>
        /// Reserved.
        /// </summary>
        ACCESS_ALLOWED_COMPOUND_ACE_TYPE = 0x4,

        /// <summary>
        /// Reserved.
        /// </summary>
        ACCESS_MAX_MS_V3_ACE_TYPE = 0x4,

        /// <summary>
        /// Same as <see cref="ACCESS_ALLOWED_OBJECT_ACE_TYPE"/>.
        /// </summary>
        ACCESS_MIN_MS_OBJECT_ACE_TYPE = 0x5,

        /// <summary>
        /// Object-specific access-allowed ACE that uses the <see cref="ACCESS_ALLOWED_OBJECT_ACE"/> structure.
        /// </summary>
        ACCESS_ALLOWED_OBJECT_ACE_TYPE = 0x5,

        /// <summary>
        /// Object-specific access-denied ACE that uses the <see cref="ACCESS_DENIED_OBJECT_ACE"/> structure.
        /// </summary>
        ACCESS_DENIED_OBJECT_ACE_TYPE = 0x6,

        /// <summary>
        /// Object-specific system-audit ACE that uses the <see cref="SYSTEM_AUDIT_OBJECT_ACE"/> structure.
        /// </summary>
        SYSTEM_AUDIT_OBJECT_ACE_TYPE = 0x7,

        /// <summary>
        /// Reserved for future use.
        /// Object-specific system-alarm ACE that uses the <see cref="SYSTEM_ALARM_OBJECT_ACE"/> structure.
        /// </summary>
        SYSTEM_ALARM_OBJECT_ACE_TYPE = 0x8,

        /// <summary>
        /// Same as <see cref="SYSTEM_ALARM_OBJECT_ACE_TYPE"/>.
        /// </summary>
        ACCESS_MAX_MS_OBJECT_ACE_TYPE = 0x8,

        /// <summary>
        /// Same as <see cref="SYSTEM_ALARM_OBJECT_ACE_TYPE"/>.
        /// </summary>
        ACCESS_MAX_MS_V4_ACE_TYPE = 0x8,

        /// <summary>
        /// Same as <see cref="SYSTEM_ALARM_OBJECT_ACE_TYPE"/>.
        /// </summary>
        ACCESS_MAX_MS_ACE_TYPE = 0x8,

        /// <summary>
        /// Access-allowed callback ACE that uses the <see cref="ACCESS_ALLOWED_CALLBACK_ACE"/> structure.
        /// </summary>
        ACCESS_ALLOWED_CALLBACK_ACE_TYPE = 0x9,

        /// <summary>
        /// Access-denied callback ACE that uses the <see cref="ACCESS_DENIED_CALLBACK_ACE"/> structure.
        /// </summary>
        ACCESS_DENIED_CALLBACK_ACE_TYPE = 0xA,

        /// <summary>
        /// Object-specific access-allowed callback ACE that uses the <see cref="ACCESS_ALLOWED_CALLBACK_OBJECT_ACE"/> structure.
        /// </summary>
        ACCESS_ALLOWED_CALLBACK_OBJECT_ACE_TYPE = 0xB,

        /// <summary>
        /// Object-specific access-denied callback ACE that uses the <see cref="ACCESS_DENIED_CALLBACK_OBJECT_ACE"/> structure.
        /// </summary>
        ACCESS_DENIED_CALLBACK_OBJECT_ACE_TYPE = 0xC,

        /// <summary>
        /// System-audit callback ACE that uses the <see cref="SYSTEM_AUDIT_CALLBACK_ACE"/> structure.
        /// </summary>
        SYSTEM_AUDIT_CALLBACK_ACE_TYPE = 0xD,

        /// <summary>
        /// Reserved for future use.
        /// System-alarm callback ACE that uses the <see cref="SYSTEM_ALARM_CALLBACK_ACE"/> structure.
        /// </summary>
        SYSTEM_ALARM_CALLBACK_ACE_TYPE = 0xE,

        /// <summary>
        /// Object-specific system-audit callback ACE that uses the <see cref="SYSTEM_AUDIT_CALLBACK_OBJECT_ACE"/> structure.
        /// </summary>
        SYSTEM_AUDIT_CALLBACK_OBJECT_ACE_TYPE = 0xF,

        /// <summary>
        /// Reserved for future use.
        /// Object-specific system-alarm callback ACE that uses the <see cref="SYSTEM_ALARM_CALLBACK_OBJECT_ACE"/> structure.
        /// </summary>
        SYSTEM_ALARM_CALLBACK_OBJECT_ACE_TYPE = 0x10,

        /// <summary>
        /// Mandatory label ACE that uses the <see cref="SYSTEM_MANDATORY_LABEL_ACE"/> structure.
        /// </summary>
        SYSTEM_MANDATORY_LABEL_ACE_TYPE = 0x11,
    }
}
