using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.VARENUM;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a parameter accepted by a method or property.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/ns-oleauto-paramdata"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PARAMDATA
    {
        /// <summary>
        /// The parameter name.
        /// Names should follow standard conventions for programming language access; that is, no embedded spaces or control characters, and 32 or fewer characters.
        /// The name should be localized because each type description provides names for a particular locale.
        /// </summary>
        public P<OLECHAR> szName;

        /// <summary>
        /// The parameter type.
        /// If more than one parameter type is accepted, <see cref="VT_VARIANT"/> should be specified.
        /// </summary>
        public VARTYPE vt;
    }
}
