using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes which resources are supported by the current graphics driver for a given format.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_format_support"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Refer to Typed unordered access view loads for an example use of this structure.
    /// </para>
    /// <para>
    /// Also see <see cref="D3D12_FEATURE"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_FEATURE_DATA_FORMAT_SUPPORT
    {
        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value for the format to return info about.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// A combination of <see cref="D3D12_FORMAT_SUPPORT1"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies which resources are supported.
        /// </summary>
        public D3D12_FORMAT_SUPPORT1 Support1;

        /// <summary>
        /// A combination of <see cref="D3D12_FORMAT_SUPPORT2"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies which unordered resource options are supported.
        /// </summary>
        public D3D12_FORMAT_SUPPORT2 Support2;
    }
}
