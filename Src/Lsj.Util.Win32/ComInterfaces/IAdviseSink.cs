using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ADVF;
using static Lsj.Util.Win32.Enums.DVASPECT;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables containers and other objects to receive notifications of data changes, view changes,
    /// and compound-document changes occurring in objects of interest.
    /// Container applications, for example, require such notifications to keep cached presentations of their linked and embedded objects up-to-date.
    /// Calls to <see cref="IAdviseSink"/> methods are asynchronous,
    /// so the call is sent and then the next instruction is executed without waiting for the call's return.
    /// For an advisory connection to exist, the object that is to receive notifications must implement <see cref="IAdviseSink"/>,
    /// and the objects in which it is interested must implement <see cref="IOleObject.Advise"/> and <see cref="IDataObject.DAdvise"/>.
    /// In-process objects and handlers may also implement <see cref="IViewObject.SetAdvise"/>.
    /// Objects implementing <see cref="IOleObject"/> must support all reasonable advisory methods.
    /// To simplify advisory notifications, OLE supplies implementations of the <see cref="IDataAdviseHolder"/> and <see cref="IOleAdviseHolder"/>,
    /// which keep track of advisory connections and send notifications to the proper sinks through pointers to their <see cref="IAdviseSink"/> interfaces.
    /// <see cref="IViewObject"/> (and its advisory methods) is implemented in the default handler.
    /// As shown in the following table, an object that has implemented an advise sink registers its interest
    /// in receiving certain types of notifications by calling the appropriate method.
    /// Call This Method                    To Register for These Notifications
    /// <see cref="IOleObject.Advise"/>     When a document is saved, closed, or renamed.
    /// <see cref="IDataObject.DAdvise"/>   When a document's data changes.
    /// <see cref="IViewObject.SetAdvise"/> When a document's presentation changes.
    /// When an event occurs that applies to a registered notification type, the object application calls the appropriate <see cref="IAdviseSink"/> method.
    /// For example, when an embedded object closes, it calls the <see cref="IAdviseSink.OnClose"/> method to notify its container.
    /// These notifications are asynchronous, occurring after the events that trigger them.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-iadvisesink
    /// </para>
    /// </summary>
    public unsafe struct IAdviseSink
    {
        IntPtr* _vTable;

        /// <summary>
        /// Called by the server to notify a data object's currently registered advise sinks that data in the object has changed.
        /// </summary>
        /// <param name="pFormatetc">
        /// A pointer to a <see cref="FORMATETC"/> structure, which describes the format, target device,
        /// rendering, and storage information of the calling data object.
        /// </param>
        /// <param name="pStgmed">
        /// A pointer to a STGMEDIUM structure, which defines the storage medium
        /// (global memory, disk file, storage object, stream object, GDI object, or undefined) and ownership of that medium for the calling data object.
        /// </param>
        public void OnDataChange([In] in FORMATETC pFormatetc, [In] in STGMEDIUM pStgmed)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in FORMATETC, in STGMEDIUM, void>)_vTable[3])(thisPtr, pFormatetc, pStgmed);
            }
        }

        /// <summary>
        /// Notifies an object's registered advise sinks that its view has changed.
        /// </summary>
        /// <param name="dwAspect">
        /// The aspect, or view, of the object.
        /// Contains a value taken from the <see cref="DVASPECT"/> enumeration.
        /// </param>
        /// <param name="lindex">
        /// The portion of the view that has changed. Currently only -1 is valid.
        /// </param>
        /// <remarks>
        /// Containers register to be notified when an object's view changes by calling <see cref="IViewObject.SetAdvise"/>.
        /// After it is registered, the object will call the sink's <see cref="OnViewChange"/> method when appropriate.
        /// <see cref="OnViewChange"/> can be called when the object is in either the loaded or running state.
        /// Even though <see cref="DVASPECT"/> values are individual flag bits, dwAspect may represent only one value.
        /// That is, <paramref name="dwAspect"/> cannot contain the result of an OR operation combining two or more <see cref="DVASPECT"/> values.
        /// The <paramref name="lindex"/> parameter represents the part of the aspect that is of interest.
        /// The value of <paramref name="lindex"/> depends on the value of <paramref name="dwAspect"/>.
        /// If <paramref name="dwAspect"/> is either <see cref="DVASPECT_THUMBNAIL"/> or <see cref="DVASPECT_ICON"/>, <paramref name="lindex"/> is ignored.
        /// If <paramref name="dwAspect"/> is <see cref="DVASPECT_CONTENT"/>, lindex must be -1, 
        /// which indicates that the entire view is of interest and is the only value that is currently valid.
        /// </remarks>
        public void OnViewChange([In] DVASPECT dwAspect, [In] LONG lindex)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DVASPECT, LONG, void>)_vTable[4])(thisPtr, dwAspect, lindex);
            }
        }

        /// <summary>
        /// Called by the server to notify all registered advisory sinks that the object has been renamed.
        /// </summary>
        /// <param name="pmk">
        /// A pointer to the <see cref="IMoniker"/> interface on the new full moniker of the object.
        /// </param>
        /// <remarks>
        /// OLE link objects normally implement <see cref="OnRename"/> to receive notification of a change in the name of a link source or its container.
        /// The object serving as the link source calls <see cref="OnRename"/> and passes its new full moniker to the object handler,
        /// which forwards the notification to the link object.
        /// In response, the link object must update its moniker.
        /// The link object, in turn, forwards the notification to its own container.
        /// </remarks>
        public void OnRename([In] in IMoniker pmk)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in IMoniker, void>)_vTable[5])(thisPtr, pmk);
            }
        }

        /// <summary>
        /// Called by the server to notify all registered advisory sinks that the object has been saved.
        /// </summary>
        /// <remarks>
        /// Object handlers and link objects normally implement <see cref="OnSave"/> to receive notifications of when an object is saved to disk,
        /// either to its original storage (through a Save operation) or to new storage (through a Save As operation).
        /// Object Handlers and link objects register to be notified when an object is saved for the purpose of updating their caches,
        /// but then only if the advise flag passed during registration specifies <see cref="ADVFCACHE_ONSAVE"/>.
        /// Object handlers and link objects forward these notifications to their containers.
        /// </remarks>
        public void OnSave()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[6])(thisPtr);
            }
        }

        /// <summary>
        /// Called by the server to notify all registered advisory sinks that the object has changed from the running to the loaded state.
        /// </summary>
        /// <remarks>
        /// The <see cref="OnClose"/> notification indicates that an object is making the transition from the running to the loaded state,
        /// so its container can take appropriate measures to ensure an orderly shutdown.
        /// For example, an object handler must release its pointer to the object.
        /// If the object that is closing is the last open object supported by its OLE server application, the application can also shut down.
        /// In the case of a link object, the notification that the object is closing should always be interpreted to mean
        /// that the connection to the link source has broken.
        /// </remarks>
        public void OnClose()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[7])(thisPtr);
            }
        }
    }
}
