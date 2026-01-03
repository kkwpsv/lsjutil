using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.DISPID;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DispInvokeFlags;
using static Lsj.Util.Win32.Enums.VARENUM;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using DISPPARAMS = Lsj.Util.Win32.Structs.DISPPARAMS;
using EXCEPINFO = Lsj.Util.Win32.Structs.EXCEPINFO;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// OleAut32.dll
    /// </summary>
    public static class OleAut32
    {
        /// <summary>
        /// <para>
        /// Creates simplified type information for use in an implementation of <see cref="IDispatch"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-createdisptypeinfo"/>
        /// </para>
        /// </summary>
        /// <param name="pidata">
        /// The interface description that this type information describes.
        /// </param>
        /// <param name="lcid">
        /// The locale identifier for the names used in the type information.
        /// </param>
        /// <param name="pptinfo">
        /// On return, pointer to a type information implementation for use in <see cref="DispGetIDsOfNames"/> and <see cref="DispInvoke"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// This function can return one of these values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The interface is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// Either the interface description or the <see cref="LCID"/> is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// Insufficient memory to complete the operation.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You can construct type information at run time by using <see cref="CreateDispTypeInfo"/>
        /// and an <see cref="INTERFACEDATA"/> structure that describes the object being exposed.
        /// </para>
        /// <para>
        /// The type information returned by this function is primarily designed to automate the implementation of <see cref="IDispatch"/>.
        /// <see cref="CreateDispTypeInfo"/> does not return all of the type information described in Type Description Interfaces.
        /// The argument <paramref name="pidata"/> is not a complete description of an interface.
        /// It does not include Help information, comments, optional parameters, and other type information that is useful in different contexts.
        /// </para>
        /// <para>
        /// Accordingly, the recommended method for providing type information about an object is to describe the object using the Object Description Language (ODL),
        /// and to compile the object description into a type library using the Microsoft Interface Definition Language (MIDL) compiler.
        /// </para>
        /// <para>
        /// To use type information from a type library,
        /// use the <see cref="LoadTypeLib"/> and <see cref="GetTypeInfoOfGuid"/> functions instead of <see cref="CreateDispTypeInfo"/>.
        /// For more information Type Description Interfaces.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDispTypeInfo", ExactSpelling = true)]
        public static extern HRESULT CreateDispTypeInfo([In] in INTERFACEDATA pidata, [In] LCID lcid, [Out] out P<ITypeInfo> pptinfo);

        /// <summary>
        /// <para>
        /// Creates a standard implementation of the <see cref="IDispatch"/> interface through a single function call.
        /// This simplifies exposing objects through Automation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-createstddispatch"/>
        /// </para>
        /// </summary>
        /// <param name="punkOuter">
        /// The object's <see cref="IUnknown"/> implementation.
        /// </param>
        /// <param name="pvThis">
        /// The object to expose.
        /// </param>
        /// <param name="ptinfo">
        /// The type information that describes the exposed object.
        /// </param>
        /// <param name="ppunkStdDisp">
        /// The private unknown for the object that implements the <see cref="IDispatch"/> interface <see cref="IUnknown.QueryInterface"/> call.
        /// This pointer is <see cref="NULL"/> if the function fails.
        /// </param>
        /// <returns>
        /// <para>
        /// This function can return one of these values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// One of the first three arguments is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// There was insufficient memory to complete the operation.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You can use <see cref="CreateStdDispatch"/> when creating an object
        /// instead of implementing the <see cref="IDispatch"/> member functions for the object.
        /// However, the implementation that <see cref="CreateStdDispatch"/> creates has these limitations:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Supports only one national language.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Supports only dispatch-defined exception codes returned from <see cref="IDispatch.Invoke"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="LoadTypeLib"/>, <see cref="GetTypeInfoOfGuid"/>, and <see cref="CreateStdDispatch"/> comprise the minimum set of functions
        /// that you need to call to expose an object using a type library.
        /// For more information on <see cref="LoadTypeLib"/> and <see cref="GetTypeInfoOfGuid"/>, see Type Description Interfaces.
        /// </para>
        /// <para>
        /// <see cref="CreateDispTypeInfo"/> and <see cref="CreateStdDispatch"/> comprise the minimum set of dispatch components
        /// you need to call to expose an object using type information provided by the <see cref="INTERFACEDATA"/> structure.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateStdDispatch", ExactSpelling = true)]
        public static extern HRESULT CreateStdDispatch(
#if NETFRAMEWORK
            [In] nint punkOuter,
#else
            [In] P<IUnknown> punkOuter,
#endif
            [In] IntPtr pvThis, [In] in ITypeInfo ptinfo,
#if NETFRAMEWORK
            [Out] out nint ppunkStdDisp
#else
            [Out] out P<IUnknown> ppunkStdDisp
#endif
            );

        /// <summary>
        /// <para>
        /// Low-level helper for <see cref="IDispatch.Invoke"/> that provides machine independence for customized Invoke.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-dispgetidsofnames"/>
        /// </para>
        /// </summary>
        /// <param name="ptinfo">
        /// The type information for an interface.
        /// This type information is specific to one interface and language code,
        /// so it is not necessary to pass an interface identifier (IID) or LCID to this function.
        /// </param>
        /// <param name="rgszNames">
        /// An array of name strings that can be the same array passed to <see cref="DispInvoke"/> in the <see cref="DISPPARAMS"/> structure.
        /// If <paramref name="cNames"/> is greater than 1, the first name is interpreted as a method name,
        /// and subsequent names are interpreted as parameters to that method.
        /// </param>
        /// <param name="cNames">
        /// The number of elements in <paramref name="rgszNames"/>.
        /// </param>
        /// <param name="rgdispid">
        /// An array of DISPIDs to be filled in by this function.
        /// The first ID corresponds to the method name.
        /// Subsequent IDs are interpreted as parameters to the method.
        /// </param>
        /// <returns>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The interface is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// One of the parameters is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_UNKNOWNNAME"/>
        /// </term>
        /// <term>
        /// One or more of the specified names were not known.
        /// The returned array of <see cref="DISPID"/>s contains <see cref="DISPID_UNKNOWN"/> for each entry that corresponds to an unknown name.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Any of the <see cref="ITypeInfo.Invoke"/> errors can also be returned.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "DispGetIDsOfNames", ExactSpelling = true)]
        public static extern HRESULT DispGetIDsOfNames([In] in ITypeInfo ptinfo, [In] LPOLESTR[] rgszNames, [In] UINT cNames, [Out] DISPID[] rgdispid);

        /// <summary>
        /// <para>
        /// Automatically calls member functions on an interface, given the type information for the interface.
        /// You can describe an interface with type information and implement Invoke for the interface using this single call.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-dispinvoke"/>
        /// </para>
        /// </summary>
        /// <param name="_this">
        /// An implementation of the <see cref="IDispatch"/> interface described by <paramref name="ptinfo"/>.
        /// </param>
        /// <param name="ptinfo">
        /// The type information that describes the interface.
        /// </param>
        /// <param name="dispidMember">
        /// The member to be invoked.
        /// Use <see cref="IDispatch.GetIDsOfNames"/> or the object's documentation to obtain the <see cref="DISPID"/>.
        /// </param>
        /// <param name="wFlags">
        /// <para>
        /// Flags describing the context of the <see cref="IDispatch.Invoke"/> call.
        /// </para>
        /// <para>
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
        /// The member is invoked as a method.
        /// If a property has the same name, both this and the <see cref="DISPATCH_PROPERTYGET"/> flag can be set.
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
        /// The member is changed as a property or data member.
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
        /// </para>
        /// </param>
        /// <param name="pparams">
        /// Pointer to a structure containing an array of arguments,
        /// an array of argument DISPIDs for named arguments, and counts for number of elements in the arrays.
        /// </param>
        /// <param name="pvarResult">
        /// Pointer to where the result is to be stored, or <see cref="NullRef{VARIANT}"/> if the caller expects no result.
        /// This argument is ignored if <see cref="DISPATCH_PROPERTYPUT"/> or <see cref="DISPATCH_PROPERTYPUTREF"/> is specified.
        /// </param>
        /// <param name="pexcepinfo">
        /// Pointer to a structure containing exception information.
        /// This structure should be filled in if <see cref="DISP_E_EXCEPTION"/> is returned.
        /// </param>
        /// <param name="puArgErr">
        /// The index within rgvarg of the first argument that has an error.
        /// Arguments are stored in pdispparams->rgvarg in reverse order, so the first argument is the one with the highest index in the array.
        /// This parameter is returned only when the resulting return value is <see cref="DISP_E_TYPEMISMATCH"/> or <see cref="DISP_E_PARAMNOTFOUND"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_BADPARAMCOUNT"/>
        /// </term>
        /// <term>
        /// The number of elements provided to <see cref="DISPPARAMS"/> is different from the number of arguments accepted by the method or property.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_BADVARTYPE"/>
        /// </term>
        /// <term>
        /// One of the arguments in DISPPARAMS is not a valid variant type.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_EXCEPTION"/>
        /// </term>
        /// <term>
        /// The application needs to raise an exception.
        /// In this case, the structure passed in <paramref name="pexcepinfo"/> should be filled in.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_MEMBERNOTFOUND"/>
        /// </term>
        /// <term>
        /// The requested member does not exist.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_NONAMEDARGS"/>
        /// </term>
        /// <term>
        /// This implementation of <see cref="IDispatch"/> does not support named arguments.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_OVERFLOW"/>
        /// </term>
        /// <term>
        /// One of the arguments in <see cref="DISPPARAMS"/> could not be coerced to the specified type.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_PARAMNOTFOUND"/>
        /// </term>
        /// <term>
        /// One of the parameter IDs does not correspond to a parameter on the method.
        /// In this case, <paramref name="puArgErr"/> is set to the first argument that contains the error.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_PARAMNOTOPTIONAL"/>
        /// </term>
        /// <term>
        /// A required parameter was omitted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_TYPEMISMATCH"/>
        /// </term>
        /// <term>
        /// One or more of the arguments could not be coerced.
        /// The index of the first parameter with the incorrect type within rgvarg is returned in <paramref name="puArgErr"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// One of the parameters is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// Insufficient memory to complete the operation.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Any of the <see cref="ITypeInfo.Invoke"/> errors can also be returned.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The parameter <paramref name="_this"/> is a pointer to an implementation of the interface that is being deferred to.
        /// <see cref="DispInvoke"/> builds a stack frame, coerces parameters using standard coercion rules,
        /// pushes them on the stack, and then calls the correct member function in the VTBL.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "DispInvoke", ExactSpelling = true)]
        public static extern HRESULT DispInvoke([In] IntPtr _this, [In] in ITypeInfo ptinfo, [In] DISPID dispidMember, [In] WORD wFlags,
            [In] in DISPPARAMS pparams, [Out] out VARIANT pvarResult, [Out] out EXCEPINFO pexcepinfo, [Out] out UINT puArgErr);

        /// <summary>
        /// <para>
        /// Converts the MS-DOS representation of time to the date and time representation stored in a variant.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-dosdatetimetovarianttime"/>
        /// </para>
        /// </summary>
        /// <param name="wDosDate">
        /// RThe MS-DOS date to convert.
        /// The valid range of MS-DOS dates is January 1, 1980, to December 31, 2099, inclusive.
        /// </param>
        /// <param name="wDosTime">
        /// The MS-DOS time to convert.
        /// </param>
        /// <param name="pvtime">
        /// The converted time.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> on success and <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <para>
        /// MS-DOS records file dates and times as packed 16-bit values.
        /// An MS-DOS date has the following format.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Contents
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0–4
        /// </term>
        /// <term>
        /// Day of the month (1–31).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5–8
        /// </term>
        /// <term>
        /// Month (1 = January, 2 = February, and so on).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 9–15
        /// </term>
        /// <term>
        /// Year offset from 1980 (add 1980 to get the actual year).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// An MS-DOS time has the following format.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Contents
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0–4
        /// </term>
        /// <term>
        /// Second divided by 2.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5–10
        /// </term>
        /// <term>
        /// Minute (0–59).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 11–15
        /// </term>
        /// <term>
        /// Hour (0– 23 on a 24-hour clock).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="DosDateTimeToVariantTime"/> function will accept invalid dates and try to fix them when resolving to a <see cref="VARIANT"/> time.
        /// For example, an invalid date such as 2/29/2001 will resolve to 3/1/2001.
        /// Only days are fixed, so invalid month values result in an error being returned.
        /// Days are checked to be between 1 and 31.
        /// Negative days and days greater than 31 results in an error.
        /// A day less than 31 but greater than the maximum day in that month has the day promoted to the appropriate day of the next month.
        /// A day equal to zero resolves as the last day of the previous month.
        /// For example, an invalid date such as 2/0/2001 will resolve to 1/31/2001.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "DosDateTimeToVariantTime", ExactSpelling = true)]
        public static extern INT DosDateTimeToVariantTime([In] USHORT wDosDate, [In] USHORT wDosTime, [Out] out DOUBLE pvtime);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to a running object that has been registered with OLE.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-getactiveobject"/>
        /// </para>
        /// </summary>
        /// <param name="rclsid">
        /// The class identifier (CLSID) of the active object from the OLE registration database.
        /// </param>
        /// <param name="pvReserved">
        /// Reserved for future use. Must be null.
        /// </param>
        /// <param name="ppunk">
        /// The requested active object.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetActiveObject", ExactSpelling = true)]
        public static extern HRESULT GetActiveObject([In] in CLSID rclsid, [In] IntPtr pvReserved, [Out] out LPVOID ppunk);

        /// <summary>
        /// <para>
        /// Allocates a new string and copies the passed string into it.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysallocstring"/>
        /// </para>
        /// </summary>
        /// <param name="psz">
        /// The string to copy.
        /// </param>
        /// <returns>
        /// If successful, returns the string.
        /// If <paramref name="psz"/> is a zero-length string, returns a zero-length <see cref="BSTR"/>.
        /// If <paramref name="psz"/> is <see cref="NULL"/> or insufficient memory exists, returns <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// You can free strings created with <see cref="SysAllocString"/> using <see cref="SysFreeString"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "SysAllocString", ExactSpelling = true)]
        public static extern BSTR SysAllocString([In] LPCWSTR psz);

        /// <summary>
        /// <para>
        /// Takes an ANSI string as input, and returns a <see cref="BSTR"/> that contains an ANSI string.
        /// Does not perform any ANSI-to-Unicode translation.
        /// </para>
        /// </summary>
        /// <param name="psz">
        /// The string to copy, or <see cref="NULL"/> to keep the string uninitialized.
        /// </param>
        /// <param name="len">
        /// The number of bytes to copy.
        /// A null character is placed afterwards, allocating a total of <paramref name="len"/> plus the size of <see cref="OLECHAR"/> bytes.
        /// </param>
        /// <returns>
        /// A copy of the string, or <see cref="NULL"/> if there is insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is provided to create <see cref="BSTR"/>s that contain binary data.
        /// You can use this type of <see cref="BSTR"/> only in situations where it will not be translated from ANSI to Unicode, or vice versa.
        /// </para>
        /// <para>
        /// For example, do not use these <see cref="BSTR"/>s between a 16-bit and a 32-bit application running on a 32-bit Windows system.
        /// The OLE 16-bit to 32-bit (and 32-bit to 16-bit) interoperability layer will translate the <see cref="BSTR"/> and corrupt the binary data.
        /// The preferred method of passing binary data is to use a SAFEARRAY of <see cref="VT_UI1"/>, which will not be translated by OLE.
        /// </para>
        /// <para>
        /// If <paramref name="psz"/> is Null, a string of the requested length is allocated, but not initialized.
        /// The string <paramref name="psz"/> can contain embedded null characters, and does not need to end with a Null.
        /// Free the returned string later with <see cref="SysFreeString"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "SysAllocStringByteLen", ExactSpelling = true)]
        public static extern BSTR SysAllocStringByteLen([In] LPCSTR psz, [In] UINT len);

        /// <summary>
        /// /<para>
        /// Allocates a new string, copies the specified number of characters from the passed string, and appends a null-terminating character.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysallocstringlen"/>
        /// </para>
        /// </summary>
        /// <param name="strIn">
        /// The input string.
        /// </param>
        /// <param name="ui">
        /// The number of characters to copy.
        /// A null character is placed afterwards, allocating a total of <paramref name="ui"/> plus one characters.
        /// </param>
        /// <returns>
        /// A copy of the string, or <see cref="NULL"/> if there is insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The string can contain embedded null characters and does not need to end with a <see cref="NULL"/>.
        /// Free the returned string later with <see cref="SysFreeString"/>.
        /// If <paramref name="strIn"/> is not <see cref="NULL"/>, then the memory allocated to <paramref name="strIn"/> must be at least <paramref name="ui"/> characters long.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function does not convert a char* string into a Unicode BSTR.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "SysAllocStringLen", ExactSpelling = true)]
        public static extern BSTR SysAllocStringLen([In] LPCWSTR strIn, [In] UINT ui);

        /// <summary>
        /// <para>
        /// Deallocates a string allocated previously by <see cref="SysAllocString"/>, <see cref="SysAllocStringByteLen"/>,
        /// <see cref="SysReAllocString"/>, <see cref="SysAllocStringLen"/>, or <see cref="SysReAllocStringLen"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysfreestring"/>
        /// </para>
        /// </summary>
        /// <param name="bstrString">
        /// The previously allocated string.
        /// If this parameter is <see cref="NULL"/>, the function simply returns.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "SysFreeString", ExactSpelling = true)]
        public static extern void SysFreeString([In] BSTR bstrString);

        /// <summary>
        /// <para>
        /// Clears a variant.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-variantclear"/>
        /// </para>
        /// </summary>
        /// <param name="pvarg">
        /// The variant to clear.
        /// </param>
        /// <returns>
        /// <para>
        /// This function can return one of these values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_ARRAYISLOCKED"/>
        /// </term>
        /// <term>
        /// The variant contains an array that is locked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DISP_E_BADVARTYPE"/>
        /// </term>
        /// <term>
        /// The variant type is not a valid type of variant.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// One of the arguments is not valid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Use this function to clear variables of type VARIANTARG (or <see cref="VARIANT"/>)
        /// before the memory containing the VARIANTARG is freed (as when a local variable goes out of scope).
        /// </para>
        /// <para>
        /// The function clears a VARIANTARG by setting the <see cref="VARIANT.vt"/> field to <see cref="VT_EMPTY"/>.
        /// The current contents of the VARIANTARG are released first.
        /// If the <see cref="VARIANT.vt"/> field is <see cref="VT_BSTR"/>, the string is freed.
        /// If the <see cref="VARIANT.vt"/> field is <see cref="VT_DISPATCH"/>, the object is released.
        /// If the <see cref="VARIANT.vt"/> field has the <see cref="VT_ARRAY"/> bit set, the array is freed.
        /// </para>
        /// <para>
        /// If the variant to be cleared is a COM object that is passed by reference,
        /// the <see cref="VARIANT.vt"/> field of the pvargparameter is <c>VT_DISPATCH | VT_BYREF</c> or <c>VT_UNKNOWN | VT_BYREF</c>.
        /// In this case, <see cref="VariantClear"/> does not release the object.
        /// Because the variant being cleared is a pointer to a reference to an object,
        /// <see cref="VariantClear"/> has no way to determine if it is necessary to release the object.
        /// It is therefore the responsibility of the caller to release the object or not, as appropriate.
        /// </para>
        /// <para>
        /// In certain cases, it may be preferable to clear a variant in code without calling <see cref="VariantClear"/>.
        /// For example, you can change the type of a <see cref="VT_I4"/> variant to another type without calling this function.
        /// Safearrays of <see cref="BSTR"/> will have <see cref="SysFreeString"/> called on each element not <see cref="VariantClear"/>.
        /// However, you must call <see cref="VariantClear"/> if a VT_type is received but cannot be handled.
        /// Safearrays of variant will also have <see cref="VariantClear"/> called on each member.
        /// Using <see cref="VariantClear"/> in these cases ensures that code will continue to work if Automation adds new variant types in the future.
        /// </para>
        /// <para>
        /// Do not use <see cref="VariantClear"/> on uninitialized variants;
        /// use <see cref="VariantInit"/> to initialize a new VARIANTARG or <see cref="VARIANT"/>.
        /// </para>
        /// <para>
        /// Variants containing arrays with outstanding references cannot be cleared.
        /// Attempts to do so will return an <see cref="HRESULT"/> containing <see cref="DISP_E_ARRAYISLOCKED"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "VariantClear", ExactSpelling = true)]
        public static extern HRESULT VariantClear([In] in VARIANT pvarg);

        /// <summary>
        /// <para>
        /// Initializes a variant.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-variantinit"/>
        /// </para>
        /// </summary>
        /// <param name="pvarg">
        /// The variant to initialize.
        /// </param>
        /// <remarks>
        /// The <see cref="VariantInit"/> function initializes the <see cref="VARIANT"/> by
        /// setting the <see cref="VARIANT.vt"/> field to <see cref="VT_EMPTY"/>.
        /// Unlike <see cref="VariantClear"/>, this function does not interpret the current contents of the <see cref="VARIANT"/>.
        /// Use <see cref="VariantInit"/> to initialize new local variables of type <see cref="VARIANT"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "VariantInit", ExactSpelling = true)]
        public static extern void VariantInit([In] in VARIANT pvarg);

        /// <summary>
        /// <para>
        /// Converts the variant representation of a date and time to MS-DOS date and time values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varianttimetodosdatetime"/>
        /// </para>
        /// </summary>
        /// <param name="vtime">
        /// The variant time to convert.
        /// </param>
        /// <param name="pwDosDate">
        /// Receives the converted MS-DOS date.
        /// </param>
        /// <param name="pwDosTime">
        /// Receives the converted MS-DOS time
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> on success and <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A variant time is stored as an 8-byte real value (<see cref="double"/>), representing a date between January 1, 100 and December 31, 9999, inclusive.
        /// The value 2.0 represents January 1, 1900; 3.0 represents January 2, 1900, and so on.
        /// Adding 1 to the value increments the date by a day.
        /// The fractional part of the value represents the time of day.
        /// Therefore, 2.5 represents noon on January 1, 1900; 3.25 represents 6:00 A.M. on January 2, 1900, and so on.
        /// Negative numbers represent the dates prior to December 30, 1899.
        /// </para>
        /// <para>
        /// For a description of the MS-DOS date and time formats, see <see cref="DosDateTimeToVariantTime"/>.
        /// </para>
        /// <para>
        /// The <see cref="VariantTimeToDosDateTime"/> function will accept invalid dates and try to fix them when resolving to a <see cref="VARIANT"/> time.
        /// For example, an invalid date such as 2/29/2001 will resolve to 3/1/2001.
        /// Only days are fixed, so invalid month values result in an error being returned.
        /// Days are checked to be between 1 and 31.
        /// Negative days and days greater than 31 results in an error.
        /// A day less than 31 but greater than the maximum day in that month has the day promoted to the appropriate day of the next month.
        /// A day equal to zero resolves as the last day of the previous month.
        /// For example, an invalid dates such as 2/0/2001 will resolve to 1/31/2001.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "VariantTimeToDosDateTime", ExactSpelling = true)]
        public static extern INT VariantTimeToDosDateTime([In] DOUBLE vtime, [Out] out USHORT pwDosDate, [Out] out USHORT pwDosTime);
    }
}
