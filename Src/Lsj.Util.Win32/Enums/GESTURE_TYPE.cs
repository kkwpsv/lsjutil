using static Lsj.Util.Win32.Dwmapi;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the gesture type specified in <see cref="DwmRenderGesture"/>.
    /// </para>
    /// <para>
    /// From： <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-gesture_type"/>
    /// </para>
    /// </summary>
    public enum GESTURE_TYPE
    {
        /// <summary>
        /// A pen tap.
        /// </summary>
        GT_PEN_TAP = 0,

        /// <summary>
        /// A pen double tap.
        /// </summary>
        GT_PEN_DOUBLETAP = 1,

        /// <summary>
        /// A pen right tap.
        /// </summary>
        GT_PEN_RIGHTTAP = 2,

        /// <summary>
        /// A pen press and hold.
        /// </summary>
        GT_PEN_PRESSANDHOLD = 3,

        /// <summary>
        /// An abort of the pen press and hold.
        /// </summary>
        GT_PEN_PRESSANDHOLDABORT = 4,

        /// <summary>
        /// A touch tap.
        /// </summary>
        GT_TOUCH_TAP = 5,

        /// <summary>
        /// A touch double tap.
        /// </summary>
        GT_TOUCH_DOUBLETAP = 6,

        /// <summary>
        /// A touch right tap.
        /// </summary>
        GT_TOUCH_RIGHTTAP = 7,

        /// <summary>
        /// A touch press and hold.
        /// </summary>
        GT_TOUCH_PRESSANDHOLD = 8,

        /// <summary>
        /// An abort of the pen press and hold.
        /// </summary>
        GT_TOUCH_PRESSANDHOLDABORT = 9,

        /// <summary>
        /// A touch press and tap.
        /// </summary>
        GT_TOUCH_PRESSANDTAP = 10,
    }
}
