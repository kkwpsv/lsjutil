using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Defines a volume.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dbox"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="D3DBOX"/> includes the left, top, and front edges; however, the right, bottom, and back edges are not included.
    /// For example, a box that is 100 units wide and begins at 0 (thus, including the points up to and including 99)
    /// would be expressed with a value of 0 for the Left member and a value of 100 for the <see cref="Right"/> member.
    /// Note that a value of 99 is not used for the <see cref="Right"/> member.
    /// The restrictions on side ordering observed for <see cref="D3DBOX"/> are left to right, top to bottom, and front to back.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DBOX
    {
        /// <summary>
        /// Position of the left side of the box on the x-axis.
        /// </summary>
        public UINT Left;

        /// <summary>
        /// Position of the top of the box on the y-axis.
        /// </summary>
        public UINT Top;

        /// <summary>
        /// Position of the right side of the box on the x-axis.
        /// </summary>
        public UINT Right;

        /// <summary>
        /// Position of the bottom of the box on the y-axis.
        /// </summary>
        public UINT Bottom;

        /// <summary>
        /// Position of the front of the box on the z-axis.
        /// </summary>
        public UINT Front;

        /// <summary>
        /// Position of the back of the box on the z-axis.
        /// </summary>
        public UINT Back;
    }
}
