using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the types of CPU access allowed for a resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_cpu_access_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enumeration is used in <see cref="D3D11_BUFFER_DESC"/>, <see cref="D3D11_TEXTURE1D_DESC"/>,
    /// <see cref="D3D11_TEXTURE2D_DESC"/>, <see cref="D3D11_TEXTURE3D_DESC"/>.
    /// </para>
    /// <para>
    /// Applications may combine one or more of these flags with a bitwise OR.
    /// When possible, create resources with no CPU access flags, as this enables better resource optimization.
    /// </para>
    /// <para>
    /// The <see cref="D3D11_RESOURCE_MISC_FLAG"/> cannot be used when creating resources with <see cref="D3D11_CPU_ACCESS_FLAG"/> flags.
    /// </para>
    /// </remarks>
    [Flags]
    public enum D3D11_CPU_ACCESS_FLAG : uint
    {
        /// <summary>
        /// The resource is to be mappable so that the CPU can change its contents.
        /// Resources created with this flag cannot be set as outputs of the pipeline
        /// and must be created with either dynamic or staging usage (see <see cref="D3D11_USAGE"/>).
        /// </summary>
        D3D11_CPU_ACCESS_WRITE = 0x10000,

        /// <summary>
        /// The resource is to be mappable so that the CPU can read its contents.
        /// Resources created with this flag cannot be set as either inputs or outputs to the pipeline
        /// and must be created with staging usage (see <see cref="D3D11_USAGE"/>).
        /// </summary>
        D3D11_CPU_ACCESS_READ = 0x20000,
    }
}
