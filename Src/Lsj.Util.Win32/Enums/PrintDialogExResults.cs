using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="PrintDlgEx"/> results
    /// </summary>
    public enum PrintDialogExResults
    {
        /// <summary>
        /// PD_RESULT_CANCEL
        /// </summary>
        PD_RESULT_CANCEL = 0,

        /// <summary>
        /// PD_RESULT_PRINT
        /// </summary>
        PD_RESULT_PRINT = 1,

        /// <summary>
        /// PD_RESULT_APPLY
        /// </summary>
        PD_RESULT_APPLY = 2,
    }
}
