using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes Direct3D 11.3 feature options in the current graphics driver.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d11_options3"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_FEATURE_DATA_D3D11_OPTIONS3
    {
        /// <summary>
        /// Whether to use the VP and RT array index from any shader feeding the rasterizer.
        /// </summary>
        public BOOL VPAndRTArrayIndexFromAnyShaderFeedingRasterizer;
    }
}
