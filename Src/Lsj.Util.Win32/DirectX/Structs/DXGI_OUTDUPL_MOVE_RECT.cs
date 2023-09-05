using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DXGI_OUTDUPL_MOVE_RECT"/> structure describes the movement of a rectangle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_outdupl_move_rect"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by <see cref="IDXGIOutputDuplication.GetFrameMoveRects"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_OUTDUPL_MOVE_RECT
    {
        /// <summary>
        /// The starting position of a rectangle.
        /// </summary>
        public POINT SourcePoint;

        /// <summary>
        /// The target region to which to move a rectangle.
        /// </summary>
        public RECT DestinationRect;
    }
}
