using System.Runtime.InteropServices;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes the animation effects associated with user actions.
    /// This structure is used with the <see cref="SystemParametersInfo"/> function
    /// when the <see cref="SystemParametersInfoParameters.SPI_GETANIMATION"/>
    /// or <see cref="SystemParametersInfoParameters.SPI_SETANIMATION"/> action value is specified.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-animationinfo
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ANIMATIONINFO
    {
        /// <summary>
        /// The size of the structure, in bytes. The caller must set this to <code>sizeof(ANIMATIONINFO)</code>.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// If this member is nonzero, minimize and restore animation is enabled; otherwise it is disabled.
        /// </summary>
        public int iMinAnimate;
    }
}
