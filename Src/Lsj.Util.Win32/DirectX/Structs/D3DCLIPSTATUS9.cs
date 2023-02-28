using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the current clip status.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dclipstatus9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// When clipping is enabled during vertex processing (by <see cref="IDirect3DDevice9.ProcessVertices"/>,
    /// <see cref="IDirect3DDevice9.DrawPrimitive"/>, or other drawing functions),
    /// Direct3D computes a clip code for every vertex. The clip code is a combination of D3DCS_* bits.
    /// When a vertex is outside a particular clipping plane, the corresponding bit is set in the clipping code.
    /// Direct3D maintains the clip status using <see cref="D3DCLIPSTATUS9"/>, which has <see cref="ClipUnion"/> and <see cref="ClipIntersection"/> members.
    /// <see cref="ClipUnion"/> is a bitwise OR of all vertex clip codes and <see cref="ClipIntersection"/> is a bitwise AND of all vertex clip codes.
    /// Initial values are zero for <see cref="ClipUnion"/> and 0xFFFFFFFF for <see cref="ClipIntersection"/>.
    /// When <see cref="D3DRS_CLIPPING"/> is set to <see cref="FALSE"/>, <see cref="ClipUnion"/> and <see cref="ClipIntersection"/> are set to zero.
    /// Direct3D updates the clip status during drawing calls.
    /// To compute clip status for a particular object, set <see cref="ClipUnion"/> and <see cref="ClipIntersection"/> to their initial value and continue drawing.
    /// Clip status is not updated by <see cref="IDirect3DDevice9.DrawRectPatch"/> and <see cref="IDirect3DDevice9.DrawTriPatch"/>
    /// because there is no software emulation for them.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DCLIPSTATUS9
    {
        /// <summary>
        /// Clip union flags that describe the current clip status.
        /// This member can be one or more of the following flags:
        /// <see cref="D3DCS_ALL"/>: Combination of all clip flags.
        /// <see cref="D3DCS_LEFT"/>: All vertices are clipped by the left plane of the viewing frustum.
        /// <see cref="D3DCS_RIGHT"/>: All vertices are clipped by the right plane of the viewing frustum.
        /// <see cref="D3DCS_TOP"/>: All vertices are clipped by the top plane of the viewing frustum.
        /// <see cref="D3DCS_BOTTOM"/>: All vertices are clipped by the bottom plane of the viewing frustum.
        /// <see cref="D3DCS_FRONT"/>: All vertices are clipped by the front plane of the viewing frustum.
        /// <see cref="D3DCS_BACK"/>: All vertices are clipped by the back plane of the viewing frustum.
        /// <see cref="D3DCS_PLANE0"/>: Application-defined clipping planes.
        /// <see cref="D3DCS_PLANE1"/>: Application-defined clipping planes.
        /// <see cref="D3DCS_PLANE2"/>: Application-defined clipping planes.
        /// <see cref="D3DCS_PLANE3"/>: Application-defined clipping planes.
        /// <see cref="D3DCS_PLANE4"/>: Application-defined clipping planes.
        /// <see cref="D3DCS_PLANE5"/>: Application-defined clipping planes.
        /// </summary>
        public DWORD ClipUnion;

        /// <summary>
        /// Clip intersection flags that describe the current clip status.
        /// This member can take the same flags as <see cref="ClipUnion"/>.
        /// </summary>
        public DWORD ClipIntersection;
    }
}
