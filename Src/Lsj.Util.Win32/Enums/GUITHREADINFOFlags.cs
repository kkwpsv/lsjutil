using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GUITHREADINFO"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-guithreadinfo"/>
    /// </para>
    /// </summary>
    public enum GUITHREADINFOFlags : uint
    {
        /// <summary>
        /// The caret's blink state. This bit is set if the caret is visible.
        /// </summary>
        GUI_CARETBLINKING = 0x00000001,

        /// <summary>
        /// The thread's menu state. This bit is set if the thread is in menu mode.
        /// </summary>
        GUI_INMOVESIZE = 0x00000002,

        /// <summary>
        /// The thread's move state. This bit is set if the thread is in a move or size loop.
        /// </summary>
        GUI_INMENUMODE = 0x00000004,

        /// <summary>
        /// The thread's pop-up menu state. This bit is set if the thread has an active pop-up menu.
        /// </summary>
        GUI_SYSTEMMENUMODE = 0x00000008,

        /// <summary>
        /// The thread's system menu state. This bit is set if the thread is in a system menu mode.
        /// </summary>
        GUI_POPUPMENUMODE = 0x00000010,
    }
}
