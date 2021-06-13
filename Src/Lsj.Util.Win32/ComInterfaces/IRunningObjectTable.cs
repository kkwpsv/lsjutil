using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ROTFLAGS;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Manages access to the running object table (ROT), a globally accessible look-up table on each workstation.
    /// A workstation's ROT keeps track of those objects that can be identified by a moniker and that are currently running on the workstation.
    /// When a client tries to bind a moniker to an object, the moniker checks the ROT to see if the object is already running;
    /// this allows the moniker to bind to the current instance instead of loading a new one.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-irunningobjecttable"/>
    /// </para>
    /// </summary>
    public unsafe struct IRunningObjectTable
    {
        IntPtr* _vTable;

        /// <summary>
        /// Registers an object and its identifying moniker in the running object table (ROT).
        /// </summary>
        /// <param name="grfFlags">
        /// Specifies whether the ROT's reference to <paramref name="punkObject"/> is weak or strong and controls access to the object
        /// through its entry in the ROT. For details, see the Remarks section.
        /// <see cref="ROTFLAGS_REGISTRATIONKEEPSALIVE"/>:
        /// When set, indicates a strong registration for the object.
        /// <see cref="ROTFLAGS_ALLOWANYCLIENT"/>:
        /// When set, any client can connect to the running object through its entry in the ROT.
        /// When not set, only clients in the window station that registered the object can connect to it.
        /// </param>
        /// <param name="punkObject">
        /// A pointer to the object that is being registered as running.
        /// </param>
        /// <param name="pmkObjectName">
        /// A pointer to the moniker that identifies <paramref name="punkObject"/>.
        /// </param>
        /// <param name="pdwRegister">
        /// An identifier for this ROT entry that can be used in subsequent calls to
        /// <see cref="IRunningObjectTable.Revoke"/> or <see cref="IRunningObjectTable.NoteChangeTime"/>.
        /// The caller cannot specify <see cref="NullRef{DWORD}"/> for this parameter.
        /// If an error occurs, <paramref name="pdwRegister"/> is set to zero.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_INVALIDARG"/> and <see cref="E_OUTOFMEMORY"/>,
        /// as well as the following values.
        /// <see cref="S_OK"/>:
        /// The method completed successfully.
        /// <see cref="MK_S_MONIKERALREADYREGISTERED"/>:
        /// The moniker/object pair was successfully registered,
        /// but that another object (possibly the same object) has already been registered with the same moniker.
        /// </returns>
        /// <remarks>
        /// This method registers a pointer to an object under a moniker that identifies the object.
        /// The moniker is used as the key when the table is searched with <see cref="IRunningObjectTable.GetObject"/>.
        /// When an object is registered, the ROT always calls AddRef on the object.
        /// For a weak registration (<see cref="ROTFLAGS_REGISTRATIONKEEPSALIVE"/> not set),
        /// the ROT will release the object whenever the last strong reference to the object is released.
        /// For a strong registration (<see cref="ROTFLAGS_REGISTRATIONKEEPSALIVE"/> set),
        /// the ROT prevents the object from being destroyed until the object's registration is explicitly revoked.
        /// A server registered as either LocalService or RunAs can set the <see cref="ROTFLAGS_ALLOWANYCLIENT"/> flag
        /// in its call to Register to allow any client to connect to it.
        /// A server setting this bit must have its executable name in the AppID section of the registry that refers to the AppID for the executable.
        /// An "activate as activator" server (not registered as LocalService or RunAs) must not set this flag in its call to Register.
        /// For details on installing services, see Installing as a Service Application.
        /// Registering a second object with the same moniker, or re-registering the same object with the same moniker,
        /// creates a second entry in the ROT. In this case, Register returns <see cref="MK_S_MONIKERALREADYREGISTERED"/>.
        /// Each call to Register must be matched by a call to <see cref="IRunningObjectTable.Revoke"/>
        /// because even duplicate entries have different <paramref name="pdwRegister"/> identifiers.
        /// A problem with duplicate registrations is that there is no way to determine which object will be returned
        /// if the moniker is specified in a subsequent call to <see cref="IRunningObjectTable.IsRunning"/>.
        /// Notes to Callers
        /// If you are a moniker provider (that is, you hand out monikers identifying your objects to make them accessible to others),
        /// you must call the Register method to register your objects when they begin running.
        /// You must also call this method if you rename your objects while they are loaded.
        /// The most common type of moniker provider is a compound-document link source.
        /// This includes server applications that support linking to their documents (or portions of a document)
        /// and container applications that support linking to embeddings within their documents.
        /// Server applications that do not support linking can also use the ROT
        /// to cooperate with container applications that support linking to embeddings.
        /// If you are writing a server application, you should register an object with the ROT when it begins running,
        /// typically in your implementation of <see cref="IOleObject.DoVerb"/>.
        /// The object must be registered under its full moniker, which requires getting the moniker
        /// of its container document using <see cref="IOleClientSite.GetMoniker"/>.
        /// You should also revoke and re-register the object in your implementation of <see cref="IOleObject.SetMoniker"/>,
        /// which is called if the container document is renamed.
        /// If you are writing a container application that supports linking to embeddings,
        /// you should register your document with the ROT when it is loaded.
        /// If your document is renamed, you should revoke and re-register it with the ROT and call <see cref="IOleObject.SetMoniker"/>
        /// for any embedded objects in the document to give them an opportunity to re-register themselves.
        /// Objects registered in the ROT must be explicitly revoked when the object is no longer running or when its moniker changes.
        /// This revocation is important because there is no way for the system to automatically remove entries from the ROT.
        /// You must cache the identifier that is written through <paramref name="pdwRegister"/> and use it
        /// in a call to <see cref="IRunningObjectTable.Revoke"/> to revoke the registration.
        /// For a strong registration, a strong reference is released when the objects registration is revoked.
        /// As of Windows Server 2003, if there are stale entries that remain in the ROT due to unexpected server problems,
        /// COM will automatically remove these stale entries from the ROT.
        /// The system's implementation of Register calls <see cref="IMoniker.Reduce"/> on the <paramref name="pmkObjectName"/> parameter
        /// to ensure that the moniker is fully reduced before registration.
        /// If an object is known by more than one fully reduced moniker, it should be registered under all such monikers.
        /// </remarks>
        public HRESULT Register([In] ROTFLAGS grfFlags, [In] in IUnknown punkObject, [In] in IMoniker pmkObjectName, [Out] out DWORD pdwRegister)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ROTFLAGS, in IUnknown, in IMoniker, out DWORD, HRESULT>)_vTable[3])(thisPtr, grfFlags, punkObject, pmkObjectName, out pdwRegister);
            }
        }

        /// <summary>
        /// Determines whether the object identified by the specified moniker is running, and if it is, retrieves a pointer to that object.
        /// </summary>
        /// <param name="pmkObjectName">
        /// A pointer to the <see cref="IMoniker"/> interface on the moniker.
        /// </param>
        /// <param name="ppunkObject">
        /// A pointer to an <see cref="IUnknown"/> pointer variable that receives the interface pointer to the running object.
        /// When successful, the implementation calls AddRef on the object; it is the caller's responsibility to call Release.
        /// If the object is not running or if an error occurs, the implementation sets *<paramref name="ppunkObject"/> to <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>:
        /// Indicates that <paramref name="pmkObjectName"/> was found in the ROT and a pointer was retrieved.
        /// <see cref="S_FALSE"/>:
        /// There is no entry for <paramref name="pmkObjectName"/> in the ROT, or that the object it identifies is no longer running
        /// (in which case, the entry is revoked).
        /// </returns>
        /// <remarks>
        /// This method checks the ROT for the moniker specified by <paramref name="pmkObjectName"/>.
        /// If that moniker had previously been registered with a call to <see cref="IRunningObjectTable.Register"/>,
        /// this method returns the pointer that was registered at that time.
        /// Notes to Caller
        /// Generally, you call the <see cref="IRunningObjectTable.GetObject"/> method only if you are writing your own moniker class
        /// (that is, implementing the <see cref="IMoniker"/> interface).
        /// You typically call this method from your implementation of <see cref="IMoniker.BindToObject"/>.
        /// However, note that not all implementations of <see cref="IMoniker.BindToObject"/> need to call this method.
        /// If you expect your moniker to have a prefix (indicated by a non-NULL pmkToLeft parameter to <see cref="IMoniker.BindToObject"/>),
        /// you should not check the ROT.
        /// The reason for this is that only complete monikers are registered with the ROT, and if your moniker has a prefix,
        /// your moniker is part of a composite and thus not complete.
        /// Instead, your moniker should request services from the object identified by the prefix
        /// (for example, the container of the object identified by your moniker).
        /// </remarks>
        public HRESULT GetObject([In] in IMoniker pmkObjectName, [Out] out IntPtr ppunkObject)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IMoniker, out IntPtr, HRESULT>)_vTable[6])(thisPtr, pmkObjectName, out ppunkObject);
            }
        }
    }
}
