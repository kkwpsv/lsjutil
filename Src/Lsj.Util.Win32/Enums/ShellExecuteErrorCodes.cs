using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="ShellExecute"/> and <see cref="ShellExecuteEx"/> Error Codes
    /// </summary>
    public enum ShellExecuteErrorCodes
    {
        /// <summary>
        /// SE_ERR_FNF
        /// </summary>
        SE_ERR_FNF = 2,

        /// <summary>
        /// SE_ERR_PNF
        /// </summary>
        SE_ERR_PNF = 3,

        /// <summary>
        /// SE_ERR_ACCESSDENIED
        /// </summary>
        SE_ERR_ACCESSDENIED = 5,

        /// <summary>
        /// SE_ERR_OOM
        /// </summary>
        SE_ERR_OOM = 8,

        /// <summary>
        /// SE_ERR_DLLNOTFOUND
        /// </summary>
        SE_ERR_DLLNOTFOUND = 32,

        /// <summary>
        /// SE_ERR_SHARE
        /// </summary>
        SE_ERR_SHARE = 26,

        /// <summary>
        /// SE_ERR_ASSOCINCOMPLETE
        /// </summary>
        SE_ERR_ASSOCINCOMPLETE = 27,

        /// <summary>
        /// SE_ERR_DDETIMEOUT
        /// </summary>
        SE_ERR_DDETIMEOUT = 28,

        /// <summary>
        /// SE_ERR_DDEFAIL
        /// </summary>
        SE_ERR_DDEFAIL = 29,

        /// <summary>
        /// SE_ERR_DDEBUSY
        /// </summary>
        SE_ERR_DDEBUSY = 30,

        /// <summary>
        /// SE_ERR_NOASSOC
        /// </summary>
        SE_ERR_NOASSOC = 31,
    }
}
