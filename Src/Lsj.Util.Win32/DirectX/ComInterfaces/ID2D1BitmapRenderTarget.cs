using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Renders to an intermediate texture created by the <see cref="ID2D1RenderTarget.CreateCompatibleRenderTarget"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1bitmaprendertarget"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An <see cref="ID2D1BitmapRenderTarget"/> writes to an intermediate texture.
    /// It's useful for creating patterns for use with an <see cref="ID2D1BitmapBrush"/> or caching drawing data that will be used repeatedly.
    /// </para>
    /// <para>
    /// To write directly to a WIC bitmap instead, use the <see cref="ID2D1Factory.CreateWicBitmapRenderTarget"/> method.
    /// This method returns an <see cref="ID2D1RenderTarget"/> that writes to the specified WIC bitmap.
    /// </para>
    /// <para>
    /// Creating <see cref="ID2D1BitmapRenderTarget"/> Objects
    /// </para>
    /// <para>
    /// To create a bitmap render target, call the <see cref="ID2D1RenderTarget.CreateCompatibleRenderTarget"/> method.
    /// </para>
    /// <para>
    /// Like other render targets, an <see cref="ID2D1BitmapRenderTarget"/> is a device-dependent resource
    /// and must be recreated when the associated device becomes unavailable.
    /// For more information, see the Resources Overview.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd90695-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 57, EndVTableSlotIndex = 57,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1RenderTarget)])]
    public unsafe struct ID2D1BitmapRenderTarget
    {
        nint* _vTable;

        /// <summary>
        /// Retrieves the bitmap for this render target.
        /// The returned bitmap can be used for drawing operations.
        /// </summary>
        /// <param name="bitmap">
        /// When this method returns, contains the address of a pointer to the bitmap for this render target.
        /// This bitmap can be used for drawing operations.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The DPI for the <see cref="ID2D1Bitmap"/> obtained from <see cref="GetBitmap"/>
        /// will be the DPI of the <see cref="ID2D1BitmapRenderTarget"/> when the render target was created.
        /// Changing the DPI of the <see cref="ID2D1BitmapRenderTarget"/>
        /// by calling <see cref="ID2D1RenderTarget.SetDpi"/> doesn't affect the DPI of the bitmap,
        /// even if <see cref="ID2D1RenderTarget.SetDpi"/> is called before <see cref="GetBitmap"/>.
        /// Using <see cref="ID2D1RenderTarget.SetDpi"/> to change the DPI of the <see cref="ID2D1BitmapRenderTarget"/>
        /// does affect how contents are rendered into the bitmap: 
        /// it just doesn't affect the DPI of the bitmap retrieved by <see cref="GetBitmap"/>.
        /// </remarks>
        public HRESULT GetBitmap([Out] out P<ID2D1Bitmap> bitmap)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ID2D1Bitmap>, HRESULT>)_vTable[57])(thisPtr, out bitmap);
            }
        }
    }
}
