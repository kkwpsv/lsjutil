using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// <para>
    /// Vertex shader caps constants.
    /// These constants are used by the <see cref="D3DCAPS9.VS20Caps"/> member of <see cref="D3DCAPS9"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dvs20caps"/>
    /// </para>
    /// </summary>
    public static class D3DVS20CAPS
    {
        /// <summary>
        /// Instruction predication is supported. See setp_comp - vs.
        /// </summary>
        public const int D3DVS20CAPS_PREDICATION = 1 << 0;

        /// <summary>
        /// The maximum level of nesting of dynamic flow control instructions (break - vs, break_comp - vs, breakp - vs, if_comp - vs, if_comp - vs, if pred - vs).
        /// </summary>
        public const int D3DVS20_MAX_DYNAMICFLOWCONTROLDEPTH = 24;

        /// <summary>
        /// The minimum level of nesting of dynamic flow control instructions (break - vs, break_comp - vs, breakp - vs, if_comp - vs, if_comp - vs, if pred - vs).
        /// </summary>
        public const int D3DVS20_MIN_DYNAMICFLOWCONTROLDEPTH = 0;

        /// <summary>
        /// The maximum number of temporary registers supported.
        /// </summary>
        public const int D3DVS20_MAX_NUMTEMPS = 32;

        /// <summary>
        /// The minimum  number of temporary registers supported.
        /// </summary>
        public const int D3DVS20_MIN_NUMTEMPS = 12;

        /// <summary>
        /// The maximum depth of nesting of the loop - vs/rep - vs and call - vs/callnz bool - vs instructions.
        /// </summary>
        public const int D3DVS20_MAX_STATICFLOWCONTROLDEPTH = 4;

        /// <summary>
        /// The minimum depth of nesting of the loop - vs/rep - vs and call - vs/callnz bool - vs instructions.
        /// </summary>
        public const int D3DVS20_MIN_STATICFLOWCONTROLDEPTH = 1;
    }
}
