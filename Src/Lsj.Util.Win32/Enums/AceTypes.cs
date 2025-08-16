namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// ACE types
    /// </summary>
    public enum AceTypes : byte
    {
        /// <summary>
        /// ACCESS_MIN_MS_ACE_TYPE
        /// </summary>
        ACCESS_MIN_MS_ACE_TYPE = 0x0,

        /// <summary>
        /// ACCESS_ALLOWED_ACE_TYPE
        /// </summary>
        ACCESS_ALLOWED_ACE_TYPE = 0x0,

        /// <summary>
        /// ACCESS_DENIED_ACE_TYPE
        /// </summary>
        ACCESS_DENIED_ACE_TYPE = 0x1,

        /// <summary>
        /// SYSTEM_AUDIT_ACE_TYPE
        /// </summary>
        SYSTEM_AUDIT_ACE_TYPE = 0x2,

        /// <summary>
        /// SYSTEM_ALARM_ACE_TYPE
        /// </summary>
        SYSTEM_ALARM_ACE_TYPE = 0x3,

        /// <summary>
        /// ACCESS_MAX_MS_V2_ACE_TYPE
        /// </summary>
        ACCESS_MAX_MS_V2_ACE_TYPE = 0x3,

        /// <summary>
        /// ACCESS_ALLOWED_COMPOUND_ACE_TYPE
        /// </summary>
        ACCESS_ALLOWED_COMPOUND_ACE_TYPE = 0x4,

        /// <summary>
        /// ACCESS_MAX_MS_V3_ACE_TYPE
        /// </summary>
        ACCESS_MAX_MS_V3_ACE_TYPE = 0x4,

        /// <summary>
        /// ACCESS_MIN_MS_OBJECT_ACE_TYPE
        /// </summary>
        ACCESS_MIN_MS_OBJECT_ACE_TYPE = 0x5,

        /// <summary>
        /// ACCESS_ALLOWED_OBJECT_ACE_TYPE
        /// </summary>
        ACCESS_ALLOWED_OBJECT_ACE_TYPE = 0x5,

        /// <summary>
        /// ACCESS_DENIED_OBJECT_ACE_TYPE
        /// </summary>
        ACCESS_DENIED_OBJECT_ACE_TYPE = 0x6,

        /// <summary>
        /// SYSTEM_AUDIT_OBJECT_ACE_TYPE
        /// </summary>
        SYSTEM_AUDIT_OBJECT_ACE_TYPE = 0x7,

        /// <summary>
        /// SYSTEM_ALARM_OBJECT_ACE_TYPE
        /// </summary>
        SYSTEM_ALARM_OBJECT_ACE_TYPE = 0x8,

        /// <summary>
        /// ACCESS_MAX_MS_OBJECT_ACE_TYPE
        /// </summary>
        ACCESS_MAX_MS_OBJECT_ACE_TYPE = 0x8,

        /// <summary>
        /// ACCESS_MAX_MS_V4_ACE_TYPE
        /// </summary>
        ACCESS_MAX_MS_V4_ACE_TYPE = 0x8,

        /// <summary>
        /// ACCESS_MAX_MS_ACE_TYPE
        /// </summary>
        ACCESS_MAX_MS_ACE_TYPE = 0x8,

        /// <summary>
        /// ACCESS_ALLOWED_CALLBACK_ACE_TYPE
        /// </summary>
        ACCESS_ALLOWED_CALLBACK_ACE_TYPE = 0x9,

        /// <summary>
        /// ACCESS_DENIED_CALLBACK_ACE_TYPE
        /// </summary>
        ACCESS_DENIED_CALLBACK_ACE_TYPE = 0xA,

        /// <summary>
        /// ACCESS_ALLOWED_CALLBACK_OBJECT_ACE_TYPE
        /// </summary>
        ACCESS_ALLOWED_CALLBACK_OBJECT_ACE_TYPE = 0xB,

        /// <summary>
        /// ACCESS_DENIED_CALLBACK_OBJECT_ACE_TYPE
        /// </summary>
        ACCESS_DENIED_CALLBACK_OBJECT_ACE_TYPE = 0xC,

        /// <summary>
        /// SYSTEM_AUDIT_CALLBACK_ACE_TYPE
        /// </summary>
        SYSTEM_AUDIT_CALLBACK_ACE_TYPE = 0xD,

        /// <summary>
        /// SYSTEM_ALARM_CALLBACK_ACE_TYPE
        /// </summary>
        SYSTEM_ALARM_CALLBACK_ACE_TYPE = 0xE,

        /// <summary>
        /// SYSTEM_AUDIT_CALLBACK_OBJECT_ACE_TYPE
        /// </summary>
        SYSTEM_AUDIT_CALLBACK_OBJECT_ACE_TYPE = 0xF,

        /// <summary>
        /// SYSTEM_ALARM_CALLBACK_OBJECT_ACE_TYPE
        /// </summary>
        SYSTEM_ALARM_CALLBACK_OBJECT_ACE_TYPE = 0x10,

        /// <summary>
        /// SYSTEM_MANDATORY_LABEL_ACE_TYPE
        /// </summary>
        SYSTEM_MANDATORY_LABEL_ACE_TYPE = 0x11,
    }
}
