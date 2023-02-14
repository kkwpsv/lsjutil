using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GetWindowLong"/> Indexes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongw"/>
    /// </para>
    /// </summary>
    public enum GetWindowLongIndexes
    {
        /// <summary>
        /// Retrieves the extended window styles.
        /// </summary>
        GWL_EXSTYLE = -20,

        /// <summary>
        /// Retrieves a handle to the application instance.
        /// </summary>
        GWL_HINSTANCE = -6,

        /// <summary>
        /// Retrieves a handle to the parent window, if any.
        /// </summary>
        GWL_HWNDPARENT = -8,

        /// <summary>
        /// Retrieves the identifier of the window.
        /// </summary>
        GWL_ID = -12,

        /// <summary>
        /// Retrieves the window styles.
        /// </summary>
        GWL_STYLE = -16,

        /// <summary>
        /// Retrieves the user data associated with the window. This data is intended for use by the application that created the window.
        /// Its value is initially zero.
        /// </summary>
        GWL_USERDATA = -21,

        /// <summary>
        /// Retrieves the address of the window procedure, or a handle representing the address of the window procedure. 
        /// You must use the <see cref="CallWindowProc"/> function to call the window procedure.
        /// </summary>
        GWL_WNDPROC = -4,

        /// <summary>
        /// Retrieves the return value of a message processed in the dialog box procedure.
        /// </summary>
        DWL_MSGRESULT = 0,

        /// <summary>
        /// USE <see cref="DWLP_DLGPROC"/> FOR BOTH 32BIT AND 64BIT!
        /// Retrieves the address of the dialog box procedure, or a handle representing the address of the dialog box procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the dialog box procedure.
        /// </summary>
        DWL_DLGPROC = 4,

        /// <summary>
        /// USE <see cref="DWLP_USER"/> FOR BOTH 32BIT AND 64BIT!
        /// Retrieves extra information private to the application, such as handles or pointers.
        /// </summary>
        DWL_USER = 8,
    }
}
