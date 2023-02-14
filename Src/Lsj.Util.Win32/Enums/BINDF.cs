using Lsj.Util.Win32.ComInterfaces;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Contains the values that determine how a resource is bound to a moniker.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775130(v=vs.85)"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These values are passed to the Urlmon.dll from the client application's implementation of the <see cref="IBindStatusCallback.GetBindInfo"/> method.
    /// Note The gopher protocol is turned off by default in Microsoft Internet Explorer 6 for Windows XP Service Pack 2 (SP2).
    /// The protocol has been removed from WinInet in Windows Internet Explorer 7.
    /// </remarks>
    public enum BINDF
    {
        /// <summary>
        /// Value that indicates that the moniker will return immediately from a call
        /// to the <see cref="IMoniker.BindToStorage"/> method or the <see cref="IMoniker.BindToObject"/> method.
        /// The actual result of the bind to an object or the bind to storage returns asynchronously.
        /// The client application is notified by a call to the <see cref="IBindStatusCallback.OnDataAvailable"/> method
        /// or the <see cref="IBindStatusCallback.OnObjectAvailable"/> method.
        /// If the client does not specify this flag, the bind operation is synchronous,
        /// and the client receives no data from the bind operation
        /// until the <see cref="IMoniker.BindToStorage"/> call or the <see cref="IMoniker.BindToObject"/> call returns.
        /// </summary>
        BINDF_ASYNCHRONOUS = 0x00000001,

        /// <summary>
        /// Value that indicates that the client application calling the <see cref="IMoniker.BindToStorage"/> method
        /// specifies that the storage objects and stream objects returned from the <see cref="IBindStatusCallback.OnDataAvailable"/> method
        /// return <see cref="E_PENDING"/> when the objects reference data that is not yet available through the <see cref="IStream.Read"/> method,
        /// instead of blocking until the data becomes available.
        /// This flag applies only to <see cref="BINDF_ASYNCHRONOUS"/> operations.
        /// Note: Asynchronous stream objects return <see cref="E_PENDING"/> while data is still downloading and return <see cref="S_FALSE"/> for the end of the file.
        /// </summary>
        BINDF_ASYNCSTORAGE = 0x00000002,

        /// <summary>
        /// Value that indicates that progressive rendering is not be allowed.
        /// </summary>
        BINDF_NOPROGRESSIVERENDERING = 0x00000004,

        /// <summary>
        /// Value that indicates that the moniker is bound to the cached version of the resource.
        /// </summary>
        BINDF_OFFLINEOPERATION = 0x00000008,

        /// <summary>
        /// Value that indicates that the bind operation retrieves the newest version of the data or object available.
        /// In URL monikers, this flag maps to the WinInet flag, <see cref="INTERNET_FLAG_RELOAD"/>, which forces a download of the requested resource.
        /// </summary>
        BINDF_GETNEWESTVERSION = 0x00000010,

        /// <summary>
        /// Value that indicates that the bind operation does not store retrieved data in the disk cache.
        /// The client must specify <see cref="BINDF_PULLDATA"/> to turn off the cache file generation when the <see cref="IMoniker.BindToStorage"/> method is called.
        /// </summary>
        BINDF_NOWRITECACHE = 0x00000020,

        /// <summary>
        /// Value that indicates that the downloaded resource must be saved in the cache or a local file.
        /// </summary>
        BINDF_NEEDFILE = 0x00000040,

        /// <summary>
        /// Value that indicates that the asynchronous moniker enables the client of the <see cref="IMoniker.BindToStorage"/> method
        /// to drive the bind operation by pulling the data, instead of using the moniker to drive the operation by pushing the data to the client.
        /// When this flag is specified, new data is read or downloaded after the client finishes downloading all data that is currently available.
        /// This means data is only downloaded for the client after the client calls an <see cref="IStream.Read"/> operation that blocks or returns <see cref="E_PENDING"/>.
        /// When this flag is specified, the client must read all the data it can, even data that is not necessarily available yet.
        /// When this flag is not specified, the moniker continues downloading data and calls the client
        /// with <see cref="IBindStatusCallback.OnDataAvailable"/> whenever new data is available. 
        /// This flag applies only to <see cref="BINDF_ASYNCHRONOUS"/> bind operations.
        /// </summary>
        BINDF_PULLDATA = 0x00000080,

        /// <summary>
        /// Value that indicates that security problems related to bad certificates and redirects between HTTP and HTTPS servers should be ignored.
        /// For URL monikers, this flag corresponds to the following WinInet flags: <see cref="INTERNET_FLAG_IGNORE_CERT_CN_INVALID"/>,
        /// <see cref="INTERNET_FLAG_IGNORE_CERT_DATE_INVALID"/>, <see cref="INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTP"/>, and <see cref="INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTPS"/>.
        /// Security Warning: Using this value incorrectly can compromise the security of your application.
        /// If you implement the <see cref="IBindStatusCallback.GetBindInfo"/> method to ignore security problems with certificates and redirection,
        /// users may be susceptible to unwanted information disclosure.
        /// You should not implement <see cref="IBindStatusCallback.GetBindInfo"/> with a return value of <see cref="BINDF_IGNORESECURITYPROBLEM"/>
        /// because it prevents Internet Explorer from notifying users of security concerns.
        /// For more information, see Security Considerations: URL Monikers.
        /// </summary>
        BINDF_IGNORESECURITYPROBLEM = 0x00000100,

        /// <summary>
        /// Value that indicates that the resource should be resynchronized.
        /// For URL monikers, this flag maps to the WinInet flag, <see cref="INTERNET_FLAG_RESYNCHRONIZE"/>,
        /// which reloads an HTTP resource if the resource has been modified since the last time it was downloaded.
        /// All FTP and Gopher resources are reloaded.
        /// </summary>
        BINDF_RESYNCHRONIZE = 0x00000200,

        /// <summary>
        /// Value that indicates that hyperlinks are allowed.
        /// </summary>
        BINDF_HYPERLINK = 0x00000400,

        /// <summary>
        /// Value that indicates that the bind operation will not display any user interfaces.
        /// </summary>
        BINDF_NO_UI = 0x00000800,

        /// <summary>
        /// Value that indicates the bind operation will be completed silently.
        /// No user interface or user notification will occur.
        /// </summary>
        BINDF_SILENTOPERATION = 0x00001000,

        /// <summary>
        /// Value that indicates that the resource will not be stored in the Internet cache.
        /// </summary>
        BINDF_PRAGMA_NO_CACHE = 0x00002000,

        /// <summary>
        /// Value that indicates that the class object will be retrieved. Typically the class instance is retrieved.
        /// </summary>
        BINDF_GETCLASSOBJECT = 0x00004000,

        /// <summary>
        /// Reserved.
        /// </summary>
        BINDF_RESERVED_1 = 0x00008000,

        /// <summary>
        /// Reserved.
        /// </summary>
        BINDF_FREE_THREADED = 0x00010000,

        /// <summary>
        /// Value that indicates that the client application does not have to know the exact size of the data available,
        /// so the information is read directly from the source.
        /// </summary>
        BINDF_DIRECT_READ = 0x00020000,

        /// <summary>
        /// Value that indicates that this transaction is handled as a forms submittal.
        /// </summary>
        BINDF_FORMS_SUBMIT = 0x00040000,

        /// <summary>
        /// Value that indicates the resource is retrieved from the cache if the attempt to download the resource from the network fails.
        /// </summary>
        BINDF_GETFROMCACHE_IF_NET_FAIL = 0x00080000,

        /// <summary>
        /// Value that indicates the binding is from a URL moniker. This value was added for Internet Explorer 5.
        /// </summary>
        BINDF_FROMURLMON = 0x00100000,

        /// <summary>
        /// Value that indicates that the moniker will bind to the copy of the resource that is currently in the Internet cache.
        /// If the requested item is not found in the Internet cache, the system will attempt to locate the resource on the network.
        /// This value maps to the Win32 Internet API flag, <see cref="INTERNET_FLAG_USE_CACHED_COPY"/>.
        /// </summary>
        BINDF_FWD_BACK = 0x00200000,

        /// <summary>
        /// Value that indicates that the moniker client will specify that Urlmon.dll should look for and use the default system protocol first,
        /// instead of searching for temporary or permanent namespace handlers before it uses the default registered handler for particular protocols.
        /// </summary>
        BINDF_PREFERDEFAULTHANDLER = 0x00400000,

        /// <summary>
        /// Value that indicates that this transaction will be treated as taking place in the Restricted Sites Zone.
        /// For URL monikers, this flag maps to the Win32 Internet API flag, <see cref="INTERNET_FLAG_RESTRICTED_ZONE"/>.
        /// </summary>
        BINDF_ENFORCERESTRICTED = 0x00800000,
    }
}
