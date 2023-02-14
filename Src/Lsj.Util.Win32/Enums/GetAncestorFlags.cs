using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GetAncestor"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getancestor"/>
    /// </para>
    /// </summary>
    public enum GetAncestorFlags : uint
    {
        /// <summary>
        /// Retrieves the parent window. This does not include the owner, as it does with the <see cref="GetParent"/> function.
        /// </summary>
        GA_PARENT = 1,

        /// <summary>
        /// Retrieves the root window by walking the chain of parent windows.
        /// </summary>
        GA_ROOT = 2,

        /// <summary>
        /// Retrieves the owned root window by walking the chain of parent and owner windows returned by <see cref="GetParent"/>.
        /// </summary>
        GA_ROOTOWNER = 3,
    }
}
