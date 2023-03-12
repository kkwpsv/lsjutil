using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// D3DCS
    /// </summary>
    [Flags]
    public enum D3DCS : uint
    {
        /// <summary>
        /// D3DCS_LEFT
        /// </summary>
        D3DCS_LEFT = 0x00000001,

        /// <summary>
        /// D3DCS_RIGHT
        /// </summary>
        D3DCS_RIGHT = 0x00000002,

        /// <summary>
        /// D3DCS_TOP
        /// </summary>
        D3DCS_TOP = 0x00000004,

        /// <summary>
        /// D3DCS_BOTTOM
        /// </summary>
        D3DCS_BOTTOM = 0x00000008,

        /// <summary>
        /// D3DCS_FRONT
        /// </summary>
        D3DCS_FRONT = 0x00000010,

        /// <summary>
        /// D3DCS_BACK
        /// </summary>
        D3DCS_BACK = 0x00000020,

        /// <summary>
        /// D3DCS_PLANE0
        /// </summary>
        D3DCS_PLANE0 = 0x00000040,

        /// <summary>
        /// D3DCS_PLANE1
        /// </summary>
        D3DCS_PLANE1 = 0x00000080,

        /// <summary>
        /// D3DCS_PLANE2
        /// </summary>
        D3DCS_PLANE2 = 0x00000100,

        /// <summary>
        /// D3DCS_PLANE3
        /// </summary>
        D3DCS_PLANE3 = 0x00000200,

        /// <summary>
        /// D3DCS_PLANE4
        /// </summary>
        D3DCS_PLANE4 = 0x00000400,

        /// <summary>
        /// D3DCS_PLANE5
        /// </summary>
        D3DCS_PLANE5 = 0x00000800,

        /// <summary>
        /// D3DCS_ALL
        /// </summary>
        D3DCS_ALL = (D3DCS_LEFT | D3DCS_RIGHT | D3DCS_TOP | D3DCS_BOTTOM | D3DCS_FRONT | D3DCS_BACK | D3DCS_PLANE0 | D3DCS_PLANE1 | D3DCS_PLANE2 | D3DCS_PLANE3 | D3DCS_PLANE4 | D3DCS_PLANE5)
    }
}
