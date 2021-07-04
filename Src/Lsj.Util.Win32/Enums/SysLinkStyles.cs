using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The following style constants are used when creating SysLink controls.
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/syslink-control-styles"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum SysLinkStyles : uint
    {
        /// <summary>
        /// The background mix mode is transparent.
        /// </summary>
        LWS_TRANSPARENT = 0x0001,

        /// <summary>
        /// When the link has keyboard focus and the user presses Enter, the keystroke is ignored by the control and passed to the host dialog box.
        /// </summary>
        LWS_IGNORERETURN =   0x0002,

        /// <summary>
        /// Windows Vista.
        /// If the text contains an ampersand, it is treated as a literal character rather than the prefix to a shortcut key.
        /// </summary>
        LWS_NOPREFIX =   0x0004,

        /// <summary>
        /// Windows Vista.
        /// The link is displayed in the current visual style.
        /// </summary>
        LWS_USEVISUALSTYLE =  0x0008,

        /// <summary>
        /// Windows Vista.
        /// An <see cref="NM_CUSTOMTEXT"/> notification is sent when the control is drawn, so that the application can supply text dynamically.
        /// </summary>
        LWS_USECUSTOMTEXT = 0x0010,

        /// <summary>
        /// Windows Vista. The text is right-justified.
        /// </summary>
        LWS_RIGHT = 0x0020,
    }
}
