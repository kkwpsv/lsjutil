using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Controls the settings of a gamma curve.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173061(v=vs.85)"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="DXGI_GAMMA_CONTROL"/> structure is used by the IDXGIOutput::SetGammaControl method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_GAMMA_CONTROL
    {
        /// <summary>
        /// A <see cref="DXGI_RGB"/> structure with scalar values that are applied to rgb values before being sent to the gamma look up table.
        /// </summary>
        public DXGI_RGB Scale;

        /// <summary>
        /// A <see cref="DXGI_RGB"/> structure with offset values that are applied to the rgb values before being sent to the gamma look up table.
        /// </summary>
        public DXGI_RGB Offset;

        /// <summary>
        /// An array of <see cref="DXGI_RGB"/> structures that control the points of a gamma curve.
        /// </summary>
        public ByValDXGI_RGBArrayStructForSize1025 GammaCurve;
    }
}
