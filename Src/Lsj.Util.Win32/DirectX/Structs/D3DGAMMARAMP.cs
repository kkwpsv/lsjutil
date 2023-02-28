using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains red, green, and blue ramp data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dgammaramp"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DGAMMARAMP
    {
        /// <summary>
        /// Array of 256 <see cref="WORD"/> element that describes the red gamma ramp.
        /// </summary>
        public ByValWORDArrayStructForSize256 red;

        /// <summary>
        /// Array of 256 <see cref="WORD"/> element that describes the green gamma ramp.
        /// </summary>
        public ByValWORDArrayStructForSize256 green;

        /// <summary>
        /// Array of 256 <see cref="WORD"/> element that describes the blue gamma ramp.
        /// </summary>
        public ByValWORDArrayStructForSize256 blue;
    }
}
