using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_ALPHA_MODE;
using static Lsj.Util.Win32.DirectX.Enums.D2DERR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Issues drawing commands to a GDI device context.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1dcrendertarget"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Creating <see cref="ID2D1DCRenderTarget"/> Objects
    /// </para>
    /// <para>
    /// To create an <see cref="ID2D1DCRenderTarget"/>, use the <see cref="ID2D1Factory.CreateDCRenderTarget"/> method.
    /// </para>
    /// <para>
    /// Before you can render with the DC render target,
    /// you must use its <see cref="BindDC"/> method to associate it with a GDI DC.
    /// You do this each time you use a different DC, or the size of the area you want to draw to changes.
    /// </para>
    /// <para>
    /// To enable the DC render target to work with GDI, set its pixel format to <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>
    /// and its alpha mode to <see cref="D2D1_ALPHA_MODE_PREMULTIPLIED"/> or <see cref="D2D1_ALPHA_MODE_IGNORE"/>.
    /// </para>
    /// <para>
    /// Your application should create render targets once and hold onto them for the life of the application
    /// or until the render target's <see cref="ID2D1RenderTarget.EndDraw"/> method returns the <see cref="D2DERR_RECREATE_TARGET"/> error.
    /// When you receive this error, you need to recreate the render target (and any resources it created).
    /// </para>
    /// <para>
    /// ID2D1DCRenderTargets, GDI Transforms, and Right-to-Left Language Builds of Windows
    /// </para>
    /// <para>
    /// When you use an <see cref="ID2D1DCRenderTarget"/>, it renders Direct2D content to an internal bitmap,
    /// and then renders the bitmap to the DC with GDI.
    /// </para>
    /// <para>
    /// It's possible for GDI to apply a GDI transform (through the <see cref="SetWorldTransform"/> method)
    /// or other effect to the same DC used by the render target, in which case GDI transforms the bitmap produced by Direct2D.
    /// Using a GDI transform to transform the Direct2D content has the potential to degrade the visual quality of the output,
    /// because you're transforming a bitmap for which antialiasing and subpixel positioning have already been calculated.
    /// </para>
    /// <para>
    /// For example, suppose you use the render target to draw a scene that contains antialiased geometries and text.
    /// If you use a GDI transform to apply a scale transform to the DC and scale the scene so that it's 10 times larger,
    /// you'll see pixelization and jagged edges.
    /// (If, however, you applied a similar transform using Direct2D, the visual quality of the scene would not be degraded.)
    /// </para>
    /// <para>
    /// In some cases, it might not be obvious that GDI is performing additional processing
    /// that might degrade the quality of the Direct2D content.
    /// For example, on a right-to-left (RTL) build of Windows,
    /// content rendered by an <see cref="ID2D1DCRenderTarget"/> might be horizontally inverted
    /// when GDI copies it to its destination.
    /// Whether the content is actually inverted depends on the current settings of the DC.
    /// </para>
    /// <para>
    /// Depending on the type of content being rendered, you might want to prevent the inversion.
    /// If the Direct2D content includes ClearType text, this inversion will degrade the quality of the text.
    /// </para>
    /// <para>
    /// You can control RTL rendering behavior by using the <see cref="SetLayout"/> GDI function.
    /// To prevent the mirroring, call the <see cref="SetLayout"/> GDI function
    /// and specify <see cref="LAYOUT_BITMAPORIENTATIONPRESERVED"/> as the only value for the second parameter
    /// (do not combine it with <see cref="LAYOUT_RTL"/>), as shown in the following example:
    /// </para>
    /// <code>
    /// SetLayout(m_hwnd, LAYOUT_BITMAPORIENTATIONPRESERVED);
    /// </code>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "1c51bc64-de61-46fd-9899-63a5d8f03950", BeginVTableSlotIndex = 57, EndVTableSlotIndex = 57,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1RenderTarget)])]
    public unsafe struct ID2D1DCRenderTarget
    {
        nint* _vTable;

        /// <summary>
        /// Binds the render target to the device context to which it issues drawing commands.
        /// </summary>
        /// <param name="hDC">
        /// The device context to which the render target issues drawing commands.
        /// </param>
        /// <param name="pSubRect">
        /// The dimensions of the handle to a device context (HDC) to which the render target is bound.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Before you can render with the DC render target,
        /// you must use its <see cref="BindDC"/> method to associate it with a GDI DC.
        /// You do this each time you use a different DC, or the size of the area you want to draw to changes.
        /// </remarks>
        public HRESULT BindDC([In] HDC hDC, [In] in RECT pSubRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HDC, in RECT, HRESULT>)_vTable[57])(thisPtr, hDC, pSubRect);
            }
        }
    }
}
