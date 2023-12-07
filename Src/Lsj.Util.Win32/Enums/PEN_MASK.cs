using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Values that can appear in the <see cref="POINTER_PEN_INFO.penMask"/> field of the <see cref="POINTER_PEN_INFO"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/pen-mask-constants"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum PEN_MASK
    {
        /// <summary>
        /// Default.
        /// None of the optional fields are valid.
        /// </summary>
        PEN_MASK_NONE = 0x00000000,

        /// <summary>
        /// <see cref="POINTER_PEN_INFO.pressure"/> of the <see cref="POINTER_PEN_INFO"/> structure is valid.
        /// </summary>
        PEN_MASK_PRESSURE = 0x00000001,

        /// <summary>
        /// <see cref="POINTER_PEN_INFO.rotation"/> of the <see cref="POINTER_PEN_INFO"/> structure is valid.
        /// </summary>
        PEN_MASK_ROTATION = 0x00000002,

        /// <summary>
        /// <see cref="POINTER_PEN_INFO.tiltX"/> of the <see cref="POINTER_PEN_INFO"/> structure is valid.
        /// </summary>
        PEN_MASK_TILT_X = 0x00000004,

        /// <summary>
        /// <see cref="POINTER_PEN_INFO.tiltY"/> of the <see cref="POINTER_PEN_INFO"/> structure is valid.
        /// </summary>
        PEN_MASK_TILT_Y = 0x00000008,
    }
}
