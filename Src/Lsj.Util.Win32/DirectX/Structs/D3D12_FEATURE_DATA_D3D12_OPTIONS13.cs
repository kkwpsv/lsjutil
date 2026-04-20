using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options13"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_FEATURE_DATA_D3D12_OPTIONS13
    {
        /// <summary>
        /// 
        /// </summary>
        public BOOL UnrestrictedBufferTextureCopyPitchSupported;

        /// <summary>
        /// 
        /// </summary>
        public BOOL UnrestrictedVertexElementAlignmentSupported;

        /// <summary>
        /// 
        /// </summary>
        public BOOL InvertedViewportHeightFlipsYSupported;

        /// <summary>
        /// 
        /// </summary>
        public BOOL InvertedViewportDepthFlipsZSupported;

        /// <summary>
        /// 
        /// </summary>
        public BOOL TextureCopyBetweenDimensionsSupported;

        /// <summary>
        /// 
        /// </summary>
        public BOOL AlphaBlendFactorSupported;
    }
}
