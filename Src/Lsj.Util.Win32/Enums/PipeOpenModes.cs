namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Pipe open modes
    /// </summary>
    public enum PipeOpenModes : uint
    {
        /// <summary>
        /// PIPE_ACCESS_INBOUND
        /// </summary>
        PIPE_ACCESS_INBOUND = 0x00000001,

        /// <summary>
        /// PIPE_ACCESS_OUTBOUND
        /// </summary>
        PIPE_ACCESS_OUTBOUND = 0x00000002,

        /// <summary>
        /// PIPE_ACCESS_DUPLEX
        /// </summary>
        PIPE_ACCESS_DUPLEX = 0x00000003,
    }

}
