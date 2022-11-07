using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    /// <summary>
    /// Device context
    /// </summary>
    public partial class DeviceContext : GdiObject
    {
        /// <summary>
        /// Handle
        /// </summary>
        public HDC Handle { get; private set; }

        private readonly DeviceContextReleaseMode _deviceContextReleaseMode;
        private readonly HWND? _window;

        /// <summary>
        /// Device context
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="deviceContextReleaseMode"></param>
        /// <param name="window"></param>
        /// <exception cref="ArgumentException"></exception>
        public DeviceContext(HDC dc, DeviceContextReleaseMode deviceContextReleaseMode, HWND? window = null)
        {
            if (deviceContextReleaseMode == DeviceContextReleaseMode.ReleaseDC && window is null)
            {
                throw new ArgumentException($"{nameof(window)} cannot be null when ${nameof(deviceContextReleaseMode)} is ${nameof(DeviceContextReleaseMode.ReleaseDC)}");
            }
            Handle = dc;
            _deviceContextReleaseMode = deviceContextReleaseMode;
            _window = window;

            if (_deviceContextReleaseMode == DeviceContextReleaseMode.None)
            {
                GC.SuppressFinalize(this);
            }
        }

        public override GdiObjectType ObjectType => GdiObjectType.DeviceContext;

        protected override void OnReleaseObject()
        {
            if (_deviceContextReleaseMode == DeviceContextReleaseMode.DeleteDC)
            {
                DeleteDC(Handle);
            }
            else if (_deviceContextReleaseMode == DeviceContextReleaseMode.ReleaseDC)
            {
                ReleaseDC(_window!.Value, Handle);
            }
        }

        /// <summary>
        /// Driver version
        /// </summary>
        public int DriverVersion => GetDeviceCaps(Handle, DeviceCapIndexes.DRIVERVERSION);

        /// <summary>
        /// Device technologies
        /// </summary>
        public DeviceTechnologies Technologies => (DeviceTechnologies)GetDeviceCaps(Handle, DeviceCapIndexes.TECHNOLOGY);

        /// <summary>
        /// Physical width in millimeters
        /// </summary>
        public int PhysicalWidth => GetDeviceCaps(Handle, DeviceCapIndexes.HORZSIZE);

        /// <summary>
        /// Physical height in millimeters
        /// </summary>
        public int PhysicalHeight => GetDeviceCaps(Handle, DeviceCapIndexes.VERTSIZE);

        /// <summary>
        /// Width in pixels
        /// </summary>
        public int Width => GetDeviceCaps(Handle, DeviceCapIndexes.HORZRES);

        /// <summary>
        /// Height in pixels
        /// </summary>
        public int Height => GetDeviceCaps(Handle, DeviceCapIndexes.VERTRES);

        /// <summary>
        /// Dpi in width
        /// </summary>
        public int DpiX => GetDeviceCaps(Handle, DeviceCapIndexes.LOGPIXELSX);

        /// <summary>
        /// Dpi in height
        /// </summary>
        public int DpiY => GetDeviceCaps(Handle, DeviceCapIndexes.LOGPIXELSY);

        /// <summary>
        /// Color bits per pixel
        /// </summary>
        public int ColorBits => GetDeviceCaps(Handle, DeviceCapIndexes.BITSPIXEL);

        /// <summary>
        /// Vertical refresh rate
        /// </summary>
        public int RefreshRate => GetDeviceCaps(Handle, DeviceCapIndexes.VREFRESH);
    }

    /// <summary>
    /// DeviceContext Release Mode
    /// </summary>
    public enum DeviceContextReleaseMode
    {
        /// <summary>
        /// Not need
        /// </summary>
        None,

        /// <summary>
        /// Release by <see cref="Gdi32.DeleteDC(HDC)"/>
        /// </summary>
        DeleteDC,

        /// <summary>
        /// Release by <see cref="User32.ReleaseDC(HWND, HDC)"/>
        /// </summary>
        ReleaseDC,
    }
}
