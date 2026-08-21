using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a key/value pair that specifies a window composition attribute and its value.
    /// This structure is used with the <see cref="GetWindowCompositionAttribute"/> and <see cref="SetWindowCompositionAttribute"/> functions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dwm/windowcompositionattribdata"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WINDOWCOMPOSITIONATTRIBDATA
    {
        /// <summary>
        /// A flag describing which value to get or set, specified as a value of the <see cref="WINDOWCOMPOSITIONATTRIB"/> enumeration.
        /// This parameter specifies which attribute to get or set,
        /// and the <see cref="pvData"/> member points to an object containing the attribute value.
        /// </summary>
        public WINDOWCOMPOSITIONATTRIB Attrib;

        /// <summary>
        /// When used with the <see cref="GetWindowCompositionAttribute"/> function,
        /// this member contains a pointer to a variable that will hold the value of the requested attribute when the function returns.
        /// When used with the <see cref="SetWindowCompositionAttribute"/> function,
        /// it points an object containing the attribute value to set.
        /// The type of the value set depends on the value of the <see cref="Attrib"/> member.
        /// For information about what type of value you should pass a pointer to in the <see cref="pvData"/> member,
        /// see <see cref="WINDOWCOMPOSITIONATTRIB"/>.
        /// </summary>
        public nint pvData;

        /// <summary>
        /// The size of the object pointed to by the <see cref="pvData"/> member, in bytes.
        /// </summary>
        public UINT cbData;
    }
}
