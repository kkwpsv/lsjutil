using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the header for an extended menu template.
    /// This structure definition is for explanation only; it is not present in any standard header file.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/menurc/menuex-template-header"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An extended menu template consists of a <see cref="MENUEX_TEMPLATE_HEADER"/> structure
    /// followed by one or more contiguous <see cref="MENUEX_TEMPLATE_ITEM"/> structures.
    /// The <see cref="MENUEX_TEMPLATE_ITEM"/> structures, which are variable in length, are aligned on <see cref="DWORD"/> boundaries.
    /// To create a menu from an extended menu template in memory, use the <see cref="LoadMenuIndirect"/> function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MENUEX_TEMPLATE_HEADER
    {
        /// <summary>
        /// The template version number.
        /// This member must be 1 for extended menu templates.
        /// </summary>
        public WORD wVersion;

        /// <summary>
        /// The offset to the first <see cref="MENUEX_TEMPLATE_ITEM"/> structure, relative to the end of this structure member.
        /// If the first item definition immediately follows the <see cref="dwHelpId"/> member, this member should be 4.
        /// </summary>
        public WORD wOffset;

        /// <summary>
        /// The help identifier of menu bar.
        /// </summary>
        public DWORD dwHelpId;
    }
}
