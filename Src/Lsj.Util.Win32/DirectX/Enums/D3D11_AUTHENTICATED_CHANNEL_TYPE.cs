namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the type of Microsoft Direct3D authenticated channel.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_authenticated_channel_type"/>
    /// </para>
    /// </summary>
    public enum D3D11_AUTHENTICATED_CHANNEL_TYPE
    {
        /// <summary>
        /// Direct3D 11 channel.
        /// This channel provides communication with the Direct3D runtime.
        /// </summary>
        D3D11_AUTHENTICATED_CHANNEL_D3D11 = 1,

        /// <summary>
        /// Software driver channel.
        /// This channel provides communication with a driver
        /// that implements content protection mechanisms in software.
        /// </summary>
        D3D11_AUTHENTICATED_CHANNEL_DRIVER_SOFTWARE = 2,

        /// <summary>
        /// Hardware driver channel.
        /// This channel provides communication with a driver
        /// that implements content protection mechanisms in the GPU hardware.
        /// </summary>
        D3D11_AUTHENTICATED_CHANNEL_DRIVER_HARDWARE = 3,
    }
}
