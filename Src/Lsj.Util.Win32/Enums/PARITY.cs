namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// PARITY
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-dcb"/>
    /// </para>
    /// </summary>
    public enum PARITY : byte
    {
        /// <summary>
        /// Even parity.
        /// </summary>
        EVENPARITY = 2,

        /// <summary>
        /// Mark parity.
        /// </summary>
        MARKPARITY = 3,

        /// <summary>
        /// No parity.
        /// </summary>
        NOPARITY = 0,

        /// <summary>
        /// Odd parity.
        /// </summary>
        ODDPARITY = 1,

        /// <summary>
        /// Space parity.
        /// </summary>
        SPACEPARITY = 4,
    }
}
