using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.TYMED;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Flags that control caching and notification of changes in data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/ne-objidl-advf"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// For a data or view advisory connection, the container uses the <see cref="ADVF"/> constants
    /// when setting up a connection between an <see cref="IAdviseSink"/> instance
    /// and either an <see cref="IDataObject"/> or <see cref="IViewObject"/> instance.
    /// These connections are set up using the <see cref="IDataObject.DAdvise"/>,
    /// <see cref="IDataAdviseHolder.Advise"/>, or <see cref="IViewObject.SetAdvise"/> methods.
    /// </para>
    /// <para>
    /// For a caching connection, the constants are specified in the <see cref="IOleCache.Cache"/> method
    /// to indicate the container's requests on how the object should update its cache.
    /// </para>
    /// <para>
    /// These constants are also used in the <see cref="STATDATA.advf"/> member of the <see cref="STATDATA"/> structure.
    /// This structure is used by <see cref="IEnumSTATDATA"/> to describe the enumerated connections,
    /// and the <see cref="STATDATA.advf"/> member indicates the flags that were specified when the advisory or cache connection was established.
    /// When <see cref="STATDATA"/> is used for an enumerator, the <see cref="STATDATA.advf"/> member is indeterminate.
    /// </para>
    /// </remarks>
    [Flags]
    public enum ADVF
    {
        /// <summary>
        /// <para>
        /// For data advisory connections (<see cref="IDataObject.DAdvise"/> or <see cref="IDataAdviseHolder.Advise"/>),
        /// this flag requests the data object not to send data when it calls <see cref="IAdviseSink.OnDataChange"/>.
        /// The recipient of the change notification can later request the data by calling <see cref="IDataObject.GetData"/>.
        /// The data object can honor the request by passing <see cref="TYMED_NULL"/> in the <see cref="STGMEDIUM"/> parameter, or it can provide the data anyway.
        /// For example, the data object might have multiple advisory connections, not all of which specified <see cref="ADVF_NODATA"/>,
        /// in which case the object might send the same notification to all connections.
        /// Regardless of the container's request, its <see cref="IAdviseSink"/> implementation must check the <see cref="STGMEDIUM"/> parameter
        /// because it is responsible for releasing the medium if it is not <see cref="TYMED_NULL"/>.
        /// </para>
        /// <para>
        /// For cache connections (<see cref="IOleCache.Cache"/>), this flag requests that the cache not be updated by changes made to the running object.
        /// Instead, the container will update the cache by explicitly calling <see cref="IOleCache.SetData"/>.
        /// This situation typically occurs when the iconic aspect of an object is being cached.
        /// </para>
        /// <para>
        /// ADVF_NODATA is not a valid flag for view advisory connections (<see cref="IViewObject.SetAdvise"/>) and it returns <see cref="E_INVALIDARG"/>.
        /// </para>
        /// </summary>
        ADVF_NODATA = 1,

        /// <summary>
        /// Requests that the object not wait for the data or view to change before making an initial call to <see cref="IAdviseSink.OnDataChange"/>
        /// (for data or view advisory connections) or updating the cache (for cache connections).
        /// Used with <see cref="ADVF_ONLYONCE"/>, this parameter provides an asynchronous <see cref="IDataObject.GetData"/> call.
        /// </summary>
        ADVF_PRIMEFIRST = 2,

        /// <summary>
        /// <para>
        /// Requests that the object make only one change notification or cache update before deleting the connection.
        /// </para>
        /// <para>
        /// <see cref="ADVF_ONLYONCE"/> automatically deletes the advisory connection after sending one data or view notification.
        /// The advisory sink receives only one <see cref="IAdviseSink"/> call.
        /// A nonzero connection identifier is returned if the connection is established,
        /// so the caller can use it to delete the connection prior to the first change notification.
        /// </para>
        /// <para>
        /// For data change notifications, the combination of <see cref="ADVF_ONLYONCE"/> and <see cref="ADVF_PRIMEFIRST"/> provides,
        /// in effect, an asynchronous <see cref="IDataObject.GetData"/> call.
        /// </para>
        /// <para>
        /// When used with caching, <see cref="ADVF_ONLYONCE"/> updates the cache one time only,
        /// on receipt of the first <see cref="IAdviseSink.OnDataChange"/> notification.
        /// After the update is complete, the advisory connection between the object and the cache is disconnected.
        /// The source object for the advisory connection calls the <see cref="IUnknown.Release"/> method.
        /// </para>
        /// </summary>
        ADVF_ONLYONCE = 4,

        /// <summary>
        /// <para>
        /// For data advisory connections, assures accessibility to data.
        /// This flag indicates that when the data object is closing, it should call , providing data with the call.
        /// Typically, this value is used in combination with <see cref="ADVF_NODATA"/>.
        /// Without th<see cref="IAdviseSink.OnDataChange"/> is value, by the time an <see cref="IAdviseSink.OnDataChange"/> call without data reaches the sink,
        /// the source might have completed its shutdown and the data might not be accessible.
        /// Sinks that specify this value should accept data provided in <see cref="IAdviseSink.OnDataChange"/> if it is being passed,
        /// because they may not get another chance to retrieve it.
        /// </para>
        /// <para>
        /// For cache connections, this flag indicates that the object should update the cache as part of object closure.
        /// </para>
        /// <para>
        /// <see cref="ADVF_DATAONSTOP"/> is not a valid flag for view advisory connections.
        /// </para>
        /// </summary>
        ADVF_DATAONSTOP = 64,

        /// <summary>
        /// Synonym for <see cref="ADVFCACHE_FORCEBUILTIN"/>, which is used more often.
        /// </summary>
        ADVFCACHE_NOHANDLER = 8,

        /// <summary>
        /// This value is used by DLL object applications and object handlers that perform the drawing of their objects.
        /// <see cref="ADVFCACHE_FORCEBUILTIN"/> instructs OLE to cache presentation data to ensure that there is a presentation in the cache.
        /// This value is not a valid flag for data or view advisory connections.
        /// For cache connections, this flag caches data that requires only code shipped with OLE (or the underlying operating system)
        /// to be present in order to produce it with <see cref="IDataObject.GetData"/> or <see cref="IViewObject.Draw"/>.
        /// By specifying this value, the container can ensure that the data can be retrieved even when the object or handler code is not available.
        /// </summary>
        ADVFCACHE_FORCEBUILTIN = 16,

        /// <summary>
        /// For cache connections, this flag updates the cached representation only when the object containing the cache is saved.
        /// The cache is also updated when the OLE object transitions from the running state back to the loaded state
        /// (because a subsequent save operation would require rerunning the object).
        /// This value is not a valid flag for data or view advisory connections.
        /// </summary>
        ADVFCACHE_ONSAVE = 32
    }
}
