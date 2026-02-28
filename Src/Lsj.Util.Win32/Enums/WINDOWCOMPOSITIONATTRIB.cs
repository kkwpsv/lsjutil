using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies options used by the <see cref="WINDOWCOMPOSITIONATTRIBDATA"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dwm/windowcompositionattrib"/>
    /// </para>
    /// </summary>
    public enum WINDOWCOMPOSITIONATTRIB
    {
        /// <summary>
        /// Prevents a window from being captured by the Desktop Duplication API.
        /// The <see cref="WINDOWCOMPOSITIONATTRIBDATA.pvData"/> member
        /// of the <see cref="WINDOWCOMPOSITIONATTRIBDATA"/> structure points to a value of type <see cref="BOOL"/>.
        /// If the value is <see cref="TRUE"/>, the window is not captured.
        /// Otherwise, the window exhibits normal behavior.
        /// </summary>
        WCA_EXCLUDED_FROM_DDA = 24,
    }
}
