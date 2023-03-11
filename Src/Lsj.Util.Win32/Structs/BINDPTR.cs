using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using ITypeComp = Lsj.Util.Win32.ComInterfaces.ITypeComp;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a pointer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-bindptr"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct BINDPTR
    {
        /// <summary>
        /// Pointer to a function.
        /// </summary>
        [FieldOffset(0)]
        public P<FUNCDESC> lpfuncdesc;

        /// <summary>
        /// Pointer to a variable, constant, or data member.
        /// </summary>
        [FieldOffset(0)]
        public P<VARDESC> lpvardesc;

        /// <summary>
        /// The <see cref="ITypeComp"/> that binds the pointer.
        /// </summary>
        [FieldOffset(0)]
        public P<ITypeComp> lptcomp;
    }
}
