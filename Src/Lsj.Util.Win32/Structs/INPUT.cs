using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.InputTypes;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Used by <see cref="SendInput"/> to store information for synthesizing input events such as keystrokes, mouse movement, and mouse clicks.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-input
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INPUT
    {
        /// <summary>
        /// The type of the input event. This member can be one of the following values.
        /// <see cref="INPUT_MOUSE"/>, <see cref="INPUT_KEYBOARD"/>, <see cref="INPUT_HARDWARE"/>
        /// </summary>
        public InputTypes type;

#pragma warning disable IDE1006
        private UnionStruct<MOUSEINPUT, KEYBDINPUT, HARDWAREINPUT> DUMMYUNIONNAME;

        /// <summary>
        /// 
        /// </summary>
        public MOUSEINPUT mi
        {
            get => DUMMYUNIONNAME.Struct1;
            set => DUMMYUNIONNAME.Struct1 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public KEYBDINPUT ki
        {
            get => DUMMYUNIONNAME.Struct2;
            set => DUMMYUNIONNAME.Struct2 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public HARDWAREINPUT hi
        {
            get => DUMMYUNIONNAME.Struct3;
            set => DUMMYUNIONNAME.Struct3 = value;
        }
#pragma warning restore IDE1006
    }
}
