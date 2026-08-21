using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D2DERR;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Renders drawing instructions to a window.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1hwndrendertarget"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// As is the case with other render targets, you must call <see cref="ID2D1RenderTarget.BeginDraw"/> before issuing drawing commands.
    /// After you've finished drawing, call <see cref="ID2D1RenderTarget.EndDraw"/> to indicate
    /// that drawing is finished and to release access to the buffer backing the render target.
    /// </para>
    /// <para>
    /// For <see cref="ID2D1HwndRenderTarget"/>, the only side effect of <see cref="ID2D1RenderTarget.BeginDraw"/>
    /// is changing the state of the render target to allow drawing commands to be issued.
    /// </para>
    /// <para>
    /// <see cref="ID2D1RenderTarget.EndDraw"/> flushes any batched drawing commands.
    /// If no errors have occurred, then it also presents the buffer, causing it to appear on the associated window.
    /// Finally, <see cref="ID2D1RenderTarget.EndDraw"/> returns the <see cref="HRESULT"/> of the first error that occurred in drawing or presenting,
    /// as well as the tag state at the time the error occurred.
    /// </para>
    /// <para>
    /// <see cref="ID2D1HwndRenderTarget"/> objects are double buffered, so drawing commands issued do not appear immediately,
    /// but rather are performed on an offscreen surface.
    /// When <see cref="ID2D1RenderTarget.EndDraw"/> is called, if there have been no rendering errors, the offscreen buffer is presented.
    /// If there have been rendering errors in the batch flushed by <see cref="ID2D1RenderTarget.EndDraw"/>,
    /// then the buffer is not presented, and the application must call <see cref="ID2D1RenderTarget.BeginDraw"/> and re-draw the frame.
    /// <see cref="ID2D1RenderTarget.Flush"/> can be used to check for errors before calling <see cref="ID2D1RenderTarget.EndDraw"/>
    /// if an application wants the frame to be presented regardless of errors.
    /// </para>
    /// <para>
    /// A hardware render target's back-buffer is the size specified by <see cref="ID2D1RenderTarget.GetPixelSize"/>.
    /// If <see cref="ID2D1RenderTarget.EndDraw"/> presents the buffer,
    /// this bitmap is stretched to cover the surface where it is presented:
    /// the entire client area of the window.
    /// This stretch is performed using bilinear filtering if the render target is rendering in hardware
    /// and using nearest-neighbor filtering if the rendering target is using software.
    /// (Typically, an application will call <see cref="Resize"/> to ensure the pixel size of the render target
    /// and the pixel size of the destination match, and no scaling is necessary, though this is not a requirement.)
    /// </para>
    /// <para>
    /// In the case where a window straddles adapters,
    /// Direct2D ensures that the portion of the off-screen render target is copied from the adapter
    /// where rendering is occurring to the adapter that needs to display the contents.
    /// </para>
    /// <para>
    /// If the adapter a render target is on has been removed or the driver upgraded while the application is running,
    /// this is returned as an error in the <see cref="ID2D1RenderTarget.EndDraw"/> call.
    /// In this case, the application should create a new render target and resources as necessary.
    /// </para>
    /// <para>
    /// Creating <see cref="ID2D1HwndRenderTarget"/> Objects
    /// </para>
    /// <para>
    /// To create an <see cref="ID2D1HwndRenderTarget"/>, use the <see cref="ID2D1Factory.CreateHwndRenderTarget"/> method.
    /// </para>
    /// <para>
    /// Your application should create render targets once and hold onto them for the life of the application
    /// or until the render target's <see cref="ID2D1RenderTarget.EndDraw"/> method returns the <see cref="D2DERR_RECREATE_TARGET"/> error.
    /// When you receive this error, you need to recreate the render target (and any resources it created).
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd90694-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 57, EndVTableSlotIndex = 59,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1RenderTarget)])]
    public unsafe struct ID2D1HwndRenderTarget
    {
        nint* _vTable;
    }
}
