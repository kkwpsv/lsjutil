using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_RENDER_TARGET_USAGE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies additional features supportable by a compatible render target when it is created.
    /// This enumeration allows a bitwise combination of its member values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_compatible_render_target_options"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this enumeration when creating a compatible render target with the <see cref="ID2D1RenderTarget.CreateCompatibleRenderTarget"/> method.
    /// For more information about compatible render targets, see the Render Targets Overview.
    /// </para>
    /// <para>
    /// The <see cref="D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_GDI_COMPATIBLE"/> option may only be requested
    /// if the parent render target was created with <see cref="D2D1_RENDER_TARGET_USAGE_GDI_COMPATIBLE"/> (for most render targets)
    /// or <see cref="D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_GDI_COMPATIBLE"/>
    /// (for render targets created by the <see cref="ID2D1RenderTarget.CreateCompatibleRenderTarget"/> method).
    /// </para>
    /// </remarks>
    public enum D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS : uint
    {
        /// <summary>
        /// The render target supports no additional features.
        /// </summary>
        D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_NONE = 0x00000000,

        /// <summary>
        /// The render target supports interoperability with the Windows Graphics Device Interface (GDI).
        /// </summary>
        D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_GDI_COMPATIBLE = 0x00000001,

        /// <summary>
        /// 
        /// </summary>
        D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_FORCE_DWORD = 0xffffffff
    }
}
