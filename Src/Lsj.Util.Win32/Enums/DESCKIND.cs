using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the type description being bound to.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ne-oaidl-desckind"/>
    /// </para>
    /// </summary>
    public enum DESCKIND
    {
        /// <summary>
        /// No match was found.
        /// </summary>
        DESCKIND_NONE = 0,

        /// <summary>
        /// A <see cref="FUNCDESC"/> was returned.
        /// </summary>
        DESCKIND_FUNCDESC,

        /// <summary>
        /// A <see cref="VARDESC"/> was returned.
        /// </summary>
        DESCKIND_VARDESC,

        /// <summary>
        /// A TYPECOMP was returned.
        /// </summary>
        DESCKIND_TYPECOMP,

        /// <summary>
        /// An IMPLICITAPPOBJ was returned.
        /// </summary>
        DESCKIND_IMPLICITAPPOBJ,

        /// <summary>
        /// The end of the enum.
        /// </summary>
        DESCKIND_MAX
    }
}
