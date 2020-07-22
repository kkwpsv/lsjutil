using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Graphics Modes
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setgraphicsmode
    /// </para>
    /// </summary>
    public enum GraphicsModes
    {
        /// <summary>
        /// Sets the graphics mode that is compatible with 16-bit Windows.
        /// This is the default mode.
        /// If this value is specified, the application can only modify the world-to-device transform
        /// by calling functions that set window and viewport extents and origins,
        /// but not by using <see cref="SetWorldTransform"/> or <see cref="ModifyWorldTransform"/>; calls to those functions will fail.
        /// Examples of functions that set window and viewport extents and origins are <see cref="SetViewportExtEx"/> and <see cref="SetWindowExtEx"/>.
        /// </summary>
        GM_COMPATIBLE = 1,

        /// <summary>
        /// Sets the advanced graphics mode that allows world transformations.
        /// This value must be specified if the application will set or modify the world transformation for the specified device context.
        /// In this mode all graphics, including text output, fully conform to the world-to-device transformation specified in the device context.
        /// </summary>
        GM_ADVANCED = 2,
    }

}
