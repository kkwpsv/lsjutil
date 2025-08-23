using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes multi-sampling parameters for a resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is a member of the <see cref="DXGI_SWAP_CHAIN_DESC1"/> structure.
    /// </para>
    /// <para>
    /// The default sampler mode, with no anti-aliasing, has a count of 1 and a quality level of 0.
    /// </para>
    /// <para>
    /// If multi-sample antialiasing is being used,
    /// all bound render targets and depth buffers must have the same sample counts and quality levels.
    /// </para>
    /// <para>
    /// Differences between Direct3D 10.0 and Direct3D 10.1 and between Direct3D 10.0 and Direct3D 11:
    /// </para>
    /// <para>
    /// Direct3D 10.1 has defined two standard quality levels:
    /// </para>
    /// <para>
    /// <see cref="D3D10_STANDARD_MULTISAMPLE_PATTERN"/> and <see cref="D3D10_CENTER_MULTISAMPLE_PATTERN"/>
    /// in the <see cref="D3D10_STANDARD_MULTISAMPLE_QUALITY_LEVELS"/> enumeration in D3D10_1.h.
    /// </para>
    /// <para>
    /// Direct3D 11 has defined two standard quality levels:
    /// </para>
    /// <para>
    /// <see cref="D3D11_STANDARD_MULTISAMPLE_PATTERN"/> and <see cref="D3D11_CENTER_MULTISAMPLE_PATTERN"/>
    /// in the <see cref="D3D11_STANDARD_MULTISAMPLE_QUALITY_LEVELS"/> enumeration in D3D11.h.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_SAMPLE_DESC
    {
        /// <summary>
        /// The number of multisamples per pixel.
        /// </summary>
        public UINT Count;

        /// <summary>
        /// <para>
        /// The image quality level.
        /// The higher the quality, the lower the performance.
        /// The valid range is between zero and one less than the level
        /// returned by <see cref="ID3D10Device.CheckMultisampleQualityLevels"/> for Direct3D 10
        /// or <see cref="ID3D11Device.CheckMultisampleQualityLevels"/> for Direct3D 11.
        /// </para>
        /// <para>
        /// For Direct3D 10.1 and Direct3D 11, you can use two special quality level values.
        /// For more information about these quality level values, see Remarks.
        /// </para>
        /// </summary>
        public UINT Quality;
    }
}
