using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes an output or physical connection between the adapter (video card) and a device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_output_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="DXGI_OUTPUT_DESC"/> structure is initialized by the <see cref="IDXGIOutput.GetDesc"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_OUTPUT_DESC
    {
        /// <summary>
        /// A string that contains the name of the output device.
        /// </summary>
        public ByValStringStructForSize32 DeviceName;

        /// <summary>
        /// A RECT structure containing the bounds of the output in desktop coordinates.
        /// Desktop coordinates depend on the dots per inch (DPI) of the desktop.
        /// For info about writing DPI-aware Win32 apps, see High DPI.
        /// </summary>
        public RECT DesktopCoordinates;

        /// <summary>
        /// True if the output is attached to the desktop; otherwise, false.
        /// </summary>
        public BOOL AttachedToDesktop;

        /// <summary>
        /// A member of the <see cref="DXGI_MODE_ROTATION"/> enumerated type describing on how an image is rotated by the output.
        /// </summary>
        public DXGI_MODE_ROTATION Rotation;

        /// <summary>
        /// An <see cref="HMONITOR"/> handle that represents the display monitor.
        /// For more information, see HMONITOR and the Device Context.
        /// </summary>
        public HMONITOR Monitor;
    }
}
