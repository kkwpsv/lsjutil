using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Options for performance counters.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_counter"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Independent hardware vendors may define their own set of performance counters for their devices,
    /// by giving the enumeration value a number that is greater than the value for <see cref="D3D11_COUNTER_DEVICE_DEPENDENT_0"/>.
    /// </para>
    /// <para>
    /// This enumeration is used by <see cref="D3D11_COUNTER_DESC"/> and <see cref="D3D11_COUNTER_INFO"/>.
    /// </para>
    /// </remarks>
    public enum D3D11_COUNTER
    {
        /// <summary>
        /// Define a performance counter that is dependent on the hardware device.
        /// </summary>
        D3D11_COUNTER_DEVICE_DEPENDENT_0 = 0x40000000
    }
}
