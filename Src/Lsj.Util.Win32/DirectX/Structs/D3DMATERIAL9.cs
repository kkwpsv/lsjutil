using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies material properties.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dmaterial9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To turn off specular highlights, set <see cref="D3DRS_SPECULARENABLE"/> to <see cref="FALSE"/>, using <see cref="D3DRENDERSTATETYPE"/>.
    /// This is the fastest option because no specular highlights will be calculated.
    /// For more information about using the lighting engine to calculate specular lighting, see Specular Lighting (Direct3D 9).
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DMATERIAL9
    {
        /// <summary>
        /// Value specifying the diffuse color of the material.
        /// See <see cref="D3DCOLORVALUE"/>.
        /// </summary>
        public D3DCOLORVALUE Diffuse;

        /// <summary>
        /// Value specifying the ambient color of the material.
        /// See <see cref="D3DCOLORVALUE"/>.
        /// </summary>
        public D3DCOLORVALUE Ambient;

        /// <summary>
        /// Value specifying the specular color of the material.
        /// See <see cref="D3DCOLORVALUE"/>.
        /// </summary>
        public D3DCOLORVALUE Specular;

        /// <summary>
        /// Value specifying the emissive color of the material.
        /// See <see cref="D3DCOLORVALUE"/>.
        /// </summary>
        public D3DCOLORVALUE Emissive;

        /// <summary>
        /// Floating-point value specifying the sharpness of specular highlights.
        /// The higher the value, the sharper the highlight.
        /// </summary>
        public float Power;
    }
}
