namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes how a render target is remoted and whether it should be GDI-compatible.
    /// This enumeration allows a bitwise combination of its member values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_render_target_usage"/>
    /// </para>
    /// </summary>
    public enum D2D1_RENDER_TARGET_USAGE : uint
    {
        /// <summary>
        /// The render target attempts to use Direct3D command-stream remoting and uses bitmap remoting if stream remoting fails.
        /// The render target is not GDI-compatible.
        /// </summary>
        D2D1_RENDER_TARGET_USAGE_NONE = 0x00000000,

        /// <summary>
        /// The render target renders content locally and sends it to the terminal services client as a bitmap.
        /// </summary>
        D2D1_RENDER_TARGET_USAGE_FORCE_BITMAP_REMOTING = 0x00000001,

        /// <summary>
        /// The render target can be used efficiently with GDI.
        /// </summary>
        D2D1_RENDER_TARGET_USAGE_GDI_COMPATIBLE = 0x00000002,

        /// <summary>
        /// 
        /// </summary>
        D2D1_RENDER_TARGET_USAGE_FORCE_DWORD = 0xffffffff
    }
}
