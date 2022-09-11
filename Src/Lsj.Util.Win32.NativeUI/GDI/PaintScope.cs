using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.ComponentModel;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    /// <summary>
    /// Paint Scope
    /// </summary>
    public class PaintScope : IDisposable
    {
        private HWND _hwnd;
        private PAINTSTRUCT _paintStruct;

        /// <summary>
        /// Device Context
        /// </summary>
        public DeviceContext DeviceContext { get; private set; }

        private PaintScope(HWND hwnd, PAINTSTRUCT paintStruct, HDC hdc)
        {
            _hwnd = hwnd;
            _paintStruct = paintStruct;
            DeviceContext = new DeviceContext(hdc);
        }

        /// <summary>
        /// EndPaint
        /// </summary>
        public void Dispose()
        {
            User32.EndPaint(_hwnd, _paintStruct);
        }

        /// <summary>
        /// Begin
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        /// <exception cref="Win32Exception"></exception>
        public static PaintScope Begin(HWND hwnd)
        {
            var hdc = User32.BeginPaint(hwnd, out var paintStruct);
            if (hdc != IntPtr.Zero)
            {
                return new PaintScope(hwnd, paintStruct, hdc);
            }
            else
            {
                throw new Win32Exception();
            }
        }
    }
}
