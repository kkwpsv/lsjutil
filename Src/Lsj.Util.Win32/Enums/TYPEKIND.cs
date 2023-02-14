using Lsj.Util.Win32.ComInterfaces;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies a type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ne-oaidl-typekind"/>
    /// </para>
    /// </summary>
    public enum TYPEKIND
    {
        /// <summary>
        /// A set of enumerators.
        /// </summary>
        TKIND_ENUM = 0,

        /// <summary>
        /// A structure with no methods.
        /// </summary>
        TKIND_RECORD,

        /// <summary>
        /// A module that can only have static functions and data (for example, a DLL).
        /// </summary>
        TKIND_MODULE,

        /// <summary>
        /// A type that has virtual and pure functions.
        /// </summary>
        TKIND_INTERFACE,

        /// <summary>
        /// A set of methods and properties that are accessible through <see cref="IDispatch.Invoke"/>.
        /// By default, dual interfaces return <see cref="TKIND_DISPATCH"/>.
        /// </summary>
        TKIND_DISPATCH,

        /// <summary>
        /// A set of implemented component object interfaces.
        /// </summary>
        TKIND_COCLASS,

        /// <summary>
        /// A type that is an alias for another type.
        /// </summary>
        TKIND_ALIAS,

        /// <summary>
        /// A union, all of whose members have an offset of zero.
        /// </summary>
        TKIND_UNION,

        /// <summary>
        /// End of enum marker.
        /// </summary>
        TKIND_MAX
    }
}
