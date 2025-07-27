using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DispInvokeFlags;
using static Lsj.Util.Win32.OleAut32;
using CALLCONV = Lsj.Util.Win32.Enums.CALLCONV;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a method or property.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/ns-oleauto-methoddata"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct METHODDATA
    {
        /// <summary>
        /// The method name.
        /// </summary>
        public P<OLECHAR> szName;

        /// <summary>
        /// An array of method parameters.
        /// </summary>
        public P<PARAMDATA> ppdata;

        /// <summary>
        /// The ID of the method, as used in <see cref="IDispatch"/>.
        /// </summary>
        public DISPID dispid;

        /// <summary>
        /// The index of the method in the VTBL of the interface, starting with 0.
        /// </summary>
        public UINT iMeth;

        /// <summary>
        /// The calling convention. 
        /// The CDECL and Pascal calling conventions are supported by the dispatch interface creation functions, such as <see cref="CreateStdDispatch"/>.
        /// </summary>
        public CALLCONV cc;

        /// <summary>
        /// The number of arguments.
        /// </summary>
        public UINT cArgs;

        /// <summary>
        /// <para>
        /// Invoke flags.
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
        /// <see cref="DISPATCH_METHOD"/>
        /// </term>
        /// <term>
        /// The member is invoked as a method. If a property has the same name, both this and the DISPATCH_PROPERTYGET flag can be set.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISPATCH_PROPERTYGET"/>
        /// </term>
        /// <term>
        /// The member is retrieved as a property or data member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISPATCH_PROPERTYPUT"/>
        /// </term>
        /// <term>
        /// The member is set as a property or data member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISPATCH_PROPERTYPUTREF"/>
        /// </term>
        /// <term>
        /// The member is changed by a reference assignment, rather than a value assignment.
        /// This flag is valid only when the property accepts a reference to an object.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public WORD wFlags;

        /// <summary>
        /// The return type for the method.
        /// </summary>
        public VARTYPE vtReturn;
    }
}
