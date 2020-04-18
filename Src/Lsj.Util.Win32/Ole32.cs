using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CLSCTX;
using static Lsj.Util.Win32.Enums.COINIT;
using static Lsj.Util.Win32.Enums.EOLE_AUTHENTICATION_CAPABILITIES;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Ole32.dll
    /// </summary>
    public static class Ole32
    {
        /// <summary>
        /// Locates an object by means of its moniker, activates the object if it is inactive,
        /// and retrieves a pointer to the specified interface on that object.
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
        public static extern HRESULT BindMoniker([In]IMoniker pmk, [In]uint grfOpt, [MarshalAs(UnmanagedType.LPStruct)][In]Guid iidResult,
            [MarshalAs(UnmanagedType.IUnknown)][Out]object ppvResult);

        /// <summary>
        /// <para>
        /// Creates a single uninitialized object of the class associated with a specified CLSID.
        /// Call <see cref="CoCreateInstance"/> when you want to create only one object on the local system.
        /// To create a single object on a remote system, call the <see cref="CoCreateInstanceEx"/> function.
        /// To create multiple objects based on a single CLSID, call the <see cref="CoGetClassObject"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cocreateinstance
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
        public static extern HRESULT CoCreateInstance([MarshalAs(UnmanagedType.LPStruct)][In]Guid rclsid,
            [MarshalAs(UnmanagedType.IUnknown)]object pUnkOuter, [In]CLSCTX dwClsContext, [MarshalAs(UnmanagedType.LPStruct)][In]Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)]out object ppv);

        /// <summary>
        /// <para>
        /// Creates an instance of a specific class on a specific computer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cocreateinstanceex
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
        /// associated with the specified CLSID, specifying the location of the class; second,to <see cref="IClassFactory.CreateInstance"/> to
        /// create an uninitialized instance, and finally, to <see cref="IClassFactory.Release"/>, to release the class object.
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
        public static extern HRESULT CoCreateInstanceEx([MarshalAs(UnmanagedType.LPStruct)][In]Guid Clsid,
            [MarshalAs(UnmanagedType.IUnknown)]object punkOuter, [In]CLSCTX dwClsCtx, [In]in COSERVERINFO pServerInfo,
            [In]DWORD dwCount, [In][Out]MULTI_QI[] pResults);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the default OLE task memory allocator (which supports the system implementation of the <see cref="IMalloc"/> interface)
        /// so applications can call its methods to manage memory.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cogetmalloc
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
        public static extern HRESULT CoGetMalloc([In]uint dwMemContext, [Out]out IntPtr ppMalloc);

        /// <summary>
        /// <para>
        /// Initializes the COM library on the current thread and identifies the concurrency model as single-thread apartment (STA).
        /// New applications should call <see cref="CoInitializeEx"/> instead of <see cref="CoInitialize"/>.
        /// If you want to use the Windows Runtime, you must call Windows::Foundation::Initialize instead.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objbase/nf-objbase-coinitialize
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
        public static extern HRESULT CoInitialize([In]LPVOID pvReserved);

        /// <summary>
        /// <para>
        /// Initializes the COM library for use by the calling thread, sets the thread's concurrency model,
        /// and creates a new apartment for the thread if one is required.
        /// You should call Windows::Foundation::Initialize to initialize the thread instead of <see cref="CoInitializeEx"/>
        /// if you want to use the Windows Runtime APIs or if you want to use both COM and Windows Runtime components.
        /// Windows::Foundation::Initialize is sufficient to use for COM components.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-coinitializeex
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
        public static extern HRESULT CoInitializeEx([In]LPVOID pvReserved, [In]COINIT dwCoInit);

        /// <summary>
        /// <para>
        /// Registers security and sets the default security values for the process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-coinitializesecurity
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
        public static extern HRESULT CoInitializeSecurity([In]in SECURITY_DESCRIPTOR pSecDesc, [In]LONG cAuthSvc, [In]SOLE_AUTHENTICATION_SERVICE[] asAuthSvc,
            [In]IntPtr pReserved1, [In]DWORD dwAuthnLevel, [In]DWORD dwImpLevel, [In]IntPtr pAuthList, [In]DWORD dwCapabilities, [In]IntPtr pReserved3);

        /// <summary>
        /// <para>
        /// Allocates a block of task memory in the same way that IMalloc::Alloc does.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemalloc
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
        public static extern IntPtr CoTaskMemAlloc([In]IntPtr cb);

        /// <summary>
        /// <para>
        /// Frees a block of task memory previously allocated through a call to the <see cref="CoTaskMemAlloc"/> or <see cref="CoTaskMemRealloc"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemfree
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
        public static extern void CoTaskMemFree([In]IntPtr pv);

        /// <summary>
        /// <para>
        /// Changes the size of a previously allocated block of task memory.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemrealloc
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
        public static extern IntPtr CoTaskMemRealloc([In]IntPtr pv, [In]IntPtr cb);

        /// <summary>
        /// <para>
        /// Returns a pointer to an implementation of <see cref="IBindCtx"/> (a bind context object).
        /// This object stores information about a particular moniker-binding operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objbase/nf-objbase-createbindctx
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
        public static extern HRESULT CreateBindCtx([In]DWORD reserved, [Out]out IBindCtx ppbc);
    }
}
