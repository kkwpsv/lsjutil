using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the visual feedback associated with an event.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-feedback_type"/>
    /// </para>
    /// </summary>
    public enum FEEDBACK_TYPE
    {
        /// <summary>
        /// Feedback for a touch contact event.
        /// </summary>
        FEEDBACK_TOUCH_CONTACTVISUALIZATION = 1,

        /// <summary>
        /// Feedback for a pen barrel-button event.
        /// </summary>
        FEEDBACK_PEN_BARRELVISUALIZATION = 2,

        /// <summary>
        /// Feedback for a pen tap event.
        /// </summary>
        FEEDBACK_PEN_TAP = 3,

        /// <summary>
        /// Feedback for a pen double-tap event.
        /// </summary>
        FEEDBACK_PEN_DOUBLETAP = 4,

        /// <summary>
        /// Feedback for a pen press-and-hold event.
        /// </summary>
        FEEDBACK_PEN_PRESSANDHOLD = 5,

        /// <summary>
        /// Feedback for a pen right-tap event.
        /// </summary>
        FEEDBACK_PEN_RIGHTTAP = 6,

        /// <summary>
        /// Feedback for a touch tap event.
        /// </summary>
        FEEDBACK_TOUCH_TAP = 7,

        /// <summary>
        /// Feedback for a touch double-tap event.
        /// </summary>
        FEEDBACK_TOUCH_DOUBLETAP = 8,

        /// <summary>
        /// Feedback for a touch press-and-hold event.
        /// </summary>
        FEEDBACK_TOUCH_PRESSANDHOLD = 9,

        /// <summary>
        /// Feedback for a touch right-tap event.
        /// </summary>
        FEEDBACK_TOUCH_RIGHTTAP = 10,

        /// <summary>
        /// Feedback for a press-and-tap gesture.
        /// </summary>
        FEEDBACK_GESTURE_PRESSANDTAP = 11,

        /// <summary>
        /// Do not use.
        /// </summary>
        FEEDBACK_MAX = unchecked((int)0xFFFFFFFF),
    }
}
