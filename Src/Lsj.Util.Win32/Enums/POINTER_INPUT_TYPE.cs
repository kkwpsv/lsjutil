namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the pointer input types.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-tagpointer_input_type"/>
    /// </para>
    /// </summary>
    public enum POINTER_INPUT_TYPE
    {
        /// <summary>
        /// Generic pointer type.
        /// This type never appears in pointer messages or pointer data.
        /// Some data query functions allow the caller to restrict the query to specific pointer type.
        /// The <see cref="PT_POINTER"/> type can be used in these functions to specify that the query is to include pointers of all types
        /// </summary>
        PT_POINTER = 1,

        /// <summary>
        /// Touch pointer type.
        /// </summary>
        PT_TOUCH = 2,

        /// <summary>
        /// Pen pointer type.
        /// </summary>
        PT_PEN = 3,

        /// <summary>
        /// Mouse pointer type.
        /// </summary>
        PT_MOUSE = 4,

        /// <summary>
        /// Touchpad pointer type (Windows 8.1 and later).
        /// </summary>
        PT_TOUCHPAD = 5,
    }
}
