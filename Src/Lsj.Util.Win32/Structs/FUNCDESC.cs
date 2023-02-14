using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.VARENUM;
using CALLCONV = Lsj.Util.Win32.Enums.CALLCONV;
using FUNCKIND = Lsj.Util.Win32.Enums.FUNCKIND;
using INVOKEKIND = Lsj.Util.Win32.Enums.INVOKEKIND;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-funcdesc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="cParams"/> field specifies the total number of required and optional parameters.
    /// The <see cref="cParamsOpt"/> field specifies the form of optional parameters accepted by the function, as follows:
    /// A value of 0 specifies that no optional arguments are supported.
    /// A value of –1 specifies that the method's last parameter is a pointer to a safe array of variants.
    /// Any number of variant arguments greater than cParams –1 must be packaged by the caller into a safe array and passed as the final parameter.
    /// This array of optional parameters must be freed by the caller after control is returned from the call.
    /// Any other number indicates that the last n parameters of the function are variants and do not need to be specified by the caller explicitly.
    /// The parameters left unspecified should be filled in by the compiler or interpreter
    /// as variants of type <see cref="VT_ERROR"/> with the value <see cref="DISP_E_PARAMNOTFOUND"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FUNCDESC
    {
        /// <summary>
        /// The function member ID.
        /// </summary>
        public MEMBERID memid;

        /// <summary>
        /// The status code.
        /// </summary>
        public IntPtr lprgscode;

        /// <summary>
        /// Description of the element.
        /// </summary>
        public IntPtr lprgelemdescParam;

        /// <summary>
        /// Indicates the type of function (virtual, static, or dispatch-only).
        /// </summary>
        public FUNCKIND funckind;

        /// <summary>
        /// The invocation type.
        /// Indicates whether this is a property function, and if so, which type.
        /// </summary>
        public INVOKEKIND invkind;

        /// <summary>
        /// The calling convention.
        /// </summary>
        public CALLCONV callconv;

        /// <summary>
        /// The total number of parameters.
        /// </summary>
        public SHORT cParams;

        /// <summary>
        /// The number of optional parameters.
        /// </summary>
        public SHORT cParamsOpt;

        /// <summary>
        /// For <see cref="FUNC_VIRTUAL"/>, specifies the offset in the VTBL.
        /// </summary>
        public SHORT oVft;

        /// <summary>
        /// The number of possible return values.
        /// </summary>
        public SHORT cScodes;

        /// <summary>
        /// The function return type.
        /// </summary>
        public ELEMDESC elemdescFunc;

        /// <summary>
        /// The function flags. See <see cref="FUNCFLAGS"/>.
        /// </summary>
        public WORD wFuncFlags;
    }
}
