using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the time of the last input.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-lastinputinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This function is useful for input idle detection.
    /// For more information on tick counts, see <see cref="GetTickCount"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LASTINPUTINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// This member must be set to <c>sizeof(LASTINPUTINFO)</c>.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// The tick count when the last input event was received.
        /// </summary>
        public DWORD dwTime;
    }
}
