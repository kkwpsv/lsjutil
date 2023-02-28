using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Defines a set of lighting properties.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dlight9"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DLIGHT9
    {
        /// <summary>
        /// Type of the light source.
        /// This value is one of the members of the <see cref="D3DLIGHTTYPE"/> enumerated type.
        /// </summary>
        public D3DLIGHTTYPE Type;

        /// <summary>
        /// Diffuse color emitted by the light.
        /// This member is a <see cref="D3DCOLORVALUE"/> structure.
        /// </summary>
        public D3DCOLORVALUE Diffuse;

        /// <summary>
        /// Specular color emitted by the light.
        /// This member is a <see cref="D3DCOLORVALUE"/> structure.
        /// </summary>
        public D3DCOLORVALUE Specular;

        /// <summary>
        /// Ambient color emitted by the light.
        /// This member is a <see cref="D3DCOLORVALUE"/> structure.
        /// </summary>
        public D3DCOLORVALUE Ambient;

        /// <summary>
        /// Position of the light in world space, specified by a <see cref="D3DVECTOR"/> structure.
        /// This member has no meaning for directional lights and is ignored in that case.
        /// </summary>
        public D3DVECTOR Position;

        /// <summary>
        /// Direction that the light is pointing in world space, specified by a <see cref="D3DVECTOR"/> structure.
        /// This member has meaning only for directional and spotlights.
        /// This vector need not be normalized, but it should have a nonzero length.
        /// </summary>
        public D3DVECTOR Direction;

        /// <summary>
        /// Distance beyond which the light has no effect.
        /// The maximum allowable value for this member is the square root of <see cref="FLT_MAX"/>.
        /// This member does not affect directional lights.
        /// </summary>
        public float Range;

        /// <summary>
        /// Decrease in illumination between a spotlight's inner cone (the angle specified by Theta)
        /// and the outer edge of the outer cone (the angle specified by Phi).
        /// The effect of falloff on the lighting is subtle.
        /// Furthermore, a small performance penalty is incurred by shaping the falloff curve.
        /// For these reasons, most developers set this value to 1.0.
        /// </summary>
        public float Falloff;

        /// <summary>
        /// Value specifying how the light intensity changes over distance.
        /// Attenuation values are ignored for directional lights.
        /// This member represents an attenuation constant.
        /// For information about attenuation, see Light Properties (Direct3D 9).
        /// Valid values for this member range from 0.0 to infinity.
        /// For non-directional lights, all three attenuation values should not be set to 0.0 at the same time.
        /// </summary>
        public float Attenuation0;

        /// <summary>
        /// Value specifying how the light intensity changes over distance.
        /// Attenuation values are ignored for directional lights.
        /// This member represents an attenuation constant.
        /// For information about attenuation, see Light Properties (Direct3D 9).
        /// Valid values for this member range from 0.0 to infinity.
        /// For non-directional lights, all three attenuation values should not be set to 0.0 at the same time.
        /// </summary>
        public float Attenuation1;

        /// <summary>
        /// Value specifying how the light intensity changes over distance.
        /// Attenuation values are ignored for directional lights.
        /// This member represents an attenuation constant.
        /// For information about attenuation, see Light Properties (Direct3D 9).
        /// Valid values for this member range from 0.0 to infinity.
        /// For non-directional lights, all three attenuation values should not be set to 0.0 at the same time.
        /// </summary>
        public float Attenuation2;

        /// <summary>
        /// Angle, in radians, of a spotlight's inner cone - that is, the fully illuminated spotlight cone.
        /// This value must be in the range from 0 through the value specified by Phi.
        /// </summary>
        public float Theta;

        /// <summary>
        /// Angle, in radians, defining the outer edge of the spotlight's outer cone.
        /// Points outside this cone are not lit by the spotlight.
        /// This value must be between 0 and pi.
        /// </summary>
        public float Phi;
    }
}
