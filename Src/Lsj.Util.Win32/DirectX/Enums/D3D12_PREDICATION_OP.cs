using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the predication operation to apply.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_predication_op"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by <see cref="ID3D12GraphicsCommandList.SetPredication"/>.
    /// </para>
    /// <para>
    /// Predication is decoupled from queries.
    /// Predication can be set based on the value of 64-bits within a buffer.
    /// </para>
    /// </remarks>
    public enum D3D12_PREDICATION_OP
    {
        /// <summary>
        /// Enables predication if all 64-bits are zero.
        /// </summary>
        D3D12_PREDICATION_OP_EQUAL_ZERO = 0,

        /// <summary>
        /// Enables predication if at least one of the 64-bits are not zero.
        /// </summary>
        D3D12_PREDICATION_OP_NOT_EQUAL_ZERO = 1
    }
}
