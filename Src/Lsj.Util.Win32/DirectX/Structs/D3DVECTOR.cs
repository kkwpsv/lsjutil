using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Defines a vector.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dvector"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DVECTOR
    {
        /// <summary>
        /// Floating-point value describing the vector.
        /// </summary>
        public float x;

        /// <summary>
        /// Floating-point value describing the vector.
        /// </summary>
        public float y;

        /// <summary>
        /// Floating-point value describing the vector.
        /// </summary>
        public float z;
    }
}
