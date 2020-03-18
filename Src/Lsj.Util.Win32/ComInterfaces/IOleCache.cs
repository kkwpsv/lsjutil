using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Enums.ADVF;
using static Lsj.Util.Win32.Structs.HRESULT;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides control of the presentation data that gets cached inside of an object.
    /// Cached presentation data is available to the container of the object even when the server application is not running or is unavailable.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/oleidl/nn-oleidl-iolecache
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IOleCache)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleCache
    {
        /// <summary>
        /// Specifies the format and other data to be cached inside an embedded object.
        /// </summary>
        /// <param name="pformatetc">
        /// A pointer to a <see cref="FORMATETC"/> structure that specifies the format and other data to be cached.
        /// View caching is specified by passing a zero clipboard format in <paramref name="pformatetc"/>.
        /// </param>
        /// <param name="advf">
        /// A group of flags that control the caching.
        /// Possible values come from the <see cref="ADVF"/> enumeration.
        /// When used in this context, for a cache, these values have specific meanings, which are outlined in Remarks.
        /// Refer to the <see cref="ADVF"/> enumeration for a more detailed description.
        /// </param>
        /// <param name="pdwConnection">
        /// A pointer to a variable that receives the identifier of this connection,
        /// which can later be used to turn caching off (by passing it to <see cref="Uncache"/>).
        /// If this value is 0, the connection was not established.
        /// The OLE-provided implementation uses nonzero numbers for connection identifiers.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_INVALIDARG"/>: The supplied <paramref name="pformatetc"/> or <paramref name="advf"/> arguments are not valid.
        /// <see cref="E_UNEXPECTED"/>: An unexpected error has occurred.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory available for the operation.
        /// <see cref="CACHE_S_FORMATETC_NOTSUPPORTED"/>:
        /// The cache was created, but the object application does not support the specified format.
        /// Cache creation succeeds even if the format is not supported, allowing the caller to fill the cache.
        /// If, however, the caller does not need to keep the cache, call <see cref="Uncache"/>.
        /// <see cref="CACHE_S_SAMECACHE"/>:
        /// A cache already exists for the <see cref="FORMATETC"/> passed to <see cref="Uncache"/>.
        /// In this case, the new advise flags are assigned to the cache, and the previously assigned connection identifier is returned.
        /// <see cref="DV_E_LINDEX"/>: Invalid value for pformatetc->lindex; currently only -1 is supported.
        /// <see cref="DV_E_TYMED"/>: The value is not valid for pformatetc->tymed.
        /// <see cref="DV_E_DVASPECT"/>: The value is not valid for pformatetc->dwAspect.
        /// <see cref="DV_E_CLIPFORMAT"/>: The value is not valid for pformatetc->cfFormat.
        /// <see cref="CO_E_NOTINITIALIZED"/>: The cache's storage is not initialized.
        /// <see cref="DV_E_DVTARGETDEVICE"/>: The value is not valid for pformatetc-->ptd.
        /// <see cref="OLE_E_STATIC"/>: The cache is for a static object and it already has a cache node.
        /// </returns>
        /// <remarks>
        /// <see cref="Cache"/> can specify either data caching or view (presentation) caching.
        /// To specify data caching, a valid data format must be passed in pformatetc.
        /// For view caching, the cache object itself decides on the format to cache, so a caller would pass a zero data format in pformatetc as follows:
        /// <code>
        /// pFormatetc->cfFormat == 0
        /// </code>
        /// A custom object handler can choose not to store data in a given format.
        /// Instead, it can synthesize it on demand when requested.
        /// The <paramref name="advf"/> value specifies a member of the <see cref="ADVF"/> enumeration.
        /// When one of these values (or an OR'd combination of more than one value) is used in this context, these values mean the following.
        /// <see cref="ADVF_NODATA"/>:
        /// The cache is not to be updated by changes made to the running object.
        /// Instead, the container will update the cache by explicitly calling <see cref="IOleCache.SetData"/>,
        /// <see cref="IDataObject.SetData"/>, or <see cref="IOleCache2.UpdateCache"/>.
        /// This flag is usually used when the iconic aspect of an object is being cached.
        /// <see cref="ADVF_ONLYONCE"/>:
        /// Update the cache one time only. After the update is complete, the advisory connection between the object and the cache is disconnected.
        /// The source object for the advisory connection calls the Release method.
        /// <see cref="ADVF_PRIMEFIRST"/>:
        /// The object is not to wait for the data or view to change before updating the cache.
        /// OR'd with <see cref="ADVF_ONLYONCE"/>, this parameter provides an asynchronous <see cref="IDataObject.GetData"/> call.
        /// <see cref="ADVFCACHE_NOHANDLER"/>:
        /// Synonym for <see cref="ADVFCACHE_FORCEBUILTIN"/>.
        /// <see cref="ADVFCACHE_FORCEBUILTIN"/>:
        /// Used by DLL object applications and object handlers that draw their objects to cache presentation data
        /// to ensure that there is a presentation in the cache.
        /// This ensures that the data can be retrieved even when the object or handler code is not available.
        /// <see cref="ADVFCACHE_ONSAVE"/>:
        /// Updates the cached representation only when the object containing the cache is saved.
        /// The cache is also updated when the OLE object changes from the running state back to the loaded state
        /// (because a subsequent save operation would require running the object again).
        /// </remarks>
        [PreserveSig]
        HRESULT Cache([MarshalAs(UnmanagedType.LPStruct)][In]FORMATETC pformatetc, [In]ADVF advf, [Out]out uint pdwConnection);

        /// <summary>
        /// Removes a cache connection created previously using <see cref="Cache"/>.
        /// </summary>
        /// <param name="dwConnection">
        /// The cache connection to be removed.
        /// This nonzero value was returned by <see cref="Cache"/> when the cache was originally established.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_E_NOCONNECTION"/>: No cache connection exists for <paramref name="dwConnection"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="Uncache"/> method removes a cache connection that was created in a prior call to <see cref="Cache"/>.
        /// It uses the <paramref name="dwConnection"/> parameter that was returned by the prior call to <see cref="Cache"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT Uncache([In]uint dwConnection);

        /// <summary>
        /// Creates an enumerator that can be used to enumerate the current cache connections.
        /// </summary>
        /// <param name="ppenumSTATDATA">
        /// A pointer to an <see cref="IEnumSTATDATA"/> pointer variable that receives the interface pointer to the new enumerator object.
        /// If this parameter is <see langword="null"/>, there are no cache connections at this time.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> if enumerator object is successfully instantiated or there are no cache connections.
        /// Note  Check the <paramref name="ppenumSTATDATA"/> parameter to determine which result occurred.
        /// If the <paramref name="ppenumSTATDATA"/> parameter is <see langword="null"/>, then there are no cache connections at this time.
        /// </returns>
        /// <remarks>
        /// The enumerator object returned by this method implements the <see cref="IEnumSTATDATA"/> interface.
        /// <see cref="IEnumSTATDATA"/> enumerates the data stored in an array of <see cref="STATDATA"/> structures
        /// containing information about current cache connections.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumCache([Out]out IEnumSTATDATA ppenumSTATDATA);

        /// <summary>
        /// Fills the cache as needed using the data provided by the specified data object.
        /// </summary>
        /// <param name="pDataObject">
        /// A pointer to the <see cref="IDataObject"/> interface on the data object from which the cache is to be initialized.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_INVALIDARG"/>: The pointer to the <see cref="IDataObject"/> interface is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory is available for the operation.
        /// <see cref="OLE_E_NOTRUNNING"/>: The cache is not running.
        /// <see cref="CACHE_E_NOCACHE_UPDATED"/>: None of the caches were updated.
        /// <see cref="CACHE_S_SOMECACHES_NOTUPDATED"/>: Only some of the existing caches were updated.
        /// </returns>
        /// <remarks>
        /// <see cref="InitCache"/> is usually used when creating an object from a drag-and-drop operation or from a clipboard paste operation.
        /// It fills the cache as needed with presentation data from all the data formats provided by the data object provided
        /// on the clipboard or in the drag-and-drop operation.
        /// Helper functions like <see cref="OleCreateFromData"/> or <see cref="OleCreateLinkFromData"/> call this method when needed.
        /// If a container does not use these helper functions to create compound document objects,
        /// it can use <see cref="Cache"/> to set up the cache entries which are then filled by <see cref="InitCache"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT InitCache([In]IDataObject pDataObject);

        /// <summary>
        /// Initializes the cache with data in a specified format and on a specified medium.
        /// </summary>
        /// <param name="pformatetc">
        /// A pointer to a <see cref="FORMATETC"/> structure that specifies the format of the presentation data being placed in the cache.
        /// </param>
        /// <param name="pmedium">
        /// A pointer to a <see cref="STGMEDIUM"/> structure that specifies the storage medium that contains the presentation data.
        /// </param>
        /// <param name="fRelease">
        /// Indicates the ownership of the storage medium after completion of the method.
        /// If <paramref name="fRelease"/> is <see langword="true"/>, the cache takes ownership, freeing the medium when it is finished using it.
        /// When <paramref name="fRelease"/> is <see langword="false"/>, the caller retains ownership and is responsible for freeing the medium.
        /// The cache can only use the storage medium for the duration of the call.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="DV_E_LINDEX"/>: The value is not valid for pformatetc->lindex. Currently, only -1 is supported.
        /// <see cref="DV_E_FORMATETC"/>: The <see cref="FORMATETC"/> structure is invalid.
        /// <see cref="DV_E_TYMED"/>: The value is not valid for pformatetc->tymed.
        /// <see cref="DV_E_DVASPECT"/>: The value is not valid for pformatetc->dwAspect.
        /// <see cref="OLE_E_BLANK"/>: There is an uninitialized object.
        /// <see cref="DV_E_TARGETDEVICE"/>: The object is static and pformatetc->ptd is non-NULL.
        /// <see cref="STG_E_MEDIUMFULL"/>: The storage medium is full.
        /// </returns>
        /// <remarks>
        /// <see cref="SetData"/> is usually called when an object is created from the clipboard or through a drag-and-drop operation,
        /// and Embed Source data is used to create the object.
        /// <see cref="SetData"/> and <see cref="InitCache"/> are very similar.
        /// There are two main differences.
        /// The first difference is that while <see cref="InitCache"/> initializes the cache with the presentation format provided by the data object,
        /// <see cref="SetData"/> initializes it with a single format.
        /// Second, the <see cref="SetData"/> method ignores the <see cref="ADVF_NODATA"/> flag while <see cref="InitCache"/> obeys this flag.
        /// A container can use this method to maintain a single aspect of an object, such as the icon aspect of the object.
        /// </remarks>
        [PreserveSig]
        HRESULT SetData([MarshalAs(UnmanagedType.LPStruct)][In]FORMATETC pformatetc, [In]IntPtr pmedium, [In]bool fRelease);
    }
}
