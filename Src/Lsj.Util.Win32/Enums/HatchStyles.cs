namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Hatch Styles
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createhatchbrush
    /// </para>
    /// </summary>
    public enum HatchStyles
    {
        /// <summary>
        /// Horizontal hatch
        /// </summary>
        HS_HORIZONTAL = 0,

        /// <summary>
        /// Vertical hatch
        /// </summary>
        HS_VERTICAL = 1,

        /// <summary>
        /// 45-degree downward left-to-right hatch
        /// </summary>
        HS_FDIAGONAL = 2,

        /// <summary>
        /// 45-degree upward left-to-right hatch
        /// </summary>
        HS_BDIAGONAL = 3,

        /// <summary>
        /// Horizontal and vertical crosshatch
        /// </summary>
        HS_CROSS = 4,

        /// <summary>
        /// 45-degree crosshatch
        /// </summary>
        HS_DIAGCROSS = 5,
    }
}
