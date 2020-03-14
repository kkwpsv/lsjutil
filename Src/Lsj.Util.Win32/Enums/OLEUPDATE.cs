namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates whether the linked object updates the cached data for the linked object automatically or only
    /// when the container calls either the <see cref="IOleObject.Update"/> or <see cref="IOleLink.Update"/> methods.
    /// The constants are used in the <see cref="IOleLink"/> interface.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/oleidl/ne-oleidl-oleupdate
    /// </para>
    /// </summary>
    public enum OLEUPDATE
    {
        /// <summary>
        /// Update the link object whenever possible, this option corresponds to the Automatic update option in the Links dialog box.
        /// </summary>
        OLEUPDATE_ALWAYS = 1,

        /// <summary>
        /// Update the link object only when <see cref="IOleObject.Update"/> or <see cref="IOleLink.Update"/> is called,
        /// this option corresponds to the Manual update option in the Links dialog box.
        /// </summary>
        OLEUPDATE_ONCALL = 3
    }
}
