namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GetClassWord"/> and <see cref="GetClassLong"/> Indexes.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclassword
    /// </para>
    /// </summary>
    public enum GetClassIndexes
    {
        /// <summary>
        /// Retrieves an ATOM value that uniquely identifies the window class.
        /// This is the same atom that the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function returns.
        /// </summary>
        GCW_ATOM = -32,
    }
}
