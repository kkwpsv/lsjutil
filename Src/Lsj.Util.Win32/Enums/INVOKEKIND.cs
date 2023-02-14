using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the way a function is invoked.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ne-oaidl-invokekind"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// In C, value assignment is written as *pobj1 = *pobj2, while reference assignment is written as pobj1 = pobj2.
    /// Other languages have other syntactic conventions.
    /// A property or data member can support only a value assignment, a reference assignment, or both.
    /// The <see cref="INVOKEKIND"/> enumeration constants are the same constants
    /// that are passed to <see cref="IDispatch.Invoke"/> to specify the way in which a function is invoked.
    /// </remarks>
    [Flags]
    public enum INVOKEKIND
    {
        /// <summary>
        /// The member is called using a normal function invocation syntax.
        /// </summary>
        INVOKE_FUNC = 1,

        /// <summary>
        /// The function is invoked using a normal property-access syntax.
        /// </summary>
        INVOKE_PROPERTYGET = 2,

        /// <summary>
        /// The function is invoked using a property value assignment syntax.
        /// Syntactically, a typical programming language might represent changing a property in the same way as assignment.
        /// For example: object.property : = value.
        /// </summary>
        INVOKE_PROPERTYPUT = 4,

        /// <summary>
        /// The function is invoked using a property reference assignment syntax.
        /// </summary>
        INVOKE_PROPERTYPUTREF = 8
    }
}
