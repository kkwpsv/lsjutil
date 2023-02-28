using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Defines the window dimensions of a render-target surface onto which a 3D volume projects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dviewport9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="X"/>, <see cref="Y"/>, <see cref="Width"/>, and <see cref="Height"/> members
    /// describe the position and dimensions of the viewport on the render-target surface.
    /// Usually, applications render to the entire target surface; when rendering on a 640 x 480 surface,
    /// these members should be 0, 0, 640, and 480, respectively.
    /// The <see cref="MinZ"/> and <see cref="MaxZ"/> are typically set to 0.0 and 1.0 but can be set to other values to achieve specific effects.
    /// For example, you might set them both to 0.0 to force the system to render objects to the foreground of a scene,
    /// or both to 1.0 to force the objects into the background.
    /// When the viewport parameters for a device change (because of a call to the SetViewport method), the driver builds a new transformation matrix.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DVIEWPORT9
    {
        /// <summary>
        /// Pixel coordinate of the upper-left corner of the viewport on the render-target surface.
        /// Unless you want to render to a subset of the surface, this member can be set to 0.
        /// </summary>
        public DWORD X;

        /// <summary>
        /// Pixel coordinate of the upper-left corner of the viewport on the render-target surface.
        /// Unless you want to render to a subset of the surface, this member can be set to 0.
        /// </summary>
        public DWORD Y;

        /// <summary>
        /// Width dimension of the clip volume, in pixels.
        /// Unless you are rendering only to a subset of the surface, this member should be set to the width dimension of the render-target surface.
        /// </summary>
        public DWORD Width;

        /// <summary>
        /// Height dimension of the clip volume, in pixels.
        /// Unless you are rendering only to a subset of the surface, this member should be set to the height dimension of the render-target surface.
        /// </summary>
        public DWORD Height;

        /// <summary>
        /// Together with <see cref="MaxZ"/>, value describing the range of depth values into which a scene is to be rendered,
        /// the minimum and maximum values of the clip volume.
        /// Most applications set this value to 0.0.
        /// Clipping is performed after applying the projection matrix.
        /// </summary>
        public float MinZ;

        /// <summary>
        /// Together with <see cref="MinZ"/>, value describing the range of depth values into which a scene is to be rendered,
        /// the minimum and maximum values of the clip volume.
        /// Most applications set this value to 1.0.
        /// Clipping is performed after applying the projection matrix.
        /// </summary>
        public float MaxZ;
    }
}
