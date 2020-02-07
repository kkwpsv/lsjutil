namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Power Management Events
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/power/power-management-events
    /// </para>
    /// </summary>
    public enum PowerManagementEvents
    {
        /// <summary>
        /// <para>
        /// Power setting change event sent with a <see cref="WindowsMessages.WM_POWERBROADCAST"/> window message or
        /// in a <see cref="HandlerEx"/> notification callback for services.
        /// </para>
        /// </summary>
        PBT_POWERSETTINGCHANGE = 0x8013
    }
}
