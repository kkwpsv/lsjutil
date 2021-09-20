using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Animation Control Styles
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/animation-control-styles"/>
    /// </para>
    /// </summary>
    public enum AnimationControlStyles : uint
    {
        /// <summary>
        /// Centers the animation in the animation control's window.
        /// </summary>
        ACS_CENTER = 0x0001,

        /// <summary>
        /// Allows you to match an animation's background color to that of the underlying window, creating a "transparent" background.
        /// The parent of the animation control must not have the <see cref="WS_CLIPCHILDREN"/> style (see Window Styles).
        /// The control sends a <see cref="WM_CTLCOLORSTATIC"/> message to its parent.
        /// Use <see cref="SetBkColor"/> to set the background color for the device context to an appropriate value.
        /// The control interprets the upper-left pixel of the first frame as the animation's default background color.
        /// It will remap all pixels with that color to the value you supplied in response to <see cref="WM_CTLCOLORSTATIC"/>.
        /// </summary>
        ACS_TRANSPARENT = 0x0002,

        /// <summary>
        /// Starts playing the animation as soon as the AVI clip is opened.
        /// </summary>
        ACS_AUTOPLAY = 0x0004,

        /// <summary>
        /// By default, the control creates a thread to play the AVI clip.
        /// If you set this flag, the control plays the clip without creating a thread; internally the control uses a Win32 timer to synchronize playback.
        /// Comctl32.dll version 6 and later: This style is not supported. By default, the control plays the AVI clip without creating a thread.
        /// </summary>
        ACS_TIMER = 0x0008,
    }
}
