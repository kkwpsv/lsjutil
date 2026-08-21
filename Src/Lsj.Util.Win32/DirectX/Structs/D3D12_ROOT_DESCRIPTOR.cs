using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_ROOT_PARAMETER_TYPE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes descriptors inline in the root signature version 1.0 that appear in shaders.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_descriptor"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="D3D12_ROOT_DESCRIPTOR"/> is the data type
    /// of the <see cref="D3D12_ROOT_PARAMETER.Descriptor"/> member of <see cref="D3D12_ROOT_PARAMETER"/>.
    /// Use a <see cref="D3D12_ROOT_DESCRIPTOR"/> when you set <see cref="D3D12_ROOT_PARAMETER"/>'s
    /// <see cref="D3D12_ROOT_PARAMETER.ParameterType"/> field to the <see cref="D3D12_ROOT_PARAMETER_TYPE_CBV"/>,
    /// <see cref="D3D12_ROOT_PARAMETER_TYPE_SRV"/>, or <see cref="D3D12_ROOT_PARAMETER_TYPE_UAV"/> members
    /// of <see cref="D3D12_ROOT_PARAMETER_TYPE"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_ROOT_DESCRIPTOR
    {
        /// <summary>
        /// The shader register.
        /// </summary>
        public UINT ShaderRegister;

        /// <summary>
        /// The register space.
        /// </summary>
        public UINT RegisterSpace;
    }
}
