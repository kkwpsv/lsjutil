using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the granularity at which the graphics processing unit (GPU) can be preempted from performing its current graphics rendering task.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_graphics_preemption_granularity"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// You call the <see cref="IDXGIAdapter2.GetDesc2"/>: method to retrieve the granularity level at
    /// which the GPU can be preempted from performing its current graphics rendering task.
    /// The operating system specifies the graphics granularity level in the <see cref="DXGI_ADAPTER_DESC2.GraphicsPreemptionGranularity"/> member
    /// of the <see cref="DXGI_ADAPTER_DESC2"/> structure.
    /// </remarks>
    public enum DXGI_GRAPHICS_PREEMPTION_GRANULARITY
    {
        /// <summary>
        /// Indicates the preemption granularity as a DMA buffer.
        /// </summary>
        DXGI_GRAPHICS_PREEMPTION_DMA_BUFFER_BOUNDARY = 0,

        /// <summary>
        /// Indicates the preemption granularity as a graphics primitive.
        /// A primitive is a section in a DMA buffer and can be a group of triangles.
        /// </summary>
        DXGI_GRAPHICS_PREEMPTION_PRIMITIVE_BOUNDARY = 1,

        /// <summary>
        /// Indicates the preemption granularity as a triangle.
        /// A triangle is a part of a primitive.
        /// </summary>
        DXGI_GRAPHICS_PREEMPTION_TRIANGLE_BOUNDARY = 2,

        /// <summary>
        /// Indicates the preemption granularity as a pixel.
        /// A pixel is a part of a triangle.
        /// </summary>
        DXGI_GRAPHICS_PREEMPTION_PIXEL_BOUNDARY = 3,

        /// <summary>
        /// Indicates the preemption granularity as a graphics instruction.
        /// A graphics instruction operates on a pixel.
        /// </summary>
        DXGI_GRAPHICS_PREEMPTION_INSTRUCTION_BOUNDARY = 4
    }
}
