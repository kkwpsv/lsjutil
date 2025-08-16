namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Text capabilities
    /// </summary>
    public enum TextCapabilities : uint
    {
        /// <summary>
        /// TC_OP_CHARACTER
        /// </summary>
        TC_OP_CHARACTER = 0x00000001,

        /// <summary>
        /// TC_OP_STROKE
        /// </summary>
        TC_OP_STROKE = 0x00000002,

        /// <summary>
        /// TC_CP_STROKE
        /// </summary>
        TC_CP_STROKE = 0x00000004,

        /// <summary>
        /// TC_CR_90
        /// </summary>
        TC_CR_90 = 0x00000008,

        /// <summary>
        /// TC_CR_ANY
        /// </summary>
        TC_CR_ANY = 0x00000010,

        /// <summary>
        /// TC_SF_X_YINDEP
        /// </summary>
        TC_SF_X_YINDEP = 0x00000020,

        /// <summary>
        /// TC_SA_DOUBLE
        /// </summary>
        TC_SA_DOUBLE = 0x00000040,

        /// <summary>
        /// TC_SA_INTEGER
        /// </summary>
        TC_SA_INTEGER = 0x00000080,

        /// <summary>
        /// TC_SA_CONTIN
        /// </summary>
        TC_SA_CONTIN = 0x00000100,

        /// <summary>
        /// TC_EA_DOUBLE
        /// </summary>
        TC_EA_DOUBLE = 0x00000200,

        /// <summary>
        /// TC_IA_ABLE
        /// </summary>
        TC_IA_ABLE = 0x00000400,

        /// <summary>
        /// TC_UA_ABLE
        /// </summary>
        TC_UA_ABLE = 0x00000800,

        /// <summary>
        /// TC_SO_ABLE
        /// </summary>
        TC_SO_ABLE = 0x00001000,

        /// <summary>
        /// TC_RA_ABLE
        /// </summary>
        TC_RA_ABLE = 0x00002000,

        /// <summary>
        /// TC_VA_ABLE
        /// </summary>
        TC_VA_ABLE = 0x00004000,

        /// <summary>
        /// TC_RESERVED
        /// </summary>
        TC_RESERVED = 0x00008000,

        /// <summary>
        /// TC_SCROLLBLT
        /// </summary>
        TC_SCROLLBLT = 0x00010000,
    }
}
