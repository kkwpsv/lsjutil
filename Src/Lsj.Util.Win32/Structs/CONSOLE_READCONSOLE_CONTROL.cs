using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.ControlKeyStates;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information for a console read operation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/console-readconsole-control"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct CONSOLE_READCONSOLE_CONTROL
    {
        /// <summary>
        /// The size of the structure.
        /// Set this member to <code>sizeof(CONSOLE_READCONSOLE_CONTROL)</code>.
        /// </summary>
        public ULONG nLength;

        /// <summary>
        /// The number of characters to skip (and thus preserve) before writing newly read input
        /// in the buffer passed to the <see cref="ReadConsole"/> function.
        /// This value must be less than the nNumberOfCharsToRead parameter of the <see cref="ReadConsole"/> function.
        /// </summary>
        public ULONG nInitialChars;

        /// <summary>
        /// A mask specifying which control characters between 0x00 and 0x1F should be used to signal that the read is complete.
        /// Each bit corresponds to a character with the least significant bit corresponding to 0x00 or NUL
        /// and the most significant bit corresponding to 0x1F or US.
        /// Multiple bits (control characters) can be specified.
        /// </summary>
        public ULONG dwCtrlWakeupMask;

        /// <summary>
        /// <para>
        /// The state of the control keys. This member can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CAPSLOCK_ON"/> 0x0080
        /// </term>
        /// <term>
        /// The CAPS LOCK light is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ENHANCED_KEY"/> 0x0100
        /// </term>
        /// <term>
        /// The key is enhanced. See remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LEFT_ALT_PRESSED"/> 0x0002
        /// </term>
        /// <term>
        /// The left ALT key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LEFT_CTRL_PRESSED"/> 0x0008
        /// </term>
        /// <term>
        /// The left CTRL key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NUMLOCK_ON"/> 0x0020
        /// </term>
        /// <term>
        /// The NUM LOCK light is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RIGHT_ALT_PRESSED"/> 0x0001
        /// </term>
        /// <term>
        /// The right ALT key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RIGHT_CTRL_PRESSED"/> 0x0004
        /// </term>
        /// <term>
        /// The right CTRL key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SCROLLLOCK_ON"/> 0x0040
        /// </term>
        /// <term>
        /// The SCROLL LOCK light is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SHIFT_PRESSED"/> 0x0010
        /// </term>
        /// <term>
        /// The SHIFT key is pressed.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ControlKeyStates dwControlKeyState;
    }
}
