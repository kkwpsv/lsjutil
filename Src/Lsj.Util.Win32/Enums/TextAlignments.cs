using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// TextAlignments
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-settextalign"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum TextAlignments : uint
    {
        /// <summary>
        /// The current position is not updated after each text output call.
        /// The reference point is passed to the text output function.
        /// </summary>
        TA_NOUPDATECP = 0,

        /// <summary>
        /// The current position is updated after each text output call.
        /// The current position is used as the reference point.
        /// </summary>
        TA_UPDATECP = 1,

        /// <summary>
        /// The reference point will be on the left edge of the bounding rectangle.
        /// </summary>
        TA_LEFT = 0,

        /// <summary>
        /// The reference point will be on the right edge of the bounding rectangle.
        /// </summary>
        TA_RIGHT = 2,

        /// <summary>
        /// The reference point will be aligned horizontally with the center of the bounding rectangle.
        /// </summary>
        TA_CENTER = 6,

        /// <summary>
        /// The reference point will be on the top edge of the bounding rectangle.
        /// </summary>
        TA_TOP = 0,

        /// <summary>
        /// The reference point will be on the bottom edge of the bounding rectangle.
        /// </summary>
        TA_BOTTOM = 8,

        /// <summary>
        /// The reference point will be on the base line of the text.
        /// </summary>
        TA_BASELINE = 24,

        /// <summary>
        /// Middle East language edition of Windows:
        /// The text is laid out in right to left reading order, as opposed to the default left to right order.
        /// This applies only when the font selected into the device context is either Hebrew or Arabic.
        /// </summary>
        TA_RTLREADING = 256,

        /// <summary>
        /// The reference point will be on the base line of the text.
        /// </summary>
        VTA_BASELINE = TA_BASELINE,

        /// <summary>
        /// The reference point will be aligned vertically with the center of the bounding rectangle.
        /// </summary>
        VTA_CENTER = TA_CENTER,
    }
}
