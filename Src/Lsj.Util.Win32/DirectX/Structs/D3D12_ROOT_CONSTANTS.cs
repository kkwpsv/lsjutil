using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_ROOT_PARAMETER_TYPE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes constants inline in the root signature that appear in shaders as one constant buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_constants"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Refer to Resource Binding in HLSL for more information on shader registers and spaces.
    /// </para>
    /// <para>
    /// <see cref="D3D12_ROOT_CONSTANTS"/> is the data type
    /// of the <see cref="D3D12_ROOT_PARAMETER.Constants"/> member of <see cref="D3D12_ROOT_PARAMETER"/>.
    /// Use a <see cref="D3D12_ROOT_CONSTANTS"/> when you set <see cref="D3D12_ROOT_PARAMETER"/>'s
    /// <see cref="D3D12_ROOT_PARAMETER.ParameterType"/> field
    /// to the <see cref="D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS"/> member of <see cref="D3D12_ROOT_PARAMETER_TYPE"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_ROOT_CONSTANTS
    {
        /// <summary>
        /// The shader register.
        /// </summary>
        public UINT ShaderRegister;

        /// <summary>
        /// The register space.
        /// </summary>
        public UINT RegisterSpace;

        /// <summary>
        /// The number of constants that occupy a single shader slot (these constants appear like a single constant buffer).
        /// All constants occupy a single root signature bind slot.
        /// </summary>
        public UINT Num32BitValues;
    }
}
