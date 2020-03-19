using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.IIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Manages advisory connections and compound document notifications in an object server.
    /// Its methods are intended to be used to implement the advisory methods of <see cref="IOleObject"/>.
    /// <see cref="IOleAdviseHolder"/> is implemented on an advise holder object.
    /// Its methods establish and delete advisory connections from the object managed by the server to the object's container,
    /// which must contain an advise sink (support the <see cref="IAdviseSink"/> interface).
    /// The advise holder object must also keep track of which advise sinks are interested in which notifications
    /// and pass along the notifications as appropriate.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/oleidl/nn-oleidl-ioleadviseholder
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IOleAdviseHolder)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleAdviseHolder
    {
        /// <summary>
        /// Establishes an advisory connection between an OLE object and the calling object's advise sink.
        /// Through that sink, the calling object can receive notification when the OLE object is renamed, saved, or closed.
        /// </summary>
        /// <param name="pAdvise">
        /// A pointer to the <see cref="IAdviseSink"/> interface on the advisory sink that should be informed of changes.
        /// </param>
        /// <param name="pdwConnection">
        /// A pointer to a token that can be passed to the <see cref="Unadvise"/> method to delete the advisory connection.
        /// The calling object is responsible for calling both IUnknown::AddRef and IUnknown::Release on this pointer.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_INVALIDARG"/>: The supplied <see cref="IAdviseSink"/> interface pointer is invalid.
        /// </returns>
        /// <remarks>
        /// Containers, object handlers, and link objects all create advise sinks to receive notification of changes
        /// in compound-document objects of interest, such as embedded or linked objects.
        /// OLE objects of interest to these objects must implement the IOleObject interface,
        /// which includes several advisory methods, including <see cref="IOleObject.Advise"/>.
        /// A call to this method must set up an advisory connection with any advise sink that calls it,
        /// and maintain each connection until it is closed.
        /// It must be able to handle more than one advisory connection at a time.
        /// <see cref="Advise"/> is intended to be used to simplify the implementation of <see cref="IOleObject.Advise"/>.
        /// You can get a pointer to the OLE implementation of <see cref="IOleAdviseHolder"/> by calling <see cref="CreateOleAdviseHolder"/>,
        /// and then, to implement <see cref="IOleObject.Advise"/>, just delegate the call to <see cref="Advise"/>.
        /// Other <see cref="IOleAdviseHolder"/> methods are intended to implement other <see cref="IOleObject"/> advisory methods.
        /// If the attempt to establish an advisory connection is successful,
        /// the object receiving the call returns a nonzero value through <paramref name="pdwConnection"/>.
        /// If the attempt fails, the object returns a zero.
        /// To delete an advisory connection, the object with the advise sink passes this nonzero token back to the object by calling <see cref="Advise"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT Advise([In]IAdviseSink pAdvise, [Out]out uint pdwConnection);

        /// <summary>
        /// Deletes a previously established advisory connection.
        /// </summary>
        /// <param name="dwConnection">
        /// The value previously returned by <see cref="Advise"/> in pdwConnection.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_E_NOCONNECTION"/>: The <paramref name="dwConnection"/> parameter does not represent a valid advisory connection.
        /// </returns>
        /// <remarks>
        /// <see cref="Unadvise"/> is intended to be used to implement <see cref="IOleObject.Unadvise"/> to delete an advisory connection.
        /// In general, you would use the OLE advise holder having obtained a pointer through a call to <see cref="CreateOleAdviseHolder"/>.
        /// Typically, containers call this method at shutdown or when an object is deleted.
        /// In certain cases, containers could call this method on objects that are running but not currently visible,
        /// as a way of reducing the overhead of maintaining multiple advisory connections.
        /// </remarks>
        [PreserveSig]
        HRESULT Unadvise([In]uint dwConnection);

        /// <summary>
        /// Creates an enumerator that can be used to enumerate the advisory connections currently established for an object.
        /// </summary>
        /// <param name="ppenumAdvise">
        /// A pointer to an <see cref="IEnumSTATDATA"/> pointer variable that receives the interface pointer to the new enumerator.
        /// If this parameter is <see langword="null"/>, there are presently no advisory connections on the object, or an error occurred.
        /// The advise holder is responsible for incrementing the reference count on the <see cref="IEnumSTATDATA"/> pointer this method supplies.
        /// It is the caller's responsibility to call IUnknown::Release when it is finished with the pointer.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_FAIL"/>: The enumeration operation has failed.
        /// <see cref="E_NOTIMPL"/>: <see cref="EnumAdvise"/> is not implemented.
        /// </returns>
        /// <remarks>
        /// <see cref="EnumAdvise"/> creates an enumerator that can be used to enumerate an object's established advisory connections.
        /// The method supplies a pointer to the <see cref="IEnumSTATDATA"/> interface on this enumerator.
        /// Advisory connection information for each connection is stored in the <see cref="STATDATA"/> structure,
        /// and the enumerator must be able to enumerate these structures.
        /// For this method, the only relevant structure members are <see cref="pAdvise"/> and <see cref="dwConnection"/>.
        /// Other members contain data advisory information.
        /// When you call the enumeration methods, and while an enumeration is in progress,
        /// the effect of registering or revoking advisory connections on what is to be enumerated is undefined.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumAdvise([Out]out IEnumSTATDATA ppenumAdvise);

        /// <summary>
        /// Sends notification to all advisory sinks currently registered with the advise holder that the name of object has changed.
        /// </summary>
        /// <param name="pmk">
        /// A pointer to the new full moniker of the object.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> if advise sinks were sent <see cref="IAdviseSink.OnRename"/> notifications.
        /// </returns>
        /// <remarks>
        /// <see cref="SendOnRename"/> calls <see cref="IAdviseSink.OnRename"/> to advise the calling object,
        /// which must have already established an advisory connection, that the object has a new moniker.
        /// If you are using the OLE advise holder (having obtained a pointer through a call to <see cref="CreateOleAdviseHolder"/>),
        /// you can call <see cref="SendOnRename"/> in the implementation of <see cref="IOleObject.SetMoniker"/>,
        /// when you have determined that the operation is successful.
        /// </remarks>
        [PreserveSig]
        HRESULT SendOnRename([In]IMoniker pmk);

        /// <summary>
        /// Sends notification to all advisory sinks currently registered with the advise holder that the object has been saved.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> if advise sinks were sent <see cref="IAdviseSink.OnSave"/> notifications.
        /// </returns>
        /// <remarks>
        /// <see cref="SendOnSave"/> calls <see cref="IAdviseSink.OnSave"/> to advise the calling object (client),
        /// which must have already established an advisory connection, that the object has been saved.
        /// If you are using the OLE advise holder (having obtained a pointer through a call to <see cref="CreateOleAdviseHolder"/>),
        /// you can call <see cref="SendOnSave"/> whenever you save the object the advise holder is associated with.
        /// To take the object from the running state to the loaded state, the client calls <see cref="IOleObject.Close"/>.
        /// Within that implementation, if the user wants to save the object to persistent storage,
        /// the object calls <see cref="IOleClientSite.SaveObject"/>, followed by the call to <see cref="SendOnSave"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT SendOnSave();

        /// <summary>
        /// Sends notification to all advisory sinks currently registered with the advise holder that the object has closed.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> if advise sinks were notified of the close operation
        /// through a call to the <see cref="IAdviseSink.OnClose"/> method.
        /// </returns>
        /// <remarks>
        /// <see cref="SendOnClose"/> must call IAdviseSink::OnClose on all advise sinks that have a valid advisory connection with the object,
        /// whenever the object goes from the running state to the loaded state.
        /// This occurs through a call to <see cref="IOleObject.Close"/>, so you can call <see cref="SendOnClose"/>
        /// when you determine that a Close operation has been successful.
        /// </remarks>
        [PreserveSig]
        HRESULT SendOnClose();
    }
}
