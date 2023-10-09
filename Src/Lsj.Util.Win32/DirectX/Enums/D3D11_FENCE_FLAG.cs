using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies fence options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ne-d3d11_3-d3d11_fence_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="ID3D11Device.CreateFence"/> method.
    /// </remarks>
    public enum D3D11_FENCE_FLAG
    {
        /// <summary>
        /// No options are specified.
        /// </summary>
        D3D11_FENCE_FLAG_NONE = 0,

        /// <summary>
        /// The fence is shared.
        /// </summary>
        D3D11_FENCE_FLAG_SHARED = 0x2,

        /// <summary>
        /// The fence is shared with another GPU adapter.
        /// </summary>
        D3D11_FENCE_FLAG_SHARED_CROSS_ADAPTER = 0x4,

        /// <summary>
        /// 
        /// </summary>
        D3D11_FENCE_FLAG_NON_MONITORED = 0x8
    }
}
