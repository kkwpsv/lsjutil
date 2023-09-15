using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_2DREGION"/> structure represents a point or an offset in a two-dimensional space.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_2dregion"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_2DREGION
    {
        /// <summary>
        /// The horizontal component of the point or offset.
        /// </summary>
        public UINT32 cx;

        /// <summary>
        /// The vertical component of the point or offset.
        /// </summary>
        public UINT32 cy;
    }
}
