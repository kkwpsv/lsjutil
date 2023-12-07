using static Lsj.Util.Win32.Enums.POINTER_FLAGS;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies a change in the state of a button associated with a pointer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-pointer_button_change_type"/>
    /// </para>
    /// </summary>
    public enum POINTER_BUTTON_CHANGE_TYPE
    {
        /// <summary>
        /// No change in button state.
        /// </summary>
        POINTER_CHANGE_NONE,

        /// <summary>
        /// The first button (see <see cref="POINTER_FLAG_FIRSTBUTTON"/>) transitioned to a pressed state.
        /// </summary>
        POINTER_CHANGE_FIRSTBUTTON_DOWN,

        /// <summary>
        /// The first button (see <see cref="POINTER_FLAG_FIRSTBUTTON"/>) transitioned to a released state.
        /// </summary>
        POINTER_CHANGE_FIRSTBUTTON_UP,

        /// <summary>
        /// The second button (see <see cref="POINTER_FLAG_SECONDBUTTON"/>) transitioned to a pressed state.
        /// </summary>
        POINTER_CHANGE_SECONDBUTTON_DOWN,

        /// <summary>
        /// The second button (see <see cref="POINTER_FLAG_SECONDBUTTON"/>) transitioned to a released state.
        /// </summary>
        POINTER_CHANGE_SECONDBUTTON_UP,

        /// <summary>
        /// The third button (see <see cref="POINTER_FLAG_THIRDBUTTON"/>) transitioned to a pressed state.
        /// </summary>
        POINTER_CHANGE_THIRDBUTTON_DOWN,

        /// <summary>
        /// The third button (see <see cref="POINTER_FLAG_THIRDBUTTON"/>) transitioned to a released state.
        /// </summary>
        POINTER_CHANGE_THIRDBUTTON_UP,

        /// <summary>
        /// The fourth button (see <see cref="POINTER_FLAG_FOURTHBUTTON"/>) transitioned to a pressed state.
        /// </summary>
        POINTER_CHANGE_FOURTHBUTTON_DOWN,

        /// <summary>
        /// The fourth button (see <see cref="POINTER_FLAG_FOURTHBUTTON"/>) transitioned to a released state.
        /// </summary>
        POINTER_CHANGE_FOURTHBUTTON_UP,

        /// <summary>
        /// The fifth button (see <see cref="POINTER_FLAG_FIFTHBUTTON"/>) transitioned to a pressed state.
        /// </summary>
        POINTER_CHANGE_FIFTHBUTTON_DOWN,

        /// <summary>
        /// The fifth button (see <see cref="POINTER_FLAG_FIFTHBUTTON"/>) transitioned to a released state.
        /// </summary>
        POINTER_CHANGE_FIFTHBUTTON_UP,
    }
}
