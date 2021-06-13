using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that defines a split button (<see cref="ButtonStyles.BS_SPLITBUTTON"/> and <see cref="ButtonStyles.BS_DEFSPLITBUTTON"/> styles).
    /// Used with the <see cref="ButtonControlMessages.BCM_GETSPLITINFO"/> and <see cref="ButtonControlMessages.BCM_SETSPLITINFO"/> messages.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/ns-commctrl-button_splitinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The glyph is the image that appears on the part of the button that activates the dropdown list.
    /// By default, this is an inverted triangle.
    /// Multiple images can be added to the image list to provide different glyphs for different states of the button, such as hot and pressed.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BUTTON_SPLITINFO
    {
        /// <summary>
        /// A set of flags that specify which members of this structure contain data to be set or which members are being requested.
        /// </summary>
        public BUTTON_SPLITINFOMaskFlags mask;

        /// <summary>
        /// A handle to the image list.
        /// The provider retains ownership of the image list and is ultimately responsible for its disposal.
        /// </summary>
        public IntPtr himlGlyph;

        /// <summary>
        /// The split button style.
        /// </summary>
        public SplitButtonStyles uSplitStyle;

        /// <summary>
        /// A <see cref="SIZE"/> structure that specifies the size of the glyph in <see cref="himlGlyph"/>.
        /// </summary>
        public SIZE size;
    }
}
