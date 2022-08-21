namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// HSHELL
    /// </summary>
    public enum HSHELL
    {
        /// <summary>
        /// HSHELL_WINDOWCREATED
        /// </summary>
        HSHELL_WINDOWCREATED = 1,

        /// <summary>
        /// HSHELL_WINDOWDESTROYED
        /// </summary>
        HSHELL_WINDOWDESTROYED = 2,

        /// <summary>
        /// HSHELL_ACTIVATESHELLWINDOW
        /// </summary>
        HSHELL_ACTIVATESHELLWINDOW = 3,

        /// <summary>
        /// HSHELL_WINDOWACTIVATED
        /// </summary>
        HSHELL_WINDOWACTIVATED = 4,

        /// <summary>
        /// HSHELL_GETMINRECT
        /// </summary>
        HSHELL_GETMINRECT = 5,

        /// <summary>
        /// HSHELL_REDRAW
        /// </summary>
        HSHELL_REDRAW = 6,

        /// <summary>
        /// HSHELL_TASKMAN
        /// </summary>
        HSHELL_TASKMAN = 7,

        /// <summary>
        /// HSHELL_LANGUAGE
        /// </summary>
        HSHELL_LANGUAGE = 8,

        /// <summary>
        /// HSHELL_SYSMENU
        /// </summary>
        HSHELL_SYSMENU = 9,

        /// <summary>
        /// HSHELL_ENDTASK
        /// </summary>
        HSHELL_ENDTASK = 10,

        /// <summary>
        /// HSHELL_ACCESSIBILITYSTATE
        /// </summary>
        HSHELL_ACCESSIBILITYSTATE = 11,

        /// <summary>
        /// HSHELL_APPCOMMAND
        /// </summary>
        HSHELL_APPCOMMAND = 12,

        /// <summary>
        /// HSHELL_WINDOWREPLACED
        /// </summary>
        HSHELL_WINDOWREPLACED = 13,

        /// <summary>
        /// HSHELL_WINDOWREPLACING
        /// </summary>
        HSHELL_WINDOWREPLACING = 14,

        /// <summary>
        /// HSHELL_MONITORCHANGED
        /// </summary>
        HSHELL_MONITORCHANGED = 16,

        /// <summary>
        /// HSHELL_HIGHBIT
        /// </summary>
        HSHELL_HIGHBIT = 0x8000,

        /// <summary>
        /// HSHELL_FLASH
        /// </summary>
        HSHELL_FLASH = (HSHELL_REDRAW | HSHELL_HIGHBIT),

        /// <summary>
        /// HSHELL_RUDEAPPACTIVATED
        /// </summary>
        HSHELL_RUDEAPPACTIVATED = (HSHELL_WINDOWACTIVATED | HSHELL_HIGHBIT),
    }
}
