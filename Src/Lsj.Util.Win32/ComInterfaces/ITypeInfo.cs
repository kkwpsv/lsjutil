using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.DispInvokeFlags;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.OleAut32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using DISPPARAMS = Lsj.Util.Win32.Structs.DISPPARAMS;
using EXCEPINFO = Lsj.Util.Win32.Structs.EXCEPINFO;
using FUNCDESC = Lsj.Util.Win32.Structs.FUNCDESC;
using IMPLTYPEFLAGS = Lsj.Util.Win32.Enums.IMPLTYPEFLAGS;
using INVOKEKIND = Lsj.Util.Win32.Enums.INVOKEKIND;
using TYPEATTR = Lsj.Util.Win32.Structs.TYPEATTR;
using VARDESC = Lsj.Util.Win32.Structs.VARDESC;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This section describes <see cref="ITypeInfo"/>, an interface typically used for reading information about objects.
    /// For example, an object browser tool can use <see cref="ITypeInfo"/> to extract information
    /// about the characteristics and capabilities of objects from type libraries.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-itypeinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Type information interfaces are intended to describe the parts of the application that can be called by outside clients,
    /// rather than those that might be used internally to build an application.
    /// The <see cref="ITypeInfo"/> interface provides access to the following:
    /// The set of function descriptions associated with the type.
    /// For interfaces, this contains the set of member functions in the interface.
    /// The set of data member descriptions associated with the type.
    /// For structures, this contains the set of fields of the type.
    /// The general attributes of the type, such as whether it describes a structure, an interface, and so on.
    /// The type description of an <see cref="IDispatch"/> interface can be used to implement the interface.
    /// For more information, see the description of <see cref="CreateStdDispatch"/> in Dispatch Interface and API Functions.
    /// An instance of <see cref="ITypeInfo"/> provides various information about the type of an object, and is used in different ways.
    /// A compiler can use an <see cref="ITypeInfo"/> to compile references to members of the type.
    /// A type interface browser can use it to find information about each member of the type.
    /// An <see cref="IDispatch"/> implementer can use it to provide automatic delegation of <see cref="IDispatch"/> calls to an interface.
    /// </remarks>
    public unsafe struct ITypeInfo
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves a <see cref="TYPEATTR"/> structure that contains the attributes of the type description.
        /// </summary>
        /// <param name="ppTypeAttr">
        /// The attributes of this type description.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// To free the <see cref="TYPEATTR"/> structure, use <see cref="ReleaseTypeAttr"/>.
        /// </remarks>
        public HRESULT GetTypeAttr([Out] out P<TYPEATTR> ppTypeAttr)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<TYPEATTR>, HRESULT>)_vTable[3])(thisPtr, out ppTypeAttr);
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ITypeComp"/> interface for the type description,
        /// which enables a client compiler to bind to the type description's members.
        /// </summary>
        /// <param name="ppTComp">
        /// The <see cref="ITypeComp"/> of the containing type library.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// A client compiler can use the <see cref="ITypeComp"/> interface to bind to members of the type.
        /// </remarks>
        public HRESULT GetTypeComp([Out] out P<ITypeComp> ppTComp)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ITypeComp>, HRESULT>)_vTable[4])(thisPtr, out ppTComp);
            }
        }

        /// <summary>
        /// Retrieves the <see cref="FUNCDESC"/> structure that contains information about a specified function.
        /// </summary>
        /// <param name="index">
        /// The index of the function whose description is to be returned.
        /// The index should be in the range of 0 to 1 less than the number of functions in this type.
        /// </param>
        /// <param name="ppFuncDesc">
        /// The index of the function whose description is to be returned.
        /// The index should be in the range of 0 to 1 less than the number of functions in this type.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// The function <see cref="GetFuncDesc"/> provides access to a <see cref="FUNCDESC"/> structure
        /// that describes the function with the specified index.
        /// The <see cref="FUNCDESC"/> structure should be freed with <see cref="ReleaseFuncDesc"/>.
        /// The number of functions in the type is one of the attributes contained in the <see cref="TYPEATTR"/> structure.
        /// </remarks>
        public HRESULT GetFuncDesc([In] UINT index, [Out] out P<FUNCDESC> ppFuncDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<FUNCDESC>, HRESULT>)_vTable[5])(thisPtr, index, out ppFuncDesc);
            }
        }

        /// <summary>
        /// Retrieves a <see cref="VARDESC"/> structure that describes the specified variable.
        /// </summary>
        /// <param name="index">
        /// The index of the variable whose description is to be returned.
        /// The index should be in the range of 0 to 1 less than the number of variables in this type.
        /// </param>
        /// <param name="ppVarDesc">
        /// A <see cref="VARDESC"/> that describes the specified variable.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// To free the <see cref="VARDESC"/> structure, use <see cref="ReleaseVarDesc"/>.
        /// </remarks>
        public HRESULT GetVarDesc([In] UINT index, [Out] out P<VARDESC> ppVarDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<VARDESC>, HRESULT>)_vTable[6])(thisPtr, index, out ppVarDesc);
            }
        }

        /// <summary>
        /// Retrieves the variable with the specified member ID or the name of the property
        /// or method and the parameters that correspond to the specified function ID.
        /// </summary>
        /// <param name="memid">
        /// The ID of the member whose name (or names) is to be returned.
        /// </param>
        /// <param name="rgBstrNames">
        /// The caller-allocated array.
        /// On return, each of the elements contains the name (or names) associated with the member.
        /// </param>
        /// <param name="cMaxNames">
        /// The length of the passed-in <paramref name="rgBstrNames"/> array.
        /// </param>
        /// <param name="pcNames">
        /// The number of names in the <paramref name="rgBstrNames"/> array.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// The caller must release the returned BSTR array.
        /// If the member ID identifies a property that is implemented with property functions, the property name is returned.
        /// For property get functions, the names of the function and its parameters are always returned.
        /// For property put and put reference functions, the right side of the assignment is unnamed.
        /// If <paramref name="cMaxNames"/> is less than is required to return all of the names of the parameters of a function,
        /// then only the names of the first cMaxNames - 1 parameters are returned.
        /// The names of the parameters are returned in the array in the same order that they appear elsewhere in the interface
        /// (for example, the same order in the parameter array associated with the <see cref="FUNCDESC"/> enumeration).
        /// If the type description inherits from another type description, this function is recursive to the base type description,
        /// if necessary, to find the item with the requested member ID.
        /// </remarks>
        public HRESULT GetNames([In] MEMBERID memid, [Out] BSTR[] rgBstrNames, [In] UINT cMaxNames, [Out] out UINT pcNames)
        {
            var buffer = new IntPtr[rgBstrNames.Length];
            fixed (void* thisPtr = &this)
            {
                var result = ((delegate* unmanaged[Stdcall]<void*, MEMBERID, IntPtr[], UINT, out UINT, HRESULT>)_vTable[7])(thisPtr, memid, buffer, cMaxNames, out pcNames);
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] != IntPtr.Zero)
                    {
                        rgBstrNames[i] = new BSTR(buffer[i], true);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// If a type description describes a COM class, it retrieves the type description of the implemented interface types.
        /// For an interface, <see cref="GetRefTypeOfImplType"/> returns the type information for inherited interfaces, if any exist.
        /// </summary>
        /// <param name="index">
        /// The index of the implemented type whose handle is returned.
        /// The valid range is 0 to the <see cref="TYPEATTR.cImplTypes"/> field in the <see cref="TYPEATTR"/> structure.
        /// </param>
        /// <param name="pRefType">
        /// A handle for the implemented interface (if any).
        /// This handle can be passed to <see cref="ITypeInfo.GetRefTypeInfo"/> to get the type description.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="TYPE_E_ELEMENTNOTFOUND"/>: Passed index is outside the range 0 to 1 less than the number of implemented interfaces.
        /// </returns>
        /// <remarks>
        /// If the <see cref="TKIND_DISPATCH"/> type description is for a dual interface,
        /// the <see cref="TKIND_INTERFACE"/> type description can be obtained
        /// by calling <see cref="GetRefTypeOfImplType"/> with an <paramref name="index"/> of –1,
        /// and by passing the returned <paramref name="pRefType"/> to <see cref="GetRefTypeInfo"/> to retrieve the type information.
        /// </remarks>
        public HRESULT GetRefTypeOfImplType([In] UINT index, [Out] out HREFTYPE pRefType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out HREFTYPE, HRESULT>)_vTable[8])(thisPtr, index, out pRefType);
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IMPLTYPEFLAGS"/> enumeration for one implemented interface or base interface in a type description.
        /// </summary>
        /// <param name="index">
        /// The index of the implemented interface or base interface for which to get the flags.
        /// </param>
        /// <param name="pImplTypeFlags">
        /// The <see cref="IMPLTYPEFLAGS"/> enumeration value.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// The flags are associated with the act of inheritance, and not with the inherited interface.
        /// </remarks>
        public HRESULT GetImplTypeFlags([In] UINT index, [Out] out IMPLTYPEFLAGS pImplTypeFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out IMPLTYPEFLAGS, HRESULT>)_vTable[9])(thisPtr, index, out pImplTypeFlags);
            }
        }

        /// <summary>
        /// Maps between member names and member IDs, and parameter names and parameter IDs.
        /// </summary>
        /// <param name="rgszNames">
        /// An array of names to be mapped.
        /// </param>
        /// <param name="cNames">
        /// The count of the names to be mapped.
        /// </param>
        /// <param name="pMemId">
        /// Caller-allocated array in which name mappings are placed.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// The function <see cref="GetIDsOfNames"/> maps the name of a member (rgszNames[0]) and its parameters (rgszNames[1] ...rgszNames[cNames- 1])
        /// to the ID of the member (pMemId[0]), and to the IDs of the specified parameters (pMemId[1] ... pMemId[cNames- 1]).
        /// The IDs of parameters are 0 for the first parameter in the member function's argument list, 1 for the second, and so on.
        /// If the type description inherits from another type description, this function is recursive to the base type description,
        /// if necessary, to find the item with the requested member ID.
        /// </remarks>
        public HRESULT GetIDsOfNames([In] LPOLESTR[] rgszNames, [In] UINT cNames, [Out] MEMBERID[] pMemId)
        {
            var buffer = new IntPtr[rgszNames.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = rgszNames[i].Handle;
            }
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr[], UINT, MEMBERID[], HRESULT>)_vTable[10])(thisPtr, buffer, cNames, pMemId);
            }
        }

        /// <summary>
        /// Invokes a method, or accesses a property of an object, that implements the interface described by the type description.
        /// </summary>
        /// <param name="pvInstance">
        /// An instance of the interface described by this type description.
        /// </param>
        /// <param name="memid">
        /// The interface member.
        /// </param>
        /// <param name="wFlags">
        /// Flags describing the context of the invoke call.
        /// <see cref="DISPATCH_METHOD"/>:
        /// The member is accessed as a method.
        /// If there is ambiguity, both this and the <see cref="DISPATCH_PROPERTYGET"/> flag can be set.
        /// <see cref="DISPATCH_PROPERTYGET"/>:
        /// The member is retrieved as a property or data member.
        /// <see cref="DISPATCH_PROPERTYPUT"/>:
        /// The member is changed as a property or data member.
        /// <see cref="DISPATCH_PROPERTYPUTREF"/>:
        /// The member is changed by using a reference assignment, rather than a value assignment.
        /// This flag is valid only when the property accepts a reference to an object.
        /// </param>
        /// <param name="pDispParams">
        /// An array of arguments, an array of DISPIDs for named arguments, and counts of the number of elements in each array.
        /// </param>
        /// <param name="pVarResult">
        /// The result.
        /// Should be null if the caller does not expect any result.
        /// If <paramref name="wFlags"/> specifies <see cref="DISPATCH_PROPERTYPUT"/> or <see cref="DISPATCH_PROPERTYPUTREF"/>,
        /// <paramref name="pVarResult"/> is ignored.
        /// </param>
        /// <param name="pExcepInfo">
        /// An exception information structure, which is filled in only if <see cref="DISP_E_EXCEPTION"/> is returned.
        /// If <paramref name="pExcepInfo"/> is <see cref="NullRef{EXCEPINFO}"/> on input, only an <see cref="HRESULT"/> error will be returned.
        /// </param>
        /// <param name="puArgErr">
        /// If Invoke returns <see cref="DISP_E_TYPEMISMATCH"/>, <paramref name="puArgErr"/> indicates the index (within rgvarg) of the argument with incorrect type.
        /// If more than one argument returns an error, <paramref name="puArgErr"/> indicates only the first argument with an error.
        /// Arguments in pDispParams->rgvarg appear in reverse order, so the first argument is the one having the highest index in the array.
        /// This parameter cannot be <see cref="NullRef{UINT}"/>.
        /// </param>
        /// <returns>
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="DISP_E_EXCEPTION"/>:
        /// The member being invoked has returned an error <see cref="HRESULT"/>.
        /// If the member implements <see cref="IErrorInfo"/>, details are available in the error object.
        /// Otherwise, the <paramref name="pExcepInfo"/> parameter contains details.
        /// Any of the <see cref="IDispatch.Invoke"/> errors may also be returned.
        /// </returns>
        /// <remarks>
        /// Use the function <see cref="Invoke"/> to access a member of an object or invoke a method 
        /// that implements the interface described by this type description.
        /// For objects that support the <see cref="IDispatch"/> interface, you can use Invoke to implement <see cref="IDispatch.Invoke"/>.
        /// <see cref="Invoke"/> takes a pointer to an instance of the class.
        /// Otherwise, its parameters are the same as <see cref="IDispatch.Invoke"/>,
        /// except that <see cref="Invoke"/> omits the refiid and lcid parameters.
        /// When called, <see cref="Invoke"/> performs the actions described by the <see cref="IDispatch.Invoke"/> parameters on the specified instance.
        /// For VTBL interface members, <see cref="Invoke"/> passes the LCID of the type information into parameters tagged with the lcid attribute,
        /// and the returned value into the retval attribute.
        /// If the type description inherits from another type description,
        /// this function recurses on the base type description to find the item with the requested member ID.
        /// </remarks>
        public HRESULT Invoke([In] PVOID pvInstance, [In] MEMBERID memid, [In] DispInvokeFlags wFlags, [In, Out] DISPPARAMS[] pDispParams,
            [Out] out VARIANT pVarResult, [Out] out EXCEPINFO pExcepInfo, [Out] out UINT puArgErr)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, PVOID, MEMBERID, DispInvokeFlags, DISPPARAMS[], out VARIANT, out EXCEPINFO, out UINT, HRESULT>)_vTable[11])
                    (thisPtr, pvInstance, memid, wFlags, pDispParams, out pVarResult, out pExcepInfo, out puArgErr);
            }
        }

        /// <summary>
        /// Retrieves the documentation string, the complete Help file name and path,
        /// and the context ID for the Help topic for a specified type description.
        /// </summary>
        /// <param name="memid">
        /// The ID of the member whose documentation is to be returned.
        /// </param>
        /// <param name="pBstrName">
        /// The name of the specified item.
        /// If the caller does not need the item name, <paramref name="pBstrName"/> can be <see cref="NullRef{BSTR}"/>.
        /// </param>
        /// <param name="pBstrDocString">
        /// The documentation string for the specified item.
        /// If the caller does not need the documentation string, <paramref name="pBstrDocString"/> can be <see cref="NullRef{BSTR}"/>.
        /// </param>
        /// <param name="pdwHelpContext">
        /// The Help localization context.
        /// If the caller does not need the Help context, it can be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="pBstrHelpFile">
        /// The fully qualified name of the file containing the DLL used for Help file.
        /// If the caller does not need the file name, it can be <see cref="NullRef{BSTR}"/>.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// The function <see cref="GetDocumentation"/> provides access to the documentation for the member specified by the memid parameter.
        /// If the passed-in memid is <see cref="MEMBERID_NIL"/>, then the documentation for the type description is returned.
        /// If the type description inherits from another type description, this function is recursive to the base type description,
        /// if necessary, to find the item with the requested member ID.
        /// The caller should use <see cref="SysFreeString"/> to free the BSTRs referenced by <paramref name="pBstrName"/>,
        /// <paramref name="pBstrDocString"/>, and <paramref name="pBstrHelpFile"/>.
        /// </remarks>
        public HRESULT GetDocumentation([In] MEMBERID memid, [Out] out BSTR pBstrName, [Out] out BSTR pBstrDocString,
            [Out] out DWORD pdwHelpContext, [Out] out BSTR pBstrHelpFile)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MEMBERID, out BSTR, out BSTR, out DWORD, out BSTR, HRESULT>)_vTable[12])
                    (thisPtr, memid, out pBstrName, out pBstrDocString, out pdwHelpContext, out pBstrHelpFile);
            }
        }

        /// <summary>
        /// Retrieves a description or specification of an entry point for a function in a DLL.
        /// </summary>
        /// <param name="memid">
        /// The ID of the member function whose DLL entry description is to be returned.
        /// </param>
        /// <param name="invKind">
        /// The kind of member identified by <paramref name="memid"/>.
        /// This is important for properties, because one memid can identify up to three separate functions.
        /// </param>
        /// <param name="pBstrDllName">
        /// If not null, the function sets <paramref name="pBstrDllName"/> to the name of the DLL.
        /// </param>
        /// <param name="pBstrName">
        /// If not null, the function sets <paramref name="pBstrName"/> to the name of the entry point.
        /// If the entry point is specified by an ordinal, this argument is null.
        /// </param>
        /// <param name="pwOrdinal">
        /// If not null, and if the function is defined by an ordinal, the function sets <paramref name="pwOrdinal"/> to the ordinal.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// The caller passes in a member ID, which represents the member function whose entry description is desired.
        /// If the function has a DLL entry point, the name of the DLL that contains the function,
        /// as well as its name or ordinal identifier, are placed in the passed-in pointers allocated by the caller.
        /// If there is no DLL entry point for the function, an error is returned.
        /// If the type description inherits from another type description, this function is recursive to the base type description,
        /// if necessary, to find the item with the requested member ID.
        /// The caller should use <see cref="SysFreeString"/> to free the BSTRs referenced by <paramref name="pBstrName"/> and <paramref name="pBstrDllName"/>.
        /// </remarks>
        public HRESULT GetDllEntry([In] MEMBERID memid, [In] INVOKEKIND invKind, [Out] out BSTR pBstrDllName, [Out] out BSTR pBstrName, [Out] out WORD pwOrdinal)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MEMBERID, INVOKEKIND, out BSTR, out BSTR, out WORD, HRESULT>)_vTable[13])
                    (thisPtr, memid, invKind, out pBstrDllName, out pBstrName, out pwOrdinal);
            }
        }

        /// <summary>
        /// If a type description references other type descriptions, it retrieves the referenced type descriptions.
        /// </summary>
        /// <param name="hRefType">
        /// A handle to the referenced type description to return.
        /// </param>
        /// <param name="ppTInfo">
        /// The referenced type description.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// On return, the second parameter contains a pointer to a pointer to a type description that is referenced by this type description.
        /// A type description must have a reference to each type description that occurs as the type of any of its variables,
        /// function parameters, or function return types.
        /// For example, if the type of a data member is a record type,
        /// the type description for that data member contains the hRefType of a referenced type description.
        /// To get a pointer to the type description, the reference is passed to <see cref="GetRefTypeInfo"/>.
        /// </remarks>
        public HRESULT GetRefTypeInfo([In] HREFTYPE hRefType, [Out] out P<ITypeInfo> ppTInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HREFTYPE, out P<ITypeInfo>, HRESULT>)_vTable[14])(thisPtr, hRefType, out ppTInfo);
            }
        }

        /// <summary>
        /// Retrieves the addresses of static functions or variables, such as those defined in a DLL.
        /// </summary>
        /// <param name="memid">
        /// The member ID of the static member whose address is to be retrieved.
        /// The member ID is defined by the DISPID.
        /// </param>
        /// <param name="invKind">
        /// Indicates whether the member is a property, and if so, what kind.
        /// </param>
        /// <param name="ppv">
        /// The static member.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// The addresses are valid until the caller releases its reference to the type description.
        /// The <paramref name="invKind"/> parameter can be ignored unless the address of a property function is being requested.
        /// If the type description inherits from another type description, this function is recursive to the base type description,
        /// if necessary, to find the item with the requested member ID.
        /// </remarks>
        public HRESULT AddressOfMember([In] MEMBERID memid, [In] INVOKEKIND invKind, [Out] out PVOID ppv)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MEMBERID, INVOKEKIND, out PVOID, HRESULT>)_vTable[15])(thisPtr, memid, invKind, out ppv);
            }
        }

        /// <summary>
        /// Creates a new instance of a type that describes a component object class (coclass).
        /// </summary>
        /// <param name="pUnkOuter">
        /// The controlling <see cref="IUnknown"/>.
        /// If <see cref="NullRef{IUnknown}"/>, then a stand-alone instance is created.
        /// If valid, then an aggregate object is created.
        /// </param>
        /// <param name="riid">
        /// An ID for the interface that the caller will use to communicate with the resulting object.
        /// </param>
        /// <param name="ppvObj">
        /// An instance of the created object.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// <see cref="E_NOINTERFACE"/>: OLE could not find an implementation of one or more required interfaces.
        /// Additional errors may be returned from <see cref="GetActiveObject"/> or <see cref="CoCreateInstance"/>.
        /// </returns>
        /// <remarks>
        /// For types that describe a component object class (coclass), <see cref="CreateInstance"/> creates a new instance of the class.
        /// Normally, <see cref="CreateInstance"/> calls <see cref="CoCreateInstance"/> with the type description's GUID.
        /// For an Application object, it first calls <see cref="GetActiveObject"/>.
        /// If the application is active, <see cref="GetActiveObject"/> returns the active object;
        /// otherwise, if <see cref="GetActiveObject"/> fails, <see cref="CreateInstance"/> calls <see cref="CoCreateInstance"/>.
        /// </remarks>
        public HRESULT CreateInstance([In] in IUnknown pUnkOuter, [In] in IID riid, [Out] out PVOID ppvObj)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IUnknown, in IID, out PVOID, HRESULT>)_vTable[16])(thisPtr, pUnkOuter, riid, out ppvObj);
            }
        }

        /// <summary>
        /// Retrieves marshaling information.
        /// </summary>
        /// <param name="memid">
        /// The member ID that indicates which marshaling information is needed.
        /// </param>
        /// <param name="pBstrMops">
        /// The opcode string used in marshaling the fields of the structure described by the referenced type description,
        /// or null if there is no information to return.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// If the passed-in member ID is <see cref="MEMBERID_NIL"/>, the function returns the opcode string
        /// for marshaling the fields of the structure described by the type description.
        /// Otherwise, it returns the opcode string for marshaling the function specified by the index.
        /// If the type description inherits from another type description, this function recurses on the base type description,
        /// if necessary, to find the item with the requested member ID.
        /// </remarks>
        public HRESULT GetMops([In] MEMBERID memid, [Out] out BSTR pBstrMops)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MEMBERID, out BSTR, HRESULT>)_vTable[17])(thisPtr, memid, out pBstrMops);
            }
        }

        /// <summary>
        /// Retrieves the containing type library and the index of the type description within that type library.
        /// </summary>
        /// <param name="ppTLib">
        /// The containing type library.
        /// </param>
        /// <param name="pIndex">
        /// The index of the type description within the containing type library.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_INVALIDARG"/>: One or more of the arguments is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory to complete the operation.
        /// <see cref="E_NOINTERFACE"/>: OLE could not find an implementation of one or more required interfaces.
        /// </returns>
        public HRESULT GetContainingTypeLib([Out] out P<ITypeLib> ppTLib, [Out] out UINT pIndex)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ITypeLib>, out UINT, HRESULT>)_vTable[18])(thisPtr, out ppTLib, out pIndex);
            }
        }

        /// <summary>
        /// Releases a <see cref="TYPEATTR"/> previously returned by <see cref="GetTypeAttr"/>.
        /// </summary>
        /// <param name="pTypeAttr">
        /// The <see cref="TYPEATTR"/> to be freed.
        /// </param>
        public void ReleaseTypeAttr([In] in TYPEATTR pTypeAttr)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in TYPEATTR, void>)_vTable[19])(thisPtr, pTypeAttr);
            }
        }

        /// <summary>
        /// Releases a <see cref="FUNCDESC "/> previously returned by <see cref="GetFuncDesc"/>.
        /// </summary>
        /// <param name="pFuncDesc">
        /// The <see cref="FUNCDESC"/> to be freed.
        /// </param>
        public void ReleaseFuncDesc([In] in FUNCDESC pFuncDesc)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in FUNCDESC, void>)_vTable[20])(thisPtr, pFuncDesc);
            }
        }

        /// <summary>
        /// Releases a <see cref="FUNCDESC "/> previously returned by <see cref="GetFuncDesc"/>.
        /// </summary>
        /// <param name="pVarDesc">
        /// The <see cref="FUNCDESC"/> to be freed.
        /// </param>
        public void ReleaseVarDesc([In] in FUNCDESC pVarDesc)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in FUNCDESC, void>)_vTable[21])(thisPtr, pVarDesc);
            }
        }
    }
}
