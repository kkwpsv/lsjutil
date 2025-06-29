using static Lsj.Util.Win32.Enums.MessageFilterFlags;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// MSGFLTINFO
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-changefilterstruct"/>
    /// </para>
    /// </summary>
    public enum MSGFLTINFO : uint
    {
        /// <summary>
        /// See the Remarks section.
        /// Applies to <see cref="MSGFLT_ALLOW"/> and <see cref="MSGFLT_DISALLOW"/>.
        /// </summary>
        MSGFLTINFO_NONE = 0,

        /// <summary>
        /// The message is allowed at a scope higher than the window.
        /// Applies to <see cref="MSGFLT_DISALLOW"/>.
        /// </summary>
        MSGFLTINFO_ALREADYALLOWED_FORWND = 1,

        /// <summary>
        /// The message has already been allowed by this window's message filter,
        /// and the function thus succeeded with no change to the window's message filter.
        /// Applies to <see cref="MSGFLT_ALLOW"/>.
        /// </summary>
        MSGFLTINFO_ALREADYDISALLOWED_FORWND = 2,

        /// <summary>
        /// The message has already been blocked by this window's message filter,
        /// and the function thus succeeded with no change to the window's message filter.
        /// Applies to <see cref="MSGFLT_DISALLOW"/>.
        /// </summary>
        MSGFLTINFO_ALLOWED_HIGHER = 3,
    }
}
