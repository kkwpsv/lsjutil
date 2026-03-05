using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the visual feedback behaviors available to <see cref="CreateSyntheticPointerDevice"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-pointer_feedback_mode"/>
    /// </para>
    /// </summary>
    public enum POINTER_FEEDBACK_MODE
    {
        /// <summary>
        /// Visual feedback might be suppressed by the user's pen (Settings -> Devices -> Pen &amp; Windows Ink)
        /// and touch (Settings -> Ease of Access -> Cursor &amp; pointer size) settings.
        /// </summary>
        POINTER_FEEDBACK_DEFAULT = 1,

        /// <summary>
        /// Visual feedback overrides the user's pen and touch settings.
        /// </summary>
        POINTER_FEEDBACK_INDIRECT = 2,

        /// <summary>
        /// Visual feedback is disabled.
        /// </summary>
        POINTER_FEEDBACK_NONE = 3
    }
}
