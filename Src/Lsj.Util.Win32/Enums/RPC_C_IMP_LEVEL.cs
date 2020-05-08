namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// RPC_C_IMP_LEVEL
    /// </summary>
    public enum RPC_C_IMP_LEVEL : uint
    {
        /// <summary>
        /// RPC_C_IMP_LEVEL_DEFAULT
        /// </summary>
        RPC_C_IMP_LEVEL_DEFAULT = 0,

        /// <summary>
        /// RPC_C_IMP_LEVEL_ANONYMOUS
        /// </summary>
        RPC_C_IMP_LEVEL_ANONYMOUS = 1,

        /// <summary>
        /// RPC_C_IMP_LEVEL_IDENTIFY
        /// </summary>
        RPC_C_IMP_LEVEL_IDENTIFY = 2,

        /// <summary>
        /// RPC_C_IMP_LEVEL_IMPERSONATE
        /// </summary>
        RPC_C_IMP_LEVEL_IMPERSONATE = 3,

        /// <summary>
        /// RPC_C_IMP_LEVEL_DELEGATE
        /// </summary>
        RPC_C_IMP_LEVEL_DELEGATE = 4,
    }
}
