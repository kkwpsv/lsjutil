using static Lsj.Util.Win32.Enums.WindowsMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Browse For Folder Messages
    /// </summary>
    public enum BrowseForFolderMessages : uint
    {
        /// <summary>
        /// BFFM_SELCHANGED
        /// </summary>
        BFFM_INITIALIZED = 1,

        /// <summary>
        /// BFFM_SELCHANGED
        /// </summary>
        BFFM_SELCHANGED = 2,

        /// <summary>
        /// BFFM_VALIDATEFAILEDA
        /// </summary>
        BFFM_VALIDATEFAILEDA = 3,

        /// <summary>
        /// BFFM_VALIDATEFAILED
        /// </summary>
        BFFM_VALIDATEFAILED = 4,

        /// <summary>
        /// BFFM_IUNKNOWN
        /// </summary>
        BFFM_IUNKNOWN = 5,

        /// <summary>
        /// BFFM_SETSTATUSTEXTA
        /// </summary>
        BFFM_SETSTATUSTEXTA = (WM_USER + 100),

        /// <summary>
        /// BFFM_ENABLEOK
        /// </summary>
        BFFM_ENABLEOK = (WM_USER + 101),

        /// <summary>
        /// BFFM_SETSELECTIONA
        /// </summary>
        BFFM_SETSELECTIONA = (WM_USER + 102),

        /// <summary>
        /// BFFM_SETSELECTION
        /// </summary>
        BFFM_SETSELECTION = (WM_USER + 103),

        /// <summary>
        /// BFFM_SETSTATUSTEXT
        /// </summary>
        BFFM_SETSTATUSTEXT = (WM_USER + 104),

        /// <summary>
        /// BFFM_SETOKTEXT
        /// </summary>
        BFFM_SETOKTEXT = (WM_USER + 105),

        /// <summary>
        /// BFFM_SETEXPANDED
        /// </summary>
        BFFM_SETEXPANDED = (WM_USER + 106),
    }
}
