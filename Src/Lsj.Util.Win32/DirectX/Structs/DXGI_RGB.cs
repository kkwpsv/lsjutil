using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents an RGB color.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173071(v=vs.85)"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is a member of the <see cref="DXGI_GAMMA_CONTROL"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_RGB
    {
        /// <summary>
        /// A value representing the color of the red component. The range of this value is between 0 and 1.
        /// </summary>
        public float Red;

        /// <summary>
        /// A value representing the color of the green component. The range of this value is between 0 and 1.
        /// </summary>
        public float Green;

        /// <summary>
        /// A value representing the color of the blue component. The range of this value is between 0 and 1.
        /// </summary>
        public float Blue;
    }
}
