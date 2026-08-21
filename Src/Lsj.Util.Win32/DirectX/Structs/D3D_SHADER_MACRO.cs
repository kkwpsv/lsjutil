using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Defines a shader macro.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ns-d3dcommon-d3d_shader_macro"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// You can use shader macros in your shaders.
    /// The <see cref="D3D_SHADER_MACRO"/> structure defines a single shader macro as shown in the following example:
    /// </para>
    /// <para>
    /// The following shader or effect creation functions take an array of shader macros as an input parameter:
    /// </para>
    /// <code>
    /// D3D_SHADER_MACRO Shader_Macros[] = { "zero", "0", NULL, NULL };
    /// </code>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="D3D10CompileShader"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3DX10CreateEffectFromFile"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3DX10PreprocessShaderFromFile"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3DX11CreateAsyncShaderPreprocessProcessor"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D_SHADER_MACRO
    {
        /// <summary>
        /// The macro name.
        /// </summary>
        public nint Name;

        /// <summary>
        /// The macro definition.
        /// </summary>
        public nint Definition;
    }
}
