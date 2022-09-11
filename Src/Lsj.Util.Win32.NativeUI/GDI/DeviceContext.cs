using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    /// <summary>
    /// Device context
    /// </summary>
    public class DeviceContext
    {
        /// <summary>
        /// Handle
        /// </summary>
        public HDC Handle { get; private set; }

        /// <summary>
        /// Device context
        /// </summary>
        /// <param name="dc"></param>
        public DeviceContext(HDC dc)
        {
            Handle = dc;
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
}
