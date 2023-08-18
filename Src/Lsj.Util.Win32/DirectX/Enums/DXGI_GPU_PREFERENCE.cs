using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// The preference of GPU for the app to run on.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/ne-dxgi1_6-dxgi_gpu_preference"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used in the <see cref="IDXGIFactory6.EnumAdapterByGpuPreference"/> method.
    /// </remarks>
    public enum DXGI_GPU_PREFERENCE
    {
        /// <summary>
        /// No preference of GPU.
        /// </summary>
        DXGI_GPU_PREFERENCE_UNSPECIFIED = 0,

        /// <summary>
        /// Preference for the minimum-powered GPU (such as an integrated graphics processor, or iGPU).
        /// </summary>
        DXGI_GPU_PREFERENCE_MINIMUM_POWER,

        /// <summary>
        /// Preference for the highest performing GPU, such as a discrete graphics processor (dGPU) or external graphics processor (xGPU).
        /// </summary>
        DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE,
    }
}
