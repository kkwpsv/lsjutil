using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ADVF;
using static Lsj.Util.Win32.Enums.DATADIR;
using static Lsj.Util.Win32.Enums.TYMED;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables data transfer and notification of changes in data.
    /// Data transfer methods specify the format of the transferred data along with the medium through which the data is to be transferred.
    /// Optionally, the data can be rendered for a specific target device.
    /// In addition to methods for retrieving and storing data, the <see cref="IDataObject"/> interface specifies methods
    /// for enumerating available formats and managing connections to advisory sinks for handling change notifications.
    /// The term data object is used to mean any object that supports an implementation of the <see cref="IDataObject"/> interface.
    /// Implementations vary, depending on what the data object is required to do; in some data objects,
    /// the implementation of certain methods not supported by the object could simply be the return of <see cref="E_NOTIMPL"/>.
    /// For example, some data objects do not allow callers to send them data.
    /// Other data objects do not support advisory connections and change notifications.
    /// However, for those data objects that do support change notifications, OLE provides an object called a data advise holder.
    /// An interface pointer to this holder is available through a call to the helper function <see cref="CreateDataAdviseHolder"/>.
    /// A data object can have multiple connections, each with its own set of attributes.
    /// The OLE data advise holder simplifies the task of managing these connections and sending the appropriate notifications.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-idataobject"/>
    /// </para>
    /// </summary>
    public unsafe struct IDataObject
    {
        IntPtr* _vTable;

        /// <summary>
        /// Called by a data consumer to obtain data from a source data object.
        /// The <see cref="GetData"/> method renders the data described in the specified <see cref="FORMATETC"/> structure
        /// and transfers it through the specified <see cref="STGMEDIUM"/> structure.
        /// The caller then assumes responsibility for releasing the <see cref="STGMEDIUM"/> structure.
        /// </summary>
        /// <param name="pformatetcIn">
        /// A pointer to the <see cref="FORMATETC"/> structure that defines the format, medium, and target device to use when passing the data.
        /// It is possible to specify more than one medium by using the Boolean OR operator,
        /// allowing the method to choose the best medium among those specified.
        /// </param>
        /// <param name="pmedium">
        /// A pointer to the <see cref="STGMEDIUM"/> structure that indicates the storage medium
        /// containing the returned data through its <see cref="STGMEDIUM.tymed"/> member,
        /// and the responsibility for releasing the medium through the value of its <see cref="STGMEDIUM.pUnkForRelease"/> member.
        /// If <see cref="STGMEDIUM.pUnkForRelease"/> is <see cref="NULL"/>, the receiver of the medium is responsible for releasing it;
        /// otherwise, <see cref="STGMEDIUM.pUnkForRelease"/> points to the <see cref="IUnknown"/> on the appropriate object
        /// so its Release method can be called.
        /// The medium must be allocated and filled in by <see cref="GetData"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="DV_E_LINDEX"/>: The value for lindex is not valid; currently, only -1 is supported.
        /// <see cref="DV_E_FORMATETC"/>: The value for pformatetcIn is not valid.
        /// <see cref="DV_E_TYMED"/>:  The tymed value is not valid.
        /// <see cref="DV_E_DVASPECT"/>: The dwAspect value is not valid.
        /// <see cref="OLE_E_NOTRUNNING"/>: The object application is not running.
        /// <see cref="STG_E_MEDIUMFULL"/>: An error occurred when allocating the medium.
        /// <see cref="E_UNEXPECTED"/>: An unexpected error has occurred.
        /// <see cref="E_INVALIDARG"/>: The dwDirection value is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: There was insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// A data consumer calls <see cref="GetData"/> to retrieve data from a data object,
        /// conveyed through a storage medium (defined through the <see cref="STGMEDIUM"/> structure).
        /// Notes to Callers
        /// You can specify more than one acceptable tymed medium with the Boolean OR operator.
        /// <see cref="GetData"/> must choose from the OR'd values the medium that best represents the data,
        /// do the allocation, and indicate responsibility for releasing the medium.
        /// Data transferred across a stream extends from position zero of the stream pointer through to the position immediately
        /// before the current stream pointer (that is, the stream pointer position upon exit).
        /// Notes to Implementers
        /// <see cref="GetData"/> must check all fields in the <see cref="FORMATETC"/> structure.
        /// It is important that <see cref="GetData"/> render the requested aspect and, if possible, use the requested medium.
        /// If the data object cannot comply with the information specified in the <see cref="FORMATETC"/>,
        /// the method should return <see cref="DV_E_FORMATETC"/>.
        /// If an attempt to allocate the medium fails, the method should return <see cref="STG_E_MEDIUMFULL"/>.
        /// It is important to fill in all of the fields in the <see cref="STGMEDIUM"/> structure.
        /// Although the caller can specify more than one medium for returning the data, <see cref="GetData"/> can provide only one medium.
        /// If the initial transfer fails with the selected medium,
        /// this method can be implemented to try one of the other media specified before returning an error.
        /// </remarks>
        public HRESULT GetData([In] in FORMATETC pformatetcIn, [Out] out STGMEDIUM pmedium)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in FORMATETC, out STGMEDIUM, HRESULT>)_vTable[3])(thisPtr, pformatetcIn, out pmedium);
            }
        }

        /// <summary>
        /// Called by a data consumer to obtain data from a source data object.
        /// This method differs from the <see cref="GetData"/> method in that the caller must allocate and free the specified storage medium.
        /// </summary>
        /// <param name="pformatetc">
        /// A pointer to the <see cref="FORMATETC"/> structure that defines the format, medium, and target device to use when passing the data.
        /// Only one medium can be specified in <see cref="FORMATETC.tymed"/>, and only the following values are valid:
        /// <see cref="TYMED_ISTORAGE"/>, <see cref="TYMED_ISTREAM"/>, <see cref="TYMED_HGLOBAL"/>, or <see cref="TYMED_FILE"/>.
        /// </param>
        /// <param name="pmedium">
        /// A pointer to the <see cref="STGMEDIUM"/> structure that defines the storage medium containing the data being transferred.
        /// The medium must be allocated by the caller and filled in by <see cref="GetDataHere"/>.
        /// The caller must also free the medium.
        /// The implementation of this method must always supply a value of <see cref="NULL"/>
        /// for the <see cref="STGMEDIUM.pUnkForRelease"/> member of the <see cref="STGMEDIUM"/> structure to which this parameter points.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="DV_E_LINDEX"/>: The value for lindex is not valid; currently, only -1 is supported.
        /// <see cref="DV_E_FORMATETC"/>: The value for pformatetcIn is not valid.
        /// <see cref="DV_E_TYMED"/>:  The tymed value is not valid.
        /// <see cref="DV_E_DVASPECT"/>: The dwAspect value is not valid.
        /// <see cref="OLE_E_NOTRUNNING"/>: The object application is not running.
        /// <see cref="STG_E_MEDIUMFULL"/>: An error occurred when allocating the medium.
        /// <see cref="E_UNEXPECTED"/>: An unexpected error has occurred.
        /// <see cref="E_INVALIDARG"/>: The dwDirection value is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: There was insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetDataHere"/> method is similar to <see cref="GetData"/>,
        /// except that the caller must both allocate and free the medium specified in pmedium.
        /// <see cref="GetDataHere"/> renders the data described in a <see cref="FORMATETC"/> structure
        /// and copies the data into that caller-provided <see cref="STGMEDIUM"/> structure.
        /// For example, if the medium is <see cref="TYMED_HGLOBAL"/>, this method cannot resize the medium or allocate a new <see cref="STGMEDIUM.hGlobal"/>.
        /// Some media are not appropriate in a call to <see cref="GetDataHere"/>, including GDI types such as metafiles.
        /// The <see cref="GetDataHere"/> method cannot put data into a caller-provided metafile.
        /// In general, the only storage media it is necessary to support in this method are <see cref="TYMED_ISTORAGE"/>,
        /// <see cref="TYMED_ISTREAM"/>, and <see cref="TYMED_FILE"/>.
        /// When the transfer medium is a stream, OLE makes assumptions about where the data is being returned and the position of the stream's seek pointer.
        /// In a GetData call, the data returned is from stream position zero through just
        /// before the current seek pointer of the stream (that is, the position on exit).
        /// For <see cref="GetDataHere"/>, the data returned is from the stream position on entry through just before the position on exit.
        /// </remarks>
        public HRESULT GetDataHere([In] in FORMATETC pformatetc, [In][Out] ref STGMEDIUM pmedium)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in FORMATETC, ref STGMEDIUM, HRESULT>)_vTable[4])(thisPtr, pformatetc, ref pmedium);
            }
        }

        /// <summary>
        /// Determines whether the data object is capable of rendering the data as specified.
        /// Objects attempting a paste or drop operation can call this method before calling <see cref="GetData"/>
        /// to get an indication of whether the operation may be successful.
        /// </summary>
        /// <param name="pformatetc">
        /// A pointer to the <see cref="FORMATETC"/> structure defining the format, medium, and target device to use for the query.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="DV_E_LINDEX"/>: The value for lindex is not valid; currently, only -1 is supported.
        /// <see cref="DV_E_FORMATETC"/>: The value for pformatetcIn is not valid.
        /// <see cref="DV_E_TYMED"/>:  The tymed value is not valid.
        /// <see cref="DV_E_DVASPECT"/>: The dwAspect value is not valid.
        /// <see cref="OLE_E_NOTRUNNING"/>: The object application is not running.
        /// <see cref="E_UNEXPECTED"/>: An unexpected error has occurred.
        /// <see cref="E_INVALIDARG"/>: The dwDirection value is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: There was insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// The client of a data object calls <see cref="QueryGetData"/> to determine
        /// whether passing the specified <see cref="FORMATETC"/> structure to a subsequent call to <see cref="GetData"/> is likely to be successful.
        /// A successful return from this method does not necessarily ensure the success of the subsequent paste or drop operation.
        /// </remarks>
        public HRESULT QueryGetData([In] in FORMATETC pformatetc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in FORMATETC, HRESULT>)_vTable[5])(thisPtr, pformatetc);
            }
        }

        /// <summary>
        /// Provides a potentially different but logically equivalent <see cref="FORMATETC"/> structure.
        /// You use this method to determine whether two different <see cref="FORMATETC"/> structures would return the same data,
        /// removing the need for duplicate rendering.
        /// </summary>
        /// <param name="pformatectIn">
        /// A pointer to the <see cref="FORMATETC"/> structure that defines the format, medium, and target device
        /// that the caller would like to use to retrieve data in a subsequent call such as <see cref="GetData"/>.
        /// The <see cref="FORMATETC.tymed"/> member is not significant in this case and should be ignored.
        /// </param>
        /// <param name="pformatetcOut">
        /// A pointer to a <see cref="FORMATETC"/> structure that contains the most general information possible for a specific rendering,
        /// making it canonically equivalent to <paramref name="pformatectIn"/>.
        /// The caller must allocate this structure and the <see cref="GetCanonicalFormatEtc"/> method must fill in the data.
        /// To retrieve data in a subsequent call like <see cref="GetData"/>, the caller uses the specified value of <paramref name="pformatetcOut"/>,
        /// unless the value specified is <see cref="NULL"/>.
        /// This value is <see cref="NULL"/> if the method returns <see cref="DATA_S_SAMEFORMATETC"/>.
        /// The tymed member is not significant in this case and should be ignored.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="DATA_S_SAMEFORMATETC"/>:
        /// The <see cref="FORMATETC"/> structures are the same and <see cref="NULL"/> is returned in <paramref name="pformatetcOut"/>.
        /// <see cref="DV_E_LINDEX"/>: The value for lindex is not valid; currently, only -1 is supported.
        /// <see cref="DV_E_FORMATETC"/>: The value for pformatetcIn is not valid.
        /// <see cref="OLE_E_NOTRUNNING"/>: The object application is not running.
        /// <see cref="E_UNEXPECTED"/>: An unexpected error has occurred.
        /// <see cref="E_INVALIDARG"/>: The dwDirection value is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: There was insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// If a data object can supply exactly the same data for more than one requested <see cref="FORMATETC"/> structure,
        /// <see cref="GetCanonicalFormatEtc"/> can supply a "canonical", or standard <see cref="FORMATETC"/> that gives the same rendering
        /// as a set of more complicated <see cref="FORMATETC"/> structures.
        /// For example, it is common for the data returned to be insensitive to the target device specified in any one of
        /// a set of otherwise similar <see cref="FORMATETC"/> structures.
        /// Notes to Callers
        /// A call to this method can determine whether two calls to <see cref="GetData"/> on a data object,
        /// specifying two different <see cref="FORMATETC"/> structures, would actually produce the same renderings,
        /// thus eliminating the need for the second call and improving performance.
        /// If the call to <see cref="GetCanonicalFormatEtc"/> results in a canonical format being written to the <paramref name="pformatetcOut"/> parameter,
        /// the caller then uses that structure in a subsequent call to <see cref="GetData"/>.
        /// Notes to Implementers
        /// Conceptually, it is possible to think of <see cref="FORMATETC"/> structures in groups defined
        /// by a canonical <see cref="FORMATETC"/> that provides the same results as each of the group members.
        /// In constructing the canonical <see cref="FORMATETC"/>, you should make sure it contains the most general information possible 
        /// that still produces a specific rendering.
        /// For data objects that never provide device-specific renderings,
        /// the simplest implementation of this method is to copy the input <see cref="FORMATETC"/> to the output <see cref="FORMATETC"/>,
        /// store a <see cref="NULL"/> in the <see cref="FORMATETC.ptd"/> member of the output <see cref="FORMATETC"/>,
        /// and return <see cref="DATA_S_SAMEFORMATETC"/>.
        /// </remarks>
        public HRESULT GetCanonicalFormatEtc([In] in FORMATETC pformatectIn, [Out] out FORMATETC pformatetcOut)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in FORMATETC, out FORMATETC, HRESULT>)_vTable[6])(thisPtr, pformatectIn, out pformatetcOut);
            }
        }

        /// <summary>
        /// Called by an object containing a data source to transfer data to the object that implements this method.
        /// </summary>
        /// <param name="pformatetc">
        /// A pointer to the <see cref="FORMATETC"/> structure defining the format used by the data object
        /// when interpreting the data contained in the storage medium.
        /// </param>
        /// <param name="pmedium">
        /// A pointer to the <see cref="STGMEDIUM"/> structure defining the storage medium in which the data is being passed.
        /// </param>
        /// <param name="fRelease">
        /// If <see cref="TRUE"/>, the data object called, which implements <see cref="SetData"/>, owns the storage medium after the call returns.
        /// This means it must free the medium after it has been used by calling the <see cref="ReleaseStgMedium"/> function.
        /// If <see cref="FALSE"/>, the caller retains ownership of the storage medium and the data object called
        /// uses the storage medium for the duration of the call only.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="DV_E_LINDEX"/>: The value for lindex is not valid; currently, only -1 is supported.
        /// <see cref="DV_E_FORMATETC"/>: The value for pformatetcIn is not valid.
        /// <see cref="DV_E_TYMED"/>:  The tymed value is not valid.
        /// <see cref="DV_E_DVASPECT"/>: The dwAspect value is not valid.
        /// <see cref="OLE_E_NOTRUNNING"/>: The object application is not running.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="E_UNEXPECTED"/>: An unexpected error has occurred.
        /// <see cref="E_INVALIDARG"/>: The dwDirection value is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: There was insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// SetData allows another object to attempt to send data to the implementing data object.
        /// A data object implements this method if it supports receiving data from another object.
        /// If it does not support this, it should be implemented to return <see cref="E_NOTIMPL"/>.
        /// The caller allocates the storage medium indicated by the pmedium parameter, in which the data is passed.
        /// The data object called does not take ownership of the data until it has successfully received it and no error code is returned.
        /// The value of the <paramref name="fRelease"/> parameter indicates the ownership of the medium after the call returns.
        /// <see cref="FALSE"/> indicates the caller still owns the medium, and the data object only has the use of it during the call;
        /// <see cref="TRUE"/> indicates that the data object now owns it and must release it when it is no longer needed.
        /// The type of medium specified in the pformatetc and pmedium parameters must be the same.
        /// For example, one cannot be a global handle and the other a stream.
        /// </remarks>
        public HRESULT SetData([In] in FORMATETC pformatetc, [In] in STGMEDIUM pmedium, [In] BOOL fRelease)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in FORMATETC, in STGMEDIUM, BOOL, HRESULT>)_vTable[7])(thisPtr, pformatetc, pmedium, fRelease);
            }
        }

        /// <summary>
        /// Creates an object to enumerate the formats supported by a data object.
        /// </summary>
        /// <param name="dwDirection">
        /// The direction of the data. Possible values come from the <see cref="DATADIR"/> enumeration.
        /// The value <see cref="DATADIR_GET"/> enumerates the formats that can be passed in to a call to <see cref="GetData"/>.
        /// The value <see cref="DATADIR_SET"/> enumerates those formats that can be passed in to a call to <see cref="SetData"/>.
        /// </param>
        /// <param name="ppenumFormatEtc">
        /// A pointer to an <see cref="IEnumFORMATETC"/> pointer variable that receives the interface pointer to the new enumerator object.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="E_INVALIDARG"/>: The dwDirection value is not valid.
        /// <see cref="E_OUTOFMEMORY"/>: There was insufficient memory available for this operation.
        /// <see cref="E_NOTIMPL"/>: The direction specified by dwDirection is not supported.
        /// <see cref="OLE_S_USEREG"/>: Requests that OLE enumerate the formats from the registry.
        /// </returns>
        /// <remarks>
        /// <see cref="EnumFormatEtc"/> creates an enumerator object that can be used to determine all of the ways
        /// the data object can describe data in a <see cref="FORMATETC"/> structure, and provides a pointer to its <see cref="IEnumFORMATETC"/> interface.
        /// This is one of the standard enumerator interfaces.
        /// Notes to Callers
        /// Having obtained the pointer, the caller can enumerate the <see cref="FORMATETC"/> structures
        /// by calling the enumeration methods of <see cref="IEnumFORMATETC"/>.
        /// Because the formats can change over time, there is no guarantee that an enumerated format is currently supported
        /// because the formats can change over time.
        /// Accordingly, applications should treat the enumeration as a hint of the format types that can be passed.
        /// The caller is responsible for calling Release when it is finished with the enumerator.
        /// <see cref="EnumFormatEtc"/> is called when one of the following actions occurs:
        /// An application calls <see cref="OleSetClipboard"/>.
        /// OLE must determine what data to place on the clipboard and whether it is necessary to put OLE 1 compatibility formats on the clipboard.
        /// Data is being pasted from the clipboard or dropped. An application uses the first acceptable format.
        /// The Paste Special dialog box is displayed.
        /// The target application builds the list of formats from the <see cref="FORMATETC"/> entries.
        /// Notes to Implementers
        /// Formats can be registered statically in the registry or dynamically during object initialization.
        /// If an object has an unchanging list of formats and these formats are registered in the registry,
        /// OLE provides an implementation of a <see cref="FORMATETC"/> enumeration object
        /// that can enumerate formats registered under a specific CLSID in the registry.
        /// A pointer to its <see cref="IEnumFORMATETC"/> interface is available through a call to the helper function <see cref="OleRegEnumFormatEtc"/>.
        /// In this situation, therefore, you can implement the <see cref="EnumFormatEtc"/> method simply with a call to this function.
        /// EXE applications can effectively do the same thing by implementing the method to return the value <see cref="OLE_S_USEREG"/>.
        /// This return value instructs the default object handler to call <see cref="OleRegEnumFormatEtc"/>.
        /// Object applications that are implemented as DLL object applications cannot return <see cref="OLE_S_USEREG"/>,
        /// so must call <see cref="OleRegEnumFormatEtc"/> directly.
        /// Private formats can be enumerated for OLE 1 objects, if they are registered  with the RequestDataFormats or SetDataFormats keys in the registry.
        /// Also, private formats can be enumerated for OLE objects (all versions after OLE 1),
        /// if they are registered with the GetDataFormats or SetDataFormats keys.
        /// For OLE 1 objects whose servers do not have RequestDataFormats or SetDataFormats information registered in the registry,
        /// a call to <see cref="EnumFormatEtc"/> passing <see cref="DATADIR_GET"/> only enumerates the native and metafile formats,
        /// regardless of whether they support these formats or others.
        /// Calling <see cref="EnumFormatEtc"/> passing <see cref="DATADIR_SET"/> on such objects only enumerates native,
        /// regardless of whether the object supports being set with other formats.
        /// The <see cref="FORMATETC"/> structure returned by the enumeration usually indicates a <see cref="NULL"/> target device (ptd).
        /// This is appropriate because, unlike the other members of <see cref="FORMATETC"/>,
        /// the target device does not participate in the object's decision as to
        /// whether it can accept or provide the data in either a <see cref="SetData"/> or <see cref="GetData"/> call.
        /// The tymed member of <see cref="FORMATETC"/> often indicates that more than one kind of storage medium is acceptable.
        /// You should always mask and test for this by using a Boolean OR operator.
        /// </remarks>
        public HRESULT EnumFormatEtc([In] DWORD dwDirection, [Out] out IntPtr ppenumFormatEtc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out IntPtr, HRESULT>)_vTable[8])(thisPtr, dwDirection, out ppenumFormatEtc);
            }
        }

        /// <summary>
        /// Called by an object supporting an advise sink to create a connection between a data object and the advise sink.
        /// This enables the advise sink to be notified of changes in the data of the object.
        /// </summary>
        /// <param name="pformatetc">
        /// A pointer to a FORMATETC structure that defines the format, target device, aspect, and medium that will be used for future notifications.
        /// For example, one sink may want to know only when the bitmap representation of the data in the data object changes.
        /// Another sink may be interested in only the metafile format of the same object.
        /// Each advise sink is notified when the data of interest changes.
        /// This data is passed back to the advise sink when notification occurs.
        /// </param>
        /// <param name="advf">
        /// A group of flags for controlling the advisory connection. Possible values are from the <see cref="ADVF"/> enumeration.
        /// However, only some of the possible <see cref="ADVF"/> values are relevant for this method.
        /// The following table briefly describes the relevant values.
        /// <see cref="ADVF_NODATA"/>:
        /// Asks the data object to avoid sending data with the notifications.
        /// Typically data is sent. This flag is a way to override the default behavior.
        /// When <see cref="ADVF_NODATA"/> is used, the tymed member of the <see cref="STGMEDIUM"/> structure
        /// that is passed to <see cref="OnDataChange"/> will usually contain <see cref="TYMED_NULL"/>.
        /// The caller can then retrieve the data with a subsequent <see cref="GetData"/> call.
        /// <see cref="ADVF_ONLYONCE"/>:
        /// Causes the advisory connection to be destroyed after the first change notification is sent.
        /// An implicit call to <see cref="DUnadvise"/> is made on behalf of the caller to remove the connection.
        /// <see cref="ADVF_PRIMEFIRST"/>:
        /// Asks for an additional initial notification.
        /// The combination of <see cref="ADVF_ONLYONCE"/> and <see cref="ADVF_PRIMEFIRST"/> provides,
        /// in effect, an asynchronous <see cref="GetData"/> call.
        /// <see cref="ADVF_DATAONSTOP"/>:
        /// When specified with <see cref="ADVF_NODATA"/>, this flag causes a last notification with the data included to to be sent before the data object is destroyed.
        /// If used without <see cref="ADVF_NODATA"/>, <see cref="DAdvise"/> can be implemented in one of the following ways:
        /// The <see cref="ADVF_DATAONSTOP"/> can be ignored.
        /// The object can behave as if <see cref="ADVF_NODATA"/> was specified.
        /// A change notification is sent only in the shutdown case. Data changes prior to shutdown do not cause a notification to be sent.
        /// </param>
        /// <param name="pAdvSink">
        /// A pointer to the <see cref="IAdviseSink"/> interface on the advisory sink that will receive the change notification.
        /// </param>
        /// <param name="pdwConnection">
        /// A token that identifies this connection.
        /// You can use this token later to delete the advisory connection (by passing it to <see cref="DUnadvise"/>).
        /// If this value is 0, the connection was not established.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="E_NOTIMPL"/>: The direction specified by dwDirection is not supported.
        /// <see cref="DV_E_LINDEX"/>: The value for lindex is not valid; currently, only -1 is supported.
        /// <see cref="DV_E_FORMATETC"/>: The value for pformatetc is not valid.
        /// <see cref="OLE_E_ADVISENOTSUPPORTED"/>: The data object does not support change notification.
        /// </returns>
        /// <remarks>
        /// DAdvise creates a change notification connection between a data object and the caller.
        /// The caller provides an advisory sink to which the notifications can be sent when the object's data changes.
        /// Objects used simply for data transfer typically do not support advisory notifications
        /// and return <see cref="OLE_E_ADVISENOTSUPPORTED"/> from <see cref="DAdvise"/>.
        /// Notes to Callers
        /// The object supporting the advise sink calls <see cref="DAdvise"/> to set up the connection,
        /// specifying the format, aspect, medium, and/or target device of interest in the <see cref="FORMATETC"/> structure passed in.
        /// If the data object does not support one or more of the requested attributes or the sending of notifications at all,
        /// it can refuse the connection by returning <see cref="OLE_E_ADVISENOTSUPPORTED"/>.
        /// Containers of linked objects can set up advisory connections directly with the bound link source or indirectly
        /// through the standard OLE link object that manages the connection.
        /// Connections set up with the bound link source are not automatically deleted.
        /// The container must explicitly call <see cref="DUnadvise"/> on the bound link source to delete an advisory connection.
        /// The OLE link object, manipulated through the <see cref="IOleLink"/> interface, is implemented in the default handler.
        /// Connections set up through the OLE link object are destroyed when the link object is deleted.
        /// The OLE default link object creates a "wildcard advise" with the link source so OLE can maintain the time of last change.
        /// This advise is specifically used to note the time that anything changed.
        /// OLE ignores all data formats that may have changed, noting only the time of last change.
        /// To allow wildcard advises, set the <see cref="FORMATETC"/> members as follows before calling DAdvise:
        /// <code>
        /// cf == 0; 
        /// ptd == NULL; 
        /// dwAspect == -1; 
        /// lindex == -1 
        /// tymed == -1;
        /// </code>
        /// The advise flags should also include <see cref="ADVF_NODATA"/>.
        /// Wildcard advises from OLE should always be accepted by applications.
        /// Notes to Implementers
        /// To simplify the implementation of DAdvise and the other notification methods in <see cref="IDataObject"/>
        /// (<see cref="DUnadvise"/> and <see cref="EnumDAdvise"/>) that supports notification,
        /// OLE provides an advise holder object that manages the registration and sending of notifications.
        /// To get a pointer to this object, call the helper function <see cref="CreateDataAdviseHolder"/> on the first invocation of <see cref="DAdvise"/>.
        /// This supplies a pointer to the object's <see cref="IDataAdviseHolder"/> interface.
        /// Then, delegate the call to the <see cref="IDataAdviseHolder.Advise"/> method in the data advise holder,
        /// which creates, and subsequently manages, the requested connection.
        /// </remarks>
        public HRESULT DAdvise([In] in FORMATETC pformatetc, [In] ADVF advf, [In] in IAdviseSink pAdvSink, [Out] out DWORD pdwConnection)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in FORMATETC, ADVF, in IAdviseSink, out DWORD, HRESULT>)_vTable[9])(thisPtr, pformatetc, advf, pAdvSink, out pdwConnection);
            }
        }

        /// <summary>
        /// Destroys a notification connection that had been previously set up.
        /// </summary>
        /// <param name="dwConnection">
        /// A token that specifies the connection to be removed.
        /// Use the value returned by <see cref="DAdvise"/> when the connection was originally established.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="OLE_E_NOCONNECTION"/>: The specified value for dwConnection is not a valid connection.
        /// <see cref="OLE_E_ADVISENOTSUPPORTED"/>: This <see cref="IDataObject"/> implementation does not support notification.
        /// </returns>
        /// <remarks>
        /// This methods destroys a notification created with a call to the <see cref="DAdvise"/> method.
        /// If the advisory connection being deleted was initially set up by delegating the <see cref="DAdvise"/> call to <see cref="IDataAdviseHolder.Advise"/>,
        /// you must delegate this call to <see cref="IDataAdviseHolder.Unadvise"/> to delete it.
        /// </remarks>
        public HRESULT DUnadvise([In] DWORD dwConnection)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[10])(thisPtr, dwConnection);
            }
        }

        /// <summary>
        /// Creates an object that can be used to enumerate the current advisory connections.
        /// </summary>
        /// <param name="ppenumAdvise">
        /// A pointer to an <see cref="IEnumSTATDATA"/> pointer variable that receives the interface pointer to the new enumerator object.
        /// If the implementation sets <paramref name="ppenumAdvise"/> to <see cref="NULL"/>, there are no connections to advise sinks at this time.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> if the enumerator object is successfully instantiated or there are no connections.
        /// Other possible values include the following.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory is available for the operation.
        /// <see cref="OLE_E_ADVISENOTSUPPORTED"/>: Advisory notifications are not supported by this object.
        /// </returns>
        /// <remarks>
        /// The enumerator object created by this method implements the <see cref="IEnumSTATDATA"/> interface.
        /// <see cref="IEnumSTATDATA"/> permits the enumeration of the data stored in an array of <see cref="STATDATA"/> structures.
        /// Each of these structures provides information on a single advisory connection,
        /// and includes <see cref="FORMATETC"/> and <see cref="ADVF"/> information,
        /// as well as the pointer to the advise sink and the token representing the connection.
        /// Notes to Callers
        /// It is recommended that you use the OLE data advise holder object to handle advisory connections.
        /// With the pointer obtained through a call to <see cref="CreateDataAdviseHolder"/>,
        /// implementing <see cref="EnumDAdvise"/> becomes a simple matter of delegating the call to <see cref="IDataAdviseHolder.EnumAdvise"/>.
        /// This creates the enumerator and supplies the pointer to the OLE implementation of <see cref="IEnumSTATDATA"/>.
        /// At that point, you can call its methods to enumerate the current advisory connections.
        /// </remarks>
        public HRESULT EnumDAdvise([Out] out IntPtr ppenumAdvise)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out IntPtr, HRESULT>)_vTable[11])(thisPtr, out ppenumAdvise);
            }
        }
    }
}
