using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.DESCKIND;
using static Lsj.Util.Win32.Enums.INVOKEKIND;
using static Lsj.Util.Win32.Enums.TYPEFLAGS;
using static Lsj.Util.Win32.Enums.TYPEKIND;
using BINDPTR = Lsj.Util.Win32.Structs.BINDPTR;
using DESCKIND = Lsj.Util.Win32.Enums.DESCKIND;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="ITypeComp"/> interface provides a fast way to access information that compilers need when binding to and instantiating structures and interfaces.
    /// Binding is the process of mapping names to types and type members.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-itypecomp"/>
    /// </para>
    /// </summary>
    public unsafe struct ITypeComp
    {
        IntPtr* _vTable;

        /// <summary>
        /// Maps a name to a member of a type, or binds global variables and functions contained in a type library.
        /// </summary>
        /// <param name="szName">
        /// The name to be bound.
        /// </param>
        /// <param name="lHashVal">
        /// The hash value for the name computed by <see cref="LHashValOfNameSys"/>.
        /// </param>
        /// <param name="wFlags">
        /// One or more of the flags defined in the <see cref="INVOKEKIND"/> enumeration.
        /// Specifies whether the name was referenced as a method or a property.
        /// When binding to a variable, specify the flag <see cref="INVOKE_PROPERTYGET"/>.
        /// Specify zero to bind to any type of member.
        /// </param>
        /// <param name="ppTInfo">
        /// If a <see cref="FUNCDESC"/> or <see cref="VARDESC"/> was returned,
        /// then <paramref name="ppTInfo"/> points to a pointer to the type description that contains the item to which it is bound.
        /// </param>
        /// <param name="pDescKind">
        /// Indicates whether the name bound to is a <see cref="VARDESC"/>, <see cref="FUNCDESC"/>, or TYPECOMP.
        /// If there was no match, <see cref="DESCKIND_NONE"/>.
        /// </param>
        /// <param name="pBindPtr">
        /// The bound-to <see cref="VARDESC"/>, <see cref="FUNCDESC"/>, or <see cref="ITypeComp"/> interface.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// Use <see cref="Bind"/> for binding to the variables and methods of a type, or for binding to the global variables and methods in a type library.
        /// The returned <see cref="DESCKIND"/> pointer <paramref name="pDescKind"/> indicates
        /// whether the name was bound to a <see cref="VARDESC"/>, a <see cref="FUNCDESC"/>, or to an <see cref="ITypeComp"/> instance.
        /// The returned <paramref name="pBindPtr"/> points to the <see cref="VARDESC"/>, <see cref="FUNCDESC"/>, or <see cref="ITypeComp"/>.
        /// If a data member or method is bound to, then <paramref name="ppTInfo"/> points to the type description that contains the method or data member.
        /// If Bind binds the name to a nested binding context, it returns a pointer to an <see cref="ITypeComp"/> instance in <paramref name="pBindPtr"/>
        /// and a null type description pointer in <paramref name="ppTInfo"/>.
        /// For example, if the name of a type description is passed for a module (<see cref="TKIND_MODULE"/>),
        /// enumeration (<see cref="TKIND_ENUM"/>), or coclass (<see cref="TKIND_COCLASS"/>),
        /// <see cref="Bind"/> returns the <see cref="ITypeComp"/> instance of the type description for the module, enumeration, or coclass.
        /// This feature supports languages such as Visual Basic that allow references to members of a type description to be qualified by the name of the type description.
        /// For example, a function in a module can be referenced by modulename.functionname.
        /// The members of <see cref="TKIND_ENUM"/>, <see cref="TKIND_MODULE"/>, and <see cref="TKIND_COCLASS"/> types
        /// marked as Application objects can be bound to directly from <see cref="ITypeComp"/>, without specifying the name of the module.
        /// The <see cref="ITypeComp"/> of a coclass defers to the <see cref="ITypeComp"/> of its default interface.
        /// As with other methods of <see cref="ITypeComp"/>, <see cref="ITypeInfo"/>, and <see cref="ITypeInfo"/>,
        /// the calling code is responsible for releasing the returned object instances or structures.
        /// If a <see cref="VARDESC"/> or <see cref="FUNCDESC"/> is returned, the caller is responsible for deleting it
        /// with the returned type description and releasing the type description instance itself.
        /// Otherwise, if an <see cref="ITypeComp"/> instance is returned, the caller must release it.
        /// Special rules apply if you call a type library's Bind method, passing it the name of a member of an Application object class
        /// (a class that has the <see cref="TYPEFLAG_FAPPOBJECT"/> flag set).
        /// In this case, <see cref="DESCKIND_IMPLICITAPPOBJ"/> returns <see cref="DESCKIND_IMPLICITAPPOBJ"/> in <paramref name="pDescKind"/>,
        /// a <see cref="VARDESC"/> that describes the Application object in <paramref name="pBindPtr"/>,
        /// and the <see cref="ITypeInfo"/> of the Application object class in <paramref name="ppTInfo"/>.
        /// To bind to the object, <see cref="ITypeInfo.GetTypeComp"/> must make a call to get the <see cref="ITypeComp"/> of the Application object class,
        /// and then reinvoke its <see cref="Bind"/> method with the name initially passed to the type library's <see cref="ITypeComp"/>.
        /// The caller should use the returned <see cref="ITypeInfo"/> pointer (<paramref name="ppTInfo"/>) to get the address of the member.
        /// Note
        /// The <paramref name="wFlags"/> parameter is the same as the wflags parameter in <see cref="IDispatch.Invoke"/>.
        /// </remarks>
        public HRESULT Bind([In] LPOLESTR szName, [In] ULONG lHashVal, [In] WORD wFlags, [Out] out P<ITypeInfo> ppTInfo,
            [Out] out DESCKIND pDescKind, [Out] out BINDPTR pBindPtr)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, ULONG, WORD, out P<ITypeInfo>, out DESCKIND, out BINDPTR, HRESULT>)_vTable[3])
                    (thisPtr, szName.Handle, lHashVal, wFlags, out ppTInfo, out pDescKind, out pBindPtr);
            }
        }
    }
}
