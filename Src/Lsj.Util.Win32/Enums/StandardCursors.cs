using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Windows provides a set of standard cursors that can be used by applications.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/menurc/about-cursors"/>
    /// </para>
    /// </summary>
    public enum StandardCursors
    {
        /// <summary>
        /// Normal select
        /// </summary>
        IDC_ARROW = 32512,

        /// <summary>
        /// Text select
        /// </summary>
        IDC_IBEAM = 32513,

        /// <summary>
        /// Busy
        /// </summary>
        IDC_WAIT = 32514,

        /// <summary>
        /// Precision select
        /// </summary>
        IDC_CROSS = 32515,

        /// <summary>
        /// Alternate select
        /// </summary>
        IDC_UPARROW = 32516,

        /// <summary>
        /// Diagonal resize 1
        /// </summary>
        IDC_SIZENWSE = 32642,

        /// <summary>
        /// Diagonal resize 2
        /// </summary>
        IDC_SIZENESW = 32643,

        /// <summary>
        /// Horizontal resize
        /// </summary>
        IDC_SIZEWE = 32644,

        /// <summary>
        /// Vertical resize
        /// </summary>
        IDC_SIZENS = 32645,

        /// <summary>
        /// Move
        /// </summary>
        IDC_SIZEALL = 32646,

        /// <summary>
        /// Unavailable
        /// </summary>
        IDC_NO = 32648,

        /// <summary>
        /// Link select
        /// </summary>
        IDC_HAND = 32649,

        /// <summary>
        /// Working in background
        /// </summary>
        IDC_APPSTARTING = 32650,

        /// <summary>
        /// Help select
        /// </summary>
        IDC_HELP = 32651,

        /// <summary>
        /// Location select
        /// </summary>
        IDC_PIN = 32671,

        /// <summary>
        /// Person select
        /// </summary>
        IDC_PERSON = 32672,

        /// <summary>
        /// IDC_ICON
        /// </summary>
        [Obsolete]
        IDC_ICON = 32641,

        /// <summary>
        /// IDC_SIZE
        /// </summary>
        [Obsolete]
        IDC_SIZE = 32640,
    }
}
