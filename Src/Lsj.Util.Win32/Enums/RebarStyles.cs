using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Rebar Styles
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/rebar-control-styles"/>
    /// </para>
    /// </summary>
    public enum RebarStyles : uint
    {
        /// <summary>
        /// Version 4.71.
        /// The rebar control will automatically change the layout of the bands when the size or position of the control changes.
        /// An <see cref="RBN_AUTOSIZE"/> notification will be sent when this occurs.
        /// </summary>
        RBS_AUTOSIZE = 0x00002000,

        /// <summary>
        /// Version 4.71.
        /// The rebar control displays narrow lines to separate adjacent bands.
        /// </summary>
        RBS_BANDBORDERS = 0x00000400,

        /// <summary>
        /// Version 4.71.
        /// The rebar band will toggle its maximized or minimized state when the user double-clicks the band.
        /// Without this style, the maximized or minimized state is toggled when the user single-clicks on the band.
        /// </summary>
        RBS_DBLCLKTOGGLE = 0x00008000,

        /// <summary>
        /// Version 4.70.
        /// The rebar control always displays bands in the same order. You can move bands to different rows, but the band order is static.
        /// </summary>
        RBS_FIXEDORDER = 0x00000800,
    }
}
