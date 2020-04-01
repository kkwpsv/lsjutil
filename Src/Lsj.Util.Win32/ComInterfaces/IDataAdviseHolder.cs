using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Enums.ADVF;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Creates and manages advisory connections between a data object and one or more advise sinks.
    /// Its methods are intended to be used to implement the advisory methods of <see cref="IDataObject"/>.
    /// <see cref="IDataAdviseHolder"/> is implemented on an advise holder object.
    /// Its methods establish and delete data advisory connections and send notification of change in data
    /// from a data object to an object that requires this notification, such as an OLE container, which must contain an advise sink.
    /// Advise sinks are objects that require notification of change in the data the object contains and implement the <see cref="IAdviseSink"/> interface.
    /// Advise sinks are also usually associated with OLE compound document containers.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-idataadviseholder
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IDataAdviseHolder)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDataAdviseHolder
    {
        /// <summary>
        /// Creates a connection between an advise sink and a data object for receiving notifications.
        /// </summary>
        /// <param name="pDataObject">
        /// A pointer to the <see cref="IDataObject"/> interface on the data object for which notifications are requested.
        /// If data in this object changes, a notification is sent to the advise sinks that have requested notification.
        /// </param>
        /// <param name="pFetc">
        /// A pointer to a <see cref="FORMATETC"/> structure that contains the specified format, medium, and target device
        /// that is of interest to the advise sink requesting notification.
        /// For example, one sink may want to know only when the bitmap representation of the data in the data object changes.
        /// Another sink may be interested in only the metafile format of the same object.
        /// Each advise sink is notified when the data of interest changes.
        /// This data is passed back to the advise sink when notification occurs.
        /// </param>
        /// <param name="advf">
        /// A group of flags that control the advisory connection.
        /// Possible values are from the <see cref="ADVF"/> enumeration.
        /// However, only some of the possible <see cref="ADVF"/> values are relevant for this method.
        /// The following table briefly describes the relevant values;
        /// a more detailed description can be found in the description of the <see cref="ADVF"/> enumeration.
        /// <see cref="ADVF_NODATA"/>: Asks that no data be sent along with the notification.
        /// <see cref="ADVF_ONLYONCE"/>:
        /// Causes the advisory connection to be destroyed after the first notification is sent.
        /// An implicit call to <see cref="Unadvise"/> is made on behalf of the caller to remove the connection.
        /// <see cref="ADVF_PRIMEFIRST"/>:
        /// Causes an initial notification to be sent regardless of whether data has changed from its current state.
        /// <see cref="ADVF_DATAONSTOP"/>:
        /// When specified with <see cref="ADVF_NODATA"/>, this flag causes a last notification with the data included
        /// to be sent before the data object is destroyed. 
        /// When <see cref="ADVF_NODATA"/> is not specified, this flag has no effect.
        /// </param>
        /// <param name="pAdvise">
        /// A pointer to the <see cref="IAdviseSink"/> interface on the advisory sink that receives the change notification.
        /// </param>
        /// <param name="pdwConnection">
        /// A pointer to a variable that receives a token that identifies this connection.
        /// The calling object can later delete the advisory connection by passing this token to <see cref="Unadvise"/>.
        /// If this value is zero, the connection was not established.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// </returns>
        /// <remarks>
        /// Through the connection established through this method, the advisory sink can receive future notifications
        /// in a call to <see cref="IAdviseSink.OnDataChange"/>.
        /// An object issues a call to <see cref="IDataObject.DAdvise"/> to request notification on changes to the format,
        /// medium, or target device of interest.
        /// This data is specified in the pFormatetc parameter.
        /// The <see cref="IDataObject.DAdvise"/> method is usually implemented to call <see cref="Advise"/> to delegate the task of setting up
        /// and tracking a connection to the advise holder.
        /// When the format, medium, or target device in question changes, the data object calls <see cref="SendOnDataChange"/>
        /// to send the necessary notifications.
        /// The established connection can be deleted by passing the value in <paramref name="pdwConnection"/> in a call to <see cref="Unadvise"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT Advise([In]IDataObject pDataObject, [In]in FORMATETC pFetc, [In]ADVF advf,
            [In]IAdviseSink pAdvise, [Out]out uint pdwConnection);

        /// <summary>
        /// Removes a connection between a data object and an advisory sink that was set up through a previous call to <see cref="Advise"/>.
        /// This method is typically called in the implementation of <see cref="IDataObject.DUnadvise"/>.
        /// </summary>
        /// <param name="dwConnection">
        /// A token that specifies the connection to be removed.
        /// This value was returned by <see cref="Advise"/> when the connection was originally established.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible values include the following.
        /// <see cref="OLE_E_NOCONNECTION"/>: The <paramref name="dwConnection"/> parameter does not specify a valid connection.
        /// </returns>
        [PreserveSig]
        HRESULT Unadvise([In]uint dwConnection);

        /// <summary>
        /// Returns an object that can be used to enumerate the current advisory connections.
        /// </summary>
        /// <param name="ppenumAdvise">
        /// A pointer to an <see cref="IEnumSTATDATA"/> pointer variable that receives the interface pointer to the new enumerator object.
        /// If the implementation returns <see langword="null"/> in <paramref name="ppenumAdvise"/>, there are no connections to advise sinks at this time.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> if the enumerator object is successfully instantiated or there are no connections.
        /// </returns>
        /// <remarks>
        /// This method must supply a pointer to an implementation of the <see cref="IEnumSTATDATA"/> interface.
        /// Its methods allow you to enumerate the data stored in an array of <see cref="STATDATA"/> structures.
        /// You get a pointer to the OLE implementation of <see cref="IDataAdviseHolder"/> through a call to <see cref="CreateDataAdviseHolder"/>,
        /// and then call <see cref="EnumAdvise"/> to implement <see cref="IDataObject.EnumDAdvise"/>.
        /// Adding more advisory connections while the enumerator object is active has an undefined effect on the enumeration that results from this method.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumAdvise([Out]out IEnumSTATDATA ppenumAdvise);

        /// <summary>
        /// Sends notifications to each advise sink for which there is a connection established by calling the <see cref="OnDataChange"/> method
        /// for each advise sink currently being handled by this instance of the advise holder object.
        /// </summary>
        /// <param name="pDataObject">
        /// A pointer to the <see cref="IDataObject"/> interface on the data object in which the data has just changed.
        /// This pointer is used in subsequent calls to <see cref="IAdviseSink.OnDataChange"/>.
        /// </param>
        /// <param name="dwReserved">
        /// This parameter is reserved and must be 0.
        /// </param>
        /// <param name="advf">
        /// Container for advise flags that specify how the call to <see cref="IAdviseSink.OnDataChange"/> is made.
        /// These flag values are from the enumeration <see cref="ADVF"/>.
        /// Typically, the value for <paramref name="advf"/> is 0.
        /// The only exception occurs when the data object is shutting down and must send a final notification
        /// that includes the actual data to sinks that have specified <see cref="ADVF_DATAONSTOP"/>
        /// and <see cref="ADVF_NODATA"/> in their call to <see cref="IDataObject.DAdvise"/>.
        /// In this case, <paramref name="advf"/> contains <see cref="ADVF_DATAONSTOP"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// </returns>
        /// <remarks>
        /// The data object must call this method when it detects a change that would be of interest to an advise sink that has previously requested notification.
        /// Most notifications include the actual data with them.
        /// The only exception is if the <see cref="ADVF_NODATA"/> flag was previously specified when the connection was initially set up
        /// in the <see cref="Advise"/> method.
        /// Before calling the <see cref="IAdviseSink.OnDataChange"/> method for each advise sink,
        /// this method obtains the actual data by calling the <see cref="IDataObject.GetData"/> method through the pointer
        /// specified in the <paramref name="pDataObject"/> parameter.
        /// </remarks>
        [PreserveSig]
        HRESULT SendOnDataChange([In]IDataObject pDataObject, [In]uint dwReserved, [In]ADVF advf);
    }
}
