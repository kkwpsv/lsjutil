using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.POINTER_INPUT_TYPE;
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
    public struct POINTER_TOUCH_INFO
    {
        /// <summary>
        /// An embedded <see cref="POINTER_INFO"/> header structure.
        /// </summary>
        public POINTER_INFO pointerInfo;

        /// <summary>
        /// Currently none.
        /// </summary>
        public TOUCH_FLAGS touchFlags;

        /// <summary>
        /// Indicates which of the optional fields contain valid values.
        /// The member can be zero or any combination of the values from the Touch Mask constants.
        /// </summary>
        public TOUCH_MASK touchMask;

        /// <summary>
        /// The predicted screen coordinates of the contact area, in pixels.
        /// By default, if the device does not report a contact area, this field defaults to a 0-by-0 rectangle centered around the pointer location.
        /// The predicted value is based on the pointer position reported by the digitizer and the motion of the pointer.
        /// This correction can compensate for visual lag due to inherent delays in sensing and processing the pointer location on the digitizer.
        /// This is applicable to pointers of type <see cref="PT_TOUCH"/>.
        /// </summary>
        public RECT rcContact;

        /// <summary>
        /// The raw screen coordinates of the contact area, in pixels.
        /// For adjusted screen coordinates, see <see cref="rcContact"/>.
        /// </summary>
        public RECT rcContactRaw;

        /// <summary>
        /// A pointer orientation, with a value between 0 and 359, where 0 indicates a touch pointer aligned with the x-axis and pointing from left to right;
        /// increasing values indicate degrees of rotation in the clockwise direction.
        /// This field defaults to 0 if the device does not report orientation.
        /// Note
        /// Some touchscreen devices that support orientation will only report half-range (0-180°) values,
        /// while other devices will only report full-range (0-359°) values.
        /// </summary>
        public UINT32 orientation;

        /// <summary>
        /// A pen pressure normalized to a range between 0 and 1024.
        /// The default is 512.
        /// </summary>
        public UINT32 pressure;
    }
}
