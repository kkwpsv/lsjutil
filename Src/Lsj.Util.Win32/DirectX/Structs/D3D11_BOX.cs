using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Defines a 3D box.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_box"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The following diagram shows a 3D box, where the origin is the left, front, top corner.
    /// The values for <see cref="right"/>, <see cref="bottom"/>, and <see cref="back"/> are each one pixel past the end of the pixels that are included in the box region.
    /// That is, the values for <see cref="left"/>, <see cref="top"/>, and <see cref="front"/> are included in the box region
    /// while the values for <see cref="right"/>, <see cref="bottom"/>, and <see cref="back"/> are excluded from the box region.
    /// For example, for a box that is one pixel wide, (right - left) == 1; the box region includes the left pixel but not the right pixel.
    /// Coordinates of a box are in bytes for buffers and in texels for textures.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_BOX
    {
        /// <summary>
        /// The x position of the left hand side of the box.
        /// </summary>
        public UINT left;

        /// <summary>
        /// The y position of the top of the box.
        /// </summary>
        public UINT top;

        /// <summary>
        /// The z position of the front of the box.
        /// </summary>
        public UINT front;

        /// <summary>
        /// The x position of the right hand side of the box.
        /// </summary>
        public UINT right;

        /// <summary>
        /// The y position of the bottom of the box.
        /// </summary>
        public UINT bottom;

        /// <summary>
        /// The z position of the back of the box.
        /// </summary>
        public UINT back;
    }
}
