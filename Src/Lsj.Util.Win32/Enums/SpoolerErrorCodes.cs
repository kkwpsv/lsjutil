namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Spooler Error Codes
    /// </summary>
    public enum SpoolerErrorCodes
    {
        /// <summary>
        /// SP_NOTREPORTED
        /// </summary>
        SP_NOTREPORTED = 0x4000,

        /// <summary>
        /// SP_ERROR
        /// </summary>
        SP_ERROR = -1,

        /// <summary>
        /// SP_APPABORT
        /// </summary>
        SP_APPABORT = -2,

        /// <summary>
        /// SP_USERABORT
        /// </summary>
        SP_USERABORT = -3,

        /// <summary>
        /// SP_OUTOFDISK
        /// </summary>
        SP_OUTOFDISK = -4,

        /// <summary>
        /// SP_OUTOFMEMORY
        /// </summary>
        SP_OUTOFMEMORY = -5,
    }
}
