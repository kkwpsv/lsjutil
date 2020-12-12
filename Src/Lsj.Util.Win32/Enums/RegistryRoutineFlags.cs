namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Registry Routine Flags
    /// </summary>
    public enum RegistryRoutineFlags : uint
    {
        /// <summary>
        /// RRF_RT_REG_NONE
        /// </summary>
        RRF_RT_REG_NONE = 0x00000001,

        /// <summary>
        /// RRF_RT_REG_SZ
        /// </summary>
        RRF_RT_REG_SZ = 0x00000002,

        /// <summary>
        /// RRF_RT_REG_EXPAND_SZ
        /// </summary>
        RRF_RT_REG_EXPAND_SZ = 0x00000004,

        /// <summary>
        /// RRF_RT_REG_BINARY
        /// </summary>
        RRF_RT_REG_BINARY = 0x00000008,

        /// <summary>
        /// RRF_RT_REG_DWORD
        /// </summary>
        RRF_RT_REG_DWORD = 0x00000010,

        /// <summary>
        /// RRF_RT_REG_MULTI_SZ
        /// </summary>
        RRF_RT_REG_MULTI_SZ = 0x00000020,

        /// <summary>
        /// RRF_RT_REG_QWORD
        /// </summary>
        RRF_RT_REG_QWORD = 0x00000040,

        /// <summary>
        /// RRF_RT_DWORD
        /// </summary>
        RRF_RT_DWORD = RRF_RT_REG_BINARY | RRF_RT_REG_DWORD,

        /// <summary>
        /// RRF_RT_QWORD
        /// </summary>
        RRF_RT_QWORD = RRF_RT_REG_BINARY | RRF_RT_REG_QWORD,

        /// <summary>
        /// RRF_RT_ANY
        /// </summary>
        RRF_RT_ANY = 0x0000ffff,

        /// <summary>
        /// RRF_SUBKEY_WOW6464KEY
        /// </summary>
        RRF_SUBKEY_WOW6464KEY = 0x00010000,

        /// <summary>
        /// RRF_SUBKEY_WOW6464KEY
        /// </summary>
        RRF_SUBKEY_WOW6432KEY = 0x00020000,

        /// <summary>
        /// RRF_WOW64_MASK
        /// </summary>
        RRF_WOW64_MASK = 0x00030000,

        /// <summary>
        /// RRF_NOEXPAND
        /// </summary>
        RRF_NOEXPAND = 0x10000000,

        /// <summary>
        /// RRF_ZEROONFAILURE
        /// </summary>
        RRF_ZEROONFAILURE = 0x20000000,
    }
}
