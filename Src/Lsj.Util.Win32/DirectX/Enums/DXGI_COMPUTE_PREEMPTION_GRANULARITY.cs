using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the granularity at which the graphics processing unit (GPU) can be preempted from performing its current compute task.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_compute_preemption_granularity"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// You call the <see cref="IDXGIAdapter2.GetDesc2"/>: method to retrieve the granularity level at
    /// which the GPU can be preempted from performing its current compute task.
    /// The operating system specifies the compute granularity level in the <see cref="DXGI_ADAPTER_DESC2.ComputePreemptionGranularity "/> member
    /// of the <see cref="DXGI_ADAPTER_DESC2"/> structure.
    /// </remarks>
    public enum DXGI_COMPUTE_PREEMPTION_GRANULARITY
    {
        /// <summary>
        /// Indicates the preemption granularity as a compute packet.
        /// </summary>
        DXGI_COMPUTE_PREEMPTION_DMA_BUFFER_BOUNDARY = 0,

        /// <summary>
        /// Indicates the preemption granularity as a dispatch (for example, a call to the <see cref="ID3D11DeviceContext.Dispatch"/> method).
        /// A dispatch is a part of a compute packet.
        /// </summary>
        DXGI_COMPUTE_PREEMPTION_DISPATCH_BOUNDARY = 1,

        /// <summary>
        /// Indicates the preemption granularity as a thread group. A thread group is a part of a dispatch.
        /// </summary>
        DXGI_COMPUTE_PREEMPTION_THREAD_GROUP_BOUNDARY = 2,

        /// <summary>
        /// Indicates the preemption granularity as a thread in a thread group. A thread is a part of a thread group.
        /// </summary>
        DXGI_COMPUTE_PREEMPTION_THREAD_BOUNDARY = 3,

        /// <summary>
        /// Indicates the preemption granularity as a compute instruction in a thread.
        /// </summary>
        DXGI_COMPUTE_PREEMPTION_INSTRUCTION_BOUNDARY = 4,
    }
}
