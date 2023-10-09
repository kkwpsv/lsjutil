using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Data type of a performance counter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_counter_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These flags are an output parameter in <see cref="ID3D11Device.CheckCounter"/>.
    /// </remarks>
    public enum D3D11_COUNTER_TYPE
    {
        /// <summary>
        /// 32-bit floating point.
        /// </summary>
        D3D11_COUNTER_TYPE_FLOAT32 = 0,

        /// <summary>
        /// 16-bit unsigned integer.
        /// </summary>
        D3D11_COUNTER_TYPE_UINT16,

        /// <summary>
        /// 32-bit unsigned integer.
        /// </summary>
        D3D11_COUNTER_TYPE_UINT32,

        /// <summary>
        /// 64-bit unsigned integer.
        /// </summary>
        D3D11_COUNTER_TYPE_UINT64,
    }
}
