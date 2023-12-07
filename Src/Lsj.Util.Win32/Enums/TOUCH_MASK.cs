using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Values that can appear in the <see cref="POINTER_TOUCH_INFO.touchMask"/> field of the <see cref="POINTER_TOUCH_INFO"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/touch-mask-constants"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum TOUCH_MASK
    {
        /// <summary>
        /// Default.
        /// None of the optional fields are valid.
        /// </summary>
        TOUCH_MASK_NONE = 0x00000000,

        /// <summary>
        /// <see cref="POINTER_TOUCH_INFO.rcContact"/> of the <see cref="POINTER_TOUCH_INFO"/> structure is valid.
        /// </summary>
        TOUCH_MASK_CONTACTAREA = 0x00000001,

        /// <summary>
        /// <see cref="POINTER_TOUCH_INFO.orientation"/> of the <see cref="POINTER_TOUCH_INFO"/> structure is valid.
        /// </summary>
        TOUCH_MASK_ORIENTATION = 0x00000002,

        /// <summary>
        /// <see cref="POINTER_TOUCH_INFO.pressure"/> of the <see cref="POINTER_TOUCH_INFO"/> structure is valid.
        /// </summary>
        TOUCH_MASK_PRESSURE = 0x00000004,
    }
}
