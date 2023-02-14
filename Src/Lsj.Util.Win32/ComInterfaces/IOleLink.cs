using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.OLELINKBIND;
using static Lsj.Util.Win32.Enums.OLEUPDATE;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.OleDlg;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables a linked object to provide its container with functions pertaining to linking.
    /// The most important of these functions is binding to the link source, that is, activating the connection to the document
    /// that stores the linked object's native data.
    /// <see cref="IOleLink"/> also defines functions for managing information about the linked object,
    /// such as the location of the link source and the cached presentation data for the linked object.
    /// A container application can distinguish between embedded objects and linked objects by querying for <see cref="IOleLink"/>;
    /// only linked objects implement <see cref="IOleLink"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-iolelink"/>
    /// </para>
    /// </summary>
    public unsafe struct IOleLink
    {
        IntPtr* _vTable;

        /// <summary>
        /// Specifies how often a linked object should update its cached data.
        /// </summary>
        /// <param name="dwUpdateOpt">
        /// Specifies how often a linked object should update its cached data.
        /// The possible values for <paramref name="dwUpdateOpt"/> are taken from the enumeration <see cref="OLEUPDATE"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_INVALIDARG"/>: The supplied value is invalid.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Your container application should call <see cref="SetUpdateOptions"/> when the end user changes the update option for a linked object.
        /// The end user selects the update option for a linked object using the Links dialog box.
        /// If you use the <see cref="OleUIEditLinks"/> function to display this dialog box,
        /// you must implement the <see cref="IOleUILinkContainer"/> interface.
        /// The dialog box calls your <see cref="IOleUILinkContainer.SetLinkUpdateOptions"/> method to specify the update option chosen by the end user.
        /// Your implementation of this method should call the <see cref="SetUpdateOptions"/> method to pass the selected option to the linked object.
        /// Notes to Implementers
        /// The default update option is <see cref="OLEUPDATE_ALWAYS"/>.
        /// The linked object's implementation of <see cref="IPersistStorage.Save"/> saves the current update option.
        /// If <see cref="OLEUPDATE_ALWAYS"/> is specified as the update option, the linked object updates the link's caches in the following situations:
        /// When the update option is changed from manual to automatic, if the link source is running.
        /// Whenever the linked object binds to the link source.
        /// Whenever the link source is running and the linked object's <see cref="IOleObject.Close"/>, <see cref="IPersistStorage.Save"/>,
        /// or <see cref="IAdviseSink.OnSave"/> implementations are called.
        /// For both manual and automatic links, the linked object updates the cache whenever the container application
        /// calls <see cref="IOleObject.Update"/> or <see cref="Update"/>.
        /// </remarks>
        public HRESULT SetUpdateOptions([In] OLEUPDATE dwUpdateOpt)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, OLEUPDATE, HRESULT>)_vTable[3])(thisPtr, dwUpdateOpt);
            }
        }

        /// <summary>
        /// Retrieves a value indicating how often the linked object updates its cached data.
        /// </summary>
        /// <param name="pdwUpdateOpt">
        /// A pointer to a variable that receives the current value for the linked object's update option,
        /// indicating how often the linked object updates the cached data for the linked object.
        /// The possible values for <paramref name="pdwUpdateOpt"/> are taken from the enumeration <see cref="OLEUPDATE"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// </returns>
        public HRESULT GetUpdateOptions([Out] out OLEUPDATE pdwUpdateOpt)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out OLEUPDATE, HRESULT>)_vTable[4])(thisPtr, out pdwUpdateOpt);
            }
        }

        /// <summary>
        /// Sets the moniker for the link source.
        /// </summary>
        /// <param name="pmk">
        /// A pointer to the <see cref="IMoniker"/> interface on a moniker that identifies the new link source of the linked object.
        /// A value of <see langword="null"/> breaks the link.
        /// </param>
        /// <param name="rclsid">
        /// The CLSID of the link source that the linked object should use to access information about the linked object when it is not bound.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Your container application can call <see cref="SetSourceMoniker"/> when the end user changes the source of a link or breaks a link.
        /// Note that this requires your container to use the <see cref="MkParseDisplayName"/> function
        /// to create a moniker out of the display name that the end user enters.
        /// If you'd rather have the linked object perform the parsing,
        /// your container can call <see cref="SetSourceDisplayName"/> instead of :<see cref="SetSourceMoniker"/>.
        /// The end user changes the source of a link or breaks a link using the Links dialog box.
        /// If you use the <see cref="OleUIEditLinks"/> function to display the Links dialog box,
        /// you must implement the <see cref="IOleUILinkContainer"/> interface.
        /// The dialog box calls your implementations of <see cref="IOleUILinkContainer.SetLinkSource"/> and <see cref="IOleUILinkContainer.CancelLink"/>;
        /// your implementation of these methods can call <see cref="SetSourceMoniker"/>.
        /// If the linked object is currently bound to its link source, the linked object's implementation
        /// of <see cref="SetSourceMoniker"/> closes the link before changing the moniker.
        /// Notes to Implementers
        /// The <see cref="IOleLink"/> contract does not specify how the linked object stores or uses the link source moniker.
        /// The provided implementation stores the absolute moniker specified when the link is created or when the moniker is changed;
        /// it then computes and stores a relative moniker.
        /// Future implementations might manage monikers differently to provide better moniker tracking.
        /// The absolute moniker provides the complete path to the link source.
        /// The linked object uses this absolute moniker and the moniker of the compound document
        /// to compute a relative moniker that identifies the link source relative to the compound document that contains the link.
        /// <code>
        /// pmkCompoundDoc-&gt;RelativePathTo(pmkAbsolute, ppmkRelative)
        /// </code>
        /// When binding to the link source, the linked object first tries to bind using the relative moniker.
        /// If that fails, it tries to bind the absolute moniker.
        /// When the linked object successfully binds using either the relative or the absolute moniker,
        /// it automatically updates the other moniker.
        /// The linked object also updates both monikers when it is bound to the link source
        /// and it receives a rename notification through the <see cref="IAdviseSink.OnRename"/> method.
        /// A container application can also use the <see cref="SetSourceDisplayName"/> method to change a link's moniker.
        /// The linked object's implementation of <see cref="IPersistStorage.Save"/> saves both the relative and the absolute moniker.
        /// </remarks>
        public HRESULT SetSourceMoniker([In] in IMoniker pmk, [In] in CLSID rclsid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IMoniker, in CLSID, HRESULT>)_vTable[5])(thisPtr, pmk, rclsid);
            }
        }

        /// <summary>
        /// Retrieves the moniker identifying the link source of a linked object.
        /// </summary>
        /// <param name="ppmk">
        /// Address of an <see cref="IMoniker"/> pointer variable that receives the interface pointer to an absolute moniker that identifies the link source.
        /// When successful, the implementation must call AddRef on <paramref name="ppmk"/>; it is the caller's responsibility to call Release.
        /// If an error occurs the implementation must set <paramref name="ppmk"/> to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="MK_E_UNAVAILABLE"/>: No moniker is available.
        /// Notes to Callers
        /// Your container application can call <see cref="GetSourceMoniker"/> to display the current source of a link in the Links dialog box.
        /// Note that this requires your container to use the <see cref="IMoniker.GetDisplayName"/> method to get the display name of the moniker.
        /// If you would rather get the display name directly, your container can call <see cref="GetSourceDisplayName"/>
        /// instead of <see cref="GetSourceMoniker"/>.
        /// If you use the <see cref="OleUIEditLinks"/> function to display the Links dialog box,
        /// you must implement the <see cref="IOleUILinkContainer"/> interface.
        /// The dialog box calls your implementations of <see cref="IOleUILinkContainer.GetLinkSource"/> to get the string it should display.
        /// Your implementation of that method can call <see cref="GetSourceMoniker"/>.
        /// Notes to Implementers
        /// The linked object stores both an absolute and a relative moniker for the link source.
        /// If the relative moniker is non-NULL and a moniker is available for the compound document,
        /// <see cref="GetSourceMoniker"/> returns the moniker created by composing the relative moniker onto the end of the compound document's moniker.
        /// Otherwise, it returns the absolute moniker or, if an error occurs, <see langword="null"/>.
        /// The container specifies the absolute moniker when it calls one of the <see cref="OleCreateLink"/> functions to create a link.
        /// The application can call <see cref="GetSourceMoniker"/> or <see cref="GetSourceDisplayName"/> to change the absolute moniker.
        /// In addition, the linked object automatically updates the monikers whenever it successfully binds to the link source,
        /// or when it is bound to the link source and it receives a rename notification through the <see cref="IAdviseSink.OnRename"/> method.
        /// </returns>
        public HRESULT GetSourceMoniker([Out] out IntPtr ppmk)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out IntPtr, HRESULT>)_vTable[6])(thisPtr, out ppmk);
            }
        }

        /// <summary>
        /// Sets the display name for the link source.
        /// </summary>
        /// <param name="pszStatusText">
        /// A pointer to the display name of the new link source. This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// Values from <see cref="MkParseDisplayName"/> may also be returned here.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Your container application can call <see cref="SetSourceDisplayName"/> when the end user changes the source of a link or breaks a link.
        /// Note that this requires the linked object to create a moniker out of the display name.
        /// If you'd rather parse the display name into a moniker yourself, your container can call <see cref="SetSourceMoniker"/>
        /// instead of <see cref="SetSourceDisplayName"/>.
        /// If you use the <see cref="OleUIEditLinks"/> function to display the Links dialog box,
        /// you must implement the <see cref="IOleUILinkContainer"/> interface.
        /// The dialog box calls your implementations of <see cref="IOleUILinkContainer.SetLinkSource"/> and <see cref="IOleUILinkContainer.CancelLink"/>.
        /// Your implementation of these methods can call <see cref="SetSourceDisplayName"/>.
        /// If your container application is immediately going to bind to a newly specified link source,
        /// you should call <see cref="MkParseDisplayName"/> and <see cref="SetSourceMoniker"/> instead,
        /// and then call <see cref="BindToSource"/> using the bind context from the parsing operation.
        /// By reusing the bind context, you can avoid redundant loading of objects that might otherwise occur.
        /// Notes to Implementers
        /// The contract for <see cref="SetSourceDisplayName"/> does not specify when the linked object will parse the display name into a moniker.
        /// The parsing can occur before <see cref="SetSourceDisplayName"/> returns,
        /// or the linked object can store the display name and parse it only when it needs to bind to the link source.
        /// Note that parsing the display name is potentially an expensive operation because it might require binding to the link source.
        /// The provided implementation of <see cref="SetSourceDisplayName"/> parses the display name
        /// and then releases the bind context used in the parse operation.
        /// This can result in running and then stopping the link source server.
        /// If the linked object is bound to the current link source, the implementation of <see cref="SetSourceDisplayName"/> breaks the connection.
        /// For more information on how the linked object stores and uses the moniker to the link source, see <see cref="SetSourceMoniker"/>.
        /// </remarks>
        public HRESULT SetSourceDisplayName([In] string pszStatusText)
        {
            fixed (void* thisPtr = &this)
            fixed (char* pszStatusTextPtr = pszStatusText)
            {
                return ((delegate* unmanaged[Stdcall]<void*, char*, HRESULT>)_vTable[7])(thisPtr, pszStatusTextPtr);
            }
        }

        /// <summary>
        /// Retrieves the display name of the link source of the linked object.
        /// </summary>
        /// <param name="ppszDisplayName">
        /// Address of a pointer variable that receives a pointer to the display name of the link source.
        /// If an error occurs, <paramref name="ppszDisplayName"/> is set to <see langword="null"/>;
        /// otherwise, the implementation must use <see cref="IMalloc.Alloc"/> to allocate the string returned in <paramref name="ppszDisplayName"/>,
        /// and the caller is responsible for calling <see cref="IMalloc.Free"/> to free it.
        /// Both caller and called use the allocator returned by <see cref="CoGetMalloc"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// Retrieving the display name requires calling these functions;
        /// therefore, this method may return errors generated by <see cref="CreateBindCtx"/> and <see cref="IMoniker.GetDisplayName"/>.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Your container application can call <see cref="GetSourceDisplayName"/> to display the current source of a link.
        /// The current source of a link is displayed in the Links dialog box.
        /// If you use the <see cref="OleUIEditLinks"/> function to display the Links dialog box,
        /// you must implement the <see cref="IOleUILinkContainer"/> interface.
        /// The dialog box calls your implementations of <see cref="IOleUILinkContainer.GetLinkSource"/> to get the string it should display.
        /// Your implementation of that method can call <see cref="GetSourceDisplayName"/>.
        /// Notes to Implementers
        /// The linked object's implementation of <see cref="GetSourceDisplayName"/> calls <see cref="GetSourceMoniker"/> to get the link source moniker,
        /// and then calls <see cref="IMoniker.GetDisplayName"/> to get that moniker's display name.
        /// This operation is potentially expensive because it might require binding the moniker.
        /// All of the system-provided monikers can return a display name without binding,
        /// but there is no guarantee that other moniker implementations can.
        /// Instead of making repeated calls to <see cref="GetSourceDisplayName"/>, your container application can cache the name
        /// and update it whenever the link source is bound.
        /// </remarks>
        public HRESULT GetSourceDisplayName([Out] out IntPtr ppszDisplayName)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out IntPtr, HRESULT>)_vTable[8])(thisPtr, out ppszDisplayName);
            }
        }

        /// <summary>
        /// Activates the connection to the link source by binding the moniker stored within the linked object.
        /// </summary>
        /// <param name="bindflags">
        /// Specifies how to proceed if the link source has a different CLSID from the last time it was bound.
        /// If this parameter is zero and the CLSIDs are different, the method fails and returns <see cref="OLE_E_CLASSDIFF"/>.
        /// If the <see cref="OLELINKBIND_EVENIFCLASSDIFF"/> value from the <see cref="OLELINKBIND"/> enumeration is specified and the CLSIDs are different,
        /// the method binds successfully and updates the CLSID stored in the linked object.
        /// </param>
        /// <param name="pbc">
        /// A pointer to the <see cref="IBindCtx"/> interface on the bind context to be used in this binding operation.
        /// This parameter can be <see langword="null"/>.
        /// The bind context caches objects bound during the binding process, contains parameters that apply to all operations using the bind context,
        /// and provides the means by which the binding implementation should retrieve information about its environment.
        /// For more information, see <see cref="IBindCtx"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_E_CLASSDIFF"/>:
        /// The link source was not bound because its CLSID has changed.
        /// This error is returned only if the <see cref="OLELINKBIND_EVENIFCLASSDIFF"/> flag is not specified in the <paramref name="bindflags"/> parameter.
        /// <see cref="MK_E_NOOBJECT"/>:
        /// The link source could not be found or (if the link source's moniker is a composite)
        /// some intermediate object identified in the composite could not be found.
        /// <see cref="E_UNSPEC"/>
        /// The link's moniker is <see langword="null"/>.
        /// Binding the moniker might require calling the <see cref="CreateBindCtx"/> function;
        /// therefore, this method may return errors generated by <see cref="CreateBindCtx"/>.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Typically, your container application does not need to call the <see cref="BindToSource"/> method directly.
        /// When it's necessary to activate the connection to the link source, your container typically calls <see cref="IOleObject.DoVerb"/>,
        /// <see cref="IOleObject.Update"/>, or <see cref="Update"/>.
        /// The linked object's implementation of these methods calls <see cref="BindToSource"/>.
        /// Your container can also call the <see cref="OleRun"/> function, which when called on a linked object calls <see cref="BindToSource"/>.
        /// In each of the examples listed previously, in which <see cref="BindToSource"/> is called indirectly,
        /// the <paramref name="bindflags"/> parameter is set to zero.
        /// Consequently, these calls can fail with the <see cref="OLE_E_CLASSDIFF"/> error if the class of the link source is differen
        /// t from what it was the last time the linked object was bound.
        /// This could happen, for example, if the original link source was an embedded Lotus spreadsheet
        /// that an end user had subsequently converted (using the Change Type dialog box) to an Excel spreadsheet.
        /// If you want your container to bind even though the link source now has a different CLSID, you can call <see cref="BindToSource"/> directly
        /// and specify <see cref="OLELINKBIND_EVENIFCLASSDIFF"/> for the <paramref name="bindflags"/> parameter.
        /// This call binds to the link source and updates the link object's CLSID.
        /// Alternatively, your container can delete the existing link and use the <see cref="OleCreateLink"/> function to create a new linked object.
        /// Notes to Implementers
        /// The linked object caches the interface pointer to the link source acquired during binding.
        /// The linked object's <see cref="BindToSource"/> implementation first tries to bind using a moniker consisting of the compound document's moniker
        /// composed with the link source's relative moniker.
        /// If successful, it updates the link's absolute moniker.
        /// Otherwise, it tries to bind using the absolute moniker, updating the relative moniker if successful.
        /// If <see cref="BindToSource"/> binds to the link source, it calls the compound document's <see cref="IOleContainer.LockContainer"/>
        /// implementation to keep the containing compound document alive while the link source is running.
        /// <see cref="BindToSource"/> also calls the <see cref="IOleObject.Advise"/> and <see cref="IDataObject.DAdvise"/> implementations of the link
        /// source to set up advisory connections.
        /// The <see cref="UnbindSource"/> implementation unlocks the container and deletes the advisory connections.
        /// </remarks>
        public HRESULT BindToSource([In] OLELINKBIND bindflags, [In] in IBindCtx pbc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, OLELINKBIND, in IBindCtx, HRESULT>)_vTable[9])(thisPtr, bindflags, pbc);
            }
        }

        /// <summary>
        /// Activates the connection between the linked object and the link source if the link source is already running.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="S_FALSE"/>: The link source is not running.
        /// Binding the moniker might require calling <see cref="CreateBindCtx"/>, <see cref="IMoniker.IsRunning"/>, or <see cref="BindToSource"/>;
        /// therefore, errors generated by these functions can also be returned.
        /// </returns>
        /// <remarks>
        /// You typically do not need to call <see cref="BindIfRunning"/>. This method is primarily called by the linked object.
        /// Notes to Implementers
        /// The linked object's implementation of <see cref="BindIfRunning"/> checks the running object table (ROT) to determine
        /// whether the link source is already running.
        /// It checks both the relative and absolute monikers.
        /// If the link source is running, <see cref="BindIfRunning"/> calls <see cref="BindToSource"/> to connect the linked object to the link source.
        /// </remarks>
        public HRESULT BindIfRunning()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[10])(thisPtr);
            }
        }

        /// <summary>
        /// Retrieves a pointer to the link source if the connection is active.
        /// </summary>
        /// <param name="ppunk">
        /// Address of <see cref="IDataObject"/> pointer variable that receives the interface pointer to the link source.
        /// When successful, the implementation must call IUnknown::AddRef on <paramref name="ppunk"/>;
        /// it is the caller's responsibility to call IUnknown::Release.
        /// If an error occurs, the implementation sets <paramref name="ppunk"/> to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// </returns>
        /// <remarks>
        /// You typically do not need to call <see cref="GetBoundSource"/>.
        /// </remarks>
        public HRESULT GetBoundSource([Out] out IntPtr ppunk)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out IntPtr, HRESULT>)_vTable[11])(thisPtr, out ppunk);
            }
        }

        /// <summary>
        /// Breaks the connection between a linked object and its link source.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// </returns>
        /// <remarks>
        /// You typically do not call <see cref="UnbindSource"/> directly.
        /// When it's necessary to deactivate the connection to the link source, your container typically calls <see cref="IOleObject.Close"/>:
        /// or IUnknown::Release; the linked object's implementation of these methods calls <see cref="UnbindSource"/>.
        /// The linked object's <see cref="IAdviseSink.OnClose"/> implementation also calls <see cref="UnbindSource"/>.
        /// Notes to Implementers
        /// The linked object's implementation of <see cref="UnbindSource"/> does nothing if the link source is not currently bound.
        /// If the link source is bound, <see cref="UnbindSource"/> calls the link source's <see cref="IOleObject.Unadvise"/>
        /// and <see cref="IDataObject.DUnadvise"/> implementations to delete the advisory connections to the link source.
        /// The <see cref="UnbindSource"/> method also calls the compound document's <see cref="IOleContainer.LockContainer"/> implementation
        /// to unlock the containing compound document.
        /// This undoes the lock on the container and the advisory connections that were established in <see cref="IOleLink.BindToSource"/>.
        /// <see cref="UnbindSource"/> releases all the linked object's interface pointers to the link source.
        /// </remarks>
        public HRESULT UnbindSource()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[12])(thisPtr);
            }
        }

        /// <summary>
        /// Updates the compound document's cached data for a linked object.
        /// This involves binding to the link source, if it is not already bound.
        /// </summary>
        /// <param name="pbc">
        /// A pointer to the <see cref="IBindCtx"/> interface on the bind context to be used in binding the link source.
        /// This parameter can be <see langword="null"/>.
        /// The bind context caches objects bound during the binding process, contains parameters that apply to all operations using the bind context,
        /// and provides the means by which the binding implementation should retrieve information about its environment.
        /// For more information, see <see cref="IBindCtx"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="CACHE_E_NOCACHE_UPDATED"/>: The bind operation worked but no caches were updated.
        /// <see cref="CACHE_S_SOMECACHES_NOTUPDATED"/>: The bind operation worked but not all caches were updated.
        /// <see cref="OLE_E_CANT_BINDTOSOURCE"/>: Unable to bind to the link source.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Your container application should call <see cref="Update"/> if the end user updates the cached data for a linked object.
        /// The end user can update the cached data for a linked object by choosing the Update Now button in the Links dialog box.
        /// If you use the <see cref="OleUIEditLinks"/> function to display the Links dialog box,
        /// you must implement the <see cref="IOleUILinkContainer"/> interface.
        /// The dialog box calls your implementations of <see cref="IOleUILinkContainer.UpdateLink"/> when the end user chooses the Update Now button.
        /// Your implementation of that method can call Update.
        /// Your container application can also call <see cref="Update"/> to update a linked object, because that method 
        /// when called on a linked object calls <see cref="Update"/>.
        /// This method updates both automatic links and manual links.
        /// For manual links, calling Update or Update is the only way to update the caches.
        /// For more information on automatic and manual links, see <see cref="SetUpdateOptions"/>.
        /// Notes on Implementation
        /// If <paramref name="pbc"/> is non-NULL, the linked object's implementation of <see cref="Update"/> calls
        /// <see cref="IBindCtx.RegisterObjectBound"/> to register the bound link source.
        /// This ensures that the link source remains running until the bind context is released.
        /// The current caches are left intact if the link source cannot be bound.
        /// </remarks>
        public HRESULT Update([In] in IBindCtx pbc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IBindCtx, HRESULT>)_vTable[13])(thisPtr, pbc);
            }
        }
    }
}
