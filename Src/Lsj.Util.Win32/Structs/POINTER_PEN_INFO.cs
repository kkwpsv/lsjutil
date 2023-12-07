using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines basic pen information common to all pointer types.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-pointer_pen_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Applications can retrieve this information using the <see cref="GetPointerPenInfo"/>, <see cref="GetPointerFramePenInfo"/>,
    /// <see cref="GetPointerPenInfoHistory"/> and <see cref="GetPointerFramePenInfoHistory"/> API functions.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINTER_PEN_INFO
    {
        /// <summary>
        /// An embedded <see cref="POINTER_INFO"/> structure.
        /// </summary>
        public POINTER_INFO pointerInfo;

        /// <summary>
        /// The pen flag.
        /// This member can be zero or any reasonable combination of the values from the Pen Flags constants.
        /// </summary>
        public PEN_FLAGS penFlags;

        /// <summary>
        /// The pen mask.
        /// This member can be zero or any reasonable combination of the values from the Pen Mask constants.
        /// </summary>
        public PEN_MASK penMask;

        /// <summary>
        /// A pen pressure normalized to a range between 0 and 1024.
        /// The default is 0 if the device does not report pressure.
        /// </summary>
        public UINT32 pressure;

        /// <summary>
        /// The clockwise rotation, or twist, of the pointer normalized in a range of 0 to 359.
        /// The default is 0.
        /// </summary>
        public UINT32 rotation;

        /// <summary>
        /// The angle of tilt of the pointer along the x-axis in a range of -90 to +90, with a positive value indicating a tilt to the right.
        /// The default is 0.
        /// </summary>
        public INT32 tiltX;

        /// <summary>
        /// The angle of tilt of the pointer along the y-axis in a range of -90 to +90, with a positive value indicating a tilt toward the user.
        /// The default is 0.
        /// </summary>
        public INT32 tiltY;
    }
}
