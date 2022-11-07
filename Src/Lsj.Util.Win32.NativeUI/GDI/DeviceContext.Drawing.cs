using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    partial class DeviceContext
    {
        public Brush SelectBrush(Brush pen) => new Brush(SelectObject(Handle, pen.Handle), GdiObjectReleaseMode.None);

        public Pen SelectPen(Pen pen) => new Pen(SelectObject(Handle, pen.Handle), GdiObjectReleaseMode.None);
    }
}
