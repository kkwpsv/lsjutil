using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.BaseTypes.IID;
using static Lsj.Util.Win32.Enums.DispInvokeFlags;
using static Lsj.Util.Win32.OleAut32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using DISPPARAMS = Lsj.Util.Win32.Structs.DISPPARAMS;
using EXCEPINFO = Lsj.Util.Win32.Structs.EXCEPINFO;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes objects, methods and properties to programming tools and other applications that support Automation.
    /// COM components implement the <see cref="IDispatch"/> interface to enable access by Automation clients, such as Visual Basic.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-idispatch"/>
    /// </para>
    /// </summary>
    public unsafe struct IDispatch
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves the number of type information interfaces that an object provides (either 0 or 1).
        /// </summary>
        /// <param name="pctinfo">
        /// The number of type information interfaces provided by the object.
        /// If the object provides type information, this number is 1; otherwise the number is 0.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_NOTIMPL"/>: Failure.
        /// </returns>
        /// <remarks>
        /// The method may return zero, which indicates that the object does not provide any type information.
        /// In this case, the object may still be programmable through <see cref="IDispatch"/> or a VTBL,
        /// but does not provide run-time type information for browsers, compilers,
        /// or other programming tools that access type information.
        /// This can be useful for hiding an object from browsers.
        /// </remarks>
        public HRESULT GetTypeInfoCount([Out] out UINT pctinfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[3])(thisPtr, out pctinfo);
            }
        }

        /// <summary>
        /// Retrieves the type information for an object, which can then be used to get the type information for an interface.
        /// </summary>
        /// <param name="iTInfo">
        /// The type information to return.
        /// Pass 0 to retrieve type information for the <see cref="IDispatch"/> implementation.
        /// </param>
        /// <param name="lcid">
        /// The locale identifier for the type information.
        /// An object may be able to return different type information for different languages.
        /// This is important for classes that support localized member names.
        /// For classes that do not support localized member names, this parameter can be ignored.
        /// </param>
        /// <param name="ppTInfo">
        /// The requested type information object.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="DISP_E_BADINDEX"/>: The <paramref name="iTInfo"/> parameter was not 0.
        /// </returns>
        public HRESULT GetTypeInfo([In] UINT iTInfo, [In] LCID lcid, [Out] out P<ITypeInfo> ppTInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, LCID, out P<ITypeInfo>, HRESULT>)_vTable[4])(thisPtr, iTInfo, lcid, out ppTInfo);
            }
        }

        /// <summary>
        /// Maps a single member and an optional set of argument names to a corresponding set of integer DISPIDs,
        /// which can be used on subsequent calls to <see cref="Invoke"/>.
        /// The dispatch function <see cref="DispGetIDsOfNames"/> provides a standard implementation of <see cref="GetIDsOfNames"/>.
        /// </summary>
        /// <param name="riid">
        /// Reserved for future use. Must be <see cref="IID_NULL"/>.
        /// </param>
        /// <param name="rgszNames">
        /// The array of names to be mapped.
        /// </param>
        /// <param name="cNames">
        /// The count of the names to be mapped.
        /// </param>
        /// <param name="lcid">
        /// The locale context in which to interpret the names.
        /// </param>
        /// <param name="rgDispId">
        /// Caller-allocated array, each element of which contains an identifier (ID)
        /// corresponding to one of the names passed in the <paramref name="rgszNames"/> array.
        /// The first element represents the member name.
        /// The subsequent elements represent each of the member's parameters.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="E_OUTOFMEMORY"/>: Out of memory.
        /// <see cref="DISP_E_UNKNOWNNAME"/>:
        /// One or more of the specified names were not known.
        /// The returned array of DISPIDs contains <see cref="DISPID_UNKNOWN"/> for each entry that corresponds to an unknown name.
        /// <see cref="DISP_E_UNKNOWNLCID"/>:
        /// The locale identifier (LCID) was not recognized.
        /// </returns>
        /// <remarks>
        /// An <see cref="IDispatch"/> implementation can associate any positive integer ID value with a given name. 
        /// Zero is reserved for the default, or Value property; –1 is reserved to indicate an unknown name;
        /// and other negative values are defined for other purposes.
        /// For example, if <see cref="GetIDsOfNames"/> is called, and the implementation does not recognize one or more of the names,
        /// it returns <see cref="DISP_E_UNKNOWNNAME"/>, and the <paramref name="rgDispId"/> array contains <see cref="DISPID_UNKNOWN"/>
        /// for the entries that correspond to the unknown names.
        /// The member and parameter DISPIDs must remain constant for the lifetime of the object.
        /// This allows a client to obtain the DISPIDs once, and cache them for later use.
        /// When <see cref="GetIDsOfNames"/> is called with more than one name, the first name (rgszNames[0]) corresponds to the member name,
        /// and subsequent names correspond to the names of the member's parameters.
        /// The same name may map to different DISPIDs, depending on context.
        /// For example, a name may have a <see cref="DISPID"/> when it is used as a member name with a particular interface,
        /// a different ID as a member of a different interface, and different mapping for each time it appears as a parameter.
        /// <see cref="GetIDsOfNames"/> is used when an <see cref="IDispatch"/> client binds to names at run time.
        /// To bind at compile time instead, an <see cref="IDispatch"/> client can map names to DISPIDs
        /// by using the type information interfaces described in Type Description Interfaces.
        /// This allows a client to bind to members at compile time and avoid calling <see cref="GetIDsOfNames"/> at run time.
        /// For a description of binding at compile time, see Type Description Interfaces.
        /// The implementation of <see cref="GetIDsOfNames"/> is case insensitive.
        /// Users that need case-sensitive name mapping should use type information interfaces to map names to DISPIDs,
        /// rather than call <see cref="GetIDsOfNames"/>.
        /// Caution
        /// You cannot use this method to access values that have been added dynamically, such as values added through JavaScript.
        /// Instead, use the GetDispID of the IDispatchEx interface. For more information, see the IDispatchEx interface.
        /// </remarks>
        public HRESULT GetIDsOfNames([In] in IID riid, [In] LPOLESTR[] rgszNames, [In] UINT cNames, [In] LCID lcid, [Out] DISPID[] rgDispId)
        {
            var rgszNamesArray = new IntPtr[rgszNames.Length];
            for (var i = 0; i < rgszNames.Length; i++)
            {
                rgszNamesArray[i] = rgszNames[i].Handle;
            }

            fixed (IntPtr* rgszNamesPtr = rgszNamesArray)
            fixed (DISPID* rgDispIdPtr = rgDispId)
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, IntPtr*, UINT, LCID, DISPID*, HRESULT>)_vTable[5])(thisPtr, in riid, rgszNamesPtr, cNames, lcid, rgDispIdPtr);
            }
        }

        /// <summary>
        /// Provides access to properties and methods exposed by an object.
        /// The dispatch function <see cref="DispInvoke"/> provides a standard implementation of <see cref="Invoke"/>.
        /// </summary>
        /// <param name="dispIdMember">
        /// Identifies the member.
        /// Use <see cref="GetIDsOfNames"/> or the object's documentation to obtain the dispatch identifier.
        /// </param>
        /// <param name="riid">
        /// Reserved for future use. Must be <see cref="IID_NULL"/>.
        /// </param>
        /// <param name="lcid">
        /// The locale context in which to interpret arguments.
        /// The <paramref name="lcid"/> is used by the <see cref="GetIDsOfNames"/> function,
        /// and is also passed to <see cref="Invoke"/> to allow the object to interpret its arguments specific to a locale.
        /// Applications that do not support multiple national languages can ignore this parameter.
        /// For more information, refer to Supporting Multiple National Languages and Exposing ActiveX Objects.
        /// </param>
        /// <param name="wFlags">
        /// Flags describing the context of the <see cref="Invoke"/> call.
        /// <see cref="DISPATCH_METHOD"/>:
        /// The member is invoked as a method. If a property has the same name, both this and the <see cref="DISPATCH_PROPERTYGET"/> flag can be set.
        /// <see cref="DISPATCH_PROPERTYGET"/>:
        /// The member is retrieved as a property or data member.
        /// <see cref="DISPATCH_PROPERTYPUT"/>:
        /// The member is changed as a property or data member.
        /// <see cref="DISPATCH_PROPERTYPUTREF"/>:
        /// The member is changed by a reference assignment, rather than a value assignment.
        /// This flag is valid only when the property accepts a reference to an object.
        /// </param>
        /// <param name="pDispParams">
        /// Pointer to a <see cref="DISPPARAMS"/> structure containing an array of arguments,
        /// an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.
        /// </param>
        /// <param name="pVarResult">
        /// Pointer to the location where the result is to be stored, or <see cref="NullRef{VARIANT}"/> if the caller expects no result.
        /// This argument is ignored if <see cref="DISPATCH_PROPERTYPUT"/> or <see cref="DISPATCH_PROPERTYPUTREF"/> is specified.
        /// </param>
        /// <param name="pExcepInfo">
        /// Pointer to a structure that contains exception information.
        /// This structure should be filled in if <see cref="DISP_E_EXCEPTION"/> is returned.
        /// Can be <see cref="NullRef{EXCEPINFO}"/>.
        /// </param>
        /// <param name="puArgErr">
        /// The index within rgvarg of the first argument that has an error.
        /// Arguments are stored in pDispParams->rgvarg in reverse order, so the first argument is the one with the highest index in the array.
        /// This parameter is returned only when the resulting return value is <see cref="DISP_E_TYPEMISMATCH"/> or <see cref="DISP_E_PARAMNOTFOUND"/>.
        /// This argument can be set to <see cref="NullRef{UINT}"/>.
        /// For details, see Returning Errors.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>:
        /// Success.
        /// <see cref="DISP_E_BADPARAMCOUNT"/>:
        /// The number of elements provided to DISPPARAMS is different from the number of arguments accepted by the method or property.
        /// <see cref="DISP_E_BADVARTYPE"/>:
        /// One of the arguments in <see cref="DISPPARAMS"/> is not a valid variant type.
        /// <see cref="DISP_E_EXCEPTION"/>:
        /// The application needs to raise an exception.
        /// In this case, the structure passed in <paramref name="pExcepInfo"/> should be filled in.
        /// <see cref="DISP_E_MEMBERNOTFOUND"/>:
        /// The requested member does not exist.
        /// <see cref="DISP_E_NONAMEDARGS"/>:
        /// This implementation of <see cref="IDispatch"/> does not support named arguments.
        /// <see cref="DISP_E_OVERFLOW"/>:
        /// One of the arguments in <see cref="DISPPARAMS"/> could not be coerced to the specified type.
        /// <see cref="DISP_E_PARAMNOTFOUND"/>:
        /// One of the parameter IDs does not correspond to a parameter on the method.
        /// In this case, <paramref name="puArgErr"/> is set to the first argument that contains the error.
        /// <see cref="DISP_E_TYPEMISMATCH"/>:
        /// One or more of the arguments could not be coerced.
        /// The index of the first parameter with the incorrect type within <see cref="DISPPARAMS.rgvarg"/> is returned in <paramref name="puArgErr"/>.
        /// <see cref="DISP_E_UNKNOWNINTERFACE"/>:
        /// The interface identifier passed in <paramref name="riid"/> is not <see cref="IID_NULL"/>.
        /// <see cref="DISP_E_UNKNOWNLCID"/>:
        /// The member being invoked interprets string arguments according to the LCID, and the LCID is not recognized.
        /// If the LCID is not needed to interpret arguments, this error should not be returned
        /// <see cref="DISP_E_PARAMNOTOPTIONAL"/>:
        /// A required parameter was omitted.
        /// </returns>
        /// <remarks>
        /// Generally, you should not implement Invoke directly.
        /// Instead, use the dispatch interface to create functions <see cref="CreateStdDispatch"/> and <see cref="DispInvoke"/>.
        /// For details, refer to <see cref="CreateStdDispatch"/>, <see cref="DispInvoke"/>, Creating the IDispatch Interface and Exposing ActiveX Objects.
        /// If some application-specific processing needs to be performed before calling a member,
        /// the code should perform the necessary actions, and then call <see cref="ITypeInfo.Invoke"/> to invoke the member.
        /// <see cref="ITypeInfo.Invoke"/> acts exactly like <see cref="Invoke"/>.
        /// The standard implementations of <see cref="Invoke"/> created by <see cref="CreateStdDispatch"/>
        /// and <see cref="DispInvoke"/> defer to <see cref="ITypeInfo.Invoke"/>.
        /// In an ActiveX client, Invoke should be used to get and set the values of properties, or to call a method of an ActiveX object.
        /// The <paramref name="dispIdMember"/> argument identifies the member to invoke.
        /// The DISPIDs that identify members are defined by the implementer of the object and can be determined by using the object's documentation,
        /// the <see cref="GetIDsOfNames"/> function, or the <see cref="ITypeInfo"/> interface.
        /// When you use <see cref="Invoke"/> with <see cref="DISPATCH_PROPERTYPUT"/> or <see cref="DISPATCH_PROPERTYPUTREF"/>,
        /// you have to specially initialize the <see cref="DISPPARAMS.cNamedArgs"/> and <see cref="DISPPARAMS.rgdispidNamedArgs"/> elements
        /// of your <see cref="DISPPARAMS"/> structure with the following:
        /// <code>
        /// DISPID dispidNamed = DISPID_PROPERTYPUT;
        /// dispparams.cNamedArgs = 1;
        /// dispparams.rgdispidNamedArgs = &amp;dispidNamed;
        /// </code>
        /// The information that follows addresses developers of ActiveX clients and others who use code to expose ActiveX objects.
        /// It describes the behavior that users of exposed objects should expect.
        /// </remarks>
        public HRESULT Invoke([In] DISPID dispIdMember, [In] in IID riid, [In] LCID lcid, [In] DispInvokeFlags wFlags, [In] in DISPPARAMS pDispParams,
            [Out] out VARIANT pVarResult, [Out] out EXCEPINFO pExcepInfo, [Out] out UINT puArgErr)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DISPID, in IID, LCID, DispInvokeFlags, in DISPPARAMS, out VARIANT, out EXCEPINFO, out UINT, HRESULT>)_vTable[6])
                    (thisPtr, dispIdMember, in riid, lcid, wFlags, pDispParams, out pVarResult, out pExcepInfo, out puArgErr);
            }
        }
    }
}
