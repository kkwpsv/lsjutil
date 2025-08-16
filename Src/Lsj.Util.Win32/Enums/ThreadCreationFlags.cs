namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Thread creation flags
    /// </summary>
    public enum ThreadCreationFlags : uint
    {
        /// <summary>
        /// CREATE_SUSPENDED
        /// </summary>
        CREATE_SUSPENDED = 0x00000004,

        /// <summary>
        /// STACK_SIZE_PARAM_IS_A_RESERVATION
        /// </summary>
        STACK_SIZE_PARAM_IS_A_RESERVATION = 0x00010000,
    }
}
