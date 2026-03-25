using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Stores an ordered pair of integers, typically the width and height of a rectangle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_size_u"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D_SIZE_U
    {
        /// <summary>
        /// The horizontal component of this size.
        /// </summary>
        public UINT32 width;

        /// <summary>
        /// The vertical component of this size.
        /// </summary>
        public UINT32 height;
    }
}
