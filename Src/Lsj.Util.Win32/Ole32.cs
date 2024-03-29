﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.CLSID;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.BaseTypes.IID;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CLSCTX;
using static Lsj.Util.Win32.Enums.COINIT;
using static Lsj.Util.Win32.Enums.EOLE_AUTHENTICATION_CAPABILITIES;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.MSHCTX;
using static Lsj.Util.Win32.Enums.OLERENDER;
using static Lsj.Util.Win32.Enums.REGCLS;
using static Lsj.Util.Win32.Enums.RPC_C_AUTHN;
using static Lsj.Util.Win32.Enums.RPC_C_AUTHN_LEVEL;
using static Lsj.Util.Win32.Enums.RPC_C_AUTHZ;
using static Lsj.Util.Win32.Enums.RPC_C_IMP_LEVEL;
using static Lsj.Util.Win32.Enums.STGFMT;
using static Lsj.Util.Win32.Enums.STGM;
using static Lsj.Util.Win32.Enums.TYMED;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;
using IUnknown = Lsj.Util.Win32.ComInterfaces.IUnknown;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Ole32.dll
    /// </summary>
    public static class Ole32
    {
        /// <summary>
        /// CF_EMBEDSOURCE
        /// </summary>
        public const string CF_EMBEDSOURCE = "Embed Source";

        /// <summary>
        /// CF_EMBEDDEDOBJECT
        /// </summary>
        public const string CF_EMBEDDEDOBJECT = "Embedded Object";

        /// <summary>
        /// CF_FILENAME
        /// </summary>
        public const string CF_FILENAME = "FileName";

        /// <summary>
        /// COLE_DEFAULT_AUTHINFO
        /// </summary>
        public static readonly IntPtr COLE_DEFAULT_AUTHINFO = (IntPtr)(-1);

        /// <summary>
        /// COLE_DEFAULT_PRINCIPAL
        /// </summary>
        public static readonly StringHandle COLE_DEFAULT_PRINCIPAL = (IntPtr)(-1);


        /// <summary>
        /// <para>
        /// Locates an object by means of its moniker, activates the object if it is inactive,
        /// and retrieves a pointer to the specified interface on that object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-bindmoniker"/>
        /// </para>
        /// </summary>
        /// <param name="pmk">
        /// A pointer to the object's moniker. See <see cref="IMoniker"/>.
        /// </param>
        /// <param name="grfOpt">
        /// This parameter is reserved for future use and must be 0.
        /// </param>
        /// <param name="iidResult">
        /// The interface identifier to be used to communicate with the object.
        /// </param>
        /// <param name="ppvResult">
        /// The address of pointer variable that receives the interface pointer requested in <paramref name="iidResult"/>.
        /// Upon successful return, <paramref name="ppvResult"/> contains the requested interface pointer.
        /// If an error occurs, <paramref name="ppvResult"/> is <see langword="null"/>.
        /// If the call is successful, the caller is responsible for releasing the pointer with a call to the object's IUnknown::Release method.
        /// </param>
        /// <returns>
        /// This function can return the following error codes, or any of the error values returned by the <see cref="IMoniker.BindToObject"/> method.
        /// <see cref="S_OK"/>: The object was located and activated, if necessary, and a pointer to the requested interface was returned.
        /// <see cref="MK_E_NOOBJECT"/>: The object that the moniker object identified could not be found.
        /// </returns>
        /// <remarks>
        /// <see cref="BindMoniker"/> is a helper function supplied as a convenient way for a client that has the moniker of an object
        /// to obtain a pointer to one of that object's interfaces. <see cref="BindMoniker"/> packages the following calls:
        /// <code>
        /// CreateBindCtx(0, &amp;pbc); 
        /// pmk-&gt;BindToObject(pbc, NULL, riid, ppvObj);
        /// </code>
        /// <see cref="CreateBindCtx"/> creates a bind context object that supports the system implementation of <see cref="IBindCtx"/>.
        /// The <paramref name="pmk"/> parameter is actually a pointer to the <see cref="IMoniker"/> implementation on a moniker object
        /// This implementation's <see cref="IMoniker.BindToObject"/> method supplies the pointer to the requested interface pointer.
        /// If you have several monikers to bind in quick succession and if you know that those monikers will activate the same object,
        /// it may be more efficient to call the <see cref="IMoniker.BindToObject"/> method directly,
        /// which enables you to use the same bind context object for all the monikers.
        /// See the <see cref="IBindCtx"/> interface for more information.
        /// Container applications that allow their documents to contain linked objects are a special client
        /// that generally does not make direct calls to <see cref="IMoniker"/> methods.
        /// Instead, the client manipulates the linked objects through the <see cref="IOleLink"/> interface.
        /// The default handler implements this interface and calls the appropriate <see cref="IMoniker"/> methods as needed.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "BindMoniker", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT BindMoniker([In] IMoniker pmk, [In] DWORD grfOpt, [In] in Guid iidResult, [Out] out IUnknown ppvResult);

        /// <summary>
        /// <para>
        /// Looks up a <see cref="CLSID"/> in the registry, given a ProgID.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-clsidfromprogid"/>
        /// </para>
        /// </summary>
        /// <param name="lpszProgID">
        /// A pointer to the ProgID whose <see cref="CLSID"/> is requested.
        /// </param>
        /// <param name="lpclsid">
        /// Receives a pointer to the retrieved <see cref="CLSID"/> on return.
        /// </param>
        /// <returns>
        /// This function can return the following values.
        /// <see cref="S_OK"/>: The <see cref="CLSID"/> was retrieved successfully.
        /// <see cref="CO_E_CLASSSTRING"/>: The registered <see cref="CLSID"/> for the ProgID is invalid.
        /// <see cref="REGDB_E_WRITEREGDB"/>: An error occurred writing the <see cref="CLSID"/> to the registry. See Remarks below.
        /// </returns>
        /// <remarks>
        /// Given a ProgID, <see cref="CLSIDFromProgID"/> looks up its associated CLSID in the registry.
        /// If the ProgID cannot be found in the registry, <see cref="CLSIDFromProgID"/> creates an OLE 1 CLSID
        /// for the ProgID and a CLSID entry in the registry.
        /// Because of the restrictions placed on OLE 1 CLSID values, <see cref="CLSIDFromProgID"/> and <see cref="CLSIDFromString"/> are
        /// the only two functions that can be used to generate a CLSID for an OLE 1 object.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CLSIDFromProgID", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CLSIDFromProgID([In] string lpszProgID, [Out] out CLSID lpclsid);

        /// <summary>
        /// <para>
        /// Converts a string generated by the <see cref="StringFromCLSID"/> function back into the original CLSID.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-clsidfromstring"/>
        /// </para>
        /// </summary>
        /// <param name="lpsz">
        /// The string representation of the CLSID.
        /// </param>
        /// <param name="lpclsid">
        /// A pointer to the CLSID.
        /// </param>
        /// <returns>
        /// This function can return the following values.
        /// <see cref="S_OK"/>: The <see cref="CLSID"/> was retrieved successfully.
        /// <see cref="CO_E_CLASSSTRING"/>: The class string was improperly formatted.
        /// <see cref="REGDB_E_CLASSNOTREG"/>: The CLSID corresponding to the class string was not found in the registry.
        /// <see cref="REGDB_E_READREGDB"/>: The registry could not be opened for reading.
        /// </returns>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CLSIDFromString", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CLSIDFromString([In] string lpsz, [Out] out CLSID lpclsid);

        /// <summary>
        /// <para>
        /// Makes a private copy of the specified proxy.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cocopyproxy"/>
        /// </para>
        /// </summary>
        /// <param name="pProxy">
        /// A pointer to the <see cref="IUnknown"/> interface on the proxy to be copied.
        /// This parameter cannot be <see cref="NullRef{IUnknown}"/>.
        /// </param>
        /// <param name="ppCopy">
        /// Address of the pointer variable that receives the interface pointer to the copy of the proxy.
        /// This parameter cannot be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// This function can return the following values.
        /// <see cref="S_OK"/>: Indicates success.
        /// <see cref="E_INVALIDARG"/>: One or more arguments are invalid.
        /// </returns>
        /// <remarks>
        /// <see cref="CoCopyProxy"/> makes a private copy of the specified proxy.
        /// Typically, this function is called when a client needs to change the authentication information of its proxy
        /// through a call to either <see cref="CoSetProxyBlanket"/> or <see cref="IClientSecurity.SetBlanket"/> without changing this information for other clients.
        /// <see cref="CoSetProxyBlanket"/> affects all the users of an instance of a proxy, so creating a private copy of the proxy
        /// through a call to <see cref="CoCopyProxy"/> and then calling <see cref="CoSetProxyBlanket"/>
        /// (or <see cref="IClientSecurity.SetBlanket"/>) using the copy eliminates the problem.
        /// This helper function encapsulates the following sequence of common calls (error handling excluded):
        /// <code>
        /// pProxy->QueryInterface(IID_IClientSecurity, (void**)&amp;pcs);
        /// pcs->CopyProxy(punkProxy, ppunkCopy);
        /// pcs->Release();
        /// </code>
        /// Local interfaces may not be copied. <see cref="IUnknown"/> and <see cref="IClientSecurity"/> are examples of existing local interfaces.
        /// Copies of the same proxy have a special relationship with respect to <see cref="IUnknown.QueryInterface"/>.
        /// Given a proxy, a, of the IA interface of a remote object, suppose a copy of a is created, called b.
        /// In this case, calling <see cref="IUnknown.QueryInterface"/> from the b proxy for IID_IA will not retrieve the IA interface on b,
        /// but the one on a, the original proxy with the "default" security settings for the IA interface.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoCopyProxy", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoCopyProxy([In] in IUnknown pProxy, [Out] P<IUnknown> ppCopy);

        /// <summary>
        /// <para>
        /// Creates a GUID, a unique 128-bit integer used for CLSIDs and interface identifiers.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cocreateguid"/>
        /// </para>
        /// </summary>
        /// <param name="pguid">
        /// A pointer to the requested GUID.
        /// </param>
        /// <returns>
        /// <see cref="S_OK"/>: The GUID was successfully created.
        /// Errors returned by <see cref="UuidCreate"/> are wrapped as an <see cref="HRESULT"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CoCreateGuid"/> function calls the RPC function <see cref="UuidCreate"/>,
        /// which creates a GUID, a globally unique 128-bit integer.
        /// Use <see cref="CoCreateGuid"/> when you need an absolutely unique number
        /// that you will use as a persistent identifier in a distributed environment.
        /// To a very high degree of certainty, this function returns a unique value – no other invocation,
        /// on the same or any other system (networked or not), should return the same value.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoCreateGuid", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoCreateGuid([Out] out GUID pguid);

        /// <summary>
        /// <para>
        /// Creates a single uninitialized object of the class associated with a specified CLSID.
        /// Call <see cref="CoCreateInstance"/> when you want to create only one object on the local system.
        /// To create a single object on a remote system, call the <see cref="CoCreateInstanceEx"/> function.
        /// To create multiple objects based on a single CLSID, call the <see cref="CoGetClassObject"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cocreateinstance"/>
        /// </para>
        /// </summary>
        /// <param name="rclsid">
        /// The CLSID associated with the data and code that will be used to create the object.
        /// </param>
        /// <param name="pUnkOuter">
        /// If <see langword="null"/>, indicates that the object is not being created as part of an aggregate.
        /// If non-NULL, pointer to the aggregate object's IUnknown interface (the controlling IUnknown).
        /// </param>
        /// <param name="dwClsContext">
        /// Context in which the code that manages the newly created object will run.
        /// The values are taken from the enumeration <see cref="CLSCTX"/>.
        /// </param>
        /// <param name="riid">
        /// A reference to the identifier of the interface to be used to communicate with the object.
        /// </param>
        /// <param name="ppv">
        /// Address of pointer variable that receives the interface pointer requested in riid.
        /// Upon successful return, *ppv contains the requested interface pointer.
        /// Upon failure, *ppv contains <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This function can return the following values.
        /// <see cref="S_OK"/>: An instance of the specified object class was successfully created.
        /// <see cref="REGDB_E_CLASSNOTREG"/>:  A specified class is not registered in the registration database.
        /// Also can indicate that the type of server you requested in the <see cref="CLSCTX"/> enumeration is not registered
        /// or the values for the server types in the registry are corrupt.
        /// <see cref="CLASS_E_NOAGGREGATION"/>:
        /// This class cannot be created as part of an aggregate.
        /// <see cref="E_NOINTERFACE"/>:
        /// The specified class does not implement the requested interface, or the controlling IUnknown does not expose the requested interface.
        /// <see cref="E_POINTER"/>:
        /// The <paramref name="ppv"/> parameter is <see langword="null"/>.
        /// </returns>
        /// <remarks>
        /// The CoCreateInstance function provides a convenient shortcut by connecting to the class object associated with the specified CLSID,
        /// creating an uninitialized instance, and releasing the class object.
        /// As such, it encapsulates the following functionality:
        /// <code>
        /// CoGetClassObject(rclsid, dwClsContext, NULL, IID_IClassFactory, &amp;pCF); 
        /// hresult = pCF->CreateInstance(pUnkOuter, riid, ppvObj)
        /// pCF->Release();
        /// </code>
        /// It is convenient to use <see cref="CoCreateInstance"/> when you need to create only a single instance of an object on the local machine.
        /// If you are creating an instance on remote computer, call <see cref="CoCreateInstanceEx"/>.
        /// When you are creating multiple instances, it is more efficient to obtain a pointer to the class object's <see cref="IClassFactory"/> interface
        /// and use its methods as needed. In the latter case, you should use the <see cref="CoGetClassObject"/> function.
        /// In the <see cref="CLSCTX"/> enumeration, you can specify the type of server used to manage the object.
        /// The constants can be <see cref="CLSCTX_INPROC_SERVER"/>, <see cref="CLSCTX_INPROC_HANDLER"/>, <see cref="CLSCTX_LOCAL_SERVER"/>,
        /// <see cref="CLSCTX_REMOTE_SERVER"/> or any combination of these values.
        /// The constant <see cref="CLSCTX_ALL"/> is defined as the combination of all four.
        /// For more information about the use of one or a combination of these constants, see <see cref="CLSCTX"/>.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoCreateInstance", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoCreateInstance([In] in CLSID rclsid, [In] in IUnknown pUnkOuter,
            [In] CLSCTX dwClsContext, [In] in IID riid, [Out] out LPVOID ppv);

        /// <summary>
        /// <para>
        /// Creates an instance of a specific class on a specific computer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cocreateinstanceex"/>
        /// </para>
        /// </summary>
        /// <param name="Clsid">
        /// The CLSID of the object to be created.
        /// </param>
        /// <param name="punkOuter">
        /// If this parameter non-NULL, indicates the instance is being created as part of an aggregate,
        /// and <paramref name="punkOuter"/> is to be used as the new instance's controlling <see cref="IUnknown"/>.
        /// Aggregation is currently not supported cross-process or cross-computer.
        /// When instantiating an object out of process, <see cref="CLASS_E_NOAGGREGATION"/> will be returned if <paramref name="punkOuter"/> is non-NULL.
        /// </param>
        /// <param name="dwClsCtx">
        /// A value from the <see cref="CLSCTX"/> enumeration.
        /// </param>
        /// <param name="pServerInfo">
        /// Information about the computer on which to instantiate the object. See <see cref="COSERVERINFO"/>.
        /// This parameter can be <see cref="NULL"/>, in which case the object is instantiated on the local computer 
        /// or at the computer specified in the registry under the class's RemoteServerName value,
        /// according to the interpretation of the <paramref name="dwClsCtx"/> parameter.
        /// </param>
        /// <param name="dwCount">
        /// The number of structures in <paramref name="pResults"/>. This value must be greater than 0.
        /// </param>
        /// <param name="pResults">
        /// An array of <see cref="MULTI_QI"/> structures.
        /// Each structure has three members: the identifier for a requested interface (pIID), the location
        /// to return the interface pointer (pItf) and the return value of the call to QueryInterface (hr).
        /// </param>
        /// <returns>
        /// This function can return the standard return value <see cref="E_INVALIDARG"/>, as well as the following values.
        /// <see cref="S_OK"/>: Indicates success.
        /// <see cref="REGDB_E_CLASSNOTREG"/>:
        /// A specified class is not registered in the registration database.
        /// Also can indicate that the type of server you requested in the <see cref="CLSCTX"/> enumeration is not registered
        /// or the values for the server types in the registry are corrupt.
        /// <see cref="CLASS_E_NOAGGREGATION"/>: This class cannot be created as part of an aggregate.
        /// <see cref="CO_S_NOTALLINTERFACES"/>:
        /// At least one, but not all of the interfaces requested in the pResults array were successfully retrieved.
        /// The <see cref="MULTI_QI.hr"/> member of each of the <see cref="MULTI_QI"/> structures in <paramref name="pResults"/>
        /// indicates with <see cref="S_OK"/> or <see cref="E_NOINTERFACE"/> whether the specific interface was returned.
        /// <see cref="E_NOINTERFACE"/>: None of the interfaces requested in the <paramref name="pResults"/> array were successfully retrieved.
        /// </returns>
        /// <remarks>
        /// <see cref="CoCreateInstanceEx"/> creates a single uninitialized object associated with the given CLSID on a specified remote computer.
        /// This is an extension of the function <see cref="CoCreateInstance"/>, which creates an object on the local computer only.
        /// In addition, rather than requesting a single interface and obtaining a single pointer to that interface,
        /// <see cref="CoCreateInstanceEx"/> makes it possible to specify an array of structures, each pointing to an interface identifier (IID) on input,
        /// and, on return, containing (if available) a pointer to the requested interface and the return value of the QueryInterface call
        /// for that interface. This permits fewer round trips between computers.
        /// This function encapsulates three calls: first, to <see cref="CoGetClassObject"/> to connect to the class object
        /// associated with the specified CLSID, specifying the location of the class; second, to <see cref="IClassFactory.CreateInstance"/> to
        /// create an uninitialized instance, and finally, to Release, to release the class object.
        /// The object so created must still be initialized through a call
        /// to one of the initialization interfaces (such as <see cref="IPersistStorage.Load"/>).
        /// Two functions, <see cref="CoGetInstanceFromFile"/> and <see cref="CoGetInstanceFromIStorage"/> encapsulate
        /// both the instance creation and initialization from the obvious sources.
        /// The <see cref="COSERVERINFO"/> structure passed as the <paramref name="pServerInfo"/> parameter contains the security settings
        /// that COM will use when creating a new instance of the specified object.
        /// Note that this parameter does not influence the security settings used when making method calls on the instantiated object.
        /// Those security settings are configurable, on a per-interface basis, with the <see cref="CoSetProxyBlanket"/> function.
        /// Also see, <see cref="IClientSecurity.SetBlanket"/>.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoCreateInstanceEx", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoCreateInstanceEx([In] in CLSID Clsid, [In] in IUnknown punkOuter,
            [In] CLSCTX dwClsCtx, [In] in COSERVERINFO pServerInfo,
            [In] DWORD dwCount, [In][Out] MULTI_QI[] pResults);

        /// <summary>
        /// <para>
        /// Disconnects all remote process connections being maintained on behalf of all the interface pointers that point to a specified object.
        /// Only the process that actually manages the object should call <see cref="CoDisconnectObject"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-codisconnectobject"/>
        /// </para>
        /// </summary>
        /// <param name="pUnk">
        /// A pointer to any interface derived from <see cref="IUnknown"/> on the object to be disconnected.
        /// </param>
        /// <param name="dwReserved">
        /// This parameter is reserved and must be 0.
        /// </param>
        /// <returns>
        /// This function returns <see cref="S_OK"/> to indicate that all connections to remote processes were successfully deleted.
        /// </returns>
        /// <remarks>
        /// The <see cref="CoDisconnectObject"/> function enables a server to correctly disconnect
        /// all external clients to the object specified by <paramref name="pUnk"/>.
        /// It performs the following tasks:
        /// Checks to see whether the object to be disconnected implements the <see cref="IMarshal"/> interface.
        /// If so, it gets the pointer to that interface;
        /// if not, it gets a pointer to the standard marshaler's (i.e., COM's) <see cref="IMarshal"/> implementation.
        /// Using whichever <see cref="IMarshal"/> interface pointer it has acquired, the function
        /// then calls <see cref="IMarshal.DisconnectObject"/> to disconnect all out-of-process clients.
        /// An object's client does not call <see cref="CoDisconnectObject"/> to disconnect itself from the server
        /// (clients should use IUnknown::Release for this purpose).
        /// Rather, an OLE server calls <see cref="CoDisconnectObject"/> to forcibly disconnect an object's clients,
        /// usually in response to a user closing the server application.
        /// Similarly, an OLE container that supports external links to its embedded objects
        /// can call <see cref="CoDisconnectObject"/> to destroy those links.
        /// Again, this call is normally made in response to a user closing the application.
        /// The container should first call <see cref="IOleObject.Close"/> for all its OLE objects,
        /// each of which should send <see cref="IAdviseSink.OnClose"/> notifications to their various clients.
        /// Then the container can call <see cref="CoDisconnectObject"/> to close any existing connections.
        /// <see cref="CoDisconnectObject"/> does not necessarily disconnect out-of-process clients immediately.
        /// If any marshaled calls are pending on the server object, <see cref="CoDisconnectObject"/> disconnects the object
        /// only when those calls have returned.
        /// In the meantime, <see cref="CoDisconnectObject"/> sets a flag
        /// that causes any new marshaled calls to return <see cref="CO_E_OBJNOTCONNECTED"/>.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoDisconnectObject", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoDisconnectObject([MarshalAs(UnmanagedType.IUnknown)][In] object pUnk, [In] DWORD dwReserved);

        /// <summary>
        /// <para>
        /// Provides a pointer to an interface on a class object associated with a specified CLSID.
        /// <see cref="CoGetClassObject"/> locates, and if necessary, dynamically loads the executable code required to do this.
        /// Call <see cref="CoGetClassObject"/> directly to create multiple objects through a class object
        /// for which there is a CLSID in the system registry.
        /// You can also retrieve a class object from a specific remote computer.Most class objects implement the <see cref="IClassFactory"/> interface.
        /// You would then call <see cref="IClassFactory.CreateInstance"/> to create an uninitialized object.
        /// It is not always necessary to go through this process however.
        /// To create a single object, call the <see cref="CoCreateInstanceEx"/> function, which allows you to create an instance on a remote machine.
        /// This replaces the <see cref="CoCreateInstance"/> function, which can still be used to create an instance on a local computer.
        /// Both functions encapsulate connecting to the class object, creating the instance, and releasing the class object.
        /// Two other functions, <see cref="CoGetInstanceFromFile"/> and <see cref="CoGetInstanceFromIStorage"/>,
        /// provide both instance creation on a remote system and object activation.
        /// There are numerous functions and interface methods whose purpose is to create objects of a single type
        /// and provide a pointer to an interface on that object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cogetclassobject"/>
        /// </para>
        /// </summary>
        /// <param name="rclsid">
        /// The CLSID associated with the data and code that you will use to create the objects.
        /// </param>
        /// <param name="dwClsContext">
        /// The context in which the executable code is to be run.
        /// To enable a remote activation, include <see cref="CLSCTX_REMOTE_SERVER"/>.
        /// For more information on the context values and their use, see the <see cref="CLSCTX"/> enumeration.
        /// </param>
        /// <param name="pvReserved">
        /// A pointer to computer on which to instantiate the class object.
        /// If this parameter is <see cref="NULL"/>, the class object is instantiated on the current computer or
        /// at the computer specified under the class's RemoteServerName key,
        /// according to the interpretation of the <paramref name="dwClsContext"/> parameter.
        /// See <see cref="COSERVERINFO"/>.
        /// </param>
        /// <param name="riid">
        /// Reference to the identifier of the interface, which will be supplied in ppv on successful return.
        /// This interface will be used to communicate with the class object.
        /// Typically this value is <see cref="IID_IClassFactory"/>, although other values such as <see cref="IID_IClassFactory2"/>
        /// which supports a form of licensing are allowed.
        /// All OLE-defined interface IIDs are defined in the OLE header files as IID_interfacename,
        /// where interfacename is the name of the interface.
        /// </param>
        /// <param name="ppv">
        /// The address of pointer variable that receives the interface pointer requested in riid.
        /// Upon successful return, <paramref name="ppv"/> contains the requested interface pointer.
        /// </param>
        /// <returns>
        /// This function can return the following values.
        /// <see cref="S_OK"/>: Location and connection to the specified class object was successful.
        /// <see cref="REGDB_E_CLASSNOTREG"/>:
        /// The CLSID is not properly registered.
        /// This error can also indicate that the value you specified in <paramref name="dwClsContext"/> is not in the registry.
        /// <see cref="E_NOINTERFACE"/>:
        /// Either the object pointed to by <paramref name="ppv"/> does not support the interface identified by <paramref name="riid"/>,
        /// or the QueryInterface operation on the class object returned <see cref="E_NOINTERFACE"/>.
        /// <see cref="REGDB_E_READREGDB"/>: There was an error reading the registration database.
        /// <see cref="CO_E_DLLNOTFOUND"/>: Either the in-process DLL or handler DLL was not found (depending on the context).
        /// <see cref="CO_E_APPNOTFOUND"/>: The executable (.exe) was not found (<see cref="CLSCTX_LOCAL_SERVER"/> only).
        /// <see cref="E_ACCESSDENIED"/>: There was a general access failure on load.
        /// <see cref="CO_E_ERRORINDLL"/>: There is an error in the executable image.
        /// <see cref="CO_E_APPDIDNTREG"/>: The executable was launched, but it did not register the class object (and it may have shut down).
        /// </returns>
        /// <remarks>
        /// A class object in OLE is an intermediate object that supports an interface that permits operations common to a group of objects.
        /// The objects in this group are instances derived from the same object definition represented by a single CLSID.
        /// Usually, the interface implemented on a class object is <see cref="IClassFactory"/>,
        /// through which you can create object instances of a given definition (class).
        /// A call to <see cref="CoGetClassObject"/> creates, initializes, and gives the caller access
        /// (through a pointer to an interface specified with the riid parameter) to the class object.
        /// The class object is the one associated with the CLSID that you specify in the rclsid parameter.
        /// The details of how the system locates the associated code and data within a computer are transparent to the caller,
        /// as is the dynamic loading of any code that is not already loaded.
        /// If the class context is <see cref="CLSCTX_REMOTE_SERVER"/>, indicating remote activation is required,
        /// the <see cref="COSERVERINFO"/> structure provided in the pServerInfo parameter allows you
        /// to specify the computer on which the server is located.
        /// For information on the algorithm used to locate a remote server when pServerInfo is NULL, refer to the <see cref="CLSCTX"/> enumeration.
        /// The registry holds an association between CLSIDs and file suffixes, and between CLSIDs and file signatures
        /// for determining the class of an object.
        /// When an object is saved to persistent storage, its CLSID is stored with its data.
        /// To create and initialize embedded or linked OLE document objects, it is not necessary to call <see cref="CoGetClassObject"/> directly.
        /// Instead, call the <see cref="OleCreate"/> or OleCreateXXX function.
        /// These functions encapsulate the entire object instantiation and initialization process,
        /// and call, among other functions, <see cref="CoGetClassObject"/>.
        /// The <paramref name="riid"/> parameter specifies the interface the client will use to communicate with the class object.
        /// In most cases, this interface is <see cref="IClassFactory"/>.
        /// This provides access to the <see cref="IClassFactory.CreateInstance"/> method, through which the caller can then create an uninitialized object
        /// of the kind specified in its implementation.
        /// All classes registered in the system with a CLSID must implement <see cref="IClassFactory"/>.
        /// In rare cases, however, you may want to specify some other interface that defines operations common to a set of objects.
        /// For example, in the way OLE implements monikers, the interface on the class object is <see cref="IParseDisplayName"/>,
        /// used to transform the display name of an object into a moniker.
        /// The <paramref name="dwClsContext"/> parameter specifies the execution context,
        /// allowing one CLSID to be associated with different pieces of code in different execution contexts.
        /// The <see cref="CLSCTX"/> enumeration specifies the available context flags.
        /// <see cref="CoGetClassObject"/> consults (as appropriate for the context indicated) both the registry
        /// and the class objects that are currently registered by calling the <see cref="CoRegisterClassObject"/> function.
        /// To release a class object, use the class object's Release method.
        /// The function <see cref="CoRevokeClassObject"/> is to be used only to remove a class object's CLSID from the system registry.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoGetClassObject", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoGetClassObject([In] in CLSID rclsid, [In] CLSCTX dwClsContext, [In] LPVOID pvReserved,
            [In] in IID riid, [Out] out LPVOID ppv);

        /// <summary>
        /// <para>
        /// Creates a new object and initializes it from a file using <see cref="IPersistFile.Load"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cogetinstancefromfile"/>
        /// </para>
        /// </summary>
        /// <param name="pServerInfo">
        /// A pointer to a <see cref="COSERVERINFO"/> structure that specifies the computer
        /// on which to instantiate the object and the authentication setting to be used.
        /// This parameter can be <see cref="NULL"/>, in which case the object is instantiated on the current computer,
        /// at the computer specified under the RemoteServerName registry value for the class,
        /// or at the computer where the <paramref name="pwszName"/> file resides
        /// if the ActivateAtStorage value is specified for the class or there is no local registry information.
        /// </param>
        /// <param name="pClsid">
        /// A pointer to the class identifier of the object to be created.
        /// This parameter can be <see cref="NULL"/>, in which case there is a call to <see cref="GetClassFile"/>,
        /// using <paramref name="pwszName"/> as its parameter to get the class of the object to be instantiated.
        /// </param>
        /// <param name="punkOuter">
        /// When non-NULL, indicates the instance is being created as part of an aggregate,
        /// and <paramref name="punkOuter"/> is to be used as the pointer to the new instance's controlling <see cref="IUnknown"/>.
        /// Aggregation is not supported cross-process or cross-computer.
        /// When instantiating an object out of process, <see cref="CLASS_E_NOAGGREGATION"/>
        /// will be returned if <paramref name="punkOuter"/> is non-NULL.
        /// </param>
        /// <param name="dwClsCtx">
        /// Values from the <see cref="CLSCTX"/> enumeration.
        /// </param>
        /// <param name="grfMode">
        /// Specifies how the file is to be opened.
        /// See <see cref="STGM"/> Constants.
        /// </param>
        /// <param name="pwszName">
        /// The file used to initialize the object with <see cref="IPersistFile.Load"/>.
        /// This parameter cannot be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwCount">
        /// The number of structures in <paramref name="pResults"/>.
        /// This parameter must be greater than 0.
        /// </param>
        /// <param name="pResults">
        /// An array of <see cref="MULTI_QI"/> structures.
        /// Each structure has three members: the identifier for a requested interface (<see cref="MULTI_QI.pIID"/>),
        /// the location to return the interface pointer (<see cref="MULTI_QI.pItf"/>)
        /// and the return value of the call to QueryInterface (<see cref="MULTI_QI.hr"/>).
        /// </param>
        /// <returns>
        /// This function can return the standard return value <see cref="E_INVALIDARG"/>, as well as the following values.
        /// <see cref="S_OK"/>: The function retrieved all of the interfaces successfully.
        /// <see cref="CO_S_NOTALLINTERFACES"/>:
        /// At least one, but not all of the interfaces requested in the pResults array were successfully retrieved.
        /// The <see cref="MULTI_QI.hr"/> member of each of the <see cref="MULTI_QI"/> structures indicates
        /// with <see cref="S_OK"/> or <see cref="E_NOINTERFACE"/> whether the specific interface was returned. 
        /// <see cref="E_NOINTERFACE"/>:
        /// None of the interfaces requested in the <paramref name="pResults"/> array were successfully retrieved. 
        /// </returns>
        /// <remarks>
        /// <see cref="CoGetInstanceFromFile"/> creates a new object and initializes it from a file using <see cref="IPersistFile.Load"/>.
        /// The result of this function is similar to creating an instance with a call to <see cref="CoCreateInstanceEx"/>,
        /// followed by an initializing call to <see cref="IPersistFile.Load"/>, with the following important distinctions:
        /// Fewer network round trips are required by this function when instantiating an object on a remote computer.
        /// In the case where <paramref name="dwClsCtx"/> is set to <see cref="CLSCTX_REMOTE_SERVER"/>
        /// and <paramref name="pServerInfo"/> is <see cref="NULL"/>,
        /// if the class is registered with the ActivateAtStorage sub-key or has no associated registry information,
        /// this function will instantiate an object on the computer where <paramref name="pwszName"/> resides,
        /// providing the least possible network traffic.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoGetInstanceFromFile", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoGetInstanceFromFile([In] in COSERVERINFO pServerInfo, [MarshalAs(UnmanagedType.LPStruct)][In] Guid pClsid,
            [MarshalAs(UnmanagedType.IUnknown)][In] object punkOuter, [In] CLSCTX dwClsCtx, [In] STGM grfMode,
            [MarshalAs(UnmanagedType.LPWStr)][In] string pwszName, [In] DWORD dwCount, [Out] MULTI_QI[] pResults);

        /// <summary>
        /// <para>
        /// Creates a new object and initializes it from a storage object through an internal call to <see cref="IPersistFile.Load"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cogetinstancefromistorage"/>
        /// </para>
        /// </summary>
        /// <param name="pServerInfo">
        /// A pointer to a <see cref="COSERVERINFO"/> structure that specifies the computer on which to instantiate the object
        /// and the authentication setting to be used.
        /// This parameter can be <see cref="NULL"/>, in which case the object is instantiated on the current computer,
        /// at the computer specified under the RemoteServerName registry value for the class,
        /// or at the computer where the pstg storage object resides if the ActivateAtStorage value is specified for the class
        /// or there is no local registry information.
        /// </param>
        /// <param name="pClsid">
        /// A pointer to the class identifier of the object to be created.
        /// This parameter can be <see cref="NULL"/>, in which case there is a call to <see cref="IStorage.Stat"/> to find the class of the object.
        /// </param>
        /// <param name="punkOuter">
        /// When non-NULL, indicates the instance is being created as part of an aggregate,
        /// and <paramref name="punkOuter"/> is to be used as the pointer to the new instance's controlling <see cref="IUnknown"/>.
        /// Aggregation is not supported cross-process or cross-computer.
        /// When instantiating an object out of process, <see cref="CLASS_E_NOAGGREGATION"/> will be returned
        /// if <paramref name="punkOuter"/> is non-NULL.
        /// </param>
        /// <param name="dwClsCtx">
        /// Values from the <see cref="CLSCTX"/> enumeration.
        /// </param>
        /// <param name="pstg">
        /// A pointer to the storage object used to initialize the object with <see cref="IPersistFile.Load"/>.
        /// This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <param name="dwCount">
        /// The number of structures in <paramref name="pResults"/>.
        /// This parameter must be greater than 0.
        /// </param>
        /// <param name="pResults">
        /// An array of <see cref="MULTI_QI"/> structures.
        /// Each structure has three members: the identifier for a requested interface (<see cref="MULTI_QI.pIID"/>),
        /// the location to return the interface pointer (<see cref="MULTI_QI.pItf"/>)
        /// and the return value of the call to QueryInterface (<see cref="MULTI_QI.hr"/>).
        /// </param>
        /// <returns>
        /// This function can return the standard return value <see cref="E_INVALIDARG"/>, as well as the following values.
        /// <see cref="S_OK"/>: The function retrieved all of the interfaces successfully.
        /// <see cref="CO_S_NOTALLINTERFACES"/>:
        /// At least one, but not all of the interfaces requested in the pResults array were successfully retrieved.
        /// The <see cref="MULTI_QI.hr"/> member of each of the <see cref="MULTI_QI"/> structures indicates
        /// with <see cref="S_OK"/> or <see cref="E_NOINTERFACE"/> whether the specific interface was returned. 
        /// <see cref="E_NOINTERFACE"/>:
        /// None of the interfaces requested in the <paramref name="pResults"/> array were successfully retrieved. 
        /// </returns>
        /// <remarks>
        /// <see cref="CoGetInstanceFromIStorage"/> creates a new object and initializes it
        /// from a storage object using <see cref="IPersistFile.Load"/>.
        /// The result of this function is similar to creating an instance with a call to <see cref="CoCreateInstanceEx"/>,
        /// followed by an initializing call to <see cref="IPersistFile.Load"/>, with the following important distinctions:
        /// Fewer network round trips are required by this function when instantiating an object on a remote computer.
        /// In the case where <paramref name="dwClsCtx"/> is set to <see cref="CLSCTX_REMOTE_SERVER"/>
        /// and <paramref name="pServerInfo"/> is <see cref="NullRef{COSERVERINFO}"/>, 
        /// if the class is registered with the ActivateAtStorage value or has no associated registry information,
        /// this function will instantiate an object on the computer where pstg resides, providing the least possible network traffic.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoGetInstanceFromIStorage", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoGetInstanceFromIStorage([In] in COSERVERINFO pServerInfo, [MarshalAs(UnmanagedType.LPStruct)][In] Guid pClsid,
              [MarshalAs(UnmanagedType.IUnknown)][In] object punkOuter, [In] CLSCTX dwClsCtx, [In] IStorage pstg, [In] DWORD dwCount,
              [Out] MULTI_QI[] pResults);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the default OLE task memory allocator (which supports the system implementation of the <see cref="IMalloc"/> interface)
        /// so applications can call its methods to manage memory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cogetmalloc"/>
        /// </para>
        /// </summary>
        /// <param name="dwMemContext">
        /// This parameter must be 1.
        /// </param>
        /// <param name="ppMalloc">
        /// The address of an IMalloc* pointer variable that receives the interface pointer to the memory allocator.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="S_OK"/>, <see cref="E_INVALIDARG"/>, and <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// The pointer to the IMalloc interface pointer received through the <paramref name="ppMalloc"/> parameter cannot be used from a remote process;
        /// each process must have its own allocator.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoGetMalloc", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoGetMalloc([In] DWORD dwMemContext, [MarshalAs(UnmanagedType.Interface)][Out] out IMalloc ppMalloc);

        /// <summary>
        /// <para>
        /// Returns an upper bound on the number of bytes needed to marshal the specified interface pointer to the specified object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cogetmarshalsizemax"/>
        /// </para>
        /// </summary>
        /// <param name="pulSize">
        /// A pointer to the upper-bound value on the size, in bytes, of the data packet to be written to the marshaling stream.
        /// If this parameter is 0, the size of the packet is unknown.
        /// </param>
        /// <param name="riid">
        /// A reference to the identifier of the interface whose pointer is to be marshaled.
        /// This interface must be derived from the <see cref="IUnknown"/> interface.
        /// </param>
        /// <param name="pUnk">
        /// A pointer to the interface to be marshaled.
        /// This interface must be derived from the <see cref="IUnknown"/> interface.
        /// </param>
        /// <param name="dwDestContext">
        /// The destination context where the specified interface is to be unmarshaled.
        /// Values for <paramref name="dwDestContext"/> come from the enumeration <see cref="MSHCTX"/>.
        /// </param>
        /// <param name="pvDestContext">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="mshlflags">
        /// Indicates whether the data to be marshaled is to be transmitted back to the client processthe normal case or written to a global table,
        /// where it can be retrieved by multiple clients.
        /// Values come from the enumeration <see cref="MSHLFLAGS"/>.
        /// </param>
        /// <returns>
        /// This function can return the standard return value <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The upper bound was returned successfully.
        /// <see cref="CO_E_NOTINITIALIZED"/>:
        /// Before this function can be called, either the <see cref="CoInitialize"/> or <see cref="OleInitialize"/> function must be called. 
        /// </returns>
        /// <remarks>
        /// This function performs the following tasks:
        /// Queries the object for an <see cref="IMarshal"/> pointer or,
        /// if the object does not implement <see cref="IMarshal"/>, gets a pointer to COM's standard marshaler.
        /// Using the pointer obtained in the preceding item, calls <see cref="IMarshal.GetMarshalSizeMax"/>.
        /// Adds to the value returned by the call to <see cref="IMarshal.GetMarshalSizeMax"/> the size of the marshaling data header and, possibly,
        /// that of the proxy CLSID to obtain the maximum size in bytes of the amount of data to be written to the marshaling stream.
        /// You do not explicitly call this function unless you are implementing <see cref="IMarshal"/>,
        /// in which case your marshaling stub should call this function to get the correct size of the data packet to be marshaled.
        /// The value returned by this method is guaranteed to be valid only as long
        /// as the internal state of the object being marshaled does not change.
        /// Therefore, the actual marshaling should be done immediately after this function returns,
        /// or the stub runs the risk that the object, because of some change in state,
        /// might require more memory to marshal than it originally indicated.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoGetMarshalSizeMax", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoGetMarshalSizeMax([Out] out ULONG pulSize, [In] in IID riid, [In] in object pUnk,
            [In] MSHCTX dwDestContext, [In] LPVOID pvDestContext, [In] in MSHLFLAGS mshlflags);

        /// <summary>
        /// <para>
        /// Creates an item moniker that identifies an object within a containing object (typically a compound document).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-createitemmoniker"/>
        /// </para>
        /// </summary>
        /// <param name="lpszDelim">
        /// A pointer to a wide character string (two bytes per character) zero-terminated string
        /// containing the delimiter (typically "!") used to separate this item's display name from the display name of its containing object.
        /// </param>
        /// <param name="lpszItem">
        /// A pointer to a zero-terminated string indicating the containing object's name for the object being identified.
        /// This name can later be used to retrieve a pointer to the object in a call to <see cref="IOleItemContainer.GetObject"/>.
        /// </param>
        /// <param name="ppmk">
        /// The address of an <see cref="IMoniker"/>* pointer variable that receives the interface pointer to the item moniker.
        /// When successful, the function has called <see cref="ComInterfaces.IUnknown.AddRef"/> on the item moniker
        /// and the caller is responsible for calling <see cref="ComInterfaces.IUnknown.Release"/>.
        /// If an error occurs, the supplied interface pointer has a <see cref="NULL"/> value.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// A moniker provider, which hands out monikers to identify its objects so they are accessible to other parties,
        /// would call <see cref="CreateItemMoniker"/> to identify its objects with item monikers.
        /// Item monikers are based on a string, and identify objects that are contained within another object and can be individually identified using a string.
        /// The containing object must also implement the <see cref="IOleContainer"/> interface.
        /// Most moniker providers are OLE applications that support linking.
        /// Applications that support linking to objects smaller than file-based documents,
        /// such as a server application that allows linking to a selection within a document, should use item monikers to identify the objects.
        /// Container applications that allow linking to embedded objects use item monikers to identify the embedded objects.
        /// The <paramref name="lpszItem"/> parameter is the name used by the document to uniquely identify the object.
        /// For example, if the object being identified is a cell range in a spreadsheet, an appropriate name might be something like "A1:E7."
        /// An appropriate name when the object being identified is an embedded object might be something like "embedobj1."
        /// The containing object must provide an implementation of the <see cref="IOleItemContainer"/> interface
        /// that can interpret this name and locate the corresponding object.
        /// This allows the item moniker to be bound to the object it identifies.
        /// Item monikers are not used in isolation. They must be composed with a moniker that identifies the containing object as well.
        /// For example, if the object being identified is a cell range contained in a file-based document,
        /// the item moniker identifying that object must be composed with the file moniker identifying that document,
        /// resulting in a composite moniker that is the equivalent of "C:\work\sales.xls!A1:E7."
        /// Nested containers are allowed also, as in the case where an object is contained within an embedded object inside another document.
        /// The complete moniker of such an object would be the equivalent of "C:\work\report.doc!embedobj1!A1:E7."
        /// In this case, each containing object must call <see cref="CreateItemMoniker"/> and provide its own implementation of the <see cref="IOleItemContainer"/> interface.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateItemMoniker", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CreateItemMoniker([In] LPCOLESTR lpszDelim, [In] LPCOLESTR lpszItem, [Out] out LP<IMoniker> ppmk);

        /// <summary>
        /// <para>
        /// Creates a default, or standard, marshaling object in either the client process or the server process,
        /// depending on the caller, and returns a pointer to that object's <see cref="IMarshal"/> implementation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cogetstandardmarshal"/>
        /// </para>
        /// </summary>
        /// <param name="riid">
        /// A reference to the identifier of the interface whose pointer is to be marshaled.
        /// This interface must be derived from the <see cref="IUnknown"/> interface.
        /// </param>
        /// <param name="pUnk">
        /// A pointer to the interface to be marshaled.
        /// </param>
        /// <param name="dwDestContext">
        /// The destination context where the specified interface is to be unmarshaled.
        /// Values come from the enumeration <see cref="MSHCTX"/>.
        /// Unmarshaling can occur either in another apartment of the current process (<see cref="MSHCTX_INPROC"/>)
        /// or in another process on the same computer as the current process (<see cref="MSHCTX_LOCAL"/>).
        /// </param>
        /// <param name="pvDestContext">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="mshlflags">
        /// Indicates whether the data to be marshaled is to be transmitted back to the client process (the normal case)
        /// or written to a global table where it can be retrieved by multiple clients.
        /// Values come from the <see cref="MSHLFLAGS"/> enumeration.
        /// </param>
        /// <param name="ppMarshal">
        /// The address of <see cref="IMarshal"/> pointer variable that receives the interface pointer to the standard marshaler.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_FAIL"/>, <see cref="E_OUTOFMEMORY"/>,
        /// and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The <see cref="IMarshal"/> instance was returned successfully.
        /// <see cref="CO_E_NOTINITIALIZED"/>:
        /// Before this function can be called, the <see cref="CoInitialize"/>
        /// or <see cref="OleInitialize"/> function must be called on the current thread. 
        /// </returns>
        /// <remarks>
        /// The <see cref="CoGetStandardMarshal"/> function creates a default, or standard, marshaling object
        /// in either the client process or the server process, as may be necessary, and returns that object's IMarshal pointer to the caller.
        /// If you implement <see cref="IMarshal"/>, you may want your implementation to call <see cref="CoGetStandardMarshal"/>
        /// as a way of delegating to COM's default implementation any destination contexts that you do not fully understand or want to handle.
        /// Otherwise, you can ignore this function, which COM calls as part of its internal marshaling procedures.
        /// When the COM library in the client process receives a marshaled interface pointer,
        /// it looks for a CLSID to be used in creating a proxy for the purposes of unmarshaling the packet.
        /// If the packet does not contain a CLSID for the proxy, COM calls <see cref="CoGetStandardMarshal"/>,
        /// passing a <see cref="NULL"/> <paramref name="pUnk"/> value.
        /// This function creates a standard proxy in the client process and returns a pointer to that proxy's implementation of <see cref="IMarshal"/>.
        /// COM uses this pointer to call <see cref="CoUnmarshalInterface"/> to retrieve the pointer to the requested interface.
        /// If your OLE server application's implementation of <see cref="IMarshal"/> calls <see cref="CoGetStandardMarshal"/>,
        /// you should pass both the IID of (<paramref name="riid"/>), and a pointer to (<paramref name="pUnk"/>), the interface being requested.
        /// This function performs the following tasks:
        /// Determines whether <paramref name="pUnk"/> is <see cref="NULL"/>.
        /// If <paramref name="pUnk"/> is <see cref="NULL"/>, creates a standard interface proxy
        /// in the client process for the specified <paramref name="riid"/> and returns the proxy's <see cref="IMarshal"/> pointer.
        /// If <paramref name="pUnk"/> is not <see cref="NULL"/>, checks to see if a marshaler for the object already exists,
        /// creates a new one if necessary, and returns the marshaler's <see cref="IMarshal"/> pointer.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoGetStandardMarshal", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoGetStandardMarshal([In] in IID riid, [In] in object pUnk, [In] MSHCTX dwDestContext,
            [In] LPVOID pvDestContext, [In] MSHLFLAGS mshlflags, [Out] out IMarshal ppMarshal);

        /// <summary>
        /// <para>
        /// Initializes the COM library on the current thread and identifies the concurrency model as single-thread apartment (STA).
        /// New applications should call <see cref="CoInitializeEx"/> instead of <see cref="CoInitialize"/>.
        /// If you want to use the Windows Runtime, you must call Windows::Foundation::Initialize instead.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-coinitialize"/>
        /// </para>
        /// </summary>
        /// <param name="pvReserved">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_INVALIDARG"/>, <see cref="E_OUTOFMEMORY"/>,
        /// and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The COM library was initialized successfully on this thread.
        /// <see cref="S_FALSE"/>: The COM library is already initialized on this thread.
        /// <see cref="RPC_E_CHANGED_MODE"/>:
        /// A previous call to <see cref="CoInitializeEx"/> specified the concurrency model for this thread as multithread apartment (MTA).
        /// This could also indicate that a change from neutral-threaded apartment to single-threaded apartment has occurred.
        /// </returns>
        /// <remarks>
        /// You need to initialize the COM library on a thread before you call any of the library functions except <see cref="CoGetMalloc"/>,
        /// to get a pointer to the standard allocator, and the memory allocation functions.
        /// After the concurrency model for a thread is set, it cannot be changed.
        /// A call to <see cref="CoInitialize"/> on an apartment that was previously initialized as multithreaded will fail
        /// and return <see cref="RPC_E_CHANGED_MODE"/>.
        /// <see cref="CoInitializeEx"/> provides the same functionality as <see cref="CoInitialize"/> and also provides a parameter
        /// to explicitly specify the thread's concurrency model.
        /// <see cref="CoInitialize"/> calls <see cref="CoInitializeEx"/> and specifies the concurrency model as single-thread apartment.
        /// Applications developed today should call <see cref="CoInitializeEx"/> rather than <see cref="CoInitialize"/>.
        /// Typically, the COM library is initialized on a thread only once.
        /// Subsequent calls to <see cref="CoInitialize"/> or <see cref="CoInitializeEx"/> on the same thread will succeed,
        /// as long as they do not attempt to change the concurrency model, but will return <see cref="S_FALSE"/>.
        /// To close the COM library gracefully, each successful call to <see cref="CoInitialize"/> or <see cref="CoInitializeEx"/>,
        /// including those that return <see cref="S_FALSE"/>, must be balanced by a corresponding call to <see cref="CoUninitialize"/>.
        /// However, the first thread in the application that calls <see cref="CoInitialize"/> with 0
        /// (or <see cref="CoInitializeEx"/> with <see cref="COINIT_APARTMENTTHREADED"/>) must be the last thread to call <see cref="CoUninitialize"/>.
        /// Otherwise, subsequent calls to <see cref="CoInitialize"/> on the STA will fail and the application will not work.
        /// Because there is no way to control the order in which in-process servers are loaded or unloaded,
        /// do not call <see cref="CoInitialize"/>, <see cref="CoInitializeEx"/>, or <see cref="CoUninitialize"/> from the DllMain function.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoInitialize", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoInitialize([In] LPVOID pvReserved);

        /// <summary>
        /// <para>
        /// Initializes the COM library for use by the calling thread, sets the thread's concurrency model,
        /// and creates a new apartment for the thread if one is required.
        /// You should call Windows::Foundation::Initialize to initialize the thread instead of <see cref="CoInitializeEx"/>
        /// if you want to use the Windows Runtime APIs or if you want to use both COM and Windows Runtime components.
        /// Windows::Foundation::Initialize is sufficient to use for COM components.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-coinitializeex"/>
        /// </para>
        /// </summary>
        /// <param name="pvReserved">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwCoInit">
        /// The concurrency model and initialization options for the thread.
        /// Values for this parameter are taken from the <see cref="COINIT"/> enumeration.
        /// Any combination of values from <see cref="COINIT"/> can be used,
        /// except that the <see cref="COINIT_APARTMENTTHREADED"/> and <see cref="COINIT_MULTITHREADED"/> flags cannot both be set.
        /// The default is <see cref="COINIT_MULTITHREADED"/>.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_INVALIDARG"/>, <see cref="E_OUTOFMEMORY"/>,
        /// and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The COM library was initialized successfully on this thread.
        /// <see cref="S_FALSE"/>: The COM library is already initialized on this thread.
        /// <see cref="RPC_E_CHANGED_MODE"/>:
        /// A previous call to <see cref="CoInitializeEx"/> specified the concurrency model for this thread as multithread apartment (MTA).
        /// This could also indicate that a change from neutral-threaded apartment to single-threaded apartment has occurred.
        /// </returns>
        /// <remarks>
        /// <see cref="CoInitializeEx"/> must be called at least once, and is usually called only once, for each thread that uses the COM library.
        /// Multiple calls to <see cref="CoInitializeEx"/> by the same thread are allowed as long as they pass the same concurrency flag,
        /// but subsequent valid calls return <see cref="S_FALSE"/>.
        /// To close the COM library gracefully on a thread, each successful call to <see cref="CoInitialize"/> or <see cref="CoInitializeEx"/>,
        /// including any call that returns <see cref="S_FALSE"/>, must be balanced by a corresponding call to <see cref="CoUninitialize"/>.
        /// You need to initialize the COM library on a thread before you call any of the library functions except <see cref="CoGetMalloc"/>,
        /// to get a pointer to the standard allocator, and the memory allocation functions.
        /// Otherwise, the COM function will return <see cref="CO_E_NOTINITIALIZED"/>.
        /// After the concurrency model for a thread is set, it cannot be changed.
        /// A call to <see cref="CoInitialize"/> on an apartment that was previously initialized as multithreaded
        /// will fail and return <see cref="RPC_E_CHANGED_MODE"/>.
        /// Objects created in a single-threaded apartment (STA) receive method calls only from their apartment's thread,
        /// so calls are serialized and arrive only at message-queue boundaries
        /// (when the <see cref="PeekMessage"/> or <see cref="SendMessage"/> function is called).
        /// Objects created on a COM thread in a multithread apartment (MTA) must be able to receive method calls from other threads at any time.
        /// You would typically implement some form of concurrency control in a multithreaded object's code
        /// using synchronization primitives such as critical sections, semaphores, or mutexes to help protect the object's data.
        /// When an object that is configured to run in the neutral threaded apartment (NTA) is called
        /// by a thread that is in either an STA or the MTA, that thread transfers to the NTA.
        /// If this thread subsequently calls <see cref="CoInitializeEx"/>, the call fails and returns <see cref="RPC_E_CHANGED_MODE"/>.
        /// Because OLE technologies are not thread-safe, the <see cref="OleInitialize"/> function
        /// calls <see cref="CoInitializeEx"/> with the <see cref="COINIT_APARTMENTTHREADED"/> flag.
        /// As a result, an apartment that is initialized for multithreaded object concurrency cannot use the features enabled by <see cref="OleInitialize"/>.
        /// Because there is no way to control the order in which in-process servers are loaded or unloaded,
        /// do not call <see cref="CoInitialize"/>, <see cref="CoInitializeEx"/>, or <see cref="CoUninitialize"/> from the DllMain function.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoInitializeEx", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoInitializeEx([In] LPVOID pvReserved, [In] COINIT dwCoInit);

        /// <summary>
        /// <para>
        /// Registers security and sets the default security values for the process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-coinitializesecurity"/>
        /// </para>
        /// </summary>
        /// <param name="pSecDesc">
        /// The access permissions that a server will use to receive calls.
        /// This parameter is used by COM only when a server calls <see cref="CoInitializeSecurity"/>.
        /// Its value is a pointer to one of three types: an AppID, an <see cref="IAccessControl"/> object,
        /// or a <see cref="SECURITY_DESCRIPTOR"/>, in absolute format. See the Remarks section for more information.
        /// </param>
        /// <param name="cAuthSvc">
        /// The count of entries in the <paramref name="asAuthSvc"/> parameter.
        /// This parameter is used by COM only when a server calls <see cref="CoInitializeSecurity"/>.
        /// If this parameter is 0, no authentication services will be registered and the server cannot receive secure calls.
        /// A value of -1 tells COM to choose which authentication services to register, and if this is the case, 
        /// the <paramref name="asAuthSvc"/> parameter must be <see langword="null"/>.
        /// However, Schannel will never be chosen as an authentication service by the server if this parameter is -1.
        /// </param>
        /// <param name="asAuthSvc">
        /// An array of authentication services that a server is willing to use to receive a call.
        /// This parameter is used by COM only when a server calls <see cref="CoInitializeSecurity"/>.
        /// For more information, see <see cref="SOLE_AUTHENTICATION_SERVICE"/>.
        /// </param>
        /// <param name="pReserved1">
        /// This parameter is reserved and must be NULL.
        /// </param>
        /// <param name="dwAuthnLevel">
        /// The default authentication level for the process.
        /// Both servers and clients use this parameter when they call <see cref="CoInitializeSecurity"/>.
        /// COM will fail calls that arrive with a lower authentication level.
        /// By default, all proxies will use at least this authentication level.
        /// This value should contain one of the authentication level constants.
        /// By default, all calls to <see cref="IUnknown"/> are made at this level.
        /// </param>
        /// <param name="dwImpLevel">
        /// The default impersonation level for proxies.
        /// The value of this parameter is used only when the process is a client.
        /// It should be a value from the impersonation level constants, except for <see cref="RPC_C_IMP_LEVEL_DEFAULT"/>,
        /// which is not for use with <see cref="CoInitializeSecurity"/>.
        /// Outgoing calls from the client always use the impersonation level as specified. (It is not negotiated.)
        /// Incoming calls to the client can be at any impersonation level.
        /// By default, all IUnknown calls are made with this impersonation level, so even security-aware applications should set this level carefully.
        /// To determine which impersonation levels each authentication service supports,
        /// see the description of the authentication services in COM and Security Packages.
        /// For more information about impersonation levels, see Impersonation.
        /// </param>
        /// <param name="pAuthList">
        /// A pointer to <see cref="SOLE_AUTHENTICATION_LIST"/>, which is an array of <see cref="SOLE_AUTHENTICATION_INFO"/> structures.
        /// This list indicates the information for each authentication service that a client can use to call a server.
        /// This parameter is used by COM only when a client calls <see cref="CoInitializeSecurity"/>.
        /// </param>
        /// <param name="dwCapabilities">
        /// Additional capabilities of the client or server, specified by setting one or more <see cref="EOLE_AUTHENTICATION_CAPABILITIES"/> values.
        /// Some of these value cannot be used simultaneously, and some cannot be set when particular authentication services are being used.
        /// For more information about these flags, see the Remarks section.
        /// </param>
        /// <param name="pReserved3">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// This function can return the standard return value <see cref="E_INVALIDARG"/>, as well as the following values.
        /// Return code	Description
        /// <see cref="S_OK"/>: Indicates success.
        /// <see cref="RPC_E_TOO_LATE"/>: <see cref="CoInitializeSecurity"/> has already been called.
        /// <see cref="RPC_E_NO_GOOD_SECURITY_PACKAGES"/>:
        /// The <paramref name="asAuthSvc"/> parameter was not <see langword="null"/>, and none of the authentication services in the list could be registered.
        /// Check the results saved in <paramref name="asAuthSvc"/> for authentication service–specific error codes.
        /// <see cref="E_OUTOFMEMORY"/>: Out of memory.
        /// </returns>
        /// <remarks>
        /// The <see cref="CoInitializeSecurity"/> function initializes the security layer and sets the specified values as the security default.
        /// If a process does not call <see cref="CoInitializeSecurity"/>, COM calls it automatically the first time an interface is marshaled or unmarshaled,
        /// registering the system default security.
        /// No default security packages are registered until then.
        /// This function is called exactly once per process, either explicitly or implicitly.
        /// It can be called by the client, server, or both.
        /// For legacy applications and other applications that do not explicitly call <see cref="CoInitializeSecurity"/>,
        /// COM calls this function implicitly with values from the registry.
        /// If you set processwide security using the registry and then call <see cref="CoInitializeSecurity"/>,
        /// the AppID registry values will be ignored and the <see cref="CoInitializeSecurity"/> values will be used.
        /// <see cref="CoInitializeSecurity"/> can be used to override both computer-wide access permissions and application-specific access permissions,
        /// but not to override the computer-wide restriction policy.
        /// If <paramref name="pSecDesc"/> points to an AppID, the <see cref="EOAC_APPID"/> flag
        /// must be set in <paramref name="dwCapabilities"/> and, when the <see cref="EOAC_APPID"/> flag is set,
        /// all other parameters to <see cref="CoInitializeSecurity"/> are ignored.
        /// <see cref="CoInitializeSecurity"/> looks for the authentication level under the AppID key in the registry
        /// and uses it to determine the default security.
        /// For more information about how the AppID key is used to set security, see Setting Process-Wide Security Through the Registry.
        /// If <paramref name="pSecDesc"/> is a pointer to an <see cref="IAccessControl"/> object,
        /// the <see cref="EOAC_ACCESS_CONTROL"/> flag must be set and <paramref name="dwAuthnLevel"/> cannot be none.
        /// The <see cref="IAccessControl"/> object is used to determine who can call the process.
        /// DCOM will AddRef the <see cref="IAccessControl"/> and will Release it when <see cref="CoUninitialize"/> is called.
        /// The state of the <see cref="IAccessControl"/> object should not be changed.
        /// If <paramref name="pSecDesc"/> is a pointer to a <see cref="SECURITY_DESCRIPTOR"/>,
        /// neither the <see cref="EOAC_APPID"/> nor the <see cref="EOAC_ACCESS_CONTROL"/> flag can be set in <paramref name="dwCapabilities"/>.
        /// The owner and group of the <see cref="SECURITY_DESCRIPTOR"/> must be set,
        /// and until DCOM supports auditing, the system ACL must be NULL.
        /// The access-control entries (ACEs) in the discretionary ACL (DACL) of the <see cref="SECURITY_DESCRIPTOR"/> are used to find out
        /// which callers are permitted to connect to the process's objects.
        /// A DACL with no ACEs allows no access, while a NULL DACL will allow calls from anyone.
        /// For more information on ACLs and ACEs, see Access Control Model.
        /// Applications should call <see cref="AccessCheck"/> (not <see cref="IsValidSecurityDescriptor"/>) to
        /// ensure that their <see cref="SECURITY_DESCRIPTOR"/> is correctly formed prior to calling <see cref="CoInitializeSecurity"/>.
        /// Passing <paramref name="pSecDesc"/> as <see langword="null"/> is strongly discouraged.
        /// An appropriate alternative might be to use a <see cref="SECURITY_DESCRIPTOR"/> that allows Everyone.
        /// If <paramref name="pSecDesc"/> is <see langword="null"/>, the flags in <paramref name="dwCapabilities"/> determine
        /// how <see cref="CoInitializeSecurity"/> defines the access permissions that a server will use, as follows:
        /// If the <see cref="EOAC_APPID"/> flag is set, <see cref="CoInitializeSecurity"/> will look up the application's .exe name in the registry
        /// and use the AppID stored there.
        /// If the <see cref="EOAC_ACCESS_CONTROL"/> flag is set, <see cref="CoInitializeSecurity"/> will return an error.
        /// If neither the <see cref="EOAC_APPID"/> flag nor the <see cref="EOAC_ACCESS_CONTROL"/> flag is set,
        /// <see cref="CoInitializeSecurity"/> allows all callers including Local and Remote Anonymous Users.
        /// The <see cref="CoInitializeSecurity"/> function returns an error
        /// if both the <see cref="EOAC_APPID"/> and <see cref="EOAC_ACCESS_CONTROL"/> flags are set in <paramref name="dwCapabilities"/>.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoInitializeSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoInitializeSecurity([In] in SECURITY_DESCRIPTOR pSecDesc, [In] LONG cAuthSvc, [In] SOLE_AUTHENTICATION_SERVICE[] asAuthSvc,
            [In] IntPtr pReserved1, [In] DWORD dwAuthnLevel, [In] DWORD dwImpLevel, [In] IntPtr pAuthList, [In] DWORD dwCapabilities, [In] IntPtr pReserved3);

        /// <summary>
        /// <para>
        /// Called either to lock an object to ensure that it stays in memory, or to release such a lock.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-colockobjectexternal"/>
        /// </para>
        /// </summary>
        /// <param name="pUnk">
        /// A pointer to the <see cref="IUnknown"/> interface on the object to be locked or unlocked.
        /// </param>
        /// <param name="fLock">
        /// Indicates whether the object is to be locked or released.
        /// If this parameter is <see cref="TRUE"/>, the object is kept in memory,
        /// independent of <see cref="ComInterfaces.IUnknown.AddRef"/>/<see cref="ComInterfaces.IUnknown.Release"/> operations, registrations, or revocations.
        /// If this parameter is <see cref="FALSE"/>, the lock previously set with a call to this function is released.
        /// </param>
        /// <param name="fLastUnlockReleases">
        /// If the lock is the last reference that is supposed to keep an object alive,
        /// specify <see cref="TRUE"/> to release all pointers to the object (there may be other references that are not supposed to keep it alive).
        /// Otherwise, specify <see cref="FALSE"/>.
        /// If <paramref name="fLock"/> is <see cref="TRUE"/>, this parameter is ignored.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_INVALIDARG"/>,
        /// <see cref="E_OUTOFMEMORY"/>, <see cref="E_UNEXPECTED"/>, and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CoLockObjectExternal"/> function must be called in the process
        /// in which the object actually resides (the EXE process, not the process in which handlers may be loaded).
        /// The <see cref="CoLockObjectExternal"/> function prevents the reference count of an object from going to zero,
        /// thereby "locking" it into existence until the lock is released.
        /// The same function (with different parameters) releases the lock.
        /// The lock is implemented by having the system call <see cref="ComInterfaces.IUnknown.AddRef"/>:: on the object.
        /// The system then waits to call <see cref="ComInterfaces.IUnknown.Release"/> on the object until a later call
        /// to <see cref="CoLockObjectExternal"/> with <paramref name="fLock"/> set to <see cref="FALSE"/>.
        /// This function can be used to maintain a reference count on the object on behalf of the end user, because it acts outside of the object, as does the user.
        /// The end user has explicit control over the lifetime of an application, even if there are external locks on it.
        /// That is, if a user decides to close the application, it must shut down.
        /// In the presence of external locks (such as the lock set by <see cref="CoLockObjectExternal"/>),
        /// the application can call the <see cref="CoDisconnectObject"/> function to force these connections to close prior to shutdown.
        /// Calling <see cref="CoLockObjectExternal"/> sets a strong lock on an object.
        /// A strong lock keeps an object in memory, while a weak lock does not.
        /// Strong locks are required, for example, during a silent update to an OLE embedding.
        /// The embedded object's container must remain in memory until the update process is complete.
        /// There must also be a strong lock on an application object to ensure that the application stays alive until it has finished providing services to its clients.
        /// All external references place a strong reference lock on an object.
        /// The <see cref="CoLockObjectExternal"/> function is typically called in the following situations:
        /// Object servers should call <see cref="CoLockObjectExternal"/> with
        /// both <paramref name="fLock"/> and <paramref name="fLastUnlockReleases"/> set to <see cref="TRUE"/> when they become visible.
        /// This call creates a strong lock on behalf of the user.
        /// When the application is closing, free the lock with a call to <see cref="CoLockObjectExternal"/>,
        /// setting <paramref name="fLock"/> to <see cref="FALSE"/> and <paramref name="fLastUnlockReleases"/> to <see cref="TRUE"/>
        /// A call to <see cref="CoLockObjectExternal"/> on the server can also be used in the implementation of <see cref="IOleContainer.LockContainer"/>.
        /// There are several things to be aware of when you use <see cref="CoLockObjectExternal"/> in the implementation of <see cref="IOleContainer.LockContainer"/>.
        /// An embedded object would call see cref="IOleContainer.LockContainer"/> on its container to
        /// keep it running (to lock it) in the absence of other reasons to keep it running.
        /// When the embedded object becomes visible, the container must weaken its connection to the embedded object
        /// with a call to the <see cref="OleSetContainedObject"/> function, so other connections can affect the object.
        /// Unless an application manages all aspects of its application and document shutdown completely with calls to <see cref="CoLockObjectExternal"/>,
        /// the container must keep a private lock count in <see cref="IOleContainer.LockContainer"/>
        /// so that it exits when the lock count reaches zero and the container is invisible.
        /// Maintaining all aspects of shutdown, and thereby avoiding keeping a private lock count,
        /// means that <see cref="CoLockObjectExternal"/> should be called whenever one of the following conditions occur:
        /// A document is created and destroyed or made visible or invisible.
        /// An application is started and shut down by the user.
        /// A pseudo-object is created and destroyed.
        /// For debugging purposes, it may be useful to keep a count of the number of external locks (and unlocks) set on the application.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoLockObjectExternal", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoLockObjectExternal([In] in LP<IUnknown> pUnk, [In] BOOL fLock, [In] BOOL fLastUnlockReleases);

        /// <summary>
        /// <para>
        /// Writes into a stream the data required to initialize a proxy object in some client process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-comarshalinterface"/>
        /// </para>
        /// </summary>
        /// <param name="pStm">
        /// A pointer to the stream to be used during marshaling.
        /// See <see cref="IStream"/>.
        /// </param>
        /// <param name="riid">
        /// A reference to the identifier of the interface to be marshaled.
        /// This interface must be derived from the <see cref="IUnknown"/> interface.
        /// </param>
        /// <param name="pUnk">
        /// A pointer to the interface to be marshaled.
        /// This interface must be derived from the <see cref="IUnknown"/> interface.
        /// </param>
        /// <param name="dwDestContext">
        /// The destination context where the specified interface is to be unmarshaled.
        /// The possible values come from the enumeration <see cref="MSHCTX"/>.
        /// Currently, unmarshaling can occur in another apartment of the current process (<see cref="MSHCTX_INPROC"/>),
        /// in another process on the same computer as the current process (<see cref="MSHCTX_LOCAL"/>),
        /// or in a process on a different computer (<see cref="MSHCTX_DIFFERENTMACHINE"/>).
        /// </param>
        /// <param name="pvDestContext">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="mshlflags">
        /// The flags that specify whether the data to be marshaled is to be transmitted back
        /// to the client process (the typical case) or written to a global table, where it can be retrieved by multiple clients.
        /// The possibles values come from the <see cref="MSHLFLAGS"/> enumeration.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_FAIL"/>, <see cref="E_OUTOFMEMORY"/>,
        /// and <see cref="E_UNEXPECTED"/>, the stream-access error values returned by <see cref="IStream"/>, as well as the following values.
        /// <see cref="S_OK"/>: The <see cref="HRESULT"/> was marshaled successfully.
        /// <see cref="CO_E_NOTINITIALIZED"/>:
        /// The <see cref="CoInitialize"/> or <see cref="OleInitialize"/> function was not called on the current thread before this function was called. 
        /// </returns>
        /// <remarks>
        /// The <see cref="CoMarshalInterface"/> function marshals the interface referred to by <paramref name="riid"/> on the object
        /// whose <see cref="IUnknown"/> implementation is pointed to by <paramref name="pUnk"/>.
        /// To do so, the <see cref="CoMarshalInterface"/> function performs the following tasks:
        /// Queries the object for a pointer to the <see cref="IMarshal"/> interface.
        /// If the object does not implement <see cref="IMarshal"/>, meaning that it relies on COM to provide marshaling support,
        /// <see cref="CoMarshalInterface"/> gets a pointer to COM's default implementation of IMarshal.
        /// Gets the CLSID of the object's proxy by calling <see cref="IMarshal.GetUnmarshalClass"/>,
        /// using whichever <see cref="IMarshal"/> interface pointer has been returned.
        /// Writes the CLSID of the proxy to the stream to be used for marshaling.
        /// Marshals the interface pointer by calling <see cref="IMarshal.MarshalInterface"/>.
        /// The COM library in the client process calls the <see cref="CoUnmarshalInterface"/> function to extract the data and initialize the proxy.
        /// Before calling <see cref="CoUnmarshalInterface"/>, seek back to the original position in the stream.
        /// If you are implementing existing COM interfaces or defining your own interfaces using the Microsoft Interface Definition Language (MIDL),
        /// the MIDL-generated proxies and stubs call <see cref="CoMarshalInterface"/> for you.
        /// If you are writing your own proxies and stubs, your proxy code and stub code
        /// should each call <see cref="CoMarshalInterface"/> to correctly marshal interface pointers.
        /// Calling <see cref="IMarshal"/> directly from your proxy and stub code is not recommended.
        /// If you are writing your own implementation of <see cref="IMarshal"/>, and your proxy needs access to a private object,
        /// you can include an interface pointer to that object as part of the data you write to the stream.
        /// In such situations, if you want to use COM's default marshaling implementation when passing the interface pointer,
        /// you can call <see cref="CoMarshalInterface"/> on the object to do so.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoMarshalInterface", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoMarshalInterface([In] in IStream pStm, [In] in IID riid, [In] object pUnk,
            [In] DWORD dwDestContext, [In] LPVOID pvDestContext, [In] DWORD mshlflags);

        /// <summary>
        /// <para>
        /// Retrieves the authentication information the client uses to make calls on the specified proxy.
        /// This is a helper function for <see cref="IClientSecurity.QueryBlanket"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-coqueryproxyblanket"/>
        /// </para>
        /// </summary>
        /// <param name="pProxy">
        /// A pointer indicating the proxy to query.
        /// This parameter cannot be <see langword="null"/>.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="pwAuthnSvc">
        /// A pointer to a variable that receives the current authentication service.
        /// This will be a single value taken from the authentication service constants.
        /// This parameter cannot be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="pAuthzSvc">
        /// A pointer to a variable that receives the current authorization service.
        /// This will be a single value taken from the authorization constants.
        /// If the caller specifies <see cref="NullRef{DWORD}"/>, the current authorization service is not retrieved.
        /// </param>
        /// <param name="pServerPrincName">
        /// The current principal name.
        /// The string will be allocated by the callee using <see cref="CoTaskMemAlloc"/>, and must be freed by the caller using <see cref="CoTaskMemFree"/>.
        /// The <see cref="EOAC_MAKE_FULLSIC"/> flag is not accepted in the <paramref name="pCapabilites"/> parameter.
        /// For more information about the msstd and fullsic forms, see Principal Names.
        /// If the caller specifies <see cref="NullRef{String}"/>, the current principal name is not retrieved.
        /// </param>
        /// <param name="pAuthnLevel">
        /// A pointer to a variable that receives the current authentication level.
        /// This will be a single value taken from the authentication level constants.
        /// If the caller specifies <see cref="NullRef{DWORD}"/>, the current authentication level is not retrieved.
        /// </param>
        /// <param name="pImpLevel">
        /// A pointer to a variable that receives the current impersonation level.
        /// This will be a single value taken from the impersonation level constants.
        /// If the caller specifies <see cref="NullRef{DWORD}"/>, the current impersonation level is not retrieved.
        /// </param>
        /// <param name="pAuthInfo">
        /// A pointer to a handle that receives the identity of the client that was passed
        /// to the last <see cref="IClientSecurity.SetBlanket"/> call (or the default value).
        /// Default values are only valid until the proxy is released.
        /// If the caller specifies <see cref="NullRef{RPC_AUTH_IDENTITY_HANDLE}"/>, the client identity is not retrieved.
        /// The format of the structure that the handle refers to depends on the authentication service.
        /// The application should not write or free the memory.
        /// For NTLMSSP and Kerberos, if the client specified a structure in the <paramref name="pAuthInfo"/> parameter
        /// to <see cref="CoInitializeSecurity"/>, that value is returned.
        /// For Schannel, if a certificate for the client could be retrieved from the certificate manager, that value is returned here.
        /// Otherwise, <see cref="NULL"/> is returned. See <see cref="RPC_AUTH_IDENTITY_HANDLE"/>.
        /// </param>
        /// <param name="pCapabilites">
        /// A pointer to a variable that receives the capabilities of the proxy.
        /// If the caller specifies <see cref="NULL"/>, the current capability flags are not retrieved.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_INVALIDARG"/>, <see cref="E_OUTOFMEMORY"/>, and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="CoQueryProxyBlanket"/> is called by the client to retrieve the authentication information
        /// COM will use on calls made from the specified proxy.
        /// This function encapsulates the following sequence of common calls (error handling excluded):
        /// <code>
        /// pProxy->QueryInterface(IID_IClientSecurity, (void**)&amp;pcs);
        /// pcs->QueryBlanket(pProxy, pAuthnSvc, pAuthzSvc, pServerPrincName, pAuthnLevel, pImpLevel, ppAuthInfo, pCapabilities);
        /// pcs->Release();
        /// </code>
        /// This sequence calls QueryInterface on the proxy to get a pointer to <see cref="IClientSecurity"/>, and with the resulting pointer,
        /// calls <see cref="IClientSecurity.QueryBlanket"/> and then releases the pointer.
        /// In <paramref name="pProxy"/>, you can pass any proxy, such as a proxy you get through a call to <see cref="CoCreateInstance"/>
        /// or <see cref="CoUnmarshalInterface"/>, or you can pass an interface pointer.
        /// It can be any interface.
        /// You cannot pass a pointer to something that is not a proxy.
        /// Therefore, you can't pass a pointer to an interface that has the local keyword in its interface definition
        /// because no proxy is created for such an interface.
        /// <see cref="IUnknown"/> is the exception to this rule.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoQueryProxyBlanket", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoQueryProxyBlanket([MarshalAs(UnmanagedType.IUnknown)][In] object pProxy, [Out] out DWORD pwAuthnSvc,
            [Out] out DWORD pAuthzSvc, [Out] out string pServerPrincName, [Out] out DWORD pAuthnLevel, [Out] out DWORD pImpLevel,
            [Out] out RPC_AUTH_IDENTITY_HANDLE pAuthInfo, [Out] out EOLE_AUTHENTICATION_CAPABILITIES pCapabilites);

        /// <summary>
        /// <para>
        /// Registers an EXE class object with OLE so other applications can connect to it.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-coregisterclassobject"/>
        /// </para>
        /// </summary>
        /// <param name="rclsid">
        /// The CLSID to be registered.
        /// </param>
        /// <param name="pUnk">
        /// A pointer to the <see cref="IUnknown"/> interface on the class object whose availability is being published.
        /// </param>
        /// <param name="dwClsContext">
        /// The context in which the executable code is to be run.
        /// For information on these context values, see the <see cref="CLSCTX"/> enumeration.
        /// </param>
        /// <param name="flags">
        /// Indicates how connections are made to the class object. For information on these flags, see the <see cref="REGCLS"/> enumeration.
        /// </param>
        /// <param name="lpdwRegister">
        /// A pointer to a value that identifies the class object registered;
        /// later used by the <see cref="CoRevokeClassObject"/> function to revoke the registration.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_INVALIDARG"/>, <see cref="E_OUTOFMEMORY"/>,
        /// and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The class object was registered successfully. 
        /// </returns>
        /// <remarks>
        /// EXE object applications should call <see cref="CoRegisterClassObject"/> on startup.
        /// It can also be used to register internal objects for use by the same EXE or other code (such as DLLs) that the EXE uses.
        /// Only EXE object applications call <see cref="CoRegisterClassObject"/>.
        /// Object handlers or DLL object applications do not call this function — instead,
        /// they must implement and export the DllGetClassObject function.
        /// At startup, a multiple-use EXE object application must create a class object (with the <see cref="IClassFactory"/> interface on it),
        /// and call <see cref="CoRegisterClassObject"/> to register the class object.
        /// Object applications that support several different classes (such as multiple types of embeddable objects)
        /// must allocate and register a different class object for each.
        /// Multiple registrations of the same class object are independent and do not produce an error.
        /// Each subsequent registration yields a unique key in <paramref name="lpdwRegister"/>.
        /// Multiple document interface (MDI) applications must register their class objects.
        /// Single document interface (SDI) applications must register their class objects only if they can be started by means of the /Embedding switch.
        /// The server for a class object should call <see cref="CoRevokeClassObject"/> to revoke the class object
        /// (remove its registration) when all of the following are true:
        /// There are no existing instances of the object definition.
        /// There are no locks on the class object.
        /// The application providing services to the class object is not under user control (not visible to the user on the display).
        /// After the class object is revoked, when its reference count reaches zero, the class object can be released, allowing the application to exit.
        /// Note that <see cref="CoRegisterClassObject"/> calls IUnknown::AddRef and <see cref="CoRevokeClassObject"/> calls IUnknown::Release,
        /// so the two functions form an AddRef/Release pair.
        /// As of Windows Server 2003, if a COM object application is registered as a service, COM verifies the registration.
        /// COM makes sure the process ID of the service, in the service control manager (SCM), matches the process ID of the registering process.
        /// If not, COM fails the registration.
        /// If the COM object application runs in the system account with no registry key, COM treats the objects application identity as Launching User.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoRegisterClassObject", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoRegisterClassObject([In] in Guid rclsid, [MarshalAs(UnmanagedType.IUnknown)][In] object pUnk,
            [In] DWORD dwClsContext, [In] REGCLS flags, [Out] out DWORD lpdwRegister);

        /// <summary>
        /// <para>
        /// Destroys a previously marshaled data packet.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-coreleasemarshaldata"/>
        /// </para>
        /// </summary>
        /// <param name="pStm">
        /// A pointer to the stream that contains the data packet to be destroyed. See <see cref="IStream"/>.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_FAIL"/>, <see cref="E_INVALIDARG"/>,
        /// <see cref="E_OUTOFMEMORY"/>, and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The data packet was successfully destroyed.
        /// <see cref="STG_E_INVALIDPOINTER"/>: An error related to the <paramref name="pStm"/> parameter.
        /// <see cref="CO_E_NOTINITIALIZED"/>:
        /// The <see cref="CoInitialize"/> or <see cref="OleInitialize"/> function was not called on the current thread before this function was called. 
        /// </returns>
        /// <remarks>
        /// Important  
        /// Security Note: Calling this method with untrusted data is a security risk.
        /// Call this method only with trusted data. For more information, see Untrusted Data Security Risks.
        /// The <see cref="CoReleaseMarshalData"/> function performs the following tasks:
        /// The function reads a CLSID from the stream.
        /// If COM's default marshaling implementation is being used,
        /// the function gets an <see cref="IMarshal"/> pointer to an instance of the standard unmarshaler.
        /// If custom marshaling is being used, the function creates a proxy by calling the <see cref="CoCreateInstance"/> function,
        /// passing the CLSID it read from the stream, and requests an <see cref="IMarshal"/> interface pointer to the newly created proxy.
        /// Using whichever <see cref="IMarshal"/> interface pointer it has acquired, the function calls <see cref="IMarshal.ReleaseMarshalData"/>.
        /// You typically do not call this function.
        /// The only situation in which you might need to call this function is if you use custom marshaling
        /// (write and use your own implementation of <see cref="IMarshal"/>).
        /// Examples of when <see cref="CoReleaseMarshalData"/> should be called include the following situations:
        /// An attempt was made to unmarshal the data packet, but it failed.
        /// A marshaled data packet was removed from a global table.
        /// As an analogy, the data packet can be thought of as a reference to the original object,
        /// just as if it were another interface pointer being held on the object.
        /// Like a real interface pointer, that data packet must be released at some point.
        /// The use of <see cref="IMarshal.ReleaseMarshalData"/> to release data packets
        /// is analogous to the use of IUnknown::Release to release interface pointers.
        /// Note that you do not need to call <see cref="CoReleaseMarshalData"/> after a successful call
        /// of the <see cref="CoUnmarshalInterface"/> function; that function releases the marshal data as part of the processing that it does.
        /// Important You must call the <see cref="CoReleaseMarshalData"/> function in the same apartment
        /// that called <see cref="CoMarshalInterface"/> to marshal the object into the stream.
        /// Failure to do this may cause the object reference held by the marshaled packet in the stream to be leaked.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoReleaseMarshalData", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoReleaseMarshalData([In] IStream pStm);

        /// <summary>
        /// <para>
        /// Called by a server that can register multiple class objects to inform the SCM about all registered classes,
        /// and permits activation requests for those class objects.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-coresumeclassobjects"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// This function returns <see cref="S_OK"/> to indicate that the CLSID was retrieved successfully.
        /// </returns>
        /// <remarks>
        /// Servers that can register multiple class objects call <see cref="CoResumeClassObjects"/> once,
        /// after having first called <see cref="CoRegisterClassObject"/>,
        /// specifying <code>REGCLS_LOCAL_SERVER | REGCLS_SUSPENDED</code> for each CLSID the server supports.
        /// This function causes OLE to inform the SCM about all the registered classes, and begins letting activation requests into the server process.
        /// This reduces the overall registration time, and thus the server application startup time,
        /// by making a single call to the SCM, no matter how many CLSIDs are registered for the server.
        /// Another advantage is that if the server has multiple apartments with different CLSIDs registered in different apartments,
        /// or is a free-threaded server, no activation requests will come in until the server calls <see cref="CoResumeClassObjects"/>.
        /// This gives the server a chance to register all of its CLSIDs and get properly set up
        /// before having to deal with activation requests, and possibly shutdown requests.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoResumeClassObjects", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoResumeClassObjects();

        /// <summary>
        /// <para>
        /// Informs OLE that a class object, previously registered with the <see cref="CoRegisterClassObject"/> function, is no longer available for use.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-corevokeclassobject"/>
        /// </para>
        /// </summary>
        /// <param name="dwRegister">
        /// A token previously returned from the <see cref="CoRegisterClassObject"/> function.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_INVALIDARG"/>, <see cref="E_OUTOFMEMORY"/>,
        /// and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The class object was revoked successfully. 
        /// </returns>
        /// <remarks>
        /// A successful call to <see cref="CoRevokeClassObject"/> means that the class object has been removed
        /// from the global class object table (although it does not release the class object).
        /// If other clients still have pointers to the class object and have caused the reference count to be incremented
        /// by calls to IUnknown::AddRef, the reference count will not be zero.
        /// When this occurs, applications may benefit if subsequent calls (with the obvious exceptions of AddRef and IUnknown::Release) to the class object fail.
        /// Note that <see cref="CoRegisterClassObject"/> calls AddRef and <see cref="CoRevokeClassObject"/> calls Release,
        /// so the two functions form an AddRef/Release pair.
        /// An object application must call <see cref="CoRevokeClassObject"/> to revoke registered class objects before exiting the program.
        /// Class object implementers should call <see cref="CoRevokeClassObject"/> as part of the release sequence.
        /// You must specifically revoke the class object even when you have specified the flags value <see cref="REGCLS_SINGLEUSE"/>
        /// in a call to <see cref="CoRegisterClassObject"/>, indicating that only one application can connect to the class object.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoRevokeClassObject", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoRevokeClassObject([In] DWORD dwRegister);

        /// <summary>
        /// <para>
        /// Sets the authentication information that will be used to make calls on the specified proxy.
        /// This is a helper function for <see cref="IClientSecurity.SetBlanket"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cosetproxyblanket"/>
        /// </para>
        /// </summary>
        /// <param name="pProxy">
        /// The proxy to be set.
        /// </param>
        /// <param name="dwAuthnSvc">
        /// The authentication service to be used.
        /// For a list of possible values, see Authentication Service Constants.
        /// Use <see cref="RPC_C_AUTHN_NONE"/> if no authentication is required.
        /// If <see cref="RPC_C_AUTHN_DEFAULT"/> is specified, DCOM will pick an authentication service
        /// following its normal security blanket negotiation algorithm.
        /// </param>
        /// <param name="dwAuthzSvc">
        /// The authorization service to be used. For a list of possible values, see Authorization Constants.
        /// If <see cref="RPC_C_AUTHZ_DEFAULT"/> is specified, DCOM will pick an authorization service
        /// following its normal security blanket negotiation algorithm.
        /// <see cref="RPC_C_AUTHZ_NONE"/> should be used as the authorization service if NTLMSSP,
        /// Kerberos, or Schannel is used as the authentication service.
        /// </param>
        /// <param name="pServerPrincName">
        /// The server principal name to be used with the authentication service.
        /// If <see cref="COLE_DEFAULT_PRINCIPAL"/> is specified, DCOM will pick a principal name using its security blanket negotiation algorithm.
        /// If Kerberos is used as the authentication service, this value must not be <see langword="null"/>.
        /// It must be the correct principal name of the server or the call will fail.
        /// If Schannel is used as the authentication service, this value must be one of the msstd or fullsic forms described in Principal Names,
        /// or <see langword="null"/> if you do not want mutual authentication.
        /// Generally, specifying <see langword="null"/> will not reset the server principal name on the proxy;
        /// rather, the previous setting will be retained.
        /// You must be careful when using <see langword="null"/> as <paramref name="pServerPrincName"/>
        /// when selecting a different authentication service for the proxy,
        /// because there is no guarantee that the previously set principal name would be valid for the newly selected authentication service.
        /// </param>
        /// <param name="dwAuthnLevel">
        /// The authentication level to be used.
        /// For a list of possible values, see Authentication Level Constants.
        /// If <see cref="RPC_C_AUTHN_LEVEL_DEFAULT"/> is specified, DCOM will pick an authentication level
        /// following its normal security blanket negotiation algorithm.
        /// If this value is none, the authentication service must also be none.
        /// </param>
        /// <param name="dwImpLevel">
        /// The impersonation level to be used.
        /// For a list of possible values, see Impersonation Level Constants.
        /// If <see cref="RPC_C_IMP_LEVEL_DEFAULT"/> is specified, DCOM will pick an impersonation level
        /// following its normal security blanket negotiation algorithm.
        /// If NTLMSSP is the authentication service, this value must be <see cref="RPC_C_IMP_LEVEL_IMPERSONATE"/>
        /// or <see cref="RPC_C_IMP_LEVEL_IDENTIFY"/>.
        /// NTLMSSP also supports delegate-level impersonation (<see cref="RPC_C_IMP_LEVEL_DELEGATE"/>) on the same computer.
        /// If Schannel is the authentication service, this parameter must be <see cref="RPC_C_IMP_LEVEL_IMPERSONATE"/>.
        /// </param>
        /// <param name="pAuthInfo">
        /// A pointer to an <see cref="RPC_AUTH_IDENTITY_HANDLE"/> value that establishes the identity of the client.
        /// The format of the structure referred to by the handle depends on the provider of the authentication service.
        /// For calls on the same computer, RPC logs on the user with the supplied credentials and uses the resulting token for the method call.
        /// For NTLMSSP or Kerberos, the structure is a <see cref="SEC_WINNT_AUTH_IDENTITY"/> or <see cref="SEC_WINNT_AUTH_IDENTITY_EX"/> structure.
        /// The client can discard pAuthInfo after calling the API.
        /// RPC does not keep a copy of the <paramref name="pAuthInfo"/> pointer,
        /// and the client cannot retrieve it later in the <see cref="CoQueryProxyBlanket"/> method.
        /// If this parameter is <see cref="NULL"/>, DCOM uses the current proxy identity (which is either the process token or the impersonation token).
        /// If the handle refers to a structure, that identity is used.
        /// For Schannel, this parameter must be either a pointer to a <see cref="CERT_CONTEXT"/> structure
        /// that contains the client's X.509 certificate or is <see cref="NULL"/> if the client wishes to make an anonymous connection to the server.
        /// If a certificate is specified, the caller must not free it as long as any proxy to the object exists in the current apartment.
        /// For Snego, this member is either <see cref="NULL"/>, points to a <see cref="SEC_WINNT_AUTH_IDENTITY"/> structure,
        /// or points to a <see cref="SEC_WINNT_AUTH_IDENTITY_EX"/> structure.
        /// If it is <see cref="NULL"/>, Snego will pick a list of authentication services based on those available on the client computer.
        /// If it points to a <see cref="SEC_WINNT_AUTH_IDENTITY_EX"/> structure,
        /// the structure's <see cref="SEC_WINNT_AUTH_IDENTITY_EX.PackageList"/> member must point to a string
        /// containing a comma-separated list of authentication service names and the <see cref="SEC_WINNT_AUTH_IDENTITY_EX.PackageListLength"/> member
        /// must give the number of bytes in the <see cref="SEC_WINNT_AUTH_IDENTITY_EX.PackageList"/> string.
        /// If <see cref="SEC_WINNT_AUTH_IDENTITY_EX.PackageList"/> is <see cref="NULL"/>, all calls using Snego will fail.
        /// If <see cref="COLE_DEFAULT_AUTHINFO"/> is specified for this parameter,
        /// DCOM will pick the authentication information following its normal security blanket negotiation algorithm.
        /// <see cref="CoSetProxyBlanket"/> will fail if <paramref name="pAuthInfo"/> is set and one of the cloaking flags
        /// is set in the <paramref name="dwCapabilities"/> parameter.
        /// </param>
        /// <param name="dwCapabilities">
        /// The capabilities of this proxy.
        /// For a list of possible values, see the <see cref="EOLE_AUTHENTICATION_CAPABILITIES"/> enumeration.
        /// The only flags that can be set through this function are <see cref="EOAC_MUTUAL_AUTH"/>, <see cref="EOAC_STATIC_CLOAKING"/>,
        /// <see cref="EOAC_DYNAMIC_CLOAKING"/>, <see cref="EOAC_ANY_AUTHORITY"/> (this flag is deprecated),
        /// <see cref="EOAC_MAKE_FULLSIC"/>, and <see cref="EOAC_DEFAULT"/>.
        /// Either <see cref="EOAC_STATIC_CLOAKING"/> or <see cref="EOAC_DYNAMIC_CLOAKING"/> can be set
        /// if <paramref name="pAuthInfo"/> is not set and Schannel is not the authentication service. (See Cloaking for more information.)
        /// If any capability flags other than those mentioned here are set, <see cref="CoSetProxyBlanket"/> will fail.
        /// </param>
        /// <returns>
        /// This function can return the following values.
        /// <see cref="S_OK"/>: The function was successful.
        /// <see cref="E_INVALIDARG"/>: One or more arguments is invalid.
        /// </returns>
        /// <remarks>
        /// <see cref="CoSetProxyBlanket"/> sets the authentication information that will be used to make calls on the specified proxy.
        /// This function encapsulates the following sequence of common calls (error handling excluded).
        /// <code>
        /// pProxy->QueryInterface(IID_IClientSecurity, (void**)&amp;pcs);
        /// pcs->SetBlanket(pProxy, dwAuthnSvc, dwAuthzSvc, pServerPrincName, dwAuthnLevel, dwImpLevel, pAuthInfo, dwCapabilities);
        /// pcs->Release();
        /// </code>
        /// This sequence calls QueryInterface on the proxy to get a pointer to <see cref="IClientSecurity"/>, and with the resulting pointer,
        /// calls <see cref="IClientSecurity.SetBlanket"/> and then releases the pointer.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoSetProxyBlanket", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoSetProxyBlanket([MarshalAs(UnmanagedType.IUnknown)][In] object pProxy, [In] DWORD dwAuthnSvc,
            [In] DWORD dwAuthzSvc, [MarshalAs(UnmanagedType.LPWStr)][In] string pServerPrincName, [In] DWORD dwAuthnLevel, [In] DWORD dwImpLevel,
            [In] RPC_AUTH_IDENTITY_HANDLE pAuthInfo, [In] EOLE_AUTHENTICATION_CAPABILITIES dwCapabilities);

        /// <summary>
        /// <para>
        /// Allocates a block of task memory in the same way that IMalloc::Alloc does.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemalloc"/>
        /// </para>
        /// </summary>
        /// <param name="cb">
        /// The size of the memory block to be allocated, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns the allocated memory block.
        /// Otherwise, it returns <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="CoTaskMemAlloc"/> uses the default allocator to allocate a memory block in the same way that IMalloc::Alloc does.
        /// It is not necessary to call the <see cref="CoGetMalloc"/> function before calling <see cref="CoTaskMemAlloc"/>.
        /// The initial contents of the returned memory block are undefined – there is no guarantee that the block has been initialized.
        /// The allocated block may be larger than cb bytes because of the space required for alignment and for maintenance information.
        /// If <paramref name="cb"/> is 0, <see cref="CoTaskMemAlloc"/> allocates a zero-length item and returns a valid pointer to that item.
        /// If there is insufficient memory available, <see cref="CoTaskMemAlloc"/> returns <see cref="IntPtr.Zero"/>.
        /// Applications should always check the return value from this function, even when requesting small amounts of memory,
        /// because there is no guarantee that the memory will be allocated.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoTaskMemAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID CoTaskMemAlloc([In] SIZE_T cb);

        /// <summary>
        /// <para>
        /// Frees a block of task memory previously allocated through a call to the <see cref="CoTaskMemAlloc"/> or <see cref="CoTaskMemRealloc"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemfree"/>
        /// </para>
        /// </summary>
        /// <param name="pv">
        /// A pointer to the memory block to be freed.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the function has no effect.
        /// </param>
        /// <remarks>
        /// The <see cref="CoTaskMemFree"/> function uses the default OLE allocator.
        /// The number of bytes freed equals the number of bytes that were originally allocated or reallocated.
        /// After the call, the memory block pointed to by pv is invalid and can no longer be used.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoTaskMemFree", ExactSpelling = true, SetLastError = true)]
        public static extern void CoTaskMemFree([In] LPVOID pv);

        /// <summary>
        /// <para>
        /// Changes the size of a previously allocated block of task memory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemrealloc"/>
        /// </para>
        /// </summary>
        /// <param name="pv">
        /// A pointer to the memory block to be reallocated.
        /// This parameter can be <see cref="IntPtr.Zero"/>, as discussed in Remarks.
        /// </param>
        /// <param name="cb">
        /// The size of the memory block to be reallocated, in bytes.
        /// This parameter can be 0, as discussed in Remarks.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns the reallocated memory block.
        /// Otherwise, it returns <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// This function changes the size of a previously allocated memory block in the same way that IMalloc::Realloc does.
        /// It is not necessary to call the <see cref="CoGetMalloc"/> function to get a pointer
        /// to the OLE allocator before calling <see cref="CoTaskMemRealloc"/>.
        /// The <paramref name="pv"/> parameter points to the beginning of the memory block.
        /// If <paramref name="pv"/> is <see cref="IntPtr.Zero"/>, <see cref="CoTaskMemRealloc"/> allocates a new memory block
        /// in the same way as the <see cref="CoTaskMemAlloc"/> function.
        /// If <paramref name="pv"/> is not <see cref="IntPtr.Zero"/>, it should be a pointer returned by a prior call to <see cref="CoTaskMemAlloc"/>.
        /// The <paramref name="cb"/> parameter specifies the size of the new block.
        /// The contents of the block are unchanged up to the shorter of the new and old sizes,
        /// although the new block can be in a different location.
        /// Because the new block can be in a different memory location, the pointer returned by <see cref="CoTaskMemRealloc"/> is not guaranteed
        /// to be the pointer passed through the <paramref name="pv"/> argument.
        /// If <paramref name="pv"/> is not <see cref="IntPtr.Zero"/> and <paramref name="cb"/> is 0,
        /// then the memory pointed to by <paramref name="pv"/> is freed.
        /// <see cref="CoTaskMemRealloc"/> returns a void pointer to the reallocated (and possibly moved) memory block.
        /// The return value is <see cref="IntPtr.Zero"/> if the size is 0 and the buffer argument is not <see cref="IntPtr.Zero"/>,
        /// or if there is not enough memory available to expand the block to the specified size.
        /// In the first case, the original block is freed; in the second case, the original block is unchanged.
        /// The storage space pointed to by the return value is guaranteed to be suitably aligned for storage of any type of object.
        /// To get a pointer to a type other than void, use a type cast on the return value.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoTaskMemRealloc", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID CoTaskMemRealloc([In] LPVOID pv, [In] SIZE_T cb);

        /// <summary>
        /// <para>
        /// Establishes or removes an emulation, in which objects of one class are treated as objects of a different class.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cotreatasclass"/>
        /// </para>
        /// </summary>
        /// <param name="clsidOld">
        /// The CLSID of the object to be emulated.
        /// </param>
        /// <param name="clsidNew">
        /// The CLSID of the object that should emulate the original object.
        /// This replaces any existing emulation for <paramref name="clsidOld"/>.
        /// This parameter can be <see cref="CLSID_NULL"/>, in which case any existing emulation for <paramref name="clsidOld"/> is removed.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_INVALIDARG"/>, as well as the following values.
        /// <see cref="S_OK"/>: The emulation was successfully established or removed.
        /// <see cref="REGDB_E_CLASSNOTREG"/>: The clsidOld parameter is not properly registered in the registration database.
        /// <see cref="REGDB_E_READREGDB"/>: Error reading from registration database.
        /// <see cref="REGDB_E_WRITEREGDB"/>: Error writing to registration database.
        /// </returns>
        /// <remarks>
        /// This function sets the TreatAs entry in the registry for the specified object, allowing the object to be emulated by another application.
        /// Emulation allows an application to open and edit an object of a different format, while retaining the original format of the object.
        /// After this entry is set, whenever any function such as <see cref="CoGetClassObject"/> specifies the object's original CLSID (<paramref name="clsidOld"/>),
        /// it is transparently forwarded to the new CLSID (<paramref name="clsidNew"/>), thus launching the application associated with the TreatAs CLSID.
        /// When the object is saved, it can be saved in its native format, which may result in loss of edits not supported by the original format.
        /// If your application supports emulation, call <see cref="CoTreatAsClass"/> in the following situations:
        /// In response to an end-user request (through a conversion dialog box) that a specified object be treated as an object of a different class
        /// (an object created under one application be run under another application, while retaining the original format information)
        /// In a setup program, to register that one class of objects be treated as objects of a different class
        /// An example of the first case is that an end user might wish to edit a spreadsheet created by one application
        /// using a different application that can read and write the spreadsheet format of the original application.
        /// For an application that supports emulation, <see cref="CoTreatAsClass"/> can be called to implement a Treat As option in a conversion dialog box.
        /// An example of the use of <see cref="CoTreatAsClass"/> in a setup program would be in an updated version of an application.
        /// When the application is updated, the objects created with the earlier version can be activated and treated as objects of the new version,
        /// while retaining the previous format information.
        /// This would allow you to give the user the option to convert when they save, or to save it in the previous format,
        /// possibly losing format information not available in the older version.
        /// One result of setting an emulation is that when you enumerate verbs, as in the <see cref="IOleObject.EnumVerbs"/> method implementation in the default handler,
        /// this would enumerate the verbs from <paramref name="clsidNew"/> instead of <paramref name="clsidOld"/>.
        /// To ensure that existing emulation information is removed when you install an application, your setup programs should call <see cref="CoTreatAsClass"/>,
        /// setting the <paramref name="clsidNew"/> parameter to <see cref="CLSID_NULL"/> to remove any existing emulation for the classes they install.
        /// If there is no CLSID assigned to the AutoTreatAs key in the registry,
        /// setting <paramref name="clsidNew"/> and <paramref name="clsidOld"/> to the same value removes the TreatAs entry, so there is no emulation.
        /// If there is a CLSID assigned to the AutoTreatAs key, that CLSID is assigned to the TreatAs key.
        /// <see cref="CoTreatAsClass"/> does not validate whether an appropriate registry entry for <paramref name="clsidNew"/> currently exists.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoTreatAsClass", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoTreatAsClass([In] in CLSID clsidOld, [In] in CLSID clsidNew);

        /// <summary>
        /// <para>
        /// Closes the COM library on the current thread, unloads all DLLs loaded by the thread,
        /// frees any other resources that the thread maintains, and forces all RPC connections on the thread to close.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-couninitialize"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// A thread must call <see cref="CoUninitialize"/> once for each successful call it
        /// has made to the <see cref="CoInitialize"/> or <see cref="CoInitializeEx"/> function, including any call that returns <see cref="S_FALSE"/>.
        /// Only the <see cref="CoUninitialize"/> call corresponding to the <see cref="CoInitialize"/> or <see cref="CoInitializeEx"/> call
        /// that initialized the library can close it.
        /// Calls to <see cref="OleInitialize"/> must be balanced by calls to <see cref="OleUninitialize"/>.
        /// The <see cref="OleUninitialize"/> function calls <see cref="CoUninitialize"/> internally,
        /// so applications that call <see cref="OleUninitialize"/> do not also need to call <see cref="CoUninitialize"/>.
        /// <see cref="CoUninitialize"/> should be called on application shutdown, as the last call made to the COM library
        /// after the application hides its main windows and falls through its main message loop.
        /// If there are open conversations remaining, <see cref="CoUninitialize"/> starts a modal message loop and dispatches any pending messages
        /// from the containers or server for this COM application.
        /// By dispatching the messages, <see cref="CoUninitialize"/> ensures that the application does not quit
        /// before receiving all of its pending messages. Non-COM messages are discarded.
        /// Because there is no way to control the order in which in-process servers are loaded or unloaded,
        /// do not call <see cref="CoInitialize"/>, <see cref="CoInitializeEx"/>, or <see cref="CoUninitialize"/> from the DllMain function.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoUninitialize", ExactSpelling = true, SetLastError = true)]
        public static extern void CoUninitialize();

        /// <summary>
        /// <para>
        /// Initializes a newly created proxy using data written into the stream by a previous call to the <see cref="CoMarshalInterface"/> function,
        /// and returns an interface pointer to that proxy.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-counmarshalinterface"/>
        /// </para>
        /// </summary>
        /// <param name="pStm">
        /// A pointer to the stream from which the interface is to be unmarshaled.
        /// </param>
        /// <param name="riid">
        /// A reference to the identifier of the interface to be unmarshaled.
        /// For <see cref="IID_NULL"/>, the returned interface is the one defined by the stream, objref.iid.
        /// </param>
        /// <param name="ppv">
        /// The address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>.
        /// Upon successful return, *<paramref name="ppv"/> contains the requested interface pointer for the unmarshaled interface.
        /// </param>
        /// <returns>
        /// This function can return the standard return value <see cref="E_FAIL"/>,
        /// errors returned by <see cref="CoCreateInstance"/>, and the following values.
        /// <see cref="S_OK"/>: The interface pointer was unmarshaled successfully.
        /// <see cref="STG_E_INVALIDPOINTER"/>: <paramref name="pStm"/> is an invalid pointer.
        /// <see cref="CO_E_NOTINITIALIZED"/>:
        /// The <see cref="CoInitialize"/> or <see cref="OleInitialize"/> function
        /// was not called on the current thread before this function was called.
        /// <see cref="CO_E_OBJNOTCONNECTED"/>:
        /// The object application has been disconnected from the remoting system
        /// (for example, as a result of a call to the <see cref="CoDisconnectObject"/> function).
        /// <see cref="REGDB_E_CLASSNOTREG"/>: An error occurred reading the registration database. 
        /// <see cref="E_NOINTERFACE"/>: The final QueryInterface of this function for the requested interface returned <see cref="E_NOINTERFACE"/>. 
        /// </returns>
        /// <remarks>
        /// Important  
        /// Security Note: Calling this method with untrusted data is a security risk.
        /// Call this method only with trusted data. For more information, see Untrusted Data Security Risks.
        /// The <see cref="CoUnmarshalInterface"/> function performs the following tasks:
        /// Reads from the stream the CLSID to be used to create an instance of the proxy.
        /// Gets an <see cref="IMarshal"/> pointer to the proxy that is to do the unmarshaling.
        /// If the object uses COM's default marshaling implementation, the pointer thus obtained is to an instance of the generic proxy object.
        /// If the marshaling is occurring between two threads in the same process,
        /// the pointer is to an instance of the in-process free threaded marshaler.
        /// If the object provides its own marshaling code, <see cref="CoUnmarshalInterface"/> calls the <see cref="CoCreateInstance"/> function,
        /// passing the CLSID it read from the marshaling stream.
        /// <see cref="CoCreateInstance"/> creates an instance of the object's proxy
        /// and returns an <see cref="IMarshal"/> interface pointer to the proxy.
        /// Using whichever <see cref="IMarshal"/> interface pointer it has acquired,
        /// the function then calls <see cref="IMarshal.UnmarshalInterface"/> and, if appropriate, <see cref="IMarshal.ReleaseMarshalData"/>.
        /// The primary caller of this function is COM itself, from within interface proxies or stubs that unmarshal an interface pointer.
        /// There are, however, some situations in which you might call <see cref="CoUnmarshalInterface"/>.
        /// For example, if you are implementing a stub, your implementation would call <see cref="CoUnmarshalInterface"/>
        /// when the stub receives an interface pointer as a parameter in a method call. 
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CoUnmarshalInterface", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CoUnmarshalInterface([In] IStream pStm, [In] in IID riid, [Out] out object ppv);

        /// <summary>
        /// <para>
        /// Creates and returns a new anti-moniker.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-createantimoniker"/>
        /// </para>
        /// </summary>
        /// <param name="ppmk">
        /// The address of an <see cref="IMoniker"/>* pointer variable that receives the interface pointer to the new anti-moniker.
        /// When successful, the function has called AddRef on the anti-moniker and the caller is responsible for calling Release.
        /// When an error occurs, the anti-moniker pointer is <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// You would call this function only if you are writing your own moniker class (implementing the <see cref="IMoniker"/> interface).
        /// If you are writing a new moniker class that has no internal structure,
        /// you can use <see cref="CreateAntiMoniker"/> in your implementation of the <see cref="IMoniker.Inverse"/> method,
        /// and then check for an anti-moniker in your implementation of <see cref="IMoniker.ComposeWith"/>.
        /// Like the ".." directory, which acts as the inverse to any directory name just preceding it in a path,
        /// an anti-moniker acts as the inverse of a simple moniker that precedes it in a composite moniker.
        /// An anti-moniker is used as the inverse of simple monikers with no internal structure.
        /// For example, the system-provided implementations of file monikers, item monikers,
        /// and pointer monikers all use anti-monikers as their inverse;
        /// consequently, an anti-moniker composed to the right of one of these monikers composes to nothing.
        /// A moniker client (an object that is using a moniker to bind to another object) typically does not know the class of a given moniker,
        /// so the client cannot be sure that an anti-moniker is the inverse.
        /// Therefore, to get the inverse of a moniker, you would call <see cref="IMoniker.Inverse"/> rather than <see cref="CreateAntiMoniker"/>.
        /// To remove the last piece of a composite moniker, you would do the following:
        /// Call <see cref="IMoniker.Enum"/> on the composite, specifying <see cref="FALSE"/> as the first parameter.
        /// This creates an enumerator that returns the component monikers in reverse order.
        /// Use the enumerator to retrieve the last piece of the composite.
        /// Call <see cref="IMoniker.Inverse"/> on that moniker.
        /// The moniker returned by <see cref="IMoniker.Inverse"/> will remove the last piece of the composite.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateAntiMoniker", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CreateAntiMoniker([Out] out IMoniker ppmk);

        /// <summary>
        /// <para>
        /// Returns a pointer to an implementation of <see cref="IBindCtx"/> (a bind context object).
        /// This object stores information about a particular moniker-binding operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-createbindctx"/>
        /// </para>
        /// </summary>
        /// <param name="reserved">
        /// This parameter is reserved and must be 0.
        /// </param>
        /// <param name="ppbc">
        /// Address of an <see cref="IBindCtx"/> pointer variable that receives the interface pointer to the new bind context object.
        /// When the function is successful, the caller is responsible for calling <see cref="Marshal.ReleaseComObject(object)"/> on the bind context.
        /// A <see langword="null"/> value for the bind context indicates that an error occurred.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// CreateBindCtx is most commonly used in the process of binding a moniker
        /// (locating and getting a pointer to an interface by identifying it through a moniker), as in the following steps:
        /// Get a pointer to a bind context by calling the <see cref="CreateBindCtx"/> function.
        /// Call the <see cref="IMoniker.BindToObject"/> on the moniker, retrieving an interface pointer to the object to which the moniker refers.
        /// Release the bind context.
        /// Use the interface pointer.
        /// Release the interface pointer.
        /// The following code fragment illustrates these steps.
        /// <code>
        /// // pMnk is an IMoniker * that points to a previously acquired moniker 
        /// IInterface* pInterface;
        /// IBindCtx* pbc;
        /// 
        /// CreateBindCtx( 0, &amp;pbc );
        /// pMnk-&gt;BindToObject(pbc, NULL, IID_IInterface, &amp;pInterface );
        /// pbc-&gt;Release();
        /// 
        /// // pInterface now points to the object; safe to use pInterface 
        /// pInterface-&gt;Release();
        /// </code>
        /// Bind contexts are also used in other methods of the <see cref="IMoniker"/> interface besides <see cref="IMoniker.BindToObject"/>
        /// and in the <see cref="MkParseDisplayName"/> function.
        /// A bind context retains references to the objects that are bound during the binding operation,
        /// causing the bound objects to remain active (keeping the object's server running) until the bind context is released.
        /// Reusing a bind context when subsequent operations bind to the same object can improve performance.
        /// You should, however, release the bind context as soon as possible, because you could be keeping the objects activated unnecessarily.
        /// A bind context contains a <see cref="BIND_OPTS"/> structure, which contains parameters that apply to all steps in a binding operation.
        /// When you create a bind context using <see cref="CreateBindCtx"/>, the fields of the <see cref="BIND_OPTS"/> structure are initialized as follows.
        /// <code>
        /// cbStruct = sizeof(BIND_OPTS) 
        /// grfFlags = 0 
        /// grfMode = STGM_READWRITE 
        /// dwTickCountDeadline = 0
        /// </code>
        /// You can call the <see cref="IBindCtx.SetBindOptions"/> method to modify these default values.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateBindCtx", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CreateBindCtx([In] DWORD reserved, [Out] out IBindCtx ppbc);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the OLE implementation of <see cref="IDataAdviseHolder"/> on the data advise holder object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-createdataadviseholder"/>
        /// </para>
        /// </summary>
        /// <param name="ppDAHolder">
        /// Address of an <see cref="IDataAdviseHolder"/> pointer variable that receives the interface pointer to the new advise holder object.
        /// </param>
        /// <returns>
        /// This function returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory for the operation.
        /// </returns>
        /// <remarks>
        /// Call <see cref="CreateDataAdviseHolder"/> in your implementation of <see cref="IDataObject.DAdvise"/> to get a pointer
        /// to the OLE implementation of <see cref="IDataAdviseHolder"/> interface.
        /// With this pointer, you can then complete the implementation of <see cref="IDataObject.DAdvise"/>
        /// by calling the <see cref="IDataAdviseHolder.Advise"/> method, which creates an advisory connection
        /// between the calling object and the data object.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDataAdviseHolder", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CreateDataAdviseHolder([Out] out IDataAdviseHolder ppDAHolder);

        /// <summary>
        /// <para>
        /// Performs a generic composition of two monikers and supplies a pointer to the resulting composite moniker.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-creategenericcomposite"/>
        /// </para>
        /// </summary>
        /// <param name="pmkFirst">
        /// A pointer to the moniker to be composed to the left of the moniker that pmkRest points to.
        /// Can point to any kind of moniker, including a generic composite.
        /// </param>
        /// <param name="pmkRest">
        /// A pointer to the moniker to be composed to the right of the moniker to which pmkFirst points.
        /// Can point to any kind of moniker compatible with the type of the <paramref name="pmkRest"/> moniker, including a generic composite.
        /// </param>
        /// <param name="ppmkComposite">
        /// The address of an <see cref="IMoniker"/> pointer variable that receives the interface pointer to the composite moniker object
        /// that is the result of composing <paramref name="pmkFirst"/> and <paramref name="pmkRest"/>.
        /// This object supports the OLE composite moniker implementation of <see cref="IMoniker"/>.
        /// When successful, the function has called AddRef on the moniker and the caller is responsible for calling Release.
        /// If either <paramref name="pmkFirst"/> or <paramref name="pmkRest"/> are <see langword="null"/>,
        /// the supplied pointer is the one that is non-NULL.
        /// If both <paramref name="pmkFirst"/> and <paramref name="pmkRest"/> are <see langword="null"/>,
        /// or if an error occurs, the returned pointer is <see langword="null"/>.
        /// </param>
        /// <returns></returns>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateGenericComposite", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CreateGenericComposite([In] IMoniker pmkFirst, [In] IMoniker pmkRest, [Out] out IMoniker ppmkComposite);

        /// <summary>
        /// <para>
        /// Creates an advise holder object for managing compound document notifications.
        /// It returns a pointer to the object's OLE implementation of the <see cref="IOleAdviseHolder"/> interface.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-createoleadviseholder"/>
        /// </para>
        /// </summary>
        /// <param name="ppOAHolder">
        /// Address of <see cref="IOleAdviseHolder"/> pointer variable that receives the interface pointer to the new advise holder object.
        /// </param>
        /// <returns>
        /// This function returns <see cref="S_OK"/> on success and supports the standard return value <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// The function <see cref="CreateOleAdviseHolder"/> creates an instance of an advise holder,
        /// which supports the OLE implementation of the <see cref="IOleAdviseHolder"/> interface.
        /// The methods of this interface are intended to be used to implement the advisory methods of <see cref="IOleObject"/>,
        /// and, when advisory connections have been set up with objects supporting an advisory sink,
        /// to send notifications of changes in the object to the advisory sink.
        /// The advise holder returned by <see cref="CreateOleAdviseHolder"/> will suffice for the great majority of applications.
        /// The OLE-provided implementation does not, however, support <see cref="IOleAdviseHolder.EnumAdvise"/>,
        /// so if you need to use this method, you will need to implement your own advise holder.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateOleAdviseHolder", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CreateOleAdviseHolder([Out] out IOleAdviseHolder ppOAHolder);

        /// <summary>
        /// <para>
        /// Provides a generic test for failure on any status value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winerror/nf-winerror-failed"/>
        /// </para>
        /// </summary>
        /// <param name="hr">
        /// The status code.
        /// This value can be an <see cref="HRESULT"/> or an SCODE.
        /// A negative number indicates failure.
        /// </param>
        /// <returns></returns>
        public static bool FAILED(HRESULT hr) => hr;

        /// <summary>
        /// <para>
        /// Returns a pointer to the <see cref="IRunningObjectTable"/> interface on the local running object table (ROT).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-getrunningobjecttable"/>
        /// </para>
        /// </summary>
        /// <param name="reserved">
        /// This parameter is reserved and must be 0.
        /// </param>
        /// <param name="pprot">
        /// The address of an <see cref="IRunningObjectTable"/>* pointer variable that receives the interface pointer to the local ROT.
        /// When the function is successful, the caller is responsible for calling Release on the interface pointer.
        /// If an error occurs, *pprot is undefined.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_UNEXPECTED"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// Each workstation has a local ROT that maintains a table of the objects that have been registered as running on that computer.
        /// This function returns an <see cref="IRunningObjectTable"/> interface pointer, which provides access to that table.
        /// Moniker providers, which hand out monikers that identify objects so they are accessible to others,
        /// should call <see cref="GetRunningObjectTable"/>.
        /// Use the interface pointer returned by this function to register your objects when they begin running,
        /// to record the times that those objects are modified, and to revoke their registrations when they stop running.
        /// See the <see cref="IRunningObjectTable"/> interface for more information.
        /// Compound-document link sources are the most common example of moniker providers.
        /// These include server applications that support linking to their documents (or portions of a document)
        /// and container applications that support linking to embeddings within their documents.
        /// Server applications that do not support linking can also use the ROT
        /// to cooperate with container applications that support linking to embeddings.
        /// If you are implementing the <see cref="IMoniker"/> interface to write a new moniker class, and you need an interface pointer to the ROT,
        /// call <see cref="IBindCtx.GetRunningObjectTable"/> rather than the <see cref="GetRunningObjectTable"/> function.
        /// This allows future implementations of the <see cref="IBindCtx"/> interface to modify binding behavior.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetRunningObjectTable", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT GetRunningObjectTable([In] DWORD reserved, [Out] out IRunningObjectTable pprot);

        /// <summary>
        /// <para>
        /// Converts a string generated by the <see cref="StringFromIID"/> function back into the original interface identifier (IID).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-iidfromstring"/>
        /// </para>
        /// </summary>
        /// <param name="lpsz">
        /// A pointer to the string representation of the IID.
        /// </param>
        /// <param name="lpiid">
        /// A pointer to the requested <see cref="IID"/> on return.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_INVALIDARG"/>, <see cref="E_OUTOFMEMORY"/>, and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// The function converts the interface identifier in a way that guarantees different interface identifiers will always be converted to different strings.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "IIDFromString", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT IIDFromString([In] LPCOLESTR lpsz, [Out] out IID lpiid);

        /// <summary>
        /// <para>
        /// Converts a string into a moniker that identifies the object named by the string.
        /// This function is the inverse of the <see cref="IMoniker.GetDisplayName"/> operation,
        /// which retrieves the display name associated with a moniker.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-mkparsedisplayname"/>
        /// </para>
        /// </summary>
        /// <param name="pbc">
        /// A pointer to the <see cref="IBindCtx"/> interface on the bind context object to be used in this binding operation.
        /// </param>
        /// <param name="szUserName">
        /// A pointer to the display name to be parsed.
        /// </param>
        /// <param name="pchEaten">
        /// A pointer to the number of characters of <paramref name="szUserName"/> that were consumed.
        /// If the function is successful, *<paramref name="pchEaten"/> is the length of <paramref name="szUserName"/>;
        /// otherwise, it is the number of characters successfully parsed.
        /// </param>
        /// <param name="ppmk">
        /// The address of the <see cref="IMoniker"/>* pointer variable that receives the interface pointer
        /// to the moniker that was built from <paramref name="szUserName"/>.
        /// When successful, the function has called AddRef on the moniker and the caller is responsible for calling Release.
        /// If an error occurs, the specified interface pointer will contain as much of the moniker
        /// that the method was able to create before the error occurred.
        /// </param>
        /// <returns>
        /// This function can return the standard return value <see cref="E_OUTOFMEMORY"/>, as well as the following values.
        /// <see cref="S_OK"/>: The parse operation was successful and the moniker was created.
        /// <see cref="MK_E_SYNTAX"/>: Error in the syntax of a file name or an error in the syntax of the resulting composite moniker.
        /// This function can also return any of the error values returned by <see cref="IMoniker.BindToObject"/>,
        /// <see cref="IOleItemContainer.GetObject"/>, or <see cref="IParseDisplayName.ParseDisplayName"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="MkParseDisplayName"/> function parses a human-readable name into a moniker that can be used to identify a link source.
        /// The resulting moniker can be a simple moniker (such as a file moniker),
        /// or it can be a generic composite made up of the component moniker pieces.
        /// For example, the display name "c:\mydir\somefile!item 1" could be parsed into the following generic composite moniker:
        /// FileMoniker based on "c:\mydir\somefile") + (ItemMoniker based on "item 1").
        /// The most common use of <see cref="MkParseDisplayName"/> is in the implementation of the standard Links dialog box,
        /// which allows an end user to specify the source of a linked object by typing in a string.
        /// You may also need to call <see cref="MkParseDisplayName"/> if your application supports a macro language
        /// that permits remote references (reference to elements outside of the document).
        /// Parsing a display name often requires activating the same objects that would be activated during a binding operation,
        /// so it can be just as expensive (in terms of performance) as binding.
        /// Objects that are bound during the parsing operation are cached in the bind context passed to the function.
        /// If you plan to bind the moniker returned by <see cref="MkParseDisplayName"/>, it is best to do so immediately after the function returns,
        /// using the same bind context, which removes the need to activate objects a second time.
        /// <see cref="MkParseDisplayName"/> parses as much of the display name as it understands into a moniker.
        /// The function then calls <see cref="IMoniker.ParseDisplayName"/> on the newly created moniker, passing the remainder of the display name.
        /// The moniker returned by <see cref="IMoniker.ParseDisplayName"/> is composed onto the end of the existing moniker and,
        /// if any of the display name remains unparsed, <see cref="IMoniker.ParseDisplayName"/> is called on the result of the composition.
        /// This process is repeated until the entire display name has been parsed.
        /// <see cref="MkParseDisplayName"/> attempts the following strategies to parse the beginning of the display name,
        /// using the first one that succeeds:
        /// The function looks in the Running Object Table for file monikers corresponding to all prefixes of the display name
        /// that consist solely of valid file name characters. This strategy can identify documents that are as yet unsaved.
        /// The function checks the maximal prefix of the display name, which consists solely of valid file name characters,
        /// to see if an OLE 1 document is registered by that name.
        /// In this case, the returned moniker is an internal moniker provided by the OLE 1 compatibility layer of OLE 2.
        /// The function consults the file system to check whether a prefix of the display name matches an existing file.
        /// The file name can be drive-absolute, drive-relative, working-directory relative, or begin with an explicit network share name.
        /// This is the common case.
        /// If the initial character of the display name is '@', the function finds the longest string immediately following it
        /// that conforms to the legal ProgID syntax.
        /// The function converts this string to a <see cref="CLSID"/> using the <see cref="CLSIDFromProgID"/> function.
        /// If the CLSID represents an OLE 2 class, the function loads the corresponding class object
        /// and asks for an <see cref="IParseDisplayName"/> interface pointer.
        /// The resulting <see cref="IParseDisplayName"/> interface is then given the whole string to parse, starting with the '@'.
        /// If the CLSID represents an OLE 1 class, then the function treats the string following the ProgID
        /// as an OLE1/DDE link designator having filename|item syntax.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "MkParseDisplayName", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT MkParseDisplayName([MarshalAs(UnmanagedType.Interface)][In] IBindCtx pbc,
            [MarshalAs(UnmanagedType.LPWStr)][In] string szUserName, [Out] out ULONG pchEaten,
            [MarshalAs(UnmanagedType.Interface)][Out] out IMoniker ppmk);

        /// <summary>
        /// <para>
        /// Creates an embedded object identified by a <see cref="CLSID"/>.
        /// You use it typically to implement the menu item that allows the end user to insert a new object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreate"/>
        /// </para>
        /// </summary>
        /// <param name="rclsid"></param>
        /// <param name="riid"></param>
        /// <param name="renderopt"></param>
        /// <param name="pFormatEtc"></param>
        /// <param name="pClientSite"></param>
        /// <param name="pStg"></param>
        /// <param name="ppvObj"></param>
        /// <returns>
        /// This function returns <see cref="S_OK"/> on success and supports the standard return value <see cref="E_OUTOFMEMORY"/>.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory for the operation.
        /// </returns>
        /// <remarks>
        /// The <see cref="OleCreate"/> function creates a new embedded object, and is typically called to implement the menu item Insert New Object.
        /// When <see cref="OleCreate"/> returns, the object it has created is blank (contains no data),
        /// unless <paramref name="renderopt"/> is <see cref="OLERENDER_DRAW"/> or <see cref="OLERENDER_FORMAT"/>, and is loaded.
        /// Containers typically then call the <see cref="OleRun"/> function or <see cref="IOleObject.DoVerb"/> to show the object for initial editing.
        /// The <paramref name="rclsid"/> parameter specifies the CLSID of the requested object.
        /// CLSIDs of registered objects are stored in the system registry.
        /// When an application user selects Insert Object, a selection box allows the user to select the type of object desired from those in the registry.
        /// When <see cref="OleCreate"/> is used to implement the Insert Object menu item,
        /// the CLSID associated with the selected item is assigned to the rclsid parameter of <see cref="OleCreate"/>.
        /// The <paramref name="riid"/> parameter specifies the interface the client will use to communicate with the new object.
        /// Upon successful return, the <paramref name="ppvObj"/> parameter holds a pointer to the requested interface.
        /// The created object's cache contains information that allows a presentation of a contained object when the container is opened.
        /// Information about what should be cached is passed in the <paramref name="renderopt"/> and <paramref name="pFormatEtc"/> values.
        /// When <see cref="OleCreate"/> returns, the created object's cache is not necessarily filled.
        /// Instead, the cache is filled the first time the object enters the running state.
        /// The caller can add additional cache control with a call to <see cref="IOleCache.Cache"/>
        /// after the return of <see cref="OleCreate"/> and before the object is run.
        /// If renderopt is <see cref="OLERENDER_DRAW"/> or <see cref="OLERENDER_FORMAT"/>,
        /// <see cref="OleCreate"/> requires that the object support the <see cref="IOleCache"/> interface.
        /// There is no such requirement for any other value of <paramref name="renderopt"/>.
        /// If <paramref name="pClientSite"/> is non-NULL, <see cref="OleCreate"/>
        /// calls <see cref="IOleObject.SetClientSite"/> through the <paramref name="pClientSite"/> pointer.
        /// <see cref="IOleClientSite"/> is the primary interface by which an object requests services from its container.
        /// If <paramref name="pClientSite"/> is <see cref="NULL"/>,
        /// you must make a specific call to <see cref="IOleObject.SetClientSite"/> before attempting any operations.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "OleCreate", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT OleCreate([In] in CLSID rclsid, [In] in IID riid, [In] OLERENDER renderopt, [In] in FORMATETC pFormatEtc,
            [In] in IOleClientSite pClientSite, [In] in IStorage pStg, [Out] out LPVOID ppvObj);

        /// <summary>
        /// <para>
        /// Creates a new instance of the default embedding handler.
        /// This instance is initialized so it creates a local server when the embedded object enters the running state.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatedefaulthandler"/>
        /// </para>
        /// </summary>
        /// <param name="clsid">
        /// CLSID identifying the OLE server to be loaded when the embedded object enters the running state.
        /// </param>
        /// <param name="pUnkOuter">
        /// Pointer to the controlling <see cref="IUnknown"/> interface if the handler is to be aggregated;
        /// <see cref="NullRef{IUnknown}"/> if it is not to be aggregated.
        /// </param>
        /// <param name="riid">
        /// Reference to the identifier of the interface, usually <see cref="IID_IOleObject"/>,
        /// through which the caller will communicate with the handler.
        /// </param>
        /// <param name="lplpObj">
        /// Address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>.
        /// Upon successful return, <paramref name="lplpObj"/> contains the requested interface pointer on the newly created handler.
        /// </param>
        /// <returns>
        /// This function returns <see cref="NOERROR"/> on success and supports the standard return value <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="OleCreateDefaultHandler"/> creates a new instance of the default embedding handler,
        /// initialized so it creates a local server identified by the <paramref name="clsid"/> parameter when the embedded object enters the running state.
        /// If you are writing a handler and want to use the services of the default handler, call <see cref="OleCreateDefaultHandler"/>.
        /// OLE also calls it internally when the CLSID specified in an object creation call is not registered.
        /// If the given class does not have a special handler, a call to <see cref="OleCreateDefaultHandler"/> produces the same results
        /// as a call to the <see cref="CoCreateInstance"/> function with the class context parameter assigned the value <see cref="CLSCTX_INPROC_HANDLER"/>.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "OleCreateDefaultHandler", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT OleCreateDefaultHandler([In] in CLSID clsid, [In] in IUnknown pUnkOuter, [In] in IID riid, [Out] out LPVOID lplpObj);

        /// <summary>
        /// <para>
        /// Creates an embedded object from a data transfer object retrieved either from the clipboard or as part of an OLE drag-and-drop operation.
        /// It is intended to be used to implement a paste from an OLE drag-and-drop operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatefromdata"/>
        /// </para>
        /// </summary>
        /// <param name="pSrcDataObj">
        /// Pointer to the <see cref="IDataObject"/> interface on the data transfer object that holds the data from which the object is created.
        /// </param>
        /// <param name="riid">
        /// Reference to the identifier of the interface the caller later uses to communicate with the new object (usually <see cref="IID_IOleObject"/>,
        /// defined in the OLE headers as the interface identifier for <see cref="IOleObject"/>).
        /// </param>
        /// <param name="renderopt">
        /// Value from the enumeration <see cref="OLERENDER"/> that indicates
        /// the locally cached drawing or data-retrieval capabilities the newly created object is to have.
        /// Additional considerations are described in the following Remarks section.
        /// </param>
        /// <param name="pFormatEtc">
        /// Pointer to a value from the enumeration <see cref="OLERENDER"/> that indicates
        /// the locally cached drawing or data-retrieval capabilities the newly created object is to have.
        /// The <see cref="OLERENDER"/> value chosen affects the possible values for the <paramref name="pFormatEtc"/> parameter.
        /// </param>
        /// <param name="pClientSite">
        /// Pointer to an instance of <see cref="IOleClientSite"/>,
        /// the primary interface through which the object will request services from its container.
        /// This parameter can be <see langword="null"/>.
        /// </param>
        /// <param name="pStg">
        /// Pointer to the <see cref="IStorage"/> interface on the storage object.
        /// This parameter may not be <see langword="null"/>.
        /// </param>
        /// <param name="ppvObj">
        /// Address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>.
        /// Upon successful return, *<paramref name="ppvObj"/> contains the requested interface pointer on the newly created object.
        /// </param>
        /// <returns>
        /// This function returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="OLE_E_STATIC"/>: Indicates OLE can create only a static object.
        /// <see cref="DV_E_FORMATETC"/>: No acceptable formats are available for object creation.
        /// </returns>
        /// <remarks>
        /// The <see cref="OleCreateFromData"/> function creates an embedded object
        /// from a data transfer object supporting the <see cref="IDataObject"/> interface.
        /// The data object in this case is either the type retrieved from the clipboard
        /// with a call to the <see cref="OleGetClipboard"/> function or is part of an OLE drag-and-drop operation
        /// (the data object is passed to a call to <see cref="IDropTarget.Drop"/>).
        /// If either the FileName or FileNameW clipboard format(<see cref="CF_FILENAME"/>) is present in the data transfer object,
        /// and <see cref="CF_EMBEDDEDOBJECT"/> or <see cref="CF_EMBEDSOURCE"/> do not exist,
        /// <see cref="OleCreateFromData"/> first attempts to create a package containing the indicated file.
        /// Generally, it takes the first available format.
        /// If <see cref="OleCreateFromData"/> cannot create a package, it tries to create an object using the <see cref="CF_EMBEDDEDOBJECT"/> format.
        /// If that format is not available, <see cref="OleCreateFromData"/> tries to create it with the <see cref="CF_EMBEDSOURCE"/> format.
        /// If neither of these formats is available and the data transfer object supports the <see cref="IPersistStorage"/> interface,
        /// <see cref="OleCreateFromData"/> calls the object's <see cref="IPersistStorage.Save"/> to have the object save itself.
        /// If an existing linked object is selected, then copied, it appears on the clipboard as just another embeddable object.
        /// Consequently, a paste operation that invokes <see cref="OleCreateFromData"/> may create a linked object. After the paste operation,
        /// the container should call the QueryInterface function, requesting <see cref="IID_IOleLink"/>
        /// (defined in the OLE headers as the interface identifier for <see cref="IOleLink"/>), to determine if a linked object was created.
        /// Use the <paramref name="renderopt"/> and <paramref name="pFormatEtc"/> parameters
        /// to control the caching capability of the newly created object.
        /// For general information about using the interaction of these parameters to determine what is to be cached,
        /// refer to the <see cref="OLERENDER"/> enumeration.
        /// There are, however, some additional specific effects of these parameters on the way <see cref="OleCreateFromData"/> initializes the cache.
        /// When <see cref="OleCreateFromData"/> uses either the <see cref="CF_EMBEDDEDOBJECT"/>
        /// or the <see cref="CF_EMBEDSOURCE"/> clipboard format to create the embedded object,
        /// the main difference between the two is where the cache-initialization data is stored:
        /// <see cref="CF_EMBEDDEDOBJECT"/> indicates that the source is an existing embedded object.
        /// It already has in its cache the appropriate data, and OLE uses this data to initialize the cache of the new object.
        /// <see cref="CF_EMBEDSOURCE"/> indicates that the source data object
        /// contains the cache-initialization information in formats other than <see cref="CF_EMBEDSOURCE"/>.
        /// <see cref="OleCreateFromData"/> uses these to initialize the cache of the newly embedded object.
        /// The renderopt values affect cache initialization as follows.
        /// <see cref="OLERENDER_DRAW"/> &amp; <see cref="OLERENDER_FORMAT"/>:
        /// If the presentation information to be cached is currently present in the appropriate cache-initialization pool, it is used.
        /// (Appropriate locations are in the source data object cache for <see cref="CF_EMBEDDEDOBJECT"/>,
        /// and in the other formats in the source data object for <see cref="CF_EMBEDSOURCE"/>.)
        /// If the information is not present, the cache is initially empty, but will be filled the first time the object is run.
        /// No other formats are cached in the newly created object.
        /// <see cref="OLERENDER_NONE"/>:
        /// Nothing is to be cached in the newly created object.
        /// If the source has the <see cref="CF_EMBEDDEDOBJECT"/> format, any existing cached data that has been copied is removed.
        /// <see cref="OLERENDER_ASIS"/>:
        /// If the source has the <see cref="CF_EMBEDDEDOBJECT"/> format,
        /// the cache of the new object is to contain the same cache data as the source object.
        /// For <see cref="CF_EMBEDSOURCE"/>, nothing is to be cached in the newly created object.
        /// This option should be used by more sophisticated containers.
        /// After this call, such containers would call <see cref="IOleCache.Cache"/>
        /// and <see cref="IOleCache.Uncache"/> to set up exactly what is to be cached.
        /// For <see cref="CF_EMBEDSOURCE"/>, they would then also call <see cref="IOleCache.InitCache"/>.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "OleCreateFromData", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT OleCreateFromData([In] IDataObject pSrcDataObj, [In] in IID riid, [In] OLERENDER renderopt,
            [In] in FORMATETC pFormatEtc, [In] in IOleClientSite pClientSite, [In] in IStorage pStg, [Out] out LPVOID ppvObj);

        /// <summary>
        /// <para>
        /// Creates an embedded object from the contents of a named file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole/nf-ole-olecreatefromfile"/>
        /// </para>
        /// </summary>
        /// <param name="rclsid"></param>
        /// <param name="lpszFileName"></param>
        /// <param name="riid"></param>
        /// <param name="renderopt"></param>
        /// <param name="lpFormatEtc"></param>
        /// <param name="pClientSite"></param>
        /// <param name="pStg"></param>
        /// <param name="ppvObj"></param>
        /// <returns>
        /// This function returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="STG_E_FILENOTFOUND"/>: File not bound.
        /// <see cref="OLE_E_CANT_BINDTOSOURCE"/>: Not able to bind to source.
        /// <see cref="STG_E_MEDIUMFULL"/>: The medium is full.
        /// <see cref="DV_E_TYMED"/>: Invalid TYMED.
        /// <see cref="DV_E_LINDEX"/>: Invalid LINDEX.
        /// <see cref="DV_E_FORMATETC"/>: Invalid FORMATETC structure.
        /// </returns>
        /// <remarks>
        /// The <see cref="OleCreateFromFile"/> function creates a new embedded object from the contents of a named file.
        /// If the ProgID in the registration database contains the PackageOnFileDrop key, it creates a package.
        /// If not, the function calls the <see cref="GetClassFile"/> function to get the CLSID associated
        /// with the <paramref name="lpszFileName"/> parameter, and then creates an OLE 2-embedded object associated with that CLSID.
        /// The <paramref name="rclsid"/> parameter of <see cref="OleCreateFromFile"/> will always be ignored,
        /// and should be set to <see cref="CLSID_NULL"/>.
        /// As for other OleCreateXxx functions, the newly created object is not shown to the user for editing,
        /// which requires a <see cref="IOleObject.DoVerb"/> operation.
        /// It is used to implement insert file operations.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "OleCreateFromFile", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT OleCreateFromFile([In] in CLSID rclsid, [MarshalAs(UnmanagedType.LPWStr)][In] in string lpszFileName,
            [In] in IID riid, [In] in DWORD renderopt, [In] in FORMATETC lpFormatEtc, [In] in IOleClientSite pClientSite,
            [In] in IStorage pStg, [Out] out LPVOID ppvObj);

        /// <summary>
        /// <para>
        /// Creates an OLE compound-document linked object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatelink"/>
        /// </para>
        /// </summary>
        /// <param name="pmkLinkSrc">
        /// Pointer to the <see cref="IMoniker"/> interface on the moniker that can be used to locate the source of the linked object.
        /// </param>
        /// <param name="riid">
        /// Reference to the identifier of the interface the caller later uses to communicate with the new object
        /// (usually <see cref="IID_IOleObject"/>, defined in the OLE headers as the interface identifier for <see cref="IOleObject"/>).
        /// </param>
        /// <param name="renderopt">
        /// Specifies a value from the enumeration <see cref="OLERENDER"/> that indicates the locally cached
        /// drawing or data-retrieval capabilities the newly created object is to have.
        /// Additional considerations are described in the Remarks section below.
        /// </param>
        /// <param name="lpFormatEtc">
        /// Pointer to a value from the enumeration <see cref="OLERENDER"/> that indicates the locally cached
        /// drawing or data-retrieval capabilities the newly created object is to have.
        /// The <see cref="OLERENDER"/> value chosen affects the possible values for the <paramref name="lpFormatEtc"/> parameter.
        /// </param>
        /// <param name="pClientSite">
        /// Pointer to an instance of <see cref="IOleClientSite"/>, the primary interface through which the object will request services from its container.
        /// This parameter can be <see cref="NullRef{IOleClientSite}"/>.
        /// </param>
        /// <param name="pStg">
        /// Pointer to the <see cref="IStorage"/> interface on the storage object.
        /// This parameter cannot be <see cref="NullRef{IStorage}"/>.
        /// </param>
        /// <param name="ppvObj">
        /// Address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>.
        /// Upon successful return, <paramref name="ppvObj"/> contains the requested interface pointer on the newly created object.
        /// </param>
        /// <returns>
        /// This function returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="OLE_E_CANT_BINDTOSOURCE"/>: Not able to bind to source.
        /// </returns>
        /// <remarks>
        /// Call <see cref="OleCreateLink"/> to allow a container to create a link to an object.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "OleCreateLink", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT OleCreateLink([In] in IMoniker pmkLinkSrc, [In] in IID riid, [In] OLERENDER renderopt, [In] in FORMATETC lpFormatEtc,
            [In] in IOleClientSite pClientSite, [In] in IStorage pStg, [Out] out LPVOID ppvObj);

        /// <summary>
        /// <para>
        /// Initializes the COM library on the current apartment, identifies the concurrency model as single-thread apartment (STA),
        /// and enables additional functionality described in the Remarks section below.
        /// Applications must initialize the COM library before they can call COM library functions
        /// other than <see cref="CoGetMalloc"/> and memory allocation functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleinitialize"/>
        /// </para>
        /// </summary>
        /// <param name="pvReserved">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// This function returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="S_FALSE"/>: The COM library is already initialized on this apartment.
        /// <see cref="OLE_E_WRONGCOMPOBJ"/>: The versions of COMPOBJ.DLL and OLE2.DLL on your machine are incompatible with each other.
        /// <see cref="RPC_E_CHANGED_MODE"/>:
        /// A previous call to <see cref="CoInitializeEx"/> specified the concurrency model for this apartment as multithread apartment (MTA).
        /// This could also mean that a change from neutral threaded apartment to single threaded apartment occurred. 
        /// </returns>
        /// <remarks>
        /// Applications that use the following functionality must call <see cref="OleInitialize"/> before calling any other function in the COM library:
        /// Clipboard, Drag and Drop, Object linking and embedding (OLE), In-place activation
        /// <see cref="OleInitialize"/> calls <see cref="CoInitializeEx"/> internally to initialize the COM library on the current apartment.
        /// Because OLE operations are not thread-safe, <see cref="OleInitialize"/> specifies the concurrency model as single-thread apartment.
        /// Once the concurrency model for an apartment is set, it cannot be changed.
        /// A call to <see cref="OleInitialize"/> on an apartment that was previously initialized
        /// as multithreaded will fail and return <see cref="RPC_E_CHANGED_MODE"/>.
        /// You need to initialize the COM library on an apartment before you call any of the library functions except <see cref="CoGetMalloc"/>,
        /// to get a pointer to the standard allocator, and the memory allocation functions.
        /// Typically, the COM library is initialized on an apartment only once.
        /// Subsequent calls will succeed, as long as they do not attempt to change the concurrency model of the apartment,
        /// but will return <see cref="S_FALSE"/>.
        /// To close the COM library gracefully, each successful call to <see cref="OleInitialize"/>,
        /// including those that return <see cref="S_FALSE"/>, must be balanced by a corresponding call to <see cref="OleUninitialize"/>.
        /// Because there is no way to control the order in which in-process servers are loaded or unloaded,
        /// do not call <see cref="OleInitialize"/> or <see cref="OleUninitialize"/> from the DllMain function.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "OleInitialize", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT OleInitialize([In] LPVOID pvReserved);

        /// <summary>
        /// <para>
        /// Loads into memory an object nested within a specified storage object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleload"/>
        /// </para>
        /// </summary>
        /// <param name="pStg">
        /// Pointer to the <see cref="IStorage"/> interface on the storage object from which to load the specified object.
        /// </param>
        /// <param name="riid">
        /// Reference to the identifier of the interface that the caller wants to use to communicate with the object after it is loaded.
        /// </param>
        /// <param name="pClientSite">
        /// Pointer to the <see cref="IOleClientSite"/> interface on the client site object being loaded.
        /// </param>
        /// <param name="ppvObj">
        /// Address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>.
        /// Upon successful return, *<paramref name="ppvObj"/> contains the requested interface pointer on the newly loaded object.
        /// </param>
        /// <returns>
        /// This function returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="E_NOINTERFACE"/>: The object does not support the specified interface.
        /// Additionally, this function can return any of the error values returned by the <see cref="IPersistStorage.Load"/> method.
        /// </returns>
        /// <remarks>
        /// OLE containers load objects into memory by calling this function.
        /// When calling the OleLoad function, the container application passes
        /// in a pointer to the open storage object in which the nested object is stored.
        /// Typically, the nested object to be loaded is a child storage object to the container's root storage object.
        /// Using the OLE information stored with the object, the object handler (usually, the default handler) attempts to load the object.
        /// On completion of the OleLoad function, the object is said to be in the loaded state with its object application not running.
        /// Some applications load all of the object's native data. Containers often defer loading the contained objects until required to do so.
        /// For example, until an object is scrolled into view and needs to be drawn, it does not need to be loaded.
        /// The <see cref="OleLoad"/> function performs the following steps:
        /// If necessary, performs an automatic conversion of the object (see the <see cref="OleDoAutoConvert"/> function).
        /// Gets the <see cref="CLSID"/> from the open storage object by calling the <see cref="IStorage.Stat"/> method.
        /// Calls the <see cref="CoCreateInstance"/> function to create an instance of the handler.
        /// If the handler code is not available, the default handler is used (see the <see cref="OleCreateDefaultHandler"/> function).
        /// Calls the <see cref="IOleObject.SetClientSite"/> method with the <paramref name="pClientSite"/> parameter
        /// to inform the object of its client site.
        /// Calls the QueryInterface method for the <see cref="IPersistStorage"/> interface.
        /// If successful, the <see cref="IPersistStorage.Load"/> method is invoked for the object.
        /// Queries and returns the interface identified by the <paramref name="riid"/> parameter.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "OleLoad", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT OleLoad([In] IStorage pStg, [In] in IID riid, [In] IOleClientSite pClientSite, [Out] out LPVOID ppvObj);

        /// <summary>
        /// <para>
        /// Saves an object opened in transacted mode into the specified storage object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olesave"/>
        /// </para>
        /// </summary>
        /// <param name="pPS">
        /// Pointer to the <see cref="IPersistStorage"/> interface on the object to be saved.
        /// </param>
        /// <param name="pStg">
        /// Pointer to the <see cref="IStorage"/> interface on the destination storage object
        /// to which the object indicated in <paramref name="pPS"/> is to be saved.
        /// </param>
        /// <param name="fSameAsLoad">
        /// <see cref="TRUE"/> indicates that pStg is the same storage object from which the object was loaded or created;
        /// <see cref="FALSE"/> indicates that pStg was loaded or created from a different storage object.
        /// </param>
        /// <returns>
        /// This function returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="STGMEDIUM_E_FULL"/>:
        /// The object could not be saved due to lack of disk space.
        /// This function can also return any of the error values returned by the <see cref="IPersistStorage.Save"/> method.
        /// </returns>
        /// <remarks>
        /// The <see cref="OleSave"/> helper function handles the common situation in which an object is open in transacted mode
        /// and is then to be saved into the specified storage object which uses the OLE-provided compound file implementation.
        /// Transacted mode means that changes to the object are buffered
        /// until either of the <see cref="IStorage.Commit"/> or <see cref="IStorage.Revert"/> is called.
        /// Callers can handle other situations by calling the <see cref="IPersistStorage"/> and <see cref="IStorage"/> interfaces directly.
        /// <see cref="OleSave"/> does the following:
        /// Calls the <see cref="IPersist.GetClassID"/> method to get the CLSID of the object.
        /// Writes the CLSID to the storage object using the <see cref="WriteClassStg"/> function.
        /// Calls the <see cref="IPersistStorage.Save"/> method to save the object.
        /// If there were no errors on the save; calls the <see cref="IStorage.Commit"/>::Commit method to commit the changes.
        /// Note
        /// Static objects are saved into a stream called CONTENTS.
        /// Static metafile objects get saved in "placeable metafile format" and static DIB data gets saved in "DIB file format."
        /// These formats are defined to be the OLE standards for metafile and DIB.All data transferred using an <see cref="IStream"/> interface
        /// or a file (that is, via <see cref="IDataObject.GetDataHere"/>) must be in these formats.
        /// Also, all objects whose default file format is a metafile or DIB must write their data into a CONTENTS stream using these standard formats.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "OleSave", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT OleSave([In] IPersistStorage pPS, [In] IStorage pStg, [In] BOOL fSameAsLoad);

        /// <summary>
        /// <para>
        /// Closes the COM library on the apartment, releases any class factories, other COM objects,
        /// or servers held by the apartment, disables RPC on the apartment, and frees any resources the apartment maintains.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleuninitialize"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Call <see cref="OleUninitialize"/> on application shutdown, as the last COM library call,
        /// if the apartment was initialized with a call to <see cref="OleInitialize"/>.
        /// <see cref="OleUninitialize"/> calls the <see cref="CoUninitialize"/> function internally to shut down the OLE Component Object(COM) Library.
        /// If the COM library was initialized on the apartment with a call to <see cref="CoInitialize"/> or <see cref="CoInitializeEx"/>,
        /// it must be closed with a call to <see cref="CoUninitialize"/>.
        /// The <see cref="OleInitialize"/> and <see cref="OleUninitialize"/> calls must be balanced
        /// if there are multiple calls to the <see cref="OleInitialize"/> function,
        /// there must be the same number of calls to <see cref="OleUninitialize"/>;
        /// only the <see cref="OleUninitialize"/> call corresponding to the <see cref="OleInitialize"/> call
        /// that actually initialized the library can close it.
        /// Because there is no way to control the order in which in-process servers are loaded or unloaded,
        /// do not call <see cref="OleInitialize"/> or <see cref="OleUninitialize"/> from the DllMain function.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "OleUninitialize", ExactSpelling = true, SetLastError = true)]
        public static extern void OleUninitialize();

        /// <summary>
        /// <para>
        /// Frees the specified storage medium.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-releasestgmedium"/>
        /// </para>
        /// </summary>
        /// <param name="LPSTGMEDIUM">
        /// Pointer to the storage medium that is to be freed.
        /// </param>
        /// <remarks>
        /// The <see cref="ReleaseStgMedium"/> function calls the appropriate method or function to release the specified storage medium.
        /// Use this function during data transfer operations where storage medium structures are parameters,
        /// such as <see cref="IDataObject.GetData"/> or <see cref="IDataObject.SetData"/>.
        /// In addition to identifying the type of the storage medium,
        /// this structure specifies the appropriate Release method for releasing the storage medium when it is no longer needed.
        /// It is common to pass a <see cref="STGMEDIUM"/> from one body of code to another, such as in <see cref="IDataObject.GetData"/>,
        /// in which the one called can allocate a medium and return it to the caller.
        /// <see cref="ReleaseStgMedium"/> permits flexibility in whether the receiving body of code owns the medium,
        /// or whether the original provider of the medium still owns it,
        /// in which case the receiving code needs to inform the provider that it can free the medium.
        /// When the original provider of the medium is responsible for freeing the medium, the provider calls <see cref="ReleaseStgMedium"/>,
        /// specifying the medium and the appropriate <see cref="IUnknown"/> pointer as the <see cref="STGMEDIUM.pUnkForRelease"/> structure member.
        /// Depending on the type of storage medium being freed, one of the following actions is taken,
        /// followed by a call to the IUnknown::Release method on the specified <see cref="IUnknown"/> pointer.
        /// Medium                          <see cref="ReleaseStgMedium"/> Action
        /// <see cref="TYMED_HGLOBAL"/>     None.
        /// <see cref="TYMED_GDI"/>         None.
        /// <see cref="TYMED_ENHMF"/>       None.
        /// <see cref="TYMED_MFPICT"/>      None.
        /// <see cref="TYMED_FILE"/>        Frees the file name string using standard memory management mechanisms.
        /// <see cref="TYMED_ISTREAM"/>     Calls IStream::Release.
        /// <see cref="TYMED_ISTORAGE"/>    Calls IStorage::Release.
        /// The provider indicates that the receiver of the medium is responsible for freeing the medium
        /// by specifying <see cref="NULL"/> for the <see cref="STGMEDIUM.pUnkForRelease"/> structure member.
        /// Then the receiver calls <see cref="ReleaseStgMedium"/>, which makes a call as described
        /// in the following table depending on the type of storage medium being freed.
        /// Medium                          <see cref="ReleaseStgMedium"/> Action
        /// <see cref="TYMED_HGLOBAL"/>     Calls the <see cref="GlobalFree"/> function on the handle.
        /// <see cref="TYMED_GDI"/>         Calls the <see cref="DeleteObject"/> function on the handle.
        /// <see cref="TYMED_ENHMF"/>       Deletes the enhanced metafile.
        /// <see cref="TYMED_MFPICT"/>      The hMF that it contains is deleted with the <see cref="DeleteMetaFile"/> function;
        ///                                 then the handle itself is passed to <see cref="GlobalFree"/>.
        /// <see cref="TYMED_FILE"/>        Frees the disk file by deleting it. 
        ///                                 Frees the file name string by using the standard memory management mechanisms.
        /// <see cref="TYMED_ISTREAM"/>     Calls IStream::Release.
        /// <see cref="TYMED_ISTORAGE"/>    Calls IStorage::Release.
        /// In either case, after the call to <see cref="ReleaseStgMedium"/>, the specified storage medium is invalid and can no longer be used.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseStgMedium", ExactSpelling = true, SetLastError = true)]
        public static extern void ReleaseStgMedium([In] in STGMEDIUM LPSTGMEDIUM);

        /// <summary>
        /// <para>
        /// The <see cref="StgCreateStorageEx"/> function creates a new storage object using a provided implementation
        /// for the <see cref="IStorage"/> or <see cref="IPropertySetStorage"/> interfaces.
        /// To open an existing file, use the <see cref="StgOpenStorageEx"/> function instead.
        /// Applications written for Windows 2000, Windows Server 2003 and Windows XP must use <see cref="StgCreateStorageEx"/>
        /// rather than <see cref="StgCreateDocfile"/> to take advantage of the enhanced Windows 2000 and Windows XP Structured Storage features.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/coml2api/nf-coml2api-stgcreatestorageex"/>
        /// </para>
        /// </summary>
        /// <param name="pwcsName">
        /// A pointer to the path of the file to create. It is passed uninterpreted to the file system.
        /// This can be a relative name or <see langword="null"/>.
        /// If <see langword="null"/>, a temporary file is allocated with a unique name.
        /// If non-NULL, the string size must not exceed <see cref="MAX_PATH"/> characters.
        /// Windows 2000: Unlike the <see cref="CreateFile"/> function, you cannot exceed the <see cref="MAX_PATH"/> limit by using the "\?" prefix.
        /// </param>
        /// <param name="grfMode">
        /// A value that specifies the access mode to use when opening the new storage object.
        /// For more information, see <see cref="STGM"/> Constants.
        /// If the caller specifies transacted mode together with <see cref="STGM_CREATE"/> or <see cref="STGM_CONVERT"/>,
        /// the overwrite or conversion takes place when the commit operation is called for the root storage.
        /// If <see cref="IStorage.Commit"/> is not called for the root storage object, previous contents of the file will be restored.
        /// <see cref="STGM_CREATE"/> and <see cref="STGM_CONVERT"/> cannot be combined with the <see cref="STGM_NOSNAPSHOT"/> flag,
        /// because a snapshot copy is required when a file is overwritten or converted in the transacted mode.
        /// </param>
        /// <param name="stgfmt">
        /// A value that specifies the storage file format.
        /// For more information, see the <see cref="STGFMT"/> enumeration.
        /// </param>
        /// <param name="grfAttrs">
        /// A value that depends on the value of the <paramref name="stgfmt"/> parameter.
        /// <see cref="STGFMT_DOCFILE"/>:
        /// 0, or <see cref="FILE_FLAG_NO_BUFFERING"/>.
        /// For more information, see <see cref="CreateFile"/>.
        /// If the sector size of the file, specified in <paramref name="pStgOptions"/>,
        /// is not an integer multiple of the underlying disk's physical sector size, this operation will fail.
        /// All other values of <paramref name="stgfmt"/>:
        /// Must be 0. 
        /// </param>
        /// <param name="pStgOptions">
        /// The <paramref name="pStgOptions"/> parameter is valid only if the stgfmt parameter is set to <see cref="STGFMT_DOCFILE"/>.
        /// If the stgfmt parameter is set to <see cref="STGFMT_DOCFILE"/>, <paramref name="pStgOptions"/> points
        /// to the <see cref="STGOPTIONS"/> structure, which specifies features of the storage object, such as the sector size.
        /// This parameter may be <see cref="NullRef{STGOPTIONS}"/>, which creates a storage object with a default sector size of 512 bytes.
        /// If non-NULL, the ulSectorSize member must be set to either 512 or 4096.
        /// If set to 4096, <see cref="STGM_SIMPLE"/> may not be specified in the <paramref name="grfMode"/> parameter.
        /// The usVersion member must be set before calling <see cref="StgCreateStorageEx"/>.
        /// For more information, see <see cref="STGOPTIONS"/>.
        /// </param>
        /// <param name="pSecurityDescriptor">
        /// Enables the ACLs to be set when the file is created.
        /// If not <see cref="NULL"/>, needs to be a pointer to the <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// See <see cref="CreateFile"/> for information on how to set ACLs on files.
        /// Windows Server 2003, Windows 2000 Server, Windows XP and Windows 2000 Professional: Value must be <see cref="NULL"/>.
        /// </param>
        /// <param name="riid">
        /// A value that specifies the interface identifier (IID) of the interface pointer to return.
        /// This IID may be for the <see cref="IStorage"/> interface or the <see cref="IPropertySetStorage"/> interface.
        /// </param>
        /// <param name="ppObjectOpen">
        /// A pointer to an interface pointer variable that receives a pointer for an interface on the new storage object;
        /// contains <see cref="NULL"/> if operation failed.
        /// </param>
        /// <returns>
        /// This function can also return any file system errors or system errors wrapped in an <see cref="HRESULT"/>.
        /// For more information, see Error Handling Strategies and Handling Unknown Errors.
        /// </returns>
        /// <remarks>
        /// When an application modifies its file, it usually creates a copy of the original.
        /// The <see cref="StgCreateStorageEx"/> function is one way for creating a copy.
        /// This function works indirectly with the Encrypting File System (EFS) duplication API.
        /// When you use this function, you will need to set the options for the file storage in the <see cref="STGOPTIONS"/> structure.
        /// <see cref="StgCreateStorageEx"/> is a superset of the <see cref="StgCreateDocfile"/> function, and should be used by new code.
        /// Future enhancements to Structured Storage will be exposed through the <see cref="StgCreateStorageEx"/> function.
        /// See the following Requirements section for information on supported platforms.
        /// The <see cref="StgCreateStorageEx"/> function creates a new storage object
        /// using one of the system-provided, structured-storage implementations.
        /// This function can be used to obtain an <see cref="IStorage"/> compound file implementation,
        /// an <see cref="IPropertySetStorage"/> compound file implementation, or to obtain an <see cref="IPropertySetStorage"/> NTFS implementation.
        /// When a new file is created, the storage implementation used depends on the flag
        /// that you specify and on the type of drive on which the file is stored.
        /// For more information, see the <see cref="STGFMT"/> enumeration.
        /// <see cref="StgCreateStorageEx"/> creates the file if it does not exist.
        /// If it does exist, the use of the <see cref="STGM_CREATE"/>, <see cref="STGM_CONVERT"/>,
        /// and <see cref="STGM_FAILIFTHERE"/> flags in the grfMode parameter indicate how to proceed.
        /// For more information on these values, see <see cref="STGM"/> Constants.
        /// It is not valid, in direct mode, to specify the <see cref="STGM_READ"/> mode in the <paramref name="grfMode"/> parameter
        /// (direct mode is indicated by not specifying the <see cref="STGM_TRANSACTED"/> flag).
        /// This function cannot be used to open an existing file; use the <see cref="StgOpenStorageEx"/> function instead.
        /// You can use the <see cref="StgCreateStorageEx"/> function to get access to the root storage of a structured-storage document
        /// or the property set storage of any file that supports property sets.
        /// See the <see cref="STGFMT"/> documentation for information about which IIDs are supported for different <see cref="STGFMT"/> values.
        /// When a file is created with this function to access the NTFS property set implementation, special sharing rules apply.
        /// For more information, see IPropertySetStorage-NTFS Implementation.
        /// If a compound file is created in transacted mode (by specifying <see cref="STGM_TRANSACTED"/>)
        /// and read-only mode (by specifying <see cref="STGM_READ"/>), it is possible to make changes to the returned storage object.
        /// For example, it is possible to call <see cref="IStorage.CreateStream"/>.
        /// However, it is not possible to commit those changes by calling <see cref="IStorage.Commit"/>.
        /// Therefore, such changes will be lost.
        /// Specifying <see cref="STGM_SIMPLE"/> provides a much faster implementation of a compound file object in a limited,
        /// but frequently used case involving applications that require a compound file implementation with multiple streams and no storages.
        /// For more information, see <see cref="STGM"/> Constants.
        /// It is not valid to specify that <see cref="STGM_TRANSACTED"/> if <see cref="STGM_SIMPLE"/> is specified.
        /// The simple mode does not support all the methods on <see cref="IStorage"/>.
        /// Specifically, in simple mode, supported <see cref="IStorage"/> methods are <see cref="IStorage.CreateStream"/>,
        /// <see cref="IStorage.Commit"/>, and <see cref="IStorage.SetClass"/> as well as
        /// the COM <see cref="IUnknown"/> methods of QueryInterface, AddRef and Release.
        /// In addition, <see cref="SetElementTimes"/> is supported with a NULL name, allowing applications to set times on a root storage.
        /// All the other methods of <see cref="IStorage"/> return <see cref="STG_E_INVALIDFUNCTION"/>.
        /// If the <paramref name="grfMode"/> parameter specifies <see cref="STGM_TRANSACTED"/>
        /// and no file yet exists with the name specified by the <paramref name="pwcsName"/> parameter, the file is created immediately.
        /// In an access-controlled file system, the caller must have write permissions
        /// for the file system directory in which the compound file is created.
        /// If <see cref="STGM_TRANSACTED"/> is not specified, and <see cref="STGM_CREATE"/> is specified,
        /// an existing file with the same name is destroyed before creating the new file.
        /// You can also use <see cref="StgCreateStorageEx"/> to create a temporary compound file
        /// by passing a <see langword="null"/> value for the <paramref name="pwcsName"/> parameter.
        /// However, these files are temporary only in the sense that
        /// they have a unique system-provided name – one that is probably meaningless to the user.
        /// The caller is responsible for deleting the temporary file when finished with it,
        /// unless <see cref="STGM_DELETEONRELEASE"/> was specified for the <paramref name="grfMode"/> parameter.
        /// For more information on these flags, see <see cref="STGM"/> Constants.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "StgCreateStorageEx", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT StgCreateStorageEx([MarshalAs(UnmanagedType.LPWStr)][In] string pwcsName,
            [In] STGM grfMode, [In] STGFMT stgfmt, [In] DWORD grfAttrs, [In] in STGOPTIONS pStgOptions,
            [In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] in IID riid, [Out] out IntPtr ppObjectOpen);

        /// <summary>
        /// <para>
        /// The <see cref="StgOpenStorage"/> function opens an existing root storage object in the file system.
        /// Use this function to open compound files. Do not use it to open directories, files, or summary catalogs.
        /// Nested storage objects can only be opened using their parent <see cref="IStorage.OpenStorage"/> method.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/coml2api/nf-coml2api-stgopenstorage"/>
        /// </para>
        /// </summary>
        /// <param name="pwcsName">
        /// A pointer to the path of the null-terminated Unicode string file that contains the storage object to open.
        /// This parameter is ignored if the <paramref name="pstgPriority"/> parameter is not <see langword="null"/>.
        /// </param>
        /// <param name="pstgPriority">
        /// A pointer to the <see cref="IStorage"/> interface that should be <see langword="null"/>.
        /// If not NULL, this parameter is used as described below in the Remarks section.
        /// After <see cref="StgOpenStorage"/> returns, the storage object
        /// specified in <paramref name="pstgPriority"/> may have been released and should no longer be used.
        /// </param>
        /// <param name="grfMode">
        /// Specifies the access mode to use to open the storage object.
        /// </param>
        /// <param name="snbExclude">
        /// If not <see langword="null"/>, pointer to a block of elements in the storage to be excluded as the storage object is opened.
        /// The exclusion occurs regardless of whether a snapshot copy happens on the open.
        /// Can be <see langword="null"/>.
        /// </param>
        /// <param name="reserved">
        /// Indicates reserved for future use; must be zero.
        /// </param>
        /// <param name="ppstgOpen">
        /// A pointer to a <see cref="IStorage"/> pointer variable that receives the interface pointer to the opened storage.
        /// </param>
        /// <returns>
        /// The <see cref="StgOpenStorage"/> function can also return any file system errors or system errors wrapped in an <see cref="HRESULT"/>.
        /// For more information, see Error Handling Strategies and Handling Unknown Errors.
        /// </returns>
        /// <remarks>
        /// The <see cref="StgOpenStorage"/> function opens the specified root storage object according to the access mode
        /// in the <paramref name="grfMode"/> parameter, and, if successful, supplies an <see cref="IStorage"/> pointer
        /// to the opened storage object in the <paramref name="ppstgOpen"/> parameter.
        /// To support the simple mode for saving a storage object with no substorages,
        /// the <see cref="StgOpenStorage"/> function accepts one of the following two flag combinations
        /// as valid modes in the <paramref name="grfMode"/> parameter.
        /// <code>STGM_SIMPLE | STGM_READWRITE | STGM_SHARE_EXCLUSIVE</code>
        /// <code>STGM_SIMPLE | STGM_READ | STGM_SHARE_EXCLUSIVE</code>
        /// To support the single-writer, multireader, direct mode,
        /// the first flag combination is the valid <paramref name="grfMode"/> parameter for the writer.
        /// The second flag combination is valid for readers.
        /// <code>STGM_DIRECT_SWMR | STGM_READWRITE | STGM_SHARE_DENY_WRITE</code>
        /// <code>STGM_DIRECT_SWMR | STGM_READ | STGM_SHARE_DENY_NONE</code>
        /// In direct mode, one of the following three combinations are valid.
        /// <code>STGM_DIRECT | STGM_READWRITE | STGM_SHARE_EXCLUSIVE</code>
        /// <code>STGM_DIRECT | STGM_READ | STGM_SHARE_DENY_WRITE</code>
        /// <code>STGM_DIRECT | STGM_READ | STGM_SHARE_EXCLUSIVE</code>
        /// Note  Opening a storage object in read/write mode without denying write permission to others
        /// (the <paramref name="grfMode"/> parameter specifies <see cref="STGM_SHARE_DENY_WRITE"/>) can be a time-consuming operation
        /// because the <see cref="StgOpenStorage"/> call must make a snapshot of the entire storage object.
        /// Applications often try to open storage objects with the following access permissions.
        /// If the application succeeds, it never needs to make a snapshot copy. 
        /// <code>STGM_READWRITE | STGM_SHARE_DENY_WRITE // transacted versus direct mode omitted for exposition </code>
        /// The application can revert to using the permissions and make a snapshot copy, if the previous access permissions fail.
        /// The application should prompt the user before making a time-consuming copy.
        /// <code>STGM_READWRITE // transacted versus direct mode omitted for exposition </code>
        /// If the document-sharing semantics implied by the access modes are appropriate, the application could try to open the storage as follows.
        /// In this case, if the application succeeds, a snapshot copy will not have been made
        /// (because <see cref="STGM_SHARE_DENY_WRITE"/> was specified, denying others write access).
        /// <code>STGM_READ | STGM_SHARE_DENY_WRITE// transacted versus direct mode omitted for exposition </code>
        /// Note
        /// To reduce the expense of making a snapshot copy, applications can open storage objects in priority mode
        /// (<paramref name="grfMode"/> specifies <see cref="STGM_PRIORITY"/>).
        /// The <paramref name="snbExclude"/> parameter specifies a set of element names in this storage object
        /// that are to be emptied as the storage object is opened:
        /// streams are set to a length of zero; storage objects have all their elements removed.
        /// By excluding certain streams, the expense of making a snapshot copy can be significantly reduced.
        /// Almost always, this approach is used after first opening the storage object in priority mode,
        /// then completely reading the now-excluded elements into memory.
        /// This earlier priority-mode opening of the storage object should be passed
        /// through the <paramref name="pstgPriority"/> parameter to remove the exclusion implied by priority mode.
        /// The calling application is responsible for rewriting the contents of excluded items before committing.
        /// Thus, this technique is most likely useful only to applications
        /// whose documents do not require constant access to their storage objects while they are active.
        /// The <paramref name="pstgPriority"/> parameter is intended as a convenience for callers replacing an existing storage object,
        /// often one opened in priority mode, with a new storage object opened on the same file but in a different mode.
        /// When <paramref name="pstgPriority"/> is not <see langword="null"/>, it is used to specify the file name
        /// instead of <paramref name="pwcsName"/>, which is ignored.
        /// However, it is recommended that applications always pass <see langword="null"/> for <paramref name="pstgPriority"/>
        /// because <see cref="StgOpenStorage"/> releases the object under some circumstances, and does not release it under other circumstances.
        /// In particular, if the function returns a failure result, it is not possible for the caller to determine whether or not the storage object was released.
        /// The functionality of the <paramref name="pstgPriority"/> parameter can be duplicated by the caller in a safer manner
        /// as shown in the following example:
        /// <code>
        /// // Replacement for:
        /// HRESULT hr = StgOpenStorage(NULL, pstgPriority, grfMode, NULL, 0, &amp;pstgNew);
        /// STATSTG statstg;
        /// HRESULT hr = pstgPriority->Stat(&amp;statstg, 0);
        /// pStgPriority->Release();
        /// pStgPriority = NULL;
        /// if (SUCCEEDED(hr))
        /// {
        ///     hr = StgOpenStorage(statstg.pwcsName, NULL, grfMode, NULL, 0, &amp;pstgNew);
        /// }
        /// </code>
        /// </remarks>
        [Obsolete("Applications should use the new function, StgOpenStorageEx, instead of StgOpenStorage," +
                "to take advantage of the enhanced and Windows Structured Storage features." +
                "This function, StgOpenStorage, still exists for compatibility with applications running on Windows 2000.")]
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "StgOpenStorage", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT StgOpenStorage([MarshalAs(UnmanagedType.LPWStr)][In] string pwcsName,
            [MarshalAs(UnmanagedType.Interface)][In] IStorage pstgPriority, [In] STGM grfMode,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)][In] string[] snbExclude,
            [In] DWORD reserved, [MarshalAs(UnmanagedType.Interface)][Out] out IStorage ppstgOpen);

        /// <summary>
        /// <para>
        /// The <see cref="StgOpenStorageEx"/> function opens an existing root storage object in the file system.
        /// Use this function to open Compound Files and regular files.
        /// To create a new file, use the <see cref="StgCreateStorageEx"/> function.
        /// Note
        /// To use enhancements, all Windows 2000, Windows XP, and Windows Server 2003 applications
        /// should call <see cref="StgOpenStorageEx"/>, instead of <see cref="StgOpenStorage"/>.
        /// The <see cref="StgOpenStorage"/> function is used for compatibility with Windows 2000 and earlier applications.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/coml2api/nf-coml2api-stgopenstorageex"/>
        /// </para>
        /// </summary>
        /// <param name="pwcsName">
        /// A pointer to the path of the null-terminated Unicode string file that contains the storage object.
        /// This string size cannot exceed <see cref="MAX_PATH"/> characters.
        /// Windows Server 2003 and Windows XP/2000:
        /// Unlike the <see cref="CreateFile"/> function, the <see cref="MAX_PATH"/> limit cannot be exceeded by using the "\?" prefix.
        /// </param>
        /// <param name="grfMode">
        /// A value that specifies the access mode to open the new storage object.
        /// For more information, see <see cref="STGM"/> Constants.
        /// If the caller specifies transacted mode together with <see cref="STGM_CREATE"/> or <see cref="STGM_CONVERT"/>,
        /// the overwrite or conversion occurs when the commit operation is called for the root storage.
        /// If <see cref="IStorage.Commit"/> is not called for the root storage object, previous contents of the file will be restored.
        /// <see cref="STGM_CREATE"/> and <see cref="STGM_CONVERT"/> cannot be combined with the <see cref="STGM_NOSNAPSHOT"/> flag,
        /// because a snapshot copy is required when a file is overwritten or converted in transacted mode.
        /// If the storage object is opened in direct mode (<see cref="STGM_DIRECT"/>) with access
        /// to either <see cref="STGM_WRITE"/> or <see cref="STGM_READWRITE"/>,
        /// the sharing mode must be <see cref="STGM_SHARE_EXCLUSIVE"/> unless the <see cref="STGM_DIRECT_SWMR"/> mode is specified.
        /// For more information, see the Remarks section.
        /// If the storage object is opened in direct mode with access to <see cref="STGM_READ"/>,
        /// the sharing mode must be either <see cref="STGM_SHARE_EXCLUSIVE"/> or <see cref="STGM_SHARE_DENY_WRITE"/>,
        /// unless <see cref="STGM_PRIORITY"/> or <see cref="STGM_DIRECT_SWMR"/> is specified.
        /// For more information, see the Remarks section.
        /// The mode in which a file is opened can affect implementation performance.
        /// For more information, see Compound File Implementation Limits.
        /// </param>
        /// <param name="stgfmt">
        /// A value that specifies the storage file format.
        /// For more information, see the <see cref="STGFMT"/> enumeration.
        /// </param>
        /// <param name="grfAttrs">
        /// A value that depends upon the value of the <paramref name="stgfmt"/> parameter.
        /// <see cref="STGFMT_DOCFILE"/> must be zero(0) or <see cref="FILE_FLAG_NO_BUFFERING"/>.
        /// For more information about this value, see <see cref="CreateFile"/>.
        /// If the sector size of the file, specified in <paramref name="pStgOptions"/>, is not an integer multiple of the physical sector size
        /// of the underlying disk, then this operation will fail.
        /// All other values of <paramref name="stgfmt"/> must be zero.
        /// </param>
        /// <param name="pStgOptions">
        /// A pointer to an <see cref="STGOPTIONS"/> structure that contains data about the storage object opened.
        /// The <paramref name="pStgOptions"/> parameter is valid only if the <paramref name="stgfmt"/> parameter is set to <see cref="STGFMT_DOCFILE"/>.
        /// The <see cref="STGOPTIONS.usVersion"/> member must be set before calling <see cref="StgOpenStorageEx"/>.
        /// For more information, see the <see cref="STGOPTIONS"/> structure.
        /// </param>
        /// <param name="pSecurityDescriptor">
        /// Reserved; must be zero.
        /// </param>
        /// <param name="riid">
        /// A value that specifies the GUID of the interface pointer to return.
        /// Can also be the header-specified value for <see cref="IID_IStorage"/> to obtain the <see cref="IStorage"/> interface
        /// or for <see cref="IID_IPropertySetStorage"/> to obtain the <see cref="IPropertySetStorage"/> interface.
        /// </param>
        /// <param name="ppObjectOpen">
        /// The address of an interface pointer variable that receives a pointer for an interface on the storage object opened;
        /// contains <see cref="NULL"/> if operation failed.
        /// </param>
        /// <returns>
        /// This function can also return any file system errors or system errors wrapped in an <see cref="HRESULT"/>.
        /// For more information, see Error Handling Strategies and Handling Unknown Errors.
        /// </returns>
        /// <remarks>
        /// StgOpenStorageEx is a superset of the <see cref="StgOpenStorage"/> function, and should be used by new code.
        /// Future enhancements to structured storage will be exposed through this function.
        /// For more information about supported platforms, see the Requirements section.
        /// The <see cref="StgOpenStorageEx"/> function opens the specified root storage object according to
        /// the access mode in the <paramref name="grfMode"/> parameter, and, if successful,
        /// supplies an interface pointer for the opened storage object in the <paramref name="ppObjectOpen"/> parameter.
        /// This function can be used to obtain an <see cref="IStorage"/> compound file implementation,
        /// an <see cref="IPropertySetStorage"/> compound file implementation, or an NTFS file system implementation of <see cref="IPropertySetStorage"/>.
        /// When you open a file, the system selects a structured storage implementation depending on which <see cref="STGFMT"/> flag
        /// you specify on the file type and on the type of drive where the file is stored.
        /// Use the <see cref="StgOpenStorageEx"/> function to access the root storage of a structured storage document
        /// or the property set storage of any file that supports property sets.
        /// For more information about which interface identifiers (IIDs) are supported
        /// for the different <see cref="STGFMT"/> values, see <see cref="STGFMT"/>.
        /// When a file is opened with this function to access the NTFS property set implementation, special sharing rules apply.
        /// For more information, see IPropertySetStorage-NTFS Implementation.
        /// If a compound file is opened in transacted mode, by specifying <see cref="STGM_TRANSACTED"/>,
        /// and read-only mode, by specifying <see cref="STGM_READ"/>, it is possible to change the returned storage object.
        /// For example, it is possible to call <see cref="IStorage.CreateStorage"/>.
        /// However, it is not possible to commit those changes by calling <see cref="IStorage.Commit"/>.
        /// Therefore, such changes will be lost.
        /// It is not valid to use the <see cref="STGM_CREATE"/>, <see cref="STGM_DELETEONRELEASE"/>,
        /// or <see cref="STGM_CONVERT"/> flags in the <paramref name="grfMode"/> parameter for this function.
        /// To support the simple mode for saving a storage object with no substorages,
        /// the <see cref="StgOpenStorageEx"/> function accepts one of the following two flag
        /// combinations as valid modes in the <paramref name="grfMode"/> parameter:
        /// <code>STGM_SIMPLE | STGM_READWRITE | STGM_SHARE_EXCLUSIVE</code>
        /// <code>STGM_SIMPLE | STGM_READ | STGM_SHARE_EXCLUSIVE</code>
        /// To support the single-writer, multireader, direct mode, the first flag combination
        /// is the valid <paramref name="grfMode"/> parameter for the writer.
        /// The second flag combination is valid for readers.
        /// <code>STGM_DIRECT_SWMR | STGM_READWRITE | STGM_SHARE_DENY_WRITE</code>
        /// <code>STGM_DIRECT_SWMR | STGM_READ | STGM_SHARE_DENY_NONE</code>
        /// For more information about simple mode and single-writer/multiple-reader modes, see <see cref="STGM"/> Constants.
        /// Note
        /// Opening a transacted mode storage object in read and/or write mode without denying write permissions to others
        /// (for example, the <paramref name="grfMode"/> parameter specifies <see cref="STGM_SHARE_DENY_WRITE"/>) can be time-consuming
        /// because the <see cref="StgOpenStorageEx"/> call must create a snapshot copy of the entire storage object.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "StgOpenStorageEx", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT StgOpenStorageEx([MarshalAs(UnmanagedType.LPWStr)][In] string pwcsName,
            [In] STGM grfMode, [In] STGFMT stgfmt, [In] DWORD grfAttrs, [In] in STGOPTIONS pStgOptions,
            [In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In] in IID riid, [Out] out IntPtr ppObjectOpen);

        /// <summary>
        /// <para>
        /// Converts a <see cref="CLSID"/> into a string of printable characters.
        /// Different CLSIDs always convert to different strings.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-stringfromclsid"/>
        /// </para>
        /// </summary>
        /// <param name="rclsid">
        /// The <see cref="CLSID"/> to be converted.
        /// </param>
        /// <param name="lplpsz">
        /// The address of a pointer variable that receives a pointer to the resulting string.
        /// The string that represents <paramref name="rclsid"/> includes enclosing braces.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="StringFromCLSID"/> calls the <see cref="StringFromGUID2"/> function
        /// to convert a globally unique identifier (GUID) into a string of printable characters.
        /// The caller is responsible for freeing the memory allocated for the string by calling the <see cref="CoTaskMemFree"/> function.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "StringFromCLSID", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT StringFromCLSID([In] in CLSID rclsid, [Out] out IntPtr lplpsz);

        /// <summary>
        /// <para>
        /// Converts a globally unique identifier (GUID) into a string of printable characters.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-stringfromguid2"/>
        /// </para>
        /// </summary>
        /// <param name="rguid">
        /// The <see cref="GUID"/> to be converted.
        /// </param>
        /// <param name="lpsz">
        /// A pointer to a caller-allocated string variable to receive the resulting string.
        /// The string that represents rguid includes enclosing braces.
        /// </param>
        /// <param name="cchMax">
        /// The number of characters available in the <paramref name="lpsz"/> buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters in the returned string, including the null terminator.
        /// If the buffer is too small to contain the string, the return value is 0.
        /// </returns>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "StringFromGUID2", ExactSpelling = true, SetLastError = true)]
        public static extern int StringFromGUID2([In] in GUID rguid, [Out] LPOLESTR lpsz, [In] int cchMax);

        /// <summary>
        /// <para>
        /// Converts an interface identifier into a string of printable characters.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-stringfromiid"/>
        /// </para>
        /// </summary>
        /// <param name="rclsid">
        /// The interface identifier to be converted.
        /// </param>
        /// <param name="lplpsz">
        /// The address of a pointer variable that receives a pointer to the resulting string.
        /// The string that represents rclsid includes enclosing braces.
        /// </param>
        /// <returns>
        /// This function can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// The caller is responsible for freeing the memory allocated for the string by calling the <see cref="CoTaskMemFree"/> function.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "StringFromIID", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT StringFromIID([In] in IID rclsid, [Out] out LPOLESTR lplpsz);

        /// <summary>
        /// <para>
        /// The <see cref="WriteClassStg"/> function stores the specified class identifier (CLSID) in a storage object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/coml2api/nf-coml2api-writeclassstg"/>
        /// </para>
        /// </summary>
        /// <param name="pStg">
        /// <see cref="IStorage"/> pointer to the storage object that gets a new CLSID.
        /// </param>
        /// <param name="rclsid">
        /// Pointer to the <see cref="CLSID"/> to be stored with the object.
        /// </param>
        /// <returns>
        /// This function returns <see cref="HRESULT"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="WriteClassStg"/> function writes a <see cref="CLSID"/> to the specified storage object
        /// so that it can be read by the <see cref="ReadClassStg"/> function.
        /// Container applications typically call this function before calling the <see cref="IPersistStorage.Save"/> method.
        /// </remarks>
        [DllImport("Ole32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteClassStg", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT WriteClassStg([In] in IStorage pStg, [In] in CLSID rclsid);
    }
}
