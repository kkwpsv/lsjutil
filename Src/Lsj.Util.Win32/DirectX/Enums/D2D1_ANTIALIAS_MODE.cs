using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how the edges of nontext primitives are rendered.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_antialias_mode"/>
    /// </para>
    /// </summary>
    public enum D2D1_ANTIALIAS_MODE : uint
    {
        /// <summary>
        /// Edges are antialiased using the Direct2D per-primitive method of high-quality antialiasing.
        /// </summary>
        D2D1_ANTIALIAS_MODE_PER_PRIMITIVE = 0,

        /// <summary>
        /// Objects are aliased in most cases.
        /// Objects are antialiased only when they are drawn to a render target
        /// created by the <see cref="ID2D1Factory.CreateDxgiSurfaceRenderTarget"/> method
        /// and Direct3D multisampling has been enabled on the backing DirectX Graphics Infrastructure (DXGI) surface.
        /// </summary>
        D2D1_ANTIALIAS_MODE_ALIASED = 1,

        /// <summary>
        /// 
        /// </summary>
        D2D1_ANTIALIAS_MODE_FORCE_DWORD = 0xffffffff
    }
}
