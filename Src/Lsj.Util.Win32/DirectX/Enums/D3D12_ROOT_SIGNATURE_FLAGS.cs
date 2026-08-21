using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_SHADER_VISIBILITY;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies options for root signature layout.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_root_signature_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used in the <see cref="D3D12_ROOT_SIGNATURE_DESC"/> structure.
    /// </para>
    /// <para>
    /// The value in denying access to shader stages is a minor optimization on some hardware.
    /// If, for example, the <see cref="D3D12_SHADER_VISIBILITY_ALL"/> flag has been set to broadcast the root signature to all shader stages,
    /// then denying access can overrule this and save the hardware some work.
    /// Alternatively if the shader is so simple that no root signature resources are needed,
    /// then denying access could be used here too.
    /// </para>
    /// </remarks>
    public enum D3D12_ROOT_SIGNATURE_FLAGS
    {
        /// <summary>
        /// Indicates default behavior.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_NONE = 0,

        /// <summary>
        /// The app is opting in to using the Input Assembler (requiring an input layout that defines a set of vertex buffer bindings).
        /// Omitting this flag can result in one root argument space being saved on some hardware.
        /// Omit this flag if the Input Assembler is not required, though the optimization is minor.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT = 0x1,

        /// <summary>
        /// Denies the vertex shader access to the root signature.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_DENY_VERTEX_SHADER_ROOT_ACCESS = 0x2,

        /// <summary>
        /// Denies the hull shader access to the root signature.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_DENY_HULL_SHADER_ROOT_ACCESS = 0x4,

        /// <summary>
        /// Denies the domain shader access to the root signature.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_DENY_DOMAIN_SHADER_ROOT_ACCESS = 0x8,

        /// <summary>
        /// Denies the geometry shader access to the root signature.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_DENY_GEOMETRY_SHADER_ROOT_ACCESS = 0x10,

        /// <summary>
        /// Denies the pixel shader access to the root signature.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_DENY_PIXEL_SHADER_ROOT_ACCESS = 0x20,

        /// <summary>
        /// The app is opting in to using Stream Output.
        /// Omitting this flag can result in one root argument space being saved on some hardware.
        /// Omit this flag if Stream Output is not required, though the optimization is minor.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_ALLOW_STREAM_OUTPUT = 0x40,

        /// <summary>
        /// The root signature is to be used with raytracing shaders to define resource bindings sourced from shader records in shader tables.
        /// This flag cannot be combined with any other root signature flags, which are all related to the graphics pipeline.
        /// The absence of the flag means the root signature can be used with graphics or compute,
        /// where the compute version is also shared with raytracing’s global root signature.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_LOCAL_ROOT_SIGNATURE = 0x80,

        /// <summary>
        /// Denies the amplification shader access to the root signature.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_DENY_AMPLIFICATION_SHADER_ROOT_ACCESS = 0x100,

        /// <summary>
        /// Denies the mesh shader access to the root signature.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_DENY_MESH_SHADER_ROOT_ACCESS = 0x200,

        /// <summary>
        /// The shaders are allowed to index the CBV/SRV/UAV descriptor heap directly,
        /// using the <c>ResourceDescriptorHeap</c> built-in variable.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_CBV_SRV_UAV_HEAP_DIRECTLY_INDEXED = 0x400,

        /// <summary>
        /// The shaders are allowed to index the sampler descriptor heap directly,
        /// using the <c>SamplerDescriptorHeap</c> built-in variable.
        /// </summary>
        D3D12_ROOT_SIGNATURE_FLAG_SAMPLER_HEAP_DIRECTLY_INDEXED = 0x800
    }
}
