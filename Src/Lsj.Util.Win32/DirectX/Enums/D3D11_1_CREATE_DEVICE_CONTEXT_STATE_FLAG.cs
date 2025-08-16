using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes flags that are used to create a device context state object (<see cref="ID3DDeviceContextState"/>)
    /// with the <see cref="ID3D11Device1.CreateDeviceContextState"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/ne-d3d11_1-d3d11_1_create_device_context_state_flag"/>
    /// </para>
    /// </summary>
    public enum D3D11_1_CREATE_DEVICE_CONTEXT_STATE_FLAG
    {
        /// <summary>
        /// <para>
        /// You use this flag if your application will only call methods of Direct3D 11 and Direct3D 10 interfaces from a single thread.
        /// By default, Direct3D 11 and Direct3D 10 are thread-safe.
        /// </para>
        /// <para>
        /// By using this flag, you can increase performance.
        /// However, if you use this flag and your application calls methods from multiple threads, undefined behavior might result.
        /// </para>
        /// </summary>
        D3D11_1_CREATE_DEVICE_CONTEXT_STATE_SINGLETHREADED = 0x1,
    }
}
