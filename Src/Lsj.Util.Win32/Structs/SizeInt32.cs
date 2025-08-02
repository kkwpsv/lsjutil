using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the height and wide of a surface in a two-dimensional plane.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.sizeint32"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SizeInt32
    {
        /// <summary>
        /// The width of a surface.
        /// </summary>
        public INT32 Width;

        /// <summary>
        /// The height of a surface.
        /// </summary>
        public INT32 Height;
    };
}
