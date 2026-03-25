namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes whether a render target uses hardware or software rendering, or if Direct2D should select the rendering mode.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_render_target_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Not every render target supports hardware rendering. For more information, see the Render Targets Overview.
    /// </remarks>
    public enum D2D1_RENDER_TARGET_TYPE : uint
    {
        /// <summary>
        /// The render target uses hardware rendering, if available; otherwise, it uses software rendering.
        /// </summary>
        D2D1_RENDER_TARGET_TYPE_DEFAULT = 0,

        /// <summary>
        /// The render target uses software rendering only.
        /// </summary>
        D2D1_RENDER_TARGET_TYPE_SOFTWARE = 1,

        /// <summary>
        /// The render target uses hardware rendering only.
        /// </summary>
        D2D1_RENDER_TARGET_TYPE_HARDWARE = 2,

        /// <summary>
        /// 
        /// </summary>
        D2D1_RENDER_TARGET_TYPE_FORCE_DWORD = 0xffffffff
    }
}
