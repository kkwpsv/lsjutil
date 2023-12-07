using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Values that can appear in the <see cref="POINTER_PEN_INFO.penFlags"/> field of the <see cref="POINTER_PEN_INFO"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/pen-flags-constants"/>
    /// </para>
    /// </summary>
    public enum PEN_FLAGS
    {
        /// <summary>
        /// There is no pen flag. This is the default.
        /// </summary>
        PEN_FLAG_NONE = 0x00000000,

        /// <summary>
        /// The barrel button is pressed.
        /// </summary>
        PEN_FLAG_BARREL = 0x00000001,

        /// <summary>
        /// The pen is inverted.
        /// </summary>
        PEN_FLAG_INVERTED = 0x00000002,

        /// <summary>
        /// The eraser button is pressed.
        /// </summary>
        PEN_FLAG_ERASER = 0x00000004,
    }
}
