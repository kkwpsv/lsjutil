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
    /// Serves as the principal means by which an embedded object provides basic functionality to, and communicates with, its container.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/oleidl/nn-oleidl-ioleobject
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IOleObject)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleObject
    {
        /// <summary>
        /// Informs an embedded object of its display location, called a "client site," within its container.
        /// </summary>
        /// <param name="pClientSite">
        /// Pointer to the <see cref="IOleClientSite"/> interface on the container application's client-site.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_UNEXPECTED"/>: An unexpected error occurred.
        /// </returns>
        /// <remarks>
        /// Within a compound document, each embedded object has its own client site the place where it is displayed and through
        /// which it receives information about its storage, user interface, and other resources.
        /// <see cref="SetClientSite"/> is the only method enabling an embedded object to obtain a pointer to its client site.
        /// Notes to Callers
        /// A container can notify an object of its client site either at the time the object is created or, subsequently, when the object is initialized.
        /// When creating or loading an object, a container may pass a client-site pointer (along with other arguments) to one of the following
        /// helper functions: <see cref="OleCreate"/>, <see cref="OleCreateFromFile"/>, <see cref="OleCreateFromData"/> or <see cref="OleLoad"/>.
        /// These helper functions load an object handler for the new object and call <see cref="SetClientSite"/> on the container's behalf
        /// before returning a pointer to the new object.
        /// Passing a client-site pointer informs the object handler that the client site is ready to process requests.
        /// If the client site is unlikely to be ready immediately after the handler is loaded,
        /// you may want your container to pass a <see langword="null"/> client-site pointer to the helper function.
        /// The <see langword="null"/> pointer says that no client site is available and thereby defers notifying
        /// the object handler of the client site until the object is initialized.
        /// In response, the helper function returns a pointer to the object, but upon receiving that pointer the container must call
        /// <see cref="SetClientSite"/> as part of initializing the new object.
        /// Notes to Implementers
        /// Implementation consists simply of incrementing the reference count on, and storing, the pointer to the client site.
        /// </remarks>
        [PreserveSig]
        HRESULT SetClientSite([In]IOleClientSite pClientSite);

        /// <summary>
        /// Retrieves a pointer to an embedded object's client site.
        /// </summary>
        /// <param name="ppClientSite">
        /// Address of <see cref="IOleClientSite"/> pointer variable that receives the interface pointer to the object's client site.
        /// If an object does not yet know its client site, or if an error has occurred, <paramref name="ppClientSite"/> must be set to <see langword="null"/>.
        /// Each time an object receives a call to <see cref="GetClientSite"/>, it must increase the reference count on <paramref name="ppClientSite"/>.
        /// It is the caller's responsibility to call Release when it is done with <paramref name="ppClientSite"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// </returns>
        /// <remarks>
        /// Link clients most commonly call the <see cref="GetClientSite"/> method in conjunction with the <see cref="IOleClientSite.GetContainer"/> method
        /// to traverse a hierarchy of nested objects.
        /// A link client calls <see cref="GetClientSite"/> to get a pointer to the link source's client site.
        /// The client then calls <see cref="IOleClientSite.GetContainer"/> to get a pointer to the link source's container.
        /// Finally, the client calls QueryInterface to get <see cref="IOleObject"/> and
        /// <see cref="GetClientSite"/> to get the container's client site within its container.
        /// By repeating this sequence of calls, the caller can eventually retrieve a pointer to the master container in which
        /// all the other objects are nested.
        /// Notes to Callers
        /// The returned client-site pointer will be <see langword="null"/> if an embedded object has not yet been informed of its client site.
        /// This will be the case with a newly loaded or created object when a container has passed a <see langword="null"/> client-site pointer
        /// to one of the object-creation helper functions but has not yet called <see cref="SetClientSite"/> as part of initializing the object.
        /// </remarks>
        [PreserveSig]
        HRESULT GetClientSite([Out]out IOleClientSite ppClientSite);

        /// <summary>
        /// Provides an object with the names of its container application and the compound document in which it is embedded.
        /// </summary>
        /// <param name="szContainerApp">
        /// Pointer to the name of the container application in which the object is running.
        /// </param>
        /// <param name="szContainerObj">
        /// Pointer to the name of the compound document that contains the object.
        /// If you do not wish to display the name of the compound document, you can set this parameter to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// </returns>
        /// <remarks>
        /// Notes for Callers
        /// Call <see cref="SetHostNames"/> only for embedded objects, because for linked objects,
        /// the link source provides its own separate editing window and title bar information.
        /// Notes to Implementers
        /// An object's application of <see cref="SetHostNames"/> should include whatever modifications to its user interface may be appropriate
        /// to an object's embedded state.
        /// Such modifications typically will include adding and removing menu commands and altering the text displayed
        /// in the title bar of the editing window.
        /// The complete window title for an embedded object in an SDI container application or an MDI application with a maximized child window
        /// should appear as follows:
        /// <code>
        /// &lt;object application name&gt; - &lt;object short type&gt; in &lt;container document&gt;
        /// </code>
        /// Otherwise, the title should be:
        /// <code>
        /// &lt;object application name&gt; - &lt;container document&gt;
        /// </code>
        /// The "object short type" refers to a form of an object's name short enough to be displayed in full in a list box.
        /// Because these identifying strings are not stored as part of the persistent state of the object,
        /// <see cref="SetHostNames"/> must be called each time the object loads or runs.
        /// </remarks>
        [PreserveSig]
        HRESULT SetHostNames([MarshalAs(UnmanagedType.LPWStr)][In]string szContainerApp, [MarshalAs(UnmanagedType.LPWStr)][In]string szContainerObj);

        /// <summary>
        /// Changes an embedded object from the running to the loaded state. Disconnects a linked object from its link source.
        /// </summary>
        /// <param name="dwSaveOption">
        /// Indicates whether the object is to be saved as part of the transition to the loaded state.
        /// Valid values are taken from the enumeration <see cref="OLECLOSE"/>.
        /// The OLE 2 user model recommends that object applications do not prompt users before saving linked or embedded objects,
        /// including those activated in place.
        /// This policy represents a change from the OLE 1 user model, in which object applications always prompt the user to decide whether to save changes.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_E_PROMPTSAVECANCELLED"/>: The user was prompted to save but chose the Cancel button from the prompt message box.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// A container application calls <see cref="Close"/> when it wants to move the object from a running to a loaded state.
        /// Following such a call, the object still appears in its container but is not open for editing.
        /// Calling <see cref="Close"/> on an object that is loaded but not running has no effect.
        /// Closing a linked object simply means disconnecting it.
        /// Notes to Implementers
        /// Upon receiving a call to <see cref="Close"/>, a running object should do the following:
        /// If the object has been changed since it was last opened for editing, it should request to be saved, or not,
        /// according to instructions specified in <paramref name="dwSaveOption"/>.
        /// If the option is to save the object, then it should call its container's <see cref="IOleClientSite.SaveObject"/> interface.
        /// If the object has <see cref="IDataObject.DAdvise"/> connections with <see cref="ADVF_DATAONSTOP"/> flags,
        /// then it should send an <see cref="IAdviseSink.OnDataChange"/> notification. See <see cref="IDataObject.DAdvise"/> for details.
        /// If the object currently owns the Clipboard, it should empty it by calling <see cref="OleFlushClipboard"/>.
        /// If the object is currently visible, notify its container by calling <see cref="IOleClientSite.OnShowWindow"/>
        /// with the fshow argument set to <see langword="false"/>.
        /// Send <see cref="IAdviseSink.OnClose"/> notifications to appropriate advise sinks.
        /// Finally, forcibly cut off all remoting clients by calling <see cref="CoDisconnectObject"/>.
        /// If the object application is a local server (an EXE rather than a DLL),
        /// closing the object should also shut down the object application unless the latter is
        /// supporting other running objects or has another reason to remain in the running state.
        /// Such reasons might include the presence of <see cref="IClassFactory.LockServer"/> locks, end-user control of the application,
        /// or the existence of other open documents requiring access to the application.
        /// Calling <see cref="Close"/> on a linked object disconnects it from, but does not shut down, its source application.
        /// A source application that is visible to the user when the object is closed remains visible and running
        /// after the disconnection and does not send an <see cref="IAdviseSink.OnClose"/> notification to the link container.
        /// </remarks>
        [PreserveSig]
        HRESULT Close([In]OLECLOSE dwSaveOption);

        /// <summary>
        /// Notifies an object of its container's moniker, the object's own moniker relative to the container, or the object's full moniker.
        /// </summary>
        /// <param name="dwWhichMoniker">
        /// The moniker is passed in <paramref name="pmk"/>. Possible values are from the enumeration <see cref="OLEWHICHMK"/>.
        /// </param>
        /// <param name="pmk">
        /// Pointer to where to return the moniker.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// </returns>
        /// <remarks>
        /// A container that supports links to embedded objects must be able to inform an embedded object when its moniker has changed.
        /// Otherwise, subsequent attempts by link clients to bind to the object will fail.
        /// The <see cref="SetMoniker"/> method provides one way for a container to communicate this information.
        /// The container can pass either its own moniker, an object's moniker relative to the container, or an object's full moniker.
        /// In practice, if a container passes anything other than an object's full moniker,
        /// each object calls the container back to request assignment of the full moniker,
        /// which the object requires to register itself in the running object table.
        /// The moniker of an object relative to its container is stored by the object handler as part of the object's persistent state.
        /// The moniker of the object's container, however, must not be persistently stored inside the object
        /// because the container can berenamed at any time.
        /// Notes to Callers
        /// A container calls <see cref="SetMoniker"/> when the container has been renamed,
        /// and the container's embedded objects currently or can potentially serve as link sources.
        /// Containers call SetMoniker mainly in the context of linking because an embedded object is already aware of its moniker.
        /// Even in the context of linking, calling this method is optional because objects can call <see cref="IOleClientSite.GetMoniker"/>
        /// to force assignment of a new moniker.
        /// Notes to Implementers
        /// Upon receiving a call to <see cref="SetMoniker"/>, an object should register its full moniker in the running object table
        /// and send <see cref="IAdviseSink.OnRename"/> notification to all advise sinks that exist for the object.
        /// </remarks>
        [PreserveSig]
        HRESULT SetMoniker([In]OLEWHICHMK dwWhichMoniker, [In]IMoniker pmk);

        /// <summary>
        /// Retrieves an embedded object's moniker, which the caller can use to link to the object.
        /// </summary>
        /// <param name="dwAssign">
        /// Determines how the moniker is assigned to the object.
        /// Depending on the value of <paramref name="dwAssign"/>, <see cref="IOleObject.GetMoniker"/> does one of the following:
        /// Obtains a moniker only if one has already been assigned.
        /// Forces assignment of a moniker, if necessary, in order to satisfy the call.
        /// Obtains a temporary moniker.
        /// Values for <paramref name="dwAssign"/> are specified in the enumeration <see cref="OLEGETMONIKER"/>.
        /// You cannot pass <see cref="OLEGETMONIKER_UNASSIGN"/> when calling <see cref="GetMoniker"/>.
        /// This value is valid only when calling <see cref="GetMoniker"/>.
        /// </param>
        /// <param name="dwWhichMoniker">
        /// Specifies the form of the moniker being requested.
        /// Possible values are taken from the enumeration <see cref="OLEWHICHMK"/>.
        /// </param>
        /// <param name="ppmk">
        /// Address of <see cref="IMoniker"/> pointer variable that receives the interface pointer to the object's moniker.
        /// If an error occurs, <paramref name="ppmk"/> must be set to <see langword="null"/>.
        /// Each time an object receives a call to <see cref="GetMoniker"/>, it must increase the reference count on <paramref name="ppmk"/>.
        /// It is the caller's responsibility to call Release when it is done with <paramref name="ppmk"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetMoniker"/> method returns an object's moniker.
        /// Like <see cref="SetMoniker"/>, this method is important only in the context of managing links
        /// to embedded objects and even in that case is optional.
        /// A potential link client that requires an object's moniker to bind to the object can call this method to obtain that moniker.
        /// The default implementation of <see cref="GetMoniker"/> calls the <see cref="IOleClientSite.GetMoniker"/>,
        /// returning <see cref="E_UNEXPECTED"/> if the object is not running or does not have a valid pointer to a client site.
        /// </remarks>
        [PreserveSig]
        HRESULT GetMoniker([In]OLEGETMONIKER dwAssign, [In]OLEWHICHMK dwWhichMoniker, [Out]out IMoniker ppmk);

        /// <summary>
        /// Initializes a newly created object with data from a specified data object,
        /// which can reside either in the same container or on the Clipboard.
        /// </summary>
        /// <param name="pDataObject">
        /// Pointer to the <see cref="IDataObject"/> interface on the data object from which the initialization data is to be obtained.
        /// This parameter can be <see langword="null"/>, which indicates that the caller wants to know if it is worthwhile trying to send data;
        /// that is, whether the container is capable of initializing an object from data passed to it.
        /// The data object to be passed can be based on either the current selection within the container document or on data
        /// transferred to the container from an external source.
        /// </param>
        /// <param name="fCreation">
        /// <see langword="true"/> indicates the container is inserting a new object inside itself and initializing
        /// that object with data from the current selection;
        /// <see langword="false"/> indicates a more general programmatic data transfer, most likely from a source other than the current selection.
        /// </param>
        /// <param name="dwReserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> if <paramref name="pDataObject"/> is not <see langword="null"/>,
        /// the object successfully attempted to initialize itself from the provided data;
        /// if <paramref name="pDataObject"/> is <see langword="null"/>, the object is able to attempt a successful initialization.
        /// Other possible return values include the following.
        /// <see cref="S_FALSE"/>:
        /// If <paramref name="pDataObject"/> is not <see langword="null"/>, the object made no attempt to initialize itself;
        /// if <paramref name="pDataObject"/> is <see langword="null"/>, the object cannot attempt to initialize itself from the data provided.
        /// <see cref="E_NOTIMPL"/>:
        /// The object does not support <see cref="InitFromData"/>.
        /// <see cref="OLE_E_NOTRUNNING"/>:
        /// The object is not running and therefore cannot perform the operation.
        /// </returns>
        /// <remarks>
        /// This method enables a container document to insert within itself a new object whose content is based on a current data selection
        /// within the container.
        /// For example, a spreadsheet document may want to create a graph object based on data in a selected range of cells.
        /// Using this method, a container can also replace the contents of an embedded object with data transferred from another source.
        /// This provides a convenient way of updating an embedded object.
        /// Notes to Callers
        /// Following initialization, the container should call <see cref="GetMiscStatus"/> 
        /// to check the value of the <see cref="OLEMISC_INSERTNOTREPLACE"/> bit.
        /// If the bit is on, the new object inserts itself following the selected data.
        /// If the bit is off, the new object replaces the selected data.
        /// Notes to Implementers
        /// A container specifies whether to base a new object on the current selection
        /// by passing either <see langword="true"/> or <see langword="false"/> to the <paramref name="fCreation"/> parameter.
        /// If <paramref name="fCreation"/> is <see langword="true"/>, the container is attempting to create a new instance of an object,
        /// initializing it with the selected data specified by the data object.
        /// If <paramref name="fCreation"/> is <see langword="false"/>, the caller is attempting to replace the object's current contents
        /// with that pointed to by <paramref name="pDataObject"/>.
        /// The usual constraints that apply to an object during a paste operation should be applied here.
        /// For example, if the type of the data provided is unacceptable, the object should fail to initialize and return <see cref="S_FALSE"/>.
        /// If the object returns <see cref="S_FALSE"/>, it cannot initialize itself from the provided data.
        /// </remarks>
        [PreserveSig]
        HRESULT InitFromData([In]IDataObject pDataObject, [MarshalAs(UnmanagedType.Bool)][In]bool fCreation, [In]uint dwReserved);

        /// <summary>
        /// Retrieves a data object containing the current contents of the embedded object on which this method is called.
        /// Using the pointer to this data object, it is possible to create a new embedded object with the same data as the original.
        /// </summary>
        /// <param name="dwReserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="ppDataObject">
        /// Address of <see cref="IDataObject"/> pointer variable that receives the interface pointer to the data object.
        /// If an error occurs, <paramref name="ppDataObject"/> must be set to <see langword="null"/>.
        /// Each time an object receives a call to <see cref="GetClipboardData"/>, it must increase the reference count on <paramref name="ppDataObject"/>.
        /// It is the caller's responsibility to call Release when it is done with <paramref name="ppDataObject"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_NOTIMPL"/>: <see cref="GetClipboardData"/> is not supported.
        /// <see cref="OLE_E_NOTRUNNING"/>: The object is not running.
        /// </returns>
        /// <remarks>
        /// You can use the <see cref="GetClipboardData"/> method to convert a linked object to an embedded object,
        /// in which case the container application would call <see cref="GetClipboardData"/> and
        /// then pass the data received to <see cref="OleCreateFromData"/>.
        /// This method returns a pointer to a data object that is identical to what would have been passed to the clipboard by a standard copy operation.
        /// Notes to Callers
        /// If you want a stable snapshot of the current contents of an embedded object, call <see cref="GetClipboardData"/>.
        /// Should the data change, you will need to call the function again for an updated snapshot.
        /// If you want the caller to be informed of changes that occur to the data, call QueryInterface, then call <see cref="IDataObject.DAdvise"/>.
        /// Notes to Implementers
        /// If you implement this function, you must return an <see cref="IDataObject"/> pointer for an object whose data will not change.
        /// </remarks>
        [PreserveSig]
        HRESULT GetClipboardData([In]uint dwReserved, [Out]out IDataObject ppDataObject);

        /// <summary>
        /// Requests that an object perform an action in response to an end-user's action.
        /// The possible actions are enumerated for the object in <see cref="EnumVerbs"/>.
        /// </summary>
        /// <param name="iVerb">
        /// Number assigned to the verb in the <see cref="OLEVERB"/> structure returned by <see cref="EnumVerbs"/>.
        /// </param>
        /// <param name="lpmsg">
        /// Pointer to the <see cref="MSG"/> structure describing the event (such as a double-click) that invoked the verb.
        /// The caller should pass the <see cref="MSG"/> structure unmodified,
        /// without attempting to interpret or alter the values of any of the structure members.
        /// </param>
        /// <param name="pActiveSite">
        /// Pointer to the <see cref="IOleClientSite"/> interface on the object's active client site, where the event occurred that invoked the verb.
        /// </param>
        /// <param name="lindex">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="hwndParent">
        /// Handle of the document window containing the object.
        /// This and <paramref name="lprcPosRect"/> together make it possible to open a temporary window for an object,
        /// where <paramref name="hwndParent"/> is the parent window in which the object's window is to be displayed,
        /// and <paramref name="lprcPosRect"/> defines the area available for displaying the object window within that parent.
        /// A temporary window is useful, for example, to a multimedia object that opens itself for playback but not for editing.
        /// </param>
        /// <param name="lprcPosRect">
        /// Pointer to the <see cref="RECT"/> structure containing the coordinates, in pixels,
        /// that define an object's bounding rectangle in <paramref name="hwndParent"/>.
        /// This and <paramref name="hwndParent"/> together enable opening multimedia objects for playback but not for editing.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_E_NOT_INPLACEACTIVE"/>:
        /// <paramref name="iVerb"/> set to <see cref="OLEIVERB_UIACTIVATE"/> or <see cref="OLEIVERB_INPLACEACTIVATE"/> and object is not already visible.
        /// <see cref="OLE_E_CANT_BINDTOSOURCE"/>:
        /// The object handler or link object cannot connect to the link source.
        /// <see cref="DV_E_LINDEX"/>:
        /// Invalid lindex.
        /// <see cref="OLEOBJ_S_CANNOT_DOVERB_NOW"/>:
        /// The verb is valid, but in the object's current state it cannot carry out the corresponding action.
        /// <see cref="OLEOBJ_S_INVALIDHWND"/>:
        /// <see cref="DoVerb"/> was successful but <paramref name="hwndParent"/> is invalid.
        /// <see cref="OLEOBJ_E_NOVERBS"/>:
        /// The object does not support any verbs.
        /// <see cref="OLEOBJ_S_INVALIDVERB"/>:
        /// Link source is across a network that is not connected to a drive on this computer.
        /// <see cref="MK_E_CONNECT"/>:
        /// Link source is across a network that is not connected to a drive on this computer.
        /// <see cref="OLE_E_CLASSDIFF"/>:
        /// Class for source of link has undergone a conversion.
        /// <see cref="E_NOTIMPL"/>:
        /// Object does not support in-place activation or does not recognize a negative verb number.
        /// </returns>
        /// <remarks>
        /// A "verb" is an action that an OLE object takes in response to a message from its container.
        /// An object's container, or a client linked to the object, normally calls <see cref="DoVerb"/> in response to some end-user action,
        /// such as double-clicking on the object.
        /// The various actions that are available for a given object are enumerated in an <see cref="OLEVERB"/> structure,
        /// which the container obtains by calling <see cref="EnumVerbs"/>.
        /// <see cref="DoVerb"/> matches the value of <paramref name="iVerb"/> against the <see cref="OLEVERB.iVerb"/> member
        /// of the structure to determine which verb to invoke.
        /// Through <see cref="EnumVerbs"/>, an object, rather than its container, determines which verbs (i.e., actions) it supports.
        /// OLE 2 defines seven verbs that are available, but not necessarily useful, to all objects.
        /// In addition, each object can define additional verbs that are unique to it.
        /// The following table describes the verbs defined by OLE.
        /// <see cref="OLEIVERB_PRIMARY"/>:
        /// Specifies the action that occurs when an end user double-clicks the object in its container.
        /// The object, not the container, determines this action.
        /// If the object supports in-place activation, the primary verb usually activates the object in place.
        /// <see cref="OLEIVERB_SHOW"/>:
        /// Instructs an object to show itself for editing or viewing.
        /// Called to display newly inserted objects for initial editing and to show link sources.
        /// Usually an alias for some other object-defined verb.
        /// <see cref="OLEIVERB_OPEN"/>:
        /// Instructs an object, including one that otherwise supports in-place activation,
        /// to open itself for editing in a window separate from that of its container.
        /// If the object does not support in-place activation, this verb has the same semantics as <see cref="OLEIVERB_SHOW"/>.
        /// <see cref="OLEIVERB_HIDE"/>:
        /// Causes an object to remove its user interface from the view. Applies only to objects that are activated in-place.
        /// <see cref="OLEIVERB_UIACTIVATE"/>:
        /// Activates an object in place, along with its full set of user-interface tools, including menus, toolbars,
        /// and its name in the title bar of the container window.
        /// If the object does not support in-place activation, it should return <see cref="E_NOTIMPL"/>.
        /// <see cref="OLEIVERB_INPLACEACTIVATE"/>:
        /// Activates an object in place without displaying tools, such as menus and toolbars,
        /// that end users need to change the behavior or appearance of the object.
        /// Single-clicking such an object causes it to negotiate the display of its user-interface tools with its container.
        /// If the container refuses, the object remains active but without its tools displayed.
        /// <see cref="OLEIVERB_DISCARDUNDOSTATE"/>:
        /// Used to tell objects to discard any undo state that they may be maintaining without deactivating the object.
        /// Notes to Callers
        /// Containers call <see cref="DoVerb"/> as part of initializing a newly created object.
        /// Before making the call, containers should first call <see cref="SetClientSite"/> to inform the object of its display location
        /// and <see cref="SetHostNames"/> to alert the object that it is an embedded object and
        /// to trigger appropriate changes to the user interface of the object application in preparation for opening an editing window.
        /// <see cref="DoVerb"/>automatically runs the OLE server application.
        /// If an error occurs during verb execution, the object application is shut down.
        /// If an end user invokes a verb by some means other than selecting a command from a menu
        /// (say, by double-clicking or, more rarely, single-clicking an object),
        /// the object's container should pass a pointer to a Windows <see cref="MSG"/> structure containing the appropriate message.
        /// For example, if the end user invokes a verb by double-clicking the object,
        /// the container should pass a <see cref="MSG"/> structure containing <see cref="WM_LBUTTONDBLCLK"/>,
        /// <see cref="WM_MBUTTONDBLCLK"/>, or <see cref="WM_RBUTTONDBLCLK"/>.
        /// If the container passes no message, <paramref name="lpmsg"/> should be set to <see langword="null"/>.
        /// The object should ignore the <see cref="MSG.hwnd"/> member of the passed <see cref="MSG"/> structure,
        /// but can use all the other <see cref="MSG"/> members.
        /// If the object's embedding container calls <see cref="DoVerb"/>, the client-site pointer (pClientSite)
        /// passed to <see cref="DoVerb"/> is the same as that of the embedding site.
        /// If the embedded object is a link source, the pointer passed to <see cref="DoVerb"/> is that of the linking client's client site.
        /// When <see cref="DoVerb"/> is invoked on an OLE link, it may return <see cref="OLE_E_CLASSDIFF"/> or <see cref="MK_CONNECTMANUALLY"/>.
        /// The link object returns the former error when the link source has been subjected to some sort of conversion while the link was passive.
        /// The link object returns the latter error when the link source is located on a network drive
        /// that is not currently connected to the caller's computer.
        /// The only way to connect a link under these conditions is to first call IUnknown::QueryInterface,
        /// ask for <see cref="IOleLink"/>, allocate a bind context, and run the link source by calling <see cref="BindToSource"/>.
        /// Container applications that do not support general in-place activation can still use the <paramref name="hwndParent"/>
        /// and <paramref name="lprcPosRect"/> parameters to support in-place playback of multimedia files.
        /// Containers must pass valid <paramref name="hwndParent"/> and lprcPosRect parameters to <see cref="DoVerb"/>.
        /// Some code samples pass a lindex value of -1 instead of zero.
        /// The value -1 works but should be avoided in favor of zero.
        /// The lindex parameter is a reserved parameter, and for reasons of consistency Microsoft recommends assigning a zero value
        /// to all reserved parameters.
        /// Notes to Implementers
        /// In addition to the above verbs, an object can define in its <see cref="OLEVERB"/> structure additional verbs that are specific to itself.
        /// Positive numbers designate these object-specific verbs.
        /// An object should treat any unknown positive verb number as if it were the primary verb
        /// and return <see cref="OLEOBJ_S_INVALIDVERB"/> to the calling function.
        /// The object should ignore verbs with negative numbers that it does not recognize and return <see cref="E_NOTIMPL"/>.
        /// If the verb being executed places the object in the running state, you should register the object in the running object table (ROT)
        /// even if its server application doesn't support linking.
        /// Registration is important because the object at some point may serve as the source of a link in a container that supports links to embeddings.
        /// Registering the object with the ROT enables the link client to get a pointer to the object directly,
        /// instead of having to go through the object's container.
        /// To perform the registration, call <see cref="IOleClientSite.GetMoniker"/> to get the full moniker of the object,
        /// call the <see cref="GetRunningObjectTable"/> function to get a pointer to the ROT, and then call <see cref="IRunningObjectTable.Register"/>.
        /// Note When the object leaves the running state, remember to revoke the object's registration with the ROT by calling <see cref="Close"/>.
        /// If the object's container document is renamed while the object is running,
        /// you should revoke the object's registration and re-register it with the ROT, using its new name.
        /// The container should inform the object of its new moniker either by calling <see cref="SetMoniker"/>
        /// or by responding to the object's calling <see cref="IOleClientSite.GetMoniker"/>.
        /// When showing a window as a result of <see cref="DoVerb"/>, it is very important for the object
        /// to explicitly call <see cref="SetForegroundWindow"/> on its editing window.
        /// This ensures that the object's window will be visible to the user even if another process originally obscured it.
        /// For more information see <see cref="SetForegroundWindow"/> and <see cref="SetActiveWindow"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT DoVerb([In]int iVerb, [In]IntPtr lpmsg, [In]IOleClientSite pActiveSite, [In]int lindex, [In]IntPtr hwndParent, [In]IntPtr lprcPosRect);

        /// <summary>
        /// Exposes a pull-down menu listing the verbs available for an object in ascending order by verb number.
        /// </summary>
        /// <param name="ppEnumOleVerb">
        /// Address of <see cref="IEnumOLEVERB"/> pointer variable that receives the interface pointer to the new enumerator object.
        /// Each time an object receives a call to <see cref="EnumVerbs"/>, it must increase the reference count on <paramref name="ppEnumOleVerb"/>.
        /// It is the caller's responsibility to call IUnknown::Release when it is done with <paramref name="ppEnumOleVerb"/>.
        /// If an error occurs, <paramref name="ppEnumOleVerb"/> must be set to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_S_USEREG"/>: Delegate to the default handler to use the entries in the registry to provide the enumeration.
        /// <see cref="OLEOBJ_E_NOVERBS"/>: Object does not support any verbs.
        /// </returns>
        [PreserveSig]
        HRESULT EnumVerbs([Out]out IEnumOLEVERB ppEnumOleVerb);

        /// <summary>
        /// Updates an object handler's or link object's data or view caches.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="OLE_E_CANT_BINDTOSOURCE"/>: Cannot run object to get updated data. The object is for some reason unavailable to the caller.
        /// <see cref="CACHE_E_NOCACHE_UPDATED"/>: No caches were updated.
        /// <see cref="CACHE_S_SOMECACHES_NOTUPDATED"/>: Some caches were not updated.
        /// </returns>
        /// <remarks>
        /// The <see cref="Update"/> method provides a way for containers to keep data updated in their linked and embedded objects.
        /// A link object can become out-of-date if the link source has been updated.
        /// An embedded object that contains links to other objects can also become out of date.
        /// An embedded object that does not contain links cannot become out of date because its data is not linked to another source.
        /// Notes to Implementers
        /// When a container calls a link object's <see cref="Update"/> method, the link object finds the link source and gets a new presentation from it.
        /// This process may also involve running one or more object applications, which could be time-consuming.
        /// When a container calls an embedded object's <see cref="Update"/> method, it is requesting the object to update all link objects it may contain.
        /// In response, the object handler recursively calls <see cref="Update"/> for each of its own linked objects, running each one as needed.
        /// </remarks>
        [PreserveSig]
        HRESULT Update();

        /// <summary>
        /// Checks whether an object is up to date.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> if the object is up to date; otherwise, <see cref="S_FALSE"/>.
        /// Other possible return values include the following.
        /// <see cref="OLE_E_UNAVAILABLE"/>: The status of object cannot be determined in a timely manner.
        /// </returns>
        /// <remarks>
        /// The <see cref="IsUpToDate"/> method provides a way for containers to check recursively whether all objects are up to date.
        /// That is, when the container calls this method on the first object, the object in turn calls it for all its own objects,
        /// and they in turn for all of theirs, until all objects have been checked.
        /// Notes to Implementers
        /// Because of the recursive nature of <see cref="IsUpToDate"/>, determining whether an object is out-of-date,
        /// particularly one containing one or more other objects, can be as time-consuming as simply updating the object in the first place.
        /// If you would rather avoid lengthy queries of this type, make sure that <see cref="IsUpToDate"/> returns <see cref="OLE_E_UNAVAILABLE"/>.
        /// In cases where the object to be queried is small and contains no objects itself, thereby making an efficient query possible,
        /// this method can return either <see cref="S_OK"/> or <see cref="S_FALSE"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT IsUpToDate();

        /// <summary>
        /// Retrieves an object's class identifier, the CLSID corresponding to the string identifying the object to an end user.
        /// </summary>
        /// <param name="pClsid">
        /// Pointer to the class identifier (CLSID) to be returned.
        /// An object's CLSID is the binary equivalent of the user-type name returned by <see cref="GetUserType"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// </returns>
        /// <remarks>
        /// <see cref="GetUserClassID"/> returns the CLSID associated with the object in the registration database.
        /// Normally, this value is identical to the CLSID stored with the object, which is returned by <see cref="IPersist.GetClassID"/>.
        /// For linked objects, this is the CLSID of the last bound link source.
        /// If the object is running in an application different from the one in which it was created and
        /// for the purpose of being edited is emulating a class that the container application recognizes,
        /// the CLSID returned will be that of the class being emulated rather than that of the object's own class.
        /// </remarks>
        [PreserveSig]
        HRESULT GetUserClassID([MarshalAs(UnmanagedType.LPStruct)][In]Guid pClsid);

        /// <summary>
        /// Retrieves the user-type name of an object for display in user-interface elements such as menus, list boxes, and dialog boxes.
        /// </summary>
        /// <param name="dwFormOfType">
        /// The form of the user-type name to be presented to users.
        /// Possible values are obtained from the <see cref="USERCLASSTYPE"/> enumeration.
        /// </param>
        /// <param name="pszUserType">
        /// Address of LPOLESTR pointer variable that receives a pointer to the user type string.
        /// The caller must free <paramref name="pszUserType"/> using the current <see cref="IMalloc"/> instance.
        /// If an error occurs, the implementation must set <paramref name="pszUserType"/> to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_S_USEREG"/>: Delegate to the default handler's implementation using the registry to provide the requested information.
        /// </returns>
        /// <remarks>
        /// Containers call <see cref="GetUserType"/> in order to represent embedded objects in list boxes, menus,
        /// and dialog boxes by their normal, user-recognizable names.
        /// Examples include "Word Document," "Excel Chart," and "Paintbrush Object."
        /// The information returned by <see cref="GetUserType"/> is the user-readable equivalent of the binary class identifier
        /// returned by <see cref="GetUserClassID"/>.
        /// Notes to Callers
        /// The default handler's implementation of <see cref="GetUserType"/> uses the object's class identifier
        /// (the pClsid parameter returned by <see cref="GetUserClassID"/>) and the <paramref name="dwFormOfType"/> parameter together
        /// as a key into the registry.
        /// If an entry is found that matches the key exactly, then the user type specified by that entry is returned.
        /// If only the CLSID part of the key matches, then the lowest-numbered entry available (usually the full name) is used.
        /// If the CLSID is not found, or there are no user types registered for the class, the user type currently found in the object's storage is used.
        /// You should not cache the string returned from <see cref="GetUserType"/>.
        /// Instead, call this method each and every time the string is needed.
        /// This guarantees correct results when the embedded object is being converted from one type into another without the caller's knowledge.
        /// Calling this method is inexpensive because the default handler implements it using the registry.
        /// Notes to Implementers
        /// You can use the implementation provided by the default handler by returning <see cref="OLE_S_USEREG"/>
        /// as your application's implementation of this method.
        /// If the user type name is an empty string, the message "Unknown Object" is returned.
        /// You can call the OLE helper function OleRegGetUserType to return the appropriate user type.
        /// </remarks>
        [PreserveSig]
        HRESULT GetUserType([In]USERCLASSTYPE dwFormOfType, [MarshalAs(UnmanagedType.LPWStr)][Out]out string pszUserType);

        /// <summary>
        /// Informs an object of how much display space its container has assigned it.
        /// </summary>
        /// <param name="dwDrawAspect">
        /// DWORD that describes which form, or "aspect," of an object is to be displayed.
        /// The object's container obtains this value from the enumeration <see cref="DVASPECT"/> (refer to the <see cref="FORMATETC"/> enumeration).
        /// The most common aspect is <see cref="DVASPECT_CONTENT"/>, which specifies a full rendering of the object within its container.
        /// An object can also be rendered as an icon, a thumbnail version for display in a browsing tool, or a print version,
        /// which displays the object as it would be rendered using the File Print command.
        /// </param>
        /// <param name="psizel">
        /// Pointer to the size limit for the object.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="OLE_E_NOTRUNNING"/>: The object is not running.
        /// </returns>
        /// <remarks>
        /// A container calls <see cref="SetExtent"/> when it needs to dictate to an embedded object the size at which it will be displayed.
        /// Often, this call occurs in response to an end user resizing the object window.
        /// Upon receiving the call, the object, if possible, should recompose itself gracefully to fit the new window.
        /// Whenever possible, a container seeks to display an object at its finest resolution, sometimes called the object's native size.
        /// All objects, however, have a default display size specified by their applications, and in the absence of other constraints,
        /// this is the size they will use to display themselves.
        /// Since an object knows its optimum display size better than does its container,
        /// the latter normally requests that size from a running object by calling <see cref="SetExtent"/>.
        /// Only in cases where the container cannot accommodate the value returned by the object
        /// does it override the object's preference by calling <see cref="SetExtent"/>.
        /// Notes to Callers
        /// You can call <see cref="SetExtent"/> on an object only when the object is running.
        /// If a container resizes an object while an object is not running, the container should keep track of the object's new size
        /// but defer calling <see cref="SetExtent"/> until a user activates the object.
        /// If the <see cref="OLEMISC_RECOMPOSEONRESIZE"/> bit is set on an object,
        /// its container should force the object to run before calling <see cref="SetExtent"/>.
        /// As noted above, a container may want to delegate responsibility for setting the size of an object's display site to the object itself,
        /// by calling <see cref="SetExtent"/>.
        /// Notes to Implementers
        /// You may want to implement this method so that your object rescales itself to match as closely as possible
        /// the maximum space available to it in its container.
        /// If an object's size is fixed, that is, if it cannot be set by its container, <see cref="SetExtent"/> should return <see cref="E_FAIL"/>.
        /// This is always the case with linked objects, whose sizes are set by their link sources, not by their containers.
        /// </remarks>
        [PreserveSig]
        HRESULT SetExtent([In]DVASPECT dwDrawAspect, [MarshalAs(UnmanagedType.LPStruct)][In]SIZE psizel);

        /// <summary>
        /// Retrieves a running object's current display size.
        /// </summary>
        /// <param name="dwDrawAspect">
        /// The aspect of the object whose limit is to be retrieved; the value is obtained
        /// from the enumerations <see cref="DVASPECT"/> and from <see cref="DVASPECT2"/>.
        /// Note that newer objects and containers that support optimized drawing interfaces support the <see cref="DVASPECT2"/> enumeration values.
        /// Older objects and containers that do not support optimized drawing interfaces may not support <see cref="DVASPECT2"/>.
        /// The most common value for this method is <see cref="DVASPECT_CONTENT"/>, which specifies a full rendering of the object within its container.
        /// </param>
        /// <param name="psizel">
        /// Pointer to where the object's size is to be returned.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_INVALIDARG"/>: The supplied <paramref name="dwDrawAspect"/> value is invalid.
        /// </returns>
        /// <remarks>
        /// A container calls <see cref="GetExtent"/> on a running object to retrieve its current display size.
        /// If the container can accommodate that size, it will normally do so because the object, after all,
        /// knows what size it should be better than the container does.
        /// A container normally makes this call as part of initializing an object.
        /// The display size returned by <see cref="GetExtent"/> may differ from the size last set by <see cref="SetExtent"/>
        /// because the latter method dictates the object's display space at the time the method is called
        /// but does not necessarily change the object's native size, as determined by its application.
        /// If one of the new aspects is requested in <paramref name="dwDrawAspect"/>,
        /// this method can either fail or return the same rectangle as for the <see cref="DVASPECT_CONTENT"/> aspect.
        /// This method must return the same size as <see cref="DVASPECT_CONTENT"/> for all the new aspects in <see cref="DVASPECT2"/>.
        /// <see cref="IViewObject2.GetExtent"/> must do the same thing.
        /// Notes to Callers
        /// Because a container can make this call only to a running object, the container must instead call <see cref="IViewObject2.GetExtent"/>
        /// if it wants to get the display size of a loaded object from its cache.
        /// Notes to Implementers
        /// Implementation consists of filling the sizel structure with an object's height and width.
        /// </remarks>
        [PreserveSig]
        HRESULT GetExtent([In]DVASPECT dwDrawAspect, [Out]out SIZE psizel);

        /// <summary>
        /// Establishes an advisory connection between a compound document object and the calling object's advise sink,
        /// through which the calling object receives notification when the compound document object is renamed, saved, or closed.
        /// </summary>
        /// <param name="pAdvSink">
        /// Pointer to the <see cref="IAdviseSink"/> interface on the advise sink of the calling object.
        /// </param>
        /// <param name="pdwConnection">
        /// Pointer to a token that can be passed to <see cref="Unadvise"/> to delete the advisory connection.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// The <see cref="Advise"/> method sets up an advisory connection between an object and its container,
        /// through which the object informs the container's advise sink of close, save, rename, and link-source change events in the object.
        /// A container calls this method, normally as part of initializing an object, to register its advisory sink with the object.
        /// In return, the object sends the container compound-document notifications by calling <see cref="IAdviseSink"/> or <see cref="IAdviseSink2"/>.
        /// If container and object successfully establish an advisory connection, the object receiving the call returns a nonzero value
        /// through <paramref name="pdwConnection"/> to the container.
        /// If the attempt to establish an advisory connection fails, the object returns zero.
        /// To delete an advisory connection, the container calls <see cref="Unadvise"/> and passes this nonzero token back to the object.
        /// An object can delegate the job of managing and tracking advisory events to an OLE advise holder,
        /// to which you obtain a pointer by calling <see cref="CreateOleAdviseHolder"/>.
        /// The returned <see cref="IOleAdviseHolder"/> interface has three methods for sending advisory notifications,
        /// as well as <see cref="IOleAdviseHolder.Advise"/>, <see cref="IOleAdviseHolder.Unadvise"/>,
        /// and <see cref="IOleAdviseHolder.EnumAdvise"/> methods that are identical to those for <see cref="IOleObject"/>.
        /// Calls to <see cref="Advise"/>, <see cref="Unadvise"/>, or <see cref="EnumAdvise"/> are delegated to corresponding methods in the advise holder.
        /// To destroy the advise holder, simply call IUnknown::Release on the <see cref="IOleAdviseHolder"/> interface.
        /// </remarks>
        [PreserveSig]
        HRESULT Advise([In]IAdviseSink pAdvSink, [Out]uint pdwConnection);

        /// <summary>
        /// Deletes a previously established advisory connection.
        /// </summary>
        /// <param name="dwConnection">
        /// Contains a token of nonzero value, which was previously returned from <see cref="IOleObject.Advise"/>
        /// through its <paramref name="dwConnection"/> parameter.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="OLE_E_NOCONNECTION"/>: <paramref name="dwConnection"/> does not represent a valid advisory connection.
        /// </returns>
        /// <remarks>
        /// Normally, containers call <see cref="Unadvise"/> at shutdown or when an object is deleted.
        /// In certain cases, containers can call this method on objects that are running but not currently visible
        /// as a way of reducing the overhead of maintaining multiple advisory connections.
        /// The easiest way to implement this method is to delegate the call to <see cref="Unadvise"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT Unadvise([In]uint dwConnection);

        /// <summary>
        /// Retrieves a pointer to an enumerator that can be used to enumerate the advisory connections registered for an object,
        /// so a container can know what to release prior to closing down.
        /// </summary>
        /// <param name="ppenumAdvise">
        /// Address of <see cref="IEnumSTATDATA"/> pointer variable that receives the interface pointer to the enumerator object.
        /// If the object does not have any advisory connections or if an error occurs,
        /// the implementation must set <paramref name="ppenumAdvise"/> to <see langword="null"/>.
        /// Each time an object receives a successful call to <see cref="EnumAdvise"/>,
        /// it must increase the reference count on <paramref name="ppenumAdvise"/>.
        /// It is the caller's responsibility to call Release when it is done with the <paramref name="ppenumAdvise"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_NOTIMPL"/>: <see cref="EnumAdvise"/> is not implemented.
        /// </returns>
        /// <remarks>
        /// The <see cref="EnumAdvise"/> method supplies an enumerator that provides a way for containers to
        /// keep track of advisory connections registered for their objects.
        /// A container normally would call this function so that it can instruct an object to release
        /// each of its advisory connections prior to closing down.
        /// The enumerator to which you get access through <see cref="EnumAdvise"/> enumerates items of type <see cref="STATDATA"/>.
        /// Upon receiving the pointer, the container can then loop through <see cref="STATDATA"/> and
        /// call <see cref="Unadvise"/> for each enumerated connection.
        /// The usual way to implement this function is to delegate the call to the <see cref="IOleAdviseHolder"/> interface.
        /// Only the pAdvise and <see cref="STATDATA.dwConnection"/> members of <see cref="STATDATA"/> are relevant for <see cref="EnumAdvise"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumAdvise([Out]out IEnumSTATDATA ppenumAdvise);

        /// <summary>
        /// Retrieves the status of an object at creation and loading.
        /// </summary>
        /// <param name="dwAspect">
        /// The aspect of an object about which status information is being requested.
        /// The value is obtained from the enumeration <see cref="DVASPECT"/>.
        /// </param>
        /// <param name="pdwStatus">
        /// Pointer to where the status information is returned.
        /// This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_S_USEREG"/>: Delegate the retrieval of miscellaneous status information to the default handler's implementation of this method.
        /// <see cref="CO_E_CLASSNOTREG"/>: There is no CLSID registered for the object.
        /// <see cref="CO_E_READREGDB"/>: Error accessing the registry.
        /// </returns>
        /// <remarks>
        /// A container normally calls <see cref="GetMiscStatus"/> when it creates or loads an object in order to determine
        /// how to display the object and what types of behaviors it supports.
        /// Objects store status information in the registry.
        /// If the object is not running, the default handler's implementation of <see cref="GetMiscStatus"/> retrieves this information from the registry.
        /// If the object is running, the default handler invokes <see cref="GetMiscStatus"/> on the object itself.
        /// The information that is actually stored in the registry varies with individual objects.
        /// The status values to be returned are defined in the enumeration <see cref="OLEMISC"/>.
        /// The default value of <see cref="GetMiscStatus"/> is used if a subkey corresponding to the specified <see cref="DVASPECT"/> is not found.
        /// To set an OLE control, specify DVASPECT==1. This will cause the following to occur in the registry:
        /// <code>
        /// HKEY_CLASSES_ROOT\CLSID\ . . .
        /// MiscStatus = 1
        /// </code>
        /// Notes to Implementers
        /// Implementation normally consists of delegating the call to the default handler.
        /// </remarks>
        [PreserveSig]
        HRESULT GetMiscStatus([In]DVASPECT dwAspect, [Out]out OLEMISC pdwStatus);

        /// <summary>
        /// Specifies the color palette that the object application should use when it edits the specified object.
        /// </summary>
        /// <param name="pLogpal">
        /// Pointer to a <see cref="LOGPALETTE"/> structure that specifies the recommended palette.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_NOTIMPL"/>: Object does not support setting palettes.
        /// <see cref="OLE_E_PALETTE"/>: Invalid <see cref="LOGPALETTE"/> structure pointed to by <paramref name="pLogpal"/>.
        /// <see cref="OLE_E_NOTRUNNING"/>: Object must be running to perform this operation.
        /// </returns>
        /// <remarks>
        /// The <see cref="IOleObject.SetColorScheme"/> method sends the container application's recommended color palette to the object application,
        /// which is not obliged to use it.
        /// </remarks>
        [PreserveSig]
        HRESULT SetColorScheme([MarshalAs(UnmanagedType.LPStruct)][In]LOGPALETTE pLogpal);
    }
}
