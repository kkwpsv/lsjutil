namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DOT11_BSS_TYPE"/> enumerated type defines a basic service set (BSS) network type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/nativewifi/dot11-bss-type"/>
    /// </para>
    /// </summary>
    public enum DOT11_BSS_TYPE
    {
        /// <summary>
        /// Specifies an infrastructure BSS network.
        /// </summary>
        dot11_BSS_type_infrastructure = 1,

        /// <summary>
        /// Specifies an independent BSS (IBSS) network.
        /// </summary>
        dot11_BSS_type_independent = 2,

        /// <summary>
        /// Specifies either infrastructure or IBSS network.
        /// </summary>
        dot11_BSS_type_any = 3
    }
}
