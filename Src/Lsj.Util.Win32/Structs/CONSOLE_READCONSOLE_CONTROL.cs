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
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/console/console-readconsole-control"/>
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
        /// A user-defined control character used to signal that the read is complete.
        /// </summary>
        public ULONG dwCtrlWakeupMask;

        /// <summary>
        /// The state of the control keys. This member can be one or more of the following values.
        /// <see cref="CAPSLOCK_ON"/>, <see cref="ENHANCED_KEY"/>, <see cref="LEFT_ALT_PRESSED"/>, <see cref="LEFT_CTRL_PRESSED"/>,
        /// <see cref="NUMLOCK_ON"/>, <see cref="RIGHT_ALT_PRESSED"/>, <see cref="RIGHT_CTRL_PRESSED"/>, <see cref="SCROLLLOCK_ON"/>,
        /// <see cref="SHIFT_PRESSED"/>
        /// </summary>
        public ControlKeyStates dwControlKeyState;
    }
}
