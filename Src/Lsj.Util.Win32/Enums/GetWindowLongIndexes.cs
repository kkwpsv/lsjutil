using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetWindowLong"/> indexes
    /// </summary>
    public enum GetWindowLongIndexes
    {
        /// <summary>
        /// DWL_MSGRESULT
        /// </summary>
        DWL_MSGRESULT = 0,

        /// <summary>
        /// DWL_DLGPROC
        /// </summary>
        DWL_DLGPROC = 4,

        /// <summary>
        /// DWL_USER
        /// </summary>
        DWL_USER = 8,

        /// <summary>
        /// GWL_EXSTYLE
        /// </summary>
        GWL_EXSTYLE = -20,

        /// <summary>
        /// GWL_HINSTANCE
        /// </summary>
        GWL_HINSTANCE = -6,

        /// <summary>
        /// GWL_HWNDPARENT
        /// </summary>
        GWL_HWNDPARENT = -8,

        /// <summary>
        /// GWL_ID
        /// </summary>
        GWL_ID = -12,

        /// <summary>
        /// GWL_STYLE
        /// </summary>
        GWL_STYLE = -16,

        /// <summary>
        /// GWL_USERDATA
        /// </summary>
        GWL_USERDATA = -21,

        /// <summary>
        /// GWL_WNDPROC
        /// </summary>
        GWL_WNDPROC = -4,
    }
}
