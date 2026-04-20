using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> represents a virtual address in GPU memory.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d12/d3d12_gpu_virtual_address"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct D3D12_GPU_VIRTUAL_ADDRESS
    {
        [FieldOffset(0)]
        private ulong _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ulong(D3D12_GPU_VIRTUAL_ADDRESS val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator D3D12_GPU_VIRTUAL_ADDRESS(ulong val) => new D3D12_GPU_VIRTUAL_ADDRESS { _value = val };
    }
}
