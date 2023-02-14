using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the variable type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ne-oaidl-varkind"/>
    /// </para>
    /// </summary>
    public enum VARKIND
    {
        /// <summary>
        /// The variable is a field or member of the type.
        /// It exists at a fixed offset within each instance of the type.
        /// </summary>
        VAR_PERINSTANCE = 0,

        /// <summary>
        /// There is only one instance of the variable.
        /// </summary>
        VAR_STATIC,

        /// <summary>
        /// The <see cref="VARDESC"/> describes a symbolic constant.
        /// There is no memory associated with it.
        /// </summary>
        VAR_CONST,

        /// <summary>
        /// The variable can only be accessed through <see cref="IDispatch.Invoke"/>.
        /// </summary>
        VAR_DISPATCH
    }
}
