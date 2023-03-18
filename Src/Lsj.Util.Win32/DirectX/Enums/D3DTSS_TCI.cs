using System;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTURESTAGESTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Driver texture coordinate capability flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dtss-tci"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These constants are used by <see cref="D3DTSS_TEXCOORDINDEX"/>.
    /// </remarks>
    [Flags]
    public enum D3DTSS_TCI : uint
    {
        /// <summary>
        /// Use the specified texture coordinates contained within the vertex format.
        /// This value resolves to zero.
        /// </summary>
        D3DTSS_TCI_PASSTHRU = 0x00000000,

        /// <summary>
        /// Use the vertex normal, transformed to camera space, as the input texture coordinates for this stage's texture transformation.
        /// </summary>
        D3DTSS_TCI_CAMERASPACENORMAL = 0x00010000,

        /// <summary>
        /// Use the vertex position, transformed to camera space, as the input texture coordinates for this stage's texture transformation.
        /// </summary>
        D3DTSS_TCI_CAMERASPACEPOSITION = 0x00020000,

        /// <summary>
        /// Use the reflection vector, transformed to camera space, as the input texture coordinate for this stage's texture transformation.
        /// The reflection vector is computed from the input vertex position and normal vector.
        /// </summary>
        D3DTSS_TCI_CAMERASPACEREFLECTIONVECTOR = 0x00030000,

        /// <summary>
        /// Use the specified texture coordinates for sphere mapping.
        /// </summary>
        D3DTSS_TCI_SPHEREMAP = 0x00040000,
    }
}
