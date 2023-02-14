using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the header for a menu template.
    /// A complete menu template consists of a header and one or more menu item lists.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-menuitemtemplateheader"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// One or more <see cref="MENUITEMTEMPLATE"/> structures are combined to form the menu item list.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MENUITEMTEMPLATEHEADER
    {
        /// <summary>
        /// The version number.
        /// This member must be zero.
        /// </summary>
        public WORD versionNumber;

        /// <summary>
        /// The offset, in bytes, from the end of the header.
        /// The menu item list begins at this offset.
        /// Usually, this member is zero, and the menu item list follows immediately after the header.
        /// </summary>
        public WORD offset;
    }
}
