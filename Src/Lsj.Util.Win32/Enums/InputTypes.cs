using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Input Types
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-input
    /// </para>
    /// </summary>
    public enum InputTypes : uint
    {
        /// <summary>
        /// The event is a mouse event. Use the <see cref="INPUT.mi"/> structure of the union.
        /// </summary>
        INPUT_MOUSE = 0,

        /// <summary>
        /// The event is a keyboard event. Use the <see cref="INPUT.ki"/> structure of the union.
        /// </summary>
        INPUT_KEYBOARD = 1,

        /// <summary>
        /// The event is a hardware event. Use the <see cref="INPUT.hi"/> structure of the union.
        /// </summary>
        INPUT_HARDWARE = 2,
    }
}
