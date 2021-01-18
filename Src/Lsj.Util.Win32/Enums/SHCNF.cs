namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// SHCNF
    /// </summary>
    public enum SHCNF : uint
    {
        /// <summary>
        /// SHCNF_IDLIST
        /// </summary>
        SHCNF_IDLIST = 0x0000,

        /// <summary>
        /// SHCNF_PATHA
        /// </summary>
        SHCNF_PATHA = 0x0001,

        /// <summary>
        /// SHCNF_PRINTERA
        /// </summary>
        SHCNF_PRINTERA = 0x0002,

        /// <summary>
        /// SHCNF_DWORD
        /// </summary>
        SHCNF_DWORD = 0x0003,

        /// <summary>
        /// SHCNF_PATH
        /// </summary>
        SHCNF_PATH = 0x0005,

        /// <summary>
        /// SHCNF_PRINTER
        /// </summary>
        SHCNF_PRINTER = 0x0006,

        /// <summary>
        /// SHCNF_TYPE
        /// </summary>
        SHCNF_TYPE = 0x00FF,

        /// <summary>
        /// SHCNF_FLUSH
        /// </summary>
        SHCNF_FLUSH = 0x1000,

        /// <summary>
        /// SHCNF_FLUSHNOWAIT
        /// </summary>
        SHCNF_FLUSHNOWAIT = 0x3000,

        /// <summary>
        /// SHCNF_NOTIFYRECURSIVE
        /// </summary>
        SHCNF_NOTIFYRECURSIVE = 0x10000,
    }
}
