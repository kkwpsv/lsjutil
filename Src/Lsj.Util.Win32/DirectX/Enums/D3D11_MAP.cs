using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BIND_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_CPU_ACCESS_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_USAGE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_FEATURE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies a resource to be accessed for reading and writing by the CPU.
    /// Applications may combine one or more of these flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_map"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enumeration is used in <see cref="ID3D11DeviceContext.Map"/>.
    /// </para>
    /// <para>
    /// <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/> signifies that the application promises
    /// not to write to data that the input assembler (IA) stage is using.
    /// In exchange, the GPU allows the application to write to other parts of the same buffer.
    /// The application must ensure that it does not write over any data in use by the IA stage.
    /// </para>
    /// <para>
    /// For example, consider the buffer illustrated in the following diagram.
    /// If a <see cref="ID3D11DeviceContext.Draw"/> call has been issued that uses vertices 4-6,
    /// then an application that calls <see cref="ID3D11DeviceContext.Map"/> on this buffer
    /// must ensure that it does not write to the vertices
    /// that the <see cref="ID3D11DeviceContext.Draw"/> call will access during rendering.
    /// However, ensuring this can be difficult, because the GPU is often many frames
    /// behind the CPU in terms of which frame it is currently processing.
    /// Keeping track of which sections of a resource are being used because of calls made 2 to 5 frames ago is difficult and error-prone.
    /// Because of this, it is recommended that applications only write to the uninitialized portions of a resource
    /// when using <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/>.
    /// </para>
    /// <para>
    /// <see cref="D3D11_MAP_WRITE_DISCARD"/> and <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/> are normally
    /// used in conjunction with dynamic index/vertex buffers.
    /// <see cref="D3D11_MAP_WRITE_DISCARD"/> can also be used with dynamic textures.
    /// However, <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/> cannot be used with dynamic textures.
    /// </para>
    /// <para>
    /// A common use of these two flags involves filling dynamic index/vertex buffers
    /// with geometry that can be seen from the camera's current position.
    /// The first time that data is entered into the buffer on a given frame,
    /// <see cref="ID3D11DeviceContext.Map"/> is called with <see cref="D3D11_MAP_WRITE_DISCARD"/>;
    /// doing so invalidates the previous contents of the buffer.
    /// The buffer is then filled with all available data.
    /// </para>
    /// <para>
    /// Subsequent writes to the buffer within the same frame should use <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/>.
    /// This will enable the CPU to access a resource that is potentially being used by the GPU
    /// as long as the restrictions described previously are respected.
    /// </para>
    /// </remarks>
    [Flags]
    public enum D3D11_MAP
    {
        /// <summary>
        /// Resource is mapped for reading.
        /// The resource must have been created with read access (see <see cref="D3D11_CPU_ACCESS_READ"/>).
        /// </summary>
        D3D11_MAP_READ = 1,

        /// <summary>
        /// Resource is mapped for writing.
        /// The resource must have been created with write access (see <see cref="D3D11_CPU_ACCESS_WRITE"/>).
        /// </summary>
        D3D11_MAP_WRITE = 2,

        /// <summary>
        /// Resource is mapped for reading and writing.
        /// The resource must have been created with read and write access
        /// (see <see cref="D3D11_CPU_ACCESS_READ"/> and <see cref="D3D11_CPU_ACCESS_WRITE"/>).
        /// </summary>
        D3D11_MAP_READ_WRITE = 3,

        /// <summary>
        /// Resource is mapped for writing; the previous contents of the resource will be undefined.
        /// The resource must have been created with write access and dynamic usage
        /// (See <see cref="D3D11_CPU_ACCESS_WRITE"/> and <see cref="D3D11_USAGE_DYNAMIC"/>).
        /// </summary>
        D3D11_MAP_WRITE_DISCARD = 4,

        /// <summary>
        /// <para>
        /// Resource is mapped for writing; the existing contents of the resource cannot be overwritten (see Remarks).
        /// This flag is only valid on vertex and index buffers.
        /// The resource must have been created with write access (see <see cref="D3D11_CPU_ACCESS_WRITE"/>).
        /// </para>
        /// <para>
        /// Cannot be used on a resource created with the <see cref="D3D11_BIND_CONSTANT_BUFFER"/> flag.
        /// </para>
        /// <para>
        /// Note
        /// The Direct3D 11.1 runtime, which is available starting with Windows 8, enables mapping dynamic constant buffers
        /// and shader resource views (SRVs) of dynamic buffers with <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/>.
        /// The Direct3D 11 and earlier runtimes limited mapping to vertex or index buffers.
        /// To determine if a Direct3D device supports these features,
        /// call <see cref="ID3D11Device.CheckFeatureSupport"/> with <see cref="D3D11_FEATURE_D3D11_OPTIONS"/>.
        /// <see cref="ID3D11Device.CheckFeatureSupport"/> fills members
        /// of a <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS"/> structure with the device's features.
        /// The relevant members here are <see cref="MapNoOverwriteOnDynamicConstantBuffer"/> and <see cref="MapNoOverwriteOnDynamicBufferSRV"/>.
        /// </para>
        /// </summary>
        D3D11_MAP_WRITE_NO_OVERWRITE = 5,
    }
}
