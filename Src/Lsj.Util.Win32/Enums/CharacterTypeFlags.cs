namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Character Type Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-getstringtypew"/>
    /// </para>
    /// </summary>
    public enum CharacterTypeFlags : uint
    {
        /// <summary>
        /// Retrieve character type information.
        /// </summary>
        CT_CTYPE1 = 0x00000001,

        /// <summary>
        /// Retrieve bidirectional layout information.
        /// </summary>
        CT_CTYPE2 = 0x00000002,

        /// <summary>
        /// Retrieve text processing information.
        /// </summary>
        CT_CTYPE3 = 0x00000004,
    }
}
