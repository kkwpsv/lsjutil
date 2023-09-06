using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_COLOR_SPACE_TYPE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes an output or physical connection between the adapter (video card) and a device,
    /// including additional information about color capabilities and connection type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/ns-dxgi1_6-dxgi_output_desc1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="DXGI_OUTPUT_DESC1"/> structure is initialized by the <see cref="IDXGIOutput6.GetDesc1"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_OUTPUT_DESC1
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

        /// <summary>
        /// The number of bits per color channel for the active wire format of the display attached to this output.
        /// </summary>
        public UINT BitsPerColor;

        /// <summary>
        /// The current advanced color capabilities of the display attached to this output.
        /// Specifically, whether its capable of reproducing color and luminance values outside of the sRGB color space.
        /// A value of <see cref="DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P709"/> indicates that the display is limited to SDR/sRGB;
        /// A value of <see cref="DXGI_COLOR_SPACE_RGB_FULL_G2084_NONE_P2020"/> indicates that the display supports advanced color capabilities.
        /// For detailed luminance and color capabilities, see additional members of this struct.
        /// </summary>
        public DXGI_COLOR_SPACE_TYPE ColorSpace;

        /// <summary>
        /// The red color primary, in xy coordinates, of the display attached to this output.
        /// This value will usually come from the EDID of the corresponding display or sometimes from an override.
        /// </summary>
        public ByValFLOATArrayStructForSize2 RedPrimary;

        /// <summary>
        /// The green color primary, in xy coordinates, of the display attached to this output.
        /// This value will usually come from the EDID of the corresponding display or sometimes from an override.
        /// </summary>
        public ByValFLOATArrayStructForSize2 GreenPrimary;

        /// <summary>
        /// The blue color primary, in xy coordinates, of the display attached to this output.
        /// This value will usually come from the EDID of the corresponding display or sometimes from an override.
        /// </summary>
        public ByValFLOATArrayStructForSize2 BluePrimary;

        /// <summary>
        /// The blue color primary, in xy coordinates, of the display attached to this output.
        /// This value will usually come from the EDID of the corresponding display or sometimes from an override.
        /// </summary>
        public ByValFLOATArrayStructForSize2 WhitePoint;

        /// <summary>
        /// The minimum luminance, in nits, that the display attached to this output is capable of rendering.
        /// Content should not exceed this minimum value for optimal rendering.
        /// This value will usually come from the EDID of the corresponding display or sometimes from an override.
        /// </summary>
        public FLOAT MinLuminance;

        /// <summary>
        /// The maximum luminance, in nits, that the display attached to this output is capable of rendering;
        /// this value is likely only valid for a small area of the panel.
        /// Content should not exceed this minimum value for optimal rendering.
        /// This value will usually come from the EDID of the corresponding display or sometimes from an override.
        /// </summary>
        public FLOAT MaxLuminance;

        /// <summary>
        /// The maximum luminance, in nits, that the display attached to this output is capable of rendering;
        /// unlike <see cref="MaxLuminance"/>, this value is valid for a color that fills the entire area of the panel.
        /// Content should not exceed this value across the entire panel for optimal rendering.
        /// This value will usually come from the EDID of the corresponding display or sometimes from an override.
        /// </summary>
        public FLOAT MaxFullFrameLuminance;
    }
}
