using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes shader data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_shader_bytecode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> and <see cref="D3D12_COMPUTE_PIPELINE_STATE_DESC"/> objects
    /// contain <see cref="D3D12_SHADER_BYTECODE"/> structures that describe various shader types.
    /// </para>
    /// <para>
    /// When loading a shader from FXC/DXC, this may be the entire compiled blob as is loaded from disk.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_SHADER_BYTECODE
    {
        /// <summary>
        /// A pointer to a memory block that contains the shader data.
        /// </summary>
        public IntPtr pShaderBytecode;

        /// <summary>
        /// The size, in bytes, of the shader data that the <see cref="pShaderBytecode"/> member points to.
        /// </summary>
        public SIZE_T BytecodeLength;
    }
}
