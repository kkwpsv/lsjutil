using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Values that can appear in the <see cref="POINTER_TOUCH_INFO.touchFlags"/> field of the <see cref="POINTER_TOUCH_INFO"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/touch-flags-constants"/>
    /// </para>
    /// </summary>
    public enum TOUCH_FLAGS
    {
        /// <summary>
        /// The default value.
        /// </summary>
        TOUCH_FLAG_NONE = 0x00000000,
    }
}
