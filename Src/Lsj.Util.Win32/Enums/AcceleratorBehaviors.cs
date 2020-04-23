using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Accelerator Behaviors
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-accel
    /// </para>
    /// </summary>
    public enum AcceleratorBehaviors : byte
    {
        /// <summary>
        /// The ALT key must be held down when the accelerator key is pressed.
        /// </summary>
        FALT = 0x10,

        /// <summary>
        /// The CTRL key must be held down when the accelerator key is pressed.
        /// </summary>
        FCONTROL = 0x08,

        /// <summary>
        /// No top-level menu item is highlighted when the accelerator is used.
        /// If this flag is not specified, a top-level menu item will be highlighted, if possible, when the accelerator is used.
        /// This attribute is obsolete and retained only for backward compatibility with resource files designed for 16-bit Windows.
        /// </summary>
        FNOINVERT = 0x02,

        /// <summary>
        /// The SHIFT key must be held down when the accelerator key is pressed.
        /// </summary>
        FSHIFT = 0x04,

        /// <summary>
        /// The <see cref="ACCEL.key"/> member specifies a virtual-key code.
        /// If this flag is not specified, key is assumed to specify a character code.
        /// </summary>
        FVIRTKEY = 0x01,
    }
}
