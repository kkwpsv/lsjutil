using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// GUI thread states
    /// </summary>
    [Flags]
    public enum GUIThreadStates : uint
    {
        /// <summary>
        /// GUI_CARETBLINKING
        /// </summary>
        GUI_CARETBLINKING = 0x00000001,

        /// <summary>
        /// GUI_INMOVESIZE
        /// </summary>
        GUI_INMOVESIZE = 0x00000002,

        /// <summary>
        /// GUI_INMENUMODE
        /// </summary>
        GUI_INMENUMODE = 0x00000004,

        /// <summary>
        /// GUI_SYSTEMMENUMODE
        /// </summary>
        GUI_SYSTEMMENUMODE = 0x00000008,

        /// <summary>
        /// GUI_POPUPMENUMODE
        /// </summary>
        GUI_POPUPMENUMODE = 0x00000010,
    }
}
