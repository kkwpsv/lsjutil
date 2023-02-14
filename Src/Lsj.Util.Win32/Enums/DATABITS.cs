namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Settable Data Bits
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-commprop"/>
    /// </para>
    /// </summary>
    public enum DATABITS : ushort
    {
        /// <summary>
        /// 5 data bits
        /// </summary>
        DATABITS_5 = 0x0001,

        /// <summary>
        /// 6 data bits
        /// </summary>
        DATABITS_6 = 0x0002,

        /// <summary>
        /// 7 data bits
        /// </summary>
        DATABITS_7 = 0x0004,

        /// <summary>
        /// 8 data bits
        /// </summary>
        DATABITS_8 = 0x0008,

        /// <summary>
        /// 16 data bits
        /// </summary>
        DATABITS_16 = 0x0010,

        /// <summary>
        /// Special wide path through serial hardware lines
        /// </summary>
        DATABITS_16X = 0x0020,
    }
}
