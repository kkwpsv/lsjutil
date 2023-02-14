namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Text Capabilities
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdevicecaps"/>
    /// </para>
    /// </summary>
    public enum TextCapabilities : uint
    {
        /// <summary>
        /// Device is capable of character output precision.
        /// </summary>
        TC_OP_CHARACTER = 0x00000001,

        /// <summary>
        /// Device is capable of stroke output precision.
        /// </summary>
        TC_OP_STROKE = 0x00000002,

        /// <summary>
        /// Device is capable of stroke clip precision.
        /// </summary>
        TC_CP_STROKE = 0x00000004,

        /// <summary>
        /// Device is capable of 90-degree character rotation.
        /// </summary>
        TC_CR_90 = 0x00000008,

        /// <summary>
        /// Device is capable of any character rotation.
        /// </summary>
        TC_CR_ANY = 0x00000010,

        /// <summary>
        /// Device can scale independently in the x- and y-directions.
        /// </summary>
        TC_SF_X_YINDEP = 0x00000020,

        /// <summary>
        /// Device is capable of doubled character for scaling.
        /// </summary>
        TC_SA_DOUBLE = 0x00000040,

        /// <summary>
        ///  Device uses integer multiples only for character scaling.
        /// </summary>
        TC_SA_INTEGER = 0x00000080,

        /// <summary>
        /// Device uses any multiples for exact character scaling.
        /// </summary>
        TC_SA_CONTIN = 0x00000100,

        /// <summary>
        /// Device can draw double-weight characters.
        /// </summary>
        TC_EA_DOUBLE = 0x00000200,

        /// <summary>
        /// Device can italicize.
        /// </summary>
        TC_IA_ABLE = 0x00000400,

        /// <summary>
        /// Device can underline.
        /// </summary>
        TC_UA_ABLE = 0x00000800,

        /// <summary>
        /// Device can draw strikeouts.
        /// </summary>
        TC_SO_ABLE = 0x00001000,

        /// <summary>
        /// Device can draw raster fonts.
        /// </summary>
        TC_RA_ABLE = 0x00002000,

        /// <summary>
        /// Device can draw vector fonts.
        /// </summary>
        TC_VA_ABLE = 0x00004000,

        /// <summary>
        /// Reserved; must be zero.
        /// </summary>
        TC_RESERVED = 0x00008000,

        /// <summary>
        /// Device cannot scroll using a bit-block transfer.
        /// Note that this meaning may be the opposite of what you expect.
        /// </summary>
        TC_SCROLLBLT = 0x00010000,
    }
}
