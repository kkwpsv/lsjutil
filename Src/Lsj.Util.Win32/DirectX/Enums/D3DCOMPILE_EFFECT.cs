using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// These constants direct how the compiler compiles an effect file or how the runtime processes the effect file.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3dhlsl/d3dcompile-effect-constants"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3DCOMPILE_EFFECT : uint
    {
        /// <summary>
        /// <para>
        /// Compile the effects (.fx) file to a child effect.
        /// Child effects have no initializers for any shared values
        /// because these child effects are initialized in the master effect (the effect pool).
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Effect pools are supported by Effects 10 (FX10) but not by Effects 11 (FX11).
        /// For more info about differences between effect pools
        /// in Direct3D 10 and effect groups in Direct3D 11, see Effect Pools and Groups.
        /// </para>
        /// </summary>
        D3DCOMPILE_EFFECT_CHILD_EFFECT = 1 << 0,

        /// <summary>
        /// <para>
        /// Disables performance mode and allows for mutable state objects.
        /// </para>
        /// <para>
        /// By default, performance mode is enabled.
        /// Performance mode disallows mutable state objects
        /// by preventing non-literal expressions from appearing in state object definitions.
        /// </para>
        /// </summary>
        D3DCOMPILE_EFFECT_ALLOW_SLOW_OPS = 1 << 1,
    }
}
