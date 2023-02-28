using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the raster status.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3draster-status"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DRASTER_STATUS
    {
        /// <summary>
        /// <see cref="TRUE"/> if the raster is in the vertical blank period.
        /// <see cref="FALSE"/> if the raster is not in the vertical blank period.
        /// </summary>
        public BOOL InVBlank;

        /// <summary>
        /// If <see cref="InVBlank"/> is <see cref="FALSE"/>,
        /// then this value is an integer roughly corresponding to the current scan line painted by the raster.
        /// Scan lines are numbered in the same way as Direct3D surface coordinates:
        /// 0 is the top of the primary surface, extending to the value (height of the surface - 1) at the bottom of the display.
        /// If <see cref="InVBlank"/> is <see cref="TRUE"/>, then this value is set to zero and can be ignored.
        /// </summary>
        public UINT ScanLine;
    }
}
