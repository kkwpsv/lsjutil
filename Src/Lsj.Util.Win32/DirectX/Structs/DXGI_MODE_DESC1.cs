using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a display mode and whether the display mode supports stereo.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_mode_desc1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="DXGI_MODE_DESC1"/> is identical to <see cref="DXGI_MODE_DESC"/>
    /// except that <see cref="DXGI_MODE_DESC1"/> includes the <see cref="Stereo"/> member.
    /// This structure is used by the <see cref="IDXGIOutput1.GetDisplayModeList1"/> and <see cref="IDXGIOutput1.FindClosestMatchingMode1"/> methods.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_MODE_DESC1
    {
        /// <summary>
        /// A value that describes the resolution width.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// A value that describes the resolution height.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// A <see cref="DXGI_RATIONAL"/> structure describing the refresh rate in hertz.
        /// </summary>
        public DXGI_RATIONAL RefreshRate;

        /// <summary>
        /// A <see cref="DXGI_FORMAT"/> structure describing the display format.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// A member of the <see cref="DXGI_MODE_SCANLINE_ORDER"/> enumerated type describing the scanline drawing mode.
        /// </summary>
        public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;

        /// <summary>
        /// A member of the <see cref="DXGI_MODE_SCALING"/> enumerated type describing the scaling mode.
        /// </summary>
        public DXGI_MODE_SCALING Scaling;

        /// <summary>
        /// Specifies whether the full-screen display mode is stereo.
        /// <see cref="TRUE"/> if stereo; otherwise, <see cref="FALSE"/>.
        /// </summary>
        public BOOL Stereo;
    }
}
