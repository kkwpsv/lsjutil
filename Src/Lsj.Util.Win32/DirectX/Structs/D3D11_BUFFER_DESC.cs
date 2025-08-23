using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BIND_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_USAGE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a buffer resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_buffer_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by <see cref="ID3D11Device.CreateBuffer"/> to create buffer resources.
    /// </para>
    /// <para>
    /// In addition to this structure, you can also use the CD3D11_BUFFER_DESC derived structure,
    /// which is defined in D3D11.h and behaves like an inherited class, to help create a buffer description.
    /// </para>
    /// <para>
    /// If the bind flag is <see cref="D3D11_BIND_CONSTANT_BUFFER"/>,
    /// you must set the <see cref="ByteWidth"/> value in multiples of 16,
    /// and less than or equal to <see cref="D3D11_REQ_CONSTANT_BUFFER_ELEMENT_COUNT"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_BUFFER_DESC
    {
        /// <summary>
        /// Size of the buffer in bytes.
        /// </summary>
        public UINT ByteWidth;

        /// <summary>
        /// Identify how the buffer is expected to be read from and written to.
        /// Frequency of update is a key factor.
        /// The most common value is typically <see cref="D3D11_USAGE_DEFAULT"/>; see <see cref="D3D11_USAGE"/> for all possible values.
        /// </summary>
        public D3D11_USAGE Usage;

        /// <summary>
        /// Identify how the buffer will be bound to the pipeline.
        /// Flags (see <see cref="D3D11_BIND_FLAG"/>) can be combined with a bitwise OR.
        /// </summary>
        public D3D11_BIND_FLAG BindFlags;

        /// <summary>
        /// CPU access flags (see <see cref="D3D11_CPU_ACCESS_FLAG"/>) or 0 if no CPU access is necessary.
        /// Flags can be combined with a bitwise OR.
        /// </summary>
        public D3D11_CPU_ACCESS_FLAG CPUAccessFlags;

        /// <summary>
        /// Miscellaneous flags (see <see cref="D3D11_RESOURCE_MISC_FLAG"/>) or 0 if unused.
        /// Flags can be combined with a bitwise OR.
        /// </summary>
        public D3D11_RESOURCE_MISC_FLAG MiscFlags;

        /// <summary>
        /// <para>
        /// The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.
        /// For more info about structured buffers, see Structured Buffer.
        /// </para>
        /// <para>
        /// The size value in <see cref="StructureByteStride"/> must match the size of the format
        /// that you use for views of the buffer.
        /// For example, if you use a shader resource view (SRV) to read a buffer in a pixel shader,
        /// the SRV format size must match the size value in <see cref="StructureByteStride"/>.
        /// </para>
        /// </summary>
        public UINT StructureByteStride;
    }
}
