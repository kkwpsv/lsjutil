using Lsj.Util.Win32.ComInterfaces;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the function type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ne-oaidl-funckind"/>
    /// </para>
    /// </summary>
    public enum FUNCKIND
    {
        /// <summary>
        /// The function is accessed the same as <see cref="FUNC_PUREVIRTUAL"/>, except the function has an implementation.
        /// </summary>
        FUNC_VIRTUAL = 0,

        /// <summary>
        /// The function is accessed through the virtual function table (VTBL), and takes an implicit this pointer.
        /// </summary>
        FUNC_PUREVIRTUAL,

        /// <summary>
        /// The function is accessed by static address and takes an implicit this pointer.
        /// </summary>
        FUNC_NONVIRTUAL,

        /// <summary>
        /// The function is accessed by static address and does not take an implicit this pointer.
        /// </summary>
        FUNC_STATIC,

        /// <summary>
        /// The function can be accessed only through <see cref="IDispatch"/>.
        /// </summary>
        FUNC_DISPATCH
    }
}
