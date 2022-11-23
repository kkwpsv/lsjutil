using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    partial class DeviceContext
    {
        /// <summary>
        /// Select brush
        /// </summary>
        /// <param name="pen"></param>
        /// <returns></returns>
        public Brush SelectBrush(Brush pen) => new Brush(SelectObject(Handle, pen.Handle), GdiObjectReleaseMode.None);

        /// <summary>
        /// Select pen
        /// </summary>
        /// <param name="pen"></param>
        /// <returns></returns>
        public Pen SelectPen(Pen pen) => new Pen(SelectObject(Handle, pen.Handle), GdiObjectReleaseMode.None);

        /// <summary>
        /// Drawing rectangle with current pen and current brush.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <exception cref="GDIOperationFailedException"></exception>
        public void DrawingRectangle(int left, int top, int right, int bottom)
        {
            if (!Rectangle(Handle, left, top, right, bottom))
            {
                throw new GDIOperationFailedException(nameof(Rectangle));
            }
        }
    }
}
