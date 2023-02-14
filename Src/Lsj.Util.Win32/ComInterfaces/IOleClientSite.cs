using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.OLEGETMONIKER;
using static Lsj.Util.Win32.Enums.OLEWHICHMK;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides the primary means by which an embedded object obtains information about the location and extent of its display site,
    /// its moniker, its user interface, and other resources provided by its container.
    /// An object server calls <see cref="IOleClientSite"/> to request services from the container.
    /// A container must provide one instance of <see cref="IOleClientSite"/> for every compound-document object it contains.
    /// Note
    /// This interface is not supported for use across machine boundaries.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ioleclientsite"/>
    /// </para>
    /// </summary>
    public unsafe struct IOleClientSite
    {
        IntPtr* _vTable;

        /// <summary>
        /// Saves the embedded object associated with the client site.
        /// This function is synchronous; by the time it returns, the save will be completed.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_FAIL"/>: The operation has failed. 
        /// </returns>
        /// <remarks>
        /// An embedded object calls <see cref="SaveObject"/> to ask its container to save it to
        /// persistent storage when an end user chooses the File Update or Exit commands.
        /// The call is synchronous, meaning that by the time it returns, the save operation will be completed.
        /// Calls to <see cref="SaveObject"/> occur in most implementations of <see cref="IOleObject.Close"/>.
        /// Normally, when a container tells an object to close, the container passes a flag specifying
        /// whether the object should save itself before closing, prompt the user for instructions, or close without saving itself.
        /// If an object is instructed to save itself, either by its container or an end user,
        /// it calls <see cref="SaveObject"/> to ask the container application to save the object's contents before the object closes itself.
        /// If a container instructs an object not to save itself, the object should not call <see cref="SaveObject"/>.
        /// </remarks>
        public HRESULT SaveObject()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[3])(thisPtr);
            }
        }

        /// <summary>
        /// Retrieves a moniker for the object's client site.
        /// An object can force the assignment of its own or its container's moniker by specifying a value for <paramref name="dwAssign"/>.
        /// </summary>
        /// <param name="dwAssign">
        /// Specifies whether to get a moniker only if one already exists, force assignment of a moniker,
        /// create a temporary moniker, or remove a moniker that has been assigned.
        /// In practice, you will usually request that the container force assignment of the moniker.
        /// Possible values are taken from the <see cref="OLEGETMONIKER"/> enumeration.
        /// </param>
        /// <param name="dwWhichMoniker">
        /// Specifies whether to return the container's moniker, the object's moniker relative to the container, or the object's full moniker.
        /// In practice, you will usually request the object's full moniker.
        /// Possible values are taken from the <see cref="OLEWHICHMK"/> enumeration.
        /// </param>
        /// <param name="ppmk">
        /// A pointer to an <see cref="IMoniker"/> pointer variable that receives the interface pointer to the moniker for the object's client site.
        /// If an error occurs, the implementation must set <paramref name="ppmk"/> to <see langword="null"/>.
        /// Each time a container receives a call to <see cref="GetMoniker"/>, it must increase the reference count on the ppmk pointer it returns.
        /// It is the caller's responsibility to call Release when it is finished with the pointer.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_NOTIMPL"/>: This container cannot assign monikers to objects. This is the case with OLE 1 containers. 
        /// </returns>
        /// <remarks>
        /// Containers implement <see cref="GetMoniker"/> as a way of passing out monikers
        /// for their embedded objects to clients that need to link to those objects.
        /// When a link is made to an embedded object or to a pseudo-object within it (a range of cells in a spreadsheet, for example),
        /// the object needs a moniker to construct the composite moniker indicating the source of the link.
        /// If the embedded object does not already have a moniker, it can call <see cref="GetMoniker"/> to request one.
        /// Every container that expects to contain links to embeddings should support <see cref="GetMoniker"/>
        /// to give out <see cref="OLEWHICHMK_CONTAINER"/>, thus enabling link tracking when the link client and link source files move,
        /// but maintain the same relative position.
        /// An object must not persistently store its full moniker or its container's moniker, because these can change while the object is not loaded.
        /// For example, either the container or the object could be renamed, in which event,
        /// storing the container's moniker or the object's full moniker would make it impossible for a client to track a link to the object.
        /// In some very specialized cases, an object may no longer need a moniker previously
        /// assigned to it and may wish to have it removed as an optimization.
        /// In such cases, the object can call GetMoniker with <see cref="OLEGETMONIKER_UNASSIGN"/> to have the moniker removed.
        /// </remarks>
        public HRESULT GetMoniker([In] OLEGETMONIKER dwAssign, [In] OLEWHICHMK dwWhichMoniker, [Out] out IntPtr ppmk)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, OLEGETMONIKER, OLEWHICHMK, out IntPtr, HRESULT>)_vTable[4])(thisPtr, dwAssign, dwWhichMoniker, out ppmk);
            }
        }

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the object's container.
        /// </para>
        /// </summary>
        /// <param name="ppContainer">
        /// Address of <see cref="IOleContainer"/> pointer variable that receives the interface pointer to the container object.
        /// If an error occurs, the implementation must set <paramref name="ppContainer"/> to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method returns S_OK on success. Other possible return values include the following.
        /// <see cref="OLE_E_NOT_SUPPORTED"/>: The client site is in an OLE 1 container. 
        /// <see cref="E_NOINTERFACE"/>: The container does not implement the <see cref="IOleContainer"/> interface. 
        /// </returns>
        /// <remarks>
        /// If a container supports links to its embedded objects, implementing <see cref="GetContainer"/> enables link clients
        /// to enumerate the container's objects and recursively traverse a containment hierarchy.
        /// This method is optional but recommended for all containers that expect to support links to their embedded objects.
        /// Link clients can traverse a hierarchy of compound-document objects by recursively calling <see cref="GetContainer"/>
        /// to get a pointer to the link source's container; followed by QueryInterface to get a pointer
        /// to the container's <see cref="IOleObject"/> interface and, finally,
        /// <see cref="IOleObject.GetClientSite"/> to get the container's client site in its container.
        /// Simple containers that do not support links to their embedded objects probably do not need to implement this method.
        /// Instead, they can return <see cref="E_NOINTERFACE"/> and set <paramref name="ppContainer"/> to <see langword="null"/>.
        /// </remarks>
        public HRESULT GetContainer([Out] out IntPtr ppContainer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out IntPtr, HRESULT>)_vTable[5])(thisPtr, out ppContainer);
            }
        }

        /// <summary>
        /// Asks a container to display its object to the user.
        /// This method ensures that the container itself is visible and not minimized.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_E_NOT_SUPPORTED"/>: Client site is in an OLE 1 container. 
        /// </returns>
        /// <remarks>
        /// After a link client binds to a link source, it commonly calls <see cref="IOleObject.DoVerb"/> on the link source,
        /// usually requesting the source to perform some action requiring that it display itself to the user.
        /// As part of its implementation of <see cref="IOleObject.DoVerb"/>, the link source can call <see cref="ShowObject"/>,
        /// which forces the client to show the link source as best it can.
        /// If the link source's container is itself an embedded object, it will recursively invoke <see cref="ShowObject"/> on its own container.
        /// Having called the <see cref="ShowObject"/> method, a link source has no guarantee of being appropriately displayed
        /// because its container may not be able to do so at the time of the call.
        /// The <see cref="ShowObject"/> method does not guarantee visibility, only that the container will do the best it can.
        /// </remarks>
        public HRESULT ShowObject()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[6])(thisPtr);
            }
        }

        /// <summary>
        /// Notifies a container when an embedded object's window is about to become visible or invisible.
        /// This method does not apply to an object that is activated in place and therefore has no window separate from that of its container.
        /// </summary>
        /// <param name="fShow">
        /// Indicates whether an object's window is open (<see cref="TRUE"/>) or closed (<see cref="FALSE"/>).
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// </returns>
        /// <remarks>
        /// An embedded object calls <see cref="OnShowWindow"/> to keep its container informed when the object is open in a window.
        /// This window may or may not be currently visible to the end user.
        /// The container uses this information to shade the object's client site when the object is displayed in a window,
        /// and to remove the shading when the object is not.
        /// A shaded object, having received this notification,
        /// knows that it already has an open window and therefore can respond to being double-clicked by bringing this window quickly to the top,
        /// instead of launching its application in order to obtain a new one.
        /// </remarks>
        public HRESULT OnShowWindow([In] BOOL fShow)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[7])(thisPtr, fShow);
            }
        }

        /// <summary>
        /// Asks a container to resize the display site for embedded objects.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_NOTIMPL"/>: Client site does not support requests for new layout. 
        /// </returns>
        /// <remarks>
        /// This method can either increase or decrease the space.
        /// Currently, there is no standard mechanism by which a container can negotiate how much room an object would like.
        /// When such a negotiation is defined, responding to this method will be optional for containers.
        /// </remarks>
        public HRESULT RequestNewObjectLayout()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[8])(thisPtr);
            }
        }
    }
}
