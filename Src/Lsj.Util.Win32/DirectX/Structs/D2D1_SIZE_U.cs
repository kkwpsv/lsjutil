using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Stores an ordered pair of integers, typically the width and height of a rectangle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/Direct2D/d2d1-size-u"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Like points, sizes are another important graphics concept.
    /// In Direct2D, sizes are represented by the <see cref="D2D1_SIZE_U"/> or <see cref="D2D1_SIZE_F"/> structures.
    /// They both contain an ordered pair of numbers.
    /// The <see cref="D2D1_SIZE_U"/> structure contains an ordered pair of <see cref="UINT32"/> values,
    /// and the <see cref="D2D1_SIZE_F"/> structure contains an ordered pair of <see cref="FLOAT"/> values.
    /// </para>
    /// <para>
    /// The <see cref="D2D1_SIZE_U"/> structure provides a convenient way for you
    /// to store an ordered pair of numbers, such as the width and height of a rectangle.
    /// </para>
    /// <para>
    /// <see cref="D2D1_SIZE_U"/> is a new name for an already defined type <see cref="D2D_SIZE_U"/>.
    /// You can use the <c>D2D1.SizeU</c> function to create a <see cref="D2D1_SIZE_U"/> structure.
    /// A common use for this structure is to specify the pixel size of a <see cref="D2D1_HWND_RENDER_TARGET_PROPERTIES"/> structure.
    /// The following provides an example of using this structure.
    /// </para>
    /// <code>
    /// if (!m_pRenderTarget)
    ///     {
    ///         RECT rc;
    ///         GetClientRect(m_hwnd, &amp;rc);
    /// 
    ///         D2D1_SIZE_U size = D2D1::SizeU(
    ///             rc.right - rc.left,
    ///             rc.bottom - rc.top
    ///             );
    /// 
    ///         // Create a Direct2D render target.
    ///         hr = m_pD2DFactory-&gt;CreateHwndRenderTarget(
    ///             D2D1::RenderTargetProperties(),
    ///             D2D1::HwndRenderTargetProperties(m_hwnd, size),
    ///             &amp;m_pRenderTarget
    ///             );
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_SIZE_U
    {
        /// <summary>
        /// The horizontal component of this size.
        /// </summary>
        public UINT32 width;

        /// <summary>
        /// The vertical component of this size.
        /// </summary>
        public UINT32 height;
    }
}
