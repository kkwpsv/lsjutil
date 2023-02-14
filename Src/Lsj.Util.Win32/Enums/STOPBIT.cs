namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// STOPBIT
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-dcb"/>
    /// </para>
    /// </summary>
    public enum STOPBIT : byte
    {
        /// <summary>
        /// 1 stop bit.
        /// </summary>
        ONESTOPBIT = 0,

        /// <summary>
        /// 1.5 stop bits.
        /// </summary>
        ONE5STOPBITS = 1,

        /// <summary>
        /// 2 stop bits.
        /// </summary>
        TWOSTOPBITS = 2,
    }
}
