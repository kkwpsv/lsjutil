namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GetClassWord"/> and <see cref="GetClassLong"/> Indexes.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclassword
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclasslongw
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclasslongptrw
    /// </para>
    /// </summary>
    public enum GetClassIndexes
    {
        /// <summary>
        /// Retrieves an ATOM value that uniquely identifies the window class.
        /// This is the same atom that the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function returns.
        /// </summary>
        GCW_ATOM = -32,

        /// <summary>
        /// Retrieves the size, in bytes, of the extra memory associated with the class.
        /// </summary>
        GCL_CBCLSEXTRA = -20,

        /// <summary>
        /// Retrieves the size, in bytes, of the extra window memory associated with each window in the class.
        /// For information on how to access this memory, see <see cref="GetWindowLong"/>.
        /// </summary>
        GCL_CBWNDEXTRA = 18,

        /// <summary>
        /// Retrieves a handle to the background brush associated with the class.
        /// </summary>
        GCL_HBRBACKGROUND = -10,

        /// <summary>
        /// Retrieves a handle to the cursor associated with the class.
        /// </summary>
        GCL_HCURSOR = -12,

        /// <summary>
        /// Retrieves a handle to the icon associated with the class.
        /// </summary>
        GCL_HICON = -14,

        /// <summary>
        /// Retrieves a handle to the small icon associated with the class.
        /// </summary>
        GCL_HICONSM = -34,

        /// <summary>
        /// Retrieves a handle to the module that registered the class.
        /// </summary>
        GCL_HMODULE = -16,

        /// <summary>
        /// Retrieves the address of the menu name string. The string identifies the menu resource associated with the class.
        /// </summary>
        GCL_MENUNAME = -8,

        /// <summary>
        /// Retrieves the window-class style bits.
        /// </summary>
        GCL_STYLE = -26,

        /// <summary>
        /// Retrieves the address of the window procedure, or a handle representing the address of the window procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the window procedure.
        /// </summary>
        GCL_WNDPROC = -24,

        /// <summary>
        /// Retrieves a handle to the background brush associated with the class.
        /// </summary>
        GCLP_HBRBACKGROUND = -10,

        /// <summary>
        /// Retrieves a handle to the cursor associated with the class.
        /// </summary>
        GCLP_HCURSOR = -12,

        /// <summary>
        /// Retrieves a handle to the icon associated with the class.
        /// </summary>
        GCLP_HICON = -14,

        /// <summary>
        /// Retrieves a handle to the small icon associated with the class.
        /// </summary>
        GCLP_HICONSM = -34,

        /// <summary>
        /// Retrieves a handle to the module that registered the class.
        /// </summary>
        GCLP_HMODULE = -16,

        /// <summary>
        /// Retrieves the pointer to the menu name string.
        /// The string identifies the menu resource associated with the class.
        /// </summary>
        GCLP_MENUNAME = -8,

        /// <summary>
        /// Retrieves the address of the window procedure, or a handle representing the address of the window procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the window procedure.
        /// </summary>
        GCLP_WNDPROC = -24,
    }
}
